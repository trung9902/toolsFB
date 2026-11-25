using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

public class ProxyInfo
{
    public string Host { get; set; } = "";
    public int Port { get; set; } = 0;
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    // 0 = HTTP, 1 = SOCKS5
    public int ProxyType { get; set; } = 0;

    public bool IsValid => !string.IsNullOrEmpty(Host) && Port > 0 && Port <= 65535;
    public bool HasAuth => !string.IsNullOrEmpty(Username);

    public override string ToString()
    {
        if (!IsValid) return "";
        string baseStr = HasAuth ? $"{Host}:{Port}:{Username}:{Password}" : $"{Host}:{Port}";
        if (ProxyType == 1) return baseStr + "*1";
        return baseStr;
    }

    public string ToCleanString()
    {
        if (!IsValid) return "";
        return HasAuth ? $"{Host}:{Port}:{Username}:{Password}" : $"{Host}:{Port}";
    }
}

public static class ProxyHelper
{
    public static ProxyInfo Parse(string rawProxy, int defaultType = 0)
    {
        var result = new ProxyInfo { ProxyType = defaultType };
        if (string.IsNullOrWhiteSpace(rawProxy)) return result;

        string s = rawProxy.Trim().TrimEnd(':');

        // Check suffix *0 or *1
        if (s.EndsWith("*0"))
        {
            result.ProxyType = 0;
            s = s.Substring(0, s.Length - 2).Trim();
        }
        else if (s.EndsWith("*1"))
        {
            result.ProxyType = 1;
            s = s.Substring(0, s.Length - 2).Trim();
        }

        // Check scheme prefix
        if (s.StartsWith("socks5://", StringComparison.OrdinalIgnoreCase))
        {
            result.ProxyType = 1;
            s = s.Substring(9).Trim();
        }
        else if (s.StartsWith("socks4://", StringComparison.OrdinalIgnoreCase) || s.StartsWith("socks://", StringComparison.OrdinalIgnoreCase))
        {
            result.ProxyType = 1;
            int idx = s.IndexOf("://", StringComparison.Ordinal);
            s = s.Substring(idx + 3).Trim();
        }
        else if (s.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
        {
            result.ProxyType = 0;
            s = s.Substring(7).Trim();
        }
        else if (s.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            result.ProxyType = 0;
            s = s.Substring(8).Trim();
        }

        // Handle user:pass@host:port format
        if (s.Contains("@"))
        {
            int atIdx = s.IndexOf('@');
            string creds = s.Substring(0, atIdx);
            string endpoint = s.Substring(atIdx + 1);

            int colonCreds = creds.IndexOf(':');
            if (colonCreds >= 0)
            {
                result.Username = creds.Substring(0, colonCreds);
                result.Password = creds.Substring(colonCreds + 1);
            }
            else
            {
                result.Username = creds;
            }

            int colonEp = endpoint.IndexOf(':');
            if (colonEp >= 0)
            {
                result.Host = endpoint.Substring(0, colonEp).Trim();
                if (int.TryParse(endpoint.Substring(colonEp + 1).Trim(), out int p))
                    result.Port = p;
            }
            else
            {
                result.Host = endpoint.Trim();
            }
            return result;
        }

        // Format without '@': split by ':'
        string[] parts = s.Split(':');
        if (parts.Length == 1)
        {
            if (int.TryParse(parts[0], out int p))
            {
                result.Host = "127.0.0.1";
                result.Port = p;
            }
            else
            {
                result.Host = parts[0];
            }
        }
        else if (parts.Length == 2)
        {
            result.Host = parts[0].Trim();
            if (int.TryParse(parts[1].Trim(), out int p))
                result.Port = p;
        }
        else if (parts.Length == 3)
        {
            // Could be host:port:type (where type is 0/1 or http/socks5)
            string lastPart = parts[2].Trim().ToLowerInvariant();
            if (lastPart == "1" || lastPart == "sock5" || lastPart == "socks5")
            {
                result.ProxyType = 1;
                result.Host = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int p)) result.Port = p;
            }
            else if (lastPart == "0" || lastPart == "http" || lastPart == "https")
            {
                result.ProxyType = 0;
                result.Host = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int p)) result.Port = p;
            }
            else
            {
                result.Host = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int p)) result.Port = p;
                result.Username = parts[2].Trim();
            }
        }
        else if (parts.Length == 4)
        {
            // host:port:user:pass
            result.Host = parts[0].Trim();
            if (int.TryParse(parts[1].Trim(), out int p)) result.Port = p;
            result.Username = parts[2].Trim();
            result.Password = parts[3].Trim();
        }
        else if (parts.Length >= 5)
        {
            // host:port:user:pass:type
            result.Host = parts[0].Trim();
            if (int.TryParse(parts[1].Trim(), out int p)) result.Port = p;
            result.Username = parts[2].Trim();
            result.Password = parts[3].Trim();
            string typePart = parts[4].Trim().ToLowerInvariant();
            if (typePart == "1" || typePart == "sock5" || typePart == "socks5")
                result.ProxyType = 1;
            else if (typePart == "0" || typePart == "http" || typePart == "https")
                result.ProxyType = 0;
        }

        return result;
    }

    /// <summary>
    /// Kiểm tra IP Public hiện tại qua đa endpoint (ipify, icanhazip, ifconfig.me).
    /// Tối ưu hóa timeout nhanh (3-5s), không block hoặc làm nghẽn thread pool.
    /// </summary>
    public static string CheckPublicIp(string proxy = "", int proxyType = 0, int timeoutSeconds = 5)
    {
        // 1. Nếu không có proxy, kiểm tra trực tiếp nhanh qua HTTP WebClient nhẹ
        if (string.IsNullOrWhiteSpace(proxy))
        {
            string[] directUrls = new string[] { "http://api64.ipify.org", "http://icanhazip.com", "http://ifconfig.me/ip" };
            foreach (var url in directUrls)
            {
                try
                {
                    var req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "GET";
                    req.Timeout = Math.Min(3000, timeoutSeconds * 1000);
                    req.ReadWriteTimeout = req.Timeout;
                    req.KeepAlive = false;
                    using (var resp = req.GetResponse())
                    using (var s = resp.GetResponseStream())
                    using (var r = new System.IO.StreamReader(s))
                    {
                        string ip = (r.ReadToEnd() ?? "").Trim();
                        if (IPAddress.TryParse(ip, out _)) return ip;
                        Match m = Regex.Match(ip, @"\b(?:\d{1,3}\.){3}\d{1,3}\b");
                        if (m.Success) return m.Value;
                    }
                }
                catch { }
            }
        }

        // 2. Chạy qua Commom.BD994637 với timeout kiểm soát
        try
        {
            return Commom.BD994637(proxy, proxyType, timeoutSeconds);
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Kiểm tra IP Public bất đồng bộ không làm nghẽn luồng gọi
    /// </summary>
    public static async Task<string> CheckPublicIpAsync(string proxy = "", int proxyType = 0, int timeoutSeconds = 5)
    {
        return await Task.Run(() => CheckPublicIp(proxy, proxyType, timeoutSeconds));
    }

    /// <summary>
    /// Cơ chế gọi hàm với Retry Exponential Backoff (500ms -> 1000ms -> 2000ms)
    /// </summary>
    public static T ExecuteWithBackoff<T>(Func<T> action, int maxRetries = 3, int initialDelayMs = 500)
    {
        int delay = initialDelayMs;
        for (int i = 1; i <= maxRetries; i++)
        {
            try
            {
                T res = action();
                if (res != null) return res;
            }
            catch (Exception)
            {
                if (i == maxRetries) throw;
            }
            Thread.Sleep(delay);
            delay *= 2;
        }
        return default(T);
    }

    /// <summary>
    /// Kiểm tra proxy có hoạt động và lấy được IP Public hay không.
    /// </summary>
    public static bool IsProxyLive(string rawProxy, int defaultType = 0)
    {
        var info = Parse(rawProxy, defaultType);
        if (!info.IsValid) return false;
        string ip = CheckPublicIp(info.ToCleanString(), info.ProxyType);
        return !string.IsNullOrEmpty(ip);
    }

    private static readonly ConcurrentDictionary<string, (string country, string isp)> _geoCache = 
        new ConcurrentDictionary<string, (string, string)>();

    public static (string country, string isp) GetGeoInfo(string ip)
    {
        if (string.IsNullOrWhiteSpace(ip)) return ("", "");
        if (_geoCache.TryGetValue(ip, out var cached)) return cached;

        try
        {
            var req = (HttpWebRequest)WebRequest.Create($"http://ip-api.com/json/{ip}?fields=country,isp");
            req.Method = "GET";
            req.Timeout = 2000;
            req.ReadWriteTimeout = 2000;
            req.UserAgent = "Mozilla/5.0";
            using (var resp = req.GetResponse())
            using (var s = resp.GetResponseStream())
            using (var r = new System.IO.StreamReader(s))
            {
                string json = r.ReadToEnd();
                var matchCountry = Regex.Match(json, @"""country""\s*:\s*""([^""]+)""");
                var matchIsp = Regex.Match(json, @"""isp""\s*:\s*""([^""]+)""");
                string country = matchCountry.Success ? matchCountry.Groups[1].Value : "";
                string isp = matchIsp.Success ? matchIsp.Groups[1].Value : "";
                var res = (country, isp);
                _geoCache[ip] = res;
                return res;
            }
        }
        catch
        {
            return ("", "");
        }
    }

    public static ProxyCheckDetail CheckProxyDetail(string rawProxy, int defaultType = 0, int timeoutSeconds = 5)
    {
        var result = new ProxyCheckDetail
        {
            RawInput = rawProxy ?? ""
        };

        if (string.IsNullOrWhiteSpace(rawProxy))
        {
            result.ErrorMessage = "Dữ liệu trống";
            return result;
        }

        var info = Parse(rawProxy, defaultType);
        result.ParsedInfo = info;

        if (!info.IsValid)
        {
            result.ErrorMessage = "Sai định dạng IP:Port";
            return result;
        }

        var sw = Stopwatch.StartNew();
        try
        {
            string ip = CheckPublicIp(info.ToCleanString(), info.ProxyType, timeoutSeconds);
            sw.Stop();
            result.PingMs = sw.ElapsedMilliseconds;

            if (!string.IsNullOrEmpty(ip))
            {
                result.IsLive = true;
                result.PublicIp = ip;
                var geo = GetGeoInfo(ip);
                result.Country = geo.country;
                result.Isp = geo.isp;
            }
            else
            {
                result.IsLive = false;
                result.ErrorMessage = "Không kết nối được / Timeout";
            }
        }
        catch (Exception ex)
        {
            sw.Stop();
            result.PingMs = sw.ElapsedMilliseconds;
            result.IsLive = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    /// <summary>
    /// Kiểm tra nhanh trạng thái Proxy qua ProxyCircuitBreaker trước khi chạy kịch bản (fail-fast).
    /// </summary>
    public static ProxyHealthResult QuickHealthCheck(string rawProxy, int defaultType = 0, int timeoutMs = 3000)
    {
        return ProxyCircuitBreaker.CheckProxyHealth(rawProxy, defaultType, timeoutMs);
    }

    /// <summary>
    /// Kích hoạt cơ chế failover / xoay IP khi phát hiện sự cố proxy giữa chừng.
    /// </summary>
    public static ProxyHealthResult RotateOrRecoverProxy(string proxy, int proxyType, string apiKey = "", string rotateUrl = "")
    {
        return ProxyCircuitBreaker.OnProxyFailureDetected(proxy, proxyType, apiKey, rotateUrl);
    }
}

public class ProxyCheckDetail
{
    public string RawInput { get; set; } = "";
    public ProxyInfo ParsedInfo { get; set; }
    public bool IsLive { get; set; } = false;
    public string PublicIp { get; set; } = "";
    public string Country { get; set; } = "";
    public string Isp { get; set; } = "";
    public long PingMs { get; set; } = 0;
    public string ErrorMessage { get; set; } = "";

    public string ProxyTypeStr => ParsedInfo != null ? (ParsedInfo.ProxyType == 1 ? "SOCKS5" : "HTTP") : "HTTP";
    public string CleanProxy => (ParsedInfo != null && ParsedInfo.IsValid) ? ParsedInfo.ToCleanString() : RawInput;
}
