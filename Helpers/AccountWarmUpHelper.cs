using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Cấu hình tham số cho quy trình Warm-up / Nướng nick tự động Comet 2026.
/// </summary>
public class WarmUpConfig
{
    // Phase 1: Passive Warm-up (Lướt nhẹ)
    public int FeedScrollRoundsMin { get; set; } = 2;
    public int FeedScrollRoundsMax { get; set; } = 4;
    public int FeedReadTimeMinSec { get; set; } = 3;
    public int FeedReadTimeMaxSec { get; set; } = 8;
    public int StoryCountMin { get; set; } = 1;
    public int StoryCountMax { get; set; } = 3;
    public int StoryViewMinSec { get; set; } = 4;
    public int StoryViewMaxSec { get; set; } = 7;
    public bool ClearNotificationBadge { get; set; } = true;

    // Phase 2: Soft Engagement (Tương tác nhẹ)
    public int FeedReactionsMin { get; set; } = 1;
    public int FeedReactionsMax { get; set; } = 2;
    public int WatchVideoMinSec { get; set; } = 15;
    public int WatchVideoMaxSec { get; set; } = 30;
    public bool VisitFriendProfile { get; set; } = true;
    public int FriendProfileReadSecMin { get; set; } = 4;
    public int FriendProfileReadSecMax { get; set; } = 7;

    // Phase 3: Health Check & Shield
    public bool CheckCheckpoint { get; set; } = true;
    public bool DismissPopups { get; set; } = true;
    public bool UpdateStatusDb { get; set; } = true;
    public string SuccessStatusText { get; set; } = "Đã warm-up";
}

