using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fSuaBaiViet : Form
{
	internal int int_0;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel D699E8A3;

	internal BunifuDragControl F0199009;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal Label label1;

	internal ComboBox cbbChuDe;

	internal BunifuCards EA93E32B;

	internal Panel pnlHeader;

	internal Button E121CD80;

	internal PictureBox C20EE304;

	internal BunifuCustomLabel ACBEAD2C;

	internal Label lblNanh;

	internal DataGridView FA238A33;

	internal DataGridViewTextBoxColumn DA16EEA9;

	internal TextBox txtName;

	internal Label C0110007;

	internal Label label5;

	internal Button C989FA87;

	internal Button F0392B90;

	internal Button metroButton2;

	internal Button metroButton3;

	internal Label label8;

	internal RichTextBox E69B8E1C;

	public fSuaBaiViet(int int_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		D00EA384();
		int_0 = int_1;
		List<Class65> list = CommonSQL.FD9ECF83(int_1.ToString());
		foreach (Class65 item in list)
		{
			cbbChuDe.Text = item.DDAA0B14;
			txtName.Text = item.String_0;
			E69B8E1C.Text = item.String_3;
			string[] array = item.String_1.Split('|');
			lblNanh.Text = "Ảnh (" + (array.Length - 1) + "):";
			item.String_2.Split('|');
			for (int i = 0; i < array.Length - 1; i++)
			{
				FA238A33.Rows.Add(array[i]);
			}
		}
	}

	private void D00EA384()
	{
		List<string> list = CommonSQL.B5A9A490();
		for (int i = 0; i < list.Count; i++)
		{
			cbbChuDe.Items.Add(list[i]);
		}
		try
		{
			cbbChuDe.SelectedIndex = 0;
		}
		catch
		{
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		Close();
	}

	private void fSuaBaiViet_Load(object sender, EventArgs e)
	{
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void F30EE72B(object sender, PaintEventArgs e)
	{
	}

	private void CD84D012(object sender, EventArgs e)
	{
		Close();
	}

	private void AA855185(object sender, EventArgs e)
	{
		if (txtName.Text != "")
		{
			string text = "";
			if (FA238A33.Rows.Count != 0)
			{
				for (int i = 0; i < FA238A33.Rows.Count; i++)
				{
					text = text + FA238A33.Rows[i].Cells[0].Value.ToString() + "|";
				}
			}
			string string_ = "";
			Class65 b127D = new Class65
			{
				String_0 = txtName.Text,
				String_1 = text,
				String_2 = string_,
				String_3 = E69B8E1C.Text
			};
			CommonSQL.smethod_21(int_0, b127D);
			if (MsBoxHelper.D41C45AC("Cập nhập thành công. Bạn có muốn thoát?") == DialogResult.Yes)
			{
				Close();
			}
		}
		else
		{
			MsBoxHelper.Show("Chưa nhập tiêu đề");
		}
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
				FA238A33.Rows.Add(fileNames[i]);
			}
			lblNanh.Text = "Ảnh (" + FA238A33.Rows.Count + "):";
		}
	}

	private void DB83C196(object sender, EventArgs e)
	{
		foreach (DataGridViewRow selectedRow in FA238A33.SelectedRows)
		{
			FA238A33.Rows.RemoveAt(selectedRow.Index);
		}
		lblNanh.Text = "Ảnh (" + FA238A33.Rows.Count + "):";
	}

	private void C989FA87_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void FA238A33_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		Process.Start(FA238A33.SelectedRows[0].Cells[0].Value.ToString());
	}

	private void AEA97B95(object sender, EventArgs e)
	{
	}

	private void fSuaBaiViet_FormClosed(object sender, FormClosedEventArgs e)
	{
		List<string> list_ = new List<string>();
		new fChonBaiViet(ref list_);
	}

	private void E521493C(object sender, EventArgs e)
	{
	}

	private void method_2(object sender, EventArgs e)
	{
		Commom.smethod_35(new fDanhSachChuDe());
		cbbChuDe.Items.Clear();
		D00EA384();
	}

	private void B6873519(object sender, LinkLabelLinkClickedEventArgs e)
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
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		D699E8A3 = new System.Windows.Forms.Panel();
		E69B8E1C = new System.Windows.Forms.RichTextBox();
		label8 = new System.Windows.Forms.Label();
		metroButton3 = new System.Windows.Forms.Button();
		metroButton2 = new System.Windows.Forms.Button();
		C989FA87 = new System.Windows.Forms.Button();
		F0392B90 = new System.Windows.Forms.Button();
		lblNanh = new System.Windows.Forms.Label();
		FA238A33 = new System.Windows.Forms.DataGridView();
		DA16EEA9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		txtName = new System.Windows.Forms.TextBox();
		C0110007 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		cbbChuDe = new System.Windows.Forms.ComboBox();
		EA93E32B = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		E121CD80 = new System.Windows.Forms.Button();
		C20EE304 = new System.Windows.Forms.PictureBox();
		ACBEAD2C = new Bunifu.Framework.UI.BunifuCustomLabel();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		F0199009 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D699E8A3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FA238A33).BeginInit();
		EA93E32B.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)C20EE304).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(46, 47);
		bunifuCards1.TabIndex = 12;
		D699E8A3.BackColor = System.Drawing.Color.White;
		D699E8A3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D699E8A3.Controls.Add(E69B8E1C);
		D699E8A3.Controls.Add(label8);
		D699E8A3.Controls.Add(metroButton3);
		D699E8A3.Controls.Add(metroButton2);
		D699E8A3.Controls.Add(C989FA87);
		D699E8A3.Controls.Add(F0392B90);
		D699E8A3.Controls.Add(lblNanh);
		D699E8A3.Controls.Add(FA238A33);
		D699E8A3.Controls.Add(txtName);
		D699E8A3.Controls.Add(C0110007);
		D699E8A3.Controls.Add(label5);
		D699E8A3.Controls.Add(label1);
		D699E8A3.Controls.Add(cbbChuDe);
		D699E8A3.Controls.Add(EA93E32B);
		D699E8A3.Dock = System.Windows.Forms.DockStyle.Fill;
		D699E8A3.Location = new System.Drawing.Point(0, 0);
		D699E8A3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		D699E8A3.Name = "panel1";
		D699E8A3.Size = new System.Drawing.Size(375, 414);
		D699E8A3.TabIndex = 37;
		D699E8A3.Paint += new System.Windows.Forms.PaintEventHandler(F30EE72B);
		E69B8E1C.Location = new System.Drawing.Point(89, 184);
		E69B8E1C.Name = "txtConten";
		E69B8E1C.Size = new System.Drawing.Size(271, 149);
		E69B8E1C.TabIndex = 119;
		E69B8E1C.Text = "";
		E69B8E1C.WordWrap = false;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(86, 336);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(133, 16);
		label8.TabIndex = 117;
		label8.Text = "Spin nội dung {a|b|c}";
		metroButton3.BackgroundImage = Class155.B0116B0C;
		metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton3.Location = new System.Drawing.Point(330, 148);
		metroButton3.Name = "metroButton3";
		metroButton3.Size = new System.Drawing.Size(30, 30);
		metroButton3.TabIndex = 113;
		metroButton3.Click += new System.EventHandler(DB83C196);
		metroButton2.BackgroundImage = Class155.Bitmap_62;
		metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton2.Location = new System.Drawing.Point(330, 109);
		metroButton2.Name = "metroButton2";
		metroButton2.Size = new System.Drawing.Size(30, 30);
		metroButton2.TabIndex = 113;
		metroButton2.Click += new System.EventHandler(metroButton2_Click);
		C989FA87.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C989FA87.BackColor = System.Drawing.Color.Maroon;
		C989FA87.Cursor = System.Windows.Forms.Cursors.Hand;
		C989FA87.FlatAppearance.BorderSize = 0;
		C989FA87.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C989FA87.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C989FA87.ForeColor = System.Drawing.Color.White;
		C989FA87.Location = new System.Drawing.Point(192, 370);
		C989FA87.Name = "btnCancel";
		C989FA87.Size = new System.Drawing.Size(92, 29);
		C989FA87.TabIndex = 103;
		C989FA87.Text = "Đóng";
		C989FA87.UseVisualStyleBackColor = false;
		C989FA87.Click += new System.EventHandler(C989FA87_Click);
		F0392B90.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F0392B90.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		F0392B90.Cursor = System.Windows.Forms.Cursors.Hand;
		F0392B90.FlatAppearance.BorderSize = 0;
		F0392B90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F0392B90.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F0392B90.ForeColor = System.Drawing.Color.White;
		F0392B90.Location = new System.Drawing.Point(85, 370);
		F0392B90.Name = "button1";
		F0392B90.Size = new System.Drawing.Size(92, 29);
		F0392B90.TabIndex = 102;
		F0392B90.Text = "Cập nhật";
		F0392B90.UseVisualStyleBackColor = false;
		F0392B90.Click += new System.EventHandler(AA855185);
		lblNanh.AutoSize = true;
		lblNanh.Location = new System.Drawing.Point(11, 109);
		lblNanh.Name = "lblNanh";
		lblNanh.Size = new System.Drawing.Size(55, 16);
		lblNanh.TabIndex = 90;
		lblNanh.Text = "Ảnh (0):";
		lblNanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		FA238A33.AllowUserToAddRows = false;
		FA238A33.AllowUserToDeleteRows = false;
		FA238A33.AllowUserToResizeColumns = false;
		FA238A33.AllowUserToResizeRows = false;
		FA238A33.BackgroundColor = System.Drawing.Color.White;
		FA238A33.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		FA238A33.ColumnHeadersVisible = false;
		FA238A33.Columns.AddRange(DA16EEA9);
		FA238A33.Cursor = System.Windows.Forms.Cursors.Hand;
		FA238A33.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		FA238A33.Location = new System.Drawing.Point(90, 109);
		FA238A33.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		FA238A33.Name = "dgvPic";
		FA238A33.RowHeadersVisible = false;
		FA238A33.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		FA238A33.Size = new System.Drawing.Size(236, 69);
		FA238A33.TabIndex = 83;
		FA238A33.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(FA238A33_CellDoubleClick);
		DA16EEA9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		DA16EEA9.DataPropertyName = "Day";
		DA16EEA9.FillWeight = 57.38708f;
		DA16EEA9.HeaderText = "Đường dẫn";
		DA16EEA9.Name = "dataGridViewTextBoxColumn4";
		txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
		txtName.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(90, 78);
		txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(269, 23);
		txtName.TabIndex = 87;
		C0110007.AutoSize = true;
		C0110007.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C0110007.ForeColor = System.Drawing.SystemColors.ControlText;
		C0110007.Location = new System.Drawing.Point(11, 187);
		C0110007.Name = "label2";
		C0110007.Size = new System.Drawing.Size(62, 16);
		C0110007.TabIndex = 86;
		C0110007.Text = "Nội dung:";
		C0110007.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.SystemColors.ControlText;
		label5.Location = new System.Drawing.Point(11, 81);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(55, 16);
		label5.TabIndex = 85;
		label5.Text = "Tiêu đề:";
		label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(11, 50);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(52, 16);
		label1.TabIndex = 81;
		label1.Text = "Chủ đề:";
		cbbChuDe.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbChuDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbChuDe.Enabled = false;
		cbbChuDe.FormattingEnabled = true;
		cbbChuDe.Location = new System.Drawing.Point(90, 47);
		cbbChuDe.Name = "cbbChuDe";
		cbbChuDe.Size = new System.Drawing.Size(269, 24);
		cbbChuDe.TabIndex = 80;
		cbbChuDe.SelectedIndexChanged += new System.EventHandler(E521493C);
		cbbChuDe.Click += new System.EventHandler(AEA97B95);
		EA93E32B.BackColor = System.Drawing.Color.White;
		EA93E32B.BorderRadius = 0;
		EA93E32B.BottomSahddow = true;
		EA93E32B.color = System.Drawing.Color.SaddleBrown;
		EA93E32B.Controls.Add(pnlHeader);
		EA93E32B.Dock = System.Windows.Forms.DockStyle.Top;
		EA93E32B.LeftSahddow = false;
		EA93E32B.Location = new System.Drawing.Point(0, 0);
		EA93E32B.Name = "bunifuCards2";
		EA93E32B.RightSahddow = true;
		EA93E32B.ShadowDepth = 20;
		EA93E32B.Size = new System.Drawing.Size(373, 37);
		EA93E32B.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(E121CD80);
		pnlHeader.Controls.Add(C20EE304);
		pnlHeader.Controls.Add(ACBEAD2C);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(373, 31);
		pnlHeader.TabIndex = 9;
		E121CD80.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E121CD80.Cursor = System.Windows.Forms.Cursors.Hand;
		E121CD80.FlatAppearance.BorderSize = 0;
		E121CD80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E121CD80.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E121CD80.ForeColor = System.Drawing.Color.White;
		E121CD80.Image = Class155.Bitmap_15;
		E121CD80.Location = new System.Drawing.Point(342, 1);
		E121CD80.Name = "button2";
		E121CD80.Size = new System.Drawing.Size(30, 30);
		E121CD80.TabIndex = 77;
		E121CD80.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E121CD80.UseVisualStyleBackColor = true;
		E121CD80.Click += new System.EventHandler(CD84D012);
		C20EE304.Cursor = System.Windows.Forms.Cursors.Default;
		C20EE304.Image = Class155.DD225F0D;
		C20EE304.Location = new System.Drawing.Point(3, 2);
		C20EE304.Name = "pictureBox1";
		C20EE304.Size = new System.Drawing.Size(34, 27);
		C20EE304.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		C20EE304.TabIndex = 76;
		C20EE304.TabStop = false;
		ACBEAD2C.BackColor = System.Drawing.Color.Transparent;
		ACBEAD2C.Cursor = System.Windows.Forms.Cursors.SizeAll;
		ACBEAD2C.Dock = System.Windows.Forms.DockStyle.Fill;
		ACBEAD2C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		ACBEAD2C.ForeColor = System.Drawing.Color.Black;
		ACBEAD2C.Location = new System.Drawing.Point(0, 0);
		ACBEAD2C.Name = "bunifuCustomLabel1";
		ACBEAD2C.Size = new System.Drawing.Size(373, 31);
		ACBEAD2C.TabIndex = 12;
		ACBEAD2C.Text = "Sửa bình luận";
		ACBEAD2C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		F0199009.Fixed = true;
		F0199009.Horizontal = true;
		F0199009.TargetControl = ACBEAD2C;
		F0199009.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(375, 414);
		base.Controls.Add(D699E8A3);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fSuaBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình chung";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(fSuaBaiViet_FormClosed);
		base.Load += new System.EventHandler(fSuaBaiViet_Load);
		D699E8A3.ResumeLayout(false);
		D699E8A3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)FA238A33).EndInit();
		EA93E32B.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)C20EE304).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
