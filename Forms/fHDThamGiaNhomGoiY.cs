using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDThamGiaNhomGoiY : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool C3817686;

	internal IContainer DD2F052D = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown D5B48916;

	internal TextBox txtTenHanhDong;

	internal Label label3;

	internal Label label1;

	internal Button B2A1BE31;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel A3BDBB86;

	internal Button F9B1E8BB;

	internal PictureBox B380A096;

	internal BunifuCustomLabel EFA29705;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal CheckBox ckbTuDongTraLoiCauHoi;

	internal Panel plTuDongTraLoiCauHoi;

	internal ComboBox F80E0C2E;

	internal Label label8;

	internal RichTextBox txtCauTraLoi;

	internal Label E412CC2C;

	internal Label label2;

	internal Label label9;

	public static bool AB2558B2
	{
		[CompilerGenerated]
		get
		{
			return C3817686;
		}
		[CompilerGenerated]
		set
		{
			C3817686 = value;
		}
	}

	public fHDThamGiaNhomGoiY(string string_3, string string_4 = "")
	{
		InitializeComponent();
		AB2558B2 = false;
		string_0 = string_3;
		string_2 = string_4;
		string aA239C = Language.GetValue(EFA29705.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_4 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_4);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to close dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void D793053D(object sender, EventArgs e)
	{
		try
		{
			D5B48916.Value = gclass4_0.method_2("nudSoLuongFrom", 3);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 5);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			ckbTuDongTraLoiCauHoi.Checked = gclass4_0.method_3("ckbTuDongTraLoiCauHoi");
			txtCauTraLoi.Text = gclass4_0.BDB80B23("txtCauTraLoi");
		}
		catch
		{
		}
		D58BC881();
	}

	private void D58BC881()
	{
		ckbTuDongTraLoiCauHoi_CheckedChanged(null, null);
	}

	private void F9B1E8BB_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void E080058B(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		if (ckbTuDongTraLoiCauHoi.Checked)
		{
			List<string> list_ = txtCauTraLoi.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			if (list_.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách câu trả lời!", 3);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", D5B48916.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbTuDongTraLoiCauHoi", ckbTuDongTraLoiCauHoi.Checked);
		gClass.method_4("txtCauTraLoi", txtCauTraLoi.Text.Trim());
		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					AB2558B2 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(string_2, text, e013A))
			{
				AB2558B2 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void B2A1BE31_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void ckbTuDongTraLoiCauHoi_CheckedChanged(object sender, EventArgs e)
	{
		plTuDongTraLoiCauHoi.Enabled = ckbTuDongTraLoiCauHoi.Checked;
	}

	private void txtCauTraLoi_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtCauTraLoi, E412CC2C);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && DD2F052D != null)
		{
			DD2F052D.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		DD2F052D = new System.ComponentModel.Container();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(DD2F052D);
		EFA29705 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(DD2F052D);
		A3BDBB86 = new System.Windows.Forms.Panel();
		F9B1E8BB = new System.Windows.Forms.Button();
		B380A096 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		plTuDongTraLoiCauHoi = new System.Windows.Forms.Panel();
		F80E0C2E = new System.Windows.Forms.ComboBox();
		label8 = new System.Windows.Forms.Label();
		txtCauTraLoi = new System.Windows.Forms.RichTextBox();
		E412CC2C = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		ckbTuDongTraLoiCauHoi = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		D5B48916 = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		B2A1BE31 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A3BDBB86.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B380A096).BeginInit();
		panel1.SuspendLayout();
		plTuDongTraLoiCauHoi.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)D5B48916).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = EFA29705;
		bunifuDragControl_0.Vertical = true;
		EFA29705.BackColor = System.Drawing.Color.Transparent;
		EFA29705.Cursor = System.Windows.Forms.Cursors.SizeAll;
		EFA29705.Dock = System.Windows.Forms.DockStyle.Fill;
		EFA29705.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EFA29705.ForeColor = System.Drawing.Color.Black;
		EFA29705.Location = new System.Drawing.Point(0, 0);
		EFA29705.Name = "bunifuCustomLabel1";
		EFA29705.Size = new System.Drawing.Size(317, 31);
		EFA29705.TabIndex = 12;
		EFA29705.Text = "Cấu hình Tham gia nhóm gợi ý";
		EFA29705.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = A3BDBB86;
		bunifuDragControl_1.Vertical = true;
		A3BDBB86.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A3BDBB86.BackColor = System.Drawing.Color.White;
		A3BDBB86.Controls.Add(F9B1E8BB);
		A3BDBB86.Controls.Add(B380A096);
		A3BDBB86.Controls.Add(EFA29705);
		A3BDBB86.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A3BDBB86.Location = new System.Drawing.Point(0, 3);
		A3BDBB86.Name = "pnlHeader";
		A3BDBB86.Size = new System.Drawing.Size(317, 31);
		A3BDBB86.TabIndex = 9;
		F9B1E8BB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F9B1E8BB.Cursor = System.Windows.Forms.Cursors.Hand;
		F9B1E8BB.FlatAppearance.BorderSize = 0;
		F9B1E8BB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F9B1E8BB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F9B1E8BB.ForeColor = System.Drawing.Color.White;
		F9B1E8BB.Image = Class155.Bitmap_15;
		F9B1E8BB.Location = new System.Drawing.Point(286, 1);
		F9B1E8BB.Name = "button1";
		F9B1E8BB.Size = new System.Drawing.Size(30, 30);
		F9B1E8BB.TabIndex = 77;
		F9B1E8BB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		F9B1E8BB.UseVisualStyleBackColor = true;
		F9B1E8BB.Click += new System.EventHandler(F9B1E8BB_Click);
		System.Drawing.Image iconClose_fHDTh = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDTh != null) F9B1E8BB.Image = iconClose_fHDTh;
		B380A096.Cursor = System.Windows.Forms.Cursors.Default;
		B380A096.Image = Class155.DD225F0D;
		B380A096.Location = new System.Drawing.Point(3, 2);
		B380A096.Name = "pictureBox1";
		B380A096.Size = new System.Drawing.Size(34, 27);
		B380A096.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		B380A096.TabIndex = 76;
		B380A096.TabStop = false;
		System.Drawing.Image iconApp_fHDTh = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDTh != null) B380A096.Image = iconApp_fHDTh;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(plTuDongTraLoiCauHoi);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(ckbTuDongTraLoiCauHoi);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(D5B48916);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(B2A1BE31);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(320, 370);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 33;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		plTuDongTraLoiCauHoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuDongTraLoiCauHoi.Controls.Add(F80E0C2E);
		plTuDongTraLoiCauHoi.Controls.Add(label8);
		plTuDongTraLoiCauHoi.Controls.Add(txtCauTraLoi);
		plTuDongTraLoiCauHoi.Controls.Add(E412CC2C);
		plTuDongTraLoiCauHoi.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		plTuDongTraLoiCauHoi.Location = new System.Drawing.Point(51, 158);
		plTuDongTraLoiCauHoi.Name = "plTuDongTraLoiCauHoi";
		plTuDongTraLoiCauHoi.Size = new System.Drawing.Size(234, 155);
		plTuDongTraLoiCauHoi.TabIndex = 117;
		F80E0C2E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F80E0C2E.Cursor = System.Windows.Forms.Cursors.Hand;
		F80E0C2E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F80E0C2E.FormattingEnabled = true;
		F80E0C2E.Location = new System.Drawing.Point(73, 159);
		F80E0C2E.Name = "cbbCauTraLoi";
		F80E0C2E.Size = new System.Drawing.Size(154, 24);
		F80E0C2E.TabIndex = 4;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(3, 152);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 3;
		label8.Text = "Tùy chọn:";
		txtCauTraLoi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtCauTraLoi.Location = new System.Drawing.Point(4, 22);
		txtCauTraLoi.Name = "txtCauTraLoi";
		txtCauTraLoi.Size = new System.Drawing.Size(225, 128);
		txtCauTraLoi.TabIndex = 2;
		txtCauTraLoi.Text = "";
		txtCauTraLoi.TextChanged += new System.EventHandler(txtCauTraLoi_TextChanged);
		E412CC2C.AutoSize = true;
		E412CC2C.Location = new System.Drawing.Point(1, 3);
		E412CC2C.Name = "lblCauTraLoi";
		E412CC2C.Size = new System.Drawing.Size(153, 16);
		E412CC2C.TabIndex = 0;
		E412CC2C.Text = "Danh sách câu trả lời (0):";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 34;
		label9.Text = "Sô\u0301 lươ\u0323ng:";
		ckbTuDongTraLoiCauHoi.AutoSize = true;
		ckbTuDongTraLoiCauHoi.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongTraLoiCauHoi.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbTuDongTraLoiCauHoi.Location = new System.Drawing.Point(30, 136);
		ckbTuDongTraLoiCauHoi.Name = "ckbTuDongTraLoiCauHoi";
		ckbTuDongTraLoiCauHoi.Size = new System.Drawing.Size(156, 20);
		ckbTuDongTraLoiCauHoi.TabIndex = 115;
		ckbTuDongTraLoiCauHoi.Text = "Tự động trả lời câu hỏi";
		ckbTuDongTraLoiCauHoi.UseVisualStyleBackColor = true;
		ckbTuDongTraLoiCauHoi.CheckedChanged += new System.EventHandler(ckbTuDongTraLoiCauHoi_CheckedChanged);
		nudDelayTo.Location = new System.Drawing.Point(229, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(194, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongTo.Location = new System.Drawing.Point(229, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		D5B48916.Location = new System.Drawing.Point(132, 78);
		D5B48916.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		D5B48916.Name = "nudSoLuongFrom";
		D5B48916.Size = new System.Drawing.Size(56, 23);
		D5B48916.TabIndex = 1;
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		B2A1BE31.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B2A1BE31.BackColor = System.Drawing.Color.Maroon;
		B2A1BE31.Cursor = System.Windows.Forms.Cursors.Hand;
		B2A1BE31.FlatAppearance.BorderSize = 0;
		B2A1BE31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B2A1BE31.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B2A1BE31.ForeColor = System.Drawing.Color.White;
		B2A1BE31.Location = new System.Drawing.Point(170, 327);
		B2A1BE31.Name = "btnCancel";
		B2A1BE31.Size = new System.Drawing.Size(92, 29);
		B2A1BE31.TabIndex = 7;
		B2A1BE31.Text = "Đóng";
		B2A1BE31.UseVisualStyleBackColor = false;
		B2A1BE31.Click += new System.EventHandler(B2A1BE31_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(63, 327);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(E080058B);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(A3BDBB86);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(317, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(320, 370);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDThamGiaNhomGoiY";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = " ";
		base.Load += new System.EventHandler(D793053D);
		A3BDBB86.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)B380A096).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plTuDongTraLoiCauHoi.ResumeLayout(false);
		plTuDongTraLoiCauHoi.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)D5B48916).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
