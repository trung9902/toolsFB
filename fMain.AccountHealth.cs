using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain - Tích hợp Hệ thống Chẩn đoán Độ trâu nick & Chấm điểm Trust Score (0-100)
/// Tự động cập nhật huy hiệu, khuyến nghị an toàn vào DataGridView và lưu xuống SQLite.
/// </summary>
public partial class fMain
{
    private ToolStripMenuItem mnuAccountHealth;

    /// <summary>
    /// Khởi tạo và đăng ký menu Chẩn đoán Trust Score trên ContextMenuStrip tài khoản (ctmsAcc).
    /// </summary>
    public void SetupAccountHealthFeatures()
    {
        try
        {
            if (this.ctmsAcc == null) return;

            // Tránh tạo trùng lặp
            if (mnuAccountHealth != null && this.ctmsAcc.Items.Contains(mnuAccountHealth))
            {
                return;
            }

            Image shieldIcon = LoadCustomMenuIcon(
                "shield.png",
                16,
                16,
                DrawShieldIconFallback
            );

            mnuAccountHealth = new ToolStripMenuItem
            {
                Name = "mnuAccountHealth",
                Text = "Check Trust",
                Font = this.toolStripMenuItem_1 != null ? this.toolStripMenuItem_1.Font : this.Font,
                Image = shieldIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                ToolTipText = "Chẩn đoán độ trâu nick / Trust Score (0-100)"
            };

            // 1. Menu con: Chẩn đoán tài khoản đang chọn
            var mnuDiagnoseSelected = new ToolStripMenuItem
            {
                Name = "mnuDiagnoseSelected",
                Text = "Đang chọn",
                Font = mnuAccountHealth.Font,
                Image = shieldIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Quét và chấm điểm các tài khoản được tick chọn hoặc bôi đen"
            };
            mnuDiagnoseSelected.Click += (s, e) => DiagnoseAccountsTrustScore(onlySelected: true);

            // 2. Menu con: Chẩn đoán toàn bộ danh sách
            var mnuDiagnoseAll = new ToolStripMenuItem
            {
                Name = "mnuDiagnoseAll",
                Text = "Tất cả",
                Font = mnuAccountHealth.Font,
                Image = shieldIcon,
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Quét và chấm điểm toàn bộ tài khoản đang hiển thị trên bảng"
            };
            mnuDiagnoseAll.Click += (s, e) => DiagnoseAccountsTrustScore(onlySelected: false);

            // 3. Menu con: Xem tiêu chí
            var mnuHelpCriteria = new ToolStripMenuItem
            {
                Name = "mnuHelpCriteria",
                Text = "Tiêu chí chấm điểm...",
                Font = mnuAccountHealth.Font,
                ToolTipText = "Xem chi tiết bảng điểm và phân hạng Trâu / Ổn định / Yếu"
            };
            mnuHelpCriteria.Click += (s, e) => ShowTrustScoreCriteriaDialog();

            mnuAccountHealth.DropDownItems.Add(mnuDiagnoseSelected);
            mnuAccountHealth.DropDownItems.Add(mnuDiagnoseAll);
            mnuAccountHealth.DropDownItems.Add(new ToolStripSeparator());
            mnuAccountHealth.DropDownItems.Add(mnuHelpCriteria);

            // Click trực tiếp vào menu cha
            mnuAccountHealth.Click += (s, e) =>
            {
                DiagnoseAccountsTrustScore(onlySelected: true);
            };

            // Gắn "Check Trust" vào menu con "Kiểm tra" (A492F617) ở vị trí đầu tiên
            if (this.A492F617 != null && !this.A492F617.DropDownItems.Contains(mnuAccountHealth))
            {
                this.A492F617.DropDownItems.Insert(0, mnuAccountHealth);
                this.A492F617.DropDownItems.Insert(1, new ToolStripSeparator());
            }
            else if (!this.ctmsAcc.Items.Contains(mnuAccountHealth))
            {
                this.ctmsAcc.Items.Add(mnuAccountHealth);
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("SetupAccountHealthFeatures error: " + ex.Message); } catch { }
        }
    }

