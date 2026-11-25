using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

/// <summary>
/// SmartTokenHub: Phân hệ trích xuất & quản trị Facebook Access Token Hiện Đại 2026.
/// Hỗ trợ bóc tách EAAG (Ads Manager/Business), EAAB (Meta Business Suite/Graph API Explorer),
/// EAAI (Meta Accounts/Instagram) và kiểm tra tính toàn vẹn (ValidateToken).
/// </summary>
public static class SmartTokenHub
{
    private const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36";

    #region HTTP Request Builder
    /// <summary>
    /// Khởi tạo Leaf.xNet.HttpRequest với cấu hình Headers hiện đại, Cookie storage và Proxy (HTTP/SOCKS5).
    /// </summary>
    private static Leaf.xNet.HttpRequest CreateRequest(string cookie = "", string proxy = "", int proxyType = 0, int timeoutMs = 12000)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        var request = new Leaf.xNet.HttpRequest
        {
            KeepAlive = true,
            AllowAutoRedirect = true,
            ConnectTimeout = timeoutMs,
            ReadWriteTimeout = timeoutMs,
            UserAgent = DefaultUserAgent
        };

        request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        request.AddHeader("Accept-Language", "en-US,en;q=0.9,vi;q=0.8");
        request.AddHeader("sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"");
        request.AddHeader("sec-ch-ua-mobile", "?0");
        request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
        request.AddHeader("sec-fetch-dest", "document");
        request.AddHeader("sec-fetch-mode", "navigate");
        request.AddHeader("sec-fetch-site", "none");
        request.AddHeader("sec-fetch-user", "?1");
        request.AddHeader("upgrade-insecure-requests", "1");

        // Parse & nạp Cookie
        if (!string.IsNullOrWhiteSpace(cookie))
        {
            request.Cookies = new CookieStorage();
            string[] pairs = cookie.Split(';');
            foreach (var pair in pairs)
            {
                var kv = pair.Trim().Split(new char[] { '=' }, 2);
                if (kv.Length == 2 && !string.IsNullOrEmpty(kv[0]))
                {
                    try
                    {
                        request.Cookies.Set(kv[0].Trim(), kv[1].Trim());
                    }
                    catch { }
                }
            }
        }

        // Parse & nạp Proxy (qua ProxyHelper hỗ trợ cả HTTP và SOCKS5)
        if (!string.IsNullOrWhiteSpace(proxy))
        {
            try
            {
                ProxyInfo pInfo = ProxyHelper.Parse(proxy, proxyType);
                if (pInfo.IsValid)
                {
                    ProxyClient pClient = null;
                    if (pInfo.ProxyType == 0) // HTTP
                    {
                        pClient = pInfo.HasAuth
                            ? new HttpProxyClient(pInfo.Host, pInfo.Port, pInfo.Username, pInfo.Password)
                            : new HttpProxyClient(pInfo.Host, pInfo.Port);
                    }
                    else // SOCKS5
                    {
                        pClient = pInfo.HasAuth
                            ? new Socks5ProxyClient(pInfo.Host, pInfo.Port, pInfo.Username, pInfo.Password)
                            : new Socks5ProxyClient(pInfo.Host, pInfo.Port);
                    }
                    if (pClient != null)
                    {
                        pClient.ConnectTimeout = timeoutMs;
                        pClient.ReadWriteTimeout = timeoutMs;
                        request.Proxy = pClient;
                    }
                }
            }
            catch { }
        }

        return request;
    }
    #endregion

