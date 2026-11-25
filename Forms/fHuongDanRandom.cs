using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHuongDanRandom : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel A029D5BF;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards EC2721AB;

	internal Panel pnlHeader;

	internal Button button2;

	internal PictureBox D6AF9F30;

	internal Button btnMinimize;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal DataGridView dgv;

	internal DataGridViewTextBoxColumn cSTT;

	internal DataGridViewTextBoxColumn cTuKhoa;

	internal DataGridViewImageColumn cNoiDung;

	public fHuongDanRandom()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_0();
	}

	private void method_0()
	{
		new Random();
		dgv.Rows.Add(dgv.RowCount + 1, "[r1]", Class155.Bitmap_53);
		dgv.Rows.Add(dgv.RowCount + 1, "[r2]", Class155.C0B6F039);
		dgv.Rows.Add(dgv.RowCount + 1, "[r3]", Class155.Bitmap_54);
		dgv.Rows.Add(dgv.RowCount + 1, "[r4]", Class155.EE147DB1);
		dgv.Rows.Add(dgv.RowCount + 1, "[r5]", Class155.CFB6549C);
		dgv.Rows.Add(dgv.RowCount + 1, "[r6]", Class155.Bitmap_55);
		dgv.Rows.Add(dgv.RowCount + 1, "[r7]", Class155.Bitmap_56);
		dgv.Rows.Add(dgv.RowCount + 1, "[r8]", Class155.Bitmap_57);
		dgv.Rows.Add(dgv.RowCount + 1, "[d]", Class155.Bitmap_58);
		dgv.Rows.Add(dgv.RowCount + 1, "[t]", Class155.C398DEBB);
		dgv.Rows.Add(dgv.RowCount + 1, "[n*]", Class155.Bitmap_59);
		dgv.Rows.Add(dgv.RowCount + 1, "[s*]", Class155.C4A0F3AE);
		dgv.Rows.Add(dgv.RowCount + 1, "[q***]", Class155.CB21A99B);
	}

	private void fHuongDanRandom_Load(object sender, EventArgs e)
	{
	}

	private void D22D753C(object sender, PaintEventArgs e)
	{
	}

	private void FD02DA23(object sender, EventArgs e)
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A029D5BF = new System.Windows.Forms.Panel();
		dgv = new System.Windows.Forms.DataGridView();
		cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cTuKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cNoiDung = new System.Windows.Forms.DataGridViewImageColumn();
		EC2721AB = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		D6AF9F30 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		A029D5BF.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
		EC2721AB.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D6AF9F30).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(243, 47);
		bunifuCards1.TabIndex = 12;
		A029D5BF.BackColor = System.Drawing.Color.White;
		A029D5BF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A029D5BF.Controls.Add(dgv);
		A029D5BF.Controls.Add(EC2721AB);
		A029D5BF.Dock = System.Windows.Forms.DockStyle.Fill;
		A029D5BF.Location = new System.Drawing.Point(0, 0);
		A029D5BF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		A029D5BF.Name = "panel1";
		A029D5BF.Size = new System.Drawing.Size(572, 503);
		A029D5BF.TabIndex = 37;
		A029D5BF.Paint += new System.Windows.Forms.PaintEventHandler(D22D753C);
		dgv.AllowUserToAddRows = false;
		dgv.AllowUserToDeleteRows = false;
		dgv.AllowUserToResizeRows = false;
		dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
		dgv.BackgroundColor = System.Drawing.Color.White;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgv.Columns.AddRange(cSTT, cTuKhoa, cNoiDung);
		dgv.Location = new System.Drawing.Point(11, 43);
		dgv.Name = "dgv";
		dgv.ReadOnly = true;
		dgv.RowHeadersVisible = false;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
		dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
		dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dgv.Size = new System.Drawing.Size(547, 447);
		dgv.TabIndex = 75;
		cSTT.HeaderText = "STT";
		cSTT.Name = "cSTT";
		cSTT.ReadOnly = true;
		cSTT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		cSTT.Width = 40;
		cTuKhoa.HeaderText = "Từ khóa";
		cTuKhoa.Name = "cTuKhoa";
		cTuKhoa.ReadOnly = true;
		cTuKhoa.Width = 80;
		cNoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		cNoiDung.HeaderText = "Nội dung random";
		cNoiDung.Name = "cNoiDung";
		cNoiDung.ReadOnly = true;
		cNoiDung.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		cNoiDung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		EC2721AB.BackColor = System.Drawing.Color.White;
		EC2721AB.BorderRadius = 0;
		EC2721AB.BottomSahddow = true;
		EC2721AB.color = System.Drawing.Color.SaddleBrown;
		EC2721AB.Controls.Add(pnlHeader);
		EC2721AB.Dock = System.Windows.Forms.DockStyle.Top;
		EC2721AB.LeftSahddow = false;
		EC2721AB.Location = new System.Drawing.Point(0, 0);
		EC2721AB.Name = "bunifuCards2";
		EC2721AB.RightSahddow = true;
		EC2721AB.ShadowDepth = 20;
		EC2721AB.Size = new System.Drawing.Size(570, 37);
		EC2721AB.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(D6AF9F30);
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(570, 31);
		pnlHeader.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(539, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(FD02DA23);
		D6AF9F30.Cursor = System.Windows.Forms.Cursors.Default;
		D6AF9F30.Image = Class155.DD225F0D;
		D6AF9F30.Location = new System.Drawing.Point(3, 2);
		D6AF9F30.Name = "pictureBox1";
		D6AF9F30.Size = new System.Drawing.Size(34, 27);
		D6AF9F30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		D6AF9F30.TabIndex = 76;
		D6AF9F30.TabStop = false;
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(570, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Hướng dẫn random nội dung";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(572, 503);
		base.Controls.Add(A029D5BF);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHuongDanRandom";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fHuongDanRandom_Load);
		A029D5BF.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dgv).EndInit();
		EC2721AB.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D6AF9F30).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
