using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;

namespace LushCare.Browser
{
    /// <summary>
    /// Isolated, version-aware ChromeDriver manager.
    /// Prevents file-locking conflicts when driver updates occur while worker processes are running.
    /// Each major version resides in its own isolated folder, and worker instances run from isolated paths.
    /// </summary>
    public static class IsolatedDriverManager
    {
        private static readonly string BaseDriverDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers");
        private static readonly ConcurrentDictionary<string, object> VersionLocks = new ConcurrentDictionary<string, object>();

        static IsolatedDriverManager()
        {
            try
            {
                if (!Directory.Exists(BaseDriverDir))
                {
                    Directory.CreateDirectory(BaseDriverDir);
                }
            }
            catch { }
        }

        /// <summary>
        /// Gets or creates the isolated directory for a specific Chrome version.
        /// </summary>
        public static string GetIsolatedDriverDirectory(string chromeVersion)
        {
            string version = string.IsNullOrEmpty(chromeVersion) ? "default" : chromeVersion;
            string versionDir = Path.Combine(BaseDriverDir, version);
            if (!Directory.Exists(versionDir))
            {
                Directory.CreateDirectory(versionDir);
            }
            return versionDir;
        }

        /// <summary>
        /// Resolves the dedicated isolated executable path for a specific Chrome version.
        /// </summary>
        public static string GetVersionedDriverPath(string chromeVersion)
        {
            string dir = GetIsolatedDriverDirectory(chromeVersion);
            return Path.Combine(dir, "chromedriver.exe");
        }

        /// <summary>
        /// Resolves the dedicated isolated executable path for a specific Chrome version.
        /// </summary>
        public static string GetDriverExecutablePath(string chromeVersion)
        {
            if (!string.IsNullOrEmpty(chromeVersion))
            {
                string directPath = GetVersionedDriverPath(chromeVersion);
                if (File.Exists(directPath))
                {
                    return directPath;
                }
            }
            string major = GetMajorVersion(chromeVersion);
            string versionDir = Path.Combine(BaseDriverDir, $"v{major}");
            string driverPath = Path.Combine(versionDir, "chromedriver.exe");

            if (File.Exists(driverPath))
            {
                return driverPath;
            }

            // Fallback checks
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
            if (File.Exists(defaultPath))
            {
                return defaultPath;
            }

            string pkgDriver = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"packages/Selenium.WebDriver.ChromeDriver.{chromeVersion}/driver/win32/chromedriver.exe");
            if (File.Exists(pkgDriver))
            {
                return pkgDriver;
            }

            return "chromedriver.exe";
        }

        /// <summary>
        /// Atomically stages a new driver update for a version without locking or interrupting
        /// workers currently running that or another version.
        /// </summary>
        public static bool SafeUpdateDriver(string targetVersion, string sourceDriverExePath)
        {
            if (string.IsNullOrEmpty(sourceDriverExePath) || !File.Exists(sourceDriverExePath))
                return false;

            string versionDir = GetIsolatedDriverDirectory(targetVersion);
            string major = GetMajorVersion(targetVersion);
            object vLock = VersionLocks.GetOrAdd(major, _ => new object());

            lock (vLock)
            {
                try
                {
                    if (!Directory.Exists(versionDir))
                    {
                        Directory.CreateDirectory(versionDir);
                    }

                    string targetExe = Path.Combine(versionDir, "chromedriver.exe");
                    string tempStaging = Path.Combine(versionDir, $"chromedriver_{Guid.NewGuid():N}.tmp");

                    File.Copy(sourceDriverExePath, tempStaging, overwrite: true);

                    try
                    {
                        Commom.PatchChromeDriverCdc(tempStaging);
                    }
                    catch { }

                    // Atomic swap or replace
                    if (File.Exists(targetExe))
                    {
                        try
                        {
                            string oldBackup = Path.Combine(versionDir, $"chromedriver_old_{DateTime.UtcNow.Ticks}.bak");
                            File.Move(targetExe, oldBackup);
                            File.Move(tempStaging, targetExe);
                            try { File.Delete(oldBackup); } catch { }
                        }
                        catch (IOException)
                        {
                            try
                            {
                                File.Delete(targetExe);
                                File.Move(tempStaging, targetExe);
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        File.Move(tempStaging, targetExe);
                    }

                    // Try to clean up stale backup files if not locked
                    try
                    {
                        foreach (var bakFile in Directory.GetFiles(versionDir, "*.bak"))
                        {
                            try { File.Delete(bakFile); } catch { }
                        }
                    }
                    catch { }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool HasDriverForVersion(string chromeVersion)
        {
            string major = GetMajorVersion(chromeVersion);
            string versionDir = Path.Combine(BaseDriverDir, $"v{major}");
            return File.Exists(Path.Combine(versionDir, "chromedriver.exe"));
        }

        public static string GetMajorVersion(string version)
        {
            if (string.IsNullOrEmpty(version)) return "default";
            string[] parts = version.Split('.');
            return parts.Length > 0 ? parts[0] : "default";
        }
    }
}