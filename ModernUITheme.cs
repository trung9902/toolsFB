using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using Bunifu.Framework.UI;

/// <summary>
/// Modern Clean Pro Light Theme Engine for LushCare (Windows 11 Fluent / Modern SaaS style).
/// Delivers an ultra-clean, elegant, eye-friendly white/slate aesthetic across the entire application:
/// - Razor-sharp typography (Segoe UI with ClearType rendering).
/// - Polished Color Palette (Slate 50 background, Pure White cards, Royal Blue / Indigo accents).
/// - Modern pill badges for DataGridView status, script tags, and account health indicators.
/// - Smooth circular clipped avatar rendering.
/// - Flat, borderless MenuStrip & ContextMenuStrip with smooth hover states.
/// - Rounded modern buttons with distinct Primary (Blue) and Secondary (Slate) hierarchy.
/// - Automatic recursive skinning for all forms, popups, and the main dashboard.
/// </summary>
public static class ModernUITheme
{
    // ==========================================
    // 1. MODERN LIGHT COLOR PALETTE
    // ==========================================
    public static readonly Color BgApp = Color.FromArgb(248, 250, 252);        // #F8FAFC (Slate 50)
    public static readonly Color BgCard = Color.FromArgb(255, 255, 255);       // #FFFFFF (Pure White)
    public static readonly Color BgHover = Color.FromArgb(241, 245, 249);      // #F1F5F9 (Slate 100)
    public static readonly Color BgActive = Color.FromArgb(226, 232, 240);     // #E2E8F0 (Slate 200)

    public static readonly Color BorderSubtle = Color.FromArgb(226, 232, 240); // #E2E8F0
    public static readonly Color BorderMedium = Color.FromArgb(203, 213, 225); // #CBD5E1

