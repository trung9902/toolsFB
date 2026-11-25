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

public class fHDKetBanTepUid : Form
{
	internal GClass4 A92BCE11;

	internal string string_0;

	internal string A3187F13;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer CA1F7E9C = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl F0A87594;

	internal Panel panel1;

	internal NumericUpDown FCAC7EA1;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox txtTenHanhDong;

	internal Label label3;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards C7A5A19E;

	internal Panel pnlHeader;

	internal Button F2021E34;

	internal PictureBox ED37BA2E;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown D885800A;

	internal Label label7;

	internal CheckBox ckbTuongTac;

	internal NumericUpDown nudTimesWarning;

	internal Label F59D8321;

	internal Label label8;

	internal CheckBox ckbAddFriendApi;

	internal LinkLabel lblCaiDat;

	internal Panel ED2EB086;

	internal Label lblUid;

	internal CheckBox EB12531E;

	internal RichTextBox txtUid;

	internal Label label2;

	internal Label label4;

	public static bool D0907C2B
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

	public fHDKetBanTepUid(string string_2, string string_3 = "")
	{
		InitializeComponent();
		D0907C2B = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			A3187F13 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		A92BCE11 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void DF39E11F(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = A92BCE11.method_2("nudSoLuongFrom", 1);
			FCAC7EA1.Value = A92BCE11.method_2("nudSoLuongTo", 1);
			D885800A.Value = A92BCE11.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = A92BCE11.method_2("nudDelayTo", 5);
			EB12531E.Checked = A92BCE11.method_3("ckbKetBanTrungNhau");
			txtUid.Text = A92BCE11.BDB80B23("txtUid");
			ckbTuongTac.Checked = A92BCE11.method_3("ckbTuongTac");
			EB12531E.Checked = A92BCE11.method_3("ckbTuDongXoaUid");
			ckbAddFriendApi.Checked = A92BCE11.method_3("ckbAddFriendApi");
			nudTimesWarning.Value = A92BCE11.method_2("nudTimesWarning", 1);
		}
		catch
		{
		}
		method_0();
	}

	private void method_0()
	{
		ckbTuongTac_CheckedChanged(null, null);
		B8238438(null, null);
	}

