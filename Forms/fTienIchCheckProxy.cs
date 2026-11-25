using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTienIchCheckProxy : Form
{
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    // Components for backward compatibility
    internal IContainer icontainer_0 = null;
    internal BunifuCards bunifuCards1;
    internal Panel panel1;
    internal BunifuDragControl E3097E31;
    internal BunifuCards bunifuCards2;
    internal Panel D53B2539;
    internal Button button2;
    internal PictureBox C49297B2;
    internal Button btnMinimize;
    internal BunifuCustomLabel B13A1A24;
    internal Button CA205410; // btnStart
    internal RichTextBox txtInput;
    internal GroupBox AD34CE20; // grLive
    internal RichTextBox F12E0690; // txtLive
    internal GroupBox groupBox1; // grInput
    internal GroupBox grChuaTao; // grDie
    internal RichTextBox txtChuaTao; // txtDie
    internal Label lblStatus;
    internal ComboBox cbbTypeProxy;
    internal Label label3;

    // Advanced VIP Controls
    private NumericUpDown nudThreads;
    private NumericUpDown nudTimeout;
    private CheckBox chkCheckGeo;
    private Button btnStop;
    private Button btnFilterBadProxy;
    private Button btnClearInput;
    private Button btnPasteInput;

    private Button btnCopyLive;
    private Button btnCopyPublicIp;
    private Button btnExportTxt;
    private Button btnClearResults;

    private Label lblStatTotal;
    private Label lblStatLive;
    private Label lblStatDie;
    private Label lblStatPing;
    private ProgressBar progressBar1;

    private TabControl tabControlResults;
    private TabPage tabGrid;
    private TabPage tabLive;
    private TabPage tabDie;
    private DataGridView dgvResults;

    // Concurrency control
    private CancellationTokenSource _cts = null;
    private volatile bool _isChecking = false;
    private int _totalCount = 0;
    private int _processedCount = 0;
    private int _liveCount = 0;
    private int _dieCount = 0;
    private long _totalPing = 0;
    private int _pingCount = 0;

    public fTienIchCheckProxy()
    {
        InitializeComponent();
        try
        {
            Language.CD21F0A9(this);
        }
        catch { }
    }

    private void Header_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }

    private void fTienIchCheckProxy_Load(object sender, EventArgs e)
    {
        if (cbbTypeProxy.Items.Count > 0 && cbbTypeProxy.SelectedIndex < 0)
        {
            cbbTypeProxy.SelectedIndex = 0;
        }
        UpdateInputCount();
    }

    private void UpdateInputCount()
    {
        try
        {
            var lines = txtInput.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            groupBox1.Text = $"Nhập Proxy ({lines.Count})";
        }
        catch { }
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
        UpdateInputCount();
    }

    private void btnClearInput_Click(object sender, EventArgs e)
    {
        if (txtInput.TextLength > 0)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ danh sách proxy đang nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtInput.Clear();
                UpdateInputCount();
            }
        }
    }

    private void btnPasteInput_Click(object sender, EventArgs e)
    {
        try
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (txtInput.TextLength > 0 && !txtInput.Text.EndsWith("\n"))
                    {
                        txtInput.AppendText("\r\n");
                    }
                    txtInput.AppendText(text);
                    UpdateInputCount();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể dán từ Clipboard: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private async void CA205410_Click(object sender, EventArgs e)
    {
        if (_isChecking) return;

        var rawLines = txtInput.Lines
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToList();

        if (rawLines.Count == 0)
        {
            MessageBox.Show("Vui lòng nhập ít nhất một proxy vào danh sách để kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtInput.Focus();
            return;
        }

        // Reset state
        _isChecking = true;
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        CA205410.Enabled = false;
        btnStop.Enabled = true;
        txtInput.ReadOnly = true;

        _totalCount = rawLines.Count;
        _processedCount = 0;
        _liveCount = 0;
        _dieCount = 0;
        _totalPing = 0;
        _pingCount = 0;

        dgvResults.Rows.Clear();
        F12E0690.Clear();
        txtChuaTao.Clear();
        AD34CE20.Text = "LIVE (0)";
        grChuaTao.Text = "DIE (0)";

        progressBar1.Maximum = _totalCount;
        progressBar1.Value = 0;
        progressBar1.Visible = true;
        lblStatus.Visible = true;
        lblStatus.Text = $"Đang chuẩn bị kiểm tra {_totalCount} proxy...";

        UpdateStatsDisplay();

        int threadCount = (int)nudThreads.Value;
        int timeoutSec = (int)nudTimeout.Value;
        int selectedTypeIndex = cbbTypeProxy.SelectedIndex;
        bool checkGeo = chkCheckGeo.Checked;

        // Default type mapping:
        // 0: Auto detect
        // 1: HTTP / HTTPS (0)
        // 2: SOCKS5 (1)
        // 3: SOCKS4 (2)
        int defaultType = 0;
        if (selectedTypeIndex == 2) defaultType = 1;
        else if (selectedTypeIndex == 3) defaultType = 2;

        var liveList = new ConcurrentBag<string>();
        var dieList = new ConcurrentBag<string>();

        try
        {
            using (var semaphore = new SemaphoreSlim(threadCount, threadCount))
            {
                var tasks = new List<Task>();

                for (int i = 0; i < rawLines.Count; i++)
                {
                    if (token.IsCancellationRequested) break;

                    int stt = i + 1;
                    string rawProxy = rawLines[i];

                    await semaphore.WaitAsync(token);

                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            if (token.IsCancellationRequested) return;

                            ProxyCheckDetail detail = ProxyHelper.CheckProxyDetail(rawProxy, defaultType, timeoutSec);

                            // Optional GEO lookup if live
                            if (detail.IsLive && checkGeo && !string.IsNullOrEmpty(detail.PublicIp) && string.IsNullOrEmpty(detail.Country))
                            {
                                var geo = ProxyHelper.GetGeoInfo(detail.PublicIp);
                                detail.Country = geo.country;
                                detail.Isp = geo.isp;
                            }

                            // Update counters thread-safely
                            Interlocked.Increment(ref _processedCount);
                            if (detail.IsLive)
                            {
                                Interlocked.Increment(ref _liveCount);
                                if (detail.PingMs > 0)
                                {
                                    Interlocked.Add(ref _totalPing, detail.PingMs);
                                    Interlocked.Increment(ref _pingCount);
                                }
                                liveList.Add(detail.CleanProxy);
                            }
                            else
                            {
                                Interlocked.Increment(ref _dieCount);
                                dieList.Add(rawProxy);
                            }

                            // Dispatch update to UI
                            if (!this.IsDisposed && this.IsHandleCreated)
                            {
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    try
                                    {
                                        AddResultRow(stt, detail);
                                        UpdateStatsDisplay();
                                    }
                                    catch { }
                                });
                            }
                        }
                        catch
                        {
                            Interlocked.Increment(ref _processedCount);
                            Interlocked.Increment(ref _dieCount);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }, token));
                }

                await Task.WhenAll(tasks);
            }
        }
        catch (OperationCanceledException)
        {
            lblStatus.Text = "Đã dừng kiểm tra theo yêu cầu người dùng.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Lỗi trong quá trình kiểm tra: " + ex.Message;
        }
        finally
        {
            _isChecking = false;
            CA205410.Enabled = true;
            btnStop.Enabled = false;
            txtInput.ReadOnly = false;
            progressBar1.Value = progressBar1.Maximum;

            // Fill tabs
            F12E0690.Text = string.Join("\r\n", liveList);
            txtChuaTao.Text = string.Join("\r\n", dieList);
            AD34CE20.Text = $"LIVE ({_liveCount})";
            grChuaTao.Text = $"DIE ({_dieCount})";

            string finishMsg = $"Kiểm tra hoàn tất: {_liveCount} LIVE, {_dieCount} DIE trên tổng số {_totalCount} proxy.";
            lblStatus.Text = finishMsg;

            if (_cts != null && !_cts.IsCancellationRequested)
            {
                MessageBox.Show(finishMsg, "Proxy Hub VIP - Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            btnStop.Enabled = false;
            lblStatus.Text = "Đang dừng các luồng...";
        }
    }

    private void AddResultRow(int stt, ProxyCheckDetail detail)
    {
        int rowIndex = dgvResults.Rows.Add();
        var row = dgvResults.Rows[rowIndex];

        row.Cells["colStt"].Value = stt;
        row.Cells["colProxy"].Value = detail.CleanProxy;
        row.Cells["colType"].Value = detail.ProxyTypeStr;

        var statusCell = row.Cells["colStatus"];
        statusCell.Value = detail.IsLive ? "LIVE" : "DIE";
        statusCell.Style.Font = new Font(dgvResults.Font.FontFamily, 9f, FontStyle.Bold);
        statusCell.Style.ForeColor = detail.IsLive ? Color.FromArgb(0, 150, 36) : Color.FromArgb(211, 47, 47);

        row.Cells["colPublicIp"].Value = string.IsNullOrEmpty(detail.PublicIp) ? "-" : detail.PublicIp;

        string geoStr = "";
        if (!string.IsNullOrEmpty(detail.Country))
        {
            geoStr = detail.Country;
            if (!string.IsNullOrEmpty(detail.Isp)) geoStr += " (" + detail.Isp + ")";
        }
        row.Cells["colGeo"].Value = string.IsNullOrEmpty(geoStr) ? "-" : geoStr;

        row.Cells["colPing"].Value = detail.PingMs > 0 ? $"{detail.PingMs} ms" : "-";
        row.Cells["colNote"].Value = detail.IsLive ? "Kết nối tốt" : (string.IsNullOrEmpty(detail.ErrorMessage) ? "Timeout" : detail.ErrorMessage);

        if (detail.IsLive)
        {
            row.DefaultCellStyle.BackColor = Color.FromArgb(246, 255, 246);
        }
        else
        {
            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 248);
        }
    }

    private void UpdateStatsDisplay()
    {
        lblStatTotal.Text = _totalCount.ToString("N0");
        lblStatLive.Text = _liveCount.ToString("N0");
        lblStatDie.Text = _dieCount.ToString("N0");

        long avgPing = _pingCount > 0 ? (_totalPing / _pingCount) : 0;
        lblStatPing.Text = avgPing > 0 ? $"{avgPing} ms" : "0 ms";

        if (progressBar1.Maximum > 0)
        {
            progressBar1.Value = Math.Min(_processedCount, progressBar1.Maximum);
        }

        lblStatus.Text = $"Tiến độ: {_processedCount}/{_totalCount} ({(_totalCount > 0 ? (_processedCount * 100 / _totalCount) : 0)}%) | Live: {_liveCount} | Die: {_dieCount}";
    }

    private void btnCopyLive_Click(object sender, EventArgs e)
    {
        var liveList = F12E0690.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).Distinct().ToList();
        if (liveList.Count == 0)
        {
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (row.Cells["colStatus"].Value?.ToString() == "LIVE")
                {
                    string p = row.Cells["colProxy"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(p)) liveList.Add(p);
                }
            }
        }

        if (liveList.Count == 0)
        {
            MessageBox.Show("Không có proxy LIVE nào để sao chép!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            Clipboard.SetText(string.Join("\r\n", liveList));
            MessageBox.Show($"Đã sao chép {liveList.Count} proxy LIVE vào bộ nhớ tạm (Clipboard)!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi sao chép: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCopyPublicIp_Click(object sender, EventArgs e)
    {
        var ipList = new HashSet<string>();
        foreach (DataGridViewRow row in dgvResults.Rows)
        {
            if (row.Cells["colStatus"].Value?.ToString() == "LIVE")
            {
                string ip = row.Cells["colPublicIp"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(ip) && ip != "-")
                {
                    ipList.Add(ip);
                }
            }
        }

        if (ipList.Count == 0)
        {
            MessageBox.Show("Không tìm thấy IP Public hợp lệ nào từ danh sách proxy LIVE!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            Clipboard.SetText(string.Join("\r\n", ipList));
            MessageBox.Show($"Đã sao chép {ipList.Count} IP Public duy nhất vào Clipboard!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi sao chép IP: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnFilterBadProxy_Click(object sender, EventArgs e)
    {
        var liveList = F12E0690.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).Distinct().ToList();
        if (liveList.Count == 0)
        {
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (row.Cells["colStatus"].Value?.ToString() == "LIVE")
                {
                    string p = row.Cells["colProxy"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(p)) liveList.Add(p);
                }
            }
        }

        int currentInputCount = txtInput.Lines.Count(l => !string.IsNullOrWhiteSpace(l));

        if (liveList.Count == 0)
        {
            if (currentInputCount == 0)
            {
                MessageBox.Show("Danh sách nhập đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialog = MessageBox.Show("Không có proxy LIVE nào trong kết quả kiểm tra gần nhất.\nBạn có muốn XÓA TOÀN BỘ proxy lỗi khỏi danh sách nhập?", "Xác nhận lọc", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                txtInput.Clear();
                UpdateInputCount();
                MessageBox.Show("Đã làm sạch danh sách nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }

        txtInput.Text = string.Join("\r\n", liveList);
        UpdateInputCount();
        int removedCount = Math.Max(0, currentInputCount - liveList.Count);
        MessageBox.Show($"Đã lọc proxy thành công!\n- Giữ lại: {liveList.Count} proxy LIVE\n- Đã loại bỏ: {removedCount} proxy lỗi/chết.", "Lọc Hoàn Tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnExportTxt_Click(object sender, EventArgs e)
    {
        if (dgvResults.Rows.Count == 0 && F12E0690.TextLength == 0)
        {
            MessageBox.Show("Chưa có kết quả nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using (var sfd = new SaveFileDialog())
        {
            sfd.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp CSV Excel (*.csv)|*.csv";
            sfd.FileName = $"LushCare_ProxyCheck_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();
                    if (sfd.FilterIndex == 2 || sfd.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        sb.AppendLine("STT,Proxy,Loai,TrangThai,IP_Public,QuocGia_ISP,Ping_ms,GhiChu");
                        foreach (DataGridViewRow r in dgvResults.Rows)
                        {
                            string cStt = Convert.ToString(r.Cells["colStt"].Value);
                            string cProxy = Convert.ToString(r.Cells["colProxy"].Value);
                            string cType = Convert.ToString(r.Cells["colType"].Value);
                            string cStatus = Convert.ToString(r.Cells["colStatus"].Value);
                            string cIp = Convert.ToString(r.Cells["colPublicIp"].Value);
                            string cGeo = Convert.ToString(r.Cells["colGeo"].Value);
                            string cPing = Convert.ToString(r.Cells["colPing"].Value);
                            string cNote = Convert.ToString(r.Cells["colNote"].Value);
                            sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"", cStt, cProxy, cType, cStatus, cIp, cGeo, cPing, cNote));
                        }
                    }
                    else
                    {
                        sb.AppendLine("# BÁO CÁO KIỂM TRA PROXY HUB VIP - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                        sb.AppendLine("# Tổng số: " + _totalCount + " | LIVE: " + _liveCount + " | DIE: " + _dieCount);
                        sb.AppendLine(new string('-', 60));
                        sb.AppendLine("[DANH SÁCH PROXY LIVE]");
                        foreach (var line in F12E0690.Lines)
                        {
                            if (!string.IsNullOrWhiteSpace(line)) sb.AppendLine(line);
                        }
                        sb.AppendLine();
                        sb.AppendLine(new string('-', 60));
                        sb.AppendLine("[CHI TIẾT KIỂM TRA ĐẦY ĐỦ]");
                        foreach (DataGridViewRow r in dgvResults.Rows)
                        {
                            string cStt = Convert.ToString(r.Cells["colStt"].Value);
                            string cProxy = Convert.ToString(r.Cells["colProxy"].Value);
                            string cStatus = Convert.ToString(r.Cells["colStatus"].Value);
                            string cIp = Convert.ToString(r.Cells["colPublicIp"].Value);
                            string cGeo = Convert.ToString(r.Cells["colGeo"].Value);
                            string cPing = Convert.ToString(r.Cells["colPing"].Value);
                            sb.AppendLine(cStt + "\t" + cProxy + "\t" + cStatus + "\tIP:" + cIp + "\tGeo:" + cGeo + "\tPing:" + cPing);
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Đã xuất báo cáo proxy thành công!", "Xuất File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void btnClearResults_Click(object sender, EventArgs e)
    {
        if (dgvResults.Rows.Count > 0 || F12E0690.TextLength > 0 || txtChuaTao.TextLength > 0)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa sạch toàn bộ kết quả kiểm tra hiện tại?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvResults.Rows.Clear();
                F12E0690.Clear();
                txtChuaTao.Clear();
                _totalCount = 0;
                _processedCount = 0;
                _liveCount = 0;
                _dieCount = 0;
                _totalPing = 0;
                _pingCount = 0;
                UpdateStatsDisplay();
                progressBar1.Value = 0;
                lblStatus.Text = "Đã làm sạch kết quả.";
                AD34CE20.Text = "LIVE (0)";
                grChuaTao.Text = "DIE (0)";
            }
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (_isChecking)
        {
            var dr = MessageBox.Show("Tiến trình kiểm tra đang chạy. Bạn có chắc muốn dừng và thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;
            if (_cts != null) _cts.Cancel();
        }
        Close();
    }

    private void btnMinimize_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_cts != null)
            {
                try { _cts.Cancel(); _cts.Dispose(); } catch { }
            }
            if (icontainer_0 != null)
            {
                icontainer_0.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.icontainer_0 = new Container();

        // Main Panels
        this.panel1 = new Panel();
        this.bunifuCards1 = new BunifuCards();
        this.bunifuCards2 = new BunifuCards();
        this.D53B2539 = new Panel();
        this.button2 = new Button();
        this.btnMinimize = new Button();
        this.C49297B2 = new PictureBox();
        this.B13A1A24 = new BunifuCustomLabel();
        this.E3097E31 = new BunifuDragControl(this.icontainer_0);

        // Sub Panels
        var pnlLeft = new Panel();
        var pnlRight = new Panel();
        var pnlStats = new Panel();
        var pnlActions = new Panel();
        var pnlSettings = new Panel();

        // Left Controls
        this.groupBox1 = new GroupBox();
        this.txtInput = new RichTextBox();
        this.label3 = new Label();
        this.cbbTypeProxy = new ComboBox();
        this.CA205410 = new Button();
        this.btnStop = new Button();
        this.btnFilterBadProxy = new Button();
        this.btnClearInput = new Button();
        this.btnPasteInput = new Button();

        this.nudThreads = new NumericUpDown();
        this.nudTimeout = new NumericUpDown();
        this.chkCheckGeo = new CheckBox();

        // Right Controls
        this.lblStatTotal = new Label();
        this.lblStatLive = new Label();
        this.lblStatDie = new Label();
        this.lblStatPing = new Label();
        this.progressBar1 = new ProgressBar();
        this.lblStatus = new Label();

        this.btnCopyLive = new Button();
        this.btnCopyPublicIp = new Button();
        this.btnExportTxt = new Button();
        this.btnClearResults = new Button();

        this.tabControlResults = new TabControl();
        this.tabGrid = new TabPage();
        this.tabLive = new TabPage();
        this.tabDie = new TabPage();

        this.dgvResults = new DataGridView();
        this.AD34CE20 = new GroupBox();
        this.F12E0690 = new RichTextBox();
        this.grChuaTao = new GroupBox();
        this.txtChuaTao = new RichTextBox();

        this.SuspendLayout();

        // 
        // bunifuCards1 (dummy for compatibility)
        // 
        this.bunifuCards1.Location = new Point(0, 0);
        this.bunifuCards1.Size = new Size(0, 0);
        this.bunifuCards1.Visible = false;

        // 
        // Form Config
        // 
        this.AutoScaleMode = AutoScaleMode.None;
        this.ClientSize = new Size(1100, 680);
        this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "fTienIchCheckProxy";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Proxy Hub VIP - LushCare Global";
        this.Load += new EventHandler(this.fTienIchCheckProxy_Load);

        // 
        // Main Container panel1
        // 
        this.panel1.Dock = DockStyle.Fill;
        this.panel1.BackColor = Color.FromArgb(245, 247, 250);
        this.panel1.BorderStyle = BorderStyle.FixedSingle;

        // 
        // Header bunifuCards2 & D53B2539
        // 
        this.bunifuCards2.Dock = DockStyle.Top;
        this.bunifuCards2.Height = 40;
        this.bunifuCards2.BackColor = Color.FromArgb(30, 32, 44);
        this.bunifuCards2.BorderRadius = 0;
        this.bunifuCards2.ShadowDepth = 10;

        this.D53B2539.Dock = DockStyle.Fill;
        this.D53B2539.BackColor = Color.FromArgb(30, 32, 44);
        this.D53B2539.MouseDown += new MouseEventHandler(this.Header_MouseDown);

        this.C49297B2.Location = new Point(8, 7);
        this.C49297B2.Size = new Size(26, 26);
        this.C49297B2.SizeMode = PictureBoxSizeMode.Zoom;
        try { this.C49297B2.Image = Class155.DD225F0D; } catch { }

        this.B13A1A24.Location = new Point(40, 0);
        this.B13A1A24.Size = new Size(950, 40);
        this.B13A1A24.Font = new Font("Tahoma", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
        this.B13A1A24.ForeColor = Color.White;
        this.B13A1A24.TextAlign = ContentAlignment.MiddleLeft;
        this.B13A1A24.Text = "⚡ PROXY HUB VIP - KIỂM TRA ĐA LUỒNG & BÓC TÁCH IP / GEO / LATENCY";
        this.B13A1A24.MouseDown += new MouseEventHandler(this.Header_MouseDown);

        this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.btnMinimize.Location = new Point(1020, 4);
        this.btnMinimize.Size = new Size(32, 32);
        this.btnMinimize.FlatStyle = FlatStyle.Flat;
        this.btnMinimize.FlatAppearance.BorderSize = 0;
        this.btnMinimize.Font = new Font("Tahoma", 11f, FontStyle.Bold);
        this.btnMinimize.ForeColor = Color.Silver;
        this.btnMinimize.Text = "—";
        this.btnMinimize.UseVisualStyleBackColor = false;
        this.btnMinimize.Click += new EventHandler(this.btnMinimize_Click);

        this.button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.button2.Location = new Point(1056, 4);
        this.button2.Size = new Size(32, 32);
        this.button2.FlatStyle = FlatStyle.Flat;
        this.button2.FlatAppearance.BorderSize = 0;
        this.button2.Font = new Font("Tahoma", 11f, FontStyle.Bold);
        this.button2.ForeColor = Color.Silver;
        this.button2.Text = "✕";
        this.button2.UseVisualStyleBackColor = false;
        this.button2.Click += new EventHandler(this.button2_Click);

        this.D53B2539.Controls.Add(this.C49297B2);
        this.D53B2539.Controls.Add(this.B13A1A24);
        this.D53B2539.Controls.Add(this.btnMinimize);
        this.D53B2539.Controls.Add(this.button2);
        this.bunifuCards2.Controls.Add(this.D53B2539);

        // 
        // Left Panel (Input & Config)
        // 
        pnlLeft.Dock = DockStyle.Left;
        pnlLeft.Width = 350;
        pnlLeft.Padding = new Padding(10, 8, 5, 8);
        pnlLeft.BackColor = Color.White;

        // GroupBox Input
        this.groupBox1.Dock = DockStyle.Fill;
        this.groupBox1.Text = "Nhập Proxy (0)";
        this.groupBox1.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.groupBox1.ForeColor = Color.FromArgb(40, 40, 40);

        this.txtInput.Dock = DockStyle.Fill;
        this.txtInput.Font = new Font("Consolas", 9.5f, FontStyle.Regular);
        this.txtInput.BackColor = Color.FromArgb(250, 252, 255);
        this.txtInput.BorderStyle = BorderStyle.FixedSingle;
        this.txtInput.WordWrap = false;
        this.txtInput.TextChanged += new EventHandler(this.txtInput_TextChanged);

        // Bottom toolbar under txtInput
        var pnlInputBtns = new Panel { Dock = DockStyle.Bottom, Height = 32, Padding = new Padding(0, 4, 0, 0) };
        this.btnClearInput.Dock = DockStyle.Right;
        this.btnClearInput.Width = 100;
        this.btnClearInput.Text = "🗑 Xóa trắng";
        this.btnClearInput.Font = new Font("Tahoma", 8.5f);
        this.btnClearInput.FlatStyle = FlatStyle.Flat;
        this.btnClearInput.FlatAppearance.BorderColor = Color.LightGray;
        this.btnClearInput.Click += new EventHandler(this.btnClearInput_Click);

        this.btnPasteInput.Dock = DockStyle.Left;
        this.btnPasteInput.Width = 120;
        this.btnPasteInput.Text = "📋 Dán Clipboard";
        this.btnPasteInput.Font = new Font("Tahoma", 8.5f);
        this.btnPasteInput.FlatStyle = FlatStyle.Flat;
        this.btnPasteInput.FlatAppearance.BorderColor = Color.LightGray;
        this.btnPasteInput.Click += new EventHandler(this.btnPasteInput_Click);

        pnlInputBtns.Controls.Add(this.btnClearInput);
        pnlInputBtns.Controls.Add(this.btnPasteInput);

        this.groupBox1.Controls.Add(this.txtInput);
        this.groupBox1.Controls.Add(pnlInputBtns);

        // Settings Panel
        pnlSettings.Dock = DockStyle.Bottom;
        pnlSettings.Height = 230;
        pnlSettings.Padding = new Padding(0, 8, 0, 0);

        var gbConfig = new GroupBox
        {
            Dock = DockStyle.Fill,
            Text = "Cấu hình Kiểm tra",
            Font = new Font("Tahoma", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(40, 40, 40)
        };

        this.label3.Location = new Point(12, 25);
        this.label3.Size = new Size(85, 20);
        this.label3.Text = "Loại Proxy:";
        this.label3.Font = new Font("Tahoma", 9f, FontStyle.Regular);

        this.cbbTypeProxy.Location = new Point(105, 22);
        this.cbbTypeProxy.Size = new Size(220, 24);
        this.cbbTypeProxy.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cbbTypeProxy.Font = new Font("Tahoma", 9f, FontStyle.Regular);
        this.cbbTypeProxy.Items.AddRange(new object[] {
            "⚡ Tự động nhận diện (Auto)",
            "🌐 HTTP / HTTPS",
            "🛡️ SOCKS5",
            "🛡️ SOCKS4"
        });
        this.cbbTypeProxy.SelectedIndex = 0;

        var lblThreads = new Label { Location = new Point(12, 57), Size = new Size(85, 20), Text = "Số luồng:", Font = new Font("Tahoma", 9f, FontStyle.Regular) };
        this.nudThreads.Location = new Point(105, 54);
        this.nudThreads.Size = new Size(70, 22);
        this.nudThreads.Minimum = 1;
        this.nudThreads.Maximum = 150;
        this.nudThreads.Value = 30;

        var lblTimeout = new Label { Location = new Point(190, 57), Size = new Size(60, 20), Text = "Timeout:", Font = new Font("Tahoma", 9f, FontStyle.Regular) };
        this.nudTimeout.Location = new Point(255, 54);
        this.nudTimeout.Size = new Size(70, 22);
        this.nudTimeout.Minimum = 1;
        this.nudTimeout.Maximum = 30;
        this.nudTimeout.Value = 5;

        this.chkCheckGeo.Location = new Point(15, 86);
        this.chkCheckGeo.Size = new Size(310, 22);
        this.chkCheckGeo.Text = "Tra cứu Quốc gia & Nhà mạng ISP (ip-api)";
        this.chkCheckGeo.Font = new Font("Tahoma", 9f, FontStyle.Regular);
        this.chkCheckGeo.Checked = true;

        // Big Action Buttons
        this.CA205410.Location = new Point(12, 118);
        this.CA205410.Size = new Size(190, 42);
        this.CA205410.Text = "▶ BẮT ĐẦU CHECK";
        this.CA205410.Font = new Font("Tahoma", 10f, FontStyle.Bold);
        this.CA205410.BackColor = Color.FromArgb(16, 124, 65);
        this.CA205410.ForeColor = Color.White;
        this.CA205410.FlatStyle = FlatStyle.Flat;
        this.CA205410.FlatAppearance.BorderSize = 0;
        this.CA205410.Cursor = Cursors.Hand;
        this.CA205410.Click += new EventHandler(this.CA205410_Click);

        this.btnStop.Location = new Point(210, 118);
        this.btnStop.Size = new Size(115, 42);
        this.btnStop.Text = "⏹ DỪNG";
        this.btnStop.Font = new Font("Tahoma", 10f, FontStyle.Bold);
        this.btnStop.BackColor = Color.FromArgb(198, 40, 40);
        this.btnStop.ForeColor = Color.White;
        this.btnStop.FlatStyle = FlatStyle.Flat;
        this.btnStop.FlatAppearance.BorderSize = 0;
        this.btnStop.Cursor = Cursors.Hand;
        this.btnStop.Enabled = false;
        this.btnStop.Click += new EventHandler(this.btnStop_Click);

        this.btnFilterBadProxy.Location = new Point(12, 170);
        this.btnFilterBadProxy.Size = new Size(313, 34);
        this.btnFilterBadProxy.Text = "🧹 Lọc bỏ proxy lỗi / chết khỏi ô nhập";
        this.btnFilterBadProxy.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.btnFilterBadProxy.BackColor = Color.FromArgb(238, 242, 246);
        this.btnFilterBadProxy.ForeColor = Color.FromArgb(30, 41, 59);
        this.btnFilterBadProxy.FlatStyle = FlatStyle.Flat;
        this.btnFilterBadProxy.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        this.btnFilterBadProxy.Cursor = Cursors.Hand;
        this.btnFilterBadProxy.Click += new EventHandler(this.btnFilterBadProxy_Click);

        gbConfig.Controls.Add(this.label3);
        gbConfig.Controls.Add(this.cbbTypeProxy);
        gbConfig.Controls.Add(lblThreads);
        gbConfig.Controls.Add(this.nudThreads);
        gbConfig.Controls.Add(lblTimeout);
        gbConfig.Controls.Add(this.nudTimeout);
        gbConfig.Controls.Add(this.chkCheckGeo);
        gbConfig.Controls.Add(this.CA205410);
        gbConfig.Controls.Add(this.btnStop);
        gbConfig.Controls.Add(this.btnFilterBadProxy);

        pnlSettings.Controls.Add(gbConfig);

        pnlLeft.Controls.Add(this.groupBox1);
        pnlLeft.Controls.Add(pnlSettings);

        // 
        // Right Panel (Results & Analytics)
        // 
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Padding = new Padding(5, 8, 10, 8);
        pnlRight.BackColor = Color.FromArgb(245, 247, 250);

        // Stats Panel (Top of Right Panel)
        pnlStats.Dock = DockStyle.Top;
        pnlStats.Height = 70;
        pnlStats.BackColor = Color.Transparent;

        int cardW = 175;
        pnlStats.Controls.Add(CreateStatCard("TỔNG PROXY", this.lblStatTotal, Color.FromArgb(33, 150, 243), 0, cardW));
        pnlStats.Controls.Add(CreateStatCard("PROXY LIVE", this.lblStatLive, Color.FromArgb(46, 125, 50), cardW + 10, cardW));
        pnlStats.Controls.Add(CreateStatCard("PROXY DIE", this.lblStatDie, Color.FromArgb(211, 47, 47), (cardW + 10) * 2, cardW));
        pnlStats.Controls.Add(CreateStatCard("PING TRUNG BÌNH", this.lblStatPing, Color.FromArgb(245, 124, 0), (cardW + 10) * 3, cardW));

        // Progress bar
        this.progressBar1.Dock = DockStyle.Top;
        this.progressBar1.Height = 5;
        this.progressBar1.ForeColor = Color.FromArgb(16, 124, 65);

        // Actions toolbar
        pnlActions.Dock = DockStyle.Top;
        pnlActions.Height = 44;
        pnlActions.Padding = new Padding(0, 6, 0, 6);

        this.btnCopyLive.Dock = DockStyle.Left;
        this.btnCopyLive.Width = 150;
        this.btnCopyLive.Text = "📋 Sao chép LIVE";
        this.btnCopyLive.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.btnCopyLive.BackColor = Color.FromArgb(232, 245, 233);
        this.btnCopyLive.ForeColor = Color.FromArgb(46, 125, 50);
        this.btnCopyLive.FlatStyle = FlatStyle.Flat;
        this.btnCopyLive.FlatAppearance.BorderColor = Color.FromArgb(165, 214, 167);
        this.btnCopyLive.Cursor = Cursors.Hand;
        this.btnCopyLive.Click += new EventHandler(this.btnCopyLive_Click);

        this.btnCopyPublicIp.Dock = DockStyle.Left;
        this.btnCopyPublicIp.Width = 150;
        this.btnCopyPublicIp.Text = "🌐 Sao chép IP Public";
        this.btnCopyPublicIp.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.btnCopyPublicIp.BackColor = Color.FromArgb(227, 242, 253);
        this.btnCopyPublicIp.ForeColor = Color.FromArgb(25, 118, 210);
        this.btnCopyPublicIp.FlatStyle = FlatStyle.Flat;
        this.btnCopyPublicIp.FlatAppearance.BorderColor = Color.FromArgb(144, 202, 249);
        this.btnCopyPublicIp.Cursor = Cursors.Hand;
        this.btnCopyPublicIp.Click += new EventHandler(this.btnCopyPublicIp_Click);

        this.btnExportTxt.Dock = DockStyle.Left;
        this.btnExportTxt.Width = 140;
        this.btnExportTxt.Text = "💾 Xuất File TXT/CSV";
        this.btnExportTxt.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.btnExportTxt.BackColor = Color.FromArgb(255, 243, 224);
        this.btnExportTxt.ForeColor = Color.FromArgb(230, 81, 0);
        this.btnExportTxt.FlatStyle = FlatStyle.Flat;
        this.btnExportTxt.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 128);
        this.btnExportTxt.Cursor = Cursors.Hand;
        this.btnExportTxt.Click += new EventHandler(this.btnExportTxt_Click);

        this.btnClearResults.Dock = DockStyle.Right;
        this.btnClearResults.Width = 120;
        this.btnClearResults.Text = "🔄 Xóa kết quả";
        this.btnClearResults.Font = new Font("Tahoma", 8.5f);
        this.btnClearResults.FlatStyle = FlatStyle.Flat;
        this.btnClearResults.FlatAppearance.BorderColor = Color.LightGray;
        this.btnClearResults.Cursor = Cursors.Hand;
        this.btnClearResults.Click += new EventHandler(this.btnClearResults_Click);

        pnlActions.Controls.Add(this.btnExportTxt);
        pnlActions.Controls.Add(this.btnCopyPublicIp);
        pnlActions.Controls.Add(this.btnCopyLive);
        pnlActions.Controls.Add(this.btnClearResults);

        // Status Label (Bottom of Right Panel)
        this.lblStatus.Dock = DockStyle.Bottom;
        this.lblStatus.Height = 24;
        this.lblStatus.Font = new Font("Tahoma", 9f, FontStyle.Regular);
        this.lblStatus.ForeColor = Color.FromArgb(70, 70, 70);
        this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        this.lblStatus.Text = "Sẵn sàng kiểm tra.";

        // TabControl
        this.tabControlResults.Dock = DockStyle.Fill;
        this.tabControlResults.Font = new Font("Tahoma", 9f, FontStyle.Regular);

        // Tab 1: Grid VIP
        this.tabGrid.Text = "📊 Bảng Chi Tiết VIP";
        this.tabGrid.BackColor = Color.White;
        this.tabGrid.Padding = new Padding(4);

        SetupDataGridView();
        this.tabGrid.Controls.Add(this.dgvResults);

        // Tab 2: Live Text
        this.tabLive.Text = "✅ Danh Sách LIVE (0)";
        this.tabLive.BackColor = Color.White;
        this.tabLive.Padding = new Padding(4);

        this.AD34CE20.Dock = DockStyle.Fill;
        this.AD34CE20.Text = "LIVE (0)";
        this.AD34CE20.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.AD34CE20.ForeColor = Color.FromArgb(46, 125, 50);

        this.F12E0690.Dock = DockStyle.Fill;
        this.F12E0690.Font = new Font("Consolas", 9.5f);
        this.F12E0690.BackColor = Color.FromArgb(248, 255, 248);
        this.F12E0690.BorderStyle = BorderStyle.FixedSingle;
        this.F12E0690.WordWrap = false;
        this.AD34CE20.Controls.Add(this.F12E0690);
        this.tabLive.Controls.Add(this.AD34CE20);

        // Tab 3: Die Text
        this.tabDie.Text = "❌ Danh Sách DIE (0)";
        this.tabDie.BackColor = Color.White;
        this.tabDie.Padding = new Padding(4);

        this.grChuaTao.Dock = DockStyle.Fill;
        this.grChuaTao.Text = "DIE (0)";
        this.grChuaTao.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        this.grChuaTao.ForeColor = Color.FromArgb(211, 47, 47);

        this.txtChuaTao.Dock = DockStyle.Fill;
        this.txtChuaTao.Font = new Font("Consolas", 9.5f);
        this.txtChuaTao.BackColor = Color.FromArgb(255, 248, 248);
        this.txtChuaTao.BorderStyle = BorderStyle.FixedSingle;
        this.txtChuaTao.WordWrap = false;
        this.grChuaTao.Controls.Add(this.txtChuaTao);
        this.tabDie.Controls.Add(this.grChuaTao);

        this.tabControlResults.TabPages.Add(this.tabGrid);
        this.tabControlResults.TabPages.Add(this.tabLive);
        this.tabControlResults.TabPages.Add(this.tabDie);

        pnlRight.Controls.Add(this.tabControlResults);
        pnlRight.Controls.Add(pnlActions);
        pnlRight.Controls.Add(this.progressBar1);
        pnlRight.Controls.Add(pnlStats);
        pnlRight.Controls.Add(this.lblStatus);

        // Assemble Form
        this.panel1.Controls.Add(pnlRight);
        this.panel1.Controls.Add(pnlLeft);
        this.panel1.Controls.Add(this.bunifuCards2);

        this.Controls.Add(this.panel1);
        this.Controls.Add(this.bunifuCards1);

        this.ResumeLayout(false);
    }

    private Panel CreateStatCard(string title, Label lblVal, Color accentColor, int left, int width)
    {
        var pnl = new Panel
        {
            Location = new Point(left, 2),
            Size = new Size(width, 62),
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };

        var pnlTopBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 3,
            BackColor = accentColor
        };

        var lblTitle = new Label
        {
            Location = new Point(8, 7),
            Size = new Size(width - 16, 16),
            Text = title,
            Font = new Font("Tahoma", 7.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(120, 120, 120)
        };

        lblVal.Location = new Point(8, 26);
        lblVal.Size = new Size(width - 16, 28);
        lblVal.Text = "0";
        lblVal.Font = new Font("Tahoma", 13f, FontStyle.Bold);
        lblVal.ForeColor = accentColor;

        pnl.Controls.Add(lblVal);
        pnl.Controls.Add(lblTitle);
        pnl.Controls.Add(pnlTopBar);

        return pnl;
    }

    private void SetupDataGridView()
    {
        this.dgvResults.Dock = DockStyle.Fill;
        this.dgvResults.BackgroundColor = Color.White;
        this.dgvResults.BorderStyle = BorderStyle.None;
        this.dgvResults.RowHeadersVisible = false;
        this.dgvResults.AllowUserToAddRows = false;
        this.dgvResults.AllowUserToDeleteRows = false;
        this.dgvResults.ReadOnly = true;
        this.dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvResults.MultiSelect = true;
        this.dgvResults.EnableHeadersVisualStyles = false;
        this.dgvResults.RowTemplate.Height = 26;

        this.dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
        this.dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
        this.dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
        this.dgvResults.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.dgvResults.ColumnHeadersHeight = 32;

        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStt", HeaderText = "#", Width = 40 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProxy", HeaderText = "Proxy Gốc / Đã Chuẩn Hóa", Width = 210 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Loại", Width = 75 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng thái", Width = 80 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPublicIp", HeaderText = "IP Public", Width = 125 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGeo", HeaderText = "Quốc gia & ISP", Width = 170 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPing", HeaderText = "Ping ms", Width = 70 });
        this.dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNote", HeaderText = "Chi tiết / Phản hồi", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

        this.dgvResults.Columns["colStt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.dgvResults.Columns["colType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.dgvResults.Columns["colStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.dgvResults.Columns["colPing"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }
}
