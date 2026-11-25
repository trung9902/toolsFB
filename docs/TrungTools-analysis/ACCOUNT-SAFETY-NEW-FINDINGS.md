# Finding mới — nguy cơ mất tài khoản/checkpoint/restriction

> Phạm vi: rà soát tĩnh bổ sung, đã loại trừ các finding trong `FINDINGS.md`. Không gọi Facebook, proxy, email, SMS hoặc tài khoản thật. Source chứng minh đường lỗi; phản ứng checkpoint/khóa thực tế của nền tảng vẫn cần fixture/runtime cô lập. Không có source nghiệp vụ nào được sửa.

## Kết quả Jev

- Model: `jev-1.14.0`
- 12 finding trọng yếu đều vượt ngưỡng đủ bằng chứng 0,70 (0,91–0,94).
- Usage: 8.963 input / 1.429 output token.
- Dữ liệu máy đọc: `jev-account-safety-new.json`.

## P0 theo Jev

### AUTH02 — Tự xác nhận cảnh báo đăng nhập trước khi kiểm tra UID

- **Jev:** P0; evidence 0,94; priority score 2,75; confidence 0,74.
- **Evidence:** `Core/FacebookLoginAutofill.cs:16-41`, `Forms/MainForm/fMain.ProfileSessions.cs:63-81`.
- **Đường lỗi:** `DismissModalsAndAlerts` click “This was me/Đúng là tôi”; sau đó caller mới đọc `c_user` và so UID.
- **Tác động:** có thể xác nhận một phiên đăng nhập bất thường trên profile sai tài khoản thay vì dừng để người dùng kiểm tra.
- **Test offline:** DOM giả có nút cảnh báo và cookie `c_user` khác UID; yêu cầu không click và trả `RequiresManualReview`.

### ISO01 — UID thiếu/sai làm identity guard fail-open

- **Jev:** P0; evidence 0,93; priority score 2,85; confidence 0,85.
- **Evidence:** `Forms/MainForm/fMain.ProfileSessions.cs:8-15`, `Core/ProfileSession.cs:9-18`, `Browser/Chrome.cs:931-952`.
- **Đường lỗi:** UID không hợp lệ → `HasExpectedProfileIdentity` trả `true` → profile `account_<id>` cũ được mở và giữ session cũ.
- **Tác động:** action và cookie có thể chạy/lưu dưới tài khoản khác với dòng dữ liệu.
- **Test offline:** profile tạm có `c_user=222`, dòng kỳ vọng thiếu UID/UID 111; phải fail-closed trước mọi action và cookie persistence.

## P1 trọng yếu

### AUTH01 — Warm-up không xác minh `c_user` khớp UID

- **Jev:** P1; evidence 0,94; score 2,49; confidence 0,49 — cần regression test để chốt P0/P1.
- **Evidence:** `Forms/MainForm/fMain.cs:2746-2760`, `Helpers/AccountWarmUpHelper.cs:62-147`, `fMain.ProfileSessions.cs:8-16`.
- **Tác động:** lướt, reaction, notification hoặc profile visit có thể chạy trên session của tài khoản khác.

### AUTH03 — 2FA tự gửi lại mỗi 12 giây, không có trần attempt

- **Jev:** P1; evidence 0,93; score 1,58; confidence 0,54.
- **Evidence:** `Core/FacebookLoginAutofill.cs:143-217`, `fMain.ProfileSessions.cs:57-96`.
- **Tác động:** cùng TOTP có thể bị gửi nhiều lần trong một cửa sổ; secret sai có thể tiếp tục tạo attempt qua nhiều cửa sổ.

### ISO02 — Không có lease/lock cấp profile

- **Jev:** P1; evidence 0,93; score 2,47; confidence 0,53.
- **Evidence:** `fMain.cs:1744-1768,2011-2045,5435-5452`, `Chrome.cs:931-952`.
- **Tác động:** hai worker cùng UID/accountId có thể mở cùng `--user-data-dir`, gây profile lock, session mixing, corruption hoặc action lặp.

### STATE01 — Trạng thái terminal có thể bị ghi đè thành Live

- **Jev:** P1; evidence 0,92; score 1,86; confidence 0,76.
- **Evidence:** `fMain.cs:2641-2646,2803-2806,4253-4256,4452-4474`.
- **Tác động:** tài khoản vừa bị Checkpoint/Die/Restricted có thể quay lại tập chạy tiếp theo.

### STATE02 — Trust Score bỏ `Status/Info` nhưng khuyến nghị tác vụ nặng

