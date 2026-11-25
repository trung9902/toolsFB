using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// Phân hạng mức độ tin cậy và sức bền tài khoản (Account Tier)
/// </summary>
public enum AccountTier
{
    Weak = 0,    // Yếu / Cần nướng (< 50)
    Normal = 1,  // Trung bình / Ổn định (50 <= score < 80)
    Strong = 2   // Trâu / VIP (>= 80)
}

/// <summary>
/// Dữ liệu đầu vào để chẩn đoán độ trâu của tài khoản
/// </summary>
public class AccountHealthInput
{
    public string Id { get; set; } = "";
    public string Uid { get; set; } = "";
    public string Password { get; set; } = "";
    public string Fa2 { get; set; } = "";
    public string Cookies { get; set; } = "";
    public string Email { get; set; } = "";
    public string PassMail { get; set; } = "";
    public string FriendCount { get; set; } = "";
    public string GroupCount { get; set; } = "";
    public string InteractEnd { get; set; } = "";
    public string Status { get; set; } = "";
    public string Info { get; set; } = "";
}

/// <summary>
/// Kết quả đánh giá sức khỏe và chấm điểm Trust Score của tài khoản
/// </summary>
public class AccountHealthResult
{
    public int Score { get; set; }
    public AccountTier Tier { get; set; }
    public string TierName { get; set; } = "";
    public List<string> Details { get; set; } = new List<string>();
    public string Recommendation { get; set; } = "";
    public string ShortBadge { get; set; } = "";
    public string Uid { get; set; } = "";

    public bool IsStrong => Tier == AccountTier.Strong;
    public bool IsNormal => Tier == AccountTier.Normal;
    public bool IsWeak => Tier == AccountTier.Weak;

    public Color BadgeColor
    {
        get
        {
            switch (Tier)
            {
                case AccountTier.Strong:
                    return Color.FromArgb(34, 197, 94); // Xanh lá cây (Emerald)
                case AccountTier.Normal:
                    return Color.FromArgb(234, 179, 8);  // Vàng cam (Amber)
                case AccountTier.Weak:
                default:
                    return Color.FromArgb(239, 68, 68);  // Đỏ (Rose)
            }
        }
    }

    public override string ToString()
    {
        return $"{ShortBadge} - {Recommendation}";
    }

    public string BuildDetailedReport()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"===== BÁO CÁO CHẨN ĐOÁN TRUST SCORE =====");
        if (!string.IsNullOrWhiteSpace(Uid))
            sb.AppendLine($"UID: {Uid}");
        sb.AppendLine($"Điểm tín nhiệm: {Score}/100 ({TierName})");
        sb.AppendLine($"Huy hiệu: {ShortBadge}");
        sb.AppendLine($"Khuyến nghị: {Recommendation}");
        sb.AppendLine("Chi tiết chấm điểm:");
        foreach (var d in Details)
        {
            sb.AppendLine($" • {d}");
        }
        return sb.ToString();
    }
}

/// <summary>
/// Động cơ chẩn đoán và chấm điểm tín nhiệm tài khoản Facebook (Trust Score 0 - 100)
/// Đưa ra khuyến nghị an toàn và phân hạng tài khoản (Trâu / Ổn định / Yếu)
/// </summary>
public static class AccountHealthEngine
{
    /// <summary>
    /// Chấm điểm Trust Score dựa trên đối tượng AccountHealthInput
    /// </summary>
    public static AccountHealthResult Calculate(AccountHealthInput account)
    {
        if (account == null)
        {
            return CreateFallbackResult("", 0, "Không có dữ liệu tài khoản");
        }

        return Calculate(
            account.Uid,
            account.Fa2,
            account.Cookies,
            account.Email,
            account.PassMail,
            account.InteractEnd,
            account.FriendCount
        );
    }

