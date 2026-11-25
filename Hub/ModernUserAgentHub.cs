using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Hub quản lý và sinh User-Agent + Client Hints hiện đại chuẩn 2026.
/// Thay thế toàn bộ các User-Agent lỗi thời (Chrome 74, iOS 3-13, v.v.)
/// Hỗ trợ Chrome 128 - 134, macOS Sonoma/Sequoia, iOS 17 - 18, Android 14 - 15.
/// </summary>
public static class ModernUserAgentHub
{
    private static readonly Random _rand = new Random();

    // Chrome builds thực tế từ 128 đến 134
    private static readonly string[] DesktopChromeVersions = new string[]
    {
        "128.0.6613.138",
        "129.0.6668.101",
        "130.0.6723.117",
        "131.0.6778.205",
        "132.0.6834.160",
        "133.0.6943.142",
        "134.0.6998.35"
    };

    private static readonly string[] WindowsVersions = new string[]
    {
        "Windows NT 10.0; Win64; x64"
    };

    private static readonly string[] MacVersions = new string[]
    {
        "Macintosh; Intel Mac OS X 10_15_7",
        "Macintosh; Intel Mac OS X 14_5",
        "Macintosh; Intel Mac OS X 14_7",
        "Macintosh; Intel Mac OS X 15_1",
        "Macintosh; Intel Mac OS X 15_3"
    };

    private static readonly string[] IphoneSpecs = new string[]
    {
        // iOS 17.4 - 17.7
        "iPhone; CPU iPhone OS 17_4_1 like Mac OS X|17.4.1|605.1.15",
        "iPhone; CPU iPhone OS 17_5_1 like Mac OS X|17.5.1|605.1.15",
        "iPhone; CPU iPhone OS 17_6_1 like Mac OS X|17.6.1|605.1.15",
        "iPhone; CPU iPhone OS 17_7 like Mac OS X|17.7|605.1.15",
        // iOS 18.0 - 18.3
        "iPhone; CPU iPhone OS 18_0 like Mac OS X|18.0|605.1.15",
        "iPhone; CPU iPhone OS 18_0_1 like Mac OS X|18.0.1|605.1.15",
        "iPhone; CPU iPhone OS 18_1 like Mac OS X|18.1|605.1.15",
        "iPhone; CPU iPhone OS 18_1_1 like Mac OS X|18.1.1|605.1.15",
        "iPhone; CPU iPhone OS 18_2 like Mac OS X|18.2|605.1.15",
        "iPhone; CPU iPhone OS 18_3 like Mac OS X|18.3|605.1.15"
    };

    private static readonly string[] AndroidDevices = new string[]
    {
        // Samsung Galaxy S23 / S24 / Pixel 8 / Pixel 9
        "Linux; Android 14; SM-S918B",
        "Linux; Android 14; SM-S928B",
        "Linux; Android 14; Pixel 8 Pro",
        "Linux; Android 14; SM-A546B",
        "Linux; Android 15; Pixel 9 Pro",
        "Linux; Android 15; SM-S938B",
        "Linux; Android 15; Pixel 8a"
    };

    /// <summary>
    /// Sinh User-Agent Chrome Desktop chuẩn Windows 10/11 (Chrome 128 - 134).
    /// </summary>
    public static string GetRandomDesktopChrome()
    {
        lock (_rand)
        {
            string ver = DesktopChromeVersions[_rand.Next(DesktopChromeVersions.Length)];
            string win = WindowsVersions[_rand.Next(WindowsVersions.Length)];
            return $"Mozilla/5.0 ({win}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{ver} Safari/537.36";
        }
    }

    /// <summary>
    /// Sinh User-Agent Chrome macOS 14/15 Sonoma / Sequoia (Chrome 128 - 134).
    /// </summary>
    public static string GetRandomMacChrome()
    {
        lock (_rand)
        {
            string ver = DesktopChromeVersions[_rand.Next(DesktopChromeVersions.Length)];
            string mac = MacVersions[_rand.Next(MacVersions.Length)];
            return $"Mozilla/5.0 ({mac}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{ver} Safari/537.36";
        }
    }

