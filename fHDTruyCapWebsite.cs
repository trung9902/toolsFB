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

public class fHDTruyCapWebsite : Form
{
	internal GClass4 gclass4_0 = null;

	internal Panel pnlTopAccent;

	internal string BC204198;

	internal string string_0;

	internal string F988B41D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer B73CF4B0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl B1268725;

	internal Panel AD119E0A;

	internal TextBox CE1DB6AB;

	internal Label AB066338;

	internal Button F709F8B2;

	internal Button C1013CBA;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox AA363CB2;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label lblStatus;

	internal RichTextBox E73F799D;

	internal NumericUpDown CA9292B2;

	internal NumericUpDown BF2D2D8B;

	internal NumericUpDown nudCountLinkClickFrom;

	internal NumericUpDown CB3F4B22;

	internal Label C62D1E04;

	internal Label label13;

	internal Label label16;

	internal Label label11;

	internal Label C3BDE6B6;

	internal Label label9;

	internal CheckBox ckbLuot;

	internal NumericUpDown B11FB92C;

	internal Label AB325F1E;

	internal Label C2387C2A;

	internal Label label4;

	internal NumericUpDown nudCountTimeScrollFrom;

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

	public fHDTruyCapWebsite(string string_1, string string_2 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		BC204198 = string_1;
		F988B41D = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_3 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			CE1DB6AB.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			string_3 = dataTable2.Rows[0]["CauHinh"].ToString();
			C1013CBA.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			CE1DB6AB.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_3, F79F9AB5: true);
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

	private void fHDTruyCapWebsite_Load(object sender, EventArgs e)
	{
		try
		{
			CB3F4B22.Value = gclass4_0.method_2("nudCountLinkFrom", 1);
			BF2D2D8B.Value = gclass4_0.method_2("nudCountLinkTo", 1);
			nudCountLinkClickFrom.Value = gclass4_0.method_2("nudCountLinkClickFrom", 3);
			CA9292B2.Value = gclass4_0.method_2("nudCountLinkClickTo", 5);
			nudCountTimeScrollFrom.Value = gclass4_0.method_2("nudCountTimeScrollFrom", 30);
			B11FB92C.Value = gclass4_0.method_2("nudCountTimeScrollTo", 30);
			E73F799D.Text = gclass4_0.BDB80B23("txtLinkWeb");
			ckbLuot.Checked = gclass4_0.method_3("ckbLuot", C9B3010F: true);
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C0209B88(object sender, EventArgs e)
	{
		string text = CE1DB6AB.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudCountLinkFrom", CB3F4B22.Value);
		gClass.method_4("nudCountLinkTo", BF2D2D8B.Value);
		gClass.method_4("nudCountLinkClickFrom", nudCountLinkClickFrom.Value);
		gClass.method_4("nudCountLinkClickTo", CA9292B2.Value);
		gClass.method_4("nudCountTimeScrollFrom", nudCountTimeScrollFrom.Value);
		gClass.method_4("nudCountTimeScrollTo", B11FB92C.Value);
		gClass.method_4("txtLinkWeb", E73F799D.Text.Trim());
		gClass.method_4("ckbLuot", ckbLuot.Checked);
		string text2 = gClass.ED11179C();
		if (F988B41D == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(BC204198, text, string_0, text2))
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
			if (Class154.smethod_13(F988B41D, text, text2))
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

	private void F709F8B2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AD119E0A_Paint(object sender, PaintEventArgs e)
	{
		if (AD119E0A.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, AD119E0A.ClientSize.Width - num, AD119E0A.ClientSize.Height - num));
		}
	}

	private void C9A58E0E(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = E73F799D.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Link Web ({0}):"), list_.Count.ToString());
		}
		catch
		{
		}
	}

	protected override void Dispose(bool A381BBA6)
	{
		if (A381BBA6 && B73CF4B0 != null)
		{
			B73CF4B0.Dispose();
		}
		base.Dispose(A381BBA6);
	}

