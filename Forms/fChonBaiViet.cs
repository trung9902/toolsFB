using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChonBaiViet : Form
{
	internal bool DAB10F11 = false;

	internal List<string> list_0 = new List<string>();

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel panel1;

	internal BunifuDragControl bunifuDragControl_0;

	internal Button btnCancel;

	internal Button btnSave;

	internal GroupBox EA3FECA0;

	internal GroupBox groupBox1;

	internal DataGridView dgvDSBaiViet;

	internal Button metroButton1;

	internal Label label1;

	internal ComboBox cbbChuDe;

	internal Label lblCountAcc;

	internal Label FA032034;

	internal BunifuCards ADA6862D;

	internal Panel C9918CB3;

	internal PictureBox pictureBox1;

	internal Button btnMinimize;

	internal BunifuCustomLabel CAAFBC38;

	internal Label FDAC381E;

	internal DataGridView C094F807;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem ED233FAF;

	internal ToolStripMenuItem CDAA4CB0;

	internal Label label3;

	internal DataGridViewTextBoxColumn D6246399;

	internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

	internal DataGridViewTextBoxColumn C517C111;

	internal DataGridViewTextBoxColumn F3233994;

	internal DataGridViewTextBoxColumn E83FB908;

	internal DataGridViewTextBoxColumn C914D20E;

	internal DataGridViewTextBoxColumn cStt;

	internal DataGridViewTextBoxColumn AE2FC4B4;

	internal DataGridViewTextBoxColumn B3B4B400;

	internal DataGridViewTextBoxColumn F62F78A5;

	internal DataGridViewTextBoxColumn cAnh;

	internal DataGridViewTextBoxColumn cVideo;

	public fChonBaiViet(ref List<string> list_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		method_1();
		list_0 = list_1;
		method_0();
	}

	private void method_0()
	{
		if (list_0.Count <= 0)
		{
			return;
		}
		C094F807.Rows.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			try
			{
				Class65 @class = ADBC4E39(list_0[i]);
				C094F807.Rows.Add(i + 1, @class.DDAA0B14, @class.Int32_0, @class.String_0, @class.String_1.Split('|').Length - 1, @class.String_2.Split('|').Length - 1);
			}
			catch
			{
				list_0.RemoveAt(i--);
			}
		}
	}

	private Class65 ADBC4E39(string A69E6B95)
	{
		Class65 result = new Class65();
		try
		{
			result = CommonSQL.FD9ECF83(A69E6B95)[0];
		}
		catch
		{
		}
		return result;
	}

	private void method_1(bool bool_0 = false)
	{
		int selectedIndex = cbbChuDe.SelectedIndex;
		cbbChuDe.Items.Clear();
		List<string> list = CommonSQL.B5A9A490();
		for (int i = 0; i < list.Count; i++)
		{
			cbbChuDe.Items.Add(list[i]);
		}
		if (cbbChuDe.Items.Count == 0)
		{
			cbbChuDe.SelectedIndex = -1;
		}
		else if (cbbChuDe.Items.Count == 1)
		{
			cbbChuDe.SelectedIndex = 0;
		}
		else if (selectedIndex == -1)
		{
			cbbChuDe.SelectedIndex = 0;
		}
		else if (cbbChuDe.Items.Count - 1 < selectedIndex)
		{
			cbbChuDe.SelectedIndex = cbbChuDe.Items.Count - 1;
		}
		else
		{
			cbbChuDe.SelectedIndex = selectedIndex;
		}
		C8AA8835(bool_0);
		method_0();
	}

	private void C8AA8835(bool bool_0 = true)
	{
		try
		{
			dgvDSBaiViet.Rows.Clear();
			List<Class65> list = new List<Class65>();
			list = (bool_0 ? CommonSQL.A4ACAC39() : CommonSQL.A4ACAC39(cbbChuDe.SelectedItem.ToString()));
			Class65 @class = new Class65();
			for (int i = 0; i < list.Count; i++)
			{
				@class = list[i];
				dgvDSBaiViet.Rows.Add(i + 1, @class.DDAA0B14, @class.Int32_0, @class.String_0, @class.String_1.Split('|').Length - 1, @class.String_2.Split('|').Length - 1);
			}
		}
		catch
		{
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E08A9D81(object sender, EventArgs e)
	{
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		list_0.Clear();
		for (int i = 0; i < C094F807.RowCount; i++)
		{
			list_0.Add(C094F807.Rows[i].Cells["cId"].Value.ToString());
		}
		if (MsBoxHelper.D41C45AC("Lưu thành công, bạn có muốn đóng cửa sổ?") == DialogResult.Yes)
		{
			Close();
		}
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void F78EB62A(object sender, EventArgs e)
	{
		Close();
	}

	private void A4B3B08C(object sender, EventArgs e)
	{
		Commom.smethod_35(new fDanhSachChuDe());
		method_1(DAB10F11);
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		try
		{
			int count = CommonSQL.A4ACAC39().Count;
			Commom.smethod_35(new fThemBaiViet(cbbChuDe.SelectedIndex));
			int count2 = CommonSQL.A4ACAC39().Count;
			if (count2 > count)
			{
				Class65 @class = CommonSQL.smethod_20()[0];
				dgvDSBaiViet.Rows.Add(dgvDSBaiViet.RowCount + 1, @class.DDAA0B14, @class.Int32_0, @class.String_0, @class.String_1.Split('|').Length - 1, @class.String_2.Split('|').Length - 1);
			}
		}
		catch
		{
		}
	}

	private void FFB2F8B8(object sender, EventArgs e)
	{
		try
		{
			DataGridViewRow dataGridViewRow = dgvDSBaiViet.SelectedRows[0];
			int int_ = Convert.ToInt32(dataGridViewRow.Cells[2].Value);
			Commom.smethod_35(new fSuaBaiViet(int_));
			Class65 @class = CommonSQL.FD9ECF83(int_.ToString())[0];
			Commom.smethod_27(dgvDSBaiViet, dataGridViewRow.Index, "cTieuDe", @class.String_0);
			Commom.smethod_27(dgvDSBaiViet, dataGridViewRow.Index, "cAnh", @class.String_1.Split('|').Length - 1);
			Commom.smethod_27(dgvDSBaiViet, dataGridViewRow.Index, "cVideo", @class.String_2.Split('|').Length - 1);
			method_0();
		}
		catch
		{
		}
	}

	private bool method_2(string string_0)
	{
		bool result = false;
		for (int i = 0; i < C094F807.Rows.Count; i++)
		{
			if (string_0 == C094F807.Rows[i].Cells[2].Value.ToString())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void AB37B5AB(object sender, DataGridViewCellEventArgs e)
	{
		int num = Convert.ToInt32(dgvDSBaiViet.SelectedRows[0].Cells[2].Value);
		List<Class65> list = CommonSQL.FD9ECF83(num.ToString());
		Class65 @class = new Class65();
		for (int i = 0; i < list.Count; i++)
		{
			if (method_2(num.ToString()))
			{
				break;
			}
			@class = list[i];
			C094F807.Rows.Add(C094F807.Rows.Count + 1, @class.DDAA0B14, @class.Int32_0, @class.String_0, @class.String_1.Split('|').Length - 1, @class.String_2.Split('|').Length - 1);
			list_0.Add(@class.Int32_0.ToString());
		}
		lblCountAcc.Text = C094F807.Rows.Count.ToString();
	}

	private void E5939087(object sender, EventArgs e)
	{
		try
		{
			int int_ = Convert.ToInt32(dgvDSBaiViet.SelectedRows[0].Cells[2].Value);
			fChiTietBaiViet fChiTietBaiViet2 = new fChiTietBaiViet(int_);
			fChiTietBaiViet2.Show();
		}
		catch
		{
		}
	}

	private void method_3()
	{
		for (int i = 0; i < C094F807.RowCount; i++)
		{
			Commom.smethod_27(C094F807, i, "cStt1", i + 1);
		}
	}

	private void DE2DF310(object sender, EventArgs e)
	{
		dgvDSBaiViet.Rows.Clear();
		List<Class65> list = CommonSQL.A4ACAC39(cbbChuDe.SelectedItem.ToString());
		Class65 @class = new Class65();
		for (int i = 0; i < list.Count; i++)
		{
			try
			{
				@class = list[i];
				dgvDSBaiViet.Rows.Add(i + 1, @class.DDAA0B14, @class.Int32_0, @class.String_0, @class.String_1.Split('|').Length - 1, @class.String_2.Split('|').Length - 1);
			}
			catch
			{
			}
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		C8AA8835(DAB10F11);
	}

	private void method_4(object sender, EventArgs e)
	{
	}

	private void CDAA4CB0_Click(object sender, EventArgs e)
	{
		DAB10F11 = true;
		dgvDSBaiViet.Rows.Clear();
		C8AA8835(DAB10F11);
	}

	private void method_5(object sender, EventArgs e)
	{
	}

	private void AEB987BC(object sender, DataGridViewCellEventArgs e)
	{
		foreach (DataGridViewRow selectedRow in C094F807.SelectedRows)
		{
			C094F807.Rows.RemoveAt(selectedRow.Index);
		}
		lblCountAcc.Text = C094F807.Rows.Count.ToString();
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		try
		{
			DataGridViewRow dataGridViewRow = dgvDSBaiViet.SelectedRows[0];
			if (dataGridViewRow != null && MsBoxHelper.D41C45AC("Bạn có muốn xóa bài viết này không?") == DialogResult.Yes)
			{
				int int_ = Convert.ToInt32(dataGridViewRow.Cells[2].Value);
				CommonSQL.A1131E3C(int_);
				dgvDSBaiViet.Rows.Remove(dataGridViewRow);
				method_0();
			}
		}
		catch
		{
		}
	}

	private void dgvDSBaiViet_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void EEA92F27(object sender, CancelEventArgs e)
	{
	}

	private void C094F807_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		method_3();
		lblCountAcc.Text = C094F807.Rows.Count.ToString();
	}

	private void C1128D2F(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		method_3();
		lblCountAcc.Text = C094F807.Rows.Count.ToString();
	}

	private void cbbChuDe_SelectedIndexChanged(object sender, EventArgs e)
	{
		DAB10F11 = false;
		C8AA8835(DAB10F11);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChonBaiViet));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		panel1 = new System.Windows.Forms.Panel();
		ADA6862D = new Bunifu.Framework.UI.BunifuCards();
		C9918CB3 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnMinimize = new System.Windows.Forms.Button();
		CAAFBC38 = new Bunifu.Framework.UI.BunifuCustomLabel();
		EA3FECA0 = new System.Windows.Forms.GroupBox();
		label3 = new System.Windows.Forms.Label();
		lblCountAcc = new System.Windows.Forms.Label();
		FA032034 = new System.Windows.Forms.Label();
		C094F807 = new System.Windows.Forms.DataGridView();
		D6246399 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		C517C111 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F3233994 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		E83FB908 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		C914D20E = new System.Windows.Forms.DataGridViewTextBoxColumn();
		groupBox1 = new System.Windows.Forms.GroupBox();
		FDAC381E = new System.Windows.Forms.Label();
		metroButton1 = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		cbbChuDe = new System.Windows.Forms.ComboBox();
		dgvDSBaiViet = new System.Windows.Forms.DataGridView();
		cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
		AE2FC4B4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		B3B4B400 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F62F78A5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cVideo = new System.Windows.Forms.DataGridViewTextBoxColumn();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		ED233FAF = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
		CDAA4CB0 = new System.Windows.Forms.ToolStripMenuItem();
		btnCancel = new System.Windows.Forms.Button();
		btnSave = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		panel1.SuspendLayout();
		ADA6862D.SuspendLayout();
		C9918CB3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		EA3FECA0.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)C094F807).BeginInit();
		groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvDSBaiViet).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(270, 47);
		bunifuCards1.TabIndex = 12;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(ADA6862D);
		panel1.Controls.Add(EA3FECA0);
		panel1.Controls.Add(groupBox1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnSave);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(927, 517);
		panel1.TabIndex = 37;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		ADA6862D.BackColor = System.Drawing.Color.White;
		ADA6862D.BorderRadius = 0;
		ADA6862D.BottomSahddow = true;
		ADA6862D.color = System.Drawing.Color.SaddleBrown;
		ADA6862D.Controls.Add(C9918CB3);
		ADA6862D.Dock = System.Windows.Forms.DockStyle.Top;
		ADA6862D.LeftSahddow = false;
		ADA6862D.Location = new System.Drawing.Point(0, 0);
		ADA6862D.Name = "bunifuCards2";
		ADA6862D.RightSahddow = true;
		ADA6862D.ShadowDepth = 20;
		ADA6862D.Size = new System.Drawing.Size(925, 37);
		ADA6862D.TabIndex = 43;
		C9918CB3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C9918CB3.BackColor = System.Drawing.Color.White;
		C9918CB3.Controls.Add(pictureBox1);
		C9918CB3.Controls.Add(btnMinimize);
		C9918CB3.Controls.Add(CAAFBC38);
		C9918CB3.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C9918CB3.Location = new System.Drawing.Point(0, 3);
		C9918CB3.Name = "pnlHeader";
		C9918CB3.Size = new System.Drawing.Size(925, 31);
		C9918CB3.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(0, 4);
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
		btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		btnMinimize.Location = new System.Drawing.Point(896, 3);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 9;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(btnCancel_Click);
		CAAFBC38.BackColor = System.Drawing.Color.Transparent;
		CAAFBC38.Cursor = System.Windows.Forms.Cursors.SizeAll;
		CAAFBC38.Dock = System.Windows.Forms.DockStyle.Fill;
		CAAFBC38.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CAAFBC38.ForeColor = System.Drawing.Color.Black;
		CAAFBC38.Location = new System.Drawing.Point(0, 0);
		CAAFBC38.Name = "bunifuCustomLabel1";
		CAAFBC38.Size = new System.Drawing.Size(925, 31);
		CAAFBC38.TabIndex = 12;
		CAAFBC38.Text = "Chọn bình luận";
		CAAFBC38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		EA3FECA0.BackColor = System.Drawing.Color.White;
		EA3FECA0.Controls.Add(label3);
		EA3FECA0.Controls.Add(lblCountAcc);
		EA3FECA0.Controls.Add(FA032034);
		EA3FECA0.Controls.Add(C094F807);
		EA3FECA0.Location = new System.Drawing.Point(465, 40);
		EA3FECA0.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
		EA3FECA0.Name = "groupBox2";
		EA3FECA0.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
		EA3FECA0.Size = new System.Drawing.Size(454, 423);
		EA3FECA0.TabIndex = 41;
		EA3FECA0.TabStop = false;
		EA3FECA0.Text = "Bình luận cần sử dụng";
		label3.AutoSize = true;
		label3.ForeColor = System.Drawing.Color.Red;
		label3.Location = new System.Drawing.Point(6, 401);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(166, 16);
		label3.TabIndex = 80;
		label3.Text = "(Click đúp vào dòng để xóa)";
		lblCountAcc.AutoSize = true;
		lblCountAcc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		lblCountAcc.ForeColor = System.Drawing.Color.Blue;
		lblCountAcc.Location = new System.Drawing.Point(349, 401);
		lblCountAcc.Name = "lblCountAcc";
		lblCountAcc.Size = new System.Drawing.Size(15, 16);
		lblCountAcc.TabIndex = 78;
		lblCountAcc.Text = "0";
		FA032034.AutoSize = true;
		FA032034.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		FA032034.Location = new System.Drawing.Point(307, 401);
		FA032034.Name = "label7";
		FA032034.Size = new System.Drawing.Size(43, 16);
		FA032034.TabIndex = 79;
		FA032034.Text = "Tổng:";
		C094F807.AllowUserToAddRows = false;
		C094F807.AllowUserToDeleteRows = false;
		C094F807.AllowUserToResizeRows = false;
		C094F807.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		C094F807.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		C094F807.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		C094F807.Columns.AddRange(D6246399, dataGridViewTextBoxColumn2, C517C111, F3233994, E83FB908, C914D20E);
		C094F807.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		C094F807.Location = new System.Drawing.Point(6, 52);
		C094F807.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		C094F807.MultiSelect = false;
		C094F807.Name = "dgvBaiVietDaChon";
		C094F807.RowHeadersVisible = false;
		C094F807.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		C094F807.Size = new System.Drawing.Size(444, 345);
		C094F807.TabIndex = 76;
		C094F807.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(AEB987BC);
		C094F807.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(C094F807_RowsAdded);
		C094F807.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(C1128D2F);
		D6246399.HeaderText = "STT";
		D6246399.Name = "cStt1";
		D6246399.Width = 35;
		dataGridViewTextBoxColumn2.HeaderText = "Chủ đề";
		dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
		C517C111.HeaderText = "ID Bài viết";
		C517C111.Name = "cId";
		C517C111.Visible = false;
		C517C111.Width = 90;
		F3233994.HeaderText = "Tiêu đề";
		F3233994.Name = "dataGridViewTextBoxColumn4";
		F3233994.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		F3233994.Width = 230;
		E83FB908.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		E83FB908.HeaderText = "Ảnh";
		E83FB908.Name = "dataGridViewTextBoxColumn5";
		C914D20E.HeaderText = "Video";
		C914D20E.Name = "Column1";
		C914D20E.Visible = false;
		C914D20E.Width = 50;
		groupBox1.BackColor = System.Drawing.Color.White;
		groupBox1.Controls.Add(FDAC381E);
		groupBox1.Controls.Add(metroButton1);
		groupBox1.Controls.Add(label1);
		groupBox1.Controls.Add(cbbChuDe);
		groupBox1.Controls.Add(dgvDSBaiViet);
		groupBox1.Location = new System.Drawing.Point(3, 39);
		groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
		groupBox1.Name = "groupBox1";
		groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
		groupBox1.Size = new System.Drawing.Size(456, 423);
		groupBox1.TabIndex = 42;
		groupBox1.TabStop = false;
		groupBox1.Text = "Danh sách bình luận";
		FDAC381E.AutoSize = true;
		FDAC381E.ForeColor = System.Drawing.Color.Red;
		FDAC381E.Location = new System.Drawing.Point(7, 401);
		FDAC381E.Name = "label2";
		FDAC381E.Size = new System.Drawing.Size(173, 16);
		FDAC381E.TabIndex = 80;
		FDAC381E.Text = "(Click đúp vào dòng để chọn)";
		metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton1.Location = new System.Drawing.Point(341, 23);
		metroButton1.Name = "metroButton1";
		metroButton1.Size = new System.Drawing.Size(109, 25);
		metroButton1.TabIndex = 79;
		metroButton1.Text = "Quản lý chủ đề";
		metroButton1.Click += new System.EventHandler(A4B3B08C);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(8, 27);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(52, 16);
		label1.TabIndex = 78;
		label1.Text = "Chủ đề:";
		cbbChuDe.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbChuDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbChuDe.FormattingEnabled = true;
		cbbChuDe.Location = new System.Drawing.Point(64, 23);
		cbbChuDe.Name = "cbbChuDe";
		cbbChuDe.Size = new System.Drawing.Size(271, 24);
		cbbChuDe.TabIndex = 77;
		cbbChuDe.SelectedIndexChanged += new System.EventHandler(cbbChuDe_SelectedIndexChanged);
		dgvDSBaiViet.AllowUserToAddRows = false;
		dgvDSBaiViet.AllowUserToDeleteRows = false;
		dgvDSBaiViet.AllowUserToResizeRows = false;
		dgvDSBaiViet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dgvDSBaiViet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgvDSBaiViet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvDSBaiViet.Columns.AddRange(cStt, AE2FC4B4, B3B4B400, F62F78A5, cAnh, cVideo);
		dgvDSBaiViet.ContextMenuStrip = contextMenuStrip1;
		dgvDSBaiViet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		dgvDSBaiViet.Location = new System.Drawing.Point(10, 54);
		dgvDSBaiViet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		dgvDSBaiViet.MultiSelect = false;
		dgvDSBaiViet.Name = "dgvDSBaiViet";
		dgvDSBaiViet.RowHeadersVisible = false;
		dgvDSBaiViet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dgvDSBaiViet.Size = new System.Drawing.Size(440, 343);
		dgvDSBaiViet.TabIndex = 76;
		dgvDSBaiViet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvDSBaiViet_CellContentClick);
		dgvDSBaiViet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(AB37B5AB);
		cStt.HeaderText = "STT";
		cStt.Name = "cStt";
		cStt.Width = 35;
		AE2FC4B4.HeaderText = "Chủ đề";
		AE2FC4B4.Name = "cChuDe";
		B3B4B400.HeaderText = "ID Bài viết";
		B3B4B400.Name = "cIdBaiViet";
		B3B4B400.Visible = false;
		B3B4B400.Width = 90;
		F62F78A5.HeaderText = "Tiêu đề";
		F62F78A5.Name = "cTieuDe";
		F62F78A5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		F62F78A5.Width = 230;
		cAnh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		cAnh.HeaderText = "Ảnh";
		cAnh.Name = "cAnh";
		cVideo.HeaderText = "Video";
		cVideo.Name = "cVideo";
		cVideo.Visible = false;
		cVideo.Width = 50;
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { toolStripMenuItem_0, toolStripMenuItem_1, toolStripMenuItem_2, ED233FAF, toolStripMenuItem_3, CDAA4CB0 });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(202, 136);
		contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(EEA92F27);
		toolStripMenuItem_0.Name = "thêmBàiViếtToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(201, 22);
		toolStripMenuItem_0.Text = "Thêm bình luận";
		toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
		toolStripMenuItem_1.Name = "sửaBàiViếtToolStripMenuItem";
		toolStripMenuItem_1.Size = new System.Drawing.Size(201, 22);
		toolStripMenuItem_1.Text = "Sửa bình luận";
		toolStripMenuItem_1.Click += new System.EventHandler(FFB2F8B8);
		toolStripMenuItem_2.Name = "xóaBàiViếtToolStripMenuItem";
		toolStripMenuItem_2.Size = new System.Drawing.Size(201, 22);
		toolStripMenuItem_2.Text = "Xóa bình luận";
		toolStripMenuItem_2.Click += new System.EventHandler(toolStripMenuItem_2_Click);
		ED233FAF.Name = "chiTiếtBàiViếtToolStripMenuItem";
		ED233FAF.Size = new System.Drawing.Size(201, 22);
		ED233FAF.Text = "Chi tiết bình luận";
		ED233FAF.Click += new System.EventHandler(E5939087);
		toolStripMenuItem_3.Name = "làmMớiDanhSáchToolStripMenuItem";
		toolStripMenuItem_3.Size = new System.Drawing.Size(201, 22);
		toolStripMenuItem_3.Text = "Làm mới danh sách";
		toolStripMenuItem_3.Click += new System.EventHandler(toolStripMenuItem_3_Click);
		CDAA4CB0.Name = "hiểnThịTấtCảBàiViếtToolStripMenuItem";
		CDAA4CB0.Size = new System.Drawing.Size(201, 22);
		CDAA4CB0.Text = "Hiển thị tất cả bình luận";
		CDAA4CB0.Click += new System.EventHandler(CDAA4CB0_Click);
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(468, 473);
		btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 20;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSave.ForeColor = System.Drawing.Color.White;
		btnSave.Location = new System.Drawing.Point(361, 473);
		btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(92, 29);
		btnSave.TabIndex = 19;
		btnSave.Text = "Lưu";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += new System.EventHandler(btnSave_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = CAAFBC38;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(927, 517);
		base.Controls.Add(panel1);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fChonBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(E08A9D81);
		panel1.ResumeLayout(false);
		ADA6862D.ResumeLayout(false);
		C9918CB3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		EA3FECA0.ResumeLayout(false);
		EA3FECA0.PerformLayout();
		((System.ComponentModel.ISupportInitialize)C094F807).EndInit();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgvDSBaiViet).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
