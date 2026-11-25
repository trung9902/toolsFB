using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain - Tích hợp Bộ điều phối RAM và Tiến trình ngầm (SmartProcessGovernor).
/// Cung cấp menu chuột phải "Dọn RAM" (phím tắt Ctrl+Shift+R), quét sạch ChromeDriver/Chrome mồ côi và tối ưu RAM.
/// </summary>
public partial class fMain
{
    public ToolStripMenuItem mnuHeThong;
    private ToolStripMenuItem mnuCleanRam;
    private bool isGovernorRunning = false;

    /// <summary>
    /// Khởi tạo và đăng ký menu "Hệ thống" (Dọn RAM & Quản trị) trên ContextMenuStrip tài khoản (ctmsAcc).
    /// </summary>
    /// <summary>
    /// Tìm hoặc khởi tạo ToolStripMenuItem "Hệ thống" dùng chung trên ctmsAcc
    /// </summary>
    public ToolStripMenuItem GetOrCreateHeThongMenu()
    {
        if (mnuHeThong != null && this.ctmsAcc.Items.Contains(mnuHeThong))
        {
            return mnuHeThong;
        }

        foreach (ToolStripItem item in this.ctmsAcc.Items)
        {
            if (item.Name == "mnuHeThong" && item is ToolStripMenuItem)
            {
                mnuHeThong = (ToolStripMenuItem)item;
                return mnuHeThong;
            }
        }

        Image sysIcon = LoadCustomMenuIcon(
            "system.png",
            16,
            16,
            DrawCleanRamIconFallback
        );

        mnuHeThong = new ToolStripMenuItem
        {
            Name = "mnuHeThong",
            Text = "Hệ thống",
            Font = this.toolStripMenuItem_1 != null ? this.toolStripMenuItem_1.Font : this.Font,
            Image = sysIcon,
            ImageScaling = ToolStripItemImageScaling.None,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            ImageAlign = ContentAlignment.MiddleLeft,
            TextAlign = ContentAlignment.MiddleLeft,
            ToolTipText = "Công cụ hệ thống: Dọn RAM, Quản lý & Sao lưu Database, Thống kê"
        };

        // Chèn vào vị trí trực quan trên ctmsAcc
        int insertIndex = -1;
        if (this.databaseToolStripMenuItem != null)
        {
            insertIndex = this.ctmsAcc.Items.IndexOf(this.databaseToolStripMenuItem);
        }
        else if (this.ctmsTinhNangKhac != null)
        {
            insertIndex = this.ctmsAcc.Items.IndexOf(this.ctmsTinhNangKhac) + 1;
        }

        if (insertIndex >= 0 && insertIndex <= this.ctmsAcc.Items.Count)
        {
            this.ctmsAcc.Items.Insert(insertIndex, mnuHeThong);
        }
        else
        {
            this.ctmsAcc.Items.Add(mnuHeThong);
        }

        return mnuHeThong;
    }

