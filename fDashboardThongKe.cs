using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class fDashboardThongKe : Form
{
    private Panel pnlBorder;
    private Panel pnlHeader;
    private PictureBox picLogo;
    private Label lblTitle;
    private Button btnClose;
    private Button btnMinimize;

    // Top Cards
    private Panel pnlCardsContainer;
    private Panel cardToday;
    private Panel cardWeek;
    private Panel cardMonth;
    private Panel cardTotal;

    // Middle Split
    private Panel pnlMiddle;
    private Panel pnlLeft;
    private GroupBox grpTypeBreakdown;
    private GroupBox grpStatusBreakdown;
    private GroupBox grpTopAccounts;
    private DataGridView dgvTop;

    // Bottom Bar
    private Panel pnlFooter;
    private Button btnRefresh;
    private Button btnOpenPosts;
    private Button btnOpenComments;
    private Button btnExportCsv;
    private Button btnCloseBottom;

    // Labels for Cards
    private Label lblValTodayPosts;
    private Label lblValTodayComments;
    private Label lblValWeekPosts;
    private Label lblValWeekComments;
    private Label lblValMonthPosts;
    private Label lblValMonthComments;
    private Label lblValTotalPosts;
    private Label lblValTotalComments;
    private Label lblValSuccessRate;

    // Labels for Breakdown
    private Label lblReelCnt;
    private Label lblStoryCnt;
    private Label lblWallCnt;
    private Label lblGroupCnt;
    private Label lblPageCnt;
    private Label lblOtherCnt;
    private ProgressBar prgReel;
    private ProgressBar prgStory;
    private ProgressBar prgWall;
    private ProgressBar prgGroup;
    private ProgressBar prgPage;

    private Label lblSuccessCnt;
    private Label lblFailedCnt;
    private Label lblPendingCnt;
    private ProgressBar prgSuccessRate;
    private Label lblCommentRate;

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    public fDashboardThongKe()
    {
        InitializeComponent();
        this.Load += (s, e) => LoadDashboardDataAsync();
    }

    private void Header_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }
    }

    private void InitializeComponent()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(1120, 700);
        this.BackColor = Color.FromArgb(248, 250, 252);
        this.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);

        // Border Panel
        pnlBorder = new Panel
        {
            Dock = DockStyle.Fill,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(248, 250, 252)
        };
        this.Controls.Add(pnlBorder);

        // 1. Header
        pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 42,
            BackColor = Color.White
        };
        pnlHeader.MouseDown += Header_MouseDown;
        pnlHeader.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        };

        picLogo = new PictureBox
        {
            Size = new Size(24, 24),
            Location = new Point(12, 9),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        try
        {
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "bar-chart.png");
            if (File.Exists(iconPath)) picLogo.Image = Image.FromFile(iconPath);
            else if (Class155.DD225F0D != null) picLogo.Image = Class155.DD225F0D;
        }
        catch { }

        lblTitle = new Label
        {
            Text = "DASHBOARD TỔNG QUAN THỐNG KÊ TƯƠNG TÁC (REELS, STORY, BÀI ĐĂNG & BÌNH LUẬN)",
            Font = new Font("Tahoma", 9.75f, FontStyle.Bold),
            ForeColor = Color.FromArgb(15, 23, 42),
            Location = new Point(44, 11),
            AutoSize = true
        };
        lblTitle.MouseDown += Header_MouseDown;

        btnClose = new Button
        {
            Text = "✕",
            Font = new Font("Segoe UI", 9.75f, FontStyle.Bold),
            ForeColor = Color.FromArgb(100, 116, 139),
            FlatStyle = FlatStyle.Flat,
            Size = new Size(32, 28),
            Location = new Point(pnlHeader.Width - 38, 7),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
        btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(185, 28, 28);
        btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.White;
        btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(100, 116, 139);
        btnClose.Click += (s, e) => this.Close();

        btnMinimize = new Button
        {
            Text = "—",
            Font = new Font("Segoe UI", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(100, 116, 139),
            FlatStyle = FlatStyle.Flat,
            Size = new Size(32, 28),
            Location = new Point(pnlHeader.Width - 72, 7),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Cursor = Cursors.Hand
        };
        btnMinimize.FlatAppearance.BorderSize = 0;
        btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
        btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

        pnlHeader.Controls.Add(picLogo);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(btnMinimize);
        pnlHeader.Controls.Add(btnClose);
        pnlBorder.Controls.Add(pnlHeader);

        // 2. Top Metric Cards Container
        pnlCardsContainer = new Panel
        {
            Dock = DockStyle.Top,
            Height = 110,
            Padding = new Padding(12, 10, 12, 6),
            BackColor = Color.FromArgb(248, 250, 252)
        };
        BuildMetricCards();
        pnlBorder.Controls.Add(pnlCardsContainer);

        // 3. Footer Panel
        pnlFooter = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 48,
            BackColor = Color.White,
            Padding = new Padding(12, 8, 12, 8)
        };
        pnlFooter.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
            }
        };

        btnRefresh = CreateFooterButton("🔄 Làm mới dữ liệu", Color.FromArgb(37, 99, 235), Color.White);
        btnRefresh.Click += (s, e) => LoadDashboardDataAsync();

        btnOpenPosts = CreateFooterButton("📝 Lịch sử Đăng bài", Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
        btnOpenPosts.Click += (s, e) =>
        {
            using (var f = new fLichSuDangBai()) f.ShowDialog(this);
            LoadDashboardDataAsync();
        };

        btnOpenComments = CreateFooterButton("💬 Lịch sử Bình luận", Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
        btnOpenComments.Click += (s, e) =>
        {
            using (var f = new fLichSuBinhLuan()) f.ShowDialog(this);
            LoadDashboardDataAsync();
        };

        btnExportCsv = CreateFooterButton("📊 Xuất Top UID ra CSV", Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
        btnExportCsv.Click += BtnExportCsv_Click;

        btnCloseBottom = CreateFooterButton("Đóng", Color.FromArgb(241, 245, 249), Color.FromArgb(100, 116, 139));
        btnCloseBottom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCloseBottom.Location = new Point(pnlFooter.Width - 100, 9);
        btnCloseBottom.Click += (s, e) => this.Close();

        pnlFooter.Controls.Add(btnRefresh);
        pnlFooter.Controls.Add(btnOpenPosts);
        pnlFooter.Controls.Add(btnOpenComments);
        pnlFooter.Controls.Add(btnExportCsv);
        pnlFooter.Controls.Add(btnCloseBottom);

        pnlBorder.Controls.Add(pnlFooter);

        // 4. Middle Workspace Panel
        pnlMiddle = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(12, 0, 12, 6),
            BackColor = Color.FromArgb(248, 250, 252)
        };
        pnlBorder.Controls.Add(pnlMiddle);
        pnlMiddle.BringToFront();

        // 4a. Left Panel (Breakdown by Type & Status)
        pnlLeft = new Panel
        {
            Dock = DockStyle.Left,
            Width = 360,
            Padding = new Padding(0, 0, 10, 0),
            BackColor = Color.Transparent
        };
        pnlMiddle.Controls.Add(pnlLeft);

        BuildLeftBreakdownWidgets();

        // 4b. Right Panel (Top Accounts DataGridView)
        grpTopAccounts = new GroupBox
        {
            Dock = DockStyle.Fill,
            Text = "  Bảng xếp hạng Top 100 Tài khoản UID hoạt động tích cực  ",
            Font = new Font("Tahoma", 9.75f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 41, 59),
            BackColor = Color.White,
            Padding = new Padding(8, 12, 8, 8)
        };
        pnlMiddle.Controls.Add(grpTopAccounts);
        grpTopAccounts.BringToFront();

        BuildTopAccountsGrid();
    }

    private void BuildMetricCards()
    {
        TableLayoutPanel tbl = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 1,
            BackColor = Color.Transparent
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));

        cardToday = CreateMetricCard("HÔM NAY", Color.FromArgb(37, 99, 235), out lblValTodayPosts, out lblValTodayComments, "Bài đăng", "Bình luận");
        cardWeek = CreateMetricCard("TUẦN NÀY", Color.FromArgb(124, 58, 237), out lblValWeekPosts, out lblValWeekComments, "Bài đăng", "Bình luận");
        cardMonth = CreateMetricCard("THÁNG NÀY", Color.FromArgb(234, 88, 12), out lblValMonthPosts, out lblValMonthComments, "Bài đăng", "Bình luận");
        cardTotal = CreateMetricCard("TỔNG TÍCH LŨY", Color.FromArgb(16, 185, 129), out lblValTotalPosts, out lblValTotalComments, "Tổng bài", "Tỷ lệ TC", out lblValSuccessRate);

        tbl.Controls.Add(cardToday, 0, 0);
        tbl.Controls.Add(cardWeek, 1, 0);
        tbl.Controls.Add(cardMonth, 2, 0);
        tbl.Controls.Add(cardTotal, 3, 0);

        pnlCardsContainer.Controls.Add(tbl);
    }

    private Panel CreateMetricCard(string title, Color accentColor, out Label lblVal1, out Label lblVal2, string sub1, string sub2, Label lblExtra = null)
    {
        return CreateMetricCard(title, accentColor, out lblVal1, out lblVal2, sub1, sub2, out _);
    }

    private Panel CreateMetricCard(string title, Color accentColor, out Label lblVal1, out Label lblVal2, string sub1, string sub2, out Label lblExtraRate)
    {
        Panel card = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Margin = new Padding(4, 2, 4, 2),
            Padding = new Padding(12, 8, 12, 8)
        };
        card.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            }
            using (var brush = new SolidBrush(accentColor))
            {
                e.Graphics.FillRectangle(brush, 0, 0, 4, card.Height);
            }
        };

        Label lblT = new Label
        {
            Text = title,
            Font = new Font("Tahoma", 8.25f, FontStyle.Bold),
            ForeColor = accentColor,
            Location = new Point(12, 8),
            AutoSize = true
        };

        lblVal1 = new Label
        {
            Text = "0",
            Font = new Font("Tahoma", 15.75f, FontStyle.Bold),
            ForeColor = Color.FromArgb(15, 23, 42),
            Location = new Point(12, 28),
            AutoSize = true
        };

        Label lblSub1 = new Label
        {
            Text = sub1,
            Font = new Font("Tahoma", 8f),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(14, 58),
            AutoSize = true
        };

        lblVal2 = new Label
        {
            Text = "0",
            Font = new Font("Tahoma", 13.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(71, 85, 105),
            Location = new Point(card.Width / 2 + 10, 30),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            AutoSize = true
        };

        Label lblSub2 = new Label
        {
            Text = sub2,
            Font = new Font("Tahoma", 8f),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(card.Width / 2 + 10, 58),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            AutoSize = true
        };

        lblExtraRate = lblVal2;

        card.Controls.Add(lblT);
        card.Controls.Add(lblVal1);
        card.Controls.Add(lblSub1);
        card.Controls.Add(lblVal2);
        card.Controls.Add(lblSub2);

        return card;
    }

    private void BuildLeftBreakdownWidgets()
    {
        // 1. Types breakdown
        grpTypeBreakdown = new GroupBox
        {
            Dock = DockStyle.Top,
            Height = 270,
            Text = "  Phân bổ Thể loại Bài đăng  ",
            Font = new Font("Tahoma", 9.75f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 41, 59),
            BackColor = Color.White,
            Padding = new Padding(12, 14, 12, 10)
        };

        int y = 24;
        AddTypeRow(grpTypeBreakdown, "🎬 Reels FB:", ref y, out lblReelCnt, out prgReel);
        AddTypeRow(grpTypeBreakdown, "📸 Story FB:", ref y, out lblStoryCnt, out prgStory);
        AddTypeRow(grpTypeBreakdown, "🏠 Tường cá nhân:", ref y, out lblWallCnt, out prgWall);
        AddTypeRow(grpTypeBreakdown, "👥 Hội nhóm FB:", ref y, out lblGroupCnt, out prgGroup);
        AddTypeRow(grpTypeBreakdown, "🚩 Fanpage FB:", ref y, out lblPageCnt, out prgPage);

        lblOtherCnt = new Label
        {
            Text = "Khác: 0 bài",
            Font = new Font("Tahoma", 8.25f, FontStyle.Italic),
            ForeColor = Color.FromArgb(100, 116, 139),
            Location = new Point(14, y + 6),
            AutoSize = true
        };
        grpTypeBreakdown.Controls.Add(lblOtherCnt);

        pnlLeft.Controls.Add(grpTypeBreakdown);

        // Spacer
        Panel sp = new Panel { Dock = DockStyle.Top, Height = 10, BackColor = Color.Transparent };
        pnlLeft.Controls.Add(sp);

        // 2. Status breakdown
        grpStatusBreakdown = new GroupBox
        {
            Dock = DockStyle.Fill,
            Text = "  Tỷ lệ Thành công & Trạng thái  ",
            Font = new Font("Tahoma", 9.75f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 41, 59),
            BackColor = Color.White,
            Padding = new Padding(12, 14, 12, 10)
        };

        lblSuccessCnt = new Label
        {
            Text = "✓ Thành công: 0 (0%)",
            Font = new Font("Tahoma", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(22, 163, 74),
            Location = new Point(14, 26),
            AutoSize = true
        };

        lblFailedCnt = new Label
        {
            Text = "✕ Thất bại / Lỗi: 0 (0%)",
            Font = new Font("Tahoma", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(220, 38, 38),
            Location = new Point(14, 50),
            AutoSize = true
        };

        lblPendingCnt = new Label
        {
            Text = "⏳ Chờ duyệt: 0",
            Font = new Font("Tahoma", 9f),
            ForeColor = Color.FromArgb(217, 119, 6),
            Location = new Point(14, 74),
            AutoSize = true
        };

        prgSuccessRate = new ProgressBar
        {
            Location = new Point(14, 104),
            Size = new Size(320, 18),
            Value = 0,
            Maximum = 100
        };

        lblCommentRate = new Label
        {
            Text = "💬 Bình luận: 0 | Tỷ lệ thành công: 100%",
            Font = new Font("Tahoma", 8.25f),
            ForeColor = Color.FromArgb(71, 85, 105),
            Location = new Point(14, 132),
            AutoSize = true
        };

        grpStatusBreakdown.Controls.Add(lblSuccessCnt);
        grpStatusBreakdown.Controls.Add(lblFailedCnt);
        grpStatusBreakdown.Controls.Add(lblPendingCnt);
        grpStatusBreakdown.Controls.Add(prgSuccessRate);
        grpStatusBreakdown.Controls.Add(lblCommentRate);

        pnlLeft.Controls.Add(grpStatusBreakdown);
    }

    private void AddTypeRow(GroupBox grp, string title, ref int y, out Label lblCnt, out ProgressBar prg)
    {
        Label lblT = new Label
        {
            Text = title,
            Font = new Font("Tahoma", 9f),
            ForeColor = Color.FromArgb(15, 23, 42),
            Location = new Point(14, y),
            AutoSize = true
        };

        lblCnt = new Label
        {
            Text = "0",
            Font = new Font("Tahoma", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(37, 99, 235),
            Location = new Point(270, y),
            AutoSize = true
        };

        prg = new ProgressBar
        {
            Location = new Point(14, y + 20),
            Size = new Size(320, 10),
            Value = 0,
            Maximum = 100
        };

        grp.Controls.Add(lblT);
        grp.Controls.Add(lblCnt);
        grp.Controls.Add(prg);

        y += 44;
    }

    private void BuildTopAccountsGrid()
    {
        dgvTop = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
            EnableHeadersVisualStyles = false,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            ReadOnly = true,
            MultiSelect = false,
            GridColor = Color.FromArgb(241, 245, 249),
            Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0)
        };

        dgvTop.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.FromArgb(248, 250, 252),
            ForeColor = Color.FromArgb(71, 85, 105),
            Font = new Font("Tahoma", 9f, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Padding = new Padding(6, 4, 6, 4)
        };
        dgvTop.ColumnHeadersHeight = 34;

        dgvTop.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = Color.FromArgb(15, 23, 42),
            SelectionBackColor = Color.FromArgb(239, 246, 255),
            SelectionForeColor = Color.FromArgb(37, 99, 235),
            Padding = new Padding(6, 2, 6, 2)
        };
        dgvTop.RowTemplate.Height = 32;

        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "#", Name = "cStt", Width = 40, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "UID", Name = "cUid", Width = 140, DefaultCellStyle = { Font = new Font("Tahoma", 9f, FontStyle.Bold) } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên tài khoản", Name = "cName", Width = 150 });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bài đăng", Name = "cPosts", Width = 75, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Tahoma", 9f, FontStyle.Bold) } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành công", Name = "cSuccess", Width = 85, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(22, 163, 74) } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thất bại", Name = "cFailed", Width = 75, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(220, 38, 38) } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tỷ lệ (%)", Name = "cRate", Width = 75, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Tahoma", 9f, FontStyle.Bold) } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bình luận", Name = "cComments", Width = 80, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
        dgvTop.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hoạt động cuối", Name = "cLastAct", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

        grpTopAccounts.Controls.Add(dgvTop);
    }

    private Button CreateFooterButton(string text, Color bg, Color fg)
    {
        Button btn = new Button
        {
            Text = text,
            Font = new Font("Tahoma", 9f, FontStyle.Bold),
            BackColor = bg,
            ForeColor = fg,
            FlatStyle = FlatStyle.Flat,
            Height = 32,
            AutoSize = true,
            Padding = new Padding(10, 0, 10, 0),
            Cursor = Cursors.Hand,
            Margin = new Padding(0, 0, 8, 0)
        };
        btn.FlatAppearance.BorderSize = bg == Color.White || bg == Color.FromArgb(241, 245, 249) ? 1 : 0;
        btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        return btn;
    }

    private async void LoadDashboardDataAsync()
    {
        try
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "⏳ Đang tải...";

            var stats = await Task.Run(() => KichBanThongKeDB.GetDashboardStatistics());

            // 1. Update KPI Cards
            lblValTodayPosts.Text = stats.PostsToday.ToString("N0");
            lblValTodayComments.Text = stats.CommentsToday.ToString("N0");

            lblValWeekPosts.Text = stats.PostsThisWeek.ToString("N0");
            lblValWeekComments.Text = stats.CommentsThisWeek.ToString("N0");

            lblValMonthPosts.Text = stats.PostsThisMonth.ToString("N0");
            lblValMonthComments.Text = stats.CommentsThisMonth.ToString("N0");

            lblValTotalPosts.Text = stats.PostsTotalAll.ToString("N0");
            lblValSuccessRate.Text = $"{stats.PostSuccessRate}%";

            // 2. Update Type Breakdown
            int maxP = Math.Max(1, stats.PostsTotalAll);
            lblReelCnt.Text = stats.PostsReels.ToString("N0");
            prgReel.Value = Math.Min(100, (int)Math.Round((double)stats.PostsReels * 100.0 / maxP));

            lblStoryCnt.Text = stats.PostsStory.ToString("N0");
            prgStory.Value = Math.Min(100, (int)Math.Round((double)stats.PostsStory * 100.0 / maxP));

            lblWallCnt.Text = stats.PostsTuong.ToString("N0");
            prgWall.Value = Math.Min(100, (int)Math.Round((double)stats.PostsTuong * 100.0 / maxP));

            lblGroupCnt.Text = stats.PostsNhom.ToString("N0");
            prgGroup.Value = Math.Min(100, (int)Math.Round((double)stats.PostsNhom * 100.0 / maxP));

            lblPageCnt.Text = stats.PostsFanpage.ToString("N0");
            prgPage.Value = Math.Min(100, (int)Math.Round((double)stats.PostsFanpage * 100.0 / maxP));

            lblOtherCnt.Text = $"Khác: {stats.PostsOther:N0} bài";

            // 3. Update Status Breakdown
            int totalStatus = stats.PostsSuccess + stats.PostsFailed + stats.PostsPending;
            double scRate = totalStatus > 0 ? Math.Round((double)stats.PostsSuccess * 100.0 / totalStatus, 1) : 100.0;
            double flRate = totalStatus > 0 ? Math.Round((double)stats.PostsFailed * 100.0 / totalStatus, 1) : 0.0;

            lblSuccessCnt.Text = $"✓ Thành công: {stats.PostsSuccess:N0} ({scRate}%)";
            lblFailedCnt.Text = $"✕ Thất bại / Lỗi: {stats.PostsFailed:N0} ({flRate}%)";
            lblPendingCnt.Text = $"⏳ Chờ duyệt: {stats.PostsPending:N0}";
            prgSuccessRate.Value = Math.Min(100, (int)Math.Round(scRate));

            lblCommentRate.Text = $"💬 Bình luận: {stats.CommentsTotalAll:N0} lượt (Thành công: {stats.CommentSuccessRate}%)";

            // 4. Update Top Grid
            dgvTop.Rows.Clear();
            if (stats.TopAccountsTable != null && stats.TopAccountsTable.Rows.Count > 0)
            {
                foreach (DataRow r in stats.TopAccountsTable.Rows)
                {
                    dgvTop.Rows.Add(
                        r["stt"],
                        r["uid"],
                        r["ten_tai_khoan"],
                        r["so_bai_dang"],
                        r["thanh_cong"],
                        r["that_bai"],
                        r["ty_le"],
                        r["so_binh_luan"],
                        r["hoat_dong_cuoi"]
                    );
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi nạp dữ liệu thống kê: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            btnRefresh.Enabled = true;
            btnRefresh.Text = "🔄 Làm mới dữ liệu";
        }
    }

    private void BtnExportCsv_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgvTop.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu tài khoản để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"LushCare_TopUID_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Hạng,UID,Tên tài khoản,Số bài đăng,Thành công,Thất bại,Tỷ lệ,Số bình luận,Hoạt động cuối");
                    foreach (DataGridViewRow row in dgvTop.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string line = $"{row.Cells[0].Value},{row.Cells[1].Value},\"{row.Cells[2].Value}\",{row.Cells[3].Value},{row.Cells[4].Value},{row.Cells[5].Value},{row.Cells[6].Value},{row.Cells[7].Value},{row.Cells[8].Value}";
                        sb.AppendLine(line);
                    }
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Đã xuất thành công {dgvTop.Rows.Count} dòng ra file:\n{sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
