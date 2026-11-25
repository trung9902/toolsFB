using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTuongTacBaiViet : Form
{
	internal GClass4 E1B6EF1D;

	internal List<CheckBox> list_0;

	internal IContainer icontainer_0 = null;

	internal Panel plCommentText;

	internal CheckBox FA0569A3;

	internal Button btnHuongDanNhapNoiDung;

	internal LinkLabel CE8771B1;

	internal Panel panel3;

	internal RadioButton rbCommentTheoThuTu;

	internal RadioButton BD91F6A0;

	internal Label E00608A3;

	internal Label FFB96782;

	internal RichTextBox txtTTBVComment;

	internal Label label11;

	internal Label CDBFC9BB;

	internal Panel plCommentImage;

	internal TextBox EDBCE8AC;

	internal Label label12;

	internal CheckBox ckbTTBVCommentImage;

	internal CheckBox ckbTTBVCommentText;

	internal CheckBox ckbTTBVShareWall;

	internal CheckBox ckbTTBVInteract;

	internal NumericUpDown nudTTBVTimeTo;

	internal NumericUpDown nudTTBVTimeFrom;

	internal Label label9;

	internal Label EC254013;

	internal ComboBox cbbTTBVTuyChonNoiDung;

	internal Panel B1994117;

	internal CheckBox ckbGian;

	internal CheckBox ckbBuon;

	internal CheckBox C11E8F22;

	internal CheckBox D638A791;

	internal CheckBox ckbThuong;

	internal CheckBox ckbTym;

	internal CheckBox C11B1F88;

	internal Panel panel7;

	internal RadioButton radioButton3;

	internal RadioButton radioButton4;

	internal Label label26;

	internal Button btnSave;

	internal Button C1A1B7AC;

	internal Button CBB9D8A3;

	internal Button btnUp;

	internal BunifuCards E69FCE8A;

	internal Panel A6AA99B2;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel panel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	public fTuongTacBaiViet(GClass4 gclass4_0)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		E1B6EF1D = gclass4_0;
		list_0 = new List<CheckBox> { C11B1F88, ckbTym, ckbThuong, D638A791, C11E8F22, ckbBuon, ckbGian };
		method_0();
		method_1();
	}

	private void txtTTBVComment_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTTBVComment, CDBFC9BB, cbbTTBVTuyChonNoiDung.SelectedIndex);
	}

	private void method_0()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTTBVTuyChonNoiDung, list);
	}

	private void CE8771B1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (cbbTTBVTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtTTBVComment.Focus();
	}

	private void ckbTTBVInteract_CheckedChanged(object sender, EventArgs e)
	{
		B1994117.Enabled = ckbTTBVInteract.Checked;
	}

	private void A106D490(object sender, EventArgs e)
	{
		plCommentText.Enabled = ckbTTBVCommentText.Checked;
	}

	private void ckbTTBVCommentImage_CheckedChanged(object sender, EventArgs e)
	{
		plCommentImage.Enabled = ckbTTBVCommentImage.Checked;
	}

	private void C1A1B7AC_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void CF8567BE(object sender, EventArgs e)
	{
		method_2();
		Close();
	}

	private void method_1()
	{
		nudTTBVTimeFrom.Value = E1B6EF1D.method_2("nudTTBVTimeFrom", 3);
		nudTTBVTimeTo.Value = E1B6EF1D.method_2("nudTTBVTimeTo", 5);
		ckbTTBVInteract.Checked = E1B6EF1D.method_3("ckbTTBVInteract");
		string text = E1B6EF1D.BDB80B23("TTBVtypeReaction", "0");
		for (int i = 0; i < list_0.Count; i++)
		{
			list_0[i].Checked = text.Split('|').Contains(i.ToString());
		}
		ckbTTBVCommentText.Checked = E1B6EF1D.method_3("ckbTTBVCommentText");
		txtTTBVComment.Text = E1B6EF1D.BDB80B23("txtTTBVComment");
		cbbTTBVTuyChonNoiDung.SelectedIndex = E1B6EF1D.method_2("cbbTTBVTuyChonNoiDung");
		FA0569A3.Checked = E1B6EF1D.method_3("ckbTTBVAutoDeleteComment");
		ckbTTBVCommentImage.Checked = E1B6EF1D.method_3("ckbTTBVCommentImage");
		EDBCE8AC.Text = E1B6EF1D.BDB80B23("txtTTBVImagePath");
		ckbTTBVShareWall.Checked = E1B6EF1D.method_3("ckbTTBVShareWall");
	}

	private void method_2()
	{
		E1B6EF1D.method_4("nudTTBVTimeFrom", nudTTBVTimeFrom.Value);
		E1B6EF1D.method_4("nudTTBVTimeTo", nudTTBVTimeTo.Value);
		E1B6EF1D.method_4("ckbTTBVInteract", ckbTTBVInteract.Checked);
		string text = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text = text + i + "|";
			}
		}
		E1B6EF1D.method_4("TTBVtypeReaction", text.TrimEnd('|'));
		E1B6EF1D.method_4("ckbTTBVCommentText", ckbTTBVCommentText.Checked);
		E1B6EF1D.method_4("txtTTBVComment", txtTTBVComment.Text);
		E1B6EF1D.method_4("cbbTTBVTuyChonNoiDung", cbbTTBVTuyChonNoiDung.SelectedIndex);
		E1B6EF1D.method_4("ckbTTBVAutoDeleteComment", FA0569A3.Checked);
		E1B6EF1D.method_4("ckbTTBVCommentImage", ckbTTBVCommentImage.Checked);
		E1B6EF1D.method_4("txtTTBVImagePath", EDBCE8AC.Text);
		E1B6EF1D.method_4("ckbTTBVShareWall", ckbTTBVShareWall.Checked);
	}

	private void A1356DAE(object sender, EventArgs e)
	{
		method_1();
		ckbTTBVInteract_CheckedChanged(null, null);
		A106D490(null, null);
		ckbTTBVCommentImage_CheckedChanged(null, null);
	}

	private void F324859C(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTTBVComment, CDBFC9BB, cbbTTBVTuyChonNoiDung.SelectedIndex);
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		plCommentText.Height = 183;
	}

	private void CBB9D8A3_Click(object sender, EventArgs e)
	{
		plCommentText.Height = 208;
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
		CBB9D8A3 = new System.Windows.Forms.Button();
		btnUp = new System.Windows.Forms.Button();
		cbbTTBVTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		FA0569A3 = new System.Windows.Forms.CheckBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		CE8771B1 = new System.Windows.Forms.LinkLabel();
		panel3 = new System.Windows.Forms.Panel();
		rbCommentTheoThuTu = new System.Windows.Forms.RadioButton();
		BD91F6A0 = new System.Windows.Forms.RadioButton();
		E00608A3 = new System.Windows.Forms.Label();
		txtTTBVComment = new System.Windows.Forms.RichTextBox();
		label11 = new System.Windows.Forms.Label();
		FFB96782 = new System.Windows.Forms.Label();
		CDBFC9BB = new System.Windows.Forms.Label();
		plCommentImage = new System.Windows.Forms.Panel();
		EDBCE8AC = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		ckbTTBVCommentImage = new System.Windows.Forms.CheckBox();
		ckbTTBVCommentText = new System.Windows.Forms.CheckBox();
		ckbTTBVShareWall = new System.Windows.Forms.CheckBox();
		ckbTTBVInteract = new System.Windows.Forms.CheckBox();
		nudTTBVTimeTo = new System.Windows.Forms.NumericUpDown();
		nudTTBVTimeFrom = new System.Windows.Forms.NumericUpDown();
		label9 = new System.Windows.Forms.Label();
		EC254013 = new System.Windows.Forms.Label();
		B1994117 = new System.Windows.Forms.Panel();
		ckbGian = new System.Windows.Forms.CheckBox();
		ckbBuon = new System.Windows.Forms.CheckBox();
		C11E8F22 = new System.Windows.Forms.CheckBox();
		D638A791 = new System.Windows.Forms.CheckBox();
		ckbThuong = new System.Windows.Forms.CheckBox();
		ckbTym = new System.Windows.Forms.CheckBox();
		C11B1F88 = new System.Windows.Forms.CheckBox();
		panel7 = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		radioButton4 = new System.Windows.Forms.RadioButton();
		label26 = new System.Windows.Forms.Label();
		btnSave = new System.Windows.Forms.Button();
		C1A1B7AC = new System.Windows.Forms.Button();
		E69FCE8A = new Bunifu.Framework.UI.BunifuCards();
		A6AA99B2 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		panel1 = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		plCommentText.SuspendLayout();
		panel3.SuspendLayout();
		plCommentImage.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTTBVTimeTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTTBVTimeFrom).BeginInit();
		B1994117.SuspendLayout();
		panel7.SuspendLayout();
		E69FCE8A.SuspendLayout();
		A6AA99B2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		SuspendLayout();
		plCommentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCommentText.Controls.Add(CBB9D8A3);
		plCommentText.Controls.Add(btnUp);
		plCommentText.Controls.Add(cbbTTBVTuyChonNoiDung);
		plCommentText.Controls.Add(FA0569A3);
		plCommentText.Controls.Add(btnHuongDanNhapNoiDung);
		plCommentText.Controls.Add(CE8771B1);
		plCommentText.Controls.Add(panel3);
		plCommentText.Controls.Add(E00608A3);
		plCommentText.Controls.Add(txtTTBVComment);
		plCommentText.Controls.Add(label11);
		plCommentText.Controls.Add(FFB96782);
		plCommentText.Controls.Add(CDBFC9BB);
		plCommentText.Location = new System.Drawing.Point(48, 161);
		plCommentText.Name = "plCommentText";
		plCommentText.Size = new System.Drawing.Size(310, 183);
		plCommentText.TabIndex = 176;
		CBB9D8A3.BackgroundImage = Class155.Bitmap_94;
		CBB9D8A3.Cursor = System.Windows.Forms.Cursors.Hand;
		CBB9D8A3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		CBB9D8A3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CBB9D8A3.Location = new System.Drawing.Point(253, -1);
		CBB9D8A3.Name = "btnDown";
		CBB9D8A3.Size = new System.Drawing.Size(25, 25);
		CBB9D8A3.TabIndex = 201;
		CBB9D8A3.Click += new System.EventHandler(CBB9D8A3_Click);
		btnUp.BackgroundImage = Class155.B116C210;
		btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
		btnUp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnUp.Location = new System.Drawing.Point(284, -1);
		btnUp.Name = "btnUp";
		btnUp.Size = new System.Drawing.Size(25, 25);
		btnUp.TabIndex = 202;
		btnUp.Click += new System.EventHandler(btnUp_Click);
		cbbTTBVTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTTBVTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTTBVTuyChonNoiDung.FormattingEnabled = true;
		cbbTTBVTuyChonNoiDung.Location = new System.Drawing.Point(81, 153);
		cbbTTBVTuyChonNoiDung.Name = "cbbTTBVTuyChonNoiDung";
		cbbTTBVTuyChonNoiDung.Size = new System.Drawing.Size(190, 24);
		cbbTTBVTuyChonNoiDung.TabIndex = 177;
		cbbTTBVTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(F324859C);
		FA0569A3.AutoSize = true;
		FA0569A3.Cursor = System.Windows.Forms.Cursors.Hand;
		FA0569A3.Location = new System.Drawing.Point(8, 182);
		FA0569A3.Name = "ckbTTBVAutoDeleteComment";
		FA0569A3.Size = new System.Drawing.Size(225, 20);
		FA0569A3.TabIndex = 176;
		FA0569A3.Text = "Tự động xóa nội dung đã bình luận";
		FA0569A3.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(277, 152);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 173;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		CE8771B1.AutoSize = true;
		CE8771B1.Cursor = System.Windows.Forms.Cursors.Hand;
		CE8771B1.Location = new System.Drawing.Point(222, 129);
		CE8771B1.Name = "linkLabel1";
		CE8771B1.Size = new System.Drawing.Size(81, 16);
		CE8771B1.TabIndex = 175;
		CE8771B1.TabStop = true;
		CE8771B1.Text = "Random icon";
		CE8771B1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(CE8771B1_LinkClicked);
		panel3.Controls.Add(rbCommentTheoThuTu);
		panel3.Controls.Add(BD91F6A0);
		panel3.Location = new System.Drawing.Point(66, 397);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(200, 43);
		panel3.TabIndex = 43;
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
		BD91F6A0.AutoSize = true;
		BD91F6A0.Cursor = System.Windows.Forms.Cursors.Hand;
		BD91F6A0.Location = new System.Drawing.Point(3, 23);
		BD91F6A0.Name = "rbCommentNgauNhien";
		BD91F6A0.Size = new System.Drawing.Size(200, 20);
		BD91F6A0.TabIndex = 3;
		BD91F6A0.Text = "Comment ngẫu nhiên nội dung";
		BD91F6A0.UseVisualStyleBackColor = true;
		E00608A3.AutoSize = true;
		E00608A3.Location = new System.Drawing.Point(3, 399);
		E00608A3.Name = "label13";
		E00608A3.Size = new System.Drawing.Size(64, 16);
		E00608A3.TabIndex = 2;
		E00608A3.Text = "Tùy chọn:";
		txtTTBVComment.Location = new System.Drawing.Point(6, 24);
		txtTTBVComment.Name = "txtTTBVComment";
		txtTTBVComment.Size = new System.Drawing.Size(297, 102);
		txtTTBVComment.TabIndex = 1;
		txtTTBVComment.Text = "";
		txtTTBVComment.WordWrap = false;
		txtTTBVComment.TextChanged += new System.EventHandler(txtTTBVComment_TextChanged);
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(4, 129);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(143, 16);
		label11.TabIndex = 0;
		label11.Text = "(Spin nội dung {a|b|c})";
		FFB96782.AutoSize = true;
		FFB96782.Location = new System.Drawing.Point(4, 156);
		FFB96782.Name = "label8";
		FFB96782.Size = new System.Drawing.Size(64, 16);
		FFB96782.TabIndex = 2;
		FFB96782.Text = "Tùy chọn:";
		CDBFC9BB.AutoSize = true;
		CDBFC9BB.Location = new System.Drawing.Point(2, 4);
		CDBFC9BB.Name = "lblComment";
		CDBFC9BB.Size = new System.Drawing.Size(139, 16);
		CDBFC9BB.TabIndex = 0;
		CDBFC9BB.Text = "Nội dung bình luận (0):";
		plCommentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCommentImage.Controls.Add(EDBCE8AC);
		plCommentImage.Controls.Add(label12);
		plCommentImage.Enabled = false;
		plCommentImage.Location = new System.Drawing.Point(48, 373);
		plCommentImage.Name = "plCommentImage";
		plCommentImage.Size = new System.Drawing.Size(310, 31);
		plCommentImage.TabIndex = 178;
		EDBCE8AC.Location = new System.Drawing.Point(82, 3);
		EDBCE8AC.Name = "txtTTBVImagePath";
		EDBCE8AC.Size = new System.Drawing.Size(222, 23);
		EDBCE8AC.TabIndex = 155;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(3, 6);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(73, 16);
		label12.TabIndex = 39;
		label12.Text = "Folder ảnh:";
		ckbTTBVCommentImage.AutoSize = true;
		ckbTTBVCommentImage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTBVCommentImage.Location = new System.Drawing.Point(30, 350);
		ckbTTBVCommentImage.Name = "ckbTTBVCommentImage";
		ckbTTBVCommentImage.Size = new System.Drawing.Size(103, 20);
		ckbTTBVCommentImage.TabIndex = 177;
		ckbTTBVCommentImage.Text = "Bình luận ảnh";
		ckbTTBVCommentImage.UseVisualStyleBackColor = true;
		ckbTTBVCommentImage.CheckedChanged += new System.EventHandler(ckbTTBVCommentImage_CheckedChanged);
		ckbTTBVCommentText.AutoSize = true;
		ckbTTBVCommentText.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTBVCommentText.Location = new System.Drawing.Point(30, 139);
		ckbTTBVCommentText.Name = "ckbTTBVCommentText";
		ckbTTBVCommentText.Size = new System.Drawing.Size(127, 20);
		ckbTTBVCommentText.TabIndex = 174;
		ckbTTBVCommentText.Text = "Bi\u0300nh luâ\u0323n văn bản";
		ckbTTBVCommentText.UseVisualStyleBackColor = true;
		ckbTTBVCommentText.CheckedChanged += new System.EventHandler(A106D490);
		ckbTTBVShareWall.AutoSize = true;
		ckbTTBVShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTBVShareWall.Location = new System.Drawing.Point(30, 408);
		ckbTTBVShareWall.Name = "ckbTTBVShareWall";
		ckbTTBVShareWall.Size = new System.Drawing.Size(143, 20);
		ckbTTBVShareWall.TabIndex = 170;
		ckbTTBVShareWall.Text = "Chia sẻ bài về tường";
		ckbTTBVShareWall.UseVisualStyleBackColor = true;
		ckbTTBVInteract.AutoSize = true;
		ckbTTBVInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTBVInteract.Location = new System.Drawing.Point(30, 78);
		ckbTTBVInteract.Name = "ckbTTBVInteract";
		ckbTTBVInteract.Size = new System.Drawing.Size(112, 20);
		ckbTTBVInteract.TabIndex = 169;
		ckbTTBVInteract.Text = "Bày tỏ cảm xúc";
		ckbTTBVInteract.UseVisualStyleBackColor = true;
		ckbTTBVInteract.CheckedChanged += new System.EventHandler(ckbTTBVInteract_CheckedChanged);
		nudTTBVTimeTo.Location = new System.Drawing.Point(269, 50);
		nudTTBVTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTTBVTimeTo.Name = "nudTTBVTimeTo";
		nudTTBVTimeTo.Size = new System.Drawing.Size(51, 23);
		nudTTBVTimeTo.TabIndex = 168;
		nudTTBVTimeFrom.Location = new System.Drawing.Point(191, 50);
		nudTTBVTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTTBVTimeFrom.Name = "nudTTBVTimeFrom";
		nudTTBVTimeFrom.Size = new System.Drawing.Size(51, 23);
		nudTTBVTimeFrom.TabIndex = 167;
		label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(242, 52);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(29, 16);
		label9.TabIndex = 173;
		label9.Text = ">";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		EC254013.AutoSize = true;
		EC254013.Location = new System.Drawing.Point(27, 52);
		EC254013.Name = "label3";
		EC254013.Size = new System.Drawing.Size(158, 16);
		EC254013.TabIndex = 171;
		EC254013.Text = "Thơ\u0300i gian xem bài viết (s):";
		B1994117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B1994117.Controls.Add(ckbGian);
		B1994117.Controls.Add(ckbBuon);
		B1994117.Controls.Add(C11E8F22);
		B1994117.Controls.Add(D638A791);
		B1994117.Controls.Add(ckbThuong);
		B1994117.Controls.Add(ckbTym);
		B1994117.Controls.Add(C11B1F88);
		B1994117.Controls.Add(panel7);
		B1994117.Controls.Add(label26);
		B1994117.Location = new System.Drawing.Point(48, 100);
		B1994117.Name = "plInteract";
		B1994117.Size = new System.Drawing.Size(310, 33);
		B1994117.TabIndex = 179;
		ckbGian.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGian.Image = Class155.Bitmap_11;
		ckbGian.Location = new System.Drawing.Point(266, 1);
		ckbGian.Name = "ckbGian";
		ckbGian.Size = new System.Drawing.Size(40, 30);
		ckbGian.TabIndex = 179;
		ckbGian.UseVisualStyleBackColor = true;
		ckbBuon.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBuon.Image = Class155.E1938320;
		ckbBuon.Location = new System.Drawing.Point(222, 1);
		ckbBuon.Name = "ckbBuon";
		ckbBuon.Size = new System.Drawing.Size(40, 30);
		ckbBuon.TabIndex = 178;
		ckbBuon.UseVisualStyleBackColor = true;
		C11E8F22.Cursor = System.Windows.Forms.Cursors.Hand;
		C11E8F22.Image = Class155.Bitmap_181;
		C11E8F22.Location = new System.Drawing.Point(178, 1);
		C11E8F22.Name = "ckbWow";
		C11E8F22.Size = new System.Drawing.Size(40, 30);
		C11E8F22.TabIndex = 177;
		C11E8F22.UseVisualStyleBackColor = true;
		D638A791.Cursor = System.Windows.Forms.Cursors.Hand;
		D638A791.Image = Class155.E982D419;
		D638A791.Location = new System.Drawing.Point(134, 1);
		D638A791.Name = "ckbHaha";
		D638A791.Size = new System.Drawing.Size(40, 30);
		D638A791.TabIndex = 176;
		D638A791.UseVisualStyleBackColor = true;
		ckbThuong.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThuong.Image = Class155.Bitmap_20;
		ckbThuong.Location = new System.Drawing.Point(90, 1);
		ckbThuong.Name = "ckbThuong";
		ckbThuong.Size = new System.Drawing.Size(40, 30);
		ckbThuong.TabIndex = 175;
		ckbThuong.UseVisualStyleBackColor = true;
		ckbTym.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTym.Image = Class155.AB95A212;
		ckbTym.Location = new System.Drawing.Point(46, 1);
		ckbTym.Name = "ckbTym";
		ckbTym.Size = new System.Drawing.Size(40, 30);
		ckbTym.TabIndex = 174;
		ckbTym.UseVisualStyleBackColor = true;
		C11B1F88.Checked = true;
		C11B1F88.CheckState = System.Windows.Forms.CheckState.Checked;
		C11B1F88.Cursor = System.Windows.Forms.Cursors.Hand;
		C11B1F88.Image = Class155.Bitmap_166;
		C11B1F88.Location = new System.Drawing.Point(2, 1);
		C11B1F88.Name = "ckbLike";
		C11B1F88.Size = new System.Drawing.Size(40, 30);
		C11B1F88.TabIndex = 173;
		C11B1F88.UseVisualStyleBackColor = true;
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
		btnSave.Location = new System.Drawing.Point(95, 441);
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(92, 29);
		btnSave.TabIndex = 180;
		btnSave.Text = "Lưu";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += new System.EventHandler(CF8567BE);
		C1A1B7AC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C1A1B7AC.BackColor = System.Drawing.Color.Maroon;
		C1A1B7AC.Cursor = System.Windows.Forms.Cursors.Hand;
		C1A1B7AC.FlatAppearance.BorderSize = 0;
		C1A1B7AC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C1A1B7AC.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C1A1B7AC.ForeColor = System.Drawing.Color.White;
		C1A1B7AC.Location = new System.Drawing.Point(205, 441);
		C1A1B7AC.Name = "btnCancel";
		C1A1B7AC.Size = new System.Drawing.Size(92, 29);
		C1A1B7AC.TabIndex = 181;
		C1A1B7AC.Text = "Đóng";
		C1A1B7AC.UseVisualStyleBackColor = false;
		C1A1B7AC.Click += new System.EventHandler(C1A1B7AC_Click);
		E69FCE8A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E69FCE8A.BackColor = System.Drawing.Color.White;
		E69FCE8A.BorderRadius = 0;
		E69FCE8A.BottomSahddow = true;
		E69FCE8A.color = System.Drawing.Color.DarkViolet;
		E69FCE8A.Controls.Add(A6AA99B2);
		E69FCE8A.LeftSahddow = false;
		E69FCE8A.Location = new System.Drawing.Point(1, 0);
		E69FCE8A.Name = "bunifuCards1";
		E69FCE8A.RightSahddow = true;
		E69FCE8A.ShadowDepth = 20;
		E69FCE8A.Size = new System.Drawing.Size(393, 37);
		E69FCE8A.TabIndex = 182;
		A6AA99B2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A6AA99B2.BackColor = System.Drawing.Color.White;
		A6AA99B2.Controls.Add(button1);
		A6AA99B2.Controls.Add(pictureBox1);
		A6AA99B2.Controls.Add(bunifuCustomLabel1);
		A6AA99B2.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A6AA99B2.Location = new System.Drawing.Point(0, 3);
		A6AA99B2.Name = "pnlHeader";
		A6AA99B2.Size = new System.Drawing.Size(393, 31);
		A6AA99B2.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = Class155.FF80C508;
		button1.Location = new System.Drawing.Point(362, 1);
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(393, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Tương ta\u0301c ba\u0300i viê\u0301t";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(nudTTBVTimeTo);
		panel1.Controls.Add(btnSave);
		panel1.Controls.Add(C1A1B7AC);
		panel1.Controls.Add(EC254013);
		panel1.Controls.Add(E69FCE8A);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(B1994117);
		panel1.Controls.Add(nudTTBVTimeFrom);
		panel1.Controls.Add(plCommentText);
		panel1.Controls.Add(plCommentImage);
		panel1.Controls.Add(ckbTTBVInteract);
		panel1.Controls.Add(ckbTTBVCommentImage);
		panel1.Controls.Add(ckbTTBVShareWall);
		panel1.Controls.Add(ckbTTBVCommentText);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(395, 483);
		panel1.TabIndex = 183;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = A6AA99B2;
		bunifuDragControl_1.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(395, 483);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fTuongTacBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.Load += new System.EventHandler(A1356DAE);
		plCommentText.ResumeLayout(false);
		plCommentText.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		plCommentImage.ResumeLayout(false);
		plCommentImage.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTTBVTimeTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTTBVTimeFrom).EndInit();
		B1994117.ResumeLayout(false);
		B1994117.PerformLayout();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		E69FCE8A.ResumeLayout(false);
		A6AA99B2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ResumeLayout(false);
	}
}
