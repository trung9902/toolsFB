using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDHuyKetBan : Form
{
	internal GClass4 gclass4_0;

	internal string CCB602AE;

	internal string B0BA8482;

	internal string E91F6823;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl DC3572B6;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown B408233D;

	internal TextBox txtTenHanhDong;

	internal Label label3;

	internal Label B0925621;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button F1937C96;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel E7817E92;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown FAAC8D30;

	internal Label label7;

	internal Label label6;

	internal RichTextBox C6A7C39D;

	internal Label F9272F3C;

	internal ComboBox cbbTypeHuyKetBan;

	internal Panel B836D687;

	internal RichTextBox txtUidHuyKetBan;

	internal Label D0A4D71A;

	internal Label label12;

	internal Label C49B468E;

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

	public fHDHuyKetBan(string F61F0F88, string string_0 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		CCB602AE = F61F0F88;
		E91F6823 = string_0;
		string aA239C = Language.GetValue(E7817E92.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string string_ = base.Name.Substring(1);
		Class154.FA0E41AD(string_, aA239C);
		string string_2 = "";
		if (string_0 == "")
		{
			DataTable dataTable = Class154.BD904B3B(string_);
			B0BA8482 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_0);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void B40E4216(object sender, EventArgs e)
	{
		method_0();
		try
		{
			B408233D.Value = gclass4_0.method_2("nudSoLuongFrom");
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo");
			FAAC8D30.Value = gclass4_0.method_2("nudDelayFrom");
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo");
			cbbTypeHuyKetBan.SelectedIndex = gclass4_0.method_2("cbbTypeHuyKetBan");
			txtUidHuyKetBan.Text = gclass4_0.BDB80B23("txtUidHuyKetBan");
			C6A7C39D.Text = gclass4_0.BDB80B23("txtUidKhongHuyKetBan");
		}
		catch
		{
		}
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Ngẫu nhiên danh sách bạn", "Hủy kết bạn với tài khoản tên ngoại", "Hủy kết bạn theo UID" };
		Commom.smethod_23(cbbTypeHuyKetBan, list_);
	}

	private void F1937C96_Click(object sender, EventArgs e)
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
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", B408233D.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", FAAC8D30.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("cbbTypeHuyKetBan", cbbTypeHuyKetBan.SelectedIndex);
		gClass.method_4("txtUidHuyKetBan", txtUidHuyKetBan.Text);
		gClass.method_4("txtUidKhongHuyKetBan", C6A7C39D.Text);
		string text2 = gClass.ED11179C();
		if (E91F6823 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(CCB602AE, text, B0BA8482, text2))
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
			if (Class154.smethod_13(E91F6823, text, text2))
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

	private void AFA88FA2(object sender, EventArgs e)
	{
		Close();
	}

	private void CF19DB1A(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void C23F462B(object sender, EventArgs e)
	{
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void C6A7C39D_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C6A7C39D, F9272F3C);
	}

	private void F9272F3C_Click(object sender, EventArgs e)
	{
	}

	private void FF15A58B(object sender, EventArgs e)
	{
		B836D687.Enabled = cbbTypeHuyKetBan.SelectedIndex == 2;
	}

	private void txtUidHuyKetBan_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtUidHuyKetBan, D0A4D71A);
	}

	protected override void Dispose(bool D49EFAA0)
	{
		if (D49EFAA0 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(D49EFAA0);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDHuyKetBan));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		E7817E92 = new Bunifu.Framework.UI.BunifuCustomLabel();
		DC3572B6 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		F1937C96 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		B836D687 = new System.Windows.Forms.Panel();
		txtUidHuyKetBan = new System.Windows.Forms.RichTextBox();
		D0A4D71A = new System.Windows.Forms.Label();
		cbbTypeHuyKetBan = new System.Windows.Forms.ComboBox();
		label12 = new System.Windows.Forms.Label();
		B0925621 = new System.Windows.Forms.Label();
		C6A7C39D = new System.Windows.Forms.RichTextBox();
		label3 = new System.Windows.Forms.Label();
		B408233D = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		FAAC8D30 = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		F9272F3C = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		C49B468E = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		B836D687.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B408233D).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)FAAC8D30).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = E7817E92;
		bunifuDragControl_0.Vertical = true;
		E7817E92.BackColor = System.Drawing.Color.Transparent;
		E7817E92.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E7817E92.Dock = System.Windows.Forms.DockStyle.Fill;
		E7817E92.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E7817E92.ForeColor = System.Drawing.Color.Black;
		E7817E92.Location = new System.Drawing.Point(0, 0);
		E7817E92.Name = "bunifuCustomLabel1";
		E7817E92.Size = new System.Drawing.Size(651, 31);
		E7817E92.TabIndex = 12;
		E7817E92.Text = "Cấu hình Hủy kết bạn";
		E7817E92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DC3572B6.Fixed = true;
		DC3572B6.Horizontal = true;
		DC3572B6.TargetControl = pnlHeader;
		DC3572B6.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(F1937C96);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(E7817E92);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(651, 31);
		pnlHeader.TabIndex = 9;
		F1937C96.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F1937C96.Cursor = System.Windows.Forms.Cursors.Hand;
		F1937C96.FlatAppearance.BorderSize = 0;
		F1937C96.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F1937C96.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F1937C96.ForeColor = System.Drawing.Color.White;
		F1937C96.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		F1937C96.Location = new System.Drawing.Point(620, 1);
		F1937C96.Name = "button1";
		F1937C96.Size = new System.Drawing.Size(30, 30);
		F1937C96.TabIndex = 77;
		F1937C96.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		F1937C96.UseVisualStyleBackColor = true;
		F1937C96.Click += new System.EventHandler(F1937C96_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(C49B468E);
		panel1.Controls.Add(B836D687);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(cbbTypeHuyKetBan);
		panel1.Controls.Add(label12);
		panel1.Controls.Add(B0925621);
		panel1.Controls.Add(C6A7C39D);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(B408233D);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(FAAC8D30);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(F9272F3C);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(654, 425);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(CF19DB1A);
		B836D687.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B836D687.Controls.Add(txtUidHuyKetBan);
		B836D687.Controls.Add(D0A4D71A);
		B836D687.Location = new System.Drawing.Point(30, 170);
		B836D687.Name = "plDieuKienID";
		B836D687.Size = new System.Drawing.Size(295, 188);
		B836D687.TabIndex = 52;
		txtUidHuyKetBan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtUidHuyKetBan.Location = new System.Drawing.Point(6, 22);
		txtUidHuyKetBan.Name = "txtUidHuyKetBan";
		txtUidHuyKetBan.Size = new System.Drawing.Size(284, 161);
		txtUidHuyKetBan.TabIndex = 1;
		txtUidHuyKetBan.Text = "";
		txtUidHuyKetBan.WordWrap = false;
		txtUidHuyKetBan.TextChanged += new System.EventHandler(txtUidHuyKetBan_TextChanged);
		D0A4D71A.AutoSize = true;
		D0A4D71A.Location = new System.Drawing.Point(3, 3);
		D0A4D71A.Name = "lblUidHuyKetBan";
		D0A4D71A.Size = new System.Drawing.Size(114, 16);
		D0A4D71A.TabIndex = 0;
		D0A4D71A.Text = "Danh sách Uid (0):";
		cbbTypeHuyKetBan.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeHuyKetBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeHuyKetBan.DropDownWidth = 220;
		cbbTypeHuyKetBan.FormattingEnabled = true;
		cbbTypeHuyKetBan.Location = new System.Drawing.Point(132, 140);
		cbbTypeHuyKetBan.Name = "cbbTypeHuyKetBan";
		cbbTypeHuyKetBan.Size = new System.Drawing.Size(193, 24);
		cbbTypeHuyKetBan.TabIndex = 124;
		cbbTypeHuyKetBan.SelectedIndexChanged += new System.EventHandler(FF15A58B);
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(27, 143);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(64, 16);
		label12.TabIndex = 122;
		label12.Text = "Tùy chọn:";
		B0925621.AutoSize = true;
		B0925621.Location = new System.Drawing.Point(284, 80);
		B0925621.Name = "label4";
		B0925621.Size = new System.Drawing.Size(28, 16);
		B0925621.TabIndex = 35;
		B0925621.Text = "ba\u0323n";
		C6A7C39D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C6A7C39D.Location = new System.Drawing.Point(364, 101);
		C6A7C39D.Name = "txtUidKhongHuyKetBan";
		C6A7C39D.Size = new System.Drawing.Size(257, 257);
		C6A7C39D.TabIndex = 117;
		C6A7C39D.Text = "";
		C6A7C39D.WordWrap = false;
		C6A7C39D.TextChanged += new System.EventHandler(C6A7C39D_TextChanged);
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(192, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B408233D.Location = new System.Drawing.Point(132, 78);
		B408233D.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		B408233D.Name = "nudSoLuongFrom";
		B408233D.Size = new System.Drawing.Size(56, 23);
		B408233D.TabIndex = 1;
		nudSoLuongTo.Location = new System.Drawing.Point(226, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		nudDelayTo.Location = new System.Drawing.Point(226, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		FAAC8D30.Location = new System.Drawing.Point(132, 107);
		FAAC8D30.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FAAC8D30.Name = "nudDelayFrom";
		FAAC8D30.Size = new System.Drawing.Size(56, 23);
		FAAC8D30.TabIndex = 3;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(192, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(285, 109);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(30, 16);
		label6.TabIndex = 45;
		label6.Text = "giây";
		F9272F3C.AutoSize = true;
		F9272F3C.Location = new System.Drawing.Point(361, 82);
		F9272F3C.Name = "label10";
		F9272F3C.Size = new System.Drawing.Size(222, 16);
		F9272F3C.TabIndex = 44;
		F9272F3C.Text = "Danh sách UID bạn bè cần giữ lại (0):";
		F9272F3C.Click += new System.EventHandler(F9272F3C_Click);
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
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
		btnCancel.Location = new System.Drawing.Point(349, 378);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(AFA88FA2);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(242, 378);
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
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(651, 37);
		bunifuCards1.TabIndex = 28;
		C49B468E.AutoSize = true;
		C49B468E.Location = new System.Drawing.Point(27, 109);
		C49B468E.Name = "label2";
		C49B468E.Size = new System.Drawing.Size(87, 16);
		C49B468E.TabIndex = 33;
		C49B468E.Text = "Gia\u0303n ca\u0301ch (s):";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 34;
		label9.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(654, 425);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDHuyKetBan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(B40E4216);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		B836D687.ResumeLayout(false);
		B836D687.PerformLayout();
		((System.ComponentModel.ISupportInitialize)B408233D).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)FAAC8D30).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
