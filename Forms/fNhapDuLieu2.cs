using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fNhapDuLieu2 : Form
{
	internal string F4A7A335 = "";

	internal Random random_0 = new Random();

	internal bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel F8301B26;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuCards EB0E3FB4;

	internal Panel pnlHeader;

	internal Button E2A62B05;

	internal PictureBox D89B5297;

	internal Button D0BBFAB1;

	internal BunifuCustomLabel lblTitle;

	internal Button btnSave;

	internal TextBox B329F499;

	internal GroupBox C1A16AA3;

	internal GroupBox groupBox2;

	internal DataGridView FAA4FE26;

	internal Button btnAdd;

	internal DataGridViewTextBoxColumn cSTT;

	internal DataGridViewTextBoxColumn E1B13C26;

	internal DataGridViewButtonColumn cChiTiet;

	internal DataGridViewButtonColumn DC871612;

	internal DataGridViewButtonColumn B524C3AB;

	internal Button btnHuy;

	public fNhapDuLieu2(string string_0, string E32AE38E)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		F4A7A335 = string_0;
		lblTitle.Text = E32AE38E;
	}

	private void fNhapDuLieu2_Load(object sender, EventArgs e)
	{
		Commom.CreateFolder(F4A7A335);
		D682B28C(F4A7A335);
	}

	private void E826E901(int D4154F15)
	{
		B329F499.Lines = File.ReadAllLines(EAB09F19.E2A1ED2F(FAA4FE26, D4154F15, "cName"));
	}

	private void D682B28C(string string_0)
	{
		int num = -1;
		switch (FAA4FE26.RowCount)
		{
		default:
			num = FAA4FE26.SelectedRows[0].Index;
			break;
		case 1:
			num = 0;
			break;
		case 0:
			break;
		}
		FAA4FE26.Rows.Clear();
		List<string> list = Commom.smethod_76(string_0);
		for (int i = 0; i < list.Count; i++)
		{
			FAA4FE26.Rows.Add(i + 1, list[i], Language.GetValue("Chi tiê\u0301t"), Language.GetValue("Sư\u0309a"), Language.GetValue("Xo\u0301a"));
		}
		if (num == -1 && FAA4FE26.RowCount > 0)
		{
			num = 0;
		}
		else if (num + 1 > FAA4FE26.RowCount)
		{
			num = FAA4FE26.RowCount - 1;
		}
		if (num == -1)
		{
			B329F499.Text = "";
			return;
		}
		Commom.A2090DB2(FAA4FE26);
		FAA4FE26.Rows[num].Selected = true;
		E826E901(num);
	}

	private void B0235511(object sender, PaintEventArgs e)
	{
	}

	private void E2A62B05_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D4191517(int int_0)
	{
		if (int_0 == 1)
		{
			FAA4FE26.Enabled = false;
			btnAdd.Enabled = false;
			btnSave.Enabled = true;
			btnHuy.Enabled = true;
			B329F499.ReadOnly = false;
			B329F499.Focus();
		}
		else
		{
			FAA4FE26.Enabled = true;
			btnAdd.Enabled = true;
			btnSave.Enabled = false;
			btnHuy.Enabled = false;
			B329F499.ReadOnly = true;
		}
	}

	private void B22BE1BF(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string text2;
			do
			{
				text2 = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_") + Commom.B820DC86(3, "a") + ".txt";
			}
			while (File.Exists(text2));
			text = F4A7A335 + "\\" + text2;
			Commom.EF994A31(text);
			B329F499.Lines = File.ReadAllLines(text);
			FAA4FE26.Rows.Add(FAA4FE26.RowCount + 1, text, Language.GetValue("Chi tiê\u0301t"), Language.GetValue("Sư\u0309a"), Language.GetValue("Xo\u0301a"));
			Commom.A2090DB2(FAA4FE26);
			FAA4FE26.Rows[FAA4FE26.RowCount - 1].Selected = true;
			D4191517(1);
			bool_0 = true;
		}
		catch
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void B329F499_TextChanged(object sender, EventArgs e)
	{
	}

	private void FAA4FE26_MouseHover(object sender, EventArgs e)
	{
	}

	private void FAA4FE26_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		string name = FAA4FE26.Columns[e.ColumnIndex].Name;
		if (name != "cChiTiet" && name != "cSua" && name != "cXoa")
		{
			FAA4FE26.Cursor = Cursors.Default;
		}
		else if (e.RowIndex < FAA4FE26.RowCount)
		{
			FAA4FE26.Cursor = Cursors.Hand;
		}
	}

	private void C8963F86(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		if (!(dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0)
		{
			return;
		}
		switch (dataGridView.Columns[e.ColumnIndex].Name)
		{
		case "cXoa":
			if (MsBoxHelper.D41C45AC("Bạn có muốn xóa?") == DialogResult.Yes)
			{
				File.Delete(EAB09F19.E2A1ED2F(FAA4FE26, e.RowIndex, "cName"));
				D682B28C(F4A7A335);
			}
			break;
		case "cSua":
			B329F499.Lines = File.ReadAllLines(EAB09F19.E2A1ED2F(FAA4FE26, e.RowIndex, "cName"));
			bool_0 = false;
			D4191517(1);
			break;
		case "cChiTiet":
			E826E901(e.RowIndex);
			break;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			string text = FAA4FE26.SelectedRows[0].Cells["cName"].Value.ToString();
			Commom.EF994A31(text);
			if (B329F499.Text.Trim() == "")
			{
				MsBoxHelper.Show("Vui lòng nhập nội dung cần lưu!", 3);
			}
			else if (MsBoxHelper.D41C45AC("Bạn có muốn lưu lại?") == DialogResult.Yes)
			{
				File.WriteAllLines(text, B329F499.Lines);
				MsBoxHelper.Show("Lưu thành công!");
				D4191517(2);
			}
		}
		catch
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void F3815F39(object sender, EventArgs e)
	{
		try
		{
			string text = FAA4FE26.SelectedRows[0].Cells["cName"].Value.ToString();
			Commom.EF994A31(text);
			if (MsBoxHelper.D41C45AC("Bạn có muốn hủy?") == DialogResult.Yes)
			{
				if (bool_0)
				{
					File.Delete(text);
				}
				D4191517(2);
				D682B28C(F4A7A335);
			}
		}
		catch
		{
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
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
		F8301B26 = new System.Windows.Forms.Panel();
		C1A16AA3 = new System.Windows.Forms.GroupBox();
		FAA4FE26 = new System.Windows.Forms.DataGridView();
		cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
		E1B13C26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
		DC871612 = new System.Windows.Forms.DataGridViewButtonColumn();
		B524C3AB = new System.Windows.Forms.DataGridViewButtonColumn();
		btnAdd = new System.Windows.Forms.Button();
		groupBox2 = new System.Windows.Forms.GroupBox();
		B329F499 = new System.Windows.Forms.TextBox();
		btnHuy = new System.Windows.Forms.Button();
		btnSave = new System.Windows.Forms.Button();
		EB0E3FB4 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		E2A62B05 = new System.Windows.Forms.Button();
		D89B5297 = new System.Windows.Forms.PictureBox();
		D0BBFAB1 = new System.Windows.Forms.Button();
		lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		F8301B26.SuspendLayout();
		C1A16AA3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FAA4FE26).BeginInit();
		groupBox2.SuspendLayout();
		EB0E3FB4.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D89B5297).BeginInit();
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
		bunifuCards1.Size = new System.Drawing.Size(425, 47);
		bunifuCards1.TabIndex = 12;
		F8301B26.BackColor = System.Drawing.Color.White;
		F8301B26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F8301B26.Controls.Add(C1A16AA3);
		F8301B26.Controls.Add(groupBox2);
		F8301B26.Controls.Add(EB0E3FB4);
		F8301B26.Dock = System.Windows.Forms.DockStyle.Fill;
		F8301B26.Location = new System.Drawing.Point(0, 0);
		F8301B26.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		F8301B26.Name = "panel1";
		F8301B26.Size = new System.Drawing.Size(754, 388);
		F8301B26.TabIndex = 37;
		F8301B26.Paint += new System.Windows.Forms.PaintEventHandler(B0235511);
		C1A16AA3.Controls.Add(FAA4FE26);
		C1A16AA3.Controls.Add(btnAdd);
		C1A16AA3.Location = new System.Drawing.Point(3, 43);
		C1A16AA3.Name = "groupBox1";
		C1A16AA3.Size = new System.Drawing.Size(284, 339);
		C1A16AA3.TabIndex = 50;
		C1A16AA3.TabStop = false;
		C1A16AA3.Text = " Danh sa\u0301ch nô\u0323i dung";
		FAA4FE26.AllowUserToAddRows = false;
		FAA4FE26.AllowUserToDeleteRows = false;
		FAA4FE26.AllowUserToResizeRows = false;
		FAA4FE26.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		FAA4FE26.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		FAA4FE26.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		FAA4FE26.Columns.AddRange(cSTT, E1B13C26, cChiTiet, DC871612, B524C3AB);
		FAA4FE26.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		FAA4FE26.Location = new System.Drawing.Point(6, 22);
		FAA4FE26.Name = "dtgvDanhSach";
		FAA4FE26.RowHeadersVisible = false;
		FAA4FE26.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		FAA4FE26.Size = new System.Drawing.Size(272, 277);
		FAA4FE26.TabIndex = 76;
		FAA4FE26.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(C8963F86);
		FAA4FE26.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(FAA4FE26_CellMouseEnter);
		FAA4FE26.MouseHover += new System.EventHandler(FAA4FE26_MouseHover);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		cSTT.DefaultCellStyle = dataGridViewCellStyle2;
		cSTT.HeaderText = "STT";
		cSTT.Name = "cSTT";
		cSTT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		cSTT.Width = 40;
		E1B13C26.HeaderText = "Tên file";
		E1B13C26.Name = "cName";
		E1B13C26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		E1B13C26.Visible = false;
		cChiTiet.HeaderText = "Chi tiê\u0301t";
		cChiTiet.Name = "cChiTiet";
		cChiTiet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		cChiTiet.Width = 80;
		DC871612.HeaderText = "Sư\u0309a";
		DC871612.Name = "cSua";
		DC871612.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		DC871612.Width = 71;
		B524C3AB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		B524C3AB.HeaderText = "Xo\u0301a";
		B524C3AB.Name = "cXoa";
		B524C3AB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		btnAdd.BackColor = System.Drawing.Color.Green;
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(186, 303);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 45;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(B22BE1BF);
		groupBox2.Controls.Add(B329F499);
		groupBox2.Controls.Add(btnHuy);
		groupBox2.Controls.Add(btnSave);
		groupBox2.Location = new System.Drawing.Point(293, 43);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(455, 339);
		groupBox2.TabIndex = 50;
		groupBox2.TabStop = false;
		groupBox2.Text = "Chi tiê\u0301t";
		B329F499.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B329F499.Location = new System.Drawing.Point(5, 22);
		B329F499.Multiline = true;
		B329F499.Name = "txtContent";
		B329F499.ReadOnly = true;
		B329F499.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		B329F499.Size = new System.Drawing.Size(444, 277);
		B329F499.TabIndex = 48;
		B329F499.WordWrap = false;
		B329F499.TextChanged += new System.EventHandler(B329F499_TextChanged);
		btnHuy.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
		btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuy.Enabled = false;
		btnHuy.FlatAppearance.BorderSize = 0;
		btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnHuy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuy.ForeColor = System.Drawing.Color.White;
		btnHuy.Location = new System.Drawing.Point(357, 304);
		btnHuy.Name = "btnHuy";
		btnHuy.Size = new System.Drawing.Size(92, 29);
		btnHuy.TabIndex = 45;
		btnHuy.Text = "Hủy";
		btnHuy.UseVisualStyleBackColor = false;
		btnHuy.Click += new System.EventHandler(F3815F39);
		btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSave.Enabled = false;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSave.ForeColor = System.Drawing.Color.White;
		btnSave.Location = new System.Drawing.Point(256, 304);
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(92, 29);
		btnSave.TabIndex = 45;
		btnSave.Text = "Lưu";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += new System.EventHandler(btnSave_Click);
		EB0E3FB4.BackColor = System.Drawing.Color.White;
		EB0E3FB4.BorderRadius = 0;
		EB0E3FB4.BottomSahddow = true;
		EB0E3FB4.color = System.Drawing.Color.SaddleBrown;
		EB0E3FB4.Controls.Add(pnlHeader);
		EB0E3FB4.Dock = System.Windows.Forms.DockStyle.Top;
		EB0E3FB4.LeftSahddow = false;
		EB0E3FB4.Location = new System.Drawing.Point(0, 0);
		EB0E3FB4.Name = "bunifuCards2";
		EB0E3FB4.RightSahddow = true;
		EB0E3FB4.ShadowDepth = 20;
		EB0E3FB4.Size = new System.Drawing.Size(752, 37);
		EB0E3FB4.TabIndex = 43;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(E2A62B05);
		pnlHeader.Controls.Add(D89B5297);
		pnlHeader.Controls.Add(D0BBFAB1);
		pnlHeader.Controls.Add(lblTitle);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(752, 31);
		pnlHeader.TabIndex = 9;
		E2A62B05.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E2A62B05.Cursor = System.Windows.Forms.Cursors.Hand;
		E2A62B05.FlatAppearance.BorderSize = 0;
		E2A62B05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E2A62B05.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E2A62B05.ForeColor = System.Drawing.Color.White;
		E2A62B05.Image = Class155.Bitmap_15;
		E2A62B05.Location = new System.Drawing.Point(721, 1);
		E2A62B05.Name = "button2";
		E2A62B05.Size = new System.Drawing.Size(30, 30);
		E2A62B05.TabIndex = 77;
		E2A62B05.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E2A62B05.UseVisualStyleBackColor = true;
		E2A62B05.Click += new System.EventHandler(E2A62B05_Click);
		D89B5297.Cursor = System.Windows.Forms.Cursors.Default;
		D89B5297.Image = Class155.DD225F0D;
		D89B5297.Location = new System.Drawing.Point(3, 2);
		D89B5297.Name = "pictureBox1";
		D89B5297.Size = new System.Drawing.Size(34, 27);
		D89B5297.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		D89B5297.TabIndex = 76;
		D89B5297.TabStop = false;
		D0BBFAB1.Cursor = System.Windows.Forms.Cursors.Hand;
		D0BBFAB1.FlatAppearance.BorderSize = 0;
		D0BBFAB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D0BBFAB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D0BBFAB1.ForeColor = System.Drawing.Color.White;
		D0BBFAB1.Location = new System.Drawing.Point(899, 1);
		D0BBFAB1.Name = "btnMinimize";
		D0BBFAB1.Size = new System.Drawing.Size(30, 30);
		D0BBFAB1.TabIndex = 9;
		D0BBFAB1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D0BBFAB1.UseVisualStyleBackColor = true;
		lblTitle.BackColor = System.Drawing.Color.Transparent;
		lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
		lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
		lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblTitle.ForeColor = System.Drawing.Color.Black;
		lblTitle.Location = new System.Drawing.Point(0, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new System.Drawing.Size(752, 31);
		lblTitle.TabIndex = 12;
		lblTitle.Text = "Nhập nội dung comment";
		lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = lblTitle;
		bunifuDragControl_0.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(754, 388);
		base.Controls.Add(F8301B26);
		base.Controls.Add(bunifuCards1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fNhapDuLieu2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(fNhapDuLieu2_Load);
		F8301B26.ResumeLayout(false);
		C1A16AA3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)FAA4FE26).EndInit();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		EB0E3FB4.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D89B5297).EndInit();
		ResumeLayout(false);
	}
}
