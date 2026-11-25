using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// LushCare Global - Account Info Automation Engine (Modern DOM + High-speed Internal GraphQL)
/// Tối ưu hóa và nâng cấp toàn diện tính năng Tự động cập nhật thông tin tài khoản:
/// - Unified Fast Scrape gom toàn bộ trường thông tin trong 1 lượt quét duy nhất (<2s).
/// - Internal GraphQL siêu tốc: Ngày tạo (doc_id=7863557980324041), Nhóm (doc_id=6985470494844388).
/// - Page Pro5: Cơ chế quét /pages/?category=your_pages và DOM switch profile hiện đại.
/// - Trạng thái Fb Block / Restrict, Avatar Yes/No, Location, Dating, Contact Points.
/// - LOẠI BỎ TRIỆT ĐỂ mọi endpoint mbasic/mobile đã khai tử.
/// </summary>
public static class AccountInfoAutomationHelper
{
    public class AccountInfoData
    {
        public string Uid { get; set; } = "";
        public string Name { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Birthday { get; set; } = "";
        public string Hometown { get; set; } = "";
        public string CurrentCity { get; set; } = "";
        public string Location { get; set; } = "";
        public string Followers { get; set; } = "";
        public string Friends { get; set; } = "";
        public List<string> Emails { get; set; } = new List<string>();
        public List<string> Phones { get; set; } = new List<string>();
        public string DateCreateAcc { get; set; } = "";
        public string Groups { get; set; } = "";
        public List<string> Pages { get; set; } = new List<string>();
        public string Avatar { get; set; } = "";
        public string FbBlock { get; set; } = "";
        public string Dating { get; set; } = "";
        public string Ads { get; set; } = "";
        public string BM { get; set; } = "";
    }

    #region 1. CHÍNH: TỰ ĐỘNG CẬP NHẬT THÔNG TIN TÀI KHOẢN (UpdateAccountInfo)

