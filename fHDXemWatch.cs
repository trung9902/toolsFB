using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDXemWatch : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string B133DCB9;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal ucTuongTacBaiVietv2 ucTuongTacBaiVietv2_0;

	internal IContainer FCBF2100 = null;

	internal BunifuDragControl B8AB5DA9;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel AC206D26;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown AFA71203;

	internal NumericUpDown nudDelayFrom;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label AA86F990;

	internal Label label5;

	internal Label label2;

	internal Label CE0B1538;

	internal Button A920F3A1;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel F32A39AF;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel plTuongTacBaiViet;

	internal ComboBox cbbOptionsPost;

	internal Label label4;

	internal Panel panel2;

	internal TabControl FB940290;

	internal TabPage C9924A27;

	internal TabPage tabPage2;

	internal Label label8;

	internal Label C833D92B;

	internal NumericUpDown nudThoiGianFrom;

	internal NumericUpDown nudThoiGianTo;

	internal Panel plDieuKien;

	internal RichTextBox txtTuKhoa;

	internal Label lblTuKhoa;

	internal Label label10;

	internal Label E62A9215;

	internal NumericUpDown F02D2B8F;

	internal CheckBox ckbDieuKien;

	public static bool EF216311
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

	public fHDXemWatch(string string_2, string string_3 = "")
	{
		InitializeComponent();
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		EF216311 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			B133DCB9 = dataTable.Rows[0]["Id_TuongTac"].ToString();
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

	private void F2BB2387(object sender, EventArgs e)
	{
		DD945428();
		try
		{
			cbbOptionsPost.SelectedIndex = gclass4_0.method_2("cbbOptionsPost");
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			AFA71203.Value = gclass4_0.method_2("nudSoLuongTo", 2);
			nudThoiGianFrom.Value = gclass4_0.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = gclass4_0.method_2("nudThoiGianTo", 30);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			ucTuongTacBaiVietv2_0 = new ucTuongTacBaiVietv2(gclass4_0);
			plTuongTacBaiViet.Controls.Add(ucTuongTacBaiVietv2_0);
			ckbDieuKien.Checked = gclass4_0.method_3("ckbDieuKien");
			txtTuKhoa.Text = gclass4_0.BDB80B23("txtTuKhoa");
			F02D2B8F.Value = gclass4_0.method_2("nudLuotToiDa", 50);
		}
		catch
		{
		}
		method_0();
	}

	private void DD945428()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(cbbOptionsPost, list_);
	}

	private void button1_Click(object sender, EventArgs e)
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
		GClass4 gClass = ucTuongTacBaiVietv2_0.method_2();
		gClass.method_4("cbbOptionsPost", cbbOptionsPost.SelectedIndex);
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", AFA71203.Value);
		gClass.method_4("nudThoiGianFrom", nudThoiGianFrom.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbDieuKien", ckbDieuKien.Checked);
		gClass.method_4("txtTuKhoa", txtTuKhoa.Text.Trim());
		gClass.method_4("nudLuotToiDa", F02D2B8F.Value);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, B133DCB9, e013A))
				{
					EF216311 = true;
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
				EF216311 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void A920F3A1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AC206D26_Paint(object sender, PaintEventArgs e)
	{
		if (AC206D26.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, AC206D26.ClientSize.Width - num, AC206D26.ClientSize.Height - num));
		}
	}

	private void method_0()
	{
		D623B838(null, null);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void cbbOptionsPost_SelectedIndexChanged(object sender, EventArgs e)
	{
		FB940290.SelectedIndex = cbbOptionsPost.SelectedIndex;
	}

	private void D623B838(object sender, EventArgs e)
	{
		plDieuKien.Enabled = ckbDieuKien.Checked;
	}

	private void txtTuKhoa_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTuKhoa, lblTuKhoa);
	}

	private void C78BE816(object sender, EventArgs e)
	{
		plDieuKien.Height = 205;
	}

	private void D307DE03(object sender, EventArgs e)
	{
		plDieuKien.Height = 86;
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && FCBF2100 != null)
		{
			FCBF2100.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		FCBF2100 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDXemWatch));
		B8AB5DA9 = new Bunifu.Framework.UI.BunifuDragControl(FCBF2100);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(FCBF2100);
		F32A39AF = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		AC206D26 = new System.Windows.Forms.Panel();
		plDieuKien = new System.Windows.Forms.Panel();
		txtTuKhoa = new System.Windows.Forms.RichTextBox();
		lblTuKhoa = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		E62A9215 = new System.Windows.Forms.Label();
		F02D2B8F = new System.Windows.Forms.NumericUpDown();
		ckbDieuKien = new System.Windows.Forms.CheckBox();
		panel2 = new System.Windows.Forms.Panel();
		FB940290 = new System.Windows.Forms.TabControl();
		C9924A27 = new System.Windows.Forms.TabPage();
		label2 = new System.Windows.Forms.Label();
		AA86F990 = new System.Windows.Forms.Label();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		AFA71203 = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		label8 = new System.Windows.Forms.Label();
		C833D92B = new System.Windows.Forms.Label();
		nudThoiGianFrom = new System.Windows.Forms.NumericUpDown();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		cbbOptionsPost = new System.Windows.Forms.ComboBox();
		plTuongTacBaiViet = new System.Windows.Forms.Panel();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		CE0B1538 = new System.Windows.Forms.Label();
		A920F3A1 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		F32A39AF.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		AC206D26.SuspendLayout();
		plDieuKien.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F02D2B8F).BeginInit();
		panel2.SuspendLayout();
		FB940290.SuspendLayout();
		C9924A27.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)AFA71203).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		B8AB5DA9.Fixed = true;
		B8AB5DA9.Horizontal = true;
		B8AB5DA9.TargetControl = bunifuCustomLabel1;
		B8AB5DA9.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(716, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Xem Watch";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = F32A39AF;
		bunifuDragControl_0.Vertical = true;
		F32A39AF.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F32A39AF.BackColor = System.Drawing.Color.White;
		F32A39AF.Controls.Add(button1);
		F32A39AF.Controls.Add(pictureBox1);
		F32A39AF.Controls.Add(bunifuCustomLabel1);
		F32A39AF.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F32A39AF.Location = new System.Drawing.Point(0, 3);
		F32A39AF.Name = "pnlHeader";
		F32A39AF.Size = new System.Drawing.Size(716, 31);
		F32A39AF.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(F32A39AF.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		F32A39AF.Controls.Add(btnMinimize);
		F32A39AF.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(F32A39AF.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(F32A39AF.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(685, 1);
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
		AC206D26.BackColor = System.Drawing.Color.White;
		AC206D26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		AC206D26.Controls.Add(plDieuKien);
		AC206D26.Controls.Add(ckbDieuKien);
		AC206D26.Controls.Add(panel2);
		AC206D26.Controls.Add(cbbOptionsPost);
		AC206D26.Controls.Add(plTuongTacBaiViet);
		AC206D26.Controls.Add(nudDelayTo);
		AC206D26.Controls.Add(nudDelayFrom);
		AC206D26.Controls.Add(txtTenHanhDong);
		AC206D26.Controls.Add(label7);
		AC206D26.Controls.Add(label5);
		AC206D26.Controls.Add(label4);
		AC206D26.Controls.Add(CE0B1538);
		AC206D26.Controls.Add(A920F3A1);
		AC206D26.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		AC206D26.Controls.Add(pnlTopAccent);
		AC206D26.Controls.Add(bunifuCards1);
		AC206D26.Cursor = System.Windows.Forms.Cursors.Arrow;
		AC206D26.Dock = System.Windows.Forms.DockStyle.Fill;
		AC206D26.Location = new System.Drawing.Point(0, 0);
		AC206D26.Name = "panel1";
		AC206D26.Size = new System.Drawing.Size(719, 489);
		AC206D26.TabIndex = 0;
		AC206D26.Paint += new System.Windows.Forms.PaintEventHandler(AC206D26_Paint);
		plDieuKien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDieuKien.Controls.Add(txtTuKhoa);
		plDieuKien.Controls.Add(lblTuKhoa);
		plDieuKien.Controls.Add(label10);
		plDieuKien.Controls.Add(E62A9215);
		plDieuKien.Controls.Add(F02D2B8F);
		plDieuKien.Location = new System.Drawing.Point(381, 74);
		plDieuKien.Name = "plDieuKien";
		plDieuKien.Size = new System.Drawing.Size(306, 86);
		plDieuKien.TabIndex = 200;
		plDieuKien.Visible = false;
		txtTuKhoa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTuKhoa.Location = new System.Drawing.Point(7, 25);
		txtTuKhoa.Name = "txtTuKhoa";
		txtTuKhoa.Size = new System.Drawing.Size(291, 55);
		txtTuKhoa.TabIndex = 0;
		txtTuKhoa.Text = "";
		txtTuKhoa.WordWrap = false;
		txtTuKhoa.TextChanged += new System.EventHandler(txtTuKhoa_TextChanged);
		txtTuKhoa.MouseEnter += new System.EventHandler(C78BE816);
		txtTuKhoa.MouseLeave += new System.EventHandler(D307DE03);
		lblTuKhoa.AutoSize = true;
		lblTuKhoa.Location = new System.Drawing.Point(3, 5);
		lblTuKhoa.Name = "lblTuKhoa";
		lblTuKhoa.Size = new System.Drawing.Size(114, 16);
		lblTuKhoa.TabIndex = 0;
		lblTuKhoa.Text = "Danh sa\u0301ch tên (0):";
		label10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		label10.AutoSize = true;
		label10.Location = new System.Drawing.Point(276, 3);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(24, 16);
		label10.TabIndex = 32;
		label10.Text = "ba\u0300i";
		E62A9215.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E62A9215.AutoSize = true;
		E62A9215.Location = new System.Drawing.Point(148, 3);
		E62A9215.Name = "label6";
		E62A9215.Size = new System.Drawing.Size(73, 16);
		E62A9215.TabIndex = 32;
		E62A9215.Text = "Lươ\u0301t tô\u0301i đa:";
		F02D2B8F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F02D2B8F.Location = new System.Drawing.Point(222, 1);
		F02D2B8F.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		F02D2B8F.Name = "nudLuotToiDa";
		F02D2B8F.Size = new System.Drawing.Size(54, 23);
		F02D2B8F.TabIndex = 1;
		F02D2B8F.Value = new decimal(new int[4] { 500, 0, 0, 0 });
		ckbDieuKien.AutoSize = true;
		ckbDieuKien.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDieuKien.Location = new System.Drawing.Point(381, 51);
		ckbDieuKien.Name = "ckbDieuKien";
		ckbDieuKien.Size = new System.Drawing.Size(293, 20);
		ckbDieuKien.TabIndex = 201;
		ckbDieuKien.Text = "Chi\u0309 tương ta\u0301c khi tên page co\u0301 chư\u0301a ca\u0301c tư\u0300 sau:";
		ckbDieuKien.UseVisualStyleBackColor = true;
		ckbDieuKien.Visible = false;
		ckbDieuKien.CheckedChanged += new System.EventHandler(D623B838);
		panel2.Controls.Add(FB940290);
		panel2.Location = new System.Drawing.Point(28, 108);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(266, 23);
		panel2.TabIndex = 199;
		FB940290.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		FB940290.Controls.Add(C9924A27);
		FB940290.Controls.Add(tabPage2);
		FB940290.Location = new System.Drawing.Point(-5, -5);
		FB940290.Name = "tabOptionsPost";
		FB940290.SelectedIndex = 0;
		FB940290.Size = new System.Drawing.Size(276, 54);
		FB940290.TabIndex = 198;
		C9924A27.Controls.Add(label2);
		C9924A27.Controls.Add(AA86F990);
		C9924A27.Controls.Add(nudSoLuongFrom);
		C9924A27.Controls.Add(AFA71203);
		C9924A27.Location = new System.Drawing.Point(4, 4);
		C9924A27.Name = "tabPage1";
		C9924A27.Padding = new System.Windows.Forms.Padding(3);
		C9924A27.Size = new System.Drawing.Size(268, 25);
		C9924A27.TabIndex = 0;
		C9924A27.Text = "tabPage1";
		C9924A27.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(0, 3);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 16);
		label2.TabIndex = 32;
		label2.Text = "Sô\u0301 lươ\u0323ng ba\u0300i:";
		AA86F990.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AA86F990.Location = new System.Drawing.Point(174, 3);
		AA86F990.Name = "label3";
		AA86F990.Size = new System.Drawing.Size(29, 16);
		AA86F990.TabIndex = 1;
		AA86F990.Text = ">";
		AA86F990.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongFrom.Location = new System.Drawing.Point(112, 1);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 0;
		AFA71203.Location = new System.Drawing.Point(209, 1);
		AFA71203.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AFA71203.Name = "nudSoLuongTo";
		AFA71203.Size = new System.Drawing.Size(56, 23);
		AFA71203.TabIndex = 2;
		tabPage2.Controls.Add(label8);
		tabPage2.Controls.Add(C833D92B);
		tabPage2.Controls.Add(nudThoiGianFrom);
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
		C833D92B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C833D92B.Location = new System.Drawing.Point(174, 3);
		C833D92B.Name = "label9";
		C833D92B.Size = new System.Drawing.Size(29, 16);
		C833D92B.TabIndex = 41;
		C833D92B.Text = ">";
		C833D92B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		cbbOptionsPost.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbOptionsPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbOptionsPost.DropDownWidth = 200;
		cbbOptionsPost.FormattingEnabled = true;
		cbbOptionsPost.Location = new System.Drawing.Point(139, 78);
		cbbOptionsPost.Name = "cbbOptionsPost";
		cbbOptionsPost.Size = new System.Drawing.Size(153, 24);
		cbbOptionsPost.TabIndex = 1;
		cbbOptionsPost.SelectedIndexChanged += new System.EventHandler(cbbOptionsPost_SelectedIndexChanged);
		plTuongTacBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuongTacBaiViet.Location = new System.Drawing.Point(30, 166);
		plTuongTacBaiViet.Name = "plTuongTacBaiViet";
		plTuongTacBaiViet.Size = new System.Drawing.Size(657, 266);
		plTuongTacBaiViet.TabIndex = 193;
		nudDelayTo.Location = new System.Drawing.Point(236, 137);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(139, 137);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 2;
		txtTenHanhDong.Location = new System.Drawing.Point(139, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(201, 139);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 3;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 139);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 34;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 81);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(64, 16);
		label4.TabIndex = 32;
		label4.Text = "Tu\u0300y cho\u0323n:";
		CE0B1538.AutoSize = true;
		CE0B1538.Location = new System.Drawing.Point(27, 52);
		CE0B1538.Name = "label1";
		CE0B1538.Size = new System.Drawing.Size(98, 16);
		CE0B1538.TabIndex = 31;
		CE0B1538.Text = "Tên ha\u0300nh đô\u0323ng:";
		A920F3A1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A920F3A1.BackColor = System.Drawing.Color.Maroon;
		A920F3A1.Cursor = System.Windows.Forms.Cursors.Hand;
		A920F3A1.FlatAppearance.BorderSize = 0;
		A920F3A1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A920F3A1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A920F3A1.ForeColor = System.Drawing.Color.White;
		A920F3A1.Location = new System.Drawing.Point(367, 446);
		A920F3A1.Name = "btnCancel";
		A920F3A1.Size = new System.Drawing.Size(92, 29);
		A920F3A1.TabIndex = 10;
		A920F3A1.Text = "Đóng";
		A920F3A1.UseVisualStyleBackColor = false;
		A920F3A1.Click += new System.EventHandler(A920F3A1_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(260, 446);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(F32A39AF);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(716, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(719, 489);
		base.Controls.Add(AC206D26);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDXemWatch";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(F2BB2387);
		F32A39AF.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		AC206D26.ResumeLayout(false);
		AC206D26.PerformLayout();
		plDieuKien.ResumeLayout(false);
		plDieuKien.PerformLayout();
		((System.ComponentModel.ISupportInitialize)F02D2B8F).EndInit();
		panel2.ResumeLayout(false);
		FB940290.ResumeLayout(false);
		C9924A27.ResumeLayout(false);
		C9924A27.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)AFA71203).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
