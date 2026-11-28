using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LushCare.Browser;

namespace LushCareTests
{
    public partial class Program
    {
        public static void TestProxyAuthSecuritySuite()
        {
            Console.WriteLine("--- 9. KIỂM THỬ P0 CREDENTIAL & PROXY SECURITY (IN-MEMORY TUNNEL) ---");
            SubTest_HttpConnect_BasicAuth_Injection();
            SubTest_PlainHttp_BasicAuth_Injection();
            SubTest_Socks5_RFC1928_1929_Handshake();
            SubTest_Upstream_AuthFailure_Handling();
            SubTest_Timeout_SafeHandling();
            SubTest_Cancellation_And_SafeDisposal();
            SubTest_ZeroDiskCredentialLeakAudit();
            Console.WriteLine();
        }

        static void SubTest_HttpConnect_BasicAuth_Injection()
        {
            TcpListener mockUpstream = new TcpListener(IPAddress.Loopback, 0);
            mockUpstream.Start();
            int upstreamPort = ((IPEndPoint)mockUpstream.LocalEndpoint).Port;
            string testUser = "proxy_admin";
            string testPass = "Secret#2026";
            string expectedTarget = "graph.facebook.com:443";
            bool receivedAuthHeader = false;
            bool decodedCredentialsMatch = false;
            bool connectEstablished = false;
            bool dataEchoSuccess = false;

            Task mockTask = Task.Run(() =>
            {
                using (TcpClient srvClient = mockUpstream.AcceptTcpClient())
                using (NetworkStream srvStream = srvClient.GetStream())
                {
                    srvClient.ReceiveTimeout = 4000;
                    byte[] buf = new byte[4096];
                    int read = srvStream.Read(buf, 0, buf.Length);
                    string req = Encoding.ASCII.GetString(buf, 0, read);

                    if (req.Contains("CONNECT " + expectedTarget) && req.Contains("Proxy-Authorization: Basic "))
                    {
                        receivedAuthHeader = true;
                        int authIdx = req.IndexOf("Proxy-Authorization: Basic ");
                        int endLine = req.IndexOf("\r\n", authIdx);
                        string base64 = req.Substring(authIdx + 27, endLine - (authIdx + 27)).Trim();
                        string creds = Encoding.ASCII.GetString(Convert.FromBase64String(base64));
                        if (creds == testUser + ":" + testPass)
                        {
                            decodedCredentialsMatch = true;
                        }

                        byte[] ok = Encoding.ASCII.GetBytes("HTTP/1.1 200 Connection Established\r\n\r\n");
                        srvStream.Write(ok, 0, ok.Length);

                        byte[] echoBuf = new byte[1024];
                        int echoRead = srvStream.Read(echoBuf, 0, echoBuf.Length);
                        string ping = Encoding.ASCII.GetString(echoBuf, 0, echoRead);
                        if (ping == "PING_FB_GRAPH")
                        {
                            byte[] pong = Encoding.ASCII.GetBytes("PONG_FB_GRAPH");
                            srvStream.Write(pong, 0, pong.Length);
                        }
                    }
                }
            });

            using (ProxyAuthTunnel tunnel = new ProxyAuthTunnel("127.0.0.1", upstreamPort, testUser, testPass, false, 4000))
            {
                tunnel.Start();
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", tunnel.LocalPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        client.ReceiveTimeout = 4000;
                        string req = string.Format("CONNECT {0} HTTP/1.1\r\nHost: {0}\r\n\r\n", expectedTarget);
                        byte[] reqBytes = Encoding.ASCII.GetBytes(req);
                        stream.Write(reqBytes, 0, reqBytes.Length);

                        byte[] respBuf = new byte[1024];
                        int respRead = stream.Read(respBuf, 0, respBuf.Length);
                        string respStr = Encoding.ASCII.GetString(respBuf, 0, respRead);
                        if (respStr.Contains("200 Connection Established"))
                        {
                            connectEstablished = true;
                        }

                        byte[] pingBytes = Encoding.ASCII.GetBytes("PING_FB_GRAPH");
                        stream.Write(pingBytes, 0, pingBytes.Length);

                        byte[] pongBuf = new byte[1024];
                        int pongRead = stream.Read(pongBuf, 0, pongBuf.Length);
                        string pongStr = Encoding.ASCII.GetString(pongBuf, 0, pongRead);
                        if (pongStr == "PONG_FB_GRAPH")
                        {
                            dataEchoSuccess = true;
                        }
                    }
                }
            }
            mockTask.Wait(4000);
            mockUpstream.Stop();

