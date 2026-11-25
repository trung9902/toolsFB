using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

/// <summary>
/// CommonChromeV2: Bộ công cụ hiện đại hóa điều khiển Chrome & Facebook Comet 2026.
/// Khai tử hoàn toàn mbasic.facebook.com, tối ưu tương tác qua Comet DOM, GraphQL và CDP.
/// </summary>
public static class CommonChromeV2
{
    /// <summary>
    /// Đọc an toàn title/og:title từ DOM.
    /// Chuẩn hóa Comet 2026.
    /// </summary>
    public static string GetPageTitle(Chrome chrome)
    {
        if (chrome == null || chrome.CD930D04()) return "";

        string title = "";
        try
        {
            string scriptTitle = @"(() => {
                try {
                    var og = document.querySelector('meta[property=""og:title""]');
                    if (og) {
                        var content = og.getAttribute('content');
                        if (content && content.trim()) return content.trim();
                    }
                    var h1 = document.querySelector('h1[dir=""auto""], h1');
                    if (h1 && h1.innerText && h1.innerText.trim()) {
                        return h1.innerText.trim();
                    }
                    var actor = document.querySelector('.actor, [data-gt] a');
                    if (actor && actor.innerText && actor.innerText.trim()) {
                        return actor.innerText.trim();
                    }
                    var docTitle = document.title || '';
                    if (docTitle) {
                        return docTitle.split(/[-|]/)[0].trim();
                    }
                } catch(e) {}
                return '';
            })()";

