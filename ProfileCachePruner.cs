using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Module tự động dọn dẹp cache Chrome profile an toàn, tối ưu dung lượng ổ cứng.
/// Đảm bảo KHÔNG XÓA Cookie, Session, LocalStorage, Login Data, Preferences của tài khoản.
/// Xử lý ngoại lệ file đang bị khóa (file-in-use) độc lập cho từng file mà không làm gián đoạn tiến trình.
/// </summary>
public static class ProfileCachePruner
{
	#region Critical WhiteList & Rules (KHÔNG ĐƯỢC XÓA)

	/// <summary>
	/// Các phân đoạn thư mục cốt lõi tuyệt đối KHÔNG được xóa hoặc duyệt xóa con.
	/// Bất kỳ file hay thư mục nào nằm trong các thư mục này đều được bảo vệ 100%.
	/// </summary>
	private static readonly HashSet<string> CriticalDirectorySegments = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"Cookies",
		"Network",
		"Local Storage",
		"Session Storage",
		"Sessions",
		"IndexedDB",
		"Sync Data",
		"Accounts",
		"Extensions",
		"Extension State",
		"Extension Rules",
		"Extension Scripts"
	};

	/// <summary>
	/// Danh sách tên file nhạy cảm chứa phiên đăng nhập, cookie, mật khẩu, cấu hình trình duyệt.
	/// </summary>
	private static readonly HashSet<string> CriticalFileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		// Cookie & Network
		"Cookies",
		"Cookies-journal",
		"Cookies-wal",
		"Cookies-shm",
		"Network Persistent State",
		"TransportSecurity",
		"Trust Tokens",
		"Trust Tokens-journal",

		// Mật khẩu & Đăng nhập
		"Login Data",
		"Login Data-journal",
		"Login Data-wal",
		"Login Data-shm",
		"Login Data For Account",
		"Login Data For Account-journal",

		// Cấu hình Chrome & Tài khoản
		"Preferences",
		"Secure Preferences",
		"Web Data",
		"Web Data-journal",
		"Web Data-wal",
		"Web Data-shm",
		"Local State",
		"First Run",

		// Lịch sử & Dấu trang (cần giữ để tránh checkpoint do profile trắng)
		"History",
		"History-journal",
		"History Provider Cache",
		"Bookmarks",
		"Bookmarks.bak",
		"Favicons",
		"Favicons-journal"
	};

	#endregion

	#region Safe-To-Prune Targets (DANH MỤC RÁC AN TOÀN ĐƯỢC PHÉP XÓA)

	/// <summary>
	/// Các thư mục cache rác đã được xác minh an toàn để xóa bên trong một Chrome Profile.
	/// </summary>
	private static readonly string[] SafePrunableDirectories = new string[]
	{
		// Cache web & bytecode V8 (chiếm 70-90% dung lượng profile)
		@"Default\Cache",
		@"Default\Code Cache",
		@"Default\GPUCache",
		@"Default\DawnCache",
		@"Default\DawnGraphiteCache",
		@"Default\DawnWebGPUCache",

		// Service Worker Cache
		@"Default\Service Worker\CacheStorage",
		@"Default\Service Worker\ScriptCache",
		@"Default\Service Worker",

		// Crashpad & Crash Dumps
		@"Default\Crashpad",
		@"Crashpad",

		// AI & Optimization Models (chiếm hàng chục đến hàng trăm MB)
		@"Default\AutofillAiModelCache",
		@"Default\optimization_guide_hint_cache_store",
		@"Default\BudgetDatabase",
		@"Default\blob_storage",
		@"OptimizationGuidePredictionModels",
		@"optimization_guide_prediction_model_downloads",
		@"optimization_guide_model_store",
		@"OptimizationGuideModelsManifest",
		@"OptimizationHints",
		@"segmentation_platform",

		// GPU Shaders & Native Client
		@"GrShaderCache",
		@"ShaderCache",
		@"GPUPersistentCache",
		@"pnacl",
		@"SwReporter",

		// Metrics, Telemetry & CRX Caches
		@"BrowserMetrics",
		@"component_crx_cache",
		@"extensions_crx_cache",
		@"SafetyTips",
		@"Crowd Deny",
		@"ActorSafetyLists",
		@"AmountExtractionHeuristicRegexes",
		@"CaptchaProviders",
		@"CertificateRevocation",
		@"FileTypePolicies",
		@"MEIPreload",
		@"OnDeviceHeadSuggestModel",
		@"OriginTrials",
		@"PKIMetadata",
		@"PrivacySandboxAttestationsPreloaded",
		@"RecoveryImproved",
		@"SSLErrorAssistant",
		@"Subresource Filter",
		@"TrustTokenKeyCommitments",
		@"WasmTtsEngine",
		@"WidevineCdm",
		@"ZxcvbnData"
	};

	/// <summary>
	/// Các định dạng file tạm, log, crash dump được xóa an toàn ở thư mục gốc profile và Default root.
	/// </summary>
	private static readonly string[] SafePrunableFileExtensions = new string[]
	{
		".dmp",
		".tmp",
		".old",
		".pma"
	};

	/// <summary>
	/// Các tên file log cụ thể được phép xóa.
	/// </summary>
	private static readonly HashSet<string> SafePrunableExactFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"chrome_debug.log",
		"CrashpadMetrics-active.pma",
		"LOG",
		"LOG.old"
	};

	#endregion

	#region Data Models

	/// <summary>
	/// Kết quả dọn dẹp một profile cụ thể.
	/// Hỗ trợ ép kiểu ngầm định sang double (trả về số MB đã giải phóng).
	/// </summary>
	public class PruneResult
	{
		public bool Success { get; set; }
		public string ProfilePath { get; set; }
		public string ProfileName => Path.GetFileName(ProfilePath?.TrimEnd('\\', '/'));
		public double InitialSizeMb { get; set; }
		public double FinalSizeMb { get; set; }
		public double FreedMb => Math.Max(0.0, Math.Round(InitialSizeMb - FinalSizeMb, 2));
		public long BytesFreed { get; set; }
		public int FilesDeleted { get; set; }
		public int DirectoriesDeleted { get; set; }
		public int LockedFilesSkipped { get; set; }
		public string ErrorMessage { get; set; }

		public static implicit operator double(PruneResult result)
		{
			return result != null ? result.FreedMb : 0.0;
		}

		public override string ToString()
		{
			return string.Format("Profile: {0} | Ban đầu: {1:F2} MB | Sau dọn: {2:F2} MB | Giải phóng: {3:F2} MB (Đã xóa {4} file, Bỏ qua {5} file khóa)",
				ProfileName, InitialSizeMb, FinalSizeMb, FreedMb, FilesDeleted, LockedFilesSkipped);
		}
	}

	/// <summary>
	/// Kết quả dọn dẹp hàng loạt tất cả profile.
	/// Hỗ trợ ép kiểu ngầm định sang double (trả về tổng số MB đã giải phóng).
	/// </summary>
	public class BatchPruneResult
	{
		public bool Success { get; set; }
		public string ProfilesRoot { get; set; }
		public int TotalProfiles { get; set; }
		public int ProcessedProfiles { get; set; }
		public double TotalInitialSizeMb { get; set; }
		public double TotalFinalSizeMb { get; set; }
		public double TotalFreedMb => Math.Max(0.0, Math.Round(TotalInitialSizeMb - TotalFinalSizeMb, 2));
		public long TotalBytesFreed { get; set; }
		public int TotalFilesDeleted { get; set; }
		public int TotalDirectoriesDeleted { get; set; }
		public int TotalLockedFilesSkipped { get; set; }
		public TimeSpan ElapsedTime { get; set; }
		public List<PruneResult> Details { get; set; } = new List<PruneResult>();

		public static implicit operator double(BatchPruneResult result)
		{
			return result != null ? result.TotalFreedMb : 0.0;
		}

		public override string ToString()
		{
			return string.Format("Tổng cộng: {0} profile | Giải phóng: {1:F2} MB ({2:F2} GB) | File đã xóa: {3} | File khóa: {4} | Thời gian: {5:mm\\:ss}",
				ProcessedProfiles, TotalFreedMb, TotalFreedMb / 1024.0, TotalFilesDeleted, TotalLockedFilesSkipped, ElapsedTime);
		}
	}

	#endregion

	#region 1. Scan Profile Size

	/// <summary>
	/// Quét và tính tổng dung lượng của thư mục Chrome profile.
	/// </summary>
	/// <param name="profileDir">Đường dẫn đầy đủ tới thư mục profile Chrome (ví dụ: bin\Debug\net48\profiles\1000123...)</param>
	/// <returns>Tổng dung lượng tính bằng Megabytes (MB), làm tròn 2 chữ số thập phân.</returns>
	public static double ScanProfileSize(string profileDir)
	{
		if (string.IsNullOrWhiteSpace(profileDir) || !Directory.Exists(profileDir))
		{
			return 0.0;
		}

		long totalBytes = ScanProfileSizeBytes(profileDir);
		return Math.Round((double)totalBytes / (1024.0 * 1024.0), 2);
	}

	/// <summary>
	/// Quét và tính tổng dung lượng theo bytes của thư mục Chrome profile.
	/// Xử lý ngoại lệ phân quyền / file khóa một cách an toàn.
	/// </summary>
	/// <param name="profileDir">Đường dẫn thư mục profile.</param>
	/// <returns>Tổng số bytes của profile.</returns>
	public static long ScanProfileSizeBytes(string profileDir)
	{
		if (string.IsNullOrWhiteSpace(profileDir) || !Directory.Exists(profileDir))
		{
			return 0L;
		}

		return CalculateDirectorySizeBytesSafe(profileDir);
	}

	/// <summary>
	/// Quét riêng dung lượng các thư mục rác / cache có thể giải phóng trong profile.
	/// Giúp dự báo dung lượng sẽ tiết kiệm được trước khi thực hiện dọn dẹp.
	/// </summary>
	/// <param name="profileDir">Đường dẫn profile.</param>
	/// <returns>Dung lượng cache rác tính bằng MB.</returns>
	public static double ScanPrunableCacheSize(string profileDir)
	{
		if (string.IsNullOrWhiteSpace(profileDir) || !Directory.Exists(profileDir))
		{
			return 0.0;
		}

		long prunableBytes = 0L;

		// 1. Quét các thư mục rác đã định danh
		foreach (string relDir in SafePrunableDirectories)
		{
			string targetDir = Path.Combine(profileDir, relDir);
			if (Directory.Exists(targetDir) && !IsCriticalPath(targetDir, profileDir))
			{
				prunableBytes += CalculateDirectorySizeBytesSafe(targetDir);
			}
		}

		// 2. Quét các file log / dump ở thư mục gốc
		try
		{
			foreach (string file in Directory.GetFiles(profileDir))
			{
				if (IsPrunableFile(file, profileDir))
				{
					try
					{
						prunableBytes += new FileInfo(file).Length;
					}
					catch { }
				}
			}

			// Quét file log ở thư mục Default
			string defaultDir = Path.Combine(profileDir, "Default");
			if (Directory.Exists(defaultDir))
			{
				foreach (string file in Directory.GetFiles(defaultDir))
				{
					if (IsPrunableFile(file, profileDir))
					{
						try
						{
							prunableBytes += new FileInfo(file).Length;
						}
						catch { }
					}
				}
			}
		}
		catch { }

		return Math.Round((double)prunableBytes / (1024.0 * 1024.0), 2);
	}

	#endregion

	#region 2. Safe Prune Profile

	/// <summary>
	/// Dọn dẹp cache rác của một Chrome profile một cách an toàn tuyệt đối.
	/// KHÔNG XÓA Cookie, Session, LocalStorage, Login Data, Preferences.
	/// Xử lý try-catch từng file bị lock (file-in-use do Chrome/Background process đang mở).
	/// </summary>
	/// <param name="profileDir">Đường dẫn tới thư mục profile cần dọn dẹp.</param>
	/// <returns>Đối tượng PruneResult (tự động convert sang double MB nếu gán vào biến double).</returns>
	public static PruneResult SafePruneProfile(string profileDir)
	{
		PruneResult result = new PruneResult
		{
			ProfilePath = profileDir,
			Success = false
		};

		if (string.IsNullOrWhiteSpace(profileDir) || !Directory.Exists(profileDir))
		{
			result.ErrorMessage = "Thư mục profile không tồn tại hoặc đường dẫn trống: " + profileDir;
			return result;
		}

		try
		{
			// Đo dung lượng trước khi dọn
			result.InitialSizeMb = ScanProfileSize(profileDir);

			long bytesFreed = 0L;
			int filesDeleted = 0;
			int dirsDeleted = 0;
			int lockedSkipped = 0;

			// A. Dọn dẹp các thư mục cache rác đã định danh
			foreach (string relDir in SafePrunableDirectories)
			{
				string fullTargetDir = Path.Combine(profileDir, relDir);
				if (!Directory.Exists(fullTargetDir))
				{
					continue;
				}

				// Vòng bảo vệ tối cao: Không bao giờ xóa đường dẫn nhạy cảm
				if (IsCriticalPath(fullTargetDir, profileDir))
				{
					continue;
				}

				DeleteDirectorySafe(fullTargetDir, profileDir, ref bytesFreed, ref filesDeleted, ref dirsDeleted, ref lockedSkipped);
			}

			// B. Dọn dẹp các file rác, log, dump ở thư mục gốc profile
			PruneFilesFromFolder(profileDir, profileDir, ref bytesFreed, ref filesDeleted, ref lockedSkipped);

			// C. Dọn dẹp các file rác, log ở thư mục Default
			string defaultFolder = Path.Combine(profileDir, "Default");
			if (Directory.Exists(defaultFolder))
			{
				PruneFilesFromFolder(defaultFolder, profileDir, ref bytesFreed, ref filesDeleted, ref lockedSkipped);
			}

			// Đo dung lượng sau khi dọn
			result.FinalSizeMb = ScanProfileSize(profileDir);
			result.BytesFreed = bytesFreed;
			result.FilesDeleted = filesDeleted;
			result.DirectoriesDeleted = dirsDeleted;
			result.LockedFilesSkipped = lockedSkipped;
			result.Success = true;
		}
		catch (Exception ex)
		{
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}

		return result;
	}

	#endregion

	#region 3. Prune All Profiles

	/// <summary>
	/// Quét và dọn dẹp cache an toàn cho tất cả Chrome profile trong thư mục gốc.
	/// </summary>
	/// <param name="profilesRoot">
	/// Thư mục chứa các profile (ví dụ: bin\Debug\net48\profiles). 
	/// Nếu để null/trống, module sẽ tự động tìm kiếm đường dẫn cấu hình mặc định.
	/// </param>
	/// <param name="logger">Hàm callback nhận log tiến trình (ví dụ: msg => Console.WriteLine(msg) hoặc cập nhật UI).</param>
	/// <param name="maxDegreeOfParallelism">Số luồng thực thi song song (mặc định = 1 tuần tự để tránh nghẽn I/O đĩa cứng).</param>
	/// <returns>Đối tượng BatchPruneResult tổng hợp kết quả toàn bộ chiến dịch dọn dẹp.</returns>
	public static BatchPruneResult PruneAllProfiles(string profilesRoot = null, Action<string> logger = null, int maxDegreeOfParallelism = 1)
	{
		DateTime startTime = DateTime.Now;

		if (string.IsNullOrWhiteSpace(profilesRoot))
		{
			profilesRoot = GetDefaultProfilesDirectory();
		}

		BatchPruneResult batchResult = new BatchPruneResult
		{
			ProfilesRoot = profilesRoot,
			Success = false
		};

		if (string.IsNullOrWhiteSpace(profilesRoot) || !Directory.Exists(profilesRoot))
		{
			string error = string.Format("[ProfileCachePruner] Thư mục profiles không tồn tại: {0}", profilesRoot);
			logger?.Invoke(error);
			batchResult.ElapsedTime = DateTime.Now - startTime;
			return batchResult;
		}

		logger?.Invoke(string.Format("[ProfileCachePruner] Bắt đầu quét thư mục gốc: {0}", profilesRoot));

		// Lấy danh sách tất cả profile (mỗi thư mục con là 1 profile)
		string[] subDirectories;
		try
		{
			subDirectories = Directory.GetDirectories(profilesRoot);
		}
		catch (Exception ex)
		{
			logger?.Invoke(string.Format("[ProfileCachePruner] Lỗi truy cập thư mục gốc: {0}", ex.Message));
			batchResult.ElapsedTime = DateTime.Now - startTime;
			return batchResult;
		}

		batchResult.TotalProfiles = subDirectories.Length;
		logger?.Invoke(string.Format("[ProfileCachePruner] Phát hiện {0} profile trong danh sách.", subDirectories.Length));

		if (subDirectories.Length == 0)
		{
			batchResult.Success = true;
			batchResult.ElapsedTime = DateTime.Now - startTime;
			logger?.Invoke("[ProfileCachePruner] Không có profile nào cần dọn dẹp.");
			return batchResult;
		}

		object lockObj = new object();
		int processedCounter = 0;

		if (maxDegreeOfParallelism <= 1)
		{
			// Xử lý tuần tự - An toàn tuyệt đối cho ổ đĩa HDD/SSD khỏi nghẽn hàng đợi I/O
			for (int i = 0; i < subDirectories.Length; i++)
			{
				string pDir = subDirectories[i];
				string pName = Path.GetFileName(pDir);

				PruneResult singleResult = SafePruneProfile(pDir);

				lock (lockObj)
				{
					processedCounter++;
					batchResult.ProcessedProfiles++;
					batchResult.TotalInitialSizeMb += singleResult.InitialSizeMb;
					batchResult.TotalFinalSizeMb += singleResult.FinalSizeMb;
					batchResult.TotalBytesFreed += singleResult.BytesFreed;
					batchResult.TotalFilesDeleted += singleResult.FilesDeleted;
					batchResult.TotalDirectoriesDeleted += singleResult.DirectoriesDeleted;
					batchResult.TotalLockedFilesSkipped += singleResult.LockedFilesSkipped;
					batchResult.Details.Add(singleResult);
				}

				string logMsg = string.Format("[{0}/{1}] Profile {2}: {3:F2} MB -> {4:F2} MB (Giải phóng: {5:F2} MB, Xóa: {6} file, Khóa: {7})",
					processedCounter, subDirectories.Length, pName,
					singleResult.InitialSizeMb, singleResult.FinalSizeMb, singleResult.FreedMb,
					singleResult.FilesDeleted, singleResult.LockedFilesSkipped);

				logger?.Invoke(logMsg);
			}
		}
		else
		{
			// Xử lý song song có giới hạn luồng
			ParallelOptions parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = maxDegreeOfParallelism
			};

			Parallel.ForEach(subDirectories, parallelOptions, pDir =>
			{
				string pName = Path.GetFileName(pDir);
				PruneResult singleResult = SafePruneProfile(pDir);

				int current;
				lock (lockObj)
				{
					processedCounter++;
					current = processedCounter;
					batchResult.ProcessedProfiles++;
					batchResult.TotalInitialSizeMb += singleResult.InitialSizeMb;
					batchResult.TotalFinalSizeMb += singleResult.FinalSizeMb;
					batchResult.TotalBytesFreed += singleResult.BytesFreed;
					batchResult.TotalFilesDeleted += singleResult.FilesDeleted;
					batchResult.TotalDirectoriesDeleted += singleResult.DirectoriesDeleted;
					batchResult.TotalLockedFilesSkipped += singleResult.LockedFilesSkipped;
					batchResult.Details.Add(singleResult);
				}

				string logMsg = string.Format("[{0}/{1}] Profile {2}: {3:F2} MB -> {4:F2} MB (Giải phóng: {5:F2} MB, Xóa: {6} file, Khóa: {7})",
					current, subDirectories.Length, pName,
					singleResult.InitialSizeMb, singleResult.FinalSizeMb, singleResult.FreedMb,
					singleResult.FilesDeleted, singleResult.LockedFilesSkipped);

				logger?.Invoke(logMsg);
			});
		}

		batchResult.ElapsedTime = DateTime.Now - startTime;
		batchResult.Success = true;

		// Báo cáo tổng kết chiến dịch
		logger?.Invoke("==================================================================");
		logger?.Invoke(string.Format("[ProfileCachePruner] HOÀN TẤT DỌN DẸP CACHE ({0:mm\\:ss}):", batchResult.ElapsedTime));
		logger?.Invoke(string.Format("- Số profile đã xử lý     : {0}/{1}", batchResult.ProcessedProfiles, batchResult.TotalProfiles));
		logger?.Invoke(string.Format("- Dung lượng ban đầu      : {0:F2} MB ({1:F2} GB)", batchResult.TotalInitialSizeMb, batchResult.TotalInitialSizeMb / 1024.0));
		logger?.Invoke(string.Format("- Dung lượng sau khi dọn  : {0:F2} MB ({1:F2} GB)", batchResult.TotalFinalSizeMb, batchResult.TotalFinalSizeMb / 1024.0));
		logger?.Invoke(string.Format("- TỔNG DUNG LƯỢNG TIẾT KIỆM: {0:F2} MB ({1:F2} GB)", batchResult.TotalFreedMb, batchResult.TotalFreedMb / 1024.0));
		logger?.Invoke(string.Format("- Tổng số file rác đã xóa : {0}", batchResult.TotalFilesDeleted));
		logger?.Invoke(string.Format("- Thư mục rác đã loại bỏ  : {0}", batchResult.TotalDirectoriesDeleted));
		logger?.Invoke(string.Format("- File đang bị khóa (bỏ qua): {0}", batchResult.TotalLockedFilesSkipped));
		logger?.Invoke("==================================================================");

		return batchResult;
	}

	/// <summary>
	/// Phiên bản bất đồng bộ (Async) của PruneAllProfiles.
	/// Phù hợp gọi trực tiếp từ WinForms UI (Background Task) để không gây treo giao diện (UI Freeze).
	/// </summary>
	public static Task<BatchPruneResult> PruneAllProfilesAsync(string profilesRoot = null, Action<string> logger = null, int maxDegreeOfParallelism = 1, CancellationToken cancellationToken = default)
	{
		return Task.Run(() =>
		{
			cancellationToken.ThrowIfCancellationRequested();
			return PruneAllProfiles(profilesRoot, logger, maxDegreeOfParallelism);
		}, cancellationToken);
	}

	#endregion

	#region Safety Inspection Logic (BỘ LỌC BẢO VỆ CHỐNG XÓA NHẦM)

	/// <summary>
	/// Kiểm tra đường dẫn có thuộc danh mục tài nguyên trọng yếu không được phép xóa hay không.
	/// BẢO VỆ TUYỆT ĐỐI: Cookies, Session Storage, Local Storage, Login Data, Preferences, Web Data...
	/// </summary>
	/// <param name="fullPath">Đường dẫn đầy đủ của file hoặc thư mục đang xem xét.</param>
	/// <param name="profileDir">Đường dẫn gốc của profile.</param>
	/// <returns>True nếu là tài nguyên quan trọng (CẤM XÓA); False nếu an toàn.</returns>
	public static bool IsCriticalPath(string fullPath, string profileDir)
	{
		if (string.IsNullOrWhiteSpace(fullPath))
		{
			return true;
		}

		try
		{
			string normalizedProfileDir = Path.GetFullPath(profileDir).TrimEnd('\\', '/');
			string normalizedFullPath = Path.GetFullPath(fullPath).TrimEnd('\\', '/');

			// Nếu đường dẫn chính là thư mục gốc profile hoặc thư mục Default gốc -> CẤM XÓA CẢ THƯ MỤC!
			if (normalizedFullPath.Equals(normalizedProfileDir, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			string defaultRoot = Path.Combine(normalizedProfileDir, "Default");
			if (normalizedFullPath.Equals(defaultRoot, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			// Lấy đường dẫn tương đối từ profileDir
			string relativePath = normalizedFullPath;
			if (normalizedFullPath.StartsWith(normalizedProfileDir, StringComparison.OrdinalIgnoreCase))
			{
				relativePath = normalizedFullPath.Substring(normalizedProfileDir.Length).TrimStart('\\', '/');
			}

			// 1. Kiểm tra từng segment trong đường dẫn: Nếu nằm trong CriticalDirectorySegments -> CẤM
			string[] segments = relativePath.Split(new char[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string seg in segments)
			{
				if (CriticalDirectorySegments.Contains(seg))
				{
					return true;
				}
			}

			// 2. Kiểm tra tên file/thư mục hiện tại có nằm trong CriticalFileNames
			string entryName = Path.GetFileName(normalizedFullPath);
			if (CriticalFileNames.Contains(entryName))
			{
				return true;
			}

			// 3. Kiểm tra tiền tố của file quan trọng (ví dụ: Cookies-journal, Login Data-wal...)
			if (entryName.StartsWith("Cookies", StringComparison.OrdinalIgnoreCase) ||
				entryName.StartsWith("Login Data", StringComparison.OrdinalIgnoreCase) ||
				entryName.StartsWith("Web Data", StringComparison.OrdinalIgnoreCase) ||
				entryName.StartsWith("History", StringComparison.OrdinalIgnoreCase) ||
				entryName.StartsWith("Preferences", StringComparison.OrdinalIgnoreCase) ||
				entryName.StartsWith("Secure Preferences", StringComparison.OrdinalIgnoreCase) ||
				entryName.StartsWith("Local State", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		catch
		{
			// Trong trường hợp có bất kỳ lỗi phân tích đường dẫn nào -> Mặc định BẢO VỆ để an toàn
			return true;
		}

		return false;
	}

	/// <summary>
	/// Kiểm tra một file rời có thuộc diện file rác được phép dọn dẹp hay không.
	/// </summary>
	private static bool IsPrunableFile(string filePath, string profileDir)
	{
		if (IsCriticalPath(filePath, profileDir))
		{
			return false;
		}

		string fileName = Path.GetFileName(filePath);
		if (SafePrunableExactFiles.Contains(fileName))
		{
			return true;
		}

		string ext = Path.GetExtension(filePath);
		if (!string.IsNullOrEmpty(ext))
		{
			foreach (string safeExt in SafePrunableFileExtensions)
			{
				if (ext.Equals(safeExt, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}

		return false;
	}

	#endregion

	#region Safe Deletion Core (XỬ LÝ TRY-CATCH TỪNG FILE & BỎ QUA FILE BỊ KHÓA)

	/// <summary>
	/// Xóa thư mục rác theo phương thức đệ quy từng file độc lập.
	/// Xử lý riêng biệt từng file bị lock, gỡ thuộc tính ReadOnly nếu có.
	/// </summary>
	private static void DeleteDirectorySafe(string targetDir, string profileDir, ref long bytesFreed, ref int filesDeleted, ref int dirsDeleted, ref int lockedSkipped)
	{
		if (!Directory.Exists(targetDir))
		{
			return;
		}

		// Bảo vệ: Tuyệt đối không xóa nếu là thư mục trọng yếu
		if (IsCriticalPath(targetDir, profileDir))
		{
			return;
		}

		// 1. Duyệt và xóa từng file trong thư mục
		try
		{
			string[] files = Directory.GetFiles(targetDir);
			foreach (string file in files)
			{
				// Kiểm tra danh mục nhạy cảm trước khi xóa
				if (IsCriticalPath(file, profileDir))
				{
					continue;
				}

				try
				{
					FileInfo fi = new FileInfo(file);
					long len = 0L;
					try
					{
						len = fi.Length;
					}
					catch { }

					// Gỡ bỏ ReadOnly nếu file bị gán cờ chỉ đọc
					if (fi.Exists && fi.IsReadOnly)
					{
						fi.IsReadOnly = false;
					}

					File.Delete(file);
					bytesFreed += len;
					filesDeleted++;
				}
				catch (IOException)
				{
					// File đang được tiến trình khác sử dụng (Locked by Chrome / AV / Background worker)
					lockedSkipped++;
				}
				catch (UnauthorizedAccessException)
				{
					// Quyền truy cập bị giới hạn
					lockedSkipped++;
				}
				catch
				{
					lockedSkipped++;
				}
			}
		}
		catch
		{
			// Nếu không thể liệt kê file do quyền truy cập
		}

		// 2. Đệ quy xử lý các thư mục con
		try
		{
			string[] subDirs = Directory.GetDirectories(targetDir);
			foreach (string subDir in subDirs)
			{
				DeleteDirectorySafe(subDir, profileDir, ref bytesFreed, ref filesDeleted, ref dirsDeleted, ref lockedSkipped);
			}
		}
		catch { }

		// 3. Cố gắng xóa thư mục rỗng này (nếu còn file bị khóa bên trong, Directory.Delete sẽ throw IOException và được bỏ qua an toàn)
		try
		{
			Directory.Delete(targetDir, false);
			dirsDeleted++;
		}
		catch
		{
			// Thư mục chưa rỗng do còn file đang bị khóa -> Bỏ qua, dữ liệu rác khác đã được xóa thành công
		}
	}

	/// <summary>
	/// Quét và xóa các file rác rời rạc nằm trong một thư mục chỉ định (không đệ quy).
	/// </summary>
	private static void PruneFilesFromFolder(string folderPath, string profileDir, ref long bytesFreed, ref int filesDeleted, ref int lockedSkipped)
	{
		if (!Directory.Exists(folderPath))
		{
			return;
		}

		try
		{
			string[] files = Directory.GetFiles(folderPath);
			foreach (string file in files)
			{
				if (!IsPrunableFile(file, profileDir))
				{
					continue;
				}

				try
				{
					FileInfo fi = new FileInfo(file);
					long len = 0L;
					try
					{
						len = fi.Length;
					}
					catch { }

					if (fi.Exists && fi.IsReadOnly)
					{
						fi.IsReadOnly = false;
					}

					File.Delete(file);
					bytesFreed += len;
					filesDeleted++;
				}
				catch (IOException)
				{
					lockedSkipped++;
				}
				catch (UnauthorizedAccessException)
				{
					lockedSkipped++;
				}
				catch
				{
					lockedSkipped++;
				}
			}
		}
		catch { }
	}

	/// <summary>
	/// Tính dung lượng đĩa an toàn bằng cách đệ quy, không ném ngoại lệ khi gặp thư mục lỗi.
	/// </summary>
	private static long CalculateDirectorySizeBytesSafe(string dirPath)
	{
		if (!Directory.Exists(dirPath))
		{
			return 0L;
		}

		long size = 0L;

		try
		{
			DirectoryInfo di = new DirectoryInfo(dirPath);
			foreach (FileInfo fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
			{
				try
				{
					size += fi.Length;
				}
				catch { }
			}
			return size;
		}
		catch
		{
			// Fallback thủ công nếu EnumerateFiles toàn cục bị chặn quyền truy cập bởi thư mục con
			return CalculateDirectorySizeManual(dirPath);
		}
	}

	/// <summary>
	/// Duyệt tính dung lượng từng cấp thư mục thủ công.
	/// </summary>
	private static long CalculateDirectorySizeManual(string dirPath)
	{
		long size = 0L;
		try
		{
			foreach (string file in Directory.GetFiles(dirPath))
			{
				try
				{
					size += new FileInfo(file).Length;
				}
				catch { }
			}

			foreach (string subDir in Directory.GetDirectories(dirPath))
			{
				size += CalculateDirectorySizeManual(subDir);
			}
		}
		catch { }

		return size;
	}

	#endregion

	#region Helper Utilities

	/// <summary>
	/// Kiểm tra xem một profile Chrome có đang bị một tiến trình (như Chrome hoặc ChromeDriver) khóa file hay không.
	/// </summary>
	/// <param name="profileDir">Đường dẫn thư mục profile.</param>
	/// <returns>True nếu profile đang hoạt động hoặc bị khóa.</returns>
	public static bool IsProfileLocked(string profileDir)
	{
		if (string.IsNullOrWhiteSpace(profileDir) || !Directory.Exists(profileDir))
		{
			return false;
		}

		string lockFile = Path.Combine(profileDir, "Default", "LOCK");
		if (File.Exists(lockFile))
		{
			try
			{
				using (FileStream fs = File.Open(lockFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
				{
					// Nếu mở được với FileShare.None chứng tỏ file không bị khóa
					return false;
				}
			}
			catch (IOException)
			{
				// Không mở được -> Chrome đang chạy trên profile này
				return true;
			}
			catch
			{
				return false;
			}
		}

		// Kiểm tra thêm file DevToolsActivePort
		string devToolsPort = Path.Combine(profileDir, "DevToolsActivePort");
		if (File.Exists(devToolsPort))
		{
			try
			{
				using (FileStream fs = File.Open(devToolsPort, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
				{
					return false;
				}
			}
			catch (IOException)
			{
				return true;
			}
			catch
			{
				return false;
			}
		}

		return false;
	}

	/// <summary>
	/// Tự động dò tìm thư mục profiles của project hiện tại.
	/// Ưu tiên lấy cấu hình từ C5034B95 (nếu có), sau đó dò tìm theo cấu trúc bin\Release hoặc bin\Debug.
	/// </summary>
	public static string GetDefaultProfilesDirectory()
	{
		try
		{
			// 1. Thử gọi cấu hình C5034B95.smethod_2() qua Reflection nếu có
			Type configType = Type.GetType("C5034B95");
			if (configType != null)
			{
				MethodInfo method = configType.GetMethod("smethod_2", BindingFlags.Public | BindingFlags.Static);
				if (method != null)
				{
					object val = method.Invoke(null, null);
					if (val is string strVal && !string.IsNullOrWhiteSpace(strVal) && Directory.Exists(strVal))
					{
						return Path.GetFullPath(strVal);
					}
				}
			}
		}
		catch { }

		string baseDir = AppDomain.CurrentDomain.BaseDirectory;

		// 2. Thử thư mục "profiles" ngay cạnh file exe đang chạy
		string localProfiles = Path.Combine(baseDir, "profiles");
		if (Directory.Exists(localProfiles))
		{
			return Path.GetFullPath(localProfiles);
		}

		// 3. Thử tìm kiếm trong bin\Release\net48\profiles hoặc bin\Debug\net48\profiles
		string[] candidatePaths = new string[]
		{
			Path.Combine(baseDir, @"bin\Release\net48\profiles"),
			Path.Combine(baseDir, @"bin\Debug\net48\profiles"),
			Path.Combine(baseDir, @"..\..\..\bin\Release\net48\profiles"),
			Path.Combine(baseDir, @"..\..\..\bin\Debug\net48\profiles")
		};

		foreach (string candidate in candidatePaths)
		{
			try
			{
				if (Directory.Exists(candidate))
				{
					return Path.GetFullPath(candidate);
				}
			}
			catch { }
		}

		return Path.Combine(baseDir, "profiles");
	}

	/// <summary>
	/// Định dạng kích thước bytes thành chuỗi hiển thị thân thiện (B, KB, MB, GB).
	/// </summary>
	public static string FormatBytes(long bytes)
	{
		if (bytes < 1024L)
		{
			return bytes + " B";
		}
		if (bytes < 1024L * 1024L)
		{
			return (bytes / 1024.0).ToString("F2") + " KB";
		}
		if (bytes < 1024L * 1024L * 1024L)
		{
			return (bytes / (1024.0 * 1024.0)).ToString("F2") + " MB";
		}
		return (bytes / (1024.0 * 1024.0 * 1024.0)).ToString("F2") + " GB";
	}

	#endregion
}
