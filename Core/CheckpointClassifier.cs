using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Các phân loại trạng thái Checkpoint của Facebook.
/// </summary>
public enum CheckpointType
{
    /// <summary>Không phát hiện checkpoint (trang bình thường, đã đăng nhập hoặc trang trống).</summary>
    None,

    /// <summary>Checkpoint 282: Xác minh hình ảnh / Video khuôn mặt / Giấy tờ tùy thân (/checkpoint/1501092823525282).</summary>
    Checkpoint282_PhotoVerify,

    /// <summary>Checkpoint 956: Khóa tài khoản / Khóa két sắt bắt đầu (/checkpoint/828281030927956).</summary>
    Checkpoint956_Lockout,

    /// <summary>Yêu cầu nhập lại mật khẩu hiện tại (re-enter your password / nhập lại mật khẩu).</summary>
    PasswordRequired,

    /// <summary>Yêu cầu nhập mã OTP gửi về Email liên kết (Email OTP).</summary>
    EmailOTP,

    /// <summary>Yêu cầu nhập mã OTP gửi về số điện thoại qua tin nhắn SMS (SMS OTP).</summary>
    SmsOTP,

    /// <summary>Xác thực 2 yếu tố 2FA (Two-Factor Authentication / input approvals_code).</summary>
    TwoFactorAuth,

    /// <summary>Xác thực bên thứ ba Google OAuth (auth_platform/login_with_third_party).</summary>
    GoogleOAuth,

    /// <summary>Tài khoản bị đình chỉ 180 ngày (/accounts/suspended / We suspended your account).</summary>
    AccountSuspended,

    /// <summary>Tài khoản bị vô hiệu hóa hoàn toàn (/checkpoint/disabled / Your account has been disabled).</summary>
    AccountDisabled,

    /// <summary>Checkpoint Captcha ảnh Facebook (/captcha/tfbimage / captcha_response).</summary>
    ImageCaptcha,

    /// <summary>Checkpoint chưa xác định hoặc dạng bảo mật mới khác.</summary>
    Unknown
}

/// <summary>
/// Module tự động phân loại và xử lý các loại Checkpoint Facebook.
/// </summary>
public static class CheckpointClassifier
{
    /// <summary>
    /// Event thông báo tiến trình xử lý cho giao diện người dùng hoặc logger.
    /// </summary>
    public static event Action<string> OnStatusUpdate;

    #region 1. Classification Engine

    /// <summary>
    /// Phân tích URL và nội dung trang (pageSource) để xác định chính xác loại Checkpoint Facebook.
    /// </summary>
    /// <param name="currentUrl">URL hiện tại của trình duyệt.</param>
    /// <param name="pageSource">Mã nguồn HTML hoặc text hiển thị của trang.</param>
    /// <returns>Giá trị CheckpointType tương ứng.</returns>
    public static CheckpointType Classify(string currentUrl, string pageSource)
    {
        string url = currentUrl ?? string.Empty;
        string src = pageSource ?? string.Empty;

        // Nếu cả URL và pageSource đều rỗng -> Không có checkpoint
        if (string.IsNullOrWhiteSpace(url) && string.IsNullOrWhiteSpace(src))
        {
            return CheckpointType.None;
        }

        // =========================================================================
        // 1. AccountSuspended: Đình chỉ tài khoản 180 ngày
        // URL: /accounts/suspended
        // Keywords: 'We suspended your account', 'Chúng tôi đã đình chỉ tài khoản', '180 days', '180 ngày'
        // =========================================================================
        if (ContainsIgnoreCase(url, "/accounts/suspended") ||
            ContainsIgnoreCase(url, "/account/suspended") ||
            ContainsIgnoreCase(src, "We suspended your account") ||
            ContainsIgnoreCase(src, "Chúng tôi đã đình chỉ tài khoản") ||
            ContainsIgnoreCase(src, "đình chỉ tài khoản của bạn") ||
            ((ContainsIgnoreCase(src, "180 days") || ContainsIgnoreCase(src, "180 ngày")) &&
             (ContainsIgnoreCase(src, "suspended") || ContainsIgnoreCase(src, "đình chỉ") || ContainsIgnoreCase(src, "disagree") || ContainsIgnoreCase(src, "phản đối"))))
        {
            return CheckpointType.AccountSuspended;
        }

        // =========================================================================
        // 2. AccountDisabled: Vô hiệu hóa tài khoản vĩnh viễn
        // URL: /checkpoint/disabled, /checkpoint/block
        // Keywords: 'Your account has been disabled', 'Tài khoản của bạn đã bị vô hiệu hóa', 'Account Disabled'
        // =========================================================================
        if (ContainsIgnoreCase(url, "/checkpoint/disabled") ||
            ContainsIgnoreCase(url, "/checkpoint/block") ||
            ContainsIgnoreCase(src, "Your account has been disabled") ||
            ContainsIgnoreCase(src, "Tài khoản của bạn đã bị vô hiệu hóa") ||
            ContainsIgnoreCase(src, "Tài khoản đã bị vô hiệu hóa") ||
            ContainsIgnoreCase(src, "Tài khoản bị vô hiệu hóa") ||
            ContainsIgnoreCase(src, "Account Disabled") ||
            ContainsIgnoreCase(src, "You can't use Facebook because your account") ||
            ContainsIgnoreCase(src, "Bạn không thể sử dụng Facebook vì tài khoản của bạn"))
        {
            return CheckpointType.AccountDisabled;
        }

        // =========================================================================
        // 3. GoogleOAuth: Luồng đăng nhập trung gian Google OAuth
        // URL: auth_platform/login_with_third_party
        // Keywords: 'login_with_third_party', 'Sign in with Google', 'Đăng nhập bằng Google'
        // =========================================================================
        if (ContainsIgnoreCase(url, "auth_platform/login_with_third_party") ||
            ContainsIgnoreCase(url, "login_with_third_party") ||
            ContainsIgnoreCase(url, "accounts.google.com") ||
            ContainsIgnoreCase(src, "auth_platform/login_with_third_party") ||
            ContainsIgnoreCase(src, "login_with_third_party"))
        {
            return CheckpointType.GoogleOAuth;
        }

        // =========================================================================
        // 4. Checkpoint282_PhotoVerify: Checkpoint 282 xác minh ảnh / video selfie
        // URL: /checkpoint/1501092823525282
        // Keywords: '1501092823525282', 'Tải lên ảnh của chính bạn', 'Take a video of your face', 'video selfie', 'Upload your ID'
        // =========================================================================
        if (ContainsIgnoreCase(url, "1501092823525282") ||
            ContainsIgnoreCase(src, "1501092823525282") ||
            ContainsIgnoreCase(src, "Tải lên ảnh của chính bạn") ||
            ContainsIgnoreCase(src, "Tải ảnh của bạn lên") ||
            ContainsIgnoreCase(src, "Upload a photo of yourself") ||
            ContainsIgnoreCase(src, "Take a video of your face") ||
            ContainsIgnoreCase(src, "Quay video khuôn mặt") ||
            ContainsIgnoreCase(src, "video selfie") ||
            ContainsIgnoreCase(src, "Tải lên giấy tờ tùy thân") ||
            ContainsIgnoreCase(src, "Upload your ID") ||
            ContainsIgnoreCase(src, "chụp ảnh khuôn mặt"))
        {
            return CheckpointType.Checkpoint282_PhotoVerify;
        }

        // =========================================================================
        // 5. Checkpoint956_Lockout: Checkpoint 956 khóa két sắt bắt đầu
        // URL: /checkpoint/828281030927956
        // Keywords: '828281030927956', 'Your account has been locked', 'Tài khoản của bạn đã bị khóa'
        // =========================================================================
        if (ContainsIgnoreCase(url, "828281030927956") ||
            ContainsIgnoreCase(src, "828281030927956") ||
            ContainsIgnoreCase(src, "Your account has been locked") ||
            ContainsIgnoreCase(src, "Tài khoản của bạn đã bị khóa") ||
            ContainsIgnoreCase(src, "Chúng tôi đã khóa tài khoản của bạn") ||
            ContainsIgnoreCase(src, "We locked your account"))
        {
            return CheckpointType.Checkpoint956_Lockout;
        }

        // =========================================================================
        // 6. TwoFactorAuth: Xác thực 2 yếu tố (2FA)
        // Keywords: 'approvals_code' (OTP input name), 'Two-factor authentication', 'Xác thực 2 yếu tố'
        // =========================================================================
        if (ContainsIgnoreCase(src, "approvals_code") ||
            ContainsIgnoreCase(url, "two_step_verification") ||
            ContainsIgnoreCase(url, "two_factor") ||
            ContainsIgnoreCase(url, "checkpoint/login_approvals") ||
            ContainsIgnoreCase(src, "Two-factor authentication") ||
            ContainsIgnoreCase(src, "Xác thực 2 yếu tố") ||
            ContainsIgnoreCase(src, "Xác thực hai yếu tố") ||
            ContainsIgnoreCase(src, "mã từ ứng dụng xác thực") ||
            ContainsIgnoreCase(src, "authenticator app") ||
            ContainsIgnoreCase(src, "code generator") ||
            ContainsIgnoreCase(src, "Trình tạo mã"))
        {
            return CheckpointType.TwoFactorAuth;
        }

        // =========================================================================
        // 7. EmailOTP: Yêu cầu nhập mã OTP gửi về Email
        // URL: recover_method=send_email
        // Keywords: 'we sent a code to your email', 'chúng tôi đã gửi mã đến email', 'recovery_code', 'gửi mã qua email'
        // =========================================================================
        if (ContainsIgnoreCase(url, "recover_method=send_email") ||
            ContainsIgnoreCase(src, "recover_method=send_email") ||
            ContainsIgnoreCase(src, "name=\"recovery_code\"") ||
            ContainsIgnoreCase(src, "id=\"recovery_code_entry\"") ||
            ContainsIgnoreCase(src, "name=\"email_code\"") ||
            ContainsIgnoreCase(src, "gửi mã qua email") ||
            ContainsIgnoreCase(src, "gửi mã đến email") ||
            ContainsIgnoreCase(src, "send code to your email") ||
            ContainsIgnoreCase(src, "send code via email") ||
            ContainsIgnoreCase(src, "chúng tôi đã gửi mã đến email") ||
            ContainsIgnoreCase(src, "we sent a code to your email") ||
            (ContainsIgnoreCase(src, "check your email") && (ContainsIgnoreCase(src, "code") || ContainsIgnoreCase(src, "security"))) ||
            (ContainsIgnoreCase(src, "kiểm tra email") && (ContainsIgnoreCase(src, "mã") || ContainsIgnoreCase(src, "bảo mật"))))
        {
            return CheckpointType.EmailOTP;
        }

        // =========================================================================
        // 8. SmsOTP: Yêu cầu nhập mã OTP gửi về SMS
        // URL: recover_method=send_sms
        // Keywords: 'send code via SMS', 'gửi mã qua SMS', 'tin nhắn văn bản', 'send a text message'
        // =========================================================================
        if (ContainsIgnoreCase(url, "recover_method=send_sms") ||
            ContainsIgnoreCase(src, "recover_method=send_sms") ||
            ContainsIgnoreCase(src, "gửi mã qua SMS") ||
            ContainsIgnoreCase(src, "gửi mã qua tin nhắn SMS") ||
            ContainsIgnoreCase(src, "send code via SMS") ||
            ContainsIgnoreCase(src, "send code to your phone") ||
            ContainsIgnoreCase(src, "gửi mã đến số điện thoại") ||
            ContainsIgnoreCase(src, "tin nhắn văn bản") ||
            ContainsIgnoreCase(src, "send a text message") ||
            ContainsIgnoreCase(src, "mã xác nhận đã gửi đến số điện thoại"))
        {
            return CheckpointType.SmsOTP;
        }

        // =========================================================================
        // 9. PasswordRequired: Yêu cầu nhập lại mật khẩu
        // Keywords: 're-enter your password', 'nhập lại mật khẩu'
        // =========================================================================
        if (ContainsIgnoreCase(src, "re-enter your password") ||
            ContainsIgnoreCase(src, "nhập lại mật khẩu") ||
            ContainsIgnoreCase(src, "xác nhận lại mật khẩu") ||
            ContainsIgnoreCase(src, "vui lòng nhập lại mật khẩu") ||
            ContainsIgnoreCase(src, "please re-enter your password") ||
            ContainsIgnoreCase(src, "nhập mật khẩu để tiếp tục") ||
            ContainsIgnoreCase(src, "enter your password to continue"))
        {
            return CheckpointType.PasswordRequired;
        }

        // =========================================================================
        // 9.5. Checkpoint Captcha hình ảnh Facebook (/captcha/tfbimage / captcha_response)
        // =========================================================================
        if (ContainsIgnoreCase(url, "captcha/tfbimage") ||
            ContainsIgnoreCase(src, "facebook.com/captcha/tfbimage") ||
            ContainsIgnoreCase(src, "name=\"captcha_response\"") ||
            ContainsIgnoreCase(src, "id=\"captcha_response\"") ||
            ContainsIgnoreCase(src, "Nhập các ký tự bạn nhìn thấy trong hình ảnh") ||
            ContainsIgnoreCase(src, "Enter the characters you see in the image"))
        {
            return CheckpointType.ImageCaptcha;
        }

        // =========================================================================
        // 10. Checkpoint Chưa xác định (Unknown): Các checkpoint khác
        // URL chứa /checkpoint/, /login/checkpoint, /challenge/ hoặc các dấu hiệu bảo mật
        // =========================================================================
        if (ContainsIgnoreCase(url, "/checkpoint/") ||
            ContainsIgnoreCase(url, "/login/checkpoint") ||
            ContainsIgnoreCase(url, "/challenge/") ||
            ContainsIgnoreCase(url, "facebook.com/nt/screen/?params=") ||
            ContainsIgnoreCase(src, "id=\"checkpointSubmitButton\"") ||
            ContainsIgnoreCase(src, "id=\"checkpointBottomBar\"") ||
            ContainsIgnoreCase(src, "name=\"verification_method\"") ||
            ContainsIgnoreCase(src, "help us confirm that you own this account") ||
            ContainsIgnoreCase(src, "hãy giúp chúng tôi xác nhận") ||
            ContainsIgnoreCase(src, "bảo vệ tài khoản của bạn") ||
            ContainsIgnoreCase(src, "protect your account"))
        {
            return CheckpointType.Unknown;
        }

        // 11. Trang bình thường, không có checkpoint
        return CheckpointType.None;
    }

