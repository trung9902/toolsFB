using System;
using System.Management;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LushCare.Benchmark
{
    /// <summary>
    /// Thông tin tiến trình được theo dõi với định danh PID và thời điểm khởi tạo StartTime,
    /// bảo đảm xác minh quyền sở hữu trước khi cưỡng chế dừng (tránh PID recycling của Windows).
    /// </summary>
    public class TrackedProcessInfo
    {
        public int Pid { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public bool OwnershipVerified { get; set; }
        public bool IsAliveAt5sGrace { get; set; }
        public bool WasForcedKilled { get; set; }

        public override string ToString()
        {
            return string.Format("{0} (PID:{1}, Started:{2:HH:mm:ss.fff}, Verified:{3})", ProcessName, Pid, StartTime, OwnershipVerified);
        }
    }

    /// <summary>
    /// Bản ghi đo lường chi tiết cho từng phiên làm việc (Session).
    /// </summary>
    public class SessionBenchmarkRecord
    {
        public string SessionId { get; set; }
        public int BatchSize { get; set; } // 10, 20, 30
        public string WindowMode { get; set; } // Visible, TrueMinimized
        public int RunIteration { get; set; } // 1, 2, 3

        // Mốc khởi tạo phiên
        public DateTime CreateStartTime { get; set; }
        public DateTime? CreateEndTime { get; set; }
        public double CreateDurationMs { get; set; }
        public bool CreateTimeoutAt30s { get; set; }
        public double CreateCleanupDurationMs { get; set; } // Thời gian dọn tài nguyên khi lỗi/timeout
        public string CreateStatus { get; set; } // Success, Timeout, Error

        // Mốc điều hướng trang tải fixture (1.5MB HTML + 10x50KB images = 2.0MB)
        public DateTime? NavStartTime { get; set; }
        public DateTime? NavEndTime { get; set; }
        public double NavDurationMs { get; set; }
        public bool NavSuccess { get; set; }

        // Mốc yêu cầu đóng và thoát tiến trình
        public DateTime? CloseRequestedTime { get; set; }
        public DateTime? CloseCompletedTime { get; set; }
        public double CloseDurationMs { get; set; }
        public string ExitType { get; set; } // NaturalExit, ForcedExit, Timeout
        public int AliveProcessesAt5sGrace { get; set; }
        public int ForcedKilledCount { get; set; }
        public int VerifiedOwnershipCount { get; set; }

        private readonly ConcurrentDictionary<int, TrackedProcessInfo> _trackedProcesses = new ConcurrentDictionary<int, TrackedProcessInfo>();
        public ConcurrentDictionary<int, TrackedProcessInfo> TrackedProcesses
        {
            get { return _trackedProcesses; }
        }
    }

    /// <summary>
    /// Điểm mẫu tài nguyên định kỳ mỗi 500 ms.
    /// </summary>
    public struct TelemetrySample
    {
        public DateTime Timestamp;
        public double ElapsedSeconds;
        public double CollectorCpuPercent;
        public float MachineCpuPercent;
        public double BatchPrivateBytesMB;
        public double SystemCommitBytesMB;
        public float DiskQueueLength;
        public int ActiveTrackedProcessesCount;
    }

    /// <summary>
    /// Bộ giám sát đo lường hiệu năng Baseline độc lập cho toolsFB.
    /// </summary>
    public class SessionBenchmarkTelemetry : IDisposable
    {
        private static readonly Lazy<SessionBenchmarkTelemetry> _instance = new Lazy<SessionBenchmarkTelemetry>(() => new SessionBenchmarkTelemetry());
        public static SessionBenchmarkTelemetry Instance
        {
            get { return _instance.Value; }
        }

        private readonly ConcurrentDictionary<string, SessionBenchmarkRecord> _sessions = new ConcurrentDictionary<string, SessionBenchmarkRecord>();
        private readonly List<TelemetrySample> _samples = new List<TelemetrySample>();
        private readonly object _sampleLock = new object();

        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _diskCounter;
        private PerformanceCounter _commitCounter;

        private Thread _samplerThread;
        private volatile bool _isSampling;
        private Stopwatch _benchmarkStopwatch;
        private Process _currentProcess;
        private TimeSpan _lastCollectorCpuTime;
        private DateTime _lastCollectorSampleTime;

        public SessionBenchmarkTelemetry()
        {
            InitPerformanceCounters();
        }

        private void InitPerformanceCounters()
        {
            try
            {
                _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                _cpuCounter.NextValue(); // Khởi động sample đầu
            }
            catch { }

            try
            {
                _diskCounter = new PerformanceCounter("PhysicalDisk", "Current Disk Queue Length", "_Total");
                _diskCounter.NextValue();
            }
            catch { }

            try
            {
                _commitCounter = new PerformanceCounter("Memory", "Committed Bytes");
                _commitCounter.NextValue();
            }
            catch { }
        }

        public void StartSampling()
        {
            if (_isSampling) return;

            _isSampling = true;
            _benchmarkStopwatch = Stopwatch.StartNew();
            _currentProcess = Process.GetCurrentProcess();
            _lastCollectorCpuTime = _currentProcess.TotalProcessorTime;
            _lastCollectorSampleTime = DateTime.UtcNow;

            _samplerThread = new Thread(SamplingLoop)
            {
                IsBackground = true,
                Name = "BenchmarkTelemetryCollector",
                Priority = ThreadPriority.Normal
            };
            _samplerThread.Start();
        }

        private void SamplingLoop()
        {
            const int intervalMs = 500;

            while (_isSampling)
            {
                try
                {
                    DateTime now = DateTime.UtcNow;
                    double elapsedSec = _benchmarkStopwatch.Elapsed.TotalSeconds;

                    // 1. Đo chi phí CPU của chính Collector
                    TimeSpan currentCpuTime = _currentProcess.TotalProcessorTime;
                    double timeDeltaMs = (now - _lastCollectorSampleTime).TotalMilliseconds;
                    double collectorCpuPercent = 0.0;
                    if (timeDeltaMs > 10.0)
                    {
                        double cpuDeltaMs = (currentCpuTime - _lastCollectorCpuTime).TotalMilliseconds;
                        collectorCpuPercent = Math.Round((cpuDeltaMs / (timeDeltaMs * Environment.ProcessorCount)) * 100.0, 3);
                    }
                    _lastCollectorCpuTime = currentCpuTime;
                    _lastCollectorSampleTime = now;

                    // 2. CPU đỉnh toàn hệ thống tại chu kỳ 500ms
                    float machineCpu = 0f;
                    try { machineCpu = _cpuCounter != null ? _cpuCounter.NextValue() : 0f; } catch { }

                    // 3. Disk Queue Length tại chu kỳ 500ms
                    float diskQueue = 0f;
                    try { diskQueue = _diskCounter != null ? _diskCounter.NextValue() : 0f; } catch { }

                    // 4. Commit Memory toàn hệ thống (tách riêng khỏi Private Bytes)
                    double systemCommitMb = 0.0;
                    try
                    {
                        if (_commitCounter != null)
                        {
                            systemCommitMb = Math.Round(_commitCounter.NextValue() / (1024.0 * 1024.0), 2);
                        }
                    }
                    catch { }

                    // 5. Tổng Private Bytes của các tiến trình thuộc đợt thử
                    long totalPrivateBytes = 0;
                    int activeProcCount = 0;

                    foreach (var session in _sessions.Values)
                    {
                        foreach (var kvp in session.TrackedProcesses)
                        {
                            var pInfo = kvp.Value;
                            try
                            {
                                using (var p = Process.GetProcessById(pInfo.Pid))
                                {
                                    // Xác minh process còn đúng start time và chưa thoát
                                    if (!p.HasExited && p.StartTime == pInfo.StartTime)
                                    {
                                        totalPrivateBytes += p.PrivateMemorySize64;
                                        activeProcCount++;
                                    }
                                }
                            }
                            catch
                            {
                                // Tiến trình đã thoát
                            }
                        }
                    }

                    double batchPrivateMb = Math.Round(totalPrivateBytes / (1024.0 * 1024.0), 2);

                    var sample = new TelemetrySample
                    {
                        Timestamp = now,
                        ElapsedSeconds = Math.Round(elapsedSec, 2),
                        CollectorCpuPercent = collectorCpuPercent,
                        MachineCpuPercent = (float)Math.Round(machineCpu, 2),
                        BatchPrivateBytesMB = batchPrivateMb,
                        SystemCommitBytesMB = systemCommitMb,
                        DiskQueueLength = (float)Math.Round(diskQueue, 2),
                        ActiveTrackedProcessesCount = activeProcCount
                    };

                    lock (_sampleLock)
                    {
                        _samples.Add(sample);
                    }
                }
                catch (Exception)
                {
                    // Ignore sample collection failures
                }

                Thread.Sleep(intervalMs);
            }
        }

        public void StopSampling()
        {
            _isSampling = false;
            if (_samplerThread != null && _samplerThread.IsAlive)
            {
                _samplerThread.Join(1500);
            }
        }

        #region Quản lý Phiên & Snapshot Cây Tiến Trình

        public SessionBenchmarkRecord RegisterSession(string sessionId, int batchSize, string windowMode, int iteration)
        {
            var record = new SessionBenchmarkRecord
            {
                SessionId = sessionId,
                BatchSize = batchSize,
                WindowMode = windowMode,
                RunIteration = iteration,
                CreateStartTime = DateTime.UtcNow
            };
            _sessions[sessionId] = record;
            return record;
        }

        /// <summary>
        /// Chụp và lưu danh sách tiến trình con khi phiên còn chạy để tiếp tục theo dõi sau khi ChromeDriver thoát.
        /// Ghi nhận cả PID và StartTime để bảo đảm quyền sở hữu.
        /// </summary>
        public void SnapshotProcessTree(string sessionId, int driverPid)
        {
            if (!_sessions.TryGetValue(sessionId, out var session)) return;

            // Lưu driver
            try
            {
                using (var driverProc = Process.GetProcessById(driverPid))
                {
                    session.TrackedProcesses.TryAdd(driverPid, new TrackedProcessInfo
                    {
                        Pid = driverPid,
                        ProcessName = driverProc.ProcessName,
                        StartTime = driverProc.StartTime,
                        OwnershipVerified = true
                    });
                }
            }
            catch { }

            // Quét tìm tất cả child processes của driverPid và chrome processes
            try
            {
                List<int> childPids = GetChildProcessIdsWin32(driverPid);
                foreach (int cPid in childPids)
                {
                    try
                    {
                        using (var childProc = Process.GetProcessById(cPid))
                        {
                            session.TrackedProcesses.TryAdd(cPid, new TrackedProcessInfo
                            {
                                Pid = cPid,
                                ProcessName = childProc.ProcessName,
                                StartTime = childProc.StartTime,
                                OwnershipVerified = true
                            });
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        public void MarkCreateCompleted(string sessionId, bool success, string error = null)
        {
            if (!_sessions.TryGetValue(sessionId, out var session)) return;
            session.CreateEndTime = DateTime.UtcNow;
            session.CreateDurationMs = Math.Round((session.CreateEndTime.Value - session.CreateStartTime).TotalMilliseconds, 2);
            session.CreateStatus = success ? "Success" : (session.CreateTimeoutAt30s ? "Timeout" : "Error");
        }

        public void MarkCreateTimeout(string sessionId, double cleanupDurationMs)
        {
            if (!_sessions.TryGetValue(sessionId, out var session)) return;
            session.CreateTimeoutAt30s = true;
            session.CreateCleanupDurationMs = Math.Round(cleanupDurationMs, 2);
            session.CreateStatus = "Timeout";
        }

        public void MarkNavCompleted(string sessionId, double durationMs, bool success)
        {
            if (!_sessions.TryGetValue(sessionId, out var session)) return;
            session.NavDurationMs = Math.Round(durationMs, 2);
            session.NavSuccess = success;
        }

        /// <summary>
        /// Khởi chạy giám sát độc lập khi có yêu cầu đóng phiên.
        /// Tách riêng thời điểm đo (mốc 5 giây) với thời điểm cưỡng chế dừng.
        /// Ghi riêng thoát tự nhiên (NaturalExit) và thoát sau cưỡng chế (ForcedExit).
        /// </summary>
        public Task MonitorCloseAsync(string sessionId, Action triggerQuitAction)
        {
            if (!_sessions.TryGetValue(sessionId, out var session))
            {
                triggerQuitAction?.Invoke();
                return Task.CompletedTask;
            }

            session.CloseRequestedTime = DateTime.UtcNow;
            Stopwatch closeSw = Stopwatch.StartNew();

            // Chạy triggerQuitAction trên luồng riêng để nếu Quit() bị treo thì bộ giám sát vẫn độc lập đo
            Task.Run(() =>
            {
                try { triggerQuitAction?.Invoke(); } catch { }
            });

            return Task.Run(() =>
            {
                const int gracePeriodMs = 5000;
                const int pollStepMs = 100;
                int waitedMs = 0;
                bool exitedNaturally = false;

                // Vòng lặp chờ thoát tự nhiên trong 5 giây
                while (waitedMs < gracePeriodMs)
                {
                    if (AreAllTrackedProcessesExited(session))
                    {
                        exitedNaturally = true;
                        break;
                    }
                    Thread.Sleep(pollStepMs);
                    waitedMs += pollStepMs;
                }

                session.CloseCompletedTime = DateTime.UtcNow;
                session.CloseDurationMs = Math.Round(closeSw.Elapsed.TotalMilliseconds, 2);

                if (exitedNaturally)
                {
                    session.ExitType = "NaturalExit";
                    session.AliveProcessesAt5sGrace = 0;
                    session.ForcedKilledCount = 0;
                }
                else
                {
                    // Quá 5 giây vẫn còn tiến trình sống -> Ghi nhận ForcedExit và cưỡng chế dừng có xác minh
                    session.ExitType = "ForcedExit";
                    var aliveProcesses = GetAliveTrackedProcesses(session);
                    session.AliveProcessesAt5sGrace = aliveProcesses.Count;

                    int killedCount = 0;
                    int verifiedCount = 0;

                    foreach (var pInfo in aliveProcesses)
                    {
                        if (KillVerifiedProcess(pInfo))
                        {
                            killedCount++;
                            if (pInfo.OwnershipVerified) verifiedCount++;
                        }
                    }

                    session.ForcedKilledCount = killedCount;
                    session.VerifiedOwnershipCount = verifiedCount;
                }
            });
        }

        private bool AreAllTrackedProcessesExited(SessionBenchmarkRecord session)
        {
            foreach (var pInfo in session.TrackedProcesses.Values)
            {
                try
                {
                    using (var p = Process.GetProcessById(pInfo.Pid))
                    {
                        if (!p.HasExited && p.StartTime == pInfo.StartTime)
                        {
                            return false;
                        }
                    }
                }
                catch
                {
                    // Process has exited
                }
            }
            return true;
        }

        private List<TrackedProcessInfo> GetAliveTrackedProcesses(SessionBenchmarkRecord session)
        {
            var list = new List<TrackedProcessInfo>();
            foreach (var pInfo in session.TrackedProcesses.Values)
            {
                try
                {
                    using (var p = Process.GetProcessById(pInfo.Pid))
                    {
                        if (!p.HasExited && p.StartTime == pInfo.StartTime)
                        {
                            pInfo.IsAliveAt5sGrace = true;
                            list.Add(pInfo);
                        }
                    }
                }
                catch { }
            }
            return list;
        }

        /// <summary>
        /// Cưỡng chế dừng tiến trình với xác minh quyền sở hữu: kiểm tra cả PID và StartTime.
        /// </summary>
        private bool KillVerifiedProcess(TrackedProcessInfo pInfo)
        {
            try
            {
                using (var p = Process.GetProcessById(pInfo.Pid))
                {
                    // Kiểm tra xác thực quyền sở hữu: trùng PID và đúng StartTime
                    if (!p.HasExited && p.StartTime == pInfo.StartTime)
                    {
                        pInfo.OwnershipVerified = true;
                        p.Kill();
                        pInfo.WasForcedKilled = true;
                        return true;
                    }
                }
            }
            catch
            {
                // Tiến trình đã thoát hoặc không có quyền
            }
            return false;
        }

        private static List<int> GetChildProcessIdsWin32(int parentPid)
        {
            var results = new List<int>();
            try
            {
                string query = $"Select ProcessId From Win32_Process Where ParentProcessId = {parentPid}";
                using (var searcher = new ManagementObjectSearcher(query))
                using (var moc = searcher.Get())
                {
                    foreach (ManagementObject mo in moc)
                    {
                        int childPid = Convert.ToInt32(mo["ProcessId"]);
                        results.Add(childPid);
                        // Đệ quy lấy con của con
                        results.AddRange(GetChildProcessIdsWin32(childPid));
                    }
                }
            }
            catch { }
            return results;
        }

        #endregion

        #region Xuất Dữ Liệu CSV

        public void ExportSamplesCsv(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Timestamp,ElapsedSeconds,CollectorCpuPercent,MachineCpuPercent,BatchPrivateBytesMB,SystemCommitBytesMB,DiskQueueLength,ActiveTrackedProcessesCount");

            lock (_sampleLock)
            {
                foreach (var s in _samples)
                {
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                        "{0:O},{1},{2},{3},{4},{5},{6},{7}",
                        s.Timestamp, s.ElapsedSeconds, s.CollectorCpuPercent, s.MachineCpuPercent,
                        s.BatchPrivateBytesMB, s.SystemCommitBytesMB, s.DiskQueueLength, s.ActiveTrackedProcessesCount));
                }
            }

            string dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        public void ExportSessionsCsv(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SessionId,BatchSize,WindowMode,RunIteration,CreateStatus,CreateDurationMs,CreateTimeoutAt30s,CreateCleanupDurationMs,NavSuccess,NavDurationMs,CloseDurationMs,ExitType,AliveProcessesAt5sGrace,ForcedKilledCount,VerifiedOwnershipCount");

            foreach (var s in _sessions.Values)
            {
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                    "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                    s.SessionId, s.BatchSize, s.WindowMode, s.RunIteration, s.CreateStatus,
                    s.CreateDurationMs, s.CreateTimeoutAt30s, s.CreateCleanupDurationMs,
                    s.NavSuccess, s.NavDurationMs, s.CloseDurationMs, s.ExitType,
                    s.AliveProcessesAt5sGrace, s.ForcedKilledCount, s.VerifiedOwnershipCount));
            }

            string dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        #endregion

        public void Dispose()
        {
            StopSampling();
            try { _cpuCounter?.Dispose(); } catch { }
            try { _diskCounter?.Dispose(); } catch { }
            try { _commitCounter?.Dispose(); } catch { }
        }
    }
}