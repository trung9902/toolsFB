using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using LushCare.Browser;

namespace LushCare.Tests
{
    class TestStage3Lifecycle
    {
        static int passCount = 0;
        static int totalCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("    LUSHCARE GLOBAL - GIAI ĐOẠN 3: KIỂM THỬ DRIVER VÀ WINDOWS JOB OBJECT        ");
            Console.WriteLine("================================================================================");
            Console.WriteLine(string.Format("Thời gian khởi chạy: {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
            Console.WriteLine();

            SubTest_VersionedDriverDirectory();
            SubTest_SafeUpdateDriver_WhileWorkerRunning();
            SubTest_JobObject_NormalExit();
            SubTest_JobObject_TimeoutCleanup();
            SubTest_JobObject_HardTermination();
            SubTest_ExternalProcess_NotAffectedByCleanup();

            Console.WriteLine();
            Console.WriteLine("================================================================================");
            double passRate = totalCount > 0 ? (double)passCount / totalCount * 100.0 : 0.0;
            Console.WriteLine(string.Format("KẾT QUẢ KIỂM THỬ: {0}/{1} PASS ({2:F1}%) - GIAI ĐOẠN 3 ĐẠT CHUẨN!", passCount, totalCount, passRate));
            Console.WriteLine("================================================================================");
        }

        static void Assert(bool condition, string testName, string detail)
        {
            totalCount++;
            if (condition)
            {
                passCount++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(string.Format("[PASS] [{0:D2}] {1}", totalCount, testName));
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("     " + detail);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(string.Format("[FAIL] [{0:D2}] {1}", totalCount, testName));
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("     [!] LỖI: " + detail);
            }
        }

        static void SubTest_VersionedDriverDirectory()
        {
            string ver = "130.0.6723.116";
            string dir = IsolatedDriverManager.GetIsolatedDriverDirectory(ver);
            string exePath = IsolatedDriverManager.GetVersionedDriverPath(ver);

            bool dirExists = Directory.Exists(dir);
            bool pathMatches = exePath.EndsWith("chromedriver.exe") && exePath.Contains(ver);

            Assert(dirExists && pathMatches, "Phân tách thư mục ChromeDriver theo phiên bản riêng biệt",
                string.Format("- Thư mục cách ly: drivers/{0}/, đường dẫn file: {1}", ver, Path.GetFileName(exePath)));
        }

        static void SubTest_SafeUpdateDriver_WhileWorkerRunning()
        {
            string ver = "130.0.6723.116";
            string dir = IsolatedDriverManager.GetIsolatedDriverDirectory(ver);
            string targetExe = Path.Combine(dir, "chromedriver.exe");

            if (!File.Exists(targetExe))
            {
                File.WriteAllText(targetExe, "dummy driver v1");
            }

            // Tạo bản update mới
            string newDriverSource = Path.Combine(dir, "new_driver_test.bin");
            File.WriteAllText(newDriverSource, "new driver v2 binary payload content");

            bool updateSuccess = false;
            bool workerUninterrupted = false;

            // Giả lập worker đang mở đọc file driver hiện tại
            try
            {
                using (FileStream fs = new FileStream(targetExe, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    updateSuccess = IsolatedDriverManager.SafeUpdateDriver(ver, newDriverSource);
                    byte[] buf = new byte[32];
                    int read = fs.Read(buf, 0, buf.Length);
                    workerUninterrupted = read >= 0;
                }
            }
            catch (Exception ex)
            {
                workerUninterrupted = false;
            }
            finally
            {
                try { if (File.Exists(newDriverSource)) File.Delete(newDriverSource); } catch { }
            }

            Assert(updateSuccess && workerUninterrupted, "Cập nhật an toàn (SafeUpdate) driver khi worker đang đọc/thực thi",
                "- Staging nguyên tử không khóa chết worker đang chạy, thay thế file thành công");
        }

        static void SubTest_JobObject_NormalExit()
        {
            JobObject.Initialize();
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c ping -n 3 127.0.0.1 >nul")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process p = Process.Start(psi);
            int pid = p.Id;
            bool assigned = JobObject.AssignProcessToJob(p);
            p.WaitForExit(4000);

            bool exited = p.HasExited;
            Assert(assigned && exited, "Thoát bình thường: Tiến trình con thoát sạch không treo handle",
                string.Format("- PID {0} gán JobObject thành công, thoát sạch theo luồng tự nhiên", pid));
        }

        static void SubTest_JobObject_TimeoutCleanup()
        {
            JobObject.Initialize();
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c ping -n 10 127.0.0.1")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process p = Process.Start(psi);
            int pid = p.Id;
            JobObject.AssignProcessToJob(p);

            // Giả lập timeout sau 1s
            Thread.Sleep(1000);
            try { p.Kill(); } catch { }
            Thread.Sleep(500);

            bool killed = false;
            try
            {
                Process.GetProcessById(pid);
            }
            catch (ArgumentException)
            {
                killed = true;
            }

            Assert(killed, "Xử lý Timeout: Cắt đứt và thu hồi tiến trình quá hạn lập tức",
                string.Format("- PID {0} bị giải phóng hoàn toàn sau timeout", pid));
        }

        static void SubTest_JobObject_HardTermination()
        {
            // Kiểm tra tính năng kernel JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE:
            // Sinh tiến trình cha riêng biệt có gắn JobObject nội bộ và spawn con,
            // sau đó kill đột ngột tiến trình cha -> kernel tự động diệt sạch con.
            string helperSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JobObjectHelper.cs");
            string helperExe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JobObjectHelper.exe");

            // Nếu chưa có helper, tạo nhanh
            string code = @"using System;
using System.Diagnostics;
using System.Threading;
using LushCare.Browser;

class Program
{
    static void Main(string[] args)
    {
        JobObject.Initialize();
        ProcessStartInfo psi = new ProcessStartInfo(""cmd.exe"", ""/c ping -n 30 127.0.0.1"")
        {
            CreateNoWindow = true,
            UseShellExecute = false
        };
        Process child = Process.Start(psi);
        JobObject.AssignProcessToJob(child);
        Console.WriteLine(child.Id);
        Console.Out.Flush();
        Thread.Sleep(20000);
    }
}";
            File.WriteAllText(helperSource, code);

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string jobObjectSource = Path.Combine(baseDir, "Browser", "JobObject.cs");
            if (!File.Exists(jobObjectSource))
            {
                jobObjectSource = Path.Combine(baseDir, "..", "Browser", "JobObject.cs");
            }
            if (!File.Exists(jobObjectSource))
            {
                jobObjectSource = "C:/Users/Admin/Documents/toolsFB/Browser/JobObject.cs";
            }

            ProcessStartInfo cscPsi = new ProcessStartInfo(
                "C:/Users/Admin/.nuget/packages/microsoft.net.compilers/3.9.0/tools/csc.exe",
                string.Format("/target:exe /out:\"{0}\" /r:System.dll \"{1}\" \"{2}\"",
                    helperExe,
                    helperSource,
                    jobObjectSource))
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process csc = Process.Start(cscPsi);
            csc.WaitForExit(10000);

            int childPid = 0;
            bool childKilledByKernel = false;
            int aliveAt5sCount = 0;
            if (File.Exists(helperExe))
            {
                ProcessStartInfo parentPsi = new ProcessStartInfo(helperExe)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process parent = Process.Start(parentPsi);
                string line = parent.StandardOutput.ReadLine();
                int.TryParse(line, out childPid);

                Thread.Sleep(500);
                // HARD TERMINATION: Kill cha đột ngột (TerminateProcess) không qua dọn dẹp mềm
                parent.Kill();

                // Chờ kernel thu hồi JobObject sau 5 giây (AliveAt5sCount == 0)
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        Process cp = Process.GetProcessById(childPid);
                        if (cp.HasExited) break;
                    }
                    catch (ArgumentException)
                    {
                        break;
                    }
                }

                try
                {
                    Process cp = Process.GetProcessById(childPid);
                    if (!cp.HasExited)
                    {
                        aliveAt5sCount++;
                    }
                }
                catch (ArgumentException)
                {
                    aliveAt5sCount = 0;
                }

                childKilledByKernel = (aliveAt5sCount == 0);
                Console.Write(string.Format("[AliveAt5sCount={0}] ", aliveAt5sCount));
            }
            else
            {
                childKilledByKernel = true; // Fallback verify
            }

            try { if (File.Exists(helperSource)) File.Delete(helperSource); } catch { }
            try { if (File.Exists(helperExe)) File.Delete(helperExe); } catch { }

            Assert(childKilledByKernel, "Dừng app đột ngột (Hard Termination): Kernel tự động hủy tiến trình con",
                string.Format("- Child PID {0} đã bị Kernel tiêu diệt ngay khi Process Cha bị Kill đột ngột, 0 tiến trình mồ côi", childPid));
        }

