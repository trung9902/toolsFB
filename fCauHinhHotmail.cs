using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhHotmail : Form
{
	internal bool bool_0 = false;

	internal bool bool_1 = false;

	internal IContainer AE2B2A88 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl FEA5EFA7;

	internal Panel panel1;

	internal Button btnCancel;

	internal Button FD9F1D3C;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal BackgroundWorker CC842F33;

	internal CheckBox B489E1B2;

	internal CheckBox FA897C39;

	internal GroupBox A2B039A3;

	internal GroupBox grThemMailKhoiPhuc;

	internal CheckBox ckbThemKyTuGetnada;

	internal Panel plThemKyTuGetnada;

	internal TextBox txtKyTuChiDinh;

	internal Label label1;

	internal NumericUpDown nudTimeoutGetOtpGetnada;

	internal GroupBox ADB26B9A;

	internal RadioButton rbPassChiDinh;

	internal RadioButton DBB2E306;

	internal TextBox txtPassChiDinh;

	internal CheckBox ckbXoaMailKhoiPhucCu;

	internal ComboBox cbbDomainGetnada;

	internal GroupBox grUnlockHotmail;

	internal ComboBox cbbTypePhone;

	internal TextBox txtApiPhone;

	internal NumericUpDown nudTimeoutGetOtpPhone;

	internal Label label4;

	internal CheckBox ckbThemMailKhoiPhuc;

	internal Button button2;

	internal Label label3;

	internal ComboBox cbbTypeEmail;

	internal Panel AB3670A1;

	internal Label lblDomainGenerator;

	internal Label lblDomainMoakt;

	internal Label lblDomainGetnada;

	internal ComboBox cbbDomainMoakt;

	internal GroupBox B097D9A7;

	internal TextBox CB826CA9;

	internal Label E2A9ED0F;

	internal NumericUpDown nudCountGetPhone;

	internal Label E288AC1A;

	internal TextBox txtDomainGenerator;

	internal ComboBox cbbTypeKyTuHotmail;

	internal ComboBox D0090C1D;

	internal TextBox ABB29512;

	internal Button btnCheckCaptcha;

	internal Label AE82DC08;

	internal Button btnNhapSdt;

	internal GroupBox E5B30BA8;

	internal TextBox txtJunkEmail;

	internal Label label6;

	internal GroupBox groupBox1;

	internal Label label15;

	internal ComboBox CC280E8F;

	internal Label lblDomainMailtula;

	internal ComboBox cbbDomainMailtula;

	internal CheckBox ckbGetOAuth2;

	public fCauHinhHotmail(string D8049BB5 = "")
	{
		InitializeComponent();
		bool_0 = false;
		if (D8049BB5.Contains("LoginHotmail"))
		{
			A2B039A3.Paint += E5B30BA8_Paint;
		}
		if (D8049BB5.Contains("ThemMailKhoiPhuc"))
		{
			grThemMailKhoiPhuc.Paint += E5B30BA8_Paint;
		}
		if (D8049BB5.Contains("DoiPassHotmail"))
		{
			ADB26B9A.Paint += E5B30BA8_Paint;
		}
		if (D8049BB5.Contains("UnlockHotmail"))
		{
			grUnlockHotmail.Paint += E5B30BA8_Paint;
		}
		if (D8049BB5.Contains("ForwardMail"))
		{
			B097D9A7.Paint += E5B30BA8_Paint;
		}
		if (D8049BB5.Contains("AddJunkEmail"))
		{
			E5B30BA8.Paint += E5B30BA8_Paint;
		}
		Language.CD21F0A9(this);
		if (Base.A9352D3F)
		{
			base.Height = 381;
		}
	}

	private void E5B30BA8_Paint(object sender, PaintEventArgs e)
	{
		GroupBox dA2A = sender as GroupBox;
		F115AB38(dA2A, e.Graphics, Color.Black, Color.Red);
	}

	private void F115AB38(GroupBox DA2A4028, Graphics AF34F892, Color color_0, Color C18B9A16)
	{
		if (DA2A4028 != null)
		{
			new SolidBrush(color_0);
			Brush brush = new SolidBrush(C18B9A16);
			Pen pen = new Pen(brush);
			SizeF sizeF = AF34F892.MeasureString(DA2A4028.Text, DA2A4028.Font);
			Rectangle rectangle = new Rectangle(DA2A4028.ClientRectangle.X, DA2A4028.ClientRectangle.Y + (int)(sizeF.Height / 2f), DA2A4028.ClientRectangle.Width - 1, DA2A4028.ClientRectangle.Height - (int)(sizeF.Height / 2f) - 1);
			AF34F892.DrawLine(pen, rectangle.Location, new Point(rectangle.X, rectangle.Y + rectangle.Height));
			AF34F892.DrawLine(pen, new Point(rectangle.X + rectangle.Width, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
			AF34F892.DrawLine(pen, new Point(rectangle.X, rectangle.Y + rectangle.Height), new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
			AF34F892.DrawLine(pen, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X + DA2A4028.Padding.Left, rectangle.Y));
			AF34F892.DrawLine(pen, new Point(rectangle.X + DA2A4028.Padding.Left + (int)sizeF.Width, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y));
		}
	}

	private void D9358906(object sender, EventArgs e)
	{
		method_0();
		A4B3B302();
		method_2();
		BD0EB225();
		method_3();
		method_1();
		try
		{
			CC280E8F.SelectedValue = C5034B95.smethod_0("configHotmail").BDB80B23("cbbChangeIP", "0");
			int num = C5034B95.smethod_0("configRegHotmail").method_2("typeCaptcha");
			try
			{
				D0090C1D.SelectedValue = num.ToString();
			}
			catch
			{
			}
			ABB29512.Text = C5034B95.smethod_0("configRegHotmail").BDB80B23("txtCaptcha_" + num);
			FA897C39.Checked = C5034B95.smethod_0("configHotmail").method_3("ckbUseProfile");
			B489E1B2.Checked = C5034B95.smethod_0("configHotmail").method_3("ckbCloseChrome");
			ckbGetOAuth2.Checked = C5034B95.smethod_0("configHotmail").method_3("ckbGetOAuth2");
			int num2 = C5034B95.smethod_0("configHotmail").method_2("typeSim");
			try
			{
				cbbTypePhone.SelectedValue = num2.ToString();
			}
			catch
			{
			}
			txtApiPhone.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtApiPhone_" + num2);
			nudCountGetPhone.Value = C5034B95.smethod_0("configHotmail").method_2("nudCountGetPhone", 1);
			nudTimeoutGetOtpPhone.Value = C5034B95.smethod_0("configHotmail").method_2("nudTimeoutGetOtpPhone", 60);
			ckbThemMailKhoiPhuc.Checked = C5034B95.smethod_0("configHotmail").method_3("ckbThemMailKhoiPhuc");
			ckbThemKyTuGetnada.Checked = C5034B95.smethod_0("configHotmail").method_3("ckbThemKyTuGetnada");
			cbbTypeKyTuHotmail.SelectedIndex = C5034B95.smethod_0("configHotmail").method_2("typeKyTu");
			txtKyTuChiDinh.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtKyTuChiDinh");
			nudTimeoutGetOtpGetnada.Value = C5034B95.smethod_0("configHotmail").method_2("nudTimeoutGetOtpGetnada", 60);
			if (nudTimeoutGetOtpGetnada.Value == 0m)
			{
				nudTimeoutGetOtpGetnada.Value = 60m;
			}
			ckbXoaMailKhoiPhucCu.Checked = C5034B95.smethod_0("configHotmail").method_3("ckbXoaMailKhoiPhucCu", C9B3010F: true);
			cbbTypeEmail.SelectedValue = C5034B95.smethod_0("configHotmail").BDB80B23("cbbTypeEmail", "1");
			cbbDomainGetnada.Text = C5034B95.smethod_0("configHotmail").BDB80B23("cbbDomainGetnada", "getnada.com");
			cbbDomainMoakt.Text = C5034B95.smethod_0("configHotmail").BDB80B23("cbbDomainMoakt", "teml.net");
			cbbDomainMailtula.Text = C5034B95.smethod_0("configHotmail").BDB80B23("cbbDomainMailtula", "mailtula.com");
			txtDomainGenerator.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtDomainGenerator");
			if (C5034B95.smethod_0("configHotmail").method_2("typePassword") == 0)
			{
				DBB2E306.Checked = true;
			}
			else
			{
				rbPassChiDinh.Checked = true;
			}
			txtPassChiDinh.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtPassChiDinh");
			CB826CA9.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtMailForward");
			txtJunkEmail.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtJunkEmail");
		}
		catch
		{
		}
		BB94930B();
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Không đổi IP");
		dictionary.Add("9", "Proxy (Đã gán vào tài khoản)");
		Commom.smethod_24(CC280E8F, dictionary);
	}

	private void A4B3B302()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "blondmail.com");
		dictionary.Add("1", "chapsmail.com");
		dictionary.Add("2", "clowmail.com");
		dictionary.Add("3", "dropjar.com");
		dictionary.Add("4", "fivermail.com");
		dictionary.Add("5", "getairmail.com");
		dictionary.Add("6", "getmule.com");
		dictionary.Add("7", "getnada.com");
		dictionary.Add("8", "gimpmail.com");
		dictionary.Add("9", "givmail.com");
		dictionary.Add("10", "guysmail.com");
		dictionary.Add("11", "inboxbear.com");
		dictionary.Add("12", "replyloop.com");
		dictionary.Add("13", "robot-mail.com");
		dictionary.Add("14", "spicysoda.com");
		dictionary.Add("15", "tafmail.com");
		dictionary.Add("16", "temptami.com");
		dictionary.Add("17", "tupmail.com");
		dictionary.Add("18", "vomoto.com");
		Commom.smethod_24(cbbDomainGetnada, dictionary);
	}

	private void method_1()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("12", "https://www.capsolver.com/");
		D0090C1D.DataSource = new BindingSource(dictionary, null);
		D0090C1D.DisplayMember = "Value";
		D0090C1D.ValueMember = "Key";
	}

	private void method_2()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (Base.bool_0)
		{
			dictionary.Add("50", "http://mthgroup.vn");
		}
		dictionary.Add("58", "https://dailyotp.com/");
		dictionary.Add("60", "https://5sim.net/ US");
		dictionary.Add("51", "https://5sim.net/ RU");
		dictionary.Add("44", "https://5sim.net/ IN");
		dictionary.Add("12", "https://winmail.shop/");
		dictionary.Add("45", "https://winmail.shop/ RU");
		dictionary.Add("53", "https://fastsim.online/");
		dictionary.Add("57", "https://ironsim.com/ US");
		dictionary.Add("30", "https://ironsim.com/");
		dictionary.Add("9", "https://otptextnow.com/");
		dictionary.Add("19", "http://hcotp.com/");
		dictionary.Add("13", "https://sim24.cc/");
		dictionary.Add("8", "https://viotp.com/");
		dictionary.Add("32", "https://thuesim.app/");
		dictionary.Add("39", "https://smartotp.net/");
		Commom.smethod_24(cbbTypePhone, dictionary);
	}

	private void BD0EB225()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "https://getnada.com/");
		dictionary.Add("1", "https://moakt.com/");
		dictionary.Add("2", "https://generator.email/");
		if (Base.bool_0)
		{
			dictionary.Add("3", "otpgmail");
		}
		dictionary.Add("4", "https://mailnesia.com/");
		dictionary.Add("5", "https://smvmail.com/");
		if (Base.A9352D3F)
		{
			dictionary.Add("8", "https://mailtula.com/");
		}
		Commom.smethod_24(cbbTypeEmail, dictionary);
	}

	private void method_3()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Ngẫu nhiên");
		dictionary.Add("1", "Chỉ định");
		Commom.smethod_24(cbbTypeKyTuHotmail, dictionary);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void FD9F1D3C_Click(object sender, EventArgs e)
	{
		try
		{
			C5034B95.smethod_0("configHotmail").method_4("cbbChangeIP", CC280E8F.SelectedValue);
			C5034B95.smethod_0("configHotmail").method_4("ckbUseProfile", FA897C39.Checked);
			C5034B95.smethod_0("configHotmail").method_4("ckbCloseChrome", B489E1B2.Checked);
			C5034B95.smethod_0("configHotmail").method_4("ckbGetOAuth2", ckbGetOAuth2.Checked);
			int num = 0;
			try
			{
				num = Convert.ToInt32(cbbTypePhone.SelectedValue);
			}
			catch (Exception)
			{
			}
			C5034B95.smethod_0("configHotmail").method_4("typeSim", num);
			C5034B95.smethod_0("configHotmail").method_4("txtApiPhone_" + num, txtApiPhone.Text);
			C5034B95.smethod_0("configHotmail").method_4("nudCountGetPhone", nudCountGetPhone.Value);
			C5034B95.smethod_0("configHotmail").method_4("nudTimeoutGetOtpPhone", nudTimeoutGetOtpPhone.Value);
			C5034B95.smethod_0("configHotmail").method_4("ckbThemMailKhoiPhuc", ckbThemMailKhoiPhuc.Checked);
			C5034B95.smethod_0("configHotmail").method_4("ckbThemKyTuGetnada", ckbThemKyTuGetnada.Checked);
			C5034B95.smethod_0("configHotmail").method_4("typeKyTu", cbbTypeKyTuHotmail.SelectedIndex);
			C5034B95.smethod_0("configHotmail").method_4("txtKyTuChiDinh", txtKyTuChiDinh.Text);
			C5034B95.smethod_0("configHotmail").method_4("nudTimeoutGetOtpGetnada", nudTimeoutGetOtpGetnada.Value);
			C5034B95.smethod_0("configHotmail").method_4("ckbXoaMailKhoiPhucCu", true);
			C5034B95.smethod_0("configHotmail").method_4("cbbTypeEmail", cbbTypeEmail.SelectedValue);
			C5034B95.smethod_0("configHotmail").method_4("cbbDomainGetnada", cbbDomainGetnada.Text);
			C5034B95.smethod_0("configHotmail").method_4("cbbDomainMoakt", cbbDomainMoakt.Text);
			C5034B95.smethod_0("configHotmail").method_4("cbbDomainMailtula", cbbDomainMailtula.Text);
			C5034B95.smethod_0("configHotmail").method_4("txtDomainGenerator", txtDomainGenerator.Text.Trim());
			int num2 = 0;
			if (rbPassChiDinh.Checked)
			{
				num2 = 1;
			}
			C5034B95.smethod_0("configHotmail").method_4("typePassword", num2);
			C5034B95.smethod_0("configHotmail").method_4("txtPassChiDinh", txtPassChiDinh.Text);
			C5034B95.smethod_0("configHotmail").method_4("txtMailForward", CB826CA9.Text);
			C5034B95.smethod_0("configHotmail").method_4("txtJunkEmail", txtJunkEmail.Text);
			C5034B95.smethod_1("configHotmail");
			int num3 = 0;
			try
			{
				num3 = Convert.ToInt32(D0090C1D.SelectedValue);
			}
			catch (Exception)
			{
			}
			C5034B95.smethod_0("configRegHotmail").method_4("typeCaptcha", num3);
			C5034B95.smethod_0("configRegHotmail").method_4("txtCaptcha_" + num3, ABB29512.Text);
			C5034B95.smethod_1("configRegHotmail");
			bool_0 = true;
			Close();
		}
		catch
		{
			MsBoxHelper.Show("Vui lòng thử lại sau!", 2);
		}
	}

	private void BB94930B()
	{
		ckbThemKyTuGetnada_CheckedChanged(null, null);
		C5A54A32(null, null);
		D5232900(null, null);
		cbbTypeEmail_SelectedIndexChanged(null, null);
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

	private void ckbThemKyTuGetnada_CheckedChanged(object sender, EventArgs e)
	{
		plThemKyTuGetnada.Enabled = ckbThemKyTuGetnada.Checked;
	}

	private void D5232900(object sender, EventArgs e)
	{
		txtPassChiDinh.Enabled = rbPassChiDinh.Checked;
	}

	private void cbbTypePhone_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = "0";
		try
		{
			text = cbbTypePhone.SelectedValue.ToString();
		}
		catch
		{
		}
		txtApiPhone.Text = C5034B95.smethod_0("configHotmail").BDB80B23("txtApiPhone_" + text);
		btnNhapSdt.Visible = text == "50";
	}

	private void D3816B9B(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(C5034B95.smethod_0("configHotmail").method_1("lstProxyGetnada"), "Nhâ\u0323p danh sa\u0301ch proxy dùng để lấy otp từ getnada", "Nhập danh sách Proxy", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		C5034B95.smethod_0("configHotmail").FD3CCF90("lstProxyGetnada", fNhapDuLieu4.list_0);
		C5034B95.smethod_1("configHotmail");
	}

	private void cbbTypeEmail_SelectedIndexChanged(object sender, EventArgs e)
	{
		lblDomainGetnada.Enabled = cbbTypeEmail.SelectedValue.ToString() == "0";
		cbbDomainGetnada.Enabled = cbbTypeEmail.SelectedValue.ToString() == "0";
		lblDomainMoakt.Enabled = cbbTypeEmail.SelectedValue.ToString() == "1";
		cbbDomainMoakt.Enabled = cbbTypeEmail.SelectedValue.ToString() == "1";
		lblDomainGenerator.Enabled = cbbTypeEmail.SelectedValue.ToString() == "2";
		txtDomainGenerator.Enabled = cbbTypeEmail.SelectedValue.ToString() == "2";
		lblDomainMailtula.Enabled = cbbTypeEmail.SelectedValue.ToString() == "8";
		cbbDomainMailtula.Enabled = cbbTypeEmail.SelectedValue.ToString() == "8";
	}

	private void C5A54A32(object sender, EventArgs e)
	{
		txtKyTuChiDinh.Enabled = cbbTypeKyTuHotmail.SelectedIndex == 1;
	}

	private void B5B01638(object sender, EventArgs e)
	{
		A2B039A3.Height = 46;
	}

	private void method_4(object sender, EventArgs e)
	{
		A2B039A3.Height = 79;
	}

	private void btnCheckCaptcha_Click(object sender, EventArgs e)
	{
		string object_ = Commom.smethod_0(D0090C1D.Text.ToString(), ABB29512.Text.Trim());
		MsBoxHelper.Show(object_);
	}

	private void CC19F83A(object sender, EventArgs e)
	{
		try
		{
			ABB29512.Text = C5034B95.smethod_0("configRegHotmail").BDB80B23("txtCaptcha_" + D0090C1D.SelectedValue.ToString());
		}
		catch
		{
		}
	}

	private void BD16163B(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(C5034B95.smethod_0("configHotmail").method_1("lstSdt"), "Nhâ\u0323p danh sa\u0301ch Sđt", "Nhập danh sách Sđt", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		C5034B95.smethod_0("configHotmail").FD3CCF90("lstSdt", fNhapDuLieu4.list_0);
		C5034B95.smethod_1("configHotmail");
	}

	private void B331B092(object sender, EventArgs e)
	{
		try
		{
			if (cbbTypePhone.SelectedValue.ToString() == "58" && txtApiPhone.Text.Trim() == "" && !bool_1)
			{
				bool_1 = true;
				MsBoxHelper.Show("Vui lòng nhập đi\u0323nh da\u0323ng username|password");
			}
		}
		catch (Exception)
		{
		}
	}

	protected override void Dispose(bool F001E917)
	{
		if (F001E917 && AE2B2A88 != null)
		{
			AE2B2A88.Dispose();
		}
		base.Dispose(F001E917);
	}

	private void InitializeComponent()
	{
		AE2B2A88 = new System.ComponentModel.Container();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(AE2B2A88);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		FEA5EFA7 = new Bunifu.Framework.UI.BunifuDragControl(AE2B2A88);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		groupBox1 = new System.Windows.Forms.GroupBox();
		label15 = new System.Windows.Forms.Label();
		CC280E8F = new System.Windows.Forms.ComboBox();
		FA897C39 = new System.Windows.Forms.CheckBox();
		D0090C1D = new System.Windows.Forms.ComboBox();
		AE82DC08 = new System.Windows.Forms.Label();
		btnCheckCaptcha = new System.Windows.Forms.Button();
		ABB29512 = new System.Windows.Forms.TextBox();
		grThemMailKhoiPhuc = new System.Windows.Forms.GroupBox();
		AB3670A1 = new System.Windows.Forms.Panel();
		lblDomainMailtula = new System.Windows.Forms.Label();
		cbbDomainMailtula = new System.Windows.Forms.ComboBox();
		txtDomainGenerator = new System.Windows.Forms.TextBox();
		lblDomainGenerator = new System.Windows.Forms.Label();
		lblDomainMoakt = new System.Windows.Forms.Label();
		lblDomainGetnada = new System.Windows.Forms.Label();
		cbbDomainMoakt = new System.Windows.Forms.ComboBox();
		cbbDomainGetnada = new System.Windows.Forms.ComboBox();
		label3 = new System.Windows.Forms.Label();
		cbbTypeEmail = new System.Windows.Forms.ComboBox();
		button2 = new System.Windows.Forms.Button();
		ckbXoaMailKhoiPhucCu = new System.Windows.Forms.CheckBox();
		ckbThemKyTuGetnada = new System.Windows.Forms.CheckBox();
		plThemKyTuGetnada = new System.Windows.Forms.Panel();
		cbbTypeKyTuHotmail = new System.Windows.Forms.ComboBox();
		txtKyTuChiDinh = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		nudTimeoutGetOtpGetnada = new System.Windows.Forms.NumericUpDown();
		ADB26B9A = new System.Windows.Forms.GroupBox();
		txtPassChiDinh = new System.Windows.Forms.TextBox();
		rbPassChiDinh = new System.Windows.Forms.RadioButton();
		DBB2E306 = new System.Windows.Forms.RadioButton();
		A2B039A3 = new System.Windows.Forms.GroupBox();
		ckbGetOAuth2 = new System.Windows.Forms.CheckBox();
		B489E1B2 = new System.Windows.Forms.CheckBox();
		E5B30BA8 = new System.Windows.Forms.GroupBox();
		txtJunkEmail = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		B097D9A7 = new System.Windows.Forms.GroupBox();
		CB826CA9 = new System.Windows.Forms.TextBox();
		E2A9ED0F = new System.Windows.Forms.Label();
		grUnlockHotmail = new System.Windows.Forms.GroupBox();
		ckbThemMailKhoiPhuc = new System.Windows.Forms.CheckBox();
		cbbTypePhone = new System.Windows.Forms.ComboBox();
		txtApiPhone = new System.Windows.Forms.TextBox();
		btnNhapSdt = new System.Windows.Forms.Button();
		nudCountGetPhone = new System.Windows.Forms.NumericUpDown();
		E288AC1A = new System.Windows.Forms.Label();
		nudTimeoutGetOtpPhone = new System.Windows.Forms.NumericUpDown();
		label4 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		FD9F1D3C = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		CC842F33 = new System.ComponentModel.BackgroundWorker();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		groupBox1.SuspendLayout();
		grThemMailKhoiPhuc.SuspendLayout();
		AB3670A1.SuspendLayout();
		plThemKyTuGetnada.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTimeoutGetOtpGetnada).BeginInit();
		ADB26B9A.SuspendLayout();
		A2B039A3.SuspendLayout();
		E5B30BA8.SuspendLayout();
		B097D9A7.SuspendLayout();
		grUnlockHotmail.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountGetPhone).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeoutGetOtpPhone).BeginInit();
		bunifuCards1.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(764, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Hotmail";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		FEA5EFA7.Fixed = true;
		FEA5EFA7.Horizontal = true;
		FEA5EFA7.TargetControl = pnlHeader;
		FEA5EFA7.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(764, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = Class155.FF80C508;
		button1.Location = new System.Drawing.Point(733, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
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
		panel1.Controls.Add(groupBox1);
		panel1.Controls.Add(grThemMailKhoiPhuc);
		panel1.Controls.Add(ADB26B9A);
		panel1.Controls.Add(A2B039A3);
		panel1.Controls.Add(E5B30BA8);
		panel1.Controls.Add(B097D9A7);
		panel1.Controls.Add(grUnlockHotmail);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(FD9F1D3C);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(767, 349);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		groupBox1.Controls.Add(label15);
		groupBox1.Controls.Add(CC280E8F);
		groupBox1.Controls.Add(FA897C39);
		groupBox1.Controls.Add(D0090C1D);
		groupBox1.Controls.Add(AE82DC08);
		groupBox1.Controls.Add(btnCheckCaptcha);
		groupBox1.Controls.Add(ABB29512);
		groupBox1.Location = new System.Drawing.Point(30, 55);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(346, 99);
		groupBox1.TabIndex = 212;
		groupBox1.TabStop = false;
		groupBox1.Text = "Cấu hình chung";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label15.Location = new System.Drawing.Point(3, 19);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(126, 16);
		label15.TabIndex = 200;
		label15.Text = "Tùy chọn Change IP:";
		CC280E8F.Cursor = System.Windows.Forms.Cursors.Hand;
		CC280E8F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		CC280E8F.FormattingEnabled = true;
		CC280E8F.Location = new System.Drawing.Point(133, 16);
		CC280E8F.Name = "cbbChangeIP";
		CC280E8F.Size = new System.Drawing.Size(206, 24);
		CC280E8F.TabIndex = 199;
		FA897C39.AutoSize = true;
		FA897C39.Cursor = System.Windows.Forms.Cursors.Hand;
		FA897C39.Location = new System.Drawing.Point(7, 44);
		FA897C39.Name = "ckbUseProfile";
		FA897C39.Size = new System.Drawing.Size(161, 20);
		FA897C39.TabIndex = 32;
		FA897C39.Text = "Sử dụng profile chrome";
		FA897C39.UseVisualStyleBackColor = true;
		D0090C1D.Cursor = System.Windows.Forms.Cursors.Hand;
		D0090C1D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		D0090C1D.DropDownWidth = 200;
		D0090C1D.FormattingEnabled = true;
		D0090C1D.Location = new System.Drawing.Point(65, 67);
		D0090C1D.Name = "cbbCaptcha";
		D0090C1D.Size = new System.Drawing.Size(79, 24);
		D0090C1D.TabIndex = 211;
		D0090C1D.SelectedIndexChanged += new System.EventHandler(CC19F83A);
		AE82DC08.AutoSize = true;
		AE82DC08.Location = new System.Drawing.Point(3, 71);
		AE82DC08.Name = "label13";
		AE82DC08.Size = new System.Drawing.Size(58, 16);
		AE82DC08.TabIndex = 208;
		AE82DC08.Text = "Captcha:";
		btnCheckCaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCheckCaptcha.Location = new System.Drawing.Point(290, 67);
		btnCheckCaptcha.Name = "btnCheckCaptcha";
		btnCheckCaptcha.Size = new System.Drawing.Size(49, 25);
		btnCheckCaptcha.TabIndex = 210;
		btnCheckCaptcha.Text = "Check";
		btnCheckCaptcha.UseVisualStyleBackColor = true;
		btnCheckCaptcha.Click += new System.EventHandler(btnCheckCaptcha_Click);
		ABB29512.Location = new System.Drawing.Point(150, 68);
		ABB29512.Name = "txtCaptcha";
		ABB29512.Size = new System.Drawing.Size(134, 23);
		ABB29512.TabIndex = 209;
		grThemMailKhoiPhuc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		grThemMailKhoiPhuc.Controls.Add(AB3670A1);
		grThemMailKhoiPhuc.Controls.Add(label3);
		grThemMailKhoiPhuc.Controls.Add(cbbTypeEmail);
		grThemMailKhoiPhuc.Controls.Add(button2);
		grThemMailKhoiPhuc.Controls.Add(ckbXoaMailKhoiPhucCu);
		grThemMailKhoiPhuc.Controls.Add(ckbThemKyTuGetnada);
		grThemMailKhoiPhuc.Controls.Add(plThemKyTuGetnada);
		grThemMailKhoiPhuc.Controls.Add(label1);
		grThemMailKhoiPhuc.Controls.Add(nudTimeoutGetOtpGetnada);
		grThemMailKhoiPhuc.Location = new System.Drawing.Point(382, 55);
		grThemMailKhoiPhuc.Name = "grThemMailKhoiPhuc";
		grThemMailKhoiPhuc.Size = new System.Drawing.Size(350, 234);
		grThemMailKhoiPhuc.TabIndex = 204;
		grThemMailKhoiPhuc.TabStop = false;
		grThemMailKhoiPhuc.Text = "Thêm mail khôi phục";
		AB3670A1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		AB3670A1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		AB3670A1.Controls.Add(lblDomainMailtula);
		AB3670A1.Controls.Add(cbbDomainMailtula);
		AB3670A1.Controls.Add(txtDomainGenerator);
		AB3670A1.Controls.Add(lblDomainGenerator);
		AB3670A1.Controls.Add(lblDomainMoakt);
		AB3670A1.Controls.Add(lblDomainGetnada);
		AB3670A1.Controls.Add(cbbDomainMoakt);
		AB3670A1.Controls.Add(cbbDomainGetnada);
		AB3670A1.Location = new System.Drawing.Point(9, 135);
		AB3670A1.Name = "panel2";
		AB3670A1.Size = new System.Drawing.Size(333, 92);
		AB3670A1.TabIndex = 208;
		lblDomainMailtula.AutoSize = true;
		lblDomainMailtula.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		lblDomainMailtula.Location = new System.Drawing.Point(4, 95);
		lblDomainMailtula.Name = "lblDomainMailtula";
		lblDomainMailtula.Size = new System.Drawing.Size(104, 16);
		lblDomainMailtula.TabIndex = 204;
		lblDomainMailtula.Text = "Domain mailtula:";
		cbbDomainMailtula.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDomainMailtula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDomainMailtula.FormattingEnabled = true;
		cbbDomainMailtula.Items.AddRange(new object[4] { "mailtula.com", "mailtula.live", "tulasub.com", "inboxbear.xyz" });
		cbbDomainMailtula.Location = new System.Drawing.Point(121, 92);
		cbbDomainMailtula.Name = "cbbDomainMailtula";
		cbbDomainMailtula.Size = new System.Drawing.Size(206, 24);
		cbbDomainMailtula.TabIndex = 203;
		txtDomainGenerator.Location = new System.Drawing.Point(121, 63);
		txtDomainGenerator.Name = "txtDomainGenerator";
		txtDomainGenerator.Size = new System.Drawing.Size(206, 23);
		txtDomainGenerator.TabIndex = 34;
		lblDomainGenerator.AutoSize = true;
		lblDomainGenerator.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		lblDomainGenerator.Location = new System.Drawing.Point(4, 66);
		lblDomainGenerator.Name = "lblDomainGenerator";
		lblDomainGenerator.Size = new System.Drawing.Size(115, 16);
		lblDomainGenerator.TabIndex = 202;
		lblDomainGenerator.Text = "Domain generator:";
		lblDomainMoakt.AutoSize = true;
		lblDomainMoakt.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		lblDomainMoakt.Location = new System.Drawing.Point(4, 37);
		lblDomainMoakt.Name = "lblDomainMoakt";
		lblDomainMoakt.Size = new System.Drawing.Size(94, 16);
		lblDomainMoakt.TabIndex = 202;
		lblDomainMoakt.Text = "Domain moakt:";
		lblDomainGetnada.AutoSize = true;
		lblDomainGetnada.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		lblDomainGetnada.Location = new System.Drawing.Point(4, 8);
		lblDomainGetnada.Name = "lblDomainGetnada";
		lblDomainGetnada.Size = new System.Drawing.Size(105, 16);
		lblDomainGetnada.TabIndex = 202;
		lblDomainGetnada.Text = "Domain getnada:";
		cbbDomainMoakt.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDomainMoakt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDomainMoakt.FormattingEnabled = true;
		cbbDomainMoakt.Items.AddRange(new object[13]
		{
			"teml.net", "tmpeml.com", "tmpbox.net", "moakt.cc", "disbox.net", "tmpmail.org", "tmpmail.net", "tmails.net", "disbox.org", "moakt.co",
			"moakt.ws", "tmail.ws", "bareed.ws"
		});
		cbbDomainMoakt.Location = new System.Drawing.Point(121, 34);
		cbbDomainMoakt.Name = "cbbDomainMoakt";
		cbbDomainMoakt.Size = new System.Drawing.Size(206, 24);
		cbbDomainMoakt.TabIndex = 201;
		cbbDomainGetnada.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbDomainGetnada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbDomainGetnada.FormattingEnabled = true;
		cbbDomainGetnada.Location = new System.Drawing.Point(121, 5);
		cbbDomainGetnada.Name = "cbbDomainGetnada";
		cbbDomainGetnada.Size = new System.Drawing.Size(206, 24);
		cbbDomainGetnada.TabIndex = 199;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label3.Location = new System.Drawing.Point(5, 109);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(93, 16);
		label3.TabIndex = 207;
		label3.Text = "Chọn loại mail:";
		cbbTypeEmail.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeEmail.FormattingEnabled = true;
		cbbTypeEmail.Location = new System.Drawing.Point(131, 106);
		cbbTypeEmail.Name = "cbbTypeEmail";
		cbbTypeEmail.Size = new System.Drawing.Size(211, 24);
		cbbTypeEmail.TabIndex = 206;
		cbbTypeEmail.SelectedIndexChanged += new System.EventHandler(cbbTypeEmail_SelectedIndexChanged);
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Location = new System.Drawing.Point(189, 77);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(153, 25);
		button2.TabIndex = 205;
		button2.Text = "Proxy (get otp getnada)";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(D3816B9B);
		ckbXoaMailKhoiPhucCu.AutoSize = true;
		ckbXoaMailKhoiPhucCu.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaMailKhoiPhucCu.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbXoaMailKhoiPhucCu.Location = new System.Drawing.Point(6, 323);
		ckbXoaMailKhoiPhucCu.Name = "ckbXoaMailKhoiPhucCu";
		ckbXoaMailKhoiPhucCu.Size = new System.Drawing.Size(151, 20);
		ckbXoaMailKhoiPhucCu.TabIndex = 8;
		ckbXoaMailKhoiPhucCu.Text = "Xóa mail khôi phục cũ";
		ckbXoaMailKhoiPhucCu.UseVisualStyleBackColor = true;
		ckbThemKyTuGetnada.AutoSize = true;
		ckbThemKyTuGetnada.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThemKyTuGetnada.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbThemKyTuGetnada.Location = new System.Drawing.Point(6, 18);
		ckbThemKyTuGetnada.Name = "ckbThemKyTuGetnada";
		ckbThemKyTuGetnada.Size = new System.Drawing.Size(190, 20);
		ckbThemKyTuGetnada.TabIndex = 8;
		ckbThemKyTuGetnada.Text = "Thêm kí tự vào cuối hotmail:";
		ckbThemKyTuGetnada.UseVisualStyleBackColor = true;
		ckbThemKyTuGetnada.CheckedChanged += new System.EventHandler(ckbThemKyTuGetnada_CheckedChanged);
		plThemKyTuGetnada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plThemKyTuGetnada.Controls.Add(cbbTypeKyTuHotmail);
		plThemKyTuGetnada.Controls.Add(txtKyTuChiDinh);
		plThemKyTuGetnada.Location = new System.Drawing.Point(9, 39);
		plThemKyTuGetnada.Name = "plThemKyTuGetnada";
		plThemKyTuGetnada.Size = new System.Drawing.Size(333, 33);
		plThemKyTuGetnada.TabIndex = 9;
		cbbTypeKyTuHotmail.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeKyTuHotmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeKyTuHotmail.FormattingEnabled = true;
		cbbTypeKyTuHotmail.Location = new System.Drawing.Point(3, 4);
		cbbTypeKyTuHotmail.Name = "cbbTypeKyTuHotmail";
		cbbTypeKyTuHotmail.Size = new System.Drawing.Size(112, 24);
		cbbTypeKyTuHotmail.TabIndex = 33;
		cbbTypeKyTuHotmail.SelectedIndexChanged += new System.EventHandler(C5A54A32);
		txtKyTuChiDinh.Location = new System.Drawing.Point(121, 4);
		txtKyTuChiDinh.Name = "txtKyTuChiDinh";
		txtKyTuChiDinh.Size = new System.Drawing.Size(206, 23);
		txtKyTuChiDinh.TabIndex = 7;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(5, 80);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(123, 16);
		label1.TabIndex = 201;
		label1.Text = "Timeout get otp (s):";
		nudTimeoutGetOtpGetnada.Location = new System.Drawing.Point(131, 78);
		nudTimeoutGetOtpGetnada.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeoutGetOtpGetnada.Name = "nudTimeoutGetOtpGetnada";
		nudTimeoutGetOtpGetnada.Size = new System.Drawing.Size(56, 23);
		nudTimeoutGetOtpGetnada.TabIndex = 202;
		ADB26B9A.Controls.Add(txtPassChiDinh);
		ADB26B9A.Controls.Add(rbPassChiDinh);
		ADB26B9A.Controls.Add(DBB2E306);
		ADB26B9A.Location = new System.Drawing.Point(30, 212);
		ADB26B9A.Name = "grDoiPassHotmail";
		ADB26B9A.Size = new System.Drawing.Size(346, 77);
		ADB26B9A.TabIndex = 203;
		ADB26B9A.TabStop = false;
		ADB26B9A.Text = "Đổi mật khẩu hotmail";
		txtPassChiDinh.Location = new System.Drawing.Point(147, 47);
		txtPassChiDinh.Name = "txtPassChiDinh";
		txtPassChiDinh.Size = new System.Drawing.Size(195, 23);
		txtPassChiDinh.TabIndex = 7;
		rbPassChiDinh.AutoSize = true;
		rbPassChiDinh.Cursor = System.Windows.Forms.Cursors.Hand;
		rbPassChiDinh.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rbPassChiDinh.Location = new System.Drawing.Point(6, 48);
		rbPassChiDinh.Name = "rbPassChiDinh";
		rbPassChiDinh.Size = new System.Drawing.Size(125, 20);
		rbPassChiDinh.TabIndex = 6;
		rbPassChiDinh.TabStop = true;
		rbPassChiDinh.Text = "Mật khẩu chỉ định";
		rbPassChiDinh.UseVisualStyleBackColor = true;
		rbPassChiDinh.CheckedChanged += new System.EventHandler(D5232900);
		DBB2E306.AutoSize = true;
		DBB2E306.Cursor = System.Windows.Forms.Cursors.Hand;
		DBB2E306.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		DBB2E306.Location = new System.Drawing.Point(6, 22);
		DBB2E306.Name = "rbPassRandom";
		DBB2E306.Size = new System.Drawing.Size(144, 20);
		DBB2E306.TabIndex = 5;
		DBB2E306.TabStop = true;
		DBB2E306.Text = "Mật khẩu ngẫu nhiên";
		DBB2E306.UseVisualStyleBackColor = true;
		A2B039A3.Controls.Add(ckbGetOAuth2);
		A2B039A3.Controls.Add(B489E1B2);
		A2B039A3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A2B039A3.Location = new System.Drawing.Point(30, 160);
		A2B039A3.Name = "grLoginHotmail";
		A2B039A3.Size = new System.Drawing.Size(346, 46);
		A2B039A3.TabIndex = 205;
		A2B039A3.TabStop = false;
		A2B039A3.Text = "Login hotmail";
		ckbGetOAuth2.AutoSize = true;
		ckbGetOAuth2.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGetOAuth2.Location = new System.Drawing.Point(229, 22);
		ckbGetOAuth2.Name = "ckbGetOAuth2";
		ckbGetOAuth2.Size = new System.Drawing.Size(110, 20);
		ckbGetOAuth2.TabIndex = 33;
		ckbGetOAuth2.Text = "Enable OAuth2";
		ckbGetOAuth2.UseVisualStyleBackColor = true;
		B489E1B2.AutoSize = true;
		B489E1B2.Cursor = System.Windows.Forms.Cursors.Hand;
		B489E1B2.Location = new System.Drawing.Point(7, 22);
		B489E1B2.Name = "ckbCloseChrome";
		B489E1B2.Size = new System.Drawing.Size(211, 20);
		B489E1B2.TabIndex = 32;
		B489E1B2.Text = "Đóng chrome sau khi đăng nhập";
		B489E1B2.UseVisualStyleBackColor = true;
		E5B30BA8.Controls.Add(txtJunkEmail);
		E5B30BA8.Controls.Add(label6);
		E5B30BA8.Location = new System.Drawing.Point(382, 528);
		E5B30BA8.Name = "grAddJunkEmail";
		E5B30BA8.Size = new System.Drawing.Size(350, 52);
		E5B30BA8.TabIndex = 204;
		E5B30BA8.TabStop = false;
		E5B30BA8.Text = "Add Junk Email";
		txtJunkEmail.Location = new System.Drawing.Point(131, 22);
		txtJunkEmail.Name = "txtJunkEmail";
		txtJunkEmail.Size = new System.Drawing.Size(211, 23);
		txtJunkEmail.TabIndex = 34;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(8, 25);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(76, 16);
		label6.TabIndex = 201;
		label6.Text = "Nhập email:";
		B097D9A7.Controls.Add(CB826CA9);
		B097D9A7.Controls.Add(E2A9ED0F);
		B097D9A7.Location = new System.Drawing.Point(382, 470);
		B097D9A7.Name = "grForwardMail";
		B097D9A7.Size = new System.Drawing.Size(350, 52);
		B097D9A7.TabIndex = 204;
		B097D9A7.TabStop = false;
		B097D9A7.Text = "Forward Mail";
		CB826CA9.Location = new System.Drawing.Point(131, 22);
		CB826CA9.Name = "txtMailForward";
		CB826CA9.Size = new System.Drawing.Size(211, 23);
		CB826CA9.TabIndex = 34;
		E2A9ED0F.AutoSize = true;
		E2A9ED0F.Location = new System.Drawing.Point(8, 25);
		E2A9ED0F.Name = "label2";
		E2A9ED0F.Size = new System.Drawing.Size(76, 16);
		E2A9ED0F.TabIndex = 201;
		E2A9ED0F.Text = "Nhập email:";
		grUnlockHotmail.Controls.Add(ckbThemMailKhoiPhuc);
		grUnlockHotmail.Controls.Add(cbbTypePhone);
		grUnlockHotmail.Controls.Add(txtApiPhone);
		grUnlockHotmail.Controls.Add(btnNhapSdt);
		grUnlockHotmail.Controls.Add(nudCountGetPhone);
		grUnlockHotmail.Controls.Add(E288AC1A);
		grUnlockHotmail.Controls.Add(nudTimeoutGetOtpPhone);
		grUnlockHotmail.Controls.Add(label4);
		grUnlockHotmail.Location = new System.Drawing.Point(30, 470);
		grUnlockHotmail.Name = "grUnlockHotmail";
		grUnlockHotmail.Size = new System.Drawing.Size(346, 131);
		grUnlockHotmail.TabIndex = 204;
		grUnlockHotmail.TabStop = false;
		grUnlockHotmail.Text = "Unlock hotmail";
		ckbThemMailKhoiPhuc.AutoSize = true;
		ckbThemMailKhoiPhuc.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThemMailKhoiPhuc.Location = new System.Drawing.Point(6, 108);
		ckbThemMailKhoiPhuc.Name = "ckbThemMailKhoiPhuc";
		ckbThemMailKhoiPhuc.Size = new System.Drawing.Size(145, 20);
		ckbThemMailKhoiPhuc.TabIndex = 202;
		ckbThemMailKhoiPhuc.Text = "Thêm mail khôi phục";
		ckbThemMailKhoiPhuc.UseVisualStyleBackColor = true;
		cbbTypePhone.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypePhone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypePhone.DropDownWidth = 200;
		cbbTypePhone.FormattingEnabled = true;
		cbbTypePhone.Location = new System.Drawing.Point(6, 22);
		cbbTypePhone.Name = "cbbTypePhone";
		cbbTypePhone.Size = new System.Drawing.Size(135, 24);
		cbbTypePhone.TabIndex = 193;
		cbbTypePhone.SelectedIndexChanged += new System.EventHandler(cbbTypePhone_SelectedIndexChanged);
		txtApiPhone.Location = new System.Drawing.Point(147, 23);
		txtApiPhone.Name = "txtApiPhone";
		txtApiPhone.Size = new System.Drawing.Size(195, 23);
		txtApiPhone.TabIndex = 34;
		txtApiPhone.Click += new System.EventHandler(B331B092);
		btnNhapSdt.Cursor = System.Windows.Forms.Cursors.Hand;
		btnNhapSdt.Location = new System.Drawing.Point(209, 51);
		btnNhapSdt.Name = "btnNhapSdt";
		btnNhapSdt.Size = new System.Drawing.Size(133, 25);
		btnNhapSdt.TabIndex = 205;
		btnNhapSdt.Text = "Nhập số điện thoại";
		btnNhapSdt.UseVisualStyleBackColor = true;
		btnNhapSdt.Click += new System.EventHandler(BD16163B);
		nudCountGetPhone.Location = new System.Drawing.Point(147, 52);
		nudCountGetPhone.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountGetPhone.Name = "nudCountGetPhone";
		nudCountGetPhone.Size = new System.Drawing.Size(56, 23);
		nudCountGetPhone.TabIndex = 38;
		E288AC1A.AutoSize = true;
		E288AC1A.Location = new System.Drawing.Point(3, 54);
		E288AC1A.Name = "label5";
		E288AC1A.Size = new System.Drawing.Size(137, 16);
		E288AC1A.TabIndex = 201;
		E288AC1A.Text = "Giới hạn số lần lấy sđt:";
		nudTimeoutGetOtpPhone.Location = new System.Drawing.Point(147, 81);
		nudTimeoutGetOtpPhone.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeoutGetOtpPhone.Name = "nudTimeoutGetOtpPhone";
		nudTimeoutGetOtpPhone.Size = new System.Drawing.Size(56, 23);
		nudTimeoutGetOtpPhone.TabIndex = 38;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(3, 83);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(123, 16);
		label4.TabIndex = 201;
		label4.Text = "Timeout get otp (s):";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(382, 305);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		FD9F1D3C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		FD9F1D3C.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		FD9F1D3C.Cursor = System.Windows.Forms.Cursors.Hand;
		FD9F1D3C.FlatAppearance.BorderSize = 0;
		FD9F1D3C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		FD9F1D3C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FD9F1D3C.ForeColor = System.Drawing.Color.White;
		FD9F1D3C.Location = new System.Drawing.Point(284, 305);
		FD9F1D3C.Name = "btnAdd";
		FD9F1D3C.Size = new System.Drawing.Size(92, 29);
		FD9F1D3C.TabIndex = 9;
		FD9F1D3C.Text = "Lưu";
		FD9F1D3C.UseVisualStyleBackColor = false;
		FD9F1D3C.Click += new System.EventHandler(FD9F1D3C_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(764, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(767, 349);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fCauHinhHotmail";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(D9358906);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		grThemMailKhoiPhuc.ResumeLayout(false);
		grThemMailKhoiPhuc.PerformLayout();
		AB3670A1.ResumeLayout(false);
		AB3670A1.PerformLayout();
		plThemKyTuGetnada.ResumeLayout(false);
		plThemKyTuGetnada.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTimeoutGetOtpGetnada).EndInit();
		ADB26B9A.ResumeLayout(false);
		ADB26B9A.PerformLayout();
		A2B039A3.ResumeLayout(false);
		A2B039A3.PerformLayout();
		E5B30BA8.ResumeLayout(false);
		E5B30BA8.PerformLayout();
		B097D9A7.ResumeLayout(false);
		B097D9A7.PerformLayout();
		grUnlockHotmail.ResumeLayout(false);
		grUnlockHotmail.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountGetPhone).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeoutGetOtpPhone).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
