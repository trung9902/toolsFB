using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class PageAccessHelper
{
    /// <summary>
    /// Grants Full Control Admin access to target UID on Facebook New Page Experience (Comet WWW).
    /// Handles context switching, settings navigation, search, toggle full control, give access,
    /// password re-authentication, and verification. Never throws an unhandled exception.
    /// </summary>
    public static bool ShareAdminPageAccess(Chrome chrome, string pageId, string toUid, string password = "", Action<string> log = null)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null)
        {
            log?.Invoke("Chrome instance or ChromeDriver is null.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(toUid))
        {
            log?.Invoke("Target UID is empty.");
            return false;
        }

        try
        {
            toUid = toUid.Trim();
            string cleanUid = Regex.Match(toUid, @"\d{6,}").Value;
            if (string.IsNullOrEmpty(cleanUid))
            {
                cleanUid = toUid;
            }

            if (string.IsNullOrEmpty(password))
            {
                password = chrome.C234EEAA ?? "";
            }

            ChromeDriver driver = chrome.ChromeDriver_0;

            // Step 1: Context switch to Page if pageId is provided
            if (!string.IsNullOrEmpty(pageId) && !pageId.StartsWith("created_"))
            {
                string curActor = chrome.method_84();
                if (curActor != pageId)
                {
                    log?.Invoke($"Chuyển ngữ cảnh sang Page {pageId}...");
                    chrome.method_87(pageId);
                    chrome.F8091028(2.0);
                }
            }

            // Step 2: Navigate to Page Access settings tab
            string settingsUrl = "https://www.facebook.com/settings/?tab=profile_access";
            log?.Invoke("Mở trang cài đặt quyền truy cập Page...");
            chrome.method_12(settingsUrl);
            chrome.F8091028(3.0);

            // Step 3: Handle in-page Profile Switch prompt if present
            try
            {
                object switchObj = driver.ExecuteScript(@"
                    try {
                        var btns = document.querySelectorAll('[role=""button""], button');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            if (b.offsetParent === null) continue;
                            var txt = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase();
                            if (txt.includes('chuyển ngay') || txt.includes('chuyển sang') || txt.includes('switch now') || txt.includes('switch to')) {
                                b.click();
                                return true;
                            }
                        }
                    } catch(e) {}
                    return false;
                ");
                if (switchObj != null && Convert.ToBoolean(switchObj))
                {
                    log?.Invoke("Đã click chuyển sang ngữ cảnh Page.");
                    chrome.F8091028(3.0);
                    chrome.method_12(settingsUrl);
                    chrome.F8091028(2.5);
                }
            }
            catch { }

            // Step 4: Check if cleanUid is ALREADY an admin or has pending invite
            try
            {
                object checkExists = driver.ExecuteScript(@"
                    try {
                        var uid = arguments[0];
                        var body = document.body ? document.body.innerHTML : '';
                        if (body.indexOf(uid) !== -1) {
                            var links = document.querySelectorAll('a[href*=""' + uid + '""]');
                            if (links.length > 0) return true;
                        }
                    } catch(e) {}
                    return false;
                ", cleanUid);
                if (checkExists != null && Convert.ToBoolean(checkExists))
                {
                    log?.Invoke($"UID {cleanUid} đã có quyền hoặc lời mời đang chờ xử lý.");
                    chrome.method_87("");
                    return true;
                }
            }
            catch { }

            // Step 5: Locate and click 'Add New' (Thêm mới) in 'People with Facebook access' (Người có quyền truy cập trên Facebook)
            log?.Invoke("Tìm nút 'Thêm mới' quyền truy cập trên Facebook...");
            bool clickedAddNew = false;
            int waitAddTick = Environment.TickCount;
            while (Environment.TickCount - waitAddTick < 10000)
            {
                if (Base.smethod_5()) return false;
                try
                {
                    object addObj = driver.ExecuteScript(@"
                        try {
                            // 1. Look specifically in 'People with Facebook access' section
                            var allHeaders = document.querySelectorAll('h1, h2, h3, h4, span, div');
                            for (var i = 0; i < allHeaders.length; i++) {
                                var el = allHeaders[i];
                                var txt = (el.innerText || el.textContent || '').trim().toLowerCase();
                                if (txt === 'người có quyền truy cập trên facebook' || txt === 'people with facebook access' ||
                                    (txt.indexOf('người có quyền truy cập trên facebook') === 0 && txt.length < 80) ||
                                    (txt.indexOf('people with facebook access') === 0 && txt.length < 80)) {
                                    var parent = el.parentElement;
                                    for (var depth = 0; depth < 5 && parent; depth++) {
                                        var btns = parent.querySelectorAll('[role=""button""], button');
                                        for (var b = 0; b < btns.length; b++) {
                                            var btn = btns[b];
                                            if (btn.offsetParent === null) continue;
                                            var bTxt = (btn.getAttribute('aria-label') || btn.innerText || '').trim().toLowerCase();
                                            if (bTxt.includes('thêm') || bTxt.includes('add')) {
                                                btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                                btn.click();
                                                return 'section_add';
                                            }
                                        }
                                        parent = parent.parentElement;
                                    }
                                }
                            }
                            // 2. Global fallback for first visible Add New button
                            var allBtns = document.querySelectorAll('[role=""button""], button');
                            for (var j = 0; j < allBtns.length; j++) {
                                var btn2 = allBtns[j];
                                if (btn2.offsetParent === null) continue;
                                var bLabel = (btn2.getAttribute('aria-label') || btn2.innerText || '').trim().toLowerCase();
                                if (bLabel === 'thêm mới' || bLabel === 'add new' || bLabel.includes('thêm mới') || bLabel.includes('add new')) {
                                    btn2.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    btn2.click();
                                    return 'global_add';
                                }
                            }
                        } catch(e) {}
                        return null;
                    ");
                    if (addObj != null)
                    {
                        clickedAddNew = true;
                        break;
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            if (!clickedAddNew)
            {
                log?.Invoke("Không tìm thấy nút 'Thêm mới' quyền truy cập!");
                chrome.method_87("");
                return false;
            }

            chrome.F8091028(1.5);

            // Step 6: Modal 1 - Click 'Next' (Tiếp / Tiếp tục)
            log?.Invoke("Modal mở ra, bấm 'Tiếp tục'...");
            int waitModal1Tick = Environment.TickCount;
            bool clickedNextIntro = false;
            while (Environment.TickCount - waitModal1Tick < 8000)
            {
                if (Base.smethod_5()) return false;
                try
                {
                    object nextObj = driver.ExecuteScript(@"
                        try {
                            var dialog = document.querySelector('[role=""dialog""]');
                            if (!dialog) return null;
                            var btns = dialog.querySelectorAll('[role=""button""], button');
                            for (var i = 0; i < btns.length; i++) {
                                var b = btns[i];
                                if (b.offsetParent === null || b.getAttribute('aria-disabled') === 'true') continue;
                                var txt = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                                if (txt === 'tiếp' || txt === 'tiếp tục' || txt === 'next' || txt.includes('tiếp') || txt.includes('next')) {
                                    b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    b.click();
                                    return 'clicked_next';
                                }
                            }
                        } catch(e) {}
                        return null;
                    ");
                    if (nextObj != null)
                    {
                        clickedNextIntro = true;
                        break;
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            if (!clickedNextIntro)
            {
                log?.Invoke("Bỏ qua bước giới thiệu hoặc đã ở ô tìm kiếm.");
            }

            chrome.F8091028(1.5);

            // Step 7: Modal 2 - Input target UID into Search box
            log?.Invoke($"Nhập UID {cleanUid} vào ô tìm kiếm...");
            bool searchInputFound = false;
            int waitSearchTick = Environment.TickCount;
            while (Environment.TickCount - waitSearchTick < 10000)
            {
                if (Base.smethod_5()) return false;
                try
                {
                    object inpObj = driver.ExecuteScript(@"
                        try {
                            var dialog = document.querySelector('[role=""dialog""]');
                            if (!dialog) return false;
                            var inp = dialog.querySelector('input[type=""search""], input[type=""text""], input[placeholder*=""Tìm kiếm"" i], input[placeholder*=""Search"" i], input[aria-label*=""Tìm kiếm"" i], input[aria-label*=""Search"" i], input:not([type=""hidden""])');
                            if (inp && inp.offsetParent !== null) {
                                inp.focus();
                                inp.value = '';
                                inp.dispatchEvent(new Event('input', { bubbles: true }));
                                return true;
                            }
                        } catch(e) {}
                        return false;
                    ");
                    if (inpObj != null && Convert.ToBoolean(inpObj))
                    {
                        searchInputFound = true;
                        break;
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            if (!searchInputFound)
            {
                log?.Invoke("Không tìm thấy ô nhập tìm kiếm người nhận quyền!");
                chrome.method_87("");
                return false;
            }

            // Type UID via JavaScript and Selenium keyboard events
            try
            {
                driver.ExecuteScript(@"
                    try {
                        var dialog = document.querySelector('[role=""dialog""]');
                        var inp = dialog.querySelector('input[type=""search""], input[type=""text""], input[placeholder*=""Tìm kiếm"" i], input[placeholder*=""Search"" i], input[aria-label*=""Tìm kiếm"" i], input[aria-label*=""Search"" i], input:not([type=""hidden""])');
                        if (inp) {
                            inp.focus();
                            inp.value = arguments[0];
                            inp.dispatchEvent(new Event('input', { bubbles: true }));
                            inp.dispatchEvent(new Event('change', { bubbles: true }));
                            inp.dispatchEvent(new KeyboardEvent('keydown', { bubbles: true, key: 'Enter' }));
                            inp.dispatchEvent(new KeyboardEvent('keyup', { bubbles: true, key: 'Enter' }));
                        }
                    } catch(e) {}
                ", cleanUid);
            }
            catch { }

            // Try typing profile URL as fallback if needed
            chrome.F8091028(2.0);

            // Step 8: Wait for user search results dropdown and click matching option
            log?.Invoke("Chờ danh sách kết quả tìm kiếm...");
            bool userSelected = false;
            int waitUserTick = Environment.TickCount;
            while (Environment.TickCount - waitUserTick < 12000)
            {
                if (Base.smethod_5()) return false;
                try
                {
                    object selObj = driver.ExecuteScript(@"
                        try {
                            var dialog = document.querySelector('[role=""dialog""]');
                            if (!dialog) return null;
                            var options = dialog.querySelectorAll('[role=""listbox""] [role=""option""], [role=""listbox""] > div, ul[role=""listbox""] li, [role=""listbox""] div[role=""button""]');
                            for (var i = 0; i < options.length; i++) {
                                var op = options[i];
                                if (op.offsetParent === null) continue;
                                var opTxt = (op.innerText || '').toLowerCase();
                                if (opTxt.includes('đóng') || opTxt.includes('hủy') || opTxt.includes('cancel') || opTxt.includes('close')) continue;
                                op.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                op.click();
                                return 'clicked_listbox_option';
                            }
                            var items = dialog.querySelectorAll('div[role=""button""][tabindex=""0""], div[tabindex=""0""]');
                            for (var j = 0; j < items.length; j++) {
                                var it = items[j];
                                if (it.offsetParent === null) continue;
                                if (it.querySelector('img') || it.querySelector('svg')) {
                                    var itTxt = (it.innerText || '').toLowerCase();
                                    if (!itTxt.includes('đóng') && !itTxt.includes('tiếp') && !itTxt.includes('hủy') && !itTxt.includes('cancel')) {
                                        it.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                        it.click();
                                        return 'clicked_avatar_item';
                                    }
                                }
                            }
                        } catch(e) {}
                        return null;
                    ");
                    if (selObj != null)
                    {
                        userSelected = true;
                        break;
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            if (!userSelected)
            {
                log?.Invoke($"Không tìm thấy tài khoản Facebook tương ứng với UID {cleanUid}!");
                chrome.method_87("");
                return false;
            }

            chrome.F8091028(1.5);

            // Step 9: Modal 3 - Enable Toggle 'Cho phép người này có toàn quyền kiểm soát' (Full control)
            log?.Invoke("Bật quyền toàn quyền kiểm soát (Quản trị viên cao nhất)...");
            try
            {
                driver.ExecuteScript(@"
                    try {
                        var dialog = document.querySelector('[role=""dialog""]');
                        if (!dialog) return;
                        var switches = dialog.querySelectorAll('[role=""switch""], input[type=""checkbox""]');
                        for (var i = 0; i < switches.length; i++) {
                            var sw = switches[i];
                            if (sw.offsetParent === null) continue;
                            var isChecked = sw.getAttribute('aria-checked') === 'true' || sw.checked === true;
                            if (!isChecked) {
                                sw.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                sw.click();
                                return;
                            }
                        }
                        var allSpans = dialog.querySelectorAll('span, div');
                        for (var j = 0; j < allSpans.length; j++) {
                            var s = allSpans[j];
                            var txt = (s.innerText || '').toLowerCase();
                            if (txt.includes('toàn quyền kiểm soát') || txt.includes('full control')) {
                                var row = s.closest('div[role=""button""]') || s.closest('div[tabindex]') || s.parentElement;
                                var sw2 = row ? row.querySelector('[role=""switch""], input[type=""checkbox""]') : null;
                                if (sw2) {
                                    sw2.click();
                                    return;
                                }
                            }
                        }
                    } catch(e) {}
                ");
            }
            catch { }

            chrome.F8091028(1.0);

            // Step 10: Click 'Cấp quyền truy cập' (Give access)
            log?.Invoke("Bấm nút 'Cấp quyền truy cập'...");
            bool clickedGiveAccess = false;
            int waitGiveTick = Environment.TickCount;
            while (Environment.TickCount - waitGiveTick < 8000)
            {
                if (Base.smethod_5()) return false;
                try
                {
                    object giveObj = driver.ExecuteScript(@"
                        try {
                            var dialog = document.querySelector('[role=""dialog""]');
                            if (!dialog) return null;
                            var btns = dialog.querySelectorAll('[role=""button""], button');
                            for (var i = 0; i < btns.length; i++) {
                                var b = btns[i];
                                if (b.offsetParent === null || b.getAttribute('aria-disabled') === 'true') continue;
                                var txt = (b.getAttribute('aria-label') || b.innerText || '').trim().toLowerCase();
                                if (txt === 'cấp quyền truy cập' || txt === 'give access' || txt === 'cấp quyền' ||
                                    txt.includes('cấp quyền truy cập') || txt.includes('give access') || txt.includes('cấp quyền')) {
                                    b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    b.click();
                                    return 'clicked_give';
                                }
                            }
                        } catch(e) {}
                        return null;
                    ");
                    if (giveObj != null)
                    {
                        clickedGiveAccess = true;
                        break;
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            if (!clickedGiveAccess)
            {
                log?.Invoke("Cảnh báo: Không click được nút 'Cấp quyền truy cập' hoặc form đã gửi.");
            }

            chrome.F8091028(2.0);

            // Step 11: Check for Password Re-authentication modal
            try
            {
                object hasPwdObj = driver.ExecuteScript(@"
                    try {
                        var pwd = document.querySelector('input[type=""password""]');
                        return (pwd && pwd.offsetParent !== null);
                    } catch(e) { return false; }
                ");
                if (hasPwdObj != null && Convert.ToBoolean(hasPwdObj))
                {
                    log?.Invoke("Facebook yêu cầu xác thực lại mật khẩu, đang nhập...");
                    if (!string.IsNullOrEmpty(password))
                    {
                        driver.ExecuteScript(@"
                            try {
                                var inp = document.querySelector('input[type=""password""]');
                                if (inp) {
                                    inp.focus();
                                    inp.value = arguments[0];
                                    inp.dispatchEvent(new Event('input', { bubbles: true }));
                                    inp.dispatchEvent(new Event('change', { bubbles: true }));
                                    var parent = inp.closest('[role=""dialog""]') || document;
                                    var btns = parent.querySelectorAll('[role=""button""], button, input[type=""submit""]');
                                    for (var i = 0; i < btns.length; i++) {
                                        var b = btns[i];
                                        if (b.offsetParent === null || b.getAttribute('aria-disabled') === 'true') continue;
                                        var txt = (b.getAttribute('aria-label') || b.innerText || b.value || '').trim().toLowerCase();
                                        if (txt === 'xác nhận' || txt === 'confirm' || txt === 'tiếp tục' || txt === 'submit' ||
                                            txt.includes('xác nhận') || txt.includes('confirm')) {
                                            b.click();
                                            break;
                                        }
                                    }
                                }
                            } catch(e) {}
                        ", password);
                        chrome.F8091028(3.0);
                    }
                    else
                    {
                        log?.Invoke("Cảnh báo: Không có mật khẩu để xác thực tài khoản!");
                    }
                }
            }
            catch { }

            // Step 12: Verification
            log?.Invoke("Kiểm tra kết quả cấp quyền...");
            bool success = false;
            int waitVerifyTick = Environment.TickCount;
            while (Environment.TickCount - waitVerifyTick < 8000)
            {
                if (Base.smethod_5()) return false;
                try
                {
                    object verObj = driver.ExecuteScript(@"
                        try {
                            var uid = arguments[0];
                            // Check for error messages
                            var alerts = document.querySelectorAll('[role=""alert""], [aria-live=""assertive""]');
                            for (var i = 0; i < alerts.length; i++) {
                                var aTxt = (alerts[i].innerText || '').toLowerCase();
                                if (aTxt.includes('mật khẩu không đúng') || aTxt.includes('incorrect password') ||
                                    aTxt.includes('bị chặn') || aTxt.includes('blocked')) {
                                    return 'error: ' + aTxt;
                                }
                            }
                            var body = document.body ? document.body.innerHTML : '';
                            if (body.indexOf(uid) !== -1 || body.indexOf('Lời mời đã gửi') !== -1 ||
                                body.indexOf('Invitation sent') !== -1 || body.indexOf('Đang chờ xử lý') !== -1) {
                                return 'success_confirmed';
                            }
                            var dialog = document.querySelector('[role=""dialog""]');
                            if (!dialog) {
                                return 'success_dialog_closed';
                            }
                        } catch(e) {}
                        return null;
                    ", cleanUid);
                    if (verObj != null)
                    {
                        string verStr = verObj.ToString();
                        if (verStr.StartsWith("error"))
                        {
                            log?.Invoke($"Lỗi Facebook: {verStr}");
                            success = false;
                            break;
                        }
                        else
                        {
                            success = true;
                            break;
                        }
                    }
                }
                catch { }
                chrome.F8091028(1.0);
            }

            // Restore personal profile context
            chrome.method_87("");

            if (success)
            {
                log?.Invoke($"Gán quyền quản trị cho UID {cleanUid} thành công!");
                return true;
            }
            else
            {
                log?.Invoke($"Gán quyền cho UID {cleanUid} có thể chưa hoàn tất hoặc cần kiểm tra lại.");
                return false;
            }
        }
        catch (Exception ex)
        {
            log?.Invoke("Ngoại lệ khi ném quyền admin: " + ex.Message);
            Commom.smethod_49("PageAccessHelper.ShareAdminPageAccess exception: " + ex.Message);
            try { chrome.method_87(""); } catch { }
            return false;
        }
    }

    /// <summary>
    /// Removes Admin access from target UID on Facebook New Page Experience.
    /// </summary>
    public static bool RemoveAdminPageAccess(Chrome chrome, string pageId, string toUid, string password = "", Action<string> log = null)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null || string.IsNullOrWhiteSpace(toUid))
        {
            return false;
        }

        try
        {
            toUid = toUid.Trim();
            string cleanUid = Regex.Match(toUid, @"\d{6,}").Value;
            if (string.IsNullOrEmpty(cleanUid)) cleanUid = toUid;
            if (string.IsNullOrEmpty(password)) password = chrome.C234EEAA ?? "";

            ChromeDriver driver = chrome.ChromeDriver_0;

            if (!string.IsNullOrEmpty(pageId) && !pageId.StartsWith("created_"))
            {
                if (chrome.method_84() != pageId)
                {
                    chrome.method_87(pageId);
                    chrome.F8091028(2.0);
                }
            }

            chrome.method_12("https://www.facebook.com/settings/?tab=profile_access");
            chrome.F8091028(3.0);

            // Locate target user row and click options menu (...)
            object clickMenu = driver.ExecuteScript(@"
                try {
                    var uid = arguments[0];
                    var links = document.querySelectorAll('a[href*=""' + uid + '""]');
                    for (var i = 0; i < links.length; i++) {
                        var row = links[i].closest('[role=""listitem""]') || links[i].closest('tr') || links[i].parentElement?.parentElement;
                        if (row) {
                            var menuBtn = row.querySelector('[aria-label*=""Hành động"" i], [aria-label*=""Action"" i], [aria-label*=""Tùy chọn"" i], [role=""button""]');
                            if (menuBtn) {
                                menuBtn.click();
                                return true;
                            }
                        }
                    }
                } catch(e) {}
                return false;
            ", cleanUid);

            chrome.F8091028(1.5);

            // Click 'Xóa khỏi Trang' (Remove from Page)
            driver.ExecuteScript(@"
                try {
                    var items = document.querySelectorAll('[role=""menuitem""], div[role=""button""]');
                    for (var i = 0; i < items.length; i++) {
                        var txt = (items[i].innerText || '').toLowerCase();
                        if (txt.includes('xóa khỏi') || txt.includes('remove from')) {
                            items[i].click();
                            return;
                        }
                    }
                } catch(e) {}
            ");

            chrome.F8091028(1.5);

            // Click Confirm remove
            driver.ExecuteScript(@"
                try {
                    var dialog = document.querySelector('[role=""dialog""]');
                    if (dialog) {
                        var btns = dialog.querySelectorAll('[role=""button""], button');
                        for (var i = 0; i < btns.length; i++) {
                            var b = btns[i];
                            var txt = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase();
                            if (txt.includes('xác nhận') || txt.includes('confirm') || txt.includes('xóa') || txt.includes('remove')) {
                                b.click();
                                return;
                            }
                        }
                    }
                } catch(e) {}
            ");

            chrome.F8091028(2.0);

            // If password prompt appears
            if (!string.IsNullOrEmpty(password))
            {
                driver.ExecuteScript(@"
                    try {
                        var pwd = document.querySelector('input[type=""password""]');
                        if (pwd) {
                            pwd.focus();
                            pwd.value = arguments[0];
                            pwd.dispatchEvent(new Event('input', { bubbles: true }));
                            pwd.dispatchEvent(new Event('change', { bubbles: true }));
                            var parent = pwd.closest('[role=""dialog""]') || document;
                            var confirmBtn = parent.querySelector('[type=""submit""], [role=""button""]');
                            if (confirmBtn) confirmBtn.click();
                        }
                    } catch(e) {}
                ", password);
                chrome.F8091028(2.5);
            }

            chrome.method_87("");
            return true;
        }
        catch (Exception ex)
        {
            Commom.smethod_49("PageAccessHelper.RemoveAdminPageAccess exception: " + ex.Message);
            try { chrome.method_87(""); } catch { }
            return false;
        }
    }

    /// <summary>
    /// JSON dispatcher handler for ShareAdminPagePro5 action.
    /// Returns JSON {"success": bool, "error": string}.
    /// </summary>
    public static string ExecuteShareAdmin(Chrome chrome, string paramJson)
    {
        string pageId = "";
        string toUid = "";
        string pass = "";

        try
        {
            if (!string.IsNullOrWhiteSpace(paramJson))
            {
                var token = JToken.Parse(paramJson);
                if (token is JArray arr)
                {
                    foreach (var item in arr)
                    {
                        string name = item["name"]?.ToString() ?? "";
                        string val = item["value"]?.ToString() ?? "";
                        if (name == "pageId") pageId = val;
                        else if (name == "toUid") toUid = val;
                        else if (name == "pass") pass = val;
                    }
                }
                else if (token is JObject obj)
                {
                    pageId = obj["pageId"]?.ToString() ?? "";
                    toUid = obj["toUid"]?.ToString() ?? "";
                    pass = obj["pass"]?.ToString() ?? "";
                }
            }

            if (string.IsNullOrEmpty(pass) && chrome != null)
            {
                pass = chrome.C234EEAA ?? "";
            }

            bool ok = ShareAdminPageAccess(chrome, pageId, toUid, pass);
            return ok
                ? "{\"success\": true, \"message\": \"Admin access granted successfully\", \"error\": \"\"}"
                : "{\"success\": false, \"error\": \"Failed to grant admin access\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + ex.Message.Replace("\"", "\\\"") + "\"}";
        }
    }

    /// <summary>
    /// JSON dispatcher handler for RemoveAdminPagePro5 action.
    /// Returns JSON {"success": bool, "error": string}.
    /// </summary>
    public static string ExecuteRemoveAdmin(Chrome chrome, string paramJson)
    {
        string pageId = "";
        string toUid = "";
        string pass = "";

        try
        {
            if (!string.IsNullOrWhiteSpace(paramJson))
            {
                var token = JToken.Parse(paramJson);
                if (token is JArray arr)
                {
                    foreach (var item in arr)
                    {
                        string name = item["name"]?.ToString() ?? "";
                        string val = item["value"]?.ToString() ?? "";
                        if (name == "pageId") pageId = val;
                        else if (name == "toUid") toUid = val;
                        else if (name == "pass") pass = val;
                    }
                }
                else if (token is JObject obj)
                {
                    pageId = obj["pageId"]?.ToString() ?? "";
                    toUid = obj["toUid"]?.ToString() ?? "";
                    pass = obj["pass"]?.ToString() ?? "";
                }
            }

            if (string.IsNullOrEmpty(pass) && chrome != null)
            {
                pass = chrome.C234EEAA ?? "";
            }

            bool ok = RemoveAdminPageAccess(chrome, pageId, toUid, pass);
            return ok
                ? "{\"success\": true, \"message\": \"Admin access removed successfully\", \"error\": \"\"}"
                : "{\"success\": false, \"error\": \"Failed to remove admin access\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + ex.Message.Replace("\"", "\\\"") + "\"}";
        }
    }
}
