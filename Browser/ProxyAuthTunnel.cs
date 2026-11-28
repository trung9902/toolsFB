using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LushCare.Browser
{
    /// <summary>
    /// High-performance in-memory local proxy bridge for authenticated HTTP and SOCKS5 proxies.
    /// Solves SEC-P0-01 & SEC-P0-02: Keeps credentials strictly in RAM, eliminating plaintext
    /// files (manifest.json, background.js) on disk, log leaks, and uncleaned temporary directories.
    /// </summary>
    public sealed class ProxyAuthTunnel : IDisposable
    {
        private readonly string _upstreamHost;
        private readonly int _upstreamPort;
        private readonly string _username;
        private readonly string _password;
        private readonly bool _isSocks5;
        private readonly int _timeoutMs;

        private TcpListener _listener;
        private CancellationTokenSource _cts;
        private readonly ConcurrentDictionary<Guid, TcpClient> _activeClients = new ConcurrentDictionary<Guid, TcpClient>();
        private bool _disposed;

        public int LocalPort { get; private set; }
        public bool IsRunning { get; private set; }
        public string BoundAddress { get { return string.Format("127.0.0.1:{0}", LocalPort); } }

        public ProxyAuthTunnel(string upstreamHost, int upstreamPort, string username, string password, bool isSocks5 = false, int timeoutMs = 15000)
        {
            if (upstreamHost == null) throw new ArgumentNullException("upstreamHost");
            _upstreamHost = upstreamHost;
            _upstreamPort = upstreamPort;
            _username = username ?? string.Empty;
            _password = password ?? string.Empty;
            _isSocks5 = isSocks5;
            _timeoutMs = timeoutMs > 0 ? timeoutMs : 15000;
        }

        public void Start()
        {
            if (IsRunning || _disposed)
                return;

            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            LocalPort = ((IPEndPoint)_listener.LocalEndpoint).Port;
            IsRunning = true;

            Task.Run(() => AcceptLoopAsync(_cts.Token));
        }

        private async Task AcceptLoopAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && IsRunning)
            {
                try
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    Guid connectionId = Guid.NewGuid();
                    _activeClients[connectionId] = client;

                    Task.Run(async () =>
                    {
                        try
                        {
                            await HandleClientAsync(client, ct).ConfigureAwait(false);
                        }
                        catch
                        {
                            // Silent close on connection errors
                        }
                        finally
                        {
                            TcpClient ignoredClient;
                            _activeClients.TryRemove(connectionId, out ignoredClient);
                            try { client.Close(); } catch { }
                        }
                    }, ct);
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (SocketException)
                {
                    break;
                }
                catch
                {
                    if (!IsRunning || ct.IsCancellationRequested)
                        break;
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken ct)
        {
            client.ReceiveTimeout = _timeoutMs;
            client.SendTimeout = _timeoutMs;
            NetworkStream clientStream = client.GetStream();

            byte[] buffer = new byte[8192];
            int bytesRead = await ReadWithTimeoutAsync(clientStream, buffer, 0, buffer.Length, _timeoutMs, ct).ConfigureAwait(false);
            if (bytesRead <= 0)
                return;

            string initialRequest = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            int firstLineEnd = initialRequest.IndexOf("\r\n", StringComparison.Ordinal);
            if (firstLineEnd <= 0)
                return;

            string requestLine = initialRequest.Substring(0, firstLineEnd);
            string[] parts = requestLine.Split(' ');
            if (parts.Length < 3)
                return;

            string method = parts[0].ToUpperInvariant();
            string target = parts[1];

            if (method == "CONNECT")
            {
                await HandleConnectAsync(clientStream, target, initialRequest, ct).ConfigureAwait(false);
            }
            else
            {
                await HandlePlainHttpAsync(clientStream, buffer, bytesRead, ct).ConfigureAwait(false);
            }
        }

        private async Task HandleConnectAsync(NetworkStream clientStream, string target, string initialRequest, CancellationToken ct)
        {
            string targetHost;
            int targetPort = 443;
            int colonIdx = target.LastIndexOf(':');
            if (colonIdx > 0)
            {
                targetHost = target.Substring(0, colonIdx);
                int.TryParse(target.Substring(colonIdx + 1), out targetPort);
            }
            else
            {
                targetHost = target;
            }

            TcpClient upstreamClient = new TcpClient();
            try
            {
                using (var connectCts = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    connectCts.CancelAfter(_timeoutMs);
                    await upstreamClient.ConnectAsync(_upstreamHost, _upstreamPort).ConfigureAwait(false);
                }

                NetworkStream upstreamStream = upstreamClient.GetStream();
                upstreamClient.ReceiveTimeout = _timeoutMs;
                upstreamClient.SendTimeout = _timeoutMs;

                if (_isSocks5)
                {
                    bool socksAuth = await PerformSocks5AuthAsync(upstreamStream, targetHost, targetPort, ct).ConfigureAwait(false);
                    if (!socksAuth)
                    {
                        byte[] fail = Encoding.ASCII.GetBytes("HTTP/1.1 502 Bad Gateway\r\nProxy-Connection: close\r\n\r\n");
                        await clientStream.WriteAsync(fail, 0, fail.Length, ct).ConfigureAwait(false);
                        return;
                    }
                }
                else
                {
                    string authHeader = string.IsNullOrEmpty(_username) ? string.Empty : string.Format("Proxy-Authorization: Basic {0}\r\n", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _username, _password))));

                    string connectCmd = string.Format("CONNECT {0} HTTP/1.1\r\nHost: {0}\r\n{1}Proxy-Connection: Keep-Alive\r\n\r\n", target, authHeader);

                    byte[] connectBytes = Encoding.ASCII.GetBytes(connectCmd);
                    await upstreamStream.WriteAsync(connectBytes, 0, connectBytes.Length, ct).ConfigureAwait(false);

                    byte[] respBuf = new byte[4096];
                    int respBytes = await ReadWithTimeoutAsync(upstreamStream, respBuf, 0, respBuf.Length, _timeoutMs, ct).ConfigureAwait(false);
                    if (respBytes <= 0)
                        return;

                    string respStr = Encoding.ASCII.GetString(respBuf, 0, respBytes);
                    if (!respStr.Contains("200"))
                    {
                        // Upstream returned 407 or error, forward to client
                        await clientStream.WriteAsync(respBuf, 0, respBytes, ct).ConfigureAwait(false);
                        return;
                    }
                }

                // Inform client the tunnel is established
                byte[] ok = Encoding.ASCII.GetBytes("HTTP/1.1 200 Connection Established\r\n\r\n");
                await clientStream.WriteAsync(ok, 0, ok.Length, ct).ConfigureAwait(false);

                // Bidirectional stream piping
                Task t1 = PipeStreamAsync(clientStream, upstreamStream, ct);
                Task t2 = PipeStreamAsync(upstreamStream, clientStream, ct);
                await Task.WhenAny(t1, t2).ConfigureAwait(false);
            }
            finally
            {
                try { upstreamClient.Close(); } catch { }
            }
        }

        private async Task HandlePlainHttpAsync(NetworkStream clientStream, byte[] initialBuffer, int bytesRead, CancellationToken ct)
        {
            TcpClient upstreamClient = new TcpClient();
            try
            {
                using (var connectCts = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    connectCts.CancelAfter(_timeoutMs);
                    await upstreamClient.ConnectAsync(_upstreamHost, _upstreamPort).ConfigureAwait(false);
                }

                NetworkStream upstreamStream = upstreamClient.GetStream();

                string rawRequest = Encoding.ASCII.GetString(initialBuffer, 0, bytesRead);
                string authHeader = string.IsNullOrEmpty(_username) ? string.Empty : string.Format("Proxy-Authorization: Basic {0}\r\n", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _username, _password))));

                // Inject Proxy-Authorization if not present

                if (!string.IsNullOrEmpty(authHeader) && !rawRequest.Contains("Proxy-Authorization:"))
                {
                    int lineBreak = rawRequest.IndexOf("\r\n", StringComparison.Ordinal);
                    if (lineBreak > 0)
                    {
                        rawRequest = rawRequest.Insert(lineBreak + 2, authHeader);
                    }
                }

                byte[] modifiedBytes = Encoding.ASCII.GetBytes(rawRequest);
                await upstreamStream.WriteAsync(modifiedBytes, 0, modifiedBytes.Length, ct).ConfigureAwait(false);

                Task t1 = PipeStreamAsync(clientStream, upstreamStream, ct);
                Task t2 = PipeStreamAsync(upstreamStream, clientStream, ct);
                await Task.WhenAny(t1, t2).ConfigureAwait(false);
            }
            finally
            {
                try { upstreamClient.Close(); } catch { }
            }
        }

        private async Task<bool> PerformSocks5AuthAsync(NetworkStream stream, string targetHost, int targetPort, CancellationToken ct)
        {
            try
            {
                // 1. Send Greeting: VER=5, NMETHODS=2 (No Auth, User/Pass)
                byte[] greeting = new byte[] { 0x05, 0x02, 0x00, 0x02 };
                await stream.WriteAsync(greeting, 0, greeting.Length, ct).ConfigureAwait(false);

                byte[] resp = new byte[2];
                int r = await ReadExactAsync(stream, resp, 0, 2, ct).ConfigureAwait(false);
                if (r < 2 || resp[0] != 0x05)
                    return false;

                if (resp[1] == 0x02) // Username/Password Auth
                {
                    byte[] uBytes = Encoding.UTF8.GetBytes(_username);
                    byte[] pBytes = Encoding.UTF8.GetBytes(_password);
                    byte[] authReq = new byte[1 + 1 + uBytes.Length + 1 + pBytes.Length];
                    authReq[0] = 0x01; // Subnegotiation version 1
                    authReq[1] = (byte)uBytes.Length;
                    Buffer.BlockCopy(uBytes, 0, authReq, 2, uBytes.Length);
                    authReq[2 + uBytes.Length] = (byte)pBytes.Length;
                    Buffer.BlockCopy(pBytes, 0, authReq, 3 + uBytes.Length, pBytes.Length);

                    await stream.WriteAsync(authReq, 0, authReq.Length, ct).ConfigureAwait(false);

                    byte[] authResp = new byte[2];
                    int ar = await ReadExactAsync(stream, authResp, 0, 2, ct).ConfigureAwait(false);
                    if (ar < 2 || authResp[1] != 0x00) // 0x00 = Success
                        return false;
                }
                else if (resp[1] != 0x00) // 0x00 = No Auth, other = rejected
                {
                    return false;
                }

                // 2. Send Connect Command: VER=5, CMD=1 (CONNECT), RSV=0, ATYP=3 (DomainName)
                byte[] hostBytes = Encoding.ASCII.GetBytes(targetHost);
                byte[] cmd = new byte[4 + 1 + hostBytes.Length + 2];
                cmd[0] = 0x05;
                cmd[1] = 0x01;
                cmd[2] = 0x00;
                cmd[3] = 0x03; // Domain name
                cmd[4] = (byte)hostBytes.Length;
                Buffer.BlockCopy(hostBytes, 0, cmd, 5, hostBytes.Length);
                cmd[5 + hostBytes.Length] = (byte)((targetPort >> 8) & 0xFF);
                cmd[6 + hostBytes.Length] = (byte)(targetPort & 0xFF);

                await stream.WriteAsync(cmd, 0, cmd.Length, ct).ConfigureAwait(false);

                byte[] cmdResp = new byte[4];
                int cr = await ReadExactAsync(stream, cmdResp, 0, 4, ct).ConfigureAwait(false);
                if (cr < 4 || cmdResp[1] != 0x00) // 0x00 = Succeeded
                    return false;

                // Skip bind address and port
                byte atyp = cmdResp[3];
                if (atyp == 0x01) { byte[] ip4 = new byte[6]; await ReadExactAsync(stream, ip4, 0, 6, ct).ConfigureAwait(false); }
                else if (atyp == 0x04) { byte[] ip6 = new byte[18]; await ReadExactAsync(stream, ip6, 0, 18, ct).ConfigureAwait(false); }
                else if (atyp == 0x03)
                { 
                    byte[] lenBuf = new byte[1];
                    await ReadExactAsync(stream, lenBuf, 0, 1, ct).ConfigureAwait(false);
                    byte[] domainPort = new byte[lenBuf[0] + 2];
                    await ReadExactAsync(stream, domainPort, 0, domainPort.Length, ct).ConfigureAwait(false);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task PipeStreamAsync(Stream from, Stream to, CancellationToken ct)
        {
            byte[] buffer = new byte[16384];
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    int read = await from.ReadAsync(buffer, 0, buffer.Length, ct).ConfigureAwait(false);
                    if (read <= 0)
                        break;
                    await to.WriteAsync(buffer, 0, read, ct).ConfigureAwait(false);
                }
            }
            catch
            {
                // Stream closed or broken pipe
            }
        }

        private static async Task<int> ReadWithTimeoutAsync(Stream stream, byte[] buffer, int offset, int count, int timeoutMs, CancellationToken ct)
        {
            var readTask = stream.ReadAsync(buffer, offset, count, ct);
            var timeoutTask = Task.Delay(timeoutMs, ct);
            var completedTask = await Task.WhenAny(readTask, timeoutTask).ConfigureAwait(false);
            if (completedTask == readTask)
            {
                return await readTask.ConfigureAwait(false);
            }
            else
            {
                try { stream.Close(); } catch { }
                return 0;
            }
        }

        private static async Task<int> ReadExactAsync(Stream stream, byte[] buffer, int offset, int count, CancellationToken ct)
        {
            int total = 0;
            while (total < count)
            {
                int read = await stream.ReadAsync(buffer, offset + total, count - total, ct).ConfigureAwait(false);
                if (read <= 0)
                    return total;
                total += read;
            }
            return total;
        }

        public void Stop()
        {
            if (!IsRunning)
                return;

            IsRunning = false;
            try { if (_cts != null) _cts.Cancel(); } catch { }
            try { if (_listener != null) _listener.Stop(); } catch { }

            foreach (var kvp in _activeClients)
            {
                try { kvp.Value.Close(); } catch { }
            }
            _activeClients.Clear();
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            _disposed = true;
            Stop();
            try { if (_cts != null) _cts.Dispose(); } catch { }
        }
    }
}