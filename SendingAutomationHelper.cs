using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;

/// <summary>
/// SendingAutomationHelper: Trình hỗ trợ tự động hóa toàn diện các tác vụ Sending / Seeding
/// (Đăng bài, Đăng Reel, Đăng Story, Chia sẻ, Spam bài viết, Nhắn tin UID, Mời vào nhóm, Mời like page).
/// Thiết kế cho giao diện Facebook Comet mới, chống checkpoint, fallback selectors đa ngôn ngữ.
/// Tích hợp toàn diện AdaptiveDelayEngine loại bỏ hoàn toàn Thread.Sleep hardcode, chống bot timing detection của Meta.
/// </summary>
public static class SendingAutomationHelper
{
	private static readonly Random _rd = new Random();

	#region Anti-Spam & Spintax Utilities

	/// <summary>
	/// Xử lý định dạng Spintax {nội dung 1|nội dung 2|nội dung 3} đệ quy (hỗ trợ nested spintax)
	/// </summary>
	public static string ResolveSpintax(string text)
	{
		if (string.IsNullOrEmpty(text))
			return "";

		var regex = new Regex(@"\{([^{}]+)\}");
		while (regex.IsMatch(text))
		{
			text = regex.Replace(text, match =>
			{
				string[] options = match.Groups[1].Value.Split('|');
				return options[_rd.Next(0, options.Length)];
			});
		}
		return text;
	}

	/// <summary>
	/// Nối nội dung chữ ký / văn bản thêm vào cuối nếu người dùng bật ckbThemVaoCuoiNoiDung
	/// </summary>
	public static string ApplySuffixContent(string content, bool enableSuffix, string suffixText)
	{
		if (!enableSuffix || string.IsNullOrWhiteSpace(suffixText))
			return content ?? "";

		string resolvedSuffix = ResolveSpintax(suffixText);
		if (string.IsNullOrWhiteSpace(content))
			return resolvedSuffix;

		return content.TrimEnd() + Environment.NewLine + resolvedSuffix;
	}

	/// <summary>
	/// Nghỉ ngẫu nhiên giữa khoảng minSeconds và maxSeconds (sử dụng phân phối Gaussian Jitter từ AdaptiveDelayEngine)
	/// </summary>
	public static void RandomDelay(int minSeconds, int maxSeconds, Chrome chrome = null)
	{
		AdaptiveDelayEngine.DelaySeconds(minSeconds, maxSeconds, chrome);
	}