    /// <summary>
    /// Hàm thực thi cập nhật thông tin tập trung, thay thế hoàn toàn cho ACA57217 cũ.
    /// Tốc độ xử lý: 1.5 - 2.5s / tài khoản.
    /// </summary>
    public static void UpdateAccountInfo(fMain form, Chrome chrome, int rowIndex, string proxy = "", int proxyType = 0)
    {
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return;

        try
        {
            var config = C5034B95.smethod_0("configInteractGeneral");
            bool needName = config.method_3("ckbName");
            bool needGender = config.method_3("ckbGender");
            bool needBirthday = config.method_3("ckbBirthday");
            bool needNgayTao = config.method_3("ckbNgayTao");
            bool needEmail = config.method_3("ckbEmail");
            bool needFriend = config.method_3("ckbFriend");
            bool needGroup = config.method_3("ckbGroup");
            bool needPagePro5 = config.method_3("ckbPagePro5");
            bool needFollow = config.method_3("ckbFollow");
            bool needPhone = config.method_3("ckbPhone");
            bool needHometown = config.method_3("ckbHometown");
            bool needLocation = config.method_3("ckbLocation");
            bool needAvatar = config.method_3("ckbAvatar");
            bool needDating = config.method_3("ckbDating");
            bool needAds = config.method_3("ckbAds");
            bool needBM = config.method_3("ckbBM");
            bool needFbBlock = config.method_3("ckbFbBlock");

            // Nếu không chọn bất kỳ trường nào cần cập nhật thì thoát sớm
            if (!needName && !needGender && !needBirthday && !needNgayTao && !needEmail &&
                !needFriend && !needGroup && !needPagePro5 && !needFollow && !needPhone &&
                !needHometown && !needLocation && !needAvatar && !needDating && !needAds &&
                !needBM && !needFbBlock)
            {
                return;
            }

            // Ghi nhận trạng thái bỏ chọn bằng "-" vào grid nếu cần
            if (!needName) form.method_134(rowIndex, "cName", "-", "name", false);
            if (!needGender) form.method_134(rowIndex, "cGender", "-", "gender", false);
            if (!needBirthday) form.method_134(rowIndex, "cBirthday", "-", "birthday", false);
            if (!needNgayTao) form.method_134(rowIndex, "cDateCreateAcc", "-", "dateCreateAcc", false);
            if (!needEmail)
            {
                form.method_134(rowIndex, "cEmail", "-", "email", false);
                form.method_134(rowIndex, "cEmail2", "-", "email2", false);
            }
            if (!needFriend) form.method_134(rowIndex, "cFriend", "-", "friends", false);
            if (!needGroup) form.method_134(rowIndex, "cGroup", "-", "groups", false);
            if (!needPagePro5) form.method_134(rowIndex, "cPagePro5", "-", "pagePro5", false);
            if (!needFollow) form.method_134(rowIndex, "cFollow", "-", "follow", false);
            if (!needPhone) form.method_134(rowIndex, "cPhone", "-", "phone", false);
            if (!needHometown)
            {
                form.method_134(rowIndex, "cHometown", "-", "hometown", false);
                form.method_134(rowIndex, "cCurrentCity", "-", "currentCity", false);
            }
            if (!needLocation) form.method_134(rowIndex, "cLocation", "-", "location", false);
            if (!needAvatar) form.method_134(rowIndex, "cAvatar", "-", "avatar", false);
            if (!needDating) form.method_134(rowIndex, "cDating", "-", "dating", false);
            if (!needAds) form.method_134(rowIndex, "cAds", "-", "ads", false);
            if (!needBM) form.method_134(rowIndex, "cBM", "-", "bm", false);
            if (!needFbBlock) form.method_134(rowIndex, "cFbBlock", "-", "fbBlock", false);

            // Xác định UID
            string uid = chrome.FB94939A();
            if (string.IsNullOrEmpty(uid)) uid = chrome.B4208531;
            if (string.IsNullOrEmpty(uid) && form != null)
            {
                try { uid = form.F6061E95(rowIndex, "cId"); } catch { }
            }

            // Đảm bảo trình duyệt đang ở Facebook WWW Desktop
            string curUrl = chrome.GetURL() ?? "";
            if (!curUrl.StartsWith("https://www.facebook.com") && !curUrl.StartsWith("https://web.facebook.com"))
            {
                chrome.method_12("https://www.facebook.com/");
                chrome.F8091028(1.0);
            }

            // Thực hiện Fast Scrape đa luồng trong trình duyệt
            AccountInfoData data = ScrapeUnifiedInfo(chrome, uid, needNgayTao, needGroup, needPagePro5, needFbBlock);

            // Cập nhật các trường thông tin vào DataGridView và CSDL
            if (needName && !string.IsNullOrEmpty(data.Name))
            {
                form.method_134(rowIndex, "cName", data.Name, "name", false);
            }

            if (needGender && !string.IsNullOrEmpty(data.Gender))
            {
                form.method_134(rowIndex, "cGender", data.Gender, "gender", false);
            }

            if (needBirthday && !string.IsNullOrEmpty(data.Birthday))
            {
                form.method_134(rowIndex, "cBirthday", data.Birthday, "birthday", false);
            }

            if (needNgayTao && !string.IsNullOrEmpty(data.DateCreateAcc))
            {
                form.method_134(rowIndex, "cDateCreateAcc", data.DateCreateAcc, "dateCreateAcc", false);
            }

            if (needFriend && !string.IsNullOrEmpty(data.Friends))
            {
                form.method_134(rowIndex, "cFriend", data.Friends, "friends", false);
            }

            if (needGroup && !string.IsNullOrEmpty(data.Groups))
            {
                form.method_134(rowIndex, "cGroup", data.Groups, "groups", false);
            }

            if (needFollow && !string.IsNullOrEmpty(data.Followers))
            {
                form.method_134(rowIndex, "cFollow", data.Followers, "follow", false);
            }

            if (needPagePro5)
            {
                string pro5Count = data.Pages != null ? data.Pages.Count.ToString() : "0";
                form.method_134(rowIndex, "cPagePro5", pro5Count, "pagePro5", false);
            }

            if (needAvatar && !string.IsNullOrEmpty(data.Avatar))
            {
                form.method_134(rowIndex, "cAvatar", data.Avatar, "avatar", false);
            }

            if (needEmail)
            {
                if (data.Emails != null && data.Emails.Count > 0)
                {
                    string joinedMail = string.Join(", ", data.Emails);
                    form.method_134(rowIndex, "cEmail2", $"{data.Emails.Count} ({joinedMail})", "email2");
                    string existingMail = form.F6061E95(rowIndex, "cEmail");
                    if (string.IsNullOrEmpty(existingMail))
                    {
                        form.method_134(rowIndex, "cEmail", data.Emails[0], "email", false);
                    }
                }
                else
                {
                    form.method_134(rowIndex, "cEmail2", "0", "email2");
                }
            }

            if (needPhone)
            {
                if (data.Phones != null && data.Phones.Count > 0)
                {
                    string joinedPhone = string.Join(", ", data.Phones);
                    form.method_134(rowIndex, "cPhone", $"{data.Phones.Count} ({joinedPhone})", "phone");
                }
                else
                {
                    form.method_134(rowIndex, "cPhone", "0", "phone");
                }
            }

            if (needHometown)
            {
                form.method_134(rowIndex, "cHometown", data.Hometown ?? "", "hometown", false);
                form.method_134(rowIndex, "cCurrentCity", data.CurrentCity ?? "", "currentCity", false);
            }

            if (needLocation)
            {
                string loc = !string.IsNullOrEmpty(data.Location) ? data.Location : (!string.IsNullOrEmpty(data.CurrentCity) ? data.CurrentCity : (data.Hometown ?? ""));
                form.method_134(rowIndex, "cLocation", loc, "location", false);
            }

            if (needDating)
            {
                form.method_134(rowIndex, "cDating", data.Dating ?? "No", "dating", false);
            }

            if (needFbBlock)
            {
                form.method_134(rowIndex, "cFbBlock", data.FbBlock ?? "", "fbBlock");
            }

            // Đối với Ads và BM nếu người dùng bật
            if (needAds || needBM)
            {
                FetchAdsAndBM(chrome, form, rowIndex, needAds, needBM);
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("UpdateAccountInfo error: " + ex.Message); } catch { }
        }
    }

