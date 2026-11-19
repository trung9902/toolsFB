using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fThemChuDe : Form
{
	internal IContainer ACB4301A = null;

	internal BunifuCards C9885896;

	internal Panel panel1;

	internal BunifuDragControl A802CC34;

	internal BunifuCards bunifuCards2;

	internal Panel pnlHeader;

	internal Button E60D1030;

	internal PictureBox B6A6800F;

	internal Button btnMinimize;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem AA3BF03D;

	internal Label label2;

	internal Button btnCancel;

	internal Button C02F4F39;

	internal TextBox txtChuDe;

	public fThemChuDe()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void method_0(object sender, EventArgs e)
	{
		Close();
	}

	private void fThemChuDe_Load(object sender, EventArgs e)
	{
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void DAB9BD11(object sender, PaintEventArgs e)
	{
	}

	private void B19E0CAB(object sender, EventArgs e)
	{
		Close();
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void C02F4F39_Click(object sender, EventArgs e)
	{
		List<string> list = CommonSQL.B5A9A490();
		string text = txtChuDe.Text;
		if (text == "")
		{
			MsBoxHelper.Show("Vui lòng nhập tên chủ đề mới!", 2);
		}
		else if (!list.Contains(text))
		{
			CommonSQL.E19E9C81(text);
			if (MsBoxHelper.D41C45AC("Thêm thành công, bạn có muốn đóng cửa sổ?") == DialogResult.Yes)
			{
				Close();
			}
		}
		else
		{
			MsBoxHelper.Show("Tên chủ đề đã tồn tại, vui lòng đổi tên khác!", 2);
		}
	}

	private void C30970A2(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool F208311F)
	{
		if (F208311F && ACB4301A != null)
		{
			ACB4301A.Dispose();
		}
		base.Dispose(F208311F);
	}

	private void InitializeComponent()
	{
		ACB4301A = new System.ComponentModel.Container();
		C9885896 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		C02F4F39 = new System.Windows.Forms.Button();
		txtChuDe = new System.Windows.Forms.TextBox();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		E60D1030 = new System.Windows.Forms.Button();
		B6A6800F = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(ACB4301A);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		AA3BF03D = new System.Windows.Forms.ToolStripMenuItem();
		A802CC34 = new Bunifu.Framework.UI.BunifuDragControl(ACB4301A);
		panel1.SuspendLayout();
		bunifuCards2.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B6A6800F).BeginInit();
		contextMenuStrip1.SuspendLayout();
		SuspendLayout();
		C9885896.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C9885896.BackColor = System.Drawing.Color.White;
		C9885896.BorderRadius = 5;
		C9885896.BottomSahddow = true;
		C9885896.color = System.Drawing.Color.SaddleBrown;
		C9885896.LeftSahddow = false;
		C9885896.Location = new System.Drawing.Point(0, 0);
		C9885896.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		C9885896.Name = "bunifuCards1";
		C9885896.RightSahddow = true;
		C9885896.ShadowDepth = 20;
		C9885896.Size = new System.Drawing.Size(0, 47);
		C9885896.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(label2);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(C02F4F39);
		panel1.Controls.Add(txtChuDe);
		panel1.Controls.Add(bunifuCards2);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(329, 138);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(DAB9BD11);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label2.Location = new System.Drawing.Point(28, 53);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(76, 16);
		label2.TabIndex = 47;
		label2.Text = "Tên chủ đề:";
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(167, 94);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 46;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(C30970A2);
		C02F4F39.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		C02F4F39.Cursor = System.Windows.Forms.Cursors.Hand;
		C02F4F39.FlatAppearance.BorderSize = 0;
		C02F4F39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C02F4F39.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C02F4F39.ForeColor = System.Drawing.Color.White;
		C02F4F39.Location = new System.Drawing.Point(63, 94);
		C02F4F39.Name = "btnAdd";
		C02F4F39.Size = new System.Drawing.Size(92, 29);
		C02F4F39.TabIndex = 45;
		C02F4F39.Text = "Thêm";
		C02F4F39.UseVisualStyleBackColor = false;
		C02F4F39.Click += new System.EventHandler(C02F4F39_Click);
		txtChuDe.Location = new System.Drawing.Point(111, 50);
		txtChuDe.Name = "txtChuDe";
		txtChuDe.Size = new System.Drawing.Size(180, 23);
		txtChuDe.TabIndex = 44;
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(pnlHeader);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(327, 37);
		bunifuCards2.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(E60D1030);
		pnlHeader.Controls.Add(B6A6800F);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(327, 31);
		pnlHeader.TabIndex = 9;
		E60D1030.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E60D1030.Cursor = System.Windows.Forms.Cursors.Hand;
		E60D1030.FlatAppearance.BorderSize = 0;
		E60D1030.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E60D1030.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E60D1030.ForeColor = System.Drawing.Color.White;
		E60D1030.Image = Class155.Bitmap_15;
		E60D1030.Location = new System.Drawing.Point(296, 1);
		E60D1030.Name = "button2";
		E60D1030.Size = new System.Drawing.Size(30, 30);
		E60D1030.TabIndex = 77;
		E60D1030.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E60D1030.UseVisualStyleBackColor = true;
		E60D1030.Click += new System.EventHandler(B19E0CAB);
		B6A6800F.Cursor = System.Windows.Forms.Cursors.Default;
		B6A6800F.Image = Class155.DD225F0D;
		B6A6800F.Location = new System.Drawing.Point(3, 2);
		B6A6800F.Name = "pictureBox1";
		B6A6800F.Size = new System.Drawing.Size(34, 27);
		B6A6800F.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		B6A6800F.TabIndex = 76;
		B6A6800F.TabStop = false;
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
		bunifuCustomLabel1.Text = "Thêm chủ đề";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_0, toolStripMenuItem_1, AA3BF03D });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
		toolStripMenuItem_0.Name = "thêmMớiToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_0.Text = "Thêm chủ đề";
		toolStripMenuItem_1.Name = "sửaToolStripMenuItem";
		toolStripMenuItem_1.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_1.Text = "Sửa tên chủ đề";
		AA3BF03D.Name = "xóaToolStripMenuItem";
		AA3BF03D.Size = new System.Drawing.Size(152, 22);
		AA3BF03D.Text = "Xóa chủ đề";
		A802CC34.Fixed = true;
		A802CC34.Horizontal = true;
		A802CC34.TargetControl = bunifuCustomLabel1;
		A802CC34.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(329, 138);
		base.Controls.Add(panel1);
		base.Controls.Add(C9885896);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fThemChuDe";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fThemChuDe_Load);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		bunifuCards2.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)B6A6800F).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
