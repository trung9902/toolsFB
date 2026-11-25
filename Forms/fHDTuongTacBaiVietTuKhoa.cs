using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDTuongTacBaiVietTuKhoa : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string A22AB50D;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool BDB9021B;

	internal ucTuongTacBaiVietv2 ucTuongTacBaiVietv2_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl AEBABE16;

	internal Panel F22CDB88;

	internal Button ED230F8A;

	internal Button btnAdd;

	internal BunifuCards E5323C2C;

	internal Panel F2066A30;

	internal Button C8B14AA0;

	internal PictureBox E90FB13D;

	internal BunifuCustomLabel AB0922B1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown DC3A6BB1;

	internal TextBox AE055317;

	internal Label label7;

	internal Label label5;

	internal Label label1;

	internal Panel ACA7B5B4;

	internal Panel AD10E79C;

	internal TabControl tabOptionsPost;

	internal TabPage tabPage1;

	internal Label label2;

	internal Label D824F681;

	internal NumericUpDown E6992A38;

	internal NumericUpDown nudSoLuongTo;

	internal TabPage tabPage2;

	internal Label F2A34E05;

	internal Label F029B6A1;

	internal NumericUpDown nudThoiGianFrom;

	internal NumericUpDown nudThoiGianTo;

	internal ComboBox cbbOptionsPost;

	internal Label label4;

	internal RichTextBox B0BABC86;

	internal Label E484C021;

	internal CheckBox DA2D3688;

	public static bool AEB1510D
	{
		[CompilerGenerated]
		get
		{
			return BDB9021B;
		}
		[CompilerGenerated]
		set
		{
			BDB9021B = value;
		}
	}

	public fHDTuongTacBaiVietTuKhoa(string string_2, string FCAAA62C = "")
	{
		InitializeComponent();
		AEB1510D = false;
		string_0 = string_2;
		string_1 = FCAAA62C;
		string aA239C = Language.GetValue(AB0922B1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (FCAAA62C == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			A22AB50D = dataTable.Rows[0]["Id_TuongTac"].ToString();
			AE055317.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(FCAAA62C);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			AE055317.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDTuongTacBaiVietTuKhoa_Load(object sender, EventArgs e)
	{
		C3A66D36();
		try
		{
			cbbOptionsPost.SelectedIndex = gclass4_0.method_2("cbbOptionsPost");
			E6992A38.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 2);
			nudThoiGianFrom.Value = gclass4_0.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = gclass4_0.method_2("nudThoiGianTo", 30);
			DC3A6BB1.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			B0BABC86.Text = gclass4_0.BDB80B23("txtTuKhoa");
			DA2D3688.Checked = gclass4_0.method_3("ckbPostAds");
			ucTuongTacBaiVietv2_0 = new ucTuongTacBaiVietv2(gclass4_0);
			ACA7B5B4.Controls.Add(ucTuongTacBaiVietv2_0);
		}
		catch
		{
		}
	}

	private void C3A66D36()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(cbbOptionsPost, list_);
	}

	private void C8B14AA0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = AE055317.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = ucTuongTacBaiVietv2_0.method_2();
		gClass.method_4("cbbOptionsPost", cbbOptionsPost.SelectedIndex);
		gClass.method_4("nudSoLuongFrom", E6992A38.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudThoiGianFrom", nudThoiGianFrom.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", DC3A6BB1.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("txtTuKhoa", B0BABC86.Text);
		gClass.method_4("ckbPostAds", DA2D3688.Checked);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, A22AB50D, e013A))
				{
					AEB1510D = true;
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
			if (Class154.smethod_13(string_1, text, e013A))
			{
				AEB1510D = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void ED230F8A_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F22CDB88_Paint(object sender, PaintEventArgs e)
	{
		if (F22CDB88.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, F22CDB88.ClientSize.Width - num, F22CDB88.ClientSize.Height - num));
		}
	}

	private void D6351511(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
		{
		}
	}

	private void cbbOptionsPost_SelectedIndexChanged(object sender, EventArgs e)
	{
		tabOptionsPost.SelectedIndex = cbbOptionsPost.SelectedIndex;
	}

	private void CA964EB8(object sender, EventArgs e)
	{
		Commom.A9BCAF05(B0BABC86, E484C021);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTuongTacBaiVietTuKhoa));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		AB0922B1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		AEBABE16 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		F2066A30 = new System.Windows.Forms.Panel();
		C8B14AA0 = new System.Windows.Forms.Button();
		E90FB13D = new System.Windows.Forms.PictureBox();
		F22CDB88 = new System.Windows.Forms.Panel();
		DA2D3688 = new System.Windows.Forms.CheckBox();
		B0BABC86 = new System.Windows.Forms.RichTextBox();
		E484C021 = new System.Windows.Forms.Label();
		AD10E79C = new System.Windows.Forms.Panel();
		tabOptionsPost = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		label2 = new System.Windows.Forms.Label();
		D824F681 = new System.Windows.Forms.Label();
		E6992A38 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		F2A34E05 = new System.Windows.Forms.Label();
		F029B6A1 = new System.Windows.Forms.Label();
		nudThoiGianFrom = new System.Windows.Forms.NumericUpDown();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		ACA7B5B4 = new System.Windows.Forms.Panel();
		cbbOptionsPost = new System.Windows.Forms.ComboBox();
		label4 = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		DC3A6BB1 = new System.Windows.Forms.NumericUpDown();
		AE055317 = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		ED230F8A = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		E5323C2C = new Bunifu.Framework.UI.BunifuCards();
		F2066A30.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E90FB13D).BeginInit();
		F22CDB88.SuspendLayout();
		AD10E79C.SuspendLayout();
		tabOptionsPost.SuspendLayout();
		tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E6992A38).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)DC3A6BB1).BeginInit();
		E5323C2C.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = AB0922B1;
		bunifuDragControl_0.Vertical = true;
		AB0922B1.BackColor = System.Drawing.Color.Transparent;
		AB0922B1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		AB0922B1.Dock = System.Windows.Forms.DockStyle.Fill;
		AB0922B1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AB0922B1.ForeColor = System.Drawing.Color.Black;
		AB0922B1.Location = new System.Drawing.Point(0, 0);
		AB0922B1.Name = "bunifuCustomLabel1";
		AB0922B1.Size = new System.Drawing.Size(717, 31);
		AB0922B1.TabIndex = 12;
		AB0922B1.Text = "Cấu hình Tương tác bài viết từ khóa";
		AB0922B1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AEBABE16.Fixed = true;
		AEBABE16.Horizontal = true;
		AEBABE16.TargetControl = F2066A30;
		AEBABE16.Vertical = true;
		F2066A30.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F2066A30.BackColor = System.Drawing.Color.White;
		F2066A30.Controls.Add(C8B14AA0);
		F2066A30.Controls.Add(E90FB13D);
		F2066A30.Controls.Add(AB0922B1);
		F2066A30.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F2066A30.Location = new System.Drawing.Point(0, 3);
		F2066A30.Name = "pnlHeader";
		F2066A30.Size = new System.Drawing.Size(717, 31);
		F2066A30.TabIndex = 9;
		C8B14AA0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		C8B14AA0.Cursor = System.Windows.Forms.Cursors.Hand;
		C8B14AA0.FlatAppearance.BorderSize = 0;
		C8B14AA0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C8B14AA0.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C8B14AA0.ForeColor = System.Drawing.Color.White;
		C8B14AA0.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		C8B14AA0.Location = new System.Drawing.Point(686, 1);
		C8B14AA0.Name = "button1";
		C8B14AA0.Size = new System.Drawing.Size(30, 30);
		C8B14AA0.TabIndex = 77;
		C8B14AA0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		C8B14AA0.UseVisualStyleBackColor = true;
		C8B14AA0.Click += new System.EventHandler(C8B14AA0_Click);
		E90FB13D.Cursor = System.Windows.Forms.Cursors.Default;
		E90FB13D.Image = Class155.DD225F0D;
		E90FB13D.Location = new System.Drawing.Point(3, 2);
		E90FB13D.Name = "pictureBox1";
		E90FB13D.Size = new System.Drawing.Size(34, 27);
		E90FB13D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E90FB13D.TabIndex = 76;
		E90FB13D.TabStop = false;
		E90FB13D.Click += new System.EventHandler(D6351511);
		F22CDB88.BackColor = System.Drawing.Color.White;
		F22CDB88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F22CDB88.Controls.Add(DA2D3688);
		F22CDB88.Controls.Add(B0BABC86);
		F22CDB88.Controls.Add(E484C021);
		F22CDB88.Controls.Add(AD10E79C);
		F22CDB88.Controls.Add(ACA7B5B4);
		F22CDB88.Controls.Add(cbbOptionsPost);
		F22CDB88.Controls.Add(label4);
		F22CDB88.Controls.Add(nudDelayTo);
		F22CDB88.Controls.Add(DC3A6BB1);
		F22CDB88.Controls.Add(AE055317);
		F22CDB88.Controls.Add(label7);
		F22CDB88.Controls.Add(label5);
		F22CDB88.Controls.Add(label1);
		F22CDB88.Controls.Add(ED230F8A);
		F22CDB88.Controls.Add(btnAdd);
		F22CDB88.Controls.Add(E5323C2C);
		F22CDB88.Cursor = System.Windows.Forms.Cursors.Arrow;
		F22CDB88.Dock = System.Windows.Forms.DockStyle.Fill;
		F22CDB88.Location = new System.Drawing.Point(0, 0);
		F22CDB88.Name = "panel1";
		F22CDB88.Size = new System.Drawing.Size(720, 468);
		F22CDB88.TabIndex = 0;
		F22CDB88.Paint += new System.Windows.Forms.PaintEventHandler(F22CDB88_Paint);
		DA2D3688.AutoSize = true;
		DA2D3688.Cursor = System.Windows.Forms.Cursors.Hand;
		DA2D3688.Location = new System.Drawing.Point(619, 54);
		DA2D3688.Name = "ckbPostAds";
		DA2D3688.Size = new System.Drawing.Size(75, 20);
		DA2D3688.TabIndex = 207;
		DA2D3688.Text = "Post Ads";
		DA2D3688.UseVisualStyleBackColor = true;
		DA2D3688.Visible = false;
		B0BABC86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B0BABC86.Location = new System.Drawing.Point(380, 75);
		B0BABC86.Name = "txtTuKhoa";
		B0BABC86.Size = new System.Drawing.Size(309, 60);
		B0BABC86.TabIndex = 205;
		B0BABC86.Text = "";
		B0BABC86.WordWrap = false;
		B0BABC86.TextChanged += new System.EventHandler(CA964EB8);
		E484C021.AutoSize = true;
		E484C021.Location = new System.Drawing.Point(377, 55);
		E484C021.Name = "lblTuKhoa";
		E484C021.Size = new System.Drawing.Size(171, 16);
		E484C021.TabIndex = 206;
		E484C021.Text = "Nhâ\u0323p danh sa\u0301ch từ khóa (0):";
		AD10E79C.Controls.Add(tabOptionsPost);
		AD10E79C.Location = new System.Drawing.Point(30, 111);
		AD10E79C.Name = "panel2";
		AD10E79C.Size = new System.Drawing.Size(266, 23);
		AD10E79C.TabIndex = 202;
		tabOptionsPost.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabOptionsPost.Controls.Add(tabPage1);
		tabOptionsPost.Controls.Add(tabPage2);
		tabOptionsPost.Location = new System.Drawing.Point(-5, -5);
		tabOptionsPost.Name = "tabOptionsPost";
		tabOptionsPost.SelectedIndex = 0;
		tabOptionsPost.Size = new System.Drawing.Size(276, 54);
		tabOptionsPost.TabIndex = 198;
		tabPage1.Controls.Add(label2);
		tabPage1.Controls.Add(D824F681);
		tabPage1.Controls.Add(E6992A38);
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
		D824F681.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D824F681.Location = new System.Drawing.Point(174, 3);
		D824F681.Name = "label3";
		D824F681.Size = new System.Drawing.Size(29, 16);
		D824F681.TabIndex = 1;
		D824F681.Text = ">";
		D824F681.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E6992A38.Location = new System.Drawing.Point(112, 1);
		E6992A38.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E6992A38.Name = "nudSoLuongFrom";
		E6992A38.Size = new System.Drawing.Size(56, 23);
		E6992A38.TabIndex = 0;
		nudSoLuongTo.Location = new System.Drawing.Point(209, 1);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		tabPage2.Controls.Add(F2A34E05);
		tabPage2.Controls.Add(F029B6A1);
		tabPage2.Controls.Add(nudThoiGianFrom);
		tabPage2.Controls.Add(nudThoiGianTo);
		tabPage2.Location = new System.Drawing.Point(4, 4);
		tabPage2.Name = "tabPage2";
		tabPage2.Padding = new System.Windows.Forms.Padding(3);
		tabPage2.Size = new System.Drawing.Size(268, 28);
		tabPage2.TabIndex = 1;
		tabPage2.Text = "tabPage2";
		tabPage2.UseVisualStyleBackColor = true;
		F2A34E05.AutoSize = true;
		F2A34E05.Location = new System.Drawing.Point(0, 3);
		F2A34E05.Name = "label8";
		F2A34E05.Size = new System.Drawing.Size(85, 16);
		F2A34E05.TabIndex = 40;
		F2A34E05.Text = "Thơ\u0300i gian (s):";
		F029B6A1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F029B6A1.Location = new System.Drawing.Point(174, 3);
		F029B6A1.Name = "label9";
		F029B6A1.Size = new System.Drawing.Size(29, 16);
		F029B6A1.TabIndex = 41;
		F029B6A1.Text = ">";
		F029B6A1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudThoiGianFrom.Location = new System.Drawing.Point(112, 1);
		nudThoiGianFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianFrom.Name = "nudThoiGianFrom";
		nudThoiGianFrom.Size = new System.Drawing.Size(56, 23);
		nudThoiGianFrom.TabIndex = 38;
		nudThoiGianTo.Location = new System.Drawing.Point(209, 1);
		nudThoiGianTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianTo.Name = "nudThoiGianTo";
		nudThoiGianTo.Size = new System.Drawing.Size(56, 23);
		nudThoiGianTo.TabIndex = 39;
		ACA7B5B4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		ACA7B5B4.Location = new System.Drawing.Point(32, 140);
		ACA7B5B4.Name = "plTuongTacBaiViet";
		ACA7B5B4.Size = new System.Drawing.Size(657, 266);
		ACA7B5B4.TabIndex = 204;
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
		nudDelayTo.Location = new System.Drawing.Point(238, 140);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 198;
		DC3A6BB1.Location = new System.Drawing.Point(141, 140);
		DC3A6BB1.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		DC3A6BB1.Name = "nudDelayFrom";
		DC3A6BB1.Size = new System.Drawing.Size(56, 23);
		DC3A6BB1.TabIndex = 197;
		AE055317.Location = new System.Drawing.Point(141, 52);
		AE055317.Name = "txtTenHanhDong";
		AE055317.Size = new System.Drawing.Size(153, 23);
		AE055317.TabIndex = 194;
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
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(29, 55);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 199;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		ED230F8A.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ED230F8A.BackColor = System.Drawing.Color.Maroon;
		ED230F8A.Cursor = System.Windows.Forms.Cursors.Hand;
		ED230F8A.FlatAppearance.BorderSize = 0;
		ED230F8A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		ED230F8A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		ED230F8A.ForeColor = System.Drawing.Color.White;
		ED230F8A.Location = new System.Drawing.Point(368, 425);
		ED230F8A.Name = "btnCancel";
		ED230F8A.Size = new System.Drawing.Size(92, 29);
		ED230F8A.TabIndex = 10;
		ED230F8A.Text = "Đóng";
		ED230F8A.UseVisualStyleBackColor = false;
		ED230F8A.Click += new System.EventHandler(ED230F8A_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(261, 425);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		E5323C2C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E5323C2C.BackColor = System.Drawing.Color.White;
		E5323C2C.BorderRadius = 0;
		E5323C2C.BottomSahddow = true;
		E5323C2C.color = System.Drawing.Color.DarkViolet;
		E5323C2C.Controls.Add(F2066A30);
		E5323C2C.LeftSahddow = false;
		E5323C2C.Location = new System.Drawing.Point(1, 0);
		E5323C2C.Name = "bunifuCards1";
		E5323C2C.RightSahddow = true;
		E5323C2C.ShadowDepth = 20;
		E5323C2C.Size = new System.Drawing.Size(717, 37);
		E5323C2C.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(720, 468);
		base.Controls.Add(F22CDB88);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTuongTacBaiVietTuKhoa";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDTuongTacBaiVietTuKhoa_Load);
		F2066A30.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)E90FB13D).EndInit();
		F22CDB88.ResumeLayout(false);
		F22CDB88.PerformLayout();
		AD10E79C.ResumeLayout(false);
		tabOptionsPost.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)E6992A38).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)DC3A6BB1).EndInit();
		E5323C2C.ResumeLayout(false);
		ResumeLayout(false);
	}
}