    #region Token Extraction Logic
    /// <summary>
    /// Trích xuất Access Token theo tiền tố (EAAG, EAAB, EAAI, EAAA...) từ mã nguồn HTML hoặc chuỗi phản hồi.
    /// </summary>
    public static string ExtractTokenByPrefix(string html, string prefix)
    {
        if (string.IsNullOrEmpty(html)) return "";

        // Chiến lược 1: Tìm trong JSON properties "accessToken":"EAAG..." hoặc "access_token":"EAAG..."
        var match = Regex.Match(html, @"\""access_?token\""\s*:\s*\""(" + prefix + @"[a-zA-Z0-9_\-]+)\""", RegexOptions.IgnoreCase);
        if (match.Success && match.Groups[1].Value.Length >= 25)
        {
            return CleanToken(match.Groups[1].Value);
        }

        // Chiến lược 2: Tìm trong window.__accessToken = "EAAG..." hoặc __accessToken = "EAAG..."
        match = Regex.Match(html, @"(?:window\.)?__accessToken\s*=\s*\""(" + prefix + @"[a-zA-Z0-9_\-]+)\""", RegexOptions.IgnoreCase);
        if (match.Success && match.Groups[1].Value.Length >= 25)
        {
            return CleanToken(match.Groups[1].Value);
        }

        // Chiến lược 3: Tìm token bọc trong dấu ngoặc kép hoặc đơn: "EAAG..."
        match = Regex.Match(html, @"[\""'](" + prefix + @"[a-zA-Z0-9_\-]{25,})[\""']");
        if (match.Success && match.Groups[1].Value.Length >= 25)
        {
            return CleanToken(match.Groups[1].Value);
        }

        // Chiến lược 4: Tìm từ ranh giới chuỗi thuần túy \b(EAAG...)\b
        match = Regex.Match(html, @"\b(" + prefix + @"[a-zA-Z0-9_\-]{30,})\b");
        if (match.Success)
        {
            return CleanToken(match.Groups[1].Value);
        }

        return "";
    }

    private static string CleanToken(string rawToken)
    {
        if (string.IsNullOrEmpty(rawToken)) return "";
        return rawToken.Replace("\\", "").Replace("\"", "").Replace("'", "").Trim();
    }

    /// <summary>
    /// Bóc tách tất cả các Token Facebook hợp lệ có trong tài liệu.
    /// </summary>
    public static List<string> ExtractAllTokens(string text)
    {
        var list = new HashSet<string>();
        if (string.IsNullOrEmpty(text)) return list.ToList();

        var matches = Regex.Matches(text, @"\b(EAA[a-zA-Z0-9_\-]{30,})\b");
        foreach (Match m in matches)
        {
            if (m.Success)
            {
                list.Add(CleanToken(m.Groups[1].Value));
            }
        }
        return list.ToList();
    }

    /// <summary>
    /// Trích xuất Token EAAG (Meta Ads Manager / Business Suite).
    /// Truy cập các endpoint hiện đại: adsmanager, onboarding, business content management, business locations.
    /// </summary>
    public static string GetTokenEAAG(string cookie, string proxy = "", int proxyType = 0)
    {
        if (string.IsNullOrWhiteSpace(cookie))
        {
            return "";
        }

        // Danh sách endpoints ưu tiên của Meta Ads Manager / Business
        string[] targetEndpoints = new string[]
        {
            "https://adsmanager.facebook.com/adsmanager/manage/campaigns",
            "https://adsmanager.facebook.com/adsmanager/onboarding",
            "https://business.facebook.com/content_management",
            "https://business.facebook.com/business_locations/",
            "https://www.facebook.com/adsmanager/manage/campaigns?act="
        };

        foreach (string url in targetEndpoints)
        {
            try
            {
                using (var req = CreateRequest(cookie, proxy, proxyType, 12000))
                {
                    string html = req.Get(url).ToString();
                    if (!string.IsNullOrEmpty(html))
                    {
                        string token = ExtractTokenByPrefix(html, "EAAG");
                        if (!string.IsNullOrEmpty(token) && token.StartsWith("EAAG"))
                        {
                            return token;
                        }

                        // Nếu tìm thấy token EAA khác hợp lệ trong trang Business
                        string generalToken = ExtractTokenByPrefix(html, "EAA");
                        if (!string.IsNullOrEmpty(generalToken) && generalToken.Length > 30)
                        {
                            return generalToken;
                        }
                    }
                }
            }
            catch
            {
                // Thử endpoint tiếp theo nếu gặp lỗi mạng hoặc redirect
                continue;
            }
        }

        return "";
    }

    /// <summary>
    /// Trích xuất Token EAAB (Meta Graph API Explorer / Meta Business Suite).
    /// </summary>
    public static string GetTokenEAAB(string cookie, string proxy = "", int proxyType = 0)
    {
        if (string.IsNullOrWhiteSpace(cookie))
        {
            return "";
        }

        string[] targetEndpoints = new string[]
        {
            "https://developers.facebook.com/tools/explorer/",
            "https://business.facebook.com/latest/home",
            "https://business.facebook.com/settings",
            "https://www.facebook.com/adsmanager/manage/campaigns?act="
        };

        foreach (string url in targetEndpoints)
        {
            try
            {
                using (var req = CreateRequest(cookie, proxy, proxyType, 12000))
                {
                    string html = req.Get(url).ToString();
                    if (!string.IsNullOrEmpty(html))
                    {
                        string token = ExtractTokenByPrefix(html, "EAAB");
                        if (!string.IsNullOrEmpty(token) && token.StartsWith("EAAB"))
                        {
                            return token;
                        }
                    }
                }
            }
            catch
            {
                continue;
            }
        }

        return "";
    }

    /// <summary>
    /// Trích xuất Token EAAI (Meta Accounts Center / Instagram Business).
    /// </summary>
    public static string GetTokenEAAI(string cookie, string proxy = "", int proxyType = 0)
    {
        if (string.IsNullOrWhiteSpace(cookie))
        {
            return "";
        }

        string[] targetEndpoints = new string[]
        {
            "https://accountscenter.facebook.com/",
            "https://business.facebook.com/creatorstudio/"
        };

        foreach (string url in targetEndpoints)
        {
            try
            {
                using (var req = CreateRequest(cookie, proxy, proxyType, 12000))
                {
                    string html = req.Get(url).ToString();
                    if (!string.IsNullOrEmpty(html))
                    {
                        string token = ExtractTokenByPrefix(html, "EAAI");
                        if (!string.IsNullOrEmpty(token) && token.StartsWith("EAAI"))
                        {
                            return token;
                        }
                    }
                }
            }
            catch
            {
                continue;
            }
        }

        return "";
    }
    #endregion

    #region Token Validation
    /// <summary>
    /// Kiểm tra tính toàn vẹn và tình trạng sống/chết của Access Token qua Facebook Graph API.
    /// Endpoint: https://graph.facebook.com/me?fields=id,name,email,permissions&access_token=...
    /// Đồng thời phân tích scopes và expires_at qua debug_token.
    /// </summary>
    public static TokenValidationResult ValidateToken(string token, string proxy = "", int proxyType = 0)
    {
        var result = new TokenValidationResult();
        if (string.IsNullOrWhiteSpace(token))
        {
            result.IsLive = false;
            result.Error = "Token trống";
            return result;
        }

        token = CleanToken(token);
        if (token.Contains("|"))
        {
            var parts = token.Split('|');
            foreach (var p in parts)
            {
                if (p.StartsWith("EAA"))
                {
                    token = p;
                    break;
                }
            }
        }

        // Định danh loại Token dựa theo prefix Meta
        if (token.StartsWith("EAAG")) result.TokenType = "EAAG (Business/Ads)";
        else if (token.StartsWith("EAAB")) result.TokenType = "EAAB (Business Suite/Explorer)";
        else if (token.StartsWith("EAAI")) result.TokenType = "EAAI (Instagram/Accounts)";
        else if (token.StartsWith("EAAAAU")) result.TokenType = "EAAAAU (Android Legacy)";
        else if (token.StartsWith("EAAAAY")) result.TokenType = "EAAAAY (iOS Legacy)";
        else if (token.StartsWith("EAA")) result.TokenType = "EAA (Graph API)";
        else result.TokenType = "Unknown";

        try
        {
            using (var req = CreateRequest("", proxy, proxyType, 9000))
            {
                string urlMe = $"https://graph.facebook.com/me?fields=id,name,email,permissions&access_token={token}";
                string jsonMe = req.Get(urlMe).ToString();
                result.RawJson = jsonMe;

                if (!string.IsNullOrEmpty(jsonMe))
                {
                    JObject jObj = JObject.Parse(jsonMe);
                    if (jObj["error"] != null)
                    {
                        result.IsLive = false;
                        result.Error = jObj["error"]?["message"]?.ToString() ?? "Token hết hạn hoặc không hợp lệ";
                        return result;
                    }

                    if (jObj["id"] != null)
                    {
                        result.IsLive = true;
                        result.Id = jObj["id"]?.ToString() ?? "";
                        result.Name = jObj["name"]?.ToString() ?? "";
                        result.Email = jObj["email"]?.ToString() ?? "";

                        // Phân tích danh sách Scope/Permissions
                        if (jObj["permissions"]?["data"] is JArray permArr)
                        {
                            foreach (var item in permArr)
                            {
                                string perm = item["permission"]?.ToString();
                                string status = item["status"]?.ToString();
                                if (!string.IsNullOrEmpty(perm) && (status == "granted" || string.IsNullOrEmpty(status)))
                                {
                                    result.Scopes.Add(perm);
                                }
                            }
                        }
                    }
                }

                // Truy vấn chi tiết debug_token để xác định hạn dùng expires_at
                if (result.IsLive)
                {
                    try
                    {
                        string urlDebug = $"https://graph.facebook.com/debug_token?input_token={token}&access_token={token}";
                        string jsonDebug = req.Get(urlDebug).ToString();
                        if (!string.IsNullOrEmpty(jsonDebug))
                        {
                            JObject jDebug = JObject.Parse(jsonDebug);
                            var data = jDebug["data"];
                            if (data != null)
                            {
                                long expUnix = data["expires_at"]?.Value<long>() ?? 0;
                                if (expUnix > 0)
                                {
                                    DateTime dt = DateTimeOffset.FromUnixTimeSeconds(expUnix).LocalDateTime;
                                    result.ExpiresAt = dt.ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    result.ExpiresAt = "Vĩnh viễn (Long-lived)";
                                }

                                if (data["scopes"] is JArray debugScopes && result.Scopes.Count == 0)
                                {
                                    foreach (var s in debugScopes)
                                    {
                                        result.Scopes.Add(s.ToString());
                                    }
                                }

                                string appName = data["application"]?.ToString();
                                if (!string.IsNullOrEmpty(appName))
                                {
                                    result.TokenType += $" [{appName}]";
                                }
                            }
                        }
                    }
                    catch
                    {
                        if (string.IsNullOrEmpty(result.ExpiresAt))
                        {
                            result.ExpiresAt = "Hoạt động (Session-bound)";
                        }
                    }

                    if (string.IsNullOrEmpty(result.ExpiresAt))
                    {
                        result.ExpiresAt = "Hoạt động (Session-bound)";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.IsLive = false;
            result.Error = ex.Message;
        }

        return result;
    }
    #endregion

    #region Credentials to Cookie Fallback
    /// <summary>
    /// Đăng nhập nhanh qua giao thức HTTP để trích xuất Cookie phiên làm việc (c_user, xs...)
    /// Phục vụ khi người dùng cấu hình chạy bằng Uid|pass nhưng cần lấy token hiện đại (EAAG/EAAB).
    /// </summary>
    public static string GetCookieFromCredentials(string uid, string pass, string fa2 = "", string proxy = "", int proxyType = 0)
    {
        if (string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(pass))
        {
            return "";
        }

        try
        {
            using (var req = CreateRequest("", proxy, proxyType, 12000))
            {
                // Bước 1: GET trang đăng nhập m.facebook.com để lấy token bảo mật lsd & jazoest
                string loginPage = req.Get("https://m.facebook.com/login.php").ToString();
                string lsd = Regex.Match(loginPage, @"name=""lsd""\s+value=""(.*?)""").Groups[1].Value;
                string jazoest = Regex.Match(loginPage, @"name=""jazoest""\s+value=""(.*?)""").Groups[1].Value;

                if (string.IsNullOrEmpty(lsd)) lsd = "AVr";
                if (string.IsNullOrEmpty(jazoest)) jazoest = "2";

                // Bước 2: POST thông tin đăng nhập
                string postData = $"email={WebUtility.UrlEncode(uid)}&pass={WebUtility.UrlEncode(pass)}&lsd={lsd}&jazoest={jazoest}&login=Log+In";
                string response = req.Post("https://m.facebook.com/login/device-based/regular/login/?refsrc=deprecated&lwv=100", postData, "application/x-www-form-urlencoded").ToString();

                string currentCookies = req.Cookies.ToString();
                if (currentCookies.Contains("c_user=") && currentCookies.Contains("xs="))
                {
                    return currentCookies;
                }

                // Bước 3: Nếu yêu cầu 2FA (approvals_code)
                if (response.Contains("approvals_code") && !string.IsNullOrWhiteSpace(fa2))
                {
                    string otpCode = Commom.smethod_62(fa2);
                    if (!string.IsNullOrEmpty(otpCode))
                    {
                        string submit2Fa = $"approvals_code={otpCode}&save_device=1&submit[Submit+Code]=Submit+Code";
                        req.Post("https://m.facebook.com/login/checkpoint/", submit2Fa, "application/x-www-form-urlencoded");

                        currentCookies = req.Cookies.ToString();
                        if (currentCookies.Contains("c_user="))
                        {
                            return currentCookies;
                        }
                    }
                }

                if (currentCookies.Contains("c_user="))
                {
                    return currentCookies;
                }
            }
        }
        catch { }

        return "";
    }
    #endregion
}

/// <summary>
/// Cấu trúc kết quả phân tích & kiểm tra Facebook Token.
/// Hỗ trợ chuyển đổi ngầm định sang bool (IsLive) và string để tương thích mọi vị trí gọi.
/// </summary>
public class TokenValidationResult
{
    public bool IsLive { get; set; } = false;
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string ExpiresAt { get; set; } = "";
    public List<string> Scopes { get; set; } = new List<string>();
    public string TokenType { get; set; } = "";
    public string Error { get; set; } = "";
    public string RawJson { get; set; } = "";

    public override string ToString()
    {
        if (IsLive)
        {
            string scopesStr = (Scopes != null && Scopes.Count > 0) ? string.Join(", ", Scopes) : "standard";
            return $"Live|ID: {Id}|Name: {Name}|Expires: {ExpiresAt}|Scopes: {scopesStr}";
        }
        return $"Die|{Error}";
    }

    public static implicit operator bool(TokenValidationResult res) => res != null && res.IsLive;
    public static implicit operator string(TokenValidationResult res) => res?.ToString() ?? "Die";
}
