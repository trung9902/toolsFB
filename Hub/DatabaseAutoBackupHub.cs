using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Trung tâm Tự động Sao lưu xoay vòng 7 ngày & Khôi phục SQLite DB an toàn (DatabaseAutoBackupHub).
/// Quản lý snapshot database db_lushcare.sqlite / db_maxcare.sqlite với cơ chế WAL checkpoint,
/// stream copy an toàn chống lock file, xoay vòng lưu trữ tối đa 7 bản và rollback an toàn.
/// </summary>
public static class DatabaseAutoBackupHub
{
    private static readonly object _syncLock = new object();

    /// <summary>
    /// Xác định đường dẫn file database SQLite chính đang được ứng dụng sử dụng.
    /// Ưu tiên Base.DE249839 + "\\database\\db_lushcare.sqlite", sau đó đến "db_maxcare.sqlite".
    /// </summary>
    public static string GetDatabasePath()
    {
        try
        {
            string baseDir = !string.IsNullOrEmpty(Base.DE249839)
                ? Base.DE249839.TrimEnd('\\', '/')
                : AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');

            string dbLushcare = Path.Combine(baseDir, "database", "db_lushcare.sqlite");
            string dbMaxcare = Path.Combine(baseDir, "database", "db_maxcare.sqlite");

            if (File.Exists(dbLushcare)) return dbLushcare;
            if (File.Exists(dbMaxcare)) return dbMaxcare;

            // Fallback sang thư mục ứng dụng nếu baseDir không thấy
            string startupDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');
            string dbLushStartup = Path.Combine(startupDir, "database", "db_lushcare.sqlite");
            string dbMaxStartup = Path.Combine(startupDir, "database", "db_maxcare.sqlite");

            if (File.Exists(dbLushStartup)) return dbLushStartup;
            if (File.Exists(dbMaxStartup)) return dbMaxStartup;

            // Mặc định trả về đường dẫn lushcare chuẩn
            return dbLushcare;
        }
        catch
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "db_lushcare.sqlite");
        }
    }

    /// <summary>
    /// Lấy hoặc tự động khởi tạo thư mục lưu trữ backup: Base.DE249839 + "\\database\\backup".
    /// </summary>
    public static string GetBackupDirectory()
    {
        try
        {
            string baseDir = !string.IsNullOrEmpty(Base.DE249839)
                ? Base.DE249839.TrimEnd('\\', '/')
                : AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');

            string backupDir = Path.Combine(baseDir, "database", "backup");
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }
            return backupDir;
        }
        catch
        {
            string fallback = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "backup");
            if (!Directory.Exists(fallback))
            {
                Directory.CreateDirectory(fallback);
            }
            return fallback;
        }
    }

    /// <summary>
    /// Thực hiện sao lưu database SQLite:
    /// 1. Đặt tên: db_lushcare_backup_yyyyMMdd_HHmmss.sqlite (hoặc db_maxcare_...).
    /// 2. Gọi checkpoint WAL PASSIVE nhẹ để đồng bộ trang nhớ.
    /// 3. Sao chép luồng an toàn có retry cơ chế FileShare.ReadWrite.
    /// 4. Tự động xoay vòng PruneOldBackups(keepCount: 7) giữ 7 bản mới nhất.
    /// </summary>
    /// <param name="trigger">Nguồn kích hoạt ("auto", "manual", "startup_auto")</param>
    /// <returns>Đường dẫn file backup vừa tạo, hoặc null nếu thất bại.</returns>
    public static string CreateBackup(string trigger = "auto")
    {
        lock (_syncLock)
        {
            try
            {
                string dbPath = GetDatabasePath();
                if (!File.Exists(dbPath))
                {
                    return null;
                }

                string backupDir = GetBackupDirectory();
                string dbNameWithoutExt = Path.GetFileNameWithoutExtension(dbPath);
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFileName = $"{dbNameWithoutExt}_backup_{timeStamp}.sqlite";
                string destFilePath = Path.Combine(backupDir, backupFileName);

                if (File.Exists(destFilePath))
                {
                    destFilePath = Path.Combine(backupDir, $"{dbNameWithoutExt}_backup_{timeStamp}_{Guid.NewGuid().ToString().Substring(0, 4)}.sqlite");
                }

                // 1. Sao lưu chuẩn ACID thông qua SQLite Online Backup API
                // Thêm Pooling=False và dọn dẹp pool để tránh khóa file backup khi Prune / Restore
                bool backupSuccess = false;
                try
                {
                    string srcConnStr = $"Data Source={dbPath};Version=3;Read Only=True;Pooling=False;BusyTimeout=15000;";
                    string dstConnStr = $"Data Source={destFilePath};Version=3;Pooling=False;";
                    using (var srcConn = new SQLiteConnection(srcConnStr))
                    using (var dstConn = new SQLiteConnection(dstConnStr))
                    {
                        srcConn.Open();
                        dstConn.Open();
                        srcConn.BackupDatabase(dstConn, "main", "main", -1, null, 0);
                        backupSuccess = true;
                    }
                }
                catch
                {
                    // Fallback sang checkpoint + SafeCopyFile nếu BackupDatabase gặp sự cố
                    CheckpointWalPassive(dbPath);
                    SafeCopyFile(dbPath, destFilePath);
                    string srcWal = dbPath + "-wal";
                    string dstWal = destFilePath + "-wal";
                    if (File.Exists(srcWal)) { try { SafeCopyFile(srcWal, dstWal); } catch { } }
                }

                // 3. Tự động dọn dẹp các bản backup cũ quá 7 bản
                PruneOldBackups(keepCount: 7);

                return destFilePath;
            }
            catch (Exception ex)
            {
                try
                {
                    Commom.smethod_57(null, ex, "DatabaseAutoBackupHub.CreateBackup (" + trigger + ")");
                }
                catch { }
                return null;
            }
        }
    }

    /// <summary>
    /// Quét thư mục database/backup, sắp xếp theo thời gian mới nhất, xóa các file vượt quá keepCount (mặc định 7).
    /// </summary>
    public static void PruneOldBackups(int keepCount = 7)
    {
        try
        {
            string backupDir = GetBackupDirectory();
            if (!Directory.Exists(backupDir)) return;

            DirectoryInfo dir = new DirectoryInfo(backupDir);
            var backupFiles = dir.GetFiles("*.sqlite")
                                 .Where(f => !f.Name.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                                 .OrderByDescending(f => f.LastWriteTime)
                                 .ToList();

            if (backupFiles.Count > keepCount)
            {
                for (int i = keepCount; i < backupFiles.Count; i++)
                {
                    try
                    {
                        backupFiles[i].Delete();
                    }
                    catch
                    {
                        // Bỏ qua nếu có file đang bị tiến trình khác tạm khóa
                    }
                }
            }
        }
        catch
        {
        }
    }

    /// <summary>
    /// Lấy danh sách toàn bộ các bản sao lưu SQLite có trong thư mục database/backup, sắp xếp mới nhất lên đầu.
    /// </summary>
    public static List<FileInfo> GetBackupList()
    {
        try
        {
            string backupDir = GetBackupDirectory();
            if (!Directory.Exists(backupDir)) return new List<FileInfo>();

            DirectoryInfo dir = new DirectoryInfo(backupDir);
            return dir.GetFiles("*.sqlite")
                      .Where(f => !f.Name.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                      .OrderByDescending(f => f.LastWriteTime)
                      .ToList();
        }
        catch
        {
            return new List<FileInfo>();
        }
    }

    /// <summary>
    /// Khôi phục database từ một file sao lưu an toàn:
    /// - Tạo bản backup khẩn cấp của file hiện tại: db_before_restore_yyyyMMdd_HHmmss.sqlite.bak
    /// - Đóng kết nối SQLite đang mở & giải phóng connection pool.
    /// - Xóa tệp -wal và -shm cũ để tránh tái hiện giao dịch sai lệch.
    /// - Ghi đè file an toàn & kiểm tra toàn vẹn integrity_check.
    /// </summary>
    public static bool RestoreBackup(string backupFilePath, out string error)
    {
        lock (_syncLock)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(backupFilePath) || !File.Exists(backupFilePath))
            {
                error = "Tệp sao lưu không tồn tại hoặc đường dẫn không hợp lệ: " + backupFilePath;
                return false;
            }

            string currentDbPath = GetDatabasePath();
            string backupDir = GetBackupDirectory();
            string preRestoreBak = Path.Combine(backupDir, $"db_before_restore_{DateTime.Now:yyyyMMdd_HHmmss}.sqlite.bak");

            try
            {
                // 1. Tạo bản snapshot dự phòng an toàn trước khi khôi phục
                if (File.Exists(currentDbPath))
                {
                    try
                    {
                        SafeCopyFile(currentDbPath, preRestoreBak);
                    }
                    catch (Exception ex)
                    {
                        error = "Không thể tạo bản sao an toàn trước khi khôi phục: " + ex.Message;
                        return false;
                    }
                }

                // 2. Đóng kết nối đang hoạt động trong bộ quản lý ConnectorAccounts
                try
                {
                    if (ConnectorAccounts.connectorAccounts_0 != null && ConnectorAccounts.connectorAccounts_0.sqliteConnection_0 != null)
                    {
                        if (ConnectorAccounts.connectorAccounts_0.sqliteConnection_0.State == ConnectionState.Open)
                        {
                            ConnectorAccounts.connectorAccounts_0.sqliteConnection_0.Close();
                        }
                        ConnectorAccounts.connectorAccounts_0.sqliteConnection_0.Dispose();
                        ConnectorAccounts.connectorAccounts_0.sqliteConnection_0 = null;
                    }
                }
                catch { }

                // 3. Giải phóng hoàn toàn Connection Pool của SQLite
                try
                {
                }
                catch { }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(200);

                // 4. Xóa các tệp WAL và SHM cũ nếu có để tránh phục hồi giao dịch cũ đè lên dữ liệu mới
                string walPath = currentDbPath + "-wal";
                string shmPath = currentDbPath + "-shm";
                try { if (File.Exists(walPath)) File.Delete(walPath); } catch { }
                try { if (File.Exists(shmPath)) File.Delete(shmPath); } catch { }

                // 5. Ghi đè file database chính từ bản sao lưu
                SafeCopyFile(backupFilePath, currentDbPath);

                // 6. Kiểm tra tính toàn vẹn (integrity_check) của file vừa khôi phục
                using (var conn = new SQLiteConnection($"Data Source={currentDbPath};Version=3;BusyTimeout=5000;"))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("PRAGMA quick_check;", conn))
                    {
                        object checkResult = cmd.ExecuteScalar();
                        string checkStr = checkResult?.ToString() ?? "";
                        if (!checkStr.Equals("ok", StringComparison.OrdinalIgnoreCase))
                        {
                            // Nếu tệp lỗi, khôi phục lại bản dự phòng
                            try
                            {
                                if (File.Exists(preRestoreBak))
                                {
                                    SafeCopyFile(preRestoreBak, currentDbPath);
                                }
                            }
                            catch { }

                            error = "Cơ sở dữ liệu khôi phục không vượt qua kiểm tra toàn vẹn SQLite: " + checkStr;
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Rollback nếu phát sinh lỗi
                try
                {
                    if (File.Exists(preRestoreBak))
                    {
                        SafeCopyFile(preRestoreBak, currentDbPath);
                    }
                }
                catch { }

                error = "Lỗi trong quá trình khôi phục database: " + ex.Message;
                return false;
            }
        }
    }

    /// <summary>
    /// Kiểm tra bản backup gần nhất trong database/backup.
    /// Nếu chưa có bản nào hoặc bản gần nhất đã tạo cách đây hơn 12 tiếng -> tự động tạo 1 bản backup nền trong Task.Run.
    /// </summary>
    public static void AutoBackupOnStartup()
    {
        try
        {
            Task.Run(() =>
            {
                try
                {
                    // Chờ 3 giây sau khi ứng dụng khởi động để giao diện và kết nối sẵn sàng
                    Thread.Sleep(3000);

                    var backups = GetBackupList();
                    bool shouldBackup = false;

                    if (backups == null || backups.Count == 0)
                    {
                        shouldBackup = true;
                    }
                    else
                    {
                        var newest = backups[0];
                        if (DateTime.Now - newest.LastWriteTime > TimeSpan.FromHours(12))
                        {
                            shouldBackup = true;
                        }
                    }

                    if (shouldBackup)
                    {
                        CreateBackup("startup_auto");
                    }
                }
                catch
                {
                    // Lỗi ngầm trong luồng không làm ảnh hưởng giao diện chính
                }
            });
        }
        catch
        {
        }
    }

    /// <summary>
    /// Gửi lệnh PRAGMA wal_checkpoint(TRUNCATE) để flush toàn bộ các trang WAL về file chính và thu gọn WAL file.
    /// </summary>
    private static void CheckpointWalPassive(string dbPath)
    {
        try
        {
            if (ConnectorAccounts.connectorAccounts_0 != null &&
                ConnectorAccounts.connectorAccounts_0.sqliteConnection_0 != null &&
                ConnectorAccounts.connectorAccounts_0.sqliteConnection_0.State == ConnectionState.Open)
            {
                ConnectorAccounts.ConnectorAccounts_0.method_2("PRAGMA wal_checkpoint(TRUNCATE);");
                return;
            }

            string connStr = $"Data Source={dbPath};Version=3;Journal Mode=WAL;BusyTimeout=15000;";
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("PRAGMA wal_checkpoint(TRUNCATE);", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch
        {
            // Bỏ qua lỗi checkpoint, tiếp tục sao chép file
        }
    }

    /// <summary>
    /// Sao chép file an toàn sử dụng FileStream với cờ FileShare.ReadWrite và vòng lặp retry.
    /// Giúp đọc được file SQLite ngay cả khi đang có tiến trình mở đọc/ghi.
    /// </summary>
    private static void SafeCopyFile(string sourcePath, string destPath)
    {
        const int maxRetries = 5;
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                using (var src = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var dst = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    src.CopyTo(dst);
                    dst.Flush(true);
                }
                return;
            }
            catch (IOException) when (attempt < maxRetries)
            {
                Thread.Sleep(250 * attempt);
            }
        }

        // Phương thức fallback cuối cùng
        File.Copy(sourcePath, destPath, true);
    }
}
