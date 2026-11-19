using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;

/// <summary>
/// LushCare Global - Security & Profile Helper
/// Quản lý và điều phối chuyên sâu toàn bộ tính năng Thông tin cá nhân & Bảo mật tài khoản:
/// 1. Cập nhật thông tin profile: Bio, công việc (Work), học vấn (Education), thành phố (City), quê quán (Hometown), mối quan hệ (Relationship), ngày sinh, giới tính.
/// 2. Đổi ảnh đại diện (Up Avatar): Tự động gán input file, hỗ trợ tùy chọn bỏ qua cắt ảnh (skip crop / ảnh gốc), chống đơ nút Lưu.
/// 3. Đổi ảnh bìa (Up Cover): Tự động gán input file, chờ thanh loading xử lý ảnh và bấm Lưu thay đổi.
/// 4. Đổi mật khẩu (Accounts Center): Tự động điều hướng Meta Accounts Center, xử lý re-auth mật khẩu cũ, đặt mật khẩu mới an toàn.
/// 5. Đổi họ tên (Accounts Center): Đổi tên First/Middle/Last qua giao diện Meta Accounts Center.
/// 6. Thêm email (Accounts Center): Điều hướng thêm mail, tự động lắng nghe mã OTP xác nhận từ dịch vụ IMAP / Hotmail / Tempmail API.
/// 7. Gỡ số điện thoại (Accounts Center): Tìm và gỡ các SĐT cũ liên kết tài khoản.
/// 8. Bật / Tắt 2FA (Accounts Center): Thiết lập xác thực hai yếu tố, trích xuất mã Secret Key 2FA để lưu trữ, xác nhận mã TOTP.
/// 9. Đăng xuất thiết bị cũ: Thoát tất cả các phiên đăng nhập lạ hoặc các phiên không phải thiết bị hiện tại.
/// 10. Xóa thiết bị tin cậy: Thu hồi danh sách thiết bị đã lưu đăng nhập trước đây.
/// </summary>
public static class SecurityProfileHelper
{
    private static readonly Random _rd = new Random();

    #region 1. HELPER LẤY MÃ OTP EMAIL & PHÂN TÍCH MAIL

    /// <summary>
    /// Lấy mã OTP từ email liên kết (hỗ trợ Hotmail/Outlook IMAP hoặc mail domain tùy chỉnh).
    /// </summary>
    public static string FetchOtpFromMail(
        string email,
        string passMail,
        string refreshToken = "",
        string cookieMail = "",
        int timeoutSeconds = 60,
        string uid = "",
        string oldOtp = "",
        Action<string> statusCallback = null)
    {
        if (string.IsNullOrEmpty(email))
            return string.Empty;

        statusCallback?.Invoke($"Đang chờ mã OTP xác nhận gửi về email {email}...");
        try
        {
            // Gọi helper lấy OTP từ MailKit/IMAP trong FB93BDA4 (type = 1 cho Hotmail/Outlook IMAP)
            string otp = FB93BDA4.GetOtpFromMail(1, email, passMail, refreshToken, cookieMail, timeoutSeconds, uid, oldOtp);
            if (!string.IsNullOrEmpty(otp) && Regex.IsMatch(otp, @"\b\d{5,8}\b"))
            {
                statusCallback?.Invoke($"Đã nhận được mã OTP xác nhận: {otp}");
                return otp;
            }
        }
        catch (Exception ex)
        {
            statusCallback?.Invoke($"Lỗi lấy OTP email: {ex.Message}");
        }

        return string.Empty;
    }

    #endregion

    #region 2. CẬP NHẬT THÔNG TIN PROFILE (BIO, WORK, EDU, CITY, HOMETOWN, RELATIONSHIP)

    /// <summary>
    /// Cập nhật Bio (tiểu sử trang cá nhân).
    /// </summary>
    public static bool UpdateBio(Chrome chrome, string bio, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        statusCallback?.Invoke("Cập nhật tiểu sử cá nhân (Bio)...");
        return ProfileInfoHub.UpdateBio(chrome, bio);
    }

    /// <summary>
    /// Cập nhật công việc (Work / Nơi làm việc).
    /// </summary>
    public static bool UpdateWork(Chrome chrome, string workName, int ifHaveAction = 0, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        statusCallback?.Invoke($"Cập nhật nơi làm việc: {workName}...");
        return ProfileInfoHub.UpdateWork(chrome, workName, ifHaveAction);
    }

    /// <summary>
    /// Cập nhật trường học (Trường trung học & Đại học).
    /// </summary>
    public static bool UpdateEducation(Chrome chrome, string highSchool, string college, int ifHaveAction = 0, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        bool ok = true;
        if (!string.IsNullOrEmpty(highSchool))
        {
            statusCallback?.Invoke($"Cập nhật trường trung học: {highSchool}...");
            ok &= ProfileInfoHub.UpdateHighSchool(chrome, highSchool, ifHaveAction);
        }
        if (!string.IsNullOrEmpty(college))
        {
            statusCallback?.Invoke($"Cập nhật trường cao đẳng/đại học: {college}...");
            ok &= ProfileInfoHub.UpdateCollege(chrome, college, ifHaveAction);
        }
        return ok;
    }

    /// <summary>
    /// Cập nhật Tỉnh/Thành phố hiện tại và Quê quán.
    /// </summary>
    public static bool UpdateLocation(Chrome chrome, string currentCity, string hometown, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        bool ok = true;
        if (!string.IsNullOrEmpty(currentCity))
        {
            statusCallback?.Invoke($"Cập nhật thành phố hiện tại: {currentCity}...");
            ok &= ProfileInfoHub.UpdateCurrentCity(chrome, currentCity);
        }
        if (!string.IsNullOrEmpty(hometown))
        {
            statusCallback?.Invoke($"Cập nhật quê quán: {hometown}...");
            ok &= ProfileInfoHub.UpdateHometown(chrome, hometown);
        }
        return ok;
    }

