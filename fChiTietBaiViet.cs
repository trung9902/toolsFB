using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChiTietBaiViet : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl C4307D24;

	internal BunifuCards bunifuCards2;

	internal Panel DFB9DBA7;

	internal Button button2;

	internal PictureBox CD063621;

	internal Button btnMinimize;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal Label CE965531;

	internal DataGridView B49F313E;

	internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	internal TextBox txtChuDe;

	internal Label DFAAB406;

	internal TextBox txtConten;

	internal Label F61BD33E;

	internal Label label2;

	internal TextBox D29CD605;

	public fChiTietBaiViet(int int_0)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		List<Class65> list = CommonSQL.FD9ECF83(int_0.ToString());
		foreach (Class65 item in list)
		{
			txtChuDe.Text = item.DDAA0B14;
			D29CD605.Text = item.String_0;
			txtConten.Text = item.String_3;
			string[] array = item.String_1.Split('|');
			CE965531.Text = "Ảnh (" + (array.Length - 1) + "):";
			item.String_2.Split('|');
			for (int i = 0; i < array.Length - 1; i++)
			{
				B49F313E.Rows.Add(array[i]);
			}
		}
	}

	private void CD82AA9F(object sender, EventArgs e)
	{
		Close();
	}

	private void B806A494(object sender, EventArgs e)
	{
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void E0A5AB0E(object sender, EventArgs e)
	{
		Close();
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void B49F313E_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			Process.Start(B49F313E.SelectedRows[0].Cells[0].Value.ToString());
		}
		catch (Exception)
		{
			MsBoxHelper.Show("Link ảnh không tồn tại!");
		}
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void BCB51B84(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void B49F313E_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
		CE965531 = new System.Windows.Forms.Label();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		DFB9DBA7 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		CD063621 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		B49F313E = new System.Windows.Forms.DataGridView();
		dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		txtChuDe = new System.Windows.Forms.TextBox();
		DFAAB406 = new System.Windows.Forms.Label();
		txtConten = new System.Windows.Forms.TextBox();
		F61BD33E = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		D29CD605 = new System.Windows.Forms.TextBox();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		C4307D24 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		bunifuCards2.SuspendLayout();
		DFB9DBA7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CD063621).BeginInit();
		((System.ComponentModel.ISupportInitialize)B49F313E).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(36, 47);
		bunifuCards1.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(CE965531);
		panel1.Controls.Add(bunifuCards2);
		panel1.Controls.Add(B49F313E);
		panel1.Controls.Add(txtChuDe);
		panel1.Controls.Add(DFAAB406);
		panel1.Controls.Add(txtConten);
		panel1.Controls.Add(F61BD33E);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(D29CD605);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(365, 342);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		CE965531.AutoSize = true;
		CE965531.Location = new System.Drawing.Point(6, 100);
		CE965531.Name = "lblNanh";
		CE965531.Size = new System.Drawing.Size(55, 16);
		CE965531.TabIndex = 50;
		CE965531.Text = "Ảnh (0):";
		CE965531.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(DFB9DBA7);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(363, 37);
		bunifuCards2.TabIndex = 43;
		DFB9DBA7.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DFB9DBA7.BackColor = System.Drawing.Color.White;
		DFB9DBA7.Controls.Add(button2);
		DFB9DBA7.Controls.Add(CD063621);
		DFB9DBA7.Controls.Add(btnMinimize);
		DFB9DBA7.Controls.Add(bunifuCustomLabel1);
		DFB9DBA7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		DFB9DBA7.Location = new System.Drawing.Point(0, 3);
		DFB9DBA7.Name = "pnlHeader";
		DFB9DBA7.Size = new System.Drawing.Size(363, 31);
		DFB9DBA7.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(332, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(E0A5AB0E);
		CD063621.Cursor = System.Windows.Forms.Cursors.Default;
		CD063621.Image = Class155.DD225F0D;
		CD063621.Location = new System.Drawing.Point(3, 2);
		CD063621.Name = "pictureBox1";
		CD063621.Size = new System.Drawing.Size(34, 27);
		CD063621.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		CD063621.TabIndex = 76;
		CD063621.TabStop = false;
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(363, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Chi tiết bài viết";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B49F313E.AllowUserToAddRows = false;
		B49F313E.AllowUserToDeleteRows = false;
		B49F313E.AllowUserToResizeColumns = false;
		B49F313E.AllowUserToResizeRows = false;
		B49F313E.BackgroundColor = System.Drawing.Color.White;
		B49F313E.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		B49F313E.ColumnHeadersVisible = false;
		B49F313E.Columns.AddRange(dataGridViewTextBoxColumn4);
		B49F313E.Cursor = System.Windows.Forms.Cursors.Hand;
		B49F313E.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		B49F313E.Location = new System.Drawing.Point(85, 97);
		B49F313E.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		B49F313E.Name = "dgvPic";
		B49F313E.RowHeadersVisible = false;
		B49F313E.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		B49F313E.Size = new System.Drawing.Size(270, 76);
		B49F313E.TabIndex = 42;
		B49F313E.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(B49F313E_CellContentClick);
		B49F313E.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(B49F313E_CellDoubleClick);
		dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn4.DataPropertyName = "Day";
		dataGridViewTextBoxColumn4.FillWeight = 57.38708f;
		dataGridViewTextBoxColumn4.HeaderText = "Đường dẫn";
		dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
		txtChuDe.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtChuDe.Location = new System.Drawing.Point(85, 41);
		txtChuDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		txtChuDe.Name = "txtChuDe";
		txtChuDe.ReadOnly = true;
		txtChuDe.Size = new System.Drawing.Size(270, 23);
		txtChuDe.TabIndex = 46;
		DFAAB406.AutoSize = true;
		DFAAB406.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		DFAAB406.ForeColor = System.Drawing.SystemColors.ControlText;
		DFAAB406.Location = new System.Drawing.Point(6, 72);
		DFAAB406.Name = "label5";
		DFAAB406.Size = new System.Drawing.Size(55, 16);
		DFAAB406.TabIndex = 44;
		DFAAB406.Text = "Tiêu đề:";
		DFAAB406.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		txtConten.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtConten.Location = new System.Drawing.Point(85, 181);
		txtConten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		txtConten.Multiline = true;
		txtConten.Name = "txtConten";
		txtConten.ReadOnly = true;
		txtConten.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		txtConten.Size = new System.Drawing.Size(270, 149);
		txtConten.TabIndex = 48;
		txtConten.WordWrap = false;
		F61BD33E.AutoSize = true;
		F61BD33E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F61BD33E.ForeColor = System.Drawing.SystemColors.ControlText;
		F61BD33E.Location = new System.Drawing.Point(6, 44);
		F61BD33E.Name = "label4";
		F61BD33E.Size = new System.Drawing.Size(52, 16);
		F61BD33E.TabIndex = 43;
		F61BD33E.Text = "Chủ đề:";
		F61BD33E.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.SystemColors.ControlText;
		label2.Location = new System.Drawing.Point(6, 184);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(62, 16);
		label2.TabIndex = 45;
		label2.Text = "Nội dung:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		D29CD605.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D29CD605.Location = new System.Drawing.Point(85, 69);
		D29CD605.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		D29CD605.Name = "txtName";
		D29CD605.ReadOnly = true;
		D29CD605.Size = new System.Drawing.Size(270, 23);
		D29CD605.TabIndex = 47;
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_0, toolStripMenuItem_1, toolStripMenuItem_2 });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
		toolStripMenuItem_0.Name = "thêmMớiToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_0.Text = "Thêm chủ đề";
		toolStripMenuItem_1.Name = "sửaToolStripMenuItem";
		toolStripMenuItem_1.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_1.Text = "Sửa tên chủ đề";
		toolStripMenuItem_2.Name = "xóaToolStripMenuItem";
		toolStripMenuItem_2.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_2.Text = "Xóa chủ đề";
		C4307D24.Fixed = true;
		C4307D24.Horizontal = true;
		C4307D24.TargetControl = bunifuCustomLabel1;
		C4307D24.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(365, 342);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fChiTietBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(B806A494);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		bunifuCards2.ResumeLayout(false);
		DFB9DBA7.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)CD063621).EndInit();
		((System.ComponentModel.ISupportInitialize)B49F313E).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
