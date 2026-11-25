using System;
using System.Linq;
using System.Net;
using System.Text;
using HttpRequest;

public class RequestHttp
{
	internal RequestHTTP requestHTTP_0;

	internal string C112EF19;

	internal string string_0;

	public RequestHttp(string D5108E27 = "", string string_1 = "", string string_2 = "", int int_0 = 0)
	{
		if (string.IsNullOrEmpty(string_1))
		{
			C112EF19 = ModernUserAgentHub.GetRandomDesktopChrome();
		}
		else
		{
			C112EF19 = string_1;
		}
		requestHTTP_0 = new RequestHTTP();
		requestHTTP_0.SetSSL(SecurityProtocolType.Tls12);
		requestHTTP_0.SetKeepAlive(k: true);
		requestHTTP_0.SetDefaultHeaders(new string[2]
		{
			"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
			"user-agent: " + C112EF19
		});
		if (D5108E27 != "")
		{
			method_1(D5108E27);
		}
		string_0 = string_2;
	}

	public string method_0(string string_1)
	{
		if (string_0 != "")
		{
			if (string_0.Contains(":"))
			{
				return requestHTTP_0.Request("GET", string_1, null, null, autoredrirect: true, new WebProxy(string_0.Split(':')[0], Convert.ToInt32(string_0.Split(':')[1]))).ToString();
			}
			return requestHTTP_0.Request("GET", string_1, null, null, autoredrirect: true, new WebProxy("127.0.0.1", Convert.ToInt32(string_0))).ToString();
		}
		return requestHTTP_0.Request("GET", string_1).ToString();
	}

	public string EF076293(string D4054BA6, string string_1 = "")
	{
		if (string_0 != "")
		{
			if (string_0.Contains(":"))
			{
				return requestHTTP_0.Request("POST", D4054BA6, null, Encoding.ASCII.GetBytes(string_1), autoredrirect: true, new WebProxy(string_0.Split(':')[0], Convert.ToInt32(string_0.Split(':')[1]))).ToString();
			}
			return requestHTTP_0.Request("POST", D4054BA6, null, Encoding.ASCII.GetBytes(string_1), autoredrirect: true, new WebProxy("127.0.0.1", Convert.ToInt32(string_0))).ToString();
		}
		return requestHTTP_0.Request("POST", D4054BA6, null, Encoding.ASCII.GetBytes(string_1)).ToString();
	}

	public void method_1(string string_1)
	{
		string[] array = string_1.Split(';');
		string text = "";
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			string[] array3 = text2.Split('=');
			if (array3.Count() > 1)
			{
				try
				{
					text = text + array3[0] + "=" + array3[1] + ";";
				}
				catch
				{
				}
			}
		}
		requestHTTP_0.SetDefaultHeaders(new string[3]
		{
			"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8;charset=UTF-8",
			"user-agent: " + C112EF19,
			"cookie: " + text
		});
	}

	public string CC81ACA4()
	{
		return requestHTTP_0.GetCookiesString();
	}
}
