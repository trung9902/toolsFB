using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class ProfileInfoHub
{
    private static void Sleep(double seconds)
    {
        try { Thread.Sleep((int)(seconds * 1000)); } catch { }
    }

    private static void DismissPopups(Chrome chrome)
    {
        try { chrome?.DismissFacebookPopups(); } catch { }
    }

    private static IWebElement FindFirst(ChromeDriver driver, params string[] xpaths)
    {
        if (driver == null) return null;
        foreach (var xpath in xpaths)
        {
            try
            {
                var elements = driver.FindElements(By.XPath(xpath));
                foreach (var el in elements)
                {
                    if (el.Displayed && el.Enabled) return el;
                }
            }
            catch { }
        }
        return null;
    }

    private static bool ClickJs(ChromeDriver driver, IWebElement element)
    {
        if (driver == null || element == null) return false;
        try
        {
            driver.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
            Sleep(0.3);
            driver.ExecuteScript("arguments[0].click();", element);
            return true;
        }
        catch
        {
            try
            {
                element.Click();
                return true;
            }
            catch { return false; }
        }
    }

    private static bool SetInputText(ChromeDriver driver, IWebElement input, string text)
    {
        if (driver == null || input == null) return false;
        try
        {
            driver.ExecuteScript(@"
                arguments[0].focus();
                var isTextArea = arguments[0] instanceof HTMLTextAreaElement || (arguments[0].tagName && arguments[0].tagName.toUpperCase() === 'TEXTAREA');
                var proto = isTextArea ? window.HTMLTextAreaElement.prototype : window.HTMLInputElement.prototype;
                var setter = Object.getOwnPropertyDescriptor(proto, 'value')?.set;
                if (setter) {
                    setter.call(arguments[0], arguments[1]);
                } else {
                    arguments[0].value = arguments[1];
                }
                if (arguments[0]._valueTracker) {
                    arguments[0]._valueTracker.setValue('');
                }
                arguments[0].dispatchEvent(new Event('input', { bubbles: true }));
                arguments[0].dispatchEvent(new Event('change', { bubbles: true }));
            ", input, text ?? "");
            Sleep(0.3);
            try
            {
                // Send a space and backspace to trigger React input event listeners and autocomplete dropdowns
                input.SendKeys(" ");
                Sleep(0.1);
                input.SendKeys(Keys.Backspace);
            }
            catch { }
            Sleep(0.5);
            return true;
        }
        catch
        {
            try
            {
                input.Clear();
                input.SendKeys(text ?? "");
                return true;
            }
            catch { return false; }
        }
    }

    public static bool HandlePasswordReauth(Chrome chrome, string password = "")
    {
        try
        {
            var driver = chrome?.ChromeDriver_0;
            if (driver == null) return false;
            string pass = !string.IsNullOrEmpty(password) ? password : chrome.C234EEAA;
            if (string.IsNullOrEmpty(pass)) return false;

            var pwdInputs = driver.FindElements(By.CssSelector("input[type='password']"));
            foreach (var input in pwdInputs)
            {
                if (input.Displayed && input.Enabled)
                {
                    SetInputText(driver, input, pass);
                    Sleep(0.5);
                    var submitBtn = FindFirst(driver,
                        "//div[@role='button'][.//*[contains(text(), 'Tiếp tục') or contains(text(), 'Continue') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm') or contains(text(), 'Gửi') or contains(text(), 'Submit') or contains(text(), 'Đăng nhập') or text()='OK']]",
                        "//button[@type='submit' or .//*[contains(text(), 'Tiếp tục') or contains(text(), 'Continue') or contains(text(), 'Xác nhận') or contains(text(), 'Confirm')]]");
                    if (submitBtn != null)
                    {
                        ClickJs(driver, submitBtn);
                        Sleep(2.5);
                        return true;
                    }
                    else
                    {
                        try
                        {
                            input.SendKeys(Keys.Enter);
                            Sleep(2.5);
                            return true;
                        }
                        catch { }
                    }
                }
            }
        }
        catch { }
        return false;
    }

    #region 1. Update Bio
    public static bool UpdateBio(Chrome chrome, string bio)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        if (string.IsNullOrEmpty(bio)) return true; // Cấu hình không có bio -> bỏ qua an toàn, không kẹt
        var driver = chrome.ChromeDriver_0;

        try
        {
            chrome.method_12("https://www.facebook.com/me");
            Sleep(2.5);
            DismissPopups(chrome);

            // 1. Kiểm tra xem textarea đã mở sẵn chưa, nếu chưa thì tìm và bấm Edit bio / Add bio
            for (int r = 0; r < 4; r++)
            {
                object openRes = chrome.method_14(@"
                    (() => {
                        var ta = document.querySelector('textarea');
                        if (ta && ta.offsetParent !== null) return 'already_open';

                        var buttons = Array.from(document.querySelectorAll('div[role=""button""], button, span'));
                        for (var b of buttons) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'edit bio' || t === 'add bio' || 
                                t === 'chỉnh sửa tiểu sử' || t === 'thêm tiểu sử' || 
                                t === 'thêm phần giới thiệu' || t === 'chỉnh sửa phần giới thiệu' ||
                                t.includes('edit bio') || t.includes('add bio') || 
                                t.includes('chỉnh sửa tiểu sử') || t.includes('thêm tiểu sử') ||
                                t.includes('thêm phần giới thiệu') || t.includes('chỉnh sửa phần giới thiệu')) {
                                var clickable = b.closest('div[role=""button""]') || b.closest('button') || b;
                                clickable.scrollIntoView({block: 'center'});
                                clickable.click();
                                return 'clicked';
                            }
                        }

                        // Fallback: click 'Chỉnh sửa trang cá nhân' / 'Edit profile'
                        for (var b of buttons) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'edit profile' || t === 'chỉnh sửa trang cá nhân' || t.includes('edit profile') || t.includes('chỉnh sửa trang cá nhân')) {
                                var clickable = b.closest('div[role=""button""]') || b;
                                clickable.scrollIntoView({block: 'center'});
                                clickable.click();
                                return 'clicked_edit_profile';
                            }
                        }

                        return 'not_found';
                    })()
                ");

                if (openRes != null && openRes.ToString() == "clicked_edit_profile")
                {
                    Sleep(2.0);
                    // Click edit bio inside dialog
                    chrome.method_14(@"
                        (() => {
                            var dialogBtns = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button, div[role=""dialog""] span'));
                            for (var b of dialogBtns) {
                                var t = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase();
                                if (t.includes('thêm tiểu sử') || t.includes('chỉnh sửa tiểu sử') || t.includes('add bio') || t.includes('edit bio') || t.includes('thêm') || t.includes('add')) {
                                    var clickable = b.closest('div[role=""button""]') || b;
                                    clickable.click();
                                    return 'clicked_sub';
                                }
                            }
                            return 'none';
                        })()
                    ");
                    Sleep(1.5);
                    break;
                }

                if (openRes != null && (openRes.ToString() == "clicked" || openRes.ToString() == "already_open"))
                {
                    Sleep(1.5);
                    break;
                }
                Sleep(1.0);
            }

            // 2. Điền text vào textarea bằng JS
            string cleanBio = bio.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n");
            chrome.method_14(@"
                (() => {
                    var ta = document.querySelector('textarea, div[role=""textbox""][contenteditable=""true""]');
                    if (!ta) return 'no_textarea';
                    ta.focus();
                    ta.scrollIntoView({block: 'center'});
                    if (ta.getAttribute('contenteditable') === 'true') {
                        document.execCommand('selectAll', false, null);
                        document.execCommand('insertText', false, '" + cleanBio + @"');
                    } else {
                        var setter = Object.getOwnPropertyDescriptor(window.HTMLTextAreaElement.prototype, 'value')?.set;
                        if (setter) {
                            setter.call(ta, '" + cleanBio + @"');
                        } else {
                            ta.value = '" + cleanBio + @"';
                        }
                    }
                    if (ta._valueTracker) {
                        ta._valueTracker.setValue('');
                    }
                    ta.dispatchEvent(new Event('input', { bubbles: true }));
                    ta.dispatchEvent(new Event('change', { bubbles: true }));
                    return 'filled';
                })()
            ");

            // Fallback điền bằng Selenium
            var textarea = FindFirst(driver, "//textarea", "//div[@role='textbox' and @contenteditable='true']");
            if (textarea != null)
            {
                try
                {
                    textarea.Click();
                    textarea.SendKeys(Keys.Control + "a");
                    textarea.SendKeys(Keys.Backspace);
                    textarea.SendKeys(bio);
                    Sleep(0.3);
                    textarea.SendKeys(" ");
                    textarea.SendKeys(Keys.Backspace);
                }
                catch { }
            }
            Sleep(1.0);

            // 3. Bấm nút Save / Lưu
            bool saved = false;
            for (int wait = 0; wait < 12; wait++)
            {
                object clickSave = chrome.method_14(@"
                    (() => {
                        var ta = document.querySelector('textarea');
                        var container = ta ? (ta.closest('form') || ta.parentElement.parentElement.parentElement) : document;
                        var btns = Array.from((container || document).querySelectorAll('div[role=""button""], button'));
                        for (var b of btns) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'save' || t === 'lưu' || t === 'lưu thay đổi' || t === 'save changes') {
                                if (b.getAttribute('aria-disabled') === 'true' || b.disabled) {
                                    return 'disabled';
                                }
                                b.scrollIntoView({block: 'center'});
                                b.click();
                                return 'clicked';
                            }
                        }
                        var allBtns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                        for (var b of allBtns) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'save' || t === 'lưu') {
                                if (b.getAttribute('aria-disabled') === 'true' || b.disabled) {
                                    return 'disabled';
                                }
                                b.scrollIntoView({block: 'center'});
                                b.click();
                                return 'clicked';
                            }
                        }
                        return 'not_found';
                    })()
                ");

                if (clickSave != null && clickSave.ToString() == "clicked")
                {
                    saved = true;
                    Sleep(2.0);
                    break;
                }
                Sleep(1.0);
            }

            if (!saved)
            {
                var btnSave = FindFirst(driver,
                    "//div[@role='button'][.//*[text()='Save' or text()='Lưu']]",
                    "//button[.//*[text()='Save' or text()='Lưu']]",
                    "//*[@aria-label='Save' or @aria-label='Lưu']");
                if (btnSave != null)
                {
                    ClickJs(driver, btnSave);
                    Sleep(2.0);
                    saved = true;
                }
            }

            // Chờ xác nhận textarea đóng
            for (int w = 0; w < 5; w++)
            {
                object taCheck = chrome.method_14("return document.querySelector('textarea') !== null ? 'yes' : 'no'");
                if (taCheck != null && taCheck.ToString() == "no")
                {
                    return true;
                }
                Sleep(1.0);
            }

            return saved;
        }
        catch { }
        return false;
    }
    #endregion

    #region 2. Update Work
    public static bool UpdateWork(Chrome chrome, string workName, int ifHaveAction)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        var driver = chrome.ChromeDriver_0;

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_work_and_education");
            Sleep(2.5);
            DismissPopups(chrome);

            // Nếu đã có thông tin: 1 = Không thêm nữa, 2 = Xóa thông tin cũ
            bool hasWork = driver.FindElements(By.XPath("//*[contains(text(), 'Works at ') or contains(text(), 'Làm việc tại ') or contains(text(), 'Từng làm việc tại')]")).Any(e => e.Displayed);

            if (hasWork && ifHaveAction == 1)
            {
                return true; // Bỏ qua nếu đã có
            }

            if (hasWork && ifHaveAction == 2)
            {
                // Xóa công việc cũ
                DeleteWorkOrEduItem(driver, "Works at", "Làm việc tại", "Delete workplace", "Xóa nơi làm việc");
            }

            if (string.IsNullOrEmpty(workName)) return true;

            // Bấm nút "Add a workplace" / "Thêm nơi làm việc"
            var btnAdd = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add a workplace') or contains(text(), 'Thêm nơi làm việc') or contains(text(), 'Thêm công việc')]]",
                "//*[text()='Add a workplace' or text()='Thêm nơi làm việc']");

            if (btnAdd != null)
            {
                ClickJs(driver, btnAdd);
                Sleep(1.5);
            }

            // Nhập tên công ty
            var input = FindFirst(driver,
                "//input[contains(@aria-label, 'Company') or contains(@aria-label, 'Công ty')]",
                "//input[contains(@placeholder, 'What company') or contains(@placeholder, 'Công ty')]",
                "//div[@role='dialog']//input[@type='text']");

            if (input == null) return false;

            SetInputText(driver, input, workName);
            Sleep(1.5);

            // Chọn gợi ý đầu tiên nếu có listbox
            SelectFirstAutocompleteOption(driver);

            // Bấm Lưu
            return ClickSaveButton(driver);
        }
        catch { }
        return false;
    }
    #endregion

    #region 3. Update High School
    public static bool UpdateHighSchool(Chrome chrome, string schoolName, int ifHaveAction)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        var driver = chrome.ChromeDriver_0;

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_work_and_education");
            Sleep(2.5);
            DismissPopups(chrome);

            bool hasSchool = driver.FindElements(By.XPath("//*[contains(text(), 'Went to ') or contains(text(), 'Từng học tại ') or contains(text(), 'Học tại ')]")).Any(e => e.Displayed);

            if (hasSchool && ifHaveAction == 1) return true;
            if (hasSchool && ifHaveAction == 2)
            {
                DeleteWorkOrEduItem(driver, "Went to", "Từng học tại", "Delete school", "Xóa trường học");
            }

            if (string.IsNullOrEmpty(schoolName)) return true;

            var btnAdd = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add high school') or contains(text(), 'Thêm trường trung học')]]",
                "//*[text()='Add high school' or text()='Thêm trường trung học']");

            if (btnAdd != null)
            {
                ClickJs(driver, btnAdd);
                Sleep(1.5);
            }

            var input = FindFirst(driver,
                "//input[contains(@aria-label, 'School') or contains(@aria-label, 'Trường học')]",
                "//div[@role='dialog']//input[@type='text']");

            if (input == null) return false;

            SetInputText(driver, input, schoolName);
            Sleep(1.5);

            SelectFirstAutocompleteOption(driver);
            return ClickSaveButton(driver);
        }
        catch { }
        return false;
    }
    #endregion

    #region 4. Update College
    public static bool UpdateCollege(Chrome chrome, string collegeName, int ifHaveAction)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        var driver = chrome.ChromeDriver_0;

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_work_and_education");
            Sleep(2.5);
            DismissPopups(chrome);

            bool hasCollege = driver.FindElements(By.XPath("//*[contains(text(), 'Studied at ') or contains(text(), 'Học đại học tại ') or contains(text(), 'Đã học tại ')]")).Any(e => e.Displayed);

            if (hasCollege && ifHaveAction == 1) return true;
            if (hasCollege && ifHaveAction == 2)
            {
                DeleteWorkOrEduItem(driver, "Studied at", "Học đại học tại", "Delete school", "Xóa trường học");
            }

            if (string.IsNullOrEmpty(collegeName)) return true;

            var btnAdd = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add college') or contains(text(), 'Thêm trường đại học') or contains(text(), 'Thêm trường cao đẳng')]]",
                "//*[text()='Add college' or text()='Thêm trường đại học']");

            if (btnAdd != null)
            {
                ClickJs(driver, btnAdd);
                Sleep(1.5);
            }

            var input = FindFirst(driver,
                "//input[contains(@aria-label, 'School') or contains(@aria-label, 'Trường học')]",
                "//div[@role='dialog']//input[@type='text']");

            if (input == null) return false;

            SetInputText(driver, input, collegeName);
            Sleep(1.5);

            SelectFirstAutocompleteOption(driver);
            return ClickSaveButton(driver);
        }
        catch { }
        return false;
    }
    #endregion

    #region 5. Update Current City
    public static bool UpdateCurrentCity(Chrome chrome, string cityName)
    {
        if (chrome?.ChromeDriver_0 == null || string.IsNullOrEmpty(cityName)) return false;
        var driver = chrome.ChromeDriver_0;

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_places");
            Sleep(2.5);
            DismissPopups(chrome);

            var btnAdd = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add current city') or contains(text(), 'Thêm thành phố hiện tại') or contains(text(), 'Thêm nơi ở hiện tại')]]",
                "//div[@aria-label='Options' or @aria-label='Tùy chọn'][ancestor::*[contains(., 'Current city') or contains(., 'Thành phố hiện tại')]]");

            if (btnAdd != null)
            {
                ClickJs(driver, btnAdd);
                Sleep(1.5);

                var editOption = FindFirst(driver, "//div[@role='menuitem'][.//*[contains(text(), 'Edit current city') or contains(text(), 'Chỉnh sửa')]]");
                if (editOption != null)
                {
                    ClickJs(driver, editOption);
                    Sleep(1.5);
                }
            }

            var input = FindFirst(driver,
                "//input[contains(@aria-label, 'Current city') or contains(@aria-label, 'Thành phố hiện tại') or contains(@aria-label, 'City')]",
                "//div[@role='dialog']//input[@type='text']");

            if (input == null) return false;

            SetInputText(driver, input, cityName);
            Sleep(1.5);

            SelectFirstAutocompleteOption(driver);
            return ClickSaveButton(driver);
        }
        catch { }
        return false;
    }
    #endregion

    #region 6. Update Hometown
    public static bool UpdateHometown(Chrome chrome, string hometownName)
    {
        if (chrome?.ChromeDriver_0 == null || string.IsNullOrEmpty(hometownName)) return false;
        var driver = chrome.ChromeDriver_0;

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_places");
            Sleep(2.5);
            DismissPopups(chrome);

            var btnAdd = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add hometown') or contains(text(), 'Thêm quê quán')]]",
                "//div[@aria-label='Options' or @aria-label='Tùy chọn'][ancestor::*[contains(., 'Hometown') or contains(., 'Quê quán')]]");

            if (btnAdd != null)
            {
                ClickJs(driver, btnAdd);
                Sleep(1.5);

                var editOption = FindFirst(driver, "//div[@role='menuitem'][.//*[contains(text(), 'Edit hometown') or contains(text(), 'Chỉnh sửa quê quán')]]");
                if (editOption != null)
                {
                    ClickJs(driver, editOption);
                    Sleep(1.5);
                }
            }

            var input = FindFirst(driver,
                "//input[contains(@aria-label, 'Hometown') or contains(@aria-label, 'Quê quán')]",
                "//div[@role='dialog']//input[@type='text']");

            if (input == null) return false;

            SetInputText(driver, input, hometownName);
            Sleep(1.5);

            SelectFirstAutocompleteOption(driver);
            return ClickSaveButton(driver);
        }
        catch { }
        return false;
    }
    #endregion

    #region 7. Update Relationship
    public static bool UpdateRelationship(Chrome chrome, string relCode)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        var driver = chrome.ChromeDriver_0;

        var map = new Dictionary<string, (string en, string vi)>
        {
            { "1", ("Single", "Độc thân") },
            { "2", ("In a relationship", "Hẹn hò") },
            { "3", ("In an open relationship", "Có mối quan hệ mở") },
            { "4", ("Married", "Đã kết hôn") },
            { "5", ("Engaged", "Đã đính hôn") },
            { "6", ("It's complicated", "Mối quan hệ phức tạp") },
            { "7", ("Widowed", "Góa") },
            { "8", ("Separated", "Ly thân") },
            { "9", ("Divorced", "Đã ly hôn") },
            { "10", ("In a civil union", "Đăng ký chung sống") },
            { "11", ("In a domestic partnership", "Chung sống như vợ chồng") }
        };

        if (string.IsNullOrEmpty(relCode) || relCode == "-1")
        {
            var keys = map.Keys.ToList();
            relCode = keys[new Random().Next(keys.Count)];
        }

        if (!map.ContainsKey(relCode)) relCode = "1";
        var pair = map[relCode];

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_family_and_relationships");
            Sleep(2.5);
            DismissPopups(chrome);

            var btnAdd = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add a relationship status') or contains(text(), 'Thêm tình trạng quan hệ')]]",
                "//div[contains(@aria-label, 'Edit relationship') or contains(@aria-label, 'Chỉnh sửa tình trạng quan hệ')]",
                "//div[@aria-label='Options' or @aria-label='Tùy chọn'][ancestor::*[contains(., 'Relationship') or contains(., 'Tình trạng quan hệ')]]");

            if (btnAdd != null)
            {
                ClickJs(driver, btnAdd);
                Sleep(1.5);
            }

            // Click mở combobox
            var combo = FindFirst(driver,
                "//div[@role='combobox' or @aria-haspopup='listbox']",
                "//div[@role='dialog']//div[@role='combobox']");

            if (combo != null)
            {
                ClickJs(driver, combo);
                Sleep(1.0);

                var option = FindFirst(driver,
                    $"//div[@role='option'][.//*[contains(text(), '{pair.en}') or contains(text(), '{pair.vi}')]]",
                    $"//*[text()='{pair.en}' or text()='{pair.vi}']");

                if (option != null)
                {
                    ClickJs(driver, option);
                    Sleep(1.0);
                }
            }

            return ClickSaveButton(driver);
        }
        catch { }
        return false;
    }
    #endregion

    #region 8. Update Gender
    public static bool UpdateGender(Chrome chrome, string genderCode)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        var driver = chrome.ChromeDriver_0;

        string targetEn = (genderCode == "2") ? "Male" : "Female";
        string targetVi = (genderCode == "2") ? "Nam" : "Nữ";

        if (genderCode == "-1" || string.IsNullOrEmpty(genderCode))
        {
            if (new Random().Next(2) == 0) { targetEn = "Male"; targetVi = "Nam"; }
            else { targetEn = "Female"; targetVi = "Nữ"; }
        }

        try
        {
            chrome.method_12("https://www.facebook.com/me/about_contact_and_basic_info");
            Sleep(2.5);
            DismissPopups(chrome);

            var btnEdit = FindFirst(driver,
                "//div[@role='button'][.//*[contains(text(), 'Edit') or contains(text(), 'Chỉnh sửa')] and ancestor::*[contains(., 'Gender') or contains(., 'Giới tính')]]",
                "//div[contains(@aria-label, 'Edit gender') or contains(@aria-label, 'Chỉnh sửa giới tính') or contains(@aria-label, 'Add your gender') or contains(@aria-label, 'Thêm giới tính')]",
                "//span[contains(text(), 'Add your gender') or contains(text(), 'Thêm giới tính')]");

            if (btnEdit != null)
            {
                ClickJs(driver, btnEdit);
                Sleep(1.5);

                var combo = FindFirst(driver, "//div[@role='combobox' or @aria-haspopup='listbox']");
                if (combo != null)
                {
                    ClickJs(driver, combo);
                    Sleep(1.0);
                }

                var genderOption = FindFirst(driver,
                    $"//div[@role='option'][.//*[contains(text(), '{targetEn}') or contains(text(), '{targetVi}')]]",
                    $"//label[.//*[contains(text(), '{targetEn}') or contains(text(), '{targetVi}')]]",
                    $"//input[@type='radio'][ancestor::*[contains(., '{targetEn}') or contains(., '{targetVi}')]]");

                if (genderOption != null)
                {
                    ClickJs(driver, genderOption);
                    Sleep(1.0);
                }

                return ClickSaveButton(driver);
            }
        }
        catch { }
        return false;
    }
    #endregion

    #region 9. Update Birthday (Accounts Center + Reauth Protection)
    public static bool UpdateBirthday(Chrome chrome, string day, string month, string year)
    {
        if (chrome?.ChromeDriver_0 == null) return false;
        var driver = chrome.ChromeDriver_0;

        var monthMap = new Dictionary<string, string>
        {
            { "1", "January" }, { "2", "February" }, { "3", "March" }, { "4", "April" },
            { "5", "May" }, { "6", "June" }, { "7", "July" }, { "8", "August" },
            { "9", "September" }, { "10", "October" }, { "11", "November" }, { "12", "December" }
        };

        day = (day ?? "").Trim();
        month = (month ?? "").Trim();
        year = (year ?? "").Trim();

        string monthName = monthMap.ContainsKey(month) ? monthMap[month] : "January";

        try
        {
            chrome.method_12("https://accountscenter.facebook.com/personal_info/birthday/?locale=en_US");
            Sleep(3.0);
            DismissPopups(chrome);

            // Kiểm tra và xử lý popup đòi lại mật khẩu
            HandlePasswordReauth(chrome);

            // Tìm nút Edit
            var btnEdit = FindFirst(driver,
                "//div[@role='button'][.//*[text()='Edit' or text()='Chỉnh sửa']]",
                "//*[@role='button'][.//*[contains(text(), 'Birthday') or contains(text(), 'Ngày sinh')]]");

            if (btnEdit != null)
            {
                ClickJs(driver, btnEdit);
                Sleep(2.0);
                HandlePasswordReauth(chrome);
            }

            // Chọn Month
            var comboMonth = FindFirst(driver, "//div[@role='combobox'][.//*[contains(text(), 'Month') or contains(text(), 'Tháng')]]");
            if (comboMonth != null)
            {
                ClickJs(driver, comboMonth);
                Sleep(1.0);
                var optMonth = FindFirst(driver, $"//div[@role='option'][.//*[contains(text(), '{monthName}') or contains(text(), 'Tháng {month}')]]");
                if (optMonth != null) ClickJs(driver, optMonth);
                Sleep(0.5);
            }

            // Chọn Day
            var comboDay = FindFirst(driver, "//div[@role='combobox'][.//*[contains(text(), 'Day') or contains(text(), 'Ngày')]]");
            if (comboDay != null)
            {
                ClickJs(driver, comboDay);
                Sleep(1.0);
                var optDay = FindFirst(driver, $"//div[@role='option'][.//*[text()='{day}']]");
                if (optDay != null) ClickJs(driver, optDay);
                Sleep(0.5);
            }

            // Chọn Year
            var comboYear = FindFirst(driver, "//div[@role='combobox'][.//*[contains(text(), 'Year') or contains(text(), 'Năm')]]");
            if (comboYear != null)
            {
                ClickJs(driver, comboYear);
                Sleep(1.0);
                var optYear = FindFirst(driver, $"//div[@role='option'][.//*[text()='{year}']]");
                if (optYear != null) ClickJs(driver, optYear);
                Sleep(0.5);
            }

            // Bấm Save
            var btnSave = FindFirst(driver,
                "//div[@role='button'][.//*[text()='Save' or text()='Lưu']]",
                "//button[contains(text(), 'Save') or contains(text(), 'Lưu')]");

            if (btnSave != null)
            {
                ClickJs(driver, btnSave);
                Sleep(2.0);

                // Xác nhận Confirm modal
                var btnConfirm = FindFirst(driver,
                    "//div[@role='dialog']//div[@role='button'][.//*[text()='Confirm' or text()='Xác nhận']]",
                    "//div[@role='button'][.//*[text()='Confirm' or text()='Xác nhận']]");

                if (btnConfirm != null)
                {
                    ClickJs(driver, btnConfirm);
                    Sleep(2.5);
                }

                HandlePasswordReauth(chrome);
                return true;
            }
        }
        catch { }
        return false;
    }
    #endregion

    #region 10. Update Nickname (Profile Nickname + Username Fallback)
    public static bool UpdateNickname(Chrome chrome, string nickname)
    {
        if (chrome?.ChromeDriver_0 == null || string.IsNullOrEmpty(nickname)) return false;
        var driver = chrome.ChromeDriver_0;

        try
        {
            // 1. Ưu tiên đặt Biệt danh hiển thị trên trang cá nhân (Other names / Nickname)
            chrome.method_12("https://www.facebook.com/me/about_details");
            Sleep(2.5);
            DismissPopups(chrome);

            var btnAddNick = FindFirst(driver,
                "//div[@role='button' or @role='link'][.//*[contains(text(), 'Add a nickname') or contains(text(), 'Thêm biệt danh') or contains(text(), 'Thêm tên thường gọi')]]",
                "//*[contains(text(), 'Add a nickname') or contains(text(), 'Thêm biệt danh')]");

            if (btnAddNick != null)
            {
                ClickJs(driver, btnAddNick);
                Sleep(1.5);

                var input = FindFirst(driver,
                    "//input[contains(@aria-label, 'Name') or contains(@aria-label, 'Tên')]",
                    "//input[contains(@placeholder, 'What is your nickname') or contains(@placeholder, 'Biệt danh')]",
                    "//div[@role='dialog']//input[@type='text']");

                if (input != null)
                {
                    SetInputText(driver, input, nickname);
                    Sleep(1.0);

                    // Tích checkbox hiển thị đầu trang cá nhân nếu có
                    var ckbShow = FindFirst(driver, "//input[@type='checkbox']");
                    if (ckbShow != null && !ckbShow.Selected)
                    {
                        ClickJs(driver, ckbShow);
                        Sleep(0.5);
                    }

                    return ClickSaveButton(driver);
                }
            }

            // 2. Fallback: Nếu không đặt được ở profile, đặt Username qua Accounts Center
            string uid = chrome.FB94939A();
            if (!string.IsNullOrEmpty(uid))
            {
                chrome.method_12($"https://accountscenter.facebook.com/profiles/{uid}/username/?entrypoint=fb_account_center&locale=en_US");
                Sleep(2.5);
                HandlePasswordReauth(chrome);

                var userInput = FindFirst(driver, "//input[./following-sibling::*[contains(text(), 'Username')]]", "//input[@name='username' or @type='text']");
                if (userInput != null)
                {
                    SetInputText(driver, userInput, nickname);
                    Sleep(1.5);

                    var btnDone = FindFirst(driver, "//div[@role='button'][.//*[text()='Done' or text()='Xong']]");
                    if (btnDone != null && btnDone.Enabled)
                    {
                        ClickJs(driver, btnDone);
                        Sleep(2.5);
                        HandlePasswordReauth(chrome);
                        return true;
                    }
                }
            }
        }
        catch { }
        return false;
    }
    #endregion

    #region Helper Functions
    private static void SelectFirstAutocompleteOption(ChromeDriver driver)
    {
        try
        {
            var option = FindFirst(driver,
                "//div[@role='listbox']//div[@role='option']",
                "//ul[@role='listbox']//li",
                "//div[@role='listbox']//div[@role='button']",
                "//div[@role='listbox']//div[contains(@class, 'x1i10hfl')]",
                "//div[contains(@class, 'x1n2onr6')]//div[@role='button']");

            if (option != null)
            {
                ClickJs(driver, option);
                Sleep(1.5);
            }
            else
            {
                var activeEl = driver.SwitchTo().ActiveElement();
                if (activeEl != null)
                {
                    activeEl.SendKeys(Keys.ArrowDown);
                    Sleep(0.3);
                    activeEl.SendKeys(Keys.Enter);
                    Sleep(1.0);
                }
            }
        }
        catch { }
    }

    private static bool ClickSaveButton(ChromeDriver driver)
    {
        if (driver == null) return false;
        try
        {
            for (int r = 0; r < 12; r++)
            {
                // 1. Try clicking via JavaScript with aria-disabled & progress check
                object jsRes = driver.ExecuteScript(@"
                    var dialogs = document.querySelectorAll('div[role=""dialog""]');
                    var containers = dialogs.length > 0 ? Array.from(dialogs) : [document];
                    for (var c of containers) {
                        var btns = Array.from(c.querySelectorAll('div[role=""button""], button'));
                        for (var b of btns) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'save' || t === 'lưu' || t === 'save changes' || t === 'lưu thay đổi' || t === 'done' || t === 'xong' || t === 'hoàn tất' || t === 'cập nhật' || t === 'update' || t === 'áp dụng' || t === 'apply' || t.includes('lưu') || t.includes('save')) {
                                if (b.getAttribute('aria-disabled') === 'true' || b.disabled || c.querySelector('[role=""progressbar""], [data-visualcompletion=""loading-state""], [aria-busy=""true""]')) {
                                    return 'disabled';
                                }
                                b.scrollIntoView({block: 'center'});
                                b.click();
                                return 'clicked';
                            }
                        }
                    }
                    return 'not_found';
                ");

                if (jsRes != null && jsRes.ToString() == "clicked")
                {
                    Sleep(2.5);
                    return true;
                }

                if (jsRes != null && jsRes.ToString() == "disabled")
                {
                    Sleep(0.8);
                    continue;
                }

                // 2. Fallback to Selenium FindFirst
                var btnSave = FindFirst(driver,
                    "//div[@role='dialog']//div[@role='button'][.//*[text()='Save' or text()='Lưu' or text()='Save changes' or text()='Lưu thay đổi'] and not(@aria-disabled='true')]",
                    "//div[@role='dialog']//button[.//*[text()='Save' or text()='Lưu'] and not(@disabled)]",
                    "//div[@role='button'][.//*[text()='Save' or text()='Lưu'] and not(@aria-disabled='true')]",
                    "//button[contains(text(), 'Save') or contains(text(), 'Lưu')]",
                    "//*[@aria-label='Save' or @aria-label='Lưu']");

                if (btnSave != null && btnSave.Displayed && btnSave.Enabled)
                {
                    ClickJs(driver, btnSave);
                    Sleep(2.5);
                    return true;
                }

                Sleep(0.5);
            }
        }
        catch { }
        return false;
    }

    private static void DeleteWorkOrEduItem(ChromeDriver driver, string enAnchor, string viAnchor, string enDelete, string viDelete)
    {
        try
        {
            var menuBtn = FindFirst(driver,
                $"//div[@aria-label='Options' or @aria-label='Tùy chọn'][ancestor::*[contains(., '{enAnchor}') or contains(., '{viAnchor}')]]",
                $"//div[@role='button'][.//*[contains(@class, 'x1i10hfl')] and ancestor::*[contains(., '{enAnchor}') or contains(., '{viAnchor}')]]");

            if (menuBtn != null)
            {
                ClickJs(driver, menuBtn);
                Sleep(1.5);

                var deleteItem = FindFirst(driver,
                    $"//div[@role='menuitem'][.//*[contains(text(), '{enDelete}') or contains(text(), '{viDelete}') or contains(text(), 'Delete') or contains(text(), 'Xóa')]]");

                if (deleteItem != null)
                {
                    ClickJs(driver, deleteItem);
                    Sleep(1.5);

                    var confirmBtn = FindFirst(driver,
                        "//div[@role='dialog']//div[@role='button'][.//*[contains(text(), 'Confirm') or contains(text(), 'Xác nhận') or contains(text(), 'Delete') or contains(text(), 'Xóa')]]");
                    if (confirmBtn != null)
                    {
                        ClickJs(driver, confirmBtn);
                        Sleep(2.0);
                    }
                }
            }
        }
        catch { }
    }
    #endregion

    #region Action 11: UploadAvatar (Meta Comet WWW & mbasic)
    public static bool UploadAvatar(Chrome chrome, string imagePath, bool skipIfHave = false, bool preferMbasic = false, bool skipCrop = true, Action<string> log = null)
    {
        if (chrome == null)
        {
            log?.Invoke("Lỗi: Chrome chưa khởi tạo!");
            return false;
        }

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            log?.Invoke("Lỗi: File ảnh không tồn tại: " + imagePath);
            return false;
        }

        try
        {
            // 1. Nếu ưu tiên mbasic, thử chạy qua mbasic trước
            if (preferMbasic)
            {
                log?.Invoke("Đang tải ảnh qua mbasic...");
                if (UploadAvatarMbasic(chrome, imagePath, log))
                {
                    log?.Invoke("Up avatar mbasic thành công!");
                    return true;
                }
                log?.Invoke("mbasic không khả dụng, chuyển sang Meta Comet WWW...");
            }

            // 2. Tải ảnh qua Meta Comet WWW (facebook.com/me)
            return UploadAvatarWWW(chrome, imagePath, skipIfHave, skipCrop, log);
        }
        catch (Exception ex)
        {
            log?.Invoke("Ngoại lệ Up Avatar: " + ex.Message);
            return false;
        }
    }

    private static bool UploadAvatarWWW(Chrome chrome, string imagePath, bool skipIfHave, bool skipCrop, Action<string> log)
    {
        log?.Invoke("Mở trang cá nhân...");
        chrome.method_12("https://www.facebook.com/me");
        Sleep(3.5);
        DismissPopups(chrome);

        // 1. Kiểm tra nếu đã có avatar và người dùng chọn bỏ qua
        if (skipIfHave)
        {
            log?.Invoke("Kiểm tra avatar hiện tại...");
            try
            {
                object hasAvt = chrome.method_14(@"
                    (() => {
                        var img = document.querySelector('svg image, div[aria-label*=""đại diện""] img, div[aria-label*=""profile""] img');
                        if (img) {
                            var src = img.getAttribute('xlink:href') || img.getAttribute('href') || img.src || '';
                            if (src && !src.includes('rsrc.php') && !src.includes('silhouette') && (src.includes('scontent') || src.includes('fbcdn.net'))) {
                                return 'yes';
                            }
                        }
                        return 'no';
                    })()
                ");
                if (hasAvt != null && hasAvt.ToString() == "yes")
                {
                    log?.Invoke("Tài khoản đã có avatar, bỏ qua...");
                    return true;
                }
            }
            catch { }
        }

        // 2. Mở popup / menu đổi ảnh đại diện
        log?.Invoke("Mở hộp thoại chọn avatar...");
        // First ensure standard window size (500x700) for reliable layout
        try { chrome.method_53(); } catch { }
        Sleep(1.0);
        object clickCam = chrome.method_14(@"
            (() => {
                // Strategy 1: aria-label match on buttons (covers EN, VI, new 2026 Meta labels)
                var buttons = Array.from(document.querySelectorAll('div[role=""button""], button'));
                var ariaKeywords = [
                    'cập nhật ảnh đại diện', 'update profile picture',
                    'chỉnh sửa ảnh đại diện', 'edit profile picture',
                    'hành động với ảnh đại diện', 'profile picture actions',
                    'thay đổi ảnh đại diện', 'change profile picture',
                    'chọn ảnh đại diện', 'choose profile picture'
                ];
                for (var b of buttons) {
                    var aria = (b.getAttribute('aria-label') || '').toLowerCase();
                    for (var kw of ariaKeywords) {
                        if (aria.includes(kw)) {
                            b.click();
                            return 'clicked_aria';
                        }
                    }
                }

                // Strategy 2: SVG camera icon inside profile header area
                var svgs = document.querySelectorAll('svg');
                for (var s of svgs) {
                    var btn = s.closest('div[role=""button""]');
                    if (btn) {
                        var rect = btn.getBoundingClientRect();
                        if (rect.top > 20 && rect.top < 750 && rect.left > 0 && rect.left < 900 && rect.width < 200 && rect.height < 200) {
                            var text = (btn.getAttribute('aria-label') || '').toLowerCase();
                            if (text.includes('ảnh') || text.includes('photo') || text.includes('picture') || text.includes('avatar') || text.includes('profile') || text.includes('camera') || text.includes('đại diện')) {
                                btn.click();
                                return 'clicked_svg';
                            }
                        }
                    }
                }

                // Strategy 3: Click the avatar image container itself (new Meta layout puts camera overlay on the image)
                var profileImgs = document.querySelectorAll('svg image[preserveAspectRatio], image[xlink\\:href], div[data-visualcompletion] svg image');
                for (var img of profileImgs) {
                    var parent = img.closest('div[role=""button""]') || img.closest('a[role=""link""]');
                    if (parent) {
                        var rect = parent.getBoundingClientRect();
                        if (rect.top > 20 && rect.top < 600 && rect.width > 60 && rect.width < 300) {
                            parent.click();
                            return 'clicked_img_container';
                        }
                    }
                }

                return 'not_found';
            })()
        ");

        Sleep(2.0);

        // 2b. Nếu mở ra menu dropdown (chọn ảnh đại diện / xem ảnh đại diện / tải ảnh)
        chrome.method_14(@"
            (() => {
                var containers = document.querySelectorAll('div[role=""menu""], div[role=""dialog""], div[data-pagelet*=""root""]');
                for (var m of containers) {
                    var items = Array.from(m.querySelectorAll('div[role=""menuitem""], div[role=""button""], span'));
                    for (var it of items) {
                        var text = (it.innerText || it.getAttribute('aria-label') || '').toLowerCase();
                        if (text.includes('chọn ảnh đại diện') || text.includes('choose profile picture') || 
                            text.includes('cập nhật ảnh đại diện') || text.includes('update profile picture') ||
                            text.includes('tải ảnh lên') || text.includes('upload photo') || text.includes('tải ảnh')) {
                            var clickable = it.closest('div[role=""menuitem""]') || it.closest('div[role=""button""]') || it;
                            clickable.click();
                            return 'clicked_menu';
                        }
                    }
                }
                return 'none';
            })()
        ");
        Sleep(2.0);

        // 2c. Fallback nếu chưa mở được dialog: Bấm nút "Chỉnh sửa trang cá nhân" / "Edit profile"
        chrome.method_14(@"
            (() => {
                var dialogs = document.querySelectorAll('div[role=""dialog""]');
                if (dialogs.length > 0) return 'already_dialog';
                var allBtns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                for (var b of allBtns) {
                    var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                    if (t === 'chỉnh sửa trang cá nhân' || t === 'edit profile' || t.includes('chỉnh sửa trang cá nhân') || t.includes('edit profile')) {
                        b.click();
                        return 'clicked_edit_profile';
                    }
                }
                return 'none';
            })()
        ");
        Sleep(2.0);

        // 3. Hiển thị input[type='file'] để tương tác qua Selenium
        log?.Invoke("Đang tải ảnh lên...");
        chrome.method_14(@"
            (() => {
                var inputs = document.querySelectorAll('input[type=""file""]');
                for (var i = 0; i < inputs.length; i++) {
                    inputs[i].style.display = 'block';
                    inputs[i].style.visibility = 'visible';
                    inputs[i].style.opacity = '1';
                    inputs[i].style.position = 'fixed';
                    inputs[i].style.top = '10px';
                    inputs[i].style.left = '10px';
                    inputs[i].style.width = '120px';
                    inputs[i].style.height = '40px';
                    inputs[i].style.zIndex = '9999999';
                }
            })()
        ");

        // Nếu chưa có file input, thử bấm nút "Tải ảnh lên" hoặc nút "Thêm/Chỉnh sửa ảnh đại diện" trong dialog
        int fileCount = 0;
        int.TryParse(chrome.method_14("return document.querySelectorAll('input[type=\"file\"]').length")?.ToString(), out fileCount);
        if (fileCount == 0)
        {
            chrome.method_14(@"
                (() => {
                    var btns = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button, div[role=""dialog""] span'));
                    for (var b of btns) {
                        var t = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase();
                        if (t.includes('tải ảnh lên') || t.includes('upload photo') || t.includes('tải ảnh') || t.includes('upload') ||
                            t.includes('thêm ảnh') || t.includes('chỉnh sửa') || t.includes('edit')) {
                            var clickable = b.closest('div[role=""button""]') || b;
                            clickable.click();
                            return 'clicked';
                        }
                    }
                    return 'none';
                })()
            ");
            Sleep(1.5);
            chrome.method_14(@"
                (() => {
                    var inputs = document.querySelectorAll('input[type=""file""]');
                    for (var i = 0; i < inputs.length; i++) {
                        inputs[i].style.display = 'block';
                        inputs[i].style.visibility = 'visible';
                        inputs[i].style.opacity = '1';
                        inputs[i].style.position = 'fixed';
                        inputs[i].style.top = '10px';
                        inputs[i].style.left = '10px';
                        inputs[i].style.width = '120px';
                        inputs[i].style.height = '40px';
                        inputs[i].style.zIndex = '9999999';
                    }
                })()
            ");
        }

        var driver = chrome.ChromeDriver_0;
        if (driver == null)
        {
            log?.Invoke("Lỗi: Không tìm thấy ChromeDriver!");
            return false;
        }

        var fileInputs = driver.FindElements(By.CssSelector("div[role='dialog'] input[type='file'], input[type='file'][accept*='image'], input[type='file']"));
        if (fileInputs.Count == 0)
        {
            log?.Invoke("Không tìm thấy ô chọn file ảnh!");
            return false;
        }

        try
        {
            IWebElement targetInput = fileInputs[fileInputs.Count - 1];
            for (int i = fileInputs.Count - 1; i >= 0; i--)
            {
                try
                {
                    var parent = fileInputs[i].FindElement(By.XPath("ancestor::div[@role='dialog']"));
                    if (parent != null)
                    {
                        targetInput = fileInputs[i];
                        break;
                    }
                }
                catch { }
            }
            targetInput.SendKeys(imagePath);
        }
        catch (Exception ex)
        {
            try
            {
                fileInputs[0].SendKeys(imagePath);
            }
            catch
            {
                log?.Invoke("Lỗi gửi đường dẫn ảnh: " + ex.Message);
                return false;
            }
        }

        log?.Invoke("Chờ xử lý ảnh & bấm Lưu...");
        Sleep(3.0);

        // 3b. Bỏ qua cắt ảnh hoặc giữ nguyên khung (nếu được yêu cầu)
        if (skipCrop)
        {
            try
            {
                chrome.method_14(@"
                    (() => {
                        // Strategy 1: Click nút Bỏ qua cắt ảnh / Ảnh gốc / Original
                        var skipBtns = Array.from(document.querySelectorAll('div[role=""button""], button, span, a'));
                        for (var sk of skipBtns) {
                            var skt = (sk.innerText || sk.getAttribute('aria-label') || '').toLowerCase().trim();
                            if (skt === 'bỏ qua cắt ảnh' || skt === 'không cắt' || skt === 'skip cropping' || skt === 'ảnh gốc' || skt === 'original' || skt === 'chỉnh sửa ảnh' || skt.includes('bỏ qua cắt') || skt.includes('không cắt') || skt.includes('skip cropping')) {
                                var clk = sk.closest('div[role=""button""]') || sk.closest('button') || sk;
                                clk.click();
                                break;
                            }
                        }

                        // Strategy 2: Reset zoom slider về mức nhỏ nhất (0 / min) để giữ nguyên khung hình trọn vẹn
                        var sliders = document.querySelectorAll('input[type=""range""]');
                        for (var sl of sliders) {
                            sl.value = sl.min || '0';
                            sl.dispatchEvent(new Event('input', { bubbles: true }));
                            sl.dispatchEvent(new Event('change', { bubbles: true }));
                        }
                    })()
                ");
                Sleep(1.5);
            }
            catch { }
        }

        // 4. Bấm nút Lưu / Save trong popup Cắt ảnh đại diện (Xử lý chống đơ khi Facebook đang upload)
        bool clickedSave = false;
        for (int i = 0; i < 25; i++)
        {
            object res = chrome.method_14(@"
                (() => {
                    var dialogs = document.querySelectorAll('div[role=""dialog""]');
                    for (var d of dialogs) {
                        if (d.querySelector('[role=""progressbar""], [data-visualcompletion=""loading-state""], [aria-busy=""true""]')) {
                            return 'disabled'; // Image is still uploading to Facebook! Keep waiting!
                        }
                        var btns = Array.from(d.querySelectorAll('div[role=""button""], button'));
                        for (var b of btns) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'lưu' || t === 'save' || t === 'lưu thay đổi' || t === 'save changes' || t === 'xong' || t === 'done' || t === 'lưu ảnh đại diện' || t === 'save profile picture' || t === 'hoàn tất' || t === 'cập nhật' || t === 'update' || t === 'áp dụng' || t === 'apply' || t.includes('lưu') || t.includes('save')) {
                                if (b.getAttribute('aria-disabled') === 'true' || b.disabled) {
                                    return 'disabled';
                                }
                                b.scrollIntoView({block: 'center'});
                                b.click();
                                return 'clicked_dialog';
                            }
                        }
                    }
                    var allBtns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                    for (var b of allBtns) {
                        var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                        if (t === 'lưu' || t === 'save' || t === 'lưu thay đổi' || t === 'save changes' || t === 'xong' || t === 'done' || t === 'lưu ảnh đại diện' || t === 'save profile picture' || t === 'hoàn tất' || t === 'cập nhật' || t === 'update' || t === 'áp dụng' || t === 'apply' || t.includes('lưu') || t.includes('save')) {
                            if (b.getAttribute('aria-disabled') === 'true' || b.disabled || b.querySelector('[role=""progressbar""]')) {
                                return 'disabled';
                            }
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            return 'clicked_all';
                        }
                    }
                    return 'waiting';
                })()
            ");

            if (res != null && (res.ToString() == "clicked_dialog" || res.ToString() == "clicked_all"))
            {
                clickedSave = true;
                log?.Invoke("Đã bấm Lưu avatar, chờ xử lý...");
                Sleep(3.0);
                break;
            }

            // Fallback click trực tiếp qua Selenium nếu JS click bị nuốt
            try
            {
                var saveEl = FindFirst(driver,
                    "//div[@role='dialog']//div[@role='button'][.//*[text()='Lưu' or text()='Save' or text()='Lưu thay đổi' or text()='Save changes'] and not(@aria-disabled='true')]",
                    "//div[@role='dialog']//button[.//*[text()='Lưu' or text()='Save'] and not(@disabled)]");
                if (saveEl != null && saveEl.Displayed && saveEl.Enabled)
                {
                    ClickJs(driver, saveEl);
                    clickedSave = true;
                    log?.Invoke("Đã bấm Lưu avatar qua Selenium, chờ xử lý...");
                    Sleep(3.0);
                    break;
                }
            }
            catch { }

            Sleep(1.2);
        }

        // 5. Chờ modal đóng xác nhận hoàn tất
        for (int wait = 0; wait < 10; wait++)
        {
            int openDialogCount = 0;
            int.TryParse(chrome.method_14("return document.querySelectorAll('div[role=\"dialog\"]').length")?.ToString(), out openDialogCount);
            if (openDialogCount == 0)
            {
                log?.Invoke("Cập nhật Avatar thành công!");
                return true;
            }
            Sleep(1.0);
        }

        if (clickedSave)
        {
            log?.Invoke("Cập nhật Avatar thành công!");
            return true;
        }

        log?.Invoke("Không tìm thấy nút Lưu avatar.");
        return false;
    }

    private static bool UploadAvatarMbasic(Chrome chrome, string imagePath, Action<string> log)
    {
        try
        {
            chrome.method_12("https://mbasic.facebook.com/profile.php");
            Sleep(2.5);

            object clickRes = chrome.method_14(@"
                (() => {
                    var links = Array.from(document.querySelectorAll('a'));
                    for (var a of links) {
                        var h = (a.getAttribute('href') || '').toLowerCase();
                        if (h.includes('/photos/upload/?profile_pic') || h.includes('/profile_picture/') || h.includes('view_profile_pic')) {
                            a.click();
                            return 'clicked';
                        }
                    }
                    return 'none';
                })()
            ");

            Sleep(2.0);

            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            var fileInputs = driver.FindElements(By.CssSelector("input[type='file'][name='pic'], input[type='file']"));
            if (fileInputs.Count == 0) return false;

            fileInputs[0].SendKeys(imagePath);
            Sleep(1.5);

            var submitBtns = driver.FindElements(By.CssSelector("input[type='submit']"));
            if (submitBtns.Count > 0)
            {
                submitBtns[0].Click();
                Sleep(3.0);

                var confirmBtns = driver.FindElements(By.CssSelector("input[type='submit']"));
                if (confirmBtns.Count > 0)
                {
                    confirmBtns[0].Click();
                    Sleep(2.0);
                }
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Action 12: UploadCover (Meta Comet WWW & Mobile/mbasic)
    public static bool UploadCover(Chrome chrome, string imagePath, bool skipIfHave = false, bool preferMbasic = false, Action<string> log = null)
    {
        return UploadCover(chrome, imagePath, skipIfHave, preferMbasic, true, true, log);
    }

    public static bool UploadCover(Chrome chrome, string imagePath, bool skipIfHave, bool preferMbasic, bool noFeedShare, bool skipCrop, Action<string> log = null)
    {
        if (chrome == null)
        {
            log?.Invoke("Lỗi: Chrome chưa khởi tạo!");
            return false;
        }

        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
        {
            log?.Invoke("Lỗi: File ảnh không tồn tại: " + imagePath);
            return false;
        }

        try
        {
            if (preferMbasic)
            {
                log?.Invoke("Đang tải ảnh bìa qua chế độ Mobile...");
                if (UploadCoverMobile(chrome, imagePath, log) || UploadCoverMbasic(chrome, imagePath, log))
                {
                    log?.Invoke("Up ảnh bìa Mobile thành công!");
                    return true;
                }
                log?.Invoke("Mobile không khả dụng, chuyển sang Meta Comet WWW...");
            }

            return UploadCoverWWW(chrome, imagePath, skipIfHave, noFeedShare, skipCrop, log);
        }
        catch (Exception ex)
        {
            log?.Invoke("Ngoại lệ Up Cover: " + ex.Message);
            return false;
        }
    }

    private static bool UploadCoverWWW(Chrome chrome, string imagePath, bool skipIfHave, bool noFeedShare, bool skipCrop, Action<string> log)
    {
        var driver = chrome.ChromeDriver_0;
        if (driver == null)
        {
            log?.Invoke("Lỗi: Không tìm thấy ChromeDriver!");
            return false;
        }

        // 1. Đảm bảo kích thước chuẩn Desktop Comet (>= 1280x800) để layout hiển thị đầy đủ
        try
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1280, 800);
        }
        catch
        {
            try { driver.Manage().Window.Maximize(); } catch { }
        }

        log?.Invoke("Mở trang cá nhân...");
        chrome.method_12("https://www.facebook.com/me");

        // Chờ trang cá nhân render đầy đủ (tối đa 10s)
        for (int w = 0; w < 10; w++)
        {
            Sleep(1.0);
            try
            {
                object ready = chrome.method_14(@"
                    (() => {
                        return (document.readyState === 'complete' || document.readyState === 'interactive') &&
                               (document.querySelector('div[role=""main""], div[data-pagelet*=""Profile""], div[role=""banner""]') != null) ? 'ready' : 'loading';
                    })()
                ");
                if (ready != null && ready.ToString() == "ready")
                {
                    break;
                }
            }
            catch { }
        }

        DismissPopups(chrome);

        // 2. Kiểm tra nếu đã có ảnh bìa và người dùng tick 'Bỏ qua nếu đã có'
        if (skipIfHave)
        {
            log?.Invoke("Kiểm tra ảnh bìa hiện tại...");
            try
            {
                object hasCover = chrome.method_14(@"
                    (() => {
                        var imgs = document.querySelectorAll('div[data-pagelet*=""ProfileCover""] img, div[data-pagelet*=""cover""] img, div[aria-label*=""bìa"" i] img, div[aria-label*=""cover"" i] img');
                        for (var img of imgs) {
                            var src = img.src || '';
                            if (src && !src.includes('rsrc.php') && (src.includes('scontent') || src.includes('fbcdn.net'))) {
                                return 'yes';
                            }
                        }
                        return 'no';
                    })()
                ");
                if (hasCover != null && hasCover.ToString() == "yes")
                {
                    log?.Invoke("Tài khoản đã có ảnh bìa, bỏ qua...");
                    return true;
                }
            }
            catch { }
        }

        // 3. Cài đặt hook interceptor chống mở hộp thoại tệp Windows (OpenFileDialog)
        // và tự động đánh dấu thẻ input[type='file'] mục tiêu
        chrome.method_14(@"
            (() => {
                window.__lushcareCoverTarget = null;
                if (!window.__lushcareCoverHookInstalled) {
                    window.__lushcareCoverHookInstalled = true;
                    var origClick = HTMLInputElement.prototype.click;
                    HTMLInputElement.prototype.click = function() {
                        if (this.type === 'file') {
                            this.setAttribute('data-lushcare-cover-target', 'true');
                            window.__lushcareCoverTarget = this;
                            return; // Ngăn chặn hoàn toàn popup Windows Native OpenFileDialog!
                        }
                        return origClick.apply(this, arguments);
                    };
                }
            })()
        ");

        // 4. Mở menu hành động ảnh bìa
        log?.Invoke("Mở menu ảnh bìa...");
        object clickRes = chrome.method_14(@"
            (() => {
                // Ưu tiên 1: Nút trong vùng ảnh bìa / cover area
                var coverArea = document.querySelector('div[data-pagelet*=""ProfileCover""], div[data-pagelet*=""cover""], div[role=""region""][aria-label*=""bìa"" i], div[role=""region""][aria-label*=""cover"" i]');
                if (coverArea) {
                    var btns = Array.from(coverArea.querySelectorAll('div[role=""button""], button'));
                    for (var b of btns) {
                        var text = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase();
                        if (text.includes('bìa') || text.includes('cover') || text.includes('ảnh') || text.includes('photo') || text.includes('chỉnh sửa') || text.includes('edit')) {
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            return 'clicked_cover_area_btn';
                        }
                    }
                    if (btns.length > 0) {
                        btns[btns.length - 1].scrollIntoView({block: 'center'});
                        btns[btns.length - 1].click();
                        return 'clicked_cover_last_btn';
                    }
                }

                // Ưu tiên 2: Tìm nút theo từ khóa trên toàn trang (top 550px)
                var allButtons = Array.from(document.querySelectorAll('div[role=""button""], button'));
                var keywords = [
                    'chỉnh sửa ảnh bìa', 'edit cover photo',
                    'thêm ảnh bìa', 'add cover photo',
                    'cập nhật ảnh bìa', 'update cover photo',
                    'hành động với ảnh bìa', 'cover photo actions',
                    'tùy chọn ảnh bìa', 'cover photo options',
                    'edit cover', 'add cover'
                ];
                for (var b of allButtons) {
                    var aria = (b.getAttribute('aria-label') || b.innerText || '').toLowerCase();
                    for (var kw of keywords) {
                        if (aria.includes(kw)) {
                            b.scrollIntoView({block: 'center'});
                            b.click();
                            return 'clicked_btn_kw';
                        }
                    }
                }

                // Ưu tiên 3: Nút chứa SVG máy ảnh trong vùng top banner
                var svgs = document.querySelectorAll('svg');
                for (var s of svgs) {
                    var btn = s.closest('div[role=""button""], button');
                    if (btn) {
                        var rect = btn.getBoundingClientRect();
                        if (rect.top >= 0 && rect.top < 550 && rect.width > 20 && rect.height > 20) {
                            var t = (btn.getAttribute('aria-label') || btn.innerText || '').toLowerCase();
                            if (t.includes('bìa') || t.includes('cover') || t.includes('ảnh') || t.includes('photo') || t.includes('camera')) {
                                btn.scrollIntoView({block: 'center'});
                                btn.click();
                                return 'clicked_svg';
                            }
                        }
                    }
                }

                // Ưu tiên 4: Nút 'Chỉnh sửa trang cá nhân' / 'Edit profile'
                for (var b of allButtons) {
                    var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                    if (t.includes('chỉnh sửa trang cá nhân') || t.includes('edit profile')) {
                        b.scrollIntoView({block: 'center'});
                        b.click();
                        return 'clicked_edit_profile';
                    }
                }

                return 'not_found';
            })()
        ");

        Sleep(1.2);

        // 5. Kích hoạt 'Tải ảnh lên' / 'Upload photo' trong menu hoặc dialog
        log?.Invoke("Định vị ô tải ảnh lên...");
        chrome.method_14(@"
            (() => {
                // Trường hợp A: Trong menu dropdown
                var menu = document.querySelector('div[role=""menu""]');
                if (menu) {
                    var inp = menu.querySelector('input[type=""file""]');
                    if (inp) {
                        inp.setAttribute('data-lushcare-cover-target', 'true');
                    }
                    var items = Array.from(menu.querySelectorAll('div[role=""menuitem""], div[role=""button""], span'));
                    for (var it of items) {
                        var t = (it.innerText || it.getAttribute('aria-label') || '').toLowerCase();
                        if (t.includes('tải ảnh lên') || t.includes('upload photo') || t.includes('tải ảnh') || t.includes('upload')) {
                            var clickable = it.closest('div[role=""menuitem""]') || it.closest('div[role=""button""]') || it;
                            clickable.click(); // Hook đã ngăn chặn OS dialog!
                            break;
                        }
                    }
                }

                // Trường hợp B: Trong dialog 'Chỉnh sửa trang cá nhân'
                var dialog = document.querySelector('div[role=""dialog""]');
                if (dialog) {
                    var dialogBtns = Array.from(dialog.querySelectorAll('div[role=""button""], button'));
                    for (var b of dialogBtns) {
                        var text = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase();
                        var parentText = (b.parentElement ? b.parentElement.innerText : '').toLowerCase();
                        if ((parentText.includes('ảnh bìa') || parentText.includes('cover')) &&
                            (text.includes('chỉnh sửa') || text.includes('edit') || text.includes('thêm') || text.includes('add') || text.includes('tải'))) {
                            b.click();
                            break;
                        }
                    }
                }

                // Hiển thị toàn bộ input candidate để Selenium tương tác
                var allInps = document.querySelectorAll('input[type=""file""]');
                for (var i = 0; i < allInps.length; i++) {
                    allInps[i].style.display = 'block';
                    allInps[i].style.visibility = 'visible';
                    allInps[i].style.opacity = '1';
                    allInps[i].style.position = 'fixed';
                    allInps[i].style.top = '10px';
                    allInps[i].style.left = '10px';
                    allInps[i].style.width = '100px';
                    allInps[i].style.height = '40px';
                    allInps[i].style.zIndex = '99999999';
                    allInps[i].removeAttribute('hidden');
                    allInps[i].removeAttribute('disabled');
                }
            })()
        ");

        Sleep(0.8);

        // 6. Gửi file ảnh qua Selenium SendKeys vào đúng input
        log?.Invoke("Đang gửi file ảnh bìa...");
        IWebElement targetInput = null;

        // Ưu tiên 1: Input được hook đánh dấu
        var taggedInputs = driver.FindElements(By.CssSelector("input[data-lushcare-cover-target='true']"));
        if (taggedInputs.Count > 0)
        {
            targetInput = taggedInputs[0];
        }

        // Ưu tiên 2: Input trong menu hoặc vùng cover / dialog
        if (targetInput == null)
        {
            var menuInputs = driver.FindElements(By.CssSelector("div[role='menu'] input[type='file'], div[data-pagelet*='Cover'] input[type='file'], div[role='dialog'] input[type='file']"));
            if (menuInputs.Count > 0)
            {
                targetInput = menuInputs[0];
            }
        }

        // Ưu tiên 3: Input file bất kỳ
        if (targetInput == null)
        {
            var anyInputs = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file']"));
            if (anyInputs.Count > 0)
            {
                targetInput = anyInputs[0];
            }
        }

        if (targetInput == null)
        {
            log?.Invoke("Không tìm thấy ô chọn file ảnh bìa!");
            return false;
        }

        try
        {
            targetInput.SendKeys(imagePath);
        }
        catch (Exception ex)
        {
            log?.Invoke("Lỗi gửi đường dẫn ảnh bìa: " + ex.Message);
            return false;
        }

        // Kích hoạt dispatch events
        chrome.method_14(@"
            (() => {
                var inps = document.querySelectorAll('input[type=""file""]');
                for (var inp of inps) {
                    inp.dispatchEvent(new Event('input', { bubbles: true }));
                    inp.dispatchEvent(new Event('change', { bubbles: true }));
                }
            })()
        ");

        log?.Invoke("Chờ xử lý ảnh tải lên...");
        Sleep(2.0);

        // 6b. Nếu có tùy chọn Không chia sẻ lên Bảng tin (Feed): tự động tìm checkbox/switch và bỏ tick
        if (noFeedShare)
        {
            try
            {
                chrome.method_14(@"
                    (() => {
                        var boxes = Array.from(document.querySelectorAll('input[type=""checkbox""], div[role=""checkbox""], div[role=""switch""]'));
                        for (var b of boxes) {
                            var text = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase();
                            var pText = (b.closest('label') ? b.closest('label').innerText : (b.parentElement ? b.parentElement.innerText : '')).toLowerCase();
                            var allT = text + ' ' + pText;
                            if (allT.includes('bảng tin') || allT.includes('news feed') || allT.includes('feed') || allT.includes('chia sẻ')) {
                                var checked = b.checked || b.getAttribute('aria-checked') === 'true';
                                if (checked) {
                                    b.click();
                                    return 'toggled_off';
                                }
                            }
                        }
                        return 'none';
                    })()
                ");
            }
            catch { }
        }

        // 7. Chờ và bấm nút 'Lưu thay đổi' / 'Save changes' (polling linh hoạt)
        log?.Invoke("Bấm Lưu thay đổi ảnh bìa...");
        bool clickedSave = false;
        for (int i = 0; i < 25; i++)
        {
            object res = chrome.method_14(@"
                (() => {
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], button'));
                    var saveBtn = null;

                    // 1. Tìm nút 'Lưu thay đổi' / 'Save changes'
                    for (var b of btns) {
                        var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                        if (t === 'lưu thay đổi' || t === 'save changes' || t.includes('lưu thay đổi') || t.includes('save changes')) {
                            saveBtn = b;
                            break;
                        }
                    }

                    // 2. Tìm nút 'Lưu' / 'Save' trong vùng banner trên cùng hoặc dialog
                    if (!saveBtn) {
                        for (var b of btns) {
                            var t = (b.innerText || b.getAttribute('aria-label') || '').trim().toLowerCase();
                            if (t === 'lưu' || t === 'save' || t === 'hoàn tất' || t === 'done') {
                                var rect = b.getBoundingClientRect();
                                var inDialog = b.closest('div[role=""dialog""]');
                                if (inDialog || (rect.top >= 0 && rect.top < 550)) {
                                    saveBtn = b;
                                    break;
                                }
                            }
                        }
                    }

                    if (saveBtn) {
                        // Kiểm tra nếu nút đang disabled hoặc đang xử lý upload
                        var isDisabled = saveBtn.getAttribute('aria-disabled') === 'true' || 
                                         saveBtn.disabled || 
                                         saveBtn.getAttribute('disabled') !== null ||
                                         saveBtn.querySelector('[role=""progressbar""]');
                        if (isDisabled) {
                            return 'uploading'; // Đang tải ảnh, nút chưa sẵn sàng
                        }
                        saveBtn.scrollIntoView({block: 'center'});
                        saveBtn.click();
                        return 'clicked';
                    }

                    return 'waiting';
                })()
            ");

            if (res != null && res.ToString() == "clicked")
            {
                clickedSave = true;
                log?.Invoke("Đã bấm Lưu thay đổi ảnh bìa, chờ xác nhận...");
                Sleep(2.5);
                break;
            }

            Sleep(0.5);
        }

        if (clickedSave)
        {
            log?.Invoke("Cập nhật ảnh bìa thành công!");
            return true;
        }

        log?.Invoke("Không tìm thấy nút Lưu thay đổi ảnh bìa.");
        return false;
    }

    private static bool UploadCoverMobile(Chrome chrome, string imagePath, Action<string> log)
    {
        try
        {
            chrome.method_12("https://m.facebook.com/profile.php");
            Sleep(2.5);

            // Tìm nút đổi cover trên m.facebook.com
            chrome.method_14(@"
                (() => {
                    var btns = Array.from(document.querySelectorAll('div[role=""button""], a, button'));
                    for (var b of btns) {
                        var text = (b.innerText || b.getAttribute('aria-label') || b.getAttribute('href') || '').toLowerCase();
                        if (text.includes('bìa') || text.includes('cover') || text.includes('edit_cover')) {
                            b.click();
                            return 'clicked';
                        }
                    }
                    return 'none';
                })()
            ");

            Sleep(1.5);
            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            var fileInputs = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file']"));
            if (fileInputs.Count == 0) return false;

            fileInputs[0].SendKeys(imagePath);
            Sleep(2.0);

            // Bấm Lưu / Submit trên mobile
            var submitBtns = driver.FindElements(By.CssSelector("input[type='submit'], button[type='submit'], div[role='button']"));
            foreach (var btn in submitBtns)
            {
                string txt = (btn.Text ?? "").ToLower();
                if (txt.Contains("lưu") || txt.Contains("save") || txt.Contains("cập nhật") || txt.Contains("update"))
                {
                    btn.Click();
                    Sleep(2.5);
                    return true;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool UploadCoverMbasic(Chrome chrome, string imagePath, Action<string> log)
    {
        try
        {
            chrome.method_12("https://mbasic.facebook.com/profile.php");
            Sleep(2.5);

            chrome.method_14(@"
                (() => {
                    var links = Array.from(document.querySelectorAll('a'));
                    for (var a of links) {
                        var h = (a.getAttribute('href') || '').toLowerCase();
                        if (h.includes('/photos/upload/?cover_photo') || h.includes('edit_cover') || h.includes('cover_photo')) {
                            a.click();
                            return 'clicked';
                        }
                    }
                    return 'none';
                })()
            ");

            Sleep(2.0);

            var driver = chrome.ChromeDriver_0;
            if (driver == null) return false;

            var fileInputs = driver.FindElements(By.CssSelector("input[type='file'][name='pic'], input[type='file']"));
            if (fileInputs.Count == 0) return false;

            fileInputs[0].SendKeys(imagePath);
            Sleep(1.5);

            var submitBtns = driver.FindElements(By.CssSelector("input[type='submit']"));
            if (submitBtns.Count > 0)
            {
                submitBtns[0].Click();
                Sleep(3.0);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
    #endregion
}
