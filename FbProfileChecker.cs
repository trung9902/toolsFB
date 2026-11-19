using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

public class FbProfileChecker
{
    private static readonly ConcurrentDictionary<string, Image> _avatarCache = new ConcurrentDictionary<string, Image>();

    public class FastCheckAccountResult
    {
        public bool Success { get; set; }
        public string Status { get; set; } = "Không check được";
        public bool IsLive => Status == "Live";
        public bool IsCheckpoint => Status != null && Status.StartsWith("Checkpoint", StringComparison.OrdinalIgnoreCase);
        public string CheckpointType { get; set; } = "";
        public string Uid { get; set; } = "";
        public string RedirectUrl { get; set; } = "";
        public int StatusCode { get; set; }
        public long ElapsedMs { get; set; }
        public string ErrorMessage { get; set; } = "";

        public static implicit operator string(FastCheckAccountResult res)
        {
            return res?.Status ?? "Không check được";
        }

        public override string ToString()
        {
            return Status;
        }
    }

    public class AccountCheckItem
    {
        public string Uid { get; set; } = "";
        public string Cookie { get; set; } = "";
        public string Proxy { get; set; } = "";
        public int ProxyType { get; set; } = 0;
        public string Status { get; set; } = "";
        public FastCheckAccountResult Result { get; set; }
        public int RowIndex { get; set; } = -1;
        public object Tag { get; set; }
    }

    public class ProfileResult
    {
        public bool Success { get; set; }
        public bool IsLive { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public bool HasAvatar { get; set; }
        public string ErrorMessage { get; set; }
    }

    public static string GetAvatarFolderPath()
    {
        string path = Path.Combine(Commom.smethod_95(), "avatar");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path;
    }

    public static string GetAvatarFilePath(string uid)
    {
        return Path.Combine(GetAvatarFolderPath(), uid + ".png");
    }

