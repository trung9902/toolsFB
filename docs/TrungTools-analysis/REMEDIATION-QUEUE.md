# Hàng đợi xử lý — mỗi lần một vấn đề

Không thực hiện tất cả trong một PR. Mỗi issue phải theo chu kỳ:

`confirm source → viết regression test thất bại → patch nhỏ → build/test → runtime fixture cô lập → user duyệt → commit`

## Gate 0 — làm test đáng tin trước

| Step | Issue | Acceptance |
|---:|---|---|
| 0.1 | Đưa test project vào solution hoặc tạo test solution rõ ràng | Build solution biên dịch cả app và test |
| 0.2 | Đổi HintPath binary sang ProjectReference/fresh artifact | Test không thể chạy binary cũ |
| 0.3 | Bật/tách `TestDangBaiSuite` | Suite được compile/discover |
| 0.4 | Temp DB/filesystem/clock/logger fixtures | Test không chạm dữ liệu thật |

## P0 — xử lý đầu tiên

1. **TT-S01 — TLS IMAP accept-all**  
   Test chứng chỉ không tin cậy phải fail trước Authenticate; xóa callback.

2. **TT-D02 — thống nhất database path**  
   Characterization test mọi repository resolve cùng một path; thêm resolver duy nhất, không migrate dữ liệu tự động nếu chưa có backup/approval.

3. **TT-D01 — backup SQLite nhất quán**  
   Fixture WAL chưa checkpoint; backup phải chứa row sentinel và pass `integrity_check`.

4. **#32 / TT-D04 — credential vault/lifecycle**  
   Thiết kế migration versioned trước; mã hóa DPAPI CurrentUser; tuyệt đối không rewrite toàn DB trong một bước không rollback.

5. **#17/#18/TT-U01 — shared extension/driver mutation**  
   Gỡ credential plaintext trong extension và cdc patch; updater atomic + integrity validation; test concurrency.

6. **TT-T01 — Thread.Abort/cross-thread UI**  
   Sửa theo một workflow trước, không đại tu toàn fMain; đo cancellation latency.

7. **TT-O01 — logging thật**  
   Thay call sites critical trước; rolling/redaction/correlation; không log cookie/password/OTP/HTML raw.

## P1 — sau khi P0 ổn định

8. **#2 + TT-R02 — false-success rename/save/comment/share**  
   Typed result và hậu điều kiện observable.

9. **TT-R01 — LogPost argument corruption**  
   Named DTO + contract test; script sửa lịch sử chỉ sau khi người dùng duyệt.

10. **#6 — AccountFormatDetector ambiguity**  
    Confidence + margin + preview; dữ liệu hỗn hợp phải yêu cầu xác nhận.

11. **#26 — checkpoint classifier consolidation**  
    Một classifier; Unknown không bao giờ tự thành 956; characterization tests giữ mapping cũ cần thiết.

12. **#34 — CookieVault semantics**  
    Tách StructuralValid / UIDMatch / SessionVerified; không gán unmatched tự động.

13. **#35/#36 — persistent login limiter + proxy containment**  
    Harness offline nhiều worker; backoff theo UID/proxy và circuit event; không thử live.

14. **#20/#23/#30/#31 — scheduler/quota/circuit breaker**  
    Mục tiêu reliability và platform compliance; không phải mô phỏng người dùng để né phát hiện.

15. **TT-D03 — group post Pending lifecycle**  
    Pending/Confirmed/Failed; release on failure/timeout.

16. **#3/TT-O02 — empty catches tại boundary quan trọng**  
    Sửa theo call path P0/P1; không mass-edit 1.401 catch.

## P2/P3 — refactor và UX

- #4 mở rộng Work/Education model nếu product requirement xác nhận.
- #5 rotation/retention toàn bộ log.
- #8–#16 bỏ cơ chế fingerprint giả; dùng browser defaults/official APIs.
- #27–#29 content history/fingerprint để tránh duplicate và tăng chất lượng, không biến đổi để lách policy.
- Typed config thay key string/legacy class.
- Tách `fMain`, `Chrome`, `Commom` theo bounded contexts sau characterization tests.
- Hợp nhất version csproj/assembly/installer và thêm CI/release manifest.

## Issue template dùng cho từng lần sửa

```md
### Issue
- ID:
- Source evidence:
- User-visible impact:
- Scope files:
- Out of scope:

### RED
- Test name:
- Fixture:
- Expected failure:

### GREEN
- Minimal invariant:
- Patch:

### Verification
- Build command/result:
- Test command/result:
- Runtime fixture/result:
- Remaining risks:
```

## Đề xuất issue đầu tiên

Bắt đầu **TT-S01 (IMAP TLS)** vì:

- Trust boundary rõ và impact cao.
- Patch nhỏ, ít coupling.
- Có thể test hoàn toàn offline.
- Không cần chạm Facebook, database thật hoặc UI lớn.
