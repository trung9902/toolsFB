using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class ucTuongTacBaiVietv2 : UserControl
{
	internal GClass4 E533651C;

	internal List<CheckBox> list_0;

	internal IContainer C4A05C0B = null;

	internal Panel panel2;

	internal Panel plShareWall;

	internal NumericUpDown nudPercentShareWall;

	internal Label label15;

	internal Label label4;

	internal NumericUpDown E6B166A5;

	internal CheckBox ckbInteract;

	internal NumericUpDown nudTimeFrom;

	internal Label E223742B;

	internal CheckBox ckbComment;

	internal CheckBox A114D13F;

	internal CheckBox ckbSendAnh;

	internal Panel plInteract;

	internal NumericUpDown nudPercentLike;

	internal CheckBox ckbAngry;

	internal Label CC18E82A;

	internal CheckBox ckbSad;

	internal CheckBox ckbWow;

	internal CheckBox BB96E704;

	internal CheckBox F8A38F88;

	internal CheckBox ckbLove;

	internal CheckBox F0A1BA8D;

	internal Panel panel7;

	internal RadioButton radioButton3;

	internal RadioButton radioButton4;

	internal Label BD3D0482;

	internal Panel plAnh;

	internal NumericUpDown nudPercentCommentImage;

	internal TextBox txtAnh;

	internal Label label14;

	internal Label B6AAD29A;

	internal Panel plComment;

	internal NumericUpDown nudPercentCommentText;

	internal ComboBox cbbTuyChonNoiDung;

	internal Label label13;

	internal Button btnHuongDanNhapNoiDung;

	internal Label label8;

	internal Button btnDown;

	internal Button btnUp;

	internal RichTextBox txtComment;

	internal Label B62395AA;

	internal CheckBox CD11EF0F;

	internal TabControl tabControl1;

	internal TabPage tabCommentText;

	internal TabPage tabCommentAI;

	internal ComboBox cbbPrompt;

	internal Label E688FA8A;

	internal CheckBox DDBD9E2F;

	internal Button A03E6335;

	public ucTuongTacBaiVietv2()
	{
		InitializeComponent();
	}

	public ucTuongTacBaiVietv2(GClass4 gclass4_0)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		E533651C = gclass4_0;
		list_0 = new List<CheckBox> { F0A1BA8D, ckbLove, F8A38F88, BB96E704, ckbWow, ckbSad, ckbAngry };
	}

	private void ckbInteract_CheckedChanged(object sender, EventArgs e)
	{
		plInteract.Enabled = ckbInteract.Checked;
	}

	private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbSendAnh.Checked;
	}

	private void D30B7231(object sender, EventArgs e)
	{
		plComment.Enabled = ckbComment.Checked;
		DDBD9E2F.Enabled = ckbComment.Checked;
	}

	private void A114D13F_CheckedChanged(object sender, EventArgs e)
	{
		plShareWall.Enabled = A114D13F.Checked;
	}

	private void B1BAF128(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, B62395AA, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, B62395AA, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtComment.Focus();
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		List<GClass10> list = GClass9.EC28DF14();
		foreach (GClass10 item in list)
		{
			dictionary.Add(item.String_0.ToString(), item.String_1.ToString());
		}
		Commom.smethod_24(cbbPrompt, dictionary);
	}

	private void ucTuongTacBaiVietv2_Load(object sender, EventArgs e)
	{
		ED802D3E();
		method_0();
		try
		{
			nudTimeFrom.Value = E533651C.method_2("nudTimeFrom", 3);
			E6B166A5.Value = E533651C.method_2("nudTimeTo", 5);
			ckbInteract.Checked = E533651C.method_3("ckbInteract");
			nudPercentLike.Value = E533651C.method_2("nudPercentLike", 100);
			string text = E533651C.BDB80B23("typeReaction", "Like");
			List<string> list = text.Split('|').ToList();
			for (int i = 0; i < list.Count; i++)
			{
				foreach (CheckBox item in list_0)
				{
					if (item.Name.Substring(3) == list[i])
					{
						item.Checked = true;
					}
				}
			}
			A114D13F.Checked = E533651C.method_3("ckbShareWall");
			nudPercentShareWall.Value = E533651C.method_2("nudPercentShareWall", 100);
			ckbSendAnh.Checked = E533651C.method_3("ckbSendAnh");
			nudPercentCommentImage.Value = E533651C.method_2("nudPercentCommentImage", 100);
			txtAnh.Text = E533651C.BDB80B23("txtAnh");
			ckbComment.Checked = E533651C.method_3("ckbComment");
			nudPercentCommentText.Value = E533651C.method_2("nudPercentCommentText", 100);
			txtComment.Text = E533651C.BDB80B23("txtComment");
			cbbTuyChonNoiDung.SelectedIndex = E533651C.method_2("typeNganCach");
			CD11EF0F.Checked = E533651C.method_3("ckbAutoDeleteComment");
			DDBD9E2F.Checked = E533651C.method_3("ckbTaoNoiDungAI");
			try
			{
				cbbPrompt.SelectedValue = E533651C.BDB80B23("cbbPrompt");
			}
			catch (Exception)
			{
			}
		}
		catch
		{
		}
		method_1();
	}

	private void ED802D3E()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list);
	}

	private void method_1()
	{
		ckbInteract_CheckedChanged(null, null);
		D30B7231(null, null);
		ckbSendAnh_CheckedChanged(null, null);
		A114D13F_CheckedChanged(null, null);
		EE8690B7(null, null);
	}

	public GClass4 method_2()
	{
		E533651C.method_4("nudTimeFrom", nudTimeFrom.Value);
		E533651C.method_4("nudTimeTo", E6B166A5.Value);
		E533651C.method_4("ckbInteract", ckbInteract.Checked);
		E533651C.method_4("nudPercentLike", nudPercentLike.Value);
		string text = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text = text + list_0[i].Name.Substring(3) + "|";
			}
		}
		E533651C.method_4("typeReaction", text.TrimEnd('|'));
		E533651C.method_4("ckbSendAnh", ckbSendAnh.Checked);
		E533651C.method_4("nudPercentCommentImage", nudPercentCommentImage.Value);
		E533651C.method_4("txtAnh", txtAnh.Text.Trim());
		E533651C.method_4("ckbShareWall", A114D13F.Checked);
		E533651C.method_4("nudPercentShareWall", nudPercentShareWall.Value);
		E533651C.method_4("ckbComment", ckbComment.Checked);
		E533651C.method_4("nudPercentCommentText", nudPercentCommentText.Value);
		E533651C.method_4("txtComment", txtComment.Text.Trim());
		E533651C.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		E533651C.method_4("ckbAutoDeleteComment", CD11EF0F.Checked);
		E533651C.method_4("ckbTaoNoiDungAI", DDBD9E2F.Checked);
		E533651C.method_4("cbbPrompt", cbbPrompt.SelectedValue ?? "");
		return E533651C;
	}

	private void BBB63C1C(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCauHinhAI(cbbPrompt.SelectedValue?.ToString()));
	}

	private void EE8690B7(object sender, EventArgs e)
	{
		tabControl1.SelectedTab = (DDBD9E2F.Checked ? tabCommentAI : tabCommentText);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && C4A05C0B != null)
		{
			C4A05C0B.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		panel2 = new System.Windows.Forms.Panel();
		plShareWall = new System.Windows.Forms.Panel();
		nudPercentShareWall = new System.Windows.Forms.NumericUpDown();
		label15 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		E6B166A5 = new System.Windows.Forms.NumericUpDown();
		ckbInteract = new System.Windows.Forms.CheckBox();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		E223742B = new System.Windows.Forms.Label();
		DDBD9E2F = new System.Windows.Forms.CheckBox();
		ckbComment = new System.Windows.Forms.CheckBox();
		A114D13F = new System.Windows.Forms.CheckBox();
		ckbSendAnh = new System.Windows.Forms.CheckBox();
		plInteract = new System.Windows.Forms.Panel();
		nudPercentLike = new System.Windows.Forms.NumericUpDown();
		ckbAngry = new System.Windows.Forms.CheckBox();
		CC18E82A = new System.Windows.Forms.Label();
		ckbSad = new System.Windows.Forms.CheckBox();
		ckbWow = new System.Windows.Forms.CheckBox();
		BB96E704 = new System.Windows.Forms.CheckBox();
		F8A38F88 = new System.Windows.Forms.CheckBox();
		ckbLove = new System.Windows.Forms.CheckBox();
		F0A1BA8D = new System.Windows.Forms.CheckBox();
		panel7 = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		radioButton4 = new System.Windows.Forms.RadioButton();
		BD3D0482 = new System.Windows.Forms.Label();
		plAnh = new System.Windows.Forms.Panel();
		nudPercentCommentImage = new System.Windows.Forms.NumericUpDown();
		txtAnh = new System.Windows.Forms.TextBox();
		label14 = new System.Windows.Forms.Label();
		B6AAD29A = new System.Windows.Forms.Label();
		plComment = new System.Windows.Forms.Panel();
		tabControl1 = new System.Windows.Forms.TabControl();
		tabCommentText = new System.Windows.Forms.TabPage();
		nudPercentCommentText = new System.Windows.Forms.NumericUpDown();
		label13 = new System.Windows.Forms.Label();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		B62395AA = new System.Windows.Forms.Label();
		txtComment = new System.Windows.Forms.RichTextBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		btnUp = new System.Windows.Forms.Button();
		label8 = new System.Windows.Forms.Label();
		btnDown = new System.Windows.Forms.Button();
		tabCommentAI = new System.Windows.Forms.TabPage();
		A03E6335 = new System.Windows.Forms.Button();
		cbbPrompt = new System.Windows.Forms.ComboBox();
		E688FA8A = new System.Windows.Forms.Label();
		CD11EF0F = new System.Windows.Forms.CheckBox();
		panel2.SuspendLayout();
		plShareWall.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentShareWall).BeginInit();
		((System.ComponentModel.ISupportInitialize)E6B166A5).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		plInteract.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentLike).BeginInit();
		panel7.SuspendLayout();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentCommentImage).BeginInit();
		plComment.SuspendLayout();
		tabControl1.SuspendLayout();
		tabCommentText.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentCommentText).BeginInit();
		tabCommentAI.SuspendLayout();
		SuspendLayout();
		panel2.Controls.Add(plShareWall);
		panel2.Controls.Add(label4);
		panel2.Controls.Add(E6B166A5);
		panel2.Controls.Add(ckbInteract);
		panel2.Controls.Add(nudTimeFrom);
		panel2.Controls.Add(E223742B);
		panel2.Controls.Add(DDBD9E2F);
		panel2.Controls.Add(ckbComment);
		panel2.Controls.Add(A114D13F);
		panel2.Controls.Add(ckbSendAnh);
		panel2.Controls.Add(plInteract);
		panel2.Controls.Add(plAnh);
		panel2.Controls.Add(plComment);
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(656, 266);
		panel2.TabIndex = 194;
		plShareWall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plShareWall.Controls.Add(nudPercentShareWall);
		plShareWall.Controls.Add(label15);
		plShareWall.Location = new System.Drawing.Point(6, 230);
		plShareWall.Name = "plShareWall";
		plShareWall.Size = new System.Drawing.Size(313, 29);
		plShareWall.TabIndex = 197;
		nudPercentShareWall.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		nudPercentShareWall.Location = new System.Drawing.Point(112, 2);
		nudPercentShareWall.Name = "nudPercentShareWall";
		nudPercentShareWall.Size = new System.Drawing.Size(42, 23);
		nudPercentShareWall.TabIndex = 189;
		nudPercentShareWall.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(1, 5);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(112, 16);
		label15.TabIndex = 191;
		label15.Text = "Xa\u0301c suâ\u0301t la\u0300m (%):";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(3, 7);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(103, 16);
		label4.TabIndex = 191;
		label4.Text = "Xem bài viết (s):";
		E6B166A5.Location = new System.Drawing.Point(205, 5);
		E6B166A5.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E6B166A5.Name = "nudTimeTo";
		E6B166A5.Size = new System.Drawing.Size(56, 23);
		E6B166A5.TabIndex = 190;
		ckbInteract.AutoSize = true;
		ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbInteract.Location = new System.Drawing.Point(6, 30);
		ckbInteract.Name = "ckbInteract";
		ckbInteract.Size = new System.Drawing.Size(99, 20);
		ckbInteract.TabIndex = 182;
		ckbInteract.Text = "Thả cảm xúc";
		ckbInteract.UseVisualStyleBackColor = true;
		ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
		nudTimeFrom.Location = new System.Drawing.Point(108, 5);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(56, 23);
		nudTimeFrom.TabIndex = 189;
		E223742B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E223742B.Location = new System.Drawing.Point(170, 7);
		E223742B.Name = "label9";
		E223742B.Size = new System.Drawing.Size(29, 16);
		E223742B.TabIndex = 192;
		E223742B.Text = ">";
		E223742B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DDBD9E2F.AutoSize = true;
		DDBD9E2F.Cursor = System.Windows.Forms.Cursors.Hand;
		DDBD9E2F.Location = new System.Drawing.Point(496, 30);
		DDBD9E2F.Name = "ckbTaoNoiDungAI";
		DDBD9E2F.Size = new System.Drawing.Size(149, 20);
		DDBD9E2F.TabIndex = 184;
		DDBD9E2F.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		DDBD9E2F.UseVisualStyleBackColor = true;
		DDBD9E2F.CheckedChanged += new System.EventHandler(EE8690B7);
		ckbComment.AutoSize = true;
		ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbComment.Location = new System.Drawing.Point(347, 30);
		ckbComment.Name = "ckbComment";
		ckbComment.Size = new System.Drawing.Size(127, 20);
		ckbComment.TabIndex = 184;
		ckbComment.Text = "Bi\u0300nh luâ\u0323n văn bản";
		ckbComment.UseVisualStyleBackColor = true;
		ckbComment.CheckedChanged += new System.EventHandler(D30B7231);
		A114D13F.AutoSize = true;
		A114D13F.Cursor = System.Windows.Forms.Cursors.Hand;
		A114D13F.Location = new System.Drawing.Point(6, 208);
		A114D13F.Name = "ckbShareWall";
		A114D13F.Size = new System.Drawing.Size(87, 20);
		A114D13F.TabIndex = 183;
		A114D13F.Text = "Share wall";
		A114D13F.UseVisualStyleBackColor = true;
		A114D13F.CheckedChanged += new System.EventHandler(A114D13F_CheckedChanged);
		ckbSendAnh.AutoSize = true;
		ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSendAnh.Location = new System.Drawing.Point(6, 118);
		ckbSendAnh.Name = "ckbSendAnh";
		ckbSendAnh.Size = new System.Drawing.Size(103, 20);
		ckbSendAnh.TabIndex = 186;
		ckbSendAnh.Text = "Bình luận ảnh";
		ckbSendAnh.UseVisualStyleBackColor = true;
		ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
		plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plInteract.Controls.Add(nudPercentLike);
		plInteract.Controls.Add(ckbAngry);
		plInteract.Controls.Add(CC18E82A);
		plInteract.Controls.Add(ckbSad);
		plInteract.Controls.Add(ckbWow);
		plInteract.Controls.Add(BB96E704);
		plInteract.Controls.Add(F8A38F88);
		plInteract.Controls.Add(ckbLove);
		plInteract.Controls.Add(F0A1BA8D);
		plInteract.Controls.Add(panel7);
		plInteract.Controls.Add(BD3D0482);
		plInteract.Location = new System.Drawing.Point(6, 52);
		plInteract.Name = "plInteract";
		plInteract.Size = new System.Drawing.Size(313, 60);
		plInteract.TabIndex = 188;
		nudPercentLike.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		nudPercentLike.Location = new System.Drawing.Point(112, 4);
		nudPercentLike.Name = "nudPercentLike";
		nudPercentLike.Size = new System.Drawing.Size(42, 23);
		nudPercentLike.TabIndex = 189;
		nudPercentLike.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		ckbAngry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbAngry.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAngry.Image = Class155.Bitmap_11;
		ckbAngry.Location = new System.Drawing.Point(269, 28);
		ckbAngry.Name = "ckbAngry";
		ckbAngry.Size = new System.Drawing.Size(40, 30);
		ckbAngry.TabIndex = 179;
		ckbAngry.Tag = "Angry";
		ckbAngry.UseVisualStyleBackColor = true;
		CC18E82A.AutoSize = true;
		CC18E82A.Location = new System.Drawing.Point(3, 6);
		CC18E82A.Name = "label11";
		CC18E82A.Size = new System.Drawing.Size(112, 16);
		CC18E82A.TabIndex = 191;
		CC18E82A.Text = "Xa\u0301c suâ\u0301t la\u0300m (%):";
		ckbSad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbSad.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSad.Image = Class155.E1938320;
		ckbSad.Location = new System.Drawing.Point(225, 28);
		ckbSad.Name = "ckbSad";
		ckbSad.Size = new System.Drawing.Size(40, 30);
		ckbSad.TabIndex = 178;
		ckbSad.Tag = "Sad";
		ckbSad.UseVisualStyleBackColor = true;
		ckbWow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbWow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWow.Image = Class155.Bitmap_181;
		ckbWow.Location = new System.Drawing.Point(181, 28);
		ckbWow.Name = "ckbWow";
		ckbWow.Size = new System.Drawing.Size(40, 30);
		ckbWow.TabIndex = 177;
		ckbWow.Tag = "Wow";
		ckbWow.UseVisualStyleBackColor = true;
		BB96E704.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BB96E704.Cursor = System.Windows.Forms.Cursors.Hand;
		BB96E704.Image = Class155.E982D419;
		BB96E704.Location = new System.Drawing.Point(137, 28);
		BB96E704.Name = "ckbHaha";
		BB96E704.Size = new System.Drawing.Size(40, 30);
		BB96E704.TabIndex = 176;
		BB96E704.Tag = "Haha";
		BB96E704.UseVisualStyleBackColor = true;
		F8A38F88.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F8A38F88.Cursor = System.Windows.Forms.Cursors.Hand;
		F8A38F88.Image = Class155.Bitmap_20;
		F8A38F88.Location = new System.Drawing.Point(93, 28);
		F8A38F88.Name = "ckbCare";
		F8A38F88.Size = new System.Drawing.Size(40, 30);
		F8A38F88.TabIndex = 175;
		F8A38F88.Tag = "Care";
		F8A38F88.UseVisualStyleBackColor = true;
		ckbLove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbLove.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLove.Image = Class155.AB95A212;
		ckbLove.Location = new System.Drawing.Point(49, 28);
		ckbLove.Name = "ckbLove";
		ckbLove.Size = new System.Drawing.Size(40, 30);
		ckbLove.TabIndex = 174;
		ckbLove.Tag = "Love";
		ckbLove.UseVisualStyleBackColor = true;
		F0A1BA8D.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F0A1BA8D.Cursor = System.Windows.Forms.Cursors.Hand;
		F0A1BA8D.Image = Class155.Bitmap_166;
		F0A1BA8D.Location = new System.Drawing.Point(5, 28);
		F0A1BA8D.Name = "ckbLike";
		F0A1BA8D.Size = new System.Drawing.Size(40, 30);
		F0A1BA8D.TabIndex = 173;
		F0A1BA8D.Tag = "Like";
		F0A1BA8D.UseVisualStyleBackColor = true;
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
		BD3D0482.AutoSize = true;
		BD3D0482.Location = new System.Drawing.Point(4, 302);
		BD3D0482.Name = "label26";
		BD3D0482.Size = new System.Drawing.Size(64, 16);
		BD3D0482.TabIndex = 2;
		BD3D0482.Text = "Tùy chọn:";
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(nudPercentCommentImage);
		plAnh.Controls.Add(txtAnh);
		plAnh.Controls.Add(label14);
		plAnh.Controls.Add(B6AAD29A);
		plAnh.Enabled = false;
		plAnh.Location = new System.Drawing.Point(6, 140);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(313, 63);
		plAnh.TabIndex = 187;
		nudPercentCommentImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		nudPercentCommentImage.Location = new System.Drawing.Point(112, 5);
		nudPercentCommentImage.Name = "nudPercentCommentImage";
		nudPercentCommentImage.Size = new System.Drawing.Size(42, 23);
		nudPercentCommentImage.TabIndex = 189;
		nudPercentCommentImage.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		txtAnh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtAnh.Location = new System.Drawing.Point(112, 33);
		txtAnh.Name = "txtAnh";
		txtAnh.Size = new System.Drawing.Size(193, 23);
		txtAnh.TabIndex = 159;
		label14.AutoSize = true;
		label14.Location = new System.Drawing.Point(3, 7);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(112, 16);
		label14.TabIndex = 191;
		label14.Text = "Xa\u0301c suâ\u0301t la\u0300m (%):";
		B6AAD29A.AutoSize = true;
		B6AAD29A.Location = new System.Drawing.Point(3, 36);
		B6AAD29A.Name = "label12";
		B6AAD29A.Size = new System.Drawing.Size(73, 16);
		B6AAD29A.TabIndex = 158;
		B6AAD29A.Text = "Folder ảnh:";
		plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plComment.Controls.Add(tabControl1);
		plComment.Controls.Add(CD11EF0F);
		plComment.Location = new System.Drawing.Point(347, 52);
		plComment.Name = "plComment";
		plComment.Size = new System.Drawing.Size(302, 207);
		plComment.TabIndex = 185;
		tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabControl1.Controls.Add(tabCommentText);
		tabControl1.Controls.Add(tabCommentAI);
		tabControl1.Location = new System.Drawing.Point(-7, -6);
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.Size = new System.Drawing.Size(320, 237);
		tabControl1.TabIndex = 198;
		tabCommentText.Controls.Add(nudPercentCommentText);
		tabCommentText.Controls.Add(label13);
		tabCommentText.Controls.Add(cbbTuyChonNoiDung);
		tabCommentText.Controls.Add(B62395AA);
		tabCommentText.Controls.Add(txtComment);
		tabCommentText.Controls.Add(btnHuongDanNhapNoiDung);
		tabCommentText.Controls.Add(btnUp);
		tabCommentText.Controls.Add(label8);
		tabCommentText.Controls.Add(btnDown);
		tabCommentText.Location = new System.Drawing.Point(4, 4);
		tabCommentText.Name = "tabCommentText";
		tabCommentText.Padding = new System.Windows.Forms.Padding(3);
		tabCommentText.Size = new System.Drawing.Size(312, 208);
		tabCommentText.TabIndex = 0;
		tabCommentText.Text = "Comment text";
		tabCommentText.UseVisualStyleBackColor = true;
		nudPercentCommentText.Location = new System.Drawing.Point(115, 7);
		nudPercentCommentText.Name = "nudPercentCommentText";
		nudPercentCommentText.Size = new System.Drawing.Size(42, 23);
		nudPercentCommentText.TabIndex = 189;
		nudPercentCommentText.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(6, 9);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(112, 16);
		label13.TabIndex = 191;
		label13.Text = "Xa\u0301c suâ\u0301t la\u0300m (%):";
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(72, 178);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(193, 24);
		cbbTuyChonNoiDung.TabIndex = 195;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		B62395AA.AutoSize = true;
		B62395AA.Location = new System.Drawing.Point(6, 34);
		B62395AA.Name = "lblComment";
		B62395AA.Size = new System.Drawing.Size(139, 16);
		B62395AA.TabIndex = 0;
		B62395AA.Text = "Nội dung bình luận (0):";
		txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtComment.Location = new System.Drawing.Point(10, 54);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(287, 119);
		txtComment.TabIndex = 1;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(B1BAF128);
		btnHuongDanNhapNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(271, 177);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 194;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		btnUp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnUp.BackgroundImage = Class155.B116C210;
		btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
		btnUp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnUp.Location = new System.Drawing.Point(279, 1);
		btnUp.Name = "btnUp";
		btnUp.Size = new System.Drawing.Size(25, 25);
		btnUp.TabIndex = 192;
		btnUp.Visible = false;
		label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(6, 181);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 193;
		label8.Text = "Tùy chọn:";
		btnDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnDown.BackgroundImage = Class155.Bitmap_94;
		btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnDown.Location = new System.Drawing.Point(248, 1);
		btnDown.Name = "btnDown";
		btnDown.Size = new System.Drawing.Size(25, 25);
		btnDown.TabIndex = 191;
		btnDown.Visible = false;
		tabCommentAI.Controls.Add(A03E6335);
		tabCommentAI.Controls.Add(cbbPrompt);
		tabCommentAI.Controls.Add(E688FA8A);
		tabCommentAI.Location = new System.Drawing.Point(4, 4);
		tabCommentAI.Name = "tabCommentAI";
		tabCommentAI.Padding = new System.Windows.Forms.Padding(3);
		tabCommentAI.Size = new System.Drawing.Size(312, 190);
		tabCommentAI.TabIndex = 1;
		tabCommentAI.Text = "Comment AI";
		tabCommentAI.UseVisualStyleBackColor = true;
		A03E6335.Cursor = System.Windows.Forms.Cursors.Hand;
		A03E6335.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A03E6335.Location = new System.Drawing.Point(267, 5);
		A03E6335.Name = "btnPrompt";
		A03E6335.Size = new System.Drawing.Size(33, 27);
		A03E6335.TabIndex = 34;
		A03E6335.Text = "...";
		A03E6335.UseVisualStyleBackColor = true;
		A03E6335.Click += new System.EventHandler(BBB63C1C);
		cbbPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbPrompt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbPrompt.DropDownWidth = 120;
		cbbPrompt.FormattingEnabled = true;
		cbbPrompt.Location = new System.Drawing.Point(97, 6);
		cbbPrompt.Name = "cbbPrompt";
		cbbPrompt.Size = new System.Drawing.Size(164, 24);
		cbbPrompt.TabIndex = 33;
		E688FA8A.AutoSize = true;
		E688FA8A.Location = new System.Drawing.Point(6, 9);
		E688FA8A.Name = "label2";
		E688FA8A.Size = new System.Drawing.Size(86, 16);
		E688FA8A.TabIndex = 32;
		E688FA8A.Text = "Cho\u0323n Prompt:";
		CD11EF0F.AutoSize = true;
		CD11EF0F.Cursor = System.Windows.Forms.Cursors.Hand;
		CD11EF0F.Location = new System.Drawing.Point(7, 209);
		CD11EF0F.Name = "ckbAutoDeleteComment";
		CD11EF0F.Size = new System.Drawing.Size(169, 20);
		CD11EF0F.TabIndex = 8;
		CD11EF0F.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		CD11EF0F.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(panel2);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucTuongTacBaiVietv2";
		base.Size = new System.Drawing.Size(656, 266);
		base.Load += new System.EventHandler(ucTuongTacBaiVietv2_Load);
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		plShareWall.ResumeLayout(false);
		plShareWall.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentShareWall).EndInit();
		((System.ComponentModel.ISupportInitialize)E6B166A5).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		plInteract.ResumeLayout(false);
		plInteract.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentLike).EndInit();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentCommentImage).EndInit();
		plComment.ResumeLayout(false);
		plComment.PerformLayout();
		tabControl1.ResumeLayout(false);
		tabCommentText.ResumeLayout(false);
		tabCommentText.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudPercentCommentText).EndInit();
		tabCommentAI.ResumeLayout(false);
		tabCommentAI.PerformLayout();
		ResumeLayout(false);
	}
}
