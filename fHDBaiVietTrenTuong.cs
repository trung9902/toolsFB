using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBaiVietTrenTuong : Form
{
	internal GClass4 CBB9FCBA;

	internal string string_0;

	internal string C13E302F;

	internal string CFAAFE17;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool FDAAB8A6;

	internal ucTuongTacBaiVietv2 D8AFE725;

	internal IContainer F594722F = null;

	internal BunifuDragControl FDBDB210;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel panel1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards EFB17AA4;

	internal Panel CF87E80E;

	internal Button A9932121;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown E186058D;

	internal NumericUpDown nudDelayFrom;

	internal TextBox E2B75A14;

	internal Label label7;

	internal Label label5;

	internal Label EA9F198C;

	internal Panel plTuongTacBaiViet;

	internal Panel panel2;

	internal TabControl tabOptionsPost;

	internal TabPage tabPage1;

	internal Label label2;

	internal Label label3;

	internal NumericUpDown nudSoLuongFrom;

	internal NumericUpDown nudSoLuongTo;

	internal TabPage tabPage2;

	internal Label label8;

	internal Label BDB917A3;

	internal NumericUpDown A1B61D81;

	internal NumericUpDown nudThoiGianTo;

	internal ComboBox cbbOptionsPost;

	internal Label label4;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return FDAAB8A6;
		}
		[CompilerGenerated]
		set
		{
			FDAAB8A6 = value;
		}
	}

	public fHDBaiVietTrenTuong(string CCB19DA3, string string_1 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = CCB19DA3;
		CFAAFE17 = string_1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (string_1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			C13E302F = dataTable.Rows[0]["Id_TuongTac"].ToString();
			E2B75A14.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_1);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			E2B75A14.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		CBB9FCBA = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDBaiVietTrenTuong_Load(object sender, EventArgs e)
	{
		FC203082();
		try
		{
			cbbOptionsPost.SelectedIndex = CBB9FCBA.method_2("cbbOptionsPost");
			nudSoLuongFrom.Value = CBB9FCBA.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = CBB9FCBA.method_2("nudSoLuongTo", 2);
			A1B61D81.Value = CBB9FCBA.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = CBB9FCBA.method_2("nudThoiGianTo", 30);
			nudDelayFrom.Value = CBB9FCBA.method_2("nudDelayFrom", 3);
			E186058D.Value = CBB9FCBA.method_2("nudDelayTo", 5);
			D8AFE725 = new ucTuongTacBaiVietv2(CBB9FCBA);
			plTuongTacBaiViet.Controls.Add(D8AFE725);
		}
		catch
		{
		}
	}

	private void FC203082()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(cbbOptionsPost, list_);
	}

	private void F5BEBA08(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = E2B75A14.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = D8AFE725.method_2();
		gClass.method_4("cbbOptionsPost", cbbOptionsPost.SelectedIndex);
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudThoiGianFrom", A1B61D81.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", E186058D.Value);
		string text2 = gClass.ED11179C();
		if (CFAAFE17 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, C13E302F, text2))
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
			if (Class154.smethod_13(CFAAFE17, text, text2))
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

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B083E913(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void BE893F22(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
		{
		}
	}

	private void cbbOptionsPost_SelectedIndexChanged(object sender, EventArgs e)
	{
		tabOptionsPost.SelectedIndex = cbbOptionsPost.SelectedIndex;
	}

	protected override void Dispose(bool F784A42C)
	{
		if (F784A42C && F594722F != null)
		{
			F594722F.Dispose();
		}
		base.Dispose(F784A42C);
	}

	private void InitializeComponent()
	{
		F594722F = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBaiVietTrenTuong));
		FDBDB210 = new Bunifu.Framework.UI.BunifuDragControl(F594722F);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F594722F);
		CF87E80E = new System.Windows.Forms.Panel();
		A9932121 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		tabOptionsPost = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		label8 = new System.Windows.Forms.Label();
		BDB917A3 = new System.Windows.Forms.Label();
		A1B61D81 = new System.Windows.Forms.NumericUpDown();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		plTuongTacBaiViet = new System.Windows.Forms.Panel();
		cbbOptionsPost = new System.Windows.Forms.ComboBox();
		label4 = new System.Windows.Forms.Label();
		E186058D = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		E2B75A14 = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		EA9F198C = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		EFB17AA4 = new Bunifu.Framework.UI.BunifuCards();
		CF87E80E.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		tabOptionsPost.SuspendLayout();
		tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)A1B61D81).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)E186058D).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		EFB17AA4.SuspendLayout();
		SuspendLayout();
		FDBDB210.Fixed = true;
		FDBDB210.Horizontal = true;
		FDBDB210.TargetControl = bunifuCustomLabel1;
		FDBDB210.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(717, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Bài viết trên tường";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = CF87E80E;
		bunifuDragControl_0.Vertical = true;
		CF87E80E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CF87E80E.BackColor = System.Drawing.Color.White;
		CF87E80E.Controls.Add(A9932121);
		CF87E80E.Controls.Add(pictureBox1);
		CF87E80E.Controls.Add(bunifuCustomLabel1);
		CF87E80E.Cursor = System.Windows.Forms.Cursors.SizeAll;
		CF87E80E.Location = new System.Drawing.Point(0, 3);
		CF87E80E.Name = "pnlHeader";
		CF87E80E.Size = new System.Drawing.Size(717, 31);
		CF87E80E.TabIndex = 9;
		A9932121.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A9932121.Cursor = System.Windows.Forms.Cursors.Hand;
		A9932121.FlatAppearance.BorderSize = 0;
		A9932121.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A9932121.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A9932121.ForeColor = System.Drawing.Color.White;
		A9932121.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		A9932121.Location = new System.Drawing.Point(686, 1);
		A9932121.Name = "button1";
		A9932121.Size = new System.Drawing.Size(30, 30);
		A9932121.TabIndex = 77;
		A9932121.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A9932121.UseVisualStyleBackColor = true;
		A9932121.Click += new System.EventHandler(F5BEBA08);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(BE893F22);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(plTuongTacBaiViet);
		panel1.Controls.Add(cbbOptionsPost);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(E186058D);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(E2B75A14);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(EA9F198C);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(EFB17AA4);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(720, 471);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(B083E913);
		panel2.Controls.Add(tabOptionsPost);
		panel2.Location = new System.Drawing.Point(30, 111);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(266, 23);
		panel2.TabIndex = 202;
		tabOptionsPost.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabOptionsPost.Controls.Add(tabPage1);
		tabOptionsPost.Controls.Add(tabPage2);
		tabOptionsPost.Location = new System.Drawing.Point(-5, -5);
		tabOptionsPost.Name = "tabOptionsPost";
		tabOptionsPost.SelectedIndex = 0;
		tabOptionsPost.Size = new System.Drawing.Size(276, 54);
		tabOptionsPost.TabIndex = 198;
		tabPage1.Controls.Add(label2);
		tabPage1.Controls.Add(label3);
		tabPage1.Controls.Add(nudSoLuongFrom);
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
		label3.Location = new System.Drawing.Point(174, 3);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 1;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongFrom.Location = new System.Drawing.Point(112, 1);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 0;
		nudSoLuongTo.Location = new System.Drawing.Point(209, 1);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		tabPage2.Controls.Add(label8);
		tabPage2.Controls.Add(BDB917A3);
		tabPage2.Controls.Add(A1B61D81);
		tabPage2.Controls.Add(nudThoiGianTo);
		tabPage2.Location = new System.Drawing.Point(4, 4);
		tabPage2.Name = "tabPage2";
		tabPage2.Padding = new System.Windows.Forms.Padding(3);
		tabPage2.Size = new System.Drawing.Size(268, 28);
		tabPage2.TabIndex = 1;
		tabPage2.Text = "tabPage2";
		tabPage2.UseVisualStyleBackColor = true;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(0, 3);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(85, 16);
		label8.TabIndex = 40;
		label8.Text = "Thơ\u0300i gian (s):";
		BDB917A3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BDB917A3.Location = new System.Drawing.Point(174, 3);
		BDB917A3.Name = "label9";
		BDB917A3.Size = new System.Drawing.Size(29, 16);
		BDB917A3.TabIndex = 41;
		BDB917A3.Text = ">";
		BDB917A3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A1B61D81.Location = new System.Drawing.Point(112, 1);
		A1B61D81.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		A1B61D81.Name = "nudThoiGianFrom";
		A1B61D81.Size = new System.Drawing.Size(56, 23);
		A1B61D81.TabIndex = 38;
		nudThoiGianTo.Location = new System.Drawing.Point(209, 1);
		nudThoiGianTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianTo.Name = "nudThoiGianTo";
		nudThoiGianTo.Size = new System.Drawing.Size(56, 23);
		nudThoiGianTo.TabIndex = 39;
		plTuongTacBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuongTacBaiViet.Location = new System.Drawing.Point(29, 140);
		plTuongTacBaiViet.Name = "plTuongTacBaiViet";
		plTuongTacBaiViet.Size = new System.Drawing.Size(657, 266);
		plTuongTacBaiViet.TabIndex = 204;
		cbbOptionsPost.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbOptionsPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbOptionsPost.DropDownWidth = 200;
		cbbOptionsPost.FormattingEnabled = true;
		cbbOptionsPost.Location = new System.Drawing.Point(141, 81);
		cbbOptionsPost.Name = "cbbOptionsPost";
		cbbOptionsPost.Size = new System.Drawing.Size(153, 24);
		cbbOptionsPost.TabIndex = 200;
		cbbOptionsPost.SelectedIndexChanged += new System.EventHandler(cbbOptionsPost_SelectedIndexChanged);
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(29, 84);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(64, 16);
		label4.TabIndex = 201;
		label4.Text = "Tu\u0300y cho\u0323n:";
		E186058D.Location = new System.Drawing.Point(238, 140);
		E186058D.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E186058D.Name = "nudDelayTo";
		E186058D.Size = new System.Drawing.Size(56, 23);
		E186058D.TabIndex = 198;
		nudDelayFrom.Location = new System.Drawing.Point(141, 140);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 197;
		E2B75A14.Location = new System.Drawing.Point(141, 52);
		E2B75A14.Name = "txtTenHanhDong";
		E2B75A14.Size = new System.Drawing.Size(153, 23);
		E2B75A14.TabIndex = 194;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(203, 142);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 203;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(29, 142);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 201;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		EA9F198C.AutoSize = true;
		EA9F198C.Location = new System.Drawing.Point(29, 55);
		EA9F198C.Name = "label1";
		EA9F198C.Size = new System.Drawing.Size(98, 16);
		EA9F198C.TabIndex = 199;
		EA9F198C.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(368, 428);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(261, 428);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		EFB17AA4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EFB17AA4.BackColor = System.Drawing.Color.White;
		EFB17AA4.BorderRadius = 0;
		EFB17AA4.BottomSahddow = true;
		EFB17AA4.color = System.Drawing.Color.DarkViolet;
		EFB17AA4.Controls.Add(CF87E80E);
		EFB17AA4.LeftSahddow = false;
		EFB17AA4.Location = new System.Drawing.Point(1, 0);
		EFB17AA4.Name = "bunifuCards1";
		EFB17AA4.RightSahddow = true;
		EFB17AA4.ShadowDepth = 20;
		EFB17AA4.Size = new System.Drawing.Size(717, 37);
		EFB17AA4.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(720, 471);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBaiVietTrenTuong";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBaiVietTrenTuong_Load);
		CF87E80E.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		tabOptionsPost.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)A1B61D81).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)E186058D).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		EFB17AA4.ResumeLayout(false);
		ResumeLayout(false);
	}
}
