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

public class fHDTimKiemGoogle : Form
{
	internal GClass4 gclass4_0 = null;

	internal Panel pnlTopAccent;

	internal string E53EE726;

	internal string string_0;

	internal string E5BE4483;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer A2A2E19B = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label2;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label lblStatus;

	internal RichTextBox txtTuKhoa;

	internal NumericUpDown nudCountTimeScrollTo;

	internal NumericUpDown nudCountLinkClickTo;

	internal NumericUpDown nudCountPageTo;

	internal NumericUpDown nudCountTuKhoaTo;

	internal NumericUpDown nudCountTimeScrollFrom;

	internal NumericUpDown C2A29BA9;

	internal NumericUpDown nudCountPageFrom;

	internal NumericUpDown CD093925;

	internal Label label4;

	internal Label label17;

	internal Label label14;

	internal Label label3;

	internal Label label13;

	internal Label EA21FB21;

	internal Label EB81E6B8;

	internal Label FD8BE393;

	internal Label F29D630D;

	internal Label D4207B3C;

	internal Label label9;

	public static bool B1AC4414
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

	public fHDTimKiemGoogle(string string_1, string A509953D = "")
	{
		InitializeComponent();
		B1AC4414 = false;
		E53EE726 = string_1;
		E5BE4483 = A509953D;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (A509953D == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(A509953D);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
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

	private void F3BFC809(object sender, EventArgs e)
	{
		try
		{
			CD093925.Value = gclass4_0.method_2("nudCountTuKhoaFrom", 1);
			nudCountTuKhoaTo.Value = gclass4_0.method_2("nudCountTuKhoaTo", 1);
			nudCountPageFrom.Value = gclass4_0.method_2("nudCountPageFrom", 3);
			nudCountPageTo.Value = gclass4_0.method_2("nudCountPageTo", 3);
			C2A29BA9.Value = gclass4_0.method_2("nudCountLinkClickFrom", 3);
			nudCountLinkClickTo.Value = gclass4_0.method_2("nudCountLinkClickTo", 5);
			nudCountTimeScrollFrom.Value = gclass4_0.method_2("nudCountTimeScrollFrom", 30);
			nudCountTimeScrollTo.Value = gclass4_0.method_2("nudCountTimeScrollTo", 30);
			txtTuKhoa.Text = gclass4_0.BDB80B23("txtTuKhoa");
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudCountTuKhoaFrom", CD093925.Value);
		gClass.method_4("nudCountTuKhoaTo", nudCountTuKhoaTo.Value);
		gClass.method_4("nudCountPageFrom", nudCountPageFrom.Value);
		gClass.method_4("nudCountPageTo", nudCountPageTo.Value);
		gClass.method_4("nudCountLinkClickFrom", C2A29BA9.Value);
		gClass.method_4("nudCountLinkClickTo", nudCountLinkClickTo.Value);
		gClass.method_4("nudCountTimeScrollFrom", nudCountTimeScrollFrom.Value);
		gClass.method_4("nudCountTimeScrollTo", nudCountTimeScrollTo.Value);
		gClass.method_4("txtTuKhoa", txtTuKhoa.Text.Trim());
		string text2 = gClass.ED11179C();
		if (E5BE4483 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(E53EE726, text, string_0, text2))
				{
					B1AC4414 = true;
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
			if (Class154.smethod_13(E5BE4483, text, text2))
			{
				B1AC4414 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void ACAEA49B(object sender, EventArgs e)
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

	private void txtTuKhoa_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = txtTuKhoa.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Tư\u0300 kho\u0301a|Link Web ({0}):"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && A2A2E19B != null)
		{
			A2A2E19B.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		A2A2E19B = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTimKiemGoogle));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(A2A2E19B);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(A2A2E19B);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		nudCountTimeScrollFrom = new System.Windows.Forms.NumericUpDown();
		C2A29BA9 = new System.Windows.Forms.NumericUpDown();
		nudCountPageFrom = new System.Windows.Forms.NumericUpDown();
		CD093925 = new System.Windows.Forms.NumericUpDown();
		txtTuKhoa = new System.Windows.Forms.RichTextBox();
		lblStatus = new System.Windows.Forms.Label();
		nudCountTimeScrollTo = new System.Windows.Forms.NumericUpDown();
		nudCountLinkClickTo = new System.Windows.Forms.NumericUpDown();
		nudCountPageTo = new System.Windows.Forms.NumericUpDown();
		nudCountTuKhoaTo = new System.Windows.Forms.NumericUpDown();
		label4 = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label17 = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		EA21FB21 = new System.Windows.Forms.Label();
		EB81E6B8 = new System.Windows.Forms.Label();
		FD8BE393 = new System.Windows.Forms.Label();
		F29D630D = new System.Windows.Forms.Label();
		D4207B3C = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountTimeScrollFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)C2A29BA9).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountPageFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)CD093925).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountTimeScrollTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountLinkClickTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountPageTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountTuKhoaTo).BeginInit();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Ti\u0300m kiê\u0301m Google";
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
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(328, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		System.Drawing.Image iconClose_fHDTi = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDTi != null) button1.Image = iconClose_fHDTi;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDTi = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDTi != null) pictureBox1.Image = iconApp_fHDTi;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(nudCountTimeScrollFrom);
		panel1.Controls.Add(C2A29BA9);
		panel1.Controls.Add(nudCountPageFrom);
		panel1.Controls.Add(CD093925);
		panel1.Controls.Add(txtTuKhoa);
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(nudCountTimeScrollTo);
		panel1.Controls.Add(nudCountLinkClickTo);
		panel1.Controls.Add(nudCountPageTo);
		panel1.Controls.Add(nudCountTuKhoaTo);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label17);
		panel1.Controls.Add(label14);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label13);
		panel1.Controls.Add(EA21FB21);
		panel1.Controls.Add(EB81E6B8);
		panel1.Controls.Add(FD8BE393);
		panel1.Controls.Add(F29D630D);
		panel1.Controls.Add(D4207B3C);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 413);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		nudCountTimeScrollFrom.Location = new System.Drawing.Point(192, 330);
		nudCountTimeScrollFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountTimeScrollFrom.Name = "nudCountTimeScrollFrom";
		nudCountTimeScrollFrom.Size = new System.Drawing.Size(36, 23);
		nudCountTimeScrollFrom.TabIndex = 1;
		C2A29BA9.Location = new System.Drawing.Point(192, 302);
		C2A29BA9.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C2A29BA9.Name = "nudCountLinkClickFrom";
		C2A29BA9.Size = new System.Drawing.Size(36, 23);
		C2A29BA9.TabIndex = 1;
		nudCountPageFrom.Location = new System.Drawing.Point(192, 274);
		nudCountPageFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountPageFrom.Name = "nudCountPageFrom";
		nudCountPageFrom.Size = new System.Drawing.Size(36, 23);
		nudCountPageFrom.TabIndex = 1;
		CD093925.Location = new System.Drawing.Point(192, 246);
		CD093925.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CD093925.Name = "nudCountTuKhoaFrom";
		CD093925.Size = new System.Drawing.Size(36, 23);
		CD093925.TabIndex = 1;
		txtTuKhoa.Location = new System.Drawing.Point(30, 96);
		txtTuKhoa.Name = "txtTuKhoa";
		txtTuKhoa.Size = new System.Drawing.Size(298, 142);
		txtTuKhoa.TabIndex = 42;
		txtTuKhoa.Text = "";
		txtTuKhoa.WordWrap = false;
		txtTuKhoa.TextChanged += new System.EventHandler(txtTuKhoa_TextChanged);
		lblStatus.AutoSize = true;
		lblStatus.Location = new System.Drawing.Point(27, 77);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(201, 16);
		lblStatus.TabIndex = 0;
		lblStatus.Text = "Danh sa\u0301ch Tư\u0300 kho\u0301a|Link Web (0):";
		nudCountTimeScrollTo.Location = new System.Drawing.Point(248, 330);
		nudCountTimeScrollTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountTimeScrollTo.Name = "nudCountTimeScrollTo";
		nudCountTimeScrollTo.Size = new System.Drawing.Size(36, 23);
		nudCountTimeScrollTo.TabIndex = 2;
		nudCountLinkClickTo.Location = new System.Drawing.Point(248, 302);
		nudCountLinkClickTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountLinkClickTo.Name = "nudCountLinkClickTo";
		nudCountLinkClickTo.Size = new System.Drawing.Size(36, 23);
		nudCountLinkClickTo.TabIndex = 2;
		nudCountPageTo.Location = new System.Drawing.Point(248, 274);
		nudCountPageTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountPageTo.Name = "nudCountPageTo";
		nudCountPageTo.Size = new System.Drawing.Size(36, 23);
		nudCountPageTo.TabIndex = 2;
		nudCountTuKhoaTo.Location = new System.Drawing.Point(248, 246);
		nudCountTuKhoaTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountTuKhoaTo.Name = "nudCountTuKhoaTo";
		nudCountTuKhoaTo.Size = new System.Drawing.Size(36, 23);
		nudCountTuKhoaTo.TabIndex = 2;
		label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(226, 332);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(26, 16);
		label4.TabIndex = 37;
		label4.Text = ">";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
		txtTenHanhDong.TabIndex = 0;
		label17.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(226, 304);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(26, 16);
		label17.TabIndex = 37;
		label17.Text = ">";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label14.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label14.Location = new System.Drawing.Point(226, 276);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(26, 16);
		label14.TabIndex = 37;
		label14.Text = ">";
		label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(284, 332);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(30, 16);
		label3.TabIndex = 35;
		label3.Text = "giây";
		label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(226, 248);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(26, 16);
		label13.TabIndex = 37;
		label13.Text = ">";
		label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		EA21FB21.AutoSize = true;
		EA21FB21.Location = new System.Drawing.Point(284, 304);
		EA21FB21.Name = "label16";
		EA21FB21.Size = new System.Drawing.Size(26, 16);
		EA21FB21.TabIndex = 35;
		EA21FB21.Text = "link";
		EB81E6B8.AutoSize = true;
		EB81E6B8.Location = new System.Drawing.Point(284, 276);
		EB81E6B8.Name = "label12";
		EB81E6B8.Size = new System.Drawing.Size(37, 16);
		EB81E6B8.TabIndex = 35;
		EB81E6B8.Text = "trang";
		FD8BE393.AutoSize = true;
		FD8BE393.Location = new System.Drawing.Point(284, 248);
		FD8BE393.Name = "label11";
		FD8BE393.Size = new System.Drawing.Size(50, 16);
		FD8BE393.TabIndex = 35;
		FD8BE393.Text = "tư\u0300 khóa";
		F29D630D.AutoSize = true;
		F29D630D.Location = new System.Drawing.Point(28, 304);
		F29D630D.Name = "label15";
		F29D630D.Size = new System.Drawing.Size(164, 16);
		F29D630D.TabIndex = 34;
		F29D630D.Text = "Click random link trên web:";
		D4207B3C.AutoSize = true;
		D4207B3C.Location = new System.Drawing.Point(27, 276);
		D4207B3C.Name = "label10";
		D4207B3C.Size = new System.Drawing.Size(150, 16);
		D4207B3C.TabIndex = 34;
		D4207B3C.Text = "Sô\u0301 trang ti\u0300m kiê\u0301m tô\u0301i đa:";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 248);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(120, 16);
		label9.TabIndex = 32;
		label9.Text = "Sô\u0301 tư\u0300 kho\u0301a câ\u0300n ti\u0300m:";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 332);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(146, 16);
		label2.TabIndex = 32;
		label2.Text = "Thơ\u0300i gian lươ\u0301t trên web:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(189, 369);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(ACAEA49B);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 369);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(359, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 413);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTimKiemGoogle";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(F3BFC809);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountTimeScrollFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)C2A29BA9).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountPageFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)CD093925).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountTimeScrollTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountLinkClickTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountPageTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountTuKhoaTo).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
