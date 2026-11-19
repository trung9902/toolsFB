using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDTuongTacReelNgauNhien : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool CD1A1FB8;

	internal ucTuongTacBaiVietv2 ucTuongTacBaiVietv2_0;

	internal IContainer F3AD3090 = null;

	internal BunifuDragControl D6A1B935;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown DB256239;

	internal TextBox txtTenHanhDong;

	internal Label label3;

	internal Label label2;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel plTuongTacBaiViet;

	internal ComboBox C602BE09;

	internal Label C23FF021;

	internal Panel panel2;

	internal TabControl A595F586;

	internal TabPage tabPage1;

	internal TabPage B7BFC31A;

	internal Label A9B12D2D;

	internal Label C9B71502;

	internal NumericUpDown C099FE2E;

	internal NumericUpDown nudThoiGianTo;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return CD1A1FB8;
		}
		[CompilerGenerated]
		set
		{
			CD1A1FB8 = value;
		}
	}

	public fHDTuongTacReelNgauNhien(string AC290EBF, string string_3 = "")
	{
		InitializeComponent();
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		Boolean_0 = false;
		string_0 = AC290EBF;
		string_2 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		base.Height = (Base.DB801CBD ? 552 : 462);
	}

	private void fHDTuongTacReelNgauNhien_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			C602BE09.SelectedIndex = gclass4_0.method_2("cbbOptionsPost");
			DB256239.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 2);
			C099FE2E.Value = gclass4_0.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = gclass4_0.method_2("nudThoiGianTo", 30);
			ucTuongTacBaiVietv2_0 = new ucTuongTacBaiVietv2(gclass4_0);
			plTuongTacBaiViet.Controls.Add(ucTuongTacBaiVietv2_0);
		}
		catch
		{
		}
		method_1();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(C602BE09, list_);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = ucTuongTacBaiVietv2_0.method_2();
		gClass.method_4("cbbOptionsPost", C602BE09.SelectedIndex);
		gClass.method_4("nudSoLuongFrom", DB256239.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudThoiGianFrom", C099FE2E.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(string_2, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void D6350984(object sender, EventArgs e)
	{
		Close();
	}

	private void A0371BA8(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void method_1()
	{
	}

	private void FD213D10(object sender, EventArgs e)
	{
	}

	private void B583D004(object sender, EventArgs e)
	{
		A595F586.SelectedIndex = C602BE09.SelectedIndex;
	}

	protected override void Dispose(bool DE277085)
	{
		if (DE277085 && F3AD3090 != null)
		{
			F3AD3090.Dispose();
		}
		base.Dispose(DE277085);
	}

	private void InitializeComponent()
	{
		F3AD3090 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTuongTacReelNgauNhien));
		D6A1B935 = new Bunifu.Framework.UI.BunifuDragControl(F3AD3090);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F3AD3090);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		plTuongTacBaiViet = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		A595F586 = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		DB256239 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		B7BFC31A = new System.Windows.Forms.TabPage();
		A9B12D2D = new System.Windows.Forms.Label();
		C9B71502 = new System.Windows.Forms.Label();
		C099FE2E = new System.Windows.Forms.NumericUpDown();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		C602BE09 = new System.Windows.Forms.ComboBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		C23FF021 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		A595F586.SuspendLayout();
		tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DB256239).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		B7BFC31A.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)C099FE2E).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		D6A1B935.Fixed = true;
		D6A1B935.Horizontal = true;
		D6A1B935.TargetControl = bunifuCustomLabel1;
		D6A1B935.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(716, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Tương ta\u0301c reel ngâ\u0303u nhiên";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = pnlHeader;
		bunifuDragControl_0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(716, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(685, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(FD213D10);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(plTuongTacBaiViet);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(C602BE09);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(C23FF021);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(719, 462);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(A0371BA8);
		plTuongTacBaiViet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		plTuongTacBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuongTacBaiViet.Location = new System.Drawing.Point(30, 137);
		plTuongTacBaiViet.Name = "plTuongTacBaiViet";
		plTuongTacBaiViet.Size = new System.Drawing.Size(657, 266);
		plTuongTacBaiViet.TabIndex = 193;
		panel2.Controls.Add(A595F586);
		panel2.Location = new System.Drawing.Point(28, 108);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(266, 23);
		panel2.TabIndex = 199;
		A595F586.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		A595F586.Controls.Add(tabPage1);
		A595F586.Controls.Add(B7BFC31A);
		A595F586.Location = new System.Drawing.Point(-5, -5);
		A595F586.Name = "tabOptionsPost";
		A595F586.SelectedIndex = 0;
		A595F586.Size = new System.Drawing.Size(276, 54);
		A595F586.TabIndex = 198;
		tabPage1.Controls.Add(label2);
		tabPage1.Controls.Add(label3);
		tabPage1.Controls.Add(DB256239);
		tabPage1.Controls.Add(nudSoLuongTo);
		tabPage1.Location = new System.Drawing.Point(4, 4);
		tabPage1.Name = "tabPage1";
		tabPage1.Padding = new System.Windows.Forms.Padding(3);
		tabPage1.Size = new System.Drawing.Size(268, 25);
		tabPage1.TabIndex = 0;
		tabPage1.Text = "tabPage1";
		tabPage1.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(0, 3);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 16);
		label2.TabIndex = 32;
		label2.Text = "Sô\u0301 lươ\u0323ng ba\u0300i:";
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(172, 3);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 1;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DB256239.Location = new System.Drawing.Point(110, 1);
		DB256239.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		DB256239.Name = "nudSoLuongFrom";
		DB256239.Size = new System.Drawing.Size(56, 23);
		DB256239.TabIndex = 0;
		nudSoLuongTo.Location = new System.Drawing.Point(207, 1);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		B7BFC31A.Controls.Add(A9B12D2D);
		B7BFC31A.Controls.Add(C9B71502);
		B7BFC31A.Controls.Add(C099FE2E);
		B7BFC31A.Controls.Add(nudThoiGianTo);
		B7BFC31A.Location = new System.Drawing.Point(4, 4);
		B7BFC31A.Name = "tabPage2";
		B7BFC31A.Padding = new System.Windows.Forms.Padding(3);
		B7BFC31A.Size = new System.Drawing.Size(268, 28);
		B7BFC31A.TabIndex = 1;
		B7BFC31A.Text = "tabPage2";
		B7BFC31A.UseVisualStyleBackColor = true;
		A9B12D2D.AutoSize = true;
		A9B12D2D.Location = new System.Drawing.Point(0, 3);
		A9B12D2D.Name = "label8";
		A9B12D2D.Size = new System.Drawing.Size(85, 16);
		A9B12D2D.TabIndex = 40;
		A9B12D2D.Text = "Thơ\u0300i gian (s):";
		C9B71502.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C9B71502.Location = new System.Drawing.Point(172, 3);
		C9B71502.Name = "label9";
		C9B71502.Size = new System.Drawing.Size(29, 16);
		C9B71502.TabIndex = 41;
		C9B71502.Text = ">";
		C9B71502.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C099FE2E.Location = new System.Drawing.Point(110, 1);
		C099FE2E.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C099FE2E.Name = "nudThoiGianFrom";
		C099FE2E.Size = new System.Drawing.Size(56, 23);
		C099FE2E.TabIndex = 38;
		nudThoiGianTo.Location = new System.Drawing.Point(207, 1);
		nudThoiGianTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianTo.Name = "nudThoiGianTo";
		nudThoiGianTo.Size = new System.Drawing.Size(56, 23);
		nudThoiGianTo.TabIndex = 39;
		C602BE09.Cursor = System.Windows.Forms.Cursors.Hand;
		C602BE09.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		C602BE09.DropDownWidth = 200;
		C602BE09.FormattingEnabled = true;
		C602BE09.Location = new System.Drawing.Point(137, 78);
		C602BE09.Name = "cbbOptionsPost";
		C602BE09.Size = new System.Drawing.Size(153, 24);
		C602BE09.TabIndex = 1;
		C602BE09.SelectedIndexChanged += new System.EventHandler(B583D004);
		txtTenHanhDong.Location = new System.Drawing.Point(137, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		C23FF021.AutoSize = true;
		C23FF021.Location = new System.Drawing.Point(27, 81);
		C23FF021.Name = "label4";
		C23FF021.Size = new System.Drawing.Size(64, 16);
		C23FF021.TabIndex = 32;
		C23FF021.Text = "Tu\u0300y cho\u0323n:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(367, 419);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(D6350984);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(260, 419);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(716, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(719, 462);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTuongTacReelNgauNhien";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDTuongTacReelNgauNhien_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		A595F586.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)DB256239).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		B7BFC31A.ResumeLayout(false);
		B7BFC31A.PerformLayout();
		((System.ComponentModel.ISupportInitialize)C099FE2E).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
