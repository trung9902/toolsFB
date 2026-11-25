using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhTaiKhoan : Form
{
	internal string string_0;

	internal IContainer A63434AF = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel lblTitle;

	internal Button EC8F220B;

	internal Button AB8A38BC;

	internal BunifuDragControl B91B4483;

	internal PictureBox pictureBox1;

	internal Panel panel1;

	internal Button btnSave;

	internal Panel plCrawlPostGroup;

	internal CheckBox ckbCrawlPostGroup;

	internal NumericUpDown nudCountPostTurn;

	internal Label label4;

	internal Label label2;

	internal NumericUpDown nudDelayTurn;

	internal Label label1;

	internal NumericUpDown F427C83F;

	internal NumericUpDown F0184427;

	internal Label label5;

	internal Label B80B9D20;

	internal RichTextBox txtGroupId;

	internal Panel pnlReplyComment;

	internal Label AA191D92;

	internal Label B9306221;

	internal CheckBox ckbReplyComment;

	internal NumericUpDown nudDelayReplyTo;

	internal NumericUpDown nudDelayReplyFrom;

	internal Label A4A361A5;

	internal Label F78B2D1A;

	internal NumericUpDown CD3A649F;

	internal NumericUpDown D7B43A99;

	internal Label label11;

	internal CheckBox ckbContent;

	internal Panel FD8802BD;

	internal TextBox EE1CCE0D;

	internal Label label6;

	internal CheckBox ckbImage;

	internal TextBox txtIdNhom;

	internal Panel plCommentText;

	internal Button btnDown;

	internal Button B0A1A808;

	internal ComboBox A308762F;

	internal CheckBox ckbTTBVAutoDeleteComment;

	internal Button btnHuongDanNhapNoiDung;

	internal Panel panel3;

	internal RadioButton rbCommentTheoThuTu;

	internal RadioButton E090B81C;

	internal Label AB14272E;

	internal Label label13;

	internal RichTextBox txtContent;

	internal Label label12;

	internal Label label14;

	public fCauHinhTaiKhoan(string string_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		string_0 = string_1;
		lblTitle.Text = "Câ\u0301u hi\u0300nh " + string_1;
	}

	private void txtContent_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContent, AB14272E, A308762F.SelectedIndex);
	}

	private void CE8F2601()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(A308762F, list_);
	}

	private void EC8F220B_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AB8A38BC_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D028D499(object sender, EventArgs e)
	{
		CE8F2601();
		ckbCrawlPostGroup.Checked = C5034B95.smethod_0(string_0).method_3("ckbCrawlPostGroup");
		txtGroupId.Text = C5034B95.smethod_0(string_0).BDB80B23("txtGroupId");
		nudCountPostTurn.Value = C5034B95.smethod_0(string_0).method_2("nudCountPostTurn", 10);
		F0184427.Value = C5034B95.smethod_0(string_0).method_2("nudDelayFrom", 3);
		F427C83F.Value = C5034B95.smethod_0(string_0).method_2("nudDelayTo", 5);
		nudDelayTurn.Value = C5034B95.smethod_0(string_0).method_2("nudDelayTurn", 60);
		ckbReplyComment.Checked = C5034B95.smethod_0(string_0).method_3("ckbReplyComment");
		txtIdNhom.Text = C5034B95.smethod_0(string_0).BDB80B23("txtIdNhom");
		D7B43A99.Value = C5034B95.smethod_0(string_0).method_2("nudSoLuongReplyFrom", 3);
		CD3A649F.Value = C5034B95.smethod_0(string_0).method_2("nudSoLuongReplyTo", 3);
		nudDelayReplyFrom.Value = C5034B95.smethod_0(string_0).method_2("nudDelayReplyFrom", 3);
		nudDelayReplyTo.Value = C5034B95.smethod_0(string_0).method_2("nudDelayReplyTo", 3);
		ckbContent.Checked = C5034B95.smethod_0(string_0).method_3("ckbContent");
		txtContent.Text = C5034B95.smethod_0(string_0).BDB80B23("txtContent");
		ckbImage.Checked = C5034B95.smethod_0(string_0).method_3("ckbImage");
		EE1CCE0D.Text = C5034B95.smethod_0(string_0).BDB80B23("txtPathImage");
		A308762F.SelectedIndex = C5034B95.smethod_0(string_0).method_2("cbbTuyChonNoiDung");
		ckbCrawlPostGroup_CheckedChanged(null, null);
		ckbReplyComment_CheckedChanged(null, null);
		ckbContent_CheckedChanged(null, null);
		ckbReplyComment_CheckedChanged(null, null);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0(string_0).method_4("ckbCrawlPostGroup", ckbCrawlPostGroup.Checked);
		C5034B95.smethod_0(string_0).method_4("txtGroupId", txtGroupId.Text);
		C5034B95.smethod_0(string_0).method_4("nudCountPostTurn", nudCountPostTurn.Value);
		C5034B95.smethod_0(string_0).method_4("nudDelayFrom", F0184427.Value);
		C5034B95.smethod_0(string_0).method_4("nudDelayTo", F427C83F.Value);
		C5034B95.smethod_0(string_0).method_4("nudDelayTurn", nudDelayTurn.Value);
		C5034B95.smethod_0(string_0).method_4("ckbReplyComment", ckbReplyComment.Checked);
		C5034B95.smethod_0(string_0).method_4("ckbImage", ckbImage.Checked);
		C5034B95.smethod_0(string_0).method_4("txtPathImage", EE1CCE0D.Text);
		C5034B95.smethod_0(string_0).method_4("nudSoLuongReplyFrom", D7B43A99.Value);
		C5034B95.smethod_0(string_0).method_4("nudSoLuongReplyTo", CD3A649F.Value);
		C5034B95.smethod_0(string_0).method_4("nudDelayReplyFrom", nudDelayReplyFrom.Value);
		C5034B95.smethod_0(string_0).method_4("nudDelayReplyTo", nudDelayReplyTo.Value);
		C5034B95.smethod_0(string_0).method_4("ckbContent", ckbContent.Checked);
		C5034B95.smethod_0(string_0).method_4("txtContent", txtContent.Text);
		C5034B95.smethod_0(string_0).method_4("txtIdNhom", txtIdNhom.Text);
		C5034B95.smethod_0(string_0).method_4("cbbTuyChonNoiDung", A308762F.SelectedIndex);
		C5034B95.smethod_1(string_0);
		Close();
	}

	private void ckbCrawlPostGroup_CheckedChanged(object sender, EventArgs e)
	{
		plCrawlPostGroup.Enabled = ckbCrawlPostGroup.Checked;
	}

	private void method_0(object sender, EventArgs e)
	{
		if (A308762F.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtContent.Focus();
	}

	private void ckbReplyComment_CheckedChanged(object sender, EventArgs e)
	{
		pnlReplyComment.Enabled = ckbReplyComment.Checked;
	}

	private void ckbContent_CheckedChanged(object sender, EventArgs e)
	{
		plCommentText.Enabled = ckbContent.Checked;
	}

	private void ckbImage_CheckedChanged(object sender, EventArgs e)
	{
		FD8802BD.Enabled = ckbImage.Checked;
	}

	private void BA8D379C(object sender, EventArgs e)
	{
		plCommentText.Height = 183;
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		plCommentText.Height = 208;
	}

	private void BE8E3239(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContent, AB14272E, A308762F.SelectedIndex);
	}

	protected override void Dispose(bool B68C2193)
	{
		if (B68C2193 && A63434AF != null)
		{
			A63434AF.Dispose();
		}
		base.Dispose(B68C2193);
	}

	private void InitializeComponent()
	{
		A63434AF = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhTaiKhoan));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		EC8F220B = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		AB8A38BC = new System.Windows.Forms.Button();
		B91B4483 = new Bunifu.Framework.UI.BunifuDragControl(A63434AF);
		panel1 = new System.Windows.Forms.Panel();
		pnlReplyComment = new System.Windows.Forms.Panel();
		txtIdNhom = new System.Windows.Forms.TextBox();
		ckbContent = new System.Windows.Forms.CheckBox();
		FD8802BD = new System.Windows.Forms.Panel();
		EE1CCE0D = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		ckbImage = new System.Windows.Forms.CheckBox();
		CD3A649F = new System.Windows.Forms.NumericUpDown();
		D7B43A99 = new System.Windows.Forms.NumericUpDown();
		label11 = new System.Windows.Forms.Label();
		nudDelayReplyTo = new System.Windows.Forms.NumericUpDown();
		nudDelayReplyFrom = new System.Windows.Forms.NumericUpDown();
		A4A361A5 = new System.Windows.Forms.Label();
		F78B2D1A = new System.Windows.Forms.Label();
		AA191D92 = new System.Windows.Forms.Label();
		B9306221 = new System.Windows.Forms.Label();
		ckbReplyComment = new System.Windows.Forms.CheckBox();
		plCrawlPostGroup = new System.Windows.Forms.Panel();
		txtGroupId = new System.Windows.Forms.RichTextBox();
		nudDelayTurn = new System.Windows.Forms.NumericUpDown();
		label1 = new System.Windows.Forms.Label();
		F427C83F = new System.Windows.Forms.NumericUpDown();
		F0184427 = new System.Windows.Forms.NumericUpDown();
		label5 = new System.Windows.Forms.Label();
		B80B9D20 = new System.Windows.Forms.Label();
		nudCountPostTurn = new System.Windows.Forms.NumericUpDown();
		label4 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		ckbCrawlPostGroup = new System.Windows.Forms.CheckBox();
		btnSave = new System.Windows.Forms.Button();
		plCommentText = new System.Windows.Forms.Panel();
		btnDown = new System.Windows.Forms.Button();
		B0A1A808 = new System.Windows.Forms.Button();
		A308762F = new System.Windows.Forms.ComboBox();
		ckbTTBVAutoDeleteComment = new System.Windows.Forms.CheckBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		panel3 = new System.Windows.Forms.Panel();
		rbCommentTheoThuTu = new System.Windows.Forms.RadioButton();
		E090B81C = new System.Windows.Forms.RadioButton();
		AB14272E = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		txtContent = new System.Windows.Forms.RichTextBox();
		label12 = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		pnlReplyComment.SuspendLayout();
		FD8802BD.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CD3A649F).BeginInit();
		((System.ComponentModel.ISupportInitialize)D7B43A99).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayReplyTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayReplyFrom).BeginInit();
		plCrawlPostGroup.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTurn).BeginInit();
		((System.ComponentModel.ISupportInitialize)F427C83F).BeginInit();
		((System.ComponentModel.ISupportInitialize)F0184427).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountPostTurn).BeginInit();
		plCommentText.SuspendLayout();
		panel3.SuspendLayout();
		SuspendLayout();
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(418, 38);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(EC8F220B);
		pnlHeader.Controls.Add(lblTitle);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(418, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		EC8F220B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		EC8F220B.Cursor = System.Windows.Forms.Cursors.Hand;
		EC8F220B.FlatAppearance.BorderSize = 0;
		EC8F220B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EC8F220B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EC8F220B.ForeColor = System.Drawing.Color.White;
		EC8F220B.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		EC8F220B.Location = new System.Drawing.Point(385, -1);
		EC8F220B.Name = "btnMinimize";
		EC8F220B.Size = new System.Drawing.Size(32, 32);
		EC8F220B.TabIndex = 9;
		EC8F220B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		EC8F220B.UseVisualStyleBackColor = true;
		EC8F220B.Click += new System.EventHandler(EC8F220B_Click);
		lblTitle.BackColor = System.Drawing.Color.Transparent;
		lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
		lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
		lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblTitle.ForeColor = System.Drawing.Color.Black;
		lblTitle.Location = new System.Drawing.Point(0, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new System.Drawing.Size(418, 32);
		lblTitle.TabIndex = 1;
		lblTitle.Text = "Cấu hình ";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AB8A38BC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		AB8A38BC.BackColor = System.Drawing.Color.Maroon;
		AB8A38BC.Cursor = System.Windows.Forms.Cursors.Hand;
		AB8A38BC.FlatAppearance.BorderSize = 0;
		AB8A38BC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AB8A38BC.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AB8A38BC.ForeColor = System.Drawing.Color.White;
		AB8A38BC.Location = new System.Drawing.Point(200, 304);
		AB8A38BC.Name = "btnCancel";
		AB8A38BC.Size = new System.Drawing.Size(92, 29);
		AB8A38BC.TabIndex = 4;
		AB8A38BC.Text = "Đo\u0301ng";
		AB8A38BC.UseVisualStyleBackColor = false;
		AB8A38BC.Click += new System.EventHandler(AB8A38BC_Click);
		B91B4483.Fixed = true;
		B91B4483.Horizontal = true;
		B91B4483.TargetControl = lblTitle;
		B91B4483.Vertical = true;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlReplyComment);
		panel1.Controls.Add(ckbReplyComment);
		panel1.Controls.Add(plCrawlPostGroup);
		panel1.Controls.Add(ckbCrawlPostGroup);
		panel1.Controls.Add(btnSave);
		panel1.Controls.Add(AB8A38BC);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(419, 346);
		panel1.TabIndex = 5;
		pnlReplyComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		pnlReplyComment.Controls.Add(plCommentText);
		pnlReplyComment.Controls.Add(txtIdNhom);
		pnlReplyComment.Controls.Add(ckbContent);
		pnlReplyComment.Controls.Add(FD8802BD);
		pnlReplyComment.Controls.Add(ckbImage);
		pnlReplyComment.Controls.Add(CD3A649F);
		pnlReplyComment.Controls.Add(D7B43A99);
		pnlReplyComment.Controls.Add(label11);
		pnlReplyComment.Controls.Add(nudDelayReplyTo);
		pnlReplyComment.Controls.Add(nudDelayReplyFrom);
		pnlReplyComment.Controls.Add(A4A361A5);
		pnlReplyComment.Controls.Add(F78B2D1A);
		pnlReplyComment.Controls.Add(AA191D92);
		pnlReplyComment.Controls.Add(B9306221);
		pnlReplyComment.Location = new System.Drawing.Point(444, 83);
		pnlReplyComment.Name = "pnlReplyComment";
		pnlReplyComment.Size = new System.Drawing.Size(364, 375);
		pnlReplyComment.TabIndex = 161;
		txtIdNhom.Location = new System.Drawing.Point(129, 5);
		txtIdNhom.Name = "txtIdNhom";
		txtIdNhom.Size = new System.Drawing.Size(197, 23);
		txtIdNhom.TabIndex = 193;
		ckbContent.Anchor = System.Windows.Forms.AnchorStyles.None;
		ckbContent.AutoSize = true;
		ckbContent.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbContent.Location = new System.Drawing.Point(19, 103);
		ckbContent.Name = "ckbContent";
		ckbContent.Size = new System.Drawing.Size(162, 20);
		ckbContent.TabIndex = 192;
		ckbContent.Text = "Reply bi\u0300nh luâ\u0323n văn bản";
		ckbContent.UseVisualStyleBackColor = true;
		ckbContent.CheckedChanged += new System.EventHandler(ckbContent_CheckedChanged);
		FD8802BD.Anchor = System.Windows.Forms.AnchorStyles.None;
		FD8802BD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		FD8802BD.Controls.Add(EE1CCE0D);
		FD8802BD.Controls.Add(label6);
		FD8802BD.Enabled = false;
		FD8802BD.Location = new System.Drawing.Point(19, 335);
		FD8802BD.Name = "plCommentImage";
		FD8802BD.Size = new System.Drawing.Size(310, 31);
		FD8802BD.TabIndex = 191;
		EE1CCE0D.Location = new System.Drawing.Point(82, 3);
		EE1CCE0D.Name = "txtPathImage";
		EE1CCE0D.Size = new System.Drawing.Size(222, 23);
		EE1CCE0D.TabIndex = 155;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(3, 6);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(73, 16);
		label6.TabIndex = 39;
		label6.Text = "Folder ảnh:";
		ckbImage.Anchor = System.Windows.Forms.AnchorStyles.None;
		ckbImage.AutoSize = true;
		ckbImage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbImage.Location = new System.Drawing.Point(19, 313);
		ckbImage.Name = "ckbImage";
		ckbImage.Size = new System.Drawing.Size(138, 20);
		ckbImage.TabIndex = 190;
		ckbImage.Text = "Reply bình luận ảnh";
		ckbImage.UseVisualStyleBackColor = true;
		ckbImage.CheckedChanged += new System.EventHandler(ckbImage_CheckedChanged);
		CD3A649F.Location = new System.Drawing.Point(273, 43);
		CD3A649F.Name = "nudSoLuongReplyTo";
		CD3A649F.Size = new System.Drawing.Size(53, 23);
		CD3A649F.TabIndex = 183;
		D7B43A99.Location = new System.Drawing.Point(194, 43);
		D7B43A99.Name = "nudSoLuongReplyFrom";
		D7B43A99.Size = new System.Drawing.Size(53, 23);
		D7B43A99.TabIndex = 184;
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(251, 45);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(18, 16);
		label11.TabIndex = 182;
		label11.Text = ">";
		nudDelayReplyTo.Location = new System.Drawing.Point(273, 73);
		nudDelayReplyTo.Name = "nudDelayReplyTo";
		nudDelayReplyTo.Size = new System.Drawing.Size(53, 23);
		nudDelayReplyTo.TabIndex = 6;
		nudDelayReplyFrom.Location = new System.Drawing.Point(194, 73);
		nudDelayReplyFrom.Name = "nudDelayReplyFrom";
		nudDelayReplyFrom.Size = new System.Drawing.Size(53, 23);
		nudDelayReplyFrom.TabIndex = 7;
		A4A361A5.AutoSize = true;
		A4A361A5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A4A361A5.Location = new System.Drawing.Point(251, 75);
		A4A361A5.Name = "label7";
		A4A361A5.Size = new System.Drawing.Size(18, 16);
		A4A361A5.TabIndex = 4;
		A4A361A5.Text = ">";
		F78B2D1A.AutoSize = true;
		F78B2D1A.Location = new System.Drawing.Point(18, 80);
		F78B2D1A.Name = "label8";
		F78B2D1A.Size = new System.Drawing.Size(141, 16);
		F78B2D1A.TabIndex = 5;
		F78B2D1A.Text = "Delay mỗi comment(s):";
		AA191D92.AutoSize = true;
		AA191D92.Location = new System.Drawing.Point(18, 50);
		AA191D92.Name = "label9";
		AA191D92.Size = new System.Drawing.Size(152, 16);
		AA191D92.TabIndex = 0;
		AA191D92.Text = "Số lượng reply comment:";
		B9306221.AutoSize = true;
		B9306221.Location = new System.Drawing.Point(18, 10);
		B9306221.Name = "label10";
		B9306221.Size = new System.Drawing.Size(105, 16);
		B9306221.TabIndex = 0;
		B9306221.Text = "ID bài viết nho\u0301m:";
		ckbReplyComment.AutoSize = true;
		ckbReplyComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbReplyComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbReplyComment.Location = new System.Drawing.Point(444, 61);
		ckbReplyComment.Name = "ckbReplyComment";
		ckbReplyComment.Size = new System.Drawing.Size(114, 20);
		ckbReplyComment.TabIndex = 161;
		ckbReplyComment.Text = "Reply comment";
		ckbReplyComment.UseVisualStyleBackColor = true;
		ckbReplyComment.CheckedChanged += new System.EventHandler(ckbReplyComment_CheckedChanged);
		plCrawlPostGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCrawlPostGroup.Controls.Add(txtGroupId);
		plCrawlPostGroup.Controls.Add(nudDelayTurn);
		plCrawlPostGroup.Controls.Add(label1);
		plCrawlPostGroup.Controls.Add(F427C83F);
		plCrawlPostGroup.Controls.Add(F0184427);
		plCrawlPostGroup.Controls.Add(label5);
		plCrawlPostGroup.Controls.Add(B80B9D20);
		plCrawlPostGroup.Controls.Add(nudCountPostTurn);
		plCrawlPostGroup.Controls.Add(label4);
		plCrawlPostGroup.Controls.Add(label2);
		plCrawlPostGroup.Location = new System.Drawing.Point(37, 83);
		plCrawlPostGroup.Name = "plCrawlPostGroup";
		plCrawlPostGroup.Size = new System.Drawing.Size(344, 196);
		plCrawlPostGroup.TabIndex = 160;
		txtGroupId.Location = new System.Drawing.Point(123, 5);
		txtGroupId.Name = "txtGroupId";
		txtGroupId.Size = new System.Drawing.Size(216, 96);
		txtGroupId.TabIndex = 3;
		txtGroupId.Text = "";
		txtGroupId.WordWrap = false;
		nudDelayTurn.Location = new System.Drawing.Point(123, 165);
		nudDelayTurn.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
		nudDelayTurn.Name = "nudDelayTurn";
		nudDelayTurn.Size = new System.Drawing.Size(83, 23);
		nudDelayTurn.TabIndex = 2;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(8, 167);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(118, 16);
		label1.TabIndex = 0;
		label1.Text = "Nghi\u0309 sau 1 lươ\u0323t (s):";
		F427C83F.Location = new System.Drawing.Point(202, 136);
		F427C83F.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
		F427C83F.Name = "nudDelayTo";
		F427C83F.Size = new System.Drawing.Size(53, 23);
		F427C83F.TabIndex = 2;
		F0184427.Location = new System.Drawing.Point(123, 136);
		F0184427.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
		F0184427.Name = "nudDelayFrom";
		F0184427.Size = new System.Drawing.Size(53, 23);
		F0184427.TabIndex = 2;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(180, 138);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(18, 16);
		label5.TabIndex = 0;
		label5.Text = ">";
		B80B9D20.AutoSize = true;
		B80B9D20.Location = new System.Drawing.Point(8, 138);
		B80B9D20.Name = "label3";
		B80B9D20.Size = new System.Drawing.Size(109, 16);
		B80B9D20.TabIndex = 0;
		B80B9D20.Text = "Delay mô\u0303i ba\u0300i (s):";
		nudCountPostTurn.Location = new System.Drawing.Point(123, 107);
		nudCountPostTurn.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
		nudCountPostTurn.Name = "nudCountPostTurn";
		nudCountPostTurn.Size = new System.Drawing.Size(83, 23);
		nudCountPostTurn.TabIndex = 2;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(8, 109);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(99, 16);
		label4.TabIndex = 0;
		label4.Text = "Sô\u0301 ba\u0300i viê\u0301t/lươ\u0323t:";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(10, 10);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(60, 16);
		label2.TabIndex = 0;
		label2.Text = "ID nho\u0301m:";
		ckbCrawlPostGroup.AutoSize = true;
		ckbCrawlPostGroup.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCrawlPostGroup.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbCrawlPostGroup.Location = new System.Drawing.Point(37, 61);
		ckbCrawlPostGroup.Name = "ckbCrawlPostGroup";
		ckbCrawlPostGroup.Size = new System.Drawing.Size(140, 20);
		ckbCrawlPostGroup.TabIndex = 25;
		ckbCrawlPostGroup.Text = "Crawl ba\u0300i viê\u0301t nho\u0301m";
		ckbCrawlPostGroup.UseVisualStyleBackColor = true;
		ckbCrawlPostGroup.CheckedChanged += new System.EventHandler(ckbCrawlPostGroup_CheckedChanged);
		btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSave.ForeColor = System.Drawing.Color.White;
		btnSave.Location = new System.Drawing.Point(92, 304);
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(92, 29);
		btnSave.TabIndex = 20;
		btnSave.Text = "Lưu";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += new System.EventHandler(btnSave_Click);
		plCommentText.Anchor = System.Windows.Forms.AnchorStyles.None;
		plCommentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCommentText.Controls.Add(btnDown);
		plCommentText.Controls.Add(B0A1A808);
		plCommentText.Controls.Add(A308762F);
		plCommentText.Controls.Add(ckbTTBVAutoDeleteComment);
		plCommentText.Controls.Add(btnHuongDanNhapNoiDung);
		plCommentText.Controls.Add(panel3);
		plCommentText.Controls.Add(AB14272E);
		plCommentText.Controls.Add(label13);
		plCommentText.Controls.Add(txtContent);
		plCommentText.Controls.Add(label12);
		plCommentText.Controls.Add(label14);
		plCommentText.Location = new System.Drawing.Point(19, 129);
		plCommentText.Name = "plCommentText";
		plCommentText.Size = new System.Drawing.Size(310, 183);
		plCommentText.TabIndex = 190;
		btnDown.BackgroundImage = Class155.Bitmap_94;
		btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnDown.Location = new System.Drawing.Point(253, -1);
		btnDown.Name = "btnDown";
		btnDown.Size = new System.Drawing.Size(25, 25);
		btnDown.TabIndex = 201;
		btnDown.Click += new System.EventHandler(btnDown_Click);
		B0A1A808.BackgroundImage = Class155.B116C210;
		B0A1A808.Cursor = System.Windows.Forms.Cursors.Hand;
		B0A1A808.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		B0A1A808.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B0A1A808.Location = new System.Drawing.Point(284, -1);
		B0A1A808.Name = "btnUp";
		B0A1A808.Size = new System.Drawing.Size(25, 25);
		B0A1A808.TabIndex = 202;
		B0A1A808.Click += new System.EventHandler(BA8D379C);
		A308762F.Cursor = System.Windows.Forms.Cursors.Hand;
		A308762F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A308762F.FormattingEnabled = true;
		A308762F.Location = new System.Drawing.Point(81, 153);
		A308762F.Name = "cbbTuyChonNoiDung";
		A308762F.Size = new System.Drawing.Size(190, 24);
		A308762F.TabIndex = 177;
		ckbTTBVAutoDeleteComment.AutoSize = true;
		ckbTTBVAutoDeleteComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTTBVAutoDeleteComment.Location = new System.Drawing.Point(8, 182);
		ckbTTBVAutoDeleteComment.Name = "ckbTTBVAutoDeleteComment";
		ckbTTBVAutoDeleteComment.Size = new System.Drawing.Size(225, 20);
		ckbTTBVAutoDeleteComment.TabIndex = 176;
		ckbTTBVAutoDeleteComment.Text = "Tự động xóa nội dung đã bình luận";
		ckbTTBVAutoDeleteComment.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(277, 152);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 173;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		panel3.Controls.Add(rbCommentTheoThuTu);
		panel3.Controls.Add(E090B81C);
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
		E090B81C.AutoSize = true;
		E090B81C.Cursor = System.Windows.Forms.Cursors.Hand;
		E090B81C.Location = new System.Drawing.Point(3, 23);
		E090B81C.Name = "rbCommentNgauNhien";
		E090B81C.Size = new System.Drawing.Size(200, 20);
		E090B81C.TabIndex = 3;
		E090B81C.Text = "Comment ngẫu nhiên nội dung";
		E090B81C.UseVisualStyleBackColor = true;
		AB14272E.AutoSize = true;
		AB14272E.Location = new System.Drawing.Point(5, 5);
		AB14272E.Name = "lblComment";
		AB14272E.Size = new System.Drawing.Size(139, 16);
		AB14272E.TabIndex = 0;
		AB14272E.Text = "Nội dung bình luận (0):";
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(3, 399);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(64, 16);
		label13.TabIndex = 2;
		label13.Text = "Tùy chọn:";
		txtContent.Location = new System.Drawing.Point(6, 24);
		txtContent.Name = "txtContent";
		txtContent.Size = new System.Drawing.Size(297, 102);
		txtContent.TabIndex = 1;
		txtContent.Text = "";
		txtContent.WordWrap = false;
		txtContent.TextChanged += new System.EventHandler(txtContent_TextChanged);
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(4, 129);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(143, 16);
		label12.TabIndex = 0;
		label12.Text = "(Spin nội dung {a|b|c})";
		label14.AutoSize = true;
		label14.Location = new System.Drawing.Point(4, 156);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(64, 16);
		label14.TabIndex = 2;
		label14.Text = "Tùy chọn:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(419, 346);
		base.Controls.Add(bunifuCards1);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhTaiKhoan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(D028D499);
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		pnlReplyComment.ResumeLayout(false);
		pnlReplyComment.PerformLayout();
		FD8802BD.ResumeLayout(false);
		FD8802BD.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CD3A649F).EndInit();
		((System.ComponentModel.ISupportInitialize)D7B43A99).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayReplyTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayReplyFrom).EndInit();
		plCrawlPostGroup.ResumeLayout(false);
		plCrawlPostGroup.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTurn).EndInit();
		((System.ComponentModel.ISupportInitialize)F427C83F).EndInit();
		((System.ComponentModel.ISupportInitialize)F0184427).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountPostTurn).EndInit();
		plCommentText.ResumeLayout(false);
		plCommentText.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		ResumeLayout(false);
	}
}
