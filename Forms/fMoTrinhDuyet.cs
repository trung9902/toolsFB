using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fMoTrinhDuyet : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards A813059E;

	internal Panel pnlHeader;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button AD3AD50C;

	internal Button btnCancel;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal Panel DAA9CA2B;

	internal Button btnCauHinh;

	internal Label label3;

	internal Button A0067632;

	internal CheckBox ckbAutoCloseChromeLoginFail;

	internal TextBox C384FE05;

	internal CheckBox ckbAutoOpenLink;

	internal CheckBox FC254DB0;

	internal Panel plAddChromeVaoFormView;

	internal NumericUpDown nudWidthChrome;

	internal Label label35;

	internal Label label33;

	internal NumericUpDown nudHeighChrome;

	internal CheckBox BC9779B4;

	internal Panel CCBF1231;

	internal Label label10;

	internal Label label11;

	internal ComboBox F4396E0A;

	internal ComboBox F22E6E1A;

	internal Panel panel3;

	internal RadioButton rbSuDungProfile;

	internal RadioButton F22AC39B;

	internal Label label1;

	public fMoTrinhDuyet()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private void AD3AD50C_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCauHinh_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCauHinhChung());
	}

	private void fMoTrinhDuyet_Load(object sender, EventArgs e)
	{
		if (C5034B95.smethod_0("configOpenBrowser").method_3("isUseProfile", C9B3010F: true))
		{
			rbSuDungProfile.Checked = true;
		}
		else
		{
			F22AC39B.Checked = true;
		}
		BC9779B4.Checked = C5034B95.smethod_0("configOpenBrowser").method_3("ckbAddChromeIntoForm");
		nudWidthChrome.Value = C5034B95.smethod_0("configOpenBrowser").method_2("nudWidthChrome", 520);
		nudHeighChrome.Value = C5034B95.smethod_0("configOpenBrowser").method_2("nudHeighChrome", 480);
		F4396E0A.Text = C5034B95.smethod_0("configOpenBrowser").BDB80B23("cbbColumnChrome", "5");
		F22E6E1A.Text = C5034B95.smethod_0("configOpenBrowser").BDB80B23("cbbRowChrome", "2");
		ckbAutoCloseChromeLoginFail.Checked = C5034B95.smethod_0("configOpenBrowser").method_3("isAutoCloseChromeLoginFail");
		ckbAutoOpenLink.Checked = C5034B95.smethod_0("configOpenBrowser").method_3("ckbAutoOpenLink");
		C384FE05.Text = C5034B95.smethod_0("configOpenBrowser").BDB80B23("txtLink");
		FC254DB0.Checked = C5034B95.smethod_0("configOpenBrowser").method_3("ckbLoginHotmail");
		C7337D83(null, null);
		method_0(null, null);
		BC9779B4_CheckedChanged(null, null);
	}

	private void D6BE4133(object sender, EventArgs e)
	{
		if (rbSuDungProfile.Checked)
		{
			C5034B95.smethod_0("configOpenBrowser").method_4("isUseProfile", true);
		}
		else
		{
			C5034B95.smethod_0("configOpenBrowser").method_4("isUseProfile", false);
		}
		C5034B95.smethod_0("configOpenBrowser").method_4("ckbAddChromeIntoForm", BC9779B4.Checked);
		C5034B95.smethod_0("configOpenBrowser").method_4("nudWidthChrome", nudWidthChrome.Value);
		C5034B95.smethod_0("configOpenBrowser").method_4("nudHeighChrome", nudHeighChrome.Value);
		C5034B95.smethod_0("configOpenBrowser").method_4("cbbColumnChrome", F4396E0A.Text);
		C5034B95.smethod_0("configOpenBrowser").method_4("cbbRowChrome", F22E6E1A.Text);
		C5034B95.smethod_0("configOpenBrowser").method_4("isAutoCloseChromeLoginFail", ckbAutoCloseChromeLoginFail.Checked);
		C5034B95.smethod_0("configOpenBrowser").method_4("ckbAutoOpenLink", ckbAutoOpenLink.Checked);
		C5034B95.smethod_0("configOpenBrowser").method_4("txtLink", C384FE05.Text);
		C5034B95.smethod_0("configOpenBrowser").method_4("ckbLoginHotmail", FC254DB0.Checked);
		C5034B95.smethod_1("configOpenBrowser");
		Close();
	}

	private void C384FE05_TextChanged(object sender, EventArgs e)
	{
	}

	private void C7337D83(object sender, EventArgs e)
	{
		C384FE05.Enabled = ckbAutoOpenLink.Checked;
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void BC9779B4_CheckedChanged(object sender, EventArgs e)
	{
		plAddChromeVaoFormView.Enabled = BC9779B4.Checked;
		CCBF1231.Enabled = !BC9779B4.Checked;
	}

	private void DAA9CA2B_Paint(object sender, PaintEventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMoTrinhDuyet));
		A813059E = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		AD3AD50C = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		DAA9CA2B = new System.Windows.Forms.Panel();
		CCBF1231 = new System.Windows.Forms.Panel();
		label10 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		F4396E0A = new System.Windows.Forms.ComboBox();
		F22E6E1A = new System.Windows.Forms.ComboBox();
		plAddChromeVaoFormView = new System.Windows.Forms.Panel();
		nudWidthChrome = new System.Windows.Forms.NumericUpDown();
		label35 = new System.Windows.Forms.Label();
		label33 = new System.Windows.Forms.Label();
		nudHeighChrome = new System.Windows.Forms.NumericUpDown();
		BC9779B4 = new System.Windows.Forms.CheckBox();
		FC254DB0 = new System.Windows.Forms.CheckBox();
		C384FE05 = new System.Windows.Forms.TextBox();
		btnCauHinh = new System.Windows.Forms.Button();
		ckbAutoOpenLink = new System.Windows.Forms.CheckBox();
		ckbAutoCloseChromeLoginFail = new System.Windows.Forms.CheckBox();
		A0067632 = new System.Windows.Forms.Button();
		panel3 = new System.Windows.Forms.Panel();
		rbSuDungProfile = new System.Windows.Forms.RadioButton();
		F22AC39B = new System.Windows.Forms.RadioButton();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		A813059E.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		DAA9CA2B.SuspendLayout();
		CCBF1231.SuspendLayout();
		plAddChromeVaoFormView.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudWidthChrome).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudHeighChrome).BeginInit();
		panel3.SuspendLayout();
		SuspendLayout();
		A813059E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A813059E.BackColor = System.Drawing.Color.White;
		A813059E.BorderRadius = 0;
		A813059E.BottomSahddow = true;
		A813059E.color = System.Drawing.Color.SaddleBrown;
		A813059E.Controls.Add(pnlHeader);
		A813059E.LeftSahddow = false;
		A813059E.Location = new System.Drawing.Point(1, 0);
		A813059E.Name = "bunifuCards1";
		A813059E.RightSahddow = true;
		A813059E.ShadowDepth = 20;
		A813059E.Size = new System.Drawing.Size(455, 38);
		A813059E.TabIndex = 0;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(AD3AD50C);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Location = new System.Drawing.Point(0, 5);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(455, 32);
		pnlHeader.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		AD3AD50C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		AD3AD50C.Cursor = System.Windows.Forms.Cursors.Hand;
		AD3AD50C.FlatAppearance.BorderSize = 0;
		AD3AD50C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AD3AD50C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AD3AD50C.ForeColor = System.Drawing.Color.White;
		AD3AD50C.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		AD3AD50C.Location = new System.Drawing.Point(422, -1);
		AD3AD50C.Name = "btnMinimize";
		AD3AD50C.Size = new System.Drawing.Size(32, 32);
		AD3AD50C.TabIndex = 9;
		AD3AD50C.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		AD3AD50C.UseVisualStyleBackColor = true;
		AD3AD50C.Click += new System.EventHandler(AD3AD50C_Click);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(455, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Cấu hình Mở trình duyệt";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(235, 258);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đo\u0301ng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		DAA9CA2B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DAA9CA2B.Controls.Add(CCBF1231);
		DAA9CA2B.Controls.Add(plAddChromeVaoFormView);
		DAA9CA2B.Controls.Add(BC9779B4);
		DAA9CA2B.Controls.Add(FC254DB0);
		DAA9CA2B.Controls.Add(C384FE05);
		DAA9CA2B.Controls.Add(btnCauHinh);
		DAA9CA2B.Controls.Add(ckbAutoOpenLink);
		DAA9CA2B.Controls.Add(ckbAutoCloseChromeLoginFail);
		DAA9CA2B.Controls.Add(A0067632);
		DAA9CA2B.Controls.Add(btnCancel);
		DAA9CA2B.Controls.Add(panel3);
		DAA9CA2B.Controls.Add(label3);
		DAA9CA2B.Controls.Add(label1);
		DAA9CA2B.Dock = System.Windows.Forms.DockStyle.Fill;
		DAA9CA2B.Location = new System.Drawing.Point(0, 0);
		DAA9CA2B.Name = "panel1";
		DAA9CA2B.Size = new System.Drawing.Size(456, 300);
		DAA9CA2B.TabIndex = 5;
		DAA9CA2B.Paint += new System.Windows.Forms.PaintEventHandler(DAA9CA2B_Paint);
		CCBF1231.Controls.Add(label10);
		CCBF1231.Controls.Add(label11);
		CCBF1231.Controls.Add(F4396E0A);
		CCBF1231.Controls.Add(F22E6E1A);
		CCBF1231.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CCBF1231.Location = new System.Drawing.Point(32, 145);
		CCBF1231.Name = "plSapXepCuaSoChrome";
		CCBF1231.Size = new System.Drawing.Size(358, 28);
		CCBF1231.TabIndex = 159;
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(3, 4);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(147, 16);
		label10.TabIndex = 33;
		label10.Text = "Sắp xếp cửa sổ chrome:";
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(245, 2);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(23, 23);
		label11.TabIndex = 33;
		label11.Text = "X";
		F4396E0A.Cursor = System.Windows.Forms.Cursors.Hand;
		F4396E0A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F4396E0A.FormattingEnabled = true;
		F4396E0A.Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
		F4396E0A.Location = new System.Drawing.Point(200, 2);
		F4396E0A.Name = "cbbColumnChrome";
		F4396E0A.Size = new System.Drawing.Size(41, 24);
		F4396E0A.TabIndex = 145;
		F22E6E1A.Cursor = System.Windows.Forms.Cursors.Hand;
		F22E6E1A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F22E6E1A.FormattingEnabled = true;
		F22E6E1A.Items.AddRange(new object[5] { "1", "2", "3", "4", "5" });
		F22E6E1A.Location = new System.Drawing.Point(272, 2);
		F22E6E1A.Name = "cbbRowChrome";
		F22E6E1A.Size = new System.Drawing.Size(41, 24);
		F22E6E1A.TabIndex = 145;
		plAddChromeVaoFormView.Controls.Add(nudWidthChrome);
		plAddChromeVaoFormView.Controls.Add(label35);
		plAddChromeVaoFormView.Controls.Add(label33);
		plAddChromeVaoFormView.Controls.Add(nudHeighChrome);
		plAddChromeVaoFormView.Location = new System.Drawing.Point(224, 118);
		plAddChromeVaoFormView.Name = "plAddChromeVaoFormView";
		plAddChromeVaoFormView.Size = new System.Drawing.Size(175, 27);
		plAddChromeVaoFormView.TabIndex = 158;
		nudWidthChrome.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		nudWidthChrome.Location = new System.Drawing.Point(41, 2);
		nudWidthChrome.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudWidthChrome.Name = "nudWidthChrome";
		nudWidthChrome.Size = new System.Drawing.Size(53, 23);
		nudWidthChrome.TabIndex = 151;
		nudWidthChrome.Value = new decimal(new int[4] { 516, 0, 0, 0 });
		label35.AutoSize = true;
		label35.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label35.Location = new System.Drawing.Point(95, 2);
		label35.Name = "label35";
		label35.Size = new System.Drawing.Size(23, 23);
		label35.TabIndex = 33;
		label35.Text = "X";
		label33.AutoSize = true;
		label33.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label33.Location = new System.Drawing.Point(3, 4);
		label33.Name = "label33";
		label33.Size = new System.Drawing.Size(36, 16);
		label33.TabIndex = 33;
		label33.Text = "Size:";
		nudHeighChrome.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		nudHeighChrome.Location = new System.Drawing.Point(118, 2);
		nudHeighChrome.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudHeighChrome.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudHeighChrome.Name = "nudHeighChrome";
		nudHeighChrome.Size = new System.Drawing.Size(53, 23);
		nudHeighChrome.TabIndex = 151;
		nudHeighChrome.Value = new decimal(new int[4] { 480, 0, 0, 0 });
		BC9779B4.AutoSize = true;
		BC9779B4.Cursor = System.Windows.Forms.Cursors.Hand;
		BC9779B4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		BC9779B4.Location = new System.Drawing.Point(37, 120);
		BC9779B4.Name = "ckbAddChromeIntoForm";
		BC9779B4.Size = new System.Drawing.Size(187, 20);
		BC9779B4.TabIndex = 157;
		BC9779B4.Text = "Add Chrome vào Form View";
		BC9779B4.UseVisualStyleBackColor = true;
		BC9779B4.CheckedChanged += new System.EventHandler(BC9779B4_CheckedChanged);
		FC254DB0.AutoSize = true;
		FC254DB0.Cursor = System.Windows.Forms.Cursors.Hand;
		FC254DB0.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FC254DB0.Location = new System.Drawing.Point(37, 229);
		FC254DB0.Name = "ckbLoginHotmail";
		FC254DB0.Size = new System.Drawing.Size(184, 20);
		FC254DB0.TabIndex = 25;
		FC254DB0.Text = "Tự động đăng nhập hotmail";
		FC254DB0.UseVisualStyleBackColor = true;
		C384FE05.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C384FE05.Location = new System.Drawing.Point(183, 201);
		C384FE05.Name = "txtLink";
		C384FE05.Size = new System.Drawing.Size(233, 23);
		C384FE05.TabIndex = 24;
		C384FE05.TextChanged += new System.EventHandler(C384FE05_TextChanged);
		btnCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCauHinh.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnCauHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCauHinh.Location = new System.Drawing.Point(157, 60);
		btnCauHinh.Name = "btnCauHinh";
		btnCauHinh.Size = new System.Drawing.Size(75, 25);
		btnCauHinh.TabIndex = 5;
		btnCauHinh.Text = "Cấu hình";
		btnCauHinh.Click += new System.EventHandler(btnCauHinh_Click);
		ckbAutoOpenLink.AutoSize = true;
		ckbAutoOpenLink.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoOpenLink.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbAutoOpenLink.Location = new System.Drawing.Point(37, 203);
		ckbAutoOpenLink.Name = "ckbAutoOpenLink";
		ckbAutoOpenLink.Size = new System.Drawing.Size(149, 20);
		ckbAutoOpenLink.TabIndex = 21;
		ckbAutoOpenLink.Text = "Tự động mở website:";
		ckbAutoOpenLink.UseVisualStyleBackColor = true;
		ckbAutoOpenLink.CheckedChanged += new System.EventHandler(C7337D83);
		ckbAutoCloseChromeLoginFail.AutoSize = true;
		ckbAutoCloseChromeLoginFail.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoCloseChromeLoginFail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbAutoCloseChromeLoginFail.Location = new System.Drawing.Point(37, 177);
		ckbAutoCloseChromeLoginFail.Name = "ckbAutoCloseChromeLoginFail";
		ckbAutoCloseChromeLoginFail.Size = new System.Drawing.Size(326, 20);
		ckbAutoCloseChromeLoginFail.TabIndex = 21;
		ckbAutoCloseChromeLoginFail.Text = "Tự động đóng những tab chrome đăng nhập thất bại";
		ckbAutoCloseChromeLoginFail.UseVisualStyleBackColor = true;
		A0067632.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A0067632.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		A0067632.Cursor = System.Windows.Forms.Cursors.Hand;
		A0067632.FlatAppearance.BorderSize = 0;
		A0067632.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A0067632.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A0067632.ForeColor = System.Drawing.Color.White;
		A0067632.Location = new System.Drawing.Point(127, 258);
		A0067632.Name = "btnSave";
		A0067632.Size = new System.Drawing.Size(92, 29);
		A0067632.TabIndex = 20;
		A0067632.Text = "Lưu";
		A0067632.UseVisualStyleBackColor = false;
		A0067632.Click += new System.EventHandler(D6BE4133);
		panel3.Controls.Add(rbSuDungProfile);
		panel3.Controls.Add(F22AC39B);
		panel3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		panel3.Location = new System.Drawing.Point(157, 88);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(273, 26);
		panel3.TabIndex = 8;
		rbSuDungProfile.AutoSize = true;
		rbSuDungProfile.Checked = true;
		rbSuDungProfile.Cursor = System.Windows.Forms.Cursors.Hand;
		rbSuDungProfile.Location = new System.Drawing.Point(3, 3);
		rbSuDungProfile.Name = "rbSuDungProfile";
		rbSuDungProfile.Size = new System.Drawing.Size(113, 20);
		rbSuDungProfile.TabIndex = 4;
		rbSuDungProfile.TabStop = true;
		rbSuDungProfile.Text = "Sử dụng Profile";
		rbSuDungProfile.UseVisualStyleBackColor = true;
		F22AC39B.AutoSize = true;
		F22AC39B.Cursor = System.Windows.Forms.Cursors.Hand;
		F22AC39B.Location = new System.Drawing.Point(127, 3);
		F22AC39B.Name = "rbKhongDungProfile";
		F22AC39B.Size = new System.Drawing.Size(132, 20);
		F22AC39B.TabIndex = 4;
		F22AC39B.Text = "Không dùng Profile";
		F22AC39B.UseVisualStyleBackColor = true;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(34, 64);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(98, 16);
		label3.TabIndex = 7;
		label3.Text = "Cấu hình đổi IP:";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(34, 93);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(104, 16);
		label1.TabIndex = 7;
		label1.Text = "Tùy chọn Profile:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(456, 300);
		base.Controls.Add(A813059E);
		base.Controls.Add(DAA9CA2B);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fMoTrinhDuyet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fMoTrinhDuyet_Load);
		A813059E.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		DAA9CA2B.ResumeLayout(false);
		DAA9CA2B.PerformLayout();
		CCBF1231.ResumeLayout(false);
		CCBF1231.PerformLayout();
		plAddChromeVaoFormView.ResumeLayout(false);
		plAddChromeVaoFormView.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudWidthChrome).EndInit();
		((System.ComponentModel.ISupportInitialize)nudHeighChrome).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		ResumeLayout(false);
	}
}
