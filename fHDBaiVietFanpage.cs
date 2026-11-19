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

public class fHDBaiVietFanpage : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string D0B46ABE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool FEB6E19D;

	internal ucTuongTacBaiVietv2 A79B6D88;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal TextBox B21EDE0C;

	internal Label label7;

	internal Label B019C233;

	internal Label label1;

	internal Button D308D691;

	internal Button F82B971A;

	internal BunifuCards A92644A9;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel DA233C89;

	internal Label E13135B6;

	internal NumericUpDown nudSoLuongPageFrom;

	internal NumericUpDown nudSoLuongPageTo;

	internal Label EA1E88B4;

	internal Label lblStatusUid;

	internal RichTextBox AE1C3782;

	internal CheckBox B828CE81;

	internal Panel E22D901C;

	internal Panel CF929731;

	internal TabControl tabOptionsPost;

	internal TabPage F08E3F81;

	internal Label label19;

	internal Label CAA9FB94;

	internal NumericUpDown EBA2ED99;

	internal NumericUpDown nudSoLuongBaiVietTo;

	internal TabPage tabPage2;

	internal Label C19D2FAD;

	internal Label A81E9138;

	internal NumericUpDown nudThoiGianFrom;

	internal NumericUpDown nudThoiGianTo;

	internal ComboBox cbbOptionsPost;

	internal Label label6;

	public static bool C880F83A
	{
		[CompilerGenerated]
		get
		{
			return FEB6E19D;
		}
		[CompilerGenerated]
		set
		{
			FEB6E19D = value;
		}
	}

	public fHDBaiVietFanpage(string string_2, string string_3 = "")
	{
		InitializeComponent();
		C880F83A = false;
		string_0 = string_2;
		D0B46ABE = string_3;
		string aA239C = Language.GetValue(DA233C89.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			B21EDE0C.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			F82B971A.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			B21EDE0C.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDBaiVietFanpage_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			nudSoLuongPageFrom.Value = gclass4_0.method_2("nudSoLuongPageFrom", 1);
			nudSoLuongPageTo.Value = gclass4_0.method_2("nudSoLuongPageTo", 1);
			cbbOptionsPost.SelectedIndex = gclass4_0.method_2("cbbOptionsPost");
			EBA2ED99.Value = gclass4_0.method_2("nudSoLuongBaiVietFrom", 1);
			nudSoLuongBaiVietTo.Value = gclass4_0.method_2("nudSoLuongBaiVietTo", 2);
			nudThoiGianFrom.Value = gclass4_0.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = gclass4_0.method_2("nudThoiGianTo", 30);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			AE1C3782.Text = gclass4_0.BDB80B23("txtUid");
			B828CE81.Checked = gclass4_0.method_3("ckbLikePage");
			A79B6D88 = new ucTuongTacBaiVietv2(gclass4_0);
			E22D901C.Controls.Add(A79B6D88);
		}
		catch
		{
		}
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(cbbOptionsPost, list_);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F82B971A_Click(object sender, EventArgs e)
	{
		string text = B21EDE0C.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		List<string> list_ = AE1C3782.Lines.ToList();
		list_ = Commom.smethod_36(list_);
		if (list_.Count == 0)
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch Id page!", 3);
			return;
		}
		GClass4 gClass = A79B6D88.method_2();
		gClass.method_4("nudSoLuongPageFrom", nudSoLuongPageFrom.Value);
		gClass.method_4("nudSoLuongPageTo", nudSoLuongPageTo.Value);
		gClass.method_4("cbbOptionsPost", cbbOptionsPost.SelectedIndex);
		gClass.method_4("nudSoLuongBaiVietFrom", EBA2ED99.Value);
		gClass.method_4("nudSoLuongBaiVietTo", nudSoLuongBaiVietTo.Value);
		gClass.method_4("nudThoiGianFrom", nudThoiGianFrom.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("txtUid", AE1C3782.Text.Trim());
		gClass.method_4("ckbLikePage", B828CE81.Checked);
		string e013A = gClass.ED11179C();
		if (D0B46ABE == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					C880F83A = true;
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
			if (Class154.smethod_13(D0B46ABE, text, e013A))
			{
				C880F83A = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void E5986301(object sender, EventArgs e)
	{
		Close();
	}

	private void D5BBF611(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
		{
		}
	}

	private void AE1C3782_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(AE1C3782, lblStatusUid);
	}

	private void cbbOptionsPost_SelectedIndexChanged(object sender, EventArgs e)
	{
		tabOptionsPost.SelectedIndex = cbbOptionsPost.SelectedIndex;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBaiVietFanpage));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		DA233C89 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		CF929731 = new System.Windows.Forms.Panel();
		tabOptionsPost = new System.Windows.Forms.TabControl();
		F08E3F81 = new System.Windows.Forms.TabPage();
		label19 = new System.Windows.Forms.Label();
		CAA9FB94 = new System.Windows.Forms.Label();
		EBA2ED99 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		nudThoiGianFrom = new System.Windows.Forms.NumericUpDown();
		C19D2FAD = new System.Windows.Forms.Label();
		A81E9138 = new System.Windows.Forms.Label();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		E22D901C = new System.Windows.Forms.Panel();
		cbbOptionsPost = new System.Windows.Forms.ComboBox();
		label6 = new System.Windows.Forms.Label();
		AE1C3782 = new System.Windows.Forms.RichTextBox();
		lblStatusUid = new System.Windows.Forms.Label();
		E13135B6 = new System.Windows.Forms.Label();
		nudSoLuongPageFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongPageTo = new System.Windows.Forms.NumericUpDown();
		EA1E88B4 = new System.Windows.Forms.Label();
		B828CE81 = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		B21EDE0C = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		B019C233 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		D308D691 = new System.Windows.Forms.Button();
		F82B971A = new System.Windows.Forms.Button();
		A92644A9 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		CF929731.SuspendLayout();
		tabOptionsPost.SuspendLayout();
		F08E3F81.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)EBA2ED99).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongPageFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongPageTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		A92644A9.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = DA233C89;
		bunifuDragControl_0.Vertical = true;
		DA233C89.BackColor = System.Drawing.Color.Transparent;
		DA233C89.Cursor = System.Windows.Forms.Cursors.SizeAll;
		DA233C89.Dock = System.Windows.Forms.DockStyle.Fill;
		DA233C89.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DA233C89.ForeColor = System.Drawing.Color.Black;
		DA233C89.Location = new System.Drawing.Point(0, 0);
		DA233C89.Name = "bunifuCustomLabel1";
		DA233C89.Size = new System.Drawing.Size(713, 31);
		DA233C89.TabIndex = 12;
		DA233C89.Text = "Cấu hình Bài viết Fanpage";
		DA233C89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(DA233C89);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(713, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(682, 1);
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
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(CF929731);
		panel1.Controls.Add(E22D901C);
		panel1.Controls.Add(cbbOptionsPost);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(AE1C3782);
		panel1.Controls.Add(lblStatusUid);
		panel1.Controls.Add(E13135B6);
		panel1.Controls.Add(nudSoLuongPageFrom);
		panel1.Controls.Add(nudSoLuongPageTo);
		panel1.Controls.Add(EA1E88B4);
		panel1.Controls.Add(B828CE81);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(B21EDE0C);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(B019C233);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(D308D691);
		panel1.Controls.Add(F82B971A);
		panel1.Controls.Add(A92644A9);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(716, 502);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(D5BBF611);
		CF929731.Controls.Add(tabOptionsPost);
		CF929731.Location = new System.Drawing.Point(28, 137);
		CF929731.Name = "panel2";
		CF929731.Size = new System.Drawing.Size(266, 23);
		CF929731.TabIndex = 205;
		tabOptionsPost.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabOptionsPost.Controls.Add(F08E3F81);
		tabOptionsPost.Controls.Add(tabPage2);
		tabOptionsPost.Location = new System.Drawing.Point(-5, -5);
		tabOptionsPost.Name = "tabOptionsPost";
		tabOptionsPost.SelectedIndex = 0;
		tabOptionsPost.Size = new System.Drawing.Size(276, 54);
		tabOptionsPost.TabIndex = 198;
		F08E3F81.Controls.Add(label19);
		F08E3F81.Controls.Add(CAA9FB94);
		F08E3F81.Controls.Add(EBA2ED99);
		F08E3F81.Controls.Add(nudSoLuongBaiVietTo);
		F08E3F81.Location = new System.Drawing.Point(4, 4);
		F08E3F81.Name = "tabPage1";
		F08E3F81.Padding = new System.Windows.Forms.Padding(3);
		F08E3F81.Size = new System.Drawing.Size(268, 25);
		F08E3F81.TabIndex = 0;
		F08E3F81.Text = "tabPage1";
		F08E3F81.UseVisualStyleBackColor = true;
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label19.Location = new System.Drawing.Point(0, 3);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(105, 16);
		label19.TabIndex = 101;
		label19.Text = "Sô\u0301 ba\u0300i viê\u0301t/page:";
		CAA9FB94.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CAA9FB94.Location = new System.Drawing.Point(174, 3);
		CAA9FB94.Name = "label3";
		CAA9FB94.Size = new System.Drawing.Size(29, 16);
		CAA9FB94.TabIndex = 37;
		CAA9FB94.Text = ">";
		CAA9FB94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		EBA2ED99.Location = new System.Drawing.Point(112, 1);
		EBA2ED99.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		EBA2ED99.Name = "nudSoLuongBaiVietFrom";
		EBA2ED99.Size = new System.Drawing.Size(56, 23);
		EBA2ED99.TabIndex = 3;
		nudSoLuongBaiVietTo.Location = new System.Drawing.Point(209, 1);
		nudSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongBaiVietTo.Name = "nudSoLuongBaiVietTo";
		nudSoLuongBaiVietTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongBaiVietTo.TabIndex = 4;
		tabPage2.Controls.Add(nudThoiGianFrom);
		tabPage2.Controls.Add(C19D2FAD);
		tabPage2.Controls.Add(A81E9138);
		tabPage2.Controls.Add(nudThoiGianTo);
		tabPage2.Location = new System.Drawing.Point(4, 4);
		tabPage2.Name = "tabPage2";
		tabPage2.Padding = new System.Windows.Forms.Padding(3);
		tabPage2.Size = new System.Drawing.Size(268, 28);
		tabPage2.TabIndex = 1;
		tabPage2.Text = "tabPage2";
		tabPage2.UseVisualStyleBackColor = true;
		nudThoiGianFrom.Location = new System.Drawing.Point(112, 1);
		nudThoiGianFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianFrom.Name = "nudThoiGianFrom";
		nudThoiGianFrom.Size = new System.Drawing.Size(56, 23);
		nudThoiGianFrom.TabIndex = 38;
		C19D2FAD.AutoSize = true;
		C19D2FAD.Location = new System.Drawing.Point(0, 3);
		C19D2FAD.Name = "label8";
		C19D2FAD.Size = new System.Drawing.Size(118, 16);
		C19D2FAD.TabIndex = 40;
		C19D2FAD.Text = "Thơ\u0300i gian/page (s):";
		A81E9138.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A81E9138.Location = new System.Drawing.Point(174, 3);
		A81E9138.Name = "label9";
		A81E9138.Size = new System.Drawing.Size(29, 16);
		A81E9138.TabIndex = 41;
		A81E9138.Text = ">";
		A81E9138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudThoiGianTo.Location = new System.Drawing.Point(209, 1);
		nudThoiGianTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianTo.Name = "nudThoiGianTo";
		nudThoiGianTo.Size = new System.Drawing.Size(56, 23);
		nudThoiGianTo.TabIndex = 39;
		E22D901C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E22D901C.Location = new System.Drawing.Point(30, 166);
		E22D901C.Name = "plTuongTacBaiViet";
		E22D901C.Size = new System.Drawing.Size(657, 266);
		E22D901C.TabIndex = 194;
		cbbOptionsPost.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbOptionsPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbOptionsPost.DropDownWidth = 200;
		cbbOptionsPost.FormattingEnabled = true;
		cbbOptionsPost.Location = new System.Drawing.Point(139, 107);
		cbbOptionsPost.Name = "cbbOptionsPost";
		cbbOptionsPost.Size = new System.Drawing.Size(153, 24);
		cbbOptionsPost.TabIndex = 203;
		cbbOptionsPost.SelectedIndexChanged += new System.EventHandler(cbbOptionsPost_SelectedIndexChanged);
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(27, 110);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(64, 16);
		label6.TabIndex = 204;
		label6.Text = "Tu\u0300y cho\u0323n:";
		AE1C3782.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		AE1C3782.Location = new System.Drawing.Point(380, 71);
		AE1C3782.Name = "txtUid";
		AE1C3782.Size = new System.Drawing.Size(307, 64);
		AE1C3782.TabIndex = 7;
		AE1C3782.Text = "";
		AE1C3782.WordWrap = false;
		AE1C3782.TextChanged += new System.EventHandler(AE1C3782_TextChanged);
		lblStatusUid.AutoSize = true;
		lblStatusUid.Location = new System.Drawing.Point(377, 51);
		lblStatusUid.Name = "lblStatusUid";
		lblStatusUid.Size = new System.Drawing.Size(171, 16);
		lblStatusUid.TabIndex = 116;
		lblStatusUid.Text = "Nhâ\u0323p danh sa\u0301ch Id page (0):";
		E13135B6.AutoSize = true;
		E13135B6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		E13135B6.Location = new System.Drawing.Point(27, 80);
		E13135B6.Name = "label49";
		E13135B6.Size = new System.Drawing.Size(95, 16);
		E13135B6.TabIndex = 92;
		E13135B6.Text = "Sô\u0301 lươ\u0323ng page:";
		nudSoLuongPageFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongPageFrom.Location = new System.Drawing.Point(139, 78);
		nudSoLuongPageFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongPageFrom.Name = "nudSoLuongPageFrom";
		nudSoLuongPageFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongPageFrom.TabIndex = 1;
		nudSoLuongPageFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		nudSoLuongPageTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongPageTo.Location = new System.Drawing.Point(236, 78);
		nudSoLuongPageTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongPageTo.Name = "nudSoLuongPageTo";
		nudSoLuongPageTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongPageTo.TabIndex = 2;
		nudSoLuongPageTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		EA1E88B4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		EA1E88B4.Location = new System.Drawing.Point(201, 80);
		EA1E88B4.Name = "label66";
		EA1E88B4.Size = new System.Drawing.Size(29, 16);
		EA1E88B4.TabIndex = 105;
		EA1E88B4.Text = ">";
		EA1E88B4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B828CE81.AutoSize = true;
		B828CE81.Cursor = System.Windows.Forms.Cursors.Hand;
		B828CE81.Location = new System.Drawing.Point(380, 141);
		B828CE81.Name = "ckbLikePage";
		B828CE81.Size = new System.Drawing.Size(182, 20);
		B828CE81.TabIndex = 8;
		B828CE81.Text = "Like page sau khi tương ta\u0301c";
		B828CE81.UseVisualStyleBackColor = true;
		nudDelayTo.Location = new System.Drawing.Point(236, 166);
		nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 6;
		nudDelayFrom.Location = new System.Drawing.Point(139, 166);
		nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 5;
		B21EDE0C.Location = new System.Drawing.Point(139, 49);
		B21EDE0C.Name = "txtTenHanhDong";
		B21EDE0C.Size = new System.Drawing.Size(153, 23);
		B21EDE0C.TabIndex = 0;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(201, 168);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B019C233.AutoSize = true;
		B019C233.Location = new System.Drawing.Point(27, 168);
		B019C233.Name = "label5";
		B019C233.Size = new System.Drawing.Size(87, 16);
		B019C233.TabIndex = 34;
		B019C233.Text = "Gia\u0303n ca\u0301ch (s):";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		D308D691.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D308D691.BackColor = System.Drawing.Color.Maroon;
		D308D691.Cursor = System.Windows.Forms.Cursors.Hand;
		D308D691.FlatAppearance.BorderSize = 0;
		D308D691.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D308D691.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D308D691.ForeColor = System.Drawing.Color.White;
		D308D691.Location = new System.Drawing.Point(365, 456);
		D308D691.Name = "btnCancel";
		D308D691.Size = new System.Drawing.Size(92, 29);
		D308D691.TabIndex = 12;
		D308D691.Text = "Đóng";
		D308D691.UseVisualStyleBackColor = false;
		D308D691.Click += new System.EventHandler(E5986301);
		F82B971A.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F82B971A.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		F82B971A.Cursor = System.Windows.Forms.Cursors.Hand;
		F82B971A.FlatAppearance.BorderSize = 0;
		F82B971A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F82B971A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F82B971A.ForeColor = System.Drawing.Color.White;
		F82B971A.Location = new System.Drawing.Point(258, 456);
		F82B971A.Name = "btnAdd";
		F82B971A.Size = new System.Drawing.Size(92, 29);
		F82B971A.TabIndex = 11;
		F82B971A.Text = "Thêm";
		F82B971A.UseVisualStyleBackColor = false;
		F82B971A.Click += new System.EventHandler(F82B971A_Click);
		A92644A9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A92644A9.BackColor = System.Drawing.Color.White;
		A92644A9.BorderRadius = 0;
		A92644A9.BottomSahddow = true;
		A92644A9.color = System.Drawing.Color.DarkViolet;
		A92644A9.Controls.Add(pnlHeader);
		A92644A9.LeftSahddow = false;
		A92644A9.Location = new System.Drawing.Point(1, 0);
		A92644A9.Name = "bunifuCards1";
		A92644A9.RightSahddow = true;
		A92644A9.ShadowDepth = 20;
		A92644A9.Size = new System.Drawing.Size(713, 37);
		A92644A9.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(716, 502);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBaiVietFanpage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBaiVietFanpage_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		CF929731.ResumeLayout(false);
		tabOptionsPost.ResumeLayout(false);
		F08E3F81.ResumeLayout(false);
		F08E3F81.PerformLayout();
		((System.ComponentModel.ISupportInitialize)EBA2ED99).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongPageFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongPageTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		A92644A9.ResumeLayout(false);
		ResumeLayout(false);
	}
}
