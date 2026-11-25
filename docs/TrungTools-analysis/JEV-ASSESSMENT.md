# Đánh giá ưu tiên bằng Jev

**Model:** `jev-1.14.0`  
**Usage:** 8.405 input token / 1.431 output token  
**Cache:** không; đây là lần đánh giá mới  
**Ngưỡng đủ bằng chứng:** Noul ≥ 0,70

Jev đánh giá mỗi finding bằng bốn câu hỏi atomic:

1. **Noul:** bằng chứng có đủ cụ thể để ưu tiên không?
2. **Choice:** nhóm chính là security, data integrity, reliability, observability hay maintainability?
3. **Score:** tác động nằm trên thang negligible → severe?
4. **Score:** ưu tiên khắc phục nằm trên thang P3 → P0?

| ID | Đủ bằng chứng | Nhóm chính | Xác suất nhóm | Tác động | Ưu tiên Jev | Xác suất mức ưu tiên được chọn | Confidence |
|---|---:|---|---:|---:|---|---:|---:|
| S01 — IMAP bỏ xác minh TLS | 0,95 | Security | 1,00 | 2,91/3 | **P0** | 0,94 | 0,94 |
| D01 — Credential lưu/nhân bản plaintext | 0,96 | Security | 1,00 | 2,94/3 | **P0** | 0,93 | 0,93 |
| D02 — Backup có thể thiếu WAL | 0,93 | Data integrity | 0,93 | 2,00/3 | **P1** | 0,80 | 0,80 |
| DB01 — Các repository có thể lệch DB | 0,77 | Data integrity | 0,99 | 2,20/3 | **P1** | 0,79 | 0,79 |
| R01 — LogPost sai thứ tự tham số | 0,93 | Data integrity | 1,00 | 1,92/3 | **P1** | 0,69 | 0,68 |
| O01 — Logger giả Base64 | 0,92 | Observability | 1,00 | 1,33/3 | **P2** | 0,68 | 0,68 |
| T01 — Thread.Abort/UI chéo luồng | 0,91 | Reliability | 1,00 | 1,85/3 | **P1** | 0,58 | 0,58 |
| U01 — Shared driver mutation/update | 0,91 | Reliability | 0,97 | 2,10/3 | **P1** | 0,63 | 0,63 |
| I01 — Detector auto-map confidence thấp | 0,92 | Data integrity | 0,99 | 2,21/3 | **P1** | 0,87 | 0,87 |
| C01 — Classifier trùng/Unknown→956 | 0,93 | Reliability | 0,97 | 1,97/3 | **P2** | 0,63 | 0,62 |
| F02 — False-success rename/save | 0,94 | Reliability | 0,99 | 1,44/3 | **P1** | 0,58 | 0,58 |
| L01 — License Base64 không chữ ký | 0,95 | Security | 1,00 | 2,48/3 | **P0** | 0,98 | 0,98 |

## Cách đọc

- **Đủ bằng chứng** là xác suất Jev cho rằng state đã có source evidence, reachability và impact đủ để chấm.
- **Xác suất mức ưu tiên** là probability của level được chọn trong Score distribution.
- **Confidence** đo độ tập trung của toàn distribution; confidence thấp nghĩa là các mức lân cận còn cạnh tranh.
- R01, T01, U01, C01 và F02 có confidence dưới 0,70; LLM phải kiểm tra chéo và regression test trước khi chốt thứ tự.
- Jev không tự xác minh file hoặc chạy code. Source evidence và test vẫn quyết định việc sửa.

## Kết luận kết hợp Jev + source review

Nhóm mở đầu hợp lý:

1. **S01 — IMAP TLS**, vì Jev P0/0,94 và trust boundary được source chứng minh trực tiếp.
2. **D01 — credential plaintext**, Jev P0/0,93 nhưng cần thiết kế migration/rollback trước khi sửa.
3. **L01 — license unsigned**, Jev P0/0,98; ảnh hưởng licensing, không phải account-data security.
4. **D02/DB01/I01/R01**, nhóm data integrity P1.
5. Các finding reliability confidence thấp được xử lý sau khi có fixture/test rõ hơn.

Dữ liệu máy đọc đầy đủ: [`jev-priority-results.json`](jev-priority-results.json).
