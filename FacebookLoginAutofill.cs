using System;
using System.Linq;
using OpenQA.Selenium;

internal sealed class FacebookLoginAutofill
{
    private readonly Func<string, bool> isTrusted;
    public bool Attempted { get; private set; }
    public bool TwoFaAttempted { get; private set; }
    private string lastFilledOtp = "";
    private DateTime lastOtpTime = DateTime.MinValue;

    public FacebookLoginAutofill() : this(IsFacebookUrl) { }
    internal FacebookLoginAutofill(Func<string, bool> isTrusted) { this.isTrusted = isTrusted; }

    public string DismissModalsAndAlerts(IWebDriver driver)
    {
        if (driver == null) return "";
        try
        {
            if (!isTrusted(driver.Url)) return "";
            var jsExecutor = driver as IJavaScriptExecutor;
            if (jsExecutor != null)
            {
                string script = @"
(function() {
    var handled = [];
    try {
        var alertBtns = document.querySelectorAll('button[name*=""This was me""], button[name*=""submit[This was me]""], button[name*=""submit[Continue]""], [role=""button""], button');
        for (var i = 0; i < alertBtns.length; i++) {
            var b = alertBtns[i];
            var name = (b.getAttribute('name') || '').toLowerCase();
            var aria = (b.getAttribute('aria-label') || '').toLowerCase();
            var txt = (b.innerText || '').trim().toLowerCase();
            if (name.indexOf('this was me') !== -1 || aria.indexOf('this was me') !== -1 || txt === 'this was me'
                || aria.indexOf('đúng là tôi') !== -1 || txt === 'đúng là tôi'
                || aria.indexOf('đây là tôi') !== -1 || txt === 'đây là tôi') {
                b.click();
                handled.push('confirmed_this_was_me');
                break;
            }
        }
        var dialogs = document.querySelectorAll('[role=""dialog""], [data-dialog=""1""]');
        for (var j = 0; j < dialogs.length; j++) {
            var d = dialogs[j];
            var dText = (d.innerText || '').toLowerCase();
            if (dText.indexOf('remember password') !== -1 || dText.indexOf('lưu mật khẩu') !== -1 
                || dText.indexOf('click your picture') !== -1 || dText.indexOf('nhấp vào ảnh') !== -1) {
                var dBtns = d.querySelectorAll('[role=""button""], button');
                for (var k = 0; k < dBtns.length; k++) {
                    var btn = dBtns[k];
                    var btnAria = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                    var btnTxt = (btn.innerText || '').toLowerCase().trim();
                    if (btnAria === 'ok' || btnTxt === 'ok' 
                        || btnAria === 'lưu mật khẩu' || btnTxt === 'lưu mật khẩu'
                        || btnAria === 'not now' || btnTxt === 'not now'
                        || btnAria === 'lúc khác' || btnTxt === 'lúc khác'
                        || btnAria === 'để sau' || btnTxt === 'để sau') {
                        btn.click();
                        handled.push('dismissed_remember_password');
                        break;
                    }
                }
            }
        }
        for (var m = 0; m < dialogs.length; m++) {
            var dlg = dialogs[m];
            var closeBtn = dlg.querySelector('[aria-label=""Close""], [aria-label=""Đóng""], [aria-label=""Not Now""], [aria-label=""Not now""], [aria-label=""Lúc khác""]');
            if (closeBtn) {
                closeBtn.click();
                handled.push('closed_dialog');
            }
        }
        var cookieBtn = document.querySelector('[data-cookiebanner=""accept_button""], [data-testid=""cookie-policy-manage-dialog""] [aria-label]:not([aria-disabled=""true""])');
        if (cookieBtn) {
            cookieBtn.click();
            handled.push('accepted_cookies');
        }
    } catch (e) {
        return 'error: ' + e.message;
    }
    return handled.join(';') || '';
})();";
                object res = jsExecutor.ExecuteScript(script);
                if (res != null)
                {
                    string action = res.ToString();
                    if (action.Contains("confirmed_this_was_me")) return "Đã tự động xác nhận cảnh báo đăng nhập (Đúng là tôi).";
                    if (action.Contains("dismissed_remember_password")) return "Đã tự động xử lý popup Lưu mật khẩu Facebook.";
                    if (action.Contains("closed_dialog")) return "Đã tự động đóng thông báo Facebook.";
                }
            }
        }
        catch (WebDriverException) { }
        return "";
    }

    internal static bool IsFacebookUrl(string address)
    {
        Uri uri;
        return Uri.TryCreate(address, UriKind.Absolute, out uri) && uri.Scheme == "https"
            && (uri.Host.Equals("facebook.com", StringComparison.OrdinalIgnoreCase)
                || uri.Host.EndsWith(".facebook.com", StringComparison.OrdinalIgnoreCase));
    }

