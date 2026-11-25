using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDangStatus : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string ED1DAC0F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer AC083B39 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl C2947B12;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label EC959A10;

	internal Button A9825D8D;

	internal Button F90F6237;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button A30F6790;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal CheckBox ckbAnh;

	internal CheckBox ckbVanBan;

	internal Panel plVanBan;

	internal Label C79386B0;

	internal Panel plAnh;

	internal TextBox txtPathAnh;

	internal RichTextBox D88CF0BD;

	internal CheckBox D802AEB7;

	internal Panel plTag;

	internal RichTextBox D4B5AD27;

	internal Label label10;

	internal Label D8125522;

	internal CheckBox F19DB80B;

	internal NumericUpDown nudUidTo;

	internal NumericUpDown nudUidFrom;

	internal Label label13;

	internal RadioButton F234B899;

	internal RadioButton rbUidBanBe;

	internal Label label12;

	internal Panel plUidTuNhap;

	internal Label label20;

	internal NumericUpDown nudKhoangCachTo;

	internal NumericUpDown F2BE1EBD;

	internal Label label17;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal NumericUpDown nudSoLuongAnhTo;

	internal NumericUpDown nudSoLuongAnhFrom;

	internal Label label2;

	internal Label label16;

	internal Label label15;

	internal Label label4;

	internal Label label5;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button btnHuongDanNhapNoiDung;

	internal Label C48426B8;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	public static bool E9918E87
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

	public fHDDangStatus(string AC9C2AAF, string string_2 = "")
	{
		InitializeComponent();
		AppIconHelper.SetIcon(this);
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		pnlHeader.Resize += (s, e) =>
		{
			if (A30F6790 != null)
			{
				A30F6790.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			}
			if (btnMinimize != null)
			{
				btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
			}
		};
		E9918E87 = false;
		string_0 = AC9C2AAF;
		ED1DAC0F = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			F90F6237.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDDangStatus_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			F2BE1EBD.Value = gclass4_0.method_2("nudKhoangCachFrom", 5);
			nudKhoangCachTo.Value = gclass4_0.method_2("nudKhoangCachTo", 10);
			ckbVanBan.Checked = gclass4_0.method_3("ckbVanBan");
			D802AEB7.Checked = gclass4_0.method_3("ckbUseBackground");
			D88CF0BD.Text = gclass4_0.BDB80B23("txtNoiDung");
			ckbAnh.Checked = gclass4_0.method_3("ckbAnh");
			nudSoLuongAnhFrom.Value = gclass4_0.method_2("nudSoLuongAnhFrom", 1);
			nudSoLuongAnhTo.Value = gclass4_0.method_2("nudSoLuongAnhTo", 1);
			txtPathAnh.Text = gclass4_0.BDB80B23("txtPathAnh");
			Commom.AttachFolderPicker(txtPathAnh);
			cbbTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("typeNganCach");
			if (gclass4_0.method_2("typeUidTag") == 0)
			{
				rbUidBanBe.Checked = true;
			}
			else
			{
				F234B899.Checked = true;
			}
			F19DB80B.Checked = gclass4_0.method_3("ckbTag");
			D4B5AD27.Text = gclass4_0.BDB80B23("txtUidTag");
			nudUidFrom.Value = gclass4_0.method_2("nudUidFrom", 1);
			nudUidTo.Value = gclass4_0.method_2("nudUidTo", 1);
		}
		catch (Exception)
		{
		}
		E3B3EEB6();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list_);
	}

	private void A30F6790_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F90F6237_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		if (ckbAnh.Checked && !Directory.Exists(txtPathAnh.Text.Trim()))
		{
			MsBoxHelper.Show("Đường dẫn ảnh không tồn tại!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudKhoangCachFrom", F2BE1EBD.Value);
		gClass.method_4("nudKhoangCachTo", nudKhoangCachTo.Value);
		gClass.method_4("ckbVanBan", ckbVanBan.Checked);
		gClass.method_4("ckbUseBackground", D802AEB7.Checked);
		gClass.method_4("ckbAnh", ckbAnh.Checked);
		gClass.method_4("nudSoLuongAnhFrom", nudSoLuongAnhFrom.Value);
		gClass.method_4("nudSoLuongAnhTo", nudSoLuongAnhTo.Value);
		gClass.method_4("txtNoiDung", D88CF0BD.Text.Trim());
		gClass.method_4("txtPathAnh", txtPathAnh.Text.Trim());
		gClass.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		if (rbUidBanBe.Checked)
		{
			gClass.method_4("typeUidTag", 0);
		}
		else if (F234B899.Checked)
		{
			gClass.method_4("typeUidTag", 1);
		}
		gClass.method_4("ckbTag", F19DB80B.Checked);
		gClass.method_4("txtUidTag", D4B5AD27.Text.Trim());
		gClass.method_4("nudUidFrom", nudUidFrom.Value);
		gClass.method_4("nudUidTo", nudUidTo.Value);
		string e013A = gClass.ED11179C();
		if (ED1DAC0F == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					E9918E87 = true;
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
			if (Class154.smethod_13(ED1DAC0F, text, e013A))
			{
				E9918E87 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void A9825D8D_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void A3A58A86(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void E3B3EEB6()
	{
		ckbVanBan_CheckedChanged(null, null);
		ckbAnh_CheckedChanged(null, null);
		D7A97439(null, null);
		BD0B1008(null, null);
		F11F3FAC(null, null);
	}

	private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
	{
		plVanBan.Enabled = ckbVanBan.Checked;
		if (!ckbVanBan.Checked)
		{
			D802AEB7.Checked = false;
		}
	}

	private void ckbAnh_CheckedChanged(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbAnh.Checked;
		if (ckbAnh.Checked)
		{
			D802AEB7.Checked = false;
		}
	}

	private void D7A97439(object sender, EventArgs e)
	{
	}

	private void D88CF0BD_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(D88CF0BD, C79386B0, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void D802AEB7_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void BD0B1008(object sender, EventArgs e)
	{
		plTag.Enabled = F19DB80B.Checked;
	}

	private void D4B5AD27_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(D4B5AD27, D8125522);
	}

	private void D8125522_Click(object sender, EventArgs e)
	{
	}

	private void D508DF25(object sender, EventArgs e)
	{
	}

	private void F11F3FAC(object sender, EventArgs e)
	{
		plUidTuNhap.Enabled = F234B899.Checked;
	}

	private void txtPathAnh_TextChanged(object sender, EventArgs e)
	{
	}

	private void F1A4AD9E(object sender, EventArgs e)
	{
		Commom.A9BCAF05(D88CF0BD, C79386B0, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		D88CF0BD.Focus();
	}

	protected override void Dispose(bool FCB3C028)
	{
		if (FCB3C028 && AC083B39 != null)
		{
			AC083B39.Dispose();
		}
		base.Dispose(FCB3C028);
	}

	private void InitializeComponent()
	{
		AC083B39 = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDangStatus));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(AC083B39);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		C2947B12 = new Bunifu.Framework.UI.BunifuDragControl(AC083B39);
		pnlHeader = new System.Windows.Forms.Panel();
		A30F6790 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		label16 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		label20 = new System.Windows.Forms.Label();
		nudKhoangCachTo = new System.Windows.Forms.NumericUpDown();
		F2BE1EBD = new System.Windows.Forms.NumericUpDown();
		label17 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		plTag = new System.Windows.Forms.Panel();
		plUidTuNhap = new System.Windows.Forms.Panel();
		D8125522 = new System.Windows.Forms.Label();
		D4B5AD27 = new System.Windows.Forms.RichTextBox();
		F234B899 = new System.Windows.Forms.RadioButton();
		rbUidBanBe = new System.Windows.Forms.RadioButton();
		nudUidTo = new System.Windows.Forms.NumericUpDown();
		nudUidFrom = new System.Windows.Forms.NumericUpDown();
		label12 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		plVanBan = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		C48426B8 = new System.Windows.Forms.Label();
		D88CF0BD = new System.Windows.Forms.RichTextBox();
		C79386B0 = new System.Windows.Forms.Label();
		F90F6237 = new System.Windows.Forms.Button();
		plAnh = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		nudSoLuongAnhTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongAnhFrom = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		txtPathAnh = new System.Windows.Forms.TextBox();
		F19DB80B = new System.Windows.Forms.CheckBox();
		D802AEB7 = new System.Windows.Forms.CheckBox();
		ckbAnh = new System.Windows.Forms.CheckBox();
		ckbVanBan = new System.Windows.Forms.CheckBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		EC959A10 = new System.Windows.Forms.Label();
		A9825D8D = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)F2BE1EBD).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		plTag.SuspendLayout();
		plUidTuNhap.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudUidTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudUidFrom).BeginInit();
		plVanBan.SuspendLayout();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(654, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Đăng status";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C2947B12.Fixed = true;
		C2947B12.Horizontal = true;
		C2947B12.TargetControl = pnlHeader;
		C2947B12.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(A30F6790);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(654, 31);
		pnlHeader.TabIndex = 9;
		// Minimize Button
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(589, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		A30F6790.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A30F6790.Cursor = System.Windows.Forms.Cursors.Hand;
		A30F6790.FlatAppearance.BorderSize = 0;
		A30F6790.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A30F6790.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A30F6790.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		A30F6790.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		A30F6790.Text = iconClose == null ? "✕" : "";
		A30F6790.Location = new System.Drawing.Point(623, 1);
		A30F6790.Name = "button1";
		A30F6790.Size = new System.Drawing.Size(30, 30);
		A30F6790.TabIndex = 0;
		A30F6790.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A30F6790.UseVisualStyleBackColor = true;
		A30F6790.Click += new System.EventHandler(A30F6790_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Controls.Add(label16);
		panel1.Controls.Add(label15);
		panel1.Controls.Add(label20);
		panel1.Controls.Add(nudKhoangCachTo);
		panel1.Controls.Add(F2BE1EBD);
		panel1.Controls.Add(label17);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(plTag);
		panel1.Controls.Add(plVanBan);
		panel1.Controls.Add(F90F6237);
		panel1.Controls.Add(plAnh);
		panel1.Controls.Add(F19DB80B);
		panel1.Controls.Add(D802AEB7);
		panel1.Controls.Add(ckbAnh);
		panel1.Controls.Add(ckbVanBan);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(EC959A10);
		panel1.Controls.Add(A9825D8D);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(657, 589);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(A3A58A86);
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(30, 112);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(87, 16);
		label16.TabIndex = 45;
		label16.Text = "Gia\u0303n ca\u0301ch (s):";
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(30, 83);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(84, 16);
		label15.TabIndex = 44;
		label15.Text = "Số lượng bài:";
		label20.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(205, 109);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(29, 16);
		label20.TabIndex = 42;
		label20.Text = ">";
		label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudKhoangCachTo.Location = new System.Drawing.Point(236, 107);
		nudKhoangCachTo.Name = "nudKhoangCachTo";
		nudKhoangCachTo.Size = new System.Drawing.Size(51, 23);
		nudKhoangCachTo.TabIndex = 41;
		F2BE1EBD.Location = new System.Drawing.Point(151, 107);
		F2BE1EBD.Name = "nudKhoangCachFrom";
		F2BE1EBD.Size = new System.Drawing.Size(51, 23);
		F2BE1EBD.TabIndex = 40;
		label17.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(205, 83);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(29, 16);
		label17.TabIndex = 38;
		label17.Text = ">";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongTo.Location = new System.Drawing.Point(236, 78);
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(51, 23);
		nudSoLuongTo.TabIndex = 37;
		nudSoLuongFrom.Location = new System.Drawing.Point(151, 78);
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(51, 23);
		nudSoLuongFrom.TabIndex = 36;
		plTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTag.Controls.Add(plUidTuNhap);
		plTag.Controls.Add(F234B899);
		plTag.Controls.Add(rbUidBanBe);
		plTag.Controls.Add(nudUidTo);
		plTag.Controls.Add(nudUidFrom);
		plTag.Controls.Add(label12);
		plTag.Controls.Add(label10);
		plTag.Controls.Add(label13);
		plTag.Enabled = false;
		plTag.Location = new System.Drawing.Point(370, 269);
		plTag.Name = "plTag";
		plTag.Size = new System.Drawing.Size(251, 255);
		plTag.TabIndex = 33;
		plUidTuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plUidTuNhap.Controls.Add(D8125522);
		plUidTuNhap.Controls.Add(D4B5AD27);
		plUidTuNhap.Location = new System.Drawing.Point(17, 97);
		plUidTuNhap.Name = "plUidTuNhap";
		plUidTuNhap.Size = new System.Drawing.Size(227, 151);
		plUidTuNhap.TabIndex = 34;
		D8125522.AutoSize = true;
		D8125522.Location = new System.Drawing.Point(3, 3);
		D8125522.Name = "lblUidTag";
		D8125522.Size = new System.Drawing.Size(114, 16);
		D8125522.TabIndex = 0;
		D8125522.Text = "Danh sa\u0301ch Uid (0):";
		D8125522.Click += new System.EventHandler(D8125522_Click);
		D4B5AD27.Location = new System.Drawing.Point(7, 22);
		D4B5AD27.Name = "txtUidTag";
		D4B5AD27.Size = new System.Drawing.Size(215, 124);
		D4B5AD27.TabIndex = 34;
		D4B5AD27.Text = "";
		D4B5AD27.WordWrap = false;
		D4B5AD27.TextChanged += new System.EventHandler(D4B5AD27_TextChanged);
		F234B899.AutoSize = true;
		F234B899.Cursor = System.Windows.Forms.Cursors.Hand;
		F234B899.Location = new System.Drawing.Point(17, 73);
		F234B899.Name = "rbUidTuNhap";
		F234B899.Size = new System.Drawing.Size(186, 20);
		F234B899.TabIndex = 42;
		F234B899.Text = "Theo danh sách Uid tự nhập";
		F234B899.UseVisualStyleBackColor = true;
		F234B899.CheckedChanged += new System.EventHandler(F11F3FAC);
		rbUidBanBe.AutoSize = true;
		rbUidBanBe.Checked = true;
		rbUidBanBe.Cursor = System.Windows.Forms.Cursors.Hand;
		rbUidBanBe.Location = new System.Drawing.Point(17, 50);
		rbUidBanBe.Name = "rbUidBanBe";
		rbUidBanBe.Size = new System.Drawing.Size(194, 20);
		rbUidBanBe.TabIndex = 42;
		rbUidBanBe.TabStop = true;
		rbUidBanBe.Text = "Ngẫu nhiên danh sách bạn bè";
		rbUidBanBe.UseVisualStyleBackColor = true;
		nudUidTo.Location = new System.Drawing.Point(208, 4);
		nudUidTo.Maximum = new decimal(new int[4] { 50, 0, 0, 0 });
		nudUidTo.Name = "nudUidTo";
		nudUidTo.Size = new System.Drawing.Size(36, 23);
		nudUidTo.TabIndex = 39;
		nudUidTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		nudUidFrom.Location = new System.Drawing.Point(137, 4);
		nudUidFrom.Maximum = new decimal(new int[4] { 50, 0, 0, 0 });
		nudUidFrom.Name = "nudUidFrom";
		nudUidFrom.Size = new System.Drawing.Size(36, 23);
		nudUidFrom.TabIndex = 38;
		nudUidFrom.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(3, 31);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(126, 16);
		label12.TabIndex = 0;
		label12.Text = "Tùy chọn Uid để tag:";
		label10.AutoSize = true;
		label10.Location = new System.Drawing.Point(3, 6);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(117, 16);
		label10.TabIndex = 0;
		label10.Text = "Số Uid cần tag/bài:";
		label13.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(176, 6);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(29, 16);
		label13.TabIndex = 41;
		label13.Text = ">";
		label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plVanBan.Controls.Add(cbbTuyChonNoiDung);
		plVanBan.Controls.Add(btnHuongDanNhapNoiDung);
		plVanBan.Controls.Add(C48426B8);
		plVanBan.Controls.Add(D88CF0BD);
		plVanBan.Controls.Add(C79386B0);
		plVanBan.Location = new System.Drawing.Point(47, 159);
		plVanBan.Name = "plVanBan";
		plVanBan.Size = new System.Drawing.Size(278, 365);
		plVanBan.TabIndex = 33;
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(66, 333);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(172, 24);
		cbbTuyChonNoiDung.TabIndex = 200;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(F1A4AD9E);
		btnHuongDanNhapNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(244, 332);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 199;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		C48426B8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C48426B8.AutoSize = true;
		C48426B8.Location = new System.Drawing.Point(0, 336);
		C48426B8.Name = "label11";
		C48426B8.Size = new System.Drawing.Size(64, 16);
		C48426B8.TabIndex = 198;
		C48426B8.Text = "Tùy chọn:";
		D88CF0BD.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D88CF0BD.Location = new System.Drawing.Point(7, 24);
		D88CF0BD.Name = "txtNoiDung";
		D88CF0BD.Size = new System.Drawing.Size(263, 304);
		D88CF0BD.TabIndex = 34;
		D88CF0BD.Text = "";
		D88CF0BD.WordWrap = false;
		D88CF0BD.TextChanged += new System.EventHandler(D88CF0BD_TextChanged);
		D88CF0BD.DoubleClick += (s, e) =>
		{
			fSoanThaoNoiDung f = new fSoanThaoNoiDung(D88CF0BD.Text, cbbTuyChonNoiDung.SelectedIndex);
			if (f.ShowDialog() == DialogResult.OK)
			{
				D88CF0BD.Text = f.Content;
				if (f.IsMultiPost)
				{
					cbbTuyChonNoiDung.SelectedIndex = 1;
				}
				Commom.A9BCAF05(D88CF0BD, C79386B0, cbbTuyChonNoiDung.SelectedIndex);
			}
		};
		C79386B0.AutoSize = true;
		C79386B0.Location = new System.Drawing.Point(3, 4);
		C79386B0.Name = "lblNoiDung";
		C79386B0.Size = new System.Drawing.Size(145, 16);
		C79386B0.TabIndex = 0;
		C79386B0.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
		F90F6237.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F90F6237.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		F90F6237.Cursor = System.Windows.Forms.Cursors.Hand;
		F90F6237.FlatAppearance.BorderSize = 0;
		F90F6237.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F90F6237.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F90F6237.ForeColor = System.Drawing.Color.White;
		F90F6237.Location = new System.Drawing.Point(245, 542);
		F90F6237.Name = "btnAdd";
		F90F6237.Size = new System.Drawing.Size(92, 29);
		F90F6237.TabIndex = 3;
		F90F6237.Text = "Thêm";
		F90F6237.UseVisualStyleBackColor = false;
		F90F6237.Click += new System.EventHandler(F90F6237_Click);
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(label4);
		plAnh.Controls.Add(label5);
		plAnh.Controls.Add(nudSoLuongAnhTo);
		plAnh.Controls.Add(nudSoLuongAnhFrom);
		plAnh.Controls.Add(label2);
		plAnh.Controls.Add(txtPathAnh);
		plAnh.Location = new System.Drawing.Point(370, 181);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(251, 60);
		plAnh.TabIndex = 33;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(3, 6);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(73, 16);
		label4.TabIndex = 46;
		label4.Text = "Folder ảnh:";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(3, 32);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(74, 16);
		label5.TabIndex = 47;
		label5.Text = "Sô\u0301 a\u0309nh/bài:";
		nudSoLuongAnhTo.Location = new System.Drawing.Point(171, 30);
		nudSoLuongAnhTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongAnhTo.Name = "nudSoLuongAnhTo";
		nudSoLuongAnhTo.Size = new System.Drawing.Size(45, 23);
		nudSoLuongAnhTo.TabIndex = 7;
		nudSoLuongAnhFrom.Location = new System.Drawing.Point(82, 30);
		nudSoLuongAnhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongAnhFrom.Name = "nudSoLuongAnhFrom";
		nudSoLuongAnhFrom.Size = new System.Drawing.Size(45, 23);
		nudSoLuongAnhFrom.TabIndex = 8;
		label2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(134, 32);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(29, 16);
		label2.TabIndex = 4;
		label2.Text = ">";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		txtPathAnh.Location = new System.Drawing.Point(82, 3);
		txtPathAnh.Name = "txtPathAnh";
		txtPathAnh.Size = new System.Drawing.Size(162, 23);
		txtPathAnh.TabIndex = 1;
		txtPathAnh.TextChanged += new System.EventHandler(txtPathAnh_TextChanged);
		F19DB80B.AutoSize = true;
		F19DB80B.Cursor = System.Windows.Forms.Cursors.Hand;
		F19DB80B.Location = new System.Drawing.Point(356, 245);
		F19DB80B.Name = "ckbTag";
		F19DB80B.Size = new System.Drawing.Size(139, 20);
		F19DB80B.TabIndex = 32;
		F19DB80B.Text = "Tag Uid vào bài viết";
		F19DB80B.UseVisualStyleBackColor = true;
		F19DB80B.CheckedChanged += new System.EventHandler(BD0B1008);
		D802AEB7.AutoSize = true;
		D802AEB7.Cursor = System.Windows.Forms.Cursors.Hand;
		D802AEB7.Location = new System.Drawing.Point(356, 135);
		D802AEB7.Name = "ckbUseBackground";
		D802AEB7.Size = new System.Drawing.Size(144, 20);
		D802AEB7.TabIndex = 32;
		D802AEB7.Text = "Sử dụng Background";
		D802AEB7.UseVisualStyleBackColor = true;
		D802AEB7.CheckedChanged += new System.EventHandler(D802AEB7_CheckedChanged);
		ckbAnh.AutoSize = true;
		ckbAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAnh.Location = new System.Drawing.Point(356, 159);
		ckbAnh.Name = "ckbAnh";
		ckbAnh.Size = new System.Drawing.Size(48, 20);
		ckbAnh.TabIndex = 32;
		ckbAnh.Text = "A\u0309nh";
		ckbAnh.UseVisualStyleBackColor = true;
		ckbAnh.CheckedChanged += new System.EventHandler(ckbAnh_CheckedChanged);
		ckbVanBan.AutoSize = true;
		ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbVanBan.Location = new System.Drawing.Point(33, 135);
		ckbVanBan.Name = "ckbVanBan";
		ckbVanBan.Size = new System.Drawing.Size(73, 20);
		ckbVanBan.TabIndex = 32;
		ckbVanBan.Text = "Văn ba\u0309n";
		ckbVanBan.UseVisualStyleBackColor = true;
		ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
		txtTenHanhDong.Location = new System.Drawing.Point(151, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(174, 23);
		txtTenHanhDong.TabIndex = 0;
		EC959A10.AutoSize = true;
		EC959A10.Location = new System.Drawing.Point(30, 52);
		EC959A10.Name = "label1";
		EC959A10.Size = new System.Drawing.Size(98, 16);
		EC959A10.TabIndex = 31;
		EC959A10.Text = "Tên ha\u0300nh đô\u0323ng:";
		A9825D8D.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		A9825D8D.BackColor = System.Drawing.Color.Maroon;
		A9825D8D.Cursor = System.Windows.Forms.Cursors.Hand;
		A9825D8D.FlatAppearance.BorderSize = 0;
		A9825D8D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A9825D8D.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A9825D8D.ForeColor = System.Drawing.Color.White;
		A9825D8D.Location = new System.Drawing.Point(344, 542);
		A9825D8D.Name = "btnCancel";
		A9825D8D.Size = new System.Drawing.Size(92, 29);
		A9825D8D.TabIndex = 4;
		A9825D8D.Text = "Đóng";
		A9825D8D.UseVisualStyleBackColor = false;
		A9825D8D.Click += new System.EventHandler(A9825D8D_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(654, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(657, 589);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDangStatus";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDDangStatus_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).EndInit();
		((System.ComponentModel.ISupportInitialize)F2BE1EBD).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		plTag.ResumeLayout(false);
		plTag.PerformLayout();
		plUidTuNhap.ResumeLayout(false);
		plUidTuNhap.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudUidTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudUidFrom).EndInit();
		plVanBan.ResumeLayout(false);
		plVanBan.PerformLayout();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
