using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ucTuongTacReel : UserControl
{
	internal GClass4 B7200221;

	internal IContainer icontainer_0 = null;

	internal Button D828ED3C;

	internal Button DB9F819B;

	internal Panel plComment;

	internal RichTextBox txtComment;

	internal Label D016450C;

	internal CheckBox ckbComment;

	internal CheckBox ckbShareWall;

	internal CheckBox ckbInteract;

	internal NumericUpDown nudTimeTo;

	internal NumericUpDown nudTimeFrom;

	internal Label C7A43B11;

	internal Label label14;

	internal Label label21;

	internal Label label3;

	internal Label A3004DA1;

	internal ComboBox CE9B3829;

	internal Button btnHuongDanNhapNoiDung;

	public ucTuongTacReel(GClass4 gclass4_0)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		B7200221 = gclass4_0;
	}

	private void DB9F819B_Click(object sender, EventArgs e)
	{
		Hide();
	}

	private void D828ED3C_Click(object sender, EventArgs e)
	{
		D411489F();
		Hide();
	}

	private void E0396E25()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(CE9B3829, list_);
	}

	private void method_0()
	{
		try
		{
			E0396E25();
			nudTimeFrom.Value = B7200221.method_2("nudTimeFrom", 15);
			nudTimeTo.Value = B7200221.method_2("nudTimeTo", 30);
			ckbInteract.Checked = B7200221.method_3("ckbInteract");
			ckbComment.Checked = B7200221.method_3("ckbComment");
			ckbShareWall.Checked = B7200221.method_3("ckbShareWall");
			txtComment.Text = B7200221.BDB80B23("txtComment");
			CE9B3829.SelectedIndex = B7200221.method_2("typeNganCachCommentReel");
			ckbComment_CheckedChanged(null, null);
		}
		catch
		{
		}
	}

	private void D411489F()
	{
		B7200221.method_4("nudTimeFrom", nudTimeFrom.Value);
		B7200221.method_4("nudTimeTo", nudTimeTo.Value);
		B7200221.method_4("ckbInteract", ckbInteract.Checked);
		B7200221.method_4("ckbShareWall", ckbShareWall.Checked);
		B7200221.method_4("ckbComment", ckbComment.Checked);
		B7200221.method_4("txtComment", txtComment.Text.Trim());
		B7200221.method_4("typeNganCachCommentReel", CE9B3829.SelectedIndex);
	}

	private void E2334137(object sender, EventArgs e)
	{
		method_0();
	}

	private void ucTuongTacReel_VisibleChanged(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			method_0();
		}
	}

	private void ckbComment_CheckedChanged(object sender, EventArgs e)
	{
		plComment.Enabled = ckbComment.Checked;
	}

	private void EA1E503C(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, D016450C, CE9B3829.SelectedIndex);
	}

	private void method_1(object sender, EventArgs e)
	{
		MsBoxHelper.Show(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
		txtComment.Focus();
	}

	private void method_2(object sender, EventArgs e)
	{
		Commom.smethod_35(new fHelpNhapComment());
		txtComment.Focus();
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (CE9B3829.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtComment.Focus();
	}

	private void CE9B3829_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, D016450C, CE9B3829.SelectedIndex);
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
		D828ED3C = new System.Windows.Forms.Button();
		DB9F819B = new System.Windows.Forms.Button();
		plComment = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		A3004DA1 = new System.Windows.Forms.Label();
		txtComment = new System.Windows.Forms.RichTextBox();
		D016450C = new System.Windows.Forms.Label();
		ckbComment = new System.Windows.Forms.CheckBox();
		ckbShareWall = new System.Windows.Forms.CheckBox();
		ckbInteract = new System.Windows.Forms.CheckBox();
		nudTimeTo = new System.Windows.Forms.NumericUpDown();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		C7A43B11 = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		label21 = new System.Windows.Forms.Label();
		CE9B3829 = new System.Windows.Forms.ComboBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		plComment.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		SuspendLayout();
		D828ED3C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D828ED3C.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		D828ED3C.Cursor = System.Windows.Forms.Cursors.Hand;
		D828ED3C.FlatAppearance.BorderSize = 0;
		D828ED3C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D828ED3C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D828ED3C.ForeColor = System.Drawing.Color.White;
		D828ED3C.Location = new System.Drawing.Point(71, 383);
		D828ED3C.Name = "btnSave";
		D828ED3C.Size = new System.Drawing.Size(92, 29);
		D828ED3C.TabIndex = 180;
		D828ED3C.Text = "Lưu";
		D828ED3C.UseVisualStyleBackColor = false;
		D828ED3C.Click += new System.EventHandler(D828ED3C_Click);
		DB9F819B.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		DB9F819B.BackColor = System.Drawing.Color.Maroon;
		DB9F819B.Cursor = System.Windows.Forms.Cursors.Hand;
		DB9F819B.FlatAppearance.BorderSize = 0;
		DB9F819B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DB9F819B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DB9F819B.ForeColor = System.Drawing.Color.White;
		DB9F819B.Location = new System.Drawing.Point(181, 383);
		DB9F819B.Name = "btnCancel";
		DB9F819B.Size = new System.Drawing.Size(92, 29);
		DB9F819B.TabIndex = 181;
		DB9F819B.Text = "Đóng";
		DB9F819B.UseVisualStyleBackColor = false;
		DB9F819B.Click += new System.EventHandler(DB9F819B_Click);
		plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plComment.Controls.Add(CE9B3829);
		plComment.Controls.Add(btnHuongDanNhapNoiDung);
		plComment.Controls.Add(label3);
		plComment.Controls.Add(A3004DA1);
		plComment.Controls.Add(txtComment);
		plComment.Controls.Add(D016450C);
		plComment.Location = new System.Drawing.Point(37, 98);
		plComment.Name = "plComment";
		plComment.Size = new System.Drawing.Size(278, 268);
		plComment.TabIndex = 187;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(2, 240);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(64, 16);
		label3.TabIndex = 181;
		label3.Text = "Tùy chọn:";
		A3004DA1.AutoSize = true;
		A3004DA1.Location = new System.Drawing.Point(3, 218);
		A3004DA1.Name = "label11";
		A3004DA1.Size = new System.Drawing.Size(133, 16);
		A3004DA1.TabIndex = 180;
		A3004DA1.Text = "Spin nội dung {a|b|c}";
		txtComment.Location = new System.Drawing.Point(6, 24);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(264, 191);
		txtComment.TabIndex = 45;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(EA1E503C);
		D016450C.AutoSize = true;
		D016450C.Location = new System.Drawing.Point(3, 5);
		D016450C.Name = "lblComment";
		D016450C.Size = new System.Drawing.Size(139, 16);
		D016450C.TabIndex = 0;
		D016450C.Text = "Nội dung bình luận (0):";
		ckbComment.AutoSize = true;
		ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbComment.Location = new System.Drawing.Point(19, 72);
		ckbComment.Name = "ckbComment";
		ckbComment.Size = new System.Drawing.Size(81, 20);
		ckbComment.TabIndex = 186;
		ckbComment.Text = "Comment";
		ckbComment.UseVisualStyleBackColor = true;
		ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
		ckbShareWall.AutoSize = true;
		ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShareWall.Location = new System.Drawing.Point(121, 46);
		ckbShareWall.Name = "ckbShareWall";
		ckbShareWall.Size = new System.Drawing.Size(89, 20);
		ckbShareWall.TabIndex = 185;
		ckbShareWall.Text = "Share Wall";
		ckbShareWall.UseVisualStyleBackColor = true;
		ckbInteract.AutoSize = true;
		ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbInteract.Location = new System.Drawing.Point(19, 46);
		ckbInteract.Name = "ckbInteract";
		ckbInteract.Size = new System.Drawing.Size(48, 20);
		ckbInteract.TabIndex = 184;
		ckbInteract.Text = "Like";
		ckbInteract.UseVisualStyleBackColor = true;
		nudTimeTo.Location = new System.Drawing.Point(218, 17);
		nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeTo.Name = "nudTimeTo";
		nudTimeTo.Size = new System.Drawing.Size(56, 23);
		nudTimeTo.TabIndex = 183;
		nudTimeFrom.Location = new System.Drawing.Point(121, 17);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(56, 23);
		nudTimeFrom.TabIndex = 182;
		C7A43B11.Location = new System.Drawing.Point(183, 19);
		C7A43B11.Name = "label13";
		C7A43B11.Size = new System.Drawing.Size(29, 16);
		C7A43B11.TabIndex = 190;
		C7A43B11.Text = "đê\u0301n";
		C7A43B11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label14.AutoSize = true;
		label14.Location = new System.Drawing.Point(279, 19);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(30, 16);
		label14.TabIndex = 189;
		label14.Text = "giây";
		label21.AutoSize = true;
		label21.Location = new System.Drawing.Point(16, 19);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(93, 16);
		label21.TabIndex = 188;
		label21.Text = "Thơ\u0300i gian xem:";
		CE9B3829.Cursor = System.Windows.Forms.Cursors.Hand;
		CE9B3829.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		CE9B3829.FormattingEnabled = true;
		CE9B3829.Location = new System.Drawing.Point(68, 237);
		CE9B3829.Name = "cbbTuyChonNoiDung";
		CE9B3829.Size = new System.Drawing.Size(170, 24);
		CE9B3829.TabIndex = 184;
		CE9B3829.SelectedIndexChanged += new System.EventHandler(CE9B3829_SelectedIndexChanged);
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(244, 236);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 183;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		base.Controls.Add(plComment);
		base.Controls.Add(ckbComment);
		base.Controls.Add(ckbShareWall);
		base.Controls.Add(ckbInteract);
		base.Controls.Add(nudTimeTo);
		base.Controls.Add(nudTimeFrom);
		base.Controls.Add(C7A43B11);
		base.Controls.Add(label14);
		base.Controls.Add(label21);
		base.Controls.Add(D828ED3C);
		base.Controls.Add(DB9F819B);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Name = "ucTuongTacReel";
		base.Size = new System.Drawing.Size(340, 425);
		base.Load += new System.EventHandler(E2334137);
		base.VisibleChanged += new System.EventHandler(ucTuongTacReel_VisibleChanged);
		plComment.ResumeLayout(false);
		plComment.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
