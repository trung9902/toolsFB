using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTuongTacProfile : Form
{
	internal GClass4 gclass4_0;

	internal List<CheckBox> list_0;

	internal IContainer icontainer_0 = null;

	internal Panel plCommentText;

	internal CheckBox F68FB239;

	internal Button btnHuongDanNhapNoiDung;

	internal LinkLabel linkLabel1;

	internal Panel C70B3E9F;

	internal RadioButton rbCommentTheoThuTu;

	internal RadioButton rbCommentNgauNhien;

	internal Label label13;

	internal Label label8;

	internal RichTextBox txtTTPComment;

	internal Label label11;

	internal Label D004D0A4;

	internal Panel DE38ED0E;

	internal TextBox F7AA6C22;

	internal Label label12;

	internal CheckBox ckbTTPCommentImage;

	internal CheckBox ckbTTPCommentText;

	internal CheckBox ckbTTPShareWall;

	internal CheckBox CB869B9F;

	internal ComboBox cbbTTPTuyChonNoiDung;

	internal Panel B70ED29E;

	internal CheckBox D116C198;

	internal CheckBox ckbBuon;

	internal CheckBox ckbWow;

	internal CheckBox ckbHaha;

	internal CheckBox D737593D;

	internal CheckBox ckbTym;

	internal CheckBox A3B74338;

	internal Panel panel7;

	internal RadioButton radioButton3;

	internal RadioButton radioButton4;

	internal Label label26;

	internal Button btnSave;

	internal Button EE332E9F;

	internal Label label19;

	internal NumericUpDown nudTTPDelayTo;

	internal NumericUpDown nudTTPSoLuongTo;

	internal NumericUpDown nudTTPDelayFrom;

	internal NumericUpDown ABB9EE33;

	internal Label label3;

	internal Label label5;

	internal Label D736F623;

	internal Panel panel1;

	internal BunifuCards CC33791F;

	internal Panel EA251B9C;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl E707E8BB;

	public fTuongTacProfile(GClass4 gclass4_1, string customTitle = "")
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		gclass4_0 = gclass4_1;
		if (!string.IsNullOrEmpty(customTitle))
		{
			bunifuCustomLabel1.Text = customTitle;
		}
		list_0 = new List<CheckBox> { A3B74338, ckbTym, D737593D, ckbHaha, ckbWow, ckbBuon, D116C198 };
		A9051C07();
		F8B1F7A8();
		SetupModernFeatures();
	}

	private void SetupModernFeatures()
	{
		try
		{
			Panel pnlTopAccent = new Panel();
			pnlTopAccent.Dock = DockStyle.Top;
			pnlTopAccent.Height = 4;
			pnlTopAccent.BackColor = Color.FromArgb(37, 99, 235);
			Controls.Add(pnlTopAccent);
			pnlTopAccent.BringToFront();

			Commom.AttachFolderPicker(F7AA6C22);
		}
		catch { }
	}

	private void txtTTPComment_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTTPComment, D004D0A4, cbbTTPTuyChonNoiDung.SelectedIndex);
	}

	private void A9051C07()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTTPTuyChonNoiDung, list);
	}

	private void F2A76137(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (cbbTTPTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtTTPComment.Focus();
	}

	private void B807D329(object sender, EventArgs e)
	{
		B70ED29E.Enabled = CB869B9F.Checked;
	}

	private void ckbTTPCommentText_CheckedChanged(object sender, EventArgs e)
	{
		plCommentText.Enabled = ckbTTPCommentText.Checked;
	}

	private void ckbTTPCommentImage_CheckedChanged(object sender, EventArgs e)
	{
		DE38ED0E.Enabled = ckbTTPCommentImage.Checked;
	}

	private void BB859CAE(object sender, EventArgs e)
	{
		Close();
	}

	private void A627CD07(object sender, EventArgs e)
	{
		F8B1F7A8();
		B807D329(null, null);
		ckbTTPCommentText_CheckedChanged(null, null);
		ckbTTPCommentImage_CheckedChanged(null, null);
	}

	private void C42DEB14(object sender, EventArgs e)
	{
		if (ckbTTPCommentImage.Checked && !string.IsNullOrWhiteSpace(F7AA6C22.Text))
		{
			if (!Commom.ValidateMediaFolder(F7AA6C22.Text.Trim(), out int count, out string msg))
			{
				MsBoxHelper.Show(Language.GetValue(msg), 3);
				return;
			}
		}
		method_0();
		Close();
	}

	private void F8B1F7A8()
	{
		ABB9EE33.Value = gclass4_0.method_2("nudTTPSoLuongFrom", 1);
		nudTTPSoLuongTo.Value = gclass4_0.method_2("nudTTPSoLuongTo", 1);
		nudTTPDelayFrom.Value = gclass4_0.method_2("nudTTPDelayFrom", 3);
		nudTTPDelayTo.Value = gclass4_0.method_2("nudTTPDelayTo", 5);
		CB869B9F.Checked = gclass4_0.method_3("ckbTTPInteract");
		string text = gclass4_0.BDB80B23("TTPtypeReaction", "0");
		for (int i = 0; i < list_0.Count; i++)
		{
			list_0[i].Checked = text.Split('|').Contains(i.ToString());
		}
		ckbTTPCommentText.Checked = gclass4_0.method_3("ckbTTPCommentText");
		txtTTPComment.Text = gclass4_0.BDB80B23("txtTTPComment");
		cbbTTPTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("cbbTTPTuyChonNoiDung");
		ckbTTPCommentImage.Checked = gclass4_0.method_3("ckbTTPCommentImage");
		F7AA6C22.Text = gclass4_0.BDB80B23("txtTTPImagePath");
		ckbTTPShareWall.Checked = gclass4_0.method_3("ckbTTPShareWall");
		int typeComment = gclass4_0.method_2("typeComment", 0);
		if (typeComment == 0)
		{
			rbCommentNgauNhien.Checked = true;
		}
		else
		{
			rbCommentTheoThuTu.Checked = true;
		}
		F68FB239.Checked = gclass4_0.method_3("ckbAutoDeleteComment", false);
	}

	private void method_0()
	{
		gclass4_0.method_4("nudTTPSoLuongFrom", ABB9EE33.Value);
		gclass4_0.method_4("nudTTPSoLuongTo", nudTTPSoLuongTo.Value);
		gclass4_0.method_4("nudTTPDelayFrom", nudTTPDelayFrom.Value);
		gclass4_0.method_4("nudTTPDelayTo", nudTTPDelayTo.Value);
		gclass4_0.method_4("ckbTTPInteract", CB869B9F.Checked);
		string text = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text = text + i + "|";
			}
		}
		gclass4_0.method_4("TTPtypeReaction", text.TrimEnd('|'));
		gclass4_0.method_4("ckbTTPCommentText", ckbTTPCommentText.Checked);
		gclass4_0.method_4("txtTTPComment", txtTTPComment.Text);
		gclass4_0.method_4("cbbTTPTuyChonNoiDung", cbbTTPTuyChonNoiDung.SelectedIndex);
		gclass4_0.method_4("ckbTTPCommentImage", ckbTTPCommentImage.Checked);
		gclass4_0.method_4("txtTTPImagePath", F7AA6C22.Text);
		gclass4_0.method_4("ckbTTPShareWall", ckbTTPShareWall.Checked);
		gclass4_0.method_4("typeComment", rbCommentTheoThuTu.Checked ? 1 : 0);
		gclass4_0.method_4("ckbAutoDeleteComment", F68FB239.Checked);
	}

	private void cbbTTPTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTTPComment, D004D0A4, cbbTTPTuyChonNoiDung.SelectedIndex);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
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
		plCommentText = new System.Windows.Forms.Panel();
		cbbTTPTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		F68FB239 = new System.Windows.Forms.CheckBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		linkLabel1 = new System.Windows.Forms.LinkLabel();
		C70B3E9F = new System.Windows.Forms.Panel();
		rbCommentTheoThuTu = new System.Windows.Forms.RadioButton();
		rbCommentNgauNhien = new System.Windows.Forms.RadioButton();
		label13 = new System.Windows.Forms.Label();
		txtTTPComment = new System.Windows.Forms.RichTextBox();
		label11 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		D004D0A4 = new System.Windows.Forms.Label();
		DE38ED0E = new System.Windows.Forms.Panel();
		F7AA6C22 = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		ckbTTPCommentImage = new System.Windows.Forms.CheckBox();
		ckbTTPCommentText = new System.Windows.Forms.CheckBox();
		ckbTTPShareWall = new System.Windows.Forms.CheckBox();
		CB869B9F = new System.Windows.Forms.CheckBox();
		B70ED29E = new System.Windows.Forms.Panel();
		D116C198 = new System.Windows.Forms.CheckBox();
		ckbBuon = new System.Windows.Forms.CheckBox();
		ckbWow = new System.Windows.Forms.CheckBox();
		ckbHaha = new System.Windows.Forms.CheckBox();
		D737593D = new System.Windows.Forms.CheckBox();
		ckbTym = new System.Windows.Forms.CheckBox();
		A3B74338 = new System.Windows.Forms.CheckBox();
		panel7 = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		radioButton4 = new System.Windows.Forms.RadioButton();
		label26 = new System.Windows.Forms.Label();
		btnSave = new System.Windows.Forms.Button();
		EE332E9F = new System.Windows.Forms.Button();
		label19 = new System.Windows.Forms.Label();
		nudTTPDelayTo = new System.Windows.Forms.NumericUpDown();
		nudTTPSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudTTPDelayFrom = new System.Windows.Forms.NumericUpDown();
		ABB9EE33 = new System.Windows.Forms.NumericUpDown();
		label3 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		D736F623 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		CC33791F = new Bunifu.Framework.UI.BunifuCards();
		EA251B9C = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		E707E8BB = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		plCommentText.SuspendLayout();
		C70B3E9F.SuspendLayout();
		DE38ED0E.SuspendLayout();
		B70ED29E.SuspendLayout();
		panel7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTTPDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTTPSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTTPDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)ABB9EE33).BeginInit();
		panel1.SuspendLayout();
		CC33791F.SuspendLayout();
		EA251B9C.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		plCommentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCommentText.Controls.Add(cbbTTPTuyChonNoiDung);
		plCommentText.Controls.Add(F68FB239);
		plCommentText.Controls.Add(btnHuongDanNhapNoiDung);
		plCommentText.Controls.Add(linkLabel1);
		plCommentText.Controls.Add(C70B3E9F);
		plCommentText.Controls.Add(label13);
		plCommentText.Controls.Add(txtTTPComment);
		plCommentText.Controls.Add(label11);
		plCommentText.Controls.Add(label8);
		plCommentText.Controls.Add(D004D0A4);
		plCommentText.Location = new System.Drawing.Point(49, 188);
		plCommentText.Name = "plCommentText";
		plCommentText.Size = new System.Drawing.Size(310, 184);
		plCommentText.TabIndex = 176;
		cbbTTPTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTTPTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTTPTuyChonNoiDung.FormattingEnabled = true;
		cbbTTPTuyChonNoiDung.Location = new System.Drawing.Point(82, 153);
		cbbTTPTuyChonNoiDung.Name = "cbbTTPTuyChonNoiDung";
		cbbTTPTuyChonNoiDung.Size = new System.Drawing.Size(190, 24);
		cbbTTPTuyChonNoiDung.TabIndex = 177;
		cbbTTPTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTTPTuyChonNoiDung_SelectedIndexChanged);
		F68FB239.AutoSize = true;
		F68FB239.Cursor = System.Windows.Forms.Cursors.Hand;
		F68FB239.Location = new System.Drawing.Point(8, 182);
		F68FB239.Name = "ckbAutoDeleteComment";
		F68FB239.Size = new System.Drawing.Size(225, 20);
		F68FB239.TabIndex = 176;
		F68FB239.Text = "Tự động xóa nội dung đã bình luận";
		F68FB239.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(278, 152);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 173;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		linkLabel1.AutoSize = true;
		linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
		linkLabel1.Location = new System.Drawing.Point(223, 129);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new System.Drawing.Size(81, 16);
		linkLabel1.TabIndex = 175;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "Random icon";
		linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(F2A76137);
		C70B3E9F.Controls.Add(rbCommentTheoThuTu);
		C70B3E9F.Controls.Add(rbCommentNgauNhien);
		C70B3E9F.Location = new System.Drawing.Point(66, 397);
		C70B3E9F.Name = "panel3";
		C70B3E9F.Size = new System.Drawing.Size(200, 43);
		C70B3E9F.TabIndex = 43;
		rbCommentTheoThuTu.AutoSize = true;
		rbCommentTheoThuTu.Checked = true;
		rbCommentTheoThuTu.Cursor = System.Windows.Forms.Cursors.Hand;
		rbCommentTheoThuTu.Location = new System.Drawing.Point(3, 2);
		rbCommentTheoThuTu.Name = "rbCommentTheoThuTu";
		rbCommentTheoThuTu.Size = new System.Drawing.Size(201, 20);
		rbCommentTheoThuTu.TabIndex = 3;
		rbCommentTheoThuTu.TabStop = true;
		rbCommentTheoThuTu.Text = "Comment theo thứ tự nội dung";
		rbCommentTheoThuTu.UseVisualStyleBackColor = true;
		rbCommentNgauNhien.AutoSize = true;
		rbCommentNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
		rbCommentNgauNhien.Location = new System.Drawing.Point(3, 23);
		rbCommentNgauNhien.Name = "rbCommentNgauNhien";
		rbCommentNgauNhien.Size = new System.Drawing.Size(200, 20);
		rbCommentNgauNhien.TabIndex = 3;
		rbCommentNgauNhien.Text = "Comment ngẫu nhiên nội dung";
		rbCommentNgauNhien.UseVisualStyleBackColor = true;
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(3, 399);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(64, 16);
		label13.TabIndex = 2;
		label13.Text = "Tùy chọn:";
		txtTTPComment.Location = new System.Drawing.Point(7, 24);
		txtTTPComment.Name = "txtTTPComment";
		txtTTPComment.Size = new System.Drawing.Size(297, 102);
		txtTTPComment.TabIndex = 1;
		txtTTPComment.Text = "";
		txtTTPComment.WordWrap = false;
		txtTTPComment.TextChanged += new System.EventHandler(txtTTPComment_TextChanged);
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(5, 129);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(143, 16);
		label11.TabIndex = 0;
		label11.Text = "(Spin nội dung {a|b|c})";
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(5, 156);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 2;
		label8.Text = "Tùy chọn:";
		D004D0A4.AutoSize = true;
		D004D0A4.Location = new System.Drawing.Point(3, 4);
		D004D0A4.Name = "lblComment";
		D004D0A4.Size = new System.Drawing.Size(139, 16);
		D004D0A4.TabIndex = 0;
		D004D0A4.Text = "Nội dung bình luận (0):";
		DE38ED0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DE38ED0E.Controls.Add(F7AA6C22);
		DE38ED0E.Controls.Add(label12);
		DE38ED0E.Enabled = false;
		DE38ED0E.Location = new System.Drawing.Point(49, 399);
		DE38ED0E.Name = "plCommentImage";
		DE38ED0E.Size = new System.Drawing.Size(310, 31);
		DE38ED0E.TabIndex = 178;
		F7AA6C22.Location = new System.Drawing.Point(82, 3);
		F7AA6C22.Name = "txtTTPImagePath";
		F7AA6C22.Size = new System.Drawing.Size(222, 23);
		F7AA6C22.TabIndex = 155;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(3, 6);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(73, 16);
		label12.TabIndex = 39;
		label12.Text = "Folder ảnh:";
		ckbTTPCommentImage.AutoSize = true;
		ckbTTPCommentImage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTPCommentImage.Location = new System.Drawing.Point(31, 377);
		ckbTTPCommentImage.Name = "ckbTTPCommentImage";
		ckbTTPCommentImage.Size = new System.Drawing.Size(103, 20);
		ckbTTPCommentImage.TabIndex = 177;
		ckbTTPCommentImage.Text = "Bình luận ảnh";
		ckbTTPCommentImage.UseVisualStyleBackColor = true;
		ckbTTPCommentImage.CheckedChanged += new System.EventHandler(ckbTTPCommentImage_CheckedChanged);
		ckbTTPCommentText.AutoSize = true;
		ckbTTPCommentText.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTPCommentText.Location = new System.Drawing.Point(31, 166);
		ckbTTPCommentText.Name = "ckbTTPCommentText";
		ckbTTPCommentText.Size = new System.Drawing.Size(127, 20);
		ckbTTPCommentText.TabIndex = 174;
		ckbTTPCommentText.Text = "Bi\u0300nh luâ\u0323n văn bản";
		ckbTTPCommentText.UseVisualStyleBackColor = true;
		ckbTTPCommentText.CheckedChanged += new System.EventHandler(ckbTTPCommentText_CheckedChanged);
		ckbTTPShareWall.AutoSize = true;
		ckbTTPShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTPShareWall.Location = new System.Drawing.Point(31, 434);
		ckbTTPShareWall.Name = "ckbTTPShareWall";
		ckbTTPShareWall.Size = new System.Drawing.Size(143, 20);
		ckbTTPShareWall.TabIndex = 170;
		ckbTTPShareWall.Text = "Chia sẻ bài về tường";
		ckbTTPShareWall.UseVisualStyleBackColor = true;
		CB869B9F.AutoSize = true;
		CB869B9F.Cursor = System.Windows.Forms.Cursors.Hand;
		CB869B9F.Location = new System.Drawing.Point(31, 106);
		CB869B9F.Name = "ckbTTPInteract";
		CB869B9F.Size = new System.Drawing.Size(112, 20);
		CB869B9F.TabIndex = 169;
		CB869B9F.Text = "Bày tỏ cảm xúc";
		CB869B9F.UseVisualStyleBackColor = true;
		CB869B9F.CheckedChanged += new System.EventHandler(B807D329);
		B70ED29E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B70ED29E.Controls.Add(D116C198);
		B70ED29E.Controls.Add(ckbBuon);
		B70ED29E.Controls.Add(ckbWow);
		B70ED29E.Controls.Add(ckbHaha);
		B70ED29E.Controls.Add(D737593D);
		B70ED29E.Controls.Add(ckbTym);
		B70ED29E.Controls.Add(A3B74338);
		B70ED29E.Controls.Add(panel7);
		B70ED29E.Controls.Add(label26);
		B70ED29E.Location = new System.Drawing.Point(49, 128);
		B70ED29E.Name = "plInteract";
		B70ED29E.Size = new System.Drawing.Size(310, 33);
		B70ED29E.TabIndex = 179;
		D116C198.Cursor = System.Windows.Forms.Cursors.Hand;
		D116C198.Image = Class155.Bitmap_11;
		D116C198.Location = new System.Drawing.Point(266, 1);
		D116C198.Name = "ckbGian";
		D116C198.Size = new System.Drawing.Size(40, 30);
		D116C198.TabIndex = 179;
		D116C198.UseVisualStyleBackColor = true;
		ckbBuon.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBuon.Image = Class155.E1938320;
		ckbBuon.Location = new System.Drawing.Point(222, 1);
		ckbBuon.Name = "ckbBuon";
		ckbBuon.Size = new System.Drawing.Size(40, 30);
		ckbBuon.TabIndex = 178;
		ckbBuon.UseVisualStyleBackColor = true;
		ckbWow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWow.Image = Class155.Bitmap_181;
		ckbWow.Location = new System.Drawing.Point(178, 1);
		ckbWow.Name = "ckbWow";
		ckbWow.Size = new System.Drawing.Size(40, 30);
		ckbWow.TabIndex = 177;
		ckbWow.UseVisualStyleBackColor = true;
		ckbHaha.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHaha.Image = Class155.E982D419;
		ckbHaha.Location = new System.Drawing.Point(134, 1);
		ckbHaha.Name = "ckbHaha";
		ckbHaha.Size = new System.Drawing.Size(40, 30);
		ckbHaha.TabIndex = 176;
		ckbHaha.UseVisualStyleBackColor = true;
		D737593D.Cursor = System.Windows.Forms.Cursors.Hand;
		D737593D.Image = Class155.Bitmap_20;
		D737593D.Location = new System.Drawing.Point(90, 1);
		D737593D.Name = "ckbThuong";
		D737593D.Size = new System.Drawing.Size(40, 30);
		D737593D.TabIndex = 175;
		D737593D.UseVisualStyleBackColor = true;
		ckbTym.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTym.Image = Class155.AB95A212;
		ckbTym.Location = new System.Drawing.Point(46, 1);
		ckbTym.Name = "ckbTym";
		ckbTym.Size = new System.Drawing.Size(40, 30);
		ckbTym.TabIndex = 174;
		ckbTym.UseVisualStyleBackColor = true;
		A3B74338.Cursor = System.Windows.Forms.Cursors.Hand;
		A3B74338.Image = Class155.Bitmap_166;
		A3B74338.Location = new System.Drawing.Point(2, 1);
		A3B74338.Name = "ckbLike";
		A3B74338.Size = new System.Drawing.Size(40, 30);
		A3B74338.TabIndex = 173;
		A3B74338.UseVisualStyleBackColor = true;
		panel7.Controls.Add(radioButton3);
		panel7.Controls.Add(radioButton4);
		panel7.Location = new System.Drawing.Point(67, 300);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(200, 43);
		panel7.TabIndex = 43;
		radioButton3.AutoSize = true;
		radioButton3.Checked = true;
		radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton3.Location = new System.Drawing.Point(3, 2);
		radioButton3.Name = "radioButton3";
		radioButton3.Size = new System.Drawing.Size(201, 20);
		radioButton3.TabIndex = 3;
		radioButton3.TabStop = true;
		radioButton3.Text = "Comment theo thứ tự nội dung";
		radioButton3.UseVisualStyleBackColor = true;
		radioButton4.AutoSize = true;
		radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton4.Location = new System.Drawing.Point(3, 23);
		radioButton4.Name = "radioButton4";
		radioButton4.Size = new System.Drawing.Size(200, 20);
		radioButton4.TabIndex = 3;
		radioButton4.Text = "Comment ngẫu nhiên nội dung";
		radioButton4.UseVisualStyleBackColor = true;
		label26.AutoSize = true;
		label26.Location = new System.Drawing.Point(4, 302);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(64, 16);
		label26.TabIndex = 2;
		label26.Text = "Tùy chọn:";
		btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSave.ForeColor = System.Drawing.Color.White;
		btnSave.Location = new System.Drawing.Point(93, 468);
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(92, 29);
		btnSave.TabIndex = 180;
		btnSave.Text = "Lưu";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += new System.EventHandler(C42DEB14);
		EE332E9F.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		EE332E9F.BackColor = System.Drawing.Color.Maroon;
		EE332E9F.Cursor = System.Windows.Forms.Cursors.Hand;
		EE332E9F.FlatAppearance.BorderSize = 0;
		EE332E9F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EE332E9F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EE332E9F.ForeColor = System.Drawing.Color.White;
		EE332E9F.Location = new System.Drawing.Point(203, 468);
		EE332E9F.Name = "btnCancel";
		EE332E9F.Size = new System.Drawing.Size(92, 29);
		EE332E9F.TabIndex = 181;
		EE332E9F.Text = "Đóng";
		EE332E9F.UseVisualStyleBackColor = false;
		EE332E9F.Click += new System.EventHandler(BB859CAE);
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label19.Location = new System.Drawing.Point(28, 50);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(72, 16);
		label19.TabIndex = 191;
		label19.Text = "Sô\u0301 ba\u0300i viết:";
		nudTTPDelayTo.Location = new System.Drawing.Point(214, 77);
		nudTTPDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudTTPDelayTo.Name = "nudTTPDelayTo";
		nudTTPDelayTo.Size = new System.Drawing.Size(56, 23);
		nudTTPDelayTo.TabIndex = 185;
		nudTTPSoLuongTo.Location = new System.Drawing.Point(214, 48);
		nudTTPSoLuongTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudTTPSoLuongTo.Name = "nudTTPSoLuongTo";
		nudTTPSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudTTPSoLuongTo.TabIndex = 183;
		nudTTPDelayFrom.Location = new System.Drawing.Point(117, 77);
		nudTTPDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudTTPDelayFrom.Name = "nudTTPDelayFrom";
		nudTTPDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudTTPDelayFrom.TabIndex = 184;
		ABB9EE33.Location = new System.Drawing.Point(117, 48);
		ABB9EE33.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		ABB9EE33.Name = "nudTTPSoLuongFrom";
		ABB9EE33.Size = new System.Drawing.Size(56, 23);
		ABB9EE33.TabIndex = 182;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(179, 50);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 189;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(28, 79);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 186;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		D736F623.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D736F623.Location = new System.Drawing.Point(179, 79);
		D736F623.Name = "label1";
		D736F623.Size = new System.Drawing.Size(29, 16);
		D736F623.TabIndex = 189;
		D736F623.Text = ">";
		D736F623.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(CC33791F);
		panel1.Controls.Add(btnSave);
		panel1.Controls.Add(EE332E9F);
		panel1.Controls.Add(label19);
		panel1.Controls.Add(nudTTPDelayTo);
		panel1.Controls.Add(CB869B9F);
		panel1.Controls.Add(nudTTPSoLuongTo);
		panel1.Controls.Add(ckbTTPShareWall);
		panel1.Controls.Add(nudTTPDelayFrom);
		panel1.Controls.Add(ckbTTPCommentText);
		panel1.Controls.Add(ABB9EE33);
		panel1.Controls.Add(ckbTTPCommentImage);
		panel1.Controls.Add(D736F623);
		panel1.Controls.Add(DE38ED0E);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(plCommentText);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(B70ED29E);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(390, 511);
		panel1.TabIndex = 192;
		CC33791F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CC33791F.BackColor = System.Drawing.Color.White;
		CC33791F.BorderRadius = 0;
		CC33791F.BottomSahddow = true;
		CC33791F.color = System.Drawing.Color.DarkViolet;
		CC33791F.Controls.Add(EA251B9C);
		CC33791F.LeftSahddow = false;
		CC33791F.Location = new System.Drawing.Point(1, 0);
		CC33791F.Name = "bunifuCards1";
		CC33791F.RightSahddow = true;
		CC33791F.ShadowDepth = 20;
		CC33791F.Size = new System.Drawing.Size(387, 37);
		CC33791F.TabIndex = 183;
		EA251B9C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EA251B9C.BackColor = System.Drawing.Color.White;
		EA251B9C.Controls.Add(button1);
		EA251B9C.Controls.Add(pictureBox1);
		EA251B9C.Controls.Add(bunifuCustomLabel1);
		EA251B9C.Cursor = System.Windows.Forms.Cursors.SizeAll;
		EA251B9C.Location = new System.Drawing.Point(0, 3);
		EA251B9C.Name = "pnlHeader";
		EA251B9C.Size = new System.Drawing.Size(387, 31);
		EA251B9C.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = Class155.FF80C508;
		button1.Location = new System.Drawing.Point(356, 1);
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
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(387, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Tương ta\u0301c ba\u0300i viê\u0301t";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = EA251B9C;
		bunifuDragControl_0.Vertical = true;
		E707E8BB.Fixed = true;
		E707E8BB.Horizontal = true;
		E707E8BB.TargetControl = bunifuCustomLabel1;
		E707E8BB.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(390, 511);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fTuongTacProfile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.Load += new System.EventHandler(A627CD07);
		plCommentText.ResumeLayout(false);
		plCommentText.PerformLayout();
		C70B3E9F.ResumeLayout(false);
		C70B3E9F.PerformLayout();
		DE38ED0E.ResumeLayout(false);
		DE38ED0E.PerformLayout();
		B70ED29E.ResumeLayout(false);
		B70ED29E.PerformLayout();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTTPDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTTPSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTTPDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)ABB9EE33).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		CC33791F.ResumeLayout(false);
		EA251B9C.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
