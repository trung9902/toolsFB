using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Helper thông minh ứng dụng Gemini AI để phân tích và trả lời câu hỏi xét duyệt gia nhập nhóm Facebook.
/// Tự động bóc tách câu hỏi từ dialog, sinh câu trả lời ngắn gọn, tự nhiên, thiện chí và tích đồng ý quy tắc nhóm.
/// </summary>
public static class SmartGroupJoinAIHelper
{
    private static readonly Random _random = new Random();

    /// <summary>
    /// Model lưu thông tin câu hỏi và phần tử nhập liệu tương ứng trong dialog Facebook.
    /// </summary>
    public class QuestionItem
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; } = "";

        [JsonProperty("tag")]
        public string TagName { get; set; } = "textarea";

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; } = "";

        [JsonProperty("ariaLabel")]
        public string AriaLabel { get; set; } = "";
    }

    /// <summary>
    /// Lấy Gemini API Key từ cấu hình hệ thống: GClass9 (prompt.json), configAI, configGeneral, hoặc biến môi trường.
    /// </summary>
    public static string GetApiKey()
    {
        try
        {
            // 1. Kiểm tra danh sách prompt trong GClass9 (prompt.json)
            List<GClass10> list = GClass9.EC28DF14();
            if (list != null && list.Count > 0)
            {
                // Ưu tiên các cấu hình có type là Gemini hoặc key có định dạng Google AI (AIzaSy...)
                foreach (var item in list)
                {
                    if (item != null && !string.IsNullOrWhiteSpace(item.String_2))
                    {
                        string type = (item.E2AD160C ?? "").ToLower().Trim();
                        string key = item.String_2.Trim();
                        if (type.Contains("gemini") || type == "0" || key.StartsWith("AIzaSy"))
                        {
                            return key;
                        }
                    }
                }

                // Fallback: lấy bất kỳ API key nào khả dụng trong danh sách prompt
                foreach (var item in list)
                {
                    if (item != null && !string.IsNullOrWhiteSpace(item.String_2))
                    {
                        string key = item.String_2.Trim();
                        if (!string.IsNullOrEmpty(key))
                        {
                            return key;
                        }
                    }
                }
            }

            // 2. Kiểm tra file cấu hình configAI (nếu có)
            try
            {
                var configAI = C5034B95.smethod_0("configAI");
                if (configAI != null)
                {
                    string key = configAI.BDB80B23("txtApiKey").Trim();
                    if (string.IsNullOrEmpty(key)) key = configAI.BDB80B23("apiKey").Trim();
                    if (string.IsNullOrEmpty(key)) key = configAI.BDB80B23("geminiKey").Trim();
                    if (string.IsNullOrEmpty(key)) key = configAI.BDB80B23("txtGeminiApiKey").Trim();
                    if (!string.IsNullOrEmpty(key)) return key;
                }
            }
            catch { }

            // 3. Kiểm tra file cấu hình configGeneral
            try
            {
                var configGen = C5034B95.smethod_0("configGeneral");
                if (configGen != null)
                {
                    string key = configGen.BDB80B23("txtApiKey").Trim();
                    if (string.IsNullOrEmpty(key)) key = configGen.BDB80B23("apiKey").Trim();
                    if (string.IsNullOrEmpty(key)) key = configGen.BDB80B23("txtGeminiApiKey").Trim();
                    if (string.IsNullOrEmpty(key)) key = configGen.BDB80B23("geminiApiKey").Trim();
                    if (!string.IsNullOrEmpty(key)) return key;
                }
            }
            catch { }

            // 4. Kiểm tra biến môi trường hệ thống
            string envKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            if (!string.IsNullOrWhiteSpace(envKey)) return envKey.Trim();

            envKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
            if (!string.IsNullOrWhiteSpace(envKey)) return envKey.Trim();
        }
        catch
        {
        }

        return "";
    }

    /// <summary>
    /// Sinh câu trả lời thông minh theo ngữ cảnh câu hỏi của Admin nhóm Facebook bằng Gemini AI.
    /// Nếu không có API Key hoặc gặp sự cố mạng, tự động trả về fallbackAnswer hoặc câu trả lời mặc định tự nhiên.
    /// </summary>
    /// <param name="groupName">Tên nhóm Facebook đang xin gia nhập</param>
    /// <param name="question">Nội dung câu hỏi xét duyệt của Admin</param>
    /// <param name="fallbackAnswer">Câu trả lời dự phòng khi AI không khả dụng</param>
    /// <returns>Câu trả lời ngắn gọn, lịch sự, thiện chí</returns>
    public static string GenerateAnswerForQuestion(string groupName, string question, string fallbackAnswer = "")
    {
        string defaultFallback = "Em xin vào nhóm để học hỏi và giao lưu kinh nghiệm ạ";
        string effectiveFallback = !string.IsNullOrWhiteSpace(fallbackAnswer)
            ? fallbackAnswer.Trim()
            : defaultFallback;

        // Nếu câu hỏi rỗng hoặc không có nội dung rõ ràng, dùng fallback
        if (string.IsNullOrWhiteSpace(question))
        {
            return effectiveFallback;
        }

        try
        {
            string apiKey = GetApiKey();
            if (string.IsNullOrEmpty(apiKey))
            {
                return effectiveFallback;
            }

            string safeGroupName = string.IsNullOrWhiteSpace(groupName) ? "này" : groupName.Trim();
            string safeQuestion = question.Trim();

            string prompt = $"Bạn đang trả lời câu hỏi xét duyệt thành viên để xin vào nhóm Facebook '{safeGroupName}'. " +
                            $"Câu hỏi là: '{safeQuestion}'. " +
                            $"Hãy viết câu trả lời ngắn gọn (1 câu, dưới 15 từ), lịch sự, tự nhiên, thiện chí, phù hợp đúng trọng tâm câu hỏi để Admin dễ duyệt nhất. " +
                            $"Chỉ trả về nội dung câu trả lời, không giải thích.";

            string response = Commom.CallGeminiApi(apiKey, prompt);

            if (!string.IsNullOrWhiteSpace(response) && !response.StartsWith("Error:", StringComparison.OrdinalIgnoreCase))
            {
                string cleaned = CleanAiAnswer(response);
                if (!string.IsNullOrWhiteSpace(cleaned))
                {
                    return cleaned;
                }
            }
        }
        catch
        {
            // Lỗi mạng hoặc exception -> fallback tự nhiên
        }

        return effectiveFallback;
    }

    /// <summary>
    /// Làm sạch câu trả lời từ AI (loại bỏ dấu ngoặc kép bọc ngoài, prefix Trả lời, ngắt dòng thừa).
    /// </summary>
    private static string CleanAiAnswer(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return "";
        string cleaned = text.Trim();

        // Xóa các tiền tố thường gặp của AI như "Trả lời: ", "Câu trả lời: ", "Đáp: "
        string[] prefixes = new string[]
        {
            "câu trả lời:", "trả lời:", "đáp:", "answer:", "phản hồi:", "câu trả lời của tôi:"
        };

        foreach (var p in prefixes)
        {
            if (cleaned.ToLower().StartsWith(p))
            {
                cleaned = cleaned.Substring(p.Length).Trim();
            }
        }

        // Bỏ dấu ngoặc kép hoặc ngoặc đơn bao quanh
        if ((cleaned.StartsWith("\"") && cleaned.EndsWith("\"")) ||
            (cleaned.StartsWith("'") && cleaned.EndsWith("'")) ||
            (cleaned.StartsWith("“") && cleaned.EndsWith("”")) ||
            (cleaned.StartsWith("‘") && cleaned.EndsWith("’")))
        {
            if (cleaned.Length >= 2)
            {
                cleaned = cleaned.Substring(1, cleaned.Length - 2).Trim();
            }
        }

        // Chuẩn hóa khoảng trắng và ngắt dòng thành 1 dòng duy nhất
        cleaned = cleaned.Replace("\r", " ").Replace("\n", " ");
        while (cleaned.Contains("  "))
        {
            cleaned = cleaned.Replace("  ", " ");
        }

        return cleaned.Trim();
    }

    /// <summary>
    /// Sử dụng JavaScript quét hộp thoại xét duyệt [role="dialog"] trên Facebook,
    /// bóc tách từng cặp (câu hỏi, phần tử input/textarea tương ứng) dựa trên label, aria-label, hoặc text phía trên.
    /// </summary>
    public static List<QuestionItem> ExtractQuestionsAndInputs(Chrome chrome)
    {
        if (chrome == null) return new List<QuestionItem>();

        try
        {
            string jsScript = @"return (() => {
                try {
                    var dialogs = document.querySelectorAll('[role=""dialog""]');
                    if (!dialogs || dialogs.length === 0) return JSON.stringify([]);
                    var dlg = dialogs[dialogs.length - 1];

                    var results = [];
                    var inputs = dlg.querySelectorAll('textarea, input[type=""text""], input:not([type]), [role=""textbox""][contenteditable=""true""]');

                    function cleanQ(raw) {
                        if (!raw) return '';
                        var lines = raw.split('\n').map(function(l) { return l.trim(); }).filter(function(l) {
                            if (!l) return false;
                            var low = l.toLowerCase();
                            if (low === 'bắt buộc' || low === 'required' || low === 'tùy chọn' || low === 'optional') return false;
                            if (/^(câu hỏi|question)\s*\d+(\s*(\/|of)\s*\d+)?$/i.test(low)) return false;
                            if (low.startsWith('viết câu trả lời') || low.startsWith('write an answer')) return false;
                            if (low.startsWith('nhập câu trả lời') || low.startsWith('enter an answer')) return false;
                            if (low === 'câu trả lời của bạn' || low === 'your answer') return false;
                            return true;
                        });
                        return lines.join(' ');
                    }

                    for (var i = 0; i < inputs.length; i++) {
                        var inp = inputs[i];
                        if (inp.type === 'hidden' || inp.style.display === 'none') continue;
                        var r = inp.getBoundingClientRect();
                        if (r.width === 0 && r.height === 0 && inp.offsetParent === null) continue;

                        var qText = '';

                        // 1. label[for]
                        if (inp.id) {
                            var lbl = dlg.querySelector('label[for=""' + inp.id + '""]');
                            if (lbl) {
                                var t = cleanQ(lbl.innerText || '');
                                if (t.length > 3) qText = t;
                            }
                        }

                        // 2. aria-labelledby
                        if (!qText) {
                            var lblId = inp.getAttribute('aria-labelledby');
                            if (lblId) {
                                var el = document.getElementById(lblId);
                                if (el) {
                                    var t2 = cleanQ(el.innerText || '');
                                    if (t2.length > 3) qText = t2;
                                }
                            }
                        }

                        // 3. Tìm thẻ cha chứa câu hỏi và các sibling đứng trước input
                        if (!qText) {
                            var curr = inp;
                            for (var depth = 0; depth < 6; depth++) {
                                if (!curr || curr === dlg) break;
                                var parent = curr.parentElement;
                                if (!parent) break;

                                var children = Array.from(parent.children);
                                var currIdx = children.indexOf(curr);

                                for (var s = currIdx - 1; s >= 0; s--) {
                                    var sib = children[s];
                                    var rawText = (sib.innerText || '').trim();
                                    var cleaned = cleanQ(rawText);
                                    if (cleaned.length > 5) {
                                        qText = cleaned;
                                        break;
                                    }
                                }
                                if (qText) break;
                                curr = parent;
                            }
                        }

                        // 4. Fallback aria-label
                        var aria = (inp.getAttribute('aria-label') || '').trim();
                        if (!qText && aria.length > 5) {
                            var cleanAria = cleanQ(aria);
                            if (cleanAria.length > 5) qText = cleanAria;
                        }

                        // 5. Fallback placeholder
                        var ph = (inp.getAttribute('placeholder') || '').trim();
                        if (!qText && ph.length > 5) {
                            var cleanPh = cleanQ(ph);
                            if (cleanPh.length > 5) qText = cleanPh;
                        }

                        results.push({
                            index: i,
                            question: qText || '',
                            tag: inp.tagName.toLowerCase(),
                            placeholder: ph,
                            ariaLabel: aria
                        });
                    }

                    return JSON.stringify(results);
                } catch (e) {
                    return JSON.stringify([]);
                }
            })()";

            string json = chrome.method_14(jsScript);
            if (!string.IsNullOrWhiteSpace(json))
            {
                var list = JsonConvert.DeserializeObject<List<QuestionItem>>(json);
                if (list != null)
                {
                    return list;
                }
            }
        }
        catch
        {
        }

        return new List<QuestionItem>();
    }

    /// <summary>
    /// Điền câu trả lời vào input/textarea thứ `inputIndex` trong dialog với tương thích chuẩn React/Comet.
    /// </summary>
    public static bool FillAnswer(Chrome chrome, int inputIndex, string answer)
    {
        if (chrome == null) return false;

        try
        {
            string safeAnswer = (answer ?? "").Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ");
            string jsFill = $@"return (() => {{
                try {{
                    var dlg = document.querySelector('[role=""dialog""]');
                    if (!dlg) return false;
                    var inputs = dlg.querySelectorAll('textarea, input[type=""text""], input:not([type]), [role=""textbox""][contenteditable=""true""]');
                    if (inputs.length <= {inputIndex}) return false;

                    var el = inputs[{inputIndex}];
                    el.focus();

                    if (el.tagName.toLowerCase() === 'textarea' || el.tagName.toLowerCase() === 'input') {{
                        var valSetter = Object.getOwnPropertyDescriptor(el, 'value') ? Object.getOwnPropertyDescriptor(el, 'value').set : null;
                        var proto = Object.getPrototypeOf(el);
                        var protoSetter = Object.getOwnPropertyDescriptor(proto, 'value') ? Object.getOwnPropertyDescriptor(proto, 'value').set : null;
                        if (protoSetter && valSetter !== protoSetter) {{
                            protoSetter.call(el, '{safeAnswer}');
                        }} else if (valSetter) {{
                            valSetter.call(el, '{safeAnswer}');
                        }} else {{
                            el.value = '{safeAnswer}';
                        }}
                    }} else {{
                        el.innerText = '{safeAnswer}';
                    }}

                    el.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    el.dispatchEvent(new Event('change', {{ bubbles: true }}));
                    return true;
                }} catch (e) {{
                    return false;
                }}
            }})()";

            string res = chrome.method_14(jsFill);
            return Convert.ToBoolean(res);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Tự động tích chọn checkbox đồng ý nội quy nhóm và chọn radio button mặc định trong dialog.
    /// </summary>
    public static void AgreeRulesAndRadios(Chrome chrome)
    {
        if (chrome == null) return;

        try
        {
            string jsScript = @"(() => {
                try {
                    var dlg = document.querySelector('[role=""dialog""]');
                    if (!dlg) return;

                    // 1. Tự động tích checkbox đồng ý nội quy nhóm
                    var checkboxes = dlg.querySelectorAll('input[type=""checkbox""], [role=""checkbox""]');
                    for (var i = 0; i < checkboxes.length; i++) {
                        var cb = checkboxes[i];
                        var isChecked = cb.checked || cb.getAttribute('aria-checked') === 'true';
                        if (isChecked) continue;

                        var container = cb.closest('div, label') || cb.parentElement;
                        var txt = (container ? container.innerText : '').toLowerCase();

                        if (txt.indexOf('quy tắc') !== -1 ||
                            txt.indexOf('rules') !== -1 ||
                            txt.indexOf('đồng ý') !== -1 ||
                            txt.indexOf('agree') !== -1 ||
                            txt.indexOf('tôi đồng ý') !== -1 ||
                            txt.indexOf('nội quy') !== -1 ||
                            txt.indexOf('chấp nhận') !== -1 ||
                            checkboxes.length <= 2) {
                            cb.click();
                            if (!cb.checked && cb.getAttribute('aria-checked') !== 'true' && container) {
                                container.click();
                            }
                        }
                    }

                    // 2. Tự động chọn radio button trong các nhóm radio nếu chưa được chọn
                    var radioGroups = {};
                    var radios = dlg.querySelectorAll('input[type=""radio""], [role=""radio""]');
                    for (var j = 0; j < radios.length; j++) {
                        var r = radios[j];
                        var g = r.name || (r.closest('[role=""radiogroup""]') ? r.closest('[role=""radiogroup""]').getAttribute('aria-label') : '') || ('grp_' + j);
                        if (!radioGroups[g]) radioGroups[g] = [];
                        radioGroups[g].push(r);
                    }

                    for (var k in radioGroups) {
                        var list = radioGroups[k];
                        var hasSelected = list.some(function(x) { return x.checked || x.getAttribute('aria-checked') === 'true'; });
                        if (!hasSelected && list.length > 0) {
                            list[0].click();
                            if (!list[0].checked && list[0].getAttribute('aria-checked') !== 'true') {
                                var parent = list[0].closest('label, div') || list[0].parentElement;
                                if (parent) parent.click();
                            }
                        }
                    }
                } catch(e) {}
            })()";

            chrome.method_14(jsScript);
        }
        catch
        {
        }
    }

    /// <summary>
    /// Tìm và click nút gửi (Submit / Gửi / Hoàn tất / Tiếp tục) trong dialog.
    /// </summary>
    public static string ClickSubmitButton(Chrome chrome)
    {
        if (chrome == null) return "no_chrome";

        try
        {
            string jsClick = @"return (() => {
                try {
                    var dlg = document.querySelector('[role=""dialog""]');
                    if (!dlg) return 'no_dialog';

                    var submitKeywords = [
                        'gửi', 'submit', 'hoàn tất', 'xong', 'done', 
                        'tiếp', 'next', 'xác nhận', 'confirm', 
                        'gửi câu trả lời', 'submit answers'
                    ];

                    var btns = dlg.querySelectorAll('[role=""button""], button, input[type=""submit""]');
                    for (var i = 0; i < btns.length; i++) {
                        var b = btns[i];
                        if (b.getAttribute('aria-disabled') === 'true' || b.disabled) continue;

                        var t = (b.innerText || b.value || '').trim().toLowerCase();
                        var a = (b.getAttribute('aria-label') || '').trim().toLowerCase();

                        // Bỏ qua các nút đóng/hủy
                        if (a.includes('đóng') || a.includes('close') || a.includes('hủy') || a.includes('cancel') ||
                            t === 'đóng' || t === 'close' || t === 'hủy' || t === 'cancel' || t === 'quay lại' || t === 'back') {
                            continue;
                        }

                        for (var k = 0; k < submitKeywords.length; k++) {
                            var kw = submitKeywords[k];
                            if (t === kw || (t.indexOf(kw) !== -1 && t.length < 25) || a === kw || (a.indexOf(kw) !== -1 && a.length < 25)) {
                                b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                b.click();
                                return 'clicked_' + kw;
                            }
                        }
                    }

                    return 'not_found';
                } catch(e) {
                    return 'error: ' + e.message;
                }
            })()";

            return chrome.method_14(jsClick);
        }
        catch (Exception ex)
        {
            return "error: " + ex.Message;
        }
    }

    /// <summary>
    /// Xử lý toàn diện hộp thoại câu hỏi và nội quy gia nhập nhóm Facebook:
    /// - Quét câu hỏi và input bằng JavaScript.
    /// - Gọi Gemini AI sinh câu trả lời theo ngữ cảnh từng câu hỏi.
    /// - Tích đồng ý nội quy (checkbox) và chọn radio button.
    /// - Bấm nút Gửi / Submit.
    /// </summary>
    public static bool HandleGroupQuestionsDialog(Chrome chrome, string groupName, bool autoAnswer, List<string> answers, bool agreeRules)
    {
        if (chrome == null) return false;

        try
        {
            // Kiểm tra xem có dialog đang mở không
            bool hasDialog = Convert.ToBoolean(chrome.method_14(@"return (() => {
                var dlg = document.querySelector('[role=""dialog""]');
                return dlg !== null && dlg.offsetParent !== null;
            })()"));

            if (!hasDialog) return false;

            chrome.F8091028(0.8);

            // Nếu chưa có tên nhóm, thử lấy từ tiêu đề dialog
            if (string.IsNullOrWhiteSpace(groupName))
            {
                groupName = chrome.method_14(@"return (() => {
                    var dlg = document.querySelector('[role=""dialog""]');
                    if (!dlg) return '';
                    var h = dlg.querySelector('h2, [role=""heading""], h1');
                    return h ? (h.innerText || '').trim() : '';
                })()");
            }

            // Vòng lặp tối đa 4 bước để xử lý các dialog nhiều trang (Bước 1: Trả lời -> Bước 2: Đồng ý quy tắc -> Gửi)
            for (int step = 0; step < 4; step++)
            {
                // 1. Đồng ý quy tắc và radio options
                if (agreeRules)
                {
                    AgreeRulesAndRadios(chrome);
                }

                // 2. Trả lời câu hỏi bằng AI nếu bật chế độ tự động trả lời
                if (autoAnswer)
                {
                    var questions = ExtractQuestionsAndInputs(chrome);

                    if (questions != null && questions.Count > 0)
                    {
                        for (int i = 0; i < questions.Count; i++)
                        {
                            var qItem = questions[i];
                            string fallback = "";
                            if (answers != null && answers.Count > 0)
                            {
                                fallback = Commom.smethod_31(answers[_random.Next(answers.Count)]).Trim();
                            }

                            string finalAnswer = GenerateAnswerForQuestion(groupName, qItem.Question, fallback);
                            FillAnswer(chrome, qItem.Index, finalAnswer);
                            chrome.F8091028(0.3 + _random.NextDouble() * 0.3);
                        }
                    }
                    else if (answers != null && answers.Count > 0)
                    {
                        // Fallback: Nếu không bóc tách được chi tiết thẻ câu hỏi nhưng có ô text
                        int rawInputCount = Convert.ToInt32(chrome.method_14(@"return (() => {
                            var dlg = document.querySelector('[role=""dialog""]');
                            if (!dlg) return 0;
                            return dlg.querySelectorAll('textarea, input[type=""text""]').length;
                        })()"));

                        for (int t = 0; t < rawInputCount; t++)
                        {
                            string fallback = Commom.smethod_31(answers[_random.Next(answers.Count)]).Trim();
                            string finalAnswer = GenerateAnswerForQuestion(groupName, "", fallback);
                            FillAnswer(chrome, t, finalAnswer);
                            chrome.F8091028(0.3);
                        }
                    }
                }

                // 3. Click nút Gửi / Tiếp tục
                string clickResult = ClickSubmitButton(chrome);
                chrome.F8091028(1.5);

                // Kiểm tra dialog còn mở hay không
                bool dialogStillOpen = Convert.ToBoolean(chrome.method_14(@"return (() => {
                    var dlg = document.querySelector('[role=""dialog""]');
                    return dlg !== null && dlg.offsetParent !== null;
                })()"));

                if (!dialogStillOpen)
                {
                    return true;
                }

                if (clickResult == "not_found")
                {
                    // Đóng dialog nếu không tìm thấy nút submit
                    chrome.method_14(@"(() => {
                        var closeBtn = document.querySelector('[role=""dialog""] [aria-label*=""Đóng"" i], [role=""dialog""] [aria-label*=""Close"" i], [role=""dialog""] div[aria-label=""Close"" i]');
                        if (closeBtn) closeBtn.click();
                    })()");
                    break;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}
