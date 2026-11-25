using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHelpNhapComment : Form
{
	internal IContainer D333249C = null;

	internal BunifuCards C6B57A22;

	internal Panel A62C1517;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button EE9BC297;

	internal Button CC318501;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox AD19E9BD;

	internal Label label1;

	internal PictureBox pictureBox2;

	internal Panel FF200700;

	public fHelpNhapComment()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		ED175C2A();
		pictureBox2.Image = ((Base.smethod_2() == "VN") ? Class155.Bitmap_48 : Class155.Bitmap_49);
	}

	private void ED175C2A()
	{
		Language.C43D0AAC(bunifuCustomLabel1);
		Language.C43D0AAC(label1);
		Language.C43D0AAC(CC318501);
	}

	private void BF8DDC38(object sender, EventArgs e)
	{
		Close();
	}

	private void B717392F(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D333249C != null)
		{
			D333249C.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		D333249C = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHelpNhapComment));
		C6B57A22 = new Bunifu.Framework.UI.BunifuCards();
		A62C1517 = new System.Windows.Forms.Panel();
		AD19E9BD = new System.Windows.Forms.PictureBox();
		EE9BC297 = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		CC318501 = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(D333249C);
		label1 = new System.Windows.Forms.Label();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		FF200700 = new System.Windows.Forms.Panel();
		C6B57A22.SuspendLayout();
		A62C1517.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AD19E9BD).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		C6B57A22.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C6B57A22.BackColor = System.Drawing.Color.White;
		C6B57A22.BorderRadius = 0;
		C6B57A22.BottomSahddow = true;
		C6B57A22.color = System.Drawing.Color.SaddleBrown;
		C6B57A22.Controls.Add(A62C1517);
		C6B57A22.LeftSahddow = false;
		C6B57A22.Location = new System.Drawing.Point(1, 0);
		C6B57A22.Name = "bunifuCards1";
		C6B57A22.RightSahddow = true;
		C6B57A22.ShadowDepth = 20;
		C6B57A22.Size = new System.Drawing.Size(577, 38);
		C6B57A22.TabIndex = 0;
		A62C1517.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A62C1517.BackColor = System.Drawing.Color.White;
		A62C1517.Controls.Add(AD19E9BD);
		A62C1517.Controls.Add(EE9BC297);
		A62C1517.Controls.Add(bunifuCustomLabel1);
		A62C1517.Location = new System.Drawing.Point(0, 5);
		A62C1517.Name = "pnlHeader";
		A62C1517.Size = new System.Drawing.Size(577, 32);
		A62C1517.TabIndex = 9;
		AD19E9BD.Cursor = System.Windows.Forms.Cursors.Default;
		AD19E9BD.Image = Class155.DD225F0D;
		AD19E9BD.Location = new System.Drawing.Point(3, 2);
		AD19E9BD.Name = "pictureBox1";
		AD19E9BD.Size = new System.Drawing.Size(34, 27);
		AD19E9BD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AD19E9BD.TabIndex = 17;
		AD19E9BD.TabStop = false;
		EE9BC297.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		EE9BC297.Cursor = System.Windows.Forms.Cursors.Hand;
		EE9BC297.FlatAppearance.BorderSize = 0;
		EE9BC297.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EE9BC297.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EE9BC297.ForeColor = System.Drawing.Color.White;
		EE9BC297.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		EE9BC297.Location = new System.Drawing.Point(544, -1);
		EE9BC297.Name = "btnMinimize";
		EE9BC297.Size = new System.Drawing.Size(32, 32);
		EE9BC297.TabIndex = 9;
		EE9BC297.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		EE9BC297.UseVisualStyleBackColor = true;
		EE9BC297.Click += new System.EventHandler(BF8DDC38);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(577, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Hướng dẫn nhập Nội dung có nhiều dòng";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CC318501.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		CC318501.BackColor = System.Drawing.Color.Maroon;
		CC318501.Cursor = System.Windows.Forms.Cursors.Hand;
		CC318501.FlatAppearance.BorderSize = 0;
		CC318501.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CC318501.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CC318501.ForeColor = System.Drawing.Color.White;
		CC318501.Location = new System.Drawing.Point(246, 380);
		CC318501.Name = "btnCancel";
		CC318501.Size = new System.Drawing.Size(92, 29);
		CC318501.TabIndex = 4;
		CC318501.Text = "Đo\u0301ng";
		CC318501.UseVisualStyleBackColor = false;
		CC318501.Click += new System.EventHandler(B717392F);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(28, 60);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(366, 16);
		label1.TabIndex = 5;
		label1.Text = "Vui lòng nhập các nội dung ngăn cách nhau bởi dấu | như sau:";
		pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		pictureBox2.Location = new System.Drawing.Point(31, 86);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(514, 275);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 6;
		pictureBox2.TabStop = false;
		FF200700.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		FF200700.Dock = System.Windows.Forms.DockStyle.Fill;
		FF200700.Location = new System.Drawing.Point(0, 0);
		FF200700.Name = "panel1";
		FF200700.Size = new System.Drawing.Size(578, 421);
		FF200700.TabIndex = 7;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(578, 421);
		base.Controls.Add(pictureBox2);
		base.Controls.Add(label1);
		base.Controls.Add(CC318501);
		base.Controls.Add(C6B57A22);
		base.Controls.Add(FF200700);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fHelpNhapComment";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		C6B57A22.ResumeLayout(false);
		A62C1517.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AD19E9BD).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
