using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Module mô phỏng hành vi gõ phím chân thực như người thật (Human-like Typing).
/// Hỗ trợ gõ từng ký tự với delay ngẫu nhiên, mô phỏng gõ lỗi (typo) và xóa sửa,
/// tương thích hoàn toàn chuẩn Unicode UTF-8 và Emoji (surrogate pairs).
/// </summary>
public static class HumanTyping
{
    // Thread-safe Random độc lập cho từng worker thread
    private static readonly ThreadLocal<Random> _threadRandom = new ThreadLocal<Random>(() =>
        new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

    private static Random Rnd => _threadRandom.Value;

    // Bảng ánh xạ các phím liền kề trên bàn phím QWERTY phục vụ mô phỏng gõ nhầm (typo)
    private static readonly Dictionary<char, string> AdjacentKeysMap = new Dictionary<char, string>
    {
        // Dãy số
        { '1', "2q`" },
        { '2', "13qw" },
        { '3', "24we" },
        { '4', "35er" },
        { '5', "46rt" },
        { '6', "57ty" },
        { '7', "68yu" },
        { '8', "79ui" },
        { '9', "80io" },
        { '0', "9-op" },

        // Dãy chữ hàng trên
        { 'q', "12wa" },
        { 'w', "23qesa" },
        { 'e', "34wrsd" },
        { 'r', "45etdf" },
        { 't', "56ryfg" },
        { 'y', "67tugh" },
        { 'u', "78yijh" },
        { 'i', "89uokj" },
        { 'o', "90iplk" },
        { 'p', "0-ol" },

        // Dãy chữ hàng giữa
        { 'a', "qwsz" },
        { 's', "weadzx" },
        { 'd', "ersfxc" },
        { 'f', "rtdgcv" },
        { 'g', "tyfhvb" },
        { 'h', "yugjbn" },
        { 'j', "uihknm" },
        { 'k', "iojlm" },
        { 'l', "opk" },

        // Dãy chữ hàng dưới
        { 'z', "asx" },
        { 'x', "zsdc" },
        { 'c', "xdfv" },
        { 'v', "cfgb" },
        { 'b', "vghn" },
        { 'n', "bhjm" },
        { 'm', "njk" }
    };

    /// <summary>
    /// Gõ văn bản vào web element mô phỏng hành vi người thật:
    /// - Gõ từng ký tự với delay ngẫu nhiên dao động giữa minDelayMs và maxDelayMs.
    /// - Mô phỏng gõ nhầm (typo) 3-5%: bấm phím liền kề, ngập ngừng, bấm Backspace sửa lại.
    /// - Hỗ trợ đầy đủ Unicode, tiếng Việt có dấu, ký tự đặc biệt và Emoji (surrogate pairs).
    /// - Tích hợp kiểm tra cờ dừng Base.smethod_5() để hủy ngay lập tức khi user yêu cầu.
    /// </summary>
    /// <param name="driver">ChromeDriver đang điều khiển trình duyệt.</param>
    /// <param name="element">IWebElement mục tiêu (ô input, textarea, div contenteditable).</param>
    /// <param name="text">Nội dung chuỗi cần nhập.</param>
    /// <param name="minDelayMs">Độ trễ tối thiểu giữa các phím (mặc định 15ms).</param>
    /// <param name="maxDelayMs">Độ trễ tối đa giữa các phím (mặc định 45ms).</param>
    public static void TypeLikeHuman(ChromeDriver driver, IWebElement element, string text, int minDelayMs = 15, int maxDelayMs = 45)
    {
        TypeLikeHumanInternal(driver, element, text, minDelayMs, maxDelayMs, 0.04);
    }

    /// <summary>
    /// Overload hỗ trợ IWebDriver tổng quát.
    /// </summary>
    public static void TypeLikeHuman(IWebDriver driver, IWebElement element, string text, int minDelayMs = 15, int maxDelayMs = 45)
    {
        TypeLikeHumanInternal(driver, element, text, minDelayMs, maxDelayMs, 0.04);
    }

    /// <summary>
    /// Overload hỗ trợ Chrome wrapper của MaxCare.
    /// </summary>
    public static void TypeLikeHuman(Chrome chrome, IWebElement element, string text, int minDelayMs = 15, int maxDelayMs = 45)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null) return;
        TypeLikeHumanInternal(chrome.ChromeDriver_0, element, text, minDelayMs, maxDelayMs, 0.04);
    }

    /// <summary>
    /// Hàm thực thi gõ phím nội bộ.
    /// </summary>
    private static void TypeLikeHumanInternal(IWebDriver driver, IWebElement element, string text, int minDelayMs, int maxDelayMs, double typoProbability)
    {
        if (driver == null || element == null || string.IsNullOrEmpty(text))
        {
            return;
        }

        if (minDelayMs < 5) minDelayMs = 5;
        if (maxDelayMs < minDelayMs) maxDelayMs = minDelayMs;

        try
        {
            // Đảm bảo focus vào phần tử trước khi gõ
            try
            {
                element.Click();
            }
            catch
            {
                // Bỏ qua nếu element đã được focus hoặc click bị chặn nhẹ
            }

            // Sử dụng StringInfo để phân tách chính xác từng Grapheme Cluster / Surrogate Pair
            // (Đảm bảo các ký tự emoji 4-byte UTF-16 không bị tách rời thành 2 nửa lỗi)
            TextElementEnumerator textElements = StringInfo.GetTextElementEnumerator(text);

            bool lastWasTypo = false;

            while (textElements.MoveNext())
            {
                // Kiểm tra cờ dừng khẩn cấp từ người dùng
                if (Base.smethod_5())
                {
                    return;
                }

                string currentElement = textElements.GetTextElement();
                if (string.IsNullOrEmpty(currentElement))
                {
                    continue;
                }

                // Kiểm tra xem ký tự này có nên kích hoạt typo simulation (xác suất 3-5%) hay không
                // Điều kiện: ký tự đơn ASCII có phím liền kề, không phải khoảng trắng, newline hay emoji
                bool canTypo = !lastWasTypo
                               && currentElement.Length == 1
                               && IsTypoEligible(currentElement[0])
                               && (Rnd.NextDouble() < typoProbability);

                if (canTypo)
                {
                    char targetChar = currentElement[0];
                    char wrongChar = GetAdjacentKey(targetChar);

                    if (wrongChar != targetChar)
                    {
                        // 1. Gõ ký tự sai
                        SendSingleKeySafe(driver, element, wrongChar.ToString());
                        lastWasTypo = true;

                        // 2. Độ trễ nhận biết lỗi (người thật mất 120ms - 260ms để nhận ra mình gõ nhầm)
                        int noticeMistakeDelay = Rnd.Next(120, 260);
                        SleepWithCancelCheck(noticeMistakeDelay);
                        if (Base.smethod_5()) return;

                        // 3. Nhấn Backspace để xóa ký tự sai
                        try
                        {
                            element.SendKeys(Keys.Backspace);
                        }
                        catch
                        {
                            // Fallback nếu sendKeys thông thường gặp vấn đề
                            ExecuteBackspaceJs(driver, element);
                        }

                        // 4. Nghỉ ngắn trước khi gõ lại ký tự đúng (80ms - 180ms)
                        int correctionDelay = Rnd.Next(80, 180);
                        SleepWithCancelCheck(correctionDelay);
                        if (Base.smethod_5()) return;
                    }
                }
                else
                {
                    lastWasTypo = false;
                }

                // Gõ ký tự chính xác (hỗ trợ Unicode, tiếng Việt, Emoji)
                SendSingleKeySafe(driver, element, currentElement);

                // Tính toán độ trễ nhịp gõ phím tự nhiên
                int delay = Rnd.Next(minDelayMs, maxDelayMs + 1);

                // Thêm độ trễ tự nhiên theo thói quen con người:
                if (currentElement == " ")
                {
                    // Giữa các từ: tạm dừng nhẹ để ngẫm từ tiếp theo (+30ms đến +70ms)
                    delay += Rnd.Next(30, 70);
                }
                else if (currentElement == "." || currentElement == "!" || currentElement == "?")
                {
                    // Cuối câu: người thật thường dừng lại để ngắt ý (+150ms đến +300ms)
                    delay += Rnd.Next(150, 300);
                }
                else if (currentElement == "," || currentElement == ";" || currentElement == ":")
                {
                    // Dấu ngắt câu ngắn (+80ms đến +150ms)
                    delay += Rnd.Next(80, 150);
                }
                else if (currentElement == "\n" || currentElement == "\r")
                {
                    // Xuống dòng (+200ms đến +400ms)
                    delay += Rnd.Next(200, 400);
                }

                SleepWithCancelCheck(delay);
            }
        }
        catch (Exception ex)
        {
            // Ghi nhận lỗi nhưng không để crash thread tự động hóa
            try
            {
                if (driver is ChromeDriver)
                {
                    // Fallback gửi toàn bộ text nếu gõ từng phím gặp sự cố DOM đột xuất
                    element?.SendKeys(text);
                }
            }
            catch
            {
                // Bỏ qua lỗi DOM không khả dụng
            }
        }
    }

    /// <summary>
    /// Gửi an toàn 1 ký tự / emoji vào web element.
    /// Hỗ trợ fallback JavaScript khi gặp các Emoji ngoài vùng BMP (surrogate pairs).
    /// </summary>
    private static void SendSingleKeySafe(IWebDriver driver, IWebElement element, string keyStr)
    {
        try
        {
            element.SendKeys(keyStr);
        }
        catch (WebDriverException)
        {
            // Khi ChromeDriver gặp emoji 4-byte (BMP astral planes) có thể ném WebDriverException:
            // "ChromeDriver only supports characters in the BMP"
            // Ta chuyển hướng chèn qua JavaScript DOM / execCommand để giữ nguyên vẹn emoji
            ExecuteInsertTextJs(driver, element, keyStr);
        }
        catch (Exception)
        {
            ExecuteInsertTextJs(driver, element, keyStr);
        }
    }

    /// <summary>
    /// Chèn text/emoji trực tiếp vào phần tử qua JavaScript hỗ trợ cả input, textarea và contenteditable.
    /// </summary>
    private static void ExecuteInsertTextJs(IWebDriver driver, IWebElement element, string text)
    {
        if (driver is IJavaScriptExecutor js)
        {
            try
            {
                js.ExecuteScript(@"
                    var el = arguments[0];
                    var txt = arguments[1];
                    if (!el) return;
                    if (document.activeElement !== el) {
                        try { el.focus(); } catch (e) {}
                    }
                    if (document.queryCommandSupported && document.queryCommandSupported('insertText')) {
                        document.execCommand('insertText', false, txt);
                    } else if (typeof el.value !== 'undefined') {
                        var start = el.selectionStart || 0;
                        var end = el.selectionEnd || 0;
                        el.value = el.value.substring(0, start) + txt + el.value.substring(end);
                        el.selectionStart = el.selectionEnd = start + txt.length;
                        el.dispatchEvent(new Event('input', { bubbles: true }));
                        el.dispatchEvent(new Event('change', { bubbles: true }));
                    } else if (el.isContentEditable) {
                        document.execCommand('insertText', false, txt);
                    }
                ", element, text);
            }
            catch
            {
                // Ignored
            }
        }
    }

    /// <summary>
    /// Xóa 1 ký tự trước con trỏ qua JavaScript fallback.
    /// </summary>
    private static void ExecuteBackspaceJs(IWebDriver driver, IWebElement element)
    {
        if (driver is IJavaScriptExecutor js)
        {
            try
            {
                js.ExecuteScript(@"
                    var el = arguments[0];
                    if (!el) return;
                    if (document.queryCommandSupported && document.queryCommandSupported('delete')) {
                        document.execCommand('delete', false, null);
                    } else if (typeof el.value !== 'undefined' && el.value.length > 0) {
                        var start = el.selectionStart || el.value.length;
                        if (start > 0) {
                            el.value = el.value.substring(0, start - 1) + el.value.substring(start);
                            el.selectionStart = el.selectionEnd = start - 1;
                            el.dispatchEvent(new Event('input', { bubbles: true }));
                        }
                    }
                ", element);
            }
            catch
            {
                // Ignored
            }
        }
    }

    /// <summary>
    /// Kiểm tra ký tự có phù hợp để tạo lỗi phím hay không.
    /// </summary>
    private static bool IsTypoEligible(char c)
    {
        char lower = char.ToLowerInvariant(c);
        return AdjacentKeysMap.ContainsKey(lower);
    }

    /// <summary>
    /// Lấy một phím liền kề ngẫu nhiên trên bàn phím QWERTY dựa trên ký tự mục tiêu.
    /// </summary>
    private static char GetAdjacentKey(char originalChar)
    {
        char lower = char.ToLowerInvariant(originalChar);
        if (!AdjacentKeysMap.TryGetValue(lower, out string adjacents) || string.IsNullOrEmpty(adjacents))
        {
            return originalChar;
        }

        char chosen = adjacents[Rnd.Next(0, adjacents.Length)];
        if (char.IsUpper(originalChar))
        {
            return char.ToUpperInvariant(chosen);
        }
        return chosen;
    }

    /// <summary>
    /// Ngủ với bước nhỏ 20ms và kiểm tra cờ dừng Base.smethod_5() liên tục.
    /// </summary>
    private static void SleepWithCancelCheck(int totalMs)
    {
        int remaining = totalMs;
        while (remaining > 0)
        {
            if (Base.smethod_5()) return;
            int slice = Math.Min(20, remaining);
            Thread.Sleep(slice);
            remaining -= slice;
        }
    }
}