    public static readonly Color Primary = Color.FromArgb(37, 99, 235);         // #2563EB (Royal Blue / Indigo)
    public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);    // #1D4ED8
    public static readonly Color PrimaryPressed = Color.FromArgb(30, 64, 175);  // #1E40AF
    public static readonly Color PrimaryLight = Color.FromArgb(239, 246, 255);  // #EFF6FF

    public static readonly Color SecondaryBtn = Color.FromArgb(241, 245, 249);  // #F1F5F9
    public static readonly Color SecondaryBtnHover = Color.FromArgb(226, 232, 240);
    public static readonly Color SecondaryBtnText = Color.FromArgb(71, 85, 105); // #475569

    public static readonly Color Danger = Color.FromArgb(239, 68, 68);          // #EF4444 (Rose 500)
    public static readonly Color DangerHover = Color.FromArgb(220, 38, 38);
    public static readonly Color Success = Color.FromArgb(16, 185, 129);        // #10B981 (Emerald 500)
    public static readonly Color Warning = Color.FromArgb(245, 158, 11);        // #F59E0B (Amber 500)

    public static readonly Color TextTitle = Color.FromArgb(15, 23, 42);        // #0F172A (Slate 900)
    public static readonly Color TextBody = Color.FromArgb(30, 41, 59);         // #1E293B (Slate 800)
    public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);     // #64748B (Slate 500)

    // DataGridView Table Colors
    public static readonly Color TableRowAlt = Color.FromArgb(248, 250, 252);   // #F8FAFC
    public static readonly Color TableHeaderBg = Color.FromArgb(248, 250, 252); // #F8FAFC
    public static readonly Color TableHeaderFg = Color.FromArgb(71, 85, 105);   // #475569
    public static readonly Color TableSelectionBg = Color.FromArgb(238, 242, 255); // #EEF2FF (Soft Indigo)
    public static readonly Color TableSelectionFg = Color.FromArgb(15, 23, 42); // #0F172A
    public static readonly Color TableGridLine = Color.FromArgb(241, 245, 249);  // #F1F5F9

    // Status Pill Badges
    public static readonly Color BadgeLiveBg = Color.FromArgb(222, 247, 236);   // #DEF7EC
    public static readonly Color BadgeLiveFg = Color.FromArgb(3, 84, 63);       // #03543F
    public static readonly Color BadgeLiveBorder = Color.FromArgb(188, 240, 218); // #BCF0DA

    public static readonly Color BadgeDieBg = Color.FromArgb(253, 232, 232);    // #FDE8E8
    public static readonly Color BadgeDieFg = Color.FromArgb(155, 28, 28);      // #9B1C1C
    public static readonly Color BadgeDieBorder = Color.FromArgb(251, 213, 213); // #FBD5D5

    public static readonly Color BadgeWarnBg = Color.FromArgb(254, 243, 199);   // #FEF3C7
    public static readonly Color BadgeWarnFg = Color.FromArgb(146, 64, 14);     // #92400E
    public static readonly Color BadgeWarnBorder = Color.FromArgb(253, 230, 138); // #FDE68A

    public static readonly Color BadgeInfoBg = Color.FromArgb(224, 231, 255);   // #E0E7FF
    public static readonly Color BadgeInfoFg = Color.FromArgb(55, 48, 163);     // #3730A3
    public static readonly Color BadgeInfoBorder = Color.FromArgb(199, 210, 254); // #C7D2FE

    public static readonly Color BadgeScriptBg = Color.FromArgb(243, 232, 255); // #F3E8FF (Lavender)
    public static readonly Color BadgeScriptFg = Color.FromArgb(107, 33, 168);  // #6B21A8
    public static readonly Color BadgeScriptBorder = Color.FromArgb(233, 213, 255); // #E9D5FF

    public static readonly Color BadgeFolderBg = Color.FromArgb(241, 245, 249); // #F1F5F9 (Slate)
    public static readonly Color BadgeFolderFg = Color.FromArgb(71, 85, 105);   // #475569
    public static readonly Color BadgeFolderBorder = Color.FromArgb(226, 232, 240); // #E2E8F0

    // ==========================================
    // 2. MODERN TYPOGRAPHY (Segoe UI)
    // ==========================================
    public static readonly Font FontBody = new Font("Segoe UI", 9.25f, FontStyle.Regular);
    public static readonly Font FontBold = new Font("Segoe UI", 9.25f, FontStyle.Bold);
    public static readonly Font FontHeader = new Font("Segoe UI", 10.5f, FontStyle.Bold);
    public static readonly Font FontSmall = new Font("Segoe UI", 8.25f, FontStyle.Regular);
    public static readonly Font FontBadge = new Font("Segoe UI", 8.25f, FontStyle.Bold);

    private static bool _initialized = false;
    private static readonly HashSet<Form> _skinnedForms = new HashSet<Form>();

    /// <summary>
    /// Initializes global renderers and event hooks for dynamic form skinning.
    /// </summary>
    public static void Init()
    {
        if (_initialized) return;
        _initialized = true;

        try
        {
            // Set global ToolStrip / MenuStrip / ContextMenuStrip Renderer
            ToolStripManager.Renderer = new ModernLightToolStripRenderer();
        }
        catch { }

        // Automatically skin newly shown forms
        Application.Idle += (s, e) =>
        {
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f != null && !_skinnedForms.Contains(f) && f.IsHandleCreated)
                    {
                        _skinnedForms.Add(f);
                        ApplyTheme(f);
                    }
                }
            }
            catch { }
        };
    }

    /// <summary>
    /// Applies the Modern Clean Pro Light Theme recursively to a form and its child controls.
    /// </summary>
    public static void ApplyTheme(Form form)
    {
        if (form == null || form.IsDisposed) return;

        try
        {
            form.Font = FontBody;
            if (form.BackColor == SystemColors.Control || form.BackColor == Color.Gainsboro)
            {
                form.BackColor = BgApp;
            }

            // Dedicated layout polish for fMain dashboard
            if (form is fMain mainForm)
            {
                SkinMainDashboard(mainForm);
            }

            SkinControlsRecursive(form.Controls, form);
        }
        catch { }
    }

    /// <summary>
    /// Performs razor-sharp styling on the main dashboard (fMain):
    /// Title bar, MenuStrip, Action toolbar, Search box, Folder selector, and Account Table.
    /// </summary>
    public static void SkinMainDashboard(fMain main)
    {
        if (main == null || main.IsDisposed) return;

        try
        {
            main.BackColor = BgApp;

            // 1. Root Container Panel
            if (main.panel1 != null)
            {
                main.panel1.BackColor = BgApp;
                main.panel1.BorderStyle = BorderStyle.None;
            }

            // 2. Hide legacy bunifu top line
            if (main.D7A63B91 != null)
            {
                main.D7A63B91.Visible = false;
            }

            // 3. Modern Title Bar (FBA31BBA)
            if (main.FBA31BBA != null)
            {
                main.FBA31BBA.BackColor = BgCard;
                main.FBA31BBA.Height = 36;
                main.FBA31BBA.Paint -= TitleBar_Paint;
                main.FBA31BBA.Paint += TitleBar_Paint;

                if (main.B526D03A != null)
                {
                    main.B526D03A.Font = FontHeader;
                    main.B526D03A.ForeColor = TextTitle;
                    main.B526D03A.Location = new Point(44, 8);
                }

                // Window action buttons
                Button[] winBtns = { main.E836E3B2, main.btnMaximize, main.ADA8C634 };
                foreach (Button b in winBtns)
                {
                    if (b != null)
                    {
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.BackColor = Color.Transparent;
                        b.Cursor = Cursors.Hand;
                    }
                }
            }

            // 4. Main MenuStrip (D39C9728)
            if (main.D39C9728 != null)
            {
                main.D39C9728.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                main.D39C9728.BackColor = BgCard;
                main.D39C9728.Font = FontBody;
                main.D39C9728.Height = 28;
                main.D39C9728.Location = new Point(0, 36);
                main.D39C9728.Padding = new Padding(6, 3, 6, 3);
            }

            // 5. Action Toolbar - Primary Button (btnInteract)
            int tbY = 68;
            int tbH = 32;

            if (main.btnInteract != null)
            {
                main.btnInteract.Size = new Size(142, tbH);
                main.btnInteract.Location = new Point(8, tbY);
                main.btnInteract.BackColor = Primary;
                main.btnInteract.ForeColor = Color.White;
                main.btnInteract.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
                main.btnInteract.FlatStyle = FlatStyle.Flat;
                main.btnInteract.FlatAppearance.BorderSize = 0;
                main.btnInteract.Image = null;
                main.btnInteract.Text = "▶  Chạy Tương Tác";
                main.btnInteract.TextAlign = ContentAlignment.MiddleCenter;
                main.btnInteract.Cursor = Cursors.Hand;
            }

            // 6. Search Container (DC993629)
            if (main.DC993629 != null)
            {
                main.DC993629.BorderStyle = BorderStyle.None;
                main.DC993629.BackColor = Color.Transparent;
                main.DC993629.Location = new Point(158, tbY);
                main.DC993629.Size = new Size(265, tbH);

                if (main.cbbSearch != null)
                {
                    main.cbbSearch.Location = new Point(0, 2);
                    main.cbbSearch.Size = new Size(82, tbH);
                    main.cbbSearch.FlatStyle = FlatStyle.Flat;
                    main.cbbSearch.Font = new Font("Segoe UI", 9f);
                    main.cbbSearch.BackColor = Color.FromArgb(248, 250, 252);
                    main.cbbSearch.ForeColor = TextBody;
                }
                if (main.txbSearch != null)
                {
                    main.txbSearch.Location = new Point(86, 2);
                    main.txbSearch.Size = new Size(146, tbH);
                    main.txbSearch.Font = new Font("Segoe UI", 9.25f);
                    main.txbSearch.BorderColor = BorderMedium;
                    main.txbSearch.ForeColor = TextBody;
                }
                if (main.BtnSearch != null)
                {
                    main.BtnSearch.Location = new Point(234, 1);
                    main.BtnSearch.Size = new Size(30, 30);
                    main.BtnSearch.FlatStyle = FlatStyle.Flat;
                    main.BtnSearch.FlatAppearance.BorderSize = 0;
                    main.BtnSearch.BackgroundImage = null;
                    main.BtnSearch.Image = null;
                    main.BtnSearch.Text = "🔍";
                    main.BtnSearch.Font = new Font("Segoe UI", 9.5f);
                    main.BtnSearch.BackColor = Color.FromArgb(241, 245, 249);
                    main.BtnSearch.ForeColor = Primary;
                    main.BtnSearch.Cursor = Cursors.Hand;
                }
            }

            // 7. Folder & Action Container (plQuanLyThuMuc)
            if (main.plQuanLyThuMuc != null)
            {
                main.plQuanLyThuMuc.BorderStyle = BorderStyle.None;
                main.plQuanLyThuMuc.BackColor = Color.Transparent;
                main.plQuanLyThuMuc.Location = new Point(432, tbY);
                main.plQuanLyThuMuc.Size = new Size(640, tbH);

                if (main.label1 != null)
                {
                    main.label1.Location = new Point(0, 7);
                    main.label1.Font = new Font("Segoe UI", 8.75f, FontStyle.Bold);
                    main.label1.ForeColor = TextMuted;
                }
                if (main.D38F4B00 != null)
                {
                    main.D38F4B00.Location = new Point(60, 2);
                    main.D38F4B00.Size = new Size(115, tbH);
                    main.D38F4B00.FlatStyle = FlatStyle.Flat;
                    main.D38F4B00.Font = new Font("Segoe UI", 9f);
                    main.D38F4B00.BackColor = Color.White;
                }
                if (main.label2 != null)
                {
                    main.label2.Location = new Point(182, 7);
                    main.label2.Font = new Font("Segoe UI", 8.75f, FontStyle.Bold);
                    main.label2.ForeColor = TextMuted;
                }
                if (main.FE921A1C != null)
                {
                    main.FE921A1C.Location = new Point(214, 2);
                    main.FE921A1C.Size = new Size(125, tbH);
                    main.FE921A1C.FlatStyle = FlatStyle.Flat;
                    main.FE921A1C.Font = new Font("Segoe UI", 9f);
                    main.FE921A1C.BackColor = Color.White;
                }

                // Small utility buttons (+, /, -, ⇄)
                Button[] utilBtns = { main.AddFileAccount, main.btnEditFile, main.D1117A83, main.btnLoadAcc };
                int btnStartX = 346;
                for (int i = 0; i < utilBtns.Length; i++)
                {
                    Button ub = utilBtns[i];
                    if (ub != null)
                    {
                        ub.Location = new Point(btnStartX + (i * 30), 2);
                        ub.Size = new Size(28, 28);
                        ub.FlatStyle = FlatStyle.Flat;
                        ub.FlatAppearance.BorderColor = BorderSubtle;
                        ub.FlatAppearance.BorderSize = 1;
                        ub.BackColor = Color.White;
                        ub.Cursor = Cursors.Hand;
                    }
                }

                // Nhập tài khoản button (Clean Modern Secondary Pill)
                if (main.CA9D953A != null)
                {
                    main.CA9D953A.Location = new Point(474, 1);
                    main.CA9D953A.Size = new Size(140, 30);
                    main.CA9D953A.Image = null; // Xóa vĩnh viễn icon thư mục vàng kiểu cũ
                    main.CA9D953A.Text = "📥  Nhập tài khoản";
                    main.CA9D953A.TextAlign = ContentAlignment.MiddleCenter;
                    main.CA9D953A.FlatStyle = FlatStyle.Flat;
                    main.CA9D953A.BackColor = PrimaryLight;
                    main.CA9D953A.ForeColor = Primary;
                    main.CA9D953A.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    main.CA9D953A.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);
                    main.CA9D953A.FlatAppearance.BorderSize = 1;
                    main.CA9D953A.Cursor = Cursors.Hand;
                }
            }

            // 8. Close Chromedriver Button (metroButton1)
            if (main.metroButton1 != null)
            {
                main.metroButton1.Size = new Size(130, tbH);
                main.metroButton1.Location = new Point(main.panel1.Width - 140, tbY);
                main.metroButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                main.metroButton1.Text = "✕  Đóng Chrome";
                main.metroButton1.TextAlign = ContentAlignment.MiddleCenter;
                main.metroButton1.FlatStyle = FlatStyle.Flat;
                main.metroButton1.BackColor = Color.FromArgb(254, 242, 242);
                main.metroButton1.ForeColor = Color.FromArgb(220, 38, 38);
                main.metroButton1.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                main.metroButton1.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
                main.metroButton1.FlatAppearance.BorderSize = 1;
                main.metroButton1.Cursor = Cursors.Hand;
            }

            // 9. Modern DataGridView (F5325785)
            if (main.F5325785 != null)
            {
                main.F5325785.Location = new Point(8, 108);
                main.F5325785.RowTemplate.Height = 36;
                foreach (DataGridViewRow r in main.F5325785.Rows)
                {
                    r.Height = 36;
                }
                SkinDataGridView(main.F5325785);
            }

            // 10. Status Bar (statusStrip1)
            if (main.statusStrip1 != null)
            {
                main.statusStrip1.Font = FontSmall;
                main.statusStrip1.BackColor = BgApp;
                main.statusStrip1.Height = 28;
                main.statusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            }
        }
        catch { }
    }

    private static void TitleBar_Paint(object sender, PaintEventArgs e)
    {
        if (sender is Panel p)
        {
            using (Pen borderPen = new Pen(BorderSubtle, 1f))
            {
                e.Graphics.DrawLine(borderPen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
    }

    /// <summary>
    /// Recursively skins controls to match the Modern Clean Light aesthetic.
    /// </summary>
    public static void SkinControlsRecursive(Control.ControlCollection controls, Form parentForm)
    {
        if (controls == null) return;

        foreach (Control c in controls)
        {
            if (c == null || c.IsDisposed) continue;

            try
            {
                // 1. DataGridView Styling
                if (c is DataGridView dgv)
                {
                    SkinDataGridView(dgv);
                }
                // 2. BunifuCards Styling (eliminate SaddleBrown)
                else if (c is BunifuCards bc)
                {
                    bc.color = Primary;
                    bc.BackColor = BgCard;
                    bc.BorderRadius = 8;
                }
                // 3. Button Styling
                else if (c is Button btn && !(c is CheckBox) && !(c is RadioButton))
                {
                    SkinButton(btn);
                }
                // 4. MenuStrip / ToolStrip / StatusStrip
                else if (c is MenuStrip menu)
                {
                    menu.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    menu.BackColor = BgCard;
                    menu.Font = FontBody;
                }
                else if (c is StatusStrip status)
                {
                    status.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    status.BackColor = BgApp;
                    status.Font = FontSmall;
                }
                else if (c is ToolStrip ts)
                {
                    ts.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    ts.BackColor = BgCard;
                    ts.Font = FontBody;
                }
                // 5. GroupBox Modernization
                else if (c is GroupBox gb)
                {
                    SkinGroupBox(gb);
                }
                // 6. Panel Backgrounds
                else if (c is Panel p)
                {
                    if (p.BackColor == Color.Gainsboro || p.BackColor == SystemColors.Control)
                    {
                        p.BackColor = BgApp;
                    }
                }
                // 7. CheckBox / RadioButton
                else if (c is CheckBox chk)
                {
                    chk.Font = FontBody;
                    chk.ForeColor = TextBody;
                }
                else if (c is RadioButton rb)
                {
                    rb.Font = FontBody;
                    rb.ForeColor = TextBody;
                }
                // 8. Text Input Controls
                else if (c is TextBox tb)
                {
                    tb.Font = FontBody;
                    tb.ForeColor = TextBody;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cb)
                {
                    cb.Font = FontBody;
                    cb.ForeColor = TextBody;
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is NumericUpDown nud)
                {
                    nud.Font = FontBody;
                    nud.ForeColor = TextBody;
                    nud.BorderStyle = BorderStyle.FixedSingle;
                }
                // 9. Labels
                else if (c is Label lbl)
                {
                    if (lbl.Font.Bold)
                    {
                        lbl.Font = FontBold;
                    }
                    else
                    {
                        lbl.Font = FontBody;
                    }
                    if (lbl.ForeColor == Color.Black || lbl.ForeColor == SystemColors.ControlText)
                    {
                        lbl.ForeColor = TextBody;
                    }
                }

                // Recurse into child controls
                if (c.HasChildren)
                {
                    SkinControlsRecursive(c.Controls, parentForm);
                }
            }
            catch { }
        }
    }

    /// <summary>
    /// Transforms DataGridView into a clean, modern SaaS table with pill status badges,
    /// rounded avatars, and razor-sharp header & row styling.
    /// </summary>
    public static void SkinDataGridView(DataGridView dgv)
    {
        if (dgv == null || dgv.IsDisposed) return;

        try
        {
            // Enable double buffering for stutter-free scrolling
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, dgv, new object[] { true });
            }
            catch { }

            dgv.BackgroundColor = BgCard;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = BorderSubtle;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Column Headers (Sleek Modern Slate Bar)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = Math.Max(dgv.ColumnHeadersHeight, 38);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = TableHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TableHeaderFg;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = TableHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = TableHeaderFg;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Default Cell Style (White background, Dark text)
            dgv.DefaultCellStyle.BackColor = BgCard;
            dgv.DefaultCellStyle.ForeColor = TextBody;
            dgv.DefaultCellStyle.SelectionBackColor = TableSelectionBg;
            dgv.DefaultCellStyle.SelectionForeColor = TableSelectionFg;
            dgv.DefaultCellStyle.Font = FontBody;
            dgv.RowTemplate.Height = Math.Max(dgv.RowTemplate.Height, 36);

            // Alternating Row Style (Soft Slate 50)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = TableRowAlt;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextBody;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = TableSelectionBg;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TableSelectionFg;

            // Hook CellPainting for Modern Pill Badges & Circular Avatars
            dgv.CellPainting -= Dgv_CellPainting;
            dgv.CellPainting += Dgv_CellPainting;
        }
        catch { }
    }

    /// <summary>
    /// Custom paints headers, status pill badges, circular avatars, and selection accent bar.
    /// </summary>
    private static void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        try
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            // 1. Modern Header Painting
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                // Fill header background
                using (SolidBrush headerBg = new SolidBrush(TableHeaderBg))
                {
                    e.Graphics.FillRectangle(headerBg, e.CellBounds);
                }

                // Header bottom border line
                using (Pen bPen = new Pen(BorderSubtle, 1.2f))
                {
                    e.Graphics.DrawLine(bPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                // Checkbox in header (cChose)
                if (dgv.Columns[e.ColumnIndex].Name == "cChose")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                    e.Handled = true;
                    return;
                }

                // Draw header text
                string headerText = dgv.Columns[e.ColumnIndex].HeaderText;
                if (!string.IsNullOrEmpty(headerText))
                {
                    Rectangle textRect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y, e.CellBounds.Width - 12, e.CellBounds.Height);
                    TextRenderer.DrawText(e.Graphics, headerText, FontBold, textRect, TableHeaderFg,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }

                e.Handled = true;
                return;
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex >= dgv.Columns.Count) return;

            string colName = dgv.Columns[e.ColumnIndex].Name;
            bool isSelected = (e.State & DataGridViewElementStates.Selected) != 0;

            // Determine base row background color
            Color rowBg = isSelected ? TableSelectionBg : (e.RowIndex % 2 == 0 ? BgCard : TableRowAlt);
            if (!isSelected && dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.Empty && dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.White)
            {
                rowBg = dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }

            // 2. Circular Avatar Painting
            if ((colName == "cAvatar" || colName.ToLowerInvariant().Contains("avatar")) && e.Value is Image avatarImg)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Fill cell background
                using (SolidBrush bgBrush = new SolidBrush(rowBg))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                // Draw circular avatar
                int size = 26;
                int ax = e.CellBounds.X + (e.CellBounds.Width - size) / 2;
                int ay = e.CellBounds.Y + (e.CellBounds.Height - size) / 2;
                Rectangle avatarRect = new Rectangle(ax, ay, size, size);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(avatarRect);
                    GraphicsState state = e.Graphics.Save();
                    e.Graphics.SetClip(path);
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImage(avatarImg, avatarRect);
                    e.Graphics.Restore(state);
                }

                // Subtle ring around avatar
                using (Pen ringPen = new Pen(BorderSubtle, 1f))
                {
                    e.Graphics.DrawEllipse(ringPen, avatarRect);
                }

                // Bottom divider line
                using (Pen divPen = new Pen(TableGridLine, 1f))
                {
                    e.Graphics.DrawLine(divPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
                return;
            }

            // 3. Status Columns (Pill Badge with Status Dot)
            bool isStatusCol = colName == "cInfo" || colName == "cStatus" || colName == "cStatus282" || colName == "cFbBlock";
            if (isStatusCol && e.Value != null)
            {
                string text = e.Value.ToString().Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    // Fill cell background
                    using (SolidBrush bgBrush = new SolidBrush(rowBg))
                    {
                        e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                    }

                    // Badge palette & status dot color
                    Color bg, fg, border, dotColor;
                    string lower = text.ToLowerInvariant();

                    if (lower == "live" || lower.StartsWith("live"))
                    {
                        bg = BadgeLiveBg; fg = BadgeLiveFg; border = BadgeLiveBorder;
                        dotColor = Success;
                    }
                    else if (lower.Contains("die") || lower.Contains("văng") || lower.Contains("khóa") || lower.Contains("block") || lower.Contains("tạm dừng"))
                    {
                        bg = BadgeDieBg; fg = BadgeDieFg; border = BadgeDieBorder;
                        dotColor = Danger;
                    }
                    else if (lower.Contains("checkpoint") || lower.Contains("282") || lower.Contains("956") || lower.Contains("xác minh"))
                    {
                        bg = BadgeWarnBg; fg = BadgeWarnFg; border = BadgeWarnBorder;
                        dotColor = Warning;
                    }
                    else if (lower.Contains("đang") || lower.Contains("...") || lower.Contains("tạo") || lower.Contains("chạy") || lower.Contains("running"))
                    {
                        bg = BadgeInfoBg; fg = BadgeInfoFg; border = BadgeInfoBorder;
                        dotColor = Primary;
                    }
                    else
                    {
                        bg = BadgeFolderBg; fg = BadgeFolderFg; border = BadgeFolderBorder;
                        dotColor = TextMuted;
                    }

                    // Render Pill Badge
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Size textSize = TextRenderer.MeasureText(text, FontBadge);
                    int dotSize = 6;
                    int padLeft = 8 + dotSize + 4;
                    int padRight = 8;
                    int badgeW = textSize.Width + padLeft + padRight;
                    int badgeH = Math.Min(24, e.CellBounds.Height - 6);

                    if (badgeW > e.CellBounds.Width - 8) badgeW = e.CellBounds.Width - 8;

                    int bx = e.CellBounds.X + 4;
                    int by = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;
                    Rectangle badgeRect = new Rectangle(bx, by, badgeW, badgeH);

                    // Pill path
                    using (GraphicsPath path = CreateRoundedRectanglePath(badgeRect, badgeH / 2))
                    {
                        using (SolidBrush bBrush = new SolidBrush(bg))
                        {
                            e.Graphics.FillPath(bBrush, path);
                        }
                        using (Pen bPen = new Pen(border, 1f))
                        {
                            e.Graphics.DrawPath(bPen, path);
                        }
                    }

                    // Draw status dot
                    int dotX = bx + 7;
                    int dotY = by + (badgeH - dotSize) / 2;
                    using (SolidBrush dotBrush = new SolidBrush(dotColor))
                    {
                        e.Graphics.FillEllipse(dotBrush, dotX, dotY, dotSize, dotSize);
                    }

                    // Draw text
                    Rectangle badgeTextRect = new Rectangle(bx + padLeft, by, badgeW - padLeft - 4, badgeH);
                    TextRenderer.DrawText(e.Graphics, text, FontBadge, badgeTextRect, fg,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                    // Bottom divider line
                    using (Pen divPen = new Pen(TableGridLine, 1f))
                    {
                        e.Graphics.DrawLine(divPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }

                    e.Handled = true;
                    return;
                }
            }

            // 4. Script Column (cKichBan) Tag
            if (colName == "cKichBan" && e.Value != null)
            {
                string text = e.Value.ToString().Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    using (SolidBrush bgBrush = new SolidBrush(rowBg))
                    {
                        e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                    }

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Size textSize = TextRenderer.MeasureText(text, FontBadge);
                    int badgeW = Math.Min(textSize.Width + 14, e.CellBounds.Width - 8);
                    int badgeH = Math.Min(22, e.CellBounds.Height - 6);
                    int bx = e.CellBounds.X + 4;
                    int by = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;
                    Rectangle badgeRect = new Rectangle(bx, by, badgeW, badgeH);

                    using (GraphicsPath path = CreateRoundedRectanglePath(badgeRect, 6))
                    {
                        using (SolidBrush bBrush = new SolidBrush(BadgeScriptBg))
                        {
                            e.Graphics.FillPath(bBrush, path);
                        }
                        using (Pen bPen = new Pen(BadgeScriptBorder, 1f))
                        {
                            e.Graphics.DrawPath(bPen, path);
                        }
                    }

                    TextRenderer.DrawText(e.Graphics, text, FontBadge, badgeRect, BadgeScriptFg,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                    using (Pen divPen = new Pen(TableGridLine, 1f))
                    {
                        e.Graphics.DrawLine(divPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }

                    e.Handled = true;
                    return;
                }
            }

            // 5. Normal Cell & Selection Accent Bar
            if (isSelected)
            {
                using (SolidBrush bgBrush = new SolidBrush(TableSelectionBg))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                // Left vertical accent strip on first column
                if (e.ColumnIndex == 0)
                {
                    using (SolidBrush accentBrush = new SolidBrush(Primary))
                    {
                        e.Graphics.FillRectangle(accentBrush, e.CellBounds.Left, e.CellBounds.Top, 3, e.CellBounds.Height);
                    }
                }

                // Paint cell contents with dark text (never inverted)
                e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);

                // Bottom divider line
                using (Pen divPen = new Pen(TableGridLine, 1f))
                {
                    e.Graphics.DrawLine(divPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
                return;
            }
        }
        catch { }
    }

    /// <summary>
    /// Modernizes buttons: Flat style, modern rounded look, Primary Blue or Secondary Slate.
    /// </summary>
    public static void SkinButton(Button btn)
    {
        if (btn == null || btn.IsDisposed) return;

        try
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;

            string txt = (btn.Text ?? "").Trim().ToLowerInvariant();
            string name = (btn.Name ?? "").ToLowerInvariant();

            // Primary Action Button (Lưu, Thêm, Chạy, Start, Save, Add)
            bool isPrimary = txt.Contains("lưu") || txt.Contains("thêm") || txt.Contains("chạy") ||
                             txt.Contains("bắt đầu") || txt.Contains("xác nhận") || txt.Contains("save") ||
                             name == "btnsave" || name == "btnadd" || name == "btninteract";

            // Cancel / Close Button (Đóng, Hủy, Thoát, Cancel, Close)
            bool isCancel = txt.Contains("đóng") || txt.Contains("hủy") || txt.Contains("thoát") ||
                            txt.Contains("close") || txt.Contains("cancel") || name == "btncancel";

            // Danger Button (Xóa, Delete)
            bool isDanger = txt.Contains("xóa") || txt.Contains("delete");

            if (isPrimary)
            {
                btn.BackColor = Primary;
                btn.ForeColor = Color.White;
                btn.Font = FontBold;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = PrimaryHover;
                btn.FlatAppearance.MouseDownBackColor = PrimaryPressed;
            }
            else if (isCancel)
            {
                btn.BackColor = SecondaryBtn;
                btn.ForeColor = SecondaryBtnText;
                btn.Font = FontBold;
                btn.FlatAppearance.BorderColor = BorderSubtle;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = SecondaryBtnHover;
                btn.FlatAppearance.MouseDownBackColor = BgActive;
            }
            else if (isDanger)
            {
                btn.BackColor = Danger;
                btn.ForeColor = Color.White;
                btn.Font = FontBold;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = DangerHover;
            }
            else
            {
                // General Button
                if (btn.BackColor == Color.Maroon || btn.BackColor == Color.Red)
                {
                    btn.BackColor = SecondaryBtn;
                    btn.ForeColor = SecondaryBtnText;
                    btn.FlatAppearance.BorderColor = BorderSubtle;
                    btn.FlatAppearance.BorderSize = 1;
                }
                else if (btn.BackColor == Color.White || btn.BackColor == SystemColors.Control)
                {
                    btn.BackColor = BgCard;
                    btn.ForeColor = TextBody;
                    btn.FlatAppearance.BorderColor = BorderSubtle;
                    btn.FlatAppearance.BorderSize = 1;
                }
                btn.FlatAppearance.MouseOverBackColor = BgHover;
                btn.Font = FontBody;
            }
        }
        catch { }
    }

    /// <summary>
    /// Custom paints GroupBox with a sleek, clean border and modern typography instead of retro 3D lines.
    /// </summary>
    public static void SkinGroupBox(GroupBox gb)
    {
        if (gb == null || gb.IsDisposed) return;

        try
        {
            gb.Font = FontBold;
            gb.ForeColor = TextBody;

            // Avoid double-hooking Paint
            gb.Paint -= Gb_Paint;
            gb.Paint += Gb_Paint;
        }
        catch { }
    }

    private static void Gb_Paint(object sender, PaintEventArgs e)
    {
        GroupBox gb = sender as GroupBox;
        if (gb == null) return;

        try
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Size textSize = TextRenderer.MeasureText(gb.Text, FontBold);
            Rectangle rect = new Rectangle(0, textSize.Height / 2, gb.Width - 1, gb.Height - textSize.Height / 2 - 1);

            // Clear background
            e.Graphics.Clear(gb.Parent != null ? gb.Parent.BackColor : BgApp);

            // Draw clean rounded border
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, 6))
            {
                using (Pen pen = new Pen(BorderSubtle, 1.2f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Draw header text
            if (!string.IsNullOrEmpty(gb.Text))
            {
                Rectangle textRect = new Rectangle(12, 0, textSize.Width + 4, textSize.Height);
                using (SolidBrush bgBrush = new SolidBrush(gb.Parent != null ? gb.Parent.BackColor : BgApp))
                {
                    e.Graphics.FillRectangle(bgBrush, textRect);
                }
                TextRenderer.DrawText(e.Graphics, gb.Text, FontBold, new Point(14, 0), TextBody);
            }
        }
        catch { }
    }

    /// <summary>
    /// Helper to create rounded rectangle GraphicsPath.
    /// </summary>
    public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        if (radius <= 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        int d = radius * 2;
        path.AddArc(rect.X, rect.Y, d, d, 180, 90);
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}

/// <summary>
/// Professional clean light renderer for MenuStrip, ToolStrip, ContextMenuStrip, and StatusStrip.
/// Replaces legacy gradients and 3D bevels with flat, elegant white/slate styling.
/// </summary>
public class ModernLightToolStripRenderer : ToolStripProfessionalRenderer
{
    public ModernLightToolStripRenderer() : base(new ModernLightColorTable())
    {
        RoundedEdges = false;
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        e.TextFont = ModernUITheme.FontBody;
        e.TextColor = (e.Item.Selected || e.Item.Pressed) ? ModernUITheme.Primary : ModernUITheme.TextBody;
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnRenderItemText(e);
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        if (e.Item.Selected || e.Item.Pressed)
        {
            Rectangle rect = new Rectangle(2, 1, e.Item.Width - 4, e.Item.Height - 2);
            using (GraphicsPath path = ModernUITheme.CreateRoundedRectanglePath(rect, 4))
            {
                using (SolidBrush brush = new SolidBrush(e.Item.Pressed ? ModernUITheme.BgActive : ModernUITheme.BgHover))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
        else
        {
            base.OnRenderMenuItemBackground(e);
        }
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        if (e.ToolStrip is ToolStripDropDown)
        {
            Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using (Pen pen = new Pen(ModernUITheme.BorderSubtle, 1f))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        else
        {
            // Subtle 1px bottom border for main menu strip
            e.Graphics.DrawLine(new Pen(ModernUITheme.BorderSubtle, 1f), 0, e.ToolStrip.Height - 1, e.ToolStrip.Width, e.ToolStrip.Height - 1);
        }
    }
}

/// <summary>
/// Custom ProfessionalColorTable for clean light flat theme.
/// </summary>
public class ModernLightColorTable : ProfessionalColorTable
{
    public override Color ToolStripDropDownBackground => ModernUITheme.BgCard;
    public override Color ImageMarginGradientBegin => ModernUITheme.BgCard;
    public override Color ImageMarginGradientMiddle => ModernUITheme.BgCard;
    public override Color ImageMarginGradientEnd => ModernUITheme.BgCard;

    public override Color MenuStripGradientBegin => ModernUITheme.BgCard;
    public override Color MenuStripGradientEnd => ModernUITheme.BgCard;

    public override Color MenuItemSelected => ModernUITheme.BgHover;
    public override Color MenuItemSelectedGradientBegin => ModernUITheme.BgHover;
    public override Color MenuItemSelectedGradientEnd => ModernUITheme.BgHover;
    public override Color MenuItemBorder => Color.Transparent;

    public override Color MenuItemPressedGradientBegin => ModernUITheme.BgActive;
    public override Color MenuItemPressedGradientMiddle => ModernUITheme.BgActive;
    public override Color MenuItemPressedGradientEnd => ModernUITheme.BgActive;

    public override Color MenuBorder => ModernUITheme.BorderSubtle;
    public override Color SeparatorDark => ModernUITheme.BorderSubtle;
    public override Color SeparatorLight => Color.Transparent;

    public override Color ButtonSelectedHighlight => ModernUITheme.BgHover;
    public override Color ButtonSelectedGradientBegin => ModernUITheme.BgHover;
    public override Color ButtonSelectedGradientMiddle => ModernUITheme.BgHover;
    public override Color ButtonSelectedGradientEnd => ModernUITheme.BgHover;

    public override Color CheckBackground => ModernUITheme.BadgeInfoBg;
    public override Color CheckSelectedBackground => ModernUITheme.BadgeInfoBorder;

    public override Color StatusStripGradientBegin => ModernUITheme.BgApp;
    public override Color StatusStripGradientEnd => ModernUITheme.BgApp;
}