            title = chrome.method_14(scriptTitle)?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(title))
            {
                try
                {
                    string docTitle = chrome.ChromeDriver_0?.Title ?? "";
                    if (!string.IsNullOrEmpty(docTitle))
                    {
                        title = docTitle.Split('-', '|')[0].Trim();
                    }
                }
                catch { }
            }

            if (!string.IsNullOrEmpty(title))
            {
                title = WebUtility.HtmlDecode(title).Trim();
            }
        }
        catch (Exception)
        {
        }

        return title ?? "";
    }

    /// <summary>
    /// Lấy danh sách UID bạn bè/tin nhắn gần nhất qua Comet DOM hoặc GraphQL fetch ('/api/graphql/').
    /// Chuẩn hóa Comet 2026, loại bỏ hoàn toàn mbasic.
    /// </summary>
    public static List<string> GetMessengerThreadList(Chrome chrome)
    {
        List<string> result = new List<string>();
        if (chrome == null || chrome.CD930D04()) return result;

        try
        {
            // 1. Kiểm tra nếu chưa ở trang Facebook / Messenger thì điều hướng sang Messenger www
            string currentUrl = chrome.GetURL() ?? "";
            if (!currentUrl.Contains("facebook.com/messages"))
            {
                chrome.method_12("https://www.facebook.com/messages/t/");
                chrome.F8091028(2.0);
            }

            // 2. Trích xuất UID / thread ID từ Comet DOM
            string scriptDom = @"(() => {
                var uids = [];
                var seen = new Set();
                try {
                    var links = document.querySelectorAll('a[href*=""/messages/t/""], div[role=""grid""] a[role=""link""], div[role=""navigation""] a[href*=""/messages/t/""]');
                    for (var i = 0; i < links.length; i++) {
                        var href = links[i].getAttribute('href') || '';
                        var m = href.match(/\/messages\/t\/([0-9]{5,})/);
                        if (m && m[1] && !seen.has(m[1])) {
                            seen.add(m[1]);
                            uids.push(m[1]);
                            continue;
                        }
                        var m2 = href.match(/\/messages\/t\/([^/?#&]+)/);
                        if (m2 && m2[1] && m2[1] !== 'new' && !seen.has(m2[1])) {
                            seen.add(m2[1]);
                            uids.push(m2[1]);
                        }
                    }
                } catch(e) {}
                return JSON.stringify(uids);
            })()";

            string jsonDom = chrome.method_14(scriptDom);
            if (!string.IsNullOrEmpty(jsonDom) && jsonDom.StartsWith("["))
            {
                JArray jArr = JArray.Parse(jsonDom);
                foreach (var token in jArr)
                {
                    string uid = token?.ToString();
                    if (!string.IsNullOrEmpty(uid) && !result.Contains(uid))
                    {
                        result.Add(uid);
                    }
                }
            }

            // 3. Fallback: Nếu DOM chưa load danh sách tin nhắn, fetch qua internal buddylist Comet
            if (result.Count == 0)
            {
                string scriptBuddy = @"async function FetchBuddylistThreads() {
                    var uids = [];
                    var seen = new Set();
                    try {
                        var dtsg = '';
                        var m = document.documentElement.innerHTML.match(/[""']DTSGInitialData[""'],\[\],\{[""']token[""']:[""']([^""']+)[""']/);
                        if (m) dtsg = m[1];
                        if (!dtsg) {
                            var el = document.querySelector('input[name=""fb_dtsg""]');
                            if (el) dtsg = el.value;
                        }
                        var c_user = (document.cookie.match(/(?:^|;\s*)c_user=([0-9]+)/) || [])[1] || '';
                        if (dtsg && c_user) {
                            var resp = await fetch('https://www.facebook.com/buddylist.php', {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                                body: 'data_fetch=true&send_full_data=true&fb_dtsg=' + encodeURIComponent(dtsg) + '&jazoest=&lsd=r&__dyn=&__csr=&__req=a&__a=&__user=' + c_user
                            });
                            if (resp.ok) {
                                var txt = await resp.text();
                                var clean = txt.replace('for (;;);', '');
                                var data = JSON.parse(clean);
                                var list = data.payload?.buddylist || data.payload?.buddy_list || [];
                                for (var i = 0; i < list.length; i++) {
                                    var id = (list[i].id || list[i].uid || '').toString();
                                    if (id && !seen.has(id)) {
                                        seen.add(id);
                                        uids.push(id);
                                    }
                                }
                            }
                        }
                    } catch(e) {}
                    return JSON.stringify(uids);
                };
                var c = await FetchBuddylistThreads();
                return c;";

                string jsonBuddy = chrome.method_14(scriptBuddy);
                if (!string.IsNullOrEmpty(jsonBuddy) && jsonBuddy.StartsWith("["))
                {
                    JArray jArr = JArray.Parse(jsonBuddy);
                    foreach (var token in jArr)
                    {
                        string uid = token?.ToString();
                        if (!string.IsNullOrEmpty(uid) && !result.Contains(uid))
                        {
                            result.Add(uid);
                        }
                    }
                }
            }

            // 4. Fallback 2: Thử truy vấn qua GraphQL q=me(){friends}
            if (result.Count == 0)
            {
                string scriptGraphQL = @"async function FetchGraphQLThreads() {
                    var uids = [];
                    try {
                        var dtsg = '';
                        var m = document.documentElement.innerHTML.match(/[""']DTSGInitialData[""'],\[\],\{[""']token[""']:[""']([^""']+)[""']/);
                        if (m) dtsg = m[1];
                        if (!dtsg) {
                            var el = document.querySelector('input[name=""fb_dtsg""]');
                            if (el) dtsg = el.value;
                        }
                        if (dtsg) {
                            var resp = await fetch('https://www.facebook.com/api/graphql/', {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                                body: 'q=me(){friends{nodes{id,name}}}&fb_dtsg=' + encodeURIComponent(dtsg)
                            });
                            if (resp.ok) {
                                var data = await resp.json();
                                for (var k in data) {
                                    var nodes = data[k]?.friends?.nodes || [];
                                    for (var i = 0; i < nodes.length; i++) {
                                        if (nodes[i]?.id) uids.push(nodes[i].id.toString());
                                    }
                                }
                            }
                        }
                    } catch(e) {}
                    return JSON.stringify(uids);
                };
                var c = await FetchGraphQLThreads();
                return c;";

                string jsonGraphQL = chrome.method_14(scriptGraphQL);
                if (!string.IsNullOrEmpty(jsonGraphQL) && jsonGraphQL.StartsWith("["))
                {
                    JArray jArr = JArray.Parse(jsonGraphQL);
                    foreach (var token in jArr)
                    {
                        string uid = token?.ToString();
                        if (!string.IsNullOrEmpty(uid) && !result.Contains(uid))
                        {
                            result.Add(uid);
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
        }

        return result;
    }

    /// <summary>
    /// Quét lịch sử tương tác/bình luận theo thời gian qua Comet Activity Log hoặc GraphQL query an toàn, không dùng mbasic.
    /// Chuẩn hóa Comet 2026.
    /// </summary>
    public static List<string> GetRecentCommentActivity(Chrome chrome, int months = 1)
    {
        List<string> list = new List<string>();
        if (chrome == null || chrome.CD930D04()) return list;

        try
        {
            string uid = "";
            try { uid = chrome.FB94939A(); } catch { }
            string targetUrl = string.IsNullOrEmpty(uid)
                ? "https://www.facebook.com/me/allactivity/?category_key=commentscluster"
                : $"https://www.facebook.com/{uid}/allactivity/?category_key=commentscluster";

            string currentUrl = chrome.GetURL() ?? "";
            if (!currentUrl.Contains("allactivity") || !currentUrl.Contains("commentscluster"))
            {
                chrome.method_12(targetUrl);
                chrome.F8091028(2.0);
            }

            // Scroll nhẹ theo số tháng để Comet tải thêm dữ liệu hoạt động
            int scrollSteps = Math.Min(Math.Max(months, 1), 6);
            for (int i = 0; i < scrollSteps; i++)
            {
                chrome.method_14("window.scrollBy({ top: 800, behavior: 'smooth' });");
                chrome.F8091028(1.0);
            }

            // Trích xuất các bản ghi bình luận từ Activity Log Comet DOM
            string scriptExtract = @"(() => {
                var records = [];
                var seen = new Set();
                try {
                    var items = document.querySelectorAll('div[role=""main""] div[role=""article""], div[role=""main""] div[dir=""auto""], div[role=""feed""] div[dir=""auto""]');
                    for (var i = 0; i < items.length; i++) {
                        var txt = (items[i].innerText || '').trim();
                        if (txt.length >= 5 && (txt.includes('bình luận') || txt.includes('comment') || txt.includes('đã trả lời') || txt.includes('replied') || txt.includes('bài viết'))) {
                            var lower = txt.toLowerCase();
                            if (lower !== 'bình luận' && lower !== 'comment' && lower !== 'thích' && lower !== 'like' && !seen.has(txt)) {
                                seen.add(txt);
                                records.push(txt);
                            }
                        }
                    }
                    if (records.length === 0) {
                        var rows = document.querySelectorAll('div[role=""main""] div[data-visualcompletion=""ignore-dynamic-hydration""]');
                        for (var j = 0; j < rows.length; j++) {
                            var t = (rows[j].innerText || '').trim();
                            if (t.length > 5 && !seen.has(t)) {
                                seen.add(t);
                                records.push(t);
                            }
                        }
                    }
                } catch(e) {}
                return JSON.stringify(records);
            })()";

            string jsonRecords = chrome.method_14(scriptExtract);
            if (!string.IsNullOrEmpty(jsonRecords) && jsonRecords.StartsWith("["))
            {
                JArray jArr = JArray.Parse(jsonRecords);
                foreach (var token in jArr)
                {
                    string rec = token?.ToString();
                    if (!string.IsNullOrEmpty(rec) && !list.Contains(rec))
                    {
                        list.Add(rec);
                    }
                }
            }
        }
        catch (Exception)
        {
        }

        return list;
    }

    /// <summary>
    /// Lấy danh sách ID page gợi ý từ Comet Facebook /pages/?category=your_pages hoặc top_suggestions không qua mbasic.
    /// Chuẩn hóa Comet 2026.
    /// </summary>
    public static List<string> GetSuggestedPages(Chrome chrome)
    {
        List<string> result = new List<string>();
        if (chrome == null || chrome.CD930D04()) return result;

        try
        {
            string currentUrl = chrome.GetURL() ?? "";
            if (!currentUrl.Contains("facebook.com/pages"))
            {
                chrome.method_12("https://www.facebook.com/pages/?category=top_suggestions");
                chrome.F8091028(2.5);
            }

            // Scroll nhẹ để Comet render các card gợi ý
            chrome.method_14("window.scrollBy({ top: 600, behavior: 'smooth' });");
            chrome.F8091028(1.0);

            // Trích xuất Page IDs từ Comet DOM và metadata
            string scriptPages = @"(() => {
                var pids = [];
                var seen = new Set();
                try {
                    var links = document.querySelectorAll('a[href*=""/pages/""], a[href*=""profile.php?id=""], div[role=""main""] a[role=""link""]');
                    for (var i = 0; i < links.length; i++) {
                        var href = links[i].getAttribute('href') || '';
                        var m = href.match(/profile\.php\?id=([0-9]{5,})/);
                        if (m && m[1] && !seen.has(m[1])) {
                            seen.add(m[1]);
                            pids.push(m[1]);
                            continue;
                        }
                        var m2 = href.match(/\/pages\/[^/]+\/([0-9]{5,})/);
                        if (m2 && m2[1] && !seen.has(m2[1])) {
                            seen.add(m2[1]);
                            pids.push(m2[1]);
                            continue;
                        }
                    }

                    var btns = document.querySelectorAll('[data-page-id], [data-profile-id]');
                    for (var j = 0; j < btns.length; j++) {
                        var id = btns[j].getAttribute('data-page-id') || btns[j].getAttribute('data-profile-id');
                        if (id && /^[0-9]+$/.test(id) && !seen.has(id)) {
                            seen.add(id);
                            pids.push(id);
                        }
                    }
                } catch(e) {}
                return JSON.stringify(pids);
            })()";

            string jsonPages = chrome.method_14(scriptPages);
            if (!string.IsNullOrEmpty(jsonPages) && jsonPages.StartsWith("["))
            {
                JArray jArr = JArray.Parse(jsonPages);
                foreach (var token in jArr)
                {
                    string pid = token?.ToString();
                    if (!string.IsNullOrEmpty(pid) && !result.Contains(pid))
                    {
                        result.Add(pid);
                    }
                }
            }

            // Quét bổ sung qua regex trong DOM html nếu kết quả ít
            if (result.Count < 5)
            {
                try
                {
                    string html = chrome.method_14("return document.documentElement.innerHTML;") ?? "";
                    MatchCollection mc1 = Regex.Matches(html, "\"page_suggestion_(\\d+)\"");
                    foreach (Match m in mc1)
                    {
                        string id = m.Groups[1].Value;
                        if (!string.IsNullOrEmpty(id) && !result.Contains(id))
                        {
                            result.Add(id);
                        }
                    }

                    MatchCollection mc2 = Regex.Matches(html, "\"delegate_page\":\\{\"id\":\"(\\d+)\"\\}");
                    foreach (Match m in mc2)
                    {
                        string id = m.Groups[1].Value;
                        if (!string.IsNullOrEmpty(id) && !result.Contains(id))
                        {
                            result.Add(id);
                        }
                    }
                }
                catch { }
            }
        }
        catch (Exception)
        {
        }

        return result;
    }

    /// <summary>
    /// Lấy danh sách bạn bè qua GraphQL Comet 2026 hoặc DOM fallback an toàn, không phụ thuộc mbasic.
    /// </summary>
    public static List<string> GetFriendsList(Chrome chrome, bool filterVietnamese = false)
    {
        List<string> list = new List<string>();
        if (chrome == null || chrome.CD930D04()) return list;

        try
        {
            string propertyName = "";
            try { propertyName = chrome.FB94939A(); } catch { }
            string dtsg = "";
            try { dtsg = chrome.method_41(); } catch { }

            // GraphQL fetch trực tiếp trong context Facebook
            string script = @"async function RequestFriends() {
                var output = '';
                try {
                    var response = await fetch('https://www.facebook.com/api/graphql/', {
                        method: 'POST',
                        body: 'q=me(){friends}&fb_dtsg=" + dtsg + @"',
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                    });
                    if (response.ok) {
                        output = await response.text();
                    }
                } catch(e) {}
                return output;
            };
            var c = await RequestFriends();
            return c;";

            string json = chrome.method_14(script);
            if (!string.IsNullOrEmpty(json))
            {
                JObject jObject = JObject.Parse(json);
                JToken nodes = null;
                if (!string.IsNullOrEmpty(propertyName) && jObject[propertyName]?["friends"]?["nodes"] != null)
                {
                    nodes = jObject[propertyName]["friends"]["nodes"];
                }
                else
                {
                    foreach (var prop in jObject.Properties())
                    {
                        if (prop.Value?["friends"]?["nodes"] != null)
                        {
                            nodes = prop.Value["friends"]["nodes"];
                            break;
                        }
                    }
                }

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        string name = node["name"]?.ToString() ?? "";
                        if (filterVietnamese)
                        {
                            if (Commom.D9AB3B82(name))
                            {
                                list.Add(name);
                            }
                        }
                        else
                        {
                            list.Add(name);
                        }
                    }
                }
            }
        }
        catch { }

        // Fallback: Graph API nếu có access token
        if (list.Count == 0)
        {
            try
            {
                string token = chrome.FB001323();
                if (!string.IsNullOrEmpty(token))
                {
                    string url = "https://graph.facebook.com/me/friends?limit=5000&fields=name&access_token=" + token;
                    string json2 = new RequestXNet("", "", chrome?.A3A32284 ?? "", chrome?.Int32_1 ?? 0).E58EB99F(url);
                    if (!string.IsNullOrEmpty(json2))
                    {
                        JObject jObject2 = JObject.Parse(json2);
                        if (jObject2["data"] != null)
                        {
                            foreach (var item in jObject2["data"])
                            {
                                string text4 = item["name"]?.ToString() ?? "";
                                if (filterVietnamese)
                                {
                                    if (Commom.D9AB3B82(text4))
                                    {
                                        list.Add(text4);
                                    }
                                }
                                else
                                {
                                    list.Add(text4);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // Fallback: DOM scraping me/friends nếu vẫn rỗng
        if (list.Count == 0)
        {
            try
            {
                string cur = chrome.GetURL() ?? "";
                if (!cur.Contains("/me/friends") && !cur.Contains("/friends"))
                {
                    chrome.method_12("https://www.facebook.com/me/friends");
                    chrome.F8091028(2.0);
                }

                string scriptDom = @"(() => {
                    var names = [];
                    try {
                        var links = document.querySelectorAll('div[role=""main""] a[role=""link""], div[role=""feed""] a[role=""link""]');
                        for (var i = 0; i < links.length; i++) {
                            var t = (links[i].innerText || '').trim();
                            if (t && t.length > 2 && !names.includes(t) && !['Bạn bè', 'Friends', 'Tất cả bạn bè', 'All friends'].includes(t)) {
                                names.push(t);
                            }
                        }
                    } catch(e) {}
                    return JSON.stringify(names);
                })()";
                string jsonDom = chrome.method_14(scriptDom);
                if (!string.IsNullOrEmpty(jsonDom) && jsonDom.StartsWith("["))
                {
                    JArray arr = JArray.Parse(jsonDom);
                    foreach (var item in arr)
                    {
                        string name = item?.ToString() ?? "";
                        if (filterVietnamese)
                        {
                            if (Commom.D9AB3B82(name)) list.Add(name);
                        }
                        else
                        {
                            list.Add(name);
                        }
                    }
                }
            }
            catch { }
        }

        return list;
    }
}
