using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fDownloadAvatar : Form
{
	internal static bool B1B6AF81;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel A93C2905;

	internal BunifuCustomLabel C523CEBF;

	internal Button D235A50F;

	internal Button btnCancel;

	internal Button C1982436;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox E2A55A2D;

	internal Button D1B11BB1;

	internal TextBox txtPathFolder;

	internal Label label1;

	internal CheckBox ckbUseProxy;

	public fDownloadAvatar()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		B1B6AF81 = false;
	}

	private void EC1BD12D(object sender, EventArgs e)
	{
		Close();
	}

	private void E9384131(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configGeneral").method_4("pathFolderAvatar", txtPathFolder.Text);
		C5034B95.smethod_0("configGeneral").method_4("ckbDownAvatarUseProxy", ckbUseProxy.Checked);
		C5034B95.smethod_1("configGeneral");
		B1B6AF81 = true;
		Close();
	}

	private void DC8B351B(object sender, EventArgs e)
	{
		Close();
	}

	private void fDownloadAvatar_Load(object sender, EventArgs e)
	{
		txtPathFolder.Text = C5034B95.smethod_0("configGeneral").BDB80B23("pathFolderAvatar");
		ckbUseProxy.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbDownAvatarUseProxy");
	}

	private void D1B11BB1_Click(object sender, EventArgs e)
	{
		string value = Commom.smethod_96();
		if (!string.IsNullOrEmpty(value))
		{
			txtPathFolder.Text = value;
		}
	}

	protected override void Dispose(bool AC8C4C24)
	{
		if (AC8C4C24 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(AC8C4C24);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDownloadAvatar));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A93C2905 = new System.Windows.Forms.Panel();
		E2A55A2D = new System.Windows.Forms.PictureBox();
		D235A50F = new System.Windows.Forms.Button();
		C523CEBF = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		C1982436 = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D1B11BB1 = new System.Windows.Forms.Button();
		txtPathFolder = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		ckbUseProxy = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		A93C2905.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E2A55A2D).BeginInit();
		SuspendLayout();
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.Controls.Add(A93C2905);
		bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(449, 34);
		bunifuCards1.TabIndex = 0;
		A93C2905.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A93C2905.BackColor = System.Drawing.Color.White;
		A93C2905.Controls.Add(E2A55A2D);
		A93C2905.Controls.Add(D235A50F);
		A93C2905.Controls.Add(C523CEBF);
		A93C2905.Location = new System.Drawing.Point(0, 3);
		A93C2905.Name = "pnlHeader";
		A93C2905.Size = new System.Drawing.Size(449, 28);
		A93C2905.TabIndex = 9;
		E2A55A2D.Cursor = System.Windows.Forms.Cursors.Default;
		E2A55A2D.Image = Class155.DD225F0D;
		E2A55A2D.Location = new System.Drawing.Point(3, 2);
		E2A55A2D.Name = "pictureBox1";
		E2A55A2D.Size = new System.Drawing.Size(34, 27);
		E2A55A2D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E2A55A2D.TabIndex = 17;
		E2A55A2D.TabStop = false;
		D235A50F.Cursor = System.Windows.Forms.Cursors.Hand;
		D235A50F.Dock = System.Windows.Forms.DockStyle.Right;
		D235A50F.FlatAppearance.BorderSize = 0;
		D235A50F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D235A50F.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D235A50F.ForeColor = System.Drawing.Color.White;
		D235A50F.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		D235A50F.Location = new System.Drawing.Point(417, 0);
		D235A50F.Name = "btnMinimize";
		D235A50F.Size = new System.Drawing.Size(32, 28);
		D235A50F.TabIndex = 9;
		D235A50F.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D235A50F.UseVisualStyleBackColor = true;
		D235A50F.Click += new System.EventHandler(EC1BD12D);
		C523CEBF.BackColor = System.Drawing.Color.Transparent;
		C523CEBF.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C523CEBF.Dock = System.Windows.Forms.DockStyle.Fill;
		C523CEBF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C523CEBF.ForeColor = System.Drawing.Color.Black;
		C523CEBF.Location = new System.Drawing.Point(0, 0);
		C523CEBF.Name = "bunifuCustomLabel1";
		C523CEBF.Size = new System.Drawing.Size(449, 28);
		C523CEBF.TabIndex = 1;
		C523CEBF.Text = "Cấu hình Tải xuống avatar";
		C523CEBF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(231, 122);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(DC8B351B);
		C1982436.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C1982436.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		C1982436.Cursor = System.Windows.Forms.Cursors.Hand;
		C1982436.FlatAppearance.BorderSize = 0;
		C1982436.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C1982436.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C1982436.ForeColor = System.Drawing.Color.White;
		C1982436.Location = new System.Drawing.Point(127, 122);
		C1982436.Name = "btnAdd";
		C1982436.Size = new System.Drawing.Size(92, 29);
		C1982436.TabIndex = 3;
		C1982436.Text = "Lưu";
		C1982436.UseVisualStyleBackColor = false;
		C1982436.Click += new System.EventHandler(E9384131);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = C523CEBF;
		bunifuDragControl_0.Vertical = true;
		D1B11BB1.Cursor = System.Windows.Forms.Cursors.Hand;
		D1B11BB1.Location = new System.Drawing.Point(349, 55);
		D1B11BB1.Name = "metroButton1";
		D1B11BB1.Size = new System.Drawing.Size(61, 25);
		D1B11BB1.TabIndex = 37;
		D1B11BB1.Text = "Chọn";
		D1B11BB1.Click += new System.EventHandler(D1B11BB1_Click);
		txtPathFolder.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtPathFolder.Location = new System.Drawing.Point(147, 56);
		txtPathFolder.Name = "txtPathFolder";
		txtPathFolder.Size = new System.Drawing.Size(196, 23);
		txtPathFolder.TabIndex = 35;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(31, 59);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(93, 16);
		label1.TabIndex = 36;
		label1.Text = "Nơi lưu Avatar:";
		ckbUseProxy.AutoSize = true;
		ckbUseProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUseProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbUseProxy.Location = new System.Drawing.Point(34, 85);
		ckbUseProxy.Name = "ckbUseProxy";
		ckbUseProxy.Size = new System.Drawing.Size(281, 20);
		ckbUseProxy.TabIndex = 38;
		ckbUseProxy.Text = "Sử dụng proxy đã gán mỗi tài khoản để chạy";
		ckbUseProxy.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(449, 166);
		base.Controls.Add(ckbUseProxy);
		base.Controls.Add(label1);
		base.Controls.Add(txtPathFolder);
		base.Controls.Add(D1B11BB1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(C1982436);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fDownloadAvatar";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fDownloadAvatar_Load);
		bunifuCards1.ResumeLayout(false);
		A93C2905.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)E2A55A2D).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
