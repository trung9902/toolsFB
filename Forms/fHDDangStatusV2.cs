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

public class fHDDangStatusV2 : Form
{
	internal GClass4 gclass4_0;

	internal string EB051B93;

	internal string string_0;

	internal string B2003697;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool AF878CA9;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button BC102108;

	internal Button AD9E9300;

	internal BunifuCards F727B401;

	internal Panel D3BF2495;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal CheckBox ckbAnh;

	internal CheckBox ckbVanBan;

	internal Panel plVanBan;

	internal Label B19F8F04;

	internal Panel plAnh;

	internal TextBox txtPathAnh;

	internal RichTextBox C3282B9A;

	internal Panel plTag;

	internal Label label10;

	internal CheckBox ckbTag;

	internal NumericUpDown nudUidTo;

	internal NumericUpDown B6B3DE84;

	internal Label F00A2B1F;

	internal NumericUpDown CD21F290;

	internal NumericUpDown nudKhoangCachFrom;

	internal Label label17;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown AFAD93B3;

	internal Label label16;

	internal Label label15;

	internal NumericUpDown BD11B82C;

	internal NumericUpDown AC09AF85;

	internal Label label2;

	internal CheckBox ckbOnlyTagVNName;

	internal CheckBox ckbDangAnhTheoThuTu;

	internal Label label4;

	internal Label label6;

	internal NumericUpDown nudDelayTagTo;

	internal NumericUpDown nudDelayTagFrom;

	internal Label B1336D1F;

	internal Label label7;

	internal Label label11;

	internal CheckBox ckbClickPrivacy;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button A32D67B9;

