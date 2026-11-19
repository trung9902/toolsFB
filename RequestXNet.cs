using System;
using System.IO;
using System.Linq;
using System.Net;
using Leaf.xNet;

public class RequestXNet
{
	internal Leaf.xNet.HttpRequest F089DBB3;

	public RequestXNet(string string_0 = "", string D5BC762E = "", string string_1 = "", int CE34D893 = 0)
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		if (string.IsNullOrEmpty(D5BC762E))
		{
			D5BC762E = ModernUserAgentHub.GetRandomDesktopChrome();
		}
		F089DBB3 = new Leaf.xNet.HttpRequest
		{
			KeepAlive = true,
			AllowAutoRedirect = true,
			Cookies = new CookieStorage(),
			UserAgent = D5BC762E,
			ConnectTimeout = 3000,
			ReadWriteTimeout = 3000
		};
		F089DBB3.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
		F089DBB3.AddHeader("Accept-Language", "en-US,en;q=0.9");
		F089DBB3.AddHeader("sec-fetch-site", "same-origin");
		if (string_0 != "")
		{
			method_3(string_0);
		}
		if (string.IsNullOrWhiteSpace(string_1))
		{
			return;
		}
		ProxyInfo proxyInfo = ProxyHelper.Parse(string_1, CE34D893);
		if (proxyInfo.IsValid)
		{
			ProxyClient proxyClient;
			if (proxyInfo.ProxyType == 0)
			{
				if (proxyInfo.HasAuth)
				{
					proxyClient = new HttpProxyClient(proxyInfo.Host, proxyInfo.Port, proxyInfo.Username, proxyInfo.Password);
				}
				else
				{
					proxyClient = new HttpProxyClient(proxyInfo.Host, proxyInfo.Port);
				}
			}
			else
			{
				if (proxyInfo.HasAuth)
				{
					proxyClient = new Socks5ProxyClient(proxyInfo.Host, proxyInfo.Port, proxyInfo.Username, proxyInfo.Password);
				}
				else
				{
					proxyClient = new Socks5ProxyClient(proxyInfo.Host, proxyInfo.Port);
				}
			}
			if (proxyClient != null)
			{
				proxyClient.ConnectTimeout = 3000;
				proxyClient.ReadWriteTimeout = 3000;
				F089DBB3.Proxy = proxyClient;
			}
		}
	}

	public int ConnectTimeout
	{
		get => F089DBB3 != null ? F089DBB3.ConnectTimeout : 3000;
		set
		{
			if (F089DBB3 != null)
			{
				F089DBB3.ConnectTimeout = value;
				if (F089DBB3.Proxy != null)
				{
					F089DBB3.Proxy.ConnectTimeout = value;
				}
			}
		}
	}

	public int ReadWriteTimeout
	{
		get => F089DBB3 != null ? F089DBB3.ReadWriteTimeout : 3000;
		set
		{
			if (F089DBB3 != null)
			{
				F089DBB3.ReadWriteTimeout = value;
				if (F089DBB3.Proxy != null)
				{
					F089DBB3.Proxy.ReadWriteTimeout = value;
				}
			}
		}
	}

	public string E58EB99F(string string_0)
	{
		for (int i = 0; i < 2 && !Base.smethod_5(); i++)
		{
			try
			{
				F089DBB3.AddHeader("sec-fetch-site", "same-origin");
				return F089DBB3.Get(string_0).ToString();
			}
			catch (Exception ex)
			{
				string text = ex.ToString();
				try
				{
					if (F089DBB3.Response != null && !string.IsNullOrEmpty(F089DBB3.Response.ToString()))
					{
						text = F089DBB3.Response.ToString();
					}
				}
				catch
				{
				}
				if (text.Contains("502") || 
				    text.Contains("timed out") || 
				    text.Contains("Timeout") ||
				    text.Contains("A connection attempt failed because the connected party did not properly respond after a period of time"))
				{
					continue;
				}
			}
			break;
		}
		return "";
	}

	public byte[] method_0(string string_0)
	{
		try
		{
			return F089DBB3.Get(string_0).ToBytes();
		}
		catch (Exception)
		{
			return F089DBB3.Response.ToBytes();
		}
	}

	public string method_1(string string_0, string D9933526 = "", string CF01DE82 = "application/x-www-form-urlencoded")
	{
		for (int i = 0; i < 5 && !Base.smethod_5(); i++)
		{
			try
			{
				F089DBB3.AddHeader("sec-fetch-site", "same-origin");
				if (D9933526 == "" || CF01DE82 == "")
				{
					return F089DBB3.Post(string_0).ToString();
				}
				return F089DBB3.Post(string_0, D9933526, CF01DE82).ToString();
			}
			catch (Exception ex)
			{
				string text = ex.ToString();
				try
				{
					if (!string.IsNullOrEmpty(F089DBB3.Response.ToString()))
					{
						text = F089DBB3.Response.ToString();
					}
				}
				catch
				{
				}
				if (text.Contains("A connection attempt failed because the connected party did not properly respond after a period of time"))
				{
					continue;
				}
			}
			break;
		}
		return "";
	}

	public string E2028331(string string_0, string E4B8F894, string string_1, string[] string_2)
	{
		foreach (string text in string_2)
		{
			string[] array = text.Split(':');
			if (array.Count() > 1)
			{
				F089DBB3.AddHeader(array[0], array[1].Trim());
			}
		}
		return method_1(string_0, E4B8F894, string_1);
	}

	public string method_2(string string_0, string string_1)
	{
		for (int i = 0; i < 5 && !Base.smethod_5(); i++)
		{
			try
			{
				F089DBB3.AddHeader("offset", "0");
				F089DBB3.AddHeader("x-entity-length", new FileInfo(string_1).Length.ToString());
				F089DBB3.AddHeader("x-entity-name", Path.GetFileName(string_1));
				F089DBB3.AddHeader("x-entity-type", "image/jpeg");
				return F089DBB3.Post(string_0, new FileContent(string_1)).ToString();
			}
			catch (Exception ex)
			{
				string text = ex.ToString();
				try
				{
					if (!string.IsNullOrEmpty(F089DBB3.Response.ToString()))
					{
						text = F089DBB3.Response.ToString();
					}
				}
				catch
				{
				}
				if (text.Contains("A connection attempt failed because the connected party did not properly respond after a period of time"))
				{
					continue;
				}
			}
			break;
		}
		return "";
	}

	public void method_3(string string_0)
	{
		string[] array = string_0.Split(';');
		string[] array2 = array;
		foreach (string text in array2)
		{
			string[] array3 = text.Split('=');
			if (array3.Count() > 1)
			{
				try
				{
					F089DBB3.Cookies.Set(array3[0], array3[1]);
				}
				catch
				{
				}
			}
		}
	}

	public string method_4()
	{
		return F089DBB3.Cookies.ToString();
	}

	public string method_5()
	{
		return F089DBB3.Address.AbsoluteUri;
	}

	internal void D49E58B4(string string_0, string string_1)
	{
		F089DBB3.AddHeader(string_0, string_1);
	}
}
