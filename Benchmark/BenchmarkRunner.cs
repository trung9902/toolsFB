using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LushCare.Benchmark
{
    public class BenchmarkConfig
    {
        public string ConfigName { get; set; } = "Baseline";
        public bool DisableGpu { get; set; } = false;
        public int RendererProcessLimit { get; set; } = 0;
        public bool DisableImages { get; set; } = false;
        public bool DisableExtensions { get; set; } = false;
        public bool CleanCache { get; set; } = false;
        public int ViewportWidth { get; set; } = 1024;
        public int ViewportHeight { get; set; } = 768;
        public int SemaphoreLimit { get; set; } = 0;
    }

    public class RunSummaryStats
    {
        public int RunNumber { get; set; }
        public string Stage { get; set; } = "Stage2_Baseline";
        public string ConfigTag { get; set; } = "Default";
        public int BatchSize { get; set; }
        public string WindowMode { get; set; }
        public int Iteration { get; set; }
        public int SemaphoreLimit { get; set; }

        public double TotalRunDurationMs { get; set; }
        public double BatchCreateDurationMs { get; set; }

        public double CreateP50 { get; set; }
        public double CreateP90 { get; set; }
        public double CreateP95 { get; set; }
        public double CreateMax { get; set; }

        public double NavP50 { get; set; }
        public double NavP90 { get; set; }
        public double NavP95 { get; set; }
        public double NavMax { get; set; }

        public double TeardownP50 { get; set; }
        public double TeardownP90 { get; set; }
        public double TeardownP95 { get; set; }
        public double TeardownMax { get; set; }

        public int NaturalExitCount { get; set; }
        public int ForcedExitCount { get; set; }
        public int AliveAt5sCount { get; set; }
        public int TimeoutCount { get; set; }
        public int ErrorCount { get; set; }

        public double ErrorRateCreate { get; set; }
        public double ErrorRateNav { get; set; }

        public float PeakMachineCpu { get; set; }
        public double PeakBatchPrivateMb { get; set; }
        public double PeakSystemCommitMb { get; set; }
        public float PeakDiskQueue { get; set; }
        public double AvgCollectorCpu { get; set; }
        public double PeakCollectorCpu { get; set; }
    }

    /// <summary>
    /// Bộ điều phối thực thi đo kiểm hiệu năng LushCare:
    /// Giai đoạn 2: Baseline Windows (10, 20, 30 phiên x Visible/TrueMinimized x 3 lượt).
    /// Giai đoạn 4: Điều phối tải SemaphoreSlim(2) đo đối chứng với Baseline.
    /// Giai đoạn 5: Thử nghiệm A/B kiểm thử các cấu hình tối ưu Chrome.
    /// </summary>
    public class BenchmarkRunner
    {
        public static void Run(string[] args)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("                 LUSHCARE PERFORMANCE BENCHMARK RUNNER                          ");
            Console.WriteLine("================================================================================");
            Console.WriteLine(string.Format("Thời gian khởi chạy: {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));

            int stage = 2;
            if (args != null)
            {
                var stageArg = args.FirstOrDefault(a => a.StartsWith("--stage=", StringComparison.OrdinalIgnoreCase));
                if (stageArg != null)
                {
                    int.TryParse(stageArg.Substring(8), out stage);
                }
                else if (args.Any(a => a.Equals("--throttle", StringComparison.OrdinalIgnoreCase) || a.Equals("--stage4", StringComparison.OrdinalIgnoreCase)))
                {
                    stage = 4;
                }
                else if (args.Any(a => a.Equals("--ab", StringComparison.OrdinalIgnoreCase) || a.Equals("--stage5", StringComparison.OrdinalIgnoreCase)))
                {
                    stage = 5;
                }
            }

            switch (stage)
            {
                case 4:
                    RunStage4Throttling(args);
                    break;
                case 5:
                    RunStage5ABTesting(args);
                    break;
                case 2:
                default:
                    RunBaselineMatrix(args);
                    break;
            }
        }

        public static void RunBaselineMatrix(string[] args)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("    GIAI ĐOẠN 2: MA TRẬN 18 LƯỢT ĐO BASELINE WINDOWS (SEMAPHORE TẮT)            ");
            Console.WriteLine("================================================================================");

            int[] batchSizes = new[] { 10, 20, 30 };
            string[] windowModes = new[] { "Visible", "TrueMinimized" };
            int iterations = 3;

            if (args != null)
            {
                if (args.Any(a => a.Equals("--quick", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("[CHẾ ĐỘ NHANH] Kiểm tra nhanh: 1 lượt với nấc 2 phiên.");
                    batchSizes = new[] { 2 };
                    windowModes = new[] { "Visible" };
                    iterations = 1;
                }
                else if (args.Any(a => a.StartsWith("--batch=", StringComparison.OrdinalIgnoreCase)))
                {
                    string bVal = args.First(a => a.StartsWith("--batch=", StringComparison.OrdinalIgnoreCase)).Substring(8);
                    if (int.TryParse(bVal, out int b)) batchSizes = new[] { b };
                }
            }

            string baseOutputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BenchmarkResults", string.Format("baseline_{0:yyyyMMdd_HHmmss}", DateTime.Now));
            if (!Directory.Exists(baseOutputDir)) Directory.CreateDirectory(baseOutputDir);

            EnsureEnvironmentReady();

            var server = BenchmarkServer.Instance;
            server.Start();
            Console.WriteLine(string.Format("[BenchmarkServer] Đang phục vụ fixture 2.0MB tại: {0}", server.FixtureUrl));

            var allRunSummaries = new List<RunSummaryStats>();
            int totalRuns = batchSizes.Length * windowModes.Length * iterations;
            int currentRunIndex = 0;

            var defaultConfig = new BenchmarkConfig { ConfigName = "Baseline", SemaphoreLimit = 0 };

            try
            {
                foreach (int batchSize in batchSizes)
                {
                    foreach (string windowMode in windowModes)
                    {
                        for (int iter = 1; iter <= iterations; iter++)
                        {
                            currentRunIndex++;
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            Console.WriteLine(string.Format("[GIAI ĐOẠN 2 - LƯỢT {0}/{1}] Nấc: {2} phiên | Cửa sổ: {3} | Lần lặp: {4}/{5}", currentRunIndex, totalRuns, batchSize, windowMode, iter, iterations));
                            Console.WriteLine("--------------------------------------------------------------------------------");

                            var summary = ExecuteSingleRun(currentRunIndex, "Stage2_Baseline", defaultConfig, batchSize, windowMode, iter, server.FixtureUrl, baseOutputDir);
                            allRunSummaries.Add(summary);

                            Thread.Sleep(5000);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    }
                }

                ExportMasterSummary(allRunSummaries, Path.Combine(baseOutputDir, "benchmark_baseline_matrix_18runs.csv"));
            }
            finally
            {
                server.Stop();
                Console.WriteLine("[BenchmarkServer] Đã dừng máy chủ.");
            }

            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine(string.Format("HOÀN TẤT MA TRẬN {0} LƯỢT ĐO BASELINE GIAI ĐOẠN 2! Dữ liệu tại: {1}", totalRuns, baseOutputDir));
            Console.WriteLine("================================================================================");
        }

        public static void RunStage4Throttling(string[] args)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("    GIAI ĐOẠN 4: ĐIỀU PHỐI TẢI KHỞI TẠO VỚI SEMAPHORESLIM(2) VS BASELINE       ");
            Console.WriteLine("================================================================================");

            int[] batchSizes = new[] { 10, 20, 30 };
            int iterations = 2;
            if (args != null)
            {
                if (args.Any(a => a.Equals("--quick", StringComparison.OrdinalIgnoreCase)))
                {
                    batchSizes = new[] { 4 };
                    iterations = 1;
                }
                else if (args.Any(a => a.StartsWith("--batch=", StringComparison.OrdinalIgnoreCase)))
                {
                    string bVal = args.First(a => a.StartsWith("--batch=", StringComparison.OrdinalIgnoreCase)).Substring(8);
                    if (int.TryParse(bVal, out int b)) batchSizes = new[] { b };
                }
            }

            string baseOutputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BenchmarkResults", string.Format("stage4_throttling_{0:yyyyMMdd_HHmmss}", DateTime.Now));
            if (!Directory.Exists(baseOutputDir)) Directory.CreateDirectory(baseOutputDir);

            EnsureEnvironmentReady();

            var server = BenchmarkServer.Instance;
            server.Start();
            Console.WriteLine(string.Format("[BenchmarkServer] Đang phục vụ fixture 2.0MB tại: {0}", server.FixtureUrl));

            var allSummaries = new List<RunSummaryStats>();
            int runIndex = 0;

            var configBaseline = new BenchmarkConfig { ConfigName = "Baseline_Unthrottled", SemaphoreLimit = 0 };
            var configThrottled = new BenchmarkConfig { ConfigName = "Throttled_Semaphore2", SemaphoreLimit = 2 };
            var configs = new[] { configBaseline, configThrottled };

            try
            {
                foreach (int batchSize in batchSizes)
                {
                    foreach (var cfg in configs)
                    {
                        for (int iter = 1; iter <= iterations; iter++)
                        {
                            runIndex++;
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            Console.WriteLine(string.Format("[GIAI ĐOẠN 4 - LƯỢT {0}] Cấu hình: {1} (Semaphore={2}) | Nấc: {3} phiên | Lặp: {4}/{5}", runIndex, cfg.ConfigName, cfg.SemaphoreLimit, batchSize, iter, iterations));
                            Console.WriteLine("--------------------------------------------------------------------------------");

                            var summary = ExecuteSingleRun(runIndex, "Stage4_Throttling", cfg, batchSize, "Visible", iter, server.FixtureUrl, baseOutputDir);
                            allSummaries.Add(summary);

                            Thread.Sleep(5000);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    }
                }

                ExportMasterSummary(allSummaries, Path.Combine(baseOutputDir, "benchmark_stage4_throttling_comparison.csv"));
            }
            finally
            {
                server.Stop();
                Console.WriteLine("[BenchmarkServer] Đã dừng máy chủ.");
            }

            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine(string.Format("HOÀN TẤT THỬ NGHIỆM ĐIỀU PHỐI TẢI GIAI ĐOẠN 4! Dữ liệu tại: {0}", baseOutputDir));
            Console.WriteLine("================================================================================");
        }

        public static void RunStage5ABTesting(string[] args)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("    GIAI ĐOẠN 5: A/B TESTING CẤU HÌNH TỐI ƯU HÓA CHROME                        ");
            Console.WriteLine("================================================================================");

            int batchSize = 10;
            int iterations = 2;

            if (args != null)
            {
                if (args.Any(a => a.Equals("--quick", StringComparison.OrdinalIgnoreCase)))
                {
                    batchSize = 2;
                    iterations = 1;
                }
                else if (args.Any(a => a.StartsWith("--batch=", StringComparison.OrdinalIgnoreCase)))
                {
                    string bVal = args.First(a => a.StartsWith("--batch=", StringComparison.OrdinalIgnoreCase)).Substring(8);
                    if (int.TryParse(bVal, out int b)) batchSize = b;
                }
            }

            bool customDisableGpu = args != null && args.Any(a => a.Equals("--disable-gpu", StringComparison.OrdinalIgnoreCase));
            bool customDisableImages = args != null && args.Any(a => a.Equals("--disable-images", StringComparison.OrdinalIgnoreCase));
            bool customDisableExt = args != null && args.Any(a => a.Equals("--disable-ext", StringComparison.OrdinalIgnoreCase));
            bool customCleanCache = args != null && args.Any(a => a.Equals("--clean-cache", StringComparison.OrdinalIgnoreCase));
            int customRendererLimit = 0;
            if (args != null && args.Any(a => a.StartsWith("--renderer-limit=", StringComparison.OrdinalIgnoreCase)))
            {
                string rVal = args.First(a => a.StartsWith("--renderer-limit=", StringComparison.OrdinalIgnoreCase)).Substring(17);
                int.TryParse(rVal, out customRendererLimit);
            }

            string baseOutputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BenchmarkResults", string.Format("stage5_ab_testing_{0:yyyyMMdd_HHmmss}", DateTime.Now));
            if (!Directory.Exists(baseOutputDir)) Directory.CreateDirectory(baseOutputDir);

            EnsureEnvironmentReady();

            var server = BenchmarkServer.Instance;
            server.Start();
            Console.WriteLine(string.Format("[BenchmarkServer] Đang phục vụ fixture 2.0MB tại: {0}", server.FixtureUrl));

            var allSummaries = new List<RunSummaryStats>();
            int runIndex = 0;

            var configA = new BenchmarkConfig
            {
                ConfigName = "Config_A_Default",
                DisableGpu = false,
                RendererProcessLimit = 0,
                DisableImages = false,
                DisableExtensions = false,
                CleanCache = false,
                SemaphoreLimit = 0
            };

            var configB = new BenchmarkConfig
            {
                ConfigName = "Config_B_Optimized",
                DisableGpu = customDisableGpu || true,
                RendererProcessLimit = (customRendererLimit > 0) ? customRendererLimit : 2,
                DisableImages = customDisableImages || true,
                DisableExtensions = customDisableExt || true,
                CleanCache = customCleanCache || true,
                SemaphoreLimit = 2
            };

            var testConfigs = new[] { configA, configB };

            try
            {
                foreach (var cfg in testConfigs)
                {
                    for (int iter = 1; iter <= iterations; iter++)
                    {
                        runIndex++;
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        Console.WriteLine(string.Format("[GIAI ĐOẠN 5 - LƯỢT {0}] {1} | GPU:{2} | RendererLimit:{3} | Images:{4} | CacheClean:{5} | Nấc: {6} phiên | Lặp: {7}/{8}",
                            runIndex, cfg.ConfigName, (cfg.DisableGpu ? "OFF" : "ON"), cfg.RendererProcessLimit, (cfg.DisableImages ? "OFF" : "ON"), (cfg.CleanCache ? "YES" : "NO"), batchSize, iter, iterations));
                        Console.WriteLine("--------------------------------------------------------------------------------");

                        var summary = ExecuteSingleRun(runIndex, "Stage5_ABTesting", cfg, batchSize, "Visible", iter, server.FixtureUrl, baseOutputDir);
                        allSummaries.Add(summary);

                        Thread.Sleep(5000);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }

                ExportMasterSummary(allSummaries, Path.Combine(baseOutputDir, "benchmark_stage5_ab_comparison.csv"));
            }
            finally
            {
                server.Stop();
                Console.WriteLine("[BenchmarkServer] Đã dừng máy chủ.");
            }

            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine(string.Format("HOÀN TẤT THỬ NGHIỆM A/B TESTING GIAI ĐOẠN 5! Dữ liệu tại: {0}", baseOutputDir));
            Console.WriteLine("================================================================================");
        }

        private static void EnsureEnvironmentReady()
        {
            string targetDir = Commom.smethod_95();
            string driverPath = Path.Combine(targetDir, "chromedriver.exe");
            if (!File.Exists(driverPath))
            {
                Console.WriteLine("[BenchmarkRunner] Đang kiểm tra và cập nhật chromedriver.exe tương thích...");
                ChromeDriverUpdater.EnsureMatchingChromeDriver(targetDir);
            }
        }

        private static RunSummaryStats ExecuteSingleRun(int runIndex, string stageName, BenchmarkConfig config, int batchSize, string windowMode, int iter, string fixtureUrl, string baseOutputDir)
        {
            string runTag = string.Format("{0}_{1}_{2}_r{3}", config.ConfigName, batchSize, windowMode, iter);
            string tempProfilesDir = Path.Combine(Path.GetTempPath(), "LushCare_Bench", runTag);
            if (!Directory.Exists(tempProfilesDir)) Directory.CreateDirectory(tempProfilesDir);

            var telemetry = new SessionBenchmarkTelemetry();
            telemetry.StartSampling();

            var chromeInstances = new ConcurrentBag<Chrome>();
            var sessionRecords = new ConcurrentBag<SessionBenchmarkRecord>();

            Console.WriteLine(string.Format("[{0}] Khởi tạo {1} phiên Chrome (Semaphore: {2})...", runTag, batchSize, (config.SemaphoreLimit > 0 ? config.SemaphoreLimit.ToString() : "TẮT")));
            Stopwatch batchSw = Stopwatch.StartNew();

            SemaphoreSlim initSemaphore = (config.SemaphoreLimit > 0) ? new SemaphoreSlim(config.SemaphoreLimit, config.SemaphoreLimit) : null;

            // Pha 1: Khởi tạo phiên đồng loạt hoặc điều phối qua SemaphoreSlim
            Parallel.For(0, batchSize, new ParallelOptions { MaxDegreeOfParallelism = batchSize }, i =>
            {
                string sessionId = string.Format("{0}_s{1:D2}", runTag, i + 1);
                string profilePath = Path.Combine(tempProfilesDir, string.Format("profile_{0}", i + 1));
                var record = telemetry.RegisterSession(sessionId, batchSize, windowMode, iter);
                sessionRecords.Add(record);

                var chrome = new Chrome
                {
                    BenchmarkSessionId = sessionId,
                    UserDataDir = profilePath,
                    BenchmarkDisableGpu = config.DisableGpu,
                    BenchmarkRendererProcessLimit = config.RendererProcessLimit,
                    BenchmarkDisableImages = config.DisableImages,
                    BenchmarkDisableExtensions = config.DisableExtensions,
                    BenchmarkClearCacheOnStart = config.CleanCache
                };
                chromeInstances.Add(chrome);

                if (initSemaphore != null) initSemaphore.Wait();
                try
                {
                    bool opened = chrome.Open();
                    if (opened)
                    {
                        if (windowMode == "TrueMinimized")
                        {
                            chrome.MinimizeWindow();
                        }
                        else
                        {
                            chrome.SetWindowVisible(config.ViewportWidth, config.ViewportHeight);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[{0}] Lỗi mở: {1}", sessionId, ex.Message));
                }
                finally
                {
                    if (initSemaphore != null) initSemaphore.Release();
                }
            });

            double batchCreateMs = batchSw.Elapsed.TotalMilliseconds;
            Console.WriteLine(string.Format("[{0}] Hoàn tất mở {1} phiên trong {2:F1}ms.", runTag, batchSize, batchCreateMs));

            // Pha 2: Điều hướng trang fixture 2.0MB và đo T_nav
            Console.WriteLine(string.Format("[{0}] Đang điều hướng {1} phiên tới fixture 2.0MB...", runTag, batchSize));
            Parallel.ForEach(chromeInstances, chrome =>
            {
                if (chrome.ChromeDriver_0 == null) return;
                string sId = chrome.BenchmarkSessionId;

                Stopwatch navSw = Stopwatch.StartNew();
                bool navOk = false;
                try
                {
                    chrome.GotoURL(fixtureUrl);

                    // Chờ DOM complete và phần tử #benchmark-ready (tối đa 30s)
                    for (int step = 0; step < 60; step++)
                    {
                        try
                        {
                            object readyState = chrome.ExecuteScript("return document.readyState === 'complete' && document.querySelector('#benchmark-ready[data-status=\"ready\"]') !== null;");
                            if (readyState != null && (readyState is bool && (bool)readyState || readyState.ToString().ToLower() == "true"))
                            {
                                navOk = true;
                                break;
                            }
                        }
                        catch { }
                        Thread.Sleep(500);
                    }
                }
                catch { }

                navSw.Stop();
                telemetry.MarkNavCompleted(sId, navSw.Elapsed.TotalMilliseconds, navOk);
            });

            // Pha 3: Giữ trạng thái hoạt động trong 5 giây để lấy đủ 10 mẫu 500ms tài nguyên ổn định
            Console.WriteLine(string.Format("[{0}] Thu thập telemetry trạng thái tải trong 5 giây...", runTag));
            Thread.Sleep(5000);

            // Pha 4: Đóng phiên và đo T_teardown qua MonitorCloseAsync
            Console.WriteLine(string.Format("[{0}] Đang yêu cầu đóng {1} phiên (kiểm tra 5s grace period & xác minh PID/StartTime)...", runTag, batchSize));
            var closeTasks = chromeInstances.Select(chrome =>
            {
                string sId = chrome.BenchmarkSessionId;
                return telemetry.MonitorCloseAsync(sId, () =>
                {
                    try
                    {
                        chrome.Close();
                    }
                    catch { }
                });
            }).ToArray();

            Task.WaitAll(closeTasks);
            batchSw.Stop();

            telemetry.StopSampling();

            string samplesPath = Path.Combine(baseOutputDir, string.Format("samples_{0}.csv", runTag));
            string sessionsPath = Path.Combine(baseOutputDir, string.Format("sessions_{0}.csv", runTag));
            telemetry.ExportSamplesCsv(samplesPath);
            telemetry.ExportSessionsCsv(sessionsPath);

            try
            {
                if (Directory.Exists(tempProfilesDir))
                {
                    Directory.Delete(tempProfilesDir, true);
                }
            }
            catch { }

            var summary = ComputeRunSummary(runIndex, stageName, config, batchSize, windowMode, iter, batchSw.Elapsed.TotalMilliseconds, batchCreateMs, sessionRecords.ToList(), samplesPath);
            telemetry.Dispose();

            Console.WriteLine(string.Format("[{0}] Kết quả: T_create p95={1:F1}ms, T_nav p95={2:F1}ms, T_teardown p95={3:F1}ms | Thoát tự nhiên: {4}/{5}, Sống sau 5s: {6}",
                runTag, summary.CreateP95, summary.NavP95, summary.TeardownP95, summary.NaturalExitCount, batchSize, summary.AliveAt5sCount));
            return summary;
        }

        private static RunSummaryStats ComputeRunSummary(int runIndex, string stageName, BenchmarkConfig config, int batchSize, string windowMode, int iter, double totalDurationMs, double batchCreateMs, List<SessionBenchmarkRecord> sessions, string samplesCsvPath)
        {
            var createTimes = sessions.Where(s => s.CreateDurationMs > 0).Select(s => s.CreateDurationMs).OrderBy(v => v).ToList();
            var navTimes = sessions.Where(s => s.NavDurationMs > 0).Select(s => s.NavDurationMs).OrderBy(v => v).ToList();
            var teardownTimes = sessions.Where(s => s.CloseDurationMs > 0).Select(s => s.CloseDurationMs).OrderBy(v => v).ToList();

            int createErrors = sessions.Count(s => s.CreateStatus == "Error" || s.CreateTimeoutAt30s);
            int navErrors = sessions.Count(s => !s.NavSuccess);

            var summary = new RunSummaryStats
            {
                RunNumber = runIndex,
                Stage = stageName,
                ConfigTag = config.ConfigName,
                BatchSize = batchSize,
                WindowMode = windowMode,
                Iteration = iter,
                SemaphoreLimit = config.SemaphoreLimit,
                TotalRunDurationMs = Math.Round(totalDurationMs, 2),
                BatchCreateDurationMs = Math.Round(batchCreateMs, 2),

                CreateP50 = GetPercentile(createTimes, 0.50),
                CreateP90 = GetPercentile(createTimes, 0.90),
                CreateP95 = GetPercentile(createTimes, 0.95),
                CreateMax = createTimes.Count > 0 ? createTimes.Last() : 0,

                NavP50 = GetPercentile(navTimes, 0.50),
                NavP90 = GetPercentile(navTimes, 0.90),
                NavP95 = GetPercentile(navTimes, 0.95),
                NavMax = navTimes.Count > 0 ? navTimes.Last() : 0,

                TeardownP50 = GetPercentile(teardownTimes, 0.50),
                TeardownP90 = GetPercentile(teardownTimes, 0.90),
                TeardownP95 = GetPercentile(teardownTimes, 0.95),
                TeardownMax = teardownTimes.Count > 0 ? teardownTimes.Last() : 0,

                NaturalExitCount = sessions.Count(s => s.ExitType == "NaturalExit"),
                ForcedExitCount = sessions.Count(s => s.ExitType == "ForcedExit"),
                AliveAt5sCount = sessions.Sum(s => s.AliveProcessesAt5sGrace),
                TimeoutCount = sessions.Count(s => s.CreateTimeoutAt30s),
                ErrorCount = sessions.Count(s => s.CreateStatus == "Error"),

                ErrorRateCreate = batchSize > 0 ? Math.Round((double)createErrors / batchSize, 4) : 0,
                ErrorRateNav = batchSize > 0 ? Math.Round((double)navErrors / batchSize, 4) : 0
            };

            try
            {
                if (File.Exists(samplesCsvPath))
                {
                    var lines = File.ReadAllLines(samplesCsvPath).Skip(1);
                    var machCpus = new List<float>();
                    var batchPrivates = new List<double>();
                    var sysCommits = new List<double>();
                    var diskQueues = new List<float>();
                    var collectorCpus = new List<double>();

                    foreach (string line in lines)
                    {
                        var p = line.Split(',');
                        if (p.Length >= 8)
                        {
                            double colCpu;
                            float machCpu;
                            double privMb;
                            double sysMb;
                            float dq;
                            if (double.TryParse(p[2], NumberStyles.Any, CultureInfo.InvariantCulture, out colCpu)) collectorCpus.Add(colCpu);
                            if (float.TryParse(p[3], NumberStyles.Any, CultureInfo.InvariantCulture, out machCpu)) machCpus.Add(machCpu);
                            if (double.TryParse(p[4], NumberStyles.Any, CultureInfo.InvariantCulture, out privMb)) batchPrivates.Add(privMb);
                            if (double.TryParse(p[5], NumberStyles.Any, CultureInfo.InvariantCulture, out sysMb)) sysCommits.Add(sysMb);
                            if (float.TryParse(p[6], NumberStyles.Any, CultureInfo.InvariantCulture, out dq)) diskQueues.Add(dq);
                        }
                    }

                    if (machCpus.Count > 0) summary.PeakMachineCpu = machCpus.Max();
                    if (batchPrivates.Count > 0) summary.PeakBatchPrivateMb = batchPrivates.Max();
                    if (sysCommits.Count > 0) summary.PeakSystemCommitMb = sysCommits.Max();
                    if (diskQueues.Count > 0) summary.PeakDiskQueue = diskQueues.Max();
                    if (collectorCpus.Count > 0)
                    {
                        summary.AvgCollectorCpu = Math.Round(collectorCpus.Average(), 3);
                        summary.PeakCollectorCpu = Math.Round(collectorCpus.Max(), 3);
                    }
                }
            }
            catch { }

            return summary;
        }

        private static double GetPercentile(List<double> sortedValues, double percentile)
        {
            if (sortedValues == null || sortedValues.Count == 0) return 0;
            int n = sortedValues.Count;
            if (n == 1) return sortedValues[0];
            double rank = percentile * (n - 1);
            int low = (int)Math.Floor(rank);
            int high = (int)Math.Ceiling(rank);
            if (low == high) return sortedValues[low];
            double weight = rank - low;
            return Math.Round(sortedValues[low] * (1.0 - weight) + sortedValues[high] * weight, 2);
        }

        private static void ExportMasterSummary(List<RunSummaryStats> summaries, string masterCsvPath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("RunNumber,Stage,ConfigTag,BatchSize,WindowMode,Iteration,SemaphoreLimit,TotalRunDurationMs,BatchCreateDurationMs,Create_p50_ms,Create_p90_ms,Create_p95_ms,Create_max_ms,Nav_p50_ms,Nav_p90_ms,Nav_p95_ms,Nav_max_ms,Teardown_p50_ms,Teardown_p90_ms,Teardown_p95_ms,Teardown_max_ms,NaturalExitCount,ForcedExitCount,AliveAt5sGraceCount,TimeoutCount,ErrorCount,ErrorRateCreate,ErrorRateNav,PeakMachineCpuPercent,PeakBatchPrivateMB,PeakSystemCommitMB,PeakDiskQueueLength,AvgCollectorCpuPercent,PeakCollectorCpuPercent");

            foreach (var s in summaries)
            {
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                    "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33}",
                    s.RunNumber, s.Stage, s.ConfigTag, s.BatchSize, s.WindowMode, s.Iteration, s.SemaphoreLimit,
                    s.TotalRunDurationMs, s.BatchCreateDurationMs,
                    s.CreateP50, s.CreateP90, s.CreateP95, s.CreateMax,
                    s.NavP50, s.NavP90, s.NavP95, s.NavMax,
                    s.TeardownP50, s.TeardownP90, s.TeardownP95, s.TeardownMax,
                    s.NaturalExitCount, s.ForcedExitCount, s.AliveAt5sCount,
                    s.TimeoutCount, s.ErrorCount,
                    s.ErrorRateCreate, s.ErrorRateNav,
                    s.PeakMachineCpu, s.PeakBatchPrivateMb, s.PeakSystemCommitMb,
                    s.PeakDiskQueue, s.AvgCollectorCpu, s.PeakCollectorCpu));
            }

            File.WriteAllText(masterCsvPath, sb.ToString(), Encoding.UTF8);
            Console.WriteLine(string.Format("[Tổng hợp] Đã xuất file tổng kết: {0}", masterCsvPath));
        }
    }
}