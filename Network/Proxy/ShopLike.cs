using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

internal class ShopLike : ABB2B510
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_2;

	internal object object_0 = new object();

	internal int int_0 = 0;

	internal bool bool_0 = true;

	internal int int_1 = 0;

	internal int int_2 = 0;

	internal int F8ABA49F = 3;

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

	public string A40F8204
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string String_1
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public ShopLike(string string_3, int int_3)
	{
		String_0 = string_3;
		A40F8204 = "";
		String_1 = C5034B95.smethod_0("configGeneral").BDB80B23("ip_iTypeChangeIp");
		F8ABA49F = int_3;
		int_1 = 0;
		int_2 = 0;
		bool_0 = true;
	}

	public void B32AAD86()
	{
		lock (object_0)
		{
			int_1--;
			if (int_1 == 0 && int_2 == F8ABA49F)
			{
				int_2 = 0;
			}
		}
	}

	public bool E1365814()
	{
		if (!method_2())
		{
			return false;
		}
		A40F8204 = "";
		try
		{
			string text = string_2;
			string text2 = text;
			switch (AFAE75A0.smethod_0(text2))
			{
			case 350953279u:
				if (text2 == "19")
				{
					string text3 = new RequestXNet().E58EB99F("https://api.netproxy.io/api/rotateProxy/getNewProxy?apiKey=" + string_0 + "&country=all&type=all");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						method_1(text3);
					}
				}
				break;
			case 334175660u:
				if (text2 == "18")
				{
					string text3 = new RequestXNet().E58EB99F("https://proxymxh.com/api/GetNew.php?api_key=" + string_0 + "&location=0");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						method_1(text3);
					}
				}
				break;
			case 434841374u:
				if (text2 == "16")
				{
					string text3 = new RequestXNet().E58EB99F("https://wwproxy.com/api/client/proxy/available?key=" + string_0 + "&provinceId=-1");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.BDB80B23("message") == "success")
					{
						method_1(text3);
					}
				}
				break;
			case 418063755u:
				if (text2 == "15")
				{
					string text3 = new RequestXNet().E58EB99F("http://api.proxyfb.com/api/changeProxy.php?key=" + string_0);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						method_1(text3);
					}
				}
				break;
			case 468396612u:
				if (text2 == "10")
				{
					string e13C = "{\"api_key\": \"" + string_0 + "\"}";
					string text3 = F0A7B98A("https://tmproxy.com/api/proxy/get-new-proxy", e13C);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					string value = Regex.Match(gClass.BDB80B23("message"), "\\d+").Value;
					if (value == "" || int.Parse(value) == 0)
					{
						A40F8204 = JObject.Parse(text3)["data"]!["https"]!.ToString();
					}
				}
				break;
			case 451618993u:
				if (text2 == "17")
				{
					string text3 = new RequestXNet().E58EB99F("https://api.kiotproxy.com/api/v1/proxies/new?key=" + string_0);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						method_1(text3);
					}
				}
				break;
			case 501951850u:
				if (text2 == "12")
				{
					string text3 = D4198D90("http://proxy.shoplike.vn/Api/getNewProxy?access_token=" + string_0);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.BDB80B23("status") == "success")
					{
						A40F8204 = JObject.Parse(text3)["data"]!["proxy"]!.ToString();
					}
				}
				break;
			case 485174231u:
			{
				if (!(text2 == "11"))
				{
					break;
				}
				string text3;
				GClass4 gClass;
				while (true)
				{
					text3 = new MaxCareLibPro.RequestXNet().RequestGet("https://api.proxyv6.net/key/get-new-ip?api_key_rotating=" + string_0 + "&authIp=" + Commom.BD994637());
					gClass = new GClass4(text3, F79F9AB5: true);
					if (!(gClass.BDB80B23("message") == "GET_IP_TOO_FAST"))
					{
						break;
					}
					int num = Convert.ToInt32(JObject.Parse(text3)["data"]!["remainTime"]!.ToString());
					Commom.smethod_52(num + 1);
				}
				if (gClass.BDB80B23("message") == "SUCCESS")
				{
					A40F8204 = JObject.Parse(text3)["data"]!["host"]!.ToString() + ":" + JObject.Parse(text3)["data"]!["port"]!.ToString();
				}
				break;
			}
			case 2297598368u:
				if (text2 == "25")
				{
					string text3 = new RequestXNet().E58EB99F("https://proxyxoay.org/api/get.php?key=" + string_0 + "&&nhamang=random&&tinhthanh=0");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_2("status") == 100)
					{
						A40F8204 = gClass.BDB80B23("proxyhttp");
					}
				}
				break;
			case 839689206u:
				if (text2 == "7")
				{
					string text3 = new RequestXNet().E58EB99F("http://proxy.tinsoftsv.com/api/changeProxy.php?key=" + string_0);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						method_1(text3);
					}
				}
				break;
			case 2347931225u:
				if (text2 == "26")
				{
					string text3 = new RequestXNet().E58EB99F("https://api.vnproxy.com/webservice/changeIP?key=" + string_0 + "&location=random&proxyType=http");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.BDB80B23("status") == "OK")
					{
						A40F8204 = JObject.Parse(text3)["data"]!["ipv4"]!.ToString();
					}
				}
				break;
			case 2314375987u:
				if (text2 == "24")
				{
					string text3 = new RequestXNet().E58EB99F("https://proxyxoay.shop/api/get.php?key=" + string_0 + "&&nhamang=random&&tinhthanh=0");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_2("status") == 100)
					{
						A40F8204 = gClass.BDB80B23("proxyhttp");
					}
				}
				break;
			case 2381486463u:
				if (text2 == "20")
				{
					string text3 = new RequestXNet().E58EB99F("https://be.raiproxy.com/api/package/" + string_0 + "/reload");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success") || gClass.method_3("status"))
					{
						method_1(text3);
					}
				}
				break;
			case 2364708844u:
				if (text2 == "21")
				{
					string text3 = new RequestXNet().E58EB99F("https://api.nortonproxy.com/get-new-proxy?api_key=" + string_0 + "&id_location=1");
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_2("code") == 0)
					{
						method_1(text3);
					}
				}
				break;
			case 2415041701u:
				if (text2 == "22")
				{
					string text3 = new RequestXNet().method_1("https://fproxy.vn/api/items/get-new-proxy", "api_key=" + string_0);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("status"))
					{
						method_1(text3);
					}
				}
				break;
			case 2398264082u:
				if (text2 == "23")
				{
					string text3 = new RequestXNet().E58EB99F("https://betacaptcha.com/api/change_proxy?api_key=" + string_0);
					GClass4 gClass = new GClass4(text3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = gClass.BDB80B23("proxy");
					}
				}
				break;
			}
		}
		catch
		{
		}
		return !string.IsNullOrEmpty(string_1);
	}

	public string method_0()
	{
		while (!method_1())
		{
		}
		return A40F8204;
	}

	public bool method_1(string string_3 = "")
	{
		A40F8204 = "";
		try
		{
			string text = string_2;
			string text2 = text;
			switch (AFAE75A0.smethod_0(text2))
			{
			case 350953279u:
				if (text2 == "19")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("https://api.netproxy.io/api/rotateProxy/getCurrentProxy?apiKey=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["proxy"]!.ToString();
					}
				}
				break;
			case 334175660u:
				if (text2 == "18")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("https://fproxy.me/api/GetCurrent.php?api_key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["proxy"]!.ToString();
					}
				}
				break;
			case 451618993u:
				if (text2 == "17")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("https://api.kiotproxy.com/api/v1/proxies/current?key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["http"]!.ToString();
					}
				}
				break;
			case 434841374u:
				if (text2 == "16")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("https://wwproxy.com/api/client/proxy/current?key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.BDB80B23("message") == "success")
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["proxy"]!.ToString();
					}
				}
				break;
			case 418063755u:
				if (text2 == "15")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("http://api.proxyfb.com/api/getProxy.php?key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = gClass.BDB80B23("proxy");
					}
				}
				break;
			case 839689206u:
				if (text2 == "7")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("http://proxy.tinsoftsv.com/api/getProxy.php?key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = gClass.BDB80B23("proxy");
					}
				}
				break;
			case 501951850u:
				if (text2 == "12")
				{
					string_3 = D4198D90("http://proxy.shoplike.vn/Api/getCurrentProxy?access_token=" + string_0);
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.BDB80B23("status") == "success")
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["proxy"]!.ToString();
					}
				}
				break;
			case 468396612u:
				if (text2 == "10")
				{
					string e13C = "{\"api_key\": \"" + string_0 + "\"}";
					string_3 = F0A7B98A("https://tmproxy.com/api/proxy/get-current-proxy", e13C);
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.BDB80B23("code") == "0")
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["https"]!.ToString();
					}
				}
				break;
			case 2415041701u:
				if (text2 == "22")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().method_1("https://fproxy.vn/api/items/get-current-proxy", "api_key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("status") || gClass.method_2("code") == 0)
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["http"]!.ToString();
					}
				}
				break;
			case 2381486463u:
				if (text2 == "20")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("https://be.raiproxy.com/api/package/" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_3("success"))
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["proxy"]!.ToString();
					}
					else if (gClass.method_3("status"))
					{
						A40F8204 = JObject.Parse(string_3)["result"]!["http"]!.ToString();
					}
				}
				break;
			case 2364708844u:
				if (text2 == "21")
				{
					if (string_3 == "")
					{
						string_3 = new RequestXNet().E58EB99F("https://api.nortonproxy.com/get-current-proxy?api_key=" + string_0);
					}
					GClass4 gClass = new GClass4(string_3, F79F9AB5: true);
					if (gClass.method_2("code") == 0)
					{
						A40F8204 = JObject.Parse(string_3)["data"]!["https"]!.ToString();
					}
				}
				break;
			}
		}
		catch (Exception)
		{
		}
		return !string.IsNullOrEmpty(string_1);
	}

	private bool method_2(int int_3 = 10)
	{
		try
		{
			DateTime dateTime = new DateTime(2001, 1, 1);
			long ticks = DateTime.Now.Ticks - dateTime.Ticks;
			int num = (int)new TimeSpan(ticks).TotalSeconds;
			if (num - int_0 >= int_3)
			{
				int_0 = num;
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	public static string ExecuteHttpWithRetry(Func<string> action, int maxRetries = 3, int initialDelayMs = 500)
	{
		int delay = initialDelayMs;
		for (int attempt = 1; attempt <= maxRetries; attempt++)
		{
			try
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
				string res = action();
				if (!string.IsNullOrEmpty(res)) return res;
			}
			catch (Exception ex)
			{
				if (attempt == maxRetries)
				{
					Commom.smethod_57(null, ex, $"API request fail after {maxRetries} retries");
					return "";
				}
			}
			Thread.Sleep(delay);
			delay *= 2; // Exponential backoff: 500ms -> 1000ms -> 2000ms
		}
		return "";
	}

	/// <summary>
	/// Gửi GET request với cơ chế Retry Exponential Backoff và timeout 8s chống nghẽn thread pool
	/// </summary>
	public static string D4198D90(string string_3)
	{
		return ExecuteHttpWithRetry(() =>
		{
			var req = (HttpWebRequest)WebRequest.Create(string_3);
			req.Method = "GET";
			req.Timeout = 8000;
			req.ReadWriteTimeout = 8000;
			req.KeepAlive = false;
			req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
			using (var resp = req.GetResponse())
			using (var stream = resp.GetResponseStream())
			using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}, 3, 500);
	}

	/// <summary>
	/// Gửi POST JSON request với cơ chế Retry Exponential Backoff và timeout 8s chống nghẽn thread pool
	/// </summary>
	private static string F0A7B98A(string string_3, string E13C2238)
	{
		return ExecuteHttpWithRetry(() =>
		{
			var req = (HttpWebRequest)WebRequest.Create(string_3);
			req.Method = "POST";
			req.ContentType = "application/json";
			req.Timeout = 8000;
			req.ReadWriteTimeout = 8000;
			req.KeepAlive = false;
			req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
			byte[] bytes = Encoding.UTF8.GetBytes(E13C2238);
			req.ContentLength = bytes.Length;
			using (var stream = req.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			using (var resp = req.GetResponse())
			using (var respStream = resp.GetResponseStream())
			using (var reader = new System.IO.StreamReader(respStream, Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}, 3, 500);
	}
}