    /// <summary>
    /// Chấm điểm Trust Score với các trường thông tin cơ bản
    /// </summary>
    public static AccountHealthResult Calculate(
        string uid,
        string fa2,
        string cookies,
        string email,
        string passmail,
        string interactEnd,
        string friendCount)
    {
        int rawScore = 0;
        List<string> details = new List<string>();
        string cleanUid = (uid ?? "").Trim();

        // 1. Tuổi nick / Định dạng UID
        // UID cổ 10000...: +25đ; UID 1000...: +20đ; UID mới 615...: +10đ
        if (string.IsNullOrWhiteSpace(cleanUid))
        {
            details.Add("Thiếu UID / Tài khoản chưa có định danh (0đ)");
        }
        else if (cleanUid.StartsWith("10000"))
        {
            rawScore += 25;
            details.Add("UID cổ 10000... (+25đ)");
        }
        else if (Regex.IsMatch(cleanUid, @"^\d+$") && cleanUid.Length <= 10)
        {
            rawScore += 25;
            details.Add($"UID siêu cổ ({cleanUid.Length} chữ số) (+25đ)");
        }
        else if (cleanUid.StartsWith("1000"))
        {
            rawScore += 20;
            details.Add("UID 1000... (+20đ)");
        }
        else if (cleanUid.StartsWith("615"))
        {
            rawScore += 10;
            details.Add("UID mới 615... (+10đ)");
        }
        else if (Regex.IsMatch(cleanUid, @"^\d+$") && cleanUid.Length >= 14)
        {
            rawScore += 15;
            details.Add("UID tiêu chuẩn Facebook (+15đ)");
        }
        else
        {
            rawScore += 10;
            details.Add("Định dạng Username / Định danh phụ (+10đ)");
        }

        // 2. Bảo mật 2FA (có 2FA Secret Key: +20đ, thiếu: -15đ)
        string clean2FA = (fa2 ?? "").Trim();
        bool has2FA = !string.IsNullOrWhiteSpace(clean2FA) && clean2FA != "0" && clean2FA.Length >= 8;
        if (has2FA)
        {
            rawScore += 20;
            details.Add("Bảo mật 2FA Secret Key đầy đủ (+20đ)");
        }
        else
        {
            rawScore -= 15;
            details.Add("Thiếu bảo mật 2FA (-15đ)");
        }

        // 3. Tình trạng Cookie (Cookie có c_user và xs hợp lệ: +20đ, cookie rỗng: 0đ)
        string cleanCookies = (cookies ?? "").Trim();
        if (!string.IsNullOrWhiteSpace(cleanCookies))
        {
            string cookieLower = cleanCookies.ToLowerInvariant();
            bool hasCUser = cookieLower.Contains("c_user=") || cookieLower.Contains("c_user");
            bool hasXs = cookieLower.Contains("xs=") || cookieLower.Contains("xs");

            if (hasCUser && hasXs)
            {
                rawScore += 20;
                details.Add("Cookie phiên hợp lệ (có c_user & xs) (+20đ)");
            }
            else if (hasCUser || hasXs)
            {
                rawScore += 10;
                details.Add("Cookie chưa hoàn chỉnh (thiếu c_user hoặc xs) (+10đ)");
            }
            else
            {
                details.Add("Cookie sai cấu trúc hoặc không chứa phiên (0đ)");
            }
        }
        else
        {
            details.Add("Cookie rỗng (0đ)");
        }

        // 4. Email / PassMail (Có email và passmail: +15đ)
        string cleanEmail = (email ?? "").Trim();
        string cleanPassMail = (passmail ?? "").Trim();
        bool hasEmail = !string.IsNullOrWhiteSpace(cleanEmail) && cleanEmail.Contains("@");
        bool hasPassMail = !string.IsNullOrWhiteSpace(cleanPassMail) && cleanPassMail != "0";

        if (hasEmail && hasPassMail)
        {
            rawScore += 15;
            details.Add("Có đầy đủ Email & Mật khẩu Mail (+15đ)");
        }
        else if (hasEmail)
        {
            rawScore += 5;
            details.Add("Có Email nhưng thiếu Mật khẩu Mail (+5đ)");
        }
        else
        {
            details.Add("Thiếu Email & Mật khẩu Mail (0đ)");
        }

        // 5. Tình trạng hoạt động gần nhất (Có ngày tương tác gần nhất: +10đ)
        string cleanInteract = (interactEnd ?? "").Trim();
        bool hasRecentInteract = !string.IsNullOrWhiteSpace(cleanInteract) && cleanInteract != "0";
        if (hasRecentInteract)
        {
            rawScore += 10;
            details.Add($"Có lịch sử tương tác gần nhất ({cleanInteract}) (+10đ)");
        }
        else
        {
            details.Add("Chưa có lịch sử hoạt động / tương tác gần nhất (0đ)");
        }

        // 6. Bạn bè & Nhóm (Có số bạn bè > 100: +10đ)
        int friends = 0;
        if (!string.IsNullOrWhiteSpace(friendCount))
        {
            string friendDigits = Regex.Replace(friendCount, @"[^\d]", "");
            int.TryParse(friendDigits, out friends);
        }

        if (friends > 100)
        {
            rawScore += 10;
            details.Add($"Số bạn bè uy tín (>100 bạn: {friends}) (+10đ)");
        }
        else if (friends > 0)
        {
            rawScore += 5;
            details.Add($"Số bạn bè khiêm tốn (<=100 bạn: {friends}) (+5đ)");
        }
        else
        {
            details.Add("Chưa có thông tin bạn bè (0 bạn) (0đ)");
        }

        // Giới hạn điểm từ 0 đến 100
        int finalScore = Math.Max(0, Math.Min(100, rawScore));

        // Phân hạng tài khoản (AccountTier)
        AccountTier tier;
        string tierName;
        string recommendation;
        string shortBadge;

        if (finalScore >= 80)
        {
            tier = AccountTier.Strong;
            tierName = "Trâu";
            recommendation = "Sẵn sàng chạy tác vụ nặng (Spam, Share, Kết bạn)";
            shortBadge = $"[Trust {finalScore}★ Trâu]";
        }
        else if (finalScore >= 50)
        {
            tier = AccountTier.Normal;
            tierName = "Ổn định";
            recommendation = "Nên chạy tác vụ vừa phải, lướt feed";
            shortBadge = $"[Trust {finalScore}⚡ Ổn định]";
        }
        else
        {
            tier = AccountTier.Weak;
            tierName = "Yếu";
            recommendation = "Cần chạy Warm-up 3 pha ngay trước khi làm việc";
            shortBadge = $"[Trust {finalScore}⚠️ Yếu]";
        }

        return new AccountHealthResult
        {
            Score = finalScore,
            Tier = tier,
            TierName = tierName,
            Details = details,
            Recommendation = recommendation,
            ShortBadge = shortBadge,
            Uid = cleanUid
        };
    }

