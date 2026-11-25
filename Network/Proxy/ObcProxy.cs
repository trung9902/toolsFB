using System;
using System.Threading;
using Newtonsoft.Json.Linq;

public class ObcProxy : ABB2B510
{
	internal int ED054DB9;

	internal string string_0;

	internal string D1AC813F;

	internal string F5BEF18F = "";

	internal bool bool_0 = true;

	internal int int_0 = 0;

	internal int C701F934 = 0;

	internal int E90A3910 = 3;

	internal string A715FE10 = "";

	public ObcProxy(string EF08B50B, string string_1, int AE2FE6B4, int int_1, string string_2)
	{
		string_0 = EF08B50B;
		D1AC813F = string_1;
		E90A3910 = int_1;
		F5BEF18F = "";
		ED054DB9 = AE2FE6B4;
		method_6(string_2);
	}

	private void method_0(string string_1)
	{
	}

	public bool method_1()
	{
		bool result = false;
		try
		{
			_ = Environment.TickCount;
			string_0 = string_0.TrimEnd('/');
			string text = string_0 + "/reset?proxy=" + D1AC813F;
			RequestXNet requestXNet = new RequestXNet();
			string text2 = requestXNet.E58EB99F(text);
			method_0(text + ": " + text2);
			JObject jObject = JObject.Parse(text2);
			if (jObject.ContainsKey("msg") && (JObject.Parse(text2)["msg"]!.ToString() == "command_sent" || JObject.Parse(text2)["msg"]!.ToString() == "OK" || JObject.Parse(text2)["msg"]!.ToString().ToLower() == "ok"))
			{
				result = true;
				return result;
			}
			if (jObject.ContainsKey("error_code") && JObject.Parse(text2)["error_code"]!.ToString().ToLower() == "0")
			{
				result = true;
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public bool method_2()
	{
		bool result = false;
		try
		{
			_ = Environment.TickCount;
			string_0 = string_0.TrimEnd('/');
			string text = string_0 + "/reset?proxy=" + D1AC813F;
			RequestXNet requestXNet = new RequestXNet();
			string text2 = requestXNet.E58EB99F(text);
			method_0(text + ": " + text2);
			JObject jObject = JObject.Parse(text2);
			bool flag = false;
			if (jObject.ContainsKey("msg") && (JObject.Parse(text2)["msg"]!.ToString() == "command_sent" || JObject.Parse(text2)["msg"]!.ToString() == "OK" || JObject.Parse(text2)["msg"]!.ToString().ToLower() == "ok"))
			{
				flag = true;
			}
			else if (jObject.ContainsKey("error_code") && JObject.Parse(text2)["error_code"]!.ToString().ToLower() == "0")
			{
				flag = true;
			}
			if (flag)
			{
				return method_4();
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public void method_3(int int_1 = 1)
	{
		int_0--;
		if (int_1 == 0 && int_0 == 0 && C701F934 == E90A3910)
		{
			C701F934 = 0;
		}
	}

	public bool method_4(int D792CB13 = -1)
	{
		if (D792CB13 == -1)
		{
			D792CB13 = C5034B95.smethod_0("configGeneral").method_2("nudDelayCheckIPObcProxy", 5) * 60;
		}
		int tickCount = Environment.TickCount;
		bool flag = false;
		try
		{
			string_0 = string_0.TrimEnd('/');
			string text = string_0 + "/status?proxy=" + D1AC813F;
			RequestXNet requestXNet = new RequestXNet();
			string text2 = "";
			do
			{
				text2 = requestXNet.E58EB99F(text);
				method_0(text + ": " + text2);
				try
				{
					if (!text2.Contains("public_ip_v6") && !text2.Contains("public_ip"))
					{
						flag = Convert.ToBoolean(JObject.Parse(text2)["status"]!.ToString());
					}
					else
					{
						string text3 = D1AC813F.Split(':')[1];
						if (text3.StartsWith("4") || text3.StartsWith("5"))
						{
							flag = JObject.Parse(text2)["public_ip"]!.ToString() != "" && JObject.Parse(text2)["public_ip"]!.ToString() != "CONNECT_INTERNET_ERROR";
						}
						else if (text3.StartsWith("6") || text3.StartsWith("7"))
						{
							flag = JObject.Parse(text2)["public_ip_v6"]!.ToString() != "" && JObject.Parse(text2)["public_ip_v6"]!.ToString() != "CONNECT_INTERNET_ERROR";
						}
					}
				}
				catch
				{
					flag = JObject.Parse(text2)["error_code"]!.ToString() == "0";
				}
				Thread.Sleep(1000);
				if (flag)
				{
					return flag;
				}
			}
			while (Environment.TickCount - tickCount < D792CB13 * 1000);
			return flag;
		}
		catch
		{
			return flag;
		}
	}

	public string method_5()
	{
		return A715FE10;
	}

	public void method_6(string string_1)
	{
		A715FE10 = string_1;
	}

	public string method_7()
	{
		return string_0;
	}

	public string method_8()
	{
		return D1AC813F.Split(':')[1];
	}
}
