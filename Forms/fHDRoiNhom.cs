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

public class fHDRoiNhom : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 gclass4_0;

	internal string BE9758A9;

	internal string string_0;

	internal string C028E8B9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown C101371C;

	internal TextBox E1AAAE09;

	internal Label label3;

	internal Label AB141015;

	internal Label EB837FAC;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal Label label6;

	internal Label label9;

	internal Panel plUidChiDinh;

	internal Label C92E4D8B;

	internal Label lblTuKhoa;

	internal Panel plDieuKienTuKhoa;

	internal CheckBox ckbDieuKienTuKhoa;

	internal CheckBox ckbDieuKienThanhVien;

	internal NumericUpDown CB0A04A2;

	internal RichTextBox txtIDNhomGiuLai;

	internal Label lblIDNhomGiuLai;

	internal Panel panel2;

	internal Label E3B93F3A;

	internal Label label13;

	internal CheckBox C6994D0F;

	internal RichTextBox txtTuKhoa;

	internal RichTextBox ADACE6BC;

	internal ComboBox A5BBA737;

	internal Label label2;

	internal Label C4ACD91A;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public fHDRoiNhom(string BFB148BC, string string_1 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		BE9758A9 = BFB148BC;
		C028E8B9 = string_1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (string_1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			E1AAAE09.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_1);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			E1AAAE09.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_2, F79F9AB5: true);
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

	private void AC27F712(object sender, EventArgs e)
	{
		method_0();
		try
		{
			C101371C.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			A5BBA737.SelectedIndex = gclass4_0.method_2("typeRoiNhom");
			ckbDieuKienThanhVien.Checked = gclass4_0.method_3("ckbDieuKienThanhVien");
			CB0A04A2.Value = gclass4_0.method_2("nudThanhVienToiDa");
			ckbDieuKienTuKhoa.Checked = gclass4_0.method_3("ckbDieuKienTuKhoa");
			txtTuKhoa.Text = gclass4_0.BDB80B23("txtTuKhoa");
			txtIDNhomGiuLai.Text = gclass4_0.BDB80B23("txtIDNhomGiuLai");
			C6994D0F.Checked = gclass4_0.method_3("ckbDieuKienID");
			ADACE6BC.Text = gclass4_0.BDB80B23("txtIdNhomRoi");
		}
		catch
		{
		}
		method_1();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Ngẫu nhiên danh sách nhóm", "Rời nhóm kiểm duyệt bài viết", "Rời nhóm theo điều kiện" };
		Commom.smethod_23(A5BBA737, list_);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AB08B3AE(object sender, EventArgs e)
	{
		string text = E1AAAE09.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		if (A5BBA737.SelectedIndex == 2)
		{
			if (!ckbDieuKienThanhVien.Checked && !ckbDieuKienTuKhoa.Checked && !C6994D0F.Checked)
			{
				MsBoxHelper.Show("Vui lo\u0300ng cho\u0323n i\u0301t nhâ\u0301t mô\u0323t điê\u0300u kiê\u0323n rơ\u0300i nho\u0301m!", 3);
				return;
			}
			if (ckbDieuKienTuKhoa.Checked)
			{
				List<string> list_ = txtTuKhoa.Lines.ToList();
				list_ = Commom.smethod_36(list_);
				if (list_.Count == 0)
				{
					MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch tư\u0300 kho\u0301a!", 3);
					return;
				}
			}
			else if (C6994D0F.Checked)
			{
				List<string> list_2 = ADACE6BC.Lines.ToList();
				list_2 = Commom.smethod_36(list_2);
				if (list_2.Count == 0)
				{
					MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch nhóm cần rời!", 3);
					return;
				}
			}
		}
		gclass4_0.method_4("nudSoLuongFrom", C101371C.Value);
		gclass4_0.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gclass4_0.method_4("nudDelayFrom", nudDelayFrom.Value);
		gclass4_0.method_4("nudDelayTo", nudDelayTo.Value);
		gclass4_0.method_4("typeRoiNhom", A5BBA737.SelectedIndex);
		gclass4_0.method_4("ckbDieuKienThanhVien", ckbDieuKienThanhVien.Checked);
		gclass4_0.method_4("nudThanhVienToiDa", CB0A04A2.Value);
		gclass4_0.method_4("ckbDieuKienTuKhoa", ckbDieuKienTuKhoa.Checked);
		gclass4_0.method_4("txtTuKhoa", txtTuKhoa.Text.Trim());
		gclass4_0.method_4("txtIDNhomGiuLai", txtIDNhomGiuLai.Text);
		gclass4_0.method_4("ckbDieuKienID", C6994D0F.Checked);
		gclass4_0.method_4("txtIdNhomRoi", ADACE6BC.Text.Trim());
		string text2 = gclass4_0.ED11179C();
		if (C028E8B9 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(BE9758A9, text, string_0, text2))
				{
					Boolean_0 = true;
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
			if (Class154.smethod_13(C028E8B9, text, text2))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void FFA194AD(object sender, EventArgs e)
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

	private void method_1()
	{
		DD9AF588(null, null);
		ckbDieuKienTuKhoa_CheckedChanged(null, null);
		method_2(null, null);
		C6994D0F_CheckedChanged(null, null);
	}

	private void DD9AF588(object sender, EventArgs e)
	{
		CB0A04A2.Enabled = ckbDieuKienThanhVien.Checked;
	}

	private void ckbDieuKienTuKhoa_CheckedChanged(object sender, EventArgs e)
	{
		plDieuKienTuKhoa.Enabled = ckbDieuKienTuKhoa.Checked;
	}

	private void lblIDNhomGiuLai_Click(object sender, EventArgs e)
	{
	}

	private void B92C3E98(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIDNhomGiuLai, lblIDNhomGiuLai);
	}

	private void method_2(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = ADACE6BC.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			E3B93F3A.Text = string.Format(Language.GetValue("Danh sách ID nhóm ({0}):"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	private void C6994D0F_CheckedChanged(object sender, EventArgs e)
	{
		panel2.Enabled = C6994D0F.Checked;
	}

	private void txtTuKhoa_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTuKhoa, lblTuKhoa);
	}

	private void ADACE6BC_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(ADACE6BC, E3B93F3A);
	}

	private void A5BBA737_SelectedIndexChanged(object sender, EventArgs e)
	{
		plUidChiDinh.Enabled = A5BBA737.SelectedIndex == 2;
	}

	protected override void Dispose(bool CE15BD1D)
	{
		if (CE15BD1D && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(CE15BD1D);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDRoiNhom));
		pnlTopAccent = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		A5BBA737 = new System.Windows.Forms.ComboBox();
		txtIDNhomGiuLai = new System.Windows.Forms.RichTextBox();
		lblIDNhomGiuLai = new System.Windows.Forms.Label();
		plUidChiDinh = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		ADACE6BC = new System.Windows.Forms.RichTextBox();
		E3B93F3A = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		C6994D0F = new System.Windows.Forms.CheckBox();
		plDieuKienTuKhoa = new System.Windows.Forms.Panel();
		txtTuKhoa = new System.Windows.Forms.RichTextBox();
		lblTuKhoa = new System.Windows.Forms.Label();
		C92E4D8B = new System.Windows.Forms.Label();
		ckbDieuKienTuKhoa = new System.Windows.Forms.CheckBox();
		ckbDieuKienThanhVien = new System.Windows.Forms.CheckBox();
		CB0A04A2 = new System.Windows.Forms.NumericUpDown();
		label9 = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		C101371C = new System.Windows.Forms.NumericUpDown();
		E1AAAE09 = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		AB141015 = new System.Windows.Forms.Label();
		EB837FAC = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		C4ACD91A = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		plUidChiDinh.SuspendLayout();
		panel2.SuspendLayout();
		plDieuKienTuKhoa.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CB0A04A2).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)C101371C).BeginInit();
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
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(676, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Rơ\u0300i nho\u0301m";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(676, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(645, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		System.Drawing.Image iconClose_fHDRo = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDRo != null) button1.Image = iconClose_fHDRo;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDRo = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDRo != null) pictureBox1.Image = iconApp_fHDRo;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(C4ACD91A);
		panel1.Controls.Add(A5BBA737);
		panel1.Controls.Add(txtIDNhomGiuLai);
		panel1.Controls.Add(lblIDNhomGiuLai);
		panel1.Controls.Add(plUidChiDinh);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(C101371C);
		panel1.Controls.Add(E1AAAE09);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(AB141015);
		panel1.Controls.Add(EB837FAC);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(679, 575);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		A5BBA737.Cursor = System.Windows.Forms.Cursors.Hand;
		A5BBA737.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A5BBA737.FormattingEnabled = true;
		A5BBA737.Location = new System.Drawing.Point(420, 79);
		A5BBA737.Name = "cbbTypeRoiNhom";
		A5BBA737.Size = new System.Drawing.Size(229, 24);
		A5BBA737.TabIndex = 121;
		A5BBA737.SelectedIndexChanged += new System.EventHandler(A5BBA737_SelectedIndexChanged);
		txtIDNhomGiuLai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtIDNhomGiuLai.Location = new System.Drawing.Point(30, 158);
		txtIDNhomGiuLai.Name = "txtIDNhomGiuLai";
		txtIDNhomGiuLai.Size = new System.Drawing.Size(296, 361);
		txtIDNhomGiuLai.TabIndex = 120;
		txtIDNhomGiuLai.Text = "";
		txtIDNhomGiuLai.WordWrap = false;
		txtIDNhomGiuLai.TextChanged += new System.EventHandler(B92C3E98);
		lblIDNhomGiuLai.AutoSize = true;
		lblIDNhomGiuLai.Location = new System.Drawing.Point(27, 139);
		lblIDNhomGiuLai.Name = "lblIDNhomGiuLai";
		lblIDNhomGiuLai.Size = new System.Drawing.Size(207, 16);
		lblIDNhomGiuLai.TabIndex = 118;
		lblIDNhomGiuLai.Text = "Danh sách ID nhóm cần giữ lại (0):";
		lblIDNhomGiuLai.Click += new System.EventHandler(lblIDNhomGiuLai_Click);
		plUidChiDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plUidChiDinh.Controls.Add(panel2);
		plUidChiDinh.Controls.Add(C6994D0F);
		plUidChiDinh.Controls.Add(plDieuKienTuKhoa);
		plUidChiDinh.Controls.Add(ckbDieuKienTuKhoa);
		plUidChiDinh.Controls.Add(ckbDieuKienThanhVien);
		plUidChiDinh.Controls.Add(CB0A04A2);
		plUidChiDinh.Location = new System.Drawing.Point(354, 111);
		plUidChiDinh.Name = "plUidChiDinh";
		plUidChiDinh.Size = new System.Drawing.Size(295, 408);
		plUidChiDinh.TabIndex = 49;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(ADACE6BC);
		panel2.Controls.Add(E3B93F3A);
		panel2.Controls.Add(label13);
		panel2.Location = new System.Drawing.Point(20, 241);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(269, 160);
		panel2.TabIndex = 52;
		ADACE6BC.Location = new System.Drawing.Point(6, 22);
		ADACE6BC.Name = "txtIdNhomRoi";
		ADACE6BC.Size = new System.Drawing.Size(258, 114);
		ADACE6BC.TabIndex = 1;
		ADACE6BC.Text = "";
		ADACE6BC.WordWrap = false;
		ADACE6BC.TextChanged += new System.EventHandler(ADACE6BC_TextChanged);
		E3B93F3A.AutoSize = true;
		E3B93F3A.Location = new System.Drawing.Point(3, 3);
		E3B93F3A.Name = "lblIdNhomRoi";
		E3B93F3A.Size = new System.Drawing.Size(144, 16);
		E3B93F3A.TabIndex = 0;
		E3B93F3A.Text = "Danh sách ID nhóm (0):";
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(3, 138);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(132, 16);
		label13.TabIndex = 0;
		label13.Text = "(Mỗi ID nhóm 1 dòng)";
		C6994D0F.AutoSize = true;
		C6994D0F.Cursor = System.Windows.Forms.Cursors.Hand;
		C6994D0F.Location = new System.Drawing.Point(6, 218);
		C6994D0F.Name = "ckbDieuKienID";
		C6994D0F.Size = new System.Drawing.Size(125, 20);
		C6994D0F.TabIndex = 51;
		C6994D0F.Text = "Rời theo ID nhóm";
		C6994D0F.UseVisualStyleBackColor = true;
		C6994D0F.CheckedChanged += new System.EventHandler(C6994D0F_CheckedChanged);
		plDieuKienTuKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDieuKienTuKhoa.Controls.Add(txtTuKhoa);
		plDieuKienTuKhoa.Controls.Add(lblTuKhoa);
		plDieuKienTuKhoa.Controls.Add(C92E4D8B);
		plDieuKienTuKhoa.Location = new System.Drawing.Point(24, 55);
		plDieuKienTuKhoa.Name = "plDieuKienTuKhoa";
		plDieuKienTuKhoa.Size = new System.Drawing.Size(265, 160);
		plDieuKienTuKhoa.TabIndex = 50;
		txtTuKhoa.Location = new System.Drawing.Point(6, 22);
		txtTuKhoa.Name = "txtTuKhoa";
		txtTuKhoa.Size = new System.Drawing.Size(254, 114);
		txtTuKhoa.TabIndex = 1;
		txtTuKhoa.Text = "";
		txtTuKhoa.WordWrap = false;
		txtTuKhoa.TextChanged += new System.EventHandler(txtTuKhoa_TextChanged);
		lblTuKhoa.AutoSize = true;
		lblTuKhoa.Location = new System.Drawing.Point(3, 3);
		lblTuKhoa.Name = "lblTuKhoa";
		lblTuKhoa.Size = new System.Drawing.Size(139, 16);
		lblTuKhoa.TabIndex = 0;
		lblTuKhoa.Text = "Danh sách tư\u0300 kho\u0301a (0):";
		C92E4D8B.AutoSize = true;
		C92E4D8B.Location = new System.Drawing.Point(4, 139);
		C92E4D8B.Name = "label10";
		C92E4D8B.Size = new System.Drawing.Size(127, 16);
		C92E4D8B.TabIndex = 0;
		C92E4D8B.Text = "(Mỗi tư\u0300 kho\u0301a 1 dòng)";
		ckbDieuKienTuKhoa.AutoSize = true;
		ckbDieuKienTuKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDieuKienTuKhoa.Location = new System.Drawing.Point(6, 29);
		ckbDieuKienTuKhoa.Name = "ckbDieuKienTuKhoa";
		ckbDieuKienTuKhoa.Size = new System.Drawing.Size(209, 20);
		ckbDieuKienTuKhoa.TabIndex = 2;
		ckbDieuKienTuKhoa.Text = "Tên nho\u0301m co\u0301 chư\u0301a tư\u0300 kho\u0301a sau:";
		ckbDieuKienTuKhoa.UseVisualStyleBackColor = true;
		ckbDieuKienTuKhoa.CheckedChanged += new System.EventHandler(ckbDieuKienTuKhoa_CheckedChanged);
		ckbDieuKienThanhVien.AutoSize = true;
		ckbDieuKienThanhVien.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDieuKienThanhVien.Location = new System.Drawing.Point(6, 3);
		ckbDieuKienThanhVien.Name = "ckbDieuKienThanhVien";
		ckbDieuKienThanhVien.Size = new System.Drawing.Size(181, 20);
		ckbDieuKienThanhVien.TabIndex = 2;
		ckbDieuKienThanhVien.Text = "Sô\u0301 lươ\u0323ng tha\u0300nh viên i\u0301t hơn:";
		ckbDieuKienThanhVien.UseVisualStyleBackColor = true;
		ckbDieuKienThanhVien.CheckedChanged += new System.EventHandler(DD9AF588);
		CB0A04A2.Location = new System.Drawing.Point(197, 2);
		CB0A04A2.Maximum = new decimal(new int[4] { 999999999, 0, 0, 0 });
		CB0A04A2.Name = "nudThanhVienToiDa";
		CB0A04A2.Size = new System.Drawing.Size(92, 23);
		CB0A04A2.TabIndex = 1;
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(351, 82);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(64, 16);
		label9.TabIndex = 47;
		label9.Text = "Tùy chọn:";
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
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(287, 109);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(30, 16);
		label6.TabIndex = 45;
		label6.Text = "giây";
		nudSoLuongTo.Location = new System.Drawing.Point(229, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		C101371C.Location = new System.Drawing.Point(132, 78);
		C101371C.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C101371C.Name = "nudSoLuongFrom";
		C101371C.Size = new System.Drawing.Size(56, 23);
		C101371C.TabIndex = 1;
		E1AAAE09.Location = new System.Drawing.Point(132, 49);
		E1AAAE09.Name = "txtTenHanhDong";
		E1AAAE09.Size = new System.Drawing.Size(194, 23);
		E1AAAE09.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AB141015.AutoSize = true;
		AB141015.Location = new System.Drawing.Point(287, 80);
		AB141015.Name = "label4";
		AB141015.Size = new System.Drawing.Size(39, 16);
		AB141015.TabIndex = 35;
		AB141015.Text = "nho\u0301m";
		EB837FAC.AutoSize = true;
		EB837FAC.Location = new System.Drawing.Point(27, 52);
		EB837FAC.Name = "label1";
		EB837FAC.Size = new System.Drawing.Size(98, 16);
		EB837FAC.TabIndex = 31;
		EB837FAC.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(347, 533);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(FFA194AD);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(242, 533);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(AB08B3AE);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(676, 37);
		bunifuCards1.TabIndex = 28;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 111);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 122;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		C4ACD91A.AutoSize = true;
		C4ACD91A.Location = new System.Drawing.Point(27, 82);
		C4ACD91A.Name = "label5";
		C4ACD91A.Size = new System.Drawing.Size(63, 16);
		C4ACD91A.TabIndex = 123;
		C4ACD91A.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(679, 575);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDRoiNhom";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(AC27F712);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plUidChiDinh.ResumeLayout(false);
		plUidChiDinh.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		plDieuKienTuKhoa.ResumeLayout(false);
		plDieuKienTuKhoa.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CB0A04A2).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)C101371C).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