    /// <summary>
    /// Chấm điểm đầy đủ với cả password, groupCount, status, info
    /// </summary>
    public static AccountHealthResult Calculate(
        string uid,
        string pass,
        string fa2,
        string cookies,
        string email,
        string passmail,
        string friendCount,
        string groupCount,
        string interactEnd,
        string status,
        string info)
    {
        return Calculate(uid, fa2, cookies, email, passmail, interactEnd, friendCount);
    }

    private static AccountHealthResult CreateFallbackResult(string uid, int score, string reason)
    {
        return new AccountHealthResult
        {
            Score = score,
            Tier = AccountTier.Weak,
            TierName = "Yếu",
            Details = new List<string> { reason },
            Recommendation = "Cần kiểm tra lại thông tin và chạy Warm-up",
            ShortBadge = $"[Trust {score}⚠️ Yếu]",
            Uid = uid
        };
    }

    /// <summary>
    /// Lấy mã màu hiển thị tương ứng với phân hạng
    /// </summary>
    public static Color GetTierColor(AccountTier tier)
    {
        switch (tier)
        {
            case AccountTier.Strong:
                return Color.FromArgb(34, 197, 94);
            case AccountTier.Normal:
                return Color.FromArgb(234, 179, 8);
            case AccountTier.Weak:
            default:
                return Color.FromArgb(239, 68, 68);
        }
    }
}
