using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fThemBaiViet : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards DC85DABB;

	internal Panel C124C9B9;

	internal BunifuDragControl F499D791;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem E818B314;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal Button E08AB884;

	internal Label label1;

	internal ComboBox A2BFCA34;

	internal BunifuCards bunifuCards2;

	internal Panel ECA32AB4;

	internal Button button2;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal DataGridView dgvPic;

	internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	internal TextBox txtName;

	internal Label label2;

	internal Label label5;

	internal Button btnCancel;

	internal Button button1;

	internal Label FF1DE7A3;

	internal Button BC9EE729;

	internal Button metroButton2;

	internal RichTextBox txtConten;

	internal Label label8;

	public fThemBaiViet(int B5B06B0A)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_0();
		A2BFCA34.SelectedIndex = B5B06B0A;
	}

	private void method_0()
	{
		List<string> list = CommonSQL.B5A9A490();
		for (int i = 0; i < list.Count; i++)
		{
			A2BFCA34.Items.Add(list[i]);
		}
		try
		{
			A2BFCA34.SelectedIndex = 0;
		}
		catch
		{
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		Close();
	}

	private void E9BBA0BB(object sender, EventArgs e)
	{
		Close();
	}

	private void E08AB884_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fDanhSachChuDe());
		A2BFCA34.Items.Clear();
		method_0();
	}

	private void metroButton2_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string[] fileNames = openFileDialog.FileNames;
			for (int i = 0; i < fileNames.Length; i++)
			{
				dgvPic.Rows.Add(fileNames[i]);
			}
			FF1DE7A3.Text = "Ảnh (" + dgvPic.Rows.Count + "):";
		}
	}

	private void BABBDC83(object sender, EventArgs e)
	{
		foreach (DataGridViewRow selectedRow in dgvPic.SelectedRows)
		{
			dgvPic.Rows.RemoveAt(selectedRow.Index);
		}
		FF1DE7A3.Text = "Ảnh (" + dgvPic.Rows.Count + "):";
	}

	private void FF332231(object sender, EventArgs e)
	{
		if (txtName.Text != "")
		{
			string text = "";
			if (dgvPic.Rows.Count != 0)
			{
				for (int i = 0; i < dgvPic.Rows.Count; i++)
				{
					text = text + dgvPic.Rows[i].Cells[0].Value.ToString() + "|";
				}
			}
			string string_ = "";
			string string_2 = A2BFCA34.SelectedItem.ToString();
			Class65 f61072B = new Class65
			{
				String_0 = txtName.Text,
				String_1 = text,
				String_2 = string_,
				String_4 = DateTime.Now.ToString("dd/MM/yyyy"),
				String_3 = txtConten.Text
			};
			CommonSQL.smethod_22(string_2, f61072B);
			DialogResult dialogResult = MsBoxHelper.D41C45AC("Thêm thành công. Bạn muốn có muốn đóng cửa sổ không?");
			if (dialogResult == DialogResult.Yes)
			{
				Close();
			}
		}
		else
		{
			MsBoxHelper.Show("Chưa nhập tiêu đề!", 2);
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void FCAA05B9(object sender, DataGridViewCellEventArgs e)
	{
		Process.Start(dgvPic.SelectedRows[0].Cells[0].Value.ToString());
	}

	private void A2BFCA34_Click(object sender, EventArgs e)
	{
	}

	private void C124C9B9_Paint(object sender, PaintEventArgs e)
	{
	}

	private void D83E3719(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void C939A4A2(object sender, EventArgs e)
	{
	}

	private void FC8BF507(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
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
		DC85DABB = new Bunifu.Framework.UI.BunifuCards();
		C124C9B9 = new System.Windows.Forms.Panel();
		label8 = new System.Windows.Forms.Label();
		txtConten = new System.Windows.Forms.RichTextBox();
		BC9EE729 = new System.Windows.Forms.Button();
		metroButton2 = new System.Windows.Forms.Button();
		FF1DE7A3 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		dgvPic = new System.Windows.Forms.DataGridView();
		dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		txtName = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		E08AB884 = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		A2BFCA34 = new System.Windows.Forms.ComboBox();
		bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
		ECA32AB4 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		E818B314 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		F499D791 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		C124C9B9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvPic).BeginInit();
		bunifuCards2.SuspendLayout();
		ECA32AB4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		contextMenuStrip1.SuspendLayout();
		SuspendLayout();
		DC85DABB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DC85DABB.BackColor = System.Drawing.Color.White;
		DC85DABB.BorderRadius = 5;
		DC85DABB.BottomSahddow = true;
		DC85DABB.color = System.Drawing.Color.SaddleBrown;
		DC85DABB.LeftSahddow = false;
		DC85DABB.Location = new System.Drawing.Point(0, 0);
		DC85DABB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		DC85DABB.Name = "bunifuCards1";
		DC85DABB.RightSahddow = true;
		DC85DABB.ShadowDepth = 20;
		DC85DABB.Size = new System.Drawing.Size(43, 47);
		DC85DABB.TabIndex = 12;
		C124C9B9.BackColor = System.Drawing.Color.White;
		C124C9B9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C124C9B9.Controls.Add(label8);
		C124C9B9.Controls.Add(txtConten);
		C124C9B9.Controls.Add(BC9EE729);
		C124C9B9.Controls.Add(metroButton2);
		C124C9B9.Controls.Add(FF1DE7A3);
		C124C9B9.Controls.Add(btnCancel);
		C124C9B9.Controls.Add(button1);
		C124C9B9.Controls.Add(dgvPic);
		C124C9B9.Controls.Add(txtName);
		C124C9B9.Controls.Add(label2);
		C124C9B9.Controls.Add(label5);
		C124C9B9.Controls.Add(E08AB884);
		C124C9B9.Controls.Add(label1);
		C124C9B9.Controls.Add(A2BFCA34);
		C124C9B9.Controls.Add(bunifuCards2);
		C124C9B9.Dock = System.Windows.Forms.DockStyle.Fill;
		C124C9B9.Location = new System.Drawing.Point(0, 0);
		C124C9B9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		C124C9B9.Name = "panel1";
		C124C9B9.Size = new System.Drawing.Size(372, 411);
		C124C9B9.TabIndex = 37;
		C124C9B9.Paint += new System.Windows.Forms.PaintEventHandler(C124C9B9_Paint);
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(74, 339);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(133, 16);
		label8.TabIndex = 121;
		label8.Text = "Spin nội dung {a|b|c}";
		txtConten.Location = new System.Drawing.Point(76, 187);
		txtConten.Name = "txtConten";
		txtConten.Size = new System.Drawing.Size(271, 149);
		txtConten.TabIndex = 120;
		txtConten.Text = "";
		txtConten.WordWrap = false;
		BC9EE729.BackgroundImage = Class155.B0116B0C;
		BC9EE729.Cursor = System.Windows.Forms.Cursors.Hand;
		BC9EE729.Location = new System.Drawing.Point(317, 149);
		BC9EE729.Name = "metroButton3";
		BC9EE729.Size = new System.Drawing.Size(30, 30);
		BC9EE729.TabIndex = 114;
		BC9EE729.Click += new System.EventHandler(BABBDC83);
		metroButton2.BackgroundImage = Class155.Bitmap_62;
		metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton2.Location = new System.Drawing.Point(317, 110);
		metroButton2.Name = "metroButton2";
		metroButton2.Size = new System.Drawing.Size(30, 30);
		metroButton2.TabIndex = 115;
		metroButton2.Click += new System.EventHandler(metroButton2_Click);
		FF1DE7A3.AutoSize = true;
		FF1DE7A3.Location = new System.Drawing.Point(6, 110);
		FF1DE7A3.Name = "lblNanh";
		FF1DE7A3.Size = new System.Drawing.Size(55, 16);
		FF1DE7A3.TabIndex = 109;
		FF1DE7A3.Text = "Ảnh (0):";
		FF1DE7A3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(184, 369);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 108;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		button1.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(77, 369);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(92, 29);
		button1.TabIndex = 107;
		button1.Text = "Lưu";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(FF332231);
		dgvPic.AllowUserToAddRows = false;
		dgvPic.AllowUserToDeleteRows = false;
		dgvPic.AllowUserToResizeColumns = false;
		dgvPic.AllowUserToResizeRows = false;
		dgvPic.BackgroundColor = System.Drawing.Color.White;
		dgvPic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvPic.ColumnHeadersVisible = false;
		dgvPic.Columns.AddRange(dataGridViewTextBoxColumn4);
		dgvPic.Cursor = System.Windows.Forms.Cursors.Hand;
		dgvPic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		dgvPic.Location = new System.Drawing.Point(77, 109);
		dgvPic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		dgvPic.Name = "dgvPic";
		dgvPic.RowHeadersVisible = false;
		dgvPic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dgvPic.Size = new System.Drawing.Size(234, 70);
		dgvPic.TabIndex = 83;
		dgvPic.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(FCAA05B9);
		dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn4.DataPropertyName = "Day";
		dataGridViewTextBoxColumn4.FillWeight = 57.38708f;
		dataGridViewTextBoxColumn4.HeaderText = "Đường dẫn";
		dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
		txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
		txtName.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(77, 78);
		txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(270, 23);
		txtName.TabIndex = 87;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.SystemColors.ControlText;
		label2.Location = new System.Drawing.Point(6, 187);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(62, 16);
		label2.TabIndex = 86;
		label2.Text = "Nội dung:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.SystemColors.ControlText;
		label5.Location = new System.Drawing.Point(6, 81);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(55, 16);
		label5.TabIndex = 85;
		label5.Text = "Tiêu đề:";
		label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		E08AB884.Cursor = System.Windows.Forms.Cursors.Hand;
		E08AB884.Location = new System.Drawing.Point(254, 46);
		E08AB884.Name = "metroButton1";
		E08AB884.Size = new System.Drawing.Size(93, 25);
		E08AB884.TabIndex = 82;
		E08AB884.Text = "Quản lý chủ đề";
		E08AB884.Click += new System.EventHandler(E08AB884_Click);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(6, 50);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(52, 16);
		label1.TabIndex = 81;
		label1.Text = "Chủ đề:";
		A2BFCA34.Cursor = System.Windows.Forms.Cursors.Hand;
		A2BFCA34.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A2BFCA34.FormattingEnabled = true;
		A2BFCA34.Location = new System.Drawing.Point(77, 47);
		A2BFCA34.Name = "cbbChuDe";
		A2BFCA34.Size = new System.Drawing.Size(171, 24);
		A2BFCA34.TabIndex = 80;
		A2BFCA34.Click += new System.EventHandler(A2BFCA34_Click);
		bunifuCards2.BackColor = System.Drawing.Color.White;
		bunifuCards2.BorderRadius = 0;
		bunifuCards2.BottomSahddow = true;
		bunifuCards2.color = System.Drawing.Color.SaddleBrown;
		bunifuCards2.Controls.Add(ECA32AB4);
		bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
		bunifuCards2.LeftSahddow = false;
		bunifuCards2.Location = new System.Drawing.Point(0, 0);
		bunifuCards2.Name = "bunifuCards2";
		bunifuCards2.RightSahddow = true;
		bunifuCards2.ShadowDepth = 20;
		bunifuCards2.Size = new System.Drawing.Size(370, 37);
		bunifuCards2.TabIndex = 43;
		ECA32AB4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		ECA32AB4.BackColor = System.Drawing.Color.White;
		ECA32AB4.Controls.Add(button2);
		ECA32AB4.Controls.Add(pictureBox1);
		ECA32AB4.Controls.Add(bunifuCustomLabel1);
		ECA32AB4.Cursor = System.Windows.Forms.Cursors.SizeAll;
		ECA32AB4.Location = new System.Drawing.Point(0, 3);
		ECA32AB4.Name = "pnlHeader";
		ECA32AB4.Size = new System.Drawing.Size(370, 31);
		ECA32AB4.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = Class155.Bitmap_15;
		button2.Location = new System.Drawing.Point(339, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(E9BBA0BB);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(370, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Thêm bình luận";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuCustomLabel1.Click += new System.EventHandler(C939A4A2);
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_0, E818B314, toolStripMenuItem_1 });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
		toolStripMenuItem_0.Name = "thêmMớiToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_0.Text = "Thêm chủ đề";
		E818B314.Name = "sửaToolStripMenuItem";
		E818B314.Size = new System.Drawing.Size(152, 22);
		E818B314.Text = "Sửa tên chủ đề";
		toolStripMenuItem_1.Name = "xóaToolStripMenuItem";
		toolStripMenuItem_1.Size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_1.Text = "Xóa chủ đề";
		F499D791.Fixed = true;
		F499D791.Horizontal = true;
		F499D791.TargetControl = bunifuCustomLabel1;
		F499D791.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(372, 411);
		base.Controls.Add(C124C9B9);
		base.Controls.Add(DC85DABB);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fThemBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		C124C9B9.ResumeLayout(false);
		C124C9B9.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgvPic).EndInit();
		bunifuCards2.ResumeLayout(false);
		ECA32AB4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
