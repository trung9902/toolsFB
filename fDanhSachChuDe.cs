using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fDanhSachChuDe : Form
{
	internal IContainer D536E08A = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl D8177925;

	internal GroupBox groupBox2;

	internal DataGridView F11CDFA5;

	internal Label D438D027;

	internal Label label7;

	internal BunifuCards bunifuCards2;

	internal Panel B9907730;

	internal Button B11808BA;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal DataGridViewTextBoxColumn A2BE7E03;

	internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem A324433A;

	internal ToolStripMenuItem BE02E896;

	internal ToolStripMenuItem BE08C32F;

	internal ToolStripMenuItem toolStripMenuItem_0;

	public fDanhSachChuDe()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_0();
	}

	private void method_0()
	{
		List<string> list = CommonSQL.B5A9A490();
		for (int i = 0; i < list.Count; i++)
		{
			F11CDFA5.Rows.Add(i + 1, list[i]);
		}
		D438D027.Text = list.Count().ToString();
	}

	private void F191A1AE(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void B11808BA_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void A324433A_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fThemChuDe());
		F11CDFA5.Rows.Clear();
		method_0();
	}

	private void DA380834(object sender, EventArgs e)
	{
		string string_ = F11CDFA5.SelectedRows[0].Cells[1].Value.ToString();
		Commom.smethod_35(new fSuaChuDe(string_));
		F11CDFA5.Rows.Clear();
		method_0();
	}

	private void D9BFF1B7(object sender, EventArgs e)
	{
	}

	private void D438D027_Click(object sender, EventArgs e)
	{
	}

	private void C5AD392A(object sender, EventArgs e)
	{
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void E915870B(object sender, PopupEventArgs e)
	{
	}

	private void BE08C32F_Click(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC("Bạn có muốn xóa chủ đề này không?") == DialogResult.Yes)
		{
			string text = F11CDFA5.SelectedRows[0].Cells[1].Value.ToString();
			CommonSQL.F91901A8(text);
			CommonSQL.smethod_19(text);
			F11CDFA5.Rows.Clear();
			method_0();
		}
	}

	private void EA93669A(object sender, EventArgs e)
	{
		F11CDFA5.Rows.Clear();
		method_0();
	}

	private void F11CDFA5_Click(object sender, EventArgs e)
	{
	}

	private void F11CDFA5_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void AB082828(object sender, EventArgs e)
	{
	}

	private void groupBox2_Enter(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D536E08A != null)
		{
			D536E08A.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		D536E08A = new System.ComponentModel.Container();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		B9907730 = new System.Windows.Forms.Panel();
		B11808BA = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		groupBox2 = new System.Windows.Forms.GroupBox();
		D438D027 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		F11CDFA5 = new System.Windows.Forms.DataGridView();
		A2BE7E03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(D536E08A);
		A324433A = new System.Windows.Forms.ToolStripMenuItem();
		BE02E896 = new System.Windows.Forms.ToolStripMenuItem();
		BE08C32F = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		D8177925 = new Bunifu.Framework.UI.BunifuDragControl(D536E08A);
		panel1.SuspendLayout();
		bunifuCards2.SuspendLayout();
		B9907730.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F11CDFA5).BeginInit();
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
		panel1.Controls.Add(bunifuCards2);
		panel1.Controls.Add(groupBox2);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(329, 317);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(B9907730);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(327, 37);
		bunifuCards2.TabIndex = 43;
		B9907730.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B9907730.BackColor = System.Drawing.Color.White;
		B9907730.Controls.Add(B11808BA);
		B9907730.Controls.Add(pictureBox1);
		B9907730.Controls.Add(btnMinimize);
		B9907730.Controls.Add(bunifuCustomLabel1);
		B9907730.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B9907730.Location = new System.Drawing.Point(0, 3);
		B9907730.Name = "pnlHeader";
		B9907730.Size = new System.Drawing.Size(327, 31);
		B9907730.TabIndex = 9;
		B11808BA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		B11808BA.Cursor = System.Windows.Forms.Cursors.Hand;
		B11808BA.FlatAppearance.BorderSize = 0;
		B11808BA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B11808BA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B11808BA.ForeColor = System.Drawing.Color.White;
		B11808BA.Image = Class155.F48B259E;
		B11808BA.Location = new System.Drawing.Point(296, 1);
		B11808BA.Name = "button2";
		B11808BA.Size = new System.Drawing.Size(30, 30);
		B11808BA.TabIndex = 77;
		B11808BA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B11808BA.UseVisualStyleBackColor = true;
		B11808BA.Click += new System.EventHandler(B11808BA_Click);
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
		bunifuCustomLabel1.Text = "Danh sách chủ đề";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		groupBox2.BackColor = System.Drawing.Color.White;
		groupBox2.Controls.Add(D438D027);
		groupBox2.Controls.Add(label7);
		groupBox2.Controls.Add(F11CDFA5);
		groupBox2.Location = new System.Drawing.Point(6, 40);
		groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
		groupBox2.Name = "groupBox2";
		groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
		groupBox2.Size = new System.Drawing.Size(311, 269);
		groupBox2.TabIndex = 41;
		groupBox2.TabStop = false;
		groupBox2.Text = "Danh sách chủ đề";
		groupBox2.Enter += new System.EventHandler(groupBox2_Enter);
		D438D027.AutoSize = true;
		D438D027.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		D438D027.ForeColor = System.Drawing.Color.Blue;
		D438D027.Location = new System.Drawing.Point(273, 248);
		D438D027.Name = "lblCountChuDe";
		D438D027.Size = new System.Drawing.Size(15, 16);
		D438D027.TabIndex = 78;
		D438D027.Text = "0";
		D438D027.Click += new System.EventHandler(D438D027_Click);
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label7.Location = new System.Drawing.Point(231, 248);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(43, 16);
		label7.TabIndex = 79;
		label7.Text = "Tổng:";
		label7.Click += new System.EventHandler(D9BFF1B7);
		F11CDFA5.AllowUserToAddRows = false;
		F11CDFA5.AllowUserToDeleteRows = false;
		F11CDFA5.AllowUserToResizeRows = false;
		F11CDFA5.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		F11CDFA5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		F11CDFA5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		F11CDFA5.Columns.AddRange(A2BE7E03, dataGridViewTextBoxColumn4);
		F11CDFA5.ContextMenuStrip = contextMenuStrip1;
		F11CDFA5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		F11CDFA5.Location = new System.Drawing.Point(9, 23);
		F11CDFA5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		F11CDFA5.MultiSelect = false;
		F11CDFA5.Name = "dgvChuDe";
		F11CDFA5.RowHeadersVisible = false;
		F11CDFA5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		F11CDFA5.Size = new System.Drawing.Size(293, 221);
		F11CDFA5.TabIndex = 76;
		F11CDFA5.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(F11CDFA5_CellContentClick);
		F11CDFA5.Click += new System.EventHandler(F11CDFA5_Click);
		A2BE7E03.HeaderText = "STT";
		A2BE7E03.Name = "dataGridViewTextBoxColumn1";
		A2BE7E03.Width = 35;
		dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn4.HeaderText = "Tên chủ đề";
		dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { A324433A, BE02E896, BE08C32F, toolStripMenuItem_0 });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(179, 92);
		A324433A.Name = "thêmMớiToolStripMenuItem";
		A324433A.Size = new System.Drawing.Size(178, 22);
		A324433A.Text = "Thêm chủ đề";
		A324433A.Click += new System.EventHandler(A324433A_Click);
		BE02E896.Name = "sửaToolStripMenuItem";
		BE02E896.Size = new System.Drawing.Size(178, 22);
		BE02E896.Text = "Sửa tên chủ đề";
		BE02E896.Click += new System.EventHandler(DA380834);
		BE08C32F.Name = "xóaToolStripMenuItem";
		BE08C32F.Size = new System.Drawing.Size(178, 22);
		BE08C32F.Text = "Xóa chủ đề";
		BE08C32F.Click += new System.EventHandler(BE08C32F_Click);
		toolStripMenuItem_0.Name = "tảiLạiToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(178, 22);
		toolStripMenuItem_0.Text = "Làm mới danh sách";
		toolStripMenuItem_0.Click += new System.EventHandler(EA93669A);
		D8177925.Fixed = true;
		D8177925.Horizontal = true;
		D8177925.TargetControl = bunifuCustomLabel1;
		D8177925.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(329, 317);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fDanhSachChuDe";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(AB082828);
		panel1.ResumeLayout(false);
		bunifuCards2.ResumeLayout(false);
		B9907730.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)F11CDFA5).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
