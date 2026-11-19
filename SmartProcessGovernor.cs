using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

/// <summary>
/// Bộ điều phối bộ nhớ và tiến trình tự động (SmartProcessGovernor) cho LushCare.
/// Chuyên trách:
/// 1. Quét và diệt sạch các tiến trình 'chromedriver.exe', 'gpmdriver.exe', 'gemlogindriver.exe' mồ côi (orphaned) hoặc treo.
/// 2. Quét và diệt sạch các tiến trình 'chrome.exe' chạy ngầm không có cửa sổ hiển thị hoặc thuộc về automation.
/// 3. Bảo vệ tuyệt đối trình duyệt Google Chrome cá nhân đang mở của người dùng.
/// 4. Flush và tối ưu bộ nhớ RAM của chính ứng dụng LushCare bằng Garbage Collection và Win32 EmptyWorkingSet API.
/// </summary>
public static class SmartProcessGovernor
{
    [DllImport("psapi.dll")]
    static extern int EmptyWorkingSet(IntPtr hwProc);

    [DllImport("kernel32.dll")]
    static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

    /// <summary>
    /// Các cờ nhận diện Chrome khởi tạo từ automation / Selenium / Puppeteer / MaxCare / LushCare
    /// </summary>
    private static readonly string[] AutomationFlags = new[]
    {
        "--remote-debugging-port",
        "--test-type",
        "--disable-blink-features=AutomationControlled",
        "--enable-automation",
        "--remote-allow-origins",
        "--headless",
        "profiles\\",
        "profiles/",
        "temp_",
        "\\gologin\\",
        "\\gpmlogin\\",
        "\\gemlogin\\",
        "\\LushCare\\",
        "\\MaxCare\\",
        "\\profile_"
    };

    /// <summary>
    /// Các tiến trình WebDriver tự động hóa
    /// </summary>
    private static readonly string[] DriverProcessNames = new[]
    {
        "chromedriver",
        "gpmdriver",
        "gemlogindriver"
    };

    /// <summary>
    /// Snapshot thông tin tiến trình từ WMI
    /// </summary>
    private class ProcessSnapshot
    {
        public int Pid;
        public int ParentPid;
        public string Name;
        public string CommandLine;
        public string ExecutablePath;
    }

    /// <summary>
    /// Thu hồi RAM của ứng dụng LushCare bằng Garbage Collection và Win32 EmptyWorkingSet API.
    /// Trả về dung lượng RAM hiện tại của tiến trình (bytes).
    /// </summary>
    public static long FlushCurrentAppMemory()
    {
        try
        {
            // 1. Thu hồi bộ nhớ managed trên tất cả các thế hệ (Gen 0, 1, 2)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // 2. Gọi Win32 EmptyWorkingSet và SetProcessWorkingSetSize giải phóng Working Set
            using (Process currentProcess = Process.GetCurrentProcess())
            {
                IntPtr handle = currentProcess.Handle;
                try
                {
                    EmptyWorkingSet(handle);
                }
                catch { }

                try
                {
                    SetProcessWorkingSetSize(handle, -1, -1);
                }
                catch { }

                currentProcess.Refresh();
                return currentProcess.WorkingSet64;
            }
        }
        catch
        {
            return 0;
        }
    }

