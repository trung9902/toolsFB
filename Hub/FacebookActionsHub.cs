using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public static class FacebookActionsHub
{
    private static readonly object _clipboardLock = new object();
    private static readonly Random _rand = new Random();

    /// <summary>
    /// Static entry point for all native Selenium Facebook actions.
    /// Handles reaction, comment, share, follow, page like, messaging, and post deletion.
    /// Never throws an unhandled exception.
    /// </summary>
    public static string Execute(Chrome chrome, string actionName, string paramJson)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null)
        {
            return ResultJson(false, "Chrome instance or ChromeDriver is not initialized.");
        }

        try
        {
            JObject param = new JObject();
            if (!string.IsNullOrWhiteSpace(paramJson))
            {
                try
                {
                    var token = JToken.Parse(paramJson);
                    if (token is JArray arr)
                    {
                        foreach (var item in arr)
                        {
                            string name = item["name"]?.ToString() ?? "";
                            string val = item["value"]?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(name))
                            {
                                param[name] = val;
                            }
                        }
                    }
                    else if (token is JObject obj)
                    {
                        param = obj;
                    }
                }
                catch
                {
                    // paramJson may be plain text or non-object; continue with empty object
                }
            }

            string act = (actionName ?? "").Trim().ToLowerInvariant();
            switch (act)
            {
                // Reaction actions
                case "reactionwww":
                case "reaction":
                    return ReactionWWW(chrome, param);
                case "reactionmfb":
                    return ReactionMfb(chrome, param);
                case "reactionmbasic":
                    return ReactionMbasic(chrome, param);

                // Comment actions
                case "commentwww":
                case "comment":
                    return CommentWWW(chrome, param);
                case "commentmfb":
                    return CommentMfb(chrome, param);
                case "commentmbasic":
                    return CommentMbasic(chrome, param);

                // Share actions
                case "sharewallwww":
                case "sharewall":
                case "share":
                    return ShareWallWWW(chrome, param);
                case "sharewallmfb":
                    return ShareWallMfb(chrome, param);
                case "sharewallmbasic":
                    return ShareWallMbasic(chrome, param);
                case "sharemesswww":
                case "sharemess":
                    return ShareMessWWW(chrome, param);

                // Profile / Page actions
                case "followwww":
                case "follow":
                    return FollowWWW(chrome, param);
                case "likepagewww":
                case "likepage":
                    return LikePageWWW(chrome, param);

                // Direct message UID
                case "nhantinuidwww":
                case "nhantinuid":
                case "nhantin":
                    return NhanTinUidWWW(chrome, param);

                // Post deletion
                case "deletepost":
                case "deletepostwww":
                    return DeletePost(chrome, param);

                // Fanpage Access & Creation actions
                case "createpage":
                case "createpagepro5":
                case "taopage":
                    {
                        string pageName = param["pageName"]?.ToString() ?? param["name"]?.ToString() ?? "";
                        string cat = param["category"]?.ToString() ?? param["catagoryId"]?.ToString() ?? "";
                        string bio = param["bio"]?.ToString() ?? "";
                        string website = param["website"]?.ToString() ?? "";
                        string phone = param["phone"]?.ToString() ?? "";
                        string email = param["email"]?.ToString() ?? "";
                        string address = param["address"]?.ToString() ?? "";
                        string city = param["city"]?.ToString() ?? "";
                        string zip = param["zip"]?.ToString() ?? "";
                        string avatar = param["avatar"]?.ToString() ?? "";
                        string cover = param["cover"]?.ToString() ?? "";
                        string targetUid = param["targetUid"]?.ToString() ?? param["toUid"]?.ToString() ?? "";
                        string pageId = PageCreationHub.CreatePage(chrome, pageName, cat, bio, website, phone, email, address, city, zip, avatar, cover, targetUid);
                        return JsonConvert.SerializeObject(new { success = !string.IsNullOrEmpty(pageId) && pageId != "fb_limit_create_page", pageId = pageId, status = pageId });
                    }
                case "shareadminpagepro5":
                case "shareadmin":
                    return PageAccessHelper.ExecuteShareAdmin(chrome, paramJson);
                case "removeadminpagepro5":
                case "removeadmin":
                    return PageAccessHelper.ExecuteRemoveAdmin(chrome, paramJson);

                // Livestream Comet 2026 actions
                case "interactlivestream":
                case "interactlivestreamv2":
                case "livestream":
                case "livestreamv2":
                    return ExecuteLivestreamAction(chrome, param);

                // Friend Automation Comet 2026 actions (FacebookFriendAutomationHelper)
                case "cancelpendingsentrequests":
                case "cancelpendingrequests":
                case "cancelsentrequests":
                case "huysentrequest":
                case "huyloimoiketban":
                case "thuhoiloimoiketban":
                    return FacebookFriendAutomationHelper.ExecuteCancelSentRequests(chrome, param, paramJson);

                case "unfriendinactiveaccounts":
                case "unfrienddeadaccounts":
                case "unfriendinactive":
                case "filterandunfriendinactive":
                case "locbanbeao":
                case "huyketbanbanbeao":
                case "locbanbedie":
                    return FacebookFriendAutomationHelper.ExecuteUnfriendInactive(chrome, param, paramJson);

                default:
                    return "";
            }
        }
        catch (Exception ex)
        {
            return ResultJson(false, "Exception in FacebookActionsHub.Execute: " + ex.Message);
        }
    }

    #region Reaction Actions

    /// <summary>
    /// Handles Reactions on Facebook Desktop WWW.
    /// If reaction is Like, clicks directly or via Actions.
    /// If other reaction, hovers 1-1.5s on Like button, waits for dock, and clicks target reaction.
    /// </summary>
    private static string ReactionWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string rawType = GetString(param, "reactionType", GetString(param, "type", GetString(param, "reaction", "Like")));
            string reaction = NormalizeReaction(rawType);
            int indexPost = GetInt(param, "indexPost", 0);
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://www.facebook.com/" + postId);

            IWebElement post = GetPostElementWWW(driver, indexPost);
            IWebElement likeBtn = FindLikeButtonInPost(driver, post);

            if (likeBtn == null)
            {
                // Fallback: try scrolling down slightly to lazy-load feed and search again
                ScrollDown(driver, 500);
                Sleep(1.2);
                post = GetPostElementWWW(driver, indexPost);
                likeBtn = FindLikeButtonInPost(driver, post);
            }

            if (likeBtn == null)
            {
                return ResultJson(false, "Could not find Like/Reaction button in post index " + indexPost);
            }

            if (reaction.Equals("Like", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string isPressed = likeBtn.GetAttribute("aria-pressed");
                    string ariaLabel = (likeBtn.GetAttribute("aria-label") ?? "").ToLowerInvariant();
                    if (isPressed == "true" || ariaLabel.Contains("bỏ thích") || ariaLabel.Contains("unlike") || ariaLabel.Contains("gỡ"))
                    {
                        return ResultJson(true);
                    }
                }
                catch { }

                bool clicked = SafeClick(driver, likeBtn);
                Sleep(1.0);
                if (clicked) return ResultJson(true);
                return ResultJson(false, "Failed to click Like button");
            }

            // Emotion other than Like: hover for 1.2 - 1.5s to display reaction dock
            SafeHover(driver, likeBtn, 1.4);

            // Wait and find target reaction button
            IWebElement reactionEl = null;
            for (int retry = 0; retry < 6; retry++)
            {
                reactionEl = FindReactionElementInDock(driver, reaction);
                if (reactionEl != null) break;
                Sleep(0.3);
            }

            // Fallback JS hover and search if dock did not appear
            if (reactionEl == null)
            {
                try
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript(@"
                        var b = arguments[0];
                        if (b) {
                            var rect = b.getBoundingClientRect();
                            var cx = rect.left + rect.width / 2;
                            var cy = rect.top + rect.height / 2;
                            var opts = { bubbles: true, cancelable: true, composed: true, view: window, clientX: cx, clientY: cy, screenX: cx, screenY: cy, buttons: 1 };
                            b.dispatchEvent(new PointerEvent('pointerdown', opts));
                            b.dispatchEvent(new MouseEvent('mousedown', opts));
                            b.dispatchEvent(new PointerEvent('pointerover', opts));
                            b.dispatchEvent(new MouseEvent('mouseover', opts));
                            b.dispatchEvent(new PointerEvent('pointerenter', opts));
                            b.dispatchEvent(new MouseEvent('mouseenter', opts));
                            b.dispatchEvent(new PointerEvent('pointermove', opts));
                            b.dispatchEvent(new MouseEvent('mousemove', opts));
                        }
                    ", likeBtn);
                    Sleep(1.0);
                    reactionEl = FindReactionElementInDock(driver, reaction);
                }
                catch { }
            }

            if (reactionEl != null)
            {
                SafeClick(driver, reactionEl);
                Sleep(1.0);
                return ResultJson(true);
            }

            // If dock element still not found, fallback to clicking Like button directly
            SafeClick(driver, likeBtn);
            Sleep(1.0);
            return ResultJson(true);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ReactionWWW error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Reactions on Facebook Mobile Web (m.facebook.com).
    /// </summary>
    private static string ReactionMfb(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string rawType = GetString(param, "reactionType", GetString(param, "type", GetString(param, "reaction", "Like")));
            string reaction = NormalizeReaction(rawType);
            string reactionCode = GetReactionCode(reaction);
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://m.facebook.com/" + postId);

            if (reaction.Equals("Like", StringComparison.OrdinalIgnoreCase))
            {
                var likeBtn = FindElementByMultipleSelectors(driver,
                    "a[data-uri*='like.php']",
                    "a[href*='/like.php']",
                    "[role='button'][aria-label*='Like']",
                    "[role='button'][aria-label*='Thích']");
                if (likeBtn == null)
                {
                    likeBtn = FindElementByText(driver, null, new[] { "Thích", "Like" }, "a");
                }
                if (likeBtn != null)
                {
                    SafeClick(driver, likeBtn);
                    Sleep(1.5);
                    return ResultJson(true);
                }
            }

            // Open reaction picker
            var pickerLink = FindElementByMultipleSelectors(driver,
                "a[href*='/reactions/picker/']",
                "a[data-uri*='/reactions/picker/']");
            if (pickerLink != null)
            {
                SafeClick(driver, pickerLink);
                Sleep(1.5);

                var targetReaction = FindElementByMultipleSelectors(driver,
                    $"a[href*='reaction_type={reactionCode}']",
                    $"a[data-uri*='reaction_type={reactionCode}']");
                if (targetReaction == null)
                {
                    targetReaction = FindElementByText(driver, null, new[] { reaction }, "a");
                }
                if (targetReaction != null)
                {
                    SafeClick(driver, targetReaction);
                    Sleep(1.5);
                    return ResultJson(true);
                }
            }

            return ResultJson(false, "Could not trigger Reaction on m.facebook.com");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ReactionMfb error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Reactions - redirects deprecated mbasic requests to modern Comet WWW.
    /// </summary>
    private static string ReactionMbasic(Chrome chrome, JObject param)
    {
        try
        {
            if (param != null && param["url"] != null)
            {
                param["url"] = Regex.Replace(param["url"].ToString(), @"https?://mbasic\.facebook\.com", "https://www.facebook.com", RegexOptions.IgnoreCase);
            }
            return ReactionWWW(chrome, param);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ReactionMbasic error: " + ex.Message);
        }
    }

    #endregion

    #region Comment Actions

    /// <summary>
    /// Handles Comment on Facebook Desktop WWW.
    /// Finds comment box, writes text using clipboard paste, attaches image if specified, and presses Enter.
    /// </summary>
    private static string CommentWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string content = GetString(param, "content", GetString(param, "comment", GetString(param, "text", "")));
            string image = GetString(param, "image", GetString(param, "imagePath", GetString(param, "filePath", "")));
            int indexPost = GetInt(param, "indexPost", 0);
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://www.facebook.com/" + postId);

            IWebElement post = GetPostElementWWW(driver, indexPost);
            IWebElement box = FindCommentBoxInPost(driver, post);

            if (box == null)
            {
                // Comment box not open: click "Bình luận" button on post to reveal it
                OpenCommentBoxIfClosed(driver, post);
                Sleep(1.2);
                box = FindCommentBoxInPost(driver, post);
            }

            if (box == null)
            {
                ScrollDown(driver, 200);
                Sleep(0.8);
                OpenCommentBoxIfClosed(driver, post);
                Sleep(1.0);
                box = FindCommentBoxInPost(driver, post);
            }

            if (box == null)
            {
                return ResultJson(false, "Could not find comment box in post index " + indexPost);
            }

            // Input text via STA Clipboard paste
            if (!string.IsNullOrEmpty(content))
            {
                PasteViaClipboard(driver, box, content);
                Sleep(0.5);
            }

            // Attach image if specified
            if (!string.IsNullOrWhiteSpace(image) && File.Exists(image))
            {
                AttachImageToComment(driver, post, image);
                // Chờ preview ảnh tải xong nếu có ảnh đính kèm
                Sleep(2.0);
                try
                {
                    for (int w = 0; w < 10; w++)
                    {
                        var preview = FindElementByMultipleSelectors(post ?? (ISearchContext)driver,
                            "div[aria-label*='Xóa ảnh' i]", "div[aria-label*='Remove photo' i]",
                            "img[src^='blob:']", "div[role='progressbar']");
                        if (preview != null) break;
                        Sleep(0.5);
                    }
                }
                catch { }
            }

            // Thêm delay tự nhiên 1.0s trước khi Enter/Click Send
            Sleep(1.0);

            // Submit comment via Enter key
            try
            {
                box.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            catch { }

            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(@"
                    var el = arguments[0];
                    if (el) {
                        var e = new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13, bubbles: true, cancelable: true });
                        el.dispatchEvent(e);
                    }
                ", box);
            }
            catch { }

            // Check if there is a Send button to click
            var sendBtn = FindElementByMultipleSelectors(driver,
                "div[aria-label*='Bình luận' i][role='button']",
                "div[aria-label*='Comment' i][role='button']",
                "div[aria-label*='Gửi' i][role='button']",
                "div[aria-label*='Send' i][role='button']",
                "div[aria-label*='Đăng' i][role='button']",
                "div[aria-label*='Post' i][role='button']",
                "div[aria-label*='Nhấn Enter để gửi' i]",
                "div[aria-label*='Press Enter to post' i]");

            if (sendBtn != null)
            {
                SafeClick(driver, sendBtn);
            }

            Sleep(2.5);

            // Extract newly posted comment ID if present
            string commentId = ExtractCommentId(driver);
            string linkCmt = !string.IsNullOrEmpty(commentId) ? ("https://facebook.com/" + commentId) : (!string.IsNullOrEmpty(url) ? url : ("https://facebook.com/" + postId));
            KichBanThongKeDB.LogComment(chrome?.B4208531, linkCmt, content, "Thành công");
            return ResultJson(true, commentId: commentId);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "CommentWWW error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Comment on Facebook Mobile Web (m.facebook.com).
    /// </summary>
    private static string CommentMfb(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string content = GetString(param, "content", "");
            string image = GetString(param, "image", GetString(param, "imagePath", ""));
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://m.facebook.com/" + postId);

            var commentInput = FindElementByMultipleSelectors(driver,
                "textarea[name='comment_text']",
                "input[name='comment_text']",
                "div[role='textbox'][contenteditable='true']");

            if (commentInput == null)
            {
                return ResultJson(false, "Could not find comment input on m.facebook.com");
            }

            if (!string.IsNullOrEmpty(content))
            {
                PasteViaClipboard(driver, commentInput, content);
                Sleep(0.5);
            }

            if (!string.IsNullOrWhiteSpace(image) && File.Exists(image))
            {
                var fileInput = FindElementByMultipleSelectors(driver, "input[type='file']");
                if (fileInput != null)
                {
                    fileInput.SendKeys(Path.GetFullPath(image));
                    Sleep(2.5);
                }
            }

            var submitBtn = FindElementByMultipleSelectors(driver,
                "button[type='submit']",
                "input[type='submit']",
                "form[action*='comment'] button");

            if (submitBtn != null)
            {
                SafeClick(driver, submitBtn);
            }
            else
            {
                commentInput.SendKeys(OpenQA.Selenium.Keys.Enter);
            }

            Sleep(2.5);
            string commentId = ExtractCommentId(driver);
            string linkCmt = !string.IsNullOrEmpty(commentId) ? ("https://m.facebook.com/" + commentId) : (!string.IsNullOrEmpty(url) ? url : ("https://m.facebook.com/" + postId));
            KichBanThongKeDB.LogComment(chrome?.B4208531, linkCmt, content, "Thành công");
            return ResultJson(true, commentId: commentId);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "CommentMfb error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Comment - redirects deprecated mbasic requests to modern Comet WWW.
    /// </summary>
    private static string CommentMbasic(Chrome chrome, JObject param)
    {
        try
        {
            if (param != null && param["url"] != null)
            {
                param["url"] = Regex.Replace(param["url"].ToString(), @"https?://mbasic\.facebook\.com", "https://www.facebook.com", RegexOptions.IgnoreCase);
            }
            return CommentWWW(chrome, param);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "CommentMbasic error: " + ex.Message);
        }
    }

    #endregion

    #region Share Actions

    /// <summary>
    /// Handles Post Sharing on Facebook Desktop WWW.
    /// Clicks Share button, selects "Chia sẻ ngay" (Share now) or "Chia sẻ lên Bảng feed" (Share to Feed) with optional caption.
    /// </summary>
    private static string ShareWallWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string content = GetString(param, "content", "");
            int indexPost = GetInt(param, "indexPost", 0);
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://www.facebook.com/" + postId);

            IWebElement post = GetPostElementWWW(driver, indexPost);
            ISearchContext searchContext = post ?? (ISearchContext)driver;

            var shareBtn = FindElementByMultipleSelectors(searchContext,
                "div[role='toolbar'] div[aria-label*='Chia sẻ'][role='button']",
                "div[role='toolbar'] div[aria-label*='Share'][role='button']",
                "div[aria-label='Chia sẻ'][role='button']",
                "div[aria-label='Share'][role='button']",
                "div[aria-label*='Chia sẻ'][role='button']",
                "div[aria-label*='Share'][role='button']",
                "div[aria-label*='Gửi nội dung này'][role='button']",
                "div[aria-label*='Send this to friends'][role='button']",
                "div[aria-label='Chia sẻ']",
                "div[aria-label='Share']");

            if (shareBtn == null)
            {
                shareBtn = FindElementByText(driver, null, new[] { "Chia sẻ", "Share" }, "div");
            }

            if (shareBtn == null)
            {
                return ResultJson(false, "Could not find Share button in post index " + indexPost);
            }

            SafeClick(driver, shareBtn);
            Sleep(1.5);

            // If custom content is provided, prefer "Chia sẻ lên Bảng feed" / "Share to Feed" to open editor dialog
            if (!string.IsNullOrWhiteSpace(content))
            {
                var feedOption = FindElementByText(driver, "div[role='menu'], div[data-pagelet*='Share']",
                    new[] { "Chia sẻ lên Bảng feed", "Chia sẻ lên bảng tin", "Share to Feed", "Share to News Feed" }, "div");

                if (feedOption != null)
                {
                    SafeClick(driver, feedOption);
                    Sleep(1.5);

                    var dialogBox = FindElementByMultipleSelectors(driver,
                        "div[role='dialog'] div[role='textbox'][contenteditable='true']",
                        "div[role='dialog'] [role='textbox']");

                    if (dialogBox != null)
                    {
                        PasteViaClipboard(driver, dialogBox, content);
                        Sleep(0.5);
                    }

                    var postBtn = FindElementByMultipleSelectors(driver,
                        "div[role='dialog'] div[aria-label='Đăng'][role='button']",
                        "div[role='dialog'] div[aria-label='Post'][role='button']",
                        "div[role='dialog'] [aria-label='Đăng']",
                        "div[role='dialog'] [aria-label='Post']");

                    if (postBtn == null)
                    {
                        postBtn = FindElementByText(driver, "div[role='dialog']", new[] { "Đăng", "Post" }, "div");
                    }

                    if (postBtn != null)
                    {
                        SafeClick(driver, postBtn);
                        Sleep(2.5);
                        return ResultJson(true);
                    }
                }
            }

            // Default: try "Chia sẻ ngay" (Share now)
            var shareNowOption = FindElementByText(driver, "div[role='menu'], div[data-pagelet*='Share']",
                new[] { "Chia sẻ ngay", "Share now", "Chia sẻ ngay (Công khai)", "Share now (Public)", "Chia sẻ ngay (Bạn bè)", "Share now (Friends)" }, "div");

            if (shareNowOption != null)
            {
                SafeClick(driver, shareNowOption);
                Sleep(2.5);
                return ResultJson(true);
            }

            // Fallback: try "Chia sẻ lên Bảng feed" and confirm
            var fallbackFeed = FindElementByText(driver, "div[role='menu'], div[data-pagelet*='Share']",
                new[] { "Chia sẻ lên Bảng feed", "Chia sẻ lên bảng tin", "Share to Feed", "Bảng feed" }, "div");

            if (fallbackFeed != null)
            {
                SafeClick(driver, fallbackFeed);
                Sleep(1.5);

                var postBtn = FindElementByMultipleSelectors(driver,
                    "div[role='dialog'] div[aria-label='Đăng'][role='button']",
                    "div[role='dialog'] div[aria-label='Post'][role='button']",
                    "div[role='dialog'] [aria-label='Đăng']",
                    "div[role='dialog'] [aria-label='Post']");

                if (postBtn == null)
                {
                    postBtn = FindElementByText(driver, "div[role='dialog']", new[] { "Đăng", "Post" }, "div");
                }

                if (postBtn != null)
                {
                    SafeClick(driver, postBtn);
                    Sleep(2.5);
                    return ResultJson(true);
                }
            }

            return ResultJson(false, "Could not find valid share option in menu");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ShareWallWWW error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Post Sharing on Facebook Mobile Web (m.facebook.com).
    /// </summary>
    private static string ShareWallMfb(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string content = GetString(param, "content", "");
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://m.facebook.com/" + postId);

            var shareLink = FindElementByMultipleSelectors(driver,
                "a[href*='/sharer.php']",
                "a[href*='share.php']",
                "a[data-uri*='share']");

            if (shareLink == null)
            {
                shareLink = FindElementByText(driver, null, new[] { "Chia sẻ", "Share" }, "a");
            }

            if (shareLink == null)
            {
                return ResultJson(false, "Could not find Share link on m.facebook.com");
            }

            SafeClick(driver, shareLink);
            Sleep(1.5);

            if (!string.IsNullOrWhiteSpace(content))
            {
                var msgBox = FindElementByMultipleSelectors(driver, "textarea[name='message']", "textarea[name='comment_text']");
                if (msgBox != null)
                {
                    PasteViaClipboard(driver, msgBox, content);
                    Sleep(0.5);
                }
            }

            var submitBtn = FindElementByMultipleSelectors(driver, "button[type='submit']", "input[type='submit']");
            if (submitBtn != null)
            {
                SafeClick(driver, submitBtn);
                Sleep(2.0);
            }

            return ResultJson(true);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ShareWallMfb error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Post Sharing - redirects deprecated mbasic requests to modern Comet WWW.
    /// </summary>
    private static string ShareWallMbasic(Chrome chrome, JObject param)
    {
        try
        {
            if (param != null && param["url"] != null)
            {
                param["url"] = Regex.Replace(param["url"].ToString(), @"https?://mbasic\.facebook\.com", "https://www.facebook.com", RegexOptions.IgnoreCase);
            }
            return ShareWallWWW(chrome, param);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ShareWallMbasic error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Post Sharing via Messenger on Facebook Desktop WWW.
    /// </summary>
    private static string ShareMessWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string content = GetString(param, "content", "");
            string receiver = GetString(param, "receiver", GetString(param, "uid", GetString(param, "target", "")));
            int indexPost = GetInt(param, "indexPost", 0);
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://www.facebook.com/" + postId);

            IWebElement post = GetPostElementWWW(driver, indexPost);
            ISearchContext searchContext = post ?? (ISearchContext)driver;

            var shareBtn = FindElementByMultipleSelectors(searchContext,
                "div[role='toolbar'] div[aria-label*='Chia sẻ'][role='button']",
                "div[role='toolbar'] div[aria-label*='Share'][role='button']",
                "div[aria-label='Chia sẻ'][role='button']",
                "div[aria-label='Share'][role='button']",
                "div[aria-label*='Chia sẻ'][role='button']",
                "div[aria-label*='Share'][role='button']",
                "div[aria-label*='Gửi nội dung này'][role='button']",
                "div[aria-label*='Send this to friends'][role='button']",
                "div[aria-label='Chia sẻ']",
                "div[aria-label='Share']");

            if (shareBtn == null)
            {
                shareBtn = FindElementByText(driver, null, new[] { "Chia sẻ", "Share" }, "div");
            }

            if (shareBtn == null)
            {
                return ResultJson(false, "Could not find Share button in post");
            }

            SafeClick(driver, shareBtn);
            Sleep(1.5);

            var messOption = FindElementByText(driver, "div[role='menu'], div[data-pagelet*='Share']",
                new[] { "Gửi bằng Messenger", "Send in Messenger", "Chia sẻ qua Messenger", "Gửi trong tin nhắn", "Messenger" }, "div");

            if (messOption == null)
            {
                return ResultJson(false, "Could not find Messenger share option in menu");
            }

            SafeClick(driver, messOption);
            Sleep(1.5);

            if (!string.IsNullOrWhiteSpace(receiver))
            {
                var inputReceiver = FindElementByMultipleSelectors(driver,
                    "div[role='dialog'] input[type='text']",
                    "div[role='dialog'] input[placeholder*='Search']",
                    "div[role='dialog'] input[placeholder*='Tìm kiếm']");

                if (inputReceiver != null)
                {
                    inputReceiver.SendKeys(receiver);
                    Sleep(1.5);

                    var firstItem = FindElementByMultipleSelectors(driver,
                        "div[role='dialog'] [role='listbox'] [role='option']",
                        "div[role='dialog'] [role='checkbox']");

                    if (firstItem != null)
                    {
                        SafeClick(driver, firstItem);
                        Sleep(0.5);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(content))
            {
                var msgBox = FindElementByMultipleSelectors(driver,
                    "div[role='dialog'] [role='textbox'][contenteditable='true']",
                    "div[role='dialog'] [role='textbox']");
                if (msgBox != null)
                {
                    PasteViaClipboard(driver, msgBox, content);
                    Sleep(0.5);
                }
            }

            var sendBtn = FindElementByMultipleSelectors(driver,
                "div[role='dialog'] div[aria-label='Gửi'][role='button']",
                "div[role='dialog'] div[aria-label='Send'][role='button']",
                "div[role='dialog'] [aria-label='Gửi']",
                "div[role='dialog'] [aria-label='Send']");

            if (sendBtn == null)
            {
                sendBtn = FindElementByText(driver, "div[role='dialog']", new[] { "Gửi", "Send" }, "div");
            }

            if (sendBtn != null)
            {
                SafeClick(driver, sendBtn);
                Sleep(2.0);
                return ResultJson(true);
            }

            return ResultJson(false, "Could not find Send button in Messenger share dialog");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "ShareMessWWW error: " + ex.Message);
        }
    }

    #endregion

    #region Profile / Page Actions

    /// <summary>
    /// Handles Following a profile on Facebook Desktop WWW.
    /// Supports English and Vietnamese, handles already-following checks and 3-dots overflow menu.
    /// </summary>
    private static string FollowWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string target = GetString(param, "uid", GetString(param, "url", GetString(param, "target", "")));

            if (!string.IsNullOrEmpty(target))
            {
                if (target.StartsWith("http://") || target.StartsWith("https://"))
                    NavigateIfNeeded(driver, target);
                else
                    NavigateIfNeeded(driver, "https://www.facebook.com/" + target);
                Sleep(2.5);
            }

            // Check if already following
            var alreadyFollowing = FindElementByText(driver, "div[role='main']",
                new[] { "Đang theo dõi", "Following" }, "span");
            if (alreadyFollowing != null)
            {
                var extra = new JObject { ["alreadyFollowing"] = true };
                return ResultJson(true, extra: extra);
            }

            // Look for Follow button
            var followBtn = FindElementByMultipleSelectors(driver,
                "div[aria-label='Theo dõi'][role='button']",
                "div[aria-label='Follow'][role='button']",
                "div[aria-label='Theo dõi']",
                "div[aria-label='Follow']");

            if (followBtn == null)
            {
                followBtn = FindElementByText(driver, "div[role='main']", new[] { "Theo dõi", "Follow" }, "div");
            }

            if (followBtn != null)
            {
                SafeClick(driver, followBtn);
                Sleep(1.5);
                return ResultJson(true);
            }

            // Check 3 dots menu on profile
            var moreBtn = FindElementByMultipleSelectors(driver,
                "div[aria-label*='Xem thêm'][role='button']",
                "div[aria-label*='More'][role='button']",
                "div[aria-label*='Hành động khác'][role='button']",
                "div[aria-label*='Xem thêm']",
                "div[aria-label*='More']");

            if (moreBtn != null)
            {
                SafeClick(driver, moreBtn);
                Sleep(1.2);

                var menuFollow = FindElementByText(driver, "div[role='menu']", new[] { "Theo dõi", "Follow" }, "span");
                if (menuFollow != null)
                {
                    SafeClick(driver, menuFollow);
                    Sleep(1.5);
                    return ResultJson(true);
                }
            }

            return ResultJson(false, "Could not find Follow / Theo dõi button");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "FollowWWW error: " + ex.Message);
        }
    }

    /// <summary>
    /// Handles Liking a Fanpage on Facebook Desktop WWW.
    /// Supports English and Vietnamese, handles already-liked checks and 3-dots overflow menu.
    /// </summary>
    private static string LikePageWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string target = GetString(param, "pageId", GetString(param, "uid", GetString(param, "url", "")));

            if (!string.IsNullOrEmpty(target))
            {
                if (target.StartsWith("http://") || target.StartsWith("https://"))
                    NavigateIfNeeded(driver, target);
                else
                    NavigateIfNeeded(driver, "https://www.facebook.com/" + target);
                Sleep(2.5);
            }

            // Check if already liked
            var alreadyLiked = FindElementByText(driver, "div[role='main']",
                new[] { "Đã thích", "Liked" }, "span");
            if (alreadyLiked != null)
            {
                var extra = new JObject { ["alreadyLiked"] = true };
                return ResultJson(true, extra: extra);
            }

            // Look for Like button on Page
            var likeBtn = FindElementByMultipleSelectors(driver,
                "div[aria-label='Thích'][role='button']",
                "div[aria-label='Like'][role='button']",
                "div[aria-label='Thích']",
                "div[aria-label='Like']");

            if (likeBtn == null)
            {
                likeBtn = FindElementByText(driver, "div[role='main']", new[] { "Thích", "Like" }, "div");
            }

            if (likeBtn != null)
            {
                SafeClick(driver, likeBtn);
                Sleep(1.5);
                return ResultJson(true);
            }

            // Check 3 dots menu
            var moreBtn = FindElementByMultipleSelectors(driver,
                "div[aria-label*='Xem thêm'][role='button']",
                "div[aria-label*='More'][role='button']",
                "div[aria-label*='Xem thêm']");

            if (moreBtn != null)
            {
                SafeClick(driver, moreBtn);
                Sleep(1.2);

                var menuLike = FindElementByText(driver, "div[role='menu']", new[] { "Thích", "Like", "Thích trang" }, "span");
                if (menuLike != null)
                {
                    SafeClick(driver, menuLike);
                    Sleep(1.5);
                    return ResultJson(true);
                }
            }

            return ResultJson(false, "Could not find Like / Thích button on page");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "LikePageWWW error: " + ex.Message);
        }
    }

    #endregion

    #region Direct Message UID Actions

    /// <summary>
    /// Handles sending direct messages to UID or conversation on Facebook Desktop WWW.
    /// Supports both dock chat tabs and full /messages/t/ pages.
    /// Navigates to messenger/conversation, writes text via clipboard, uploads image if provided,
    /// applies natural 1-2s delay before sending, and sends.
    /// </summary>
    private static string NhanTinUidWWW(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            string uid = GetString(param, "uid", GetString(param, "target", ""));
            string content = GetString(param, "content", "");
            string image = GetString(param, "image", GetString(param, "imagePath", ""));

            // Parse Spintax cho tin nhắn gửi đi
            content = SendingAutomationHelper.ResolveSpintax(content);

            // Kiểm tra trạng thái checkpoint / chặn tính năng
            if (SendingAutomationHelper.IsCheckpointOrRestricted(chrome))
            {
                return ResultJson(false, "Account restricted or checkpoint");
            }
            chrome.DismissFacebookPopups();

            if (!string.IsNullOrEmpty(uid))
            {
                string targetUrl = uid.StartsWith("http") ? uid : ("https://www.facebook.com/messages/t/" + uid);
                if (!driver.Url.Contains("/messages/t/" + uid))
                {
                    // Check if dock chat window is already open on current page before navigating
                    var existingDock = FindElementByMultipleSelectors(driver,
                        "div[data-pagelet*='ChatTab'] div[role='textbox'][contenteditable='true']",
                        "div[data-pagelet*='ChatTab'] div[role='textbox']",
                        "div[role='dialog'] div[role='textbox'][contenteditable='true']");

                    if (existingDock == null)
                    {
                        driver.Navigate().GoToUrl(targetUrl);
                        Sleep(3.5);
                    }
                }
            }

            // Find chat message textbox (supporting both chat dock window and full /messages/t/ page)
            IWebElement box = null;
            for (int retry = 0; retry < 5; retry++)
            {
                box = FindElementByMultipleSelectors(driver,
                    "div[role='main'] div[role='textbox'][contenteditable='true']",
                    "div[role='main'] div[role='textbox']",
                    "div[data-pagelet*='ChatTab'] div[role='textbox'][contenteditable='true']",
                    "div[data-pagelet*='ChatTab'] div[role='textbox']",
                    "div[role='dialog'] div[role='textbox'][contenteditable='true']",
                    "div[role='dialog'] div[role='textbox']",
                    "div[role='textbox'][contenteditable='true']",
                    "div[role='textbox'][aria-label*='Tin nhắn' i]",
                    "div[role='textbox'][aria-label*='Message' i]",
                    "div[aria-label*='Nhập tin nhắn' i]",
                    "div[data-lexical-editor='true']");

                if (box != null) break;
                Sleep(1.0);
            }

            if (box == null)
            {
                // Try finding "Nhắn tin" / "Message" button on profile to open chat dock window
                var msgBtn = FindElementByMultipleSelectors(driver,
                    "div[aria-label='Nhắn tin' i][role='button']",
                    "div[aria-label='Message' i][role='button']",
                    "div[aria-label*='Gửi tin nhắn' i][role='button']",
                    "div[aria-label*='Send message' i][role='button']",
                    "div[aria-label='Nhắn tin' i]",
                    "div[aria-label='Message' i]");

                if (msgBtn != null)
                {
                    SafeClick(driver, msgBtn);
                    Sleep(2.0);
                    box = FindElementByMultipleSelectors(driver,
                        "div[data-pagelet*='ChatTab'] div[role='textbox'][contenteditable='true']",
                        "div[data-pagelet*='ChatTab'] div[role='textbox']",
                        "div[role='dialog'] div[role='textbox'][contenteditable='true']",
                        "div[role='textbox'][contenteditable='true']",
                        "div[role='textbox'][aria-label*='Tin nhắn' i]",
                        "div[role='textbox'][aria-label*='Message' i]");
                }
            }

            if (box == null)
            {
                return ResultJson(false, "Could not find chat message textbox in dock or messages page");
            }

            // Input text
            if (!string.IsNullOrWhiteSpace(content))
            {
                PasteViaClipboard(driver, box, content);
                Sleep(0.8);
            }

            // Attach image if specified (hỗ trợ nhiều ảnh qua '|' hoặc ';')
            if (!string.IsNullOrWhiteSpace(image))
            {
                var imageList = image.Split(new[] { '|', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .Where(File.Exists)
                    .ToList();

                foreach (var imgPath in imageList)
                {
                    try
                    {
                        var fileInput = FindElementByMultipleSelectors(driver,
                            "input[type='file'][accept*='image']",
                            "input[type='file']");
                        if (fileInput == null)
                        {
                            var attachBtn = FindElementByMultipleSelectors(driver,
                                "[aria-label*='Đính kèm file' i]",
                                "[aria-label*='Attach a file' i]",
                                "[aria-label*='Gửi ảnh' i]",
                                "[aria-label*='Send a photo' i]",
                                "[aria-label*='Ảnh' i]",
                                "[aria-label*='Photo' i]");
                            if (attachBtn != null)
                            {
                                SafeClick(driver, attachBtn);
                                Sleep(1.0);
                                fileInput = FindElementByMultipleSelectors(driver, "input[type='file']");
                            }
                        }

                        if (fileInput != null)
                        {
                            ((IJavaScriptExecutor)driver).ExecuteScript(
                                "arguments[0].style.display = 'block'; arguments[0].style.visibility = 'visible'; arguments[0].style.opacity = '1';",
                                fileInput);
                            fileInput.SendKeys(Path.GetFullPath(imgPath));
                            Sleep(2.0);
                        }
                    }
                    catch { }
                }
            }

            // Delay tự nhiên 1-2s sau khi gõ nội dung trước khi bấm gửi/Enter
            int delayMs = Base.rd != null ? Base.rd.Next(1000, 2001) : new Random().Next(1000, 2001);
            Thread.Sleep(delayMs);

            // Send message via Enter
            try
            {
                box.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            catch { }

            var sendBtn = FindElementByMultipleSelectors(driver,
                "div[aria-label*='Gửi' i][role='button']",
                "div[aria-label*='Send' i][role='button']",
                "div[aria-label*='Press Enter to send' i]");

            if (sendBtn != null)
            {
                SafeClick(driver, sendBtn);
            }

            Sleep(2.0);
            return ResultJson(true);
        }
        catch (Exception ex)
        {
            return ResultJson(false, "NhanTinUidWWW error: " + ex.Message);
        }
    }

    #endregion

    #region Post Deletion Actions

    /// <summary>
    /// Handles Post Deletion on Facebook Desktop WWW.
    /// Finds 3 dots menu of post, clicks "Chuyển vào thùng rác" / "Xóa bài viết", and confirms.
    /// </summary>
    private static string DeletePost(Chrome chrome, JObject param)
    {
        try
        {
            IWebDriver driver = chrome.ChromeDriver_0;
            int indexPost = GetInt(param, "indexPost", 0);
            string url = GetString(param, "url", "");
            string postId = GetString(param, "postId", GetString(param, "idPost", ""));

            if (!string.IsNullOrEmpty(url)) NavigateIfNeeded(driver, url);
            else if (!string.IsNullOrEmpty(postId)) NavigateIfNeeded(driver, "https://www.facebook.com/" + postId);

            IWebElement post = GetPostElementWWW(driver, indexPost);
            ISearchContext searchContext = post ?? (ISearchContext)driver;

            var menuBtn = FindElementByMultipleSelectors(searchContext,
                "div[aria-label*='Hành động đối với bài viết'][role='button']",
                "div[aria-label*='Actions for this post'][role='button']",
                "div[aria-label*='Hành động'][role='button']",
                "div[aria-label*='Actions'][role='button']",
                "div[aria-label*='Xem thêm'][role='button']",
                "div[aria-label*='More'][role='button']",
                "div[aria-label*='Hành động đối với bài viết']",
                "div[aria-label*='Actions for this post']");

            if (menuBtn == null)
            {
                return ResultJson(false, "Could not find 3-dots post action menu button");
            }

            SafeClick(driver, menuBtn);
            Sleep(1.5);

            // Find Delete / Trash option in popup menu
            var deleteItem = FindElementByText(driver, "div[role='menu']",
                new[] { "Chuyển vào thùng rác", "Move to trash", "Xóa bài viết", "Delete post", "Chuyển vào kho lưu trữ", "Move to archive", "Xóa", "Delete" }, "span");

            if (deleteItem == null)
            {
                deleteItem = FindElementByText(driver, "div[role='menu']",
                    new[] { "thùng rác", "trash", "xóa bài viết", "delete post" }, "div");
            }

            if (deleteItem == null)
            {
                return ResultJson(false, "Could not find Move to trash / Delete post item in menu");
            }

            SafeClick(driver, deleteItem);
            Sleep(1.5);

            // Confirm deletion in dialog
            var confirmBtn = FindElementByMultipleSelectors(driver,
                "div[role='dialog'] div[aria-label='Chuyển'][role='button']",
                "div[role='dialog'] div[aria-label='Move'][role='button']",
                "div[role='dialog'] div[aria-label='Xóa'][role='button']",
                "div[role='dialog'] div[aria-label='Delete'][role='button']",
                "div[role='dialog'] [aria-label='Chuyển']",
                "div[role='dialog'] [aria-label='Move']",
                "div[role='dialog'] [aria-label='Xóa']",
                "div[role='dialog'] [aria-label='Delete']");

            if (confirmBtn == null)
            {
                confirmBtn = FindElementByText(driver, "div[role='dialog']",
                    new[] { "Chuyển", "Move", "Xóa", "Delete", "Xác nhận", "Confirm" }, "div");
            }

            if (confirmBtn != null)
            {
                SafeClick(driver, confirmBtn);
                Sleep(2.0);
                return ResultJson(true);
            }

            return ResultJson(false, "Could not find confirmation button in delete dialog");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "DeletePost error: " + ex.Message);
        }
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Constructs uniform JSON string result matching project conventions.
    /// </summary>
    private static string ResultJson(bool success, string error = "", string commentId = null, JObject extra = null)
    {
        var obj = new JObject
        {
            ["success"] = success,
            ["error"] = error ?? ""
        };
        if (commentId != null)
        {
            obj["commentId"] = commentId;
        }
        if (extra != null)
        {
            foreach (var prop in extra.Properties())
            {
                obj[prop.Name] = prop.Value;
            }
        }
        return obj.ToString(Newtonsoft.Json.Formatting.None);
    }

    /// <summary>
    /// Safe sleep delegating to Commom.smethod_52 or Thread.Sleep.
    /// </summary>
    private static void Sleep(double seconds)
    {
        try
        {
            Commom.smethod_52(seconds);
        }
        catch
        {
            Thread.Sleep((int)(seconds * 1000));
        }
    }

    /// <summary>
    /// Smoothly navigates to target URL if not already there.
    /// </summary>
    private static void NavigateIfNeeded(IWebDriver driver, string url)
    {
        if (driver == null || string.IsNullOrWhiteSpace(url)) return;
        try
        {
            if (url.IndexOf("mbasic.facebook.com", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                url = Regex.Replace(url, @"https?://mbasic\.facebook\.com", "https://www.facebook.com", RegexOptions.IgnoreCase);
            }
            string current = driver.Url ?? "";
            if (!current.Equals(url, StringComparison.OrdinalIgnoreCase) &&
                !current.TrimEnd('/').Equals(url.TrimEnd('/'), StringComparison.OrdinalIgnoreCase))
            {
                driver.Navigate().GoToUrl(url);
                Sleep(2.5);
            }
        }
        catch { }
    }

    /// <summary>
    /// Scrolls page down by specified pixel amount.
    /// </summary>
    private static void ScrollDown(IWebDriver driver, int pixels)
    {
        try
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy({{top: {pixels}, behavior: 'smooth'}});");
        }
        catch { }
    }

    /// <summary>
    /// Retrieves post container element on Facebook Desktop WWW using Comet 2026 anti-lazy-load selectors.
    /// Prioritizes finding the active/visible post in viewport center (solving Comet feed virtualization).
    /// </summary>
    private static IWebElement GetPostElementWWW(IWebDriver driver, int indexPost)
    {
        if (driver == null) return null;
        try
        {
            // 1. First priority: find article/feed unit active and visible around viewport center
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js != null)
            {
                try
                {
                    string findActiveJs = @"
                        var selectors = [
                            ""div[role='feed'] > div[data-pagelet*='FeedUnit']"",
                            ""div[role='main'] div[data-pagelet*='FeedUnit']"",
                            ""div[role='feed'] div[role='article']"",
                            ""div[role='main'] div[role='article']"",
                            ""div[role='article']"",
                            ""div[data-pagelet*='FeedUnit']""
                        ];
                        var elements = [];
                        for (var s = 0; s < selectors.length; s++) {
                            var found = document.querySelectorAll(selectors[s]);
                            if (found && found.length > 0) {
                                elements = Array.from(found);
                                break;
                            }
                        }
                        if (elements.length === 0) {
                            elements = Array.from(document.querySelectorAll(""div[role='article']""));
                        }

                        var valid = elements.filter(function(el) {
                            try {
                                var rect = el.getBoundingClientRect();
                                if (rect.height < 60 || rect.width < 180) return false;
                                if (el.getAttribute('aria-busy') === 'true') return false;
                                return rect.top < window.innerHeight && rect.bottom > 0;
                            } catch(e) { return false; }
                        });

                        if (valid.length > 0) {
                            var targetIdx = arguments[0];
                            if (typeof targetIdx === 'number' && targetIdx >= 0) {
                                if (targetIdx >= valid.length) targetIdx = valid.length - 1;
                                var el = valid[targetIdx];
                                if (el) {
                                    el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    return el;
                                }
                            }
                            var viewCenterY = window.innerHeight / 2;
                            var bestEl = null;
                            var bestScore = -999999;
                            for (var i = 0; i < valid.length; i++) {
                                var el = valid[i];
                                var rect = el.getBoundingClientRect();
                                var visibleTop = Math.max(0, rect.top);
                                var visibleBottom = Math.min(window.innerHeight, rect.bottom);
                                var visibleHeight = Math.max(0, visibleBottom - visibleTop);
                                var elCenterY = (rect.top + rect.bottom) / 2;
                                var distToCenter = Math.abs(elCenterY - viewCenterY);
                                var containsCenter = (rect.top <= viewCenterY && rect.bottom >= viewCenterY) ? 10000 : 0;
                                var score = containsCenter + visibleHeight - (distToCenter * 0.5);
                                if (score > bestScore) {
                                    bestScore = score;
                                    bestEl = el;
                                }
                            }
                            return bestEl;
                        }
                        return null;
                    ";
                    IWebElement activeInViewport = js.ExecuteScript(findActiveJs, indexPost) as IWebElement;
                    if (activeInViewport != null)
                    {
                        return activeInViewport;
                    }
                }
                catch { }
            }

            // 2. Fallback: query DOM elements list
            const string feedSelector = "div[role='feed'] > div[data-pagelet*='FeedUnit'], div[role='main'] div[data-pagelet*='FeedUnit'], div[role='feed'] div[role='article'], div[role='article'], div[data-pagelet*='FeedUnit']";
            for (int attempt = 0; attempt < 2; attempt++)
            {
                var elements = driver.FindElements(By.CssSelector(feedSelector));
                if (elements != null && elements.Count > 0)
                {
                    var valid = elements.Where(e => {
                        try
                        {
                            if (!e.Displayed) return false;
                            var size = e.Size;
                            if (size.Height < 60 || size.Width < 180) return false;
                            string busy = e.GetAttribute("aria-busy");
                            if (busy != null && busy.Equals("true", StringComparison.OrdinalIgnoreCase)) return false;
                            return true;
                        }
                        catch { return false; }
                    }).ToList();

                    if (valid.Count > 0)
                    {
                        int target = (indexPost >= 0 && indexPost < valid.Count) ? indexPost : (valid.Count - 1);
                        var chosen = valid[target];
                        try
                        {
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", chosen);
                        }
                        catch { }
                        return chosen;
                    }
                }

                if (attempt == 0)
                {
                    ScrollDown(driver, 400);
                    Sleep(0.8);
                }
            }
        }
        catch { }
        return null;
    }

    /// <summary>
    /// Finds the Like button within a post container (Comet 2026 English & Vietnamese).
    /// </summary>
    private static IWebElement FindLikeButtonInPost(IWebDriver driver, IWebElement post)
    {
        ISearchContext searchContext = post ?? (ISearchContext)driver;

        var likeBtn = FindElementByMultipleSelectors(searchContext,
            "div[role='toolbar'] [aria-label*='Thích' i]",
            "div[role='toolbar'] [aria-label*='Like' i]",
            "div[role='article'] [role='button'][aria-label*='Thích' i]",
            "div[role='article'] [role='button'][aria-label*='Like' i]",
            "div[role='toolbar'] [aria-label*='Thích'][role='button']",
            "div[role='toolbar'] [aria-label*='Like'][role='button']",
            "div[role='toolbar'] [aria-label='Thích'][role='button']",
            "div[role='toolbar'] [aria-label='Like'][role='button']",
            "div[role='article'] [role='button'][aria-label*='Thích']",
            "div[role='article'] [role='button'][aria-label*='Like']",
            "[role='button'][aria-label*='Thích' i]",
            "[role='button'][aria-label*='Like' i]",
            "[aria-label*='Thích' i]",
            "[aria-label*='Like' i]",
            "div[aria-label*='Thích'][role='button']",
            "div[aria-label*='Like'][role='button']",
            "div[aria-label='Thích'][role='button']",
            "div[aria-label='Like'][role='button']",
            "div[aria-label='Like']",
            "div[aria-label='Thích']",
            "[role='button'][aria-label*='React']",
            "[role='button'][aria-label*='Bày tỏ cảm xúc']",
            "[role='button'][aria-label*='Yêu thích']",
            "[role='button'][aria-label*='Thương thương']",
            "[role='button'][aria-label*='Haha']",
            "[role='button'][aria-label*='Wow']",
            "[role='button'][aria-label*='Buồn']",
            "[role='button'][aria-label*='Phẫn nộ']",
            "[role='button'][aria-label^='Like ']",
            "[role='button'][aria-label^='Thích ']");

        if (likeBtn != null) return likeBtn;

        if (post != null)
        {
            likeBtn = FindElementByMultipleSelectors(driver,
                "div[role='toolbar'] [aria-label*='Thích' i]",
                "div[role='toolbar'] [aria-label*='Like' i]",
                "div[role='article'] [role='button'][aria-label*='Thích' i]",
                "div[role='article'] [role='button'][aria-label*='Like' i]",
                "[role='button'][aria-label*='Thích' i]",
                "[role='button'][aria-label*='Like' i]");
            if (likeBtn != null) return likeBtn;
        }

        try
        {
            string js = @"
                var root = arguments[0] || document;
                function findLike(container) {
                    if (!container) return null;
                    var buttons = container.querySelectorAll('[role=""button""], div[aria-label], span[aria-label]');
                    for (var i = 0; i < buttons.length; i++) {
                        var b = buttons[i];
                        var aria = (b.getAttribute('aria-label') || '').toLowerCase();
                        var txt = (b.innerText || '').trim().toLowerCase();
                        if (aria.includes('bỏ thích') || aria.includes('remove like') || aria.includes('unlike') ||
                            aria.includes('gỡ cảm xúc') || txt.includes('bỏ thích') || txt.includes('remove like') || txt.includes('unlike')) {
                            continue; // Không bấm Bỏ thích
                        }
                        if (aria === 'like' || aria === 'thích' || txt === 'like' || txt === 'thích' 
                            || aria.startsWith('thích') || aria.startsWith('like')
                            || aria.indexOf('thích') !== -1 || aria.indexOf('like') !== -1
                            || aria.indexOf('bày tỏ cảm xúc') !== -1 || aria.indexOf('react') !== -1
                            || aria.indexOf('leave a reaction') !== -1
                            || aria.indexOf('yêu thích') !== -1 || aria.indexOf('love') !== -1) {
                            return b;
                        }
                    }
                    return null;
                }
                var res = findLike(root);
                if (!res && root !== document) {
                    res = findLike(document);
                }
                return res;
            ";
            return ((IJavaScriptExecutor)driver).ExecuteScript(js, post) as IWebElement;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Finds target reaction element inside reaction dock toolbar (Comet 2026 English & Vietnamese).
    /// </summary>
    private static IWebElement FindReactionElementInDock(IWebDriver driver, string reaction)
    {
        string[] enViLabels;
        switch (reaction)
        {
            case "Love":
                enViLabels = new[] { "Love", "Yêu thích", "tim", "Tim", "love", "yêu thích" };
                break;
            case "Care":
                enViLabels = new[] { "Care", "Thương thương", "care", "thương thương" };
                break;
            case "Haha":
                enViLabels = new[] { "Haha", "Cười", "haha" };
                break;
            case "Wow":
                enViLabels = new[] { "Wow", "wow" };
                break;
            case "Sad":
                enViLabels = new[] { "Sad", "Buồn", "sad", "buồn" };
                break;
            case "Angry":
                enViLabels = new[] { "Angry", "Phẫn nộ", "angry", "phẫn nộ" };
                break;
            default:
                enViLabels = new[] { "Like", "Thích", "like", "thích" };
                break;
        }

        var dock = FindElementByMultipleSelectors(driver,
            "div[aria-label*='Reactions' i]",
            "div[aria-label*='Cảm xúc' i]",
            "div[role='toolbar'][aria-label*='Reaction' i]",
            "div[role='toolbar'][aria-label*='Cảm xúc' i]",
            "div[role='dialog'] [role='toolbar']",
            "div[role='toolbar']",
            "div[data-pagelet*='Reaction']",
            "div[aria-label='Reactions']",
            "div[aria-label='Cảm xúc']");

        ISearchContext searchContext = (ISearchContext)dock ?? driver;

        foreach (var label in enViLabels)
        {
            var el = FindElementByMultipleSelectors(searchContext,
                $"[aria-label*='{label}' i]",
                $"[data-reaction*='{label}' i]",
                $"div[role='button'][aria-label*='{label}' i]",
                $"[aria-label='{label}']",
                $"[data-reaction='{label}']");
            if (el != null) return el;
        }

        if (dock != null)
        {
            foreach (var label in enViLabels)
            {
                var el = FindElementByMultipleSelectors(driver,
                    $"[aria-label*='{label}' i][role='button']",
                    $"[aria-label*='{label}' i]",
                    $"[data-reaction*='{label}' i]");
                if (el != null) return el;
            }
        }

        var byText = FindElementByText(driver, "div[role='toolbar'], div[aria-label*='Reaction' i], div[aria-label*='Cảm xúc' i]", enViLabels, "div");
        if (byText != null) return byText;

        try
        {
            string js = @"
                var targets = arguments[0] || [];
                var toolbars = document.querySelectorAll('div[role=""toolbar""], div[aria-label*=""Reaction"" i], div[aria-label*=""Cảm xúc"" i], div[role=""dialog""]');
                for (var t = 0; t < toolbars.length; t++) {
                    var items = toolbars[t].querySelectorAll('[role=""button""], div[aria-label], span[aria-label], [data-reaction]');
                    for (var i = 0; i < items.length; i++) {
                        var aria = (items[i].getAttribute('aria-label') || items[i].getAttribute('data-reaction') || '').toLowerCase();
                        for (var k = 0; k < targets.length; k++) {
                            if (aria.indexOf(targets[k].toLowerCase()) !== -1) return items[i];
                        }
                    }
                }
                var allBtns = document.querySelectorAll('[role=""button""][aria-label], div[aria-label][role=""button""]');
                for (var j = 0; j < allBtns.length; j++) {
                    var btnAria = (allBtns[j].getAttribute('aria-label') || '').toLowerCase();
                    for (var m = 0; m < targets.length; m++) {
                        var targetStr = targets[m].toLowerCase();
                        if (btnAria === targetStr || btnAria.startsWith(targetStr) || btnAria.indexOf(targetStr) !== -1) {
                            var r = allBtns[j].getBoundingClientRect();
                            if (r.width > 0 && r.height > 0) return allBtns[j];
                        }
                    }
                }
                return null;
            ";
            return ((IJavaScriptExecutor)driver).ExecuteScript(js, (object)enViLabels) as IWebElement;
        }
        catch { return null; }
    }

    /// <summary>
    /// Finds comment input textbox inside post (Comet 2026 Lexical editor English & Vietnamese).
    /// </summary>
    private static IWebElement FindCommentBoxInPost(IWebDriver driver, IWebElement post)
    {
        ISearchContext searchContext = post ?? (ISearchContext)driver;

        var box = FindElementByMultipleSelectors(searchContext,
            "div[role='textbox'][contenteditable='true']",
            "[aria-label*='Viết bình luận' i]",
            "[aria-label*='Write a comment' i]",
            "[data-lexical-editor='true']",
            "div[data-lexical-editor='true']",
            "[role='textbox'][contenteditable='true']",
            "div[aria-label*='Bình luận'][contenteditable='true']",
            "div[aria-label*='Comment'][contenteditable='true']",
            "div[aria-label*='Write a comment'][contenteditable='true']",
            "div[aria-label*='Viết bình luận'][contenteditable='true']",
            "div[aria-label*='Viết bình luận công khai'][contenteditable='true']",
            "div[aria-label*='Write a public comment'][contenteditable='true']",
            "div[aria-label*='Viết câu trả lời'][contenteditable='true']",
            "div[aria-label*='Write an answer'][contenteditable='true']",
            "form [role='textbox']",
            "form div[contenteditable='true']");

        if (box != null) return box;

        var fallback = FindElementByMultipleSelectors(driver,
            "div[role='textbox'][contenteditable='true']",
            "[aria-label*='Viết bình luận' i]",
            "[aria-label*='Write a comment' i]",
            "[data-lexical-editor='true']",
            "div[data-lexical-editor='true']",
            "[role='textbox'][contenteditable='true']",
            "div[aria-label*='Bình luận'][contenteditable='true']",
            "div[aria-label*='Comment'][contenteditable='true']",
            "div[aria-label*='Write a comment'][contenteditable='true']",
            "div[aria-label*='Viết bình luận'][contenteditable='true']");

        if (fallback != null) return fallback;

        try
        {
            string js = @"
                var root = arguments[0] || document;
                function findBox(container) {
                    if (!container) return null;
                    return container.querySelector('div[contenteditable=""true""][role=""textbox""], [data-lexical-editor=""true""], [role=""textbox""][contenteditable=""true""], [aria-label*=""Viết bình luận"" i], [aria-label*=""Write a comment"" i], [aria-label*=""Bình luận"" i][contenteditable=""true""], form [role=""textbox""], form [contenteditable=""true""]');
                }
                var res = findBox(root);
                if (!res && root !== document) {
                    res = findBox(document);
                }
                return res;
            ";
            return ((IJavaScriptExecutor)driver).ExecuteScript(js, post) as IWebElement;
        }
        catch { return null; }
    }

    /// <summary>
    /// Toggles comment input open by clicking Comment button on post if not already open (Comet 2026 English & Vietnamese).
    /// </summary>
    private static bool OpenCommentBoxIfClosed(IWebDriver driver, IWebElement post)
    {
        ISearchContext searchContext = post ?? (ISearchContext)driver;
        var btn = FindElementByMultipleSelectors(searchContext,
            "div[role='toolbar'] [aria-label*='Bình luận' i]",
            "div[role='toolbar'] [aria-label*='Comment' i]",
            "div[role='article'] [role='button'][aria-label*='Bình luận' i]",
            "div[role='article'] [role='button'][aria-label*='Comment' i]",
            "[role='button'][aria-label*='Bình luận' i]",
            "[role='button'][aria-label*='Comment' i]",
            "[aria-label*='Viết bình luận' i]",
            "[aria-label*='Write a comment' i]",
            "div[role='toolbar'] div[aria-label*='Bình luận'][role='button']",
            "div[role='toolbar'] div[aria-label*='Comment'][role='button']",
            "div[aria-label='Bình luận'][role='button']",
            "div[aria-label='Comment'][role='button']",
            "div[aria-label*='Bình luận'][role='button']",
            "div[aria-label*='Comment'][role='button']",
            "div[aria-label*='Viết bình luận']",
            "div[aria-label*='Write a comment']",
            "div[aria-label*='Leave a comment']",
            "div[aria-label='Bình luận']",
            "div[aria-label='Comment']");

        if (btn == null && post != null)
        {
            btn = FindElementByMultipleSelectors(driver,
                "div[role='toolbar'] [aria-label*='Bình luận' i]",
                "div[role='toolbar'] [aria-label*='Comment' i]",
                "div[role='article'] [role='button'][aria-label*='Bình luận' i]",
                "div[role='article'] [role='button'][aria-label*='Comment' i]",
                "[role='button'][aria-label*='Bình luận' i]",
                "[role='button'][aria-label*='Comment' i]",
                "[aria-label*='Viết bình luận' i]",
                "[aria-label*='Write a comment' i]");
        }

        if (btn == null)
        {
            btn = FindElementByText(driver, null, new[] { "Bình luận", "Comment", "Viết bình luận", "Write a comment" }, "div");
        }

        if (btn != null)
        {
            SafeClick(driver, btn);
            Sleep(1.0);
            return true;
        }

        try
        {
            string js = @"
                var root = arguments[0] || document;
                function findCommentBtn(container) {
                    if (!container) return null;
                    var btns = container.querySelectorAll('[role=""button""], div[aria-label], span[aria-label]');
                    for (var i = 0; i < btns.length; i++) {
                        var b = btns[i];
                        var aria = (b.getAttribute('aria-label') || '').toLowerCase();
                        var txt = (b.innerText || '').trim().toLowerCase();
                        if (aria.indexOf('bình luận') !== -1 || aria.indexOf('comment') !== -1 ||
                            txt === 'bình luận' || txt === 'comment' || txt.indexOf('viết bình luận') !== -1 || txt.indexOf('write a comment') !== -1) {
                            return b;
                        }
                    }
                    return null;
                }
                var target = findCommentBtn(root);
                if (!target && root !== document) {
                    target = findCommentBtn(document);
                }
                if (target) {
                    try { target.scrollIntoView({ behavior: 'smooth', block: 'center' }); } catch(e){}
                    target.click();
                    return true;
                }
                return false;
            ";
            object res = ((IJavaScriptExecutor)driver).ExecuteScript(js, post);
            if (res is bool b && b)
            {
                Sleep(1.0);
                return true;
            }
        }
        catch { }

        return false;
    }

    /// <summary>
    /// Attaches an image file to a comment form.
    /// Automatically clicks camera/photo icon if input[type='file'] has not appeared in DOM (Comet lazy-load),
    /// removes hidden styles (display='block', visibility='visible', opacity='1'), inputs image path and waits 2.0s for preview.
    /// </summary>
    private static bool AttachImageToComment(IWebDriver driver, IWebElement post, string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath)) return false;

        try
        {
            string fullPath = Path.GetFullPath(imagePath);
            ISearchContext searchContext = post ?? (ISearchContext)driver;

            var fileInput = FindElementByMultipleSelectors(searchContext,
                "input[type='file'][accept*='image']",
                "input[type='file']");

            if (fileInput == null && searchContext != driver)
            {
                fileInput = FindElementByMultipleSelectors(driver,
                    "input[type='file'][accept*='image']",
                    "input[type='file']");
            }

            if (fileInput == null)
            {
                // In modern Facebook Comet, the input[type=file] is lazy-loaded when clicking the photo/camera icon
                var photoIcon = FindElementByMultipleSelectors(searchContext,
                    "[aria-label*='Đính kèm ảnh' i]",
                    "[aria-label*='Attach a photo' i]",
                    "[aria-label*='Ảnh/video' i]",
                    "[aria-label*='Photo/video' i]",
                    "[aria-label*='Đính kèm file' i]",
                    "[aria-label*='Attach a photo or video' i]",
                    "[aria-label*='Đính kèm ảnh hoặc video' i]",
                    "[aria-label*='Attach' i]");

                if (photoIcon == null && searchContext != driver)
                {
                    photoIcon = FindElementByMultipleSelectors(driver,
                        "[aria-label*='Đính kèm ảnh' i]",
                        "[aria-label*='Attach a photo' i]",
                        "[aria-label*='Ảnh/video' i]",
                        "[aria-label*='Photo/video' i]",
                        "[aria-label*='Đính kèm file' i]",
                        "[aria-label*='Attach a photo or video' i]",
                        "[aria-label*='Đính kèm ảnh hoặc video' i]",
                        "[aria-label*='Attach' i]");
                }

                if (photoIcon != null)
                {
                    SafeClick(driver, photoIcon);
                    Sleep(1.0);
                    fileInput = FindElementByMultipleSelectors(searchContext, "input[type='file']");
                    if (fileInput == null && searchContext != driver)
                    {
                        fileInput = FindElementByMultipleSelectors(driver, "input[type='file']");
                    }
                }
            }

            if (fileInput != null)
            {
                try
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript(
                        "arguments[0].style.display = 'block'; arguments[0].style.visibility = 'visible'; arguments[0].style.opacity = '1';",
                        fileInput);
                }
                catch { }

                fileInput.SendKeys(fullPath);
                Sleep(2.0); // Chờ preview 2.0s
                return true;
            }
        }
        catch (Exception ex)
        {
            Commom.smethod_49("AttachImageToComment error: " + ex.Message);
        }
        return false;
    }

    /// <summary>
    /// Extracts recently submitted comment ID from DOM.
    /// </summary>
    private static string ExtractCommentId(IWebDriver driver)
    {
        try
        {
            string js = @"
                var links = Array.from(document.querySelectorAll('a[href*=""comment_id=""], a[href*=""reply_comment_id=""]'));
                for (var i = links.length - 1; i >= 0; i--) {
                    var m = links[i].href.match(/(?:comment_id|reply_comment_id)=(\d+)/);
                    if (m && m[1]) return m[1];
                }
                var articles = document.querySelectorAll('[data-commentid]');
                if (articles.length > 0) {
                    return articles[articles.length - 1].getAttribute('data-commentid') || '';
                }
                return '';
            ";
            object res = ((IJavaScriptExecutor)driver).ExecuteScript(js);
            return res?.ToString() ?? "";
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Multi-tier high-reliability text entry into Facebook input fields (Lexical, ContentEditable, Textbox).
    /// Tier 1: STA Thread Clipboard Ctrl+V with lock & DOM verification.
    /// Tier 2: Direct Selenium SendKeys character/line typing simulation with natural human delays (15-35ms) & Shift+Enter.
    /// Tier 3: Synthetic DOM beforeinput / InputEvent / ClipboardEvent dispatch.
    /// Tier 4: DOM element verification & deep fallback insertion.
    /// </summary>
    private static bool PasteViaClipboard(IWebDriver driver, IWebElement element, string text)
    {
        if (driver == null || element == null) return false;
        if (string.IsNullOrEmpty(text)) return true;

        string normalized = text.Replace("\r", "").Trim();
        bool filledSuccessfully = false;

        // Ensure element focus
        try
        {
            try { element.Click(); } catch { }
            try { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", element); } catch { }
            Sleep(0.2);

            // Tier 1: STA Clipboard Ctrl+V paste with lock + verification
            lock (_clipboardLock)
            {
                bool setClipOk = false;
                for (int r = 0; r < 5; r++)
                {
                    try
                    {
                        if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                        {
                            Clipboard.Clear();
                            Clipboard.SetDataObject(normalized, true, 5, 100);
                            setClipOk = true;
                            break;
                        }
                        else
                        {
                            Thread staThread = new Thread(() =>
                            {
                                try
                                {
                                    Clipboard.Clear();
                                    Clipboard.SetDataObject(normalized, true, 5, 100);
                                    setClipOk = true;
                                }
                                catch { }
                            });
                            staThread.SetApartmentState(ApartmentState.STA);
                            staThread.IsBackground = true;
                            staThread.Start();
                            staThread.Join(1500);
                            if (setClipOk) break;
                        }
                    }
                    catch
                    {
                        Thread.Sleep(100);
                    }
                }

                if (setClipOk)
                {
                    element.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                    Sleep(0.4);

                    // Verify if text got inserted
                    try
                    {
                        object check = ((IJavaScriptExecutor)driver).ExecuteScript(
                            "var el = arguments[0]; var t = (el.innerText || el.textContent || el.value || '').trim(); return t.length > 0;",
                            element);
                        if (check != null && Convert.ToBoolean(check))
                        {
                            filledSuccessfully = true;
                        }
                    }
                    catch { }
                }
            }
        }
        catch (Exception ex)
        {
            Commom.smethod_49("PasteViaClipboard STA error: " + ex.Message);
        }

        // Tier 2: Selenium SendKeys direct human typing line-by-line (with Shift+Enter for newlines and 15-35ms rhythm)
        if (!filledSuccessfully)
        {
            try
            {
                element.Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", element);
                Sleep(0.2);

                string[] lines = normalized.Split('\n');
                var random = new Random();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i > 0)
                    {
                        element.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                        Sleep(0.05);
                    }
                    string line = lines[i];
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Length <= 120)
                        {
                            for (int c = 0; c < line.Length; c++)
                            {
                                element.SendKeys(line[c].ToString());
                                Thread.Sleep(random.Next(15, 36));
                            }
                        }
                        else
                        {
                            var tokens = line.Split(' ');
                            for (int t = 0; t < tokens.Length; t++)
                            {
                                element.SendKeys(tokens[t] + (t < tokens.Length - 1 ? " " : ""));
                                Thread.Sleep(random.Next(15, 36));
                            }
                        }
                    }
                }
                Sleep(0.3);

                object check2 = ((IJavaScriptExecutor)driver).ExecuteScript(
                    "var el = arguments[0]; var t = (el.innerText || el.textContent || el.value || '').trim(); return t.length > 0;",
                    element);
                if (check2 != null && Convert.ToBoolean(check2))
                {
                    filledSuccessfully = true;
                }
            }
            catch (Exception ex)
            {
                Commom.smethod_49("PasteViaClipboard SendKeys fallback error: " + ex.Message);
            }
        }

        // Tier 3: DOM synthetic beforeinput / InputEvent / ClipboardEvent
        if (!filledSuccessfully)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(@"
                    var el = arguments[0];
                    var val = arguments[1];
                    if (!el) return;
                    el.focus();
                    try {
                        var dt = new DataTransfer();
                        dt.setData('text/plain', val);
                        var pasteEvt = new ClipboardEvent('paste', { clipboardData: dt, bubbles: true, cancelable: true });
                        el.dispatchEvent(pasteEvt);
                    } catch(e) {}

                    var cur = (el.innerText || el.textContent || el.value || '').trim();
                    if (cur.length === 0) {
                        try {
                            if (document.queryCommandSupported && document.queryCommandSupported('insertText')) {
                                document.execCommand('insertText', false, val);
                            }
                        } catch(e) {}
                        try {
                            el.dispatchEvent(new InputEvent('beforeinput', { inputType: 'insertText', data: val, bubbles: true, cancelable: true }));
                            el.dispatchEvent(new InputEvent('input', { inputType: 'insertText', data: val, bubbles: true }));
                        } catch(e) {}
                    }
                    el.dispatchEvent(new Event('input', { bubbles: true }));
                    el.dispatchEvent(new Event('change', { bubbles: true }));
                ", element, normalized);
                Sleep(0.3);

                object check3 = ((IJavaScriptExecutor)driver).ExecuteScript(
                    "var el = arguments[0]; var t = (el.innerText || el.textContent || el.value || '').trim(); return t.length > 0;",
                    element);
                if (check3 != null && Convert.ToBoolean(check3))
                {
                    filledSuccessfully = true;
                }
            }
            catch (Exception ex)
            {
                Commom.smethod_49("PasteViaClipboard Tier 3 synthetic input error: " + ex.Message);
            }
        }

        // Tier 4: Kiểm tra xác thực DOM element & deep fallback
        if (!filledSuccessfully)
        {
            try
            {
                object check4 = ((IJavaScriptExecutor)driver).ExecuteScript(@"
                    var el = arguments[0];
                    var val = arguments[1];
                    if (!el) return false;
                    var t = (el.innerText || el.textContent || el.value || '').trim();
                    if (t.length > 0) return true;

                    try {
                        if (el.tagName === 'INPUT' || el.tagName === 'TEXTAREA') {
                            el.value = val;
                        } else if (el.isContentEditable) {
                            var p = el.querySelector('p');
                            if (p) {
                                p.textContent = val;
                            } else {
                                el.innerHTML = '<p>' + val.replace(/\n/g, '<br>') + '</p>';
                            }
                        }
                        el.dispatchEvent(new Event('input', { bubbles: true }));
                        el.dispatchEvent(new Event('change', { bubbles: true }));
                    } catch(e) {}

                    var verified = (el.innerText || el.textContent || el.value || '').trim();
                    return verified.length > 0;
                ", element, normalized);

                if (check4 != null && Convert.ToBoolean(check4))
                {
                    filledSuccessfully = true;
                }
            }
            catch (Exception ex)
            {
                Commom.smethod_49("PasteViaClipboard Tier 4 verification error: " + ex.Message);
            }
        }

        return filledSuccessfully;
    }

    /// <summary>
    /// Safely clicks an element with smooth scroll and fallback across native click, Actions, and JS click.
    /// </summary>
    private static bool SafeClick(IWebDriver driver, IWebElement element)
    {
        if (element == null) return false;
        try
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
            Sleep(0.3);
        }
        catch { }

        try
        {
            element.Click();
            return true;
        }
        catch
        {
            try
            {
                new Actions(driver).MoveToElement(element).Click().Perform();
                return true;
            }
            catch
            {
                try
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                    return true;
                }
                catch { }
            }
        }
        return false;
    }

    /// <summary>
    /// Safely hovers over an element using Actions and dispatches JS mouseover/pointer events.
    /// </summary>
    private static bool SafeHover(IWebDriver driver, IWebElement element, double hoverSeconds = 1.2)
    {
        if (element == null) return false;
        try
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
            Sleep(0.3);
        }
        catch { }

        try
        {
            new Actions(driver).MoveToElement(element).Perform();
        }
        catch { }

        try
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(@"
                var el = arguments[0];
                var rect = el.getBoundingClientRect();
                var cx = rect.left + rect.width / 2;
                var cy = rect.top + rect.height / 2;
                var opts = { bubbles: true, cancelable: true, composed: true, view: window, clientX: cx, clientY: cy, screenX: cx, screenY: cy };
                el.dispatchEvent(new PointerEvent('pointerover', opts));
                el.dispatchEvent(new PointerEvent('pointerenter', opts));
                el.dispatchEvent(new MouseEvent('mouseover', opts));
                el.dispatchEvent(new MouseEvent('mouseenter', opts));
                el.dispatchEvent(new PointerEvent('pointermove', opts));
                el.dispatchEvent(new MouseEvent('mousemove', opts));
            ", element);
        }
        catch { }

        Sleep(hoverSeconds);
        return true;
    }

    /// <summary>
    /// Queries element matching any of the specified CSS selectors.
    /// </summary>
    private static IWebElement FindElementByMultipleSelectors(ISearchContext context, params string[] cssSelectors)
    {
        if (context == null) return null;
        foreach (var selector in cssSelectors)
        {
            try
            {
                var elements = context.FindElements(By.CssSelector(selector));
                var visible = elements.FirstOrDefault(e => {
                    try { return e.Displayed && e.Enabled; } catch { return false; }
                });
                if (visible != null) return visible;
                if (elements.Count > 0) return elements[0];
            }
            catch { }
        }
        return null;
    }

    /// <summary>
    /// Finds element containing specific inner text or aria-label within a container.
    /// </summary>
    private static IWebElement FindElementByText(IWebDriver driver, string containerSelector, string[] searchTexts, string tag = "*")
    {
        try
        {
            string js = @"
                var container = arguments[0] ? document.querySelector(arguments[0]) : document;
                if (!container) return null;
                var tag = arguments[1] || '*';
                var texts = arguments[2] || [];
                var elements = container.querySelectorAll(tag);
                for (var i = 0; i < elements.length; i++) {
                    var el = elements[i];
                    var t = (el.innerText || el.textContent || '').trim().toLowerCase();
                    var aria = (el.getAttribute('aria-label') || '').trim().toLowerCase();
                    for (var j = 0; j < texts.length; j++) {
                        var target = texts[j].toLowerCase();
                        if (t === target || aria === target || t.indexOf(target) !== -1 || aria.indexOf(target) !== -1) {
                            return el;
                        }
                    }
                }
                return null;
            ";
            var res = ((IJavaScriptExecutor)driver).ExecuteScript(js, containerSelector, tag, searchTexts);
            return res as IWebElement;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Normalizes reaction type string to standard capitalized name (Like, Love, Care, Haha, Wow, Sad, Angry).
    /// </summary>
    private static string NormalizeReaction(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "Like";
        if (input.Contains("|") || input.Contains(","))
        {
            var parts = input.Split(new[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                input = parts[_rand.Next(0, parts.Length)].Trim();
            }
        }
        string s = input.Trim().ToLowerInvariant();
        if (s == "0" || s == "like" || s == "thích") return "Like";
        if (s == "1" || s == "love" || s == "yêu thích" || s == "tim") return "Love";
        if (s == "2" || s == "care" || s == "thương thương") return "Care";
        if (s == "3" || s == "haha" || s == "cười") return "Haha";
        if (s == "4" || s == "wow") return "Wow";
        if (s == "5" || s == "sad" || s == "buồn") return "Sad";
        if (s == "6" || s == "angry" || s == "phẫn nộ") return "Angry";

        if (s.Length > 0)
            return char.ToUpperInvariant(s[0]) + s.Substring(1);
        return "Like";
    }

    /// <summary>
    /// Maps reaction name to Facebook numeric reaction code for mfb and mobile.
    /// </summary>
    private static string GetReactionCode(string reaction)
    {
        switch (reaction)
        {
            case "Love": return "2";
            case "Care": return "16";
            case "Haha": return "4";
            case "Wow": return "3";
            case "Sad": return "7";
            case "Angry": return "8";
            default: return "1"; // Like
        }
    }

    /// <summary>
    /// Case-insensitive property extraction from JObject.
    /// </summary>
    private static string GetString(JObject obj, string key, string defaultValue = "")
    {
        if (obj == null) return defaultValue;
        if (obj.TryGetValue(key, StringComparison.OrdinalIgnoreCase, out JToken token))
        {
            return token?.ToString() ?? defaultValue;
        }
        return defaultValue;
    }

    /// <summary>
    /// Case-insensitive integer extraction from JObject.
    /// </summary>
    private static int GetInt(JObject obj, string key, int defaultValue = 0)
    {
        if (obj == null) return defaultValue;
        if (obj.TryGetValue(key, StringComparison.OrdinalIgnoreCase, out JToken token))
        {
            if (int.TryParse(token?.ToString(), out int val))
                return val;
        }
        return defaultValue;
    }

    #region Livestream Actions Comet 2026

    /// <summary>
    /// Kịch bản tương tác Livestream Comet 2026 (Live Chatbox, Floating Reactions, Watch timer).
    /// </summary>
    public static bool InteractLivestreamV2(
        Chrome chrome,
        string liveUrlOrId,
        int watchDurationSec,
        List<string> reactions,
        List<string> comments,
        Action<string> logCallback = null)
    {
        return PersonalInteractionHelper.InteractLivestreamV2(chrome, liveUrlOrId, watchDurationSec, reactions, comments, logCallback);
    }

    private static string ExecuteLivestreamAction(Chrome chrome, JObject param)
    {
        try
        {
            string url = GetString(param, "url", GetString(param, "liveUrlOrId", GetString(param, "link", "")));
            int duration = GetInt(param, "watchDurationSec", GetInt(param, "duration", GetInt(param, "time", 30)));

            List<string> reactions = new List<string>();
            var rVal = param["reactions"];
            if (rVal != null)
            {
                if (rVal is JArray jarr) reactions = jarr.Select(x => x.ToString()).ToList();
                else reactions = rVal.ToString().Split(new[] { '|', ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            }

            List<string> comments = new List<string>();
            var cVal = param["comments"];
            if (cVal != null)
            {
                if (cVal is JArray jarr) comments = jarr.Select(x => x.ToString()).ToList();
                else comments = cVal.ToString().Split(new[] { '\r', '\n', '|' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            }

            bool ok = InteractLivestreamV2(chrome, url, duration, reactions, comments, null);
            return ResultJson(ok, ok ? "Livestream interaction completed successfully" : "Livestream interaction failed");
        }
        catch (Exception ex)
        {
            return ResultJson(false, "Livestream error: " + ex.Message);
        }
    }

    #endregion

    #region Friend Automation Comet 2026 Actions (FacebookFriendAutomationHelper)

    public static int CancelPendingSentRequests(
        Chrome chrome,
        int maxCancelCount = 50,
        int delayMinSec = 1,
        int delayMaxSec = 3,
        Action<string> logCallback = null)
    {
        return FacebookFriendAutomationHelper.CancelPendingSentRequests(chrome, maxCancelCount, delayMinSec, delayMaxSec, logCallback);
    }

    public static int UnfriendInactiveAccounts(
        Chrome chrome,
        List<string> deadFriendUids,
        int maxUnfriendCount = 30,
        Action<string> logCallback = null)
    {
        return FacebookFriendAutomationHelper.UnfriendInactiveAccounts(chrome, deadFriendUids, maxUnfriendCount, logCallback);
    }

    public static int FilterAndUnfriendInactive(
        Chrome chrome,
        int maxCheckCount = 100,
        int maxUnfriendCount = 30,
        Action<string> logCallback = null)
    {
        return FacebookFriendAutomationHelper.FilterAndUnfriendInactive(chrome, maxCheckCount, maxUnfriendCount, logCallback);
    }

    #endregion

    #endregion
}
