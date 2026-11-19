using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class LocalProxyTunnel : IDisposable
{
    private readonly ProxyInfo _upstream;
    private TcpListener _listener;
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();
    private readonly ConcurrentDictionary<Socket, byte> _activeSockets = new ConcurrentDictionary<Socket, byte>();
    private bool _isDisposed = false;

    public int LocalPort { get; private set; }
    public ProxyInfo UpstreamProxy => _upstream;

    public LocalProxyTunnel(ProxyInfo upstream)
    {
        _upstream = upstream ?? throw new ArgumentNullException(nameof(upstream));
    }

    public void Start()
    {
        _listener = new TcpListener(IPAddress.Loopback, 0);
        _listener.Start();
        LocalPort = ((IPEndPoint)_listener.LocalEndpoint).Port;

        Task.Run(AcceptLoopAsync);
    }

    private async Task AcceptLoopAsync()
    {
        while (!_cts.IsCancellationRequested && !_isDisposed)
        {
            try
            {
                Socket clientSocket = await _listener.AcceptSocketAsync().ConfigureAwait(false);
                clientSocket.NoDelay = true;
                _activeSockets.TryAdd(clientSocket, 0);
                _ = Task.Run(() => HandleClientAsync(clientSocket));
            }
            catch (ObjectDisposedException)
            {
                break;
            }
            catch (Exception)
            {
                if (_cts.IsCancellationRequested) break;
            }
        }
    }

    private async Task HandleClientAsync(Socket clientSocket)
    {
        Socket upstreamSocket = null;
        try
        {
            using (var clientStream = new NetworkStream(clientSocket, ownsSocket: false))
            {
                // Read the initial HTTP request line and headers
                byte[] buffer = new byte[8192];
                int totalRead = 0;
                string headersText = "";

                while (totalRead < buffer.Length)
                {
                    int read = await clientStream.ReadAsync(buffer, totalRead, buffer.Length - totalRead, _cts.Token).ConfigureAwait(false);
                    if (read <= 0) return;
                    totalRead += read;
                    headersText = Encoding.ASCII.GetString(buffer, 0, totalRead);
                    if (headersText.Contains("\r\n\r\n")) break;
                }

                int headerEndIdx = headersText.IndexOf("\r\n\r\n", StringComparison.Ordinal);
                if (headerEndIdx < 0) return;

                int firstLineEnd = headersText.IndexOf("\r\n", StringComparison.Ordinal);
                if (firstLineEnd < 0) return;

                string firstLine = headersText.Substring(0, firstLineEnd);
                string[] reqParts = firstLine.Split(' ');
                if (reqParts.Length < 2) return;

                string method = reqParts[0].ToUpperInvariant();
                string target = reqParts[1];

                // Connect to upstream proxy
                upstreamSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    NoDelay = true
                };
                _activeSockets.TryAdd(upstreamSocket, 0);

                await ConnectSocketAsync(upstreamSocket, _upstream.Host, _upstream.Port, 10000).ConfigureAwait(false);

                using (var upstreamStream = new NetworkStream(upstreamSocket, ownsSocket: false))
                {
                    if (_upstream.ProxyType == 1) // SOCKS5
                    {
                        await HandleSocks5RelayAsync(clientStream, upstreamStream, method, target, buffer, totalRead, headerEndIdx + 4).ConfigureAwait(false);
                    }
                    else // HTTP proxy
                    {
                        await HandleHttpRelayAsync(clientStream, upstreamStream, method, target, headersText, buffer, totalRead, headerEndIdx + 4).ConfigureAwait(false);
                    }
                }
            }
        }
        catch
        {
            // Silently close on client disconnect or proxy timeout
        }
        finally
        {
            CloseSocket(clientSocket);
            CloseSocket(upstreamSocket);
        }
    }

    private async Task HandleHttpRelayAsync(NetworkStream clientStream, NetworkStream upstreamStream, string method, string target, string headersText, byte[] initialBuffer, int initialTotal, int bodyStartIdx)
    {
        string authHeader = "";
        if (_upstream.HasAuth)
        {
            string rawCreds = $"{_upstream.Username}:{_upstream.Password}";
            string base64Creds = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawCreds));
            authHeader = $"Proxy-Authorization: Basic {base64Creds}\r\n";
        }

        if (method == "CONNECT")
        {
            // Chrome is opening a tunnel (HTTPS)
            string connectReq = $"CONNECT {target} HTTP/1.1\r\nHost: {target}\r\n{authHeader}Proxy-Connection: Keep-Alive\r\n\r\n";
            byte[] connectBytes = Encoding.ASCII.GetBytes(connectReq);
            await upstreamStream.WriteAsync(connectBytes, 0, connectBytes.Length).ConfigureAwait(false);
            await upstreamStream.FlushAsync().ConfigureAwait(false);

            // Read response from upstream
            byte[] respBuf = new byte[4096];
            int respTotal = 0;
            string respStr = "";
            while (respTotal < respBuf.Length)
            {
                int r = await upstreamStream.ReadAsync(respBuf, respTotal, respBuf.Length - respTotal).ConfigureAwait(false);
                if (r <= 0) return;
                respTotal += r;
                respStr = Encoding.ASCII.GetString(respBuf, 0, respTotal);
                if (respStr.Contains("\r\n\r\n")) break;
            }

            if (respStr.StartsWith("HTTP/1.0 200") || respStr.StartsWith("HTTP/1.1 200"))
            {
                byte[] okBytes = Encoding.ASCII.GetBytes("HTTP/1.1 200 Connection Established\r\n\r\n");
                await clientStream.WriteAsync(okBytes, 0, okBytes.Length).ConfigureAwait(false);
                await clientStream.FlushAsync().ConfigureAwait(false);

                // If upstream sent any extra bytes after the 200 headers
                int headerEnd = respStr.IndexOf("\r\n\r\n", StringComparison.Ordinal) + 4;
                if (respTotal > headerEnd)
                {
                    await clientStream.WriteAsync(respBuf, headerEnd, respTotal - headerEnd).ConfigureAwait(false);
                }

                // Bidirectional pump
                await RelayBidirectionalAsync(clientStream, upstreamStream).ConfigureAwait(false);
            }
            else
            {
                // Relay error response (e.g. 407, 502) back to client
                await clientStream.WriteAsync(respBuf, 0, respTotal).ConfigureAwait(false);
            }
        }
        else
        {
            // Plain HTTP (GET, POST, etc.)
            // Inject Proxy-Authorization header if needed
            string modifiedHeaders = headersText;
            if (!string.IsNullOrEmpty(authHeader) && !headersText.Contains("Proxy-Authorization:"))
            {
                int idx = headersText.IndexOf("\r\n\r\n", StringComparison.Ordinal);
                if (idx >= 0)
                {
                    modifiedHeaders = headersText.Substring(0, idx) + "\r\n" + authHeader + "\r\n";
                }
            }

            byte[] newHeaderBytes = Encoding.ASCII.GetBytes(modifiedHeaders);
            await upstreamStream.WriteAsync(newHeaderBytes, 0, newHeaderBytes.Length).ConfigureAwait(false);

            // Forward any initial body bytes that were already read
            if (initialTotal > bodyStartIdx)
            {
                await upstreamStream.WriteAsync(initialBuffer, bodyStartIdx, initialTotal - bodyStartIdx).ConfigureAwait(false);
            }
            await upstreamStream.FlushAsync().ConfigureAwait(false);

            // Bidirectional pump
            await RelayBidirectionalAsync(clientStream, upstreamStream).ConfigureAwait(false);
        }
    }

    private async Task HandleSocks5RelayAsync(NetworkStream clientStream, NetworkStream upstreamStream, string method, string target, byte[] initialBuffer, int initialTotal, int bodyStartIdx)
    {
        // 1. SOCKS5 Greeting
        byte[] greeting;
        if (_upstream.HasAuth)
        {
            // Method 0x00 (No Auth), 0x02 (Username/Password)
            greeting = new byte[] { 0x05, 0x02, 0x00, 0x02 };
        }
        else
        {
            greeting = new byte[] { 0x05, 0x01, 0x00 };
        }

        await upstreamStream.WriteAsync(greeting, 0, greeting.Length).ConfigureAwait(false);
        await upstreamStream.FlushAsync().ConfigureAwait(false);

        byte[] methodResp = new byte[2];
        await ReadExactAsync(upstreamStream, methodResp, 0, 2).ConfigureAwait(false);

        if (methodResp[0] != 0x05 || methodResp[1] == 0xFF)
        {
            return; // No acceptable methods
        }

        // 2. SOCKS5 Authentication if requested
        if (methodResp[1] == 0x02)
        {
            byte[] uBytes = Encoding.UTF8.GetBytes(_upstream.Username ?? "");
            byte[] pBytes = Encoding.UTF8.GetBytes(_upstream.Password ?? "");

            byte[] authReq = new byte[3 + uBytes.Length + pBytes.Length];
            authReq[0] = 0x01; // Version
            authReq[1] = (byte)uBytes.Length;
            Buffer.BlockCopy(uBytes, 0, authReq, 2, uBytes.Length);
            authReq[2 + uBytes.Length] = (byte)pBytes.Length;
            Buffer.BlockCopy(pBytes, 0, authReq, 3 + uBytes.Length, pBytes.Length);

            await upstreamStream.WriteAsync(authReq, 0, authReq.Length).ConfigureAwait(false);
            await upstreamStream.FlushAsync().ConfigureAwait(false);

            byte[] authResp = new byte[2];
            await ReadExactAsync(upstreamStream, authResp, 0, 2).ConfigureAwait(false);
            if (authResp[0] != 0x01 || authResp[1] != 0x00)
            {
                return; // Auth failed
            }
        }

        // 3. Resolve Target Host & Port from method & target
        string targetHost = target;
        int targetPort = 80;

        if (method == "CONNECT")
        {
            int colon = target.LastIndexOf(':');
            if (colon >= 0)
            {
                targetHost = target.Substring(0, colon);
                int.TryParse(target.Substring(colon + 1), out targetPort);
            }
            else
            {
                targetPort = 443;
            }
        }
        else
        {
            // HTTP URL: parse host from target or Host header
            try
            {
                if (target.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                {
                    var uri = new Uri(target);
                    targetHost = uri.DnsSafeHost;
                    targetPort = uri.Port;
                }
            }
            catch {}
        }

        // 4. SOCKS5 Connect Request
        byte[] connectReq;
        if (IPAddress.TryParse(targetHost, out IPAddress ip) && ip.AddressFamily == AddressFamily.InterNetwork)
        {
            byte[] ipBytes = ip.GetAddressBytes();
            connectReq = new byte[10];
            connectReq[0] = 0x05;
            connectReq[1] = 0x01; // CMD: CONNECT
            connectReq[2] = 0x00; // RSV
            connectReq[3] = 0x01; // ATYP: IPv4
            Buffer.BlockCopy(ipBytes, 0, connectReq, 4, 4);
            connectReq[8] = (byte)(targetPort >> 8);
            connectReq[9] = (byte)(targetPort & 0xFF);
        }
        else
        {
            byte[] domainBytes = Encoding.ASCII.GetBytes(targetHost);
            connectReq = new byte[7 + domainBytes.Length];
            connectReq[0] = 0x05;
            connectReq[1] = 0x01; // CMD: CONNECT
            connectReq[2] = 0x00; // RSV
            connectReq[3] = 0x03; // ATYP: Domain name
            connectReq[4] = (byte)domainBytes.Length;
            Buffer.BlockCopy(domainBytes, 0, connectReq, 5, domainBytes.Length);
            connectReq[5 + domainBytes.Length] = (byte)(targetPort >> 8);
            connectReq[6 + domainBytes.Length] = (byte)(targetPort & 0xFF);
        }

        await upstreamStream.WriteAsync(connectReq, 0, connectReq.Length).ConfigureAwait(false);
        await upstreamStream.FlushAsync().ConfigureAwait(false);

        // Read SOCKS5 Connect Reply
        byte[] replyHeader = new byte[4];
        await ReadExactAsync(upstreamStream, replyHeader, 0, 4).ConfigureAwait(false);
        if (replyHeader[0] != 0x05 || replyHeader[1] != 0x00)
        {
            return; // Connect failed
        }

        // Read bound address and port
        byte atyp = replyHeader[3];
        if (atyp == 0x01) // IPv4 (4 bytes) + port (2 bytes)
        {
            byte[] rest = new byte[6];
            await ReadExactAsync(upstreamStream, rest, 0, 6).ConfigureAwait(false);
        }
        else if (atyp == 0x03) // Domain: 1 byte len + domain + 2 bytes port
        {
            byte[] lenBuf = new byte[1];
            await ReadExactAsync(upstreamStream, lenBuf, 0, 1).ConfigureAwait(false);
            byte[] rest = new byte[lenBuf[0] + 2];
            await ReadExactAsync(upstreamStream, rest, 0, rest.Length).ConfigureAwait(false);
        }
        else if (atyp == 0x04) // IPv6 (16 bytes) + port (2 bytes)
        {
            byte[] rest = new byte[18];
            await ReadExactAsync(upstreamStream, rest, 0, 18).ConfigureAwait(false);
        }

        // 5. Successfully connected to target via SOCKS5
        if (method == "CONNECT")
        {
            byte[] okBytes = Encoding.ASCII.GetBytes("HTTP/1.1 200 Connection Established\r\n\r\n");
            await clientStream.WriteAsync(okBytes, 0, okBytes.Length).ConfigureAwait(false);
            await clientStream.FlushAsync().ConfigureAwait(false);
            await RelayBidirectionalAsync(clientStream, upstreamStream).ConfigureAwait(false);
        }
        else
        {
            // For plain HTTP over SOCKS5: send initial bytes and relay
            await upstreamStream.WriteAsync(initialBuffer, 0, initialTotal).ConfigureAwait(false);
            await upstreamStream.FlushAsync().ConfigureAwait(false);
            await RelayBidirectionalAsync(clientStream, upstreamStream).ConfigureAwait(false);
        }
    }

    private async Task RelayBidirectionalAsync(NetworkStream s1, NetworkStream s2)
    {
        var t1 = RelayStreamAsync(s1, s2);
        var t2 = RelayStreamAsync(s2, s1);
        await Task.WhenAny(t1, t2).ConfigureAwait(false);
    }

    private async Task RelayStreamAsync(NetworkStream src, NetworkStream dst)
    {
        byte[] buf = new byte[32768];
        try
        {
            while (!_cts.IsCancellationRequested && !_isDisposed)
            {
                int r = await src.ReadAsync(buf, 0, buf.Length, _cts.Token).ConfigureAwait(false);
                if (r <= 0) break;
                await dst.WriteAsync(buf, 0, r, _cts.Token).ConfigureAwait(false);
                await dst.FlushAsync(_cts.Token).ConfigureAwait(false);
            }
        }
        catch {}
    }

    private static async Task ReadExactAsync(Stream s, byte[] buf, int offset, int count)
    {
        int read = 0;
        while (read < count)
        {
            int r = await s.ReadAsync(buf, offset + read, count - read).ConfigureAwait(false);
            if (r <= 0) throw new EndOfStreamException();
            read += r;
        }
    }

    private static async Task ConnectSocketAsync(Socket socket, string host, int port, int timeoutMs)
    {
        var t = Task.Factory.FromAsync(
            (cb, state) => socket.BeginConnect(host, port, cb, state),
            socket.EndConnect,
            null);

        var delay = Task.Delay(timeoutMs);
        var finished = await Task.WhenAny(t, delay).ConfigureAwait(false);
        if (finished == delay)
        {
            socket.Close();
            throw new TimeoutException($"Connection to proxy {host}:{port} timed out after {timeoutMs}ms");
        }
        await t.ConfigureAwait(false);
    }

    private void CloseSocket(Socket s)
    {
        if (s == null) return;
        try
        {
            _activeSockets.TryRemove(s, out _);
            if (s.Connected) s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
        catch {}
    }

    public void Stop()
    {
        Dispose();
    }

    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;

        try { _cts.Cancel(); } catch {}
        try { _listener?.Stop(); } catch {}

        foreach (var s in _activeSockets.Keys)
        {
            try { s.Close(); } catch {}
        }
        _activeSockets.Clear();
        _cts.Dispose();
    }
}
