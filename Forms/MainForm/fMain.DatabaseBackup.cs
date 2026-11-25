using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain - Tích hợp Quản lý Sao lưu xoay vòng 7 ngày & Khôi phục Database SQLite an toàn.
/// Cung cấp menu chuột phải trên danh sách tài khoản (ctmsAcc):
/// - Sao lưu DB
///     + Tạo bản sao lưu ngay (Snapshot tức thời)
///     + Khôi phục DB... (Hộp thoại chọn bản sao lưu hoặc file ngoài an toàn)
///     + Mở thư mục backup (Truy cập thư mục database/backup)
/// </summary>
public partial class fMain
{
    private ToolStripMenuItem mnuDatabaseBackup;
    private ToolStripMenuItem mnuCreateBackupNow;
    private ToolStripMenuItem mnuRestoreBackup;
    private ToolStripMenuItem mnuOpenBackupFolder;

    /// <summary>
    /// Khởi tạo và thiết lập các tính năng sao lưu & khôi phục database SQLite.
    /// Gọi kiểm tra và tự động sao lưu nền nếu bản backup gần nhất quá 12 tiếng,
    /// đồng thời gắn menu "Sao lưu DB" vào context menu ctmsAcc.
    /// </summary>
    public void SetupDatabaseBackupFeatures()
    {
        try
        {
            // 1. Kích hoạt sao lưu tự động khi khởi động (nếu cần)
            DatabaseAutoBackupHub.AutoBackupOnStartup();

            if (this.ctmsAcc == null)
                return;

            // Tránh khởi tạo lặp lại
            if (mnuDatabaseBackup != null && this.ctmsAcc.Items.Contains(mnuDatabaseBackup))
                return;

            // Icon hiển thị: ưu tiên icon database gốc trong resource, nếu không có thì vẽ GDI+ fallback
            Image dbIcon = this.databaseToolStripMenuItem != null ? this.databaseToolStripMenuItem.Image : null;
            if (dbIcon == null)
            {
                dbIcon = DrawDatabaseBackupIconFallback(16, 16);
            }

            Font menuFont = this.toolStripMenuItem_1 != null ? this.toolStripMenuItem_1.Font : this.Font;

            // 2. Tạo menu chính: "Sao lưu DB"
            mnuDatabaseBackup = new ToolStripMenuItem
            {
                Name = "mnuDatabaseBackup",
                Text = "Sao lưu DB",
                Font = menuFont,
                Image = dbIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Sao lưu xoay vòng 7 ngày & Khôi phục database SQLite an toàn"
            };

            // 3. Sub-menu 1: "Tạo bản sao lưu ngay"
            mnuCreateBackupNow = new ToolStripMenuItem
            {
                Name = "mnuCreateBackupNow",
                Text = "Tạo bản sao lưu ngay",
                Font = menuFont,
                Image = dbIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Tạo ngay 1 bản sao lưu database vào thư mục database/backup/"
            };
            mnuCreateBackupNow.Click += (s, e) => HandleCreateBackupNow();

            // 4. Sub-menu 2: "Khôi phục DB..."
            mnuRestoreBackup = new ToolStripMenuItem
            {
                Name = "mnuRestoreBackup",
                Text = "Khôi phục DB...",
                Font = menuFont,
                Image = dbIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Hiển thị danh sách các bản backup để chọn khôi phục hoặc chọn file ngoài"
            };
            mnuRestoreBackup.Click += (s, e) => ShowRestoreDatabaseDialog();

            // 5. Sub-menu 3: "Mở thư mục backup"
            mnuOpenBackupFolder = new ToolStripMenuItem
            {
                Name = "mnuOpenBackupFolder",
                Text = "Mở thư mục backup",
                Font = menuFont,
                Image = dbIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Mở thư mục chứa các bản sao lưu SQLite trong Windows Explorer"
            };
            mnuOpenBackupFolder.Click += (s, e) =>
            {
                try
                {
                    string backupDir = DatabaseAutoBackupHub.GetBackupDirectory();
                    if (Directory.Exists(backupDir))
                    {
                        Process.Start("explorer.exe", backupDir);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Không thể mở thư mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            mnuDatabaseBackup.DropDownItems.Add(mnuCreateBackupNow);
            mnuDatabaseBackup.DropDownItems.Add(mnuRestoreBackup);
            mnuDatabaseBackup.DropDownItems.Add(new ToolStripSeparator());
            mnuDatabaseBackup.DropDownItems.Add(mnuOpenBackupFolder);

            // 6. Gắn menu vào menu con "Hệ thống" để gom gọn giao diện
            ToolStripMenuItem sysMenu = GetOrCreateHeThongMenu();
            if (sysMenu != null && !sysMenu.DropDownItems.Contains(mnuDatabaseBackup))
            {
                sysMenu.DropDownItems.Add(mnuDatabaseBackup);
            }
        }
        catch (Exception ex)
        {
            try
            {
                Commom.smethod_57(null, ex, "fMain.SetupDatabaseBackupFeatures");
            }
            catch { }
        }
    }

    /// <summary>
    /// Xử lý tạo bản sao lưu thủ công tức thì khi người dùng click "Tạo bản sao lưu ngay".
    /// </summary>
    private void HandleCreateBackupNow()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            string backupPath = DatabaseAutoBackupHub.CreateBackup("manual");
            Cursor.Current = Cursors.Default;

            if (!string.IsNullOrEmpty(backupPath) && File.Exists(backupPath))
            {
                FileInfo fi = new FileInfo(backupPath);
                string sizeStr = fi.Length > 1024 * 1024
                    ? $"{fi.Length / (1024.0 * 1024.0):F2} MB"
                    : $"{fi.Length / 1024.0:F1} KB";

                string relativePath = "database/backup/" + fi.Name;
                MessageBox.Show(
                    this,
                    $"Đã tạo bản sao lưu tại {relativePath}\n\n• Thời gian: {fi.CreationTime:dd/MM/yyyy HH:mm:ss}\n• Dung lượng: {sizeStr}",
                    "Sao Lưu Database Thành Công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    this,
                    "Không thể tạo bản sao lưu. Vui lòng kiểm tra lại quyền truy cập hoặc file database.",
                    "Lỗi Sao Lưu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(
                this,
                "Lỗi khi tạo bản sao lưu: " + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Hiển thị hộp thoại giao diện người dùng chọn bản sao lưu trong 7 ngày hoặc chọn file ngoài để khôi phục.
    /// </summary>
    private void ShowRestoreDatabaseDialog()
    {
        try
        {
            using (Form dialog = new Form())
            {
                dialog.Text = "Khôi phục Database SQLite - LushCare";
                dialog.Size = new Size(720, 480);
                dialog.MinimumSize = new Size(620, 380);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.BackColor = Color.White;
                dialog.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                dialog.ShowIcon = true;
                if (this.Icon != null) dialog.Icon = this.Icon;

                // 1. Panel tiêu đề phía trên (Header)
                Panel pnlHeader = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 62,
                    BackColor = Color.FromArgb(248, 250, 252),
                    Padding = new Padding(16, 10, 16, 10)
                };

                Label lblTitle = new Label
                {
                    Text = "Khôi Phục Cơ Sở Dữ Liệu SQLite",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(15, 23, 42),
                    AutoSize = true,
                    Location = new Point(14, 8)
                };

                Label lblSub = new Label
                {
                    Text = "Chọn một bản sao lưu trong 7 ngày gần nhất để khôi phục hoặc chọn tệp ngoài.\nHệ thống sẽ tự động tạo bản backup an toàn trước khi ghi đè dữ liệu.",
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(71, 85, 105),
                    AutoSize = true,
                    Location = new Point(15, 30)
                };

                pnlHeader.Controls.Add(lblTitle);
                pnlHeader.Controls.Add(lblSub);

                // 2. Panel nút bấm phía dưới (Bottom actions)
                Panel pnlBottom = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 56,
                    BackColor = Color.FromArgb(248, 250, 252),
                    Padding = new Padding(12, 10, 12, 10)
                };

                Button btnRestore = new Button
                {
                    Text = "Khôi phục bản đã chọn",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = Color.FromArgb(37, 99, 235),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(165, 34),
                    Cursor = Cursors.Hand
                };
                btnRestore.FlatAppearance.BorderSize = 0;

                Button btnBrowse = new Button
                {
                    Text = "Chọn file khác...",
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(125, 34),
                    Cursor = Cursors.Hand
                };
                btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

                Button btnOpenFolder = new Button
                {
                    Text = "Mở thư mục backup",
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(140, 34),
                    Cursor = Cursors.Hand
                };
                btnOpenFolder.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

                Button btnRefresh = new Button
                {
                    Text = "Làm mới",
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(85, 34),
                    Cursor = Cursors.Hand
                };
                btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

                Button btnClose = new Button
                {
                    Text = "Đóng",
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(75, 34),
                    Cursor = Cursors.Hand
                };
                btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

                // Sắp xếp các nút theo layout chuẩn
                int currentX = 14;
                btnRestore.Location = new Point(currentX, 11);
                currentX += btnRestore.Width + 8;

                btnBrowse.Location = new Point(currentX, 11);
                currentX += btnBrowse.Width + 8;

                btnOpenFolder.Location = new Point(currentX, 11);
                currentX += btnOpenFolder.Width + 8;

                btnRefresh.Location = new Point(currentX, 11);

                btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnClose.Location = new Point(dialog.ClientSize.Width - btnClose.Width - 14, 11);

                pnlBottom.Controls.Add(btnRestore);
                pnlBottom.Controls.Add(btnBrowse);
                pnlBottom.Controls.Add(btnOpenFolder);
                pnlBottom.Controls.Add(btnRefresh);
                pnlBottom.Controls.Add(btnClose);

                // 3. DataGridView hiển thị danh sách các bản sao lưu
                DataGridView dgvBackups = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    BackgroundColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                    GridColor = Color.FromArgb(226, 232, 240),
                    RowHeadersVisible = false,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeRows = false,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false,
                    EnableHeadersVisualStyles = false
                };

                dgvBackups.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                dgvBackups.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                dgvBackups.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvBackups.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
                dgvBackups.ColumnHeadersHeight = 32;

                dgvBackups.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                dgvBackups.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
                dgvBackups.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);
                dgvBackups.RowTemplate.Height = 30;

                dgvBackups.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên tệp sao lưu", Width = 270, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvBackups.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời gian sao lưu", Width = 150 });
                dgvBackups.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Dung lượng", Width = 95 });
                dgvBackups.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại bản ghi", Width = 110 });
                dgvBackups.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "FullPath", Visible = false });

