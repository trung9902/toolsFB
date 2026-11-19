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

public class fHDTuongTacLivestream : Form
{
	internal GClass4 gclass4_0;

	internal List<CheckBox> list_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown nudTimeTo;

	internal NumericUpDown nudTimeFrom;

	internal TextBox txtTenHanhDong;

	internal Label D92DB7B9;

	internal Label F2851C18;

	internal Label label1;

	internal Button B20B5BB8;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel C2A58C00;

	internal Button button1;

	internal PictureBox B315C73B;

	internal BunifuCustomLabel C19DF28D;

	internal Panel plComment;

	internal CheckBox ckbComment;

	internal CheckBox C225933D;

	internal NumericUpDown nudLapLaiTuongTacDelayTo;

	internal Label A3BF3E3A;

	internal NumericUpDown D11181BA;

	internal Label A0B9DD9D;

	internal TextBox txtLinkVideo;

	internal Label label9;

	internal CheckBox BD8FA2B7;

	internal Panel plInteract;

	internal CheckBox ckbGian;

	internal CheckBox ckbBuon;

	internal CheckBox ckbWow;

	internal CheckBox ckbHaha;

	internal CheckBox ckbThuong;

	internal CheckBox A00BF933;

	internal CheckBox ckbLike;

	internal Panel D80E4794;

	internal RadioButton radioButton3;

	internal RadioButton radioButton4;

	internal Label label26;

	internal RichTextBox CF04C19D;

	internal Label label11;

	internal Label lblComment;

	internal Panel EEBEBD15;

	internal Panel FD0157B8;

	internal RadioButton radioButton1;

	internal RadioButton radioButton2;

	internal CheckBox ckbLapLaiTuongTacInteract;

	internal CheckBox ED2FF032;

	internal Label label4;

	internal CheckBox D98DB012;

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