    public static Image GetAvatarImage(string uid)
    {
        if (string.IsNullOrEmpty(uid)) return null;

        if (_avatarCache.TryGetValue(uid, out Image cached) && cached != null)
        {
            return cached;
        }

        string filePath = GetAvatarFilePath(uid);
        if (!File.Exists(filePath))
        {
            string jpgPath = Path.Combine(GetAvatarFolderPath(), uid + ".jpg");
            if (File.Exists(jpgPath)) filePath = jpgPath;
        }

        if (File.Exists(filePath))
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (Image temp = Image.FromStream(ms))
                    {
                        Image cloned = new Bitmap(temp);
                        _avatarCache[uid] = cloned;
                        return cloned;
                    }
                }
            }
            catch
            {
            }
        }

        return null;
    }

    public static void SetAvatarImage(string uid, Image img)
    {
        if (!string.IsNullOrEmpty(uid) && img != null)
        {
            _avatarCache[uid] = img;
        }
    }

    public static ProfileResult CheckProfile(string uid, string proxy = "", int proxyType = 0)
    {
        ProfileResult result = new ProfileResult
        {
            Uid = uid,
            Success = false,
            IsLive = false,
            Name = "",
            AvatarUrl = "",
            HasAvatar = false
        };

        if (string.IsNullOrWhiteSpace(uid))
        {
            result.ErrorMessage = "UID rỗng!";
            return result;
        }

        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string urlMobile = "https://m.facebook.com/profile.php?id=" + uid.Trim();
            string html = RequestGet(urlMobile, proxy, proxyType, isMobile: true);

            string name = ExtractName(html);
            string avatarUrl = ExtractAvatarUrl(html);

            if (string.IsNullOrEmpty(name))
            {
                string urlWeb = "https://www.facebook.com/profile.php?id=" + uid.Trim();
                string htmlWeb = RequestGet(urlWeb, proxy, proxyType, isMobile: false);
                name = ExtractName(htmlWeb);
                if (string.IsNullOrEmpty(avatarUrl))
                {
                    avatarUrl = ExtractAvatarUrl(htmlWeb);
                }
            }

            bool isDie = string.IsNullOrEmpty(name)
                         || name.Equals("Facebook", StringComparison.OrdinalIgnoreCase)
                         || name.Contains("Đăng nhập")
                         || name.Contains("Log in")
                         || name.Contains("Page Not Found")
                         || name.Contains("Trang không tìm thấy")
                         || name.Contains("Lỗi")
                         || name.Contains("Error");

            if (isDie)
            {
                result.Success = true;
                result.IsLive = false;
                result.ErrorMessage = "Tài khoản Die hoặc không tìm thấy trang cá nhân!";
                return result;
            }

            result.Success = true;
            result.IsLive = true;
            result.Name = name;
            result.AvatarUrl = avatarUrl;

            // Tải và lưu avatar nếu có
            if (string.IsNullOrEmpty(avatarUrl) || avatarUrl.Contains("static.xx.fbcdn.net"))
            {
                avatarUrl = "https://graph.facebook.com/" + uid.Trim() + "/picture?type=large";
            }

            try
            {
                byte[] imgBytes = DownloadBytes(avatarUrl, proxy, proxyType);
                if (imgBytes != null && imgBytes.Length > 0)
                {
                    string savePath = GetAvatarFilePath(uid.Trim());
                    File.WriteAllBytes(savePath, imgBytes);
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        using (Image temp = Image.FromStream(ms))
                        {
                            Image cloned = new Bitmap(temp);
                            _avatarCache[uid.Trim()] = cloned;
                        }
                    }
                    result.HasAvatar = true;
                }
            }
            catch
            {
            }

            return result;
        }
        catch (Exception ex)
        {
            result.ErrorMessage = ex.Message;
            return result;
        }
    }

    private static string ExtractName(string html)
    {
        if (string.IsNullOrEmpty(html)) return "";

        string name = "";
        Match mOgTitle = Regex.Match(html, "property=\"og:title\"\\s+content=\"(.*?)\"", RegexOptions.IgnoreCase);
        if (mOgTitle.Success)
        {
            name = WebUtility.HtmlDecode(mOgTitle.Groups[1].Value).Trim();
        }

        if (string.IsNullOrEmpty(name))
        {
            Match mTitle = Regex.Match(html, "<title>(.*?)</title>", RegexOptions.IgnoreCase);
            if (mTitle.Success)
            {
                name = WebUtility.HtmlDecode(mTitle.Groups[1].Value).Trim();
            }
        }

        if (name.EndsWith(" | Facebook", StringComparison.OrdinalIgnoreCase))
        {
            name = name.Substring(0, name.Length - " | Facebook".Length).Trim();
        }

        return name;
    }

    private static string ExtractAvatarUrl(string html)
    {
        if (string.IsNullOrEmpty(html)) return "";

        Match mOgImg = Regex.Match(html, "property=\"og:image\"\\s+content=\"(.*?)\"", RegexOptions.IgnoreCase);
        if (mOgImg.Success)
        {
            return WebUtility.HtmlDecode(mOgImg.Groups[1].Value).Trim();
        }

        return "";
    }

    private static string RequestGet(string url, string proxy, int proxyType, bool isMobile)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 10000;
            request.ReadWriteTimeout = 10000;
            request.AllowAutoRedirect = true;

            if (isMobile)
            {
                request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 16_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.5 Mobile/15E148 Safari/604.1";
            }
            else
            {
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
            }

            request.Headers["Accept-Language"] = "vi-VN,vi;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            ApplyProxy(request, proxy, proxyType);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
        catch (WebException wex)
        {
            if (wex.Response != null)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(wex.Response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch { }
            }
        }
        catch { }

        return "";
    }

    private static byte[] DownloadBytes(string url, string proxy, int proxyType)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 12000;
            request.ReadWriteTimeout = 12000;
            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";

            ApplyProxy(request, proxy, proxyType);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
        catch
        {
            return null;
        }
    }

    private static void ApplyProxy(HttpWebRequest request, string proxy, int proxyType)
    {
        if (string.IsNullOrEmpty(proxy)) return;

        try
        {
            ProxyInfo info = ProxyHelper.Parse(proxy, proxyType);
            if (info.IsValid)
            {
                if (info.HasAuth)
                {
                    request.Proxy = new WebProxy(info.Host, info.Port)
                    {
                        Credentials = new NetworkCredential(info.Username, info.Password)
                    };
                }
                else
                {
                    request.Proxy = new WebProxy(info.Host, info.Port);
                }
            }
            else
            {
                string[] parts = proxy.Trim().Split(':');
                if (parts.Length == 2)
                {
                    request.Proxy = new WebProxy(parts[0], int.Parse(parts[1]));
                }
                else if (parts.Length == 4)
                {
                    request.Proxy = new WebProxy(parts[0], int.Parse(parts[1]))
                    {
                        Credentials = new NetworkCredential(parts[2], parts[3])
                    };
                }
            }
        }
        catch
        {
        }
    }

    #region Fast Live/Die HTTP Account Checker (<1s siêu tốc, không mở trình duyệt)

    public static string ExtractUidFromCookie(string cookie)
    {
        if (string.IsNullOrWhiteSpace(cookie)) return "";
        Match match = Regex.Match(cookie, @"(?:^|;|\s)c_user=(\d+)");
        if (match.Success) return match.Groups[1].Value;
        return "";
    }

    public static string NormalizeCookie(string rawCookie)
    {
        if (string.IsNullOrWhiteSpace(rawCookie)) return "";
        string trimmed = rawCookie.Trim();

        // Định dạng mảng JSON từ Extension xuất Cookie
        if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
        {
            try
            {
                JArray arr = JArray.Parse(trimmed);
                StringBuilder sb = new StringBuilder();
                foreach (JObject item in arr)
                {
                    string name = item["name"]?.ToString();
                    string value = item["value"]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        sb.Append($"{name}={value}; ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ';');
            }
            catch { }
        }

        string[] parts = trimmed.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> cleanParts = new List<string>();
        foreach (var p in parts)
        {
            string t = p.Trim();
            if (t.Contains("="))
            {
                cleanParts.Add(t);
            }
        }
        return string.Join("; ", cleanParts);
    }

    public static string FastCheckAccountStatus(string uid, string cookie, string proxy = "", int proxyType = 0)
    {
        var result = FastCheckAccountStatusDetailed(uid, cookie, proxy, proxyType);
        return result.Status;
    }

    public static FastCheckAccountResult FastCheckAccountStatusDetailed(string uid, string cookie, string proxy = "", int proxyType = 0)
    {
        Stopwatch sw = Stopwatch.StartNew();
        FastCheckAccountResult result = new FastCheckAccountResult
        {
            Uid = uid ?? "",
            Success = false,
            Status = "Không check được"
        };

        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (string.IsNullOrWhiteSpace(result.Uid) && !string.IsNullOrWhiteSpace(cookie))
            {
                result.Uid = ExtractUidFromCookie(cookie);
            }

            string normCookie = NormalizeCookie(cookie);

            if (string.IsNullOrWhiteSpace(normCookie))
            {
                if (!string.IsNullOrWhiteSpace(result.Uid))
                {
                    var wall = CheckProfile(result.Uid, proxy, proxyType);
                    sw.Stop();
                    result.ElapsedMs = sw.ElapsedMilliseconds;
                    result.Success = true;
                    result.Status = (wall.Success && wall.IsLive) ? "Live" : "Die / Vô hiệu hóa";
                    return result;
                }

                sw.Stop();
                result.ElapsedMs = sw.ElapsedMilliseconds;
                result.Success = true;
                result.Status = "Changed pass / Cookie Die";
                result.ErrorMessage = "Cookie rỗng!";
                return result;
            }

            if (!normCookie.Contains("c_user="))
            {
                sw.Stop();
                result.ElapsedMs = sw.ElapsedMilliseconds;
                result.Success = true;
                result.Status = "Changed pass / Cookie Die";
                result.ErrorMessage = "Cookie không chứa c_user";
                return result;
            }

            ProxyInfo proxyInfo = ProxyHelper.Parse(proxy, proxyType);

            // SOCKS5 Proxy Handling qua Leaf.xNet
            if (proxyInfo.IsValid && proxyInfo.ProxyType == 1)
            {
                return FastCheckWithXNet(normCookie, proxyInfo, result, sw);
            }

            // Direct / HTTP Proxy qua HttpWebRequest (siêu nhẹ, non-redirect, <300ms)
            return FastCheckWithHttpWebRequest(normCookie, proxy, proxyType, result, sw);
        }
        catch (Exception ex)
        {
            sw.Stop();
            result.ElapsedMs = sw.ElapsedMilliseconds;
            result.ErrorMessage = ex.Message;
            result.Status = "Không check được";
            return result;
        }
    }

    private static FastCheckAccountResult FastCheckWithHttpWebRequest(
        string normCookie, string proxy, int proxyType, FastCheckAccountResult result, Stopwatch sw)
    {
        string location = "";
        string body = "";
        int statusCode = 0;

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://m.facebook.com/me");
            request.Method = "GET";
            request.Timeout = 5000;
            request.ReadWriteTimeout = 5000;
            request.AllowAutoRedirect = false; // Ngắt ngay khi có 302 để đọc Location header trong <300ms!
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
            request.Headers["Accept-Language"] = "vi-VN,vi;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers["Cookie"] = normCookie;

            ApplyProxy(request, proxy, proxyType);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                statusCode = (int)response.StatusCode;
                location = response.Headers["Location"] ?? "";
                if (string.IsNullOrEmpty(location))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        body = reader.ReadToEnd();
                    }
                }
            }
        }
        catch (WebException wex)
        {
            if (wex.Response is HttpWebResponse errResp)
            {
                statusCode = (int)errResp.StatusCode;
                location = errResp.Headers["Location"] ?? "";
                try
                {
                    using (StreamReader reader = new StreamReader(errResp.GetResponseStream()))
                    {
                        body = reader.ReadToEnd();
                    }
                }
                catch { }
            }
            else
            {
                string gqlStatus = FastCheckGraphQL(normCookie, proxy, proxyType);
                if (gqlStatus != "Không check được")
                {
                    sw.Stop();
                    result.ElapsedMs = sw.ElapsedMilliseconds;
                    result.Success = true;
                    result.Status = gqlStatus;
                    return result;
                }

                sw.Stop();
                result.ElapsedMs = sw.ElapsedMilliseconds;
                result.ErrorMessage = wex.Message;
                result.Status = "Không check được";
                return result;
            }
        }

        sw.Stop();
        result.ElapsedMs = sw.ElapsedMilliseconds;
        result.StatusCode = statusCode;
        result.RedirectUrl = location;
        EvaluateFacebookResponse(location, body, statusCode, result);
        return result;
    }

    private static FastCheckAccountResult FastCheckWithXNet(
        string normCookie, ProxyInfo proxyInfo, FastCheckAccountResult result, Stopwatch sw)
    {
        try
        {
            using (var xnet = new Leaf.xNet.HttpRequest())
            {
                xnet.AllowAutoRedirect = false;
                xnet.ConnectTimeout = 5000;
                xnet.ReadWriteTimeout = 5000;
                xnet.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
                xnet.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                xnet.AddHeader("Accept-Language", "vi-VN,vi;q=0.9,en-US;q=0.8,en;q=0.7");

                string[] pairs = normCookie.Split(';');
                foreach (var p in pairs)
                {
                    var kv = p.Trim().Split(new[] { '=' }, 2);
                    if (kv.Length == 2)
                    {
                        try { xnet.Cookies.Set(kv[0].Trim(), kv[1].Trim()); } catch { }
                    }
                }

                if (proxyInfo.HasAuth)
                {
                    xnet.Proxy = new Socks5ProxyClient(proxyInfo.Host, proxyInfo.Port, proxyInfo.Username, proxyInfo.Password);
                }
                else
                {
                    xnet.Proxy = new Socks5ProxyClient(proxyInfo.Host, proxyInfo.Port);
                }
                xnet.Proxy.ConnectTimeout = 5000;
                xnet.Proxy.ReadWriteTimeout = 5000;

                string location = "";
                string body = "";
                int statusCode = 0;

                try
                {
                    var resp = xnet.Get("https://m.facebook.com/me");
                    statusCode = (int)resp.StatusCode;
                    location = resp.Location ?? "";
                    if (string.IsNullOrEmpty(location))
                    {
                        body = resp.ToString();
                    }
                }
                catch (Exception)
                {
                    if (xnet.Response != null)
                    {
                        statusCode = (int)xnet.Response.StatusCode;
                        location = xnet.Response.Location ?? "";
                        try { body = xnet.Response.ToString(); } catch { }
                    }
                }

                sw.Stop();
                result.ElapsedMs = sw.ElapsedMilliseconds;
                result.StatusCode = statusCode;
                result.RedirectUrl = location;
                EvaluateFacebookResponse(location, body, statusCode, result);
                return result;
            }
        }
        catch (Exception ex)
        {
            sw.Stop();
            result.ElapsedMs = sw.ElapsedMilliseconds;
            result.ErrorMessage = ex.Message;
            result.Status = "Không check được";
            return result;
        }
    }

    private static void EvaluateFacebookResponse(string location, string body, int statusCode, FastCheckAccountResult result)
    {
        string combined = (location + " " + body).ToLowerInvariant();

        // 1. Checkpoint 956 (828281030927956 hoặc 601051028565049)
        if (combined.Contains("828281030927956") || combined.Contains("601051028565049"))
        {
            result.Status = "Checkpoint 956";
            result.CheckpointType = "956";
            result.Success = true;
            return;
        }

        // 2. Checkpoint 282 (1501092823525282)
        if (combined.Contains("1501092823525282"))
        {
            result.Status = "Checkpoint 282";
            result.CheckpointType = "282";
            result.Success = true;
            return;
        }

        // 3. Die / Vô hiệu hóa
        if (combined.Contains("checkpoint/disabled") ||
            combined.Contains("help/contact/260749603972907") ||
            combined.Contains("help/contact/357439354283890") ||
            combined.Contains("your account has been disabled") ||
            combined.Contains("tài khoản của bạn đã bị vô hiệu hóa") ||
            combined.Contains("account_disabled"))
        {
            result.Status = "Die / Vô hiệu hóa";
            result.Success = true;
            return;
        }

        // 4. Changed pass / Cookie Die / Bị đẩy ra Login
        if (combined.Contains("login.php") ||
            combined.Contains("facebook.com/login") ||
            combined.Contains("/login/") ||
            combined.Contains("session_expired") ||
            combined.Contains("phiên đăng nhập đã hết hạn") ||
            combined.Contains("id=\"login_form\"") ||
            combined.Contains("name=\"login\"") ||
            combined.Contains("login_attempt"))
        {
            result.Status = "Changed pass / Cookie Die";
            result.Success = true;
            return;
        }

        // 5. Dạng Checkpoint khác
        if (combined.Contains("/checkpoint/") || combined.Contains("checkpoint"))
        {
            Match cpMatch = Regex.Match(combined, @"checkpoint/(\d+)");
            if (cpMatch.Success)
            {
                string cpId = cpMatch.Groups[1].Value;
                if (cpId == "828281030927956" || cpId == "601051028565049")
                    result.Status = "Checkpoint 956";
                else if (cpId == "1501092823525282")
                    result.Status = "Checkpoint 282";
                else
                    result.Status = "Checkpoint " + cpId;
            }
            else
            {
                result.Status = "Checkpoint 956";
            }
            result.Success = true;
            return;
        }

        // 6. Live
        if (!string.IsNullOrEmpty(location) &&
            !location.Contains("login") &&
            !location.Contains("checkpoint"))
        {
            result.Status = "Live";
            result.Success = true;
            return;
        }

        if (statusCode == 200 && (combined.Contains("c_user") ||
                                  combined.Contains("user_id") ||
                                  combined.Contains("account_id") ||
                                  combined.Contains("viewer") ||
                                  combined.Contains("m_home_stream") ||
                                  combined.Contains("composer") ||
                                  combined.Contains("profile.php")))
        {
            result.Status = "Live";
            result.Success = true;
            return;
        }

        if (statusCode >= 200 && statusCode < 400 && !combined.Contains("login") && !combined.Contains("checkpoint"))
        {
            result.Status = "Live";
            result.Success = true;
            return;
        }

        result.Status = "Không check được";
    }

    public static string FastCheckGraphQL(string cookie, string proxy = "", int proxyType = 0)
    {
        try
        {
            string normCookie = NormalizeCookie(cookie);
            if (string.IsNullOrWhiteSpace(normCookie)) return "Changed pass / Cookie Die";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.facebook.com/api/graphql/");
            request.Method = "POST";
            request.Timeout = 4000;
            request.ReadWriteTimeout = 4000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers["Cookie"] = normCookie;
            request.Headers["Accept-Language"] = "vi-VN,vi;q=0.9,en-US;q=0.8,en;q=0.7";
            ApplyProxy(request, proxy, proxyType);

            string postData = "doc_id=7863557980324041&variables={}";
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream os = request.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length);
            }

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                if (json.Contains("828281030927956")) return "Checkpoint 956";
                if (json.Contains("1501092823525282")) return "Checkpoint 282";
                if (json.Contains("checkpoint/disabled") || json.Contains("account_disabled")) return "Die / Vô hiệu hóa";
                if (json.Contains("1357004") || json.Contains("Not logged in") || json.Contains("login")) return "Changed pass / Cookie Die";
                if (json.Contains("\"data\"") || json.Contains("viewer")) return "Live";
            }
        }
        catch (WebException wex)
        {
            if (wex.Response is HttpWebResponse errResp)
            {
                string loc = errResp.Headers["Location"] ?? "";
                if (loc.Contains("828281030927956")) return "Checkpoint 956";
                if (loc.Contains("1501092823525282")) return "Checkpoint 282";
                if (loc.Contains("disabled")) return "Die / Vô hiệu hóa";
                if (loc.Contains("login")) return "Changed pass / Cookie Die";
            }
        }
        catch { }
        return "Không check được";
    }

    public static List<AccountCheckItem> FastCheckBatch(
        IList<AccountCheckItem> items,
        int maxParallel = 20,
        Action<AccountCheckItem, int, int> callback = null)
    {
        if (items == null || items.Count == 0) return new List<AccountCheckItem>();

        int completed = 0;
        int total = items.Count;

        Parallel.ForEach(items, new ParallelOptions { MaxDegreeOfParallelism = Math.Max(1, maxParallel) }, item =>
        {
            try
            {
                item.Result = FastCheckAccountStatusDetailed(item.Uid, item.Cookie, item.Proxy, item.ProxyType);
                item.Status = item.Result.Status;
            }
            catch (Exception ex)
            {
                item.Status = "Không check được";
                item.Result = new FastCheckAccountResult { Status = item.Status, ErrorMessage = ex.Message };
            }
            finally
            {
                int c = Interlocked.Increment(ref completed);
                callback?.Invoke(item, c, total);
            }
        });

        return items as List<AccountCheckItem> ?? new List<AccountCheckItem>(items);
    }

    public static async Task<List<AccountCheckItem>> FastCheckBatchAsync(
        IList<AccountCheckItem> items,
        int maxParallel = 20,
        IProgress<AccountCheckItem> progress = null,
        CancellationToken cancellationToken = default)
    {
        if (items == null || items.Count == 0) return new List<AccountCheckItem>();

        using (var semaphore = new SemaphoreSlim(Math.Max(1, maxParallel), Math.Max(1, maxParallel)))
        {
            var tasks = items.Select(async item =>
            {
                await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    if (cancellationToken.IsCancellationRequested) return item;

                    item.Result = await Task.Run(() =>
                        FastCheckAccountStatusDetailed(item.Uid, item.Cookie, item.Proxy, item.ProxyType), cancellationToken)
                        .ConfigureAwait(false);
                    item.Status = item.Result.Status;
                    progress?.Report(item);
                    return item;
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        return items as List<AccountCheckItem> ?? new List<AccountCheckItem>(items);
    }

    #endregion
}
