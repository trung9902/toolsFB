using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// Định nghĩa các kiểu chọn nhanh tài khoản
/// </summary>
public enum QuickSelectType
{
    Strong,     // Nick Trâu (>=80đ)
    Weak,       // Nick Yếu (<50đ)
    Live,       // Nick Live
    Checkpoint  // Nick Checkpoint
}

/// <summary>
/// Bộ máy đánh giá logic chọn nhanh tài khoản theo Trust Score và Trạng thái
/// Hỗ trợ Unit Test và tái sử dụng thuật toán
/// </summary>
public static class QuickSelectorEvaluator
{
    /// <summary>
    /// Trích xuất điểm Trust Score (0-100) từ chuỗi ghi chú (ví dụ: [Trust 85★ Trâu] -> 85)
    /// </summary>
    public static int? ExtractTrustScore(string note)
    {
        if (string.IsNullOrEmpty(note)) return null;

        // 1. Dạng chuẩn huy hiệu: [Trust 85★ Trâu] hoặc [Trust 85]
        var match = Regex.Match(note, @"\[Trust\s*(\d+)");
        if (match.Success && int.TryParse(match.Groups[1].Value, out int score1))
        {
            return score1;
        }

        // 2. Dạng văn bản: Trust: 85 hoặc Trust 85
        match = Regex.Match(note, @"Trust\s*(?:Score)?\s*[:=\s]\s*(\d+)", RegexOptions.IgnoreCase);
        if (match.Success && int.TryParse(match.Groups[1].Value, out int score2))
        {
            return score2;
        }

        // 3. Dạng số điểm: 85đ hoặc 85 điểm
        match = Regex.Match(note, @"(\d+)\s*(?:đ|điểm|pt|pts)\b", RegexOptions.IgnoreCase);
        if (match.Success && int.TryParse(match.Groups[1].Value, out int score3))
        {
            return score3;
        }

        return null;
    }

