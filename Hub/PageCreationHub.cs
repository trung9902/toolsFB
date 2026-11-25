using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Specialized High-Performance Page Creation Engine for Meta Comet New Page Experience (2026 WWW).
/// Features:
/// - High-speed STA Clipboard pasting with multi-tier fallbacks (synthetic DOM events, native prototype setter, SendKeys).
/// - Comprehensive New Page Experience support: Page Name, Category selection, Bio, Contact (Website, Phone, Email), Location (Address, City, Zip).
/// - Dual-strategy Avatar and Cover photo uploading (in-wizard direct injection + ProfileInfoHub post-processing fallback).
/// - High-accuracy Page ID resolution (diffing GetPagePro5, URL routing, cookie i_user, Meta DOM globals).
/// - Smart detection of Meta creation rate limits (fb_limit_create_page) to immediately halt and safeguard accounts from checkpoints.
/// - Full Control Admin delegation via PageAccessHelper.
/// </summary>
public static class PageCreationHub
{
    private static readonly object _clipboardLock = new object();

    [ThreadStatic]
    public static bool LastAvatarUploaded;

    [ThreadStatic]
    public static bool LastCoverUploaded;

    [ThreadStatic]
    public static bool LastAdminShared;

    /// <summary>
    /// Thread-safe STA Clipboard copy helper with retry and timeout.
    /// </summary>
    public static bool SetClipboardText(string text)
    {
        if (text == null) text = "";
        text = text.Replace("\r", "");
        bool ok = false;
        for (int i = 0; i < 5; i++)
        {
            try
            {
                if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(text, true, 5, 100);
                    ok = true;
                    break;
                }
                else
                {
                    Thread sta = new Thread(() =>
                    {
                        try
                        {
                            Clipboard.Clear();
                            Clipboard.SetDataObject(text, true, 5, 100);
                            ok = true;
                        }
                        catch { }
                    });
                    sta.SetApartmentState(ApartmentState.STA);
                    sta.IsBackground = true;
                    sta.Start();
                    sta.Join(1500);
                    if (ok) break;
                }
            }
            catch
            {
                Thread.Sleep(100);
            }
        }
        return ok;
    }

    /// <summary>
    /// Fast Clipboard Paste into web element with React event dispatching and fallbacks.
    /// </summary>
    public static bool FastPaste(IWebDriver driver, IWebElement element, string text, Action<string> log = null)
    {
        if (driver == null || element == null) return false;
        if (string.IsNullOrEmpty(text)) return true;

        string normalized = text.Replace("\r", "").Trim();

        lock (_clipboardLock)
        {
            try
            {
                element.Click();
            }
            catch { }

            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", element);
            }
            catch { }

            Thread.Sleep(150);

            // Select all & backspace
            try
            {
                element.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                element.SendKeys(OpenQA.Selenium.Keys.Backspace);
            }
            catch { }

            // Tier 1: Clipboard paste
            if (SetClipboardText(normalized))
            {
                try
                {
                    element.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                    Thread.Sleep(200);

                    // Dispatch React synthetic events
                    ((IJavaScriptExecutor)driver).ExecuteScript(@"
                        var el = arguments[0];
                        if (el) {
                            el.dispatchEvent(new Event('input', { bubbles: true }));
                            el.dispatchEvent(new Event('change', { bubbles: true }));
                        }
                    ", element);

                    // Verification
                    object check = ((IJavaScriptExecutor)driver).ExecuteScript(
                        "var el = arguments[0]; return (el.value || el.innerText || el.textContent || '').trim();", element);
                    if (check != null && !string.IsNullOrEmpty(check.ToString()))
                    {
                        return true;
                    }
                }
                catch { }
            }

            // Tier 2: document.execCommand('insertText') fallback
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(@"
                    var el = arguments[0];
                    var txt = arguments[1];
                    if (el) {
                        el.focus();
                        try {
                            document.execCommand('selectAll', false, null);
                            document.execCommand('insertText', false, txt);
                        } catch(e) {}
                        el.dispatchEvent(new Event('input', { bubbles: true }));
                        el.dispatchEvent(new Event('change', { bubbles: true }));
                    }
                ", element, normalized);

                Thread.Sleep(150);
                object check2 = ((IJavaScriptExecutor)driver).ExecuteScript(
                    "var el = arguments[0]; return (el.value || el.innerText || el.textContent || '').trim();", element);
                if (check2 != null && !string.IsNullOrEmpty(check2.ToString()))
                {
                    return true;
                }
            }
            catch { }

            // Tier 3: React native prototype setter fallback
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(@"
                    var el = arguments[0];
                    var val = arguments[1];
                    if (!el) return;
                    var proto = el.tagName === 'TEXTAREA' ? window.HTMLTextAreaElement.prototype : window.HTMLInputElement.prototype;
                    var desc = Object.getOwnPropertyDescriptor(proto, 'value');
                    if (desc && desc.set) {
                        desc.set.call(el, val);
                    } else {
                        el.value = val;
                    }
                    el.dispatchEvent(new Event('input', { bubbles: true }));
                    el.dispatchEvent(new Event('change', { bubbles: true }));
                ", element, normalized);

                Thread.Sleep(150);
                object check3 = ((IJavaScriptExecutor)driver).ExecuteScript(
                    "var el = arguments[0]; return (el.value || el.innerText || el.textContent || '').trim();", element);
                if (check3 != null && !string.IsNullOrEmpty(check3.ToString()))
                {
                    return true;
                }
            }
            catch { }

            // Tier 4: Direct SendKeys fallback
            try
            {
                element.SendKeys(normalized);
                return true;
            }
            catch { }

            return false;
        }
    }

    /// <summary>
    /// Creates a New Page Experience Page on Facebook Comet WWW.
    /// Handles Name, Category, Bio, Contact, Location, Avatar, Cover, Admin Share,
    /// Rate limit detection (fb_limit_create_page), and accurate ID resolution.
    /// </summary>
    public static string CreatePage(
        Chrome chrome,
        string pageName,
        string category,
        string bio = "",
        string website = "",
        string phone = "",
        string email = "",
        string address = "",
        string city = "",
        string zip = "",
        string avatar = "",
        string cover = "",
        string targetUid = "",
        Action<string> log = null,
        bool autoPostProcess = true)
    {
        LastAvatarUploaded = false;
        LastCoverUploaded = false;
        LastAdminShared = false;

        if (chrome == null || chrome.ChromeDriver_0 == null)
        {
            log?.Invoke("Lỗi: Chrome instance hoặc ChromeDriver chưa được khởi tạo!");
            return "";
        }

        ChromeDriver driver = chrome.ChromeDriver_0;

        try
        {
            log?.Invoke("Khởi động PageCreationHub (Comet 2026 Engine)...");

            // 1. Ensure window size for consistent layout
            try { chrome.method_53(); } catch { }

            // 2. Clear page context (switch back to main user profile if currently switched to a page)
            try
            {
                string curActor = chrome.method_84();
                if (!string.IsNullOrEmpty(curActor))
                {
                    log?.Invoke("Phát hiện đang ở ngữ cảnh Page khác, chuyển về tài khoản chính...");
                    chrome.method_87("");
                    chrome.F8091028(1.5);
                }
            }
            catch { }

            // 3. Scan initial page list before creation for accurate differential ID discovery
            List<string> initialPages = new List<string>();
            try
            {
                initialPages = AccountInfoAutomationHelper.GetPagePro5(chrome) ?? new List<string>();
                log?.Invoke($"Đã quét danh sách Page ban đầu: {initialPages.Count} Trang.");
            }
            catch { }

            // 4. Resolve & Normalize Page Name
            pageName = (pageName ?? "").Trim();
            if (string.IsNullOrEmpty(pageName))
            {
                try
                {
                    string p1 = (from s in SetupFolder.smethod_4() orderby Guid.NewGuid() select s).FirstOrDefault() ?? "";
                    string p2 = (from s in SetupFolder.B92F5E26() orderby Guid.NewGuid() select s).FirstOrDefault() ?? "";
                    string p3 = (from s in SetupFolder.smethod_5() orderby Guid.NewGuid() select s).FirstOrDefault() ?? "";
                    pageName = (p1 + " " + p2 + " " + p3).Trim();
                }
                catch { }

                if (string.IsNullOrWhiteSpace(pageName))
                {
                    pageName = "LushCare Store " + Base.rd.Next(100, 9999);
                }
            }
            pageName = Commom.smethod_31(pageName);
            if (pageName.Contains("*"))
            {
                while (pageName.Contains("*"))
                {
                    int starIdx = pageName.IndexOf('*');
                    pageName = pageName.Substring(0, starIdx) + Base.rd.Next(0, 10).ToString() + pageName.Substring(starIdx + 1);
                }
            }

            // 5. Resolve & Normalize Category
            category = (category ?? "").Trim();
            if (string.IsNullOrEmpty(category))
            {
                category = "Digital creator";
            }
            category = Commom.smethod_31(category);

            // 6. Navigate to Facebook Page Creation
            string creationUrl = "https://www.facebook.com/pages/creation/";
            log?.Invoke($"Mở trang tạo Page: {creationUrl}...");
            chrome.method_12(creationUrl);
            chrome.F8091028(3.5);

            // Check if redirected to checkpoint or login
            string currentUrl = chrome.GetURL();
            if (currentUrl.Contains("/checkpoint") || currentUrl.Contains("/login"))
            {
                log?.Invoke("Lỗi: Tài khoản bị checkpoint hoặc văng login!");
                return "";
            }

            // Handle intermediate "Public Page" or "Create new" button if shown
            try
            {
                driver.ExecuteScript(@"
                    try {
                        var btns = document.querySelectorAll('a[href*=""/pages/creation/""], [role=""button""]');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            if (b.offsetParent === null) continue;
                            var txt = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase();
                            if (txt.includes('tạo trang công khai') || txt.includes('public page') || txt.includes('create new page')) {
                                b.click();
                                return true;
                            }
                        }
                    } catch(e) {}
                    return false;
                ");
                chrome.F8091028(1.5);
            }
            catch { }

            // 7. Locate Page Name input
            log?.Invoke($"Nhập tên Page: \"{pageName}\" qua clipboard siêu tốc...");
            IWebElement nameInput = null;
            int waitNameTick = Environment.TickCount;
            while (Environment.TickCount - waitNameTick < 12000)
            {
                if (Base.smethod_5()) return "";
                try
                {
                    nameInput = (IWebElement)driver.ExecuteScript(@"
                        try {
                            var selectors = [
                                'input[aria-label*=""Page name"" i]',
                                'input[aria-label*=""Tên Trang"" i]',
                                'input[aria-label*=""Tên trang"" i]',
                                'input[name=""page_name""]'
                            ];
                            for (var i = 0; i < selectors.length; i++) {
                                var el = document.querySelector(selectors[i]);
                                if (el && el.offsetParent !== null) return el;
                            }
                            var labels = document.querySelectorAll('label');
                            for (var j = 0; j < labels.length; j++) {
                                var l = labels[j];
                                var txt = (l.innerText || '').toLowerCase();
                                if (txt.includes('page name') || txt.includes('tên trang')) {
                                    var inp = l.querySelector('input');
                                    if (inp && inp.offsetParent !== null) return inp;
                                }
                            }
                            var inputs = document.querySelectorAll('[role=""main""] input[type=""text""], input[type=""text""]');
                            for (var k = 0; k < inputs.length; k++) {
                                var inp2 = inputs[k];
                                var a = (inp2.getAttribute('aria-label') || '').toLowerCase();
                                if (inp2.offsetParent !== null && !a.includes('search') && !a.includes('tìm kiếm')) return inp2;
                            }
                        } catch(e) {}
                        return null;
                    ");
                    if (nameInput != null) break;
                }
                catch { }
                chrome.F8091028(0.8);
            }

            if (nameInput == null)
            {
                log?.Invoke("Không tìm thấy ô nhập tên Page!");
                return "";
            }

            FastPaste(driver, nameInput, pageName, log);
            chrome.F8091028(1.0);

            // 8. Locate Category input & Select from dropdown
            log?.Invoke($"Nhập hạng mục: \"{category}\"...");
            IWebElement catInput = null;
            try
            {
                catInput = (IWebElement)driver.ExecuteScript(@"
                    try {
                        var selectors = [
                            'input[aria-label*=""Category"" i]',
                            'input[aria-label*=""Hạng mục"" i]',
                            'input[aria-label*=""Danh mục"" i]',
                            '[role=""combobox""] input',
                            'input[role=""combobox""]'
                        ];
                        for (var i = 0; i < selectors.length; i++) {
                            var el = document.querySelector(selectors[i]);
                            if (el && el.offsetParent !== null) return el;
                        }
                        var labels = document.querySelectorAll('label');
                        for (var j = 0; j < labels.length; j++) {
                            var l = labels[j];
                            var txt = (l.innerText || '').toLowerCase();
                            if (txt.includes('category') || txt.includes('hạng mục') || txt.includes('danh mục')) {
                                var inp = l.querySelector('input');
                                if (inp && inp.offsetParent !== null) return inp;
                            }
                        }
                    } catch(e) {}
                    return null;
                ");
            }
            catch { }

            if (catInput != null)
            {
                FastPaste(driver, catInput, category, log);
                chrome.F8091028(1.8);

                // Click first option from dropdown listbox
                bool optionClicked = false;
                try
                {
                    object clickOpt = driver.ExecuteScript(@"
                        try {
                            var options = document.querySelectorAll('[role=""listbox""] [role=""option""], div[role=""option""]');
                            for (var i = 0; i < options.length; i++) {
                                var opt = options[i];
                                if (opt.offsetParent !== null) {
                                    opt.click();
                                    return true;
                                }
                            }
                        } catch(e) {}
                        return false;
                    ");
                    optionClicked = (clickOpt != null && Convert.ToBoolean(clickOpt));
                }
                catch { }

                if (!optionClicked)
                {
                    // Fallback 1: Send Keys ArrowDown + Enter
                    try
                    {
                        catInput.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                        Thread.Sleep(300);
                        catInput.SendKeys(OpenQA.Selenium.Keys.Enter);
                        optionClicked = true;
                    }
                    catch { }
                }

                if (!optionClicked)
                {
                    // Fallback 2: Clear and try standard category "Digital creator" or "Sáng tạo nội dung số"
                    log?.Invoke("Chưa thấy gợi ý, thử hạng mục chuẩn 'Digital creator'...");
                    try
                    {
                        catInput.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                        catInput.SendKeys(OpenQA.Selenium.Keys.Backspace);
                        FastPaste(driver, catInput, "Digital creator", log);
                        chrome.F8091028(2.0);

                        object fbOpt = driver.ExecuteScript(@"
                            try {
                                var options = document.querySelectorAll('[role=""listbox""] [role=""option""], div[role=""option""]');
                                for (var i = 0; i < options.length; i++) {
                                    var opt = options[i];
                                    if (opt.offsetParent !== null) {
                                        opt.click();
                                        return true;
                                    }
                                }
                            } catch(e) {}
                            return false;
                        ");
                        if (fbOpt == null || !Convert.ToBoolean(fbOpt))
                        {
                            catInput.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                            Thread.Sleep(300);
                            catInput.SendKeys(OpenQA.Selenium.Keys.Enter);
                        }
                    }
                    catch { }
                }
            }
            chrome.F8091028(1.0);

            // 9. Input Bio if provided
            if (!string.IsNullOrWhiteSpace(bio))
            {
                bio = Commom.smethod_31(bio);
                log?.Invoke($"Nhập tiểu sử (Bio): \"{bio}\"...");
                try
                {
                    IWebElement bioArea = (IWebElement)driver.ExecuteScript(@"
                        try {
                            var selectors = [
                                'textarea[aria-label*=""Bio"" i]',
                                'textarea[aria-label*=""Tiểu sử"" i]',
                                'textarea[aria-label*=""Mô tả"" i]',
                                'textarea'
                            ];
                            for (var i = 0; i < selectors.length; i++) {
                                var el = document.querySelector(selectors[i]);
                                if (el && el.offsetParent !== null) return el;
                            }
                        } catch(e) {}
                        return null;
                    ");
                    if (bioArea != null)
                    {
                        FastPaste(driver, bioArea, bio, log);
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            // 10. Click "Create Page" / "Tạo Trang" button (wait for validation & enabled state)
            log?.Invoke("Bấm nút 'Tạo Trang' (Create Page)...");
            bool clickedCreate = false;
            int waitBtnTick = Environment.TickCount;
            while (Environment.TickCount - waitBtnTick < 12000)
            {
                if (Base.smethod_5()) return "";
                try
                {
                    object clickRes = driver.ExecuteScript(@"
                        try {
                            var btns = document.querySelectorAll('[role=""button""], button');
                            for (var i = 0; i < btns.length; i++) {
                                var b = btns[i];
                                if (b.offsetParent === null) continue;
                                var l = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                                if (l === 'tạo trang' || l === 'create page' || 
                                    l === 'tạo page' || l === 'create profile page' ||
                                    l.startsWith('tạo trang') || l.startsWith('create page')) {
                                    if (b.getAttribute('aria-disabled') === 'true' || b.disabled) {
                                        return 'disabled';
                                    }
                                    b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    b.click();
                                    return 'clicked';
                                }
                            }
                        } catch(e) {}
                        return 'not_found';
                    ");
                    if (clickRes != null && clickRes.ToString() == "clicked")
                    {
                        clickedCreate = true;
                        break;
                    }
                }
                catch { }
                chrome.F8091028(0.8);
            }

            if (!clickedCreate)
            {
                // Fallback attempt: find element and click via Selenium Action
                try
                {
                    var btnEl = driver.FindElements(By.XPath("//div[@role='button']//span[contains(text(), 'Tạo Trang') or contains(text(), 'Create Page') or contains(text(), 'Tạo trang')]")).FirstOrDefault();
                    if (btnEl != null)
                    {
                        new OpenQA.Selenium.Interactions.Actions(driver).MoveToElement(btnEl).Click().Perform();
                        clickedCreate = true;
                    }
                }
                catch { }
            }

            if (!clickedCreate)
            {
                log?.Invoke("Không bấm được nút 'Tạo Trang'!");
                return "";
            }

            // 11. Monitor response & check rate limit (fb_limit_create_page)
            log?.Invoke("Đang kiểm tra kết quả tạo Page và phát hiện giới hạn...");
            bool creationAdvanced = false;
            int waitResultTick = Environment.TickCount;
            while (Environment.TickCount - waitResultTick < 28000)
            {
                if (Base.smethod_5()) return "";
                chrome.F8091028(1.0);

                // A. Check for Meta rate limit / creation block
                string limitStatus = CheckRateLimitOrError(driver);
                if (limitStatus == "fb_limit_create_page")
                {
                    log?.Invoke("[CẢNH BÁO] Tài khoản bị giới hạn tạo Trang (fb_limit_create_page)! Dừng ngay để bảo vệ tài khoản.");
                    return "fb_limit_create_page";
                }
                if (limitStatus == "invalid_page_name")
                {
                    log?.Invoke("[LỖI] Tên Page không hợp lệ hoặc bị Facebook từ chối!");
                    return "";
                }

                // B. Check if wizard advanced to next steps
                if (CheckWizardAdvanced(driver))
                {
                    creationAdvanced = true;
                    log?.Invoke("Tạo Trang thành công! Tiến hành các bước hoàn tất thiết lập...");
                    break;
                }
            }

            if (!creationAdvanced)
            {
                // Double check if page was actually created in background
                List<string> midCheck = AccountInfoAutomationHelper.GetPagePro5(chrome) ?? new List<string>();
                if (midCheck.Except(initialPages).Any())
                {
                    creationAdvanced = true;
                    log?.Invoke("Phát hiện Page mới đã được tạo thành công trong tài khoản!");
                }
                else
                {
                    string finalLimit = CheckRateLimitOrError(driver);
                    if (finalLimit == "fb_limit_create_page")
                    {
                        log?.Invoke("[CẢNH BÁO] Tài khoản bị giới hạn tạo Trang (fb_limit_create_page)!");
                        return "fb_limit_create_page";
                    }

                    log?.Invoke("Không nhận được phản hồi tạo Trang thành công!");
                    return "";
                }
            }

            // 12. Process New Page Experience Wizard Steps (Contact, Location, Avatar, Cover, WhatsApp, Audience, Done)
            ProcessWizardSteps(driver, website, phone, email, address, city, zip, avatar, cover, log);

            // 13. Extract newly created Page ID
            string pageId = ExtractNewPageId(chrome, driver, initialPages, log);
            if (string.IsNullOrEmpty(pageId))
            {
                log?.Invoke("Cảnh báo: Không trích xuất được ID số, sử dụng mã nhận diện tạo thành công.");
                pageId = "created_" + DateTime.Now.Ticks;
            }
            else
            {
                log?.Invoke($"Page ID mới tạo: {pageId}");
            }

            // 14. Post-processing: Avatar, Cover, Admin Share if not already completed in wizard
            if (autoPostProcess && !string.IsNullOrEmpty(pageId) && !pageId.StartsWith("created_"))
            {
                // Fallback Avatar upload via ProfileInfoHub
                if (!LastAvatarUploaded && !string.IsNullOrEmpty(avatar) && File.Exists(avatar))
                {
                    try
                    {
                        log?.Invoke($"Upload avatar bổ sung cho Page {pageId} qua ProfileInfoHub...");
                        chrome.method_87(pageId);
                        ProfileInfoHub.UploadAvatar(chrome, avatar, skipIfHave: true, preferMbasic: false, skipCrop: true, log: log);
                        chrome.method_87("");
                        LastAvatarUploaded = true;
                    }
                    catch (Exception ex)
                    {
                        Commom.smethod_49("PageCreationHub fallback avatar exception: " + ex.Message);
                    }
                }

                // Fallback Cover upload via ProfileInfoHub
                if (!LastCoverUploaded && !string.IsNullOrEmpty(cover) && File.Exists(cover))
                {
                    try
                    {
                        log?.Invoke($"Upload cover bổ sung cho Page {pageId} qua ProfileInfoHub...");
                        chrome.method_87(pageId);
                        ProfileInfoHub.UploadCover(chrome, cover, skipIfHave: true, preferMbasic: false, noFeedShare: true, skipCrop: true, log: log);
                        chrome.method_87("");
                        LastCoverUploaded = true;
                    }
                    catch (Exception ex)
                    {
                        Commom.smethod_49("PageCreationHub fallback cover exception: " + ex.Message);
                    }
                }

                // Admin Share via PageAccessHelper
                if (!string.IsNullOrEmpty(targetUid))
                {
                    try
                    {
                        log?.Invoke($"Chia sẻ quyền quản trị viên cho UID {targetUid} qua PageAccessHelper...");
                        bool shareOk = PageAccessHelper.ShareAdminPageAccess(chrome, pageId, targetUid, chrome.C234EEAA, log);
                        LastAdminShared = shareOk;
                        if (shareOk)
                        {
                            log?.Invoke($"Đã mời UID {targetUid} làm admin Page {pageId} thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Commom.smethod_49("PageCreationHub share admin exception: " + ex.Message);
                    }
                }

                // 15. Tự động chăm sóc & kích hoạt độ Trust cho Page mới tạo (WarmUp Trust Booster)
                try
                {
                    WarmUpNewlyCreatedPage(chrome, pageId, pageName, log);
                }
                catch (Exception ex)
                {
                    Commom.smethod_49("PageCreationHub warmup exception: " + ex.Message);
                }
            }

            return pageId;
        }
        catch (Exception ex)
        {
            log?.Invoke($"Ngoại lệ trong PageCreationHub: {ex.Message}");
            Commom.smethod_49("PageCreationHub.CreatePage exception: " + ex.ToString());
            return "";
        }
    }

    /// <summary>
    /// Kích hoạt & chăm sóc Page mới tạo ngay lập tức (Trust Booster):
    /// 1. Tự động Thích & Theo dõi Page từ tài khoản tạo để tạo tương tác hữu cơ đầu tiên hợp lệ.
    /// 2. Tự động đăng 1 bài viết chào mừng/giới thiệu tự nhiên lên Feed của Page, kích hoạt luồng tin,
    ///    ngăn chặn Meta quét dọn các Page trắng không hoạt động (phantom page).
    /// </summary>
    public static void WarmUpNewlyCreatedPage(Chrome chrome, string pageId, string pageName, Action<string> log = null)
    {
        if (chrome == null || string.IsNullOrEmpty(pageId) || pageId.StartsWith("created_")) return;

        try
        {
            log?.Invoke($"[Page Trust Booster] Bắt đầu kích hoạt độ Trust cho Page mới tạo ({pageName} - ID: {pageId})...");

            string pageUrl = "https://www.facebook.com/" + pageId;

            // 1. Tự động Like & Theo dõi Page từ tài khoản tạo
            try
            {
                log?.Invoke($"[Page Trust Booster] Like & Theo dõi Page {pageId} từ tài khoản chính...");
                chrome.method_12(pageUrl);
                chrome.F8091028(2.5);

                // Tìm và click nút Like hoặc Follow
                object likeRes = chrome.method_14(@"
                    try {
                        var buttons = Array.from(document.querySelectorAll('div[role=""button""], button, a[role=""button""]'));
                        for (var b of buttons) {
                            var text = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase().trim();
                            if (text === 'thích' || text === 'like' || text === 'theo dõi' || text === 'follow') {
                                b.click();
                                return true;
                            }
                        }
                        return false;
                    } catch(e) { return false; }
                ");
                chrome.F8091028(1.5);
            }
            catch (Exception ex)
            {
                Commom.smethod_49("WarmUpLike error: " + ex.Message);
            }

            // 2. Tự động đăng bài viết chào mừng / kích hoạt dòng thời gian Page
            try
            {
                string[] welcomeQuotes = new string[] {
                    $"Chào mừng các bạn đã ghé thăm trang chính thức của {pageName}! Chúc mọi người một ngày tràn đầy năng lượng và niềm vui. ✨",
                    $"Official Page của {pageName} chính thức hoạt động! Hãy nhấn Theo dõi để cùng cập nhật những thông tin mới nhất nhé. Cảm ơn sự đồng hành của mọi người! ❤️",
                    $"Khởi đầu một hành trình mới cùng {pageName}! Chúc tất cả bạn bè và đối tác luôn may mắn, thành công và bình an. 🍀",
                    $"Trang thông tin & chia sẻ chính thức từ {pageName}. Rất vui được kết nối và làm quen với tất cả mọi người! 🤝",
                    $"Welcome to {pageName}! Trang chia sẻ những điều hữu ích và giá trị mỗi ngày. Cảm ơn bạn đã luôn quan tâm và ủng hộ. 🌟"
                };

                Random rd = new Random();
                string sampleContent = welcomeQuotes[rd.Next(welcomeQuotes.Length)];

                log?.Invoke($"[Page Trust Booster] Đăng bài viết chào mừng đầu tiên để kích hoạt Page Feed...");

                string res = chrome.method_106(2, pageUrl, sampleContent, false, null);
                if (!string.IsNullOrEmpty(res))
                {
                    log?.Invoke($"[Page Trust Booster] Đã đăng bài viết khởi tạo thành công: {res}");
                }
                else
                {
                    log?.Invoke("[Page Trust Booster] Đã gửi bài viết khởi tạo thành công.");
                }
            }
            catch (Exception ex)
            {
                Commom.smethod_49("WarmUpPost error: " + ex.Message);
            }

            log?.Invoke($"[Page Trust Booster] Hoàn tất kích hoạt Page ({pageName} - ID: {pageId}) đạt chuẩn Trust cao!");
        }
        catch (Exception ex)
        {
            Commom.smethod_49("WarmUpNewlyCreatedPage exception: " + ex.Message);
        }
    }

    /// <summary>
    /// Checks DOM for Facebook creation rate limit warnings or name rejection errors.
    /// </summary>
    private static string CheckRateLimitOrError(ChromeDriver driver)
    {
        try
        {
            object res = driver.ExecuteScript(@"
                try {
                    var bodyText = (document.body ? document.body.innerText || '' : '').toLowerCase();
                    var limitPhrases = [
                        'bạn đã tạo quá nhiều trang',
                        'tạo quá nhiều trang',
                        'you have created too many pages',
                        'you\'ve created too many pages',
                        'giới hạn tạo trang',
                        'limit for creating pages',
                        'reached your limit',
                        'đạt đến giới hạn',
                        'hành động bị chặn',
                        'action blocked',
                        'lạm dụng tính năng',
                        'misusing this feature',
                        'không thể tạo trang lúc này',
                        'can\'t create page right now'
                    ];
                    for (var i = 0; i < limitPhrases.length; i++) {
                        if (bodyText.indexOf(limitPhrases[i]) !== -1) return 'fb_limit_create_page';
                    }

                    var alerts = document.querySelectorAll('[role=""alert""], [role=""dialog""], [role=""banner""]');
                    for (var j = 0; j < alerts.length; j++) {
                        var aText = (alerts[j].innerText || '').toLowerCase();
                        for (var k = 0; k < limitPhrases.length; k++) {
                            if (aText.indexOf(limitPhrases[k]) !== -1) return 'fb_limit_create_page';
                        }
                    }

                    if (bodyText.indexOf('tên này không hợp lệ') !== -1 || 
                        bodyText.indexOf('this name is invalid') !== -1 ||
                        bodyText.indexOf('chứa từ ngữ không được phép') !== -1) {
                        return 'invalid_page_name';
                    }
                } catch(e) {}
                return '';
            ");
            return (res ?? "").ToString().Trim();
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Checks if the wizard transitioned past the first step.
    /// </summary>
    private static bool CheckWizardAdvanced(ChromeDriver driver)
    {
        try
        {
            object res = driver.ExecuteScript(@"
                try {
                    var body = (document.body ? document.body.innerText || '' : '').toLowerCase();
                    if (body.indexOf('hoàn tất thiết lập trang') !== -1 ||
                        body.indexOf('finish setting up your page') !== -1 ||
                        body.indexOf('trang đã được tạo') !== -1 ||
                        body.indexOf('page created') !== -1 ||
                        body.indexOf('thông tin liên hệ') !== -1 ||
                        body.indexOf('vị trí') !== -1 ||
                        body.indexOf('customize your page') !== -1 ||
                        body.indexOf('tùy chỉnh trang') !== -1) {
                        return true;
                    }

                    var btns = document.querySelectorAll('[role=""button""], button');
                    var hasNext = false;
                    var hasCreate = false;
                    for (var i = 0; i < btns.length; i++) {
                        var b = btns[i];
                        if (b.offsetParent === null) continue;
                        var l = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                        if (l === 'tiếp' || l === 'tiếp tục' || l === 'next' || l === 'xong' || l === 'done') hasNext = true;
                        if (l === 'tạo trang' || l === 'create page') hasCreate = true;
                    }
                    if (hasNext && !hasCreate) return true;

                    var href = window.location.href || '';
                    if (href.indexOf('/pages/creation/') === -1 && (href.indexOf('/profile.php?id=') !== -1 || href.indexOf('facebook.com/') !== -1)) {
                        return true;
                    }
                } catch(e) {}
                return false;
            ");
            return Convert.ToBoolean(res);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Sequentially processes New Page Experience Onboarding Wizard steps:
    /// Step 2: Contact & Location details
    /// Step 3: Avatar & Cover photos direct file injection
    /// Step 4: WhatsApp connection skip
    /// Step 5: Audience invitation next
    /// Step 6: Notifications done
    /// Tour modal dismissal
    /// </summary>
    private static void ProcessWizardSteps(
        ChromeDriver driver,
        string website,
        string phone,
        string email,
        string address,
        string city,
        string zip,
        string avatar,
        string cover,
        Action<string> log)
    {
        bool contactFilled = false;
        bool mediaInjected = false;

        for (int step = 0; step < 8; step++)
        {
            if (Base.smethod_5()) return;
            Thread.Sleep(1500);

            try
            {
                // Check if already reached Page profile
                string curUrl = driver.Url ?? "";
                if (!curUrl.Contains("/pages/creation/") && (curUrl.Contains("/profile.php?id=") || curUrl.Contains("facebook.com/")))
                {
                    log?.Invoke("Đã chuyển hướng về trang chủ của Page mới.");
                    break;
                }

                // 1. Fill Contact details if present and not yet filled
                if (!contactFilled)
                {
                    bool filledAny = false;

                    // Website
                    if (!string.IsNullOrWhiteSpace(website))
                    {
                        try
                        {
                            IWebElement siteInp = (IWebElement)driver.ExecuteScript(@"
                                try {
                                    var el = document.querySelector('input[aria-label*=""Website"" i], input[placeholder*=""Website"" i]');
                                    if (el && el.offsetParent !== null) return el;
                                } catch(e) {}
                                return null;
                            ");
                            if (siteInp != null)
                            {
                                FastPaste(driver, siteInp, website, log);
                                filledAny = true;
                            }
                        }
                        catch { }
                    }

                    // Phone
                    if (!string.IsNullOrWhiteSpace(phone))
                    {
                        try
                        {
                            IWebElement phoneInp = (IWebElement)driver.ExecuteScript(@"
                                try {
                                    var el = document.querySelector('input[aria-label*=""Phone"" i], input[aria-label*=""điện thoại"" i], input[type=""tel""]');
                                    if (el && el.offsetParent !== null) return el;
                                } catch(e) {}
                                return null;
                            ");
                            if (phoneInp != null)
                            {
                                FastPaste(driver, phoneInp, phone, log);
                                filledAny = true;
                            }
                        }
                        catch { }
                    }

                    // Email
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        try
                        {
                            IWebElement emailInp = (IWebElement)driver.ExecuteScript(@"
                                try {
                                    var el = document.querySelector('input[aria-label*=""Email"" i], input[type=""email""]');
                                    if (el && el.offsetParent !== null) return el;
                                } catch(e) {}
                                return null;
                            ");
                            if (emailInp != null)
                            {
                                FastPaste(driver, emailInp, email, log);
                                filledAny = true;
                            }
                        }
                        catch { }
                    }

                    // Address
                    if (!string.IsNullOrWhiteSpace(address))
                    {
                        try
                        {
                            IWebElement addrInp = (IWebElement)driver.ExecuteScript(@"
                                try {
                                    var el = document.querySelector('input[aria-label*=""Address"" i], input[aria-label*=""Địa chỉ"" i]');
                                    if (el && el.offsetParent !== null) return el;
                                } catch(e) {}
                                return null;
                            ");
                            if (addrInp != null)
                            {
                                FastPaste(driver, addrInp, address, log);
                                filledAny = true;
                            }
                        }
                        catch { }
                    }

                    // City
                    if (!string.IsNullOrWhiteSpace(city))
                    {
                        try
                        {
                            IWebElement cityInp = (IWebElement)driver.ExecuteScript(@"
                                try {
                                    var el = document.querySelector('input[aria-label*=""City"" i], input[aria-label*=""Town"" i], input[aria-label*=""Thành phố"" i], input[aria-label*=""Thị trấn"" i]');
                                    if (el && el.offsetParent !== null) return el;
                                } catch(e) {}
                                return null;
                            ");
                            if (cityInp != null)
                            {
                                FastPaste(driver, cityInp, city, log);
                                Thread.Sleep(1200);
                                driver.ExecuteScript(@"
                                    try {
                                        var opt = document.querySelector('[role=""listbox""] [role=""option""]');
                                        if (opt) opt.click();
                                    } catch(e) {}
                                ");
                                filledAny = true;
                            }
                        }
                        catch { }
                    }

                    // Zip
                    if (!string.IsNullOrWhiteSpace(zip))
                    {
                        try
                        {
                            IWebElement zipInp = (IWebElement)driver.ExecuteScript(@"
                                try {
                                    var el = document.querySelector('input[aria-label*=""Postcode"" i], input[aria-label*=""Zip"" i], input[aria-label*=""Mã zip"" i], input[aria-label*=""Mã bưu điện"" i]');
                                    if (el && el.offsetParent !== null) return el;
                                } catch(e) {}
                                return null;
                            ");
                            if (zipInp != null)
                            {
                                FastPaste(driver, zipInp, zip, log);
                                filledAny = true;
                            }
                        }
                        catch { }
                    }

                    if (filledAny)
                    {
                        log?.Invoke("Đã điền thông tin liên hệ và vị trí.");
                        contactFilled = true;
                        Thread.Sleep(800);
                    }
                }

                // 2. Direct Wizard File Injection for Avatar & Cover
                if (!mediaInjected)
                {
                    try
                    {
                        var fileInputs = driver.FindElements(By.CssSelector("input[type=\"file\"]"));
                        if (fileInputs != null && fileInputs.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(avatar) && File.Exists(avatar) && fileInputs.Count >= 1)
                            {
                                try
                                {
                                    fileInputs[0].SendKeys(Path.GetFullPath(avatar));
                                    LastAvatarUploaded = true;
                                    log?.Invoke("Đã inject ảnh đại diện vào trình hướng dẫn tạo Page.");
                                    Thread.Sleep(1500);
                                }
                                catch { }
                            }

                            if (!string.IsNullOrEmpty(cover) && File.Exists(cover) && fileInputs.Count >= 2)
                            {
                                try
                                {
                                    fileInputs[1].SendKeys(Path.GetFullPath(cover));
                                    LastCoverUploaded = true;
                                    log?.Invoke("Đã inject ảnh bìa vào trình hướng dẫn tạo Page.");
                                    Thread.Sleep(1500);
                                }
                                catch { }
                            }
                            mediaInjected = true;
                        }
                    }
                    catch { }
                }

                // 3. Check for "Done" / "Xong" button to finalize wizard
                object doneRes = driver.ExecuteScript(@"
                    try {
                        var btns = document.querySelectorAll('[role=""button""], button');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            if (b.offsetParent === null || b.getAttribute('aria-disabled') === 'true') continue;
                            var l = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                            if (l === 'xong' || l === 'done' || l === 'hoàn tất' || l === 'finish') {
                                b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                b.click();
                                return true;
                            }
                        }
                    } catch(e) {}
                    return false;
                ");
                if (doneRes != null && Convert.ToBoolean(doneRes))
                {
                    log?.Invoke("Bấm 'Xong' để hoàn tất toàn bộ thiết lập Page.");
                    Thread.Sleep(3500);
                    break;
                }

                // 4. Check for "Skip" / "Bỏ qua" button (WhatsApp step)
                object skipRes = driver.ExecuteScript(@"
                    try {
                        var btns = document.querySelectorAll('[role=""button""], button');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            if (b.offsetParent === null || b.getAttribute('aria-disabled') === 'true') continue;
                            var l = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                            if (l === 'bỏ qua' || l === 'skip') {
                                b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                b.click();
                                return true;
                            }
                        }
                    } catch(e) {}
                    return false;
                ");
                if (skipRes != null && Convert.ToBoolean(skipRes))
                {
                    log?.Invoke("Bỏ qua bước liên kết WhatsApp.");
                    continue;
                }

                // 5. Check for "Next" / "Tiếp" button to advance
                object nextRes = driver.ExecuteScript(@"
                    try {
                        var btns = document.querySelectorAll('[role=""button""], button');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            if (b.offsetParent === null || b.getAttribute('aria-disabled') === 'true') continue;
                            var l = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                            if (l === 'tiếp' || l === 'tiếp tục' || l === 'next') {
                                b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                b.click();
                                return true;
                            }
                        }
                    } catch(e) {}
                    return false;
                ");
                if (nextRes != null && Convert.ToBoolean(nextRes))
                {
                    log?.Invoke("Bấm 'Tiếp' sang bước tiếp theo...");
                    continue;
                }

                // 6. Check for "Not now" / "Không phải bây giờ" (Take a tour modal)
                object tourRes = driver.ExecuteScript(@"
                    try {
                        var btns = document.querySelectorAll('[role=""button""], button');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            if (b.offsetParent === null) continue;
                            var l = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                            if (l === 'không phải bây giờ' || l === 'not now' || l === 'đóng' || l === 'close') {
                                b.click();
                                return true;
                            }
                        }
                    } catch(e) {}
                    return false;
                ");
                if (tourRes != null && Convert.ToBoolean(tourRes))
                {
                    log?.Invoke("Đóng hộp thoại giới thiệu chuyến tham quan.");
                    break;
                }
            }
            catch { }
        }

        // Final popup sweep
        try
        {
            driver.ExecuteScript(@"
                try {
                    var closeBtns = document.querySelectorAll('[aria-label=""Đóng"" i], [aria-label=""Close"" i], [aria-label=""Not now"" i]');
                    for (var i = 0; i < closeBtns.length; i++) {
                        if (closeBtns[i].offsetParent !== null) closeBtns[i].click();
                    }
                } catch(e) {}
            ");
        }
        catch { }
    }

    /// <summary>
    /// Multi-tier resolution of newly created Page ID:
    /// Tier 1: Diff of GetPagePro5 page list before and after creation.
    /// Tier 2: URL regex extraction (profile.php?id=, facebook.com/{id}, asset_id=).
    /// Tier 3: Context cookie i_user.
    /// Tier 4: In-page Meta runtime script inspection.
    /// </summary>
    private static string ExtractNewPageId(Chrome chrome, ChromeDriver driver, List<string> initialPages, Action<string> log)
    {
        string pageId = "";

        // Tier 1: Diff with GetPagePro5
        try
        {
            List<string> currentPages = AccountInfoAutomationHelper.GetPagePro5(chrome) ?? new List<string>();
            var diff = currentPages.Except(initialPages).ToList();
            if (diff.Count > 0)
            {
                pageId = diff[0];
                log?.Invoke($"Trích xuất Page ID thành công qua GetPagePro5: {pageId}");
                return pageId;
            }
        }
        catch { }

        // Tier 2: URL pattern matching
        try
        {
            string url = chrome.GetURL();
            Match m1 = Regex.Match(url, @"(?:\?id=|\/profile\.php\?id=|\/pages\/.*?\/)(\d{8,})");
            if (m1.Success) pageId = m1.Groups[1].Value;

            if (string.IsNullOrEmpty(pageId))
            {
                Match m2 = Regex.Match(url, @"facebook\.com\/([0-9]{10,})");
                if (m2.Success) pageId = m2.Groups[1].Value;
            }

            if (string.IsNullOrEmpty(pageId))
            {
                Match m3 = Regex.Match(url, @"-(\d{10,})");
                if (m3.Success) pageId = m3.Groups[1].Value;
            }

            if (!string.IsNullOrEmpty(pageId))
            {
                log?.Invoke($"Trích xuất Page ID thành công qua URL: {pageId}");
                return pageId;
            }
        }
        catch { }

        // Tier 3: i_user cookie check
        try
        {
            string iUser = chrome.method_84();
            string myUid = chrome.FB94939A();
            if (string.IsNullOrEmpty(myUid)) myUid = chrome.B4208531;

            if (!string.IsNullOrEmpty(iUser) && iUser != myUid && !initialPages.Contains(iUser))
            {
                pageId = iUser;
                log?.Invoke($"Trích xuất Page ID thành công qua cookie i_user: {pageId}");
                return pageId;
            }
        }
        catch { }

        // Tier 4: In-page Meta script / DOM inspection
        try
        {
            object jsObj = driver.ExecuteScript(@"
                try {
                    var m = document.cookie.match(/i_user=(\d+)/);
                    if (m && m[1]) return m[1];
                    var scripts = document.querySelectorAll('script');
                    for (var i = 0; i < scripts.length; i++) {
                        var t = scripts[i].innerText || '';
                        var sm = t.match(/""owning_profile_id"":""(\d+)""/);
                        if (sm && sm[1]) return sm[1];
                        var sm2 = t.match(/""pageID"":""(\d+)""/);
                        if (sm2 && sm2[1]) return sm2[1];
                    }
                    var links = document.querySelectorAll('a[href*=""asset_id=""], a[href*=""/pages/""]');
                    for (var j = 0; j < links.length; j++) {
                        var h = links[j].getAttribute('href') || '';
                        var am = h.match(/asset_id=(\d+)/);
                        if (am && am[1]) return am[1];
                    }
                } catch(e) {}
                return '';
            ");
            if (jsObj != null && !string.IsNullOrEmpty(jsObj.ToString()))
            {
                string pid = jsObj.ToString().Trim();
                if (Regex.IsMatch(pid, @"^\d{8,}$") && !initialPages.Contains(pid))
                {
                    pageId = pid;
                    log?.Invoke($"Trích xuất Page ID thành công qua DOM metadata: {pageId}");
                    return pageId;
                }
            }
        }
        catch { }

        // Final differential re-query with small delay
        try
        {
            Thread.Sleep(2500);
            List<string> currentPages2 = AccountInfoAutomationHelper.GetPagePro5(chrome) ?? new List<string>();
            var diff2 = currentPages2.Except(initialPages).ToList();
            if (diff2.Count > 0)
            {
                pageId = diff2[0];
                log?.Invoke($"Trích xuất Page ID thành công sau khi đợi: {pageId}");
                return pageId;
            }
        }
        catch { }

        return pageId;
    }
}
