using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain - Quản lý & Tích hợp Bộ chuyển đổi Cookie đa định dạng (CookieVault).
/// Cung cấp menu chuột phải:
/// - Copy -> "Cookie (JSON)" (chuẩn EditThisCookie / Puppeteer / AdsPower)
/// - Copy -> "Cookie (Netscape)" (chuẩn curl / wget / antidetect)
/// - Tiện ích "Nạp Cookie đa định dạng" (tự chuẩn hóa Raw/JSON/Netscape/Base64 và lưu DB/giao diện).
/// </summary>
public partial class fMain
{
    private ToolStripMenuItem mnuCopyCookieJson;
    private ToolStripMenuItem mnuCopyCookieNetscape;
    private ToolStripMenuItem mnuImportCookieVault;

    /// <summary>
    /// Khởi tạo và tích hợp các tính năng CookieVault vào menu chuột phải ctmsAcc và copyToolStripMenuItem.
    /// </summary>
    public void SetupCookieVaultFeatures()
    {
        try
        {
            if (this.copyToolStripMenuItem == null && this.ctmsAcc == null)
                return;

            Image cookieIcon = this.cookieToolStripMenuItem != null ? this.cookieToolStripMenuItem.Image : null;

            // 1. Thêm 2 mục menu con vào copyToolStripMenuItem: Cookie (JSON) và Cookie (Netscape)
            if (this.copyToolStripMenuItem != null)
            {
                mnuCopyCookieJson = new ToolStripMenuItem
                {
                    Name = "mnuCopyCookieJson",
                    Text = "Cookie (JSON)",
                    Font = this.cookieToolStripMenuItem != null ? this.cookieToolStripMenuItem.Font : this.copyToolStripMenuItem.Font,
                    Image = cookieIcon,
                    ToolTipText = "Copy cookie các tài khoản đang chọn theo chuẩn JSON (EditThisCookie / Puppeteer / AdsPower / GoLogin)"
                };
                mnuCopyCookieJson.Click += (s, e) => CopySelectedCookiesToJson();

                mnuCopyCookieNetscape = new ToolStripMenuItem
                {
                    Name = "mnuCopyCookieNetscape",
                    Text = "Cookie (Netscape)",
                    Font = this.cookieToolStripMenuItem != null ? this.cookieToolStripMenuItem.Font : this.copyToolStripMenuItem.Font,
                    Image = cookieIcon,
                    ToolTipText = "Copy cookie các tài khoản đang chọn theo định dạng Netscape HTTP (curl / wget / antidetect)"
                };
                mnuCopyCookieNetscape.Click += (s, e) => CopySelectedCookiesToNetscape();

                // Chèn ngay sau mục "Cookie" nếu có
                int cookieIndex = this.cookieToolStripMenuItem != null ? this.copyToolStripMenuItem.DropDownItems.IndexOf(this.cookieToolStripMenuItem) : -1;
                if (cookieIndex >= 0)
                {
                    this.copyToolStripMenuItem.DropDownItems.Insert(cookieIndex + 1, mnuCopyCookieJson);
                    this.copyToolStripMenuItem.DropDownItems.Insert(cookieIndex + 2, mnuCopyCookieNetscape);
                }
                else
                {
                    this.copyToolStripMenuItem.DropDownItems.Add(mnuCopyCookieJson);
                    this.copyToolStripMenuItem.DropDownItems.Add(mnuCopyCookieNetscape);
                }
            }

            // 2. Thêm menu tiện ích "Nhập Cookie" vào ctmsAcc
            if (this.ctmsAcc != null)
            {
                mnuImportCookieVault = new ToolStripMenuItem
                {
                    Name = "mnuImportCookieVault",
                    Text = "Nhập Cookie",
                    Font = this.toolStripMenuItem_33 != null ? this.toolStripMenuItem_33.Font : this.Font,
                    Image = cookieIcon,
                    ShortcutKeys = Keys.Control | Keys.Shift | Keys.C,
                    ShowShortcutKeys = false,
                    ToolTipText = "Nạp Cookie đa định dạng (Raw, JSON, Netscape, Base64)"
                };
                mnuImportCookieVault.Click += (s, e) => ShowImportCookieVaultDialog();

                // Đặt ngay sau mục "Nhập Useragent" hoặc "Nhập Proxy"
                int insertIndex = this.toolStripMenuItem_33 != null ? this.ctmsAcc.Items.IndexOf(this.toolStripMenuItem_33) + 1 :
                                 (this.toolStripMenuItem_32 != null ? this.ctmsAcc.Items.IndexOf(this.toolStripMenuItem_32) + 1 : -1);

                if (insertIndex >= 0 && insertIndex <= this.ctmsAcc.Items.Count)
                {
                    this.ctmsAcc.Items.Insert(insertIndex, mnuImportCookieVault);
                }
                else
                {
                    this.ctmsAcc.Items.Add(mnuImportCookieVault);
                }
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("SetupCookieVaultFeatures error: " + ex.Message); } catch { }
        }
    }

