using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LushCare.Browser
{
    /// <summary>
    /// Windows Job Object wrapper providing kernel-level process containment.
    /// Configured with JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE so that when the JobObject handle
    /// is closed (session teardown, timeout, or unexpected host termination/crash),
    /// the entire Chrome + ChromeDriver + Renderers + GPU process tree is terminated by the kernel.
    /// </summary>
    public class JobObject : IDisposable
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetInformationJobObject(IntPtr hJob, int JobObjectInfoClass, IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool TerminateJobObject(IntPtr hJob, uint uExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const int JobObjectExtendedLimitInformation = 9;
        private const uint JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x2000;
        private const uint PROCESS_TERMINATE = 0x0001;
        private const uint PROCESS_SET_QUOTA = 0x0100;

        [StructLayout(LayoutKind.Sequential)]
        private struct IO_COUNTERS
        {
            public ulong ReadOperationCount;
            public ulong WriteOperationCount;
            public ulong OtherOperationCount;
            public ulong ReadTransferCount;
            public ulong WriteTransferCount;
            public ulong OtherTransferCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct JOBOBJECT_BASIC_LIMIT_INFORMATION
        {
            public long PerProcessUserTimeLimit;
            public long PerJobUserTimeLimit;
            public uint LimitFlags;
            public UIntPtr MinimumWorkingSetSize;
            public UIntPtr MaximumWorkingSetSize;
            public uint ActiveProcessLimit;
            public UIntPtr Affinity;
            public uint PriorityClass;
            public uint SchedulingClass;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        {
            public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
            public IO_COUNTERS IoInfo;
            public UIntPtr ProcessMemoryLimit;
            public UIntPtr JobMemoryLimit;
            public UIntPtr PeakProcessMemoryLimit;
            public UIntPtr PeakJobMemoryLimit;
        }

        private IntPtr _handle;
        private bool _disposed;
        private static readonly object _staticLock = new object();
        private static JobObject _defaultJob;

        public static JobObject Default
        {
            get
            {
                if (_defaultJob == null)
                {
                    lock (_staticLock)
                    {
                        if (_defaultJob == null)
                        {
                            _defaultJob = new JobObject();
                        }
                    }
                }
                return _defaultJob;
            }
        }

        public static void Initialize()
        {
            var _ = Default;
        }

        public static bool AssignProcessToJob(Process process)
        {
            return Default.AssignProcess(process);
        }

        public static bool AssignProcessToJob(int processId)
        {
            return Default.AssignProcess(processId);
        }

        public static bool AssignProcessToJob(IntPtr hProcess)
        {
            if (Default._handle == IntPtr.Zero || hProcess == IntPtr.Zero) return false;
            try
            {
                return AssignProcessToJobObject(Default._handle, hProcess);
            }
            catch
            {
                return false;
            }
        }

        public IntPtr Handle => _handle;
        public bool IsValid => _handle != IntPtr.Zero;

        public JobObject(string name = null)
        {
            _handle = CreateJobObject(IntPtr.Zero, name);
            if (_handle == IntPtr.Zero)
            {
                return;
            }

            var info = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION();
            info.BasicLimitInformation.LimitFlags = JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE;

            int length = Marshal.SizeOf(typeof(JOBOBJECT_EXTENDED_LIMIT_INFORMATION));
            IntPtr extendedInfoPtr = Marshal.AllocHGlobal(length);
            try
            {
                Marshal.StructureToPtr(info, extendedInfoPtr, false);
                SetInformationJobObject(_handle, JobObjectExtendedLimitInformation, extendedInfoPtr, (uint)length);
            }
            finally
            {
                Marshal.FreeHGlobal(extendedInfoPtr);
            }
        }

        public bool AssignProcess(Process process)
        {
            if (_handle == IntPtr.Zero || process == null) return false;
            try
            {
                if (process.HasExited) return false;
                return AssignProcessToJobObject(_handle, process.Handle);
            }
            catch
            {
                return false;
            }
        }

        public bool AssignProcess(int processId)
        {
            if (_handle == IntPtr.Zero || processId <= 0) return false;
            try
            {
                using (var p = Process.GetProcessById(processId))
                {
                    if (AssignProcess(p)) return true;
                }
            }
            catch { }

            // Direct Win32 handle fallback with required job permissions
            try
            {
                IntPtr hProcess = OpenProcess(PROCESS_SET_QUOTA | PROCESS_TERMINATE, false, processId);
                if (hProcess != IntPtr.Zero)
                {
                    try
                    {
                        return AssignProcessToJobObject(_handle, hProcess);
                    }
                    finally
                    {
                        CloseHandle(hProcess);
                    }
                }
            }
            catch { }

            return false;
        }

        public void TerminateProcesses(uint exitCode = 0)
        {
            if (_handle != IntPtr.Zero)
            {
                try
                {
                    TerminateJobObject(_handle, exitCode);
                }
                catch { }
            }
        }

        /// <summary>
        /// Chờ có giới hạn (bounded wait) cho một tiến trình thoát tự nhiên.
        /// </summary>
        public static bool WaitForProcessExitBounded(Process process, int timeoutMs = 2000)
        {
            if (process == null) return true;
            try
            {
                if (process.HasExited) return true;
                return process.WaitForExit(timeoutMs);
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// Xác minh tiến trình có còn sống và thực sự thuộc về phiên làm việc này hay không.
        /// Chống hiện tượng PID recycling (hệ điều hành cấp lại PID của tiến trình đã chết cho tiến trình khác).
        /// HasExited riêng lẻ chưa đủ để xác minh quyền sở hữu.
        /// </summary>
        public static bool IsSessionProcessStillAliveAndOwned(Process process, int recordedPid, DateTime? recordedStartTime, string expectedNameKeyword = null)
        {
            int targetPid = (process != null) ? process.Id : recordedPid;
            if (targetPid <= 0) return false;

            try
            {
                if (process != null)
                {
                    try
                    {
                        if (process.HasExited) return false;
                    }
                    catch
                    {
                        return false;
                    }
                }

                Process current = Process.GetProcessById(targetPid);
                if (current == null) return false;

                try
                {
                    if (current.HasExited) return false;
                }
                catch
                {
                    return false;
                }

                // 1. Xác minh tên tiến trình khớp mong đợi (chống diệt nhầm process khác loại)
                if (!string.IsNullOrEmpty(expectedNameKeyword))
                {
                    string actualName = current.ProcessName.ToLowerInvariant();
                    if (!actualName.Contains(expectedNameKeyword.ToLowerInvariant()))
                    {
                        return false;
                    }
                }

                // 2. Xác minh thời điểm khởi tạo (StartTime) để bảo đảm đúng phiên, chống PID recycling
                if (recordedStartTime.HasValue)
                {
                    try
                    {
                        if (Math.Abs((current.StartTime - recordedStartTime.Value).TotalSeconds) > 1.0)
                        {
                            return false; // PID đã bị tiến trình khác ngoài phiên chiếm giữ
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (ArgumentException)
            {
                // Tiến trình không tồn tại (đã thoát)
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (_handle != IntPtr.Zero)
                {
                    try
                    {
                        TerminateJobObject(_handle, 0);
                    }
                    catch { }
                    CloseHandle(_handle);
                    _handle = IntPtr.Zero;
                }
            }
        }

        ~JobObject()
        {
            Dispose(false);
        }
    }
}