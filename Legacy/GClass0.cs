using System;
using Newtonsoft.Json.Linq;

public class GClass0
{
	internal string string_0;

	internal string E82254B8;

	internal string string_1;

	internal int int_0;

	internal string EB237231;

	internal string string_2;

	public GClass0(string B131A7A0 = "", string E13AA8B3 = "", string string_3 = "", int BB04F990 = 0)
	{
		string_0 = B131A7A0;
		E82254B8 = E13AA8B3;
		string_1 = string_3;
		int_0 = BB04F990;
	}

	public void method_0(string string_3)
	{
		E82254B8 = string_3;
	}

	public string B2157B0A(string C2A08704)
	{
		for (int i = 0; i < 5; i++)
		{
			if (Base.smethod_5())
			{
				break;
			}
			string json = Commom.smethod_2(string_0, E82254B8, string_1, int_0, C2A08704);
			JObject jObject = JObject.Parse(json);
			if (!Convert.ToBoolean(jObject["success"]))
			{
				string text = jObject["error"]!.ToString();
				if (!text.Contains("A connection attempt failed because the connected party did not properly respond after a period of time"))
				{
					if (text.Contains(".facebook.com/dialog/unsupported_browser/"))
					{
						EB237231 = "https://www.facebook.com";
					}
					break;
				}
				continue;
			}
			EB237231 = jObject["url"]!.ToString();
			string_0 = jObject["cookie"]!.ToString();
			string_2 = jObject["response"]!.ToString();
			return string_2;
		}
		return "";
	}

	public string B930129D(string D1B1F302, string D8B49E88 = "")
	{
		for (int i = 0; i < 5; i++)
		{
			if (Base.smethod_5())
			{
				break;
			}
			string json = Commom.smethod_3(string_0, E82254B8, string_1, int_0, D1B1F302, D8B49E88);
			JObject jObject = JObject.Parse(json);
			if (!Convert.ToBoolean(jObject["success"]))
			{
				string text = jObject["error"]!.ToString();
				if (!(D1B1F302 == "https://www.facebook.com/api/graphql/") || !text.Contains("A connection attempt failed because the connected party did not properly respond after a period of time"))
				{
					break;
				}
				continue;
			}
			EB237231 = jObject["url"]!.ToString();
			string_0 = jObject["cookie"]!.ToString();
			string_2 = jObject["response"]!.ToString();
			return string_2;
		}
		return "";
	}

	public string method_1(string DD2AC0B6, string string_3, string B5ABCB94)
	{
		for (int i = 0; i < 5; i++)
		{
			if (Base.smethod_5())
			{
				break;
			}
			string json = Commom.smethod_4(string_0, E82254B8, string_1, int_0, DD2AC0B6, string_3, B5ABCB94);
			JObject jObject = JObject.Parse(json);
			if (!Convert.ToBoolean(jObject["success"]))
			{
				string text = jObject["error"]!.ToString();
				if (!(DD2AC0B6 == "https://www.facebook.com/api/graphql/") || !text.Contains("A connection attempt failed because the connected party did not properly respond after a period of time"))
				{
					break;
				}
				continue;
			}
			EB237231 = jObject["url"]!.ToString();
			string_0 = jObject["cookie"]!.ToString();
			string_2 = jObject["response"]!.ToString();
			return string_2;
		}
		return "";
	}
}
