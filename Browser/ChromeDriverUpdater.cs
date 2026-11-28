using System;
using LushCare.Browser;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;

public static class ChromeDriverUpdater
{
    private static readonly object syncLock = new object();

    public static (bool success, string message) EnsureMatchingChromeDriver(string targetDir = "")
    {
        lock (syncLock)
        {
            try
            {
                if (string.IsNullOrEmpty(targetDir))
                {
                    targetDir = Commom.smethod_95();
                }

                string chromeVersion = GetInstalledChromeVersion();
                if (string.IsNullOrEmpty(chromeVersion))
                {
                    return (false, "Không tìm thấy Chrome.");
                }

                int chromeMajor = 0;
                string[] parts = chromeVersion.Split('.');
                if (!int.TryParse(parts[0], out chromeMajor) || chromeMajor <= 0)
                {
                    return (false, "Không parse được version Chrome: " + chromeVersion);
                }

                string driverPath = Path.Combine(targetDir, "chromedriver.exe");
                int driverMajor = 0;
                if (File.Exists(driverPath))
                {
                    try
                    {
                        var vi = FileVersionInfo.GetVersionInfo(driverPath);
                        if (!string.IsNullOrEmpty(vi.FileVersion))
                        {
                            int.TryParse(vi.FileVersion.Split('.')[0], out driverMajor);
                        }
                    }
                    catch { }
                }

                if (driverMajor != chromeMajor)
                {
                    return UpdateChromeDriver(targetDir);
                }

                return (true, "ChromeDriver đã khớp phiên bản Chrome " + chromeMajor);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kiểm tra ChromeDriver: " + ex.Message);
            }
        }
    }

    public static string GetInstalledChromeVersion(string customBinaryPath = "")
    {
        try
        {
            if (!string.IsNullOrEmpty(customBinaryPath) && File.Exists(customBinaryPath))
            {
                var vi = FileVersionInfo.GetVersionInfo(customBinaryPath);
                if (!string.IsNullOrEmpty(vi.FileVersion))
                    return vi.FileVersion;
            }

            string[] regKeys = new string[]
            {
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe",
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe"
            };

            foreach (var key in regKeys)
            {
                object val = Registry.GetValue(key, "", null);
                if (val != null && File.Exists(val.ToString()))
                {
                    var vi = FileVersionInfo.GetVersionInfo(val.ToString());
                    if (!string.IsNullOrEmpty(vi.FileVersion))
                        return vi.FileVersion;
                }
            }

            // Check default installation paths
            string[] defaultPaths = new string[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Google\Chrome\Application\chrome.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Google\Chrome\Application\chrome.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\Application\chrome.exe")
            };

            foreach (var p in defaultPaths)
            {
                if (File.Exists(p))
                {
                    var vi = FileVersionInfo.GetVersionInfo(p);
                    if (!string.IsNullOrEmpty(vi.FileVersion))
                        return vi.FileVersion;
                }
            }
        }
        catch
        {
        }

        return "";
    }

    public static (bool success, string message) UpdateChromeDriver(string targetDir = "")
    {
        try
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }
            catch { }
            if (string.IsNullOrEmpty(targetDir))
            {
                targetDir = AppDomain.CurrentDomain.BaseDirectory;
            }

            string chromeVersion = GetInstalledChromeVersion();
            if (string.IsNullOrEmpty(chromeVersion))
            {
                return (false, "Không tìm thấy phiên bản Google Chrome trên máy tính!");
            }

            int major = 0;
            string[] parts = chromeVersion.Split('.');
            if (!int.TryParse(parts[0], out major))
            {
                return (false, "Không xác định được phiên bản Chrome chính: " + chromeVersion);
            }

            string downloadUrl = "";
            string driverVersion = "";

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

