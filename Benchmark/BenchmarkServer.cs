using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LushCare.Benchmark
{
    /// <summary>
    /// Máy chủ HTTP nội bộ độc lập phục vụ trang đo kiểm chuẩn fixture.html và 10 ảnh mock.
    /// Quy chuẩn tải: HTML text = 1.5 MB, 10 ảnh mock = 500 KB (50 KB/ảnh). Tổng tải 2.0 MB.
    /// </summary>
    public class BenchmarkServer : IDisposable
    {
        private static readonly Lazy<BenchmarkServer> _instance =
            new Lazy<BenchmarkServer>(() => new BenchmarkServer());
        public static BenchmarkServer Instance => _instance.Value;

        private readonly HttpListener _listener;
        private readonly string _fixtureHtmlPath;
        private readonly byte[] _mockImageBytes;
        private CancellationTokenSource _cts;
        private bool _isRunning;

        public int Port { get; }
        public string BaseUrl => $"http://127.0.0.1:{Port}/";
        public string FixtureUrl => $"http://127.0.0.1:{Port}/fixture.html";

        public BenchmarkServer(int port = 18080, string fixtureHtmlPath = null)
        {
            Port = port;
            _fixtureHtmlPath = fixtureHtmlPath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Benchmark", "fixture.html");
            if (!File.Exists(_fixtureHtmlPath))
            {
                // Dự phòng đường dẫn tương đối trong môi trường phát triển / kiểm thử
                string altPath = Path.Combine(Directory.GetCurrentDirectory(), "Benchmark", "fixture.html");
                if (File.Exists(altPath))
                {
                    _fixtureHtmlPath = altPath;
                }
                else
                {
                    string altPath2 = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Benchmark", "fixture.html"));
                    if (File.Exists(altPath2))
                    {
                        _fixtureHtmlPath = altPath2;
                    }
                }
            }

            // Tạo sẵn payload binary ảnh mock 50 KB (51,200 bytes) theo định dạng JPEG chuẩn
            _mockImageBytes = GenerateMockJpeg(51200);

            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://127.0.0.1:{Port}/");
            _listener.Prefixes.Add($"http://localhost:{Port}/");
        }

        public void Start()
        {
            if (_isRunning) return;

            _cts = new CancellationTokenSource();
            _listener.Start();
            _isRunning = true;

            Task.Run(async () =>
            {
                while (_isRunning && !_cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var context = await _listener.GetContextAsync().ConfigureAwait(false);
                        _ = Task.Run(() => ProcessRequest(context), _cts.Token);
                    }
                    catch (HttpListenerException)
                    {
                        break;
                    }
                    catch (ObjectDisposedException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[BenchmarkServer] Request Error: {ex.Message}");
                    }
                }
            }, _cts.Token);

            Console.WriteLine($"[BenchmarkServer] Started listening at {BaseUrl}");
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            try
            {
                string rawPath = request.Url.AbsolutePath.ToLowerInvariant();

                if (rawPath == "/" || rawPath == "/fixture.html")
                {
                    byte[] buffer;
                    if (File.Exists(_fixtureHtmlPath))
                    {
                        buffer = File.ReadAllBytes(_fixtureHtmlPath);
                    }
                    else
                    {
                        string fallbackHtml = "<!DOCTYPE html><html><body><h1>Benchmark Fixture Missing</h1><div id='benchmark-ready' data-status='ready'></div></body></html>";
                        buffer = Encoding.UTF8.GetBytes(fallbackHtml);
                    }

                    response.ContentType = "text/html; charset=utf-8";
                    response.ContentLength64 = buffer.Length;
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
                else if (rawPath.StartsWith("/images/") && rawPath.EndsWith(".jpg"))
                {
                    response.ContentType = "image/jpeg";
                    response.ContentLength64 = _mockImageBytes.Length;
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.OutputStream.Write(_mockImageBytes, 0, _mockImageBytes.Length);
                }
                else if (rawPath == "/health" || rawPath == "/ping")
                {
                    byte[] ok = Encoding.UTF8.GetBytes("OK");
                    response.ContentType = "text/plain";
                    response.ContentLength64 = ok.Length;
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.OutputStream.Write(ok, 0, ok.Length);
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            catch
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            finally
            {
                try
                {
                    response.OutputStream.Close();
                }
                catch { }
            }
        }

        private static byte[] GenerateMockJpeg(int sizeInBytes)
        {
            byte[] bytes = new byte[sizeInBytes];
            // JPEG SOI (Start of Image)
            bytes[0] = 0xFF;
            bytes[1] = 0xD8;
            // APP0 marker
            bytes[2] = 0xFF;
            bytes[3] = 0xE0;
            bytes[4] = 0x00;
            bytes[5] = 0x10;
            // JFIF signature
            bytes[6] = 0x4A; // J
            bytes[7] = 0x46; // F
            bytes[8] = 0x49; // I
            bytes[9] = 0x46; // F
            bytes[10] = 0x00;
            bytes[11] = 0x01; // v1.1
            bytes[12] = 0x01;
            bytes[13] = 0x00;
            bytes[14] = 0x00;
            bytes[15] = 0x01;
            bytes[16] = 0x00;
            bytes[17] = 0x01;

            // Fill middle with predictable mock byte patterns
            for (int i = 18; i < sizeInBytes - 2; i++)
            {
                bytes[i] = (byte)((i * 37) % 251);
            }

            // JPEG EOI (End of Image)
            bytes[sizeInBytes - 2] = 0xFF;
            bytes[sizeInBytes - 1] = 0xD9;
            return bytes;
        }

        public void Stop()
        {
            if (!_isRunning) return;
            _isRunning = false;
            try { _cts?.Cancel(); } catch { }
            try { _listener?.Stop(); } catch { }
        }

        public void Dispose()
        {
            Stop();
            try { _listener?.Close(); } catch { }
            _cts?.Dispose();
        }
    }
}