    /// <summary>
    /// Quét và diệt sạch các tiến trình ChromeDriver/Chrome treo ngầm, mồ côi hoặc thuộc về automation,
    /// đồng thời giải phóng triệt để bộ nhớ RAM của ứng dụng LushCare.
    /// </summary>
    /// <param name="killChromes">Có quét và dọn các Chrome automation / treo ngầm hay không (mặc định: true)</param>
    /// <returns>(số driver đã diệt, số chrome đã diệt, tổng dung lượng RAM đã giải phóng tính bằng bytes)</returns>
    public static (int killedDrivers, int killedChromes, long ramFreedBytes) CleanZombieProcessesAndFlushMemory(bool killChromes = true)
    {
        int killedDrivers = 0;
        int killedChromes = 0;
        long ramFreedBytes = 0;

        long initialAppWorkingSet = 0;
        try
        {
            using (Process current = Process.GetCurrentProcess())
            {
                initialAppWorkingSet = current.WorkingSet64;
            }
        }
        catch { }

        try
        {
            // 1. Lấy metadata của các tiến trình liên quan qua WMI (ProcessId, ParentProcessId, CommandLine)
            Dictionary<int, ProcessSnapshot> wmiMap = GetProcessMetadata();

            // 2. Tập hợp các PID của WebDriver
            HashSet<int> driverPids = new HashSet<int>();
            List<Process> driverProcesses = new List<Process>();

            foreach (string driverName in DriverProcessNames)
            {
                try
                {
                    Process[] procs = Process.GetProcessesByName(driverName);
                    foreach (var p in procs)
                    {
                        driverProcesses.Add(p);
                        driverPids.Add(p.Id);
                    }
                }
                catch { }
            }

            // 3. Quét và diệt ChromeDriver mồ côi (orphaned) hoặc treo
            foreach (Process driverProc in driverProcesses)
            {
                try
                {
                    if (driverProc.HasExited) continue;

                    int pid = driverProc.Id;
                    int parentPid = 0;
                    if (wmiMap.TryGetValue(pid, out var snap))
                    {
                        parentPid = snap.ParentPid;
                    }

                    DateTime startTime = DateTime.MinValue;
                    try { startTime = driverProc.StartTime; } catch { }

                    bool shouldKill = false;

                    if (parentPid <= 0)
                    {
                        // Không có tiến trình cha -> mồ côi
                        shouldKill = true;
                    }
                    else if (!IsParentAlive(parentPid, startTime))
                    {
                        // Tiến trình cha đã thoát hoặc PID bị tái sử dụng -> mồ côi 100%
                        shouldKill = true;
                    }
                    else
                    {
                        // Nếu tiến trình cha còn sống (ví dụ là LushCare):
                        // Kiểm tra xem driver này có Chrome con nào đang chạy không
                        bool hasChildChrome = false;
                        foreach (var kvp in wmiMap)
                        {
                            if (kvp.Value.ParentPid == pid && kvp.Value.Name.Equals("chrome.exe", StringComparison.OrdinalIgnoreCase))
                            {
                                hasChildChrome = true;
                                break;
                            }
                        }

                        // Nếu driver không điều khiển bất kỳ Chrome nào -> driver treo ngầm vô dụng
                        if (!hasChildChrome)
                        {
                            shouldKill = true;
                        }
                    }

                    if (shouldKill)
                    {
                        var (killed, ws) = SafeKillProcess(driverProc);
                        if (killed)
                        {
                            killedDrivers++;
                            ramFreedBytes += ws;
                        }
                    }
                }
                catch { }
                finally
                {
                    try { driverProc.Dispose(); } catch { }
                }
            }

            // 4. Quét và diệt Chrome ngầm / automation (nếu được yêu cầu)
            if (killChromes)
            {
                // Danh sách PID của Chrome cần diệt
                HashSet<int> chromePidsToKill = new HashSet<int>();

                // Bước 4.1: Nhận diện các Chrome gốc thuộc về Automation hoặc là con của driver
                foreach (var kvp in wmiMap)
                {
                    var snap = kvp.Value;
                    if (snap.Name.Equals("chrome.exe", StringComparison.OrdinalIgnoreCase))
                    {
                        bool isDriverChild = driverPids.Contains(snap.ParentPid);
                        bool isAutoCmd = IsAutomationCommandLine(snap.CommandLine);

                        if (isDriverChild || isAutoCmd)
                        {
                            chromePidsToKill.Add(snap.Pid);
                        }
                    }
                }

                // Bước 4.2: Lan truyền xuống toàn bộ cây con của Chrome automation (renderers, gpu, crashpad)
                bool addedChild = true;
                while (addedChild)
                {
                    addedChild = false;
                    foreach (var kvp in wmiMap)
                    {
                        var snap = kvp.Value;
                        if (snap.Name.Equals("chrome.exe", StringComparison.OrdinalIgnoreCase))
                        {
                            if (!chromePidsToKill.Contains(snap.Pid) && chromePidsToKill.Contains(snap.ParentPid))
                            {
                                chromePidsToKill.Add(snap.Pid);
                                addedChild = true;
                            }
                        }
                    }
                }

                // Bước 4.3: Nhận diện các Chrome ngầm mồ côi (không có cửa sổ hiển thị VÀ tiến trình cha đã chết)
                foreach (var kvp in wmiMap)
                {
                    var snap = kvp.Value;
                    if (snap.Name.Equals("chrome.exe", StringComparison.OrdinalIgnoreCase))
                    {
                        if (chromePidsToKill.Contains(snap.Pid)) continue;

                        DateTime startTime = DateTime.MinValue;
                        try
                        {
                            using (Process p = Process.GetProcessById(snap.Pid))
                            {
                                startTime = p.StartTime;
                            }
                        }
                        catch { }

                        // Nếu tiến trình cha đã chết
                        if (snap.ParentPid <= 0 || !IsParentAlive(snap.ParentPid, startTime))
                        {
                            bool hasVisibleWindow = false;
                            try
                            {
                                using (Process p = Process.GetProcessById(snap.Pid))
                                {
                                    hasVisibleWindow = p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(p.MainWindowTitle);
                                }
                            }
                            catch { }

                            if (!hasVisibleWindow)
                            {
                                chromePidsToKill.Add(snap.Pid);
                            }
                        }
                    }
                }

                // Bước 4.4: Tiến hành diệt các Chrome đã được phân loại an toàn
                foreach (int pid in chromePidsToKill)
                {
                    try
                    {
                        using (Process p = Process.GetProcessById(pid))
                        {
                            var (killed, ws) = SafeKillProcess(p);
                            if (killed)
                            {
                                killedChromes++;
                                ramFreedBytes += ws;
                            }
                        }
                    }
                    catch { }
                }
            }

            // 5. Thu hồi RAM của chính ứng dụng LushCare
            long finalAppWorkingSet = FlushCurrentAppMemory();
            if (initialAppWorkingSet > finalAppWorkingSet)
            {
                ramFreedBytes += (initialAppWorkingSet - finalAppWorkingSet);
            }
        }
        catch { }

        return (killedDrivers, killedChromes, ramFreedBytes);
    }

