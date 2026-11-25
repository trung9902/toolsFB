using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhTaoShortcut : Form
{
	internal static bool bool_0;

	internal string E9204797 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel DC3A7B2F;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button E92B7699;

	internal Button DF82948A;

	internal Button btnAdd;

	internal BunifuDragControl F1097514;

	internal PictureBox pictureBox1;

	internal Label label1;

	internal TextBox DB06922F;

	internal Button D91C5036;

	internal Label D89D00A8;

	internal TextBox C68B9CAC;

	internal Button F4B7DC89;

	public fCauHinhTaoShortcut()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		bool_0 = false;
		string text = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
		string text2 = "C:\\Program Files (x64)\\Google\\Chrome\\Application\\chrome.exe";
		string text3 = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
		if (!File.Exists(text))
		{
			if (!File.Exists(text2))
			{
				if (File.Exists(text3))
				{
					E9204797 = text3;
				}
			}
			else
			{
				E9204797 = text2;
			}
		}
		else
		{
			E9204797 = text;
		}
	}

	private void E92B7699_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D29EE29C(object sender, EventArgs e)
	{
		if (DB06922F.Text.Trim() == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p đươ\u0300ng dâ\u0303n đê\u0301n Thư mu\u0323c lưu Shortcut!", 3);
			return;
		}
		if (C68B9CAC.Text.Trim() == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p đươ\u0300ng dâ\u0303n đê\u0301n chrome.exe!", 3);
			return;
		}
		if (!C68B9CAC.Text.Trim().EndsWith("chrome.exe"))
		{
			MsBoxHelper.Show("Đươ\u0300ng dâ\u0303n đê\u0301n chrome.exe không hơ\u0323p lê\u0323!", 3);
			return;
		}
		C5034B95.smethod_0("configInteractGeneral").method_4("txtPathShortcut", DB06922F.Text.Trim());
		C5034B95.smethod_0("configInteractGeneral").method_4("txtPathChromeOrigin", C68B9CAC.Text.Trim());
		C5034B95.smethod_1("configInteractGeneral");
		bool_0 = true;
		Close();
	}

	private void D302CD8D(object sender, EventArgs e)
	{
		Close();
	}

	private void A580D72A(object sender, EventArgs e)
	{
	}

	private void fCauHinhTaoShortcut_Load(object sender, EventArgs e)
	{
		DB06922F.Text = C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtPathShortcut");
		if (DB06922F.Text.Trim() == "" || !Directory.Exists(DB06922F.Text.Trim()))
		{
			DB06922F.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		}
		if (File.Exists(C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtPathChromeOrigin")))
		{
			C68B9CAC.Text = C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtPathChromeOrigin");
		}
		else
		{
			C68B9CAC.Text = E9204797;
		}
	}

	private void D91C5036_Click(object sender, EventArgs e)
	{
		string value = Commom.smethod_96();
		if (!string.IsNullOrEmpty(value))
		{
			DB06922F.Text = value;
		}
	}

	private void F4B7DC89_Click(object sender, EventArgs e)
	{
		C68B9CAC.Text = Commom.smethod_97(Language.GetValue("Cho\u0323n File"), "");
	}

	protected override void Dispose(bool B689EFAD)
	{
		if (B689EFAD && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(B689EFAD);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhTaoShortcut));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		DC3A7B2F = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		E92B7699 = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		DF82948A = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		F1097514 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		label1 = new System.Windows.Forms.Label();
		DB06922F = new System.Windows.Forms.TextBox();
		D91C5036 = new System.Windows.Forms.Button();
		D89D00A8 = new System.Windows.Forms.Label();
		C68B9CAC = new System.Windows.Forms.TextBox();
		F4B7DC89 = new System.Windows.Forms.Button();
		bunifuCards1.SuspendLayout();
		DC3A7B2F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(DC3A7B2F);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(594, 38);
		bunifuCards1.TabIndex = 0;
		DC3A7B2F.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DC3A7B2F.BackColor = System.Drawing.Color.White;
		DC3A7B2F.Controls.Add(pictureBox1);
		DC3A7B2F.Controls.Add(E92B7699);
		DC3A7B2F.Controls.Add(bunifuCustomLabel1);
		DC3A7B2F.Location = new System.Drawing.Point(0, 5);
		DC3A7B2F.Name = "pnlHeader";
		DC3A7B2F.Size = new System.Drawing.Size(594, 32);
		DC3A7B2F.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		E92B7699.Cursor = System.Windows.Forms.Cursors.Hand;
		E92B7699.Dock = System.Windows.Forms.DockStyle.Right;
		E92B7699.FlatAppearance.BorderSize = 0;
		E92B7699.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E92B7699.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E92B7699.ForeColor = System.Drawing.Color.White;
		E92B7699.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		E92B7699.Location = new System.Drawing.Point(562, 0);
		E92B7699.Name = "btnMinimize";
		E92B7699.Size = new System.Drawing.Size(32, 32);
		E92B7699.TabIndex = 9;
		E92B7699.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E92B7699.UseVisualStyleBackColor = true;
		E92B7699.Click += new System.EventHandler(E92B7699_Click);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(594, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh ta\u0323o Shortcut Chrome";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DF82948A.BackColor = System.Drawing.Color.Maroon;
		DF82948A.Cursor = System.Windows.Forms.Cursors.Hand;
		DF82948A.FlatAppearance.BorderSize = 0;
		DF82948A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DF82948A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DF82948A.ForeColor = System.Drawing.Color.White;
		DF82948A.Location = new System.Drawing.Point(303, 139);
		DF82948A.Name = "btnCancel";
		DF82948A.Size = new System.Drawing.Size(92, 29);
		DF82948A.TabIndex = 4;
		DF82948A.Text = "Đo\u0301ng";
		DF82948A.UseVisualStyleBackColor = false;
		DF82948A.Click += new System.EventHandler(D302CD8D);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(199, 139);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(D29EE29C);
		F1097514.Fixed = true;
		F1097514.Horizontal = true;
		F1097514.TargetControl = bunifuCustomLabel1;
		F1097514.Vertical = true;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(33, 60);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(104, 16);
		label1.TabIndex = 5;
		label1.Text = "Nơi lưu Shortcut:";
		DB06922F.Location = new System.Drawing.Point(157, 58);
		DB06922F.Name = "txtPathShortcut";
		DB06922F.Size = new System.Drawing.Size(352, 23);
		DB06922F.TabIndex = 6;
		D91C5036.Cursor = System.Windows.Forms.Cursors.Hand;
		D91C5036.Location = new System.Drawing.Point(515, 58);
		D91C5036.Name = "metroButton1";
		D91C5036.Size = new System.Drawing.Size(47, 24);
		D91C5036.TabIndex = 7;
		D91C5036.Text = "Cho\u0323n";
		D91C5036.Click += new System.EventHandler(D91C5036_Click);
		D89D00A8.AutoSize = true;
		D89D00A8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D89D00A8.Location = new System.Drawing.Point(33, 91);
		D89D00A8.Name = "label2";
		D89D00A8.Size = new System.Drawing.Size(124, 16);
		D89D00A8.TabIndex = 5;
		D89D00A8.Text = "Đươ\u0300ng dâ\u0303n Chrome:";
		C68B9CAC.Location = new System.Drawing.Point(157, 89);
		C68B9CAC.Name = "txtPathChromeOrigin";
		C68B9CAC.Size = new System.Drawing.Size(352, 23);
		C68B9CAC.TabIndex = 6;
		C68B9CAC.Text = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
		F4B7DC89.Cursor = System.Windows.Forms.Cursors.Hand;
		F4B7DC89.Location = new System.Drawing.Point(515, 89);
		F4B7DC89.Name = "metroButton2";
		F4B7DC89.Size = new System.Drawing.Size(47, 24);
		F4B7DC89.TabIndex = 7;
		F4B7DC89.Text = "Cho\u0323n";
		F4B7DC89.Click += new System.EventHandler(F4B7DC89_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(594, 187);
		base.Controls.Add(F4B7DC89);
		base.Controls.Add(D91C5036);
		base.Controls.Add(C68B9CAC);
		base.Controls.Add(D89D00A8);
		base.Controls.Add(DB06922F);
		base.Controls.Add(label1);
		base.Controls.Add(DF82948A);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhTaoShortcut";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhTaoShortcut_Load);
		bunifuCards1.ResumeLayout(false);
		DC3A7B2F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
