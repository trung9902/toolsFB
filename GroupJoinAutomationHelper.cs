using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

public static class GroupJoinAutomationHelper
{
    private static readonly Random _random = new Random();

    public static int JoinGroups(fMain form, int int_3, string A92F5F31, Chrome chrome_0, GClass4 gclass4_0, string string_1 = "")
    {
        int nudSoLuongFrom = gclass4_0.method_2("nudSoLuongFrom", 1);
        int nudSoLuongTo = gclass4_0.method_2("nudSoLuongTo", 3);
        int nudDelayFrom = gclass4_0.method_2("nudDelayFrom", 3);
        int nudDelayTo = gclass4_0.method_2("nudDelayTo", 5);
        List<string> listTuKhoa = gclass4_0.method_1("txtTuKhoa");
        bool ckbTuDongTraLoiCauHoi = gclass4_0.method_3("ckbTuDongTraLoiCauHoi");
        List<string> listCauTraLoi = gclass4_0.method_1("txtCauTraLoi");

        bool ckbGroupId = gclass4_0.method_3("ckbGroupId");
        List<string> listGroupIds = ckbGroupId ? gclass4_0.method_1("txtGroupId") : new List<string>();

        bool ckbGoChuTimKiem = gclass4_0.method_3("ckbGoChuTimKiem", true);
        bool ckbDongYQuyTac = gclass4_0.method_3("ckbDongYQuyTac", true);
        bool ckbSkipJoined = gclass4_0.method_3("ckbSkipJoined", true);

        int result = 0;
        bool isZoomed = false;

        try
        {
            int targetCount = chrome_0.method_50(nudSoLuongFrom, nudSoLuongTo);
            if (targetCount <= 0 || listTuKhoa == null || listTuKhoa.Count == 0)
            {
                return 0;
            }

            List<string> shuffledKeywords = listTuKhoa.Where(k => !string.IsNullOrWhiteSpace(k))
                                                      .OrderBy(x => Guid.NewGuid())
                                                      .ToList();
            if (shuffledKeywords.Count == 0) return 0;

            int keywordIndex = 0;

            while (result < targetCount && !Base.smethod_5() && !chrome_0.CD930D04())
            {
                string rawKeyword = shuffledKeywords[keywordIndex % shuffledKeywords.Count];
                string keyword = Commom.smethod_31(rawKeyword).Trim();

                bool searchSuccess = PerformKeywordSearch(form, int_3, A92F5F31, chrome_0, keyword, ckbGoChuTimKiem);
                if (!searchSuccess)
                {
                    int loginStatus = chrome_0.method_125();
                    if (new List<int> { -3, -2, -1, 2 }.Contains(loginStatus))
                    {
                        return -1;
                    }
                }

                isZoomed = true;
                chrome_0.method_53();
                chrome_0.method_60();

                form.method_130(int_3, A92F5F31 + Language.GetValue("Đang") + $" {string_1} ({result + 1}/{targetCount})...");

                int keywordTickCount = Environment.TickCount;
                int maxTimeoutKeyword = 180;
                int consecutiveScrolls = 0;

                while (result < targetCount &&
                       Environment.TickCount - keywordTickCount <= maxTimeoutKeyword * 1000 &&
                       !Base.smethod_5() &&
                       !chrome_0.CD930D04())
                {
                    GroupJoinCardResult cardResult = ScanAndClickJoinButton(chrome_0, ckbSkipJoined);

                    if (cardResult != null && cardResult.Found)
                    {
                        consecutiveScrolls = 0;
                        chrome_0.F8091028(2.0);

                        if (ckbGroupId && listGroupIds.Count > 0 && !string.IsNullOrEmpty(cardResult.Href))
                        {
                            string gid = Regex.Match(cardResult.Href, @"\/groups\/([^/?#]+)").Groups[1].Value;
                            if (!string.IsNullOrEmpty(gid) && !listGroupIds.Contains(gid))
                            {
                                continue;
                            }
                        }

                        HandleGroupQuestionsAndRules(chrome_0, ckbTuDongTraLoiCauHoi, listCauTraLoi, ckbDongYQuyTac, cardResult.Name);

                        result++;

                        form.method_131(int_3, A92F5F31 + Language.GetValue("Đang") + string.Format(" {0} ({1}/{2}), {3} {{time}}s...", string_1, result, targetCount, Language.GetValue("đợi")), nudDelayFrom, nudDelayTo);

                        if (result >= targetCount)
                        {
                            break;
                        }

                        form.method_130(int_3, A92F5F31 + Language.GetValue("Đang") + $" {string_1} ({result + 1}/{targetCount})...");
                        keywordTickCount = Environment.TickCount;
                    }
                    else
                    {
                        consecutiveScrolls++;
                        if (consecutiveScrolls >= 6)
                        {
                            break;
                        }

                        HumanScroll.ScrollNewsfeed(chrome_0, 450 + _random.Next(80, 260));
                        chrome_0.F8091028(1.5 + _random.NextDouble());
                    }
                }

                keywordIndex++;
                if (keywordIndex >= shuffledKeywords.Count && result < targetCount)
                {
                    break;
                }
            }
        }
        catch
        {
            result = -1;
        }
        finally
        {
            if (isZoomed)
            {
                chrome_0.method_54();
            }
        }

        return result;
    }

