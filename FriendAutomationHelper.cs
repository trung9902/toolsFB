using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;

public static class FriendAutomationHelper
{
    private static readonly Random _rand = new Random();

    #region Modern Form UI Synchronization
    /// <summary>
    /// Đồng bộ giao diện chuẩn LushCare cho form Bạn Bè:
    /// - Dải xanh 4px pnlTopAccent (#2563EB) trên cùng
    /// - Bắt phím ESC đóng form
    /// - Icon thu nhỏ (min_window.png) và đóng (close_window.png) chuẩn LushCare
    /// - Viền BunifuCards đồng bộ màu #2563EB
    /// </summary>
    public static void SetupModernFormUI(Form form)
    {
        if (form == null || form.IsDisposed) return;

        try
        {
            // 1. Phím tắt ESC đóng form
            form.KeyPreview = true;
            form.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    form.Close();
                }
            };

            // 2. Quét tìm container panel, header, cards, buttons
            Panel mainPanel = null;
            Panel pnlHeader = null;
            BunifuCards cards = null;
            Button btnClose = null;
            Button btnMinimize = null;
            PictureBox picLogo = null;

            Action<Control> scan = null;
            scan = (parent) =>
            {
                foreach (Control c in parent.Controls)
                {
                    if (c is BunifuCards bc)
                    {
                        cards = bc;
                    }
                    else if (c is Panel p)
                    {
                        string pName = p.Name.ToLowerInvariant();
                        if (pName.Contains("header") || pName == "c89c7222" || pName == "f728520d")
                        {
                            pnlHeader = p;
                        }
                        else if (mainPanel == null && (p.Dock == DockStyle.Fill || pName == "panel1" || pName == "e4a1483a" || pName == "b5108228" || pName == "c720bd87" || pName == "a0084b84"))
                        {
                            mainPanel = p;
                        }
                    }
                    else if (c is Button b)
                    {
                        string bName = b.Name.ToLowerInvariant();
                        if (bName == "btnminimize")
                        {
                            btnMinimize = b;
                        }
                        else if (bName == "button1" || bName == "btnclose" || bName == "ccaf8d8f" || bName == "d500930b" || bName == "f1937c96" || bName == "d783c535")
                        {
                            btnClose = b;
                        }
                        else if (pnlHeader != null && pnlHeader.Controls.Contains(b) && (b.Text == "✕" || b.Text == "X" || b.Text == "" || bName.Contains("close")))
                        {
                            btnClose = b;
                        }
                    }
                    else if (c is PictureBox pb && (pb.Name.ToLowerInvariant().Contains("logo") || pb.Name == "pictureBox1" || pb.Name == "EB1E7891" || pb.Name == "E32E6232"))
                    {
                        picLogo = pb;
                    }

                    if (c.HasChildren) scan(c);
                }
            };

            scan(form);

            if (mainPanel == null)
            {
                foreach (Control c in form.Controls)
                {
                    if (c is Panel p && p.Dock == DockStyle.Fill) { mainPanel = p; break; }
                }
            }
            if (mainPanel == null && form.Controls.Count > 0 && form.Controls[0] is Panel p0)
            {
                mainPanel = p0;
            }

            // 3. Chèn dải màu xanh 4px pnlTopAccent (#2563EB) trên cùng
            Control topContainer = mainPanel ?? (Control)form;
            bool hasAccent = false;
            foreach (Control c in topContainer.Controls)
            {
                if (c.Name == "pnlTopAccent") { hasAccent = true; break; }
            }
            if (!hasAccent)
            {
                Panel pnlTopAccent = new Panel
                {
                    Name = "pnlTopAccent",
                    Height = 4,
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(37, 99, 235), // Royal Blue #2563EB
                    TabIndex = 0
                };
                topContainer.Controls.Add(pnlTopAccent);
                pnlTopAccent.BringToFront();
            }

            // 4. Đồng bộ màu thẻ BunifuCards
            if (cards != null)
            {
                cards.color = Color.FromArgb(37, 99, 235);
            }

            // 5. Cấu hình Nút Đóng & Nút Thu nhỏ chuẩn LushCare
            if (pnlHeader != null)
            {
                Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
                Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);

                if (btnClose != null)
                {
                    btnClose.FlatAppearance.BorderSize = 0;
                    btnClose.FlatStyle = FlatStyle.Flat;
                    btnClose.Cursor = Cursors.Hand;
                    btnClose.ForeColor = Color.FromArgb(71, 85, 105);
                    if (iconClose != null)
                    {
                        btnClose.Image = iconClose;
                        btnClose.Text = "";
                    }
                }

                if (btnMinimize == null)
                {
                    btnMinimize = new Button
                    {
                        Name = "btnMinimize",
                        Size = new Size(30, 30),
                        Cursor = Cursors.Hand,
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.FromArgb(71, 85, 105),
                        TabIndex = 78,
                        UseVisualStyleBackColor = true
                    };
                    btnMinimize.FlatAppearance.BorderSize = 0;
                    if (iconMin != null)
                    {
                        btnMinimize.Image = iconMin;
                        btnMinimize.Text = "";
                    }
                    else
                    {
                        btnMinimize.Text = "—";
                        btnMinimize.Font = new Font("Tahoma", 9f, FontStyle.Bold);
                    }
                    btnMinimize.Click += (s, e) => { form.WindowState = FormWindowState.Minimized; };
                    pnlHeader.Controls.Add(btnMinimize);
                }

                Action relayoutHeader = () =>
                {
                    if (btnClose != null)
                    {
                        btnClose.Location = new Point(pnlHeader.Width - 34, 1);
                        btnClose.BringToFront();
                    }
                    if (btnMinimize != null)
                    {
                        btnMinimize.Location = new Point(pnlHeader.Width - 68, 1);
                        btnMinimize.BringToFront();
                    }
                };

