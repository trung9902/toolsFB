using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

public enum ProxyState
{
    Live,
    Reconnecting,
    Swapped,
    Dead
}

public class ProxyHealthResult
{
    public ProxyState State { get; set; } = ProxyState.Live;
    public bool IsLive => State == ProxyState.Live;
    public long LatencyMs { get; set; } = 0;
    public string PublicIp { get; set; } = "";
    public string NewProxy { get; set; } = "";
    public string Message { get; set; } = "";

    public override string ToString()
    {
        return $"[ProxyHealth: {State}, Ping={LatencyMs}ms, IP={PublicIp}, Msg={Message}]";
    }
}

public static class ProxyCircuitBreaker
{
    // Cấu hình Circuit Breaker
    private const int DEFAULT_TIMEOUT_MS = 3000;
    private const int FAILURE_THRESHOLD = 3; // Số lần lỗi liên tiếp để ngắt mạch
    private static readonly TimeSpan RESET_TIMEOUT = TimeSpan.FromMinutes(2); // Thời gian chờ để thử lại

    // Quản lý trạng thái cho từng endpoint proxy
    private class CircuitEntry
    {
        public int ConsecutiveFailures = 0;
        public DateTime LastFailureTime = DateTime.MinValue;
        public bool IsCircuitOpen = false;
        public string LastKnownIp = "";
    }

    private static readonly ConcurrentDictionary<string, CircuitEntry> _circuitMap =
        new ConcurrentDictionary<string, CircuitEntry>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Kiểm tra kết nối nhanh của proxy, đo độ trễ mili-giây với timeout siêu nhanh (mặc định 3000ms).
    /// Sử dụng probing trực tiếp qua IP endpoints (ipify, icanhazip, ifconfig.me) với kiểm soát hủy luồng chặt chẽ.
    /// </summary>
    public static ProxyHealthResult CheckProxyHealth(string proxy, int proxyType = 0, int timeoutMs = DEFAULT_TIMEOUT_MS)
    {
        var result = new ProxyHealthResult();
        if (string.IsNullOrWhiteSpace(proxy))
        {
            // Không có proxy -> Direct connection
            result.State = ProxyState.Live;
            result.Message = "Direct Connection (No Proxy)";
            return result;
        }

        string cleanProxyKey = proxy.Trim();
        CircuitEntry entry = _circuitMap.GetOrAdd(cleanProxyKey, _ => new CircuitEntry());

        // Kiểm tra xem Circuit có đang bị Open (chặn) không
        if (entry.IsCircuitOpen)
        {
            if (DateTime.UtcNow - entry.LastFailureTime < RESET_TIMEOUT)
            {
                result.State = ProxyState.Dead;
                result.Message = $"Circuit Open (Bị khóa do liên tục lỗi {entry.ConsecutiveFailures} lần)";
                return result;
            }
            // Hết thời gian chờ -> Chuyển sang Half-Open để thử lại 1 lần
            entry.IsCircuitOpen = false;
        }

        var sw = Stopwatch.StartNew();
        try
        {
            // Sử dụng RequestXNet nhẹ hoặc WebRequest với timeoutMs
            RequestXNet req = new RequestXNet("", "", cleanProxyKey, proxyType);
            req.ConnectTimeout = timeoutMs;
            req.ReadWriteTimeout = timeoutMs;

            string[] testUrls = new string[]
            {
                "http://api64.ipify.org",
                "http://icanhazip.com",
                "http://ifconfig.me/ip"
            };

            string liveIp = "";
            foreach (string url in testUrls)
            {
                try
                {
                    string body = req.E58EB99F(url);
                    if (!string.IsNullOrEmpty(body))
                    {
                        body = body.Trim();
                        if (IPAddress.TryParse(body, out IPAddress parsed))
                        {
                            liveIp = parsed.ToString();
                            break;
                        }
                        Match m = Regex.Match(body, @"\b(?:\d{1,3}\.){3}\d{1,3}\b");
                        if (m.Success)
                        {
                            liveIp = m.Value;
                            break;
                        }
                    }
                }
                catch
                {
                    // Thử endpoint tiếp theo trong danh sách
                }
            }

            sw.Stop();
            result.LatencyMs = sw.ElapsedMilliseconds;

            if (!string.IsNullOrEmpty(liveIp))
            {
                result.State = ProxyState.Live;
                result.PublicIp = liveIp;
                result.Message = $"Live ({result.LatencyMs}ms)";

                // Reset mạch thành công
                entry.ConsecutiveFailures = 0;
                entry.IsCircuitOpen = false;
                entry.LastKnownIp = liveIp;
            }
            else
            {
                result.State = ProxyState.Dead;
                result.Message = $"Proxy không phản hồi (Timeout {timeoutMs}ms)";
                RecordFailure(cleanProxyKey, entry);
            }
        }
        catch (Exception ex)
        {
            sw.Stop();
            result.LatencyMs = sw.ElapsedMilliseconds;
            result.State = ProxyState.Dead;
            result.Message = "Lỗi kết nối: " + ex.Message;
            RecordFailure(cleanProxyKey, entry);
        }

        return result;
    }

