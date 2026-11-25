using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBaiVietBanBe : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string C704AAB9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool A50B2BB8;

	internal ucTuongTacBaiVietv2 ucTuongTacBaiVietv2_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl FB974C97;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel E1AF2283;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel D701FA38;

	internal Button button1;

	internal PictureBox EF3AD832;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label label49;

	internal NumericUpDown D532F4A3;

	internal Label EC9F8DAF;

	internal NumericUpDown nudSoLuongBanBeTo;

	internal Label F3B13483;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal Label label5;

	internal Panel C6B124AD;

	internal NumericUpDown FD20B609;

	internal NumericUpDown nudSoLuongBaiVietFrom;

	internal Label EC13C8BE;

	internal Panel panel2;

	internal TabControl EC990A3F;

	internal TabPage E817CE3A;

	internal TabPage FB8053B6;

	internal Label E6A4FC90;

	internal Label label9;

	internal NumericUpDown nudThoiGianFrom;

	internal NumericUpDown nudThoiGianTo;

	internal ComboBox A680FE03;

	internal Label C13D900B;

	public static bool AF106D94
	{
		[CompilerGenerated]
		get
		{
			return A50B2BB8;
		}
		[CompilerGenerated]
		set
		{
			A50B2BB8 = value;
		}
	}

	public fHDBaiVietBanBe(string string_2, string string_3 = "")
	{
		InitializeComponent();
		AF106D94 = false;
		string_0 = string_2;
		C704AAB9 = string_3;
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
	}

	private void fHDBaiVietBanBe_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			D532F4A3.Value = gclass4_0.method_2("nudSoLuongBanBeFrom", 1);
			nudSoLuongBanBeTo.Value = gclass4_0.method_2("nudSoLuongBanBeTo", 1);
			A680FE03.SelectedIndex = gclass4_0.method_2("cbbOptionsPost");
			nudSoLuongBaiVietFrom.Value = gclass4_0.method_2("nudSoLuongBaiVietFrom", 1);
			FD20B609.Value = gclass4_0.method_2("nudSoLuongBaiVietTo", 2);
			nudThoiGianFrom.Value = gclass4_0.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = gclass4_0.method_2("nudThoiGianTo", 30);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			ucTuongTacBaiVietv2_0 = new ucTuongTacBaiVietv2(gclass4_0);
			C6B124AD.Controls.Add(ucTuongTacBaiVietv2_0);
		}
		catch
		{
		}
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(A680FE03, list_);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E81A0896(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = ucTuongTacBaiVietv2_0.method_2();
		gClass.method_4("nudSoLuongBanBeFrom", D532F4A3.Value);
		gClass.method_4("nudSoLuongBanBeTo", nudSoLuongBanBeTo.Value);
		gClass.method_4("cbbOptionsPost", A680FE03.SelectedIndex);
		gClass.method_4("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
		gClass.method_4("nudSoLuongBaiVietTo", FD20B609.Value);
		gClass.method_4("nudThoiGianFrom", nudThoiGianFrom.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		string e013A = gClass.ED11179C();
		if (C704AAB9 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					AF106D94 = true;
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
			if (Class154.smethod_13(C704AAB9, text, e013A))
			{
				AF106D94 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void F01FA5AC(object sender, EventArgs e)
	{
		Close();
	}

	private void E1AF2283_Paint(object sender, PaintEventArgs e)
	{
		if (E1AF2283.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, E1AF2283.ClientSize.Width - num, E1AF2283.ClientSize.Height - num));
		}
	}

	private void C0824BAA(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
		{
		}
	}

	private void A680FE03_SelectedIndexChanged(object sender, EventArgs e)
	{
		EC990A3F.SelectedIndex = A680FE03.SelectedIndex;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBaiVietBanBe));
		FB974C97 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D701FA38 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		EF3AD832 = new System.Windows.Forms.PictureBox();
		E1AF2283 = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		EC990A3F = new System.Windows.Forms.TabControl();
		E817CE3A = new System.Windows.Forms.TabPage();
		EC9F8DAF = new System.Windows.Forms.Label();
		EC13C8BE = new System.Windows.Forms.Label();
		nudSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
		FD20B609 = new System.Windows.Forms.NumericUpDown();
		FB8053B6 = new System.Windows.Forms.TabPage();
		E6A4FC90 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		nudThoiGianFrom = new System.Windows.Forms.NumericUpDown();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		A680FE03 = new System.Windows.Forms.ComboBox();
		C13D900B = new System.Windows.Forms.Label();
		C6B124AD = new System.Windows.Forms.Panel();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label49 = new System.Windows.Forms.Label();
		D532F4A3 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongBanBeTo = new System.Windows.Forms.NumericUpDown();
		F3B13483 = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		D701FA38.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)EF3AD832).BeginInit();
		E1AF2283.SuspendLayout();
		panel2.SuspendLayout();
		EC990A3F.SuspendLayout();
		E817CE3A.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)FD20B609).BeginInit();
		FB8053B6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)D532F4A3).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeTo).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		FB974C97.Fixed = true;
		FB974C97.Horizontal = true;
		FB974C97.TargetControl = bunifuCustomLabel1;
		FB974C97.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(716, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Bài viết Bạn bè";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = D701FA38;
		bunifuDragControl_0.Vertical = true;
		D701FA38.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D701FA38.BackColor = System.Drawing.Color.White;
		D701FA38.Controls.Add(button1);
		D701FA38.Controls.Add(EF3AD832);
		D701FA38.Controls.Add(bunifuCustomLabel1);
		D701FA38.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D701FA38.Location = new System.Drawing.Point(0, 3);
		D701FA38.Name = "pnlHeader";
		D701FA38.Size = new System.Drawing.Size(716, 31);
		D701FA38.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(685, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		EF3AD832.Cursor = System.Windows.Forms.Cursors.Default;
		EF3AD832.Image = Class155.DD225F0D;
		EF3AD832.Location = new System.Drawing.Point(3, 2);
		EF3AD832.Name = "pictureBox1";
		EF3AD832.Size = new System.Drawing.Size(34, 27);
		EF3AD832.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		EF3AD832.TabIndex = 76;
		EF3AD832.TabStop = false;
		EF3AD832.Click += new System.EventHandler(C0824BAA);
		E1AF2283.BackColor = System.Drawing.Color.White;
		E1AF2283.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E1AF2283.Controls.Add(panel2);
		E1AF2283.Controls.Add(A680FE03);
		E1AF2283.Controls.Add(C13D900B);
		E1AF2283.Controls.Add(C6B124AD);
		E1AF2283.Controls.Add(nudDelayTo);
		E1AF2283.Controls.Add(nudDelayFrom);
		E1AF2283.Controls.Add(label7);
		E1AF2283.Controls.Add(label5);
		E1AF2283.Controls.Add(label49);
		E1AF2283.Controls.Add(D532F4A3);
		E1AF2283.Controls.Add(nudSoLuongBanBeTo);
		E1AF2283.Controls.Add(F3B13483);
		E1AF2283.Controls.Add(txtTenHanhDong);
		E1AF2283.Controls.Add(label1);
		E1AF2283.Controls.Add(btnCancel);
		E1AF2283.Controls.Add(btnAdd);
		E1AF2283.Controls.Add(bunifuCards1);
		E1AF2283.Cursor = System.Windows.Forms.Cursors.Arrow;
		E1AF2283.Dock = System.Windows.Forms.DockStyle.Fill;
		E1AF2283.Location = new System.Drawing.Point(0, 0);
		E1AF2283.Name = "panel1";
		E1AF2283.Size = new System.Drawing.Size(719, 495);
		E1AF2283.TabIndex = 0;
		E1AF2283.Paint += new System.Windows.Forms.PaintEventHandler(E1AF2283_Paint);
		panel2.Controls.Add(EC990A3F);
		panel2.Location = new System.Drawing.Point(28, 137);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(266, 23);
		panel2.TabIndex = 202;
		EC990A3F.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		EC990A3F.Controls.Add(E817CE3A);
		EC990A3F.Controls.Add(FB8053B6);
		EC990A3F.Location = new System.Drawing.Point(-5, -5);
		EC990A3F.Name = "tabOptionsPost";
		EC990A3F.SelectedIndex = 0;
		EC990A3F.Size = new System.Drawing.Size(276, 54);
		EC990A3F.TabIndex = 198;
		E817CE3A.Controls.Add(EC9F8DAF);
		E817CE3A.Controls.Add(EC13C8BE);
		E817CE3A.Controls.Add(nudSoLuongBaiVietFrom);
		E817CE3A.Controls.Add(FD20B609);
		E817CE3A.Location = new System.Drawing.Point(4, 4);
		E817CE3A.Name = "tabPage1";
		E817CE3A.Padding = new System.Windows.Forms.Padding(3);
		E817CE3A.Size = new System.Drawing.Size(268, 25);
		E817CE3A.TabIndex = 0;
		E817CE3A.Text = "tabPage1";
		E817CE3A.UseVisualStyleBackColor = true;
		EC9F8DAF.AutoSize = true;
		EC9F8DAF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		EC9F8DAF.Location = new System.Drawing.Point(0, 3);
		EC9F8DAF.Name = "label19";
		EC9F8DAF.Size = new System.Drawing.Size(98, 16);
		EC9F8DAF.TabIndex = 101;
		EC9F8DAF.Text = "Sô\u0301 ba\u0300i viê\u0301t/ba\u0323n:";
		EC13C8BE.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EC13C8BE.Location = new System.Drawing.Point(174, 3);
		EC13C8BE.Name = "label3";
		EC13C8BE.Size = new System.Drawing.Size(29, 16);
		EC13C8BE.TabIndex = 37;
		EC13C8BE.Text = ">";
		EC13C8BE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongBaiVietFrom.Location = new System.Drawing.Point(112, 1);
		nudSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongBaiVietFrom.Name = "nudSoLuongBaiVietFrom";
		nudSoLuongBaiVietFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongBaiVietFrom.TabIndex = 3;
		FD20B609.Location = new System.Drawing.Point(209, 1);
		FD20B609.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		FD20B609.Name = "nudSoLuongBaiVietTo";
		FD20B609.Size = new System.Drawing.Size(56, 23);
		FD20B609.TabIndex = 4;
		FB8053B6.Controls.Add(E6A4FC90);
		FB8053B6.Controls.Add(label9);
		FB8053B6.Controls.Add(nudThoiGianFrom);
		FB8053B6.Controls.Add(nudThoiGianTo);
		FB8053B6.Location = new System.Drawing.Point(4, 4);
		FB8053B6.Name = "tabPage2";
		FB8053B6.Padding = new System.Windows.Forms.Padding(3);
		FB8053B6.Size = new System.Drawing.Size(268, 28);
		FB8053B6.TabIndex = 1;
		FB8053B6.Text = "tabPage2";
		FB8053B6.UseVisualStyleBackColor = true;
		E6A4FC90.AutoSize = true;
		E6A4FC90.Location = new System.Drawing.Point(0, 3);
		E6A4FC90.Name = "label8";
		E6A4FC90.Size = new System.Drawing.Size(111, 16);
		E6A4FC90.TabIndex = 40;
		E6A4FC90.Text = "Thơ\u0300i gian/ba\u0323n (s):";
		label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(174, 3);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(29, 16);
		label9.TabIndex = 41;
		label9.Text = ">";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		A680FE03.Cursor = System.Windows.Forms.Cursors.Hand;
		A680FE03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A680FE03.DropDownWidth = 200;
		A680FE03.FormattingEnabled = true;
		A680FE03.Location = new System.Drawing.Point(139, 107);
		A680FE03.Name = "cbbOptionsPost";
		A680FE03.Size = new System.Drawing.Size(153, 24);
		A680FE03.TabIndex = 200;
		A680FE03.SelectedIndexChanged += new System.EventHandler(A680FE03_SelectedIndexChanged);
		C13D900B.AutoSize = true;
		C13D900B.Location = new System.Drawing.Point(27, 110);
		C13D900B.Name = "label6";
		C13D900B.Size = new System.Drawing.Size(64, 16);
		C13D900B.TabIndex = 201;
		C13D900B.Text = "Tu\u0300y cho\u0323n:";
		C6B124AD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C6B124AD.Location = new System.Drawing.Point(30, 167);
		C6B124AD.Name = "plTuongTacBaiViet";
		C6B124AD.Size = new System.Drawing.Size(657, 266);
		C6B124AD.TabIndex = 198;
		nudDelayTo.Location = new System.Drawing.Point(236, 167);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 195;
		nudDelayFrom.Location = new System.Drawing.Point(139, 167);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 194;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(201, 169);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 197;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 169);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 196;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		label49.AutoSize = true;
		label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label49.Location = new System.Drawing.Point(27, 80);
		label49.Name = "label49";
		label49.Size = new System.Drawing.Size(88, 16);
		label49.TabIndex = 92;
		label49.Text = "Sô\u0301 lươ\u0323ng ba\u0323n:";
		D532F4A3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		D532F4A3.Location = new System.Drawing.Point(139, 78);
		D532F4A3.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		D532F4A3.Name = "nudSoLuongBanBeFrom";
		D532F4A3.Size = new System.Drawing.Size(56, 23);
		D532F4A3.TabIndex = 1;
		D532F4A3.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		nudSoLuongBanBeTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongBanBeTo.Location = new System.Drawing.Point(236, 78);
		nudSoLuongBanBeTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongBanBeTo.Name = "nudSoLuongBanBeTo";
		nudSoLuongBanBeTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongBanBeTo.TabIndex = 2;
		nudSoLuongBanBeTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		F3B13483.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		F3B13483.Location = new System.Drawing.Point(201, 80);
		F3B13483.Name = "label66";
		F3B13483.Size = new System.Drawing.Size(29, 16);
		F3B13483.TabIndex = 105;
		F3B13483.Text = ">";
		F3B13483.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(367, 450);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 12;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F01FA5AC);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(260, 450);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 11;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(E81A0896);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(D701FA38);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(716, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(719, 495);
		base.Controls.Add(E1AF2283);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBaiVietBanBe";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBaiVietBanBe_Load);
		D701FA38.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)EF3AD832).EndInit();
		E1AF2283.ResumeLayout(false);
		E1AF2283.PerformLayout();
		panel2.ResumeLayout(false);
		EC990A3F.ResumeLayout(false);
		E817CE3A.ResumeLayout(false);
		E817CE3A.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)FD20B609).EndInit();
		FB8053B6.ResumeLayout(false);
		FB8053B6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)D532F4A3).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeTo).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
