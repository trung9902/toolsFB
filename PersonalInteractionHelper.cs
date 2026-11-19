using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Helper chuyên trách cho Nhóm 1: Tương tác cá nhân (Facebook Comet WWW 2026).
/// Quản lý toàn bộ 9 tính năng: Newsfeed, Story, Watch, Reel, Đọc thông báo, Kháng spam,
/// Chế độ chuyên nghiệp, Mở khóa profile, Nghỉ giải lao.
/// Tích hợp HumanScroll, xử lý chống checkpoint, fallback đa tầng, selector Comet 2026.
/// </summary>
public static class PersonalInteractionHelper
{
    private static readonly ThreadLocal<Random> _threadRandom = new ThreadLocal<Random>(() =>
        new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

    private static Random Rnd => _threadRandom.Value;

    #region 1. LƯỚT & TƯƠNG TÁC NEWSFEED (HDBaiVietNewsfeed, HDBaiVietNewsfeed2, HDBaiVietNewsfeed3)

    public static int InteractNewsfeed(fMain form, int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string E105C011)
    {
        int result = 0;
        try
        {
            if (chrome_0 == null || chrome_0.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int loginStatus = chrome_0.method_125();
            if (new List<int> { -3, -2, -1, 2 }.Contains(loginStatus)) return -1;

            int typeOptionsPost = gclass4_0.method_2("cbbOptionsPost", 0); // 0: theo số lượng bài, 1: theo thời gian
            int nudSoLuongFrom = gclass4_0.method_2("nudSoLuongFrom", 1);
            int nudSoLuongTo = gclass4_0.method_2("nudSoLuongTo", 3);
            int nudThoiGianFrom = gclass4_0.method_2("nudThoiGianFrom", 30);
            int nudThoiGianTo = gclass4_0.method_2("nudThoiGianTo", 60);
            int nudDelayFrom = gclass4_0.method_2("nudDelayFrom", 3);
            int nudDelayTo = gclass4_0.method_2("nudDelayTo", 5);

            bool ckbInteract = gclass4_0.method_3("ckbInteract");
            bool ckbComment = gclass4_0.method_3("ckbComment");
            List<string> listComments = gclass4_0.method_1("txtComment");
            bool ckbCommentImage = gclass4_0.method_3("ckbCommentImage");
            string pathImage = gclass4_0.BDB80B23("txtPathImage");
            bool ckbShare = gclass4_0.method_3("ckbShare");
            bool ckbLikePage = gclass4_0.method_3("ckbLikePage");
            bool ckbXemBaiVietChiDinh = gclass4_0.method_3("ckbXemBaiVietChiDinh") || gclass4_0.method_3("ckbXemAnh");

            int targetCount = (nudSoLuongTo > 0) ? Rnd.Next(nudSoLuongFrom, nudSoLuongTo + 1) : 1;
            int targetDurationSec = (nudThoiGianTo > 0) ? Rnd.Next(nudThoiGianFrom, nudThoiGianTo + 1) : 45;
            int startTick = Environment.TickCount;

            // Điều hướng về WWW Newsfeed
            IWebDriver driver = chrome_0.ChromeDriver_0;
            string currentUrl = driver.Url ?? "";
            if (!currentUrl.Contains("facebook.com") || currentUrl.Contains("/login") || currentUrl.Contains("/checkpoint"))
            {
                chrome_0.method_12("https://www.facebook.com/");
                SleepWithCancelCheck(2500);
            }
            else if (!currentUrl.EndsWith("facebook.com/") && !currentUrl.Contains("/?"))
            {
                chrome_0.method_12("https://www.facebook.com/");
                SleepWithCancelCheck(2000);
            }

            int interactedCount = 0;
            int scrollRound = 0;

            while (!Base.smethod_5() && !chrome_0.CD930D04())
            {
                if (typeOptionsPost == 0 && interactedCount >= targetCount)
                {
                    break;
                }
                if (typeOptionsPost == 1 && (Environment.TickCount - startTick) >= targetDurationSec * 1000)
                {
                    break;
                }

                scrollRound++;
                string progressMsg = (typeOptionsPost == 0)
                    ? $"{E105C011} ({interactedCount + 1}/{targetCount})..."
                    : $"{E105C011} ({Math.Min(targetDurationSec, (Environment.TickCount - startTick) / 1000)}/{targetDurationSec}s)...";

                form.method_130(int_3, string_1 + Language.GetValue("Đang") + " " + progressMsg);

                // Cuộn tự nhiên HumanScroll
                int scrollDist = Rnd.Next(380, 720);
                HumanScroll.ScrollNewsfeed(chrome_0, scrollDist);

                // Dừng lại đọc bài mô phỏng người thật
                SleepWithCancelCheck(Rnd.Next(1200, 2600));
                if (Base.smethod_5()) break;

                // Tương tác với bài viết đang hiển thị trên màn hình
                bool didInteractThisRound = false;

                if (ckbInteract || ckbComment || ckbShare || ckbLikePage || ckbXemBaiVietChiDinh)
                {
                    // Tìm các bài viết trên Comet WWW 2026
                    var postElements = GetVisibleFeedPosts(driver);
                    if (postElements != null && postElements.Count > 0)
                    {
                        IWebElement targetPost = postElements[Math.Min(postElements.Count - 1, Rnd.Next(0, postElements.Count))];

                        if (ckbInteract)
                        {
                            string reaction = PickReaction(gclass4_0);
                            bool okReact = ApplyReactionToPost(driver, targetPost, reaction);
                            if (okReact) didInteractThisRound = true;
                            SleepWithCancelCheck(Rnd.Next(600, 1200));
                        }

                        if (ckbComment && listComments != null && listComments.Count > 0)
                        {
                            string rawComment = listComments[Rnd.Next(0, listComments.Count)];
                            string commentText = Commom.smethod_31(rawComment).Trim();
                            if (!string.IsNullOrEmpty(commentText))
                            {
                                string singleImg = GetRandomImageFromPath(pathImage, ckbCommentImage);
                                bool okCmt = SubmitCommentToPost(driver, targetPost, commentText, singleImg);
                                if (okCmt) didInteractThisRound = true;
                                SleepWithCancelCheck(Rnd.Next(1000, 1800));
                            }
                        }

                        if (ckbShare && Rnd.Next(0, 3) == 0)
                        {
                            SharePostNow(driver, targetPost);
                            SleepWithCancelCheck(Rnd.Next(1200, 2000));
                        }

                        if (ckbLikePage && Rnd.Next(0, 4) == 0)
                        {
                            FollowOrLikeAuthorInPost(driver, targetPost);
                        }

                        if (ckbXemBaiVietChiDinh && Rnd.Next(0, 3) == 0)
                        {
                            ExpandSeeMoreInPost(driver, targetPost);
                            SleepWithCancelCheck(Rnd.Next(1500, 3000));
                        }
                    }
                }

                if (didInteractThisRound || typeOptionsPost == 1 || scrollRound % 3 == 0)
                {
                    interactedCount++;
                    result = 1;
                    form.method_131(int_3, string_1 + Language.GetValue("Đang nghỉ giữa các bài viết, chờ {time}s..."), nudDelayFrom, nudDelayTo);
                }
            }

            result = 1;
            return result;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    #endregion

    #region 2. XEM STORY (HDXemStory, HDXemStoryChiDinh)

    public static int WatchStory(fMain form, int int_3, string string_1, Chrome C3A67081, GClass4 AD3C1D98, string string_2)
    {
        return WatchStoryInternal(form, int_3, string_1, C3A67081, AD3C1D98, string_2, isSpecific: false);
    }

    public static int WatchStoryChiDinh(fMain form, int B13032AE, string string_1, Chrome C52B61BA, GClass4 gclass4_0, string string_2)
    {
        return WatchStoryInternal(form, B13032AE, string_1, C52B61BA, gclass4_0, string_2, isSpecific: true);
    }

    private static int WatchStoryInternal(fMain form, int rowIdx, string prefix, Chrome chrome, GClass4 config, string actionTitle, bool isSpecific)
    {
        try
        {
            if (chrome == null || chrome.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int nudSoLuongFrom = config.method_2("nudSoLuongFrom", 1);
            int nudSoLuongTo = config.method_2("nudSoLuongTo", 3);
            int nudDelayFrom = config.method_2("nudDelayFrom", 3);
            int nudDelayTo = config.method_2("nudDelayTo", 6);
            bool ckbInteract = config.method_3("ckbInteract");
            bool ckbComment = config.method_3("ckbComment");
            List<string> listComments = config.method_1("txtComment");

            int targetCount = Rnd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
            List<string> specificLinks = isSpecific ? config.method_1("txtLinkStory") : new List<string>();

            IWebDriver driver = chrome.ChromeDriver_0;
            int viewedCount = 0;

            if (isSpecific && specificLinks.Count > 0)
            {
                foreach (var link in specificLinks.Where(l => !string.IsNullOrWhiteSpace(l)))
                {
                    if (Base.smethod_5() || chrome.CD930D04()) break;
                    if (viewedCount >= targetCount) break;

                    string storyUrl = link.Trim();
                    if (!storyUrl.StartsWith("http")) storyUrl = "https://www.facebook.com/stories/" + storyUrl;
                    chrome.method_12(storyUrl);
                    SleepWithCancelCheck(2500);

                    form.method_130(rowIdx, prefix + Language.GetValue("Đang") + $" {actionTitle} ({viewedCount + 1}/{targetCount})...");
                    InteractSingleStory(driver, config, ckbInteract, ckbComment, listComments, nudDelayFrom, nudDelayTo);
                    viewedCount++;
                    form.method_131(rowIdx, prefix + Language.GetValue("Chờ {time}s..."), nudDelayFrom, nudDelayTo);
                }
            }
            else
            {
                chrome.method_12("https://www.facebook.com/stories/");
                SleepWithCancelCheck(3000);

                while (viewedCount < targetCount && !Base.smethod_5() && !chrome.CD930D04())
                {
                    form.method_130(rowIdx, prefix + Language.GetValue("Đang") + $" {actionTitle} ({viewedCount + 1}/{targetCount})...");
                    InteractSingleStory(driver, config, ckbInteract, ckbComment, listComments, nudDelayFrom, nudDelayTo);
                    viewedCount++;

                    // Nhấn next story trên Comet WWW
                    NextStoryComet(driver);
                    SleepWithCancelCheck(Rnd.Next(1500, 2500));
                }
            }

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    private static void InteractSingleStory(IWebDriver driver, GClass4 config, bool ckbInteract, bool ckbComment, List<string> listComments, int delayFrom, int delayTo)
    {
        int watchMs = Rnd.Next(Math.Max(2, delayFrom), Math.Max(3, delayTo) + 1) * 1000;
        SleepWithCancelCheck(watchMs);
        if (Base.smethod_5()) return;

        if (ckbInteract)
        {
            string reaction = PickReaction(config);
            ReactStoryComet(driver, reaction);
            SleepWithCancelCheck(800);
        }

        if (ckbComment && listComments != null && listComments.Count > 0)
        {
            string rawComment = listComments[Rnd.Next(0, listComments.Count)];
            string cmt = Commom.smethod_31(rawComment).Trim();
            if (!string.IsNullOrEmpty(cmt))
            {
                ReplyStoryComet(driver, cmt);
            }
        }
    }

    private static void NextStoryComet(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // 1. Dispatch ArrowRight keyboard event
            js.ExecuteScript("window.dispatchEvent(new KeyboardEvent('keydown', { key: 'ArrowRight', code: 'ArrowRight', keyCode: 39, which: 39, bubbles: true }));");
            // 2. Fallback tìm nút next story
            js.ExecuteScript(@"
                var nextBtn = document.querySelector('div[aria-label*=""Tiếp"" i][role=""button""], div[aria-label*=""Next"" i][role=""button""], div[aria-label*=""tiếp theo"" i][role=""button""]');
                if (nextBtn) nextBtn.click();
            ");
        }
        catch { }
    }

    private static void ReactStoryComet(IWebDriver driver, string reaction)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string targetLabel = (reaction.ToLowerInvariant() == "like" || reaction == "Thích") ? "thích" : reaction.ToLowerInvariant();
            js.ExecuteScript(@"
                var rType = arguments[0];
                var buttons = document.querySelectorAll('div[role=""toolbar""] div[role=""button""], div[aria-label*=""bày tỏ cảm xúc"" i] div[role=""button""], div[role=""main""] div[role=""button""][aria-label]');
                for (var i = 0; i < buttons.length; i++) {
                    var l = (buttons[i].getAttribute('aria-label') || '').toLowerCase();
                    if (l.indexOf(rType) >= 0 || (rType === 'thích' && (l.indexOf('like') >= 0 || l.indexOf('thích') >= 0))) {
                        buttons[i].click();
                        return true;
                    }
                }
                // Fallback click reaction đầu tiên trên toolbar
                var firstBtn = document.querySelector('div[role=""toolbar""] div[role=""button""]');
                if (firstBtn) { firstBtn.click(); return true; }
                return false;
            ", targetLabel);
        }
        catch { }
    }

    private static void ReplyStoryComet(IWebDriver driver, string text)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var text = arguments[0];
                var input = document.querySelector('input[placeholder*=""Trả lời"" i], input[placeholder*=""Reply"" i], div[role=""textbox""][aria-label*=""Trả lời"" i], div[role=""textbox""][aria-label*=""Reply"" i]');
                if (input) {
                    input.focus();
                    if (input.tagName.toLowerCase() === 'input') {
                        input.value = text;
                        input.dispatchEvent(new Event('input', { bubbles: true }));
                        input.dispatchEvent(new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true }));
                    } else {
                        document.execCommand('insertText', false, text);
                        input.dispatchEvent(new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true }));
                    }
                }
            ", text);
        }
        catch { }
    }