    public void SetupProcessGovernorFeatures()
    {
        try
        {
            if (this.ctmsAcc == null) return;

            // Bật hiển thị ToolTip trên context menu nếu chưa bật
            this.ctmsAcc.ShowItemToolTips = true;

            Image ramIcon = LoadCustomMenuIcon(
                "ram_clean.png",
                16,
                16,
                DrawCleanRamIconFallback
            );

            // Tìm hoặc tạo menu cha "Hệ thống"
            mnuHeThong = GetOrCreateHeThongMenu();

            // Tránh tạo trùng lặp nút Dọn RAM
            if (mnuCleanRam == null || !mnuHeThong.DropDownItems.Contains(mnuCleanRam))
            {
                mnuCleanRam = new ToolStripMenuItem
                {
                    Name = "mnuCleanRam",
                    Text = "Dọn RAM",
                    Font = mnuHeThong.Font,
                    Image = ramIcon,
                    ImageScaling = ToolStripItemImageScaling.None,
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ShortcutKeys = Keys.Control | Keys.Shift | Keys.R,
                    ShowShortcutKeys = false,
                    ToolTipText = "Quét sạch ChromeDriver/Chrome treo ngầm và giải phóng RAM (Ctrl+Shift+R)"
                };

                mnuCleanRam.Click += (s, e) => ExecuteRamAndProcessCleanup();
                mnuHeThong.DropDownItems.Add(mnuCleanRam);
            }

            // Đăng ký sự kiện FormClosing của fMain để tự động dọn dẹp nhẹ khi thoát ứng dụng
            this.FormClosing += (s, e) =>
            {
                try
                {
                    SmartProcessGovernor.CleanZombieProcessesAndFlushMemory(killChromes: true);
                }
                catch { }
            };
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("SetupProcessGovernorFeatures error: " + ex.Message); } catch { }
        }
    }

    /// <summary>
    /// Thực hiện dọn dẹp RAM và diệt Chrome/ChromeDriver mồ côi trên ThreadPool
    /// </summary>
    private void ExecuteRamAndProcessCleanup()
    {
        if (isGovernorRunning)
        {
            MsBoxHelper.Show("Hệ thống đang tiến hành dọn RAM, vui lòng chờ...", 2);
            return;
        }

        isGovernorRunning = true;

        try
        {
            if (this.lblTrangThai != null)
            {
                this.lblTrangThai.Text = "Đang dọn RAM và diệt tiến trình treo...";
                if (this.plTrangThai != null) this.plTrangThai.Visible = true;
            }
        }
        catch { }

        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                var result = SmartProcessGovernor.CleanZombieProcessesAndFlushMemory(killChromes: true);
                string freedRamStr = SmartProcessGovernor.FormatBytes(result.ramFreedBytes);
                string message = $"Đã dọn {result.killedDrivers} driver, {result.killedChromes} chrome, giải phóng {freedRamStr} RAM";

                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (this.lblTrangThai != null)
                        {
                            this.lblTrangThai.Text = message;
                        }
                    }
                    catch { }

                    MsBoxHelper.Show(message, 1);
                }));
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new Action(() =>
                {
                    MsBoxHelper.Show("Lỗi khi dọn RAM: " + ex.Message, 2);
                }));
            }
            finally
            {
                isGovernorRunning = false;
            }
        });
    }

    /// <summary>
    /// Fallback icon GDI+ cho nút Dọn RAM (Hình thanh RAM công nghệ cao hiện đại)
    /// </summary>
    private static Image DrawCleanRamIconFallback(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Thanh RAM module: hình chữ nhật bo góc viền xanh Cyan công nghệ cao
            float x = 2f;
            float y = 4f;
            float w = width - 4f;
            float h = height - 8f;

            using (GraphicsPath path = new GraphicsPath())
            {
                float radius = 2f;
                path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
                path.AddArc(x + w - radius * 2, y, radius * 2, radius * 2, 270, 90);
                path.AddArc(x + w - radius * 2, y + h - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(x, y + h - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                    new PointF(0, y),
                    new PointF(0, y + h),
                    Color.FromArgb(14, 165, 233), // Sky blue
                    Color.FromArgb(2, 132, 199))) // Ocean blue
                {
                    g.FillPath(bgBrush, path);
                }

                using (Pen borderPen = new Pen(Color.FromArgb(3, 105, 161), 1f))
                {
                    g.DrawPath(borderPen, path);
                }
            }

            // 3 chip nhớ vàng trên bề mặt RAM
            using (SolidBrush chipBrush = new SolidBrush(Color.FromArgb(254, 240, 138)))
            {
                float chipW = 2.5f;
                float chipH = 4.5f;
                float startX = x + 2f;
                float chipY = y + 2.5f;

                for (int i = 0; i < 3; i++)
                {
                    g.FillRectangle(chipBrush, startX + i * 3.8f, chipY, chipW, chipH);
                }
            }

            // Các chân tiếp xúc mạ vàng ở cạnh đáy
            using (SolidBrush pinBrush = new SolidBrush(Color.FromArgb(234, 179, 8)))
            {
                float pinW = 1.2f;
                float pinH = 1.8f;
                for (float px = x + 1.5f; px < x + w - 1.5f; px += 2.2f)
                {
                    g.FillRectangle(pinBrush, px, y + h - 1.2f, pinW, pinH);
                }
            }
        }
        return bmp;
    }
}
