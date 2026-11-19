using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class AccountGroupItem
{
    public int Id { get; set; }
    public string AccountUid { get; set; } = "";
    public string AccountName { get; set; } = "";
    public string GroupId { get; set; } = "";
    public string GroupName { get; set; } = "";
    public string GroupAvatar { get; set; } = "";
    public string GroupLink { get; set; } = "";
    public string MemberCount { get; set; } = "";
    public string Privacy { get; set; } = "Công khai";
    public string PostApproval { get; set; } = "Không duyệt bài";
    public string Status { get; set; } = "Đã tham gia";
    public string UpdatedAt { get; set; } = "";
}

public class AccountSimpleInfo
{
    public string Id { get; set; } = "";
    public string Uid { get; set; } = "";
    public string Name { get; set; } = "";
    public string Token { get; set; } = "";
    public string Cookie { get; set; } = "";
    public string Proxy { get; set; } = "";
    public string UserAgent { get; set; } = "";
}

public static class AccountGroupDB
{
    private static readonly object _dbLock = new object();
    private static bool _initialized = false;

    public static string GetDbConnectionString(string dbPath)
    {
        return $"Data Source={dbPath};Version=3;Journal Mode=WAL;BusyTimeout=10000;Pooling=True;";
    }

    public static List<string> GetAllTargetDbPaths()
    {
        List<string> paths = new List<string>();
        List<string> candidateDirs = new List<string>();

        try
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(appDir) && !candidateDirs.Contains(appDir)) candidateDirs.Add(appDir);
        }
        catch { }

        try
        {
            string startup = System.Windows.Forms.Application.StartupPath;
            if (!string.IsNullOrEmpty(startup) && !candidateDirs.Contains(startup)) candidateDirs.Add(startup);
        }
        catch { }

        try
        {
            if (!string.IsNullOrEmpty(Base.DE249839) && !candidateDirs.Contains(Base.DE249839)) candidateDirs.Add(Base.DE249839);
        }
        catch { }

        string[] dbNames = new string[] { "db_maxcare.sqlite", "db_lushcare.sqlite" };

        foreach (var dir in candidateDirs)
        {
            foreach (var name in dbNames)
            {
                string p1 = Path.Combine(dir, "database", name);
                if (!paths.Contains(p1)) paths.Add(p1);

                string p2 = Path.Combine(dir, name);
                if (!paths.Contains(p2)) paths.Add(p2);
            }
        }

        return paths;
    }

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
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "db_maxcare.sqlite");
    }

    public static void EnsureDatabase()
    {
        lock (_dbLock)
        {
            if (_initialized) return;

            string createTableSql = @"
                CREATE TABLE IF NOT EXISTS account_groups (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    account_uid TEXT,
                    account_name TEXT,
                    group_id TEXT,
                    group_name TEXT,
                    group_avatar TEXT,
                    group_link TEXT,
                    member_count TEXT,
                    privacy TEXT,
                    post_approval TEXT,
                    status TEXT,
                    updated_at TEXT,
                    UNIQUE(account_uid, group_id) ON CONFLICT REPLACE
                );
                CREATE INDEX IF NOT EXISTS idx_account_groups_uid ON account_groups(account_uid);
                CREATE INDEX IF NOT EXISTS idx_account_groups_gid ON account_groups(group_id);
            ";

            var paths = GetAllTargetDbPaths();
            foreach (var p in paths)
            {
                try
                {
                    string dir = Path.GetDirectoryName(p);
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    using (var conn = new SQLiteConnection(GetDbConnectionString(p)))
                    {
                        conn.Open();
                        using (var pragmaCmd = new SQLiteCommand("PRAGMA journal_mode=WAL; PRAGMA busy_timeout=10000; PRAGMA synchronous=NORMAL;", conn))
                        {
                            pragmaCmd.ExecuteNonQuery();
                        }
                        using (var cmd = new SQLiteCommand(createTableSql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            }

            _initialized = true;
        }
    }

    public static List<AccountSimpleInfo> GetAllAccounts()
    {
        EnsureDatabase();
        List<AccountSimpleInfo> list = new List<AccountSimpleInfo>();
        string dbPath = GetPrimaryDbPath();

        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetDbConnectionString(dbPath)))
                {
                    conn.Open();
                    string sql = "SELECT id, uid, name, token, cookie1, proxy, useragent FROM accounts WHERE active=1 ORDER BY name ASC, uid ASC";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new AccountSimpleInfo
                            {
                                Id = reader["id"]?.ToString() ?? "",
                                Uid = reader["uid"]?.ToString() ?? "",
                                Name = reader["name"]?.ToString() ?? "",
                                Token = reader["token"]?.ToString() ?? "",
                                Cookie = reader["cookie1"]?.ToString() ?? "",
                                Proxy = reader["proxy"]?.ToString() ?? "",
                                UserAgent = reader["useragent"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            catch { }
        }

        return list;
    }

    public static AccountSimpleInfo GetAccountByUid(string uid)
    {
        EnsureDatabase();
        if (string.IsNullOrEmpty(uid)) return null;
        string dbPath = GetPrimaryDbPath();

        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetDbConnectionString(dbPath)))
                {
                    conn.Open();
                    string sql = "SELECT id, uid, name, token, cookie1, proxy, useragent FROM accounts WHERE uid=@uid LIMIT 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", uid);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountSimpleInfo
                                {
                                    Id = reader["id"]?.ToString() ?? "",
                                    Uid = reader["uid"]?.ToString() ?? "",
                                    Name = reader["name"]?.ToString() ?? "",
                                    Token = reader["token"]?.ToString() ?? "",
                                    Cookie = reader["cookie1"]?.ToString() ?? "",
                                    Proxy = reader["proxy"]?.ToString() ?? "",
                                    UserAgent = reader["useragent"]?.ToString() ?? ""
                                };
                            }
                        }
                    }
                }
            }
            catch { }
        }

        return null;
    }

    public static DataTable GetGroupsDataTable(string accountUid = null, string filterType = "Tất cả", string search = null)
    {
        EnsureDatabase();
        DataTable dt = new DataTable();
        string dbPath = GetPrimaryDbPath();

        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetDbConnectionString(dbPath)))
                {
                    conn.Open();
                    List<string> whereClauses = new List<string>();
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();

                    if (!string.IsNullOrEmpty(accountUid) && accountUid != "all" && accountUid != "[Tất cả]")
                    {
                        whereClauses.Add("account_uid = @account_uid");
                        parameters.Add(new SQLiteParameter("@account_uid", accountUid));
                    }

                    if (!string.IsNullOrEmpty(filterType) && filterType != "Tất cả" && filterType != "All")
                    {
                        if (filterType.IndexOf("tự do", StringComparison.OrdinalIgnoreCase) >= 0 || filterType.IndexOf("Không duyệt", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            whereClauses.Add("(post_approval LIKE '%tự do%' OR post_approval LIKE '%Không duyệt%')");
                        }
                        else if (filterType.IndexOf("Có duyệt", StringComparison.OrdinalIgnoreCase) >= 0 || filterType.IndexOf("Kiểm duyệt", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            whereClauses.Add("post_approval LIKE '%Có duyệt%'");
                        }
                        else if (filterType.IndexOf("Công khai", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            whereClauses.Add("privacy LIKE '%Công khai%'");
                        }
                        else if (filterType.IndexOf("Kín", StringComparison.OrdinalIgnoreCase) >= 0 || filterType.IndexOf("Riêng tư", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            whereClauses.Add("(privacy LIKE '%Kín%' OR privacy LIKE '%Riêng tư%')");
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        whereClauses.Add("(group_name LIKE @search OR group_id LIKE @search)");
                        parameters.Add(new SQLiteParameter("@search", "%" + search.Trim() + "%"));
                    }

                    string sql = "SELECT id, account_uid, account_name, group_id, group_name, group_avatar, group_link, member_count, privacy, post_approval, status, updated_at FROM account_groups";
                    if (whereClauses.Count > 0)
                    {
                        sql += " WHERE " + string.Join(" AND ", whereClauses);
                    }
                    sql += " ORDER BY id DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        foreach (var p in parameters) cmd.Parameters.Add(p);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch { }
        }

        return dt;
    }

    public static int SaveGroup(AccountGroupItem item)
    {
        if (item == null) return 0;
        return SaveGroups(new List<AccountGroupItem> { item });
    }

    public static int SaveGroups(List<AccountGroupItem> items)
    {
        EnsureDatabase();
        if (items == null || items.Count == 0) return 0;

        int affected = 0;
        var paths = GetAllTargetDbPaths();

        lock (_dbLock)
        {
            foreach (var path in paths)
            {
                if (!File.Exists(path)) continue;

                try
                {
                    using (var conn = new SQLiteConnection(GetDbConnectionString(path)))
                    {
                        conn.Open();
                        using (var tx = conn.BeginTransaction())
                        {
                            string sql = @"
                                INSERT INTO account_groups (
                                    account_uid, account_name, group_id, group_name, group_avatar,
                                    group_link, member_count, privacy, post_approval, status, updated_at
                                ) VALUES (
                                    @account_uid, @account_name, @group_id, @group_name, @group_avatar,
                                    @group_link, @member_count, @privacy, @post_approval, @status, @updated_at
                                )
                                ON CONFLICT(account_uid, group_id) DO UPDATE SET
                                    account_name = excluded.account_name,
                                    group_name = excluded.group_name,
                                    group_avatar = CASE WHEN excluded.group_avatar <> '' THEN excluded.group_avatar ELSE account_groups.group_avatar END,
                                    group_link = excluded.group_link,
                                    member_count = excluded.member_count,
                                    privacy = excluded.privacy,
                                    post_approval = excluded.post_approval,
                                    status = excluded.status,
                                    updated_at = excluded.updated_at;
                            ";

                            using (var cmd = new SQLiteCommand(sql, conn, tx))
                            {
                                var pAccountUid = cmd.Parameters.Add("@account_uid", DbType.String);
                                var pAccountName = cmd.Parameters.Add("@account_name", DbType.String);
                                var pGroupId = cmd.Parameters.Add("@group_id", DbType.String);
                                var pGroupName = cmd.Parameters.Add("@group_name", DbType.String);
                                var pGroupAvatar = cmd.Parameters.Add("@group_avatar", DbType.String);
                                var pGroupLink = cmd.Parameters.Add("@group_link", DbType.String);
                                var pMemberCount = cmd.Parameters.Add("@member_count", DbType.String);
                                var pPrivacy = cmd.Parameters.Add("@privacy", DbType.String);
                                var pPostApproval = cmd.Parameters.Add("@post_approval", DbType.String);
                                var pStatus = cmd.Parameters.Add("@status", DbType.String);
                                var pUpdatedAt = cmd.Parameters.Add("@updated_at", DbType.String);

                                foreach (var it in items)
                                {
                                    if (string.IsNullOrWhiteSpace(it.GroupId)) continue;

                                    pAccountUid.Value = it.AccountUid ?? "";
                                    pAccountName.Value = it.AccountName ?? "";
                                    pGroupId.Value = it.GroupId ?? "";
                                    pGroupName.Value = it.GroupName ?? ("Nhóm " + it.GroupId);
                                    pGroupAvatar.Value = it.GroupAvatar ?? "";
                                    pGroupLink.Value = string.IsNullOrEmpty(it.GroupLink) ? $"https://www.facebook.com/groups/{it.GroupId}/" : it.GroupLink;
                                    pMemberCount.Value = it.MemberCount ?? "";
                                    pPrivacy.Value = string.IsNullOrEmpty(it.Privacy) ? "Công khai" : it.Privacy;
                                    pPostApproval.Value = string.IsNullOrEmpty(it.PostApproval) ? "Không duyệt bài" : it.PostApproval;
                                    pStatus.Value = string.IsNullOrEmpty(it.Status) ? "Đã tham gia" : it.Status;
                                    pUpdatedAt.Value = string.IsNullOrEmpty(it.UpdatedAt) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : it.UpdatedAt;

                                    affected += cmd.ExecuteNonQuery();
                                }
                            }
                            tx.Commit();
                        }
                    }
                }
                catch { }
            }
        }

        return affected;
    }

    public static int DeleteGroupsByIds(List<int> ids)
    {
        EnsureDatabase();
        if (ids == null || ids.Count == 0) return 0;

        int affected = 0;
        var paths = GetAllTargetDbPaths();

        lock (_dbLock)
        {
            string idList = string.Join(",", ids);
            string sql = $"DELETE FROM account_groups WHERE id IN ({idList})";

            foreach (var path in paths)
            {
                if (!File.Exists(path)) continue;
                try
                {
                    using (var conn = new SQLiteConnection(GetDbConnectionString(path)))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            affected += cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            }
        }

        return affected;
    }

    public static int UpdateGroupStatus(string accountUid, string groupId, string newStatus)
    {
        EnsureDatabase();
        if (string.IsNullOrEmpty(groupId)) return 0;

        int affected = 0;
        var paths = GetAllTargetDbPaths();

        lock (_dbLock)
        {
            foreach (var path in paths)
            {
                if (!File.Exists(path)) continue;
                try
                {
                    using (var conn = new SQLiteConnection(GetDbConnectionString(path)))
                    {
                        conn.Open();
                        string sql = "UPDATE account_groups SET status=@status, updated_at=@time WHERE group_id=@gid";
                        if (!string.IsNullOrEmpty(accountUid)) sql += " AND account_uid=@uid";

                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@gid", groupId);
                            if (!string.IsNullOrEmpty(accountUid)) cmd.Parameters.AddWithValue("@uid", accountUid);
                            affected += cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            }
        }

        return affected;
    }

    public static long ParseMemberCountString(string countStr)
    {
        if (string.IsNullOrWhiteSpace(countStr)) return 0;
        try
        {
            countStr = countStr.Trim().ToLowerInvariant();
            countStr = countStr.Replace("thành viên", "").Replace("tv", "").Replace("members", "").Replace("member", "").Trim();

            bool isMillion = countStr.EndsWith("m") || countStr.EndsWith("tr") || countStr.EndsWith("triệu");
            bool isThousand = countStr.EndsWith("k") || countStr.EndsWith("n") || countStr.EndsWith("nghìn") || countStr.EndsWith("ngàn");

            countStr = Regex.Replace(countStr, @"[^\d.,]", "").Trim();
            if (string.IsNullOrEmpty(countStr)) return 0;

            if (countStr.Contains(",") && countStr.Contains("."))
            {
                if (countStr.LastIndexOf(",") > countStr.LastIndexOf("."))
                {
                    countStr = countStr.Replace(".", "").Replace(",", ".");
                }
                else
                {
                    countStr = countStr.Replace(",", "");
                }
            }
            else if (countStr.Contains(","))
            {
                if (isMillion || isThousand)
                {
                    countStr = countStr.Replace(",", ".");
                }
                else
                {
                    int idx = countStr.IndexOf(',');
                    if (countStr.Length - idx - 1 == 3)
                    {
                        countStr = countStr.Replace(",", "");
                    }
                    else
                    {
                        countStr = countStr.Replace(",", ".");
                    }
                }
            }
            else if (countStr.Contains("."))
            {
                if (isMillion || isThousand)
                {
                    // keep dot as decimal
                }
                else
                {
                    int idx = countStr.IndexOf('.');
                    if (countStr.Length - idx - 1 == 3)
                    {
                        countStr = countStr.Replace(".", "");
                    }
                }
            }

            if (double.TryParse(countStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double num))
            {
                if (isMillion) num *= 1000000;
                else if (isThousand) num *= 1000;
                return (long)num;
            }
        }
        catch { }
        return 0;
    }

    public static long GetGroupMemberCount(string groupItemOrId, string accountUid = null)
    {
        if (string.IsNullOrWhiteSpace(groupItemOrId)) return 0;
        EnsureDatabase();

        string rawItem = groupItemOrId.Trim();
        string cleanGroupId = rawItem;
        if (cleanGroupId.Contains("|"))
        {
            cleanGroupId = cleanGroupId.Split('|')[0].Trim();
        }
        if (cleanGroupId.Contains("groups/"))
        {
            var match = Regex.Match(cleanGroupId, @"groups/([^/?#]+)");
            if (match.Success) cleanGroupId = match.Groups[1].Value;
        }
        cleanGroupId = cleanGroupId.Trim('/').Split('/').Last().Trim();

        // 1. Tra cứu số lượng thành viên từ bảng CSDL account_groups nếu đã có dữ liệu quét trước đó
        string dbPath = GetPrimaryDbPath();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetDbConnectionString(dbPath)))
                {
                    conn.Open();
                    string sql = "SELECT member_count FROM account_groups WHERE group_id=@gid";
                    if (!string.IsNullOrEmpty(accountUid)) sql += " AND account_uid=@uid";
                    sql += " ORDER BY id DESC LIMIT 1";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@gid", cleanGroupId);
                        if (!string.IsNullOrEmpty(accountUid)) cmd.Parameters.AddWithValue("@uid", accountUid);
                        object val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            string dbMemStr = val.ToString();
                            long parsed = ParseMemberCountString(dbMemStr);
                            if (parsed > 0) return parsed;
                        }
                    }
                }
            }
            catch { }
        }

        // 2. Bóc tách chuỗi member count từ format group scan nếu không có trong DB
        if (rawItem.Contains("|"))
        {
            string[] parts = rawItem.Split('|');
            for (int i = parts.Length - 1; i >= 1; i--)
            {
                string p = parts[i].Trim();
                if (p.Equals("true", StringComparison.OrdinalIgnoreCase) || p.Equals("false", StringComparison.OrdinalIgnoreCase)) continue;
                long parsed = ParseMemberCountString(p);
                if (parsed > 0) return parsed;
            }
        }

        return 0;
    }

    public static bool IsGroupPendingApproval(string groupId)
    {
        if (string.IsNullOrWhiteSpace(groupId)) return false;
        EnsureDatabase();
        string cleanGid = groupId.Trim();
        if (cleanGid.Contains("|")) cleanGid = cleanGid.Split('|')[0].Trim();
        if (cleanGid.Contains("groups/"))
        {
            var match = Regex.Match(cleanGid, @"groups/([^/?#]+)");
            if (match.Success) cleanGid = match.Groups[1].Value;
        }
        cleanGid = cleanGid.Trim('/').Split('/').Last().Trim();

        string dbPath = GetPrimaryDbPath();
        lock (_dbLock)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetDbConnectionString(dbPath)))
                {
                    conn.Open();
                    string sql = "SELECT post_approval FROM account_groups WHERE group_id=@gid ORDER BY id DESC LIMIT 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@gid", cleanGid);
                        object val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            string app = val.ToString().ToLower();
                            if (app.Contains("có duyệt") || app.Contains("kiểm duyệt") || app.Contains("approval") || app.Contains("duyệt bài"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        return false;
    }

    public static string ExtractGroupId(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";
        string s = input.Trim();
        if (s.Contains("|")) s = s.Split('|')[0].Trim();
        if (s.Contains("groups/"))
        {
            var match = Regex.Match(s, @"groups/([^/?#]+)");
            if (match.Success) s = match.Groups[1].Value.Trim();
        }
        s = s.Trim('/').Split('/').Last().Trim();
        if (s.Contains("?")) s = s.Split('?')[0].Trim();
        if (s.Contains("#")) s = s.Split('#')[0].Trim();
        return s;
    }

    public static int UpdateGroupApproval(string groupId, string approvalStatus, string accountUid = null)
    {
        if (string.IsNullOrWhiteSpace(groupId)) return 0;
        EnsureDatabase();
        string cleanGid = ExtractGroupId(groupId);
        if (string.IsNullOrEmpty(cleanGid)) return 0;

        int affected = 0;
        var paths = GetAllTargetDbPaths();
        lock (_dbLock)
        {
            foreach (var path in paths)
            {
                if (!File.Exists(path)) continue;
                try
                {
                    using (var conn = new SQLiteConnection(GetDbConnectionString(path)))
                    {
                        conn.Open();
                        string sql = "UPDATE account_groups SET post_approval=@approval, updated_at=@time WHERE group_id=@gid";
                        if (!string.IsNullOrEmpty(accountUid)) sql += " AND account_uid=@uid";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@approval", approvalStatus ?? "Không duyệt bài");
                            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@gid", cleanGid);
                            if (!string.IsNullOrEmpty(accountUid)) cmd.Parameters.AddWithValue("@uid", accountUid);
                            affected += cmd.ExecuteNonQuery();
                        }

                        if (affected == 0)
                        {
                            string insertSql = "INSERT INTO account_groups (account_uid, group_id, group_name, post_approval, member_count, status, updated_at) " +
                                              "VALUES (@uid, @gid, @name, @approval, 0, 'Đã tham gia', @time)";
                            using (var cmdIns = new SQLiteCommand(insertSql, conn))
                            {
                                cmdIns.Parameters.AddWithValue("@uid", accountUid ?? "");
                                cmdIns.Parameters.AddWithValue("@gid", cleanGid);
                                cmdIns.Parameters.AddWithValue("@name", cleanGid);
                                cmdIns.Parameters.AddWithValue("@approval", approvalStatus ?? "Không duyệt bài");
                                cmdIns.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdIns.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch { }
            }
        }
        return affected;
    }

    private static readonly object _postedGroupsLock = new object();

    public static bool IsGroupPostedToday(string accountUid, string groupId)
    {
        if (string.IsNullOrWhiteSpace(groupId)) return false;
        try
        {
            string cleanGid = groupId.Trim();
            if (cleanGid.Contains("|")) cleanGid = cleanGid.Split('|')[0].Trim();
            if (cleanGid.Contains("groups/"))
            {
                var match = Regex.Match(cleanGid, @"groups/([^/?#]+)");
                if (match.Success) cleanGid = match.Groups[1].Value;
            }
            cleanGid = cleanGid.Trim('/').Split('/').Last().Trim();

            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(dir, "output", "posted_groups.txt");
            if (!File.Exists(filePath)) return false;

            string today = DateTime.Now.ToString("yyyy-MM-dd");
            lock (_postedGroupsLock)
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length >= 2)
                    {
                        string g = parts[1].Trim();
                        if (g.Equals(cleanGid, StringComparison.OrdinalIgnoreCase))
                        {
                            if (parts.Length >= 3)
                            {
                                string timeStr = parts[2].Trim();
                                if (timeStr.StartsWith(today)) return true;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        catch { }
        return false;
    }

    public static void RecordPostedGroup(string accountUid, string groupId)
    {
        if (string.IsNullOrWhiteSpace(groupId)) return;
        try
        {
            string cleanGid = groupId.Trim();
            if (cleanGid.Contains("|")) cleanGid = cleanGid.Split('|')[0].Trim();
            if (cleanGid.Contains("groups/"))
            {
                var match = Regex.Match(cleanGid, @"groups/([^/?#]+)");
                if (match.Success) cleanGid = match.Groups[1].Value;
            }
            cleanGid = cleanGid.Trim('/').Split('/').Last().Trim();

            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string outDir = Path.Combine(dir, "output");
            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);
            string filePath = Path.Combine(outDir, "posted_groups.txt");

            string record = $"{accountUid ?? ""}|{cleanGid}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            lock (_postedGroupsLock)
            {
                File.AppendAllText(filePath, record + Environment.NewLine);
            }
        }
        catch { }
    }
}
