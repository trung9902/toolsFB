using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

public class GClass14
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string string_0;

	public string String_0
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public GClass14(string string_1)
	{
		String_0 = string_1;
	}

	public bool C083FF86(int int_0, string D7905217, out string A41703A7)
	{
		string text = "";
		string text2 = "";
		text2 = ((int_0 != 0) ? "api.captcha.guru" : "2captcha.com");
		using (WebClient webClient = new WebClient())
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["method"] = "base64";
			nameValueCollection["key"] = String_0;
			nameValueCollection["body"] = D7905217;
			byte[] bytes = webClient.UploadValues("http://" + text2 + "/in.php", nameValueCollection);
			text = Encoding.Default.GetString(bytes);
		}
		Thread.Sleep(TimeSpan.FromSeconds(5.0));
		if (text.Substring(0, 3) == "OK|")
		{
			string text3 = text.Remove(0, 3);
			for (int i = 0; i < 24; i++)
			{
				WebRequest webRequest = WebRequest.Create("http://" + text2 + "/res.php?key=" + String_0 + "&action=get&id=" + text3);
				using (WebResponse webResponse = webRequest.GetResponse())
				{
					using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
					string text4 = streamReader.ReadToEnd();
					if (text4.Length < 3)
					{
						A41703A7 = text4;
						return false;
					}
					if (text4.Substring(0, 3) == "OK|")
					{
						A41703A7 = text4.Remove(0, 3);
						return true;
					}
					if (text4 != "CAPCHA_NOT_READY")
					{
						A41703A7 = text4;
						return false;
					}
				}
				Thread.Sleep(5000);
			}
			A41703A7 = "Timeout";
			return false;
		}
		A41703A7 = text;
		return false;
	}

	public static string smethod_0(int C63D4DAF, string B43FB5B4, string F5B6C83E)
	{
		string A41703A = "";
		GClass14 gClass = new GClass14(B43FB5B4);
		bool flag = gClass.C083FF86(C63D4DAF, F5B6C83E, out A41703A);
		while (!flag)
		{
			flag = gClass.C083FF86(C63D4DAF, F5B6C83E, out A41703A);
			Thread.Sleep(TimeSpan.FromSeconds(2.0));
		}
		return A41703A;
	}

	public static string smethod_1(string string_1, string DC801D3E, int int_0, string string_2 = "", string string_3 = "")
	{
		string A8243C = "";
		GClass14 gClass = new GClass14(string_1);
		gClass.EC185326(DC801D3E, int_0, out A8243C, string_2, string_3);
		return A8243C;
	}

	private bool EC185326(string AE28EC37, int int_0, out string A8243C08, string string_1 = "", string string_2 = "")
	{
		string text = "";
		using (WebClient webClient = new WebClient())
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["method"] = "base64";
			nameValueCollection["key"] = String_0;
			nameValueCollection["body"] = AE28EC37;
			nameValueCollection["type"] = int_0.ToString();
			nameValueCollection["code"] = string_1;
			nameValueCollection["hash"] = string_2;
			byte[] bytes = webClient.UploadValues("http://captchafb.xyz/in.php", nameValueCollection);
			text = Encoding.Default.GetString(bytes);
		}
		Thread.Sleep(TimeSpan.FromSeconds(1.0));
		if (text.Substring(0, 3) == "OK|")
		{
			string text2 = text.Remove(0, 3);
			for (int i = 0; i < 24; i++)
			{
				WebRequest webRequest = WebRequest.Create("http://captchafb.xyz/res.php?id=" + text2);
				using (WebResponse webResponse = webRequest.GetResponse())
				{
					using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
					string text3 = streamReader.ReadToEnd();
					if (text3.Length < 3)
					{
						A8243C08 = text3;
						return false;
					}
					if (text3.Substring(0, 3) == "OK|")
					{
						A8243C08 = text3.Remove(0, 3);
						return true;
					}
					if (text3 != "CAPCHA_NOT_READY")
					{
						A8243C08 = text3;
						return false;
					}
				}
				Thread.Sleep(2000);
			}
			A8243C08 = "Timeout";
			return false;
		}
		A8243C08 = text;
		return false;
	}

	public bool method_0(int int_0, string ED3C7F33, string string_1, out string string_2, string string_3 = "")
	{
		string text = "";
		switch (int_0)
		{
		case 0:
			text = "2captcha.com";
			break;
		case 1:
			text = "api.captcha.guru";
			break;
		case 3:
			text = string_3.Split('*')[0];
			String_0 = string_3.Split('*')[1];
			break;
		}
		string requestUriString = "http://" + text + "/in.php?key=" + String_0 + "&method=userrecaptcha&googlekey=" + ED3C7F33 + "&pageurl=" + string_1;
		try
		{
			WebRequest webRequest = WebRequest.Create(requestUriString);
			using WebResponse webResponse = webRequest.GetResponse();
			using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
			string text2 = streamReader.ReadToEnd();
			if (text2.Length < 3)
			{
				string_2 = text2;
				return false;
			}
			if (text2.Substring(0, 3) == "OK|")
			{
				string text3 = text2.Remove(0, 3);
				for (int i = 0; i < 24; i++)
				{
					WebRequest webRequest2 = WebRequest.Create("http://" + text + "/res.php?key=" + String_0 + "&action=get&id=" + text3);
					using (WebResponse webResponse2 = webRequest2.GetResponse())
					{
						using StreamReader streamReader2 = new StreamReader(webResponse2.GetResponseStream());
						string text4 = streamReader2.ReadToEnd();
						if (text4.Length < 3)
						{
							string_2 = text4;
							return false;
						}
						if (text4.Substring(0, 3) == "OK|")
						{
							string_2 = text4.Remove(0, 3);
							return true;
						}
						if (text4 != "CAPCHA_NOT_READY")
						{
							string_2 = text4;
							return false;
						}
					}
					Thread.Sleep(5000);
				}
				string_2 = "Timeout";
				return false;
			}
			string_2 = text2;
			return false;
		}
		catch
		{
		}
		string_2 = "Unknown error";
		return false;
	}

	public static string smethod_2(int int_0, string string_1, string string_2, string D488980E)
	{
		string string_3 = "";
		GClass14 gClass = null;
		gClass = ((!string_1.Contains("*")) ? new GClass14(string_1) : new GClass14(string_1.Split('*')[1]));
		bool flag = gClass.method_0(int_0, string_2, D488980E, out string_3, string_1);
		while (!flag)
		{
			flag = gClass.method_0(int_0, string_2, D488980E, out string_3, string_1);
			Thread.Sleep(TimeSpan.FromSeconds(2.0));
		}
		return string_3;
	}
}
