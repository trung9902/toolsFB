using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhChung : Form
{
	internal string EB146694 = "";

	internal string B831A598 = "";

	internal GClass4 gclass4_0 = new GClass4();

	internal List<CheckBox> list_0 = null;

	internal string string_0 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuCards F312A539;

	internal Label label3;

	internal NumericUpDown F0B340B0;

	internal Label C4285B36;

	internal Label label5;

	internal NumericUpDown D18BDD07;

	internal Label label6;

	internal Label B0069BAF;

	internal TextBox txbPathProfile;

	internal Panel F90EBB3D;

	internal GroupBox D1AA09A1;

	internal CheckBox ckbShowImageInteract;

	internal ComboBox cbbHostpot;

	internal Panel plNordVPN;

	internal Label B6AABC28;

	internal TextBox E301229B;

	internal Button E72E4C82;

	internal RadioButton rbSSH;

	internal RadioButton rbExpressVPN;

	internal RadioButton rbNordVPN;

	internal RadioButton rbHotspot;

	internal BunifuDragControl DCB0E58D;

	internal Button F5BBF938;

	internal Button FB88FF8C;

	internal BunifuCards A6A9722C;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel FE379922;

	internal Button button2;

	internal ComboBox cbbRowChrome;

	internal ComboBox cbbColumnChrome;

	internal Label label10;

	internal Label label11;

	internal Panel BD1A8989;

	internal Label label12;

	internal TextBox F130372E;

	internal RadioButton radioButton5;

	internal RadioButton radioButton4;

	internal RadioButton radioButton3;

	internal RadioButton A81ECE2B;

	internal GroupBox grCauHinhChrome;

	internal TextBox txtLinkToOtherBrowser;

	internal Label label19;

	internal NumericUpDown nudDelayOpenChromeTo;

	internal Label AEAB8830;

	internal GroupBox grCauHinhKhac;

	internal Label D804F51B;

	internal NumericUpDown nudDelayOpenChromeFrom;

	internal Label label29;

	internal NumericUpDown nudDelayCloseChromeFrom;

	internal NumericUpDown nudDelayCloseChromeTo;

	internal Panel plSizeChrome;

	internal Label lblTocDoGoVanBan;

	internal NumericUpDown nudHeighChrome;

	internal NumericUpDown BA8586B0;

	internal CheckBox ckbAddChromeIntoForm;

	internal CheckBox ckbAddAndroidPhoneView;

	internal Label label35;

	internal Panel A592D8B4;

	internal Panel plSapXepCuaSoChrome;

	internal Panel DB13DAA8;

	internal Label lblFileZip;

	internal CheckBox ckbUsePortable;

	internal TextBox FEA6DA1C;

	internal Panel DBA562BA;

	internal RichTextBox A1013881;

	internal RadioButton CE2E6104;

	internal RadioButton C897B6B7;

	internal Label label40;

	internal Label C2147C1F;

	internal Label label42;

	internal NumericUpDown FA1228A6;

	internal Label label46;

	internal TextBox B4A292BB;

	internal RadioButton rbVitech;

	internal CheckBox EA12298A;

	internal GroupBox B42ED23C;

	internal TabControl tabChangeIP;

	internal TabPage tabDcom;

	internal Panel plDcom;

	internal Button button4;

	internal TextBox txtUrlHilink;

	internal TextBox A6BD02B4;

	internal RadioButton A1B5F810;

	internal Label label36;

	internal RadioButton A2868C92;

	internal TabPage tabXProxy;

	internal Panel plXproxy;

	internal TabPage tabObcProxy;

	internal Panel plObcProxy;

	internal Label label54;

	internal RadioButton rbObcSock5Proxy;

	internal RadioButton EF35891C;

	internal Label label55;

	internal RichTextBox ED07F537;

	internal Label label67;

	internal Label label69;

	internal NumericUpDown DE3AA0A2;

	internal Label label71;

	internal TextBox txtLinkWebObcProxy;

	internal TabPage A7804FB9;

	internal Panel ED385A1A;

	internal TabPage tabMinProxy;

	internal Panel panel5;

	internal RadioButton B08E0132;

	internal RadioButton rbProxyDong;

	internal Button D389003F;

	internal RichTextBox txtApiKeyMinProxy;

	internal Label E016E38C;

	internal Label label50;

	internal NumericUpDown nudLuongPerIPMinProxy;

	internal Label label37;

	internal NumericUpDown nudDelayCheckIP;

	internal Panel AC15EA00;

	internal Button button5;

	internal Label label26;

	internal NumericUpDown nudChangeIpCount;

	internal Label label27;

	internal CheckBox ckbKhongCheckIP;

	internal Label label53;

	internal CheckBox AD04BF88;

	internal RichTextBox DD8F89BC;

	internal RadioButton CEA19B35;

	internal RadioButton rbHttpProxy;

	internal Label DAABC591;

	internal Label A52984BD;

	internal Label label18;

	internal NumericUpDown nudLuongPerIPXProxy;

	internal Label CB12DD94;

	internal TextBox DF104731;

	internal Panel panel3;

	internal Panel plDelayCloseChrome;

	internal Label label2;

	internal CheckBox ckbDelayCloseChrome;

	internal ComboBox cbbTocDoGoVanBan;

	internal Button btnDown;

	internal Button btnUp;

	internal ComboBox cbbTypePhanBietMau;

	internal Button metroButton2;

	internal Button metroButton1;

	internal ComboBox cbbChangeIP;

	internal ComboBox cbbTypeRunXproxy;

	internal ComboBox BAAFBA3D;

	internal ComboBox B92ECB82;

	internal Label label21;

	internal Label EB0A3BA4;

	internal Panel plTypeProxy;

	internal Panel A784892D;

	internal CheckBox ckbUseExtensionProxy;

	internal Panel D08C5593;

	internal Label B51C7E0E;

	internal TextBox F63689B9;

	internal CheckBox ckbDongBoMaxCare;

	internal TabPage tabProxy;

	internal ComboBox cbbProxy;

	internal RichTextBox txtProxy;

	internal Label label39;

	internal Label label33;

	internal Panel BA0EB62D;

	internal Button E298F032;

	internal Button button9;

	internal TextBox txtTokenDonglaomail;

	internal CheckBox ckbHideBrowser;

	internal LinkLabel D63D63A3;

	internal CheckBox ckbBackupDB;

	internal CheckBox ckbGologin;

	internal Panel plGologin;

	internal Label label51;

	internal TextBox txtOrbitaPath;

	internal LinkLabel linkLabel1;

	internal GroupBox grEmailConfigs;

	internal Label label58;

	internal Panel panel4;

	internal CheckBox F6214BB1;

	internal Panel panel6;

	internal Label label59;

	internal Label B622823D;

	internal TextBox txtMysqlServer;

	internal CheckBox ckbMysqlServer;

	internal Panel panel7;

	internal Label CD2F5EB9;

	internal TextBox F3A4F60E;

	internal TabPage tabProxyWeb;

	internal RichTextBox C3AF698D;

	internal Label lblApiKeyProxy;

	internal Label label65;

	internal NumericUpDown nudLuongPerIP;

	internal Panel plGpmLogin;

	internal Button B63267A8;

	internal TextBox F1A8AE28;

	internal Label label66;

	internal CheckBox ckbGpmLogin;

	internal ComboBox E7039F9E;

	internal Label ADA0CFA7;

	internal NumericUpDown nudChromeScale;

	internal Label A1BDE92B;

	internal Panel plGemLogin;

	internal Button BE2283BF;

	internal TextBox txtGemApiUrl;

	internal Label label62;

	internal CheckBox ckbGemLogin;

	internal Label label38;

	internal ComboBox cbbProxyType;

	internal Label label45;

	internal GroupBox CDBC4A2C;

	internal TextBox txtCaptcha_4;

	internal Button button1;

	internal Label label1;

	internal CheckBox EB3600AF;

	internal LinkLabel A6264B1A;

	internal LinkLabel linkLabel3;

	internal LinkLabel A68F1C80;

	public fCauHinhChung()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	public fCauHinhChung(ref GClass4 gclass4_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		gclass4_0 = gclass4_1;
	}

	private void F5BBF938_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D11BC311(object sender, EventArgs e)
	{
		list_0 = new List<CheckBox> { ckbGologin, ckbGpmLogin, ckbGemLogin };
		EF058097();
		AEA314AB();
		method_3();
		A404B092();
		method_4();
		method_5();
		method_1();
		method_2();
		F0B340B0.Value = C5034B95.smethod_0("configGeneral").method_2("nudInteractThread", 3);
		D18BDD07.Value = C5034B95.smethod_0("configGeneral").method_2("nudHideThread", 5);
		txbPathProfile.Text = C5034B95.smethod_2();
		if (!Directory.Exists(txbPathProfile.Text) || txbPathProfile.Text.Trim() == "profiles")
		{
			txbPathProfile.Text = Commom.smethod_95() + "\\profiles";
		}
		C5034B95.smethod_0("configGeneral").method_4("txbPathProfile", txbPathProfile.Text);
		ckbShowImageInteract.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbShowImageInteract");
		ckbUseExtensionProxy.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbUseExtensionProxy");
		ckbDongBoMaxCare.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbDongBoMaxCare");
		F63689B9.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtPathMaxCare");
		EB146694 = (ckbDongBoMaxCare.Checked ? F63689B9.Text : "");
		ckbHideBrowser.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbHideBrowser");
		ckbAddChromeIntoForm.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbAddChromeIntoForm");
		ckbAddAndroidPhoneView.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView");
		BA8586B0.Value = C5034B95.smethod_0("configGeneral").method_2("nudWidthChrome", 320);
		nudHeighChrome.Value = C5034B95.smethod_0("configGeneral").method_2("nudHeighChrome", 480);
		nudDelayOpenChromeFrom.Value = C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeFrom", 1);
		nudDelayOpenChromeTo.Value = C5034B95.smethod_0("configGeneral").method_2("nudDelayOpenChromeTo", 1);
		nudDelayCloseChromeFrom.Value = C5034B95.smethod_0("configGeneral").method_2("nudDelayCloseChromeFrom");
		nudDelayCloseChromeTo.Value = C5034B95.smethod_0("configGeneral").method_2("nudDelayCloseChromeTo");
		ckbDelayCloseChrome.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbDelayCloseChrome");
		cbbColumnChrome.Text = ((C5034B95.smethod_0("configGeneral").BDB80B23("cbbColumnChrome") == "") ? "3" : C5034B95.smethod_0("configGeneral").BDB80B23("cbbColumnChrome"));
		cbbRowChrome.Text = ((C5034B95.smethod_0("configGeneral").BDB80B23("cbbRowChrome") == "") ? "2" : C5034B95.smethod_0("configGeneral").BDB80B23("cbbRowChrome"));
		txtLinkToOtherBrowser.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtLinkToOtherBrowser");
		ckbUsePortable.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbUsePortable");
		FEA6DA1C.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtPathToPortableZip");
		nudChromeScale.Value = C5034B95.smethod_0("configGeneral").method_2("nudChromeScale", 100);
		cbbTocDoGoVanBan.SelectedIndex = C5034B95.smethod_0("configGeneral").method_2("tocDoGoVanBan");
		ckbGologin.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbGologin");
		txtOrbitaPath.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtOrbitaPath");
		ckbGpmLogin.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin");
		F1A8AE28.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtGpmApiUrl");
		E7039F9E.Text = C5034B95.smethod_0("configGeneral").BDB80B23("cbbBrowserVersion", "132.0.6834.84");
		ckbGemLogin.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin");
		txtGemApiUrl.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtGemApiUrl");
		ckbKhongCheckIP.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbKhongCheckIP");
		nudChangeIpCount.Value = C5034B95.smethod_0("configGeneral").method_2("ip_nudChangeIpCount", 1);
		nudDelayCheckIP.Value = C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP");
		cbbChangeIP.SelectedValue = C5034B95.smethod_0("configGeneral").BDB80B23("ip_iTypeChangeIp");
		if (C5034B95.smethod_0("configGeneral").method_2("typeDcom") == 0)
		{
			A2868C92.Checked = true;
		}
		else
		{
			A1B5F810.Checked = true;
		}
		A6BD02B4.Text = C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtProfileNameDcom");
		txtUrlHilink.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtUrlHilink", "http://192.168.1.1/html/home.html");
		E301229B.Text = C5034B95.smethod_0("configGeneral").BDB80B23("ip_txtNordVPN");
		cbbHostpot.SelectedIndex = C5034B95.smethod_0("configGeneral").method_2("ip_cbbHostpot");
		DF104731.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtServiceURLXProxy");
		if (C5034B95.smethod_0("configGeneral").method_2("typeProxy") == 0)
		{
			rbHttpProxy.Checked = true;
		}
		else
		{
			CEA19B35.Checked = true;
		}
		DD8F89BC.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtListProxy");
		nudLuongPerIPXProxy.Value = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPXProxy");
		AD04BF88.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbWaitDoneAllXproxy");
		cbbTypeRunXproxy.SelectedIndex = C5034B95.smethod_0("configGeneral").method_2("typeRunXproxy");
		cbbProxy.SelectedValue = C5034B95.smethod_0("configGeneral").BDB80B23("cbbProxy", "0");
		txtProxy.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtProxy");
		cbbProxyType.SelectedValue = C5034B95.smethod_0("configGeneral").BDB80B23("cbbProxyType", "0");
		if (C5034B95.smethod_0("configGeneral").method_2("typeMin") == 0)
		{
			rbProxyDong.Checked = true;
		}
		else
		{
			B08E0132.Checked = true;
		}
		B92ECB82.SelectedIndex = C5034B95.smethod_0("configGeneral").method_2("typeProxyMin");
		txtApiKeyMinProxy.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtApiKeyMinProxy");
		nudLuongPerIPMinProxy.Value = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPMinProxy");
		txtLinkWebObcProxy.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtLinkWebObcProxy");
		ED07F537.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtListObcProxy");
		DE3AA0A2.Value = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPObcProxy", 1);
		BAAFBA3D.SelectedIndex = C5034B95.smethod_0("configGeneral").method_2("typeRunObcProxy");
		method_0();
		F6214BB1.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetOtpHotmailChrome");
		ckbBackupDB.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbBackupDB", C9B3010F: true);
		string_0 = C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtBackupDBPath");
		Commom.CreateFolder(string_0);
		if (!Directory.Exists(string_0))
		{
			string_0 = Environment.GetEnvironmentVariable("LocalAppData") + "\\database";
			Commom.CreateFolder(string_0);
		}
		cbbTypePhanBietMau.SelectedIndex = C5034B95.smethod_0("configGeneral").method_2("typePhanBietMau");
		EA12298A.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbLuuTrangThai");
		F3A4F60E.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtTokenUnlimitMail");
		txtTokenDonglaomail.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtTokenDonglaomail");
		ckbMysqlServer.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbMysqlServer");
		txtMysqlServer.Text = C5034B95.smethod_0("configGeneral").BDB80B23("txtMysqlServer");
		B831A598 = (ckbMysqlServer.Checked ? txtMysqlServer.Text : "");
		txtCaptcha_4.Text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4");
		EB3600AF.Checked = C5034B95.smethod_0("configGeneral").method_3("ckbExtensionOmoCaptcha");
		D51F920A();
	}

	private void method_0()
	{
		int num = 0;
		try
		{
			num = Convert.ToInt32(cbbChangeIP.SelectedValue);
		}
		catch (Exception)
		{
		}
		if (num == 0 || num == 1 || num == 2 || num == 8 || num == 9 || num == 13 || num == 14)
		{
			return;
		}
		List<string> values = C5034B95.smethod_0("configGeneral").method_1("txtApiKey_" + num);
		int num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIP_" + num, -1);
		if (num2 == -1)
		{
			switch (num)
			{
			case 7:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPTinsoft", 1);
				break;
			case 10:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyTMProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPTMProxy", 1);
				break;
			case 11:
				values = C5034B95.smethod_0("configGeneral").method_1("txtListProxyv6");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPProxyv6", 1);
				break;
			case 12:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiShopLike");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPShopLike", 1);
				break;
			default:
				num2 = 1;
				break;
			case 15:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyProxyFb");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPProxyFb", 1);
				break;
			case 16:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyWWProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPWWProxy", 1);
				break;
			case 17:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyKiotProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPKiotProxy", 1);
				break;
			case 18:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyFProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPFProxy", 1);
				break;
			case 19:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyNetProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPNetProxy", 1);
				break;
			case 20:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyRaiProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPRaiProxy", 1);
				break;
			case 21:
				values = C5034B95.smethod_0("configGeneral").method_1("txtApiKeyNortonProxy");
				num2 = C5034B95.smethod_0("configGeneral").method_2("nudLuongPerIPNortonProxy", 1);
				break;
			}
		}
		C3AF698D.Text = string.Join("\n", values);
		nudLuongPerIP.Value = num2;
	}

	private void EF058097()
	{
		List<string> list = new List<string> { "Chậm", "Bình thường", "Nhanh" };
		Commom.smethod_23(cbbTocDoGoVanBan, list);
	}

	private void method_1()
	{
		List<string> list = new List<string> { "Đổi màu nền dòng", "Đổi màu chữ" };
		Commom.smethod_23(cbbTypePhanBietMau, list);
	}

	private void AEA314AB()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Không đổi IP");
		dictionary.Add("2", "Dcom");
		dictionary.Add("1", "HMA");
		dictionary.Add("9", "Proxy");
		dictionary.Add("13", "https://minproxy.vn/");
		dictionary.Add("26", "https://vnproxy.com/");
		dictionary.Add("24", "https://proxy.vn/");
		dictionary.Add("25", "https://topproxy.vn/");
		dictionary.Add("19", "https://netproxy.io/");
		dictionary.Add("20", "https://raiproxy.com/");
		dictionary.Add("22", "https://fproxy.vn/");
		dictionary.Add("21", "https://nortonproxy.com/");
		dictionary.Add("17", "https://kiotproxy.com/");
		dictionary.Add("18", "https://fproxy.me/");
		dictionary.Add("16", "https://wwproxy.com/");
		dictionary.Add("15", "https://proxyfb.com/");
		dictionary.Add("7", "https://tinsoftproxy.com/");
		dictionary.Add("12", "http://proxy.shoplike.vn/");
		dictionary.Add("11", "https://proxyv6.net/");
		dictionary.Add("10", "https://tmproxy.com/");
		dictionary.Add("8", "Xproxy, Mobi, Eager, S Proxy, OBC, Proxy Machine");
		dictionary.Add("14", "OBC Proxy");
		Commom.smethod_24(cbbChangeIP, dictionary);
		cbbChangeIP.SelectedIndexChanged += E70153A8;
	}

	private void method_2()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("132.0.6834.84", "132.0.6834.84");
		dictionary.Add("129.0.6533.73", "129.0.6533.73");
		dictionary.Add("127.0.6533.73", "127.0.6533.73");
		dictionary.Add("124.0.6367.29", "124.0.6367.29");
		dictionary.Add("121.0.6167.140", "121.0.6167.140");
		dictionary.Add("119.0.6045.124", "119.0.6045.124");
		Commom.smethod_24(E7039F9E, dictionary);
	}

	private void method_3()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Đã gán vào mỗi tài khoản");
		dictionary.Add("1", "Ngẫu nhiên trong danh sách");
		Commom.smethod_24(cbbProxy, dictionary);
	}

	private void A404B092()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Reset từng proxy");
		dictionary.Add("1", "Reset tất cả proxy");
		Commom.smethod_24(cbbTypeRunXproxy, dictionary);
	}

	private void method_4()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Http");
		dictionary.Add("1", "Sock5");
		Commom.smethod_24(cbbProxyType, dictionary);
	}

	private void C80031A9(object sender, EventArgs e)
	{
		try
		{
			C5034B95.smethod_0("configGeneral").method_4("nudInteractThread", F0B340B0.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudHideThread", D18BDD07.Value);
			C5034B95.smethod_0("configGeneral").method_4("txbPathProfile", txbPathProfile.Text);
			C5034B95.smethod_0("configGeneral").method_4("ckbShowImageInteract", ckbShowImageInteract.Checked);
			C5034B95.smethod_0("configGeneral").method_4("ckbUseExtensionProxy", ckbUseExtensionProxy.Checked);
			C5034B95.smethod_0("configGeneral").method_4("ckbDongBoMaxCare", ckbDongBoMaxCare.Checked);
			string text = F63689B9.Text.Trim();
			if (ckbDongBoMaxCare.Checked && !File.Exists(text + "\\database\\db_maxcare.sqlite"))
			{
				MsBoxHelper.Show("Đươ\u0300ng dâ\u0303n không hơ\u0323p lê\u0323!", 3);
				return;
			}
			C5034B95.smethod_0("configGeneral").method_4("txtPathMaxCare", text);
			if (!ckbDongBoMaxCare.Checked)
			{
				text = "";
			}
			C5034B95.smethod_0("configGeneral").method_4("ckbHideBrowser", ckbHideBrowser.Checked);
			C5034B95.smethod_0("configGeneral").method_4("ckbAddChromeIntoForm", ckbAddChromeIntoForm.Checked);
			C5034B95.smethod_0("configGeneral").method_4("ckbAddAndroidPhoneView", ckbAddAndroidPhoneView.Checked);
			C5034B95.smethod_0("configGeneral").method_4("nudWidthChrome", BA8586B0.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudHeighChrome", nudHeighChrome.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudDelayOpenChromeFrom", nudDelayOpenChromeFrom.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudDelayOpenChromeTo", nudDelayOpenChromeTo.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudDelayCloseChromeFrom", nudDelayCloseChromeFrom.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudDelayCloseChromeTo", nudDelayCloseChromeTo.Value);
			C5034B95.smethod_0("configGeneral").method_4("ckbDelayCloseChrome", ckbDelayCloseChrome.Checked);
			C5034B95.smethod_0("configGeneral").method_4("cbbColumnChrome", cbbColumnChrome.Text);
			C5034B95.smethod_0("configGeneral").method_4("cbbRowChrome", cbbRowChrome.Text);
			C5034B95.smethod_0("configGeneral").method_4("txtLinkToOtherBrowser", txtLinkToOtherBrowser.Text.Trim());
			C5034B95.smethod_0("configGeneral").method_4("ckbUsePortable", ckbUsePortable.Checked);
			C5034B95.smethod_0("configGeneral").method_4("txtPathToPortableZip", FEA6DA1C.Text.Trim());
			C5034B95.smethod_0("configGeneral").method_4("nudChromeScale", nudChromeScale.Value);
			C5034B95.smethod_0("configGeneral").method_4("tocDoGoVanBan", cbbTocDoGoVanBan.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("ckbGologin", ckbGologin.Checked);
			C5034B95.smethod_0("configGeneral").method_4("txtOrbitaPath", txtOrbitaPath.Text.Trim());
			C5034B95.smethod_0("configGeneral").method_4("ckbGpmLogin", ckbGpmLogin.Checked);
			C5034B95.smethod_0("configGeneral").method_4("txtGpmApiUrl", F1A8AE28.Text.Trim());
			C5034B95.smethod_0("configGeneral").method_4("cbbBrowserVersion", E7039F9E.Text);
			C5034B95.smethod_0("configGeneral").method_4("ckbGemLogin", ckbGemLogin.Checked);
			C5034B95.smethod_0("configGeneral").method_4("txtGemApiUrl", txtGemApiUrl.Text.Trim());
			C5034B95.smethod_0("configGeneral").method_4("ckbKhongCheckIP", ckbKhongCheckIP.Checked);
			C5034B95.smethod_0("configGeneral").method_4("ip_nudChangeIpCount", nudChangeIpCount.Value);
			C5034B95.smethod_0("configGeneral").method_4("nudDelayCheckIP", nudDelayCheckIP.Value);
			C5034B95.smethod_0("configGeneral").method_4("ip_iTypeChangeIp", cbbChangeIP.SelectedValue);
			if (A2868C92.Checked)
			{
				C5034B95.smethod_0("configGeneral").method_4("typeDcom", 0);
			}
			else
			{
				C5034B95.smethod_0("configGeneral").method_4("typeDcom", 1);
			}
			C5034B95.smethod_0("configGeneral").method_4("txtUrlHilink", txtUrlHilink.Text);
			C5034B95.smethod_0("configGeneral").method_4("ip_txtProfileNameDcom", A6BD02B4.Text);
			C5034B95.smethod_0("configGeneral").method_4("ip_txtNordVPN", E301229B.Text);
			C5034B95.smethod_0("configGeneral").method_4("ip_cbbHostpot", cbbHostpot.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("txtServiceURLXProxy", DF104731.Text);
			int num = 0;
			if (CEA19B35.Checked)
			{
				num = 1;
			}
			C5034B95.smethod_0("configGeneral").method_4("typeProxy", num);
			C5034B95.smethod_0("configGeneral").method_4("txtListProxy", DD8F89BC.Text);
			C5034B95.smethod_0("configGeneral").method_4("nudLuongPerIPXProxy", nudLuongPerIPXProxy.Value);
			C5034B95.smethod_0("configGeneral").method_4("ckbWaitDoneAllXproxy", AD04BF88.Checked);
			C5034B95.smethod_0("configGeneral").method_4("typeRunXproxy", cbbTypeRunXproxy.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("cbbProxy", cbbProxy.SelectedValue);
			C5034B95.smethod_0("configGeneral").method_4("txtProxy", txtProxy.Text);
			C5034B95.smethod_0("configGeneral").method_4("cbbProxyType", cbbProxyType.SelectedValue);
			int num2 = 0;
			if (B08E0132.Checked)
			{
				num2 = 1;
			}
			C5034B95.smethod_0("configGeneral").method_4("typeMin", cbbTypeRunXproxy.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("typeMin", num2);
			C5034B95.smethod_0("configGeneral").method_4("typeProxyMin", B92ECB82.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("txtApiKeyMinProxy", txtApiKeyMinProxy.Text);
			C5034B95.smethod_0("configGeneral").method_4("nudLuongPerIPMinProxy", nudLuongPerIPMinProxy.Value);
			C5034B95.smethod_0("configGeneral").method_4("txtLinkWebObcProxy", txtLinkWebObcProxy.Text);
			C5034B95.smethod_0("configGeneral").method_4("txtListObcProxy", ED07F537.Text);
			C5034B95.smethod_0("configGeneral").method_4("nudLuongPerIPObcProxy", DE3AA0A2.Value);
			C5034B95.smethod_0("configGeneral").method_4("typeRunObcProxy", BAAFBA3D.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("txtApiKey_" + cbbChangeIP.SelectedValue, C3AF698D.Text);
			C5034B95.smethod_0("configGeneral").method_4("nudLuongPerIP_" + cbbChangeIP.SelectedValue, nudLuongPerIP.Value);
			C5034B95.smethod_0("configInteractGeneral").method_4("ckbGetOtpHotmailChrome", F6214BB1.Checked);
			C5034B95.smethod_0("configInteractGeneral").method_4("ckbBackupDB", ckbBackupDB.Checked);
			C5034B95.smethod_0("configInteractGeneral").method_4("txtBackupDBPath", string_0);
			C5034B95.smethod_0("configInteractGeneral").AEBFED04();
			C5034B95.smethod_0("configGeneral").method_4("typePhanBietMau", cbbTypePhanBietMau.SelectedIndex);
			C5034B95.smethod_0("configGeneral").method_4("ckbLuuTrangThai", EA12298A.Checked);
			Class87.bool_0 = EA12298A.Checked;
			C5034B95.smethod_0("configGeneral").method_4("txtTokenUnlimitMail", F3A4F60E.Text);
			C5034B95.smethod_0("configGeneral").method_4("txtTokenDonglaomail", txtTokenDonglaomail.Text);
			C5034B95.smethod_0("configGeneral").method_4("ckbMysqlServer", ckbMysqlServer.Checked);
			string text2 = txtMysqlServer.Text.Trim();
			if (ckbMysqlServer.Checked && txtMysqlServer.Text.Trim() == "")
			{
				MsBoxHelper.Show("Vui lòng nhập MysqlServer!", 3);
				return;
			}
			C5034B95.smethod_0("configGeneral").method_4("txtMysqlServer", text2);
			if (!ckbMysqlServer.Checked)
			{
				text2 = "";
			}
			C5034B95.smethod_0("configGeneral").method_4("ckbExtensionOmoCaptcha", EB3600AF.Checked);
			C5034B95.smethod_1("configGeneral");
			C5034B95.smethod_0("configCheckpoint").method_4("txtCaptcha_4", txtCaptcha_4.Text);
			C5034B95.smethod_1("configCheckpoint");
			if (MsBoxHelper.D41C45AC("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
			{
				Close();
			}
			if (EB146694 != text || B831A598 != text2)
			{
				Base.DE249839 = Base.DA889BA1();
				gclass4_0.method_4("isChangePathDatabase", true);
			}
		}
		catch
		{
			MsBoxHelper.Show("Lỗi!");
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		if (Convert.ToInt32(cbbChangeIP.SelectedValue) == 0)
		{
			MsBoxHelper.Show("Vui lòng chọn loại đổi IP", 3);
			return;
		}
		int int_ = 0;
		if (A1B5F810.Checked)
		{
			int_ = 1;
		}
		if (Commom.smethod_59(Convert.ToInt32(cbbChangeIP.SelectedValue), int_, A6BD02B4.Text.Trim(), txtUrlHilink.Text.Trim(), cbbHostpot.SelectedIndex, E301229B.Text.Trim()))
		{
			MsBoxHelper.Show("Đổi IP thành công!");
		}
		else
		{
			MsBoxHelper.Show("Đổi IP thất bại!", 2);
		}
	}

	private void E5AC459D(object sender, EventArgs e)
	{
		Process.Start("changeip\\ssh.txt");
	}

	private void radioButton3_CheckedChanged(object sender, EventArgs e)
	{
		BD1A8989.Enabled = rbNordVPN.Checked;
	}

	private void D51F920A()
	{
		ckbAddChromeIntoForm_CheckedChanged(null, null);
		ckbAddAndroidPhoneView_CheckedChanged(null, null);
		ckbUsePortable_CheckedChanged(null, null);
		A1B5F810_CheckedChanged(null, null);
		B4B8DE1E(null, null);
		BF067980(null, null);
		A1010A35(null, null);
		B08E0132_CheckedChanged(null, null);
		ckbBackupDB_CheckedChanged(null, null);
		ckbGologin_CheckedChanged(null, null);
		FAAE981E(null, null);
		DD8F89BC_TextChanged(null, null);
		C22BEBAD(null, null);
		A52DC38E(null, null);
		method_6(null, null);
		txtProxy_TextChanged(null, null);
		C3AF698D_TextChanged(null, null);
		ckbGpmLogin_CheckedChanged(null, null);
		ckbGemLogin_CheckedChanged(null, null);
	}

	private void button4_Click(object sender, EventArgs e)
	{
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
			{
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			};
			Process process = Process.Start(startInfo);
			string text = process.StandardOutput.ReadToEnd();
			if (text.Split('\n').Length <= 3)
			{
				MsBoxHelper.Show("Vui lòng kết nối Dcom trước!", 2);
				return;
			}
			A6BD02B4.Text = text.Split('\n').ToList()[1];
			MsBoxHelper.Show("Lấy tên cấu hình Dcom thành công!");
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "change ip dcom");
			MsBoxHelper.Show("Có lỗi xảy ra, vui lòng thử lại sau!", 2);
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if (((e as MouseEventArgs).Button != MouseButtons.Right || Control.ModifierKeys != Keys.Control) && (e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Alt)
		{
			plSizeChrome.Visible = false;
		}
	}

	private void plXproxy_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
		{
			AD04BF88.Visible = true;
		}
	}

	private void B137DB2A(object sender, EventArgs e)
	{
	}

	private void method_5()
	{
	}

	private void DD8F89BC_TextChanged(object sender, EventArgs e)
	{
		try
		{
			List<string> list = DD8F89BC.Lines.ToList();
			list = Commom.smethod_36(list);
			A52984BD.Text = string.Format(Language.GetValue("Nhập Proxy ({0}):"), list.Count.ToString());
		}
		catch
		{
		}
	}

	private void FEA6DA1C_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			Process.Start(txbPathProfile.Text.Trim());
		}
	}

	private void ckbAddChromeIntoForm_CheckedChanged(object sender, EventArgs e)
	{
		if (ckbAddChromeIntoForm.Checked && ckbAddAndroidPhoneView != null && ckbAddAndroidPhoneView.Checked)
		{
			ckbAddAndroidPhoneView.Checked = false;
		}
		bool flag = ckbAddChromeIntoForm.Checked || (ckbAddAndroidPhoneView != null && ckbAddAndroidPhoneView.Checked);
		A592D8B4.Enabled = flag;
		plSapXepCuaSoChrome.Enabled = !flag;
	}

	private void ckbAddAndroidPhoneView_CheckedChanged(object sender, EventArgs e)
	{
		if (ckbAddAndroidPhoneView.Checked && ckbAddChromeIntoForm != null && ckbAddChromeIntoForm.Checked)
		{
			ckbAddChromeIntoForm.Checked = false;
		}
		bool flag = (ckbAddChromeIntoForm != null && ckbAddChromeIntoForm.Checked) || ckbAddAndroidPhoneView.Checked;
		A592D8B4.Enabled = flag;
		plSapXepCuaSoChrome.Enabled = !flag;
	}

	private void DB13DAA8_Paint(object sender, PaintEventArgs e)
	{
	}

	private void ckbUsePortable_CheckedChanged(object sender, EventArgs e)
	{
		lblFileZip.Enabled = ckbUsePortable.Checked;
		FEA6DA1C.Enabled = ckbUsePortable.Checked;
	}

	private void panel3_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			DB13DAA8.BringToFront();
		}
	}

	private void B4B8DE1E(object sender, EventArgs e)
	{
		button4.Enabled = A2868C92.Checked;
		A6BD02B4.Enabled = A2868C92.Checked;
	}

	private void A1B5F810_CheckedChanged(object sender, EventArgs e)
	{
		label36.Enabled = A1B5F810.Checked;
		txtUrlHilink.Enabled = A1B5F810.Checked;
	}

	private void method_6(object sender, EventArgs e)
	{
	}

	private void E6B97A19(object sender, EventArgs e)
	{
		List<string> list = A1013881.Lines.ToList();
		list = Commom.smethod_36(list);
		C2147C1F.Text = string.Format(Language.GetValue("Nhập Proxy ({0}):"), list.Count.ToString());
	}

	private void F90EBB3D_Paint(object sender, PaintEventArgs e)
	{
	}

	private void F4268DBA(object sender, EventArgs e)
	{
	}

	private void A52DC38E(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtApiKeyMinProxy, E016E38C);
	}

	private void E78406AF(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		List<string> list2 = txtApiKeyMinProxy.Lines.ToList();
		list2 = Commom.smethod_36(list2);
		int int_ = 0;
		if (B08E0132.Checked)
		{
			int_ = 1;
		}
		foreach (string item in list2)
		{
			if (MinProxyVN.smethod_0(int_, item))
			{
				list.Add(item);
			}
		}
		txtApiKeyMinProxy.Lines = list.ToArray();
		if (list.Count > 0)
		{
			MsBoxHelper.Show(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), list.Count));
		}
		else
		{
			MsBoxHelper.Show("Không có proxy khả dụng!", 2);
		}
	}

	private void C22BEBAD(object sender, EventArgs e)
	{
		Commom.A9BCAF05(ED07F537, label67);
	}

	private void B08E0132_CheckedChanged(object sender, EventArgs e)
	{
		plTypeProxy.Enabled = B08E0132.Checked;
	}

	private void BF067980(object sender, EventArgs e)
	{
		plDelayCloseChrome.Enabled = ckbDelayCloseChrome.Checked;
	}

	private void D1BF43B6(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			A1BDE92B.Visible = true;
			nudChromeScale.Visible = true;
		}
		grCauHinhChrome.Height = 280;
		lblTocDoGoVanBan.Visible = true;
		cbbTocDoGoVanBan.Visible = true;
		ckbHideBrowser.Visible = true;
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		grCauHinhChrome.Height = 108;
		lblTocDoGoVanBan.Visible = false;
		cbbTocDoGoVanBan.Visible = false;
		ckbHideBrowser.Visible = false;
	}

	private void metroButton2_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			D1AA09A1.Height = 159;
		}
		else
		{
			D1AA09A1.Height = 111;
		}
	}

	private void BA29DDBC(object sender, EventArgs e)
	{
		D1AA09A1.Height = 53;
	}

	private void method_7(object sender, EventArgs e)
	{
		A784892D.Visible = true;
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			E298F032.Visible = true;
		}
	}

	private void E70153A8(object sender, EventArgs e)
	{
		if (cbbChangeIP.SelectedValue == null)
		{
			return;
		}
		object selectedValue = cbbChangeIP.SelectedValue;
		object obj = selectedValue;
		string text = obj as string;
		if (text != null)
		{
			uint num = AFAE75A0.smethod_0(text);
			if (num <= 873244444)
			{
				if (num != 401286136)
				{
					if (num != 518729469)
					{
						if (num == 873244444 && text == "1")
						{
							goto IL_0116;
						}
					}
					else if (text == "13")
					{
						tabChangeIP.SelectedTab = tabMinProxy;
						goto IL_0194;
					}
				}
				else if (text == "14")
				{
					tabChangeIP.SelectedTab = tabObcProxy;
					goto IL_0194;
				}
			}
			else
			{
				if (num > 923577301)
				{
					if (num != 1007465396)
					{
						if (num != 1024243015 || !(text == "8"))
						{
							goto IL_017d;
						}
						tabChangeIP.SelectedTab = tabXProxy;
					}
					else
					{
						if (!(text == "9"))
						{
							goto IL_017d;
						}
						tabChangeIP.SelectedTab = tabProxy;
					}
					goto IL_0194;
				}
				if (num != 890022063)
				{
					if (num == 923577301 && text == "2")
					{
						tabChangeIP.SelectedTab = tabDcom;
						goto IL_0194;
					}
				}
				else if (text == "0")
				{
					goto IL_0116;
				}
			}
		}
		goto IL_017d;
		IL_0116:
		tabChangeIP.SelectedTab = A7804FB9;
		goto IL_0194;
		IL_017d:
		tabChangeIP.SelectedTab = tabProxyWeb;
		method_0();
		goto IL_0194;
		IL_0194:
		AC15EA00.Visible = cbbChangeIP.SelectedValue.ToString() == "1" || cbbChangeIP.SelectedValue.ToString() == "2";
	}

	private void A1010A35(object sender, EventArgs e)
	{
		D08C5593.Enabled = ckbDongBoMaxCare.Checked;
	}

	private void cbbProxy_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (cbbProxy.SelectedValue != null)
			{
				BA0EB62D.Enabled = cbbProxy.SelectedValue.ToString() == "1";
			}
		}
		catch (Exception)
		{
		}
	}

	private void txtProxy_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtProxy, label33);
	}

	private void E298F032_Click(object sender, EventArgs e)
	{
		Commom.smethod_35(new fCauHinhDomainGenerator());
	}

	private void F3BF3CA3(object sender, EventArgs e)
	{
		if (MsBoxHelper.D41C45AC("Bạn có muốn cập nhật ChromeDriver khớp với phiên bản Google Chrome hiện tại không?") != DialogResult.Yes)
		{
			return;
		}
		try
		{
			var result = ChromeDriverUpdater.UpdateChromeDriver();
			if (result.success)
			{
				MsBoxHelper.Show(result.message);
				return;
			}
			else
			{
				MsBoxHelper.Show(result.message, 2);
				return;
			}
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show("Cập nhật ChromeDriver thất bại: " + ex.Message, 2);
		}
	}

	private void D63D63A3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = Commom.smethod_40(string_0);
		if (text != "")
		{
			string_0 = text;
		}
	}

	private void ckbBackupDB_CheckedChanged(object sender, EventArgs e)
	{
		D63D63A3.Enabled = ckbBackupDB.Checked;
	}

	private void ckbGologin_CheckedChanged(object sender, EventArgs e)
	{
		plGologin.Enabled = ckbGologin.Checked;
		B63131B9(sender as CheckBox);
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_14(Base.string_2 + "/download/gologin.zip");
		if (File.Exists(Commom.smethod_95() + "\\orbita-browser\\chrome.exe"))
		{
			txtOrbitaPath.Text = Commom.smethod_95() + "\\orbita-browser\\chrome.exe";
		}
	}

	private void FAAE981E(object sender, EventArgs e)
	{
		txtMysqlServer.Enabled = ckbMysqlServer.Checked;
		if (ckbMysqlServer.Checked)
		{
			ckbBackupDB.Checked = false;
			ckbBackupDB.Enabled = false;
		}
		else
		{
			ckbBackupDB.Enabled = true;
		}
	}

	private void C3AF698D_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C3AF698D, lblApiKeyProxy);
	}

	private void ckbGpmLogin_CheckedChanged(object sender, EventArgs e)
	{
		plGpmLogin.Enabled = ckbGpmLogin.Checked;
		B63131B9(sender as CheckBox);
	}

	private void B63131B9(CheckBox checkBox_0)
	{
		if (checkBox_0 == null || !checkBox_0.Checked)
		{
			return;
		}
		foreach (CheckBox item in list_0)
		{
			if (item != checkBox_0)
			{
				item.Checked = false;
			}
		}
	}

	private void B63267A8_Click(object sender, EventArgs e)
	{
		bool flag = false;
		try
		{
			string text = F1A8AE28.Text.Trim();
			string text2 = new RequestXNet().E58EB99F(text.TrimEnd('/') + "/api/v3/profiles");
			if (text2 != "")
			{
				flag = true;
			}
		}
		catch (Exception)
		{
		}
		MsBoxHelper.Show("Connect " + (flag ? "Success" : "Fail") + "!", flag ? 1 : 2);
	}

	private void BE2283BF_Click(object sender, EventArgs e)
	{
		bool flag = false;
		try
		{
			string text = txtGemApiUrl.Text.Trim();
			string text2 = new RequestXNet().E58EB99F(text.TrimEnd('/') + "/api/profiles");
			if (text2 != "")
			{
				flag = true;
			}
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show(ex.ToString());
		}
		MsBoxHelper.Show("Connect " + (flag ? "Success" : "Fail") + "!", flag ? 1 : 2);
	}

	private void ckbGemLogin_CheckedChanged(object sender, EventArgs e)
	{
		plGemLogin.Enabled = ckbGemLogin.Checked;
		B63131B9(sender as CheckBox);
	}

	private void FABC2DA7(object sender, EventArgs e)
	{
		string object_ = Commom.smethod_0("https://omocaptcha.com/", txtCaptcha_4.Text.Trim());
		MsBoxHelper.Show(object_);
	}

	private void A68F1C80_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.CE2E5B3B((sender as LinkLabel).Text);
	}

	protected override void Dispose(bool FBB4E3A8)
	{
		if (FBB4E3A8 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(FBB4E3A8);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhChung));
		F312A539 = new Bunifu.Framework.UI.BunifuCards();
		label3 = new System.Windows.Forms.Label();
		F0B340B0 = new System.Windows.Forms.NumericUpDown();
		C4285B36 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		D18BDD07 = new System.Windows.Forms.NumericUpDown();
		label6 = new System.Windows.Forms.Label();
		B0069BAF = new System.Windows.Forms.Label();
		txbPathProfile = new System.Windows.Forms.TextBox();
		F90EBB3D = new System.Windows.Forms.Panel();
		D1AA09A1 = new System.Windows.Forms.GroupBox();
		D08C5593 = new System.Windows.Forms.Panel();
		B51C7E0E = new System.Windows.Forms.Label();
		F63689B9 = new System.Windows.Forms.TextBox();
		ckbDongBoMaxCare = new System.Windows.Forms.CheckBox();
		metroButton2 = new System.Windows.Forms.Button();
		metroButton1 = new System.Windows.Forms.Button();
		grCauHinhChrome = new System.Windows.Forms.GroupBox();
		nudDelayOpenChromeTo = new System.Windows.Forms.NumericUpDown();
		plGemLogin = new System.Windows.Forms.Panel();
		BE2283BF = new System.Windows.Forms.Button();
		txtGemApiUrl = new System.Windows.Forms.TextBox();
		label62 = new System.Windows.Forms.Label();
		nudDelayOpenChromeFrom = new System.Windows.Forms.NumericUpDown();
		AEAB8830 = new System.Windows.Forms.Label();
		ckbGemLogin = new System.Windows.Forms.CheckBox();
		plGpmLogin = new System.Windows.Forms.Panel();
		B63267A8 = new System.Windows.Forms.Button();
		F1A8AE28 = new System.Windows.Forms.TextBox();
		label66 = new System.Windows.Forms.Label();
		E7039F9E = new System.Windows.Forms.ComboBox();
		ADA0CFA7 = new System.Windows.Forms.Label();
		plSizeChrome = new System.Windows.Forms.Panel();
		plDelayCloseChrome = new System.Windows.Forms.Panel();
		nudDelayCloseChromeTo = new System.Windows.Forms.NumericUpDown();
		nudDelayCloseChromeFrom = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		ckbDelayCloseChrome = new System.Windows.Forms.CheckBox();
		label29 = new System.Windows.Forms.Label();
		ckbGpmLogin = new System.Windows.Forms.CheckBox();
		plGologin = new System.Windows.Forms.Panel();
		txtOrbitaPath = new System.Windows.Forms.TextBox();
		linkLabel1 = new System.Windows.Forms.LinkLabel();
		label51 = new System.Windows.Forms.Label();
		button9 = new System.Windows.Forms.Button();
		btnDown = new System.Windows.Forms.Button();
		btnUp = new System.Windows.Forms.Button();
		cbbTocDoGoVanBan = new System.Windows.Forms.ComboBox();
		lblTocDoGoVanBan = new System.Windows.Forms.Label();
		plSapXepCuaSoChrome = new System.Windows.Forms.Panel();
		cbbColumnChrome = new System.Windows.Forms.ComboBox();
		label10 = new System.Windows.Forms.Label();
		cbbRowChrome = new System.Windows.Forms.ComboBox();
		label11 = new System.Windows.Forms.Label();
		nudChromeScale = new System.Windows.Forms.NumericUpDown();
		A592D8B4 = new System.Windows.Forms.Panel();
		BA8586B0 = new System.Windows.Forms.NumericUpDown();
		nudHeighChrome = new System.Windows.Forms.NumericUpDown();
		label35 = new System.Windows.Forms.Label();
		A1BDE92B = new System.Windows.Forms.Label();
		ckbGologin = new System.Windows.Forms.CheckBox();
		ckbUseExtensionProxy = new System.Windows.Forms.CheckBox();
		ckbHideBrowser = new System.Windows.Forms.CheckBox();
		ckbShowImageInteract = new System.Windows.Forms.CheckBox();
		ckbAddChromeIntoForm = new System.Windows.Forms.CheckBox();
		ckbAddAndroidPhoneView = new System.Windows.Forms.CheckBox();
		panel3 = new System.Windows.Forms.Panel();
		label19 = new System.Windows.Forms.Label();
		txtLinkToOtherBrowser = new System.Windows.Forms.TextBox();
		DB13DAA8 = new System.Windows.Forms.Panel();
		FEA6DA1C = new System.Windows.Forms.TextBox();
		lblFileZip = new System.Windows.Forms.Label();
		ckbUsePortable = new System.Windows.Forms.CheckBox();
		CDBC4A2C = new System.Windows.Forms.GroupBox();
		txtCaptcha_4 = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		EB3600AF = new System.Windows.Forms.CheckBox();
		B42ED23C = new System.Windows.Forms.GroupBox();
		tabChangeIP = new System.Windows.Forms.TabControl();
		A7804FB9 = new System.Windows.Forms.TabPage();
		ED385A1A = new System.Windows.Forms.Panel();
		tabProxy = new System.Windows.Forms.TabPage();
		BA0EB62D = new System.Windows.Forms.Panel();
		cbbProxyType = new System.Windows.Forms.ComboBox();
		label45 = new System.Windows.Forms.Label();
		label33 = new System.Windows.Forms.Label();
		txtProxy = new System.Windows.Forms.RichTextBox();
		cbbProxy = new System.Windows.Forms.ComboBox();
		label39 = new System.Windows.Forms.Label();
		tabDcom = new System.Windows.Forms.TabPage();
		plDcom = new System.Windows.Forms.Panel();
		button4 = new System.Windows.Forms.Button();
		txtUrlHilink = new System.Windows.Forms.TextBox();
		A6BD02B4 = new System.Windows.Forms.TextBox();
		A1B5F810 = new System.Windows.Forms.RadioButton();
		label36 = new System.Windows.Forms.Label();
		A2868C92 = new System.Windows.Forms.RadioButton();
		tabXProxy = new System.Windows.Forms.TabPage();
		plXproxy = new System.Windows.Forms.Panel();
		label53 = new System.Windows.Forms.Label();
		AD04BF88 = new System.Windows.Forms.CheckBox();
		cbbTypeRunXproxy = new System.Windows.Forms.ComboBox();
		DD8F89BC = new System.Windows.Forms.RichTextBox();
		CEA19B35 = new System.Windows.Forms.RadioButton();
		rbHttpProxy = new System.Windows.Forms.RadioButton();
		DAABC591 = new System.Windows.Forms.Label();
		A52984BD = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		nudLuongPerIPXProxy = new System.Windows.Forms.NumericUpDown();
		CB12DD94 = new System.Windows.Forms.Label();
		DF104731 = new System.Windows.Forms.TextBox();
		tabObcProxy = new System.Windows.Forms.TabPage();
		plObcProxy = new System.Windows.Forms.Panel();
		BAAFBA3D = new System.Windows.Forms.ComboBox();
		label54 = new System.Windows.Forms.Label();
		rbObcSock5Proxy = new System.Windows.Forms.RadioButton();
		EF35891C = new System.Windows.Forms.RadioButton();
		label55 = new System.Windows.Forms.Label();
		ED07F537 = new System.Windows.Forms.RichTextBox();
		label67 = new System.Windows.Forms.Label();
		label69 = new System.Windows.Forms.Label();
		DE3AA0A2 = new System.Windows.Forms.NumericUpDown();
		label71 = new System.Windows.Forms.Label();
		txtLinkWebObcProxy = new System.Windows.Forms.TextBox();
		tabMinProxy = new System.Windows.Forms.TabPage();
		panel5 = new System.Windows.Forms.Panel();
		B08E0132 = new System.Windows.Forms.RadioButton();
		rbProxyDong = new System.Windows.Forms.RadioButton();
		D389003F = new System.Windows.Forms.Button();
		txtApiKeyMinProxy = new System.Windows.Forms.RichTextBox();
		E016E38C = new System.Windows.Forms.Label();
		label50 = new System.Windows.Forms.Label();
		plTypeProxy = new System.Windows.Forms.Panel();
		B92ECB82 = new System.Windows.Forms.ComboBox();
		label21 = new System.Windows.Forms.Label();
		nudLuongPerIPMinProxy = new System.Windows.Forms.NumericUpDown();
		tabProxyWeb = new System.Windows.Forms.TabPage();
		C3AF698D = new System.Windows.Forms.RichTextBox();
		lblApiKeyProxy = new System.Windows.Forms.Label();
		label65 = new System.Windows.Forms.Label();
		nudLuongPerIP = new System.Windows.Forms.NumericUpDown();
		cbbChangeIP = new System.Windows.Forms.ComboBox();
		EB0A3BA4 = new System.Windows.Forms.Label();
		label37 = new System.Windows.Forms.Label();
		nudDelayCheckIP = new System.Windows.Forms.NumericUpDown();
		label38 = new System.Windows.Forms.Label();
		AC15EA00 = new System.Windows.Forms.Panel();
		button5 = new System.Windows.Forms.Button();
		label26 = new System.Windows.Forms.Label();
		nudChangeIpCount = new System.Windows.Forms.NumericUpDown();
		label27 = new System.Windows.Forms.Label();
		ckbKhongCheckIP = new System.Windows.Forms.CheckBox();
		grEmailConfigs = new System.Windows.Forms.GroupBox();
		A6264B1A = new System.Windows.Forms.LinkLabel();
		linkLabel3 = new System.Windows.Forms.LinkLabel();
		A68F1C80 = new System.Windows.Forms.LinkLabel();
		panel7 = new System.Windows.Forms.Panel();
		CD2F5EB9 = new System.Windows.Forms.Label();
		F3A4F60E = new System.Windows.Forms.TextBox();
		label58 = new System.Windows.Forms.Label();
		panel4 = new System.Windows.Forms.Panel();
		F6214BB1 = new System.Windows.Forms.CheckBox();
		panel6 = new System.Windows.Forms.Panel();
		label59 = new System.Windows.Forms.Label();
		E298F032 = new System.Windows.Forms.Button();
		A784892D = new System.Windows.Forms.Panel();
		B622823D = new System.Windows.Forms.Label();
		txtTokenDonglaomail = new System.Windows.Forms.TextBox();
		txtMysqlServer = new System.Windows.Forms.TextBox();
		grCauHinhKhac = new System.Windows.Forms.GroupBox();
		D63D63A3 = new System.Windows.Forms.LinkLabel();
		ckbBackupDB = new System.Windows.Forms.CheckBox();
		EA12298A = new System.Windows.Forms.CheckBox();
		cbbTypePhanBietMau = new System.Windows.Forms.ComboBox();
		D804F51B = new System.Windows.Forms.Label();
		DBA562BA = new System.Windows.Forms.Panel();
		A1013881 = new System.Windows.Forms.RichTextBox();
		CE2E6104 = new System.Windows.Forms.RadioButton();
		C897B6B7 = new System.Windows.Forms.RadioButton();
		label40 = new System.Windows.Forms.Label();
		C2147C1F = new System.Windows.Forms.Label();
		label42 = new System.Windows.Forms.Label();
		FA1228A6 = new System.Windows.Forms.NumericUpDown();
		label46 = new System.Windows.Forms.Label();
		B4A292BB = new System.Windows.Forms.TextBox();
		cbbHostpot = new System.Windows.Forms.ComboBox();
		ckbMysqlServer = new System.Windows.Forms.CheckBox();
		rbVitech = new System.Windows.Forms.RadioButton();
		A6A9722C = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		FE379922 = new Bunifu.Framework.UI.BunifuCustomLabel();
		F5BBF938 = new System.Windows.Forms.Button();
		BD1A8989 = new System.Windows.Forms.Panel();
		label12 = new System.Windows.Forms.Label();
		F130372E = new System.Windows.Forms.TextBox();
		FB88FF8C = new System.Windows.Forms.Button();
		plNordVPN = new System.Windows.Forms.Panel();
		B6AABC28 = new System.Windows.Forms.Label();
		E301229B = new System.Windows.Forms.TextBox();
		E72E4C82 = new System.Windows.Forms.Button();
		radioButton4 = new System.Windows.Forms.RadioButton();
		rbHotspot = new System.Windows.Forms.RadioButton();
		radioButton5 = new System.Windows.Forms.RadioButton();
		rbNordVPN = new System.Windows.Forms.RadioButton();
		A81ECE2B = new System.Windows.Forms.RadioButton();
		rbSSH = new System.Windows.Forms.RadioButton();
		radioButton3 = new System.Windows.Forms.RadioButton();
		rbExpressVPN = new System.Windows.Forms.RadioButton();
		DCB0E58D = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		((System.ComponentModel.ISupportInitialize)F0B340B0).BeginInit();
		((System.ComponentModel.ISupportInitialize)D18BDD07).BeginInit();
		F90EBB3D.SuspendLayout();
		D1AA09A1.SuspendLayout();
		D08C5593.SuspendLayout();
		grCauHinhChrome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeTo).BeginInit();
		plGemLogin.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeFrom).BeginInit();
		plGpmLogin.SuspendLayout();
		plSizeChrome.SuspendLayout();
		plDelayCloseChrome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeFrom).BeginInit();
		plGologin.SuspendLayout();
		plSapXepCuaSoChrome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudChromeScale).BeginInit();
		A592D8B4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)BA8586B0).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudHeighChrome).BeginInit();
		panel3.SuspendLayout();
		DB13DAA8.SuspendLayout();
		CDBC4A2C.SuspendLayout();
		B42ED23C.SuspendLayout();
		tabChangeIP.SuspendLayout();
		A7804FB9.SuspendLayout();
		tabProxy.SuspendLayout();
		BA0EB62D.SuspendLayout();
		tabDcom.SuspendLayout();
		plDcom.SuspendLayout();
		tabXProxy.SuspendLayout();
		plXproxy.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).BeginInit();
		tabObcProxy.SuspendLayout();
		plObcProxy.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DE3AA0A2).BeginInit();
		tabMinProxy.SuspendLayout();
		panel5.SuspendLayout();
		plTypeProxy.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudLuongPerIPMinProxy).BeginInit();
		tabProxyWeb.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudLuongPerIP).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayCheckIP).BeginInit();
		AC15EA00.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudChangeIpCount).BeginInit();
		grEmailConfigs.SuspendLayout();
		panel7.SuspendLayout();
		panel4.SuspendLayout();
		panel6.SuspendLayout();
		A784892D.SuspendLayout();
		grCauHinhKhac.SuspendLayout();
		DBA562BA.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FA1228A6).BeginInit();
		A6A9722C.SuspendLayout();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		BD1A8989.SuspendLayout();
		plNordVPN.SuspendLayout();
		SuspendLayout();
		F312A539.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F312A539.BackColor = System.Drawing.Color.White;
		F312A539.BorderRadius = 5;
		F312A539.BottomSahddow = true;
		F312A539.color = System.Drawing.Color.SaddleBrown;
		F312A539.LeftSahddow = false;
		F312A539.Location = new System.Drawing.Point(0, 0);
		F312A539.Name = "bunifuCards1";
		F312A539.RightSahddow = true;
		F312A539.ShadowDepth = 20;
		F312A539.Size = new System.Drawing.Size(476, 38);
		F312A539.TabIndex = 12;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(32, 25);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(111, 16);
		label3.TabIndex = 23;
		label3.Text = "Số luồng Chrome:";
		F0B340B0.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F0B340B0.Location = new System.Drawing.Point(173, 23);
		F0B340B0.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
		F0B340B0.Name = "nudInteractThread";
		F0B340B0.Size = new System.Drawing.Size(89, 23);
		F0B340B0.TabIndex = 24;
		C4285B36.AutoSize = true;
		C4285B36.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C4285B36.Location = new System.Drawing.Point(265, 25);
		C4285B36.Name = "label4";
		C4285B36.Size = new System.Drawing.Size(41, 16);
		C4285B36.TabIndex = 25;
		C4285B36.Text = "Luồng";
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(265, 55);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(41, 16);
		label5.TabIndex = 28;
		label5.Text = "Luồng";
		D18BDD07.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D18BDD07.Location = new System.Drawing.Point(173, 53);
		D18BDD07.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
		D18BDD07.Name = "nudHideThread";
		D18BDD07.Size = new System.Drawing.Size(89, 23);
		D18BDD07.TabIndex = 27;
		label6.AutoSize = true;
		label6.Cursor = System.Windows.Forms.Cursors.Help;
		label6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(32, 55);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(125, 16);
		label6.TabIndex = 26;
		label6.Text = "Số luồng Check info:";
		B0069BAF.AutoSize = true;
		B0069BAF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B0069BAF.Location = new System.Drawing.Point(32, 85);
		B0069BAF.Name = "label9";
		B0069BAF.Size = new System.Drawing.Size(94, 16);
		B0069BAF.TabIndex = 33;
		B0069BAF.Text = "Folder profiles:";
		txbPathProfile.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txbPathProfile.Location = new System.Drawing.Point(173, 82);
		txbPathProfile.Name = "txbPathProfile";
		txbPathProfile.Size = new System.Drawing.Size(386, 23);
		txbPathProfile.TabIndex = 32;
		txbPathProfile.Click += new System.EventHandler(FEA6DA1C_Click);
		txbPathProfile.TextChanged += new System.EventHandler(F4268DBA);
		F90EBB3D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F90EBB3D.Controls.Add(D1AA09A1);
		F90EBB3D.Controls.Add(grCauHinhChrome);
		F90EBB3D.Controls.Add(CDBC4A2C);
		F90EBB3D.Controls.Add(B42ED23C);
		F90EBB3D.Controls.Add(grEmailConfigs);
		F90EBB3D.Controls.Add(txtMysqlServer);
		F90EBB3D.Controls.Add(grCauHinhKhac);
		F90EBB3D.Controls.Add(DBA562BA);
		F90EBB3D.Controls.Add(cbbHostpot);
		F90EBB3D.Controls.Add(ckbMysqlServer);
		F90EBB3D.Controls.Add(rbVitech);
		F90EBB3D.Controls.Add(A6A9722C);
		F90EBB3D.Controls.Add(F5BBF938);
		F90EBB3D.Controls.Add(BD1A8989);
		F90EBB3D.Controls.Add(FB88FF8C);
		F90EBB3D.Controls.Add(plNordVPN);
		F90EBB3D.Controls.Add(E72E4C82);
		F90EBB3D.Controls.Add(radioButton4);
		F90EBB3D.Controls.Add(rbHotspot);
		F90EBB3D.Controls.Add(radioButton5);
		F90EBB3D.Controls.Add(rbNordVPN);
		F90EBB3D.Controls.Add(A81ECE2B);
		F90EBB3D.Controls.Add(rbSSH);
		F90EBB3D.Controls.Add(radioButton3);
		F90EBB3D.Controls.Add(rbExpressVPN);
		F90EBB3D.Dock = System.Windows.Forms.DockStyle.Fill;
		F90EBB3D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F90EBB3D.Location = new System.Drawing.Point(0, 0);
		F90EBB3D.Name = "panel1";
		F90EBB3D.Size = new System.Drawing.Size(1059, 464);
		F90EBB3D.TabIndex = 37;
		F90EBB3D.Paint += new System.Windows.Forms.PaintEventHandler(F90EBB3D_Paint);
		D1AA09A1.Controls.Add(D08C5593);
		D1AA09A1.Controls.Add(ckbDongBoMaxCare);
		D1AA09A1.Controls.Add(metroButton2);
		D1AA09A1.Controls.Add(label5);
		D1AA09A1.Controls.Add(metroButton1);
		D1AA09A1.Controls.Add(D18BDD07);
		D1AA09A1.Controls.Add(label6);
		D1AA09A1.Controls.Add(B0069BAF);
		D1AA09A1.Controls.Add(txbPathProfile);
		D1AA09A1.Controls.Add(C4285B36);
		D1AA09A1.Controls.Add(F0B340B0);
		D1AA09A1.Controls.Add(label3);
		D1AA09A1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		D1AA09A1.Location = new System.Drawing.Point(7, 39);
		D1AA09A1.Name = "grCauHinhChung";
		D1AA09A1.Size = new System.Drawing.Size(568, 53);
		D1AA09A1.TabIndex = 38;
		D1AA09A1.TabStop = false;
		D1AA09A1.Text = "Cấu hình chung";
		D08C5593.Controls.Add(B51C7E0E);
		D08C5593.Controls.Add(F63689B9);
		D08C5593.Location = new System.Drawing.Point(48, 129);
		D08C5593.Name = "plDongBoMaxCare";
		D08C5593.Size = new System.Drawing.Size(517, 23);
		D08C5593.TabIndex = 168;
		B51C7E0E.AutoSize = true;
		B51C7E0E.Location = new System.Drawing.Point(3, 3);
		B51C7E0E.Name = "label22";
		B51C7E0E.Size = new System.Drawing.Size(102, 16);
		B51C7E0E.TabIndex = 158;
		B51C7E0E.Text = "Folder:";
		F63689B9.Location = new System.Drawing.Point(125, 0);
		F63689B9.Name = "txtPathMaxCare";
		F63689B9.Size = new System.Drawing.Size(386, 23);
		F63689B9.TabIndex = 159;
		ckbDongBoMaxCare.AutoSize = true;
		ckbDongBoMaxCare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDongBoMaxCare.Location = new System.Drawing.Point(35, 108);
		ckbDongBoMaxCare.Name = "ckbDongBoMaxCare";
		ckbDongBoMaxCare.Size = new System.Drawing.Size(191, 20);
		ckbDongBoMaxCare.TabIndex = 167;
		ckbDongBoMaxCare.Text = "Đô\u0300ng bô\u0323 dư\u0303 liê\u0323u vơ\u0301i LushCare";
		ckbDongBoMaxCare.UseVisualStyleBackColor = true;
		ckbDongBoMaxCare.CheckedChanged += new System.EventHandler(A1010A35);
		metroButton2.BackgroundImage = Class155.Bitmap_94;
		metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton2.Location = new System.Drawing.Point(512, 8);
		metroButton2.Name = "metroButton2";
		metroButton2.Size = new System.Drawing.Size(25, 25);
		metroButton2.TabIndex = 158;
		metroButton2.Click += new System.EventHandler(metroButton2_Click);
		metroButton1.BackgroundImage = Class155.B116C210;
		metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton1.Location = new System.Drawing.Point(543, 8);
		metroButton1.Name = "metroButton1";
		metroButton1.Size = new System.Drawing.Size(25, 25);
		metroButton1.TabIndex = 159;
		metroButton1.Click += new System.EventHandler(BA29DDBC);
		grCauHinhChrome.Controls.Add(nudDelayOpenChromeTo);
		grCauHinhChrome.Controls.Add(plGemLogin);
		grCauHinhChrome.Controls.Add(nudDelayOpenChromeFrom);
		grCauHinhChrome.Controls.Add(AEAB8830);
		grCauHinhChrome.Controls.Add(ckbGemLogin);
		grCauHinhChrome.Controls.Add(plGpmLogin);
		grCauHinhChrome.Controls.Add(plSizeChrome);
		grCauHinhChrome.Controls.Add(label29);
		grCauHinhChrome.Controls.Add(ckbGpmLogin);
		grCauHinhChrome.Controls.Add(plGologin);
		grCauHinhChrome.Controls.Add(button9);
		grCauHinhChrome.Controls.Add(btnDown);
		grCauHinhChrome.Controls.Add(btnUp);
		grCauHinhChrome.Controls.Add(cbbTocDoGoVanBan);
		grCauHinhChrome.Controls.Add(plSapXepCuaSoChrome);
		grCauHinhChrome.Controls.Add(nudChromeScale);
		grCauHinhChrome.Controls.Add(A592D8B4);
		grCauHinhChrome.Controls.Add(A1BDE92B);
		grCauHinhChrome.Controls.Add(ckbGologin);
		grCauHinhChrome.Controls.Add(ckbUseExtensionProxy);
		grCauHinhChrome.Controls.Add(ckbHideBrowser);
		grCauHinhChrome.Controls.Add(ckbShowImageInteract);
		grCauHinhChrome.Controls.Add(ckbAddChromeIntoForm);
		grCauHinhChrome.Controls.Add(ckbAddAndroidPhoneView);
		grCauHinhChrome.Controls.Add(panel3);
		grCauHinhChrome.Controls.Add(DB13DAA8);
		grCauHinhChrome.Controls.Add(lblTocDoGoVanBan);
		grCauHinhChrome.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		grCauHinhChrome.Location = new System.Drawing.Point(7, 98);
		grCauHinhChrome.Name = "grCauHinhChrome";
		grCauHinhChrome.Size = new System.Drawing.Size(568, 108);
		grCauHinhChrome.TabIndex = 38;
		grCauHinhChrome.TabStop = false;
		grCauHinhChrome.Text = "Cấu hình chrome";
		nudDelayOpenChromeTo.Location = new System.Drawing.Point(235, 78);
		nudDelayOpenChromeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayOpenChromeTo.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudDelayOpenChromeTo.Name = "nudDelayOpenChromeTo";
		nudDelayOpenChromeTo.Size = new System.Drawing.Size(41, 23);
		nudDelayOpenChromeTo.TabIndex = 151;
		nudDelayOpenChromeTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		plGemLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plGemLogin.Controls.Add(BE2283BF);
		plGemLogin.Controls.Add(txtGemApiUrl);
		plGemLogin.Controls.Add(label62);
		plGemLogin.Location = new System.Drawing.Point(172, 170);
		plGemLogin.Name = "plGemLogin";
		plGemLogin.Size = new System.Drawing.Size(390, 33);
		plGemLogin.TabIndex = 164;
		BE2283BF.Cursor = System.Windows.Forms.Cursors.Hand;
		BE2283BF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		BE2283BF.ForeColor = System.Drawing.Color.Black;
		BE2283BF.Location = new System.Drawing.Point(326, 3);
		BE2283BF.Name = "button11";
		BE2283BF.Size = new System.Drawing.Size(59, 25);
		BE2283BF.TabIndex = 143;
		BE2283BF.Text = "Check";
		BE2283BF.UseVisualStyleBackColor = true;
		BE2283BF.Click += new System.EventHandler(BE2283BF_Click);
		txtGemApiUrl.Location = new System.Drawing.Point(116, 4);
		txtGemApiUrl.Name = "txtGemApiUrl";
		txtGemApiUrl.Size = new System.Drawing.Size(204, 23);
		txtGemApiUrl.TabIndex = 149;
		label62.AutoSize = true;
		label62.Location = new System.Drawing.Point(5, 8);
		label62.Name = "label62";
		label62.Size = new System.Drawing.Size(57, 16);
		label62.TabIndex = 148;
		label62.Text = "API URL:";
		nudDelayOpenChromeFrom.Location = new System.Drawing.Point(173, 78);
		nudDelayOpenChromeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayOpenChromeFrom.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudDelayOpenChromeFrom.Name = "nudDelayOpenChromeFrom";
		nudDelayOpenChromeFrom.Size = new System.Drawing.Size(41, 23);
		nudDelayOpenChromeFrom.TabIndex = 151;
		nudDelayOpenChromeFrom.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		AEAB8830.AutoSize = true;
		AEAB8830.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AEAB8830.Location = new System.Drawing.Point(28, 80);
		AEAB8830.Name = "label20";
		AEAB8830.Size = new System.Drawing.Size(144, 16);
		AEAB8830.TabIndex = 33;
		AEAB8830.Text = "Delay Open chrome (s):";
		ckbGemLogin.AutoSize = true;
		ckbGemLogin.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGemLogin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbGemLogin.Location = new System.Drawing.Point(31, 177);
		ckbGemLogin.Name = "ckbGemLogin";
		ckbGemLogin.Size = new System.Drawing.Size(137, 20);
		ckbGemLogin.TabIndex = 163;
		ckbGemLogin.Text = "Sư\u0309 du\u0323ng GEM Login";
		ckbGemLogin.UseVisualStyleBackColor = true;
		ckbGemLogin.CheckedChanged += new System.EventHandler(ckbGemLogin_CheckedChanged);
		plGpmLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plGpmLogin.Controls.Add(B63267A8);
		plGpmLogin.Controls.Add(F1A8AE28);
		plGpmLogin.Controls.Add(label66);
		plGpmLogin.Controls.Add(E7039F9E);
		plGpmLogin.Controls.Add(ADA0CFA7);
		plGpmLogin.Location = new System.Drawing.Point(172, 209);
		plGpmLogin.Name = "plGpmLogin";
		plGpmLogin.Size = new System.Drawing.Size(390, 64);
		plGpmLogin.TabIndex = 162;
		B63267A8.Cursor = System.Windows.Forms.Cursors.Hand;
		B63267A8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B63267A8.ForeColor = System.Drawing.Color.Black;
		B63267A8.Location = new System.Drawing.Point(326, 3);
		B63267A8.Name = "button12";
		B63267A8.Size = new System.Drawing.Size(59, 25);
		B63267A8.TabIndex = 143;
		B63267A8.Text = "Check";
		B63267A8.UseVisualStyleBackColor = true;
		B63267A8.Click += new System.EventHandler(B63267A8_Click);
		F1A8AE28.Location = new System.Drawing.Point(116, 4);
		F1A8AE28.Name = "txtGpmApiUrl";
		F1A8AE28.Size = new System.Drawing.Size(204, 23);
		F1A8AE28.TabIndex = 149;
		label66.AutoSize = true;
		label66.Location = new System.Drawing.Point(5, 8);
		label66.Name = "label66";
		label66.Size = new System.Drawing.Size(57, 16);
		label66.TabIndex = 148;
		label66.Text = "API URL:";
		E7039F9E.Cursor = System.Windows.Forms.Cursors.Hand;
		E7039F9E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		E7039F9E.FormattingEnabled = true;
		E7039F9E.Location = new System.Drawing.Point(116, 33);
		E7039F9E.Name = "cbbBrowserVersion";
		E7039F9E.Size = new System.Drawing.Size(204, 24);
		E7039F9E.TabIndex = 34;
		ADA0CFA7.AutoSize = true;
		ADA0CFA7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ADA0CFA7.Location = new System.Drawing.Point(5, 36);
		ADA0CFA7.Name = "label68";
		ADA0CFA7.Size = new System.Drawing.Size(106, 16);
		ADA0CFA7.TabIndex = 33;
		ADA0CFA7.Text = "Browser Version:";
		plSizeChrome.Controls.Add(plDelayCloseChrome);
		plSizeChrome.Controls.Add(ckbDelayCloseChrome);
		plSizeChrome.Location = new System.Drawing.Point(162, 350);
		plSizeChrome.Name = "plSizeChrome";
		plSizeChrome.Size = new System.Drawing.Size(331, 25);
		plSizeChrome.TabIndex = 155;
		plDelayCloseChrome.Controls.Add(nudDelayCloseChromeTo);
		plDelayCloseChrome.Controls.Add(nudDelayCloseChromeFrom);
		plDelayCloseChrome.Controls.Add(label2);
		plDelayCloseChrome.Location = new System.Drawing.Point(164, -1);
		plDelayCloseChrome.Name = "plDelayCloseChrome";
		plDelayCloseChrome.Size = new System.Drawing.Size(111, 24);
		plDelayCloseChrome.TabIndex = 159;
		nudDelayCloseChromeTo.Location = new System.Drawing.Point(66, 1);
		nudDelayCloseChromeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayCloseChromeTo.Name = "nudDelayCloseChromeTo";
		nudDelayCloseChromeTo.Size = new System.Drawing.Size(43, 23);
		nudDelayCloseChromeTo.TabIndex = 151;
		nudDelayCloseChromeFrom.Location = new System.Drawing.Point(1, 1);
		nudDelayCloseChromeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayCloseChromeFrom.Name = "nudDelayCloseChromeFrom";
		nudDelayCloseChromeFrom.Size = new System.Drawing.Size(44, 23);
		nudDelayCloseChromeFrom.TabIndex = 151;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(44, 4);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(23, 16);
		label2.TabIndex = 33;
		label2.Text = ">";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ckbDelayCloseChrome.AutoSize = true;
		ckbDelayCloseChrome.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDelayCloseChrome.Location = new System.Drawing.Point(3, 1);
		ckbDelayCloseChrome.Name = "ckbDelayCloseChrome";
		ckbDelayCloseChrome.Size = new System.Drawing.Size(166, 20);
		ckbDelayCloseChrome.TabIndex = 158;
		ckbDelayCloseChrome.Text = "Delay Close Chrome (s):";
		ckbDelayCloseChrome.UseVisualStyleBackColor = true;
		ckbDelayCloseChrome.CheckedChanged += new System.EventHandler(BF067980);
		label29.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label29.Location = new System.Drawing.Point(213, 81);
		label29.Name = "label29";
		label29.Size = new System.Drawing.Size(23, 16);
		label29.TabIndex = 33;
		label29.Text = ">";
		label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ckbGpmLogin.AutoSize = true;
		ckbGpmLogin.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGpmLogin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbGpmLogin.Location = new System.Drawing.Point(31, 216);
		ckbGpmLogin.Name = "ckbGpmLogin";
		ckbGpmLogin.Size = new System.Drawing.Size(137, 20);
		ckbGpmLogin.TabIndex = 161;
		ckbGpmLogin.Text = "Sư\u0309 du\u0323ng GPM Login";
		ckbGpmLogin.UseVisualStyleBackColor = true;
		ckbGpmLogin.CheckedChanged += new System.EventHandler(ckbGpmLogin_CheckedChanged);
		plGologin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plGologin.Controls.Add(txtOrbitaPath);
		plGologin.Controls.Add(linkLabel1);
		plGologin.Controls.Add(label51);
		plGologin.Location = new System.Drawing.Point(172, 137);
		plGologin.Name = "plGologin";
		plGologin.Size = new System.Drawing.Size(390, 27);
		plGologin.TabIndex = 156;
		plGologin.Click += new System.EventHandler(panel3_Click);
		txtOrbitaPath.Location = new System.Drawing.Point(116, 1);
		txtOrbitaPath.Name = "txtOrbitaPath";
		txtOrbitaPath.Size = new System.Drawing.Size(204, 23);
		txtOrbitaPath.TabIndex = 149;
		linkLabel1.AutoSize = true;
		linkLabel1.Location = new System.Drawing.Point(322, 4);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new System.Drawing.Size(62, 16);
		linkLabel1.TabIndex = 150;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "download";
		linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		label51.AutoSize = true;
		label51.Location = new System.Drawing.Point(-1, 5);
		label51.Name = "label51";
		label51.Size = new System.Drawing.Size(118, 16);
		label51.TabIndex = 148;
		label51.Text = "Orbita chrome.exe:";
		button9.Cursor = System.Windows.Forms.Cursors.Hand;
		button9.Location = new System.Drawing.Point(429, 77);
		button9.Name = "button9";
		button9.Size = new System.Drawing.Size(137, 26);
		button9.TabIndex = 160;
		button9.Text = "Update Chromedriver";
		button9.UseVisualStyleBackColor = true;
		button9.Click += new System.EventHandler(F3BF3CA3);
		btnDown.BackgroundImage = Class155.Bitmap_94;
		btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDown.Location = new System.Drawing.Point(512, 8);
		btnDown.Name = "btnDown";
		btnDown.Size = new System.Drawing.Size(25, 25);
		btnDown.TabIndex = 158;
		btnDown.Click += new System.EventHandler(D1BF43B6);
		btnUp.BackgroundImage = Class155.B116C210;
		btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
		btnUp.Location = new System.Drawing.Point(543, 8);
		btnUp.Name = "btnUp";
		btnUp.Size = new System.Drawing.Size(25, 25);
		btnUp.TabIndex = 159;
		btnUp.Click += new System.EventHandler(btnUp_Click);
		cbbTocDoGoVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTocDoGoVanBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTocDoGoVanBan.FormattingEnabled = true;
		cbbTocDoGoVanBan.Location = new System.Drawing.Point(356, 20);
		cbbTocDoGoVanBan.Name = "cbbTocDoGoVanBan";
		cbbTocDoGoVanBan.Size = new System.Drawing.Size(102, 24);
		cbbTocDoGoVanBan.TabIndex = 34;
		cbbTocDoGoVanBan.Visible = false;
		lblTocDoGoVanBan.AutoSize = true;
		lblTocDoGoVanBan.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblTocDoGoVanBan.Location = new System.Drawing.Point(232, 23);
		lblTocDoGoVanBan.Name = "lblTocDoGoVanBan";
		lblTocDoGoVanBan.Size = new System.Drawing.Size(118, 16);
		lblTocDoGoVanBan.TabIndex = 33;
		lblTocDoGoVanBan.Text = "Tốc độ gõ văn bản:";
		lblTocDoGoVanBan.Visible = false;
		plSapXepCuaSoChrome.Controls.Add(cbbColumnChrome);
		plSapXepCuaSoChrome.Controls.Add(label10);
		plSapXepCuaSoChrome.Controls.Add(cbbRowChrome);
		plSapXepCuaSoChrome.Controls.Add(label11);
		plSapXepCuaSoChrome.Location = new System.Drawing.Point(25, 44);
		plSapXepCuaSoChrome.Name = "plSapXepCuaSoChrome";
		plSapXepCuaSoChrome.Size = new System.Drawing.Size(251, 29);
		plSapXepCuaSoChrome.TabIndex = 157;
		cbbColumnChrome.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbColumnChrome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbColumnChrome.FormattingEnabled = true;
		cbbColumnChrome.Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
		cbbColumnChrome.Location = new System.Drawing.Point(148, 2);
		cbbColumnChrome.Name = "cbbColumnChrome";
		cbbColumnChrome.Size = new System.Drawing.Size(40, 24);
		cbbColumnChrome.TabIndex = 145;
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(3, 5);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(147, 16);
		label10.TabIndex = 33;
		label10.Text = "Sắp xếp cửa sổ chrome:";
		cbbRowChrome.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbRowChrome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbRowChrome.FormattingEnabled = true;
		cbbRowChrome.Items.AddRange(new object[5] { "1", "2", "3", "4", "5" });
		cbbRowChrome.Location = new System.Drawing.Point(210, 2);
		cbbRowChrome.Name = "cbbRowChrome";
		cbbRowChrome.Size = new System.Drawing.Size(40, 24);
		cbbRowChrome.TabIndex = 145;
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(188, 2);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(23, 23);
		label11.TabIndex = 33;
		label11.Text = "X";
		nudChromeScale.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		nudChromeScale.Location = new System.Drawing.Point(378, 78);
		nudChromeScale.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
		nudChromeScale.Name = "nudChromeScale";
		nudChromeScale.Size = new System.Drawing.Size(45, 23);
		nudChromeScale.TabIndex = 24;
		nudChromeScale.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		nudChromeScale.Visible = false;
		A592D8B4.Controls.Add(BA8586B0);
		A592D8B4.Controls.Add(nudHeighChrome);
		A592D8B4.Controls.Add(label35);
		A592D8B4.Location = new System.Drawing.Point(456, 45);
		A592D8B4.Name = "plAddChromeVaoFormView";
		A592D8B4.Size = new System.Drawing.Size(110, 27);
		A592D8B4.TabIndex = 156;
		BA8586B0.Location = new System.Drawing.Point(1, 2);
		BA8586B0.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		BA8586B0.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		BA8586B0.Name = "nudWidthChrome";
		BA8586B0.Size = new System.Drawing.Size(43, 23);
		BA8586B0.TabIndex = 151;
		BA8586B0.Value = new decimal(new int[4] { 320, 0, 0, 0 });
		nudHeighChrome.Location = new System.Drawing.Point(66, 2);
		nudHeighChrome.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudHeighChrome.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudHeighChrome.Name = "nudHeighChrome";
		nudHeighChrome.Size = new System.Drawing.Size(43, 23);
		nudHeighChrome.TabIndex = 151;
		nudHeighChrome.Value = new decimal(new int[4] { 480, 0, 0, 0 });
		label35.AutoSize = true;
		label35.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label35.Location = new System.Drawing.Point(44, 2);
		label35.Name = "label35";
		label35.Size = new System.Drawing.Size(23, 23);
		label35.TabIndex = 33;
		label35.Text = "X";
		A1BDE92B.AutoSize = true;
		A1BDE92B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A1BDE92B.Location = new System.Drawing.Point(292, 80);
		A1BDE92B.Name = "lblChromeScale";
		A1BDE92B.Size = new System.Drawing.Size(86, 16);
		A1BDE92B.TabIndex = 23;
		A1BDE92B.Text = "Ty\u0309 lê\u0323 hiê\u0309n thi\u0323:";
		A1BDE92B.Visible = false;
		ckbGologin.AutoSize = true;
		ckbGologin.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGologin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbGologin.Location = new System.Drawing.Point(31, 141);
		ckbGologin.Name = "ckbGologin";
		ckbGologin.Size = new System.Drawing.Size(120, 20);
		ckbGologin.TabIndex = 112;
		ckbGologin.Text = "Sư\u0309 du\u0323ng Gologin";
		ckbGologin.UseVisualStyleBackColor = true;
		ckbGologin.CheckedChanged += new System.EventHandler(ckbGologin_CheckedChanged);
		ckbUseExtensionProxy.AutoSize = true;
		ckbUseExtensionProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUseExtensionProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbUseExtensionProxy.Location = new System.Drawing.Point(32, 324);
		ckbUseExtensionProxy.Name = "ckbUseExtensionProxy";
		ckbUseExtensionProxy.Size = new System.Drawing.Size(140, 20);
		ckbUseExtensionProxy.TabIndex = 112;
		ckbUseExtensionProxy.Text = "Use extension proxy";
		ckbUseExtensionProxy.UseVisualStyleBackColor = true;
		ckbHideBrowser.AutoSize = true;
		ckbHideBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHideBrowser.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbHideBrowser.Location = new System.Drawing.Point(295, 79);
		ckbHideBrowser.Name = "ckbHideBrowser";
		ckbHideBrowser.Size = new System.Drawing.Size(88, 20);
		ckbHideBrowser.TabIndex = 112;
		ckbHideBrowser.Text = "Ẩn chrome";
		ckbHideBrowser.UseVisualStyleBackColor = true;
		ckbHideBrowser.Visible = false;
		ckbShowImageInteract.AutoSize = true;
		ckbShowImageInteract.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShowImageInteract.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbShowImageInteract.Location = new System.Drawing.Point(32, 22);
		ckbShowImageInteract.Name = "ckbShowImageInteract";
		ckbShowImageInteract.Size = new System.Drawing.Size(183, 20);
		ckbShowImageInteract.TabIndex = 112;
		ckbShowImageInteract.Text = "Hiê\u0323n a\u0309nh khi mơ\u0309 tri\u0300nh duyê\u0323t";
		ckbShowImageInteract.UseVisualStyleBackColor = true;
		ckbAddChromeIntoForm.AutoSize = true;
		ckbAddChromeIntoForm.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAddChromeIntoForm.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbAddChromeIntoForm.Location = new System.Drawing.Point(295, 48);
		ckbAddChromeIntoForm.Name = "ckbAddChromeIntoForm";
		ckbAddChromeIntoForm.Size = new System.Drawing.Size(163, 20);
		ckbAddChromeIntoForm.TabIndex = 112;
		ckbAddChromeIntoForm.Text = "Add Chrome Form View";
		ckbAddChromeIntoForm.UseVisualStyleBackColor = true;
		ckbAddChromeIntoForm.CheckedChanged += new System.EventHandler(ckbAddChromeIntoForm_CheckedChanged);
		ckbAddAndroidPhoneView.AutoSize = true;
		ckbAddAndroidPhoneView.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAddAndroidPhoneView.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbAddAndroidPhoneView.Location = new System.Drawing.Point(295, 22);
		ckbAddAndroidPhoneView.Name = "ckbAddAndroidPhoneView";
		ckbAddAndroidPhoneView.Size = new System.Drawing.Size(168, 20);
		ckbAddAndroidPhoneView.TabIndex = 111;
		ckbAddAndroidPhoneView.Text = "Add Android Phone View";
		ckbAddAndroidPhoneView.UseVisualStyleBackColor = true;
		ckbAddAndroidPhoneView.CheckedChanged += new System.EventHandler(ckbAddAndroidPhoneView_CheckedChanged);
		panel3.Controls.Add(label19);
		panel3.Controls.Add(txtLinkToOtherBrowser);
		panel3.Location = new System.Drawing.Point(29, 108);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(535, 25);
		panel3.TabIndex = 156;
		panel3.Click += new System.EventHandler(panel3_Click);
		label19.AutoSize = true;
		label19.Location = new System.Drawing.Point(-3, 4);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(108, 16);
		label19.TabIndex = 148;
		label19.Text = "Path chrome.exe:";
		txtLinkToOtherBrowser.Location = new System.Drawing.Point(143, 1);
		txtLinkToOtherBrowser.Name = "txtLinkToOtherBrowser";
		txtLinkToOtherBrowser.Size = new System.Drawing.Size(390, 23);
		txtLinkToOtherBrowser.TabIndex = 149;
		DB13DAA8.Controls.Add(FEA6DA1C);
		DB13DAA8.Controls.Add(lblFileZip);
		DB13DAA8.Controls.Add(ckbUsePortable);
		DB13DAA8.Location = new System.Drawing.Point(29, 108);
		DB13DAA8.Name = "plUsePortable";
		DB13DAA8.Size = new System.Drawing.Size(502, 25);
		DB13DAA8.TabIndex = 155;
		DB13DAA8.Paint += new System.Windows.Forms.PaintEventHandler(DB13DAA8_Paint);
		FEA6DA1C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FEA6DA1C.Location = new System.Drawing.Point(194, 1);
		FEA6DA1C.Name = "txtPathToPortableZip";
		FEA6DA1C.Size = new System.Drawing.Size(305, 23);
		FEA6DA1C.TabIndex = 32;
		FEA6DA1C.Click += new System.EventHandler(FEA6DA1C_Click);
		lblFileZip.AutoSize = true;
		lblFileZip.Location = new System.Drawing.Point(139, 4);
		lblFileZip.Name = "lblFileZip";
		lblFileZip.Size = new System.Drawing.Size(52, 16);
		lblFileZip.TabIndex = 113;
		lblFileZip.Text = "File zip:";
		ckbUsePortable.AutoSize = true;
		ckbUsePortable.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUsePortable.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbUsePortable.Location = new System.Drawing.Point(0, 3);
		ckbUsePortable.Name = "ckbUsePortable";
		ckbUsePortable.Size = new System.Drawing.Size(125, 20);
		ckbUsePortable.TabIndex = 112;
		ckbUsePortable.Text = "Sử dụng Portable";
		ckbUsePortable.UseVisualStyleBackColor = true;
		ckbUsePortable.CheckedChanged += new System.EventHandler(ckbUsePortable_CheckedChanged);
		CDBC4A2C.Controls.Add(txtCaptcha_4);
		CDBC4A2C.Controls.Add(button1);
		CDBC4A2C.Controls.Add(label1);
		CDBC4A2C.Controls.Add(EB3600AF);
		CDBC4A2C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CDBC4A2C.Location = new System.Drawing.Point(7, 212);
		CDBC4A2C.Name = "groupBox2";
		CDBC4A2C.Size = new System.Drawing.Size(568, 52);
		CDBC4A2C.TabIndex = 165;
		CDBC4A2C.TabStop = false;
		CDBC4A2C.Text = "Cấu hình captcha";
		txtCaptcha_4.Location = new System.Drawing.Point(187, 20);
		txtCaptcha_4.Name = "txtCaptcha_4";
		txtCaptcha_4.Size = new System.Drawing.Size(236, 23);
		txtCaptcha_4.TabIndex = 173;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.Location = new System.Drawing.Point(429, 18);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(52, 27);
		button1.TabIndex = 171;
		button1.Text = "Check";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(FABC2DA7);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(29, 23);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(159, 16);
		label1.TabIndex = 172;
		label1.Text = "API Key OMOcaptcha.com:";
		EB3600AF.AutoSize = true;
		EB3600AF.Cursor = System.Windows.Forms.Cursors.Hand;
		EB3600AF.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EB3600AF.Location = new System.Drawing.Point(487, 22);
		EB3600AF.Name = "ckbExtensionOmoCaptcha";
		EB3600AF.Size = new System.Drawing.Size(80, 20);
		EB3600AF.TabIndex = 112;
		EB3600AF.Text = "Extension";
		EB3600AF.UseVisualStyleBackColor = true;
		B42ED23C.Controls.Add(tabChangeIP);
		B42ED23C.Controls.Add(cbbChangeIP);
		B42ED23C.Controls.Add(EB0A3BA4);
		B42ED23C.Controls.Add(label37);
		B42ED23C.Controls.Add(nudDelayCheckIP);
		B42ED23C.Controls.Add(label38);
		B42ED23C.Controls.Add(AC15EA00);
		B42ED23C.Controls.Add(ckbKhongCheckIP);
		B42ED23C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B42ED23C.Location = new System.Drawing.Point(580, 38);
		B42ED23C.Name = "groupBox3";
		B42ED23C.Size = new System.Drawing.Size(471, 290);
		B42ED23C.TabIndex = 39;
		B42ED23C.TabStop = false;
		B42ED23C.Text = "Cấu hình đổi IP";
		tabChangeIP.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabChangeIP.Controls.Add(A7804FB9);
		tabChangeIP.Controls.Add(tabProxy);
		tabChangeIP.Controls.Add(tabDcom);
		tabChangeIP.Controls.Add(tabXProxy);
		tabChangeIP.Controls.Add(tabObcProxy);
		tabChangeIP.Controls.Add(tabMinProxy);
		tabChangeIP.Controls.Add(tabProxyWeb);
		tabChangeIP.Cursor = System.Windows.Forms.Cursors.Hand;
		tabChangeIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tabChangeIP.Location = new System.Drawing.Point(30, 107);
		tabChangeIP.Name = "tabChangeIP";
		tabChangeIP.SelectedIndex = 0;
		tabChangeIP.Size = new System.Drawing.Size(440, 206);
		tabChangeIP.TabIndex = 146;
		A7804FB9.Controls.Add(ED385A1A);
		A7804FB9.Location = new System.Drawing.Point(4, 4);
		A7804FB9.Name = "tabNone";
		A7804FB9.Padding = new System.Windows.Forms.Padding(3);
		A7804FB9.Size = new System.Drawing.Size(432, 177);
		A7804FB9.TabIndex = 7;
		A7804FB9.Text = "tabNone";
		A7804FB9.UseVisualStyleBackColor = true;
		ED385A1A.Dock = System.Windows.Forms.DockStyle.Fill;
		ED385A1A.Location = new System.Drawing.Point(3, 3);
		ED385A1A.Name = "panel16";
		ED385A1A.Size = new System.Drawing.Size(426, 171);
		ED385A1A.TabIndex = 0;
		tabProxy.Controls.Add(BA0EB62D);
		tabProxy.Controls.Add(cbbProxy);
		tabProxy.Controls.Add(label39);
		tabProxy.Location = new System.Drawing.Point(4, 4);
		tabProxy.Name = "tabProxy";
		tabProxy.Size = new System.Drawing.Size(432, 177);
		tabProxy.TabIndex = 10;
		tabProxy.Text = "tabProxy";
		tabProxy.UseVisualStyleBackColor = true;
		BA0EB62D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		BA0EB62D.Controls.Add(cbbProxyType);
		BA0EB62D.Controls.Add(label45);
		BA0EB62D.Controls.Add(label33);
		BA0EB62D.Controls.Add(txtProxy);
		BA0EB62D.Location = new System.Drawing.Point(70, 46);
		BA0EB62D.Name = "plTuyChonProxy";
		BA0EB62D.Size = new System.Drawing.Size(304, 116);
		BA0EB62D.TabIndex = 161;
		cbbProxyType.Anchor = System.Windows.Forms.AnchorStyles.None;
		cbbProxyType.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbProxyType.DropDownWidth = 150;
		cbbProxyType.FormattingEnabled = true;
		cbbProxyType.Items.AddRange(new object[2] { "Http", "Sock5" });
		cbbProxyType.Location = new System.Drawing.Point(215, 3);
		cbbProxyType.Name = "cbbProxyType";
		cbbProxyType.Size = new System.Drawing.Size(84, 24);
		cbbProxyType.TabIndex = 162;
		label45.Anchor = System.Windows.Forms.AnchorStyles.None;
		label45.AutoSize = true;
		label45.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label45.Location = new System.Drawing.Point(142, 6);
		label45.Name = "label45";
		label45.Size = new System.Drawing.Size(70, 16);
		label45.TabIndex = 161;
		label45.Text = "Loại Proxy:";
		label33.Anchor = System.Windows.Forms.AnchorStyles.None;
		label33.AutoSize = true;
		label33.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label33.Location = new System.Drawing.Point(3, 6);
		label33.Name = "label33";
		label33.Size = new System.Drawing.Size(97, 16);
		label33.TabIndex = 147;
		label33.Text = "Nhập Proxy (0):";
		txtProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		txtProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtProxy.Location = new System.Drawing.Point(6, 30);
		txtProxy.Name = "txtProxy";
		txtProxy.Size = new System.Drawing.Size(294, 82);
		txtProxy.TabIndex = 148;
		txtProxy.Text = "";
		txtProxy.WordWrap = false;
		txtProxy.TextChanged += new System.EventHandler(txtProxy_TextChanged);
		cbbProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		cbbProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbProxy.DropDownWidth = 150;
		cbbProxy.FormattingEnabled = true;
		cbbProxy.Location = new System.Drawing.Point(137, 16);
		cbbProxy.Name = "cbbProxy";
		cbbProxy.Size = new System.Drawing.Size(237, 24);
		cbbProxy.TabIndex = 160;
		cbbProxy.SelectedIndexChanged += new System.EventHandler(cbbProxy_SelectedIndexChanged);
		label39.Anchor = System.Windows.Forms.AnchorStyles.None;
		label39.AutoSize = true;
		label39.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label39.Location = new System.Drawing.Point(67, 19);
		label39.Name = "label39";
		label39.Size = new System.Drawing.Size(64, 16);
		label39.TabIndex = 159;
		label39.Text = "Tùy chọn:";
		tabDcom.Controls.Add(plDcom);
		tabDcom.Location = new System.Drawing.Point(4, 4);
		tabDcom.Name = "tabDcom";
		tabDcom.Padding = new System.Windows.Forms.Padding(3);
		tabDcom.Size = new System.Drawing.Size(432, 177);
		tabDcom.TabIndex = 0;
		tabDcom.Text = "Dcom";
		tabDcom.UseVisualStyleBackColor = true;
		plDcom.Controls.Add(button4);
		plDcom.Controls.Add(txtUrlHilink);
		plDcom.Controls.Add(A6BD02B4);
		plDcom.Controls.Add(A1B5F810);
		plDcom.Controls.Add(label36);
		plDcom.Controls.Add(A2868C92);
		plDcom.Dock = System.Windows.Forms.DockStyle.Fill;
		plDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		plDcom.Location = new System.Drawing.Point(3, 3);
		plDcom.Name = "plDcom";
		plDcom.Size = new System.Drawing.Size(426, 171);
		plDcom.TabIndex = 131;
		button4.Anchor = System.Windows.Forms.AnchorStyles.None;
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		button4.ForeColor = System.Drawing.Color.Black;
		button4.Location = new System.Drawing.Point(279, 57);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(93, 25);
		button4.TabIndex = 143;
		button4.Text = "Lâ\u0301y tên Dcom";
		button4.UseVisualStyleBackColor = true;
		button4.Click += new System.EventHandler(button4_Click);
		txtUrlHilink.Anchor = System.Windows.Forms.AnchorStyles.None;
		txtUrlHilink.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		txtUrlHilink.ForeColor = System.Drawing.Color.Black;
		txtUrlHilink.Location = new System.Drawing.Point(151, 106);
		txtUrlHilink.Name = "txtUrlHilink";
		txtUrlHilink.Size = new System.Drawing.Size(221, 23);
		txtUrlHilink.TabIndex = 81;
		A6BD02B4.Anchor = System.Windows.Forms.AnchorStyles.None;
		A6BD02B4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A6BD02B4.ForeColor = System.Drawing.Color.Black;
		A6BD02B4.Location = new System.Drawing.Point(87, 58);
		A6BD02B4.Name = "txtProfileNameDcom";
		A6BD02B4.Size = new System.Drawing.Size(186, 23);
		A6BD02B4.TabIndex = 81;
		A1B5F810.Anchor = System.Windows.Forms.AnchorStyles.None;
		A1B5F810.AutoSize = true;
		A1B5F810.Cursor = System.Windows.Forms.Cursors.Hand;
		A1B5F810.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A1B5F810.Location = new System.Drawing.Point(68, 85);
		A1B5F810.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		A1B5F810.Name = "rbDcomHilink";
		A1B5F810.Size = new System.Drawing.Size(55, 20);
		A1B5F810.TabIndex = 136;
		A1B5F810.Text = "Hilink";
		A1B5F810.UseVisualStyleBackColor = true;
		A1B5F810.CheckedChanged += new System.EventHandler(A1B5F810_CheckedChanged);
		label36.Anchor = System.Windows.Forms.AnchorStyles.None;
		label36.AutoSize = true;
		label36.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label36.Location = new System.Drawing.Point(84, 109);
		label36.Name = "label36";
		label36.Size = new System.Drawing.Size(64, 16);
		label36.TabIndex = 79;
		label36.Text = "Link Web:";
		A2868C92.Anchor = System.Windows.Forms.AnchorStyles.None;
		A2868C92.AutoSize = true;
		A2868C92.Cursor = System.Windows.Forms.Cursors.Hand;
		A2868C92.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A2868C92.Location = new System.Drawing.Point(68, 34);
		A2868C92.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		A2868C92.Name = "rbDcomThuong";
		A2868C92.Size = new System.Drawing.Size(69, 20);
		A2868C92.TabIndex = 136;
		A2868C92.Text = "Thươ\u0300ng";
		A2868C92.UseVisualStyleBackColor = true;
		A2868C92.CheckedChanged += new System.EventHandler(B4B8DE1E);
		tabXProxy.Controls.Add(plXproxy);
		tabXProxy.Location = new System.Drawing.Point(4, 4);
		tabXProxy.Name = "tabXProxy";
		tabXProxy.Padding = new System.Windows.Forms.Padding(3);
		tabXProxy.Size = new System.Drawing.Size(432, 177);
		tabXProxy.TabIndex = 2;
		tabXProxy.Text = "Xproxy";
		tabXProxy.UseVisualStyleBackColor = true;
		plXproxy.Controls.Add(label53);
		plXproxy.Controls.Add(AD04BF88);
		plXproxy.Controls.Add(cbbTypeRunXproxy);
		plXproxy.Controls.Add(DD8F89BC);
		plXproxy.Controls.Add(CEA19B35);
		plXproxy.Controls.Add(rbHttpProxy);
		plXproxy.Controls.Add(DAABC591);
		plXproxy.Controls.Add(A52984BD);
		plXproxy.Controls.Add(label18);
		plXproxy.Controls.Add(nudLuongPerIPXProxy);
		plXproxy.Controls.Add(CB12DD94);
		plXproxy.Controls.Add(DF104731);
		plXproxy.Dock = System.Windows.Forms.DockStyle.Fill;
		plXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		plXproxy.Location = new System.Drawing.Point(3, 3);
		plXproxy.Name = "plXproxy";
		plXproxy.Size = new System.Drawing.Size(426, 171);
		plXproxy.TabIndex = 142;
		plXproxy.Click += new System.EventHandler(plXproxy_Click);
		label53.Anchor = System.Windows.Forms.AnchorStyles.None;
		label53.AutoSize = true;
		label53.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label53.Location = new System.Drawing.Point(244, 139);
		label53.Name = "label53";
		label53.Size = new System.Drawing.Size(82, 16);
		label53.TabIndex = 155;
		label53.Text = "Chế độ chạy:";
		AD04BF88.Anchor = System.Windows.Forms.AnchorStyles.None;
		AD04BF88.AutoSize = true;
		AD04BF88.Cursor = System.Windows.Forms.Cursors.Hand;
		AD04BF88.Location = new System.Drawing.Point(115, 60);
		AD04BF88.Name = "ckbWaitDoneAllXproxy";
		AD04BF88.Size = new System.Drawing.Size(128, 20);
		AD04BF88.TabIndex = 145;
		AD04BF88.Text = "Đợi chạy xong hết";
		AD04BF88.UseVisualStyleBackColor = true;
		AD04BF88.Visible = false;
		cbbTypeRunXproxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		cbbTypeRunXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeRunXproxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeRunXproxy.DropDownWidth = 150;
		cbbTypeRunXproxy.FormattingEnabled = true;
		cbbTypeRunXproxy.Items.AddRange(new object[2] { "Reset từng proxy", "Reset tất cả proxy" });
		cbbTypeRunXproxy.Location = new System.Drawing.Point(332, 135);
		cbbTypeRunXproxy.Name = "cbbTypeRunXproxy";
		cbbTypeRunXproxy.Size = new System.Drawing.Size(84, 24);
		cbbTypeRunXproxy.TabIndex = 34;
		DD8F89BC.Anchor = System.Windows.Forms.AnchorStyles.None;
		DD8F89BC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DD8F89BC.Location = new System.Drawing.Point(9, 82);
		DD8F89BC.Name = "txtListProxy";
		DD8F89BC.Size = new System.Drawing.Size(229, 78);
		DD8F89BC.TabIndex = 144;
		DD8F89BC.Text = "";
		DD8F89BC.WordWrap = false;
		DD8F89BC.TextChanged += new System.EventHandler(DD8F89BC_TextChanged);
		CEA19B35.Anchor = System.Windows.Forms.AnchorStyles.None;
		CEA19B35.AutoSize = true;
		CEA19B35.Cursor = System.Windows.Forms.Cursors.Hand;
		CEA19B35.Location = new System.Drawing.Point(156, 36);
		CEA19B35.Name = "rbSock5Proxy";
		CEA19B35.Size = new System.Drawing.Size(59, 20);
		CEA19B35.TabIndex = 82;
		CEA19B35.Text = "Sock5";
		CEA19B35.UseVisualStyleBackColor = true;
		rbHttpProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		rbHttpProxy.AutoSize = true;
		rbHttpProxy.Checked = true;
		rbHttpProxy.Cursor = System.Windows.Forms.Cursors.Hand;
		rbHttpProxy.Location = new System.Drawing.Point(93, 36);
		rbHttpProxy.Name = "rbHttpProxy";
		rbHttpProxy.Size = new System.Drawing.Size(48, 20);
		rbHttpProxy.TabIndex = 82;
		rbHttpProxy.TabStop = true;
		rbHttpProxy.Text = "Http";
		rbHttpProxy.UseVisualStyleBackColor = true;
		DAABC591.Anchor = System.Windows.Forms.AnchorStyles.None;
		DAABC591.AutoSize = true;
		DAABC591.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DAABC591.Location = new System.Drawing.Point(6, 36);
		DAABC591.Name = "label16";
		DAABC591.Size = new System.Drawing.Size(70, 16);
		DAABC591.TabIndex = 79;
		DAABC591.Text = "Loại Proxy:";
		A52984BD.Anchor = System.Windows.Forms.AnchorStyles.None;
		A52984BD.AutoSize = true;
		A52984BD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A52984BD.Location = new System.Drawing.Point(6, 61);
		A52984BD.Name = "label17";
		A52984BD.Size = new System.Drawing.Size(97, 16);
		A52984BD.TabIndex = 79;
		A52984BD.Text = "Nhập Proxy (0):";
		label18.Anchor = System.Windows.Forms.AnchorStyles.None;
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label18.Location = new System.Drawing.Point(244, 108);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(78, 16);
		label18.TabIndex = 139;
		label18.Text = "Số luồng/IP:";
		nudLuongPerIPXProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		nudLuongPerIPXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudLuongPerIPXProxy.Location = new System.Drawing.Point(332, 106);
		nudLuongPerIPXProxy.Name = "nudLuongPerIPXProxy";
		nudLuongPerIPXProxy.Size = new System.Drawing.Size(84, 23);
		nudLuongPerIPXProxy.TabIndex = 140;
		nudLuongPerIPXProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		CB12DD94.Anchor = System.Windows.Forms.AnchorStyles.None;
		CB12DD94.AutoSize = true;
		CB12DD94.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		CB12DD94.Location = new System.Drawing.Point(6, 12);
		CB12DD94.Name = "label13";
		CB12DD94.Size = new System.Drawing.Size(80, 16);
		CB12DD94.TabIndex = 79;
		CB12DD94.Text = "Service URL:";
		DF104731.Anchor = System.Windows.Forms.AnchorStyles.None;
		DF104731.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DF104731.ForeColor = System.Drawing.Color.Black;
		DF104731.Location = new System.Drawing.Point(93, 9);
		DF104731.Name = "txtServiceURLXProxy";
		DF104731.Size = new System.Drawing.Size(327, 23);
		DF104731.TabIndex = 81;
		tabObcProxy.Controls.Add(plObcProxy);
		tabObcProxy.Location = new System.Drawing.Point(4, 4);
		tabObcProxy.Name = "tabObcProxy";
		tabObcProxy.Padding = new System.Windows.Forms.Padding(3);
		tabObcProxy.Size = new System.Drawing.Size(432, 177);
		tabObcProxy.TabIndex = 3;
		tabObcProxy.Text = "OBC";
		tabObcProxy.UseVisualStyleBackColor = true;
		plObcProxy.Controls.Add(BAAFBA3D);
		plObcProxy.Controls.Add(label54);
		plObcProxy.Controls.Add(rbObcSock5Proxy);
		plObcProxy.Controls.Add(EF35891C);
		plObcProxy.Controls.Add(label55);
		plObcProxy.Controls.Add(ED07F537);
		plObcProxy.Controls.Add(label67);
		plObcProxy.Controls.Add(label69);
		plObcProxy.Controls.Add(DE3AA0A2);
		plObcProxy.Controls.Add(label71);
		plObcProxy.Controls.Add(txtLinkWebObcProxy);
		plObcProxy.Dock = System.Windows.Forms.DockStyle.Fill;
		plObcProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		plObcProxy.Location = new System.Drawing.Point(3, 3);
		plObcProxy.Name = "plObcProxy";
		plObcProxy.Size = new System.Drawing.Size(426, 171);
		plObcProxy.TabIndex = 142;
		BAAFBA3D.Anchor = System.Windows.Forms.AnchorStyles.None;
		BAAFBA3D.Cursor = System.Windows.Forms.Cursors.Hand;
		BAAFBA3D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		BAAFBA3D.DropDownWidth = 150;
		BAAFBA3D.FormattingEnabled = true;
		BAAFBA3D.Items.AddRange(new object[2] { "Reset từng IP", "Reset cả dải IP" });
		BAAFBA3D.Location = new System.Drawing.Point(336, 136);
		BAAFBA3D.Name = "cbbTypeRunObcProxy";
		BAAFBA3D.Size = new System.Drawing.Size(84, 24);
		BAAFBA3D.TabIndex = 157;
		label54.Anchor = System.Windows.Forms.AnchorStyles.None;
		label54.AutoSize = true;
		label54.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label54.Location = new System.Drawing.Point(244, 139);
		label54.Name = "label54";
		label54.Size = new System.Drawing.Size(82, 16);
		label54.TabIndex = 155;
		label54.Text = "Chế độ chạy:";
		rbObcSock5Proxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		rbObcSock5Proxy.AutoSize = true;
		rbObcSock5Proxy.Cursor = System.Windows.Forms.Cursors.Hand;
		rbObcSock5Proxy.Enabled = false;
		rbObcSock5Proxy.Location = new System.Drawing.Point(156, 37);
		rbObcSock5Proxy.Name = "rbObcSock5Proxy";
		rbObcSock5Proxy.Size = new System.Drawing.Size(59, 20);
		rbObcSock5Proxy.TabIndex = 154;
		rbObcSock5Proxy.Text = "Sock5";
		rbObcSock5Proxy.UseVisualStyleBackColor = true;
		EF35891C.Anchor = System.Windows.Forms.AnchorStyles.None;
		EF35891C.AutoSize = true;
		EF35891C.Checked = true;
		EF35891C.Cursor = System.Windows.Forms.Cursors.Hand;
		EF35891C.Location = new System.Drawing.Point(93, 37);
		EF35891C.Name = "rbObcHttpProxy";
		EF35891C.Size = new System.Drawing.Size(48, 20);
		EF35891C.TabIndex = 155;
		EF35891C.TabStop = true;
		EF35891C.Text = "Http";
		EF35891C.UseVisualStyleBackColor = true;
		label55.Anchor = System.Windows.Forms.AnchorStyles.None;
		label55.AutoSize = true;
		label55.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label55.Location = new System.Drawing.Point(6, 37);
		label55.Name = "label55";
		label55.Size = new System.Drawing.Size(70, 16);
		label55.TabIndex = 153;
		label55.Text = "Loại Proxy:";
		ED07F537.Anchor = System.Windows.Forms.AnchorStyles.None;
		ED07F537.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		ED07F537.Location = new System.Drawing.Point(9, 77);
		ED07F537.Name = "txtListObcProxy";
		ED07F537.Size = new System.Drawing.Size(229, 81);
		ED07F537.TabIndex = 144;
		ED07F537.Text = "";
		ED07F537.WordWrap = false;
		ED07F537.TextChanged += new System.EventHandler(C22BEBAD);
		label67.Anchor = System.Windows.Forms.AnchorStyles.None;
		label67.AutoSize = true;
		label67.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label67.Location = new System.Drawing.Point(6, 58);
		label67.Name = "label67";
		label67.Size = new System.Drawing.Size(97, 16);
		label67.TabIndex = 79;
		label67.Text = "Nhập Proxy (0):";
		label69.Anchor = System.Windows.Forms.AnchorStyles.None;
		label69.AutoSize = true;
		label69.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label69.Location = new System.Drawing.Point(246, 108);
		label69.Name = "label69";
		label69.Size = new System.Drawing.Size(78, 16);
		label69.TabIndex = 139;
		label69.Text = "Số luồng/IP:";
		DE3AA0A2.Anchor = System.Windows.Forms.AnchorStyles.None;
		DE3AA0A2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DE3AA0A2.Location = new System.Drawing.Point(336, 107);
		DE3AA0A2.Name = "nudLuongPerIPObcProxy";
		DE3AA0A2.Size = new System.Drawing.Size(84, 23);
		DE3AA0A2.TabIndex = 140;
		DE3AA0A2.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		label71.Anchor = System.Windows.Forms.AnchorStyles.None;
		label71.AutoSize = true;
		label71.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label71.Location = new System.Drawing.Point(6, 15);
		label71.Name = "label71";
		label71.Size = new System.Drawing.Size(64, 16);
		label71.TabIndex = 79;
		label71.Text = "Link Web:";
		txtLinkWebObcProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		txtLinkWebObcProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		txtLinkWebObcProxy.ForeColor = System.Drawing.Color.Black;
		txtLinkWebObcProxy.Location = new System.Drawing.Point(93, 12);
		txtLinkWebObcProxy.Name = "txtLinkWebObcProxy";
		txtLinkWebObcProxy.Size = new System.Drawing.Size(326, 23);
		txtLinkWebObcProxy.TabIndex = 81;
		tabMinProxy.Controls.Add(panel5);
		tabMinProxy.Location = new System.Drawing.Point(4, 4);
		tabMinProxy.Name = "tabMinProxy";
		tabMinProxy.Padding = new System.Windows.Forms.Padding(3);
		tabMinProxy.Size = new System.Drawing.Size(432, 177);
		tabMinProxy.TabIndex = 8;
		tabMinProxy.Text = "minproxy";
		tabMinProxy.UseVisualStyleBackColor = true;
		panel5.Controls.Add(B08E0132);
		panel5.Controls.Add(rbProxyDong);
		panel5.Controls.Add(D389003F);
		panel5.Controls.Add(txtApiKeyMinProxy);
		panel5.Controls.Add(E016E38C);
		panel5.Controls.Add(label50);
		panel5.Controls.Add(plTypeProxy);
		panel5.Controls.Add(nudLuongPerIPMinProxy);
		panel5.Dock = System.Windows.Forms.DockStyle.Fill;
		panel5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		panel5.Location = new System.Drawing.Point(3, 3);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(426, 171);
		panel5.TabIndex = 153;
		B08E0132.Anchor = System.Windows.Forms.AnchorStyles.None;
		B08E0132.AutoSize = true;
		B08E0132.Cursor = System.Windows.Forms.Cursors.Hand;
		B08E0132.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B08E0132.Location = new System.Drawing.Point(211, 8);
		B08E0132.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		B08E0132.Name = "rbProxyDanCu";
		B08E0132.Size = new System.Drawing.Size(99, 20);
		B08E0132.TabIndex = 154;
		B08E0132.Text = "Proxy dân cư";
		B08E0132.UseVisualStyleBackColor = true;
		B08E0132.CheckedChanged += new System.EventHandler(B08E0132_CheckedChanged);
		rbProxyDong.Anchor = System.Windows.Forms.AnchorStyles.None;
		rbProxyDong.AutoSize = true;
		rbProxyDong.Checked = true;
		rbProxyDong.Cursor = System.Windows.Forms.Cursors.Hand;
		rbProxyDong.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		rbProxyDong.Location = new System.Drawing.Point(92, 8);
		rbProxyDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		rbProxyDong.Name = "rbProxyDong";
		rbProxyDong.Size = new System.Drawing.Size(107, 20);
		rbProxyDong.TabIndex = 153;
		rbProxyDong.TabStop = true;
		rbProxyDong.Text = "Proxy V6 động";
		rbProxyDong.UseVisualStyleBackColor = true;
		D389003F.Anchor = System.Windows.Forms.AnchorStyles.None;
		D389003F.Cursor = System.Windows.Forms.Cursors.Hand;
		D389003F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		D389003F.ForeColor = System.Drawing.Color.Black;
		D389003F.Location = new System.Drawing.Point(310, 136);
		D389003F.Name = "button10";
		D389003F.Size = new System.Drawing.Size(52, 27);
		D389003F.TabIndex = 145;
		D389003F.Text = "Check";
		D389003F.UseVisualStyleBackColor = true;
		D389003F.Click += new System.EventHandler(E78406AF);
		txtApiKeyMinProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		txtApiKeyMinProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiKeyMinProxy.Location = new System.Drawing.Point(92, 59);
		txtApiKeyMinProxy.Name = "txtApiKeyMinProxy";
		txtApiKeyMinProxy.Size = new System.Drawing.Size(270, 76);
		txtApiKeyMinProxy.TabIndex = 144;
		txtApiKeyMinProxy.Text = "";
		txtApiKeyMinProxy.WordWrap = false;
		txtApiKeyMinProxy.TextChanged += new System.EventHandler(A52DC38E);
		E016E38C.Anchor = System.Windows.Forms.AnchorStyles.None;
		E016E38C.AutoSize = true;
		E016E38C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		E016E38C.Location = new System.Drawing.Point(89, 35);
		E016E38C.Name = "label49";
		E016E38C.Size = new System.Drawing.Size(110, 16);
		E016E38C.TabIndex = 79;
		E016E38C.Text = "Nhập API KEY (0):";
		label50.Anchor = System.Windows.Forms.AnchorStyles.None;
		label50.AutoSize = true;
		label50.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label50.Location = new System.Drawing.Point(89, 141);
		label50.Name = "label50";
		label50.Size = new System.Drawing.Size(78, 16);
		label50.TabIndex = 139;
		label50.Text = "Số luồng/IP:";
		plTypeProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		plTypeProxy.Controls.Add(B92ECB82);
		plTypeProxy.Controls.Add(label21);
		plTypeProxy.Location = new System.Drawing.Point(202, 32);
		plTypeProxy.Name = "plTypeProxy";
		plTypeProxy.Size = new System.Drawing.Size(164, 25);
		plTypeProxy.TabIndex = 146;
		B92ECB82.Anchor = System.Windows.Forms.AnchorStyles.None;
		B92ECB82.Cursor = System.Windows.Forms.Cursors.Hand;
		B92ECB82.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		B92ECB82.DropDownWidth = 150;
		B92ECB82.FormattingEnabled = true;
		B92ECB82.Items.AddRange(new object[4] { "Http Ipv4", "Http Ipv6", "Sock Ipv4", "Sock Ipv6" });
		B92ECB82.Location = new System.Drawing.Point(75, 1);
		B92ECB82.Name = "cbbTypeProxyMin";
		B92ECB82.Size = new System.Drawing.Size(84, 24);
		B92ECB82.TabIndex = 160;
		label21.Anchor = System.Windows.Forms.AnchorStyles.None;
		label21.AutoSize = true;
		label21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label21.Location = new System.Drawing.Point(2, 4);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(70, 16);
		label21.TabIndex = 159;
		label21.Text = "Loại Proxy:";
		nudLuongPerIPMinProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		nudLuongPerIPMinProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudLuongPerIPMinProxy.Location = new System.Drawing.Point(174, 139);
		nudLuongPerIPMinProxy.Name = "nudLuongPerIPMinProxy";
		nudLuongPerIPMinProxy.Size = new System.Drawing.Size(67, 23);
		nudLuongPerIPMinProxy.TabIndex = 140;
		nudLuongPerIPMinProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		tabProxyWeb.Controls.Add(C3AF698D);
		tabProxyWeb.Controls.Add(lblApiKeyProxy);
		tabProxyWeb.Controls.Add(label65);
		tabProxyWeb.Controls.Add(nudLuongPerIP);
		tabProxyWeb.Location = new System.Drawing.Point(4, 4);
		tabProxyWeb.Name = "tabProxyWeb";
		tabProxyWeb.Padding = new System.Windows.Forms.Padding(3);
		tabProxyWeb.Size = new System.Drawing.Size(432, 177);
		tabProxyWeb.TabIndex = 14;
		tabProxyWeb.Text = "tabProxyWeb";
		tabProxyWeb.UseVisualStyleBackColor = true;
		C3AF698D.Anchor = System.Windows.Forms.AnchorStyles.None;
		C3AF698D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C3AF698D.Location = new System.Drawing.Point(63, 34);
		C3AF698D.Name = "txtApiKeyProxy";
		C3AF698D.Size = new System.Drawing.Size(310, 101);
		C3AF698D.TabIndex = 166;
		C3AF698D.Text = "";
		C3AF698D.WordWrap = false;
		C3AF698D.TextChanged += new System.EventHandler(C3AF698D_TextChanged);
		lblApiKeyProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
		lblApiKeyProxy.AutoSize = true;
		lblApiKeyProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		lblApiKeyProxy.Location = new System.Drawing.Point(60, 13);
		lblApiKeyProxy.Name = "lblApiKeyProxy";
		lblApiKeyProxy.Size = new System.Drawing.Size(110, 16);
		lblApiKeyProxy.TabIndex = 163;
		lblApiKeyProxy.Text = "Nhập API KEY (0):";
		label65.Anchor = System.Windows.Forms.AnchorStyles.None;
		label65.AutoSize = true;
		label65.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label65.Location = new System.Drawing.Point(60, 142);
		label65.Name = "label65";
		label65.Size = new System.Drawing.Size(78, 16);
		label65.TabIndex = 164;
		label65.Text = "Số luồng/IP:";
		nudLuongPerIP.Anchor = System.Windows.Forms.AnchorStyles.None;
		nudLuongPerIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudLuongPerIP.Location = new System.Drawing.Point(142, 140);
		nudLuongPerIP.Name = "nudLuongPerIP";
		nudLuongPerIP.Size = new System.Drawing.Size(67, 23);
		nudLuongPerIP.TabIndex = 165;
		nudLuongPerIP.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		cbbChangeIP.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbChangeIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbChangeIP.FormattingEnabled = true;
		cbbChangeIP.Location = new System.Drawing.Point(167, 79);
		cbbChangeIP.Name = "cbbChangeIP";
		cbbChangeIP.Size = new System.Drawing.Size(299, 24);
		cbbChangeIP.TabIndex = 34;
		EB0A3BA4.AutoSize = true;
		EB0A3BA4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		EB0A3BA4.Location = new System.Drawing.Point(27, 82);
		EB0A3BA4.Name = "label15";
		EB0A3BA4.Size = new System.Drawing.Size(126, 16);
		EB0A3BA4.TabIndex = 139;
		EB0A3BA4.Text = "Tùy chọn Change IP:";
		label37.AutoSize = true;
		label37.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label37.Location = new System.Drawing.Point(27, 51);
		label37.Name = "label37";
		label37.Size = new System.Drawing.Size(123, 16);
		label37.TabIndex = 139;
		label37.Text = "Delay sau khi đô\u0309i IP:";
		nudDelayCheckIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudDelayCheckIP.Location = new System.Drawing.Point(167, 49);
		nudDelayCheckIP.Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		nudDelayCheckIP.Name = "nudDelayCheckIP";
		nudDelayCheckIP.Size = new System.Drawing.Size(36, 23);
		nudDelayCheckIP.TabIndex = 140;
		label38.AutoSize = true;
		label38.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label38.Location = new System.Drawing.Point(202, 51);
		label38.Name = "label38";
		label38.Size = new System.Drawing.Size(13, 16);
		label38.TabIndex = 141;
		label38.Text = "s";
		AC15EA00.Controls.Add(button5);
		AC15EA00.Controls.Add(label26);
		AC15EA00.Controls.Add(nudChangeIpCount);
		AC15EA00.Controls.Add(label27);
		AC15EA00.Location = new System.Drawing.Point(233, 46);
		AC15EA00.Name = "plCheckDoiIP";
		AC15EA00.Size = new System.Drawing.Size(237, 27);
		AC15EA00.TabIndex = 146;
		button5.Cursor = System.Windows.Forms.Cursors.Hand;
		button5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		button5.ForeColor = System.Drawing.Color.Black;
		button5.Location = new System.Drawing.Point(183, 0);
		button5.Name = "button5";
		button5.Size = new System.Drawing.Size(50, 27);
		button5.TabIndex = 143;
		button5.Text = "Test";
		button5.UseVisualStyleBackColor = true;
		button5.Click += new System.EventHandler(button5_Click);
		label26.AutoSize = true;
		label26.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label26.Location = new System.Drawing.Point(3, 5);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(100, 16);
		label26.TabIndex = 139;
		label26.Text = "Thay đổi IP sau:";
		nudChangeIpCount.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudChangeIpCount.Location = new System.Drawing.Point(104, 3);
		nudChangeIpCount.Name = "nudChangeIpCount";
		nudChangeIpCount.Size = new System.Drawing.Size(46, 23);
		nudChangeIpCount.TabIndex = 140;
		nudChangeIpCount.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		label27.AutoSize = true;
		label27.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label27.Location = new System.Drawing.Point(152, 5);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(29, 16);
		label27.TabIndex = 141;
		label27.Text = "lượt";
		ckbKhongCheckIP.AutoSize = true;
		ckbKhongCheckIP.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbKhongCheckIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbKhongCheckIP.Location = new System.Drawing.Point(30, 25);
		ckbKhongCheckIP.Name = "ckbKhongCheckIP";
		ckbKhongCheckIP.Size = new System.Drawing.Size(198, 20);
		ckbKhongCheckIP.TabIndex = 112;
		ckbKhongCheckIP.Text = "Không Check IP trước khi chạy";
		ckbKhongCheckIP.UseVisualStyleBackColor = true;
		grEmailConfigs.Controls.Add(A6264B1A);
		grEmailConfigs.Controls.Add(linkLabel3);
		grEmailConfigs.Controls.Add(A68F1C80);
		grEmailConfigs.Controls.Add(panel7);
		grEmailConfigs.Controls.Add(label58);
		grEmailConfigs.Controls.Add(panel4);
		grEmailConfigs.Controls.Add(panel6);
		grEmailConfigs.Controls.Add(A784892D);
		grEmailConfigs.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		grEmailConfigs.Location = new System.Drawing.Point(7, 270);
		grEmailConfigs.Name = "grEmailConfigs";
		grEmailConfigs.Size = new System.Drawing.Size(568, 137);
		grEmailConfigs.TabIndex = 38;
		grEmailConfigs.TabStop = false;
		grEmailConfigs.Text = "Cấu hình email";
		A6264B1A.AutoSize = true;
		A6264B1A.Location = new System.Drawing.Point(29, 98);
		A6264B1A.Name = "linkLabel4";
		A6264B1A.Size = new System.Drawing.Size(152, 16);
		A6264B1A.TabIndex = 155;
		A6264B1A.TabStop = true;
		A6264B1A.Text = "https://donglaomail.com/";
		A6264B1A.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(A68F1C80_LinkClicked);
		linkLabel3.AutoSize = true;
		linkLabel3.Location = new System.Drawing.Point(29, 61);
		linkLabel3.Name = "linkLabel3";
		linkLabel3.Size = new System.Drawing.Size(145, 16);
		linkLabel3.TabIndex = 155;
		linkLabel3.TabStop = true;
		linkLabel3.Text = "https://unlimitmail.com/";
		linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(A68F1C80_LinkClicked);
		A68F1C80.AutoSize = true;
		A68F1C80.Location = new System.Drawing.Point(29, 24);
		A68F1C80.Name = "linkLabel2";
		A68F1C80.Size = new System.Drawing.Size(146, 16);
		A68F1C80.TabIndex = 155;
		A68F1C80.TabStop = true;
		A68F1C80.Text = "https://generator.email/";
		A68F1C80.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(A68F1C80_LinkClicked);
		panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel7.Controls.Add(CD2F5EB9);
		panel7.Controls.Add(F3A4F60E);
		panel7.Location = new System.Drawing.Point(187, 56);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(375, 31);
		panel7.TabIndex = 154;
		CD2F5EB9.AutoSize = true;
		CD2F5EB9.Location = new System.Drawing.Point(-1, 6);
		CD2F5EB9.Name = "label57";
		CD2F5EB9.Size = new System.Drawing.Size(76, 16);
		CD2F5EB9.TabIndex = 46;
		CD2F5EB9.Text = "Nhập token:";
		F3A4F60E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F3A4F60E.Location = new System.Drawing.Point(86, 3);
		F3A4F60E.Name = "txtTokenUnlimitMail";
		F3A4F60E.Size = new System.Drawing.Size(284, 23);
		F3A4F60E.TabIndex = 47;
		label58.AutoSize = true;
		label58.Location = new System.Drawing.Point(29, 161);
		label58.Name = "label58";
		label58.Size = new System.Drawing.Size(55, 16);
		label58.TabIndex = 46;
		label58.Text = "Hotmail:";
		panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel4.Controls.Add(F6214BB1);
		panel4.Location = new System.Drawing.Point(187, 156);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(375, 31);
		panel4.TabIndex = 152;
		F6214BB1.AutoSize = true;
		F6214BB1.Cursor = System.Windows.Forms.Cursors.Hand;
		F6214BB1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F6214BB1.Location = new System.Drawing.Point(2, 5);
		F6214BB1.Name = "ckbGetOtpHotmailChrome";
		F6214BB1.Size = new System.Drawing.Size(310, 20);
		F6214BB1.TabIndex = 157;
		F6214BB1.Text = "Mở chrome để lấy otp nếu không thể kết nối Imap";
		F6214BB1.UseVisualStyleBackColor = true;
		panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel6.Controls.Add(label59);
		panel6.Controls.Add(E298F032);
		panel6.Location = new System.Drawing.Point(187, 19);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(375, 31);
		panel6.TabIndex = 152;
		label59.AutoSize = true;
		label59.Location = new System.Drawing.Point(-1, 6);
		label59.Name = "label59";
		label59.Size = new System.Drawing.Size(87, 16);
		label59.TabIndex = 46;
		label59.Text = "Nhập domain:";
		E298F032.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E298F032.Cursor = System.Windows.Forms.Cursors.Hand;
		E298F032.Location = new System.Drawing.Point(86, 2);
		E298F032.Name = "button6";
		E298F032.Size = new System.Drawing.Size(285, 25);
		E298F032.TabIndex = 35;
		E298F032.Text = "Nhập";
		E298F032.UseVisualStyleBackColor = true;
		E298F032.Click += new System.EventHandler(E298F032_Click);
		A784892D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A784892D.Controls.Add(B622823D);
		A784892D.Controls.Add(txtTokenDonglaomail);
		A784892D.Location = new System.Drawing.Point(187, 93);
		A784892D.Name = "plGetCode2FA";
		A784892D.Size = new System.Drawing.Size(375, 31);
		A784892D.TabIndex = 152;
		B622823D.AutoSize = true;
		B622823D.Location = new System.Drawing.Point(-1, 6);
		B622823D.Name = "label52";
		B622823D.Size = new System.Drawing.Size(76, 16);
		B622823D.TabIndex = 46;
		B622823D.Text = "Nhập token:";
		txtTokenDonglaomail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTokenDonglaomail.Location = new System.Drawing.Point(86, 3);
		txtTokenDonglaomail.Name = "txtTokenDonglaomail";
		txtTokenDonglaomail.Size = new System.Drawing.Size(284, 23);
		txtTokenDonglaomail.TabIndex = 47;
		txtMysqlServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtMysqlServer.Location = new System.Drawing.Point(194, 379);
		txtMysqlServer.Name = "txtMysqlServer";
		txtMysqlServer.Size = new System.Drawing.Size(375, 23);
		txtMysqlServer.TabIndex = 47;
		grCauHinhKhac.Controls.Add(D63D63A3);
		grCauHinhKhac.Controls.Add(ckbBackupDB);
		grCauHinhKhac.Controls.Add(EA12298A);
		grCauHinhKhac.Controls.Add(cbbTypePhanBietMau);
		grCauHinhKhac.Controls.Add(D804F51B);
		grCauHinhKhac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		grCauHinhKhac.Location = new System.Drawing.Point(580, 332);
		grCauHinhKhac.Name = "grCauHinhKhac";
		grCauHinhKhac.Size = new System.Drawing.Size(470, 75);
		grCauHinhKhac.TabIndex = 38;
		grCauHinhKhac.TabStop = false;
		grCauHinhKhac.Text = "Cấu hình khác";
		D63D63A3.AutoSize = true;
		D63D63A3.Location = new System.Drawing.Point(351, 50);
		D63D63A3.Name = "lblSelectBackupDB";
		D63D63A3.Size = new System.Drawing.Size(42, 16);
		D63D63A3.TabIndex = 153;
		D63D63A3.TabStop = true;
		D63D63A3.Text = "Select";
		D63D63A3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(D63D63A3_LinkClicked);
		ckbBackupDB.AutoSize = true;
		ckbBackupDB.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBackupDB.Location = new System.Drawing.Point(229, 49);
		ckbBackupDB.Name = "ckbBackupDB";
		ckbBackupDB.Size = new System.Drawing.Size(127, 20);
		ckbBackupDB.TabIndex = 152;
		ckbBackupDB.Text = "Backup Database ";
		ckbBackupDB.UseVisualStyleBackColor = true;
		ckbBackupDB.CheckedChanged += new System.EventHandler(ckbBackupDB_CheckedChanged);
		EA12298A.AutoSize = true;
		EA12298A.Cursor = System.Windows.Forms.Cursors.Hand;
		EA12298A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EA12298A.Location = new System.Drawing.Point(32, 49);
		EA12298A.Name = "ckbLuuTrangThai";
		EA12298A.Size = new System.Drawing.Size(184, 20);
		EA12298A.TabIndex = 157;
		EA12298A.Text = "Lưu dư\u0303 liê\u0323u cô\u0323t [Tra\u0323ng tha\u0301i]";
		EA12298A.UseVisualStyleBackColor = true;
		cbbTypePhanBietMau.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypePhanBietMau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypePhanBietMau.FormattingEnabled = true;
		cbbTypePhanBietMau.Location = new System.Drawing.Point(229, 19);
		cbbTypePhanBietMau.Name = "cbbTypePhanBietMau";
		cbbTypePhanBietMau.Size = new System.Drawing.Size(161, 24);
		cbbTypePhanBietMau.TabIndex = 34;
		D804F51B.AutoSize = true;
		D804F51B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D804F51B.Location = new System.Drawing.Point(29, 22);
		D804F51B.Name = "label23";
		D804F51B.Size = new System.Drawing.Size(194, 16);
		D804F51B.TabIndex = 33;
		D804F51B.Text = "Phân biệt [Tình trạng tài khoản]:";
		DBA562BA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DBA562BA.Controls.Add(A1013881);
		DBA562BA.Controls.Add(CE2E6104);
		DBA562BA.Controls.Add(C897B6B7);
		DBA562BA.Controls.Add(label40);
		DBA562BA.Controls.Add(C2147C1F);
		DBA562BA.Controls.Add(label42);
		DBA562BA.Controls.Add(FA1228A6);
		DBA562BA.Controls.Add(label46);
		DBA562BA.Controls.Add(B4A292BB);
		DBA562BA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		DBA562BA.Location = new System.Drawing.Point(11, 909);
		DBA562BA.Name = "plVitech";
		DBA562BA.Size = new System.Drawing.Size(266, 170);
		DBA562BA.TabIndex = 151;
		DBA562BA.Visible = false;
		A1013881.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A1013881.Location = new System.Drawing.Point(6, 71);
		A1013881.Name = "txtListProxyVitech";
		A1013881.Size = new System.Drawing.Size(255, 68);
		A1013881.TabIndex = 144;
		A1013881.Text = "";
		A1013881.WordWrap = false;
		A1013881.TextChanged += new System.EventHandler(E6B97A19);
		CE2E6104.AutoSize = true;
		CE2E6104.Cursor = System.Windows.Forms.Cursors.Hand;
		CE2E6104.Enabled = false;
		CE2E6104.Location = new System.Drawing.Point(137, 28);
		CE2E6104.Name = "radioButton9";
		CE2E6104.Size = new System.Drawing.Size(59, 20);
		CE2E6104.TabIndex = 82;
		CE2E6104.Text = "Sock5";
		CE2E6104.UseVisualStyleBackColor = true;
		C897B6B7.AutoSize = true;
		C897B6B7.Checked = true;
		C897B6B7.Cursor = System.Windows.Forms.Cursors.Hand;
		C897B6B7.Location = new System.Drawing.Point(74, 28);
		C897B6B7.Name = "radioButton10";
		C897B6B7.Size = new System.Drawing.Size(48, 20);
		C897B6B7.TabIndex = 82;
		C897B6B7.TabStop = true;
		C897B6B7.Text = "Http";
		C897B6B7.UseVisualStyleBackColor = true;
		label40.AutoSize = true;
		label40.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label40.Location = new System.Drawing.Point(3, 28);
		label40.Name = "label40";
		label40.Size = new System.Drawing.Size(70, 16);
		label40.TabIndex = 79;
		label40.Text = "Loại Proxy:";
		C2147C1F.AutoSize = true;
		C2147C1F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		C2147C1F.Location = new System.Drawing.Point(3, 50);
		C2147C1F.Name = "label41";
		C2147C1F.Size = new System.Drawing.Size(97, 16);
		C2147C1F.TabIndex = 79;
		C2147C1F.Text = "Nhập Proxy (0):";
		label42.AutoSize = true;
		label42.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label42.Location = new System.Drawing.Point(5, 143);
		label42.Name = "label42";
		label42.Size = new System.Drawing.Size(78, 16);
		label42.TabIndex = 139;
		label42.Text = "Số luồng/IP:";
		FA1228A6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		FA1228A6.Location = new System.Drawing.Point(90, 142);
		FA1228A6.Name = "nudLuongPerIPVitech";
		FA1228A6.Size = new System.Drawing.Size(67, 23);
		FA1228A6.TabIndex = 140;
		FA1228A6.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		label46.AutoSize = true;
		label46.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label46.Location = new System.Drawing.Point(3, 5);
		label46.Name = "label46";
		label46.Size = new System.Drawing.Size(55, 16);
		label46.TabIndex = 79;
		label46.Text = "API Key:";
		B4A292BB.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B4A292BB.ForeColor = System.Drawing.Color.Black;
		B4A292BB.Location = new System.Drawing.Point(74, 2);
		B4A292BB.Name = "txtApiVitech";
		B4A292BB.Size = new System.Drawing.Size(187, 23);
		B4A292BB.TabIndex = 81;
		cbbHostpot.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbHostpot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbHostpot.Enabled = false;
		cbbHostpot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		cbbHostpot.ForeColor = System.Drawing.Color.Black;
		cbbHostpot.FormattingEnabled = true;
		cbbHostpot.Items.AddRange(new object[2] { "Chi\u0309 trong quô\u0301c gia đang cho\u0323n", "Toa\u0300n bô\u0323 quô\u0301c gia" });
		cbbHostpot.Location = new System.Drawing.Point(1177, 563);
		cbbHostpot.Name = "cbbHostpot";
		cbbHostpot.Size = new System.Drawing.Size(229, 24);
		cbbHostpot.TabIndex = 144;
		ckbMysqlServer.AutoSize = true;
		ckbMysqlServer.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbMysqlServer.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ckbMysqlServer.Location = new System.Drawing.Point(37, 381);
		ckbMysqlServer.Name = "ckbMysqlServer";
		ckbMysqlServer.Size = new System.Drawing.Size(110, 20);
		ckbMysqlServer.TabIndex = 112;
		ckbMysqlServer.Text = "MySQL server:";
		ckbMysqlServer.UseVisualStyleBackColor = true;
		ckbMysqlServer.CheckedChanged += new System.EventHandler(FAAE981E);
		rbVitech.AutoSize = true;
		rbVitech.Cursor = System.Windows.Forms.Cursors.Hand;
		rbVitech.Enabled = false;
		rbVitech.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		rbVitech.Location = new System.Drawing.Point(11, 885);
		rbVitech.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		rbVitech.Name = "rbVitech";
		rbVitech.Size = new System.Drawing.Size(145, 20);
		rbVitech.TabIndex = 150;
		rbVitech.Text = "VitechCheap(Sắp có)";
		rbVitech.UseVisualStyleBackColor = true;
		rbVitech.Visible = false;
		A6A9722C.BackColor = System.Drawing.Color.White;
		A6A9722C.BorderRadius = 0;
		A6A9722C.BottomSahddow = true;
		A6A9722C.color = System.Drawing.Color.SaddleBrown;
		A6A9722C.Controls.Add(pnlHeader);
		A6A9722C.Dock = System.Windows.Forms.DockStyle.Top;
		A6A9722C.LeftSahddow = false;
		A6A9722C.Location = new System.Drawing.Point(0, 0);
		A6A9722C.Name = "bunifuCards2";
		A6A9722C.RightSahddow = true;
		A6A9722C.ShadowDepth = 20;
		A6A9722C.Size = new System.Drawing.Size(1057, 37);
		A6A9722C.TabIndex = 40;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button2);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(FE379922);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1057, 31);
		pnlHeader.TabIndex = 9;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
		button2.Location = new System.Drawing.Point(1026, 1);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(30, 30);
		button2.TabIndex = 77;
		button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(F5BBF938_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		FE379922.BackColor = System.Drawing.Color.Transparent;
		FE379922.Cursor = System.Windows.Forms.Cursors.SizeAll;
		FE379922.Dock = System.Windows.Forms.DockStyle.Fill;
		FE379922.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FE379922.ForeColor = System.Drawing.Color.Black;
		FE379922.Location = new System.Drawing.Point(0, 0);
		FE379922.Name = "bunifuCustomLabel1";
		FE379922.Size = new System.Drawing.Size(1057, 31);
		FE379922.TabIndex = 12;
		FE379922.Text = "Câ\u0301u hi\u0300nh chung";
		FE379922.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F5BBF938.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F5BBF938.BackColor = System.Drawing.Color.Maroon;
		F5BBF938.Cursor = System.Windows.Forms.Cursors.Hand;
		F5BBF938.FlatAppearance.BorderSize = 0;
		F5BBF938.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F5BBF938.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F5BBF938.ForeColor = System.Drawing.Color.White;
		F5BBF938.Location = new System.Drawing.Point(580, 421);
		F5BBF938.Name = "btnCancel";
		F5BBF938.Size = new System.Drawing.Size(92, 29);
		F5BBF938.TabIndex = 20;
		F5BBF938.Text = "Đóng";
		F5BBF938.UseVisualStyleBackColor = false;
		F5BBF938.Click += new System.EventHandler(F5BBF938_Click);
		BD1A8989.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		BD1A8989.Controls.Add(label12);
		BD1A8989.Controls.Add(F130372E);
		BD1A8989.Enabled = false;
		BD1A8989.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		BD1A8989.Location = new System.Drawing.Point(1176, 475);
		BD1A8989.Name = "panel2";
		BD1A8989.Size = new System.Drawing.Size(232, 30);
		BD1A8989.TabIndex = 142;
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label12.Location = new System.Drawing.Point(3, 5);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(75, 16);
		label12.TabIndex = 82;
		label12.Text = "Đường dẫn:";
		F130372E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F130372E.ForeColor = System.Drawing.Color.Black;
		F130372E.Location = new System.Drawing.Point(87, 2);
		F130372E.Name = "textBox1";
		F130372E.Size = new System.Drawing.Size(142, 23);
		F130372E.TabIndex = 83;
		FB88FF8C.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		FB88FF8C.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		FB88FF8C.Cursor = System.Windows.Forms.Cursors.Hand;
		FB88FF8C.FlatAppearance.BorderSize = 0;
		FB88FF8C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		FB88FF8C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FB88FF8C.ForeColor = System.Drawing.Color.White;
		FB88FF8C.Location = new System.Drawing.Point(483, 421);
		FB88FF8C.Name = "btnSave";
		FB88FF8C.Size = new System.Drawing.Size(92, 29);
		FB88FF8C.TabIndex = 19;
		FB88FF8C.Text = "Lưu";
		FB88FF8C.UseVisualStyleBackColor = false;
		FB88FF8C.Click += new System.EventHandler(C80031A9);
		plNordVPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plNordVPN.Controls.Add(B6AABC28);
		plNordVPN.Controls.Add(E301229B);
		plNordVPN.Enabled = false;
		plNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		plNordVPN.Location = new System.Drawing.Point(1176, 475);
		plNordVPN.Name = "plNordVPN";
		plNordVPN.Size = new System.Drawing.Size(232, 30);
		plNordVPN.TabIndex = 142;
		B6AABC28.AutoSize = true;
		B6AABC28.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B6AABC28.Location = new System.Drawing.Point(3, 5);
		B6AABC28.Name = "label14";
		B6AABC28.Size = new System.Drawing.Size(75, 16);
		B6AABC28.TabIndex = 82;
		B6AABC28.Text = "Đường dẫn:";
		E301229B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		E301229B.ForeColor = System.Drawing.Color.Black;
		E301229B.Location = new System.Drawing.Point(87, 2);
		E301229B.Name = "txtNordVPN";
		E301229B.Size = new System.Drawing.Size(142, 23);
		E301229B.TabIndex = 83;
		E72E4C82.Cursor = System.Windows.Forms.Cursors.Hand;
		E72E4C82.Enabled = false;
		E72E4C82.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		E72E4C82.ForeColor = System.Drawing.Color.Black;
		E72E4C82.Location = new System.Drawing.Point(1263, 508);
		E72E4C82.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		E72E4C82.Name = "btnSSH";
		E72E4C82.Size = new System.Drawing.Size(106, 26);
		E72E4C82.TabIndex = 130;
		E72E4C82.Text = "Nhập IP SSH";
		E72E4C82.UseVisualStyleBackColor = true;
		E72E4C82.Click += new System.EventHandler(E5AC459D);
		radioButton4.AutoSize = true;
		radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton4.Enabled = false;
		radioButton4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		radioButton4.Location = new System.Drawing.Point(1162, 426);
		radioButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		radioButton4.Name = "radioButton4";
		radioButton4.Size = new System.Drawing.Size(130, 20);
		radioButton4.TabIndex = 133;
		radioButton4.Text = "Đổi IP ExpressVPN";
		radioButton4.UseVisualStyleBackColor = true;
		rbHotspot.AutoSize = true;
		rbHotspot.Enabled = false;
		rbHotspot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		rbHotspot.Location = new System.Drawing.Point(1162, 539);
		rbHotspot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		rbHotspot.Name = "rbHotspot";
		rbHotspot.Size = new System.Drawing.Size(145, 20);
		rbHotspot.TabIndex = 135;
		rbHotspot.Text = "Đổi IP Hotspot Shield";
		rbHotspot.UseVisualStyleBackColor = true;
		radioButton5.AutoSize = true;
		radioButton5.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton5.Enabled = false;
		radioButton5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		radioButton5.Location = new System.Drawing.Point(1162, 511);
		radioButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		radioButton5.Name = "radioButton5";
		radioButton5.Size = new System.Drawing.Size(87, 20);
		radioButton5.TabIndex = 132;
		radioButton5.Text = "Đổi IP SSH";
		radioButton5.UseVisualStyleBackColor = true;
		rbNordVPN.AutoSize = true;
		rbNordVPN.Enabled = false;
		rbNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		rbNordVPN.Location = new System.Drawing.Point(1162, 451);
		rbNordVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		rbNordVPN.Name = "rbNordVPN";
		rbNordVPN.Size = new System.Drawing.Size(113, 20);
		rbNordVPN.TabIndex = 134;
		rbNordVPN.Text = "Đổi IP NordVPN";
		rbNordVPN.UseVisualStyleBackColor = true;
		rbNordVPN.CheckedChanged += new System.EventHandler(radioButton3_CheckedChanged);
		A81ECE2B.AutoSize = true;
		A81ECE2B.Cursor = System.Windows.Forms.Cursors.Hand;
		A81ECE2B.Enabled = false;
		A81ECE2B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		A81ECE2B.Location = new System.Drawing.Point(1162, 539);
		A81ECE2B.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		A81ECE2B.Name = "radioButton2";
		A81ECE2B.Size = new System.Drawing.Size(145, 20);
		A81ECE2B.TabIndex = 135;
		A81ECE2B.Text = "Đổi IP Hotspot Shield";
		A81ECE2B.UseVisualStyleBackColor = true;
		rbSSH.AutoSize = true;
		rbSSH.Enabled = false;
		rbSSH.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		rbSSH.Location = new System.Drawing.Point(1162, 511);
		rbSSH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		rbSSH.Name = "rbSSH";
		rbSSH.Size = new System.Drawing.Size(87, 20);
		rbSSH.TabIndex = 132;
		rbSSH.Text = "Đổi IP SSH";
		rbSSH.UseVisualStyleBackColor = true;
		radioButton3.AutoSize = true;
		radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton3.Enabled = false;
		radioButton3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		radioButton3.Location = new System.Drawing.Point(1162, 451);
		radioButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		radioButton3.Name = "radioButton3";
		radioButton3.Size = new System.Drawing.Size(113, 20);
		radioButton3.TabIndex = 134;
		radioButton3.Text = "Đổi IP NordVPN";
		radioButton3.UseVisualStyleBackColor = true;
		radioButton3.CheckedChanged += new System.EventHandler(radioButton3_CheckedChanged);
		rbExpressVPN.AutoSize = true;
		rbExpressVPN.Enabled = false;
		rbExpressVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		rbExpressVPN.Location = new System.Drawing.Point(1162, 426);
		rbExpressVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		rbExpressVPN.Name = "rbExpressVPN";
		rbExpressVPN.Size = new System.Drawing.Size(130, 20);
		rbExpressVPN.TabIndex = 133;
		rbExpressVPN.Text = "Đổi IP ExpressVPN";
		rbExpressVPN.UseVisualStyleBackColor = true;
		DCB0E58D.Fixed = true;
		DCB0E58D.Horizontal = true;
		DCB0E58D.TargetControl = FE379922;
		DCB0E58D.Vertical = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1059, 464);
		base.Controls.Add(F90EBB3D);
		base.Controls.Add(F312A539);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhChung";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình chung";
		base.Load += new System.EventHandler(D11BC311);
		((System.ComponentModel.ISupportInitialize)F0B340B0).EndInit();
		((System.ComponentModel.ISupportInitialize)D18BDD07).EndInit();
		F90EBB3D.ResumeLayout(false);
		F90EBB3D.PerformLayout();
		D1AA09A1.ResumeLayout(false);
		D1AA09A1.PerformLayout();
		D08C5593.ResumeLayout(false);
		D08C5593.PerformLayout();
		grCauHinhChrome.ResumeLayout(false);
		grCauHinhChrome.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeTo).EndInit();
		plGemLogin.ResumeLayout(false);
		plGemLogin.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayOpenChromeFrom).EndInit();
		plGpmLogin.ResumeLayout(false);
		plGpmLogin.PerformLayout();
		plSizeChrome.ResumeLayout(false);
		plSizeChrome.PerformLayout();
		plDelayCloseChrome.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayCloseChromeFrom).EndInit();
		plGologin.ResumeLayout(false);
		plGologin.PerformLayout();
		plSapXepCuaSoChrome.ResumeLayout(false);
		plSapXepCuaSoChrome.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudChromeScale).EndInit();
		A592D8B4.ResumeLayout(false);
		A592D8B4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)BA8586B0).EndInit();
		((System.ComponentModel.ISupportInitialize)nudHeighChrome).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		DB13DAA8.ResumeLayout(false);
		DB13DAA8.PerformLayout();
		CDBC4A2C.ResumeLayout(false);
		CDBC4A2C.PerformLayout();
		B42ED23C.ResumeLayout(false);
		B42ED23C.PerformLayout();
		tabChangeIP.ResumeLayout(false);
		A7804FB9.ResumeLayout(false);
		tabProxy.ResumeLayout(false);
		tabProxy.PerformLayout();
		BA0EB62D.ResumeLayout(false);
		BA0EB62D.PerformLayout();
		tabDcom.ResumeLayout(false);
		plDcom.ResumeLayout(false);
		plDcom.PerformLayout();
		tabXProxy.ResumeLayout(false);
		plXproxy.ResumeLayout(false);
		plXproxy.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).EndInit();
		tabObcProxy.ResumeLayout(false);
		plObcProxy.ResumeLayout(false);
		plObcProxy.PerformLayout();
		((System.ComponentModel.ISupportInitialize)DE3AA0A2).EndInit();
		tabMinProxy.ResumeLayout(false);
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		plTypeProxy.ResumeLayout(false);
		plTypeProxy.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudLuongPerIPMinProxy).EndInit();
		tabProxyWeb.ResumeLayout(false);
		tabProxyWeb.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudLuongPerIP).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayCheckIP).EndInit();
		AC15EA00.ResumeLayout(false);
		AC15EA00.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudChangeIpCount).EndInit();
		grEmailConfigs.ResumeLayout(false);
		grEmailConfigs.PerformLayout();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		A784892D.ResumeLayout(false);
		A784892D.PerformLayout();
		grCauHinhKhac.ResumeLayout(false);
		grCauHinhKhac.PerformLayout();
		DBA562BA.ResumeLayout(false);
		DBA562BA.PerformLayout();
		((System.ComponentModel.ISupportInitialize)FA1228A6).EndInit();
		A6A9722C.ResumeLayout(false);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		BD1A8989.ResumeLayout(false);
		BD1A8989.PerformLayout();
		plNordVPN.ResumeLayout(false);
		plNordVPN.PerformLayout();
		ResumeLayout(false);
	}
}