	private void InitializeComponent()
	{
		B73CF4B0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDTruyCapWebsite));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(B73CF4B0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		B1268725 = new Bunifu.Framework.UI.BunifuDragControl(B73CF4B0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		AA363CB2 = new System.Windows.Forms.PictureBox();
		AD119E0A = new System.Windows.Forms.Panel();
		B11FB92C = new System.Windows.Forms.NumericUpDown();
		AB325F1E = new System.Windows.Forms.Label();
		C2387C2A = new System.Windows.Forms.Label();
		ckbLuot = new System.Windows.Forms.CheckBox();
		label4 = new System.Windows.Forms.Label();
		E73F799D = new System.Windows.Forms.RichTextBox();
		nudCountTimeScrollFrom = new System.Windows.Forms.NumericUpDown();
		lblStatus = new System.Windows.Forms.Label();
		CA9292B2 = new System.Windows.Forms.NumericUpDown();
		BF2D2D8B = new System.Windows.Forms.NumericUpDown();
		nudCountLinkClickFrom = new System.Windows.Forms.NumericUpDown();
		CB3F4B22 = new System.Windows.Forms.NumericUpDown();
		CE1DB6AB = new System.Windows.Forms.TextBox();
		C62D1E04 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		C3BDE6B6 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		AB066338 = new System.Windows.Forms.Label();
		F709F8B2 = new System.Windows.Forms.Button();
		C1013CBA = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AA363CB2).BeginInit();
		AD119E0A.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B11FB92C).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountTimeScrollFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)CA9292B2).BeginInit();
		((System.ComponentModel.ISupportInitialize)BF2D2D8B).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountLinkClickFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)CB3F4B22).BeginInit();
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
		bunifuCustomLabel1.Text = "Cấu hình Truy cập Website";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B1268725.Fixed = true;
		B1268725.Horizontal = true;
		B1268725.TargetControl = pnlHeader;
		B1268725.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(AA363CB2);
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
		System.Drawing.Image iconClose_fHDTr = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDTr != null) button1.Image = iconClose_fHDTr;
		AA363CB2.Cursor = System.Windows.Forms.Cursors.Default;
		AA363CB2.Image = Class155.DD225F0D;
		AA363CB2.Location = new System.Drawing.Point(3, 2);
		AA363CB2.Name = "pictureBox1";
		AA363CB2.Size = new System.Drawing.Size(34, 27);
		AA363CB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AA363CB2.TabIndex = 76;
		AA363CB2.TabStop = false;
		System.Drawing.Image iconApp_fHDTr = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDTr != null) AA363CB2.Image = iconApp_fHDTr;
		AD119E0A.BackColor = System.Drawing.Color.White;
		AD119E0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		AD119E0A.Controls.Add(pnlTopAccent);
		AD119E0A.Controls.Add(B11FB92C);
		AD119E0A.Controls.Add(AB325F1E);
		AD119E0A.Controls.Add(C2387C2A);
		AD119E0A.Controls.Add(ckbLuot);
		AD119E0A.Controls.Add(label4);
		AD119E0A.Controls.Add(E73F799D);
		AD119E0A.Controls.Add(nudCountTimeScrollFrom);
		AD119E0A.Controls.Add(lblStatus);
		AD119E0A.Controls.Add(CA9292B2);
		AD119E0A.Controls.Add(BF2D2D8B);
		AD119E0A.Controls.Add(nudCountLinkClickFrom);
		AD119E0A.Controls.Add(CB3F4B22);
		AD119E0A.Controls.Add(CE1DB6AB);
		AD119E0A.Controls.Add(C62D1E04);
		AD119E0A.Controls.Add(label13);
		AD119E0A.Controls.Add(label16);
		AD119E0A.Controls.Add(label11);
		AD119E0A.Controls.Add(C3BDE6B6);
		AD119E0A.Controls.Add(label9);
		AD119E0A.Controls.Add(AB066338);
		AD119E0A.Controls.Add(F709F8B2);
		AD119E0A.Controls.Add(C1013CBA);
		AD119E0A.Controls.Add(bunifuCards1);
		AD119E0A.Cursor = System.Windows.Forms.Cursors.Arrow;
		AD119E0A.Dock = System.Windows.Forms.DockStyle.Fill;
		AD119E0A.Location = new System.Drawing.Point(0, 0);
		AD119E0A.Name = "panel1";
		AD119E0A.Size = new System.Drawing.Size(362, 419);
		AD119E0A.TabIndex = 0;
		AD119E0A.Paint += new System.Windows.Forms.PaintEventHandler(AD119E0A_Paint);
		B11FB92C.Location = new System.Drawing.Point(263, 316);
		B11FB92C.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		B11FB92C.Name = "nudCountTimeScrollTo";
		B11FB92C.Size = new System.Drawing.Size(36, 23);
		B11FB92C.TabIndex = 2;
		AB325F1E.AutoSize = true;
		AB325F1E.Location = new System.Drawing.Point(28, 318);
		AB325F1E.Name = "label2";
		AB325F1E.Size = new System.Drawing.Size(120, 16);
		AB325F1E.TabIndex = 32;
		AB325F1E.Text = "Thời gian trên web:";
		C2387C2A.AutoSize = true;
		C2387C2A.Location = new System.Drawing.Point(299, 318);
		C2387C2A.Name = "label3";
		C2387C2A.Size = new System.Drawing.Size(30, 16);
		C2387C2A.TabIndex = 35;
		C2387C2A.Text = "giây";
		ckbLuot.AutoSize = true;
		ckbLuot.Checked = true;
		ckbLuot.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbLuot.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLuot.Location = new System.Drawing.Point(30, 343);
		ckbLuot.Name = "ckbLuot";
		ckbLuot.Size = new System.Drawing.Size(157, 20);
		ckbLuot.TabIndex = 43;
		ckbLuot.Text = "Tự động lướt trên Web";
		ckbLuot.UseVisualStyleBackColor = true;
		label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(231, 318);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(29, 16);
		label4.TabIndex = 37;
		label4.Text = ">";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E73F799D.Location = new System.Drawing.Point(30, 94);
		E73F799D.Name = "txtLinkWeb";
		E73F799D.Size = new System.Drawing.Size(298, 160);
		E73F799D.TabIndex = 42;
		E73F799D.Text = "";
		E73F799D.WordWrap = false;
		E73F799D.TextChanged += new System.EventHandler(C9A58E0E);
		nudCountTimeScrollFrom.Location = new System.Drawing.Point(192, 316);
		nudCountTimeScrollFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountTimeScrollFrom.Name = "nudCountTimeScrollFrom";
		nudCountTimeScrollFrom.Size = new System.Drawing.Size(36, 23);
		nudCountTimeScrollFrom.TabIndex = 1;
		lblStatus.AutoSize = true;
		lblStatus.Location = new System.Drawing.Point(27, 75);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(148, 16);
		lblStatus.TabIndex = 0;
		lblStatus.Text = "Danh sa\u0301ch Link Web (0):";
		CA9292B2.Location = new System.Drawing.Point(263, 288);
		CA9292B2.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CA9292B2.Name = "nudCountLinkClickTo";
		CA9292B2.Size = new System.Drawing.Size(36, 23);
		CA9292B2.TabIndex = 2;
		BF2D2D8B.Location = new System.Drawing.Point(263, 260);
		BF2D2D8B.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		BF2D2D8B.Name = "nudCountLinkTo";
		BF2D2D8B.Size = new System.Drawing.Size(36, 23);
		BF2D2D8B.TabIndex = 2;
		nudCountLinkClickFrom.Location = new System.Drawing.Point(192, 288);
		nudCountLinkClickFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountLinkClickFrom.Name = "nudCountLinkClickFrom";
		nudCountLinkClickFrom.Size = new System.Drawing.Size(36, 23);
		nudCountLinkClickFrom.TabIndex = 1;
		CB3F4B22.Location = new System.Drawing.Point(192, 260);
		CB3F4B22.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CB3F4B22.Name = "nudCountLinkFrom";
		CB3F4B22.Size = new System.Drawing.Size(36, 23);
		CB3F4B22.TabIndex = 1;
		CE1DB6AB.Location = new System.Drawing.Point(134, 49);
		CE1DB6AB.Name = "txtTenHanhDong";
		CE1DB6AB.Size = new System.Drawing.Size(194, 23);
		CE1DB6AB.TabIndex = 0;
		C62D1E04.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C62D1E04.Location = new System.Drawing.Point(231, 290);
		C62D1E04.Name = "label17";
		C62D1E04.Size = new System.Drawing.Size(29, 16);
		C62D1E04.TabIndex = 37;
		C62D1E04.Text = ">";
		C62D1E04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(231, 262);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(29, 16);
		label13.TabIndex = 37;
		label13.Text = ">";
		label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(299, 290);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(26, 16);
		label16.TabIndex = 35;
		label16.Text = "link";
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(299, 262);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(26, 16);
		label11.TabIndex = 35;
		label11.Text = "link";
		C3BDE6B6.AutoSize = true;
		C3BDE6B6.Location = new System.Drawing.Point(28, 290);
		C3BDE6B6.Name = "label15";
		C3BDE6B6.Size = new System.Drawing.Size(164, 16);
		C3BDE6B6.TabIndex = 34;
		C3BDE6B6.Text = "Click random link trên web:";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 262);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(152, 16);
		label9.TabIndex = 32;
		label9.Text = "Sô\u0301 link web cần truy cập:";
		AB066338.AutoSize = true;
		AB066338.Location = new System.Drawing.Point(27, 52);
		AB066338.Name = "label1";
		AB066338.Size = new System.Drawing.Size(98, 16);
		AB066338.TabIndex = 31;
		AB066338.Text = "Tên ha\u0300nh đô\u0323ng:";
		F709F8B2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F709F8B2.BackColor = System.Drawing.Color.Maroon;
		F709F8B2.Cursor = System.Windows.Forms.Cursors.Hand;
		F709F8B2.FlatAppearance.BorderSize = 0;
		F709F8B2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F709F8B2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F709F8B2.ForeColor = System.Drawing.Color.White;
		F709F8B2.Location = new System.Drawing.Point(189, 375);
		F709F8B2.Name = "btnCancel";
		F709F8B2.Size = new System.Drawing.Size(92, 29);
		F709F8B2.TabIndex = 10;
		F709F8B2.Text = "Đóng";
		F709F8B2.UseVisualStyleBackColor = false;
		F709F8B2.Click += new System.EventHandler(F709F8B2_Click);
		C1013CBA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		C1013CBA.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		C1013CBA.Cursor = System.Windows.Forms.Cursors.Hand;
		C1013CBA.FlatAppearance.BorderSize = 0;
		C1013CBA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C1013CBA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C1013CBA.ForeColor = System.Drawing.Color.White;
		C1013CBA.Location = new System.Drawing.Point(82, 375);
		C1013CBA.Name = "btnAdd";
		C1013CBA.Size = new System.Drawing.Size(92, 29);
		C1013CBA.TabIndex = 9;
		C1013CBA.Text = "Thêm";
		C1013CBA.UseVisualStyleBackColor = false;
		C1013CBA.Click += new System.EventHandler(C0209B88);
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
		base.ClientSize = new System.Drawing.Size(362, 419);
		base.Controls.Add(AD119E0A);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDTruyCapWebsite";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDTruyCapWebsite_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AA363CB2).EndInit();
		AD119E0A.ResumeLayout(false);
		AD119E0A.PerformLayout();
		((System.ComponentModel.ISupportInitialize)B11FB92C).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountTimeScrollFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)CA9292B2).EndInit();
		((System.ComponentModel.ISupportInitialize)BF2D2D8B).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountLinkClickFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)CB3F4B22).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
