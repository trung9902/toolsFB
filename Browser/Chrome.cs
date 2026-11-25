using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class Chrome
{
    public bool PreserveSession { get; set; }
    public bool ManualSessionLogin { get; set; }
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct B63F06A4
	{
		internal bool bool_0;

		internal Chrome A61E8287;

		internal bool bool_1;

		internal int int_0;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct Struct1
	{
		internal string string_0;
	}

	internal int D1154987;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Process process_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal Process process_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ChromeDriver D40B6F94;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool FA2F8F9F;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool D7BCDFAB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool C7BDADBC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal bool D68F1B00;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal bool bool_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal int int_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string B53A3008;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point C9040600;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal Point point_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal bool FE0CAAB7;

	internal bool bool_1 = false;

	internal string string_1;

	internal int int_1;

	internal string string_2 = "";

	internal string D8B3A7B5 = "";

	internal string string_3 = "";

	internal string string_4 = "";

	internal string string_5 = "";

	internal string F9B9EB1F = "";

	internal string BFAF968B = "";

	internal string EB853E81 = "";

	internal string B6B71C81 = "";

	internal string string_6 = "";

	internal string DC011F35 = "";

	internal string string_7 = "";

	internal bool bool_2 = false;

	public Action<string> OnStatusUpdate = null;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal bool bool_3 = false;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool bool_4 = false;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool bool_5 = false;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string DF115529;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal int D00F6EA9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string string_8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string C0953CB5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal bool bool_6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal bool F3B1773A;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string D0021FB0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal double double_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point E983A69E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal int int_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string B586998D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal FE33ED1C FB956D0D;

	internal Class59 class59_0;

	internal bool bool_7 = false;

	internal int int_3 = -1;

	internal bool bool_8 = false;

	internal int CF366839 = 0;

	internal int DF91F13B = 0;

	internal int AA3B0EAA = 0;

	internal int FC8813AF = 0;

	internal string ED0947B5 = "";

	public Process Process_0
	{
		[CompilerGenerated]
		get
		{
			return process_0;
		}
		[CompilerGenerated]
		set
		{
			process_0 = value;
		}
	}

	public Process Process_1
	{
		[CompilerGenerated]
		get
		{
			return process_1;
		}
		[CompilerGenerated]
		set
		{
			process_1 = value;
		}
	}

	public ChromeDriver ChromeDriver_0
	{
		[CompilerGenerated]
		get
		{
			return D40B6F94;
		}
		[CompilerGenerated]
		set
		{
			D40B6F94 = value;
		}
	}

	public bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return FA2F8F9F;
		}
		[CompilerGenerated]
		set
		{
			FA2F8F9F = value;
		}
	}

	public bool Boolean_1
	{
		[CompilerGenerated]
		get
		{
			return D7BCDFAB;
		}
		[CompilerGenerated]
		set
		{
			D7BCDFAB = value;
		}
	}

	public bool Boolean_2
	{
		[CompilerGenerated]
		get
		{
			return C7BDADBC;
		}
		[CompilerGenerated]
		set
		{
			C7BDADBC = value;
		}
	}

	public bool Boolean_3
	{
		[CompilerGenerated]
		get
		{
			return D68F1B00;
		}
		[CompilerGenerated]
		set
		{
			D68F1B00 = value;
		}
	}

	public bool Boolean_4
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

	public string String_0
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int Int32_0
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public string String_1
	{
		[CompilerGenerated]
		get
		{
			return B53A3008;
		}
		[CompilerGenerated]
		set
		{
			B53A3008 = value;
		}
	}

	public Point F5BA98AC
	{
		[CompilerGenerated]
		get
		{
			return C9040600;
		}
		[CompilerGenerated]
		set
		{
			C9040600 = value;
		}
	}

	public Point Point_0
	{
		[CompilerGenerated]
		get
		{
			return point_0;
		}
		[CompilerGenerated]
		set
		{
			point_0 = value;
		}
	}

	public bool Boolean_5
	{
		[CompilerGenerated]
		get
		{
			return FE0CAAB7;
		}
		[CompilerGenerated]
		set
		{
			FE0CAAB7 = value;
		}
	}

	public string AF336B2C
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public int CF8FD901
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public string B4208531
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string C234EEAA
	{
		get
		{
			return D8B3A7B5;
		}
		set
		{
			D8B3A7B5 = value;
		}
	}

	public string A1BF36A2
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string String_2
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string F5812DA8
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string F8A3B83F
	{
		get
		{
			return F9B9EB1F;
		}
		set
		{
			F9B9EB1F = value;
		}
	}

	public string ACBD1889
	{
		get
		{
			return BFAF968B;
		}
		set
		{
			BFAF968B = value;
		}
	}

	public string A70B4E96
	{
		get
		{
			return EB853E81;
		}
		set
		{
			EB853E81 = value;
		}
	}

	public string A990D886
	{
		get
		{
			return B6B71C81;
		}
		set
		{
			B6B71C81 = value;
		}
	}

	public string C72CBD25
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string String_3
	{
		get
		{
			return DC011F35;
		}
		set
		{
			DC011F35 = value;
		}
	}

	public string F2B1E915
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public bool EE37E6A7
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool BF35E2B2
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool Boolean_6
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool DA248813
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public string A3A32284
	{
		[CompilerGenerated]
		get
		{
			return DF115529;
		}
		[CompilerGenerated]
		set
		{
			DF115529 = value;
		}
	}

	public int Int32_1
	{
		[CompilerGenerated]
		get
		{
			return D00F6EA9;
		}
		[CompilerGenerated]
		set
		{
			D00F6EA9 = value;
		}
	}

	public string DA9C9817
	{
		[CompilerGenerated]
		get
		{
			return string_8;
		}
		[CompilerGenerated]
		set
		{
			string_8 = value;
		}
	}

	public string A1277F87
	{
		[CompilerGenerated]
		get
		{
			return string_9;
		}
		[CompilerGenerated]
		set
		{
			string_9 = value;
		}
	}

	public string AC20011A
	{
		[CompilerGenerated]
		get
		{
			return C0953CB5;
		}
		[CompilerGenerated]
		set
		{
			C0953CB5 = value;
		}
	}

	public bool C63504A5
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool Boolean_7
	{
		[CompilerGenerated]
		get
		{
			return F3B1773A;
		}
		[CompilerGenerated]
		set
		{
			F3B1773A = value;
		}
	}

	public string String_4
	{
		[CompilerGenerated]
		get
		{
			return D0021FB0;
		}
		[CompilerGenerated]
		set
		{
			D0021FB0 = value;
		}
	}

	public double Double_0
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public Point Point_1
	{
		[CompilerGenerated]
		get
		{
			return E983A69E;
		}
		[CompilerGenerated]
		set
		{
			E983A69E = value;
		}
	}

	public int Int32_2
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public string String_5
	{
		[CompilerGenerated]
		get
		{
			return B586998D;
		}
		[CompilerGenerated]
		set
		{
			B586998D = value;
		}
	}

	public FE33ED1C CA294803
	{
		[CompilerGenerated]
		get
		{
			return FB956D0D;
		}
		[CompilerGenerated]
		set
		{
			FB956D0D = value;
		}
	}

	public Chrome()
	{
		D1154987 = 0;
		Boolean_0 = false;
		Boolean_2 = false;
		Boolean_3 = true;
		Boolean_1 = false;
		String_0 = "";
		String_1 = "";
		F5BA98AC = new Point(300, 300);
		F5BA98AC = new Point(F5BA98AC.X, F5BA98AC.Y);
		A3A32284 = "";
		Int32_1 = 0;
		Point_0 = new Point(Point_0.X, Point_0.Y);
		DA9C9817 = "";
		Boolean_4 = false;
		A1277F87 = "";
		AC20011A = "data\\extension";
		C63504A5 = false;
		Point_1 = new Point(300, 300);
		CA294803 = FE33ED1C.AC3A1601;
		Boolean_7 = false;
		String_4 = "";
		Double_0 = 1.0;
		Boolean_5 = true;
	}

	public (bool success, string error) method_0()
	{
		int num = 3;
		bool item;
		while (true)
		{
			if (C5034B95.smethod_0("configGeneral").BDB80B23("sizeChrome").Contains("x"))
			{
				C63504A5 = true;
				string text = C5034B95.smethod_0("configGeneral").BDB80B23("sizeChrome").Substring(0, C5034B95.smethod_0("configGeneral").BDB80B23("sizeChrome").LastIndexOf('x'));
				int int32_ = Convert.ToInt32(C5034B95.smethod_0("configGeneral").BDB80B23("sizeChrome").Split('x')[2]);
				Point_1 = new Point(Convert.ToInt32(text.Split('x')[0]), Convert.ToInt32(text.Split('x')[1]));
				Int32_0 = int32_;
				String_0 = String_0;
			}
			A1277F87 = C5034B95.smethod_0("configGeneral").BDB80B23("txtLinkToOtherBrowser").Trim();
			Boolean_7 = C5034B95.smethod_0("configGeneral").method_3("ckbUsePortable");
			String_4 = C5034B95.smethod_0("configGeneral").BDB80B23("txtPathToPortableZip");
			if (!Boolean_0)
			{
				Boolean_0 = C5034B95.smethod_0("configGeneral").method_3("ckbHideBrowser");
			}
			if (BF35E2B2 || Boolean_6 || DA248813)
			{
				Boolean_2 = false;
				if (!BF35E2B2)
				{
					Boolean_0 = false;
				}
			}
			if (Boolean_0 && !ManualSessionLogin)
			{
				Boolean_2 = true;
			}
			item = false;
			try
			{
				ChromeOptions chromeOptions = new ChromeOptions();
				AA3B0EAA = F5BA98AC.X;
				FC8813AF = F5BA98AC.Y;
				CF366839 = Point_0.X;
				DF91F13B = Point_0.Y;
				chromeOptions.AddArguments("--window-size=" + F5BA98AC.X + "," + F5BA98AC.Y, "--window-position=" + Point_0.X + "," + Point_0.Y);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 0);
				if (Boolean_3)
				{
					chromeOptions.AddArgument("--mute-audio");
				}
				chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
				chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
				chromeOptions.AddExcludedArgument("enable-automation");
				chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
				chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
				if (Double_0 == 1.0)
				{
					Double_0 = (double)C5034B95.smethod_0("configGeneral").method_2("nudChromeScale", 100) * 1.0 / 100.0;
				}
				if (Double_0 != 1.0)
				{
					chromeOptions.AddArgument("--force-device-scale-factor=" + Double_0);
				}
				if (A1277F87 != "")
				{
					string text2 = A1277F87;
					if (!text2.EndsWith(".exe"))
					{
						text2 = (File.Exists(text2 + ".exe") ? (text2 + ".exe") : ((!File.Exists(text2 + "\\chrome.exe")) ? "" : (text2 + "\\chrome.exe")));
					}
					if (text2 != "" && File.Exists(text2))
					{
						chromeOptions.BinaryLocation = text2;
					}
				}
				if (Boolean_0 && !ManualSessionLogin)
				{
					chromeOptions.AddArgument("--headless=new");
				}
				if (Boolean_2)
				{
					chromeOptions.AddArgument("--blink-settings=imagesEnabled=false");
					chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
				}
				else
				{
					chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 1);
				}
				if (!string.IsNullOrEmpty(String_1.Trim()))
				{
					if (!PreserveSession && C5034B95.smethod_0("configInteractGeneral").method_3("ckbXoaProfile"))
					{
						Commom.DeleteFolder(String_1);
					}
					if (Boolean_7)
					{
						if (!Directory.Exists(String_1))
						{
							ZipFile.ExtractToDirectory(String_4, String_1);
						}
						chromeOptions.BinaryLocation = String_1 + "\\App\\Chrome-bin\\chrome.exe";
						chromeOptions.AddArgument("--user-data-dir=" + String_1 + "\\Data\\profile");
					}
					else
					{
						try
						{
							Directory.CreateDirectory(String_1);
                            chromeOptions.AddArgument("--user-data-dir=" + Path.GetFullPath(String_1));
						}
						catch (Exception)
						{
						}
					}
				}
				if (Boolean_1 && !PreserveSession)
				{
					chromeOptions.AddArguments("--incognito");
				}
				if (AC20011A.Trim() != "")
				{
					if (!Directory.Exists(AC20011A))
					{
						Directory.CreateDirectory(AC20011A);
					}
					List<string> list = Commom.smethod_76(AC20011A);
					for (int i = 0; i < list.Count; i++)
					{
						chromeOptions.AddExtension(list[i]);
					}
				}
				if (!string.IsNullOrEmpty(DA9C9817.Trim()))
				{
					chromeOptions.AddArgument("--app=" + DA9C9817);
				}
				if (Boolean_4)
				{
					chromeOptions.AddArgument("--autoplay-policy=no-user-gesture-required");
				}
				chromeOptions.AddArguments(
					"--disable-background-networking",
					"--disable-bundled-ppapi-flash",
					"--disable-client-side-phishing-detection",
					"--disable-default-apps",
					"--disable-hang-monitor",
					"--disable-prompt-on-repost",
					"--disable-sync",
					"--disable-notifications",
					"--disable-dev-shm-usage",
					"--disable-rtc-smoothness-algorithm",
					"--disable-webrtc-hw-decoding",
					"--disable-webrtc-hw-encoding",
					"--disable-webrtc-multiple-routes",
					"--disable-webrtc-hw-vp8-encoding",
					"--enforce-webrtc-ip-permission-check",
					"--force-webrtc-ip-handling-policy=disable_non_proxied_udp",
					"--disable-infobars",
					"--disable-popup-blocking",
					"--no-default-browser-check",
					"--no-first-run",
					"--lang=en_US",
					"--hide-crash-restore-bubble",
					"--no-sandbox",
					"--ignore-certificate-errors",
					"--disable-blink-features=BlockCredentialedSubresources",
					"--disable-gpu",
					"--disable-software-rasterizer",
					"--memory-saver-mode",
					"--js-flags=--max-old-space-size=512",
					"--renderer-process-limit=2",
					"--disable-features=Translate,OptimizationHints,MediaRouter,BackForwardCache",
					"--disable-component-update",
					"--disable-breakpad",
					"--disable-domain-reliability",
					"--disk-cache-size=33554432",
					"--media-cache-size=16777216");
				if (!string.IsNullOrEmpty(String_0) && !BF35E2B2 && !Boolean_6)
				{
					chromeOptions.AddArgument("--user-agent=" + String_0);
				}
				string text3 = "";
				string proxyAuthExtensionDir = "";
				A3A32284 = A3A32284.Trim().TrimEnd(':');
				if (!string.IsNullOrEmpty(A3A32284))
				{
					if (A3A32284.Split(':').Length == 1)
					{
						A3A32284 = "127.0.0.1:" + A3A32284;
					}
					if (A3A32284.Split(':').Length == 4)
					{
						string[] arrayProxy = A3A32284.Split(':');
						proxyAuthExtensionDir = CreateProxyAuthExtension(arrayProxy[0], Convert.ToInt32(arrayProxy[1]), arrayProxy[2], arrayProxy[3], Int32_1);
					}
					else if (C5034B95.smethod_0("configGeneral").method_3("ckbUseExtensionProxy") && Directory.Exists(Commom.smethod_95() + "\\extension\\Proxy"))
					{
						chromeOptions.AddArgument("--load-extension=" + Commom.smethod_95() + "\\extension\\Proxy");
						text3 = method_1(Int32_1, A3A32284.Split(':')[0], Convert.ToInt32(A3A32284.Split(':')[1]));
					}
					else
					{
						chromeOptions.AddArgument("--proxy-server=" + ((Int32_1 == 0) ? "" : "socks5://") + A3A32284.Split(':')[0] + ":" + A3A32284.Split(':')[1]);
					}
				}
				if (C5034B95.smethod_0("configCheckpoint").method_3("ckbImage") && C5034B95.smethod_0("configCheckpoint").method_3("ckbQuayVideo"))
				{
					chromeOptions.AddArgument("--use-fake-ui-for-media-stream");
				}
				try
				{
					Commom.PatchChromeDriverCdc(Commom.smethod_95() + "\\chromedriver.exe");
				}
				catch {}
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(Commom.smethod_95());
				if (!string.IsNullOrEmpty(chromeOptions.BinaryLocation))
				{
					string directoryName = Path.GetDirectoryName(chromeOptions.BinaryLocation);
					chromeDriverService = ((!File.Exists(directoryName + "\\chromedriver.exe")) ? ChromeDriverService.CreateDefaultService(Commom.smethod_95()) : ChromeDriverService.CreateDefaultService(directoryName));
				}
				bool flag = C5034B95.smethod_0("configGeneral").method_3("ckbGologin") && String_1 != "";
				bool flag2 = Class59.ED081E86();
				if (flag || flag2)
				{
					if (flag)
					{
						string path = (chromeOptions.BinaryLocation = C5034B95.smethod_0("configGeneral").BDB80B23("txtOrbitaPath"));
						chromeDriverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(path));
						string text5 = String_1 + "\\Default\\Preferences";
						if (!File.Exists(text5) || !File.ReadAllText(text5).Contains("gologin"))
						{
							Commom.smethod_79(String_1);
						}
						try
						{
							string text6 = "gologin\\" + string_2 + ".config";
							string text7 = File.ReadAllText(File.Exists(text6) ? text6 : text5);
							if (string.IsNullOrEmpty(String_0))
							{
								String_0 = ModernUserAgentHub.GetRandomDesktopChrome();
							}
							string value = Regex.Match(text7, "\"userAgent\":.*?\"(.*?)\"").Groups[1].Value;
							if (value != String_0)
							{
								text7 = text7.Replace(value, String_0);
							}
							string value2 = Regex.Match(text7, "\"proxy\":.*?\\{.*?\\},", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.CultureInvariant).Value;
							text7 = ((A3A32284.Split(':').Length != 4) ? text7.Replace(value2, "\"proxy\": { \"password\": \"\", \"username\": \"\" },") : text7.Replace(value2, "\"proxy\": { \"password\": \"" + A3A32284.Split(':')[3] + "\", \"username\": \"" + A3A32284.Split(':')[2] + "\" },"));
							File.WriteAllText(text5, text7);
							File.WriteAllText(text6, text7);
						}
						catch (Exception)
						{
						}
					}
					else if (flag2)
					{
						if (String_1 == "")
						{
							class59_0 = new Class59("temp_" + Commom.smethod_90());
						}
						else
						{
							class59_0 = new Class59(string_2);
						}
						class59_0.method_1(A3A32284, String_0);
					}
				}
				else
				{
					// chromeOptions.AddArgument("--disable-webrtc"); // Deprecated, triggers bot detection
					chromeOptions.AddUserProfilePreference("webrtc.ip_handling_policy", "disable_non_proxied_udp");
					chromeOptions.AddUserProfilePreference("webrtc.multiple_routes_enabled", false);
					chromeOptions.AddUserProfilePreference("webrtc.nonproxied_udp_enabled", false);
					if (String_1 != "")
					{
						Commom.E10A40B6(String_1 + "\\Default\\Preferences");
					}
					if (!C5034B95.smethod_0("configGeneral").method_3("ckbUseExtensionProxy") && A3A32284.Split(':').Length == 4)
					{
						if (File.Exists("extension\\proxy2.crx"))
						{
							try { chromeOptions.AddExtension("extension\\proxy2.crx"); } catch {}
						}
					}
				}
				List<string> list2 = new List<string>();
				if (!string.IsNullOrEmpty(proxyAuthExtensionDir) && Directory.Exists(proxyAuthExtensionDir))
				{
					list2.Add(proxyAuthExtensionDir);
				}
				if (C5034B95.smethod_0("configGeneral").method_3("ckbExtensionOmoCaptcha") && Directory.Exists("extension\\omocaptcha"))
				{
					list2.Add(Commom.smethod_95() + "\\extension\\omocaptcha");
				}
				if (AC20011A.Trim() != "")
				{
					List<string> list3 = Directory.GetDirectories(AC20011A).ToList();
					for (int j = 0; j < list3.Count; j++)
					{
						list2.Add(Commom.smethod_95() + "\\" + list3[j]);
					}
				}
				if (list2.Count > 0)
				{
					chromeOptions.AddArgument("--load-extension=" + string.Join(",", list2));
				}
				if (flag2)
				{
					string text8 = chromeOptions.Arguments.Select((string A22C9DBE) => A22C9DBE.Trim()).Aggregate("", (string string_0, string string_1) => string_0 + " " + (string_1.Contains(" ") ? ("\"" + string_1 + "\"") : string_1));
					text8 = text8.Replace("--no-sandbox", "");
					text8 = text8.Replace("--disable-web-security", "");
					text8 = text8.Replace("--ignore-certificate-errors", "");
					text8 = text8.Replace("--disable-blink-features=BlockCredentialedSubresources", "");
					text8 = text8.Replace("--disable-blink-features=AutomationControlled", "");
					text8 = text8.Replace("--enable-blink-features=ShadowDOMV0", "");
					text8 = text8.Trim() + " ";
					if (text8.Contains("--proxy-server="))
					{
						text8 = text8.Replace(Regex.Match(text8, "--proxy-server=(.*?) ").Value, "");
					}
					if (text8.Contains("--user-data-dir="))
					{
						text8 = text8.Replace(Regex.Match(text8, "--user-data-dir=(.*?) ").Value, "");
					}
					text8 = Regex.Replace(text8, "\\s+", " ").Trim();
					class59_0.method_2(text8);
					if (string.IsNullOrEmpty(class59_0.string_1))
					{
						return (item, class59_0.A99A612B());
					}
					chromeDriverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(class59_0.string_1), Path.GetFileName(class59_0.string_1));
					chromeOptions = new ChromeOptions();
					chromeOptions.DebuggerAddress = class59_0.string_0;
				}
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeDriver_0 = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3.0));
				Process_1 = Process.GetProcessById(chromeDriverService.ProcessId);
				ChromeDriver_0.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				ChromeDriver_0.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60.0);
				ChromeDriver_0.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60.0);
				String_5 = ChromeDriver_0.SessionId.ToString();
				Int32_2 = chromeDriverService.Port;
				Boolean_5 = false;
				ApplyStealthCDP();
				if (!Boolean_0)
				{
					A3A60133();
				}
				if (flag || flag2)
				{
					method_53(F5BA98AC.X, F5BA98AC.Y);
					method_51(Point_0.X, Point_0.Y);
				}
				else if (C5034B95.smethod_0("configGeneral").method_3("ckbUseExtensionProxy"))
				{
					for (int k = 0; k < 4; k++)
					{
						if (!D7A424AE("textarea[id=\"proxyConfig\"]", 5.0))
						{
							method_13();
							item = false;
							continue;
						}
						if (text3 != "")
						{
							method_14("document.querySelector(\"#proxyConfig\").value = `" + text3 + "`;\r\ndocument.querySelector(\"#import\").click();");
						}
						break;
					}
				}
				else if (A3A32284.Split(':').Length == 4)
				{
					if (string.IsNullOrEmpty(proxyAuthExtensionDir))
					{
						while (true)
						{
							method_14("document.title=\"proxyauth=" + A3A32284 + "\"");
							int num2 = C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIP");
							F8091028((num2 >= 3) ? num2 : 3);
							method_12("https://ifconfig.co/ip");
							if (!(AFACE5B4() == "<html><head></head><body></body></html>"))
							{
								break;
							}
							method_12("chrome://extensions/");
							string text9 = "document.querySelector('extensions-manager').shadowRoot.querySelector('#toolbar').shadowRoot.querySelector('#devMode')";
							if (method_14("return " + text9 + ".checked").ToLower() == "false")
							{
								method_14(text9 + ".click()");
							}
							string text10 = "document.querySelector('extensions-manager').shadowRoot.querySelector('#items-list').shadowRoot.querySelector('extensions-item').shadowRoot.querySelector('#enableToggle')";
							if (method_14("return " + text10 + ".checked").ToLower() == "false")
							{
								method_14(text10 + ".click()");
								continue;
							}
							A4B307B3(60);
							num--;
							if (num <= 0)
							{
								return (item, "Proxy yêu cầu User/Pass!");
							}
							goto end_IL_00d4;
						}
					}
					item = true;
				}
				if (C5034B95.smethod_0("configGeneral").method_3("ckbExtensionOmoCaptcha"))
				{
					method_12("https://omocaptcha.com/?api_key=" + C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4"));
					F8091028(3.0);
				}
				item = true;
				break;
				end_IL_00d4:;
			}
			catch (Exception ex3)
			{
				if (PreserveSession && (ex3.Message.IndexOf("user data directory is already in use", StringComparison.OrdinalIgnoreCase) >= 0
                    || ex3.Message.IndexOf("Chrome has crashed", StringComparison.OrdinalIgnoreCase) >= 0))
                    return (false, "Profile đang mở hoặc Chrome chưa đóng hoàn toàn. Đóng cửa sổ của profile rồi thử lại.");
				if (ex3.ToString().Contains("This version of ChromeDriver only supports Chrome version") ||
					(ex3.ToString().Contains("session not created") && ex3.ToString().Contains("Chrome version")))
				{
					try
					{
						var updateRes = ChromeDriverUpdater.UpdateChromeDriver(Commom.smethod_95());
						if (updateRes.success)
						{
							num--;
							if (num > 0)
							{
								A4B307B3(10);
								Thread.Sleep(1500);
								continue;
							}
						}
					}
					catch { }
					return (item, "Update chromedriver");
				}
				if (!ex3.ToString().Contains("ChromeDriver is assuming that Chrome has crashed") && !ex3.ToString().Contains("user data directory is already in use"))
				{
					goto IL_125e;
				}
				num--;
				if (num <= 0)
				{
					goto IL_125e;
				}
				Commom.B2B23807(B4208531);
				goto end_IL_11f4;
				IL_125e:
				if (!PreserveSession && ex3.ToString().Contains("session timed out after"))
				{
					try { if (Process_0 != null && !Process_0.HasExited) Process_0.Kill(); } catch {}
					try { if (Process_1 != null && !Process_1.HasExited) Process_1.Kill(); } catch {}
				}
				method_46(ex3, "chrome.Open()");
				break;
				end_IL_11f4:;
			}
		}
		return (item, "");
	}

	private string method_1(int int_4, string string_10, int F71A5A9D, string string_11 = "", string string_12 = "")
	{
		string text = (int_4 == 1) ? "socks5" : "http";
		return $"{{\"scheme\": \"{text}\", \"host\": \"{string_10}\", \"port\": \"{F71A5A9D}\", \"username\": \"{string_11}\", \"password\": \"{string_12}\"}}";
	}

	private string CreateProxyAuthExtension(string host, int port, string user, string pass, int proxyType = 0)
	{
		try
		{
			string scheme = (proxyType == 1) ? "socks5" : "http";
			string safeHost = host.Replace(".", "_").Replace(":", "_");
			string extDir = Path.Combine(Commom.smethod_95(), "extension", "auth_" + safeHost + "_" + port);
			if (!Directory.Exists(extDir))
			{
				Directory.CreateDirectory(extDir);
			}
			string manifest = "{\n  \"version\": \"1.0.0\",\n  \"manifest_version\": 2,\n  \"name\": \"LushCare Proxy Auth\",\n  \"permissions\": [\"proxy\", \"tabs\", \"unlimitedStorage\", \"storage\", \"<all_urls>\", \"webRequest\", \"webRequestBlocking\"],\n  \"background\": { \"scripts\": [\"background.js\"] },\n  \"minimum_chrome_version\": \"22.0.0\"\n}";
			string bg = "var config = {\n  mode: 'fixed_servers',\n  rules: {\n    singleProxy: {\n      scheme: '" + scheme + "',\n      host: '" + host + "',\n      port: parseInt(" + port + ")\n    },\n    bypassList: ['localhost', '127.0.0.1']\n  }\n};\nchrome.proxy.settings.set({value: config, scope: 'regular'}, function() {});\nchrome.webRequest.onAuthRequired.addListener(\n  function(details) {\n    return {\n      authCredentials: {\n        username: '" + user + "',\n        password: '" + pass + "'\n      }\n    };\n  },\n  {urls: ['<all_urls>']},\n  ['blocking']\n);\n";
			File.WriteAllText(Path.Combine(extDir, "manifest.json"), manifest);
			File.WriteAllText(Path.Combine(extDir, "background.js"), bg);
			return extDir;
		}
		catch
		{
			return "";
		}
	}

	private void ApplyStealthCDP()
	{
		try
		{
			if (string.IsNullOrEmpty(String_5) || Int32_2 <= 0)
			{
				return;
			}

			// Generate per-profile deterministic seed from account UID / Profile Path / Session
			uint seed = 2166136261u;
			string seedInput = !string.IsNullOrEmpty(B4208531) ? B4208531 :
				(!string.IsNullOrEmpty(AF336B2C) ? AF336B2C :
				(!string.IsNullOrEmpty(String_1) ? String_1 :
				(!string.IsNullOrEmpty(String_5) ? String_5 : Guid.NewGuid().ToString("N"))));
			foreach (char c in seedInput)
			{
				seed = (seed ^ c) * 16777619u;
			}
			if (seed == 0) seed = 123456789u;

			string script = @"(function() {
				const profileSeed = " + seed + @";
				const nativeMap = new WeakMap();
				const origFnToString = Function.prototype.toString;
				const makeNative = (fn, name) => {
					try {
						Object.defineProperty(fn, 'name', { value: name, configurable: true });
						nativeMap.set(fn, 'function ' + name + '() { [native code] }');
					} catch(e){}
					return fn;
				};
				try {
					Function.prototype.toString = makeNative(function toString() {
						if (nativeMap.has(this)) {
							return nativeMap.get(this);
						}
						return origFnToString.call(this);
					}, 'toString');
				} catch(e){}

				try {
					const proto = Object.getPrototypeOf(navigator);
					delete proto.webdriver;
					delete navigator.webdriver;
					Object.defineProperty(proto, 'webdriver', { get: () => undefined, configurable: true, enumerable: false });
				} catch(e){}

				try {
					if (!window.chrome) { window.chrome = {}; }
					window.chrome.app = {
						isInstalled: false,
						InstallState: { DISABLED: 'disabled', INSTALLED: 'installed', NOT_INSTALLED: 'not_installed' },
						RunningState: { CANNOT_RUN: 'cannot_run', READY_TO_RUN: 'ready_to_run', RUNNING: 'running' }
					};
					window.chrome.runtime = window.chrome.runtime || {
						OnInstalledReason: { CHROME_UPDATE: 'chrome_update', INSTALL: 'install', SHARED_MODULE_UPDATE: 'shared_module_update', UPDATE: 'update' }
					};
					window.chrome.csi = makeNative(function() {
						return { startE: Date.now(), onloadT: Date.now() + 50, pageT: 50.5, tran: 15 };
					}, 'csi');
					window.chrome.loadTimes = makeNative(function() {
						const now = Date.now() / 1000;
						return {
							commitLoadTime: now,
							connectionInfo: 'http/1.1',
							finishDocumentLoadTime: now + 0.1,
							finishLoadTime: now + 0.2,
							firstPaintAfterLoadTime: 0,
							firstPaintTime: now + 0.05,
							navigationType: 'Other',
							npnNegotiatedProtocol: 'unknown',
							requestTime: now - 0.1,
							startLoadTime: now - 0.1,
							wasAlternateProtocolAvailable: false,
							wasFetchedViaSpdy: false,
							wasNpnNegotiated: false
						};
					}, 'loadTimes');
				} catch(e){}

				try {
					const fakePlugins = [
						{ name: 'PDF Viewer', filename: 'internal-pdf-viewer', description: 'Portable Document Format' },
						{ name: 'Chrome PDF Viewer', filename: 'internal-pdf-viewer', description: 'Portable Document Format' },
						{ name: 'Chromium PDF Viewer', filename: 'internal-pdf-viewer', description: 'Portable Document Format' }
					];
					Object.defineProperty(navigator, 'plugins', {
						get: () => {
							const arr = [...fakePlugins];
							arr.item = (i) => fakePlugins[i] || null;
							arr.namedItem = (name) => fakePlugins.find(p => p.name === name) || null;
							arr.refresh = () => {};
							return arr;
						},
						configurable: true
					});
				} catch(e){}

				try {
					Object.defineProperty(navigator, 'languages', {
						get: () => ['en-US', 'en', 'vi-VN', 'vi'],
						configurable: true
					});
				} catch(e){}

				try {
					const origQuery = window.navigator.permissions.query;
					if (origQuery) {
						const fakeQuery = function(parameters) {
							return (parameters && parameters.name === 'notifications')
								? Promise.resolve({ state: Notification.permission, onchange: null })
								: origQuery.apply(this, arguments);
						};
						window.navigator.permissions.query = makeNative(fakeQuery, 'query');
					}
				} catch(e){}

				try {
					if (window.RTCPeerConnection) {
						const OrigRTC = window.RTCPeerConnection;
						const PatchedRTC = function(config, constraints) {
							if (config && config.iceServers) {
								config.iceTransportPolicy = 'relay';
							}
							const pc = new OrigRTC(config, constraints);
							const origAddIceCandidate = pc.addIceCandidate;
							pc.addIceCandidate = function(candidate) {
								if (!candidate || !candidate.candidate) return Promise.resolve();
								if (candidate.candidate.includes('typ host') || candidate.candidate.includes('typ srflx')) {
									return Promise.resolve();
								}
								return origAddIceCandidate.apply(this, arguments);
							};
							return pc;
						};
						PatchedRTC.prototype = OrigRTC.prototype;
						window.RTCPeerConnection = makeNative(PatchedRTC, 'RTCPeerConnection');
					}
				} catch(e){}

				// Canvas Fingerprint Anti-Detect
				try {
					if (window.CanvasRenderingContext2D && CanvasRenderingContext2D.prototype.getImageData) {
						const origGetImageData = CanvasRenderingContext2D.prototype.getImageData;
						const canvasStep = 20 + (profileSeed % 13);
						const canvasChannel = (profileSeed % 3);
						const canvasDelta = ((profileSeed & 1) === 0) ? 1 : -1;

						CanvasRenderingContext2D.prototype.getImageData = makeNative(function(sx, sy, sw, sh) {
							const imgData = origGetImageData.apply(this, arguments);
							if (imgData && imgData.data) {
								const d = imgData.data;
								const len = d.length;
								for (let i = 0; i < len; i += canvasStep * 4) {
									if (d[i + 3] > 10) {
										const idx = i + canvasChannel;
										const val = d[idx] + canvasDelta;
										d[idx] = val < 0 ? 0 : (val > 255 ? 255 : val);
									}
								}
							}
							return imgData;
						}, 'getImageData');

						if (window.HTMLCanvasElement) {
							const origToDataURL = HTMLCanvasElement.prototype.toDataURL;
							HTMLCanvasElement.prototype.toDataURL = makeNative(function(type, quality) {
								try {
									const w = this.width;
									const h = this.height;
									if (w > 0 && h > 0) {
										const clone = document.createElement('canvas');
										clone.width = w;
										clone.height = h;
										const ctx = clone.getContext('2d', { willReadFrequently: true });
										if (ctx) {
											ctx.drawImage(this, 0, 0);
											const imgData = origGetImageData.call(ctx, 0, 0, w, h);
											const d = imgData.data;
											let modified = 0;
											for (let i = 0; i < d.length; i += canvasStep * 4) {
												if (d[i + 3] > 10) {
													const idx = i + canvasChannel;
													const val = d[idx] + canvasDelta;
													d[idx] = val < 0 ? 0 : (val > 255 ? 255 : val);
													modified++;
												}
											}
											if (modified > 0) {
												ctx.putImageData(imgData, 0, 0);
												return origToDataURL.apply(clone, arguments);
											}
										}
									}
								} catch(e){}
								return origToDataURL.apply(this, arguments);
							}, 'toDataURL');

							if (HTMLCanvasElement.prototype.toBlob) {
								const origToBlob = HTMLCanvasElement.prototype.toBlob;
								HTMLCanvasElement.prototype.toBlob = makeNative(function(callback, type, quality) {
									try {
										const w = this.width;
										const h = this.height;
										if (w > 0 && h > 0 && typeof callback === 'function') {
											const clone = document.createElement('canvas');
											clone.width = w;
											clone.height = h;
											const ctx = clone.getContext('2d', { willReadFrequently: true });
											if (ctx) {
												ctx.drawImage(this, 0, 0);
												const imgData = origGetImageData.call(ctx, 0, 0, w, h);
												const d = imgData.data;
												let modified = 0;
												for (let i = 0; i < d.length; i += canvasStep * 4) {
													if (d[i + 3] > 10) {
														const idx = i + canvasChannel;
														const val = d[idx] + canvasDelta;
														d[idx] = val < 0 ? 0 : (val > 255 ? 255 : val);
														modified++;
													}
												}
												if (modified > 0) {
													ctx.putImageData(imgData, 0, 0);
													return origToBlob.call(clone, callback, type, quality);
												}
											}
										}
									} catch(e){}
									return origToBlob.apply(this, arguments);
								}, 'toBlob');
							}
						}
					}
				} catch(e){}

				// WebGL Fingerprint Anti-Detect
				try {
					const gpuProfiles = [
						{ vendor: 'Google Inc. (NVIDIA)', renderer: 'ANGLE (NVIDIA, NVIDIA GeForce RTX 3060 Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (NVIDIA)', renderer: 'ANGLE (NVIDIA, NVIDIA GeForce RTX 3070 Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (NVIDIA)', renderer: 'ANGLE (NVIDIA, NVIDIA GeForce RTX 2060 Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (NVIDIA)', renderer: 'ANGLE (NVIDIA, NVIDIA GeForce GTX 1660 SUPER Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (NVIDIA)', renderer: 'ANGLE (NVIDIA, NVIDIA GeForce GTX 1050 Ti Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (Intel)', renderer: 'ANGLE (Intel, Intel(R) UHD Graphics 630 Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (Intel)', renderer: 'ANGLE (Intel, Intel(R) UHD Graphics 770 Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (Intel)', renderer: 'ANGLE (Intel, Intel(R) Iris(R) Xe Graphics Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (AMD)', renderer: 'ANGLE (AMD, AMD Radeon RX 6600 Direct3D11 vs_5_0 ps_5_0, D3D11)' },
						{ vendor: 'Google Inc. (AMD)', renderer: 'ANGLE (AMD, AMD Radeon RX 580 Series Direct3D11 vs_5_0 ps_5_0, D3D11)' }
					];
					const chosenGpu = gpuProfiles[profileSeed % gpuProfiles.length];

					const hookWebGL = (proto) => {
						if (!proto) return;
						const origGetParameter = proto.getParameter;
						proto.getParameter = makeNative(function(param) {
							if (param === 37445) return chosenGpu.vendor;
							if (param === 37446) return chosenGpu.renderer;
							if (param === 7936) return 'WebKit';
							if (param === 7937) return 'WebKit WebGL';
							return origGetParameter.apply(this, arguments);
						}, 'getParameter');

						const origGetExtension = proto.getExtension;
						proto.getExtension = makeNative(function(name) {
							if (name === 'WEBGL_debug_renderer_info') {
								return {
									UNMASKED_VENDOR_WEBGL: 37445,
									UNMASKED_RENDERER_WEBGL: 37446
								};
							}
							return origGetExtension.apply(this, arguments);
						}, 'getExtension');

						const origGetSupportedExtensions = proto.getSupportedExtensions;
						if (origGetSupportedExtensions) {
							proto.getSupportedExtensions = makeNative(function() {
								const list = origGetSupportedExtensions.apply(this, arguments) || [];
								if (!list.includes('WEBGL_debug_renderer_info')) {
									return [...list, 'WEBGL_debug_renderer_info'];
								}
								return list;
							}, 'getSupportedExtensions');
						}
					};

					if (window.WebGLRenderingContext) hookWebGL(WebGLRenderingContext.prototype);
					if (window.WebGL2RenderingContext) hookWebGL(WebGL2RenderingContext.prototype);
				} catch(e){}

				// AudioContext Fingerprint Anti-Detect
				try {
					const audioJitter = ((profileSeed % 100) + 1) * 1e-7;

					if (window.AudioBuffer) {
						const origGetChannelData = AudioBuffer.prototype.getChannelData;
						AudioBuffer.prototype.getChannelData = makeNative(function(channel) {
							const data = origGetChannelData.apply(this, arguments);
							if (!this._jitteredChannels) this._jitteredChannels = new Set();
							if (!this._jitteredChannels.has(channel)) {
								this._jitteredChannels.add(channel);
								for (let i = 0; i < data.length; i += 100) {
									const sign = ((i + profileSeed) % 2 === 0) ? 1 : -1;
									data[i] += sign * audioJitter;
								}
							}
							return data;
						}, 'getChannelData');

						if (AudioBuffer.prototype.copyFromChannel) {
							const origCopyFromChannel = AudioBuffer.prototype.copyFromChannel;
							AudioBuffer.prototype.copyFromChannel = makeNative(function(destination, channelNumber, startInChannel) {
								origCopyFromChannel.apply(this, arguments);
								if (!this._jitteredChannels || !this._jitteredChannels.has(channelNumber)) {
									for (let i = 0; i < destination.length; i += 100) {
										const sign = ((i + profileSeed) % 2 === 0) ? 1 : -1;
										destination[i] += sign * audioJitter;
									}
								}
							}, 'copyFromChannel');
						}
					}

					if (window.AnalyserNode) {
						const origGetFloatFrequencyData = AnalyserNode.prototype.getFloatFrequencyData;
						AnalyserNode.prototype.getFloatFrequencyData = makeNative(function(array) {
							origGetFloatFrequencyData.apply(this, arguments);
							for (let i = 0; i < array.length; i += 20) {
								if (array[i] !== -Infinity && array[i] !== 0) {
									const sign = ((i + profileSeed) % 2 === 0) ? 1 : -1;
									array[i] += sign * audioJitter;
								}
							}
						}, 'getFloatFrequencyData');

						if (AnalyserNode.prototype.getFloatTimeDomainData) {
							const origGetFloatTimeDomainData = AnalyserNode.prototype.getFloatTimeDomainData;
							AnalyserNode.prototype.getFloatTimeDomainData = makeNative(function(array) {
								origGetFloatTimeDomainData.apply(this, arguments);
								for (let i = 0; i < array.length; i += 20) {
									const sign = ((i + profileSeed) % 2 === 0) ? 1 : -1;
									array[i] += sign * audioJitter;
								}
							}, 'getFloatTimeDomainData');
						}
					}
				} catch(e){}

				// ClientRects Fingerprint Anti-Detect
				try {
					const clientRectNoise = ((profileSeed % 9) - 4) * 0.0001;
					if (window.Element && Element.prototype.getBoundingClientRect) {
						const origGetBoundingClientRect = Element.prototype.getBoundingClientRect;
						Element.prototype.getBoundingClientRect = makeNative(function() {
							const rect = origGetBoundingClientRect.apply(this, arguments);
							if (rect && (rect.width > 0 || rect.height > 0)) {
								return new DOMRect(
									rect.x,
									rect.y,
									rect.width > 0 ? rect.width + clientRectNoise : 0,
									rect.height > 0 ? rect.height + clientRectNoise : 0
								);
							}
							return rect;
						}, 'getBoundingClientRect');
					}

					if (window.Range && Range.prototype.getBoundingClientRect) {
						const origRangeGetBoundingClientRect = Range.prototype.getBoundingClientRect;
						Range.prototype.getBoundingClientRect = makeNative(function() {
							const rect = origRangeGetBoundingClientRect.apply(this, arguments);
							if (rect && (rect.width > 0 || rect.height > 0)) {
								return new DOMRect(
									rect.x,
									rect.y,
									rect.width > 0 ? rect.width + clientRectNoise : 0,
									rect.height > 0 ? rect.height + clientRectNoise : 0
								);
							}
							return rect;
						}, 'getBoundingClientRect');
					}
				} catch(e){}
			})();";

			JObject payload = new JObject
			{
				["cmd"] = "Page.addScriptToEvaluateOnNewDocument",
				["params"] = new JObject
				{
					["source"] = script
				}
			};

			string url = $"http://127.0.0.1:{Int32_2}/session/{String_5}/chromium/send_command_and_get_result";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.ContentType = "application/json;charset=utf-8";
			request.Timeout = 5000;
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(payload.ToString());
			request.ContentLength = bytes.Length;
			using (Stream stream = request.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
			}
		}
		catch
		{
		}
	}

	public void method_2()
	{
		if (!CD930D04() && !E184CD03())
		{
			User32Helper.ShowWindow(Process_0.MainWindowHandle, 6);
		}
	}

	public bool CD930D04()
	{
		if (Boolean_5)
		{
			return true;
		}
		if (Process_0 != null && Process_0.HasExited)
		{
			Boolean_5 = true;
		}
		return Boolean_5;
	}

	public bool E184CD03()
	{
		return Base.smethod_5();
	}

	public string AFACE5B4()
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		try
		{
			return ChromeDriver_0.PageSource;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return "";
	}

	private string method_3(string string_10)
	{
		string_10 = string_10.Replace("\\", "\\\\\\\\");
		string_10 = string_10.Replace("'", "\\'");
		string_10 = string_10.Replace("\n", "\\\\n");
		return string_10;
	}

	private string method_4(bool C7157C07)
	{
		return C7157C07.ToString().ToLower();
	}

	private bool B1A19F3D(string string_10)
	{
		if (string.IsNullOrEmpty(string_10)) return false;
		string trimmed = string_10.Trim();
		return trimmed.StartsWith("/") || trimmed.StartsWith("//") || trimmed.StartsWith("(/") || (trimmed.StartsWith("(") && trimmed.Contains("//"));
	}

	public string A7B8E3A5(string string_10)
	{
		if (string.IsNullOrEmpty(string_10)) return "null";
		if (B1A19F3D(string_10))
		{
			string escapedXpath = string_10.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "");
			return $"(document.evaluate(\"{escapedXpath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue)";
		}

		string[] array = string_10.Split('|');
		string parentSel = array[0].Trim().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "");
		int parentIdx = 0;
		string childSel = "";
		int childIdx = 0;

		if (array.Length >= 2)
		{
			int.TryParse(array[1].Trim(), out parentIdx);
		}
		if (array.Length >= 3)
		{
			childSel = array[2].Trim().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "");
		}
		if (array.Length >= 4)
		{
			int.TryParse(array[3].Trim(), out childIdx);
		}

		if (string.IsNullOrEmpty(childSel))
		{
			if (array.Length == 1)
			{
				return $"(document.querySelector(\"{parentSel}\"))";
			}
			return $"(document.querySelectorAll(\"{parentSel}\")[{parentIdx}])";
		}
		else
		{
			return $"(document.querySelectorAll(\"{parentSel}\")[{parentIdx}] ? document.querySelectorAll(\"{parentSel}\")[{parentIdx}].querySelectorAll(\"{childSel}\")[{childIdx}] : null)";
		}
	}

	public string B9BE8807(string C6163892, string string_10)
	{
		return method_14("return " + A7B8E3A5(C6163892) + ".getAttribute('" + string_10 + "')");
	}

	public string method_5(string string_10)
	{
		return method_14("return " + A7B8E3A5(string_10) + ".value");
	}

	public string method_6(string string_10)
	{
		return method_14("return " + A7B8E3A5(string_10) + ".innerText");
	}

	public string D3901939(string string_10)
	{
		return method_14("return " + A7B8E3A5(string_10) + ".innerHTML");
	}

	public string method_7(string E21E4006)
	{
		return method_14("return " + A7B8E3A5(E21E4006) + ".outerHTML");
	}

	public void method_8(int DAB3F7B4)
	{
		try
		{
			if (ChromeDriver_0 != null && !CD930D04() && !E184CD03())
			{
				HumanScroll.ScrollNewsfeed(ChromeDriver_0, DAB3F7B4, null);
			}
			else
			{
				method_14("window.scrollBy({ top: " + DAB3F7B4 + ",behavior: 'smooth'});");
			}
		}
		catch
		{
			method_14("window.scrollBy({ top: " + DAB3F7B4 + ",behavior: 'smooth'});");
		}
	}

	public string method_9()
	{
		return method_14("return navigator.userAgent");
	}

	public bool F4AC0516(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(string_10);
			webElement.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public string GetURL()
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		try
		{
			return ChromeDriver_0.Url;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return "";
	}

	public static string NormalizeFacebookUrl(string url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			return url;
		}

		string trimmed = url.Trim();
		bool hasMobile = trimmed.IndexOf("mobile.facebook.com", StringComparison.OrdinalIgnoreCase) >= 0;
		bool hasMbasic = trimmed.IndexOf("mbasic.facebook.com", StringComparison.OrdinalIgnoreCase) >= 0;

		if (!hasMobile && !hasMbasic)
		{
			return url;
		}

		try
		{
			string parseable = trimmed;
			if (!parseable.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
			    !parseable.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
			{
				parseable = "https://" + parseable;
			}

			Uri uri = new Uri(parseable);
			string path = (uri.AbsolutePath ?? "").ToLowerInvariant();

			string targetHost;
			if (hasMobile)
			{
				if (path.StartsWith("/privacy/touch") ||
				    path.StartsWith("/messages") ||
				    path.StartsWith("/zero") ||
				    path.StartsWith("/touch") ||
				    path.StartsWith("/a/preferences.php") ||
				    path.StartsWith("/composer/mbasic"))
				{
					targetHost = "m.facebook.com";
				}
				else if (path.StartsWith("/buddylist.php"))
				{
					targetHost = "www.facebook.com";
				}
				else if (path.StartsWith("/login.php") || path.StartsWith("/login"))
				{
					targetHost = "www.facebook.com";
				}
				else
				{
					targetHost = "www.facebook.com";
				}
			}
			else
			{
				if (path.StartsWith("/entercode.php") ||
				    path.StartsWith("/login/checkpoint") ||
				    path.StartsWith("/zero") ||
				    path.StartsWith("/privacy/touch") ||
				    path.StartsWith("/a/preferences.php"))
				{
					targetHost = "m.facebook.com";
				}
				else
				{
					targetHost = "www.facebook.com";
				}
			}

			UriBuilder builder = new UriBuilder(uri)
			{
				Scheme = "https",
				Host = targetHost,
				Port = -1
			};

			return builder.Uri.ToString();
		}
		catch
		{
			if (hasMobile)
			{
				if (trimmed.IndexOf("/privacy/touch", StringComparison.OrdinalIgnoreCase) >= 0 ||
				    trimmed.IndexOf("/messages", StringComparison.OrdinalIgnoreCase) >= 0 ||
				    trimmed.IndexOf("/zero", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return Regex.Replace(trimmed, @"https?://mobile\.facebook\.com", "https://m.facebook.com", RegexOptions.IgnoreCase);
				}
				return Regex.Replace(trimmed, @"https?://mobile\.facebook\.com", "https://www.facebook.com", RegexOptions.IgnoreCase);
			}
			if (hasMbasic)
			{
				if (trimmed.IndexOf("/entercode.php", StringComparison.OrdinalIgnoreCase) >= 0 ||
				    trimmed.IndexOf("/login/checkpoint", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return Regex.Replace(trimmed, @"https?://mbasic\.facebook\.com", "https://m.facebook.com", RegexOptions.IgnoreCase);
				}
				return Regex.Replace(trimmed, @"https?://mbasic\.facebook\.com", "https://www.facebook.com", RegexOptions.IgnoreCase);
			}
			return url;
		}
	}

	private string method_11(string string_10)
	{
		string_10 = NormalizeFacebookUrl(string_10);
		if (string_10.Contains("locale=en_US"))
		{
			return string_10;
		}
		if (string_10.Contains("locale="))
		{
			return Regex.Replace(string_10, "locale=[^&]*", "locale=en_US");
		}
		if (string_10.EndsWith("#"))
		{
			string_10 = string_10.TrimEnd('#');
		}
		if (string_10.Contains("?"))
		{
			return string_10 + "&locale=en_US";
		}
		return string_10 + "?locale=en_US";
	}

	public void method_12(string string_10, bool FC3A841F = false)
	{
		string_10 = NormalizeFacebookUrl(string_10);
		bool flag = false;
		if (FC3A841F)
		{
			string_10 = method_11(string_10);
		}
		for (int i = 0; i < 2 && !CD930D04() && !E184CD03(); i++)
		{
			try
			{
				if (i == 0)
				{
					ChromeDriver_0.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5.0);
				}
				else
				{
					ChromeDriver_0.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60.0);
				}
				ChromeDriver_0.Navigate().GoToUrl(string_10);
				flag = true;
			}
			catch (Exception exception_)
			{
				method_46(exception_);
				string exMsg = exception_?.Message ?? "";
				if ((exMsg.Contains("ERR_CONNECTION_REFUSED") || exMsg.Contains("ERR_TIMED_OUT") || exMsg.Contains("ERR_NAME_NOT_RESOLVED") || exMsg.Contains("Timeout"))
				    && (string_10.Contains("mobile.facebook.com") || string_10.Contains("mbasic.facebook.com")))
				{
					try
					{
						string fallbackUrl = "https://www.facebook.com/";
						ChromeDriver_0.Navigate().GoToUrl(fallbackUrl);
						flag = true;
						break;
					}
					catch { }
				}
				continue;
			}
			break;
		}
		ChromeDriver_0.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60.0);
		if (flag && !CD930D04())
		{
			try
			{
				string currentUrl = GetURL();
				bool isDeadDomain = currentUrl.Contains("mobile.facebook.com") || currentUrl.Contains("mbasic.facebook.com");
				bool isHttp400OrError = false;

				try
				{
					string title = ChromeDriver_0.Title;
					if (!string.IsNullOrEmpty(title) && (title.Contains("400") || title.IndexOf("Bad Request", StringComparison.OrdinalIgnoreCase) >= 0 || title.IndexOf("Site can’t be reached", StringComparison.OrdinalIgnoreCase) >= 0 || title.IndexOf("Site can't be reached", StringComparison.OrdinalIgnoreCase) >= 0))
					{
						isHttp400OrError = true;
					}
				}
				catch { }

				if (!isHttp400OrError)
				{
					try
					{
						string bodySnippet = RunCodeChrome("document.body ? (document.body.innerText || '').substring(0, 500) : ''");
						if (!string.IsNullOrEmpty(bodySnippet) && (bodySnippet.Contains("400 Bad Request") || bodySnippet.Contains("HTTP ERROR 400") || bodySnippet.IndexOf("Bad Request", StringComparison.OrdinalIgnoreCase) >= 0))
						{
							isHttp400OrError = true;
						}
					}
					catch { }
				}

				if (isDeadDomain || (isHttp400OrError && currentUrl.Contains("facebook.com")))
				{
					string safeUrl = "https://www.facebook.com/";
					if (!string.IsNullOrEmpty(currentUrl) && currentUrl.Contains("facebook.com"))
					{
						safeUrl = NormalizeFacebookUrl(currentUrl);
						if (safeUrl.Contains("mobile.facebook.com") || safeUrl.Contains("mbasic.facebook.com"))
						{
							safeUrl = "https://www.facebook.com/";
						}
					}
					ChromeDriver_0.Navigate().GoToUrl(safeUrl);
				}
			}
			catch (Exception exNav)
			{
				method_46(exNav);
			}

			method_82();
			method_59();
			DismissFacebookPopups();
		}
	}

	public void method_13()
	{
		try
		{
			ChromeDriver_0.Navigate().Refresh();
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
	}

	public void F7221F34(int int_4 = 1)
	{
		try
		{
			for (int i = 0; i < int_4; i++)
			{
				if (CD930D04())
				{
					break;
				}
				if (E184CD03())
				{
					break;
				}
				ChromeDriver_0.Navigate().Back();
				F8091028(1.0);
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.GotoBackPage()");
		}
	}

	public string method_14(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		try
		{
			string text = ChromeDriver_0.ExecuteScript(string_10)?.ToString();
			return text ?? "";
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return "";
	}

	public string method_15(double double_1, List<string> D7892609)
	{
		if (CD930D04() || E184CD03() || D7892609 == null || D7892609.Count == 0)
		{
			return "";
		}
		try
		{
			int tickCount = Environment.TickCount;
			while (true)
			{
				for (int i = 0; i < D7892609.Count; i++)
				{
					string sel = D7892609[i];
					if (string.IsNullOrEmpty(sel)) continue;
					try
					{
						string dom = A7B8E3A5(sel);
						string res = method_14("return " + dom + "!=null;");
						if (res.ToLower() == "true")
						{
							return sel;
						}
					}
					catch { }
				}

				if (!((double)(Environment.TickCount - tickCount) >= double_1 * 1000.0))
				{
					Thread.Sleep(500);
					continue;
				}
				break;
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return "";
	}

	public bool method_16(int int_4, string[] string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		string text = method_15(int_4, string_10.ToList());
		if (text == "")
		{
			return false;
		}
		bool result;
		if (!(result = method_18(text)))
		{
			result = method_21(text);
		}
		return result;
	}

	public bool DA2A8C96(int int_4 = 0, params string[] string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		string text = method_15(int_4, string_10.ToList());
		if (text == "")
		{
			return false;
		}
		return method_21(text);
	}

	public bool E11EB838(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement onElement = ChromeDriver_0.FindElement(By.CssSelector(string_10));
			new Actions(ChromeDriver_0).Click(onElement).Perform();
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_17(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		if (!method_18(string_10))
		{
			return method_21(string_10);
		}
		return true;
	}

	public IWebElement A022661F(string string_10)
	{
		if (B1A19F3D(string_10))
		{
			return ChromeDriver_0.FindElement(By.XPath(string_10));
		}
		string cssSelectorToFind = "";
		string text = "";
		int index = 0;
		int index2 = 0;
		string[] array = string_10.Split('|');
		switch (array.Length)
		{
		case 1:
			cssSelectorToFind = array[0].Trim();
			break;
		case 2:
			cssSelectorToFind = array[0].Trim();
			index = Convert.ToInt32(array[1].Trim());
			break;
		case 3:
			cssSelectorToFind = array[0].Trim();
			index = Convert.ToInt32(array[1].Trim());
			text = array[2].Trim();
			break;
		case 4:
			cssSelectorToFind = array[0].Trim();
			index = Convert.ToInt32(array[1].Trim());
			text = array[2].Trim();
			index2 = Convert.ToInt32(array[3].Trim());
			break;
		}
		if (text == "")
		{
			return ChromeDriver_0.FindElements(By.CssSelector(cssSelectorToFind))[index];
		}
		return ChromeDriver_0.FindElements(By.CssSelector(cssSelectorToFind))[index].FindElements(By.CssSelector(text))[index2];
	}

	public bool method_18(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(string_10);
			webElement.Click();
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_19(string D88CF43E)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			method_20(D88CF43E);
			return method_18(D88CF43E);
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_20(string AA32FEA9, int B59A84BE = 1)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			if (!method_34(AA32FEA9))
			{
				return false;
			}
			F8091028(B59A84BE);
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_21(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			ChromeDriver_0.ExecuteScript(A7B8E3A5(string_10) + ".click()");
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool B623741C(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		method_14(A7B8E3A5(string_10) + ".play()");
		return true;
	}

	public bool method_22(string string_10, string string_11)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			string_11 = Commom.smethod_31(string_11);
			IWebElement webElement = A022661F(string_10);
			if (webElement == null)
			{
				return false;
			}

			string tagName = "";
			string isCe = "";
			try
			{
				tagName = (webElement.TagName ?? "").ToLower();
				isCe = (webElement.GetAttribute("contenteditable") ?? "").ToLower();
			}
			catch { }

			if (isCe == "true" || tagName == "div")
			{
				bool pasted = false;
				try
				{
					webElement.Click();
					F8091028(0.2);
					webElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
					F8091028(0.1);

					Thread staThread = new Thread(() =>
					{
						try
						{
							Clipboard.Clear();
							Clipboard.SetDataObject(string_11, true, 5, 100);
						}
						catch { }
					});
					staThread.SetApartmentState(ApartmentState.STA);
					staThread.IsBackground = true;
					staThread.Start();
					staThread.Join(1000);

					webElement.SendKeys(OpenQA.Selenium.Keys.Control + "v");
					F8091028(0.3);
					pasted = true;
				}
				catch { }

				if (!pasted && ChromeDriver_0 != null)
				{
					ChromeDriver_0.ExecuteScript(@"
						var el = arguments[0];
						var val = arguments[1];
						el.focus();
						if (document.queryCommandSupported && document.queryCommandSupported('insertText')) {
							document.execCommand('insertText', false, val);
						} else {
							el.innerText = val;
							el.dispatchEvent(new Event('input', { bubbles: true }));
							el.dispatchEvent(new Event('change', { bubbles: true }));
						}
					", webElement, string_11);
				}
				return true;
			}

			if (Commom.A01DE9AB(string_11))
			{
				method_18(string_10);
				if (ChromeDriver_0 != null)
				{
					ChromeDriver_0.ExecuteScript(@"
						var el = arguments[0];
						var val = arguments[1];
						var proto = (el.tagName === 'TEXTAREA') ? window.HTMLTextAreaElement.prototype : window.HTMLInputElement.prototype;
						var desc = Object.getOwnPropertyDescriptor(proto, 'value');
						if (desc && desc.set) {
							desc.set.call(el, val);
						} else {
							el.value = val;
						}
						el.dispatchEvent(new Event('input', { bubbles: true }));
						el.dispatchEvent(new Event('change', { bubbles: true }));
					", webElement, string_11);
				}
				else
				{
					string_11 = string_11.Replace("\r\n", "*rr*nn").Replace("\n", "*rr*nn");
					string_11 = string_11.Replace("*rr*nn", "\\r\\n").Replace("\"", "\\\"");
					method_14(A7B8E3A5(string_10) + ".value=\"" + string_11 + "\"");
				}
				webElement.SendKeys(" ");
			}
			else
			{
				try
				{
					if (ChromeDriver_0 != null && !CD930D04() && !E184CD03())
					{
						HumanTyping.TypeLikeHuman(ChromeDriver_0, webElement, string_11, 15, 45);
					}
					else
					{
						webElement.SendKeys(string_11);
					}
				}
				catch
				{
					webElement.SendKeys(string_11);
				}
				if (string_11.Contains(" "))
				{
					webElement.SendKeys(" ");
				}
			}
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_23(string F209B519, string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		method_14(A7B8E3A5(F209B519) + ".value = '" + string_10.Replace("'", "\\'") + "'");
		return true;
	}

	public bool AE3408BC(string string_10, string string_11, bool E01F871E = false)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		string_10 = method_3(string_10);
		string_11 = method_3(string_11);
		string text = RunCodeChrome("SendKeys2('" + string_10 + "','" + string_11 + "', " + method_4(E01F871E) + ")");
		return text.ToLower() == "true";
	}

	public bool method_24(string string_10, string string_11)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(string_10);
			webElement.SendKeys(string_11);
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool F217FA96(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(string_10);
			webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public string method_25(string url, string currentUrl = "")
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		if (currentUrl == "")
		{
			currentUrl = GetURL();
		}
		string newValue = GetDomainFb(currentUrl);
		string oldValue = GetDomainFb(url);
		return url.Replace(oldValue, newValue);
	}

	public string GetDomainFb(string string_10 = "")
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		if (string_10 == "")
		{
			string_10 = GetURL();
		}
		return Regex.Match(string_10, "https://(.*?)facebook.com").Value;
	}

	public string GetLinkFromId(string IdOrLink, string domainFb = "https://www.facebook.com")
	{
		return RunCodeChrome("GetLinkFromId('" + IdOrLink + "','" + domainFb + "')");
	}

	public bool method_27(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		string_10 = method_3(string_10);
		string text = RunCodeChrome("IsElementVisible('" + string_10 + "')");
		return text == "true";
	}

	public bool method_28(string string_10, string string_11, double double_1, bool C1BF9231 = true, double double_2 = 0.1)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			if (C1BF9231)
			{
				method_18(string_10);
				F8091028(double_2);
				EB2B3FB0(string_10);
			}
			switch (C5034B95.smethod_0("configGeneral").method_2("tocDoGoVanBan"))
			{
			case 2:
				ChromeDriver_0.FindElement(By.CssSelector(string_10)).SendKeys(string_11);
				break;
			case 0:
			case 1:
			{
				IWebElement webElement = A022661F(string_10);
				for (int i = 0; i < string_11.Length; i++)
				{
					webElement.SendKeys(string_11[i].ToString());
					if (double_1 > 0.0)
					{
						int num = Convert.ToInt32(double_1 * 1000.0);
						if (num < 100)
						{
							num = 100;
						}
						Thread.Sleep(Base.rd.Next(num, num + 50));
					}
				}
				break;
			}
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_);
			return false;
		}
		return true;
	}

	public bool F9820F3E(string BA3D1E2C)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(BA3D1E2C);
			webElement.SendKeys(OpenQA.Selenium.Keys.Backspace);
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_29(string B91FD9AA)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(B91FD9AA);
			webElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool EB2B3FB0(string CB3F1A9D)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			IWebElement webElement = A022661F(CB3F1A9D);
			webElement.Clear();
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool EEB5149C(string AE1DB21B)
	{
		if (CD930D04())
		{
			return false;
		}
		method_29(AE1DB21B);
		F9820F3E(AE1DB21B);
		return true;
	}

	public int method_30(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return 0;
		}
		int result = 0;
		try
		{
			result = ((!B1A19F3D(string_10)) ? Convert.ToInt32(ChromeDriver_0.ExecuteScript("return document.querySelectorAll('" + string_10.Replace("'", "\\'") + "').length+''").ToString()) : Convert.ToInt32(ChromeDriver_0.ExecuteScript("return document.evaluate('count(" + string_10.Replace("'", "\\'") + ")', document, null, XPathResult.NUMBER_TYPE, null).numberValue").ToString()));
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return result;
	}

	public bool method_31(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		method_14(A7B8E3A5(string_10) + ".remove();");
		return true;
	}

	public bool D7A424AE(string string_10, double double_1 = 0.0)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			string text = A7B8E3A5(string_10);
			int tickCount = Environment.TickCount;
			while (true)
			{
				if (!(method_14("return " + text + "!=null").ToLower() == "true"))
				{
					if (!CD930D04() && !E184CD03())
					{
						if (!((double)(Environment.TickCount - tickCount) >= double_1 * 1000.0))
						{
							F8091028(1.0);
							continue;
						}
						break;
					}
					return false;
				}
				return true;
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool E821BD02(string string_10, double double_1 = 0.0)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		string_10 = string_10.ToLower();
		return D7A424AE("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"" + string_10 + "\"]", double_1);
	}

	public bool method_32(int int_4, int int_5)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		method_14($"window.scrollTo({{ left: {int_4}, top: {int_5}, behavior: 'smooth' }});");
		return true;
	}

	public bool method_33(string F939F393, int AA8B9D12)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			string text = A7B8E3A5(F939F393);
			int tickCount = Environment.TickCount;
			while (true)
			{
				if (!(method_14("return " + text + "!=null").ToLower() == "false"))
				{
					if (!CD930D04() && !E184CD03())
					{
						if (Environment.TickCount - tickCount < AA8B9D12 * 1000)
						{
							F8091028(1.0);
							continue;
						}
						break;
					}
					return false;
				}
				return true;
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public bool method_34(string D8164E38)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		method_14(A7B8E3A5(D8164E38) + ".scrollIntoView({ behavior: 'smooth', block: 'center'});");
		return true;
	}

	public bool method_35(string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		if (!method_36(string_10))
		{
			return method_34(string_10);
		}
		return true;
	}

	public bool method_36(string EDB13716, int int_4 = 0)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		EDB13716 = method_3(EDB13716);
		string text = RunCodeChrome($"IsElementOnScreen('{EDB13716}',{int_4})");
		return text.ToLower() == "true";
	}

	public bool A4B307B3(int C123C431 = 10)
	{
		try
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				try
				{
					if (class59_0 != null)
					{
						class59_0.method_3();
					}
					ChromeDriver_0.Quit();
					if (class59_0 != null && class59_0.C1B1B61F.StartsWith("temp_"))
					{
						Class59.smethod_3(class59_0.C61C311D);
					}
				}
				catch (Exception)
				{
				}
			});
			thread.IsBackground = true;
			thread.Start();
			if (!thread.Join(C123C431 * 1000))
			{
				thread.Abort();
			}
		}
		catch
		{
		}
		try
		{
			// Diet sach toan bo cay tien trinh Chrome va ChromeDriver bang taskkill /T /F chong orphan
			if (Process_1 != null)
			{
				try
				{
					int p1Id = Process_1.Id;
					if (!Process_1.HasExited)
					{
						var psi = new ProcessStartInfo("taskkill", $"/pid {p1Id} /T /F") { CreateNoWindow = true, UseShellExecute = false };
						Process.Start(psi)?.WaitForExit(1500);
					}
				}
				catch {}
			}
			if (Process_0 != null)
			{
				try
				{
					int p0Id = Process_0.Id;
					if (!Process_0.HasExited)
					{
						var psi = new ProcessStartInfo("taskkill", $"/pid {p0Id} /T /F") { CreateNoWindow = true, UseShellExecute = false };
						Process.Start(psi)?.WaitForExit(1500);
					}
				}
				catch {}
			}
		}
		catch
		{
		}
		Process_0 = null;
		Process_1 = null;
		Boolean_5 = true;
		try
		{
			if (!string.IsNullOrEmpty(String_1))
			{
				PruneProfileSafeCache(String_1);
			}
		}
		catch
		{
		}
		if (!PreserveSession && !string.IsNullOrEmpty(String_1.Trim()) && C5034B95.smethod_0("configInteractGeneral").method_3("ckbXoaProfile"))
		{
			for (int i = 0; i < 10; i++)
			{
				if (Commom.DeleteFolder(String_1))
				{
					break;
				}
				Commom.smethod_52(1.0);
			}
		}
		return true;
	}

	/// <summary>
	/// Instance helper to safely prune temporary caches of this Chrome instance's profile.
	/// </summary>
	public void PruneProfileSafeCache()
	{
		PruneProfileSafeCache(String_1);
	}

	/// <summary>
	/// Safely prunes ONLY temporary Chrome caches (RAM and disk space optimization)
	/// without affecting login sessions, cookies, or user profile data.
	/// STRICT SAFETY RULE: NEVER touch Cookies, Network\Cookies, Local Storage, IndexedDB, Preferences, Login Data, Web Data.
	/// </summary>
	public static void PruneProfileSafeCache(string profilePath)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(profilePath)) return;
			string fullProfilePath = Path.GetFullPath(profilePath);
			if (!Directory.Exists(fullProfilePath)) return;

			// Target directories to safely prune
			string[] safeCacheSubDirs = new string[]
			{
				@"Default\Cache",
				@"Default\Code Cache",
				@"Default\GPUCache",
				@"Default\DawnCache",
				@"Default\DawnGraphiteCache",
				@"Default\DawnWebGPUCache",
				@"Default\Service Worker\CacheStorage",
				@"Default\Service Worker\ScriptCache",
				@"GrShaderCache",
				@"ShaderCache",
				@"Crashpad",
				@"Default\Crashpad"
			};

			List<string> baseRoots = new List<string> { fullProfilePath };
			string nestedDataProfile = Path.Combine(fullProfilePath, "Data", "profile");
			if (Directory.Exists(nestedDataProfile))
			{
				baseRoots.Add(nestedDataProfile);
			}

			foreach (string baseDir in baseRoots)
			{
				// 1. Delete temporary cache directories
				foreach (string subDir in safeCacheSubDirs)
				{
					try
					{
						string fullDirPath = Path.Combine(baseDir, subDir);
						if (!Directory.Exists(fullDirPath)) continue;

						if (IsSafeCacheProtected(fullDirPath, fullProfilePath)) continue;

						SafeDeleteDirectory(fullDirPath, fullProfilePath);
					}
					catch
					{
					}
				}

				// 2. Safely delete *.tmp temporary files
				string[] scanFolders = new string[] { baseDir, Path.Combine(baseDir, "Default") };
				foreach (string folder in scanFolders)
				{
					try
					{
						if (!Directory.Exists(folder)) continue;
						string[] tmpFiles = Directory.GetFiles(folder, "*.tmp", SearchOption.TopDirectoryOnly);
						foreach (string tmpFile in tmpFiles)
						{
							try
							{
								if (!IsSafeCacheProtected(tmpFile, fullProfilePath))
								{
									File.SetAttributes(tmpFile, FileAttributes.Normal);
									File.Delete(tmpFile);
								}
							}
							catch
							{
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
	}

	private static bool IsSafeCacheProtected(string targetPath, string profileRoot)
	{
		if (string.IsNullOrWhiteSpace(targetPath)) return true;

		try
		{
			string normTarget = Path.GetFullPath(targetPath).TrimEnd('\\', '/');
			string normRoot = Path.GetFullPath(profileRoot).TrimEnd('\\', '/');

			// Never delete profile root or Default root
			if (normTarget.Equals(normRoot, StringComparison.OrdinalIgnoreCase)) return true;
			string defaultRoot = Path.Combine(normRoot, "Default");
			if (normTarget.Equals(defaultRoot, StringComparison.OrdinalIgnoreCase)) return true;

			string fileName = Path.GetFileName(normTarget);
			if (!string.IsNullOrEmpty(fileName))
			{
				// STRICT SAFETY RULE: NEVER touch Cookies, Preferences, Login Data, Web Data, Local State
				if (fileName.Equals("Cookies", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Cookies-", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Cookies.", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Preferences", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Preferences.", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Secure Preferences", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Secure Preferences.", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Login Data", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Login Data-", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Login Data.", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Web Data", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Web Data-", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Web Data.", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Local State", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Local State.", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("History", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("History-", StringComparison.OrdinalIgnoreCase) ||
					fileName.Equals("Bookmarks", StringComparison.OrdinalIgnoreCase) ||
					fileName.StartsWith("Bookmarks.", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			// Check directory segments: NEVER touch Cookies, Network\Cookies, Local Storage, IndexedDB, Session Storage
			string relative = normTarget;
			if (normTarget.StartsWith(normRoot, StringComparison.OrdinalIgnoreCase))
			{
				relative = normTarget.Substring(normRoot.Length).TrimStart('\\', '/');
			}

			string[] segments = relative.Split(new char[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string seg in segments)
			{
				if (seg.Equals("Cookies", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Network", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Local Storage", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("IndexedDB", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Session Storage", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Sessions", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Accounts", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Sync Data", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Extensions", StringComparison.OrdinalIgnoreCase) ||
					seg.Equals("Extension State", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		catch
		{
			return true;
		}

		return false;
	}

	private static void SafeDeleteDirectory(string dirPath, string profileRoot)
	{
		try
		{
			if (!Directory.Exists(dirPath) || IsSafeCacheProtected(dirPath, profileRoot)) return;

			// Non-blocking file deletion
			string[] files;
			try
			{
				files = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
			}
			catch
			{
				files = new string[0];
			}

			foreach (string file in files)
			{
				try
				{
					if (!IsSafeCacheProtected(file, profileRoot))
					{
						File.SetAttributes(file, FileAttributes.Normal);
						File.Delete(file);
					}
				}
				catch
				{
				}
			}

			// Delete empty subdirectories bottom-up
			string[] subDirs;
			try
			{
				subDirs = Directory.GetDirectories(dirPath, "*", SearchOption.AllDirectories)
					.OrderByDescending(d => d.Length)
					.ToArray();
			}
			catch
			{
				subDirs = new string[0];
			}

			foreach (string subDir in subDirs)
			{
				try
				{
					if (!IsSafeCacheProtected(subDir, profileRoot))
					{
						Directory.Delete(subDir, false);
					}
				}
				catch
				{
				}
			}

			try
			{
				Directory.Delete(dirPath, false);
			}
			catch
			{
			}
		}
		catch
		{
		}
	}

	public bool method_37()
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			new Actions(ChromeDriver_0).KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(OpenQA.Selenium.Keys.ArrowUp).SendKeys(OpenQA.Selenium.Keys.ArrowUp)
				.SendKeys(OpenQA.Selenium.Keys.ArrowUp)
				.SendKeys(OpenQA.Selenium.Keys.Delete)
				.KeyUp(OpenQA.Selenium.Keys.Shift)
				.Build()
				.Perform();
		}
		catch (Exception exception_)
		{
			method_46(exception_);
			return false;
		}
		return true;
	}

	public int method_38(string string_10, string BBA1401C)
	{
		bool flag = false;
		if (CD930D04() || E184CD03())
		{
			return -2;
		}
		try
		{
			Screenshot screenshot = ((ITakesScreenshot)ChromeDriver_0).GetScreenshot();
			screenshot.SaveAsFile(string_10 + (string_10.EndsWith("\\") ? "" : "\\") + BBA1401C + ".png");
			flag = true;
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.ScreenCapture(" + string_10 + "," + BBA1401C + ")");
		}
		return flag ? 1 : 0;
	}

	public bool method_39(string C0B9E0A0, string DE09EC8A = ".facebook.com")
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			string[] array = C0B9E0A0.Split(';');
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Trim() != "")
				{
					string[] array3 = text.Split('=');
					if (array3.Count() > 1 && array3[0].Trim() != "")
					{
						OpenQA.Selenium.Cookie cookie = null;
						cookie = new OpenQA.Selenium.Cookie(array3[0].Trim(), text.Substring(text.IndexOf('=') + 1).Trim(), DE09EC8A, "/", DateTime.Now.AddDays(10.0));
						ChromeDriver_0.Manage().Cookies.AddCookie(cookie);
					}
				}
			}
			BE160BA0("i_user");
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.AddCookieIntoChrome(" + C0B9E0A0 + "," + DE09EC8A + ")");
		}
		return false;
	}

	public bool BE160BA0(string A5312207)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			ChromeDriver_0.Manage().Cookies.DeleteCookieNamed(A5312207);
			return true;
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
		return false;
	}

	public string method_40(string string_10 = "facebook")
	{
		string text = "";
		try
		{
			OpenQA.Selenium.Cookie[] array = ChromeDriver_0.Manage().Cookies.AllCookies.ToArray();
			OpenQA.Selenium.Cookie[] array2 = array;
			foreach (OpenQA.Selenium.Cookie cookie in array2)
			{
				if (cookie.Domain.Contains(string_10))
				{
					text = text + cookie.Name + "=" + cookie.Value + ";";
				}
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.GetCookieFromChrome(" + string_10 + ")");
		}
		return text;
	}

	public string FB94939A()
	{
		return Regex.Match(method_40(), "c_user=(\\d+)").Groups[1].Value;
	}

	public string method_41()
	{
		return method_66("Getfb_dtsg");
	}

	public bool method_42(string string_10 = "", bool D709A3A9 = true)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			method_14("window.open('" + string_10 + "', '_blank').focus();");
			if (D709A3A9)
			{
				ChromeDriver_0.SwitchTo().Window(ChromeDriver_0.WindowHandles.Last());
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_, $"chrome.OpenNewTab({string_10},{D709A3A9})");
			return false;
		}
		return true;
	}

	public bool B810BF0C()
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			ChromeDriver_0.Close();
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.CloseCurrentTab()");
			return false;
		}
		return true;
	}

	public bool method_43()
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			ChromeDriver_0.SwitchTo().Window(ChromeDriver_0.WindowHandles.First());
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.SwitchToFirstTab()");
			return false;
		}
		return true;
	}

	public bool method_44()
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			ChromeDriver_0.SwitchTo().Window(ChromeDriver_0.WindowHandles.Last());
		}
		catch (Exception exception_)
		{
			method_46(exception_, "chrome.SwitchToLastTab()");
			return false;
		}
		return true;
	}

	public void F8091028(double double_1)
	{
		double_1 = Math.Floor(double_1);
		for (int i = 0; (double)i < double_1; i++)
		{
			if (CD930D04())
			{
				break;
			}
			if (E184CD03())
			{
				break;
			}
			Commom.smethod_52(1.0);
		}
	}

	public void method_45(int F8079B95, int F1ADBDB8)
	{
		int num = method_50(F8079B95, F1ADBDB8);
		F8091028(num);
	}

	public void method_46(Exception exception_0, string string_10 = "")
	{
		try
		{
			if (exception_0 != null)
			{
				string exStr = exception_0.ToString();
				if (exStr.Contains("timed out") || exStr.Contains("disconnected") || exStr.Contains("Unable to connect to the remote server") || exStr.Contains("target window already closed") || exStr.Contains("ERR_PROXY_CONNECTION_FAILED") || exStr.Contains("ERR_TUNNEL_CONNECTION_FAILED"))
				{
					Boolean_5 = true;
				}
			}
			if (!(string_10 == "chrome.Open()"))
			{
				return;
			}
			if (!Directory.Exists("log"))
			{
				Directory.CreateDirectory("log");
			}
			if (!Directory.Exists("log\\html"))
			{
				Directory.CreateDirectory("log\\html");
			}
			if (!Directory.Exists("log\\images"))
			{
				Directory.CreateDirectory("log\\images");
			}
			Random random = new Random();
			string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + random.Next(1000, 9999);
			if (ChromeDriver_0 != null)
			{
				string contents = method_14("var markup = document.documentElement.innerHTML;return markup;").ToString();
				method_38("log\\images\\", text);
				File.WriteAllText("log\\html\\" + text + ".html", contents);
			}
			using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
			streamWriter.WriteLine("-----------------------------------------------------------------------------");
			streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
			streamWriter.WriteLine("File: " + text);
			if (string_10 != "")
			{
				streamWriter.WriteLine("Error: " + string_10);
			}
			streamWriter.WriteLine();
			if (exception_0 != null)
			{
				streamWriter.WriteLine("Type: " + exception_0.GetType().FullName);
				streamWriter.WriteLine("Message: " + exception_0.Message);
				streamWriter.WriteLine("StackTrace: " + exception_0.StackTrace);
				exception_0 = exception_0.InnerException;
			}
		}
		catch
		{
		}
	}

	public bool method_47(string AC18AC19, string string_10)
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			new SelectElement(ChromeDriver_0.FindElement(By.CssSelector(AC18AC19))).SelectByValue(string_10);
		}
		catch (Exception exception_)
		{
			method_46(exception_);
			return false;
		}
		return true;
	}

	public void B63706AA()
	{
		int num = ChromeDriver_0.WindowHandles.Count();
		if (num > 1)
		{
			for (int i = 0; i < num - 1; i++)
			{
				method_43();
				B810BF0C();
			}
			method_43();
		}
	}

	public void DC9244BF()
	{
		int num = ChromeDriver_0.WindowHandles.Count();
		if (num > 1)
		{
			for (int i = 0; i < num - 1; i++)
			{
				method_44();
				B810BF0C();
			}
			method_43();
		}
	}

	private bool A3A60133()
	{
		try
		{
			if (Process_0 != null && !Process_0.HasExited)
			{
				return true;
			}
			if (Process_1 != null && !Process_1.HasExited)
			{
				List<int> childPids = Commom.GetChildProcessIds(Process_1.Id);
				foreach (int pid in childPids)
				{
					try
					{
						Process child = Process.GetProcessById(pid);
						if (!child.HasExited && child.ProcessName.ToLower().Contains("chrome"))
						{
							Process_0 = child;
							return true;
						}
					}
					catch {}
				}
			}
			B63706AA();
			string string_0 = "";
			for (int i = 0; i < 10; i++)
			{
				if (E184CD03())
				{
					break;
				}
				try
				{
					try
					{
						string_0 = ChromeDriver_0.CurrentWindowHandle;
					}
					catch
					{
						string_0 = Commom.B820DC86(15, "a_A_0");
					}
					if (string_0 != "")
					{
						for (int j = 0; j < 3; j++)
						{
							method_14("document.title='" + string_0 + "'");
							F8091028(1.0);
							Process_0 = (from A21A0E2E in Process.GetProcessesByName("chrome")
								where A21A0E2E.MainWindowTitle.Contains(string_0)
								select A21A0E2E).FirstOrDefault();
							if (Process_0 != null)
							{
								return true;
							}
						}
						DC9244BF();
					}
				}
				catch (Exception exception_)
				{
					method_46(exception_);
				}
				F8091028(1.0);
			}
		}
		catch (Exception exception_2)
		{
			method_46(exception_2);
		}
		return false;
	}

	public bool A084051A()
	{
		string text = GetURL();
		if (text.Contains("checkpoint/disabled"))
		{
			return false;
		}
		string text2 = GetDomainFb(text);
		text = method_14("async function Request(){try{let a=await fetch(\"" + text2 + "/me\"),b=\"\";return a.ok&&(b=a.url),b}catch{}}var c=await Request();return c").ToString();
		if (text.Contains("checkpoint/disabled") || text.Contains("828281030927956") || text.Contains("1501092823525282"))
		{
			return false;
		}
		bool flag = false;
		List<string> list = method_14("arrAction = []; document.querySelectorAll('form[method]').forEach(e => arrAction.push(e.getAttribute('action'))); return arrAction.join('|');").ToString().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			if (!list[i].StartsWith("/a/home.php?") && !list[i].StartsWith("/search/?") && !list[i].StartsWith("/composer/mbasic/?"))
			{
				if (list[i].Equals("/logout.php?button_location=settings&button_name=logout") && CommonRequest.BC9215A7(B4208531).StartsWith("1"))
				{
					flag = true;
					break;
				}
				continue;
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			text2 = GetDomainFb();
			string text3 = C604C58C(text2 + "/home.php").ToString();
			flag = text3.Contains("href=\"/menu/bookmarks/") && text3.Contains("id=\"mbasic_logout_button\"");
		}
		return flag;
	}

	public string C604C58C(string string_10)
	{
		string_10 = NormalizeFacebookUrl(string_10);
		return AccountInfoAutomationHelper.ExecuteBrowserFetch(this, string_10, "GET", null);
	}

	public string method_48(string string_10, string string_11)
	{
		string_10 = NormalizeFacebookUrl(string_10);
		return AccountInfoAutomationHelper.ExecuteBrowserFetch(this, string_10, "POST", string_11);
	}

	public int method_49(string string_10 = "en_US")
	{
		string text = "";
		for (int i = 0; i < 3; i++)
		{
			text = RunCodeChrome("SetFbLanguage('" + string_10 + "')");
			if (!(text == "0"))
			{
				break;
			}
		}
		return Convert.ToInt32(text);
	}

	public int method_50(int int_4, int F4960BA6)
	{
		return Base.rd.Next(int_4, F4960BA6 + 1);
	}

	public void method_51(int int_4 = 0, int D9A54580 = 0)
	{
		if (!CD930D04() && !E184CD03())
		{
			try
			{
				CF366839 = ChromeDriver_0.Manage().Window.Position.X;
				DF91F13B = ChromeDriver_0.Manage().Window.Position.Y;
				ChromeDriver_0.Manage().Window.Position = new Point(int_4, D9A54580);
			}
			catch (Exception exception_)
			{
				method_46(exception_);
			}
		}
	}

	public void method_52()
	{
		if (!CD930D04() && !E184CD03())
		{
			try
			{
				ChromeDriver_0.Manage().Window.Position = new Point(CF366839, DF91F13B);
			}
			catch (Exception exception_)
			{
				method_46(exception_);
			}
		}
	}

	public void method_53(int int_4 = 500, int int_5 = 700)
	{
		if (int_4 < F5BA98AC.X && int_5 < F5BA98AC.Y)
		{
			return;
		}
		if (int_4 >= 500 && int_5 >= 700)
		{
			bool_7 = true;
		}
		if (CD930D04() || E184CD03())
		{
			return;
		}
		try
		{
			AA3B0EAA = ChromeDriver_0.Manage().Window.Size.Width;
			FC8813AF = ChromeDriver_0.Manage().Window.Size.Height;
			ChromeDriver_0.Manage().Window.Size = new Size(int_4, int_5);
			if (bool_1)
			{
				method_51(-10, -30);
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
	}

	public void method_54()
	{
		if ((AA3B0EAA < F5BA98AC.X && FC8813AF < F5BA98AC.Y) || CD930D04() || E184CD03())
		{
			return;
		}
		try
		{
			ChromeDriver_0.Manage().Window.Size = new Size(AA3B0EAA, FC8813AF);
			if (bool_1)
			{
				method_51(-10, -30);
			}
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
	}

	internal string method_55(string string_10)
	{
		string text = "";
		List<string> list = new List<string> { "Like", "Love", "Care", "Haha", "Wow", "Sad", "Angry" };
		try
		{
			int index = Convert.ToInt32(string_10.Split('|').ToList().smethod_8());
			text = list[index];
		}
		catch (Exception)
		{
			text = list.First();
		}
		return $"//*[@aria-label=\"Reactions\" and not(ancestor::*/@hidden)]//*[contains(@aria-label,\"{text}\")]";
	}

	private List<string> EF32BE86(List<string> EE81D6BC)
	{
		List<string> list_1 = new List<string>();
		try
		{
			int F1385F89 = 0;
			int num = ((EE81D6BC.Count < 100) ? EE81D6BC.Count : 100);
			string B3ACAC34 = method_40();
			string CF01B21E = method_9();
			string string_0 = A3A32284;
			int DE1F8939 = Int32_1;
			int num2 = 0;
			while (num2 < EE81D6BC.Count)
			{
				if (F1385F89 < num)
				{
					Interlocked.Increment(ref F1385F89);
					int int_0 = num2++;
					Thread thread = new Thread((ThreadStart)delegate
					{
						try
						{
							bool flag = false;
							string text = EE81D6BC[int_0].Split('|')[0];
							RequestXNet requestXNet = new RequestXNet(B3ACAC34, CF01B21E, string_0, DE1F8939);
							string text2 = requestXNet.E58EB99F("https://m.facebook.com/groups/" + text + "/madminpanel");
							if (text2.Contains("/help/contact/571927962827151") || text2.Contains("madminpanel/pending/"))
							{
								flag = true;
							}
							lock (list_1)
							{
								list_1.Add(EE81D6BC[int_0] + "|" + flag);
							}
						}
						catch
						{
						}
						Interlocked.Decrement(ref F1385F89);
					});
					thread.IsBackground = true;
					thread.Start();
				}
				else
				{
					Application.DoEvents();
					Thread.Sleep(200);
				}
			}
			while (F1385F89 > 0)
			{
				Application.DoEvents();
				Thread.Sleep(1000);
			}
		}
		catch
		{
		}
		return list_1;
	}

	public List<string> method_56(bool bool_9)
	{
		List<string> list = new List<string>();
		try
		{
			method_40();
			string text = FB94939A();
			if (!bool_9)
			{
				string input = C604C58C(GetDomainFb() + "/help/");
				string value = Regex.Match(input, Commom.smethod_50("ImR0c2dfYWciOnsidG9rZW4iOiIoLio/KSI=")).Groups[1].Value;
				if (value == "")
				{
					value = Regex.Match(input, "\"async_get_token\":\"(.*?)\"").Groups[1].Value;
				}
				if (value == "")
				{
					input = C604C58C("https://www.facebook.com/help");
					value = Regex.Match(input, Commom.smethod_50("ImR0c2dfYWciOnsidG9rZW4iOiIoLio/KSI=")).Groups[1].Value;
					if (value == "")
					{
						value = Regex.Match(input, "\"async_get_token\":\"(.*?)\"").Groups[1].Value;
					}
				}
				string string_ = "https://www.facebook.com/ajax/typeahead/first_degree.php?fb_dtsg_ag=" + value + "&filter%5B0%5D=group&viewer=" + text + "&__user=" + text + "&__a=1&__dyn=&__comet_req=0&jazoest=26581";
				input = C604C58C(string_).Replace("for (;;);", "");
				JObject jObject = JObject.Parse(input);
				if (jObject["redirect"] != null)
				{
					string_ = jObject["redirect"]!.ToString();
					input = C604C58C(string_).Replace("for (;;);", "");
					jObject = JObject.Parse(input);
				}
				foreach (JToken item in (IEnumerable<JToken>)(jObject["payload"]!["entries"]!))
				{
					try
					{
						list.Add(string.Format("{0}|{1}|{2}", item["uid"], item["text"], item["size"]));
					}
					catch
					{
					}
				}
				if (bool_9)
				{
					list = EF32BE86(list);
				}
			}
			else
			{
				string text2 = FB001323();
				string json = new RequestXNet("", "", A3A32284, Int32_1).E58EB99F("https://graph.facebook.com/graphql?q=nodes(" + text + "){groups{nodes{id,name,viewer_post_status,visibility,group_member_profiles{count}}}}&method=post&access_token=" + text2);
				JObject jObject2 = JObject.Parse(json);
				foreach (JToken item2 in (IEnumerable<JToken>)(jObject2[text]!["groups"]!["nodes"]!))
				{
					try
					{
						list.Add(string.Format("{0}|{1}|{2}|{3}", item2["id"], item2["name"], item2["group_member_profiles"]!["count"], (item2["viewer_post_status"]!.ToString() == "CAN_POST_WITHOUT_APPROVAL") ? "False" : "True"));
					}
					catch (Exception)
					{
					}
				}
			}
		}
		catch
		{
		}
		if (list.Count == 0)
		{
			try
			{
				method_12("https://www.facebook.com/groups/joins/");
				F8091028(2.5);
				string jsonGroups = method_14("try { var links = Array.from(document.querySelectorAll('a[href*=\"/groups/\"]')); var gids = []; var seen = new Set(); for (var a of links) { var href = a.getAttribute('href') || ''; var m = href.match(/\\/groups\\/([0-9]{8,}|[a-zA-Z0-9.\\-_]+)/); if (m && m[1] && !seen.has(m[1])) { var slug = m[1].toLowerCase(); if (!['feed', 'discover', 'joins', 'create', 'categories', 'notifications'].includes(slug)) { seen.add(m[1]); gids.push(m[1]); } } } return JSON.stringify(gids); } catch(e) { return '[]'; }");
				if (!string.IsNullOrEmpty(jsonGroups) && jsonGroups.StartsWith("["))
				{
					JArray jArr = JArray.Parse(jsonGroups);
					foreach (var item in jArr)
					{
						string gid = item?.ToString();
						if (!string.IsNullOrEmpty(gid))
						{
							list.Add(gid + "|Group|" + gid);
						}
					}
				}
			}
			catch { }
		}
		return list;
	}

	public List<string> method_57(int int_4 = 0)
	{
		List<string> list = new List<string>();
		try
		{
			string propertyName = FB94939A();
			string text = method_41();
			if (!GetURL().Contains("https://www.facebook.com/api/graphql"))
			{
				method_12("https://www.facebook.com/api/graphql");
			}
			string json = method_14("async function RequestPost() { var output = ''; try { var response = await fetch('https://www.facebook.com/api/graphql', { method: 'POST', body: 'q=me(){friends}&fb_dtsg=" + text + "', headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await RequestPost(); return c;");
			JObject jObject = JObject.Parse(json);
			int num = jObject[propertyName]!["friends"]!["nodes"].Count();
			for (int i = 0; i < num; i++)
			{
				if (int_4 != 0)
				{
					try
					{
						string text2 = jObject[propertyName]!["friends"]!["nodes"]![i]!["name"]!.ToString();
						if ((int_4 == 1 && Commom.D9AB3B82(text2)) || (int_4 == 2 && !Commom.D9AB3B82(text2)))
						{
							list.Add(jObject[propertyName]!["friends"]!["nodes"]![i]!["id"]!.ToString());
						}
					}
					catch
					{
					}
				}
				else
				{
					list.Add(jObject[propertyName]!["friends"]!["nodes"]![i]!["id"]!.ToString());
				}
			}
		}
		catch
		{
		}
		if (list.Count == 0)
		{
			try
			{
				method_12("https://www.facebook.com/me/friends");
				F8091028(2.5);
				string jsonFriends = method_14("try { var links = Array.from(document.querySelectorAll('a[href*=\"/user/\"], a[href*=\"profile.php?id=\"], a[role=\"link\"][href*=\"facebook.com/\"]')); var uids = []; var seen = new Set(); for (var a of links) { var href = a.getAttribute('href') || ''; var m = href.match(/(?:profile\\.php\\?id=)([0-9]{8,})/); if (m && m[1] && !seen.has(m[1])) { seen.add(m[1]); uids.push(m[1]); } else { var m2 = href.match(/facebook\\.com\\/([a-zA-Z0-9.\\-_]+)/); if (m2 && m2[1] && !seen.has(m2[1])) { var slug = m2[1].toLowerCase(); if (!['friends', 'messages', 'notifications', 'groups', 'watch', 'marketplace', 'gaming', 'pages', 'bookmarks', 'reel', 'stories'].includes(slug)) { seen.add(m2[1]); uids.push(m2[1]); } } } } return JSON.stringify(uids); } catch(e) { return '[]'; }");
				if (!string.IsNullOrEmpty(jsonFriends) && jsonFriends.StartsWith("["))
				{
					JArray jArr = JArray.Parse(jsonFriends);
					foreach (var item in jArr)
					{
						string uid = item?.ToString();
						if (!string.IsNullOrEmpty(uid) && !list.Contains(uid))
						{
							list.Add(uid);
						}
					}
				}
			}
			catch { }
		}
		return list;
	}

	public List<string> D5008BAB()
	{
		List<string> list = new List<string>();
		try
		{
			string text = method_41();
			string json = method_48("https://www.facebook.com/buddylist.php", "data_fetch=true&send_full_data=true&fb_dtsg=" + text + "&jazoest=&lsd=r&__dyn=&__csr=&__req=a&__a=&__user=" + string_2).Replace("for (;;);", "");
			JObject jObject = JObject.Parse(json);
			foreach (JToken item in (IEnumerable<JToken>)(jObject["payload"]!["buddylist"]!))
			{
				list.Add(item["id"]!.ToString());
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public List<string> method_58()
	{
		List<string> list = new List<string>();
		try
		{
			string text = "/messages/?folder=other";
			do
			{
				string input = C604C58C("https://m.facebook.com" + text).Replace("&amp;", "&");
				text = Regex.Match(input, "href=\"(/messages/\\?pageNum=.*?)\"").Groups[1].Value;
				MatchCollection matchCollection = Regex.Matches(input, "/messages/read/\\?tid=cid\\.c\\.(.*?)%");
				foreach (Match item in matchCollection)
				{
					list.Add(item.Groups[1].Value);
				}
			}
			while (text != "");
		}
		catch (Exception)
		{
		}
		list.Remove(string_2);
		return list;
	}

	public List<string> FA099AA0()
	{
		List<string> list = new List<string>();
		try
		{
			string text = "/messages/?folder=pending";
			do
			{
				string input = C604C58C("https://m.facebook.com" + text).Replace("&amp;", "&");
				text = Regex.Match(input, "href=\"(/messages/\\?pageNum=.*?)\"").Groups[1].Value;
				MatchCollection matchCollection = Regex.Matches(input, "/messages/read/\\?tid=cid\\.c\\.(.*?)%");
				foreach (Match item in matchCollection)
				{
					list.Add(item.Groups[1].Value);
				}
			}
			while (text != "");
		}
		catch (Exception)
		{
		}
		list.Remove(string_2);
		return list;
	}

	public bool method_59()
	{
		string text = GetURL();
		if (!text.Contains("601051028565049"))
		{
			return false;
		}
		string text2 = method_15(0.0, new List<string> { "//div[@role=\"button\"][.//div/div and not(ancestor::*[@role=\"dialog\"])]", "//*[@action=\"/checkpoint/601051028565049/submit/\"]//*[@type=\"submit\"]" });
		if (text2 == "")
		{
			return false;
		}
		method_19(text2);
		F8091028(2.0);
		return true;
	}

	public void method_60()
	{
		try
		{
			if (method_59() || method_82())
			{
				return;
			}
			DismissFacebookPopups();
			for (int i = 0; i < 3; i++)
			{
				string text = method_15(0.0, new List<string>
				{
					"[role=\"dialog\"] [aria-label=\"[object Object]\"]", "[role=\"dialog\"] [aria-label=\"Not Now\"]", "[role=\"dialog\"] [aria-label=\"Use Page\"]", "[role=\"dialog\"] [aria-label=\"Close\"],[role=\"dialog\"] [aria-label=\"Đóng\"]", "[aria-label=\"Done\"]", "[aria-label=\"Xong\"]", "[data-visualcompletion=\"ignore\"] [role=\"dialog\"] [role=\"button\"]", "[style=\"transform: translateX(0%) translateZ(1px);\"]>div>div:nth-child(2)>div:nth-child(3)>div", "[style=\"transform: translate(16px, 0px);\"] [role=\"button\"]", "[style=\"padding-top: 40px;\"]>div>div>[role=\"button\"]",
					"[style=\"transform: translateX(0%) translateZ(1px);\"] [role=\"button\"]", "[role=\"dialog\"]>div>div>div:nth-child(3)>div", "[role=\"dialog\"] [style*=\"transform: translate\"]>div>div>div [role=\"button\"]", "[data-testid=\"cookie-policy-manage-dialog\"] > [role=\"dialog\"] [aria-label]:not([aria-disabled=\"true\"])"
				});
				string text2 = text;
				string text3 = text2;
				switch (AFAE75A0.smethod_0(text3))
				{
				default:
					return;
				case 716036627u:
					if (!(text3 == "[style=\"transform: translateX(0%) translateZ(1px);\"] [role=\"button\"]"))
					{
						return;
					}
					goto IL_0350;
				case 615184787u:
					if (!(text3 == "[role=\"dialog\"]>div>div>div:nth-child(3)>div"))
					{
						return;
					}
					goto IL_0350;
				case 458653063u:
					if (!(text3 == "[style=\"transform: translateX(0%) translateZ(1px);\"]>div>div:nth-child(2)>div:nth-child(3)>div"))
					{
						return;
					}
					goto IL_0350;
				case 1692541720u:
					if (!(text3 == "[aria-label=\"Xong\"]"))
					{
						return;
					}
					goto IL_0350;
				case 737127231u:
					if (!(text3 == "[style=\"transform: translate(16px, 0px);\"] [role=\"button\"]"))
					{
						return;
					}
					goto IL_0350;
				case 2528427641u:
					if (!(text3 == "[role=\"dialog\"] [aria-label=\"Close\"],[role=\"dialog\"] [aria-label=\"Đóng\"]"))
					{
						return;
					}
					goto IL_0350;
				case 1817943238u:
					if (text3 == "[data-testid=\"cookie-policy-manage-dialog\"] > [role=\"dialog\"] [aria-label]:not([aria-disabled=\"true\"])")
					{
						method_19(text + "|" + (method_30(text) - 1));
						break;
					}
					return;
				case 2721477684u:
					if (!(text3 == "[role=\"dialog\"] [style*=\"transform: translate\"]>div>div>div [role=\"button\"]"))
					{
						return;
					}
					goto IL_0350;
				case 2690410623u:
					if (!(text3 == "[data-visualcompletion=\"ignore\"] [role=\"dialog\"] [role=\"button\"]"))
					{
						return;
					}
					goto IL_0350;
				case 2615523657u:
					if (!(text3 == "[role=\"dialog\"] [aria-label=\"[object Object]\"]"))
					{
						return;
					}
					if (D7A424AE("[role=\"dialog\"] [aria-label=\"Close\"],[role=\"dialog\"] [aria-label=\"Đóng\"]"))
					{
						method_21("[role=\"dialog\"] [aria-label=\"Close\"],[role=\"dialog\"] [aria-label=\"Đóng\"]");
						break;
					}
					if (D7A424AE("(//*[@role=\"dialog\"]//*[@role=\"radio\"])[last()]"))
					{
						method_21("(//*[@role=\"dialog\"]//*[@role=\"radio\"])[last()]");
					}
					method_21("(//*[@role=\"dialog\"]//*[@aria-label=\"[object Object]\"])[last()]");
					break;
				case 3408643542u:
					if (!(text3 == "[style=\"padding-top: 40px;\"]>div>div>[role=\"button\"]"))
					{
						return;
					}
					goto IL_0350;
				case 3199891620u:
					if (!(text3 == "[role=\"dialog\"] [aria-label=\"Not Now\"]"))
					{
						return;
					}
					goto IL_0350;
				case 4207376459u:
					if (!(text3 == "[role=\"dialog\"] [aria-label=\"Use Page\"]"))
					{
						return;
					}
					goto IL_0350;
				case 3896031394u:
					{
						if (!(text3 == "[aria-label=\"Done\"]"))
						{
							return;
						}
						goto IL_0350;
					}
					IL_0350:
					if (method_27(text))
					{
						string text4 = GetURL();
						if (!text4.Contains("facebook.com/messages/") && !text4.Contains("&rdid=") && !text4.Contains("/posts/") && !text4.Contains("?story_fbid=") && !text4.Contains("/permalink/") && !text4.Contains("multi_permalinks"))
						{
							method_34(text);
							F8091028(1.0);
							method_21(text);
							break;
						}
						return;
					}
					return;
				}
				F8091028(1.0);
			}
		}
		catch
		{
		}
	}

	public bool DismissFacebookPopups()
	{
		if (CD930D04() || E184CD03())
		{
			return false;
		}
		try
		{
			string script = @"
(function() {
    var handled = [];
    try {
        var alertBtns = document.querySelectorAll('button[name*=""This was me""], button[name*=""submit[This was me]""], button[name*=""submit[Continue]""], [role=""button""], button');
        for (var i = 0; i < alertBtns.length; i++) {
            var b = alertBtns[i];
            var name = (b.getAttribute('name') || '').toLowerCase();
            var aria = (b.getAttribute('aria-label') || '').toLowerCase();
            var txt = (b.innerText || '').trim().toLowerCase();
            if (name.indexOf('this was me') !== -1 || aria.indexOf('this was me') !== -1 || txt === 'this was me'
                || aria.indexOf('đúng là tôi') !== -1 || txt === 'đúng là tôi'
                || aria.indexOf('đây là tôi') !== -1 || txt === 'đây là tôi') {
                b.click();
                handled.push('confirmed_this_was_me');
                break;
            }
        }
        var dialogs = document.querySelectorAll('[role=""dialog""], [data-dialog=""1""]');
        for (var j = 0; j < dialogs.length; j++) {
            var d = dialogs[j];
            var dText = (d.innerText || '').toLowerCase();
            if (dText.indexOf('remember password') !== -1 || dText.indexOf('lưu mật khẩu') !== -1 
                || dText.indexOf('click your picture') !== -1 || dText.indexOf('nhấp vào ảnh') !== -1) {
                var dBtns = d.querySelectorAll('[role=""button""], button');
                for (var k = 0; k < dBtns.length; k++) {
                    var btn = dBtns[k];
                    var btnAria = (btn.getAttribute('aria-label') || '').toLowerCase().trim();
                    var btnTxt = (btn.innerText || '').toLowerCase().trim();
                    if (btnAria === 'ok' || btnTxt === 'ok' 
                        || btnAria === 'lưu mật khẩu' || btnTxt === 'lưu mật khẩu'
                        || btnAria === 'not now' || btnTxt === 'not now'
                        || btnAria === 'lúc khác' || btnTxt === 'lúc khác'
                        || btnAria === 'để sau' || btnTxt === 'để sau') {
                        btn.click();
                        handled.push('dismissed_remember_password');
                        break;
                    }
                }
            }
        }
        for (var m = 0; m < dialogs.length; m++) {
            var dlg = dialogs[m];
            var closeBtn = dlg.querySelector('[aria-label=""Close""], [aria-label=""Đóng""], [aria-label=""Not Now""], [aria-label=""Not now""], [aria-label=""Lúc khác""]');
            if (closeBtn) {
                closeBtn.click();
                handled.push('closed_dialog');
            }
        }
        var cookieBtn = document.querySelector('[data-cookiebanner=""accept_button""], [data-testid=""cookie-policy-manage-dialog""] [aria-label]:not([aria-disabled=""true""])');
        if (cookieBtn) {
            cookieBtn.click();
            handled.push('accepted_cookies');
        }
    } catch (e) {
        return 'error';
    }
    return handled.join(';') || '';
})();";
			string text = method_14(script);
			return !string.IsNullOrEmpty(text) && text != "error";
		}
		catch
		{
			return false;
		}
	}

	public int method_61(string AA074189 = "")
	{
		if (AA074189 == "")
		{
			AA074189 = GetURL();
		}
		return CommonRequest.smethod_16(AA074189);
	}

	internal void EC9B94B0()
	{
		DismissFacebookPopups();
		if (method_59() || (D7A424AE("[href=\"/\"]") && !GetURL().Contains("facebook.com/privacy/consent_framework/prompt/")))
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (method_61() == 1)
			{
				for (int j = 0; j < 10; j++)
				{
					if (!GetURL().Contains(".facebook.com/privacy/consent/"))
					{
						break;
					}
					method_120();
					F8091028(2.0);
				}
				if (D7A424AE("[role=\"dialog\"] [aria-label=\"Close\"],[role=\"dialog\"] [aria-label][role=\"button\"]:has(svg)") && method_21("[role=\"dialog\"] [aria-label=\"Close\"],[role=\"dialog\"] [aria-label][role=\"button\"]:has(svg)"))
				{
					F8091028(2.0);
				}
				if (GetURL().Contains("facebook.com/checkpoint/block") && D7A424AE("[href*=\"facebook.com/communitystandards\"]") && method_18("#checkpointBottomBar button, #checkpointSubmitButton button"))
				{
					continue;
				}
				break;
			}
			if (D7A424AE("[data-cookiebanner=\"accept_button\"]"))
			{
				method_14("document.querySelector('[data-cookiebanner=\"accept_button\"]').click()");
				continue;
			}
			if (D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
			{
				method_18("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
				continue;
			}
			string text = GetURL();
			if (text.Contains("facebook.com/si/actor_experience/actor_gateway"))
			{
				string text2 = method_15(10.0, new List<string> { "[data-nt=\"NT:IMAGE\"]", "button[data-sigil=\"touchable\"]" });
				if (text2 == "[data-nt=\"NT:IMAGE\"]")
				{
					num++;
					if (num <= 1)
					{
						method_21(text2);
						F8091028(2.0);
						continue;
					}
					break;
				}
				if (text2 == "button[data-sigil=\"touchable\"]")
				{
					method_18(text2);
					F8091028(2.0);
					break;
				}
			}
			if (text.Contains("facebook.com/legal_consent"))
			{
				method_21("button[type=\"submit\"]");
				F8091028(1.0);
				method_21("button[type=\"submit\"]:last-child");
				F8091028(1.0);
				method_21("button[type=\"submit\"]");
				F8091028(1.0);
				method_21("#consent-page-container button[type=\"submit\"]:last-child");
				F8091028(1.0);
				continue;
			}
			if (!text.Contains("facebook.com/privacy/consent_framework/prompt/"))
			{
				break;
			}
			if (D7A424AE("[href=\"/\"]"))
			{
				method_12("https://www.facebook.com/");
				continue;
			}
			if (D7A424AE("[type=\"checkbox\"][name=\"personal_data_toggle\"]"))
			{
				method_14("document.querySelector('[type=\"checkbox\"][name=\"personal_data_toggle\"]').checked=true;");
			}
			if (D7A424AE("[type=\"checkbox\"][name=\"data_shared_3pd_toggle\"]"))
			{
				method_14("document.querySelector('[type=\"checkbox\"][name=\"data_shared_3pd_toggle\"]').checked=true;");
			}
			if (D7A424AE("[type=\"checkbox\"][name=\"cross_border_data_transfer_toggle\"]"))
			{
				method_14("document.querySelector('[type=\"checkbox\"][name=\"cross_border_data_transfer_toggle\"]').checked=true;");
			}
			if (D7A424AE("[type=\"checkbox\"][name=\"location_info_toggle\"]"))
			{
				method_14("document.querySelector('[type=\"checkbox\"][name=\"location_info_toggle\"]').checked=true;");
			}
			method_21("button[name=\"primary_consent_button\"]");
			F8091028(2.0);
		}
	}

	public void method_62(string string_10 = "")
	{
		if (string_10 == "")
		{
			string_10 = GetURL();
		}
		ED0947B5 = string_10;
	}

	public bool method_63(int int_4, string string_10 = "")
	{
		int tickCount = Environment.TickCount;
		while (!CD930D04() && !E184CD03())
		{
			if (string_10 == "")
			{
				string_10 = GetURL();
			}
			if (!(ED0947B5 != string_10))
			{
				if (int_4 == 0)
				{
					break;
				}
				F8091028(1.0);
				string_10 = "";
				if (Environment.TickCount - tickCount >= int_4 * 1000)
				{
					break;
				}
				continue;
			}
			return true;
		}
		return false;
	}

	public bool method_64(Func<bool> func_0, int B0146BB5)
	{
		int tickCount = Environment.TickCount;
		while (!CD930D04() && !E184CD03())
		{
			if (!func_0())
			{
				if (B0146BB5 == 0)
				{
					break;
				}
				F8091028(1.0);
				if (Environment.TickCount - tickCount >= B0146BB5 * 1000)
				{
					break;
				}
				continue;
			}
			return true;
		}
		return false;
	}

	internal void method_65()
	{
		string text = "300645083384735";
		method_12("https://m.facebook.com/privacy/touch/composer/selector/?logging_source=composer_options&paipv=0");
		if (method_14("return document.querySelector('[href^=\"/privacy/save/\"] [name=\"privacyx\"][value=\"" + text + "\"]').checked").ToString().ToLower() != "true")
		{
			string text2 = method_14("return document.querySelector('[href^=\"/privacy/save/?privacy_x=" + text + "\"]').getAttribute('href')").ToString();
			if (text2 != "")
			{
				string text3 = GetDomainFb(GetURL());
				text2 = text3 + text2;
				method_12(text2);
			}
			else if (D7A424AE("#modalDialogView [type=\"submit\"]", 5.0))
			{
				method_21("#modalDialog [data-sigil=\"audience-options-list\"] input[type=\"radio\"]");
				F8091028(2.0);
				method_21("#modalDialogView [type=\"submit\"]");
				F8091028(2.0);
			}
		}
	}

	public string method_66(string E93E6CA2, string string_10 = "")
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		try
		{
			if (C5034B95.smethod_0("configDebug").method_3("ckbUseScriptFile"))
			{
				string text = C5034B95.smethod_0("configDebug").BDB80B23("txtFilePath");
				if (!string.IsNullOrEmpty(text) && File.Exists(text))
				{
					string script = File.ReadAllText(text);
					object res = ChromeDriver_0.ExecuteScript(script, E93E6CA2, string_10);
					return res?.ToString() ?? "";
				}
			}

			// Hub dispatchers are handled below with JSON wrapping (lines 3693+)

			if (E93E6CA2 == "CheckFbBlock")
			{
				try
				{
					string url = GetURL();
					if (url.Contains("/checkpoint/") || url.Contains("1501092823525282") || url.Contains("828281030927956"))
					{
						return "true";
					}
					object res = ChromeDriver_0.ExecuteScript("return (document.body && (document.body.innerText.includes('tạm thời bị chặn') || document.body.innerText.includes('bị khóa') || document.body.innerText.includes('Temporarily Blocked') || document.body.innerText.includes('account has been locked'))) ? 'true' : 'false';");
					return res?.ToString() ?? "false";
				}
				catch
				{
					return "false";
				}
			}

			if (E93E6CA2 == "Getfb_dtsg")
			{
				try
				{
					object res = ChromeDriver_0.ExecuteScript("try { return (require('DTSGInitialData')?.token) || (document.querySelector('[name=\"fb_dtsg\"]')?.value) || (document.documentElement.innerHTML.match(/[\"']DTSGInitialData[\"'],\\[\\],\\{\"token\":\"([^\"]+)\"/)?.[1]) || (document.documentElement.innerHTML.match(/\"token\":\"([^\"]+)\"/)?.[1]) || ''; } catch(e) { return ''; }");
					return res?.ToString() ?? "";
				}
				catch
				{
					return "";
				}
			}

			if (E93E6CA2.StartsWith("GetToken"))
			{
				try
				{
					object res = ChromeDriver_0.ExecuteScript("try { var m = document.documentElement.innerHTML.match(/(EAA[a-zA-Z0-9]+)/); return m ? m[1] : ''; } catch(e) { return ''; }");
					return res?.ToString() ?? "";
				}
				catch
				{
					return "";
				}
			}

			if (E93E6CA2 == "Logout")
			{
				try
				{
					ChromeDriver_0.Navigate().GoToUrl("https://www.facebook.com/logout.php");
					return "true";
				}
				catch
				{
					return "";
				}
			}

			if (E93E6CA2 == "DangBaiWWW")
			{
				try
				{
					int typeObject = 0;
					string link = "";
					string content = "";
					bool isUseBg = false;
					List<string> images = new List<string>();
					if (!string.IsNullOrEmpty(string_10))
					{
						JArray arr = JArray.Parse(string_10);
						foreach (var item in arr)
						{
							string name = item["name"]?.ToString();
							string val = item["value"]?.ToString();
							if (name == "content") content = val ?? "";
							else if (name == "link") link = val ?? "";
							else if (name == "typeObject") int.TryParse(val, out typeObject);
							else if (name == "isUseBackground") bool.TryParse(val, out isUseBg);
							else if (name == "image" && !string.IsNullOrEmpty(val))
							{
								images = val.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
							}
						}
					}
					string postUrl = ExecuteDangBaiWWW(typeObject, link, content, isUseBg, images);
					if (!string.IsNullOrEmpty(postUrl))
					{
						return "{\"success\": true, \"postUrl\": \"" + postUrl.Replace("\"", "\\\"") + "\"}";
					}
					return "{\"success\": false, \"postUrl\": \"\", \"error\": \"failed\"}";
				}
				catch (Exception ex)
				{
					return "{\"success\": false, \"postUrl\": \"\", \"error\": \"" + ex.Message.Replace("\"", "\\\"") + "\"}";
				}
			}

			if (E93E6CA2 == "DangBaiMbasic")
			{
				try
				{
					string content = "";
					List<string> images = new List<string>();
					if (!string.IsNullOrEmpty(string_10))
					{
						JArray arr = JArray.Parse(string_10);
						foreach (var item in arr)
						{
							string name = item["name"]?.ToString();
							string val = item["value"]?.ToString();
							if (name == "content") content = val ?? "";
							else if (name == "image" && !string.IsNullOrEmpty(val))
							{
								images = val.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
							}
						}
					}
					string postUrl = ExecuteDangBaiWWW(0, "", content, false, images);
					bool ok = !string.IsNullOrEmpty(postUrl);
					return "{\"success\": " + (ok ? "true" : "false") + ", \"postUrl\": \"" + (postUrl ?? "").Replace("\"", "\\\"") + "\", \"error\": \"\"}";
				}
				catch (Exception ex)
				{
					return "{\"success\": false, \"error\": \"" + ex.Message.Replace("\"", "\\\"") + "\"}";
				}
			}

			string acResult = AccountsCenterHub.Execute(this, E93E6CA2, string_10);
			if (!string.IsNullOrEmpty(acResult))
			{
				if (acResult.TrimStart().StartsWith("{"))
				{
					return acResult;
				}
				if (acResult.Equals("success", StringComparison.OrdinalIgnoreCase))
				{
					return "{\"success\": true, \"error\": \"\"}";
				}
				if (E93E6CA2 == "TurnOn2FA")
				{
					return "{\"success\": true, \"fa2\": \"" + acResult.Replace("\"", "\\\"") + "\", \"error\": \"\"}";
				}
				return "{\"success\": false, \"error\": \"" + acResult.Replace("\"", "\\\"") + "\"}";
			}

			string hubResult = FacebookGroupFriendHub.Execute(this, E93E6CA2, string_10);
			if (!string.IsNullOrEmpty(hubResult))
			{
				return hubResult;
			}

			string actionResult = FacebookActionsHub.Execute(this, E93E6CA2, string_10);
			if (!string.IsNullOrEmpty(actionResult) && !actionResult.Contains("Unknown action name"))
			{
				return actionResult;
			}

			return "";
		}
		catch
		{
			return "";
		}
	}

	public string RunCodeChrome(string string_10)
	{
		if (CD930D04() || E184CD03() || string.IsNullOrEmpty(string_10))
		{
			return "";
		}
		try
		{
			string trimmed = string_10.Trim();
			if (trimmed.StartsWith("ToJSDom(") && trimmed.EndsWith(")"))
			{
				string arg = trimmed.Substring(8, trimmed.Length - 9).Trim('\'', '"', ' ');
				return A7B8E3A5(arg);
			}
			if (trimmed.StartsWith("IsXpath(") && trimmed.EndsWith(")"))
			{
				string arg = trimmed.Substring(8, trimmed.Length - 9).Trim('\'', '"', ' ');
				return B1A19F3D(arg) ? "true" : "false";
			}
			if (trimmed.StartsWith("IsElementVisible(") && trimmed.EndsWith(")"))
			{
				string arg = trimmed.Substring(17, trimmed.Length - 18).Trim('\'', '"', ' ');
				string dom = A7B8E3A5(arg);
				string chkRes = method_14($"var el={dom}; if(!el) return 'false'; var r=el.getBoundingClientRect(); return (r.width>0 && r.height>0 && window.getComputedStyle(el).display!=='none') ? 'true' : 'false';");
				return chkRes.ToLower() == "true" ? "true" : "false";
			}
			if (trimmed.StartsWith("IsElementOnScreen(") && trimmed.EndsWith(")"))
			{
				string inside = trimmed.Substring(18, trimmed.Length - 19);
				string[] parts = inside.Split(',');
				string arg = parts[0].Trim('\'', '"', ' ');
				string dom = A7B8E3A5(arg);
				string chkRes = method_14($"var el={dom}; if(!el) return 'false'; var r=el.getBoundingClientRect(); return (r.top>=0 && r.left>=0 && r.bottom<=(window.innerHeight||document.documentElement.clientHeight)) ? 'true' : 'false';");
				return chkRes.ToLower() == "true" ? "true" : "false";
			}
			if (trimmed.StartsWith("SendKeys2(") && trimmed.EndsWith(")"))
			{
				string inside = trimmed.Substring(10, trimmed.Length - 11);
				string[] parts = inside.Split(',');
				string sel = parts[0].Trim('\'', '"', ' ');
				string val = parts.Length > 1 ? parts[1].Trim('\'', '"', ' ') : "";
				return method_22(sel, val) ? "true" : "false";
			}
			if (trimmed.StartsWith("SwitchToFrame(") && trimmed.EndsWith(")"))
			{
				string arg = trimmed.Substring(14, trimmed.Length - 15).Trim();
				if (int.TryParse(arg, out int fIdx))
				{
					ChromeDriver_0.SwitchTo().Frame(fIdx);
					return "true";
				}
				return "false";
			}
			if (trimmed == "SwitchToParentFrame()")
			{
				ChromeDriver_0.SwitchTo().ParentFrame();
				return "true";
			}
			if (trimmed == "CheckFbLogout()")
			{
				string url = GetURL();
				if (url.Contains("/login") || url.Contains("login.php")) return "true";
				return D7A424AE("[name='login'],#loginbutton,input[name='email']") ? "true" : "false";
			}
			if (trimmed == "GetContact()" || trimmed.StartsWith("GetContact("))
			{
				return AccountInfoAutomationHelper.GetContactsJson(this);
			}
			if (trimmed.StartsWith("RequestGet(") && trimmed.EndsWith(")"))
			{
				string arg = trimmed.Substring(11, trimmed.Length - 12).Trim('\'', '"', ' ');
				return AccountInfoAutomationHelper.ExecuteBrowserFetch(this, arg, "GET", null);
			}
			if (trimmed.StartsWith("RequestPost(") && trimmed.EndsWith(")"))
			{
				string inside = trimmed.Substring(12, trimmed.Length - 13);
				string[] parts = inside.Split(new char[] { ',' }, 2);
				string postUrl = parts[0].Trim('\'', '"', ' ');
				string postData = parts.Length > 1 ? parts[1].Trim('\'', '"', ' ') : "";
				return AccountInfoAutomationHelper.ExecuteBrowserFetch(this, postUrl, "POST", postData);
			}

			object res = ChromeDriver_0.ExecuteScript(string_10);
			return res?.ToString() ?? "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public string B5A45B08()
	{
		return "";
	}

	public void method_68(string string_10)
	{
		string text = GetURL();
		string value = Regex.Match(text, "https://(.*?)facebook.com").Value;
		text = ((value == "") ? string_10 : text.Replace(value, string_10));
		method_12(text);
	}

	public void method_69(int int_4 = 2)
	{
		List<string> list = new List<string>();
		switch (int_4)
		{
		case 1:
			list = new List<string> { "https://facebook.com", "https://www.facebook.com", "https://web.facebook.com" };
			break;
		case 2:
			list = new List<string> { "https://m.facebook.com" };
			break;
		case 3:
			list = new List<string> { "https://m.facebook.com", "https://d.facebook.com" };
			break;
		}
		foreach (string item in list)
		{
			string text = GetURL();
			if (method_61(text) != int_4)
			{
				string value = Regex.Match(text, "https://(.*?)facebook.com").Value;
				text = ((value == "") ? item : text.Replace(value, item));
				if (text.Contains("?") && !text.Contains("?id=") && !text.Contains("?story_fbid") && !text.Contains("recover/password") && !text.Contains("?fbid=") && !text.Contains("?v=") && !text.Contains("/si/actor_experience/actor_gateway/nt/?flow_id=") && !text.Contains("1501092823525282"))
				{
					text = text.Split('?')[0].TrimEnd('/');
				}
				method_12(text);
				F8091028(2.0);
				continue;
			}
			break;
		}
	}

	internal List<string> method_70(bool bool_9 = false)
	{
		return AccountInfoAutomationHelper.GetPhones(this, bool_9);
	}

	internal List<string> method_71()
	{
		if (!GetURL().StartsWith("https://www.facebook.com"))
		{
			method_12("https://www.facebook.com/api/graphql/");
		}
		string string_ = Commom.FD9AD412("GetEmail");
		string text = method_14(string_).ToString();
		return text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
	}

	internal List<string> B13A9E19(bool AE8E2B8E = false)
	{
		return AccountInfoAutomationHelper.GetEmails(this, AE8E2B8E);
	}

	internal string B8BA1F03(string string_10)
	{
		if (!GetURL().StartsWith("https://www.facebook.com"))
		{
			method_12("https://www.facebook.com/api/graphql/");
		}
		string string_11 = Commom.FD9AD412("CheckGroup").Replace("{fb_dtsg}", string_10);
		return method_14(string_11).ToString();
	}

	internal string DC1ABB3C(string string_10)
	{
		try
		{
			if (string.IsNullOrEmpty(string_10)) return "";
			string url = "https://graph.facebook.com/me/groups?summary=total_count&limit=1&access_token=" + string_10;
			string json = new RequestXNet("", "", A3A32284, Int32_1).E58EB99F(url);
			if (!string.IsNullOrEmpty(json))
			{
				JObject jObj = JObject.Parse(json);
				if (jObj["summary"]?["total_count"] != null)
				{
					return jObj["summary"]["total_count"].ToString();
				}
				if (jObj["data"] != null)
				{
					return jObj["data"].Count().ToString();
				}
			}
		}
		catch
		{
		}
		return "";
	}

	internal string method_72(string AE8EDEBE)
	{
		try
		{
			if (string.IsNullOrEmpty(AE8EDEBE)) return "";
			string url = "https://graph.facebook.com/me/businesses?access_token=" + AE8EDEBE;
			string json = new RequestXNet("", "", A3A32284, Int32_1).E58EB99F(url);
			if (!string.IsNullOrEmpty(json))
			{
				JObject jObj = JObject.Parse(json);
				if (jObj["data"] != null)
				{
					return jObj["data"].Count().ToString();
				}
			}
		}
		catch
		{
		}
		return "";
	}

	internal string method_73(string string_10)
	{
		try
		{
			if (string.IsNullOrEmpty(string_10)) return "";
			string url = "https://graph.facebook.com/me?fields=created_time,friends.limit(0)&access_token=" + string_10;
			string json = new RequestXNet("", "", A3A32284, Int32_1).E58EB99F(url);
			if (!string.IsNullOrEmpty(json))
			{
				JObject jObj = JObject.Parse(json);
				string createdUnix = "";
				if (jObj["created_time"] != null)
				{
					string rawCreated = jObj["created_time"].ToString();
					if (double.TryParse(rawCreated, out _))
					{
						createdUnix = rawCreated;
					}
					else if (DateTime.TryParse(rawCreated, out DateTime dt))
					{
						createdUnix = ((long)(dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString();
					}
				}
				string friendCount = jObj["friends"]?["summary"]?["total_count"]?.ToString() ?? "";
				if (!string.IsNullOrEmpty(createdUnix) || !string.IsNullOrEmpty(friendCount))
				{
					return createdUnix + "|" + friendCount;
				}
			}
		}
		catch
		{
		}
		return "";
	}

	internal string method_74(string CF1331A7, string string_10, string string_11, string F60B11AD)
	{
		try
		{
			if (string.IsNullOrEmpty(CF1331A7)) return "";
			RequestXNet req = new RequestXNet("", "", A3A32284, Int32_1);
			string friendVal = string_10 ?? "";
			string pageVal = string_11 ?? "";
			string adsVal = F60B11AD ?? "";

			if (string.IsNullOrEmpty(friendVal))
			{
				try
				{
					string res = req.E58EB99F("https://graph.facebook.com/me?fields=friends.limit(0)&access_token=" + CF1331A7);
					if (!string.IsNullOrEmpty(res))
					{
						JObject obj = JObject.Parse(res);
						friendVal = obj["friends"]?["summary"]?["total_count"]?.ToString() ?? "";
					}
				}
				catch { }
			}

			if (string.IsNullOrEmpty(pageVal))
			{
				try
				{
					string res = req.E58EB99F("https://graph.facebook.com/me/accounts?summary=total_count&limit=1&access_token=" + CF1331A7);
					if (!string.IsNullOrEmpty(res))
					{
						JObject obj = JObject.Parse(res);
						pageVal = obj["summary"]?["total_count"]?.ToString() ?? (obj["data"] != null ? obj["data"].Count().ToString() : "");
					}
				}
				catch { }
			}

			if (string.IsNullOrEmpty(adsVal))
			{
				try
				{
					string res = req.E58EB99F("https://graph.facebook.com/me/adaccounts?fields=account_id&limit=50&access_token=" + CF1331A7);
					if (!string.IsNullOrEmpty(res))
					{
						JObject obj = JObject.Parse(res);
						adsVal = obj["data"] != null ? obj["data"].Count().ToString() : "";
					}
				}
				catch { }
			}

			JObject resultObj = new JObject
			{
				["friend"] = friendVal,
				["page"] = pageVal,
				["ads"] = adsVal
			};
			return resultObj.ToString(Newtonsoft.Json.Formatting.None);
		}
		catch
		{
			return "";
		}
	}

	internal string CF38FA07()
	{
		return AccountInfoAutomationHelper.CheckDating(this);
	}

	internal void EE1B8EA5(List<string> list_0)
	{
		if (!GetURL().StartsWith("https://www.facebook.com") || GetURL().Contains("https://www.facebook.com/api/graphql"))
		{
			method_12("https://www.facebook.com/");
		}
		string text = Commom.FD9AD412("DeletePhone");
		foreach (string item in list_0)
		{
			if (method_14(text.Replace("{phone}", item)).ToString().Contains("Confirmation Required"))
			{
				break;
			}
		}
	}

	public string B782EC30()
	{
		return AccountInfoAutomationHelper.GetLocationInfo(this);
	}

	public string method_75()
	{
		return AccountInfoAutomationHelper.GetPrimaryLocation(this);
	}

	internal void B70D1B3A(List<string> list_0)
	{
		if (!GetURL().StartsWith("https://accountscenter.facebook.com/"))
		{
			method_12("https://accountscenter.facebook.com/");
		}
		string text = Commom.FD9AD412("DeletePhone2");
		foreach (string item in list_0)
		{
			method_14(text.Replace("{phone}", item)).ToString();
		}
	}

	internal bool method_76(string EE284293)
	{
		EE284293 = EE284293.ToLower();
		string string_ = "[{\"name\":\"email\", \"value\":\"" + EE284293 + "\", \"type\":\"text\"}]";
		string json = method_66("AddEmail", string_);
		try
		{
			JObject jObject = JObject.Parse(json);
			return Convert.ToBoolean(jObject["success"]);
		}
		catch
		{
		}
		return false;
	}

	internal bool method_77(string string_10)
	{
		string_10 = string_10.ToLower();
		string string_11 = "[{\"name\":\"email\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
		string json = method_66("AddEmail2", string_11);
		try
		{
			JObject jObject = JObject.Parse(json);
			return Convert.ToBoolean(jObject["success"]);
		}
		catch
		{
		}
		return false;
	}

	internal bool D01EB497(string C7AD4616)
	{
		C7AD4616 = C7AD4616.ToLower();
		List<string> list = B13A9E19();
		list.Remove(C7AD4616);
		if (list.Count == 0)
		{
			return true;
		}
		string text = RunCodeChrome("ReauthPassword('" + C234EEAA + "')");
		if (text != "true")
		{
			return false;
		}
		foreach (string item in list)
		{
			RunCodeChrome("DeleteEmail2('" + C234EEAA + "','" + item + "')");
		}
		list = B13A9E19();
		list.Remove(C7AD4616);
		return list.Count == 0;
	}

	internal void method_78(List<string> list_0)
	{
		string text = Commom.FD9AD412("DeleteMail2");
		if (!GetURL().StartsWith("https://accountscenter.facebook.com/"))
		{
			method_12("https://accountscenter.facebook.com/");
		}
		foreach (string item in list_0)
		{
			method_14(text.Replace("{email}", item)).ToString();
		}
	}

	internal void method_79(bool bool_9, bool bool_10)
	{
		string text = "";
		string string_ = Commom.FD9AD412("CheckSessionFb");
		if (!GetURL().StartsWith("https://www.facebook.com") || GetURL().Contains("https://www.facebook.com/api/graphql"))
		{
			method_12("https://www.facebook.com/");
		}
		text = method_14(string_).ToString();
		string_ = Commom.FD9AD412("LogoutOldDevice");
		try
		{
			string text2 = "";
			JObject jObject = JObject.Parse(text);
			JToken jToken = jObject["data"]!["security_settings"]!["sessions"]!["edges"];
			foreach (JToken item in (IEnumerable<JToken>)jToken)
			{
				try
				{
					bool flag = Convert.ToBoolean(item["node"]!["is_active"]!.ToString());
					string text3 = item["node"]!["sid"]!.ToString();
					if (text3 != "")
					{
						if (flag && bool_10)
						{
							text2 = text3;
						}
						if (!flag && bool_9)
						{
							text = method_14(string_.Replace("{sid}", text3)).ToString();
						}
					}
				}
				catch
				{
				}
			}
			if (text2 != "")
			{
				text = method_14(string_.Replace("{sid}", text2)).ToString();
			}
		}
		catch
		{
		}
	}

	public bool method_80(string EEA8598B, string string_10)
	{
		bool result = false;
		try
		{
			RequestXNet requestXNet = new RequestXNet(EEA8598B);
			string input = requestXNet.E58EB99F("https://www.facebook.com/profile.php?id=" + string_10);
			string value = Regex.Match(input, "\"profile_admin_invite_id\":\"(\\d+)").Groups[1].Value;
			string value2 = Regex.Match(input, "DTSGInitData\",\\[\\],{\"token\":\"(.*?)\"").Groups[1].Value;
			string value3 = Regex.Match(input, "LSD\",\\[\\],{\"token\":\"(.*?)\"").Groups[1].Value;
			if (value != "")
			{
				string value4 = Regex.Match(EEA8598B, "c_user=(\\d+)").Groups[1].Value;
				string text = "https://www.facebook.com/api/graphql/";
				string d = "av=" + value4 + "&__user=" + value4 + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + value2 + "&jazoest=22037&lsd=" + value3 + "&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ProfilePlusCometAcceptOrDeclineAdminInviteMutation&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%222%22%2C%22actor_id%22%3A%22" + value4 + "%22%2C%22is_accept%22%3Atrue%2C%22profile_admin_invite_id%22%3A%22" + value + "%22%2C%22user_id%22%3A%22" + string_10 + "%22%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=6438160746194698";
				input = requestXNet.method_1(text, d);
				result = input.Contains("accept_or_decline_profile_plus_admin_invite") && !input.Contains("\"errors\"");
				return result;
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	internal string method_81(string string_10, string string_11)
	{
		return PageCreationHub.CreatePage(this, string_10, string_11);
	}

	public bool method_82(int int_4 = 0)
	{
		try
		{
			if (int_4 > 0)
			{
				WebDriverWait webDriverWait = new WebDriverWait(ChromeDriver_0, TimeSpan.FromSeconds(int_4));
				webDriverWait.Until(ExpectedConditions.AlertIsPresent());
			}
			ChromeDriver_0.SwitchTo().Alert().Accept();
			return true;
		}
		catch
		{
		}
		return false;
	}

	internal bool method_83(string D52E5A1F, string string_10)
	{
		try
		{
			return PageAccessHelper.ShareAdminPageAccess(this, D52E5A1F, string_10, C234EEAA);
		}
		catch
		{
			return false;
		}
	}

	public string method_84()
	{
		return Regex.Match(method_40(), "i_user=(\\d+)").Groups[1].Value;
	}

	internal bool method_85(string B2164BBA, string A0934F3A)
	{
		if (!GetURL().StartsWith("https://www.facebook.com") || GetURL().Contains("https://www.facebook.com/api/graphql"))
		{
			method_12("https://www.facebook.com/");
		}
		if (method_84() != B2164BBA)
		{
			method_87(B2164BBA);
			method_12("https://www.facebook.com/settings/?tab=profile_access");
		}
		string string_ = "[{\"name\":\"pageId\", \"value\":\"" + B2164BBA + "\", \"type\":\"text\"},{\"name\":\"toUid\", \"value\":\"" + A0934F3A + "\", \"type\":\"text\"},{\"name\":\"pass\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"}]";
		string json = method_66("RemoveAdminPagePro5", string_);
		JObject jObject = JObject.Parse(json);
		bool result = Convert.ToBoolean(jObject["success"]);
		method_87("");
		return result;
	}

	public string method_86(List<string> list_0)
	{
		int count = method_30("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]");
		List<string> list = (from int_0 in Enumerable.Range(0, count)
			select int_0.ToString()).ToList();
		string text;
		string item;
		do
		{
			if (list.Count() != 0)
			{
				text = list.smethod_8();
				list.Remove(text);
				item = method_6("[aria-labelledby=\"dialog_title\"][role=\"dialog\"] [role=\"listitem\"]|" + text);
				continue;
			}
			return "";
		}
		while (list_0.Contains(item));
		return text;
	}

	public List<string> BE0C6B9C()
	{
		return AccountInfoAutomationHelper.GetPagePro5(this);
	}

	public void method_87(string A98E89AB)
	{
		try
		{
			OpenQA.Selenium.Cookie cookie = new OpenQA.Selenium.Cookie("i_user", A98E89AB, ".facebook.com", "/", DateTime.Now.AddDays(10.0));
			ChromeDriver_0.Manage().Cookies.AddCookie(cookie);
			method_13();
		}
		catch (Exception exception_)
		{
			method_46(exception_);
		}
	}

	public void A5326904()
	{
		if (method_61() != 1)
		{
			method_12("https://www.facebook.com/");
		}
		try
		{
			string string_ = Commom.FD9AD412("IncomingCallSounds");
			method_14(string_).ToString();
			string_ = Commom.FD9AD412("MessageSounds");
			method_14(string_).ToString();
			string_ = Commom.FD9AD412("PopupNewMessages");
			method_14(string_).ToString();
			string_ = Commom.FD9AD412("ShowContacts");
			method_14(string_).ToString();
		}
		catch (Exception)
		{
		}
	}

	public string FB001323()
	{
		string text = method_66("GetTokenEAABs");
		if (!text.StartsWith("EAA"))
		{
			text = "";
		}
		return text;
	}

	public string method_88()
	{
		string text = method_66("GetTokenEAAAAU");
		if (text.StartsWith("EAA"))
		{
			return text;
		}
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				text = Commom.smethod_6(B4208531, C234EEAA, A1BF36A2, A3A32284, Int32_1).Split('|')[0];
				if (text.StartsWith("EAA"))
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return text;
	}

	public string DC8F5A1A()
	{
		string text = "";
		if (!text.StartsWith("EAA"))
		{
			for (int i = 0; i < 3; i++)
			{
				string a1BF36A = A1BF36A2;
				string string_ = "[{\"name\":\"fa2\", \"value\":\"" + a1BF36A + "\", \"type\":\"text\"}]";
				text = method_66("GetTokenEAAG", string_);
				if (text.StartsWith("EAA"))
				{
					break;
				}
				method_59();
				F8091028(3.0);
			}
		}
		return text;
	}

	public string method_89()
	{
		string text = method_66("GetTokenEAAAAY");
		if (text.StartsWith("EAA"))
		{
			return text;
		}
		text = Commom.B0B017A1(B4208531, C234EEAA, A1BF36A2, A3A32284, Int32_1).Split('|')[0];
		if (text.StartsWith("EAA"))
		{
			return text;
		}
		return "";
	}

	public string F23C6F07()
	{
		string text = method_66("GetTokenEAABw");
		if (!text.StartsWith("EAA"))
		{
			text = "";
		}
		return text;
	}

	public string D7BD1D96(string string_10, int AF2ADA09)
	{
		try
		{
			string string_11 = $"[{{\"name\":\"tuKhoa\", \"value\":\"{string_10}\", \"type\":\"text\"}}, {{\"name\":\"limit\", \"value\":\"{AF2ADA09}\", \"type\":\"number\"}}]";
			return method_66("SearchGroup", string_11);
		}
		catch (Exception)
		{
		}
		return "";
	}

	public bool ED3CEFB3()
	{
		try
		{
			string json = method_66("Logout");
			JObject jObject = JObject.Parse(json);
			return Convert.ToBoolean(jObject["success"]);
		}
		catch (Exception)
		{
		}
		return false;
	}

	public string method_90()
	{
		return method_66("UnlinkInstagram");
	}

	public string method_91(string D10F6D9D)
	{
		string string_ = "[{\"name\":\"password\", \"value\":\"" + D10F6D9D + "\", \"type\":\"text\"}]";
		string json = method_66("LinkInstagram", string_);
		JObject jObject = JObject.Parse(json);
		return string.Format("{0}|{1}|{2}|{3}", jObject["success"], jObject["username"], jObject["password"], jObject["email"]);
	}

	private string method_92(int B5A0C206, string string_10)
	{
		return Commom.B820DC86(B5A0C206, string_10);
	}

	private string D5ABA580(string string_10, string string_11, int BAB5E582, string FD8725B9, string C43EA2A0)
	{
		if (CD930D04())
		{
			return "";
		}
		int tickCount = Environment.TickCount;
		while (true)
		{
			string text = RunCodeChrome($"GetOtpMailKhoiPhuc('{string_10}', {BAB5E582}, '{string_11}')");
			if (!(text != C43EA2A0))
			{
				if (Environment.TickCount - tickCount > BAB5E582 * 1000 || CD930D04())
				{
					break;
				}
				F8091028(3.0);
				continue;
			}
			return text;
		}
		return "";
	}

	private string F0183F27(int C8B36594, string string_10, string EB1B91A9, int int_4)
	{
		if (CD930D04() || E184CD03())
		{
			return "";
		}
		return RunCodeChrome($"ResolveImageMicrosoft({C8B36594}, '{string_10}', '{EB1B91A9}', {int_4})");
	}

	private string method_93()
	{
		int num = C5034B95.smethod_0("configHotmail").method_2("typePassword");
		string text = C5034B95.smethod_0("configHotmail").BDB80B23("txtPassChiDinh");
		if (num == 0)
		{
			return method_92(3, "A") + method_92(3, "a") + method_92(3, "0") + "@";
		}
		return text.smethod_1(2);
	}

	private (string mailKp, string passMailKp) CF1EBD05(string mail)
	{
		bool ckbThemKyTuGetnada = C5034B95.smethod_0("configHotmail").method_3("ckbThemKyTuGetnada");
		int typeKyTu = C5034B95.smethod_0("configHotmail").method_2("typeKyTu");
		string txtKyTuChiDinh = C5034B95.smethod_0("configHotmail").BDB80B23("txtKyTuChiDinh");
		string duoiMail = "";
		string item = "";
		switch (C5034B95.smethod_0("configHotmail").method_2("cbbTypeEmail"))
		{
		case 0:
			duoiMail = C5034B95.smethod_0("configHotmail").BDB80B23("cbbDomainGetnada", "getnada.com");
			break;
		case 1:
			duoiMail = C5034B95.smethod_0("configHotmail").BDB80B23("cbbDomainMoakt", "teml.net");
			break;
		case 2:
			duoiMail = C5034B95.smethod_0("configHotmail").BDB80B23("txtDomainGenerator");
			break;
		case 3:
			duoiMail = "otpgmail.com";
			break;
		case 4:
			duoiMail = "mailnesia.com";
			break;
		case 5:
			duoiMail = "smvmail.com";
			break;
		case 8:
			duoiMail = C5034B95.smethod_0("configHotmail").BDB80B23("cbbDomainMailtula", "mailtula.com");
			break;
		case 9:
			duoiMail = C5034B95.smethod_0("configHotmail").BDB80B23("txtDomainMailtm");
			item = Commom.B820DC86(10, "a_A_0");
			break;
		}
        //string item2 = RunCodeChrome($"GenerateRecoveryMail('{mail}', {method_4(ckbThemKyTuGetnada)}, {typeKyTu}, '{txtKyTuChiDinh}', '{duoiMail}')");
        string item2 = MaxCareLibPro.Common.GenerateRecoverybyhongbeoiii(mail, ckbThemKyTuGetnada, typeKyTu, txtKyTuChiDinh, duoiMail);
        return (item2, item);
	}

	public string method_94(string string_10, string string_11, string string_12, string A9304E36, GClass4 gclass4_0 = null)
	{
		string_10 = string_10.Trim();
		string_11 = string_11.Trim();
		string_12 = string_12.Trim();
		A9304E36 = A9304E36.Trim();
		if (gclass4_0 == null)
		{
			gclass4_0 = new GClass4();
		}
		bool flag = gclass4_0.method_3("UnlockHotmail");
		bool flag2 = gclass4_0.method_3("ThemMailKhoiPhuc2");
		int c8B = C5034B95.smethod_0("configRegHotmail").method_2("typeCaptcha");
		string string_13 = C5034B95.smethod_0("configRegHotmail").BDB80B23("txtCaptcha_" + c8B);
		int num = C5034B95.smethod_0("configHotmail").method_2("nudTimeoutGetOtpGetnada", 60);
		string text = C5034B95.smethod_0("configHotmail").method_1("lstProxyGetnada").smethod_8();
		if (string.IsNullOrEmpty(text))
		{
			text = DF115529;
		}
		int num2 = num + 60;
		int num3 = num;
		int int_ = 60;
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		gClass.method_4("mailRecover", string_12);
		gClass.method_4("passMailRecover", A9304E36);
		gClass.method_4("passmail", string_11);
		if (flag2)
		{
			method_12("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=159&ct=1725608543&rver=7.5.2156.0&wp=SA_20MIN&wreply=https%3A%2F%2Faccount.live.com%2Fpassword%2Fchange%3Frefd%3Daccount.microsoft.com%26fref%3Dhome.banner.changepwd%26uaid%3D0a801d2df34b466a81ca4fd348ad36c5&lc=1033&id=38936&mkt=en-US&uaid=0a801d2df34b466a81ca4fd348ad36c5");
		}
		else if (flag)
		{
			method_12(C5034B95.smethod_0("configHotmail").BDB80B23("cbbWebLogin", "https://www.microsoft.com/vi-vn/microsoft-365/"));
		}
		else
		{
			method_12("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=15&ct=1691141884&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3dd7a5dc50-1baa-7441-e411-465bdcd16528&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015");
		}
		F8091028(1.0);
		int num4 = 0;
		int num5 = 10;
		int num6 = 0;
		int num7 = num3 / 10;
		string text2 = "";
		int num8 = 0;
		int num9 = 2;
		int num10 = 0;
		int num11 = 3;
		int num12 = 3;
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		bool flag3 = false;
		string string_14 = "https://outlook.live.com/mail/0/";
		int tickCount = Environment.TickCount;
		while (true)
		{
			string text7;
			if (!CD930D04() && !E184CD03())
			{
				if (Environment.TickCount - tickCount < num2 * 1000)
				{
					text7 = method_15(0.0, new List<string>
					{
						"[name=\"loginfmt\"][aria-required=\"true\"]", "#usernameEntry", "[name=\"passwd\"][aria-required=\"true\"]", "#iLandingViewAction", "#btnAskLater", "[name=\"iProofEmail\"]", "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]", "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation", "[name=\"EmailAddress\"]", "[name=\"DontShowAgain\"]",
						"#O365_MainLink_Me,#mectrl_viewAccount", "#StartAction", "#iOttText,#otc-confirmation-input,[name=\"otc\"]", "#iCancel", "#iLooksGood", "[data-task=\"signin\"],#mectrl_main_trigger", "#idA_PWD_SwitchToPassword", "#loadingScreen", "#iSelectProofAction", "#iVerifyText",
						"#iResetPasswordAction", "#iResetSuccessAction", "[name=\"passwd\"]", "[name=\"loginfmt\"]", "#idDiv_SAOTCS_Proofs", "[id^=\"c-shellmenu_custom_outline_newtab_signin_\"]", "[data-testid=\"routeAnimationFluent\"] [data-testid=\"primaryButton\"]", "#i1011[href^=\"https://account.live.com/ResetPassword.aspx\"]", "[role=\"dialog\"] [data-bi-id=\"choice-i-am-a-parent\"]", "#iSigninName",
						"[data-testid=\"tileList\"] [role=\"listitem\"]", "[data-testid=\"proof-confirmation-email-input\"] input"
					});
					if (text7 != "")
					{
						num4 = 0;
					}
					string text8 = text7;
					string text9 = text8;
					uint num13 = AFAE75A0.smethod_0(text9);
					if (num13 <= 2170474919u)
					{
						if (num13 <= 1144402631)
						{
							if (num13 <= 654325030)
							{
								if (num13 <= 160560651)
								{
									if (num13 != 61418301)
									{
										if (num13 == 160560651 && text9 == "#iLandingViewAction")
										{
											goto IL_06bf;
										}
									}
									else if (text9 == "#iResetSuccessAction")
									{
										method_18(text7);
										goto IL_17ef;
									}
								}
								else if (num13 != 261348265)
								{
									if (num13 == 654325030 && text9 == "[data-testid=\"tileList\"] [role=\"listitem\"]")
									{
										goto IL_1067;
									}
								}
								else if (text9 == "[name=\"DontShowAgain\"]")
								{
									method_18(text7);
									F8091028(1.0);
									method_18("#idSIButton9, #acceptButton");
									goto IL_17ef;
								}
							}
							else if (num13 <= 926608917)
							{
								if (num13 != 853575775)
								{
									if (num13 == 926608917 && text9 == "[name=\"passwd\"][aria-required=\"true\"]")
									{
										goto IL_0e20;
									}
								}
								else if (text9 == "[name=\"loginfmt\"]")
								{
									goto IL_04e8;
								}
							}
							else if (num13 != 1020151071)
							{
								if (num13 == 1144402631 && text9 == "[name=\"loginfmt\"][aria-required=\"true\"]")
								{
									goto IL_04e8;
								}
							}
							else if (text9 == "#iCancel")
							{
								method_18(text7);
								goto IL_17ef;
							}
						}
						else if (num13 <= 1311303583)
						{
							if (num13 <= 1249266990)
							{
								if (num13 != 1208005370)
								{
									if (num13 == 1249266990 && text9 == "#usernameEntry")
									{
										if (method_5(text7) != "")
										{
											text6 = method_15(0.0, new List<string> { "[data-testid=\"usernameEntry\"] [role=\"alert\"]" });
											text3 = method_6(text6);
											if (text3 != "")
											{
												gClass.method_4("error", "Sai email");
												break;
											}
										}
										else
										{
											EB2B3FB0(text7);
											method_22(text7, string_10);
											F8091028(1.0);
											method_18("[data-testid=\"primaryButton\"]");
										}
										goto IL_17ef;
									}
								}
								else if (text9 == "#loadingScreen")
								{
									num4++;
									if (num4 >= 5)
									{
										num4 = 0;
										method_13();
									}
									goto IL_17ef;
								}
							}
							else if (num13 != 1301603804)
							{
								if (num13 == 1311303583 && text9 == "#btnAskLater")
								{
									goto IL_06bf;
								}
							}
							else if (text9 == "[role=\"dialog\"] [data-bi-id=\"choice-i-am-a-parent\"]")
							{
								break;
							}
						}
						else if (num13 <= 1599624365)
						{
							if (num13 != 1317621506)
							{
								if (num13 == 1599624365 && text9 == "[data-task=\"signin\"],#mectrl_main_trigger")
								{
									if (D7A424AE("a[id*=\"_rememberedAccount_\"]") && method_27("a[id*=\"_rememberedAccount_\"]"))
									{
										method_12(string_14);
									}
									else
									{
										method_18(text7);
									}
									goto IL_17ef;
								}
							}
							else if (text9 == "[data-testid=\"proof-confirmation-email-input\"] input")
							{
								goto IL_0ac0;
							}
						}
						else if (num13 != 2053805095)
						{
							if (num13 == 2170474919u && text9 == "#iResetPasswordAction")
							{
								text3 = method_14("return document.querySelector('#pNewPwdErrorArea').innerText");
								if (!(text3 != "") || !method_27("#pNewPwdErrorArea"))
								{
									if (method_5("#iPassword") == "")
									{
										string_11 = method_93();
										gClass.method_4("passmail", string_11);
										method_22("#iPassword", string_11);
										F8091028(1.0);
										method_22("#iRetypePassword", string_11);
										F8091028(1.0);
									}
									method_18(text7);
									goto IL_17ef;
								}
								gClass.method_4("error", "Lỗi khi nhập pass mới");
								break;
							}
						}
						else if (text9 == "#O365_MainLink_Me,#mectrl_viewAccount")
						{
							if (!GetURL().Contains("https://outlook.live.com/"))
							{
								method_12(string_14);
							}
							gClass.method_4("success", true);
							break;
						}
					}
					else if (num13 <= 3576173000u)
					{
						if (num13 <= 2620677736u)
						{
							if (num13 <= 2440571791u)
							{
								if (num13 != 2221530851u)
								{
									if (num13 == 2440571791u && text9 == "#iVerifyText")
									{
										num6++;
										text5 = D5ABA580(string_12, A9304E36, 10, text, text2);
										switch (text5)
										{
										case "":
											if (num6 < num7)
											{
												goto IL_17ef;
											}
											gClass.method_4("error", "Không lấy được otp");
											break;
										default:
											text2 = text5;
											EB2B3FB0(text7);
											method_22(text7, text5);
											F8091028(1.0);
											method_18("#iVerifyIdentityAction");
											goto IL_17ef;
										case "too_many_requests":
											gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
											break;
										case "fail":
											gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
											break;
										}
										break;
									}
								}
								else if (text9 == "#idA_PWD_SwitchToPassword")
								{
									method_18(text7);
									goto IL_17ef;
								}
							}
							else if (num13 != 2548005543u)
							{
								if (num13 == 2620677736u && text9 == "#StartAction")
								{
									gClass.method_4("error", "Hotmail bị khóa (1)");
									break;
								}
							}
							else if (text9 == "#iSelectProofAction")
							{
								text3 = method_6("#proofInput0Error");
								if (!(text3 != ""))
								{
									if (D7A424AE("//input[contains(@name,\"ProofOption\")][./following-sibling::span[contains(text(),'" + string_12.Split('@')[1] + "')]]"))
									{
										method_18("//input[contains(@name,\"ProofOption\")][./following-sibling::span[contains(text(),'" + string_12.Split('@')[1] + "')]]");
										F8091028(2.0);
										text2 = D5ABA580(string_12, A9304E36, 0, text, "");
										if (!(text2 == "fail"))
										{
											EB2B3FB0("input[name*=\"Email\"], input[type=\"email\"]");
											method_22("input[name*=\"Email\"], input[type=\"email\"]", string_12.Split('@')[0]);
											F8091028(2.0);
											method_18(text7);
											goto IL_17ef;
										}
										gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
										break;
									}
									gClass.method_4("error", "Mail khôi phục không đu\u0301ng");
									break;
								}
								gClass.method_4("error", "Lô\u0303i reset pass");
								break;
							}
						}
						else if (num13 <= 3188555620u)
						{
							if (num13 != 3002727654u)
							{
								if (num13 == 3188555620u && text9 == "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation")
								{
									goto IL_0ac0;
								}
							}
							else if (text9 == "[name=\"iProofEmail\"]")
							{
								F8091028(3.0);
								text3 = method_6("#iProofInputError");
								if (!(text3 != ""))
								{
									if (!D7A424AE("#iCollectPhoneViewSkip") || !method_27("#iCollectPhoneViewSkip"))
									{
										if (D7A424AE("[name=\"proof\"]"))
										{
											string text10 = method_14("var x=[]; document.querySelectorAll('[name=\"proof\"]').forEach(e => {x.push(e.value)}); return x.join('|');");
											if (!text10.Contains("@"))
											{
												gClass.method_4("error", "Xác minh phone");
												break;
											}
											if (string_12 == "" && string_12 == "")
											{
												gClass.method_4("error", "Xác minh mail khôi phục");
												break;
											}
											string text11 = "";
											MatchCollection matchCollection = Regex.Matches(text10, "\\@(.*?)\\|");
											foreach (Match item in matchCollection)
											{
												if (string_12.Split('@')[1] == item.Groups[1].Value)
												{
													text11 = item.Groups[1].Value;
													break;
												}
											}
											if (text11 == "")
											{
												gClass.method_4("error", "Mail khôi phục không khớp");
												break;
											}
											method_14("document.querySelectorAll('[name=\"proof\"]').forEach(e=>{if(e.getAttribute('value').includes('" + text11 + "')) e.click()})");
											F8091028(1.0);
										}
										if (!(string_12 == ""))
										{
											text2 = D5ABA580(string_12, A9304E36, 0, text, "");
											if (!(text2 == "fail"))
											{
												method_22(text7, string_12.Split('@')[0]);
												F8091028(1.0);
												method_18("#iSelectProofAction");
												goto IL_17ef;
											}
											gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
											break;
										}
										gClass.method_4("error", "Xác minh mail khôi phục");
										break;
									}
									gClass.method_4("error", "Hotmail bị khóa (2)");
									break;
								}
								gClass.method_4("error", "Sai mail khôi phục");
								break;
							}
						}
						else
						{
							switch (num13)
							{
							case 3576173000u:
								if (text9 == "[data-testid=\"routeAnimationFluent\"] [data-testid=\"primaryButton\"]")
								{
									method_18(text7);
									goto IL_17ef;
								}
								break;
							case 3283083884u:
								if (text9 == "#iSigninName")
								{
									EB2B3FB0(text7);
									method_22(text7, string_10);
									F8091028(1.0);
									method_18("#resetPwdHipAction");
									goto IL_17ef;
								}
								break;
							}
						}
					}
					else if (num13 <= 3904434194u)
					{
						if (num13 <= 3815666825u)
						{
							if (num13 != 3751185834u)
							{
								if (num13 == 3815666825u && text9 == "[name=\"passwd\"]")
								{
									goto IL_0e20;
								}
							}
							else if (text9 == "#iLooksGood")
							{
								method_18(text7);
								goto IL_17ef;
							}
						}
						else if (num13 != 3858357123u)
						{
							if (num13 == 3904434194u && text9 == "#i1011[href^=\"https://account.live.com/ResetPassword.aspx\"]")
							{
								gClass.method_4("error", "Sign-in is blocked");
								break;
							}
						}
						else if (text9 == "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]")
						{
							goto IL_1067;
						}
					}
					else if (num13 <= 3966638439u)
					{
						if (num13 != 3911541265u)
						{
							if (num13 == 3966638439u && text9 == "#iOttText,#otc-confirmation-input,[name=\"otc\"]")
							{
								if (D7A424AE("#idA_PWD_SwitchToPassword") && method_27("#idA_PWD_SwitchToPassword"))
								{
									method_18("#idA_PWD_SwitchToPassword");
								}
								else if (D7A424AE("#iFinishViewAction") && method_27("#iFinishViewAction"))
								{
									method_18("#iFinishViewAction");
								}
								else if (D7A424AE("#iCollectProofsViewAlternate") && method_27("#iCollectProofsViewAlternate"))
								{
									method_18("#iCollectProofsViewAlternate");
								}
								else if (D7A424AE("#iReviewProofsViewAction") && method_27("#iReviewProofsViewAction"))
								{
									method_18("#iReviewProofsViewAction");
								}
								else if (D7A424AE("#iRepeatCompromisedViewAction") && method_27("#iRepeatCompromisedViewAction"))
								{
									method_18("#iRepeatCompromisedViewAction");
								}
								else if (D7A424AE("#iShowSkip") && method_27("#iShowSkip"))
								{
									method_18("#iShowSkip");
								}
								else if (D7A424AE("[name=\"proof\"]") && method_27("[name=\"proof\"]"))
								{
									string text12 = method_14("var x=[]; document.querySelectorAll('[name=\"proof\"]').forEach(e => {x.push(e.value)}); return x.join('|');");
									if (!text12.Contains("@"))
									{
										gClass.method_4("error", "Xác minh phone");
										break;
									}
									if (string_12 == "")
									{
										gClass.method_4("error", "Xác minh mail khôi phục");
										break;
									}
									string text13 = "";
									MatchCollection matchCollection2 = Regex.Matches(text12, "\\@(.*?)\\|");
									foreach (Match item2 in matchCollection2)
									{
										if (string_12.Split('@')[1] == item2.Groups[1].Value)
										{
											text13 = item2.Groups[1].Value;
											break;
										}
									}
									if (text13 == "")
									{
										gClass.method_4("error", "Mail khôi phục không khớp");
										break;
									}
									method_14("document.querySelectorAll('[name=\"proof\"]').forEach(e=>{if(e.getAttribute('value').includes('" + text13 + "')) e.click()})");
									F8091028(1.0);
									method_18("#iNext,[name=\"otc-confirmation\"] button[type=\"submit\"],[name=\"OneTimeCodeViewForm\"] button[type=\"submit\"],#idSubmit_SAOTCC_Continue");
								}
								else if (D7A424AE("#maincontent #iPassword") && method_27("#maincontent #iPassword"))
								{
									if (method_5("#maincontent #iPassword") == "")
									{
										string_11 = method_93();
										gClass.method_4("passmail", string_11);
										method_22("#maincontent #iPassword", string_11);
										F8091028(1.0);
									}
									method_18("#iPasswordViewAction");
								}
								else if (!(string_12 == ""))
								{
									num6++;
									text5 = D5ABA580(string_12, A9304E36, 10, text, text2);
									switch (text5)
									{
									case "":
										if (num6 < num7)
										{
											goto IL_17ef;
										}
										gClass.method_4("error", "Không lấy được otp");
										break;
									default:
										text2 = text5;
										if (method_27(text7))
										{
											EB2B3FB0(text7);
											method_22(text7, text5);
											F8091028(1.0);
											method_18("#iVerifyCodeAction,#iNext,[name=\"otc-confirmation\"] button[type=\"submit\"],[name=\"OneTimeCodeViewForm\"] button[type=\"submit\"],#idSubmit_SAOTCC_Continue");
										}
										else
										{
											text7 = method_15(0.0, new List<string> { "[data-testid=\"codeEntryField\"] input" });
											EB2B3FB0(text7);
											method_22(text7, text5);
										}
										goto IL_17ef;
									case "too_many_requests":
										gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
										break;
									case "fail":
										gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
										break;
									}
									break;
								}
								goto IL_17ef;
							}
						}
						else if (text9 == "[id^=\"c-shellmenu_custom_outline_newtab_signin_\"]")
						{
							string text14 = B9BE8807(text7, "href");
							if (text14 != "")
							{
								num12--;
								if (num12 < 0)
								{
									break;
								}
								method_12(text14);
							}
							else
							{
								method_12(string_14);
							}
							goto IL_17ef;
						}
					}
					else if (num13 != 4022600828u)
					{
						if (num13 == 4109521859u && text9 == "[name=\"EmailAddress\"]")
						{
							if (D7A424AE("#iEmailSection") && !method_27("#iEmailSection"))
							{
								method_31("#iEmailSection");
							}
							else if (D7A424AE("#iShowSkip") && method_27("#iShowSkip"))
							{
								method_18("#iShowSkip");
							}
							else
							{
								string text15 = E3A1A80C(string_10, string_11, string_12, A9304E36);
								GClass4 gClass2 = new GClass4(text15, F79F9AB5: true);
								if (!gClass2.method_3("success"))
								{
									gClass.method_4("error", "Yêu cầu add mail khôi phục");
									break;
								}
								string_12 = gClass2.BDB80B23("mailRecover");
								A9304E36 = gClass2.BDB80B23("passMailRecover");
								gClass.method_4("mailRecover", string_12);
								gClass.method_4("passMailRecover", A9304E36);
								method_12(string_14);
							}
							goto IL_17ef;
						}
					}
					else if (text9 == "#idDiv_SAOTCS_Proofs")
					{
						goto IL_17ef;
					}
					if (D7A424AE("#iNext") && method_27("#iNext"))
					{
						method_17("#iNext");
					}
					else
					{
						string text16 = GetURL();
						if (text16.StartsWith("https://privacynotice.account.microsoft.com/notice"))
						{
							method_18("button");
						}
						else
						{
							string text17 = AFACE5B4();
							if (text16.StartsWith("https://account.microsoft.com/auth/complete-client-signin-oauth-silent?state=") || text16.StartsWith("https://account.live.com/error.aspx?errcode=") || text16.Contains("chrome-error://chromewebdata/") || text17.Contains("Ref A:") || text17.Contains("Service Unavailable") || text17.Contains("ERR_HTTP2_PROTOCOL_ERROR") || text17.Contains("HTTP ERROR 503") || text17.Contains("ERR_TOO_MANY_RETRIES"))
							{
								num4++;
								if (num4 >= 5)
								{
									num4 = 0;
									method_12(string_14);
								}
							}
							else if (text16.StartsWith("https://www.office.com/?auth="))
							{
								method_12(string_14);
							}
							else if (D7A424AE("#app button"))
							{
								method_18("#app button");
							}
							else if (D7A424AE(".refreshPageButton"))
							{
								method_14("refreshPage();");
							}
							else
							{
								if (num4 >= num5)
								{
									break;
								}
								num4++;
							}
						}
					}
					goto IL_17ef;
				}
				gClass.method_4("error", "timeout");
				break;
			}
			gClass.method_4("error", "chrome_closed");
			break;
			IL_04e8:
			if (method_5(text7) != "")
			{
				text6 = method_15(0.0, new List<string> { "#usernameError", "[data-testid=\"inputComponentWrapper\"] [role=\"alert\"]" });
				text3 = method_6(text6);
				if (text3 != "")
				{
					gClass.method_4("error", "Sai email");
					break;
				}
			}
			else
			{
				EEB5149C(text7);
				method_22(text7, string_10);
				F8091028(1.0);
				method_18("#idSIButton9");
			}
			goto IL_17ef;
			IL_1067:
			if (flag3)
			{
				break;
			}
			if (!(string_12 == ""))
			{
				if (method_30("[role=\"listitem\"]") > 1)
				{
					text7 = "//*[@role='listitem'][.//*[contains(text(),'" + string_12.Split('@')[1] + "')]]";
					if (!D7A424AE(text7))
					{
						gClass.method_4("error", "Xác minh mail khôi phục cũ");
						break;
					}
					method_18(text7);
				}
				else
				{
					method_18(text7);
				}
				goto IL_17ef;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			if (method_6(text7).Contains("+"))
			{
				gClass.method_4("error", "Xác minh phone cũ");
			}
			break;
			IL_0ac0:
			text3 = method_14("return document.querySelector('#id_SAOTCS_Error_ProofConfirmation,#proof-confirmationError').innerText");
			if (!(text3 != ""))
			{
				text2 = D5ABA580(string_12, A9304E36, 0, text, "");
				if (!(text2 == "fail"))
				{
					EB2B3FB0(text7);
					method_22(text7, string_12.Split('*')[0]);
					F8091028(1.0);
					method_18(method_15(0.0, new List<string> { "#idSubmit_SAOTCS_SendCode,[name=\"proof-confirmation\"] button[type=\"submit\"]", "button[type=\"submit\"]" }));
					goto IL_17ef;
				}
				gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
				break;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			break;
			IL_0e20:
			if (D7A424AE("[id^=\"wlspispHIPBimg\"]"))
			{
				string text18 = method_14("var img=document.querySelector('[id^=\"wlspispHIPBimg\"]');var d=document.createElement('canvas');d.height=96;d.width=216;var ctx=d.getContext('2d');ctx.drawImage(img,0,0);var x=d.toDataURL(); return x").Replace("data:image/png;base64,", "");
				if (!(text18 == "") && !(text18 == "iVBORw0KGgoAAAANSUhEUgAAANgAAABgCAYAAAB/ubz1AAAAAXNSR0IArs4c6QAAAjZJREFUeF7t0zERAAAIAzHq3zQqfgsCOuT4nSNAIBNYtmyYAIETmCcgEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEBOYHCIQCAgtxTRMQmB8gEAoILMQ1TUBgfoBAKCCwENc0AYH5AQKhgMBCXNMEHrwyAGGfbFR9AAAAAElFTkSuQmCC"))
				{
					num10++;
					if (num10 > num11)
					{
						gClass.method_4("error", "Captcha");
						break;
					}
					text4 = F0183F27(c8B, string_13, text18, int_);
					if (text4 == "")
					{
						method_18("[id^=\"wlspispHIPNew\"]");
					}
					else
					{
						method_22("[id^=\"wlspispSolutionElement\"]", text4);
						F8091028(1.0);
						method_22(text7, string_11);
						F8091028(1.0);
						method_18("#idSIButton9");
					}
				}
			}
			else
			{
				text6 = method_15(0.0, new List<string> { "#passwordError", "[data-testid=\"inputComponentWrapper\"] [role=\"alert\"]", "[data-testid=\"passwordEntry\"] [role=\"alert\"]" });
				text3 = method_6(text6);
				if (text3 != "")
				{
					string text19 = method_15(0.0, new List<string>
					{
						"#idA_IL_ForgotPassword0",
						"[data-testid=\"passwordEntry\"]+div>button.fui-Link",
						text6 + " span"
					});
					if (text19 != "" && string_12 != "")
					{
						method_18(text19);
						goto IL_17ef;
					}
					num8++;
					if (num8 >= num9)
					{
						gClass.method_4("error", "Sai passmail");
						break;
					}
				}
				if (!(method_5(text7) != ""))
				{
					method_22(text7, string_11);
					F8091028(1.0);
					method_18("#idSIButton9,[data-testid=\"primaryButton\"]");
				}
			}
			goto IL_17ef;
			IL_17ef:
			F8091028(1.0);
			continue;
			IL_06bf:
			method_18(text7);
			goto IL_17ef;
		}
		if (!gClass.method_3("success") && gClass.BDB80B23("error") == "")
		{
			gClass.method_4("error", "fail");
		}
		return gClass.ED11179C();
	}

	public string E3A1A80C(string E70CEF04, string DA96A305, string A736EC03, string string_10)
	{
		int num = C5034B95.smethod_0("configHotmail").method_2("nudTimeoutGetOtpGetnada", 60);
		string text = C5034B95.smethod_0("configHotmail").method_1("lstProxyGetnada").smethod_8();
		if (string.IsNullOrEmpty(text))
		{
			text = DF115529;
		}
		int num2 = num + 60;
		int num3 = num;
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		gClass.method_4("mailRecover", A736EC03);
		gClass.method_4("passMailRecover", string_10);
		gClass.method_4("passmail", DA96A305);
		string string_11 = "https://account.live.com/proofs/Add?uaid=50148bd952d946c6bfd5a8e09f28f510&mpSplit=2&apt=2";
		method_12(string_11);
		F8091028(1.0);
		int tickCount = Environment.TickCount;
		int num4 = 0;
		int num5 = 10;
		int num6 = 0;
		int num7 = num3 / 10;
		string text2 = "";
		bool flag = false;
		string text3 = "";
		string text4 = "";
		while (true)
		{
			string text5 = method_15(0.0, new List<string> { "[name=\"EmailAddress\"]", "#iOttText,#otc-confirmation-input,[name=\"otc\"]", "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]", "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation", "#idTxtBx_SAOTCC_OTC", "#O365_MainLink_Me", "#iCancel", "[name=\"passwd\"][aria-required=\"true\"]", "[data-testid=\"tileList\"] [role=\"listitem\"]", "[data-testid=\"proof-confirmation-email-input\"] input" });
			if (text5 != "")
			{
				num4 = 0;
			}
			string text6 = text5;
			string text7 = text6;
			uint num8 = AFAE75A0.smethod_0(text7);
			if (num8 <= 3188555620u)
			{
				if (num8 <= 926608917)
				{
					if (num8 != 654325030)
					{
						if (num8 == 926608917 && text7 == "[name=\"passwd\"][aria-required=\"true\"]")
						{
							text3 = method_14("return document.querySelector('#passwordError').innerText");
							if (!(text3 != ""))
							{
								if (!(method_5(text5) != ""))
								{
									method_22(text5, DA96A305);
									F8091028(1.0);
									method_18("#idSIButton9");
								}
								goto IL_0753;
							}
							gClass.method_4("error", "Sai passmail");
							break;
						}
					}
					else if (text7 == "[data-testid=\"tileList\"] [role=\"listitem\"]")
					{
						goto IL_02fd;
					}
				}
				else if (num8 != 1020151071)
				{
					if (num8 != 1317621506)
					{
						if (num8 == 3188555620u && text7 == "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation")
						{
							goto IL_01fc;
						}
					}
					else if (text7 == "[data-testid=\"proof-confirmation-email-input\"] input")
					{
						goto IL_01fc;
					}
				}
				else if (text7 == "#iCancel")
				{
					method_18(text5);
					goto IL_0753;
				}
			}
			else
			{
				if (num8 > 3858357123u)
				{
					if (num8 != 3966638439u)
					{
						if (num8 != 4109521859u)
						{
							if (num8 != 4138054670u || !(text7 == "#idTxtBx_SAOTCC_OTC"))
							{
								goto IL_0546;
							}
							if (!(A736EC03 == ""))
							{
								num6++;
								text4 = D5ABA580(A736EC03, string_10, 10, text, text2);
								switch (text4)
								{
								case "":
									break;
								default:
									goto IL_044e;
								case "too_many_requests":
									goto IL_08ff;
								case "fail":
									goto IL_0915;
								}
								if (num6 >= num7)
								{
									gClass.method_4("error", "Không lấy được otp");
									break;
								}
							}
						}
						else
						{
							if (!(text7 == "[name=\"EmailAddress\"]"))
							{
								goto IL_0546;
							}
							text3 = method_14("return document.querySelector('#EmailError').innerText");
							if (text3 != "")
							{
								if (!(text3.Contains("This is already part of your security info") && flag))
								{
									flag = false;
									gClass.method_4("error", "Lỗi khi nhập mail khôi phục");
								}
								break;
							}
							if (method_5(text5) == "")
							{
								(string mailKp, string passMailKp) tuple = CF1EBD05(E70CEF04);
								A736EC03 = tuple.mailKp;
								string_10 = tuple.passMailKp;
								text2 = D5ABA580(A736EC03, string_10, 0, text, "");
								if (text2 == "fail")
								{
									gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
									break;
								}
								EB2B3FB0(text5);
								method_22(text5, A736EC03);
								F8091028(1.0);
							}
							method_18("#iNext");
						}
					}
					else
					{
						if (!(text7 == "#iOttText,#otc-confirmation-input,[name=\"otc\"]"))
						{
							goto IL_0546;
						}
						flag = false;
						num6++;
						text4 = D5ABA580(A736EC03, string_10, 10, text, text2);
						switch (text4)
						{
						case "":
							break;
						default:
							goto IL_06dc;
						case "too_many_requests":
							goto IL_09a1;
						case "fail":
							goto IL_09b4;
						}
						if (num6 >= num7)
						{
							gClass.method_4("error", "Không lấy được otp");
							break;
						}
					}
					goto IL_0753;
				}
				if (num8 != 3797872910u)
				{
					if (num8 == 3858357123u && text7 == "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]")
					{
						goto IL_02fd;
					}
				}
				else if (text7 == "#O365_MainLink_Me")
				{
					break;
				}
			}
			goto IL_0546;
			IL_044e:
			text2 = text4;
			EB2B3FB0(text5);
			method_22(text5, text4);
			F8091028(1.0);
			method_18("#idSubmit_SAOTCC_Continue");
			goto IL_0753;
			IL_09b4:
			gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
			break;
			IL_0546:
			if (D7A424AE("#iNext") && method_27("#iNext"))
			{
				method_17("#iNext");
			}
			else
			{
				string text8 = GetURL();
				if (text8.StartsWith("https://privacynotice.account.microsoft.com/notice"))
				{
					method_18("button");
				}
				else
				{
					string text9 = AFACE5B4();
					if (text8.StartsWith("https://account.microsoft.com/auth/complete-client-signin-oauth-silent?state=") || text8.StartsWith("https://account.live.com/error.aspx?errcode=") || text8.Contains("chrome-error://chromewebdata/") || text9.Contains("Ref A:") || text9.Contains("Service Unavailable") || text9.Contains("ERR_HTTP2_PROTOCOL_ERROR") || text9.Contains("HTTP ERROR 503") || text9.Contains("ERR_TOO_MANY_RETRIES"))
					{
						num4++;
						if (num4 >= 5)
						{
							num4 = 0;
							method_12(string_11);
						}
					}
					else if (D7A424AE(".refreshPageButton"))
					{
						method_14("refreshPage();");
					}
					else
					{
						if (num4 >= num5)
						{
							break;
						}
						num4++;
					}
				}
			}
			goto IL_0753;
			IL_02fd:
			if (flag)
			{
				break;
			}
			if (!C5034B95.smethod_0("configHotmail").method_3("ckbBoQuaNeuDaCoMailKP"))
			{
				if (!(A736EC03 == ""))
				{
					if (method_30("[role=\"listitem\"]") > 1)
					{
						text5 = "//*[@role='listitem'][.//*[contains(text(),'" + A736EC03.Split('@')[1] + "')]]";
						if (!D7A424AE(text5))
						{
							gClass.method_4("error", "Xác minh mail khôi phục cũ");
							break;
						}
						method_18(text5);
					}
					else
					{
						method_18(text5);
					}
					goto IL_0753;
				}
				gClass.method_4("error", "Xác minh mail khôi phục cũ");
				if (!method_6(text5).Contains("@"))
				{
					gClass.method_4("error", "Xác minh phone cũ");
				}
				break;
			}
			gClass.method_4("error", Language.GetValue("Bo\u0309 qua"));
			break;
			IL_01fc:
			text3 = method_14("return document.querySelector('#id_SAOTCS_Error_ProofConfirmation,#proof-confirmationError').innerText");
			if (!(text3 != ""))
			{
				text2 = D5ABA580(A736EC03, string_10, 0, text, "");
				if (!(text2 == "fail"))
				{
					EB2B3FB0(text5);
					method_22(text5, A736EC03.Split('*')[0]);
					F8091028(1.0);
					method_18(method_15(0.0, new List<string> { "#idSubmit_SAOTCS_SendCode,[name=\"proof-confirmation\"] button[type=\"submit\"]", "button[type=\"submit\"]" }));
					goto IL_0753;
				}
				gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
				break;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			break;
			IL_06dc:
			text2 = text4;
			if (method_27(text5))
			{
				EB2B3FB0(text5);
				method_22(text5, text4);
				F8091028(1.0);
				method_18("#iNext,[name=\"otc-confirmation\"] button[type=\"submit\"],[name=\"OneTimeCodeViewForm\"] button[type=\"submit\"],#idSubmit_SAOTCC_Continue");
			}
			else
			{
				text5 = method_15(0.0, new List<string> { "[data-testid=\"codeEntryField\"] input" });
				EB2B3FB0(text5);
				method_22(text5, text4);
			}
			flag = true;
			goto IL_0753;
			IL_0915:
			gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
			break;
			IL_09a1:
			gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
			break;
			IL_0753:
			if (!CD930D04() && !E184CD03())
			{
				if (Environment.TickCount - tickCount < num2 * 1000)
				{
					F8091028(1.0);
					continue;
				}
				gClass.method_4("error", "timeout");
				break;
			}
			gClass.method_4("error", "chrome_closed");
			break;
			IL_08ff:
			gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
			break;
		}
		if (!gClass.method_3("success") && gClass.BDB80B23("error") == "")
		{
			if (flag)
			{
				gClass.method_4("success", true);
				gClass.method_4("mailRecover", A736EC03);
				gClass.method_4("passMailRecover", string_10);
			}
			else
			{
				gClass.method_4("error", "Add mail khôi phục thất bại");
			}
		}
		return gClass.ED11179C();
	}

	public string C21E6A38(string FAB7970D, string string_10, string string_11, string string_12)
	{
		string text = C5034B95.smethod_0("configHotmail").method_1("lstProxyGetnada").smethod_8();
		if (string.IsNullOrEmpty(text))
		{
			text = DF115529;
		}
		int num = 120;
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		gClass.method_4("passmail", string_10);
		gClass.method_4("mailRecover", string_11);
		gClass.method_4("passMailRecover", string_12);
		string string_13 = "https://account.live.com/proofs/manage/additional?mkt=en-US&refd=account.microsoft.com&refp=security";
		method_12(string_13);
		F8091028(1.0);
		int tickCount = Environment.TickCount;
		int num2 = 0;
		int num3 = 10;
		int num4 = 0;
		int num5 = 6;
		string text2 = "";
		string text3 = "";
		string text4 = "";
		while (true)
		{
			string text5 = method_15(0.0, new List<string> { "[id*=\"Email\"]", "#iOttText,#otc-confirmation-input,[name=\"otc\"]", "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]", "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation", "#idTxtBx_SAOTCC_OTC", "#iCancel", "[name=\"passwd\"][aria-required=\"true\"]", "[data-testid=\"tileList\"] [role=\"listitem\"]", "[data-testid=\"proof-confirmation-email-input\"] input" });
			if (text5 != "")
			{
				num2 = 0;
			}
			string text6 = text5;
			string text7 = text6;
			uint num6 = AFAE75A0.smethod_0(text7);
			if (num6 <= 1317621506)
			{
				if (num6 <= 926608917)
				{
					if (num6 != 654325030)
					{
						if (num6 == 926608917 && text7 == "[name=\"passwd\"][aria-required=\"true\"]")
						{
							text3 = method_14("return document.querySelector('#passwordError').innerText");
							if (!(text3 != ""))
							{
								if (!(method_5(text5) != ""))
								{
									EB2B3FB0(text5);
									method_22(text5, string_10);
									F8091028(1.0);
									method_18("#idSIButton9");
								}
								goto IL_074a;
							}
							gClass.method_4("error", "Sai passmail");
							break;
						}
					}
					else if (text7 == "[data-testid=\"tileList\"] [role=\"listitem\"]")
					{
						goto IL_021c;
					}
				}
				else if (num6 != 1020151071)
				{
					if (num6 == 1317621506 && text7 == "[data-testid=\"proof-confirmation-email-input\"] input")
					{
						goto IL_02a6;
					}
				}
				else if (text7 == "#iCancel")
				{
					method_18(text5);
					goto IL_074a;
				}
			}
			else
			{
				if (num6 > 3858357123u)
				{
					if (num6 != 3966638439u)
					{
						if (num6 != 4138054670u)
						{
							if (num6 != 4170035877u || !(text7 == "[id*=\"Email\"]"))
							{
								goto IL_0543;
							}
							if (D7A424AE("[name=\"EmailAddress\"]") && method_27("[name='EmailAddress']"))
							{
								text5 = "[name='EmailAddress']";
								text3 = method_14("return document.querySelector('#EmailError').innerText");
								if (text3 != "")
								{
									string_11 = "";
									gClass.method_4("error", "Lỗi khi nhập mail khôi phục");
									break;
								}
								if (method_5(text5) == "")
								{
									(string mailKp, string passMailKp) tuple = CF1EBD05(FAB7970D);
									string_11 = tuple.mailKp;
									string_12 = tuple.passMailKp;
									text2 = D5ABA580(string_11, string_12, 0, text, "");
									if (text2 == "fail")
									{
										gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
										break;
									}
									EB2B3FB0(text5);
									method_22(text5, string_11);
									F8091028(1.0);
								}
								method_18("#iNext");
							}
							else
							{
								if (!D7A424AE("#iBtn_action"))
								{
									for (int i = 0; i < 2; i++)
									{
										List<string> list = JArray.Parse(RunCodeChrome("GetMailKhoiPhuc()")).Values<string>().ToList();
										if (list.Count != 0)
										{
											if (list.Count != 1)
											{
												RunCodeChrome("XoaMailKhoiPhuc('" + string_11 + "')");
												method_13();
												continue;
											}
											gClass.method_4("success", true);
											break;
										}
										gClass.method_4("error", "Không ti\u0300m thâ\u0301y mail kp");
										break;
									}
									break;
								}
								method_18("#iBtn_action");
							}
						}
						else
						{
							if (!(text7 == "#idTxtBx_SAOTCC_OTC"))
							{
								goto IL_0543;
							}
							if (!(string_11 == ""))
							{
								num4++;
								text4 = D5ABA580(string_11, string_12, 10, text, text2);
								switch (text4)
								{
								case "":
									break;
								default:
									goto IL_04fa;
								case "too_many_requests":
									goto IL_0987;
								case "fail":
									goto IL_0999;
								}
								if (num4 >= num5)
								{
									gClass.method_4("error", "Không lấy được otp");
									break;
								}
							}
						}
					}
					else
					{
						if (!(text7 == "#iOttText,#otc-confirmation-input,[name=\"otc\"]"))
						{
							goto IL_0543;
						}
						num4++;
						text4 = D5ABA580(string_11, string_12, 10, text, text2);
						switch (text4)
						{
						case "":
							break;
						default:
							goto IL_06d6;
						case "too_many_requests":
							goto IL_09e1;
						case "fail":
							goto IL_09f3;
						}
						if (num4 >= num5)
						{
							gClass.method_4("error", "Không lấy được otp");
							break;
						}
					}
					goto IL_074a;
				}
				if (num6 != 3188555620u)
				{
					if (num6 == 3858357123u && text7 == "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]")
					{
						goto IL_021c;
					}
				}
				else if (text7 == "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation")
				{
					goto IL_02a6;
				}
			}
			goto IL_0543;
			IL_0543:
			if (D7A424AE("#iNext") && method_27("#iNext"))
			{
				method_17("#iNext");
			}
			else
			{
				string text8 = GetURL();
				if (text8.StartsWith("https://privacynotice.account.microsoft.com/notice"))
				{
					method_18("button");
				}
				else
				{
					string text9 = AFACE5B4();
					if (text8.StartsWith("https://account.microsoft.com/auth/complete-client-signin-oauth-silent?state=") || text8.StartsWith("https://account.live.com/error.aspx?errcode=") || text8.Contains("chrome-error://chromewebdata/") || text9.Contains("Ref A:") || text9.Contains("Service Unavailable") || text9.Contains("ERR_HTTP2_PROTOCOL_ERROR") || text9.Contains("HTTP ERROR 503") || text9.Contains("ERR_TOO_MANY_RETRIES"))
					{
						num2++;
						if (num2 >= 5)
						{
							num2 = 0;
							method_12(string_13);
						}
					}
					else if (D7A424AE(".refreshPageButton"))
					{
						method_14("refreshPage();");
					}
					else
					{
						if (num2 >= num3)
						{
							break;
						}
						num2++;
					}
				}
			}
			goto IL_074a;
			IL_09e1:
			gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
			break;
			IL_04fa:
			text2 = text4;
			EB2B3FB0(text5);
			method_22(text5, text4);
			F8091028(1.0);
			method_18("#idSubmit_SAOTCC_Continue");
			goto IL_074a;
			IL_09f3:
			gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
			break;
			IL_0999:
			gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
			break;
			IL_02a6:
			text3 = method_14("return document.querySelector('#id_SAOTCS_Error_ProofConfirmation,#proof-confirmationError').innerText");
			if (!(text3 != ""))
			{
				text2 = D5ABA580(string_11, string_12, 0, text, "");
				if (!(text2 == "fail"))
				{
					EB2B3FB0(text5);
					method_22(text5, string_11.Split('*')[0]);
					F8091028(1.0);
					method_18(method_15(0.0, new List<string> { "#idSubmit_SAOTCS_SendCode,[name=\"proof-confirmation\"] button[type=\"submit\"]", "button[type=\"submit\"]" }));
					goto IL_074a;
				}
				gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
				break;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			break;
			IL_0987:
			gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
			break;
			IL_021c:
			if (!(string_11 == ""))
			{
				if (method_30("[role=\"listitem\"]") > 1)
				{
					text5 = "//*[@role='listitem'][.//*[contains(text(),'" + string_11.Split('@')[1] + "')]]";
					if (!D7A424AE(text5))
					{
						gClass.method_4("error", "Xác minh mail khôi phục cũ");
						break;
					}
					method_18(text5);
				}
				else
				{
					method_18(text5);
				}
				goto IL_074a;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			if (method_6(text5).Contains("+"))
			{
				gClass.method_4("error", "Xác minh phone cũ");
			}
			break;
			IL_074a:
			if (!CD930D04() && !E184CD03())
			{
				if (Environment.TickCount - tickCount < num * 1000)
				{
					F8091028(1.0);
					continue;
				}
				gClass.method_4("error", "timeout");
				break;
			}
			gClass.method_4("error", "chrome_closed");
			break;
			IL_06d6:
			text2 = text4;
			if (method_27(text5))
			{
				EB2B3FB0(text5);
				method_22(text5, text4);
				F8091028(1.0);
				method_18("#iNext,[name=\"otc-confirmation\"] button[type=\"submit\"],[name=\"OneTimeCodeViewForm\"] button[type=\"submit\"],#idSubmit_SAOTCC_Continue");
			}
			else
			{
				text5 = method_15(0.0, new List<string> { "[data-testid=\"codeEntryField\"] input" });
				EB2B3FB0(text5);
				method_22(text5, text4);
			}
			goto IL_074a;
		}
		if (!gClass.method_3("success") && gClass.BDB80B23("error") == "")
		{
			gClass.method_4("error", "Xóa mail khôi phục thất bại");
		}
		gClass.method_4("mailRecover", string_11);
		gClass.method_4("passMailRecover", string_12);
		return gClass.ED11179C();
	}

	public string E8032DA4(string CD070887, string F62ADAA0, string D812CF8A, string string_10)
	{
		int num = C5034B95.smethod_0("configHotmail").method_2("nudTimeoutGetOtpGetnada", 60);
		string text = C5034B95.smethod_0("configHotmail").method_1("lstProxyGetnada").smethod_8();
		if (string.IsNullOrEmpty(text))
		{
			text = DF115529;
		}
		int num2 = num + 60;
		int num3 = num;
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		gClass.method_4("passmail", F62ADAA0);
		gClass.method_4("mailRecover", D812CF8A);
		gClass.method_4("passMailRecover", string_10);
		string string_11 = "https://account.live.com/password/change?refd=account.microsoft.com&fref=home.banner.changepwd";
		method_12(string_11);
		F8091028(1.0);
		int tickCount = Environment.TickCount;
		int num4 = 0;
		int num5 = 10;
		int num6 = 0;
		int num7 = num3 / 10;
		bool flag = false;
		string text2 = "";
		string text3 = "";
		while (true)
		{
			string text4 = method_15(0.0, new List<string>
			{
				"[name=\"EmailAddress\"]", "#iOttText,#otc-confirmation-input,[name=\"otc\"]", "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]", "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation", "#idTxtBx_SAOTCC_OTC", "#iCancel", "#iCurPassword", "#O365_MainLink_Me", "[name=\"passwd\"]", "[data-testid=\"tileList\"] [role=\"listitem\"]",
				"[data-testid=\"proof-confirmation-email-input\"] input"
			});
			if (text4 != "")
			{
				num4 = 0;
			}
			string text5 = text4;
			string text6 = text5;
			uint num8 = AFAE75A0.smethod_0(text6);
			string text7;
			if (num8 <= 3508380156u)
			{
				if (num8 <= 1020151071)
				{
					if (num8 != 654325030)
					{
						if (num8 == 1020151071 && text6 == "#iCancel")
						{
							method_18(text4);
							goto IL_086e;
						}
					}
					else if (text6 == "[data-testid=\"tileList\"] [role=\"listitem\"]")
					{
						goto IL_0394;
					}
				}
				else if (num8 != 1317621506)
				{
					if (num8 != 3188555620u)
					{
						if (num8 == 3508380156u && text6 == "#iCurPassword")
						{
							text7 = method_14("return document.querySelector('#pPwdErrorArea').innerText");
							if (!(text7 != "") || !method_27("#pPwdErrorArea"))
							{
								text7 = method_14("return document.querySelector('#pNewPwdErrorArea').innerText");
								if (!(text7 != "") || !method_27("#pNewPwdErrorArea"))
								{
									if (method_5(text4) == "")
									{
										method_22(text4, F62ADAA0);
										F8091028(1.0);
										string text8 = method_93();
										method_22("#iPassword", text8);
										F8091028(1.0);
										method_22("#iRetypePassword", text8);
										F8091028(1.0);
										gClass.method_4("passmail", text8);
									}
									if (method_18("#UpdatePasswordAction"))
									{
										flag = true;
									}
									goto IL_086e;
								}
								flag = false;
								gClass.method_4("error", "Lỗi khi nhập pass mới");
								break;
							}
							flag = false;
							gClass.method_4("error", "Lỗi khi nhập pass mới");
							break;
						}
					}
					else if (text6 == "#idTxtBx_SAOTCS_ProofConfirmation,#proof-confirmation")
					{
						goto IL_02a6;
					}
				}
				else if (text6 == "[data-testid=\"proof-confirmation-email-input\"] input")
				{
					goto IL_02a6;
				}
			}
			else
			{
				if (num8 > 3858357123u)
				{
					if (num8 != 3966638439u)
					{
						if (num8 != 4109521859u)
						{
							if (num8 != 4138054670u || !(text6 == "#idTxtBx_SAOTCC_OTC"))
							{
								goto IL_0667;
							}
							if (!(D812CF8A == ""))
							{
								num6++;
								text3 = D5ABA580(D812CF8A, string_10, 10, text, text2);
								switch (text3)
								{
								case "":
									break;
								default:
									goto IL_056f;
								case "too_many_requests":
									goto IL_0a39;
								case "fail":
									goto IL_0a4f;
								}
								if (num6 >= num7)
								{
									gClass.method_4("error", "Không lấy được otp");
									break;
								}
							}
						}
						else
						{
							if (!(text6 == "[name=\"EmailAddress\"]"))
							{
								goto IL_0667;
							}
							text7 = method_14("return document.querySelector('#EmailError').innerText");
							if (text7 != "")
							{
								D812CF8A = "";
								gClass.method_4("error", "Lỗi khi nhập mail khôi phục");
								break;
							}
							if (method_5(text4) == "")
							{
								(string mailKp, string passMailKp) tuple = CF1EBD05(CD070887);
								D812CF8A = tuple.mailKp;
								string_10 = tuple.passMailKp;
								text2 = D5ABA580(D812CF8A, string_10, 0, text, "");
								if (text2 == "fail")
								{
									gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
									break;
								}
								EB2B3FB0(text4);
								method_22(text4, D812CF8A);
								F8091028(1.0);
							}
							method_18("#iNext");
						}
					}
					else
					{
						if (!(text6 == "#iOttText,#otc-confirmation-input,[name=\"otc\"]"))
						{
							goto IL_0667;
						}
						num6++;
						text3 = D5ABA580(D812CF8A, string_10, 10, text, text2);
						switch (text3)
						{
						case "":
							break;
						default:
							goto IL_07fa;
						case "too_many_requests":
							goto IL_0acb;
						case "fail":
							goto IL_0ade;
						}
						if (num6 >= num7)
						{
							gClass.method_4("error", "Không lấy được otp");
							break;
						}
					}
					goto IL_086e;
				}
				if (num8 != 3797872910u)
				{
					if (num8 != 3815666825u)
					{
						if (num8 == 3858357123u && text6 == "#idDiv_SAOTCS_Proofs,[aria-labelledby^=\"errorText \"][data-testid=\"tileList\"]")
						{
							goto IL_0394;
						}
					}
					else if (text6 == "[name=\"passwd\"]")
					{
						if (flag)
						{
							break;
						}
						text7 = method_14("return document.querySelector('#passwordError').innerText");
						if (!(text7 != ""))
						{
							if (!(method_5(text4) != ""))
							{
								method_22(text4, F62ADAA0);
								F8091028(1.0);
								method_18(method_15(0.0, new List<string> { "#idSIButton9", "[data-testid=\"passwordEntryForm\"] button[type=\"submit\"]" }));
							}
							goto IL_086e;
						}
						gClass.method_4("error", "Sai passmail");
						break;
					}
				}
				else if (text6 == "#O365_MainLink_Me")
				{
					if (flag)
					{
						break;
					}
					method_12(string_11);
					goto IL_086e;
				}
			}
			goto IL_0667;
			IL_0a4f:
			gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
			break;
			IL_0a39:
			gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
			break;
			IL_07fa:
			text2 = text3;
			if (method_27(text4))
			{
				EB2B3FB0(text4);
				method_22(text4, text3);
				F8091028(1.0);
				method_18("#iNext,[name=\"otc-confirmation\"] button[type=\"submit\"],[name=\"OneTimeCodeViewForm\"] button[type=\"submit\"],#idSubmit_SAOTCC_Continue");
			}
			else
			{
				text4 = method_15(0.0, new List<string> { "[data-testid=\"codeEntryField\"] input" });
				EB2B3FB0(text4);
				method_22(text4, text3);
			}
			goto IL_086e;
			IL_02a6:
			text7 = method_14("return document.querySelector('#id_SAOTCS_Error_ProofConfirmation,#proof-confirmationError').innerText");
			if (!(text7 != ""))
			{
				text2 = D5ABA580(D812CF8A, string_10, 0, text, "");
				if (!(text2 == "fail"))
				{
					EB2B3FB0(text4);
					method_22(text4, D812CF8A.Split('*')[0]);
					F8091028(1.0);
					method_18(method_15(0.0, new List<string> { "#idSubmit_SAOTCS_SendCode,[name=\"proof-confirmation\"] button[type=\"submit\"]", "button[type=\"submit\"]" }));
					goto IL_086e;
				}
				gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
				break;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			break;
			IL_0667:
			if (D7A424AE("#iNext") && method_27("#iNext"))
			{
				method_17("#iNext");
			}
			else
			{
				string text9 = GetURL();
				if (text9.StartsWith("https://privacynotice.account.microsoft.com/notice"))
				{
					method_18("button");
				}
				else
				{
					string text10 = AFACE5B4();
					if (text9.StartsWith("https://account.microsoft.com/auth/complete-client-signin-oauth-silent?state=") || text9.StartsWith("https://account.live.com/error.aspx?errcode=") || text9.Contains("chrome-error://chromewebdata/") || text10.Contains("Ref A:") || text10.Contains("Service Unavailable") || text10.Contains("ERR_HTTP2_PROTOCOL_ERROR") || text10.Contains("HTTP ERROR 503") || text10.Contains("ERR_TOO_MANY_RETRIES"))
					{
						num4++;
						if (num4 >= 5)
						{
							num4 = 0;
							method_12(string_11);
						}
					}
					else if (D7A424AE(".refreshPageButton"))
					{
						method_14("refreshPage();");
					}
					else
					{
						if (num4 >= num5)
						{
							break;
						}
						num4++;
					}
				}
			}
			goto IL_086e;
			IL_0ade:
			gClass.method_4("error", "Không kê\u0301t nô\u0301i đươ\u0323c mail kp");
			break;
			IL_086e:
			if (!CD930D04() && !E184CD03())
			{
				if (Environment.TickCount - tickCount < num2 * 1000)
				{
					F8091028(1.0);
					continue;
				}
				gClass.method_4("error", "timeout");
				break;
			}
			gClass.method_4("error", "chrome_closed");
			break;
			IL_0acb:
			gClass.method_4("error", "Getnada block ip, vui lo\u0300ng đô\u0309i ip kha\u0301c");
			break;
			IL_0394:
			if (!(D812CF8A == ""))
			{
				if (method_30("[role=\"listitem\"]") > 1)
				{
					text4 = "//*[@role='listitem'][.//*[contains(text(),'" + D812CF8A.Split('@')[1] + "')]]";
					if (!D7A424AE(text4))
					{
						gClass.method_4("error", "Xác minh mail khôi phục cũ");
						break;
					}
					method_18(text4);
				}
				else
				{
					method_18(text4);
				}
				goto IL_086e;
			}
			gClass.method_4("error", "Xác minh mail khôi phục cũ");
			if (method_6(text4).Contains("+"))
			{
				gClass.method_4("error", "Xác minh phone cũ");
			}
			break;
			IL_056f:
			text2 = text3;
			EB2B3FB0(text4);
			method_22(text4, text3);
			F8091028(1.0);
			method_18("#idSubmit_SAOTCC_Continue");
			goto IL_086e;
		}
		if (flag)
		{
			gClass.method_4("success", true);
		}
		if (!gClass.method_3("success") && gClass.BDB80B23("error") == "")
		{
			gClass.method_4("error", "Đổi pass thất bại");
		}
		gClass.method_4("mailRecover", D812CF8A);
		gClass.method_4("passMailRecover", string_10);
		return gClass.ED11179C();
	}

	public string method_95()
	{
		return method_66("UnlockProfile");
	}

	public string method_96()
	{
		return method_66("LockProfile");
	}

	public bool method_97(bool bool_9)
	{
		string string_ = $"[{{\"name\":\"isEnable\", \"value\":\"{bool_9}\", \"type\":\"bool\"}}]";
		string json = method_66("ProfessionalMode", string_);
		JObject jObject = JObject.Parse(json);
		return Convert.ToBoolean(jObject["success"]);
	}

	public void DC0DE395(string string_10, string string_11, string B48A8CBD)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "1", "January" },
			{ "2", "February" },
			{ "3", "March" },
			{ "4", "April" },
			{ "5", "May" },
			{ "6", "June" },
			{ "7", "July" },
			{ "8", "August" },
			{ "9", "September" },
			{ "10", "October" },
			{ "11", "November" },
			{ "12", "December" }
		};
		string_10 = string_10.Trim();
		string_11 = dictionary[string_11.Trim()];
		B48A8CBD = B48A8CBD.Trim();
		method_12("https://accountscenter.facebook.com/personal_info/birthday/?entrypoint=edit_basic_info&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text = method_15(0.0, new List<string> { "//*[@role=\"dialog\"]//*[text()=\"Your birthday was updated\"]", "//*[@role=\"dialog\"][.//*[text()=\"Birthday\"]]//*[@role=\"button\"][.//*[text()=\"Edit\"]]" });
			string text2 = text;
			string text3 = text2;
			if (!(text3 == "//*[@role=\"dialog\"]//*[text()=\"Your birthday was updated\"]"))
			{
				if (text3 == "//*[@role=\"dialog\"][.//*[text()=\"Birthday\"]]//*[@role=\"button\"][.//*[text()=\"Edit\"]]")
				{
					if (D7A424AE("//*[@role=\"combobox\"][.//*[text()=\"Month\"]]"))
					{
						if (D7A424AE("//*[@role=\"dialog\"]//*[@role=\"button\"][.//*[text()=\"Confirm\"]]"))
						{
							method_18("//*[@role=\"dialog\"]//*[@role=\"button\"][.//*[text()=\"Confirm\"]]");
							F8091028(2.0);
							method_33("//*[@role=\"dialog\"]//*[@role=\"button\"][.//*[text()=\"Confirm\"]]", 60);
							break;
						}
						method_18("//*[@role=\"combobox\"][.//*[text()=\"Month\"]]");
						F8091028(2.0);
						method_19("//*[@aria-label=\"Select Month\" and @role=\"listbox\"]//*[@role=\"option\"][.//*[text()=\"" + string_11 + "\"]]");
						F8091028(1.0);
						method_18("//*[@role=\"combobox\"][.//*[text()=\"Day\"]]");
						F8091028(2.0);
						method_19("//*[@aria-label=\"Select Day\" and @role=\"listbox\"]//*[@role=\"option\"][.//*[text()=\"" + string_10 + "\"]]");
						F8091028(1.0);
						method_18("//*[@role=\"combobox\"][.//*[text()=\"Year\"]]");
						F8091028(2.0);
						method_19("//*[@aria-label=\"Select Year\" and @role=\"listbox\"]//*[@role=\"option\"][.//*[text()=\"" + B48A8CBD + "\"]]");
						F8091028(1.0);
						method_19("//*[@role=\"button\"][.//*[text()=\"Save\"]]");
						F8091028(2.0);
					}
					else
					{
						if (D7A424AE("//*[@role=\"dialog\"]//*[contains(text(),\"limit to how many times you can change your birthday\")]"))
						{
							break;
						}
						method_18(text);
					}
				}
			}
			else
			{
				method_18("//*[@role=\"dialog\"][.//*[text()=\"Your birthday was updated\"]]//*[@aria-label=\"Close\"]");
			}
			F8091028(2.0);
		}
	}

	public GClass4 method_98(string string_10)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		method_12("https://accountscenter.facebook.com/profiles/" + FB94939A() + "/username/?entrypoint=fb_account_center&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (true)
		{
			if (!CD930D04() && !E184CD03())
			{
				if (Environment.TickCount - tickCount < num * 1000)
				{
					string text = method_15(0.0, new List<string> { "//input[./following-sibling::*[text()=\"Username\"]]" });
					string text2 = text;
					string text3 = text2;
					if (text3 == "//input[./following-sibling::*[text()=\"Username\"]]")
					{
						if (D7A424AE("//*[contains(text(),\"currently unable to choose a username\")]"))
						{
							gClass.method_4("error", "Không thể đổi nickname");
							return gClass;
						}
						if (method_5(text) == string_10)
						{
							if (D7A424AE("//*[contains(text(),\"is not available\") or contains(text(),\"be at least 5 characters\")]"))
							{
								gClass.method_4("error", "Nickname không hợp lệ");
								return gClass;
							}
							if (D7A424AE("//*[@role=\"button\" and @aria-disabled=\"true\"]//*[text()=\"Done\"]"))
							{
								goto IL_015d;
							}
							method_62();
							method_19("//*[@role=\"button\"]//*[text()=\"Done\"]");
							F8091028(2.0);
							if (method_64(() => method_63(0) || D7A424AE("//*[text()=\"Leave page?\"]"), 60))
							{
								break;
							}
						}
						EEB5149C(text);
						method_22(text, string_10);
					}
					goto IL_015d;
				}
				gClass.method_4("error", "timeout");
			}
			else
			{
				gClass.method_4("error", "chrome_closed");
			}
			return gClass;
			IL_015d:
			F8091028(2.0);
		}
		gClass.method_4("success", true);
		return gClass;
	}

	public string DA8E1336()
	{
		return method_66("XoaThietBiTinCay");
	}

	public string F91F5893()
	{
		try
		{
			string text = method_41();
			string text2 = "";
			string text3 = FB94939A();
			string string_ = "https://www.facebook.com/api/graphql/";
			string string_2 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + text + "&jazoest=22037&lsd=" + text2 + "&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%222%22%2C%22actor_id%22%3A%22" + text3 + "%22%2C%22entry_point%22%3A%22SETTINGS%22%2C%22node_id%22%3A%22PUBLIC_POSTS_FOLLOWERS%22%2C%22update_value%22%3A0%2C%22update_value_string%22%3A%220%22%7D%7D&server_timestamps=true&doc_id=9096161553759589";
			string json = method_48(string_, string_2);
			return JObject.Parse(json)["data"]!["xfb_update_usf_general_selector"]!["setting_value_text"]!.ToString();
		}
		catch (Exception)
		{
		}
		return "";
	}

	public string method_99(string string_10, string string_11)
	{
		string string_12 = "[{\"name\":\"password\", \"value\":\"" + string_10 + "\", \"type\":\"text\"},{\"name\":\"email\", \"value\":\"" + string_11 + "\", \"type\":\"text\"}]";
		return method_66("RemoveEmailMfb", string_12);
	}

	public string method_100(string string_10, int C984E38F)
	{
		string string_11 = $"[{{\"name\":\"password\", \"value\":\"{string_10}\", \"type\":\"text\"}},{{\"name\":\"typeWeb\", \"value\":\"{C984E38F}\", \"type\":\"number\"}}]";
		return method_66("RemovePhone", string_11);
	}

	public bool D6BBEDA3()
	{
		if (EE37E6A7)
		{
			return true;
		}
		if (GetURL().Contains("1501092823525282"))
		{
			return false;
		}
		bool result;
		if (result = method_66("CheckFbBlock") == "true")
		{
			EE37E6A7 = true;
		}
		return result;
	}

	internal string method_101(string string_10)
	{
		if (!Commom.smethod_45(string_10))
		{
			string_10 = Commom.smethod_87(string_10);
		}
		if (Commom.smethod_45(string_10))
		{
			string string_11 = "[{\"name\":\"id\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
			return method_66("CrawlPostWWW", string_11);
		}
		string string_12 = "[{\"name\":\"id\", \"value\":\"" + string_10 + "\", \"type\":\"text\"},{\"name\":\"fa2\", \"value\":\"" + A1BF36A2 + "\", \"type\":\"text\"}]";
		return method_66("CrawlPost", string_12);
	}

	internal bool method_102(int int_4, GClass4 A400502B, int int_5 = -1)
	{
		string text = A400502B.BDB80B23("reaction");
		bool flag = A400502B.method_3("postAds");
		string string_ = "[{\"name\":\"reaction\", \"value\":\"" + text + "\", \"type\":\"text\"}" + $",{{\"name\":\"indexPost\", \"value\":\"{int_5}\", \"type\":\"number\"}}" + $",{{\"name\":\"postAds\", \"value\":\"{flag}\", \"type\":\"bool\"}}]";
		string e93E6CA = "";
		switch (int_4)
		{
		case 1:
			e93E6CA = "ReactionWWW";
			break;
		case 2:
			e93E6CA = "ReactionMfb";
			break;
		case 3:
			e93E6CA = "ReactionMbasic";
			break;
		}
		string json = method_66(e93E6CA, string_);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool A42C8002(string string_10)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		if (!D7A424AE("[aria-label=\"Go to News Feed\" i]"))
		{
			int tickCount = Environment.TickCount;
			int num = 60;
			while (!E184CD03() && !CD930D04() && Environment.TickCount - tickCount <= num * 1000)
			{
				string text = method_15(0.0, new List<string> { "[aria-label=\"Yes\" i]" });
				string text2 = text;
				string text3 = text2;
				if (text3 == "[aria-label=\"Yes\" i]")
				{
					if (D7A424AE("[aria-label=\"Select audience\"][role=\"dialog\"]"))
					{
						method_19("//*[@aria-label=\"Select audience\"]//*[@data-visualcompletion=\"ignore-dynamic\"]//*[@role=\"radio\"]//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'public']");
						F8091028(2.0);
						method_18("[aria-label=\"Select audience\"][role=\"dialog\"] [aria-label=\"Done\"]");
					}
					else if (D7A424AE("[aria-label*=\"Recommend\"][role=\"dialog\"]") && method_6("[aria-label*=\"Recommend\"][role=\"dialog\"] [aria-label*=\"Edit privacy\" i]") != "Public")
					{
						method_18("[aria-label*=\"Recommend\"][role=\"dialog\"] [aria-label*=\"Edit privacy\" i]");
					}
					else if (D7A424AE("[role=\"dialog\"] [role=\"textbox\"]"))
					{
						if (D7A424AE("[aria-label=\"Select audience\"][role=\"dialog\"]"))
						{
							method_19("//*[@aria-label=\"Select audience\"]//*[@data-visualcompletion=\"ignore-dynamic\"]//*[@role=\"radio\"]//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'public']");
							F8091028(2.0);
							method_18("[aria-label=\"Select audience\"][role=\"dialog\"] [aria-label=\"Done\"]");
						}
						else
						{
							if (!D7A424AE("[aria-label*=\"Recommend\"][role=\"dialog\"]") || !(method_6("[aria-label*=\"Recommend\"][role=\"dialog\"] [aria-label*=\"Edit privacy\" i]") != "Public"))
							{
								AE3408BC("[role=\"dialog\"] [role=\"textbox\"]", string_10);
								F8091028(1.0);
								method_18("[role=\"dialog\"] [aria-label=\"Post\" i]");
								if (method_33("[role=\"dialog\"] [aria-label=\"Post\" i]", 30))
								{
									gClass.method_4("success", true);
								}
								break;
							}
							method_18("[aria-label*=\"Recommend\"][role=\"dialog\"] [aria-label*=\"Edit privacy\" i]");
						}
					}
					else
					{
						method_18(text);
					}
				}
				F8091028(2.0);
			}
		}
		return gClass.method_3("success");
	}

	internal string method_103(bool F322969C, List<string> DC12169C)
	{
		string string_ = $"[{{\"name\":\"isAnswer\", \"value\":\"{F322969C}\", \"type\":\"bool\"}}" + ",{\"name\":\"answer\", \"value\":\"" + string.Join("\\\\n", DC12169C).Replace("\"", "\\\"") + "\", \"type\":\"text\"}]";
		int num = method_61();
		string json = "";
		switch (num)
		{
		case 1:
			json = method_66("JoinGroupWWW", string_);
			break;
		case 3:
			json = method_66("JoinGroupMbasic", string_);
			break;
		}
		JObject jObject = JObject.Parse(json);
		if (!Convert.ToBoolean(jObject["success"]))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
			return jObject["error"]!.ToString();
		}
		return "success";
	}

	internal string method_104(int int_4, int int_5, int F227E63F, int int_6, bool ED09002D, List<string> list_0)
	{
		string string_ = $"[{{\"name\":\"nudSoLuongFrom\", \"value\":\"{int_4}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudSoLuongTo\", \"value\":\"{int_5}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudDelayFrom\", \"value\":\"{F227E63F}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudDelayTo\", \"value\":\"{int_6}\", \"type\":\"number\"}}" + $",{{\"name\":\"ckbTuDongTraLoiCauHoi\", \"value\":\"{ED09002D}\", \"type\":\"bool\"}}" + ",{\"name\":\"lstCauTraLoi\", \"value\":\"" + string.Join("\\\\n", list_0).Replace("\"", "\\\"") + "\", \"type\":\"text\"}]";
		string json = method_66("JoinGroupDeXuatWWW", string_);
		JObject jObject = JObject.Parse(json);
		if (!Convert.ToBoolean(jObject["success"]))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
			return jObject["error"]!.ToString();
		}
		return "success";
	}

	internal bool D727CD89(string F210731D)
	{
		string string_ = "[{\"name\":\"name\", \"value\":\"" + F210731D + "\", \"type\":\"text\"}]";
		string json = method_66("Rename", string_);
		JObject jObject = JObject.Parse(json);
		return Convert.ToBoolean(jObject["success"]);
	}

	internal bool method_105(string BE27DCA7, string C510ABB7)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(BE27DCA7))
			{
				return false;
			}
			string fullUrl = BE27DCA7.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || BE27DCA7.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
				? BE27DCA7
				: ("https://www.facebook.com/" + BE27DCA7.TrimStart('/'));
			C510ABB7 = Commom.smethod_31(C510ABB7 ?? "");
			string paramJson = new JObject
			{
				["url"] = fullUrl,
				["content"] = C510ABB7
			}.ToString(Newtonsoft.Json.Formatting.None);

			string res = FacebookActionsHub.Execute(this, "comment", paramJson);
			if (!string.IsNullOrEmpty(res))
			{
				try
				{
					JObject jObj = JObject.Parse(res);
					if (jObj["success"]?.Value<bool>() == true)
					{
						return true;
					}
				}
				catch
				{
					if (res.Contains("\"success\":true") || res.Contains("\"success\": true"))
					{
						return true;
					}
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	internal bool C11B5C31(string DAAA0B14, string string_10)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(DAAA0B14))
			{
				return false;
			}
			string fullUrl = DAAA0B14.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || DAAA0B14.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
				? DAAA0B14
				: ("https://www.facebook.com/" + DAAA0B14.TrimStart('/'));
			string_10 = Commom.smethod_31(string_10 ?? "");
			string paramJson = new JObject
			{
				["url"] = fullUrl,
				["content"] = string_10
			}.ToString(Newtonsoft.Json.Formatting.None);

			string res = FacebookActionsHub.Execute(this, "sharewall", paramJson);
			if (!string.IsNullOrEmpty(res))
			{
				try
				{
					JObject jObj = JObject.Parse(res);
					if (jObj["success"]?.Value<bool>() == true)
					{
						return true;
					}
				}
				catch
				{
					if (res.Contains("\"success\":true") || res.Contains("\"success\": true"))
					{
						return true;
					}
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	internal bool DD052422(int int_4, GClass4 gclass4_0, int A0A52B9B = -1)
	{
		string text = gclass4_0.BDB80B23("content").Replace("\r\n", "\n").Replace("\n", "\\\\n")
			.Replace("\"", "\\\"");
		string text2 = gclass4_0.BDB80B23("image").Replace("\\", "\\\\\\\\");
		bool flag = gclass4_0.method_3("ckbDeleteComment");
		int num = gclass4_0.method_2("nudDelayDeleteFrom");
		int num2 = gclass4_0.method_2("nudDelayDeleteTo");
		bool flag2 = gclass4_0.method_3("ckbEditComment");
		int num3 = gclass4_0.method_2("nudDelayEditFrom");
		int num4 = gclass4_0.method_2("nudDelayEditTo");
		string text3 = gclass4_0.BDB80B23("contentEdit").Replace("\r\n", "\n").Replace("\n", "\\\\n")
			.Replace("\"", "\\\"");
		bool flag3 = gclass4_0.method_3("postAds");
		if (text == "" && text2 == "")
		{
			return false;
		}
		string string_ = "[{\"name\":\"content\", \"value\":\"" + text + "\", \"type\":\"text\"},{\"name\":\"image\", \"value\":\"" + text2 + "\", \"type\":\"text\"}" + $",{{\"name\":\"ckbDeleteComment\", \"value\":\"{flag}\", \"type\":\"bool\"}}" + $",{{\"name\":\"nudDelayDeleteFrom\", \"value\":\"{num}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudDelayDeleteTo\", \"value\":\"{num2}\", \"type\":\"number\"}}" + $",{{\"name\":\"ckbEditComment\", \"value\":\"{flag2}\", \"type\":\"bool\"}}" + $",{{\"name\":\"nudDelayEditFrom\", \"value\":\"{num3}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudDelayEditTo\", \"value\":\"{num4}\", \"type\":\"number\"}}" + ",{\"name\":\"contentEdit\", \"value\":\"" + text3 + "\", \"type\":\"text\"}" + $",{{\"name\":\"indexPost\", \"value\":\"{A0A52B9B}\", \"type\":\"number\"}}" + $",{{\"name\":\"postAds\", \"value\":\"{flag3}\", \"type\":\"bool\"}}]";
		string e93E6CA = "";
		switch (int_4)
		{
		case 1:
			e93E6CA = "CommentWWW";
			break;
		case 2:
			e93E6CA = "CommentMfb";
			break;
		case 3:
			e93E6CA = "CommentMbasic";
			break;
		}
		string json = method_66(e93E6CA, string_);
		JObject jobject_0 = JObject.Parse(json);
		bool result;
		if ((result = Convert.ToBoolean(jobject_0["success"])) && jobject_0["commentId"]!.ToString() != "" && !flag)
		{
			string string_0 = Commom.smethod_95() + "\\output\\comment_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
			Commom.smethod_98(string_0, delegate
			{
				File.AppendAllText(string_0, B4208531 + "|https://fb.com/" + jobject_0["commentId"]?.ToString() + Environment.NewLine);
			});
		}
		else
		{
			EE37E6A7 = jobject_0["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool AF0F44B1(int D5B7FB25, GClass4 F8AD3DB6, int DDA165B4 = -1)
	{
		bool flag = F8AD3DB6.method_3("postAds");
		string text = F8AD3DB6.BDB80B23("content").Replace("\r\n", "\n").Replace("\n", "\\\\n")
			.Replace("\"", "\\\"");
		string string_ = "[{\"name\":\"content\", \"value\":\"" + text + "\", \"type\":\"text\"}" + $",{{\"name\":\"indexPost\", \"value\":\"{DDA165B4}\", \"type\":\"number\"}}" + $",{{\"name\":\"postAds\", \"value\":\"{flag}\", \"type\":\"bool\"}}]";
		string e93E6CA = "";
		switch (D5B7FB25)
		{
		case 1:
			e93E6CA = "ShareWallWWW";
			break;
		case 2:
			e93E6CA = "ShareWallMfb";
			break;
		case 3:
			e93E6CA = "ShareWallMbasic";
			break;
		}
		string json = method_66(e93E6CA, string_);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool E40A833A(int int_4, GClass4 F03AB9B8, int A22A2F04 = -1)
	{
		int num = F03AB9B8.method_2("soLuongFrom");
		int num2 = F03AB9B8.method_2("soLuongTo");
		int num3 = F03AB9B8.method_2("delayFrom");
		int num4 = F03AB9B8.method_2("delayTo");
		string text = F03AB9B8.BDB80B23("content").Replace("\r\n", "\n").Replace("\n", "\\\\n")
			.Replace("\"", "\\\"");
		string string_ = "[{\"name\":\"content\", \"value\":\"" + text + "\", \"type\":\"text\"}" + $",{{\"name\":\"soLuongFrom\", \"value\":\"{num}\", \"type\":\"number\"}}" + $",{{\"name\":\"soLuongTo\", \"value\":\"{num2}\", \"type\":\"number\"}}" + $",{{\"name\":\"delayFrom\", \"value\":\"{num3}\", \"type\":\"number\"}}" + $",{{\"name\":\"delayTo\", \"value\":\"{num4}\", \"type\":\"number\"}}" + $",{{\"name\":\"indexPost\", \"value\":\"{A22A2F04}\", \"type\":\"number\"}}]";
		string e93E6CA = "";
		switch (int_4)
		{
		case 1:
			e93E6CA = "ShareMessWWW";
			break;
		case 2:
			e93E6CA = "ShareMessMfb";
			break;
		case 3:
			e93E6CA = "ShareMessMbasic";
			break;
		}
		string json = method_66(e93E6CA, string_);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	private static readonly object _clipboardLock = new object();

	public bool EnterPostContentWWW(string content)
	{
		if (string.IsNullOrEmpty(content))
		{
			return true;
		}

		if (ChromeDriver_0 == null || CD930D04() || E184CD03())
		{
			return false;
		}

		// 1. Unicode Normalization (NFC) & Linebreak Canonicalization
		// Preserves Vietnamese diacritics (composed NFC), 4-byte UTF-16 surrogate emojis, hashtags, and newlines
		string normalized = content.Normalize(System.Text.NormalizationForm.FormC)
			.Replace("\u000d\u000a", "\n")
			.Replace("\u000d", "\n")
			.Trim();

		if (normalized.Length == 0)
		{
			return true;
		}

		// Extract representative head token for verification
		string headToken = normalized;
		int firstNl = normalized.IndexOf('\n');
		if (firstNl > 0)
		{
			headToken = normalized.Substring(0, firstNl).Trim();
		}
		if (headToken.Length > 20)
		{
			headToken = headToken.Substring(0, 20).Trim();
		}
		if (headToken.Length > 0 && char.IsHighSurrogate(headToken[headToken.Length - 1]))
		{
			headToken = headToken.Substring(0, headToken.Length - 1).Trim();
		}

		// 2. Discover Composer Textbox (Adaptive polling up to 3.5s)
		IWebElement boxElement = null;
		for (int waitAttempt = 0; waitAttempt < 18; waitAttempt++)
		{
			try
			{
				var candidates = ChromeDriver_0.FindElements(By.CssSelector(
					@"div[role=""dialog""] [role=""textbox""][contenteditable=""true""], " +
					@"div[role=""dialog""] [data-lexical-editor=""true""][contenteditable=""true""], " +
					@"div[role=""dialog""] div[contenteditable=""true""], " +
					@"div[role=""dialog""] [role=""textbox""]"
				));

				if (candidates.Count > 0 && candidates[0].Displayed)
				{
					boxElement = candidates[0];
					break;
				}

				// Fallback to document-level feed composer if no dialog
				var docCandidates = ChromeDriver_0.FindElements(By.CssSelector(
					@"[role=""main""] [role=""textbox""][contenteditable=""true""], " +
					@"[data-lexical-editor=""true""][contenteditable=""true""]"
				));
				if (docCandidates.Count > 0 && docCandidates[0].Displayed)
				{
					boxElement = docCandidates[0];
					break;
				}
			}
			catch { }

			Thread.Sleep(200);
		}

		if (boxElement == null)
		{
			Commom.smethod_49("EnterPostContentWWW: Không tìm thấy ô soạn thảo (dialog/textbox not found)");
			return false;
		}

		// 3. Clear Existing Content if box already has text (Prevents text accumulation/duplication)
		try
		{
			boxElement.Click();
			F8091028(0.1);

			object hasExistingText = ChromeDriver_0.ExecuteScript(@"
				var box = arguments[0];
				if (!box) return false;
				var t = (box.innerText || box.textContent || '').trim();
				return t.length > 0;
			", boxElement);

			if (hasExistingText != null && Convert.ToBoolean(hasExistingText))
			{
				try
				{
					boxElement.SendKeys(OpenQA.Selenium.Keys.Control + "a");
					F8091028(0.05);
					boxElement.SendKeys(OpenQA.Selenium.Keys.Backspace);
					F8091028(0.05);
				}
				catch { }

				ChromeDriver_0.ExecuteScript(@"
					var box = arguments[0];
					if (box) {
						box.focus();
						try {
							var sel = window.getSelection();
							if (sel) {
								var r = document.createRange();
								r.selectNodeContents(box);
								sel.removeAllRanges();
								sel.addRange(r);
							}
							document.execCommand('delete', false, null);
						} catch(e) {}
					}
				", boxElement);
				F8091028(0.05);
			}
		}
		catch (Exception ex)
		{
			Commom.smethod_49("EnterPostContentWWW clear warning: " + ex.Message);
		}

		// 4. METHOD 1 (PRIMARY): Dán nội dung 1 lần dứt khoát qua STA Clipboard (Ctrl+V) <0.5s
		// Natively handled by Meta Lexical's trusted paste handler, preserving emojis, Vietnamese diacritics, and newlines.
		bool filledSuccessfully = false;
		try
		{
			bool setClipOk = false;
			lock (_clipboardLock)
			{
				for (int r = 0; r < 5; r++)
				{
					try
					{
						if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
						{
							Clipboard.Clear();
							Clipboard.SetDataObject(normalized, true, 5, 100);
							setClipOk = true;
							break;
						}
						else
						{
							Thread staThread = new Thread(() =>
							{
								try
								{
									Clipboard.Clear();
									Clipboard.SetDataObject(normalized, true, 5, 100);
									setClipOk = true;
								}
								catch { }
							});
							staThread.SetApartmentState(ApartmentState.STA);
							staThread.IsBackground = true;
							staThread.Start();
							staThread.Join(1200);
							if (setClipOk) break;
						}
					}
					catch
					{
						Thread.Sleep(50);
					}
				}

				if (setClipOk)
				{
					try
					{
						boxElement.SendKeys(OpenQA.Selenium.Keys.Control + "v");
					}
					catch
					{
						new Actions(ChromeDriver_0)
							.MoveToElement(boxElement)
							.Click()
							.KeyDown(OpenQA.Selenium.Keys.Control)
							.SendKeys("v")
							.KeyUp(OpenQA.Selenium.Keys.Control)
							.Perform();
					}
					F8091028(0.25);
				}
			}

			// Verify immediately
			filledSuccessfully = VerifyContentInEditor(boxElement, headToken);
		}
		catch (Exception ex)
		{
			Commom.smethod_49("EnterPostContentWWW Clipboard Paste exception: " + ex.Message);
		}

		// 5. METHOD 2 (FALLBACK): In-Memory Synthetic Paste (CHỈ chạy khi ô soạn thảo HOÀN TOÀN TRỐNG)
		if (!filledSuccessfully)
		{
			try
			{
				object isBoxEmpty = ChromeDriver_0.ExecuteScript(@"
					var box = arguments[0];
					if (!box) return false;
					var t = (box.innerText || box.textContent || '').trim();
					return t.length === 0;
				", boxElement);

				if (isBoxEmpty != null && Convert.ToBoolean(isBoxEmpty))
				{
					ChromeDriver_0.ExecuteScript(@"
						var text = arguments[0];
						var box = arguments[1];
						if (!box) return;
						box.focus();

						try {
							var dt = new DataTransfer();
							dt.setData('text/plain', text);
							var pEvt = new ClipboardEvent('paste', { clipboardData: dt, bubbles: true, cancelable: true });
							box.dispatchEvent(pEvt);
						} catch(e) {}

						var t = (box.innerText || box.textContent || '').trim();
						if (t.length === 0) {
							try {
								document.execCommand('insertText', false, text);
							} catch(e) {
								box.innerText = text;
							}
						}

						box.dispatchEvent(new Event('input', { bubbles: true }));
						box.dispatchEvent(new Event('change', { bubbles: true }));
					", normalized, boxElement);

					F8091028(0.3);
					filledSuccessfully = VerifyContentInEditor(boxElement, headToken);
				}
			}
			catch (Exception ex)
			{
				Commom.smethod_49("EnterPostContentWWW Fallback exception: " + ex.Message);
			}
		}

		// 6. Dismiss Autocomplete / Hashtag / Mention Suggestion Popups (Press Escape)
		try
		{
			ChromeDriver_0.ExecuteScript(@"
				var listbox = document.querySelector('div[role=""listbox""], div[role=""menu""][aria-label*=""gợi ý"" i], div[role=""menu""][aria-label*=""suggestion"" i]');
				if (listbox) {
					var active = document.activeElement || document.body;
					active.dispatchEvent(new KeyboardEvent('keydown', { key: 'Escape', code: 'Escape', keyCode: 27, which: 27, bubbles: true, cancelable: true }));
					active.dispatchEvent(new KeyboardEvent('keyup', { key: 'Escape', code: 'Escape', keyCode: 27, which: 27, bubbles: true, cancelable: true }));
				}
			");
		}
		catch { }

		return filledSuccessfully;
	}

	private bool VerifyContentInEditor(IWebElement boxElement, string headToken)
	{
		try
		{
			object checkResult = ChromeDriver_0.ExecuteScript(@"
				var box = arguments[0] || document.querySelector('div[role=""dialog""] [role=""textbox""], div[role=""dialog""] div[contenteditable=""true""], [data-lexical-editor=""true""]');
				if (!box) return false;

				var actualText = (box.innerText || box.textContent || '').trim();
				if (actualText.length === 0) return false;

				var expectedHead = (arguments[1] || '').trim();
				if (expectedHead.length === 0) return true;

				var normActual = actualText.normalize('NFC').replace(/\s+/g, '');
				var normExpected = expectedHead.normalize('NFC').replace(/\s+/g, '');
				var prefix = normExpected.substring(0, Math.min(10, normExpected.length));

				return normActual.indexOf(prefix) !== -1;
			", boxElement, headToken);

			if (checkResult != null && checkResult is bool b)
			{
				return b;
			}
		}
		catch { }

		return false;
	}

	private void DismissComposerDialog()
	{
		try
		{
			if (ChromeDriver_0 == null || CD930D04()) return;

			ChromeDriver_0.ExecuteScript(@"
				var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
				if (!dialog) return;

				// Click close button if found, otherwise send Escape
				var closeBtn = dialog.querySelector('div[aria-label=""Đóng"" i], div[aria-label=""Close"" i], div[aria-label=""Hủy"" i], div[aria-label=""Cancel"" i], [aria-label*=""Đóng"" i]');
				if (closeBtn) {
					closeBtn.click();
				} else {
					var escEvt = new KeyboardEvent('keydown', { key: 'Escape', code: 'Escape', keyCode: 27, which: 27, bubbles: true });
					document.dispatchEvent(escEvt);
				}
			");
			Commom.smethod_52(1.0);

			// Handle 'Discard post?' / 'Bỏ bài viết?' confirmation dialog if it pops up
			ChromeDriver_0.ExecuteScript(@"
				var confirmDialogs = Array.from(document.querySelectorAll('div[role=""dialog""]'));
				for (var cd of confirmDialogs) {
					var btns = Array.from(cd.querySelectorAll('div[role=""button""], button'));
					for (var b of btns) {
						var t = (b.innerText || b.textContent || '').trim().toLowerCase();
						var a = (b.getAttribute('aria-label') || '').trim().toLowerCase();
						if (t === 'bỏ' || a === 'bỏ' || t === 'discard' || a === 'discard') {
							b.click();
							break;
						}
					}
				}
			");
		}
		catch { }
	}

	public string ExecuteDangBaiWWW(int typeObject, string link, string content, bool isUseBackground = false, List<string> images = null)
	{
		if (ChromeDriver_0 == null || CD930D04() || E184CD03())
		{
			return "";
		}

		try
		{
			DismissFacebookPopups();

			// 1. Chuyển hướng đến đối tượng cần đăng (Tường, Nhóm, hoặc Page)
			string cleanGroupIdTarget = "";
			string cleanPageIdTarget = "";

			if (typeObject == 1 && !string.IsNullOrEmpty(link)) // 1. Đăng nhóm
			{
				string groupUrl = link.Trim();
				if (!groupUrl.StartsWith("http://") && !groupUrl.StartsWith("https://"))
				{
					groupUrl = "https://www.facebook.com/groups/" + groupUrl.Trim('/');
				}
				cleanGroupIdTarget = Regex.Match(groupUrl, @"groups/([^/?#]+)").Groups[1].Value;
				if (string.IsNullOrEmpty(cleanGroupIdTarget))
				{
					cleanGroupIdTarget = groupUrl.Trim('/').Split('/').Last();
				}
				if (!GetURL().Contains(cleanGroupIdTarget))
				{
					method_12(groupUrl, FC3A841F: true);
					F8091028(3.0);
				}
			}
			else if (typeObject == 2 && !string.IsNullOrEmpty(link)) // 2. Đăng Page (Fanpage)
			{
				string pageUrl = link.Trim();
				if (!pageUrl.StartsWith("http://") && !pageUrl.StartsWith("https://"))
				{
					pageUrl = "https://www.facebook.com/" + pageUrl.Trim('/');
				}
				cleanPageIdTarget = Regex.Match(pageUrl, @"facebook\.com/([^/?#]+)").Groups[1].Value;
				if (string.IsNullOrEmpty(cleanPageIdTarget))
				{
					cleanPageIdTarget = pageUrl.Split('?')[0].Split('#')[0].Trim('/').Split('/').Last();
				}
				if (!GetURL().Contains(cleanPageIdTarget))
				{
					method_12(pageUrl, FC3A841F: true);
					F8091028(3.0);
				}

				// Xử lý chuyển đổi Profile sang Page ("Chuyển ngay" / "Switch now") nếu cần
				try
				{
					ChromeDriver_0.ExecuteScript(@"
						var switchBtns = Array.from(document.querySelectorAll('div[role=""button""], button'));
						for (var b of switchBtns) {
							var t = (b.innerText || b.textContent || '').trim().toLowerCase();
							var a = (b.getAttribute('aria-label') || '').trim().toLowerCase();
							if (t.includes('chuyển ngay') || a.includes('chuyển ngay') ||
								t.includes('switch now') || a.includes('switch now')) {
								b.click();
								break;
							}
						}
					");
					Commom.smethod_52(1.5);
				}
				catch { }
			}
			else // 0. Đăng Tường (Profile Feed / Wall)
			{
				string currentUrl = GetURL();
				if (!string.IsNullOrEmpty(link) && (link.Contains("/me") || link.Contains("profile.php") || link.Contains("facebook.com/")))
				{
					string wallUrl = link.Trim();
					if (!wallUrl.StartsWith("http")) wallUrl = "https://www.facebook.com/" + wallUrl.Trim('/');
					if (!currentUrl.Contains(wallUrl))
					{
						method_12(wallUrl, FC3A841F: true);
						F8091028(3.0);
					}
				}
				else if (!currentUrl.Contains("facebook.com") || currentUrl.Contains("/groups/") || currentUrl.Contains("/pages/") || currentUrl.Contains("/watch"))
				{
					method_12("https://www.facebook.com/", FC3A841F: true);
					F8091028(3.0);
				}
			}

			DismissFacebookPopups();

			// Phân loại danh sách tệp đính kèm
			if (images != null && images.Count > 0)
			{
				var nonExistent = images.Where(f => !File.Exists(f)).ToList();
				if (nonExistent.Count == images.Count)
				{
					Commom.smethod_49("ExecuteDangBaiWWW: Toàn bộ tệp media chỉ định không tồn tại trên ổ đĩa. Hủy đăng bài để tránh chỉ đăng văn bản!");
					return "";
				}
			}

			List<string> validMedia = (images != null) ? images.Where(File.Exists).ToList() : new List<string>();
			bool hasMedia = validMedia.Count > 0;
			bool hasVideo = validMedia.Any(f =>
			{
				string ext = Path.GetExtension(f).ToLowerInvariant();
				return ext == ".mp4" || ext == ".mov" || ext == ".avi" || ext == ".mkv" || ext == ".webm" || ext == ".3gp" || ext == ".wmv" || ext == ".m4v";
			});

			// 2. Mở Hộp thoại Soạn thảo (Composer Dialog)
			bool composerOpened = false;

			// Kiểm tra nếu modal đã mở sẵn
			object initialDialogCheck = ChromeDriver_0.ExecuteScript(@"
				var existingBox = document.querySelector('div[role=""dialog""] [role=""textbox""], div[role=""dialog""] div[contenteditable=""true""]');
				if (existingBox) {
					var dlg = existingBox.closest('div[role=""dialog""]');
					if (dlg) dlg.setAttribute('data-lushcare-composer', 'active');
					return true;
				}
				return false;
			");
			if (initialDialogCheck != null && Convert.ToBoolean(initialDialogCheck))
			{
				composerOpened = true;
			}

			for (int loop = 0; loop < 4 && !composerOpened; loop++)
			{
				if (CD930D04() || E184CD03()) return "";
				DismissFacebookPopups();

				object openResult = ChromeDriver_0.ExecuteScript(@"
					function triggerClick(el) {
						if (!el) return;
						el.scrollIntoView({ behavior: 'auto', block: 'center' });
						['mouseover', 'mouseenter', 'pointerdown', 'mousedown', 'pointerup', 'mouseup', 'click'].forEach(function(evt) {
							try {
								var e = new MouseEvent(evt, { bubbles: true, cancelable: true, view: window, buttons: 1 });
								el.dispatchEvent(e);
							} catch(err) {}
						});
						try { el.click(); } catch(e) {}
					}

					var existing = document.querySelector('div[role=""dialog""] [role=""textbox""], div[role=""dialog""] div[contenteditable=""true""]');
					if (existing) {
						var d = existing.closest('div[role=""dialog""]');
						if (d) d.setAttribute('data-lushcare-composer', 'active');
						return 'already_open';
					}

					// Nếu có yêu cầu upload media, ưu tiên click nút 'Ảnh/video' trực tiếp trên composer inline để mở sẵn dropzone
					var wantsMedia = arguments[0];
					if (wantsMedia) {
						var photoButtons = Array.from(document.querySelectorAll('div[data-pagelet*=""Composer""] div[role=""button""], div[data-pagelet*=""FeedUnit""] div[role=""button""]'));
						for (var pb of photoButtons) {
							var pAria = (pb.getAttribute('aria-label') || '').toLowerCase();
							var pText = (pb.innerText || pb.textContent || '').toLowerCase();
							if (pAria.includes('ảnh/video') || pAria.includes('photo/video') ||
								pText.includes('ảnh/video') || pText.includes('photo/video')) {
								triggerClick(pb);
								return 'clicked_inline_photo_trigger';
							}
						}
					}

					// Tìm kiếm theo các Pagelet chuyên dụng theo Wall, Group, và Page
					var pageletSelectors = [
						'div[data-pagelet=""GroupInlineComposer""] div[role=""button""][tabindex=""0""]',
						'div[data-pagelet*=""GroupComposer""] div[role=""button""][tabindex=""0""]',
						'div[data-pagelet=""ProfileComposer""] div[role=""button""][tabindex=""0""]',
						'div[data-pagelet=""PageComposer""] div[role=""button""][tabindex=""0""]',
						'div[data-pagelet=""PageInlineComposer""] div[role=""button""][tabindex=""0""]',
						'div[data-pagelet*=""Composer""] div[role=""button""][tabindex=""0""]',
						'div[data-pagelet*=""FeedUnit""] div[role=""button""][tabindex=""0""]'
					];
					for (var pSel of pageletSelectors) {
						var pElem = document.querySelector(pSel);
						if (pElem) {
							triggerClick(pElem);
							return 'clicked_pagelet_button';
						}
					}

					// Tìm kiếm theo văn bản nhắc nhở bài viết (Bilingual VN/EN)
					var allElements = Array.from(document.querySelectorAll('span, div[role=""button""], div[tabindex=""0""]'));
					for (var el of allElements) {
						var t = (el.innerText || el.textContent || '').trim().toLowerCase();
						if (t.includes('bạn đang nghĩ gì') ||
							t.includes(""what's on your mind"") ||
							t.includes('tạo bài viết') ||
							t.includes('viết gì đó') ||
							t.includes('write something') ||
							t.includes('tạo bài viết công khai') ||
							t.includes('create a public post') ||
							t.includes('create a post') ||
							t.includes('bạn viết gì đi') ||
							t.includes('chia sẻ suy nghĩ') ||
							t.includes('share your thoughts') ||
							t.includes('viết bài viết') ||
							t.includes('write a post')) {
							var btn = el.closest('div[role=""button""]') || el;
							triggerClick(btn);
							return 'clicked_prompt_text';
						}
					}

					// Tìm kiếm theo thuộc tính aria-label
					var ariaSelectors = [
						'div[role=""button""][aria-label*=""Tạo bài viết"" i]',
						'div[role=""button""][aria-label*=""Create a post"" i]',
						'div[role=""button""][aria-label*=""Create post"" i]',
						'div[role=""button""][aria-label*=""Bạn đang nghĩ gì"" i]',
						'div[role=""button""][aria-label*=""What\'s on your mind"" i]',
						'div[role=""button""][aria-label*=""Viết gì đó"" i]',
						'div[role=""button""][aria-label*=""Write something"" i]'
					];
					for (var aSel of ariaSelectors) {
						var aElem = document.querySelector(aSel);
						if (aElem) {
							triggerClick(aElem);
							return 'clicked_aria_button';
						}
					}

					return 'not_found';
				", hasMedia);

				Commom.smethod_52(2.0);

				object hasDialog = ChromeDriver_0.ExecuteScript(@"
					var box = document.querySelector('div[role=""dialog""] [role=""textbox""], div[role=""dialog""] div[contenteditable=""true""]');
					if (box) {
						var d = box.closest('div[role=""dialog""]');
						if (d) d.setAttribute('data-lushcare-composer', 'active');
						return true;
					}
					return false;
				");
				if (hasDialog != null && Convert.ToBoolean(hasDialog))
				{
					composerOpened = true;
					break;
				}

				// Nếu chưa mở được, cuộn nhẹ 200px xuống để lộ composer nếu bị che bởi sticky header
				if (loop >= 1)
				{
					try { ChromeDriver_0.ExecuteScript("window.scrollBy({ top: 200, behavior: 'smooth' });"); } catch { }
					Commom.smethod_52(1.0);
				}
			}

			if (!composerOpened)
			{
				Commom.smethod_49("ExecuteDangBaiWWW: Không thể mở hộp thoại soạn thảo (Composer Dialog) sau các lần thử");
				return "";
			}

			// 3. ĐIỀN NỘI DUNG VĂN BẢN TRƯỚC (Dán 1 lần duy nhất qua STA Clipboard siêu tốc <0.5s)
			if (!string.IsNullOrEmpty(content))
			{
				bool entered = EnterPostContentWWW(content);
				if (!entered && !hasMedia)
				{
					Commom.smethod_49("ExecuteDangBaiWWW: Không thể điền nội dung cho bài viết thuần văn bản. Hủy để tránh đăng bài rỗng.");
					DismissComposerDialog();
					return "";
				}
				Commom.smethod_52(0.3);

				// Đóng menu gợi ý hashtag / mention (div[role="listbox"]) nếu xuất hiện để tránh che nút bấm
				try
				{
					ChromeDriver_0.ExecuteScript(@"
						var listbox = document.querySelector('div[role=""listbox""]');
						if (listbox) {
							var escEvt = new KeyboardEvent('keydown', { key: 'Escape', code: 'Escape', keyCode: 27, which: 27, bubbles: true });
							document.dispatchEvent(escEvt);
						}
					");
				}
				catch { }
			}

			// Tùy chọn phông nền (Background color) nếu là bài viết thuần văn bản
			if (isUseBackground && !hasMedia)
			{
				try
				{
					ChromeDriver_0.ExecuteScript(@"
						var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
						if (!dialog) return;
						var bgBtn = dialog.querySelector('div[aria-label*=""Hiển thị các tùy chọn nền"" i], div[aria-label*=""Show background options"" i], img[src*=""background""]');
						if (bgBtn) {
							bgBtn.click();
							var swatches = dialog.querySelectorAll('div[role=""button""][style*=""background-image""], div[role=""button""][style*=""linear-gradient""]');
							if (swatches.length > 0) {
								swatches[Math.floor(Math.random() * swatches.length)].click();
							}
						}
					");
					Commom.smethod_52(0.8);
				}
				catch { }
			}

			// 4. ĐÍNH KÈM VÀ XÁC MINH ẢNH / VIDEO NỘI BỘ (Scope 100% trong div[role="dialog"])
			if (hasMedia)
			{
				try
				{
					// 4.1 Bấm nút Ảnh/video BÊN TRONG HỘP THOẠI nếu chưa có input file nội bộ
					ChromeDriver_0.ExecuteScript(@"
						function triggerClick(el) {
							if (!el) return;
							el.scrollIntoView({ behavior: 'auto', block: 'center' });
							['mouseover', 'mouseenter', 'pointerdown', 'mousedown', 'pointerup', 'mouseup', 'click'].forEach(function(evt) {
								try {
									var e = new MouseEvent(evt, { bubbles: true, cancelable: true, view: window, buttons: 1 });
									el.dispatchEvent(e);
								} catch(err) {}
							});
							try { el.click(); } catch(e) {}
						}

						var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
						if (!dialog) return;

						var inp = dialog.querySelector('input[type=""file""]');
						if (!inp) {
							var btns = Array.from(dialog.querySelectorAll('div[role=""button""], [aria-label], [role=""button""] span, div[tabindex=""0""]'));
							for (var b of btns) {
								var aria = (b.getAttribute('aria-label') || '').toLowerCase();
								var text = (b.innerText || b.textContent || '').toLowerCase();
								if (aria.includes('ảnh/video') || aria.includes('photo/video') ||
									aria.includes('thêm ảnh/video') || aria.includes('add photos/videos') ||
									text.includes('ảnh/video') || text.includes('photo/video') ||
									text.includes('thêm ảnh/video') || text.includes('add photos/videos') ||
									aria.includes('ảnh') || aria.includes('photo')) {
									var target = b.closest('div[role=""button""]') || b;
									triggerClick(target);
									break;
								}
							}
						}
					");

					// 4.2 Chờ thẻ input[type="file"] xuất hiện BÊN TRONG div[role="dialog"]
					bool inputReady = false;
					for (int p = 0; p < 15; p++)
					{
						object hasInp = ChromeDriver_0.ExecuteScript(@"
							var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
							if (!dialog) return false;
							var inp = dialog.querySelector('input[type=""file""]');
							if (inp) {
								inp.setAttribute('data-lushcare-file', 'true');
								inp.style.display = 'block';
								inp.style.visibility = 'visible';
								inp.style.opacity = '1';
								inp.style.width = '120px';
								inp.style.height = '40px';
								inp.removeAttribute('hidden');
								inp.removeAttribute('disabled');
								return true;
							}
							return false;
						");
						if (hasInp != null && Convert.ToBoolean(hasInp))
						{
							inputReady = true;
							break;
						}
						Commom.smethod_52(0.3);
					}

					// 4.3 Gửi đường dẫn tệp vào input nội bộ của dialog
					if (!inputReady)
					{
						Commom.smethod_49("ExecuteDangBaiWWW: Không tìm thấy input file trong dialog. Hủy đăng bài để bảo vệ nội dung.");
						DismissComposerDialog();
						return "";
					}

					string filesPayload = string.Join("\n", validMedia);
					try
					{
						var fileInput = ChromeDriver_0.FindElement(By.CssSelector(@"div[role=""dialog""] input[data-lushcare-file=""true""]"));
						fileInput.SendKeys(filesPayload);
					}
					catch
					{
						var fileInputs = ChromeDriver_0.FindElements(By.CssSelector(@"div[role=""dialog""] input[type=""file""]"));
						if (fileInputs.Count > 0)
						{
							fileInputs[0].SendKeys(filesPayload);
						}
						else
						{
							Commom.smethod_49("ExecuteDangBaiWWW: Không thể tương tác với input file trong dialog");
							DismissComposerDialog();
							return "";
						}
					}

					// 4.4 XÁC MINH MEDIA ĐÃ TẢI LÊN THÀNH CÔNG (Kiểm tra Thumbnail, Video card, Progress bar, Lỗi từ chối)
					int mediaTimeoutSec = hasVideo ? 90 : 25;
					int startMediaTick = Environment.TickCount;
					bool mediaVerified = false;

					while (Environment.TickCount - startMediaTick < mediaTimeoutSec * 1000)
					{
						if (CD930D04() || E184CD03()) return "";

						object verifyRes = ChromeDriver_0.ExecuteScript(@"
							var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
							if (!dialog) return JSON.stringify({ status: 'dialog_lost' });

							// 1. Kiểm tra thông báo lỗi hoặc từ chối tải tệp
							var alerts = Array.from(dialog.querySelectorAll('[role=""alert""], div[data-visualcompletion=""ignore-dynamic-snippet""]'));
							for (var al of alerts) {
								var altText = (al.innerText || al.textContent || '').toLowerCase();
								if (altText.includes('không thể tải lên') || altText.includes('couldn\'t be uploaded') ||
									altText.includes('could not upload') || altText.includes('lỗi khi tải lên') ||
									altText.includes('something went wrong') || altText.includes('tệp quá lớn') ||
									altText.includes('too large') || altText.includes('không được hỗ trợ') ||
									altText.includes('unsupported') || altText.includes('không thể xử lý video') ||
									altText.includes('could not process video')) {
									return JSON.stringify({ status: 'error', message: altText.substring(0, 150) });
								}
							}

							// 2. Kiểm tra xem thẻ preview của ảnh/video đã gắn vào DOM chưa
							var hasImgPreview = !!dialog.querySelector('img[src*=""blob:""], [data-visualcompletion=""media-vc-image""], div[style*=""background-image""][style*=""blob:""], [aria-label*=""Gỡ ảnh"" i], [aria-label*=""Remove photo"" i]');
							var hasVideoPreview = !!dialog.querySelector('video, [data-video-player], [aria-label*=""Tùy chọn video"" i], [aria-label*=""Video options"" i], [aria-label*=""Gỡ video"" i], [aria-label*=""Remove video"" i]');
							var hasMediaCard = hasImgPreview || hasVideoPreview || !!dialog.querySelector('div[data-pagelet*=""MediaAttachment""]');

							// 3. Kiểm tra thanh tiến trình upload và biểu tượng spinner đang tải
							// LƯU Ý: Phải loại trừ thanh scrubber progressbar bên trong chính video player!
							var activeProgress = dialog.querySelector('div[role=""progressbar""]:not(video *):not([data-video-player] *):not([aria-valuenow=""100""])');
							var activeSpinner = dialog.querySelector('svg[aria-label*=""Đang tải"" i], svg[aria-label*=""Loading"" i], [role=""status""]');
							var isUploading = !!(activeProgress || activeSpinner);

							var textContent = (dialog.innerText || '').toLowerCase();
							if (textContent.includes('đang tải lên') || textContent.includes('uploading') ||
								textContent.includes('đang xử lý') || textContent.includes('processing video')) {
								isUploading = true;
							}

							if (hasMediaCard && !isUploading) {
								return JSON.stringify({ status: 'ready', hasVideo: hasVideoPreview, hasImage: hasImgPreview });
							}
							if (isUploading) {
								return JSON.stringify({ status: 'uploading' });
							}
							if (hasMediaCard) {
								return JSON.stringify({ status: 'card_present_waiting' });
							}
							return JSON.stringify({ status: 'waiting_for_mount' });
						");

						if (verifyRes != null)
						{
							try
							{
								JObject vObj = JObject.Parse(verifyRes.ToString());
								string status = vObj["status"]?.ToString() ?? "";
								if (status == "ready")
								{
									mediaVerified = true;
									break;
								}
								if (status == "error")
								{
									string errDetail = vObj["message"]?.ToString() ?? "Facebook rejected media";
									Commom.smethod_49("ExecuteDangBaiWWW: Media upload bị Facebook từ chối: " + errDetail);
									DismissComposerDialog();
									return "";
								}
							}
							catch { }
						}

						Commom.smethod_52(1.0);
					}

					// BẢO VỆ CHỐNG ĐĂNG BÀI KHÔNG CÓ MEDIA KHI ĐÃ ĐƯỢC YÊU CẦU
					if (!mediaVerified)
					{
						Commom.smethod_49("ExecuteDangBaiWWW: Hết thời gian chờ xác minh media tải lên (Timeout). Hủy đăng bài để tránh chỉ đăng văn bản!");
						DismissComposerDialog();
						return "";
					}

					// 4.5 BẢO TOÀN NỘI DUNG VĂN BẢN: Chỉ dán lại nếu ô soạn thảo thực sự tồn tại và bị Facebook làm trống
					if (!string.IsNullOrEmpty(content))
					{
						try
						{
							object isTextEmpty = ChromeDriver_0.ExecuteScript(@"
								var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
								if (!dialog) return false;
								var box = dialog.querySelector('[role=""textbox""], div[contenteditable=""true""]');
								if (!box) return false;
								var t = (box.innerText || box.textContent || '').trim();
								return t.length === 0;
							");
							if (isTextEmpty != null && Convert.ToBoolean(isTextEmpty))
							{
								EnterPostContentWWW(content);
								Commom.smethod_52(0.3);
							}
						}
						catch { }
					}
				}
				catch (Exception ex)
				{
					Commom.smethod_49("ExecuteDangBaiWWW upload media exception: " + ex.Message);
					DismissComposerDialog();
					return "";
				}
			}

			// 5. XỬ LÝ CÁC BƯỚC CHUYỂN TIẾP: 'Tiếp' / 'Next' / Quy tắc nhóm
			for (int nextAttempt = 0; nextAttempt < 3; nextAttempt++)
			{
				if (CD930D04() || E184CD03()) return "";

				object intermediateResult = ChromeDriver_0.ExecuteScript(@"
					function triggerClick(el) {
						if (!el) return;
						el.scrollIntoView({ behavior: 'auto', block: 'center' });
						['mouseover', 'mouseenter', 'pointerdown', 'mousedown', 'pointerup', 'mouseup', 'click'].forEach(function(evt) {
							try {
								var e = new MouseEvent(evt, { bubbles: true, cancelable: true, view: window, buttons: 1 });
								el.dispatchEvent(e);
							} catch(err) {}
						});
						try { el.click(); } catch(e) {}
					}

					var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
					if (!dialog) return 'none';

					// Tự động tích chọn đồng ý quy tắc nhóm nếu có checkbox
					var ruleCheckboxes = dialog.querySelectorAll('input[type=""checkbox""]:not(:checked), div[role=""checkbox""][aria-checked=""false""]');
					for (var cb of ruleCheckboxes) {
						try { cb.click(); } catch(e) {}
					}

					var buttons = Array.from(dialog.querySelectorAll('div[role=""button""], button'));
					for (var b of buttons) {
						var aria = (b.getAttribute('aria-label') || '').trim().toLowerCase();
						var text = (b.innerText || b.textContent || '').trim().toLowerCase();
						if (aria.includes('anonymously') || text.includes('anonymously') ||
							aria.includes('ẩn danh') || text.includes('ẩn danh')) continue;

						if (aria === 'tiếp' || aria === 'next' || aria === 'tiếp tục' || aria === 'continue' ||
							text === 'tiếp' || text === 'next' || text === 'tiếp tục' || text === 'continue' ||
							text.includes('tôi đồng ý') || text.includes('i agree') || text.includes('đồng ý quy tắc')) {
							var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled || b.hasAttribute('disabled');
							if (!disabled) {
								triggerClick(b);
								return 'clicked_intermediate';
							}
						}
					}
					return 'none';
				");
				if (intermediateResult != null && intermediateResult.ToString() == "clicked_intermediate")
				{
					Commom.smethod_52(1.5);
				}
				else
				{
					break;
				}
			}

			// Cài đặt MutationObserver để bắt toast snackbar / cảnh báo đăng bài trong nền
			try
			{
				ChromeDriver_0.ExecuteScript(@"
					window.__lushcare_post_state = {
						toastLink: null,
						isPending: false,
						errorMessage: null,
						isBlocked: false
					};

					if (!window.__lushcare_observer_installed) {
						window.__lushcare_observer_installed = true;
						var obs = new MutationObserver(function(mutations) {
							try {
								var alerts = document.querySelectorAll('div[role=""alert""], div[role=""status""], div[data-visualcompletion=""ignore-dynamic-layout""]');
								for (var i = 0; i < alerts.length; i++) {
									var el = alerts[i];
									var text = (el.innerText || el.textContent || '').trim();
									var lower = text.toLowerCase();
									if (!lower) continue;

									if (lower.includes('hạn chế') || lower.includes('bị chặn') || lower.includes('restricted') || 
										lower.includes('temporarily blocked') || lower.includes('tiêu chuẩn cộng đồng') || lower.includes('community standards')) {
										window.__lushcare_post_state.isBlocked = true;
										window.__lushcare_post_state.errorMessage = text;
									}
									else if (lower.includes('đã xảy ra lỗi') || lower.includes('có lỗi xảy ra') || 
											 lower.includes('không thể chia sẻ') || lower.includes('không thể tạo') || 
											 lower.includes('something went wrong') || lower.includes('could not share')) {
										window.__lushcare_post_state.errorMessage = text;
									}

									if (lower.includes('chờ phê duyệt') || lower.includes('pending approval') || 
										lower.includes('đang chờ quản trị viên') || lower.includes('chờ duyệt') ||
										lower.includes('đã gửi bài viết') || lower.includes('submitted')) {
										window.__lushcare_post_state.isPending = true;
									}

									var links = el.querySelectorAll('a[href]');
									for (var j = 0; j < links.length; j++) {
										var a = links[j];
										var h = a.getAttribute('href') || '';
										var atxt = (a.innerText || a.textContent || '').toLowerCase();
										if (h.includes('/posts/') || h.includes('/permalink/') || h.includes('story_fbid=') || 
											h.includes('/videos/') || h.includes('fbid=') || atxt.includes('xem') || atxt.includes('view')) {
											window.__lushcare_post_state.toastLink = a.href;
										}
									}
								}
							} catch(e) {}
						});
						obs.observe(document.body, { childList: true, subtree: true });
					}
				");
			}
			catch { }

			// 6. CHỜ NÚT ĐĂNG / POST KHẢ DỤNG (ENABLED & HẾT TIẾN TRÌNH TẢI)
			bool isReadyToPost = false;
			for (int waitReady = 0; waitReady < 45; waitReady++)
			{
				if (CD930D04() || E184CD03()) return "";

				object readyCheck = ChromeDriver_0.ExecuteScript(@"
					var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
					if (!dialog) return false;

					// Nếu vẫn còn progressbar hoặc spinner tải lên ngoài video player thì tiếp tục chờ
					var progress = dialog.querySelector('div[role=""progressbar""]:not(video *):not([data-video-player] *):not([aria-valuenow=""100""])');
					var spinner = dialog.querySelector('svg[aria-label*=""Đang tải"" i], svg[aria-label*=""Loading"" i]');
					if (progress || spinner) return false;

					var buttons = Array.from(dialog.querySelectorAll('div[role=""button""], button'));
					for (var b of buttons) {
						var aria = (b.getAttribute('aria-label') || '').trim().toLowerCase();
						var text = (b.innerText || b.textContent || '').trim().toLowerCase();
						if (aria.includes('anonymously') || text.includes('anonymously') ||
							aria.includes('ẩn danh') || text.includes('ẩn danh') ||
							aria.includes('thêm vào') || text.includes('thêm vào') ||
							aria.includes('add to') || text.includes('add to')) continue;

						if (aria === 'đăng' || aria === 'post' || aria === 'chia sẻ' || aria === 'share' ||
							aria === 'xuất bản' || aria === 'publish' || aria === 'xong' || aria === 'done' ||
							text === 'đăng' || text === 'post' || text === 'chia sẻ' || text === 'share' ||
							text === 'xuất bản' || text === 'publish' || text === 'xong' || text === 'done') {
							var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled || b.hasAttribute('disabled');
							if (!disabled) return true;
						}
					}
					return false;
				");
				if (readyCheck != null && Convert.ToBoolean(readyCheck))
				{
					isReadyToPost = true;
					break;
				}
				Commom.smethod_52(1.0);
			}

			if (!isReadyToPost)
			{
				Commom.smethod_49("ExecuteDangBaiWWW: Nút Post không khả dụng sau 45s chờ (bị disabled hoặc không tìm thấy)");
				DismissComposerDialog();
				return "";
			}

			// 7. BẤM NÚT ĐĂNG / POST DUY NHẤT VÀ CHỐNG DOUBLE-CLICK (Debounced Click & Confirmation)
			bool postSubmitted = false;
			int postClickedTick = 0;

			// Thực hiện 1 click dứt khoát đầu tiên qua JavaScript MouseEvents
			object initialClick = ChromeDriver_0.ExecuteScript(@"
				function triggerClick(el) {
					if (!el) return;
					el.scrollIntoView({ behavior: 'auto', block: 'center' });
					['mouseover', 'mouseenter', 'pointerdown', 'mousedown', 'pointerup', 'mouseup', 'click'].forEach(function(evt) {
						try {
							var e = new MouseEvent(evt, { bubbles: true, cancelable: true, view: window, buttons: 1 });
							el.dispatchEvent(e);
						} catch(err) {}
					});
					try { el.click(); } catch(e) {}
				}

				var dialog = document.querySelector('div[data-lushcare-composer=""active""]') || document.querySelector('div[role=""dialog""]');
				if (!dialog) return 'no_dialog';

				var buttons = Array.from(dialog.querySelectorAll('div[role=""button""], button'));
				for (var b of buttons) {
					var aria = (b.getAttribute('aria-label') || '').trim().toLowerCase();
					var text = (b.innerText || b.textContent || '').trim().toLowerCase();
					if (aria.includes('anonymously') || text.includes('anonymously') ||
						aria.includes('ẩn danh') || text.includes('ẩn danh') ||
						aria.includes('thêm vào') || text.includes('thêm vào') ||
						aria.includes('add to') || text.includes('add to')) continue;

					if (aria === 'đăng' || aria === 'post' || aria === 'chia sẻ' || aria === 'share' ||
						aria === 'xuất bản' || aria === 'publish' || aria === 'xong' || aria === 'done' ||
						text === 'đăng' || text === 'post' || text === 'chia sẻ' || text === 'share' ||
						text === 'xuất bản' || text === 'publish' || text === 'xong' || text === 'done') {
						var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled || b.hasAttribute('disabled');
						if (!disabled) {
							triggerClick(b);
							return 'clicked_post';
						}
					}
				}
				return 'not_found';
			");

			postClickedTick = Environment.TickCount;

			// Vòng lặp chờ xác nhận đóng dialog và ngăn chặn double-click (Tối đa 25s)
			string verifiedPermalink = "";
			bool isPendingApproval = false;

			for (int confirmSec = 0; confirmSec < 25; confirmSec++)
			{
				if (CD930D04() || E184CD03()) return "";

				// Kiểm tra xem hộp thoại soạn thảo đã biến mất hoàn toàn chưa
				object dialogState = ChromeDriver_0.ExecuteScript(@"
					var state = window.__lushcare_post_state || {};

					// 1. Kiểm tra thông báo lỗi bị chặn / hạn chế đăng bài từ dialogs
					var dialogs = document.querySelectorAll('div[role=""dialog""], div[role=""alertdialog""]');
					for (var i = 0; i < dialogs.length; i++) {
						var d = dialogs[i];
						var dText = (d.innerText || d.textContent || '').trim();
						var dLower = dText.toLowerCase();
						var hasTextbox = d.querySelector('[role=""textbox""], div[contenteditable=""true""]');

						if (dLower.includes('hạn chế') || dLower.includes('bị chặn') || dLower.includes('temporarily blocked') ||
							dLower.includes('restricted') || dLower.includes('tiêu chuẩn cộng đồng') || dLower.includes('community standards')) {
							return JSON.stringify({ status: 'blocked', message: dText });
						}

						if (!hasTextbox && (dLower.includes('đã xảy ra lỗi') || dLower.includes('có lỗi xảy ra') || 
							dLower.includes('something went wrong') || dLower.includes('không thể chia sẻ') || dLower.includes('không thể tạo'))) {
							return JSON.stringify({ status: 'error', message: dText });
						}

						if (dLower.includes('chờ phê duyệt') || dLower.includes('pending approval') || 
							dLower.includes('đang chờ quản trị viên') || dLower.includes('submitted')) {
							return JSON.stringify({ status: 'pending', message: dText });
						}
					}

					if (state.isBlocked) return JSON.stringify({ status: 'blocked', message: state.errorMessage || 'Blocked' });
					if (state.errorMessage) return JSON.stringify({ status: 'error', message: state.errorMessage });
					if (state.isPending) return JSON.stringify({ status: 'pending', message: 'Pending approval' });
					if (state.toastLink) return JSON.stringify({ status: 'success', permalink: state.toastLink });

					// Kiểm tra link Xem bài viết trên Toast snackbar
					var alerts = Array.from(document.querySelectorAll('div[role=""alert""], div[role=""status""]'));
					for (var a of alerts) {
						var aLinks = a.querySelectorAll('a[href]');
						for (var al of aLinks) {
							var h = al.getAttribute('href') || '';
							var atxt = (al.innerText || al.textContent || '').toLowerCase();
							if (h.includes('/posts/') || h.includes('/permalink/') || h.includes('story_fbid=') ||
								h.includes('/videos/') || h.includes('fbid=') || atxt.includes('xem') || atxt.includes('view')) {
								return JSON.stringify({ status: 'success', permalink: al.href });
							}
						}
					}

					// Kiểm tra trạng thái Hộp thoại soạn thảo
					var composerDialog = document.querySelector('div[role=""dialog""] [role=""textbox""], div[role=""dialog""] div[contenteditable=""true""]');
					if (!composerDialog) return JSON.stringify({ status: 'dialog_closed' });

					// Kiểm tra nút Post có đang trong trạng thái Đang gửi (Submitting) hay không
					var buttons = Array.from(document.querySelectorAll('div[role=""dialog""] div[role=""button""], div[role=""dialog""] button'));
					for (var b of buttons) {
						var aria = (b.getAttribute('aria-label') || '').trim().toLowerCase();
						var text = (b.innerText || b.textContent || '').trim().toLowerCase();
						if (aria === 'đăng' || aria === 'post' || aria === 'chia sẻ' || aria === 'share' ||
							text === 'đăng' || text === 'post' || text === 'chia sẻ' || text === 'share') {
							var disabled = b.getAttribute('aria-disabled') === 'true' || b.disabled || b.hasAttribute('disabled');
							var posting = text.includes('đang') || aria.includes('đang') || text.includes('posting') || aria.includes('posting');
							if (disabled || posting) return JSON.stringify({ status: 'submitting' });
							return JSON.stringify({ status: 'still_enabled' });
						}
					}

					return JSON.stringify({ status: 'waiting' });
				");

				if (dialogState != null)
				{
					try
					{
						JObject jState = JObject.Parse(dialogState.ToString());
						string status = jState["status"]?.ToString() ?? "";

						if (status == "blocked")
						{
							EE37E6A7 = true;
							Commom.smethod_49("ExecuteDangBaiWWW: Tài khoản bị Facebook chặn/hạn chế: " + jState["message"]);
							DismissComposerDialog();
							return "";
						}

						if (status == "error")
						{
							Commom.smethod_49("ExecuteDangBaiWWW: Lỗi đăng bài: " + jState["message"]);
							DismissComposerDialog();
							return "";
						}

						if (status == "pending")
						{
							isPendingApproval = true;
							postSubmitted = true;
							break;
						}

						if (status == "success")
						{
							string rawLink = jState["permalink"]?.ToString() ?? "";
							if (!string.IsNullOrEmpty(rawLink))
							{
								verifiedPermalink = CleanFacebookPermalink(rawLink);
								postSubmitted = true;
								break;
							}
						}

						if (status == "dialog_closed")
						{
							postSubmitted = true;
							break;
						}

						if (status == "submitting")
						{
							// Đang gửi request lên server Meta, KHÔNG ĐƯỢC bấm lại để tránh duplicate!
							Commom.smethod_52(1.0);
							continue;
						}

						// Nếu đã trôi qua hơn 7 giây mà dialog vẫn còn và nút Post vẫn 'still_enabled' (bấm hụt focus),
						// mới kích hoạt 1 lần bấm retry bằng Selenium Actions duy nhất
						if (status == "still_enabled" && (Environment.TickCount - postClickedTick >= 7000))
						{
							try
							{
								var postBtns = ChromeDriver_0.FindElements(By.XPath("//div[@role='dialog']//div[(@aria-label='Đăng' or @aria-label='Post' or descendant::span[text()='Đăng' or text()='Post']) and not(contains(@aria-label, 'anonymously')) and not(contains(@aria-label, 'ẩn danh'))]"));
								foreach (var btn in postBtns)
								{
									if (btn.GetAttribute("aria-disabled") != "true")
									{
										OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(ChromeDriver_0);
										actions.MoveToElement(btn).Click().Perform();
										postClickedTick = Environment.TickCount;
										break;
									}
								}
							}
							catch { }
						}
					}
					catch { }
				}

				Commom.smethod_52(1.0);
			}

			// Nếu phát hiện bài viết đang chờ quản trị viên phê duyệt
			if (isPendingApproval)
			{
				string pendingGroupUrl = "https://www.facebook.com/groups/" + cleanGroupIdTarget + "/pending_posts";
				Commom.smethod_49("ExecuteDangBaiWWW: Bài viết gửi duyệt nhóm thành công: " + pendingGroupUrl);
				try { KichBanThongKeDB.LogPost(B4208531, pendingGroupUrl, content ?? "", "Đăng nhóm (Chờ duyệt)", "Chờ duyệt"); } catch { }
				return pendingGroupUrl;
			}

			// Nếu đã bắt được permalink từ toast snackbar
			if (!string.IsNullOrEmpty(verifiedPermalink))
			{
				Commom.smethod_49("ExecuteDangBaiWWW: Bắt được permalink từ toast: " + verifiedPermalink);
				try { string tLabel = (typeObject == 1) ? "Đăng nhóm" : (typeObject == 2) ? "Đăng Page" : "Đăng tường"; KichBanThongKeDB.LogPost(B4208531, verifiedPermalink, content ?? "", tLabel, "Thành công"); } catch { }
				return verifiedPermalink;
			}

			if (!postSubmitted)
			{
				Commom.smethod_49("ExecuteDangBaiWWW: Hộp thoại soạn thảo không đóng sau thời gian chờ -> Thất bại.");
				DismissComposerDialog();
				return "";
			}

			// 8. QUÉT BẢNG TIN (FEED POLLING) ĐỂ LẤY PERMALINK THẬT
			F8091028(1.5);
			string expectedSnippet = string.IsNullOrEmpty(content) ? "" : Regex.Replace(content.Trim(), @"\s+", " ");
			if (expectedSnippet.Length > 40) expectedSnippet = expectedSnippet.Substring(0, 40);

			for (int poll = 0; poll < 5; poll++)
			{
				try
				{
					object feedResultObj = ChromeDriver_0.ExecuteScript(@"
						var expected = (arguments[0] || '').trim().toLowerCase();

						var pendingBanner = document.querySelector('a[href*=""/pending_posts""], a[href*=""/user_manage_post""]');
						if (pendingBanner) {
							return JSON.stringify({ status: 'pending', url: pendingBanner.href });
						}

						var allSpans = document.querySelectorAll('span, div');
						for (var sp of allSpans) {
							var t = (sp.innerText || sp.textContent || '').trim().toLowerCase();
							if (t === 'bài viết đang chờ phê duyệt' || t === '1 bài viết đang chờ phê duyệt' || t === 'pending approval' || t.includes('bài viết đang chờ phê duyệt')) {
								return JSON.stringify({ status: 'pending', url: 'pending_posts' });
							}
						}

						var feedUnits = Array.from(document.querySelectorAll('div[role=""feed""] > div, div[data-pagelet*=""FeedUnit""], div[role=""article""], div[data-pagelet*=""ProfileFeed""] > div, div[data-pagelet*=""GroupFeed""] > div'));
						if (!feedUnits.length) {
							feedUnits = Array.from(document.querySelectorAll('div[role=""main""] div[role=""article""]'));
						}

						var topUnits = feedUnits.slice(0, 7);
						var timeKeywords = ['vừa xong', 'just now', '1 phút', '1m', '1 min', '2m', '2 phút', 'một phút trước', 'a few seconds ago'];

						for (var unit of topUnits) {
							var unitText = (unit.innerText || unit.textContent || '');
							var unitTextLower = unitText.toLowerCase();

							if (unitTextLower.includes('đang chờ phê duyệt') || unitTextLower.includes('pending approval') || unitTextLower.includes('bài viết đang chờ')) {
								return JSON.stringify({ status: 'pending', url: 'pending_posts' });
							}

							var contentMatched = false;
							if (expected && expected.length > 0 && unitTextLower.includes(expected)) {
								contentMatched = true;
							}

							var timeMatched = false;
							for (var kw of timeKeywords) {
								if (unitTextLower.includes(kw)) {
									timeMatched = true;
									break;
								}
							}

							if (!timeMatched) {
								var timeLinks = unit.querySelectorAll('span[id], a[role=""link""], span[aria-labelledby]');
								for (var tl of timeLinks) {
									var aria = (tl.getAttribute('aria-label') || '').toLowerCase();
									for (var kw of timeKeywords) {
										if (aria.includes(kw)) {
											timeMatched = true;
											break;
										}
									}
									if (timeMatched) break;
								}
							}

							if (contentMatched || timeMatched) {
								var links = Array.from(unit.querySelectorAll('a[href]'));
								for (var a of links) {
									var href = a.getAttribute('href') || '';
									if (href.includes('/posts/') || 
										href.includes('/permalink/') || 
										href.includes('story_fbid=') || 
										href.includes('/videos/') || 
										href.includes('/photo/?fbid=') || 
										href.includes('/photos/')) {
										if (!href.endsWith('/groups/') && !href.endsWith('/groups') && !href.includes('/user/') && !href.includes('/hashtag/')) {
											return JSON.stringify({ status: 'found', permalink: a.href });
										}
									}
								}

								for (var a of links) {
									var atxt = (a.innerText || a.textContent || '').trim().toLowerCase();
									var aaria = (a.getAttribute('aria-label') || '').toLowerCase();
									for (var kw of timeKeywords) {
										if (atxt.includes(kw) || aaria.includes(kw)) {
											return JSON.stringify({ status: 'found', permalink: a.href });
										}
									}
								}
							}
						}

						return JSON.stringify({ status: 'not_found' });
					", expectedSnippet);

					if (feedResultObj != null)
					{
						JObject jFeed = JObject.Parse(feedResultObj.ToString());
						string fStatus = jFeed["status"]?.ToString() ?? "";
						if (fStatus == "pending")
						{
							string pendingGroupUrl = "https://www.facebook.com/groups/" + cleanGroupIdTarget + "/pending_posts";
							Commom.smethod_49("ExecuteDangBaiWWW: Phát hiện bài viết chờ duyệt qua feed: " + pendingGroupUrl);
							try { KichBanThongKeDB.LogPost(B4208531, pendingGroupUrl, content ?? "", "Đăng nhóm (Chờ duyệt)", "Chờ duyệt"); } catch { }
							return pendingGroupUrl;
						}
						if (fStatus == "found")
						{
							string rawFoundLink = jFeed["permalink"]?.ToString() ?? "";
							if (!string.IsNullOrEmpty(rawFoundLink))
							{
								verifiedPermalink = CleanFacebookPermalink(rawFoundLink);
								Commom.smethod_49("ExecuteDangBaiWWW: Trích xuất thành công permalink từ Feed: " + verifiedPermalink);
								try { string tLabel = (typeObject == 1) ? "Đăng nhóm" : (typeObject == 2) ? "Đăng Page" : "Đăng tường"; KichBanThongKeDB.LogPost(B4208531, verifiedPermalink, content ?? "", tLabel, "Thành công"); } catch { }
								return verifiedPermalink;
							}
						}
					}
				}
				catch { }

				// Cuộn nhẹ trang để kích thích nạp feed
				try
				{
					ChromeDriver_0.ExecuteScript("window.scrollBy(0, 250);");
				}
				catch { }
				F8091028(1.0);
			}

			// 9. NẾU LÀ ĐĂNG TƯỜNG (typeObject == 0) MÀ CHƯA TÌM THẤY TRÊN HOME FEED,
			// CHUYỂN HƯỚNG VÀO TRANG CÁ NHÂN ĐỂ QUÉT TIMELINE CHÍNH XÁC
			if (typeObject == 0 && string.IsNullOrEmpty(verifiedPermalink))
			{
				try
				{
					string myProfileUrl = !string.IsNullOrEmpty(B4208531) ? ("https://www.facebook.com/" + B4208531) : "https://www.facebook.com/me";
					method_12(myProfileUrl, FC3A841F: true);
					F8091028(2.0);

					object profileFeedObj = ChromeDriver_0.ExecuteScript(@"
						var expected = (arguments[0] || '').trim().toLowerCase();
						var feedUnits = Array.from(document.querySelectorAll('div[data-pagelet*=""ProfileTimeline""] div[role=""article""], div[role=""feed""] div[role=""article""], div[data-pagelet*=""FeedUnit""]'));
						var topUnits = feedUnits.slice(0, 4);
						var timeKeywords = ['vừa xong', 'just now', '1 phút', '1m', '1 min', '2m', '2 phút', 'a few seconds ago'];

						for (var unit of topUnits) {
							var unitText = (unit.innerText || unit.textContent || '').toLowerCase();
							var matched = (!expected || unitText.includes(expected));
							if (!matched) {
								for (var kw of timeKeywords) {
									if (unitText.includes(kw)) { matched = true; break; }
								}
							}
							if (matched) {
								var links = Array.from(unit.querySelectorAll('a[href]'));
								for (var a of links) {
									var href = a.getAttribute('href') || '';
									if (href.includes('/posts/') || href.includes('/permalink/') || href.includes('story_fbid=') || href.includes('/videos/') || href.includes('/photo/?fbid=')) {
										if (!href.includes('/hashtag/')) return a.href;
									}
								}
							}
						}
						return null;
					", expectedSnippet);

					if (profileFeedObj != null && !string.IsNullOrEmpty(profileFeedObj.ToString()))
					{
						verifiedPermalink = CleanFacebookPermalink(profileFeedObj.ToString());
						Commom.smethod_49("ExecuteDangBaiWWW: Trích xuất thành công permalink từ Trang cá nhân: " + verifiedPermalink);
						try { KichBanThongKeDB.LogPost(B4208531, verifiedPermalink, content ?? "", "Đăng tường", "Thành công"); } catch { }
						return verifiedPermalink;
					}
				}
				catch { }
			}

			// NẾU KHÔNG THỂ XÁC MINH ĐƯỢC BÀI VIẾT: TUYỆT ĐỐI KHÔNG TẠO URL GIẢ!
			// Trả về rỗng ("") để thông báo chưa xác minh, tuân thủ nghiêm ngặt yêu cầu hệ thống.
			Commom.smethod_49("ExecuteDangBaiWWW: Không thể trích xuất permalink thực tế sau khi đăng. Trả về rỗng để đảm bảo tính xác thực.");
			return "";
		}
		catch (Exception ex)
		{
			Commom.smethod_49("ExecuteDangBaiWWW exception: " + ex.ToString());
			return "";
		}
	}

	public static string CleanFacebookPermalink(string rawUrl)
	{
		if (string.IsNullOrWhiteSpace(rawUrl)) return "";
		rawUrl = rawUrl.Trim();
		if (rawUrl.StartsWith("/"))
		{
			rawUrl = "https://www.facebook.com" + rawUrl;
		}
		if (!rawUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
			!rawUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
		{
			rawUrl = "https://www.facebook.com/" + rawUrl.TrimStart('/');
		}

		try
		{
			int qIdx = rawUrl.IndexOf('?');
			if (qIdx == -1)
			{
				return rawUrl.TrimEnd('/');
			}

			string baseUrl = rawUrl.Substring(0, qIdx).TrimEnd('/');
			string queryString = rawUrl.Substring(qIdx + 1);

			// Direct post path (e.g. groups/.../posts/123, username/posts/123, /videos/123)
			if (baseUrl.Contains("/posts/") || baseUrl.Contains("/permalink/") || baseUrl.Contains("/videos/"))
			{
				return baseUrl;
			}

			// Query based post links (permalink.php?story_fbid=... or story.php?story_fbid=...)
			if (baseUrl.EndsWith("/permalink.php", StringComparison.OrdinalIgnoreCase) ||
				baseUrl.EndsWith("/story.php", StringComparison.OrdinalIgnoreCase))
			{
				var matchFbid = Regex.Match(queryString, @"(?:story_fbid|fbid|post_id)=([^&]+)");
				var matchId = Regex.Match(queryString, @"(?:\bid)=([^&]+)");
				if (matchFbid.Success)
				{
					if (matchId.Success)
					{
						return $"{baseUrl}?story_fbid={matchFbid.Groups[1].Value}&id={matchId.Groups[1].Value}";
					}
					return $"{baseUrl}?story_fbid={matchFbid.Groups[1].Value}";
				}
			}

			// Photo links: photo/?fbid=...
			if (baseUrl.Contains("/photo"))
			{
				var matchFbid = Regex.Match(queryString, @"fbid=([^&]+)");
				if (matchFbid.Success)
				{
					return $"{baseUrl}/?fbid={matchFbid.Groups[1].Value}";
				}
			}

			// Clean tracking params from query
			string cleanQuery = Regex.Replace(queryString, @"(?:^|&)(?:__cft__(?:\[\d+\])?|__tn__|notif_\w+|ref|rdid|epa|mibextid)=[^&]*", "");
			cleanQuery = cleanQuery.Trim('&');
			return string.IsNullOrEmpty(cleanQuery) ? baseUrl : $"{baseUrl}?{cleanQuery}";
		}
		catch
		{
			return rawUrl;
		}
	}

	internal string method_106(int int_4, string string_10, string F818BC07, bool B9322A3C = false, List<string> list_0 = null)
	{
		try
		{
			string textDirect = ExecuteDangBaiWWW(int_4, string_10, F818BC07, B9322A3C, list_0);
			return textDirect ?? "";
		}
		catch (Exception ex)
		{
			Commom.smethod_49("method_106 ExecuteDangBaiWWW error: " + ex.Message);
			return "";
		}
	}


	internal bool AA9B31A2(string A00EFB84, List<string> EE046D39 = null)
	{
		A00EFB84 = A00EFB84.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"");
		string text = "";
		if (EE046D39 != null)
		{
			text = string.Join("|", EE046D39);
			text = text.Replace("\\", "\\\\\\\\");
		}
		string string_ = "[{\"name\":\"content\", \"value\":\"" + A00EFB84 + "\", \"type\":\"text\"},{\"name\":\"image\", \"value\":\"" + text + "\", \"type\":\"text\"}]";
		string json = method_66("DangBaiMbasic", string_);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool F91638A4(string C1956D1E, string string_10)
	{
		C1956D1E = C1956D1E.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"");
		string_10 = string_10.Replace("\\", "\\\\\\\\");
		string string_11 = "[{\"name\":\"content\", \"value\":\"" + C1956D1E + "\", \"type\":\"text\"},{\"name\":\"image\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}" + $",{{\"name\":\"timeout\", \"value\":\"{60}\", \"type\":\"bool\"}}]";
		int num = method_61();
		string json = "";
		switch (num)
		{
		case 1:
			json = method_66("UpAvatarWWW", string_11);
			break;
		case 3:
			json = method_66("UpAvatarMbasic", string_11);
			break;
		}
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool F30671BA(string EA84520E, string D434E10F)
	{
		EA84520E = EA84520E.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"");
		D434E10F = D434E10F.Replace("\\", "\\\\\\\\");
		string string_ = "[{\"name\":\"image\", \"value\":\"" + D434E10F + "\", \"type\":\"text\"}]";
		int num = method_61();
		string json = "";
		switch (num)
		{
		case 1:
			json = method_66("UpCoverWWW", string_);
			break;
		case 3:
			json = method_66("UpCoverMbasic", string_);
			break;
		}
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool method_107()
	{
		string json = method_66("RoiNhomWWW");
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool method_108()
	{
		string json = method_66("HuyKetBanWWW");
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool method_109(string string_10)
	{
		string_10 = string_10.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"");
		string string_11 = "[{\"name\":\"content\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}" + $",{{\"name\":\"timeout\", \"value\":\"{60}\", \"type\":\"bool\"}}]";
		string json = method_66("AddFrameAvatarWWW", string_11);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool method_110(GClass4 gclass4_0)
	{
		int num = gclass4_0.method_2("nudSoLuongBaiFrom");
		int num2 = gclass4_0.method_2("nudSoLuongBaiTo");
		int num3 = gclass4_0.method_2("nudDelayFrom");
		int num4 = gclass4_0.method_2("nudDelayTo");
		bool flag = gclass4_0.method_3("ckbOnlyDeleteTagPost");
		string string_ = $"[{{\"name\":\"nudSoLuongFrom\", \"value\":\"{num}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudSoLuongTo\", \"value\":\"{num2}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudDelayFrom\", \"value\":\"{num3}\", \"type\":\"number\"}}" + $",{{\"name\":\"nudDelayTo\", \"value\":\"{num4}\", \"type\":\"number\"}}" + $",{{\"name\":\"ckbOnlyDeleteTagPost\", \"value\":\"{flag}\", \"type\":\"bool\"}}]";
		string json = method_66("DeletePost", string_);
		JObject jObject = JObject.Parse(json);
		return Convert.ToBoolean(jObject["success"]);
	}

	internal List<string> method_111(string string_10, int EEAA1797)
	{
		List<string> list = new List<string>();
		if (!GetURL().StartsWith("https://m.facebook.com/"))
		{
			method_12("https://m.facebook.com/");
		}
		string text = "https://m.facebook.com/" + string_10;
		if (string_10.Contains("https://"))
		{
			text = string_10.Replace(Regex.Match(string_10, "https://.*?facebook").Value, "https://m.facebook");
			string_10 = "";
		}
		do
		{
			string input = C604C58C(text);
			MatchCollection matchCollection = Regex.Matches(input, "top_level_post_id&quot;:&quot;(.*?)&quot;");
			if (matchCollection.Count == 0)
			{
				matchCollection = Regex.Matches(input, "/story\\.php\\?story_fbid=(.*?)&");
			}
			foreach (Match item2 in matchCollection)
			{
				string item = string_10 + "_" + item2.Groups[1].Value;
				if (!list.Contains(item))
				{
					list.Add(item);
					if (EEAA1797 <= list.Count)
					{
						return list;
					}
				}
			}
			if (list.Count == 0 && !text.Contains("timeline"))
			{
				text = "https://m.facebook.com/" + string_10 + "?v=timeline";
				continue;
			}
			text = Regex.Match(input, "href=\"(/groups/\\d+\\?bacr.*?)\"").Groups[1].Value;
			if (text == "")
			{
				text = Regex.Match(input, "href=\"(/profile/timeline/stream/\\?cursor=.*?)\"").Groups[1].Value;
			}
			if (text == "" && string_10 == "")
			{
				text = Regex.Match(input, "href=\"(/watch/\\?cursor=.*?)\"").Groups[1].Value;
			}
			if (text != "")
			{
				text = "https://m.facebook.com" + text.Replace("&amp;", "&");
			}
		}
		while (text != "" && EEAA1797 > list.Count);
		return list;
	}

	public string DDA19A0D(string string_10, ref string string_11, ref string string_12, ref string string_13)
	{
		if (B6B71C81 != "")
		{
			return B6B71C81;
		}
		B6B71C81 = D831098B.smethod_0(string_10, string_11);
		if (B6B71C81 != "")
		{
			return B6B71C81;
		}
		if (CD930D04() || E184CD03())
		{
			(bool success, string error) tuple = method_0();
			var (flag, _) = tuple;
			_ = tuple.error;
			if (!flag)
			{
				return "fail";
			}
		}
		string json = method_94(string_10, string_11, string_12, string_13);
		JObject jObject = JObject.Parse(json);
		if (!Convert.ToBoolean(jObject["success"]))
		{
			return "fail";
		}
		if (jObject["mailRecover"]!.ToString() != "" && jObject["mailRecover"]!.ToString() != string_12)
		{
			string_12 = jObject["mailRecover"]!.ToString();
			string_13 = jObject["passMailRecover"]!.ToString();
		}
		if (string_11 != jObject["passmail"]!.ToString())
		{
			string_11 = jObject["passmail"]!.ToString();
		}
		B6B71C81 = method_40("live.com");
		return B6B71C81;
	}

	internal void CC3EF93A(string string_10, string string_11 = "")
	{
		string_11 = string_11.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"");
		string_10 = string_10.Replace("\\", "\\\\\\\\");
		string string_12 = "[{\"name\":\"image\", \"value\":\"" + string_10 + "\", \"type\":\"text\"},{\"name\":\"content\", \"value\":\"" + string_11 + "\", \"type\":\"text\"}]";
		method_66("DangStoryWWW", string_12);
	}

	internal bool method_113(string string_10, string string_11, string string_12, string C8AE7D33)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		gClass.method_4("commentId", "");
		string text = "[href^=\"/reactions/picker/?ft_id=" + string_10 + "\"]";
		string text2 = "[href^=\"/comment/replies/?ctoken=\"][href*=\"" + string_10 + "\"]";
		string text3 = "[href^=\"/mbasic/comment/advanced/\"][href*=\"at=edit\"]";
		string string_13 = "[name=\"comment_text\"]";
		string d88CF43E = "input[name=\"view_photo\"]";
		string string_14 = "[data-sigil=\"m-raw-file-input\"],[type=\"file\"]";
		if (string_11 != "" && D7A424AE(text))
		{
			method_19(text);
			F8091028(2.0);
			if (Commom.smethod_45(string_11))
			{
				string_11 = "Like|Love|Care|Haha|Wow|Sad|Angry".Split('|')[Convert.ToInt32(string_11)];
			}
			else if (string_11.Contains("|"))
			{
				string_11 = string_11.Split('|').ToList().smethod_8();
			}
			string text4 = string_11.ToLower();
			string text5 = text4;
			switch (AFAE75A0.smethod_0(text5))
			{
			case 2267502540u:
				if (text5 == "care")
				{
					string_11 = "16";
				}
				break;
			case 585688324u:
				if (text5 == "wow")
				{
					string_11 = "3";
				}
				break;
			case 199741238u:
				if (text5 == "like")
				{
					string_11 = "1";
				}
				break;
			case 3576140497u:
				if (text5 == "love")
				{
					string_11 = "2";
				}
				break;
			case 3037376254u:
				if (text5 == "angry")
				{
					string_11 = "8";
				}
				break;
			case 4256463021u:
				if (text5 == "haha")
				{
					string_11 = "4";
				}
				break;
			case 3860638727u:
				if (text5 == "sad")
				{
					string_11 = "7";
				}
				break;
			}
			string string_15 = "[href^=\"/ufi/reaction/?ft_ent_identifier=" + string_10 + "&reaction_type=" + string_11 + "&\"]";
			if (D7A424AE(string_15) && method_18(string_15))
			{
				gClass.method_4("success", true);
				F8091028(2.0);
			}
			else
			{
				F7221F34();
			}
		}
		if ((string_12 != "" || C8AE7D33 != "") && D7A424AE(text2))
		{
			method_19(text2);
			F8091028(2.0);
			int num = method_30(text3);
			List<string> list = new List<string>();
			for (int i = 0; i < num; i++)
			{
				string item = F79D3F1F(B9BE8807(text3 + "|" + i, "href"), "ctoken=(.*?)&");
				list.Add(item);
			}
			if (C8AE7D33 != "")
			{
				method_19(d88CF43E);
				F8091028(1.0);
				method_24(string_14, C8AE7D33);
				F8091028(2.0);
			}
			if (string_12 != "")
			{
				method_22(string_13, string_12 + " ");
				F8091028(2.0);
			}
			string d88CF43E2 = method_15(0.0, new List<string> { "form [name=\"post\"]", "form [type=\"submit\"]" });
			method_19(d88CF43E2);
			int num2 = 60;
			int tickCount = Environment.TickCount;
			while (true)
			{
				if (!CD930D04() && !E184CD03())
				{
					if (method_30(text3) > 0)
					{
						num = method_30(text3);
						for (int j = 0; j < num; j++)
						{
							string text6 = F79D3F1F(B9BE8807(text3 + "|" + j, "href"), "ctoken=(.*?)&");
							if (!list.Contains(text6))
							{
								gClass.method_4("commentId", text6);
								gClass.method_4("success", true);
								break;
							}
						}
						if (gClass.method_3("success"))
						{
							break;
						}
					}
					if (!D6BBEDA3())
					{
						if (Environment.TickCount - tickCount >= num2 * 1000)
						{
							break;
						}
						F8091028(1.0);
						continue;
					}
					gClass.method_4("error", "fb_blocked");
					break;
				}
				gClass.method_4("error", "chrome_closed");
				break;
			}
		}
		bool result;
		if (!(result = Convert.ToBoolean(gClass.method_3("success"))))
		{
			EE37E6A7 = gClass.BDB80B23("error") == "fb_blocked";
		}
		return result;
	}

	internal bool method_114(string string_10, string D3AFF613, string E28DC710, string string_11)
	{
		if (string_10.StartsWith("https://"))
		{
			string_10 = Regex.Match(string_10, "comment_id=(\\d+)").Groups[1].Value;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		gClass.method_4("commentId", "");
		bool flag = ((E28DC710 != "") ? true : false);
		bool flag2 = ((string_11 != "") ? true : false);
		if (D7A424AE("[aria-label=\"See all\"]"))
		{
			method_19("[aria-label=\"See all\"]");
			F8091028(2.0);
		}
		string text = method_15(0.0, new List<string>
		{
			"//*[contains(@aria-label, \"Comment by\") or contains(@aria-label, \"Comment as\")][.//*[contains(@href,\"comment_id=" + string_10 + "\")]]",
			"//*[(contains(@aria-label, \"Comment by\") or contains(@aria-label, \"Comment as\")) and parent::*//*[contains(@aria-label,\"Reply to\") or contains(@aria-label,\"Reply as\") or contains(@aria-label,\"Write a\")]]"
		});
		if (text == "")
		{
			gClass.method_4("error", "not_found_post");
		}
		else
		{
			string text2 = text + "//*[(@aria-label=\"React\" or (contains(@aria-label,\"Change \") and contains(@aria-label,\" reaction\")))]";
			string text3 = text + "//*[text()=\"Reply\"]";
			string text4 = text + "//parent::*//parent::*";
			string text5 = text4 + "//*[contains(@aria-label,\"Reply to\") or contains(@aria-label,\"Reply as\") or contains(@aria-label,\"Write a\")]";
			string string_12 = "(" + text4 + "//input[@type=\"file\"])[last()]";
			string d88CF43E = text4 + "//*[@aria-label=\"Comment\"]";
			string text6 = text4 + "//*[@aria-label=\"Edit or delete this\"]";
			if (D3AFF613 != "" && D7A424AE(text2))
			{
				method_20(text2, 2);
				method_21(text2);
				F8091028(2.0);
				if (Commom.smethod_45(D3AFF613))
				{
					D3AFF613 = "Like|Love|Care|Haha|Wow|Sad|Angry".Split('|')[Convert.ToInt32(D3AFF613)];
				}
				else if (D3AFF613.Contains("|"))
				{
					D3AFF613 = D3AFF613.Split('|').ToList().smethod_8();
				}
				string text7 = "(//*[@aria-label=\"Reactions\"]//*[contains(@aria-label,\"" + D3AFF613 + "\")])[last()]";
				if (D7A424AE(text7, 5.0) && method_19(text7))
				{
					gClass.method_4("success", true);
					F8091028(2.0);
				}
			}
			if ((flag || flag2) && D7A424AE(text3))
			{
				int num = method_30(text6);
				List<string> list = new List<string>();
				for (int i = 1; i < num + 1; i++)
				{
					string item = F79D3F1F(method_7("(" + text6 + "//ancestor::*[contains(@aria-label,\"Reply by\")])[" + i + "]"), "reply_comment_id=(\\d+)&");
					list.Add(item);
				}
				method_19(text3);
				F8091028(2.0);
				if (flag)
				{
					method_20(text5);
					AE3408BC(text5, E28DC710 + " ", E01F871E: true);
					F8091028(2.0);
				}
				if (flag2 && D7A424AE(string_12))
				{
					method_24(string_12, string_11);
					method_15(60.0, new List<string>
					{
						text4 + "//img[contains(@class,\"scaledImageFit\")]",
						text4 + "//*[@aria-live=\"polite\"]"
					});
					F8091028(2.0);
				}
				method_19(d88CF43E);
				int num2 = 60;
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (!CD930D04() && !E184CD03())
					{
						if (method_30(text6) <= num)
						{
							if (!D6BBEDA3())
							{
								if (Environment.TickCount - tickCount >= num2 * 1000)
								{
									break;
								}
								F8091028(1.0);
								continue;
							}
							gClass.method_4("error", "fb_blocked");
							break;
						}
						num = method_30(text6);
						for (int j = 1; j < num + 1; j++)
						{
							string text8 = F79D3F1F(method_7("(" + text6 + "//ancestor::*[contains(@aria-label,\"Reply by\")])[" + j + "]"), "reply_comment_id=(\\d+)&");
							if (!list.Contains(text8))
							{
								gClass.method_4("commentId", text8);
								break;
							}
						}
						gClass.method_4("success", true);
						break;
					}
					gClass.method_4("error", "chrome_closed");
					break;
				}
			}
		}
		bool result;
		if (!(result = Convert.ToBoolean(gClass.method_3("success"))))
		{
			EE37E6A7 = gClass.BDB80B23("error") == "fb_blocked";
		}
		return result;
	}

	private string F79D3F1F(string C1B463B1, string ABB0483A)
	{
		return Regex.Match(C1B463B1, ABB0483A).Groups[1].Value;
	}

	internal bool method_115(int AC2C171E, int int_4, List<string> list_0)
	{
		string string_ = "[{\"name\":\"id\", \"value\":\"\", \"type\":\"text\"}" + $",{{\"name\":\"count\", \"value\":\"{AC2C171E}\", \"type\":\"number\"}}" + $",{{\"name\":\"typeInvite\", \"value\":\"{int_4}\", \"type\":\"number\"}}" + ",{\"name\":\"arrNames\", \"value\":\"" + string.Join("|", list_0) + "\", \"type\":\"text\"}]";
		string json = method_66("MoiBanBeVaoNhomWWW", string_);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	internal bool method_116(string FFA2F437, string string_10)
	{
		if (FFA2F437 == "" && string_10 == "")
		{
			return false;
		}
		FFA2F437 = FFA2F437.Replace("\r\n", "\n").Replace("\n", "\\\\n").Replace("\"", "\\\"");
		string_10 = string_10.Replace("\\", "\\\\\\\\");
		string string_11 = "[{\"name\":\"image\", \"value\":\"" + string_10 + "\", \"type\":\"text\"},{\"name\":\"content\", \"value\":\"" + FFA2F437 + "\", \"type\":\"text\"}]";
		string json = method_66("NhanTinUidWWW", string_11);
		JObject jObject = JObject.Parse(json);
		bool result;
		if (!(result = Convert.ToBoolean(jObject["success"])))
		{
			EE37E6A7 = jObject["error"]!.ToString() == "fb_blocked";
		}
		return result;
	}

	public bool method_118()
	{
		if (D7A424AE("[data-sigil$=\"m-overlay-layer\"] form button") && D7A424AE("[style=\"display: none;\"]>[data-sigil$=\"m-overlay-layer\"] form button"))
		{
			return false;
		}
		return DA2A8C96(0, "[action*=\"facebook.com/a/friends/profile/add\"] [type=\"submit\"]", "[data-sigil$=\"m-overlay-layer\"] [value=\"OK\"]", "[data-sigil$=\"m-overlay-layer\"] form button", "[data-sigil$=\"m-error-overlay-done\"]", "[data-sigil$=\"m-overlay-layer\"]", "[data-sigil$=\"m-error-overlay-cancel\"]", "[role=\"dialog\"] [aria-label^=\"Add \"]", "div[aria-label=\"OK\" i][role=\"button\"]");
	}

	public List<string> method_119(bool E317088E = false)
	{
		string propertyName = FB94939A();
		List<string> list = new List<string>();
		try
		{
			string text = method_41();
			if (!GetURL().Contains("https://www.facebook.com/api/graphql"))
			{
				method_12("https://www.facebook.com/api/graphql");
			}
			string json = method_14("async function RequestPost() { var output = ''; try { var response = await fetch('https://www.facebook.com/api/graphql', { method: 'POST', body: 'q=me(){friends}&fb_dtsg=" + text + "', headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await RequestPost(); return c;");
			JObject jObject = JObject.Parse(json);
			int num = jObject[propertyName]!["friends"]!["nodes"].Count();
			for (int i = 0; i < num; i++)
			{
				if (E317088E)
				{
					try
					{
						string text2 = jObject[propertyName]!["friends"]!["nodes"]![i]!["name"]!.ToString();
						if (Commom.D9AB3B82(text2))
						{
							list.Add(jObject[propertyName]!["friends"]!["nodes"]![i]!["name"]!.ToString());
						}
					}
					catch
					{
					}
				}
				else
				{
					list.Add(jObject[propertyName]!["friends"]!["nodes"]![i]!["name"]!.ToString());
				}
			}
		}
		catch
		{
		}
		return list;
	}

	internal void method_120()
	{
		if (D7A424AE("input[role=\"switch\"]"))
		{
			method_14("document.querySelectorAll('input[role=\"switch\"]').forEach(elm => {if (elm.checked!==true) {elm.click();}})");
		}
		method_19("(//div[@role=\"button\"])[last()]");
	}

	internal void method_121(string A3A2853C)
	{
		ProfileInfoHub.UpdateBio(this, A3A2853C);
	}

	internal bool C018519D()
	{
		if (A3A32284.Split(':').Length > 1)
		{
			string[] checkUrls = new string[]
			{
				"https://api.ipify.org",
				"https://icanhazip.com",
				"https://ifconfig.me/ip",
				"https://ifconfig.co/ip"
			};
			foreach (string url in checkUrls)
			{
				try
				{
					method_12(url);
					F8091028(1.0);
					string text = method_6("body").Trim();
					if (System.Net.IPAddress.TryParse(text, out _))
					{
						return true;
					}
					if (text.Split('.').Length == 4 || text.Split(':').Length >= 3)
					{
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}
		return true;
	}

	internal void A7B3F62B(bool EE3B6F92)
	{
		int int_ = 0;
		F32C1090(EE3B6F92, ref int_);
	}

	internal void F32C1090(bool bool_9, ref int int_4)
	{
		try
		{
			if (CD930D04() || E184CD03())
			{
				CA294803 = FE33ED1C.const_1;
				return;
			}
			method_60();
			method_59();
			if (method_122())
			{
				CA294803 = FE33ED1C.DDA575B2;
			}
			else if (method_124())
			{
				CA294803 = FE33ED1C.C2301331;
			}
			else
			{
				if ((method_61() != 1 && D7A424AE("[href=\"/\"]")) || D6BBEDA3())
				{
					return;
				}
				if (method_61() == 2 && D7A424AE("[href^=\"/a/preferences.php?fast_switch_site\"]"))
				{
					DA2A8C96(0, "[href^=\"/a/preferences.php?fast_switch_site\"]");
				}
				if (GetURL().StartsWith("https://free.facebook.com/") || D7A424AE("[href^=\"/upsell/advanced_upsell/in_line\"]"))
				{
					DA2A8C96(0, "[href^=\"/upsell/advanced_upsell/in_line\"]");
					DA2A8C96(5, "#upsell_upgrade_confirm_button");
					int_4 = 1;
				}
				string text = GetURL();
				if (text.Contains("facebook.com/error/index.php"))
				{
					method_12("https://www.facebook.com/notifications");
					F8091028(2.0);
					if (method_18("[role=\"complementary\"] [role=\"toolbar\"] [aria-pressed]|1"))
					{
						F8091028(2.0);
					}
					if (method_18("[role=\"complementary\"] [role=\"grid\"] [role=\"row\"] a|0"))
					{
						F8091028(2.0);
					}
					method_12(text);
					F8091028(2.0);
				}
				if (D7A424AE("[href^=\"/zero/optin/write/?action=cancel&page=dialtone_optin_page\"]"))
				{
					method_21("[href^=\"/zero/optin/write/?action=cancel&page=dialtone_optin_page\"]");
					DA2A8C96(5, "[action^=\"/zero/optin/write/?action=confirm&page=reconsider_optin_dialog\"] button");
					int_4 = 1;
				}
				if (D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
				{
					E11EB838("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
					if (D7A424AE("#qf_skip_dialog_skip_link", 5.0))
					{
						E11EB838("#qf_skip_dialog_skip_link");
					}
					int_4 = 1;
				}
				if (D7A424AE("[href^=\"/a/nux/wizard/nav.php?step=search&skip\"]"))
				{
					E11EB838("[href^=\"/a/nux/wizard/nav.php?step=search&skip\"]");
					int_4 = 1;
				}
				if (method_122())
				{
					CA294803 = FE33ED1C.DDA575B2;
					return;
				}
				if (C8825826())
				{
					CA294803 = FE33ED1C.C323FF1D;
					return;
				}
				string text2 = "";
				if (bool_9)
				{
					text = GetDomainFb() + "/login";
					text2 = C604C58C(text);
				}
				if (text2 == "")
				{
					text2 = AFACE5B4();
				}
				if (text2 == "-2")
				{
					CA294803 = FE33ED1C.const_1;
				}
				else if (Regex.IsMatch(text2, "login_form") || text2.Contains("/login/?next"))
				{
					if (D7A424AE("[href*=\"/login/?next\"]"))
					{
						method_18("[href*=\"/login/?next\"]");
					}
					CA294803 = FE33ED1C.DDA575B2;
				}
				else if (Regex.IsMatch(text2, "login_profile_form") || Regex.IsMatch(text2, "/login/device-based/validate-p") || Regex.IsMatch(text2, "aria-label=\"Log in\"") || Convert.ToBoolean(method_14("var kq=false;if(document.querySelector('#mErrorView')!=null && !document.querySelector('#mErrorView').getAttribute('style').includes('display:none')) kq=true;return kq+''")) || Regex.IsMatch(text2, "href=\"https://m.facebook.com/login.php") || Regex.IsMatch(text2, "href=\"https://www.facebook.com/login.php"))
				{
					CA294803 = FE33ED1C.DDA575B2;
				}
				else if (method_123())
				{
					CA294803 = FE33ED1C.const_7;
				}
				else if (method_124())
				{
					CA294803 = FE33ED1C.C2301331;
				}
				else if (text2.Contains("error-information-popup-content") || text2.Contains("suggestionsSummaryList"))
				{
					CA294803 = FE33ED1C.CDBBFE27;
				}
				return;
			}
		}
		catch
		{
		}
	}

	private bool method_122()
	{
		return RunCodeChrome("CheckFbLogout()").ToLower() == "true";
	}

	public bool method_123(string C6827C01 = "")
	{
		if (C6827C01 == "")
		{
			C6827C01 = GetURL();
		}
		List<string> f3259A2A = new List<string> { "facebook.com/confirmemail", "facebook.com/confirmation", "facebook.com/conf/strongrec/?contact=" };
		if (Commom.smethod_89(C6827C01, f3259A2A))
		{
			return true;
		}
		List<string> d = new List<string> { "[name=\"c\"]" };
		if (method_15(0.0, d) != "")
		{
			return true;
		}
		return false;
	}

	public bool method_124()
	{
		string text = GetURL();
		List<string> f3259A2A = new List<string> { 
			"facebook.com/checkpoint/828281030927956", 
			"facebook.com/checkpoint/1501092823525282", 
			"facebook.com/checkpoint/465803052217681", 
			"facebook.com/checkpoint/588324129567771", 
			"facebook.com/x/checkpoint/", 
			"facebook.com/checkpoint/block",
			"facebook.com/checkpoint/disabled",
			"/accounts/suspended"
		};
		if (Commom.smethod_89(text, f3259A2A))
		{
			return true;
		}
		if (text.Contains("/checkpoint/") && !text.Contains("/login/checkpoint") && !D7A424AE("input[name='approvals_code']") && !D7A424AE("input[autocomplete='one-time-code']"))
		{
			return true;
		}
		if (text.Contains("facebook.com/nt/screen/?params=") && text.Contains("checkpoint"))
		{
			return true;
		}
		string text2 = AFACE5B4();
		List<string> f3259A2A2 = new List<string> { 
			"verification_method", 
			"send_code", 
			"/checkpoint/dyi", 
			"facebook.com/communitystandards/", 
			"help/121104481304395", 
			"help/166863010078512", 
			"help/117450615006715", 
			"checkpoint/1501092823525282", 
			"checkpoint/828281030927956", 
			"name=\"code_1\"",
			"We suspended your account",
			"Chúng tôi đã đình chỉ tài khoản của bạn",
			"180 days left to disagree",
			"180 ngày để phản đối",
			"disagree with decision",
			"phản đối quyết định",
			"Tài khoản của bạn đã bị vô hiệu hóa",
			"Your account has been disabled"
		};
		if (Commom.smethod_89(text2, f3259A2A2))
		{
			return true;
		}
		List<string> d = new List<string> { "[name=\"verification_method\"]", "[name=\"submit[Yes]\"]", "[name=\"send_code\"]", "[href*=\"facebook.com/communitystandards/\"]", "[name=\"code_1\"]", "[action=\"/login/checkpoint/\"] [name=\"contact_index\"]" };
		if (method_15(0.0, d) != "")
		{
			return true;
		}
		return false;
	}

	public bool C8825826()
	{
		try
		{
			if (method_61() == 2 && D7A424AE("[href^=\"/a/preferences.php?fast_switch_site\"]"))
			{
				DA2A8C96(0, "[href^=\"/a/preferences.php?fast_switch_site\"]");
			}
			if (method_124())
			{
				return false;
			}
			if (method_15(0.0, new List<string> { "[action^=\"/login/\"]", "[name=\"email\"]", "[name=\"pass\"]" }) != "")
			{
				return false;
			}
			string text = GetURL();
			List<string> f3259A2A = new List<string> { "facebook.com/home.php" };
			if (Commom.smethod_89(text, f3259A2A))
			{
				return true;
			}
			string text2 = AFACE5B4();
			List<string> f3259A2A2 = new List<string> { "/friends/", "/logout.php?button_location=settings&amp;button_name=logout", "\"is_checkpointed\":false" };
			if (Commom.smethod_89(text2, f3259A2A2))
			{
				return true;
			}
			List<string> d = new List<string> { "a[href*=\"/friends/\"]", "[action=\"/logout.php?button_location=settings&button_name=logout\"]" };
			if (method_15(0.0, d) != "")
			{
				return true;
			}
			if (D7A424AE("[name=\"email\"]") && D7A424AE("[name=\"pass\"]"))
			{
				return false;
			}
			return A084051A();
		}
		catch (Exception)
		{
		}
		return false;
	}

	public int method_125(bool bool_9 = false)
	{
		int int_ = 0;
		F32C1090(bool_9, ref int_);
		if (int_ == 0)
		{
			switch (CA294803)
			{
			case FE33ED1C.const_1:
				int_ = -2;
				break;
			case FE33ED1C.DDA575B2:
			{
				string string_ = "https://www.facebook.com/";
				if (C5034B95.smethod_0("configInteractGeneral").method_2("typeBrowserLogin") == 0)
				{
					string_ = "https://m.facebook.com/";
				}
				else if (C5034B95.smethod_0("configInteractGeneral").method_2("typeBrowserLogin") == 2)
				{
					string_ = "https://m.facebook.com";
				}
				string text = method_127(-1, string_);
				if (text == "1")
				{
					CA294803 = FE33ED1C.AC3A1601;
					int_ = 1;
				}
				else
				{
					int_ = 2;
				}
				break;
			}
			case FE33ED1C.C2301331:
				int_ = -1;
				break;
			case FE33ED1C.CDBBFE27:
				int_ = -3;
				break;
			}
		}
		return int_;
	}

	public string method_126()
	{
		string text = method_15(0.0, new List<string> { "[role=\"dialog\"] [data-ad-rendering-role=\"story_message\"]", "[role=\"dialog\"] [data-ad-preview=\"message\"]", "[style*=\"max-width:\"] [dir=\"auto\"] [style*=\"-webkit-box-orient\"]" });
		if (text == "")
		{
			text = "//*[@aria-label=\"See Owner Profile\"]/ancestor::div[3]/following-sibling::div[1]//*[@dir=\"auto\"]";
		}
		switch (text)
		{
		default:
			return "";
		case "[role=\"dialog\"] [data-ad-rendering-role=\"story_message\"]":
		case "[role=\"dialog\"] [data-ad-preview=\"message\"]":
		case "[style*=\"max-width:\"] [dir=\"auto\"] [style*=\"-webkit-box-orient\"]":
		case "//*[@aria-label=\"See Owner Profile\"]/ancestor::div[3]/following-sibling::div[1]//*[@dir=\"auto\"]":
			if (D7A424AE("//*[@aria-label=\"See Owner Profile\"]/ancestor::div[3]/following-sibling::div[1]//*[@dir=\"auto\"]//*[text()=\"See more\"]"))
			{
				method_18("//*[@aria-label=\"See Owner Profile\"]/ancestor::div[3]/following-sibling::div[1]//*[@dir=\"auto\"]//*[text()=\"See more\"]");
				F8091028(2.0);
				string text2 = method_6(text);
				if (text2.EndsWith("See less", StringComparison.OrdinalIgnoreCase))
				{
					text2 = Regex.Replace(text2, "See less", "", RegexOptions.IgnoreCase);
				}
				return text2;
			}
			return method_6(text);
		}
	}

	public bool SubmitFacebookLoginForm()
	{
		try
		{
			try
			{
				string[] passSelectors = new string[] { "[name='pass']", "#pass", "input[type='password']", "#m_login_password" };
				foreach (var sel in passSelectors)
				{
					if (D7A424AE(sel))
					{
						F217FA96(sel);
						break;
					}
				}
			}
			catch { }

			F8091028(0.3);

			string script = @"
				try {
					function triggerEvents(el) {
						if (!el) return false;
						el.focus();
						['mouseover', 'mouseenter', 'mousedown', 'mouseup', 'click'].forEach(function(evtName) {
							var evt = new MouseEvent(evtName, { bubbles: true, cancelable: true, view: window });
							el.dispatchEvent(evt);
						});
						if (typeof el.click === 'function') {
							el.click();
						}
						return true;
					}

					var sels = [
						'button[name=\'login\']',
						'#loginbutton',
						'[name=\'login\']',
						'button[type=\'submit\']',
						'[data-testid=\'royal_login_button\']',
						'#m_login_button',
						'input[type=\'submit\']',
						'[aria-label=\'Đăng nhập\']',
						'[aria-label=\'Log In\']',
						'[aria-label=\'Log in\']'
					];
					for (var i = 0; i < sels.length; i++) {
						var btn = document.querySelector(sels[i]);
						if (btn && (btn.offsetWidth > 0 || btn.offsetHeight > 0 || btn.getClientRects().length > 0)) {
							triggerEvents(btn);
							return 'clicked_selector';
						}
					}

					var allBtns = document.querySelectorAll('button, div[role=\'button\'], input[type=\'submit\'], a[role=\'button\']');
					for (var j = 0; j < allBtns.length; j++) {
						var b = allBtns[j];
						var t = (b.innerText || b.value || b.getAttribute('aria-label') || '').trim().toLowerCase();
						if (t === 'đăng nhập' || t === 'log in' || t === 'login') {
							triggerEvents(b);
							return 'clicked_text';
						}
					}

					var p = document.querySelector('input[type=\'password\'], [name=\'pass\']');
					if (p && p.form) {
						p.form.submit();
						return 'submitted_form';
					}
					return 'none';
				} catch(e) {
					return 'error: ' + e.message;
				}
			";
			string res = method_14(script);
			return res != "none" && !res.StartsWith("error");
		}
		catch
		{
			return false;
		}
	}

	public bool WaitForCaptchaAndContinue(string captchaType = "FunCaptcha", int timeoutSeconds = 90)
	{
		try
		{
			OnStatusUpdate?.Invoke("Phát hiện " + captchaType + ", đang chờ giải...");
			int startWait = Environment.TickCount;
			while (!CD930D04() && !E184CD03() && (Environment.TickCount - startWait < timeoutSeconds * 1000))
			{
				if (!string.IsNullOrEmpty(FB94939A()) || (method_40().Contains("c_user=") && method_40().Contains("xs=")))
				{
					return true;
				}

				if (D7A424AE("input[name='approvals_code']") || 
					D7A424AE("input[autocomplete='one-time-code']") || 
					D7A424AE("input[data-bloks-name=\"bk.components.TextInput\"]"))
				{
					return true;
				}

				bool stillHasCaptcha = D7A424AE("#arkose-captcha") || 
									   D7A424AE("iframe[src*='arkoselabs']") || 
									   D7A424AE("iframe[src*='funcaptcha']") || 
									   D7A424AE("#captcha-recaptcha") || 
									   D7A424AE("iframe[src*='recaptcha']") ||
									   D7A424AE("#captcha_response") ||
									   D7A424AE("[src*=\"facebook.com/captcha/tfbimage\"]");

				if (D7A424AE("[src*=\"facebook.com/captcha/tfbimage\"]") || D7A424AE("#captcha_response"))
				{
					string geminiKey = GeminiVisionCaptchaHelper.GetGeminiApiKey();
					if (!string.IsNullOrEmpty(geminiKey))
					{
						string solved = GeminiVisionCaptchaHelper.SolveCaptchaOnPage(this, geminiKey);
						if (!string.IsNullOrEmpty(solved))
						{
							F8091028(1.0);
							method_14("try { var btn = document.querySelector('button[type=\"submit\"], button[id=\"checkpointSubmitButton\"], [role=\"button\"][tabindex=\"0\"]'); if(btn && !btn.disabled) btn.click(); } catch(e){}");
							F8091028(2.0);
						}
					}
				}

				if (!stillHasCaptcha)
				{
					F8091028(2.0);
					return true;
				}

				method_14("try { var btn = document.querySelector('button[type=\"submit\"], button[id=\"checkpointSubmitButton\"], [role=\"button\"][tabindex=\"0\"]'); if(btn && !btn.disabled && (btn.innerText.indexOf('Tiếp tục') >= 0 || btn.innerText.indexOf('Continue') >= 0 || btn.innerText.indexOf('Xác nhận') >= 0)) btn.click(); } catch(e){}");

				int elapsed = (Environment.TickCount - startWait) / 1000;
				int rem = timeoutSeconds - elapsed;
				if (rem >= 0 && (rem % 5 == 0 || rem == timeoutSeconds - 1))
				{
					OnStatusUpdate?.Invoke("Chờ giải " + captchaType + " (" + rem + "s)...");
				}

				F8091028(2.0);
			}
		}
		catch { }
		return false;
	}

	public bool TryLoginFacebook(string username, string password)
	{
		try
		{
			method_14("try { document.querySelectorAll('[data-cookiebanner=\"accept_button\"], [data-testid=\"cookie-policy-manage-dialog-accept-button\"], [name=\"primary_consent_button\"]').forEach(e => e.click()); } catch(e){}");

			string[] emailSelectors = new string[] { "[name='email']", "#email", "#m_login_email", "input[type='email']", "input[autocomplete='username']", "input[name='email']" };
			string[] passSelectors = new string[] { "[name='pass']", "#pass", "#m_login_password", "input[type='password']", "input[name='pass']" };

			string foundEmail = "";
			foreach (var s in emailSelectors)
			{
				if (D7A424AE(s)) { foundEmail = s; break; }
			}

			string foundPass = "";
			foreach (var s in passSelectors)
			{
				if (D7A424AE(s)) { foundPass = s; break; }
			}

			if (foundEmail != "" && foundPass != "")
			{
				string initialUrl = GetURL();

				EB2B3FB0(foundEmail);
				method_28(foundEmail, username, 0.05);
				F8091028(0.3);

				EB2B3FB0(foundPass);
				method_28(foundPass, password, 0.05);
				F8091028(0.5);

				method_14($"try {{ var e = {A7B8E3A5(foundEmail)}; if (e && (!e.value || e.value.length === 0)) {{ e.value = '{username}'; e.dispatchEvent(new Event('input', {{bubbles:true}})); e.dispatchEvent(new Event('change', {{bubbles:true}})); }} var p = {A7B8E3A5(foundPass)}; if (p && (!p.value || p.value.length === 0)) {{ p.value = '{password}'; p.dispatchEvent(new Event('input', {{bubbles:true}})); p.dispatchEvent(new Event('change', {{bubbles:true}})); }} }} catch(ex){{}}");
				F8091028(0.5);

				SubmitFacebookLoginForm();
				F8091028(1.5);

				if (GetURL() == initialUrl && method_5(foundPass) != "")
				{
					SubmitFacebookLoginForm();
					F8091028(1.5);
				}

				return true;
			}
		}
		catch { }
		return false;
	}

	public string method_127(int int_4 = -1, string string_10 = "https://www.facebook.com")
	{
		bool flag = C5034B95.smethod_0("configInteractGeneral").method_2("typeBrowserLogin") == 3;
		string f9B9EB1F = string_2;
		if (int_4 == -1)
		{
			int_4 = C5034B95.smethod_0("configInteractGeneral").method_2("typeLogin");
		}
		if (!bool_8)
		{
			string result = "";
			switch (int_4)
			{
			case 0:
				if (string_2.Trim() == "" || D8B3A7B5.Trim() == "")
				{
					if (string_2.Trim() == "")
					{
						result = Language.GetValue("Không ti\u0300m thâ\u0301y UID!");
					}
					else if (D8B3A7B5.Trim() == "")
					{
						result = Language.GetValue("Không ti\u0300m thâ\u0301y Pass!");
					}
					return result;
				}
				f9B9EB1F = string_2;
				break;
			case 1:
				if (F9B9EB1F.Trim() == "" || D8B3A7B5.Trim() == "")
				{
					if (F9B9EB1F.Trim() == "")
					{
						result = Language.GetValue("Không ti\u0300m thâ\u0301y Email!");
					}
					else if (D8B3A7B5.Trim() == "")
					{
						result = Language.GetValue("Không ti\u0300m thâ\u0301y Pass!");
					}
					return result;
				}
				f9B9EB1F = F9B9EB1F;
				break;
			case 2:
			case 3:
				if (string_4.Trim() == "")
				{
					return Language.GetValue("Không ti\u0300m thâ\u0301y Cookie!");
				}
				method_12(string_10);
				method_39(string_4);
				method_13();
				return FE31BD92().ToString();
			}
		}
		bool flag2 = C5034B95.smethod_0("configInteractGeneral").method_3("ckbDontSaveBrowser");
		string text = GetURL();
		if (text.Contains("1501092823525282") || text.Contains("828281030927956") || (text.Contains("facebook.com/nt/screen/?params=") && text.Contains("checkpoint")))
		{
			return "2";
		}
		bool flag3 = false;
		int tickCount = Environment.TickCount;
		int num = 120;
		try
		{
			if (method_61() != method_61(string_10))
			{
				method_12(string_10);
			}
			while (true)
			{
				IL_2143:
				if (!D7A424AE("[name='email']") || !D7A424AE("[name='pass']") || !D7A424AE("[name='login'],#loginbutton,div[role=\"button\"]:not([aria-label])") || D7A424AE("[data-cookiebanner=\"accept_button\"]"))
				{
					if (GetURL().Contains("facebook.com/user_cookie_prompt"))
					{
						method_12("https://www.facebook.com/");
					}
					if (D7A424AE("[name=\"accept_only_essential\"][value=\"0\"]"))
					{
						method_18("[name=\"accept_only_essential\"][value=\"0\"]");
					}
					method_14("document.querySelector('[name=\"primary_consent_button\"]').click()");
					method_14("document.querySelector('[data-cookiebanner=\"accept_button\"]').click()");
					method_14("document.querySelectorAll('[data-testid=\"cookie-policy-manage-dialog-accept-button\"]')[1].click()");
					if (!D7A424AE("[name=\"pass\"]"))
					{
						method_12(string_10.TrimEnd('/') + "/login", FC3A841F: true);
						method_14("document.querySelector('[data-cookiebanner=\"accept_button\"]').click()");
						method_14("document.querySelectorAll('[data-testid=\"cookie-policy-manage-dialog-accept-button\"]')[1].click()");
					}
				}
				if (method_61() == 1)
				{
					if (method_16(0, new string[2] { "[data-userid] [name=\"login\"]", "[data-userid]" }) && D7A424AE("[role=\"dialog\"] [name=\"pass\"]", 5.0))
					{
						F8091028(1.0);
						method_28("[role=\"dialog\"] [name=\"pass\"]", D8B3A7B5, 0.1);
						F8091028(1.0);
						method_21("[role=\"dialog\"] [name=\"login\"]");
					}
				}
				else if (!D7A424AE("[name='email']") || !D7A424AE("[name='pass']") || !D7A424AE("[name='login']"))
				{
					if (method_16(0, new string[2] { "[data-sigil=\"login_profile_form\"] div[role=\"button\"]", "[action*=\"/login/device-based/\"] [type=\"submit\"]" }))
					{
						if (method_15(5.0, new List<string> { "[name=\"pass\"]", "#approvals_code" }) == "[name=\"pass\"]")
						{
							F8091028(1.0);
							method_28("[name=\"pass\"]", D8B3A7B5, 0.1);
							F8091028(1.0);
							F217FA96("[name=\"pass\"]");
						}
					}
					else if (method_61() > 1 && D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]", 4.0))
					{
						method_18("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
					}
				}
				if (!flag3)
				{
					flag3 = TryLoginFacebook(f9B9EB1F, D8B3A7B5);
				}
				if (!flag3 && D7A424AE("[name='email']") && D7A424AE("[name='pass']") && D7A424AE("[name='login'],#loginbutton,div[role=\"button\"]:not([aria-label])"))
				{
					flag3 = true;
					string text2 = GetURL();
					EB2B3FB0("[name='email']");
					method_28("[name='email']", f9B9EB1F, 0.1);
					F8091028(1.0);
					EB2B3FB0("[name='pass']");
					method_28("[name='pass']", D8B3A7B5, 0.1);
					F8091028(1.0);
					SubmitFacebookLoginForm();
					F8091028(2.0);
					for (int i = 0; i < 10; i++)
					{
						if (GetURL() != text2)
						{
							break;
						}
						if (method_5("[name=\"pass\"]") == "")
						{
							break;
						}
						F8091028(2.0);
					}
				}
				int num2 = 0;
				int num3 = 5;
				int num4 = 0;
				int num5 = 2;
				int num6 = 0;
				int num7 = 2;
				int num8 = 0;
				for (; !CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000; F8091028(2.0))
				{
					if (!string.IsNullOrEmpty(FB94939A()) || (method_40().Contains("c_user=") && method_40().Contains("xs=")))
					{
						return "1";
					}
					string text3 = method_15(0.0, new List<string>
					{
						"[name=\"login\"],[name=\"email\"],[name=\"pass\"]", "#loginbutton", "[name=\"approvals_code\"]", "[name=\"verification_method\"]", "#checkpointSubmitButton", "#qf_skip_dialog_skip_link", "#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]", "[name=\"n\"]", "[name=\"reset_action\"]", "#checkpointBottomBar",
						"[name=\"primary_consent_button\"]", "#identify_search_text_input", "[action*=\"/login/device-based/update-nonce/\"]", "[href^=\"/a/nux/wizard/nav.php\"]", "[data-testid=\"yes_continue_button\"]", "[action^=\"/login/account_recovery/name_search/\"]", "[action^=\"/ajax/recover/initiate/?recover_method=send_email&selected_cuid\"]", "[src*=\"facebook.com/captcha/tfbimage\"]", "[data-utime] .timestampContent", "[aria-label=\"Use another profile\"]"
					});
					string text4 = text3;
					string text5 = text4;
					uint num9 = AFAE75A0.smethod_0(text5);
					if (num9 <= 2023020616)
					{
						switch (num9)
						{
						case 274197922u:
							if (text5 == "[action*=\"/login/device-based/update-nonce/\"]")
							{
								method_18("[action*=\"/login/device-based/update-nonce/\"] [type=\"submit\"]");
								continue;
							}
							break;
						case 14632705u:
							if (!(text5 == "[action^=\"/ajax/recover/initiate/?recover_method=send_email&selected_cuid\"]"))
							{
								break;
							}
							return "5";
						case 1047558992u:
							if (!(text5 == "#checkpointBottomBar"))
							{
								break;
							}
							if (num6 <= 1)
							{
								if (!(method_15(0.0, new List<string> { "[name=\"verification_method\"]", "[name=\"submit[Yes]\"]", "[name=\"send_code\"]", "#captcha_response", "[href=\"https://www.facebook.com/communitystandards/\"]" }) != "") && !Commom.smethod_89(AFACE5B4(), new List<string> { "/checkpoint/dyi", "https://www.facebook.com/communitystandards/", "help/121104481304395", "checkpoint/828281030927956" }))
								{
									text3 = method_15(0.0, new List<string> { "button#checkpointSubmitButton", "#checkpointSubmitButton [type=\"submit\"]" });
									if (num8 < 10)
									{
										if (D7A424AE("[value=\"dont_save\"]") && flag2)
										{
											method_18("[value=\"dont_save\"]");
										}
										num8++;
										if (text3 == "button#checkpointSubmitButton")
										{
											method_18(text3);
										}
										else
										{
											method_16(0, new string[3] { "#checkpointSubmitButton [type=\"submit\"]", "[name=\"submit[Get Started]\"]", "#checkpointBottomBar [name=\"submit[Continue]\"]" });
											F8091028(2.0);
											method_33("#hcs_prog_o>#hcs_prog_i[style]", 60);
										}
										F8091028(1.0);
										continue;
									}
									return "2";
								}
								return "2";
							}
							return "6";
						case 657175336u:
							if (!(text5 == "[src*=\"facebook.com/captcha/tfbimage\"]"))
							{
								break;
							}
							if (!GetURL().Contains("facebook.com/checkpoint/1501092823525282/") && !GetURL().Contains("checkpoint/828281030927956"))
							{
								string string_11 = "input[type^=\"text\"]";
								if (method_5(string_11) != "")
								{
									method_13();
									continue;
								}
								int num11 = C5034B95.smethod_0("configCheckpoint").method_2("typeCaptcha");
								string text8 = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_" + num11);
								string geminiKey = GeminiVisionCaptchaHelper.GetGeminiApiKey();

								// Ưu tiên thử giải trực tiếp trên trang bằng Gemini Vision AI nếu chọn cấu hình 9 hoặc có Gemini Key
								if (num11 == 9 || !string.IsNullOrEmpty(geminiKey))
								{
									string solved = GeminiVisionCaptchaHelper.SolveCaptchaOnPage(this, string.IsNullOrEmpty(text8) ? geminiKey : text8);
									if (!string.IsNullOrEmpty(solved))
									{
										F8091028(1.0);
										method_62();
										method_16(0, new string[2] { "[role=\"button\"]>[role=\"none\"]", "[role=\"button\"]>[style*=\"justify-content\"]" });
										F8091028(3.0);
										method_64(() => !D7A424AE("[aria-label$=\"...\"]") || method_63(0), 30);
										continue;
									}
								}

								if (!(text8 == "") || !string.IsNullOrEmpty(geminiKey) || DB81C53D.smethod_2(C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4")))
								{
									string value = Regex.Match(AFACE5B4(), "src=\"(https://(?:[a-z]+)\\.facebook\\.com/captcha/tfbimage.*?)\"").Groups[1].Value;
									if (!(value == ""))
									{
										string text9 = Commom.A794F28D(method_40(), value);
										if (text9 == "")
										{
											method_13();
											continue;
										}
										string text10 = GClass2.smethod_1(num11, text8, text9);
										if (text10 == "")
										{
											method_13();
											continue;
										}
										method_22(string_11, text10);
										F8091028(1.0);
										method_62();
										method_16(0, new string[2] { "[role=\"button\"]>[role=\"none\"]", "[role=\"button\"]>[style*=\"justify-content\"]" });
										F8091028(3.0);
										method_64(() => !D7A424AE("[aria-label$=\"...\"]") || method_63(0), 30);
										continue;
									}
									return "captcha";
								}
								bool resolvedImg = WaitForCaptchaAndContinue("Captcha hình ảnh", 60);
								if (resolvedImg)
								{
									continue;
								}
								return "captcha";
							}
							return "2";
						case 426848336u:
							if (!(text5 == "#checkpointSubmitButton"))
							{
								break;
							}
							if (D7A424AE("[name=\"checkpointU2Fauth\"]"))
							{
								method_12("https://www.facebook.com/checkpoint/?next&no_fido=true");
								continue;
							}
							if (!(method_15(0.0, new List<string> { "#SupportFormRow\\\\.382907505152522", "[href=\"/help/117450615006715\"]" }) != ""))
							{
								num2++;
								if (num2 < num3)
								{
									if (D7A424AE("[value=\"dont_save\"]") && flag2)
									{
										method_18("[value=\"dont_save\"]");
									}
									string text7 = "";
									if (D7A424AE("[name=\"password_new\"]"))
									{
										text7 = Commom.smethod_77();
										method_22("[name=\"password_new\"]", text7);
										F8091028(1.0);
										method_22("[name=\"password_confirm\"]", text7);
										F8091028(1.0);
									}
									if (D7A424AE("[name=\"submit[Confirm identity another way]\"]"))
									{
										method_18("[name=\"submit[Confirm identity another way]\"]");
									}
									else if (D7A424AE("#checkpointSubmitButton>input"))
									{
										method_21("#checkpointSubmitButton>input");
									}
									else if (D7A424AE("button[name=\"submit[Done]\"]"))
									{
										method_21("button[name=\"submit[Done]\"]");
									}
									else if (D7A424AE("button[name=\"submit[Delete]\"]"))
									{
										method_21("button[name=\"submit[Delete]\"]");
									}
									else if (D7A424AE("#checkpointSubmitButton>button"))
									{
										if (!D7A424AE("[action=\"/login/checkpoint/\"]") || !D7A424AE("[name=\"send_code\"]"))
										{
										}
										method_21("#checkpointSubmitButton>button");
										F8091028(2.0);
										method_33("#checkpointSubmitButton>button [role=\"progressbar\"]", 30);
									}
									else
									{
										if (D7A424AE("button[name=\"submit[This was me]\"]"))
										{
											num2--;
											num4++;
											if (num4 <= num5)
											{
												method_18("button[name=\"submit[This was me]\"]");
											}
											else
											{
												method_18("button[name=\"submit[This wasn't me]\"]");
											}
										}
										else
										{
											method_21("#checkpointSubmitButton");
										}
										F8091028(2.0);
										method_33("#checkpointSubmitButton[disabled]", 30);
									}
									F8091028(1.0);
									if (!GetURL().Contains("facebook.com/secured_action/block/") && text7 != "")
									{
										fMain.fMain_0.F0A81525(string_1, "pass", int_1, "cPassword", text7);
										C234EEAA = text7;
									}
									continue;
								}
								return "2";
							}
							return "2";
						case 1563265681u:
							if (text5 == "#qf_skip_dialog_skip_link")
							{
								if (!E11EB838("#qf_skip_dialog_skip_link"))
								{
									method_14("document.getElementById('qf_skip_dialog_skip_link').click()");
								}
								F8091028(2.0);
								continue;
							}
							break;
						case 1060476925u:
							if (!(text5 == "[name=\"n\"]"))
							{
								break;
							}
							return "5";
						case 2023020616u:
							if (!(text5 == "#identify_search_text_input"))
							{
								break;
							}
							goto IL_20d1;
						case 1971552943u:
							if (text5 == "[name=\"primary_consent_button\"]")
							{
								int num10 = method_30("[name=\"primary_consent_button\"]");
								method_18("[name=\"primary_consent_button\"]|" + (num10 - 1));
								continue;
							}
							break;
						case 1679731735u:
							if (text5 == "[data-utime] .timestampContent")
							{
								string text6 = method_6(".uiInterstitialContent>p:has([data-utime] .timestampContent)");
								if (!(text6 != ""))
								{
									continue;
								}
								return text6;
							}
							break;
						}
					}
					else if (num9 <= 2739289613u)
					{
						if (num9 <= 2427656247u)
						{
							switch (num9)
							{
							case 2427656247u:
								if (!(text5 == "[name=\"approvals_code\"]"))
								{
									break;
								}
								if (!(string_3 == ""))
								{
									if (num6 < num7)
									{
										if (flag)
										{
											method_12(GetURL().Replace("www.face", "m.face"));
											for (int j = 0; j < 10; j++)
											{
												if (D7A424AE("[name=\"approvals_code\"]"))
												{
													break;
												}
												if (CD930D04())
												{
													break;
												}
												if (E184CD03())
												{
													break;
												}
												F8091028(1.0);
											}
										}
										string text11 = Commom.smethod_62(string_3.Replace(" ", "").Replace("\n", "").Trim());
										if (!(text11 == ""))
										{
											num6++;
											EB2B3FB0("[name='approvals_code']");
											method_22("[name='approvals_code']", text11);
											F8091028(1.0);
											F217FA96("[name='approvals_code']");
											F8091028(1.0);
											continue;
										}
										return "6";
									}
									return "6";
								}
								return "3";
							case 2077551060u:
								if (text5 == "[action^=\"/login/account_recovery/name_search/\"]")
								{
									method_22(text3 + " [name=\"pass\"]", D8B3A7B5);
									F8091028(1.0);
									method_18("[data-testid=\"conf_login_button\"]");
									continue;
								}
								break;
							}
						}
						else if (num9 != 2433247304u)
						{
							if (num9 != 2617566843u)
							{
								if (num9 == 2739289613u && text5 == "[name=\"reset_action\"]")
								{
									goto IL_120a;
								}
							}
							else if (text5 == "[href^=\"/a/nux/wizard/nav.php\"]")
							{
								method_18(text3);
								F8091028(2.0);
								continue;
							}
						}
						else if (text5 == "#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]")
						{
							method_18("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
							F8091028(2.0);
							continue;
						}
					}
					else if (num9 <= 3098163882u)
					{
						if (num9 != 2833087881u)
						{
							if (num9 == 3098163882u && text5 == "[name=\"verification_method\"]")
							{
								return "2";
							}
						}
						else if (text5 == "[name=\"login\"],[name=\"email\"],[name=\"pass\"]")
						{
							goto IL_120a;
						}
					}
					else
					{
						switch (num9)
						{
						case 4094933479u:
						{
							if (!(text5 == "#loginbutton"))
							{
								break;
							}
							string text12 = GetURL();
							if (D7A424AE("[name='email']"))
							{
								EB2B3FB0("[name='email']");
								method_28("[name='email']", f9B9EB1F, 0.1);
								F8091028(1.0);
							}
							if (D7A424AE("[name='pass']"))
							{
								EB2B3FB0("[name='pass']");
								method_28("[name='pass']", D8B3A7B5, 0.1);
								F8091028(1.0);
							}
							SubmitFacebookLoginForm();
							F8091028(2.0);
							for (int k = 0; k < 10; k++)
							{
								if (GetURL() != text12)
								{
									break;
								}
								if (method_5("[name=\"pass\"]") == "")
								{
									break;
								}
								if (CD930D04())
								{
									break;
								}
								if (E184CD03())
								{
									break;
								}
								F8091028(2.0);
							}
							continue;
						}
						case 4081019825u:
							if (text5 == "[aria-label=\"Use another profile\"]")
							{
								method_18(text3);
								continue;
							}
							break;
						case 3529631106u:
							if (text5 == "[data-testid=\"yes_continue_button\"]")
							{
								method_18(text3);
								continue;
							}
							break;
						}
					}
					goto IL_1710;
					IL_20d1:
					method_12("https://www.facebook.com/login");
					F8091028(1.0);
					string_10 = "https://www.facebook.com";
					goto IL_2143;
					IL_120a:
					if (!GetURL().Contains("facebook.com/auth_platform/"))
					{
						if (num6 == 0 && num8 == 0)
						{
							if (!flag3 || GetURL().Contains("facebook.com/login/web/?email="))
							{
								flag3 = true;
								method_62();
								if (D7A424AE("[name='email']"))
								{
									EB2B3FB0("[name='email']");
									method_28("[name='email']", f9B9EB1F, 0.1);
									F8091028(1.0);
								}
								if (D7A424AE("[name='pass']"))
								{
									EB2B3FB0("[name='pass']");
									method_28("[name='pass']", D8B3A7B5, 0.1);
									F8091028(1.0);
								}
								SubmitFacebookLoginForm();
								F8091028(2.0);
								for (int l = 0; l < 10; l++)
								{
									if (method_63(0))
									{
										break;
									}
									if (method_5("[name=\"pass\"]") == "")
									{
										break;
									}
									if (D7A424AE("[href*=\"/login/identify/\"]"))
									{
										break;
									}
									F8091028(2.0);
								}
								continue;
							}
							string text13 = "";
							switch (method_61())
							{
							case 2:
							case 3:
								text13 = method_14("var out='';var x=document.querySelector('#login_error');if(x!=null) out=x.innerText;return out;").ToString();
								break;
							case 1:
								text13 = method_6("#error_box").Replace("\r\n", "\n");
								text13 = ((text13.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Count() > 1) ? text13.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim() : text13);
								break;
							}
							if (text13 != "")
							{
								return text13;
							}
							if (D7A424AE("[href*=\"/login/identify/\"]"))
							{
								return "4";
							}
							if (D7A424AE("#account_recovery_initiate_view_label"))
							{
								return "5";
							}
							if (method_61() == 1 || method_61() == 3)
							{
								if (D7A424AE("[name=\"email\"]") && method_5("[name=\"email\"]") == "")
								{
									return "4";
								}
								if (D7A424AE("[name=\"pass\"]") && method_5("[name=\"pass\"]") == "")
								{
									return "5";
								}
							}
						}
						else
						{
							if (!string.IsNullOrEmpty(FB94939A()) || method_40().Contains("c_user="))
							{
								return "1";
							}
							if (method_5("[name=\"email\"]") == "")
							{
								if (C8825826())
								{
									return "1";
								}
								return "0";
							}
							if (D7A424AE("#checkpointButtonGotoNewsFeed"))
							{
								method_18("#checkpointButtonGotoNewsFeed");
							}
						}
						continue;
					}
					goto IL_1710;
					IL_1710:
					text = GetURL();
					if (text.Contains("?rcs="))
					{
						if (D7A424AE("[aria-label=\"Remove profiles from this browser\"]") && D7A424AE("[aria-label=\"Continue\"]") && D7A424AE("[aria-label=\"Use another profile\"]"))
						{
							method_18("[aria-label=\"Continue\"]");
							continue;
						}
						text += "&locale=en_US";
						method_12(text);
						continue;
					}
					if (!text.Contains("facebook.com/secured_action/block/"))
					{
						if (!text.Contains("checkpoint/disabled"))
						{
							if (text.Contains("facebook.com/checkpoint/465803052217681"))
							{
								if (method_61() == 1)
								{
									method_53();
									bool flag4 = method_128();
									method_54();
									if (flag4)
									{
										continue;
									}
									return "2";
								}
								return "2";
							}
							if (text.Contains("facebook.com/checkpoint/588324129567771"))
							{
								if (method_61() == 1)
								{
									method_53();
									bool flag5 = method_130();
									method_54();
									if (flag5)
									{
										continue;
									}
									return "2";
								}
								return "2";
							}
							if (text.Contains("facebook.com/two_step_verification/two_factor/"))
							{
								string text14 = "input[type=\"text\"]";
								if (D7A424AE(text14))
								{
									if (string_3 == "")
									{
										return "3";
									}
									if (num6 >= num7)
									{
										return "6";
									}
									string text15 = Commom.smethod_62(string_3.Replace(" ", "").Replace("\n", "").Trim());
									if (text15 == "")
									{
										return "6";
									}
									num6++;
									method_29(text14);
									method_22(text14, text15);
									F8091028(1.0);
									F217FA96(text14);
									F8091028(3.0);
									method_33("svg[aria-label$=\"...\"]", 30);
								}
								else if (D7A424AE("[role=\"dialog\"]"))
								{
									method_19("//label[not(.//*[contains(text(),\"*\")])]//input[@type=\"radio\"][@aria-checked=\"false\"]");
									F8091028(1.0);
									method_19("[role=\"dialog\"] [role=\"button\"]|" + (method_30("[role=\"dialog\"] [role=\"button\"]") - 1));
								}
								else
								{
									method_19("[role=\"button\"]");
								}
								continue;
							}
							if (text.Contains("facebook.com/auth_platform/"))
							{
								if (text.Contains("login_with_third_party"))
								{
									try
									{
										method_12("https://m.facebook.com/login/checkpoint/");
										F8091028(2.0);
										text = GetURL();
										if (!text.Contains("login_with_third_party"))
										{
											continue;
										}
									}
									catch { }
								}
								if (method_61() == 1)
								{
									method_53();
									bool flag6 = method_129();
									method_54();
									if (flag6)
									{
										tickCount = Environment.TickCount;
										continue;
									}
									return "2";
								}
								return "2";
							}
							if (text.Contains("facebook.com/two_factor/remember_browser/"))
							{
								if (D7A424AE("[role=\"dialog\"] [role=\"button\"][aria-label=\"[object Object]\"]"))
								{
									method_19("[role=\"dialog\"] [role=\"button\"][aria-label=\"[object Object]\"]");
									F8091028(2.0);
								}
								else if (D7A424AE("[role=\"dialog\"] [aria-label]"))
								{
									method_18("[role=\"dialog\"] [role=\"button\"]");
									F8091028(2.0);
								}
								else
								{
									method_14("HTMLInputElement.prototype.click = function() { if(this.type != 'file') HTMLElement.prototype.click.call(this); };");
									method_19("div[role=\"button\"]|" + (method_30("div[role=\"button\"]") - 2));
								}
								continue;
							}
							if (!text.Contains("facebook.com/checkpoint/1501092823525282/") && !text.Contains("checkpoint/828281030927956"))
							{
								if (text.Contains("facebook.com/user_cookie_prompt"))
								{
									method_12("https://www.facebook.com/");
									continue;
								}
								if (text.Contains("facebook.com/two_step_verification/authentication/"))
								{
									if (method_61(text) == 2)
									{
										string text16 = "input[data-bloks-name=\"bk.components.TextInput\"]";
										if (D7A424AE(text16))
										{
											if (string_3 == "")
											{
												return "3";
											}
											if (num6 >= num7)
											{
												return "6";
											}
											string text17 = Commom.smethod_62(string_3.Replace(" ", "").Replace("\n", "").Trim());
											if (text17 == "")
											{
												return "6";
											}
											num6++;
											method_29(text16);
											method_22(text16, text17);
											F8091028(1.0);
											method_18("[role=\"button\"]>[style*=\"justify-content\"]");
											F8091028(3.0);
											method_33("[aria-label$=\"...\"]", 30);
										}
										else
										{
											method_12("https://m.facebook.com/");
											flag3 = false;
										}
									}
									else
									{
										string text18 = method_15(0.0, new List<string> { "#arkose-captcha", "#captcha-recaptcha" });
										bool isArkose = (text18 == "#arkose-captcha" || D7A424AE("iframe[src*='arkoselabs']") || D7A424AE("iframe[src*='funcaptcha']"));
										bool isRecaptcha = (text18 == "#captcha-recaptcha" || D7A424AE("iframe[src*='recaptcha']"));

										if (isArkose || isRecaptcha)
										{
											string capName = isArkose ? "FunCaptcha" : "ReCaptcha";
											bool resolved = WaitForCaptchaAndContinue(capName, 120);
											if (!resolved)
											{
												if (isArkose)
												{
													return "funcaptcha";
												}
												return "recaptcha";
											}
										}
										string otpSelector = "";
										if (D7A424AE("input[name='approvals_code']")) otpSelector = "input[name='approvals_code']";
										else if (D7A424AE("input[autocomplete='one-time-code']")) otpSelector = "input[autocomplete='one-time-code']";
										else if (D7A424AE("input[type='text']") && !D7A424AE("#arkose-captcha")) otpSelector = "input[type='text']";

										if (string.IsNullOrEmpty(otpSelector) && !string.IsNullOrEmpty(string_3))
										{
											try
											{
												bool clickedTryAnother = Convert.ToBoolean(method_14(@"
													(() => {
														var els = Array.from(document.querySelectorAll('a, button, div[role=""button""], span'));
														for (var el of els) {
															var t = (el.innerText || el.getAttribute('aria-label') || '').toLowerCase().trim();
															if (t === 'thử cách khác' || t === 'try another way' || t === 'need another way to authenticate?' || t.includes('cách khác') || t.includes('another way')) {
																el.click();
																return true;
															}
														}
														return false;
													})()
												"));
												if (clickedTryAnother)
												{
													F8091028(2.0);
													method_14(@"
														(() => {
															var items = Array.from(document.querySelectorAll('label, div[role=""radio""], div[role=""button""], span'));
															for (var it of items) {
																var t = (it.innerText || '').toLowerCase();
																if (t.includes('ứng dụng xác thực') || t.includes('authentication app') || t.includes('authenticator app')) {
																	it.click();
																	break;
																}
															}
															setTimeout(() => {
																var btns = Array.from(document.querySelectorAll('button, div[role=""button""]'));
																for (var b of btns) {
																	var bt = (b.innerText || b.getAttribute('aria-label') || '').toLowerCase().trim();
																	if (bt === 'tiếp tục' || bt === 'continue') {
																		b.click();
																		break;
																	}
																}
															}, 500);
														})()
													");
													F8091028(2.5);
													if (D7A424AE("input[name='approvals_code']")) otpSelector = "input[name='approvals_code']";
													else if (D7A424AE("input[autocomplete='one-time-code']")) otpSelector = "input[autocomplete='one-time-code']";
												}
											}
											catch { }
										}

										if (otpSelector != "" && !string.IsNullOrEmpty(string_3))
										{
											OnStatusUpdate?.Invoke("Đang tự động nhập mã 2FA...");
											string otpCode = Commom.smethod_62(string_3.Replace(" ", "").Replace("\n", "").Trim());
											if (otpCode != "")
											{
												num6++;
												method_29(otpSelector);
												method_22(otpSelector, otpCode);
												F8091028(1.0);
												if (D7A424AE("button[id='checkpointSubmitButton']")) method_19("button[id='checkpointSubmitButton']");
												else if (D7A424AE("button[name='submit[Continue]']")) method_19("button[name='submit[Continue]']");
												else if (D7A424AE("button[type='submit']")) method_19("button[type='submit']");
												else F217FA96(otpSelector);
												SubmitFacebookLoginForm();
												F8091028(3.0);
											}
										}
									}
									continue;
								}
								if (!method_123(text))
								{
									if (!text.Contains("facebook.com/nt/screen/?params=%7B%22token") && !(method_15(0.0, new List<string> { "[name=\"verification_method\"]", "[name=\"submit[Yes]\"]", "[name=\"send_code\"]", "#captcha_response", "[href=\"https://www.facebook.com/communitystandards/\"]" }) != "") && !Commom.smethod_89(AFACE5B4(), new List<string> { "/checkpoint/dyi", "https://www.facebook.com/communitystandards/", "help/121104481304395" }))
									{
										if (!(method_15(0.0, new List<string> { "[href=\"/help/103873106370583\"]", "[href=\"/help/121104481304395\"]" }) != ""))
										{
											if (!D6BBEDA3())
											{
												if (method_61(text) == 1 && text.Contains(".facebook.com/privacy/consent/"))
												{
													method_120();
												}
												else
												{
													if (method_59())
													{
														continue;
													}
													string text19 = method_14("async function checkCookie(){try{let a=await fetch(\"https://www.facebook.com/me\"),b=\"0|0\";if(a.ok){if(a.url.includes(\"checkpoint\"))b=\"0|1\";else if(a.url.includes(\"com/?refsrc\")||\"https://www.facebook.com/\"==a.url)b=\"0|2\";else{let d=await a.text();if(d.includes(\"/photos/change/profile_picture\"))b=\"1|1\";else{let e=d.match(/\"USER_ID\"\\:\"([0-9]{0,})\"/)[1],f=document.cookie.match(/c_user\\=([0-9]{0,})/)[1];e==f&&(b=\"1|1\")}}}return b}catch{}}var c=await checkCookie(); return c") ?? "";
													if (text19.ToString().StartsWith("0|"))
													{
														return "2";
													}
													if (D7A424AE("[href=\"/\"]") && text.Contains("facebook.com/privacy/consent_framework/prompt/"))
													{
														method_12("https://www.facebook.com/");
														continue;
													}
													if (C8825826())
													{
														return "1";
													}
													if (method_61(text) == 2)
													{
														if (text.StartsWith("https://m.facebook.com/zero/policy/optin") || text.StartsWith("https://mobile.facebook.com/zero/policy/optin"))
														{
															F8091028(1.0);
															method_14("document.querySelector('a[data-sigil=\"touchable\"]').click()");
															F8091028(3.0);
															if (D7A424AE("button[data-sigil=\"touchable\"]", 10.0))
															{
																F8091028(1.0);
																method_14("document.querySelector('button[data-sigil=\"touchable\"]').click()");
																F8091028(3.0);
															}
														}
														if (Convert.ToBoolean(method_14("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
														{
															for (int m = 0; m < 5; m++)
															{
																Commom.smethod_52(2.0);
																if (!Convert.ToBoolean(method_14("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
																{
																	break;
																}
															}
															for (int n = 0; n < 5; n++)
															{
																Commom.smethod_52(2.0);
																if (!Convert.ToBoolean(method_14("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('consent/basic/log')){x[i].click();break;check='true'}} return check")))
																{
																	break;
																}
															}
															if (D7A424AE("[href=\"/home.php\"]"))
															{
																method_18("[href=\"/home.php\"]");
															}
														}
														if (text.Contains("facebook.com/legal_consent"))
														{
															method_14("document.querySelector('button').click()");
															F8091028(1.0);
															method_14("document.querySelectorAll('button')[1].click()");
															F8091028(1.0);
															method_14("document.querySelector('button').click()");
															F8091028(1.0);
															method_14("document.querySelectorAll('button')[1].click()");
															F8091028(1.0);
														}
														if (text.Contains("facebook.com/si/actor_experience/actor_gateway"))
														{
															method_18("[data-sigil=\"touchable\"]");
															F8091028(1.0);
														}
														if (D7A424AE("button[value=\"OK\"]"))
														{
															method_18("button[value=\"OK\"]");
															F8091028(1.0);
														}
														if (D7A424AE("[data-store-id=\"2\"]>span"))
														{
															method_18("[data-store-id=\"2\"]>span");
															F8091028(1.0);
														}
														if (D7A424AE("[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span"))
														{
															method_18("[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span");
															F8091028(3.0);
														}
													}
													else
													{
														if (!text.StartsWith("https://www.facebook.com/legal_consent"))
														{
															continue;
														}
														for (int num12 = 0; num12 < 5; num12++)
														{
															if (!D7A424AE("button"))
															{
																break;
															}
															method_21("button");
															F8091028(1.0);
														}
													}
												}
												continue;
											}
											return "9";
										}
										return "vhh";
									}
									return "2";
								}
								return "8";
							}
							return "2";
						}
						return "vhh";
					}
					return "21";
				}
				if (!string.IsNullOrEmpty(FB94939A()) || method_40().Contains("c_user=") || C8825826())
				{
					return "1";
				}
				break;
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(this, exception_, "Error Login Uid Pass");
		}
		if (!string.IsNullOrEmpty(FB94939A()) || method_40().Contains("c_user=") || C8825826())
		{
			return "1";
		}
		return "0";
	}

	public bool method_128()
	{
		int num = 0;
		int num2 = 3;
		string text = "";
		bool result = false;
		int tickCount = Environment.TickCount;
		int num3 = 120;
		string text2 = Commom.smethod_50("CmZ1bmN0aW9uIGdldEVtYWlscyh0ZXh0KSB7CiAgICB2YXIgYXJyRW1haWxzID0gdGV4dC5tYXRjaCgvXGJbYS16QS1aMC05Kl0rQFthLXpBLVowLTkqLi1dK1wuW2EtekEtWl17Mix9XGIvZykgfHwgW107CiAgICBpZiAoYXJyRW1haWxzLmxlbmd0aCA9PT0gMCkKICAgICAgICBhcnJFbWFpbHMgPSB0ZXh0Lm1hdGNoKC9cYlthLXpBLVpdXCorKFthLXpBLVowLTkuXyUrLV0rKT9AW0EtWmEtejAtOS4tXStcLltBLVp8YS16XXsyLH1cYi9nKSB8fCBbXTsKICAgIGFyckVtYWlscyA9IGFyckVtYWlscy5maWx0ZXIoKGl0ZW0sIGluZGV4KSA9PiBhcnJFbWFpbHMuaW5kZXhPZihpdGVtKSA9PT0gaW5kZXgpOwogICAgcmV0dXJuIGFyckVtYWlsczsKfQoKCmZ1bmN0aW9uIGNvbXBhcmVFbWFpbHMoZW1haWwsIGFyckVtYWlscykgewogICAgZm9yICh2YXIgaiA9IDA7IGogPCBhcnJFbWFpbHMubGVuZ3RoOyBqKyspIHsKICAgICAgICB2YXIgdGVtcCA9IGFyckVtYWlsc1tqXTsKICAgICAgICBpZiAoZW1haWwuc3Vic3RyaW5nKGVtYWlsLmluZGV4T2YoJ0AnKSAtIDEsIGVtYWlsLmluZGV4T2YoJ0AnKSArIDEpID09PSB0ZW1wLnN1YnN0cmluZyh0ZW1wLmluZGV4T2YoJ0AnKSAtIDEsIHRlbXAuaW5kZXhPZignQCcpICsgMSkpIHsKICAgICAgICAgICAgcmV0dXJuIHRydWU7CiAgICAgICAgfQogICAgfQogICAgcmV0dXJuIGZhbHNlOwp9Ow==");
		while (GetURL().Contains("facebook.com/checkpoint/465803052217681"))
		{
			string text3 = method_15(0.0, new List<string> { "form input[type=\"text\"]", "[role=\"dialog\"] div>label", "[role=\"button\"]>[role=\"none\"]" });
			switch (text3)
			{
			case "form input[type=\"text\"]":
				if (method_5(text3) != "" && !D7A424AE("form div span"))
				{
					break;
				}
				if (!("false" == method_14(text2 + ";var email = \"" + F9B9EB1F.ToLower() + "\"; var isSuccess = false; var arrEmails = getEmails(document.documentElement.innerText); for (var j = 0; j < arrEmails.length; j++) { var temp = arrEmails[j]; if (compareEmails(email, arrEmails)) { isSuccess = true; break; }}; return isSuccess;").ToString().ToLower()))
				{
					F8091028(3.0);
					num++;
					if (num < num2)
					{
						string text4 = FB93BDA4.GetOtpFromMail(1, F9B9EB1F, BFAF968B, EB853E81, B6B71C81, 60, "", text);
						if (!(text4 == "fail"))
						{
							if (text4 == "")
							{
								method_17("span div[role=\"button\"]");
							}
							else if (Commom.smethod_45(text4))
							{
								text = text4;
								if (method_5(text3) != "")
								{
									method_18(text3);
									method_18("//form//input[@type=\"text\"]/parent::*//*[@role=\"button\"]");
								}
								method_22(text3, text4);
								F217FA96(text3);
								result = true;
							}
							break;
						}
						return false;
					}
					return false;
				}
				return false;
			case "[role=\"dialog\"] div>label":
				if (!(F9B9EB1F == ""))
				{
					if (!("false" == method_14(text2 + "; var isSuccess = false; var email = \"" + F9B9EB1F + "\"; var labels = document.querySelectorAll('[role=\"dialog\"] div>label'); for (let i = 0; i < labels.length; i++) { var e = labels[i]; var text = e.innerText; if (!text.includes('@')) continue; var arrEmails = getEmails(text); if (arrEmails.length == 0) continue; for (var j = 0; j < arrEmails.length; j++) { var temp = arrEmails[j]; if (compareEmails(email, arrEmails)) { e.click(); isSuccess = true; break; } } if (isSuccess) break; } return isSuccess;").ToString().ToLower()))
					{
						text = FB93BDA4.GetOtpFromMail(1, F9B9EB1F, BFAF968B, EB853E81, B6B71C81, 0, "", "");
						if (!(text == "fail"))
						{
							method_21("[role=\"dialog\"] [role=\"none\"]>[role=\"none\"]");
							break;
						}
						return false;
					}
					return false;
				}
				return false;
			case "[role=\"button\"]>[role=\"none\"]":
				method_18(text3);
				break;
			}
			if (Environment.TickCount - tickCount > num3 * 1000)
			{
				break;
			}
			F8091028(1.0);
		}
		return result;
	}

	public bool method_129()
	{
		int num = 0;
		int num2 = 3;
		string text = "";
		bool result = false;
		string text2 = Commom.smethod_50("CmZ1bmN0aW9uIGdldEVtYWlscyh0ZXh0KSB7CiAgICB2YXIgYXJyRW1haWxzID0gdGV4dC5tYXRjaCgvXGJbYS16QS1aMC05Kl0rQFthLXpBLVowLTkqLi1dK1wuW2EtekEtWl17Mix9XGIvZykgfHwgW107CiAgICBpZiAoYXJyRW1haWxzLmxlbmd0aCA9PT0gMCkKICAgICAgICBhcnJFbWFpbHMgPSB0ZXh0Lm1hdGNoKC9cYlthLXpBLVpdXCorKFthLXpBLVowLTkuXyUrLV0rKT9AW0EtWmEtejAtOS4tXStcLltBLVp8YS16XXsyLH1cYi9nKSB8fCBbXTsKICAgIGFyckVtYWlscyA9IGFyckVtYWlscy5maWx0ZXIoKGl0ZW0sIGluZGV4KSA9PiBhcnJFbWFpbHMuaW5kZXhPZihpdGVtKSA9PT0gaW5kZXgpOwogICAgcmV0dXJuIGFyckVtYWlsczsKfQoKCmZ1bmN0aW9uIGNvbXBhcmVFbWFpbHMoZW1haWwsIGFyckVtYWlscykgewogICAgZm9yICh2YXIgaiA9IDA7IGogPCBhcnJFbWFpbHMubGVuZ3RoOyBqKyspIHsKICAgICAgICB2YXIgdGVtcCA9IGFyckVtYWlsc1tqXTsKICAgICAgICBpZiAoZW1haWwuc3Vic3RyaW5nKGVtYWlsLmluZGV4T2YoJ0AnKSAtIDEsIGVtYWlsLmluZGV4T2YoJ0AnKSArIDEpID09PSB0ZW1wLnN1YnN0cmluZyh0ZW1wLmluZGV4T2YoJ0AnKSAtIDEsIHRlbXAuaW5kZXhPZignQCcpICsgMSkpIHsKICAgICAgICAgICAgcmV0dXJuIHRydWU7CiAgICAgICAgfQogICAgfQogICAgcmV0dXJuIGZhbHNlOwp9Ow==");
		List<string> list = new List<string>();
		int tickCount = Environment.TickCount;
		int num3 = 300;
		while (GetURL().Contains("facebook.com/auth_platform/") && !CD930D04() && !E184CD03() && Environment.TickCount - tickCount <= num3 * 1000)
		{
			string text3 = method_15(0.0, new List<string> { "//form//input[@type=\"text\"]", "//div/label", "//*[@role=\"button\"]/*[@role=\"none\"]" });
			list.Add(text3);
			if (list.Distinct().Count() == 1 && list.Count >= 4)
			{
				break;
			}
			switch (text3)
			{
			case "//*[@role=\"button\"]/*[@role=\"none\"]":
				method_17("(" + text3 + ")[last()]");
				break;
			case "//div/label":
				if (!(F9B9EB1F == ""))
				{
					if (!("false" == method_14(text2 + "; var isSuccess = false; var email = \"" + F9B9EB1F + "\"; var labels = document.querySelectorAll('div>label'); for (let i = 0; i < labels.length; i++) { var e = labels[i]; var text = e.innerText; if (!text.includes('@')) continue; var arrEmails = getEmails(text); if (arrEmails.length == 0) continue; for (var j = 0; j < arrEmails.length; j++) { var temp = arrEmails[j]; if (compareEmails(email, arrEmails)) { e.click(); isSuccess = true; break; } } if (isSuccess) break; } return isSuccess;").ToString().ToLower()))
					{
						text = FB93BDA4.GetOtpFromMail(1, F9B9EB1F, BFAF968B, EB853E81, B6B71C81, 0, "", "");
						if (!(text == "fail"))
						{
							method_17("(//*[@role=\"button\"]/*[@role=\"none\"])[last()]");
							F8091028(2.0);
							D7A424AE("//form//input[@type=\"text\"]", 10.0);
							break;
						}
						return false;
					}
					return false;
				}
				return false;
			case "//form//input[@type=\"text\"]":
				if ((method_5(text3) != "" && !D7A424AE("form div span")) || method_14(text2 + ";return getEmails(document.documentElement.innerText);").ToString() == "")
				{
					break;
				}
				if (!("false" == method_14(text2 + ";var email = \"" + F9B9EB1F.ToLower() + "\"; var isSuccess = false; var arrEmails = getEmails(document.documentElement.innerText); for (var j = 0; j < arrEmails.length; j++) { var temp = arrEmails[j]; if (compareEmails(email, arrEmails)) { isSuccess = true; break; }}; return isSuccess;").ToString().ToLower()))
				{
					F8091028(3.0);
					num++;
					if (num < num2)
					{
						string text4 = FB93BDA4.GetOtpFromMail(1, F9B9EB1F, BFAF968B, EB853E81, B6B71C81, 60, "", text);
						if (!(text4 == "fail"))
						{
							if (text4 == "")
							{
								method_17("span div[role=\"button\"]");
							}
							else if (Commom.smethod_45(text4))
							{
								text = text4;
								if (method_5(text3) != "")
								{
									method_18(text3);
									method_18("//form//input[@type=\"text\"]/parent::*//*[@role=\"button\"]");
								}
								method_22(text3, text4);
								F217FA96(text3);
								result = true;
							}
							break;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			F8091028(2.0);
		}
		return result;
	}

	public bool method_130()
	{
		try
		{
			if (string.IsNullOrWhiteSpace(A1BF36A2))
			{
				return false;
			}
			string otp = Commom.smethod_62(A1BF36A2.Replace(" ", "").Replace("\n", "").Trim());
			if (string.IsNullOrEmpty(otp))
			{
				return false;
			}
			string selector = "";
			if (D7A424AE("input[name='approvals_code']"))
			{
				selector = "input[name='approvals_code']";
			}
			else if (D7A424AE("input[autocomplete='one-time-code']"))
			{
				selector = "input[autocomplete='one-time-code']";
			}
			else if (D7A424AE("input[type='text']"))
			{
				selector = "input[type='text']";
			}

			if (selector != "")
			{
				EB2B3FB0(selector);
				method_22(selector, otp);
				F8091028(1.0);
				if (D7A424AE("button[id='checkpointSubmitButton']"))
				{
					method_19("button[id='checkpointSubmitButton']");
				}
				else if (D7A424AE("#checkpointSubmitButton button"))
				{
					method_19("#checkpointSubmitButton button");
				}
				else if (D7A424AE("button[name='submit[Continue]']"))
				{
					method_19("button[name='submit[Continue]']");
				}
				else if (D7A424AE("button[type='submit']"))
				{
					method_19("button[type='submit']");
				}
				else
				{
					F217FA96(selector);
				}
				F8091028(3.0);

				if (D7A424AE("button[id='checkpointSubmitButton']"))
				{
					method_19("button[id='checkpointSubmitButton']");
					F8091028(2.0);
				}
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	public int FE31BD92(string string_10 = "https://www.facebook.com")
	{
		try
		{
			if (CD930D04() || E184CD03())
			{
				return -2;
			}
			if (D7A424AE("#m_login_email,#m_login_password,[name=\"login\"]"))
			{
				return 0;
			}
			if (method_124())
			{
				return 2;
			}
			if (D6BBEDA3())
			{
				return 9;
			}
			method_59();
			if (method_61() != method_61(string_10))
			{
				method_12(string_10);
			}
			if (method_61() == 2 && D7A424AE("[href^=\"/a/preferences.php?fast_switch_site\"]"))
			{
				DA2A8C96(0, "[href^=\"/a/preferences.php?fast_switch_site\"]");
			}
			if (method_123())
			{
				return 8;
			}
			if (C8825826())
			{
				return 1;
			}
			string text = GetURL();
			if (text.Contains("facebook.com/checkpoint/") || text.Contains("facebook.com/nt/screen/?params=%7B%22token") || text.Contains("facebook.com/x/checkpoint/"))
			{
				return 2;
			}
			if (GetURL().Contains("facebook.com/user_cookie_prompt"))
			{
				method_12("https://www.facebook.com/");
			}
			switch (method_61(string_10))
			{
			case 2:
			{
				for (int i = 0; i < 30; i++)
				{
					if (GetURL().Contains("facebook.com/si/actor_experience/actor_gateway/nt/?flow_id="))
					{
						break;
					}
					A7B3F62B(EE3B6F92: true);
					switch (CA294803)
					{
					case FE33ED1C.const_1:
						return -2;
					case FE33ED1C.DDA575B2:
						return 0;
					case FE33ED1C.C2301331:
						return 2;
					case FE33ED1C.C323FF1D:
						return 1;
					case FE33ED1C.CDBBFE27:
						return -3;
					case FE33ED1C.const_7:
						return 3;
					}
					EC9B94B0();
					if (D7A424AE("a[href*=\"/zero/optin/write/?action=cancel&page=dialtone_optin_page\"]", 5.0))
					{
						method_14("document.querySelector('a[href*=\"/zero/optin/write/?action=cancel&page=dialtone_optin_page\"]').click()");
						F8091028(3.0);
						if (D7A424AE("[action=\"/zero/optin/write/?action=confirm&page=reconsider_optin_dialog\"] button", 10.0))
						{
							method_14("document.querySelector('[action=\"/zero/optin/write/?action=confirm&page=reconsider_optin_dialog\"] button').click()");
							F8091028(3.0);
						}
					}
					if (GetURL().Contains("facebook.com/zero/optin/write/"))
					{
						F8091028(1.0);
						method_14("document.querySelector('[action=\"/zero/optin/write/?action=confirm&page=reconsider_optin_dialog\"] button').click()");
						F8091028(3.0);
					}
					if (GetURL().Contains("facebook.com/zero/policy/optin"))
					{
						F8091028(1.0);
						method_14("document.querySelector('a[data-sigil=\"touchable\"]').click()");
						F8091028(3.0);
						if (D7A424AE("button[data-sigil=\"touchable\"]", 10.0))
						{
							F8091028(1.0);
							method_14("document.querySelector('button[data-sigil=\"touchable\"]').click()");
							F8091028(3.0);
						}
					}
					if (Convert.ToBoolean(method_14("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
					{
						for (int j = 0; j < 5; j++)
						{
							Commom.smethod_52(2.0);
							if (!Convert.ToBoolean(method_14("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
							{
								break;
							}
						}
						for (int k = 0; k < 5; k++)
						{
							Commom.smethod_52(2.0);
							if (!Convert.ToBoolean(method_14("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('consent/basic/log')){x[i].click();break;check='true'}} return check")))
							{
								break;
							}
						}
						if (D7A424AE("[href=\"/home.php\"]"))
						{
							method_18("[href=\"/home.php\"]");
						}
					}
					if (GetURL().Contains("facebook.com/si/actor_experience/actor_gateway"))
					{
						method_18("[data-sigil=\"touchable\"]");
						F8091028(1.0);
					}
					if (D7A424AE("button[value=\"OK\"]"))
					{
						method_18("button[value=\"OK\"]");
						F8091028(1.0);
					}
					if (D7A424AE("[data-store-id=\"2\"]>span"))
					{
						method_18("[data-store-id=\"2\"]>span");
						F8091028(1.0);
					}
					if (D7A424AE("[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span"))
					{
						method_18("[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span");
						F8091028(3.0);
					}
					if (D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
					{
						bool flag = false;
						for (int l = 0; l < 5; l++)
						{
							if (flag)
							{
								break;
							}
							string text2 = method_15(3.0, new List<string> { "#qf_skip_dialog_skip_link", "#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]" });
							string text3 = text2;
							string text4 = text3;
							if (!(text4 == "#qf_skip_dialog_skip_link"))
							{
								if (!(text4 == "#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
								{
									flag = true;
									continue;
								}
								method_18(text2);
								F8091028(2.0);
							}
							else
							{
								method_21(text2);
								F8091028(1.0);
							}
						}
					}
					method_18("[name=\"primary_consent_button\"]");
					F8091028(2.0);
					if (D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
					{
						method_18("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
						if (D7A424AE("#qf_skip_dialog_skip_link", 10.0) && !E11EB838("#qf_skip_dialog_skip_link"))
						{
							method_14("document.getElementById('qf_skip_dialog_skip_link').click()");
						}
					}
				}
				break;
			}
			case 1:
			{
				if (!GetURL().StartsWith("https://www.facebook.com/legal_consent"))
				{
					break;
				}
				for (int m = 0; m < 5; m++)
				{
					if (!D7A424AE("button"))
					{
						break;
					}
					method_21("button");
					F8091028(1.0);
				}
				break;
			}
			case 3:
				if (D7A424AE("[name=\"accept_only_essential\"][value=\"0\"]"))
				{
					method_18("[name=\"accept_only_essential\"][value=\"0\"]");
				}
				break;
			}
			A7B3F62B(EE3B6F92: true);
			switch (CA294803)
			{
			case FE33ED1C.const_1:
				return -2;
			case FE33ED1C.DDA575B2:
				return 0;
			case FE33ED1C.C2301331:
				return 2;
			case FE33ED1C.C323FF1D:
				return 1;
			case FE33ED1C.CDBBFE27:
				return -3;
			case FE33ED1C.const_6:
				break;
			case FE33ED1C.const_7:
				return 3;
			}
		}
		catch
		{
		}
		return 0;
	}

	internal string method_131(string string_10)
	{
		string string_11 = "[{\"name\":\"password\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
		return method_66("TurnOn2FA", string_11);
	}

	internal string A799E836(string string_10)
	{
		string string_11 = "[{\"name\":\"password\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
		return method_66("TurnOff2FA", string_11);
	}

	internal string method_132(string string_10, string FD99741A)
	{
		string string_11 = "[{\"name\":\"password\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"},{\"name\":\"newpassword\", \"value\":\"" + string_10 + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + FD99741A + "\", \"type\":\"text\"}]";
		return method_66("ChangePass", string_11);
	}

	internal string method_133(string string_10)
	{
		string string_11 = "[{\"name\":\"password\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
		return method_66("DeletePhone", string_11);
	}

	internal string method_134(string C9ACAC2E, string string_10)
	{
		string string_11 = "[{\"name\":\"password\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"},{\"name\":\"email\", \"value\":\"" + C9ACAC2E.ToLower() + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
		return method_66("DeleteOtherEmail", string_11);
	}

	internal string method_135(string string_10, string string_11)
	{
		string string_12 = "[{\"name\":\"password\", \"value\":\"" + C234EEAA + "\", \"type\":\"text\"},{\"name\":\"email\", \"value\":\"" + string_10.ToLower() + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + string_11 + "\", \"type\":\"text\"}]";
		return method_66("AddMailAccountCenter", string_12);
	}

	internal string method_136(string BE218399, string string_10)
	{
		string string_11 = "[{\"name\":\"email\", \"value\":\"" + BE218399.ToLower() + "\", \"type\":\"text\"},{\"name\":\"otp\", \"value\":\"" + string_10 + "\", \"type\":\"text\"}]";
		return method_66("SubmitOtpAddMail", string_11);
	}

	internal bool method_137(string B0A70F8C)
	{
		method_12("https://m.facebook.com/entercode.php?cp=" + B0A70F8C.smethod_3() + "&source_verified=m_settings&redirect_to_unified_contact_setting_page");
		string string_ = "[href*=\"/entercode.php\"][href*=\"step=resend\"]";
		if (D7A424AE(string_, 30.0))
		{
			F8091028(2.0);
			method_21(string_);
			return true;
		}
		return false;
	}

	public string method_138(string string_10, string string_11, string string_12, string string_13, int int_4)
	{
		if (CD930D04())
		{
			return "";
		}
		return RunCodeChrome($"ResolveFunCaptcha('{string_10}', '{string_11}', '{string_12}', '{string_13}', {int_4})");
	}

	public bool method_139(int int_4)
	{
		if (CD930D04())
		{
			return false;
		}
		string text = RunCodeChrome($"SwitchToFrame({int_4})");
		return text.ToLower() == "true";
	}

	public bool method_140()
	{
		if (CD930D04())
		{
			return false;
		}
		string text = RunCodeChrome("SwitchToParentFrame()");
		return text.ToLower() == "true";
	}

	internal void method_141(string B5A618AE, int int_4)
	{
		method_12("https://www.facebook.com/profile.php?sk=about_work_and_education&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		for (int num = 60; !CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000; F8091028(2.0))
		{
			string text = method_15(0.0, new List<string> { "//*[text()=\"Add a workplace\"]", "//*[@aria-label=\"Company\"]//input", "//input[@aria-label=\"Company\"]" });
			switch (text)
			{
			case "//input[@aria-label=\"Company\"]":
			case "//*[@aria-label=\"Company\"]//input":
				if (!D7A424AE("[role=\"listbox\"]>li"))
				{
					EEB5149C(text);
					method_22(text, B5A618AE);
					F8091028(2.0);
					break;
				}
				method_18("[role=\"listbox\"]>li");
				F8091028(2.0);
				method_19("[aria-label*=\"Save\" i]");
				F8091028(2.0);
				method_33(text, 60);
				return;
			case "//*[text()=\"Add a workplace\"]":
				if (D7A424AE("//*[starts-with(text(),\"Works at \")]"))
				{
					switch (int_4)
					{
					case 2:
						if (D7A424AE("//*[@role=\"menuitem\"]//*[text()=\"Delete workplace\"]"))
						{
							method_18("//*[@role=\"menuitem\"]//*[text()=\"Delete workplace\"]");
						}
						else if (D7A424AE("[role=\"dialog\"] [aria-label=\"Confirm\"]"))
						{
							method_18("[role=\"dialog\"] [aria-label=\"Confirm\"]");
						}
						else
						{
							method_18("//*[@aria-label=\"Options\"][./parent::*/parent::*//*[starts-with(text(),\"Works at \")]]");
						}
						continue;
					case 1:
						return;
					}
				}
				method_19(text);
				break;
			}
		}
	}

	private void CF0AA19C()
	{
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text = method_15(0.0, new List<string> { "[href^=\"/profile/edit/exp/work/detail/\"]", "[href*=\"/editprofile/experience/delete/\"]" });
			if (!(text == ""))
			{
				method_18(text);
				F8091028(1.0);
				continue;
			}
			break;
		}
	}

	internal void method_142(string E004C38F, int F000E1BD)
	{
		method_12("https://www.facebook.com/profile.php?sk=about_work_and_education&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		for (int num = 60; !CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000; F8091028(2.0))
		{
			string text = method_15(0.0, new List<string> { "//*[text()=\"Add high school\"]", "//*[@aria-label=\"School\"]//input", "//input[@aria-label=\"School\"]" });
			switch (text)
			{
			case "//*[@aria-label=\"School\"]//input":
			case "//input[@aria-label=\"School\"]":
				if (!D7A424AE("[role=\"listbox\"]>li"))
				{
					EEB5149C(text);
					method_22(text, E004C38F);
					F8091028(2.0);
					break;
				}
				method_18("[role=\"listbox\"]>li");
				F8091028(2.0);
				method_19("[aria-label*=\"Save\" i]");
				F8091028(2.0);
				method_33(text, 60);
				return;
			case "//*[text()=\"Add high school\"]":
				if (D7A424AE("//*[starts-with(text(),\"Went to \")]"))
				{
					switch (F000E1BD)
					{
					case 2:
						if (D7A424AE("//*[@role=\"menuitem\"]//*[text()=\"Delete school\"]"))
						{
							method_18("//*[@role=\"menuitem\"]//*[text()=\"Delete school\"]");
						}
						else if (D7A424AE("[role=\"dialog\"] [aria-label=\"Confirm\"]"))
						{
							method_18("[role=\"dialog\"] [aria-label=\"Confirm\"]");
						}
						else
						{
							method_18("//*[@aria-label=\"Options\"][./parent::*/parent::*//*[starts-with(text(),\"Went to \")]]");
						}
						continue;
					case 1:
						return;
					}
				}
				method_19(text);
				break;
			}
		}
	}

	private void method_143()
	{
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text = method_15(0.0, new List<string> { "#education [href^=\"/profile/edit/exp/edu/detail/\"]", "[href*=\"/editprofile/experience/delete/\"]" });
			if (!(text == ""))
			{
				method_18(text);
				F8091028(1.0);
				continue;
			}
			break;
		}
	}

	internal void B516A6BD(string A8A14327, int C623D73F)
	{
		method_12("https://www.facebook.com/profile.php?sk=about_work_and_education&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		for (int num = 60; !CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000; F8091028(2.0))
		{
			string text = method_15(0.0, new List<string> { "//*[text()=\"Add college\"]", "//*[@aria-label=\"School\"]//input", "//input[@aria-label=\"School\"]" });
			switch (text)
			{
			case "//*[@aria-label=\"School\"]//input":
			case "//input[@aria-label=\"School\"]":
				if (!D7A424AE("[role=\"listbox\"]>li"))
				{
					EEB5149C(text);
					method_22(text, A8A14327);
					F8091028(2.0);
					break;
				}
				method_18("[role=\"listbox\"]>li");
				F8091028(2.0);
				method_19("[aria-label*=\"Save\" i]");
				F8091028(2.0);
				method_33(text, 60);
				return;
			case "//*[text()=\"Add college\"]":
				if (D7A424AE("//*[starts-with(text(),\"Studied at \")]"))
				{
					switch (C623D73F)
					{
					case 2:
						if (D7A424AE("//*[@role=\"menuitem\"]//*[text()=\"Delete school\"]"))
						{
							method_18("//*[@role=\"menuitem\"]//*[text()=\"Delete school\"]");
						}
						else if (D7A424AE("[role=\"dialog\"] [aria-label=\"Confirm\"]"))
						{
							method_18("[role=\"dialog\"] [aria-label=\"Confirm\"]");
						}
						else
						{
							method_18("//*[@aria-label=\"Options\"][./parent::*/parent::*//*[starts-with(text(),\"Studied at \")]]");
						}
						continue;
					case 1:
						return;
					}
				}
				method_19(text);
				break;
			}
		}
	}

	internal void D60F4C83(string E01EBE1C)
	{
		method_12("https://www.facebook.com/profile.php?sk=about_places&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text = method_15(0.0, new List<string> { "//*[text()=\"Add current city\"]", "//input[@aria-label=\"Current city\"]", "//*[@aria-label=\"Options\"][./parent::*/parent::*//*[text()=\"Current city\"]]" });
			switch (text)
			{
			case "//*[@aria-label=\"Options\"][./parent::*/parent::*//*[text()=\"Current city\"]]":
				if (D7A424AE("//*[text()=\"Edit current city\"]"))
				{
					method_18("//*[text()=\"Edit current city\"]");
				}
				else
				{
					method_19(text);
				}
				break;
			case "//input[@aria-label=\"Current city\"]":
				if (!D7A424AE("[role=\"listbox\"]>li"))
				{
					EEB5149C(text);
					method_22(text, E01EBE1C);
					F8091028(2.0);
					break;
				}
				method_18("[role=\"listbox\"]>li");
				F8091028(2.0);
				method_19("[aria-label*=\"Save\" i]");
				F8091028(2.0);
				method_33(text, 60);
				return;
			case "//*[text()=\"Add current city\"]":
				method_19(text);
				break;
			}
			F8091028(2.0);
		}
	}

	internal void method_144(string string_10)
	{
		method_12("https://www.facebook.com/profile.php?sk=about_places&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text = method_15(0.0, new List<string> { "//*[text()=\"Add hometown\"]", "//input[@aria-label=\"Hometown\"]", "//*[@aria-label=\"Options\"][./parent::*/parent::*//*[text()=\"Hometown\"]]" });
			switch (text)
			{
			case "//*[@aria-label=\"Options\"][./parent::*/parent::*//*[text()=\"Hometown\"]]":
				if (D7A424AE("//*[text()=\"Edit hometown\"]"))
				{
					method_18("//*[text()=\"Edit hometown\"]");
				}
				else
				{
					method_19(text);
				}
				break;
			case "//input[@aria-label=\"Hometown\"]":
				if (!D7A424AE("[role=\"listbox\"]>li"))
				{
					EEB5149C(text);
					method_22(text, string_10);
					F8091028(2.0);
					break;
				}
				method_18("[role=\"listbox\"]>li");
				F8091028(2.0);
				method_19("[aria-label*=\"Save\" i]");
				F8091028(2.0);
				method_33(text, 60);
				return;
			case "//*[text()=\"Add hometown\"]":
				method_19(text);
				break;
			}
			F8091028(2.0);
		}
	}

	internal bool method_145(string FDBE5012)
	{
		if (!D7A424AE("[type=\"file\"]", 15.0))
		{
			return false;
		}
		method_53();
		F8091028(1.0);
		method_24("[type=\"file\"]", FDBE5012);
		F8091028(1.0);
		if (D7A424AE("[name=\"action_upload_image\"]"))
		{
			method_18("[name=\"action_upload_image\"]");
		}
		else
		{
			method_33(".html-div [role=\"button\"][aria-disabled=\"true\"]", 60);
			method_18(".html-div [role=\"button\"]:has(div>[role=\"none\"])");
			F8091028(2.0);
			method_33(".html-div [role=\"button\"][aria-disabled=\"true\"]", 60);
		}
		method_54();
		return true;
	}

	public string BB357610()
	{
		string text = "9e5f94bc-e8a4-4e73-b8be-63364c29d753";
		string string_ = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=" + text + "&response_type=code&redirect_uri=https%3A%2F%2Flocalhost%2F&response_mode=query&scope=offline_access https://outlook.office.com/IMAP.AccessAsUser.All https://outlook.office.com/POP.AccessAsUser.All https://outlook.office.com/EWS.AccessAsUser.All https://outlook.office.com/SMTP.Send&state=PvCYEqIiGX";
		method_12(string_);
		string text2 = "";
		for (int i = 0; i < 30; i++)
		{
			text2 = Commom.F914B80B(GetURL(), "code=(.*?)&");
			if (text2 != "")
			{
				break;
			}
			string text3 = method_15(0.0, new List<string> { "#idBtn_Accept", "#iLandingViewAction", "[data-testid=\"appConsentPrimaryButton\"]" });
			if (text3 != "")
			{
				method_17(text3);
			}
			F8091028(2.0);
		}
		if (text2 == "")
		{
			return "";
		}
		GClass0 gClass = new GClass0();
		string_ = "https://login.microsoftonline.com/common/oauth2/v2.0/token";
		List<KeyValuePair<string, string>> list_ = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("client_id", text),
			new KeyValuePair<string, string>("code", text2),
			new KeyValuePair<string, string>("redirect_uri", "https://localhost/"),
			new KeyValuePair<string, string>("grant_type", "authorization_code")
		};
		string d8B49E = method_146(list_);
		string input = gClass.B930129D(string_, d8B49E);
		string value = Regex.Match(input, "\"refresh_token\":\"(.*?)\"").Groups[1].Value;
		if (value == "")
		{
			return "";
		}
		return value + "|" + text;
	}

	public string method_146(List<KeyValuePair<string, string>> list_0)
	{
		return string.Join("&", list_0.Select((KeyValuePair<string, string> keyValuePair_0) => WebUtility.UrlEncode(keyValuePair_0.Key) + "=" + WebUtility.UrlEncode(keyValuePair_0.Value)));
	}

	internal void method_147(List<string> B73D2917)
	{
		string text = "[aria-label$=\" questions\"][role=\"dialog\"]";
		if (D7A424AE(text + " input[type=\"radio\"]"))
		{
			int num = method_30(text + " input[type=\"radio\"]");
			for (int i = 0; i < num; i++)
			{
				method_19(text + " input[type=\"radio\"]|" + i);
			}
		}
		if (D7A424AE(text + " textarea"))
		{
			int num2 = method_30(text + " textarea");
			for (int j = 0; j < num2; j++)
			{
				string string_ = B73D2917[j % B73D2917.Count];
				method_20(text + " textarea|" + j);
				method_22(text + " textarea|" + j, string_);
			}
		}
		if (D7A424AE(text + " input[type=\"checkbox\"]"))
		{
			int num3 = method_30(text + " input[type=\"checkbox\"]");
			for (int k = 0; k < num3; k++)
			{
				method_19(text + " input[type=\"checkbox\"]|" + k);
			}
		}
		method_19("(//*[contains(@aria-label,\" questions\") and @role=\"dialog\"]//*[@aria-label=\"Submit\"])[last()]");
	}

	internal void method_148(string string_10)
	{
		try
		{
			IWebElement toElement = A022661F(string_10);
			Actions actions = new Actions(ChromeDriver_0);
			actions.MoveToElement(toElement).Perform();
		}
		catch (Exception)
		{
		}
	}

	internal void method_149(string BC3D5230)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "1", "Single" },
			{ "2", "In a relationship" },
			{ "5", "Engaged" },
			{ "4", "Married" },
			{ "10", "In a civil union" },
			{ "11", "In a domestic partnership" },
			{ "3", "In an open relationship" },
			{ "6", "It's complicated" },
			{ "8", "Separated" },
			{ "9", "Divorced" },
			{ "7", "Widowed" }
		};
		string text = dictionary[BC3D5230];
		method_12("https://www.facebook.com/profile.php?sk=about_family_and_relationships&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text2 = method_15(0.0, new List<string> { "//*[text()=\"Add a relationship status\"]", "//*[text()=\"Relationship\"]/ancestor::*//*[@role=\"combobox\"]//span", "//*[@aria-label=\"Edit relationship\"]" });
			switch (text2)
			{
			case "//*[@aria-label=\"Edit relationship\"]":
				if (!D7A424AE("//*[text()=\"" + text + "\"]"))
				{
					method_19(text2);
					break;
				}
				return;
			case "//*[text()=\"Relationship\"]/ancestor::*//*[@role=\"combobox\"]//span":
				if (!D7A424AE("//*[@role=\"option\"]//*[text()=\"" + text + "\"]"))
				{
					method_18(text2);
					break;
				}
				method_18("//*[@role=\"option\"]//*[text()=\"" + text + "\"]");
				F8091028(2.0);
				method_19("[aria-label*=\"Save\" i]");
				F8091028(2.0);
				method_33(text2, 60);
				return;
			case "//*[text()=\"Add a relationship status\"]":
				method_19(text2);
				break;
			}
			F8091028(2.0);
		}
	}

	internal void method_150(string string_10)
	{
		string text = "";
		string text2 = "";
		if (!(string_10 == "1"))
		{
			if (string_10 == "2")
			{
				text = "Male";
				text2 = "he/him";
			}
		}
		else
		{
			text = "Female";
			text2 = "she/her";
		}
		method_12("https://www.facebook.com/profile.php?sk=about_contact_and_basic_info&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount < num * 1000)
		{
			string text3 = method_15(0.0, new List<string> { "[aria-label=\"Add your gender\"]", "[aria-haspopup=\"listbox\"][role=\"combobox\"]", "[aria-label=\"Edit gender\" i]" });
			switch (text3)
			{
			case "[aria-label=\"Edit gender\" i]":
				if (!D7A424AE("//*[text()=\"" + text + "\"]"))
				{
					method_19(text3);
					break;
				}
				return;
			case "[aria-haspopup=\"listbox\"][role=\"combobox\"]":
				if (D7A424AE("//*[@role=\"option\"]//*[text()=\"" + text + "\"]"))
				{
					method_18("//*[@role=\"option\"]//*[text()=\"" + text + "\"]");
					F8091028(2.0);
					method_19("[aria-label*=\"Save\" i]");
					F8091028(2.0);
					method_33("[aria-label*=\"Save\" i]", 60);
				}
				else
				{
					method_18(text3);
				}
				break;
			case "[aria-label=\"Add your gender\"]":
				if (D7A424AE("//*[@aria-label=\"Add your gender\"]/ancestor::*//*[text()=\"" + text + "\"]"))
				{
					if (D7A424AE("//*[text()=\"" + text2 + "\"]"))
					{
						if (!D7A424AE("//*[@role=\"option\"]//*[text()=\"" + text2 + "\"]"))
						{
							return;
						}
						method_18("//*[@role=\"option\"]//*[text()=\"" + text2 + "\"]");
						F8091028(2.0);
						method_19("[aria-label*=\"Save\" i]");
						F8091028(2.0);
						method_33("[aria-label*=\"Save\" i]", 60);
					}
					else if (D7A424AE("[aria-haspopup=\"listbox\"][role=\"combobox\"]"))
					{
						method_19("[aria-haspopup=\"listbox\"][role=\"combobox\"]");
					}
					else
					{
						method_18("[aria-label=\"Edit\"]");
					}
				}
				else
				{
					method_19(text3);
				}
				break;
			}
			F8091028(2.0);
		}
	}

	public void method_151(string string_10, string FD14FABB, int int_4)
	{
		if (class59_0 == null)
		{
			return;
		}
		RequestXNet requestXNet = new RequestXNet();
		string text = "{\r\n                \"profileId\": {profileId},\r\n                \"closeBrowser\": false,\r\n                \"parameters\": {input}\r\n            }";
		text = text.Replace("{profileId}", class59_0.C61C311D);
		text = text.Replace("{input}", FD14FABB);
		string json = requestXNet.method_1("http://localhost:1010/api/scripts/execute/" + string_10, text, "application/json");
		if (!Convert.ToBoolean(JObject.Parse(json)["success"]))
		{
			return;
		}
		F8091028(3.0);
		text = "{\r\n                \"profileId\": {profileId}\r\n            }";
		text = text.Replace("{profileId}", class59_0.C61C311D);
		int tickCount = Environment.TickCount;
		while (!CD930D04())
		{
			if (Environment.TickCount - tickCount < int_4 * 1000 && !E184CD03())
			{
				json = requestXNet.method_1("http://localhost:1010/api/scripts/check-status/" + string_10, text, "application/json");
				if (Convert.ToBoolean(JObject.Parse(json)["is_running"]))
				{
					F8091028(3.0);
					continue;
				}
				break;
			}
			text = "{\r\n                        \"profileId\": {profileId},\r\n                        \"closeBrowser\": false,\r\n                    }";
			text = text.Replace("{profileId}", class59_0.C61C311D);
			json = requestXNet.method_1("http://localhost:1010/api/scripts/kill-excute/" + string_10, text, "application/json");
			break;
		}
	}

	public string method_152()
	{
		string result = "";
		method_53();
		try
		{
			method_12("https://www.facebook.com/profile.php?locale=en_US");
			F8091028(2.0);
			int tickCount = Environment.TickCount;
			int num = 60;
			while (!CD930D04() && !E184CD03() && Environment.TickCount - tickCount <= num * 1000)
			{
				string text = method_15(0.0, new List<string> { "[aria-label=\"See options\" i]", "[role=\"listitem\"]" });
				string text2 = text;
				string text3 = text2;
				if (!(text3 == "[aria-label=\"See options\" i]"))
				{
					if (text3 == "[role=\"listitem\"]")
					{
						if (D7A424AE("//*[contains(text(),' waitlist') or contains(text(),' waiting list')]"))
						{
							return "Waitlist";
						}
						return "Enable";
					}
					if (D7A424AE("//*[text()=\"You're on the waitlist!\"]"))
					{
						return "Waitlist";
					}
				}
				else if (D7A424AE("[role=\"menu\"] [role=\"menuitem\"]"))
				{
					if (!D7A424AE("[role=\"menu\"] [role=\"menuitem\"][href*=\"meta_verified\"]"))
					{
						result = "No";
						break;
					}
					method_19("[role=\"menu\"] [role=\"menuitem\"][href*=\"meta_verified\"]");
				}
				else
				{
					method_19(text);
				}
				F8091028(2.0);
			}
		}
		catch (Exception)
		{
		}
		method_54();
		return result;
	}

	internal string BD9F631D(GClass4 AB9B679D)
	{
		B63F06A4 b63F06A4_ = default(B63F06A4);
		b63F06A4_.A61E8287 = this;
		int num = AB9B679D.method_2("nudWallPosts", 8);
		b63F06A4_.bool_0 = AB9B679D.method_3("ckbWallPostLinkShare");
		b63F06A4_.bool_1 = AB9B679D.method_3("ckbWallPostUpAvatarCover");
		b63F06A4_.int_0 = 0;
		bool flag = false;
		try
		{
			string text = method_41();
			if (text == "")
			{
				method_12("https://www.facebook.com");
				text = method_41();
			}
			string text2 = "";
			string text3 = FB94939A();
			string string_ = "https://www.facebook.com/api/graphql/";
			string string_2 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + text + "&jazoest=22037&lsd=" + text2 + "&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern&variables={\"afterTime\":null,\"beforeTime\":null,\"count\":8,\"cursor\":null,\"gridMediaWidth\":230,\"omitPinnedPost\":true,\"postedBy\":null,\"privacy\":null,\"privacySelectorRenderLocation\":\"COMET_STREAM\",\"renderLocation\":\"timeline\",\"scale\":1,\"taggedInOnly\":null,\"id\":\"" + text3 + "\"}&doc_id=7860607297326640&locale=en_US";
			Struct1 struct1_ = default(Struct1);
			struct1_.string_0 = method_48(string_, string_2);
			b63F06A4_.int_0 = struct1_.string_0.Split('\n').Length - 1;
			if (b63F06A4_.int_0 == 1 && struct1_.string_0.Contains("timeline_grid_feed_units\":{\"edges\":[]}"))
			{
				return "0";
			}
			flag = struct1_.string_0.Split('\n').Last().Contains("\"has_next_page\":true");
			if (b63F06A4_.bool_0 | b63F06A4_.bool_1)
			{
				b63F06A4_.int_0 = 0;
				B8AE01A9(ref b63F06A4_, ref struct1_);
				while (flag && num > b63F06A4_.int_0 && !E184CD03() && !CD930D04())
				{
					string text4 = JObject.Parse(struct1_.string_0.Split('\n').Last())["data"]!["page_info"]!["end_cursor"]!.ToString();
					string_2 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + text + "&jazoest=22037&lsd=" + text2 + "&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern&variables={\"afterTime\":null,\"beforeTime\":null,\"count\":8,\"cursor\":\"" + text4 + "\",\"gridMediaWidth\":230,\"omitPinnedPost\":true,\"postedBy\":null,\"privacy\":null,\"privacySelectorRenderLocation\":\"COMET_STREAM\",\"renderLocation\":\"timeline\",\"scale\":1,\"taggedInOnly\":null,\"id\":\"" + text3 + "\"}&doc_id=7860607297326640&locale=en_US";
					struct1_.string_0 = method_48(string_, string_2);
					B8AE01A9(ref b63F06A4_, ref struct1_);
					flag = struct1_.string_0.Split('\n').Last().Contains("\"has_next_page\":true");
				}
			}
			else
			{
				while (flag && num > b63F06A4_.int_0 && !E184CD03() && !CD930D04())
				{
					string text5 = JObject.Parse(struct1_.string_0.Split('\n').Last())["data"]!["page_info"]!["end_cursor"]!.ToString();
					string_2 = "av=" + text3 + "&__user=" + text3 + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + text + "&jazoest=22037&lsd=" + text2 + "&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern&variables={\"afterTime\":null,\"beforeTime\":null,\"count\":8,\"cursor\":\"" + text5 + "\",\"gridMediaWidth\":230,\"omitPinnedPost\":true,\"postedBy\":null,\"privacy\":null,\"privacySelectorRenderLocation\":\"COMET_STREAM\",\"renderLocation\":\"timeline\",\"scale\":1,\"taggedInOnly\":null,\"id\":\"" + text3 + "\"}&doc_id=7860607297326640&locale=en_US";
					struct1_.string_0 = method_48(string_, string_2);
					b63F06A4_.int_0 += struct1_.string_0.Split('\n').Length - 1;
					flag = struct1_.string_0.Split('\n').Last().Contains("\"has_next_page\":true");
				}
			}
		}
		catch (Exception)
		{
		}
		return string.Format("{0}{1}", b63F06A4_.int_0, flag ? "+" : "");
	}

	public GClass4 CE37360F(string BEAC0BA1, string string_10, string AAB42593)
	{
		method_53();
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		bool flag = false;
		method_12("https://accountscenter.facebook.com/profiles/" + FB94939A() + "/name/?entrypoint=fb_account_center&locale=en_US");
		F8091028(2.0);
		int tickCount = Environment.TickCount;
		int num = 60;
		while (true)
		{
			if (!CD930D04() && !E184CD03())
			{
				if (Environment.TickCount - tickCount < num * 1000)
				{
					string text = method_15(0.0, new List<string> { "[role=\"dialog\"] input[type=\"text\"][disabled]", "[role=\"dialog\"] input[type=\"text\"]", "[role=\"dialog\"] [role=\"list\"]>[role=\"listitem\"]" });
					switch (text)
					{
					case "[role=\"dialog\"] input[type=\"text\"]":
						if (method_27(text))
						{
							flag = true;
							int num2 = method_30(text);
							if (num2 == 3)
							{
								EEB5149C("[role=\"dialog\"] [type=\"text\"]|0");
								method_22("[role=\"dialog\"] [type=\"text\"]|0", AAB42593);
								F8091028(1.0);
								EEB5149C("[role=\"dialog\"] [type=\"text\"]|1");
								method_22("[role=\"dialog\"] [type=\"text\"]|1", string_10);
							}
							else
							{
								EEB5149C("[role=\"dialog\"] [type=\"text\"]|0");
								method_22("[role=\"dialog\"] [type=\"text\"]|0", string_10 + " " + AAB42593);
							}
							F8091028(1.0);
							EEB5149C($"[role=\"dialog\"] [type=\"text\"]|{num2 - 1}");
							method_22($"[role=\"dialog\"] [type=\"text\"]|{num2 - 1}", BEAC0BA1);
							F8091028(1.0);
						}
						method_18("(//*[@role=\"dialog\"]//*[@role=\"button\"][.//*[@role=\"none\"]//span])[last()]");
						goto IL_01ea;
					default:
						goto IL_01ea;
					case "[role=\"dialog\"] [role=\"list\"]>[role=\"listitem\"]":
						if (flag)
						{
							gClass.method_4("success", true);
						}
						else
						{
							gClass.method_4("error", "fail");
						}
						break;
					case "[role=\"dialog\"] input[type=\"text\"][disabled]":
						if (D7A424AE("//*[text()=\"Leave page?\"]"))
						{
							gClass.method_4("success", true);
						}
						else
						{
							gClass.method_4("error", "fail");
						}
						break;
					}
				}
				else
				{
					gClass.method_4("error", "timeout");
				}
			}
			else
			{
				gClass.method_4("error", "chrome_closed");
			}
			break;
			IL_01ea:
			F8091028(2.0);
			tickCount = Environment.TickCount;
		}
		method_54();
		return gClass;
	}

	internal void A80F3C2C(string D3AAD19E)
	{
		string text = Commom.smethod_94(D3AAD19E);
		string text2 = method_41();
		string text3 = "av=" + B4208531 + "&__user=" + B4208531 + "&__a=1&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=&__rev=&__s=&__hsi=&__comet_req=15&fb_dtsg=" + text2 + "&jazoest=25389&lsd=dXx0C5PYe6DF2HH9mgHWfS&__spin_r=&__spin_b=&__spin_t=&fb_api_caller_class=RelayModern&";
		string string_ = (text3 = text3 + "fb_api_req_friendly_name=useCometFeedUnsubscribeToStoryMutation&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + B4208531 + "%22%2C%22feedback_id%22%3A%22" + Commom.smethod_49("feedback:" + text) + "%22%7D%7D&server_timestamps=true&doc_id=6947353665286869");
		method_48("https://www.facebook.com/api/graphql", string_);
	}

	internal bool method_153()
	{
		bool result = false;
		method_53();
		int tickCount = Environment.TickCount;
		for (int num = 300; !CD930D04() && !E184CD03() && Environment.TickCount - tickCount <= num * 1000; F8091028(2.0))
		{
			string text = method_15(0.0, new List<string> { "[role=\"dialog\"] [aria-label=\"Next\"]", "[role=\"dialog\"] [aria-label=\"Upload\"]:not([aria-disabled])", "[role=\"dialog\"] [aria-label=\"Upload\"]", "[role=\"dialog\"] [aria-label=\"Uploading\"]", "[role=\"dialog\"] [aria-label=\"Finish\"]", "[aria-label=\"Continue\"]" });
			switch (text)
			{
			default:
				if (!GetURL().Contains("828281030927956"))
				{
					continue;
				}
				break;
			case "[aria-label=\"Continue\"]":
				method_18(text);
				continue;
			case "[role=\"dialog\"] [aria-label=\"Upload\"]:not([aria-disabled])":
				method_18(text);
				continue;
			case "[role=\"dialog\"] [aria-label=\"Next\"]":
				method_18(text);
				continue;
			case "[role=\"dialog\"] [aria-label=\"Upload\"]":
			case "[role=\"dialog\"] [aria-label=\"Uploading\"]":
				continue;
			case "[role=\"dialog\"] [aria-label=\"Finish\"]":
				method_18(text);
				result = true;
				break;
			}
			break;
		}
		method_54();
		return result;
	}

	[CompilerGenerated]
	private void method_154()
	{
		try
		{
			if (class59_0 != null)
			{
				class59_0.method_3();
			}
			ChromeDriver_0.Quit();
			if (class59_0 != null && class59_0.C1B1B61F.StartsWith("temp_"))
			{
				Class59.smethod_3(class59_0.C61C311D);
			}
		}
		catch (Exception)
		{
		}
	}

	[CompilerGenerated]
	private bool method_155()
	{
		return method_63(0) || D7A424AE("//*[text()=\"Leave page?\"]");
	}

	[CompilerGenerated]
	private bool DF8624AA()
	{
		return !D7A424AE("[aria-label$=\"...\"]") || method_63(0);
	}

	[CompilerGenerated]
	private void B8AE01A9(ref B63F06A4 b63F06A4_0, ref Struct1 struct1_0)
	{
		string[] array = struct1_0.string_0.Split('\n');
		for (int i = 0; i < array.Length - 1; i++)
		{
			string text = array[i];
			try
			{
				JObject jObject = JObject.Parse(text);
				jObject = ((jObject?["data"]?["node"]?["timeline_grid_feed_units"]?["edges"]?[0] == null) ? (jObject?["data"] as JObject) : (jObject?["data"]?["node"]?["timeline_grid_feed_units"]?["edges"]?[0] as JObject));
				if (!b63F06A4_0.bool_0)
				{
					goto IL_0163;
				}
				bool num = (jObject?["node"]?["attached_story"] as JObject)?.ContainsKey("attachments") ?? false;
				bool flag = num;
				if (!num)
				{
					flag = text.Contains("FBShortsShareAttachment");
				}
				if (!flag)
				{
					goto IL_0163;
				}
				goto end_IL_002a;
				IL_0163:
				bool flag2 = true;
				string text2 = jObject?["node"]?["url"].ToString();
				if (!string.IsNullOrEmpty(text2) && !text2.Contains("/posts/"))
				{
					flag2 = text2.Contains(string_2);
				}
				if (!flag2)
				{
					continue;
				}
				if (b63F06A4_0.bool_1)
				{
					bool flag3 = false;
					try
					{
						string text3 = jObject?["node"]?["title"]?["text"]?.ToString();
						if (!string.IsNullOrEmpty(text3))
						{
							flag3 = text3.Contains("profile picture") || text3.Contains("cover photo");
						}
						if (flag3)
						{
							continue;
						}
					}
					catch (Exception)
					{
					}
				}
				b63F06A4_0.int_0++;
				end_IL_002a:;
			}
			catch (Exception)
			{
			}
		}
	}

	public bool CheckGroupApprovalInDOM()
	{
		try
		{
			string script = @"
				return (() => {
					const text = (document.body ? document.body.innerText : '') || '';
					if (text.includes('bài viết của bạn đã được gửi') || 
						text.includes('chờ phê duyệt') || 
						text.includes('pending approval') || 
						text.includes('submitted to group admins') ||
						text.includes('quản trị viên phê duyệt')) {
						return true;
					}
					return false;
				})();
			";
			object result = (ChromeDriver_0 != null) ? ChromeDriver_0.ExecuteScript(script) : null;
			return result != null && (bool)result;
		}
		catch
		{
			return false;
		}
	}

	internal string method_81(string string_10, string string_11, string bio, string website, string phone, string email, string address, string city, string zip, string avatar, string cover, string targetUid, Action<string> log = null)
	{
		return PageCreationHub.CreatePage(this, string_10, string_11, bio, website, phone, email, address, city, zip, avatar, cover, targetUid, log, autoPostProcess: true);
	}
}
