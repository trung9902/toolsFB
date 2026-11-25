using System;
using System.Net;
using System.Text;
using Leaf.xNet;


namespace HttpRequest
{
    public class RequestHTTP
    {
        private Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest();

        public void SetSSL(SecurityProtocolType type)
        {
            ServicePointManager.SecurityProtocol = type;
        }

        public void SetKeepAlive(bool k)
        {
            req.KeepAlive = k;
        }

        public void SetDefaultHeaders(string[] headers)
        {
            if (headers == null) return;
            foreach (var h in headers)
            {
                var idx = h.IndexOf(':');
                if (idx > 0)
                {
                    req.AddHeader(h.Substring(0, idx).Trim(), h.Substring(idx + 1).Trim());
                }
            }
        }

        public string GetCookiesString()
        {
            return req.Cookies != null ? req.Cookies.ToString() : "";
        }

        public string Request(string method, string url, byte[] b = null, byte[] data = null, bool autoredrirect = true, WebProxy proxy = null)
        {
            try
            {
                req.AllowAutoRedirect = autoredrirect;
                if (proxy != null && proxy.Address != null)
                {
                    req.Proxy = HttpProxyClient.Parse(proxy.Address.Host + ":" + proxy.Address.Port);
                }
                if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    string postStr = data != null ? Encoding.UTF8.GetString(data) : "";
                    return req.Post(url, postStr, "application/x-www-form-urlencoded").ToString();
                }
                return req.Get(url).ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}

namespace WindowsFormsControlLibrary1
{
    public class BunifuCustomTextbox : System.Windows.Forms.TextBox
    {
        public System.Drawing.Color BorderColor { get; set; }
        public void AF8ADE0B() { }
    }
}

namespace MaxCareLibPro
{
    public class RequestXNet
    {
        private Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest();
        public string RequestGet(string url)
        {
            try { return req.Get(url).ToString(); } catch { return ""; }
        }
    }

    public static class Hotmail9
    {
        public static string CreateHotmail9(string a, string b) => "true";
        public static string GetTokenHotmail9(string a, string b) => "";
        public static bool CheckHotmail9(string mail) => true;
        public static string GetOtpMailhotmail9(object type, string mail, string passmail, string uid)
        {
            try
            {
                if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(passmail)) return "";
                return CheckpointClassifier.ExtractFacebookOtpFromImap("", 993, mail, passmail, 60);
            }
            catch { return ""; }
        }
    }

    public static class Common
    {
        public static bool Check1secMail(string mail) => false;
        public static string GetOtp1secMail(object type, string mail, string uid) => "";
        public static string getOtpHotmail(object type, string mail, string refresh_token, string uid) => "";
        public static string getAccessTokenHotmail(string a, string b, int c) => "";
        public static string GetOtpHotmailByCookie(object type, string cookie, string uidFb, string a, int b) => "";
        public static string GenerateRecoverybyhongbeoiii(string mail, bool ckb, int type, string txt, string duoi) => "";
    }
}

namespace WhiteNewLib
{
    public static class Common
    {
        /// <summary>
        /// Gọi AI đa nhà cung cấp: Gemini / ChatGPT (OpenAI) / DeepSeek
        /// Hỗ trợ Auto-Detect: nếu type chọn Gemini nhưng apiKey là sk- → tự chuyển OpenAI/DeepSeek
        /// </summary>
        public static string AIRequest(string type, string apiKey, string prompt, string a, string b)
        {
            try
            {
                if (string.IsNullOrEmpty(apiKey)) return "";
                string text = prompt ?? "";
                if (!string.IsNullOrEmpty(a) && text.Contains("{content}"))
                {
                    text = text.Replace("{content}", a);
                }
                string image = "";
                if (text.Contains("{image}"))
                {
                    text = text.Replace("{image}", "");
                    if (!string.IsNullOrEmpty(b) && System.IO.File.Exists(b))
                    {
                        image = b;
                    }
                }
                else if (!string.IsNullOrEmpty(b))
                {
                    image = b;
                }

                string typeLower = (type ?? "").ToLower().Trim();
                string keyTrimmed = apiKey.Trim();

                // --- Auto-Detect thông minh: phát hiện key không khớp provider ---
                // Key bắt đầu bằng "sk-" thường là OpenAI hoặc DeepSeek
                // Key bắt đầu bằng "AI" hoặc không có prefix "sk-" thường là Gemini
                bool isSkKey = keyTrimmed.StartsWith("sk-");
                bool isGeminiKey = !isSkKey; // Gemini key thường bắt đầu bằng AIza...

                // Xác định provider đích
                if (typeLower.Contains("deepseek") || typeLower == "2")
                {
                    return global::Commom.CallDeepSeekApi(keyTrimmed, text);
                }
                else if (typeLower.Contains("chatgpt") || typeLower.Contains("openai") || typeLower == "1")
                {
                    // Nếu user chọn ChatGPT nhưng key không phải sk- → thử Gemini
                    if (isGeminiKey)
                    {
                        return global::Commom.CallGeminiApi(keyTrimmed, text, image);
                    }
                    return global::Commom.CallOpenAiApi(keyTrimmed, text);
                }
                else // Gemini (type == "0", "Gemini", hoặc mặc định)
                {
                    // Nếu user chọn Gemini nhưng key là sk- → tự chuyển sang OpenAI
                    if (isSkKey)
                    {
                        return global::Commom.CallOpenAiApi(keyTrimmed, text);
                    }
                    return global::Commom.CallGeminiApi(keyTrimmed, text, image);
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