	public fHDTuongTacLivestream(string F9A1B487, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = F9A1B487;
		string_2 = string_3;
		string aA239C = Language.GetValue(C19DF28D.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
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
		list_0 = new List<CheckBox> { ckbLike, A00BF933, ckbThuong, ckbHaha, ckbWow, ckbBuon, ckbGian };
	}

	private void fHDTuongTacLivestream_Load(object sender, EventArgs e)
	{
		try
		{
			txtLinkVideo.Text = gclass4_0.BDB80B23("txtLinkVideo");
			nudTimeFrom.Value = gclass4_0.method_2("nudTimeFrom", 30);
			nudTimeTo.Value = gclass4_0.method_2("nudTimeTo", 30);
			C225933D.Checked = gclass4_0.method_3("ckbInteract");
			string text = gclass4_0.BDB80B23("typeReaction");
			new List<CheckBox> { ckbLike, A00BF933, ckbHaha, ckbWow, ckbBuon, ckbGian };
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Checked = text.Split('|').Contains(i.ToString());
			}
			ckbComment.Checked = gclass4_0.method_3("ckbComment");
			CF04C19D.Text = gclass4_0.BDB80B23("txtComment");
			BD8FA2B7.Checked = gclass4_0.method_3("ckbTuDongXoaNoiDung");
			D98DB012.Checked = gclass4_0.method_3("ckbLapLaiTuongTac");
			D11181BA.Value = gclass4_0.method_2("nudLapLaiTuongTacDelayFrom", 10);
			nudLapLaiTuongTacDelayTo.Value = gclass4_0.method_2("nudLapLaiTuongTacDelayTo", 10);
			ckbLapLaiTuongTacInteract.Checked = gclass4_0.method_3("ckbLapLaiTuongTacInteract");
			ED2FF032.Checked = gclass4_0.method_3("ckbLapLaiTuongTacComment");
		}
		catch
		{
		}
		method_0();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D732D1A4(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!");
			return;
		}
		if (ckbComment.Checked)
		{
			List<string> list = CF04C19D.Lines.ToList();
			list = Commom.smethod_36(list);
			if (list.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung bi\u0300nh luâ\u0323n!");
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("txtLinkVideo", txtLinkVideo.Text.Trim());
		gClass.method_4("nudTimeFrom", nudTimeFrom.Value);
		gClass.method_4("nudTimeTo", nudTimeTo.Value);
		gClass.method_4("ckbInteract", C225933D.Checked);
		string text2 = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text2 = text2 + i + "|";
			}
		}
		gClass.method_4("typeReaction", text2.TrimEnd('|'));
		gClass.method_4("ckbComment", ckbComment.Checked);
		gClass.method_4("txtComment", CF04C19D.Text.Trim());
		gClass.method_4("ckbTuDongXoaNoiDung", BD8FA2B7.Checked);
		gClass.method_4("ckbLapLaiTuongTac", D98DB012.Checked);
		gClass.method_4("nudLapLaiTuongTacDelayFrom", D11181BA.Value);
		gClass.method_4("nudLapLaiTuongTacDelayTo", nudLapLaiTuongTacDelayTo.Value);
		gClass.method_4("ckbLapLaiTuongTacInteract", ckbLapLaiTuongTacInteract.Checked);
		gClass.method_4("ckbLapLaiTuongTacComment", ED2FF032.Checked);
		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!");
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(string_2, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!");
			}
		}
	}

	private void D3AB2CAF(object sender, EventArgs e)
	{
		Close();
	}

	private void D6B45E02(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void method_0()
	{
		C225933D_CheckedChanged(null, null);
		F8194906(null, null);
		D98DB012_CheckedChanged(null, null);
	}

	private void C225933D_CheckedChanged(object sender, EventArgs e)
	{
		plInteract.Enabled = C225933D.Checked;
		if (C225933D.Checked)
		{
			ckbLapLaiTuongTacInteract.Enabled = true;
			return;
		}
		ckbLapLaiTuongTacInteract.Checked = false;
		ckbLapLaiTuongTacInteract.Enabled = false;
	}

	private void F8194906(object sender, EventArgs e)
	{
		plComment.Enabled = ckbComment.Checked;
		if (ckbComment.Checked)
		{
			ED2FF032.Enabled = true;
			return;
		}
		ED2FF032.Checked = false;
		ED2FF032.Enabled = false;
	}

	private void CF04C19D_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(CF04C19D, lblComment);
	}

	private void D98DB012_CheckedChanged(object sender, EventArgs e)
	{
		EEBEBD15.Enabled = D98DB012.Checked;
	}

	protected override void Dispose(bool EC0041A3)
	{
		if (EC0041A3 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(EC0041A3);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTuongTacLivestream));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		C19DF28D = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		C2A58C00 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		B315C73B = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		EEBEBD15 = new System.Windows.Forms.Panel();
		nudLapLaiTuongTacDelayTo = new System.Windows.Forms.NumericUpDown();
		FD0157B8 = new System.Windows.Forms.Panel();
		radioButton1 = new System.Windows.Forms.RadioButton();
		radioButton2 = new System.Windows.Forms.RadioButton();
		ckbLapLaiTuongTacInteract = new System.Windows.Forms.CheckBox();
		A3BF3E3A = new System.Windows.Forms.Label();
		ED2FF032 = new System.Windows.Forms.CheckBox();
		D11181BA = new System.Windows.Forms.NumericUpDown();
		label4 = new System.Windows.Forms.Label();
		A0B9DD9D = new System.Windows.Forms.Label();
		plInteract = new System.Windows.Forms.Panel();
		ckbGian = new System.Windows.Forms.CheckBox();
		ckbBuon = new System.Windows.Forms.CheckBox();
		ckbWow = new System.Windows.Forms.CheckBox();
		ckbHaha = new System.Windows.Forms.CheckBox();
		ckbThuong = new System.Windows.Forms.CheckBox();
		A00BF933 = new System.Windows.Forms.CheckBox();
		ckbLike = new System.Windows.Forms.CheckBox();
		D80E4794 = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		radioButton4 = new System.Windows.Forms.RadioButton();
		label26 = new System.Windows.Forms.Label();
		plComment = new System.Windows.Forms.Panel();
		CF04C19D = new System.Windows.Forms.RichTextBox();
		label11 = new System.Windows.Forms.Label();
		lblComment = new System.Windows.Forms.Label();
		BD8FA2B7 = new System.Windows.Forms.CheckBox();
		D98DB012 = new System.Windows.Forms.CheckBox();
		ckbComment = new System.Windows.Forms.CheckBox();
		C225933D = new System.Windows.Forms.CheckBox();
		nudTimeTo = new System.Windows.Forms.NumericUpDown();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		txtLinkVideo = new System.Windows.Forms.TextBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		D92DB7B9 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		F2851C18 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		B20B5BB8 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		C2A58C00.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B315C73B).BeginInit();
		panel1.SuspendLayout();
		EEBEBD15.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudLapLaiTuongTacDelayTo).BeginInit();
		FD0157B8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D11181BA).BeginInit();
		plInteract.SuspendLayout();
		D80E4794.SuspendLayout();
		plComment.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = C19DF28D;
		bunifuDragControl_0.Vertical = true;
		C19DF28D.BackColor = System.Drawing.Color.Transparent;
		C19DF28D.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C19DF28D.Dock = System.Windows.Forms.DockStyle.Fill;
		C19DF28D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C19DF28D.ForeColor = System.Drawing.Color.Black;
		C19DF28D.Location = new System.Drawing.Point(0, 0);
		C19DF28D.Name = "bunifuCustomLabel1";
		C19DF28D.Size = new System.Drawing.Size(388, 31);
		C19DF28D.TabIndex = 12;
		C19DF28D.Text = "Cấu hình Tương tác Livestream";
		C19DF28D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = C2A58C00;
		bunifuDragControl_1.Vertical = true;
		C2A58C00.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C2A58C00.BackColor = System.Drawing.Color.White;
		C2A58C00.Controls.Add(button1);
		C2A58C00.Controls.Add(B315C73B);
		C2A58C00.Controls.Add(C19DF28D);
		C2A58C00.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C2A58C00.Location = new System.Drawing.Point(0, 3);
		C2A58C00.Name = "pnlHeader";
		C2A58C00.Size = new System.Drawing.Size(388, 31);
		C2A58C00.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(357, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		B315C73B.Cursor = System.Windows.Forms.Cursors.Default;
		B315C73B.Image = Class155.DD225F0D;
		B315C73B.Location = new System.Drawing.Point(3, 2);
		B315C73B.Name = "pictureBox1";
		B315C73B.Size = new System.Drawing.Size(34, 27);
		B315C73B.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		B315C73B.TabIndex = 76;
		B315C73B.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(EEBEBD15);
		panel1.Controls.Add(plInteract);
		panel1.Controls.Add(plComment);
		panel1.Controls.Add(D98DB012);
		panel1.Controls.Add(ckbComment);
		panel1.Controls.Add(C225933D);
		panel1.Controls.Add(nudTimeTo);
		panel1.Controls.Add(nudTimeFrom);
		panel1.Controls.Add(txtLinkVideo);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(D92DB7B9);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(F2851C18);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(B20B5BB8);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(391, 544);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(D6B45E02);
		EEBEBD15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		EEBEBD15.Controls.Add(nudLapLaiTuongTacDelayTo);
		EEBEBD15.Controls.Add(FD0157B8);
		EEBEBD15.Controls.Add(ckbLapLaiTuongTacInteract);
		EEBEBD15.Controls.Add(A3BF3E3A);
		EEBEBD15.Controls.Add(ED2FF032);
		EEBEBD15.Controls.Add(D11181BA);
		EEBEBD15.Controls.Add(label4);
		EEBEBD15.Controls.Add(A0B9DD9D);
		EEBEBD15.Location = new System.Drawing.Point(48, 426);
		EEBEBD15.Name = "plLapLaiTuongTac";
		EEBEBD15.Size = new System.Drawing.Size(310, 59);
		EEBEBD15.TabIndex = 180;
		nudLapLaiTuongTacDelayTo.Cursor = System.Windows.Forms.Cursors.Hand;
		nudLapLaiTuongTacDelayTo.Location = new System.Drawing.Point(185, 4);
		nudLapLaiTuongTacDelayTo.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
		nudLapLaiTuongTacDelayTo.Name = "nudLapLaiTuongTacDelayTo";
		nudLapLaiTuongTacDelayTo.Size = new System.Drawing.Size(56, 23);
		nudLapLaiTuongTacDelayTo.TabIndex = 22;
		FD0157B8.Controls.Add(radioButton1);
		FD0157B8.Controls.Add(radioButton2);
		FD0157B8.Location = new System.Drawing.Point(67, 300);
		FD0157B8.Name = "panel3";
		FD0157B8.Size = new System.Drawing.Size(200, 43);
		FD0157B8.TabIndex = 43;
		radioButton1.AutoSize = true;
		radioButton1.Checked = true;
		radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton1.Location = new System.Drawing.Point(3, 2);
		radioButton1.Name = "radioButton1";
		radioButton1.Size = new System.Drawing.Size(201, 20);
		radioButton1.TabIndex = 3;
		radioButton1.TabStop = true;
		radioButton1.Text = "Comment theo thứ tự nội dung";
		radioButton1.UseVisualStyleBackColor = true;
		radioButton2.AutoSize = true;
		radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton2.Location = new System.Drawing.Point(3, 23);
		radioButton2.Name = "radioButton2";
		radioButton2.Size = new System.Drawing.Size(200, 20);
		radioButton2.TabIndex = 3;
		radioButton2.Text = "Comment ngẫu nhiên nội dung";
		radioButton2.UseVisualStyleBackColor = true;
		ckbLapLaiTuongTacInteract.AutoSize = true;
		ckbLapLaiTuongTacInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLapLaiTuongTacInteract.Location = new System.Drawing.Point(6, 32);
		ckbLapLaiTuongTacInteract.Name = "ckbLapLaiTuongTacInteract";
		ckbLapLaiTuongTacInteract.Size = new System.Drawing.Size(112, 20);
		ckbLapLaiTuongTacInteract.TabIndex = 5;
		ckbLapLaiTuongTacInteract.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
		ckbLapLaiTuongTacInteract.UseVisualStyleBackColor = true;
		ckbLapLaiTuongTacInteract.CheckedChanged += new System.EventHandler(C225933D_CheckedChanged);
		A3BF3E3A.AutoSize = true;
		A3BF3E3A.Location = new System.Drawing.Point(2, 6);
		A3BF3E3A.Name = "lblmc1";
		A3BF3E3A.Size = new System.Drawing.Size(92, 16);
		A3BF3E3A.TabIndex = 18;
		A3BF3E3A.Text = "Delay time (s):";
		ED2FF032.AutoSize = true;
		ED2FF032.Cursor = System.Windows.Forms.Cursors.Hand;
		ED2FF032.Location = new System.Drawing.Point(134, 32);
		ED2FF032.Name = "ckbLapLaiTuongTacComment";
		ED2FF032.Size = new System.Drawing.Size(81, 20);
		ED2FF032.TabIndex = 7;
		ED2FF032.Text = "Comment";
		ED2FF032.UseVisualStyleBackColor = true;
		ED2FF032.CheckedChanged += new System.EventHandler(F8194906);
		D11181BA.Cursor = System.Windows.Forms.Cursors.Hand;
		D11181BA.Location = new System.Drawing.Point(94, 4);
		D11181BA.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
		D11181BA.Name = "nudLapLaiTuongTacDelayFrom";
		D11181BA.Size = new System.Drawing.Size(56, 23);
		D11181BA.TabIndex = 21;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(4, 302);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(64, 16);
		label4.TabIndex = 2;
		label4.Text = "Tùy chọn:";
		A0B9DD9D.AutoSize = true;
		A0B9DD9D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A0B9DD9D.Location = new System.Drawing.Point(159, 5);
		A0B9DD9D.Name = "label6";
		A0B9DD9D.Size = new System.Drawing.Size(18, 16);
		A0B9DD9D.TabIndex = 20;
		A0B9DD9D.Text = ">";
		plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plInteract.Controls.Add(ckbGian);
		plInteract.Controls.Add(ckbBuon);
		plInteract.Controls.Add(ckbWow);
		plInteract.Controls.Add(ckbHaha);
		plInteract.Controls.Add(ckbThuong);
		plInteract.Controls.Add(A00BF933);
		plInteract.Controls.Add(ckbLike);
		plInteract.Controls.Add(D80E4794);
		plInteract.Controls.Add(label26);
		plInteract.Location = new System.Drawing.Point(48, 159);
		plInteract.Name = "plInteract";
		plInteract.Size = new System.Drawing.Size(310, 33);
		plInteract.TabIndex = 180;
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
		ckbThuong.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThuong.Image = Class155.Bitmap_20;
		ckbThuong.Location = new System.Drawing.Point(90, 1);
		ckbThuong.Name = "ckbThuong";
		ckbThuong.Size = new System.Drawing.Size(40, 30);
		ckbThuong.TabIndex = 175;
		ckbThuong.UseVisualStyleBackColor = true;
		A00BF933.Cursor = System.Windows.Forms.Cursors.Hand;
		A00BF933.Image = Class155.AB95A212;
		A00BF933.Location = new System.Drawing.Point(46, 1);
		A00BF933.Name = "ckbTym";
		A00BF933.Size = new System.Drawing.Size(40, 30);
		A00BF933.TabIndex = 174;
		A00BF933.UseVisualStyleBackColor = true;
		ckbLike.Checked = true;
		ckbLike.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbLike.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLike.Image = Class155.Bitmap_166;
		ckbLike.Location = new System.Drawing.Point(2, 1);
		ckbLike.Name = "ckbLike";
		ckbLike.Size = new System.Drawing.Size(40, 30);
		ckbLike.TabIndex = 173;
		ckbLike.UseVisualStyleBackColor = true;
		D80E4794.Controls.Add(radioButton3);
		D80E4794.Controls.Add(radioButton4);
		D80E4794.Location = new System.Drawing.Point(67, 300);
		D80E4794.Name = "panel7";
		D80E4794.Size = new System.Drawing.Size(200, 43);
		D80E4794.TabIndex = 43;
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
		plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plComment.Controls.Add(CF04C19D);
		plComment.Controls.Add(label11);
		plComment.Controls.Add(lblComment);
		plComment.Controls.Add(BD8FA2B7);
		plComment.Location = new System.Drawing.Point(48, 221);
		plComment.Name = "plComment";
		plComment.Size = new System.Drawing.Size(310, 176);
		plComment.TabIndex = 8;
		CF04C19D.Location = new System.Drawing.Point(6, 24);
		CF04C19D.Name = "txtComment";
		CF04C19D.Size = new System.Drawing.Size(297, 102);
		CF04C19D.TabIndex = 199;
		CF04C19D.Text = "";
		CF04C19D.WordWrap = false;
		CF04C19D.TextChanged += new System.EventHandler(CF04C19D_TextChanged);
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(4, 129);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(143, 16);
		label11.TabIndex = 197;
		label11.Text = "(Spin nội dung {a|b|c})";
		lblComment.AutoSize = true;
		lblComment.Location = new System.Drawing.Point(2, 4);
		lblComment.Name = "lblComment";
		lblComment.Size = new System.Drawing.Size(139, 16);
		lblComment.TabIndex = 198;
		lblComment.Text = "Nội dung bình luận (0):";
		BD8FA2B7.AutoSize = true;
		BD8FA2B7.Cursor = System.Windows.Forms.Cursors.Hand;
		BD8FA2B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		BD8FA2B7.Location = new System.Drawing.Point(7, 151);
		BD8FA2B7.Name = "ckbTuDongXoaNoiDung";
		BD8FA2B7.Size = new System.Drawing.Size(201, 20);
		BD8FA2B7.TabIndex = 196;
		BD8FA2B7.Text = "Tư\u0323 đô\u0323ng xo\u0301a nô\u0323i dung đa\u0303 dùng";
		BD8FA2B7.UseVisualStyleBackColor = true;
		D98DB012.AutoSize = true;
		D98DB012.Cursor = System.Windows.Forms.Cursors.Hand;
		D98DB012.Location = new System.Drawing.Point(30, 403);
		D98DB012.Name = "ckbLapLaiTuongTac";
		D98DB012.Size = new System.Drawing.Size(121, 20);
		D98DB012.TabIndex = 7;
		D98DB012.Text = "Lặp lại tương tác";
		D98DB012.UseVisualStyleBackColor = true;
		D98DB012.CheckedChanged += new System.EventHandler(D98DB012_CheckedChanged);
		ckbComment.AutoSize = true;
		ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbComment.Location = new System.Drawing.Point(30, 198);
		ckbComment.Name = "ckbComment";
		ckbComment.Size = new System.Drawing.Size(81, 20);
		ckbComment.TabIndex = 7;
		ckbComment.Text = "Comment";
		ckbComment.UseVisualStyleBackColor = true;
		ckbComment.CheckedChanged += new System.EventHandler(F8194906);
		C225933D.AutoSize = true;
		C225933D.Cursor = System.Windows.Forms.Cursors.Hand;
		C225933D.Location = new System.Drawing.Point(30, 136);
		C225933D.Name = "ckbInteract";
		C225933D.Size = new System.Drawing.Size(112, 20);
		C225933D.TabIndex = 5;
		C225933D.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
		C225933D.UseVisualStyleBackColor = true;
		C225933D.CheckedChanged += new System.EventHandler(C225933D_CheckedChanged);
		nudTimeTo.Location = new System.Drawing.Point(236, 107);
		nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeTo.Name = "nudTimeTo";
		nudTimeTo.Size = new System.Drawing.Size(56, 23);
		nudTimeTo.TabIndex = 2;
		nudTimeFrom.Location = new System.Drawing.Point(143, 107);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(56, 23);
		nudTimeFrom.TabIndex = 1;
		txtLinkVideo.Location = new System.Drawing.Point(143, 78);
		txtLinkVideo.Name = "txtLinkVideo";
		txtLinkVideo.Size = new System.Drawing.Size(215, 23);
		txtLinkVideo.TabIndex = 0;
		txtTenHanhDong.Location = new System.Drawing.Point(143, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(215, 23);
		txtTenHanhDong.TabIndex = 0;
		D92DB7B9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D92DB7B9.Location = new System.Drawing.Point(203, 109);
		D92DB7B9.Name = "label3";
		D92DB7B9.Size = new System.Drawing.Size(29, 16);
		D92DB7B9.TabIndex = 37;
		D92DB7B9.Text = ">";
		D92DB7B9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 81);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(97, 16);
		label9.TabIndex = 31;
		label9.Text = "Link livestream:";
		F2851C18.AutoSize = true;
		F2851C18.Location = new System.Drawing.Point(27, 109);
		F2851C18.Name = "label2";
		F2851C18.Size = new System.Drawing.Size(113, 16);
		F2851C18.TabIndex = 32;
		F2851C18.Text = "Thời gian xem (s):";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		B20B5BB8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B20B5BB8.BackColor = System.Drawing.Color.Maroon;
		B20B5BB8.Cursor = System.Windows.Forms.Cursors.Hand;
		B20B5BB8.FlatAppearance.BorderSize = 0;
		B20B5BB8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B20B5BB8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B20B5BB8.ForeColor = System.Drawing.Color.White;
		B20B5BB8.Location = new System.Drawing.Point(203, 500);
		B20B5BB8.Name = "btnCancel";
		B20B5BB8.Size = new System.Drawing.Size(92, 29);
		B20B5BB8.TabIndex = 10;
		B20B5BB8.Text = "Đóng";
		B20B5BB8.UseVisualStyleBackColor = false;
		B20B5BB8.Click += new System.EventHandler(D3AB2CAF);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(96, 500);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(D732D1A4);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(C2A58C00);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(388, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(391, 544);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTuongTacLivestream";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDTuongTacLivestream_Load);
		C2A58C00.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)B315C73B).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		EEBEBD15.ResumeLayout(false);
		EEBEBD15.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudLapLaiTuongTacDelayTo).EndInit();
		FD0157B8.ResumeLayout(false);
		FD0157B8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)D11181BA).EndInit();
		plInteract.ResumeLayout(false);
		plInteract.PerformLayout();
		D80E4794.ResumeLayout(false);
		D80E4794.PerformLayout();
		plComment.ResumeLayout(false);
		plComment.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
