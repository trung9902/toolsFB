using System;
using Newtonsoft.Json.Linq;

internal class Class21
{
	public static string smethod_0(string string_0, string string_1)
	{
		try
		{
			string text = Commom.smethod_50("ewogICAgICJBcGlrZXkiOiAie2FwaUtleX0iLAogICAgICJUeXBlIjogImltYWdldG90ZXh0IiwKICAgICAiSW1hZ2UiOiAie2ltYWdlQmFzZTY0fSIsCiAgICAgIkN1c3RvbWl6ZSI6ICJGQUNFQk9PSyIKfQ==");
			text = text.Replace("{apiKey}", string_0);
			text = text.Replace("{imageBase64}", string_1);
			string text2 = "";
			string text3 = "";
			int tickCount = Environment.TickCount;
			do
			{
				try
				{
					text2 = new RequestXNet().F089DBB3.Post("https://api.rockcaptcha.com/recognition", text, "application/json").ToString();
					text3 = JObject.Parse(text2)["TaskId"]!.ToString();
					if (text3 != "")
					{
						break;
					}
				}
				catch
				{
				}
				Commom.smethod_52(1.0);
			}
			while (Environment.TickCount - tickCount < 300000);
			if (text3 == "")
			{
				return "";
			}
			text = Commom.smethod_50("ewoJImFwaV90b2tlbiI6ICJ7YXBpS2V5fSIsCgkiam9iX2lkIjoge2pvYl9pZH0KfQ==");
			text = text.Replace("{apiKey}", string_0);
			text = text.Replace("{job_id}", text3);
			do
			{
				text2 = new RequestXNet().E58EB99F("https://api.rockcaptcha.com/getresult?apikey=" + string_0 + "&taskid=" + text3);
				string text4 = JObject.Parse(text2)["Status"]!.ToString();
				if (!(text4 == "ERROR"))
				{
					if (text4 == "SUCCESS")
					{
						break;
					}
					Commom.smethod_52(1.0);
					continue;
				}
				return "";
			}
			while (Environment.TickCount - tickCount < 300000);
			if (!text2.Contains("Data"))
			{
				return "";
			}
			return JObject.Parse(text2)["Data"]!.ToString();
		}
		catch (Exception)
		{
		}
		return "";
	}

	public static string smethod_1(string string_0, string string_1, string string_2)
	{
		try
		{
			string text = "https://api.rockcaptcha.com/recaptchav2?apikey={apiKey}&sitekey={websiteKey}&siteurl={websiteURL}&invisible=false&affiliateid=36495";
			text = text.Replace("{apiKey}", string_0);
			text = text.Replace("{websiteKey}", string_1);
			text = text.Replace("{websiteURL}", string_2);
			string text2 = "";
			string text3 = "";
			int tickCount = Environment.TickCount;
			do
			{
				try
				{
					text2 = new RequestXNet().E58EB99F(text);
					text3 = JObject.Parse(text2)["TaskId"]!.ToString();
					if (text3 != "")
					{
						break;
					}
				}
				catch
				{
				}
				Commom.smethod_52(1.0);
			}
			while (Environment.TickCount - tickCount < 300000);
			if (text3 == "")
			{
				return "";
			}
			text = "https://api.rockcaptcha.com/getresult?apikey={apiKey}&taskid={job_id}";
			text = text.Replace("{apiKey}", string_0);
			text = text.Replace("{job_id}", text3);
			do
			{
				text2 = new RequestXNet().E58EB99F(text);
				string text4 = JObject.Parse(text2)["Status"]!.ToString();
				if (!(text4 == "ERROR"))
				{
					if (text4 == "SUCCESS")
					{
						break;
					}
					Commom.smethod_52(3.0);
					continue;
				}
				return "";
			}
			while (Environment.TickCount - tickCount < 300000);
			if (!text2.Contains("Data"))
			{
				return "";
			}
			return JObject.Parse(text2)["Data"]!["Token"]!.ToString();
		}
		catch (Exception)
		{
		}
		return "";
	}
}