    private static bool PerformKeywordSearch(fMain form, int int_3, string A92F5F31, Chrome chrome_0, string keyword, bool ckbGoChuTimKiem)
    {
        try
        {
            if (ckbGoChuTimKiem)
            {
                form.method_130(int_3, A92F5F31 + Language.GetValue("Tìm kiếm nhóm: ") + keyword + "...");

                string currentUrl = "";
                try { currentUrl = chrome_0.ChromeDriver_0.Url; } catch { }
                if (string.IsNullOrEmpty(currentUrl) || !currentUrl.Contains("facebook.com"))
                {
                    chrome_0.method_12("https://www.facebook.com/", FC3A841F: true);
                    chrome_0.F8091028(2.5);
                }

                int loginStatus = chrome_0.method_125();
                if (new List<int> { -3, -2, -1, 2 }.Contains(loginStatus)) return false;

                string jsLocateSearch = @"(() => {
                    try {
                        var selectors = [
                            'input[placeholder*=""Tìm kiếm"" i]',
                            'input[placeholder*=""Search"" i]',
                            'input[aria-label*=""Tìm kiếm"" i]',
                            'input[aria-label*=""Search"" i]',
                            'input[type=""search""]',
                            'div[role=""search""] input'
                        ];
                        for (var s = 0; s < selectors.length; s++) {
                            var inp = document.querySelector(selectors[s]);
                            if (inp && inp.offsetParent !== null) {
                                inp.focus();
                                inp.click();
                                return true;
                            }
                        }
                        var searchBtn = document.querySelector('[aria-label*=""Search Facebook"" i], [aria-label*=""Tìm kiếm trên Facebook"" i], a[href*=""/search/""], [role=""button""][aria-label*=""Search"" i]');
                        if (searchBtn) {
                            searchBtn.click();
                            for (var s2 = 0; s2 < selectors.length; s2++) {
                                var inp2 = document.querySelector(selectors[s2]);
                                if (inp2) {
                                    inp2.focus();
                                    inp2.click();
                                    return true;
                                }
                            }
                        }
                        return false;
                    } catch(e) {
                        return false;
                    }
                })()";

                bool inputFound = Convert.ToBoolean(chrome_0.method_14("return " + jsLocateSearch + ";"));

                if (inputFound)
                {
                    chrome_0.F8091028(0.6);
                    try
                    {
                        IWebElement activeInput = chrome_0.ChromeDriver_0.SwitchTo().ActiveElement();
                        activeInput.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                        activeInput.SendKeys(OpenQA.Selenium.Keys.Backspace);
                        Thread.Sleep(_random.Next(120, 250));

                        foreach (char c in keyword)
                        {
                            activeInput.SendKeys(c.ToString());
                            Thread.Sleep(_random.Next(60, 180));
                        }

                        Thread.Sleep(_random.Next(300, 600));
                        activeInput.SendKeys(OpenQA.Selenium.Keys.Enter);
                    }
                    catch
                    {
                        string escaped = keyword.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "").Replace("\n", "");
                        chrome_0.method_14($@"(() => {{
                            var inp = document.querySelector('input[placeholder*=""Tìm kiếm"" i], input[placeholder*=""Search"" i], input[aria-label*=""Search"" i], input[type=""search""]');
                            if (inp) {{
                                inp.value = '{escaped}';
                                inp.dispatchEvent(new Event('input', {{ bubbles: true }}));
                                inp.dispatchEvent(new Event('change', {{ bubbles: true }}));
                                var enter = new KeyboardEvent('keydown', {{ bubbles: true, cancelable: true, key: 'Enter', keyCode: 13 }});
                                inp.dispatchEvent(enter);
                            }}
                        }})()");
                    }

                    chrome_0.F8091028(2.8);

                    string jsFilterGroups = @"(() => {
                        try {
                            if (window.location.href.indexOf('/search/groups') !== -1) return true;
                            
                            var groupLink = document.querySelector('a[href*=""/search/groups/""], a[href*=""search/groups""]');
                            if (groupLink) {
                                groupLink.click();
                                return true;
                            }
                            var items = document.querySelectorAll('div[role=""navigation""] a, div[role=""feed""] a, [role=""tablist""] a, [role=""tablist""] [role=""tab""], div[role=""list""] a, [role=""navigation""] [role=""button""]');
                            for (var i = 0; i < items.length; i++) {
                                var t = (items[i].innerText || items[i].getAttribute('aria-label') || '').trim().toLowerCase();
                                if (t === 'nhóm' || t === 'groups') {
                                    items[i].click();
                                    return true;
                                }
                            }
                            return false;
                        } catch(e) {
                            return false;
                        }
                    })()";

                    bool filtered = Convert.ToBoolean(chrome_0.method_14("return " + jsFilterGroups + ";"));
                    if (filtered)
                    {
                        chrome_0.F8091028(2.5);
                    }
                    else
                    {
                        chrome_0.method_12("https://www.facebook.com/search/groups/?q=" + Uri.EscapeDataString(keyword), FC3A841F: true);
                        chrome_0.F8091028(3.0);
                    }
                }
                else
                {
                    chrome_0.method_12("https://www.facebook.com/search/groups/?q=" + Uri.EscapeDataString(keyword), FC3A841F: true);
                    chrome_0.F8091028(3.0);
                }
            }
            else
            {
                chrome_0.method_12("https://www.facebook.com/search/groups/?q=" + Uri.EscapeDataString(keyword), FC3A841F: true);
                chrome_0.F8091028(3.0);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private class GroupJoinCardResult
    {
        public bool Found { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
    }

    private static GroupJoinCardResult ScanAndClickJoinButton(Chrome chrome_0, bool ckbSkipJoined)
    {
        string jsScanAndClick = @"(() => {
            try {
                var skipJoined = " + (ckbSkipJoined ? "true" : "false") + @";
                var skipWords = [
                    'đã tham gia', 'joined',
                    'đã gửi yêu cầu', 'chờ phê duyệt', 'chờ duyệt',
                    'yêu cầu đang chờ duyệt', 'pending', 'requested',
                    'hủy yêu cầu', 'cancel request'
                ];

                var cards = document.querySelectorAll('[role=""feed""] > div, [role=""article""], div[data-visualcompletion=""ignore-dynamic""], div[role=""main""] div[data-visualcompletion]');
                for (var i = 0; i < cards.length; i++) {
                    var card = cards[i];
                    if (card.getAttribute('data-lc-join-done') === '1' || card.getAttribute('data-lc-join-skip') === '1') {
                        continue;
                    }

                    var cardText = (card.innerText || '').toLowerCase();

                    var isJoined = false;
                    for (var s = 0; s < skipWords.length; s++) {
                        if (cardText.indexOf(skipWords[s]) !== -1) {
                            isJoined = true;
                            break;
                        }
                    }

                    if (skipJoined && isJoined) {
                        card.setAttribute('data-lc-join-skip', '1');
                        continue;
                    }

                    var joinBtn = null;
                    var candidates = card.querySelectorAll('div[aria-label], [role=""button""], button');
                    for (var b = 0; b < candidates.length; b++) {
                        var el = candidates[b];
                        var aria = (el.getAttribute('aria-label') || '').trim().toLowerCase();
                        var txt = (el.innerText || '').trim().toLowerCase();

                        var isJoin = (aria === 'tham gia' || aria === 'tham gia nhóm' || aria === 'join' || aria === 'join group' ||
                                      txt === 'tham gia' || txt === 'tham gia nhóm' || txt === 'join' || txt === 'join group');

                        if (isJoin) {
                            var hasNegative = false;
                            for (var n = 0; n < skipWords.length; n++) {
                                if (aria.indexOf(skipWords[n]) !== -1 || txt.indexOf(skipWords[n]) !== -1) {
                                    hasNegative = true;
                                    break;
                                }
                            }
                            if (!hasNegative) {
                                joinBtn = el;
                                break;
                            }
                        }
                    }

                    if (!joinBtn) continue;

                    var href = '';
                    var name = '';
                    var link = card.querySelector('a[href*=""/groups/""]');
                    if (link) {
                        href = link.getAttribute('href') || '';
                        name = (link.innerText || '').trim();
                    }

                    card.setAttribute('data-lc-join-done', '1');
                    joinBtn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                    joinBtn.click();

                    return JSON.stringify({
                        found: true,
                        href: href,
                        name: name
                    });
                }

                var looseBtns = document.querySelectorAll('div[aria-label=""Tham gia nhóm"" i], div[aria-label=""Join group"" i], [role=""button""][aria-label*=""Tham gia nhóm"" i], [role=""button""][aria-label*=""Join group"" i]');
                for (var m = 0; m < looseBtns.length; m++) {
                    var lb = looseBtns[m];
                    if (lb.getAttribute('data-lc-join-done') === '1') continue;
                    lb.setAttribute('data-lc-join-done', '1');
                    lb.scrollIntoView({ behavior: 'smooth', block: 'center' });
                    lb.click();
                    return JSON.stringify({ found: true, href: '', name: '' });
                }

                return JSON.stringify({ found: false });
            } catch(e) {
                return JSON.stringify({ found: false, error: e.message });
            }
        })()";

        string resJson = chrome_0.method_14("return " + jsScanAndClick + ";");
        if (string.IsNullOrEmpty(resJson)) return null;

        try
        {
            JObject jObj = JObject.Parse(resJson);
            bool found = jObj["found"]?.ToObject<bool>() ?? false;
            string href = jObj["href"]?.ToString() ?? "";
            string name = jObj["name"]?.ToString() ?? "";
            return new GroupJoinCardResult { Found = found, Href = href, Name = name };
        }
        catch
        {
            return null;
        }
    }

    private static void HandleGroupQuestionsAndRules(Chrome chrome_0, bool autoAnswer, List<string> answers, bool agreeRules, string groupName = "")
    {
        try
        {
            bool hasDialog = Convert.ToBoolean(chrome_0.method_14(@"return (() => {
                var dlg = document.querySelector('[role=""dialog""]');
                return dlg !== null && dlg.offsetParent !== null;
            })()"));

            if (!hasDialog) return;

            chrome_0.F8091028(1.0);

            // Nếu chưa có groupName, thử trích xuất từ tiêu đề dialog
            if (string.IsNullOrWhiteSpace(groupName))
            {
                groupName = chrome_0.method_14(@"return (() => {
                    var dlg = document.querySelector('[role=""dialog""]');
                    if (!dlg) return '';
                    var h = dlg.querySelector('h2, [role=""heading""], h1');
                    return h ? (h.innerText || '').trim() : '';
                })()");
            }

            for (int step = 0; step < 4; step++)
            {
                // 1. Tự động tích đồng ý nội quy (checkbox quy tắc) & chọn radio option mặc định
                if (agreeRules)
                {
                    SmartGroupJoinAIHelper.AgreeRulesAndRadios(chrome_0);
                }

                // 2. Bóc tách câu hỏi và trả lời bằng Gemini AI (hoặc fallback)
                if (autoAnswer)
                {
                    var questions = SmartGroupJoinAIHelper.ExtractQuestionsAndInputs(chrome_0);
                    if (questions != null && questions.Count > 0)
                    {
                        for (int i = 0; i < questions.Count; i++)
                        {
                            var q = questions[i];
                            string fallback = "";
                            if (answers != null && answers.Count > 0)
                            {
                                fallback = Commom.smethod_31(answers[_random.Next(answers.Count)]).Trim();
                            }

                            string generatedAnswer = SmartGroupJoinAIHelper.GenerateAnswerForQuestion(groupName, q.Question, fallback);
                            SmartGroupJoinAIHelper.FillAnswer(chrome_0, q.Index, generatedAnswer);
                            chrome_0.F8091028(0.3 + _random.NextDouble() * 0.3);
                        }
                    }
                    else if (answers != null && answers.Count > 0)
                    {
                        // Fallback thuần nếu DOM dạng custom không bóc tách được label
                        int textInputCount = Convert.ToInt32(chrome_0.method_14(@"return (() => {
                            var dlg = document.querySelector('[role=""dialog""]');
                            if (!dlg) return 0;
                            return dlg.querySelectorAll('textarea, input[type=""text""], input:not([type]), [role=""textbox""][contenteditable=""true""]').length;
                        })()"));

                        for (int t = 0; t < textInputCount; t++)
                        {
                            string fallback = Commom.smethod_31(answers[_random.Next(answers.Count)]).Trim();
                            string generatedAnswer = SmartGroupJoinAIHelper.GenerateAnswerForQuestion(groupName, "", fallback);
                            SmartGroupJoinAIHelper.FillAnswer(chrome_0, t, generatedAnswer);
                            chrome_0.F8091028(0.4);
                        }
                    }
                }

                // 3. Bấm nút gửi (Submit / Gửi / Hoàn tất)
                string clickResult = SmartGroupJoinAIHelper.ClickSubmitButton(chrome_0);

                chrome_0.F8091028(1.5);

                bool dialogStillOpen = Convert.ToBoolean(chrome_0.method_14(@"return (() => {
                    var dlg = document.querySelector('[role=""dialog""]');
                    return dlg !== null && dlg.offsetParent !== null;
                })()"));

                if (!dialogStillOpen) break;

                if (clickResult == "not_found")
                {
                    chrome_0.method_14(@"(() => {
                        var closeBtn = document.querySelector('[role=""dialog""] [aria-label*=""Đóng"" i], [role=""dialog""] [aria-label*=""Close"" i], [role=""dialog""] div[aria-label=""Close"" i]');
                        if (closeBtn) closeBtn.click();
                    })()");
                    break;
                }
            }
        }
        catch
        {
        }
    }
}
