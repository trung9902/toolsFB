using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class MinProxyVN : ABB2B510
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int int_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string A911A5B2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string E53C1BA1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int CB335E3A;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string string_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int int_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal int int_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int int_3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string D19E1236;

	internal object object_0 = new object();

	internal object B4AA92AA = new object();

	internal int int_4 = 0;

	internal int int_5 = 0;

	internal int int_6 = 0;

	internal int int_7 = 3;

	internal bool A88A2F81 = true;

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

	public string D61B363B
	{
		[CompilerGenerated]
		get
		{
			return A911A5B2;
		}
		[CompilerGenerated]
		set
		{
			A911A5B2 = value;
		}
	}

	public string CB10C9AD
	{
		[CompilerGenerated]
		get
		{
			return E53C1BA1;
		}
		[CompilerGenerated]
		set
		{
			E53C1BA1 = value;
		}
	}

	public int EE222CA5
	{
		[CompilerGenerated]
		get
		{
			return CB335E3A;
		}
		[CompilerGenerated]
		set
		{
			CB335E3A = value;
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

	public int Int32_1
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
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

	public int Int32_3
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public string String_1
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

	public string String_2
	{
		[CompilerGenerated]
		get
		{
			return D19E1236;
		}
		[CompilerGenerated]
		set
		{
			D19E1236 = value;
		}
	}

	public MinProxyVN(int D2B8F52E, string string_2, int A7A8BFA5, int int_8)
	{
		Int32_0 = D2B8F52E;
		D61B363B = string_2;
		CB10C9AD = "";
		String_0 = "";
		Int32_2 = 0;
		Int32_3 = 0;
		EE222CA5 = A7A8BFA5;
		int_7 = int_8;
		int_4 = 0;
		int_5 = 0;
		int_6 = 0;
		String_1 = "";
		String_2 = "";
	}

	public static bool smethod_0(int int_8, string string_2)
	{
		string text = "";
		text = ((int_8 != 0) ? F386EA20("http://dash.minproxy.vn/api/rotating/v1/proxy_v4/get-status?api_key=" + string_2) : F386EA20("http://dash.minproxy.vn/api/rotating/v1/proxy/get-status?api_key=" + string_2));
		if (text != "")
		{
			try
			{
				JObject jObject = JObject.Parse(text);
				if (jObject["code"]!.ToString() == "1")
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

	public string method_0()
	{
		lock (object_0)
		{
			if (int_5 == 0)
			{
				if (int_6 > 0 && int_6 < int_7)
				{
					if (EBBA88B3() < 30 && B9903930() != 1)
					{
						return "0";
					}
				}
				else if (B9903930() != 1)
				{
					return "0";
				}
			}
			else
			{
				if (int_6 >= int_7)
				{
					return "2";
				}
				if (EBBA88B3() < 30 && B9903930() != 1)
				{
					return "0";
				}
			}
			int_6++;
			int_5++;
			return "1";
		}
	}

	public int EBBA88B3()
	{
		method_2();
		return Int32_1;
	}

	public void method_1()
	{
		lock (B4AA92AA)
		{
			int_5--;
			if (int_5 == 0 && int_6 == int_7)
			{
				A88A2F81 = true;
				int_6 = 0;
			}
		}
	}

	public int B9903930()
	{
		CB10C9AD = "";
		String_0 = "";
		Int32_2 = 0;
		string text = "";
		text = ((Int32_0 != 0) ? F386EA20("http://dash.minproxy.vn/api/rotating/v1/proxy_v4/get-new-proxy?api_key=" + D61B363B) : F386EA20("http://dash.minproxy.vn/api/rotating/v1/proxy/get-new-proxy?api_key=" + D61B363B));
		if (text != "")
		{
			if (text.Contains("api expired"))
			{
				return -1;
			}
			if (text.Contains("api wrong") || text.Contains("error"))
			{
				return -2;
			}
			try
			{
				JObject jObject = JObject.Parse(text);
				string value = Regex.Match(jObject["data"]!["next_request"]!.ToString(), "\\d+").Value;
				Int32_3 = ((!(value == "")) ? int.Parse(value) : 0);
				if (jObject["code"]!.ToString() == "2")
				{
					String_1 = jObject["data"]!["ip_allow"]!.ToString();
					String_2 = jObject["data"]!["your_ip"]!.ToString();
					if (Int32_0 == 0)
					{
						CB10C9AD = jObject["data"]!["http_proxy"]!.ToString();
						string[] array = CB10C9AD.Split(':');
						String_0 = array[0];
						Int32_2 = int.Parse(array[1]);
						return 1;
					}
					if (Int32_0 == 1)
					{
						if (EE222CA5 == 0)
						{
							CB10C9AD = jObject["data"]!["http_proxy_ipv4"]!.ToString();
							string[] array2 = CB10C9AD.Split(':');
							String_0 = array2[0];
							Int32_2 = int.Parse(array2[1]);
						}
						else if (EE222CA5 == 1)
						{
							CB10C9AD = jObject["data"]!["http_proxy_ipv6"]!.ToString();
							string[] array3 = CB10C9AD.Split(':');
							String_0 = array3[0];
							Int32_2 = int.Parse(array3[1]);
						}
						else if (EE222CA5 == 2)
						{
							CB10C9AD = jObject["data"]!["sock_proxy_ipv4"]!.ToString();
							string[] array4 = CB10C9AD.Split(':');
							String_0 = array4[0];
							Int32_2 = int.Parse(array4[1]);
						}
						else
						{
							CB10C9AD = jObject["data"]!["sock_proxy_ipv6"]!.ToString();
							string[] array5 = CB10C9AD.Split(':');
							String_0 = array5[0];
							Int32_2 = int.Parse(array5[1]);
						}
						return 1;
					}
				}
				return 0;
			}
			catch
			{
			}
		}
		Int32_3 = 0;
		return 0;
	}

	public bool method_2()
	{
		Int32_3 = 0;
		CB10C9AD = "";
		String_0 = "";
		Int32_2 = 0;
		Int32_1 = 0;
		string text = "";
		text = ((Int32_0 != 0) ? F386EA20("http://dash.minproxy.vn/api/rotating/v1/proxy_v4/get-current-proxy?api_key=" + D61B363B) : F386EA20("http://dash.minproxy.vn/api/rotating/v1/proxy/get-current-proxy?api_key=" + D61B363B));
		if (text != "")
		{
			try
			{
				JObject jObject = JObject.Parse(text);
				if (jObject["code"]!.ToString() == "1")
				{
					Int32_3 = Convert.ToInt32(jObject["data"]!["next_request"]!.ToString());
					Int32_1 = Convert.ToInt32(jObject["data"]!["timeout"]!.ToString());
					String_1 = jObject["data"]!["ip_allow"]!.ToString();
					String_2 = jObject["data"]!["your_ip"]!.ToString();
					if (Int32_0 == 0)
					{
						CB10C9AD = jObject["data"]!["http_proxy"]!.ToString();
						string[] array = CB10C9AD.Split(':');
						String_0 = array[0];
						Int32_2 = int.Parse(array[1]);
						return true;
					}
					if (Int32_0 == 1)
					{
						if (EE222CA5 == 0)
						{
							CB10C9AD = jObject["data"]!["http_proxy_ipv4"]!.ToString();
							string[] array2 = CB10C9AD.Split(':');
							String_0 = array2[0];
							Int32_2 = int.Parse(array2[1]);
						}
						else if (EE222CA5 == 1)
						{
							CB10C9AD = jObject["data"]!["http_proxy_ipv6"]!.ToString();
							string[] array3 = CB10C9AD.Split(':');
							String_0 = array3[0];
							Int32_2 = int.Parse(array3[1]);
						}
						else if (EE222CA5 == 2)
						{
							CB10C9AD = jObject["data"]!["sock_proxy_ipv4"]!.ToString();
							string[] array4 = CB10C9AD.Split(':');
							String_0 = array4[0];
							Int32_2 = int.Parse(array4[1]);
						}
						else
						{
							CB10C9AD = jObject["data"]!["sock_proxy_ipv6"]!.ToString();
							string[] array5 = CB10C9AD.Split(':');
							String_0 = array5[0];
							Int32_2 = int.Parse(array5[1]);
						}
						return true;
					}
				}
			}
			catch
			{
			}
		}
		return false;
	}

	public string method_3()
	{
		while (!method_2())
		{
		}
		return CB10C9AD;
	}

	public static string F386EA20(string string_2)
	{
		string text = "";
		try
		{
			new HttpClient();
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			Task<string> task = Task.Run(() => RequestHelper.GetURI(new Uri(string_2)));
			task.Wait();
			return task.Result;
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "Request get");
			return "";
		}
	}
}