    /// <summary>
    /// Overload phân loại Checkpoint trực tiếp từ đối tượng ChromeDriver đang chạy.
    /// </summary>
    /// <param name="driver">Đối tượng ChromeDriver hiện tại.</param>
    /// <returns>Loại Checkpoint xác định được.</returns>
    public static CheckpointType Classify(ChromeDriver driver)
    {
        if (driver == null)
        {
            return CheckpointType.None;
        }

        try
        {
            string url = driver.Url ?? string.Empty;
            string pageSource = driver.PageSource ?? string.Empty;
            return Classify(url, pageSource);
        }
        catch
        {
            return CheckpointType.Unknown;
        }
    }

    #endregion

    #region 2. Auto-Solve Email OTP Engine

    /// <summary>
    /// Tự động đọc mã xác thực OTP 6 số từ email Facebook qua giao thức IMAP (MailKit) và điền vào form trên trình duyệt.
    /// </summary>
    /// <param name="driver">Đối tượng ChromeDriver đang điều khiển phiên duyệt web.</param>
    /// <param name="imapHost">Địa chỉ IMAP server (VD: imap-mail.outlook.com đối với Hotmail/Outlook). Để trống sẽ tự nhận diện theo đuôi email.</param>
    /// <param name="imapPort">Cổng IMAP (mặc định 993 SSL).</param>
    /// <param name="email">Địa chỉ email nhận OTP.</param>
    /// <param name="emailPassword">Mật khẩu của email (hoặc App Password).</param>
    /// <returns>True nếu đọc mã và submit form thành công; False nếu thất bại hoặc timeout.</returns>
    public static bool TryAutoSolveEmailOTP(
        ChromeDriver driver,
        string imapHost,
        int imapPort,
        string email,
        string emailPassword)
    {
        return TryAutoSolveEmailOTP(driver, imapHost, imapPort, email, emailPassword, 60);
    }

    /// <summary>
    /// Tự động đọc mã xác thực OTP 6 số từ email Facebook qua giao thức IMAP (MailKit) và điền vào form với thời gian chờ tùy chỉnh.
    /// </summary>
    /// <param name="driver">Đối tượng ChromeDriver đang điều khiển phiên duyệt web.</param>
    /// <param name="imapHost">Địa chỉ IMAP server (VD: imap-mail.outlook.com). Để trống sẽ tự nhận diện theo đuôi email.</param>
    /// <param name="imapPort">Cổng IMAP (mặc định 993 SSL).</param>
    /// <param name="email">Địa chỉ email nhận OTP.</param>
    /// <param name="emailPassword">Mật khẩu email.</param>
    /// <param name="timeoutSeconds">Thời gian tối đa chờ email gửi về (giây, mặc định 60s).</param>
    /// <returns>True nếu thành công; False nếu thất bại.</returns>
    public static bool TryAutoSolveEmailOTP(
        ChromeDriver driver,
        string imapHost,
        int imapPort,
        string email,
        string emailPassword,
        int timeoutSeconds)
    {
        if (driver == null)
        {
            OnStatusUpdate?.Invoke("[AutoSolveEmailOTP] Lỗi: ChromeDriver không khả dụng (null).");
            return false;
        }

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(emailPassword))
        {
            OnStatusUpdate?.Invoke("[AutoSolveEmailOTP] Lỗi: Email hoặc mật khẩu email trống.");
            return false;
        }

        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Bước 1: Xử lý màn hình tiền đề (nếu Facebook yêu cầu chọn phương thức nhận mã trước khi hiện ô input)
            HandlePreOtpSelectionScreen(driver, js);

