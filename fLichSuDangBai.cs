using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

public class fLichSuDangBai : Form
{
    private Panel pnlBorder;
    private Panel pnlHeader;
    private PictureBox picLogo;
    private Label lblTitle;
    private Button btnClose;

    private Panel pnlToolbar;
    private Label lblTaiKhoan;
    private ComboBox cbbTaiKhoan;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnClearSearch;
    private DateTimePicker dtpTuNgay;
    private Label lblSeparatorDate;
    private DateTimePicker dtpDenNgay;
    private Button btnLocTheoNgay;
    private Button btnStop;
    private Button btnXuatExcel;

    private DataGridView dgvData;
    private Panel pnlFooter;
    private Label lblThongKe;
    private Button btnSaoChepLink;
    private Button btnXoa;
    private Button btnLamMoi;
    private ContextMenuStrip ctmsGrid;

    private CheckBox chkHeader;
    private DataTable _dtSource;
    private int _totalRecordsAll = 0;
    private int _countVisible = 0;
    private int _countChecked = 0;
    private volatile bool _isStopping = false;
    private string _initialUid = "";

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    public fLichSuDangBai()
    {
        InitializeComponent();
        this.Load += FLichSuDangBai_Load;
    }

    public fLichSuDangBai(string initialUid) : this()
    {
        _initialUid = initialUid ?? "";
    }