- **Jev:** P1; evidence 0,92; score 2,12; confidence 0,80.
- **Evidence:** `AccountHealthEngine.cs:102-117,281-300,318-331`.
- **Tác động:** tài khoản checkpoint/restricted vẫn có thể được xếp “Trâu” và chọn chạy Spam/Share/Kết bạn.

### WF01 — Nhắn tin có thể gửi nhầm cuộc trò chuyện

- **Jev:** P1; evidence 0,94; score 2,18; confidence 0,80.
- **Evidence:** `FacebookActionsHub.cs:1110-1178`.
- **Đường lỗi:** nếu bất kỳ dock chat nào đang mở, code bỏ điều hướng UID đích rồi chọn textbox rộng.
- **Tác động:** text/ảnh dành cho B có thể gửi cho A.

### RECOV01 — Tự tạo selfie tổng hợp để gửi checkpoint 282

- **Jev:** P1; evidence 0,94; score 2,37; confidence 0,52.
- **Evidence:** `CheckpointClassifier.cs:1032-1044,1142-1192,1399-1497`.
- **Tác động:** bằng chứng nhận dạng không phải của chủ tài khoản có thể làm appeal thất bại hoặc kéo dài khóa.
- **Yêu cầu an toàn:** xóa synthetic fallback/anti-hash; chỉ nhận ảnh do người dùng cung cấp, preview và xác nhận thủ công trước submit.

### PASS01 — UI đổi mật khẩu ánh xạ sai handler runtime

- **Jev:** P1; evidence 0,91; score 2,19; confidence 0,71.
- **Evidence:** `Forms/fHDDoiMatKhau.cs:129-154`, `fMain.cs:9166-9188,9265-9277`.
- **Tác động:** người dùng chọn Account Center nhưng runtime có thể chạy handler khác, gây false-success hoặc lệch credential.

## P2 nhưng side effect đã được source chứng minh

### WF02 — CommentWWW có tối đa ba cơ chế submit nối tiếp

- **Jev:** P2; evidence 0,94; score 1,27; confidence 0,72.
- **Evidence:** `FacebookActionsHub.cs:455-496`.
- **Đường lỗi:** Selenium Enter → JavaScript Enter → click Send/Post, không kiểm hậu điều kiện giữa các bước.
- **Tác động:** có thể gửi 2–3 comment giống nhau.

### WF03 — Lọc Group ID sau khi đã click Join

- **Jev:** P2; evidence 0,94; score 1,49; confidence 0,48.
- **Evidence:** `GroupJoinAutomationHelper.cs:78-96,297-368`.
- **Tác động:** yêu cầu tham gia nhóm ngoài allowlist đã xảy ra trước khi caller loại kết quả.

## Finding mới bổ sung chưa đưa vào batch Jev này

### AUTH04 — Form login có thể submit hai lần sau 1,5 giây

- **Evidence:** `Chrome.cs:10721-10770,10893-10920`.
- **Trigger:** URL và ô password chưa đổi sau 1,5 giây dù request đầu đã được nhận.
- **Tác động:** tăng attempt khi phản hồi chậm hoặc password sai.

### AUTH05 — HTTP credential-to-cookie fallback xử lý checkpoint thiếu state

- **Evidence:** `SmartTokenHub.cs:459-513`, `fMain.cs:4927-4960`.
- **Vấn đề:** POST OTP không replay đầy đủ hidden form state; chỉ cần thấy `c_user` là coi thành công.
- **Tác động:** challenge chưa hoàn tất vẫn có thể được dùng như session hợp lệ và thử lại ở lần sau.

### ISO03 — Persistent profile không ràng buộc proxy/egress

- **Evidence:** `ProfileSession.cs:9-18`, `fMain.cs:2653,5421-5452,5678-6213`, `Chrome.cs:1025-1044`.
- **Tác động:** cùng session cũ có thể mở với proxy khác hoặc direct connection mà không cảnh báo/quarantine.

### ISO04 — `account_<id>` cũ được ưu tiên hơn profile UID

- **Evidence:** `ProfileSession.cs:11-17`, `fMain.cs:4005-4010,4185-4189,4480-4487`.
- **Tác động:** khi cả hai profile tồn tại, session fallback cũ thắng dù UID hiện đã hợp lệ.

### STATE03 — Quick Select coi rỗng/unknown/restricted là Live

