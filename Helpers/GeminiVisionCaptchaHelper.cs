using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;

/// <summary>
/// Trợ lý giải mã Captcha ảnh Facebook siêu tốc và miễn phí sử dụng mô hình Google Gemini Vision AI.
/// Tự động trích xuất Base64 qua HTML5 Canvas, cookie session hoặc DOM screenshot.
/// </summary>
public static class GeminiVisionCaptchaHelper
{
    /// <summary>
    /// Google Gemini API Key mặc định hệ thống.
    /// </summary>
    public const string DefaultGeminiApiKey = "";

    public static event Action<string> OnStatusUpdate;

    /// <summary>
    /// Tự động tìm kiếm Google Gemini API Key từ các cấu hình hệ thống:
    /// 1. configCheckpoint (txtCaptcha_9)
    /// 2. configAI (txtApiKey, apiKey, txtGeminiApiKey)
    /// 3. configGeneral (txtGeminiApiKey)
    /// 4. Danh sách prompt trong GClass9 (prompt.json)
    /// </summary>
    /// <returns>API Key hợp lệ hoặc rỗng nếu chưa cấu hình</returns>
    public static string GetGeminiApiKey()
    {
        try
        {
            // 1. Kiểm tra cấu hình configCheckpoint (txtCaptcha_9)
            string key = C5034B95.smethod_0("configCheckpoint")?.BDB80B23("txtCaptcha_9")?.Trim();
            if (!string.IsNullOrEmpty(key) && !key.StartsWith("sk-", StringComparison.OrdinalIgnoreCase))
            {
                return key;
            }

            // 2. Kiểm tra cấu hình configAI
            var configAi = C5034B95.smethod_0("configAI");
            if (configAi != null)
            {
                key = configAi.BDB80B23("txtApiKey")?.Trim();
                if (!string.IsNullOrEmpty(key) && !key.StartsWith("sk-", StringComparison.OrdinalIgnoreCase)) return key;

                key = configAi.BDB80B23("apiKey")?.Trim();
                if (!string.IsNullOrEmpty(key) && !key.StartsWith("sk-", StringComparison.OrdinalIgnoreCase)) return key;

                key = configAi.BDB80B23("txtGeminiApiKey")?.Trim();
                if (!string.IsNullOrEmpty(key) && !key.StartsWith("sk-", StringComparison.OrdinalIgnoreCase)) return key;
            }

            // 3. Kiểm tra cấu hình configGeneral
            var configGen = C5034B95.smethod_0("configGeneral");
            if (configGen != null)
            {
                key = configGen.BDB80B23("txtGeminiApiKey")?.Trim();
                if (!string.IsNullOrEmpty(key) && !key.StartsWith("sk-", StringComparison.OrdinalIgnoreCase)) return key;
            }

            // 4. Kiểm tra danh sách prompt trong GClass9 (prompt.json)
            try
            {
                var promptList = GClass9.EC28DF14();
                if (promptList != null && promptList.Count > 0)
                {
                    // Lượt 1: Tìm item có type rõ ràng là Gemini hoặc key có tiền tố AIza
                    foreach (var item in promptList)
                    {
                        string itemKey = item?.String_2?.Trim();
                        if (string.IsNullOrEmpty(itemKey)) continue;

                        string itemType = item.E2AD160C ?? "";
                        if (itemType.Equals("Gemini", StringComparison.OrdinalIgnoreCase) || 
                            itemKey.StartsWith("AIza", StringComparison.OrdinalIgnoreCase))
                        {
                            return itemKey;
                        }
                    }

                    // Lượt 2: Tìm bất kỳ key nào không phải sk- (DeepSeek/ChatGPT)
                    foreach (var item in promptList)
                    {
                        string itemKey = item?.String_2?.Trim();
                        if (!string.IsNullOrEmpty(itemKey) && !itemKey.StartsWith("sk-", StringComparison.OrdinalIgnoreCase))
                        {
                            return itemKey;
                        }
                    }
                }
            }
            catch { }

            // 5. Fallback nếu txtCaptcha_9 có giá trị bất kỳ
            string fallbackKey = C5034B95.smethod_0("configCheckpoint")?.BDB80B23("txtCaptcha_9")?.Trim();
            if (!string.IsNullOrEmpty(fallbackKey)) return fallbackKey;
        }
        catch { }

        // 6. Master Default Fallback: Sử dụng key mặc định của hệ thống
        return DefaultGeminiApiKey;
    }

