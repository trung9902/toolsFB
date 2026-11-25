# TrungTools — Hồ sơ phân tích LushCare Global

**Branch:** `TrungTools`  
**Source ref:** `aea62717a9db5b5b453dac66141332231a8e13da` + worktree chưa commit hiện tại  
**Ngày phân tích:** 2026-11-23  
**Chế độ:** static/read-only; chưa sửa code nghiệp vụ, chưa gọi Facebook/proxy/mail thật.

## Phạm vi và độ tin cậy

Repository hiện có **305 tệp C# / 211.461 dòng**, khoảng **1.401 catch rỗng**, **233 `Thread.Sleep`** và **12 `Thread.Abort`**. Worktree đã có hàng trăm rename/modify/delete trước khi tạo branch; branch mới giữ nguyên trạng thái đó.

Ký hiệu:

- **CONFIRMED:** source hiện tại đủ chứng minh lỗi hoặc rủi ro.
- **REJECTED:** claim không đúng với source hiện tại.
- **NEEDS RUNTIME:** có giả thuyết source-grounded nhưng cần test cô lập.
- **PARTIAL:** một phần claim đúng, phần còn lại bị nói quá.

## Tóm tắt điều hành

LushCare là WinForms monolith .NET Framework 4.8 x64. Runtime spine thực tế:

`Program → SetupFolder → fIntro → fMain → account worker → Chrome/Selenium → login/action dispatcher → SQLite → cleanup`

`fMain.cs` (~27.600 dòng), `Chrome.cs` (~13.380 dòng) và `Commom.cs` (~3.396 dòng) đang gánh quá nhiều trách nhiệm. Hai rủi ro nền tảng lớn nhất không phải selector Facebook mà là:

1. **Credential lifecycle:** mật khẩu, cookie, token, passmail và 2FA được lưu và nhân bản dạng rõ.
2. **Integrity/observability:** backup có thể thiếu WAL, đường dẫn DB không thống nhất, logger giả `smethod_49`, nhiều false-success và catch rỗng.

Không nên sửa tất cả cùng lúc. Hướng đúng là chọn từng issue, viết regression test, sửa nhỏ, build/test, rồi mới sang issue tiếp theo.

## Hồ sơ bàn giao

- [ARCHITECTURE.md](ARCHITECTURE.md) — kiến trúc, runtime flow, data flow, chức năng.
- [FINDINGS.md](FINDINGS.md) — kiểm chứng 36 claim của Claude và lỗi bổ sung.
- [REMEDIATION-QUEUE.md](REMEDIATION-QUEUE.md) — thứ tự xử lý từng vấn đề, chưa thực thi.
- [JEV-ASSESSMENT.md](JEV-ASSESSMENT.md) — phân loại, xác suất, confidence và token usage của Jev.
- [jev-priority-results.json](jev-priority-results.json) — dữ liệu Jev đầy đủ dạng máy đọc.
- [architecture.html](architecture.html) — sơ đồ tương tác trực quan.

## Quyết định Jev

Adapter Jev đã được sửa bằng tool chuyên dụng `jev_prioritize_findings`: LLM chỉ truyền danh sách finding có cấu trúc, còn MCP tự dựng câu hỏi atomic, chia mỗi batch 4 finding, kiểm schema và cộng token usage.

Jev `jev-1.14.0` đã đánh giá đủ 12 finding trọng yếu bằng bốn phép đo cho mỗi finding: độ đủ bằng chứng (Noul), nhóm vấn đề (Choice), mức tác động (Score), và ưu tiên khắc phục (Score). Tất cả 12 finding vượt ngưỡng bằng chứng `0.7`; tổng usage là **8.405 input token / 1.431 output token**. Kết quả chi tiết nằm trong [jev-priority-results.json](jev-priority-results.json).

Jev là lớp quyết định bổ sung; file:line, call path và regression test vẫn là bằng chứng có thẩm quyền trước khi sửa code.

## Giới hạn an toàn

Các mục “né phát hiện Facebook”, fingerprint giả, proxy rotation và hành vi hàng loạt chỉ được đánh giá theo reliability, privacy, isolation và tuân thủ. Hồ sơ này không đề xuất kỹ thuật lẩn tránh hoặc vượt kiểm soát nền tảng.
