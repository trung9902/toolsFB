# LushCare v26.01 Pro

> **LushCare** là phần mềm quản lý, nuôi và tự động hóa tương tác tài khoản Facebook đa luồng trên nền tảng Windows Forms (.NET Framework 4.8).

---

## 🌟 Tính Năng Nổi Bật

- **Quản lý tài khoản chuyên sâu**:
  - Hỗ trợ lưu trữ, phân loại theo thư mục danh mục tài khoản.
  - Quản lý đầy đủ thông tin: UID, Password, 2FA, Cookie, Token, Email/Passmail, Proxy, Useragent.
  - Tự động tạo cấu trúc dữ liệu SQLite sạch sẽ ngay lần đầu khởi chạy.

- **Tự động hóa trình duyệt Chrome (Selenium & Native DOM)**:
  - Tự động hóa đăng nhập Facebook (hỗ trợ nhập mật khẩu an toàn, tự động sinh mã 2FA, giải captcha checkpoint).
  - Hệ thống profile độc lập cho từng tài khoản, chống checkpoint chồng chéo.
  - Khả năng khôi phục tab, quản lý cửa sổ trình duyệt và điều khiển đa luồng linh hoạt.

- **Kịch bản tương tác phong phú**:
  - Tương tác Newsfeed, bài viết bạn bè, nhóm, fanpage.
  - Xem Video / Watch, Story, Reel ngẫu nhiên hoặc theo chỉ định.
  - Kết bạn gợi ý, theo tệp UID, kết bạn với bạn bè của UID, thành viên nhóm.
  - Đăng bài lên tường, đăng reel, đăng story kèm nội dung spin hoặc AI prompt.
  - Đổi mật khẩu, bật/tắt 2FA, đổi tên, cập nhật thông tin cá nhân.

- **Tích hợp Proxy đa dạng**:
  - Hỗ trợ HTTP Proxy, SOCKS5, MinProxy VN, ShopLike, OBC Proxy, XProxy (xoay IP tự động theo luồng).

- **Tích hợp Trí tuệ Nhân tạo (AI Prompt Engine)**:
  - Hỗ trợ tạo nội dung bình luận, nhắn tin phản hồi, caption bài viết tự động theo chủ đề.

---

## 🛠 Cấu Trúc Dự Án (Source Code)

Dự án được tác giả tối ưu hóa chỉ bao gồm mã nguồn sạch (Pure Source Code), không chứa tài khoản cá nhân, cơ sở dữ liệu rác, cache trình duyệt hay file thực thi tạm thời:

```
├── LushCare.sln                    # Solution file cho Visual Studio 2022/2019
├── LushCare_v25.05.08.csproj       # SDK-style project file (.NET Framework 4.8)
├── Program.cs                      # Entry point của phần mềm
├── SetupFolder.cs                  # Khởi tạo thư mục và SQLite schema tự động
├── Chrome.cs                       # Engine điều khiển Chrome & Selenium
├── FacebookLoginAutofill.cs        # Module đăng nhập Facebook & 2FA tự động
├── fMain.cs                        # Giao diện điều khiển trung tâm
├── LibsStubs.cs                    # Các lớp hỗ trợ mở rộng & stubs thư viện
├── icons/                          # Bộ icon và thương hiệu phần mềm
├── Properties/                     # Thông tin Assembly và Settings ứng dụng
└── ... (Các Form chức năng & User Control giao diện)
```

---

## 🚀 Hướng Dẫn Cài Đặt & Biên Dịch

### Yêu Cầu Môi Trường
- Hệ điều hành: Windows 10 / Windows 11 (64-bit khuyến nghị).
- Công cụ phát triển: **Visual Studio 2022** (hoặc Visual Studio 2019) đã cài đặt workload **.NET desktop development** (bao gồm .NET Framework 4.8 Targeting Pack).
- Hoặc sử dụng **.NET CLI**: `dotnet build`

### Các Bước Thực Hiện

1. **Clone repository về máy**:
   ```bash
   git clone https://github.com/vanducdev/LushCare.git
   cd LushCare
   ```

2. **Mở dự án**:
   - Mở file `LushCare.sln` bằng Visual Studio.
   - Nhấn **Restore NuGet Packages** để tự động tải các gói phụ thuộc (`Selenium.WebDriver`, `Leaf.xNet`, `MailKit`, `Newtonsoft.Json`, `System.Data.SQLite`, `Bunifu.UI.WinForms`).

3. **Build phần mềm**:
   - Chọn cấu hình `Release` hoặc `Debug` (x64 / Any CPU).
   - Chọn **Build Solution** (`Ctrl + Shift + B`).

4. **Khởi chạy & Sử dụng**:
   - Khi chạy lần đầu tiên, phần mềm sẽ tự động tạo cấu trúc thư mục làm việc và cơ sở dữ liệu SQLite trống trong thư mục chạy của bạn.
   - Bạn có thể tải hoặc cập nhật `chromedriver.exe` tương thích với phiên bản Google Chrome của máy thông qua nút **Update ChromeDriver** trong Cấu hình chung.

---

## ⚖️ Tuyên Bố Miễn Trừ Trách Nhiệm (Disclaimer)

Dự án này được chia sẻ với mục đích học tập, nghiên cứu kỹ thuật lập trình tự động hóa trình duyệt và quản lý dữ liệu trên nền tảng .NET. Người sử dụng có trách nhiệm tuân thủ các điều khoản dịch vụ của bên thứ ba khi sử dụng phần mềm.
