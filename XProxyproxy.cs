using System;
using System.Threading;
using Newtonsoft.Json.Linq;

internal class XProxyproxy : ABB2B510
{
	internal int int_0;

	internal string string_0;

	internal string string_1;

	internal string C1BB0FBE = "";

	internal bool E183403C = true;

	internal int A3391CAD = 0;

	internal int int_1 = 0;

	internal int CEA46DB5 = 3;

	public XProxyproxy(string string_2, string string_3, int int_2, int int_3)
	{
		string_0 = string_2;
		string_1 = string_3;
		CEA46DB5 = int_3;
		C1BB0FBE = "";
		int_0 = int_2;
	}

	private void method_0(string string_2)
	{
	}

	public int method_1()
	{
		bool flag = false;
		try
		{
			_ = Environment.TickCount;
			string_0 = string_0.TrimEnd('/');
			string text = string_0 + "/reset?proxy=" + string_1.Split(':')[0] + ":" + string_1.Split(':')[1];
			RequestXNet requestXNet = new RequestXNet();
			string text2 = requestXNet.E58EB99F(text);
			if (text2.Contains("reset_too_much"))
			{
				Thread.Sleep(5000);
				return 2;
			}
			JObject jObject = JObject.Parse(text2);
			if (jObject.ContainsKey("msg") && (JObject.Parse(text2)["msg"]!.ToString() == "command_sent" || JObject.Parse(text2)["msg"]!.ToString() == "OK" || JObject.Parse(text2)["msg"]!.ToString().ToLower() == "ok"))
			{
				flag = true;
			}
			else if (jObject.ContainsKey("error_code") && JObject.Parse(text2)["error_code"]!.ToString().ToLower() == "0")
			{
				flag = true;
			}
			else
			{
				method_0(text + ": " + text2);
			}
		}
		catch (Exception)
		{
		}
		return flag ? 1 : 0;
	}

	public int method_2()
	{
		try
		{
			int num = 0;
			for (int i = 0; i < 5; i++)
			{
				num = method_1();
				if (num == 1)
				{
					Commom.smethod_52(3.0);
					num = (A20D1A35() ? 1 : 0);
				}
				if (num == 1)
				{
					break;
				}
			}
			return num;
		}
		catch
		{
		}
		return 0;
	}

	public bool A20D1A35(int int_2 = -1)
	{
		if (int_2 == -1)
		{
			int_2 = C5034B95.smethod_0("configGeneral").method_2("nudDelayResetXProxy", 5) * 60;
		}
		int tickCount = Environment.TickCount;
		bool flag = false;
		try
		{
			string_0 = string_0.TrimEnd('/');
			string text = string_0 + "/status?proxy=" + string_1.Split(':')[0] + ":" + string_1.Split(':')[1];
			RequestXNet requestXNet = new RequestXNet();
			string text2 = "";
			do
			{
				text2 = requestXNet.E58EB99F(text);
				try
				{
					if (!text2.Contains("public_ip_v6") && !text2.Contains("public_ip"))
					{
						if (flag = Convert.ToBoolean(JObject.Parse(text2)["status"]!.ToString()))
						{
							flag = JObject.Parse(text2)["msg"]!.ToString() == "MODEM_READY";
						}
					}
					else
					{
						string text3 = string_1.Split(':')[1];
						flag = ((text3.StartsWith("4") || text3.StartsWith("5")) ? (JObject.Parse(text2)["public_ip"]!.ToString() != "" && JObject.Parse(text2)["public_ip"]!.ToString() != "CONNECT_INTERNET_ERROR") : ((!text3.StartsWith("6") && !text3.StartsWith("7")) ? Convert.ToBoolean(JObject.Parse(text2)["status"]!.ToString()) : (JObject.Parse(text2)["public_ip_v6"]!.ToString() != "" && JObject.Parse(text2)["public_ip_v6"]!.ToString() != "CONNECT_INTERNET_ERROR")));
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
			while (Environment.TickCount - tickCount < int_2 * 1000);
			return flag;
		}
		catch (Exception)
		{
			return flag;
		}
	}

	public void method_3()
	{
		A3391CAD--;
		if (C5034B95.smethod_0("configGeneral").method_2("typeRunXproxy") == 0 && A3391CAD == 0 && int_1 == CEA46DB5)
		{
			int_1 = 0;
		}
	}
}