    public string TryLogin(IWebDriver driver, string account, string password)
    {
        if (Attempted) return "Đã gửi đăng nhập một lần; đang chờ Facebook. Nếu báo sai thông tin, hãy kiểm tra dữ liệu tài khoản.";
        if (!isTrusted(driver.Url)) return "Chờ trang đăng nhập Facebook.";
        if (string.IsNullOrWhiteSpace(account) || string.IsNullOrEmpty(password))
            return "Thiếu UID/email hoặc mật khẩu trong dòng tài khoản. Bổ sung dữ liệu rồi chạy lại.";

        var login = driver.FindElements(By.CssSelector("input[name='email'],input[name='login'],input[autocomplete='username'],input[type='email'],#m_login_email"))
            .FirstOrDefault(e => e.Displayed && e.Enabled);
        var secret = driver.FindElements(By.CssSelector("input[name='pass'],input[type='password'],#m_login_password"))
            .FirstOrDefault(e => e.Displayed && e.Enabled);
        if (login == null || secret == null) return "Đang chờ ô tài khoản và mật khẩu Facebook...";

        ISearchContext scope = secret.FindElements(By.XPath("ancestor::form[1]")).FirstOrDefault();
        if (scope == null) scope = driver;
        var submit = scope.FindElements(By.CssSelector("button[name='login'],button[type='submit'],input[type='submit'],[role='button'][aria-label='Log in'],[role='button'][aria-label='Đăng nhập']"))
            .FirstOrDefault(e => e.Displayed && e.Enabled);
        if (submit == null) return "Chưa tìm thấy nút đăng nhập; bạn có thể bấm trực tiếp trên Facebook.";
        // One attempt per opened profile, including a click whose response is interrupted.
        Attempted = true;
        try
        {
            if (!isTrusted(driver.Url)) return "Trang đã chuyển hướng; không điền thông tin đăng nhập.";
            login.Clear();
            login.SendKeys(account.Trim());
            secret.Clear();
            secret.SendKeys(password);
            if (!isTrusted(driver.Url)) return "Trang đã chuyển hướng; không gửi đăng nhập.";
            submit.Click();
            return "Đã điền tài khoản/mật khẩu và bấm đăng nhập. Đang chờ Facebook...";
        }
        catch (WebDriverException)
        {
            return "Không hoàn tất thao tác đăng nhập. Kiểm tra cửa sổ Facebook hoặc đóng và mở lại profile để thử lại.";
        }
    }

    public string TryFill2FA(IWebDriver driver, string twoFaSecret)
    {
        if (string.IsNullOrWhiteSpace(twoFaSecret))
        {
            return "Facebook yêu cầu xác thực 2FA nhưng tài khoản chưa có khóa 2FA (cFa2). Vui lòng nhập mã trên trình duyệt.";
        }

        if (!isTrusted(driver.Url))
        {
            return "Chờ trang xác thực Facebook.";
        }

        try
        {
            // First check if there's a continue button for post-2FA (e.g. "Save Browser" / "Lưu trình duyệt")
            var continueBtn = driver.FindElements(By.CssSelector(
                "button[id='checkpointSubmitButton'],#checkpointSubmitButton button,button[name='submit[Continue]'],button[name='submit[This was me]'],[role='button'][aria-label='Tiếp tục'],[role='button'][aria-label='Continue'],[role='button'][aria-label='Đây là tôi']"))
                .FirstOrDefault(e => e.Displayed && e.Enabled);

            // Find 2FA OTP input field
            var otpInput = driver.FindElements(By.CssSelector(
                "input[name='approvals_code'],input[id='approvals_code'],input[autocomplete='one-time-code'],input[inputmode='numeric'],input[name='code'],input[placeholder*='code'],input[placeholder*='mã'],input[aria-label*='code'],input[aria-label*='mã']"))
                .FirstOrDefault(e => e.Displayed && e.Enabled);

            if (otpInput != null)
            {
                // Only fill once every 12 seconds to avoid spamming if OTP is still being processed
                if ((DateTime.Now - lastOtpTime).TotalSeconds < 12 && !string.IsNullOrEmpty(lastFilledOtp))
                {
                    return $"Đã gửi mã 2FA ({lastFilledOtp}); đang chờ Facebook xử lý...";
                }

                string otp = Commom.smethod_62(twoFaSecret.Trim().Replace(" ", ""));
                if (string.IsNullOrEmpty(otp))
                {
                    return "Không thể tạo mã OTP từ khóa 2FA. Kiểm tra lại chuỗi bí mật 2FA của tài khoản.";
                }

                otpInput.Clear();
                otpInput.SendKeys(otp);
                lastFilledOtp = otp;
                lastOtpTime = DateTime.Now;
                TwoFaAttempted = true;

                // Find submit button
                var submit = driver.FindElements(By.CssSelector(
                    "button[id='checkpointSubmitButton'],#checkpointSubmitButton button,button[name='submit[Continue]'],button[type='submit'],input[type='submit'],[role='button'][aria-label='Tiếp tục'],[role='button'][aria-label='Continue'],[role='button'][aria-label='Submit'],[role='button'][aria-label='Xác nhận']"))
                    .FirstOrDefault(e => e.Displayed && e.Enabled);

                if (submit != null)
                {
                    submit.Click();
                    return $"Đã tự động lấy mã 2FA ({otp}) và bấm xác nhận. Đang chờ Facebook...";
                }
                else
                {
                    // Fallback: try pressing Enter in the OTP field
                    otpInput.SendKeys(Keys.Enter);
                    return $"Đã tự động lấy mã 2FA ({otp}) và gửi phím Enter. Đang chờ Facebook...";
                }
            }
            else if (continueBtn != null)
            {
                // On checkpoint continue screens (like "Save browser" or "Someone tried to log in")
                continueBtn.Click();
                return "Đã tự động bấm Tiếp tục trên màn hình xác thực Facebook.";
            }

            return "Facebook yêu cầu xác thực 2FA. Đang tìm ô nhập mã OTP...";
        }
        catch (WebDriverException)
        {
            return "Đang chờ hoàn tất xác thực 2FA trên trình duyệt...";
        }
    }
}