    /// <summary>
    /// Cập nhật tình trạng quan hệ (Độc thân, Hẹn hò, Đã kết hôn...).
    /// </summary>
    public static bool UpdateRelationship(Chrome chrome, string relCode, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        statusCallback?.Invoke("Cập nhật tình trạng quan hệ...");
        return ProfileInfoHub.UpdateRelationship(chrome, relCode);
    }

    /// <summary>
    /// Cập nhật giới tính.
    /// </summary>
    public static bool UpdateGender(Chrome chrome, string genderCode, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        statusCallback?.Invoke("Cập nhật giới tính...");
        return ProfileInfoHub.UpdateGender(chrome, genderCode);
    }

    /// <summary>
    /// Cập nhật ngày sinh.
    /// </summary>
    public static bool UpdateBirthday(Chrome chrome, string day, string month, string year, Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        statusCallback?.Invoke($"Cập nhật ngày sinh: {day}/{month}/{year}...");
        return ProfileInfoHub.UpdateBirthday(chrome, day, month, year);
    }

    #endregion

    #region 3. UPLOAD AVATAR (HỖ TRỢ BỎ QUA CẮT ẢNH)

    /// <summary>
    /// Tải lên ảnh đại diện cá nhân kèm tùy chọn bỏ qua cắt ảnh (giữ nguyên khung ảnh gốc).
    /// </summary>
    public static bool ExecuteUploadAvatar(
        Chrome chrome,
        string imagePath,
        bool skipIfHave = false,
        bool preferMbasic = false,
        bool skipCrop = true,
        Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        if (!File.Exists(imagePath))
        {
            statusCallback?.Invoke($"Tệp ảnh avatar không tồn tại: {imagePath}");
            return false;
        }

        try
        {
            statusCallback?.Invoke("Đang tải ảnh đại diện lên trang cá nhân...");
            bool res = ProfileInfoHub.UploadAvatar(chrome, imagePath, skipIfHave, preferMbasic, skipCrop, statusCallback);
            statusCallback?.Invoke(res ? "Đổi ảnh đại diện thành công!" : "Đổi ảnh đại diện thất bại!");
            return res;
        }
        catch (Exception ex)
        {
            statusCallback?.Invoke($"Lỗi tải avatar: {ex.Message}");
            return false;
        }
    }

    #endregion

    #region 4. UPLOAD COVER (ẢNH BÌA)

    /// <summary>
    /// Tải lên ảnh bìa Profile cá nhân.
    /// </summary>
    public static bool ExecuteUploadCover(
        Chrome chrome,
        string coverPath,
        bool skipIfHave = false,
        bool preferMbasic = false,
        Action<string> statusCallback = null)
    {
        if (chrome == null) return false;
        if (!File.Exists(coverPath))
        {
            statusCallback?.Invoke($"Tệp ảnh bìa không tồn tại: {coverPath}");
            return false;
        }

        try
        {
            statusCallback?.Invoke("Đang tải ảnh bìa lên trang cá nhân...");
            bool res = ProfileInfoHub.UploadCover(chrome, coverPath, skipIfHave, preferMbasic, statusCallback);
            statusCallback?.Invoke(res ? "Đổi ảnh bìa thành công!" : "Đổi ảnh bìa thất bại!");
            return res;
        }
        catch (Exception ex)
        {
            statusCallback?.Invoke($"Lỗi tải ảnh bìa: {ex.Message}");
            return false;
        }
    }

    #endregion

    #region 5. ĐIỀU PHỐI ACCOUNTS CENTER ACTIONS

    /// <summary>
    /// Thực hiện các hành động bảo mật thông qua Meta Accounts Center (Đổi mật khẩu, Thêm mail, Đổi tên, 2FA, Gỡ SĐT, Đăng xuất thiết bị).
    /// </summary>
    public static string ExecuteAccountsCenterAction(
        Chrome chrome,
        string actionType,
        string jsonConfig,
        Action<string> statusCallback = null)
    {
        if (chrome == null)
            return "{\"success\":false,\"message\":\"Chrome null\"}";

        try
        {
            statusCallback?.Invoke($"Đang xử lý Accounts Center: {actionType}...");
            string result = AccountsCenterHub.Execute(chrome, actionType, jsonConfig);
            return result;
        }
        catch (Exception ex)
        {
            statusCallback?.Invoke($"Lỗi Accounts Center ({actionType}): {ex.Message}");
            return $"{{\"success\":false,\"message\":\"{ex.Message}\"}}";
        }
    }

    /// <summary>
    /// Kiểm tra kết quả trả về từ AccountsCenterHub có thành công hay không.
    /// </summary>
    public static bool IsSuccess(string jsonResult)
    {
        return AccountsCenterHub.IsSuccess(jsonResult);
    }

    #endregion

    #region 6. XỬ LÝ RE-AUTHENTICATION MẬT KHẨU

    /// <summary>
    /// Tự động điền mật khẩu và xác thực khi Facebook/Meta yêu cầu xác minh lại mật khẩu.
    /// </summary>
    public static bool HandlePasswordReauth(Chrome chrome, string password = "", Action<string> statusCallback = null)
    {
        if (chrome == null)
            return false;

        try
        {
            statusCallback?.Invoke("Kiểm tra hộp thoại yêu cầu xác thực lại mật khẩu (Re-auth)...");
            return ProfileInfoHub.HandlePasswordReauth(chrome, password);
        }
        catch
        {
            return false;
        }
    }

    #endregion
}
