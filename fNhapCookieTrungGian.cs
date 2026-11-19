using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fNhapCookieTrungGian : Form
{
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel D5B31A88;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button BEA95999;

	internal BunifuDragControl B7263587;

	internal PictureBox pictureBox1;

	internal Label label2;

	internal TextBox txtCookie;

	internal Button btnCheckLiveTokenTg;

	public fNhapCookieTrungGian()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		bool_0 = false;
	}

	private void D824A5B3(object sender, EventArgs e)
	{
		Close();
	}

	private void BEA95999_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configGeneral").method_4("cookie", txtCookie.Text);
		C5034B95.smethod_1("configGeneral");
		bool_0 = true;
		Close();
	}

	private void F507972C(object sender, EventArgs e)
	{
		Close();
	}

	private void fNhapCookieTrungGian_Load(object sender, EventArgs e)
	{
		txtCookie.Text = C5034B95.smethod_0("configGeneral").BDB80B23("cookie");
	}

	private void btnCheckLiveTokenTg_Click(object sender, EventArgs e)
	{
		if (CommonRequest.smethod_0(txtCookie.Text, "", "", 0).StartsWith("1|"))
		{
			MsBoxHelper.Show("Cookie live!");
		}
		else
		{
			MsBoxHelper.Show("Cookie die!");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNhapCookieTrungGian));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		D5B31A88 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		BEA95999 = new System.Windows.Forms.Button();
		B7263587 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		label2 = new System.Windows.Forms.Label();
		txtCookie = new System.Windows.Forms.TextBox();
		btnCheckLiveTokenTg = new System.Windows.Forms.Button();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(449, 34);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(D5B31A88);
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(449, 28);
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
		btnMinimize.Location = new System.Drawing.Point(417, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 28);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(D824A5B3);
		D5B31A88.BackColor = System.Drawing.Color.Transparent;
		D5B31A88.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D5B31A88.Dock = System.Windows.Forms.DockStyle.Fill;
		D5B31A88.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D5B31A88.ForeColor = System.Drawing.Color.Black;
		D5B31A88.Location = new System.Drawing.Point(0, 0);
		D5B31A88.Name = "bunifuCustomLabel1";
		D5B31A88.Size = new System.Drawing.Size(449, 28);
		D5B31A88.TabIndex = 1;
		D5B31A88.Text = "Nhập Cookie trung gian";
		D5B31A88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(230, 112);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F507972C);
		BEA95999.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		BEA95999.Cursor = System.Windows.Forms.Cursors.Hand;
		BEA95999.FlatAppearance.BorderSize = 0;
		BEA95999.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BEA95999.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BEA95999.ForeColor = System.Drawing.Color.White;
		BEA95999.Location = new System.Drawing.Point(126, 112);
		BEA95999.Name = "btnAdd";
		BEA95999.Size = new System.Drawing.Size(92, 29);
		BEA95999.TabIndex = 3;
		BEA95999.Text = "Lưu";
		BEA95999.UseVisualStyleBackColor = false;
		BEA95999.Click += new System.EventHandler(BEA95999_Click);
		B7263587.Fixed = true;
		B7263587.Horizontal = true;
		B7263587.TargetControl = D5B31A88;
		B7263587.Vertical = true;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(31, 61);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(112, 16);
		label2.TabIndex = 36;
		label2.Text = "Cookie trung gian:";
		txtCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCookie.Location = new System.Drawing.Point(147, 58);
		txtCookie.Name = "txtCookie";
		txtCookie.Size = new System.Drawing.Size(196, 23);
		txtCookie.TabIndex = 35;
		btnCheckLiveTokenTg.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCheckLiveTokenTg.Location = new System.Drawing.Point(349, 58);
		btnCheckLiveTokenTg.Name = "btnCheckLiveTokenTg";
		btnCheckLiveTokenTg.Size = new System.Drawing.Size(65, 23);
		btnCheckLiveTokenTg.TabIndex = 37;
		btnCheckLiveTokenTg.Text = "Kiểm tra";
		btnCheckLiveTokenTg.Click += new System.EventHandler(btnCheckLiveTokenTg_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(449, 159);
		base.Controls.Add(label2);
		base.Controls.Add(txtCookie);
		base.Controls.Add(btnCheckLiveTokenTg);
		base.Controls.Add(btnCancel);
		base.Controls.Add(BEA95999);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fNhapCookieTrungGian";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fNhapCookieTrungGian_Load);
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
