using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhDebug : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal BunifuCustomLabel FD35B8B9;

	internal Button btnMinimize;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal CheckBox ckbUseScriptFile;

	internal TextBox txtFilePath;

	internal Panel plFilePath;

	internal Label AE189CB6;

	internal CheckBox ckbModeDev;

	internal CheckBox D73C2B13;

	internal CheckBox EB215596;

	internal CheckBox B9292D11;

	public fCauHinhDebug()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void D823C08B(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configDebug").method_4("ckbModeDev", ckbModeDev.Checked);
		C5034B95.smethod_0("configDebug").method_4("ckbUseScriptFile", ckbUseScriptFile.Checked);
		C5034B95.smethod_0("configDebug").method_4("txtFilePath", txtFilePath.Text);
		C5034B95.smethod_0("configDebug").method_4("ckbLogWelike", D73C2B13.Checked);
		C5034B95.smethod_0("configDebug").method_4("ckbDebugWelike", EB215596.Checked);
		C5034B95.smethod_0("configDebug").method_4("ckbLanguage", B9292D11.Checked);
		C5034B95.smethod_1("configDebug");
		if (B9292D11.Checked)
		{
			Commom.smethod_85("SaveLanguage()");
		}
		if (MsBoxHelper.D41C45AC("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
		{
			Close();
		}
	}

	private void DEB87329(object sender, EventArgs e)
	{
		Close();
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void fCauHinhDebug_Load(object sender, EventArgs e)
	{
		ckbModeDev.Checked = C5034B95.smethod_0("configDebug").method_3("ckbModeDev");
		ckbUseScriptFile.Checked = C5034B95.smethod_0("configDebug").method_3("ckbUseScriptFile");
		txtFilePath.Text = C5034B95.smethod_0("configDebug").BDB80B23("txtFilePath");
		D73C2B13.Checked = C5034B95.smethod_0("configDebug").method_3("ckbLogWelike");
		EB215596.Checked = C5034B95.smethod_0("configDebug").method_3("ckbDebugWelike");
		B9292D11.Checked = C5034B95.smethod_0("configDebug").method_3("ckbLanguage");
		ckbUseScriptFile_CheckedChanged(null, null);
	}

	private void ckbUseScriptFile_CheckedChanged(object sender, EventArgs e)
	{
		plFilePath.Enabled = ckbUseScriptFile.Checked;
	}

	protected override void Dispose(bool F791FD35)
	{
		if (F791FD35 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(F791FD35);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhDebug));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		FD35B8B9 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		ckbUseScriptFile = new System.Windows.Forms.CheckBox();
		txtFilePath = new System.Windows.Forms.TextBox();
		plFilePath = new System.Windows.Forms.Panel();
		AE189CB6 = new System.Windows.Forms.Label();
		ckbModeDev = new System.Windows.Forms.CheckBox();
		D73C2B13 = new System.Windows.Forms.CheckBox();
		EB215596 = new System.Windows.Forms.CheckBox();
		B9292D11 = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		plFilePath.SuspendLayout();
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
		bunifuCards1.Size = new System.Drawing.Size(445, 38);
		bunifuCards1.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(FD35B8B9);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(445, 32);
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
		btnMinimize.Location = new System.Drawing.Point(413, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(D823C08B);
		FD35B8B9.BackColor = System.Drawing.Color.Transparent;
		FD35B8B9.Cursor = System.Windows.Forms.Cursors.SizeAll;
		FD35B8B9.Dock = System.Windows.Forms.DockStyle.Fill;
		FD35B8B9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FD35B8B9.ForeColor = System.Drawing.Color.Black;
		FD35B8B9.Location = new System.Drawing.Point(0, 0);
		FD35B8B9.Name = "bunifuCustomLabel1";
		FD35B8B9.Size = new System.Drawing.Size(445, 32);
		FD35B8B9.TabIndex = 1;
		FD35B8B9.Text = "Câ\u0301u hi\u0300nh Debug";
		FD35B8B9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(230, 206);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(DEB87329);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(126, 206);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = FD35B8B9;
		bunifuDragControl_0.Vertical = true;
		ckbUseScriptFile.AutoSize = true;
		ckbUseScriptFile.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUseScriptFile.Location = new System.Drawing.Point(50, 84);
		ckbUseScriptFile.Name = "ckbUseScriptFile";
		ckbUseScriptFile.Size = new System.Drawing.Size(130, 20);
		ckbUseScriptFile.TabIndex = 5;
		ckbUseScriptFile.Text = "Sử dụng file script";
		ckbUseScriptFile.UseVisualStyleBackColor = true;
		ckbUseScriptFile.CheckedChanged += new System.EventHandler(ckbUseScriptFile_CheckedChanged);
		txtFilePath.Location = new System.Drawing.Point(67, 1);
		txtFilePath.Name = "txtFilePath";
		txtFilePath.Size = new System.Drawing.Size(240, 23);
		txtFilePath.TabIndex = 6;
		plFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plFilePath.Controls.Add(AE189CB6);
		plFilePath.Controls.Add(txtFilePath);
		plFilePath.Location = new System.Drawing.Point(70, 106);
		plFilePath.Name = "plFilePath";
		plFilePath.Size = new System.Drawing.Size(310, 27);
		plFilePath.TabIndex = 8;
		AE189CB6.AutoSize = true;
		AE189CB6.Location = new System.Drawing.Point(3, 3);
		AE189CB6.Name = "label21";
		AE189CB6.Size = new System.Drawing.Size(61, 16);
		AE189CB6.TabIndex = 49;
		AE189CB6.Text = "File path:";
		ckbModeDev.AutoSize = true;
		ckbModeDev.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbModeDev.Location = new System.Drawing.Point(50, 58);
		ckbModeDev.Name = "ckbModeDev";
		ckbModeDev.Size = new System.Drawing.Size(110, 20);
		ckbModeDev.TabIndex = 5;
		ckbModeDev.Text = "Bật chế độ dev";
		ckbModeDev.UseVisualStyleBackColor = true;
		D73C2B13.AutoSize = true;
		D73C2B13.Cursor = System.Windows.Forms.Cursors.Hand;
		D73C2B13.Location = new System.Drawing.Point(50, 139);
		D73C2B13.Name = "ckbLogWelike";
		D73C2B13.Size = new System.Drawing.Size(140, 20);
		D73C2B13.TabIndex = 5;
		D73C2B13.Text = "Xuất log getjobs fail";
		D73C2B13.UseVisualStyleBackColor = true;
		EB215596.AutoSize = true;
		EB215596.Cursor = System.Windows.Forms.Cursors.Hand;
		EB215596.Location = new System.Drawing.Point(230, 139);
		EB215596.Name = "ckbDebugWelike";
		EB215596.Size = new System.Drawing.Size(104, 20);
		EB215596.TabIndex = 5;
		EB215596.Text = "Debug Welike";
		EB215596.UseVisualStyleBackColor = true;
		B9292D11.AutoSize = true;
		B9292D11.Cursor = System.Windows.Forms.Cursors.Hand;
		B9292D11.Location = new System.Drawing.Point(50, 165);
		B9292D11.Name = "ckbLanguage";
		B9292D11.Size = new System.Drawing.Size(141, 20);
		B9292D11.TabIndex = 9;
		B9292D11.Text = "Bâ\u0323t debug ngôn ngư\u0303";
		B9292D11.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(445, 248);
		base.Controls.Add(B9292D11);
		base.Controls.Add(plFilePath);
		base.Controls.Add(EB215596);
		base.Controls.Add(D73C2B13);
		base.Controls.Add(ckbModeDev);
		base.Controls.Add(ckbUseScriptFile);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhDebug";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhDebug_Load);
		bunifuCards1.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		plFilePath.ResumeLayout(false);
		plFilePath.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
