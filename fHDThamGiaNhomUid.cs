using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDThamGiaNhomUid : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 gclass4_0;

	internal string string_0;

	internal string E0817F98;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown E33955B7;

	internal NumericUpDown CB27619F;

	internal TextBox F628D601;

	internal Label BA188D12;

	internal Label label1;

	internal Button F3A2009A;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button EA00BE8B;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label CA0B4E3B;

	internal NumericUpDown CF0AFB10;

	internal NumericUpDown nudDelayFrom;

	internal Label DDB449A3;

	internal RichTextBox FF1D1DA0;

	internal CheckBox F40FB098;

	internal Panel F8101818;

	internal CheckBox E09E2E0E;

	internal Label lblCauTraLoi;

	internal RichTextBox txtCauTraLoi;

	internal Label label8;

	internal ComboBox cbbCauTraLoi;

	internal Panel E9301719;

	internal CheckBox C00FEF15;

	internal Label label2;

	internal Label label9;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public fHDThamGiaNhomUid(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			E0817F98 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			F628D601.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			F628D601.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to close dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void fHDThamGiaNhomUid_Load(object sender, EventArgs e)
	{
		method_2();
		try
		{
			CB27619F.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			E33955B7.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			CF0AFB10.Value = gclass4_0.method_2("nudDelayTo", 5);
			FF1D1DA0.Text = gclass4_0.BDB80B23("txtUid");
			E09E2E0E.Checked = gclass4_0.method_3("ckbTuDongTraLoiCauHoi");
			F40FB098.Checked = gclass4_0.method_3("ckbTuDongXoaUid");
			txtCauTraLoi.Text = gclass4_0.BDB80B23("txtCauTraLoi");
			cbbCauTraLoi.SelectedIndex = gclass4_0.method_2("cbbCauTraLoi", 1);
			C00FEF15.Checked = gclass4_0.method_3("ckbUuTienMbasic");
		}
		catch
		{
		}
		method_0();
	}

	private void method_0()
	{
		E40C4A33(null, null);
	}

	private void EA00BE8B_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = F628D601.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		List<string> list_ = FF1D1DA0.Lines.ToList();
		list_ = Commom.smethod_36(list_);
		if (list_.Count == 0)
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách uid nhóm!", 3);
			return;
		}
		if (E09E2E0E.Checked)
		{
			list_ = txtCauTraLoi.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			if (list_.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách câu trả lời!", 3);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", CB27619F.Value);
		gClass.method_4("nudSoLuongTo", E33955B7.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", CF0AFB10.Value);
		gClass.method_4("txtUid", FF1D1DA0.Text.Trim());
		gClass.method_4("ckbTuDongTraLoiCauHoi", E09E2E0E.Checked);
		gClass.method_4("ckbTuDongXoaUid", F40FB098.Checked);
		gClass.method_4("txtCauTraLoi", txtCauTraLoi.Text.Trim());
		gClass.method_4("cbbCauTraLoi", cbbCauTraLoi.SelectedIndex);
		gClass.method_4("ckbUuTienMbasic", C00FEF15.Checked);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MessageBox.Show("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?", "Thông ba\u0301o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, E0817F98, e013A))
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
		else if (MessageBox.Show("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?", "Thông ba\u0301o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			if (Class154.smethod_13(string_1, text, e013A))
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

	private void EF3D983B(object sender, EventArgs e)
	{
		Close();
	}

	private void D5A28FAA(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void FF1D1DA0_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(FF1D1DA0, CA0B4E3B);
	}

	private void E40C4A33(object sender, EventArgs e)
	{
		F8101818.Enabled = E09E2E0E.Checked;
	}

	private void F00CD13A(object sender, EventArgs e)
	{
	}

	private void txtCauTraLoi_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtCauTraLoi, lblCauTraLoi);
	}

	private void method_2()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Random câu trả lời");
		dictionary.Add("1", "Trả lời theo thứ tự");
		Commom.smethod_24(cbbCauTraLoi, dictionary);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDThamGiaNhomUid));
		pnlTopAccent = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		EA00BE8B = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		E9301719 = new System.Windows.Forms.Panel();
		CA0B4E3B = new System.Windows.Forms.Label();
		F40FB098 = new System.Windows.Forms.CheckBox();
		FF1D1DA0 = new System.Windows.Forms.RichTextBox();
		label9 = new System.Windows.Forms.Label();
		F8101818 = new System.Windows.Forms.Panel();
		cbbCauTraLoi = new System.Windows.Forms.ComboBox();
		label8 = new System.Windows.Forms.Label();
		txtCauTraLoi = new System.Windows.Forms.RichTextBox();
		lblCauTraLoi = new System.Windows.Forms.Label();
		E09E2E0E = new System.Windows.Forms.CheckBox();
		CF0AFB10 = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		DDB449A3 = new System.Windows.Forms.Label();
		E33955B7 = new System.Windows.Forms.NumericUpDown();
		CB27619F = new System.Windows.Forms.NumericUpDown();
		F628D601 = new System.Windows.Forms.TextBox();
		BA188D12 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		F3A2009A = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		C00FEF15 = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		E9301719.SuspendLayout();
		F8101818.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CF0AFB10).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)E33955B7).BeginInit();
		((System.ComponentModel.ISupportInitialize)CB27619F).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(557, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Tham gia nhóm chi\u0309 đi\u0323nh";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(EA00BE8B);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(557, 31);
		pnlHeader.TabIndex = 9;
		EA00BE8B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		EA00BE8B.Cursor = System.Windows.Forms.Cursors.Hand;
		EA00BE8B.FlatAppearance.BorderSize = 0;
		EA00BE8B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EA00BE8B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EA00BE8B.ForeColor = System.Drawing.Color.White;
		EA00BE8B.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		EA00BE8B.Location = new System.Drawing.Point(526, 1);
		EA00BE8B.Name = "button1";
		EA00BE8B.Size = new System.Drawing.Size(30, 30);
		EA00BE8B.TabIndex = 77;
		EA00BE8B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		EA00BE8B.UseVisualStyleBackColor = true;
		EA00BE8B.Click += new System.EventHandler(EA00BE8B_Click);
		System.Drawing.Image iconClose_fHDTh = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDTh != null) EA00BE8B.Image = iconClose_fHDTh;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDTh = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDTh != null) pictureBox1.Image = iconApp_fHDTh;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(E9301719);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(F8101818);
		panel1.Controls.Add(E09E2E0E);
		panel1.Controls.Add(CF0AFB10);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(DDB449A3);
		panel1.Controls.Add(E33955B7);
		panel1.Controls.Add(CB27619F);
		panel1.Controls.Add(F628D601);
		panel1.Controls.Add(BA188D12);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(F3A2009A);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(C00FEF15);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(560, 369);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(D5A28FAA);
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 115;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		E9301719.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E9301719.Controls.Add(CA0B4E3B);
		E9301719.Controls.Add(F40FB098);
		E9301719.Controls.Add(FF1D1DA0);
		E9301719.Location = new System.Drawing.Point(290, 49);
		E9301719.Name = "panel2";
		E9301719.Size = new System.Drawing.Size(234, 262);
		E9301719.TabIndex = 117;
		CA0B4E3B.AutoSize = true;
		CA0B4E3B.Location = new System.Drawing.Point(1, 3);
		CA0B4E3B.Name = "lblUid";
		CA0B4E3B.Size = new System.Drawing.Size(113, 16);
		CA0B4E3B.TabIndex = 0;
		CA0B4E3B.Text = "Nhâ\u0323p Id nho\u0301m (0):";
		CA0B4E3B.Click += new System.EventHandler(F00CD13A);
		F40FB098.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F40FB098.AutoSize = true;
		F40FB098.Cursor = System.Windows.Forms.Cursors.Hand;
		F40FB098.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F40FB098.Location = new System.Drawing.Point(4, 237);
		F40FB098.Name = "ckbTuDongXoaUid";
		F40FB098.Size = new System.Drawing.Size(167, 20);
		F40FB098.TabIndex = 113;
		F40FB098.Text = "Xo\u0301a Id nho\u0301m đa\u0303 sư\u0309 du\u0323ng";
		F40FB098.UseVisualStyleBackColor = true;
		FF1D1DA0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		FF1D1DA0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		FF1D1DA0.Location = new System.Drawing.Point(4, 23);
		FF1D1DA0.Name = "txtUid";
		FF1D1DA0.Size = new System.Drawing.Size(224, 213);
		FF1D1DA0.TabIndex = 114;
		FF1D1DA0.Text = "";
		FF1D1DA0.WordWrap = false;
		FF1D1DA0.TextChanged += new System.EventHandler(FF1D1DA0_TextChanged);
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 116;
		label9.Text = "Sô\u0301 lươ\u0323ng:";
		F8101818.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F8101818.Controls.Add(cbbCauTraLoi);
		F8101818.Controls.Add(label8);
		F8101818.Controls.Add(txtCauTraLoi);
		F8101818.Controls.Add(lblCauTraLoi);
		F8101818.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F8101818.Location = new System.Drawing.Point(30, 156);
		F8101818.Name = "plTuongTac";
		F8101818.Size = new System.Drawing.Size(244, 155);
		F8101818.TabIndex = 116;
		cbbCauTraLoi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbCauTraLoi.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbCauTraLoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbCauTraLoi.FormattingEnabled = true;
		cbbCauTraLoi.Location = new System.Drawing.Point(73, 159);
		cbbCauTraLoi.Name = "cbbCauTraLoi";
		cbbCauTraLoi.Size = new System.Drawing.Size(164, 24);
		cbbCauTraLoi.TabIndex = 4;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(3, 152);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 3;
		label8.Text = "Tùy chọn:";
		txtCauTraLoi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtCauTraLoi.Location = new System.Drawing.Point(4, 22);
		txtCauTraLoi.Name = "txtCauTraLoi";
		txtCauTraLoi.Size = new System.Drawing.Size(235, 128);
		txtCauTraLoi.TabIndex = 2;
		txtCauTraLoi.Text = "";
		txtCauTraLoi.WordWrap = false;
		txtCauTraLoi.TextChanged += new System.EventHandler(txtCauTraLoi_TextChanged);
		lblCauTraLoi.AutoSize = true;
		lblCauTraLoi.Location = new System.Drawing.Point(1, 3);
		lblCauTraLoi.Name = "lblCauTraLoi";
		lblCauTraLoi.Size = new System.Drawing.Size(153, 16);
		lblCauTraLoi.TabIndex = 0;
		lblCauTraLoi.Text = "Danh sách câu trả lời (0):";
		E09E2E0E.AutoSize = true;
		E09E2E0E.Cursor = System.Windows.Forms.Cursors.Hand;
		E09E2E0E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		E09E2E0E.Location = new System.Drawing.Point(30, 134);
		E09E2E0E.Name = "ckbTuDongTraLoiCauHoi";
		E09E2E0E.Size = new System.Drawing.Size(156, 20);
		E09E2E0E.TabIndex = 115;
		E09E2E0E.Text = "Tự động trả lời câu hỏi";
		E09E2E0E.UseVisualStyleBackColor = true;
		E09E2E0E.CheckedChanged += new System.EventHandler(E40C4A33);
		CF0AFB10.Location = new System.Drawing.Point(218, 107);
		CF0AFB10.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CF0AFB10.Name = "nudDelayTo";
		CF0AFB10.Size = new System.Drawing.Size(56, 23);
		CF0AFB10.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		DDB449A3.AutoSize = true;
		DDB449A3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DDB449A3.Location = new System.Drawing.Point(194, 109);
		DDB449A3.Name = "label7";
		DDB449A3.Size = new System.Drawing.Size(18, 16);
		DDB449A3.TabIndex = 46;
		DDB449A3.Text = ">";
		E33955B7.Location = new System.Drawing.Point(218, 78);
		E33955B7.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E33955B7.Name = "nudSoLuongTo";
		E33955B7.Size = new System.Drawing.Size(56, 23);
		E33955B7.TabIndex = 2;
		CB27619F.Location = new System.Drawing.Point(132, 78);
		CB27619F.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CB27619F.Name = "nudSoLuongFrom";
		CB27619F.Size = new System.Drawing.Size(56, 23);
		CB27619F.TabIndex = 1;
		F628D601.Location = new System.Drawing.Point(132, 49);
		F628D601.Name = "txtTenHanhDong";
		F628D601.Size = new System.Drawing.Size(142, 23);
		F628D601.TabIndex = 0;
		BA188D12.AutoSize = true;
		BA188D12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BA188D12.Location = new System.Drawing.Point(194, 80);
		BA188D12.Name = "label3";
		BA188D12.Size = new System.Drawing.Size(18, 16);
		BA188D12.TabIndex = 37;
		BA188D12.Text = ">";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		F3A2009A.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F3A2009A.BackColor = System.Drawing.Color.Maroon;
		F3A2009A.Cursor = System.Windows.Forms.Cursors.Hand;
		F3A2009A.FlatAppearance.BorderSize = 0;
		F3A2009A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F3A2009A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F3A2009A.ForeColor = System.Drawing.Color.White;
		F3A2009A.Location = new System.Drawing.Point(290, 326);
		F3A2009A.Name = "btnCancel";
		F3A2009A.Size = new System.Drawing.Size(92, 29);
		F3A2009A.TabIndex = 7;
		F3A2009A.Text = "Đóng";
		F3A2009A.UseVisualStyleBackColor = false;
		F3A2009A.Click += new System.EventHandler(EF3D983B);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(183, 326);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
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
		bunifuCards1.Size = new System.Drawing.Size(557, 37);
		bunifuCards1.TabIndex = 28;
		C00FEF15.AutoSize = true;
		C00FEF15.Cursor = System.Windows.Forms.Cursors.Hand;
		C00FEF15.Location = new System.Drawing.Point(290, 291);
		C00FEF15.Name = "ckbUuTienMbasic";
		C00FEF15.Size = new System.Drawing.Size(173, 20);
		C00FEF15.TabIndex = 199;
		C00FEF15.Text = "Ưu tiên chạy bằng mbasic";
		C00FEF15.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(560, 369);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDThamGiaNhomUid";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDThamGiaNhomUid_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		E9301719.ResumeLayout(false);
		E9301719.PerformLayout();
		F8101818.ResumeLayout(false);
		F8101818.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CF0AFB10).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)E33955B7).EndInit();
		((System.ComponentModel.ISupportInitialize)CB27619F).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
