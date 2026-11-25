using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class TangTuongTacHub
{
    private static readonly Random _rng = new Random();

    private static void Sleep(double sec)
    {
        Commom.smethod_52(sec);
    }

    private static int RandomDelay(int from, int to)
    {
        return (to > from && from > 0) ? _rng.Next(from, to + 1) : from;
    }

    /// <summary>
    /// Phân giải spintax {a|b|c} ngẫu nhiên cho nội dung bình luận / chia sẻ
    /// </summary>
    public static string SpinText(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        try
        {
            var regex = new Regex(@"\{([^{}]+)\}");
            while (regex.IsMatch(text))
            {
                text = regex.Replace(text, m =>
                {
                    var parts = m.Groups[1].Value.Split('|');
                    return parts[_rng.Next(parts.Length)];
                });
            }
        }
        catch { }
        return text;
    }

    /// <summary>
    /// Lấy danh sách tất cả các Page của tài khoản (New Page Experience / Profile Page)
    /// </summary>
    public static List<string> GetAllPages(Chrome chrome, Action<string> log = null)
    {
        var list = new List<string>();
        try
        {
            if (chrome == null) return list;

            // Cách 1: Gọi hàm lấy Page tích hợp sẵn của Chrome
            var fromChrome = chrome.BE0C6B9C();
            if (fromChrome != null && fromChrome.Count > 0)
            {
                foreach (var p in fromChrome)
                {
                    string clean = (p ?? "").Trim();
                    if (!string.IsNullOrEmpty(clean) && !list.Contains(clean))
                    {
                        list.Add(clean);
                    }
                }
            }

            if (list.Count > 0)
            {
                log?.Invoke($"Lấy được {list.Count} Page từ tài khoản.");
                return list;
            }

            // Cách 2: Quét trực tiếp trang category=your_pages
            log?.Invoke("Quét danh sách Page qua facebook.com/pages/?category=your_pages...");
            chrome.method_12("https://www.facebook.com/pages/?category=your_pages");
            Sleep(2.5);

            string script = @"
                (() => {
                    var set = new Set();
                    document.querySelectorAll('a[href*=""/latest/""], a[href*=""facebook.com/""], a[href*=""/pages/""]').forEach(a => {
                        var h = a.getAttribute('href') || '';
                        var m = h.match(/(?:asset_id=([0-9]+)|facebook\.com\/([0-9]{8,}))/);
                        if (m) {
                            var pid = m[1] || m[2];
                            if (pid) set.add(pid);
                        }
                    });
                    return Array.from(set).join('|');
                })()
            ";
            string res = chrome.method_14(script) as string;
            if (!string.IsNullOrEmpty(res))
            {
                var arr = res.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in arr)
                {
                    string pid = item.Trim();
                    if (!string.IsNullOrEmpty(pid) && !list.Contains(pid))
                    {
                        list.Add(pid);
                    }
                }
            }

            log?.Invoke($"Tìm thấy {list.Count} Page trong tài khoản.");
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi GetAllPages: " + ex.Message);
        }
        return list;
    }

    /// <summary>
    /// Chuyển ngữ cảnh tài khoản sang 1 Page cụ thể (Switch Profile Comet)
    /// </summary>
    public static bool SwitchToPage(Chrome chrome, string pageTarget, Action<string> log = null)
    {
        try
        {
            if (chrome == null || string.IsNullOrWhiteSpace(pageTarget)) return false;

            string target = pageTarget.Trim();
            string cleanId = Regex.Match(target, @"\d{8,}").Value;

            // Nếu là numeric ID hoặc URL có ID
            if (!string.IsNullOrEmpty(cleanId))
            {
                log?.Invoke($"Chuyển ngữ cảnh sang Page ID: {cleanId}...");
                chrome.method_87(cleanId);
                Sleep(2.0);
                return true;
            }

            // Nếu là URL vanity name (facebook.com/myfanpage)
            string url = target.StartsWith("http") ? target : "https://www.facebook.com/" + target.TrimStart('/');
            log?.Invoke($"Mở trang Page: {url}...");
            chrome.method_12(url);
            Sleep(3.0);

            // Bấm nút 'Chuyển sang' / 'Switch Now' nếu có
            string jsSwitch = @"
                (() => {
                    var btns = Array.from(document.querySelectorAll('[role=""button""], button'));
                    for (var b of btns) {
                        var txt = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase();
                        if (txt.includes('chuyển ngay') || txt.includes('chuyển sang') || txt.includes('switch now') || txt.includes('switch to')) {
                            b.click();
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                })()
            ";
            string swRes = chrome.method_14(jsSwitch) as string;
            if (swRes == "clicked")
            {
                Sleep(3.0);
                log?.Invoke("Đã nhấn nút Chuyển sang ngữ cảnh Page.");
                return true;
            }

            // Trích xuất ID từ DOM nếu nút không click được
            string pageSrc = chrome.method_14("document.documentElement.innerHTML") as string;
            if (!string.IsNullOrEmpty(pageSrc))
            {
                var match = Regex.Match(pageSrc, @"""page_id"":""(\d+)""|""delegate_page"":\{""id"":""(\d+)""\}");
                string extId = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
                if (!string.IsNullOrEmpty(extId))
                {
                    log?.Invoke($"Trích xuất được Page ID: {extId}, chuyển actor cookie...");
                    chrome.method_87(extId);
                    Sleep(2.0);
                    return true;
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi SwitchToPage: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Chuyển ngữ cảnh trở lại Profile cá nhân gốc
    /// </summary>
    public static void SwitchToPersonalProfile(Chrome chrome, Action<string> log = null)
    {
        try
        {
            if (chrome == null) return;
            log?.Invoke("Chuyển về Profile cá nhân gốc...");
            chrome.method_87("");
            Sleep(1.5);
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi SwitchToPersonalProfile: " + ex.Message);
        }
    }

    /// <summary>
    /// Follow profile/page trên Facebook Comet.
    /// Tự động tìm nút Theo dõi / Follow (cả menu 3 chấm) và hỗ trợ fallback FacebookActionsHub.
    /// </summary>
    public static bool FollowProfile(Chrome chrome, string url, Action<string> log = null)
    {
        try
        {
            if (chrome == null) return false;

            string targetUrl = (url ?? "").Trim();
            if (string.IsNullOrEmpty(targetUrl)) return false;

            if (!targetUrl.StartsWith("http://") && !targetUrl.StartsWith("https://"))
            {
                targetUrl = "https://www.facebook.com/" + targetUrl.TrimStart('/');
            }

            log?.Invoke($"Mở trang Follow: {targetUrl}...");
            chrome.method_12(targetUrl);
            Sleep(2.5);

            if (chrome.method_125() == 1)
            {
                log?.Invoke("Tài khoản bị checkpoint!");
                return false;
            }

            chrome.EC9B94B0();

            // 1. Dùng JS DOM click nút Theo dõi
            string jsCode = @"
                (() => {
                    var allSpans = Array.from(document.querySelectorAll('span'));
                    if (allSpans.some(s => s.innerText && (s.innerText.includes('Đang theo dõi') || s.innerText.includes('Following')))) {
                        return 'already';
                    }

                    var selectors = [
                        ""div[role='button'][aria-label*='Theo dõi' i]"",
                        ""div[role='button'][aria-label*='Follow' i]"",
                        ""button[aria-label*='Theo dõi' i]"",
                        ""button[aria-label*='Follow' i]"",
                        ""div[aria-label*='Theo dõi' i]"",
                        ""div[aria-label*='Follow' i]""
                    ];

                    for (var sel of selectors) {
                        var el = document.querySelector(sel);
                        if (el) {
                            el.click();
                            return 'clicked';
                        }
                    }

                    var moreBtn = document.querySelector(""div[aria-label*='Xem thêm' i], div[aria-label*='More' i], div[aria-label*='Hành động khác' i]"");
                    if (moreBtn) {
                        moreBtn.click();
                        return 'opened_menu';
                    }

                    return 'not_found';
                })()
            ";

            string status = chrome.method_14(jsCode);
            if (status == "already")
            {
                log?.Invoke("Đã theo dõi từ trước.");
                return true;
            }

            if (status == "clicked")
            {
                Sleep(1.5);
                log?.Invoke("Đã nhấn Theo dõi thành công.");
                return true;
            }

            if (status == "opened_menu")
            {
                Sleep(1.2);
                string jsMenu = @"
                    (() => {
                        var items = Array.from(document.querySelectorAll(""div[role='menuitem'], div[role='menu'] span, div[role='menu'] div""));
                        for (var it of items) {
                            var txt = (it.innerText || '').toLowerCase();
                            if (txt.includes('theo dõi') || txt.includes('follow')) {
                                it.click();
                                return 'clicked';
                            }
                        }
                        return 'not_found';
                    })()
                ";
                string menuStatus = chrome.method_14(jsMenu);
                if (menuStatus == "clicked")
                {
                    Sleep(1.5);
                    log?.Invoke("Đã nhấn Theo dõi từ menu thành công.");
                    return true;
                }
            }

            // 2. Fallback native qua FacebookActionsHub
            try
            {
                string res = FacebookActionsHub.Execute(chrome, "followwww", JsonConvert.SerializeObject(new { url = targetUrl }));
                if (!string.IsNullOrEmpty(res) && res.Contains("\"success\":true"))
                {
                    log?.Invoke("Theo dõi thành công qua ActionsHub.");
                    return true;
                }
            }
            catch { }

            log?.Invoke("Không tìm thấy nút Theo dõi.");
            return false;
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi FollowProfile: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Tương tác bài viết chi tiết (Thả cảm xúc ngẫu nhiên theo danh sách chọn, Bình luận kèm Spintax + ảnh, Chia sẻ lên Tường)
    /// </summary>
    public static bool TuongTacBaiViet(
        Chrome chrome,
        string postUrl,
        string reactions,
        bool doComment,
        List<string> comments,
        bool doShare,
        bool shareWall,
        bool doSendImg,
        List<string> imgPaths,
        int delayActionFrom,
        int delayActionTo,
        Action<string> log = null)
    {
        bool hasSuccess = false;
        try
        {
            if (chrome == null) return false;

            string targetUrl = (postUrl ?? "").Trim();
            if (!string.IsNullOrEmpty(targetUrl))
            {
                if (!targetUrl.StartsWith("http://") && !targetUrl.StartsWith("https://"))
                {
                    targetUrl = "https://www.facebook.com/" + targetUrl.TrimStart('/');
                }

                log?.Invoke($"Mở bài viết: {targetUrl}...");
                chrome.method_12(targetUrl);
                Sleep(3.0);
            }

            if (chrome.method_125() == 1)
            {
                log?.Invoke("Tài khoản bị checkpoint!");
                return false;
            }

            chrome.EC9B94B0();

            // 1. Thả Reaction (Like, Love, Care, Haha, Wow, Sad, Angry)
            if (!string.IsNullOrEmpty(reactions))
            {
                var reactOptions = reactions.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(r => r.Trim())
                    .Where(r => !string.IsNullOrEmpty(r))
                    .ToList();

                if (reactOptions.Count > 0)
                {
                    string chosenReaction = reactOptions[_rng.Next(reactOptions.Count)];
                    log?.Invoke($"Thả cảm xúc {chosenReaction}...");

                    bool reactOk = false;
                    if (chosenReaction.Equals("Like", StringComparison.OrdinalIgnoreCase))
                    {
                        string jsLike = @"
                            (() => {
                                var btn = document.querySelector(""div[role='button'][aria-label*='Thích' i], div[role='button'][aria-label*='Like' i], span[data-testid*='like']"");
                                if (!btn) {
                                    var btns = Array.from(document.querySelectorAll(""div[role='button']""));
                                    btn = btns.find(b => {
                                        var label = (b.getAttribute('aria-label') || '').toLowerCase();
                                        return label === 'thích' || label === 'like';
                                    });
                                }
                                if (btn) {
                                    var pressed = btn.getAttribute('aria-pressed');
                                    if (pressed === 'true') return 'already';
                                    btn.click();
                                    return 'ok';
                                }
                                return 'not_found';
                            })()
                        ";
                        string likeRes = chrome.method_14(jsLike);
                        if (likeRes == "ok" || likeRes == "already")
                        {
                            reactOk = true;
                            log?.Invoke("Đã thả cảm xúc Like.");
                        }
                    }

                    if (!reactOk)
                    {
                        try
                        {
                            string hubParam = JsonConvert.SerializeObject(new { url = targetUrl, reaction = chosenReaction, type = chosenReaction });
                            string res = FacebookActionsHub.Execute(chrome, "reactionwww", hubParam);
                            if (!string.IsNullOrEmpty(res) && res.Contains("\"success\":true"))
                            {
                                reactOk = true;
                                log?.Invoke($"Đã thả cảm xúc {chosenReaction} thành công.");
                            }
                        }
                        catch { }
                    }

                    if (reactOk) hasSuccess = true;

                    int delayReact = RandomDelay(delayActionFrom, delayActionTo);
                    chrome.F8091028(delayReact);
                }
            }

            // 2. Bình luận (Comment) kèm Spintax {a|b|c} và ảnh đính kèm
            if (doComment && comments != null && comments.Count > 0)
            {
                var validComments = comments.Where(c => !string.IsNullOrWhiteSpace(c)).ToList();
                if (validComments.Count > 0)
                {
                    string rawCmt = validComments[_rng.Next(validComments.Count)].Trim();
                    string cmt = SpinText(rawCmt);

                    string imgFile = "";
                    if (doSendImg && imgPaths != null && imgPaths.Count > 0)
                    {
                        var validImgs = imgPaths.Where(File.Exists).ToList();
                        if (validImgs.Count > 0)
                        {
                            imgFile = validImgs[_rng.Next(validImgs.Count)];
                        }
                    }

                    log?.Invoke($"Bình luận: \"{(cmt.Length > 30 ? cmt.Substring(0, 30) + "..." : cmt)}\"...");

                    bool commentOk = false;
                    try
                    {
                        string hubParam = JsonConvert.SerializeObject(new
                        {
                            url = targetUrl,
                            content = cmt,
                            image = imgFile
                        });
                        string res = FacebookActionsHub.Execute(chrome, "commentwww", hubParam);
                        if (!string.IsNullOrEmpty(res) && res.Contains("\"success\":true"))
                        {
                            commentOk = true;
                            log?.Invoke("Bình luận thành công.");
                        }
                    }
                    catch { }

                    if (commentOk) hasSuccess = true;

                    int delayCmt = RandomDelay(delayActionFrom, delayActionTo);
                    chrome.F8091028(delayCmt);
                }
            }

            // 3. Chia sẻ lên Tường (Share)
            if (doShare && shareWall)
            {
                log?.Invoke("Chia sẻ bài viết lên Tường...");
                bool shareOk = false;
                try
                {
                    string hubParam = JsonConvert.SerializeObject(new
                    {
                        url = targetUrl
                    });
                    string res = FacebookActionsHub.Execute(chrome, "sharewallwww", hubParam);
                    if (!string.IsNullOrEmpty(res) && res.Contains("\"success\":true"))
                    {
                        shareOk = true;
                        log?.Invoke("Chia sẻ lên Tường thành công.");
                    }
                }
                catch { }

                if (shareOk) hasSuccess = true;
            }
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi TuongTacBaiViet: " + ex.Message);
        }

        return hasSuccess;
    }

    /// <summary>
    /// Tự động lướt Newsfeed và tương tác các bài viết ngẫu nhiên
    /// </summary>
    public static void TuongTacNewsfeed(
        Chrome chrome,
        string reactions,
        bool doComment,
        List<string> comments,
        bool doShare,
        bool shareWall,
        int delayActFrom,
        int delayActTo,
        Action<string> log = null)
    {
        try
        {
            if (chrome == null) return;

            log?.Invoke("Mở trang chủ facebook.com để lấy bài viết Newsfeed...");
            chrome.method_12("https://www.facebook.com");
            Sleep(2.5);

            if (chrome.method_125() == 1)
            {
                log?.Invoke("Tài khoản bị checkpoint!");
                return;
            }

            chrome.EC9B94B0();

            // Cuộn trang nhẹ nhàng để tải bài viết
            chrome.method_14("window.scrollBy(0, 500);");
            Sleep(1.5);

            // Lấy danh sách link bài viết trên feed
            var postLinks = chrome.method_14(@"
                (() => {
                    var links = new Set();
                    document.querySelectorAll('a[href*=""/posts/""], a[href*=""?story_fbid=""]').forEach(a => {
                        if (a.href && a.href.includes('facebook.com')) links.add(a.href);
                    });
                    return Array.from(links).slice(0, 5).join('|');
                })()
            ") as string;

            if (!string.IsNullOrEmpty(postLinks))
            {
                var list = postLinks.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                log?.Invoke($"Tìm thấy {list.Count} bài viết trên Newsfeed.");

                foreach (var url in list)
                {
                    TuongTacBaiViet(chrome, url, reactions, doComment, comments, doShare, shareWall, false, new List<string>(), delayActFrom, delayActTo, log);
                    Commom.smethod_52(RandomDelay(delayActFrom, delayActTo));
                }
            }
            else
            {
                log?.Invoke("Không tìm thấy link bài viết nào trên Newsfeed.");
            }
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi TuongTacNewsfeed: " + ex.Message);
        }
    }
}
