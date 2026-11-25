using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Partial class fMain: Tích hợp Bộ lọc & Tìm kiếm tức thì theo thời gian thực (Live Search & Filter Engine)
/// - Lọc theo thời gian thực khi gõ (Real-time live search with 200ms debounce).
/// - Hỗ trợ lọc theo cột được chọn (UID, Tên, Mail, v.v.) hoặc Tất cả các cột đồng thời.
/// - Nhấn ESC trong ô tìm kiếm để xóa nội dung và khôi phục toàn bộ danh sách tức thì.
/// - Tự động cập nhật số lượng kết quả trùng khớp trên thanh trạng thái.
/// </summary>
public partial class fMain
{
    private System.Windows.Forms.Timer _liveSearchTimer;

    /// <summary>
    /// Khởi tạo và thiết lập các sự kiện cho cơ chế tìm kiếm & lọc tức thì.
    /// </summary>
    public void SetupLiveSearchFeatures()
    {
        try
        {
            if (this.txbSearch == null) return;

            // Timer debounce tránh giật lag khi gõ nhanh
            if (_liveSearchTimer == null)
            {
                _liveSearchTimer = new System.Windows.Forms.Timer();
                _liveSearchTimer.Interval = 200;
                _liveSearchTimer.Tick += (s, e) =>
                {
                    _liveSearchTimer.Stop();
                    ApplyLiveFilter();
                };
            }

            // Bắt sự kiện gõ ký tự để lọc thời gian thực
            this.txbSearch.TextChanged -= TxbSearch_TextChanged;
            this.txbSearch.TextChanged += TxbSearch_TextChanged;

            // Bắt sự kiện phím ESC để xóa tìm kiếm nhanh
            this.txbSearch.KeyDown -= TxbSearch_KeyDown;
            this.txbSearch.KeyDown += TxbSearch_KeyDown;

            // Bắt sự kiện đổi kiểu tìm kiếm trên combobox
            if (this.cbbSearch != null)
            {
                this.cbbSearch.SelectedIndexChanged -= CbbSearch_SelectedIndexChanged;
                this.cbbSearch.SelectedIndexChanged += CbbSearch_SelectedIndexChanged;
            }
        }
        catch { }
    }

    private void TxbSearch_TextChanged(object sender, EventArgs e)
    {
        if (_liveSearchTimer != null)
        {
            _liveSearchTimer.Stop();
            _liveSearchTimer.Start();
        }
    }

    private void TxbSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            if (this.txbSearch != null)
            {
                this.txbSearch.Text = "";
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    private void CbbSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.txbSearch != null && !string.IsNullOrEmpty(this.txbSearch.Text))
        {
            ApplyLiveFilter();
        }
    }

    /// <summary>
    /// Thực hiện lọc toàn bộ các dòng trên DataGridView theo từ khóa tìm kiếm.
    /// </summary>
    public void ApplyLiveFilter()
    {
        try
        {
            if (this.F5325785 == null || this.txbSearch == null) return;

            string query = this.txbSearch.Text.Trim();
            string normQuery = Commom.EB835717(query.ToLowerInvariant());

            string selectedCol = "";
            if (this.cbbSearch != null && this.cbbSearch.SelectedValue != null)
            {
                selectedCol = this.cbbSearch.SelectedValue.ToString();
            }

            this.F5325785.SuspendLayout();
            try
            {
                this.F5325785.CurrentCell = null;
            }
            catch { }

            int visibleCount = 0;
            int totalCount = this.F5325785.RowCount;

            if (string.IsNullOrEmpty(normQuery))
            {
                // Khôi phục hiển thị toàn bộ các dòng
                for (int i = 0; i < totalCount; i++)
                {
                    this.F5325785.Rows[i].Visible = true;
                    visibleCount++;
                }
            }
            else
            {
                for (int i = 0; i < totalCount; i++)
                {
                    bool isMatch = false;
                    DataGridViewRow row = this.F5325785.Rows[i];

                    if (!string.IsNullOrEmpty(selectedCol) && selectedCol != "all" && this.F5325785.Columns.Contains(selectedCol))
                    {
                        object val = row.Cells[selectedCol].Value;
                        if (val != null)
                        {
                            string cellText = Commom.EB835717(val.ToString().ToLowerInvariant());
                            if (cellText.Contains(normQuery))
                            {
                                isMatch = true;
                            }
                        }
                    }
                    else
                    {
                        // Tìm kiếm trên tất cả các cột chính
                        string[] targetCols = new string[] { "cUid", "cName", "cEmail", "cProxy", "cStatus", "cInfo", "cKichBan", "cThumuc", "cGhiChu" };
                        foreach (string colName in targetCols)
                        {
                            if (this.F5325785.Columns.Contains(colName))
                            {
                                object val = row.Cells[colName].Value;
                                if (val != null)
                                {
                                    string cellText = Commom.EB835717(val.ToString().ToLowerInvariant());
                                    if (cellText.Contains(normQuery))
                                    {
                                        isMatch = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    row.Visible = isMatch;
                    if (isMatch)
                    {
                        visibleCount++;
                    }
                }
            }

            this.F5325785.ResumeLayout();

            // Cập nhật số lượng hiển thị trên thanh trạng thái
            try
            {
                if (this.lblCountTotal != null)
                {
                    if (string.IsNullOrEmpty(normQuery))
                    {
                        this.lblCountTotal.Text = totalCount.ToString();
                    }
                    else
                    {
                        this.lblCountTotal.Text = $"{visibleCount}/{totalCount}";
                    }
                }
            }
            catch { }
        }
        catch { }
    }
}
