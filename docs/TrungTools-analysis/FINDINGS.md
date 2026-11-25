# Findings — kiểm chứng danh sách Claude và rà soát bổ sung

> Đây là backlog phân tích, chưa phải danh sách thay đổi đã thực hiện. Severity chỉ áp dụng khi source đủ chứng minh tác động. Các mục phụ thuộc hành vi Facebook/runtime được giữ ở trạng thái NEEDS RUNTIME.

## A. Đối chiếu 36 claim được cung cấp

| ID | Verdict | Priority | Kết luận và bằng chứng chính |
|---:|---|---|---|
| 1 | **REJECTED** | — | `AccountsCenterHub.cs:951` dùng `"./ancestor::..."`, không có `"\ancestor"` hay ký tự BEL. XPath hiện tại hợp lệ; selector vẫn cần fixture DOM để đánh giá độ chính xác. |
| 2 | **CONFIRMED** | P1 | `AccountsCenterHub.cs:934-973`: thiếu Review/Save hoặc re-auth thất bại vẫn rơi tới `SuccessJson()`; không kiểm hậu điều kiện. |
| 3 | **CONFIRMED** | P1 | `ProfileInfoHub.cs:22-37,106-145,348-349,409-410,458-459,507-508,1003-1004`: exception bị nuốt, caller chỉ nhận false. |
| 4 | **CONFIRMED (scope gap)** | P2 | `ProfileInfoHub.cs:392-407,446-456,495-505`: chỉ nhập tên company/school; API wrapper cũng chỉ nhận chuỗi tên. Nếu yêu cầu là hồ sơ đầy đủ thì model hiện thiếu field. |
| 5 | **CONFIRMED** | P1 | `Program.cs:12-39`, `SetupFolder.cs:149-371`, `PostingV2AutomationHelper.cs:59-60`: append log không rotation/retention. |
| 6 | **CONFIRMED** | P1 | `AccountFormatDetector.cs:43-51,113-175`: single-column chỉ nhìn dòng đầu rồi mặc định Cookie; Cookie/Token 40%, nhiều loại 50%; kết quả được auto-apply. |
| 7 | **CONFIRMED RESOLVED** | — | `Legacy/GClass11.cs` tồn tại và SDK project compile thư mục Legacy. Cần build để xác nhận trạng thái worktree hiện tại. |
| 8 | **CONFIRMED** | P2 | `Chrome.cs:982-1018` luôn `--lang=en_US`; request builders cũng có Accept-Language cố định. |
| 9 | **CONFIRMED** | P2 | `Chrome.cs:1437-1442` monkey-patch `navigator.languages` cố định, không đồng bộ với các bề mặt locale khác. |
| 10 | **CONFIRMED** | P2 | `Chrome.cs:2047-2065,7534-7537,12432-12435` và nhiều call site ép `locale=en_US`. |
| 11 | **PARTIAL / NEEDS RUNTIME** | P2 | Không có timezone/locale CDP override (`Chrome.cs:1338-1751`), nhưng mức mismatch thực tế phải đo trong Chrome cô lập. Không khuyến nghị giả timezone theo proxy. |
| 12 | **CONFIRMED, not necessarily defect** | P3 | `Chrome.cs:882-889` đặt geolocation=0. Từ chối vị trí là bảo vệ riêng tư; không nên thay bằng vị trí giả. |
| 13 | **CONFIRMED consistency issue** | P1 | `Chrome.cs:1019-1022,1338-1722`: sửa nhiều fingerprint surface nhưng bỏ các surface khác; còn `--disable-gpu` trong khi giả WebGL. Hướng an toàn là bỏ giả mạo, không hoàn thiện né phát hiện. |
| 14 | **CONFIRMED** | P2 | `Chrome.cs:1575-1627`: 10 GPU profile giả, chọn modulo seed. Không đề xuất mở rộng pool; nên bỏ giả GPU. |
| 15 | **CONFIRMED** | P2 | `fMain.cs:5377-5413`, `Chrome.cs:827-888`: viewport lấy từ config chung; rủi ro layout/consistency. Không cần random để né nhận diện. |
| 16 | **CONFIRMED** | P1 | `Chrome.cs:1019-1022` đổi UA nhưng không đồng bộ Client Hints; các HTTP builder còn tạo CH khác nhau. Hướng an toàn: dùng UA mặc định/API chính thức. |
| 17 | **CONFIRMED** | P0 | `Chrome.cs:962-973,1128-1148,1315-1329`: shared extension directory; proxy credentials được ghi plaintext vào `background.js`, quyền `<all_urls>`, có race/cross-session risk. |
| 18 | **CONFIRMED** | P0 | `Chrome.cs:1051-1056,1264-1277`, `Commom.cs:3024-3059`, `ChromeDriverUpdater.cs:220-263`: nhiều worker patch/copy/kill binary chung không atomic/khóa toàn đường gọi. |
| 19 | **CONFIRMED capability** | P1 | `fMain.cs:5531-5785`, `fCauHinhChung.cs:556-819`: cho phép nhiều account/proxy theo cấu hình. Tác động thực tế phụ thuộc giá trị runtime; nên mặc định isolation/quota. |
| 20 | **CONFIRMED** | P1 | `fMain.cs:1759-1763,2024-2029,2103-2108`: phát worker cách nhau 100 ms cố định; không có scheduler/rate limiter cấp campaign. |
| 21 | **PARTIAL** | P1 | AdaptiveDelayEngine được dùng nhiều trong `SendingAutomationHelper`, nhưng phần lớn action cũ không dùng; chính sách delay phân mảnh. |
| 22 | **PARTIAL** | P2 | Không xác nhận đúng exact line/15–36ms trên source hiện tại, nhưng nhiều helper dùng miền delay hẹp; adaptive path rộng hơn. |
| 23 | **CONFIRMED** | P1 | Sleep cố định phổ biến (`Chrome.cs:8129+`, `CheckpointClassifier.cs:386+`, nhiều hub/helper); gây race/lãng phí, cần explicit wait + cancellation. |
| 24 | **NEEDS RUNTIME / policy** | P2 | Warm-up có feed/story/reaction/watch/profile, nhưng không phải mọi workflow đi qua nó. Không dùng warm-up để né kiểm soát; áp quota/opt-in. |
| 25 | **REJECTED/PARTIAL** | — | Claim comment luôn JS instant không đúng đường chính: `SendingAutomationHelper.cs:854-878` dùng HumanTyping/SendKeys. Vẫn có JS/catch rỗng ở share và action khác. |
| 26 | **CONFIRMED** | P1 | Classifier bị lặp ở `CheckpointClassifier`, `FbProfileChecker`, `Chrome`, `SendingAutomationHelper`; `FbProfileChecker.cs:715-732` có thể gán Unknown thành 956. |
| 27 | **PARTIAL** | P2 | Spintax có vòng lặp hỗ trợ nesting cơ bản, nhưng không có similarity/history/quality gate. |
| 28 | **PARTIAL** | P2 | Không phải luôn cùng ảnh, nhưng khi không xóa ảnh thì không có used-set/content hash bền vững; có thể tái sử dụng. Không đề xuất biến đổi ảnh để né phát hiện. |
| 29 | **CONFIRMED** | P2 | `NoiDungTemplateManager.cs:33,62-82` và posting helper tái sử dụng template, không canonical history. |
| 30 | **CONFIRMED** | P1 | Delay theo bài trong account không tạo quota liên-account; worker phát gần đồng thời, adaptive tracker chỉ theo UID. |
| 31 | **CONFIRMED capability/risk** | P1 | Có batch share lên wall/group/page (`fHDShareBai`, `TangTuongTacHub`); cần preview, quota, confirmation, circuit breaker. |
| 32 | **CONFIRMED** | **P0** | `SetupFolder.cs:151-177`: pass/token/cookie/2FA/passmail/proxy plaintext; `CommonSQL.cs:655-695` có thể ghi ra `bin.txt`; backup copy nguyên DB. |
| 33 | **PARTIAL / reframed** | P2 | Cookie Base64 là conversion, không được dùng như crypto at-rest. Nhưng license ở `Commom.cs:145-168` thực sự chỉ Base64 + PERM không signature, tạo bypass local. |
| 34 | **CONFIRMED** | P1 | `CookieVaultConverter.cs:319-346` chỉ kiểm cấu trúc; `fMain.CookieVault.cs:620-703` vẫn có đường gán cookie unmatched/unchecked. |
| 35 | **NEEDS RUNTIME** | P1 | Có `Attempted` per helper instance, nên claim “không có giới hạn nào” sai; chưa có persistent rate/backoff theo UID+proxy qua lần tạo helper mới. |
| 36 | **NEEDS RUNTIME** | P1 | Có `ProxyCircuitBreaker` shared dictionary, nên claim tuyệt đối sai; source chưa chứng minh nó hủy toàn bộ worker đang dùng cùng proxy/checkpoint signal. |