    #endregion

    #region 3. XEM WATCH (HDXemWatch)

    public static int WatchVideo(fMain form, int CFAD1B05, string D39A8225, Chrome chrome_0, GClass4 F804943F, string ACA2BEBF)
    {
        try
        {
            if (chrome_0 == null || chrome_0.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int nudSoLuongFrom = F804943F.method_2("nudSoLuongFrom", 1);
            int nudSoLuongTo = F804943F.method_2("nudSoLuongTo", 3);
            int nudTimeFrom = F804943F.method_2("nudTimeFrom", 15);
            int nudTimeTo = F804943F.method_2("nudTimeTo", 30);
            int nudDelayFrom = F804943F.method_2("nudDelayFrom", 3);
            int nudDelayTo = F804943F.method_2("nudDelayTo", 5);

            bool ckbInteract = F804943F.method_3("ckbInteract");
            bool ckbComment = F804943F.method_3("ckbComment");
            List<string> listComments = F804943F.method_1("txtComment");
            bool ckbFollow = F804943F.method_3("ckbFollow");

            int targetCount = Rnd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
            IWebDriver driver = chrome_0.ChromeDriver_0;

            chrome_0.method_12("https://www.facebook.com/watch/");
            SleepWithCancelCheck(3000);

            for (int i = 0; i < targetCount; i++)
            {
                if (Base.smethod_5() || chrome_0.CD930D04()) break;

                form.method_130(CFAD1B05, D39A8225 + Language.GetValue("Đang") + $" {ACA2BEBF} ({i + 1}/{targetCount})...");

                // Kích hoạt play video nếu đang tạm dừng
                EnsureVideoPlaying(driver);

                int watchDurationSec = Rnd.Next(nudTimeFrom, nudTimeTo + 1);
                int watchElapsed = 0;
                while (watchElapsed < watchDurationSec && !Base.smethod_5())
                {
                    SleepWithCancelCheck(2000);
                    watchElapsed += 2;
                }

                if (Base.smethod_5()) break;

                // Tương tác với video
                if (ckbInteract)
                {
                    string reaction = PickReaction(F804943F);
                    ReactCurrentVideo(driver, reaction);
                    SleepWithCancelCheck(800);
                }

                if (ckbComment && listComments != null && listComments.Count > 0)
                {
                    string rawComment = listComments[Rnd.Next(0, listComments.Count)];
                    string cmt = Commom.smethod_31(rawComment).Trim();
                    if (!string.IsNullOrEmpty(cmt))
                    {
                        CommentCurrentVideo(driver, cmt);
                        SleepWithCancelCheck(1200);
                    }
                }

                if (ckbFollow && Rnd.Next(0, 3) == 0)
                {
                    FollowCurrentVideoCreator(driver);
                }

                // Cuộn mượt đến video tiếp theo với HumanScroll
                int scrollDistance = Rnd.Next(650, 950);
                HumanScroll.ScrollNewsfeed(chrome_0, scrollDistance);
                form.method_131(CFAD1B05, D39A8225 + Language.GetValue("Nghỉ chuyển video, chờ {time}s..."), nudDelayFrom, nudDelayTo);
            }

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    private static void EnsureVideoPlaying(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var videos = document.querySelectorAll('video');
                for (var i = 0; i < videos.length; i++) {
                    var v = videos[i];
                    var rect = v.getBoundingClientRect();
                    if (rect.top >= -100 && rect.bottom <= window.innerHeight + 100) {
                        if (v.paused) { v.play().catch(function(){}); }
                        break;
                    }
                }
            ");
        }
        catch { }
    }

    private static void ReactCurrentVideo(IWebDriver driver, string reaction)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var btn = document.querySelector('div[role=""article""] div[role=""button""][aria-label*=""Thích"" i], div[role=""article""] div[role=""button""][aria-label*=""Like"" i], div[role=""main""] div[role=""button""][aria-label*=""Thích"" i], div[role=""main""] div[role=""button""][aria-label*=""Like"" i]');
                if (btn) {
                    var isPressed = btn.getAttribute('aria-pressed');
                    if (isPressed !== 'true') btn.click();
                }
            ");
        }
        catch { }
    }

