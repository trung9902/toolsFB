using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhWallPost : Form
{
	internal GClass4 ECAD8F17;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl CB398836;

	internal BunifuCards bunifuCards1;

	internal Button E8B1323B;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel A4B3012F;

	internal Button btnCancel;

	internal Button EC891D3B;

	internal CheckBox ckbWallPostLinkShare;

	internal Label label2;

	internal Label label1;

	internal NumericUpDown B883981F;

	internal CheckBox BC12A891;

	public fCauHinhWallPost(GClass4 AC25629C)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		ECAD8F17 = AC25629C;
	}

	private void EE1E79AF(object sender, EventArgs e)
	{
		Close();
	}

	private void fCauHinhWallPost_Load(object sender, EventArgs e)
	{
		try
		{
			B883981F.Value = ECAD8F17.method_2("nudWallPosts", 8);
			ckbWallPostLinkShare.Checked = ECAD8F17.method_3("ckbWallPostLinkShare");
			BC12A891.Checked = ECAD8F17.method_3("ckbWallPostUpAvatarCover");
		}
		catch (Exception)
		{
		}
	}

	private void C2856523(object sender, EventArgs e)
	{
		ECAD8F17.method_4("nudWallPosts", B883981F.Value);
		ECAD8F17.method_4("ckbWallPostLinkShare", ckbWallPostLinkShare.Checked);
		ECAD8F17.method_4("ckbWallPostUpAvatarCover", BC12A891.Checked);
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
		CB398836 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		E8B1323B = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		A4B3012F = new System.Windows.Forms.Panel();
		BC12A891 = new System.Windows.Forms.CheckBox();
		ckbWallPostLinkShare = new System.Windows.Forms.CheckBox();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		B883981F = new System.Windows.Forms.NumericUpDown();
		btnCancel = new System.Windows.Forms.Button();
		EC891D3B = new System.Windows.Forms.Button();
		bunifuCards1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		A4B3012F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B883981F).BeginInit();
		SuspendLayout();
		CB398836.Fixed = true;
		CB398836.Horizontal = true;
		CB398836.TargetControl = bunifuCustomLabel1;
		CB398836.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(468, 38);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh Check wall posts";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(E8B1323B);
		bunifuCards1.Controls.Add(pictureBox1);
		bunifuCards1.Controls.Add(bunifuCustomLabel1);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(468, 38);
		bunifuCards1.TabIndex = 29;
		E8B1323B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E8B1323B.Cursor = System.Windows.Forms.Cursors.Hand;
		E8B1323B.FlatAppearance.BorderSize = 0;
		E8B1323B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E8B1323B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E8B1323B.ForeColor = System.Drawing.Color.White;
		E8B1323B.Image = Class155.FF80C508;
		E8B1323B.Location = new System.Drawing.Point(436, 5);
		E8B1323B.Name = "btnClose";
		E8B1323B.Size = new System.Drawing.Size(30, 30);
		E8B1323B.TabIndex = 77;
		E8B1323B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E8B1323B.UseVisualStyleBackColor = true;
		E8B1323B.Click += new System.EventHandler(EE1E79AF);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(2, 6);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		A4B3012F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A4B3012F.Controls.Add(BC12A891);
		A4B3012F.Controls.Add(ckbWallPostLinkShare);
		A4B3012F.Controls.Add(label2);
		A4B3012F.Controls.Add(label1);
		A4B3012F.Controls.Add(B883981F);
		A4B3012F.Controls.Add(btnCancel);
		A4B3012F.Controls.Add(EC891D3B);
		A4B3012F.Controls.Add(bunifuCards1);
		A4B3012F.Dock = System.Windows.Forms.DockStyle.Fill;
		A4B3012F.Location = new System.Drawing.Point(0, 0);
		A4B3012F.Name = "panel2";
		A4B3012F.Size = new System.Drawing.Size(470, 189);
		A4B3012F.TabIndex = 30;
		BC12A891.AutoSize = true;
		BC12A891.Cursor = System.Windows.Forms.Cursors.Hand;
		BC12A891.Location = new System.Drawing.Point(255, 110);
		BC12A891.Name = "ckbWallPostUpAvatarCover";
		BC12A891.Size = new System.Drawing.Size(131, 20);
		BC12A891.TabIndex = 99;
		BC12A891.Text = "Up avatar, a\u0309nh bi\u0300a";
		BC12A891.UseVisualStyleBackColor = true;
		ckbWallPostLinkShare.AutoSize = true;
		ckbWallPostLinkShare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWallPostLinkShare.Location = new System.Drawing.Point(255, 84);
		ckbWallPostLinkShare.Name = "ckbWallPostLinkShare";
		ckbWallPostLinkShare.Size = new System.Drawing.Size(143, 20);
		ckbWallPostLinkShare.TabIndex = 99;
		ckbWallPostLinkShare.Text = "Chia se\u0309 ba\u0300i viê\u0301t kha\u0301c";
		ckbWallPostLinkShare.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(120, 85);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(119, 16);
		label2.TabIndex = 98;
		label2.Text = "Bo\u0309 qua ca\u0301c ba\u0300i viê\u0301t:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(120, 56);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(120, 16);
		label1.TabIndex = 98;
		label1.Text = "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t:";
		B883981F.Location = new System.Drawing.Point(255, 54);
		B883981F.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		B883981F.Name = "nudWallPosts";
		B883981F.Size = new System.Drawing.Size(135, 23);
		B883981F.TabIndex = 97;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(241, 147);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 96;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		EC891D3B.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		EC891D3B.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		EC891D3B.Cursor = System.Windows.Forms.Cursors.Hand;
		EC891D3B.FlatAppearance.BorderSize = 0;
		EC891D3B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EC891D3B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EC891D3B.ForeColor = System.Drawing.Color.White;
		EC891D3B.Location = new System.Drawing.Point(137, 147);
		EC891D3B.Name = "btnSave";
		EC891D3B.Size = new System.Drawing.Size(92, 29);
		EC891D3B.TabIndex = 95;
		EC891D3B.Text = "Lưu";
		EC891D3B.UseVisualStyleBackColor = false;
		EC891D3B.Click += new System.EventHandler(C2856523);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(470, 189);
		base.Controls.Add(A4B3012F);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhWallPost";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhWallPost_Load);
		bunifuCards1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		A4B3012F.ResumeLayout(false);
		A4B3012F.PerformLayout();
		((System.ComponentModel.ISupportInitialize)B883981F).EndInit();
		ResumeLayout(false);
	}
}