            // Bước 2: Dùng MailKit IMAP đọc mã OTP 6 số từ hộp thư
            OnStatusUpdate?.Invoke($"[AutoSolveEmailOTP] Bắt đầu đọc mã OTP từ hòm thư {email}...");
            string otpCode = ExtractFacebookOtpFromImap(imapHost, imapPort, email, emailPassword, timeoutSeconds);

            if (string.IsNullOrWhiteSpace(otpCode))
            {
                OnStatusUpdate?.Invoke("[AutoSolveEmailOTP] Không lấy được mã OTP 6 chữ số từ Facebook trong thời gian quy định.");
                return false;
            }

            OnStatusUpdate?.Invoke($"[AutoSolveEmailOTP] Đã lấy thành công mã OTP: [{otpCode}]. Đang điền vào form...");

            // Bước 3: Tìm ô input và điền mã OTP vào form
            bool filled = FillOtpCodeIntoForm(driver, js, otpCode);
            if (!filled)
            {
                OnStatusUpdate?.Invoke("[AutoSolveEmailOTP] Không tìm thấy ô nhập mã OTP trên giao diện Facebook.");
                return false;
            }

            Thread.Sleep(1000);

            // Bước 4: Nhấn nút Submit / Tiếp tục / Xác nhận
            bool submitted = SubmitOtpForm(driver, js);
            if (!submitted)
            {
                OnStatusUpdate?.Invoke("[AutoSolveEmailOTP] Không tìm thấy hoặc không thể kích hoạt nút Tiếp tục/Xác nhận.");
                return false;
            }

            Thread.Sleep(2500);