    /// <summary>
    /// Copy Cookie của các nick đang chọn sang định dạng JSON (EditThisCookie/Puppeteer) và nạp vào Clipboard.
    /// </summary>
    private void CopySelectedCookiesToJson()
    {
        try
        {
            var selectedIndices = GetCookieVaultSelectedRowIndices();
            if (selectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hoặc tích chọn ít nhất một tài khoản để copy Cookie!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cookieLines = new List<string>();
            foreach (int idx in selectedIndices)
            {
                string rawCookie = F6061E95(idx, "cCookies");
                if (!string.IsNullOrWhiteSpace(rawCookie))
                {
                    cookieLines.Add(rawCookie);
                }
            }

            if (cookieLines.Count == 0)
            {
                MessageBox.Show("Các tài khoản được chọn không có Cookie!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string result;
            if (cookieLines.Count == 1)
            {
                // 1 tài khoản: xuất JSON định dạng đẹp (pretty) chuẩn EditThisCookie
                result = CookieVaultConverter.CookieToJson(cookieLines[0], ".facebook.com", pretty: true);
            }
            else
            {
                // Nhiều tài khoản: mỗi dòng là 1 JSON array thu gọn tương ứng 1 tài khoản
                var jsonRows = cookieLines.Select(c => CookieVaultConverter.CookieToJson(c, ".facebook.com", pretty: false));
                result = string.Join("\r\n", jsonRows);
            }

            Commom.SetTextToClipboard(result);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi copy Cookie JSON: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Copy Cookie của các nick đang chọn sang định dạng Netscape HTTP Cookie và nạp vào Clipboard.
    /// </summary>
    private void CopySelectedCookiesToNetscape()
    {
        try
        {
            var selectedIndices = GetCookieVaultSelectedRowIndices();
            if (selectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hoặc tích chọn ít nhất một tài khoản để copy Cookie!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var netscapeBlocks = new List<string>();
            foreach (int idx in selectedIndices)
            {
                string rawCookie = F6061E95(idx, "cCookies");
                if (!string.IsNullOrWhiteSpace(rawCookie))
                {
                    string uid = F6061E95(idx, "cUid");
                    string netscape = CookieVaultConverter.CookieToNetscape(rawCookie, ".facebook.com");
                    if (selectedIndices.Count > 1 && !string.IsNullOrWhiteSpace(uid))
                    {
                        netscapeBlocks.Add($"# Account UID: {uid}\r\n" + netscape);
                    }
                    else
                    {
                        netscapeBlocks.Add(netscape);
                    }
                }
            }

            if (netscapeBlocks.Count == 0)
            {
                MessageBox.Show("Các tài khoản được chọn không có Cookie!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string result = string.Join("\r\n\r\n", netscapeBlocks);
            Commom.SetTextToClipboard(result);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi copy Cookie Netscape: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Mở hộp thoại Nạp Cookie đa định dạng.
    /// </summary>
    private void ShowImportCookieVaultDialog()
    {
        try
        {
            var selectedIndices = GetCookieVaultSelectedRowIndices();
            using (var form = new fNapCookieMultiFormat(selectedIndices))
            {
                form.ShowDialog(this);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi mở giao diện Nạp Cookie: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Lấy danh sách chỉ số các dòng tài khoản đang được chọn/tích trên DataGridView.
    /// </summary>
    private List<int> GetCookieVaultSelectedRowIndices()
    {
        var list = new List<int>();
        try
        {
            if (this.F5325785 == null) return list;

            // Kiểm tra các dòng được tích checkbox cChose
            for (int i = 0; i < this.F5325785.RowCount; i++)
            {
                if (Convert.ToBoolean(this.F5325785.Rows[i].Cells["cChose"].Value))
                {
                    list.Add(i);
                }
            }

            // Nếu chưa tích checkbox nào, lấy các dòng đang bôi đen bằng chuột
            if (list.Count == 0 && this.F5325785.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.F5325785.SelectedRows)
                {
                    list.Add(row.Index);
                }
                list.Sort();
            }
        }
        catch { }

        return list;
    }
}

/// <summary>
/// Hộp thoại Nạp Cookie đa định dạng (Raw, JSON, Netscape, Base64).
/// Hỗ trợ dán trực tiếp, tự động nhận diện định dạng, kiểm tra tính hợp lệ và cập nhật vào CSDL & giao diện.
/// </summary>
public class fNapCookieMultiFormat : Form
{
    private List<int> _selectedIndices;

    private Panel pnlHeader;
    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblTargetAccounts;
    private TextBox txtCookies;
    private Panel pnlStatus;
    private Label lblFormatDetect;
    private Label lblCountDetect;
    private CheckBox chkMatchUid;
    private CheckBox chkUpdateUid;
    private CheckBox chkOverwrite;
    private Button btnPasteClipboard;
    private Button btnSave;
    private Button btnClose;

    public fNapCookieMultiFormat(List<int> selectedIndices)
    {
        _selectedIndices = selectedIndices ?? new List<int>();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "CookieVault - Nạp Cookie Đa Định Dạng";
        this.Size = new Size(680, 560);
        this.MinimumSize = new Size(600, 480);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(248, 250, 252);
        this.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
        this.ShowIcon = false;
        this.MaximizeBox = false;

        // Header Panel
        pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.White,
            Padding = new Padding(15, 10, 15, 10)
        };
        pnlHeader.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240)))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        };

        lblTitle = new Label
        {
            Text = "Nạp & Chuẩn Hóa Cookie Đa Định Dạng (CookieVault)",
            Font = new Font("Segoe UI", 11f, FontStyle.Bold),
            ForeColor = Color.FromArgb(15, 23, 42),
            Location = new Point(15, 10),
            AutoSize = true
        };

        lblSubtitle = new Label
        {
            Text = "Tự động nhận diện và chuyển đổi giữa Raw, JSON (Puppeteer/EditThisCookie), Netscape HTTP, Base64.",
            Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(16, 36),
            AutoSize = true
        };

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSubtitle);

        // Target Info
        int selectedCount = _selectedIndices.Count;
        string targetText = selectedCount > 0 
            ? $"Đang chọn: {selectedCount} tài khoản trên danh sách" 
            : "Chưa chọn tài khoản cụ thể (Sẽ tự động tìm tài khoản khớp UID)";

        lblTargetAccounts = new Label
        {
            Text = targetText,
            Font = new Font("Segoe UI", 9f, FontStyle.Bold),
            ForeColor = selectedCount > 0 ? Color.FromArgb(37, 99, 235) : Color.FromArgb(220, 38, 38),
            Location = new Point(18, 75),
            AutoSize = true
        };

        // Text area
        txtCookies = new TextBox
        {
            Multiline = true,
            ScrollBars = ScrollBars.Both,
            WordWrap = false,
            Font = new Font("Consolas", 9.5f, FontStyle.Regular),
            Location = new Point(18, 100),
            Size = new Size(628, 230),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.White,
            ForeColor = Color.FromArgb(15, 23, 42)
        };
        txtCookies.TextChanged += (s, e) => UpdateDetectionInfo();

        // Status Panel (Detection info bar)
        pnlStatus = new Panel
        {
            Location = new Point(18, 338),
            Size = new Size(628, 32),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.White
        };
        pnlStatus.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnlStatus.Width - 1, pnlStatus.Height - 1);
            }
        };

        lblFormatDetect = new Label
        {
            Text = "Định dạng nhận diện: Chưa có dữ liệu",
            Font = new Font("Segoe UI", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(37, 99, 235),
            Location = new Point(10, 7),
            AutoSize = true
        };

        lblCountDetect = new Label
        {
            Text = "Số cookie: 0",
            Font = new Font("Segoe UI", 9f, FontStyle.Regular),
            ForeColor = Color.FromArgb(51, 65, 85),
            Location = new Point(400, 7),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            AutoSize = true
        };

        pnlStatus.Controls.Add(lblFormatDetect);
        pnlStatus.Controls.Add(lblCountDetect);

        // Options
        chkMatchUid = new CheckBox
        {
            Text = "Khớp theo UID nếu cookie có UID (tự tìm đúng tài khoản trên danh sách)",
            Checked = true,
            Location = new Point(20, 380),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
            AutoSize = true,
            ForeColor = Color.FromArgb(30, 41, 59)
        };

        chkUpdateUid = new CheckBox
        {
            Text = "Tự động cập nhật cột UID nếu tài khoản đang trống UID",
            Checked = true,
            Location = new Point(20, 405),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
            AutoSize = true,
            ForeColor = Color.FromArgb(30, 41, 59)
        };

        chkOverwrite = new CheckBox
        {
            Text = "Ghi đè nếu tài khoản đã có Cookie sẵn",
            Checked = true,
            Location = new Point(20, 430),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
            AutoSize = true,
            ForeColor = Color.FromArgb(30, 41, 59)
        };

        // Buttons
        btnPasteClipboard = new Button
        {
            Text = "📋 Dán từ Clipboard",
            Size = new Size(150, 34),
            Location = new Point(20, 468),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(241, 245, 249),
            ForeColor = Color.FromArgb(30, 41, 59),
            Cursor = Cursors.Hand
        };
        btnPasteClipboard.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnPasteClipboard.Click += (s, e) => PasteFromClipboard();

        btnSave = new Button
        {
            Text = "💾 Xác nhận & Nạp Cookie",
            Size = new Size(185, 34),
            Location = new Point(340, 468),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += BtnSave_Click;

        btnClose = new Button
        {
            Text = "Đóng",
            Size = new Size(95, 34),
            Location = new Point(535, 468),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(241, 245, 249),
            ForeColor = Color.FromArgb(71, 85, 105),
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnClose.Click += (s, e) => this.Close();

        this.Controls.Add(pnlHeader);
        this.Controls.Add(lblTargetAccounts);
        this.Controls.Add(txtCookies);
        this.Controls.Add(pnlStatus);
        this.Controls.Add(chkMatchUid);
        this.Controls.Add(chkUpdateUid);
        this.Controls.Add(chkOverwrite);
        this.Controls.Add(btnPasteClipboard);
        this.Controls.Add(btnSave);
        this.Controls.Add(btnClose);

        this.Load += FNapCookieMultiFormat_Load;
    }

    private void FNapCookieMultiFormat_Load(object sender, EventArgs e)
    {
        try
        {
            // Kiểm tra nếu Clipboard có cookie thì tự động dán và hiển thị
            if (Clipboard.ContainsText())
            {
                string clip = Clipboard.GetText();
                if (!string.IsNullOrWhiteSpace(clip))
                {
                    string format = CookieVaultConverter.DetectFormat(clip);
                    if (format != "Trống" && format != "Không xác định")
                    {
                        txtCookies.Text = clip;
                    }
                }
            }
        }
        catch { }
    }

    private void PasteFromClipboard()
    {
        try
        {
            if (Clipboard.ContainsText())
            {
                txtCookies.Text = Clipboard.GetText();
            }
            else
            {
                MessageBox.Show("Clipboard hiện không có dữ liệu văn bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể đọc Clipboard: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateDetectionInfo()
    {
        try
        {
            string text = txtCookies.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                lblFormatDetect.Text = "Định dạng nhận diện: Chưa có dữ liệu";
                lblCountDetect.Text = "Số cookie: 0";
                return;
            }

            string format = CookieVaultConverter.DetectFormat(text);
            lblFormatDetect.Text = $"Định dạng nhận diện: {format}";

            var list = CookieVaultConverter.ParseMultipleCookies(text);
            int validFbCount = 0;
            foreach (var c in list)
            {
                var val = CookieVaultConverter.ValidateFacebookCookie(c);
                if (val.isValid) validFbCount++;
            }

            lblCountDetect.Text = $"Tổng: {list.Count} | Hợp lệ Facebook (c_user + xs): {validFbCount}";
        }
        catch
        {
            lblFormatDetect.Text = "Định dạng nhận diện: Đang phân tích...";
            lblCountDetect.Text = "";
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string text = txtCookies.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Vui lòng nhập hoặc dán cookie cần nạp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cookies = CookieVaultConverter.ParseMultipleCookies(text);
            if (cookies.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Cookie hợp lệ nào trong nội dung đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedIndices == null || _selectedIndices.Count == 0)
            {
                if (chkMatchUid.Checked)
                {
                    // Quét toàn bộ danh sách tài khoản nếu người dùng không chọn dòng cụ thể
                    _selectedIndices = new List<int>();
                    if (fMain.fMain_0 != null && fMain.fMain_0.F5325785 != null)
                    {
                        for (int i = 0; i < fMain.fMain_0.F5325785.RowCount; i++)
                        {
                            _selectedIndices.Add(i);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hoặc tích chọn ít nhất một tài khoản trên danh sách để nạp cookie!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int successCount = 0;
            var usedRows = new HashSet<int>();

            // 1. Nếu có tùy chọn khớp theo UID:
            if (chkMatchUid.Checked)
            {
                var uidToRowMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                foreach (int rowIdx in _selectedIndices)
                {
                    string rowUid = fMain.fMain_0.F6061E95(rowIdx, "cUid");
                    if (!string.IsNullOrEmpty(rowUid) && !uidToRowMap.ContainsKey(rowUid))
                    {
                        uidToRowMap[rowUid] = rowIdx;
                    }
                }

                var unmatchedCookies = new List<string>();

                foreach (var rawCookie in cookies)
                {
                    var validation = CookieVaultConverter.ValidateFacebookCookie(rawCookie);
                    if (validation.isValid && !string.IsNullOrEmpty(validation.uid) && uidToRowMap.TryGetValue(validation.uid, out int targetRow))
                    {
                        if (ApplyCookieToRow(targetRow, rawCookie, validation.uid))
                        {
                            usedRows.Add(targetRow);
                            successCount++;
                        }
                    }
                    else
                    {
                        unmatchedCookies.Add(rawCookie);
                    }
                }

                // Đối với các cookie còn lại không khớp UID, gán tuần tự cho các dòng còn lại
                var remainingRows = _selectedIndices.Where(r => !usedRows.Contains(r)).ToList();
                int assignLimit = Math.Min(unmatchedCookies.Count, remainingRows.Count);
                for (int i = 0; i < assignLimit; i++)
                {
                    int rowIdx = remainingRows[i];
                    string c = unmatchedCookies[i];
                    var v = CookieVaultConverter.ValidateFacebookCookie(c);
                    if (ApplyCookieToRow(rowIdx, c, v.uid))
                    {
                        successCount++;
                    }
                }
            }
            else
            {
                // Gán tuần tự theo thứ tự dòng tài khoản
                int assignLimit = Math.Min(cookies.Count, _selectedIndices.Count);
                for (int i = 0; i < assignLimit; i++)
                {
                    int rowIdx = _selectedIndices[i];
                    string c = cookies[i];
                    var v = CookieVaultConverter.ValidateFacebookCookie(c);
                    if (ApplyCookieToRow(rowIdx, c, v.uid))
                    {
                        successCount++;
                    }
                }
            }

            MessageBox.Show($"Đã nạp thành công {successCount} cookie vào tài khoản!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi nạp cookie: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ApplyCookieToRow(int rowIdx, string rawCookie, string uid)
    {
        try
        {
            if (fMain.fMain_0 == null) return false;

            if (!chkOverwrite.Checked)
            {
                string existing = fMain.fMain_0.F6061E95(rowIdx, "cCookies");
                if (!string.IsNullOrWhiteSpace(existing))
                    return false;
            }

            // Cập nhật Cookie vào DB và giao diện DataGridView
            fMain.fMain_0.method_134(rowIdx, "cCookies", rawCookie, "cookie1");

            // Cập nhật UID nếu ô UID đang trống và cookie có chứa UID
            if (chkUpdateUid.Checked && !string.IsNullOrEmpty(uid))
            {
                string existingUid = fMain.fMain_0.F6061E95(rowIdx, "cUid");
                if (string.IsNullOrWhiteSpace(existingUid))
                {
                    fMain.fMain_0.method_134(rowIdx, "cUid", uid, "uid");
                }
            }

            fMain.fMain_0.method_130(rowIdx, "Đã nạp Cookie");
            return true;
        }
        catch
        {
            return false;
        }
    }
}
