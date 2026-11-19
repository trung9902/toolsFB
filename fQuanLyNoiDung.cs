using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fQuanLyNoiDung : Form
{
	public string ResultContent { get; set; } = "";
	public bool ResultIsMultiPost { get; set; } = false;

	private List<ContentTemplate> allTemplates = new List<ContentTemplate>();
	private ContentTemplate currentEditing = null;
	private bool isCreatingNew = false;

	// Controls
	private BunifuCards bunifuCards1;
	private Panel pnlHeader;
	private BunifuCustomLabel lblTitle;
	private Button btnClose;
	private BunifuDragControl bunifuDragControl;

	// Left panel controls
	private Panel plLeft;
	private TextBox txtTimKiem;
	private ComboBox cbbFilterChuDe;
	private DataGridView dgvDanhSach;
	private DataGridViewCheckBoxColumn colChon;
	private DataGridViewTextBoxColumn colStt;
	private DataGridViewTextBoxColumn colTieuDe;
	private DataGridViewTextBoxColumn colChuDe;
	private DataGridViewTextBoxColumn colSoDong;
	private DataGridViewTextBoxColumn colSoKyTu;

	private Button btnThem;
	private Button btnXoa;
	private Button btnNhanBan;
	private Button btnNhapFile;
	private Button btnXuatFile;

	// Right panel controls
	private Panel plRight;
	private TextBox txtTieuDe;
	private ComboBox cbbChuDe;
	private FlowLayoutPanel flpEmoji;
	private FlowLayoutPanel flpTags;
	private RichTextBox txtNoiDung;
	private Label lblStats;
	private Button btnLuu;

	// Bottom controls
	private Panel plBottom;
	private Button btnApDung;
	private Button btnDong;

	public fQuanLyNoiDung()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		Font fontTahoma = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Font fontBold = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);

		bunifuCards1 = new BunifuCards();
		pnlHeader = new Panel();
		lblTitle = new BunifuCustomLabel();
		btnClose = new Button();
		bunifuDragControl = new BunifuDragControl();

		plLeft = new Panel();
		txtTimKiem = new TextBox();
		cbbFilterChuDe = new ComboBox();
		dgvDanhSach = new DataGridView();
		colChon = new DataGridViewCheckBoxColumn();
		colStt = new DataGridViewTextBoxColumn();
		colTieuDe = new DataGridViewTextBoxColumn();
		colChuDe = new DataGridViewTextBoxColumn();
		colSoDong = new DataGridViewTextBoxColumn();
		colSoKyTu = new DataGridViewTextBoxColumn();

		btnThem = new Button();
		btnXoa = new Button();
		btnNhanBan = new Button();
		btnNhapFile = new Button();
		btnXuatFile = new Button();

		plRight = new Panel();
		txtTieuDe = new TextBox();
		cbbChuDe = new ComboBox();
		flpEmoji = new FlowLayoutPanel();
		flpTags = new FlowLayoutPanel();
		txtNoiDung = new RichTextBox();
		lblStats = new Label();
		btnLuu = new Button();

		plBottom = new Panel();
		btnApDung = new Button();
		btnDong = new Button();

		SuspendLayout();

		// Form setup
		AutoScaleDimensions = new SizeF(7f, 16f);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		ClientSize = new Size(1000, 640);
		Font = fontTahoma;
		FormBorderStyle = FormBorderStyle.None;
		StartPosition = FormStartPosition.CenterParent;
		Name = "fQuanLyNoiDung";
		Text = "Quản lý nội dung bài viết";

		// bunifuCards1 & Header
		bunifuCards1.BackColor = Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = false;
		bunifuCards1.color = Color.FromArgb(53, 120, 229);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.Dock = DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = false;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new Size(1000, 38);
		bunifuCards1.TabIndex = 0;

		pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		pnlHeader.BackColor = Color.White;
		pnlHeader.Controls.Add(lblTitle);
		pnlHeader.Controls.Add(btnClose);
		pnlHeader.Cursor = Cursors.SizeAll;
		pnlHeader.Location = new Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new Size(1000, 32);
		pnlHeader.TabIndex = 9;

		lblTitle.AutoSize = true;
		lblTitle.Font = new Font("Segoe UI", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
		lblTitle.Location = new Point(14, 7);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(350, 19);
		lblTitle.Text = "QUẢN LÝ NỘI DUNG BÀI VIẾT";

		btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClose.Cursor = Cursors.Hand;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnClose.ForeColor = Color.FromArgb(100, 116, 139);
		btnClose.Location = new Point(965, 1);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(32, 30);
		btnClose.Text = "✕";
		btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
		btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 38, 38);
		btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.White;
		btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(100, 116, 139);
		btnClose.Click += (s, e) => Close();

		bunifuDragControl.Fixed = true;
		bunifuDragControl.Horizontal = true;
		bunifuDragControl.TargetControl = pnlHeader;
		bunifuDragControl.Vertical = true;

		// Left Panel
		plLeft.Location = new Point(12, 45);
		plLeft.Size = new Size(480, 535);
		plLeft.BorderStyle = BorderStyle.FixedSingle;

		Label lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(8, 12), AutoSize = true, Font = fontBold };
		txtTimKiem.Location = new Point(80, 8);
		txtTimKiem.Size = new Size(190, 23);
		txtTimKiem.TextChanged += (s, e) => FilterList();

		Label lblChuDeFilter = new Label { Text = "Chủ đề:", Location = new Point(280, 12), AutoSize = true, Font = fontBold };
		cbbFilterChuDe.Location = new Point(340, 8);
		cbbFilterChuDe.Size = new Size(130, 24);
		cbbFilterChuDe.DropDownStyle = ComboBoxStyle.DropDownList;
		cbbFilterChuDe.SelectedIndexChanged += (s, e) => FilterList();

		// DataGridView
		dgvDanhSach.Location = new Point(8, 38);
		dgvDanhSach.Size = new Size(462, 445);
		dgvDanhSach.AllowUserToAddRows = false;
		dgvDanhSach.AllowUserToDeleteRows = false;
		dgvDanhSach.AllowUserToResizeRows = false;
		dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgvDanhSach.MultiSelect = false;
		dgvDanhSach.BackgroundColor = Color.White;
		dgvDanhSach.RowHeadersVisible = false;

		colChon.HeaderText = "";
		colChon.Width = 32;
		colChon.Name = "colChon";

		colStt.HeaderText = "STT";
		colStt.Width = 38;
		colStt.ReadOnly = true;
		colStt.Name = "colStt";

		colTieuDe.HeaderText = "Tiêu đề mẫu bài";
		colTieuDe.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		colTieuDe.ReadOnly = true;
		colTieuDe.Name = "colTieuDe";

		colChuDe.HeaderText = "Chủ đề";
		colChuDe.Width = 110;
		colChuDe.ReadOnly = true;
		colChuDe.Name = "colChuDe";

		colSoDong.HeaderText = "Dòng";
		colSoDong.Width = 45;
		colSoDong.ReadOnly = true;
		colSoDong.Name = "colSoDong";

		colSoKyTu.HeaderText = "Ký tự";
		colSoKyTu.Width = 50;
		colSoKyTu.ReadOnly = true;
		colSoKyTu.Name = "colSoKyTu";

		dgvDanhSach.Columns.AddRange(new DataGridViewColumn[] { colChon, colStt, colTieuDe, colChuDe, colSoDong, colSoKyTu });
		dgvDanhSach.SelectionChanged += DgvDanhSach_SelectionChanged;

		// Left Action Buttons
		btnThem.Location = new Point(8, 492);
		btnThem.Size = new Size(88, 32);
		btnThem.Text = "Thêm";
		btnThem.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnThem.BackColor = Color.FromArgb(53, 120, 229);
		btnThem.ForeColor = Color.White;
		btnThem.FlatStyle = FlatStyle.Flat;
		btnThem.FlatAppearance.BorderSize = 0;
		btnThem.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
		btnThem.Cursor = Cursors.Hand;
		btnThem.Click += BtnThem_Click;

		btnNhanBan.Location = new Point(102, 492);
		btnNhanBan.Size = new Size(88, 32);
		btnNhanBan.Text = "Nhân bản";
		btnNhanBan.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnNhanBan.BackColor = Color.White;
		btnNhanBan.ForeColor = Color.FromArgb(51, 65, 85);
		btnNhanBan.FlatStyle = FlatStyle.Flat;
		btnNhanBan.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
		btnNhanBan.FlatAppearance.BorderSize = 1;
		btnNhanBan.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnNhanBan.Cursor = Cursors.Hand;
		btnNhanBan.Click += BtnNhanBan_Click;

		btnXoa.Location = new Point(196, 492);
		btnXoa.Size = new Size(82, 32);
		btnXoa.Text = "Xóa";
		btnXoa.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnXoa.BackColor = Color.FromArgb(254, 242, 242);
		btnXoa.ForeColor = Color.FromArgb(220, 38, 38);
		btnXoa.FlatStyle = FlatStyle.Flat;
		btnXoa.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
		btnXoa.FlatAppearance.BorderSize = 1;
		btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);
		btnXoa.Cursor = Cursors.Hand;
		btnXoa.Click += BtnXoa_Click;

		btnNhapFile.Location = new Point(284, 492);
		btnNhapFile.Size = new Size(90, 32);
		btnNhapFile.Text = "Nhập .txt";
		btnNhapFile.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnNhapFile.BackColor = Color.White;
		btnNhapFile.ForeColor = Color.FromArgb(51, 65, 85);
		btnNhapFile.FlatStyle = FlatStyle.Flat;
		btnNhapFile.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
		btnNhapFile.FlatAppearance.BorderSize = 1;
		btnNhapFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnNhapFile.Cursor = Cursors.Hand;
		btnNhapFile.Click += BtnNhapFile_Click;

		btnXuatFile.Location = new Point(380, 492);
		btnXuatFile.Size = new Size(90, 32);
		btnXuatFile.Text = "Xuất .txt";
		btnXuatFile.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnXuatFile.BackColor = Color.White;
		btnXuatFile.ForeColor = Color.FromArgb(51, 65, 85);
		btnXuatFile.FlatStyle = FlatStyle.Flat;
		btnXuatFile.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
		btnXuatFile.FlatAppearance.BorderSize = 1;
		btnXuatFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnXuatFile.Cursor = Cursors.Hand;
		btnXuatFile.Click += BtnXuatFile_Click;

		plLeft.Controls.Add(lblSearch);
		plLeft.Controls.Add(txtTimKiem);
		plLeft.Controls.Add(lblChuDeFilter);
		plLeft.Controls.Add(cbbFilterChuDe);
		plLeft.Controls.Add(dgvDanhSach);
		plLeft.Controls.Add(btnThem);
		plLeft.Controls.Add(btnNhanBan);
		plLeft.Controls.Add(btnXoa);
		plLeft.Controls.Add(btnNhapFile);
		plLeft.Controls.Add(btnXuatFile);

		// Right Panel (Editor)
		plRight.Location = new Point(502, 45);
		plRight.Size = new Size(485, 535);
		plRight.BorderStyle = BorderStyle.FixedSingle;

		Label lblTieuDe = new Label { Text = "Tiêu đề mẫu:", Location = new Point(8, 12), AutoSize = true, Font = fontBold };
		txtTieuDe.Location = new Point(95, 8);
		txtTieuDe.Size = new Size(378, 23);

		Label lblChuDe = new Label { Text = "Chủ đề / Nhóm:", Location = new Point(8, 40), AutoSize = true, Font = fontBold };
		cbbChuDe.Location = new Point(115, 36);
		cbbChuDe.Size = new Size(358, 24);
		cbbChuDe.Items.AddRange(new object[] {
			"Website & Doanh nghiệp",
			"Bán hàng & Khuyến mãi",
			"Tuyển dụng & Hợp tác",
			"Chia sẻ kiến thức",
			"Tương tác / Mini game",
			"Chung"
		});

		// Emoji Bar
		// Emoji Bar - High quality icons
		flpEmoji.Location = new Point(8, 66);
		flpEmoji.Size = new Size(468, 38);
		flpEmoji.WrapContents = false;
		flpEmoji.AutoScroll = true;

		ToolTip toolTipEmoji = new ToolTip();
		EmojiIconHelper.PopulateEmojiToolbar(flpEmoji, InsertTextAtCursor, toolTipEmoji, 32, 22);

		// Tags Bar
		flpTags.Location = new Point(8, 106);
		flpTags.Size = new Size(468, 30);
		flpTags.WrapContents = false;

		Button btnSpin = new Button { Text = "{Spin}", Size = new Size(68, 26), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0), BackColor = Color.FromArgb(248, 250, 252), ForeColor = Color.FromArgb(51, 65, 85), Margin = new Padding(2) };
		btnSpin.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
		btnSpin.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnSpin.Click += (s, e) => InsertTextAtCursor("{Nội dung 1|Nội dung 2|Nội dung 3}");

		Button btnTagTime = new Button { Text = "{time}", Size = new Size(60, 26), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0), BackColor = Color.FromArgb(248, 250, 252), ForeColor = Color.FromArgb(51, 65, 85), Margin = new Padding(2) };
		btnTagTime.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
		btnTagTime.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnTagTime.Click += (s, e) => InsertTextAtCursor("{time}");

		Button btnTagRandom = new Button { Text = "{random}", Size = new Size(72, 26), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0), BackColor = Color.FromArgb(248, 250, 252), ForeColor = Color.FromArgb(51, 65, 85), Margin = new Padding(2) };
		btnTagRandom.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
		btnTagRandom.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnTagRandom.Click += (s, e) => InsertTextAtCursor("{random}");

		Button btnDongTrong = new Button { Text = "+ Dòng trống", Size = new Size(95, 26), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0), BackColor = Color.FromArgb(248, 250, 252), ForeColor = Color.FromArgb(51, 65, 85), Margin = new Padding(2) };
		btnDongTrong.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
		btnDongTrong.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnDongTrong.Click += (s, e) => InsertTextAtCursor("\r\n\r\n");

		Button btnClear = new Button { Text = "Xóa trắng", Size = new Size(84, 26), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0), BackColor = Color.FromArgb(254, 242, 242), ForeColor = Color.FromArgb(220, 38, 38), Margin = new Padding(2) };
		btnClear.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
		btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);
		btnClear.Click += (s, e) => { if (MsBoxHelper.D41C45AC("Bạn có chắc muốn xóa trắng nội dung soạn thảo?") == DialogResult.Yes) txtNoiDung.Clear(); };

		flpTags.Controls.Add(btnSpin);
		flpTags.Controls.Add(btnTagTime);
		flpTags.Controls.Add(btnTagRandom);
		flpTags.Controls.Add(btnDongTrong);
		flpTags.Controls.Add(btnClear);

		// RichTextBox
		txtNoiDung.Location = new Point(8, 140);
		txtNoiDung.Size = new Size(468, 346);
		txtNoiDung.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		txtNoiDung.ForeColor = Color.FromArgb(30, 41, 59);
		txtNoiDung.BackColor = Color.White;
		txtNoiDung.WordWrap = true;
		txtNoiDung.ScrollBars = RichTextBoxScrollBars.Both;
		txtNoiDung.TextChanged += TxtNoiDung_TextChanged;

		// Stats & Save Button
		lblStats.Location = new Point(8, 498);
		lblStats.Size = new Size(330, 24);
		lblStats.Text = "Dòng: 0 | Ký tự: 0 | Từ: 0";
		lblStats.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblStats.ForeColor = Color.FromArgb(100, 116, 139);

		btnLuu.Location = new Point(345, 492);
		btnLuu.Size = new Size(130, 32);
		btnLuu.Text = "Lưu mẫu này";
		btnLuu.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnLuu.BackColor = Color.FromArgb(53, 120, 229);
		btnLuu.ForeColor = Color.White;
		btnLuu.FlatStyle = FlatStyle.Flat;
		btnLuu.FlatAppearance.BorderSize = 0;
		btnLuu.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
		btnLuu.Cursor = Cursors.Hand;
		btnLuu.Click += BtnLuu_Click;

		plRight.Controls.Add(lblTieuDe);
		plRight.Controls.Add(txtTieuDe);
		plRight.Controls.Add(lblChuDe);
		plRight.Controls.Add(cbbChuDe);
		plRight.Controls.Add(flpEmoji);
		plRight.Controls.Add(flpTags);
		plRight.Controls.Add(txtNoiDung);
		plRight.Controls.Add(lblStats);
		plRight.Controls.Add(btnLuu);

		// Bottom Panel
		plBottom.Location = new Point(12, 588);
		plBottom.Size = new Size(975, 42);

		btnApDung.Location = new Point(660, 4);
		btnApDung.Size = new Size(210, 34);
		btnApDung.Text = "Áp dụng vào cấu hình";
		btnApDung.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnApDung.BackColor = Color.FromArgb(53, 120, 229);
		btnApDung.ForeColor = Color.White;
		btnApDung.FlatStyle = FlatStyle.Flat;
		btnApDung.FlatAppearance.BorderSize = 0;
		btnApDung.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
		btnApDung.Cursor = Cursors.Hand;
		btnApDung.Click += BtnApDung_Click;

		btnDong.Location = new Point(880, 4);
		btnDong.Size = new Size(92, 34);
		btnDong.Text = "Đóng";
		btnDong.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnDong.BackColor = Color.White;
		btnDong.ForeColor = Color.FromArgb(71, 85, 105);
		btnDong.FlatStyle = FlatStyle.Flat;
		btnDong.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
		btnDong.FlatAppearance.BorderSize = 1;
		btnDong.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
		btnDong.Cursor = Cursors.Hand;
		btnDong.Click += (s, e) => Close();

		plBottom.Controls.Add(btnApDung);
		plBottom.Controls.Add(btnDong);

		Controls.Add(bunifuCards1);
		Controls.Add(plLeft);
		Controls.Add(plRight);
		Controls.Add(plBottom);

		Load += FQuanLyNoiDung_Load;
		ResumeLayout(false);
	}

	private void FQuanLyNoiDung_Load(object sender, EventArgs e)
	{
		LoadTemplates();
	}

	private void LoadTemplates()
	{
		allTemplates = NoiDungTemplateManager.GetAll();
		PopulateCategories();
		FilterList();
	}

	private void PopulateCategories()
	{
		cbbFilterChuDe.Items.Clear();
		cbbFilterChuDe.Items.Add("Tất cả chủ đề");
		var categories = allTemplates.Select(x => x.Category).Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
		foreach (var cat in categories)
		{
			cbbFilterChuDe.Items.Add(cat);
		}
		cbbFilterChuDe.SelectedIndex = 0;
	}

	private void FilterList()
	{
		string keyword = txtTimKiem.Text.Trim().ToLower();
		string catFilter = cbbFilterChuDe.SelectedItem?.ToString() ?? "Tất cả chủ đề";

		var filtered = allTemplates.Where(t =>
		{
			bool matchCat = catFilter == "Tất cả chủ đề" || t.Category == catFilter;
			bool matchKw = string.IsNullOrEmpty(keyword) ||
						   (t.Title != null && t.Title.ToLower().Contains(keyword)) ||
						   (t.Content != null && t.Content.ToLower().Contains(keyword));
			return matchCat && matchKw;
		}).ToList();

		dgvDanhSach.Rows.Clear();
		for (int i = 0; i < filtered.Count; i++)
		{
			var item = filtered[i];
			int lineCount = string.IsNullOrEmpty(item.Content) ? 0 : item.Content.Split('\n').Length;
			int charCount = string.IsNullOrEmpty(item.Content) ? 0 : item.Content.Length;
			int rowIndex = dgvDanhSach.Rows.Add(false, i + 1, item.Title, item.Category, lineCount, charCount);
			dgvDanhSach.Rows[rowIndex].Tag = item;
		}

		if (dgvDanhSach.Rows.Count > 0)
		{
			dgvDanhSach.Rows[0].Selected = true;
		}
		else
		{
			ClearEditor();
		}
	}

	private void DgvDanhSach_SelectionChanged(object sender, EventArgs e)
	{
		if (dgvDanhSach.SelectedRows.Count > 0)
		{
			var template = dgvDanhSach.SelectedRows[0].Tag as ContentTemplate;
			if (template != null)
			{
				currentEditing = template;
				isCreatingNew = false;
				txtTieuDe.Text = template.Title;
				cbbChuDe.Text = template.Category;
				txtNoiDung.Text = template.Content;
				UpdateStats();
			}
		}
	}

	private void ClearEditor()
	{
		currentEditing = null;
		isCreatingNew = true;
		txtTieuDe.Text = "";
		cbbChuDe.Text = "Website & Doanh nghiệp";
		txtNoiDung.Text = "";
		UpdateStats();
	}

	private void InsertTextAtCursor(string text)
	{
		int selStart = txtNoiDung.SelectionStart;
		txtNoiDung.SelectedText = text;
		txtNoiDung.SelectionStart = selStart + text.Length;
		txtNoiDung.Focus();
	}

	private void TxtNoiDung_TextChanged(object sender, EventArgs e)
	{
		UpdateStats();
	}

	private void UpdateStats()
	{
		string text = txtNoiDung.Text;
		int lines = string.IsNullOrEmpty(text) ? 0 : text.Split('\n').Length;
		int chars = text.Length;
		int words = string.IsNullOrWhiteSpace(text) ? 0 : Regex.Matches(text, @"\b\w+\b").Count;
		lblStats.Text = string.Format("Dòng: {0} | Ký tự: {1} | Từ: {2}", lines, chars, words);
	}

	private void BtnThem_Click(object sender, EventArgs e)
	{
		ClearEditor();
		txtTieuDe.Text = "Mẫu bài viết mới #" + (allTemplates.Count + 1);
		txtTieuDe.Focus();
		txtTieuDe.SelectAll();
	}

	private void BtnNhanBan_Click(object sender, EventArgs e)
	{
		if (currentEditing != null)
		{
			ContentTemplate clone = new ContentTemplate
			{
				Title = currentEditing.Title + " (Bản sao)",
				Category = currentEditing.Category,
				Content = currentEditing.Content,
				SortOrder = allTemplates.Count + 1
			};
			int id = NoiDungTemplateManager.Insert(clone);
			LoadTemplates();
			SelectTemplateById(id);
		}
	}

	private void BtnXoa_Click(object sender, EventArgs e)
	{
		if (currentEditing != null)
		{
			if (MsBoxHelper.D41C45AC("Bạn có chắc chắn muốn xóa mẫu: \"" + currentEditing.Title + "\"?") == DialogResult.Yes)
			{
				NoiDungTemplateManager.Delete(currentEditing.Id);
				LoadTemplates();
			}
		}
	}

	private void BtnLuu_Click(object sender, EventArgs e)
	{
		string title = txtTieuDe.Text.Trim();
		if (string.IsNullOrEmpty(title))
		{
			MsBoxHelper.Show("Vui lòng nhập tiêu đề cho mẫu bài viết!", 2);
			txtTieuDe.Focus();
			return;
		}

		string content = txtNoiDung.Text;
		if (string.IsNullOrEmpty(content))
		{
			MsBoxHelper.Show("Vui lòng nhập nội dung bài viết!", 2);
			txtNoiDung.Focus();
			return;
		}

		string cat = string.IsNullOrWhiteSpace(cbbChuDe.Text) ? "Chung" : cbbChuDe.Text.Trim();

		if (isCreatingNew || currentEditing == null)
		{
			ContentTemplate item = new ContentTemplate
			{
				Title = title,
				Category = cat,
				Content = content,
				SortOrder = allTemplates.Count + 1
			};
			int id = NoiDungTemplateManager.Insert(item);
			LoadTemplates();
			SelectTemplateById(id);
			MsBoxHelper.Show("Đã thêm mẫu bài viết mới thành công!");
		}
		else
		{
			currentEditing.Title = title;
			currentEditing.Category = cat;
			currentEditing.Content = content;
			NoiDungTemplateManager.Update(currentEditing);
			LoadTemplates();
			SelectTemplateById(currentEditing.Id);
			MsBoxHelper.Show("Đã cập nhật mẫu bài viết thành công!");
		}
	}

	private void SelectTemplateById(int id)
	{
		foreach (DataGridViewRow row in dgvDanhSach.Rows)
		{
			if (row.Tag is ContentTemplate t && t.Id == id)
			{
				row.Selected = true;
				dgvDanhSach.CurrentCell = row.Cells[2];
				break;
			}
		}
	}

	private void BtnNhapFile_Click(object sender, EventArgs e)
	{
		using OpenFileDialog ofd = new OpenFileDialog();
		ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		ofd.Title = "Chọn file bài viết để nhập";
		if (ofd.ShowDialog() == DialogResult.OK)
		{
			try
			{
				string text = File.ReadAllText(ofd.FileName);
				List<string> posts;
				if (text.Contains("\n|\n"))
				{
					posts = text.Split(new string[] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
				}
				else
				{
					posts = new List<string> { text };
				}

				int added = 0;
				for (int i = 0; i < posts.Count; i++)
				{
					string p = posts[i].Trim();
					if (!string.IsNullOrEmpty(p))
					{
						string firstLine = p.Split('\n')[0].Trim();
						if (firstLine.Length > 40) firstLine = firstLine.Substring(0, 40) + "...";
						string title = string.IsNullOrEmpty(firstLine) ? ("Bài viết nhập #" + (i + 1)) : firstLine;

						ContentTemplate t = new ContentTemplate
						{
							Title = title,
							Category = "Nhập từ file",
							Content = p,
							SortOrder = allTemplates.Count + i + 1
						};
						NoiDungTemplateManager.Insert(t);
						added++;
					}
				}

				LoadTemplates();
				MsBoxHelper.Show("Đã nhập thành công " + added + " bài viết từ file!");
			}
			catch (Exception ex)
			{
				MsBoxHelper.Show("Lỗi khi nhập file: " + ex.Message, 2);
			}
		}
	}

	private void BtnXuatFile_Click(object sender, EventArgs e)
	{
		var checkedItems = GetCheckedTemplates();
		if (checkedItems.Count == 0 && currentEditing != null)
		{
			checkedItems.Add(currentEditing);
		}

		if (checkedItems.Count == 0)
		{
			MsBoxHelper.Show("Vui lòng chọn hoặc tick ít nhất 1 bài viết để xuất file!", 2);
			return;
		}

		using SaveFileDialog sfd = new SaveFileDialog();
		sfd.Filter = "Text Files (*.txt)|*.txt";
		sfd.FileName = "BaiViet_Export_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
		if (sfd.ShowDialog() == DialogResult.OK)
		{
			try
			{
				string content;
				if (checkedItems.Count == 1)
				{
					content = checkedItems[0].Content;
				}
				else
				{
					content = string.Join("\r\n|\r\n", checkedItems.Select(x => x.Content));
				}
				File.WriteAllText(sfd.FileName, content);
				MsBoxHelper.Show("Đã xuất " + checkedItems.Count + " bài viết ra file thành công!");
			}
			catch (Exception ex)
			{
				MsBoxHelper.Show("Lỗi xuất file: " + ex.Message, 2);
			}
		}
	}

	private List<ContentTemplate> GetCheckedTemplates()
	{
		List<ContentTemplate> list = new List<ContentTemplate>();
		foreach (DataGridViewRow row in dgvDanhSach.Rows)
		{
			if (Convert.ToBoolean(row.Cells["colChon"].Value) && row.Tag is ContentTemplate t)
			{
				list.Add(t);
			}
		}
		return list;
	}

	private void BtnApDung_Click(object sender, EventArgs e)
	{
		var checkedList = GetCheckedTemplates();
		if (checkedList.Count > 1)
		{
			// Multiple posts selected -> join with \r\n|\r\n and set multi post
			ResultContent = string.Join("\r\n|\r\n", checkedList.Select(x => x.Content.Trim()));
			ResultIsMultiPost = true;
			DialogResult = DialogResult.OK;
			Close();
		}
		else if (checkedList.Count == 1)
		{
			ResultContent = checkedList[0].Content.Trim();
			ResultIsMultiPost = ResultContent.Contains("\n");
			DialogResult = DialogResult.OK;
			Close();
		}
		else if (currentEditing != null)
		{
			// Use the current editing text in case user made on-the-fly tweaks
			ResultContent = txtNoiDung.Text.Trim();
			ResultIsMultiPost = ResultContent.Contains("\n");
			DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			MsBoxHelper.Show("Vui lòng chọn ít nhất 1 bài viết!", 2);
		}
	}
}