    /// <summary>
    /// Kiểm tra xem CommandLine có chứa cờ automation hay không
    /// </summary>
    private static bool IsAutomationCommandLine(string cmdLine)
    {
        if (string.IsNullOrEmpty(cmdLine)) return false;

        foreach (string flag in AutomationFlags)
        {
            if (cmdLine.IndexOf(flag, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Kiểm tra xem tiến trình cha có còn sống hay không (kèm kiểm tra tái sử dụng PID)
    /// </summary>
    private static bool IsParentAlive(int parentPid, DateTime childStartTime)
    {
        if (parentPid <= 0) return false;
        try
        {
            using (Process parent = Process.GetProcessById(parentPid))
            {
                if (parent.HasExited) return false;

                // Nếu tiến trình cha khởi động sau tiến trình con -> PID đã bị Windows tái sử dụng
                try
                {
                    if (childStartTime != DateTime.MinValue && parent.StartTime > childStartTime)
                    {
                        return false;
                    }
                }
                catch { }

                return true;
            }
        }
        catch (ArgumentException)
        {
            // Process không tồn tại
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Diệt tiến trình một cách an toàn tuyệt đối với try/catch bọc kín
    /// </summary>
    private static (bool killed, long workingSet) SafeKillProcess(Process proc)
    {
        if (proc == null) return (false, 0);
        try
        {
            if (proc.HasExited) return (false, 0);

            long ws = 0;
            try { ws = proc.WorkingSet64; } catch { }

            try
            {
                proc.Kill();
                proc.WaitForExit(1000);
                return (true, ws);
            }
            catch
            {
                return (false, 0);
            }
        }
        catch
        {
            return (false, 0);
        }
    }

    /// <summary>
    /// Lấy metadata của các tiến trình Chrome và WebDriver từ WMI
    /// </summary>
    private static Dictionary<int, ProcessSnapshot> GetProcessMetadata()
    {
        var map = new Dictionary<int, ProcessSnapshot>();
        try
        {
            string query = "SELECT ProcessId, ParentProcessId, Name, CommandLine, ExecutablePath FROM Win32_Process " +
                           "WHERE Name = 'chromedriver.exe' OR Name = 'gpmdriver.exe' OR Name = 'gemlogindriver.exe' OR Name = 'chrome.exe'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            using (ManagementObjectCollection coll = searcher.Get())
            {
                foreach (ManagementObject mo in coll)
                {
                    try
                    {
                        int pid = Convert.ToInt32(mo["ProcessId"]);
                        int ppid = mo["ParentProcessId"] != null ? Convert.ToInt32(mo["ParentProcessId"]) : 0;
                        string name = mo["Name"]?.ToString() ?? "";
                        string cmd = mo["CommandLine"]?.ToString() ?? "";
                        string path = mo["ExecutablePath"]?.ToString() ?? "";

                        map[pid] = new ProcessSnapshot
                        {
                            Pid = pid,
                            ParentPid = ppid,
                            Name = name,
                            CommandLine = cmd,
                            ExecutablePath = path
                        };
                    }
                    catch { }
                }
            }
        }
        catch { }
        return map;
    }

    /// <summary>
    /// Định dạng dung lượng byte sang chuỗi thân thiện (MB, GB)
    /// </summary>
    public static string FormatBytes(long bytes)
    {
        if (bytes <= 0) return "0 MB";
        double mb = bytes / (1024.0 * 1024.0);
        if (mb < 1024.0)
        {
            return $"{mb:N1} MB";
        }
        double gb = mb / 1024.0;
        return $"{gb:N2} GB";
    }
}