    /// <summary>
    /// Sinh User-Agent iPhone chuẩn iOS 17 - 18 (Safari, CriOS, FBAV/Facebook App).
    /// </summary>
    public static string GetRandomIphone()
    {
        lock (_rand)
        {
            string item = IphoneSpecs[_rand.Next(IphoneSpecs.Length)];
            string[] parts = item.Split('|');
            string os = parts[0];
            string safariVer = parts[1];

            int type = _rand.Next(3);
            if (type == 0)
            {
                // Mobile Safari
                return $"Mozilla/5.0 ({os}) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/{safariVer} Mobile/15E148 Safari/604.1";
            }
            else if (type == 1)
            {
                // Chrome on iOS (CriOS)
                string chromeVer = DesktopChromeVersions[_rand.Next(DesktopChromeVersions.Length)];
                return $"Mozilla/5.0 ({os}) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/{chromeVer} Mobile/15E148 Safari/604.1";
            }
            else
            {
                // Facebook App iOS
                return $"Mozilla/5.0 ({os}) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 [FBAN/FBIOS;FBAV/470.0.0.44.110;FBBV/598000000;FBDV/iPhone15,2;FBMD/iPhone;FBSN/iOS;FBSV/{safariVer};FBSS/3;FBCR/Viettel;FBID/phone;FBLC/vi_VN;FBOP/5]";
            }
        }
    }

    /// <summary>
    /// Danh sách User-Agent iPhone hiện đại dùng cho danh mục fallback / test.
    /// </summary>
    public static List<string> GetAllModernIphoneUserAgents()
    {
        List<string> list = new List<string>();
        foreach (string item in IphoneSpecs)
        {
            string[] parts = item.Split('|');
            string os = parts[0];
            string safariVer = parts[1];

            // Mobile Safari
            list.Add($"Mozilla/5.0 ({os}) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/{safariVer} Mobile/15E148 Safari/604.1");
            // CriOS
            list.Add($"Mozilla/5.0 ({os}) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/131.0.6778.205 Mobile/15E148 Safari/604.1");
            // Facebook
            list.Add($"Mozilla/5.0 ({os}) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 [FBAN/FBIOS;FBAV/470.0.0.44.110;FBBV/598000000;FBDV/iPhone15,2;FBMD/iPhone;FBSN/iOS;FBSV/{safariVer};FBSS/3;FBCR/Viettel;FBID/phone;FBLC/vi_VN;FBOP/5]");
        }
        return list;
    }

    /// <summary>
    /// Sinh User-Agent Android 14/15 Chrome 128 - 134.
    /// </summary>
    public static string GetRandomAndroid()
    {
        lock (_rand)
        {
            string device = AndroidDevices[_rand.Next(AndroidDevices.Length)];
            string ver = DesktopChromeVersions[_rand.Next(DesktopChromeVersions.Length)];
            return $"Mozilla/5.0 ({device}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{ver} Mobile Safari/537.36";
        }
    }

    /// <summary>
    /// Trích xuất phiên bản Chrome Major từ chuỗi User-Agent.
    /// Mặc định trả về "131" nếu không nhận diện được.
    /// </summary>
    public static string GetChromeMajorVersion(string userAgent)
    {
        if (string.IsNullOrEmpty(userAgent))
        {
            return "131";
        }
        Match m = Regex.Match(userAgent, @"(?:Chrome|CriOS)/(\d+)");
        if (m.Success)
        {
            return m.Groups[1].Value;
        }
        return "131";
    }

    /// <summary>
    /// Tạo bộ header Client Hints (sec-ch-ua, sec-ch-ua-mobile, sec-ch-ua-platform)
    /// tương thích hoàn hảo với User-Agent truyền vào.
    /// </summary>
    public static Dictionary<string, string> GetClientHintsHeaders(string userAgent)
    {
        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        string major = GetChromeMajorVersion(userAgent);
        bool isMobile = false;
        string platform = "\"Windows\"";

        if (!string.IsNullOrEmpty(userAgent))
        {
            if (userAgent.IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0 ||
                userAgent.IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                isMobile = true;
                platform = "\"iOS\"";
            }
            else if (userAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                isMobile = true;
                platform = "\"Android\"";
            }
            else if (userAgent.IndexOf("Macintosh", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     userAgent.IndexOf("Mac OS X", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                platform = "\"macOS\"";
            }
            else if (userAgent.IndexOf("Linux", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                platform = "\"Linux\"";
            }
        }

        // Định dạng Sec-CH-UA chuẩn Chrome brand GREASE
        // Ví dụ: "Google Chrome";v="131", "Chromium";v="131", "Not_A Brand";v="24"
        headers["sec-ch-ua"] = $"\"Google Chrome\";v=\"{major}\", \"Chromium\";v=\"{major}\", \"Not_A Brand\";v=\"24\"";
        headers["sec-ch-ua-mobile"] = isMobile ? "?1" : "?0";
        headers["sec-ch-ua-platform"] = platform;

        return headers;
    }
}
