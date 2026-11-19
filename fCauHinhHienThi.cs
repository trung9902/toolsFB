using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhHienThi : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel EB2C2518;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCustomLabel lblStatus;

	internal PictureBox pictureBox1;

	internal CheckBox ckbToken;

	internal CheckBox ckbCookie;

	internal CheckBox ckbEmail;

	internal CheckBox ckbTen;

	internal CheckBox F6998901;

	internal CheckBox F4246A04;

	internal CheckBox D21A60A8;

	internal CheckBox ckbGioiTinh;

	internal CheckBox ckbMatKhau;

	internal CheckBox ckbMatKhauMail;

	internal CheckBox EB1DFF2E;

	internal CheckBox ckbMa2FA;

	internal CheckBox ckbUseragent;

	internal CheckBox D7910399;

	internal CheckBox B0342718;

	internal CheckBox ckbAvatar;

	internal CheckBox EB16083E;

	internal CheckBox CB18F79C;

	internal CheckBox ckbGhiChu;

	internal CheckBox DD1D6CBD;

	internal CheckBox ckbFollow;

	internal CheckBox ckbInteractEnd;

	internal CheckBox CFA4E539;

	internal CheckBox ckbPhone;

	internal CheckBox CA3B7987;

	internal CheckBox B8874199;

	internal CheckBox C29572B7;

	internal CheckBox ckbBM;

	internal CheckBox ckbHometown;

	internal CheckBox ckbCurrentCity;

	internal CheckBox ckbWallPosts;

	internal CheckBox E7967691;

	internal CheckBox ckbJob;

	internal CheckBox F19715BB;

	internal CheckBox F0322A2D;

	internal CheckBox ckbKichBan;

	internal Button button1;

	internal CheckBox ckbPassMailRecovery;

	internal CheckBox ckbPagePro5;

	internal CheckBox A193DE81;

	public fCauHinhHienThi()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void D20EB69E(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			ckbKichBan.Visible = true;
		}
		else
		{
			Close();
		}
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configDatagridview").method_4("cToken", ckbToken.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbCookie", ckbCookie.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbEmail", ckbEmail.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbEmailFull", F0322A2D.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbTen", ckbTen.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbBanBe", F6998901.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbNhom", F4246A04.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbPagePro5", ckbPagePro5.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbNgaySinh", D21A60A8.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbGioiTinh", ckbGioiTinh.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbMatKhau", ckbMatKhau.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbMatKhauMail", ckbMatKhauMail.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbOAuth2", EB1DFF2E.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbCookieHotmail", A193DE81.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbMa2FA", ckbMa2FA.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbUseragent", ckbUseragent.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbProxy", D7910399.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbNgayTao", B0342718.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbAvatar", ckbAvatar.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbProfile", EB16083E.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbTinhTrang", CB18F79C.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbThuMuc", DD1D6CBD.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbGhiChu", ckbGhiChu.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbStatus282", F19715BB.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbFollow", ckbFollow.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbInteractEnd", ckbInteractEnd.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbMailRecovery", CFA4E539.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbPassMailRecovery", ckbPassMailRecovery.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbPhone", ckbPhone.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbHometown", ckbHometown.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbLocation", CA3B7987.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbCurrentCity", ckbCurrentCity.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbJob", ckbJob.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbDating", B8874199.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbAds", C29572B7.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbBM", ckbBM.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbWallPosts", ckbWallPosts.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbFbBlock", E7967691.Checked);
		C5034B95.smethod_0("configDatagridview").method_4("ckbKichBan", ckbKichBan.Checked);
		if (ckbMa2FA.Checked && !Base.smethod_3())
		{
			C5034B95.smethod_0("configDatagridview").method_4("ckbMa2FA", false);
		}
		C5034B95.smethod_1("configDatagridview");
		Close();
	}

	private void B81A0E38(object sender, EventArgs e)
	{
		Close();
	}

	private void F1B2B32F(object sender, EventArgs e)
	{
	}

	private void fCauHinhHienThi_Load(object sender, EventArgs e)
	{
		ckbToken.Checked = C5034B95.smethod_0("configDatagridview").method_3("cToken");
		ckbCookie.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbCookie");
		ckbEmail.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbEmail");
		F0322A2D.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbEmailFull");
		ckbTen.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbTen");
		F6998901.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbBanBe");
		F4246A04.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbNhom");
		ckbPagePro5.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbPagePro5");
		D21A60A8.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbNgaySinh");
		ckbGioiTinh.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbGioiTinh");
		ckbMatKhau.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbMatKhau");
		ckbMatKhauMail.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbMatKhauMail");
		EB1DFF2E.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbOAuth2");
		A193DE81.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbCookieHotmail");
		ckbMa2FA.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbMa2FA");
		ckbUseragent.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbUseragent");
		D7910399.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbProxy");
		B0342718.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbNgayTao");
		ckbAvatar.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbAvatar");
		EB16083E.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbProfile");
		CB18F79C.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbTinhTrang");
		DD1D6CBD.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbThuMuc");
		ckbGhiChu.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbGhiChu");
		F19715BB.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbStatus282");
		ckbFollow.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbFollow");
		ckbInteractEnd.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbInteractEnd");
		CFA4E539.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbMailRecovery");
		ckbPassMailRecovery.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbPassMailRecovery");
		ckbPhone.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbPhone");
		ckbHometown.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbHometown");
		CA3B7987.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbLocation");
		ckbCurrentCity.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbCurrentCity");
		ckbJob.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbJob");
		B8874199.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbDating");
		C29572B7.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbAds");
		ckbBM.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbBM");
		ckbWallPosts.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbWallPosts");
		E7967691.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbFbBlock");
		ckbKichBan.Checked = C5034B95.smethod_0("configDatagridview").method_3("ckbKichBan");
		D098CB0E(null, null);
	}

	private void D098CB0E(object sender, EventArgs e)
	{
		if (!ckbEmail.Checked)
		{
			F0322A2D.Enabled = false;
			F0322A2D.Checked = false;
		}
		else
		{
			F0322A2D.Enabled = true;
		}
	}

	private void F58A6AA7(object sender, EventArgs e)
	{
		List<string> list = new List<string> { "ckbMatKhau", "ckbTen", "ckbProxy", "ckbInteractEnd", "ckbTinhTrang", "ckbThuMuc", "ckbEmail" };
		List<CheckBox> list2 = base.Controls.OfType<CheckBox>().ToList();
		foreach (CheckBox item in list2)
		{
			item.Checked = list.Contains(item.Name);
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhHienThi));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		EB2C2518 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		lblStatus = new Bunifu.Framework.UI.BunifuCustomLabel();
		ckbToken = new System.Windows.Forms.CheckBox();
		ckbCookie = new System.Windows.Forms.CheckBox();
		ckbEmail = new System.Windows.Forms.CheckBox();
		ckbTen = new System.Windows.Forms.CheckBox();
		F6998901 = new System.Windows.Forms.CheckBox();
		F4246A04 = new System.Windows.Forms.CheckBox();
		D21A60A8 = new System.Windows.Forms.CheckBox();
		ckbGioiTinh = new System.Windows.Forms.CheckBox();
		ckbMatKhau = new System.Windows.Forms.CheckBox();
		ckbMatKhauMail = new System.Windows.Forms.CheckBox();
		EB1DFF2E = new System.Windows.Forms.CheckBox();
		ckbMa2FA = new System.Windows.Forms.CheckBox();
		ckbUseragent = new System.Windows.Forms.CheckBox();
		D7910399 = new System.Windows.Forms.CheckBox();
		B0342718 = new System.Windows.Forms.CheckBox();
		ckbAvatar = new System.Windows.Forms.CheckBox();
		EB16083E = new System.Windows.Forms.CheckBox();
		CB18F79C = new System.Windows.Forms.CheckBox();
		ckbGhiChu = new System.Windows.Forms.CheckBox();
		DD1D6CBD = new System.Windows.Forms.CheckBox();
		ckbFollow = new System.Windows.Forms.CheckBox();
		ckbInteractEnd = new System.Windows.Forms.CheckBox();
		CFA4E539 = new System.Windows.Forms.CheckBox();
		ckbPhone = new System.Windows.Forms.CheckBox();
		CA3B7987 = new System.Windows.Forms.CheckBox();
		B8874199 = new System.Windows.Forms.CheckBox();
		C29572B7 = new System.Windows.Forms.CheckBox();
		ckbBM = new System.Windows.Forms.CheckBox();
		ckbHometown = new System.Windows.Forms.CheckBox();
		ckbCurrentCity = new System.Windows.Forms.CheckBox();
		ckbWallPosts = new System.Windows.Forms.CheckBox();
		E7967691 = new System.Windows.Forms.CheckBox();
		ckbJob = new System.Windows.Forms.CheckBox();
		F19715BB = new System.Windows.Forms.CheckBox();
		F0322A2D = new System.Windows.Forms.CheckBox();
		ckbKichBan = new System.Windows.Forms.CheckBox();
		button1 = new System.Windows.Forms.Button();
		ckbPassMailRecovery = new System.Windows.Forms.CheckBox();
		ckbPagePro5 = new System.Windows.Forms.CheckBox();
		A193DE81 = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		EB2C2518.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(EB2C2518);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(613, 38);
		bunifuCards1.TabIndex = 0;
		EB2C2518.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EB2C2518.BackColor = System.Drawing.Color.White;
		EB2C2518.Controls.Add(pictureBox1);
		EB2C2518.Controls.Add(btnMinimize);
		EB2C2518.Controls.Add(bunifuCustomLabel1);
		EB2C2518.Location = new System.Drawing.Point(0, 5);
		EB2C2518.Name = "pnlHeader";
		EB2C2518.Size = new System.Drawing.Size(613, 32);
		EB2C2518.TabIndex = 9;
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
		btnMinimize.Location = new System.Drawing.Point(581, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(D20EB69E);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(613, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(369, 294);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(B81A0E38);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(265, 294);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		lblStatus.BackColor = System.Drawing.Color.Transparent;
		lblStatus.Cursor = System.Windows.Forms.Cursors.SizeAll;
		lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblStatus.ForeColor = System.Drawing.Color.Black;
		lblStatus.Location = new System.Drawing.Point(51, 41);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(384, 32);
		lblStatus.TabIndex = 21;
		lblStatus.Text = "Vui lo\u0300ng cho\u0323n như\u0303ng cô\u0323t câ\u0300n hiê\u0309n thi\u0323!";
		lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		lblStatus.Click += new System.EventHandler(F1B2B32F);
		ckbToken.AutoSize = true;
		ckbToken.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbToken.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbToken.Location = new System.Drawing.Point(31, 137);
		ckbToken.Name = "ckbToken";
		ckbToken.Size = new System.Drawing.Size(61, 20);
		ckbToken.TabIndex = 22;
		ckbToken.Text = "Token";
		ckbToken.UseVisualStyleBackColor = true;
		ckbCookie.AutoSize = true;
		ckbCookie.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbCookie.Location = new System.Drawing.Point(31, 163);
		ckbCookie.Name = "ckbCookie";
		ckbCookie.Size = new System.Drawing.Size(64, 20);
		ckbCookie.TabIndex = 22;
		ckbCookie.Text = "Cookie";
		ckbCookie.UseVisualStyleBackColor = true;
		ckbEmail.AutoSize = true;
		ckbEmail.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbEmail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbEmail.Location = new System.Drawing.Point(31, 189);
		ckbEmail.Name = "ckbEmail";
		ckbEmail.Size = new System.Drawing.Size(57, 20);
		ckbEmail.TabIndex = 22;
		ckbEmail.Text = "Email";
		ckbEmail.UseVisualStyleBackColor = true;
		ckbEmail.CheckedChanged += new System.EventHandler(D098CB0E);
		ckbTen.AutoSize = true;
		ckbTen.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTen.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbTen.Location = new System.Drawing.Point(158, 85);
		ckbTen.Name = "ckbTen";
		ckbTen.Size = new System.Drawing.Size(48, 20);
		ckbTen.TabIndex = 22;
		ckbTen.Text = "Tên";
		ckbTen.UseVisualStyleBackColor = true;
		F6998901.AutoSize = true;
		F6998901.Cursor = System.Windows.Forms.Cursors.Hand;
		F6998901.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F6998901.Location = new System.Drawing.Point(158, 137);
		F6998901.Name = "ckbBanBe";
		F6998901.Size = new System.Drawing.Size(65, 20);
		F6998901.TabIndex = 22;
		F6998901.Text = "Ba\u0323n be\u0300";
		F6998901.UseVisualStyleBackColor = true;
		F4246A04.AutoSize = true;
		F4246A04.Cursor = System.Windows.Forms.Cursors.Hand;
		F4246A04.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F4246A04.Location = new System.Drawing.Point(158, 163);
		F4246A04.Name = "ckbNhom";
		F4246A04.Size = new System.Drawing.Size(59, 20);
		F4246A04.TabIndex = 22;
		F4246A04.Text = "Nho\u0301m";
		F4246A04.UseVisualStyleBackColor = true;
		D21A60A8.AutoSize = true;
		D21A60A8.Cursor = System.Windows.Forms.Cursors.Hand;
		D21A60A8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D21A60A8.Location = new System.Drawing.Point(277, 85);
		D21A60A8.Name = "ckbNgaySinh";
		D21A60A8.Size = new System.Drawing.Size(81, 20);
		D21A60A8.TabIndex = 22;
		D21A60A8.Text = "Nga\u0300y sinh";
		D21A60A8.UseVisualStyleBackColor = true;
		ckbGioiTinh.AutoSize = true;
		ckbGioiTinh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGioiTinh.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbGioiTinh.Location = new System.Drawing.Point(277, 137);
		ckbGioiTinh.Name = "ckbGioiTinh";
		ckbGioiTinh.Size = new System.Drawing.Size(72, 20);
		ckbGioiTinh.TabIndex = 22;
		ckbGioiTinh.Text = "Giơ\u0301i ti\u0301nh";
		ckbGioiTinh.UseVisualStyleBackColor = true;
		ckbMatKhau.AutoSize = true;
		ckbMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbMatKhau.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbMatKhau.Location = new System.Drawing.Point(31, 85);
		ckbMatKhau.Name = "ckbMatKhau";
		ckbMatKhau.Size = new System.Drawing.Size(78, 20);
		ckbMatKhau.TabIndex = 22;
		ckbMatKhau.Text = "Mâ\u0323t khâ\u0309u";
		ckbMatKhau.UseVisualStyleBackColor = true;
		ckbMatKhauMail.AutoSize = true;
		ckbMatKhauMail.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbMatKhauMail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbMatKhauMail.Location = new System.Drawing.Point(31, 215);
		ckbMatKhauMail.Name = "ckbMatKhauMail";
		ckbMatKhauMail.Size = new System.Drawing.Size(106, 20);
		ckbMatKhauMail.TabIndex = 22;
		ckbMatKhauMail.Text = "Mâ\u0323t khâ\u0309u mail";
		ckbMatKhauMail.UseVisualStyleBackColor = true;
		EB1DFF2E.AutoSize = true;
		EB1DFF2E.Cursor = System.Windows.Forms.Cursors.Hand;
		EB1DFF2E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EB1DFF2E.Location = new System.Drawing.Point(158, 215);
		EB1DFF2E.Name = "ckbOAuth2";
		EB1DFF2E.Size = new System.Drawing.Size(68, 20);
		EB1DFF2E.TabIndex = 22;
		EB1DFF2E.Text = "OAuth2";
		EB1DFF2E.UseVisualStyleBackColor = true;
		ckbMa2FA.AutoSize = true;
		ckbMa2FA.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbMa2FA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbMa2FA.Location = new System.Drawing.Point(31, 111);
		ckbMa2FA.Name = "ckbMa2FA";
		ckbMa2FA.Size = new System.Drawing.Size(69, 20);
		ckbMa2FA.TabIndex = 22;
		ckbMa2FA.Text = "Ma\u0303 2FA";
		ckbMa2FA.UseVisualStyleBackColor = true;
		ckbUseragent.AutoSize = true;
		ckbUseragent.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUseragent.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbUseragent.Location = new System.Drawing.Point(277, 163);
		ckbUseragent.Name = "ckbUseragent";
		ckbUseragent.Size = new System.Drawing.Size(84, 20);
		ckbUseragent.TabIndex = 22;
		ckbUseragent.Text = "Useragent";
		ckbUseragent.UseVisualStyleBackColor = true;
		D7910399.AutoSize = true;
		D7910399.Cursor = System.Windows.Forms.Cursors.Hand;
		D7910399.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D7910399.Location = new System.Drawing.Point(277, 189);
		D7910399.Name = "ckbProxy";
		D7910399.Size = new System.Drawing.Size(57, 20);
		D7910399.TabIndex = 22;
		D7910399.Text = "Proxy";
		D7910399.UseVisualStyleBackColor = true;
		B0342718.AutoSize = true;
		B0342718.Cursor = System.Windows.Forms.Cursors.Hand;
		B0342718.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B0342718.Location = new System.Drawing.Point(277, 215);
		B0342718.Name = "ckbNgayTao";
		B0342718.Size = new System.Drawing.Size(76, 20);
		B0342718.TabIndex = 22;
		B0342718.Text = "Nga\u0300y ta\u0323o";
		B0342718.UseVisualStyleBackColor = true;
		ckbAvatar.AutoSize = true;
		ckbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAvatar.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbAvatar.Location = new System.Drawing.Point(277, 241);
		ckbAvatar.Name = "ckbAvatar";
		ckbAvatar.Size = new System.Drawing.Size(63, 20);
		ckbAvatar.TabIndex = 22;
		ckbAvatar.Text = "Avatar";
		ckbAvatar.UseVisualStyleBackColor = true;
		EB16083E.AutoSize = true;
		EB16083E.Cursor = System.Windows.Forms.Cursors.Hand;
		EB16083E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EB16083E.Location = new System.Drawing.Point(373, 85);
		EB16083E.Name = "ckbProfile";
		EB16083E.Size = new System.Drawing.Size(62, 20);
		EB16083E.TabIndex = 22;
		EB16083E.Text = "Profile";
		EB16083E.UseVisualStyleBackColor = true;
		CB18F79C.AutoSize = true;
		CB18F79C.Cursor = System.Windows.Forms.Cursors.Hand;
		CB18F79C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CB18F79C.Location = new System.Drawing.Point(373, 137);
		CB18F79C.Name = "ckbTinhTrang";
		CB18F79C.Size = new System.Drawing.Size(85, 20);
		CB18F79C.TabIndex = 22;
		CB18F79C.Text = "Ti\u0300nh tra\u0323ng";
		CB18F79C.UseVisualStyleBackColor = true;
		ckbGhiChu.AutoSize = true;
		ckbGhiChu.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGhiChu.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbGhiChu.Location = new System.Drawing.Point(373, 189);
		ckbGhiChu.Name = "ckbGhiChu";
		ckbGhiChu.Size = new System.Drawing.Size(68, 20);
		ckbGhiChu.TabIndex = 22;
		ckbGhiChu.Text = "Ghi chú";
		ckbGhiChu.UseVisualStyleBackColor = true;
		DD1D6CBD.AutoSize = true;
		DD1D6CBD.Cursor = System.Windows.Forms.Cursors.Hand;
		DD1D6CBD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		DD1D6CBD.Location = new System.Drawing.Point(373, 163);
		DD1D6CBD.Name = "ckbThuMuc";
		DD1D6CBD.Size = new System.Drawing.Size(77, 20);
		DD1D6CBD.TabIndex = 22;
		DD1D6CBD.Text = "Thư mục";
		DD1D6CBD.UseVisualStyleBackColor = true;
		ckbFollow.AutoSize = true;
		ckbFollow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFollow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbFollow.Location = new System.Drawing.Point(158, 111);
		ckbFollow.Name = "ckbFollow";
		ckbFollow.Size = new System.Drawing.Size(76, 20);
		ckbFollow.TabIndex = 22;
		ckbFollow.Text = "Theo do\u0303i";
		ckbFollow.UseVisualStyleBackColor = true;
		ckbInteractEnd.AutoSize = true;
		ckbInteractEnd.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbInteractEnd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbInteractEnd.Location = new System.Drawing.Point(373, 111);
		ckbInteractEnd.Name = "ckbInteractEnd";
		ckbInteractEnd.Size = new System.Drawing.Size(111, 20);
		ckbInteractEnd.TabIndex = 22;
		ckbInteractEnd.Text = "Tương ta\u0301c cuô\u0301i";
		ckbInteractEnd.UseVisualStyleBackColor = true;
		CFA4E539.AutoSize = true;
		CFA4E539.Cursor = System.Windows.Forms.Cursors.Hand;
		CFA4E539.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CFA4E539.Location = new System.Drawing.Point(30, 241);
		CFA4E539.Name = "ckbMailRecovery";
		CFA4E539.Size = new System.Drawing.Size(107, 20);
		CFA4E539.TabIndex = 22;
		CFA4E539.Text = "Mail khôi phục";
		CFA4E539.UseVisualStyleBackColor = true;
		ckbPhone.AutoSize = true;
		ckbPhone.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPhone.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbPhone.Location = new System.Drawing.Point(277, 111);
		ckbPhone.Name = "ckbPhone";
		ckbPhone.Size = new System.Drawing.Size(61, 20);
		ckbPhone.TabIndex = 22;
		ckbPhone.Text = "Phone";
		ckbPhone.UseVisualStyleBackColor = true;
		CA3B7987.AutoSize = true;
		CA3B7987.Cursor = System.Windows.Forms.Cursors.Hand;
		CA3B7987.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CA3B7987.Location = new System.Drawing.Point(496, 111);
		CA3B7987.Name = "ckbLocation";
		CA3B7987.Size = new System.Drawing.Size(73, 20);
		CA3B7987.TabIndex = 22;
		CA3B7987.Text = "Location";
		CA3B7987.UseVisualStyleBackColor = true;
		B8874199.AutoSize = true;
		B8874199.Cursor = System.Windows.Forms.Cursors.Hand;
		B8874199.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B8874199.Location = new System.Drawing.Point(373, 215);
		B8874199.Name = "ckbDating";
		B8874199.Size = new System.Drawing.Size(62, 20);
		B8874199.TabIndex = 22;
		B8874199.Text = "Dating";
		B8874199.UseVisualStyleBackColor = true;
		C29572B7.AutoSize = true;
		C29572B7.Cursor = System.Windows.Forms.Cursors.Hand;
		C29572B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C29572B7.Location = new System.Drawing.Point(496, 85);
		C29572B7.Name = "ckbAds";
		C29572B7.Size = new System.Drawing.Size(47, 20);
		C29572B7.TabIndex = 22;
		C29572B7.Text = "Ads";
		C29572B7.UseVisualStyleBackColor = true;
		ckbBM.AutoSize = true;
		ckbBM.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBM.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbBM.Location = new System.Drawing.Point(547, 85);
		ckbBM.Name = "ckbBM";
		ckbBM.Size = new System.Drawing.Size(43, 20);
		ckbBM.TabIndex = 22;
		ckbBM.Text = "BM";
		ckbBM.UseVisualStyleBackColor = true;
		ckbHometown.AutoSize = true;
		ckbHometown.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHometown.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbHometown.Location = new System.Drawing.Point(496, 137);
		ckbHometown.Name = "ckbHometown";
		ckbHometown.Size = new System.Drawing.Size(87, 20);
		ckbHometown.TabIndex = 22;
		ckbHometown.Text = "Hometown";
		ckbHometown.UseVisualStyleBackColor = true;
		ckbCurrentCity.AutoSize = true;
		ckbCurrentCity.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCurrentCity.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbCurrentCity.Location = new System.Drawing.Point(496, 163);
		ckbCurrentCity.Name = "ckbCurrentCity";
		ckbCurrentCity.Size = new System.Drawing.Size(94, 20);
		ckbCurrentCity.TabIndex = 22;
		ckbCurrentCity.Text = "Current City";
		ckbCurrentCity.UseVisualStyleBackColor = true;
		ckbWallPosts.AutoSize = true;
		ckbWallPosts.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWallPosts.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbWallPosts.Location = new System.Drawing.Point(496, 241);
		ckbWallPosts.Name = "ckbWallPosts";
		ckbWallPosts.Size = new System.Drawing.Size(85, 20);
		ckbWallPosts.TabIndex = 22;
		ckbWallPosts.Text = "Wall posts";
		ckbWallPosts.UseVisualStyleBackColor = true;
		E7967691.AutoSize = true;
		E7967691.Cursor = System.Windows.Forms.Cursors.Hand;
		E7967691.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E7967691.Location = new System.Drawing.Point(496, 215);
		E7967691.Name = "ckbFbBlock";
		E7967691.Size = new System.Drawing.Size(73, 20);
		E7967691.TabIndex = 22;
		E7967691.Text = "Fb Block";
		E7967691.UseVisualStyleBackColor = true;
		ckbJob.AutoSize = true;
		ckbJob.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbJob.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbJob.Location = new System.Drawing.Point(496, 189);
		ckbJob.Name = "ckbJob";
		ckbJob.Size = new System.Drawing.Size(45, 20);
		ckbJob.TabIndex = 22;
		ckbJob.Text = "Job";
		ckbJob.UseVisualStyleBackColor = true;
		F19715BB.AutoSize = true;
		F19715BB.Cursor = System.Windows.Forms.Cursors.Hand;
		F19715BB.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F19715BB.Location = new System.Drawing.Point(373, 241);
		F19715BB.Name = "ckbStatus282";
		F19715BB.Size = new System.Drawing.Size(87, 20);
		F19715BB.TabIndex = 22;
		F19715BB.Text = "Status 282";
		F19715BB.UseVisualStyleBackColor = true;
		F0322A2D.AutoSize = true;
		F0322A2D.Cursor = System.Windows.Forms.Cursors.Hand;
		F0322A2D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F0322A2D.Location = new System.Drawing.Point(85, 189);
		F0322A2D.Name = "ckbEmailFull";
		F0322A2D.Size = new System.Drawing.Size(46, 20);
		F0322A2D.TabIndex = 22;
		F0322A2D.Text = "Full";
		F0322A2D.UseVisualStyleBackColor = true;
		ckbKichBan.AutoSize = true;
		ckbKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbKichBan.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbKichBan.Location = new System.Drawing.Point(496, 376);
		ckbKichBan.Name = "ckbKichBan";
		ckbKichBan.Size = new System.Drawing.Size(74, 20);
		ckbKichBan.TabIndex = 22;
		ckbKichBan.Text = "Kịch bản";
		ckbKichBan.UseVisualStyleBackColor = true;
		ckbKichBan.Visible = false;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		button1.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(133, 294);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(119, 29);
		button1.TabIndex = 3;
		button1.Text = "Hiê\u0309n thi\u0323 tô\u0301i ưu";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(F58A6AA7);
		ckbPassMailRecovery.AutoSize = true;
		ckbPassMailRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPassMailRecovery.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbPassMailRecovery.Location = new System.Drawing.Point(30, 267);
		ckbPassMailRecovery.Name = "ckbPassMailRecovery";
		ckbPassMailRecovery.Size = new System.Drawing.Size(138, 20);
		ckbPassMailRecovery.TabIndex = 23;
		ckbPassMailRecovery.Text = "Pass mail khôi phu\u0323c";
		ckbPassMailRecovery.UseVisualStyleBackColor = true;
		ckbPagePro5.AutoSize = true;
		ckbPagePro5.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPagePro5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbPagePro5.Location = new System.Drawing.Point(158, 189);
		ckbPagePro5.Name = "ckbPagePro5";
		ckbPagePro5.Size = new System.Drawing.Size(54, 20);
		ckbPagePro5.TabIndex = 22;
		ckbPagePro5.Text = "Page";
		ckbPagePro5.UseVisualStyleBackColor = true;
		A193DE81.AutoSize = true;
		A193DE81.Cursor = System.Windows.Forms.Cursors.Hand;
		A193DE81.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A193DE81.Location = new System.Drawing.Point(158, 241);
		A193DE81.Name = "ckbCookieHotmail";
		A193DE81.Size = new System.Drawing.Size(111, 20);
		A193DE81.TabIndex = 22;
		A193DE81.Text = "Cookie Hotmail";
		A193DE81.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(613, 335);
		base.Controls.Add(ckbPassMailRecovery);
		base.Controls.Add(D21A60A8);
		base.Controls.Add(DD1D6CBD);
		base.Controls.Add(ckbPhone);
		base.Controls.Add(ckbBM);
		base.Controls.Add(C29572B7);
		base.Controls.Add(B8874199);
		base.Controls.Add(E7967691);
		base.Controls.Add(ckbKichBan);
		base.Controls.Add(ckbWallPosts);
		base.Controls.Add(ckbJob);
		base.Controls.Add(ckbCurrentCity);
		base.Controls.Add(ckbHometown);
		base.Controls.Add(CA3B7987);
		base.Controls.Add(A193DE81);
		base.Controls.Add(CFA4E539);
		base.Controls.Add(F19715BB);
		base.Controls.Add(ckbGhiChu);
		base.Controls.Add(ckbInteractEnd);
		base.Controls.Add(CB18F79C);
		base.Controls.Add(EB16083E);
		base.Controls.Add(ckbAvatar);
		base.Controls.Add(B0342718);
		base.Controls.Add(D7910399);
		base.Controls.Add(ckbUseragent);
		base.Controls.Add(ckbMa2FA);
		base.Controls.Add(EB1DFF2E);
		base.Controls.Add(ckbMatKhauMail);
		base.Controls.Add(ckbMatKhau);
		base.Controls.Add(ckbGioiTinh);
		base.Controls.Add(ckbPagePro5);
		base.Controls.Add(F4246A04);
		base.Controls.Add(ckbFollow);
		base.Controls.Add(F6998901);
		base.Controls.Add(ckbTen);
		base.Controls.Add(F0322A2D);
		base.Controls.Add(ckbEmail);
		base.Controls.Add(ckbCookie);
		base.Controls.Add(ckbToken);
		base.Controls.Add(lblStatus);
		base.Controls.Add(btnCancel);
		base.Controls.Add(button1);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhHienThi";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhHienThi_Load);
		bunifuCards1.ResumeLayout(false);
		EB2C2518.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
