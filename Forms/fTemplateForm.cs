using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fTemplateForm : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards C7138912;

	internal Panel pnlHeader;

	internal BunifuCustomLabel BA8EA0B7;

	internal Button BB2D50AF;

	internal Button btnCancel;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal Panel panel1;

	public fTemplateForm()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void ED1CBC8B(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTemplateForm));
		C7138912 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		BB2D50AF = new System.Windows.Forms.Button();
		BA8EA0B7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1 = new System.Windows.Forms.Panel();
		C7138912.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		C7138912.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C7138912.BackColor = System.Drawing.Color.White;
		C7138912.BorderRadius = 0;
		C7138912.BottomSahddow = true;
		C7138912.color = System.Drawing.Color.SaddleBrown;
		C7138912.Controls.Add(pnlHeader);
		C7138912.LeftSahddow = false;
		C7138912.Location = new System.Drawing.Point(1, 0);
		C7138912.Name = "bunifuCards1";
		C7138912.RightSahddow = true;
		C7138912.ShadowDepth = 20;
		C7138912.Size = new System.Drawing.Size(832, 38);
		C7138912.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(BB2D50AF);
		pnlHeader.Controls.Add(BA8EA0B7);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(832, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		BB2D50AF.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		BB2D50AF.Cursor = System.Windows.Forms.Cursors.Hand;
		BB2D50AF.FlatAppearance.BorderSize = 0;
		BB2D50AF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BB2D50AF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		BB2D50AF.ForeColor = System.Drawing.Color.White;
		BB2D50AF.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		BB2D50AF.Location = new System.Drawing.Point(799, -1);
		BB2D50AF.Name = "btnMinimize";
		BB2D50AF.Size = new System.Drawing.Size(32, 32);
		BB2D50AF.TabIndex = 9;
		BB2D50AF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		BB2D50AF.UseVisualStyleBackColor = true;
		BB2D50AF.Click += new System.EventHandler(ED1CBC8B);
		BA8EA0B7.BackColor = System.Drawing.Color.Transparent;
		BA8EA0B7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		BA8EA0B7.Dock = System.Windows.Forms.DockStyle.Fill;
		BA8EA0B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BA8EA0B7.ForeColor = System.Drawing.Color.Black;
		BA8EA0B7.Location = new System.Drawing.Point(0, 0);
		BA8EA0B7.Name = "bunifuCustomLabel1";
		BA8EA0B7.Size = new System.Drawing.Size(832, 32);
		BA8EA0B7.TabIndex = 1;
		BA8EA0B7.Text = "Hướng dẫn nhập Nội dung có nhiều dòng";
		BA8EA0B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(370, 501);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = BA8EA0B7;
		bunifuDragControl_0.Vertical = true;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(833, 542);
		panel1.TabIndex = 5;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(833, 542);
		base.Controls.Add(btnCancel);
		base.Controls.Add(C7138912);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fTemplateForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		C7138912.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
