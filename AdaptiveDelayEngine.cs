using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

/// <summary>
/// Mức độ tác động / tính nhạy cảm của hành vi tự động hóa đối với thuật toán phát hiện bot của Meta
/// </summary>
public enum ActionIntensity
{
    /// <summary>
    /// Hành động nhẹ: Like, React, xem bài viết, cuộn trang, di chuột
    /// </summary>
    Light,

    /// <summary>
    /// Hành động trung bình: Bình luận (Comment), Chia sẻ (Share), Gửi tin nhắn (Message), Mời thích trang
    /// </summary>
    Medium,

    /// <summary>
    /// Hành động nặng: Đăng bài (Post), Đăng Reels, Tham gia nhóm (GroupJoin), Đổi mật khẩu (ChangePass), Đăng Story
    /// </summary>
    Heavy
}

/// <summary>
/// AdaptiveDelayEngine: Động cơ tạo trễ thích ứng, mô phỏng sinh trắc học và nhịp điệu người dùng thật.
/// - Áp dụng phân phối xác suất ngẫu nhiên Gaussian (Box-Muller) và Log-Normal (mô phỏng nhịp sinh học tự nhiên).
/// - Triệt tiêu hoàn toàn chu kỳ trễ cố định (rhythm / periodic detection) của Meta Anti-Bot & AI Shield.
/// - Tự động ghi nhận nhịp độ (RegisterAction) và áp dụng cơ chế mỏi (human fatigue & burst throttling).
/// - Cung cấp HumanTypingDelay tính toán gõ phím ngẫu nhiên (30-150ms/phím) kết hợp micro-pause giữa các từ.
/// - Cung cấp MicroPause (300-1200ms) ngẫu nhiên giữa các thao tác chuột.
/// - Hỗ trợ hủy khẩn cấp (Responsive Sleep) phản hồi tức thì khi người dùng bấm Dừng (Base.smethod_5 / Chrome closed).
/// </summary>
public static class AdaptiveDelayEngine
{
    // Thread-safe Random độc lập cho mỗi thread thực thi
    private static readonly ThreadLocal<Random> _threadRandom = new ThreadLocal<Random>(() =>
        new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId + Guid.NewGuid().GetHashCode())));

    // Bộ theo dõi lịch sử hoạt động và cơ chế mỏi cho từng tài khoản (UID)
    private static readonly ConcurrentDictionary<string, AccountActivityProfile> _trackers =
        new ConcurrentDictionary<string, AccountActivityProfile>(StringComparer.OrdinalIgnoreCase);

    #region 1. Phân phối Toán học Gaussian & Log-Normal

    /// <summary>
    /// Sinh số ngẫu nhiên theo phân phối Gaussian (Chuẩn) sử dụng thuật toán Box-Muller Transform
    /// </summary>
    /// <param name="mean">Giá trị trung bình kì vọng (Mean / Mu)</param>
    /// <param name="stdDev">Độ lệch chuẩn (Standard Deviation / Sigma)</param>
    public static double NextGaussian(double mean = 0.0, double stdDev = 1.0)
    {
        var rnd = _threadRandom.Value;
        double u1 = 1.0 - rnd.NextDouble();
        double u2 = 1.0 - rnd.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        return mean + stdDev * randStdNormal;
    }

    /// <summary>
    /// Sinh số ngẫu nhiên theo phân phối Log-Normal.
    /// Đây là mô hình chuẩn mực trong nghiên cứu tương tác người-máy (HCI),
    /// đảm bảo độ trễ luôn dương và có đuôi dài bên phải (right-skewed tail) mô phỏng những lúc người dùng lướt đọc hoặc mất tập trung.
    /// </summary>
    /// <param name="medianMs">Giá trị trung vị (Median mong muốn tính bằng milliseconds)</param>
    /// <param name="shapeSigma">Độ phân tán / jitter (thường 0.25 - 0.45)</param>
    public static double NextLogNormal(double medianMs, double shapeSigma = 0.35)
    {
        if (medianMs <= 0) medianMs = 100;
        var rnd = _threadRandom.Value;
        double u1 = 1.0 - rnd.NextDouble();
        double u2 = 1.0 - rnd.NextDouble();
        double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        double mu = Math.Log(medianMs);
        return Math.Exp(mu + shapeSigma * z);
    }

    #endregion

    #region 2. Theo dõi Nhịp độ & Cơ chế Mỏi (Fatigue & Burst Throttling)

    /// <summary>
    /// Hồ sơ ghi nhận nhịp độ hoạt động của một UID
    /// </summary>
    private class AccountActivityProfile
    {
        private readonly object _lock = new object();
        private readonly List<Tuple<DateTime, ActionIntensity>> _history = new List<Tuple<DateTime, ActionIntensity>>();

        public void Record(ActionIntensity intensity)
        {
            lock (_lock)
            {
                DateTime now = DateTime.UtcNow;
                _history.Add(Tuple.Create(now, intensity));
                Prune(now);
            }
        }

        private void Prune(DateTime now)
        {
            DateTime cutoff = now.AddMinutes(-12);
            _history.RemoveAll(x => x.Item1 < cutoff);
        }

        public double GetFatigueScale()
        {
            lock (_lock)
            {
                DateTime now = DateTime.UtcNow;
                Prune(now);

                if (_history.Count <= 1)
                    return 1.0;

                int score = 0;
                int recent3MinActions = 0;
                DateTime recent3Min = now.AddMinutes(-3);

                foreach (var item in _history)
                {
                    switch (item.Item2)
                    {
                        case ActionIntensity.Light: score += 1; break;
                        case ActionIntensity.Medium: score += 3; break;
                        case ActionIntensity.Heavy: score += 6; break;
                    }

                    if (item.Item1 >= recent3Min)
                    {
                        recent3MinActions++;
                    }
                }

                double scale = 1.0;

                // 1. Scale mỏi theo tổng điểm tải trong 12 phút qua
                if (score > 12)
                {
                    scale += (score - 12) * 0.04;
                }

                // 2. Chống bùng phát dồn dập (Burst Throttling): nếu trong 3 phút làm liên tục >= 5 hành động
                if (recent3MinActions >= 5)
                {
                    scale += (recent3MinActions - 4) * 0.15;
                }

                // Kẹp tỷ lệ điều chỉnh an toàn từ 1.0x đến tối đa 3.0x
                return Math.Min(3.0, Math.Max(1.0, scale));
            }
        }
    }

    /// <summary>
    /// Ghi nhận nhịp độ của từng nick; nếu nick thực hiện nhiều hành động liên tiếp trong thời gian ngắn,
    /// tự động scale up thời gian nghỉ để tránh rate-limit của Meta.
    /// </summary>
    public static void RegisterAction(string uid, ActionIntensity intensity)
    {
        if (string.IsNullOrWhiteSpace(uid)) return;
        var profile = _trackers.GetOrAdd(uid, _ => new AccountActivityProfile());
        profile.Record(intensity);
    }

    /// <summary>
    /// Lấy hệ số co giãn trễ mỏi hiện tại của UID (1.0 = bình thường, > 1.0 = cần nghỉ dài hơn)
    /// </summary>
    public static double GetFatigueMultiplier(string uid)
    {
        if (string.IsNullOrWhiteSpace(uid)) return 1.0;
        if (_trackers.TryGetValue(uid, out var profile))
        {
            return profile.GetFatigueScale();
        }
        return 1.0;
    }

    /// <summary>
    /// Xóa bộ nhớ nhịp độ của UID (khi chuyển phiên hoặc đăng nhập lại)
    /// </summary>
    public static void ResetTracker(string uid)
    {
        if (string.IsNullOrWhiteSpace(uid)) return;
        _trackers.TryRemove(uid, out _);
    }

    /// <summary>
    /// Tính toán hệ số sinh học theo chu kỳ ngày đêm (Circadian Rhythm):
    /// Con người phản ứng chậm hơn một chút vào đêm khuya hoặc đầu giờ chiều.
    /// </summary>
    private static double GetCircadianPaceFactor()
    {
        int hour = DateTime.Now.Hour;
        if (hour >= 23 || hour < 5) return 1.18; // Khuya / sáng sớm
        if (hour >= 13 && hour <= 14) return 1.08; // Đầu giờ chiều
        return 1.0; // Giờ hoạt động chuẩn
    }

    private static string TryGetUid(Chrome chrome)
    {
        if (chrome == null) return null;
        try
        {
            if (!string.IsNullOrEmpty(chrome.B4208531)) return chrome.B4208531;
            string u = chrome.FB94939A();
            if (!string.IsNullOrEmpty(u)) return u;
        }
        catch { }
        return null;
    }

    #endregion

    #region 3. Các hàm Delay Thông minh

    /// <summary>
    /// Tính toán thời gian ngủ theo phân phối Gaussian / Log-Normal với độ lệch chuẩn jitter ngẫu nhiên,
    /// mô phỏng hành vi nhịp sinh học người dùng thật (human fatigue & pace variation), chống bot timing detection.
    /// </summary>
    /// <param name="intensity">Mức độ hành vi (Light, Medium, Heavy)</param>
    /// <param name="multiplier">Hệ số nhân điều chỉnh trễ tùy biến (mặc định 1.0)</param>
    /// <param name="chrome">Đối tượng Chrome (được dùng để auto-detect UID và phản hồi dừng khẩn cấp)</param>
    public static void Delay(ActionIntensity intensity, double multiplier = 1.0, Chrome chrome = null)
    {
        if (multiplier <= 0.0) multiplier = 1.0;

        // 1. Tự động kiểm tra và ghi nhận hành vi nếu trích xuất được UID
        string uid = TryGetUid(chrome);
        if (!string.IsNullOrEmpty(uid))
        {
            multiplier *= GetFatigueMultiplier(uid);
            RegisterAction(uid, intensity);
        }

        // 2. Tích hợp nhịp sinh học thực tế theo giờ địa phương
        multiplier *= GetCircadianPaceFactor();

        // 3. Phân bổ trung vị (Median) và biên giới hạn theo cấp độ
        double medianMs;
        double minClamp;
        double maxClamp;

        switch (intensity)
        {
            case ActionIntensity.Light:
                medianMs = 2200;
                minClamp = 900;
                maxClamp = 5000;
                break;
            case ActionIntensity.Medium:
                medianMs = 5200;
                minClamp = 2400;
                maxClamp = 12000;
                break;
            case ActionIntensity.Heavy:
            default:
                medianMs = 13500;
                minClamp = 6500;
                maxClamp = 32000;
                break;
        }

        // 4. Sinh ngẫu nhiên theo phân phối Log-Normal
        double calculatedMs = NextLogNormal(medianMs, 0.32);
        if (calculatedMs < minClamp) calculatedMs = minClamp + (_threadRandom.Value.NextDouble() * 250);
        if (calculatedMs > maxClamp) calculatedMs = maxClamp - (_threadRandom.Value.NextDouble() * 1000);

        // 5. Thêm vi sai ngẫu nhiên 5-12% (micro-jitter)
        double jitter = 1.0 + ((_threadRandom.Value.NextDouble() - 0.5) * 0.16);
        int finalMs = (int)Math.Round(calculatedMs * multiplier * jitter);

        ResponsiveSleep(finalMs, chrome);
    }

    /// <summary>
    /// Overload hỗ trợ chỉ định UID trực tiếp
    /// </summary>
    public static void Delay(string uid, ActionIntensity intensity, double multiplier = 1.0, Chrome chrome = null)
    {
        if (!string.IsNullOrWhiteSpace(uid))
        {
            RegisterAction(uid, intensity);
            multiplier *= GetFatigueMultiplier(uid);
        }
        Delay(intensity, multiplier, chrome);
    }

    /// <summary>
    /// Trả về delay gõ phím ngẫu nhiên (30-150ms per key) kết hợp micro-pause giữa các từ.
    /// </summary>
    /// <param name="characterCount">Số lượng ký tự văn bản cần gõ</param>
    /// <returns>Tổng số milliseconds trễ tự nhiên ước tính</returns>
    public static int HumanTypingDelay(int characterCount)
    {
        if (characterCount <= 0) return 0;
        var rnd = _threadRandom.Value;
        double totalMs = 0;

        int charsSinceLastPause = 0;
        int nextPauseInterval = rnd.Next(4, 8);

        for (int i = 0; i < characterCount; i++)
        {
            // Độ trễ nhấn từng phím: 30ms - 150ms theo phân phối chuẩn Gaussian quanh 75ms
            double keyDelay = NextGaussian(75, 22);
            if (keyDelay < 30) keyDelay = 30 + rnd.Next(0, 15);
            if (keyDelay > 150) keyDelay = 150 - rnd.Next(0, 20);
            totalMs += keyDelay;

            charsSinceLastPause++;
            if (charsSinceLastPause >= nextPauseInterval)
            {
                // Micro-pause giữa các từ hoặc cụm từ (tư duy / đảo mắt) 200ms - 600ms
                double pause = NextGaussian(360, 75);
                if (pause < 200) pause = 200 + rnd.Next(0, 50);
                if (pause > 600) pause = 600 - rnd.Next(0, 50);
                totalMs += pause;

                charsSinceLastPause = 0;
                nextPauseInterval = rnd.Next(4, 8);
            }
        }

        return (int)Math.Round(totalMs);
    }

    /// <summary>
    /// Ngủ mô phỏng thời gian gõ phím chân thực (tự động chia nhỏ vòng lặp để phản hồi nút Dừng).
    /// </summary>
    public static void SimulateTypingSleep(int characterCount, Chrome chrome = null)
    {
        int delay = HumanTypingDelay(characterCount);
        ResponsiveSleep(delay, chrome);
    }

    /// <summary>
    /// Tạm dừng 300ms - 1200ms ngẫu nhiên giữa các thao tác chuột / click, chống nhận diện bot click tốc độ máy.
    /// </summary>
    public static void MicroPause(Chrome chrome = null)
    {
        var rnd = _threadRandom.Value;
        // Phân phối Gaussian quanh 620ms, độ lệch 150ms, giới hạn 300ms - 1200ms
        double pause = NextGaussian(620, 150);
        if (pause < 300) pause = 300 + rnd.Next(0, 60);
        if (pause > 1200) pause = 1200 - rnd.Next(0, 90);

        ResponsiveSleep((int)Math.Round(pause), chrome);
    }

    /// <summary>
    /// Thay thế cho các đoạn Thread.Sleep(targetMs) cứng bằng cách áp dụng độ lệch chuẩn Gaussian Jitter quanh targetMs.
    /// </summary>
    public static void DelayMs(int targetMs, double jitterRatio = 0.22, Chrome chrome = null)
    {
        if (targetMs <= 0) return;
        if (jitterRatio <= 0) jitterRatio = 0.1;
        double stdDev = targetMs * jitterRatio;
        double delay = NextGaussian(targetMs, stdDev);
        int minLimit = Math.Max(50, (int)(targetMs * 0.55));
        int maxLimit = (int)(targetMs * 1.75);
        if (delay < minLimit) delay = minLimit + (_threadRandom.Value.NextDouble() * 50);
        if (delay > maxLimit) delay = maxLimit - (_threadRandom.Value.NextDouble() * 50);
        ResponsiveSleep((int)Math.Round(delay), chrome);
    }

    /// <summary>
    /// Tạo độ trễ ngẫu nhiên theo phân phối Gaussian giữa khoảng minSeconds và maxSeconds.
    /// Thay thế hoàn toàn cho Random.Next(min, max) dạng hình chữ nhật đồng nhất của bot cũ.
    /// </summary>
    public static void DelaySeconds(double minSeconds, double maxSeconds, Chrome chrome = null)
    {
        if (minSeconds < 0.2) minSeconds = 0.2;
        if (maxSeconds < minSeconds) maxSeconds = minSeconds;

        double median = ((minSeconds + maxSeconds) / 2.0) * 1000.0;
        double range = (maxSeconds - minSeconds) * 1000.0;
        double stdDev = range / 4.0;
        double delay = NextGaussian(median, stdDev);

        double minMs = minSeconds * 1000.0;
        double maxMs = maxSeconds * 1000.0;
        if (delay < minMs) delay = minMs + (_threadRandom.Value.NextDouble() * 150);
        if (delay > maxMs) delay = maxMs - (_threadRandom.Value.NextDouble() * 150);

        ResponsiveSleep((int)Math.Round(delay), chrome);
    }

    #endregion

    #region 4. Vòng lặp Ngủ Phản hồi Nhanh (Responsive Sleep)

    /// <summary>
    /// Vòng lặp ngủ chia nhỏ chu kỳ (50ms) để phản hồi ngay lập tức cờ hủy của người dùng hoặc sự cố đóng trình duyệt.
    /// Không bao giờ làm đơ ứng dụng hoặc luồng chạy như Thread.Sleep đơn thuần.
    /// </summary>
    public static void ResponsiveSleep(int ms, Chrome chrome = null)
    {
        if (ms <= 0) return;
        const int chunkSize = 50;
        int elapsed = 0;

        while (elapsed < ms)
        {
            // Kiểm tra trạng thái đóng trình duyệt hoặc yêu cầu dừng
            if (chrome != null)
            {
                try
                {
                    if (chrome.CD930D04() || chrome.E184CD03())
                        break;
                }
                catch { }
            }
            else
            {
                try
                {
                    if (Base.smethod_5())
                        break;
                }
                catch { }
            }

            int sleepDuration = Math.Min(chunkSize, ms - elapsed);
            Thread.Sleep(sleepDuration);
            elapsed += sleepDuration;
        }
    }

    #endregion
}