    private static void CommentCurrentVideo(IWebDriver driver, string cmt)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var text = arguments[0];
                var cmtBtn = document.querySelector('div[role=""article""] div[role=""button""][aria-label*=""Bình luận"" i], div[role=""article""] div[role=""button""][aria-label*=""Comment"" i]');
                if (cmtBtn) cmtBtn.click();
                setTimeout(function() {
                    var tb = document.querySelector('div[role=""textbox""][contenteditable=""true""]');
                    if (tb) {
                        tb.focus();
                        document.execCommand('insertText', false, text);
                        tb.dispatchEvent(new Event('input', { bubbles: true }));
                        tb.dispatchEvent(new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true }));
                    }
                }, 800);
            ", cmt);
        }
        catch { }
    }

    private static void FollowCurrentVideoCreator(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var btns = document.querySelectorAll('div[role=""button""]');
                for (var i = 0; i < btns.length; i++) {
                    var t = (btns[i].innerText || btns[i].textContent || '').trim().toLowerCase();
                    if (t === 'theo dõi' || t === 'follow' || t === '+ theo dõi') {
                        btns[i].click();
                        break;
                    }
                }
            ");
        }
        catch { }
    }

    #endregion

    #region 4. TƯƠNG TÁC REEL (HDTuongTacReelNgauNhien, HDTuongTacReelChiDinh)

    public static int InteractReelRandom(fMain form, int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2, string string_3)
    {
        return InteractReelInternal(form, int_3, string_1, chrome_0, gclass4_0, string_2, isSpecific: false);
    }

    public static int InteractReelSpecific(fMain form, int int_3, string A3248B14, Chrome chrome_0, GClass4 gclass4_0, string string_1, string string_2)
    {
        return InteractReelInternal(form, int_3, A3248B14, chrome_0, gclass4_0, string_1, isSpecific: true);
    }

    private static int InteractReelInternal(fMain form, int rowIdx, string prefix, Chrome chrome, GClass4 config, string actionTitle, bool isSpecific)
    {
        try
        {
            if (chrome == null || chrome.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int nudSoLuongFrom = config.method_2("nudSoLuongUidFrom", config.method_2("nudSoLuongFrom", 1));
            int nudSoLuongTo = config.method_2("nudSoLuongUidTo", config.method_2("nudSoLuongTo", 3));
            int nudTimeFrom = config.method_2("nudTimeFrom", 5);
            int nudTimeTo = config.method_2("nudTimeTo", 15);
            int nudDelayFrom = config.method_2("nudDelayFrom", 3);
            int nudDelayTo = config.method_2("nudDelayTo", 5);

            bool ckbInteract = config.method_3("ckbInteract");
            bool ckbComment = config.method_3("ckbComment");
            List<string> listComments = config.method_1("txtComment");
            bool ckbFollow = config.method_3("ckbFollow");

            int targetCount = (nudSoLuongTo > 0) ? Rnd.Next(nudSoLuongFrom, nudSoLuongTo + 1) : 1;
            List<string> specificLinks = isSpecific ? config.method_1("txtIdPost") : new List<string>();
            if (isSpecific && (specificLinks == null || specificLinks.Count == 0))
            {
                specificLinks = config.method_1("txtLink");
            }

            IWebDriver driver = chrome.ChromeDriver_0;
            int countDone = 0;

            if (isSpecific && specificLinks.Count > 0)
            {
                foreach (var link in specificLinks.Where(l => !string.IsNullOrWhiteSpace(l)))
                {
                    if (Base.smethod_5() || chrome.CD930D04()) break;
                    if (countDone >= targetCount) break;

                    string reelUrl = link.Trim();
                    if (!reelUrl.StartsWith("http")) reelUrl = "https://www.facebook.com/reel/" + reelUrl;
                    chrome.method_12(reelUrl);
                    SleepWithCancelCheck(3000);

                    form.method_130(rowIdx, prefix + Language.GetValue("Đang") + $" {actionTitle} ({countDone + 1}/{targetCount})...");
                    InteractSingleReel(driver, config, ckbInteract, ckbComment, listComments, ckbFollow, nudTimeFrom, nudTimeTo);
                    countDone++;
                    form.method_131(rowIdx, prefix + Language.GetValue("Chờ {time}s..."), nudDelayFrom, nudDelayTo);
                }
            }
            else
            {
                chrome.method_12("https://www.facebook.com/reel/");
                SleepWithCancelCheck(3500);

                while (countDone < targetCount && !Base.smethod_5() && !chrome.CD930D04())
                {
                    form.method_130(rowIdx, prefix + Language.GetValue("Đang") + $" {actionTitle} ({countDone + 1}/{targetCount})...");
                    InteractSingleReel(driver, config, ckbInteract, ckbComment, listComments, ckbFollow, nudTimeFrom, nudTimeTo);
                    countDone++;

                    // Chuyển sang Reel kế tiếp bằng ArrowDown hoặc nút Next
                    NextReelComet(driver);
                    form.method_131(rowIdx, prefix + Language.GetValue("Chờ {time}s..."), nudDelayFrom, nudDelayTo);
                }
            }

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    private static void InteractSingleReel(IWebDriver driver, GClass4 config, bool ckbInteract, bool ckbComment, List<string> listComments, bool ckbFollow, int timeFrom, int timeTo)
    {
        int watchDurationMs = Rnd.Next(timeFrom, timeTo + 1) * 1000;
        SleepWithCancelCheck(watchDurationMs);
        if (Base.smethod_5()) return;

        if (ckbInteract)
        {
            ReactReelComet(driver);
            SleepWithCancelCheck(800);
        }

        if (ckbComment && listComments != null && listComments.Count > 0)
        {
            string rawComment = listComments[Rnd.Next(0, listComments.Count)];
            string cmt = Commom.smethod_31(rawComment).Trim();
            if (!string.IsNullOrEmpty(cmt))
            {
                CommentReelComet(driver, cmt);
                SleepWithCancelCheck(1000);
            }
        }

        if (ckbFollow && Rnd.Next(0, 3) == 0)
        {
            FollowReelCreatorComet(driver);
        }
    }

    private static void NextReelComet(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.dispatchEvent(new KeyboardEvent('keydown', { key: 'ArrowDown', code: 'ArrowDown', keyCode: 40, which: 40, bubbles: true }));");
            js.ExecuteScript(@"
                var nextBtn = document.querySelector('div[aria-label*=""Next Card"" i][role=""button""], div[aria-label*=""tiếp theo"" i][role=""button""], div[aria-label*=""Next"" i][role=""button""]');
                if (nextBtn) nextBtn.click();
            ");
        }
        catch { }
    }

    private static void ReactReelComet(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var likeBtn = document.querySelector('div[role=""main""] div[role=""button""][aria-label*=""Like"" i], div[role=""main""] div[role=""button""][aria-label*=""Thích"" i]');
                if (likeBtn) {
                    var pressed = likeBtn.getAttribute('aria-pressed');
                    if (pressed !== 'true') likeBtn.click();
                }
            ");
        }
        catch { }
    }

    private static void CommentReelComet(IWebDriver driver, string text)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var text = arguments[0];
                var cmtBtn = document.querySelector('div[role=""main""] div[role=""button""][aria-label*=""Bình luận"" i], div[role=""main""] div[role=""button""][aria-label*=""Comment"" i]');
                if (cmtBtn) {
                    cmtBtn.click();
                    setTimeout(function() {
                        var tb = document.querySelector('div[role=""dialog""] div[role=""textbox""], div[role=""textbox""][contenteditable=""true""]');
                        if (tb) {
                            tb.focus();
                            document.execCommand('insertText', false, text);
                            tb.dispatchEvent(new Event('input', { bubbles: true }));
                            tb.dispatchEvent(new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true }));
                        }
                    }, 800);
                }
            ", text);
        }
        catch { }
    }

    private static void FollowReelCreatorComet(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var btns = document.querySelectorAll('div[role=""main""] div[role=""button""]');
                for (var i = 0; i < btns.length; i++) {
                    var t = (btns[i].innerText || btns[i].textContent || '').trim().toLowerCase();
                    if (t === 'theo dõi' || t === 'follow') {
                        btns[i].click();
                        break;
                    }
                }
            ");
        }
        catch { }
    }

    #endregion

    #region 5. ĐỌC THÔNG BÁO (HDDocThongBao)

    public static int ReadNotifications(fMain form, int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string D41E6F97)
    {
        try
        {
            if (chrome_0 == null || chrome_0.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int nudSoLuongFrom = gclass4_0.method_2("nudSoLuongFrom", 1);
            int nudSoLuongTo = gclass4_0.method_2("nudSoLuongTo", 3);
            int typeDocThongBao = gclass4_0.method_2("typeDocThongBao", 0); // 0: Lần lượt, 1: Ngẫu nhiên
            int nudDelayFrom = gclass4_0.method_2("nudDelayFrom", 3);
            int nudDelayTo = gclass4_0.method_2("nudDelayTo", 5);

            int targetCount = Rnd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
            IWebDriver driver = chrome_0.ChromeDriver_0;

            // Mở trang thông báo trực tiếp trên Facebook Comet WWW
            chrome_0.method_12("https://www.facebook.com/notifications/");
            SleepWithCancelCheck(3000);

            int readCount = 0;

            for (int i = 0; i < targetCount; i++)
            {
                if (Base.smethod_5() || chrome_0.CD930D04()) break;

                form.method_130(int_3, string_1 + Language.GetValue("Đang") + $" {D41E6F97} ({i + 1}/{targetCount})...");

                // Cuộn nhẹ danh sách thông báo bằng HumanScroll
                HumanScroll.ScrollNewsfeed(chrome_0, 150);
                SleepWithCancelCheck(800);

                // Click vào thông báo (lần lượt hoặc ngẫu nhiên)
                bool clicked = ClickNotificationItem(driver, typeDocThongBao, i);
                if (clicked)
                {
                    readCount++;
                    // Dừng xem nội dung bài thông báo
                    int readSec = Rnd.Next(nudDelayFrom, nudDelayTo + 1);
                    SleepWithCancelCheck(readSec * 1000);

                    // Quay lại trang thông báo nếu đã chuyển hướng
                    if (driver.Url != null && !driver.Url.Contains("/notifications"))
                    {
                        chrome_0.method_12("https://www.facebook.com/notifications/");
                        SleepWithCancelCheck(2000);
                    }
                }

                form.method_131(int_3, string_1 + Language.GetValue("Nghỉ giữa các thông báo, chờ {time}s..."), nudDelayFrom, nudDelayTo);
            }

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    private static bool ClickNotificationItem(IWebDriver driver, int typeMode, int indexOrder)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                var mode = arguments[0];
                var order = arguments[1];
                var links = document.querySelectorAll('div[role=""feed""] a[role=""link""], div[role=""main""] a[href*=""notif_id""], a[href*=""notif_t""], div[role=""dialog""] a[role=""link""]');
                if (!links || links.length === 0) return false;
                var targetIdx = (mode === 0) ? Math.min(order, links.length - 1) : Math.floor(Math.random() * links.length);
                var link = links[targetIdx];
                if (link) {
                    link.scrollIntoView({ behavior: 'smooth', block: 'center' });
                    link.click();
                    return true;
                }
                return false;
            ", typeMode, indexOrder);

            return res is bool b && b;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region 6. KHÁNG NGHỊ SPAM / SUPPORT INBOX (HDKhangSpam)

    public static int AppealSpam(fMain form, int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2, string B89388BF)
    {
        try
        {
            if (chrome_0 == null || chrome_0.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int nudSoLuongFrom = gclass4_0.method_2("nudSoLuongFrom", 1);
            int nudSoLuongTo = gclass4_0.method_2("nudSoLuongTo", 3);
            int nudDelayFrom = gclass4_0.method_2("nudDelayFrom", 3);
            int nudDelayTo = gclass4_0.method_2("nudDelayTo", 5);

            int targetCount = Rnd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
            IWebDriver driver = chrome_0.ChromeDriver_0;

            // Điều hướng đến Support Inbox
            chrome_0.method_12("https://www.facebook.com/support/");
            SleepWithCancelCheck(3000);

            // Nếu WWW trống hoặc lỗi, fallback qua mbasic support inbox
            bool hasCasesWWW = CheckHasCases(driver);
            if (!hasCasesWWW)
            {
                chrome_0.method_12("https://mbasic.facebook.com/support/?num_to_show=1000");
                SleepWithCancelCheck(2500);
            }

            int countAppealed = 0;
            for (int i = 0; i < targetCount; i++)
            {
                if (Base.smethod_5() || chrome_0.CD930D04()) break;

                form.method_130(int_3, string_1 + Language.GetValue("Đang") + $" {B89388BF} ({i + 1}/{targetCount})...");

                bool appealSuccess = ExecuteAppealStep(driver);
                if (appealSuccess)
                {
                    countAppealed++;
                }

                form.method_131(int_3, string_1 + Language.GetValue("Chờ {time}s..."), nudDelayFrom, nudDelayTo);
            }

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    private static bool CheckHasCases(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                var items = document.querySelectorAll('a[href*=""/support/""], div[role=""feed""] a');
                return items && items.length > 0;
            ");
            return res is bool b && b;
        }
        catch { return false; }
    }

    private static bool ExecuteAppealStep(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                // 1. Click vào vụ việc / case chưa giải quyết
                var caseLink = document.querySelector('a[href*=""/support/view_details""], a[href*=""/support/ticket""], a[href*=""support/?num_to_show""]');
                if (caseLink) {
                    caseLink.click();
                    return true;
                }
                // 2. Tìm nút Không đồng ý / Kháng nghị
                var btns = document.querySelectorAll('div[role=""button""], input[type=""submit""], button');
                for (var i = 0; i < btns.length; i++) {
                    var txt = (btns[i].innerText || btns[i].value || btns[i].textContent || '').toLowerCase();
                    if (txt.indexOf('không đồng ý') >= 0 || txt.indexOf('disagree') >= 0 || txt.indexOf('kháng nghị') >= 0 || txt.indexOf('appeal') >= 0 || txt.indexOf('request review') >= 0) {
                        btns[i].click();
                        return true;
                    }
                }
                // 3. Nút Tiếp tục / Gửi
                for (var j = 0; j < btns.length; j++) {
                    var t2 = (btns[j].innerText || btns[j].value || btns[j].textContent || '').toLowerCase();
                    if (t2 === 'tiếp' || t2 === 'next' || t2 === 'tiếp tục' || t2 === 'gửi' || t2 === 'submit' || t2 === 'đóng' || t2 === 'close') {
                        btns[j].click();
                        return true;
                    }
                }
                return false;
            ");
            return res is bool b && b;
        }
        catch { return false; }
    }

    #endregion

    #region 7. BẬT / TẮT CHẾ ĐỘ CHUYÊN NGHIỆP (HDBatCheDoChuyenNghiep)

    public static int ToggleProfessionalMode(fMain form, ref string FE912FA1, int int_3, string string_1, Chrome BDBFB20C, GClass4 D4A00F82, string B0000B04)
    {
        try
        {
            if (BDBFB20C == null || BDBFB20C.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int typeChucNang = D4A00F82.method_2("cbbTuyChon", D4A00F82.method_2("typeChucNang", 0)); // 0: Bật, 1: Tắt
            string modeParam = (typeChucNang == 0) ? "on" : "off";
            string modeName = (typeChucNang == 0) ? Language.GetValue("Bật chế độ chuyên nghiệp") : Language.GetValue("Tắt chế độ chuyên nghiệp");

            form.method_130(int_3, string_1 + Language.GetValue("Đang") + $" {modeName}...");

            // 1. Thử qua AccountsCenterHub
            try
            {
                string hubResult = AccountsCenterHub.Execute(BDBFB20C, "ProfessionalMode", modeParam);
                if (!string.IsNullOrEmpty(hubResult) && !hubResult.Contains("\"success\":false"))
                {
                    FE912FA1 = Language.GetValue("Thành công");
                    return 1;
                }
            }
            catch { }

            // 2. Thử qua method_97 có sẵn trong Chrome
            try
            {
                if (BDBFB20C.method_97(typeChucNang == 0))
                {
                    FE912FA1 = Language.GetValue("Thành công");
                    return 1;
                }
            }
            catch { }

            // 2. Fallback trực tiếp qua Profile Menu trên Comet WWW 2026
            IWebDriver driver = BDBFB20C.ChromeDriver_0;
            BDBFB20C.method_12("https://www.facebook.com/me");
            SleepWithCancelCheck(3500);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Click nút 3 chấm trên trang cá nhân
            js.ExecuteScript(@"
                var btns = document.querySelectorAll('div[role=""button""][aria-label]');
                for (var i = 0; i < btns.length; i++) {
                    var l = (btns[i].getAttribute('aria-label') || '').toLowerCase();
                    if (l.indexOf('xem thêm') >= 0 || l.indexOf('more') >= 0 || l.indexOf('tùy chọn') >= 0 || l.indexOf('settings') >= 0) {
                        btns[i].click();
                        break;
                    }
                }
            ");
            SleepWithCancelCheck(1500);

            // Click menu item Chế độ chuyên nghiệp
            js.ExecuteScript(@"
                var items = document.querySelectorAll('div[role=""menuitem""]');
                for (var i = 0; i < items.length; i++) {
                    var t = (items[i].innerText || items[i].textContent || '').toLowerCase();
                    if (t.indexOf('chế độ chuyên nghiệp') >= 0 || t.indexOf('professional mode') >= 0) {
                        items[i].click();
                        break;
                    }
                }
            ");
            SleepWithCancelCheck(2000);

            // Click nút xác nhận trong dialog
            js.ExecuteScript(@"
                var dBtns = document.querySelectorAll('div[role=""dialog""] div[role=""button""]');
                for (var i = 0; i < dBtns.length; i++) {
                    var t = (dBtns[i].innerText || dBtns[i].textContent || '').trim().toLowerCase();
                    if (t === 'bật' || t === 'turn on' || t === 'tắt' || t === 'turn off' || t === 'tiếp tục' || t === 'done' || t === 'xong') {
                        dBtns[i].click();
                        break;
                    }
                }
            ");
            SleepWithCancelCheck(2500);

            FE912FA1 = Language.GetValue("Thành công");
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    #endregion

    #region 8. MỞ KHÓA / KHÓA TRANG CÁ NHÂN (HDUnlockProfile)

    public static int UnlockOrLockProfile(fMain form, int F63AC827, string string_1, Chrome chrome_0, GClass4 gclass4_0, string DD18C120)
    {
        try
        {
            if (chrome_0 == null || chrome_0.CD930D04()) return 0;
            if (Base.smethod_5()) return 0;

            int typeChucNang = gclass4_0.method_2("cbbTuyChon", gclass4_0.method_2("typeChucNang", 0)); // 0: Mở khóa, 1: Khóa bảo vệ
            string actionName = (typeChucNang == 0) ? "UnlockProfile" : "LockProfile";
            string label = (typeChucNang == 0) ? Language.GetValue("Mở khóa profile") : Language.GetValue("Khóa bảo vệ profile");

            form.method_130(F63AC827, string_1 + Language.GetValue("Đang") + $" {label}...");

            // 1. Thử qua AccountsCenterHub
            try
            {
                string hubResult = AccountsCenterHub.Execute(chrome_0, actionName, "");
                if (!string.IsNullOrEmpty(hubResult) && !hubResult.Contains("\"success\":false"))
                {
                    return 1;
                }
            }
            catch { }

            // 2. Thử qua method_95 / method_96 có sẵn trong Chrome
            try
            {
                string res = (typeChucNang == 0) ? chrome_0.method_95() : chrome_0.method_96();
                if (!string.IsNullOrEmpty(res) && !res.Contains("\"success\":false") && !res.Contains("\"success\": false"))
                {
                    return 1;
                }
            }
            catch { }

            // 2. Fallback trực tiếp qua Profile Menu Comet WWW 2026
            IWebDriver driver = chrome_0.ChromeDriver_0;
            chrome_0.method_12("https://www.facebook.com/me");
            SleepWithCancelCheck(3500);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Click 3-dots
            js.ExecuteScript(@"
                var btns = document.querySelectorAll('div[role=""button""][aria-label]');
                for (var i = 0; i < btns.length; i++) {
                    var l = (btns[i].getAttribute('aria-label') || '').toLowerCase();
                    if (l.indexOf('xem thêm') >= 0 || l.indexOf('more') >= 0 || l.indexOf('tùy chọn') >= 0) {
                        btns[i].click();
                        break;
                    }
                }
            ");
            SleepWithCancelCheck(1500);

            // Click menu item Khóa / Mở khóa
            string keyword = (typeChucNang == 0) ? "mở khóa" : "khóa";
            js.ExecuteScript(@"
                var kw = arguments[0];
                var items = document.querySelectorAll('div[role=""menuitem""]');
                for (var i = 0; i < items.length; i++) {
                    var t = (items[i].innerText || items[i].textContent || '').toLowerCase();
                    if (t.indexOf(kw) >= 0 || t.indexOf('lock') >= 0 || t.indexOf('unlock') >= 0) {
                        items[i].click();
                        break;
                    }
                }
            ", keyword);
            SleepWithCancelCheck(2000);

            // Xác nhận trong dialog
            js.ExecuteScript(@"
                var dBtns = document.querySelectorAll('div[role=""dialog""] div[role=""button""]');
                for (var i = 0; i < dBtns.length; i++) {
                    var t = (dBtns[i].innerText || dBtns[i].textContent || '').trim().toLowerCase();
                    if (t.indexOf('mở khóa') >= 0 || t.indexOf('khóa') >= 0 || t === 'ok' || t === 'xác nhận') {
                        dBtns[i].click();
                        break;
                    }
                }
            ");
            SleepWithCancelCheck(2000);

            return 1;
        }
        catch
        {
            return 0;
        }
    }

    #endregion

    #region 9. NGHỈ GIẢI LAO (HDNghiGiaiLao)

    public static int TakeBreak(fMain form, int int_3, string string_1, GClass4 gclass4_0, string F7BDC820)
    {
        try
        {
            if (Base.smethod_5()) return 0;
            int delayFrom = gclass4_0.method_2("nudDelayFrom", 5);
            int delayTo = gclass4_0.method_2("nudDelayTo", 10);

            form.method_131(int_3, string_1 + string.Format(Language.GetValue("Đang {0}, " + Language.GetValue("đợi") + " {{time}}s..."), F7BDC820), delayFrom, delayTo);
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    #endregion

    #region 10. TƯƠNG TÁC LIVESTREAM COMET 2026 (HDTuongTacLivestream)

    /// <summary>
    /// Kịch bản Tương tác Livestream tích hợp cho form fMain (HDTuongTacLivestream).
    /// Hỗ trợ Live Chatbox Comet 2026, Floating Live Reactions, Watch Timer.
    /// </summary>
    public static int InteractLivestream(fMain form, int int_3, string string_1, Chrome chrome_0, GClass4 gclass4_0, string string_2, string string_3)
    {
        if (chrome_0 == null || chrome_0.CD930D04()) return 0;
        if (Base.smethod_5()) return 0;

        chrome_0.method_49();
        chrome_0.method_53();
        int result = 0;
        try
        {
            string linkVideo = gclass4_0.BDB80B23("txtLinkVideo");
            int timeFrom = gclass4_0.method_2("nudTimeFrom", 30);
            int timeTo = gclass4_0.method_2("nudTimeTo", 60);
            bool ckbInteract = gclass4_0.method_3("ckbInteract");
            string typeReaction = gclass4_0.BDB80B23("typeReaction");
            bool ckbComment = gclass4_0.method_3("ckbComment");
            bool ckbTuDongXoaNoiDung = gclass4_0.method_3("ckbTuDongXoaNoiDung");
            bool ckbLapLaiTuongTac = gclass4_0.method_3("ckbLapLaiTuongTac");
            bool ckbLapLaiTuongTacInteract = ckbLapLaiTuongTac && gclass4_0.method_3("ckbLapLaiTuongTacInteract");
            bool ckbLapLaiTuongTacComment = ckbLapLaiTuongTac && gclass4_0.method_3("ckbLapLaiTuongTacComment");

            int watchDurationSec = (timeTo >= timeFrom && timeTo > 0) ? Rnd.Next(timeFrom, timeTo + 1) : 30;

            List<string> reactions = new List<string>();
            if (ckbInteract || ckbLapLaiTuongTacInteract)
            {
                reactions = ParseReactionTypes(typeReaction);
                if (reactions.Count == 0)
                {
                    reactions.Add("Like");
                    reactions.Add("Love");
                }
            }

            List<string> comments = new List<string>();
            if (ckbComment || ckbLapLaiTuongTacComment)
            {
                if (form != null && form.dictionary_18 != null && form.dictionary_18.ContainsKey(string_3))
                {
                    lock (form.dictionary_18)
                    {
                        var dictList = form.dictionary_18[string_3];
                        if (dictList != null && dictList.Count > 0)
                        {
                            if (ckbTuDongXoaNoiDung)
                            {
                                string cmt = dictList.smethod_8();
                                dictList.Remove(cmt);
                                if (!string.IsNullOrEmpty(cmt)) comments.Add(cmt);
                            }
                            else
                            {
                                string cmt = dictList.smethod_8();
                                if (!string.IsNullOrEmpty(cmt)) comments.Add(cmt);
                            }
                        }
                    }
                }
                if (comments.Count == 0)
                {
                    comments = gclass4_0.method_1("txtComment");
                }
            }

            Action<string> logCallback = (msg) =>
            {
                form?.method_130(int_3, string_1 + Language.GetValue("Đang") + " " + string_2 + ": " + msg);
            };

            bool ok = InteractLivestreamV2(chrome_0, linkVideo, watchDurationSec, reactions, comments, logCallback, ckbLapLaiTuongTacComment);
            result = ok ? 1 : 0;
        }
        catch (Exception ex)
        {
            Commom.smethod_58(ex, "InteractLivestream");
            result = 0;
        }
        finally
        {
            chrome_0.method_54();
        }
        return result;
    }

    /// <summary>
    /// Nâng cấp Kịch bản Tương tác Livestream Comet 2026 (Live Chatbox, Floating Reactions, Watch timer).
    /// </summary>
    public static bool InteractLivestreamV2(
        Chrome chrome,
        string liveUrlOrId,
        int watchDurationSec,
        List<string> reactions,
        List<string> comments,
        Action<string> logCallback = null,
        bool loopComments = false)
    {
        try
        {
            if (chrome == null || chrome.CD930D04()) return false;
            if (string.IsNullOrWhiteSpace(liveUrlOrId))
            {
                logCallback?.Invoke("Lỗi: Link hoặc ID livestream không được để trống.");
                return false;
            }
            if (Base.smethod_5()) return false;

            string targetLink = liveUrlOrId.Split(new[] { (char)13, (char)10, '|' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim() ?? liveUrlOrId.Trim();
            string targetUrl = targetLink;
            if (!targetUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !targetUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                if (Regex.IsMatch(targetUrl, @"^\d+$"))
                {
                    targetUrl = "https://www.facebook.com/watch/live/?v=" + targetUrl;
                }
                else
                {
                    targetUrl = "https://www.facebook.com/" + targetUrl.TrimStart('/');
                }
            }

            logCallback?.Invoke($"Điều hướng tới livestream: {targetUrl}...");
            chrome.method_12(targetUrl);
            SleepWithCancelCheck(2500);
            if (Base.smethod_5() || chrome.CD930D04()) return false;

            IWebDriver driver = chrome.ChromeDriver_0;

            // Chờ player tải xong và video bắt đầu phát
            logCallback?.Invoke("Đang kiểm tra player livestream Comet 2026...");
            bool playerReady = false;
            int waitSec = 0;
            while (waitSec < 15 && !Base.smethod_5() && !chrome.CD930D04())
            {
                try
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    object res = js.ExecuteScript(@"
                        var playButtons = document.querySelectorAll(""div[role='button'][aria-label*='Phát' i], div[role='button'][aria-label*='Play' i], div[role='button'][aria-label*='Bấm để phát' i], div[role='button'][aria-label*='Click to play' i], div[role='button'][aria-label*='Bật âm thanh' i], div[role='button'][aria-label*='Unmute' i], [aria-label^='Play']"");
                        for (var i = 0; i < playButtons.length; i++) {
                            var pb = playButtons[i];
                            if (pb && pb.offsetParent !== null) {
                                pb.click();
                                break;
                            }
                        }

                        var videos = document.querySelectorAll('video');
                        if (!videos || videos.length === 0) return { ready: false, playing: false };

                        var mainVideo = null;
                        for (var j = 0; j < videos.length; j++) {
                            var rect = videos[j].getBoundingClientRect();
                            if (rect.width > 120 && rect.height > 80) {
                                mainVideo = videos[j];
                                break;
                            }
                        }
                        if (!mainVideo) mainVideo = videos[0];

                        if (mainVideo.paused) {
                            try { mainVideo.play(); } catch(e) {}
                        }

                        return { ready: true, playing: (!mainVideo.paused && mainVideo.readyState >= 2) };
                    ");

                    if (res is Dictionary<string, object> dict)
                    {
                        bool ready = dict.ContainsKey("ready") && Convert.ToBoolean(dict["ready"]);
                        bool playing = dict.ContainsKey("playing") && Convert.ToBoolean(dict["playing"]);
                        if (ready && playing)
                        {
                            playerReady = true;
                            break;
                        }
                        else if (ready)
                        {
                            playerReady = true;
                            break;
                        }
                    }
                }
                catch { }

                SleepWithCancelCheck(1000);
                waitSec++;
            }

            if (playerReady)
            {
                logCallback?.Invoke("Player livestream đã sẵn sàng, video đang phát.");
            }
            else
            {
                logCallback?.Invoke("Cảnh báo: Không phát hiện video phát, vẫn tiếp tục theo dõi...");
            }

            int targetSec = Math.Max(5, watchDurationSec);
            int elapsedSec = 0;

            // Chuẩn bị danh sách cảm xúc
            List<string> cleanReactions = reactions?.Where(r => !string.IsNullOrWhiteSpace(r)).ToList() ?? new List<string>();
            int nextReactionSec = (cleanReactions.Count > 0) ? Rnd.Next(3, 8) : int.MaxValue;

            // Chuẩn bị danh sách bình luận
            List<string> cleanComments = comments?.Where(c => !string.IsNullOrWhiteSpace(c)).ToList() ?? new List<string>();
            int commentIndex = 0;
            int nextCommentSec = (cleanComments.Count > 0) ? Math.Min(5, Math.Max(2, targetSec / 4)) : int.MaxValue;

            bool streamEnded = false;

            while (elapsedSec < targetSec && !Base.smethod_5() && !chrome.CD930D04() && !streamEnded)
            {
                SleepWithCancelCheck(1000);
                elapsedSec++;

                int percent = (int)Math.Min(100, Math.Round((double)elapsedSec / targetSec * 100));

                // Định kỳ mỗi 6 giây kiểm tra trạng thái video còn live không
                if (elapsedSec % 6 == 0)
                {
                    var status = CheckLivestreamStatus(driver);
                    if (status.LiveEnded)
                    {
                        logCallback?.Invoke($"Livestream đã kết thúc sớm tại giây {elapsedSec}/{targetSec}.");
                        streamEnded = true;
                        break;
                    }
                    if (!status.IsPlaying)
                    {
                        EnsureVideoPlaying(driver);
                    }
                }

                // Thả cảm xúc nổi theo chu kỳ ngẫu nhiên (5-15s)
                if (cleanReactions.Count > 0 && elapsedSec >= nextReactionSec)
                {
                    string chosenReaction = cleanReactions[Rnd.Next(0, cleanReactions.Count)];
                    bool ok = TriggerFloatingReaction(driver, chosenReaction);
                    if (ok)
                    {
                        logCallback?.Invoke($"Đã thả cảm xúc [{chosenReaction}] bay lên livestream ({elapsedSec}/{targetSec}s)...");
                    }
                    nextReactionSec = elapsedSec + Rnd.Next(5, 16);
                }

                // Gửi bình luận nhanh qua Chatbox Comet 2026
                if (cleanComments.Count > 0 && commentIndex < cleanComments.Count && elapsedSec >= nextCommentSec)
                {
                    string rawCmt = cleanComments[commentIndex];
                    string cmt = Commom.smethod_31(rawCmt).Trim();
                    if (!string.IsNullOrEmpty(cmt))
                    {
                        logCallback?.Invoke($"Đang gửi bình luận: \"{cmt}\"...");
                        bool cmtOk = SendLivestreamComment(driver, cmt);
                        if (cmtOk)
                        {
                            logCallback?.Invoke($"Đã gửi bình luận thành công: \"{cmt}\" ({elapsedSec}/{targetSec}s)");
                        }
                        else
                        {
                            logCallback?.Invoke($"Thử lại gửi bình luận qua clipboard: \"{cmt}\"");
                            SendLivestreamCommentClipboardFallback(driver, cmt);
                        }
                    }
                    commentIndex++;
                    if (commentIndex < cleanComments.Count)
                    {
                        nextCommentSec = elapsedSec + Rnd.Next(12, 25);
                    }
                    else if (loopComments && cleanComments.Count > 0)
                    {
                        commentIndex = 0;
                        nextCommentSec = elapsedSec + Rnd.Next(15, 30);
                    }
                    else
                    {
                        nextCommentSec = int.MaxValue;
                    }
                }

                logCallback?.Invoke($"Đang xem livestream ({elapsedSec}/{targetSec}s - {percent}%)...");
            }

            logCallback?.Invoke($"Hoàn thành xem livestream ({elapsedSec}s).");
            return true;
        }
        catch (Exception ex)
        {
            logCallback?.Invoke("Lỗi tương tác Livestream: " + ex.Message);
            return false;
        }
    }

    private static bool SendLivestreamComment(IWebDriver driver, string commentText)
    {
        if (string.IsNullOrWhiteSpace(commentText)) return false;
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                var text = arguments[0];
                var selectors = [
                    ""div[role='textbox'][contenteditable='true']"",
                    ""textarea[aria-label*='bình luận' i]"",
                    ""textarea[aria-label*='comment' i]"",
                    ""div[aria-label*='Viết bình luận' i]"",
                    ""div[aria-label*='Write a comment' i]"",
                    ""div[aria-label*='Chat' i][role='textbox']"",
                    ""div[aria-label*='Bình luận trực tiếp' i]"",
                    ""div[aria-label*='Live chat' i]"",
                    ""form textarea"",
                    ""form div[role='textbox'][contenteditable='true']""
                ];

                var chatInput = null;
                for (var i = 0; i < selectors.length; i++) {
                    var els = document.querySelectorAll(selectors[i]);
                    for (var j = els.length - 1; j >= 0; j--) {
                        var el = els[j];
                        var r = el.getBoundingClientRect();
                        if (r.width > 20 && r.height > 10) {
                            chatInput = el;
                            break;
                        }
                    }
                    if (chatInput) break;
                }

                if (!chatInput) {
                    var chatToggles = document.querySelectorAll(""div[role='button'][aria-label*='bình luận' i], div[role='button'][aria-label*='comment' i], div[role='button'][aria-label*='chat' i]"");
                    for (var t = 0; t < chatToggles.length; t++) {
                        if (chatToggles[t].offsetParent !== null) {
                            chatToggles[t].click();
                            break;
                        }
                    }
                    return false;
                }

                chatInput.scrollIntoView({ block: 'center', inline: 'nearest' });
                chatInput.focus();

                var isTextarea = (chatInput.tagName.toLowerCase() === 'textarea' || chatInput.tagName.toLowerCase() === 'input');
                if (isTextarea) {
                    chatInput.value = text;
                    chatInput.dispatchEvent(new Event('input', { bubbles: true }));
                    chatInput.dispatchEvent(new Event('change', { bubbles: true }));
                } else {
                    var sel = window.getSelection();
                    var range = document.createRange();
                    range.selectNodeContents(chatInput);
                    sel.removeAllRanges();
                    sel.addRange(range);
                    document.execCommand('delete', false, null);
                    var ok = document.execCommand('insertText', false, text);
                    if (!ok) {
                        chatInput.innerText = text;
                    }
                    chatInput.dispatchEvent(new Event('input', { bubbles: true }));
                }

                var kd = new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true });
                var kp = new KeyboardEvent('keypress', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true });
                var ku = new KeyboardEvent('keyup', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true });
                chatInput.dispatchEvent(kd);
                chatInput.dispatchEvent(kp);
                chatInput.dispatchEvent(ku);

                setTimeout(function() {
                    var sendBtns = document.querySelectorAll(""div[aria-label*='Gửi' i][role='button'], div[aria-label*='Send' i][role='button'], button[type='submit'], div[role='button'][aria-label*='Bình luận' i]"");
                    for (var s = 0; s < sendBtns.length; s++) {
                        var sb = sendBtns[s];
                        var sr = sb.getBoundingClientRect();
                        if (sr.width > 0 && sr.height > 0 && sb.getAttribute('aria-disabled') !== 'true') {
                            sb.click();
                            break;
                        }
                    }
                }, 250);

                return true;
            ", commentText);

            if (res is bool b && b) return true;
            return SendLivestreamCommentClipboardFallback(driver, commentText);
        }
        catch
        {
            return SendLivestreamCommentClipboardFallback(driver, commentText);
        }
    }

    private static bool SendLivestreamCommentClipboardFallback(IWebDriver driver, string commentText)
    {
        try
        {
            string[] selectors = new string[]
            {
                "div[role='textbox'][contenteditable='true']",
                "textarea[aria-label*='bình luận' i]",
                "textarea[aria-label*='comment' i]",
                "div[aria-label*='Viết bình luận' i]",
                "div[aria-label*='Write a comment' i]"
            };

            IWebElement box = null;
            foreach (var sel in selectors)
            {
                try
                {
                    var els = driver.FindElements(By.CssSelector(sel));
                    for (int i = els.Count - 1; i >= 0; i--)
                    {
                        if (els[i].Displayed && els[i].Enabled)
                        {
                            box = els[i];
                            break;
                        }
                    }
                    if (box != null) break;
                }
                catch { }
            }

            if (box == null) return false;

            box.Click();
            Thread.Sleep(200);

            Thread staThread = new Thread(() =>
            {
                try
                {
                    System.Windows.Forms.Clipboard.SetText(commentText);
                }
                catch { }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join(1000);

            box.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            box.SendKeys(OpenQA.Selenium.Keys.Control + "v");
            Thread.Sleep(300);
            box.SendKeys(OpenQA.Selenium.Keys.Enter);

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool TriggerFloatingReaction(IWebDriver driver, string reaction)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                var reaction = (arguments[0] || 'Love').toLowerCase();
                
                var kwMap = {
                    'like': ['thích', 'like'],
                    'love': ['yêu thích', 'love', 'tim', 'heart'],
                    'care': ['thương thương', 'care'],
                    'haha': ['haha'],
                    'wow': ['wow', 'ngạc nhiên'],
                    'sad': ['buồn', 'sad'],
                    'angry': ['phẫn nộ', 'angry', 'giận dữ']
                };

                var targetKws = kwMap[reaction] || [reaction, 'love', 'tim', 'thích', 'like'];

                // 1. Tìm trực tiếp trên thanh reaction nổi (floating reactions bar)
                var floatingButtons = document.querySelectorAll(""div[role='button'][aria-label], div[data-visualcompletion='ignore-dynamic-attribute'][role='button']"");
                for (var i = 0; i < floatingButtons.length; i++) {
                    var btn = floatingButtons[i];
                    var label = (btn.getAttribute('aria-label') || '').toLowerCase();
                    for (var k = 0; k < targetKws.length; k++) {
                        if (label.indexOf(targetKws[k]) >= 0) {
                            btn.click();
                            return true;
                        }
                    }
                }

                // 2. Mở dock cảm xúc nếu đang đóng (hover hoặc click nút React/Bày tỏ cảm xúc)
                var triggerSelectors = [
                    ""div[role='button'][aria-label*='bày tỏ cảm xúc' i]"",
                    ""div[role='button'][aria-label*='thả cảm xúc' i]"",
                    ""div[role='button'][aria-label*='react' i]"",
                    ""div[role='button'][aria-label*='reactions' i]"",
                    ""div[role='button'][aria-label*='cảm xúc' i]"",
                    ""div[role='complementary'] div[role='button'][aria-label*='like' i]""
                ];

                for (var t = 0; t < triggerSelectors.length; t++) {
                    var tr = document.querySelector(triggerSelectors[t]);
                    if (tr && tr.offsetParent !== null) {
                        var r = tr.getBoundingClientRect();
                        var cx = r.left + r.width / 2;
                        var cy = r.top + r.height / 2;
                        var opts = { bubbles: true, cancelable: true, clientX: cx, clientY: cy };
                        tr.dispatchEvent(new MouseEvent('mouseover', opts));
                        tr.dispatchEvent(new PointerEvent('pointerover', opts));
                        tr.click();

                        var emojis = document.querySelectorAll(""div[role='dialog'] div[role='button'], div[role='tooltip'] div[role='button'], div[role='toolbar'] div[role='button']"");
                        for (var e = 0; e < emojis.length; e++) {
                            var eLabel = (emojis[e].getAttribute('aria-label') || '').toLowerCase();
                            for (var k2 = 0; k2 < targetKws.length; k2++) {
                                if (eLabel.indexOf(targetKws[k2]) >= 0) {
                                    emojis[e].click();
                                    return true;
                                }
                            }
                        }
                        return true;
                    }
                }

                // 3. Fallback nút like của video player
                var mainLike = document.querySelector(""div[role='main'] div[role='button'][aria-label*='Thích' i], div[role='main'] div[role='button'][aria-label*='Like' i]"");
                if (mainLike) {
                    mainLike.click();
                    return true;
                }

                return false;
            ", reaction);

            return res is bool b && b;
        }
        catch
        {
            return false;
        }
    }

    private static (bool IsPlaying, bool LiveEnded) CheckLivestreamStatus(IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                var bodyText = (document.body ? document.body.innerText : '');
                var ended = bodyText.includes('Video trực tiếp đã kết thúc') ||
                            bodyText.includes('This live video has ended') ||
                            bodyText.includes('Phát trực tiếp đã kết thúc') ||
                            bodyText.includes('Live stream ended') ||
                            bodyText.includes('buổi phát trực tiếp đã kết thúc');

                var videos = document.querySelectorAll('video');
                var isPlaying = false;
                for (var i = 0; i < videos.length; i++) {
                    var v = videos[i];
                    if (!v.paused && v.readyState >= 2) {
                        isPlaying = true;
                        break;
                    }
                }

                return { isPlaying: isPlaying, ended: ended };
            ");

            if (res is Dictionary<string, object> dict)
            {
                bool playing = dict.ContainsKey("isPlaying") && Convert.ToBoolean(dict["isPlaying"]);
                bool ended = dict.ContainsKey("ended") && Convert.ToBoolean(dict["ended"]);
                return (playing, ended);
            }
        }
        catch { }
        return (true, false);
    }

    private static List<string> ParseReactionTypes(string typeReaction)
    {
        List<string> result = new List<string>();
        if (string.IsNullOrWhiteSpace(typeReaction)) return result;

        var parts = typeReaction.Split(new[] { '|', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var part in parts)
        {
            string p = part.Trim().ToLowerInvariant();
            switch (p)
            {
                case "0":
                case "like":
                case "thích":
                    result.Add("Like");
                    break;
                case "1":
                case "love":
                case "tim":
                case "yêu thích":
                    result.Add("Love");
                    break;
                case "2":
                case "care":
                case "thương thương":
                    result.Add("Care");
                    break;
                case "3":
                case "haha":
                    result.Add("Haha");
                    break;
                case "4":
                case "wow":
                    result.Add("Wow");
                    break;
                case "5":
                case "sad":
                case "buồn":
                    result.Add("Sad");
                    break;
                case "6":
                case "angry":
                case "phẫn nộ":
                case "giận":
                    result.Add("Angry");
                    break;
                default:
                    if (!string.IsNullOrEmpty(part.Trim())) result.Add(part.Trim());
                    break;
            }
        }
        return result;
    }

    #endregion

    #region CÁC HÀM TIỆN ÍCH HỖ TRỢ COMET WWW 2026

    private static List<IWebElement> GetVisibleFeedPosts(IWebDriver driver)
    {
        try
        {
            var elements = driver.FindElements(By.CssSelector("div[role='feed'] > div, div[role='article'], div[data-pagelet*='FeedUnit']"));
            List<IWebElement> visiblePosts = new List<IWebElement>();
            foreach (var el in elements)
            {
                try
                {
                    if (el.Displayed && el.Size.Height > 100)
                    {
                        visiblePosts.Add(el);
                    }
                }
                catch { }
            }
            return visiblePosts;
        }
        catch
        {
            return new List<IWebElement>();
        }
    }

    private static string PickReaction(GClass4 config)
    {
        string typeReaction = config.BDB80B23("typeReaction");
        if (!string.IsNullOrEmpty(typeReaction))
        {
            var parts = typeReaction.Split('|').Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
            if (parts.Count > 0)
            {
                string sel = parts[Rnd.Next(0, parts.Count)].Trim();
                switch (sel)
                {
                    case "0": return "Like";
                    case "1": return "Love";
                    case "2": return "Care";
                    case "3": return "Haha";
                    case "4": return "Wow";
                    case "5": return "Sad";
                    case "6": return "Angry";
                    default: return sel;
                }
            }
        }

        List<string> active = new List<string>();
        if (config.method_3("ckbLike")) active.Add("Like");
        if (config.method_3("ckbLove")) active.Add("Love");
        if (config.method_3("ckbCare")) active.Add("Care");
        if (config.method_3("ckbHaha")) active.Add("Haha");
        if (config.method_3("ckbWow")) active.Add("Wow");
        if (config.method_3("ckbSad")) active.Add("Sad");
        if (config.method_3("ckbAngry")) active.Add("Angry");

        if (active.Count == 0) return "Like";
        return active[Rnd.Next(0, active.Count)];
    }

    private static bool ApplyReactionToPost(IWebDriver driver, IWebElement post, string reactionType)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object res = js.ExecuteScript(@"
                var post = arguments[0];
                var rType = arguments[1].toLowerCase();
                if (!post) return false;

                // Tìm nút Like/Reaction trong post
                var btns = post.querySelectorAll('div[role=""button""][aria-label]');
                var likeBtn = null;
                for (var i = 0; i < btns.length; i++) {
                    var l = (btns[i].getAttribute('aria-label') || '').toLowerCase();
                    if (l === 'thích' || l === 'like' || l === 'bày tỏ cảm xúc' || l.indexOf('thích') === 0 || l.indexOf('like') === 0) {
                        likeBtn = btns[i];
                        break;
                    }
                }
                if (!likeBtn) return false;

                // Nếu đã react rồi thì bỏ qua để không bị hủy like
                var pressed = likeBtn.getAttribute('aria-pressed');
                if (pressed === 'true') return true;

                if (rType === 'like' || rType === 'thích') {
                    likeBtn.click();
                    return true;
                }

                // Kích hoạt thanh reaction dock qua pointer events
                var rect = likeBtn.getBoundingClientRect();
                var cx = rect.left + rect.width / 2;
                var cy = rect.top + rect.height / 2;
                var opts = { bubbles: true, cancelable: true, composed: true, view: window, clientX: cx, clientY: cy, screenX: cx, screenY: cy, buttons: 1 };
                likeBtn.dispatchEvent(new PointerEvent('pointerdown', opts));
                likeBtn.dispatchEvent(new MouseEvent('mousedown', opts));
                likeBtn.dispatchEvent(new PointerEvent('pointerover', opts));
                likeBtn.dispatchEvent(new MouseEvent('mouseover', opts));

                // Click reaction tương ứng
                setTimeout(function() {
                    var dock = document.querySelector('div[role=""toolbar""]');
                    if (dock) {
                        var emojis = dock.querySelectorAll('div[role=""button""]');
                        for (var j = 0; j < emojis.length; j++) {
                            var elLabel = (emojis[j].getAttribute('aria-label') || '').toLowerCase();
                            if (elLabel.indexOf(rType) >= 0) {
                                emojis[j].click();
                                return;
                            }
                        }
                    }
                    likeBtn.click();
                }, 600);

                return true;
            ", post, reactionType);

            return res is bool b && b;
        }
        catch
        {
            return false;
        }
    }

    private static bool SubmitCommentToPost(IWebDriver driver, IWebElement post, string commentText, string imagePath)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // 1. Click nút mở comment box
            js.ExecuteScript(@"
                var post = arguments[0];
                if (!post) return;
                var cmtBtn = post.querySelector('div[role=""button""][aria-label*=""Bình luận"" i], div[role=""button""][aria-label*=""Comment"" i]');
                if (cmtBtn) cmtBtn.click();
            ", post);

            SleepWithCancelCheck(800);

            // 2. Nhập nội dung bình luận vào Lexical editor
            js.ExecuteScript(@"
                var post = arguments[0];
                var text = arguments[1];
                var tb = post.querySelector('div[role=""textbox""][contenteditable=""true""], div[data-lexical-editor=""true""]');
                if (!tb) tb = document.querySelector('div[role=""textbox""][contenteditable=""true""]');
                if (tb) {
                    tb.focus();
                    document.execCommand('insertText', false, text);
                    tb.dispatchEvent(new Event('input', { bubbles: true }));
                    setTimeout(function() {
                        tb.dispatchEvent(new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true }));
                    }, 400);
                }
            ", post, commentText);

            // 3. Nếu có đính kèm ảnh
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    IWebElement fileInput = post.FindElement(By.CssSelector("input[type='file'][accept*='image']"));
                    if (fileInput != null)
                    {
                        fileInput.SendKeys(imagePath);
                        SleepWithCancelCheck(1500);
                        // Gửi lại phím Enter sau khi ảnh tải xong
                        IWebElement tb = post.FindElement(By.CssSelector("div[role='textbox'][contenteditable='true']"));
                        if (tb != null) tb.SendKeys(OpenQA.Selenium.Keys.Enter);
                    }
                }
                catch { }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void SharePostNow(IWebDriver driver, IWebElement post)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var post = arguments[0];
                if (!post) return;
                var shareBtn = post.querySelector('div[role=""button""][aria-label*=""Chia sẻ"" i], div[role=""button""][aria-label*=""Share"" i]');
                if (shareBtn) {
                    shareBtn.click();
                    setTimeout(function() {
                        var shareNow = document.querySelector('div[role=""menuitem""][aria-label*=""Chia sẻ ngay"" i], div[role=""menuitem""][aria-label*=""Share now"" i]');
                        if (shareNow) shareNow.click();
                    }, 700);
                }
            ", post);
        }
        catch { }
    }

    private static void FollowOrLikeAuthorInPost(IWebDriver driver, IWebElement post)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var post = arguments[0];
                if (!post) return;
                var btns = post.querySelectorAll('div[role=""button""]');
                for (var i = 0; i < btns.length; i++) {
                    var t = (btns[i].innerText || btns[i].textContent || '').trim().toLowerCase();
                    if (t === 'theo dõi' || t === 'follow' || t === '+ theo dõi') {
                        btns[i].click();
                        break;
                    }
                }
            ", post);
        }
        catch { }
    }

    private static void ExpandSeeMoreInPost(IWebDriver driver, IWebElement post)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                var post = arguments[0];
                if (!post) return;
                var btns = post.querySelectorAll('div[role=""button""]');
                for (var i = 0; i < btns.length; i++) {
                    var t = (btns[i].innerText || btns[i].textContent || '').trim().toLowerCase();
                    if (t === 'xem thêm' || t === 'see more') {
                        btns[i].click();
                        break;
                    }
                }
            ", post);
        }
        catch { }
    }

    private static string GetRandomImageFromPath(string pathImage, bool enable)
    {
        if (!enable || string.IsNullOrEmpty(pathImage) || !Directory.Exists(pathImage)) return null;
        try
        {
            var files = Directory.GetFiles(pathImage, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (files.Count > 0) return files[Rnd.Next(0, files.Count)];
        }
        catch { }
        return null;
    }

    private static void SleepWithCancelCheck(int totalMs)
    {
        int remaining = totalMs;
        while (remaining > 0)
        {
            if (Base.smethod_5()) return;
            int slice = Math.Min(50, remaining);
            Thread.Sleep(slice);
            remaining -= slice;
        }
    }

    #endregion
}