                pnlHeader.Resize += (s, e) => relayoutHeader();
                relayoutHeader();
            }

            // 6. Icon logo nhóm/bạn bè
            if (picLogo != null)
            {
                Image friendIcon = AppIconHelper.GetIcon("group.png", 22, 22);
                if (friendIcon != null)
                {
                    picLogo.Image = friendIcon;
                }
            }
        }
        catch { }
    }
    #endregion

    #region Smart Filter & Spintax Helpers
    private static readonly Regex _regexVnAccents = new Regex("[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ]", RegexOptions.Compiled);
    private static readonly HashSet<string> _vnSurnames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "nguyen", "tran", "le", "pham", "hoang", "huynh", "phan", "vu", "vo", "dang", "bui", "do", "ho", "ngo",
        "duong", "dinh", "dao", "doan", "mai", "truong", "luong", "ngoc", "thao", "anh", "linh", "trang", "phuong",
        "huong", "duc", "tuan", "nam", "hai", "quang", "minh", "kien", "son", "dat", "hung", "long", "thanh", "tien"
    };

    /// <summary>
    /// Kiểm tra tên tiếng Việt:
    /// - Có dấu tiếng Việt chuẩn
    /// - Hoặc họ tên không dấu nhưng khớp các từ họ/đệm Việt Nam phổ biến
    /// </summary>
    public static bool IsVietnameseName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;

        // Có ký tự tiếng Việt có dấu
        if (_regexVnAccents.IsMatch(name)) return true;

        // Kiểm tra qua helper gốc nếu có
        try
        {
            if (Commom.D9AB3B82(name)) return true;
        }
        catch { }

        // Kiểm tra họ/tên Việt Nam không dấu
        string cleanName = Regex.Replace(name, @"[^\w\s]", " ").Trim();
        string[] parts = cleanName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int matchCount = 0;
        foreach (var p in parts)
        {
            if (_vnSurnames.Contains(p)) matchCount++;
        }
        return matchCount >= 2 || (matchCount >= 1 && parts.Length <= 4);
    }

    /// <summary>
    /// Kiểm tra người dùng có ảnh đại diện (avatar thật) hay không:
    /// Bỏ qua avatar mặc định placeholder của Facebook (rsrc.php, silhouette, blank).
    /// </summary>
    public static bool HasCustomAvatar(string avatarSrc)
    {
        if (string.IsNullOrWhiteSpace(avatarSrc)) return false;
        string lower = avatarSrc.ToLowerInvariant();
        if (lower.Contains("rsrc.php") || lower.Contains("silhouette") || lower.Contains("default_avatar") || lower.Contains("profile_avatar"))
        {
            return false;
        }
        return lower.Contains("fbcdn.net") || lower.Contains("scontent");
    }

    /// <summary>
    /// Trích xuất số lượng bạn chung từ chuỗi text trên card (ví dụ: "12 bạn chung", "5 mutual friends")
    /// </summary>
    public static int ExtractMutualFriends(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        Match m = Regex.Match(text, @"(\d+)\s*(?:bạn\s*chung|mutual)", RegexOptions.IgnoreCase);
        if (m.Success && int.TryParse(m.Groups[1].Value, out int count))
        {
            return count;
        }
        return 0;
    }

    /// <summary>
    /// Giải mã nội dung Spintax đa tầng: {lời chúc 1|lời chúc 2|lời chúc 3}
    /// Hỗ trợ thay thế tag {name} bằng tên người nhận.
    /// </summary>
    public static string SpinText(string text, string targetName = "")
    {
        if (string.IsNullOrEmpty(text)) return "";

        string result = text;
        if (!string.IsNullOrEmpty(targetName))
        {
            result = result.Replace("{name}", targetName).Replace("[name]", targetName);
        }

        string pattern = @"\{([^{}]+)\}";
        int loops = 0;
        while (Regex.IsMatch(result, pattern) && loops++ < 10)
        {
            result = Regex.Replace(result, pattern, m =>
            {
                string[] parts = m.Groups[1].Value.Split('|');
                return parts[_rand.Next(parts.Length)];
            });
        }

        return result;
    }
    #endregion

    #region Feature 1: Kết bạn gợi ý (HDKetBanGoiY)
    public static int KetBanGoiY(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool filterVnName = config.method_3("ckbChiKetBanTenCoDau");
            bool filterMutual = config.method_3("ckbOnlyAddFriendWithMutualFriends");
            bool filterAvatar = config.method_3("ckbBoQuaNickKhongAvatar", false);
            int minMutual = config.method_2("nudMinMutualFriends", 1);
            int maxWarning = config.method_2("nudTimesWarning", 3);
            int warningCount = 0;

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở danh sách gợi ý kết bạn...");
            chrome.method_12("https://www.facebook.com/friends/suggestions");
            chrome.F8091028(3.0);

            if (chrome.method_125() != 1 && new List<int> { -3, -2, -1, 2 }.Contains(chrome.method_125()))
            {
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Tài khoản checkpoint hoặc mất đăng nhập!");
                return 0;
            }

            int noCardAttempts = 0;
            while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
            {
                // JavaScript quét thông minh danh sách thẻ gợi ý trên Facebook Comet WWW mới nhất
                string jsScan = @"(() => {
                    var filterVn = " + (filterVnName ? "true" : "false") + @";
                    var filterMutual = " + (filterMutual ? "true" : "false") + @";
                    var minMutual = " + minMutual + @";
                    var filterAvatar = " + (filterAvatar ? "true" : "false") + @";

                    function isVn(str) {
                        if (!str) return false;
                        var reg = /[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]/i;
                        if (reg.test(str)) return true;
                        var surnames = ['nguyen','tran','le','pham','hoang','huynh','phan','vu','vo','dang','bui','do','ho','ngo','duong','dinh','dao','doan','mai','truong','thanh','quang','minh'];
                        var words = str.toLowerCase().split(/\s+/);
                        var hits = 0;
                        for (var w of words) { if (surnames.includes(w)) hits++; }
                        return hits >= 1;
                    }

                    // Tìm nút Thêm bạn bè trong từng card
                    var buttons = document.querySelectorAll('[role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], div[aria-label=""Thêm bạn bè"" i], div[aria-label=""Add friend"" i], [role=""button""][aria-label*=""Add Friend"" i]');
                    for (var btn of buttons) {
                        if (btn.getAttribute('data-lc-processed') === '1') continue;
                        
                        // Tìm card bao bọc nút
                        var card = btn.closest('[role=""listitem""]') || btn.closest('[data-visualcompletion=""ignore-dynamic""]') || btn.parentElement.parentElement;
                        var name = '';
                        var mutualCount = 0;
                        var hasAvatar = true;

                        if (card) {
                            var link = card.querySelector('a[role=""link""], h2, h3, span[dir=""auto""]');
                            if (link) name = (link.innerText || '').trim();

                            var cardText = card.innerText || '';
                            var mMatch = cardText.match(/(\d+)\s*(?:bạn\s*chung|mutual)/i);
                            if (mMatch) mutualCount = parseInt(mMatch[1], 10);

                            var img = card.querySelector('image, img');
                            if (img) {
                                var src = img.getAttribute('xlink:href') || img.src || '';
                                if (src.indexOf('rsrc.php') !== -1 || src.indexOf('silhouette') !== -1 || src.indexOf('default_avatar') !== -1) {
                                    hasAvatar = false;
                                }
                            }
                        }

                        // Kiểm tra bộ lọc thông minh
                        if (filterVn && name && !isVn(name)) {
                            btn.setAttribute('data-lc-processed', '1');
                            continue;
                        }
                        if (filterMutual && mutualCount < minMutual) {
                            btn.setAttribute('data-lc-processed', '1');
                            continue;
                        }
                        if (filterAvatar && !hasAvatar) {
                            btn.setAttribute('data-lc-processed', '1');
                            continue;
                        }

                        // Thỏa mãn điều kiện -> Click thêm bạn bè
                        btn.setAttribute('data-lc-processed', '1');
                        btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        btn.click();
                        return JSON.stringify({ status: 'ok', name: name, mutual: mutualCount });
                    }

                    // Nếu không còn card trên màn hình -> Cuộn trang tải thêm
                    window.scrollBy(0, 800);
                    return JSON.stringify({ status: 'scroll' });
                })()";

                string evalRes = chrome.method_14(jsScan);
                if (string.IsNullOrEmpty(evalRes))
                {
                    chrome.method_14("window.scrollBy(0, 700);");
                    chrome.F8091028(2.0);
                    noCardAttempts++;
                    if (noCardAttempts > 5) break;
                    continue;
                }

                try
                {
                    JObject jRes = JObject.Parse(evalRes);
                    string status = (string)jRes["status"];
                    if (status == "ok")
                    {
                        noCardAttempts = 0;
                        countSuccess++;
                        string friendName = (string)jRes["name"] ?? "";
                        int mutual = (int)(jRes["mutual"] ?? 0);

                        // Kiểm tra cảnh báo Facebook (method_118)
                        if (chrome.method_118())
                        {
                            warningCount++;
                            mainForm.method_130(rowIndex, $"{accStatusPrefix}: FB cảnh báo spam ({warningCount}/{maxWarning})");
                            if (warningCount >= maxWarning) break;
                        }

                        mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã gửi kết bạn {countSuccess}/{targetCount} ({friendName} - {mutual} bạn chung)");

                        if (countSuccess < targetCount)
                        {
                            mainForm.method_131(rowIndex, $"{accStatusPrefix}: Nghỉ giãn cách...", delayFrom, delayTo);
                        }
                    }
                    else if (status == "scroll")
                    {
                        noCardAttempts++;
                        chrome.F8091028(2.0);
                        if (noCardAttempts > 8) break;
                    }
                }
                catch
                {
                    chrome.method_14("window.scrollBy(0, 600);");
                    chrome.F8091028(2.0);
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn thành kết bạn gợi ý ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi kết bạn gợi ý: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 2: Kết bạn theo tệp UID (HDKetBanTepUid)
    public static int KetBanTepUid(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName, string actionId)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool filterVnName = config.method_3("ckbChiKetBanTenCoDau");
            bool filterAvatar = config.method_3("ckbBoQuaNickKhongAvatar", false);
            bool preInteract = config.method_3("ckbTuongTac");

            // Lấy danh sách UID từ cấu hình hoặc dictionary_0
            List<string> uids = null;
            if (mainForm.dictionary_0 != null && mainForm.dictionary_0.ContainsKey(actionId))
            {
                uids = mainForm.dictionary_0[actionId];
            }
            if (uids == null || uids.Count == 0)
            {
                string rawUidText = config.BDB80B23("txtUid");
                uids = rawUidText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(u => u.Trim())
                                 .Where(u => !string.IsNullOrEmpty(u))
                                 .ToList();
            }

            if (uids == null || uids.Count == 0)
            {
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hết danh sách UID cần kết bạn!");
                return 0;
            }

            while (!Base.smethod_5() && uids.Count > 0 && countSuccess < targetCount && !chrome.CD930D04())
            {
                string targetUid = uids[0];
                uids.RemoveAt(0);

                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở profile UID: {targetUid} ({countSuccess}/{targetCount})");
                string profileUrl = targetUid.All(char.IsDigit) ? $"https://www.facebook.com/profile.php?id={targetUid}" : $"https://www.facebook.com/{targetUid}";
                chrome.method_12(profileUrl);
                chrome.F8091028(3.0);

                // Kiểm tra trang có khả dụng
                string pageContent = chrome.method_14("document.body ? document.body.innerText : ''");
                if (pageContent.Contains("Trang này không khả dụng") || pageContent.Contains("This content isn't available"))
                {
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Profile {targetUid} không tồn tại hoặc bị khóa, bỏ qua...");
                    continue;
                }

                // Kiểm tra đã là bạn bè hoặc đã gửi lời mời trước đó
                string checkStatusJs = @"(() => {
                    var txt = document.body.innerText || '';
                    if (document.querySelector('[aria-label=""Bạn bè"" i], [aria-label=""Friends"" i], [aria-label*=""Đã gửi lời mời"" i], [aria-label*=""Cancel request"" i], [aria-label*=""Hủy lời mời"" i]')) {
                        return 'already_friend_or_pending';
                    }
                    var nameEl = document.querySelector('h1, h2');
                    var name = nameEl ? nameEl.innerText.trim() : '';
                    var img = document.querySelector('image, img[src*=""scontent""], img[src*=""fbcdn""]');
                    var hasAvatar = img && !img.src.includes('rsrc.php') && !img.src.includes('silhouette');
                    return JSON.stringify({ name: name, hasAvatar: hasAvatar });
                })()";

                string checkRes = chrome.method_14(checkStatusJs);
                if (checkRes == "already_friend_or_pending")
                {
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã là bạn bè hoặc đang chờ đồng ý UID: {targetUid}");
                    continue;
                }

                // Kiểm tra bộ lọc
                if (!string.IsNullOrEmpty(checkRes) && checkRes.StartsWith("{"))
                {
                    try
                    {
                        JObject jCheck = JObject.Parse(checkRes);
                        string pName = (string)jCheck["name"];
                        bool pAvatar = (bool)(jCheck["hasAvatar"] ?? true);

                        if (filterVnName && !string.IsNullOrEmpty(pName) && !IsVietnameseName(pName))
                        {
                            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Bỏ qua UID {targetUid} vì tên không phải tiếng Việt ({pName})");
                            continue;
                        }
                        if (filterAvatar && !pAvatar)
                        {
                            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Bỏ qua UID {targetUid} vì không có avatar thật");
                            continue;
                        }
                    }
                    catch { }
                }

                // Tương tác nhẹ nếu có bật cấu hình
                if (preInteract)
                {
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Tương tác xem timeline UID: {targetUid}...");
                    chrome.method_14("window.scrollBy(0, 500);");
                    chrome.F8091028(2.0);
                    chrome.method_14(@"(() => {
                        var likeBtn = document.querySelector('[role=""button""][aria-label*=""Thích"" i], [role=""button""][aria-label*=""Like"" i]');
                        if (likeBtn) likeBtn.click();
                    })()");
                    chrome.F8091028(1.5);
                }

                // Bấm nút Thêm bạn bè (Add Friend) với bộ selector Comet WWW đầy đủ
                string addFriendJs = @"(() => {
                    var selectors = [
                        '[role=""button""][aria-label=""Thêm bạn bè"" i]',
                        '[role=""button""][aria-label=""Thêm bạn"" i]',
                        '[role=""button""][aria-label=""Add friend"" i]',
                        '[role=""button""][aria-label=""Add Friend"" i]',
                        'div[aria-label=""Thêm bạn bè"" i]',
                        'div[aria-label=""Thêm bạn"" i]',
                        'div[aria-label=""Add friend"" i]',
                        '[role=""button""][aria-label*=""Thêm bạn"" i]',
                        '[role=""button""][aria-label*=""Add friend"" i]'
                    ];
                    for (var sel of selectors) {
                        var btn = document.querySelector(sel);
                        if (btn && btn.offsetParent !== null) {
                            btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            btn.click();
                            return 'clicked';
                        }
                    }
                    // Tìm theo span chứa text
                    var buttons = document.querySelectorAll('[role=""button""], button');
                    for (var b of buttons) {
                        var t = (b.innerText || '').trim();
                        if (t === 'Thêm bạn bè' || t === 'Thêm bạn' || t === 'Add friend' || t === 'Add Friend') {
                            b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            b.click();
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                })()";

                string addResult = chrome.method_14(addFriendJs);
                if (addResult == "clicked")
                {
                    countSuccess++;
                    if (chrome.method_118())
                    {
                        mainForm.method_130(rowIndex, $"{accStatusPrefix}: FB phát cảnh báo khi kết bạn UID {targetUid}");
                    }
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã gửi kết bạn UID: {targetUid} ({countSuccess}/{targetCount})");

                    if (countSuccess < targetCount && uids.Count > 0)
                    {
                        mainForm.method_131(rowIndex, $"{accStatusPrefix}: Chờ tiếp theo...", delayFrom, delayTo);
                    }
                }
                else
                {
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Không tìm thấy nút Thêm bạn bè cho UID: {targetUid}");
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất kết bạn tệp UID ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi kết bạn UID: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 3: Kết bạn thành viên nhóm (HDKetBanThanhVienNhom)
    public static int KetBanThanhVienNhom(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool filterVnName = config.method_3("ckbChiKetBanTenCoDau");
            bool filterAvatar = config.method_3("ckbBoQuaNickKhongAvatar", false);
            string rawGroupText = config.BDB80B23("txtUid");
            List<string> groupIds = rawGroupText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(g => g.Trim())
                                                .Where(g => !string.IsNullOrEmpty(g))
                                                .ToList();

            if (groupIds.Count == 0)
            {
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Chưa nhập ID nhóm cần kết bạn!");
                return 0;
            }

            string targetGroupId = groupIds[_rand.Next(groupIds.Count)];
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở danh sách thành viên nhóm {targetGroupId}...");
            chrome.method_12($"https://www.facebook.com/groups/{targetGroupId}/members");
            chrome.F8091028(4.0);

            int scrollAttempts = 0;
            while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
            {
                string jsMemberAdd = @"(() => {
                    var filterVn = " + (filterVnName ? "true" : "false") + @";
                    var filterAvatar = " + (filterAvatar ? "true" : "false") + @";

                    function isVn(str) {
                        if (!str) return false;
                        var reg = /[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]/i;
                        if (reg.test(str)) return true;
                        var surnames = ['nguyen','tran','le','pham','hoang','huynh','phan','vu','vo','dang','bui','do','ho','ngo','duong','dinh','dao','doan','mai','truong','thanh','quang','minh'];
                        var words = str.toLowerCase().split(/\s+/);
                        var hits = 0;
                        for (var w of words) { if (surnames.includes(w)) hits++; }
                        return hits >= 1;
                    }

                    var buttons = document.querySelectorAll('[role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], div[aria-label=""Thêm bạn bè"" i], div[aria-label=""Add friend"" i]');
                    for (var btn of buttons) {
                        if (btn.getAttribute('data-lc-member-done') === '1') continue;

                        var card = btn.closest('[role=""listitem""]') || btn.parentElement.parentElement;
                        var name = '';
                        var hasAvatar = true;

                        if (card) {
                            var link = card.querySelector('a[role=""link""], span[dir=""auto""]');
                            if (link) name = (link.innerText || '').trim();

                            var cardText = card.innerText || '';
                            if (cardText.indexOf('Quản trị viên') !== -1 || cardText.indexOf('Người kiểm duyệt') !== -1 || cardText.indexOf('Admin') !== -1 || cardText.indexOf('Moderator') !== -1) {
                                btn.setAttribute('data-lc-member-done', '1');
                                continue;
                            }

                            var img = card.querySelector('image, img');
                            if (img) {
                                var src = img.getAttribute('xlink:href') || img.src || '';
                                if (src.indexOf('rsrc.php') !== -1 || src.indexOf('silhouette') !== -1) {
                                    hasAvatar = false;
                                }
                            }
                        }

                        if (filterVn && name && !isVn(name)) {
                            btn.setAttribute('data-lc-member-done', '1');
                            continue;
                        }
                        if (filterAvatar && !hasAvatar) {
                            btn.setAttribute('data-lc-member-done', '1');
                            continue;
                        }

                        btn.setAttribute('data-lc-member-done', '1');
                        btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        btn.click();
                        return JSON.stringify({ status: 'ok', name: name });
                    }

                    window.scrollBy(0, 800);
                    return JSON.stringify({ status: 'scroll' });
                })()";

                string res = chrome.method_14(jsMemberAdd);
                if (string.IsNullOrEmpty(res))
                {
                    chrome.method_14("window.scrollBy(0, 700);");
                    chrome.F8091028(2.0);
                    scrollAttempts++;
                    if (scrollAttempts > 6) break;
                    continue;
                }

                try
                {
                    JObject jRes = JObject.Parse(res);
                    string status = (string)jRes["status"];
                    if (status == "ok")
                    {
                        scrollAttempts = 0;
                        countSuccess++;
                        string mName = (string)jRes["name"] ?? "";
                        mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã gửi kết bạn TV nhóm {countSuccess}/{targetCount} ({mName})");

                        if (countSuccess < targetCount)
                        {
                            mainForm.method_131(rowIndex, $"{accStatusPrefix}: Giãn cách...", delayFrom, delayTo);
                        }
                    }
                    else if (status == "scroll")
                    {
                        scrollAttempts++;
                        chrome.F8091028(2.0);
                        if (scrollAttempts > 8) break;
                    }
                }
                catch
                {
                    chrome.method_14("window.scrollBy(0, 600);");
                    chrome.F8091028(2.0);
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất kết bạn thành viên nhóm ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi kết bạn TV nhóm: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 4: Kết bạn theo từ khóa (HDKetBanTheoTuKhoa)
    public static int KetBanTheoTuKhoa(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool filterVnName = config.method_3("ckbChiKetBanTenCoDau");
            bool filterAvatar = config.method_3("ckbBoQuaNickKhongAvatar", false);
            string rawKeywords = config.BDB80B23("txtTuKhoa");
            List<string> keywords = rawKeywords.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(k => k.Trim())
                                               .Where(k => !string.IsNullOrEmpty(k))
                                               .ToList();

            if (keywords.Count == 0)
            {
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Danh sách từ khóa trống!");
                return 0;
            }

            string keyword = keywords[_rand.Next(keywords.Count)];
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang tìm kiếm người dùng từ khóa '{keyword}'...");
            chrome.method_12($"https://www.facebook.com/search/people/?q={Uri.EscapeDataString(keyword)}");
            chrome.F8091028(4.0);

            int scrollAttempts = 0;
            while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
            {
                string jsSearchAdd = @"(() => {
                    var filterVn = " + (filterVnName ? "true" : "false") + @";
                    var filterAvatar = " + (filterAvatar ? "true" : "false") + @";

                    function isVn(str) {
                        if (!str) return false;
                        var reg = /[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]/i;
                        if (reg.test(str)) return true;
                        var surnames = ['nguyen','tran','le','pham','hoang','huynh','phan','vu','vo','dang','bui','do','ho','ngo','duong','dinh','dao','doan','mai','truong','thanh','quang','minh'];
                        var words = str.toLowerCase().split(/\s+/);
                        var hits = 0;
                        for (var w of words) { if (surnames.includes(w)) hits++; }
                        return hits >= 1;
                    }

                    var buttons = document.querySelectorAll('[role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], div[aria-label=""Thêm bạn bè"" i], div[aria-label=""Add friend"" i]');
                    for (var btn of buttons) {
                        if (btn.getAttribute('data-lc-search-done') === '1') continue;

                        var card = btn.closest('[role=""article""]') || btn.closest('[role=""listitem""]') || btn.parentElement.parentElement;
                        var name = '';
                        var hasAvatar = true;

                        if (card) {
                            var link = card.querySelector('a[role=""link""], span[dir=""auto""]');
                            if (link) name = (link.innerText || '').trim();

                            var img = card.querySelector('image, img');
                            if (img) {
                                var src = img.getAttribute('xlink:href') || img.src || '';
                                if (src.indexOf('rsrc.php') !== -1 || src.indexOf('silhouette') !== -1) {
                                    hasAvatar = false;
                                }
                            }
                        }

                        if (filterVn && name && !isVn(name)) {
                            btn.setAttribute('data-lc-search-done', '1');
                            continue;
                        }
                        if (filterAvatar && !hasAvatar) {
                            btn.setAttribute('data-lc-search-done', '1');
                            continue;
                        }

                        btn.setAttribute('data-lc-search-done', '1');
                        btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        btn.click();
                        return JSON.stringify({ status: 'ok', name: name });
                    }

                    window.scrollBy(0, 800);
                    return JSON.stringify({ status: 'scroll' });
                })()";

                string res = chrome.method_14(jsSearchAdd);
                if (string.IsNullOrEmpty(res))
                {
                    chrome.method_14("window.scrollBy(0, 700);");
                    chrome.F8091028(2.0);
                    scrollAttempts++;
                    if (scrollAttempts > 6) break;
                    continue;
                }

                try
                {
                    JObject jRes = JObject.Parse(res);
                    string status = (string)jRes["status"];
                    if (status == "ok")
                    {
                        scrollAttempts = 0;
                        countSuccess++;
                        string sName = (string)jRes["name"] ?? "";
                        mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã gửi kết bạn từ khóa {countSuccess}/{targetCount} ({sName})");

                        if (countSuccess < targetCount)
                        {
                            mainForm.method_131(rowIndex, $"{accStatusPrefix}: Nghỉ giãn cách...", delayFrom, delayTo);
                        }
                    }
                    else if (status == "scroll")
                    {
                        scrollAttempts++;
                        chrome.F8091028(2.0);
                        if (scrollAttempts > 8) break;
                    }
                }
                catch
                {
                    chrome.method_14("window.scrollBy(0, 600);");
                    chrome.F8091028(2.0);
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất kết bạn từ khóa ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi kết bạn từ khóa: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 5: Kết bạn với bạn của UID (HDKetBanVoiBanBeCuaUid)
    public static int KetBanVoiBanBeCuaUid(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName, string actionId)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool filterVnName = config.method_3("ckbChiKetBanTenCoDau");
            bool filterAvatar = config.method_3("ckbBoQuaNickKhongAvatar", false);

            List<string> targetUids = null;
            if (mainForm.DE0D9D90 != null && mainForm.DE0D9D90.ContainsKey(actionId))
            {
                targetUids = mainForm.DE0D9D90[actionId];
            }
            if (targetUids == null || targetUids.Count == 0)
            {
                string raw = config.BDB80B23("txtUid");
                targetUids = raw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(u => u.Trim())
                                .Where(u => !string.IsNullOrEmpty(u))
                                .ToList();
            }

            if (targetUids == null || targetUids.Count == 0)
            {
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hết UID mục tiêu để kết bạn bạn bè!");
                return 0;
            }

            string targetUid = targetUids[0];
            targetUids.RemoveAt(0);

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở danh sách bạn bè của UID {targetUid}...");
            string friendsUrl = targetUid.All(char.IsDigit) ? $"https://www.facebook.com/profile.php?id={targetUid}&sk=friends" : $"https://www.facebook.com/{targetUid}/friends";
            chrome.method_12(friendsUrl);
            chrome.F8091028(4.0);

            int scrollAttempts = 0;
            while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
            {
                string jsFriendsOfUid = @"(() => {
                    var filterVn = " + (filterVnName ? "true" : "false") + @";
                    var filterAvatar = " + (filterAvatar ? "true" : "false") + @";

                    function isVn(str) {
                        if (!str) return false;
                        var reg = /[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]/i;
                        if (reg.test(str)) return true;
                        var surnames = ['nguyen','tran','le','pham','hoang','huynh','phan','vu','vo','dang','bui','do','ho','ngo','duong','dinh','dao','doan','mai','truong','thanh','quang','minh'];
                        var words = str.toLowerCase().split(/\s+/);
                        var hits = 0;
                        for (var w of words) { if (surnames.includes(w)) hits++; }
                        return hits >= 1;
                    }

                    var buttons = document.querySelectorAll('[role=""button""][aria-label*=""Thêm bạn"" i], [role=""button""][aria-label*=""Add friend"" i], div[aria-label=""Thêm bạn bè"" i], div[aria-label=""Add friend"" i]');
                    for (var btn of buttons) {
                        if (btn.getAttribute('data-lc-fof-done') === '1') continue;

                        var card = btn.closest('[role=""listitem""]') || btn.parentElement.parentElement;
                        var name = '';
                        var hasAvatar = true;

                        if (card) {
                            var link = card.querySelector('a[role=""link""], span[dir=""auto""]');
                            if (link) name = (link.innerText || '').trim();

                            var img = card.querySelector('image, img');
                            if (img) {
                                var src = img.getAttribute('xlink:href') || img.src || '';
                                if (src.indexOf('rsrc.php') !== -1 || src.indexOf('silhouette') !== -1) {
                                    hasAvatar = false;
                                }
                            }
                        }

                        if (filterVn && name && !isVn(name)) {
                            btn.setAttribute('data-lc-fof-done', '1');
                            continue;
                        }
                        if (filterAvatar && !hasAvatar) {
                            btn.setAttribute('data-lc-fof-done', '1');
                            continue;
                        }

                        btn.setAttribute('data-lc-fof-done', '1');
                        btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        btn.click();
                        return JSON.stringify({ status: 'ok', name: name });
                    }

                    window.scrollBy(0, 800);
                    return JSON.stringify({ status: 'scroll' });
                })()";

                string res = chrome.method_14(jsFriendsOfUid);
                if (string.IsNullOrEmpty(res))
                {
                    chrome.method_14("window.scrollBy(0, 700);");
                    chrome.F8091028(2.0);
                    scrollAttempts++;
                    if (scrollAttempts > 6) break;
                    continue;
                }

                try
                {
                    JObject jRes = JObject.Parse(res);
                    string status = (string)jRes["status"];
                    if (status == "ok")
                    {
                        scrollAttempts = 0;
                        countSuccess++;
                        string fName = (string)jRes["name"] ?? "";
                        mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã gửi kết bạn bạn của UID {countSuccess}/{targetCount} ({fName})");

                        if (countSuccess < targetCount)
                        {
                            mainForm.method_131(rowIndex, $"{accStatusPrefix}: Giãn cách...", delayFrom, delayTo);
                        }
                    }
                    else if (status == "scroll")
                    {
                        scrollAttempts++;
                        chrome.F8091028(2.0);
                        if (scrollAttempts > 8) break;
                    }
                }
                catch
                {
                    chrome.method_14("window.scrollBy(0, 600);");
                    chrome.F8091028(2.0);
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất kết bạn bạn của UID ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi kết bạn bạn của UID: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 6: Xác nhận lời mời kết bạn (HDXacNhanKetBan)
    public static int XacNhanKetBan(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool filterVnName = config.method_3("ckbChiKetBanTenCoDau");
            bool filterMutual = config.method_3("ckbOnlyAddFriendWithMutualFriends");
            bool filterAvatar = config.method_3("ckbBoQuaNickKhongAvatar", false);

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở danh sách lời mời kết bạn đến...");
            chrome.method_12("https://www.facebook.com/friends/requests");
            chrome.F8091028(3.5);

            int scrollAttempts = 0;
            while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
            {
                string jsConfirm = @"(() => {
                    var filterVn = " + (filterVnName ? "true" : "false") + @";
                    var filterMutual = " + (filterMutual ? "true" : "false") + @";
                    var filterAvatar = " + (filterAvatar ? "true" : "false") + @";

                    function isVn(str) {
                        if (!str) return false;
                        var reg = /[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]/i;
                        if (reg.test(str)) return true;
                        var surnames = ['nguyen','tran','le','pham','hoang','huynh','phan','vu','vo','dang','bui','do','ho','ngo','duong','dinh','dao','doan','mai','truong','thanh','quang','minh'];
                        var words = str.toLowerCase().split(/\s+/);
                        var hits = 0;
                        for (var w of words) { if (surnames.includes(w)) hits++; }
                        return hits >= 1;
                    }

                    var buttons = document.querySelectorAll('[role=""button""][aria-label*=""Xác nhận"" i], [role=""button""][aria-label*=""Confirm"" i], div[aria-label=""Xác nhận"" i], div[aria-label=""Confirm"" i], button[aria-label*=""Xác nhận"" i], button[aria-label*=""Confirm"" i]');
                    for (var btn of buttons) {
                        if (btn.getAttribute('data-lc-confirm-done') === '1') continue;

                        var card = btn.closest('[role=""listitem""]') || btn.closest('[role=""article""]') || btn.parentElement.parentElement;
                        var name = '';
                        var mutualCount = 0;
                        var hasAvatar = true;

                        if (card) {
                            var link = card.querySelector('a[role=""link""], span[dir=""auto""]');
                            if (link) name = (link.innerText || '').trim();

                            var cardText = card.innerText || '';
                            var mMatch = cardText.match(/(\d+)\s*(?:bạn\s*chung|mutual)/i);
                            if (mMatch) mutualCount = parseInt(mMatch[1], 10);

                            var img = card.querySelector('image, img');
                            if (img) {
                                var src = img.getAttribute('xlink:href') || img.src || '';
                                if (src.indexOf('rsrc.php') !== -1 || src.indexOf('silhouette') !== -1) {
                                    hasAvatar = false;
                                }
                            }
                        }

                        if (filterVn && name && !isVn(name)) {
                            btn.setAttribute('data-lc-confirm-done', '1');
                            continue;
                        }
                        if (filterMutual && mutualCount < 1) {
                            btn.setAttribute('data-lc-confirm-done', '1');
                            continue;
                        }
                        if (filterAvatar && !hasAvatar) {
                            btn.setAttribute('data-lc-confirm-done', '1');
                            continue;
                        }

                        btn.setAttribute('data-lc-confirm-done', '1');
                        btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        btn.click();
                        return JSON.stringify({ status: 'ok', name: name, mutual: mutualCount });
                    }

                    window.scrollBy(0, 800);
                    return JSON.stringify({ status: 'scroll' });
                })()";

                string res = chrome.method_14(jsConfirm);
                if (string.IsNullOrEmpty(res))
                {
                    chrome.method_14("window.scrollBy(0, 700);");
                    chrome.F8091028(2.0);
                    scrollAttempts++;
                    if (scrollAttempts > 5) break;
                    continue;
                }

                try
                {
                    JObject jRes = JObject.Parse(res);
                    string status = (string)jRes["status"];
                    if (status == "ok")
                    {
                        scrollAttempts = 0;
                        countSuccess++;
                        string rName = (string)jRes["name"] ?? "";
                        mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã xác nhận lời mời {countSuccess}/{targetCount} ({rName})");

                        if (countSuccess < targetCount)
                        {
                            mainForm.method_131(rowIndex, $"{accStatusPrefix}: Nghỉ giãn cách...", delayFrom, delayTo);
                        }
                    }
                    else if (status == "scroll")
                    {
                        scrollAttempts++;
                        chrome.F8091028(2.0);
                        if (scrollAttempts > 6) break;
                    }
                }
                catch
                {
                    chrome.method_14("window.scrollBy(0, 600);");
                    chrome.F8091028(2.0);
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất xác nhận kết bạn ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi xác nhận kết bạn: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 7: Hủy kết bạn (HDHuyKetBan)
    public static int HuyKetBan(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            int typeHuy = config.method_2("typeHuyKetBan", 0); // 0: Theo danh sách bạn bè, 1: Theo UID
            string rawUid = config.BDB80B23("txtUid");
            List<string> uids = rawUid.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(u => u.Trim())
                                      .Where(u => !string.IsNullOrEmpty(u))
                                      .ToList();

            // Nếu người dùng chọn hủy theo danh sách UID
            if (typeHuy == 1 || (uids.Count > 0 && config.method_3("ckbHuyTheoUid")))
            {
                while (!Base.smethod_5() && uids.Count > 0 && countSuccess < targetCount && !chrome.CD930D04())
                {
                    string targetUid = uids[0];
                    uids.RemoveAt(0);

                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở profile để hủy kết bạn UID: {targetUid}...");
                    string profileUrl = targetUid.All(char.IsDigit) ? $"https://www.facebook.com/profile.php?id={targetUid}" : $"https://www.facebook.com/{targetUid}";
                    chrome.method_12(profileUrl);
                    chrome.F8091028(3.0);

                    // Bấm nút 'Bạn bè' -> Menu 'Hủy kết bạn' -> Modal 'Xác nhận'
                    string jsUnfriendProfile = @"(() => {
                        var btnFriends = document.querySelector('[role=""button""][aria-label=""Bạn bè"" i], [role=""button""][aria-label=""Friends"" i], div[aria-label=""Bạn bè"" i], div[aria-label=""Friends"" i]');
                        if (!btnFriends) return 'not_friend';
                        btnFriends.click();
                        return 'opened_menu';
                    })()";

                    string res = chrome.method_14(jsUnfriendProfile);
                    if (res == "opened_menu")
                    {
                        chrome.F8091028(1.5);
                        // Bấm 'Hủy kết bạn' trong menu
                        string jsClickMenuItem = @"(() => {
                            var items = document.querySelectorAll('[role=""menuitem""], div[role=""menu""] span, div[role=""menu""] div');
                            for (var it of items) {
                                var txt = (it.innerText || '').trim();
                                if (txt.indexOf('Hủy kết bạn') !== -1 || txt.indexOf('Unfriend') !== -1) {
                                    it.click();
                                    return 'menu_clicked';
                                }
                            }
                            return 'item_not_found';
                        })()";

                        string resItem = chrome.method_14(jsClickMenuItem);
                        if (resItem == "menu_clicked")
                        {
                            chrome.F8091028(1.5);
                            // Bấm Xác nhận trong dialog
                            string jsConfirmDialog = @"(() => {
                                var confirmBtns = document.querySelectorAll('[role=""dialog""] [role=""button""], [role=""dialog""] button');
                                for (var b of confirmBtns) {
                                    var txt = (b.innerText || '').trim();
                                    if (txt === 'Xác nhận' || txt === 'Confirm' || txt === 'Hủy kết bạn' || txt === 'Unfriend') {
                                        b.click();
                                        return 'confirmed';
                                    }
                                }
                                return 'dialog_not_found';
                            })()";
                            string confRes = chrome.method_14(jsConfirmDialog);
                            if (confRes == "confirmed")
                            {
                                countSuccess++;
                                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã hủy kết bạn UID: {targetUid} ({countSuccess}/{targetCount})");
                                if (countSuccess < targetCount && uids.Count > 0)
                                {
                                    mainForm.method_131(rowIndex, $"{accStatusPrefix}: Chờ tiếp...", delayFrom, delayTo);
                                }
                                continue;
                            }
                        }
                    }
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Không thể hủy kết bạn UID: {targetUid}");
                }
            }
            else
            {
                // Hủy bạn bè từ trang danh sách bạn bè
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở danh sách bạn bè...");
                chrome.method_12("https://www.facebook.com/me/friends");
                chrome.F8091028(3.5);

                while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
                {
                    // Click nút 3 chấm hoặc nút Bạn bè trên từng dòng bạn
                    string jsOpenMore = @"(() => {
                        var btns = document.querySelectorAll('[role=""button""][aria-label*=""Khác"" i], [role=""button""][aria-label*=""More"" i], [role=""button""][aria-label*=""Bạn bè"" i], [role=""button""][aria-label*=""Friends"" i]');
                        for (var b of btns) {
                            if (b.getAttribute('data-lc-unfriend-done') === '1') continue;
                            b.setAttribute('data-lc-unfriend-done', '1');
                            b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            b.click();
                            return 'opened';
                        }
                        window.scrollBy(0, 800);
                        return 'scroll';
                    })()";

                    string resMore = chrome.method_14(jsOpenMore);
                    if (resMore == "opened")
                    {
                        chrome.F8091028(1.5);
                        // Chọn 'Hủy kết bạn'
                        chrome.method_14(@"(() => {
                            var items = document.querySelectorAll('[role=""menuitem""], div[role=""menu""] span');
                            for (var it of items) {
                                var txt = (it.innerText || '').trim();
                                if (txt.indexOf('Hủy kết bạn') !== -1 || txt.indexOf('Unfriend') !== -1) {
                                    it.click();
                                    return;
                                }
                            }
                        })()");
                        chrome.F8091028(1.5);
                        // Xác nhận dialog
                        string conf = chrome.method_14(@"(() => {
                            var confirmBtns = document.querySelectorAll('[role=""dialog""] [role=""button""], [role=""dialog""] button');
                            for (var b of confirmBtns) {
                                var txt = (b.innerText || '').trim();
                                if (txt === 'Xác nhận' || txt === 'Confirm' || txt === 'Hủy kết bạn' || txt === 'Unfriend') {
                                    b.click();
                                    return 'confirmed';
                                }
                            }
                            return 'none';
                        })()");

                        if (conf == "confirmed")
                        {
                            countSuccess++;
                            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã hủy kết bạn {countSuccess}/{targetCount}");
                            if (countSuccess < targetCount)
                            {
                                mainForm.method_131(rowIndex, $"{accStatusPrefix}: Giãn cách...", delayFrom, delayTo);
                            }
                        }
                    }
                    else
                    {
                        chrome.F8091028(2.0);
                    }
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất hủy kết bạn ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi hủy kết bạn: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 8: Hủy lời mời kết bạn đã gửi (HDHuyLoiMoiKetBan)
    public static int HuyLoiMoiKetBan(fMain mainForm, int rowIndex, string chromePrefix, Chrome chrome, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, string actionName)
    {
        int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);
        return FacebookFriendAutomationHelper.CancelPendingSentRequests(mainForm, rowIndex, chromePrefix, chrome, targetCount, delayFrom, delayTo);
    }
    #endregion

    #region Feature 9: Chọc bạn bè (HDChocBanBe)
    public static int ChocBanBe(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở trang Chọc bạn bè...");
            chrome.method_12("https://www.facebook.com/pokes");
            chrome.F8091028(3.5);

            int scrollAttempts = 0;
            while (!Base.smethod_5() && countSuccess < targetCount && !chrome.CD930D04())
            {
                // Bấm nút 'Chọc lại' hoặc 'Chọc' (chưa chọc)
                string jsPoke = @"(() => {
                    var selectors = [
                        '[role=""button""][aria-label*=""Chọc lại"" i]',
                        '[role=""button""][aria-label*=""Chọc"" i]',
                        '[role=""button""][aria-label*=""Poke back"" i]',
                        '[role=""button""][aria-label*=""Poke"" i]'
                    ];
                    for (var sel of selectors) {
                        var buttons = document.querySelectorAll(sel);
                        for (var btn of buttons) {
                            var aria = btn.getAttribute('aria-label') || '';
                            if (aria.includes('Đã chọc') || aria.includes('Poked')) continue;
                            if (btn.getAttribute('data-lc-poke-done') === '1') continue;

                            btn.setAttribute('data-lc-poke-done', '1');
                            btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            btn.click();
                            return 'poked';
                        }
                    }

                    // Fallback theo text của button
                    var allBtns = document.querySelectorAll('[role=""button""], button');
                    for (var b of allBtns) {
                        var txt = (b.innerText || '').trim();
                        if ((txt === 'Chọc lại' || txt === 'Chọc' || txt === 'Poke back' || txt === 'Poke') && b.getAttribute('data-lc-poke-done') !== '1') {
                            b.setAttribute('data-lc-poke-done', '1');
                            b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            b.click();
                            return 'poked';
                        }
                    }

                    window.scrollBy(0, 800);
                    return 'scroll';
                })()";

                string res = chrome.method_14(jsPoke);
                if (res == "poked")
                {
                    scrollAttempts = 0;
                    countSuccess++;
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã chọc bạn bè {countSuccess}/{targetCount}");

                    if (countSuccess < targetCount)
                    {
                        mainForm.method_131(rowIndex, $"{accStatusPrefix}: Chờ tiếp...", delayFrom, delayTo);
                    }
                }
                else if (res == "scroll")
                {
                    scrollAttempts++;
                    chrome.F8091028(2.0);
                    if (scrollAttempts > 5) break;
                }
                else
                {
                    chrome.F8091028(2.0);
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất chọc bạn bè ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi chọc bạn bè: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion

    #region Feature 10: Chúc mừng sinh nhật (HDChucMungSinhNhat)
    public static int ChucMungSinhNhat(fMain mainForm, int rowIndex, string accStatusPrefix, Chrome chrome, GClass4 config, string actionName)
    {
        int countSuccess = 0;
        try
        {
            int soLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int soLuongTo = config.method_2("nudSoLuongTo", 3);
            int delayFrom = config.method_2("nudDelayFrom", 3);
            int delayTo = config.method_2("nudDelayTo", 5);
            int targetCount = _rand.Next(soLuongFrom, soLuongTo + 1);

            bool sendMsg = config.method_3("ckbGuiTinNhan", true);
            bool postWall = config.method_3("ckbDangTuong", false);
            string rawContent = config.BDB80B23("txtNoiDung");
            if (string.IsNullOrWhiteSpace(rawContent))
            {
                rawContent = "Chúc mừng sinh nhật {bạn|bạn yêu|bạn nhé}! Chúc bạn {thêm tuổi mới luôn vui vẻ, may mắn và hạnh phúc|sinh nhật vui vẻ, luôn ngập tràn niềm vui và gặt hái nhiều thành công|sinh nhật thật ý nghĩa và ấm áp} nha! 🎉🎂";
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đang mở danh sách bạn bè sinh nhật hôm nay...");
            chrome.method_12("https://www.facebook.com/events/birthdays/");
            chrome.F8091028(4.0);

            // Quét danh sách bạn bè có sinh nhật hôm nay
            string jsScanBirthdays = @"(() => {
                var list = [];
                var main = document.querySelector('[role=""main""]') || document.body;
                var cards = main.querySelectorAll('[role=""article""], [role=""listitem""], div[data-visualcompletion=""ignore-dynamic""]');
                for (var card of cards) {
                    var link = card.querySelector('a[href*=""/profile.php""], a[role=""link""]');
                    var name = link ? (link.innerText || '').trim() : '';
                    var href = link ? link.href : '';
                    if (!name || name.length < 2) continue;

                    var hasTextbox = card.querySelector('[role=""textbox""], textarea') !== null;
                    var hasMsgBtn = card.querySelector('[role=""button""][aria-label*=""Nhắn tin"" i], [role=""button""][aria-label*=""Message"" i]') !== null;

                    if (hasTextbox || hasMsgBtn) {
                        list.push({ name: name, href: href });
                    }
                }
                return JSON.stringify(list);
            })()";

            string bdayListJson = chrome.method_14(jsScanBirthdays);
            List<JObject> birthdayFriends = new List<JObject>();
            if (!string.IsNullOrEmpty(bdayListJson) && bdayListJson.StartsWith("["))
            {
                try
                {
                    JArray arr = JArray.Parse(bdayListJson);
                    foreach (var item in arr)
                    {
                        birthdayFriends.Add((JObject)item);
                    }
                }
                catch { }
            }

            if (birthdayFriends.Count == 0)
            {
                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Không tìm thấy bạn bè nào có sinh nhật hôm nay!");
                return 0;
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Tìm thấy {birthdayFriends.Count} bạn bè sinh nhật hôm nay. Bắt đầu gửi chúc mừng...");

            for (int i = 0; i < birthdayFriends.Count && countSuccess < targetCount; i++)
            {
                if (Base.smethod_5() || chrome.CD930D04()) break;

                var friendObj = birthdayFriends[i];
                string friendName = (string)friendObj["name"] ?? "";
                string profileHref = (string)friendObj["href"] ?? "";
                string greeting = SpinText(rawContent, friendName);

                mainForm.method_130(rowIndex, $"{accStatusPrefix}: Chúc mừng sinh nhật bạn '{friendName}' ({countSuccess + 1}/{targetCount})...");

                bool sent = false;

                // Cách 1: Đăng lên dòng thời gian (Wall) nếu bật ckbDangTuong
                if (postWall)
                {
                    string jsPostWall = @"(() => {
                        var targetName = " + Newtonsoft.Json.JsonConvert.SerializeObject(friendName) + @";
                        var textToPost = " + Newtonsoft.Json.JsonConvert.SerializeObject(greeting) + @";
                        var cards = document.querySelectorAll('[role=""main""] [role=""article""], [role=""main""] [role=""listitem""]');
                        for (var c of cards) {
                            if ((c.innerText || '').indexOf(targetName) !== -1) {
                                var tb = c.querySelector('[role=""textbox""][contenteditable=""true""], textarea');
                                if (tb) {
                                    tb.focus();
                                    document.execCommand('insertText', false, textToPost);
                                    
                                    var postBtn = c.querySelector('[role=""button""][aria-label*=""Đăng"" i], [role=""button""][aria-label*=""Post"" i], button');
                                    if (postBtn) {
                                        postBtn.click();
                                        return 'posted';
                                    }
                                    return 'typed';
                                }
                            }
                        }
                        return 'not_found';
                    })()";

                    string pRes = chrome.method_14(jsPostWall);
                    if (pRes == "posted" || pRes == "typed")
                    {
                        if (pRes == "typed")
                        {
                            chrome.F217FA96("[role=\"main\"] [role=\"textbox\"]");
                        }
                        sent = true;
                    }
                }

                // Cách 2: Gửi tin nhắn Messenger riêng (nếu ckbGuiTinNhan hoặc wall không khả dụng)
                if (!sent && sendMsg)
                {
                    string friendUid = "";
                    Match m = Regex.Match(profileHref, @"[?&]id=(\d+)");
                    if (m.Success)
                    {
                        friendUid = m.Groups[1].Value;
                    }
                    else
                    {
                        Match m2 = Regex.Match(profileHref, @"facebook\.com/([^/?]+)");
                        if (m2.Success && !m2.Groups[1].Value.Contains("events"))
                        {
                            friendUid = m2.Groups[1].Value;
                        }
                    }

                    if (!string.IsNullOrEmpty(friendUid))
                    {
                        chrome.method_12($"https://www.facebook.com/messages/t/{friendUid}");
                        chrome.F8091028(3.5);

                        string msgSelector = "[role=\"main\"] [role=\"textbox\"][contenteditable=\"true\"], div[contenteditable=\"true\"][role=\"textbox\"]";
                        if (chrome.D7A424AE(msgSelector, 5.0))
                        {
                            chrome.AE3408BC(msgSelector, greeting, true);
                            chrome.F8091028(1.0);
                            chrome.F217FA96(msgSelector);
                            sent = true;
                        }
                    }
                }

                if (sent)
                {
                    countSuccess++;
                    mainForm.method_130(rowIndex, $"{accStatusPrefix}: Đã gửi lời chúc sinh nhật đến '{friendName}' ({countSuccess}/{targetCount})");

                    if (countSuccess < targetCount && i < birthdayFriends.Count - 1)
                    {
                        mainForm.method_131(rowIndex, $"{accStatusPrefix}: Giãn cách giữa các lời chúc...", delayFrom, delayTo);
                    }
                }
            }

            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Hoàn tất chúc mừng sinh nhật ({countSuccess}/{targetCount})");
        }
        catch (Exception ex)
        {
            mainForm.method_130(rowIndex, $"{accStatusPrefix}: Lỗi chúc mừng sinh nhật: {ex.Message}");
        }
        return countSuccess;
    }
    #endregion
}
