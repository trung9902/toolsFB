# CẨM NANG VẬN HÀNH & NUOI ACC HIỆU QUẢ — LUSHCARE GLOBAL v26.02
> **Tài liệu chuẩn kiến trúc & quy trình tác chiến từ Senior BA & Lead Automation Architect**  
> *Phiên bản áp dụng:* LushCare Global v26.02+ | *Cập nhật:* Tháng 10/2026

---

## MỤC LỤC TỔNG QUAN
1. [TỔNG QUAN HỆ THỐNG & NGUYÊN TẮC CỐT LÕI](#1-tổng-quan-hệ-thống--nguyên-tắc-cốt-lõi)
2. [CẤU HÌNH MÔI TRƯỜNG & TỐI ƯU TÀI NGUYÊN](#2-cấu-hình-môi-trường--tối-ưu-tài-nguyên)
3. [LỘ TRÌNH 4 GIAI ĐOẠN NUÔI NICK TRUST CAO (FACEBOOK TRUST CYCLE)](#3-lộ-trình-4-giai-đoạn-nuôi-nick-trust-cao-facebook-trust-cycle)
4. [LÀM CHỦ CÁC TÍNH NĂNG PRO ĐỘC QUYỀN TRÊN v26.02](#4-làm-chủ-các-tính-năng-pro-độc-quyền-trên-v2602)
   - 4.1. Module Đăng Bài V2 (HDDangBaiV2 & Page Pro5)
   - 4.2. Hệ Thống AI Đa Tầng (Gemini Latest, ChatGPT, DeepSeek)
   - 4.3. Quản Trị Dữ Liệu & Menu Cập Nhật Nhanh UID
5. [CHIẾN LƯỢC QUẢN TRỊ PROXY & NETWORK AN TOÀN](#5-chiến-lược-quản-trị-proxy--network-an-toàn)
6. [SOP XỬ LÝ SỰ CỐ & GIẢI CỨU CHECKPOINT](#6-sop-xử-lý-sự-cố--giải-cứu-checkpoint)
7. [CHECKLIST VẬN HÀNH HÀNG NGÀY CHO DÀN TÀI KHOẢN](#7-checklist-vận-hành-hàng-ngày-cho-dàn-tài-khoản)

---

## 1. TỔNG QUAN HỆ THỐNG & NGUYÊN TẮC CỐT LÕI

LushCare Global v26.02 được thiết kế dựa trên triết lý **Automation DOM-First**, loại bỏ hoàn toàn các phương thức thao tác thô thiển dễ bị Facebook gắn cờ (như gọi trực tiếp Graph API URL gây lỗi `Unsupported get request 100/33`, hoặc mô phỏng gõ phím rùa bò).

### 3 Nguyên tắc bất biến để dàn nick "bất tử":
1. **Hành vi tự nhiên (Natural Fingerprint):** Mọi hành động Newsfeed, Reels, Story phải có thời gian chờ ngẫu nhiên (`delay 3-10s`), scroll chuột tự nhiên, mô phỏng đúng thói quen người dùng thật.
2. **Tốc độ cao nhưng dứt khoát:** Nhập liệu văn bản sử dụng cơ chế Clipboard Injection (<0.5s), click ngay khi element DOM sẵn sàng, không giữ kết nối Selenium treo vô định.
3. **Phân tách dữ liệu & độc lập phiên:** Mỗi tài khoản sở hữu một Profile Chrome riêng biệt (User Data Dir độc lập), kèm file xuất log kết quả riêng biệt theo từng UID (`output/posts/{uid}.txt`).

---

## 2. CẤU HÌNH MÔI TRƯỜNG & TỐI ƯU TÀI NGUYÊN

### 2.1. Phân bổ số luồng chạy (Threads) theo phần cứng
- **Công thức vàng:** `Số luồng tối ưu = (Số nhân thực CPU x 1.5) đến (Dung lượng RAM trống / 450MB)`
  - *Ví dụ máy 16GB RAM, CPU 8 nhân 16 luồng:* Chạy mượt mà nhất ở mức **8 - 12 luồng đồng thời**.
  - *Ví dụ máy 32GB RAM, CPU 12 nhân 24 luồng:* Thiết lập an toàn ở mức **16 - 24 luồng**.
- **Chế độ hiển thị trình duyệt:**
  - Khi test kịch bản: Bật hiển thị Chrome để kiểm tra tọa độ, layout và flow DOM.
  - Khi vận hành hàng loạt: Có thể thu nhỏ hoặc xếp chồng lưới (Scale window) để tiết kiệm GPU.

### 2.2. Dọn dẹp cache & dung lượng profile
- Profile Chrome sau thời gian dài nuôi sẽ phình to do cache ảnh, video.
- Sử dụng tính năng **"Giải phóng dung lượng"** (`fGiaiPhongDungLuong`) trên thanh công cụ để xóa: `Cache`, `Code Cache`, `GPUCache` mà **vẫn giữ nguyên Cookie, Local Storage và Session Login**.

---

## 3. LỘ TRÌNH 4 GIAI ĐOẠN NUÔI NICK TRUST CAO (FACEBOOK TRUST CYCLE)

Đây là quy trình chuẩn được đúc kết từ thực chiến hàng trăm nghìn tài khoản:

```
[Ngày 1 - 3] GIAI ĐOẠN 1: Cấy Fingerprint & Ngâm IP
     ↓
[Ngày 4 - 7] GIAI ĐOẠN 2: Xây Dựng Đồ Thị Bạn Bè & Profile Thật
     ↓
[Ngày 8 - 14] GIAI ĐOẠN 3: Kích Hoạt Đăng Bài V2 & Quản Trị Page Pro5
     ↓
[Ngày 15+] GIAI ĐOẠN 4: Thương Mại Hóa, Seeding AI & Khai Thác Đỉnh Cao
```

### 🟢 GIAI ĐOẠN 1: CẤY FINGERPRINT & NGÂM IP (Ngày 1 - 3)
*Mục tiêu: Đăng nhập an toàn, tạo lịch sử trình duyệt, không kích hoạt hệ thống phát hiện bất thường.*
- **Kịch bản tương tác đề xuất:**
  - `Lướt Newsfeed`: 60 - 120 giây (Like 1-2 bài ngẫu nhiên).
  - `Xem Video / Reels`: 90 - 180 giây (thả cảm xúc 1 video).
  - `Đọc Thông Báo`: 15 - 30 giây (bấm vào 1 thông báo để tạo traffic nội bộ).
- ⚠️ **Điều cấm kỵ:** Tuyệt đối KHÔNG đổi mật khẩu, KHÔNG đổi mail, KHÔNG kết bạn lạ, KHÔNG đăng bài hay share link.

### 🟡 GIAI ĐOẠN 2: XÂY DỰNG ĐỒ THỊ BẠN BÈ & SOCIAL GRAPH (Ngày 4 - 7)
*Mục tiêu: Định hình danh tính người dùng thật, tăng Trust Score trong mắt thuật toán AI Facebook.*
- **Kịch bản tương tác đề xuất:**
  - `Cập nhật thông tin`: Thay avatar người thật (dùng chức năng Tải Avatar theo tệp), cập nhật tiểu sử ngắn.
  - `Tương tác Bạn bè`: Like bài bạn bè, lướt Story 60s.
  - `Kết bạn chất lượng`: Chỉ kết bạn theo **Gợi ý (Mutual friends)** hoặc tệp UID cùng target ngách (3 - 5 người/ngày).
  - `Tham gia nhóm`: Tìm và xin vào 1 - 2 nhóm công khai đúng sở thích/ngành nghề.

### 🟠 GIAI ĐOẠN 3: MỞ RỘNG TƯƠNG TÁC & BẬT ĐĂNG BÀI V2 (Ngày 8 - 14)
*Mục tiêu: Bắt đầu khai thác năng lực tiếp cận khách hàng tiềm năng.*
- **Kịch bản tương tác đề xuất:**
  - Sử dụng module **Đăng bài V2 (`HDDangBaiV2`)**:
    - Đăng tường cá nhân 1 bài/ngày (kèm 1-3 ảnh đời sống hoặc sản phẩm).
    - Đăng vào 2 - 3 nhóm đã tham gia (Ưu tiên tùy chọn: *"Chỉ đăng nhóm không kiểm duyệt"*).
  - Bật tính năng **"Tương tác bài viết sau khi đăng"**: Tự thả tim và viết 1 bình luận dẫn dắt dưới bài để tăng tương tác ban đầu.
  - Tận dụng hệ thống **Page Profile (Pro5)**: Tự động phát hiện và đăng bài phân luồng qua Page Pro5.

### 🔴 GIAI ĐOẠN 4: THƯƠNG MẠI HÓA & SEEDING AI ĐỈNH CAO (Ngày 15 trở đi)
*Mục tiêu: Bán hàng, kéo phễu, phủ thương hiệu, tương tác hoàn toàn tự động.*
- **Kịch bản tương tác đề xuất:**
  - Bình luận bài viết theo từ khóa bằng **Hệ Thống Prompt AI** (Gemini / ChatGPT).
  - Nhắn tin tự động (Auto Inbox) phản hồi khách hàng theo ngữ cảnh tự nhiên.
  - Tương tác chéo giữa các tài khoản trong hệ thống để kích hoạt thuật toán đẩy đề xuất.

---

## 4. LÀM CHỦ CÁC TÍNH NĂNG PRO ĐỘC QUYỀN TRÊN v26.02

### 4.1. Module Đăng Bài V2 (HDDangBaiV2 & Page Pro5)
Nút **"Đăng bài V2"** được tích hợp ngay hàng đầu của form Thêm hành động, đem lại những cải tiến vượt bậc:
- **Tùy chọn Nhóm Không Kiểm Duyệt:** Tránh tình trạng bài bị pending trong nhóm kiểm duyệt dẫn đến đánh giá điểm spam tài khoản.
- **Ưu Tiên Nhóm Đông Thành Viên:** Tự động lọc danh sách group của nick và chọn các group có lượng tương tác cao nhất để post.
- **Tự Động Đăng Page Pro5 Có Sẵn:** Tool tự động dùng hàm `BE0C6B9C()` switch sang Profile Page Pro5 để đăng, sau đó switch ngược lại Profile cá nhân an toàn.
- **Xuất Log Độc Lập Theo UID:** Tự động ghi lại nhật ký link bài đăng thành công vào `output/posts/{uid}.txt` và `logs/posts/{uid}.txt` giúp bạn dễ dàng thống kê, xuất báo cáo cho khách hàng hoặc đối soát link.

### 4.2. Hệ Thống Cấu Hình Prompt AI Đa Tầng
Nằm tại **Cấu hình > Cấu hình AI** (`fCauHinhAI`), sở hữu công nghệ AI Router thông minh nhất:
- **Smart Auto-Fallback:**
  - Khởi tạo với mô hình thế hệ mới: `gemini-flash-lite-latest` hoặc `gemini-3.5-flash-lite`.
  - Nếu gặp thời điểm cao điểm (503 High Demand) hoặc lỗi mô hình, hệ sinh thái tự động trượt sang các model tiếp theo: `gemini-3.5-flash` $\rightarrow$ `gemini-3.8-flash` $\rightarrow$ `OpenAI gpt-4o-mini`.
- **Auto-Detect API Key Thông Minh:**
  - Nếu bạn dán Key OpenAI (bắt đầu bằng `sk-...`) nhưng quên chưa đổi dropdown từ Gemini sang ChatGPT, hệ sinh thái tự động nhận diện và chuyển hướng đúng cổng API.
  - Ngược lại với Key Google Gemini (`AIza...`), hệ thống cũng tự động bảo vệ để không bao giờ bị lỗi kết nối.
- **Làm Sạch Markdown Code Fences:** Mọi câu trả lời của AI tự động được bóc tách thẻ code ` ``` ` hoặc ` ```json `, đảm bảo bài viết và bình luận luôn xuất hiện tự nhiên như người gõ.

### 4.3. Quản Trị Dữ Liệu & Menu Cập Nhật Nhanh UID
- Nhấp chuột phải vào tài khoản bất kỳ $\rightarrow$ **Cập nhật dữ liệu** $\rightarrow$ **Cập nhật UID**.
- Form cập nhật dữ liệu (`fUpdateData`) cho phép dán danh sách UID hàng loạt, tự động map theo thứ tự các dòng đang chọn hoặc cập nhật đồng loạt chỉ với 1 cú click.

---

## 5. CHIẾN LƯỢC QUẢN TRỊ PROXY & NETWORK AN TOÀN

| Tiêu chí | Proxy Dân Cư Xoay (Rotating Residential) | Proxy Tĩnh (Static IPv4/IPv6) | Dcom 4G / Hilink Xoay |
|---|---|---|---|
| **Độ Trust với Facebook** | Rất cao (IP hộ gia đình) | Trung bình - Cao | Tuyệt đối an toàn (IP trạm phát sóng di động) |
| **Tỷ lệ acc/IP an toàn** | 1 IP / 1 acc tại 1 thời điểm | 2 - 3 acc / 1 IP tĩnh | Đổi IP sau mỗi lượt chạy luồng (Batch) |
| **Phù hợp giai đoạn** | Giai đoạn 1 & Nuôi nick nhạy cảm | Giai đoạn 3 & 4 (Đăng bài, Seeding) | Toàn diện mọi giai đoạn |
| **Tích hợp LushCare** | TMProxy, Tinsoft, ShopLike, MinProxy | Nhập dạng `IP:Port` hoặc `IP:Port:User:Pass` | Đổi IP qua API Hilink hoặc Tool đổi IP Dcom |

*Lời khuyên từ Architect:* Nếu tài khoản vừa mới mua về, hãy chạy qua Proxy tĩnh hoặc Dcom 4G trong 3 ngày đầu để cố định vị trí địa lý (Geo-location), tránh Facebook nghi ngờ hành vi thay đổi vị trí liên tục.

---

## 6. SOP XỬ LÝ SỰ CỐ & GIẢI CỨU CHECKPOINT

1. **Gặp Checkpoint 282 (Bắt xác minh hình ảnh khuôn mặt):**
   - Không xác minh ngay trên mạng bẩn. Đưa nick về trạng thái tĩnh 24h.
   - Sử dụng ảnh selfie rõ mặt bằng camera trước (đã lưu sẵn trong thư mục avatar của nick).
2. **Gặp Checkpoint 956 (Khóa dạng Két sắt):**
   - Kiểm tra mã xác thực qua Hotmail tự động bằng tính năng **"Cấu hình Hotmail"** (`fCauHinhHotmail`) có hỗ trợ IMAP / OAuth.
   - Nếu nick bị checkpoint bắt xác nhận bạn bè: Sử dụng tính năng **Backup Bạn Bè** (`fCauHinhBackupGroup`) đã lưu trước đó để giải mã chuẩn xác 100%.
3. **Mất Cookie hoặc Bị Đăng Xuất (Session Expired):**
   - Tuyệt đối không đăng nhập thủ công dồn dập.
   - Dùng tính năng **"Đăng nhập lại"** với cơ chế xác thực 2FA (mã 32 ký tự) tích hợp sẵn trong tool.

---

## 7. CHECKLIST VẬN HÀNH HÀNG NGÀY CHO DÀN TÀI KHOẢN

- [ ] **Đầu ngày (08:00 - 09:30):** Chạy kịch bản *Morning Warm-up* (Đọc thông báo, lướt Newsfeed 60s, xem 1-2 Reels).
- [ ] **Giữa ngày (11:30 - 13:30):** Chạy kịch bản *Đăng bài V2* (Post bài viết mới lên tường hoặc nhóm không duyệt), tương tác chéo bài viết.
- [ ] **Chiều tối (19:30 - 22:00):** Chạy kịch bản *Seeding AI & Tương tác Bạn bè* (Comment bài viết chỉ định theo Prompt AI, kết bạn theo gợi ý).
- [ ] **Cuối tuần:** Chạy công cụ *Giải phóng dung lượng Profile* và sao lưu cơ sở dữ liệu (`db_lushcare.sqlite`).

---
*(Tài liệu thuộc bộ giải pháp LushCare Global — Tối ưu hóa hiệu năng & tự động hóa bền vững)*