using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChonKichBan : Form
{
	internal IContainer A7AB44BF = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal GroupBox groupBox1;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel BE135813;

	internal Button button1;

	internal DataGridView F71DA698;

	internal Panel F2AB9F27;

	internal Button button2;

	internal Button button3;

	internal GroupBox B4BAD7B4;

	internal Label label2;

	internal Button btnCancel;

	internal Button EA323219;

	internal Label lblCountAcc;

	internal Label B19CD612;

	internal Label CFACE51B;

	internal DataGridView dtgvKichBanChoose;

	internal DataGridViewTextBoxColumn D7B1D631;

	internal DataGridViewTextBoxColumn F19B6E38;

	internal DataGridViewTextBoxColumn cTenKichBan;

	internal DataGridViewTextBoxColumn cSTTChoose;

	internal DataGridViewTextBoxColumn cIdKichBanChoose;

	internal DataGridViewTextBoxColumn CA0C9219;

	public fChonKichBan()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void B99EB2AC(object sender, EventArgs e)
	{
		method_0();
		method_0(C5034B95.smethod_0("configInteractGeneral").method_1("lstIdKichBan"));
	}

	private void method_0(List<string> list_0 = null)
	{
		try
		{
			if (list_0 != null && list_0.Count > 0)
			{
				dtgvKichBanChoose.Rows.Clear();
				for (int i = 0; i < list_0.Count; i++)
				{
					DataTable dataTable = Class154.smethod_1(list_0[i]);
					if (dataTable.Rows.Count > 0)
					{
						DataRow dataRow = dataTable.Rows[0];
						dtgvKichBanChoose.Rows.Add(dtgvKichBanChoose.RowCount + 1, dataRow["Id_KichBan"], dataRow["TenKichBan"]);
					}
				}
				return;
			}
			F71DA698.Rows.Clear();
			DataTable dataTable2 = Class154.smethod_2();
			if (dataTable2.Rows.Count > 0)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					DataRow dataRow2 = dataTable2.Rows[j];
					F71DA698.Rows.Add(j + 1, dataRow2["Id_KichBan"], dataRow2["TenKichBan"]);
				}
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	public void DAA361A4(ref DataGridView C7953304, int int_0, int int_1)
	{
		string text = "";
		for (int i = 1; i < C7953304.Columns.Count; i++)
		{
			text = EAB09F19.EC12300A(C7953304, int_0, i);
			EAB09F19.smethod_2(C7953304, int_0, i, EAB09F19.EC12300A(C7953304, int_1, i));
			EAB09F19.smethod_2(C7953304, int_1, i, text);
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		int index = dtgvKichBanChoose.SelectedRows[0].Index;
		if (index != 0)
		{
			string text = EAB09F19.E2A1ED2F(dtgvKichBanChoose, index - 1, "cIdKichBanChoose");
			string text2 = EAB09F19.E2A1ED2F(dtgvKichBanChoose, index, "cIdKichBanChoose");
			if (text + text2 != "")
			{
				DAA361A4(ref dtgvKichBanChoose, index, index - 1);
				dtgvKichBanChoose.Rows[index - 1].Selected = true;
			}
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		int index = dtgvKichBanChoose.SelectedRows[0].Index;
		if (index != dtgvKichBanChoose.RowCount - 1)
		{
			string text = EAB09F19.E2A1ED2F(dtgvKichBanChoose, index + 1, "cIdKichBanChoose");
			string text2 = EAB09F19.E2A1ED2F(dtgvKichBanChoose, index, "cIdKichBanChoose");
			if (text + text2 != "")
			{
				DAA361A4(ref dtgvKichBanChoose, index, index + 1);
				dtgvKichBanChoose.Rows[index + 1].Selected = true;
			}
		}
	}

	private void F2AB9F27_Paint(object sender, PaintEventArgs e)
	{
		if (F2AB9F27.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, F2AB9F27.ClientSize.Width - num, F2AB9F27.ClientSize.Height - num));
		}
	}

	private void D22A7697(object sender, EventArgs e)
	{
		Close();
	}

	private bool E3092E22(string string_0)
	{
		bool result = false;
		for (int i = 0; i < dtgvKichBanChoose.RowCount; i++)
		{
			if (string_0 == dtgvKichBanChoose.Rows[i].Cells[1].Value.ToString())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void F71DA698_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		int num = Convert.ToInt32(F71DA698.SelectedRows[0].Cells[1].Value);
		string text = F71DA698.SelectedRows[0].Cells[2].Value.ToString();
		if (!E3092E22(num.ToString()))
		{
			dtgvKichBanChoose.Rows.Add(dtgvKichBanChoose.RowCount + 1, num, text);
		}
	}

	private void E508482C(object sender, DataGridViewCellEventArgs e)
	{
		dtgvKichBanChoose.Rows.RemoveAt(dtgvKichBanChoose.SelectedRows[0].Index);
		for (int i = 0; i < dtgvKichBanChoose.RowCount; i++)
		{
			EAB09F19.smethod_3(dtgvKichBanChoose, i, "cSTTChoose", i + 1);
		}
	}

	private void AD914DBB(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i < dtgvKichBanChoose.RowCount; i++)
			{
				list.Add(EAB09F19.E2A1ED2F(dtgvKichBanChoose, i, "cIdKichBanChoose"));
			}
			C5034B95.smethod_0("configInteractGeneral").FD3CCF90("lstIdKichBan", list);
			C5034B95.smethod_1("configInteractGeneral");
			Close();
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", 3);
		}
	}

	private void dtgvKichBanChoose_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		lblCountAcc.Text = dtgvKichBanChoose.RowCount.ToString();
	}

	private void dtgvKichBanChoose_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		lblCountAcc.Text = dtgvKichBanChoose.RowCount.ToString();
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && A7AB44BF != null)
		{
			A7AB44BF.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		A7AB44BF = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChonKichBan));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(A7AB44BF);
		BE135813 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(A7AB44BF);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		groupBox1 = new System.Windows.Forms.GroupBox();
		label2 = new System.Windows.Forms.Label();
		F71DA698 = new System.Windows.Forms.DataGridView();
		D7B1D631 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F19B6E38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cTenKichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		F2AB9F27 = new System.Windows.Forms.Panel();
		btnCancel = new System.Windows.Forms.Button();
		EA323219 = new System.Windows.Forms.Button();
		B4BAD7B4 = new System.Windows.Forms.GroupBox();
		lblCountAcc = new System.Windows.Forms.Label();
		B19CD612 = new System.Windows.Forms.Label();
		CFACE51B = new System.Windows.Forms.Label();
		button3 = new System.Windows.Forms.Button();
		dtgvKichBanChoose = new System.Windows.Forms.DataGridView();
		cSTTChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cIdKichBanChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
		CA0C9219 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		button2 = new System.Windows.Forms.Button();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F71DA698).BeginInit();
		bunifuCards1.SuspendLayout();
		F2AB9F27.SuspendLayout();
		B4BAD7B4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dtgvKichBanChoose).BeginInit();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = BE135813;
		bunifuDragControl_0.Vertical = true;
		BE135813.BackColor = System.Drawing.Color.Transparent;
		BE135813.Cursor = System.Windows.Forms.Cursors.SizeAll;
		BE135813.Dock = System.Windows.Forms.DockStyle.Fill;
		BE135813.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BE135813.ForeColor = System.Drawing.Color.Black;
		BE135813.Location = new System.Drawing.Point(0, 0);
		BE135813.Name = "bunifuCustomLabel1";
		BE135813.Size = new System.Drawing.Size(696, 31);
		BE135813.TabIndex = 12;
		BE135813.Text = "Chọn danh sách kịch bản chạy";
		BE135813.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(BE135813);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(696, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(667, 2);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		groupBox1.BackColor = System.Drawing.Color.White;
		groupBox1.Controls.Add(label2);
		groupBox1.Controls.Add(F71DA698);
		groupBox1.Location = new System.Drawing.Point(12, 41);
		groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox1.Name = "groupBox1";
		groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox1.Size = new System.Drawing.Size(308, 302);
		groupBox1.TabIndex = 1;
		groupBox1.TabStop = false;
		groupBox1.Text = "Danh sách kịch bản";
		label2.AutoSize = true;
		label2.ForeColor = System.Drawing.Color.Red;
		label2.Location = new System.Drawing.Point(3, 281);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(192, 16);
		label2.TabIndex = 81;
		label2.Text = "(Click đúp vào kịch bản để chọn)";
		F71DA698.AllowUserToAddRows = false;
		F71DA698.AllowUserToDeleteRows = false;
		F71DA698.AllowUserToResizeRows = false;
		F71DA698.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		F71DA698.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		F71DA698.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		F71DA698.Columns.AddRange(D7B1D631, F19B6E38, cTenKichBan);
		F71DA698.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		F71DA698.Location = new System.Drawing.Point(6, 20);
		F71DA698.MultiSelect = false;
		F71DA698.Name = "dtgvKichBan";
		F71DA698.RowHeadersVisible = false;
		F71DA698.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		F71DA698.Size = new System.Drawing.Size(296, 258);
		F71DA698.TabIndex = 76;
		F71DA698.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(F71DA698_CellDoubleClick);
		D7B1D631.HeaderText = "STT";
		D7B1D631.Name = "cStt";
		D7B1D631.Width = 35;
		F19B6E38.HeaderText = "Id kịch bản";
		F19B6E38.Name = "cIdKichBan";
		F19B6E38.Visible = false;
		cTenKichBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		cTenKichBan.HeaderText = "Tên kịch bản";
		cTenKichBan.Name = "cTenKichBan";
		cTenKichBan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(699, 37);
		bunifuCards1.TabIndex = 12;
		F2AB9F27.BackColor = System.Drawing.Color.White;
		F2AB9F27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F2AB9F27.Controls.Add(btnCancel);
		F2AB9F27.Controls.Add(EA323219);
		F2AB9F27.Controls.Add(bunifuCards1);
		F2AB9F27.Controls.Add(B4BAD7B4);
		F2AB9F27.Dock = System.Windows.Forms.DockStyle.Fill;
		F2AB9F27.Location = new System.Drawing.Point(0, 0);
		F2AB9F27.Name = "panel1";
		F2AB9F27.Size = new System.Drawing.Size(702, 391);
		F2AB9F27.TabIndex = 13;
		F2AB9F27.Paint += new System.Windows.Forms.PaintEventHandler(F2AB9F27_Paint);
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(359, 350);
		btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 22;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(D22A7697);
		EA323219.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		EA323219.Cursor = System.Windows.Forms.Cursors.Hand;
		EA323219.FlatAppearance.BorderSize = 0;
		EA323219.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EA323219.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EA323219.ForeColor = System.Drawing.Color.White;
		EA323219.Location = new System.Drawing.Point(252, 350);
		EA323219.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		EA323219.Name = "btnSave";
		EA323219.Size = new System.Drawing.Size(92, 29);
		EA323219.TabIndex = 21;
		EA323219.Text = "Lưu";
		EA323219.UseVisualStyleBackColor = false;
		EA323219.Click += new System.EventHandler(AD914DBB);
		B4BAD7B4.BackColor = System.Drawing.Color.White;
		B4BAD7B4.Controls.Add(lblCountAcc);
		B4BAD7B4.Controls.Add(B19CD612);
		B4BAD7B4.Controls.Add(CFACE51B);
		B4BAD7B4.Controls.Add(button3);
		B4BAD7B4.Controls.Add(dtgvKichBanChoose);
		B4BAD7B4.Controls.Add(button2);
		B4BAD7B4.Location = new System.Drawing.Point(325, 40);
		B4BAD7B4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		B4BAD7B4.Name = "groupBox2";
		B4BAD7B4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		B4BAD7B4.Size = new System.Drawing.Size(363, 302);
		B4BAD7B4.TabIndex = 1;
		B4BAD7B4.TabStop = false;
		B4BAD7B4.Text = "Kịch bản cần chạy";
		lblCountAcc.AutoSize = true;
		lblCountAcc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		lblCountAcc.ForeColor = System.Drawing.Color.Blue;
		lblCountAcc.Location = new System.Drawing.Point(297, 281);
		lblCountAcc.Name = "lblCountAcc";
		lblCountAcc.Size = new System.Drawing.Size(15, 16);
		lblCountAcc.TabIndex = 82;
		lblCountAcc.Text = "0";
		B19CD612.AutoSize = true;
		B19CD612.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		B19CD612.Location = new System.Drawing.Point(255, 281);
		B19CD612.Name = "label7";
		B19CD612.Size = new System.Drawing.Size(43, 16);
		B19CD612.TabIndex = 83;
		B19CD612.Text = "Tổng:";
		CFACE51B.AutoSize = true;
		CFACE51B.ForeColor = System.Drawing.Color.Red;
		CFACE51B.Location = new System.Drawing.Point(4, 282);
		CFACE51B.Name = "label1";
		CFACE51B.Size = new System.Drawing.Size(185, 16);
		CFACE51B.TabIndex = 81;
		CFACE51B.Text = "(Click đúp vào kịch bản để xóa)";
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.Image = Class155.Bitmap_89;
		button3.Location = new System.Drawing.Point(314, 64);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(41, 38);
		button3.TabIndex = 78;
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(button3_Click);
		dtgvKichBanChoose.AllowUserToAddRows = false;
		dtgvKichBanChoose.AllowUserToDeleteRows = false;
		dtgvKichBanChoose.AllowUserToResizeRows = false;
		dtgvKichBanChoose.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dtgvKichBanChoose.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dtgvKichBanChoose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dtgvKichBanChoose.Columns.AddRange(cSTTChoose, cIdKichBanChoose, CA0C9219);
		dtgvKichBanChoose.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		dtgvKichBanChoose.Location = new System.Drawing.Point(6, 20);
		dtgvKichBanChoose.MultiSelect = false;
		dtgvKichBanChoose.Name = "dtgvKichBanChoose";
		dtgvKichBanChoose.RowHeadersVisible = false;
		dtgvKichBanChoose.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dtgvKichBanChoose.Size = new System.Drawing.Size(302, 258);
		dtgvKichBanChoose.TabIndex = 76;
		dtgvKichBanChoose.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(E508482C);
		dtgvKichBanChoose.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dtgvKichBanChoose_RowsAdded);
		dtgvKichBanChoose.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(dtgvKichBanChoose_RowsRemoved);
		cSTTChoose.HeaderText = "STT";
		cSTTChoose.Name = "cSTTChoose";
		cSTTChoose.Width = 35;
		cIdKichBanChoose.HeaderText = "Id kịch bản";
		cIdKichBanChoose.Name = "cIdKichBanChoose";
		cIdKichBanChoose.Visible = false;
		CA0C9219.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		CA0C9219.HeaderText = "Tên kịch bản";
		CA0C9219.Name = "cTenKichBanChoose";
		CA0C9219.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Image = Class155.Bitmap_155;
		button2.Location = new System.Drawing.Point(314, 19);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(41, 38);
		button2.TabIndex = 78;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(702, 391);
		base.Controls.Add(groupBox1);
		base.Controls.Add(F2AB9F27);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fChonKichBan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(B99EB2AC);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)F71DA698).EndInit();
		bunifuCards1.ResumeLayout(false);
		F2AB9F27.ResumeLayout(false);
		B4BAD7B4.ResumeLayout(false);
		B4BAD7B4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dtgvKichBanChoose).EndInit();
		ResumeLayout(false);
	}
}