    /// <summary>
    /// Thực hiện chẩn đoán Trust Score cho các dòng tài khoản trên DataGridView
    /// </summary>
    private void DiagnoseAccountsTrustScore(bool onlySelected)
    {
        try
        {
            if (this.F5325785 == null || this.F5325785.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách tài khoản trống, không có tài khoản để chẩn đoán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> targetIndices = new List<int>();

            if (onlySelected)
            {
                // 1. Kiểm tra các dòng được tick chọn (cChose = true)
                for (int i = 0; i < this.F5325785.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.F5325785.Rows[i].Cells["cChose"].Value))
                    {
                        targetIndices.Add(i);
                    }
                }

                // 2. Nếu chưa tick checkbox nào, kiểm tra các dòng đang bôi đen (SelectedRows)
                if (targetIndices.Count == 0 && this.F5325785.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow selRow in this.F5325785.SelectedRows)
                    {
                        targetIndices.Add(selRow.Index);
                    }
                }
            }

            // 3. Nếu vẫn không chọn dòng nào (hoặc onlySelected = false): Quét tất cả các dòng
            if (targetIndices.Count == 0)
            {
                for (int i = 0; i < this.F5325785.Rows.Count; i++)
                {
                    targetIndices.Add(i);
                }
            }

            targetIndices = targetIndices.Distinct().OrderBy(x => x).ToList();

            // Xác định cột hiển thị trên DataGridView: cGhiChu (hoặc cNote / cInfo)
            string noteCol = this.F5325785.Columns.Contains("cGhiChu") ? "cGhiChu" 
                           : (this.F5325785.Columns.Contains("cNote") ? "cNote" : "cInfo");
            string dbCol = (noteCol == "cInfo") ? "info" : "ghiChu";

            // Đảm bảo cột hiển thị để người dùng nhìn thấy kết quả
            if (this.F5325785.Columns.Contains(noteCol) && !this.F5325785.Columns[noteCol].Visible)
            {
                this.F5325785.Columns[noteCol].Visible = true;
            }