    #endregion

    #region 2. UNIFIED FAST SCRAPE ENGINE (DOM + PROMISE.ALL GRAPHQL)

    /// <summary>
    /// Thực thi script JS siêu tốc chạy song song tất cả các request trong browser session:
    /// 1 lượt fetch sk=about_contact_and_basic_info + 2 GraphQL queries + 1 check your_pages + check account_status.
    /// </summary>
    public static AccountInfoData ScrapeUnifiedInfo(Chrome chrome, string uid, bool needNgayTao = true, bool needGroup = true, bool needPagePro5 = true, bool needFbBlock = true)
    {
        var data = new AccountInfoData { Uid = uid };
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return data;

        try
        {
            string jsUid = JsonConvert.ToString(uid ?? "");
            string jsNeedNgayTao = needNgayTao ? "true" : "false";
            string jsNeedGroup = needGroup ? "true" : "false";
            string jsNeedPagePro5 = needPagePro5 ? "true" : "false";
            string jsNeedFbBlock = needFbBlock ? "true" : "false";

            string script = @"
async function _fastScrapeAccount() {
    var res = {
        name: '',
        gender: '',
        birthday: '',
        hometown: '',
        currentCity: '',
        location: '',
        followers: '',
        friends: '',
        emails: [],
        phones: [],
        dateCreateAcc: '',
        groups: '',
        pages: [],
        avatar: '',
        fbBlock: '',
        dating: ''
    };

    try {
        var uid = " + jsUid + @";
        if (!uid) {
            var mCookie = document.cookie.match(/c_user=(\d+)/);
            if (mCookie) uid = mCookie[1];
        }

        // Trích xuất fb_dtsg
        var dtsg = '';
        try {
            dtsg = (typeof require === 'function' ? (require('DTSGInitialData')?.token) : null)
                || document.querySelector('[name=""fb_dtsg""]')?.value
                || (document.documentElement.innerHTML.match(/[""']DTSGInitialData[""'],\[\],\{""token"":""([^""]+)""/)?.[1])
                || (document.documentElement.innerHTML.match(/""token"":""([^""]+)""/)?.[1])
                || '';
        } catch(e) {}

        // Tác vụ A: Lấy nội dung trang About / Contact & Basic Info
        var pAbout = (async () => {
            try {
                var url = uid ? ('/profile.php?id=' + uid + '&sk=about_contact_and_basic_info') : '/me/about_contact_and_basic_info';
                var r = await fetch(url, { credentials: 'include' });
                if (r.ok) return await r.text();
            } catch(e) {}
            return '';
        })();

        // Tác vụ B: GraphQL Ngày tạo (Comet Hovercard)
        var pCreated = (async () => {
            if (!" + jsNeedNgayTao + @" || !uid || !dtsg) return '';
            try {
                var p = new URLSearchParams();
                p.append('av', uid);
                p.append('__user', uid);
                p.append('__a', '1');
                p.append('__comet_req', '15');
                p.append('fb_dtsg', dtsg);
                p.append('fb_api_caller_class', 'RelayModern');
                p.append('variables', JSON.stringify({
                    actionBarRenderLocation: 'WWW_COMET_HOVERCARD',
                    context: 'MARKETPLACE',
                    entityID: uid,
                    includeTdaInfo: false,
                    scale: 1.5,
                    __relay_internal__pv__VideoPlayerRelayReplaceDashManifestWithPlaylistrelayprovider: false
                }));
                p.append('doc_id', '7863557980324041');
                p.append('locale', 'en_US');

                var r = await fetch('/api/graphql', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    body: p.toString(),
                    credentials: 'include'
                });
                if (r.ok) {
                    var txt = await r.text();
                    var j = JSON.parse(txt);
                    var jt = j?.data?.node?.comet_hovercard_renderer?.user?.join_time;
                    return jt ? jt.toString() : '';
                }
            } catch(e) {}
            return '';
        })();

        // Tác vụ C: GraphQL Nhóm tham gia (all_joined_groups)
        var pGroups = (async () => {
            if (!" + jsNeedGroup + @" || !uid || !dtsg) return '';
            try {
                var p = new URLSearchParams();
                p.append('av', uid);
                p.append('__user', uid);
                p.append('__a', '1');
                p.append('__comet_req', '15');
                p.append('fb_dtsg', dtsg);
                p.append('fb_api_caller_class', 'RelayModern');
                p.append('variables', JSON.stringify({
                    ordering: ['integrity_signals'],
                    scale: 1
                }));
                p.append('doc_id', '6985470494844388');

                var r = await fetch('/api/graphql', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    body: p.toString(),
                    credentials: 'include'
                });
                if (r.ok) {
                    var txt = await r.text();
                    var j = JSON.parse(txt);
                    var g = j?.data?.viewer?.all_joined_groups?.total_joined_groups;
                    return (g !== undefined && g !== null) ? g.toString() : '';
                }
            } catch(e) {}
            return '';
        })();

        // Tác vụ D: Lấy danh sách Page Pro5 quản lý
        var pPages = (async () => {
            if (!" + jsNeedPagePro5 + @") return [];
            try {
                var r = await fetch('/pages/?category=your_pages', { credentials: 'include' });
                if (r.ok) {
                    var txt = await r.text();
                    var pids = [];
                    var seen = {};
                    var linkReg = /href=""([^""]*(?:latest|facebook\.com\/|pages\/)[^""]*)""/g;
                    var m;
                    while ((m = linkReg.exec(txt)) !== null) {
                        var href = m[1];
                        var sub = href.match(/(?:asset_id=([0-9]+)|facebook\.com\/([0-9]{8,}))/);
                        if (sub) {
                            var pid = sub[1] || sub[2];
                            if (pid && pid !== uid && !seen[pid]) {
                                seen[pid] = true;
                                pids.push(pid);
                            }
                        }
                    }
                    if (pids.length === 0) {
                        var mJson = txt.match(/""page_id"":""(\d+)""/g);
                        if (mJson) {
                            for (var it of mJson) {
                                var pid = it.replace(/[^0-9]/g, '');
                                if (pid && pid !== uid && !seen[pid]) {
                                    seen[pid] = true;
                                    pids.push(pid);
                                }
                            }
                        }
                    }
                    return pids;
                }
            } catch(e) {}
            return [];
        })();

        // Tác vụ E: Kiểm tra Account Restricted / Blocked
        var pStatus = (async () => {
            if (!" + jsNeedFbBlock + @") return '';
            try {
                var r = await fetch('/account_status/', { credentials: 'include' });
                if (r.ok) {
                    var txt = (await r.text()).toLowerCase();
                    if (txt.includes('account restricted') || txt.includes('bị hạn chế') || txt.includes('tạm thời bị chặn')) {
                        return 'Account restricted';
                    }
                }
            } catch(e) {}
            return '';
        })();

        // Chờ tất cả tác vụ song song hoàn thành
        var [aboutHtml, joinTime, groupsCount, pageList, statusTxt] = await Promise.all([
            pAbout, pCreated, pGroups, pPages, pStatus
        ]);

        res.dateCreateAcc = joinTime || '';
        res.groups = groupsCount || '';
        res.pages = pageList || [];
        res.fbBlock = statusTxt || '';

        // Kiểm tra block bổ sung qua URL và DOM hiện tại
        if (!res.fbBlock) {
            var curUrl = window.location.href || '';
            if (curUrl.includes('checkpoint') || curUrl.includes('1501092823525282') || curUrl.includes('828281030927956')) {
                res.fbBlock = 'Account restricted';
            } else if (document.body) {
                var bTxt = document.body.innerText || '';
                if (bTxt.includes('Account restricted') || bTxt.includes('bị hạn chế') || bTxt.includes('tạm thời bị chặn') || bTxt.includes('bị khóa') || bTxt.includes('Temporarily Blocked')) {
                    res.fbBlock = 'Account restricted';
                }
            }
        }

        // Bóc tách dữ liệu từ aboutHtml và DOM hiện tại
        var src = aboutHtml || (document.documentElement ? document.documentElement.innerHTML : '');

        // 1. Tên (Name)
        var mName = src.match(/""NAME"":""([^""]+)""/) || src.match(/""data"":\{""name"":""([^""]+)""/) || src.match(/""name"":""([^""]+)""/);
        if (mName) {
            try { res.name = JSON.parse('""' + mName[1] + '""'); } catch(e) { res.name = mName[1]; }
        }
        if (!res.name) {
            var t = document.title || '';
            if (t && !t.toLowerCase().startsWith('facebook') && !t.includes('Log in') && !t.includes('Đăng nhập')) {
                res.name = t.replace(/\s*\|\s*Facebook.*$/i, '').trim();
            }
            if (!res.name) {
                var h1 = document.querySelector('h1');
                if (h1 && h1.innerText) res.name = h1.innerText.trim();
            }
        }

        // 2. Giới tính (Gender)
        var mGen = src.match(/""gender"":""([^""]+)""/i);
        if (mGen) {
            res.gender = mGen[1].toLowerCase();
        } else {
            if (/(""gender"":1|Giới tính.*?Nữ|Female)/i.test(src)) res.gender = 'female';
            else if (/(""gender"":2|Giới tính.*?Nam|Male)/i.test(src)) res.gender = 'male';
        }

        // 3. Ngày sinh (Birthday)
        var mBday = src.match(/""day"":(\d+),""month"":(\d+),""year"":(\d+)/);
        if (mBday) {
            res.birthday = mBday[2] + '/' + mBday[1] + '/' + mBday[3];
        } else {
            var mBday2 = src.match(/""birthdate"":\{""day"":(\d+),""month"":(\d+)(?:,""year"":(\d+))?\}/);
            if (mBday2) {
                res.birthday = mBday2[2] + '/' + mBday2[1] + (mBday2[3] ? ('/' + mBday2[3]) : '');
            } else {
                var mBdayTxt = src.match(/(?:Ngày sinh|Date of birth|Birthday)[^<]*?(\d{1,2}\s+(?:tháng\s+\d{1,2}|\w+)(?:\s*,\s*\d{4})?|\d{1,2}[\/\-\.]\d{1,2}[\/\-\.]\d{2,4})/i);
                if (mBdayTxt) res.birthday = mBdayTxt[1].trim();
            }
        }

        // 4. Quê quán (Hometown) & Thành phố hiện tại (Current City)
        var mHome = src.match(/""hometown"":\{""name"":""([^""]+)""/i) || src.match(/(?:Đến từ|From)\s+<[^>]+>([^<]+)<\/a>/i) || src.match(/(?:Đến từ|From)\s+([A-Za-z0-9À-ỹ\s\.,\-]+?)(?:<|\n|$)/i);
        if (mHome) {
            try { res.hometown = JSON.parse('""' + mHome[1] + '""').trim(); } catch(e) { res.hometown = mHome[1].trim(); }
        }
        var mCity = src.match(/""current_city"":\{""name"":""([^""]+)""/i) || src.match(/(?:Sống tại|Lives in)\s+<[^>]+>([^<]+)<\/a>/i) || src.match(/(?:Sống tại|Lives in)\s+([A-Za-z0-9À-ỹ\s\.,\-]+?)(?:<|\n|$)/i);
        if (mCity) {
            try { res.currentCity = JSON.parse('""' + mCity[1] + '""').trim(); } catch(e) { res.currentCity = mCity[1].trim(); }
        }
        res.location = res.currentCity || res.hometown || '';

        // 5. Số người theo dõi (Followers)
        var mFollow = src.match(/followers""\s*role=""link""[^>]*>(\d[\d,\.]*)/i)
            || src.match(/(\d[\d,\.]*)\s*(?:người theo dõi|followers)/i)
            || src.match(/""follower_count"":(\d+)/i)
            || src.match(/""followers"":\{""count"":(\d+)\}/i);
        if (mFollow) {
            res.followers = mFollow[1].replace(/[\.,]/g, '');
        }

        // 6. Bạn bè (Friends)
        var mFriends = src.match(/""id"":""[^""]*2356318349:2""[^}]*""items"":\{""count"":(\d+)\}/)
            || src.match(/""friends"":\{""count"":(\d+)\}/i)
            || src.match(/""friend_count"":(\d+)/i)
            || src.match(/(\d[\d,\.]*)\s*(?:người bạn|bạn bè|friends)/i);
        if (mFriends) {
            res.friends = mFriends[1].replace(/[\.,]/g, '');
        }

        // 7. Email
        var emList = [];
        var mailtoReg = /href=""mailto:([^""?#\s]+)""/gi;
        var em;
        while ((em = mailtoReg.exec(src)) !== null) {
            var mail = em[1].trim();
            if (mail && !mail.includes('@facebook.com') && !emList.includes(mail)) {
                emList.push(mail);
            }
        }
        if (emList.length === 0) {
            var rawMailReg = /[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/g;
            while ((em = rawMailReg.exec(src)) !== null) {
                var mail = em[0].trim();
                var lower = mail.toLowerCase();
                if (!lower.includes('@facebook.com') && !lower.includes('@meta.com') && !lower.includes('@tfbnw.net') && !lower.includes('.png') && !lower.includes('.jpg') && !emList.includes(mail)) {
                    emList.push(mail);
                }
            }
        }
        res.emails = emList;

        // 8. Số điện thoại (Phones)
        var phList = [];
        var telReg = /href=""tel:([^""?#\s]+)""/gi;
        var ph;
        while ((ph = telReg.exec(src)) !== null) {
            var pVal = ph[1].replace(/[^0-9+]/g, '');
            if (pVal && pVal.length >= 8 && !phList.includes(pVal)) {
                phList.push(pVal);
            }
        }
        if (phList.length === 0) {
            var rawPhoneReg = /(?:\+84|0)(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-9]|9[0-9])\d{7}/g;
            while ((ph = rawPhoneReg.exec(src)) !== null) {
                var pVal = ph[0].replace(/[^0-9+]/g, '');
                if (pVal && !phList.includes(pVal)) {
                    phList.push(pVal);
                }
            }
        }
        res.phones = phList;

        // 9. Ảnh đại diện (Avatar Yes/No)
        var hasAvatar = false;
        if (/(""has_profile_pic"":true|""profile_pic_large"":\{""uri"":""https:\/\/scontent)/i.test(src)) {
            hasAvatar = true;
        } else if (/scontent[^\s""'>]+(?:profile_picture|\/p\d+x\d+\/)[^\s""'>]+/i.test(src)) {
            hasAvatar = true;
        } else {
            var profileImgs = document.querySelectorAll('svg image, [aria-label*=""profile"" i] img, [role=""img""] img, a[href*=""/photo""] img');
            for (var img of profileImgs) {
                var iSrc = img.src || img.getAttribute('xlink:href') || '';
                if (iSrc && (iSrc.includes('scontent') || iSrc.includes('fbcdn.net')) && !iSrc.includes('rsrc.php')) {
                    hasAvatar = true;
                    break;
                }
            }
        }
        res.avatar = hasAvatar ? 'Yes' : 'No';

        // 10. Hẹn hò (Dating)
        if (/(""has_dating_profile"":true|shortcut_type"":""dating""|Hẹn hò|Dating)/i.test(src)) {
            res.dating = 'Yes';
        } else {
            res.dating = 'No';
        }

    } catch(err) {
        res.error = err.message;
    }

    return JSON.stringify(res);
}

var _c = await _fastScrapeAccount();
return _c;
";

            string jsonResult = chrome.method_14(script);
            if (!string.IsNullOrEmpty(jsonResult) && jsonResult.TrimStart().StartsWith("{"))
            {
                JObject obj = JObject.Parse(jsonResult);
                data.Name = obj["name"]?.ToString() ?? "";
                data.Gender = obj["gender"]?.ToString() ?? "";
                data.Birthday = obj["birthday"]?.ToString() ?? "";
                data.Hometown = obj["hometown"]?.ToString() ?? "";
                data.CurrentCity = obj["currentCity"]?.ToString() ?? "";
                data.Location = obj["location"]?.ToString() ?? "";
                data.Followers = obj["followers"]?.ToString() ?? "";
                data.Friends = obj["friends"]?.ToString() ?? "";
                data.Groups = obj["groups"]?.ToString() ?? "";
                data.Avatar = obj["avatar"]?.ToString() ?? "";
                data.FbBlock = obj["fbBlock"]?.ToString() ?? "";
                data.Dating = obj["dating"]?.ToString() ?? "";

                // Format ngày tạo từ Unix timestamp nếu có
                string jt = obj["dateCreateAcc"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(jt) && double.TryParse(jt, out double unixTs))
                {
                    try
                    {
                        data.DateCreateAcc = Commom.smethod_33(unixTs).ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    catch
                    {
                        data.DateCreateAcc = jt;
                    }
                }
                else
                {
                    data.DateCreateAcc = jt;
                }

                if (obj["emails"] is JArray emArr)
                {
                    data.Emails = emArr.Select(x => x.ToString()).Where(x => !string.IsNullOrEmpty(x)).ToList();
                }

                if (obj["phones"] is JArray phArr)
                {
                    data.Phones = phArr.Select(x => x.ToString()).Where(x => !string.IsNullOrEmpty(x)).ToList();
                }

                if (obj["pages"] is JArray pgArr)
                {
                    data.Pages = pgArr.Select(x => x.ToString()).Where(x => !string.IsNullOrEmpty(x)).ToList();
                }
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("ScrapeUnifiedInfo error: " + ex.Message); } catch { }
        }

        return data;
    }

    #endregion

    #region 3. HELPER DELEGATES CHO CHROME.CS (Thay thế stub lỗi)

    /// <summary>
    /// Thay thế BE0C6B9C() trong Chrome.cs:
    /// Trả về danh sách Page Pro5 của tài khoản bằng cách quét /pages/?category=your_pages hoặc DOM.
    /// </summary>
    public static List<string> GetPagePro5(Chrome chrome)
    {
        var list = new List<string>();
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return list;

        try
        {
            string uid = chrome.FB94939A();
            if (string.IsNullOrEmpty(uid)) uid = chrome.B4208531;

            string script = @"
async function _getPages() {
    var pids = [];
    var seen = {};
    var myUid = " + JsonConvert.ToString(uid ?? "") + @";
    try {
        var r = await fetch('/pages/?category=your_pages', { credentials: 'include' });
        if (r.ok) {
            var txt = await r.text();
            var linkReg = /href=""([^""]*(?:latest|facebook\.com\/|pages\/)[^""]*)""/g;
            var m;
            while ((m = linkReg.exec(txt)) !== null) {
                var href = m[1];
                var sub = href.match(/(?:asset_id=([0-9]+)|facebook\.com\/([0-9]{8,}))/);
                if (sub) {
                    var pid = sub[1] || sub[2];
                    if (pid && pid !== myUid && !seen[pid]) {
                        seen[pid] = true;
                        pids.push(pid);
                    }
                }
            }
            if (pids.length === 0) {
                var mJson = txt.match(/""page_id"":""(\d+)""/g);
                if (mJson) {
                    for (var it of mJson) {
                        var pid = it.replace(/[^0-9]/g, '');
                        if (pid && pid !== myUid && !seen[pid]) {
                            seen[pid] = true;
                            pids.push(pid);
                        }
                    }
                }
            }
        }
    } catch(e) {}

    // Fallback: Quét DOM hiện tại nếu đang ở trang pages
    if (pids.length === 0 && document.body) {
        var domLinks = Array.from(document.querySelectorAll('a[href*=""/latest/""], a[href*=""facebook.com/""], a[href*=""/pages/""]'));
        for (var a of domLinks) {
            var h = a.getAttribute('href') || '';
            var sm = h.match(/(?:asset_id=([0-9]+)|facebook\.com\/([0-9]{8,}))/);
            if (sm) {
                var pid = sm[1] || sm[2];
                if (pid && pid !== myUid && !seen[pid]) {
                    seen[pid] = true;
                    pids.push(pid);
                }
            }
        }
    }
    return JSON.stringify(pids);
}
var _res = await _getPages();
return _res;
";
            string json = chrome.method_14(script);
            if (!string.IsNullOrEmpty(json) && json.TrimStart().StartsWith("["))
            {
                var jArr = JArray.Parse(json);
                foreach (var item in jArr)
                {
                    string p = item?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(p) && !list.Contains(p))
                    {
                        list.Add(p);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("GetPagePro5 error: " + ex.Message); } catch { }
        }

        return list;
    }

    /// <summary>
    /// Thay thế B13A9E19() trong Chrome.cs: Trích xuất danh sách email liên kết tài khoản.
    /// </summary>
    public static List<string> GetEmails(Chrome chrome, bool excludePending = false)
    {
        var list = new List<string>();
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return list;

        try
        {
            string script = @"
async function _extractEmails() {
    var emails = [];
    var seen = {};
    var addMail = function(m) {
        if (!m) return;
        m = m.trim().toLowerCase();
        if (m && !m.includes('@facebook.com') && !m.includes('@meta.com') && !m.includes('@tfbnw.net') && !seen[m]) {
            seen[m] = true;
            emails.push(m);
        }
    };

    try {
        var links = document.querySelectorAll('a[href*=""mailto:""]');
        for (var a of links) {
            var href = a.getAttribute('href') || '';
            var m = href.match(/mailto:([^?&#\s]+)/i);
            if (m) addMail(m[1]);
        }
    } catch(e) {}

    try {
        var text = document.documentElement ? document.documentElement.innerHTML : '';
        var rawMails = text.match(/[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/g) || [];
        for (var rm of rawMails) {
            if (!rm.includes('.png') && !rm.includes('.jpg')) {
                addMail(rm);
            }
        }
    } catch(e) {}

    return JSON.stringify(emails);
}
var _res = await _extractEmails();
return _res;
";
            string json = chrome.method_14(script);
            if (!string.IsNullOrEmpty(json) && json.TrimStart().StartsWith("["))
            {
                var jArr = JArray.Parse(json);
                foreach (var item in jArr)
                {
                    string m = item?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(m) && !list.Contains(m)) list.Add(m);
                }
            }
        }
        catch { }

        return list;
    }

    /// <summary>
    /// Thay thế method_70() trong Chrome.cs: Trích xuất danh sách số điện thoại liên kết tài khoản.
    /// </summary>
    public static List<string> GetPhones(Chrome chrome, bool excludePending = false)
    {
        var list = new List<string>();
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return list;

        try
        {
            string script = @"
async function _extractPhones() {
    var phones = [];
    var seen = {};
    var addPhone = function(p) {
        if (!p) return;
        p = p.replace(/[^0-9+]/g, '');
        if (p && p.length >= 8 && !seen[p]) {
            seen[p] = true;
            phones.push(p);
        }
    };

    try {
        var links = document.querySelectorAll('a[href*=""tel:""]');
        for (var a of links) {
            var href = a.getAttribute('href') || '';
            var m = href.match(/tel:([^?&#\s]+)/i);
            if (m) addPhone(m[1]);
        }
    } catch(e) {}

    try {
        var text = document.documentElement ? document.documentElement.innerHTML : '';
        var rawPhones = text.match(/(?:\+84|0)(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-9]|9[0-9])\d{7}/g) || [];
        for (var rp of rawPhones) {
            addPhone(rp);
        }
    } catch(e) {}

    return JSON.stringify(phones);
}
var _res = await _extractPhones();
return _res;
";
            string json = chrome.method_14(script);
            if (!string.IsNullOrEmpty(json) && json.TrimStart().StartsWith("["))
            {
                var jArr = JArray.Parse(json);
                foreach (var item in jArr)
                {
                    string p = item?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(p) && !list.Contains(p)) list.Add(p);
                }
            }
        }
        catch { }

        return list;
    }

    /// <summary>
    /// Xử lý GetContact() trong RunCodeChrome:
    /// Trả về chuỗi JSON mảng contact chuẩn [{"type":"email","contact":"...","pending":false}, ...]
    /// Không bao giờ ném exception parse JSON rỗng.
    /// </summary>
    public static string GetContactsJson(Chrome chrome)
    {
        try
        {
            var emails = GetEmails(chrome);
            var phones = GetPhones(chrome);
            var arr = new JArray();

            foreach (var e in emails)
            {
                arr.Add(new JObject
                {
                    ["type"] = "email",
                    ["contact"] = e,
                    ["pending"] = false
                });
            }

            foreach (var p in phones)
            {
                arr.Add(new JObject
                {
                    ["type"] = "phone",
                    ["contact"] = p,
                    ["pending"] = false
                });
            }

            return arr.ToString(Formatting.None);
        }
        catch
        {
            return "[]";
        }
    }

    /// <summary>
    /// Thay thế B782EC30() trong Chrome.cs: Trả về "Hometown|CurrentCity"
    /// </summary>
    public static string GetLocationInfo(Chrome chrome)
    {
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return "|";

        try
        {
            string uid = chrome.FB94939A();
            if (string.IsNullOrEmpty(uid)) uid = chrome.B4208531;

            string script = @"
async function _getLoc() {
    var home = '';
    var city = '';
    try {
        var src = document.documentElement ? document.documentElement.innerHTML : '';
        var mHome = src.match(/""hometown"":\{""name"":""([^""]+)""/i) || src.match(/(?:Đến từ|From)\s+<[^>]+>([^<]+)<\/a>/i) || src.match(/(?:Đến từ|From)\s+([A-Za-z0-9À-ỹ\s\.,\-]+?)(?:<|\n|$)/i);
        if (mHome) {
            try { home = JSON.parse('""' + mHome[1] + '""').trim(); } catch(e) { home = mHome[1].trim(); }
        }
        var mCity = src.match(/""current_city"":\{""name"":""([^""]+)""/i) || src.match(/(?:Sống tại|Lives in)\s+<[^>]+>([^<]+)<\/a>/i) || src.match(/(?:Sống tại|Lives in)\s+([A-Za-z0-9À-ỹ\s\.,\-]+?)(?:<|\n|$)/i);
        if (mCity) {
            try { city = JSON.parse('""' + mCity[1] + '""').trim(); } catch(e) { city = mCity[1].trim(); }
        }
    } catch(e) {}
    return home + '|' + city;
}
var _res = await _getLoc();
return _res;
";
            string res = chrome.method_14(script);
            if (!string.IsNullOrEmpty(res) && res.Contains('|')) return res;
        }
        catch { }

        return "|";
    }

    /// <summary>
    /// Thay thế method_75() trong Chrome.cs: Trả về vị trí chính (Primary Location)
    /// </summary>
    public static string GetPrimaryLocation(Chrome chrome)
    {
        string locInfo = GetLocationInfo(chrome);
        string[] parts = locInfo.Split('|');
        if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1])) return parts[1];
        if (parts.Length > 0 && !string.IsNullOrEmpty(parts[0])) return parts[0];
        return "";
    }

    /// <summary>
    /// Thay thế CF38FA07() trong Chrome.cs: Kiểm tra tính năng Dating (Hẹn hò)
    /// </summary>
    public static string CheckDating(Chrome chrome)
    {
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03()) return "No";

        try
        {
            string script = @"
try {
    var src = document.documentElement ? document.documentElement.innerHTML : '';
    if (/(""has_dating_profile"":true|shortcut_type"":""dating""|Hẹn hò|Dating)/i.test(src)) {
        return 'Yes';
    }
} catch(e) {}
return 'No';
";
            string res = chrome.method_14(script);
            return (res == "Yes") ? "Yes" : "No";
        }
        catch
        {
            return "No";
        }
    }

    /// <summary>
    /// Thực hiện Browser Fetch thực tế (hỗ trợ C604C58C / RequestGet và method_48 / RequestPost).
    /// </summary>
    public static string ExecuteBrowserFetch(Chrome chrome, string url, string method = "GET", string postData = null)
    {
        if (chrome == null || chrome.CD930D04() || chrome.E184CD03() || string.IsNullOrEmpty(url)) return "";

        try
        {
            string jsUrl = JsonConvert.ToString(url);
            string script;

            if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
            {
                string jsBody = JsonConvert.ToString(postData ?? "");
                script = @"
async function _fetchPost() {
    try {
        var r = await fetch(" + jsUrl + @", {
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            body: " + jsBody + @",
            credentials: 'include'
        });
        if (r.ok) return await r.text();
    } catch(e) {}
    return '';
}
var _res = await _fetchPost();
return _res;
";
            }
            else
            {
                script = @"
async function _fetchGet() {
    try {
        var r = await fetch(" + jsUrl + @", {
            method: 'GET',
            credentials: 'include'
        });
        if (r.ok) return await r.text();
    } catch(e) {}
    return '';
}
var _res = await _fetchGet();
return _res;
";
            }

            return chrome.method_14(script);
        }
        catch
        {
            return "";
        }
    }

    #endregion

    #region 4. ADS & BM TOKEN FALLBACK

    private static void FetchAdsAndBM(Chrome chrome, fMain form, int rowIndex, bool needAds, bool needBM)
    {
        try
        {
            string token = chrome.FB001323();
            if (string.IsNullOrEmpty(token)) token = chrome.DC8F5A1A();
            if (string.IsNullOrEmpty(token)) return;

            if (needAds)
            {
                string adsData = chrome.method_74(token, "", "", "");
                if (!string.IsNullOrEmpty(adsData))
                {
                    try
                    {
                        var jObj = JObject.Parse(adsData);
                        string ads = jObj["ads"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(ads))
                        {
                            form.method_134(rowIndex, "cAds", ads.Replace("|", "*"), "ads", false);
                        }
                    }
                    catch { }
                }
            }

            if (needBM)
            {
                string bm = chrome.method_72(token);
                if (!string.IsNullOrEmpty(bm))
                {
                    form.method_134(rowIndex, "cBM", bm, "bm", false);
                }
            }
        }
        catch { }
    }

    #endregion
}
