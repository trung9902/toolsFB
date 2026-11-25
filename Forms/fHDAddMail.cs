using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDAddMail : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal List<string> list_0 = new List<string>();

	internal List<string> list_1 = new List<string>();

	internal List<string> B487E907 = new List<string>();

	internal List<string> A283A8AC = new List<string>();

	internal List<string> list_2 = new List<string>();

	internal List<string> list_3 = new List<string>();

	internal List<string> C4B17805 = new List<string>();

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel panel1;

	internal TextBox DB943215;

	internal Label CCBEFF0C;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards BEAC6435;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal CheckBox DA2D473C;

	internal Panel plAddMail;

	internal CheckBox DF01579A;

	internal Panel plMatKhauMoi;

	internal Label C5088C16;

	internal TextBox txtNewPass;

	internal ComboBox cbbTypeMail;

	internal ComboBox cbbXoaMailCu;

	internal ComboBox cbbAddMail;

	internal Button btnNhapMail;

	internal Label label3;

	internal Label A8B4AEBB;

	internal CheckBox ckbAnMail;

	internal Button button2;

	internal NumericUpDown A2BAAF0F;

	internal Label label5;

	public static bool DB959BA9
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

	public fHDAddMail(string string_3, string F000FFB1 = "")
	{
		InitializeComponent();
		DB959BA9 = false;
		string_0 = string_3;
		string_2 = F000FFB1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (F000FFB1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			DB943215.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(F000FFB1);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			DB943215.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to safely dismiss dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void E193ABA1(object sender, EventArgs e)
	{
		try
		{
			method_0();
			method_1();
			A8BA843E();
			DF01579A.Checked = gclass4_0.method_3("ckbAddMail");
			cbbAddMail.SelectedValue = gclass4_0.BDB80B23("typeAddMail", "7");
			try
			{
				cbbTypeMail.SelectedValue = gclass4_0.BDB80B23("cbbTypeMail", "0");
			}
			catch
			{
				cbbTypeMail.SelectedIndex = 0;
			}
			list_0 = gclass4_0.method_1("lstHotmail");
			list_1 = gclass4_0.method_1("lstMailDomain");
			B487E907 = gclass4_0.method_1("lstDomain");
			A283A8AC = gclass4_0.method_1("lstDomainUnlimitMail");
			if (A283A8AC.Count == 0)
			{
				A283A8AC.Add("otpgmail.com");
			}
			list_2 = gclass4_0.method_1("lstDomainDonglaomail");
			if (list_2.Count == 0)
			{
				list_2.Add("cristionel.com");
			}
			list_3 = gclass4_0.method_1("lstDomain1secmail");
			if (list_3.Count == 0)
			{
				list_3.Add("1secmail.com");
			}
			C4B17805 = gclass4_0.method_1("lstDomainMailtm");
			if (C4B17805.Count == 0)
			{
				C4B17805.Add("starmail.net");
			}
			A2BAAF0F.Value = gclass4_0.method_2("nudDelayOtp", 60);
			DA2D473C.Checked = gclass4_0.method_3("ckbXoaMailCu");
			cbbXoaMailCu.SelectedValue = gclass4_0.BDB80B23("typeXoaMail", "0");
			txtNewPass.Text = gclass4_0.BDB80B23("txtNewPass");
			ckbAnMail.Checked = gclass4_0.method_3("ckbAnMail");
			DF01579A_CheckedChanged(null, null);
			D0399708(null, null);
			DD2904BC();
			A2B3422A();
		}
		catch
		{
		}
	}

	private void A8BA843E()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Sử dụng m.fb");
		dictionary.Add("1", "Sử dụng link hacked");
		dictionary.Add("2", "Sử dụng www");
		dictionary.Add("3", "Sử dụng tut không pass");
		Commom.smethod_24(cbbXoaMailCu, dictionary);
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("6", "Sư\u0309 du\u0323ng Account Center");
		dictionary.Add("7", "Tut không câ\u0300n lâ\u0301y otp tư\u0300 email cu\u0303");
		Commom.smethod_24(cbbAddMail, dictionary);
	}

	private void method_1()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Hotmail");
		dictionary.Add("2", "https://generator.email/");
		dictionary.Add("3", "https://unlimitmail.com/");
		if (Base.A9352D3F)
		{
			dictionary.Add("4", "https://mailtula.com/");
		}
		dictionary.Add("5", "https://hotmail9.com/");
		dictionary.Add("6", "https://1secmail.com/");
		dictionary.Add("8", "https://donglaomail.com/");
		Commom.smethod_24(cbbTypeMail, dictionary);
	}

	private void E41F2687(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = DB943215.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("ckbAddMail", DF01579A.Checked);
		gClass.method_4("typeAddMail", cbbAddMail.SelectedValue);
		gClass.method_4("cbbTypeMail", cbbTypeMail.SelectedValue);
		gClass.FD3CCF90("lstHotmail", list_0);
		gClass.FD3CCF90("lstMailDomain", list_1);
		gClass.FD3CCF90("lstDomain", B487E907);
		gClass.FD3CCF90("lstDomainUnlimitMail", A283A8AC);
		gClass.FD3CCF90("lstDomainDonglaomail", list_2);
		gClass.FD3CCF90("lstDomain1secmail", list_3);
		gClass.FD3CCF90("lstDomainMailtm", C4B17805);
		gClass.method_4("nudDelayOtp", A2BAAF0F.Value);
		gClass.method_4("ckbXoaMailCu", DA2D473C.Checked);
		gClass.method_4("typeXoaMail", cbbXoaMailCu.SelectedValue);
		gClass.method_4("txtNewPass", txtNewPass.Text.Trim());
		gClass.method_4("ckbAnMail", ckbAnMail.Checked);
		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					DB959BA9 = true;
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
				DB959BA9 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
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

	private void DF01579A_CheckedChanged(object sender, EventArgs e)
	{
		plAddMail.Enabled = DF01579A.Checked;
		DD2904BC();
	}

	private void D0399708(object sender, EventArgs e)
	{
		cbbXoaMailCu.Enabled = DA2D473C.Checked;
		DD2904BC();
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void cbbXoaMailCu_SelectedIndexChanged(object sender, EventArgs e)
	{
		DD2904BC();
	}

	private void DD2904BC()
	{
		plMatKhauMoi.Enabled = (cbbAddMail.Enabled && cbbAddMail.Text.ToLower().Contains("hacked")) || (cbbXoaMailCu.Enabled && cbbXoaMailCu.Text.ToLower().Contains("hacked"));
	}

	private void cbbTypeMail_SelectedIndexChanged(object sender, EventArgs e)
	{
		A2B3422A();
	}

	private void A2B3422A()
	{
		string text = cbbTypeMail.SelectedValue.ToString();
		string text2 = text;
		string text3 = text2;
		switch (AFAE75A0.smethod_0(text3))
		{
		case 873244444u:
			if (text3 == "1")
			{
				Commom.E998C514(btnNhapMail, list_1.Count);
			}
			break;
		case 856466825u:
			if (text3 == "6")
			{
				Commom.E998C514(btnNhapMail, list_3.Count);
			}
			break;
		case 839689206u:
			if (text3 == "7")
			{
				Commom.E998C514(btnNhapMail, C4B17805.Count);
			}
			break;
		case 906799682u:
			if (text3 == "3")
			{
				Commom.E998C514(btnNhapMail, A283A8AC.Count);
			}
			break;
		case 890022063u:
			if (text3 == "0")
			{
				Commom.E998C514(btnNhapMail, list_0.Count);
			}
			break;
		case 1024243015u:
			if (text3 == "8")
			{
				Commom.E998C514(btnNhapMail, list_2.Count);
			}
			break;
		case 923577301u:
			if (text3 == "2")
			{
				Commom.E998C514(btnNhapMail, B487E907.Count);
			}
			break;
		}
		btnNhapMail.Enabled = text != "4" && text != "5";
	}

	private void E40192BD(object sender, EventArgs e)
	{
		string text = cbbTypeMail.SelectedValue.ToString();
		string text2 = text;
		string text3 = text2;
		switch (AFAE75A0.smethod_0(text3))
		{
		case 873244444u:
			if (text3 == "1")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_1, "Nhâ\u0323p danh sa\u0301ch link mail domain", "Danh sa\u0301ch link mail domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_1 = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, list_1.Count);
			}
			break;
		case 856466825u:
			if (text3 == "6")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_3, "Nhâ\u0323p danh sa\u0301ch domain", "Danh sa\u0301ch domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_3 = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, list_3.Count);
			}
			break;
		case 839689206u:
			if (text3 == "7")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(C4B17805, "Nhâ\u0323p danh sa\u0301ch domain", "Danh sa\u0301ch domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				C4B17805 = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, C4B17805.Count);
			}
			break;
		case 906799682u:
			if (text3 == "3")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(A283A8AC, "Nhâ\u0323p danh sa\u0301ch domain", "Danh sa\u0301ch domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				A283A8AC = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, A283A8AC.Count);
			}
			break;
		case 890022063u:
			if (text3 == "0")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_0, "Nhâ\u0323p danh sa\u0301ch hotmail", "Danh sa\u0301ch email|password hoă\u0323c email|password|refresh_token|client_id", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_0 = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, list_0.Count);
			}
			break;
		case 1024243015u:
			if (text3 == "8")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_2, "Nhâ\u0323p danh sa\u0301ch domain", "Danh sa\u0301ch domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				list_2 = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, list_2.Count);
			}
			break;
		case 923577301u:
			if (text3 == "2")
			{
				fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(B487E907, "Nhâ\u0323p danh sa\u0301ch domain", "Danh sa\u0301ch domain", "(Mô\u0303i nội dung 1 do\u0300ng)");
				Commom.smethod_35(fNhapDuLieu4);
				B487E907 = fNhapDuLieu4.list_0;
				Commom.E998C514(btnNhapMail, B487E907.Count);
			}
			break;
		}
	}

	private void cbbAddMail_Click(object sender, EventArgs e)
	{
	}

	private void A481288B(object sender, EventArgs e)
	{
		string object_ = "Có thể sử dụng ký tự * để random 1 ký tự ngẫu nhiên!\r\nVí dụ: MIN****** => MINdfghta";
		MsBoxHelper.Show(object_);
	}

	private void C98FDC8A(object sender, EventArgs e)
	{
		DD2904BC();
	}

	private void panel1_ParentChanged(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool D13FF4B9)
	{
		if (D13FF4B9 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(D13FF4B9);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDAddMail));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		plAddMail = new System.Windows.Forms.Panel();
		A2BAAF0F = new System.Windows.Forms.NumericUpDown();
		cbbAddMail = new System.Windows.Forms.ComboBox();
		btnNhapMail = new System.Windows.Forms.Button();
		cbbTypeMail = new System.Windows.Forms.ComboBox();
		label3 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		A8B4AEBB = new System.Windows.Forms.Label();
		cbbXoaMailCu = new System.Windows.Forms.ComboBox();
		plMatKhauMoi = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		C5088C16 = new System.Windows.Forms.Label();
		txtNewPass = new System.Windows.Forms.TextBox();
		DF01579A = new System.Windows.Forms.CheckBox();
		ckbAnMail = new System.Windows.Forms.CheckBox();
		DA2D473C = new System.Windows.Forms.CheckBox();
		DB943215 = new System.Windows.Forms.TextBox();
		CCBEFF0C = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		BEAC6435 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		plAddMail.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)A2BAAF0F).BeginInit();
		plMatKhauMoi.SuspendLayout();
		BEAC6435.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(356, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Add Mail";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(356, 31);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};

		// Minimize Button
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

		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(E41F2687);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(plAddMail);
		panel1.Controls.Add(cbbXoaMailCu);
		panel1.Controls.Add(plMatKhauMoi);
		panel1.Controls.Add(DF01579A);
		panel1.Controls.Add(ckbAnMail);
		panel1.Controls.Add(DA2D473C);
		panel1.Controls.Add(DB943215);
		panel1.Controls.Add(CCBEFF0C);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(BEAC6435);
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(359, 246);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		panel1.ParentChanged += new System.EventHandler(panel1_ParentChanged);
		plAddMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAddMail.Controls.Add(A2BAAF0F);
		plAddMail.Controls.Add(cbbAddMail);
		plAddMail.Controls.Add(btnNhapMail);
		plAddMail.Controls.Add(cbbTypeMail);
		plAddMail.Controls.Add(label3);
		plAddMail.Controls.Add(label5);
		plAddMail.Controls.Add(A8B4AEBB);
		plAddMail.Location = new System.Drawing.Point(23, 100);
		plAddMail.Name = "plAddMail";
		plAddMail.Size = new System.Drawing.Size(311, 63);
		plAddMail.TabIndex = 115;
		A2BAAF0F.Location = new System.Drawing.Point(101, 34);
		A2BAAF0F.Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		A2BAAF0F.Name = "nudDelayOtp";
		A2BAAF0F.Size = new System.Drawing.Size(68, 23);
		A2BAAF0F.TabIndex = 118;
		cbbAddMail.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbAddMail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbAddMail.FormattingEnabled = true;
		cbbAddMail.Location = new System.Drawing.Point(101, 99);
		cbbAddMail.Name = "cbbAddMail";
		cbbAddMail.Size = new System.Drawing.Size(205, 24);
		cbbAddMail.TabIndex = 116;
		cbbAddMail.SelectionChangeCommitted += new System.EventHandler(C98FDC8A);
		cbbAddMail.Click += new System.EventHandler(cbbAddMail_Click);
		btnNhapMail.Cursor = System.Windows.Forms.Cursors.Hand;
		btnNhapMail.Location = new System.Drawing.Point(220, 3);
		btnNhapMail.Name = "btnNhapMail";
		btnNhapMail.Size = new System.Drawing.Size(86, 26);
		btnNhapMail.TabIndex = 117;
		btnNhapMail.Text = "Nhập (0)";
		btnNhapMail.UseVisualStyleBackColor = true;
		btnNhapMail.Click += new System.EventHandler(E40192BD);
		cbbTypeMail.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeMail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeMail.DropDownWidth = 200;
		cbbTypeMail.FormattingEnabled = true;
		cbbTypeMail.Location = new System.Drawing.Point(101, 4);
		cbbTypeMail.Name = "cbbTypeMail";
		cbbTypeMail.Size = new System.Drawing.Size(113, 24);
		cbbTypeMail.TabIndex = 116;
		cbbTypeMail.SelectedIndexChanged += new System.EventHandler(cbbTypeMail_SelectedIndexChanged);
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(1, 102);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(64, 16);
		label3.TabIndex = 31;
		label3.Text = "Tùy chọn:";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(1, 36);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(96, 16);
		label5.TabIndex = 31;
		label5.Text = "Chờ lấy otp (s):";
		A8B4AEBB.AutoSize = true;
		A8B4AEBB.Location = new System.Drawing.Point(1, 7);
		A8B4AEBB.Name = "label4";
		A8B4AEBB.Size = new System.Drawing.Size(63, 16);
		A8B4AEBB.TabIndex = 31;
		A8B4AEBB.Text = "Loại mail:";
		cbbXoaMailCu.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbXoaMailCu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbXoaMailCu.FormattingEnabled = true;
		cbbXoaMailCu.Location = new System.Drawing.Point(125, 400);
		cbbXoaMailCu.Name = "cbbXoaMailCu";
		cbbXoaMailCu.Size = new System.Drawing.Size(209, 24);
		cbbXoaMailCu.TabIndex = 116;
		cbbXoaMailCu.SelectedIndexChanged += new System.EventHandler(cbbXoaMailCu_SelectedIndexChanged);
		plMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plMatKhauMoi.Controls.Add(button2);
		plMatKhauMoi.Controls.Add(C5088C16);
		plMatKhauMoi.Controls.Add(txtNewPass);
		plMatKhauMoi.Location = new System.Drawing.Point(23, 430);
		plMatKhauMoi.Name = "plMatKhauMoi";
		plMatKhauMoi.Size = new System.Drawing.Size(311, 31);
		plMatKhauMoi.TabIndex = 115;
		button2.Cursor = System.Windows.Forms.Cursors.Help;
		button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button2.Location = new System.Drawing.Point(282, 3);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(24, 24);
		button2.TabIndex = 151;
		button2.Text = "?";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(A481288B);
		C5088C16.AutoSize = true;
		C5088C16.Location = new System.Drawing.Point(2, 6);
		C5088C16.Name = "label2";
		C5088C16.Size = new System.Drawing.Size(89, 16);
		C5088C16.TabIndex = 31;
		C5088C16.Text = "Mật khẩu mới:";
		txtNewPass.Location = new System.Drawing.Point(101, 3);
		txtNewPass.Name = "txtNewPass";
		txtNewPass.Size = new System.Drawing.Size(178, 23);
		txtNewPass.TabIndex = 0;
		DF01579A.AutoSize = true;
		DF01579A.Cursor = System.Windows.Forms.Cursors.Hand;
		DF01579A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DF01579A.Location = new System.Drawing.Point(23, 78);
		DF01579A.Name = "ckbAddMail";
		DF01579A.Size = new System.Drawing.Size(75, 20);
		DF01579A.TabIndex = 113;
		DF01579A.Text = "Add Mail";
		DF01579A.UseVisualStyleBackColor = true;
		DF01579A.CheckedChanged += new System.EventHandler(DF01579A_CheckedChanged);
		ckbAnMail.AutoSize = true;
		ckbAnMail.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAnMail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbAnMail.Location = new System.Drawing.Point(23, 321);
		ckbAnMail.Name = "ckbAnMail";
		ckbAnMail.Size = new System.Drawing.Size(69, 20);
		ckbAnMail.TabIndex = 113;
		ckbAnMail.Text = "Ẩn mail";
		ckbAnMail.UseVisualStyleBackColor = true;
		DA2D473C.AutoSize = true;
		DA2D473C.Cursor = System.Windows.Forms.Cursors.Hand;
		DA2D473C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DA2D473C.Location = new System.Drawing.Point(23, 169);
		DA2D473C.Name = "ckbXoaMailCu";
		DA2D473C.Size = new System.Drawing.Size(183, 20);
		DA2D473C.TabIndex = 113;
		DA2D473C.Text = "Xóa mail không co\u0301 trên tool";
		DA2D473C.UseVisualStyleBackColor = true;
		DA2D473C.CheckedChanged += new System.EventHandler(D0399708);
		DB943215.Location = new System.Drawing.Point(125, 49);
		DB943215.Name = "txtTenHanhDong";
		DB943215.Size = new System.Drawing.Size(209, 23);
		DB943215.TabIndex = 0;
		CCBEFF0C.AutoSize = true;
		CCBEFF0C.Location = new System.Drawing.Point(20, 52);
		CCBEFF0C.Name = "label1";
		CCBEFF0C.Size = new System.Drawing.Size(98, 16);
		CCBEFF0C.TabIndex = 31;
		CCBEFF0C.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(189, 203);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 203);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		BEAC6435.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		BEAC6435.BackColor = System.Drawing.Color.White;
		BEAC6435.BorderRadius = 0;
		BEAC6435.BottomSahddow = true;
		BEAC6435.color = System.Drawing.Color.DarkViolet;
		BEAC6435.Controls.Add(pnlHeader);
		BEAC6435.LeftSahddow = false;
		BEAC6435.Location = new System.Drawing.Point(1, 0);
		BEAC6435.Name = "bunifuCards1";
		BEAC6435.RightSahddow = true;
		BEAC6435.ShadowDepth = 20;
		BEAC6435.Size = new System.Drawing.Size(356, 37);
		BEAC6435.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(359, 246);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDAddMail";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(E193ABA1);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plAddMail.ResumeLayout(false);
		plAddMail.PerformLayout();
		((System.ComponentModel.ISupportInitialize)A2BAAF0F).EndInit();
		plMatKhauMoi.ResumeLayout(false);
		plMatKhauMoi.PerformLayout();
		BEAC6435.ResumeLayout(false);
		ResumeLayout(false);
	}
}
