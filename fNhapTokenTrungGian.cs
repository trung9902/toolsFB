using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fNhapTokenTrungGian : Form
{
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel AA3F9B9F;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button C20F4725;

	internal Button E8337B0B;

	internal BunifuDragControl AABE8E90;

	internal PictureBox pictureBox1;

	internal Label label2;

	internal TextBox txtToken;

	internal Button btnCheckLiveTokenTg;

	internal Label label1;

	internal TextBox txtCookie;

	public fNhapTokenTrungGian()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		bool_0 = false;
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E8337B0B_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configGeneral").method_4("cookie", txtCookie.Text);
		C5034B95.smethod_0("configGeneral").method_4("token", txtToken.Text);
		C5034B95.smethod_1("configGeneral");
		bool_0 = true;
		Close();
	}

	private void C20F4725_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fNhapTokenTrungGian_Load(object sender, EventArgs e)
	{
		txtCookie.Text = C5034B95.smethod_0("configGeneral").BDB80B23("cookie");
		txtToken.Text = C5034B95.smethod_0("configGeneral").BDB80B23("token");
	}

	private void AEB19310(object sender, EventArgs e)
	{
		string text = "";
		text = (CommonRequest.B4B29420(txtCookie.Text, txtToken.Text, "", "") ? "Live" : ((!CommonRequest.smethod_0(txtCookie.Text, "", "", 0).StartsWith("1|")) ? "Cookie die" : "Token die"));
		MsBoxHelper.Show(text + "!");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNhapTokenTrungGian));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		AA3F9B9F = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		C20F4725 = new System.Windows.Forms.Button();
		E8337B0B = new System.Windows.Forms.Button();
		AABE8E90 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		label2 = new System.Windows.Forms.Label();
		txtToken = new System.Windows.Forms.TextBox();
		btnCheckLiveTokenTg = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		txtCookie = new System.Windows.Forms.TextBox();
		bunifuCards1.SuspendLayout();
		AA3F9B9F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(AA3F9B9F);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(449, 34);
		bunifuCards1.TabIndex = 0;
		AA3F9B9F.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		AA3F9B9F.BackColor = System.Drawing.Color.White;
		AA3F9B9F.Controls.Add(pictureBox1);
		AA3F9B9F.Controls.Add(btnMinimize);
		AA3F9B9F.Controls.Add(bunifuCustomLabel1);
		AA3F9B9F.Location = new System.Drawing.Point(0, 3);
		AA3F9B9F.Name = "pnlHeader";
		AA3F9B9F.Size = new System.Drawing.Size(449, 28);
		AA3F9B9F.TabIndex = 9;
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
		btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(449, 28);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Nhập Token trung gian";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C20F4725.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C20F4725.BackColor = System.Drawing.Color.Maroon;
		C20F4725.Cursor = System.Windows.Forms.Cursors.Hand;
		C20F4725.FlatAppearance.BorderSize = 0;
		C20F4725.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C20F4725.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C20F4725.ForeColor = System.Drawing.Color.White;
		C20F4725.Location = new System.Drawing.Point(230, 143);
		C20F4725.Name = "btnCancel";
		C20F4725.Size = new System.Drawing.Size(92, 29);
		C20F4725.TabIndex = 4;
		C20F4725.Text = "Đo\u0301ng";
		C20F4725.UseVisualStyleBackColor = false;
		C20F4725.Click += new System.EventHandler(C20F4725_Click);
		E8337B0B.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E8337B0B.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		E8337B0B.Cursor = System.Windows.Forms.Cursors.Hand;
		E8337B0B.FlatAppearance.BorderSize = 0;
		E8337B0B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E8337B0B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E8337B0B.ForeColor = System.Drawing.Color.White;
		E8337B0B.Location = new System.Drawing.Point(126, 143);
		E8337B0B.Name = "btnAdd";
		E8337B0B.Size = new System.Drawing.Size(92, 29);
		E8337B0B.TabIndex = 3;
		E8337B0B.Text = "Lưu";
		E8337B0B.UseVisualStyleBackColor = false;
		E8337B0B.Click += new System.EventHandler(E8337B0B_Click);
		AABE8E90.Fixed = true;
		AABE8E90.Horizontal = true;
		AABE8E90.TargetControl = bunifuCustomLabel1;
		AABE8E90.Vertical = true;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(26, 95);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(109, 16);
		label2.TabIndex = 36;
		label2.Text = "Token trung gian:";
		txtToken.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtToken.Location = new System.Drawing.Point(142, 92);
		txtToken.Name = "txtToken";
		txtToken.Size = new System.Drawing.Size(196, 23);
		txtToken.TabIndex = 35;
		btnCheckLiveTokenTg.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCheckLiveTokenTg.Location = new System.Drawing.Point(344, 62);
		btnCheckLiveTokenTg.Name = "btnCheckLiveTokenTg";
		btnCheckLiveTokenTg.Size = new System.Drawing.Size(65, 54);
		btnCheckLiveTokenTg.TabIndex = 37;
		btnCheckLiveTokenTg.Text = "Kiểm tra";
		btnCheckLiveTokenTg.Click += new System.EventHandler(AEB19310);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(26, 66);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(112, 16);
		label1.TabIndex = 39;
		label1.Text = "Cookie trung gian:";
		txtCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCookie.Location = new System.Drawing.Point(142, 63);
		txtCookie.Name = "txtCookie";
		txtCookie.Size = new System.Drawing.Size(196, 23);
		txtCookie.TabIndex = 38;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(449, 190);
		base.Controls.Add(label1);
		base.Controls.Add(txtCookie);
		base.Controls.Add(label2);
		base.Controls.Add(txtToken);
		base.Controls.Add(btnCheckLiveTokenTg);
		base.Controls.Add(C20F4725);
		base.Controls.Add(E8337B0B);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fNhapTokenTrungGian";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fNhapTokenTrungGian_Load);
		bunifuCards1.ResumeLayout(false);
		AA3F9B9F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