    /// <summary>
    /// Giải mã Captcha hình ảnh thông qua Google Gemini Vision AI.
    /// </summary>
    /// <param name="imagePathOrBase64">Đường dẫn file ảnh hoặc chuỗi Base64 (hoặc data URI data:image/...)</param>
    /// <param name="apiKey">API key tuỳ chọn; nếu để trống sẽ tự động lấy qua GetGeminiApiKey()</param>
    /// <returns>Chuỗi ký tự captcha đã làm sạch hoặc rỗng nếu thất bại</returns>
    public static string SolveImageCaptcha(string imagePathOrBase64, string apiKey = "")
    {
        try
        {
            if (string.IsNullOrWhiteSpace(imagePathOrBase64))
                return "";

            string key = string.IsNullOrWhiteSpace(apiKey) ? GetGeminiApiKey() : apiKey.Trim();
            if (string.IsNullOrWhiteSpace(key))
            {
                return "";
            }

            // Chuẩn hóa Base64 nếu có data URI prefix
            string normalizedImage = imagePathOrBase64.Trim();
            if (normalizedImage.StartsWith("data:image", StringComparison.OrdinalIgnoreCase))
            {
                int commaIdx = normalizedImage.IndexOf(',');
                if (commaIdx >= 0)
                {
                    normalizedImage = normalizedImage.Substring(commaIdx + 1);
                }
            }

            string prompt = "Đọc chính xác toàn bộ các ký tự chữ cái và chữ số trong ảnh captcha này. Trả về DUY NHẤT các ký tự của captcha, viết liền, không khoảng trắng, không kèm bất kỳ giải thích, dấu câu hay ngoặc kép nào.";

            string rawResult = Commom.CallGeminiApi(key, prompt, normalizedImage);
            if (string.IsNullOrWhiteSpace(rawResult) || rawResult.StartsWith("Error:", StringComparison.OrdinalIgnoreCase))
            {
                return "";
            }

            string clean = CleanCaptchaText(rawResult);
            return clean;
        }
        catch (Exception)
        {
            return "";
        }
    }