	private void BD3C9E84(object sender, EventArgs e)
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
		List<string> list_ = txtUid.Lines.ToList();
		list_ = Commom.smethod_36(list_);
		if (list_.Count == 0)
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách uid cần kết bạn!", 3);
			return;
		}
		A92BCE11.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		A92BCE11.method_4("nudSoLuongTo", FCAC7EA1.Value);
		A92BCE11.method_4("nudDelayFrom", D885800A.Value);
		A92BCE11.method_4("nudDelayTo", nudDelayTo.Value);
		A92BCE11.method_4("ckbKetBanTrungNhau", EB12531E.Checked);
		A92BCE11.method_4("txtUid", txtUid.Text.Trim());
		A92BCE11.method_4("ckbTuongTac", ckbTuongTac.Checked);
		A92BCE11.method_4("ckbTuDongXoaUid", EB12531E.Checked);
		A92BCE11.method_4("ckbAddFriendApi", ckbAddFriendApi.Checked);
		A92BCE11.method_4("nudTimesWarning", nudTimesWarning.Value);
		string e013A = A92BCE11.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, A3187F13, e013A))
				{
					D0907C2B = true;
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
				D0907C2B = true;
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

	private void panel1_Paint(object sender, PaintEventArgs e)
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

	private void txtUid_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtUid, lblUid);
	}

	private void ckbTuongTac_CheckedChanged(object sender, EventArgs e)
	{
		lblCaiDat.Enabled = ckbTuongTac.Checked;
	}

	private void B8238438(object sender, EventArgs e)
	{
	}

	private void lblCaiDat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fTuongTacProfile(A92BCE11));
	}

	protected override void Dispose(bool FF154608)
	{
		if (FF154608 && CA1F7E9C != null)
		{
			CA1F7E9C.Dispose();
		}
		base.Dispose(FF154608);
	}

	private void InitializeComponent()
	{
		CA1F7E9C = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKetBanTepUid));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(CA1F7E9C);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		F0A87594 = new Bunifu.Framework.UI.BunifuDragControl(CA1F7E9C);
		pnlHeader = new System.Windows.Forms.Panel();
		F2021E34 = new System.Windows.Forms.Button();
		ED37BA2E = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		ED2EB086 = new System.Windows.Forms.Panel();
		lblUid = new System.Windows.Forms.Label();
		EB12531E = new System.Windows.Forms.CheckBox();
		txtUid = new System.Windows.Forms.RichTextBox();
		label4 = new System.Windows.Forms.Label();
		lblCaiDat = new System.Windows.Forms.LinkLabel();
		nudTimesWarning = new System.Windows.Forms.NumericUpDown();
		F59D8321 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		ckbTuongTac = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		D885800A = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		FCAC7EA1 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		C7A5A19E = new Bunifu.Framework.UI.BunifuCards();
		ckbAddFriendApi = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)ED37BA2E).BeginInit();
		panel1.SuspendLayout();
		ED2EB086.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTimesWarning).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)D885800A).BeginInit();
		((System.ComponentModel.ISupportInitialize)FCAC7EA1).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		C7A5A19E.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(597, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Kết bạn theo tệp UID";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F0A87594.Fixed = true;
		F0A87594.Horizontal = true;
		F0A87594.TargetControl = pnlHeader;
		F0A87594.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(F2021E34);
		pnlHeader.Controls.Add(ED37BA2E);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(597, 31);
		pnlHeader.TabIndex = 9;
		F2021E34.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F2021E34.Cursor = System.Windows.Forms.Cursors.Hand;
		F2021E34.FlatAppearance.BorderSize = 0;
		F2021E34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F2021E34.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F2021E34.ForeColor = System.Drawing.Color.White;
		F2021E34.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		F2021E34.Location = new System.Drawing.Point(566, 1);
		F2021E34.Name = "button1";
		F2021E34.Size = new System.Drawing.Size(30, 30);
		F2021E34.TabIndex = 77;
		F2021E34.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		F2021E34.UseVisualStyleBackColor = true;
		F2021E34.Click += new System.EventHandler(BD3C9E84);
		ED37BA2E.Cursor = System.Windows.Forms.Cursors.Default;
		ED37BA2E.Image = Class155.DD225F0D;
		ED37BA2E.Location = new System.Drawing.Point(3, 2);
		ED37BA2E.Name = "pictureBox1";
		ED37BA2E.Size = new System.Drawing.Size(34, 27);
		ED37BA2E.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		ED37BA2E.TabIndex = 76;
		ED37BA2E.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(label2);
		panel1.Controls.Add(ED2EB086);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(lblCaiDat);
		panel1.Controls.Add(nudTimesWarning);
		panel1.Controls.Add(F59D8321);
		panel1.Controls.Add(label8);
		panel1.Controls.Add(ckbTuongTac);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(D885800A);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(FCAC7EA1);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(C7A5A19E);
		panel1.Controls.Add(ckbAddFriendApi);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(600, 301);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(25, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 115;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		ED2EB086.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		ED2EB086.Controls.Add(lblUid);
		ED2EB086.Controls.Add(EB12531E);
		ED2EB086.Controls.Add(txtUid);
		ED2EB086.Location = new System.Drawing.Point(315, 49);
		ED2EB086.Name = "plUid";
		ED2EB086.Size = new System.Drawing.Size(255, 194);
		ED2EB086.TabIndex = 195;
		lblUid.AutoSize = true;
		lblUid.Location = new System.Drawing.Point(1, 4);
		lblUid.Name = "lblUid";
		lblUid.Size = new System.Drawing.Size(114, 16);
		lblUid.TabIndex = 0;
		lblUid.Text = "Danh sa\u0301ch Uid (0):";
		EB12531E.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		EB12531E.AutoSize = true;
		EB12531E.Cursor = System.Windows.Forms.Cursors.Hand;
		EB12531E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		EB12531E.Location = new System.Drawing.Point(5, 169);
		EB12531E.Name = "ckbTuDongXoaUid";
		EB12531E.Size = new System.Drawing.Size(170, 20);
		EB12531E.TabIndex = 113;
		EB12531E.Text = "Tư\u0323 đô\u0323ng xo\u0301a Uid đa\u0303 dùng";
		EB12531E.UseVisualStyleBackColor = true;
		txtUid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtUid.Location = new System.Drawing.Point(5, 23);
		txtUid.Name = "txtUid";
		txtUid.Size = new System.Drawing.Size(243, 144);
		txtUid.TabIndex = 114;
		txtUid.Text = "";
		txtUid.WordWrap = false;
		txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(25, 80);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(63, 16);
		label4.TabIndex = 116;
		label4.Text = "Sô\u0301 lươ\u0323ng:";
		lblCaiDat.AutoSize = true;
		lblCaiDat.Cursor = System.Windows.Forms.Cursors.Hand;
		lblCaiDat.Location = new System.Drawing.Point(211, 137);
		lblCaiDat.Name = "lblCaiDat";
		lblCaiDat.Size = new System.Drawing.Size(47, 16);
		lblCaiDat.TabIndex = 194;
		lblCaiDat.TabStop = true;
		lblCaiDat.Text = "Cài đặt";
		lblCaiDat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lblCaiDat_LinkClicked);
		nudTimesWarning.Location = new System.Drawing.Point(167, 157);
		nudTimesWarning.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimesWarning.Name = "nudTimesWarning";
		nudTimesWarning.Size = new System.Drawing.Size(43, 23);
		nudTimesWarning.TabIndex = 117;
		F59D8321.AutoSize = true;
		F59D8321.Location = new System.Drawing.Point(213, 159);
		F59D8321.Name = "label9";
		F59D8321.Size = new System.Drawing.Size(24, 16);
		F59D8321.TabIndex = 119;
		F59D8321.Text = "lần";
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(25, 159);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(136, 16);
		label8.TabIndex = 118;
		label8.Text = "Dừng khi Fb cảnh báo:";
		ckbTuongTac.AutoSize = true;
		ckbTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuongTac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbTuongTac.Location = new System.Drawing.Point(28, 136);
		ckbTuongTac.Name = "ckbTuongTac";
		ckbTuongTac.Size = new System.Drawing.Size(184, 20);
		ckbTuongTac.TabIndex = 115;
		ckbTuongTac.Text = "Tương tác trước khi kết bạn";
		ckbTuongTac.UseVisualStyleBackColor = true;
		ckbTuongTac.CheckedChanged += new System.EventHandler(ckbTuongTac_CheckedChanged);
		nudDelayTo.Location = new System.Drawing.Point(227, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		D885800A.Location = new System.Drawing.Point(130, 107);
		D885800A.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		D885800A.Name = "nudDelayFrom";
		D885800A.Size = new System.Drawing.Size(56, 23);
		D885800A.TabIndex = 3;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(192, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		FCAC7EA1.Location = new System.Drawing.Point(227, 78);
		FCAC7EA1.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FCAC7EA1.Name = "nudSoLuongTo";
		FCAC7EA1.Size = new System.Drawing.Size(56, 23);
		FCAC7EA1.TabIndex = 2;
		nudSoLuongFrom.Location = new System.Drawing.Point(130, 78);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 1;
		txtTenHanhDong.Location = new System.Drawing.Point(130, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(192, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(25, 52);
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
		btnCancel.Location = new System.Drawing.Point(306, 259);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
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
		btnAdd.Location = new System.Drawing.Point(199, 259);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		C7A5A19E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C7A5A19E.BackColor = System.Drawing.Color.White;
		C7A5A19E.BorderRadius = 0;
		C7A5A19E.BottomSahddow = true;
		C7A5A19E.color = System.Drawing.Color.DarkViolet;
		C7A5A19E.Controls.Add(pnlHeader);
		C7A5A19E.LeftSahddow = false;
		C7A5A19E.Location = new System.Drawing.Point(1, 0);
		C7A5A19E.Name = "bunifuCards1";
		C7A5A19E.RightSahddow = true;
		C7A5A19E.ShadowDepth = 20;
		C7A5A19E.Size = new System.Drawing.Size(597, 37);
		C7A5A19E.TabIndex = 28;
		ckbAddFriendApi.AutoSize = true;
		ckbAddFriendApi.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAddFriendApi.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbAddFriendApi.Location = new System.Drawing.Point(28, 184);
		ckbAddFriendApi.Name = "ckbAddFriendApi";
		ckbAddFriendApi.Size = new System.Drawing.Size(99, 20);
		ckbAddFriendApi.TabIndex = 113;
		ckbAddFriendApi.Text = "Run API (ẩn)";
		ckbAddFriendApi.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(600, 301);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKetBanTepUid";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(DF39E11F);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)ED37BA2E).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ED2EB086.ResumeLayout(false);
		ED2EB086.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTimesWarning).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)D885800A).EndInit();
		((System.ComponentModel.ISupportInitialize)FCAC7EA1).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		C7A5A19E.ResumeLayout(false);
		ResumeLayout(false);
	}
}
