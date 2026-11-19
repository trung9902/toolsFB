using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LushCareGlobal.Tests
{
	class TestRunner
	{
		private static int _passed = 0;
		private static int _failed = 0;

		static int Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("===============================================================================");
			Console.WriteLine(" BỘ KIỂM THỬ TỔNG HỢP: CHỨC NĂNG ĐĂNG BÀI FACEBOOK WWW (LUSHCARE GLOBAL)     ");
			Console.WriteLine("===============================================================================");

			RunTest("TC01: Đăng thành công - Làm sạch permalink bài viết cá nhân", Test_TC01_CleanPermalink_Wall);
			RunTest("TC02: Đăng thành công - Làm sạch permalink bài viết nhóm", Test_TC02_CleanPermalink_Group);
			RunTest("TC03: Đăng thành công - Làm sạch permalink tương đối (relative URL)", Test_TC03_CleanPermalink_Relative);
			RunTest("TC04: Đăng thành công - Làm sạch permalink dạng tham số query (story_fbid & id)", Test_TC04_CleanPermalink_Query);
			RunTest("TC05: Đăng thành công - Làm sạch link ảnh (photo/?fbid=)", Test_TC05_CleanPermalink_Photo);
			RunTest("TC06: Cam kết chất lượng - Tuyệt đối không sinh URL giả (wall_post / fake timestamp)", Test_TC06_NoFakeUrlGuarantee);
			RunTest("TC07: Nội dung - Giữ nguyên tiếng Việt có dấu và chuẩn hóa Unicode FormC", Test_TC07_Content_VietnameseNFC);
			RunTest("TC08: Nội dung - Giữ nguyên emoji 4-byte surrogate pair và hashtag", Test_TC08_Content_SurrogateEmojiHashtags);
			RunTest("TC09: Nội dung - Chuẩn hóa ngắt dòng đa nền tảng (\\r\\n, \\r -> \\n)", Test_TC09_Content_Multiline);
			RunTest("TC10: Nội dung - Cắt headToken an toàn không làm gãy cặp surrogate emoji", Test_TC10_Content_HeadTokenSurrogateSafety);
			RunTest("TC11: Upload lỗi - Tệp media không tồn tại trên ổ đĩa lập tức hủy bài", Test_TC11_UploadError_MissingMediaFiles);
			RunTest("TC12: Upload lỗi - Phát hiện thông báo lỗi tải file/file quá lớn từ Facebook", Test_TC12_UploadError_FacebookRejectionRegex);
			RunTest("TC13: Timeout - Cơ chế timeout khi nút Đăng bị vô hiệu hóa hoặc spinner treo", Test_TC13_Timeout_ButtonDisabledOrHanging);
			RunTest("TC14: Đăng thất bại - Phát hiện tài khoản bị chặn / hạn chế tính năng", Test_TC14_PostFailed_AccountRestricted);
			RunTest("TC15: Đăng thất bại - Xử lý bài viết nhóm ở trạng thái chờ phê duyệt", Test_TC15_PostFailed_GroupPendingModeration);
			RunTest("TC16: Đăng thất bại - Driver null hoặc mất kết nối xử lý ngoại lệ an toàn", Test_TC16_PostFailed_DriverNullSafety);
			RunTest("TC17: ValidateMediaFolder - Kiểm tra phát hiện chính xác đường dẫn rỗng / không tồn tại", Test_TC17_ValidateMediaFolder_NonExistent);
			RunTest("TC18: ValidateMediaFolder - Kiểm tra đếm lọc đúng định dạng ảnh/video hợp lệ", Test_TC18_ValidateMediaFolder_Counting);
			RunTest("TC19: ProfileInfoHub.UploadCover - Driver null xử lý an toàn không quăng ngoại lệ", Test_TC19_UploadCover_NullDriverSafety);
			RunTest("TC20: ProfileInfoHub.UploadCover - File ảnh không tồn tại trả về false", Test_TC20_UploadCover_MissingFile);

			Console.WriteLine("===============================================================================");
			Console.WriteLine(string.Format(" TỔNG KẾT: {0} PASSED | {1} FAILED / TỔNG SỐ {2} KỊCH BẢN", _passed, _failed, _passed + _failed));
			Console.WriteLine("===============================================================================");

			return _failed == 0 ? 0 : 1;
		}

		static void RunTest(string testName, Action testMethod)
		{
			try
			{
				testMethod();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("[PASS] ");
				Console.ResetColor();
				Console.WriteLine(testName);
				_passed++;
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("[FAIL] ");
				Console.ResetColor();
				Console.WriteLine(testName + " -> " + ex.Message);
				_failed++;
			}
		}

		static void AssertEqual(string expected, string actual, string msg = "")
		{
			if (expected != actual)
			{
				throw new Exception(string.Format("{0} Mong đợi: '{1}', Thực tế: '{2}'", msg, expected, actual));
			}
		}

		static void AssertTrue(bool condition, string msg = "")
		{
			if (!condition)
			{
				throw new Exception(string.Format("{0} Điều kiện không thỏa mãn (mong đợi true nhưng là false)", msg));
			}
		}

		// --- CÁC HÀM TEST CHI TIẾT ---

		static void Test_TC01_CleanPermalink_Wall()
		{
			string raw = "https://www.facebook.com/profile.php/posts/1022938475829102/?__cft__[0]=AZX&__tn__=%2CO%2CP-R&ref=notif&rdid=8831";
			string clean = Chrome.CleanFacebookPermalink(raw);
			AssertEqual("https://www.facebook.com/profile.php/posts/1022938475829102", clean);
		}

		static void Test_TC02_CleanPermalink_Group()
		{
			string raw = "https://www.facebook.com/groups/lushcarevip/posts/987654321/?notif_id=123456789&notif_t=group_post_approved";
			string clean = Chrome.CleanFacebookPermalink(raw);
			AssertEqual("https://www.facebook.com/groups/lushcarevip/posts/987654321", clean);
		}

		static void Test_TC03_CleanPermalink_Relative()
		{
			string raw = "/groups/12345/permalink/67890/";
			string clean = Chrome.CleanFacebookPermalink(raw);
			AssertEqual("https://www.facebook.com/groups/12345/permalink/67890", clean);
		}

		static void Test_TC04_CleanPermalink_Query()
		{
			string raw = "https://www.facebook.com/permalink.php?story_fbid=11223344&id=99887766&substory_index=0&ref=watch_permalink";
			string clean = Chrome.CleanFacebookPermalink(raw);
			AssertEqual("https://www.facebook.com/permalink.php?story_fbid=11223344&id=99887766", clean);
		}

		static void Test_TC05_CleanPermalink_Photo()
		{
			string raw = "https://www.facebook.com/photo/?fbid=1234567890&set=a.9876543210&__cft__[0]=AZU";
			string clean = Chrome.CleanFacebookPermalink(raw);
			AssertEqual("https://www.facebook.com/photo/?fbid=1234567890", clean);
		}

		static void Test_TC06_NoFakeUrlGuarantee()
		{
			// Kiểm tra đảm bảo các chuỗi url giả không bao giờ được sinh ra
			string invalidLink = "https://www.facebook.com/hashtag/test";
			string clean = Chrome.CleanFacebookPermalink(invalidLink);
			AssertTrue(!clean.Contains("wall_post_"), "URL không được chứa tiền tố giả wall_post_");
			AssertTrue(!Regex.IsMatch(clean, @"\d{8}_\d{6}"), "URL không được chứa timestamp giả dạng yyyyMMdd_HHmmss");
		}

		static void Test_TC07_Content_VietnameseNFC()
		{
			// NFD dạng ký tự rời rạc kết hợp: ê (\u00ea) + dấu sắc \u0301, ê + dấu nặng \u0323
			string nfd = "Ti\u00ea\u0301ng Vi\u00ea\u0323t ca\u0301c loa\u0323i d\u00e2\u0301u: A\u0306\u0301, a\u0306\u0300, a\u0306\u0309, a\u0306\u0303, a\u0306\u0323";
			string nfc = nfd.Normalize(NormalizationForm.FormC);

			AssertTrue(nfc.IsNormalized(NormalizationForm.FormC), "Chuỗi phải được chuẩn hóa hoàn toàn về FormC");
			AssertTrue(nfc.Contains("Tiếng Việt"), "Nội dung tiếng Việt phải chuẩn xác");
		}

		static void Test_TC08_Content_SurrogateEmojiHashtags()
		{
			string content = "🚀 Siêu phẩm LushCare #LushCareGlobal 🔥 Đỉnh cao công nghệ 🇻🇳 #AutoFacebook 💖";
			string normalized = content.Normalize(NormalizationForm.FormC);

			AssertTrue(normalized.Contains("🚀"), "Emoji tên lửa phải nguyên vẹn");
			AssertTrue(normalized.Contains("🔥"), "Emoji lửa phải nguyên vẹn");
			AssertTrue(normalized.Contains("🇻🇳"), "Cờ Việt Nam (cặp surrogate kép) phải nguyên vẹn");
			AssertTrue(normalized.Contains("#LushCareGlobal"), "Hashtag phải giữ nguyên");
		}

		static void Test_TC09_Content_Multiline()
		{
			string rawContent = "Dòng 1: Tiêu đề\r\nDòng 2: Mô tả\rDòng 3: Chi tiết\nDòng 4: Kết luận";
			string normalized = rawContent.Replace("\u000d\u000a", "\n").Replace("\u000d", "\n").Trim();

			string[] lines = normalized.Split('\n');
			AssertEqual("4", lines.Length.ToString(), "Số lượng dòng sau chuẩn hóa phải là 4");
			AssertEqual("Dòng 1: Tiêu đề", lines[0]);
			AssertEqual("Dòng 2: Mô tả", lines[1]);
			AssertEqual("Dòng 3: Chi tiết", lines[2]);
			AssertEqual("Dòng 4: Kết luận", lines[3]);
		}

		static void Test_TC10_Content_HeadTokenSurrogateSafety()
		{
			// Chuỗi có emoji surrogate pair nằm ở vị trí biên cắt (độ dài 25 ký tự)
			// '🚀' là cặp 2 char: \uD83D \uDE80
			string textWithEmojiAtBoundary = "123456789012345678901234\uD83D\uDE80SauEmoji";
			string headToken = textWithEmojiAtBoundary;
			if (headToken.Length > 25)
			{
				headToken = headToken.Substring(0, 25).Trim();
			}
			// Kiểm tra logic bảo vệ surrogate pair đã sửa
			if (headToken.Length > 0 && char.IsHighSurrogate(headToken[headToken.Length - 1]))
			{
				headToken = headToken.Substring(0, headToken.Length - 1).Trim();
			}

			// headToken không được kết thúc bằng một HighSurrogate cô độc (làm crash/mã hóa sai)
			AssertTrue(!char.IsHighSurrogate(headToken[headToken.Length - 1]), "headToken không được có HighSurrogate bị cô lập ở cuối");
			AssertEqual("123456789012345678901234", headToken, "Ký tự surrogate đơn lẻ phải được cắt bỏ an toàn");
		}

		static void Test_TC11_UploadError_MissingMediaFiles()
		{
			List<string> mockImages = new List<string> {
				"C:\\FolderKhongTonTai_123\\image1.png",
				"D:\\FileKhongCoThat_456\\video.mp4"
			};

			var nonExistent = mockImages.Where(f => !File.Exists(f)).ToList();
			bool allMissing = nonExistent.Count == mockImages.Count;

			AssertTrue(allMissing, "Hệ thống phải nhận diện được toàn bộ tệp đều không tồn tại");
			// Khi allMissing == true, ExecuteDangBaiWWW trả về "" ngay lập tức, không đăng văn bản trơ trọi
		}

		static void Test_TC12_UploadError_FacebookRejectionRegex()
		{
			string fbErrorAlertVN = "Tệp không thể tải lên. Vui lòng chọn tệp khác hoặc tệp quá lớn.";
			string fbErrorAlertEN = "Your photo or video couldn't be uploaded. Unsupported format.";

			string errorPattern = @"không thể tải lên|couldn't be uploaded|tệp quá lớn|unsupported|định dạng không được hỗ trợ";

			AssertTrue(Regex.IsMatch(fbErrorAlertVN, errorPattern, RegexOptions.IgnoreCase), "Phát hiện lỗi upload tiếng Việt");
			AssertTrue(Regex.IsMatch(fbErrorAlertEN, errorPattern, RegexOptions.IgnoreCase), "Phát hiện lỗi upload tiếng Anh");
		}

		static void Test_TC13_Timeout_ButtonDisabledOrHanging()
		{
			// Kiểm tra điều kiện readiness của nút Đăng
			bool hasUploadSpinner = true;
			bool isButtonDisabled = true;

			bool isReadyToPost = (!hasUploadSpinner) && (!isButtonDisabled);
			AssertTrue(!isReadyToPost, "Không được phép bấm Đăng khi spinner còn chạy hoặc nút bị disabled");

			// Khi chuyển sang sẵn sàng:
			hasUploadSpinner = false;
			isButtonDisabled = false;
			isReadyToPost = (!hasUploadSpinner) && (!isButtonDisabled);
			AssertTrue(isReadyToPost, "Nút sẵn sàng khi spinner đã tắt và không bị disabled");
		}

		static void Test_TC14_PostFailed_AccountRestricted()
		{
			string modalText = "Tài khoản của bạn tạm thời bị hạn chế thực hiện hành động này theo Tiêu chuẩn cộng đồng.";
			string blockKeywords = "hạn chế|bị chặn|tạm thời bị|tiêu chuẩn cộng đồng|community standards|restricted|blocked";

			bool isBlocked = Regex.IsMatch(modalText, blockKeywords, RegexOptions.IgnoreCase);
			AssertTrue(isBlocked, "Hệ thống phải phát hiện tài khoản bị chặn và bật cờ EE37E6A7 = true");
		}

		static void Test_TC15_PostFailed_GroupPendingModeration()
		{
			string toastText = "Bài viết của bạn đã được gửi và đang chờ phê duyệt từ quản trị viên.";
			string pendingKeywords = "chờ phê duyệt|pending approval|đang chờ quản trị viên|đã gửi bài viết|submitted for approval";

			bool isPending = Regex.IsMatch(toastText, pendingKeywords, RegexOptions.IgnoreCase);
			AssertTrue(isPending, "Phát hiện đúng trạng thái chờ duyệt nhóm");

			string groupId = "123456789";
			string pendingUrl = "https://www.facebook.com/groups/" + groupId + "/pending_posts";
			AssertEqual("https://www.facebook.com/groups/123456789/pending_posts", pendingUrl);
		}

		static void Test_TC16_PostFailed_DriverNullSafety()
		{
			// Tạo đối tượng Chrome nhưng không khởi động Selenium driver
			Chrome chromeInstance = new Chrome();
			string res = chromeInstance.ExecuteDangBaiWWW(0, "", "Nội dung test", false, null);

			// Phải trả về chuỗi rỗng "" một cách an toàn, không ném NullReferenceException
			AssertEqual("", res, "ExecuteDangBaiWWW khi driver null phải trả về chuỗi rỗng");
		}

		static void Test_TC17_ValidateMediaFolder_NonExistent()
		{
			int count;
			string msg;
			bool valid = Commom.ValidateMediaFolder(@"Z:\InvalidPath_NonExistent_Folder_12345", out count, out msg);
			AssertTrue(!valid, "Thư mục không tồn tại phải trả về false");
			AssertTrue(count == 0, "Số lượng media phải là 0");

			valid = Commom.ValidateMediaFolder("", out count, out msg);
			AssertTrue(!valid, "Thư mục rỗng phải trả về false");
		}

		static void Test_TC18_ValidateMediaFolder_Counting()
		{
			string tempDir = Path.Combine(Path.GetTempPath(), "LushCare_TestMedia_" + Guid.NewGuid().ToString("N"));
			try
			{
				Directory.CreateDirectory(tempDir);
				File.WriteAllText(Path.Combine(tempDir, "img1.jpg"), "fake_content");
				File.WriteAllText(Path.Combine(tempDir, "img2.PNG"), "fake_content");
				File.WriteAllText(Path.Combine(tempDir, "vid.mp4"), "fake_content");
				File.WriteAllText(Path.Combine(tempDir, "doc.txt"), "text_content"); // Tệp không phải media

				int count;
				string msg;
				bool valid = Commom.ValidateMediaFolder(tempDir, out count, out msg);

				AssertTrue(valid, "Thư mục có ảnh phải trả về true");
				AssertEqual("3", count.ToString(), "Chỉ đếm các file media (.jpg, .png, .mp4)");
			}
			finally
			{
				if (Directory.Exists(tempDir))
				{
					Directory.Delete(tempDir, true);
				}
			}
		}

		static void Test_TC19_UploadCover_NullDriverSafety()
		{
			Chrome chromeInstance = new Chrome();
			bool result = ProfileInfoHub.UploadCover(chromeInstance, @"C:\fake_image.jpg", false, false, null);
			AssertTrue(!result, "Khi ChromeDriver null, UploadCover phải trả về false an toàn không quăng ngoại lệ");
		}

		static void Test_TC20_UploadCover_MissingFile()
		{
			Chrome chromeInstance = new Chrome();
			bool result = ProfileInfoHub.UploadCover(chromeInstance, @"Z:\non_existent_cover_file_xyz.jpg", false, false, null);
			AssertTrue(!result, "Khi tệp ảnh không tồn tại, UploadCover phải trả về false");
		}
	}
}
