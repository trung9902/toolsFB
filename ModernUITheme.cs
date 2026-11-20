using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using Bunifu.Framework.UI;

/// <summary>
/// Modern Clean Pro Light Theme Engine for LushCare (Windows 11 Fluent / Modern SaaS style).
/// Delivers an ultra-clean, elegant, eye-friendly white/slate aesthetic across the entire application:
/// - Crisp Segoe UI typography.
/// - Polished Color Palette (Slate 50 background, Pure White cards, Royal Blue / Indigo accents).
/// - Modern pill badges for DataGridView status and account health indicators.
/// - Flat, borderless MenuStrip & ContextMenuStrip with smooth hover states.
/// - Rounded modern buttons with distinct Primary (Blue) and Secondary (Slate) hierarchy.
/// - Automatic recursive skinning for all forms and popups.
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
    public static readonly Color TableHeaderBg = Color.FromArgb(241, 245, 249); // #F1F5F9
    public static readonly Color TableHeaderFg = Color.FromArgb(71, 85, 105);   // #475569
    public static readonly Color TableSelectionBg = Color.FromArgb(224, 231, 255); // #E0E7FF (Soft Indigo)
    public static readonly Color TableSelectionFg = Color.FromArgb(30, 41, 59); // #1E293B
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

            SkinControlsRecursive(form.Controls, form);
        }
        catch { }
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
    /// Transforms DataGridView into a clean, modern SaaS table with pill status badges.
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

            // Column Headers
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = Math.Max(dgv.ColumnHeadersHeight, 34);
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
            dgv.RowTemplate.Height = Math.Max(dgv.RowTemplate.Height, 28);

            // Alternating Row Style (Soft Slate 50)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = TableRowAlt;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextBody;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = TableSelectionBg;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TableSelectionFg;

            // Hook CellPainting for Modern Pill Badges
            dgv.CellPainting -= Dgv_CellPainting;
            dgv.CellPainting += Dgv_CellPainting;
        }
        catch { }
    }

    /// <summary>
    /// Custom paints status and health cells as elegant rounded Pill Badges.
    /// </summary>
    private static void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        try
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null || e.ColumnIndex >= dgv.Columns.Count) return;

            string colName = dgv.Columns[e.ColumnIndex].Name;
            bool isStatusCol = colName == "cInfo" || colName == "cStatus" || colName == "cStatus282" || colName == "cFbBlock";

            if (isStatusCol && e.Value != null)
            {
                string text = e.Value.ToString().Trim();
                if (string.IsNullOrEmpty(text)) return;

                // Determine badge palette based on status text
                Color bg;
                Color fg;
                Color border;

                string lower = text.ToLowerInvariant();
                if (lower == "live" || lower.StartsWith("live"))
                {
                    bg = BadgeLiveBg;
                    fg = BadgeLiveFg;
                    border = BadgeLiveBorder;
                }
                else if (lower.Contains("die") || lower.Contains("văng") || lower.Contains("khóa") || lower.Contains("block") || lower.Contains("tạm dừng"))
                {
                    bg = BadgeDieBg;
                    fg = BadgeDieFg;
                    border = BadgeDieBorder;
                }
                else if (lower.Contains("checkpoint") || lower.Contains("282") || lower.Contains("956") || lower.Contains("xác minh"))
                {
                    bg = BadgeWarnBg;
                    fg = BadgeWarnFg;
                    border = BadgeWarnBorder;
                }
                else if (lower.Contains("đang") || lower.Contains("...") || lower.Contains("tạo") || lower.Contains("chạy") || lower.Contains("running"))
                {
                    bg = BadgeInfoBg;
                    fg = BadgeInfoFg;
                    border = BadgeInfoBorder;
                }
                else
                {
                    bg = BgHover;
                    fg = TextMuted;
                    border = BorderSubtle;
                }

                // Paint standard cell background first
                e.PaintBackground(e.ClipBounds, (e.State & DataGridViewElementStates.Selected) != 0);

                // Measure badge bounds
                using (Graphics g = e.Graphics)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    Size textSize = TextRenderer.MeasureText(text, FontBadge);
                    int padX = 8;
                    int padY = 3;
                    int badgeW = textSize.Width + padX * 2;
                    int badgeH = textSize.Height + padY * 2;

                    // Ensure within cell limits
                    if (badgeW > e.CellBounds.Width - 6) badgeW = e.CellBounds.Width - 6;
                    if (badgeH > e.CellBounds.Height - 4) badgeH = e.CellBounds.Height - 4;

                    int badgeX = e.CellBounds.X + 4;
                    int badgeY = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;
                    Rectangle badgeRect = new Rectangle(badgeX, badgeY, badgeW, badgeH);

                    // Draw rounded pill badge
                    using (GraphicsPath path = CreateRoundedRectanglePath(badgeRect, 6))
                    {
                        using (SolidBrush bBrush = new SolidBrush(bg))
                        {
                            g.FillPath(bBrush, path);
                        }
                        using (Pen bPen = new Pen(border, 1f))
                        {
                            g.DrawPath(bPen, path);
                        }
                    }

                    // Draw centered badge text
                    TextRenderer.DrawText(g, text, FontBadge, badgeRect, fg,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }

                e.Handled = true;
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
