using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

/// <summary>
/// LushCare Global - Other Utilities Helper
/// Tự động hóa và tối ưu toàn diện các tính năng Khác:
/// - Tìm kiếm Google organic (Human typing, consent bypass, smart domain matching, pagination, organic onsite browsing & internal links)
/// - Truy cập Website (Same-domain internal link filtering, popup management, organic reading scroll, onsite dwell time)
/// - Rời nhóm Facebook Comet (Bắt modal xác nhận rời nhóm Comet mới, đa ngôn ngữ, dropdown menu, checkbox ngăn thêm lại)
/// - Follow / Like Page & Profile (Đa ngôn ngữ: VN, EN, ES, FR, ID, DE; kiểm tra trạng thái tránh bấm nhầm; menu 3 chấm)
/// - Hủy like page, dọn dẹp bài viết tường cá nhân, báo cáo, liên kết Instagram, chạy GemLogin script.
/// </summary>
public static class OtherUtilitiesHelper
{
    private static readonly Random _rd = new Random();

    #region 1. TÌM KIẾM GOOGLE ORGANIC (HDTimKiemGoogle)

    /// <summary>
    /// Thực hiện tìm kiếm Google tự nhiên với Human Typing, vượt cookie banner, tìm domain đích, phân trang, lướt web và click link nội bộ.
    /// </summary>
    public static int ExecuteGoogleSearch(
        Chrome chrome,
        List<string> keywordList,
        int countTuKhoaFrom,
        int countTuKhoaTo,
        int countPageFrom,
        int countPageTo,
        int countLinkClickFrom,
        int countLinkClickTo,
        int countTimeScrollFrom,
        int countTimeScrollTo,
        Action<string> statusCallback = null,
        Action<string, int, int> delayCallback = null)
    {
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return -2;
        if (keywordList == null || keywordList.Count == 0) return 0;

        int successCount = 0;
        int targetKeywordCount = _rd.Next(Math.Max(1, countTuKhoaFrom), Math.Max(countTuKhoaFrom, countTuKhoaTo) + 1);
        List<string> remainingKeywords = new List<string>(keywordList);

        try
        {
            for (int i = 0; i < targetKeywordCount && remainingKeywords.Count > 0; i++)
            {
                if (chrome.CD930D04() || chrome.E184CD03() || Base.smethod_5()) break;

                string rawItem = remainingKeywords[_rd.Next(0, remainingKeywords.Count)];
                remainingKeywords.Remove(rawItem);

                string[] parts = rawItem.Split('|');
                string keyword = parts[0].Trim();
                string targetDomain = parts.Length > 1 ? parts[1].Trim() : "";

                statusCallback?.Invoke(Language.GetValue("Tìm kiếm Google") + $": '{keyword}' ({i + 1}/{targetKeywordCount})...");

                // 1. Điều hướng tới Google
                chrome.method_12("https://www.google.com");
                SleepHuman(1.5, 2.5);

                // 2. Vượt qua consent banner / cookie notice của Google nếu xuất hiện
                BypassGoogleConsent(chrome);

                // 3. Tìm ô nhập tìm kiếm
                string inputSelector = "textarea[name='q'], input[name='q'], textarea[role='combobox'], [aria-label*='Search' i], [aria-label*='Tìm kiếm' i]";
                if (!chrome.D7A424AE(inputSelector, 4.0))
                {
                    chrome.method_12("https://www.google.com.vn");
                    SleepHuman(1.5, 2.5);
                    BypassGoogleConsent(chrome);
                }

                if (!chrome.D7A424AE(inputSelector, 3.0))
                {
                    continue;
                }

                // 4. Focus và gõ từ khóa như người thật (Human typing)
                chrome.method_35(inputSelector);
                SleepHuman(0.4, 0.8);
                TypeHumanLike(chrome, inputSelector, keyword);
                SleepHuman(0.6, 1.2);

                // Nhấn Enter để gửi truy vấn tìm kiếm
                chrome.F217FA96(inputSelector);
                SleepHuman(2.5, 3.5);

                // 5. Tìm domain đích trên trang kết quả Google
                bool domainFound = false;
                string normalizedDomain = NormalizeDomain(targetDomain);

                if (!string.IsNullOrEmpty(normalizedDomain))
                {
                    int maxPages = _rd.Next(Math.Max(1, countPageFrom), Math.Max(countPageFrom, countPageTo) + 1);

                    for (int page = 1; page <= maxPages; page++)
                    {
                        if (chrome.CD930D04() || Base.smethod_5()) break;

                        // Cuộn nhẹ xem kết quả
                        NaturalScroll(chrome, 2, 3);

                        // Tìm link chứa domain
                        string matchedLinkSelector = FindGoogleResultLink(chrome, normalizedDomain);
                        if (!string.IsNullOrEmpty(matchedLinkSelector))
                        {
                            statusCallback?.Invoke(Language.GetValue("Đã thấy domain") + $" {normalizedDomain} " + Language.GetValue("trang") + $" {page}!");
                            chrome.method_35(matchedLinkSelector);
                            SleepHuman(0.8, 1.5);
                            chrome.method_17(matchedLinkSelector);
                            SleepHuman(3.0, 4.5);
                            domainFound = true;
                            break;
                        }

                        // Nếu chưa thấy và chưa hết số trang cho phép -> Bấm trang tiếp theo
                        if (page < maxPages)
                        {
                            bool nextPageClicked = ClickGoogleNextPage(chrome, page + 1);
                            if (!nextPageClicked) break;
                            SleepHuman(2.5, 3.5);
                        }
                    }

                    // Nếu không tìm thấy domain sau khi phân trang, truy cập trực tiếp domain nếu có URL
                    if (!domainFound)
                    {
                        string directUrl = targetDomain.StartsWith("http") ? targetDomain : "https://" + targetDomain;
                        statusCallback?.Invoke(Language.GetValue("Truy cập trực tiếp") + $": {directUrl}...");
                        chrome.method_12(directUrl);
                        SleepHuman(3.0, 4.5);
                    }
                }
                else
                {
                    // Nếu không có domain đích, click ngẫu nhiên 1 kết quả organic
                    ClickRandomGoogleResult(chrome);
                    SleepHuman(3.0, 4.5);
                }

                // 6. Click link nội bộ (Internal links) trên trang web đích
                int internalLinksToClick = _rd.Next(Math.Max(0, countLinkClickFrom), Math.Max(countLinkClickFrom, countLinkClickTo) + 1);
                if (internalLinksToClick > 0)
                {
                    ExploreInternalLinks(chrome, internalLinksToClick, statusCallback);
                }

                // 7. Giữ chân onsite và cuộn đọc trang tự nhiên
                int lingerSeconds = _rd.Next(Math.Max(5, countTimeScrollFrom), Math.Max(countTimeScrollFrom, countTimeScrollTo) + 1);
                statusCallback?.Invoke(Language.GetValue("Đọc trang đích") + $" ({lingerSeconds}s)...");
                LingerOnsiteNatural(chrome, lingerSeconds);

                successCount++;
                delayCallback?.Invoke(Language.GetValue("Hoàn thành từ khóa") + $" {keyword}", 3, 6);
            }
        }
        catch (Exception ex)
        {
            Commom.smethod_57(chrome, ex, "OtherUtilitiesHelper.ExecuteGoogleSearch");
            return -1;
        }

        return successCount;
    }