            // Chạy tiến trình chẩn đoán trên luồng nền (ThreadPool) đảm bảo an toàn và không đơ giao diện
            ThreadPool.QueueUserWorkItem(_ =>
            {
                int strongCount = 0;
                int normalCount = 0;
                int weakCount = 0;
                int totalProcessed = 0;

                foreach (int rowIndex in targetIndices)
                {
                    try
                    {
                        if (rowIndex < 0 || rowIndex >= this.F5325785.Rows.Count) continue;

                        string id = F6061E95(rowIndex, "cId");
                        string uid = F6061E95(rowIndex, "cUid");
                        string pass = F6061E95(rowIndex, "cPassword");
                        string fa2 = F6061E95(rowIndex, "cFa2");
                        string cookies = F6061E95(rowIndex, "cCookies");
                        string email = F6061E95(rowIndex, "cEmail");
                        string passmail = F6061E95(rowIndex, "cPassMail");
                        string friend = F6061E95(rowIndex, "cFriend");
                        string group = F6061E95(rowIndex, "cGroup");
                        string interactEnd = F6061E95(rowIndex, "cInteractEnd");
                        string status = F6061E95(rowIndex, "cStatus");
                        string info = F6061E95(rowIndex, "cInfo");

                        var input = new AccountHealthInput
                        {
                            Id = id,
                            Uid = uid,
                            Password = pass,
                            Fa2 = fa2,
                            Cookies = cookies,
                            Email = email,
                            PassMail = passmail,
                            FriendCount = friend,
                            GroupCount = group,
                            InteractEnd = interactEnd,
                            Status = status,
                            Info = info
                        };

                        var result = AccountHealthEngine.Calculate(input);

                        switch (result.Tier)
                        {
                            case AccountTier.Strong: strongCount++; break;
                            case AccountTier.Normal: normalCount++; break;
                            case AccountTier.Weak: weakCount++; break;
                        }
                        totalProcessed++;

                        string noteValue = $"{result.ShortBadge} - {result.Recommendation}";

                        // Cập nhật lên DataGridView (thread-safe qua smethod_3)
                        EAB09F19.smethod_3(this.F5325785, rowIndex, noteCol, noteValue);

                        // Cập nhật xuống SQLite database
                        if (!string.IsNullOrEmpty(id))
                        {
                            CommonSQL.UpdateField(id, dbCol, noteValue);
                        }
                    }
                    catch
                    {
                    }
                }

                // Hiển thị thông báo tổng kết trên UI thread
                try
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            try
                            {
                                string summary = $"Đã chẩn đoán thành công {totalProcessed} tài khoản:\n\n" +
                                                 $" • {strongCount} nick Trâu (Score >= 80) -> Sẵn sàng chạy tác vụ nặng (Spam, Share, Kết bạn)\n" +
                                                 $" • {normalCount} nick Ổn định (50 <= Score < 80) -> Nên chạy tác vụ vừa phải, lướt feed\n" +
                                                 $" • {weakCount} nick Yếu (Score < 50) -> Cần chạy Warm-up 3 pha ngay trước khi làm việc";

                                MessageBox.Show(this, summary, "Kết Quả Chẩn Đoán Trust Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                            }
                        });
                    }
                }
                catch
                {
                }
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show("Có lỗi xảy ra khi chẩn đoán tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Hiển thị hộp thoại giải thích chi tiết tiêu chí chấm điểm Trust Score
    /// </summary>
    private void ShowTrustScoreCriteriaDialog()
    {
        string msg = "HỆ THỐNG ĐÁNH GIÁ SỨC KHỎE TÀI KHOẢN (TRUST SCORE 0 - 100)\n\n" +
                     "1. TIÊU CHÍ CHẤM ĐIỂM:\n" +
                     " • Tuổi nick / Định dạng UID:\n" +
                     "   - UID cổ 10000... hoặc UID siêu cổ: +25đ\n" +
                     "   - UID 1000...: +20đ\n" +
                     "   - UID mới 615...: +10đ\n" +
                     " • Bảo mật 2FA Secret Key:\n" +
                     "   - Có 2FA Secret Key: +20đ\n" +
                     "   - Thiếu 2FA: -15đ (nguy cơ checkpoint cao)\n" +
                     " • Tình trạng Cookie:\n" +
                     "   - Cookie có đầy đủ c_user và xs: +20đ\n" +
                     "   - Cookie rỗng: 0đ\n" +
                     " • Email & PassMail:\n" +
                     "   - Có đầy đủ Email và Mật khẩu Mail: +15đ\n" +
                     " • Tình trạng hoạt động gần nhất:\n" +
                     "   - Có ngày tương tác gần nhất: +10đ\n" +
                     " • Bạn bè & Nhóm:\n" +
                     "   - Có số bạn bè > 100 bạn: +10đ\n\n" +
                     "2. PHÂN HẠNG TÀI KHOẢN (ACCOUNT TIER):\n" +
                     " • Tier.Strong (Trâu / VIP) [Score >= 80]:\n" +
                     "   -> Sẵn sàng chạy tác vụ nặng (Spam, Share, Kết bạn)\n" +
                     " • Tier.Normal (Ổn định) [50 <= Score < 80]:\n" +
                     "   -> Nên chạy tác vụ vừa phải, lướt feed\n" +
                     " • Tier.Weak (Yếu / Cần nướng) [Score < 50]:\n" +
                     "   -> Cần chạy Warm-up 3 pha ngay trước khi làm việc";

        MessageBox.Show(this, msg, "Tiêu Chí Chẩn Đoán Trust Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Vẽ biểu tượng chiếc khiên bảo mật fallback cho menu Chẩn đoán Trust Score
    /// </summary>
    private static Image DrawShieldIconFallback(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Hình dạng chiếc khiên
            using (GraphicsPath shieldPath = new GraphicsPath())
            {
                float w = width;
                float h = height;
                shieldPath.AddLine(2f, 2f, w - 2f, 2f);
                shieldPath.AddBezier(w - 2f, 2f, w - 1f, h * 0.65f, w * 0.5f, h * 0.95f, w * 0.5f, h - 1.5f);
                shieldPath.AddBezier(w * 0.5f, h - 1.5f, 1f, h * 0.65f, 2f, 2f, 2f, 2f);
                shieldPath.CloseFigure();

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, height),
                    Color.FromArgb(16, 185, 129),  // Xanh ngọc Emerald
                    Color.FromArgb(5, 150, 105)))
                {
                    g.FillPath(brush, shieldPath);
                }

                using (Pen borderPen = new Pen(Color.FromArgb(4, 120, 87), 1.2f))
                {
                    g.DrawPath(borderPen, shieldPath);
                }
            }

            // Ngôi sao vàng sáng ở trung tâm chiếc khiên
            using (SolidBrush starBrush = new SolidBrush(Color.FromArgb(254, 240, 138)))
            {
                float cx = width / 2f;
                float cy = height * 0.46f;
                float r = width * 0.22f;
                PointF[] starPoints = new PointF[10];
                for (int i = 0; i < 10; i++)
                {
                    double angle = i * Math.PI / 5.0 - Math.PI / 2.0;
                    float radius = (i % 2 == 0) ? r : r * 0.45f;
                    starPoints[i] = new PointF(cx + (float)(Math.Cos(angle) * radius), cy + (float)(Math.Sin(angle) * radius));
                }
                g.FillPolygon(starBrush, starPoints);
            }
        }
        return bmp;
    }
}
