using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBaiVietNhom : Form
{
	internal GClass4 CDAD4E3B;

	internal string EE3B2688;

	internal string string_0;

	internal string BD93E0B4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal ucTuongTacBaiVietv2 ucTuongTacBaiVietv2_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel D4B2D12E;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button A80862B7;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button A61CF713;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label label49;

	internal NumericUpDown F5242414;

	internal NumericUpDown nudSoLuongNhomTo;

	internal Label BB988A9C;

	internal CheckBox ckbNangCao;

	internal CheckBox A798A385;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal Label B3023830;

	internal Panel D13F481A;

	internal Panel panel2;

	internal TabControl tabOptionsPost;

	internal TabPage tabPage1;

	internal Label label19;

	internal Label E70BD584;

	internal NumericUpDown nudSoLuongBaiVietFrom;

	internal NumericUpDown nudSoLuongBaiVietTo;

	internal TabPage tabPage2;

	internal Label label8;

	internal Label ECA2E12A;

	internal NumericUpDown nudThoiGianFrom;

	internal NumericUpDown nudThoiGianTo;

	internal ComboBox FF1F0DBB;

	internal Label F48DE01B;

	public static bool BAAC4606
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

	public fHDBaiVietNhom(string string_1, string string_2 = "")
	{
		InitializeComponent();
		BAAC4606 = false;
		EE3B2688 = string_1;
		BD93E0B4 = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_3 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			string_3 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		CDAD4E3B = new GClass4(string_3, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDBaiVietNhom_Load(object sender, EventArgs e)
	{
		D236E52C();
		try
		{
			F5242414.Value = CDAD4E3B.method_2("nudSoLuongNhomFrom", 1);
			nudSoLuongNhomTo.Value = CDAD4E3B.method_2("nudSoLuongNhomTo", 1);
			FF1F0DBB.SelectedIndex = CDAD4E3B.method_2("cbbOptionsPost");
			nudSoLuongBaiVietFrom.Value = CDAD4E3B.method_2("nudSoLuongBaiVietFrom", 1);
			nudSoLuongBaiVietTo.Value = CDAD4E3B.method_2("nudSoLuongBaiVietTo", 2);
			nudThoiGianFrom.Value = CDAD4E3B.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = CDAD4E3B.method_2("nudThoiGianTo", 30);
			nudDelayFrom.Value = CDAD4E3B.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = CDAD4E3B.method_2("nudDelayTo", 5);
			ucTuongTacBaiVietv2_0 = new ucTuongTacBaiVietv2(CDAD4E3B);
			D13F481A.Controls.Add(ucTuongTacBaiVietv2_0);
			A798A385.Checked = CDAD4E3B.method_3("ckbKhongCommentTrungBaiCu");
			ckbNangCao.Checked = CDAD4E3B.method_3("ckbNangCao");
		}
		catch
		{
		}
	}

	private void D236E52C()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(FF1F0DBB, list_);
	}

	private void D608ABA0(object sender, EventArgs e)
	{
		Close();
	}

	private void D287688F(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = ucTuongTacBaiVietv2_0.method_2();
		gClass.method_4("nudSoLuongNhomFrom", F5242414.Value);
		gClass.method_4("nudSoLuongNhomTo", nudSoLuongNhomTo.Value);
		gClass.method_4("cbbOptionsPost", FF1F0DBB.SelectedIndex);
		gClass.method_4("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
		gClass.method_4("nudSoLuongBaiVietTo", nudSoLuongBaiVietTo.Value);
		gClass.method_4("nudThoiGianFrom", nudThoiGianFrom.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		string text2 = gClass.ED11179C();
		if (BD93E0B4 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(EE3B2688, text, string_0, text2))
				{
					BAAC4606 = true;
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
			if (Class154.smethod_13(BD93E0B4, text, text2))
			{
				BAAC4606 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void A80862B7_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D4B2D12E_Paint(object sender, PaintEventArgs e)
	{
		if (D4B2D12E.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, D4B2D12E.ClientSize.Width - num, D4B2D12E.ClientSize.Height - num));
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
		{
		}
	}

	private void FF1F0DBB_SelectedIndexChanged(object sender, EventArgs e)
	{
		tabOptionsPost.SelectedIndex = FF1F0DBB.SelectedIndex;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBaiVietNhom));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		A61CF713 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		D4B2D12E = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		tabOptionsPost = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		label19 = new System.Windows.Forms.Label();
		E70BD584 = new System.Windows.Forms.Label();
		nudSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		nudThoiGianFrom = new System.Windows.Forms.NumericUpDown();
		label8 = new System.Windows.Forms.Label();
		ECA2E12A = new System.Windows.Forms.Label();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		FF1F0DBB = new System.Windows.Forms.ComboBox();
		F48DE01B = new System.Windows.Forms.Label();
		D13F481A = new System.Windows.Forms.Panel();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		B3023830 = new System.Windows.Forms.Label();
		A798A385 = new System.Windows.Forms.CheckBox();
		ckbNangCao = new System.Windows.Forms.CheckBox();
		label49 = new System.Windows.Forms.Label();
		F5242414 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongNhomTo = new System.Windows.Forms.NumericUpDown();
		BB988A9C = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		A80862B7 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		D4B2D12E.SuspendLayout();
		panel2.SuspendLayout();
		tabOptionsPost.SuspendLayout();
		tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)F5242414).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongNhomTo).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(716, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Bài viết Nhóm";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(A61CF713);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(716, 31);
		pnlHeader.TabIndex = 9;
		A61CF713.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A61CF713.Cursor = System.Windows.Forms.Cursors.Hand;
		A61CF713.FlatAppearance.BorderSize = 0;
		A61CF713.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A61CF713.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A61CF713.ForeColor = System.Drawing.Color.White;
		A61CF713.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		A61CF713.Location = new System.Drawing.Point(685, 1);
		A61CF713.Name = "button1";
		A61CF713.Size = new System.Drawing.Size(30, 30);
		A61CF713.TabIndex = 77;
		A61CF713.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A61CF713.UseVisualStyleBackColor = true;
		A61CF713.Click += new System.EventHandler(D608ABA0);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		D4B2D12E.BackColor = System.Drawing.Color.White;
		D4B2D12E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D4B2D12E.Controls.Add(panel2);
		D4B2D12E.Controls.Add(FF1F0DBB);
		D4B2D12E.Controls.Add(F48DE01B);
		D4B2D12E.Controls.Add(D13F481A);
		D4B2D12E.Controls.Add(nudDelayTo);
		D4B2D12E.Controls.Add(nudDelayFrom);
		D4B2D12E.Controls.Add(label7);
		D4B2D12E.Controls.Add(B3023830);
		D4B2D12E.Controls.Add(A798A385);
		D4B2D12E.Controls.Add(ckbNangCao);
		D4B2D12E.Controls.Add(label49);
		D4B2D12E.Controls.Add(F5242414);
		D4B2D12E.Controls.Add(nudSoLuongNhomTo);
		D4B2D12E.Controls.Add(BB988A9C);
		D4B2D12E.Controls.Add(txtTenHanhDong);
		D4B2D12E.Controls.Add(label1);
		D4B2D12E.Controls.Add(A80862B7);
		D4B2D12E.Controls.Add(btnAdd);
		D4B2D12E.Controls.Add(bunifuCards1);
		D4B2D12E.Cursor = System.Windows.Forms.Cursors.Arrow;
		D4B2D12E.Dock = System.Windows.Forms.DockStyle.Fill;
		D4B2D12E.Location = new System.Drawing.Point(0, 0);
		D4B2D12E.Name = "panel1";
		D4B2D12E.Size = new System.Drawing.Size(719, 491);
		D4B2D12E.TabIndex = 0;
		D4B2D12E.Paint += new System.Windows.Forms.PaintEventHandler(D4B2D12E_Paint);
		panel2.Controls.Add(tabOptionsPost);
		panel2.Location = new System.Drawing.Point(28, 137);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(266, 23);
		panel2.TabIndex = 206;
		tabOptionsPost.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabOptionsPost.Controls.Add(tabPage1);
		tabOptionsPost.Controls.Add(tabPage2);
		tabOptionsPost.Location = new System.Drawing.Point(-5, -5);
		tabOptionsPost.Name = "tabOptionsPost";
		tabOptionsPost.SelectedIndex = 0;
		tabOptionsPost.Size = new System.Drawing.Size(276, 54);
		tabOptionsPost.TabIndex = 198;
		tabPage1.Controls.Add(label19);
		tabPage1.Controls.Add(E70BD584);
		tabPage1.Controls.Add(nudSoLuongBaiVietFrom);
		tabPage1.Controls.Add(nudSoLuongBaiVietTo);
		tabPage1.Location = new System.Drawing.Point(4, 4);
		tabPage1.Name = "tabPage1";
		tabPage1.Padding = new System.Windows.Forms.Padding(3);
		tabPage1.Size = new System.Drawing.Size(268, 25);
		tabPage1.TabIndex = 0;
		tabPage1.Text = "tabPage1";
		tabPage1.UseVisualStyleBackColor = true;
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label19.Location = new System.Drawing.Point(0, 3);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(109, 16);
		label19.TabIndex = 101;
		label19.Text = "Sô\u0301 ba\u0300i viê\u0301t/nho\u0301m:";
		E70BD584.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E70BD584.Location = new System.Drawing.Point(174, 3);
		E70BD584.Name = "label3";
		E70BD584.Size = new System.Drawing.Size(29, 16);
		E70BD584.TabIndex = 37;
		E70BD584.Text = ">";
		E70BD584.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongBaiVietFrom.Location = new System.Drawing.Point(112, 1);
		nudSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongBaiVietFrom.Name = "nudSoLuongBaiVietFrom";
		nudSoLuongBaiVietFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongBaiVietFrom.TabIndex = 3;
		nudSoLuongBaiVietTo.Location = new System.Drawing.Point(209, 1);
		nudSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongBaiVietTo.Name = "nudSoLuongBaiVietTo";
		nudSoLuongBaiVietTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongBaiVietTo.TabIndex = 4;
		tabPage2.Controls.Add(nudThoiGianFrom);
		tabPage2.Controls.Add(label8);
		tabPage2.Controls.Add(ECA2E12A);
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
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(0, 3);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(122, 16);
		label8.TabIndex = 40;
		label8.Text = "Thơ\u0300i gian/nho\u0301m (s):";
		ECA2E12A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		ECA2E12A.Location = new System.Drawing.Point(174, 3);
		ECA2E12A.Name = "label9";
		ECA2E12A.Size = new System.Drawing.Size(29, 16);
		ECA2E12A.TabIndex = 41;
		ECA2E12A.Text = ">";
		ECA2E12A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudThoiGianTo.Location = new System.Drawing.Point(209, 1);
		nudThoiGianTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianTo.Name = "nudThoiGianTo";
		nudThoiGianTo.Size = new System.Drawing.Size(56, 23);
		nudThoiGianTo.TabIndex = 39;
		FF1F0DBB.Cursor = System.Windows.Forms.Cursors.Hand;
		FF1F0DBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		FF1F0DBB.DropDownWidth = 200;
		FF1F0DBB.FormattingEnabled = true;
		FF1F0DBB.Location = new System.Drawing.Point(139, 107);
		FF1F0DBB.Name = "cbbOptionsPost";
		FF1F0DBB.Size = new System.Drawing.Size(153, 24);
		FF1F0DBB.TabIndex = 204;
		FF1F0DBB.SelectedIndexChanged += new System.EventHandler(FF1F0DBB_SelectedIndexChanged);
		F48DE01B.AutoSize = true;
		F48DE01B.Location = new System.Drawing.Point(27, 110);
		F48DE01B.Name = "label6";
		F48DE01B.Size = new System.Drawing.Size(64, 16);
		F48DE01B.TabIndex = 205;
		F48DE01B.Text = "Tu\u0300y cho\u0323n:";
		D13F481A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D13F481A.Location = new System.Drawing.Point(30, 166);
		D13F481A.Name = "plTuongTacBaiViet";
		D13F481A.Size = new System.Drawing.Size(657, 266);
		D13F481A.TabIndex = 203;
		nudDelayTo.Location = new System.Drawing.Point(236, 166);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 200;
		nudDelayFrom.Location = new System.Drawing.Point(139, 166);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 199;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(201, 168);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 202;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B3023830.AutoSize = true;
		B3023830.Location = new System.Drawing.Point(27, 168);
		B3023830.Name = "label5";
		B3023830.Size = new System.Drawing.Size(87, 16);
		B3023830.TabIndex = 201;
		B3023830.Text = "Gia\u0303n ca\u0301ch (s):";
		A798A385.AutoSize = true;
		A798A385.Cursor = System.Windows.Forms.Cursors.Hand;
		A798A385.Location = new System.Drawing.Point(30, 532);
		A798A385.Name = "ckbKhongCommentTrungBaiCu";
		A798A385.Size = new System.Drawing.Size(152, 20);
		A798A385.TabIndex = 169;
		A798A385.Text = "Không comment trùng";
		A798A385.UseVisualStyleBackColor = true;
		ckbNangCao.AutoSize = true;
		ckbNangCao.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbNangCao.Location = new System.Drawing.Point(30, 558);
		ckbNangCao.Name = "ckbNangCao";
		ckbNangCao.Size = new System.Drawing.Size(129, 20);
		ckbNangCao.TabIndex = 168;
		ckbNangCao.Text = "Random nâng cao";
		ckbNangCao.UseVisualStyleBackColor = true;
		label49.AutoSize = true;
		label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label49.Location = new System.Drawing.Point(27, 80);
		label49.Name = "label49";
		label49.Size = new System.Drawing.Size(99, 16);
		label49.TabIndex = 92;
		label49.Text = "Sô\u0301 lươ\u0323ng nhóm:";
		F5242414.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F5242414.Location = new System.Drawing.Point(139, 78);
		F5242414.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		F5242414.Name = "nudSoLuongNhomFrom";
		F5242414.Size = new System.Drawing.Size(56, 23);
		F5242414.TabIndex = 1;
		F5242414.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		nudSoLuongNhomTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongNhomTo.Location = new System.Drawing.Point(236, 78);
		nudSoLuongNhomTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongNhomTo.Name = "nudSoLuongNhomTo";
		nudSoLuongNhomTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongNhomTo.TabIndex = 2;
		nudSoLuongNhomTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		BB988A9C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		BB988A9C.Location = new System.Drawing.Point(201, 80);
		BB988A9C.Name = "label66";
		BB988A9C.Size = new System.Drawing.Size(29, 16);
		BB988A9C.TabIndex = 105;
		BB988A9C.Text = ">";
		BB988A9C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		txtTenHanhDong.Location = new System.Drawing.Point(139, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		A80862B7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A80862B7.BackColor = System.Drawing.Color.Maroon;
		A80862B7.Cursor = System.Windows.Forms.Cursors.Hand;
		A80862B7.FlatAppearance.BorderSize = 0;
		A80862B7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A80862B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A80862B7.ForeColor = System.Drawing.Color.White;
		A80862B7.Location = new System.Drawing.Point(366, 448);
		A80862B7.Name = "btnCancel";
		A80862B7.Size = new System.Drawing.Size(92, 29);
		A80862B7.TabIndex = 12;
		A80862B7.Text = "Đóng";
		A80862B7.UseVisualStyleBackColor = false;
		A80862B7.Click += new System.EventHandler(A80862B7_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(259, 448);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 11;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(D287688F);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(716, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(719, 491);
		base.Controls.Add(D4B2D12E);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBaiVietNhom";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBaiVietNhom_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		D4B2D12E.ResumeLayout(false);
		D4B2D12E.PerformLayout();
		panel2.ResumeLayout(false);
		tabOptionsPost.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)F5242414).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongNhomTo).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
