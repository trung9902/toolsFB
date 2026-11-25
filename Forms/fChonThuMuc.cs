using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fChonThuMuc : Form
{
	internal bool D6B8F692 = false;

	internal static List<string> list_0;

	internal static List<string> DA363022;

	internal static bool D3160788;

	internal IContainer C203ED0E = null;

	internal BunifuCards F9361613;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button EE90962F;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuDragControl C7AA569A;

	internal PictureBox AA8DED2B;

	internal Label label1;

	internal Label lblCountTotal;

	internal Label A404C20A;

	internal Label lblCountChoose;

	internal Label label2;

	internal DataGridView dtgvAcc;

	internal CheckBox checkBox1;

	internal DataGridViewCheckBoxColumn EE0847BA;

	internal DataGridViewTextBoxColumn C486DC1E;

	internal DataGridViewTextBoxColumn E78DECBD;

	internal DataGridViewTextBoxColumn C8AF5509;

	internal Button BAB5B389;

	internal Button D50986AC;

	public fChonThuMuc(bool EB086334 = false)
	{
		InitializeComponent();
		D3160788 = false;
		D6B8F692 = EB086334;
		Language.CD21F0A9(this);
	}

	private void EE90962F_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		D3160788 = true;
		if (D6B8F692)
		{
			DA363022 = new List<string>();
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					DA363022.Add(EAB09F19.E2A1ED2F(dtgvAcc, i, "cId"));
				}
			}
			if (DA363022.Count == 0)
			{
				MsBoxHelper.Show("Vui lòng chọn ít nhất 1 thư mục!", 2);
				return;
			}
		}
		else
		{
			list_0 = new List<string>();
			for (int j = 0; j < dtgvAcc.Rows.Count; j++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
				{
					list_0.Add(EAB09F19.E2A1ED2F(dtgvAcc, j, "cId"));
				}
			}
			if (list_0.Count == 0)
			{
				MsBoxHelper.Show("Vui lòng chọn ít nhất 1 thư mục!", 2);
				return;
			}
		}
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void fChonThuMuc_Load(object sender, EventArgs e)
	{
		if (D6B8F692)
		{
			if (DA363022 == null)
			{
				DA363022 = new List<string>();
			}
			method_0(DA363022);
		}
		else
		{
			if (list_0 == null)
			{
				list_0 = new List<string>();
			}
			method_0(list_0);
		}
	}

	private void method_0(List<string> list_1 = null)
	{
		try
		{
			DataTable dataTable = ((!D6B8F692) ? CommonSQL.smethod_1() : CommonSQL.smethod_1(bool_0: false, bool_1: true));
			if (list_1 != null && list_1.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (list_1.Contains(dataTable.Rows[i]["id"].ToString()))
					{
						dtgvAcc.Rows.Add(true, i + 1, dataTable.Rows[i]["id"], dataTable.Rows[i]["name"]);
					}
					else
					{
						dtgvAcc.Rows.Add(false, i + 1, dataTable.Rows[i]["id"], dataTable.Rows[i]["name"]);
					}
				}
			}
			else
			{
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					dtgvAcc.Rows.Add(false, j + 1, dataTable.Rows[j]["id"], dataTable.Rows[j]["name"]);
				}
			}
			method_1();
			F735812E();
			if (method_2() == dtgvAcc.RowCount)
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_58(exception_, "LoadListFiles");
			MsBoxHelper.Show("Có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void method_1()
	{
		try
		{
			lblCountChoose.Text = method_2().ToString();
		}
		catch
		{
		}
	}

	private void dtgvAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 0 && e.RowIndex > -1)
		{
			method_1();
			if (method_2() == dtgvAcc.RowCount)
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}
		}
	}

	private void F735812E()
	{
		try
		{
			lblCountTotal.Text = dtgvAcc.Rows.Count.ToString();
		}
		catch
		{
		}
	}

	private void dtgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value))
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = false;
			}
			else
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = true;
			}
		}
		catch
		{
		}
	}

	private int method_2()
	{
		int num = 0;
		for (int i = 0; i < dtgvAcc.Rows.Count; i++)
		{
			if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
			{
				num++;
			}
		}
		return num;
	}

	private void dtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex != 0 || e.RowIndex <= -1)
		{
			return;
		}
		try
		{
			if (Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value))
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = false;
			}
			else
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = true;
			}
		}
		catch
		{
		}
	}

	private void EA15CC13(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				EAB09F19.smethod_3(dtgvAcc, i, "cChose", true);
			}
		}
		else
		{
			for (int j = 0; j < dtgvAcc.Rows.Count; j++)
			{
				EAB09F19.smethod_3(dtgvAcc, j, "cChose", false);
			}
		}
	}

	private void D50986AC_Click(object sender, EventArgs e)
	{
		int index = dtgvAcc.SelectedRows[0].Index;
		if (index == 0)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(dtgvAcc, index - 1, "cId");
		string text2 = EAB09F19.E2A1ED2F(dtgvAcc, index, "cId");
		if (text + text2 != "")
		{
			if (CommonSQL.smethod_27(text, text2))
			{
				Commom.smethod_75(ref dtgvAcc, index, index - 1, 2);
				dtgvAcc.ClearSelection();
				dtgvAcc.Rows[index - 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void F2359535(object sender, EventArgs e)
	{
		int index = dtgvAcc.SelectedRows[0].Index;
		if (index == dtgvAcc.RowCount - 1)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(dtgvAcc, index + 1, "cId");
		string text2 = EAB09F19.E2A1ED2F(dtgvAcc, index, "cId");
		if (text + text2 != "")
		{
			if (CommonSQL.smethod_27(text, text2))
			{
				Commom.smethod_75(ref dtgvAcc, index, index + 1, 2);
				dtgvAcc.ClearSelection();
				dtgvAcc.Rows[index + 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void dtgvAcc_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyValue == 32)
		{
			for (int i = 0; i < dtgvAcc.SelectedRows.Count; i++)
			{
				int index = dtgvAcc.SelectedRows[i].Index;
				EAB09F19.smethod_3(dtgvAcc, index, "cChose", !Convert.ToBoolean(EAB09F19.E2A1ED2F(dtgvAcc, index, "cChose")));
			}
			method_2();
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && C203ED0E != null)
		{
			C203ED0E.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		C203ED0E = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChonThuMuc));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		F9361613 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		AA8DED2B = new System.Windows.Forms.PictureBox();
		EE90962F = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		C7AA569A = new Bunifu.Framework.UI.BunifuDragControl(C203ED0E);
		label1 = new System.Windows.Forms.Label();
		lblCountTotal = new System.Windows.Forms.Label();
		A404C20A = new System.Windows.Forms.Label();
		lblCountChoose = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		dtgvAcc = new System.Windows.Forms.DataGridView();
		EE0847BA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		C486DC1E = new System.Windows.Forms.DataGridViewTextBoxColumn();
		E78DECBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
		C8AF5509 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		checkBox1 = new System.Windows.Forms.CheckBox();
		BAB5B389 = new System.Windows.Forms.Button();
		D50986AC = new System.Windows.Forms.Button();
		F9361613.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AA8DED2B).BeginInit();
		((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
		SuspendLayout();
		F9361613.BackColor = System.Drawing.Color.White;
		F9361613.BorderRadius = 0;
		F9361613.BottomSahddow = true;
		F9361613.color = System.Drawing.Color.SaddleBrown;
		F9361613.Controls.Add(pnlHeader);
		F9361613.Dock = System.Windows.Forms.DockStyle.Top;
		F9361613.LeftSahddow = false;
		F9361613.Location = new System.Drawing.Point(0, 0);
		F9361613.Name = "bunifuCards1";
		F9361613.RightSahddow = true;
		F9361613.ShadowDepth = 20;
		F9361613.Size = new System.Drawing.Size(487, 34);
		F9361613.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(AA8DED2B);
		pnlHeader.Controls.Add(EE90962F);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(487, 28);
		pnlHeader.TabIndex = 9;
		AA8DED2B.Cursor = System.Windows.Forms.Cursors.Default;
		AA8DED2B.Image = Class155.DD225F0D;
		AA8DED2B.Location = new System.Drawing.Point(3, 2);
		AA8DED2B.Name = "pictureBox1";
		AA8DED2B.Size = new System.Drawing.Size(34, 27);
		AA8DED2B.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AA8DED2B.TabIndex = 17;
		AA8DED2B.TabStop = false;
		EE90962F.Cursor = System.Windows.Forms.Cursors.Hand;
		EE90962F.Dock = System.Windows.Forms.DockStyle.Right;
		EE90962F.FlatAppearance.BorderSize = 0;
		EE90962F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		EE90962F.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EE90962F.ForeColor = System.Drawing.Color.White;
		EE90962F.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		EE90962F.Location = new System.Drawing.Point(455, 0);
		EE90962F.Name = "btnMinimize";
		EE90962F.Size = new System.Drawing.Size(32, 28);
		EE90962F.TabIndex = 9;
		EE90962F.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		EE90962F.UseVisualStyleBackColor = true;
		EE90962F.Click += new System.EventHandler(EE90962F_Click);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(487, 28);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Chọn Danh sách thư mục";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(248, 374);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(144, 374);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		C7AA569A.Fixed = true;
		C7AA569A.Horizontal = true;
		C7AA569A.TargetControl = bunifuCustomLabel1;
		C7AA569A.Vertical = true;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(263, 346);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(58, 16);
		label1.TabIndex = 6;
		label1.Text = "Tổng số:";
		lblCountTotal.AutoSize = true;
		lblCountTotal.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblCountTotal.ForeColor = System.Drawing.Color.DarkRed;
		lblCountTotal.Location = new System.Drawing.Point(321, 347);
		lblCountTotal.Name = "lblCountTotal";
		lblCountTotal.Size = new System.Drawing.Size(14, 16);
		lblCountTotal.TabIndex = 6;
		lblCountTotal.Text = "0";
		A404C20A.AutoSize = true;
		A404C20A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A404C20A.Location = new System.Drawing.Point(128, 346);
		A404C20A.Name = "label3";
		A404C20A.Size = new System.Drawing.Size(59, 16);
		A404C20A.TabIndex = 6;
		A404C20A.Text = "Đã chọn:";
		lblCountChoose.AutoSize = true;
		lblCountChoose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblCountChoose.ForeColor = System.Drawing.Color.DarkGreen;
		lblCountChoose.Location = new System.Drawing.Point(186, 347);
		lblCountChoose.Name = "lblCountChoose";
		lblCountChoose.Size = new System.Drawing.Size(14, 16);
		lblCountChoose.TabIndex = 6;
		lblCountChoose.Text = "0";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.DarkRed;
		label2.Location = new System.Drawing.Point(12, 320);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(177, 16);
		label2.TabIndex = 6;
		label2.Text = "(Click đúp vào dòng để chọn!)";
		dtgvAcc.AllowUserToAddRows = false;
		dtgvAcc.AllowUserToDeleteRows = false;
		dtgvAcc.AllowUserToResizeRows = false;
		dtgvAcc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dtgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dtgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dtgvAcc.Columns.AddRange(EE0847BA, C486DC1E, E78DECBD, C8AF5509);
		dtgvAcc.Location = new System.Drawing.Point(15, 40);
		dtgvAcc.Name = "dtgvAcc";
		dtgvAcc.ReadOnly = true;
		dtgvAcc.RowHeadersVisible = false;
		dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dtgvAcc.Size = new System.Drawing.Size(415, 277);
		dtgvAcc.TabIndex = 7;
		dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellClick);
		dtgvAcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellDoubleClick);
		dtgvAcc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellValueChanged);
		dtgvAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(dtgvAcc_KeyDown);
		EE0847BA.HeaderText = "";
		EE0847BA.Name = "cChose";
		EE0847BA.ReadOnly = true;
		EE0847BA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		EE0847BA.Width = 30;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		C486DC1E.DefaultCellStyle = dataGridViewCellStyle2;
		C486DC1E.HeaderText = "STT";
		C486DC1E.Name = "cStt";
		C486DC1E.ReadOnly = true;
		C486DC1E.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		C486DC1E.Width = 35;
		E78DECBD.HeaderText = "Id";
		E78DECBD.Name = "cId";
		E78DECBD.ReadOnly = true;
		E78DECBD.Visible = false;
		E78DECBD.Width = 90;
		C8AF5509.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		C8AF5509.HeaderText = "Thư mục";
		C8AF5509.Name = "cThuMuc";
		C8AF5509.ReadOnly = true;
		checkBox1.AutoSize = true;
		checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		checkBox1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		checkBox1.Location = new System.Drawing.Point(25, 45);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(15, 14);
		checkBox1.TabIndex = 8;
		checkBox1.UseVisualStyleBackColor = true;
		checkBox1.Click += new System.EventHandler(EA15CC13);
		BAB5B389.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		BAB5B389.Cursor = System.Windows.Forms.Cursors.Hand;
		BAB5B389.Image = Class155.Bitmap_89;
		BAB5B389.Location = new System.Drawing.Point(436, 85);
		BAB5B389.Name = "button4";
		BAB5B389.Size = new System.Drawing.Size(41, 38);
		BAB5B389.TabIndex = 81;
		BAB5B389.UseVisualStyleBackColor = true;
		BAB5B389.Click += new System.EventHandler(F2359535);
		D50986AC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D50986AC.Cursor = System.Windows.Forms.Cursors.Hand;
		D50986AC.Image = Class155.Bitmap_155;
		D50986AC.Location = new System.Drawing.Point(436, 40);
		D50986AC.Name = "button5";
		D50986AC.Size = new System.Drawing.Size(41, 38);
		D50986AC.TabIndex = 82;
		D50986AC.UseVisualStyleBackColor = true;
		D50986AC.Click += new System.EventHandler(D50986AC_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(487, 415);
		base.Controls.Add(BAB5B389);
		base.Controls.Add(D50986AC);
		base.Controls.Add(checkBox1);
		base.Controls.Add(dtgvAcc);
		base.Controls.Add(lblCountChoose);
		base.Controls.Add(label2);
		base.Controls.Add(lblCountTotal);
		base.Controls.Add(A404C20A);
		base.Controls.Add(label1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnAdd);
		base.Controls.Add(F9361613);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fChonThuMuc";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fChonThuMuc_Load);
		F9361613.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AA8DED2B).EndInit();
		((System.ComponentModel.ISupportInitialize)dtgvAcc).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