    /// <summary>
    /// Tự động tìm kiếm ảnh Captcha trên trang web hiện tại của Chrome, trích xuất hình ảnh,
    /// giải mã bằng Gemini Vision AI và điền tự động vào trường input captcha tương ứng.
    /// </summary>
    /// <param name="chrome">Đối tượng Chrome đang điều khiển</param>
    /// <param name="apiKey">Google Gemini API key tuỳ chọn</param>
    /// <param name="log">Action ghi log thông báo tiến trình</param>
    /// <returns>Chuỗi ký tự captcha đã giải được và điền, hoặc rỗng nếu không tìm thấy/thất bại</returns>
    public static string SolveCaptchaOnPage(Chrome chrome, string apiKey = "", Action<string> log = null)
    {
        if (chrome == null) return "";
        var driver = chrome.ChromeDriver_0;
        if (driver == null) return "";

        try
        {
            log?.Invoke("Đang quét tìm Captcha hình ảnh trên trang...");

            // 1. Quét tìm và trích xuất Base64 của ảnh Captcha từ trang bằng Javascript Canvas
            string extractScript = @"
                return (() => {
                    var selectors = [
                        'img[src*=""facebook.com/captcha/tfbimage""]',
                        'img[src*=""captcha/tfbimage""]',
                        'img[src*=""tfbimage""]',
                        'img.captcha',
                        'img[alt*=""captcha""]',
                        'img[src*=""captcha""]',
                        'canvas.captcha',
                        'canvas'
                    ];

                    var el = null;
                    for (var s of selectors) {
                        el = document.querySelector(s);
                        if (el) break;
                    }

                    if (!el) return JSON.stringify({ found: false });

                    var src = el.getAttribute('src') || el.src || '';

                    // Thử trích xuất Base64 trực tiếp
                    try {
                        if (el.tagName.toLowerCase() === 'canvas') {
                            var b64 = el.toDataURL('image/png');
                            return JSON.stringify({ found: true, base64: b64, src: src });
                        }

                        if (src.startsWith('data:image')) {
                            return JSON.stringify({ found: true, base64: src, src: src });
                        }

                        var canvas = document.createElement('canvas');
                        canvas.width = el.naturalWidth || el.width || 200;
                        canvas.height = el.naturalHeight || el.height || 60;
                        var ctx = canvas.getContext('2d');
                        ctx.drawImage(el, 0, 0);
                        var dataUrl = canvas.toDataURL('image/png');
                        if (dataUrl && dataUrl.length > 100 && !dataUrl.includes('data:,')) {
                            return JSON.stringify({ found: true, base64: dataUrl, src: src });
                        }
                    } catch (e) { }

                    return JSON.stringify({ found: true, base64: '', src: src });
                })();
            ";

            object resObj = driver.ExecuteScript(extractScript);
            string base64Image = "";
            string imageSrc = "";
            bool foundElement = false;

            if (resObj != null)
            {
                string jsonStr = resObj.ToString();
                try
                {
                    var parsed = Newtonsoft.Json.Linq.JObject.Parse(jsonStr);
                    foundElement = parsed.Value<bool>("found");
                    base64Image = parsed.Value<string>("base64") ?? "";
                    imageSrc = parsed.Value<string>("src") ?? "";
                }
                catch { }
            }

            // Nếu không tìm thấy element captcha nào
            if (!foundElement && string.IsNullOrEmpty(imageSrc))
            {
                // Thử regex từ PageSource
                string pageSource = chrome.AFACE5B4() ?? "";
                var match = Regex.Match(pageSource, "src=\"(https://(?:[a-z]+)\\.facebook\\.com/captcha/tfbimage.*?)\"");
                if (match.Success)
                {
                    imageSrc = match.Groups[1].Value.Replace("&amp;", "&");
                    foundElement = true;
                }
            }

            if (!foundElement && string.IsNullOrEmpty(imageSrc))
            {
                log?.Invoke("Không tìm thấy phần tử Captcha ảnh trên trang.");
                return "";
            }

            // Nếu JS canvas bị vướng CORS khiến base64Image rỗng -> Tải ảnh qua cookie phiên
            if (string.IsNullOrEmpty(base64Image) && !string.IsNullOrEmpty(imageSrc))
            {
                log?.Invoke("Đang tải ảnh Captcha qua Session Cookie...");
                string fullUrl = imageSrc;
                if (fullUrl.StartsWith("//")) fullUrl = "https:" + fullUrl;
                else if (fullUrl.StartsWith("/")) fullUrl = "https://www.facebook.com" + fullUrl;

                base64Image = Commom.A794F28D(chrome.method_40(), fullUrl);
            }

            // Fallback: Chụp ảnh trực tiếp từ element bounds nếu tải cookie vẫn rỗng
            if (string.IsNullOrEmpty(base64Image))
            {
                try
                {
                    log?.Invoke("Đang chụp ảnh phần tử Captcha trực tiếp từ DOM...");
                    var imgElement = chrome.A022661F("[src*=\"facebook.com/captcha/tfbimage\"], img[src*=\"captcha\"], img.captcha, canvas");
                    if (imgElement != null)
                    {
                        var takesScreenshot = driver as ITakesScreenshot;
                        if (takesScreenshot != null)
                        {
                            Screenshot ss = takesScreenshot.GetScreenshot();
                            using (var ms = new MemoryStream(ss.AsByteArray))
                            using (var fullBmp = new Bitmap(ms))
                            {
                                var loc = imgElement.Location;
                                var sz = imgElement.Size;
                                if (sz.Width > 0 && sz.Height > 0)
                                {
                                    Rectangle cropRect = new Rectangle(
                                        Math.Max(0, loc.X),
                                        Math.Max(0, loc.Y),
                                        Math.Min(sz.Width, fullBmp.Width - Math.Max(0, loc.X)),
                                        Math.Min(sz.Height, fullBmp.Height - Math.Max(0, loc.Y))
                                    );
                                    using (Bitmap cropped = fullBmp.Clone(cropRect, fullBmp.PixelFormat))
                                    using (var cropMs = new MemoryStream())
                                    {
                                        cropped.Save(cropMs, System.Drawing.Imaging.ImageFormat.Png);
                                        base64Image = Convert.ToBase64String(cropMs.ToArray());
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            if (string.IsNullOrEmpty(base64Image))
            {
                log?.Invoke("Không thể trích xuất dữ liệu ảnh Captcha!");
                return "";
            }

            log?.Invoke("Đang gửi ảnh sang Gemini Vision AI để giải mã...");
            string keyToUse = string.IsNullOrWhiteSpace(apiKey) ? GetGeminiApiKey() : apiKey.Trim();
            string captchaResult = SolveImageCaptcha(base64Image, keyToUse);

            if (string.IsNullOrEmpty(captchaResult))
            {
                log?.Invoke("Gemini Vision AI không thể nhận diện được Captcha.");
                return "";
            }

            log?.Invoke($"Gemini Vision AI giải thành công: [{captchaResult}]. Đang điền vào ô nhập...");

            // 2. Tìm trường input để điền kết quả
            string fillScript = @"
                return ((code) => {
                    var inputSelectors = [
                        'input[name=""captcha_response""]',
                        '#captcha_response',
                        'input[name*=""captcha""]',
                        'input[id*=""captcha""]',
                        'input[type=""text""]'
                    ];

                    var inp = null;
                    for (var s of inputSelectors) {
                        inp = document.querySelector(s);
                        if (inp && inp.offsetParent !== null) break;
                    }

                    if (!inp) {
                        inp = document.querySelector('input[type=""text""]');
                    }

                    if (inp) {
                        inp.focus();
                        inp.value = code;
                        inp.dispatchEvent(new Event('input', { bubbles: true }));
                        inp.dispatchEvent(new Event('change', { bubbles: true }));
                        return 'filled:' + (inp.name || inp.id || 'text');
                    }
                    return 'not_found';
                })('" + captchaResult.Replace("'", "\\'") + @"');
            ";

            object fillRes = driver.ExecuteScript(fillScript);

            // Cũng hỗ trợ điền qua method_22 chuẩn nếu selector được xác định
            string[] knownSelectors = new string[]
            {
                "input[name=\"captcha_response\"]",
                "#captcha_response",
                "input[name*=\"captcha\"]",
                "input[id*=\"captcha\"]",
                "input[type=\"text\"]"
            };

            foreach (var sel in knownSelectors)
            {
                if (chrome.D7A424AE(sel))
                {
                    chrome.method_22(sel, captchaResult);
                    break;
                }
            }

            log?.Invoke("Đã điền mã Captcha: " + captchaResult);
            OnStatusUpdate?.Invoke("Đã giải Captcha: " + captchaResult);

            return captchaResult;
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi SolveCaptchaOnPage: " + ex.Message);
            return "";
        }
    }

    /// <summary>
    /// Làm sạch chuỗi kết quả trả về từ Gemini, loại bỏ định dạng Markdown, nhãn thừa và dấu câu.
    /// </summary>
    public static string CleanCaptchaText(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return "";

        string cleaned = raw.Replace("```", "").Replace("`", "").Replace("\"", "").Replace("'", "").Trim();

        // Tách theo dòng để tìm dòng chứa chuỗi captcha chính xác
        string[] lines = cleaned.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            string trimmed = line.Trim();
            if (trimmed.StartsWith("Captcha:", StringComparison.OrdinalIgnoreCase))
                trimmed = trimmed.Substring(8).Trim();
            else if (trimmed.StartsWith("Mã captcha:", StringComparison.OrdinalIgnoreCase))
                trimmed = trimmed.Substring(11).Trim();
            else if (trimmed.StartsWith("Kết quả:", StringComparison.OrdinalIgnoreCase))
                trimmed = trimmed.Substring(8).Trim();
            else if (trimmed.StartsWith("Code:", StringComparison.OrdinalIgnoreCase))
                trimmed = trimmed.Substring(5).Trim();
            else if (trimmed.StartsWith("Answer:", StringComparison.OrdinalIgnoreCase))
                trimmed = trimmed.Substring(7).Trim();

            // Loại bỏ khoảng trắng và ký tự đặc biệt
            string candidate = Regex.Replace(trimmed, @"[^a-zA-Z0-9]", "");
            if (candidate.Length >= 2 && candidate.Length <= 12)
            {
                return candidate;
            }
        }

        return Regex.Replace(cleaned, @"[^a-zA-Z0-9]", "");
    }
}
