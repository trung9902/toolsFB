using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

public partial class fMain
{
    private void SetupAvatarFeatures()
    {
        try
        {
            F5325785.RowTemplate.Height = 28;
            F5325785.CellPainting += F5325785_CellPainting;
            F5325785.CellDoubleClick += F5325785_AvatarCellDoubleClick;

            if (F5325785.Columns.Contains("cAvatar"))
            {
                F5325785.Columns["cAvatar"].HeaderText = "Avatar";
                F5325785.Columns["cAvatar"].Width = 55;
                F5325785.Columns["cAvatar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            AddCheckUidLiveMenu();
        }
        catch { }
    }

    private void AddCheckUidLiveMenu()
    {
        try
        {
            if (A492F617 != null)
            {
                ToolStripMenuItem checkUidMenu = new ToolStripMenuItem("Check UID (Cập nhật Tên, Avatar)")
                {
                    ToolTipText = "Kiểm tra trạng thái UID trực tiếp trên Facebook\nTự động tải Avatar và cập nhật Tên, Trạng thái"
                };

                ToolStripMenuItem subNoIp = new ToolStripMenuItem("Không đổi IP");
                subNoIp.Click += (s, e) => C4A352A3(s, e);

                ToolStripMenuItem subProxy = new ToolStripMenuItem("Sử dụng proxy đã gán");
                subProxy.Click += (s, e) => B39C7333(s, e);

                checkUidMenu.DropDownItems.Add(subNoIp);
                checkUidMenu.DropDownItems.Add(subProxy);
                checkUidMenu.Click += (s, e) => C4A352A3(s, e);

                A492F617.DropDownItems.Insert(0, checkUidMenu);
                A492F617.DropDownItems.Insert(1, new ToolStripSeparator());
            }
        }
        catch { }
    }

    private void F5325785_AvatarCellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < F5325785.Columns.Count)
        {
            if (F5325785.Columns[e.ColumnIndex].Name == "cAvatar")
            {
                string uid = F6061E95(e.RowIndex, "cUid");
                if (!string.IsNullOrEmpty(uid))
                {
                    string url = "https://www.facebook.com/profile.php?id=" + uid;
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                    catch { }
                }
            }
        }
    }

    private void F5325785_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < F5325785.Columns.Count && F5325785.Columns[e.ColumnIndex].Name == "cAvatar")
        {
            e.PaintBackground(e.ClipBounds, true);

            string uid = F6061E95(e.RowIndex, "cUid");
            Image img = FbProfileChecker.GetAvatarImage(uid);

            int pad = 3;
            int size = Math.Min(e.CellBounds.Width - pad * 2, e.CellBounds.Height - pad * 2);
            if (size > 8)
            {
                int x = e.CellBounds.X + (e.CellBounds.Width - size) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - size) / 2;
                Rectangle rect = new Rectangle(x, y, size, size);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                if (img != null)
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse(rect);
                        using (TextureBrush brush = new TextureBrush(img, WrapMode.Clamp))
                        {
                            Matrix matrix = new Matrix();
                            matrix.Translate(rect.X, rect.Y);
                            matrix.Scale((float)rect.Width / img.Width, (float)rect.Height / img.Height);
                            brush.Transform = matrix;
                            e.Graphics.FillPath(brush, path);
                        }
                        using (Pen pen = new Pen(Color.FromArgb(200, 205, 215), 1f))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
                else
                {
                    using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(238, 240, 244)))
                    {
                        e.Graphics.FillEllipse(bgBrush, rect);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(215, 220, 228), 1f))
                    {
                        e.Graphics.DrawEllipse(pen, rect);
                    }
                    using (SolidBrush fgBrush = new SolidBrush(Color.FromArgb(175, 180, 192)))
                    {
                        int headW = size * 35 / 100;
                        int headH = headW;
                        int headX = rect.X + (rect.Width - headW) / 2;
                        int headY = rect.Y + size * 18 / 100;
                        e.Graphics.FillEllipse(fgBrush, headX, headY, headW, headH);

                        int bodyW = size * 65 / 100;
                        int bodyH = size * 45 / 100;
                        int bodyX = rect.X + (rect.Width - bodyW) / 2;
                        int bodyY = rect.Y + size * 60 / 100;
                        e.Graphics.FillPie(fgBrush, bodyX, bodyY, bodyW, bodyH, 180, 180);
                    }
                }
            }

            e.Handled = true;
        }
    }
}