                // Nạp danh sách bản sao lưu vào bảng
                Action loadData = () =>
                {
                    try
                    {
                        dgvBackups.Rows.Clear();
                        var list = DatabaseAutoBackupHub.GetBackupList();
                        if (list != null && list.Count > 0)
                        {
                            foreach (var fi in list)
                            {
                                string sizeStr = fi.Length > 1024 * 1024
                                    ? $"{fi.Length / (1024.0 * 1024.0):F2} MB"
                                    : $"{fi.Length / 1024.0:F1} KB";

                                string typeName = "Tự động xoay vòng";
                                if (fi.Name.Contains("manual"))
                                    typeName = "Thủ công";
                                else if (fi.Name.Contains("startup"))
                                    typeName = "Khởi động";

                                dgvBackups.Rows.Add(fi.Name, fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"), sizeStr, typeName, fi.FullName);
                            }
                            if (dgvBackups.Rows.Count > 0)
                            {
                                dgvBackups.Rows[0].Selected = true;
                            }
                        }
                    }
                    catch { }
                };

                loadData();

                // 4. Xử lý logic khôi phục từ dòng đang chọn
                Action executeRestoreSelected = () =>
                {
                    if (dgvBackups.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(dialog, "Vui lòng chọn 1 bản sao lưu trong danh sách.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var selectedRow = dgvBackups.SelectedRows[0];
                    string fileName = selectedRow.Cells[0].Value?.ToString() ?? "";
                    string fileTime = selectedRow.Cells[1].Value?.ToString() ?? "";
                    string fileSize = selectedRow.Cells[2].Value?.ToString() ?? "";
                    string fullPath = selectedRow.Cells[4].Value?.ToString() ?? "";

                    if (string.IsNullOrEmpty(fullPath) || !File.Exists(fullPath))
                    {
                        MessageBox.Show(dialog, "Tệp sao lưu không còn tồn tại trên đĩa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult confirm = MessageBox.Show(dialog,
                        $"Bạn có chắc chắn muốn khôi phục database từ bản sao lưu:\n\n" +
                        $"• Tệp: {fileName}\n" +
                        $"• Thời gian: {fileTime}\n" +
                        $"• Dung lượng: {fileSize}\n\n" +
                        $"LƯU Ý AN TOÀN:\n" +
                        $"- Hệ thống sẽ tự động tạo 1 bản sao dự phòng (.sqlite.bak) của dữ liệu hiện tại trước khi ghi đè.\n" +
                        $"- Sau khi khôi phục, danh sách tài khoản sẽ được tự động tải lại.",
                        "Xác Nhận Khôi Phục Database",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm != DialogResult.Yes) return;

                    Cursor.Current = Cursors.WaitCursor;
                    bool ok = DatabaseAutoBackupHub.RestoreBackup(fullPath, out string error);
                    Cursor.Current = Cursors.Default;

                    if (ok)
                    {
                        MessageBox.Show(dialog,
                            "Khôi phục cơ sở dữ liệu thành công!\nĐang đồng bộ dữ liệu...",
                            "Thành Công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        try
                        {
                            if (this.btnLoadAcc != null)
                            {
                                this.btnLoadAcc.PerformClick();
                            }
                            else
                            {
                                this.E48D7F88(null, null);
                            }
                        }
                        catch { }

                        dialog.DialogResult = DialogResult.OK;
                        dialog.Close();
                    }
                    else
                    {
                        MessageBox.Show(dialog,
                            "Khôi phục database thất bại:\n\n" + error,
                            "Lỗi Khôi Phục",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };

                btnRestore.Click += (s, e) => executeRestoreSelected();
                dgvBackups.CellDoubleClick += (s, e) =>
                {
                    if (e.RowIndex >= 0) executeRestoreSelected();
                };

                btnRefresh.Click += (s, e) => loadData();

                btnOpenFolder.Click += (s, e) =>
                {
                    try
                    {
                        string bDir = DatabaseAutoBackupHub.GetBackupDirectory();
                        if (Directory.Exists(bDir)) Process.Start("explorer.exe", bDir);
                    }
                    catch { }
                };

                btnBrowse.Click += (s, e) =>
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Title = "Chọn tệp database SQLite để khôi phục";
                        ofd.Filter = "SQLite Database (*.sqlite;*.db;*.bak)|*.sqlite;*.db;*.bak|All files (*.*)|*.*";
                        ofd.InitialDirectory = DatabaseAutoBackupHub.GetBackupDirectory();

                        if (ofd.ShowDialog(dialog) == DialogResult.OK && File.Exists(ofd.FileName))
                        {
                            DialogResult confirm = MessageBox.Show(dialog,
                                $"Bạn có chắc chắn muốn khôi phục database từ tệp bên ngoài:\n\n{ofd.FileName}\n\n" +
                                $"Hệ thống sẽ tự động tạo bản sao lưu dữ liệu hiện tại trước khi ghi đè.",
                                "Xác Nhận Khôi Phục File Ngoài",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (confirm == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                bool ok = DatabaseAutoBackupHub.RestoreBackup(ofd.FileName, out string error);
                                Cursor.Current = Cursors.Default;

                                if (ok)
                                {
                                    MessageBox.Show(dialog, "Khôi phục cơ sở dữ liệu thành công!\nĐang đồng bộ dữ liệu...", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    try
                                    {
                                        if (this.btnLoadAcc != null) this.btnLoadAcc.PerformClick();
                                        else this.E48D7F88(null, null);
                                    }
                                    catch { }
                                    dialog.DialogResult = DialogResult.OK;
                                    dialog.Close();
                                }
                                else
                                {
                                    MessageBox.Show(dialog, "Khôi phục database thất bại:\n\n" + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                };

                btnClose.Click += (s, e) => dialog.Close();

                dialog.Controls.Add(dgvBackups);
                dialog.Controls.Add(pnlBottom);
                dialog.Controls.Add(pnlHeader);

                dialog.ShowDialog(this);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Không thể mở hộp thoại khôi phục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Vẽ biểu tượng Database Backup dự phòng chuẩn Vector GDI+ nếu không lấy được ảnh từ resource.
    /// </summary>
    private static Image DrawDatabaseBackupIconFallback(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Transparent);

            using (Brush brush = new SolidBrush(Color.FromArgb(37, 99, 235)))
            using (Pen pen = new Pen(Color.FromArgb(29, 78, 216), 1.2f))
            {
                // Đĩa 1 (Đỉnh)
                g.FillEllipse(brush, 2, 2, width - 5, 4);
                g.DrawEllipse(pen, 2, 2, width - 5, 4);

                // Đĩa 2 (Giữa)
                g.FillRectangle(brush, 2, 4, width - 4, 4);
                g.DrawLine(pen, 2, 4, 2, 8);
                g.DrawLine(pen, width - 3, 4, width - 3, 8);
                g.DrawArc(pen, 2, 5, width - 5, 4, 0, 180);

                // Đĩa 3 (Đáy)
                g.FillRectangle(brush, 2, 8, width - 4, 4);
                g.DrawLine(pen, 2, 8, 2, 12);
                g.DrawLine(pen, width - 3, 8, width - 3, 12);
                g.DrawArc(pen, 2, 9, width - 5, 4, 0, 180);
            }
        }
        return bmp;
    }
}
