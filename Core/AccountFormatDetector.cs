using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class AccountFormatDetector
{
    /// <summary>
    /// Chuẩn hóa một dòng tài khoản: nếu sao chép từ Excel/Sheets có dấu Tab và không có Pipe thì chuyển đổi thành Pipe.
    /// </summary>
    public static string NormalizeLine(string line)
    {
        if (string.IsNullOrEmpty(line)) return "";
        string trimmed = line.Trim();
        if (trimmed.Contains("\t") && !trimmed.Contains("|"))
        {
            trimmed = trimmed.Replace("\t", "|");
        }
        return trimmed;
    }

    /// <summary>
    /// Tự động nhận diện định dạng từ danh sách dòng tài khoản.
    /// Hỗ trợ tất cả cấu trúc Facebook MMO: Uid, Pass, 2FA, Token, Cookie, Email, Pass Email, Proxy, Birthday, v.v.
    /// </summary>
    public static string DetectFormat(IEnumerable<string> rawLines)
    {
        if (rawLines == null) return "";

        List<string> cleanLines = new List<string>();
        foreach (var l in rawLines)
        {
            string norm = NormalizeLine(l);
            if (!string.IsNullOrWhiteSpace(norm))
            {
                cleanLines.Add(norm);
                if (cleanLines.Count >= 30) break; // Lấy mẫu tối đa 30 dòng đại diện
            }
        }

        if (cleanLines.Count == 0) return "";

        // Kiểm tra trường hợp single-token (chỉ có 1 cột dữ liệu, không có ký tự phân tách)
        bool hasPipe = cleanLines.Any(l => l.Contains("|"));
        if (!hasPipe)
        {
            string firstVal = cleanLines[0];
            if (IsCookie(firstVal)) return "Cookie";
            if (IsToken(firstVal)) return "Token";
            if (IsUid(firstVal)) return "Uid";
            return "Cookie";
        }

        // Tách các cột theo dấu phân cách |
        List<List<string>> rowColumns = new List<List<string>>();
        int maxCols = 0;
        foreach (var line in cleanLines)
        {
            var cols = line.Split('|').Select(c => c.Trim()).ToList();
            rowColumns.Add(cols);
            if (cols.Count > maxCols) maxCols = cols.Count;
        }

        if (maxCols == 0) return "";

        List<string> detectedColumns = new List<string>();

        for (int c = 0; c < maxCols; c++)
        {
            List<string> samples = new List<string>();
            foreach (var r in rowColumns)
            {
                if (c < r.Count && !string.IsNullOrEmpty(r[c]))
                {
                    samples.Add(r[c]);
                }
            }

            string colType = ClassifyColumn(samples, c, detectedColumns, maxCols);
            detectedColumns.Add(colType);
        }

        // Tinh chỉnh và hợp thức hóa danh sách cột
        RefineDetectedColumns(detectedColumns);

        return string.Join("|", detectedColumns);
    }

    /// <summary>
    /// Nhận diện định dạng cho 1 dòng đơn lẻ
    /// </summary>
    public static string DetectSingleLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return "";
        return DetectFormat(new[] { line });
    }

    private static string ClassifyColumn(List<string> samples, int colIndex, List<string> alreadyDetected, int totalCols)
    {
        if (samples == null || samples.Count == 0)
        {
            if (colIndex == 0 && !alreadyDetected.Contains("Uid")) return "Uid";
            if (colIndex == 1 && alreadyDetected.Count > 0 && alreadyDetected[0] == "Uid" && !alreadyDetected.Contains("Pass")) return "Pass";
            return "";
        }

        int total = samples.Count;

        // Quy tắc ngữ cảnh vị trí ưu tiên cao (High Priority Positional Context):
        // Cột 0: nếu là số 8-20 chữ số -> Chắc chắn là Uid
        if (colIndex == 0)
        {
            int uid0Hits = samples.Count(IsUid);
            if (uid0Hits > 0 && (double)uid0Hits / total >= 0.5)
            {
                return "Uid";
            }
        }

        // Cột 1: nếu cột 0 là Uid -> Cột 1 BẮT BUỘC là Pass (trừ khi là Cookie hoặc Token rõ ràng)
        if (colIndex == 1 && alreadyDetected.Count > 0 && alreadyDetected[0] == "Uid" && !alreadyDetected.Contains("Pass"))
        {
            int cookieH = samples.Count(IsCookie);
            int tokenH = samples.Count(IsToken);
            bool isCookieOrToken = (cookieH > 0 && (double)cookieH / total >= 0.5) || (tokenH > 0 && (double)tokenH / total >= 0.5);
            if (!isCookieOrToken)
            {
                return "Pass";
            }
        }

        // Cột đứng ngay sau Email: nếu không phải Cookie, Token, Proxy, Email khác -> BẮT BUỘC là 'Pass Email'
        if (alreadyDetected.Count > 0 && alreadyDetected[alreadyDetected.Count - 1] == "Email" && !alreadyDetected.Contains("Pass Email"))
        {
            int cookieH = samples.Count(IsCookie);
            int tokenH = samples.Count(IsToken);
            int emailH = samples.Count(IsEmail);
            int proxyH = samples.Count(IsProxy);
            bool isOtherExplicitType = (cookieH > 0 && (double)cookieH / total >= 0.5) ||
                                       (tokenH > 0 && (double)tokenH / total >= 0.5) ||
                                       (emailH > 0 && (double)emailH / total >= 0.5) ||
                                       (proxyH > 0 && (double)proxyH / total >= 0.5);
            if (!isOtherExplicitType)
            {
                return "Pass Email";
            }
        }

        // Cột đứng ngay sau Mail khôi phục: nếu không phải loại cụ thể khác -> BẮT BUỘC là 'Pass mail khôi phục'
        if (alreadyDetected.Count > 0 && alreadyDetected[alreadyDetected.Count - 1] == "Mail khôi phục" && !alreadyDetected.Contains("Pass mail khôi phục"))
        {
            int cookieH = samples.Count(IsCookie);
            int tokenH = samples.Count(IsToken);
            int emailH = samples.Count(IsEmail);
            bool isOtherExplicitType = (cookieH > 0 && (double)cookieH / total >= 0.5) ||
                                       (tokenH > 0 && (double)tokenH / total >= 0.5) ||
                                       (emailH > 0 && (double)emailH / total >= 0.5);
            if (!isOtherExplicitType)
            {
                return "Pass mail khôi phục";
            }
        }

        // 1. Cookie
        int cookieHits = samples.Count(IsCookie);
        if (cookieHits > 0 && (double)cookieHits / total >= 0.4)
        {
            return "Cookie";
        }

        // 2. Token Facebook (EAA... / CAA...)
        int tokenHits = samples.Count(IsToken);
        if (tokenHits > 0 && (double)tokenHits / total >= 0.4)
        {
            return "Token";
        }

        // 3. Email & Mail khôi phục
        int emailHits = samples.Count(IsEmail);
        if (emailHits > 0 && (double)emailHits / total >= 0.5)
        {
            if (!alreadyDetected.Contains("Email"))
            {
                return "Email";
            }
            if (!alreadyDetected.Contains("Mail khôi phục"))
            {
                return "Mail khôi phục";
            }
        }

        // 4. 2FA Secret Key (Base32 in hoa [A-Z2-7] 16/26/32/36 ký tự)
        int b32Hits = samples.Count(Is2FA);
        if (b32Hits > 0 && (double)b32Hits / total >= 0.5)
        {
            return "2FA";
        }

        // 5. Proxy (IP:Port / IP:Port:User:Pass / Domain:Port)
        int proxyHits = samples.Count(IsProxy);
        if (proxyHits > 0 && (double)proxyHits / total >= 0.5)
        {
            return "Proxy";
        }

        // 6. Useragent
        int uaHits = samples.Count(IsUseragent);
        if (uaHits > 0 && (double)uaHits / total >= 0.4)
        {
            return "Useragent";
        }

        // 7. Ngày sinh (Birthday)
        int bdayHits = samples.Count(IsBirthday);
        if (bdayHits > 0 && (double)bdayHits / total >= 0.5)
        {
            return "Birthday";
        }

        // 8. Client_id
        int clientIdHits = samples.Count(IsClientId);
        if (clientIdHits > 0 && (double)clientIdHits / total >= 0.5)
        {
            return "Client_id";
        }

        // 9. UID (8-20 chữ số)
        int uidHits = samples.Count(IsUid);
        if (uidHits > 0 && (double)uidHits / total >= 0.5 && !alreadyDetected.Contains("Uid"))
        {
            return "Uid";
        }

        // 10. Xử lý Pass, Pass Email, Pass mail khôi phục theo ngữ cảnh
        if (alreadyDetected.Count > 0)
        {
            string prev = alreadyDetected[alreadyDetected.Count - 1];
            if (prev == "Email" && !alreadyDetected.Contains("Pass Email"))
            {
                return "Pass Email";
            }
            if (prev == "Mail khôi phục" && !alreadyDetected.Contains("Pass mail khôi phục"))
            {
                return "Pass mail khôi phục";
            }
            if (prev == "Uid" && !alreadyDetected.Contains("Pass"))
            {
                return "Pass";
            }
        }

        if (!alreadyDetected.Contains("Pass"))
        {
            return "Pass";
        }

        if (alreadyDetected.Contains("Email") && !alreadyDetected.Contains("Pass Email"))
        {
            return "Pass Email";
        }

        if (!alreadyDetected.Contains("Ghi chú"))
        {
            return "Ghi chú";
        }

        return "";
    }

    private static void RefineDetectedColumns(List<string> cols)
    {
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i] == "Email" && i + 1 < cols.Count)
            {
                if (cols[i + 1] == "" || cols[i + 1] == "Ghi chú" || cols[i + 1] == "Pass")
                {
                    cols[i + 1] = "Pass Email";
                }
            }
            else if (cols[i] == "Mail khôi phục" && i + 1 < cols.Count)
            {
                if (cols[i + 1] == "" || cols[i + 1] == "Ghi chú" || cols[i + 1] == "Pass")
                {
                    cols[i + 1] = "Pass mail khôi phục";
                }
            }
        }
    }

    public static bool IsCookie(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        val = val.ToLowerInvariant();
        return val.Contains("c_user=") || val.Contains("xs=") || val.Contains("datr=") ||
               val.Contains("sb=") || val.Contains("fr=") || val.Contains("wd=") ||
               val.StartsWith("[{\"name\"") || val.StartsWith("[{\"domain\"");
    }

    public static bool IsToken(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        return (val.StartsWith("EAA", StringComparison.OrdinalIgnoreCase) || 
                val.StartsWith("CAA", StringComparison.OrdinalIgnoreCase)) && val.Length >= 40;
    }

    public static bool IsEmail(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        return Regex.IsMatch(val.Trim(), @"^[^\s@|]+@[^\s@|]+\.[^\s@|]+$");
    }

    public static bool Is2FA(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        string clean = Regex.Replace(val, @"\s+", "");
        // Chuẩn Base32 secret key: CHỈ chứa chữ IN HOA [A-Z] và các số [2-7].
        // Nếu chứa chữ cái viết thường (a-z) thì TUYỆT ĐỐI KHÔNG PHẢI là 2FA (thường là mật khẩu).
        if (clean.Length == 16 || clean.Length == 26 || clean.Length == 32 || clean.Length == 36)
        {
            return Regex.IsMatch(clean, @"^[A-Z2-7]+$");
        }
        return false;
    }

    public static bool IsProxy(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        val = val.Trim();
        if (Regex.IsMatch(val, @"^(https?:\/\/|socks[45]:\/\/)?(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}|[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}):\d{2,5}(:[^|]+)?$", RegexOptions.IgnoreCase))
        {
            return true;
        }
        string valLower = val.ToLowerInvariant();
        return valLower.Contains("tmproxy") || valLower.Contains("tinsoft") || 
               valLower.Contains("shoplike") || valLower.Contains("minproxy");
    }

    public static bool IsBirthday(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        return Regex.IsMatch(val.Trim(), @"^(\d{1,2}[\/\-\.]\d{1,2}[\/\-\.]\d{4}|\d{4}[\/\-\.]\d{1,2}[\/\-\.]\d{1,2})$");
    }

    public static bool IsUseragent(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        return val.Contains("Mozilla/") || val.Contains("AppleWebKit") || 
               val.Contains("Chrome/") || val.Contains("Safari/");
    }

    public static bool IsUid(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        return Regex.IsMatch(val.Trim(), @"^\d{8,20}$");
    }

    public static bool IsClientId(string val)
    {
        if (string.IsNullOrEmpty(val)) return false;
        return Regex.IsMatch(val.Trim(), @"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$");
    }
}
