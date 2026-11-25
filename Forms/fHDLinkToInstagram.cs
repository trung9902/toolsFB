using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDLinkToInstagram : Form
{
	internal GClass4 gclass4_0 = null;

	internal Panel pnlTopAccent;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool BCA6AABE;

	internal IContainer EE850A13 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl BD12BB09;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button BBBBBC28;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel E5AF9A32;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button button1;

	internal TextBox txtPassword;

	internal Label B91C8820;

	internal RadioButton rbPassTuNhap;

	internal RadioButton rbPassRandom;

	internal Label lblStatus;

	internal CheckBox F7A31335;

	internal TextBox txtPathFileSaveAcc;

	internal Panel panel3;

	internal TextBox txtPathImage;

	internal Label label2;

	internal CheckBox E6B65C28;

	internal Panel panel2;

	internal NumericUpDown CC3BA81D;

	internal NumericUpDown nudSoLuongTo;

	internal Label BE28AF10;

	internal Label label3;

	internal RichTextBox D52D969C;

	internal CheckBox ckbBio;

	internal Panel DBA8C8AC;

	internal Label label6;

	public static bool B6ADA603
	{
		[CompilerGenerated]
		get
		{
			return BCA6AABE;
		}
		[CompilerGenerated]
		set
		{
			BCA6AABE = value;
		}
	}

	public fHDLinkToInstagram(string string_3, string AC1E729D = "")
	{
		InitializeComponent();
		B6ADA603 = false;
		string_0 = string_3;
		string_2 = AC1E729D;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (AC1E729D == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(AC1E729D);
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

	private void B0209A1B(object sender, EventArgs e)
	{
		try
		{
			if (gclass4_0.method_2("typePass") == 0)
			{
				rbPassRandom.Checked = true;
			}
			else
			{
				rbPassTuNhap.Checked = true;
			}
			txtPassword.Text = gclass4_0.BDB80B23("txtPassword");
			txtPathFileSaveAcc.Text = Commom.smethod_95() + "\\accountIG.txt";
			E6B65C28.Checked = gclass4_0.method_3("ckbUpAvatar");
			txtPathImage.Text = gclass4_0.BDB80B23("txtPathImage");
			F7A31335.Checked = gclass4_0.method_3("ckbFollow");
			CC3BA81D.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			ckbBio.Checked = gclass4_0.method_3("ckbBio");
			D52D969C.Text = gclass4_0.BDB80B23("txtBio");
		}
		catch
		{
		}
		rbPassTuNhap_CheckedChanged(null, null);
		E6B65C28_CheckedChanged(null, null);
		F7A31335_CheckedChanged(null, null);
		ckbBio_CheckedChanged(null, null);
		F322A706(null, null);
		Commom.AttachFolderPicker(txtPathImage);
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
		if (E6B65C28.Checked)
		{
			string textPathImage = txtPathImage.Text.Trim();
			if (string.IsNullOrWhiteSpace(textPathImage) || !Directory.Exists(textPathImage))
			{
				MsBoxHelper.Show("Thư mục ảnh không tồn tại! Vui lòng chọn lại.", 3);
				txtPathImage.Focus();
				return;
			}
			if (!Commom.ValidateMediaFolder(textPathImage, out int mediaCount, out string _) || mediaCount == 0)
			{
				MsBoxHelper.Show("Thư mục đã chọn không có file ảnh/video nào! Vui lòng kiểm tra lại.", 3);
				txtPathImage.Focus();
				return;
			}
		}
		GClass4 gClass = new GClass4();
		int num = 0;
		if (rbPassTuNhap.Checked)
		{
			num = 1;
		}
		gClass.method_4("typePass", num);
		gClass.method_4("txtPassword", txtPassword.Text.Trim());
		gClass.method_4("ckbUpAvatar", E6B65C28.Checked);
		gClass.method_4("txtPathImage", txtPathImage.Text.Trim());
		gClass.method_4("ckbFollow", F7A31335.Checked);
		gClass.method_4("nudSoLuongFrom", CC3BA81D.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("ckbBio", ckbBio.Checked);
		gClass.method_4("txtBio", D52D969C.Text);
		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					B6ADA603 = true;
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
				B6ADA603 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void BBBBBC28_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AB0B1A20(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void rbPassTuNhap_CheckedChanged(object sender, EventArgs e)
	{
		txtPassword.Enabled = rbPassTuNhap.Checked;
	}

	private void txtPathFileSaveAcc_TextChanged(object sender, EventArgs e)
	{
	}

	private void E6B65C28_CheckedChanged(object sender, EventArgs e)
	{
		panel3.Enabled = E6B65C28.Checked;
	}

	private void F7A31335_CheckedChanged(object sender, EventArgs e)
	{
		panel2.Enabled = F7A31335.Checked;
	}

	private void ckbBio_CheckedChanged(object sender, EventArgs e)
	{
		DBA8C8AC.Enabled = ckbBio.Checked;
	}

	private void F322A706(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			list = D52D969C.Lines.ToList();
			list = Commom.smethod_36(list);
			label6.Text = string.Format(Language.GetValue("Danh sách Bio ({0}):"), list.Count.ToString());
		}
		catch
		{
		}
	}

	protected override void Dispose(bool C70B930F)
	{
		if (C70B930F && EE850A13 != null)
		{
			EE850A13.Dispose();
		}
		base.Dispose(C70B930F);
	}

	private void InitializeComponent()
	{
		EE850A13 = new System.ComponentModel.Container();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(EE850A13);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		BD12BB09 = new Bunifu.Framework.UI.BunifuDragControl(EE850A13);
		E5AF9A32 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		DBA8C8AC = new System.Windows.Forms.Panel();
		label6 = new System.Windows.Forms.Label();
		D52D969C = new System.Windows.Forms.RichTextBox();
		ckbBio = new System.Windows.Forms.CheckBox();
		panel3 = new System.Windows.Forms.Panel();
		txtPathImage = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		E6B65C28 = new System.Windows.Forms.CheckBox();
		panel2 = new System.Windows.Forms.Panel();
		CC3BA81D = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		BE28AF10 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		F7A31335 = new System.Windows.Forms.CheckBox();
		B91C8820 = new System.Windows.Forms.Label();
		rbPassTuNhap = new System.Windows.Forms.RadioButton();
		rbPassRandom = new System.Windows.Forms.RadioButton();
		txtPassword = new System.Windows.Forms.TextBox();
		lblStatus = new System.Windows.Forms.Label();
		txtPathFileSaveAcc = new System.Windows.Forms.TextBox();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		BBBBBC28 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		E5AF9A32.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		DBA8C8AC.SuspendLayout();
		panel3.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CC3BA81D).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(407, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Liên kết Instagram";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BD12BB09.Fixed = true;
		BD12BB09.Horizontal = true;
		BD12BB09.TargetControl = E5AF9A32;
		BD12BB09.Vertical = true;
		E5AF9A32.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E5AF9A32.BackColor = System.Drawing.Color.White;
		E5AF9A32.Controls.Add(button1);
		E5AF9A32.Controls.Add(pictureBox1);
		E5AF9A32.Controls.Add(bunifuCustomLabel1);
		E5AF9A32.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E5AF9A32.Location = new System.Drawing.Point(0, 3);
		E5AF9A32.Name = "pnlHeader";
		E5AF9A32.Size = new System.Drawing.Size(407, 31);
		E5AF9A32.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = Class155.Bitmap_15;
		button1.Location = new System.Drawing.Point(376, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		System.Drawing.Image iconClose_fHDLi = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDLi != null) button1.Image = iconClose_fHDLi;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDLi = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDLi != null) pictureBox1.Image = iconApp_fHDLi;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(DBA8C8AC);
		panel1.Controls.Add(ckbBio);
		panel1.Controls.Add(panel3);
		panel1.Controls.Add(E6B65C28);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(F7A31335);
		panel1.Controls.Add(B91C8820);
		panel1.Controls.Add(rbPassTuNhap);
		panel1.Controls.Add(rbPassRandom);
		panel1.Controls.Add(txtPassword);
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(txtPathFileSaveAcc);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(BBBBBC28);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(410, 206);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(AB0B1A20);
		DBA8C8AC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DBA8C8AC.Controls.Add(label6);
		DBA8C8AC.Controls.Add(D52D969C);
		DBA8C8AC.Location = new System.Drawing.Point(145, 393);
		DBA8C8AC.Name = "panel4";
		DBA8C8AC.Size = new System.Drawing.Size(231, 145);
		DBA8C8AC.TabIndex = 50;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(3, 3);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(113, 16);
		label6.TabIndex = 50;
		label6.Text = "Danh sách bio (0):";
		D52D969C.Location = new System.Drawing.Point(6, 22);
		D52D969C.Name = "txtBio";
		D52D969C.Size = new System.Drawing.Size(220, 118);
		D52D969C.TabIndex = 49;
		D52D969C.Text = "";
		D52D969C.WordWrap = false;
		D52D969C.TextChanged += new System.EventHandler(F322A706);
		ckbBio.AutoSize = true;
		ckbBio.Location = new System.Drawing.Point(31, 389);
		ckbBio.Name = "ckbBio";
		ckbBio.Size = new System.Drawing.Size(85, 20);
		ckbBio.TabIndex = 48;
		ckbBio.Text = "Thêm bio:";
		ckbBio.UseVisualStyleBackColor = true;
		ckbBio.CheckedChanged += new System.EventHandler(ckbBio_CheckedChanged);
		panel3.Controls.Add(txtPathImage);
		panel3.Controls.Add(label2);
		panel3.Location = new System.Drawing.Point(145, 330);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(231, 27);
		panel3.TabIndex = 47;
		txtPathImage.Location = new System.Drawing.Point(97, 2);
		txtPathImage.Name = "txtPathImage";
		txtPathImage.Size = new System.Drawing.Size(131, 23);
		txtPathImage.TabIndex = 0;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(3, 5);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(88, 16);
		label2.TabIndex = 41;
		label2.Text = "Thư mục ảnh:";
		E6B65C28.AutoSize = true;
		E6B65C28.Location = new System.Drawing.Point(31, 333);
		E6B65C28.Name = "ckbUpAvatar";
		E6B65C28.Size = new System.Drawing.Size(87, 20);
		E6B65C28.TabIndex = 42;
		E6B65C28.Text = "Up Avatar:";
		E6B65C28.UseVisualStyleBackColor = true;
		E6B65C28.CheckedChanged += new System.EventHandler(E6B65C28_CheckedChanged);
		panel2.Controls.Add(CC3BA81D);
		panel2.Controls.Add(nudSoLuongTo);
		panel2.Controls.Add(BE28AF10);
		panel2.Controls.Add(label3);
		panel2.Location = new System.Drawing.Point(145, 360);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(200, 27);
		panel2.TabIndex = 47;
		CC3BA81D.Location = new System.Drawing.Point(1, 2);
		CC3BA81D.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CC3BA81D.Name = "nudSoLuongFrom";
		CC3BA81D.Size = new System.Drawing.Size(56, 23);
		CC3BA81D.TabIndex = 43;
		nudSoLuongTo.Location = new System.Drawing.Point(97, 2);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 44;
		BE28AF10.AutoSize = true;
		BE28AF10.Location = new System.Drawing.Point(155, 4);
		BE28AF10.Name = "label4";
		BE28AF10.Size = new System.Drawing.Size(39, 16);
		BE28AF10.TabIndex = 45;
		BE28AF10.Text = "người";
		label3.Location = new System.Drawing.Point(62, 4);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 46;
		label3.Text = "đê\u0301n";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F7A31335.AutoSize = true;
		F7A31335.Location = new System.Drawing.Point(31, 363);
		F7A31335.Name = "ckbFollow";
		F7A31335.Size = new System.Drawing.Size(99, 20);
		F7A31335.TabIndex = 42;
		F7A31335.Text = "Follow gợi ý:";
		F7A31335.UseVisualStyleBackColor = true;
		F7A31335.CheckedChanged += new System.EventHandler(F7A31335_CheckedChanged);
		B91C8820.AutoSize = true;
		B91C8820.Location = new System.Drawing.Point(28, 131);
		B91C8820.Name = "label5";
		B91C8820.Size = new System.Drawing.Size(110, 16);
		B91C8820.TabIndex = 41;
		B91C8820.Text = "File lưu tài khoản:";
		rbPassTuNhap.AutoSize = true;
		rbPassTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
		rbPassTuNhap.Location = new System.Drawing.Point(145, 100);
		rbPassTuNhap.Name = "rbPassTuNhap";
		rbPassTuNhap.Size = new System.Drawing.Size(78, 20);
		rbPassTuNhap.TabIndex = 40;
		rbPassTuNhap.Text = "Tự nhập:";
		rbPassTuNhap.UseVisualStyleBackColor = true;
		rbPassTuNhap.CheckedChanged += new System.EventHandler(rbPassTuNhap_CheckedChanged);
		rbPassRandom.AutoSize = true;
		rbPassRandom.Checked = true;
		rbPassRandom.Cursor = System.Windows.Forms.Cursors.Hand;
		rbPassRandom.Location = new System.Drawing.Point(145, 76);
		rbPassRandom.Name = "rbPassRandom";
		rbPassRandom.Size = new System.Drawing.Size(89, 20);
		rbPassRandom.TabIndex = 39;
		rbPassRandom.TabStop = true;
		rbPassRandom.Text = "Ngẫu nhiên";
		rbPassRandom.UseVisualStyleBackColor = true;
		txtPassword.Location = new System.Drawing.Point(230, 99);
		txtPassword.Name = "txtPassword";
		txtPassword.Size = new System.Drawing.Size(146, 23);
		txtPassword.TabIndex = 38;
		lblStatus.AutoSize = true;
		lblStatus.Location = new System.Drawing.Point(28, 76);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(64, 16);
		lblStatus.TabIndex = 0;
		lblStatus.Text = "Mật khẩu:";
		txtPathFileSaveAcc.Location = new System.Drawing.Point(145, 128);
		txtPathFileSaveAcc.Name = "txtPathFileSaveAcc";
		txtPathFileSaveAcc.ReadOnly = true;
		txtPathFileSaveAcc.Size = new System.Drawing.Size(231, 23);
		txtPathFileSaveAcc.TabIndex = 0;
		txtPathFileSaveAcc.TextChanged += new System.EventHandler(txtPathFileSaveAcc_TextChanged);
		txtTenHanhDong.Location = new System.Drawing.Point(145, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(231, 23);
		txtTenHanhDong.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		BBBBBC28.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BBBBBC28.BackColor = System.Drawing.Color.Maroon;
		BBBBBC28.Cursor = System.Windows.Forms.Cursors.Hand;
		BBBBBC28.FlatAppearance.BorderSize = 0;
		BBBBBC28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BBBBBC28.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BBBBBC28.ForeColor = System.Drawing.Color.White;
		BBBBBC28.Location = new System.Drawing.Point(217, 165);
		BBBBBC28.Name = "btnCancel";
		BBBBBC28.Size = new System.Drawing.Size(92, 29);
		BBBBBC28.TabIndex = 10;
		BBBBBC28.Text = "Đóng";
		BBBBBC28.UseVisualStyleBackColor = false;
		BBBBBC28.Click += new System.EventHandler(BBBBBC28_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(110, 165);
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
		bunifuCards1.Controls.Add(E5AF9A32);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(407, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(410, 206);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDLinkToInstagram";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(B0209A1B);
		E5AF9A32.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		DBA8C8AC.ResumeLayout(false);
		DBA8C8AC.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CC3BA81D).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