            OnStatusUpdate?.Invoke($"[AutoSolveEmailOTP] Đã hoàn tất nhập và gửi mã OTP [{otpCode}] thành công!");
            return true;
        }
        catch (Exception ex)
        {
            OnStatusUpdate?.Invoke($"[AutoSolveEmailOTP] Lỗi ngoại lệ trong quá trình giải OTP: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Sử dụng MailKit IMAP để kết nối hòm thư và trích xuất mã OTP 6 chữ số do Facebook gửi đến.
    /// Facebook gửi email có subject chứa 'FB-' hoặc 'Facebook' với mã 6 chữ số trong subject hoặc body.
    /// </summary>
    /// <param name="imapHost">Host IMAP (VD: imap-mail.outlook.com). Để trống tự động nhận diện.</param>
    /// <param name="imapPort">Port IMAP (mặc định 993).</param>
    /// <param name="email">Email tài khoản.</param>
    /// <param name="emailPassword">Mật khẩu email.</param>
    /// <param name="timeoutSeconds">Thời gian chờ tối đa (giây).</param>
    /// <returns>Mã OTP 6 số nếu tìm thấy; chuỗi rỗng nếu không tìm thấy.</returns>
    public static string ExtractFacebookOtpFromImap(
        string imapHost,
        int imapPort,
        string email,
        string emailPassword,
        int timeoutSeconds = 60)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(emailPassword))
        {
            return string.Empty;
        }

        string resolvedHost = imapHost;
        int resolvedPort = imapPort <= 0 ? 993 : imapPort;

        // Tự động suy luận IMAP server nếu người dùng không truyền vào
        if (string.IsNullOrWhiteSpace(resolvedHost))
        {
            string lower = email.ToLowerInvariant();
            if (lower.EndsWith("@hotmail.com") || lower.EndsWith("@outlook.com") ||
                lower.EndsWith("@live.com") || lower.EndsWith("@msn.com") || lower.EndsWith("@windowslive.com"))
            {
                // IMAP Hotmail mặc định
                resolvedHost = "imap-mail.outlook.com";
            }
            else if (lower.EndsWith("@gmail.com"))
            {
                resolvedHost = "imap.gmail.com";
            }
            else if (lower.EndsWith("@yahoo.com"))
            {
                resolvedHost = "imap.mail.yahoo.com";
            }
            else
            {
                resolvedHost = "imap-mail.outlook.com";
            }
        }

        // Mốc thời gian tìm kiếm: chỉ chấp nhận thư đến trong vòng 10 phút gần nhất
        DateTime searchCutoff = DateTime.UtcNow.AddMinutes(-10);
        int startTick = Environment.TickCount;
        int maxWaitMs = Math.Min(60, Math.Max(10, timeoutSeconds)) * 1000; // Tối đa 60s timeout bảo vệ luồng bot
        int consecutiveErrors = 0;
        const int maxRetries = 3;

        OnStatusUpdate?.Invoke($"[IMAP] Đang kết nối tới máy chủ IMAP {resolvedHost}:{resolvedPort} ({email})...");

        while (Environment.TickCount - startTick < maxWaitMs)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    // Cấu hình TLS IMAP bảo vệ chống tấn công MITM:
                    // Chỉ chấp nhận chứng chỉ hợp lệ từ Trusted CA, hoặc kết nối tới localhost / proxy nội bộ
                    client.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                    {
                        if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None) return true;
                        // Chấp nhận nếu là kết nối qua localhost / IP nội bộ / mail bridge
                        if (resolvedHost == "127.0.0.1" || resolvedHost == "::1" || resolvedHost.Equals("localhost", StringComparison.OrdinalIgnoreCase)) return true;
                        // Từ chối tất cả các chứng chỉ giả mạo / không xác thực
                        return false;
                    };
                    client.Timeout = 8000; // 8s timeout cho mỗi thao tác socket tránh treo

                    SecureSocketOptions socketOptions = (resolvedPort == 993)
                        ? SecureSocketOptions.SslOnConnect
                        : SecureSocketOptions.Auto;

                    client.Connect(resolvedHost, resolvedPort, socketOptions);
                    client.Authenticate(email, emailPassword);
                    consecutiveErrors = 0; // Reset số lần lỗi nếu kết nối thành công

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    int count = inbox.Count;
                    if (count > 0)
                    {
                        // Quét tối đa 20 email mới nhất từ count - 1 lùi dần về trước
                        int fetchStart = Math.Max(0, count - 20);
                        var summaries = inbox.Fetch(fetchStart, count - 1,
                            MessageSummaryItems.Envelope | MessageSummaryItems.Flags | MessageSummaryItems.InternalDate);

                        for (int i = summaries.Count - 1; i >= 0; i--)
                        {
                            var summary = summaries[i];
                            DateTime msgTime = (summary.Envelope.Date ?? summary.InternalDate ?? DateTimeOffset.MinValue).UtcDateTime;

                            if (msgTime < searchCutoff && msgTime != DateTime.MinValue)
                            {
                                // Bỏ qua email gửi trước mốc thời gian bắt đầu phiên
                                continue;
                            }

                            string subject = summary.Envelope.Subject ?? string.Empty;
                            string from = summary.Envelope.From?.ToString() ?? string.Empty;

                            // Nhận diện email gửi từ Facebook: subject chứa 'FB-' hoặc 'Facebook', hoặc người gửi là facebookmail.com
                            bool isFacebook =
                                subject.IndexOf("FB-", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                subject.IndexOf("Facebook", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                from.IndexOf("facebookmail.com", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                from.IndexOf("account.meta.com", StringComparison.OrdinalIgnoreCase) >= 0;

                            if (!isFacebook)
                            {
                                continue;
                            }

                            // 1. Kiểm tra mã 6 chữ số trong Subject
                            Match mSub = Regex.Match(subject, @"FB-(\d{6})", RegexOptions.IgnoreCase);
                            if (mSub.Success)
                            {
                                string code = mSub.Groups[1].Value;
                                client.Disconnect(true);
                                return code;
                            }

                            mSub = Regex.Match(subject, @"\b(\d{6})\b");
                            if (mSub.Success)
                            {
                                string code = mSub.Groups[1].Value;
                                client.Disconnect(true);
                                return code;
                            }

                            // 2. Tải Body email để trích xuất mã 6 số trong nội dung
                            MimeMessage message = inbox.GetMessage(summary.Index);
                            string body = (message.TextBody ?? string.Empty) + " " + (message.HtmlBody ?? string.Empty);

                            // Mẫu 1: FB-123456
                            Match mBody = Regex.Match(body, @"FB-(\d{6})", RegexOptions.IgnoreCase);
                            if (mBody.Success)
                            {
                                string code = mBody.Groups[1].Value;
                                client.Disconnect(true);
                                return code;
                            }

                            // Mẫu 2: Tiền tố xác nhận + 6 chữ số
                            mBody = Regex.Match(body, @"(?:code|mã|mã xác nhận|security code|mã bảo mật|confirmation code|recovery code)[^\d]{1,30}(\d{6})\b", RegexOptions.IgnoreCase);
                            if (mBody.Success)
                            {
                                string code = mBody.Groups[1].Value;
                                client.Disconnect(true);
                                return code;
                            }

                            // Mẫu 3: Thẻ HTML số lớn (in đậm, font size to)
                            mBody = Regex.Match(body, @"(?:font-size[^>]*>|<strong>|<b>|\s)([0-9]{6})(?:<|\s)");
                            if (mBody.Success)
                            {
                                string code = mBody.Groups[1].Value;
                                client.Disconnect(true);
                                return code;
                            }

                            // Mẫu 4: Mã 6 chữ số độc lập
                            mBody = Regex.Match(body, @"(?<!\d)(\d{6})(?!\d)");
                            if (mBody.Success)
                            {
                                string code = mBody.Groups[1].Value;
                                client.Disconnect(true);
                                return code;
                            }
                        }
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                consecutiveErrors++;
                OnStatusUpdate?.Invoke($"[IMAP] Cảnh báo kết nối (lần {consecutiveErrors}/{maxRetries}): {ex.Message}");
                if (consecutiveErrors >= maxRetries)
                {
                    OnStatusUpdate?.Invoke($"[IMAP] Đã thử kết nối {maxRetries} lần không thành công, dừng để bảo vệ tiến trình.");
                    break;
                }
            }

            int elapsed = (Environment.TickCount - startTick) / 1000;
            int remaining = (maxWaitMs / 1000) - elapsed;
            if (remaining > 0)
            {
                OnStatusUpdate?.Invoke($"[IMAP] Đang đợi email mã từ Facebook ({remaining}s còn lại)...");
                Thread.Sleep(3000);
            }
            else
            {
                break;
            }
        }

        return string.Empty;
    }

    #endregion

    #region 3. DOM Automation Helpers

    /// <summary>
    /// Xử lý trường hợp Facebook hiển thị màn hình chọn phương thức nhận mã (ví dụ: chọn radio button Email).
    /// </summary>
    private static void HandlePreOtpSelectionScreen(ChromeDriver driver, IJavaScriptExecutor js)
    {
        try
        {
            string selectEmailScript = @"
                (function() {
                    try {
                        var radios = document.querySelectorAll('input[type=""radio""]');
                        for (var i = 0; i < radios.length; i++) {
                            var r = radios[i];
                            var val = (r.value || '').toLowerCase();
                            var parentText = (r.parentElement ? r.parentElement.innerText : '').toLowerCase();
                            if (val.indexOf('email') >= 0 || val.indexOf('send_email') >= 0 || parentText.indexOf('@') >= 0 || parentText.indexOf('email') >= 0) {
                                if (!r.checked) {
                                    r.click();
                                }
                                return 'selected_radio';
                            }
                        }

                        var labels = document.querySelectorAll('label, [role=""radio""]');
                        for (var j = 0; j < labels.length; j++) {
                            var lbl = labels[j];
                            var txt = (lbl.innerText || '').toLowerCase();
                            if (txt.indexOf('email') >= 0 || txt.indexOf('@') >= 0) {
                                lbl.click();
                                return 'clicked_label';
                            }
                        }
                    } catch(e) {}
                    return 'none';
                })()";

            object res = js.ExecuteScript(selectEmailScript);
            if (res != null && res.ToString() != "none")
            {
                Thread.Sleep(1000);
                SubmitOtpForm(driver, js);
                Thread.Sleep(2500);
            }
        }
        catch { }
    }

    /// <summary>
    /// Điền mã OTP 6 chữ số vào ô nhập trên form Facebook. Hỗ trợ cả single input và split digit inputs.
    /// </summary>
    private static bool FillOtpCodeIntoForm(ChromeDriver driver, IJavaScriptExecutor js, string otpCode)
    {
        try
        {
            // Cách 1: Tiêm JavaScript để cập nhật giá trị và kích hoạt đầy đủ input / change events cho React
            string fillJs = @"
                (function(code) {
                    try {
                        var selectors = [
                            'input[name=""recovery_code""]',
                            'input[id=""recovery_code_entry""]',
                            'input[name=""code""]',
                            'input[name=""email_code""]',
                            'input[name=""code_1""]',
                            'input[name=""approvals_code""]',
                            'input[autocomplete=""one-time-code""]',
                            'input[data-bloks-name=""bk.components.TextInput""]',
                            'input[type=""text""][maxlength=""6""]',
                            'input[type=""number""][maxlength=""6""]',
                            'input[maxlength=""6""]',
                            'input[placeholder*=""code"" i]',
                            'input[placeholder*=""mã"" i]'
                        ];

                        for (var i = 0; i < selectors.length; i++) {
                            var input = document.querySelector(selectors[i]);
                            if (input && input.offsetParent !== null) {
                                input.focus();
                                input.value = code;
                                input.dispatchEvent(new Event('input', { bubbles: true }));
                                input.dispatchEvent(new Event('change', { bubbles: true }));
                                return 'filled_single:' + selectors[i];
                            }
                        }

                        // Kiểm tra nếu là 6 ô nhập riêng biệt (mỗi ô 1 số)
                        var splitInputs = document.querySelectorAll('input[maxlength=""1""], input[data-index]');
                        if (splitInputs.length >= 6 && code.length === 6) {
                            for (var k = 0; k < 6; k++) {
                                splitInputs[k].focus();
                                splitInputs[k].value = code[k];
                                splitInputs[k].dispatchEvent(new Event('input', { bubbles: true }));
                                splitInputs[k].dispatchEvent(new Event('change', { bubbles: true }));
                            }
                            return 'filled_split';
                        }
                    } catch(e) {
                        return 'error:' + e.message;
                    }
                    return 'not_found';
                })(arguments[0]);";

            object res = js.ExecuteScript(fillJs, otpCode);
            if (res != null && (res.ToString().StartsWith("filled_single") || res.ToString() == "filled_split"))
            {
                return true;
            }

            // Cách 2: Fallback qua Selenium native WebDriver
            string[] selectors = new string[]
            {
                "input[name='recovery_code']",
                "input[id='recovery_code_entry']",
                "input[name='code']",
                "input[name='email_code']",
                "input[name='code_1']",
                "input[name='approvals_code']",
                "input[autocomplete='one-time-code']",
                "input[type='text'][maxlength='6']",
                "input[type='number'][maxlength='6']",
                "input[maxlength='6']"
            };

            foreach (var sel in selectors)
            {
                var elements = driver.FindElements(By.CssSelector(sel));
                foreach (var el in elements)
                {
                    if (el.Displayed && el.Enabled)
                    {
                        el.Clear();
                        el.SendKeys(otpCode);
                        return true;
                    }
                }
            }

            // Split inputs fallback bằng Selenium
            var splitList = driver.FindElements(By.CssSelector("input[maxlength='1']"));
            if (splitList.Count >= 6 && otpCode.Length == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    splitList[i].Clear();
                    splitList[i].SendKeys(otpCode[i].ToString());
                }
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Kích hoạt nút xác nhận/gửi form OTP sau khi đã điền mã.
    /// </summary>
    private static bool SubmitOtpForm(ChromeDriver driver, IJavaScriptExecutor js)
    {
        try
        {
            // 1. Thử click qua JavaScript
            string submitJs = @"
                (function() {
                    try {
                        var btnSelectors = [
                            'button[type=""submit""]',
                            'button[name=""reset_action""]',
                            'button[id=""checkpointSubmitButton""]',
                            'button[name=""submit[Continue]""]',
                            'button[name=""submit[Get Started]""]',
                            'button[name=""submit[Confirm]""]',
                            'button[value=""Continue""]',
                            'button[value=""Tiếp tục""]',
                            'input[type=""submit""]'
                        ];

                        for (var i = 0; i < btnSelectors.length; i++) {
                            var btn = document.querySelector(btnSelectors[i]);
                            if (btn && btn.offsetParent !== null && !btn.disabled) {
                                btn.click();
                                return 'clicked_selector:' + btnSelectors[i];
                            }
                        }

                        var allButtons = document.querySelectorAll('button, div[role=""button""], a[role=""button""]');
                        var targetKeywords = ['tiếp tục', 'continue', 'xác nhận', 'confirm', 'gửi', 'submit', 'bắt đầu', 'get started'];
                        for (var j = 0; j < allButtons.length; j++) {
                            var b = allButtons[j];
                            if (b.offsetParent === null) continue;
                            var txt = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase().trim();
                            for (var k = 0; k < targetKeywords.length; k++) {
                                if (txt === targetKeywords[k] || txt.indexOf(targetKeywords[k]) >= 0) {
                                    b.click();
                                    return 'clicked_text:' + txt;
                                }
                            }
                        }
                    } catch(e) {
                        return 'error:' + e.message;
                    }
                    return 'not_found';
                })()";

            object res = js.ExecuteScript(submitJs);
            if (res != null && res.ToString().StartsWith("clicked_"))
            {
                return true;
            }

            // 2. Fallback qua Selenium XPath
            string[] xpathButtons = new string[]
            {
                "//button[@type='submit']",
                "//button[@id='checkpointSubmitButton']",
                "//button[@name='reset_action']",
                "//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'tiếp tục')]",
                "//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'continue')]",
                "//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'xác nhận')]",
                "//div[@role='button'][contains(., 'Tiếp tục') or contains(., 'Continue') or contains(., 'Xác nhận')]"
            };

            foreach (var xpath in xpathButtons)
            {
                var btns = driver.FindElements(By.XPath(xpath));
                foreach (var b in btns)
                {
                    if (b.Displayed && b.Enabled)
                    {
                        b.Click();
                        return true;
                    }
                }
            }

            // 3. Fallback cuối: Gửi phím Enter vào ô input
            var activeInput = driver.FindElements(By.CssSelector("input[name='recovery_code'], input[id='recovery_code_entry'], input[name='code'], input[type='text'][maxlength='6']"));
            if (activeInput.Count > 0 && activeInput[0].Displayed)
            {
                activeInput[0].SendKeys(Keys.Enter);
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Kiểm tra chuỗi chứa chuỗi con không phân biệt hoa thường một cách tối ưu.
    /// </summary>
    private static bool ContainsIgnoreCase(string source, string value)
    {
        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(value))
        {
            return false;
        }
        return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    #endregion

    #region 3. Auto Solve Checkpoint 956 & 282 Helpers

    /// <summary>
    /// Tự động giải captcha ảnh Facebook trên trang bằng Gemini Vision AI.
    /// </summary>
    public static bool TrySolveImageCaptcha(Chrome chrome, string apiKey = "", Action<string> log = null)
    {
        if (chrome == null) return false;
        try
        {
            string solved = GeminiVisionCaptchaHelper.SolveCaptchaOnPage(chrome, apiKey, log);
            if (!string.IsNullOrEmpty(solved))
            {
                log?.Invoke("Đã giải và điền Captcha thành công: " + solved);
                return true;
            }
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi khi giải Captcha bằng Gemini Vision AI: " + ex.Message);
        }
        return false;
    }

    /// <summary>
    /// Tự động xử lý Checkpoint 956 (Két sắt vàng) trực tiếp qua Web Browser DOM:
    /// Bấm Bắt đầu (Get started) -> Tiếp tục (Next) -> Tự động nhận mã Mail OTP nếu có email.
    /// Trả về: 1 (thành công mở khóa / bypass), 0 (cần thao tác thêm / cooldown), -1 (thất bại).
    /// </summary>
    public static int SolveCheckpoint956(Chrome chrome, string email = "", string passMail = "", Action<string> log = null)
    {
        if (chrome == null) return -1;
        var driver = chrome.ChromeDriver_0;
        if (driver == null) return -1;

        int start956Tick = Environment.TickCount;
        const int max956Ms = 60000; // Giới hạn 60s timeout không để treo luồng bot

        try
        {
            log?.Invoke("Đang kiểm tra giao diện Checkpoint 956...");
            try { chrome.RunCodeChrome("SetFbLanguage('en_US')"); } catch { }
            chrome.method_53();

            // Kiểm tra nếu trang đang có Captcha ảnh Facebook
            if (chrome.D7A424AE("[src*=\"facebook.com/captcha/tfbimage\"]") || chrome.D7A424AE("#captcha_response"))
            {
                log?.Invoke("Phát hiện Captcha hình ảnh trong Checkpoint 956, đang kích hoạt Gemini Vision AI...");
                if (TrySolveImageCaptcha(chrome, "", log))
                {
                    chrome.F8091028(2.0);
                    driver.ExecuteScript(@"
                        var btn = document.querySelector('button[type=""submit""], button[id=""checkpointSubmitButton""], div[role=""button""]');
                        if (btn) btn.click();
                    ");
                    chrome.F8091028(2.5);
                }
            }

            // 1. Kiểm tra xem có nút "Bắt đầu" / "Get started"
            for (int i = 0; i < 3; i++)
            {
                if (Environment.TickCount - start956Tick > max956Ms) break;

                object startRes = driver.ExecuteScript(@"
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], button, a[role=""button""]'));
                    for (var b of btns) {
                        var txt = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase().trim();
                        if (txt === 'bắt đầu' || txt === 'get started' || txt === 'tiếp tục' || txt === 'next' || txt.includes('bắt đầu') || txt.includes('get started')) {
                            b.click();
                            return 'clicked:' + txt;
                        }
                    }
                    return 'not_found';
                ");

                if (startRes != null && startRes.ToString().StartsWith("clicked:"))
                {
                    log?.Invoke("Đã nhấn: " + startRes.ToString());
                    chrome.F8091028(2.5);
                    break;
                }
                chrome.F8091028(1.5);
            }

            if (Environment.TickCount - start956Tick > max956Ms)
            {
                log?.Invoke("Hết thời gian chờ (timeout 60s) khi giải Checkpoint 956.");
                return 0;
            }

            // 2. Kiểm tra nếu có nút "Tiếp" / "Next" tiếp theo
            driver.ExecuteScript(@"
                var btns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                for (var b of btns) {
                    var txt = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase().trim();
                    if (txt === 'tiếp' || txt === 'tiếp tục' || txt === 'next' || txt === 'xác nhận') {
                        b.click();
                        return;
                    }
                }
            ");
            chrome.F8091028(2.5);

            // 3. Kiểm tra form yêu cầu OTP qua Email
            string currentUrl = chrome.GetURL();
            if (currentUrl.Contains("checkpoint") || chrome.D7A424AE("input[type='text'], input[name='code'], input[name='email_code']"))
            {
                // Thử giải bằng Mail OTP nếu có thông tin email
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(passMail))
                {
                    int remainSec = Math.Max(10, (max956Ms - (Environment.TickCount - start956Tick)) / 1000);
                    log?.Invoke($"Phát hiện form xác thực, đang lấy mã OTP từ Email: {email} (tối đa {remainSec}s)...");
                    bool solvedOtp = TryAutoSolveEmailOTP(driver, "", 993, email, passMail, Math.Min(60, remainSec));
                    if (solvedOtp)
                    {
                        log?.Invoke("Đã điền và gửi OTP Email thành công!");
                        chrome.F8091028(4.0);
                        if (!chrome.GetURL().Contains("checkpoint"))
                        {
                            return 1;
                        }
                    }
                }
            }

            // Kiểm tra trạng thái cuối
            if (!chrome.GetURL().Contains("checkpoint") && !chrome.GetURL().Contains("828281030927956"))
            {
                log?.Invoke("Đã vượt qua Checkpoint 956!");
                return 1;
            }

            // Nếu chỉ có "Tìm hiểu thêm" (Learn more) -> Két sắt tím / Cooldown Aging
            string pageSource = chrome.AFACE5B4().ToLower();
            if (pageSource.Contains("tìm hiểu thêm") || pageSource.Contains("learn more"))
            {
                log?.Invoke("Dạng 956 Tìm hiểu thêm (cần Cooldown IP/Aging nick).");
                return 0;
            }

            return 0;
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi SolveCheckpoint956: " + ex.Message);
            return -1;
        }
    }

    /// <summary>
    /// Tự động xử lý Checkpoint 282 (Upload Selfie / Giấy tờ tùy thân) qua Web Browser DOM:
    /// Dò tìm nút "Bắt đầu" (Get started) hoặc "Phản đối quyết định" (Disagree with decision / Appeal) -> Click.
    /// Dò tìm input upload file: input[type='file'], input[name='mobile_image_data'], input[accept*='image'].
    /// Chuẩn bị ảnh: Lấy ảnh từ folder cấu hình hoặc tự động tạo ảnh avatar selfie tự nhiên ~400x500 in-memory.
    /// Cho qua PrepareAntiDetectionSelfie để phá băm MD5/SHA256 trùng lặp.
    /// Unhide input file bằng JS và inject đường dẫn ảnh qua SendKeys.
    /// Chờ ảnh upload và preview xác thực.
    /// Click "Tiếp" / "Next" / "Gửi" / "Submit" / "Continue".
    /// Chờ trang chuyển sang trạng thái "Đã nhận thông tin phản đối" / "Chúng tôi đang xem xét thông tin của bạn".
    /// Trả về: 1 (Upload thành công, chờ xét duyệt), 0 (chưa xong/cần bổ sung), -1 (lỗi).
    /// </summary>
    public static int SolveCheckpoint282(Chrome chrome, string imageDirOrPath = "", Action<string> log = null)
    {
        if (chrome == null)
        {
            log?.Invoke("Lỗi SolveCheckpoint282: Chrome instance is null.");
            return -1;
        }

        var driver = chrome.ChromeDriver_0;
        if (driver == null)
        {
            log?.Invoke("Lỗi SolveCheckpoint282: ChromeDriver is null.");
            return -1;
        }

        int start282Tick = Environment.TickCount;
        const int max282Ms = 90000; // 90s timeout

        try
        {
            log?.Invoke("Bắt đầu tự động xử lý Checkpoint 282 (Upload Selfie / Giấy tờ)...");
            try { chrome.RunCodeChrome("SetFbLanguage('en_US')"); } catch { }
            chrome.method_53();

            // Kiểm tra nếu trang đang có Captcha ảnh Facebook
            if (chrome.D7A424AE("[src*=\"facebook.com/captcha/tfbimage\"]") || chrome.D7A424AE("#captcha_response"))
            {
                log?.Invoke("Phát hiện Captcha hình ảnh trong Checkpoint 282, đang kích hoạt Gemini Vision AI...");
                if (TrySolveImageCaptcha(chrome, "", log))
                {
                    chrome.F8091028(2.0);
                    driver.ExecuteScript(@"
                        var btn = document.querySelector('button[type=""submit""], button[id=""checkpointSubmitButton""], div[role=""button""]');
                        if (btn) btn.click();
                    ");
                    chrome.F8091028(2.5);
                }
            }

            // 1. Kiểm tra xem trang đã ở trạng thái đã gửi / đang xem xét từ trước chưa
            string initUrl = chrome.GetURL() ?? string.Empty;
            string initSource = chrome.AFACE5B4() ?? string.Empty;
            if (IsCheckpoint282Reviewing(initUrl, initSource))
            {
                log?.Invoke("Trang đã ở trạng thái 'Đã nhận thông tin phản đối / Đang xem xét'.");
                return 1;
            }

            // 2. Dò tìm nút "Bắt đầu" (Get started) hoặc "Phản đối quyết định" (Disagree with decision / Appeal)
            for (int attempt = 0; attempt < 3; attempt++)
            {
                if (Environment.TickCount - start282Tick > max282Ms) break;

                // Kiểm tra xem input file upload đã hiện diện trong DOM chưa
                object checkInput = driver.ExecuteScript(@"
                    var inp = document.querySelector('input[type=""file""], input[name=""mobile_image_data""], input[accept*=""image""]');
                    return inp !== null ? 'found' : 'not_found';
                ");

                if (checkInput != null && checkInput.ToString() == "found")
                {
                    log?.Invoke("Đã phát hiện trường input file upload selfie/ID.");
                    break;
                }

                // Nếu chưa có input file, tìm và bấm các nút bắt đầu / phản đối quyết định / kháng nghị
                object clickRes = driver.ExecuteScript(@"
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], button, a[role=""button""], input[type=""submit""], input[type=""button""]'));
                    for (var b of btns) {
                        var txt = (b.innerText || b.getAttribute('aria-label') || b.value || '').toLowerCase().trim();
                        if (txt.includes('phản đối quyết định') || txt.includes('disagree with decision') ||
                            txt.includes('bắt đầu') || txt.includes('get started') ||
                            txt.includes('kháng nghị') || txt.includes('appeal') ||
                            txt === 'tiếp tục' || txt === 'continue' || txt === 'next') {
                            b.click();
                            return 'clicked:' + txt;
                        }
                    }
                    return 'not_found';
                ");

                if (clickRes != null && clickRes.ToString().StartsWith("clicked:"))
                {
                    log?.Invoke("Đã nhấn: " + clickRes.ToString());
                    chrome.F8091028(3.0);
                }
                else
                {
                    chrome.F8091028(1.5);
                }
            }

            if (Environment.TickCount - start282Tick > max282Ms)
            {
                log?.Invoke("Hết thời gian chờ (timeout 90s) khi dò tìm giao diện upload 282.");
                return 0;
            }

            // 3. Chuẩn bị file ảnh selfie (chọn ngẫu nhiên hoặc tạo ảnh chân dung tự nhiên ~400x500 in-memory)
            string selfiePath = GetPreparedSelfieImage(imageDirOrPath, log);
            if (string.IsNullOrEmpty(selfiePath) || !File.Exists(selfiePath))
            {
                log?.Invoke("Không tìm thấy hoặc không thể tạo file ảnh selfie hợp lệ!");
                return -1;
            }
            log?.Invoke("Ảnh selfie chuẩn bị hoàn tất: " + Path.GetFileName(selfiePath));

            // 4. Unhide input file bằng JS nếu đang ẩn (display:none / visibility:hidden / opacity:0)
            driver.ExecuteScript(@"
                var inputs = document.querySelectorAll('input[type=""file""], input[name=""mobile_image_data""], input[accept*=""image""]');
                for (var inp of inputs) {
                    inp.style.display = 'block';
                    inp.style.visibility = 'visible';
                    inp.style.opacity = '1';
                    inp.style.position = 'relative';
                    inp.style.width = '120px';
                    inp.style.height = '40px';
                    inp.removeAttribute('hidden');
                    inp.removeAttribute('disabled');
                }
            ");
            chrome.F8091028(1.0);

            // Tìm web element của input file
            var fileInputs = driver.FindElements(By.CssSelector("input[type='file'], input[name='mobile_image_data'], input[accept*='image']"));
            if (fileInputs == null || fileInputs.Count == 0)
            {
                log?.Invoke("Không tìm thấy phần tử input upload file trên trang!");
                return 0;
            }

            IWebElement activeInput = null;
            foreach (var el in fileInputs)
            {
                try
                {
                    if (el.Enabled)
                    {
                        activeInput = el;
                        break;
                    }
                }
                catch { }
            }
            if (activeInput == null) activeInput = fileInputs[0];

            // Gửi đường dẫn ảnh vào input file
            activeInput.SendKeys(selfiePath);
            log?.Invoke("Đã gửi đường dẫn ảnh selfie vào input file.");
            chrome.F8091028(1.5);

            // Kích hoạt các sự kiện DOM 'change' và 'input' để Meta nhận diện file upload
            try
            {
                driver.ExecuteScript(@"
                    var inputs = document.querySelectorAll('input[type=""file""], input[name=""mobile_image_data""], input[accept*=""image""]');
                    for (var inp of inputs) {
                        inp.dispatchEvent(new Event('change', { bubbles: true }));
                        inp.dispatchEvent(new Event('input', { bubbles: true }));
                    }
                ");
            }
            catch { }

            // 5. Chờ ảnh upload xong (kiểm tra preview ảnh hiện ra hoặc nút Tiếp tục/Gửi được kích hoạt)
            log?.Invoke("Đang chờ ảnh selfie hoàn tất tải lên...");
            int uploadWaitTick = Environment.TickCount;
            while (Environment.TickCount - uploadWaitTick < 30000)
            {
                object readyStatus = driver.ExecuteScript(@"
                    // Kiểm tra preview ảnh
                    var hasPreview = document.querySelector('img[src*=""blob:""], [data-visualcompletion=""media-vc-image""], img[alt*=""preview""], img[alt*=""ảnh""], img[alt*=""photo""]') !== null;
                    if (hasPreview) return 'preview_ready';

                    // Kiểm tra nút Tiếp/Gửi đã enable
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], button, input[type=""submit""]'));
                    for (var b of btns) {
                        var txt = (b.innerText || b.getAttribute('aria-label') || b.value || '').toLowerCase().trim();
                        if (txt.includes('tiếp') || txt.includes('next') || txt.includes('gửi') || txt.includes('submit') || txt.includes('continue')) {
                            var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled === true || b.classList.contains('disabled');
                            if (!disabled) return 'btn_ready';
                        }
                    }
                    return 'waiting';
                ");

                if (readyStatus != null && (readyStatus.ToString() == "preview_ready" || readyStatus.ToString() == "btn_ready"))
                {
                    log?.Invoke("Ảnh đã upload thành công (" + readyStatus.ToString() + ").");
                    break;
                }

                chrome.F8091028(1.5);
            }

            // 6. Click nút "Tiếp" / "Next" / "Gửi" / "Submit" / "Continue"
            log?.Invoke("Đang nhấn nút gửi yêu cầu xét duyệt...");
            object submitRes = driver.ExecuteScript(@"
                var btns = Array.from(document.querySelectorAll('div[role=""button""], button, input[type=""submit""], [name=""action_upload_image""]'));
                for (var b of btns) {
                    var txt = (b.innerText || b.getAttribute('aria-label') || b.value || '').toLowerCase().trim();
                    if (txt.includes('tiếp') || txt.includes('next') || txt.includes('gửi') || txt.includes('submit') || txt.includes('continue')) {
                        var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled === true;
                        if (!disabled) {
                            b.click();
                            return 'clicked:' + txt;
                        }
                    }
                }
                // Fallback: click nút bấm đầu tiên khả dụng
                for (var b of btns) {
                    var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled === true;
                    if (!disabled) {
                        b.click();
                        return 'clicked_fallback';
                    }
                }
                return 'not_found';
            ");

            if (submitRes != null && submitRes.ToString().StartsWith("clicked"))
            {
                log?.Invoke("Đã nhấn nút gửi: " + submitRes.ToString());
            }
            else
            {
                log?.Invoke("Không tìm thấy nút gửi hoặc nút chưa được kích hoạt.");
            }
            chrome.F8091028(3.0);

            // 7. Chờ trang chuyển sang trạng thái "Đã nhận thông tin phản đối" / "Chúng tôi đang xem xét thông tin của bạn"
            log?.Invoke("Đang chờ xác nhận từ Meta...");
            int reviewWaitTick = Environment.TickCount;
            while (Environment.TickCount - reviewWaitTick < 35000)
            {
                string currUrl = chrome.GetURL() ?? string.Empty;
                string currSrc = chrome.AFACE5B4() ?? string.Empty;

                if (IsCheckpoint282Reviewing(currUrl, currSrc))
                {
                    log?.Invoke("Thành công! Đã nhận thông tin phản đối (Tài khoản đang được Meta xem xét).");
                    return 1;
                }

                // Kiểm tra nếu báo lỗi upload
                string lowerSrc = currSrc.ToLower();
                if (lowerSrc.Contains("không thể tải ảnh lên") || lowerSrc.Contains("could not upload") ||
                    lowerSrc.Contains("vui lòng thử lại") || lowerSrc.Contains("please try again"))
                {
                    log?.Invoke("Meta thông báo lỗi upload ảnh!");
                    return -1;
                }

                // Nếu chuyển sang 956 hoặc Live
                if (currUrl.Contains("828281030927956"))
                {
                    log?.Invoke("Tài khoản đã chuyển sang dạng Checkpoint 956.");
                    return 0;
                }
                if (!currUrl.Contains("checkpoint") && (currUrl.Contains("facebook.com/home.php") || currUrl.Contains("facebook.com/?") || currUrl.EndsWith("facebook.com/")))
                {
                    log?.Invoke("Tài khoản đã Live thành công!");
                    return 1;
                }

                chrome.F8091028(2.0);
            }

            // Kiểm tra trạng thái cuối cùng
            string finalUrl = chrome.GetURL() ?? string.Empty;
            string finalSrc = chrome.AFACE5B4() ?? string.Empty;
            if (IsCheckpoint282Reviewing(finalUrl, finalSrc))
            {
                log?.Invoke("Thành công! Đã nhận thông tin phản đối, đang chờ xét duyệt.");
                return 1;
            }

            log?.Invoke("Chưa nhận được xác nhận xét duyệt từ Meta sau thời gian chờ.");
            return 0;
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi SolveCheckpoint282: " + ex.Message);
            return -1;
        }
    }

    /// <summary>
    /// Kiểm tra xem trang có đang ở trạng thái đã nhận thông tin phản đối / đang xem xét xét duyệt hay không.
    /// </summary>
    public static bool IsCheckpoint282Reviewing(string url, string pageSource)
    {
        string s = (pageSource ?? string.Empty).ToLower();
        string u = (url ?? string.Empty).ToLower();

        if (s.Contains("chúng tôi đã nhận thông tin") ||
            s.Contains("đã nhận thông tin phản đối") ||
            s.Contains("chúng tôi đang xem xét thông tin của bạn") ||
            s.Contains("chúng tôi đang xem xét") ||
            s.Contains("đang xem xét thông tin") ||
            s.Contains("we're reviewing your info") ||
            s.Contains("we received your information") ||
            s.Contains("you submitted an appeal") ||
            s.Contains("reviewing your information") ||
            s.Contains("you disagreed with the decision") ||
            s.Contains("bạn đã phản đối quyết định"))
        {
            return true;
        }

        if (u.Contains("/review/") || u.Contains("/appeal/") || u.Contains("awaiting_review"))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tìm ảnh selfie hợp lệ từ cấu hình đường dẫn/thư mục hoặc tự động tạo ảnh avatar selfie tự nhiên ~400x500 in-memory.
    /// Đưa qua bộ biến thiên PrepareAntiDetectionSelfie để phá băm MD5/SHA256 trùng lặp.
    /// </summary>
    public static string GetPreparedSelfieImage(string imageDirOrPath, Action<string> log = null)
    {
        string chosenPath = string.Empty;

        try
        {
            if (!string.IsNullOrEmpty(imageDirOrPath))
            {
                if (File.Exists(imageDirOrPath))
                {
                    chosenPath = imageDirOrPath;
                    log?.Invoke("Sử dụng tệp ảnh selfie chỉ định: " + Path.GetFileName(chosenPath));
                }
                else if (Directory.Exists(imageDirOrPath))
                {
                    var extList = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".jpg", ".jpeg", ".png" };
                    var files = Directory.GetFiles(imageDirOrPath)
                                         .Where(f => extList.Contains(Path.GetExtension(f)))
                                         .ToList();
                    if (files.Count > 0)
                    {
                        Random rnd = new Random();
                        chosenPath = files[rnd.Next(files.Count)];
                        log?.Invoke("Đã chọn ngẫu nhiên ảnh selfie từ thư mục: " + Path.GetFileName(chosenPath));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi kiểm tra thư mục ảnh selfie: " + ex.Message);
        }

        if (string.IsNullOrEmpty(chosenPath) || !File.Exists(chosenPath))
        {
            log?.Invoke("Không có ảnh selfie sẵn có, đang tự động tạo ảnh avatar selfie tự nhiên in-memory...");
            chosenPath = GenerateSampleNaturalSelfie();
            if (string.IsNullOrEmpty(chosenPath) || !File.Exists(chosenPath))
            {
                log?.Invoke("Không thể tạo ảnh selfie mẫu!");
                return string.Empty;
            }
        }

        log?.Invoke("Đang xử lý phá băm trùng lặp (Anti-Detection Hash Variation)...");
        string antiDetectPath = PrepareAntiDetectionSelfie(chosenPath);
        return antiDetectPath;
    }

    /// <summary>
    /// Tự động tạo một ảnh chân dung selfie tự nhiên (~400x500) in-memory bằng GDI+ Bitmap/Graphics
    /// khi người dùng chưa chuẩn bị sẵn ảnh selfie.
    /// </summary>
    public static string GenerateSampleNaturalSelfie()
    {
        try
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "LushCare_282");
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            string rawPath = Path.Combine(tempDir, "sample_selfie_" + Guid.NewGuid().ToString("N") + ".jpg");

            int width = 400;
            int height = 500;
            Random rnd = new Random();

            using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // 1. Phông nền phòng tự nhiên (Warm subtle gradient)
                int bgR = 215 + rnd.Next(-10, 15);
                int bgG = 210 + rnd.Next(-10, 15);
                int bgB = 200 + rnd.Next(-10, 15);
                Color bgTop = Color.FromArgb(bgR, bgG, bgB);
                Color bgBottom = Color.FromArgb(Math.Max(0, bgR - 25), Math.Max(0, bgG - 25), Math.Max(0, bgB - 25));
                using (LinearGradientBrush bgBrush = new LinearGradientBrush(new Rectangle(0, 0, width, height), bgTop, bgBottom, 65f))
                {
                    g.FillRectangle(bgBrush, 0, 0, width, height);
                }

                // 2. Thân người và áo (Shoulders / Casual clothing)
                int[] shirtR = { 45, 52, 60, 80, 40 };
                int[] shirtG = { 65, 75, 80, 50, 40 };
                int[] shirtB = { 95, 110, 85, 55, 45 };
                int colorIdx = rnd.Next(shirtR.Length);
                Color shirtColor = Color.FromArgb(shirtR[colorIdx] + rnd.Next(-5, 5), shirtG[colorIdx] + rnd.Next(-5, 5), shirtB[colorIdx] + rnd.Next(-5, 5));

                using (SolidBrush shirtBrush = new SolidBrush(shirtColor))
                {
                    GraphicsPath shirtPath = new GraphicsPath();
                    shirtPath.AddArc(new Rectangle(40, 340, 320, 240), 180, 180);
                    shirtPath.AddLine(360, 460, 360, 500);
                    shirtPath.AddLine(360, 500, 40, 500);
                    shirtPath.AddLine(40, 500, 40, 460);
                    shirtPath.CloseFigure();
                    g.FillPath(shirtBrush, shirtPath);
                }

                // 3. Cổ (Neck)
                int skinBaseR = 242 + rnd.Next(-8, 8);
                int skinBaseG = 198 + rnd.Next(-8, 8);
                int skinBaseB = 172 + rnd.Next(-8, 8);
                Color skinColor = Color.FromArgb(skinBaseR, skinBaseG, skinBaseB);
                Color skinShadow = Color.FromArgb(skinBaseR - 25, skinBaseG - 25, skinBaseB - 25);

                using (SolidBrush neckBrush = new SolidBrush(skinShadow))
                {
                    g.FillRectangle(neckBrush, 165, 275, 70, 90);
                }

                // 4. Khuôn mặt chân dung (Oval face)
                using (SolidBrush faceBrush = new SolidBrush(skinColor))
                {
                    g.FillEllipse(faceBrush, 125, 110, 150, 185);
                }

                // 5. Má hồng nhẹ tự nhiên (Subtle cheek blush)
                using (SolidBrush blushBrush = new SolidBrush(Color.FromArgb(28, 220, 100, 100)))
                {
                    g.FillEllipse(blushBrush, 140, 205, 35, 25);
                    g.FillEllipse(blushBrush, 225, 205, 35, 25);
                }

                // 6. Tóc (Hair)
                Color hairColor = Color.FromArgb(25 + rnd.Next(0, 15), 20 + rnd.Next(0, 10), 18 + rnd.Next(0, 10));
                using (SolidBrush hairBrush = new SolidBrush(hairColor))
                {
                    GraphicsPath hairPath = new GraphicsPath();
                    hairPath.AddArc(new Rectangle(115, 80, 170, 160), 170, 200);
                    hairPath.AddCurve(new Point[] {
                        new Point(285, 180),
                        new Point(275, 130),
                        new Point(230, 100),
                        new Point(170, 100),
                        new Point(125, 130),
                        new Point(115, 180)
                    });
                    hairPath.CloseFigure();
                    g.FillPath(hairBrush, hairPath);

                    g.FillEllipse(hairBrush, 120, 95, 160, 45);
                }

                // 7. Lông mày (Eyebrows)
                using (Pen browPen = new Pen(Color.FromArgb(50, 40, 35), 3f))
                {
                    browPen.StartCap = LineCap.Round;
                    browPen.EndCap = LineCap.Round;
                    g.DrawCurve(browPen, new Point[] {
                        new Point(148, 178),
                        new Point(165, 173),
                        new Point(182, 177)
                    });
                    g.DrawCurve(browPen, new Point[] {
                        new Point(218, 177),
                        new Point(235, 173),
                        new Point(252, 178)
                    });
                }

                // 8. Đôi mắt có hồn (Eyes with Iris & Specular reflection)
                using (SolidBrush eyeWhite = new SolidBrush(Color.FromArgb(250, 248, 245)))
                using (SolidBrush irisBrush = new SolidBrush(Color.FromArgb(40 + rnd.Next(0, 20), 28, 20)))
                using (SolidBrush pupilBrush = new SolidBrush(Color.FromArgb(15, 15, 15)))
                using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(255, 255, 255)))
                using (Pen eyelidPen = new Pen(Color.FromArgb(140, 90, 70), 1.8f))
                {
                    g.FillEllipse(eyeWhite, 150, 188, 28, 15);
                    g.DrawArc(eyelidPen, 149, 186, 30, 16, 190, 160);
                    g.FillEllipse(irisBrush, 158, 189, 13, 13);
                    g.FillEllipse(pupilBrush, 161, 192, 7, 7);
                    g.FillEllipse(highlightBrush, 164, 191, 3, 3);

                    g.FillEllipse(eyeWhite, 222, 188, 28, 15);
                    g.DrawArc(eyelidPen, 221, 186, 30, 16, 190, 160);
                    g.FillEllipse(irisBrush, 229, 189, 13, 13);
                    g.FillEllipse(pupilBrush, 232, 192, 7, 7);
                    g.FillEllipse(highlightBrush, 235, 191, 3, 3);
                }

                // 9. Sống mũi & cánh mũi (Subtle nose)
                using (Pen nosePen = new Pen(Color.FromArgb(50, 180, 130, 110), 1.8f))
                {
                    g.DrawLine(nosePen, 198, 195, 196, 228);
                    g.DrawArc(nosePen, 192, 223, 16, 9, 20, 140);
                }

                // 10. Miệng / Môi (Natural lips)
                Color lipColor = Color.FromArgb(215 + rnd.Next(-10, 10), 125 + rnd.Next(-10, 10), 115 + rnd.Next(-10, 10));
                using (SolidBrush lipBrush = new SolidBrush(lipColor))
                using (Pen lipLinePen = new Pen(Color.FromArgb(160, 80, 75), 1.2f))
                {
                    g.FillEllipse(lipBrush, 184, 250, 32, 11);
                    g.DrawArc(lipLinePen, 183, 252, 34, 6, 10, 160);
                }

                // 11. Cổ áo
                using (Pen collarPen = new Pen(Color.FromArgb(shirtColor.R - 20, shirtColor.G - 20, shirtColor.B - 20), 2f))
                {
                    g.DrawArc(collarPen, 160, 345, 80, 35, 0, 180);
                }

                // 12. Thêm nhẹ độ nhiễu camera sensor (ISO noise) khắp bức ảnh
                for (int ny = 0; ny < height; ny += 4)
                {
                    for (int nx = 0; nx < width; nx += 4)
                    {
                        if (rnd.Next(0, 3) == 0)
                        {
                            var pix = bmp.GetPixel(nx, ny);
                            int delta = rnd.Next(-2, 3);
                            int nr = Math.Min(255, Math.Max(0, pix.R + delta));
                            int ng = Math.Min(255, Math.Max(0, pix.G + delta));
                            int nb = Math.Min(255, Math.Max(0, pix.B + delta));
                            bmp.SetPixel(nx, ny, Color.FromArgb(pix.A, nr, ng, nb));
                        }
                    }
                }

                bmp.Save(rawPath, ImageFormat.Jpeg);
            }

            return rawPath;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Thêm nhiễu pixel và biến thiên ngẫu nhiên EXIF vào ảnh trước khi upload giải 282,
    /// giúp vượt qua bộ lọc computer vision phát hiện ảnh trùng lặp của Meta.
    /// </summary>
    public static string PrepareAntiDetectionSelfie(string originalImagePath)
    {
        if (string.IsNullOrEmpty(originalImagePath) || !File.Exists(originalImagePath))
        {
            return originalImagePath;
        }

        try
        {
            string ext = Path.GetExtension(originalImagePath);
            string tempDir = Path.Combine(Path.GetTempPath(), "LushCare_282");
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            string newPath = Path.Combine(tempDir, "selfie_" + Guid.NewGuid().ToString("N") + (string.IsNullOrEmpty(ext) ? ".jpg" : ext));

            // Đọc an toàn qua byte array để không khóa file gốc
            byte[] fileBytes = File.ReadAllBytes(originalImagePath);
            using (var ms = new MemoryStream(fileBytes))
            using (var bmp = new System.Drawing.Bitmap(ms))
            {
                using (var cloned = new System.Drawing.Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                {
                    using (var g = System.Drawing.Graphics.FromImage(cloned))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
                    }

                    // Biến thiên nhẹ nhiều pixel ngẫu nhiên ở các góc để phá vỡ hoàn toàn hash SHA-256/MD5/pHash
                    Random rnd = new Random();
                    int w = Math.Max(1, cloned.Width);
                    int h = Math.Max(1, cloned.Height);
                    for (int i = 0; i < 5; i++)
                    {
                        int x = rnd.Next(0, Math.Min(10, w));
                        int y = rnd.Next(0, Math.Min(10, h));
                        var p = cloned.GetPixel(x, y);
                        int delta = rnd.Next(1, 4) * (rnd.Next(0, 2) == 0 ? 1 : -1);
                        int newR = Math.Min(255, Math.Max(0, p.R + delta));
                        cloned.SetPixel(x, y, System.Drawing.Color.FromArgb(p.A, newR, p.G, p.B));
                    }

                    // Lưu với chất lượng JPEG cao 95%
                    var encoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
                    System.Drawing.Imaging.ImageCodecInfo jpegEncoder = null;
                    foreach (var enc in encoders)
                    {
                        if (enc.FormatID == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                        {
                            jpegEncoder = enc;
                            break;
                        }
                    }

                    if (jpegEncoder != null)
                    {
                        var encParams = new System.Drawing.Imaging.EncoderParameters(1);
                        encParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L);
                        cloned.Save(newPath, jpegEncoder, encParams);
                    }
                    else
                    {
                        cloned.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }

            return newPath;
        }
        catch
        {
            return originalImagePath;
        }
    }

    #endregion

    #region 4. Utility & Helper Methods

    /// <summary>
    /// Lấy mô tả chi tiết bằng tiếng Việt của loại Checkpoint.
    /// </summary>
    public static string GetDescription(CheckpointType type)
    {
        switch (type)
        {
            case CheckpointType.None:
                return "Không có Checkpoint (Bình thường / Đã đăng nhập)";
            case CheckpointType.Checkpoint282_PhotoVerify:
                return "Checkpoint 282 (Xác minh ảnh / Video khuôn mặt / Giấy tờ)";
            case CheckpointType.Checkpoint956_Lockout:
                return "Checkpoint 956 (Khóa két sắt Bắt đầu)";
            case CheckpointType.PasswordRequired:
                return "Yêu cầu nhập lại mật khẩu";
            case CheckpointType.EmailOTP:
                return "Yêu cầu mã xác nhận Email (Email OTP)";
            case CheckpointType.SmsOTP:
                return "Yêu cầu mã xác nhận SMS (SMS OTP)";
            case CheckpointType.TwoFactorAuth:
                return "Xác thực 2 yếu tố (2FA / Approvals Code)";
            case CheckpointType.GoogleOAuth:
                return "Xác thực bên thứ ba (Google OAuth)";
            case CheckpointType.AccountSuspended:
                return "Tài khoản bị đình chỉ (180 ngày)";
            case CheckpointType.AccountDisabled:
                return "Tài khoản bị vô hiệu hóa";
            case CheckpointType.ImageCaptcha:
                return "Checkpoint Captcha ảnh Facebook (Gemini Vision AI)";
            case CheckpointType.Unknown:
            default:
                return "Checkpoint chưa xác định";
        }
    }

    /// <summary>
    /// Kiểm tra xem loại checkpoint này có phải là lỗi chí mạng không thể giải tự động (tài khoản chết / bị vô hiệu hóa / bị đình chỉ).
    /// </summary>
    public static bool IsFatal(CheckpointType type)
    {
        return type == CheckpointType.AccountDisabled || type == CheckpointType.AccountSuspended;
    }

    /// <summary>
    /// Kiểm tra xem loại checkpoint này có yêu cầu nhập mã xác thực (OTP / 2FA) hay không.
    /// </summary>
    public static bool RequiresCode(CheckpointType type)
    {
        return type == CheckpointType.EmailOTP ||
               type == CheckpointType.SmsOTP ||
               type == CheckpointType.TwoFactorAuth;
    }

    #endregion
}