    /// <summary>
    /// Đánh giá tiêu chí Nick Trâu: Trust score >= 80 hoặc ghi chú chứa "Trâu"
    /// </summary>
    public static bool EvaluateStrongCriteria(string note, int dynamicScore = 0)
    {
        if (!string.IsNullOrEmpty(note))
        {
            if (note.IndexOf("Trâu", StringComparison.OrdinalIgnoreCase) >= 0 ||
                note.IndexOf("trau", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            if (note.IndexOf("Yếu", StringComparison.OrdinalIgnoreCase) >= 0 ||
                note.IndexOf("yeu", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return false;
            }

            int? score = ExtractTrustScore(note);
            if (score.HasValue)
            {
                return score.Value >= 80;
            }
        }

        return dynamicScore >= 80;
    }

    /// <summary>
    /// Đánh giá tiêu chí Nick Yếu: Trust score < 50 hoặc ghi chú chứa "Yếu"
    /// </summary>
    public static bool EvaluateWeakCriteria(string note, int dynamicScore = 0)
    {
        if (!string.IsNullOrEmpty(note))
        {
            if (note.IndexOf("Trâu", StringComparison.OrdinalIgnoreCase) >= 0 ||
                note.IndexOf("trau", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return false;
            }

            if (note.IndexOf("Yếu", StringComparison.OrdinalIgnoreCase) >= 0 ||
                note.IndexOf("yeu", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            int? score = ExtractTrustScore(note);
            if (score.HasValue)
            {
                return score.Value < 50;
            }
        }

        return dynamicScore < 50;
    }

    /// <summary>
    /// Đánh giá tiêu chí Nick Live: Trạng thái chứa "Live", "Hoạt động", hoặc không chứa "die", "checkpoint", "282", "956"
    /// </summary>
    public static bool EvaluateLiveCriteria(string status)
    {
        if (string.IsNullOrEmpty(status))
        {
            return true;
        }

        string statusLower = status.ToLowerInvariant();

        bool isBad = statusLower.Contains("checkpoint") ||
                     statusLower.Contains("282") ||
                     statusLower.Contains("956") ||
                     statusLower.Contains("die") ||
                     statusLower.Contains("khóa") ||
                     statusLower.Contains("khoa") ||
                     statusLower.Contains("changed pass") ||
                     statusLower.Contains("vô hiệu hóa") ||
                     statusLower.Contains("vo hieu hoa");

        if (isBad)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Đánh giá tiêu chí Nick Checkpoint: Trạng thái chứa "checkpoint", "282", "956", "die", "khóa"
    /// </summary>
    public static bool EvaluateCheckpointCriteria(string status)
    {
        if (string.IsNullOrEmpty(status))
        {
            return false;
        }

        string statusLower = status.ToLowerInvariant();

        return statusLower.Contains("checkpoint") ||
               statusLower.Contains("282") ||
               statusLower.Contains("956") ||
               statusLower.Contains("die") ||
               statusLower.Contains("khóa") ||
               statusLower.Contains("khoa") ||
               statusLower.Contains("changed pass") ||
               statusLower.Contains("vô hiệu hóa") ||
               statusLower.Contains("vo hieu hoa");
    }

    #region Tạo biểu tượng vector GDI+ (Clean Menu Icons)

    /// <summary>
    /// Tạo icon khiên xanh lá kèm ngôi sao vàng cho "Nick Trâu (>=80đ)"
    /// </summary>
    public static Image CreateStrongIcon()
    {
        Bitmap bmp = new Bitmap(16, 16);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Hình chiếc khiên xanh
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(2f, 1f, 14f, 1f);
                path.AddBezier(14f, 1f, 14f, 9f, 8f, 14f, 8f, 15f);
                path.AddBezier(8f, 15f, 2f, 9f, 2f, 1f, 2f, 1f);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(16, 185, 129)))
                {
                    g.FillPath(brush, path);
                }
                using (Pen pen = new Pen(Color.FromArgb(5, 150, 105), 1f))
                {
                    g.DrawPath(pen, path);
                }
            }

            // Ngôi sao vàng ở trung tâm
            using (SolidBrush starBrush = new SolidBrush(Color.FromArgb(254, 240, 138)))
            {
                float cx = 8f, cy = 6.5f, r = 3.2f;
                PointF[] pts = new PointF[10];
                for (int i = 0; i < 10; i++)
                {
                    double a = i * Math.PI / 5.0 - Math.PI / 2.0;
                    float rad = (i % 2 == 0) ? r : r * 0.45f;
                    pts[i] = new PointF(cx + (float)(Math.Cos(a) * rad), cy + (float)(Math.Sin(a) * rad));
                }
                g.FillPolygon(starBrush, pts);
            }
        }
        return bmp;
    }

    /// <summary>
    /// Tạo icon tam giác cảnh báo màu cam cho "Nick Yếu (<50đ)"
    /// </summary>
    public static Image CreateWeakIcon()
    {
        Bitmap bmp = new Bitmap(16, 16);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            PointF[] tri = new PointF[]
            {
                new PointF(8f, 1.5f),
                new PointF(15f, 14f),
                new PointF(1f, 14f)
            };

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(245, 158, 11)))
            {
                g.FillPolygon(brush, tri);
            }
            using (Pen pen = new Pen(Color.FromArgb(217, 119, 6), 1f))
            {
                g.DrawPolygon(pen, tri);
            }

            // Dấu chấm than '!'
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            using (Font font = new Font("Tahoma", 7.5f, FontStyle.Bold, GraphicsUnit.Point))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString("!", font, textBrush, new RectangleF(1f, 3.5f, 14f, 11f), sf);
            }
        }
        return bmp;
    }

    /// <summary>
    /// Tạo icon hình tròn xanh lá kèm dấu tích trắng cho "Nick Live"
    /// </summary>
    public static Image CreateLiveIcon()
    {
        Bitmap bmp = new Bitmap(16, 16);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(34, 197, 94)))
            {
                g.FillEllipse(brush, 1, 1, 14, 14);
            }
            using (Pen pen = new Pen(Color.FromArgb(22, 163, 74), 1f))
            {
                g.DrawEllipse(pen, 1, 1, 14, 14);
            }

            using (Pen checkPen = new Pen(Color.White, 2f))
            {
                checkPen.StartCap = LineCap.Round;
                checkPen.EndCap = LineCap.Round;
                g.DrawLine(checkPen, 4.5f, 8f, 7f, 10.5f);
                g.DrawLine(checkPen, 7f, 10.5f, 11.5f, 5.5f);
            }
        }
        return bmp;
    }

    /// <summary>
    /// Tạo icon hình tròn đỏ kèm chữ X trắng cho "Nick Checkpoint"
    /// </summary>
    public static Image CreateCheckpointIcon()
    {
        Bitmap bmp = new Bitmap(16, 16);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(239, 68, 68)))
            {
                g.FillEllipse(brush, 1, 1, 14, 14);
            }
            using (Pen pen = new Pen(Color.FromArgb(220, 38, 38), 1f))
            {
                g.DrawEllipse(pen, 1, 1, 14, 14);
            }

            using (Pen xPen = new Pen(Color.White, 2f))
            {
                xPen.StartCap = LineCap.Round;
                xPen.EndCap = LineCap.Round;
                g.DrawLine(xPen, 5f, 5f, 11f, 11f);
                g.DrawLine(xPen, 11f, 5f, 5f, 11f);
            }
        }
        return bmp;
    }

    #endregion
}

