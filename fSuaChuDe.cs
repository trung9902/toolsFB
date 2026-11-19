using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fSuaChuDe : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards bunifuCards2;

	internal Panel FA0A3DB2;

	internal Button B039A0B7;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem BF9BD633;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal Label AC24A805;

	internal Button btnCancel;

	internal Button btnAdd;

	internal TextBox txtNewChuDe;

	internal Label label1;

	internal TextBox D10E9AB9;

	public fSuaChuDe(string string_0)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		D10E9AB9.Text = string_0;
	}

	private void fSuaChuDe_Load(object sender, EventArgs e)
	{
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void B039A0B7_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void CC09D294(object sender, EventArgs e)
	{
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		List<string> list = CommonSQL.B5A9A490();
		string string_ = D10E9AB9.Text;
		string text = txtNewChuDe.Text;
		if (text == "")
		{
			MsBoxHelper.Show("Vui lòng nhập tên chủ đề mới!", 2);
		}
		else if (!list.Contains(text))
		{
			CommonSQL.DD031E85(string_, text);
			if (MsBoxHelper.D41C45AC("Cập nhật thành công, bạn có muốn đóng cửa sổ?") == DialogResult.Yes)
			{
				Close();
			}
		}
		else
		{
			MsBoxHelper.Show("Tên chủ đề đã tồn tại, vui lòng đổi tên khác!", 2);
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fSuaChuDe_FormClosing(object sender, FormClosingEventArgs e)
	{
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
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		AC24A805 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		D10E9AB9 = new System.Windows.Forms.TextBox();
		btnAdd = new System.Windows.Forms.Button();
		txtNewChuDe = new System.Windows.Forms.TextBox();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		FA0A3DB2 = new System.Windows.Forms.Panel();
		B039A0B7 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		BF9BD633 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		bunifuCards2.SuspendLayout();
		FA0A3DB2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		contextMenuStrip1.SuspendLayout();
		SuspendLayout();
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 5;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.SaddleBrown;
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(0, 0);
		bunifuCards1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(0, 47);
		bunifuCards1.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(label1);
		panel1.Controls.Add(AC24A805);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(D10E9AB9);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(txtNewChuDe);
		panel1.Controls.Add(bunifuCards2);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(329, 164);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label1.Location = new System.Drawing.Point(28, 49);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(93, 16);
		label1.TabIndex = 47;
		label1.Text = "Tên chủ đề cũ:";
		AC24A805.AutoSize = true;
		AC24A805.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		AC24A805.Location = new System.Drawing.Point(28, 78);
		AC24A805.Name = "label2";
		AC24A805.Size = new System.Drawing.Size(101, 16);
		AC24A805.TabIndex = 47;
		AC24A805.Text = "Tên chủ đề mới:";
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(173, 116);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 46;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		D10E9AB9.Location = new System.Drawing.Point(138, 46);
		D10E9AB9.Name = "txtChude";
		D10E9AB9.ReadOnly = true;
		D10E9AB9.Size = new System.Drawing.Size(153, 23);
		D10E9AB9.TabIndex = 44;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(69, 116);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Cập nhật";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		txtNewChuDe.Location = new System.Drawing.Point(138, 75);
		txtNewChuDe.Name = "txtNewChuDe";
		txtNewChuDe.Size = new System.Drawing.Size(153, 23);
		txtNewChuDe.TabIndex = 44;
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(FA0A3DB2);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(327, 37);
		bunifuCards2.TabIndex = 43;
		FA0A3DB2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FA0A3DB2.BackColor = System.Drawing.Color.White;
		FA0A3DB2.Controls.Add(B039A0B7);
		FA0A3DB2.Controls.Add(pictureBox1);
		FA0A3DB2.Controls.Add(btnMinimize);
		FA0A3DB2.Controls.Add(bunifuCustomLabel1);
		FA0A3DB2.Cursor = System.Windows.Forms.Cursors.SizeAll;
		FA0A3DB2.Location = new System.Drawing.Point(0, 3);
		FA0A3DB2.Name = "pnlHeader";
		FA0A3DB2.Size = new System.Drawing.Size(327, 31);
		FA0A3DB2.TabIndex = 9;
		B039A0B7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		B039A0B7.Cursor = System.Windows.Forms.Cursors.Hand;
		B039A0B7.FlatAppearance.BorderSize = 0;
		B039A0B7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B039A0B7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B039A0B7.ForeColor = System.Drawing.Color.White;
		B039A0B7.Image = Class155.Bitmap_15;
		B039A0B7.Location = new System.Drawing.Point(296, 1);
		B039A0B7.Name = "button2";
		B039A0B7.Size = new System.Drawing.Size(30, 30);
		B039A0B7.TabIndex = 77;
		B039A0B7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B039A0B7.UseVisualStyleBackColor = true;
		B039A0B7.Click += new System.EventHandler(B039A0B7_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Location = new System.Drawing.Point(899, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(327, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cập nhật chủ đề";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_0, BF9BD633, toolStripMenuItem_1 });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
		toolStripMenuItem_0.Name = "thêmMớiToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_0.Text = "Thêm chủ đề";
		BF9BD633.Name = "sửaToolStripMenuItem";
		BF9BD633.Size = new System.Drawing.Size(152, 22);
		BF9BD633.Text = "Sửa tên chủ đề";
		toolStripMenuItem_1.Name = "xóaToolStripMenuItem";
		toolStripMenuItem_1.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_1.Text = "Xóa chủ đề";
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(329, 164);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fSuaChuDe";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fSuaChuDe_FormClosing);
		base.Load += new System.EventHandler(fSuaChuDe_Load);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		bunifuCards2.ResumeLayout(false);
		FA0A3DB2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
