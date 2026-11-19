using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fImportAccountFormatInput : Form
{
	internal List<ComboBox> list_0;

	internal string string_0 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuCards E894FE3F;

	internal Panel pnlHeader;

	internal BunifuCustomLabel F23CFF20;

	internal Button btnMinimize;

	internal Button A68CE42C;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal Panel panel1;

	internal Panel plDinhDangNhap;

	internal ComboBox DB0FD206;

	internal ComboBox cbbDinhDang2;

	internal ComboBox A7AB3D38;

	internal ComboBox FD9C022D;

	internal Label BF8763A2;

	internal Label label18;

	internal Label F12D83B8;

	internal ComboBox cbbDinhDang5;

	internal Label label1;

	internal ComboBox AAB84006;

	internal Label C8A38390;

	internal ComboBox CF09431B;

	internal Label label13;

	internal ComboBox cbbDinhDang11;

	internal ComboBox cbbDinhDang6;

	internal ComboBox cbbDinhDang9;

	internal Label label12;

	internal ComboBox DC9970BC;

	internal Label C3A823AF;

	internal Label label9;

	internal Label label10;

	public fImportAccountFormatInput()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_0();
	}

	private void method_0()
	{
		list_0 = new List<ComboBox>
		{
			DB0FD206, cbbDinhDang2, A7AB3D38, FD9C022D, cbbDinhDang5, cbbDinhDang6, DC9970BC, CF09431B, cbbDinhDang9, AAB84006,
			cbbDinhDang11
		};
		foreach (ComboBox item in list_0)
		{
			Commom.smethod_23(item, new List<string>
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"Bạn bè", "Ngày tạo", "Mail khôi phục"
			});
			item.SelectedIndex = -1;
			item.DropDownWidth = 100;
		}
	}

	private void B4897FA2(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			string_0 = string_0 + list_0[i].Text + "|";
		}
		string_0 = string_0.TrimEnd('|');
		if (string_0 == "")
		{
			MsBoxHelper.Show("Vui lòng chọn định dạng tài khoản!", 3);
		}
		else
		{
			Close();
		}
	}

	private void A68CE42C_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool C820379F)
	{
		if (C820379F && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(C820379F);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fImportAccountFormatInput));
		E894FE3F = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		F23CFF20 = new Bunifu.Framework.UI.BunifuCustomLabel();
		A68CE42C = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1 = new System.Windows.Forms.Panel();
		plDinhDangNhap = new System.Windows.Forms.Panel();
		DB0FD206 = new System.Windows.Forms.ComboBox();
		cbbDinhDang2 = new System.Windows.Forms.ComboBox();
		A7AB3D38 = new System.Windows.Forms.ComboBox();
		FD9C022D = new System.Windows.Forms.ComboBox();
		BF8763A2 = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		F12D83B8 = new System.Windows.Forms.Label();
		cbbDinhDang5 = new System.Windows.Forms.ComboBox();
		label1 = new System.Windows.Forms.Label();
		AAB84006 = new System.Windows.Forms.ComboBox();
		C8A38390 = new System.Windows.Forms.Label();
		CF09431B = new System.Windows.Forms.ComboBox();
		label13 = new System.Windows.Forms.Label();
		cbbDinhDang11 = new System.Windows.Forms.ComboBox();
		cbbDinhDang6 = new System.Windows.Forms.ComboBox();
		cbbDinhDang9 = new System.Windows.Forms.ComboBox();
		label12 = new System.Windows.Forms.Label();
		DC9970BC = new System.Windows.Forms.ComboBox();
		C3A823AF = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		E894FE3F.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		plDinhDangNhap.SuspendLayout();
		SuspendLayout();
		E894FE3F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E894FE3F.BackColor = System.Drawing.Color.White;
		E894FE3F.BorderRadius = 0;
		E894FE3F.BottomSahddow = true;
		E894FE3F.color = System.Drawing.Color.SaddleBrown;
		E894FE3F.Controls.Add(pnlHeader);
		E894FE3F.LeftSahddow = false;
		E894FE3F.Location = new System.Drawing.Point(1, 0);
		E894FE3F.Name = "bunifuCards1";
		E894FE3F.RightSahddow = true;
		E894FE3F.ShadowDepth = 20;
		E894FE3F.Size = new System.Drawing.Size(1044, 38);
		E894FE3F.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(F23CFF20);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1043, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 77;
		pictureBox1.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(1011, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(B4897FA2);
		F23CFF20.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F23CFF20.BackColor = System.Drawing.Color.Transparent;
		F23CFF20.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F23CFF20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F23CFF20.ForeColor = System.Drawing.Color.Black;
		F23CFF20.Location = new System.Drawing.Point(0, 0);
		F23CFF20.Name = "bunifuCustomLabel1";
		F23CFF20.Size = new System.Drawing.Size(1043, 32);
		F23CFF20.TabIndex = 1;
		F23CFF20.Text = "Thêm Định dạng nhập tài khoản";
		F23CFF20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A68CE42C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A68CE42C.BackColor = System.Drawing.Color.Maroon;
		A68CE42C.Cursor = System.Windows.Forms.Cursors.Hand;
		A68CE42C.FlatAppearance.BorderSize = 0;
		A68CE42C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A68CE42C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A68CE42C.ForeColor = System.Drawing.Color.White;
		A68CE42C.Location = new System.Drawing.Point(528, 106);
		A68CE42C.Name = "btnCancel";
		A68CE42C.Size = new System.Drawing.Size(92, 29);
		A68CE42C.TabIndex = 4;
		A68CE42C.Text = "Hủy";
		A68CE42C.UseVisualStyleBackColor = false;
		A68CE42C.Click += new System.EventHandler(A68CE42C_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(424, 106);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = F23CFF20;
		bunifuDragControl_0.Vertical = true;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(plDinhDangNhap);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1045, 146);
		panel1.TabIndex = 48;
		plDinhDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDinhDangNhap.Controls.Add(DB0FD206);
		plDinhDangNhap.Controls.Add(cbbDinhDang2);
		plDinhDangNhap.Controls.Add(A7AB3D38);
		plDinhDangNhap.Controls.Add(FD9C022D);
		plDinhDangNhap.Controls.Add(BF8763A2);
		plDinhDangNhap.Controls.Add(label18);
		plDinhDangNhap.Controls.Add(F12D83B8);
		plDinhDangNhap.Controls.Add(cbbDinhDang5);
		plDinhDangNhap.Controls.Add(label1);
		plDinhDangNhap.Controls.Add(AAB84006);
		plDinhDangNhap.Controls.Add(C8A38390);
		plDinhDangNhap.Controls.Add(CF09431B);
		plDinhDangNhap.Controls.Add(label13);
		plDinhDangNhap.Controls.Add(cbbDinhDang11);
		plDinhDangNhap.Controls.Add(cbbDinhDang6);
		plDinhDangNhap.Controls.Add(cbbDinhDang9);
		plDinhDangNhap.Controls.Add(label12);
		plDinhDangNhap.Controls.Add(DC9970BC);
		plDinhDangNhap.Controls.Add(C3A823AF);
		plDinhDangNhap.Controls.Add(label9);
		plDinhDangNhap.Controls.Add(label10);
		plDinhDangNhap.Location = new System.Drawing.Point(11, 52);
		plDinhDangNhap.Name = "plDinhDangNhap";
		plDinhDangNhap.Size = new System.Drawing.Size(1019, 36);
		plDinhDangNhap.TabIndex = 47;
		DB0FD206.Cursor = System.Windows.Forms.Cursors.Hand;
		DB0FD206.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		DB0FD206.DropDownWidth = 100;
		DB0FD206.FormattingEnabled = true;
		DB0FD206.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		DB0FD206.Location = new System.Drawing.Point(4, 5);
		DB0FD206.Name = "cbbDinhDang1";
		DB0FD206.Size = new System.Drawing.Size(78, 24);
		DB0FD206.TabIndex = 40;
		cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang2.DropDownWidth = 100;
		cbbDinhDang2.FormattingEnabled = true;
		cbbDinhDang2.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang2.Location = new System.Drawing.Point(97, 5);
		cbbDinhDang2.Name = "cbbDinhDang2";
		cbbDinhDang2.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang2.TabIndex = 40;
		A7AB3D38.Cursor = System.Windows.Forms.Cursors.Hand;
		A7AB3D38.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A7AB3D38.DropDownWidth = 100;
		A7AB3D38.FormattingEnabled = true;
		A7AB3D38.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		A7AB3D38.Location = new System.Drawing.Point(190, 5);
		A7AB3D38.Name = "cbbDinhDang3";
		A7AB3D38.Size = new System.Drawing.Size(78, 24);
		A7AB3D38.TabIndex = 40;
		FD9C022D.Cursor = System.Windows.Forms.Cursors.Hand;
		FD9C022D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		FD9C022D.DropDownWidth = 100;
		FD9C022D.FormattingEnabled = true;
		FD9C022D.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		FD9C022D.Location = new System.Drawing.Point(283, 5);
		FD9C022D.Name = "cbbDinhDang4";
		FD9C022D.Size = new System.Drawing.Size(78, 24);
		FD9C022D.TabIndex = 40;
		BF8763A2.AutoSize = true;
		BF8763A2.Font = new System.Drawing.Font("Tahoma", 12f);
		BF8763A2.Location = new System.Drawing.Point(920, 5);
		BF8763A2.Name = "label19";
		BF8763A2.Size = new System.Drawing.Size(15, 19);
		BF8763A2.TabIndex = 41;
		BF8763A2.Text = "|";
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Tahoma", 12f);
		label18.Location = new System.Drawing.Point(733, 5);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(15, 19);
		label18.TabIndex = 41;
		label18.Text = "|";
		F12D83B8.AutoSize = true;
		F12D83B8.Font = new System.Drawing.Font("Tahoma", 12f);
		F12D83B8.Location = new System.Drawing.Point(547, 5);
		F12D83B8.Name = "label14";
		F12D83B8.Size = new System.Drawing.Size(15, 19);
		F12D83B8.TabIndex = 41;
		F12D83B8.Text = "|";
		cbbDinhDang5.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang5.DropDownWidth = 100;
		cbbDinhDang5.FormattingEnabled = true;
		cbbDinhDang5.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang5.Location = new System.Drawing.Point(376, 5);
		cbbDinhDang5.Name = "cbbDinhDang5";
		cbbDinhDang5.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang5.TabIndex = 40;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 12f);
		label1.Location = new System.Drawing.Point(827, 7);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(15, 19);
		label1.TabIndex = 41;
		label1.Text = "|";
		AAB84006.Cursor = System.Windows.Forms.Cursors.Hand;
		AAB84006.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		AAB84006.DropDownWidth = 100;
		AAB84006.FormattingEnabled = true;
		AAB84006.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		AAB84006.Location = new System.Drawing.Point(842, 5);
		AAB84006.Name = "cbbDinhDang10";
		AAB84006.Size = new System.Drawing.Size(78, 24);
		AAB84006.TabIndex = 40;
		C8A38390.AutoSize = true;
		C8A38390.Font = new System.Drawing.Font("Tahoma", 12f);
		C8A38390.Location = new System.Drawing.Point(640, 5);
		C8A38390.Name = "label17";
		C8A38390.Size = new System.Drawing.Size(15, 19);
		C8A38390.TabIndex = 41;
		C8A38390.Text = "|";
		CF09431B.Cursor = System.Windows.Forms.Cursors.Hand;
		CF09431B.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		CF09431B.DropDownWidth = 100;
		CF09431B.FormattingEnabled = true;
		CF09431B.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		CF09431B.Location = new System.Drawing.Point(655, 5);
		CF09431B.Name = "cbbDinhDang8";
		CF09431B.Size = new System.Drawing.Size(78, 24);
		CF09431B.TabIndex = 40;
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Tahoma", 12f);
		label13.Location = new System.Drawing.Point(454, 5);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(15, 19);
		label13.TabIndex = 41;
		label13.Text = "|";
		cbbDinhDang11.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang11.DropDownWidth = 100;
		cbbDinhDang11.FormattingEnabled = true;
		cbbDinhDang11.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang11.Location = new System.Drawing.Point(935, 5);
		cbbDinhDang11.Name = "cbbDinhDang11";
		cbbDinhDang11.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang11.TabIndex = 40;
		cbbDinhDang6.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang6.DropDownWidth = 100;
		cbbDinhDang6.FormattingEnabled = true;
		cbbDinhDang6.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang6.Location = new System.Drawing.Point(469, 5);
		cbbDinhDang6.Name = "cbbDinhDang6";
		cbbDinhDang6.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang6.TabIndex = 40;
		cbbDinhDang9.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDinhDang9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDinhDang9.DropDownWidth = 100;
		cbbDinhDang9.FormattingEnabled = true;
		cbbDinhDang9.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		cbbDinhDang9.Location = new System.Drawing.Point(748, 5);
		cbbDinhDang9.Name = "cbbDinhDang9";
		cbbDinhDang9.Size = new System.Drawing.Size(78, 24);
		cbbDinhDang9.TabIndex = 40;
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Tahoma", 12f);
		label12.Location = new System.Drawing.Point(361, 5);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(15, 19);
		label12.TabIndex = 41;
		label12.Text = "|";
		DC9970BC.Cursor = System.Windows.Forms.Cursors.Hand;
		DC9970BC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		DC9970BC.DropDownWidth = 100;
		DC9970BC.FormattingEnabled = true;
		DC9970BC.Items.AddRange(new object[13]
		{
			"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
			"Bạn bè", "Ngày tạo", "Mail khôi phục"
		});
		DC9970BC.Location = new System.Drawing.Point(562, 5);
		DC9970BC.Name = "cbbDinhDang7";
		DC9970BC.Size = new System.Drawing.Size(78, 24);
		DC9970BC.TabIndex = 40;
		C3A823AF.AutoSize = true;
		C3A823AF.Font = new System.Drawing.Font("Tahoma", 12f);
		C3A823AF.Location = new System.Drawing.Point(268, 5);
		C3A823AF.Name = "label11";
		C3A823AF.Size = new System.Drawing.Size(15, 19);
		C3A823AF.TabIndex = 41;
		C3A823AF.Text = "|";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Tahoma", 12f);
		label9.Location = new System.Drawing.Point(82, 5);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(15, 19);
		label9.TabIndex = 41;
		label9.Text = "|";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Tahoma", 12f);
		label10.Location = new System.Drawing.Point(175, 5);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(15, 19);
		label10.TabIndex = 41;
		label10.Text = "|";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1045, 146);
		base.Controls.Add(A68CE42C);
		base.Controls.Add(btnAdd);
		base.Controls.Add(E894FE3F);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fImportAccountFormatInput";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		E894FE3F.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		plDinhDangNhap.ResumeLayout(false);
		plDinhDangNhap.PerformLayout();
		ResumeLayout(false);
	}
}