    /// <summary>
    /// Vượt qua consent banner / cookie modal của Google
    /// </summary>
    private static void BypassGoogleConsent(Chrome chrome)
    {
        try
        {
            string consentJs = @"(() => {
                try {
                    var btns = document.querySelectorAll('button, div[role=""button""]');
                    for (var i = 0; i < btns.length; i++) {
                        var b = btns[i];
                        var t = (b.innerText || '').toLowerCase().trim();
                        var a = (b.getAttribute('aria-label') || '').toLowerCase().trim();
                        var id = (b.id || '').toLowerCase();
                        if (id === 'l2aglb' || t.includes('i agree') || t.includes('accept all') || 
                            t.includes('tôi đồng ý') || t.includes('chấp nhận') || t.includes('alle akzeptieren') ||
                            t.includes('tout accepter') || a.includes('accept all') || a.includes('tôi đồng ý')) {
                            b.click();
                            return 'clicked';
                        }
                    }
                    var forms = document.querySelectorAll('form[action*=""consent""] button');
                    if (forms.length > 0) {
                        forms[forms.length - 1].click();
                        return 'clicked_form';
                    }
                    return 'none';
                } catch(e) { return 'error'; }
            })()";

            chrome.ChromeDriver_0?.ExecuteScript(consentJs);
            Thread.Sleep(800);
        }
        catch { }
    }

    /// <summary>
    /// Chuẩn hóa domain (bỏ protocol, www, đường dẫn con, query)
    /// </summary>
    private static string NormalizeDomain(string domainOrUrl)
    {
        if (string.IsNullOrWhiteSpace(domainOrUrl)) return "";
        string clean = domainOrUrl.Trim();
        if (clean.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            clean = clean.Substring(7);
        else if (clean.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            clean = clean.Substring(8);

        if (clean.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
            clean = clean.Substring(4);

        int slashIdx = clean.IndexOf('/');
        if (slashIdx >= 0) clean = clean.Substring(0, slashIdx);

        int colonIdx = clean.IndexOf(':');
        if (colonIdx >= 0) clean = clean.Substring(0, colonIdx);

        return clean.Trim().ToLowerInvariant();
    }

    /// <summary>
    /// Gõ phím mô phỏng người thật với tốc độ biến thiên ngẫu nhiên (Human Typing)
    /// </summary>
    public static void TypeHumanLike(Chrome chrome, string selector, string text)
    {
        if (chrome == null || string.IsNullOrEmpty(text)) return;
        try
        {
            // Xóa nội dung cũ
            chrome.ChromeDriver_0?.ExecuteScript($"document.querySelector('{selector}') ? document.querySelector('{selector}').value = '' : null;");
            Thread.Sleep(150);

            var el = chrome.ChromeDriver_0?.FindElement(By.CssSelector(selector));
            if (el != null)
            {
                foreach (char c in text)
                {
                    el.SendKeys(c.ToString());
                    int delay = _rd.Next(35, 110);
                    if (c == ' ' || c == '.' || c == ',') delay += _rd.Next(50, 150);
                    Thread.Sleep(delay);
                }
            }
        }
        catch
        {
            // Fallback gửi cả chuỗi
            try { chrome.method_28(selector, text, 0.05); } catch { }
        }
    }

    /// <summary>
    /// Tìm link kết quả Google chứa domain đích
    /// </summary>
    private static string FindGoogleResultLink(Chrome chrome, string normalizedDomain)
    {
        try
        {
            string findJs = @"((domain) => {
                var links = document.querySelectorAll('#search a[href], #rso a[href], div[data-hveid] a[href]');
                for (var i = 0; i < links.length; i++) {
                    var a = links[i];
                    var href = (a.getAttribute('href') || '').toLowerCase();
                    if (!href.startsWith('http')) continue;
                    if (href.includes('google.') || href.includes('/search?') || href.includes('accounts.google.')) continue;
                    if (href.includes(domain)) {
                        a.setAttribute('data-lc-target', '1');
                        return 'a[data-lc-target=""1""]';
                    }
                }
                return '';
            })('" + normalizedDomain.Replace("'", "\\'") + "')";

            object res = chrome.ChromeDriver_0?.ExecuteScript(findJs);
            return res?.ToString() ?? "";
        }
        catch { return ""; }
    }

    /// <summary>
    /// Bấm sang trang kết quả tìm kiếm tiếp theo của Google
    /// </summary>
    private static bool ClickGoogleNextPage(Chrome chrome, int targetPageNumber)
    {
        try
        {
            string nextJs = @"((targetNum) => {
                var nextBtn = document.querySelector('#pnnext, a[aria-label=""Next"" i], a[aria-label=""Tiếp"" i], a[id=""pnnext""]');
                if (nextBtn) {
                    nextBtn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                    nextBtn.click();
                    return 'clicked_next';
                }
                var pageLink = document.querySelector('a[aria-label=""Page ' + targetNum + '"" i], a[aria-label=""Trang ' + targetNum + '"" i]');
                if (pageLink) {
                    pageLink.scrollIntoView({ behavior: 'smooth', block: 'center' });
                    pageLink.click();
                    return 'clicked_page';
                }
                return 'not_found';
            })(" + targetPageNumber + ")";

            object res = chrome.ChromeDriver_0?.ExecuteScript(nextJs);
            return res != null && res.ToString().StartsWith("clicked");
        }
        catch { return false; }
    }

    /// <summary>
    /// Bấm ngẫu nhiên một kết quả tìm kiếm Google organic
    /// </summary>
    private static void ClickRandomGoogleResult(Chrome chrome)
    {
        try
        {
            string clickJs = @"(() => {
                var links = document.querySelectorAll('#rso a[href]');
                var candidates = [];
                for (var i = 0; i < links.length; i++) {
                    var href = (links[i].getAttribute('href') || '').toLowerCase();
                    if (href.startsWith('http') && !href.includes('google.') && !href.includes('/search?')) {
                        candidates.push(links[i]);
                    }
                }
                if (candidates.length > 0) {
                    var idx = Math.floor(Math.random() * Math.min(candidates.length, 5));
                    candidates[idx].scrollIntoView({ behavior: 'smooth', block: 'center' });
                    candidates[idx].click();
                    return 'clicked';
                }
                return 'none';
            })()";

            chrome.ChromeDriver_0?.ExecuteScript(clickJs);
        }
        catch { }
    }

    #endregion

    #region 2. TRUY CẬP WEBSITE VÀ NUÔI COOKIE NGOÀI (HDTruyCapWebsite)

    /// <summary>
    /// Thực hiện truy cập website chỉ định, lọc và click link nội bộ, cuộn đọc tự nhiên, quản lý tab popup.
    /// </summary>
    public static int ExecuteWebsiteVisit(
        Chrome chrome,
        List<string> urlList,
        int countLinkFrom,
        int countLinkTo,
        int countLinkClickFrom,
        int countLinkClickTo,
        int countTimeScrollFrom,
        int countTimeScrollTo,
        bool enableRandomScroll,
        Action<string> statusCallback = null,
        Action<string, int, int> delayCallback = null)
    {
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return -2;
        if (urlList == null || urlList.Count == 0) return 0;

        int successCount = 0;
        int targetUrlCount = _rd.Next(Math.Max(1, countLinkFrom), Math.Max(countLinkFrom, countLinkTo) + 1);
        List<string> remainingUrls = new List<string>(urlList);

        try
        {
            for (int i = 0; i < targetUrlCount && remainingUrls.Count > 0; i++)
            {
                if (chrome.CD930D04() || chrome.E184CD03() || Base.smethod_5()) break;

                string rawUrl = remainingUrls[_rd.Next(0, remainingUrls.Count)];
                remainingUrls.Remove(rawUrl);

                string directUrl = rawUrl.Trim();
                if (!directUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                    !directUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    directUrl = "https://" + directUrl;
                }

                statusCallback?.Invoke(Language.GetValue("Truy cập website") + $": {directUrl} ({i + 1}/{targetUrlCount})...");

                // Chuyển tab chính nếu có nhiều tab
                chrome.DC9244BF();

                // Điều hướng tới website
                chrome.method_12(directUrl);
                SleepHuman(2.5, 4.0);

                // Dọn dẹp popup / tab thừa vừa mở
                CloseExtraTabs(chrome);

                // Click link nội bộ (Internal links - cùng host/domain)
                int linksToClick = _rd.Next(Math.Max(0, countLinkClickFrom), Math.Max(countLinkClickFrom, countLinkClickTo) + 1);
                if (linksToClick > 0)
                {
                    ExploreInternalLinks(chrome, linksToClick, statusCallback);
                }

                // Giữ chân onsite với hành vi cuộn chuột tự nhiên
                int lingerSec = _rd.Next(Math.Max(5, countTimeScrollFrom), Math.Max(countTimeScrollFrom, countTimeScrollTo) + 1);
                if (enableRandomScroll)
                {
                    statusCallback?.Invoke(Language.GetValue("Lướt đọc trang") + $" ({lingerSec}s)...");
                    LingerOnsiteNatural(chrome, lingerSec);
                }
                else
                {
                    statusCallback?.Invoke(Language.GetValue("Dừng xem trang") + $" ({lingerSec}s)...");
                    chrome.F8091028(lingerSec);
                }

                successCount++;
                delayCallback?.Invoke(Language.GetValue("Hoàn thành trang"), 2, 4);
            }
        }
        catch (Exception ex)
        {
            Commom.smethod_57(chrome, ex, "OtherUtilitiesHelper.ExecuteWebsiteVisit");
            return -1;
        }

        return successCount;
    }

    /// <summary>
    /// Tìm và click các liên kết NỘI BỘ (cùng domain/hostname), loại bỏ hoàn toàn link quảng cáo, redirect ngoài, javascript void, đăng xuất.
    /// </summary>
    public static void ExploreInternalLinks(Chrome chrome, int countToClick, Action<string> statusCallback = null)
    {
        if (chrome == null || countToClick <= 0) return;

        try
        {
            for (int k = 0; k < countToClick; k++)
            {
                if (chrome.CD930D04() || Base.smethod_5()) break;

                // Script lọc link nội bộ chính xác
                string clickInternalJs = @"(() => {
                    try {
                        var curHost = window.location.hostname.toLowerCase();
                        var allA = document.querySelectorAll('a[href]');
                        var internalLinks = [];

                        for (var i = 0; i < allA.length; i++) {
                            var a = allA[i];
                            var href = (a.getAttribute('href') || '').trim();
                            if (!href || href === '#' || href.startsWith('javascript:') || 
                                href.startsWith('mailto:') || href.startsWith('tel:')) continue;

                            // Tránh các nút nhạy cảm
                            var hrefLower = href.toLowerCase();
                            var textLower = (a.innerText || '').toLowerCase();
                            if (hrefLower.includes('logout') || hrefLower.includes('signout') || 
                                hrefLower.includes('dang-xuat') || hrefLower.includes('thoat') ||
                                textLower.includes('đăng xuất') || textLower.includes('log out') || textLower.includes('sign out')) {
                                continue;
                            }

                            // Kiểm tra cùng hostname hoặc relative URL
                            if (href.startsWith('/') || href.startsWith('./') || a.hostname.toLowerCase() === curHost || a.hostname.toLowerCase().endsWith('.' + curHost)) {
                                var rect = a.getBoundingClientRect();
                                if (rect.width > 0 && rect.height > 0) {
                                    internalLinks.push(a);
                                }
                            }
                        }

                        if (internalLinks.length === 0) return 'none';
                        var chosen = internalLinks[Math.floor(Math.random() * internalLinks.length)];
                        chosen.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        chosen.click();
                        return 'clicked';
                    } catch(e) { return 'error: ' + e.message; }
                })()";

                object res = chrome.ChromeDriver_0?.ExecuteScript(clickInternalJs);
                if (res == null || res.ToString() != "clicked") break;

                statusCallback?.Invoke(Language.GetValue("Duyệt link nội bộ") + $" ({k + 1}/{countToClick})...");
                SleepHuman(2.5, 4.0);

                // Đóng tab lạ nếu link tự mở target="_blank"
                CloseExtraTabs(chrome);

                // Cuộn đọc nội dung bài viết nội bộ
                NaturalScroll(chrome, 2, 4);
            }
        }
        catch { }
    }

    /// <summary>
    /// Cuộn đọc trang tự nhiên (lên/xuống ngẫu nhiên với nhịp đọc như người dùng thật)
    /// </summary>
    public static void LingerOnsiteNatural(Chrome chrome, int durationSeconds)
    {
        if (chrome == null || durationSeconds <= 0) return;
        int startTick = Environment.TickCount;
        int maxMs = durationSeconds * 1000;

        while (Environment.TickCount - startTick < maxMs)
        {
            if (chrome.CD930D04() || Base.smethod_5()) break;

            // 75% cuộn xuống, 25% cuộn lên xem lại
            int dir = (_rd.Next(1, 100) % 4 != 0) ? 1 : -1;
            int scrollDelta = dir * _rd.Next(150, 450);

            chrome.method_8(scrollDelta);
            SleepHuman(1.2, 2.8);
        }
    }

    /// <summary>
    /// Cuộn trang vài nhịp tự nhiên
    /// </summary>
    private static void NaturalScroll(Chrome chrome, int minSteps, int maxSteps)
    {
        int steps = _rd.Next(minSteps, maxSteps + 1);
        for (int i = 0; i < steps; i++)
        {
            int dir = (_rd.Next(1, 10) > 2) ? 1 : -1;
            chrome.method_8(dir * _rd.Next(150, 400));
            SleepHuman(0.8, 1.8);
        }
    }

    /// <summary>
    /// Đóng các tab/window popup thừa, giữ nguyên tab làm việc chính
    /// </summary>
    public static void CloseExtraTabs(Chrome chrome)
    {
        try
        {
            var driver = chrome?.ChromeDriver_0;
            if (driver == null) return;

            var handles = driver.WindowHandles;
            if (handles.Count > 1)
            {
                string mainHandle = handles[0];
                for (int i = handles.Count - 1; i >= 1; i--)
                {
                    driver.SwitchTo().Window(handles[i]);
                    driver.Close();
                }
                driver.SwitchTo().Window(mainHandle);
            }
        }
        catch { }
    }

    #endregion

    #region 3. RỜI NHÓM FACEBOOK COMET (HDRoiNhom)

    /// <summary>
    /// Tự động rời nhóm trên Facebook Desktop WWW (Comet mới 2026), bắt chuẩn modal xác nhận rời nhóm đa ngôn ngữ.
    /// </summary>
    public static bool LeaveGroupComet(Chrome chrome, string groupId = "", Action<string> statusCallback = null)
    {
        if (chrome == null || chrome.CD930D04()) return false;

        try
        {
            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            if (!string.IsNullOrEmpty(groupId))
            {
                string url = groupId.StartsWith("http") ? groupId : $"https://www.facebook.com/groups/{groupId}";
                chrome.method_12(url);
                SleepHuman(2.5, 3.5);
            }

            statusCallback?.Invoke(Language.GetValue("Đang xác định nút Đã tham gia..."));

            // 1. Tìm và click nút "Đã tham gia" / "Joined" trên trang nhóm
            string clickJoinedJs = @"(() => {
                try {
                    var all = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                    for (var i = 0; i < all.length; i++) {
                        var el = all[i];
                        var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (el.innerText || '').toLowerCase().trim();
                        if (a === 'đã tham gia' || a === 'joined' || a.includes('đã tham gia') || a.includes('joined') ||
                            t === 'đã tham gia' || t === 'joined' || t.includes('đã tham gia') || t.includes('joined') ||
                            a === 'membre' || a === 'unirse' || a === 'sudah bergabung') {
                            el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el.click();
                            return 'clicked_joined';
                        }
                    }
                    // Nếu là giao diện 3-dots
                    var moreBtn = document.querySelector('div[aria-label=""More"" i][role=""button""], div[aria-label=""Xem thêm"" i][role=""button""]');
                    if (moreBtn) {
                        moreBtn.click();
                        return 'clicked_more';
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            })()";

            object resJoined = driver.ExecuteScript(clickJoinedJs);
            if (resJoined == null || resJoined.ToString() == "not_found")
            {
                // Kiểm tra xem đã không ở trong nhóm nữa hay chưa
                bool notInGroup = (bool)(driver.ExecuteScript(@"return !!document.querySelector('div[aria-label*=""Tham gia nhóm"" i], div[aria-label*=""Join Group"" i]');") ?? false);
                if (notInGroup) return true;
                return false;
            }

            SleepHuman(1.2, 1.8);

            // 2. Click "Rời khỏi nhóm" / "Leave group" trong menu dropdown
            statusCallback?.Invoke(Language.GetValue("Chọn Rời khỏi nhóm trong menu..."));
            string clickLeaveMenuItemJs = @"(() => {
                try {
                    var items = document.querySelectorAll('[role=""menu""] [role=""menuitem""], [role=""menu""] [role=""button""], [role=""menu""] div, [role=""menu""] span');
                    for (var i = 0; i < items.length; i++) {
                        var it = items[i];
                        var a = (it.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (it.innerText || '').toLowerCase().trim();
                        if (a.includes('rời khỏi nhóm') || a.includes('leave group') || a.includes('rời nhóm') ||
                            t.includes('rời khỏi nhóm') || t.includes('leave group') || t.includes('rời nhóm') ||
                            a.includes('salir del grupo') || a.includes('quitter le groupe') || a.includes('keluar dari grup')) {
                            it.click();
                            return 'clicked_menu_leave';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            })()";

            object resLeaveItem = driver.ExecuteScript(clickLeaveMenuItemJs);
            SleepHuman(1.2, 2.0);

            // 3. Tự động bắt Modal xác nhận rời nhóm Comet mới (div[role="dialog"])
            statusCallback?.Invoke(Language.GetValue("Bắt modal xác nhận rời nhóm Comet..."));
            string confirmModalJs = @"(() => {
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];

                    // Tùy chọn checkbox ngăn thêm lại nếu có
                    var cb = dlg.querySelector('input[type=""checkbox""], div[role=""checkbox""]');
                    if (cb && !cb.checked && cb.getAttribute('aria-checked') !== 'true') {
                        cb.click();
                    }

                    var btns = dlg.querySelectorAll('[role=""button""], button');
                    for (var i = 0; i < btns.length; i++) {
                        var b = btns[i];
                        var a = (b.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (b.innerText || '').toLowerCase().trim();

                        // Bỏ qua các nút Cancel / Hủy / Đóng
                        if (a.includes('cancel') || a.includes('hủy') || a.includes('đóng') || a.includes('close') ||
                            t === 'hủy' || t === 'cancel' || t === 'đóng' || t === 'close') {
                            continue;
                        }

                        // Tìm nút xác nhận rời
                        if (a.includes('rời khỏi nhóm') || a.includes('leave group') || a.includes('rời nhóm') || a.includes('leave') ||
                            t.includes('rời khỏi nhóm') || t.includes('leave group') || t.includes('rời nhóm') || t.includes('rời') ||
                            a.includes('xác nhận') || a.includes('confirm') || t.includes('xác nhận') || t.includes('confirm') ||
                            a.includes('salir') || a.includes('quitter') || a.includes('keluar')) {
                            b.click();
                            return 'confirmed';
                        }
                    }

                    // Fallback: bấm nút action cuối cùng không phải Cancel
                    for (var j = btns.length - 1; j >= 0; j--) {
                        var b2 = btns[j];
                        var a2 = (b2.getAttribute('aria-label') || '').toLowerCase();
                        var t2 = (b2.innerText || '').toLowerCase();
                        if (a2.includes('cancel') || a2.includes('hủy') || t2.includes('hủy') || t2.includes('cancel')) continue;
                        b2.click();
                        return 'confirmed_fallback';
                    }

                    return 'no_confirm_button';
                } catch(e) { return 'error: ' + e.message; }
            })()";

            object resConfirm = driver.ExecuteScript(confirmModalJs);
            SleepHuman(2.0, 3.0);

            // Kiểm tra checkpoint hoặc block
            if (chrome.method_66("CheckFbBlock") == "true")
            {
                chrome.EE37E6A7 = true;
                return false;
            }

            return resConfirm != null && resConfirm.ToString().StartsWith("confirmed");
        }
        catch (Exception ex)
        {
            Commom.smethod_57(chrome, ex, "OtherUtilitiesHelper.LeaveGroupComet");
            return false;
        }
    }

    #endregion

    #region 4. FOLLOW / LIKE PAGE & CÁ NHÂN ĐA NGÔN NGỮ (HDBuffFollowLikePage / HDBuffFollowCaNhan)

    /// <summary>
    /// Thực hiện Follow Profile Facebook WWW với nhận diện đa ngôn ngữ, menu 3 chấm và kiểm tra trạng thái tránh bấm nhầm.
    /// </summary>
    public static bool ExecuteFollow(Chrome chrome, string targetIdOrUrl, Action<string> statusCallback = null)
    {
        if (chrome == null || chrome.CD930D04()) return false;

        try
        {
            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            if (!string.IsNullOrEmpty(targetIdOrUrl))
            {
                string url = targetIdOrUrl.StartsWith("http") ? targetIdOrUrl : $"https://www.facebook.com/{targetIdOrUrl}";
                chrome.method_12(url);
                SleepHuman(2.5, 3.5);
            }

            statusCallback?.Invoke(Language.GetValue("Kiểm tra trạng thái Follow..."));

            string followJs = @"(() => {
                try {
                    // 1. Kiểm tra nếu đã follow rồi
                    var bodyText = document.body.innerText || '';
                    var allSpans = document.querySelectorAll('div[role=""main""] span, div[role=""main""] div');
                    for (var s = 0; s < allSpans.length; s++) {
                        var st = (allSpans[s].innerText || '').toLowerCase().trim();
                        if (st === 'đang theo dõi' || st === 'following' || st === 'siguiendo' || 
                            st === 'abonné(e)' || st === 'mengikuti' || st === 'gefolgt') {
                            return 'already_following';
                        }
                    }

                    // 2. Tìm nút Follow trực tiếp trên trang
                    var candidates = document.querySelectorAll('div[role=""button""], button');
                    for (var i = 0; i < candidates.length; i++) {
                        var b = candidates[i];
                        var a = (b.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (b.innerText || '').toLowerCase().trim();
                        if (a === 'theo dõi' || a === 'follow' || a === 'seguir' || a === 'suivre' || a === 'ikuti' || a === 'folgen' ||
                            t === 'theo dõi' || t === 'follow' || t === 'seguir' || t === 'suivre' || t === 'ikuti' || t === 'folgen') {
                            b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            b.click();
                            return 'clicked_follow';
                        }
                    }

                    // 3. Nếu nút Follow ẩn trong menu 3 chấm (...)
                    var moreBtns = document.querySelectorAll('div[aria-label*=""Xem thêm"" i][role=""button""], div[aria-label*=""More"" i][role=""button""], div[aria-label*=""Hành động khác"" i][role=""button""]');
                    if (moreBtns.length > 0) {
                        moreBtns[0].click();
                        return 'open_more_menu';
                    }

                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            })()";

            object res = driver.ExecuteScript(followJs);
            if (res != null)
            {
                string r = res.ToString();
                if (r == "already_following") return true;
                if (r == "clicked_follow")
                {
                    SleepHuman(1.5, 2.5);
                    return true;
                }
                if (r == "open_more_menu")
                {
                    SleepHuman(1.0, 1.5);
                    // Bấm Follow trong dropdown
                    string menuFollowJs = @"(() => {
                        var items = document.querySelectorAll('div[role=""menu""] span, div[role=""menu""] div');
                        for (var i = 0; i < items.length; i++) {
                            var t = (items[i].innerText || '').toLowerCase().trim();
                            if (t === 'theo dõi' || t === 'follow' || t === 'seguir' || t === 'suivre' || t === 'ikuti') {
                                items[i].click();
                                return 'clicked_menu';
                            }
                        }
                        return 'not_found';
                    })()";
                    object menuRes = driver.ExecuteScript(menuFollowJs);
                    SleepHuman(1.5, 2.5);
                    return menuRes != null && menuRes.ToString() == "clicked_menu";
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            Commom.smethod_57(chrome, ex, "OtherUtilitiesHelper.ExecuteFollow");
            return false;
        }
    }

    /// <summary>
    /// Thực hiện Like Fanpage Facebook WWW với nhận diện đa ngôn ngữ, menu 3 chấm và kiểm tra trạng thái tránh bỏ thích nhầm.
    /// </summary>
    public static bool ExecuteLikePage(Chrome chrome, string pageIdOrUrl, Action<string> statusCallback = null)
    {
        if (chrome == null || chrome.CD930D04()) return false;

        try
        {
            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            if (!string.IsNullOrEmpty(pageIdOrUrl))
            {
                string url = pageIdOrUrl.StartsWith("http") ? pageIdOrUrl : $"https://www.facebook.com/{pageIdOrUrl}";
                chrome.method_12(url);
                SleepHuman(2.5, 3.5);
            }

            statusCallback?.Invoke(Language.GetValue("Kiểm tra trạng thái Thích trang..."));

            string likeJs = @"(() => {
                try {
                    // 1. Kiểm tra nếu đã like rồi
                    var allSpans = document.querySelectorAll('div[role=""main""] span, div[role=""main""] div');
                    for (var s = 0; s < allSpans.length; s++) {
                        var st = (allSpans[s].innerText || '').toLowerCase().trim();
                        if (st === 'đã thích' || st === 'liked' || st === 'te gusta' || 
                            st === 'aimé' || st === 'disukai' || st === 'gefällt dir') {
                            return 'already_liked';
                        }
                    }

                    // 2. Tìm nút Thích / Like trực tiếp
                    var candidates = document.querySelectorAll('div[role=""button""], button');
                    for (var i = 0; i < candidates.length; i++) {
                        var b = candidates[i];
                        var a = (b.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (b.innerText || '').toLowerCase().trim();
                        if (a === 'thích' || a === 'like' || a === 'me gusta' || a === 'j\'aime' || a === 'suka' || a === 'gefällt mir' ||
                            t === 'thích' || t === 'like' || t === 'me gusta' || t === 'j\'aime' || t === 'suka' || t === 'gefällt mir') {
                            b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            b.click();
                            return 'clicked_like';
                        }
                    }

                    // 3. Nếu nút Thích ẩn trong menu 3 chấm (...)
                    var moreBtns = document.querySelectorAll('div[aria-label*=""Xem thêm"" i][role=""button""], div[aria-label*=""More"" i][role=""button""], div[aria-label*=""Hành động khác"" i][role=""button""]');
                    if (moreBtns.length > 0) {
                        moreBtns[0].click();
                        return 'open_more_menu';
                    }

                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            })()";

            object res = driver.ExecuteScript(likeJs);
            if (res != null)
            {
                string r = res.ToString();
                if (r == "already_liked") return true;
                if (r == "clicked_like")
                {
                    SleepHuman(1.5, 2.5);
                    return true;
                }
                if (r == "open_more_menu")
                {
                    SleepHuman(1.0, 1.5);
                    string menuLikeJs = @"(() => {
                        var items = document.querySelectorAll('div[role=""menu""] span, div[role=""menu""] div');
                        for (var i = 0; i < items.length; i++) {
                            var t = (items[i].innerText || '').toLowerCase().trim();
                            if (t === 'thích' || t === 'like' || t === 'me gusta' || t === 'j\'aime' || t === 'suka') {
                                items[i].click();
                                return 'clicked_menu';
                            }
                        }
                        return 'not_found';
                    })()";
                    object menuRes = driver.ExecuteScript(menuLikeJs);
                    SleepHuman(1.5, 2.5);
                    return menuRes != null && menuRes.ToString() == "clicked_menu";
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            Commom.smethod_57(chrome, ex, "OtherUtilitiesHelper.ExecuteLikePage");
            return false;
        }
    }

    #endregion

    #region Phụ trợ chung

    private static void SleepHuman(double minSec, double maxSec)
    {
        int ms = (int)(_rd.NextDouble() * (maxSec - minSec) * 1000 + minSec * 1000);
        Thread.Sleep(Math.Max(100, ms));
    }

    #endregion

    private static object ExecuteScript(this IWebDriver driver, string script, params object[] args)
    {
        return ((IJavaScriptExecutor)driver).ExecuteScript(script, args);
    }
}