    private void InitializeComponent()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(1160, 680);
        this.BackColor = Color.White;
        this.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);

        // 0. Border Panel
        pnlBorder = new Panel();
        pnlBorder.Dock = DockStyle.Fill;
        pnlBorder.BorderStyle = BorderStyle.FixedSingle;
        this.Controls.Add(pnlBorder);

        // 1. Header Panel (Height 40px, top title bar with logo, title and rounded close button)
        pnlHeader = new Panel();
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 40;
        pnlHeader.BackColor = Color.White;
        pnlHeader.MouseDown += Header_MouseDown;
        pnlHeader.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        };

        // App Logo
        picLogo = new PictureBox();
        picLogo.Size = new Size(24, 24);
        picLogo.Location = new Point(12, 8);
        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
        picLogo.Cursor = Cursors.Default;
        try { picLogo.Image = Class155.DD225F0D; } catch { }
        picLogo.MouseDown += Header_MouseDown;
        pnlHeader.Controls.Add(picLogo);

        // Title
        lblTitle = new Label();
        lblTitle.Text = "Lịch sử Đăng bài";
        lblTitle.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59); // Slate-800
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(42, 11);
        lblTitle.MouseDown += Header_MouseDown;
        pnlHeader.Controls.Add(lblTitle);

        // Close Button [X] with rounded corners
        btnClose = new Button();
        btnClose.Text = "✕";
        btnClose.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        btnClose.Size = new Size(34, 28);
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(pnlHeader.Width - 44, 6);
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.BackColor = Color.FromArgb(241, 245, 249); // Slate-100
        btnClose.ForeColor = Color.FromArgb(100, 116, 139); // Slate-500
        btnClose.Cursor = Cursors.Hand;
        ApplyRoundedRegion(btnClose, 6);
        btnClose.MouseEnter += (s, e) =>
        {
            btnClose.BackColor = Color.FromArgb(239, 68, 68); // Red-500
            btnClose.ForeColor = Color.White;
        };
        btnClose.MouseLeave += (s, e) =>
        {
            btnClose.BackColor = Color.FromArgb(241, 245, 249);
            btnClose.ForeColor = Color.FromArgb(100, 116, 139);
        };
        btnClose.Click += (s, e) => this.Close();
        pnlHeader.Controls.Add(btnClose);

        // 2. Toolbar Panel (Height 50px, flat background #F8FAFC)
        pnlToolbar = new Panel();
        pnlToolbar.Dock = DockStyle.Top;
        pnlToolbar.Height = 50;
        pnlToolbar.BackColor = Color.FromArgb(248, 250, 252);
        pnlToolbar.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawLine(pen, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            }
        };

        // Label Tai Khoan
        lblTaiKhoan = new Label();
        lblTaiKhoan.Text = "Tài khoản:";
        lblTaiKhoan.AutoSize = true;
        lblTaiKhoan.Location = new Point(12, 16);
        lblTaiKhoan.ForeColor = Color.FromArgb(51, 65, 85);
        lblTaiKhoan.Font = new Font("Tahoma", 9.75f, FontStyle.Regular);
        pnlToolbar.Controls.Add(lblTaiKhoan);

        // ComboBox Tai Khoan
        cbbTaiKhoan = new ComboBox();
        cbbTaiKhoan.DropDownStyle = ComboBoxStyle.DropDownList;
        cbbTaiKhoan.Font = new Font("Tahoma", 9.75f);
        cbbTaiKhoan.Location = new Point(86, 13);
        cbbTaiKhoan.Size = new Size(175, 24);
        cbbTaiKhoan.SelectedIndexChanged += (s, e) => LoadDataGrid();
        pnlToolbar.Controls.Add(cbbTaiKhoan);

        // Search Input
        txtSearch = new TextBox();
        txtSearch.Font = new Font("Tahoma", 9.75f);
        txtSearch.Location = new Point(268, 14);
        txtSearch.Size = new Size(145, 23);
        txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadDataGrid(); };
        pnlToolbar.Controls.Add(txtSearch);

        // Button Search (Real search.png icon)
        btnSearch = new Button();
        btnSearch.Location = new Point(417, 12);
        btnSearch.Size = new Size(32, 26);
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnSearch.BackColor = Color.White;
        btnSearch.Cursor = Cursors.Hand;
        btnSearch.Image = AppIconHelper.GetIcon("search.png", 16, 16);
        btnSearch.ImageAlign = ContentAlignment.MiddleCenter;
        btnSearch.Click += (s, e) => LoadDataGrid();
        pnlToolbar.Controls.Add(btnSearch);

        // Button Clear Search
        btnClearSearch = new Button();
        btnClearSearch.Text = "✕";
        btnClearSearch.Font = new Font("Tahoma", 9f, FontStyle.Bold);
        btnClearSearch.ForeColor = Color.FromArgb(148, 163, 184);
        btnClearSearch.Location = new Point(452, 12);
        btnClearSearch.Size = new Size(26, 26);
        btnClearSearch.FlatStyle = FlatStyle.Flat;
        btnClearSearch.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnClearSearch.BackColor = Color.White;
        btnClearSearch.Cursor = Cursors.Hand;
        btnClearSearch.Click += (s, e) => { txtSearch.Text = ""; LoadDataGrid(); };
        pnlToolbar.Controls.Add(btnClearSearch);

        // Date Range: From
        dtpTuNgay = new DateTimePicker();
        dtpTuNgay.Format = DateTimePickerFormat.Custom;
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Font = new Font("Tahoma", 9.75f);
        dtpTuNgay.Location = new Point(488, 14);
        dtpTuNgay.Size = new Size(105, 23);
        dtpTuNgay.Value = DateTime.Now.AddDays(-30);
        pnlToolbar.Controls.Add(dtpTuNgay);

        lblSeparatorDate = new Label();
        lblSeparatorDate.Text = "—";
        lblSeparatorDate.AutoSize = true;
        lblSeparatorDate.Location = new Point(598, 16);
        lblSeparatorDate.ForeColor = Color.FromArgb(148, 163, 184);
        lblSeparatorDate.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        pnlToolbar.Controls.Add(lblSeparatorDate);

        // Date Range: To
        dtpDenNgay = new DateTimePicker();
        dtpDenNgay.Format = DateTimePickerFormat.Custom;
        dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        dtpDenNgay.Font = new Font("Tahoma", 9.75f);
        dtpDenNgay.Location = new Point(617, 14);
        dtpDenNgay.Size = new Size(105, 23);
        dtpDenNgay.Value = DateTime.Now;
        pnlToolbar.Controls.Add(dtpDenNgay);

        // Button Loc theo ngay (Professional MaxCare Royal Blue #3578E5)
        btnLocTheoNgay = new Button();
        btnLocTheoNgay.Text = "Lọc theo ngày";
        btnLocTheoNgay.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        btnLocTheoNgay.BackColor = Color.FromArgb(53, 120, 229);
        btnLocTheoNgay.ForeColor = Color.White;
        btnLocTheoNgay.FlatStyle = FlatStyle.Flat;
        btnLocTheoNgay.FlatAppearance.BorderSize = 0;
        btnLocTheoNgay.Location = new Point(730, 12);
        btnLocTheoNgay.Size = new Size(116, 27);
        btnLocTheoNgay.Cursor = Cursors.Hand;
        btnLocTheoNgay.Click += (s, e) => LoadDataGrid();
        pnlToolbar.Controls.Add(btnLocTheoNgay);

        // Button Dung (Real stop.png icon)
        btnStop = new Button();
        btnStop.Text = " Dừng";
        btnStop.Font = new Font("Tahoma", 9.75f, FontStyle.Regular);
        btnStop.BackColor = Color.White;
        btnStop.ForeColor = Color.FromArgb(220, 38, 38);
        btnStop.FlatStyle = FlatStyle.Flat;
        btnStop.FlatAppearance.BorderColor = Color.FromArgb(252, 165, 165);
        btnStop.Location = new Point(854, 12);
        btnStop.Size = new Size(82, 27);
        btnStop.Cursor = Cursors.Hand;
        btnStop.Image = AppIconHelper.GetIcon("stop.png", 16, 16);
        btnStop.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnStop.ImageAlign = ContentAlignment.MiddleLeft;
        btnStop.TextAlign = ContentAlignment.MiddleCenter;
        btnStop.Padding = new Padding(4, 0, 4, 0);
        btnStop.Enabled = false;
        btnStop.Click += (s, e) =>
        {
            _isStopping = true;
            btnStop.Enabled = false;
        };
        pnlToolbar.Controls.Add(btnStop);

        // Button Xuat Excel (Real excel.png icon, flat style)
        btnXuatExcel = new Button();
        btnXuatExcel.Text = " Xuất Excel";
        btnXuatExcel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        btnXuatExcel.BackColor = Color.White;
        btnXuatExcel.ForeColor = Color.FromArgb(16, 124, 65);
        btnXuatExcel.FlatStyle = FlatStyle.Flat;
        btnXuatExcel.FlatAppearance.BorderColor = Color.FromArgb(187, 247, 208);
        btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnXuatExcel.Location = new Point(pnlToolbar.Width - 142, 12);
        btnXuatExcel.Size = new Size(128, 27);
        btnXuatExcel.Cursor = Cursors.Hand;
        btnXuatExcel.Image = AppIconHelper.GetIcon("excel.png", 16, 16);
        btnXuatExcel.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnXuatExcel.ImageAlign = ContentAlignment.MiddleLeft;
        btnXuatExcel.TextAlign = ContentAlignment.MiddleCenter;
        btnXuatExcel.Padding = new Padding(6, 0, 4, 0);
        btnXuatExcel.Click += BtnXuatExcel_Click;
        pnlToolbar.Controls.Add(btnXuatExcel);

        // 3. Footer Panel (Height 44px, clean neutral text #334155, bold numbers)
        pnlFooter = new Panel();
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Height = 44;
        pnlFooter.BackColor = Color.FromArgb(248, 250, 252);
        pnlFooter.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
            }
        };

        // Unified professional status label with bold numbers and neutral #334155 color
        lblThongKe = new Label();
        lblThongKe.Font = new Font("Tahoma", 9.75f);
        lblThongKe.ForeColor = Color.FromArgb(51, 65, 85);
        lblThongKe.Location = new Point(14, 12);
        lblThongKe.Size = new Size(500, 22);
        lblThongKe.Paint += LblThongKe_Paint;
        pnlFooter.Controls.Add(lblThongKe);

        // Button Sao chep link (Royal Blue style, real copy.png icon)
        btnSaoChepLink = new Button();
        btnSaoChepLink.Text = " Sao chép link";
        btnSaoChepLink.Font = new Font("Tahoma", 9.75f);
        btnSaoChepLink.BackColor = Color.White;
        btnSaoChepLink.ForeColor = Color.FromArgb(37, 99, 235);
        btnSaoChepLink.FlatStyle = FlatStyle.Flat;
        btnSaoChepLink.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);
        btnSaoChepLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSaoChepLink.Location = new Point(pnlFooter.Width - 390, 8);
        btnSaoChepLink.Size = new Size(130, 28);
        btnSaoChepLink.Cursor = Cursors.Hand;
        btnSaoChepLink.Image = AppIconHelper.GetIcon("copy.png", 16, 16);
        btnSaoChepLink.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnSaoChepLink.ImageAlign = ContentAlignment.MiddleLeft;
        btnSaoChepLink.TextAlign = ContentAlignment.MiddleCenter;
        btnSaoChepLink.Padding = new Padding(4, 0, 4, 0);
        btnSaoChepLink.Click += (s, e) => CopySelectedLinks();
        pnlFooter.Controls.Add(btnSaoChepLink);

        // Button Xoa da chon (Real trash-can_115312.png icon)
        btnXoa = new Button();
        btnXoa.Text = " Xóa đã chọn";
        btnXoa.Font = new Font("Tahoma", 9.75f);
        btnXoa.BackColor = Color.White;
        btnXoa.ForeColor = Color.FromArgb(220, 38, 38);
        btnXoa.FlatStyle = FlatStyle.Flat;
        btnXoa.FlatAppearance.BorderColor = Color.FromArgb(252, 165, 165);
        btnXoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnXoa.Location = new Point(pnlFooter.Width - 250, 8);
        btnXoa.Size = new Size(130, 28);
        btnXoa.Cursor = Cursors.Hand;
        btnXoa.Image = AppIconHelper.GetIcon("trash-can_115312.png", 16, 16);
        btnXoa.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
        btnXoa.TextAlign = ContentAlignment.MiddleCenter;
        btnXoa.Padding = new Padding(4, 0, 4, 0);
        btnXoa.Click += BtnXoa_Click;
        pnlFooter.Controls.Add(btnXoa);

        // Button Lam moi (Real refresh_arrows_14418.png icon)
        btnLamMoi = new Button();
        btnLamMoi.Text = " Làm mới";
        btnLamMoi.Font = new Font("Tahoma", 9.75f);
        btnLamMoi.BackColor = Color.White;
        btnLamMoi.ForeColor = Color.FromArgb(30, 41, 59);
        btnLamMoi.FlatStyle = FlatStyle.Flat;
        btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnLamMoi.Location = new Point(pnlFooter.Width - 110, 8);
        btnLamMoi.Size = new Size(100, 28);
        btnLamMoi.Cursor = Cursors.Hand;
        btnLamMoi.Image = AppIconHelper.GetIcon("refresh_arrows_14418.png", 16, 16);
        btnLamMoi.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
        btnLamMoi.TextAlign = ContentAlignment.MiddleCenter;
        btnLamMoi.Padding = new Padding(4, 0, 4, 0);
        btnLamMoi.Click += (s, e) => LoadDataGrid();
        pnlFooter.Controls.Add(btnLamMoi);

        // 4. DataGridView (Full width, FillWeight proportional stretch, Light Slate Header #F1F5F9)
        dgvData = new DataGridView();
        dgvData.Dock = DockStyle.Fill;
        dgvData.BackgroundColor = Color.White;
        dgvData.BorderStyle = BorderStyle.None;
        dgvData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvData.GridColor = Color.FromArgb(241, 245, 249);
        dgvData.AllowUserToAddRows = false;
        dgvData.AllowUserToDeleteRows = false;
        dgvData.AllowUserToResizeRows = false;
        dgvData.RowHeadersVisible = false;
        dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvData.MultiSelect = true;
        dgvData.EnableHeadersVisualStyles = false;
        dgvData.ColumnHeadersHeight = 36;
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvData.RowTemplate.Height = 28;

        // Header Styling
        dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
        dgvData.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
        dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        // Row Cell Styling
        dgvData.DefaultCellStyle.BackColor = Color.White;
        dgvData.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
        dgvData.DefaultCellStyle.Font = new Font("Tahoma", 9.75f, FontStyle.Regular);
        dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
        dgvData.DefaultCellStyle.SelectionForeColor = Color.FromArgb(12, 74, 110);

        dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

        // Enable double buffering via Reflection
        typeof(DataGridView).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
            null, dgvData, new object[] { true });

        // Add Columns: STT, Checkbox, Time, Status fixed; TaiKhoan, Link, NoiDung auto-stretch via FillWeight
        var colCheck = new DataGridViewCheckBoxColumn();
        colCheck.Name = "cChose";
        colCheck.HeaderText = "";
        colCheck.Width = 36;
        colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        colCheck.Resizable = DataGridViewTriState.False;
        dgvData.Columns.Add(colCheck);

        var colStt = new DataGridViewTextBoxColumn();
        colStt.Name = "cStt";
        colStt.HeaderText = "STT";
        colStt.Width = 48;
        colStt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        colStt.Resizable = DataGridViewTriState.False;
        colStt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colStt.ReadOnly = true;
        dgvData.Columns.Add(colStt);

        var colTaiKhoan = new DataGridViewTextBoxColumn();
        colTaiKhoan.Name = "cTaiKhoan";
        colTaiKhoan.HeaderText = "Tài khoản";
        colTaiKhoan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colTaiKhoan.FillWeight = 26;
        colTaiKhoan.MinimumWidth = 230;
        colTaiKhoan.ReadOnly = true;
        dgvData.Columns.Add(colTaiKhoan);

        var colUid = new DataGridViewTextBoxColumn();
        colUid.Name = "cUid";
        colUid.Visible = false;
        dgvData.Columns.Add(colUid);

        var colTenNick = new DataGridViewTextBoxColumn();
        colTenNick.Name = "cTenNick";
        colTenNick.Visible = false;
        dgvData.Columns.Add(colTenNick);

        var colLink = new DataGridViewTextBoxColumn();
        colLink.Name = "cLink";
        colLink.HeaderText = "Link bài viết";
        colLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colLink.FillWeight = 24;
        colLink.MinimumWidth = 170;
        colLink.DefaultCellStyle.ForeColor = Color.FromArgb(2, 132, 199);
        colLink.ReadOnly = true;
        dgvData.Columns.Add(colLink);

        var colThoiGian = new DataGridViewTextBoxColumn();
        colThoiGian.Name = "cThoiGian";
        colThoiGian.HeaderText = "Thời gian";
        colThoiGian.Width = 145;
        colThoiGian.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        colThoiGian.Resizable = DataGridViewTriState.False;
        colThoiGian.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colThoiGian.ReadOnly = true;
        dgvData.Columns.Add(colThoiGian);

        var colNoiDung = new DataGridViewTextBoxColumn();
        colNoiDung.Name = "cNoiDung";
        colNoiDung.HeaderText = "Nội dung";
        colNoiDung.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colNoiDung.FillWeight = 50;
        colNoiDung.MinimumWidth = 200;
        colNoiDung.ReadOnly = true;
        dgvData.Columns.Add(colNoiDung);

        var colLoai = new DataGridViewTextBoxColumn();
        colLoai.Name = "cLoai";
        colLoai.HeaderText = "Loại";
        colLoai.Width = 110;
        colLoai.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        colLoai.Resizable = DataGridViewTriState.False;
        colLoai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colLoai.ReadOnly = true;
        dgvData.Columns.Add(colLoai);

        var colTrangThai = new DataGridViewTextBoxColumn();
        colTrangThai.Name = "cTrangThai";
        colTrangThai.HeaderText = "Trạng thái";
        colTrangThai.Width = 105;
        colTrangThai.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        colTrangThai.Resizable = DataGridViewTriState.False;
        colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colTrangThai.ReadOnly = true;
        dgvData.Columns.Add(colTrangThai);

        // Header CheckBox for Select/Deselect All
        chkHeader = new CheckBox();
        chkHeader.Size = new Size(15, 15);
        chkHeader.BackColor = Color.Transparent;
        chkHeader.Location = new Point(11, 10);
        chkHeader.CheckedChanged += (s, e) =>
        {
            bool checkAll = chkHeader.Checked;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Cells["cChose"].Value = checkAll;
            }
            UpdateStatusCounts();
        };
        dgvData.Controls.Add(chkHeader);

        dgvData.CellContentClick += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvData.Columns["cChose"].Index)
            {
                dgvData.EndEdit();
                UpdateStatusCounts();
            }
        };

        // ContextMenuStrip for DataGridView
        ctmsGrid = new ContextMenuStrip();
        ctmsGrid.Font = new Font("Tahoma", 9.75f);

        var mnuMoLink = new ToolStripMenuItem("Mở bài viết trên trình duyệt", AppIconHelper.GetIcon("link.png", 16, 16));
        mnuMoLink.Click += (s, e) => OpenSelectedLinkInBrowser();

        var mnuCopyLink = new ToolStripMenuItem("Sao chép link bài viết", AppIconHelper.GetIcon("copy.png", 16, 16));
        mnuCopyLink.ShortcutKeyDisplayString = "Ctrl+C";
        mnuCopyLink.Click += (s, e) => CopySelectedLinks();

        var mnuCopyUid = new ToolStripMenuItem("Sao chép UID tài khoản", AppIconHelper.GetIcon("user.png", 16, 16));
        mnuCopyUid.Click += (s, e) => CopySelectedUids();

        var mnuCopyTen = new ToolStripMenuItem("Sao chép Tên nick tài khoản");
        mnuCopyTen.Click += (s, e) => CopySelectedNames();

        var mnuCopyNoiDung = new ToolStripMenuItem("Sao chép Nội dung bài viết", AppIconHelper.GetIcon("document.png", 16, 16));
        mnuCopyNoiDung.Click += (s, e) => CopySelectedContents();

        var mnuLocTheoTaiKhoan = new ToolStripMenuItem("Lọc theo tài khoản này", AppIconHelper.GetIcon("search.png", 16, 16));
        mnuLocTheoTaiKhoan.Click += (s, e) => FilterBySelectedAccount();

        var mnuChonTatCa = new ToolStripMenuItem("Chọn tất cả");
        mnuChonTatCa.ShortcutKeyDisplayString = "Ctrl+A";
        mnuChonTatCa.Click += (s, e) =>
        {
            foreach (DataGridViewRow r in dgvData.Rows) r.Cells["cChose"].Value = true;
            UpdateStatusCounts();
        };

        var mnuBoChonTatCa = new ToolStripMenuItem("Bỏ chọn tất cả");
        mnuBoChonTatCa.Click += (s, e) =>
        {
            foreach (DataGridViewRow r in dgvData.Rows) r.Cells["cChose"].Value = false;
            UpdateStatusCounts();
        };

        var mnuDaoChon = new ToolStripMenuItem("Đảo chọn");
        mnuDaoChon.Click += (s, e) =>
        {
            foreach (DataGridViewRow r in dgvData.Rows)
                r.Cells["cChose"].Value = !Convert.ToBoolean(r.Cells["cChose"].Value);
            UpdateStatusCounts();
        };

        var mnuXoa = new ToolStripMenuItem("Xóa bản ghi đã chọn", AppIconHelper.GetIcon("trash-can_115312.png", 16, 16));
        mnuXoa.ShortcutKeyDisplayString = "Del";
        mnuXoa.Click += BtnXoa_Click;

        ctmsGrid.Items.Add(mnuMoLink);
        ctmsGrid.Items.Add(mnuCopyLink);
        ctmsGrid.Items.Add(new ToolStripSeparator());
        ctmsGrid.Items.Add(mnuCopyUid);
        ctmsGrid.Items.Add(mnuCopyTen);
        ctmsGrid.Items.Add(mnuCopyNoiDung);
        ctmsGrid.Items.Add(new ToolStripSeparator());
        ctmsGrid.Items.Add(mnuLocTheoTaiKhoan);
        ctmsGrid.Items.Add(new ToolStripSeparator());
        ctmsGrid.Items.Add(mnuChonTatCa);
        ctmsGrid.Items.Add(mnuBoChonTatCa);
        ctmsGrid.Items.Add(mnuDaoChon);
        ctmsGrid.Items.Add(new ToolStripSeparator());
        ctmsGrid.Items.Add(mnuXoa);

        dgvData.ContextMenuStrip = ctmsGrid;

        dgvData.CellMouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                if (!dgvData.Rows[e.RowIndex].Selected)
                {
                    dgvData.ClearSelection();
                    dgvData.Rows[e.RowIndex].Selected = true;
                }
            }
        };

        dgvData.KeyDown += (s, e) =>
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedLinks();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                BtnXoa_Click(s, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (DataGridViewRow r in dgvData.Rows) r.Cells["cChose"].Value = true;
                UpdateStatusCounts();
                e.Handled = true;
            }
        };

        dgvData.CellMouseEnter += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvData.Columns["cLink"].Index)
            {
                string url = dgvData.Rows[e.RowIndex].Cells["cLink"].Value?.ToString();
                if (!string.IsNullOrEmpty(url) && (url.StartsWith("http://") || url.StartsWith("https://")))
                {
                    dgvData.Cursor = Cursors.Hand;
                }
            }
        };

        dgvData.CellMouseLeave += (s, e) =>
        {
            dgvData.Cursor = Cursors.Default;
        };

        dgvData.CellDoubleClick += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != dgvData.Columns["cChose"].Index)
            {
                OpenSelectedLinkInBrowser();
            }
        };

        // Adding controls to pnlBorder in proper hierarchy order:
        // pnlHeader (Outermost Top) -> pnlToolbar (Below Header) -> pnlFooter (Bottom) -> dgvData (Fills remaining center)
        pnlBorder.Controls.Add(dgvData);
        pnlBorder.Controls.Add(pnlFooter);
        pnlBorder.Controls.Add(pnlToolbar);
        pnlBorder.Controls.Add(pnlHeader);

        pnlHeader.SendToBack();
        pnlFooter.SendToBack();
        pnlToolbar.BringToFront();
        dgvData.BringToFront();
    }

    private void Header_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }
    }

    private static void ApplyRoundedRegion(Control control, int radius)
    {
        try
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width + 1, control.Height + 1, radius, radius));
        }
        catch { }
    }

    private void LblThongKe_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        using (var fontReg = new Font("Tahoma", 9.75f, FontStyle.Regular))
        using (var fontBold = new Font("Tahoma", 9.75f, FontStyle.Bold))
        using (var brushText = new SolidBrush(Color.FromArgb(51, 65, 85)))
        using (var brushSep = new SolidBrush(Color.FromArgb(148, 163, 184)))
        {
            float x = 0;
            float y = 2;

            void DrawPart(string label, string val, bool isLast)
            {
                e.Graphics.DrawString(label, fontReg, brushText, x, y);
                x += e.Graphics.MeasureString(label, fontReg).Width - 3;

                e.Graphics.DrawString(val, fontBold, brushText, x, y);
                x += e.Graphics.MeasureString(val, fontBold).Width - 2;

                if (!isLast)
                {
                    string sep = "   |   ";
                    e.Graphics.DrawString(sep, fontReg, brushSep, x, y);
                    x += e.Graphics.MeasureString(sep, fontReg).Width - 3;
                }
            }

            DrawPart("Hiện: ", _countVisible.ToString(), false);
            DrawPart("Đã chọn: ", _countChecked.ToString(), false);
            DrawPart("Tất cả: ", _totalRecordsAll.ToString(), true);
        }
    }

    private void FLichSuDangBai_Load(object sender, EventArgs e)
    {
        cbbTaiKhoan.Items.Clear();
        cbbTaiKhoan.Items.Add("[Tất cả tài khoản]");

        int selectedIdx = 0;
        var accounts = KichBanThongKeDB.GetExistingAccountsList();
        int idx = 1;
        foreach (var acc in accounts)
        {
            cbbTaiKhoan.Items.Add($"{acc.Key} - {acc.Value}");
            if (!string.IsNullOrEmpty(_initialUid) && (acc.Key == _initialUid || acc.Key.Trim() == _initialUid.Trim()))
            {
                selectedIdx = idx;
            }
            idx++;
        }

        if (selectedIdx == 0 && !string.IsNullOrEmpty(_initialUid))
        {
            string name = KichBanThongKeDB.GetAccountNameByUid(_initialUid);
            cbbTaiKhoan.Items.Add($"{_initialUid} - {name}");
            selectedIdx = cbbTaiKhoan.Items.Count - 1;
        }

        cbbTaiKhoan.SelectedIndex = selectedIdx;

        LoadDataGrid();
    }

    private void LoadDataGrid()
    {
        _isStopping = false;
        btnStop.Enabled = true;

        string selectedAcc = cbbTaiKhoan.SelectedItem?.ToString() ?? "";
        string uidFilter = "";
        if (selectedAcc.Contains(" - "))
        {
            uidFilter = selectedAcc.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
        }

        string keyword = txtSearch.Text.Trim();
        DateTime fromDate = dtpTuNgay.Value.Date;
        DateTime toDate = dtpDenNgay.Value.Date;

        _dtSource = KichBanThongKeDB.GetPostHistory(uidFilter, keyword, fromDate, toDate);

        DataTable dtAll = KichBanThongKeDB.GetPostHistory();
        _totalRecordsAll = dtAll != null ? dtAll.Rows.Count : 0;

        dgvData.SuspendLayout();
        dgvData.Rows.Clear();
        if (_dtSource != null)
        {
            int stt = 1;
            foreach (DataRow dr in _dtSource.Rows)
            {
                if (_isStopping)
                {
                    break;
                }

                int rowIndex = dgvData.Rows.Add();
                var row = dgvData.Rows[rowIndex];

                row.Tag = dr["id"];
                row.Cells["cChose"].Value = false;
                row.Cells["cStt"].Value = stt++;

                string uid = dr["uid"]?.ToString() ?? "";
                string tenTaiKhoan = dr["ten_tai_khoan"]?.ToString() ?? "";
                if (string.IsNullOrEmpty(tenTaiKhoan) || tenTaiKhoan == uid)
                {
                    tenTaiKhoan = KichBanThongKeDB.GetAccountNameByUid(uid);
                }

                row.Cells["cUid"].Value = uid;
                row.Cells["cTenNick"].Value = tenTaiKhoan;
                row.Cells["cTaiKhoan"].Value = string.IsNullOrEmpty(tenTaiKhoan) || tenTaiKhoan == uid
                    ? uid
                    : $"{tenTaiKhoan} ({uid})";

                row.Cells["cLink"].Value = dr["link_bai_viet"]?.ToString();
                row.Cells["cThoiGian"].Value = dr["thoi_gian"]?.ToString();
                row.Cells["cNoiDung"].Value = dr["noi_dung"]?.ToString();
                row.Cells["cLoai"].Value = dr["loai"]?.ToString();

                string status = dr["trang_thai"]?.ToString() ?? "Thành công";
                row.Cells["cTrangThai"].Value = status;
                if (status == "Thành công")
                {
                    row.Cells["cTrangThai"].Style.ForeColor = Color.FromArgb(16, 185, 129);
                    row.Cells["cTrangThai"].Style.SelectionForeColor = Color.FromArgb(16, 185, 129);
                    row.Cells["cTrangThai"].Style.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
                }
                else
                {
                    row.Cells["cTrangThai"].Style.ForeColor = Color.FromArgb(239, 68, 68);
                    row.Cells["cTrangThai"].Style.SelectionForeColor = Color.FromArgb(239, 68, 68);
                }

                if (stt % 50 == 0)
                {
                    Application.DoEvents();
                }
            }
        }
        dgvData.ClearSelection();
        dgvData.ResumeLayout();

        btnStop.Enabled = false;
        UpdateStatusCounts();
    }

    private void UpdateStatusCounts()
    {
        _countVisible = dgvData.Rows.Count;
        _countChecked = 0;
        foreach (DataGridViewRow row in dgvData.Rows)
        {
            if (Convert.ToBoolean(row.Cells["cChose"].Value))
            {
                _countChecked++;
            }
        }

        lblThongKe.Invalidate();
    }

    private void BtnXoa_Click(object sender, EventArgs e)
    {
        List<long> idsToDelete = new List<long>();
        foreach (DataGridViewRow row in dgvData.Rows)
        {
            if (Convert.ToBoolean(row.Cells["cChose"].Value) && row.Tag != null)
            {
                if (long.TryParse(row.Tag.ToString(), out long id))
                {
                    idsToDelete.Add(id);
                }
            }
        }

        if (idsToDelete.Count == 0)
        {
            MessageBox.Show("Vui lòng tích chọn ít nhất 1 dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show($"Bạn có chắc chắn muốn xóa {idsToDelete.Count} bản ghi lịch sử đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            int deleted = KichBanThongKeDB.DeletePosts(idsToDelete);
            MessageBox.Show($"Đã xóa thành công {deleted} bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGrid();
        }
    }

    private void BtnXuatExcel_Click(object sender, EventArgs e)
    {
        if (dgvData.Rows.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "CSV UTF-8 (*.csv)|*.csv|Excel CSV (*.csv)|*.csv";
            sfd.FileName = $"LichSuDangBai_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();

                    // Header row
                    List<string> headers = new List<string> { "STT", "Tài khoản", "Link bài viết", "Thời gian", "Nội dung", "Loại", "Trạng thái" };
                    sb.AppendLine(string.Join(",", headers));

                    // Data rows
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        var values = new List<string>
                        {
                            EscapeCsv(row.Cells["cStt"].Value?.ToString()),
                            EscapeCsv(row.Cells["cTaiKhoan"].Value?.ToString()),
                            EscapeCsv(row.Cells["cLink"].Value?.ToString()),
                            EscapeCsv(row.Cells["cThoiGian"].Value?.ToString()),
                            EscapeCsv(row.Cells["cNoiDung"].Value?.ToString()),
                            EscapeCsv(row.Cells["cLoai"].Value?.ToString()),
                            EscapeCsv(row.Cells["cTrangThai"].Value?.ToString())
                        };
                        sb.AppendLine(string.Join(",", values));
                    }

                    // Write UTF-8 with BOM for clean Excel display without mojibake
                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                    if (MessageBox.Show("Xuất dữ liệu Excel thành công! Bạn có muốn mở file ngay bây giờ không?", "Hoàn tất", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private string EscapeCsv(string str)
    {
        if (string.IsNullOrEmpty(str)) return "\"\"";
        return "\"" + str.Replace("\"", "\"\"").Replace((char)13, ' ').Replace((char)10, ' ') + "\"";
    }

    private void OpenSelectedLinkInBrowser()
    {
        try
        {
            string url = "";
            if (dgvData.SelectedRows.Count > 0)
            {
                url = dgvData.SelectedRows[0].Cells["cLink"].Value?.ToString();
            }
            else
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["cChose"].Value))
                    {
                        url = row.Cells["cLink"].Value?.ToString();
                        if (!string.IsNullOrEmpty(url)) break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(url) && (url.StartsWith("http://") || url.StartsWith("https://")))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Bài viết này không có liên kết hợp lệ để mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể mở liên kết: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CopySelectedLinks()
    {
        try
        {
            List<string> links = new List<string>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cChose"].Value))
                {
                    string url = row.Cells["cLink"].Value?.ToString();
                    if (!string.IsNullOrEmpty(url)) links.Add(url);
                }
            }

            if (links.Count == 0 && dgvData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.SelectedRows)
                {
                    string url = row.Cells["cLink"].Value?.ToString();
                    if (!string.IsNullOrEmpty(url)) links.Add(url);
                }
            }

            if (links.Count > 0)
            {
                Clipboard.SetText(string.Join(Environment.NewLine, links));
                MessageBox.Show($"Đã sao chép {links.Count} liên kết bài viết vào bộ nhớ tạm (Clipboard)!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hoặc tích chọn dòng có liên kết bài viết để sao chép!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi sao chép: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CopySelectedUids()
    {
        try
        {
            HashSet<string> uids = new HashSet<string>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cChose"].Value))
                {
                    string uid = row.Cells["cUid"].Value?.ToString();
                    if (!string.IsNullOrEmpty(uid)) uids.Add(uid);
                }
            }

            if (uids.Count == 0 && dgvData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.SelectedRows)
                {
                    string uid = row.Cells["cUid"].Value?.ToString();
                    if (!string.IsNullOrEmpty(uid)) uids.Add(uid);
                }
            }

            if (uids.Count > 0)
            {
                Clipboard.SetText(string.Join(Environment.NewLine, uids));
                MessageBox.Show($"Đã sao chép {uids.Count} UID tài khoản vào bộ nhớ tạm!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hoặc tích chọn dòng để sao chép UID!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi sao chép UID: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CopySelectedNames()
    {
        try
        {
            List<string> names = new List<string>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cChose"].Value))
                {
                    string name = row.Cells["cTenNick"].Value?.ToString();
                    if (!string.IsNullOrEmpty(name)) names.Add(name);
                }
            }

            if (names.Count == 0 && dgvData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.SelectedRows)
                {
                    string name = row.Cells["cTenNick"].Value?.ToString();
                    if (!string.IsNullOrEmpty(name)) names.Add(name);
                }
            }

            if (names.Count > 0)
            {
                Clipboard.SetText(string.Join(Environment.NewLine, names));
                MessageBox.Show($"Đã sao chép {names.Count} tên tài khoản vào bộ nhớ tạm!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi sao chép tên tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CopySelectedContents()
    {
        try
        {
            List<string> contents = new List<string>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cChose"].Value))
                {
                    string txt = row.Cells["cNoiDung"].Value?.ToString();
                    if (!string.IsNullOrEmpty(txt)) contents.Add(txt);
                }
            }

            if (contents.Count == 0 && dgvData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.SelectedRows)
                {
                    string txt = row.Cells["cNoiDung"].Value?.ToString();
                    if (!string.IsNullOrEmpty(txt)) contents.Add(txt);
                }
            }

            if (contents.Count > 0)
            {
                Clipboard.SetText(string.Join(Environment.NewLine + "---" + Environment.NewLine, contents));
                MessageBox.Show($"Đã sao chép {contents.Count} nội dung bài viết vào bộ nhớ tạm!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi sao chép nội dung: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void FilterBySelectedAccount()
    {
        try
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                string uid = dgvData.SelectedRows[0].Cells["cUid"].Value?.ToString();
                if (!string.IsNullOrEmpty(uid))
                {
                    for (int i = 0; i < cbbTaiKhoan.Items.Count; i++)
                    {
                        if (cbbTaiKhoan.Items[i].ToString().StartsWith(uid))
                        {
                            cbbTaiKhoan.SelectedIndex = i;
                            return;
                        }
                    }
                    txtSearch.Text = uid;
                    LoadDataGrid();
                }
            }
        }
        catch { }
    }
}
