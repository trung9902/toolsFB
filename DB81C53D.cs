using System;
using Newtonsoft.Json.Linq;

public class DB81C53D
{
	public static string smethod_0(string string_0, string string_1)
	{
		string text = "https://omocaptcha.com";
		try
		{
			string text2 = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiZGF0YSI6IHsKCQkidHlwZV9qb2JfaWQiOiAiMzAiLAoJCSJpbWFnZV9iYXNlNjQiOiAie2ltYWdlQmFzZTY0fSIKCX0KfQ==");
			text2 = text2.Replace("{apiKey}", string_0);
			text2 = text2.Replace("{imageBase64}", string_1);
			string text3 = new RequestXNet().method_1(text + "/api/createJob", text2, "application/json").ToString();
			string newValue = JObject.Parse(text3)["job_id"]!.ToString();
			text2 = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiam9iX2lkIjoge2pvYl9pZH0KfQ==");
			text2 = text2.Replace("{apiKey}", string_0);
			text2 = text2.Replace("{job_id}", newValue);
			int tickCount = Environment.TickCount;
			do
			{
				try
				{
					text3 = new RequestXNet().method_1(text + "/api/getJobResult", text2, "application/json");
				}
				catch (Exception)
				{
					continue;
				}
				string text4 = JObject.Parse(text3)["status"]!.ToString();
				if (!(text4 == "fail") && !(text4 == "timeout"))
				{
					if (text4 == "success")
					{
						break;
					}
					Commom.smethod_52(1.0);
					continue;
				}
				return "";
			}
			while (Environment.TickCount - tickCount < 300000);
			if (!text3.Contains("result"))
			{
				return "";
			}
			return JObject.Parse(text3)["result"]!.ToString();
		}
		catch (Exception)
		{
		}
		return "";
	}

	public static string CB9F2F03(string string_0, string A13F25A7, int int_0 = 0)
	{
		string text = "https://omocaptcha.com";
		if (int_0 == 1)
		{
			text = "https://mincaptcha.com";
		}
		try
		{
			string text2 = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiZGF0YSI6IHsKCQkidHlwZV9qb2JfaWQiOiAiNDEiLAoJCSJpbnB1dCI6ICJ7aW5wdXR9IgoJfQp9");
			text2 = text2.Replace("{apiKey}", string_0);
			text2 = text2.Replace("{input}", A13F25A7);
			string text3 = "";
			string text4 = "";
			int tickCount = Environment.TickCount;
			do
			{
				try
				{
					text3 = new RequestXNet().method_1(text + "/api/createJob", text2, "application/json");
					text4 = JObject.Parse(text3)["job_id"]!.ToString();
					if (text4 != "")
					{
						break;
					}
				}
				catch
				{
				}
				Commom.smethod_52(3.0);
			}
			while (Environment.TickCount - tickCount < 300000);
			if (text4 == "")
			{
				return "";
			}
			text2 = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiam9iX2lkIjoge2pvYl9pZH0KfQ==");
			text2 = text2.Replace("{apiKey}", string_0);
			text2 = text2.Replace("{job_id}", text4);
			do
			{
				text3 = new RequestXNet().method_1(text + "/api/getJobResult", text2, "application/json");
				string text5 = JObject.Parse(text3)["status"]!.ToString();
				if (!(text5 == "fail") && !(text5 == "timeout"))
				{
					if (text5 == "success")
					{
						break;
					}
					Commom.smethod_52(3.0);
					continue;
				}
				return "";
			}
			while (Environment.TickCount - tickCount < 300000);
			if (!text3.Contains("result"))
			{
				return "";
			}
			return JObject.Parse(text3)["result"]!.ToString();
		}
		catch (Exception)
		{
		}
		return "";
	}

	public static string smethod_1(string DF25BF9F, string string_0, string string_1)
	{
		string text = "https://omocaptcha.com";
		try
		{
			string text2 = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiZGF0YSI6IHsKCQkidHlwZV9qb2JfaWQiOiAiMiIsCgkJIndlYnNpdGVfdXJsIjogInt3ZWJzaXRlVVJMfSIsCgkJIndlYnNpdGVfa2V5IjogInt3ZWJzaXRlS2V5fSIKCX0KfQ==");
			text2 = text2.Replace("{apiKey}", DF25BF9F);
			text2 = text2.Replace("{websiteKey}", string_0);
			text2 = text2.Replace("{websiteURL}", string_1);
			string text3 = "";
			string text4 = "";
			int tickCount = Environment.TickCount;
			do
			{
				try
				{
					text3 = new RequestXNet().method_1(text + "/api/createJob", text2, "application/json");
					text4 = JObject.Parse(text3)["job_id"]!.ToString();
					if (text4 != "")
					{
						break;
					}
				}
				catch
				{
				}
				Commom.smethod_52(3.0);
			}
			while (Environment.TickCount - tickCount < 300000);
			if (text4 == "")
			{
				return "";
			}
			text2 = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiam9iX2lkIjoge2pvYl9pZH0KfQ==");
			text2 = text2.Replace("{apiKey}", DF25BF9F);
			text2 = text2.Replace("{job_id}", text4);
			do
			{
				text3 = new RequestXNet().method_1(text + "/api/getJobResult", text2, "application/json");
				string text5 = JObject.Parse(text3)["status"]!.ToString();
				if (!(text5 == "fail") && !(text5 == "timeout"))
				{
					if (text5 == "success")
					{
						break;
					}
					Commom.smethod_52(3.0);
					continue;
				}
				return "";
			}
			while (Environment.TickCount - tickCount < 300000);
			if (!text3.Contains("result"))
			{
				return "";
			}
			return JObject.Parse(text3)["result"]!.ToString();
		}
		catch (Exception)
		{
		}
		return "";
	}

	public static bool smethod_2(string B3AE023A)
	{
		if (B3AE023A == "")
		{
			return false;
		}
		string text = Commom.smethod_0("https://omocaptcha.com/", B3AE023A);
		return text != "";
	}
}
