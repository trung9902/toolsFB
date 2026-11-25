using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain - Tích hợp Phân hệ Nướng Nick / Account Warm-Up Tự Động 2026.
/// Cung cấp menu chuột phải, phím tắt Ctrl+W, và luồng thực thi warm-up realtime.
/// </summary>
public partial class fMain
{
    private ToolStripMenuItem mnuWarmUp;

    /// <summary>
    /// Khởi tạo và đăng ký Menu Warm-up trên ContextMenuStrip tài khoản (ctmsAcc).
    /// </summary>
    public void SetupAccountWarmUpMenu()
    {
        try
        {
            if (this.ctmsAcc == null) return;

            Image fireIcon = LoadCustomMenuIcon(
                System.IO.Path.Combine("emoji", "1f525.png"),
                16,
                16,
                DrawFlameIconFallback
            );

            mnuWarmUp = new ToolStripMenuItem
            {
                Name = "mnuWarmUp",
                Text = "Warm-up nick",
                Font = this.toolStripMenuItem_1 != null ? this.toolStripMenuItem_1.Font : this.Font,
                Image = fireIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                ToolTipText = "Nướng nick 3 pha Comet: Lướt feed, story, reaction, watch."
            };

            var mnuStartNow = new ToolStripMenuItem
            {
                Name = "mnuStartWarmUpNow",
                Text = "Bắt đầu",
                Font = mnuWarmUp.Font,
                Image = fireIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ShortcutKeys = Keys.Control | Keys.W,
                ShowShortcutKeys = false
            };
            mnuStartNow.Click += (s, e) => StartWarmUpSession();
            mnuWarmUp.Click += (s, e) => StartWarmUpSession();

            mnuWarmUp.DropDownItems.Add(mnuStartNow);

            // Chèn vào ContextMenuStrip ctmsAcc ở vị trí nổi bật (sau 'Mở trình duyệt' hoặc đầu danh sách)
            int insertIndex = this.toolStripMenuItem_2 != null ? this.ctmsAcc.Items.IndexOf(this.toolStripMenuItem_2) + 1 : 2;
            if (insertIndex < 0 || insertIndex > this.ctmsAcc.Items.Count)
            {
                insertIndex = Math.Min(2, this.ctmsAcc.Items.Count);
            }

            this.ctmsAcc.Items.Insert(insertIndex, mnuWarmUp);
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("SetupAccountWarmUpMenu error: " + ex.Message); } catch { }
        }
    }

    /// <summary>
    /// Kích hoạt phiên Warm-Up cho các tài khoản đang được chọn/bôi đen trên giao diện.
    /// </summary>
    private void StartWarmUpSession()
    {
        try
        {
            // Tự động tích chọn dòng nếu người dùng bôi đen mà chưa tích checkbox
            if (method_128() == 0 && F5325785.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in F5325785.SelectedRows)
                {
                    row.Cells["cChose"].Value = true;
                }
                EA1B25A9(0);
            }

            if (!method_129())
            {
                return;
            }

            GClass4 options = new GClass4();
            options.method_4("AccountWarmUp", true);
            method_12(options);
        }
        catch (Exception ex)
        {
            MsBoxHelper.Show("Lỗi khi khởi chạy Warm-up: " + ex.Message, 2);
        }
    }

    /// <summary>
    /// Hàm xử lý Warm-up được điều phối bởi worker thread trong method_12.
    /// </summary>
    /// <param name="rowIndex">Vị trí dòng tài khoản trên DataGridView.</param>
    /// <param name="chrome">Trình duyệt Chrome đang mở tương ứng.</param>
    private void RunAccountWarmUp(int rowIndex, Chrome chrome)
    {
        if (chrome == null || chrome.CD930D04()) return;

        string accountId = chrome.AF336B2C;
        if (string.IsNullOrEmpty(accountId))
        {
            accountId = F6061E95(rowIndex, "cId");
        }

        string uid = chrome.B4208531;
        if (string.IsNullOrEmpty(uid))
        {
            uid = F6061E95(rowIndex, "cUid");
        }

        WarmUpConfig config = new WarmUpConfig();

        method_130(rowIndex, "Bắt đầu Warm-up tự động...");

        bool success = AccountWarmUpHelper.ExecuteWarmUpSession(
            chrome,
            uid,
            config,
            statusMsg =>
            {
                method_130(rowIndex, statusMsg);
            }
        );

        if (success)
        {
            method_134(rowIndex, "cStatus", "Đã warm-up", "status");
            method_134(rowIndex, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "interactEnd");
        }
    }

    /// <summary>
    /// Fallback vẽ icon ngọn lửa (Flame) vector chất lượng cao khi không có file ảnh ngoài.
    /// </summary>
    private static Image DrawFlameIconFallback(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Ngọn lửa chính: cam đỏ
            using (GraphicsPath outerPath = new GraphicsPath())
            {
                outerPath.AddBezier(width / 2f, 2f, width - 2f, 7f, width - 2f, height - 2f, width / 2f, height - 1f);
                outerPath.AddBezier(width / 2f, height - 1f, 2f, height - 2f, 2f, 7f, width / 2f, 2f);

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, height),
                    Color.FromArgb(255, 107, 0),
                    Color.FromArgb(239, 68, 68)))
                {
                    g.FillPath(brush, outerPath);
                }
            }

            // Lõi ngọn lửa: vàng sáng
            using (GraphicsPath innerPath = new GraphicsPath())
            {
                innerPath.AddBezier(width / 2f, 6f, width - 5f, 10f, width - 5f, height - 3f, width / 2f, height - 2f);
                innerPath.AddBezier(width / 2f, height - 2f, 5f, height - 3f, 5f, 10f, width / 2f, 6f);

                using (SolidBrush yellowBrush = new SolidBrush(Color.FromArgb(254, 240, 138)))
                {
                    g.FillPath(yellowBrush, innerPath);
                }
            }
        }
        return bmp;
    }
}