/// <summary>
/// Phân hệ Nướng Nick / Account Warm-Up Tự Động 2026 (Comet WWW).
/// Thiết lập nhịp sinh học tự nhiên người dùng qua 3 pha:
/// - Phase 1 (Passive Warm-up): Lướt nhẹ Newsfeed Comet, dừng đọc bài 3-8s, xem 1-3 Story, mở thông báo xóa badge đỏ.
/// - Phase 2 (Soft Engagement): Thả 1-2 reaction (Like/Love), xem Video Watch 15-30s, lướt trang cá nhân bạn bè.
/// - Phase 3 (Health Check & Shield): Quét Checkpoint, đóng modal Lưu mật khẩu/Thông báo (FacebookLoginAutofill), cập nhật trạng thái "Đã warm-up".
/// </summary>
public static class AccountWarmUpHelper
{
    private static readonly ThreadLocal<Random> _rnd = new ThreadLocal<Random>(() =>
        new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

    private static Random Rnd => _rnd.Value;

    /// <summary>
    /// Thực thi một phiên Warm-Up 3 giai đoạn tự động cho tài khoản Facebook Comet 2026.
    /// </summary>
    /// <param name="chrome">Đối tượng Chrome điều khiển trình duyệt.</param>
    /// <param name="uid">UID của tài khoản cần warm-up.</param>
    /// <param name="config">Cấu hình tham số warm-up (nếu null sẽ dùng mặc định).</param>
    /// <param name="statusLogger">Callback ghi log tiến độ realtime hiển thị lên DataGridView.</param>
    /// <returns>True nếu warm-up thành công; False nếu gặp checkpoint hoặc bị hủy.</returns>
    public static bool ExecuteWarmUpSession(Chrome chrome, string uid, WarmUpConfig config = null, Action<string> statusLogger = null)
    {
        if (chrome == null || chrome.CD930D04())
        {
            statusLogger?.Invoke("Trình duyệt không sẵn sàng!");
            return false;
        }

        if (config == null)
        {
            config = new WarmUpConfig();
        }

        try
        {
            statusLogger?.Invoke("[Warm-up 2026] Bắt đầu nướng nick tự động...");

            // 0. Chuẩn bị phiên Facebook
            if (!EnsureFacebookSession(chrome, statusLogger))
            {
                return false;
            }

            // GIAI ĐOẠN 1: PASSIVE WARM-UP (LƯỚT NHẸ)
            statusLogger?.Invoke("[Phase 1] Bắt đầu Passive Warm-up (Lướt nhẹ)...");
            if (!ExecutePhase1_PassiveWarmUp(chrome, config, statusLogger))
            {
                return false;
            }

            // GIAI ĐOẠN 2: SOFT ENGAGEMENT (TƯƠNG TÁC NHẸ)
            statusLogger?.Invoke("[Phase 2] Bắt đầu Soft Engagement (Tương tác nhẹ)...");
            if (!ExecutePhase2_SoftEngagement(chrome, config, statusLogger))
            {
                return false;
            }

            // GIAI ĐOẠN 3: HEALTH CHECK & SHIELD (KIỂM TRA & BẢO VỆ)
            statusLogger?.Invoke("[Phase 3] Bắt đầu Health Check & Shield...");
            if (!ExecutePhase3_HealthCheckAndShield(chrome, uid, config, statusLogger))
            {
                return false;
            }

            statusLogger?.Invoke(config.SuccessStatusText);
            return true;
        }
        catch (ThreadAbortException)
        {
            statusLogger?.Invoke("Đã dừng warm-up!");
            return false;
        }
        catch (Exception ex)
        {
            statusLogger?.Invoke("Lỗi warm-up: " + ex.Message);
            return false;
        }
    }

    #region 0. KHỞI TẠO & ĐIỀU HƯỚNG PHIÊN FACEBOOK

    private static bool EnsureFacebookSession(Chrome chrome, Action<string> statusLogger)
    {
        if (Base.smethod_5() || chrome.CD930D04()) return false;

        IWebDriver driver = chrome.ChromeDriver_0;
        string currentUrl = driver.Url ?? "";

        if (!currentUrl.Contains("facebook.com"))
        {
            statusLogger?.Invoke("Đang điều hướng vào Facebook...");
            chrome.method_12("https://www.facebook.com/");
            if (!SafeSleep(2500)) return false;
        }

        // Tự động đóng modal popup ban đầu nếu có
        DismissAllModals(driver);

        // Kiểm tra ngay xem có bị checkpoint trước khi warm-up
        if (IsCheckpointPage(driver))
        {
            statusLogger?.Invoke("Cảnh báo: Tài khoản đang ở màn hình Checkpoint!");
            return false;
        }

        return true;
    }

    #endregion

    #region GIAI ĐOẠN 1: PASSIVE WARM-UP (LƯỚT NHẸ)

    private static bool ExecutePhase1_PassiveWarmUp(Chrome chrome, WarmUpConfig config, Action<string> statusLogger)
    {
        IWebDriver driver = chrome.ChromeDriver_0;

        // 1.1 Lướt Newsfeed Comet theo nhịp người thật & dừng đọc bài 3-8s
        int scrollRounds = Rnd.Next(config.FeedScrollRoundsMin, config.FeedScrollRoundsMax + 1);
        for (int r = 1; r <= scrollRounds; r++)
        {
            if (Base.smethod_5() || chrome.CD930D04()) return false;

            statusLogger?.Invoke($"[Phase 1] Lướt Newsfeed Comet ({r}/{scrollRounds})...");

            // Cuộn mượt với HumanScroll
            int scrollPx = Rnd.Next(350, 680);
            HumanScroll.ScrollNewsfeed(chrome, scrollPx);

            // Dừng đọc bài mô phỏng người thật 3-8s
            int readSec = Rnd.Next(config.FeedReadTimeMinSec, config.FeedReadTimeMaxSec + 1);
            statusLogger?.Invoke($"[Phase 1] Đọc bài viết trên feed ({readSec}s)...");
            if (!SafeSleep(readSec * 1000)) return false;

            // 35% khả năng mở rộng "Xem thêm / See more" bài viết
            if (Rnd.Next(0, 100) < 35)
            {
                ExpandSeeMoreOnFeed(driver);
            }
        }

        // 1.2 Xem Stories Facebook (1-3 story)
        if (config.StoryCountMax > 0)
        {
            int storyCount = Rnd.Next(config.StoryCountMin, config.StoryCountMax + 1);
            statusLogger?.Invoke($"[Phase 1] Mở xem Stories Facebook ({storyCount} story)...");

            chrome.method_12("https://www.facebook.com/stories/");
            if (!SafeSleep(2500)) return false;

            for (int s = 0; s < storyCount; s++)
            {
                if (Base.smethod_5() || chrome.CD930D04()) return false;

                bool isStoryPlaying = IsStoryViewerActive(driver);
                if (!isStoryPlaying)
                {
                    // Thử click vào story đầu tiên trên màn hình nếu chưa phát
                    ClickFirstStory(driver);
                    SafeSleep(1500);
                    isStoryPlaying = IsStoryViewerActive(driver);
                }

                if (!isStoryPlaying)
                {
                    statusLogger?.Invoke("[Phase 1] Không phát hiện Story đang phát, tiếp tục...");
                    break;
                }

                int watchSec = Rnd.Next(config.StoryViewMinSec, config.StoryViewMaxSec + 1);
                statusLogger?.Invoke($"[Phase 1] Đang xem Story ({s + 1}/{storyCount}) trong {watchSec}s...");
                if (!SafeSleep(watchSec * 1000)) return false;

                // Chuyển sang story tiếp theo
                NextStory(driver);
                SafeSleep(1200);
            }
        }

        // 1.3 Mở thông báo Facebook để xóa badge đỏ
        if (config.ClearNotificationBadge)
        {
            if (Base.smethod_5() || chrome.CD930D04()) return false;

            statusLogger?.Invoke("[Phase 1] Mở thông báo Facebook để xóa badge đỏ...");
            chrome.method_12("https://www.facebook.com/notifications/");
            if (!SafeSleep(2500)) return false;

            // Cuộn nhẹ xem thông báo
            HumanScroll.ScrollNewsfeed(chrome, 200);
            SafeSleep(800);

            // Click vào thông báo gần nhất để xóa badge
            ClickLatestNotification(driver);
            SafeSleep(2000);
        }

        return true;
    }

    #endregion

    #region GIAI ĐOẠN 2: SOFT ENGAGEMENT (TƯƠNG TÁC NHẸ)

    private static bool ExecutePhase2_SoftEngagement(Chrome chrome, WarmUpConfig config, Action<string> statusLogger)
    {
        IWebDriver driver = chrome.ChromeDriver_0;

        // Đảm bảo quay về feed
        if (driver.Url == null || !driver.Url.EndsWith("facebook.com/"))
        {
            chrome.method_12("https://www.facebook.com/");
            if (!SafeSleep(2500)) return false;
        }

        // 2.1 Thả 1-2 reaction (Like/Love) ngẫu nhiên vào bài viết trên feed
        int reactTarget = Rnd.Next(config.FeedReactionsMin, config.FeedReactionsMax + 1);
        int reactedCount = 0;

        for (int attempt = 0; attempt < 4 && reactedCount < reactTarget; attempt++)
        {
            if (Base.smethod_5() || chrome.CD930D04()) return false;

            string rType = (Rnd.Next(0, 100) < 65) ? "Like" : "Love";
            statusLogger?.Invoke($"[Phase 2] Thả {rType} ngẫu nhiên vào bài viết ({reactedCount + 1}/{reactTarget})...");

            bool reacted = ApplyReactionToFeed(driver, rType);
            if (reacted)
            {
                reactedCount++;
                statusLogger?.Invoke($"[Phase 2] Đã thả {rType} bài viết thành công!");
                int delaySec = Rnd.Next(3, 6);
                if (!SafeSleep(delaySec * 1000)) return false;
            }

            // Cuộn tiếp xuống bài khác
            HumanScroll.ScrollNewsfeed(chrome, Rnd.Next(400, 750));
            SafeSleep(1500);
        }

        // 2.2 Xem Facebook Watch / Video feed 15-30 giây
        if (config.WatchVideoMaxSec > 0)
        {
            if (Base.smethod_5() || chrome.CD930D04()) return false;

            int watchDurationSec = Rnd.Next(config.WatchVideoMinSec, config.WatchVideoMaxSec + 1);
            statusLogger?.Invoke($"[Phase 2] Mở Facebook Watch / Video feed ({watchDurationSec}s)...");

            chrome.method_12("https://www.facebook.com/watch/");
            if (!SafeSleep(3000)) return false;

            // Đảm bảo video phát
            EnsureHtml5VideoPlaying(driver);

            int elapsed = 0;
            while (elapsed < watchDurationSec)
            {
                if (Base.smethod_5() || chrome.CD930D04()) return false;

                int stepSec = Math.Min(3, watchDurationSec - elapsed);
                if (!SafeSleep(stepSec * 1000)) return false;
                elapsed += stepSec;

                statusLogger?.Invoke($"[Phase 2] Đang xem video Watch ({elapsed}/{watchDurationSec}s)...");

                // Giữa chừng cuộn nhẹ 1 lần
                if (elapsed >= watchDurationSec / 2 && elapsed <= watchDurationSec / 2 + stepSec)
                {
                    HumanScroll.ScrollNewsfeed(chrome, 250);
                }
            }
        }

        // 2.3 Lướt qua trang cá nhân một người bạn
        if (config.VisitFriendProfile)
        {
            if (Base.smethod_5() || chrome.CD930D04()) return false;

            statusLogger?.Invoke("[Phase 2] Ghé thăm trang cá nhân bạn bè...");
            chrome.method_12("https://www.facebook.com/me/friends");
            if (!SafeSleep(2500)) return false;

            List<string> friendUrls = ExtractFriendUrls(driver);

            if (friendUrls != null && friendUrls.Count > 0)
            {
                string targetFriendUrl = friendUrls[Rnd.Next(0, friendUrls.Count)];
                statusLogger?.Invoke("[Phase 2] Đang mở trang cá nhân bạn bè...");
                chrome.method_12(targetFriendUrl);
                if (!SafeSleep(2500)) return false;

                statusLogger?.Invoke("[Phase 2] Lướt xem timeline tường nhà bạn...");
                HumanScroll.ScrollNewsfeed(chrome, Rnd.Next(350, 650));

                int readSec = Rnd.Next(config.FriendProfileReadSecMin, config.FriendProfileReadSecMax + 1);
                if (!SafeSleep(readSec * 1000)) return false;
            }
            else
            {
                // Fallback an toàn cho nick mới chưa có bạn bè: xem trang cá nhân chính mình
                statusLogger?.Invoke("[Phase 2] Chưa có danh sách bạn bè, ghé thăm trang cá nhân chính mình...");
                chrome.method_12("https://www.facebook.com/me");
                if (!SafeSleep(2000)) return false;
                HumanScroll.ScrollNewsfeed(chrome, 300);
                SafeSleep(2500);
            }
        }

        return true;
    }

    #endregion

    #region GIAI ĐOẠN 3: HEALTH CHECK & SHIELD

    private static bool ExecutePhase3_HealthCheckAndShield(Chrome chrome, string uid, WarmUpConfig config, Action<string> statusLogger)
    {
        IWebDriver driver = chrome.ChromeDriver_0;

        // 3.1 Kiểm tra Checkpoint Banner & Trang thái tài khoản
        if (config.CheckCheckpoint)
        {
            statusLogger?.Invoke("[Phase 3] Kiểm tra checkpoint & tình trạng tài khoản...");
            if (IsCheckpointPage(driver))
            {
                statusLogger?.Invoke("Cảnh báo: Tài khoản bị Checkpoint! Dừng warm-up bảo toàn nick.");
                if (config.UpdateStatusDb && !string.IsNullOrEmpty(chrome.AF336B2C))
                {
                    CommonSQL.B8A0E617(chrome.AF336B2C, "status", "Checkpoint");
                }
                return false;
            }
        }

        // 3.2 Đóng các modal popup "Lưu mật khẩu / Remember password / Nhận thông báo"
        if (config.DismissPopups)
        {
            statusLogger?.Invoke("[Phase 3] Đóng popup lưu mật khẩu, thông báo & bảo toàn phiên...");
            try
            {
                var autofill = new FacebookLoginAutofill();
                autofill.DismissModalsAndAlerts(driver);
            }
            catch { }

            DismissAllModals(driver);
            SafeSleep(1200);
        }

        // 3.3 Cập nhật trạng thái nick là "Đã warm-up" vào DB
        if (config.UpdateStatusDb && !string.IsNullOrEmpty(chrome.AF336B2C))
        {
            try
            {
                CommonSQL.B8A0E617(chrome.AF336B2C, "status", config.SuccessStatusText);
                CommonSQL.B8A0E617(chrome.AF336B2C, "interactEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch { }
        }

        statusLogger?.Invoke("Hoàn tất quy trình Warm-up 3 pha (Trust Score tăng, an toàn)!");
        return true;
    }

    #endregion

    #region CÁC HÀM XỬ LÝ COMET DOM & JAVASCRIPT NỘI BỘ

    private static bool SafeSleep(int milliseconds)
    {
        int step = 200;
        int waited = 0;
        while (waited < milliseconds)
        {
            if (Base.smethod_5()) return false;
            int wait = Math.Min(step, milliseconds - waited);
            Thread.Sleep(wait);
            waited += wait;
        }
        return !Base.smethod_5();
    }

    private static bool IsCheckpointPage(IWebDriver driver)
    {
        try
        {
            string url = (driver.Url ?? "").ToLower();
            if (url.Contains("/checkpoint") || url.Contains("/two_step_verification") ||
                url.Contains("facebook.com/recover") || url.Contains("suspended") ||
                url.Contains("disabled"))
            {
                return true;
            }

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js != null)
            {
                string script = @"
                    var txt = (document.body ? document.body.innerText : '').toLowerCase();
                    if (txt.indexOf('tài khoản của bạn đã bị vô hiệu hóa') !== -1 ||
                        txt.indexOf('tài khoản của bạn đã bị khóa') !== -1 ||
                        txt.indexOf('your account has been disabled') !== -1 ||
                        txt.indexOf('your account has been locked') !== -1 ||
                        txt.indexOf('we suspended your account') !== -1 ||
                        txt.indexOf('xác nhận danh tính') !== -1) {
                        return true;
                    }
                    if (document.querySelector('input[name=""approvals_code""], iframe[src*=""captcha""]')) {
                        return true;
                    }
                    return false;
                ";
                object res = js.ExecuteScript(script);
                if (res is bool b && b) return true;
            }
        }
        catch { }
        return false;
    }

    private static void DismissAllModals(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return;

            string script = @"
(function() {
    try {
        // 1. Popup Lưu mật khẩu / Remember password
        var dialogs = document.querySelectorAll('[role=""dialog""], [data-dialog=""1""]');
        for (var i = 0; i < dialogs.length; i++) {
            var d = dialogs[i];
            var txt = (d.innerText || '').toLowerCase();
            if (txt.indexOf('lưu mật khẩu') !== -1 || txt.indexOf('remember password') !== -1 ||
                txt.indexOf('save your login') !== -1 || txt.indexOf('nhấp vào ảnh') !== -1) {
                var btns = d.querySelectorAll('[role=""button""], button');
                for (var j = 0; j < btns.length; j++) {
                    var bTxt = (btns[j].innerText || btns[j].getAttribute('aria-label') || '').toLowerCase().trim();
                    if (bTxt === 'ok' || bTxt === 'lưu' || bTxt === 'lúc khác' || bTxt === 'not now' || bTxt === 'để sau') {
                        btns[j].click();
                        break;
                    }
                }
            }
        }
        // 2. Popup Bật thông báo
        for (var k = 0; k < dialogs.length; k++) {
            var nd = dialogs[k];
            var nTxt = (nd.innerText || '').toLowerCase();
            if (nTxt.indexOf('thông báo') !== -1 || nTxt.indexOf('notification') !== -1) {
                var closeBtn = nd.querySelector('[aria-label=""Đóng""], [aria-label=""Close""], [aria-label=""Lúc khác""], [aria-label=""Not Now""], [aria-label=""Block""]');
                if (closeBtn) {
                    closeBtn.click();
                }
            }
        }
        // 3. Modal xác nhận Đúng là tôi (This was me)
        var confirmBtns = document.querySelectorAll('button[name*=""submit[This was me]""], [role=""button""]');
        for (var c = 0; c < confirmBtns.length; c++) {
            var cTxt = (confirmBtns[c].innerText || confirmBtns[c].getAttribute('aria-label') || '').toLowerCase();
            if (cTxt === 'đúng là tôi' || cTxt === 'đây là tôi' || cTxt === 'this was me') {
                confirmBtns[c].click();
                break;
            }
        }
        // 4. Cookie banner
        var cookieBtn = document.querySelector('[data-cookiebanner=""accept_button""], [data-testid=""cookie-policy-manage-dialog""] [aria-label]:not([aria-disabled=""true""])');
        if (cookieBtn) {
            cookieBtn.click();
        }
    } catch (e) {}
})();";
            js.ExecuteScript(script);
        }
        catch { }
    }

    private static void ExpandSeeMoreOnFeed(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return;
            string script = @"
                var moreBtns = document.querySelectorAll('div[role=""feed""] div[role=""button""]');
                for (var i = 0; i < moreBtns.length; i++) {
                    var t = (moreBtns[i].innerText || '').trim().toLowerCase();
                    if (t === 'xem thêm' || t === 'see more') {
                        moreBtns[i].click();
                        break;
                    }
                }
            ";
            js.ExecuteScript(script);
        }
        catch { }
    }

