using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LushCareTests
{
    class Program
    {
        static int passedCount = 0;
        static int failedCount = 0;

        static void Assert(bool condition, string testName, string details = "")
        {
            if (condition)
            {
                passedCount++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[PASS] ");
                Console.ResetColor();
                Console.WriteLine($"{testName} {details}");
            }
            else
            {
                failedCount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[FAIL] ");
                Console.ResetColor();
                Console.WriteLine($"{testName} {details}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("        LUSHCARE GLOBAL - PRODUCTION QA & VERIFICATION TEST SUITE               ");
            Console.WriteLine("================================================================================");
            Console.WriteLine($"Thời gian bắt đầu: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine();

            Test2FABase32Offline();
            TestCheckpointClassifier();
            TestProxyHelperParse();
            TestPrepareAntiDetectionSelfie();
            TestCookieVaultSuite();
            TestDatabaseAutoBackupHubSuite();
            TestQuickSelectorSuite();

            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine($"TỔNG KẾT: {passedCount} PASSED, {failedCount} FAILED");
            Console.WriteLine("================================================================================");

            Environment.Exit(failedCount == 0 ? 0 : 1);
        }

        static void Test2FABase32Offline()
        {
            Console.WriteLine("--- 1. KIỂM THỬ GIẢI MÃ 2FA BASE32 OFFLINE TỐC ĐỘ CAO ---");
            string testSecret = "JBSWY3DPEHPK3PXP"; // Chuẩn RFC 4648 Base32 Secret

            // Test 1: Tính hợp lệ mã 2FA
            string code = Commom.smethod_62(testSecret);
            bool isValid6Digits = Regex.IsMatch(code, @"^\d{6}$");
            Assert(isValid6Digits, "2FA Code Format Check", $"- Secret: {testSecret} => Code: {code}");

            // Test 2: Tốc độ giải mã 1000 lần offline
            Stopwatch sw = Stopwatch.StartNew();
            const int iterations = 1000;
            for (int i = 0; i < iterations; i++)
            {
                string c = Commom.smethod_62(testSecret);
            }
            sw.Stop();
            double avgMs = sw.Elapsed.TotalMilliseconds / iterations;
            Assert(sw.ElapsedMilliseconds < 500, "2FA High-Speed Benchmark", 
                $"- 1,000 lần: {sw.ElapsedMilliseconds}ms (TB: {avgMs:F3}ms/lần, yêu cầu < 0.5ms)");

            // Test 3: Secret có khoảng trắng và chữ thường
            string messySecret = "jbsw y3dp ehpk 3pxp";
            string code2 = Commom.smethod_62(messySecret);
            Assert(code == code2, "2FA Input Normalization", $"- Trim/Uppercase/Space removal: {code2} == {code}");

            // Test 4: otpauth URL bóc tách tự động
            string otpauthUrl = "otpauth://totp/Facebook:user?secret=JBSWY3DPEHPK3PXP&issuer=Facebook";
            string codeOtpauth = LocalTotpEngine.GenerateTotp(otpauthUrl);
            Assert(code == codeOtpauth, "LocalTotpEngine otpauth:// Parsing", $"- URL {otpauthUrl} => {codeOtpauth}");

            // Test 5: Secret với dấu gạch ngang và thiếu padding
            string hyphenSecret = "jbsw-y3dp-ehpk-3pxp";
            string codeHyphen = LocalTotpEngine.GenerateTotp(hyphenSecret);
            Assert(code == codeHyphen, "LocalTotpEngine Hyphens Removal", $"- Hyphens: {codeHyphen} == {code}");

            // Test 6: Secret không hợp lệ trả về rỗng an toàn không ném Exception
            string invalidCode = LocalTotpEngine.GenerateTotp("1890invalid!@#");
            Assert(invalidCode == "", "LocalTotpEngine Invalid Secret Safe Handling", $"- Invalid => '{invalidCode}'");

            // Test 7: GetSecondsRemaining trong khoảng [1, 30]
            int remaining = LocalTotpEngine.GetSecondsRemaining();
            Assert(remaining >= 1 && remaining <= 30, "LocalTotpEngine GetSecondsRemaining", $"- Remaining: {remaining}s");

            // Test 8: ValidateTotp chuẩn và dung sai Drift
            bool isValidCode = LocalTotpEngine.ValidateTotp(testSecret, code, 1);
            Assert(isValidCode, "LocalTotpEngine ValidateTotp (Exact Match)", $"- Validate {code} => {isValidCode}");

            bool isInvalidCode = LocalTotpEngine.ValidateTotp(testSecret, "999999", 1);
            Assert(!isInvalidCode, "LocalTotpEngine ValidateTotp (Reject Wrong Code)", $"- Validate 999999 => {!isInvalidCode}");

            // Test 9: GenerateWithDriftTolerance
            string driftCode = LocalTotpEngine.GenerateWithDriftTolerance("Key: JBSWY3DPEHPK3PXP");
            Assert(driftCode == code, "LocalTotpEngine GenerateWithDriftTolerance", $"- Extracted key code: {driftCode} == {code}");
            Console.WriteLine();
        }

        static void TestCheckpointClassifier()
        {
            Console.WriteLine("--- 2. KIỂM THỬ PHÂN LOẠI CHECKPOINT CLASSIFIER (DOM / HTML) ---");

            // Checkpoint 956 URL & DOM
            var res956Url = CheckpointClassifier.Classify("https://www.facebook.com/checkpoint/828281030927956", "");
            Assert(res956Url == CheckpointType.Checkpoint956_Lockout, "Phân loại 956 qua URL (828281030927956)", $"=> {res956Url}");

            var res956Html = CheckpointClassifier.Classify("https://m.facebook.com/", "<div>Tài khoản của bạn đã bị khóa</div>");
            Assert(res956Html == CheckpointType.Checkpoint956_Lockout, "Phân loại 956 qua Tiếng Việt DOM", $"=> {res956Html}");

            var res956En = CheckpointClassifier.Classify("", "<div>Your account has been locked. We noticed unusual activity.</div>");
            Assert(res956En == CheckpointType.Checkpoint956_Lockout, "Phân loại 956 qua Tiếng Anh DOM", $"=> {res956En}");

            // Checkpoint 282 URL & DOM
            var res282Url = CheckpointClassifier.Classify("https://www.facebook.com/checkpoint/1501092823525282", "");
            Assert(res282Url == CheckpointType.Checkpoint282_PhotoVerify, "Phân loại 282 qua URL (1501092823525282)", $"=> {res282Url}");

            var res282Html = CheckpointClassifier.Classify("", "<form><span>Tải lên ảnh của chính bạn</span><input type='file'/></form>");
            Assert(res282Html == CheckpointType.Checkpoint282_PhotoVerify, "Phân loại 282 qua Tiếng Việt DOM", $"=> {res282Html}");

            var res282En = CheckpointClassifier.Classify("", "<div>Upload a photo of yourself to help confirm this is your account</div>");
            Assert(res282En == CheckpointType.Checkpoint282_PhotoVerify, "Phân loại 282 qua Tiếng Anh DOM", $"=> {res282En}");

            // Suspended / 180 Days
            var resSuspended = CheckpointClassifier.Classify("https://www.facebook.com/account/suspended", "We suspended your account. You have 180 days left to disagree.");
            Assert(resSuspended == CheckpointType.AccountSuspended, "Phân loại Account Suspended 180 ngày", $"=> {resSuspended}");

            // Account Disabled
            var resDisabled = CheckpointClassifier.Classify("https://www.facebook.com/checkpoint/disabled", "Your account has been disabled");
            Assert(resDisabled == CheckpointType.AccountDisabled, "Phân loại Account Disabled vĩnh viễn", $"=> {resDisabled}");

            // Two-Factor Auth (2FA)
            var res2FA = CheckpointClassifier.Classify("https://www.facebook.com/checkpoint/login_approvals", "<input name='approvals_code' />");
            Assert(res2FA == CheckpointType.TwoFactorAuth, "Phân loại Two-Factor Authentication (2FA)", $"=> {res2FA}");

            // None (Trang bình thường)
            var resNone = CheckpointClassifier.Classify("https://www.facebook.com/home.php", "<div>Bảng tin Facebook</div>");
            Assert(resNone == CheckpointType.None, "Phân loại Trang bình thường (None)", $"=> {resNone}");

            Console.WriteLine();
        }

        static void TestProxyHelperParse()
        {
            Console.WriteLine("--- 3. KIỂM THỬ PROXYHELPER.PARSE & VALIDATE PROXY FORMAT ---");

            // Test 1: Định dạng IP:Port
            var p1 = ProxyHelper.Parse("127.0.0.1:8080");
            Assert(p1.IsValid && p1.Host == "127.0.0.1" && p1.Port == 8080 && string.IsNullOrEmpty(p1.Username),
                "Parse IP:Port", $"- Kết quả: {p1.ToCleanString()}");

            // Test 2: Định dạng IP:Port:User:Pass
            var p2 = ProxyHelper.Parse("103.74.120.5:9999:proxyuser:proxypass123");
            Assert(p2.IsValid && p2.Host == "103.74.120.5" && p2.Port == 9999 && p2.Username == "proxyuser" && p2.Password == "proxypass123",
                "Parse IP:Port:User:Pass", $"- Kết quả: {p2.Host}:{p2.Port} (User: {p2.Username})");

            // Test 3: Định dạng User:Pass@IP:Port
            var p3 = ProxyHelper.Parse("proxyuser:proxypass123@103.74.120.5:9999");
            Assert(p3.IsValid && p3.Host == "103.74.120.5" && p3.Port == 9999 && p3.Username == "proxyuser" && p3.Password == "proxypass123",
                "Parse User:Pass@IP:Port", $"- Kết quả: {p3.Host}:{p3.Port} (User: {p3.Username})");

            // Test 4: Định dạng Proxy kèm tiền tố http://
            var p4 = ProxyHelper.Parse("http://192.168.1.1:3128");
            Assert(p4.IsValid && p4.Host == "192.168.1.1" && p4.Port == 3128,
                "Parse Proxy kèm tiền tố http://", $"- Kết quả: {p4.Host}:{p4.Port}");

            // Test 5: Chuỗi proxy rác / không hợp lệ
            var p5 = ProxyHelper.Parse("invalid_proxy_format_xyz");
            Assert(!p5.IsValid, "Xác thực chuỗi Proxy không hợp lệ (Reject Invalid)", $"- IsValid: {p5.IsValid}");

            // Test 6: Port không hợp lệ (ngoài phạm vi 1-65535)
            var p6 = ProxyHelper.Parse("127.0.0.1:999999");
            Assert(!p6.IsValid, "Xác thực Port vượt ngưỡng 65535 (Reject Port)", $"- IsValid: {p6.IsValid}");

            Console.WriteLine();
        }

        static void TestPrepareAntiDetectionSelfie()
        {
            Console.WriteLine("--- 4. KIỂM THỬ PREPARE ANTIDETECTION SELFIE (BIẾN THIÊN ẢNH 282) ---");

            string tempOrig = Path.Combine(Path.GetTempPath(), "test_orig_selfie.jpg");
            try
            {
                // Tạo ảnh test JPEG 120x120
                using (var bmp = new Bitmap(120, 120, PixelFormat.Format24bppRgb))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Beige);
                        g.FillEllipse(Brushes.DarkBlue, 20, 20, 80, 80);
                    }
                    bmp.Save(tempOrig, ImageFormat.Jpeg);
                }

                byte[] origBytes = File.ReadAllBytes(tempOrig);
                string origHash = ComputeSha256(origBytes);

                // Gọi hàm PrepareAntiDetectionSelfie
                string processedPath = CheckpointClassifier.PrepareAntiDetectionSelfie(tempOrig);

                Assert(File.Exists(processedPath), "Tệp ảnh sau biến thiên được tạo thành công", $"- Đường dẫn: {processedPath}");

                byte[] processedBytes = File.ReadAllBytes(processedPath);
                string newHash = ComputeSha256(processedBytes);

                Assert(origHash != newHash, "Mã băm SHA-256 thay đổi hoàn toàn (Anti-Duplicate Bypass)", 
                    $"- Orig SHA: {origHash.Substring(0, 12)}... => New SHA: {newHash.Substring(0, 12)}...");

                // Kiểm tra ảnh biến thiên đọc được bình thường (valid image format)
                bool validBmp = false;
                using (var testBmp = new Bitmap(processedPath))
                {
                    validBmp = testBmp.Width > 0 && testBmp.Height > 0;
                }
                Assert(validBmp, "Ảnh biến thiên là ảnh hợp lệ (Loadable Bitmap)", $"- Kích thước: 120x120");

                // Cleanup
                try { if (File.Exists(processedPath)) File.Delete(processedPath); } catch { }
            }
            finally
            {
                try { if (File.Exists(tempOrig)) File.Delete(tempOrig); } catch { }
            }
            Console.WriteLine();
        }

        static void TestCookieVaultSuite()
        {
            Console.WriteLine("--- 5. KIỂM THỬ BỘ CHUYỂN ĐỔI COOKIEVAULTCONVERTER (TASK 2) ---");

            string sampleRaw = "c_user=100089123456789; xs=2%3Aabc_xyz123%3A2%3A1700000000; fr=0abc123xyz; sb=sb_random_token;";
            string sampleUid = "100089123456789";

            // Test 1: Raw -> JSON
            string jsonPretty = CookieVaultConverter.CookieToJson(sampleRaw, ".facebook.com", pretty: true);
            string jsonCompact = CookieVaultConverter.CookieToJson(sampleRaw, ".facebook.com", pretty: false);
            bool isJsonValid = jsonPretty.StartsWith("[") && jsonPretty.Contains("\"name\": \"c_user\"") && jsonPretty.Contains("\"value\": \"100089123456789\"");
            Assert(isJsonValid, "CookieToJson chuyển đổi thành công sang JSON JArray chuẩn", $"- Length: {jsonPretty.Length} chars");
            Assert(jsonCompact.StartsWith("[") && !jsonCompact.Contains("\r\n"), "CookieToJson compact không chứa xuống dòng", "");

            // Test 2: JSON -> Raw
            string rawFromJson = CookieVaultConverter.JsonToRawCookie(jsonPretty);
            bool isRawFromJsonValid = rawFromJson.Contains("c_user=100089123456789") && rawFromJson.Contains("xs=2%3Aabc_xyz123%3A2%3A1700000000");
            Assert(isRawFromJsonValid, "JsonToRawCookie khôi phục chính xác về chuỗi Raw", $"- Raw: {rawFromJson.Substring(0, Math.Min(60, rawFromJson.Length))}...");

            // Test 3: Raw -> Netscape
            string netscape = CookieVaultConverter.CookieToNetscape(sampleRaw, ".facebook.com");
            bool isNetscapeValid = netscape.StartsWith("# Netscape HTTP Cookie File") && 
                                   netscape.Contains(".facebook.com\tTRUE\t/\tTRUE\t") && 
                                   netscape.Contains("c_user\t100089123456789");
            Assert(isNetscapeValid, "CookieToNetscape tạo đúng chuẩn định dạng curl/antidetect", $"- Dòng đầu: # Netscape HTTP Cookie File");

            // Test 4: Netscape -> Raw
            string rawFromNetscape = CookieVaultConverter.NetscapeToRawCookie(netscape);
            bool isRawFromNetscapeValid = rawFromNetscape.Contains("c_user=100089123456789") && rawFromNetscape.Contains("xs=");
            Assert(isRawFromNetscapeValid, "NetscapeToRawCookie khôi phục chính xác về chuỗi Raw", $"- Raw: {rawFromNetscape.Substring(0, Math.Min(60, rawFromNetscape.Length))}...");

            // Test 5: Base64 chuyển đổi 2 chiều
            string base64 = CookieVaultConverter.ToBase64(sampleRaw);
            string rawFromBase64 = CookieVaultConverter.Base64ToRaw(base64);
            Assert(rawFromBase64.Contains("c_user=100089123456789"), "Base64 chuyển đổi và khôi phục Raw thành công", $"- B64: {base64.Substring(0, 20)}...");

            // Test 6: NormalizeToRaw đa định dạng tự động nhận diện
            string normRaw = CookieVaultConverter.NormalizeToRaw("Cookie: " + sampleRaw);
            string normJson = CookieVaultConverter.NormalizeToRaw(jsonCompact);
            string normNetscape = CookieVaultConverter.NormalizeToRaw(netscape);
            string normBase64 = CookieVaultConverter.NormalizeToRaw(base64);

            Assert(normRaw.Contains("c_user=100089123456789") && normRaw.Contains("xs="), "NormalizeToRaw chuẩn hóa từ Raw có tiền tố 'Cookie: '", "");
            Assert(normJson.Contains("c_user=100089123456789") && normJson.Contains("xs="), "NormalizeToRaw tự động nhận diện và chuẩn hóa từ JSON", "");
            Assert(normNetscape.Contains("c_user=100089123456789") && normNetscape.Contains("xs="), "NormalizeToRaw tự động nhận diện và chuẩn hóa từ Netscape", "");
            Assert(normBase64.Contains("c_user=100089123456789") && normBase64.Contains("xs="), "NormalizeToRaw tự động nhận diện và chuẩn hóa từ Base64", "");

            // Test 7: ValidateFacebookCookie
            var (validUid, isValid) = CookieVaultConverter.ValidateFacebookCookie(sampleRaw);
            Assert(isValid && validUid == sampleUid, "ValidateFacebookCookie nhận diện Cookie hợp lệ và bóc tách đúng UID", $"- UID: {validUid}, isValid: {isValid}");

            // Test 8: ValidateFacebookCookie phát hiện Cookie thiếu xs
            string invalidRaw = "c_user=100089123456789; fr=test_token; sb=test;";
            var (uidNoXs, isValidNoXs) = CookieVaultConverter.ValidateFacebookCookie(invalidRaw);
            Assert(!isValidNoXs && uidNoXs == sampleUid, "ValidateFacebookCookie phát hiện thiếu xs (hết hạn / không hợp lệ)", $"- UID: {uidNoXs}, isValid: {isValidNoXs}");

            // Test 9: ValidateFacebookCookie phát hiện chuỗi rỗng / rác
            var (emptyUid, isEmptyValid) = CookieVaultConverter.ValidateFacebookCookie("invalid_cookie_random_text");
            Assert(!isEmptyValid && string.IsNullOrEmpty(emptyUid), "ValidateFacebookCookie từ chối chuỗi rác", "");

            // Test 10: ParseMultipleCookies phân tách danh sách cookie
            string multiText = sampleRaw + "\r\n" + "c_user=100099999999999; xs=2%3Atoken2; fr=fr2;\r\n" + jsonCompact;
            var multiList = CookieVaultConverter.ParseMultipleCookies(multiText);
            Assert(multiList.Count == 3, "ParseMultipleCookies phân tách chính xác danh sách đa dòng và đa định dạng", $"- Tìm thấy: {multiList.Count} cookies");

            Console.WriteLine();
        }

        static void TestDatabaseAutoBackupHubSuite()
        {
            Console.WriteLine("--- 6. KIỂM THỬ TỰ ĐỘNG SAO LƯU 7 NGÀY & KHÔI PHỤC DATABASE SQLITE ---");

            // Test 1: GetDatabasePath
            string dbPath = DatabaseAutoBackupHub.GetDatabasePath();
            Assert(!string.IsNullOrEmpty(dbPath) && (dbPath.EndsWith(".sqlite") || dbPath.EndsWith(".db")),
                "GetDatabasePath định vị chính xác đường dẫn SQLite DB", $"- Path: {dbPath}");

            // Test 2: GetBackupDirectory
            string backupDir = DatabaseAutoBackupHub.GetBackupDirectory();
            Assert(!string.IsNullOrEmpty(backupDir) && Directory.Exists(backupDir),
                "GetBackupDirectory tự động tạo và định vị thư mục backup", $"- BackupDir: {backupDir}");

            // Test 3: CreateBackup
            string backupFile = DatabaseAutoBackupHub.CreateBackup("manual_test");
            Assert(!string.IsNullOrEmpty(backupFile) && File.Exists(backupFile),
                "CreateBackup tạo bản sao lưu thành công với cơ chế an toàn", $"- File: {backupFile}");

            // Test 4: File naming pattern check
            string fileName = Path.GetFileName(backupFile);
            bool nameMatches = Regex.IsMatch(fileName, @"^db_(lushcare|maxcare)_backup_\d{8}_\d{6}.*\.sqlite$");
            Assert(nameMatches, "Tên file backup chuẩn format: db_*_backup_yyyyMMdd_HHmmss.sqlite", $"- Name: {fileName}");

            // Test 5: GetBackupList
            var backupList = DatabaseAutoBackupHub.GetBackupList();
            Assert(backupList != null && backupList.Count > 0 && backupList.Any(f => f.FullName == backupFile),
                "GetBackupList nạp danh sách bản sao lưu thành công", $"- Tổng số bản backup: {backupList?.Count}");

            // Test 6: PruneOldBackups
            DatabaseAutoBackupHub.PruneOldBackups(7);
            var prunedList = DatabaseAutoBackupHub.GetBackupList();
            Assert(prunedList.Count <= 7, "PruneOldBackups giới hạn tối đa 7 bản sao lưu gần nhất", $"- Còn lại: {prunedList.Count} bản");

            // Test 7: RestoreBackup
            bool restoreSuccess = DatabaseAutoBackupHub.RestoreBackup(backupFile, out string restoreError);
            Assert(restoreSuccess && string.IsNullOrEmpty(restoreError),
                "RestoreBackup khôi phục SQLite database an toàn và toàn vẹn", $"- Error: {restoreError ?? "none"}");

            // Test 8: Backup before restore check (.bak)
            var dir = new DirectoryInfo(backupDir);
            var bakFiles = dir.GetFiles("db_before_restore_*.sqlite.bak");
            Assert(bakFiles.Length > 0, "RestoreBackup tự động tạo bản sao an toàn trước khi ghi đè (.sqlite.bak)", $"- Số bản pre-restore: {bakFiles.Length}");

            Console.WriteLine();
        }

        static void TestQuickSelectorSuite()
        {
            Console.WriteLine("--- 7. KIỂM THỬ QUICK SELECTOR CHỌN NHANH TÀI KHOẢN (TRUST SCORE & TRẠNG THÁI) ---");

            // Test 1: ExtractTrustScore với các định dạng khác nhau
            int? score1 = QuickSelectorEvaluator.ExtractTrustScore("[Trust 85★ Trâu] - Khỏe mạnh");
            Assert(score1 == 85, "ExtractTrustScore định dạng chuẩn [Trust 85★ Trâu]", $"- Score: {score1}");

            int? score2 = QuickSelectorEvaluator.ExtractTrustScore("[Trust 40⚠️ Yếu] - Cần ngâm");
            Assert(score2 == 40, "ExtractTrustScore định dạng cảnh báo [Trust 40⚠️ Yếu]", $"- Score: {score2}");

            int? score3 = QuickSelectorEvaluator.ExtractTrustScore("Trust Score: 92");
            Assert(score3 == 92, "ExtractTrustScore định dạng text 'Trust Score: 92'", $"- Score: {score3}");

            int? score4 = QuickSelectorEvaluator.ExtractTrustScore("Tài khoản đạt 75 điểm");
            Assert(score4 == 75, "ExtractTrustScore định dạng '75 điểm'", $"- Score: {score4}");

            // Test 2: Tiêu chí Nick Trâu (>=80đ)
            bool trau1 = QuickSelectorEvaluator.EvaluateStrongCriteria("[Trust 85★ Trâu]");
            Assert(trau1, "Nick Trâu: phát hiện badge [Trust 85★ Trâu] (>=80đ)", "");

            bool trau2 = QuickSelectorEvaluator.EvaluateStrongCriteria("Dàn nick trâu đi cày tương tác");
            Assert(trau2, "Nick Trâu: nhận diện từ khóa 'trâu' trong ghi chú", "");

            bool trau3 = QuickSelectorEvaluator.EvaluateStrongCriteria("[Trust 40⚠️ Yếu]");
            Assert(!trau3, "Nick Trâu: từ chối badge nick yếu [Trust 40⚠️ Yếu]", "");

            bool trau4 = QuickSelectorEvaluator.EvaluateStrongCriteria("", dynamicScore: 82);
            Assert(trau4, "Nick Trâu: nhận diện chính xác qua dynamicScore >= 80", "");

            bool trau5 = QuickSelectorEvaluator.EvaluateStrongCriteria("", dynamicScore: 65);
            Assert(!trau5, "Nick Trâu: từ chối dynamicScore < 80 (65đ)", "");

            // Test 3: Tiêu chí Nick Yếu (<50đ)
            bool yeu1 = QuickSelectorEvaluator.EvaluateWeakCriteria("[Trust 40⚠️ Yếu]");
            Assert(yeu1, "Nick Yếu: phát hiện badge [Trust 40⚠️ Yếu] (<50đ)", "");

            bool yeu2 = QuickSelectorEvaluator.EvaluateWeakCriteria("Nick yếu mới reg cần warm-up");
            Assert(yeu2, "Nick Yếu: nhận diện từ khóa 'yếu' trong ghi chú", "");

            bool yeu3 = QuickSelectorEvaluator.EvaluateWeakCriteria("[Trust 85★ Trâu]");
            Assert(!yeu3, "Nick Yếu: từ chối badge nick trâu [Trust 85★ Trâu]", "");

            bool yeu4 = QuickSelectorEvaluator.EvaluateWeakCriteria("", dynamicScore: 35);
            Assert(yeu4, "Nick Yếu: nhận diện chính xác qua dynamicScore < 50", "");

            bool yeu5 = QuickSelectorEvaluator.EvaluateWeakCriteria("", dynamicScore: 70);
            Assert(!yeu5, "Nick Yếu: từ chối dynamicScore >= 50 (70đ)", "");

            // Test 4: Tiêu chí Nick Live
            bool live1 = QuickSelectorEvaluator.EvaluateLiveCriteria("Live");
            Assert(live1, "Nick Live: trạng thái 'Live'", "");

            bool live2 = QuickSelectorEvaluator.EvaluateLiveCriteria("Hoạt động bình thường");
            Assert(live2, "Nick Live: trạng thái 'Hoạt động bình thường'", "");

            bool live3 = QuickSelectorEvaluator.EvaluateLiveCriteria("Đăng nhập OK");
            Assert(live3, "Nick Live: trạng thái không chứa die/checkpoint ('Đăng nhập OK')", "");

            bool live4 = QuickSelectorEvaluator.EvaluateLiveCriteria("Checkpoint 282");
            Assert(!live4, "Nick Live: từ chối 'Checkpoint 282'", "");

            bool live5 = QuickSelectorEvaluator.EvaluateLiveCriteria("Checkpoint 956 - Két sắt");
            Assert(!live5, "Nick Live: từ chối 'Checkpoint 956'", "");

            bool live6 = QuickSelectorEvaluator.EvaluateLiveCriteria("Die cookie");
            Assert(!live6, "Nick Live: từ chối 'Die cookie'", "");

            bool live7 = QuickSelectorEvaluator.EvaluateLiveCriteria("Tài khoản bị khóa vĩnh viễn");
            Assert(!live7, "Nick Live: từ chối 'Tài khoản bị khóa'", "");

            // Test 5: Tiêu chí Nick Checkpoint
            bool cp1 = QuickSelectorEvaluator.EvaluateCheckpointCriteria("Checkpoint 282 upload ảnh");
            Assert(cp1, "Nick Checkpoint: phát hiện 'Checkpoint 282'", "");

            bool cp2 = QuickSelectorEvaluator.EvaluateCheckpointCriteria("Checkpoint 956");
            Assert(cp2, "Nick Checkpoint: phát hiện 'Checkpoint 956'", "");

            bool cp3 = QuickSelectorEvaluator.EvaluateCheckpointCriteria("Nick die");
            Assert(cp3, "Nick Checkpoint: phát hiện 'die'", "");

            bool cp4 = QuickSelectorEvaluator.EvaluateCheckpointCriteria("Tài khoản bị khóa tạm thời");
            Assert(cp4, "Nick Checkpoint: phát hiện 'khóa'", "");

            bool cp5 = QuickSelectorEvaluator.EvaluateCheckpointCriteria("Live");
            Assert(!cp5, "Nick Checkpoint: từ chối trạng thái 'Live'", "");

            bool cp6 = QuickSelectorEvaluator.EvaluateCheckpointCriteria("Hoạt động");
            Assert(!cp6, "Nick Checkpoint: từ chối trạng thái 'Hoạt động'", "");

            // Test 6: Kiểm tra khởi tạo GDI+ Icon không lỗi, đúng kích thước 16x16
            using (var iconStrong = QuickSelectorEvaluator.CreateStrongIcon())
            using (var iconWeak = QuickSelectorEvaluator.CreateWeakIcon())
            using (var iconLive = QuickSelectorEvaluator.CreateLiveIcon())
            using (var iconCheckpoint = QuickSelectorEvaluator.CreateCheckpointIcon())
            {
                Assert(iconStrong != null && iconStrong.Width == 16 && iconStrong.Height == 16,
                    "CreateStrongIcon tạo icon 16x16 hợp lệ", "");
                Assert(iconWeak != null && iconWeak.Width == 16 && iconWeak.Height == 16,
                    "CreateWeakIcon tạo icon 16x16 hợp lệ", "");
                Assert(iconLive != null && iconLive.Width == 16 && iconLive.Height == 16,
                    "CreateLiveIcon tạo icon 16x16 hợp lệ", "");
                Assert(iconCheckpoint != null && iconCheckpoint.Width == 16 && iconCheckpoint.Height == 16,
                    "CreateCheckpointIcon tạo icon 16x16 hợp lệ", "");
            }

            Console.WriteLine();
        }

        static string ComputeSha256(byte[] data)
        {
            using (var sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}