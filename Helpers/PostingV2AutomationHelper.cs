using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

/// <summary>
/// PostingV2AutomationHelper: Trình hỗ trợ tự động hóa Đăng bài V2 (HDDangBaiV2)
/// Tách biệt module hóa hoàn toàn, hỗ trợ:
/// 1. Đăng lên Tường cá nhân (Personal Wall)
/// 2. Đăng vào Nhóm (Facebook Groups)
/// 3. Đăng lên Fanpage Profile thông minh (Tự động phát hiện và đăng lên Page có sẵn)
/// 4. Xuất log riêng biệt theo từng tài khoản/Profile (logs/posts/{uid}.txt & output/posts/{uid}.txt)
/// 5. Đồng bộ vào SQLite lịch sử đăng bài (KichBanThongKeDB) để hiển thị trên giao diện
/// </summary>
public static class PostingV2AutomationHelper
{
    private static readonly object _fileLock = new object();
    private static readonly Random _rd = new Random();

    #region 1. Log System per Profile/UID

    /// <summary>
    /// Ghi log kết quả đăng bài chi tiết ra file riêng biệt theo UID tài khoản
    /// Format: yyyy-MM-dd HH:mm:ss | UID | Target (Wall/Group/Page) | TargetId | Content snippet | PostUrl | Status
    /// </summary>
    public static void WritePostLog(string uid, string targetType, string targetId, string content, string postUrl, string status)
    {
        if (string.IsNullOrEmpty(uid)) uid = "unknown_uid";
        string timeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Rút gọn nội dung (snippet) tránh làm gãy dòng log
        string snippet = "";
        if (!string.IsNullOrEmpty(content))
        {
            snippet = content.Replace("\r", " ").Replace("\n", " ").Trim();
            if (snippet.Length > 80)
            {
                snippet = snippet.Substring(0, 80) + "...";
            }
        }

        string logLine = $"{timeStr} | {uid} | {targetType} | {targetId} | {snippet} | {postUrl} | {status}";

        lock (_fileLock)
        {
            try
            {
                // 1. Thư mục logs/posts/
                string baseDir = Commom.smethod_95();
                string logFolder = Path.Combine(baseDir, "logs", "posts");
                if (!Directory.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }
                string logFilePath = Path.Combine(logFolder, $"{uid}.txt");
                File.AppendAllText(logFilePath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("WritePostLog logs/posts error: " + ex.Message); } catch { }
            }

            try
            {
                // 2. Thư mục output/posts/
                string outFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output", "posts");
                if (!Directory.Exists(outFolder))
                {
                    Directory.CreateDirectory(outFolder);
                }
                string outFilePath = Path.Combine(outFolder, $"{uid}.txt");
                File.AppendAllText(outFilePath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                try { Commom.smethod_49("WritePostLog output/posts error: " + ex.Message); } catch { }
            }
        }
    }

    #endregion

    #region 2. Spintax & Content Helpers

    /// <summary>
    /// Xử lý định dạng Spintax {nội dung 1|nội dung 2|nội dung 3} đệ quy
    /// </summary>
    public static string ResolveSpintax(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";

        var regex = new Regex(@"\{([^{}]+)\}");
        while (regex.IsMatch(text))
        {
            text = regex.Replace(text, match =>
            {
                string[] options = match.Groups[1].Value.Split('|');
                return options[_rd.Next(0, options.Length)];
            });
        }
        return text;
    }

    /// <summary>
    /// Chuẩn bị nội dung văn bản và ảnh cho bài đăng V2
    /// </summary>
    public static (string content, bool isUseBackground, List<string> lstPathImage) PreparePostContentV2(
        GClass4 gclass4_0,
        string uid,
        string actionId,
        Dictionary<string, List<string>> dictContent = null,
        Dictionary<string, List<string>> dictImages = null)
    {
        bool flagVanBan = gclass4_0.method_3("ckbVanBan");
        bool flagUseBackground = gclass4_0.method_3("ckbUseBackground");
        bool flagAnh = gclass4_0.method_3("ckbAnh");
        int nudSoLuongAnhFrom = gclass4_0.method_2("nudSoLuongAnhFrom", 1);
        int nudSoLuongAnhTo = gclass4_0.method_2("nudSoLuongAnhTo", 1);
        bool flagUseAvatar = gclass4_0.method_3("ckbUseAvatar");
        bool flagXoaAnh = gclass4_0.method_3("ckbXoaAnh");
        bool flagThemVaoCuoi = gclass4_0.method_3("ckbThemVaoCuoiNoiDung");
        string txtThemVaoCuoi = gclass4_0.BDB80B23("txtNoiDungThemVaoCuoi");
        bool flagXoaHashtag = gclass4_0.method_3("ckbXoaHashtag");

        string content = "";

        // 1. Lấy nội dung bài viết
        if (flagVanBan)
        {
            if (dictContent != null && dictContent.ContainsKey(actionId) && dictContent[actionId].Count > 0)
            {
                lock (dictContent)
                {
                    if (dictContent[actionId].Count > 0)
                    {
                        int idx = _rd.Next(0, dictContent[actionId].Count);
                        content = dictContent[actionId][idx];
                    }
                }
            }
            else
            {
                string rawText = gclass4_0.BDB80B23("txtNoiDung");
                if (!string.IsNullOrEmpty(rawText))
                {
                    int typeNganCach = gclass4_0.method_2("typeNganCach", 0);
                    if (typeNganCach == 0) // Mỗi dòng là 1 nội dung
                    {
                        var lines = rawText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        if (lines.Length > 0)
                        {
                            content = lines[_rd.Next(0, lines.Length)];
                        }
                    }
                    else // Các nội dung ngăn cách bằng [---]
                    {
                        var parts = rawText.Split(new[] { "[---]" }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 0)
                        {
                            content = parts[_rd.Next(0, parts.Length)].Trim();
                        }
                    }
                }
            }

            // Xử lý Spintax
            content = ResolveSpintax(content);

            // Nối thêm vào cuối nội dung nếu cấu hình
            if (flagThemVaoCuoi && !string.IsNullOrWhiteSpace(txtThemVaoCuoi))
            {
                string suffix = ResolveSpintax(txtThemVaoCuoi);
                content = (content + Environment.NewLine + suffix).Trim();
            }

            // Xóa Hashtag nếu cấu hình
            if (flagXoaHashtag && !string.IsNullOrEmpty(content))
            {
                content = Regex.Replace(content, @"#\w+", "").Trim();
            }
        }

        // 2. Lấy danh sách ảnh
        List<string> lstImages = new List<string>();
        if (flagAnh)
        {
            if (flagUseAvatar)
            {
                string avatarPath = Path.Combine(Commom.smethod_95(), "avatar", $"{uid}.png");
                if (File.Exists(avatarPath))
                {
                    lstImages.Add(avatarPath);
                }
            }
            else
            {
                string folderAnh = gclass4_0.BDB80B23("txtPathAnh");
                if (!string.IsNullOrEmpty(folderAnh) && Directory.Exists(folderAnh))
                {
                    List<string> availableImages = null;
                    if (dictImages != null && dictImages.ContainsKey(actionId))
                    {
                        availableImages = dictImages[actionId];
                    }
                    else
                    {
                        availableImages = Commom.smethod_76(folderAnh);
                    }

                    if (availableImages != null && availableImages.Count > 0)
                    {
                        int targetImgCount = Commom.BF833227(nudSoLuongAnhFrom, nudSoLuongAnhTo);
                        if (targetImgCount < 1) targetImgCount = 1;

                        lock (availableImages)
                        {
                            for (int i = 0; i < targetImgCount && availableImages.Count > 0; i++)
                            {
                                int pickIdx = _rd.Next(0, availableImages.Count);
                                string chosenImg = availableImages[pickIdx];
                                if (flagXoaAnh)
                                {
                                    availableImages.RemoveAt(pickIdx);
                                }

                                if (File.Exists(chosenImg))
                                {
                                    lstImages.Add(chosenImg);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Nếu có ảnh thì không dùng Background màu
        if (lstImages.Count > 0)
        {
            flagUseBackground = false;
        }

        return (content, flagUseBackground, lstImages);
    }

    #endregion

    #region 3. Smart Fanpage Detection

    /// <summary>
    /// Cơ chế phát hiện Fanpage thông minh cho tài khoản:
    /// - Gọi GraphQL / GetPagePro5 (chrome.BE0C6B9C())
    /// - Quét DOM danh sách Pages quản lý qua method_14 trên URL your_pages
    /// - Trả về danh sách Page ID / URL quản lý của tài khoản
    /// </summary>
    public static List<string> DetectFanpages(Chrome chrome, Action<string> logCallback = null)
    {
        List<string> lstPages = new List<string>();
        if (chrome == null || chrome.CD930D04()) return lstPages;

        // Chiến lược 1: Gọi BE0C6B9C (GetPagePro5 / GraphQL)
        try
        {
            logCallback?.Invoke("Quét danh sách Page qua Graph/Pro5...");
            List<string> pro5Pages = chrome.BE0C6B9C();
            if (pro5Pages != null && pro5Pages.Count > 0)
            {
                foreach (var p in pro5Pages)
                {
                    string clean = p.Trim();
                    if (!string.IsNullOrEmpty(clean) && !lstPages.Contains(clean))
                    {
                        lstPages.Add(clean);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("DetectFanpages Pro5 error: " + ex.Message); } catch { }
        }

        if (lstPages.Count > 0)
        {
            return lstPages;
        }

        // Chiến lược 2: Điều hướng trang quản lý your_pages và quét DOM JS
        try
        {
            logCallback?.Invoke("Quét danh sách Page qua giao diện Facebook your_pages...");
            chrome.method_12("https://www.facebook.com/pages/?category=your_pages");
            chrome.F8091028(2.0);

            string script = @"try {
                var links = Array.from(document.querySelectorAll('a[href*=""/latest/""], a[href*=""facebook.com/""], a[href*=""/pages/""]'));
                var pids = [];
                var seen = new Set();
                for (var a of links) {
                    var href = a.getAttribute('href') || '';
                    var m = href.match(/(?:asset_id=|[0-9]{8,})/);
                    if (m && !seen.has(m[0])) {
                        seen.add(m[0]);
                        pids.push(m[0]);
                    }
                }
                return JSON.stringify(pids);
            } catch(e) {
                return '[]';
            }";

            string jsonPages = chrome.method_14(script)?.ToString();
            if (!string.IsNullOrEmpty(jsonPages) && jsonPages.StartsWith("["))
            {
                var jArr = JArray.Parse(jsonPages);
                foreach (var item in jArr)
                {
                    string pid = item?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(pid) && !lstPages.Contains(pid))
                    {
                        lstPages.Add(pid);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("DetectFanpages your_pages DOM error: " + ex.Message); } catch { }
        }

        return lstPages;
    }

    #endregion

    #region 4. Main Execution Engine (HDDangBaiV2)

    /// <summary>
    /// Phương thức thực thi toàn diện Đăng bài V2 (HDDangBaiV2):
    /// Hỗ trợ Đăng Tường, Đăng Nhóm, Đăng Fanpage Thông Minh, và Ghi Log Riêng Biệt Theo UID.
    /// </summary>
    public static int ExecuteDangBaiV2(
        int int_3,
        string string_1,
        Chrome chrome,
        GClass4 gclass4_0,
        string text29,
        string text28,
        fMain form,
        Dictionary<string, List<string>> dictionary_13 = null,
        Dictionary<string, List<string>> dictionary_14 = null,
        Dictionary<string, List<string>> dictionary_19 = null,
        Dictionary<string, List<string>> dictionary_20 = null,
        Dictionary<string, List<string>> dictDuplicates = null)
    {
        if (chrome == null || chrome.CD930D04()) return -2;
        if (Base.smethod_5()) return 0;

        string uid = chrome.B4208531;
        if (string.IsNullOrEmpty(uid))
        {
            try { uid = form.F6061E95(int_3, "cId"); } catch { }
        }
        if (string.IsNullOrEmpty(uid)) uid = "unknown_uid";

        // Cấu hình thời gian delay
        int nudDelayFrom = gclass4_0.method_2("nudDelayFrom", 3);
        int nudDelayTo = gclass4_0.method_2("nudDelayTo", 5);

        // Cấu hình đăng tường
        bool ckbDangBaiLenTuong = gclass4_0.method_3("ckbDangBaiLenTuong");
        int nudCountWallFrom = gclass4_0.method_2("nudCountWallFrom", 1);
        int nudCountWallTo = gclass4_0.method_2("nudCountWallTo", 1);

        // Cấu hình đăng nhóm
        bool ckbDangBaiLenNhom = gclass4_0.method_3("ckbDangBaiLenNhom");
        int nudCountGroupFrom = gclass4_0.method_2("nudCountGroupFrom", 1);
        int nudCountGroupTo = gclass4_0.method_2("nudCountGroupTo", 1);
        int typePost = gclass4_0.method_2("typePost", 0); // 0: random, 1: tự nhập
        List<string> lstNhomTuNhap = gclass4_0.method_1("lstNhomTuNhap");
        bool ckbChiDangNhomDaThamGia = gclass4_0.method_3("ckbChiDangNhomDaThamGia");
        bool ckbXoaNhomDaDang = gclass4_0.method_3("ckbXoaNhomDaDang");
        bool ckbOnlyDangNhomKhongKiemDuyet = gclass4_0.method_3("ckbOnlyDangNhomKhongKiemDuyet");
        bool ckbUuTienNhomNhieuThanhVien = gclass4_0.method_3("ckbUuTienNhomNhieuThanhVien");
        bool ckbKhongDangTrung = gclass4_0.method_3("ckbKhongDangTrung");

        // Cấu hình Fanpage thông minh
        bool ckbDangBaiLenPage = gclass4_0.method_3("ckbDangBaiLenPage");
        bool ckbTuDongDangPageCoSan = gclass4_0.method_3("ckbTuDongDangPageCoSan", false);
        int nudCountPageFrom = gclass4_0.method_2("nudCountPageFrom", 1);
        int nudCountPageTo = gclass4_0.method_2("nudCountPageTo", 1);

        // Tùy chọn khác
        bool ckbXoaAnh = gclass4_0.method_3("ckbXoaAnh");
        bool ckbXuatLogFileRieng = gclass4_0.method_3("ckbXuatLogFileRieng", true);
        bool ckbTuongTacBaiVietDaDang = gclass4_0.method_3("ckbTuongTacBaiVietDaDang");

        int totalSuccessPosts = 0;
        chrome.method_53();

        try
        {
            #region BƯỚC 1: ĐĂNG BÀI LÊN TƯỜNG CÁ NHÂN (WALL)
            if (ckbDangBaiLenTuong)
            {
                int targetWallCount = Commom.BF833227(nudCountWallFrom, nudCountWallTo);
                if (targetWallCount < 1) targetWallCount = 1;

                form.method_130(int_3, string_1 + Language.GetValue("Bắt đầu đăng bài lên tường") + $" (mục tiêu {targetWallCount} bài)...");

                for (int w = 0; w < targetWallCount; w++)
                {
                    if (chrome.CD930D04()) return -2;

                    form.method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng tường") + " ({0}/{1})...", w + 1, targetWallCount));

                    // Điều hướng tường cá nhân
                    int retryNav = 0;
                    bool navOk = false;
                    while (retryNav < 3 && !navOk)
                    {
                        retryNav++;
                        string wallUrl = (retryNav == 1) ? "https://www.facebook.com/profile.php" : "https://www.facebook.com/";
                        chrome.method_12(wallUrl, FC3A841F: true);
                        chrome.F8091028(2.0);
                        int statusNav = chrome.method_125();
                        if (!new List<int> { -3, -2, -1, 2 }.Contains(statusNav))
                        {
                            navOk = true;
                        }
                        else if (!chrome.method_124() && !chrome.D6BBEDA3())
                        {
                            string curr = chrome.GetURL().ToLower();
                            if (curr.Contains("facebook.com")) navOk = true;
                        }
                    }

                    if (!navOk)
                    {
                        form.method_130(int_3, string_1 + "Không thể truy cập tường cá nhân.");
                        break;
                    }

                    // Cuộn nhẹ giả lập người dùng
                    HumanScroll.ScrollNewsfeed(chrome, 250);
                    chrome.F8091028(1.0);

                    // Chuẩn bị nội dung và media
                    var (content, isUseBg, images) = PreparePostContentV2(gclass4_0, uid, text28, dictionary_19, dictionary_20);

                    // Đăng bài tường qua ExecuteDangBaiWWW (type 0 = Wall)
                    string postResult = chrome.method_106(0, "", content, isUseBg, images);

                    if (!string.IsNullOrEmpty(postResult))
                    {
                        totalSuccessPosts++;

                        if (ckbXoaAnh && images != null && images.Count > 0)
                        {
                            Commom.smethod_68(images);
                        }

                        // Ghi log riêng biệt UID
                        if (ckbXuatLogFileRieng)
                        {
                            WritePostLog(uid, "Wall", uid, content, postResult, "Thành công");
                        }

                        // Đồng bộ vào DB lịch sử đăng bài
                        try
                        {
                            KichBanThongKeDB.LogPost(uid, postResult, content, "Bài viết tường", "Thành công");
                        }
                        catch { }

                        // Ghi output chung
                        try
                        {
                            string outDir = Path.Combine(Commom.smethod_95(), "output");
                            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);
                            string fWall = Path.Combine(outDir, "postWall_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                            Commom.smethod_98(fWall, delegate
                            {
                                File.AppendAllText(fWall, uid + "|" + postResult + Environment.NewLine);
                            });
                        }
                        catch { }

                        string msgSuccess = postResult.StartsWith("http")
                            ? (Language.GetValue("Đã đăng tường: ") + postResult)
                            : string.Format(Language.GetValue("Đã đăng tường thành công ({0}/{1})!"), w + 1, targetWallCount);

                        form.method_130(int_3, string_1 + msgSuccess);

                        // Tương tác lại bài viết nếu cần
                        if (ckbTuongTacBaiVietDaDang && postResult.StartsWith("http") && !postResult.Contains("wall_post_"))
                        {
                            chrome.method_12(postResult);
                            chrome.F8091028(2.0);
                        }

                        if (w + 1 < targetWallCount)
                        {
                            form.method_131(int_3, string_1 + $"Đã đăng tường ({w + 1}/{targetWallCount}), đợi {{time}}s...", nudDelayFrom, nudDelayTo);
                        }
                    }
                    else
                    {
                        if (ckbXuatLogFileRieng)
                        {
                            WritePostLog(uid, "Wall", uid, content, "", "Thất bại");
                        }
                        form.method_130(int_3, string_1 + $"Đăng bài tường ({w + 1}/{targetWallCount}) thất bại!");
                        Commom.smethod_52(2.0);
                    }
                }
            }
            #endregion

            #region BƯỚC 2: ĐĂNG BÀI LÊN NHÓM (GROUPS)
            if (ckbDangBaiLenNhom)
            {
                if (chrome.CD930D04()) return -2;

                List<string> listGroups = new List<string>();
                if (typePost == 0 || (typePost == 1 && ckbChiDangNhomDaThamGia))
                {
                    form.method_130(int_3, string_1 + Language.GetValue("Quét danh sách nhóm...") + "...");
                    var scanned = chrome.method_56(ckbOnlyDangNhomKhongKiemDuyet);
                    if (scanned != null)
                    {
                        listGroups = ckbOnlyDangNhomKhongKiemDuyet
                            ? scanned.Where(g => g.Split('|').Last().ToLower() == "false").ToList()
                            : scanned.ToList();
                    }
                }

                if (typePost == 1)
                {
                    if (ckbChiDangNhomDaThamGia)
                    {
                        var targetGids = new HashSet<string>(lstNhomTuNhap.Select(x => AccountGroupDB.ExtractGroupId(x)).Where(x => !string.IsNullOrEmpty(x)), StringComparer.OrdinalIgnoreCase);
                        listGroups = listGroups.Where(g => targetGids.Contains(AccountGroupDB.ExtractGroupId(g))).ToList();
                    }
                    else
                    {
                        if (ckbXoaNhomDaDang && dictionary_13 != null && dictionary_13.ContainsKey(text28))
                        {
                            lock (dictionary_13)
                            {
                                listGroups = new List<string>(dictionary_13[text28]);
                            }
                        }
                        else
                        {
                            listGroups = new List<string>(lstNhomTuNhap);
                        }
                    }
                }

                // Lọc nhóm chờ duyệt
                if (ckbOnlyDangNhomKhongKiemDuyet && listGroups.Count > 0)
                {
                    listGroups = listGroups.Where(g => !AccountGroupDB.IsGroupPendingApproval(AccountGroupDB.ExtractGroupId(g))).ToList();
                }

                // Sắp xếp ưu tiên thành viên hoặc xáo trộn ngẫu nhiên
                if (ckbUuTienNhomNhieuThanhVien)
                {
                    listGroups = listGroups.OrderByDescending(g => AccountGroupDB.GetGroupMemberCount(g, uid)).ToList();
                }
                else
                {
                    listGroups = listGroups.OrderBy(x => Guid.NewGuid()).ToList();
                }

                int targetGroupCount = Commom.BF833227(nudCountGroupFrom, nudCountGroupTo);
                if (targetGroupCount < 1) targetGroupCount = 1;

                if (listGroups.Count > 0)
                {
                    int postedGroupCount = 0;
                    while (postedGroupCount < targetGroupCount && listGroups.Count > 0)
                    {
                        if (chrome.CD930D04()) return -2;

                        string rawGroup = listGroups[0];
                        listGroups.RemoveAt(0);

                        string cleanGid = AccountGroupDB.ExtractGroupId(rawGroup);
                        if (string.IsNullOrEmpty(cleanGid)) continue;

                        string groupTargetUrl = "https://www.facebook.com/groups/" + cleanGid;

                        // Kiểm tra chống trùng nhóm
                        if (ckbKhongDangTrung && dictDuplicates != null)
                        {
                            bool alreadyPosted = false;
                            lock (dictDuplicates)
                            {
                                if (!dictDuplicates.ContainsKey(text28))
                                {
                                    dictDuplicates[text28] = new List<string>();
                                }
                                if (dictDuplicates[text28].Contains(cleanGid))
                                {
                                    alreadyPosted = true;
                                }
                                else
                                {
                                    dictDuplicates[text28].Add(cleanGid);
                                }
                            }
                            if (alreadyPosted)
                            {
                                form.method_130(int_3, string_1 + $"Bỏ qua nhóm {cleanGid} (đã đăng trong phiên này)...");
                                continue;
                            }
                        }

                        form.method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng nhóm") + " ({0}/{1}): {2}...", postedGroupCount + 1, targetGroupCount, cleanGid));

                        HumanScroll.ScrollNewsfeed(chrome, 300);

                        var (contentGrp, isUseBgGrp, imagesGrp) = PreparePostContentV2(gclass4_0, uid, text28, dictionary_19, dictionary_20);

                        // Đăng bài nhóm qua ExecuteDangBaiWWW (type 1 = Group)
                        string resGrp = chrome.method_106(1, groupTargetUrl, contentGrp, isUseBgGrp, imagesGrp);

                        if (!string.IsNullOrEmpty(resGrp))
                        {
                            totalSuccessPosts++;
                            postedGroupCount++;

                            if (ckbXoaAnh && imagesGrp != null && imagesGrp.Count > 0)
                            {
                                Commom.smethod_68(imagesGrp);
                            }

                            AccountGroupDB.RecordPostedGroup(uid, cleanGid);

                            if (typePost == 1 && ckbXoaNhomDaDang && dictionary_13 != null && dictionary_13.ContainsKey(text28))
                            {
                                lock (dictionary_13)
                                {
                                    dictionary_13[text28].RemoveAll(x => AccountGroupDB.ExtractGroupId(x).Equals(cleanGid, StringComparison.OrdinalIgnoreCase));
                                }
                            }

                            string outDir = Path.Combine(Commom.smethod_95(), "output");
                            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

                            if (resGrp.Contains("pending_posts"))
                            {
                                AccountGroupDB.UpdateGroupApproval(cleanGid, "Có duyệt bài", uid);
                                if (ckbXuatLogFileRieng)
                                {
                                    WritePostLog(uid, "Group", cleanGid, contentGrp, resGrp, "Chờ duyệt");
                                }
                                try
                                {
                                    KichBanThongKeDB.LogPost(uid, resGrp, contentGrp, "Bài viết nhóm", "Chờ duyệt", tenTaiKhoan: cleanGid);
                                }
                                catch { }

                                string fPending = Path.Combine(outDir, "pending_post_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                                Commom.smethod_98(fPending, delegate
                                {
                                    File.AppendAllText(fPending, uid + "|" + cleanGid + "|" + resGrp + Environment.NewLine);
                                });

                                form.method_130(int_3, string_1 + string.Format(Language.GetValue("Đã gửi duyệt nhóm ({0}/{1}): {2}"), postedGroupCount, targetGroupCount, resGrp));
                            }
                            else
                            {
                                AccountGroupDB.UpdateGroupApproval(cleanGid, "Không duyệt bài", uid);
                                if (ckbXuatLogFileRieng)
                                {
                                    WritePostLog(uid, "Group", cleanGid, contentGrp, resGrp, "Thành công");
                                }
                                try
                                {
                                    KichBanThongKeDB.LogPost(uid, resGrp, contentGrp, "Bài viết nhóm", "Thành công", tenTaiKhoan: cleanGid);
                                }
                                catch { }

                                string fPost = Path.Combine(outDir, "post_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                                Commom.smethod_98(fPost, delegate
                                {
                                    File.AppendAllText(fPost, uid + "|" + cleanGid + "|" + resGrp + Environment.NewLine);
                                });

                                form.method_130(int_3, string_1 + string.Format(Language.GetValue("Đã đăng nhóm ({0}/{1}): {2}"), postedGroupCount, targetGroupCount, resGrp));
                            }

                            if (postedGroupCount < targetGroupCount && listGroups.Count > 0)
                            {
                                form.method_131(int_3, string_1 + $"Đã đăng nhóm ({postedGroupCount}/{targetGroupCount}), đợi {{time}}s...", nudDelayFrom, nudDelayTo);
                            }
                        }
                        else
                        {
                            if (ckbXuatLogFileRieng)
                            {
                                WritePostLog(uid, "Group", cleanGid, contentGrp, "", "Thất bại");
                            }
                            form.method_130(int_3, string_1 + $"Đăng nhóm {cleanGid} không thành công, thử nhóm tiếp...");
                            Commom.smethod_52(2.0);
                        }
                    }
                }
                else
                {
                    form.method_130(int_3, string_1 + Language.GetValue("Không tìm thấy nhóm phù hợp để đăng."));
                    Commom.smethod_52(1.5);
                }
            }
            #endregion

            #region BƯỚC 3: ĐĂNG BÀI LÊN FANPAGE PROFILE THÔNG MINH
            // Tự động kích hoạt nếu người dùng bật ckbDangBaiLenPage HOẶC bật ckbTuDongDangPageCoSan
            bool shouldRunPagePosting = ckbDangBaiLenPage || ckbTuDongDangPageCoSan;
            if (shouldRunPagePosting)
            {
                if (chrome.CD930D04()) return -2;

                form.method_130(int_3, string_1 + Language.GetValue("Đang tự động phát hiện Fanpage của tài khoản..."));

                // Quét phát hiện Fanpage thông minh
                List<string> lstPages = DetectFanpages(chrome, msg => form.method_130(int_3, string_1 + msg));

                if (lstPages != null && lstPages.Count > 0)
                {
                    int maxPagePosts = Commom.BF833227(nudCountPageFrom, nudCountPageTo);
                    if (maxPagePosts > lstPages.Count) maxPagePosts = lstPages.Count;
                    if (maxPagePosts < 1) maxPagePosts = 1;

                    form.method_130(int_3, string_1 + string.Format(Language.GetValue("Tìm thấy {0} Page, bắt đầu đăng {1} Page..."), lstPages.Count, maxPagePosts));

                    int postedPageCount = 0;
                    for (int pIdx = 0; pIdx < maxPagePosts; pIdx++)
                    {
                        if (chrome.CD930D04()) return -2;

                        string pageTarget = lstPages[pIdx].Trim();
                        string pageUrl = pageTarget.StartsWith("http") ? pageTarget : ("https://www.facebook.com/" + pageTarget);

                        form.method_130(int_3, string_1 + string.Format(Language.GetValue("Đang đăng Page ({0}/{1}): {2}..."), pIdx + 1, maxPagePosts, pageTarget));

                        var (contentPage, isUseBgPage, imagesPage) = PreparePostContentV2(gclass4_0, uid, text28, dictionary_19, dictionary_20);

                        // Đăng bài Page qua ExecuteDangBaiWWW (type 2 = Page)
                        string resPage = chrome.method_106(2, pageUrl, contentPage, isUseBgPage, imagesPage);

                        if (!string.IsNullOrEmpty(resPage))
                        {
                            totalSuccessPosts++;
                            postedPageCount++;

                            if (ckbXoaAnh && imagesPage != null && imagesPage.Count > 0)
                            {
                                Commom.smethod_68(imagesPage);
                            }

                            // Ghi log riêng biệt UID
                            if (ckbXuatLogFileRieng)
                            {
                                WritePostLog(uid, "Page", pageTarget, contentPage, resPage, "Thành công");
                            }

                            // Đồng bộ vào DB lịch sử đăng bài
                            try
                            {
                                KichBanThongKeDB.LogPost(uid, resPage, contentPage, "Bài viết Fanpage", "Thành công", tenTaiKhoan: pageTarget);
                            }
                            catch { }

                            // Ghi output chung
                            try
                            {
                                string outDir = Path.Combine(Commom.smethod_95(), "output");
                                if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);
                                string fPage = Path.Combine(outDir, "postPage_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                                Commom.smethod_98(fPage, delegate
                                {
                                    File.AppendAllText(fPage, uid + "|" + pageTarget + "|" + resPage + Environment.NewLine);
                                });
                            }
                            catch { }

                            string msgSuccess = string.Format(Language.GetValue("Đã đăng Page ({0}/{1}): {2}"), postedPageCount, maxPagePosts, resPage);
                            form.method_130(int_3, string_1 + msgSuccess);

                            if (pIdx + 1 < maxPagePosts)
                            {
                                form.method_131(int_3, string_1 + $"Đã đăng Page ({postedPageCount}/{maxPagePosts}), đợi {{time}}s...", nudDelayFrom, nudDelayTo);
                            }
                        }
                        else
                        {
                            if (ckbXuatLogFileRieng)
                            {
                                WritePostLog(uid, "Page", pageTarget, contentPage, "", "Thất bại");
                            }
                            form.method_130(int_3, string_1 + $"Đăng Page {pageTarget} không thành công.");
                            Commom.smethod_52(2.0);
                        }
                    }
                }
                else
                {
                    if (ckbDangBaiLenPage)
                    {
                        form.method_130(int_3, string_1 + Language.GetValue("Tài khoản không sở hữu Fanpage nào để đăng bài."));
                    }
                    Commom.smethod_52(1.5);
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("ExecuteDangBaiV2 error: " + ex.ToString()); } catch { }
        }
        finally
        {
            chrome.method_54();
        }

        return totalSuccessPosts;
    }

    #endregion

    #region Action: PostReelV2 (Reels Automation với xử lý input video & auto-publish)

    /// <summary>
    /// Click phần tử an toàn bằng Selenium kết hợp JS fallback chống trượt click
    /// </summary>
    public static bool SafeClickElement(IWebDriver driver, IWebElement el)
    {
        if (driver == null || el == null) return false;
        try
        {
            el.Click();
            return true;
        }
        catch
        {
            try
            {
                var js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(@"
                    var el = arguments[0];
                    if (el) {
                        el.scrollIntoView({behavior: 'instant', block: 'center', inline: 'center'});
                        el.click();
                        el.dispatchEvent(new MouseEvent('click', {bubbles: true, cancelable: true, view: window}));
                    }
                ", el);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Xóa triệt để popup, modal backdrop và dialog chắn màn hình trên Facebook Web
    /// </summary>
    public static void DismissAllPopups(Chrome chrome, IWebDriver driver)
    {
        try { chrome?.DismissFacebookPopups(); } catch { }
        try
        {
            if (driver is IJavaScriptExecutor js)
            {
                js.ExecuteScript(@"
                    try {
                        var dialogs = document.querySelectorAll('[role=""dialog""], [data-dialog=""1""], div[aria-modal=""true""]');
                        for (var i = 0; i < dialogs.length; i++) {
                            var d = dialogs[i];
                            var closeBtn = d.querySelector('[aria-label=""Close"" i], [aria-label=""Đóng"" i], [aria-label=""Not Now"" i], [aria-label=""Lúc khác"" i], [aria-label=""Để sau"" i]');
                            if (closeBtn) {
                                closeBtn.click();
                            }
                        }
                        var cookieBtn = document.querySelector('[data-cookiebanner=""accept_button""]');
                        if (cookieBtn) cookieBtn.click();
                    } catch(e) {}
                ");
            }
        }
        catch { }
    }

    /// <summary>
    /// Đăng Reels Facebook V2 qua Web Browser (hỗ trợ song ngữ Tiếng Việt & Tiếng Anh, chống trượt click, xử lý triệt để popup)
    /// </summary>
    public static bool PostReelV2(Chrome chrome, string videoPath, string caption, List<string> hashtags, Action<string> logCallback = null)
    {
        if (chrome == null || string.IsNullOrEmpty(videoPath) || !File.Exists(videoPath))
        {
            logCallback?.Invoke("Video không tồn tại: " + videoPath);
            return false;
        }

        try
        {
            chrome.method_49();
            chrome.method_53();

            logCallback?.Invoke("Điều hướng tới Reels Create...");
            chrome.method_12("https://www.facebook.com/reels/create/");
            chrome.F8091028(3.0);
            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            DismissAllPopups(chrome, driver);

            // Unhide input file nếu cần
            try
            {
                driver.ExecuteScript(@"
                    var inputs = document.querySelectorAll('input[type=""file""]');
                    inputs.forEach(function(i) {
                        i.style.display = 'block';
                        i.style.opacity = '1';
                        i.style.visibility = 'visible';
                        i.style.width = '100px';
                        i.style.height = '30px';
                        i.style.position = 'fixed';
                        i.style.top = '10px';
                        i.style.left = '10px';
                        i.style.zIndex = '999999';
                    });
                ");
            }
            catch { }

            int waitFileTick = Environment.TickCount;
            bool fileUploaded = false;
            while (Environment.TickCount - waitFileTick < 25000)
            {
                var fileInputs = driver.FindElements(By.CssSelector("input[type='file'][accept*='video'], input[type='file']"));
                if (fileInputs.Count > 0)
                {
                    try
                    {
                        fileInputs[0].SendKeys(videoPath);
                        fileUploaded = true;
                        logCallback?.Invoke("Đã tải video lên Reels...");
                        break;
                    }
                    catch { }
                }
                chrome.F8091028(1.0);
            }

            if (!fileUploaded)
            {
                logCallback?.Invoke("Không tìm thấy ô chọn video Reels!");
                return false;
            }

            // Chờ video render và các nút xuất hiện
            chrome.F8091028(5.0);
            DismissAllPopups(chrome, driver);

            // Điền Caption & Hashtags
            string finalCaption = (caption ?? "").Trim();
            if (hashtags != null && hashtags.Count > 0)
            {
                string tagStr = string.Join(" ", hashtags);
                finalCaption = string.IsNullOrEmpty(finalCaption) ? tagStr : (finalCaption + "\n" + tagStr);
            }

            if (!string.IsNullOrEmpty(finalCaption))
            {
                logCallback?.Invoke("Nhập nội dung Reels...");
                try
                {
                    var captionInputs = driver.FindElements(By.CssSelector("div[role='textbox'], div[contenteditable='true'], textarea"));
                    if (captionInputs.Count > 0)
                    {
                        SafeClickElement(driver, captionInputs[0]);
                        chrome.F8091028(0.5);
                        captionInputs[0].SendKeys(finalCaption);
                    }
                    else
                    {
                        driver.ExecuteScript(@"
                            var box = document.querySelector('div[role=""textbox""], div[contenteditable=""true""]');
                            if (box) {
                                box.focus();
                                document.execCommand('insertText', false, arguments[0]);
                            }
                        ", finalCaption);
                    }
                }
                catch { }
            }

            chrome.F8091028(2.0);

            // Bấm Next/Tiếp tục nếu có các bước chỉnh sửa (hỗ trợ cả Tiếng Việt và Tiếng Anh)
            for (int step = 0; step < 3; step++)
            {
                DismissAllPopups(chrome, driver);
                bool nextClicked = false;
                try
                {
                    var nextBtns = driver.FindElements(By.XPath("//div[@role='button'][@aria-label='Next' or @aria-label='Tiếp tục' or @aria-label='Tiếp' or @aria-label='Tiếp theo' or .//*[text()='Next' or text()='Tiếp tục' or text()='Tiếp' or text()='Tiếp theo']] | //button[contains(.,'Next') or contains(.,'Tiếp')]"));
                    foreach (var btn in nextBtns)
                    {
                        if (btn.Displayed && btn.Enabled && btn.GetAttribute("aria-disabled") != "true")
                        {
                            if (SafeClickElement(driver, btn))
                            {
                                nextClicked = true;
                                logCallback?.Invoke($"Nhấn Next bước {step + 1}...");
                                chrome.F8091028(2.5);
                                break;
                            }
                        }
                    }
                }
                catch { }

                if (!nextClicked)
                {
                    // JS search fallback cho nút Next/Tiếp
                    object jsNext = driver.ExecuteScript(@"
                        var btns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                        for (var b of btns) {
                            if (b.getAttribute('aria-disabled') === 'true') continue;
                            var lbl = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase().trim();
                            if (lbl === 'next' || lbl === 'tiếp tục' || lbl === 'tiếp' || lbl === 'tiếp theo') {
                                b.scrollIntoView({behavior: 'instant', block: 'center'});
                                b.click();
                                b.dispatchEvent(new MouseEvent('click', {bubbles: true, cancelable: true, view: window}));
                                return 'clicked';
                            }
                        }
                        return 'not_found';
                    ");
                    if (jsNext != null && jsNext.ToString() == "clicked")
                    {
                        logCallback?.Invoke($"Nhấn Next bước {step + 1} qua JS fallback...");
                        chrome.F8091028(2.5);
                    }
                }
            }

            // Bấm Publish / Đăng (Hỗ trợ song ngữ Tiếng Việt & Tiếng Anh)
            logCallback?.Invoke("Nhấn Publish Reels...");
            bool published = false;
            int pubTick = Environment.TickCount;
            while (Environment.TickCount - pubTick < 45000)
            {
                DismissAllPopups(chrome, driver);
                var pubBtns = driver.FindElements(By.XPath("//div[@role='button'][@aria-label='Publish' or @aria-label='Đăng' or @aria-label='Chia sẻ' or @aria-label='Share' or @aria-label='Chia sẻ ngay' or @aria-label='Share now' or .//*[text()='Publish' or text()='Đăng' or text()='Chia sẻ' or text()='Share']] | //button[contains(.,'Publish') or contains(.,'Đăng') or contains(.,'Chia sẻ') or contains(.,'Share')]"));
                foreach (var btn in pubBtns)
                {
                    if (btn.Displayed && btn.Enabled && btn.GetAttribute("aria-disabled") != "true")
                    {
                        if (SafeClickElement(driver, btn))
                        {
                            published = true;
                            break;
                        }
                    }
                }

                if (published) break;

                // Thử bằng JS click với MouseEvent fallback
                object jsClick = driver.ExecuteScript(@"
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                    for (var b of btns) {
                        if (b.getAttribute('aria-disabled') === 'true') continue;
                        var lbl = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase().trim();
                        if (lbl === 'publish' || lbl === 'đăng' || lbl === 'chia sẻ ngay' || lbl === 'share now' || lbl === 'chia sẻ' || lbl === 'share' || lbl === 'post') {
                            b.scrollIntoView({behavior: 'instant', block: 'center'});
                            b.click();
                            b.dispatchEvent(new MouseEvent('click', {bubbles: true, cancelable: true, view: window}));
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                ");
                if (jsClick != null && jsClick.ToString() == "clicked")
                {
                    published = true;
                    break;
                }

                chrome.F8091028(2.0);
            }

            if (published)
            {
                chrome.F8091028(5.0);
                DismissAllPopups(chrome, driver);
                logCallback?.Invoke("Xuất bản Reels thành công!");
                return true;
            }

            logCallback?.Invoke("Không nhấn được nút Publish Reels.");
            return false;
        }
        catch (Exception ex)
        {
            logCallback?.Invoke("Lỗi PostReelV2: " + ex.Message);
            return false;
        }
    }
    #endregion

    #region Action: PostStoryV2 (Tối ưu xuất bản Story đa định dạng)
    /// <summary>
    /// Đăng Story Facebook V2 qua Web Browser (hỗ trợ song ngữ Tiếng Việt & Tiếng Anh, click JS/Selenium fallback, popup handling)
    /// </summary>
    public static bool PostStoryV2(Chrome chrome, string mediaPath, string text = "", Action<string> logCallback = null)
    {
        if (chrome == null) return false;
        if (string.IsNullOrEmpty(mediaPath) || !File.Exists(mediaPath))
        {
            logCallback?.Invoke("Tệp tin media Story không tồn tại: " + mediaPath);
            return false;
        }

        try
        {
            logCallback?.Invoke("Bắt đầu đăng Story Facebook V2...");

            // Cách 1: Thử thông qua AccountsCenterHub
            try
            {
                string json = new Newtonsoft.Json.Linq.JObject(new Newtonsoft.Json.Linq.JProperty("imagePath", mediaPath)).ToString();
                string res = AccountsCenterHub.ExecuteDangStoryWWW(chrome, json);
                if (AccountsCenterHub.IsSuccess(res))
                {
                    logCallback?.Invoke("Đăng Story thành công qua AccountsCenterHub!");
                    return true;
                }
            }
            catch { }

            // Cách 2: Trực tiếp điều hướng DOM tự động hóa V2
            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            chrome.method_49();
            chrome.method_53();
            chrome.method_12("https://www.facebook.com/stories/create/");
            chrome.F8091028(3.5);
            DismissAllPopups(chrome, driver);

            // Làm hiện input file
            try
            {
                driver.ExecuteScript(@"
                    var inputs = document.querySelectorAll('input[type=""file""]');
                    inputs.forEach(function(inp) {
                        inp.style.display = 'block';
                        inp.style.visibility = 'visible';
                        inp.style.opacity = '1';
                        inp.style.width = '100px';
                        inp.style.height = '100px';
                        inp.style.position = 'fixed';
                        inp.style.top = '10px';
                        inp.style.left = '10px';
                        inp.style.zIndex = '999999';
                    });
                ");
            }
            catch { }

            IWebElement fileInput = null;
            try
            {
                var list = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file'][accept*='video'], input[type='file']"));
                if (list.Count > 0) fileInput = list[0];
            }
            catch { }

            if (fileInput == null)
            {
                // Bấm chọn card Tạo tin ảnh / Tạo tin video (Bilingual: VI & EN)
                try
                {
                    var cards = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Tạo tin ảnh') or contains(text(), 'Create a photo story') or contains(text(), 'Tạo tin') or contains(text(), 'Create a story')]]"));
                    if (cards.Count > 0)
                    {
                        SafeClickElement(driver, cards[0]);
                        chrome.F8091028(1.5);
                        var list = driver.FindElements(By.CssSelector("input[type='file']"));
                        if (list.Count > 0) fileInput = list[0];
                    }
                }
                catch { }
            }

            if (fileInput == null)
            {
                logCallback?.Invoke("Không tìm thấy input tải file Story!");
                return false;
            }

            fileInput.SendKeys(mediaPath);
            logCallback?.Invoke("Đã tải tệp media lên Story, đang chờ xử lý...");
            chrome.F8091028(4.5);
            DismissAllPopups(chrome, driver);

            // Nếu có văn bản đi kèm
            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    var textBoxes = driver.FindElements(By.CssSelector("textarea, [role='textbox'][contenteditable='true']"));
                    if (textBoxes.Count > 0)
                    {
                        SafeClickElement(driver, textBoxes[0]);
                        textBoxes[0].SendKeys(text);
                        chrome.F8091028(1.0);
                    }
                }
                catch { }
            }

            // Chờ và nhấn nút "Chia sẻ lên tin" / "Share to story" (Hỗ trợ song ngữ Tiếng Việt & Tiếng Anh)
            logCallback?.Invoke("Nhấn Chia sẻ Story...");
            bool shared = false;
            int waitShareTick = Environment.TickCount;
            while (Environment.TickCount - waitShareTick < 35000)
            {
                DismissAllPopups(chrome, driver);

                var shareBtns = driver.FindElements(By.XPath("//div[@role='button'][@aria-label='Chia sẻ lên tin' or @aria-label='Share to story' or @aria-label='Chia sẻ' or @aria-label='Share' or contains(@aria-label, 'Chia sẻ lên tin') or contains(@aria-label, 'Share to story') or .//*[contains(text(), 'Chia sẻ lên tin') or contains(text(), 'Share to story') or contains(text(), 'Chia sẻ')]] | //button[contains(.,'Chia sẻ lên tin') or contains(.,'Share to story')]"));
                foreach (var btn in shareBtns)
                {
                    if (btn.Displayed && btn.Enabled && btn.GetAttribute("aria-disabled") != "true")
                    {
                        if (SafeClickElement(driver, btn))
                        {
                            shared = true;
                            break;
                        }
                    }
                }

                if (shared) break;

                // JS fallback click
                object jsShare = driver.ExecuteScript(@"
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                    for (var b of btns) {
                        if (b.getAttribute('aria-disabled') === 'true') continue;
                        var t = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase().trim();
                        if (t.includes('chia sẻ lên tin') || t.includes('share to story') || t === 'chia sẻ' || t === 'share') {
                            b.scrollIntoView({behavior: 'instant', block: 'center'});
                            b.click();
                            b.dispatchEvent(new MouseEvent('click', {bubbles: true, cancelable: true, view: window}));
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                ");

                if (jsShare != null && jsShare.ToString() == "clicked")
                {
                    shared = true;
                    break;
                }

                chrome.F8091028(1.5);
            }

            if (shared)
            {
                chrome.F8091028(4.0);
                DismissAllPopups(chrome, driver);
                logCallback?.Invoke("Xuất bản Story thành công!");
                return true;
            }

            logCallback?.Invoke("Không tìm thấy nút Chia sẻ Story hoặc nút bị vô hiệu hóa.");
            return false;
        }
        catch (Exception ex)
        {
            logCallback?.Invoke("Lỗi PostStoryV2: " + ex.Message);
            return false;
        }
    }
    #endregion
}