    private static bool IsStoryViewerActive(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return false;
            string script = @"
                return (document.querySelector('div[aria-label=""Story""], div[data-pagelet*=""StoryViewer""], div[aria-label=""Tiếp""], div[aria-label=""Next""]') !== null)
                    || (window.location.href.indexOf('/stories/') !== -1);
            ";
            object res = js.ExecuteScript(script);
            return res is bool b && b;
        }
        catch
        {
            return false;
        }
    }

    private static void ClickFirstStory(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return;
            string script = @"
                var storyCard = document.querySelector('div[aria-label*=""Story""][role=""button""], div[data-pagelet=""Stories""] div[role=""button""], a[href*=""/stories/""]');
                if (storyCard) {
                    storyCard.click();
                }
            ";
            js.ExecuteScript(script);
        }
        catch { }
    }

    private static void NextStory(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return;
            string script = @"
                var nextBtn = document.querySelector('[aria-label=""Tiếp""], [aria-label=""Next""], [aria-label=""Story tiếp theo""], [aria-label=""Next story""]');
                if (nextBtn) {
                    nextBtn.click();
                } else {
                    var evt = new KeyboardEvent('keydown', { key: 'ArrowRight', keyCode: 39, which: 39, bubbles: true });
                    document.dispatchEvent(evt);
                }
            ";
            js.ExecuteScript(script);
        }
        catch { }
    }

    private static void ClickLatestNotification(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return;
            string script = @"
                var notifs = document.querySelectorAll('div[role=""feed""] a[role=""link""], div[role=""main""] a[href*=""notif_id""], a[href*=""notif_t""]');
                if (notifs && notifs.length > 0) {
                    notifs[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
                    notifs[0].click();
                }
            ";
            js.ExecuteScript(script);
        }
        catch { }
    }

    private static bool ApplyReactionToFeed(IWebDriver driver, string reactionType)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return false;

            string script = @"
                var rType = arguments[0].toLowerCase();
                var posts = document.querySelectorAll('div[role=""feed""] > div, div[role=""article""], div[data-pagelet*=""FeedUnit""]');
                for (var i = 0; i < posts.length; i++) {
                    var p = posts[i];
                    var rect = p.getBoundingClientRect();
                    if (rect.height < 80) continue;

                    var btns = p.querySelectorAll('div[role=""button""][aria-label]');
                    for (var j = 0; j < btns.length; j++) {
                        var b = btns[j];
                        var label = (b.getAttribute('aria-label') || '').toLowerCase();
                        if (label === 'thích' || label === 'like' || label.indexOf('thích') === 0 || label.indexOf('like') === 0) {
                            if (b.getAttribute('aria-pressed') === 'true') continue;

                            b.scrollIntoView({ behavior: 'smooth', block: 'center' });

                            if (rType === 'love' || rType === 'yêu thích') {
                                var rc = b.getBoundingClientRect();
                                var cx = rc.left + rc.width / 2;
                                var cy = rc.top + rc.height / 2;
                                var opts = { bubbles: true, cancelable: true, composed: true, view: window, clientX: cx, clientY: cy, buttons: 1 };
                                b.dispatchEvent(new PointerEvent('pointerdown', opts));
                                b.dispatchEvent(new MouseEvent('mouseover', opts));

                                setTimeout(function() {
                                    var love = document.querySelector('div[role=""toolbar""] div[aria-label=""Yêu thích""], div[role=""toolbar""] div[aria-label=""Love""]');
                                    if (love) love.click();
                                    else b.click();
                                }, 350);
                                return true;
                            } else {
                                b.click();
                                return true;
                            }
                        }
                    }
                }
                return false;
            ";
            object res = js.ExecuteScript(script, reactionType);
            return res is bool b && b;
        }
        catch
        {
            return false;
        }
    }

    private static void EnsureHtml5VideoPlaying(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return;
            string script = @"
                var v = document.querySelector('video');
                if (v) {
                    try {
                        v.muted = true;
                        v.play();
                    } catch (e) {}
                }
            ";
            js.ExecuteScript(script);
        }
        catch { }
    }

    private static List<string> ExtractFriendUrls(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js == null) return new List<string>();

            string script = @"
                var links = Array.from(document.querySelectorAll('a[role=""link""][href*=""facebook.com/""], div[role=""main""] a[role=""link""]'));
                var friends = [];
                for (var i = 0; i < links.length; i++) {
                    var href = links[i].getAttribute('href') || '';
                    if (href.indexOf('/friends') !== -1 || href.indexOf('/groups') !== -1 ||
                        href.indexOf('/watch') !== -1 || href.indexOf('/gaming') !== -1 ||
                        href.indexOf('/messages') !== -1 || href.indexOf('/events') !== -1 ||
                        href.indexOf('/saved') !== -1 || href.indexOf('#') !== -1) {
                        continue;
                    }
                    if (href.indexOf('profile.php?id=') !== -1 || (href.indexOf('facebook.com/') !== -1 && href.split('/').filter(Boolean).length >= 3)) {
                        if (friends.indexOf(href) === -1) {
                            friends.push(href);
                        }
                    }
                }
                return friends;
            ";
            object res = js.ExecuteScript(script);
            if (res is IEnumerable<object> list)
            {
                return list.Select(o => o.ToString()).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            }
        }
        catch { }
        return new List<string>();
    }

    #endregion
}
