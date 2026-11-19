using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBaiVietNewsfeed3 : Form
{
	internal GClass4 B6847308;

	internal string B9B98E09;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal ucTuongTacBaiVietv2 ucTuongTacBaiVietv2_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl C4A44AB3;

	internal BunifuDragControl D6BADD17;

	internal Panel E611971B;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown D53FDCBE;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox txtTenHanhDong;

	internal Label BE886D86;

	internal Label label3;

	internal Label CD2D8400;

	internal Label label2;

	internal Label label1;

	internal Button E235CBAB;

	internal Button A61DB09A;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel A29FE597;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel D72E550C;

	internal Panel plTuongTacBaiViet;

	internal CheckBox ckbDieuKien;

	internal Panel plDieuKien;

	internal RichTextBox txtTuKhoa;

	internal Label lblTuKhoa;

	internal Label D80DDF3C;

	internal Label F49DFD83;

	internal NumericUpDown nudLuotToiDa;

	internal ComboBox cbbOptionsPost;

	internal Label label4;

	internal Panel panel2;

	internal TabControl A4343289;

	internal TabPage B01EA699;

	internal TabPage tabPage2;

	internal Label label8;

	internal Label label9;

	internal NumericUpDown B5B93127;

	internal NumericUpDown B5B158BE;

	internal Panel plFeedAds;

	internal Label label12;

	internal Label label13;

	internal NumericUpDown AA814F05;

	internal CheckBox C4331F2A;

	internal Panel plClickXemAnh;

	internal NumericUpDown nudDelayXemAnhTo;

	internal NumericUpDown nudDelayXemAnhFrom;

	internal Label label11;

	internal Label label16;

	internal Panel plClickXemThem;

	internal NumericUpDown nudDelayXemThemTo;

	internal NumericUpDown nudDelayXemThemFrom;

	internal Label label17;

	internal Label C10FF5AD;

	internal CheckBox ckbClickXemAnh;

	internal CheckBox ckbClickXemThem;

	internal Panel plFeedGroup;

	internal RichTextBox txtIdNhom;

	internal Label lblIdNhom;

	internal Label D01F0CAE;

	internal Label label15;

	internal NumericUpDown DCA019A9;

	internal CheckBox ckbFeedGroup;

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

	public fHDBaiVietNewsfeed3(string string_2, string CF83DE17 = "")
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
		Boolean_0 = false;
		B9B98E09 = string_2;
		string_1 = CF83DE17;
		string aA239C = Language.GetValue(D72E550C.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (CF83DE17 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(CF83DE17);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			A61DB09A.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		B6847308 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		ckbFeedGroup.Visible = Base.DB801CBD;
		plFeedGroup.Visible = Base.DB801CBD;
		base.Height = (Base.DB801CBD ? 552 : 462);
	}

	private void fHDBaiVietNewsfeed3_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			cbbOptionsPost.SelectedIndex = B6847308.method_2("cbbOptionsPost");
			nudSoLuongFrom.Value = B6847308.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = B6847308.method_2("nudSoLuongTo", 2);
			B5B93127.Value = B6847308.method_2("nudThoiGianFrom", 30);
			B5B158BE.Value = B6847308.method_2("nudThoiGianTo", 30);
			D53FDCBE.Value = B6847308.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = B6847308.method_2("nudDelayTo", 5);
			ucTuongTacBaiVietv2_0 = new ucTuongTacBaiVietv2(B6847308);
			plTuongTacBaiViet.Controls.Add(ucTuongTacBaiVietv2_0);
			ckbDieuKien.Checked = B6847308.method_3("ckbDieuKien");
			txtTuKhoa.Text = B6847308.BDB80B23("txtTuKhoa");
			nudLuotToiDa.Value = B6847308.method_2("nudLuotToiDa", 50);
			C4331F2A.Checked = B6847308.method_3("ckbFeedAds");
			AA814F05.Value = B6847308.method_2("nudFeedAdsLuotToiDa", 50);
			ckbFeedGroup.Checked = B6847308.method_3("ckbFeedGroup");
			txtIdNhom.Text = B6847308.BDB80B23("txtIdNhom");
			DCA019A9.Value = B6847308.method_2("nudFeedGroupLuotToiDa", 50);
			ckbClickXemThem.Checked = B6847308.method_3("ckbClickXemThem");
			nudDelayXemThemFrom.Value = B6847308.method_2("nudDelayXemThemFrom", 3);
			nudDelayXemThemTo.Value = B6847308.method_2("nudDelayXemThemTo", 3);
			ckbClickXemAnh.Checked = B6847308.method_3("ckbClickXemAnh");
			nudDelayXemAnhFrom.Value = B6847308.method_2("nudDelayXemAnhFrom", 3);
			nudDelayXemAnhTo.Value = B6847308.method_2("nudDelayXemAnhTo", 3);
		}
		catch
		{
		}
		AE3542A3();
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

	private void A61DB09A_Click(object sender, EventArgs e)
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
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudThoiGianFrom", B5B93127.Value);
		gClass.method_4("nudThoiGianTo", B5B158BE.Value);
		gClass.method_4("nudDelayFrom", D53FDCBE.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbDieuKien", ckbDieuKien.Checked);
		gClass.method_4("txtTuKhoa", txtTuKhoa.Text.Trim());
		gClass.method_4("nudLuotToiDa", nudLuotToiDa.Value);
		gClass.method_4("ckbFeedAds", C4331F2A.Checked);
		gClass.method_4("nudFeedAdsLuotToiDa", AA814F05.Value);
		gClass.method_4("ckbFeedGroup", ckbFeedGroup.Checked);
		gClass.method_4("txtIdNhom", txtIdNhom.Text.Trim());
		gClass.method_4("nudFeedGroupLuotToiDa", DCA019A9.Value);
		gClass.method_4("ckbClickXemThem", ckbClickXemThem.Checked);
		gClass.method_4("nudDelayXemThemFrom", nudDelayXemThemFrom.Value);
		gClass.method_4("nudDelayXemThemTo", nudDelayXemThemTo.Value);
		gClass.method_4("ckbClickXemAnh", ckbClickXemAnh.Checked);
		gClass.method_4("nudDelayXemAnhFrom", nudDelayXemAnhFrom.Value);
		gClass.method_4("nudDelayXemAnhTo", nudDelayXemAnhTo.Value);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(B9B98E09, text, string_0, e013A))
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
			if (Class154.smethod_13(string_1, text, e013A))
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

	private void E235CBAB_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E611971B_Paint(object sender, PaintEventArgs e)
	{
		if (E611971B.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, E611971B.ClientSize.Width - num, E611971B.ClientSize.Height - num));
		}
	}

	private void AE3542A3()
	{
		ckbDieuKien_CheckedChanged(null, null);
		C4331F2A_CheckedChanged(null, null);
		EE167004(null, null);
		A53CAE9D(null, null);
		CA8EF3A5(null, null);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void ckbDieuKien_CheckedChanged(object sender, EventArgs e)
	{
		plDieuKien.Enabled = ckbDieuKien.Checked;
	}

	private void txtTuKhoa_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTuKhoa, lblTuKhoa);
	}

	private void cbbOptionsPost_SelectedIndexChanged(object sender, EventArgs e)
	{
		A4343289.SelectedIndex = cbbOptionsPost.SelectedIndex;
	}

	private void BA01BEA3(object sender, EventArgs e)
	{
		plDieuKien.Height = 205;
	}

	private void txtTuKhoa_MouseLeave(object sender, EventArgs e)
	{
		plDieuKien.Height = 86;
	}

	private void C4331F2A_CheckedChanged(object sender, EventArgs e)
	{
		plFeedAds.Enabled = C4331F2A.Checked;
	}

	private void EE167004(object sender, EventArgs e)
	{
		plFeedGroup.Enabled = ckbFeedGroup.Checked;
	}

	private void txtIdNhom_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdNhom, lblIdNhom);
	}

	private void A53CAE9D(object sender, EventArgs e)
	{
		plClickXemThem.Enabled = ckbClickXemThem.Checked;
	}

	private void CA8EF3A5(object sender, EventArgs e)
	{
		plClickXemAnh.Enabled = ckbClickXemAnh.Checked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBaiVietNewsfeed3));
		C4A44AB3 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D72E550C = new Bunifu.Framework.UI.BunifuCustomLabel();
		D6BADD17 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		A29FE597 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		E611971B = new System.Windows.Forms.Panel();
		plTuongTacBaiViet = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		A4343289 = new System.Windows.Forms.TabControl();
		B01EA699 = new System.Windows.Forms.TabPage();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		label8 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		B5B93127 = new System.Windows.Forms.NumericUpDown();
		B5B158BE = new System.Windows.Forms.NumericUpDown();
		cbbOptionsPost = new System.Windows.Forms.ComboBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		D53FDCBE = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		BE886D86 = new System.Windows.Forms.Label();
		CD2D8400 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		E235CBAB = new System.Windows.Forms.Button();
		A61DB09A = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		plDieuKien = new System.Windows.Forms.Panel();
		txtTuKhoa = new System.Windows.Forms.RichTextBox();
		lblTuKhoa = new System.Windows.Forms.Label();
		D80DDF3C = new System.Windows.Forms.Label();
		F49DFD83 = new System.Windows.Forms.Label();
		nudLuotToiDa = new System.Windows.Forms.NumericUpDown();
		ckbDieuKien = new System.Windows.Forms.CheckBox();
		plFeedAds = new System.Windows.Forms.Panel();
		label12 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		AA814F05 = new System.Windows.Forms.NumericUpDown();
		C4331F2A = new System.Windows.Forms.CheckBox();
		ckbClickXemThem = new System.Windows.Forms.CheckBox();
		C10FF5AD = new System.Windows.Forms.Label();
		label17 = new System.Windows.Forms.Label();
		nudDelayXemThemFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayXemThemTo = new System.Windows.Forms.NumericUpDown();
		plClickXemThem = new System.Windows.Forms.Panel();
		ckbFeedGroup = new System.Windows.Forms.CheckBox();
		DCA019A9 = new System.Windows.Forms.NumericUpDown();
		label15 = new System.Windows.Forms.Label();
		D01F0CAE = new System.Windows.Forms.Label();
		lblIdNhom = new System.Windows.Forms.Label();
		txtIdNhom = new System.Windows.Forms.RichTextBox();
		plFeedGroup = new System.Windows.Forms.Panel();
		ckbClickXemAnh = new System.Windows.Forms.CheckBox();
		label16 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		nudDelayXemAnhFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayXemAnhTo = new System.Windows.Forms.NumericUpDown();
		plClickXemAnh = new System.Windows.Forms.Panel();
		A29FE597.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		E611971B.SuspendLayout();
		panel2.SuspendLayout();
		A4343289.SuspendLayout();
		B01EA699.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B5B93127).BeginInit();
		((System.ComponentModel.ISupportInitialize)B5B158BE).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)D53FDCBE).BeginInit();
		bunifuCards1.SuspendLayout();
		plDieuKien.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudLuotToiDa).BeginInit();
		plFeedAds.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AA814F05).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemTo).BeginInit();
		plClickXemThem.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DCA019A9).BeginInit();
		plFeedGroup.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayXemAnhFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemAnhTo).BeginInit();
		plClickXemAnh.SuspendLayout();
		SuspendLayout();
		C4A44AB3.Fixed = true;
		C4A44AB3.Horizontal = true;
		C4A44AB3.TargetControl = D72E550C;
		C4A44AB3.Vertical = true;
		D72E550C.BackColor = System.Drawing.Color.Transparent;
		D72E550C.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D72E550C.Dock = System.Windows.Forms.DockStyle.Fill;
		D72E550C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D72E550C.ForeColor = System.Drawing.Color.Black;
		D72E550C.Location = new System.Drawing.Point(0, 0);
		D72E550C.Name = "bunifuCustomLabel1";
		D72E550C.Size = new System.Drawing.Size(716, 31);
		D72E550C.TabIndex = 12;
		D72E550C.Text = "Cấu hình Bài viết Newsfeed";
		D72E550C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D6BADD17.Fixed = true;
		D6BADD17.Horizontal = true;
		D6BADD17.TargetControl = A29FE597;
		D6BADD17.Vertical = true;
		A29FE597.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A29FE597.BackColor = System.Drawing.Color.White;
		A29FE597.Controls.Add(button1);
		A29FE597.Controls.Add(pictureBox1);
		A29FE597.Controls.Add(D72E550C);
		A29FE597.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A29FE597.Location = new System.Drawing.Point(0, 3);
		A29FE597.Name = "pnlHeader";
		A29FE597.Size = new System.Drawing.Size(716, 31);
		A29FE597.TabIndex = 9;
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
		btnMinimize.Location = new System.Drawing.Point(A29FE597.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		A29FE597.Controls.Add(btnMinimize);
		A29FE597.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(A29FE597.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(A29FE597.Width - 68, 1);
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
		E611971B.BackColor = System.Drawing.Color.White;
		E611971B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E611971B.Controls.Add(plTuongTacBaiViet);
		E611971B.Controls.Add(plClickXemAnh);
		E611971B.Controls.Add(plClickXemThem);
		E611971B.Controls.Add(ckbClickXemAnh);
		E611971B.Controls.Add(ckbClickXemThem);
		E611971B.Controls.Add(panel2);
		E611971B.Controls.Add(cbbOptionsPost);
		E611971B.Controls.Add(nudDelayTo);
		E611971B.Controls.Add(D53FDCBE);
		E611971B.Controls.Add(txtTenHanhDong);
		E611971B.Controls.Add(BE886D86);
		E611971B.Controls.Add(CD2D8400);
		E611971B.Controls.Add(label4);
		E611971B.Controls.Add(label1);
		E611971B.Controls.Add(E235CBAB);
		E611971B.Controls.Add(A61DB09A);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		E611971B.Controls.Add(pnlTopAccent);
		E611971B.Controls.Add(bunifuCards1);
		E611971B.Controls.Add(plFeedGroup);
		E611971B.Controls.Add(plDieuKien);
		E611971B.Controls.Add(ckbFeedGroup);
		E611971B.Controls.Add(ckbDieuKien);
		E611971B.Controls.Add(plFeedAds);
		E611971B.Controls.Add(C4331F2A);
		E611971B.Cursor = System.Windows.Forms.Cursors.Arrow;
		E611971B.Dock = System.Windows.Forms.DockStyle.Fill;
		E611971B.Location = new System.Drawing.Point(0, 0);
		E611971B.Name = "panel1";
		E611971B.Size = new System.Drawing.Size(719, 462);
		E611971B.TabIndex = 0;
		E611971B.Paint += new System.Windows.Forms.PaintEventHandler(E611971B_Paint);
		plTuongTacBaiViet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		plTuongTacBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuongTacBaiViet.Location = new System.Drawing.Point(30, 136);
		plTuongTacBaiViet.Name = "plTuongTacBaiViet";
		plTuongTacBaiViet.Size = new System.Drawing.Size(657, 266);
		plTuongTacBaiViet.TabIndex = 193;
		panel2.Controls.Add(A4343289);
		panel2.Location = new System.Drawing.Point(28, 108);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(266, 23);
		panel2.TabIndex = 199;
		A4343289.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		A4343289.Controls.Add(B01EA699);
		A4343289.Controls.Add(tabPage2);
		A4343289.Location = new System.Drawing.Point(-5, -5);
		A4343289.Name = "tabOptionsPost";
		A4343289.SelectedIndex = 0;
		A4343289.Size = new System.Drawing.Size(276, 54);
		A4343289.TabIndex = 198;
		B01EA699.Controls.Add(label2);
		B01EA699.Controls.Add(label3);
		B01EA699.Controls.Add(nudSoLuongFrom);
		B01EA699.Controls.Add(nudSoLuongTo);
		B01EA699.Location = new System.Drawing.Point(4, 4);
		B01EA699.Name = "tabPage1";
		B01EA699.Padding = new System.Windows.Forms.Padding(3);
		B01EA699.Size = new System.Drawing.Size(268, 25);
		B01EA699.TabIndex = 0;
		B01EA699.Text = "tabPage1";
		B01EA699.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(0, 3);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 16);
		label2.TabIndex = 32;
		label2.Text = "Sô\u0301 lươ\u0323ng ba\u0300i:";
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(172, 3);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 1;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongFrom.Location = new System.Drawing.Point(110, 1);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 0;
		nudSoLuongTo.Location = new System.Drawing.Point(207, 1);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		tabPage2.Controls.Add(label8);
		tabPage2.Controls.Add(label9);
		tabPage2.Controls.Add(B5B93127);
		tabPage2.Controls.Add(B5B158BE);
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
		label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(172, 3);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(29, 16);
		label9.TabIndex = 41;
		label9.Text = ">";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B5B93127.Location = new System.Drawing.Point(110, 1);
		B5B93127.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		B5B93127.Name = "nudThoiGianFrom";
		B5B93127.Size = new System.Drawing.Size(56, 23);
		B5B93127.TabIndex = 38;
		B5B158BE.Location = new System.Drawing.Point(207, 1);
		B5B158BE.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		B5B158BE.Name = "nudThoiGianTo";
		B5B158BE.Size = new System.Drawing.Size(56, 23);
		B5B158BE.TabIndex = 39;
		cbbOptionsPost.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbOptionsPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbOptionsPost.DropDownWidth = 200;
		cbbOptionsPost.FormattingEnabled = true;
		cbbOptionsPost.Location = new System.Drawing.Point(137, 78);
		cbbOptionsPost.Name = "cbbOptionsPost";
		cbbOptionsPost.Size = new System.Drawing.Size(153, 24);
		cbbOptionsPost.TabIndex = 1;
		cbbOptionsPost.SelectedIndexChanged += new System.EventHandler(cbbOptionsPost_SelectedIndexChanged);
		nudDelayTo.Location = new System.Drawing.Point(234, 138);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		D53FDCBE.Location = new System.Drawing.Point(137, 138);
		D53FDCBE.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		D53FDCBE.Name = "nudDelayFrom";
		D53FDCBE.Size = new System.Drawing.Size(56, 23);
		D53FDCBE.TabIndex = 2;
		txtTenHanhDong.Location = new System.Drawing.Point(137, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		BE886D86.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BE886D86.Location = new System.Drawing.Point(199, 140);
		BE886D86.Name = "label7";
		BE886D86.Size = new System.Drawing.Size(29, 16);
		BE886D86.TabIndex = 3;
		BE886D86.Text = ">";
		BE886D86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CD2D8400.AutoSize = true;
		CD2D8400.Location = new System.Drawing.Point(27, 140);
		CD2D8400.Name = "label5";
		CD2D8400.Size = new System.Drawing.Size(87, 16);
		CD2D8400.TabIndex = 34;
		CD2D8400.Text = "Gia\u0303n ca\u0301ch (s):";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 81);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(64, 16);
		label4.TabIndex = 32;
		label4.Text = "Tu\u0300y cho\u0323n:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		E235CBAB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E235CBAB.BackColor = System.Drawing.Color.Maroon;
		E235CBAB.Cursor = System.Windows.Forms.Cursors.Hand;
		E235CBAB.FlatAppearance.BorderSize = 0;
		E235CBAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E235CBAB.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E235CBAB.ForeColor = System.Drawing.Color.White;
		E235CBAB.Location = new System.Drawing.Point(367, 419);
		E235CBAB.Name = "btnCancel";
		E235CBAB.Size = new System.Drawing.Size(92, 29);
		E235CBAB.TabIndex = 10;
		E235CBAB.Text = "Đóng";
		E235CBAB.UseVisualStyleBackColor = false;
		E235CBAB.Click += new System.EventHandler(E235CBAB_Click);
		A61DB09A.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A61DB09A.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		A61DB09A.Cursor = System.Windows.Forms.Cursors.Hand;
		A61DB09A.FlatAppearance.BorderSize = 0;
		A61DB09A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A61DB09A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A61DB09A.ForeColor = System.Drawing.Color.White;
		A61DB09A.Location = new System.Drawing.Point(260, 419);
		A61DB09A.Name = "btnAdd";
		A61DB09A.Size = new System.Drawing.Size(92, 29);
		A61DB09A.TabIndex = 9;
		A61DB09A.Text = "Thêm";
		A61DB09A.UseVisualStyleBackColor = false;
		A61DB09A.Click += new System.EventHandler(A61DB09A_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(A29FE597);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(716, 37);
		bunifuCards1.TabIndex = 28;
		plDieuKien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDieuKien.Controls.Add(txtTuKhoa);
		plDieuKien.Controls.Add(lblTuKhoa);
		plDieuKien.Controls.Add(D80DDF3C);
		plDieuKien.Controls.Add(F49DFD83);
		plDieuKien.Controls.Add(nudLuotToiDa);
		plDieuKien.Location = new System.Drawing.Point(30, 310);
		plDieuKien.Name = "plDieuKien";
		plDieuKien.Size = new System.Drawing.Size(306, 86);
		plDieuKien.TabIndex = 195;
		plDieuKien.Visible = false;
		txtTuKhoa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTuKhoa.Location = new System.Drawing.Point(7, 25);
		txtTuKhoa.Name = "txtTuKhoa";
		txtTuKhoa.Size = new System.Drawing.Size(291, 55);
		txtTuKhoa.TabIndex = 0;
		txtTuKhoa.Text = "";
		txtTuKhoa.WordWrap = false;
		txtTuKhoa.TextChanged += new System.EventHandler(txtTuKhoa_TextChanged);
		txtTuKhoa.MouseEnter += new System.EventHandler(BA01BEA3);
		txtTuKhoa.MouseLeave += new System.EventHandler(txtTuKhoa_MouseLeave);
		lblTuKhoa.AutoSize = true;
		lblTuKhoa.Location = new System.Drawing.Point(3, 5);
		lblTuKhoa.Name = "lblTuKhoa";
		lblTuKhoa.Size = new System.Drawing.Size(114, 16);
		lblTuKhoa.TabIndex = 0;
		lblTuKhoa.Text = "Danh sa\u0301ch tên (0):";
		D80DDF3C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D80DDF3C.AutoSize = true;
		D80DDF3C.Location = new System.Drawing.Point(276, 5);
		D80DDF3C.Name = "label10";
		D80DDF3C.Size = new System.Drawing.Size(24, 16);
		D80DDF3C.TabIndex = 32;
		D80DDF3C.Text = "ba\u0300i";
		F49DFD83.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F49DFD83.AutoSize = true;
		F49DFD83.Location = new System.Drawing.Point(148, 5);
		F49DFD83.Name = "label6";
		F49DFD83.Size = new System.Drawing.Size(73, 16);
		F49DFD83.TabIndex = 32;
		F49DFD83.Text = "Lươ\u0301t tô\u0301i đa:";
		nudLuotToiDa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		nudLuotToiDa.Location = new System.Drawing.Point(222, 1);
		nudLuotToiDa.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudLuotToiDa.Name = "nudLuotToiDa";
		nudLuotToiDa.Size = new System.Drawing.Size(54, 23);
		nudLuotToiDa.TabIndex = 1;
		nudLuotToiDa.Value = new decimal(new int[4] { 500, 0, 0, 0 });
		ckbDieuKien.AutoSize = true;
		ckbDieuKien.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDieuKien.Location = new System.Drawing.Point(30, 287);
		ckbDieuKien.Name = "ckbDieuKien";
		ckbDieuKien.Size = new System.Drawing.Size(293, 20);
		ckbDieuKien.TabIndex = 196;
		ckbDieuKien.Text = "Chi\u0309 tương ta\u0301c khi tên page co\u0301 chư\u0301a ca\u0301c tư\u0300 sau:";
		ckbDieuKien.UseVisualStyleBackColor = true;
		ckbDieuKien.Visible = false;
		ckbDieuKien.CheckedChanged += new System.EventHandler(ckbDieuKien_CheckedChanged);
		plFeedAds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plFeedAds.Controls.Add(label12);
		plFeedAds.Controls.Add(label13);
		plFeedAds.Controls.Add(AA814F05);
		plFeedAds.Location = new System.Drawing.Point(381, 362);
		plFeedAds.Name = "plFeedAds";
		plFeedAds.Size = new System.Drawing.Size(306, 33);
		plFeedAds.TabIndex = 200;
		plFeedAds.Visible = false;
		label12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(132, 6);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(24, 16);
		label12.TabIndex = 32;
		label12.Text = "ba\u0300i";
		label13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(4, 6);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(73, 16);
		label13.TabIndex = 32;
		label13.Text = "Lươ\u0301t tô\u0301i đa:";
		AA814F05.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		AA814F05.Location = new System.Drawing.Point(78, 4);
		AA814F05.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AA814F05.Name = "nudFeedAdsLuotToiDa";
		AA814F05.Size = new System.Drawing.Size(54, 23);
		AA814F05.TabIndex = 1;
		AA814F05.Value = new decimal(new int[4] { 500, 0, 0, 0 });
		C4331F2A.AutoSize = true;
		C4331F2A.Cursor = System.Windows.Forms.Cursors.Hand;
		C4331F2A.Location = new System.Drawing.Point(381, 339);
		C4331F2A.Name = "ckbFeedAds";
		C4331F2A.Size = new System.Drawing.Size(167, 20);
		C4331F2A.TabIndex = 201;
		C4331F2A.Text = "Chi\u0309 tương ta\u0301c vơ\u0301i ba\u0300i ads";
		C4331F2A.UseVisualStyleBackColor = true;
		C4331F2A.Visible = false;
		C4331F2A.CheckedChanged += new System.EventHandler(C4331F2A_CheckedChanged);
		ckbClickXemThem.AutoSize = true;
		ckbClickXemThem.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbClickXemThem.Location = new System.Drawing.Point(30, 166);
		ckbClickXemThem.Name = "ckbClickXemThem";
		ckbClickXemThem.Size = new System.Drawing.Size(112, 20);
		ckbClickXemThem.TabIndex = 203;
		ckbClickXemThem.Text = "Click See more";
		ckbClickXemThem.UseVisualStyleBackColor = true;
		ckbClickXemThem.CheckedChanged += new System.EventHandler(A53CAE9D);
		C10FF5AD.AutoSize = true;
		C10FF5AD.Location = new System.Drawing.Point(3, 6);
		C10FF5AD.Name = "label18";
		C10FF5AD.Size = new System.Drawing.Size(92, 16);
		C10FF5AD.TabIndex = 41;
		C10FF5AD.Text = "Delay time (s):";
		label17.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(163, 6);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(29, 16);
		label17.TabIndex = 43;
		label17.Text = ">";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudDelayXemThemFrom.Location = new System.Drawing.Point(101, 4);
		nudDelayXemThemFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemThemFrom.Name = "nudDelayXemThemFrom";
		nudDelayXemThemFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayXemThemFrom.TabIndex = 39;
		nudDelayXemThemTo.Location = new System.Drawing.Point(198, 4);
		nudDelayXemThemTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemThemTo.Name = "nudDelayXemThemTo";
		nudDelayXemThemTo.Size = new System.Drawing.Size(56, 23);
		nudDelayXemThemTo.TabIndex = 40;
		plClickXemThem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plClickXemThem.Controls.Add(nudDelayXemThemTo);
		plClickXemThem.Controls.Add(nudDelayXemThemFrom);
		plClickXemThem.Controls.Add(label17);
		plClickXemThem.Controls.Add(C10FF5AD);
		plClickXemThem.Location = new System.Drawing.Point(30, 188);
		plClickXemThem.Name = "plClickXemThem";
		plClickXemThem.Size = new System.Drawing.Size(262, 33);
		plClickXemThem.TabIndex = 205;
		ckbFeedGroup.AutoSize = true;
		ckbFeedGroup.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFeedGroup.Location = new System.Drawing.Point(381, 51);
		ckbFeedGroup.Name = "ckbFeedGroup";
		ckbFeedGroup.Size = new System.Drawing.Size(257, 20);
		ckbFeedGroup.TabIndex = 196;
		ckbFeedGroup.Text = "Chi\u0309 tương ta\u0301c vơ\u0301i ba\u0300i viê\u0301t cu\u0309a group sau:";
		ckbFeedGroup.UseVisualStyleBackColor = true;
		ckbFeedGroup.Visible = false;
		ckbFeedGroup.CheckedChanged += new System.EventHandler(EE167004);
		DCA019A9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		DCA019A9.Location = new System.Drawing.Point(234, 1);
		DCA019A9.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		DCA019A9.Name = "nudFeedGroupLuotToiDa";
		DCA019A9.Size = new System.Drawing.Size(42, 23);
		DCA019A9.TabIndex = 1;
		DCA019A9.Value = new decimal(new int[4] { 50, 0, 0, 0 });
		label15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(161, 5);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(73, 16);
		label15.TabIndex = 32;
		label15.Text = "Lươ\u0301t tô\u0301i đa:";
		D01F0CAE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D01F0CAE.AutoSize = true;
		D01F0CAE.Location = new System.Drawing.Point(276, 5);
		D01F0CAE.Name = "label14";
		D01F0CAE.Size = new System.Drawing.Size(24, 16);
		D01F0CAE.TabIndex = 32;
		D01F0CAE.Text = "ba\u0300i";
		lblIdNhom.AutoSize = true;
		lblIdNhom.Location = new System.Drawing.Point(3, 5);
		lblIdNhom.Name = "lblIdNhom";
		lblIdNhom.Size = new System.Drawing.Size(143, 16);
		lblIdNhom.TabIndex = 0;
		lblIdNhom.Text = "Danh sa\u0301ch Id nho\u0301m (0):";
		txtIdNhom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIdNhom.Location = new System.Drawing.Point(7, 25);
		txtIdNhom.Name = "txtIdNhom";
		txtIdNhom.Size = new System.Drawing.Size(291, 55);
		txtIdNhom.TabIndex = 0;
		txtIdNhom.Text = "";
		txtIdNhom.WordWrap = false;
		txtIdNhom.TextChanged += new System.EventHandler(txtIdNhom_TextChanged);
		plFeedGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plFeedGroup.Controls.Add(txtIdNhom);
		plFeedGroup.Controls.Add(lblIdNhom);
		plFeedGroup.Controls.Add(D01F0CAE);
		plFeedGroup.Controls.Add(label15);
		plFeedGroup.Controls.Add(DCA019A9);
		plFeedGroup.Location = new System.Drawing.Point(381, 74);
		plFeedGroup.Name = "plFeedGroup";
		plFeedGroup.Size = new System.Drawing.Size(306, 86);
		plFeedGroup.TabIndex = 195;
		plFeedGroup.Visible = false;
		ckbClickXemAnh.AutoSize = true;
		ckbClickXemAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbClickXemAnh.Location = new System.Drawing.Point(381, 166);
		ckbClickXemAnh.Name = "ckbClickXemAnh";
		ckbClickXemAnh.Size = new System.Drawing.Size(88, 20);
		ckbClickXemAnh.TabIndex = 202;
		ckbClickXemAnh.Text = "Click Photo";
		ckbClickXemAnh.UseVisualStyleBackColor = true;
		ckbClickXemAnh.CheckedChanged += new System.EventHandler(CA8EF3A5);
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(3, 6);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(92, 16);
		label16.TabIndex = 41;
		label16.Text = "Delay time (s):";
		label11.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(163, 6);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(29, 16);
		label11.TabIndex = 43;
		label11.Text = ">";
		label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudDelayXemAnhFrom.Location = new System.Drawing.Point(101, 4);
		nudDelayXemAnhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemAnhFrom.Name = "nudDelayXemAnhFrom";
		nudDelayXemAnhFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayXemAnhFrom.TabIndex = 39;
		nudDelayXemAnhTo.Location = new System.Drawing.Point(198, 4);
		nudDelayXemAnhTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemAnhTo.Name = "nudDelayXemAnhTo";
		nudDelayXemAnhTo.Size = new System.Drawing.Size(56, 23);
		nudDelayXemAnhTo.TabIndex = 40;
		plClickXemAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plClickXemAnh.Controls.Add(nudDelayXemAnhTo);
		plClickXemAnh.Controls.Add(nudDelayXemAnhFrom);
		plClickXemAnh.Controls.Add(label11);
		plClickXemAnh.Controls.Add(label16);
		plClickXemAnh.Location = new System.Drawing.Point(381, 188);
		plClickXemAnh.Name = "plClickXemAnh";
		plClickXemAnh.Size = new System.Drawing.Size(306, 33);
		plClickXemAnh.TabIndex = 204;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(719, 462);
		base.Controls.Add(E611971B);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBaiVietNewsfeed3";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBaiVietNewsfeed3_Load);
		A29FE597.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		E611971B.ResumeLayout(false);
		E611971B.PerformLayout();
		panel2.ResumeLayout(false);
		A4343289.ResumeLayout(false);
		B01EA699.ResumeLayout(false);
		B01EA699.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)B5B93127).EndInit();
		((System.ComponentModel.ISupportInitialize)B5B158BE).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)D53FDCBE).EndInit();
		bunifuCards1.ResumeLayout(false);
		plDieuKien.ResumeLayout(false);
		plDieuKien.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudLuotToiDa).EndInit();
		plFeedAds.ResumeLayout(false);
		plFeedAds.PerformLayout();
		((System.ComponentModel.ISupportInitialize)AA814F05).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemTo).EndInit();
		plClickXemThem.ResumeLayout(false);
		plClickXemThem.PerformLayout();
		((System.ComponentModel.ISupportInitialize)DCA019A9).EndInit();
		plFeedGroup.ResumeLayout(false);
		plFeedGroup.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayXemAnhFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemAnhTo).EndInit();
		plClickXemAnh.ResumeLayout(false);
		plClickXemAnh.PerformLayout();
		ResumeLayout(false);
	}
}
