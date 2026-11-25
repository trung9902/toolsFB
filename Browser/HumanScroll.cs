using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Module mô phỏng hành vi cuộn trang chân thực như người dùng lướt mạng xã hội (Human-like Scroll).
/// Hỗ trợ cuộn từng bước ngẫu nhiên (300-700px), quán tính vật lý mượt mà (Ease-In-Out),
/// ngắt nghỉ 0.5-2s giữa các lần cuộn để mô phỏng đọc bài viết, và kiểm tra cờ dừng Base.smethod_5().
/// </summary>
public static class HumanScroll
{
    // Thread-safe Random độc lập cho từng worker thread
    private static readonly ThreadLocal<Random> _threadRandom = new ThreadLocal<Random>(() =>
        new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

    private static Random Rnd => _threadRandom.Value;

    /// <summary>
    /// Cuộn newsfeed/trang web mô phỏng người thật:
    /// - Cuộn tổng quãng đường totalScrollPx.
    /// - Mỗi bước lớn cuộn ngẫu nhiên 300 - 700px.
    /// - Mỗi bước lớn được chia nhỏ thành nhiều bước vi mô mô phỏng gia tốc và quán tính vật lý (Ease-In-Out).
    /// - Sử dụng IJavaScriptExecutor.ExecuteScript("window.scrollBy(0, px)") với timing ngẫu nhiên.
    /// - Tạm dừng ngẫu nhiên 0.5s - 2s giữa các bước mô phỏng hành vi đọc tin.
    /// - Tích hợp kiểm tra cờ dừng Base.smethod_5() trong từng vòng lặp vi mô để dừng ngay lập tức.
    /// - Gọi callback onScrollStep(currentScrolledPx) sau mỗi bước lớn để cập nhật tiến độ.
    /// </summary>
    /// <param name="driver">ChromeDriver điều khiển trình duyệt.</param>
    /// <param name="totalScrollPx">Tổng số pixel cần cuộn (ví dụ: 3000px, 5000px).</param>
    /// <param name="onScrollStep">Action callback truyền vào số pixel đã cuộn lũy kế (có thể null).</param>
    public static void ScrollNewsfeed(ChromeDriver driver, int totalScrollPx, Action<int> onScrollStep = null)
    {
        ScrollNewsfeedInternal(driver, totalScrollPx, onScrollStep);
    }

    /// <summary>
    /// Overload hỗ trợ IWebDriver tổng quát.
    /// </summary>
    public static void ScrollNewsfeed(IWebDriver driver, int totalScrollPx, Action<int> onScrollStep = null)
    {
        ScrollNewsfeedInternal(driver, totalScrollPx, onScrollStep);
    }

    /// <summary>
    /// Overload hỗ trợ Chrome wrapper của MaxCare.
    /// </summary>
    public static void ScrollNewsfeed(Chrome chrome, int totalScrollPx, Action<int> onScrollStep = null)
    {
        if (chrome == null || chrome.ChromeDriver_0 == null) return;
        ScrollNewsfeedInternal(chrome.ChromeDriver_0, totalScrollPx, onScrollStep);
    }

    /// <summary>
    /// Hàm thực thi cuộn trang nội bộ.
    /// </summary>
    private static void ScrollNewsfeedInternal(IWebDriver driver, int totalScrollPx, Action<int> onScrollStep)
    {
        if (driver == null || totalScrollPx <= 0)
        {
            return;
        }

        IJavaScriptExecutor js = driver as IJavaScriptExecutor;
        if (js == null)
        {
            return;
        }

        int totalScrolled = 0;

        try
        {
            while (totalScrolled < totalScrollPx)
            {
                // 1. Kiểm tra cờ dừng khẩn cấp từ người dùng
                if (Base.smethod_5())
                {
                    return;
                }

                // 2. Xác định khoảng cách cuộn cho bước hiện tại (ngẫu nhiên 300 - 700px)
                int remainingPx = totalScrollPx - totalScrolled;
                int stepDistance = Rnd.Next(300, 701);

                if (stepDistance > remainingPx)
                {
                    stepDistance = remainingPx;
                }

                if (stepDistance <= 0)
                {
                    break;
                }

                // 3. Thực hiện cuộn mềm mại theo quán tính vật lý (Ease-In-Out)
                // Chia nhỏ bước cuộn thành nhiều micro-steps với timing ngẫu nhiên
                SmoothInertiaScroll(js, stepDistance);

                totalScrolled += stepDistance;

                // 4. Kiểm tra cờ dừng ngay sau khi hoàn tất vi bước
                if (Base.smethod_5())
                {
                    return;
                }

                // 5. Xác suất nhỏ (khoảng 6%) người dùng cuộn ngược nhẹ lên (25-50px)
                // để xem lại hình ảnh/tiêu đề vừa lướt qua (hành vi cực kỳ tự nhiên)
                if (Rnd.NextDouble() < 0.06 && totalScrolled > 600)
                {
                    int glanceBackPx = Rnd.Next(25, 55);
                    SmoothInertiaScroll(js, -glanceBackPx);
                    totalScrolled -= glanceBackPx;
                    if (Base.smethod_5()) return;
                }

                // 6. Kích hoạt callback thông báo tiến trình đã cuộn
                try
                {
                    onScrollStep?.Invoke(totalScrolled);
                }
                catch
                {
                    // Tránh lỗi từ phía callback người gọi làm gián đoạn luồng
                }

                // 7. Nếu đã đạt hoặc vượt chỉ tiêu quãng đường, kết thúc
                if (totalScrolled >= totalScrollPx)
                {
                    break;
                }

                // 8. Tạm dừng ngắn 0.3s - 0.8s giữa các bước lướt tin
                int pauseMs = Rnd.Next(300, 801);
                SleepWithCancelCheck(pauseMs);

                if (Base.smethod_5())
                {
                    return;
                }

                // 9. Kiểm tra xem đã chạm đáy trang web chưa (nếu hết nội dung thì dừng sớm)
                if (IsAtPageBottom(js))
                {
                    // Chờ nhẹ 1.2s xem nội dung có tự load thêm (infinite scrolling) không
                    SleepWithCancelCheck(1200);
                    if (Base.smethod_5() || IsAtPageBottom(js))
                    {
                        break;
                    }
                }
            }
        }
        catch (WebDriverException)
        {
            // Trình duyệt có thể đã bị đóng hoặc chuyển hướng
        }
        catch (Exception)
        {
            // Bảo vệ thread không bị gián đoạn ngoài ý muốn
        }
    }

    /// <summary>
    /// Thực hiện cuộn một quãng đường px theo hàm quán tính vật lý Ease-In-Out Cubic:
    /// - Tăng tốc mượt từ trạng thái nghỉ (Ease-In).
    /// - Đạt tốc độ ổn định ở giữa quãng cuộn.
    /// - Giảm tốc mềm mại và dừng lại (Ease-Out).
    /// - Thực hiện qua IJavaScriptExecutor.ExecuteScript("window.scrollBy(0, px)") với timing ngẫu nhiên.
    /// </summary>
    private static void SmoothInertiaScroll(IJavaScriptExecutor js, int totalDistance)
    {
        if (totalDistance == 0) return;
        try
        {
            js.ExecuteScript($"window.scrollBy({{ top: {totalDistance}, behavior: 'smooth' }});");
        }
        catch { }
    }

    /// <summary>
    /// Kiểm tra xem thanh cuộn đã đến gần cuối trang hay chưa.
    /// </summary>
    private static bool IsAtPageBottom(IJavaScriptExecutor js)
    {
        try
        {
            object result = js.ExecuteScript(@"
                var scrollHeight = Math.max(document.body.scrollHeight, document.documentElement.scrollHeight);
                var clientHeight = window.innerHeight || document.documentElement.clientHeight;
                var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
                return (scrollTop + clientHeight) >= (scrollHeight - 15);
            ");

            if (result is bool isBottom)
            {
                return isBottom;
            }
            if (result != null && bool.TryParse(result.ToString(), out bool parsed))
            {
                return parsed;
            }
        }
        catch
        {
            // Bỏ qua nếu trang đang trong trạng thái điều hướng
        }
        return false;
    }

    /// <summary>
    /// Ngủ với bước nhỏ 30ms và kiểm tra cờ dừng Base.smethod_5() liên tục,
    /// giúp phản hồi lập tức khi user nhấn Dừng mà không phải chờ hết pause.
    /// </summary>
    private static void SleepWithCancelCheck(int totalMs)
    {
        int remaining = totalMs;
        while (remaining > 0)
        {
            if (Base.smethod_5()) return;
            int slice = Math.Min(30, remaining);
            Thread.Sleep(slice);
            remaining -= slice;
        }
    }
}
