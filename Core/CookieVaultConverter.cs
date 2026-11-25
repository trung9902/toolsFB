using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Bộ chuyển đổi Cookie đa định dạng CookieVault:
/// Hỗ trợ chuyển đổi 2 chiều và thông minh giữa:
/// - Raw Cookie: 'c_user=1000123; xs=2%3A...; fr=...; sb=...;'
/// - JSON Cookie (EditThisCookie / Puppeteer / Playwright / AdsPower / GoLogin)
/// - Netscape HTTP Cookie (curl / wget / antidetect txt)
/// - Base64 Cookie
/// </summary>
public static class CookieVaultConverter
{
    private static readonly HashSet<string> HttpOnlyCookies = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "xs", "fr", "sb", "datr", "spin", "csm", "act"
    };

    /// <summary>
    /// Chuyển đổi Cookie dạng Raw sang JSON chuẩn (EditThisCookie / Puppeteer / Playwright).
    /// </summary>
    /// <param name="rawCookie">Chuỗi cookie dạng raw hoặc bất kỳ định dạng nào</param>
    /// <param name="domain">Domain cookie (mặc định .facebook.com)</param>
    /// <param name="pretty">True nếu muốn thụt lề định dạng đẹp, False nếu nén 1 dòng</param>
    public static string CookieToJson(string rawCookie, string domain = ".facebook.com", bool pretty = false)
    {
        if (string.IsNullOrWhiteSpace(rawCookie))
            return "[]";

        try
        {
            string trimmed = StripCodeBlock(rawCookie.Trim());

            // Nếu đầu vào đã là JSON thì format lại theo yêu cầu pretty
            if ((trimmed.StartsWith("[") && trimmed.EndsWith("]")) || (trimmed.StartsWith("{") && trimmed.EndsWith("}")))
            {
                var token = JToken.Parse(trimmed);
                return token.ToString(pretty ? Formatting.Indented : Formatting.None);
            }

            // Nếu đầu vào là Netscape hoặc Base64 thì chuẩn hóa về Raw trước
            if (trimmed.Contains("# Netscape") || trimmed.Contains("\t") || (!trimmed.Contains("=") && trimmed.Length >= 20))
            {
                trimmed = NormalizeToRaw(trimmed);
            }

            var pairs = ParseRawPairs(trimmed);
            if (pairs.Count == 0)
                return "[]";

            string effectiveDomain = string.IsNullOrWhiteSpace(domain) ? ".facebook.com" : domain.Trim();
            if (!effectiveDomain.StartsWith(".") && !effectiveDomain.Contains("localhost"))
            {
                effectiveDomain = "." + effectiveDomain;
            }

            long expiry = DateTimeOffset.UtcNow.AddYears(1).ToUnixTimeSeconds();
            var jArr = new JArray();

            for (int i = 0; i < pairs.Count; i++)
            {
                var p = pairs[i];
                bool isHttpOnly = HttpOnlyCookies.Contains(p.Key);

                var obj = new JObject
                {
                    ["domain"] = effectiveDomain,
                    ["expirationDate"] = (double)expiry,
                    ["hostOnly"] = false,
                    ["httpOnly"] = isHttpOnly,
                    ["name"] = p.Key,
                    ["path"] = "/",
                    ["sameSite"] = "no_restriction",
                    ["secure"] = true,
                    ["session"] = false,
                    ["storeId"] = "0",
                    ["value"] = p.Value,
                    ["id"] = i + 1
                };

                jArr.Add(obj);
            }

            return jArr.ToString(pretty ? Formatting.Indented : Formatting.None);
        }
        catch
        {
            return "[]";
        }
    }

    /// <summary>
    /// Chuyển đổi Cookie dạng JSON (EditThisCookie, Puppeteer, AdsPower, GoLogin) về Raw 'c_user=...; xs=...;'.
    /// </summary>
    public static string JsonToRawCookie(string jsonText)
    {
        if (string.IsNullOrWhiteSpace(jsonText))
            return "";

        try
        {
            string cleanJson = StripCodeBlock(jsonText.Trim());
            var token = JToken.Parse(cleanJson);
            var pairs = new List<KeyValuePair<string, string>>();

            ExtractPairsFromToken(token, pairs);

            if (pairs.Count == 0)
                return "";

            return FormatPairsToRaw(pairs);
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Chuyển đổi Cookie Raw sang định dạng Netscape HTTP Cookie File (curl / wget / antidetect).
    /// </summary>
    public static string CookieToNetscape(string rawCookie, string domain = ".facebook.com")
    {
        if (string.IsNullOrWhiteSpace(rawCookie))
            return "# Netscape HTTP Cookie File\n";

        try
        {
            string raw = NormalizeToRaw(rawCookie);
            var pairs = ParseRawPairs(raw);
            if (pairs.Count == 0)
                return "# Netscape HTTP Cookie File\n";

            string effectiveDomain = string.IsNullOrWhiteSpace(domain) ? ".facebook.com" : domain.Trim();
            if (!effectiveDomain.StartsWith(".") && !effectiveDomain.Contains("localhost"))
            {
                effectiveDomain = "." + effectiveDomain;
            }

            string flag = effectiveDomain.StartsWith(".") ? "TRUE" : "FALSE";
            long expiry = DateTimeOffset.UtcNow.AddYears(1).ToUnixTimeSeconds();

            var sb = new StringBuilder();
            sb.AppendLine("# Netscape HTTP Cookie File");
            sb.AppendLine("# http://curl.haxx.se/rfc/cookie_spec.html");
            sb.AppendLine("# This file was generated by LushCare CookieVault! Edit at your own risk.");
            sb.AppendLine();

            foreach (var p in pairs)
            {
                bool isHttpOnly = HttpOnlyCookies.Contains(p.Key);
                string prefix = isHttpOnly ? "#HttpOnly_" : "";
                sb.AppendLine($"{prefix}{effectiveDomain}\t{flag}\t/\tTRUE\t{expiry}\t{p.Key}\t{p.Value}");
            }

            return sb.ToString().TrimEnd();
        }
        catch
        {
            return "# Netscape HTTP Cookie File\n";
        }
    }

    /// <summary>
    /// Chuyển đổi Cookie định dạng Netscape HTTP về dạng Raw 'c_user=...; xs=...;'.
    /// </summary>
    public static string NetscapeToRawCookie(string netscapeText)
    {
        if (string.IsNullOrWhiteSpace(netscapeText))
            return "";

        try
        {
            var pairs = new List<KeyValuePair<string, string>>();
            var lines = netscapeText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var rawLine in lines)
            {
                string line = rawLine.Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                if (line.StartsWith("#"))
                {
                    if (line.StartsWith("#HttpOnly_", StringComparison.OrdinalIgnoreCase))
                    {
                        line = line.Substring("#HttpOnly_".Length).Trim();
                    }
                    else
                    {
                        continue; // Bỏ qua comment
                    }
                }

                var parts = line.Split('\t');
                if (parts.Length >= 7)
                {
                    string name = parts[5].Trim();
                    string val = parts[6].Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        pairs.Add(new KeyValuePair<string, string>(name, val));
                    }
                }
                else if (parts.Length == 6)
                {
                    string name = parts[5].Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        pairs.Add(new KeyValuePair<string, string>(name, ""));
                    }
                }
            }

            if (pairs.Count == 0)
                return "";

            return FormatPairsToRaw(pairs);
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Tự động nhận diện định dạng đầu vào (JSON, Netscape, Base64, Raw) và quy đổi chuẩn về Raw 'c_user=...; xs=...;'.
    /// </summary>
    public static string NormalizeToRaw(string anyCookieInput)
    {
        if (string.IsNullOrWhiteSpace(anyCookieInput))
            return "";

        try
        {
            string s = StripCodeBlock(anyCookieInput.Trim());

            // Bỏ tiền tố "Cookie: " nếu có
            if (s.StartsWith("Cookie:", StringComparison.OrdinalIgnoreCase))
            {
                s = s.Substring(7).Trim();
            }

            // Bỏ bao ngoặc kép/đơn bên ngoài nếu bị bọc
            if ((s.StartsWith("\"") && s.EndsWith("\"")) || (s.StartsWith("'") && s.EndsWith("'")))
            {
                if (s.Length >= 2)
                    s = s.Substring(1, s.Length - 2).Trim();
            }

            // 1. Thử nhận diện Base64
            if (!s.Contains(";") && !s.Contains("\t") && !s.StartsWith("[") && !s.StartsWith("{") && !s.StartsWith("#") && s.Length >= 16)
            {
                string b64Candidate = s.Replace(" ", "").Replace("\r", "").Replace("\n", "");
                int mod = b64Candidate.Length % 4;
                if (mod > 0)
                {
                    b64Candidate = b64Candidate.PadRight(b64Candidate.Length + (4 - mod), '=');
                }

                if (Regex.IsMatch(b64Candidate, @"^[A-Za-z0-9+/]+={0,2}$"))
                {
                    try
                    {
                        byte[] decodedBytes = Convert.FromBase64String(b64Candidate);
                        string decodedText = Encoding.UTF8.GetString(decodedBytes);
                        if (decodedText.Contains("c_user") || decodedText.Contains("xs=") ||
                            decodedText.TrimStart().StartsWith("[") || decodedText.TrimStart().StartsWith("{") ||
                            decodedText.Contains("# Netscape") || (decodedText.Contains("=") && decodedText.Contains(";")))
                        {
                            return NormalizeToRaw(decodedText);
                        }
                    }
                    catch { }
                }
            }

            // 2. Thử nhận diện JSON
            string trimmedStart = s.TrimStart();
            if (trimmedStart.StartsWith("[") || trimmedStart.StartsWith("{"))
            {
                string jsonResult = JsonToRawCookie(s);
                if (!string.IsNullOrWhiteSpace(jsonResult) && jsonResult.Contains("="))
                {
                    return jsonResult;
                }
            }

            // 3. Thử nhận diện Netscape
            if (s.Contains("# Netscape") || s.Contains("\t"))
            {
                string netscapeResult = NetscapeToRawCookie(s);
                if (!string.IsNullOrWhiteSpace(netscapeResult) && netscapeResult.Contains("="))
                {
                    return netscapeResult;
                }
            }

            // 4. Raw Cookie: Phân tách cặp key=value
            var pairs = ParseRawPairs(s);
            if (pairs.Count > 0)
            {
                return FormatPairsToRaw(pairs);
            }

            return s;
        }
        catch
        {
            return anyCookieInput.Trim();
        }
    }

    /// <summary>
    /// Kiểm tra Cookie Facebook có hợp lệ (đủ c_user và xs), bóc tách UID từ c_user.
    /// </summary>
    public static (string uid, bool isValid) ValidateFacebookCookie(string rawCookie)
    {
        if (string.IsNullOrWhiteSpace(rawCookie))
            return ("", false);

        try
        {
            string raw = rawCookie;
            if (!raw.Contains("c_user=") || !raw.Contains("xs="))
            {
                raw = NormalizeToRaw(rawCookie);
            }

            // Bóc tách c_user
            var mUid = Regex.Match(raw, @"(?:^|[;\s])c_user=(\d+)");
            string uid = mUid.Success ? mUid.Groups[1].Value : "";

            // Bóc tách xs
            var mXs = Regex.Match(raw, @"(?:^|[;\s])xs=([^;\s]+)");
            bool hasXs = mXs.Success && !string.IsNullOrWhiteSpace(mXs.Groups[1].Value) &&
                         !mXs.Groups[1].Value.Equals("null", StringComparison.OrdinalIgnoreCase) &&
                         !mXs.Groups[1].Value.Equals("undefined", StringComparison.OrdinalIgnoreCase);

            bool isValid = !string.IsNullOrEmpty(uid) && hasXs;
            return (uid, isValid);
        }
        catch
        {
            return ("", false);
        }
    }

    /// <summary>
    /// Nhận diện loại định dạng của chuỗi cookie (JSON, Netscape, Base64, Raw, hoặc Unknown).
    /// </summary>
    public static string DetectFormat(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "Trống";

        string s = StripCodeBlock(input.Trim());
        if (s.StartsWith("[") || s.StartsWith("{"))
            return "JSON (Puppeteer / EditThisCookie)";
        if (s.Contains("# Netscape") || (s.Contains("\t") && (s.Contains("TRUE") || s.Contains("FALSE"))))
            return "Netscape HTTP";
        if (!s.Contains(";") && !s.Contains("\t") && !s.Contains("=") && s.Length >= 20)
            return "Base64";
        if (s.Contains("c_user=") || s.Contains("xs=") || s.Contains("="))
            return "Raw Cookie";

        return "Không xác định";
    }

    /// <summary>
    /// Phân tách chuỗi nhập nhiều cookie (nhiều dòng Raw, nhiều khối JSON, hoặc Netscape) thành danh sách các cookie Raw chuẩn.
    /// </summary>
    public static List<string> ParseMultipleCookies(string multiInput)
    {
        var result = new List<string>();
        if (string.IsNullOrWhiteSpace(multiInput))
            return result;

        try
        {
            string trimmed = multiInput.Trim();

            // Nếu là 1 JSON Array chứa nhiều tài khoản:
            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                try
                {
                    var token = JToken.Parse(trimmed);
                    if (token is JArray arr)
                    {
                        // Kiểm tra nếu arr chứa các JArray con: [ [ {...} ], [ {...} ] ]
                        if (arr.Count > 0 && arr[0] is JArray)
                        {
                            foreach (var subArr in arr)
                            {
                                string raw = JsonToRawCookie(subArr.ToString());
                                if (!string.IsNullOrWhiteSpace(raw))
                                    result.Add(raw);
                            }
                            if (result.Count > 0) return result;
                        }

                        // Hoặc arr chứa danh sách cookie: đếm số lượng c_user xuất hiện
                        int cUserCount = arr.Count(item => item["name"]?.ToString() == "c_user" || item["Name"]?.ToString() == "c_user");
                        if (cUserCount <= 1)
                        {
                            // Chỉ 1 tài khoản
                            string raw = JsonToRawCookie(trimmed);
                            if (!string.IsNullOrWhiteSpace(raw))
                                result.Add(raw);
                            return result;
                        }
                        else
                        {
                            // Nhiều tài khoản được gộp trong 1 array -> gom nhóm theo c_user
                            var currentAccountCookies = new JArray();
                            foreach (var item in arr)
                            {
                                string name = item["name"]?.ToString() ?? item["Name"]?.ToString() ?? "";
                                if (name == "c_user" && currentAccountCookies.Count > 0)
                                {
                                    string r = JsonToRawCookie(currentAccountCookies.ToString());
                                    if (!string.IsNullOrWhiteSpace(r))
                                        result.Add(r);
                                    currentAccountCookies.Clear();
                                }
                                currentAccountCookies.Add(item);
                            }
                            if (currentAccountCookies.Count > 0)
                            {
                                string r = JsonToRawCookie(currentAccountCookies.ToString());
                                if (!string.IsNullOrWhiteSpace(r))
                                    result.Add(r);
                            }
                            if (result.Count > 0) return result;
                        }
                    }
                }
                catch { }
            }

            // Nếu phân tách theo dòng
            var lines = multiInput.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Kiểm tra xem có phải Netscape với nhiều tài khoản không (phân tách bởi c_user)
            bool isNetscape = lines.Any(l => l.Contains("\t") && (l.Contains(".facebook.com") || l.Contains("TRUE")));
            if (isNetscape)
            {
                var currentBlock = new StringBuilder();
                foreach (var line in lines)
                {
                    if (line.Contains("\tc_user\t") && currentBlock.Length > 0)
                    {
                        string r = NetscapeToRawCookie(currentBlock.ToString());
                        if (!string.IsNullOrWhiteSpace(r))
                            result.Add(r);
                        currentBlock.Clear();
                    }
                    currentBlock.AppendLine(line);
                }
                if (currentBlock.Length > 0)
                {
                    string r = NetscapeToRawCookie(currentBlock.ToString());
                    if (!string.IsNullOrWhiteSpace(r))
                        result.Add(r);
                }
                if (result.Count > 0) return result;
            }

            // Xử lý từng dòng (mỗi dòng có thể là JSON, Base64, hoặc Raw)
            foreach (var line in lines)
            {
                string l = line.Trim();
                if (string.IsNullOrEmpty(l) || l.StartsWith("#"))
                    continue;

                string raw = NormalizeToRaw(l);
                if (!string.IsNullOrWhiteSpace(raw) && raw.Contains("="))
                {
                    result.Add(raw);
                }
            }
        }
        catch { }

        return result;
    }

    /// <summary>
    /// Mã hóa Cookie Raw sang Base64.
    /// </summary>
    public static string ToBase64(string rawCookie)
    {
        if (string.IsNullOrWhiteSpace(rawCookie)) return "";
        byte[] bytes = Encoding.UTF8.GetBytes(rawCookie.Trim());
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Giải mã Cookie từ Base64 về Raw.
    /// </summary>
    public static string Base64ToRaw(string base64)
    {
        return NormalizeToRaw(base64);
    }

    #region Helper Methods
    private static List<KeyValuePair<string, string>> ParseRawPairs(string rawCookie)
    {
        var list = new List<KeyValuePair<string, string>>();

        // Phân tách bằng ';' hoặc xuống dòng
        char[] seps = rawCookie.Contains(";") ? new[] { ';' } : new[] { '\r', '\n' };
        var parts = rawCookie.Split(seps, StringSplitOptions.RemoveEmptyEntries);

        foreach (var p in parts)
        {
            string piece = p.Trim();
            if (string.IsNullOrEmpty(piece)) continue;

            int eq = piece.IndexOf('=');
            if (eq <= 0) continue;

            string name = piece.Substring(0, eq).Trim();
            string val = piece.Substring(eq + 1).Trim();

            // Loại bỏ dấu nháy kép bọc quanh giá trị nếu có
            if (val.StartsWith("\"") && val.EndsWith("\"") && val.Length >= 2)
            {
                val = val.Substring(1, val.Length - 2);
            }

            if (!string.IsNullOrEmpty(name))
            {
                list.RemoveAll(item => string.Equals(item.Key, name, StringComparison.OrdinalIgnoreCase));
                list.Add(new KeyValuePair<string, string>(name, val));
            }
        }

        return list;
    }

    private static void ExtractPairsFromToken(JToken token, List<KeyValuePair<string, string>> pairs)
    {
        if (token is JArray arr)
        {
            foreach (var item in arr)
            {
                if (item is JObject obj)
                {
                    string name = obj["name"]?.ToString() ?? obj["Name"]?.ToString() ??
                                  obj["key"]?.ToString() ?? obj["Key"]?.ToString() ??
                                  obj["cookie_name"]?.ToString();

                    string val = obj["value"]?.ToString() ?? obj["Value"]?.ToString() ??
                                 obj["val"]?.ToString() ?? obj["Val"]?.ToString() ??
                                 obj["cookie_value"]?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(name))
                    {
                        pairs.RemoveAll(x => string.Equals(x.Key, name, StringComparison.OrdinalIgnoreCase));
                        pairs.Add(new KeyValuePair<string, string>(name, val));
                    }
                }
                else if (item is JArray subArr)
                {
                    ExtractPairsFromToken(subArr, pairs);
                }
            }
        }
        else if (token is JObject obj)
        {
            if (obj["cookies"] is JArray cArr)
            {
                ExtractPairsFromToken(cArr, pairs);
            }
            else if (obj["data"] is JArray dArr)
            {
                ExtractPairsFromToken(dArr, pairs);
            }
            else
            {
                // Object dạng { "c_user": "...", "xs": "..." }
                foreach (var prop in obj.Properties())
                {
                    string val = prop.Value?.ToString() ?? "";
                    pairs.RemoveAll(x => string.Equals(x.Key, prop.Name, StringComparison.OrdinalIgnoreCase));
                    pairs.Add(new KeyValuePair<string, string>(prop.Name, val));
                }
            }
        }
    }

    private static string FormatPairsToRaw(List<KeyValuePair<string, string>> pairs)
    {
        if (pairs == null || pairs.Count == 0) return "";

        // Sắp xếp ưu tiên c_user và xs lên đầu
        var ordered = pairs.OrderByDescending(p => p.Key.Equals("c_user", StringComparison.OrdinalIgnoreCase) ? 2 :
                                                   p.Key.Equals("xs", StringComparison.OrdinalIgnoreCase) ? 1 : 0)
                           .ToList();

        var sb = new StringBuilder();
        foreach (var p in ordered)
        {
            sb.Append($"{p.Key}={p.Value}; ");
        }

        return sb.ToString().TrimEnd();
    }

    private static string StripCodeBlock(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";
        string s = input.Trim();
        if (s.StartsWith("```json", StringComparison.OrdinalIgnoreCase))
            s = s.Substring(7);
        else if (s.StartsWith("```"))
            s = s.Substring(3);

        if (s.EndsWith("```"))
            s = s.Substring(0, s.Length - 3);

        return s.Trim();
    }
    #endregion
}