- **Evidence:** `fMain.QuickSelector.cs:116-140,376-386,589-619`.
- **Tác động:** dòng chưa kiểm tra hoặc “Account restricted/Không check được” vẫn được tick vào campaign.

### STATE04 — Action guard fail-open khi đọc trạng thái lỗi

- **Evidence:** `SendingAutomationHelper.cs:68-92` và các caller tại `140-146,291-297,406-412,549-555,646-652,786-792`.
- **Tác động:** exception hoặc vocabulary restriction không khớp làm guard trả `false`, rồi upload/publish/message/invite tiếp tục.

### STATE05 — Có `c_user` bị coi là Live trước kiểm tra sâu

- **Evidence:** `fMain.cs:10242-10298`.
- **Tác động:** restricted account vẫn có session cookie có thể bị ghi Live và bỏ qua kiểm tra sâu.

### STATE06 — Warm-up không kiểm restriction giữa các phase

- **Evidence:** `AccountWarmUpHelper.cs:123-147,154-238,245-402,423-458`.
- **Tác động:** restriction phát sinh sau reaction vẫn không dừng story/watch/profile action và cuối phiên có thể ghi “Đã warm-up”.

### WF04 — Nhắn tin gửi Enter rồi click Send

- **Evidence:** `FacebookActionsHub.cs:1236-1254`, `SendingAutomationHelper.cs:503-523`.
- **Tác động:** cùng message có thể được gửi hai lần.

### WF05 — Join group tăng success dù câu hỏi/nội quy chưa submit

- **Evidence:** `GroupJoinAutomationHelper.cs:78-107,410-505`.
- **Tác động:** dialog chưa hoàn tất vẫn tính thành công và tiếp tục nhóm khác.

### WF06 — Workflow kết bạn tiếp tục sau warning/restriction

- **Evidence:** `FriendAutomationHelper.cs:423-447,618-631,649-1080`.
- **Tác động:** một số luồng chỉ log warning hoặc không kiểm warning rồi tiếp tục gửi lời mời.

### WF07 — Đăng bài V2 gặp lỗi wall nhưng vẫn chạy group/page

- **Evidence:** `PostingV2AutomationHelper.cs:405-446,524-632,724-757`.
- **Tác động:** mã lỗi điều hướng chỉ break phase Wall, không chặn các phase Group/Fanpage.

### PAGE01 — Tạo Page tự động fan-out Like/Follow + post

- **Evidence:** `PageCreationHub.cs:669-824`, `Chrome.cs:13375-13377`, `fMain.cs:17643-17743`.
- **Tác động:** mỗi Page tạo thành công phát sinh thêm bundle action không có quota riêng; cancel/lỗi warm-up không propagate để mở circuit breaker.

### PASS02 — Mật khẩu mặc định có entropy yếu

- **Evidence:** `fMain.cs:9177-9181,9187-9195,9320-9323`.
- **Vấn đề:** mẫu `yyMMdd + changepass + 3 chữ số` dễ dự đoán.

### NET01 — Key/token OTP và proxy đi qua HTTP query string

- **Evidence:** `MinProxyVN.cs:223-226,298-304,375-383`; `ShopLike.cs:149-153,184-188,232-235,389-420`; `Legacy/GClass2.cs` nhiều call site.
- **Tác động:** key, phone và request ID có thể bị quan sát/ghi log/sửa trên đường truyền.

## Thứ tự xử lý an toàn đề xuất

1. AUTH02 — dừng tự click “This was me”.
2. ISO01 + AUTH01 — identity guard fail-closed cho mọi profile/warm-up.
3. STATE01 + STATE02 + STATE03 — không để trạng thái unhealthy quay lại campaign.
4. PASS01 — thống nhất enum đổi mật khẩu trước khi chạy mutation tiếp.
5. RECOV01 — xóa synthetic identity evidence và auto-submit.
6. WF01 — ràng buộc conversation ID trước khi nhắn.
7. AUTH03/AUTH04 — một attempt/challenge, hậu điều kiện rõ ràng.
8. ISO02/ISO03/ISO04 — profile lease, owner metadata và proxy-change gate.
9. WF02/WF03/WF04/WF05/WF06/WF07 — idempotency + typed outcome + circuit breaker.
10. NET01/PASS02/PAGE01 — transport, password entropy và quota/cancel propagation.

Mỗi issue phải theo chu kỳ: `test offline đỏ → patch nhỏ → build/test → fixture cô lập → người dùng duyệt → commit`. Không thử các finding này bằng tài khoản thật trước khi có guard và fixture.