### Kết quả đối chiếu

- **Confirmed/resolved:** 29 mục (một số là capability hoặc consistency issue, không đồng nghĩa vulnerability).
- **Partial:** 5 mục.
- **Rejected rõ:** #1; phần cốt lõi #25.
- **Needs runtime trọng yếu:** #11, #24, #35, #36.

## B. Finding mới quan trọng bị bỏ sót

### TT-S01 — IMAP chấp nhận mọi chứng chỉ TLS

- **State:** CONFIRMED — **High / P0**
- **Evidence:** `CheckpointClassifier.cs:470-481` đặt `ServerCertificateValidationCallback = (...) => true`, sau đó `Authenticate(email,emailPassword)`.
- **Impact:** MITM có thể lấy mật khẩu email/OTP.
- **Fix tối thiểu:** bỏ callback; dùng validation mặc định; CA doanh nghiệp phải cấu hình explicit.
- **Test:** MailKit server fixture/chứng chỉ không tin cậy phải bị từ chối trước Authenticate.

### TT-D01 — Backup SQLite có thể thiếu WAL

- **State:** CONFIRMED — **P0 integrity**
- **Evidence:** `DatabaseAutoBackupHub.cs:115-124` chạy PASSIVE checkpoint rồi copy file DB; failure của checkpoint không chặn copy; không dùng SQLite Backup API/VACUUM INTO và không copy WAL.
- **Impact:** backup có thể hợp lệ về file nhưng thiếu giao dịch mới.
- **Fix:** SQLite Backup API/VACUUM INTO trên connection nhất quán; verify `integrity_check` và data sentinel.

