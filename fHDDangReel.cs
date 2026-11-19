using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDangReel : Form
{
	internal ucTuongTacReel EDB5A0B2;

	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string D2B6002E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer F9968A8E = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button C6BF323C;

	internal PictureBox C6285A34;

	internal BunifuCustomLabel DF8DC3A4;

	internal CheckBox F482C702;

	internal Panel plVanBan;

	internal Label label8;

	internal Label F89D6EA2;

	internal RichTextBox txtNoiDung;

	internal Label label20;

	internal Panel pnlTopAccent;

	internal NumericUpDown nudKhoangCachTo;

	internal NumericUpDown nudKhoangCachFrom;

	internal Label label17;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal Label label16;

	internal Label label15;

	internal CheckBox ckbXoaNguyenLieuDaDung;

	internal LinkLabel linkLabel1;

	internal TextBox txtPathAnh;

	internal Label label3;

	internal NumericUpDown nudTimeOutLoadVideo;

	internal Label label5;

	internal Label label4;

	internal CheckBox ckbHashtag;

	internal Panel plHashtag;

	internal RichTextBox FAA5379B;

	internal Label lblHashtag;

	internal Label label6;

	internal NumericUpDown A91C9F86;

	internal NumericUpDown F017F4A2;

	internal Label label7;

	internal CheckBox ckbXoaVideoDaDang;

	internal LinkLabel lblCaiDatTuongTacReel;

	internal CheckBox D79C4A01;

	internal TextBox txtKhoNoiDung;

	internal CheckBox ckbKhoNoiDung;

	internal TextBox txtThuMucMedia;

	internal CheckBox ckbThuMucMedia;

	internal Button FA92D4B5;

	internal Label label9;

	internal ComboBox cbbTuyChonNoiDung;

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

	public fHDDangReel(string E10B7E93, string string_2 = "")
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
		string_0 = E10B7E93;
		D2B6002E = string_2;
		string aA239C = Language.GetValue(DF8DC3A4.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		EDB5A0B2 = new ucTuongTacReel(gclass4_0)
		{
			Visible = false
		};
		base.Controls.Add(EDB5A0B2);
		EDB5A0B2.smethod_0(F6165FA8: true);
		Language.CD21F0A9(this);
	}

	private void fHDDangReel_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			nudKhoangCachFrom.Value = gclass4_0.method_2("nudKhoangCachFrom", 5);
			nudKhoangCachTo.Value = gclass4_0.method_2("nudKhoangCachTo", 10);
			F482C702.Checked = gclass4_0.method_3("ckbVanBan");
			ckbXoaNguyenLieuDaDung.Checked = gclass4_0.method_3("ckbXoaNguyenLieuDaDung");
			txtNoiDung.Text = gclass4_0.BDB80B23("txtNoiDung");
			cbbTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("typeNganCach");
			ckbHashtag.Checked = gclass4_0.method_3("ckbHashtag");
			FAA5379B.Text = gclass4_0.BDB80B23("txtHashtag");
			A91C9F86.Value = gclass4_0.method_2("nudSoHashtagFrom", 1);
			F017F4A2.Value = gclass4_0.method_2("nudSoHashtagTo", 1);
			txtPathAnh.Text = gclass4_0.BDB80B23("txtPathAnh");
			ckbXoaVideoDaDang.Checked = gclass4_0.method_3("ckbXoaVideoDaDang");
			nudTimeOutLoadVideo.Value = gclass4_0.method_2("nudTimeOutLoadVideo", 300);
			D79C4A01.Checked = gclass4_0.method_3("ckbXuatLinkReel");
			ckbKhoNoiDung.Checked = gclass4_0.method_3("ckbKhoNoiDung");
			txtKhoNoiDung.Text = gclass4_0.BDB80B23("txtKhoNoiDung");
			ckbThuMucMedia.Checked = gclass4_0.method_3("ckbThuMucMedia");
			txtThuMucMedia.Text = gclass4_0.BDB80B23("txtThuMucMedia");
			Commom.AttachFolderPicker(txtPathAnh);
			Commom.AttachFolderPicker(txtKhoNoiDung);
			Commom.AttachFolderPicker(txtThuMucMedia);
		}
		catch (Exception)
		{
		}
		method_1();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { Language.GetValue("Nội dung chỉ có 1 dòng"), Language.GetValue("Nội dung có nhiều dòng") };
		Commom.smethod_23(cbbTuyChonNoiDung, list_);
	}

	private void C6BF323C_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void A73A0F2B(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
			return;
		}
		gclass4_0.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gclass4_0.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gclass4_0.method_4("nudKhoangCachFrom", nudKhoangCachFrom.Value);
		gclass4_0.method_4("nudKhoangCachTo", nudKhoangCachTo.Value);
		gclass4_0.method_4("ckbVanBan", F482C702.Checked);
		gclass4_0.method_4("ckbXoaNguyenLieuDaDung", ckbXoaNguyenLieuDaDung.Checked);
		gclass4_0.method_4("txtNoiDung", txtNoiDung.Text.Trim());
		gclass4_0.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		gclass4_0.method_4("ckbHashtag", ckbHashtag.Checked);
		gclass4_0.method_4("txtHashtag", FAA5379B.Text.Trim());
		gclass4_0.method_4("nudSoHashtagFrom", A91C9F86.Value);
		gclass4_0.method_4("nudSoHashtagTo", F017F4A2.Value);
		gclass4_0.method_4("txtPathAnh", txtPathAnh.Text.Trim());
		gclass4_0.method_4("ckbXoaVideoDaDang", ckbXoaVideoDaDang.Checked);
		gclass4_0.method_4("nudTimeOutLoadVideo", nudTimeOutLoadVideo.Value);
		gclass4_0.method_4("ckbXuatLinkReel", D79C4A01.Checked);
		gclass4_0.method_4("ckbThuMucMedia", ckbThuMucMedia.Checked);
		gclass4_0.method_4("txtThuMucMedia", txtThuMucMedia.Text);
		gclass4_0.method_4("ckbKhoNoiDung", ckbKhoNoiDung.Checked);
		gclass4_0.method_4("txtKhoNoiDung", txtKhoNoiDung.Text);
		string e013A = gclass4_0.ED11179C();
		if (D2B6002E == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
		{
			if (Class154.smethod_13(D2B6002E, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void CA8D933E(object sender, EventArgs e)
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

	private void method_1()
	{
		F482C702_CheckedChanged(null, null);
		method_2(null, null);
		ckbHashtag_CheckedChanged(null, null);
		D79C4A01_CheckedChanged(null, null);
		FFB4302D(null, null);
		ckbThuMucMedia_CheckedChanged(null, null);
	}

	private void F482C702_CheckedChanged(object sender, EventArgs e)
	{
		plVanBan.Enabled = F482C702.Checked;
	}

	private void F8AD7799(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtNoiDung, F89D6EA2, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void E5330C1E(object sender, EventArgs e)
	{
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void FA92D4B5_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtNoiDung.Focus();
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void FAA5379B_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(FAA5379B, lblHashtag);
	}

	private void ckbHashtag_CheckedChanged(object sender, EventArgs e)
	{
		plHashtag.Enabled = ckbHashtag.Checked;
	}

	private void B510C5A3(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = Commom.smethod_95() + "\\output\\LinkReel.txt";
		if (!File.Exists(text))
		{
			Commom.EF994A31(text);
		}
		Process.Start(text);
	}

	private void D79C4A01_CheckedChanged(object sender, EventArgs e)
	{
		lblCaiDatTuongTacReel.Enabled = D79C4A01.Checked;
	}

	private void FFB4302D(object sender, EventArgs e)
	{
		txtKhoNoiDung.Enabled = ckbKhoNoiDung.Checked;
	}

	private void ckbThuMucMedia_CheckedChanged(object sender, EventArgs e)
	{
		txtThuMucMedia.Enabled = ckbThuMucMedia.Checked;
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtNoiDung, F89D6EA2, cbbTuyChonNoiDung.SelectedIndex);
	}

	protected override void Dispose(bool A6A2183C)
	{
		if (A6A2183C && F9968A8E != null)
		{
			F9968A8E.Dispose();
		}
		base.Dispose(A6A2183C);
	}

	private void InitializeComponent()
	{
		F9968A8E = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDangReel));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F9968A8E);
		DF8DC3A4 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(F9968A8E);
		pnlHeader = new System.Windows.Forms.Panel();
		C6BF323C = new System.Windows.Forms.Button();
		C6285A34 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		txtThuMucMedia = new System.Windows.Forms.TextBox();
		txtKhoNoiDung = new System.Windows.Forms.TextBox();
		txtPathAnh = new System.Windows.Forms.TextBox();
		label20 = new System.Windows.Forms.Label();
		nudKhoangCachTo = new System.Windows.Forms.NumericUpDown();
		label3 = new System.Windows.Forms.Label();
		nudKhoangCachFrom = new System.Windows.Forms.NumericUpDown();
		ckbXoaVideoDaDang = new System.Windows.Forms.CheckBox();
		label17 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudTimeOutLoadVideo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		label5 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		plVanBan = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		linkLabel1 = new System.Windows.Forms.LinkLabel();
		FA92D4B5 = new System.Windows.Forms.Button();
		label9 = new System.Windows.Forms.Label();
		txtNoiDung = new System.Windows.Forms.RichTextBox();
		label8 = new System.Windows.Forms.Label();
		F89D6EA2 = new System.Windows.Forms.Label();
		ckbXoaNguyenLieuDaDung = new System.Windows.Forms.CheckBox();
		ckbHashtag = new System.Windows.Forms.CheckBox();
		plHashtag = new System.Windows.Forms.Panel();
		A91C9F86 = new System.Windows.Forms.NumericUpDown();
		F017F4A2 = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		FAA5379B = new System.Windows.Forms.RichTextBox();
		lblHashtag = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		ckbThuMucMedia = new System.Windows.Forms.CheckBox();
		btnAdd = new System.Windows.Forms.Button();
		ckbKhoNoiDung = new System.Windows.Forms.CheckBox();
		F482C702 = new System.Windows.Forms.CheckBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		lblCaiDatTuongTacReel = new System.Windows.Forms.LinkLabel();
		D79C4A01 = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)C6285A34).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeOutLoadVideo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		plVanBan.SuspendLayout();
		plHashtag.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)A91C9F86).BeginInit();
		((System.ComponentModel.ISupportInitialize)F017F4A2).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = DF8DC3A4;
		bunifuDragControl_0.Vertical = true;
		DF8DC3A4.BackColor = System.Drawing.Color.Transparent;
		DF8DC3A4.Cursor = System.Windows.Forms.Cursors.SizeAll;
		DF8DC3A4.Dock = System.Windows.Forms.DockStyle.Fill;
		DF8DC3A4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DF8DC3A4.ForeColor = System.Drawing.Color.Black;
		DF8DC3A4.Location = new System.Drawing.Point(0, 0);
		DF8DC3A4.Name = "bunifuCustomLabel1";
		DF8DC3A4.Size = new System.Drawing.Size(593, 31);
		DF8DC3A4.TabIndex = 12;
		DF8DC3A4.Text = "Cấu hình Đăng Reel";
		DF8DC3A4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(C6BF323C);
		pnlHeader.Controls.Add(C6285A34);
		pnlHeader.Controls.Add(DF8DC3A4);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(593, 31);
		pnlHeader.TabIndex = 9;
		C6BF323C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		C6BF323C.Cursor = System.Windows.Forms.Cursors.Hand;
		C6BF323C.FlatAppearance.BorderSize = 0;
		C6BF323C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C6BF323C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C6BF323C.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		C6BF323C.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		C6BF323C.Text = iconClose == null ? "✕" : "";
		C6BF323C.Location = new System.Drawing.Point(562, 1);
		C6BF323C.Name = "button1";
		C6BF323C.Size = new System.Drawing.Size(30, 30);
		C6BF323C.TabIndex = 0;
		C6BF323C.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		C6BF323C.UseVisualStyleBackColor = true;
		C6BF323C.Click += new System.EventHandler(C6BF323C_Click);
		C6285A34.Cursor = System.Windows.Forms.Cursors.Default;
		C6285A34.Image = Class155.DD225F0D;
		C6285A34.Location = new System.Drawing.Point(3, 2);
		C6285A34.Name = "pictureBox1";
		C6285A34.Size = new System.Drawing.Size(34, 27);
		C6285A34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		C6285A34.TabIndex = 76;
		C6285A34.TabStop = false;
		C6285A34.Click += new System.EventHandler(E5330C1E);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Controls.Add(txtThuMucMedia);
		panel1.Controls.Add(txtKhoNoiDung);
		panel1.Controls.Add(txtPathAnh);
		panel1.Controls.Add(label20);
		panel1.Controls.Add(nudKhoangCachTo);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(nudKhoangCachFrom);
		panel1.Controls.Add(ckbXoaVideoDaDang);
		panel1.Controls.Add(label17);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(nudTimeOutLoadVideo);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(label16);
		panel1.Controls.Add(label15);
		panel1.Controls.Add(plVanBan);
		panel1.Controls.Add(ckbThuMucMedia);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(ckbKhoNoiDung);
		panel1.Controls.Add(F482C702);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(lblCaiDatTuongTacReel);
		panel1.Controls.Add(D79C4A01);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(596, 701);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		txtThuMucMedia.Location = new System.Drawing.Point(168, 772);
		txtThuMucMedia.Name = "txtThuMucMedia";
		txtThuMucMedia.Size = new System.Drawing.Size(393, 23);
		txtThuMucMedia.TabIndex = 1;
		txtKhoNoiDung.Location = new System.Drawing.Point(168, 801);
		txtKhoNoiDung.Name = "txtKhoNoiDung";
		txtKhoNoiDung.Size = new System.Drawing.Size(393, 23);
		txtKhoNoiDung.TabIndex = 1;
		txtPathAnh.Location = new System.Drawing.Point(168, 136);
		txtPathAnh.Name = "txtPathAnh";
		txtPathAnh.Size = new System.Drawing.Size(260, 23);
		txtPathAnh.TabIndex = 1;
		label20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(222, 109);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(29, 16);
		label20.TabIndex = 42;
		label20.Text = ">";
		label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudKhoangCachTo.Location = new System.Drawing.Point(253, 107);
		nudKhoangCachTo.Name = "nudKhoangCachTo";
		nudKhoangCachTo.Size = new System.Drawing.Size(51, 23);
		nudKhoangCachTo.TabIndex = 41;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(30, 139);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(97, 16);
		label3.TabIndex = 0;
		label3.Text = "Thư mu\u0323c video:";
		nudKhoangCachFrom.Location = new System.Drawing.Point(168, 107);
		nudKhoangCachFrom.Name = "nudKhoangCachFrom";
		nudKhoangCachFrom.Size = new System.Drawing.Size(51, 23);
		nudKhoangCachFrom.TabIndex = 40;
		ckbXoaVideoDaDang.AutoSize = true;
		ckbXoaVideoDaDang.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaVideoDaDang.Location = new System.Drawing.Point(436, 138);
		ckbXoaVideoDaDang.Name = "ckbXoaVideoDaDang";
		ckbXoaVideoDaDang.Size = new System.Drawing.Size(132, 20);
		ckbXoaVideoDaDang.TabIndex = 32;
		ckbXoaVideoDaDang.Text = "Xóa video đã đăng";
		ckbXoaVideoDaDang.UseVisualStyleBackColor = true;
		ckbXoaVideoDaDang.CheckedChanged += new System.EventHandler(F482C702_CheckedChanged);
		label17.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(222, 83);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(29, 16);
		label17.TabIndex = 38;
		label17.Text = ">";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongTo.Location = new System.Drawing.Point(253, 78);
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(51, 23);
		nudSoLuongTo.TabIndex = 37;
		nudTimeOutLoadVideo.Location = new System.Drawing.Point(168, 625);
		nudTimeOutLoadVideo.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		nudTimeOutLoadVideo.Name = "nudTimeOutLoadVideo";
		nudTimeOutLoadVideo.Size = new System.Drawing.Size(51, 23);
		nudTimeOutLoadVideo.TabIndex = 36;
		nudSoLuongFrom.Location = new System.Drawing.Point(168, 78);
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(51, 23);
		nudSoLuongFrom.TabIndex = 36;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(225, 627);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(30, 16);
		label5.TabIndex = 34;
		label5.Text = "giây";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(30, 627);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(132, 16);
		label4.TabIndex = 34;
		label4.Text = "Chờ load video tối đa:";
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(30, 109);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(136, 16);
		label16.TabIndex = 35;
		label16.Text = "Khoảng cách đăng (s):";
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(30, 80);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(89, 16);
		label15.TabIndex = 34;
		label15.Text = "Số lượng reel:";
		plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plVanBan.Controls.Add(cbbTuyChonNoiDung);
		plVanBan.Controls.Add(linkLabel1);
		plVanBan.Controls.Add(FA92D4B5);
		plVanBan.Controls.Add(label9);
		plVanBan.Controls.Add(txtNoiDung);
		plVanBan.Controls.Add(label8);
		plVanBan.Controls.Add(F89D6EA2);
		plVanBan.Controls.Add(ckbXoaNguyenLieuDaDung);
		plVanBan.Controls.Add(ckbHashtag);
		plVanBan.Controls.Add(plHashtag);
		plVanBan.Location = new System.Drawing.Point(47, 186);
		plVanBan.Name = "plVanBan";
		plVanBan.Size = new System.Drawing.Size(514, 434);
		plVanBan.TabIndex = 33;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.DropDownWidth = 180;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(325, 197);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(154, 24);
		cbbTuyChonNoiDung.TabIndex = 196;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		linkLabel1.AutoSize = true;
		linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
		linkLabel1.Location = new System.Drawing.Point(154, 197);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new System.Drawing.Size(81, 16);
		linkLabel1.TabIndex = 195;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "Random icon";
		linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		FA92D4B5.Cursor = System.Windows.Forms.Cursors.Help;
		FA92D4B5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FA92D4B5.Location = new System.Drawing.Point(485, 197);
		FA92D4B5.Name = "button2";
		FA92D4B5.Size = new System.Drawing.Size(21, 24);
		FA92D4B5.TabIndex = 194;
		FA92D4B5.Text = "?";
		FA92D4B5.UseVisualStyleBackColor = true;
		FA92D4B5.Click += new System.EventHandler(FA92D4B5_Click);
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(261, 200);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(64, 16);
		label9.TabIndex = 35;
		label9.Text = "Tùy chọn:";
		txtNoiDung.Location = new System.Drawing.Point(7, 23);
		txtNoiDung.Name = "txtNoiDung";
		txtNoiDung.Size = new System.Drawing.Size(499, 172);
		txtNoiDung.TabIndex = 34;
		txtNoiDung.Text = "";
		txtNoiDung.WordWrap = false;
		txtNoiDung.TextChanged += new System.EventHandler(F8AD7799);
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(4, 197);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(143, 16);
		label8.TabIndex = 0;
		label8.Text = "(Spin nội dung {a|b|c})";
		F89D6EA2.AutoSize = true;
		F89D6EA2.Location = new System.Drawing.Point(3, 4);
		F89D6EA2.Name = "lblNoiDung";
		F89D6EA2.Size = new System.Drawing.Size(145, 16);
		F89D6EA2.TabIndex = 0;
		F89D6EA2.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
		ckbXoaNguyenLieuDaDung.AutoSize = true;
		ckbXoaNguyenLieuDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaNguyenLieuDaDung.Location = new System.Drawing.Point(7, 220);
		ckbXoaNguyenLieuDaDung.Name = "ckbXoaNguyenLieuDaDung";
		ckbXoaNguyenLieuDaDung.Size = new System.Drawing.Size(151, 20);
		ckbXoaNguyenLieuDaDung.TabIndex = 32;
		ckbXoaNguyenLieuDaDung.Text = "Xóa nội dung đã đăng";
		ckbXoaNguyenLieuDaDung.UseVisualStyleBackColor = true;
		ckbXoaNguyenLieuDaDung.CheckedChanged += new System.EventHandler(F482C702_CheckedChanged);
		ckbHashtag.AutoSize = true;
		ckbHashtag.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHashtag.Location = new System.Drawing.Point(7, 246);
		ckbHashtag.Name = "ckbHashtag";
		ckbHashtag.Size = new System.Drawing.Size(101, 20);
		ckbHashtag.TabIndex = 32;
		ckbHashtag.Text = "Kèm Hashtag";
		ckbHashtag.UseVisualStyleBackColor = true;
		ckbHashtag.CheckedChanged += new System.EventHandler(ckbHashtag_CheckedChanged);
		plHashtag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plHashtag.Controls.Add(A91C9F86);
		plHashtag.Controls.Add(F017F4A2);
		plHashtag.Controls.Add(label7);
		plHashtag.Controls.Add(FAA5379B);
		plHashtag.Controls.Add(lblHashtag);
		plHashtag.Controls.Add(label6);
		plHashtag.Location = new System.Drawing.Point(19, 271);
		plHashtag.Name = "plHashtag";
		plHashtag.Size = new System.Drawing.Size(487, 156);
		plHashtag.TabIndex = 33;
		A91C9F86.Location = new System.Drawing.Point(170, 127);
		A91C9F86.Name = "nudSoHashtagFrom";
		A91C9F86.Size = new System.Drawing.Size(51, 23);
		A91C9F86.TabIndex = 40;
		F017F4A2.Location = new System.Drawing.Point(255, 127);
		F017F4A2.Name = "nudSoHashtagTo";
		F017F4A2.Size = new System.Drawing.Size(51, 23);
		F017F4A2.TabIndex = 41;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(224, 129);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 42;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		FAA5379B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FAA5379B.Location = new System.Drawing.Point(7, 22);
		FAA5379B.Name = "txtHashtag";
		FAA5379B.Size = new System.Drawing.Size(472, 102);
		FAA5379B.TabIndex = 34;
		FAA5379B.Text = "";
		FAA5379B.WordWrap = false;
		FAA5379B.TextChanged += new System.EventHandler(FAA5379B_TextChanged);
		lblHashtag.AutoSize = true;
		lblHashtag.Location = new System.Drawing.Point(3, 3);
		lblHashtag.Name = "lblHashtag";
		lblHashtag.Size = new System.Drawing.Size(141, 16);
		lblHashtag.TabIndex = 0;
		lblHashtag.Text = "Danh sa\u0301ch hashtag (0):";
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(4, 129);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(166, 16);
		label6.TabIndex = 35;
		label6.Text = "Số lượng hashtag/nội dung:";
		ckbThuMucMedia.AutoSize = true;
		ckbThuMucMedia.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThuMucMedia.Location = new System.Drawing.Point(33, 774);
		ckbThuMucMedia.Name = "ckbThuMucMedia";
		ckbThuMucMedia.Size = new System.Drawing.Size(121, 20);
		ckbThuMucMedia.TabIndex = 32;
		ckbThuMucMedia.Text = "Thư mục media:";
		ckbThuMucMedia.UseVisualStyleBackColor = true;
		ckbThuMucMedia.CheckedChanged += new System.EventHandler(ckbThuMucMedia_CheckedChanged);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(205, 659);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(A73A0F2B);
		ckbKhoNoiDung.AutoSize = true;
		ckbKhoNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbKhoNoiDung.Location = new System.Drawing.Point(33, 803);
		ckbKhoNoiDung.Name = "ckbKhoNoiDung";
		ckbKhoNoiDung.Size = new System.Drawing.Size(140, 20);
		ckbKhoNoiDung.TabIndex = 32;
		ckbKhoNoiDung.Text = "Kho video/nội dung:";
		ckbKhoNoiDung.UseVisualStyleBackColor = true;
		ckbKhoNoiDung.CheckedChanged += new System.EventHandler(FFB4302D);
		F482C702.AutoSize = true;
		F482C702.Cursor = System.Windows.Forms.Cursors.Hand;
		F482C702.Location = new System.Drawing.Point(33, 164);
		F482C702.Name = "ckbVanBan";
		F482C702.Size = new System.Drawing.Size(113, 20);
		F482C702.TabIndex = 32;
		F482C702.Text = "Nội dung mô tả";
		F482C702.UseVisualStyleBackColor = true;
		F482C702.CheckedChanged += new System.EventHandler(F482C702_CheckedChanged);
		txtTenHanhDong.Location = new System.Drawing.Point(168, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(174, 23);
		txtTenHanhDong.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(30, 52);
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
		btnCancel.Location = new System.Drawing.Point(304, 659);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(CA8D933E);
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
		bunifuCards1.Size = new System.Drawing.Size(593, 37);
		bunifuCards1.TabIndex = 28;
		lblCaiDatTuongTacReel.AutoSize = true;
		lblCaiDatTuongTacReel.Cursor = System.Windows.Forms.Cursors.Hand;
		lblCaiDatTuongTacReel.Location = new System.Drawing.Point(492, 627);
		lblCaiDatTuongTacReel.Name = "lblCaiDatTuongTacReel";
		lblCaiDatTuongTacReel.Size = new System.Drawing.Size(73, 16);
		lblCaiDatTuongTacReel.TabIndex = 184;
		lblCaiDatTuongTacReel.TabStop = true;
		lblCaiDatTuongTacReel.Text = "File kê\u0301t qua\u0309";
		lblCaiDatTuongTacReel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(B510C5A3);
		D79C4A01.AutoSize = true;
		D79C4A01.Cursor = System.Windows.Forms.Cursors.Hand;
		D79C4A01.Location = new System.Drawing.Point(316, 626);
		D79C4A01.Name = "ckbXuatLinkReel";
		D79C4A01.Size = new System.Drawing.Size(177, 20);
		D79C4A01.TabIndex = 32;
		D79C4A01.Text = "Xuâ\u0301t link reel sau khi đăng";
		D79C4A01.UseVisualStyleBackColor = true;
		D79C4A01.CheckedChanged += new System.EventHandler(D79C4A01_CheckedChanged);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(596, 701);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDangReel";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDDangReel_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)C6285A34).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeOutLoadVideo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		plVanBan.ResumeLayout(false);
		plVanBan.PerformLayout();
		plHashtag.ResumeLayout(false);
		plHashtag.PerformLayout();
		((System.ComponentModel.ISupportInitialize)A91C9F86).EndInit();
		((System.ComponentModel.ISupportInitialize)F017F4A2).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
