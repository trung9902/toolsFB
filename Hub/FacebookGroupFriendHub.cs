using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

public static class FacebookGroupFriendHub
{
    public static string Execute(Chrome chrome, string actionName, string paramJson)
    {
        if (chrome == null || string.IsNullOrWhiteSpace(actionName))
        {
            return "{\"success\": false, \"error\": \"invalid_arguments\"}";
        }

        try
        {
            switch (actionName.Trim().ToLowerInvariant())
            {
                case "joingroupwww":
                case "joingroupmbasic":
                case "joingroup":
                    return JoinGroup(chrome, paramJson);

                case "joingroupdexuatwww":
                case "joingroupdexuat":
                case "joingroupsuggestion":
                    return JoinGroupDeXuat(chrome, paramJson);

                case "roinhomwww":
                case "roinhom":
                case "leavegroupwww":
                case "leavegroup":
                    return RoiNhom(chrome, paramJson);

                case "huyketbanwww":
                case "huyketban":
                case "unfriendwww":
                case "unfriend":
                    return HuyKetBan(chrome, paramJson);

                case "moibanbevaonhomwww":
                case "moibanbevaonhom":
                case "invitegroupwww":
                case "invitegroup":
                    return MoiBanBeVaoNhom(chrome, paramJson);

                case "moibanbelikepagewww":
                case "moibanbelikepage":
                case "invitelikepagewww":
                case "invitelikepage":
                    return MoiBanBeLikePage(chrome, paramJson);

                case "searchgroup":
                case "searchgroupwww":
                case "timkiemnhom":
                    return SearchGroup(chrome, paramJson);

                default:
                    return "";
            }
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #region Action 1: JoinGroup (JoinGroupWWW / JoinGroupMbasic)

    private static string JoinGroup(Chrome chrome, string paramJson)
    {
        try
        {
            var p = ParseParams(paramJson);
            bool isAnswer = GetBool(p, "isAnswer", false) || GetBool(p, "ckbTuDongTraLoiCauHoi", false);
            string answer = GetString(p, "answer", "");
            if (string.IsNullOrEmpty(answer))
            {
                answer = GetString(p, "lstCauTraLoi", "");
            }
            if (string.IsNullOrEmpty(answer))
            {
                answer = GetString(p, "txtCauTraLoi", "");
            }

            // Check if already in group or requested
            string checkScript = @"
                try {
                    var all = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                    for (var i = 0; i < all.length; i++) {
                        var b = all[i];
                        var a = (b.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (b.innerText || '').toLowerCase().trim();
                        if (a.includes('đã tham gia') || a.includes('joined') || t === 'đã tham gia' || t === 'joined') {
                            return 'already_joined';
                        }
                        if (a.includes('đã gửi yêu cầu') || a.includes('cancel request') || a.includes('hủy yêu cầu') ||
                            t === 'đã gửi yêu cầu' || t === 'hủy yêu cầu' || t === 'cancel request') {
                            return 'already_requested';
                        }
                    }
                    return 'not_joined';
                } catch(e) { return 'error'; }
            ";
            string status = RunScript(chrome, checkScript)?.ToString() ?? "";
            if (status == "already_joined" || status == "already_requested")
            {
                return "{\"success\": true, \"error\": \"\"}";
            }

            // Find and click Join button
            string clickJoinScript = @"
                try {
                    var all = document.querySelectorAll('div[aria-label*=""Tham gia nhóm"" i], div[aria-label*=""Join group"" i], button[aria-label*=""Tham gia nhóm"" i], button[aria-label*=""Join group"" i], [role=""button""][aria-label*=""Tham gia nhóm"" i], [role=""button""][aria-label*=""Join group"" i], div[aria-label*=""Tham gia"" i], div[aria-label*=""Join"" i], button[aria-label*=""Tham gia"" i], button[aria-label*=""Join"" i], [role=""button""][aria-label*=""Tham gia"" i], [role=""button""][aria-label*=""Join"" i], [role=""button""], button');
                    for (var i = 0; i < all.length; i++) {
                        var btn = all[i];
                        var a = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (btn.innerText || '').toLowerCase().trim();
                        if (a.includes('chat') || t.includes('chat') || a.includes('cuộc trò chuyện')) continue;

                        if (a.includes('tham gia nhóm') || a.includes('join group') ||
                            t === 'tham gia nhóm' || t === 'join group' ||
                            a === 'tham gia' || a === 'join' || t === 'tham gia' || t === 'join') {
                            btn.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            btn.click();
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string clickResult = RunScript(chrome, clickJoinScript)?.ToString() ?? "";
            if (clickResult == "not_found")
            {
                // Double check if already joined
                string recheck = RunScript(chrome, checkScript)?.ToString() ?? "";
                if (recheck == "already_joined" || recheck == "already_requested")
                {
                    return "{\"success\": true, \"error\": \"\"}";
                }
                return "{\"success\": false, \"error\": \"Join button not found\"}";
            }

            Sleep(chrome, 2.0);

            // Handle review question dialog if present
            AnswerGroupQuestions(chrome, isAnswer, answer);

            Sleep(chrome, 1.5);

            if (IsFbBlocked(chrome))
            {
                return "{\"success\": false, \"error\": \"fb_blocked\"}";
            }

            return "{\"success\": true, \"error\": \"\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #endregion

    #region Action 2: JoinGroupDeXuatWWW

    private static string JoinGroupDeXuat(Chrome chrome, string paramJson)
    {
        try
        {
            var p = ParseParams(paramJson);
            int soLuongFrom = GetInt(p, "nudSoLuongFrom", 1);
            int soLuongTo = GetInt(p, "nudSoLuongTo", Math.Max(soLuongFrom, 3));
            int delayFrom = GetInt(p, "nudDelayFrom", 2);
            int delayTo = GetInt(p, "nudDelayTo", Math.Max(delayFrom, 4));
            bool isAnswer = GetBool(p, "ckbTuDongTraLoiCauHoi", false) || GetBool(p, "isAnswer", false);
            string answer = GetString(p, "lstCauTraLoi", "");
            if (string.IsNullOrEmpty(answer))
            {
                answer = GetString(p, "answer", "");
            }

            int targetCount = (soLuongFrom > 0 && soLuongTo >= soLuongFrom)
                ? new Random().Next(soLuongFrom, soLuongTo + 1)
                : Math.Max(1, soLuongTo);

            // Check current URL, navigate to discover/groups if needed
            string currentUrl = GetUrl(chrome);
            if (!currentUrl.Contains("facebook.com/groups"))
            {
                chrome.method_12("https://www.facebook.com/groups/discover", FC3A841F: true);
                Sleep(chrome, 3.0);
            }

            int joined = 0;
            int maxScrollAttempts = 10;
            var rand = new Random();

            for (int attempt = 0; attempt < maxScrollAttempts && joined < targetCount; attempt++)
            {
                // Find next eligible join button in recommendations
                string findAndClickNextScript = @"
                    try {
                        var candidates = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                        for (var i = 0; i < candidates.length; i++) {
                            var el = candidates[i];
                            if (el.getAttribute('data-dexuat-joined') === '1') continue;

                            var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                            var t = (el.innerText || '').toLowerCase().trim();
                            if (a.includes('chat') || t.includes('chat')) continue;
                            if (a.includes('đã tham gia') || a.includes('joined') || t === 'đã tham gia' || t === 'joined' ||
                                a.includes('đã gửi') || t.includes('đã gửi')) continue;

                            if (a.includes('tham gia nhóm') || a.includes('join group') ||
                                t === 'tham gia nhóm' || t === 'join group' ||
                                a === 'tham gia' || a === 'join' || t === 'tham gia' || t === 'join') {
                                
                                var rect = el.getBoundingClientRect();
                                if (rect.width > 0 && rect.height > 0) {
                                    el.setAttribute('data-dexuat-joined', '1');
                                    el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                    el.click();
                                    return 'clicked';
                                }
                            }
                        }
                        return 'none';
                    } catch(e) { return 'error: ' + e.message; }
                ";

                string clickRes = RunScript(chrome, findAndClickNextScript)?.ToString() ?? "";
                if (clickRes == "clicked")
                {
                    Sleep(chrome, 2.0);

                    // Check for questions dialog
                    AnswerGroupQuestions(chrome, isAnswer, answer);

                    if (IsFbBlocked(chrome))
                    {
                        return "{\"success\": false, \"error\": \"fb_blocked\"}";
                    }

                    joined++;
                    if (joined >= targetCount) break;

                    int delay = (delayTo >= delayFrom) ? rand.Next(delayFrom, delayTo + 1) : delayFrom;
                    Sleep(chrome, delay);
                }
                else
                {
                    // Scroll down to load more suggestions
                    RunScript(chrome, "window.scrollBy(0, 1000);");
                    Sleep(chrome, 2.5);
                }
            }

            return "{\"success\": true, \"error\": \"\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #endregion

    #region Action 3: RoiNhomWWW

    private static string RoiNhom(Chrome chrome, string paramJson)
    {
        try
        {
            // 1. Find and click "Đã tham gia" / "Joined" button on group page
            string clickJoinedBtnScript = @"
                try {
                    var all = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                    for (var i = 0; i < all.length; i++) {
                        var el = all[i];
                        var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (el.innerText || '').toLowerCase().trim();
                        if (a === 'đã tham gia' || a === 'joined' || a.includes('đã tham gia') || a.includes('joined') ||
                            t === 'đã tham gia' || t === 'joined') {
                            el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el.click();
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string res = RunScript(chrome, clickJoinedBtnScript)?.ToString() ?? "";
            if (res != "clicked")
            {
                return "{\"success\": false, \"error\": \"Joined button not found\"}";
            }

            Sleep(chrome, 1.5);

            // 2. In dropdown menu, click "Rời khỏi nhóm" / "Leave group"
            string clickLeaveMenuItemScript = @"
                try {
                    var items = document.querySelectorAll('[role=""menu""] [role=""menuitem""], [role=""menu""] [role=""button""], [role=""menu""] div, [role=""menu""] span');
                    for (var i = 0; i < items.length; i++) {
                        var item = items[i];
                        var a = (item.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (item.innerText || '').toLowerCase().trim();
                        if (a.includes('rời khỏi nhóm') || a.includes('leave group') || a.includes('rời nhóm') ||
                            t.includes('rời khỏi nhóm') || t.includes('leave group') || t.includes('rời nhóm')) {
                            item.click();
                            return 'clicked_leave';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string leaveRes = RunScript(chrome, clickLeaveMenuItemScript)?.ToString() ?? "";
            if (leaveRes != "clicked_leave")
            {
                return "{\"success\": false, \"error\": \"Leave group menu item not found\"}";
            }

            Sleep(chrome, 1.5);

            // 3. In confirmation dialog, click confirm button
            string confirmLeaveScript = @"
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];
                    var btns = dlg.querySelectorAll('[role=""button""], button');
                    for (var i = 0; i < btns.length; i++) {
                        var btn = btns[i];
                        var a = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (btn.innerText || '').toLowerCase().trim();
                        if (a.includes('cancel') || a.includes('hủy') || a.includes('đóng') || a.includes('close') ||
                            t === 'hủy' || t === 'cancel' || t === 'đóng' || t === 'close') {
                            continue;
                        }
                        if (a.includes('rời khỏi nhóm') || a.includes('leave group') || a.includes('rời nhóm') || a.includes('leave') ||
                            t.includes('rời khỏi nhóm') || t.includes('leave group') || t.includes('rời nhóm') || t.includes('rời') ||
                            a.includes('xác nhận') || a.includes('confirm') || t.includes('xác nhận') || t.includes('confirm')) {
                            btn.click();
                            return 'confirmed';
                        }
                    }
                    // Fallback to the last action button
                    for (var j = btns.length - 1; j >= 0; j--) {
                        var b2 = btns[j];
                        var a2 = (b2.getAttribute('aria-label') || '').toLowerCase();
                        var t2 = (b2.innerText || '').toLowerCase();
                        if (a2.includes('cancel') || a2.includes('hủy') || t2.includes('hủy') || t2.includes('cancel')) continue;
                        b2.click();
                        return 'confirmed_fallback';
                    }
                    return 'no_confirm_button';
                } catch(e) { return 'error: ' + e.message; }
            ";

            RunScript(chrome, confirmLeaveScript);
            Sleep(chrome, 2.0);

            if (IsFbBlocked(chrome))
            {
                return "{\"success\": false, \"error\": \"fb_blocked\"}";
            }

            return "{\"success\": true, \"error\": \"\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #endregion

    #region Action 4: HuyKetBanWWW

    private static string HuyKetBan(Chrome chrome, string paramJson)
    {
        try
        {
            // 1. Find "Bạn bè" / "Friends" button
            string clickFriendsBtnScript = @"
                try {
                    var all = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                    for (var i = 0; i < all.length; i++) {
                        var el = all[i];
                        var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (el.innerText || '').toLowerCase().trim();
                        if (a === 'bạn bè' || a === 'friends' || t === 'bạn bè' || t === 'friends') {
                            el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el.click();
                            return 'clicked';
                        }
                    }
                    for (var j = 0; j < all.length; j++) {
                        var el2 = all[j];
                        var a2 = (el2.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t2 = (el2.innerText || '').toLowerCase().trim();
                        if ((a2.includes('bạn bè') || a2.includes('friends') || t2.includes('bạn bè') || t2.includes('friends')) &&
                            !a2.includes('tìm') && !t2.includes('tìm') && !a2.includes('lời mời') && !t2.includes('lời mời')) {
                            el2.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el2.click();
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string res = RunScript(chrome, clickFriendsBtnScript)?.ToString() ?? "";
            if (res != "clicked")
            {
                return "{\"success\": false, \"error\": \"Friends button not found\"}";
            }

            Sleep(chrome, 1.2);

            // 2. In dropdown menu, click "Hủy kết bạn" / "Unfriend"
            string clickUnfriendScript = @"
                try {
                    var items = document.querySelectorAll('[role=""menu""] [role=""menuitem""], [role=""menu""] [role=""button""], [role=""menu""] span, [role=""menu""] div');
                    for (var i = 0; i < items.length; i++) {
                        var item = items[i];
                        var a = (item.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (item.innerText || '').toLowerCase().trim();
                        if (a.includes('hủy kết bạn') || a.includes('unfriend') ||
                            t.includes('hủy kết bạn') || t.includes('unfriend')) {
                            item.click();
                            return 'clicked_unfriend';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string unfriendRes = RunScript(chrome, clickUnfriendScript)?.ToString() ?? "";
            if (unfriendRes != "clicked_unfriend")
            {
                return "{\"success\": false, \"error\": \"Unfriend menu item not found\"}";
            }

            Sleep(chrome, 1.2);

            // 3. In confirmation dialog, click confirm button
            string confirmUnfriendScript = @"
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];
                    var btns = dlg.querySelectorAll('[role=""button""], button');
                    for (var i = 0; i < btns.length; i++) {
                        var btn = btns[i];
                        var a = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (btn.innerText || '').toLowerCase().trim();
                        if ((a.includes('cancel') || a.includes('hủy')) && !a.includes('hủy kết bạn') ||
                            t === 'hủy' || t === 'cancel' || t === 'đóng' || t === 'close') {
                            continue;
                        }
                        if (a.includes('xác nhận') || a.includes('confirm') || t.includes('xác nhận') || t.includes('confirm') ||
                            a.includes('hủy kết bạn') || a.includes('unfriend') || t.includes('hủy kết bạn') || t.includes('unfriend')) {
                            btn.click();
                            return 'confirmed';
                        }
                    }
                    return 'no_confirm_button';
                } catch(e) { return 'error: ' + e.message; }
            ";

            RunScript(chrome, confirmUnfriendScript);
            Sleep(chrome, 1.5);

            if (IsFbBlocked(chrome))
            {
                return "{\"success\": false, \"error\": \"fb_blocked\"}";
            }

            return "{\"success\": true, \"error\": \"\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #endregion

    #region Action 5: MoiBanBeVaoNhomWWW

    private static string MoiBanBeVaoNhom(Chrome chrome, string paramJson)
    {
        try
        {
            var p = ParseParams(paramJson);
            int count = GetInt(p, "count", 10);
            int typeInvite = GetInt(p, "typeInvite", 0);
            string arrNames = GetString(p, "arrNames", "");

            // 1. Click "Mời" / "Invite" button on group page
            string clickInviteBtnScript = @"
                try {
                    var all = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                    for (var i = 0; i < all.length; i++) {
                        var el = all[i];
                        var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (el.innerText || '').toLowerCase().trim();
                        if (a.includes('chat') || t.includes('chat')) continue;
                        if (a === 'mời' || a === 'invite' || a.includes('mời bạn bè') || a.includes('invite friends') ||
                            t === 'mời' || t === 'invite' || t === '+ mời' || t === '+ invite') {
                            el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el.click();
                            return 'clicked';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string clickRes = RunScript(chrome, clickInviteBtnScript)?.ToString() ?? "";
            if (clickRes != "clicked")
            {
                return "{\"success\": false, \"error\": \"Invite button not found\"}";
            }

            Sleep(chrome, 2.5);

            // 2. Select friends in dialog
            string selectFriendsScript = @"
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];

                    var maxCount = arguments[0];
                    var typeInv = arguments[1];
                    var namesRaw = arguments[2];
                    var targetNames = (namesRaw || '').split(/[\n|]/).map(function(x) { return x.trim().toLowerCase(); }).filter(function(x) { return x.length > 0; });
                    var selected = 0;

                    if (typeInv === 1 && targetNames.length > 0) {
                        var searchBox = dlg.querySelector('input[type=""text""], input[type=""search""], input[placeholder*=""Tìm"" i], input[placeholder*=""Search"" i]');
                        for (var n = 0; n < targetNames.length && selected < maxCount; n++) {
                            var name = targetNames[n];
                            if (searchBox) {
                                searchBox.value = name;
                                searchBox.dispatchEvent(new Event('input', { bubbles: true }));
                                searchBox.dispatchEvent(new Event('change', { bubbles: true }));
                            }
                            var cbs = dlg.querySelectorAll('input[type=""checkbox""], [role=""checkbox""]');
                            for (var c = 0; c < cbs.length && selected < maxCount; c++) {
                                var cb = cbs[c];
                                var isChecked = cb.checked || cb.getAttribute('aria-checked') === 'true';
                                if (!isChecked) {
                                    cb.click();
                                    selected++;
                                    break;
                                }
                            }
                        }
                    } else {
                        var cbs = dlg.querySelectorAll('input[type=""checkbox""], [role=""checkbox""]');
                        for (var i = 0; i < cbs.length && selected < maxCount; i++) {
                            var cb = cbs[i];
                            var isChecked = cb.checked || cb.getAttribute('aria-checked') === 'true';
                            if (!isChecked) {
                                cb.click();
                                selected++;
                            }
                        }
                    }
                    return 'selected_' + selected;
                } catch(e) { return 'error: ' + e.message; }
            ";

            RunScript(chrome, selectFriendsScript, count, typeInvite, arrNames);
            Sleep(chrome, 1.0);

            // 3. Click "Gửi lời mời" / "Send invites" button in dialog
            string sendInvitesScript = @"
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];
                    var btns = dlg.querySelectorAll('[role=""button""], button');
                    for (var i = 0; i < btns.length; i++) {
                        var btn = btns[i];
                        var a = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (btn.innerText || '').toLowerCase().trim();
                        if (a.includes('cancel') || a.includes('hủy') || a.includes('đóng') || a.includes('close') ||
                            t === 'hủy' || t === 'cancel' || t === 'đóng' || t === 'close') {
                            continue;
                        }
                        if (a.includes('gửi lời mời') || a.includes('send invites') || a.includes('send invite') ||
                            t.includes('gửi lời mời') || t.includes('send invites') || t.includes('send invite') ||
                            t === 'gửi' || t === 'send' || a === 'gửi' || a === 'send' ||
                            t === 'mời' || t === 'invite' || a === 'mời' || a === 'invite') {
                            btn.click();
                            return 'sent';
                        }
                    }
                    for (var j = btns.length - 1; j >= 0; j--) {
                        var b2 = btns[j];
                        var a2 = (b2.getAttribute('aria-label') || '').toLowerCase();
                        var t2 = (b2.innerText || '').toLowerCase();
                        if (a2.includes('cancel') || a2.includes('hủy') || t2.includes('hủy') || t2.includes('cancel')) continue;
                        b2.click();
                        return 'sent_fallback';
                    }
                    return 'no_send_button';
                } catch(e) { return 'error: ' + e.message; }
            ";

            RunScript(chrome, sendInvitesScript);
            Sleep(chrome, 2.0);

            if (IsFbBlocked(chrome))
            {
                return "{\"success\": false, \"error\": \"fb_blocked\"}";
            }

            return "{\"success\": true, \"error\": \"\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #endregion

    #region Action 6: MoiBanBeLikePageWWW

    private static string MoiBanBeLikePage(Chrome chrome, string paramJson)
    {
        try
        {
            var p = ParseParams(paramJson);
            int count = GetInt(p, "count", 50);

            // 1. Look for direct "Mời bạn bè" / "Invite friends" button, or 3-dots menu button
            string triggerInviteScript = @"
                try {
                    var all = document.querySelectorAll('[role=""button""], button, div[aria-label]');
                    for (var i = 0; i < all.length; i++) {
                        var el = all[i];
                        var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (el.innerText || '').toLowerCase().trim();
                        if (a.includes('mời bạn bè') || a.includes('invite friends') ||
                            t.includes('mời bạn bè') || t.includes('invite friends')) {
                            el.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el.click();
                            return 'clicked_direct';
                        }
                    }
                    // Click 3 dots menu
                    for (var j = 0; j < all.length; j++) {
                        var el2 = all[j];
                        var a2 = (el2.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t2 = (el2.innerText || '').toLowerCase().trim();
                        if (a2.includes('hành động khác') || a2.includes('xem thêm') || a2.includes('khác') ||
                            a2.includes('more actions') || a2.includes('action options') || a2.includes('more') ||
                            t2 === '...' || t2 === '…') {
                            el2.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            el2.click();
                            return 'clicked_menu';
                        }
                    }
                    return 'not_found';
                } catch(e) { return 'error: ' + e.message; }
            ";

            string triggerRes = RunScript(chrome, triggerInviteScript)?.ToString() ?? "";
            if (triggerRes == "clicked_menu")
            {
                Sleep(chrome, 1.2);
                string clickMenuInviteScript = @"
                    try {
                        var items = document.querySelectorAll('[role=""menu""] [role=""menuitem""], [role=""menu""] [role=""button""], [role=""menu""] span, [role=""menu""] div');
                        for (var i = 0; i < items.length; i++) {
                            var item = items[i];
                            var a = (item.getAttribute('aria-label') || '').toLowerCase().trim();
                            var t = (item.innerText || '').toLowerCase().trim();
                            if (a.includes('mời bạn bè') || a.includes('invite friends') ||
                                t.includes('mời bạn bè') || t.includes('invite friends') ||
                                a.includes('mời') || t.includes('mời')) {
                                item.click();
                                return 'clicked_item';
                            }
                        }
                        return 'not_found';
                    } catch(e) { return 'error: ' + e.message; }
                ";
                RunScript(chrome, clickMenuInviteScript);
            }

            Sleep(chrome, 2.5);

            // 2. In dialog, select all or tick friend checkboxes
            string selectFriendsPageScript = @"
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];
                    var maxCount = arguments[0];

                    // Check for 'Select all' / 'Chọn tất cả'
                    var allElements = dlg.querySelectorAll('[role=""button""], button, span, label, div');
                    for (var s = 0; s < allElements.length; s++) {
                        var el = allElements[s];
                        var t = (el.innerText || '').toLowerCase().trim();
                        var a = (el.getAttribute('aria-label') || '').toLowerCase().trim();
                        if (t === 'chọn tất cả' || t === 'select all' || a === 'chọn tất cả' || a === 'select all' ||
                            t.includes('chọn tất cả') || t.includes('select all')) {
                            var cbParent = el.querySelector('input[type=""checkbox""], [role=""checkbox""]') || el;
                            cbParent.click();
                            return 'selected_all';
                        }
                    }

                    // Fallback to ticking checkboxes up to maxCount
                    var cbs = dlg.querySelectorAll('input[type=""checkbox""], [role=""checkbox""]');
                    var count = 0;
                    for (var i = 0; i < cbs.length && count < maxCount; i++) {
                        var cb = cbs[i];
                        var isChecked = cb.checked || cb.getAttribute('aria-checked') === 'true';
                        if (!isChecked) {
                            cb.click();
                            count++;
                        }
                    }
                    return 'selected_' + count;
                } catch(e) { return 'error: ' + e.message; }
            ";

            RunScript(chrome, selectFriendsPageScript, count);
            Sleep(chrome, 1.0);

            // 3. Click "Gửi lời mời" / "Send invites"
            string sendPageInvitesScript = @"
                try {
                    var dlgs = document.querySelectorAll('div[role=""dialog""]');
                    if (!dlgs || dlgs.length === 0) return 'no_dialog';
                    var dlg = dlgs[dlgs.length - 1];
                    var btns = dlg.querySelectorAll('[role=""button""], button');
                    for (var i = 0; i < btns.length; i++) {
                        var btn = btns[i];
                        var a = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                        var t = (btn.innerText || '').toLowerCase().trim();
                        if (a.includes('cancel') || a.includes('hủy') || a.includes('đóng') || a.includes('close') ||
                            t === 'hủy' || t === 'cancel' || t === 'đóng' || t === 'close') {
                            continue;
                        }
                        if (a.includes('gửi lời mời') || a.includes('send invites') ||
                            t.includes('gửi lời mời') || t.includes('send invites') ||
                            t === 'gửi' || t === 'send' || a === 'gửi' || a === 'send') {
                            btn.click();
                            return 'sent';
                        }
                    }
                    for (var j = btns.length - 1; j >= 0; j--) {
                        var b2 = btns[j];
                        var a2 = (b2.getAttribute('aria-label') || '').toLowerCase();
                        var t2 = (b2.innerText || '').toLowerCase();
                        if (a2.includes('cancel') || a2.includes('hủy') || t2.includes('hủy') || t2.includes('cancel')) continue;
                        b2.click();
                        return 'sent_fallback';
                    }
                    return 'no_send_button';
                } catch(e) { return 'error: ' + e.message; }
            ";

            RunScript(chrome, sendPageInvitesScript);
            Sleep(chrome, 2.0);

            if (IsFbBlocked(chrome))
            {
                return "{\"success\": false, \"error\": \"fb_blocked\"}";
            }

            return "{\"success\": true, \"error\": \"\"}";
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\"}";
        }
    }

    #endregion

    #region Action 7: SearchGroup

    private static string SearchGroup(Chrome chrome, string paramJson)
    {
        try
        {
            var p = ParseParams(paramJson);
            string tuKhoa = GetString(p, "tuKhoa", "");
            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = GetString(p, "keyword", "");
            }
            int limit = GetInt(p, "limit", 20);

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return "{\"success\": false, \"error\": \"empty_keyword\", \"data\": []}";
            }

            string searchUrl = "https://www.facebook.com/search/groups/?q=" + Uri.EscapeDataString(tuKhoa);
            chrome.method_12(searchUrl, FC3A841F: true);
            Sleep(chrome, 3.5);

            string extractScript = @"
                try {
                    var list = [];
                    var seen = {};
                    var links = document.querySelectorAll('a[href*=""/groups/""]');
                    var maxCount = arguments[0];

                    for (var i = 0; i < links.length; i++) {
                        var a = links[i];
                        var href = a.getAttribute('href') || '';
                        var m = href.match(/\/groups\/([^\/?#]+)/);
                        if (!m) continue;
                        var gid = m[1];
                        if (gid === 'feed' || gid === 'discover' || gid === 'joins' || gid === 'create' || gid === 'search') continue;
                        if (seen[gid]) continue;
                        seen[gid] = true;

                        var name = (a.innerText || '').trim();
                        var card = a.closest('[role=""article""]') || a.closest('[role=""feed""] > div') || a.parentElement;
                        if ((!name || name.length < 2) && card) {
                            var h = card.querySelector('h2, h3, span[dir=""auto""], strong');
                            if (h) name = (h.innerText || '').trim();
                        }
                        if (!name) name = gid;
                        name = name.split('\n')[0].trim();

                        var info = card ? (card.innerText || '') : '';
                        var privacy = '';
                        if (info.includes('Công khai') || info.toLowerCase().includes('public')) privacy = 'Public';
                        else if (info.includes('Riêng tư') || info.toLowerCase().includes('private')) privacy = 'Private';

                        var members = '';
                        var memMatch = info.match(/([0-9.,]+[KkMm]?\s*(thành viên|members|người theo dõi|followers))/i);
                        if (memMatch) members = memMatch[1];

                        list.push({
                            id: gid,
                            name: name,
                            url: 'https://www.facebook.com/groups/' + gid + '/',
                            privacy: privacy,
                            members: members
                        });

                        if (list.length >= maxCount) break;
                    }
                    return JSON.stringify(list);
                } catch(e) { return JSON.stringify([]); }
            ";

            List<JObject> results = new List<JObject>();
            for (int scroll = 0; scroll < 4; scroll++)
            {
                string jsonRaw = RunScript(chrome, extractScript, limit)?.ToString() ?? "[]";
                try
                {
                    var arr = JArray.Parse(jsonRaw);
                    results = arr.OfType<JObject>().ToList();
                }
                catch { }

                if (results.Count >= limit) break;

                RunScript(chrome, "window.scrollBy(0, 1000);");
                Sleep(chrome, 2.0);
            }

            JArray dataArr = new JArray(results.Take(limit));
            var resp = new JObject
            {
                ["success"] = true,
                ["total"] = dataArr.Count,
                ["data"] = dataArr,
                ["groups"] = dataArr,
                ["error"] = ""
            };

            return resp.ToString(Formatting.None);
        }
        catch (Exception ex)
        {
            return "{\"success\": false, \"error\": \"" + EscapeJson(ex.Message) + "\", \"data\": []}";
        }
    }

    #endregion

    #region Modal & Dialog Helpers

    private static void AnswerGroupQuestions(Chrome chrome, bool isAnswer, string answers, string groupName = "")
    {
        try
        {
            List<string> answerList = new List<string>();
            if (!string.IsNullOrEmpty(answers))
            {
                answerList = answers.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => x.Trim())
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .ToList();
            }

            // Nâng cấp tự động trả lời câu hỏi nhóm Facebook bằng Gemini AI thông minh
            SmartGroupJoinAIHelper.HandleGroupQuestionsDialog(chrome, groupName, isAnswer, answerList, agreeRules: true);
        }
        catch
        {
        }
    }

    private static bool IsFbBlocked(Chrome chrome)
    {
        try
        {
            string res = RunScript(chrome, @"
                try {
                    var txt = (document.body ? document.body.innerText : '').toLowerCase();
                    if (txt.includes('tạm thời bị chặn') || txt.includes('bị khóa') || 
                        txt.includes('temporarily blocked') || txt.includes('account has been locked') ||
                        txt.includes('hành động này bị chặn') || txt.includes('you’re temporarily blocked') ||
                        txt.includes('you\'re temporarily blocked')) {
                        return true;
                    }
                } catch(e) {}
                return false;
            ")?.ToString();
            return res != null && res.Equals("true", StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Internal Utilities

    private static object RunScript(Chrome chrome, string script, params object[] args)
    {
        try
        {
            if (chrome?.ChromeDriver_0 != null)
            {
                return chrome.ChromeDriver_0.ExecuteScript(script, args);
            }
        }
        catch { }
        return null;
    }

    private static void Sleep(Chrome chrome, double seconds)
    {
        try
        {
            if (chrome != null)
            {
                chrome.F8091028(seconds);
            }
            else
            {
                Thread.Sleep((int)(seconds * 1000));
            }
        }
        catch
        {
            Thread.Sleep((int)(seconds * 1000));
        }
    }

    private static string GetUrl(Chrome chrome)
    {
        try
        {
            return chrome?.GetURL() ?? chrome?.ChromeDriver_0?.Url ?? "";
        }
        catch
        {
            return "";
        }
    }

    private static Dictionary<string, string> ParseParams(string paramJson)
    {
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (string.IsNullOrWhiteSpace(paramJson)) return dict;

        try
        {
            var token = JToken.Parse(paramJson);
            if (token is JArray arr)
            {
                foreach (var item in arr)
                {
                    string name = item["name"]?.ToString() ?? "";
                    string val = item["value"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(name))
                    {
                        dict[name] = val;
                    }
                }
            }
            else if (token is JObject obj)
            {
                foreach (var prop in obj.Properties())
                {
                    dict[prop.Name] = prop.Value?.ToString() ?? "";
                }
            }
        }
        catch { }
        return dict;
    }

    private static int GetInt(Dictionary<string, string> dict, string key, int defaultValue)
    {
        if (dict != null && dict.TryGetValue(key, out string val) && int.TryParse(val, out int res))
        {
            return res;
        }
        return defaultValue;
    }

    private static bool GetBool(Dictionary<string, string> dict, string key, bool defaultValue)
    {
        if (dict != null && dict.TryGetValue(key, out string val) && bool.TryParse(val, out bool res))
        {
            return res;
        }
        return defaultValue;
    }

    private static string GetString(Dictionary<string, string> dict, string key, string defaultValue)
    {
        if (dict != null && dict.TryGetValue(key, out string val) && !string.IsNullOrEmpty(val))
        {
            return val;
        }
        return defaultValue;
    }

    private static string EscapeJson(string str)
    {
        if (string.IsNullOrEmpty(str)) return "";
        return str.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n");
    }

    #endregion
}
