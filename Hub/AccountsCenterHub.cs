using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

public static class AccountsCenterHub
{
    /// <summary>
    /// Static entrypoint for Meta Accounts Center and Facebook WWW Desktop automation.
    /// </summary>
    /// <param name="chrome">Chrome instance running the session</param>
    /// <param name="actionName">Target action name</param>
    /// <param name="paramJson">Parameters as JSON array, JSON object, or string</param>
    /// <returns>Result string (JSON string or status string based on action specification)</returns>
    public static string Execute(Chrome chrome, string actionName, string paramJson)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null || chrome.CD930D04() || chrome.E184CD03())
        {
            return FormatError(actionName, "chrome_closed_or_null");
        }

        try
        {
            string cleanAction = (actionName ?? "").Trim();
            switch (cleanAction)
            {
                case "ChangePass":
                case "DoiMatKhau":
                    return ExecuteChangePass(chrome, paramJson);

                case "TurnOn2FA":
                case "Bat2FA":
                    return ExecuteTurnOn2FA(chrome, paramJson);

                case "TurnOff2FA":
                case "Tat2FA":
                    return ExecuteTurnOff2FA(chrome, paramJson);

                case "AddMailAccountCenter":
                case "AddMail":
                    return ExecuteAddMail(chrome, paramJson);

                case "SubmitOtpAddMail":
                case "ConfirmAddMail":
                    return ExecuteSubmitOtpAddMail(chrome, paramJson);

                case "DeletePhone":
                case "XoaSdt":
                    return ExecuteDeletePhone(chrome, paramJson);

                case "DeleteOtherEmail":
                case "DeleteMail":
                case "XoaMail":
                case "RemoveEmailMfb":
                case "RemoveEmail":
                    return ExecuteDeleteOtherEmail(chrome, paramJson);

                case "Rename":
                case "DoiTen":
                    return ExecuteRename(chrome, paramJson);

                case "UpAvatarWWW":
                case "UpAvatar":
                    return ExecuteUpAvatarWWW(chrome, paramJson);

                case "UpAvatarMbasic":
                    return ExecuteUpAvatarMbasic(chrome, paramJson);

                case "UpCoverWWW":
                case "UpCover":
                    return ExecuteUpCoverWWW(chrome, paramJson);

                case "UpCoverMbasic":
                    return ExecuteUpCoverMbasic(chrome, paramJson);

                case "LogoutOldDevices":
                case "DangXuatThietBiCu":
                    return ExecuteLogoutOldDevices(chrome, paramJson);

                case "DangStoryWWW":
                case "DangStory":
                    return ExecuteDangStoryWWW(chrome, paramJson);

                case "UnlockProfile":
                case "MoKhoaProfile":
                    return ExecuteUnlockProfile(chrome, paramJson, unlock: true);

                case "LockProfile":
                case "KhoaProfile":
                    return ExecuteUnlockProfile(chrome, paramJson, unlock: false);

                case "ProfessionalMode":
                case "BatCheDoChuyenNghiep":
                    return ExecuteProfessionalMode(chrome, paramJson);

                default:
                    return "";
            }
        }
        catch (Exception ex)
        {
            return FormatError(actionName, ex.Message);
        }
    }

    #region Action 1: ChangePass
    private static string ExecuteChangePass(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string curPass = GetParam(p, "password", "pass", "current_password", "old_password");
        if (string.IsNullOrEmpty(curPass))
        {
            curPass = chrome.C234EEAA;
        }

        string newPass = GetParam(p, "newpassword", "new_password", "newpass", "txtNewPass");
        if (string.IsNullOrEmpty(newPass))
        {
            return "fail (empty new password)";
        }

        var driver = chrome.ChromeDriver_0;
        string currentUrl = chrome.GetURL() ?? "";

        // Support Accounts Center URL and Facebook Settings Security Tab (Comet 2026)
        if (!currentUrl.Contains("password_change") && !currentUrl.Contains("settings/?tab=security") && !currentUrl.Contains("settings?tab=security"))
        {
            Navigate(chrome, "https://accountscenter.facebook.com/password_and_security/password_change", 4);
        }
        chrome.DismissFacebookPopups();

        HandleReauth(chrome, curPass);
        SelectProfileAccount(driver);
        HandleReauth(chrome, curPass);

        int maxWait = 20;
        int start = Environment.TickCount;
        IWebElement curInput = null;
        IWebElement newInput = null;
        IWebElement confirmInput = null;

        while (Environment.TickCount - start < maxWait * 1000)
        {
            // If on Facebook settings tab, trigger Accounts Center dialog or navigate
            string curUrl = chrome.GetURL() ?? "";
            if (curUrl.Contains("settings") && (curUrl.Contains("security") || curUrl.Contains("account_center")))
            {
                try
                {
                    var acLinks = driver.FindElements(By.XPath("//a[contains(@href, 'accountscenter.facebook.com') or contains(@href, 'password_change')] | //div[@role='button'][.//*[contains(text(), 'Đổi mật khẩu') or contains(text(), 'Change password') or contains(text(), 'Chỉnh sửa') or contains(text(), 'Edit')]]"));
                    if (acLinks.Count > 0 && acLinks[0].Displayed)
                    {
                        ClickElement(driver, acLinks[0]);
                        Sleep(2.0);
                        chrome.DismissFacebookPopups();
                    }
                }
                catch { }
            }

            if (FindPasswordInputs(driver, out curInput, out newInput, out confirmInput))
            {
                break;
            }

            // Check if reauth screen appears with 1 password field
            var pwdInputs = driver.FindElements(By.CssSelector("input[type='password']")).Where(e => {
                try { return e.Displayed && e.Enabled; } catch { return false; }
            }).ToList();
            if (pwdInputs.Count == 1)
            {
                HandleReauth(chrome, curPass);
            }

            SelectProfileAccount(driver);
            Sleep(1.0);
        }

        if (curInput == null || newInput == null || confirmInput == null)
        {
            string earlyErr = DetectChangePassError(driver);
            if (!string.IsNullOrEmpty(earlyErr))
            {
                return earlyErr;
            }
            return "fail (password fields not found)";
        }

        // Fill current password
        JsSetInputValue(driver, curInput, curPass);
        Sleep(0.5);

        // Fill new password
        JsSetInputValue(driver, newInput, newPass);
        Sleep(0.5);

        // Confirm new password
        JsSetInputValue(driver, confirmInput, newPass);
        Sleep(1.0);

        // Click Change password button
        ClickSubmitChangePass(driver);

        // Check result
        int checkStart = Environment.TickCount;
        while (Environment.TickCount - checkStart < 18000)
        {
            Sleep(1.5);
            string url = chrome.GetURL() ?? "";

            // Check if stay logged in modal appears
            var stayLoggedInButtons = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Duy trì đăng nhập') or contains(text(), 'Stay logged in') or contains(text(), 'Đăng xuất khỏi thiết bị khác') or contains(text(), 'Log out of other devices') or contains(text(), 'Tiếp tục') or contains(text(), 'Continue') or contains(text(), 'Xong') or contains(text(), 'Done') or contains(text(), 'Đóng') or contains(text(), 'Close')]]"));
            foreach (var sbtn in stayLoggedInButtons)
            {
                if (sbtn.Displayed && sbtn.Enabled)
                {
                    ClickElement(driver, sbtn);
                    Sleep(1.0);
                    chrome.C234EEAA = newPass;
                    return "success";
                }
            }

            // Check for error text
            string err = DetectChangePassError(driver);
            if (!string.IsNullOrEmpty(err))
            {
                return err;
            }

            // If navigated away or inputs gone
            var remainingPwd = driver.FindElements(By.CssSelector("input[type='password']")).Where(e => {
                try { return e.Displayed && e.Enabled; } catch { return false; }
            }).ToList();

            if (remainingPwd.Count == 0 || (!url.Contains("password_change") && !url.Contains("settings/?tab=security") && !url.Contains("settings?tab=security")))
            {
                chrome.C234EEAA = newPass;
                return "success";
            }
        }

        chrome.C234EEAA = newPass;
        return "success";
    }
    #endregion

    #region Action 2: TurnOn2FA & TurnOff2FA
    private static string ExecuteTurnOn2FA(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string pass = GetParam(p, "password", "pass", "current_password");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;
        string otp = GetParam(p, "otp", "code");

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://accountscenter.facebook.com/password_and_security/two_factor", 4);
        chrome.DismissFacebookPopups();

        HandleReauth(chrome, pass);
        SelectProfileAccount(driver);
        HandleReauth(chrome, pass);

        // Check if 2FA is already turned on
        string bodyText = driver.FindElement(By.TagName("body")).Text;
        if (bodyText.Contains("Bảo mật hai lớp đang bật") ||
            bodyText.ToLower().Contains("two-factor authentication is on") ||
            bodyText.Contains("Tắt tính năng xác thực") ||
            bodyText.ToLower().Contains("turn off two-factor") ||
            bodyText.Contains("Bạn đã bật tính năng xác thực") ||
            bodyText.Contains("Phương thức bảo mật của bạn") ||
            bodyText.ToLower().Contains("your security methods"))
        {
            string existingFa2 = !string.IsNullOrEmpty(chrome.A1BF36A2) ? chrome.A1BF36A2 : "";
            return "{\"success\": true, \"fa2\": \"" + existingFa2 + "\", \"error\": \"\"}";
        }

        // Select Authenticator App method
        bool authAppSelected = false;
        try
        {
            object selectRes = driver.ExecuteScript(@"
                var keywords = ['ứng dụng xác thực', 'authentication app', 'authenticator app', 'authenticator'];
                var els = Array.from(document.querySelectorAll('div[role=""radio""], div[role=""button""], div[role=""checkbox""], label, div[class*=""x1i10hfl""]'));
                for (var el of els) {
                    var t = (el.innerText || el.textContent || '').toLowerCase();
                    for (var k of keywords) {
                        if (t.includes(k)) {
                            el.scrollIntoView({block: 'center'});
                            el.click();
                            ['mousedown', 'mouseup', 'click'].forEach(eventType => {
                                el.dispatchEvent(new MouseEvent(eventType, { bubbles: true, cancelable: true, view: window }));
                            });
                            return 'clicked';
                        }
                    }
                }
                return 'not_found';
            ");
            if (selectRes?.ToString() == "clicked")
            {
                authAppSelected = true;
            }
        }
        catch { }

        if (!authAppSelected)
        {
            var authOptions = driver.FindElements(By.XPath("//div[@role='button' or @role='radio' or @role='checkbox' or contains(@class, 'x1i10hfl')][.//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'ứng dụng xác thực') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'authentication app') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'authenticator')]] | //label[.//*[contains(text(), 'Ứng dụng xác thực') or contains(text(), 'Authentication app')]]"));
            if (authOptions.Count > 0)
            {
                ClickElement(driver, authOptions[0]);
                authAppSelected = true;
            }
        }

        Sleep(1.5);
        ClickNextButton(driver);
        Sleep(2.5);
        HandleReauth(chrome, pass);

        // Look for "Cannot scan QR code?" or "Can't scan QR" / "Sao chép khóa"
        try
        {
            driver.ExecuteScript(@"
                var keywords = ['không thể quét', 'can\'t scan', 'cannot scan', 'sao chép khóa', 'copy key', 'sao chép mã', 'copy code', 'thiết lập trên cùng thiết bị', 'set up on same device', 'nhập mã khóa này', 'enter this key'];
                var btns = Array.from(document.querySelectorAll('div[role=""button""], a, span, div[role=""link""], div[class*=""x1i10hfl""]'));
                for (var b of btns) {
                    var t = (b.innerText || b.textContent || '').toLowerCase();
                    for (var k of keywords) {
                        if (t.includes(k)) {
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            return;
                        }
                    }
                }
            ");
        }
        catch { }

        var cantScanButtons = driver.FindElements(By.XPath("//div[@role='button' or @role='link' or contains(@class, 'x1i10hfl')][.//*[contains(text(), 'Không thể quét') or contains(text(), 'Can\'t scan') or contains(text(), 'Sao chép') or contains(text(), 'Copy key') or contains(text(), 'Thiết lập trên cùng thiết bị') or contains(text(), 'Set up on same device')]]"));
        if (cantScanButtons.Count > 0)
        {
            ClickElement(driver, cantScanButtons[0]);
            Sleep(1.5);
        }

        // Extract secret key from DOM
        string secretKey = "";
        int extractStart = Environment.TickCount;
        while (Environment.TickCount - extractStart < 8000 && string.IsNullOrEmpty(secretKey))
        {
            // 1. Try JS DOM query
            try
            {
                object keyObj = driver.ExecuteScript(@"
                    var candidates = Array.from(document.querySelectorAll('code, pre, input[type=""text""], input[readonly], span, div, p'));
                    for (var el of candidates) {
                        var val = (el.value || el.innerText || el.textContent || '').trim();
                        var clean = val.replace(/[\s\-]/g, '').toUpperCase();
                        if (/^[A-Z2-7]{16,64}$/.test(clean)) {
                            if (!clean.includes('PASSWORD') && !clean.includes('CONTINUE') && !clean.includes('FACEBOOK')) {
                                return clean;
                            }
                        }
                    }
                    var bodyText = document.body ? document.body.innerText : '';
                    var m = bodyText.match(/\b([A-Z2-7]{4}[\s\-]?){4,8}\b/i);
                    if (m && m[0]) {
                        var c = m[0].replace(/[\s\-]/g, '').toUpperCase();
                        if (/^[A-Z2-7]{16,64}$/.test(c)) return c;
                    }
                    return '';
                ");
                secretKey = keyObj?.ToString() ?? "";
            }
            catch { }

            // 2. C# Regex fallback
            if (string.IsNullOrEmpty(secretKey))
            {
                try
                {
                    string currentText = driver.FindElement(By.TagName("body")).Text;
                    var match = Regex.Match(currentText, @"\b([A-Z2-7]{4}[\s\-]?){4,8}\b", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        string clean = Regex.Replace(match.Value, @"[\s\-]", "").ToUpper();
                        if (Regex.IsMatch(clean, @"^[A-Z2-7]{16,64}$"))
                        {
                            secretKey = clean;
                        }
                    }
                }
                catch { }
            }

            if (!string.IsNullOrEmpty(secretKey)) break;
            Sleep(1.0);
        }

        // If secret key is extracted, save to Chrome session and auto-generate TOTP code via RFC6238 Base32 offline
        if (!string.IsNullOrEmpty(secretKey))
        {
            chrome.A1BF36A2 = secretKey;
            if (string.IsNullOrEmpty(otp))
            {
                try
                {
                    otp = Commom.smethod_62(secretKey);
                }
                catch { }
            }
        }

        // If OTP is available (or generated offline), submit to activate 2FA
        if (!string.IsNullOrEmpty(otp))
        {
            ClickNextButton(driver);
            Sleep(2.0);
            HandleReauth(chrome, pass);

            bool otpEntered = false;
            try
            {
                object otpFillRes = driver.ExecuteScript(@"
                    var code = arguments[0];
                    var digitInputs = Array.from(document.querySelectorAll('input[type=""text""], input[inputmode=""numeric""]')).filter(i => i.offsetParent !== null && (i.maxLength === 1 || i.getAttribute('aria-label')?.includes('digit')));
                    if (digitInputs.length === 6) {
                        for (var i = 0; i < 6; i++) {
                            digitInputs[i].focus();
                            digitInputs[i].value = code[i];
                            digitInputs[i].dispatchEvent(new Event('input', { bubbles: true }));
                            digitInputs[i].dispatchEvent(new Event('change', { bubbles: true }));
                        }
                        return 'filled_6';
                    }

                    var singleInputs = Array.from(document.querySelectorAll('input[type=""text""], input[inputmode=""numeric""], input[name=""code""], input[autocomplete=""one-time-code""]')).filter(i => i.offsetParent !== null);
                    if (singleInputs.length > 0) {
                        var inp = singleInputs[0];
                        inp.focus();
                        inp.value = code;
                        inp.dispatchEvent(new Event('input', { bubbles: true }));
                        inp.dispatchEvent(new Event('change', { bubbles: true }));
                        return 'filled_1';
                    }
                    return 'not_found';
                ", otp);

                if (otpFillRes?.ToString()?.StartsWith("filled") == true)
                {
                    otpEntered = true;
                }
            }
            catch { }

            if (!otpEntered)
            {
                var otpInputs = driver.FindElements(By.CssSelector("input[type='text'], input[inputmode='numeric'], input[name='code']")).Where(e => {
                    try { return e.Displayed && e.Enabled; } catch { return false; }
                }).ToList();

                if (otpInputs.Count == 6)
                {
                    for (int i = 0; i < 6 && i < otp.Length; i++)
                    {
                        JsSetInputValue(driver, otpInputs[i], otp[i].ToString());
                    }
                    otpEntered = true;
                }
                else if (otpInputs.Count > 0)
                {
                    JsSetInputValue(driver, otpInputs[0], otp);
                    otpEntered = true;
                }
            }

            Sleep(1.0);
            ClickNextButton(driver);
            Sleep(3.0);
            HandleReauth(chrome, pass);

            // Click Done / Xong button if appears
            try
            {
                var doneBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[text()='Xong' or text()='Done' or text()='Hoàn tất' or text()='Finish' or contains(text(), 'Xong') or contains(text(), 'Done')]]"));
                if (doneBtns.Count > 0 && doneBtns[0].Displayed)
                {
                    ClickElement(driver, doneBtns[0]);
                    Sleep(1.5);
                }
            }
            catch { }
        }

        if (!string.IsNullOrEmpty(secretKey))
        {
            return "{\"success\": true, \"fa2\": \"" + secretKey + "\", \"error\": \"\"}";
        }

        return "{\"success\": false, \"error\": \"secret_key_not_found\"}";
    }

    private static string ExecuteTurnOff2FA(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string pass = GetParam(p, "password", "pass", "current_password");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://accountscenter.facebook.com/password_and_security/two_factor", 4);
        chrome.DismissFacebookPopups();

        HandleReauth(chrome, pass);
        SelectProfileAccount(driver);
        HandleReauth(chrome, pass);

        // Check if 2FA is already turned off
        string bodyText = driver.FindElement(By.TagName("body")).Text;
        if (!bodyText.Contains("Bảo mật hai lớp đang bật") &&
            !bodyText.ToLower().Contains("two-factor authentication is on") &&
            !bodyText.Contains("Tắt tính năng xác thực") &&
            !bodyText.ToLower().Contains("turn off two-factor") &&
            (bodyText.Contains("Chọn phương thức bảo mật") || bodyText.Contains("Ứng dụng xác thực") || bodyText.ToLower().Contains("authentication app")))
        {
            chrome.A1BF36A2 = "";
            return "{\"success\": true, \"error\": \"\"}";
        }

        // Click Turn Off button or method manage row
        bool clickedTurnOff = false;
        try
        {
            object jsTurnOff = driver.ExecuteScript(@"
                var keywords = ['tắt', 'turn off', 'tắt tính năng xác thực', 'turn off two-factor'];
                var btns = Array.from(document.querySelectorAll('div[role=""button""], button, div[class*=""x1i10hfl""]'));
                for (var b of btns) {
                    if (b.offsetParent === null) continue;
                    var t = (b.innerText || b.textContent || b.getAttribute('aria-label') || '').toLowerCase().trim();
                    for (var k of keywords) {
                        if (t === k || t.includes(k)) {
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            return 'clicked';
                        }
                    }
                }
                return 'not_found';
            ");
            if (jsTurnOff?.ToString() == "clicked")
            {
                clickedTurnOff = true;
            }
        }
        catch { }

        if (!clickedTurnOff)
        {
            var turnOffButtons = driver.FindElements(By.XPath("//div[@role='button'][.//*[text()='Tắt' or text()='Turn off' or text()='Turn Off' or contains(text(), 'Tắt tính năng') or contains(text(), 'Turn off two-factor')]] | //div[contains(@class, 'x1i10hfl') and @role='button'][.//*[contains(text(), 'Tắt') or contains(text(), 'Turn off')]]"));
            if (turnOffButtons.Count > 0)
            {
                ClickElement(driver, turnOffButtons[0]);
                clickedTurnOff = true;
            }
        }

        if (clickedTurnOff)
        {
            Sleep(1.5);

            // Confirm Turn Off inside dialog
            bool confirmed = false;
            try
            {
                object jsConfirm = driver.ExecuteScript(@"
                    var keywords = ['tắt', 'turn off', 'xác nhận', 'confirm'];
                    var btns = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button'));
                    for (var b of btns) {
                        if (b.offsetParent === null) continue;
                        var t = (b.innerText || b.textContent || '').toLowerCase().trim();
                        for (var k of keywords) {
                            if (t === k || t.includes(k)) {
                                b.scrollIntoView({block: 'center'});
                                b.click();
                                return 'confirmed';
                            }
                        }
                    }
                    return 'not_found';
                ");
                if (jsConfirm?.ToString() == "confirmed") confirmed = true;
            }
            catch { }

            if (!confirmed)
            {
                var confirmButtons = driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][.//*[text()='Tắt' or text()='Turn off' or text()='Turn Off' or contains(text(), 'Tắt tính năng') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm')]]"));
                if (confirmButtons.Count > 0)
                {
                    ClickElement(driver, confirmButtons[0]);
                }
            }

            Sleep(2.5);
            HandleReauth(chrome, pass);
            chrome.A1BF36A2 = "";
            return "{\"success\": true, \"error\": \"\"}";
        }

        chrome.A1BF36A2 = "";
        return "{\"success\": true, \"error\": \"\"}";
    }
    #endregion

    #region Action 3: AddMailAccountCenter & SubmitOtpAddMail
    private static string ExecuteAddMail(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string email = GetParam(p, "email", "mail", "txtEmail");
        string pass = GetParam(p, "password", "pass");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;
        string otp = GetParam(p, "otp", "code");

        if (string.IsNullOrEmpty(email))
        {
            return "fail (empty email)";
        }

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://accountscenter.facebook.com/personal-info/contact-points", 4);
        chrome.DismissFacebookPopups();
        HandleReauth(chrome, pass);

        // Click Add new contact
        var addContactBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Thêm thông tin liên hệ mới') or contains(text(), 'Add new contact')]] | //a[contains(@href, 'add_contact')]"));
        if (addContactBtns.Count > 0)
        {
            ClickElement(driver, addContactBtns[0]);
            Sleep(2.0);
        }

        // Click Add email
        var addEmailBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Thêm email') or contains(text(), 'Add email')]] | //a[contains(@href, 'add_email')]"));
        if (addEmailBtns.Count > 0)
        {
            ClickElement(driver, addEmailBtns[0]);
            Sleep(2.0);
        }

        // Type email
        var emailInputs = driver.FindElements(By.CssSelector("input[type='text'], input[type='email']"));
        if (emailInputs.Count > 0)
        {
            JsSetInputValue(driver, emailInputs[0], email);
            Sleep(1.0);
        }

        // Check account checkbox
        var checkboxes = driver.FindElements(By.XPath("//div[@role='checkbox' or @role='radio'] | //input[@type='checkbox']"));
        if (checkboxes.Count > 0)
        {
            ClickElement(driver, checkboxes[0]);
            Sleep(1.0);
        }

        // Click Next / Gửi
        var nextBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Tiếp') or contains(text(), 'Next') or contains(text(), 'Gửi') or contains(text(), 'Send')]]"));
        if (nextBtns.Count > 0)
        {
            ClickElement(driver, nextBtns[0]);
            Sleep(3.0);
        }

        HandleReauth(chrome, pass);

        // If OTP provided, submit it
        if (!string.IsNullOrEmpty(otp))
        {
            return ExecuteSubmitOtpAddMail(chrome, paramJson);
        }

        return "success";
    }

    private static string ExecuteSubmitOtpAddMail(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string otp = GetParam(p, "otp", "code", "confirmation_code");
        if (string.IsNullOrEmpty(otp))
        {
            return "fail (empty otp)";
        }

        var driver = chrome.ChromeDriver_0;
        Sleep(1.5);

        var otpInputs = driver.FindElements(By.CssSelector("input[type='text'], input[inputmode='numeric']"));
        if (otpInputs.Count > 0)
        {
            JsSetInputValue(driver, otpInputs[0], otp);
            Sleep(1.0);

            var confirmBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Tiếp') or contains(text(), 'Next') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm') or contains(text(), 'Xong') or contains(text(), 'Done')]]"));
            if (confirmBtns.Count > 0)
            {
                ClickElement(driver, confirmBtns[0]);
                Sleep(3.0);
            }
            return "success";
        }

        return "fail (otp input not found)";
    }
    #endregion

    #region Action 4: DeletePhone & DeleteOtherEmail
    private static string ExecuteDeletePhone(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string phone = GetParam(p, "phone", "sdt", "phoneNumber");
        string pass = GetParam(p, "password", "pass");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://accountscenter.facebook.com/personal-info/contact-points", 4);
        chrome.DismissFacebookPopups();
        HandleReauth(chrome, pass);

        // Find phone item in contact points
        IWebElement targetItem = null;
        var items = driver.FindElements(By.XPath("//div[@role='list']//div[@role='listitem'] | //div[@role='button']"));
        foreach (var item in items)
        {
            string t = item.Text;
            if (!string.IsNullOrEmpty(phone) && t.Contains(phone))
            {
                targetItem = item;
                break;
            }
            else if (string.IsNullOrEmpty(phone) && Regex.IsMatch(t, @"\+?\d{8,15}"))
            {
                targetItem = item;
                break;
            }
        }

        if (targetItem == null)
        {
            return "success"; // Phone not present
        }

        ClickElement(driver, targetItem);
        Sleep(2.5);

        // Click Delete number
        var delBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Xóa số') or contains(text(), 'Delete number') or contains(text(), 'Xóa') or contains(text(), 'Delete')]]"));
        if (delBtns.Count > 0)
        {
            ClickElement(driver, delBtns[0]);
            Sleep(1.5);

            // Confirm delete
            var confirmBtns = driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][.//*[contains(text(), 'Xóa') or contains(text(), 'Delete')]]"));
            if (confirmBtns.Count > 0)
            {
                ClickElement(driver, confirmBtns[0]);
                Sleep(2.5);
            }

            HandleReauth(chrome, pass);
            return "success";
        }

        return "success";
    }

    private static string ExecuteDeleteOtherEmail(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string email = GetParam(p, "email", "mail");
        string pass = GetParam(p, "password", "pass");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://accountscenter.facebook.com/personal-info/contact-points", 4);
        chrome.DismissFacebookPopups();
        HandleReauth(chrome, pass);

        if (string.IsNullOrEmpty(email))
        {
            return "success";
        }

        IWebElement targetItem = null;
        var items = driver.FindElements(By.XPath("//div[@role='list']//div[@role='listitem'] | //div[@role='button']"));
        foreach (var item in items)
        {
            if (item.Text.ToLower().Contains(email.ToLower()))
            {
                targetItem = item;
                break;
            }
        }

        if (targetItem == null)
        {
            return "success"; // Already removed
        }

        ClickElement(driver, targetItem);
        Sleep(2.5);

        // Click Delete email
        var delBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Xóa email') or contains(text(), 'Delete email') or contains(text(), 'Xóa') or contains(text(), 'Delete')]]"));
        if (delBtns.Count > 0)
        {
            ClickElement(driver, delBtns[0]);
            Sleep(1.5);

            // Confirm delete
            var confirmBtns = driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][.//*[contains(text(), 'Xóa') or contains(text(), 'Delete')]]"));
            if (confirmBtns.Count > 0)
            {
                ClickElement(driver, confirmBtns[0]);
                Sleep(2.5);
            }

            HandleReauth(chrome, pass);
            return "success";
        }

        return "success";
    }
    #endregion

    #region Action 5: Rename
    private static string ExecuteRename(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string fullName = GetParam(p, "name", "fullname", "txtTen");
        string firstName = GetParam(p, "firstName", "first_name");
        string lastName = GetParam(p, "lastName", "last_name");
        string middleName = GetParam(p, "middleName", "middle_name");
        string pass = GetParam(p, "password", "pass");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;

        if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(fullName))
        {
            var parts = fullName.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                firstName = parts[0];
                lastName = parts[0];
            }
            else if (parts.Length == 2)
            {
                lastName = parts[0];
                firstName = parts[1];
            }
            else if (parts.Length == 3)
            {
                lastName = parts[0];
                middleName = parts[1];
                firstName = parts[2];
            }
            else
            {
                lastName = parts[0];
                middleName = string.Join(" ", parts.Skip(1).Take(parts.Length - 2));
                firstName = parts.Last();
            }
        }

        string uid = GetParam(p, "uid");
        if (string.IsNullOrEmpty(uid)) uid = chrome.B4208531;
        if (string.IsNullOrEmpty(uid)) uid = chrome.FB94939A();

        var driver = chrome.ChromeDriver_0;
        string targetUrl = string.IsNullOrEmpty(uid) ?
            "https://accountscenter.facebook.com/profiles/?entrypoint=fb_account_center&locale=en_US" :
            $"https://accountscenter.facebook.com/profiles/{uid}/name/?entrypoint=fb_account_center&locale=en_US";

        Navigate(chrome, targetUrl, 4);
        chrome.DismissFacebookPopups();
        HandleReauth(chrome, pass);
        SelectProfileAccount(driver);

        // Find name inputs
        var inputs = driver.FindElements(By.CssSelector("[role='dialog'] input[type='text'], input[type='text']"));
        var activeInputs = inputs.Where(i => i.Displayed && i.Enabled).ToList();

        if (activeInputs.Count >= 3)
        {
            JsSetInputValue(driver, activeInputs[0], firstName);
            Sleep(0.5);
            JsSetInputValue(driver, activeInputs[1], string.IsNullOrEmpty(middleName) ? "" : middleName);
            Sleep(0.5);
            JsSetInputValue(driver, activeInputs[2], lastName);
            Sleep(1.0);
        }
        else if (activeInputs.Count == 2)
        {
            JsSetInputValue(driver, activeInputs[0], firstName);
            Sleep(0.5);
            JsSetInputValue(driver, activeInputs[1], lastName);
            Sleep(1.0);
        }
        else if (activeInputs.Count == 1)
        {
            JsSetInputValue(driver, activeInputs[0], fullName);
            Sleep(1.0);
        }
        else
        {
            // Inputs might be disabled (60-day limit)
            var disabled = driver.FindElements(By.CssSelector("input[type='text'][disabled]"));
            if (disabled.Count > 0)
            {
                return ErrorJson("name_change_locked_60_days");
            }
            return ErrorJson("name_inputs_not_found");
        }

        // Click Review Change / Xem lại thay đổi
        var reviewBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Xem lại thay đổi') or contains(text(), 'Review change') or contains(text(), 'Review Change')]] | (//div[@role='dialog']//div[@role='button'])[last()]"));
        if (reviewBtns.Count > 0)
        {
            ClickElement(driver, reviewBtns[0]);
            Sleep(3.0);
        }

        // Select preview display option
        var radioOptions = driver.FindElements(By.XPath("//div[@role='radio'] | //input[@type='radio']"));
        if (radioOptions.Count > 0)
        {
            IWebElement targetRadio = null;
            string matchName = !string.IsNullOrEmpty(fullName) ? fullName.Trim().ToLower() : $"{lastName} {middleName} {firstName}".Trim().ToLower();
            foreach (var r in radioOptions)
            {
                try
                {
                    string containerText = r.FindElement(By.XPath("./ancestor::div[@role='button' or @role='radio' or @role='listitem'] | ..")).Text.ToLower();
                    if (containerText.Contains(matchName))
                    {
                        targetRadio = r;
                        break;
                    }
                }
                catch { }
            }
            ClickElement(driver, targetRadio ?? radioOptions[0]);
            Sleep(1.0);
        }

        // Click Save Changes / Lưu thay đổi
        var saveBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Lưu thay đổi') or contains(text(), 'Save changes') or contains(text(), 'Save Changes') or contains(text(), 'Lưu') or contains(text(), 'Save')]]"));
        if (saveBtns.Count > 0)
        {
            ClickElement(driver, saveBtns[0]);
            Sleep(3.0);
        }

        HandleReauth(chrome, pass);

        // Kiem tra canh bao loi tu choi tu Meta (gioi han 60 ngay, ten vi pham, v.v.) tranh False-Success
        try
        {
            var alerts = driver.FindElements(By.CssSelector("div[role='alert'], [aria-live='assertive'], div[class*='error']"));
            foreach (var a in alerts)
            {
                if (a.Displayed && !string.IsNullOrWhiteSpace(a.Text))
                {
                    return ErrorJson("meta_rejected: " + a.Text.Trim());
                }
            }
        }
        catch { }

        return SuccessJson();
    }
    #endregion

    #region Action 6: UpAvatarWWW & UpCoverWWW
    private static string ExecuteUpAvatarWWW(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string imagePath = GetParam(p, "image", "imagePath", "path", "file", "value");

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            return ErrorJson("image_file_not_found: " + imagePath);
        }

        bool ok = ProfileInfoHub.UploadAvatar(chrome, imagePath, false, false);
        return ok ? SuccessJson() : ErrorJson("upload_avatar_failed");
    }

    private static string ExecuteUpAvatarMbasic(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string imagePath = GetParam(p, "image", "imagePath", "path", "file", "value");

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            return ErrorJson("image_file_not_found: " + imagePath);
        }

        bool ok = ProfileInfoHub.UploadAvatar(chrome, imagePath, false, true);
        return ok ? SuccessJson() : ErrorJson("upload_avatar_mbasic_failed");
    }

    private static string ExecuteUpCoverWWW(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string imagePath = GetParam(p, "image", "imagePath", "path", "file", "value");

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            return ErrorJson("image_file_not_found: " + imagePath);
        }

        bool skipIfHave = p.ContainsKey("skipIfHave") && (p["skipIfHave"]?.ToString()?.ToLower() == "true");
        bool ok = ProfileInfoHub.UploadCover(chrome, imagePath, skipIfHave, false);
        return ok ? SuccessJson() : ErrorJson("upload_cover_failed");
    }

    private static string ExecuteUpCoverMbasic(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string imagePath = GetParam(p, "image", "imagePath", "path", "file", "value");

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            return ErrorJson("image_file_not_found: " + imagePath);
        }

        bool skipIfHave = p.ContainsKey("skipIfHave") && (p["skipIfHave"]?.ToString()?.ToLower() == "true");
        bool ok = ProfileInfoHub.UploadCover(chrome, imagePath, skipIfHave, true);
        return ok ? SuccessJson() : ErrorJson("upload_cover_mbasic_failed");
    }

    private static string ExecuteLogoutOldDevices(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string pass = GetParam(p, "password", "pass");
        if (string.IsNullOrEmpty(pass)) pass = chrome.C234EEAA;

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://accountscenter.facebook.com/password_and_security/login_activity?locale=en_US", 4);
        chrome.DismissFacebookPopups();
        HandleReauth(chrome, pass);
        SelectProfileAccount(driver);
        HandleReauth(chrome, pass);

        // 1. Click "Select devices to log out" / "Chọn thiết bị để đăng xuất"
        var selectDevicesBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(translate(text(), 'SELECT DEVICES TO LOG OUT', 'select devices to log out'), 'select devices to log out') or contains(text(), 'Chọn thiết bị để đăng xuất') or contains(text(), 'Select devices')]] | //a[contains(@href, 'login_activity')]"));
        if (selectDevicesBtns.Count > 0)
        {
            ClickElement(driver, selectDevicesBtns[0]);
            Sleep(2.0);
        }

        // 2. Click "Select all" / "Chọn tất cả"
        var selectAllBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(translate(text(), 'SELECT ALL', 'select all'), 'select all') or contains(text(), 'Chọn tất cả')]] | //input[@type='checkbox' and not(@checked)]"));
        if (selectAllBtns.Count > 0)
        {
            ClickElement(driver, selectAllBtns[0]);
            Sleep(1.5);
        }

        // 3. Click "Log out" / "Đăng xuất"
        var logoutBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Log out') or contains(text(), 'Đăng xuất')]]"));
        if (logoutBtns.Count > 0)
        {
            ClickElement(driver, logoutBtns[0]);
            Sleep(2.0);

            // Confirm in dialog
            var confirmBtns = driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][.//*[contains(text(), 'Log out') or contains(text(), 'Đăng xuất')]]"));
            if (confirmBtns.Count > 0)
            {
                ClickElement(driver, confirmBtns[0]);
                Sleep(3.0);
            }
        }

        HandleReauth(chrome, pass);

        // Kiem tra canh bao loi tu choi tu Meta (gioi han 60 ngay, ten vi pham, v.v.) tranh False-Success
        try
        {
            var alerts = driver.FindElements(By.CssSelector("div[role='alert'], [aria-live='assertive'], div[class*='error']"));
            foreach (var a in alerts)
            {
                if (a.Displayed && !string.IsNullOrWhiteSpace(a.Text))
                {
                    return ErrorJson("meta_rejected: " + a.Text.Trim());
                }
            }
        }
        catch { }

        return SuccessJson();
    }
    #endregion

    #region Action 7: DangStoryWWW
    public static string ExecuteDangStoryWWW(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        string imagePath = GetParam(p, "image", "imagePath", "path", "file", "value");

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            return ErrorJson("image_file_not_found: " + imagePath);
        }

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://www.facebook.com/stories/create", 4);
        chrome.DismissFacebookPopups();

        // Unhide file input
        UnhideFileInputs(driver);

        var fileInputs = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file']"));
        if (fileInputs.Count == 0)
        {
            // Click "Tạo tin ảnh" / "Create a photo story"
            var photoStoryBtns = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Tạo tin ảnh') or contains(text(), 'Create a photo story')]]"));
            if (photoStoryBtns.Count > 0)
            {
                ClickElement(driver, photoStoryBtns[0]);
                Sleep(2.0);
                UnhideFileInputs(driver);
                fileInputs = driver.FindElements(By.CssSelector("input[type='file']"));
            }
        }

        if (fileInputs.Count == 0)
        {
            return ErrorJson("file_input_not_found");
        }

        fileInputs[0].SendKeys(imagePath);
        Sleep(4.0);

        // Click "Chia sẻ lên tin" / "Share to story"
        var shareBtns = driver.FindElements(By.XPath("//div[@aria-label='Chia sẻ lên tin' or @aria-label='Share to story' or contains(@aria-label, 'Chia sẻ lên tin') or contains(@aria-label, 'Share to story')][@role='button'] | //div[@role='button'][.//*[contains(text(), 'Chia sẻ lên tin') or contains(text(), 'Share to story')]]"));
        if (shareBtns.Count > 0)
        {
            ClickElement(driver, shareBtns[0]);
            Sleep(4.0);
        }
        else
        {
            driver.ExecuteScript(@"
                var btns = Array.from(document.querySelectorAll('div[role=""button""]'));
                for (var b of btns) {
                    var t = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase();
                    if (t.includes('chia sẻ lên tin') || t.includes('share to story')) {
                        b.click();
                        return;
                    }
                }
            ");
            Sleep(4.0);
        }

        return SuccessJson();
    }
    #endregion

    #region Action 8: UnlockProfile & ProfessionalMode
    private static string ExecuteUnlockProfile(Chrome chrome, string paramJson, bool unlock = true)
    {
        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://www.facebook.com/me", 4);
        chrome.DismissFacebookPopups();

        // 1. Open 3 dots menu on profile header
        var threeDotsBtns = driver.FindElements(By.XPath("//div[@aria-label='Xem thêm' or @aria-label='More' or contains(@aria-label, 'tùy chọn trang cá nhân') or contains(@aria-label, 'Profile settings')][@role='button'] | //div[@role='button'][.//*[name()='svg'] and (contains(@aria-label, 'Xem thêm') or contains(@aria-label, 'More'))]"));
        if (threeDotsBtns.Count > 0)
        {
            ClickElement(driver, threeDotsBtns[0]);
            Sleep(1.5);
        }

        // 2. Click Unlock/Lock profile menuitem
        string keyword = unlock ? "Mở khóa" : "Khóa trang cá nhân";
        string keywordEn = unlock ? "Unlock" : "Lock profile";

        var menuItems = driver.FindElements(By.XPath($"//div[@role='menuitem'][.//*[contains(text(), '{keyword}') or contains(text(), '{keywordEn}')]]"));
        if (menuItems.Count > 0)
        {
            ClickElement(driver, menuItems[0]);
            Sleep(2.0);

            // Confirm inside dialog
            var confirmBtns = driver.FindElements(By.XPath($"//div[@role='dialog']//div[@role='button'][.//*[contains(text(), '{keyword}') or contains(text(), '{keywordEn}') or contains(text(), 'OK')]]"));
            if (confirmBtns.Count > 0)
            {
                ClickElement(driver, confirmBtns[0]);
                Sleep(2.0);
            }
        }

        return SuccessJson();
    }

    private static string ExecuteProfessionalMode(Chrome chrome, string paramJson)
    {
        var p = ParseParams(paramJson);
        bool isEnable = true;
        if (p.ContainsKey("isEnable"))
        {
            bool.TryParse(p["isEnable"], out isEnable);
        }

        var driver = chrome.ChromeDriver_0;
        Navigate(chrome, "https://www.facebook.com/me", 4);
        chrome.DismissFacebookPopups();

        // 1. Open 3 dots menu
        var threeDotsBtns = driver.FindElements(By.XPath("//div[@aria-label='Xem thêm' or @aria-label='More' or contains(@aria-label, 'tùy chọn trang cá nhân') or contains(@aria-label, 'Profile settings')][@role='button'] | //div[@role='button'][.//*[name()='svg'] and (contains(@aria-label, 'Xem thêm') or contains(@aria-label, 'More'))]"));
        if (threeDotsBtns.Count > 0)
        {
            ClickElement(driver, threeDotsBtns[0]);
            Sleep(1.5);
        }

        // 2. Click Professional mode menuitem
        var menuItems = driver.FindElements(By.XPath("//div[@role='menuitem'][.//*[contains(text(), 'chế độ chuyên nghiệp') or contains(text(), 'Professional mode') or contains(text(), 'professional mode')]]"));
        if (menuItems.Count > 0)
        {
            ClickElement(driver, menuItems[0]);
            Sleep(2.0);

            // 3. Confirm inside dialog (Turn on / Turn off)
            string btnText = isEnable ? "Bật" : "Tắt";
            string btnTextEn = isEnable ? "Turn on" : "Turn off";
            var actionBtns = driver.FindElements(By.XPath($"//div[@role='dialog']//div[@role='button'][.//*[contains(text(), '{btnText}') or contains(text(), '{btnTextEn}') or contains(text(), 'Tiếp tục') or contains(text(), 'Continue')]]"));
            if (actionBtns.Count > 0)
            {
                ClickElement(driver, actionBtns[0]);
                Sleep(3.0);
            }
        }

        return SuccessJson();
    }
    #endregion

    #region Helper Methods
    public static Dictionary<string, string> ParseParams(string paramJson)
    {
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (string.IsNullOrWhiteSpace(paramJson))
            return dict;

        try
        {
            string trimmed = paramJson.Trim();
            if (trimmed.StartsWith("["))
            {
                var arr = JArray.Parse(trimmed);
                foreach (var item in arr)
                {
                    string name = item["name"]?.ToString();
                    string val = item["value"]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        dict[name] = val ?? "";
                    }
                }
            }
            else if (trimmed.StartsWith("{"))
            {
                var obj = JObject.Parse(trimmed);
                foreach (var prop in obj.Properties())
                {
                    dict[prop.Name] = prop.Value?.ToString() ?? "";
                }
            }
            else
            {
                dict["value"] = trimmed;
                dict["image"] = trimmed;
            }
        }
        catch { }
        return dict;
    }

    private static string GetParam(Dictionary<string, string> dict, params string[] keys)
    {
        if (dict == null || keys == null) return "";
        foreach (var k in keys)
        {
            if (dict.ContainsKey(k) && !string.IsNullOrEmpty(dict[k]))
            {
                return dict[k].Trim();
            }
        }
        return "";
    }

    private static void Navigate(Chrome chrome, string url, int waitSeconds = 3)
    {
        chrome.method_12(url, FC3A841F: true);
        Sleep(waitSeconds);
    }

    private static void Sleep(double seconds)
    {
        Thread.Sleep((int)(seconds * 1000));
    }

    private static void ClickElement(ChromeDriver driver, IWebElement element)
    {
        try
        {
            element.Click();
        }
        catch
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'}); arguments[0].click();", element);
            }
            catch
            {
                try
                {
                    new Actions(driver).MoveToElement(element).Click().Perform();
                }
                catch { }
            }
        }
    }

    private static void JsSetInputValue(ChromeDriver driver, IWebElement element, string value)
    {
        try
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(@"
                var el = arguments[0];
                var val = arguments[1];
                el.focus();
                var proto = el instanceof HTMLTextAreaElement ? window.HTMLTextAreaElement.prototype : window.HTMLInputElement.prototype;
                var setter = Object.getOwnPropertyDescriptor(proto, 'value') ?
                             Object.getOwnPropertyDescriptor(proto, 'value').set : null;
                if (setter) {
                    setter.call(el, val);
                } else {
                    el.value = val;
                }
                if (el._valueTracker) {
                    el._valueTracker.setValue('');
                }
                el.dispatchEvent(new Event('input', { bubbles: true }));
                el.dispatchEvent(new Event('change', { bubbles: true }));
            ", element, value ?? "");
            Sleep(0.2);
            try
            {
                element.SendKeys(" ");
                Sleep(0.1);
                element.SendKeys(Keys.Backspace);
            }
            catch { }
        }
        catch
        {
            try
            {
                element.Clear();
                element.SendKeys(value ?? "");
            }
            catch { }
        }
    }

    private static bool HandleReauth(Chrome chrome, string password)
    {
        try
        {
            var driver = chrome?.ChromeDriver_0;
            if (driver == null) return false;
            string pass = !string.IsNullOrEmpty(password) ? password : chrome.C234EEAA;
            if (string.IsNullOrEmpty(pass)) return false;

            // 1. Check for password inputs inside dialog first
            var dialogInputs = driver.FindElements(By.CssSelector("div[role='dialog'] input[type='password'], div[role='dialog'] input[name='password'], div[role='dialog'] input[autocomplete='current-password']"))
                                     .Where(e => { try { return e.Displayed && e.Enabled; } catch { return false; } }).ToList();

            IWebElement targetInput = null;
            if (dialogInputs.Count == 1)
            {
                targetInput = dialogInputs[0];
            }
            else
            {
                // Check page-level password inputs
                var pageInputs = driver.FindElements(By.CssSelector("input[type='password'], input[name='password'], input[autocomplete='current-password']"))
                                       .Where(e => { try { return e.Displayed && e.Enabled; } catch { return false; } }).ToList();
                // Never treat change password form (3 password inputs) as reauth
                if (pageInputs.Count == 1)
                {
                    targetInput = pageInputs[0];
                }
            }

            if (targetInput != null)
            {
                JsSetInputValue(driver, targetInput, pass);
                Sleep(0.5);

                // Try clicking submit button via JS and XPath
                bool clicked = false;
                try
                {
                    object clickRes = driver.ExecuteScript(@"
                        var keywords = ['tiếp tục', 'continue', 'xác nhận', 'confirm', 'gửi', 'submit', 'đăng nhập', 'log in', 'tiếp', 'next', 'ok'];
                        var btns = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button, div[role=""button""], button'));
                        for (var b of btns) {
                            if (b.offsetParent === null) continue;
                            if (b.getAttribute('aria-disabled') === 'true' || b.disabled) continue;
                            var t = (b.innerText || b.textContent || b.getAttribute('aria-label') || '').toLowerCase().trim();
                            for (var k of keywords) {
                                if (t === k || (t.startsWith(k) && t.length <= k.length + 5)) {
                                    b.scrollIntoView({block: 'center'});
                                    b.click();
                                    ['mousedown', 'mouseup', 'click'].forEach(eventType => {
                                        b.dispatchEvent(new MouseEvent(eventType, { bubbles: true, cancelable: true, view: window }));
                                    });
                                    return 'clicked';
                                }
                            }
                        }
                        return 'not_found';
                    ");
                    if (clickRes?.ToString() == "clicked") clicked = true;
                }
                catch { }

                if (!clicked)
                {
                    var buttons = driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][.//*[contains(text(), 'Tiếp tục') or contains(text(), 'Continue') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm') or contains(text(), 'Gửi') or contains(text(), 'Submit') or contains(text(), 'Đăng nhập') or text()='OK']] | //div[@role='button'][.//*[contains(text(), 'Tiếp tục') or contains(text(), 'Continue') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm') or contains(text(), 'Gửi') or contains(text(), 'Submit')]] | //button[@type='submit']"));
                    foreach (var btn in buttons)
                    {
                        if (btn.Displayed && btn.Enabled)
                        {
                            ClickElement(driver, btn);
                            clicked = true;
                            break;
                        }
                    }
                }

                if (!clicked)
                {
                    try
                    {
                        targetInput.SendKeys(Keys.Enter);
                        clicked = true;
                    }
                    catch { }
                }

                Sleep(2.0);
                return clicked;
            }
        }
        catch { }
        return false;
    }

    private static bool SelectProfileAccount(ChromeDriver driver)
    {
        try
        {
            // 1. Try JS click prioritizing Facebook account item
            object jsRes = driver.ExecuteScript(@"
                var items = Array.from(document.querySelectorAll('div[role=""listitem""], div[role=""button""], a[href*=""password_change""], a[href*=""two_factor""]'));
                for (var it of items) {
                    if (it.offsetParent === null) continue;
                    var t = (it.innerText || it.textContent || '').toLowerCase();
                    if (t.includes('facebook') || t.includes('trang cá nhân') || t.includes('profile')) {
                        it.scrollIntoView({block: 'center'});
                        it.click();
                        return 'clicked';
                    }
                }
                // Fallback: first listitem or button in list
                var listItems = Array.from(document.querySelectorAll('div[role=""list""] div[role=""listitem""], div[role=""list""] div[role=""button""]'));
                if (listItems.length > 0 && listItems[0].offsetParent !== null) {
                    listItems[0].scrollIntoView({block: 'center'});
                    listItems[0].click();
                    return 'clicked';
                }
                return 'not_found';
            ");
            if (jsRes?.ToString() == "clicked")
            {
                Sleep(2.0);
                return true;
            }
        }
        catch { }

        try
        {
            var items = driver.FindElements(By.XPath("//div[@role='list']//div[@role='listitem'] | //div[contains(@class, 'x1i10hfl') and @role='button' and .//span[contains(text(), 'Facebook')]] | //div[@role='button'][.//*[contains(text(), 'Facebook') or contains(text(), 'Trang cá nhân') or contains(text(), 'Profile')]] | //a[contains(@href, '/password_change') or contains(@href, '/two_factor')]"));
            foreach (var item in items)
            {
                if (item.Displayed)
                {
                    ClickElement(driver, item);
                    Sleep(2.0);
                    return true;
                }
            }
        }
        catch { }
        return false;
    }

    private static bool FindPasswordInputs(ChromeDriver driver, out IWebElement curInput, out IWebElement newInput, out IWebElement confirmInput)
    {
        curInput = null;
        newInput = null;
        confirmInput = null;

        try
        {
            // 1. Try finding by specific attributes
            var allInputs = driver.FindElements(By.CssSelector("input")).Where(e => {
                try { return e.Displayed && e.Enabled; } catch { return false; }
            }).ToList();

            foreach (var inp in allInputs)
            {
                string name = (inp.GetAttribute("name") ?? "").ToLower();
                string auto = (inp.GetAttribute("autocomplete") ?? "").ToLower();
                string aria = (inp.GetAttribute("aria-label") ?? "").ToLower();
                string ph = (inp.GetAttribute("placeholder") ?? "").ToLower();
                string type = (inp.GetAttribute("type") ?? "").ToLower();

                if (type != "password" && type != "text") continue;

                // Check current password
                if (curInput == null)
                {
                    if (name == "current_password" || name == "password_old" || name == "old_password" ||
                        auto == "current-password" ||
                        aria.Contains("mật khẩu hiện tại") || aria.Contains("current password") ||
                        ph.Contains("mật khẩu hiện tại") || ph.Contains("current password"))
                    {
                        curInput = inp;
                        continue;
                    }
                }

                // Check confirm password (test before new_password because confirm labels often contain 'mật khẩu mới' / 'new password')
                if (confirmInput == null)
                {
                    if (name == "confirm_password" || name == "password_confirm" || name == "new_password_confirm" || name == "confirm_new_password" ||
                        aria.Contains("nhập lại mật khẩu") || aria.Contains("gõ lại mật khẩu") ||
                        aria.Contains("re-type new password") || aria.Contains("retype new password") || aria.Contains("confirm new password") ||
                        ph.Contains("nhập lại mật khẩu") || ph.Contains("gõ lại mật khẩu") ||
                        ph.Contains("re-type new password") || ph.Contains("retype new password") || ph.Contains("confirm new password"))
                    {
                        confirmInput = inp;
                        continue;
                    }
                }

                // Check new password
                if (newInput == null)
                {
                    if (name == "new_password" || name == "password_new" ||
                        (auto == "new-password" && confirmInput != inp) ||
                        aria.Contains("mật khẩu mới") || aria.Contains("new password") ||
                        ph.Contains("mật khẩu mới") || ph.Contains("new password"))
                    {
                        newInput = inp;
                        continue;
                    }
                }
            }

            if (curInput != null && newInput != null && confirmInput != null)
            {
                return true;
            }

            // 2. Positional fallback: look for visible password inputs in dialog or page
            var pwdInputs = driver.FindElements(By.CssSelector("input[type='password']")).Where(e => {
                try { return e.Displayed && e.Enabled; } catch { return false; }
            }).ToList();

            if (pwdInputs.Count >= 3)
            {
                if (curInput == null) curInput = pwdInputs[0];
                if (newInput == null) newInput = pwdInputs[1];
                if (confirmInput == null) confirmInput = pwdInputs[2];
                return true;
            }
        }
        catch { }

        return false;
    }

    private static bool ClickSubmitChangePass(ChromeDriver driver)
    {
        // 1. Try JS click across buttons and div[role='button']
        try
        {
            object jsRes = driver.ExecuteScript(@"
                var keywords = ['đổi mật khẩu', 'change password', 'lưu thay đổi', 'save changes', 'lưu', 'save', 'cập nhật mật khẩu', 'update password'];
                var btns = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button, div[role=""button""], button, input[type=""submit""]'));
                for (var b of btns) {
                    if (b.offsetParent === null) continue;
                    var aria = (b.getAttribute('aria-label') || '').toLowerCase().trim();
                    var text = (b.innerText || b.textContent || b.value || '').toLowerCase().trim();
                    for (var k of keywords) {
                        if (text === k || aria === k || text.includes(k) || aria.includes(k)) {
                            if (b.getAttribute('aria-disabled') === 'true' || b.disabled) continue;
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            ['mousedown', 'mouseup', 'click'].forEach(eventType => {
                                b.dispatchEvent(new MouseEvent(eventType, { bubbles: true, cancelable: true, view: window }));
                            });
                            return 'clicked';
                        }
                    }
                }
                return 'not_found';
            ");
            if (jsRes?.ToString() == "clicked") return true;
        }
        catch { }

        // 2. Try XPath search
        try
        {
            var submitButtons = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'đổi mật khẩu') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'change password') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'lưu thay đổi') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'save changes') or translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')='lưu' or translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')='save']] | //button[@type='submit' or @role='button'][.//*[contains(text(), 'Đổi mật khẩu') or contains(text(), 'Change password') or contains(text(), 'Lưu thay đổi') or contains(text(), 'Save changes')]]"));
            foreach (var btn in submitButtons)
            {
                if (btn.Displayed && btn.Enabled)
                {
                    ClickElement(driver, btn);
                    return true;
                }
            }
        }
        catch { }

        // 3. Fallback: last button in dialog
        try
        {
            var lastBtn = driver.FindElements(By.XPath("(//div[@role='dialog']//div[@role='button' and not(@aria-disabled='true')])[last()] | (//div[@role='button' and not(@aria-disabled='true')])[last()]")).LastOrDefault();
            if (lastBtn != null && lastBtn.Displayed && lastBtn.Enabled)
            {
                ClickElement(driver, lastBtn);
                return true;
            }
        }
        catch { }

        return false;
    }

    private static string DetectChangePassError(ChromeDriver driver)
    {
        try
        {
            string pageText = driver.FindElement(By.TagName("body")).Text;
            string lower = pageText.ToLower();

            // Wrong current password
            if (pageText.Contains("Mật khẩu hiện tại không chính xác") ||
                pageText.Contains("Mật khẩu hiện tại của bạn không đúng") ||
                pageText.Contains("Mật khẩu bạn đã nhập không chính xác") ||
                pageText.Contains("Mật khẩu không đúng") ||
                lower.Contains("incorrect current password") ||
                lower.Contains("current password is incorrect") ||
                lower.Contains("the password you entered is incorrect") ||
                lower.Contains("incorrect password") ||
                lower.Contains("wrong password") ||
                lower.Contains("wrong_password") ||
                lower.Contains("incorrect_password"))
            {
                return "wrong_password";
            }

            // Same password
            if (pageText.Contains("Mật khẩu mới không được") ||
                pageText.Contains("Mật khẩu mới không được giống mật khẩu cũ") ||
                lower.Contains("new password cannot be") ||
                lower.Contains("please choose a different password") ||
                lower.Contains("new password must be different"))
            {
                return "same_password";
            }

            // Too many attempts / Rate limited
            if (pageText.Contains("Bạn đã nhập sai") ||
                pageText.Contains("quá nhiều lần") ||
                pageText.Contains("Thử lại sau") ||
                lower.Contains("too many attempts") ||
                lower.Contains("try again later"))
            {
                return "too_many_attempts";
            }

            // Password mismatch
            if (pageText.Contains("Mật khẩu không khớp") ||
                lower.Contains("passwords do not match") ||
                lower.Contains("re-entered password does not match"))
            {
                return "password_mismatch";
            }

            // Weak password
            if (pageText.Contains("Mật khẩu phải có ít nhất") ||
                lower.Contains("password must be at least") ||
                lower.Contains("password is too weak"))
            {
                return "weak_password";
            }
        }
        catch { }
        return null;
    }

    private static bool ClickNextButton(ChromeDriver driver)
    {
        try
        {
            object jsRes = driver.ExecuteScript(@"
                var keywords = ['tiếp', 'next', 'continue', 'tiếp tục', 'xác nhận', 'confirm', 'xong', 'done', 'lưu', 'save'];
                var btns = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button, div[role=""button""], button'));
                for (var b of btns) {
                    if (b.offsetParent === null) continue;
                    if (b.getAttribute('aria-disabled') === 'true' || b.disabled) continue;
                    var t = (b.innerText || b.textContent || b.getAttribute('aria-label') || '').toLowerCase().trim();
                    for (var k of keywords) {
                        if (t === k || (t.startsWith(k) && t.length <= k.length + 5)) {
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            ['mousedown', 'mouseup', 'click'].forEach(eventType => {
                                b.dispatchEvent(new MouseEvent(eventType, { bubbles: true, cancelable: true, view: window }));
                            });
                            return 'clicked';
                        }
                    }
                }
                return 'not_found';
            ");
            if (jsRes?.ToString() == "clicked") return true;
        }
        catch { }

        try
        {
            var nextButtons = driver.FindElements(By.XPath("//div[@role='button' and not(@aria-disabled='true')][.//*[text()='Tiếp' or text()='Next' or text()='Continue' or contains(text(), 'Tiếp tục') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm') or text()='Xong' or text()='Done']] | //button[not(@disabled)][.//*[text()='Tiếp' or text()='Next' or text()='Continue' or contains(text(), 'Xác nhận')]]"));
            foreach (var btn in nextButtons)
            {
                if (btn.Displayed && btn.Enabled)
                {
                    ClickElement(driver, btn);
                    return true;
                }
            }
        }
        catch { }
        return false;
    }

    private static void UnhideFileInputs(ChromeDriver driver)
    {
        try
        {
            driver.ExecuteScript(@"
                var inputs = document.querySelectorAll('input[type=""file""]');
                for (var i = 0; i < inputs.length; i++) {
                    inputs[i].style.display = 'block';
                    inputs[i].style.visibility = 'visible';
                    inputs[i].style.opacity = '1';
                    inputs[i].style.position = 'fixed';
                    inputs[i].style.top = '0';
                    inputs[i].style.left = '0';
                    inputs[i].style.zIndex = '999999';
                }
            ");
        }
        catch { }
    }

    public static bool IsSuccess(string res)
    {
        if (string.IsNullOrWhiteSpace(res)) return false;
        string trimmed = res.Trim();
        if (trimmed.Equals("success", StringComparison.OrdinalIgnoreCase)) return true;
        if (trimmed.IndexOf("\"success\": true", StringComparison.OrdinalIgnoreCase) >= 0) return true;
        if (trimmed.IndexOf("\"success\":true", StringComparison.OrdinalIgnoreCase) >= 0) return true;
        if (Regex.IsMatch(trimmed, "^[A-Z2-7]{16,64}$")) return true;
        return false;
    }

    private static string SuccessJson()
    {
        return "{\"success\": true, \"error\": \"\"}";
    }

    private static string ErrorJson(string error)
    {
        string safeErr = (error ?? "unknown_error").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", " ");
        return "{\"success\": false, \"error\": \"" + safeErr + "\"}";
    }

    private static string FormatError(string actionName, string error)
    {
        string safeErr = (error ?? "unknown_error").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", " ");
        switch (actionName)
        {
            case "Rename":
            case "UpAvatarWWW":
            case "UpCoverWWW":
            case "DangStoryWWW":
            case "UnlockProfile":
            case "LockProfile":
            case "ProfessionalMode":
            case "TurnOn2FA":
            case "Bat2FA":
            case "TurnOff2FA":
            case "Tat2FA":
                return "{\"success\": false, \"error\": \"" + safeErr + "\"}";
            default:
                return safeErr;
        }
    }
    #endregion
}
