using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fSelectFolder : Form
{
	internal static string string_0 = "";

	internal IContainer EF2D338F = null;

	internal BunifuCards BEBCF89B;

	internal Panel E63CFE32;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button EF87DBA8;

	internal BunifuDragControl D3256FBC;

	internal PictureBox BC2BB68C;

	internal Label label2;

	internal TextBox txtPathFolder;

	internal Button metroButton1;

	public fSelectFolder()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		string_0 = "";
	}

	private void btnMinimize_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void EF87DBA8_Click(object sender, EventArgs e)
	{
		string_0 = txtPathFolder.Text.Trim();
		if (string_0 == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p đươ\u0300ng dâ\u0303n Folder!", 2);
			txtPathFolder.Focus();
		}
		else
		{
			Close();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fSelectFolder_Load(object sender, EventArgs e)
	{
		string_0 = "";
	}

	private void AA28B596(object sender, EventArgs e)
	{
		string value = Commom.smethod_96();
		if (!string.IsNullOrEmpty(value))
		{
			txtPathFolder.Text = value;
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && EF2D338F != null)
		{
			EF2D338F.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		EF2D338F = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSelectFolder));
		BEBCF89B = new Bunifu.Framework.UI.BunifuCards();
		E63CFE32 = new System.Windows.Forms.Panel();
		BC2BB68C = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		EF87DBA8 = new System.Windows.Forms.Button();
		D3256FBC = new Bunifu.Framework.UI.BunifuDragControl(EF2D338F);
		label2 = new System.Windows.Forms.Label();
		txtPathFolder = new System.Windows.Forms.TextBox();
		metroButton1 = new System.Windows.Forms.Button();
		BEBCF89B.SuspendLayout();
		E63CFE32.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)BC2BB68C).BeginInit();
		SuspendLayout();
		BEBCF89B.BackColor = System.Drawing.Color.White;
		BEBCF89B.BorderRadius = 0;
		BEBCF89B.BottomSahddow = true;
		BEBCF89B.color = System.Drawing.Color.SaddleBrown;
		BEBCF89B.Controls.Add(E63CFE32);
		BEBCF89B.Dock = System.Windows.Forms.DockStyle.Top;
		BEBCF89B.LeftSahddow = false;
		BEBCF89B.Location = new System.Drawing.Point(0, 0);
		BEBCF89B.Name = "bunifuCards1";
		BEBCF89B.RightSahddow = true;
		BEBCF89B.ShadowDepth = 20;
		BEBCF89B.Size = new System.Drawing.Size(449, 34);
		BEBCF89B.TabIndex = 0;
		E63CFE32.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E63CFE32.BackColor = System.Drawing.Color.White;
		E63CFE32.Controls.Add(BC2BB68C);
		E63CFE32.Controls.Add(btnMinimize);
		E63CFE32.Controls.Add(bunifuCustomLabel1);
		E63CFE32.Location = new System.Drawing.Point(0, 3);
		E63CFE32.Name = "pnlHeader";
		E63CFE32.Size = new System.Drawing.Size(449, 28);
		E63CFE32.TabIndex = 9;
		BC2BB68C.Cursor = System.Windows.Forms.Cursors.Default;
		BC2BB68C.Image = Class155.DD225F0D;
		BC2BB68C.Location = new System.Drawing.Point(3, 2);
		BC2BB68C.Name = "pictureBox1";
		BC2BB68C.Size = new System.Drawing.Size(34, 27);
		BC2BB68C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		BC2BB68C.TabIndex = 17;
		BC2BB68C.TabStop = false;
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
		bunifuCustomLabel1.Text = "Cho\u0323n nơi lưu";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(230, 108);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		EF87DBA8.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		EF87DBA8.Cursor = System.Windows.Forms.Cursors.Hand;
		EF87DBA8.FlatAppearance.BorderSize = 0;
		EF87DBA8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EF87DBA8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EF87DBA8.ForeColor = System.Drawing.Color.White;
		EF87DBA8.Location = new System.Drawing.Point(126, 108);
		EF87DBA8.Name = "btnAdd";
		EF87DBA8.Size = new System.Drawing.Size(92, 29);
		EF87DBA8.TabIndex = 3;
		EF87DBA8.Text = "Lưu";
		EF87DBA8.UseVisualStyleBackColor = false;
		EF87DBA8.Click += new System.EventHandler(EF87DBA8_Click);
		D3256FBC.Fixed = true;
		D3256FBC.Horizontal = true;
		D3256FBC.TargetControl = bunifuCustomLabel1;
		D3256FBC.Vertical = true;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(31, 61);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(146, 16);
		label2.TabIndex = 36;
		label2.Text = "Nhâ\u0323p đươ\u0300ng dâ\u0303n Folder:";
		txtPathFolder.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtPathFolder.Location = new System.Drawing.Point(184, 58);
		txtPathFolder.Name = "txtPathFolder";
		txtPathFolder.Size = new System.Drawing.Size(172, 23);
		txtPathFolder.TabIndex = 35;
		metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton1.Location = new System.Drawing.Point(362, 57);
		metroButton1.Name = "metroButton1";
		metroButton1.Size = new System.Drawing.Size(61, 25);
		metroButton1.TabIndex = 38;
		metroButton1.Text = "Chọn";
		metroButton1.Click += new System.EventHandler(AA28B596);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(449, 159);
		base.Controls.Add(metroButton1);
		base.Controls.Add(label2);
		base.Controls.Add(txtPathFolder);
		base.Controls.Add(btnCancel);
		base.Controls.Add(EF87DBA8);
		base.Controls.Add(BEBCF89B);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fSelectFolder";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fSelectFolder_Load);
		BEBCF89B.ResumeLayout(false);
		E63CFE32.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)BC2BB68C).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
