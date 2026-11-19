using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDUptopBaiViet : Form
{
	internal GClass4 D59FEF27;

	internal string string_0;

	internal string string_1;

	internal string DD91B8AB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl E3A4C79C;

	internal BunifuDragControl D68978B0;

	internal Panel F90FDEBD;

	internal NumericUpDown CF124A18;

	internal NumericUpDown nudDelayFrom;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label BC01C625;

	internal Button btnCancel;

	internal Button D0106B0B;

	internal BunifuCards F39BFEBC;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label label2;

	internal NumericUpDown nudTimeTo;

	internal NumericUpDown nudTimeFrom;

	internal Label F8099306;

	internal Label C415F7AE;

	internal Panel B620F58A;

	internal RichTextBox txtComment;

	internal Label lblComment;

	internal RichTextBox txtIdPost;

	internal NumericUpDown nudSoLuongUidFrom;

	internal NumericUpDown nudSoLuongUidTo;

	internal Label label66;

	internal CheckBox A221D73D;

	internal ComboBox A9B16B24;

	internal Button btnHuongDanNhapNoiDung;

	internal Label label8;

	internal CheckBox D9044E13;

	internal Panel panel2;

	internal CheckBox ckbUuTienMbasic;

	internal Label label25;

	internal Label label27;

	internal NumericUpDown AD852898;

	internal NumericUpDown nudDelayDeleteTo;

	internal Label label4;

	internal Label label5;

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

	public fHDUptopBaiViet(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		DD91B8AB = string_3;
		string aA239C = bunifuCustomLabel1.Text.Replace("Câ\u0301u hi\u0300nh ", "").Replace("Configure ", "");
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
			D0106B0B.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		D59FEF27 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDUptopBaiViet_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			nudSoLuongUidFrom.Value = D59FEF27.method_2("nudSoLuongUidFrom", 1);
			nudSoLuongUidTo.Value = D59FEF27.method_2("nudSoLuongUidTo", 1);
			nudDelayFrom.Value = D59FEF27.method_2("nudDelayFrom", 3);
			CF124A18.Value = D59FEF27.method_2("nudDelayTo", 5);
			txtIdPost.Text = D59FEF27.BDB80B23("txtIdPost");
			D9044E13.Checked = D59FEF27.method_3("ckbTuDongXoa");
			ckbUuTienMbasic.Checked = D59FEF27.method_3("ckbUuTienMbasic");
			nudTimeFrom.Value = D59FEF27.method_2("nudTimeFrom", 3);
			nudTimeTo.Value = D59FEF27.method_2("nudTimeTo", 5);
			txtComment.Text = D59FEF27.BDB80B23("txtComment");
			A9B16B24.SelectedIndex = D59FEF27.method_2("typeNganCach");
			A221D73D.Checked = D59FEF27.method_3("ckbAutoDeleteComment");
			AD852898.Value = D59FEF27.method_2("nudDelayDeleteFrom", 1);
			nudDelayDeleteTo.Value = D59FEF27.method_2("nudDelayDeleteTo", 1);
		}
		catch
		{
		}
		method_1();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(A9B16B24, list_);
	}

	private void E1B7D32C(object sender, EventArgs e)
	{
		Close();
	}

	private void B12E62B2(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
		gClass.method_4("nudSoLuongUidTo", nudSoLuongUidTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", CF124A18.Value);
		gClass.method_4("txtIdPost", txtIdPost.Text.Trim());
		gClass.method_4("ckbTuDongXoa", D9044E13.Checked);
		gClass.method_4("ckbUuTienMbasic", ckbUuTienMbasic.Checked);
		gClass.method_4("nudTimeFrom", nudTimeFrom.Value);
		gClass.method_4("nudTimeTo", nudTimeTo.Value);
		gClass.method_4("txtComment", txtComment.Text.Trim());
		gClass.method_4("typeNganCach", A9B16B24.SelectedIndex);
		gClass.method_4("ckbAutoDeleteComment", A221D73D.Checked);
		gClass.method_4("nudDelayDeleteFrom", AD852898.Value);
		gClass.method_4("nudDelayDeleteTo", nudDelayDeleteTo.Value);
		string e013A = gClass.ED11179C();
		if (DD91B8AB == "")
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
			if (Class154.smethod_13(DD91B8AB, text, e013A))
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

	private void F90FDEBD_Paint(object sender, PaintEventArgs e)
	{
		if (F90FDEBD.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, F90FDEBD.ClientSize.Width - num, F90FDEBD.ClientSize.Height - num));
		}
	}

	private void C618A81F(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, lblComment, A9B16B24.SelectedIndex);
	}

	private void method_1()
	{
		C618A81F(null, null);
	}

	private void D4852FAF(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdPost, label2);
	}

	private void F90FDEBD_Click(object sender, EventArgs e)
	{
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void A9B16B24_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, lblComment, A9B16B24.SelectedIndex);
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (A9B16B24.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtComment.Focus();
	}

	private void B620F58A_Paint(object sender, PaintEventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDUptopBaiViet));
		E3A4C79C = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		D68978B0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		F90FDEBD = new System.Windows.Forms.Panel();
		label25 = new System.Windows.Forms.Label();
		label27 = new System.Windows.Forms.Label();
		B620F58A = new System.Windows.Forms.Panel();
		A9B16B24 = new System.Windows.Forms.ComboBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		label8 = new System.Windows.Forms.Label();
		A221D73D = new System.Windows.Forms.CheckBox();
		txtComment = new System.Windows.Forms.RichTextBox();
		lblComment = new System.Windows.Forms.Label();
		AD852898 = new System.Windows.Forms.NumericUpDown();
		panel2 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		txtIdPost = new System.Windows.Forms.RichTextBox();
		D9044E13 = new System.Windows.Forms.CheckBox();
		nudDelayDeleteTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
		label66 = new System.Windows.Forms.Label();
		nudTimeTo = new System.Windows.Forms.NumericUpDown();
		CF124A18 = new System.Windows.Forms.NumericUpDown();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		F8099306 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		C415F7AE = new System.Windows.Forms.Label();
		BC01C625 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		D0106B0B = new System.Windows.Forms.Button();
		F39BFEBC = new Bunifu.Framework.UI.BunifuCards();
		ckbUuTienMbasic = new System.Windows.Forms.CheckBox();
		label4 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		F90FDEBD.SuspendLayout();
		B620F58A.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AD852898).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayDeleteTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)CF124A18).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		F39BFEBC.SuspendLayout();
		SuspendLayout();
		E3A4C79C.Fixed = true;
		E3A4C79C.Horizontal = true;
		E3A4C79C.TargetControl = bunifuCustomLabel1;
		E3A4C79C.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(660, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh Uptop ba\u0300i viê\u0301t";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D68978B0.Fixed = true;
		D68978B0.Horizontal = true;
		D68978B0.TargetControl = pnlHeader;
		D68978B0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(660, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(629, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(E1B7D32C);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		F90FDEBD.BackColor = System.Drawing.Color.White;
		F90FDEBD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F90FDEBD.Controls.Add(label4);
		F90FDEBD.Controls.Add(label5);
		F90FDEBD.Controls.Add(label25);
		F90FDEBD.Controls.Add(label27);
		F90FDEBD.Controls.Add(B620F58A);
		F90FDEBD.Controls.Add(AD852898);
		F90FDEBD.Controls.Add(panel2);
		F90FDEBD.Controls.Add(nudDelayDeleteTo);
		F90FDEBD.Controls.Add(nudSoLuongUidFrom);
		F90FDEBD.Controls.Add(nudSoLuongUidTo);
		F90FDEBD.Controls.Add(label66);
		F90FDEBD.Controls.Add(nudTimeTo);
		F90FDEBD.Controls.Add(CF124A18);
		F90FDEBD.Controls.Add(nudTimeFrom);
		F90FDEBD.Controls.Add(nudDelayFrom);
		F90FDEBD.Controls.Add(txtTenHanhDong);
		F90FDEBD.Controls.Add(F8099306);
		F90FDEBD.Controls.Add(label7);
		F90FDEBD.Controls.Add(C415F7AE);
		F90FDEBD.Controls.Add(BC01C625);
		F90FDEBD.Controls.Add(btnCancel);
		F90FDEBD.Controls.Add(D0106B0B);
		F90FDEBD.Controls.Add(F39BFEBC);
		F90FDEBD.Controls.Add(ckbUuTienMbasic);
		F90FDEBD.Cursor = System.Windows.Forms.Cursors.Arrow;
		F90FDEBD.Dock = System.Windows.Forms.DockStyle.Fill;
		F90FDEBD.Location = new System.Drawing.Point(0, 0);
		F90FDEBD.Name = "panel1";
		F90FDEBD.Size = new System.Drawing.Size(663, 476);
		F90FDEBD.TabIndex = 0;
		F90FDEBD.Click += new System.EventHandler(F90FDEBD_Click);
		F90FDEBD.Paint += new System.Windows.Forms.PaintEventHandler(F90FDEBD_Paint);
		label25.AutoSize = true;
		label25.Location = new System.Drawing.Point(314, 108);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(135, 16);
		label25.TabIndex = 34;
		label25.Text = "Chơ\u0300 xo\u0301a comment (s):";
		label27.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label27.Location = new System.Drawing.Point(526, 108);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(29, 16);
		label27.TabIndex = 38;
		label27.Text = ">";
		label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B620F58A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B620F58A.Controls.Add(A9B16B24);
		B620F58A.Controls.Add(btnHuongDanNhapNoiDung);
		B620F58A.Controls.Add(label8);
		B620F58A.Controls.Add(A221D73D);
		B620F58A.Controls.Add(txtComment);
		B620F58A.Controls.Add(lblComment);
		B620F58A.Location = new System.Drawing.Point(317, 135);
		B620F58A.Name = "plCommentText";
		B620F58A.Size = new System.Drawing.Size(311, 273);
		B620F58A.TabIndex = 164;
		B620F58A.Paint += new System.Windows.Forms.PaintEventHandler(B620F58A_Paint);
		A9B16B24.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A9B16B24.Cursor = System.Windows.Forms.Cursors.Hand;
		A9B16B24.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A9B16B24.FormattingEnabled = true;
		A9B16B24.Location = new System.Drawing.Point(69, 219);
		A9B16B24.Name = "cbbTuyChonNoiDung";
		A9B16B24.Size = new System.Drawing.Size(202, 24);
		A9B16B24.TabIndex = 180;
		A9B16B24.SelectedIndexChanged += new System.EventHandler(A9B16B24_SelectedIndexChanged);
		btnHuongDanNhapNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(277, 218);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 179;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(3, 222);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 178;
		label8.Text = "Tùy chọn:";
		A221D73D.AutoSize = true;
		A221D73D.Cursor = System.Windows.Forms.Cursors.Hand;
		A221D73D.Location = new System.Drawing.Point(6, 247);
		A221D73D.Name = "ckbAutoDeleteComment";
		A221D73D.Size = new System.Drawing.Size(169, 20);
		A221D73D.TabIndex = 176;
		A221D73D.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		A221D73D.UseVisualStyleBackColor = true;
		txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtComment.Location = new System.Drawing.Point(7, 26);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(296, 186);
		txtComment.TabIndex = 1;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(C618A81F);
		lblComment.AutoSize = true;
		lblComment.Location = new System.Drawing.Point(3, 6);
		lblComment.Name = "lblComment";
		lblComment.Size = new System.Drawing.Size(139, 16);
		lblComment.TabIndex = 0;
		lblComment.Text = "Nội dung bình luận (0):";
		AD852898.Location = new System.Drawing.Point(455, 106);
		AD852898.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		AD852898.Name = "nudDelayDeleteFrom";
		AD852898.Size = new System.Drawing.Size(56, 23);
		AD852898.TabIndex = 5;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txtIdPost);
		panel2.Controls.Add(D9044E13);
		panel2.Location = new System.Drawing.Point(30, 135);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(252, 273);
		panel2.TabIndex = 181;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(3, 4);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(176, 16);
		label2.TabIndex = 40;
		label2.Text = "Nhâ\u0323p Id hoă\u0323c link ba\u0300i viê\u0301t (0):";
		txtIdPost.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIdPost.Location = new System.Drawing.Point(6, 24);
		txtIdPost.Name = "txtIdPost";
		txtIdPost.Size = new System.Drawing.Size(238, 220);
		txtIdPost.TabIndex = 1;
		txtIdPost.Text = "";
		txtIdPost.WordWrap = false;
		txtIdPost.TextChanged += new System.EventHandler(D4852FAF);
		D9044E13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D9044E13.AutoSize = true;
		D9044E13.Cursor = System.Windows.Forms.Cursors.Hand;
		D9044E13.Location = new System.Drawing.Point(6, 247);
		D9044E13.Name = "ckbTuDongXoa";
		D9044E13.Size = new System.Drawing.Size(192, 20);
		D9044E13.TabIndex = 176;
		D9044E13.Text = "Xóa link ba\u0300i viê\u0301t đã tương tác";
		D9044E13.UseVisualStyleBackColor = true;
		nudDelayDeleteTo.Location = new System.Drawing.Point(572, 106);
		nudDelayDeleteTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayDeleteTo.Name = "nudDelayDeleteTo";
		nudDelayDeleteTo.Size = new System.Drawing.Size(56, 23);
		nudDelayDeleteTo.TabIndex = 6;
		nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidFrom.Location = new System.Drawing.Point(129, 77);
		nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
		nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidFrom.TabIndex = 167;
		nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidTo.Location = new System.Drawing.Point(226, 77);
		nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidTo.Name = "nudSoLuongUidTo";
		nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidTo.TabIndex = 168;
		nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label66.Location = new System.Drawing.Point(191, 79);
		label66.Name = "label66";
		label66.Size = new System.Drawing.Size(29, 16);
		label66.TabIndex = 171;
		label66.Text = ">";
		label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudTimeTo.Location = new System.Drawing.Point(572, 77);
		nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeTo.Name = "nudTimeTo";
		nudTimeTo.Size = new System.Drawing.Size(56, 23);
		nudTimeTo.TabIndex = 4;
		CF124A18.Location = new System.Drawing.Point(226, 106);
		CF124A18.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CF124A18.Name = "nudDelayTo";
		CF124A18.Size = new System.Drawing.Size(56, 23);
		CF124A18.TabIndex = 4;
		nudTimeFrom.Location = new System.Drawing.Point(455, 77);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(56, 23);
		nudTimeFrom.TabIndex = 3;
		nudDelayFrom.Location = new System.Drawing.Point(129, 106);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		txtTenHanhDong.Location = new System.Drawing.Point(129, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		F8099306.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F8099306.Location = new System.Drawing.Point(526, 79);
		F8099306.Name = "label9";
		F8099306.Size = new System.Drawing.Size(29, 16);
		F8099306.TabIndex = 38;
		F8099306.Text = ">";
		F8099306.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(191, 108);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C415F7AE.AutoSize = true;
		C415F7AE.Location = new System.Drawing.Point(314, 79);
		C415F7AE.Name = "label3";
		C415F7AE.Size = new System.Drawing.Size(103, 16);
		C415F7AE.TabIndex = 34;
		C415F7AE.Text = "Xem bài viết (s):";
		BC01C625.AutoSize = true;
		BC01C625.Location = new System.Drawing.Point(27, 52);
		BC01C625.Name = "label1";
		BC01C625.Size = new System.Drawing.Size(98, 16);
		BC01C625.TabIndex = 31;
		BC01C625.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(317, 434);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		D0106B0B.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D0106B0B.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		D0106B0B.Cursor = System.Windows.Forms.Cursors.Hand;
		D0106B0B.FlatAppearance.BorderSize = 0;
		D0106B0B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D0106B0B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D0106B0B.ForeColor = System.Drawing.Color.White;
		D0106B0B.Location = new System.Drawing.Point(210, 434);
		D0106B0B.Name = "btnAdd";
		D0106B0B.Size = new System.Drawing.Size(92, 29);
		D0106B0B.TabIndex = 9;
		D0106B0B.Text = "Thêm";
		D0106B0B.UseVisualStyleBackColor = false;
		D0106B0B.Click += new System.EventHandler(B12E62B2);
		F39BFEBC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F39BFEBC.BackColor = System.Drawing.Color.White;
		F39BFEBC.BorderRadius = 0;
		F39BFEBC.BottomSahddow = true;
		F39BFEBC.color = System.Drawing.Color.DarkViolet;
		F39BFEBC.Controls.Add(pnlHeader);
		F39BFEBC.LeftSahddow = false;
		F39BFEBC.Location = new System.Drawing.Point(1, 0);
		F39BFEBC.Name = "bunifuCards1";
		F39BFEBC.RightSahddow = true;
		F39BFEBC.ShadowDepth = 20;
		F39BFEBC.Size = new System.Drawing.Size(660, 37);
		F39BFEBC.TabIndex = 28;
		ckbUuTienMbasic.AutoSize = true;
		ckbUuTienMbasic.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUuTienMbasic.Location = new System.Drawing.Point(30, 414);
		ckbUuTienMbasic.Name = "ckbUuTienMbasic";
		ckbUuTienMbasic.Size = new System.Drawing.Size(173, 20);
		ckbUuTienMbasic.TabIndex = 176;
		ckbUuTienMbasic.Text = "Ưu tiên chạy bằng mbasic";
		ckbUuTienMbasic.UseVisualStyleBackColor = true;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 108);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(87, 16);
		label4.TabIndex = 182;
		label4.Text = "Gia\u0303n ca\u0301ch (s):";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 79);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(63, 16);
		label5.TabIndex = 183;
		label5.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(663, 476);
		base.Controls.Add(F90FDEBD);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDUptopBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDUptopBaiViet_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		F90FDEBD.ResumeLayout(false);
		F90FDEBD.PerformLayout();
		B620F58A.ResumeLayout(false);
		B620F58A.PerformLayout();
		((System.ComponentModel.ISupportInitialize)AD852898).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayDeleteTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
		((System.ComponentModel.ISupportInitialize)CF124A18).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		F39BFEBC.ResumeLayout(false);
		ResumeLayout(false);
	}
}