                if (major >= 115)
                {
                    // Google Chrome for Testing API
                    try
                    {
                        string apiRelease = $"https://googlechromelabs.github.io/chrome-for-testing/LATEST_RELEASE_{major}";
                        driverVersion = wc.DownloadString(apiRelease).Trim();
                    }
                    catch
                    {
                        // Fallback to exact version match or LATEST_RELEASE
                        try
                        {
                            driverVersion = wc.DownloadString("https://googlechromelabs.github.io/chrome-for-testing/LATEST_RELEASE").Trim();
                        }
                        catch { }
                    }

                    if (!string.IsNullOrEmpty(driverVersion))
                    {
                        // Check if 64-bit OS
                        bool is64 = Environment.Is64BitOperatingSystem;
                        string platform = is64 ? "win64" : "win32";
                        downloadUrl = $"https://storage.googleapis.com/chrome-for-testing-public/{driverVersion}/{platform}/chromedriver-{platform}.zip";

                        // Verify url exists
                        try
                        {
                            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(downloadUrl);
                            req.Method = "HEAD";
                            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                            {
                                if (res.StatusCode != HttpStatusCode.OK && platform == "win64")
                                {
                                    downloadUrl = $"https://storage.googleapis.com/chrome-for-testing-public/{driverVersion}/win32/chromedriver-win32.zip";
                                }
                            }
                        }
                        catch
                        {
                            downloadUrl = $"https://storage.googleapis.com/chrome-for-testing-public/{driverVersion}/win32/chromedriver-win32.zip";
                        }
                    }
                }
                else
                {
                    // Legacy Chrome (< 115)
                    try
                    {
                        driverVersion = wc.DownloadString($"https://chromedriver.storage.googleapis.com/LATEST_RELEASE_{major}").Trim();
                        downloadUrl = $"https://chromedriver.storage.googleapis.com/{driverVersion}/chromedriver_win32.zip";
                    }
                    catch
                    {
                        downloadUrl = $"https://chromedriver.storage.googleapis.com/LATEST_RELEASE";
                        driverVersion = wc.DownloadString(downloadUrl).Trim();
                        downloadUrl = $"https://chromedriver.storage.googleapis.com/{driverVersion}/chromedriver_win32.zip";
                    }
                }
            }

            if (string.IsNullOrEmpty(downloadUrl))
            {
                return (false, "Không tìm thấy link tải ChromeDriver cho Chrome v" + chromeVersion);
            }

            // Kill running chromedriver processes
            try
            {
                foreach (var p in Process.GetProcessesByName("chromedriver"))
                {
                    try { p.Kill(); } catch { }
                }
            }
            catch { }

            string tempDir = Path.Combine(Path.GetTempPath(), "LushCare_Driver_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);
            string zipPath = Path.Combine(tempDir, "chromedriver.zip");

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
                client.DownloadFile(downloadUrl, zipPath);
            }

            if (!File.Exists(zipPath) || new FileInfo(zipPath).Length == 0)
            {
                return (false, "Tải file ChromeDriver zip thất bại!");
            }

            string extractDir = Path.Combine(tempDir, "extracted");
            ZipFile.ExtractToDirectory(zipPath, extractDir);

            string[] foundDrivers = Directory.GetFiles(extractDir, "chromedriver.exe", SearchOption.AllDirectories);
            if (foundDrivers.Length == 0)
            {
                return (false, "Không tìm thấy file chromedriver.exe trong gói giải nén!");
            }

            string sourceDriver = foundDrivers[0];

            // Use IsolatedDriverManager for version-isolated, conflict-free atomic staging update
            try
            {
                IsolatedDriverManager.SafeUpdateDriver(chromeVersion, sourceDriver);
            }
            catch { }

            string destDriver = Path.Combine(targetDir, "chromedriver.exe");
            if (File.Exists(destDriver))
            {
                try { File.Delete(destDriver); } catch { }
            }
            try { File.Copy(sourceDriver, destDriver, true); } catch { }
            try { Commom.PatchChromeDriverCdc(destDriver); } catch { }

            // Also copy to bin/Debug/net48 and bin/Release/net48 if in project directory
            try
            {
                string debugPath = Path.Combine(targetDir, @"bin\Debug\net48\chromedriver.exe");
                if (Directory.Exists(Path.GetDirectoryName(debugPath)))
                {
                    File.Copy(sourceDriver, debugPath, true);
                }

                string releasePath = Path.Combine(targetDir, @"bin\Release\net48\chromedriver.exe");
                if (Directory.Exists(Path.GetDirectoryName(releasePath)))
                {
                    File.Copy(sourceDriver, releasePath, true);
                }
            }
            catch { }

            // Cleanup temp
            try { Directory.Delete(tempDir, true); } catch { }

            return (true, $"Cập nhật ChromeDriver v{driverVersion} (khớp Chrome v{chromeVersion}) thành công!");
        }
        catch (Exception ex)
        {
            return (false, "Lỗi cập nhật ChromeDriver: " + ex.Message);
        }
    }
}