### TT-D02 — Các repository có thể đọc/ghi DB khác nhau

- **State:** CONFIRMED — **P0 integrity**
- **Evidence:** `ConnectorAccounts`/backup ưu tiên `db_lushcare`; `AccountGroupDB`/`KichBanThongKeDB` ưu tiên hoặc fan-out candidate paths.
- **Impact:** UI, group/history và backup có thể nhìn các database khác nhau; dữ liệu phân kỳ.
- **Fix:** `DbPathResolver` duy nhất; migration một lần; cấm fan-out write.

### TT-R01 — `LogPost` truyền lệch tham số

- **State:** CONFIRMED — **P1**
- **Evidence:** chữ ký `KichBanThongKeDB.cs:726` là `(uid, link, content, type, status, accountName)`, nhưng `PostingV2AutomationHelper.cs:476` gọi `(uid, null, postResult, content, "Bài viết tường", "Thành công")`.
- **Impact:** link rỗng, URL thành content, content thành type, type thành status; dedup theo link mất tác dụng. Các call group/page tương tự.
- **Fix:** named arguments/DTO; migration sửa dữ liệu; contract test từng cột.

### TT-O01 — Logger giả `smethod_49`

- **State:** CONFIRMED — **P0 observability**
- **Evidence:** `Commom.cs:932-935` chỉ Base64-encode và return; nhiều call site bỏ return.
- **Impact:** sự kiện/lỗi được tưởng là đã log nhưng biến mất.
- **Fix:** logger facade thật, rolling file trong LocalAppData, structured event, redaction.

### TT-R02 — False-success sau click Save/comment/share