    private static void RecordFailure(string key, CircuitEntry entry)
    {
        int f = Interlocked.Increment(ref entry.ConsecutiveFailures);
        entry.LastFailureTime = DateTime.UtcNow;
        if (f >= FAILURE_THRESHOLD)
        {
            entry.IsCircuitOpen = true;
        }
    }

    /// <summary>
    /// Kiểm tra nhanh trạng thái mạch có đang bị Dead/Hở không
    /// </summary>
    public static bool IsCircuitBreakerTripped(string proxy)
    {
        if (string.IsNullOrWhiteSpace(proxy)) return false;
        if (_circuitMap.TryGetValue(proxy.Trim(), out var entry))
        {
            if (entry.IsCircuitOpen && DateTime.UtcNow - entry.LastFailureTime < RESET_TIMEOUT)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Xóa trạng thái Circuit Breaker cho proxy khi được khôi phục hoặc cấu hình lại
    /// </summary>
    public static void ResetCircuit(string proxy)
    {
        if (string.IsNullOrWhiteSpace(proxy)) return;
        _circuitMap.TryRemove(proxy.Trim(), out _);
    }

    /// <summary>
    /// Tự động kích hoạt cơ chế đổi IP hoặc reset kết nối nếu là proxy xoay (ShopLike, TMProxy, Tinsoft, XProxy, MinProxyVN, OBC).
    /// Trả về trạng thái: Live, Reconnecting, Swapped, Dead để caller quyết định dừng hay tiếp tục.
    /// </summary>
    /// <param name="proxy">Chuỗi proxy hiện tại (IP:Port hoặc API Key)</param>
    /// <param name="proxyType">Loại proxy (0: HTTP, 1: Socks5, hoặc ID hệ thống xoay: 7=Tinsoft, 8=XProxy, 10=TMProxy, 12=ShopLike, 13=MinProxy, 14=OBC, ...)</param>
    /// <param name="apiKey">API Key đổi IP nếu có</param>
    /// <param name="rotateUrl">URL điều khiển xoay proxy nếu có (XProxy/OBC)</param>
    public static ProxyHealthResult OnProxyFailureDetected(string proxy, int proxyType, string apiKey = "", string rotateUrl = "")
    {
        var result = new ProxyHealthResult
        {
            State = ProxyState.Reconnecting,
            Message = "Bắt đầu cơ chế Failover/Xoay IP..."
        };

        try
        {
            // 1. Phân loại theo cấu hình xoay IP tự động
            // Nếu có API Key hoặc rotateUrl hoặc proxyType thuộc nhóm dynamic
            string activeKey = !string.IsNullOrEmpty(apiKey) ? apiKey : proxy;

            // XProxy hoặc proxy có rotateUrl (case 8 hoặc rotateUrl chỉ định)
            if (proxyType == 8 || !string.IsNullOrEmpty(rotateUrl))
            {
                string sUrl = rotateUrl;
                if (string.IsNullOrEmpty(sUrl))
                {
                    sUrl = C5034B95.smethod_0("configGeneral").BDB80B23("txtServiceURLXProxy");
                }

                if (!string.IsNullOrEmpty(sUrl))
                {
                    result.Message = "Gửi lệnh Reset modem/proxy tới XProxy Gateway...";
                    XProxyproxy xProxy = new XProxyproxy(sUrl, proxy, 0, 1);
                    int resetRes = xProxy.method_1();
                    if (resetRes == 1)
                    {
                        // Chờ proxy phục hồi
                        Thread.Sleep(2000);
                        var checkLive = CheckProxyHealth(proxy, 0, 4000);
                        if (checkLive.IsLive)
                        {
                            result.State = ProxyState.Swapped;
                            result.PublicIp = checkLive.PublicIp;
                            result.LatencyMs = checkLive.LatencyMs;
                            result.NewProxy = proxy;
                            result.Message = "Reset XProxy thành công. IP mới: " + checkLive.PublicIp;
                            ResetCircuit(proxy);
                            return result;
                        }
                    }
                }
            }

            // Nhóm xoay qua ShopLike / TMProxy / Tinsoft / NetProxy / WWProxy (Case 7, 10, 12, 15, 16, 17, 18, 19, 20, 21, 22)
            if (proxyType == 7 || proxyType == 10 || proxyType == 12 || proxyType >= 15)
            {
                result.Message = "Gửi yêu cầu xoay IP qua API Provider...";
                ShopLike rotator = new ShopLike(activeKey, 1);
                // Gán loại cấu hình nếu chưa có
                if (string.IsNullOrEmpty(rotator.String_1) || rotator.String_1 == "0")
                {
                    rotator.String_1 = proxyType.ToString();
                }

                bool rotated = rotator.E1365814();
                if (rotated && !string.IsNullOrEmpty(rotator.A40F8204))
                {
                    string newProxy = rotator.A40F8204;
                    // Kiểm tra độ sống của proxy mới nhận
                    var checkNew = CheckProxyHealth(newProxy, 0, 4000);
                    result.State = ProxyState.Swapped;
                    result.NewProxy = newProxy;
                    result.PublicIp = checkNew.PublicIp;
                    result.LatencyMs = checkNew.LatencyMs;
                    result.Message = "Xoay IP API thành công: " + newProxy;
                    ResetCircuit(newProxy);
                    return result;
                }
            }

            // MinProxy (Case 13)
            if (proxyType == 13)
            {
                result.Message = "Lấy IP mới từ MinProxy...";
                MinProxyVN minProxy = new MinProxyVN(0, activeKey, 0, 1);
                int code = minProxy.B9903930();
                if (code == 1 && !string.IsNullOrEmpty(minProxy.CB10C9AD))
                {
                    string newProxy = minProxy.CB10C9AD;
                    var checkNew = CheckProxyHealth(newProxy, 0, 4000);
                    result.State = ProxyState.Swapped;
                    result.NewProxy = newProxy;
                    result.PublicIp = checkNew.PublicIp;
                    result.LatencyMs = checkNew.LatencyMs;
                    result.Message = "Xoay IP MinProxy thành công: " + newProxy;
                    ResetCircuit(newProxy);
                    return result;
                }
            }

            // Đối với Proxy tĩnh (Static/Private Proxy: IP:Port hoặc IP:Port:User:Pass)
            // Thử kiểm tra lại 1 lần với timeout mở rộng (5s) đề phòng mạng chập chờn
            result.Message = "Proxy tĩnh: Kiểm tra lại kết nối lần cuối...";
            var retryCheck = CheckProxyHealth(proxy, proxyType, 5000);
            if (retryCheck.IsLive)
            {
                result.State = ProxyState.Live;
                result.PublicIp = retryCheck.PublicIp;
                result.LatencyMs = retryCheck.LatencyMs;
                result.Message = "Proxy đã phục hồi kết nối: " + retryCheck.PublicIp;
                ResetCircuit(proxy);
                return result;
            }

            // Nếu tất cả phương án đều thất bại -> Trả về Dead
            result.State = ProxyState.Dead;
            result.Message = "Proxy đã chết và không thể tự động khôi phục / xoay IP.";
        }
        catch (Exception ex)
        {
            result.State = ProxyState.Dead;
            result.Message = "Lỗi trong quá trình Failover/Xoay IP: " + ex.Message;
        }

        return result;
    }
}
