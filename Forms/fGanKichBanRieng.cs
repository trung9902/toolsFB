using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class fGanKichBanRieng : Form
{
    private List<string> _listUids;
    private List<int> _listRowIndices;
    private Action<List<int>, string, string> _onAssignedCallback;

    private Panel pnlHeader;
    private Label lblTitle;
    private Button btnClose;
    private Label lblCount;
    private Label lblScript;
    private ComboBox cbbKichBan;
    private Button btnSave;
    private Button btnRemove;
    private Button btnCancel;
    private Panel pnlMain;

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool DeleteObject(IntPtr hObject);

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
            return cp;
        }
    }

    public fGanKichBanRieng(List<string> listUids, List<int> listRowIndices = null, Action<List<int>, string, string> onAssignedCallback = null)
    {
        _listUids = listUids ?? new List<string>();
        _listRowIndices = listRowIndices ?? new List<int>();
        _onAssignedCallback = onAssignedCallback;

        InitializeComponent();
        LoadKichBan();
    }

    private void InitializeComponent()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Size = new Size(380, 168);
        this.BackColor = Color.FromArgb(203, 213, 225); // Slate-300 outer border
        this.Padding = new Padding(1);
        this.ShowInTaskbar = false;
        this.DoubleBuffered = true;

        // Border Panel Wrapper
        Panel pnlBorder = new Panel();
        pnlBorder.Dock = DockStyle.Fill;
        pnlBorder.BackColor = Color.White;
        this.Controls.Add(pnlBorder);
        pnlMain = pnlBorder;

        // Header Panel - Height 36px
        pnlHeader = new Panel();
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 36;
        pnlHeader.BackColor = Color.White;
        pnlHeader.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
        pnlHeader.Paint += (s, pe) =>
        {
            using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                pe.Graphics.DrawLine(p, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        };
        pnlBorder.Controls.Add(pnlHeader);

        lblTitle = new Label();
        lblTitle.Text = "Gán kịch bản riêng cho tài khoản";
        lblTitle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(16, 9);
        lblTitle.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
        pnlHeader.Controls.Add(lblTitle);

        btnClose = new Button();
        btnClose.Text = "✕";
        btnClose.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        btnClose.Size = new Size(28, 24);
        btnClose.Location = new Point(342, 6);
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.BackColor = Color.White;
        btnClose.ForeColor = Color.FromArgb(100, 116, 139);
        btnClose.Cursor = Cursors.Hand;
        try
        {
            IntPtr hrgn = CreateRoundRectRgn(0, 0, btnClose.Width + 1, btnClose.Height + 1, 4, 4);
            btnClose.Region = Region.FromHrgn(hrgn);
            DeleteObject(hrgn);
        }
        catch { }
        btnClose.MouseEnter += (s, e) => { btnClose.BackColor = Color.FromArgb(239, 68, 68); btnClose.ForeColor = Color.White; };
        btnClose.MouseLeave += (s, e) => { btnClose.BackColor = Color.White; btnClose.ForeColor = Color.FromArgb(100, 116, 139); };
        btnClose.Click += (s, e) => this.Close();
        pnlHeader.Controls.Add(btnClose);

        // Body Elements
        // Dòng 1: Label số lượng tài khoản (y = 48, x = 16)
        lblCount = new Label();
        lblCount.Text = $"Đang chọn: {_listUids.Count} tài khoản";
        lblCount.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        lblCount.ForeColor = Color.FromArgb(37, 99, 235);
        lblCount.Location = new Point(16, 48);
        lblCount.AutoSize = true;
        pnlBorder.Controls.Add(lblCount);

        // Dòng 2: Label "Chọn kịch bản:" (y = 78, x = 16)
        lblScript = new Label();
        lblScript.Text = "Chọn kịch bản:";
        lblScript.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
        lblScript.ForeColor = Color.FromArgb(71, 85, 105);
        lblScript.Location = new Point(16, 78);
        lblScript.AutoSize = true;
        pnlBorder.Controls.Add(lblScript);

        // ComboBox kịch bản: (y = 75, x = 108), Size(254, 25)
        cbbKichBan = new ComboBox();
        cbbKichBan.DropDownStyle = ComboBoxStyle.DropDownList;
        cbbKichBan.Font = new Font("Segoe UI", 9.5f);
        cbbKichBan.Location = new Point(108, 75);
        cbbKichBan.Size = new Size(254, 25);
        cbbKichBan.Cursor = Cursors.Hand;
        pnlBorder.Controls.Add(cbbKichBan);

        // Footer Buttons - y = 118, height = 30px
        // Nút [Hủy kịch bản riêng]: đặt bên trái (x = 16), Size(125, 30)
        btnRemove = new Button();
        btnRemove.Text = "Hủy kịch bản riêng";
        btnRemove.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        btnRemove.BackColor = Color.FromArgb(254, 226, 226);
        btnRemove.ForeColor = Color.FromArgb(220, 38, 38);
        btnRemove.FlatStyle = FlatStyle.Flat;
        btnRemove.FlatAppearance.BorderSize = 1;
        btnRemove.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
        btnRemove.Size = new Size(125, 30);
        btnRemove.Location = new Point(16, 118);
        btnRemove.Cursor = Cursors.Hand;
        btnRemove.MouseEnter += (s, e) => btnRemove.BackColor = Color.FromArgb(254, 202, 202);
        btnRemove.MouseLeave += (s, e) => btnRemove.BackColor = Color.FromArgb(254, 226, 226);
        btnRemove.Click += BtnRemove_Click;
        pnlBorder.Controls.Add(btnRemove);

        // Nút [Lưu kịch bản]: đặt ngay trước nút Đóng (x = 188), Size(100, 30)
        btnSave = new Button();
        btnSave.Text = "Lưu kịch bản";
        btnSave.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.ForeColor = Color.White;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Size = new Size(100, 30);
        btnSave.Location = new Point(188, 118);
        btnSave.Cursor = Cursors.Hand;
        btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(29, 78, 216);
        btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.Click += BtnSave_Click;
        pnlBorder.Controls.Add(btnSave);

        // Nút [Đóng]: đặt góc phải ngoài cùng (x = 296), Size(66, 30)
        btnCancel = new Button();
        btnCancel.Text = "Đóng";
        btnCancel.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
        btnCancel.BackColor = Color.FromArgb(241, 245, 249);
        btnCancel.ForeColor = Color.FromArgb(51, 65, 85);
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.FlatAppearance.BorderSize = 1;
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        btnCancel.Size = new Size(66, 30);
        btnCancel.Location = new Point(296, 118);
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(226, 232, 240);
        btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(241, 245, 249);
        btnCancel.Click += (s, e) => this.Close();
        pnlBorder.Controls.Add(btnCancel);
    }

    private void LoadKichBan()
    {
        try
        {
            DataTable dt = Class154.smethod_2();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbbKichBan.DataSource = dt;
                cbbKichBan.DisplayMember = "TenKichBan";
                cbbKichBan.ValueMember = "Id_KichBan";
            }
            else
            {
                cbbKichBan.Items.Add("Chưa có kịch bản nào");
                cbbKichBan.SelectedIndex = 0;
                btnSave.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải danh sách kịch bản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (cbbKichBan.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn một kịch bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string idKb = cbbKichBan.SelectedValue.ToString();
        string tenKb = cbbKichBan.Text;

        if (string.IsNullOrEmpty(idKb))
        {
            MessageBox.Show("Kịch bản không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        foreach (var uid in _listUids)
        {
            KichBanThongKeDB.AssignCustomScript(uid, idKb, tenKb);
        }

        _onAssignedCallback?.Invoke(_listRowIndices, idKb, tenKb);

        MessageBox.Show($"Đã gắn kịch bản [{tenKb}] cho {_listUids.Count} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show($"Bạn có chắc chắn muốn hủy kịch bản riêng của {_listUids.Count} tài khoản đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            foreach (var uid in _listUids)
            {
                KichBanThongKeDB.RemoveCustomScript(uid);
            }

            _onAssignedCallback?.Invoke(_listRowIndices, "", "");

            MessageBox.Show($"Đã hủy kịch bản riêng cho {_listUids.Count} tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