/// <summary>
/// Partial class fMain - Mở rộng menu "Chọn" chuột phải (toolStripMenuItem_1)
/// Bổ sung các tính năng chọn nhanh tài khoản theo Trust Score và Trạng thái:
/// - Nick Trâu (>=80đ)
/// - Nick Yếu (<50đ)
/// - Nick Live
/// - Nick Checkpoint
/// </summary>
public partial class fMain
{
    private ToolStripSeparator sepQuickSelector;
    private ToolStripMenuItem mnuSelectStrong;
    private ToolStripMenuItem mnuSelectWeak;
    private ToolStripMenuItem mnuSelectLive;
    private ToolStripMenuItem mnuSelectCheckpoint;

    /// <summary>
    /// Khởi tạo và gắn các tính năng chọn nhanh vào menu "Chọn" (toolStripMenuItem_1).
    /// </summary>
    public void SetupQuickSelectorFeatures()
    {
        try
        {
            if (this.toolStripMenuItem_1 == null) return;

            // Kiểm tra tránh khởi tạo trùng lặp
            if (this.mnuSelectStrong != null && this.toolStripMenuItem_1.DropDownItems.Contains(this.mnuSelectStrong))
            {
                return;
            }

            Font menuFont = this.toolStripMenuItem_1.Font ?? this.Font;

            // 1. Phân cách nhóm chức năng chọn nhanh
            sepQuickSelector = new ToolStripSeparator
            {
                Name = "sepQuickSelector"
            };

            // 2. Menu con: Nick Trâu (>=80đ)
            mnuSelectStrong = new ToolStripMenuItem
            {
                Name = "mnuSelectStrong",
                Text = "Nick Trâu (>=80đ)",
                Font = menuFont,
                Image = QuickSelectorEvaluator.CreateStrongIcon(),
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Tích chọn toàn bộ dòng có điểm Trust >= 80 hoặc ghi chú chứa 'Trâu' (Bỏ tích các dòng khác)"
            };
            mnuSelectStrong.Click += (s, e) => QuickSelectAccounts(QuickSelectType.Strong);

            // 3. Menu con: Nick Yếu (<50đ)
            mnuSelectWeak = new ToolStripMenuItem
            {
                Name = "mnuSelectWeak",
                Text = "Nick Yếu (<50đ)",
                Font = menuFont,
                Image = QuickSelectorEvaluator.CreateWeakIcon(),
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Tích chọn toàn bộ dòng có điểm Trust < 50 hoặc ghi chú chứa 'Yếu' (Bỏ tích các dòng khác)"
            };
            mnuSelectWeak.Click += (s, e) => QuickSelectAccounts(QuickSelectType.Weak);

            // 4. Menu con: Nick Live
            mnuSelectLive = new ToolStripMenuItem
            {
                Name = "mnuSelectLive",
                Text = "Nick Live",
                Font = menuFont,
                Image = QuickSelectorEvaluator.CreateLiveIcon(),
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Tích chọn các dòng có trạng thái Live, Hoạt động (Bỏ tích các dòng khác)"
            };
            mnuSelectLive.Click += (s, e) => QuickSelectAccounts(QuickSelectType.Live);

            // 5. Menu con: Nick Checkpoint
            mnuSelectCheckpoint = new ToolStripMenuItem
            {
                Name = "mnuSelectCheckpoint",
                Text = "Nick Checkpoint",
                Font = menuFont,
                Image = QuickSelectorEvaluator.CreateCheckpointIcon(),
                ImageScaling = ToolStripItemImageScaling.None,
                ToolTipText = "Tích chọn các dòng có trạng thái Checkpoint (282, 956), Die, Bị khóa (Bỏ tích các dòng khác)"
            };
            mnuSelectCheckpoint.Click += (s, e) => QuickSelectAccounts(QuickSelectType.Checkpoint);

            // Thêm các mục vào menu "Chọn"
            this.toolStripMenuItem_1.DropDownItems.Add(sepQuickSelector);
            this.toolStripMenuItem_1.DropDownItems.Add(mnuSelectStrong);
            this.toolStripMenuItem_1.DropDownItems.Add(mnuSelectWeak);
            this.toolStripMenuItem_1.DropDownItems.Add(mnuSelectLive);
            this.toolStripMenuItem_1.DropDownItems.Add(mnuSelectCheckpoint);
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("SetupQuickSelectorFeatures error: " + ex.Message); } catch { }
        }
    }

    /// <summary>
    /// Thực hiện chọn nhanh tài khoản trên DataGridView theo tiêu chí và cập nhật thanh trạng thái
    /// </summary>
    public void QuickSelectAccounts(QuickSelectType selectType)
    {
        try
        {
            if (this.F5325785 == null || this.F5325785.RowCount == 0)
            {
                return;
            }

            // Kết thúc chỉnh sửa cell nếu đang có cell focus
            try { this.F5325785.EndEdit(); } catch { }

            Func<int, bool> predicate;
            switch (selectType)
            {
                case QuickSelectType.Strong:
                    predicate = IsStrongRow;
                    break;
                case QuickSelectType.Weak:
                    predicate = IsWeakRow;
                    break;
                case QuickSelectType.Live:
                    predicate = IsLiveRow;
                    break;
                case QuickSelectType.Checkpoint:
                    predicate = IsCheckpointRow;
                    break;
                default:
                    return;
            }

            int rowCount = this.F5325785.RowCount;
            int selectedCount = 0;

            // Tối ưu hiệu năng: Suspend layout trong lúc quét và cập nhật cell
            this.F5325785.SuspendLayout();
            try
            {
                for (int i = 0; i < rowCount; i++)
                {
                    bool match = predicate(i);
                    this.F5325785.Rows[i].Cells["cChose"].Value = match;
                    if (match)
                    {
                        selectedCount++;
                    }
                }
            }
            finally
            {
                this.F5325785.ResumeLayout();
            }

            // Cập nhật bộ đếm dòng được chọn trên thanh trạng thái (status bar / lblCountSelect)
            EA1B25A9(selectedCount);
            if (this.lblCountSelect != null)
            {
                this.lblCountSelect.Text = selectedCount.ToString();
            }
        }
        catch (Exception ex)
        {
            try { Commom.smethod_49("QuickSelectAccounts error: " + ex.Message); } catch { }
        }
    }

    #region Kiểm tra tiêu chí từng dòng (Row Level Evaluators)

    /// <summary>
    /// Kiểm tra nick Trâu: Trust score >= 80 hoặc ghi chú chứa "Trâu"
    /// </summary>
    private bool IsStrongRow(int rowIndex)
    {
        try
        {
            string note = GetRowNote(rowIndex);
            int dynamicScore = string.IsNullOrEmpty(note) ? CalculateDynamicScore(rowIndex) : 0;
            return QuickSelectorEvaluator.EvaluateStrongCriteria(note, dynamicScore);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Kiểm tra nick Yếu: Trust score < 50 hoặc ghi chú chứa "Yếu"
    /// </summary>
    private bool IsWeakRow(int rowIndex)
    {
        try
        {
            string note = GetRowNote(rowIndex);
            int dynamicScore = string.IsNullOrEmpty(note) ? CalculateDynamicScore(rowIndex) : 0;
            return QuickSelectorEvaluator.EvaluateWeakCriteria(note, dynamicScore);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Kiểm tra nick Live: trạng thái chứa "Live", "Hoạt động", hoặc không chứa "die", "checkpoint", "282", "956"
    /// </summary>
    private bool IsLiveRow(int rowIndex)
    {
        try
        {
            string status = GetRowStatus(rowIndex);
            return QuickSelectorEvaluator.EvaluateLiveCriteria(status);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Kiểm tra nick Checkpoint: trạng thái chứa "checkpoint", "282", "956", "die", "khóa"
    /// </summary>
    private bool IsCheckpointRow(int rowIndex)
    {
        try
        {
            string status = GetRowStatus(rowIndex);
            return QuickSelectorEvaluator.EvaluateCheckpointCriteria(status);
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Trích xuất dữ liệu dòng (Data Extraction Helpers)

    /// <summary>
    /// Lấy chuỗi ghi chú của dòng từ cGhiChu, cNote hoặc cInfo
    /// </summary>
    private string GetRowNote(int rowIndex)
    {
        try
        {
            string note = "";
            if (this.F5325785.Columns.Contains("cGhiChu"))
            {
                note = F6061E95(rowIndex, "cGhiChu") ?? "";
            }
            if (string.IsNullOrEmpty(note) && this.F5325785.Columns.Contains("cNote"))
            {
                note = F6061E95(rowIndex, "cNote") ?? "";
            }
            if (string.IsNullOrEmpty(note) && this.F5325785.Columns.Contains("cInfo"))
            {
                string info = F6061E95(rowIndex, "cInfo") ?? "";
                if (info.Contains("Trust") || info.Contains("Trâu") || info.Contains("Yếu"))
                {
                    note = info;
                }
            }
            return note.Trim();
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Lấy chuỗi trạng thái của dòng từ cStatus, cStatus282 hoặc cInfo
    /// </summary>
    private string GetRowStatus(int rowIndex)
    {
        try
        {
            string status = "";
            if (this.F5325785.Columns.Contains("cStatus"))
            {
                status = F6061E95(rowIndex, "cStatus") ?? "";
            }

            string status282 = "";
            if (this.F5325785.Columns.Contains("cStatus282"))
            {
                status282 = F6061E95(rowIndex, "cStatus282") ?? "";
            }

            string combined = (status + " " + status282).Trim();
            if (string.IsNullOrEmpty(combined) && this.F5325785.Columns.Contains("cInfo"))
            {
                string info = F6061E95(rowIndex, "cInfo") ?? "";
                if (!info.StartsWith("[Trust"))
                {
                    combined = info.Trim();
                }
            }
            return combined;
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Trích xuất điểm Trust Score (0-100) từ chuỗi ghi chú (ví dụ: [Trust 85★ Trâu] -> 85)
    /// </summary>
    private int? ExtractTrustScore(string note)
    {
        if (string.IsNullOrEmpty(note)) return null;

        // 1. Dạng chuẩn huy hiệu: [Trust 85★ Trâu] hoặc [Trust 85]
        var match = Regex.Match(note, @"\[Trust\s*(\d+)");
        if (match.Success && int.TryParse(match.Groups[1].Value, out int score1))
        {
            return score1;
        }

        // 2. Dạng văn bản: Trust: 85 hoặc Trust 85
        match = Regex.Match(note, @"Trust\s*(?:Score)?\s*[:=\s]\s*(\d+)", RegexOptions.IgnoreCase);
        if (match.Success && int.TryParse(match.Groups[1].Value, out int score2))
        {
            return score2;
        }

        // 3. Dạng số điểm: 85đ hoặc 85 điểm
        match = Regex.Match(note, @"(\d+)\s*(?:đ|điểm|pt|pts)\b", RegexOptions.IgnoreCase);
        if (match.Success && int.TryParse(match.Groups[1].Value, out int score3))
        {
            return score3;
        }

        return null;
    }

    /// <summary>
    /// Tính toán Trust Score động bằng AccountHealthEngine cho các tài khoản chưa có ghi chú điểm
    /// </summary>
    private int CalculateDynamicScore(int rowIndex)
    {
        try
        {
            string uid = F6061E95(rowIndex, "cUid") ?? "";
            string fa2 = F6061E95(rowIndex, "cFa2") ?? "";
            string cookies = F6061E95(rowIndex, "cCookies") ?? "";
            string email = F6061E95(rowIndex, "cEmail") ?? "";
            string passmail = F6061E95(rowIndex, "cPassMail") ?? "";
            string interactEnd = F6061E95(rowIndex, "cInteractEnd") ?? "";
            string friend = F6061E95(rowIndex, "cFriend") ?? "";

            var res = AccountHealthEngine.Calculate(uid, fa2, cookies, email, passmail, interactEnd, friend);
            return res != null ? res.Score : 0;
        }
        catch
        {
            return 0;
        }
    }

    #endregion
}