	internal Label label3;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return AF878CA9;
		}
		[CompilerGenerated]
		set
		{
			AF878CA9 = value;
		}
	}

	public fHDDangStatusV2(string string_1, string string_2 = "")
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
		D3BF2495.Resize += (s, e) =>
		{
			if (button1 != null)
			{
				button1.Location = new System.Drawing.Point(D3BF2495.Width - 34, 1);
			}
			if (btnMinimize != null)
			{
				btnMinimize.Location = new System.Drawing.Point(D3BF2495.Width - 68, 1);
			}
		};
		Boolean_0 = false;
		EB051B93 = string_1;
		B2003697 = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_3 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			string_3 = dataTable2.Rows[0]["CauHinh"].ToString();
			AD9E9300.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_3, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDDangStatusV2_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			AFAD93B3.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			nudKhoangCachFrom.Value = gclass4_0.method_2("nudKhoangCachFrom", 5);
			CD21F290.Value = gclass4_0.method_2("nudKhoangCachTo", 10);
			ckbVanBan.Checked = gclass4_0.method_3("ckbVanBan");
			C3282B9A.Text = gclass4_0.BDB80B23("txtNoiDung");
			ckbAnh.Checked = gclass4_0.method_3("ckbAnh");
			ckbDangAnhTheoThuTu.Checked = gclass4_0.method_3("ckbDangAnhTheoThuTu");
			AC09AF85.Value = gclass4_0.method_2("nudSoLuongAnhFrom", 1);
			BD11B82C.Value = gclass4_0.method_2("nudSoLuongAnhTo", 1);
			txtPathAnh.Text = gclass4_0.BDB80B23("txtPathAnh");
			Commom.AttachFolderPicker(txtPathAnh);
			cbbTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("typeNganCach");
			ckbTag.Checked = gclass4_0.method_3("ckbTag");
			B6B3DE84.Value = gclass4_0.method_2("nudUidFrom", 1);
			nudUidTo.Value = gclass4_0.method_2("nudUidTo", 1);
			ckbOnlyTagVNName.Checked = gclass4_0.method_3("ckbOnlyTagVNName");
			nudDelayTagFrom.Value = gclass4_0.method_2("nudDelayTagFrom");
			nudDelayTagTo.Value = gclass4_0.method_2("nudDelayTagTo");
			ckbClickPrivacy.Checked = gclass4_0.method_3("ckbClickPrivacy", C9B3010F: true);
		}
		catch (Exception)
		{
		}
		method_1();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list_);
	}

	private void C410592B(object sender, EventArgs e)
	{
		Close();
	}

	private void DB32EA11(object sender, EventArgs e)
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
		gClass.method_4("nudSoLuongFrom", AFAD93B3.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudKhoangCachFrom", nudKhoangCachFrom.Value);
		gClass.method_4("nudKhoangCachTo", CD21F290.Value);
		gClass.method_4("ckbVanBan", ckbVanBan.Checked);
		gClass.method_4("ckbAnh", ckbAnh.Checked);
		gClass.method_4("ckbDangAnhTheoThuTu", ckbDangAnhTheoThuTu.Checked);
		gClass.method_4("nudSoLuongAnhFrom", AC09AF85.Value);
		gClass.method_4("nudSoLuongAnhTo", BD11B82C.Value);
		gClass.method_4("txtNoiDung", C3282B9A.Text.Trim());
		gClass.method_4("txtPathAnh", txtPathAnh.Text.Trim());
		gClass.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		gClass.method_4("ckbTag", ckbTag.Checked);
		gClass.method_4("nudUidFrom", B6B3DE84.Value);
		gClass.method_4("nudUidTo", nudUidTo.Value);
		gClass.method_4("ckbOnlyTagVNName", ckbOnlyTagVNName.Checked);
		gClass.method_4("nudDelayTagFrom", nudDelayTagFrom.Value);
		gClass.method_4("nudDelayTagTo", nudDelayTagTo.Value);
		gClass.method_4("ckbClickPrivacy", ckbClickPrivacy.Checked);
		string text2 = gClass.ED11179C();
		if (B2003697 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(EB051B93, text, string_0, text2))
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
			if (Class154.smethod_13(B2003697, text, text2))
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

	private void BC102108_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void method_1()
	{
		ckbVanBan_CheckedChanged(null, null);
		FE296734(null, null);
		ckbTag_CheckedChanged(null, null);
		method_2(null, null);
	}

	private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
	{
		plVanBan.Enabled = ckbVanBan.Checked;
	}

	private void FE296734(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbAnh.Checked;
	}

	private void C3282B9A_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C3282B9A, B19F8F04, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void ED99E932(object sender, EventArgs e)
	{
	}

	private void ckbTag_CheckedChanged(object sender, EventArgs e)
	{
		plTag.Enabled = ckbTag.Checked;
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void AD387905(object sender, EventArgs e)
	{
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C3282B9A, B19F8F04, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void A32D67B9_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		C3282B9A.Focus();
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
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDangStatusV2));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D3BF2495 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		F00A2B1F = new System.Windows.Forms.Label();
		CD21F290 = new System.Windows.Forms.NumericUpDown();
		nudKhoangCachFrom = new System.Windows.Forms.NumericUpDown();
		label17 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		AFAD93B3 = new System.Windows.Forms.NumericUpDown();
		label16 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		plTag = new System.Windows.Forms.Panel();
		label6 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		nudDelayTagTo = new System.Windows.Forms.NumericUpDown();
		nudUidTo = new System.Windows.Forms.NumericUpDown();
		nudDelayTagFrom = new System.Windows.Forms.NumericUpDown();
		B6B3DE84 = new System.Windows.Forms.NumericUpDown();
		B1336D1F = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		ckbOnlyTagVNName = new System.Windows.Forms.CheckBox();
		plVanBan = new System.Windows.Forms.Panel();
		C3282B9A = new System.Windows.Forms.RichTextBox();
		B19F8F04 = new System.Windows.Forms.Label();
		AD9E9300 = new System.Windows.Forms.Button();
		plAnh = new System.Windows.Forms.Panel();
		label7 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		BD11B82C = new System.Windows.Forms.NumericUpDown();
		AC09AF85 = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		txtPathAnh = new System.Windows.Forms.TextBox();
		ckbDangAnhTheoThuTu = new System.Windows.Forms.CheckBox();
		ckbTag = new System.Windows.Forms.CheckBox();
		ckbAnh = new System.Windows.Forms.CheckBox();
		ckbVanBan = new System.Windows.Forms.CheckBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		BC102108 = new System.Windows.Forms.Button();
		F727B401 = new Bunifu.Framework.UI.BunifuCards();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		A32D67B9 = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		ckbClickPrivacy = new System.Windows.Forms.CheckBox();
		D3BF2495.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CD21F290).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)AFAD93B3).BeginInit();
		plTag.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTagTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudUidTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTagFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)B6B3DE84).BeginInit();
		plVanBan.SuspendLayout();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)BD11B82C).BeginInit();
		((System.ComponentModel.ISupportInitialize)AC09AF85).BeginInit();
		F727B401.SuspendLayout();
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
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = D3BF2495;
		bunifuDragControl_1.Vertical = true;
		D3BF2495.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D3BF2495.BackColor = System.Drawing.Color.White;
		D3BF2495.Controls.Add(btnMinimize);
		D3BF2495.Controls.Add(button1);
		D3BF2495.Controls.Add(pictureBox1);
		D3BF2495.Controls.Add(bunifuCustomLabel1);
		D3BF2495.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D3BF2495.Location = new System.Drawing.Point(0, 3);
		D3BF2495.Name = "pnlHeader";
		D3BF2495.Size = new System.Drawing.Size(654, 31);
		D3BF2495.TabIndex = 9;
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
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(623, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 0;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(C410592B);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(ED99E932);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Controls.Add(ckbClickPrivacy);
		panel1.Controls.Add(F00A2B1F);
		panel1.Controls.Add(CD21F290);
		panel1.Controls.Add(nudKhoangCachFrom);
		panel1.Controls.Add(label17);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(AFAD93B3);
		panel1.Controls.Add(label16);
		panel1.Controls.Add(label15);
		panel1.Controls.Add(plTag);
		panel1.Controls.Add(plVanBan);
		panel1.Controls.Add(AD9E9300);
		panel1.Controls.Add(plAnh);
		panel1.Controls.Add(ckbTag);
		panel1.Controls.Add(ckbAnh);
		panel1.Controls.Add(ckbVanBan);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(BC102108);
		panel1.Controls.Add(F727B401);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(657, 411);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		F00A2B1F.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F00A2B1F.Location = new System.Drawing.Point(188, 109);
		F00A2B1F.Name = "label20";
		F00A2B1F.Size = new System.Drawing.Size(29, 16);
		F00A2B1F.TabIndex = 42;
		F00A2B1F.Text = ">";
		F00A2B1F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CD21F290.Location = new System.Drawing.Point(219, 107);
		CD21F290.Name = "nudKhoangCachTo";
		CD21F290.Size = new System.Drawing.Size(51, 23);
		CD21F290.TabIndex = 41;
		nudKhoangCachFrom.Location = new System.Drawing.Point(134, 107);
		nudKhoangCachFrom.Name = "nudKhoangCachFrom";
		nudKhoangCachFrom.Size = new System.Drawing.Size(51, 23);
		nudKhoangCachFrom.TabIndex = 40;
		label17.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(188, 83);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(29, 16);
		label17.TabIndex = 38;
		label17.Text = ">";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongTo.Location = new System.Drawing.Point(219, 78);
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(51, 23);
		nudSoLuongTo.TabIndex = 37;
		AFAD93B3.Location = new System.Drawing.Point(134, 78);
		AFAD93B3.Name = "nudSoLuongFrom";
		AFAD93B3.Size = new System.Drawing.Size(51, 23);
		AFAD93B3.TabIndex = 36;
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(30, 109);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(87, 16);
		label16.TabIndex = 35;
		label16.Text = "Gia\u0303n ca\u0301ch (s):";
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(30, 80);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(84, 16);
		label15.TabIndex = 34;
		label15.Text = "Số lượng bài:";
		plTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTag.Controls.Add(label6);
		plTag.Controls.Add(label4);
		plTag.Controls.Add(nudDelayTagTo);
		plTag.Controls.Add(nudUidTo);
		plTag.Controls.Add(nudDelayTagFrom);
		plTag.Controls.Add(B6B3DE84);
		plTag.Controls.Add(B1336D1F);
		plTag.Controls.Add(label10);
		plTag.Controls.Add(ckbOnlyTagVNName);
		plTag.Enabled = false;
		plTag.Location = new System.Drawing.Point(368, 264);
		plTag.Name = "plTag";
		plTag.Size = new System.Drawing.Size(256, 82);
		plTag.TabIndex = 33;
		label6.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(169, 55);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(29, 16);
		label6.TabIndex = 33;
		label6.Text = ">";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label4.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(169, 5);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(29, 16);
		label4.TabIndex = 33;
		label4.Text = ">";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudDelayTagTo.Location = new System.Drawing.Point(204, 53);
		nudDelayTagTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTagTo.Name = "nudDelayTagTo";
		nudDelayTagTo.Size = new System.Drawing.Size(46, 23);
		nudDelayTagTo.TabIndex = 39;
		nudDelayTagTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		nudUidTo.Location = new System.Drawing.Point(204, 3);
		nudUidTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudUidTo.Name = "nudUidTo";
		nudUidTo.Size = new System.Drawing.Size(46, 23);
		nudUidTo.TabIndex = 39;
		nudUidTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		nudDelayTagFrom.Location = new System.Drawing.Point(118, 53);
		nudDelayTagFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTagFrom.Name = "nudDelayTagFrom";
		nudDelayTagFrom.Size = new System.Drawing.Size(46, 23);
		nudDelayTagFrom.TabIndex = 38;
		nudDelayTagFrom.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		B6B3DE84.Location = new System.Drawing.Point(118, 3);
		B6B3DE84.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		B6B3DE84.Name = "nudUidFrom";
		B6B3DE84.Size = new System.Drawing.Size(46, 23);
		B6B3DE84.TabIndex = 38;
		B6B3DE84.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		B1336D1F.AutoSize = true;
		B1336D1F.Location = new System.Drawing.Point(3, 55);
		B1336D1F.Name = "label5";
		B1336D1F.Size = new System.Drawing.Size(87, 16);
		B1336D1F.TabIndex = 0;
		B1336D1F.Text = "Gia\u0303n ca\u0301ch (s):";
		label10.AutoSize = true;
		label10.Location = new System.Drawing.Point(3, 5);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(109, 16);
		label10.TabIndex = 0;
		label10.Text = "Số người cần tag:";
		ckbOnlyTagVNName.AutoSize = true;
		ckbOnlyTagVNName.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbOnlyTagVNName.Location = new System.Drawing.Point(6, 30);
		ckbOnlyTagVNName.Name = "ckbOnlyTagVNName";
		ckbOnlyTagVNName.Size = new System.Drawing.Size(192, 20);
		ckbOnlyTagVNName.TabIndex = 32;
		ckbOnlyTagVNName.Text = "Chỉ gắn thẻ ngươ\u0300i co\u0301 tên Việt";
		ckbOnlyTagVNName.UseVisualStyleBackColor = true;
		plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plVanBan.Controls.Add(cbbTuyChonNoiDung);
		plVanBan.Controls.Add(A32D67B9);
		plVanBan.Controls.Add(label3);
		plVanBan.Controls.Add(C3282B9A);
		plVanBan.Controls.Add(B19F8F04);
		plVanBan.Location = new System.Drawing.Point(47, 159);
		plVanBan.Name = "plVanBan";
		plVanBan.Size = new System.Drawing.Size(278, 187);
		plVanBan.TabIndex = 33;
		C3282B9A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C3282B9A.Location = new System.Drawing.Point(7, 24);
		C3282B9A.Name = "txtNoiDung";
		C3282B9A.Size = new System.Drawing.Size(263, 125);
		C3282B9A.TabIndex = 34;
		C3282B9A.Text = "";
		C3282B9A.WordWrap = false;
		C3282B9A.TextChanged += new System.EventHandler(C3282B9A_TextChanged);
		C3282B9A.DoubleClick += (s, e) =>
		{
			fSoanThaoNoiDung f = new fSoanThaoNoiDung(C3282B9A.Text, cbbTuyChonNoiDung.SelectedIndex);
			if (f.ShowDialog() == DialogResult.OK)
			{
				C3282B9A.Text = f.Content;
				if (f.IsMultiPost)
				{
					cbbTuyChonNoiDung.SelectedIndex = 1;
				}
				Commom.A9BCAF05(C3282B9A, B19F8F04, cbbTuyChonNoiDung.SelectedIndex);
			}
		};
		B19F8F04.AutoSize = true;
		B19F8F04.Location = new System.Drawing.Point(3, 5);
		B19F8F04.Name = "lblNoiDung";
		B19F8F04.Size = new System.Drawing.Size(145, 16);
		B19F8F04.TabIndex = 0;
		B19F8F04.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
		AD9E9300.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		AD9E9300.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		AD9E9300.Cursor = System.Windows.Forms.Cursors.Hand;
		AD9E9300.FlatAppearance.BorderSize = 0;
		AD9E9300.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AD9E9300.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AD9E9300.ForeColor = System.Drawing.Color.White;
		AD9E9300.Location = new System.Drawing.Point(231, 366);
		AD9E9300.Name = "btnAdd";
		AD9E9300.Size = new System.Drawing.Size(92, 29);
		AD9E9300.TabIndex = 3;
		AD9E9300.Text = "Thêm";
		AD9E9300.UseVisualStyleBackColor = false;
		AD9E9300.Click += new System.EventHandler(DB32EA11);
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(label7);
		plAnh.Controls.Add(label11);
		plAnh.Controls.Add(BD11B82C);
		plAnh.Controls.Add(AC09AF85);
		plAnh.Controls.Add(label2);
		plAnh.Controls.Add(txtPathAnh);
		plAnh.Controls.Add(ckbDangAnhTheoThuTu);
		plAnh.Location = new System.Drawing.Point(368, 157);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(256, 82);
		plAnh.TabIndex = 33;
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(3, 6);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(73, 16);
		label7.TabIndex = 44;
		label7.Text = "Folder ảnh:";
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(3, 34);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(74, 16);
		label11.TabIndex = 45;
		label11.Text = "Sô\u0301 a\u0309nh/bài:";
		BD11B82C.Location = new System.Drawing.Point(176, 32);
		BD11B82C.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		BD11B82C.Name = "nudSoLuongAnhTo";
		BD11B82C.Size = new System.Drawing.Size(45, 23);
		BD11B82C.TabIndex = 7;
		AC09AF85.Location = new System.Drawing.Point(82, 32);
		AC09AF85.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		AC09AF85.Name = "nudSoLuongAnhFrom";
		AC09AF85.Size = new System.Drawing.Size(45, 23);
		AC09AF85.TabIndex = 8;
		label2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(138, 34);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(29, 16);
		label2.TabIndex = 4;
		label2.Text = ">";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		txtPathAnh.Location = new System.Drawing.Point(82, 3);
		txtPathAnh.Name = "txtPathAnh";
		txtPathAnh.Size = new System.Drawing.Size(168, 23);
		txtPathAnh.TabIndex = 1;
		txtPathAnh.TextChanged += new System.EventHandler(AD387905);
		ckbDangAnhTheoThuTu.AutoSize = true;
		ckbDangAnhTheoThuTu.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDangAnhTheoThuTu.Location = new System.Drawing.Point(6, 58);
		ckbDangAnhTheoThuTu.Name = "ckbDangAnhTheoThuTu";
		ckbDangAnhTheoThuTu.Size = new System.Drawing.Size(170, 20);
		ckbDangAnhTheoThuTu.TabIndex = 32;
		ckbDangAnhTheoThuTu.Text = "Đăng file a\u0309nh theo thư\u0301 tư\u0323";
		ckbDangAnhTheoThuTu.UseVisualStyleBackColor = true;
		ckbTag.AutoSize = true;
		ckbTag.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTag.Location = new System.Drawing.Point(354, 242);
		ckbTag.Name = "ckbTag";
		ckbTag.Size = new System.Drawing.Size(182, 20);
		ckbTag.TabIndex = 32;
		ckbTag.Text = "Gắn thẻ bạn bè vào bài viết";
		ckbTag.UseVisualStyleBackColor = true;
		ckbTag.CheckedChanged += new System.EventHandler(ckbTag_CheckedChanged);
		ckbAnh.AutoSize = true;
		ckbAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAnh.Location = new System.Drawing.Point(354, 135);
		ckbAnh.Name = "ckbAnh";
		ckbAnh.Size = new System.Drawing.Size(48, 20);
		ckbAnh.TabIndex = 32;
		ckbAnh.Text = "A\u0309nh";
		ckbAnh.UseVisualStyleBackColor = true;
		ckbAnh.CheckedChanged += new System.EventHandler(FE296734);
		ckbVanBan.AutoSize = true;
		ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbVanBan.Location = new System.Drawing.Point(33, 137);
		ckbVanBan.Name = "ckbVanBan";
		ckbVanBan.Size = new System.Drawing.Size(73, 20);
		ckbVanBan.TabIndex = 32;
		ckbVanBan.Text = "Văn ba\u0309n";
		ckbVanBan.UseVisualStyleBackColor = true;
		ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
		txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(191, 23);
		txtTenHanhDong.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(30, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		BC102108.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BC102108.BackColor = System.Drawing.Color.Maroon;
		BC102108.Cursor = System.Windows.Forms.Cursors.Hand;
		BC102108.FlatAppearance.BorderSize = 0;
		BC102108.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BC102108.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BC102108.ForeColor = System.Drawing.Color.White;
		BC102108.Location = new System.Drawing.Point(330, 366);
		BC102108.Name = "btnCancel";
		BC102108.Size = new System.Drawing.Size(92, 29);
		BC102108.TabIndex = 4;
		BC102108.Text = "Đóng";
		BC102108.UseVisualStyleBackColor = false;
		BC102108.Click += new System.EventHandler(BC102108_Click);
		F727B401.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F727B401.BackColor = System.Drawing.Color.White;
		F727B401.BorderRadius = 0;
		F727B401.BottomSahddow = true;
		F727B401.color = System.Drawing.Color.FromArgb(37, 99, 235);
		F727B401.Controls.Add(D3BF2495);
		F727B401.LeftSahddow = false;
		F727B401.Location = new System.Drawing.Point(1, 0);
		F727B401.Name = "bunifuCards1";
		F727B401.RightSahddow = true;
		F727B401.ShadowDepth = 20;
		F727B401.Size = new System.Drawing.Size(654, 37);
		F727B401.TabIndex = 28;
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(69, 155);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(169, 24);
		cbbTuyChonNoiDung.TabIndex = 203;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		A32D67B9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A32D67B9.Cursor = System.Windows.Forms.Cursors.Hand;
		A32D67B9.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A32D67B9.Location = new System.Drawing.Point(244, 154);
		A32D67B9.Name = "btnHuongDanNhapNoiDung";
		A32D67B9.Size = new System.Drawing.Size(26, 26);
		A32D67B9.TabIndex = 202;
		A32D67B9.Text = "?";
		A32D67B9.UseVisualStyleBackColor = true;
		A32D67B9.Click += new System.EventHandler(A32D67B9_Click);
		label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(3, 158);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(64, 16);
		label3.TabIndex = 201;
		label3.Text = "Tùy chọn:";
		ckbClickPrivacy.AutoSize = true;
		ckbClickPrivacy.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbClickPrivacy.Location = new System.Drawing.Point(33, 434);
		ckbClickPrivacy.Name = "ckbClickPrivacy";
		ckbClickPrivacy.Size = new System.Drawing.Size(251, 20);
		ckbClickPrivacy.TabIndex = 206;
		ckbClickPrivacy.Text = "Tư\u0323 đô\u0323ng set ba\u0300i viê\u0301t ơ\u0309 chê\u0301 đô\u0323 công khai";
		ckbClickPrivacy.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(657, 411);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDangStatusV2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDDangStatusV2_Load);
		D3BF2495.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CD21F290).EndInit();
		((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)AFAD93B3).EndInit();
		plTag.ResumeLayout(false);
		plTag.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTagTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudUidTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTagFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)B6B3DE84).EndInit();
		plVanBan.ResumeLayout(false);
		plVanBan.PerformLayout();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)BD11B82C).EndInit();
		((System.ComponentModel.ISupportInitialize)AC09AF85).EndInit();
		F727B401.ResumeLayout(false);
		ResumeLayout(false);
	}
}
