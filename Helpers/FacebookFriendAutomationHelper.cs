using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// FacebookFriendAutomationHelper (Comet 2026 Engine):
/// 1. Tự động thu hồi lời mời kết bạn treo (CancelPendingSentRequests) chống trần 1.000 lời mời treo & chặn quét spam kết bạn.
/// 2. Lọc và hủy kết bạn bạn bè ảo, tài khoản die/checkpoint (UnfriendInactiveAccounts) qua Comet UI 2026 & GraphQL RelayModern.
/// 3. Hỗ trợ tích hợp kịch bản, menu ngữ cảnh tài khoản và FacebookActionsHub.
/// </summary>
public static class FacebookFriendAutomationHelper
{
    private static readonly Random _rand = new Random();

    #region 1. Thu Hồi Lời Mời Kết Bạn Treo (CancelPendingSentRequests)

    /// <summary>
    /// Điều hướng đến trang lời mời kết bạn đã gửi (outgoing sent requests),
    /// nhận diện các nút 'Hủy yêu cầu' / 'Cancel request' theo Comet 2026 selectors
    /// và thực hiện click hủy dứt khoát kèm delay ngẫu nhiên an toàn.
    /// </summary>
    public static int CancelPendingSentRequests(
        Chrome chrome,
        int maxCancelCount = 50,
        int delayMinSec = 1,
        int delayMaxSec = 3,
        Action<string> logCallback = null)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null)
        {
            logCallback?.Invoke("Chrome instance hoặc ChromeDriver chưa được khởi tạo.");
            return 0;
        }

        if (maxCancelCount <= 0) maxCancelCount = 50;
        if (delayMinSec < 0) delayMinSec = 1;
        if (delayMaxSec < delayMinSec) delayMaxSec = delayMinSec + 2;

        int totalCancelled = 0;

        try
        {
            logCallback?.Invoke("Đang mở trang danh sách lời mời kết bạn đã gửi (outgoing)...");

            // Điều hướng thẳng vào tab lời mời đã gửi (outgoing=1) Comet 2026
            chrome.method_12("https://www.facebook.com/friends/requests/?outgoing=1");
            chrome.F8091028(3.0);

            // Kiểm tra và click 'Xem lời mời đã gửi' (View sent requests) nếu Facebook mở trang requests chung
            string jsOpenSent = @"(() => {
                try {
                    var links = document.querySelectorAll('a, [role=""button""], span');
                    for (var el of links) {
                        var text = (el.innerText || el.textContent || '').trim().toLowerCase();
                        if (text.includes('xem lời mời đã gửi') || text.includes('view sent requests')) {
                            el.click();
                            return 'clicked_view_sent';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error:' + e.message; }
            })()";

            string openRes = chrome.method_14(jsOpenSent);
            if (openRes == "clicked_view_sent")
            {
                chrome.F8091028(2.0);
            }

            int consecutiveNoButton = 0;
            const int maxConsecutiveScrolls = 6;

            while (totalCancelled < maxCancelCount)
            {
                if (Base.smethod_5() || chrome.CD930D04())
                {
                    logCallback?.Invoke("Người dùng dừng tác vụ hoặc trình duyệt đã đóng.");
                    break;
                }

                // JS Tìm và click nút Hủy yêu cầu / Cancel request Comet 2026
                string jsCancelNext = @"(() => {
                    try {
                        // 1. Selector Comet 2026 chuẩn xác
                        var selectors = [
                            'div[aria-label*=""Hủy yêu cầu"" i][role=""button""]',
                            'div[aria-label*=""Hủy lời mời"" i][role=""button""]',
                            'div[aria-label*=""Cancel request"" i][role=""button""]',
                            'div[aria-label*=""Hủy yêu cầu"" i]',
                            'div[aria-label*=""Hủy lời mời"" i]',
                            'div[aria-label*=""Cancel request"" i]',
                            'button[aria-label*=""Hủy yêu cầu"" i]',
                            'button[aria-label*=""Hủy lời mời"" i]',
                            'button[aria-label*=""Cancel request"" i]',
                            '[role=""button""][aria-label*=""Hủy"" i]',
                            '[role=""button""][aria-label*=""Cancel"" i]'
                        ];

                        for (var sel of selectors) {
                            var elements = document.querySelectorAll(sel);
                            for (var el of elements) {
                                if (el.getAttribute('data-lc-cancel-done') === '1') continue;
                                var rect = el.getBoundingClientRect();
                                if (rect.width === 0 && rect.height === 0) continue;

                                el.setAttribute('data-lc-cancel-done', '1');
                                el.scrollIntoView({ behavior: 'smooth', block: 'center' });

                                try {
                                    el.click();
                                } catch(ex) {
                                    var evt = new MouseEvent('click', { bubbles: true, cancelable: true, view: window });
                                    el.dispatchEvent(evt);
                                }
                                return 'clicked';
                            }
                        }

                        // 2. Fallback tìm theo text nội dung nút
                        var allBtns = document.querySelectorAll('[role=""button""], button');
                        for (var b of allBtns) {
                            if (b.getAttribute('data-lc-cancel-done') === '1') continue;
                            var txt = (b.innerText || b.textContent || '').trim().toLowerCase();
                            if (txt === 'hủy yêu cầu' || txt === 'hủy lời mời' || txt === 'hủy' ||
                                txt === 'cancel request' || txt === 'cancel') {
                                var rect2 = b.getBoundingClientRect();
                                if (rect2.width === 0 && rect2.height === 0) continue;

                                b.setAttribute('data-lc-cancel-done', '1');
                                b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                try {
                                    b.click();
                                } catch(ex) {
                                    var evt = new MouseEvent('click', { bubbles: true, cancelable: true, view: window });
                                    b.dispatchEvent(evt);
                                }
                                return 'clicked';
                            }
                        }

                        return 'none';
                    } catch(e) { return 'error:' + e.message; }
                })()";

                string clickResult = chrome.method_14(jsCancelNext);

                if (clickResult == "clicked")
                {
                    consecutiveNoButton = 0;
                    chrome.F8091028(0.8);

                    // Xử lý modal xác nhận nếu có (Hủy yêu cầu / Xác nhận)
                    string jsConfirmModal = @"(() => {
                        try {
                            var dialogs = document.querySelectorAll('div[role=""dialog""]');
                            if (!dialogs || dialogs.length === 0) return 'no_dialog';
                            var dlg = dialogs[dialogs.length - 1];
                            var btns = dlg.querySelectorAll('[role=""button""], button');
                            for (var btn of btns) {
                                var a = (btn.getAttribute('aria-label') || '').toLowerCase();
                                var t = (btn.innerText || btn.textContent || '').trim().toLowerCase();
                                if (t === 'đóng' || t === 'close' || t === 'không' || t === 'no') continue;
                                if (a.includes('xác nhận') || a.includes('confirm') || a.includes('hủy') || a.includes('cancel') ||
                                    t.includes('xác nhận') || t.includes('confirm') || t.includes('hủy') || t.includes('cancel')) {
                                    btn.click();
                                    return 'modal_confirmed';
                                }
                            }
                            return 'no_confirm_button';
                        } catch(e) { return 'modal_error:' + e.message; }
                    })()";

                    chrome.method_14(jsConfirmModal);

                    totalCancelled++;
                    logCallback?.Invoke($"Đã hủy {totalCancelled}/{maxCancelCount} lời mời kết bạn treo");

                    if (totalCancelled < maxCancelCount)
                    {
                        int delayMs = _rand.Next(delayMinSec * 1000, (delayMaxSec + 1) * 1000);
                        Thread.Sleep(delayMs);
                    }
                }
                else
                {
                    // Cuộn xuống để nạp thêm lời mời kết bạn treo từ virtual feed
                    consecutiveNoButton++;
                    logCallback?.Invoke($"Đang cuộn tìm thêm lời mời kết bạn (lần {consecutiveNoButton}/{maxConsecutiveScrolls})...");

                    chrome.method_14(@"(() => {
                        try {
                            var containers = document.querySelectorAll('[role=""feed""], [data-pagelet*=""Requests""], div[style*=""overflow""]');
                            for (var c of containers) {
                                if (c.scrollHeight > c.clientHeight) {
                                    c.scrollTop += 800;
                                    return;
                                }
                            }
                            window.scrollBy(0, 800);
                        } catch(e) {}
                    })()");

                    chrome.F8091028(2.0);

                    if (consecutiveNoButton >= maxConsecutiveScrolls)
                    {
                        logCallback?.Invoke("Không còn lời mời kết bạn treo nào khác.");
                        break;
                    }
                }
            }

            logCallback?.Invoke($"Hoàn tất thu hồi lời mời kết bạn treo: {totalCancelled}/{maxCancelCount} lời mời.");
        }
        catch (Exception ex)
        {
            logCallback?.Invoke($"Lỗi trong quá trình thu hồi lời mời kết bạn: {ex.Message}");
        }

        return totalCancelled;
    }

    /// <summary>
    /// Overload hỗ trợ tương tác với giao diện fMain: cập nhật dòng tài khoản trực tiếp.
    /// </summary>
    public static int CancelPendingSentRequests(
        fMain mainForm,
        int rowIndex,
        string accPrefix,
        Chrome chrome,
        int maxCancelCount = 50,
        int delayMinSec = 1,
        int delayMaxSec = 3)
    {
        return CancelPendingSentRequests(
            chrome,
            maxCancelCount,
            delayMinSec,
            delayMaxSec,
            msg => mainForm?.method_130(rowIndex, $"{accPrefix}: {msg}")
        );
    }

    #endregion

    #region 2. Lọc Bạn Bè Ảo & Hủy Kết Bạn Nick Die (UnfriendInactiveAccounts)

    /// <summary>
    /// Hủy kết bạn với danh sách tài khoản đã chết/die (xác định qua FastCheckAccountStatus trước đó)
    /// mà không cần vào tường từng nick một. Hỗ trợ hủy nhanh qua Comet GraphQL RelayModern
    /// và fallback Comet Friend Menu 2026.
    /// </summary>
    public static int UnfriendInactiveAccounts(
        Chrome chrome,
        List<string> deadFriendUids,
        int maxUnfriendCount = 30,
        Action<string> logCallback = null)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null)
        {
            logCallback?.Invoke("Chrome instance hoặc ChromeDriver chưa được khởi tạo.");
            return 0;
        }

        if (deadFriendUids == null || deadFriendUids.Count == 0)
        {
            logCallback?.Invoke("Danh sách UID bạn bè ảo/die rỗng.");
            return 0;
        }

        if (maxUnfriendCount <= 0) maxUnfriendCount = 30;

        // Lọc danh sách UID hợp lệ, loại bỏ trùng lặp
        List<string> cleanUids = deadFriendUids
            .Where(u => !string.IsNullOrWhiteSpace(u))
            .Select(u => Regex.Match(u.Trim(), @"\d{6,}").Value)
            .Where(u => !string.IsNullOrEmpty(u))
            .Distinct()
            .ToList();

        if (cleanUids.Count == 0)
        {
            logCallback?.Invoke("Không có UID hợp lệ trong danh sách cung cấp.");
            return 0;
        }

        int totalUnfriended = 0;
        int targetCount = Math.Min(cleanUids.Count, maxUnfriendCount);
        logCallback?.Invoke($"Bắt đầu hủy kết bạn {targetCount} tài khoản ảo/die...");

        foreach (string targetUid in cleanUids)
        {
            if (totalUnfriended >= maxUnfriendCount) break;
            if (Base.smethod_5() || chrome.CD930D04())
            {
                logCallback?.Invoke("Người dùng dừng tác vụ hoặc Chrome đóng.");
                break;
            }

            logCallback?.Invoke($"[{totalUnfriended + 1}/{targetCount}] Đang hủy kết bạn UID: {targetUid}...");

            bool success = false;

            // Strategy 1: Comet GraphQL RelayModern Friendship Remove (siêu nhanh, không cần tải toàn bộ tường cá nhân)
            try
            {
                string jsGraphUnfriend = @"(async (unfriendUid) => {
                    try {
                        var dtsg = (window.require && window.require('DTSGInitialData')?.token)
                            || document.querySelector('[name=""fb_dtsg""]')?.value
                            || (document.documentElement.innerHTML.match(/[""']DTSGInitialData[""'],\[\],\{""token"":""([^""]+)""/)?.[1])
                            || (document.documentElement.innerHTML.match(/""token"":""([^""]+)""/)?.[1])
                            || '';
                        var actorId = (window.require && window.require('CurrentUserInitialData')?.USER_ID)
                            || (document.cookie.match(/c_user=(\d+)/)?.[1])
                            || '';
                        if (!dtsg || !actorId) return 'no_session_credentials';

                        var p = new URLSearchParams();
                        p.append('av', actorId);
                        p.append('__user', actorId);
                        p.append('__a', '1');
                        p.append('__comet_req', '15');
                        p.append('fb_dtsg', dtsg);
                        p.append('fb_api_caller_class', 'RelayModern');
                        p.append('fb_api_req_friendly_name', 'CometFriendshipRemoveMutation');
                        p.append('variables', JSON.stringify({
                            input: {
                                client_mutation_id: Math.floor(Math.random() * 10000).toString(),
                                actor_id: actorId,
                                source: 'profile',
                                unfriended_user_id: unfriendUid
                            }
                        }));
                        p.append('doc_id', '7162627993809633');

                        var res = await fetch('https://www.facebook.com/api/graphql/', {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            body: p.toString()
                        });
                        if (res.ok) {
                            var txt = await res.text();
                            if (txt.includes('unfriended_person') || txt.includes('""success"":true') || (txt.includes('""data""') && !txt.includes('""errors""'))) {
                                return 'graphql_success';
                            }
                        }
                    } catch(e) {}
                    return 'fallback_dom';
                })('" + targetUid + "')";

                string graphRes = chrome.method_14(jsGraphUnfriend);
                if (graphRes == "graphql_success")
                {
                    success = true;
                }
            }
            catch
            {
                // Fallback to DOM navigation
            }

            // Strategy 2: Comet 2026 Profile Action Bar Menu
            if (!success)
            {
                try
                {
                    string profileUrl = $"https://www.facebook.com/profile.php?id={targetUid}";
                    chrome.method_12(profileUrl);
                    chrome.F8091028(2.5);

                    // Nhận diện và click nút 'Bạn bè' / 'Friends'
                    string jsClickFriendBtn = @"(() => {
                        try {
                            var btnFriends = document.querySelector('[role=""button""][aria-label*=""Bạn bè"" i], [role=""button""][aria-label*=""Friends"" i], div[aria-label=""Bạn bè"" i], div[aria-label=""Friends"" i]');
                            if (btnFriends) {
                                btnFriends.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                btnFriends.click();
                                return 'menu_opened';
                            }

                            var allBtns = document.querySelectorAll('[role=""button""], button');
                            for (var b of allBtns) {
                                var t = (b.innerText || b.textContent || '').trim().toLowerCase();
                                if (t === 'bạn bè' || t === 'friends') {
                                    b.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    b.click();
                                    return 'menu_opened';
                                }
                            }

                            var bodyText = document.body.innerText || '';
                            if (bodyText.includes('không khả dụng') || bodyText.includes('isn\'t available') || bodyText.includes('bị vô hiệu hóa') || bodyText.includes('Page Not Found')) {
                                return 'profile_dead_unavailable';
                            }
                            return 'not_found';
                        } catch(e) { return 'error:' + e.message; }
                    })()";

                    string openMenuRes = chrome.method_14(jsClickFriendBtn);

                    if (openMenuRes == "menu_opened")
                    {
                        chrome.F8091028(1.2);

                        // Click menu item 'Hủy kết bạn' / 'Unfriend'
                        string jsClickUnfriendItem = @"(() => {
                            try {
                                var items = document.querySelectorAll('[role=""menuitem""], div[role=""menu""] span, div[role=""menu""] div');
                                for (var it of items) {
                                    var txt = (it.innerText || it.textContent || '').trim().toLowerCase();
                                    var aria = (it.getAttribute('aria-label') || '').toLowerCase();
                                    if (txt.includes('hủy kết bạn') || txt.includes('unfriend') || aria.includes('hủy kết bạn') || aria.includes('unfriend')) {
                                        it.click();
                                        return 'unfriend_clicked';
                                    }
                                }
                                return 'item_not_found';
                            } catch(e) { return 'error:' + e.message; }
                        })()";

                        string itemRes = chrome.method_14(jsClickUnfriendItem);
                        if (itemRes == "unfriend_clicked")
                        {
                            chrome.F8091028(1.0);

                            // Click Xác nhận trong dialog
                            string jsConfirmUnfriend = @"(() => {
                                try {
                                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                                    var dlg = dlgs[dlgs.length - 1];
                                    var btns = dlg.querySelectorAll('[role=""button""], button');
                                    for (var b of btns) {
                                        var a = (b.getAttribute('aria-label') || '').toLowerCase();
                                        var t = (b.innerText || b.textContent || '').trim().toLowerCase();
                                        if (t === 'hủy' || t === 'cancel' || t === 'đóng' || t === 'close') continue;
                                        if (a.includes('xác nhận') || a.includes('confirm') || a.includes('hủy kết bạn') || a.includes('unfriend') ||
                                            t.includes('xác nhận') || t.includes('confirm') || t.includes('hủy kết bạn') || t.includes('unfriend')) {
                                            b.click();
                                            return 'confirmed';
                                        }
                                    }
                                    return 'no_confirm_button';
                                } catch(e) { return 'error:' + e.message; }
                            })()";

                            string confRes = chrome.method_14(jsConfirmUnfriend);
                            if (confRes == "confirmed")
                            {
                                success = true;
                            }
                        }
                    }
                    else if (openMenuRes == "profile_dead_unavailable")
                    {
                        // Strategy 3: Nếu trang cá nhân đã bị Facebook khóa 404 (Die hẳn), tìm và hủy trên /me/friends
                        chrome.method_12("https://www.facebook.com/me/friends");
                        chrome.F8091028(2.5);

                        string jsSearchAndUnfriend = @"(() => {
                            try {
                                var inp = document.querySelector('input[aria-label*=""Tìm kiếm"" i], input[placeholder*=""Tìm kiếm"" i]');
                                if (inp) {
                                    inp.focus();
                                    inp.value = '" + targetUid + @"';
                                    inp.dispatchEvent(new Event('input', { bubbles: true }));
                                    inp.dispatchEvent(new Event('change', { bubbles: true }));
                                }
                                return 'searched';
                            } catch(e) { return 'err:' + e.message; }
                        })()";

                        chrome.method_14(jsSearchAndUnfriend);
                        chrome.F8091028(1.5);

                        // Thử click nút Khác / Bạn bè trên kết quả tìm kiếm
                        chrome.method_14(@"(() => {
                            try {
                                var moreBtn = document.querySelector('[role=""button""][aria-label*=""Khác"" i], [role=""button""][aria-label*=""More"" i], [role=""button""][aria-label*=""Bạn bè"" i]');
                                if (moreBtn) moreBtn.click();
                            } catch(e) {}
                        })()");
                        chrome.F8091028(1.0);

                        // Click hủy kết bạn
                        chrome.method_14(@"(() => {
                            try {
                                var items = document.querySelectorAll('[role=""menuitem""], div[role=""menu""] span');
                                for (var it of items) {
                                    var txt = (it.innerText || '').trim().toLowerCase();
                                    if (txt.includes('hủy kết bạn') || txt.includes('unfriend')) {
                                        it.click();
                                        return;
                                    }
                                }
                            } catch(e) {}
                        })()");
                        chrome.F8091028(1.0);

                        // Confirm
                        string conf = chrome.method_14(@"(() => {
                            try {
                                var btns = document.querySelectorAll('[role=""dialog""] [role=""button""], [role=""dialog""] button');
                                for (var b of btns) {
                                    var txt = (b.innerText || '').trim().toLowerCase();
                                    if (txt.includes('xác nhận') || txt.includes('confirm') || txt.includes('hủy kết bạn') || txt.includes('unfriend')) {
                                        b.click();
                                        return 'confirmed';
                                    }
                                }
                                return 'none';
                            } catch(e) { return 'err:' + e.message; }
                        })()");

                        if (conf == "confirmed")
                        {
                            success = true;
                        }
                    }
                }
                catch (Exception exDom)
                {
                    logCallback?.Invoke($"Lỗi DOM khi hủy kết bạn UID {targetUid}: {exDom.Message}");
                }
            }

            if (success)
            {
                totalUnfriended++;
                logCallback?.Invoke($"Đã hủy kết bạn UID: {targetUid} thành công ({totalUnfriended}/{targetCount})");
            }
            else
            {
                logCallback?.Invoke($"Không thể hủy kết bạn UID: {targetUid}");
            }

            // Giãn cách an toàn giữa các lượt hủy kết bạn
            if (totalUnfriended < targetCount)
            {
                int delaySec = _rand.Next(2, 5);
                chrome.F8091028(delaySec);
            }
        }

        logCallback?.Invoke($"Hoàn tất lọc bạn bè ảo: Đã hủy kết bạn thành công {totalUnfriended}/{targetCount} tài khoản.");
        return totalUnfriended;
    }

    /// <summary>
    /// Overload hỗ trợ tương tác với fMain: cập nhật log tiến độ trên dòng tài khoản.
    /// </summary>
    public static int UnfriendInactiveAccounts(
        fMain mainForm,
        int rowIndex,
        string accPrefix,
        Chrome chrome,
        List<string> deadFriendUids,
        int maxUnfriendCount = 30)
    {
        return UnfriendInactiveAccounts(
            chrome,
            deadFriendUids,
            maxUnfriendCount,
            msg => mainForm?.method_130(rowIndex, $"{accPrefix}: {msg}")
        );
    }

    /// <summary>
    /// Tự động quét danh sách bạn bè hiện tại, kiểm tra trạng thái Live/Die qua FbProfileChecker
    /// và thực hiện hủy kết bạn với các tài khoản ảo/die.
    /// </summary>
    public static int FilterAndUnfriendInactive(
        Chrome chrome,
        int maxCheckCount = 100,
        int maxUnfriendCount = 30,
        Action<string> logCallback = null)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null)
        {
            logCallback?.Invoke("Chrome instance hoặc ChromeDriver chưa được khởi tạo.");
            return 0;
        }

        logCallback?.Invoke("Đang trích xuất danh sách bạn bè của tài khoản...");

        // 1. Trích xuất UID bạn bè từ GraphQL hoặc DOM /me/friends
        List<string> friendUids = new List<string>();

        try
        {
            string jsGetFriends = @"(async () => {
                try {
                    var dtsg = (window.require && window.require('DTSGInitialData')?.token)
                        || document.querySelector('[name=""fb_dtsg""]')?.value
                        || '';
                    if (dtsg) {
                        var resp = await fetch('https://www.facebook.com/api/graphql', {
                            method: 'POST',
                            body: 'q=me(){friends}&fb_dtsg=' + dtsg,
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                        });
                        if (resp.ok) {
                            var data = await resp.json();
                            var key = Object.keys(data)[0];
                            if (data[key] && data[key].friends && data[key].friends.nodes) {
                                return data[key].friends.nodes.map(n => n.id).join(',');
                            }
                        }
                    }
                } catch(e) {}
                return '';
            })()";

            string friendStr = chrome.method_14(jsGetFriends);
            if (!string.IsNullOrWhiteSpace(friendStr))
            {
                friendUids = friendStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(u => u.Trim())
                                      .Where(u => !string.IsNullOrEmpty(u))
                                      .Distinct()
                                      .ToList();
            }
        }
        catch {}

        // Fallback mở /me/friends nếu không lấy được qua GraphQL
        if (friendUids.Count == 0)
        {
            chrome.method_12("https://www.facebook.com/me/friends");
            chrome.F8091028(3.0);

            string jsDomFriends = @"(() => {
                try {
                    var links = Array.from(document.querySelectorAll('a[href*=""/user/""], a[href*=""profile.php?id=""], a[role=""link""][href*=""facebook.com/""]'));
                    var uids = [];
                    var seen = new Set();
                    for (var a of links) {
                        var href = a.getAttribute('href') || '';
                        var m = href.match(/(?:profile\.php\?id=)([0-9]{8,})/);
                        if (m && m[1] && !seen.has(m[1])) {
                            seen.add(m[1]);
                            uids.push(m[1]);
                        }
                    }
                    return uids.join(',');
                } catch(e) { return ''; }
            })()";

            string domStr = chrome.method_14(jsDomFriends);
            if (!string.IsNullOrWhiteSpace(domStr))
            {
                friendUids = domStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(u => u.Trim())
                                   .Where(u => !string.IsNullOrEmpty(u))
                                   .Distinct()
                                   .ToList();
            }
        }

        if (friendUids.Count == 0)
        {
            logCallback?.Invoke("Không tìm thấy danh sách bạn bè nào để kiểm tra.");
            return 0;
        }

        int scanCount = Math.Min(friendUids.Count, maxCheckCount);
        logCallback?.Invoke($"Đã tìm thấy {friendUids.Count} bạn bè. Bắt đầu quét nhanh trạng thái {scanCount} bạn bè...");

        List<string> deadFriendUids = new List<string>();

        for (int i = 0; i < scanCount; i++)
        {
            if (Base.smethod_5() || chrome.CD930D04()) break;

            string targetUid = friendUids[i];
            try
            {
                var profileResult = FbProfileChecker.CheckProfile(targetUid);
                bool isDead = !profileResult.Success || !profileResult.IsLive;

                if (isDead)
                {
                    deadFriendUids.Add(targetUid);
                    logCallback?.Invoke($"Phát hiện UID ảo/die: {targetUid} (Tổng die: {deadFriendUids.Count})");
                }
                else
                {
                    if ((i + 1) % 10 == 0 || i == scanCount - 1)
                    {
                        logCallback?.Invoke($"Đã kiểm tra {i + 1}/{scanCount} bạn bè (Phát hiện {deadFriendUids.Count} tài khoản ảo/die)...");
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi kết nối từng nick
            }

            if (deadFriendUids.Count >= maxUnfriendCount)
            {
                logCallback?.Invoke($"Đã đủ số lượng {maxUnfriendCount} tài khoản ảo/die cần xử lý.");
                break;
            }
        }

        if (deadFriendUids.Count == 0)
        {
            logCallback?.Invoke($"Quét xong {scanCount} bạn bè: Toàn bộ đều Live, không phát hiện tài khoản ảo/die.");
            return 0;
        }

        logCallback?.Invoke($"Tiến hành hủy kết bạn {deadFriendUids.Count} tài khoản ảo/die vừa phát hiện...");
        return UnfriendInactiveAccounts(chrome, deadFriendUids, maxUnfriendCount, logCallback);
    }

    /// <summary>
    /// Overload hỗ trợ tương tác với fMain: tự động lọc và hủy kết bạn bạn bè ảo.
    /// </summary>
    public static int FilterAndUnfriendInactive(
        fMain mainForm,
        int rowIndex,
        string accPrefix,
        Chrome chrome,
        int maxCheckCount = 100,
        int maxUnfriendCount = 30)
    {
        return FilterAndUnfriendInactive(
            chrome,
            maxCheckCount,
            maxUnfriendCount,
            msg => mainForm?.method_130(rowIndex, $"{accPrefix}: {msg}")
        );
    }

    #endregion

    #region 3. FacebookActionsHub Action Execution Integration

    /// <summary>
    /// Điểm nối chuẩn hóa JSON cho FacebookActionsHub: Thu hồi lời mời kết bạn treo.
    /// </summary>
    public static string ExecuteCancelSentRequests(Chrome chrome, JObject param, string paramJson = "")
    {
        try
        {
            int maxCount = 50;
            int delayMin = 1;
            int delayMax = 3;

            if (param != null)
            {
                if (param["maxCancelCount"] != null) int.TryParse(param["maxCancelCount"].ToString(), out maxCount);
                else if (param["maxCount"] != null) int.TryParse(param["maxCount"].ToString(), out maxCount);
                else if (param["count"] != null) int.TryParse(param["count"].ToString(), out maxCount);

                if (param["delayMinSec"] != null) int.TryParse(param["delayMinSec"].ToString(), out delayMin);
                else if (param["delayMin"] != null) int.TryParse(param["delayMin"].ToString(), out delayMin);

                if (param["delayMaxSec"] != null) int.TryParse(param["delayMaxSec"].ToString(), out delayMax);
                else if (param["delayMax"] != null) int.TryParse(param["delayMax"].ToString(), out delayMax);
            }

            int cancelled = CancelPendingSentRequests(chrome, maxCount, delayMin, delayMax, null);

            var res = new JObject
            {
                ["success"] = true,
                ["cancelledCount"] = cancelled,
                ["maxCount"] = maxCount,
                ["error"] = ""
            };
            return res.ToString(Newtonsoft.Json.Formatting.None);
        }
        catch (Exception ex)
        {
            var res = new JObject
            {
                ["success"] = false,
                ["cancelledCount"] = 0,
                ["error"] = ex.Message
            };
            return res.ToString(Newtonsoft.Json.Formatting.None);
        }
    }

    /// <summary>
    /// Điểm nối chuẩn hóa JSON cho FacebookActionsHub: Lọc & hủy bạn bè ảo/die.
    /// </summary>
    public static string ExecuteUnfriendInactive(Chrome chrome, JObject param, string paramJson = "")
    {
        try
        {
            int maxUnfriend = 30;
            int maxCheck = 100;
            List<string> deadUids = new List<string>();

            if (param != null)
            {
                if (param["maxUnfriendCount"] != null) int.TryParse(param["maxUnfriendCount"].ToString(), out maxUnfriend);
                else if (param["maxCount"] != null) int.TryParse(param["maxCount"].ToString(), out maxUnfriend);

                if (param["maxCheckCount"] != null) int.TryParse(param["maxCheckCount"].ToString(), out maxCheck);
                else if (param["maxCheck"] != null) int.TryParse(param["maxCheck"].ToString(), out maxCheck);

                var uVal = param["deadFriendUids"] ?? param["uids"] ?? param["deadUids"];
                if (uVal != null)
                {
                    if (uVal is JArray jarr)
                    {
                        deadUids = jarr.Select(x => x.ToString()).ToList();
                    }
                    else
                    {
                        deadUids = uVal.ToString()
                                       .Split(new[] { '\r', '\n', '|', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(s => s.Trim())
                                       .ToList();
                    }
                }
            }

            int unfriended = 0;
            if (deadUids.Count > 0)
            {
                unfriended = UnfriendInactiveAccounts(chrome, deadUids, maxUnfriend, null);
            }
            else
            {
                unfriended = FilterAndUnfriendInactive(chrome, maxCheck, maxUnfriend, null);
            }

            var res = new JObject
            {
                ["success"] = true,
                ["unfriendedCount"] = unfriended,
                ["maxCount"] = maxUnfriend,
                ["error"] = ""
            };
            return res.ToString(Newtonsoft.Json.Formatting.None);
        }
        catch (Exception ex)
        {
            var res = new JObject
            {
                ["success"] = false,
                ["unfriendedCount"] = 0,
                ["error"] = ex.Message
            };
            return res.ToString(Newtonsoft.Json.Formatting.None);
        }
    }

    #endregion
}