- **State:** CONFIRMED — **P1**
- **Evidence:** `ProfileInfoHub.cs:953-998` trả true ngay sau click; `SendingAutomationHelper.cs:872-887` log comment thành công dù Enter exception bị bỏ qua; share JS không trả kết quả.
- **Impact:** báo cáo sai, retry/dedup sai, không biết DOM/server từ chối.
- **Fix:** hậu điều kiện observable; typed `Success/Failed/Unknown/Restricted`.

### TT-D03 — Lịch sử duplicate group giữ Pending vĩnh viễn sau failure

- **State:** CONFIRMED — **P1**
- **Evidence:** `PostingV2AutomationHelper.cs:599-617` reserve group trước post; failure path không release ở `705-713`.
- **Impact:** lỗi tạm thời khiến group không được retry trong phiên.
- **Fix:** state machine Pending/Confirmed/Failed + timeout/release.

### TT-O02 — 1.401 catch rỗng

- **State:** CONFIRMED metric — **P1 systemic**
- **Evidence:** static count trên 305 tệp C# hiện tại; ví dụ `ProfileInfoHub`, `ConnectorKichBan`, posting/share helpers.
- **Impact:** mất root cause, false-success và circuit breaker thiếu tín hiệu.
- **Fix:** không sửa đại trà; bắt đầu tại boundary P0/P1, log context đã redact và Result<T>.

### TT-T01 — Thread lifecycle không an toàn

- **State:** CONFIRMED — **P0 reliability**
- **Evidence:** 12 `.Abort(`; `Chrome.cs:2981-2983`, `fMain.cs:1241-1243`; background thread truy cập WinForms controls.
- **Impact:** ngắt giữa critical section, corrupt state, UI cross-thread/deadlock.
- **Fix:** cooperative CancellationToken, bounded await, marshal UI updates.

### TT-U01 — Driver updater không có integrity gate và mutation race

- **State:** CONFIRMED source path / package authenticity NEEDS VALIDATION — **P0**
- **Evidence:** updater tải ZIP, kiểm tồn tại/kích thước, giải nén/copy; patch binary; không SHA-256/signature; update có đường không khóa và kill driver khác.
- **Fix:** bỏ cdc patch; updater ngoài runtime; signed manifest/hash/Authenticode; atomic replace.

### TT-D04 — Credential copies không có lifecycle

- **State:** CONFIRMED — **P0**
- **Evidence:** SQLite, Chrome profile, backups, clipboard, `bin.txt`, old-password columns; soft delete giữ credential.
- **Impact:** xóa account không xóa/thu hồi bản sao.
- **Fix:** encrypted vault + inventory/TTL/revoke/clear; backup encrypted; clipboard timeout.

### TT-S02 — Localhost GemLogin không có peer authentication rõ ràng

- **State:** NEEDS RUNTIME
- **Evidence:** `Chrome.cs:12972-12999`, `fHDScriptGemLogin.cs:235-242` gọi HTTP localhost:1010 không thấy token tại call site.
- **Validation:** loopback fixture cô lập; kiểm schema/challenge; không đụng dịch vụ thật.

## C. Testing gaps làm các lỗi sống sót

1. `Tests` không nằm trong `LushCare.sln`.
2. Test project tham chiếu binary `LushCare.exe` qua HintPath, có thể test binary cũ.
3. `TestDangBaiSuite.cs` bị `Compile Remove`.
4. Không xUnit/NUnit/MSTest, coverage, timeout per test hoặc CI gate.
5. Nhiều test copy regex/logic vào test thay vì gọi production.
6. Backup tests có nguy cơ đụng database thật, chưa inject temp path.

## D. Không kết luận từ static source

- Tỷ lệ Facebook checkpoint/ban hoặc khả năng “bị phát hiện”.
- Selector hiện còn hoạt động với DOM/locale/account state thật hay không.
- ACL thật của thư mục app/backup/log.
- Hành vi proxy/circuit breaker khi nhiều worker đang chạy.
- Header/timezone/fingerprint thực tế trong Chrome.
- Tính đầy đủ của backup với workload thật cho tới khi có fixture WAL.
