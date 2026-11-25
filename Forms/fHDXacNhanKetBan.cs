using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDXacNhanKetBan : Form
{
	internal GClass4 BF08F82A;

	internal string C09E03B0;

	internal string string_0;

	internal string EE0008BF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl EEAA7195;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel CF9B818E;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox DF24560C;

	internal Label label3;

	internal Label label1;

	internal Button btnCancel;

	internal Button E9A14614;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button B91F86AF;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label E41639B8;

	internal CheckBox ckbChiKetBanTenCoDau;

	internal CheckBox ckbOnlyAddFriendWithMutualFriends;

	internal NumericUpDown CCAA780E;

	internal Label label9;

	internal Label FA8B3C1C;

	internal CheckBox B0A9F7BB;

	internal ComboBox cbbFacebookWeb;

	internal Label label4;

	internal Label BA05070F;

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

	public fHDXacNhanKetBan(string string_1, string C98BA41C = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		C09E03B0 = string_1;
		EE0008BF = C98BA41C;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (C98BA41C == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			DF24560C.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(C98BA41C);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			E9A14614.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			DF24560C.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		BF08F82A = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void BC29D20A(object sender, EventArgs e)
	{
		D3B60A01();
		try
		{
			nudSoLuongFrom.Value = BF08F82A.method_2("nudSoLuongFrom", 3);
			nudSoLuongTo.Value = BF08F82A.method_2("nudSoLuongTo", 3);
			nudDelayFrom.Value = BF08F82A.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = BF08F82A.method_2("nudDelayTo", 5);
			ckbChiKetBanTenCoDau.Checked = BF08F82A.method_3("ckbChiKetBanTenCoDau");
			ckbOnlyAddFriendWithMutualFriends.Checked = BF08F82A.method_3("ckbOnlyAddFriendWithMutualFriends");
			CCAA780E.Value = BF08F82A.method_2("nudTimesWarning", 5);
			B0A9F7BB.Checked = BF08F82A.method_3("ckbAddFriendApi");
			cbbFacebookWeb.SelectedValue = BF08F82A.BDB80B23("cbbFacebookWeb", "1");
		}
		catch
		{
		}
	}

	private void D3B60A01()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("3", "https://mbasic.facebook.com/");
		dictionary.Add("1", "https://www.facebook.com/");
		dictionary.Add("2", "https://m.facebook.com/");
		Commom.smethod_24(cbbFacebookWeb, dictionary);
	}

	private void B91F86AF_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E9A14614_Click(object sender, EventArgs e)
	{
		string text = DF24560C.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbChiKetBanTenCoDau", ckbChiKetBanTenCoDau.Checked);
		gClass.method_4("ckbOnlyAddFriendWithMutualFriends", ckbOnlyAddFriendWithMutualFriends.Checked);
		gClass.method_4("nudTimesWarning", CCAA780E.Value);
		gClass.method_4("ckbAddFriendApi", B0A9F7BB.Checked);
		gClass.method_4("cbbFacebookWeb", cbbFacebookWeb.SelectedValue);
		string text2 = gClass.ED11179C();
		if (EE0008BF == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(C09E03B0, text, string_0, text2))
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
			if (Class154.smethod_13(EE0008BF, text, text2))
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

	private void E9AC1C0E(object sender, PaintEventArgs e)
	{
		if (CF9B818E.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, CF9B818E.ClientSize.Width - num, CF9B818E.ClientSize.Height - num));
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDXacNhanKetBan));
		EEAA7195 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		B91F86AF = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		CF9B818E = new System.Windows.Forms.Panel();
		cbbFacebookWeb = new System.Windows.Forms.ComboBox();
		E9A14614 = new System.Windows.Forms.Button();
		CCAA780E = new System.Windows.Forms.NumericUpDown();
		label9 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		FA8B3C1C = new System.Windows.Forms.Label();
		ckbOnlyAddFriendWithMutualFriends = new System.Windows.Forms.CheckBox();
		ckbChiKetBanTenCoDau = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		E41639B8 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		DF24560C = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		B0A9F7BB = new System.Windows.Forms.CheckBox();
		BA05070F = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		CF9B818E.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CCAA780E).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		EEAA7195.Fixed = true;
		EEAA7195.Horizontal = true;
		EEAA7195.TargetControl = bunifuCustomLabel1;
		EEAA7195.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Xác nhận kết bạn";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = pnlHeader;
		bunifuDragControl_0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(B91F86AF);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		B91F86AF.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		B91F86AF.Cursor = System.Windows.Forms.Cursors.Hand;
		B91F86AF.FlatAppearance.BorderSize = 0;
		B91F86AF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B91F86AF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B91F86AF.ForeColor = System.Drawing.Color.White;
		B91F86AF.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		B91F86AF.Location = new System.Drawing.Point(328, 1);
		B91F86AF.Name = "button1";
		B91F86AF.Size = new System.Drawing.Size(30, 30);
		B91F86AF.TabIndex = 77;
		B91F86AF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B91F86AF.UseVisualStyleBackColor = true;
		B91F86AF.Click += new System.EventHandler(B91F86AF_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		CF9B818E.BackColor = System.Drawing.Color.White;
		CF9B818E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		CF9B818E.Controls.Add(BA05070F);
		CF9B818E.Controls.Add(label5);
		CF9B818E.Controls.Add(cbbFacebookWeb);
		CF9B818E.Controls.Add(E9A14614);
		CF9B818E.Controls.Add(CCAA780E);
		CF9B818E.Controls.Add(label9);
		CF9B818E.Controls.Add(label4);
		CF9B818E.Controls.Add(FA8B3C1C);
		CF9B818E.Controls.Add(ckbOnlyAddFriendWithMutualFriends);
		CF9B818E.Controls.Add(ckbChiKetBanTenCoDau);
		CF9B818E.Controls.Add(nudDelayTo);
		CF9B818E.Controls.Add(nudDelayFrom);
		CF9B818E.Controls.Add(E41639B8);
		CF9B818E.Controls.Add(nudSoLuongTo);
		CF9B818E.Controls.Add(nudSoLuongFrom);
		CF9B818E.Controls.Add(DF24560C);
		CF9B818E.Controls.Add(label3);
		CF9B818E.Controls.Add(label1);
		CF9B818E.Controls.Add(btnCancel);
		CF9B818E.Controls.Add(bunifuCards1);
		CF9B818E.Controls.Add(B0A9F7BB);
		CF9B818E.Cursor = System.Windows.Forms.Cursors.Arrow;
		CF9B818E.Dock = System.Windows.Forms.DockStyle.Fill;
		CF9B818E.Location = new System.Drawing.Point(0, 0);
		CF9B818E.Name = "panel1";
		CF9B818E.Size = new System.Drawing.Size(362, 261);
		CF9B818E.TabIndex = 0;
		CF9B818E.Paint += new System.Windows.Forms.PaintEventHandler(E9AC1C0E);
		cbbFacebookWeb.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbFacebookWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbFacebookWeb.DropDownWidth = 120;
		cbbFacebookWeb.FormattingEnabled = true;
		cbbFacebookWeb.Location = new System.Drawing.Point(132, 382);
		cbbFacebookWeb.Name = "cbbFacebookWeb";
		cbbFacebookWeb.Size = new System.Drawing.Size(194, 24);
		cbbFacebookWeb.TabIndex = 115;
		E9A14614.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E9A14614.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		E9A14614.Cursor = System.Windows.Forms.Cursors.Hand;
		E9A14614.FlatAppearance.BorderSize = 0;
		E9A14614.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E9A14614.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E9A14614.ForeColor = System.Drawing.Color.White;
		E9A14614.Location = new System.Drawing.Point(82, 217);
		E9A14614.Name = "btnAdd";
		E9A14614.Size = new System.Drawing.Size(92, 29);
		E9A14614.TabIndex = 6;
		E9A14614.Text = "Thêm";
		E9A14614.UseVisualStyleBackColor = false;
		E9A14614.Click += new System.EventHandler(E9A14614_Click);
		CCAA780E.Location = new System.Drawing.Point(253, 183);
		CCAA780E.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CCAA780E.Name = "nudTimesWarning";
		CCAA780E.Size = new System.Drawing.Size(43, 23);
		CCAA780E.TabIndex = 50;
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(299, 185);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(24, 16);
		label9.TabIndex = 52;
		label9.Text = "lần";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 385);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(96, 16);
		label4.TabIndex = 51;
		label4.Text = "Facebook Web:";
		FA8B3C1C.AutoSize = true;
		FA8B3C1C.Location = new System.Drawing.Point(27, 185);
		FA8B3C1C.Name = "label8";
		FA8B3C1C.Size = new System.Drawing.Size(225, 16);
		FA8B3C1C.TabIndex = 51;
		FA8B3C1C.Text = "Dừng khi gặp cảnh báo của Facebook:";
		ckbOnlyAddFriendWithMutualFriends.AutoSize = true;
		ckbOnlyAddFriendWithMutualFriends.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbOnlyAddFriendWithMutualFriends.Location = new System.Drawing.Point(30, 160);
		ckbOnlyAddFriendWithMutualFriends.Name = "ckbOnlyAddFriendWithMutualFriends";
		ckbOnlyAddFriendWithMutualFriends.Size = new System.Drawing.Size(226, 20);
		ckbOnlyAddFriendWithMutualFriends.TabIndex = 49;
		ckbOnlyAddFriendWithMutualFriends.Text = "Chỉ kết bạn với người có bạn chung";
		ckbOnlyAddFriendWithMutualFriends.UseVisualStyleBackColor = true;
		ckbChiKetBanTenCoDau.AutoSize = true;
		ckbChiKetBanTenCoDau.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbChiKetBanTenCoDau.Location = new System.Drawing.Point(30, 136);
		ckbChiKetBanTenCoDau.Name = "ckbChiKetBanTenCoDau";
		ckbChiKetBanTenCoDau.Size = new System.Drawing.Size(211, 20);
		ckbChiKetBanTenCoDau.TabIndex = 48;
		ckbChiKetBanTenCoDau.Text = "Chỉ kết bạn với người có tên Việt";
		ckbChiKetBanTenCoDau.UseVisualStyleBackColor = true;
		nudDelayTo.Location = new System.Drawing.Point(229, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		E41639B8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E41639B8.Location = new System.Drawing.Point(194, 109);
		E41639B8.Name = "label7";
		E41639B8.Size = new System.Drawing.Size(29, 16);
		E41639B8.TabIndex = 46;
		E41639B8.Text = ">";
		E41639B8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongTo.Location = new System.Drawing.Point(229, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		nudSoLuongFrom.Location = new System.Drawing.Point(132, 78);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 1;
		DF24560C.Location = new System.Drawing.Point(132, 49);
		DF24560C.Name = "txtTenHanhDong";
		DF24560C.Size = new System.Drawing.Size(194, 23);
		DF24560C.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		btnCancel.Location = new System.Drawing.Point(189, 217);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(359, 37);
		bunifuCards1.TabIndex = 28;
		B0A9F7BB.AutoSize = true;
		B0A9F7BB.Cursor = System.Windows.Forms.Cursors.Hand;
		B0A9F7BB.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B0A9F7BB.Location = new System.Drawing.Point(30, 407);
		B0A9F7BB.Name = "ckbAddFriendApi";
		B0A9F7BB.Size = new System.Drawing.Size(99, 20);
		B0A9F7BB.TabIndex = 114;
		B0A9F7BB.Text = "Run API (ẩn)";
		B0A9F7BB.UseVisualStyleBackColor = true;
		BA05070F.AutoSize = true;
		BA05070F.Location = new System.Drawing.Point(27, 109);
		BA05070F.Name = "label2";
		BA05070F.Size = new System.Drawing.Size(87, 16);
		BA05070F.TabIndex = 116;
		BA05070F.Text = "Gia\u0303n ca\u0301ch (s):";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 80);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(63, 16);
		label5.TabIndex = 117;
		label5.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 261);
		base.Controls.Add(CF9B818E);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDXacNhanKetBan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(BC29D20A);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		CF9B818E.ResumeLayout(false);
		CF9B818E.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CCAA780E).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
