using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBaiVietNewsfeed2 : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string AB2728B3;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal ucTuongTacBaiVietv2 D4317C28;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl B09EF1A8;

	internal Panel AE94D1A9;

	internal NumericUpDown D69F5081;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown AC9DE9AB;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox B2BD1514;

	internal Label F72AE790;

	internal Label C40536B3;

	internal Label C5AA7032;

	internal Label label2;

	internal Label A50756BF;

	internal Button btnCancel;

	internal Button BC34FBA2;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox DDA89B96;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel plTuongTacBaiViet;

	internal ComboBox ED35DB1E;

	internal Label label4;

	internal Panel C399DC83;

	internal TabControl E53E7BA0;

	internal TabPage tabPage1;

	internal TabPage tabPage2;

	internal Label label8;

	internal Label label9;

	internal NumericUpDown nudThoiGianFrom;

	internal NumericUpDown nudThoiGianTo;

	internal Panel A0A098A0;

	internal RichTextBox txtIdNhom;

	internal Label lblIdNhom;

	internal Label label14;

	internal Label label15;

	internal NumericUpDown nudFeedGroupLuotToiDa;

	internal CheckBox ckbFeedGroup;

	internal Panel B185ABB6;

	internal NumericUpDown E391D534;

	internal NumericUpDown nudDelayXemAnhFrom;

	internal Label label11;

	internal Label label16;

	internal Panel plClickXemThem;

	internal NumericUpDown nudDelayXemThemTo;

	internal NumericUpDown nudDelayXemThemFrom;

	internal Label A1923DA7;

	internal Label label18;

	internal CheckBox ckbClickXemAnh;

	internal CheckBox ckbClickXemThem;

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

	public fHDBaiVietNewsfeed2(string string_2, string string_3 = "")
	{
		InitializeComponent();
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		Boolean_0 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			AB2728B3 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			B2BD1514.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			BC34FBA2.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			B2BD1514.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void E0B6C73F(object sender, EventArgs e)
	{
		method_0();
		try
		{
			ED35DB1E.SelectedIndex = gclass4_0.method_2("cbbOptionsPost");
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 2);
			nudThoiGianFrom.Value = gclass4_0.method_2("nudThoiGianFrom", 30);
			nudThoiGianTo.Value = gclass4_0.method_2("nudThoiGianTo", 30);
			AC9DE9AB.Value = gclass4_0.method_2("nudDelayFrom", 3);
			D69F5081.Value = gclass4_0.method_2("nudDelayTo", 5);
			D4317C28 = new ucTuongTacBaiVietv2(gclass4_0);
			plTuongTacBaiViet.Controls.Add(D4317C28);
			ckbFeedGroup.Checked = gclass4_0.method_3("ckbFeedGroup");
			txtIdNhom.Text = gclass4_0.BDB80B23("txtIdNhom");
			nudFeedGroupLuotToiDa.Value = gclass4_0.method_2("nudFeedGroupLuotToiDa", 50);
			ckbClickXemThem.Checked = gclass4_0.method_3("ckbClickXemThem");
			nudDelayXemThemFrom.Value = gclass4_0.method_2("nudDelayXemThemFrom", 3);
			nudDelayXemThemTo.Value = gclass4_0.method_2("nudDelayXemThemTo", 3);
			ckbClickXemAnh.Checked = gclass4_0.method_3("ckbClickXemAnh");
			nudDelayXemAnhFrom.Value = gclass4_0.method_2("nudDelayXemAnhFrom", 3);
			E391D534.Value = gclass4_0.method_2("nudDelayXemAnhTo", 3);
		}
		catch
		{
		}
		method_1();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Giơ\u0301i ha\u0323n sô\u0301 ba\u0300i viê\u0301t tương ta\u0301c", "Giơ\u0301i ha\u0323n thơ\u0300i gian tương ta\u0301c" };
		Commom.smethod_23(ED35DB1E, list_);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BC34FBA2_Click(object sender, EventArgs e)
	{
		string text = B2BD1514.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = D4317C28.method_2();
		gClass.method_4("cbbOptionsPost", ED35DB1E.SelectedIndex);
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudThoiGianFrom", nudThoiGianFrom.Value);
		gClass.method_4("nudThoiGianTo", nudThoiGianTo.Value);
		gClass.method_4("nudDelayFrom", AC9DE9AB.Value);
		gClass.method_4("nudDelayTo", D69F5081.Value);
		gClass.method_4("ckbFeedGroup", ckbFeedGroup.Checked);
		gClass.method_4("txtIdNhom", txtIdNhom.Text.Trim());
		gClass.method_4("nudFeedGroupLuotToiDa", nudFeedGroupLuotToiDa.Value);
		gClass.method_4("ckbClickXemThem", ckbClickXemThem.Checked);
		gClass.method_4("nudDelayXemThemFrom", nudDelayXemThemFrom.Value);
		gClass.method_4("nudDelayXemThemTo", nudDelayXemThemTo.Value);
		gClass.method_4("ckbClickXemAnh", ckbClickXemAnh.Checked);
		gClass.method_4("nudDelayXemAnhFrom", nudDelayXemAnhFrom.Value);
		gClass.method_4("nudDelayXemAnhTo", E391D534.Value);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, AB2728B3, e013A))
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
			if (Class154.smethod_13(string_1, text, e013A))
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

	private void DF927030(object sender, EventArgs e)
	{
		Close();
	}

	private void AE94D1A9_Paint(object sender, PaintEventArgs e)
	{
		if (AE94D1A9.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, AE94D1A9.ClientSize.Width - num, AE94D1A9.ClientSize.Height - num));
		}
	}

	private void method_1()
	{
		BA069996(null, null);
		ckbClickXemThem_CheckedChanged(null, null);
		D3048512(null, null);
	}

	private void B5189338(object sender, EventArgs e)
	{
	}

	private void FA064927(object sender, EventArgs e)
	{
		E53E7BA0.SelectedIndex = ED35DB1E.SelectedIndex;
	}

	private void BA069996(object sender, EventArgs e)
	{
		A0A098A0.Enabled = ckbFeedGroup.Checked;
	}

	private void B11D1315(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdNhom, lblIdNhom);
	}

	private void ckbClickXemThem_CheckedChanged(object sender, EventArgs e)
	{
		plClickXemThem.Enabled = ckbClickXemThem.Checked;
	}

	private void D3048512(object sender, EventArgs e)
	{
		B185ABB6.Enabled = ckbClickXemAnh.Checked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBaiVietNewsfeed2));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		B09EF1A8 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		DDA89B96 = new System.Windows.Forms.PictureBox();
		AE94D1A9 = new System.Windows.Forms.Panel();
		plTuongTacBaiViet = new System.Windows.Forms.Panel();
		B185ABB6 = new System.Windows.Forms.Panel();
		E391D534 = new System.Windows.Forms.NumericUpDown();
		nudDelayXemAnhFrom = new System.Windows.Forms.NumericUpDown();
		label11 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		plClickXemThem = new System.Windows.Forms.Panel();
		nudDelayXemThemTo = new System.Windows.Forms.NumericUpDown();
		nudDelayXemThemFrom = new System.Windows.Forms.NumericUpDown();
		A1923DA7 = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		ckbClickXemAnh = new System.Windows.Forms.CheckBox();
		ckbClickXemThem = new System.Windows.Forms.CheckBox();
		C399DC83 = new System.Windows.Forms.Panel();
		E53E7BA0 = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		label2 = new System.Windows.Forms.Label();
		C40536B3 = new System.Windows.Forms.Label();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		tabPage2 = new System.Windows.Forms.TabPage();
		label8 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		nudThoiGianFrom = new System.Windows.Forms.NumericUpDown();
		nudThoiGianTo = new System.Windows.Forms.NumericUpDown();
		ED35DB1E = new System.Windows.Forms.ComboBox();
		D69F5081 = new System.Windows.Forms.NumericUpDown();
		AC9DE9AB = new System.Windows.Forms.NumericUpDown();
		B2BD1514 = new System.Windows.Forms.TextBox();
		F72AE790 = new System.Windows.Forms.Label();
		C5AA7032 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		A50756BF = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		BC34FBA2 = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A0A098A0 = new System.Windows.Forms.Panel();
		txtIdNhom = new System.Windows.Forms.RichTextBox();
		lblIdNhom = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		nudFeedGroupLuotToiDa = new System.Windows.Forms.NumericUpDown();
		ckbFeedGroup = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DDA89B96).BeginInit();
		AE94D1A9.SuspendLayout();
		B185ABB6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E391D534).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemAnhFrom).BeginInit();
		plClickXemThem.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemFrom).BeginInit();
		C399DC83.SuspendLayout();
		E53E7BA0.SuspendLayout();
		tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)D69F5081).BeginInit();
		((System.ComponentModel.ISupportInitialize)AC9DE9AB).BeginInit();
		bunifuCards1.SuspendLayout();
		A0A098A0.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudFeedGroupLuotToiDa).BeginInit();
		SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(716, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Bài viết Newsfeed";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B09EF1A8.Fixed = true;
		B09EF1A8.Horizontal = true;
		B09EF1A8.TargetControl = pnlHeader;
		B09EF1A8.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(DDA89B96);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(716, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(685, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		DDA89B96.Cursor = System.Windows.Forms.Cursors.Default;
		DDA89B96.Image = Class155.DD225F0D;
		DDA89B96.Location = new System.Drawing.Point(3, 2);
		DDA89B96.Name = "pictureBox1";
		DDA89B96.Size = new System.Drawing.Size(34, 27);
		DDA89B96.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		DDA89B96.TabIndex = 76;
		DDA89B96.TabStop = false;
		DDA89B96.Click += new System.EventHandler(B5189338);
		AE94D1A9.BackColor = System.Drawing.Color.White;
		AE94D1A9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		AE94D1A9.Controls.Add(plTuongTacBaiViet);
		AE94D1A9.Controls.Add(B185ABB6);
		AE94D1A9.Controls.Add(plClickXemThem);
		AE94D1A9.Controls.Add(ckbClickXemAnh);
		AE94D1A9.Controls.Add(ckbClickXemThem);
		AE94D1A9.Controls.Add(C399DC83);
		AE94D1A9.Controls.Add(ED35DB1E);
		AE94D1A9.Controls.Add(D69F5081);
		AE94D1A9.Controls.Add(AC9DE9AB);
		AE94D1A9.Controls.Add(B2BD1514);
		AE94D1A9.Controls.Add(F72AE790);
		AE94D1A9.Controls.Add(C5AA7032);
		AE94D1A9.Controls.Add(label4);
		AE94D1A9.Controls.Add(A50756BF);
		AE94D1A9.Controls.Add(btnCancel);
		AE94D1A9.Controls.Add(BC34FBA2);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		AE94D1A9.Controls.Add(pnlTopAccent);
		AE94D1A9.Controls.Add(bunifuCards1);
		AE94D1A9.Controls.Add(A0A098A0);
		AE94D1A9.Controls.Add(ckbFeedGroup);
		AE94D1A9.Cursor = System.Windows.Forms.Cursors.Arrow;
		AE94D1A9.Dock = System.Windows.Forms.DockStyle.Fill;
		AE94D1A9.Location = new System.Drawing.Point(0, 0);
		AE94D1A9.Name = "panel1";
		AE94D1A9.Size = new System.Drawing.Size(719, 552);
		AE94D1A9.TabIndex = 0;
		AE94D1A9.Paint += new System.Windows.Forms.PaintEventHandler(AE94D1A9_Paint);
		plTuongTacBaiViet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		plTuongTacBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuongTacBaiViet.Location = new System.Drawing.Point(30, 227);
		plTuongTacBaiViet.Name = "plTuongTacBaiViet";
		plTuongTacBaiViet.Size = new System.Drawing.Size(657, 266);
		plTuongTacBaiViet.TabIndex = 193;
		B185ABB6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B185ABB6.Controls.Add(E391D534);
		B185ABB6.Controls.Add(nudDelayXemAnhFrom);
		B185ABB6.Controls.Add(label11);
		B185ABB6.Controls.Add(label16);
		B185ABB6.Location = new System.Drawing.Point(381, 188);
		B185ABB6.Name = "plClickXemAnh";
		B185ABB6.Size = new System.Drawing.Size(306, 33);
		B185ABB6.TabIndex = 204;
		E391D534.Location = new System.Drawing.Point(198, 4);
		E391D534.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		E391D534.Name = "nudDelayXemAnhTo";
		E391D534.Size = new System.Drawing.Size(56, 23);
		E391D534.TabIndex = 40;
		nudDelayXemAnhFrom.Location = new System.Drawing.Point(101, 4);
		nudDelayXemAnhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemAnhFrom.Name = "nudDelayXemAnhFrom";
		nudDelayXemAnhFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayXemAnhFrom.TabIndex = 39;
		label11.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(163, 6);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(29, 16);
		label11.TabIndex = 43;
		label11.Text = ">";
		label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(3, 6);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(92, 16);
		label16.TabIndex = 41;
		label16.Text = "Delay time (s):";
		plClickXemThem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plClickXemThem.Controls.Add(nudDelayXemThemTo);
		plClickXemThem.Controls.Add(nudDelayXemThemFrom);
		plClickXemThem.Controls.Add(A1923DA7);
		plClickXemThem.Controls.Add(label18);
		plClickXemThem.Location = new System.Drawing.Point(30, 188);
		plClickXemThem.Name = "plClickXemThem";
		plClickXemThem.Size = new System.Drawing.Size(262, 33);
		plClickXemThem.TabIndex = 205;
		nudDelayXemThemTo.Location = new System.Drawing.Point(198, 4);
		nudDelayXemThemTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemThemTo.Name = "nudDelayXemThemTo";
		nudDelayXemThemTo.Size = new System.Drawing.Size(56, 23);
		nudDelayXemThemTo.TabIndex = 40;
		nudDelayXemThemFrom.Location = new System.Drawing.Point(101, 4);
		nudDelayXemThemFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayXemThemFrom.Name = "nudDelayXemThemFrom";
		nudDelayXemThemFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayXemThemFrom.TabIndex = 39;
		A1923DA7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A1923DA7.Location = new System.Drawing.Point(163, 6);
		A1923DA7.Name = "label17";
		A1923DA7.Size = new System.Drawing.Size(29, 16);
		A1923DA7.TabIndex = 43;
		A1923DA7.Text = ">";
		A1923DA7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label18.AutoSize = true;
		label18.Location = new System.Drawing.Point(3, 6);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(92, 16);
		label18.TabIndex = 41;
		label18.Text = "Delay time (s):";
		ckbClickXemAnh.AutoSize = true;
		ckbClickXemAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbClickXemAnh.Location = new System.Drawing.Point(381, 166);
		ckbClickXemAnh.Name = "ckbClickXemAnh";
		ckbClickXemAnh.Size = new System.Drawing.Size(88, 20);
		ckbClickXemAnh.TabIndex = 202;
		ckbClickXemAnh.Text = "Click Photo";
		ckbClickXemAnh.UseVisualStyleBackColor = true;
		ckbClickXemAnh.CheckedChanged += new System.EventHandler(D3048512);
		ckbClickXemThem.AutoSize = true;
		ckbClickXemThem.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbClickXemThem.Location = new System.Drawing.Point(30, 166);
		ckbClickXemThem.Name = "ckbClickXemThem";
		ckbClickXemThem.Size = new System.Drawing.Size(112, 20);
		ckbClickXemThem.TabIndex = 203;
		ckbClickXemThem.Text = "Click See more";
		ckbClickXemThem.UseVisualStyleBackColor = true;
		ckbClickXemThem.CheckedChanged += new System.EventHandler(ckbClickXemThem_CheckedChanged);
		C399DC83.Controls.Add(E53E7BA0);
		C399DC83.Location = new System.Drawing.Point(28, 108);
		C399DC83.Name = "panel2";
		C399DC83.Size = new System.Drawing.Size(266, 23);
		C399DC83.TabIndex = 199;
		E53E7BA0.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		E53E7BA0.Controls.Add(tabPage1);
		E53E7BA0.Controls.Add(tabPage2);
		E53E7BA0.Location = new System.Drawing.Point(-5, -5);
		E53E7BA0.Name = "tabOptionsPost";
		E53E7BA0.SelectedIndex = 0;
		E53E7BA0.Size = new System.Drawing.Size(276, 54);
		E53E7BA0.TabIndex = 198;
		tabPage1.Controls.Add(label2);
		tabPage1.Controls.Add(C40536B3);
		tabPage1.Controls.Add(nudSoLuongFrom);
		tabPage1.Controls.Add(nudSoLuongTo);
		tabPage1.Location = new System.Drawing.Point(4, 4);
		tabPage1.Name = "tabPage1";
		tabPage1.Padding = new System.Windows.Forms.Padding(3);
		tabPage1.Size = new System.Drawing.Size(268, 25);
		tabPage1.TabIndex = 0;
		tabPage1.Text = "tabPage1";
		tabPage1.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(0, 3);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 16);
		label2.TabIndex = 32;
		label2.Text = "Sô\u0301 lươ\u0323ng ba\u0300i:";
		C40536B3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C40536B3.Location = new System.Drawing.Point(172, 3);
		C40536B3.Name = "label3";
		C40536B3.Size = new System.Drawing.Size(29, 16);
		C40536B3.TabIndex = 1;
		C40536B3.Text = ">";
		C40536B3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongFrom.Location = new System.Drawing.Point(110, 1);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 0;
		nudSoLuongTo.Location = new System.Drawing.Point(207, 1);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		tabPage2.Controls.Add(label8);
		tabPage2.Controls.Add(label9);
		tabPage2.Controls.Add(nudThoiGianFrom);
		tabPage2.Controls.Add(nudThoiGianTo);
		tabPage2.Location = new System.Drawing.Point(4, 4);
		tabPage2.Name = "tabPage2";
		tabPage2.Padding = new System.Windows.Forms.Padding(3);
		tabPage2.Size = new System.Drawing.Size(268, 28);
		tabPage2.TabIndex = 1;
		tabPage2.Text = "tabPage2";
		tabPage2.UseVisualStyleBackColor = true;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(0, 3);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(85, 16);
		label8.TabIndex = 40;
		label8.Text = "Thơ\u0300i gian (s):";
		label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(172, 3);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(29, 16);
		label9.TabIndex = 41;
		label9.Text = ">";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudThoiGianFrom.Location = new System.Drawing.Point(110, 1);
		nudThoiGianFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianFrom.Name = "nudThoiGianFrom";
		nudThoiGianFrom.Size = new System.Drawing.Size(56, 23);
		nudThoiGianFrom.TabIndex = 38;
		nudThoiGianTo.Location = new System.Drawing.Point(207, 1);
		nudThoiGianTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudThoiGianTo.Name = "nudThoiGianTo";
		nudThoiGianTo.Size = new System.Drawing.Size(56, 23);
		nudThoiGianTo.TabIndex = 39;
		ED35DB1E.Cursor = System.Windows.Forms.Cursors.Hand;
		ED35DB1E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		ED35DB1E.DropDownWidth = 200;
		ED35DB1E.FormattingEnabled = true;
		ED35DB1E.Location = new System.Drawing.Point(137, 78);
		ED35DB1E.Name = "cbbOptionsPost";
		ED35DB1E.Size = new System.Drawing.Size(153, 24);
		ED35DB1E.TabIndex = 1;
		ED35DB1E.SelectedIndexChanged += new System.EventHandler(FA064927);
		D69F5081.Location = new System.Drawing.Point(234, 138);
		D69F5081.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		D69F5081.Name = "nudDelayTo";
		D69F5081.Size = new System.Drawing.Size(56, 23);
		D69F5081.TabIndex = 4;
		AC9DE9AB.Location = new System.Drawing.Point(137, 138);
		AC9DE9AB.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AC9DE9AB.Name = "nudDelayFrom";
		AC9DE9AB.Size = new System.Drawing.Size(56, 23);
		AC9DE9AB.TabIndex = 2;
		B2BD1514.Location = new System.Drawing.Point(137, 49);
		B2BD1514.Name = "txtTenHanhDong";
		B2BD1514.Size = new System.Drawing.Size(153, 23);
		B2BD1514.TabIndex = 0;
		F72AE790.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F72AE790.Location = new System.Drawing.Point(199, 140);
		F72AE790.Name = "label7";
		F72AE790.Size = new System.Drawing.Size(29, 16);
		F72AE790.TabIndex = 3;
		F72AE790.Text = ">";
		F72AE790.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C5AA7032.AutoSize = true;
		C5AA7032.Location = new System.Drawing.Point(27, 140);
		C5AA7032.Name = "label5";
		C5AA7032.Size = new System.Drawing.Size(87, 16);
		C5AA7032.TabIndex = 34;
		C5AA7032.Text = "Gia\u0303n ca\u0301ch (s):";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 81);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(64, 16);
		label4.TabIndex = 32;
		label4.Text = "Tu\u0300y cho\u0323n:";
		A50756BF.AutoSize = true;
		A50756BF.Location = new System.Drawing.Point(27, 52);
		A50756BF.Name = "label1";
		A50756BF.Size = new System.Drawing.Size(98, 16);
		A50756BF.TabIndex = 31;
		A50756BF.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(367, 509);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(DF927030);
		BC34FBA2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BC34FBA2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		BC34FBA2.Cursor = System.Windows.Forms.Cursors.Hand;
		BC34FBA2.FlatAppearance.BorderSize = 0;
		BC34FBA2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BC34FBA2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BC34FBA2.ForeColor = System.Drawing.Color.White;
		BC34FBA2.Location = new System.Drawing.Point(260, 509);
		BC34FBA2.Name = "btnAdd";
		BC34FBA2.Size = new System.Drawing.Size(92, 29);
		BC34FBA2.TabIndex = 9;
		BC34FBA2.Text = "Thêm";
		BC34FBA2.UseVisualStyleBackColor = false;
		BC34FBA2.Click += new System.EventHandler(BC34FBA2_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(716, 37);
		bunifuCards1.TabIndex = 28;
		A0A098A0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A0A098A0.Controls.Add(txtIdNhom);
		A0A098A0.Controls.Add(lblIdNhom);
		A0A098A0.Controls.Add(label14);
		A0A098A0.Controls.Add(label15);
		A0A098A0.Controls.Add(nudFeedGroupLuotToiDa);
		A0A098A0.Location = new System.Drawing.Point(381, 74);
		A0A098A0.Name = "plFeedGroup";
		A0A098A0.Size = new System.Drawing.Size(306, 86);
		A0A098A0.TabIndex = 195;
		txtIdNhom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIdNhom.Location = new System.Drawing.Point(7, 25);
		txtIdNhom.Name = "txtIdNhom";
		txtIdNhom.Size = new System.Drawing.Size(291, 55);
		txtIdNhom.TabIndex = 0;
		txtIdNhom.Text = "";
		txtIdNhom.WordWrap = false;
		txtIdNhom.TextChanged += new System.EventHandler(B11D1315);
		lblIdNhom.AutoSize = true;
		lblIdNhom.Location = new System.Drawing.Point(3, 5);
		lblIdNhom.Name = "lblIdNhom";
		lblIdNhom.Size = new System.Drawing.Size(143, 16);
		lblIdNhom.TabIndex = 0;
		lblIdNhom.Text = "Danh sa\u0301ch Id nho\u0301m (0):";
		label14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		label14.AutoSize = true;
		label14.Location = new System.Drawing.Point(276, 5);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(24, 16);
		label14.TabIndex = 32;
		label14.Text = "ba\u0300i";
		label15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(161, 5);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(73, 16);
		label15.TabIndex = 32;
		label15.Text = "Lươ\u0301t tô\u0301i đa:";
		nudFeedGroupLuotToiDa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		nudFeedGroupLuotToiDa.Location = new System.Drawing.Point(234, 1);
		nudFeedGroupLuotToiDa.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudFeedGroupLuotToiDa.Name = "nudFeedGroupLuotToiDa";
		nudFeedGroupLuotToiDa.Size = new System.Drawing.Size(42, 23);
		nudFeedGroupLuotToiDa.TabIndex = 1;
		nudFeedGroupLuotToiDa.Value = new decimal(new int[4] { 50, 0, 0, 0 });
		ckbFeedGroup.AutoSize = true;
		ckbFeedGroup.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFeedGroup.Location = new System.Drawing.Point(381, 51);
		ckbFeedGroup.Name = "ckbFeedGroup";
		ckbFeedGroup.Size = new System.Drawing.Size(257, 20);
		ckbFeedGroup.TabIndex = 196;
		ckbFeedGroup.Text = "Chi\u0309 tương ta\u0301c vơ\u0301i ba\u0300i viê\u0301t cu\u0309a group sau:";
		ckbFeedGroup.UseVisualStyleBackColor = true;
		ckbFeedGroup.CheckedChanged += new System.EventHandler(BA069996);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(719, 552);
		base.Controls.Add(AE94D1A9);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBaiVietNewsfeed2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(E0B6C73F);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)DDA89B96).EndInit();
		AE94D1A9.ResumeLayout(false);
		AE94D1A9.PerformLayout();
		B185ABB6.ResumeLayout(false);
		B185ABB6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)E391D534).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemAnhFrom).EndInit();
		plClickXemThem.ResumeLayout(false);
		plClickXemThem.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayXemThemFrom).EndInit();
		C399DC83.ResumeLayout(false);
		E53E7BA0.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudThoiGianTo).EndInit();
		((System.ComponentModel.ISupportInitialize)D69F5081).EndInit();
		((System.ComponentModel.ISupportInitialize)AC9DE9AB).EndInit();
		bunifuCards1.ResumeLayout(false);
		A0A098A0.ResumeLayout(false);
		A0A098A0.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudFeedGroupLuotToiDa).EndInit();
		ResumeLayout(false);
	}
}
