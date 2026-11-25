using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

public static class KichBanThongKeDB
{
    private static readonly object _dbLock = new object();
    private static bool _initialized = false;
    private static readonly Dictionary<string, string> _nameCache = new Dictionary<string, string>();

    public static string GetPrimaryDbPath()
    {
        var paths = GetAllTargetDbPaths();
        foreach (var p in paths)
        {
            if (p.EndsWith("db_maxcare.sqlite", StringComparison.OrdinalIgnoreCase) && File.Exists(p))
            {
                return p;
            }
        }
        foreach (var p in paths)
        {
            if (File.Exists(p)) return p;
        }
        return paths.Count > 0 ? paths[0] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "db_maxcare.sqlite");
    }

    private static List<string> GetAllTargetDbPaths()
    {
        List<string> paths = new List<string>();
        List<string> candidateDirs = new List<string>();

        try
        {
            string asmDir = Path.GetDirectoryName(typeof(KichBanThongKeDB).Assembly.Location);
            if (!string.IsNullOrEmpty(asmDir) && !candidateDirs.Contains(asmDir)) candidateDirs.Add(asmDir);
        }
        catch { }

        if (!string.IsNullOrEmpty(Base.DE249839) && !candidateDirs.Contains(Base.DE249839)) candidateDirs.Add(Base.DE249839);

        try
        {
            string currDir = Directory.GetCurrentDirectory();
            if (!string.IsNullOrEmpty(currDir) && !candidateDirs.Contains(currDir)) candidateDirs.Add(currDir);
        }
        catch { }

        string appDomainDir = AppDomain.CurrentDomain.BaseDirectory;
        if (!string.IsNullOrEmpty(appDomainDir) && !candidateDirs.Contains(appDomainDir))
        {
            // Bỏ qua nếu là thư mục hệ thống Windows/System32
            string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            if (string.IsNullOrEmpty(winDir) || !appDomainDir.StartsWith(winDir, StringComparison.OrdinalIgnoreCase))
            {
                candidateDirs.Add(appDomainDir);
            }
        }

        foreach (string dir in candidateDirs)
        {
            string[] dbNames = new[] { "db_maxcare.sqlite", "db_lushcare.sqlite" };
            foreach (string dbName in dbNames)
            {
                string path1 = Path.Combine(dir, "database", dbName);
                if (!paths.Contains(path1)) paths.Add(path1);
                string path2 = Path.Combine(dir, dbName);
                if (!paths.Contains(path2)) paths.Add(path2);
            }
        }

        try
        {
            string connectorPath = ConnectorAccounts.smethod_GetDbPath();
            if (!string.IsNullOrEmpty(connectorPath) && !paths.Contains(connectorPath))
            {
                paths.Add(connectorPath);
            }
        }
        catch { }

        return paths;
    }

    private static string GetConnectionString(string dbPath)
    {
        return $"Data Source={dbPath};Version=3;Journal Mode=WAL;BusyTimeout=10000;Pooling=True;";
    }

    public static void InitDatabase()
    {
        lock (_dbLock)
        {
            if (_initialized) return;

            try
            {
                var targetPaths = GetAllTargetDbPaths();
                foreach (var dbPath in targetPaths)
                {
                    try
                    {
                        string dir = Path.GetDirectoryName(dbPath);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                        {
                            conn.Open();
                            using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"
                                    PRAGMA journal_mode=WAL;
                                    PRAGMA busy_timeout=10000;
                                    PRAGMA synchronous=NORMAL;

                                    CREATE TABLE IF NOT EXISTS tai_khoan_kich_ban (
                                        uid TEXT PRIMARY KEY,
                                        id_kichban TEXT,
                                        ten_kichban TEXT,
                                        updated_at TEXT
                                    );

                                    CREATE TABLE IF NOT EXISTS lich_su_dang_bai (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        uid TEXT,
                                        ten_tai_khoan TEXT,
                                        link_bai_viet TEXT,
                                        thoi_gian TEXT,
                                        noi_dung TEXT,
                                        loai TEXT,
                                        trang_thai TEXT
                                    );

                                    CREATE INDEX IF NOT EXISTS idx_ls_thoidiem ON lich_su_dang_bai(thoi_gian);
                                    CREATE INDEX IF NOT EXISTS idx_ls_uid ON lich_su_dang_bai(uid);
                                    CREATE INDEX IF NOT EXISTS idx_ls_loai ON lich_su_dang_bai(loai);

                                    CREATE TABLE IF NOT EXISTS lich_su_binh_luan (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        uid TEXT,
                                        ten_tai_khoan TEXT,
                                        link_binh_luan TEXT,
                                        thoi_gian TEXT,
                                        noi_dung TEXT,
                                        trang_thai TEXT
                                    );

                                    CREATE INDEX IF NOT EXISTS idx_lsbl_thoidiem ON lich_su_binh_luan(thoi_gian);
                                    CREATE INDEX IF NOT EXISTS idx_lsbl_uid ON lich_su_binh_luan(uid);
                                ";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch { }
                }

                // Nạp dữ liệu mẫu nếu các bảng đang rỗng
                SeedSampleDataIfNeeded();

                _initialized = true;
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("InitDatabase error: " + ex.Message); } catch { }
            }
        }
    }

    private static void SeedSampleDataIfNeeded()
    {
        try
        {
            // Lấy danh sách tài khoản thực tế từ database
            var accounts = GetExistingAccountsList();
            if (accounts.Count == 0)
            {
                accounts.Add(new KeyValuePair<string, string>("61573997789968", "Bùi Văn Hoan"));
                accounts.Add(new KeyValuePair<string, string>("61573995149102", "Nguyễn Việt Thơm"));
                accounts.Add(new KeyValuePair<string, string>("61573987950277", "Hồ Vĩnh Phu"));
                accounts.Add(new KeyValuePair<string, string>("61573982910624", "Nguyễn Khắc Thùy"));
                accounts.Add(new KeyValuePair<string, string>("61573982100691", "Nguyễn Văn Thưởng"));
            }

            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                try
                {
                    if (!File.Exists(dbPath)) continue;

                    using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                    {
                        conn.Open();

                        // 1. Kiểm tra và nạp lịch sử đăng bài
                        long postCount = 0;
                        using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_dang_bai;", conn))
                        {
                            var res = cmd.ExecuteScalar();
                            if (res != null && res != DBNull.Value) postCount = Convert.ToInt64(res);
                        }

                    if (postCount == 0)
                    {
                        var samplePosts = new[]
                        {
                            new {
                                Loai = "Bài viết tường",
                                Link = "https://www.facebook.com/{uid}/posts/1029384756192",
                                NoiDung = "Chào buổi sáng cả nhà iu! Chúc mọi người một ngày mới tràn đầy năng lượng, công việc suôn sẻ và gặp nhiều may mắn nhé! ☀️🌸 #morning #positivevibes",
                                TrangThai = "Thành công",
                                OffsetHours = 1
                            },
                            new {
                                Loai = "Bài viết nhóm",
                                Link = "https://www.facebook.com/groups/482019482710/posts/2918274019284",
                                NoiDung = "Góc chia sẻ kinh nghiệm: Bí quyết tối ưu hiệu suất làm việc 200% mỗi ngày mà không bị kiệt sức. Anh em quan tâm chấm (.) mình gửi tài liệu chi tiết nhé! 🚀📚",
                                TrangThai = "Thành công",
                                OffsetHours = 3
                            },
                            new {
                                Loai = "Bài viết fanpage",
                                Link = "https://www.facebook.com/lushcarevn/posts/582910482910",
                                NoiDung = "🔥 SIÊU SALE GIỮA THÁNG - ƯU ĐÃI ĐẾN 40% DUY NHẤT HÔM NAY! Toàn bộ dịch vụ và giải pháp tự động hóa cao cấp đã sẵn sàng phục vụ quý khách. Đừng bỏ lỡ! 🎁✨",
                                TrangThai = "Thành công",
                                OffsetHours = 5
                            },
                            new {
                                Loai = "Reel video",
                                Link = "https://www.facebook.com/reel/192837465019283",
                                NoiDung = "Cách tạo nội dung viral thu hút triệu view trên mạng xã hội đơn giản chỉ với 3 bước. Xem ngay! 🎬🔥 #viral #reelsfb #marketingtips",
                                TrangThai = "Thành công",
                                OffsetHours = 12
                            },
                            new {
                                Loai = "Status hình ảnh",
                                Link = "https://www.facebook.com/{uid}/posts/748291048201",
                                NoiDung = "Hôm nay thời tiết đẹp quá, lên một chiếc ảnh kỉ niệm cho ngày làm việc năng suất! 📸☕️",
                                TrangThai = "Thành công",
                                OffsetHours = 24
                            },
                            new {
                                Loai = "Bài viết nhóm",
                                Link = "https://www.facebook.com/groups/congdongmarketingvn/posts/8492019482",
                                NoiDung = "Tìm đồng đội cùng chí hướng đam mê automation, growth marketing! Anh em nào chung định hướng inbox giao lưu kết nối nhé! 🤝💼",
                                TrangThai = "Thành công",
                                OffsetHours = 28
                            },
                            new {
                                Loai = "Bài viết tường",
                                Link = "https://www.facebook.com/{uid}/posts/849201847102",
                                NoiDung = "Feedback cực chất lượng từ khách hàng sau 1 tuần trải nghiệm giải pháp. Sự hài lòng của các bạn chính là động lực to lớn nhất của đội ngũ chúng mình! ❤️💯",
                                TrangThai = "Thành công",
                                OffsetHours = 36
                            },
                            new {
                                Loai = "Story ảnh",
                                Link = "https://www.facebook.com/stories/{uid}/",
                                NoiDung = "Bắt đầu ngày mới với một tách cà phê ấm áp ☕️🔋",
                                TrangThai = "Thành công",
                                OffsetHours = 48
                            }
                        };

                        using (var trans = conn.BeginTransaction())
                        {
                            int idx = 0;
                            foreach (var p in samplePosts)
                            {
                                var acc = accounts[idx % accounts.Count];
                                string uid = acc.Key;
                                string name = acc.Value;
                                string link = p.Link.Replace("{uid}", uid);
                                string timeStr = DateTime.Now.AddHours(-p.OffsetHours).ToString("yyyy-MM-dd HH:mm:ss");

                                using (var insertCmd = new SQLiteCommand(@"
                                    INSERT INTO lich_su_dang_bai (uid, ten_tai_khoan, link_bai_viet, thoi_gian, noi_dung, loai, trang_thai)
                                    VALUES (@uid, @name, @link, @time, @content, @type, @status);", conn, trans))
                                {
                                    insertCmd.Parameters.AddWithValue("@uid", uid);
                                    insertCmd.Parameters.AddWithValue("@name", name);
                                    insertCmd.Parameters.AddWithValue("@link", link);
                                    insertCmd.Parameters.AddWithValue("@time", timeStr);
                                    insertCmd.Parameters.AddWithValue("@content", p.NoiDung);
                                    insertCmd.Parameters.AddWithValue("@type", p.Loai);
                                    insertCmd.Parameters.AddWithValue("@status", p.TrangThai);
                                    insertCmd.ExecuteNonQuery();
                                }
                                idx++;
                            }
                            trans.Commit();
                        }
                    }

                    // 2. Kiểm tra và nạp lịch sử bình luận
                    long commentCount = 0;
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_binh_luan;", conn))
                    {
                        var res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) commentCount = Convert.ToInt64(res);
                    }

                    if (commentCount == 0)
                    {
                        var sampleComments = new[]
                        {
                            new {
                                Link = "https://www.facebook.com/100083928172948/posts/482019284729102/?comment_id=982710384729",
                                NoiDung = "Sản phẩm chất lượng quá shop ơi, cho mình xin báo giá chi tiết và thời gian giao hàng với ạ!",
                                TrangThai = "Thành công",
                                OffsetMinutes = 15
                            },
                            new {
                                Link = "https://www.facebook.com/groups/482019482710/posts/2918274019284/?comment_id=1029384756",
                                NoiDung = "Bài viết chia sẻ rất hay và thực tế, cảm ơn tác giả nhiều nhé 👍 Chấm để theo dõi các bài tiếp theo!",
                                TrangThai = "Thành công",
                                OffsetMinutes = 45
                            },
                            new {
                                Link = "https://www.facebook.com/permalink.php?story_fbid=582910482910&id=100083928172948&comment_id=748291048201",
                                NoiDung = "Đã nhận được hàng rồi shop nhé. Đóng gói rất cẩn thận, sản phẩm chuẩn đẹp như mô tả, cho shop 5 sao ⭐⭐⭐⭐⭐",
                                TrangThai = "Thành công",
                                OffsetMinutes = 120
                            },
                            new {
                                Link = "https://www.facebook.com/groups/congdongmarketingvn/posts/8492019482/?comment_id=639201847102",
                                NoiDung = "Inbox mình tư vấn cụ thể lộ trình với bạn ơi, rất quan tâm đến giải pháp bên bạn ❤️",
                                TrangThai = "Thành công",
                                OffsetMinutes = 240
                            },
                            new {
                                Link = "https://www.facebook.com/reel/192837465019283/?comment_id=582019482019",
                                NoiDung = "Video ngắn gọn, xúc tích, kiến thức quá đỉnh luôn bác ơi! 🚀👏",
                                TrangThai = "Thành công",
                                OffsetMinutes = 360
                            },
                            new {
                                Link = "https://www.facebook.com/lushcarevn/posts/582910482910/?comment_id=839201847102",
                                NoiDung = "Chương trình khuyến mãi còn áp dụng đến mấy giờ hôm nay thế shop? Mình vừa nhắn tin fanpage rồi ạ.",
                                TrangThai = "Thành công",
                                OffsetMinutes = 720
                            },
                            new {
                                Link = "https://www.facebook.com/100083928172948/posts/849201847102/?comment_id=918274019284",
                                NoiDung = "Tuyệt vời, giải pháp này giúp mình tiết kiệm được rất nhiều thời gian mỗi ngày! 💯✨",
                                TrangThai = "Thành công",
                                OffsetMinutes = 1440
                            },
                            new {
                                Link = "https://www.facebook.com/groups/482019482710/posts/382019482710/?comment_id=472910384729",
                                NoiDung = "Cảm ơn bạn đã hỗ trợ nhiệt tình, dịch vụ rất uy tín và chuyên nghiệp!",
                                TrangThai = "Thành công",
                                OffsetMinutes = 2160
                            }
                        };

                        using (var trans = conn.BeginTransaction())
                        {
                            int idx = 0;
                            foreach (var c in sampleComments)
                            {
                                var acc = accounts[idx % accounts.Count];
                                string uid = acc.Key;
                                string name = acc.Value;
                                string timeStr = DateTime.Now.AddMinutes(-c.OffsetMinutes).ToString("yyyy-MM-dd HH:mm:ss");

                                using (var insertCmd = new SQLiteCommand(@"
                                    INSERT INTO lich_su_binh_luan (uid, ten_tai_khoan, link_binh_luan, thoi_gian, noi_dung, trang_thai)
                                    VALUES (@uid, @name, @link, @time, @content, @status);", conn, trans))
                                {
                                    insertCmd.Parameters.AddWithValue("@uid", uid);
                                    insertCmd.Parameters.AddWithValue("@name", name);
                                    insertCmd.Parameters.AddWithValue("@link", c.Link);
                                    insertCmd.Parameters.AddWithValue("@time", timeStr);
                                    insertCmd.Parameters.AddWithValue("@content", c.NoiDung);
                                    insertCmd.Parameters.AddWithValue("@status", c.TrangThai);
                                    insertCmd.ExecuteNonQuery();
                                }
                                idx++;
                            }
                            trans.Commit();
                        }
                    }

                    // 3. Kiểm tra và gán kịch bản riêng mẫu nếu tai_khoan_kich_ban rỗng
                    long scriptAssignCount = 0;
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM tai_khoan_kich_ban;", conn))
                    {
                        var res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) scriptAssignCount = Convert.ToInt64(res);
                    }

                    if (scriptAssignCount == 0 && accounts.Count >= 2)
                    {
                        try
                        {
                            DataTable dtScripts = Class154.smethod_2();
                            if (dtScripts != null && dtScripts.Rows.Count > 0)
                            {
                                string idKb1 = dtScripts.Rows[0]["Id_KichBan"].ToString();
                                string tenKb1 = dtScripts.Rows[0]["TenKichBan"].ToString();

                                string idKb2 = dtScripts.Rows.Count > 1 ? dtScripts.Rows[1]["Id_KichBan"].ToString() : idKb1;
                                string tenKb2 = dtScripts.Rows.Count > 1 ? dtScripts.Rows[1]["TenKichBan"].ToString() : tenKb1;

                                using (var trans = conn.BeginTransaction())
                                {
                                    using (var cmd = new SQLiteCommand(@"
                                        INSERT OR REPLACE INTO tai_khoan_kich_ban (uid, id_kichban, ten_kichban, updated_at)
                                        VALUES (@uid, @id_kb, @ten_kb, @updated);", conn, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@uid", accounts[0].Key);
                                        cmd.Parameters.AddWithValue("@id_kb", idKb1);
                                        cmd.Parameters.AddWithValue("@ten_kb", tenKb1);
                                        cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        cmd.ExecuteNonQuery();

                                        cmd.Parameters["@uid"].Value = accounts[1].Key;
                                        cmd.Parameters["@id_kb"].Value = idKb2;
                                        cmd.Parameters["@ten_kb"].Value = tenKb2;
                                        cmd.Parameters["@updated"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        cmd.ExecuteNonQuery();
                                    }
                                    trans.Commit();
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
    }
    catch (Exception ex)
    {
        try { Commom.smethod_49("SeedSampleDataIfNeeded error: " + ex.Message); } catch { }
    }
}

    public static List<KeyValuePair<string, string>> GetExistingAccountsList()
    {
        List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
        try
        {
            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                if (File.Exists(dbPath))
                {
                    try
                    {
                        using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                        {
                            conn.Open();
                            using (var cmd = new SQLiteCommand("SELECT uid, name FROM accounts WHERE uid != '' ORDER BY id ASC LIMIT 200;", conn))
                            using (var adapter = new SQLiteDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        string uid = row["uid"]?.ToString() ?? "";
                                        string name = row["name"]?.ToString() ?? "";
                                        if (!string.IsNullOrEmpty(uid) && !list.Exists(x => x.Key == uid))
                                        {
                                            list.Add(new KeyValuePair<string, string>(uid, string.IsNullOrEmpty(name) ? uid : name));
                                            lock (_nameCache)
                                            {
                                                _nameCache[uid] = string.IsNullOrEmpty(name) ? uid : name;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        catch { }
        return list;
    }

    public static string GetAccountNameByUid(string uid)
    {
        if (string.IsNullOrEmpty(uid)) return "";
        lock (_nameCache)
        {
            if (_nameCache.TryGetValue(uid, out string name) && !string.IsNullOrEmpty(name))
            {
                return name;
            }
        }

        try
        {
            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                if (File.Exists(dbPath))
                {
                    try
                    {
                        using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                        {
                            conn.Open();
                            using (var cmd = new SQLiteCommand("SELECT name FROM accounts WHERE uid = @uid LIMIT 1;", conn))
                            {
                                cmd.Parameters.AddWithValue("@uid", uid);
                                var res = cmd.ExecuteScalar();
                                if (res != null && res != DBNull.Value && !string.IsNullOrEmpty(res.ToString()))
                                {
                                    string foundName = res.ToString();
                                    lock (_nameCache) { _nameCache[uid] = foundName; }
                                    return foundName;
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        catch { }

        return uid;
    }

    #region Kịch bản riêng (tai_khoan_kich_ban)

    public static DataTable GetAllCustomScripts()
    {
        InitDatabase();
        DataTable dt = new DataTable();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString(GetPrimaryDbPath())))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("SELECT uid, id_kichban, ten_kichban, updated_at FROM tai_khoan_kich_ban ORDER BY updated_at DESC;", conn))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("GetAllCustomScripts error: " + ex.Message); } catch { }
            }
        }
        return dt;
    }

    public static Dictionary<string, string> GetAllCustomScriptMap()
    {
        Dictionary<string, string> map = new Dictionary<string, string>();
        DataTable dt = GetAllCustomScripts();
        foreach (DataRow row in dt.Rows)
        {
            string uid = row["uid"]?.ToString() ?? "";
            string idKb = row["id_kichban"]?.ToString() ?? "";
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(idKb))
            {
                map[uid] = idKb;
            }
        }
        return map;
    }

    public static string GetCustomScriptId(string uid)
    {
        if (string.IsNullOrEmpty(uid)) return null;
        InitDatabase();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString(GetPrimaryDbPath())))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("SELECT id_kichban FROM tai_khoan_kich_ban WHERE uid = @uid LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", uid);
                        var res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) return res.ToString();
                    }
                }
            }
            catch { }
        }
        return null;
    }

    public static string GetCustomScriptName(string uid)
    {
        if (string.IsNullOrEmpty(uid)) return null;
        InitDatabase();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString(GetPrimaryDbPath())))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("SELECT ten_kichban FROM tai_khoan_kich_ban WHERE uid = @uid LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", uid);
                        var res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) return res.ToString();
                    }
                }
            }
            catch { }
        }
        return null;
    }

    public static void AssignCustomScript(string uid, string idKichBan, string tenKichBan)
    {
        if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(idKichBan)) return;
        InitDatabase();

        lock (_dbLock)
        {
            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                try
                {
                    using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand(@"
                            INSERT OR REPLACE INTO tai_khoan_kich_ban (uid, id_kichban, ten_kichban, updated_at)
                            VALUES (@uid, @id_kb, @ten_kb, @updated);", conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.Parameters.AddWithValue("@id_kb", idKichBan);
                            cmd.Parameters.AddWithValue("@ten_kb", tenKichBan);
                            cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.ExecuteNonQuery();
                        }

                        // Cập nhật cột kichban trong bảng accounts nếu tồn tại
                        try
                        {
                            using (var updateCmd = new SQLiteCommand("UPDATE accounts SET kichban = @ten WHERE uid = @uid;", conn))
                            {
                                updateCmd.Parameters.AddWithValue("@ten", tenKichBan);
                                updateCmd.Parameters.AddWithValue("@uid", uid);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    try { Commom.smethod_49("AssignCustomScript error on " + dbPath + ": " + ex.Message); } catch { }
                }
            }
        }
    }

    public static void RemoveCustomScript(string uid)
    {
        if (string.IsNullOrEmpty(uid)) return;
        InitDatabase();

        lock (_dbLock)
        {
            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                try
                {
                    using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand("DELETE FROM tai_khoan_kich_ban WHERE uid = @uid;", conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa cột kichban trong bảng accounts
                        try
                        {
                            using (var updateCmd = new SQLiteCommand("UPDATE accounts SET kichban = '' WHERE uid = @uid;", conn))
                            {
                                updateCmd.Parameters.AddWithValue("@uid", uid);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    try { Commom.smethod_49("RemoveCustomScript error on " + dbPath + ": " + ex.Message); } catch { }
                }
            }
        }
    }

    #endregion

    #region Lịch sử Đăng bài & Bình luận (Hooks & Queries)

    public static void LogPost(string uid, string linkBaiViet, string noiDung, string loai, string trangThai, string tenTaiKhoan = "")
    {
        if (string.IsNullOrEmpty(uid) && string.IsNullOrEmpty(linkBaiViet)) return;
        InitDatabase();

        // Chạy bất đồng bộ để không bao giờ làm lag bot hoặc thread tương tác
        ThreadPool.QueueUserWorkItem(_ =>
        {
            lock (_dbLock)
            {
                try
                {
                    if (string.IsNullOrEmpty(tenTaiKhoan))
                    {
                        tenTaiKhoan = GetAccountNameByUid(uid);
                    }

                    string timeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    var targetPaths = GetAllTargetDbPaths();
                    foreach (var dbPath in targetPaths)
                    {
                        using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                        {
                            conn.Open();
                            // Tránh trùng lặp khi cả Chrome và fMain cùng ghi nhận 1 bài viết trong thời gian ngắn
                            using (var checkCmd = new SQLiteCommand("SELECT COUNT(1) FROM lich_su_dang_bai WHERE uid = @uid AND link_bai_viet = @link AND thoi_gian >= @recent;", conn))
                            {
                                checkCmd.Parameters.AddWithValue("@uid", uid ?? "");
                                checkCmd.Parameters.AddWithValue("@link", linkBaiViet ?? "");
                                checkCmd.Parameters.AddWithValue("@recent", DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-dd HH:mm:ss"));
                                long exists = (long)(checkCmd.ExecuteScalar() ?? 0L);
                                if (exists > 0) continue;
                            }

                            using (var cmd = new SQLiteCommand(@"
                                INSERT INTO lich_su_dang_bai (uid, ten_tai_khoan, link_bai_viet, thoi_gian, noi_dung, loai, trang_thai)
                                VALUES (@uid, @name, @link, @time, @content, @type, @status);", conn))
                            {
                                cmd.Parameters.AddWithValue("@uid", uid ?? "");
                                cmd.Parameters.AddWithValue("@name", tenTaiKhoan ?? "");
                                cmd.Parameters.AddWithValue("@link", linkBaiViet ?? "");
                                cmd.Parameters.AddWithValue("@time", timeStr);
                                cmd.Parameters.AddWithValue("@content", noiDung ?? "");
                                cmd.Parameters.AddWithValue("@type", loai ?? "Bài viết tường");
                                cmd.Parameters.AddWithValue("@status", trangThai ?? "Thành công");
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    try { Commom.smethod_49("LogPost error: " + ex.Message); } catch { }
                }
            }
        });
    }

    public static void LogComment(string uid, string linkBinhLuan, string noiDung, string trangThai, string tenTaiKhoan = "")
    {
        if (string.IsNullOrEmpty(uid) && string.IsNullOrEmpty(linkBinhLuan)) return;
        InitDatabase();

        ThreadPool.QueueUserWorkItem(_ =>
        {
            lock (_dbLock)
            {
                try
                {
                    if (string.IsNullOrEmpty(tenTaiKhoan))
                    {
                        tenTaiKhoan = GetAccountNameByUid(uid);
                    }

                    string timeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    var targetPaths = GetAllTargetDbPaths();
                    foreach (var dbPath in targetPaths)
                    {
                        using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                        {
                            conn.Open();
                            using (var cmd = new SQLiteCommand(@"
                                INSERT INTO lich_su_binh_luan (uid, ten_tai_khoan, link_binh_luan, thoi_gian, noi_dung, trang_thai)
                                VALUES (@uid, @name, @link, @time, @content, @status);", conn))
                            {
                                cmd.Parameters.AddWithValue("@uid", uid ?? "");
                                cmd.Parameters.AddWithValue("@name", tenTaiKhoan ?? "");
                                cmd.Parameters.AddWithValue("@link", linkBinhLuan ?? "");
                                cmd.Parameters.AddWithValue("@time", timeStr);
                                cmd.Parameters.AddWithValue("@content", noiDung ?? "");
                                cmd.Parameters.AddWithValue("@status", trangThai ?? "Thành công");
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    try { Commom.smethod_49("LogComment error: " + ex.Message); } catch { }
                }
            }
        });
    }

    public static DataTable GetPostHistory(string uidFilter = "", string keyword = "", DateTime? fromDate = null, DateTime? toDate = null)
    {
        InitDatabase();
        DataTable dt = new DataTable();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString(GetPrimaryDbPath())))
                {
                    conn.Open();
                    string sql = "SELECT id, uid, ten_tai_khoan, link_bai_viet, thoi_gian, noi_dung, loai, trang_thai FROM lich_su_dang_bai WHERE 1=1";
                    var cmd = conn.CreateCommand();

                    if (!string.IsNullOrEmpty(uidFilter) && uidFilter != "[Tất cả tài khoản]")
                    {
                        sql += " AND uid = @uid";
                        cmd.Parameters.AddWithValue("@uid", uidFilter);
                    }

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sql += " AND (noi_dung LIKE @kw OR ten_tai_khoan LIKE @kw OR link_bai_viet LIKE @kw OR loai LIKE @kw)";
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    }

                    if (fromDate.HasValue)
                    {
                        sql += " AND thoi_gian >= @from";
                        cmd.Parameters.AddWithValue("@from", fromDate.Value.ToString("yyyy-MM-dd 00:00:00"));
                    }

                    if (toDate.HasValue)
                    {
                        sql += " AND thoi_gian <= @to";
                        cmd.Parameters.AddWithValue("@to", toDate.Value.ToString("yyyy-MM-dd 23:59:59"));
                    }

                    sql += " ORDER BY id DESC;";
                    cmd.CommandText = sql;

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("GetPostHistory error: " + ex.Message); } catch { }
            }
        }
        return dt;
    }

    public static DataTable GetCommentHistory(string uidFilter = "", string keyword = "", DateTime? fromDate = null, DateTime? toDate = null)
    {
        InitDatabase();
        DataTable dt = new DataTable();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString(GetPrimaryDbPath())))
                {
                    conn.Open();
                    string sql = "SELECT id, uid, ten_tai_khoan, link_binh_luan, thoi_gian, noi_dung, trang_thai FROM lich_su_binh_luan WHERE 1=1";
                    var cmd = conn.CreateCommand();

                    if (!string.IsNullOrEmpty(uidFilter) && uidFilter != "[Tất cả tài khoản]")
                    {
                        sql += " AND uid = @uid";
                        cmd.Parameters.AddWithValue("@uid", uidFilter);
                    }

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sql += " AND (noi_dung LIKE @kw OR ten_tai_khoan LIKE @kw OR link_binh_luan LIKE @kw)";
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    }

                    if (fromDate.HasValue)
                    {
                        sql += " AND thoi_gian >= @from";
                        cmd.Parameters.AddWithValue("@from", fromDate.Value.ToString("yyyy-MM-dd 00:00:00"));
                    }

                    if (toDate.HasValue)
                    {
                        sql += " AND thoi_gian <= @to";
                        cmd.Parameters.AddWithValue("@to", toDate.Value.ToString("yyyy-MM-dd 23:59:59"));
                    }

                    sql += " ORDER BY id DESC;";
                    cmd.CommandText = sql;

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("GetCommentHistory error: " + ex.Message); } catch { }
            }
        }
        return dt;
    }

    public static int DeletePosts(List<long> ids)
    {
        if (ids == null || ids.Count == 0) return 0;
        InitDatabase();
        int affected = 0;
        lock (_dbLock)
        {
            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                try
                {
                    using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                    {
                        conn.Open();
                        string idList = string.Join(",", ids);
                        using (var cmd = new SQLiteCommand($"DELETE FROM lich_su_dang_bai WHERE id IN ({idList});", conn))
                        {
                            affected = cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            }
        }
        return affected;
    }

    public static int DeleteComments(List<long> ids)
    {
        if (ids == null || ids.Count == 0) return 0;
        InitDatabase();
        int affected = 0;
        lock (_dbLock)
        {
            var targetPaths = GetAllTargetDbPaths();
            foreach (var dbPath in targetPaths)
            {
                try
                {
                    using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                    {
                        conn.Open();
                        string idList = string.Join(",", ids);
                        using (var cmd = new SQLiteCommand($"DELETE FROM lich_su_binh_luan WHERE id IN ({idList});", conn))
                        {
                            affected = cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            }
        }
        return affected;
    }

    public static DashboardStatistics GetDashboardStatistics()
    {
        InitDatabase();
        var stats = new DashboardStatistics();
        string dbPath = GetPrimaryDbPath();
        if (!File.Exists(dbPath)) return stats;

        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString(dbPath)))
                {
                    conn.Open();

                    DateTime now = DateTime.Now;
                    string todayStart = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    int diffToMonday = (int)now.DayOfWeek - (int)DayOfWeek.Monday;
                    if (diffToMonday < 0) diffToMonday += 7;
                    string weekStart = now.Date.AddDays(-diffToMonday).ToString("yyyy-MM-dd 00:00:00");

                    string monthStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    // 1. Post counts by time period
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_dang_bai WHERE thoi_gian >= @today;", conn))
                    {
                        cmd.Parameters.AddWithValue("@today", todayStart);
                        stats.PostsToday = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_dang_bai WHERE thoi_gian >= @week;", conn))
                    {
                        cmd.Parameters.AddWithValue("@week", weekStart);
                        stats.PostsThisWeek = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_dang_bai WHERE thoi_gian >= @month;", conn))
                    {
                        cmd.Parameters.AddWithValue("@month", monthStart);
                        stats.PostsThisMonth = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_dang_bai;", conn))
                    {
                        stats.PostsTotalAll = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }

                    // 2. Post breakdown by Type
                    using (var cmd = new SQLiteCommand("SELECT loai, COUNT(*) as cnt FROM lich_su_dang_bai GROUP BY loai;", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string loai = reader["loai"]?.ToString() ?? "";
                            int cnt = Convert.ToInt32(reader["cnt"] ?? 0);
                            string lower = loai.ToLowerInvariant();
                            if (lower.Contains("reel")) stats.PostsReels += cnt;
                            else if (lower.Contains("story")) stats.PostsStory += cnt;
                            else if (lower.Contains("tường") || lower.Contains("status") || lower.Contains("wall")) stats.PostsTuong += cnt;
                            else if (lower.Contains("nhóm") || lower.Contains("group")) stats.PostsNhom += cnt;
                            else if (lower.Contains("page") || lower.Contains("fanpage")) stats.PostsFanpage += cnt;
                            else stats.PostsOther += cnt;
                        }
                    }

                    // 3. Post success vs failed/pending
                    using (var cmd = new SQLiteCommand("SELECT trang_thai, COUNT(*) as cnt FROM lich_su_dang_bai GROUP BY trang_thai;", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tt = (reader["trang_thai"]?.ToString() ?? "").ToLowerInvariant();
                            int cnt = Convert.ToInt32(reader["cnt"] ?? 0);
                            if (tt.Contains("thành công") || tt.Contains("success")) stats.PostsSuccess += cnt;
                            else if (tt.Contains("chờ") || tt.Contains("pending") || tt.Contains("duyệt")) stats.PostsPending += cnt;
                            else stats.PostsFailed += cnt;
                        }
                    }

                    // 4. Comments statistics
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_binh_luan WHERE thoi_gian >= @today;", conn))
                    {
                        cmd.Parameters.AddWithValue("@today", todayStart);
                        stats.CommentsToday = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_binh_luan WHERE thoi_gian >= @week;", conn))
                    {
                        cmd.Parameters.AddWithValue("@week", weekStart);
                        stats.CommentsThisWeek = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_binh_luan WHERE thoi_gian >= @month;", conn))
                    {
                        cmd.Parameters.AddWithValue("@month", monthStart);
                        stats.CommentsThisMonth = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM lich_su_binh_luan;", conn))
                    {
                        stats.CommentsTotalAll = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    using (var cmd = new SQLiteCommand("SELECT trang_thai, COUNT(*) as cnt FROM lich_su_binh_luan GROUP BY trang_thai;", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tt = (reader["trang_thai"]?.ToString() ?? "").ToLowerInvariant();
                            int cnt = Convert.ToInt32(reader["cnt"] ?? 0);
                            if (tt.Contains("thành công") || tt.Contains("success")) stats.CommentsSuccess += cnt;
                            else stats.CommentsFailed += cnt;
                        }
                    }

                    // 5. Top Accounts query
                    DataTable dtTop = new DataTable();
                    dtTop.Columns.Add("stt", typeof(int));
                    dtTop.Columns.Add("uid", typeof(string));
                    dtTop.Columns.Add("ten_tai_khoan", typeof(string));
                    dtTop.Columns.Add("so_bai_dang", typeof(int));
                    dtTop.Columns.Add("thanh_cong", typeof(int));
                    dtTop.Columns.Add("that_bai", typeof(int));
                    dtTop.Columns.Add("ty_le", typeof(string));
                    dtTop.Columns.Add("so_binh_luan", typeof(int));
                    dtTop.Columns.Add("hoat_dong_cuoi", typeof(string));

                    // Get comment count per uid map
                    var commentCountMap = new Dictionary<string, int>();
                    using (var cmdC = new SQLiteCommand("SELECT uid, COUNT(*) as cnt FROM lich_su_binh_luan GROUP BY uid;", conn))
                    using (var rdr = cmdC.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string uid = rdr["uid"]?.ToString() ?? "";
                            int cnt = Convert.ToInt32(rdr["cnt"] ?? 0);
                            commentCountMap[uid] = cnt;
                        }
                    }

                    string sqlTop = @"
                        SELECT uid, ten_tai_khoan, 
                               COUNT(*) as total_posts,
                               SUM(CASE WHEN LOWER(trang_thai) LIKE '%thành công%' OR LOWER(trang_thai) LIKE '%success%' THEN 1 ELSE 0 END) as tc,
                               SUM(CASE WHEN LOWER(trang_thai) NOT LIKE '%thành công%' AND LOWER(trang_thai) NOT LIKE '%success%' THEN 1 ELSE 0 END) as tb,
                               MAX(thoi_gian) as last_act
                        FROM lich_su_dang_bai
                        GROUP BY uid
                        ORDER BY total_posts DESC
                        LIMIT 100;";

                    using (var cmd = new SQLiteCommand(sqlTop, conn))
                    using (var rdr = cmd.ExecuteReader())
                    {
                        int rank = 1;
                        while (rdr.Read())
                        {
                            string uid = rdr["uid"]?.ToString() ?? "";
                            string name = rdr["ten_tai_khoan"]?.ToString() ?? "";
                            if (string.IsNullOrEmpty(name)) name = GetAccountNameByUid(uid);
                            int totalP = Convert.ToInt32(rdr["total_posts"] ?? 0);
                            int tc = Convert.ToInt32(rdr["tc"] ?? 0);
                            int tb = Convert.ToInt32(rdr["tb"] ?? 0);
                            double rate = totalP > 0 ? Math.Round((double)tc * 100.0 / totalP, 1) : 0;
                            int commentCnt = commentCountMap.ContainsKey(uid) ? commentCountMap[uid] : 0;
                            string lastAct = rdr["last_act"]?.ToString() ?? "";

                            dtTop.Rows.Add(rank++, uid, name, totalP, tc, tb, $"{rate}%", commentCnt, lastAct);
                        }
                    }
                    stats.TopAccountsTable = dtTop;
                }
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("GetDashboardStatistics error: " + ex.Message); } catch { }
            }
        }
        return stats;
    }

    #endregion
}

public class DashboardStatistics
{
    public int PostsToday { get; set; }
    public int PostsThisWeek { get; set; }
    public int PostsThisMonth { get; set; }
    public int PostsTotalAll { get; set; }

    public int PostsReels { get; set; }
    public int PostsStory { get; set; }
    public int PostsTuong { get; set; }
    public int PostsNhom { get; set; }
    public int PostsFanpage { get; set; }
    public int PostsOther { get; set; }

    public int PostsSuccess { get; set; }
    public int PostsFailed { get; set; }
    public int PostsPending { get; set; }
    public double PostSuccessRate => (PostsSuccess + PostsFailed + PostsPending) > 0
        ? Math.Round((double)PostsSuccess * 100.0 / (PostsSuccess + PostsFailed + PostsPending), 1)
        : 100.0;

    public int CommentsToday { get; set; }
    public int CommentsThisWeek { get; set; }
    public int CommentsThisMonth { get; set; }
    public int CommentsTotalAll { get; set; }
    public int CommentsSuccess { get; set; }
    public int CommentsFailed { get; set; }
    public double CommentSuccessRate => (CommentsSuccess + CommentsFailed) > 0
        ? Math.Round((double)CommentsSuccess * 100.0 / (CommentsSuccess + CommentsFailed), 1)
        : 100.0;

    public DataTable TopAccountsTable { get; set; } = new DataTable();
}