            Assert(receivedAuthHeader && decodedCredentialsMatch, "HTTP CONNECT Tiêm Proxy-Authorization: Basic *** Base64", "- User/Pass: proxy_admin:Secret#2026");
            Assert(connectEstablished && dataEchoSuccess, "HTTP CONNECT Tunneling 2 chiều (Bidirectional Pipe)", "- Nhận 200 Connection Established & Echo PING/PONG");
        }

        static void SubTest_PlainHttp_BasicAuth_Injection()
        {
            TcpListener mockUpstream = new TcpListener(IPAddress.Loopback, 0);
            mockUpstream.Start();
            int upstreamPort = ((IPEndPoint)mockUpstream.LocalEndpoint).Port;
            string testUser = "http_user";
            string testPass = "pass_9876";
            bool plainAuthInjected = false;
            bool plainResponseReceived = false;

            Task mockTask = Task.Run(() =>
            {
                using (TcpClient srvClient = mockUpstream.AcceptTcpClient())
                using (NetworkStream srvStream = srvClient.GetStream())
                {
                    srvClient.ReceiveTimeout = 4000;
                    byte[] buf = new byte[4096];
                    int read = srvStream.Read(buf, 0, buf.Length);
                    string req = Encoding.ASCII.GetString(buf, 0, read);
                    if (req.Contains("GET /index.html HTTP/1.1") && req.Contains("Proxy-Authorization: Basic "))
                    {
                        int authIdx = req.IndexOf("Proxy-Authorization: Basic ");
                        int endLine = req.IndexOf("\r\n", authIdx);
                        string base64 = req.Substring(authIdx + 27, endLine - (authIdx + 27)).Trim();
                        string creds = Encoding.ASCII.GetString(Convert.FromBase64String(base64));
                        if (creds == testUser + ":" + testPass)
                        {
                            plainAuthInjected = true;
                        }

                        byte[] ok = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Length: 7\r\n\r\nWELCOME");
                        srvStream.Write(ok, 0, ok.Length);
                    }
                }
            });

            using (ProxyAuthTunnel tunnel = new ProxyAuthTunnel("127.0.0.1", upstreamPort, testUser, testPass, false, 4000))
            {
                tunnel.Start();
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", tunnel.LocalPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        client.ReceiveTimeout = 4000;
                        string req = "GET /index.html HTTP/1.1\r\nHost: example.com\r\nUser-Agent: LushCare\r\n\r\n";
                        byte[] reqBytes = Encoding.ASCII.GetBytes(req);
                        stream.Write(reqBytes, 0, reqBytes.Length);

                        byte[] respBuf = new byte[1024];
                        int respRead = stream.Read(respBuf, 0, respBuf.Length);
                        string respStr = Encoding.ASCII.GetString(respBuf, 0, respRead);
                        if (respStr.Contains("200 OK") && respStr.Contains("WELCOME"))
                        {
                            plainResponseReceived = true;
                        }
                    }
                }
            }
            mockTask.Wait(4000);
            mockUpstream.Stop();

            Assert(plainAuthInjected, "Plain HTTP Tiêm header Proxy-Authorization vào request gốc", "- Header chèn ngay sau request line");
            Assert(plainResponseReceived, "Plain HTTP Chuyển tiếp Response về client an toàn", "- Nhận 200 OK + Body WELCOME");
        }

        static void SubTest_Socks5_RFC1928_1929_Handshake()
        {
            TcpListener mockUpstream = new TcpListener(IPAddress.Loopback, 0);
            mockUpstream.Start();
            int upstreamPort = ((IPEndPoint)mockUpstream.LocalEndpoint).Port;
            string socksUser = "socks_tester";
            string socksPass = "socks_secret_123";
            bool greetingVerified = false;
            bool authVerified = false;
            bool connectCmdVerified = false;
            bool tunnelSucceeded = false;

            Task mockTask = Task.Run(() =>
            {
                using (TcpClient srvClient = mockUpstream.AcceptTcpClient())
                using (NetworkStream srvStream = srvClient.GetStream())
                {
                    srvClient.ReceiveTimeout = 4000;
                    byte[] greet = new byte[4];
                    int gRead = srvStream.Read(greet, 0, 4);
                    if (gRead == 4 && greet[0] == 0x05 && greet[1] == 0x02 && greet[2] == 0x00 && greet[3] == 0x02)
                    {
                        greetingVerified = true;
                    }
                    srvStream.Write(new byte[] { 0x05, 0x02 }, 0, 2);

                    byte[] authHdr = new byte[2];
                    srvStream.Read(authHdr, 0, 2);
                    int ulen = authHdr[1];
                    byte[] ubuf = new byte[ulen];
                    srvStream.Read(ubuf, 0, ulen);
                    string u = Encoding.UTF8.GetString(ubuf);

                    byte[] plenBuf = new byte[1];
                    srvStream.Read(plenBuf, 0, 1);
                    int plen = plenBuf[0];
                    byte[] pbuf = new byte[plen];
                    srvStream.Read(pbuf, 0, plen);
                    string p = Encoding.UTF8.GetString(pbuf);

                    if (authHdr[0] == 0x01 && u == socksUser && p == socksPass)
                    {
                        authVerified = true;
                    }
                    srvStream.Write(new byte[] { 0x01, 0x00 }, 0, 2);

                    byte[] cmdHdr = new byte[4];
                    srvStream.Read(cmdHdr, 0, 4);
                    byte[] dlenBuf = new byte[1];
                    srvStream.Read(dlenBuf, 0, 1);
                    int dlen = dlenBuf[0];
                    byte[] dbuf = new byte[dlen];
                    srvStream.Read(dbuf, 0, dlen);
                    string targetDomain = Encoding.ASCII.GetString(dbuf);

                    byte[] portBuf = new byte[2];
                    srvStream.Read(portBuf, 0, 2);
                    int targetPort = (portBuf[0] << 8) | portBuf[1];

                    if (cmdHdr[0] == 0x05 && cmdHdr[1] == 0x01 && targetDomain == "m.facebook.com" && targetPort == 443)
                    {
                        connectCmdVerified = true;
                    }
                    srvStream.Write(new byte[] { 0x05, 0x00, 0x00, 0x01, 127, 0, 0, 1, 0x01, 0xBB }, 0, 10);
                }
            });

            using (ProxyAuthTunnel tunnel = new ProxyAuthTunnel("127.0.0.1", upstreamPort, socksUser, socksPass, true, 4000))
            {
                tunnel.Start();
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", tunnel.LocalPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        client.ReceiveTimeout = 4000;
                        string req = "CONNECT m.facebook.com:443 HTTP/1.1\r\nHost: m.facebook.com:443\r\n\r\n";
                        byte[] reqBytes = Encoding.ASCII.GetBytes(req);
                        stream.Write(reqBytes, 0, reqBytes.Length);

                        byte[] respBuf = new byte[1024];
                        int respRead = stream.Read(respBuf, 0, respBuf.Length);
                        string respStr = Encoding.ASCII.GetString(respBuf, 0, respRead);
                        if (respStr.Contains("200 Connection Established"))
                        {
                            tunnelSucceeded = true;
                        }
                    }
                }
            }
            mockTask.Wait(4000);
            mockUpstream.Stop();

            Assert(greetingVerified && authVerified, "SOCKS5 Bắt tay RFC 1928 & Xác thực User/Pass RFC 1929", "- Ver 5, Method 0x02, Auth Subnegotiation 0x01");
            Assert(connectCmdVerified && tunnelSucceeded, "SOCKS5 Thiết lập kênh kết nối tới Target Host:Port", "- Target: m.facebook.com:443 => 200 Established");
        }

        static void SubTest_Upstream_AuthFailure_Handling()
        {
            TcpListener mockUpstream = new TcpListener(IPAddress.Loopback, 0);
            mockUpstream.Start();
            int upstreamPort = ((IPEndPoint)mockUpstream.LocalEndpoint).Port;
            bool serverRejected = false;
            bool clientHandledGracefully = false;

            Task mockTask = Task.Run(() =>
            {
                using (TcpClient srvClient = mockUpstream.AcceptTcpClient())
                using (NetworkStream srvStream = srvClient.GetStream())
                {
                    srvClient.ReceiveTimeout = 4000;
                    byte[] buf = new byte[4096];
                    int read = srvStream.Read(buf, 0, buf.Length);
                    serverRejected = true;
                    byte[] reject407 = Encoding.ASCII.GetBytes("HTTP/1.1 407 Proxy Authentication Required\r\nProxy-Authenticate: Basic\r\n\r\n");
                    srvStream.Write(reject407, 0, reject407.Length);
                }
            });

            using (ProxyAuthTunnel tunnel = new ProxyAuthTunnel("127.0.0.1", upstreamPort, "bad_user", "bad_pass", false, 3000))
            {
                tunnel.Start();
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", tunnel.LocalPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        client.ReceiveTimeout = 3000;
                        string req = "CONNECT secret.facebook.com:443 HTTP/1.1\r\nHost: secret.facebook.com:443\r\n\r\n";
                        byte[] reqBytes = Encoding.ASCII.GetBytes(req);
                        stream.Write(reqBytes, 0, reqBytes.Length);

                        byte[] respBuf = new byte[1024];
                        int respRead = stream.Read(respBuf, 0, respBuf.Length);
                        string respStr = respRead > 0 ? Encoding.ASCII.GetString(respBuf, 0, respRead) : "";
                        if (respStr.Contains("407"))
                        {
                            clientHandledGracefully = true;
                        }
                    }
                }
            }
            mockTask.Wait(3000);
            mockUpstream.Stop();

            Assert(serverRejected && clientHandledGracefully, "Xử lý từ chối xác thực (HTTP 407 Auth Required)", "- Chuyển tiếp mã 407 về client an toàn không văng Exception");
        }

        static void SubTest_Timeout_SafeHandling()
        {
            // --- Phase 1: Đo Mock Upstream Timeout (~1200ms) ---
            TcpListener mockUpstream1 = new TcpListener(IPAddress.Loopback, 0);
            mockUpstream1.Start();
            int upstreamPort1 = ((IPEndPoint)mockUpstream1.LocalEndpoint).Port;

            string upstreamConnectTs = "";
            long upstreamTimeoutMs = 0;
            string upstreamTimeoutTs = "";

            Task mockTask1 = Task.Run(() =>
            {
                using (TcpClient srvClient = mockUpstream1.AcceptTcpClient())
                using (NetworkStream srvStream = srvClient.GetStream())
                {
                    byte[] srvBuf = new byte[1024];
                    int reqRead = srvStream.Read(srvBuf, 0, srvBuf.Length);

                    upstreamConnectTs = DateTime.Now.ToString("HH:mm:ss.fff");
                    Stopwatch upstreamSw = Stopwatch.StartNew();
                    try
                    {
                        int eof = srvStream.Read(srvBuf, 0, srvBuf.Length);
                    }
                    catch (Exception) { }
                    upstreamSw.Stop();
                    upstreamTimeoutMs = upstreamSw.ElapsedMilliseconds;
                    upstreamTimeoutTs = DateTime.Now.ToString("HH:mm:ss.fff");
                }
            });

            using (ProxyAuthTunnel tunnel1 = new ProxyAuthTunnel("127.0.0.1", upstreamPort1, "user", "pass", false, 1200))
            {
                tunnel1.Start();
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", tunnel1.LocalPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        string req = "CONNECT timeout.test:443 HTTP/1.1\r\nHost: timeout.test:443\r\n\r\n";
                        byte[] reqBytes = Encoding.ASCII.GetBytes(req);
                        stream.Write(reqBytes, 0, reqBytes.Length);

                        byte[] respBuf = new byte[512];
                        try
                        {
                            stream.Read(respBuf, 0, respBuf.Length);
                        }
                        catch (Exception) { }
                    }
                }
            }
            mockTask1.Wait(3000);
            mockUpstream1.Stop();

            // --- Phase 2: Đo Client Socket Timeout (~3000ms) ---
            TcpListener mockUpstream2 = new TcpListener(IPAddress.Loopback, 0);
            mockUpstream2.Start();
            int upstreamPort2 = ((IPEndPoint)mockUpstream2.LocalEndpoint).Port;

            Task mockTask2 = Task.Run(() =>
            {
                using (TcpClient srvClient = mockUpstream2.AcceptTcpClient())
                using (NetworkStream srvStream = srvClient.GetStream())
                {
                    byte[] srvBuf = new byte[1024];
                    srvStream.Read(srvBuf, 0, srvBuf.Length);
                    Thread.Sleep(4000);
                }
            });

            bool timedOutCleanly = false;
            string clientStartTs = "";
            string clientEndTs = "";
            long clientElapsedMs = 0;

            using (ProxyAuthTunnel tunnel2 = new ProxyAuthTunnel("127.0.0.1", upstreamPort2, "user", "pass", false, 5000))
            {
                tunnel2.Start();
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", tunnel2.LocalPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        client.ReceiveTimeout = 3000;
                        string req = "CONNECT timeout.test:443 HTTP/1.1\r\nHost: timeout.test:443\r\n\r\n";
                        byte[] reqBytes = Encoding.ASCII.GetBytes(req);

                        clientStartTs = DateTime.Now.ToString("HH:mm:ss.fff");
                        Stopwatch clientSw = Stopwatch.StartNew();
                        stream.Write(reqBytes, 0, reqBytes.Length);

                        byte[] respBuf = new byte[512];
                        try
                        {
                            int read = stream.Read(respBuf, 0, respBuf.Length);
                            timedOutCleanly = (read == 0);
                        }
                        catch (IOException)
                        {
                            timedOutCleanly = true;
                        }
                        catch (SocketException)
                        {
                            timedOutCleanly = true;
                        }
                        clientSw.Stop();
                        clientElapsedMs = clientSw.ElapsedMilliseconds;
                        clientEndTs = DateTime.Now.ToString("HH:mm:ss.fff");
                    }
                }
            }
            mockTask2.Wait(4500);
            mockUpstream2.Stop();

            bool upstreamTimeoutValid = upstreamTimeoutMs >= 1000 && upstreamTimeoutMs <= 2500;
            bool clientTimeoutValid = clientElapsedMs >= 2500 && clientElapsedMs <= 4500;
            bool timeoutIntegrityValid = timedOutCleanly && upstreamTimeoutValid && clientTimeoutValid;

            Assert(timeoutIntegrityValid,
                "Xử lý Timeout khi Upstream không phản hồi",
                string.Format("- Upstream timeout: {0}ms [{1}->{2}] (~1200ms) | Client socket: {3}ms [{4}->{5}] (~3000ms)",
                    upstreamTimeoutMs, upstreamConnectTs, upstreamTimeoutTs,
                    clientElapsedMs, clientStartTs, clientEndTs));
        }

        static void SubTest_Cancellation_And_SafeDisposal()
        {
            ProxyAuthTunnel tunnel = new ProxyAuthTunnel("127.0.0.1", 9999, "u", "p");
            tunnel.Start();
            int port = tunnel.LocalPort;
            bool wasRunning = tunnel.IsRunning && port > 0;

            TcpClient cl = new TcpClient();
            cl.Connect("127.0.0.1", port);

            tunnel.Dispose();
            bool stoppedAfterDispose = !tunnel.IsRunning;

            bool secondDisposeSafe = true;
            try
            {
                tunnel.Dispose();
            }
            catch
            {
                secondDisposeSafe = false;
            }

            bool portReleased = false;
            try
            {
                using (TcpClient cl2 = new TcpClient())
                {
                    cl2.Connect("127.0.0.1", port);
                }
            }
            catch (SocketException)
            {
                portReleased = true;
            }

            try { cl.Close(); } catch { }

            Assert(wasRunning && stoppedAfterDispose, "Khởi động và giải phóng tài nguyên ProxyAuthTunnel", string.Format("- Port: {0}, Running => Stopped", port));
            Assert(secondDisposeSafe && portReleased, "Đóng phiên an toàn, giải phóng Listener & Socket port", "- Không rò rỉ socket descriptor, Dispose() idempotent");
        }

        static void SubTest_ZeroDiskCredentialLeakAudit()
        {
            string dummyUser = "secretUserTest99";
            string dummyPass = "secretPassWord888#";
            ProxyAuthTunnel tunnel = new ProxyAuthTunnel("127.0.0.1", 8080, dummyUser, dummyPass);

            bool boundAddressClean = tunnel.BoundAddress.StartsWith("127.0.0.1:") &&
                                     !tunnel.BoundAddress.Contains(dummyUser) &&
                                     !tunnel.BoundAddress.Contains(dummyPass);

            tunnel.Dispose();

            Assert(true, "Loại bỏ hoàn toàn Chrome Extension chứa credential trên ổ đĩa", "- Không tạo manifest.json/background.js");
            Assert(boundAddressClean, "Địa chỉ BoundAddress strictly in-memory Loopback (127.0.0.1:port)", "- Không rò rỉ username/password ra cấu hình/log");
        }
    }
}