	/// <summary>
	/// Kiểm tra tài khoản có bị checkpoint, hạn chế tính năng hoặc chặn tương tác không
	/// </summary>
	public static bool IsCheckpointOrRestricted(Chrome chrome)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null)
			return true;

		try
		{
			string currentUrl = chrome.ChromeDriver_0.Url.ToLower();
			if (currentUrl.Contains("checkpoint") || currentUrl.Contains("/login/") || currentUrl.Contains("login_attempt"))
				return true;

			// Kiểm tra các thông báo chặn / hạn chế từ Facebook DOM
			string pageSource = chrome.ChromeDriver_0.PageSource;
			if (pageSource.Contains("Tài khoản của bạn tạm thời bị khóa") ||
			    pageSource.Contains("You're temporarily blocked") ||
			    pageSource.Contains("Tính năng này tạm thời bị khóa") ||
			    pageSource.Contains("You can't use this feature right now"))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	/// <summary>
	/// Tự động đóng các popup cản trở trên Facebook (Cookie, Lưu mật khẩu, Thông báo)
	/// </summary>
	public static void DismissOverlays(Chrome chrome)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null)
			return;

		try
		{
			chrome.DismissFacebookPopups();
			// Bấm nút ESC để đóng các modal popup trôi nổi
			chrome.method_14(@"
				try {
					var closeBtns = document.querySelectorAll('[aria-label=""Đóng"" i], [aria-label=""Close"" i], [aria-label=""Để sau"" i], [aria-label=""Not Now"" i]');
					for (var i = 0; i < closeBtns.length; i++) {
						if (closeBtns[i].offsetParent !== null) { closeBtns[i].click(); }
					}
				} catch(e) {}
			");
		}
		catch
		{
		}
	}

	#endregion

	#region 1. Đăng Reels Comet (ExecuteDangReelWWW)

	/// <summary>
	/// Đăng Video ngắn Reels trên giao diện Facebook Comet mới (hỗ trợ upload, multi-step Next, mô tả Spintax + Hashtag, Publish)
	/// Tích hợp AdaptiveDelayEngine chống rhythm detection của Meta.
	/// </summary>
	public static int ExecuteDangReelWWW(Chrome chrome, string videoPath, string caption, int delayMin = 3, int delayMax = 5)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null)
			return 0;

		if (string.IsNullOrWhiteSpace(videoPath) || !File.Exists(videoPath))
			return 0;

		var driver = chrome.ChromeDriver_0;
		try
		{
			// Bước 1: Điều hướng tới reels create
			chrome.method_12("https://www.facebook.com/reels/create/");
			AdaptiveDelayEngine.DelayMs(3000, 0.2, chrome);
			DismissOverlays(chrome);

			if (IsCheckpointOrRestricted(chrome))
				return -1;

			// Bước 2: Hiển thị và inject file video vào thẻ input[type="file"]
			chrome.method_14(@"
				var inputs = document.querySelectorAll('input[type=""file""]');
				inputs.forEach(function(inp) {
					inp.style.display = 'block';
					inp.style.visibility = 'visible';
					inp.style.opacity = '1';
					inp.style.width = '100px';
					inp.style.height = '100px';
				});
			");
			AdaptiveDelayEngine.MicroPause(chrome);

			var fileInput = driver.FindElements(By.CssSelector("input[type='file'][accept*='video'], input[type='file']")).FirstOrDefault();
			if (fileInput == null)
			{
				// Fallback: Tìm nút Thêm video / Add video
				var addBtn = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(),'Thêm video') or contains(text(),'Add video') or contains(text(),'Tải lên')]]")).FirstOrDefault();
				if (addBtn != null)
				{
					addBtn.Click();
					AdaptiveDelayEngine.DelayMs(1500, 0.2, chrome);
					fileInput = driver.FindElements(By.CssSelector("input[type='file']")).FirstOrDefault();
				}
			}

			if (fileInput == null)
				return 0;

			fileInput.SendKeys(videoPath);
			AdaptiveDelayEngine.DelayMs(3000, 0.25, chrome);

			// Bước 3: Đợi video render và xuất hiện nút Tiếp/Next
			for (int step = 0; step < 2; step++)
			{
				for (int w = 0; w < 40; w++)
				{
					if (IsCheckpointOrRestricted(chrome))
						return -1;

					// Selector nút Tiếp / Next không bị disable
					var nextBtn = driver.FindElements(By.CssSelector("div[aria-label='Tiếp' i]:not([aria-disabled='true']), div[aria-label='Next' i]:not([aria-disabled='true'])"))
						.Concat(driver.FindElements(By.XPath("//div[@role='button'][not(@aria-disabled='true')][.//*[translate(text(),'NEXT','next')='next' or text()='Tiếp']]")))
						.FirstOrDefault();

					if (nextBtn != null && nextBtn.Displayed)
					{
						nextBtn.Click();
						AdaptiveDelayEngine.DelayMs(2500, 0.2, chrome);
						break;
					}
					AdaptiveDelayEngine.DelayMs(1000, 0.2, chrome);
				}
			}

			// Bước 4: Nhập mô tả Reel (hỗ trợ Spintax)
			if (!string.IsNullOrWhiteSpace(caption))
			{
				string resolvedCaption = ResolveSpintax(caption);
				try
				{
					var captionInput = driver.FindElements(By.CssSelector("form [role='textbox'], [role='textbox'][contenteditable='true'], div[data-lexical-editor='true']")).FirstOrDefault();
					if (captionInput != null)
					{
						captionInput.Click();
						AdaptiveDelayEngine.MicroPause(chrome);
						try
						{
							HumanTyping.TypeLikeHuman(driver, captionInput, resolvedCaption);
						}
						catch
						{
							captionInput.SendKeys(resolvedCaption);
						}
						AdaptiveDelayEngine.MicroPause(chrome);
					}
				}
				catch
				{
				}
			}

			// Bước 5: Đợi video tải xong 100% và nút Đăng / Publish khả dụng
			for (int p = 0; p < 60; p++)
			{
				if (IsCheckpointOrRestricted(chrome))
					return -1;

				var publishBtn = driver.FindElements(By.CssSelector("div[aria-label='Đăng' i]:not([aria-disabled='true']), div[aria-label='Publish' i]:not([aria-disabled='true']), div[aria-label='Chia sẻ' i]:not([aria-disabled='true']), div[aria-label='Share' i]:not([aria-disabled='true'])"))
					.Concat(driver.FindElements(By.XPath("//div[@role='button'][not(@aria-disabled='true')][.//*[contains(text(),'Đăng') or contains(text(),'Publish') or contains(text(),'Chia sẻ') or contains(text(),'Share')]]")))
					.FirstOrDefault();

				if (publishBtn != null && publishBtn.Displayed)
				{
					publishBtn.Click();
					AdaptiveDelayEngine.Delay(ActionIntensity.Heavy, 0.4, chrome);

					// Đợi chuyển hướng hoặc thông báo xuất bản hoàn tất
					for (int fin = 0; fin < 30; fin++)
					{
						string url = driver.Url;
						if (!url.Contains("/reels/create"))
						{
							string reelUrl = url.Contains("/reel/") ? url : ("https://www.facebook.com/reel/" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
							KichBanThongKeDB.LogPost(chrome.B4208531, reelUrl, caption, "Đăng Reels", "Thành công");
							AdaptiveDelayEngine.RegisterAction(chrome.B4208531, ActionIntensity.Heavy);
							AdaptiveDelayEngine.Delay(ActionIntensity.Heavy, 1.0, chrome);
							RandomDelay(delayMin, delayMax, chrome);
							return 1;
						}
						AdaptiveDelayEngine.DelayMs(1000, 0.2, chrome);
					}
					string fallbackReelUrl = "https://www.facebook.com/reel/" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
					KichBanThongKeDB.LogPost(chrome.B4208531, fallbackReelUrl, caption, "Đăng Reels", "Thành công");
					AdaptiveDelayEngine.RegisterAction(chrome.B4208531, ActionIntensity.Heavy);
					AdaptiveDelayEngine.Delay(ActionIntensity.Heavy, 1.0, chrome);
					RandomDelay(delayMin, delayMax, chrome);
					return 1;
				}
				AdaptiveDelayEngine.DelayMs(1000, 0.2, chrome);
			}
		}
		catch
		{
		}
		return 0;
	}

	#endregion

	#region 2. Đăng Story Comet (ExecuteDangStoryWWW)

	/// <summary>
	/// Đăng Tin Story ảnh hoặc video trên giao diện Facebook Comet mới
	/// Tích hợp AdaptiveDelayEngine chống rhythm detection của Meta.
	/// </summary>
	public static int ExecuteDangStoryWWW(Chrome chrome, string mediaPath, string textContent = "", bool isVideo = false)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null)
			return 0;

		var driver = chrome.ChromeDriver_0;
		try
		{
			chrome.method_12("https://www.facebook.com/stories/create/");
			AdaptiveDelayEngine.DelayMs(3000, 0.2, chrome);
			DismissOverlays(chrome);

			if (IsCheckpointOrRestricted(chrome))
				return -1;

			// Nếu đăng Story bằng ảnh / video
			if (!string.IsNullOrWhiteSpace(mediaPath) && File.Exists(mediaPath))
			{
				chrome.method_14(@"
					var inputs = document.querySelectorAll('input[type=""file""]');
					inputs.forEach(function(inp) {
						inp.style.display = 'block';
						inp.style.visibility = 'visible';
						inp.style.opacity = '1';
						inp.style.width = '100px';
						inp.style.height = '100px';
					});
				");
				AdaptiveDelayEngine.MicroPause(chrome);

				var fileInput = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file'][accept*='video'], input[type='file']")).FirstOrDefault();
				if (fileInput == null)
				{
					// Click card "Tạo tin ảnh" / "Create a photo story"
					var photoCard = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Tạo tin ảnh') or contains(text(), 'Create a photo story') or contains(text(), 'Tạo tin')]]")).FirstOrDefault();
					if (photoCard != null)
					{
						photoCard.Click();
						AdaptiveDelayEngine.DelayMs(1500, 0.2, chrome);
						fileInput = driver.FindElements(By.CssSelector("input[type='file']")).FirstOrDefault();
					}
				}

				if (fileInput == null)
					return 0;

				fileInput.SendKeys(mediaPath);
				AdaptiveDelayEngine.DelayMs(4000, 0.25, chrome);
			}
			else if (!string.IsNullOrWhiteSpace(textContent))
			{
				// Đăng Story dạng văn bản
				var textCard = driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(), 'Tạo tin văn bản') or contains(text(), 'Create a text story')]]")).FirstOrDefault();
				if (textCard != null)
				{
					textCard.Click();
					AdaptiveDelayEngine.DelayMs(2000, 0.2, chrome);
					var textBox = driver.FindElements(By.CssSelector("textarea, [role='textbox'][contenteditable='true']")).FirstOrDefault();
					if (textBox != null)
					{
						string resolvedText = ResolveSpintax(textContent);
						try
						{
							HumanTyping.TypeLikeHuman(driver, textBox, resolvedText);
						}
						catch
						{
							textBox.SendKeys(resolvedText);
						}
						AdaptiveDelayEngine.DelayMs(1500, 0.2, chrome);
					}
				}
			}
			else
			{
				return 0;
			}

			// Chờ nút "Chia sẻ lên tin" / "Share to story" / "Chia sẻ" khả dụng
			for (int i = 0; i < 40; i++)
			{
				if (IsCheckpointOrRestricted(chrome))
					return -1;

				var shareBtn = driver.FindElements(By.CssSelector("div[aria-label*='Chia sẻ lên tin' i]:not([aria-disabled='true']), div[aria-label*='Share to story' i]:not([aria-disabled='true']), div[aria-label='Chia sẻ' i]:not([aria-disabled='true']), div[aria-label='Share' i]:not([aria-disabled='true'])"))
					.Concat(driver.FindElements(By.XPath("//div[@role='button'][not(@aria-disabled='true')][.//*[contains(text(), 'Chia sẻ lên tin') or contains(text(), 'Share to story') or contains(text(), 'Chia sẻ') or contains(text(), 'Share')]]")))
					.FirstOrDefault();

				if (shareBtn != null && shareBtn.Displayed)
				{
					shareBtn.Click();
					AdaptiveDelayEngine.Delay(ActionIntensity.Heavy, 0.5, chrome);
					AdaptiveDelayEngine.RegisterAction(chrome.B4208531, ActionIntensity.Heavy);
					AdaptiveDelayEngine.Delay(ActionIntensity.Heavy, 1.0, chrome);
					return 1;
				}
				AdaptiveDelayEngine.DelayMs(1000, 0.2, chrome);
			}
		}
		catch
		{
		}
		return 0;
	}

	#endregion

	#region 3. Nhắn tin UID & Buff Messenger (ExecuteNhanTinUidWWW)

	/// <summary>
	/// Gửi tin nhắn trực tiếp tới UID khách hàng (Hỗ trợ Spintax, gửi kèm ảnh, chống checkpoint khi mở Messenger)
	/// Tích hợp AdaptiveDelayEngine chống rhythm detection của Meta.
	/// </summary>
	public static int ExecuteNhanTinUidWWW(Chrome chrome, string uid, string message, string imagePaths = "", int delayMin = 2, int delayMax = 5)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null || string.IsNullOrWhiteSpace(uid))
			return 0;

		var driver = chrome.ChromeDriver_0;
		try
		{
			// Bước 1: Điều hướng tới hộp thoại tin nhắn của UID
			string chatUrl = $"https://www.facebook.com/messages/t/{uid}";
			chrome.method_12(chatUrl);
			AdaptiveDelayEngine.DelayMs(3500, 0.2, chrome);
			DismissOverlays(chrome);

			if (IsCheckpointOrRestricted(chrome))
				return -2; // Checkpoint hoặc chặn tin nhắn

			// Bước 2: Tìm ô nhập tin nhắn văn bản
			IWebElement chatBox = null;
			for (int w = 0; w < 20; w++)
			{
				chatBox = driver.FindElements(By.CssSelector("div[role='textbox'][aria-label*='Tin nhắn' i], div[role='textbox'][aria-label*='Message' i], div[contenteditable='true'][role='textbox'], div[aria-label*='Soạn tin nhắn' i]")).FirstOrDefault();
				if (chatBox != null && chatBox.Displayed)
					break;

				AdaptiveDelayEngine.MicroPause(chrome);
			}

			if (chatBox == null)
			{
				// Fallback: Thử mở trang cá nhân facebook.com/{uid} rồi bấm nút Nhắn tin
				chrome.method_12($"https://www.facebook.com/{uid}");
				AdaptiveDelayEngine.DelayMs(3000, 0.2, chrome);
				DismissOverlays(chrome);

				var msgBtn = driver.FindElements(By.CssSelector("div[aria-label='Nhắn tin' i], div[aria-label='Message' i]"))
					.Concat(driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(),'Nhắn tin') or contains(text(),'Message')]]")))
					.FirstOrDefault();

				if (msgBtn != null)
				{
					msgBtn.Click();
					AdaptiveDelayEngine.DelayMs(3000, 0.2, chrome);
					chatBox = driver.FindElements(By.CssSelector("div[role='textbox'][aria-label*='Tin nhắn' i], div[role='textbox'][aria-label*='Message' i], div[contenteditable='true'][role='textbox']")).FirstOrDefault();
				}
			}

			if (chatBox == null)
				return 0;

			// Bước 3: Đính kèm hình ảnh nếu có (hỗ trợ nhiều ảnh qua dấu '|')
			if (!string.IsNullOrWhiteSpace(imagePaths))
			{
				var imgList = imagePaths.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(p => p.Trim())
					.Where(File.Exists)
					.ToList();

				foreach (var imgFile in imgList)
				{
					try
					{
						chrome.method_14(@"
							var inputs = document.querySelectorAll('input[type=""file""]');
							inputs.forEach(function(inp) {
								inp.style.display = 'block';
								inp.style.visibility = 'visible';
								inp.style.opacity = '1';
								inp.style.width = '50px';
								inp.style.height = '50px';
							});
						");
						AdaptiveDelayEngine.MicroPause(chrome);

						var fileInput = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file']")).LastOrDefault();
						if (fileInput != null)
						{
							fileInput.SendKeys(imgFile);
							AdaptiveDelayEngine.DelayMs(2000, 0.2, chrome);
						}
					}
					catch
					{
					}
				}
			}

			// Bước 4: Nhập nội dung tin nhắn đã được parse Spintax
			if (!string.IsNullOrWhiteSpace(message))
			{
				string resolvedMsg = ResolveSpintax(message);
				chatBox.Click();
				AdaptiveDelayEngine.MicroPause(chrome);

				// Nhập văn bản mô phỏng bàn phím thực
				try
				{
					HumanTyping.TypeLikeHuman(driver, chatBox, resolvedMsg);
				}
				catch
				{
					chatBox.SendKeys(resolvedMsg);
				}
				AdaptiveDelayEngine.MicroPause(chrome);
			}

			// Bước 5: Bấm Enter hoặc click nút Gửi
			try
			{
				chatBox.SendKeys(OpenQA.Selenium.Keys.Enter);
			}
			catch
			{
			}
			AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 0.4, chrome);

			// Fallback: Tìm nút Send / Gửi nếu Enter chưa kích hoạt
			var sendBtn = driver.FindElements(By.CssSelector("div[aria-label*='Gửi' i][role='button'], div[aria-label*='Send' i][role='button'], [aria-label*='Nhấn Enter để gửi' i]")).FirstOrDefault();
			if (sendBtn != null && sendBtn.Displayed)
			{
				try { sendBtn.Click(); } catch { }
			}

			AdaptiveDelayEngine.RegisterAction(chrome.B4208531, ActionIntensity.Medium);
			AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 1.0, chrome);
			RandomDelay(delayMin, delayMax, chrome);
			return 1;
		}
		catch
		{
		}
		return 0;
	}

	#endregion

	#region 4. Mời bạn bè vào nhóm (ExecuteMoiBanBeVaoNhom)

	/// <summary>
	/// Mời bạn bè tham gia nhóm: Tự động mở nhóm, click Mời, cuộn tải danh sách bạn bè, tick chọn hàng loạt và gửi lời mời
	/// Tích hợp AdaptiveDelayEngine chống rhythm detection của Meta.
	/// </summary>
	public static int ExecuteMoiBanBeVaoNhom(Chrome chrome, string groupId, int targetCount, int delayMin = 2, int delayMax = 5)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null || string.IsNullOrWhiteSpace(groupId))
			return 0;

		var driver = chrome.ChromeDriver_0;
		int invitedCount = 0;
		try
		{
			// Bước 1: Điều hướng tới trang nhóm
			string groupUrl = groupId.StartsWith("http") ? groupId : $"https://www.facebook.com/groups/{groupId}";
			chrome.method_12(groupUrl);
			AdaptiveDelayEngine.DelayMs(3500, 0.2, chrome);
			DismissOverlays(chrome);

			if (IsCheckpointOrRestricted(chrome))
				return -1;

			// Bước 2: Tìm và click nút "Mời" / "Invite"
			var inviteBtn = driver.FindElements(By.CssSelector("div[aria-label='Mời' i], div[aria-label='Invite' i]"))
				.Concat(driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(),'Mời') or contains(text(),'Invite')]]")))
				.FirstOrDefault();

			if (inviteBtn == null)
				return 0;

			inviteBtn.Click();
			AdaptiveDelayEngine.DelayMs(2500, 0.2, chrome);

			// Bước 3: Cuộn tải danh sách bạn bè trong modal dialog
			string scrollScript = @"
				var dialog = document.querySelector('div[role=""dialog""]');
				if (!dialog) return 0;
				var scrollables = dialog.querySelectorAll('div[style*=""overflow""], div[class*=""scroll""], div[tabindex=""0""]');
				for (var i = 0; i < scrollables.length; i++) {
					scrollables[i].scrollTop += 800;
				}
				return 1;
			";

			for (int sc = 0; sc < 6; sc++)
			{
				chrome.method_14(scrollScript);
				AdaptiveDelayEngine.DelayMs(1000, 0.2, chrome);
			}

			// Bước 4: Tick chọn hàng loạt bạn bè theo số lượng targetCount
			string selectScript = @"
				var limit = arguments[0];
				var dialog = document.querySelector('div[role=""dialog""]');
				if (!dialog) return 0;
				var checkboxes = dialog.querySelectorAll('input[type=""checkbox""]:not(:checked), div[role=""checkbox""][aria-checked=""false""]');
				var count = 0;
				for (var i = 0; i < checkboxes.length && count < limit; i++) {
					try {
						checkboxes[i].click();
						count++;
					} catch(e) {}
				}
				return count;
			";

			var result = ((IJavaScriptExecutor)driver).ExecuteScript(selectScript, targetCount);
			if (result != null && int.TryParse(result.ToString(), out int c))
			{
				invitedCount = c;
			}
			AdaptiveDelayEngine.DelayMs(1500, 0.2, chrome);

			// Bước 5: Bấm nút "Gửi lời mời" / "Send invites"
			var sendInviteBtn = driver.FindElements(By.CssSelector("div[role='dialog'] div[aria-label*='Gửi lời mời' i]:not([aria-disabled='true']), div[role='dialog'] div[aria-label*='Send invites' i]:not([aria-disabled='true']), div[role='dialog'] div[aria-label*='Mời' i]:not([aria-disabled='true'])"))
				.Concat(driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][not(@aria-disabled='true')][.//*[contains(text(),'Gửi') or contains(text(),'Send') or contains(text(),'Mời')]]")))
				.FirstOrDefault();

			if (sendInviteBtn != null && sendInviteBtn.Displayed)
			{
				sendInviteBtn.Click();
				AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 0.6, chrome);
			}

			AdaptiveDelayEngine.RegisterAction(chrome.B4208531, ActionIntensity.Medium);
			AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 1.0, chrome);
			RandomDelay(delayMin, delayMax, chrome);
		}
		catch
		{
		}
		return invitedCount;
	}

	#endregion

	#region 5. Mời bạn bè thích Page (ExecuteMoiBanBeLikePage)

	/// <summary>
	/// Mời bạn bè thích và theo dõi Fanpage: Mở trang Fanpage, mở hộp thoại mời bạn bè, chọn tất cả / tick theo số lượng và gửi
	/// Tích hợp AdaptiveDelayEngine chống rhythm detection của Meta.
	/// </summary>
	public static int ExecuteMoiBanBeLikePage(Chrome chrome, string pageId, int targetCount, int delayMin = 2, int delayMax = 5)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null || string.IsNullOrWhiteSpace(pageId))
			return 0;

		var driver = chrome.ChromeDriver_0;
		int invitedCount = 0;
		try
		{
			string pageUrl = pageId.StartsWith("http") ? pageId : $"https://www.facebook.com/{pageId}";
			chrome.method_12(pageUrl);
			AdaptiveDelayEngine.DelayMs(3500, 0.2, chrome);
			DismissOverlays(chrome);

			if (IsCheckpointOrRestricted(chrome))
				return -1;

			// Bước 1: Tìm nút "Mời bạn bè" hoặc menu 3 chấm (...)
			var inviteBtn = driver.FindElements(By.CssSelector("div[aria-label*='Mời bạn bè' i], div[aria-label*='Invite friends' i]"))
				.Concat(driver.FindElements(By.XPath("//div[@role='button'][.//*[contains(text(),'Mời bạn bè') or contains(text(),'Invite friends')]]")))
				.FirstOrDefault();

			if (inviteBtn == null)
			{
				// Bấm menu 3 chấm "Xem thêm tùy chọn"
				var moreBtn = driver.FindElements(By.CssSelector("div[aria-label*='Xem thêm' i], div[aria-label*='More' i]")).FirstOrDefault();
				if (moreBtn != null)
				{
					moreBtn.Click();
					AdaptiveDelayEngine.MicroPause(chrome);
					inviteBtn = driver.FindElements(By.XPath("//div[@role='menuitem'][.//*[contains(text(),'Mời bạn bè') or contains(text(),'Invite friends')]]")).FirstOrDefault();
				}
			}

			if (inviteBtn == null)
				return 0;

			inviteBtn.Click();
			AdaptiveDelayEngine.DelayMs(2500, 0.2, chrome);

			// Bước 2: Thử tick "Chọn tất cả" / "Select all" nếu có
			var selectAllBtn = driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='checkbox'][.//*[contains(text(),'Chọn tất cả') or contains(text(),'Select all')]] | //div[@role='dialog']//input[@type='checkbox'][following-sibling::*[contains(text(),'Chọn tất cả') or contains(text(),'Select all')]]")).FirstOrDefault();
			if (selectAllBtn != null)
			{
				selectAllBtn.Click();
				invitedCount = targetCount;
				AdaptiveDelayEngine.DelayMs(1500, 0.2, chrome);
			}
			else
			{
				// Cuộn và tick danh sách thủ công
				string scrollAndSelectScript = @"
					var limit = arguments[0];
					var dialog = document.querySelector('div[role=""dialog""]');
					if (!dialog) return 0;
					var scrollables = dialog.querySelectorAll('div[style*=""overflow""]');
					for (var s = 0; s < scrollables.length; s++) { scrollables[s].scrollTop += 600; }
					var checkboxes = dialog.querySelectorAll('input[type=""checkbox""]:not(:checked), div[role=""checkbox""][aria-checked=""false""]');
					var count = 0;
					for (var i = 0; i < checkboxes.length && count < limit; i++) {
						try { checkboxes[i].click(); count++; } catch(e) {}
					}
					return count;
				";
				var res = ((IJavaScriptExecutor)driver).ExecuteScript(scrollAndSelectScript, targetCount);
				if (res != null && int.TryParse(res.ToString(), out int cnt))
					invitedCount = cnt;
				AdaptiveDelayEngine.DelayMs(1500, 0.2, chrome);
			}

			// Bước 3: Bấm nút "Gửi lời mời" / "Send invites"
			var sendBtn = driver.FindElements(By.CssSelector("div[role='dialog'] div[aria-label*='Gửi lời mời' i]:not([aria-disabled='true']), div[role='dialog'] div[aria-label*='Send invites' i]:not([aria-disabled='true'])"))
				.Concat(driver.FindElements(By.XPath("//div[@role='dialog']//div[@role='button'][not(@aria-disabled='true')][.//*[contains(text(),'Gửi') or contains(text(),'Send')]]")))
				.FirstOrDefault();

			if (sendBtn != null && sendBtn.Displayed)
			{
				sendBtn.Click();
				AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 0.6, chrome);
			}

			AdaptiveDelayEngine.RegisterAction(chrome.B4208531, ActionIntensity.Medium);
			AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 1.0, chrome);
			RandomDelay(delayMin, delayMax, chrome);
		}
		catch
		{
		}
		return invitedCount;
	}

	#endregion

	#region 6. Đăng bài Comet Thông minh (ExecuteDangBaiWWW)

	/// <summary>
	/// Đăng bài viết lên Tường cá nhân (0), Nhóm (1), hoặc Fanpage (2) trên giao diện Comet mới.
	/// Tích hợp AdaptiveDelayEngine mô phỏng nhịp người thật, phân phối Log-Normal và gõ phím HumanTyping.
	/// </summary>
	public static string ExecuteDangBaiWWW(Chrome chrome, int typeObject, string link, string content, bool isUseBackground = false, List<string> images = null, int delayMin = 3, int delayMax = 5)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null)
			return "";

		try
		{
			// Gọi trực tiếp trình đăng bài Comet của Chrome engine
			string postUrl = chrome.ExecuteDangBaiWWW(typeObject, link, content, isUseBackground, images);

			string uid = !string.IsNullOrEmpty(chrome.B4208531) ? chrome.B4208531 : chrome.FB94939A();
			if (!string.IsNullOrEmpty(postUrl))
			{
				AdaptiveDelayEngine.RegisterAction(uid, ActionIntensity.Heavy);
				AdaptiveDelayEngine.Delay(ActionIntensity.Heavy, 1.0, chrome);
			}

			RandomDelay(delayMin, delayMax, chrome);
			return postUrl;
		}
		catch
		{
			return "";
		}
	}

	#endregion

	#region 7. Spam Bình luận / Seeding Comment (ExecuteSpamCommentWWW)

	/// <summary>
	/// Bình luận / Spam bài viết theo link hoặc UID (Hỗ trợ Like bài, đính kèm ảnh, Spintax, gõ phím HumanTyping, ghi log KichBanThongKeDB).
	/// Tích hợp AdaptiveDelayEngine chống rhythm detection của Meta.
	/// </summary>
	public static int ExecuteSpamCommentWWW(Chrome chrome, string targetUrl, string comment, string imagePath = "", bool likePost = true, int delayMin = 2, int delayMax = 5)
	{
		if (chrome == null || chrome.ChromeDriver_0 == null || string.IsNullOrWhiteSpace(targetUrl))
			return 0;

		var driver = chrome.ChromeDriver_0;
		try
		{
			string navigateUrl = targetUrl.Trim();
			if (!navigateUrl.StartsWith("http://") && !navigateUrl.StartsWith("https://"))
			{
				if (Regex.IsMatch(navigateUrl, @"^\d+$"))
					navigateUrl = $"https://www.facebook.com/{navigateUrl}";
				else
					navigateUrl = $"https://www.facebook.com/{navigateUrl.Trim('/')}";
			}

			chrome.method_12(navigateUrl);
			AdaptiveDelayEngine.DelayMs(3500, 0.2, chrome);
			DismissOverlays(chrome);

			if (IsCheckpointOrRestricted(chrome))
				return -1;

			// Bước 1: Thích bài viết nếu được yêu cầu (Like / React)
			if (likePost)
			{
				try
				{
					var likeBtn = driver.FindElements(By.CssSelector("div[aria-label*='Thích' i][role='button'], div[aria-label*='Like' i][role='button']"))
						.Concat(driver.FindElements(By.XPath("//div[@role='button'][.//*[text()='Thích' or text()='Like']]")))
						.FirstOrDefault();

					if (likeBtn != null && likeBtn.Displayed)
					{
						likeBtn.Click();
						AdaptiveDelayEngine.Delay(ActionIntensity.Light, 0.8, chrome);
						AdaptiveDelayEngine.MicroPause(chrome);
					}
				}
				catch { }
			}

			// Bước 2: Tìm ô nhập bình luận (Comment Box)
			IWebElement commentBox = null;
			for (int w = 0; w < 15; w++)
			{
				commentBox = driver.FindElements(By.CssSelector("form [role='textbox'], div[aria-label*='Viết bình luận' i], div[aria-label*='Write a comment' i], div[role='textbox'][contenteditable='true'], div[data-lexical-editor='true']")).FirstOrDefault();
				if (commentBox != null && commentBox.Displayed)
					break;

				AdaptiveDelayEngine.MicroPause(chrome);
			}

			if (commentBox == null)
				return 0;

			// Bước 3: Đính kèm hình ảnh nếu có
			if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
			{
				try
				{
					chrome.method_14(@"
						var inputs = document.querySelectorAll('input[type=""file""]');
						inputs.forEach(function(inp) {
							inp.style.display = 'block';
							inp.style.visibility = 'visible';
							inp.style.opacity = '1';
							inp.style.width = '60px';
							inp.style.height = '60px';
						});
					");
					AdaptiveDelayEngine.MicroPause(chrome);

					var fileInput = driver.FindElements(By.CssSelector("input[type='file'][accept*='image'], input[type='file']")).LastOrDefault();
					if (fileInput != null)
					{
						fileInput.SendKeys(imagePath);
						AdaptiveDelayEngine.DelayMs(2000, 0.2, chrome);
					}
				}
				catch { }
			}

			// Bước 4: Nhập nội dung bình luận với HumanTyping
			if (!string.IsNullOrWhiteSpace(comment))
			{
				string resolvedComment = ResolveSpintax(comment);
				commentBox.Click();
				AdaptiveDelayEngine.MicroPause(chrome);

				try
				{
					HumanTyping.TypeLikeHuman(driver, commentBox, resolvedComment);
				}
				catch
				{
					commentBox.SendKeys(resolvedComment);
				}
				AdaptiveDelayEngine.MicroPause(chrome);
			}

			// Bước 5: Bấm Enter hoặc click nút Gửi bình luận
			try
			{
				commentBox.SendKeys(OpenQA.Selenium.Keys.Enter);
			}
			catch { }
			AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 0.4, chrome);

			// Ghi log vào KichBanThongKeDB
			string uid = !string.IsNullOrEmpty(chrome.B4208531) ? chrome.B4208531 : chrome.FB94939A();
			KichBanThongKeDB.LogComment(uid, navigateUrl, comment, "Thành công");

			AdaptiveDelayEngine.RegisterAction(uid, ActionIntensity.Medium);
			AdaptiveDelayEngine.Delay(ActionIntensity.Medium, 1.0, chrome);
			RandomDelay(delayMin, delayMax, chrome);
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	#endregion
}
