using System;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;

public partial class fMain
{
    private static bool HasExpectedProfileIdentity(Chrome browser)
    {
        if (!Commom.IsUid(browser.B4208531)) return true;
        try
        {
            return browser.ChromeDriver_0.Manage().Cookies.GetCookieNamed("c_user")?.Value == browser.B4208531;
        }
        catch (WebDriverException) { return false; }
    }

    private void AddProfileSessionMenu()
    {
        var keep = new ToolStripMenuItem("Giữ phiên Facebook cho lần mở sau")
        {
            CheckOnClick = true,
            Checked = ProfileSession.Enabled,
            ToolTipText = "Ưu tiên profile cố định; bỏ qua tùy chọn không dùng profile, xóa profile và tự đăng xuất khi chạy."
        };
        keep.CheckedChanged += (sender, args) =>
        {
            C5034B95.smethod_0("configGeneral").method_4("preserveFacebookSessions", keep.Checked);
            C5034B95.smethod_1("configGeneral");
        };
        var login = new ToolStripMenuItem("Tự đăng nhập Facebook và lưu phiên");
        login.Click += (sender, args) =>
        {
            keep.Checked = true;
            var options = new GClass4();
            options.method_4("OpenBrowser", true);
            options.method_4("ManualFacebookLogin", true);
            method_12(options);
        };
        toolStripMenuItem_2.DropDownItems.Insert(0, login);
        toolStripMenuItem_2.DropDownItems.Add(new ToolStripSeparator());
        toolStripMenuItem_2.DropDownItems.Add(keep);
    }

    private void RunManualFacebookLogin(int row, Chrome browser)
    {
        string status = "Đã đóng trình duyệt; chưa xác nhận đăng nhập.";
        var autofill = new FacebookLoginAutofill();
        bool preferEmail = C5034B95.smethod_0("configInteractGeneral").method_2("typeLogin") == 1;
        string account = preferEmail && !string.IsNullOrWhiteSpace(browser.F8A3B83F)
            ? browser.F8A3B83F : browser.B4208531;
        if (string.IsNullOrWhiteSpace(account)) account = browser.F8A3B83F;
        try
        {
            browser.method_12("https://www.facebook.com/");
            method_130(row, "Đang kiểm tra phiên và tự điền thông tin của dòng tài khoản...");
            while (!Base.smethod_5() && !browser.CD930D04())
            {
                try
                {
                    var driver = browser.ChromeDriver_0;
                    Uri current;
                    if (Uri.TryCreate(driver.Url, UriKind.Absolute, out current) && FacebookLoginAutofill.IsFacebookUrl(driver.Url))
                    {
                        string modalStatus = autofill.DismissModalsAndAlerts(driver);
                        if (!string.IsNullOrEmpty(modalStatus))
                        {
                            method_130(row, modalStatus);
                        }

                        var uid = driver.Manage().Cookies.GetCookieNamed("c_user");
                        var session = driver.Manage().Cookies.GetCookieNamed("xs");
                        bool challenge = current.AbsolutePath.Contains("checkpoint") || current.AbsolutePath.Contains("two_step_verification")
                            || driver.FindElements(By.CssSelector("input[name='approvals_code'],input[autocomplete='one-time-code'],iframe[src*='captcha']")).Count > 0;
                        bool loginForm = driver.FindElements(By.CssSelector("input[type='password']")).Count > 0;
                        bool navigation = driver.FindElements(By.CssSelector("[role='navigation']")).Count > 0;
                        if (uid != null && !string.IsNullOrEmpty(uid.Value) && session != null && !challenge && !loginForm && navigation)
                        {
                            string expected = browser.B4208531;
                            if (Commom.IsUid(expected) && expected != uid.Value)
                                status = "Sai tài khoản trong profile. Hãy đăng xuất trên Facebook và đăng nhập đúng UID của dòng này.";
                            else
                                status = "Đã nhận phiên Facebook. Đóng cửa sổ để hoàn tất lưu; lần sau mở lại profile này.";
                        }
                        else if (challenge)
                            status = autofill.TryFill2FA(driver, browser.A1BF36A2);
                        else if (loginForm)
                            status = autofill.TryLogin(driver, account, browser.C234EEAA);
                        else
                            status = "Đang chờ Facebook xác nhận phiên. Nếu có yêu cầu xác minh, hãy hoàn tất trên cửa sổ.";
                        method_130(row, status);
                    }
                }
                catch (WebDriverException) { /* Closing or navigating the window can race with polling. */ }
                Thread.Sleep(1000);
            }
        }
        catch (Exception)
        {
            status = "Không kiểm tra được phiên Facebook. Mở lại profile để kiểm tra đăng nhập.";
        }
        finally
        {
            browser.A4B307B3(30);
            method_130(row, Base.smethod_5() ? "Đã dừng đăng nhập; giữ lại dữ liệu profile." : status.Replace("Đã nhận phiên Facebook. Đóng cửa sổ để hoàn tất lưu; lần sau mở lại profile này.", "Đã đóng và giữ profile Facebook. Có thể mở lại hoặc chạy tương tác."));
        }
    }
}
