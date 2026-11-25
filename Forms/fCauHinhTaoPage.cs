using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhTaoPage : Form
{
	internal bool bool_0 = false;

	internal List<string> C7A01B97 = new List<string>();

	internal List<string> CA2AF00B = new List<string>();

	internal List<string> list_0 = new List<string>();

	internal List<string> list_1 = new List<string>();

	internal List<string> list_2 = new List<string>();

	internal List<string> list_3 = new List<string>();

	internal List<string> C2949FAA = new List<string>();

	internal List<string> C31BC809 = new List<string>();

	internal List<string> list_4 = new List<string>();

	internal IContainer CDA1DD84 = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel EBA7A291;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl E6BA5125;

	internal PictureBox pictureBox1;

	internal CheckBox ckbTaoPage;

	internal Panel plTaoPage;

	internal NumericUpDown D536579C;

	internal Label label1;

	internal CheckBox ckbFollow;

	internal Panel B238581F;

	internal TextBox txtId;

	internal Label A42A9C2B;

	internal CheckBox E2990EB8;

	internal Panel plCapNhatThongTin;

	internal Button button5;

	internal Button button3;

	internal Button C93C2FA0;

	internal Button button6;

	internal Button button4;

	internal Button B3B2AE3A;

	internal Button CC329022;

	internal CheckBox B413DCBF;

	internal Button button8;

	internal Label AFAF6A93;

	internal CheckBox E5144728;

	internal Panel B02C1832;

	internal TextBox txtPageId;

	internal Label E4AE17B6;

	internal CheckBox AF0F3683;

	internal Panel plJoinGroup;

	internal TextBox txtGroupId;

	internal Label label5;

	internal CheckBox A73F49A1;

	internal Button button9;

	internal Label label6;

	public fCauHinhTaoPage()
	{
		InitializeComponent();
		bool_0 = false;
		Language.CD21F0A9(this);
	}

	private void AD2D053C(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configTaoPage").method_4("ckbGetToken", E2990EB8.Checked);
		C5034B95.smethod_0("configTaoPage").method_4("ckbTaoPage", ckbTaoPage.Checked);
		C5034B95.smethod_0("configTaoPage").method_4("nudSoLuongPage", D536579C.Value);
		C5034B95.smethod_0("configTaoPage").method_4("ckbCapNhatThongTin", B413DCBF.Checked);
		C5034B95.smethod_0("configTaoPage").method_4("ckbRandomTen", A73F49A1.Checked);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstTenPage", C7A01B97);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstDanhMuc", CA2AF00B);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstBio", list_0);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstZip", list_1);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstWebsite", list_2);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstStreet", list_3);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstPhone", C2949FAA);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstEmail", C31BC809);
		C5034B95.smethod_0("configTaoPage").FD3CCF90("lstCity", list_4);
		C5034B95.smethod_0("configTaoPage").method_4("ckbFollow", ckbFollow.Checked);
		C5034B95.smethod_0("configTaoPage").method_4("txtId", txtId.Text.Trim());
		C5034B95.smethod_0("configTaoPage").method_4("ckbLikePage", E5144728.Checked);
		C5034B95.smethod_0("configTaoPage").method_4("txtPageId", txtPageId.Text.Trim());
		C5034B95.smethod_0("configTaoPage").method_4("ckbJoinGroup", AF0F3683.Checked);
		C5034B95.smethod_0("configTaoPage").method_4("txtGroupId", txtGroupId.Text.Trim());
		C5034B95.smethod_1("configTaoPage");
		bool_0 = true;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fCauHinhTaoPage_Load(object sender, EventArgs e)
	{
		E2990EB8.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbGetToken");
		ckbTaoPage.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbTaoPage");
		D536579C.Value = C5034B95.smethod_0("configTaoPage").method_2("nudSoLuongPage", 5);
		B413DCBF.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbCapNhatThongTin");
		A73F49A1.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbRandomTen", C9B3010F: true);
		C7A01B97 = C5034B95.smethod_0("configTaoPage").method_1("lstTenPage");
		CA2AF00B = C5034B95.smethod_0("configTaoPage").method_1("lstDanhMuc");
		list_0 = C5034B95.smethod_0("configTaoPage").method_1("lstBio");
		list_1 = C5034B95.smethod_0("configTaoPage").method_1("lstZip");
		list_2 = C5034B95.smethod_0("configTaoPage").method_1("lstWebsite");
		list_3 = C5034B95.smethod_0("configTaoPage").method_1("lstStreet");
		C2949FAA = C5034B95.smethod_0("configTaoPage").method_1("lstPhone");
		C31BC809 = C5034B95.smethod_0("configTaoPage").method_1("lstEmail");
		list_4 = C5034B95.smethod_0("configTaoPage").method_1("lstCity");
		ckbFollow.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbFollow");
		txtId.Text = C5034B95.smethod_0("configTaoPage").BDB80B23("txtId");
		E5144728.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbLikePage");
		txtPageId.Text = C5034B95.smethod_0("configTaoPage").BDB80B23("txtPageId");
		AF0F3683.Checked = C5034B95.smethod_0("configTaoPage").method_3("ckbJoinGroup");
		txtGroupId.Text = C5034B95.smethod_0("configTaoPage").BDB80B23("txtGroupId");
		if (C7A01B97.Count == 0)
		{
			C7A01B97.Add("MaxPhoneFarm *****");
		}
		if (CA2AF00B.Count == 0)
		{
			CA2AF00B.Add("2347428775505624");
		}
		if (list_0.Count == 0)
		{
			list_0.Add("Phần mềm nuôi Facebook tự động - Hotline/zalo: 0975 337 854 - 085.226.1234");
		}
		if (list_1.Count == 0)
		{
			list_1.Add("100000");
		}
		if (list_2.Count == 0)
		{
			list_2.Add("maxphonefarm.com");
		}
		if (list_3.Count == 0)
		{
			list_3.Add("58 Trương Công Giai, Dịch Vọng, Cầu Giấy");
		}
		if (C2949FAA.Count == 0)
		{
			C2949FAA.Add("097 533 78 54");
		}
		if (C31BC809.Count == 0)
		{
			C31BC809.Add("hotro@maxphonefarm.com");
		}
		if (list_4.Count == 0)
		{
			list_4.Add("106388046062960");
		}
		E2990EB8_CheckedChanged(null, null);
		FD27D6AA(null, null);
		B413DCBF_CheckedChanged(null, null);
		E9842EA3(null, null);
		A1153939(null, null);
		E4086FBF(null, null);
	}

	private void E2990EB8_CheckedChanged(object sender, EventArgs e)
	{
		plTaoPage.Enabled = ckbTaoPage.Checked;
	}

	private void FD27D6AA(object sender, EventArgs e)
	{
		B238581F.Enabled = ckbFollow.Checked;
	}

	private void B413DCBF_CheckedChanged(object sender, EventArgs e)
	{
		plCapNhatThongTin.Enabled = B413DCBF.Checked;
	}

	private void method_0(string FF0E1EBC)
	{
		switch (AFAE75A0.smethod_0(FF0E1EBC))
		{
		case 898528047u:
			if (FF0E1EBC == "tenPage")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(C7A01B97, "Nhâ\u0323p danh sa\u0301ch tên page", "Danh sa\u0301ch tên page", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				C7A01B97 = fNhapDuLieu4.list_0;
			}
			break;
		case 230981954u:
			if (FF0E1EBC == "city")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_4, "Nhâ\u0323p danh sa\u0301ch id thành phố", "Danh sa\u0301ch id thành phố", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_4 = fNhapDuLieu4.list_0;
			}
			break;
		case 1986331710u:
			if (FF0E1EBC == "street")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_3, "Nhâ\u0323p danh sa\u0301ch street", "Danh sa\u0301ch street", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_3 = fNhapDuLieu4.list_0;
			}
			break;
		case 1540020817u:
			if (FF0E1EBC == "bio")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_0, "Nhâ\u0323p danh sa\u0301ch bio", "Danh sa\u0301ch bio", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_0 = fNhapDuLieu4.list_0;
			}
			break;
		case 2324124615u:
			if (FF0E1EBC == "email")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(C31BC809, "Nhâ\u0323p danh sa\u0301ch email", "Danh sa\u0301ch email", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				C31BC809 = fNhapDuLieu4.list_0;
			}
			break;
		case 2000032175u:
			if (FF0E1EBC == "phone")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(C2949FAA, "Nhâ\u0323p danh sa\u0301ch phone", "Danh sa\u0301ch phone", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				C2949FAA = fNhapDuLieu4.list_0;
			}
			break;
		case 4243573962u:
			if (FF0E1EBC == "website")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_2, "Nhâ\u0323p danh sa\u0301ch website", "Danh sa\u0301ch website", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_2 = fNhapDuLieu4.list_0;
			}
			break;
		case 3255466783u:
			if (FF0E1EBC == "danhMuc")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(CA2AF00B, "Nhâ\u0323p danh sa\u0301ch id danh mục", "Danh sa\u0301ch id danh mục", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				CA2AF00B = fNhapDuLieu4.list_0;
			}
			break;
		case 2877453236u:
			if (FF0E1EBC == "zip")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_1, "Nhâ\u0323p danh sa\u0301ch zip", "Danh sa\u0301ch zip", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_1 = fNhapDuLieu4.list_0;
			}
			break;
		}
	}

	private void BF8FA180(object sender, EventArgs e)
	{
		method_0("bio");
	}

	private void button8_Click(object sender, EventArgs e)
	{
		method_0("danhMuc");
	}

	private void ABB226BC(object sender, EventArgs e)
	{
		method_0("website");
	}

	private void C90D9488(object sender, EventArgs e)
	{
		method_0("street");
	}

	private void CC329022_Click(object sender, EventArgs e)
	{
		method_0("zip");
	}

	private void button4_Click(object sender, EventArgs e)
	{
		method_0("phone");
	}

	private void button6_Click(object sender, EventArgs e)
	{
		method_0("city");
	}

	private void C93C2FA0_Click(object sender, EventArgs e)
	{
		method_0("email");
	}

	private void E9842EA3(object sender, EventArgs e)
	{
		B02C1832.Enabled = E5144728.Checked;
	}

	private void A1153939(object sender, EventArgs e)
	{
		plJoinGroup.Enabled = AF0F3683.Checked;
	}

	private void button9_Click(object sender, EventArgs e)
	{
		method_0("tenPage");
	}

	private void E4086FBF(object sender, EventArgs e)
	{
		button9.Enabled = !A73F49A1.Checked;
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && CDA1DD84 != null)
		{
			CDA1DD84.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		CDA1DD84 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhTaoPage));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		EBA7A291 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		E6BA5125 = new Bunifu.Framework.UI.BunifuDragControl(CDA1DD84);
		ckbTaoPage = new System.Windows.Forms.CheckBox();
		plTaoPage = new System.Windows.Forms.Panel();
		A73F49A1 = new System.Windows.Forms.CheckBox();
		button9 = new System.Windows.Forms.Button();
		button8 = new System.Windows.Forms.Button();
		plCapNhatThongTin = new System.Windows.Forms.Panel();
		button5 = new System.Windows.Forms.Button();
		button3 = new System.Windows.Forms.Button();
		C93C2FA0 = new System.Windows.Forms.Button();
		button6 = new System.Windows.Forms.Button();
		button4 = new System.Windows.Forms.Button();
		B3B2AE3A = new System.Windows.Forms.Button();
		CC329022 = new System.Windows.Forms.Button();
		B413DCBF = new System.Windows.Forms.CheckBox();
		label6 = new System.Windows.Forms.Label();
		D536579C = new System.Windows.Forms.NumericUpDown();
		AFAF6A93 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		ckbFollow = new System.Windows.Forms.CheckBox();
		B238581F = new System.Windows.Forms.Panel();
		txtId = new System.Windows.Forms.TextBox();
		A42A9C2B = new System.Windows.Forms.Label();
		E2990EB8 = new System.Windows.Forms.CheckBox();
		E5144728 = new System.Windows.Forms.CheckBox();
		B02C1832 = new System.Windows.Forms.Panel();
		txtPageId = new System.Windows.Forms.TextBox();
		E4AE17B6 = new System.Windows.Forms.Label();
		AF0F3683 = new System.Windows.Forms.CheckBox();
		plJoinGroup = new System.Windows.Forms.Panel();
		txtGroupId = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		plTaoPage.SuspendLayout();
		plCapNhatThongTin.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D536579C).BeginInit();
		B238581F.SuspendLayout();
		B02C1832.SuspendLayout();
		plJoinGroup.SuspendLayout();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(714, 38);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(EBA7A291);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(714, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(682, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(AD2D053C);
		EBA7A291.BackColor = System.Drawing.Color.Transparent;
		EBA7A291.Cursor = System.Windows.Forms.Cursors.SizeAll;
		EBA7A291.Dock = System.Windows.Forms.DockStyle.Fill;
		EBA7A291.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EBA7A291.ForeColor = System.Drawing.Color.Black;
		EBA7A291.Location = new System.Drawing.Point(0, 0);
		EBA7A291.Name = "bunifuCustomLabel1";
		EBA7A291.Size = new System.Drawing.Size(714, 32);
		EBA7A291.TabIndex = 1;
		EBA7A291.Text = "Câ\u0301u hi\u0300nh Ta\u0323o page";
		EBA7A291.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(365, 237);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(261, 237);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		E6BA5125.Fixed = true;
		E6BA5125.Horizontal = true;
		E6BA5125.TargetControl = EBA7A291;
		E6BA5125.Vertical = true;
		ckbTaoPage.AutoSize = true;
		ckbTaoPage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTaoPage.Location = new System.Drawing.Point(30, 87);
		ckbTaoPage.Name = "ckbTaoPage";
		ckbTaoPage.Size = new System.Drawing.Size(80, 20);
		ckbTaoPage.TabIndex = 5;
		ckbTaoPage.Text = "Ta\u0323o page";
		ckbTaoPage.UseVisualStyleBackColor = true;
		ckbTaoPage.CheckedChanged += new System.EventHandler(E2990EB8_CheckedChanged);
		plTaoPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTaoPage.Controls.Add(A73F49A1);
		plTaoPage.Controls.Add(button9);
		plTaoPage.Controls.Add(button8);
		plTaoPage.Controls.Add(plCapNhatThongTin);
		plTaoPage.Controls.Add(B413DCBF);
		plTaoPage.Controls.Add(label6);
		plTaoPage.Controls.Add(D536579C);
		plTaoPage.Controls.Add(AFAF6A93);
		plTaoPage.Controls.Add(label1);
		plTaoPage.Location = new System.Drawing.Point(30, 108);
		plTaoPage.Name = "plTaoPage";
		plTaoPage.Size = new System.Drawing.Size(351, 95);
		plTaoPage.TabIndex = 6;
		A73F49A1.AutoSize = true;
		A73F49A1.Cursor = System.Windows.Forms.Cursors.Hand;
		A73F49A1.Location = new System.Drawing.Point(73, 37);
		A73F49A1.Name = "ckbRandomTen";
		A73F49A1.Size = new System.Drawing.Size(73, 20);
		A73F49A1.TabIndex = 4;
		A73F49A1.Text = "Random";
		A73F49A1.UseVisualStyleBackColor = true;
		A73F49A1.CheckedChanged += new System.EventHandler(E4086FBF);
		button9.Cursor = System.Windows.Forms.Cursors.Hand;
		button9.Location = new System.Drawing.Point(152, 34);
		button9.Name = "button9";
		button9.Size = new System.Drawing.Size(192, 25);
		button9.TabIndex = 0;
		button9.Text = "Nhập";
		button9.UseVisualStyleBackColor = true;
		button9.Click += new System.EventHandler(button9_Click);
		button8.Cursor = System.Windows.Forms.Cursors.Hand;
		button8.Location = new System.Drawing.Point(72, 63);
		button8.Name = "button8";
		button8.Size = new System.Drawing.Size(272, 25);
		button8.TabIndex = 0;
		button8.Text = "Nhập";
		button8.UseVisualStyleBackColor = true;
		button8.Click += new System.EventHandler(button8_Click);
		plCapNhatThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCapNhatThongTin.Controls.Add(button5);
		plCapNhatThongTin.Controls.Add(button3);
		plCapNhatThongTin.Controls.Add(C93C2FA0);
		plCapNhatThongTin.Controls.Add(button6);
		plCapNhatThongTin.Controls.Add(button4);
		plCapNhatThongTin.Controls.Add(B3B2AE3A);
		plCapNhatThongTin.Controls.Add(CC329022);
		plCapNhatThongTin.Location = new System.Drawing.Point(6, 114);
		plCapNhatThongTin.Name = "plCapNhatThongTin";
		plCapNhatThongTin.Size = new System.Drawing.Size(338, 97);
		plCapNhatThongTin.TabIndex = 3;
		button5.Cursor = System.Windows.Forms.Cursors.Hand;
		button5.Location = new System.Drawing.Point(4, 5);
		button5.Name = "button5";
		button5.Size = new System.Drawing.Size(118, 25);
		button5.TabIndex = 0;
		button5.Text = "Giới thiệu (Bio)";
		button5.UseVisualStyleBackColor = true;
		button5.Click += new System.EventHandler(BF8FA180);
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.Location = new System.Drawing.Point(232, 5);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(98, 25);
		button3.TabIndex = 0;
		button3.Text = "Địa chỉ";
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(C90D9488);
		C93C2FA0.Cursor = System.Windows.Forms.Cursors.Hand;
		C93C2FA0.Location = new System.Drawing.Point(128, 67);
		C93C2FA0.Name = "button7";
		C93C2FA0.Size = new System.Drawing.Size(98, 25);
		C93C2FA0.TabIndex = 0;
		C93C2FA0.Text = "Email";
		C93C2FA0.UseVisualStyleBackColor = true;
		C93C2FA0.Click += new System.EventHandler(C93C2FA0_Click);
		button6.Cursor = System.Windows.Forms.Cursors.Hand;
		button6.Location = new System.Drawing.Point(232, 36);
		button6.Name = "button6";
		button6.Size = new System.Drawing.Size(98, 25);
		button6.TabIndex = 0;
		button6.Text = "Thành phố";
		button6.UseVisualStyleBackColor = true;
		button6.Click += new System.EventHandler(button6_Click);
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.Location = new System.Drawing.Point(128, 36);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(98, 25);
		button4.TabIndex = 0;
		button4.Text = "Số điện thoại";
		button4.UseVisualStyleBackColor = true;
		button4.Click += new System.EventHandler(button4_Click);
		B3B2AE3A.Cursor = System.Windows.Forms.Cursors.Hand;
		B3B2AE3A.Location = new System.Drawing.Point(128, 5);
		B3B2AE3A.Name = "button2";
		B3B2AE3A.Size = new System.Drawing.Size(98, 25);
		B3B2AE3A.TabIndex = 0;
		B3B2AE3A.Text = "Website";
		B3B2AE3A.UseVisualStyleBackColor = true;
		B3B2AE3A.Click += new System.EventHandler(ABB226BC);
		CC329022.Cursor = System.Windows.Forms.Cursors.Hand;
		CC329022.Location = new System.Drawing.Point(4, 36);
		CC329022.Name = "button1";
		CC329022.Size = new System.Drawing.Size(118, 25);
		CC329022.TabIndex = 0;
		CC329022.Text = "Mã Zip";
		CC329022.UseVisualStyleBackColor = true;
		CC329022.Click += new System.EventHandler(CC329022_Click);
		B413DCBF.AutoSize = true;
		B413DCBF.Cursor = System.Windows.Forms.Cursors.Hand;
		B413DCBF.Location = new System.Drawing.Point(6, 92);
		B413DCBF.Name = "ckbCapNhatThongTin";
		B413DCBF.Size = new System.Drawing.Size(131, 20);
		B413DCBF.TabIndex = 2;
		B413DCBF.Text = "Cập nhật thông tin";
		B413DCBF.UseVisualStyleBackColor = true;
		B413DCBF.CheckedChanged += new System.EventHandler(B413DCBF_CheckedChanged);
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(3, 38);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(66, 16);
		label6.TabIndex = 0;
		label6.Text = "Tên page:";
		D536579C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D536579C.Location = new System.Drawing.Point(72, 5);
		D536579C.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		D536579C.Name = "nudSoLuongPage";
		D536579C.Size = new System.Drawing.Size(272, 23);
		D536579C.TabIndex = 1;
		AFAF6A93.AutoSize = true;
		AFAF6A93.Location = new System.Drawing.Point(3, 67);
		AFAF6A93.Name = "label3";
		AFAF6A93.Size = new System.Drawing.Size(69, 16);
		AFAF6A93.TabIndex = 0;
		AFAF6A93.Text = "Danh mục:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(3, 7);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(63, 16);
		label1.TabIndex = 0;
		label1.Text = "Sô\u0301 lươ\u0323ng:";
		ckbFollow.AutoSize = true;
		ckbFollow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFollow.Location = new System.Drawing.Point(413, 64);
		ckbFollow.Name = "ckbFollow";
		ckbFollow.Size = new System.Drawing.Size(63, 20);
		ckbFollow.TabIndex = 5;
		ckbFollow.Text = "Follow";
		ckbFollow.UseVisualStyleBackColor = true;
		ckbFollow.CheckedChanged += new System.EventHandler(FD27D6AA);
		B238581F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B238581F.Controls.Add(txtId);
		B238581F.Controls.Add(A42A9C2B);
		B238581F.Location = new System.Drawing.Point(413, 85);
		B238581F.Name = "plFollow";
		B238581F.Size = new System.Drawing.Size(274, 31);
		B238581F.TabIndex = 6;
		txtId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtId.Location = new System.Drawing.Point(58, 3);
		txtId.Name = "txtId";
		txtId.Size = new System.Drawing.Size(211, 23);
		txtId.TabIndex = 1;
		A42A9C2B.AutoSize = true;
		A42A9C2B.Location = new System.Drawing.Point(5, 6);
		A42A9C2B.Name = "label2";
		A42A9C2B.Size = new System.Drawing.Size(56, 16);
		A42A9C2B.TabIndex = 0;
		A42A9C2B.Text = "Nhâ\u0323p Id:";
		E2990EB8.AutoSize = true;
		E2990EB8.Cursor = System.Windows.Forms.Cursors.Hand;
		E2990EB8.Location = new System.Drawing.Point(30, 64);
		E2990EB8.Name = "ckbGetToken";
		E2990EB8.Size = new System.Drawing.Size(131, 20);
		E2990EB8.TabIndex = 5;
		E2990EB8.Text = "Get token EAAAAU";
		E2990EB8.UseVisualStyleBackColor = true;
		E2990EB8.CheckedChanged += new System.EventHandler(E2990EB8_CheckedChanged);
		E5144728.AutoSize = true;
		E5144728.Cursor = System.Windows.Forms.Cursors.Hand;
		E5144728.Location = new System.Drawing.Point(412, 118);
		E5144728.Name = "ckbLikePage";
		E5144728.Size = new System.Drawing.Size(80, 20);
		E5144728.TabIndex = 5;
		E5144728.Text = "Like page";
		E5144728.UseVisualStyleBackColor = true;
		E5144728.CheckedChanged += new System.EventHandler(E9842EA3);
		B02C1832.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B02C1832.Controls.Add(txtPageId);
		B02C1832.Controls.Add(E4AE17B6);
		B02C1832.Location = new System.Drawing.Point(412, 139);
		B02C1832.Name = "plLikePage";
		B02C1832.Size = new System.Drawing.Size(274, 31);
		B02C1832.TabIndex = 6;
		txtPageId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtPageId.Location = new System.Drawing.Point(58, 3);
		txtPageId.Name = "txtPageId";
		txtPageId.Size = new System.Drawing.Size(211, 23);
		txtPageId.TabIndex = 1;
		E4AE17B6.AutoSize = true;
		E4AE17B6.Location = new System.Drawing.Point(5, 6);
		E4AE17B6.Name = "label4";
		E4AE17B6.Size = new System.Drawing.Size(56, 16);
		E4AE17B6.TabIndex = 0;
		E4AE17B6.Text = "Nhâ\u0323p Id:";
		AF0F3683.AutoSize = true;
		AF0F3683.Cursor = System.Windows.Forms.Cursors.Hand;
		AF0F3683.Location = new System.Drawing.Point(411, 172);
		AF0F3683.Name = "ckbJoinGroup";
		AF0F3683.Size = new System.Drawing.Size(85, 20);
		AF0F3683.TabIndex = 5;
		AF0F3683.Text = "Join group";
		AF0F3683.UseVisualStyleBackColor = true;
		AF0F3683.CheckedChanged += new System.EventHandler(A1153939);
		plJoinGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plJoinGroup.Controls.Add(txtGroupId);
		plJoinGroup.Controls.Add(label5);
		plJoinGroup.Location = new System.Drawing.Point(411, 193);
		plJoinGroup.Name = "plJoinGroup";
		plJoinGroup.Size = new System.Drawing.Size(274, 31);
		plJoinGroup.TabIndex = 6;
		txtGroupId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtGroupId.Location = new System.Drawing.Point(58, 3);
		txtGroupId.Name = "txtGroupId";
		txtGroupId.Size = new System.Drawing.Size(211, 23);
		txtGroupId.TabIndex = 1;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(5, 6);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(56, 16);
		label5.TabIndex = 0;
		label5.Text = "Nhâ\u0323p Id:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(714, 279);
		base.Controls.Add(plJoinGroup);
		base.Controls.Add(B02C1832);
		base.Controls.Add(B238581F);
		base.Controls.Add(plTaoPage);
		base.Controls.Add(AF0F3683);
		base.Controls.Add(E5144728);
		base.Controls.Add(ckbFollow);
		base.Controls.Add(E2990EB8);
		base.Controls.Add(ckbTaoPage);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhTaoPage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhTaoPage_Load);
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		plTaoPage.ResumeLayout(false);
		plTaoPage.PerformLayout();
		plCapNhatThongTin.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D536579C).EndInit();
		B238581F.ResumeLayout(false);
		B238581F.PerformLayout();
		B02C1832.ResumeLayout(false);
		B02C1832.PerformLayout();
		plJoinGroup.ResumeLayout(false);
		plJoinGroup.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