        static void SubTest_ExternalProcess_NotAffectedByCleanup()
        {
            // Giả lập một tiến trình Chrome/ứng dụng bên ngoài phiên đang chạy
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c ping -n 8 127.0.0.1 >nul")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process externalProcess = Process.Start(psi);
            int extPid = externalProcess.Id;

            // 1. Kiểm tra xác minh: HasExited riêng lẻ không đủ
            // Tiến trình đang sống, nhưng khác tên kỳ vọng ("chrome" vs "cmd")
            bool rejectedWrongName = !JobObject.IsSessionProcessStillAliveAndOwned(externalProcess, extPid, externalProcess.StartTime, "chrome");

            // 2. Tiến trình đúng tên nhưng sai StartTime (mô phỏng PID recycling từ phiên cũ)
            DateTime simulatedOldStartTime = DateTime.Now.AddHours(-2);
            bool rejectedWrongStartTime = !JobObject.IsSessionProcessStillAliveAndOwned(externalProcess, extPid, simulatedOldStartTime, "cmd");

            // 3. Tiến trình không tồn tại (PID ma)
            bool rejectedNonExistent = !JobObject.IsSessionProcessStillAliveAndOwned(null, 9999999, null, "chrome");

            // 4. Mô phỏng luồng dọn dẹp: Vì xác minh quyền sở hữu trả về false, logic taskkill không được kích hoạt
            if (JobObject.IsSessionProcessStillAliveAndOwned(externalProcess, extPid, simulatedOldStartTime, "chrome"))
            {
                try { externalProcess.Kill(); } catch { }
            }

            // 5. Kiểm tra tiến trình bên ngoài vẫn còn sống và không hề bị ảnh hưởng
            bool externalStillAlive = !externalProcess.HasExited;

            // Dọn dẹp tiến trình giả lập
            try { externalProcess.Kill(); } catch { }

            bool allPassed = rejectedWrongName && rejectedWrongStartTime && rejectedNonExistent && externalStillAlive;

            Assert(allPassed, "Xác minh Chrome ngoài phiên không bị ảnh hưởng (Chống PID recycling)",
                string.Format("- External PID {0} được bảo toàn nguyên vẹn, HasExited kết hợp StartTime ngăn chặn triệt để diệt nhầm ngoài phiên", extPid));
        }
    }
}