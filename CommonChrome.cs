using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

public class CommonChrome
{
	public static void smethod_0(Chrome chrome_0, List<string> list_0)
	{
		List<string> list = new List<string>();
		int num = chrome_0.method_30("textarea");
		string text = "";
		for (int i = 0; i < num; i++)
		{
			if (list.Count == 0)
			{
				list = Commom.smethod_30(list_0);
			}
			text = list[Base.rd.Next(0, list.Count)];
			text = Commom.smethod_31(text);
			list.Remove(text);
			chrome_0.method_34("textarea|" + i);
			chrome_0.method_45(1, 2);
			chrome_0.method_22("textarea|" + i, text);
			chrome_0.method_45(1, 2);
		}
	}

	public static string smethod_1(Chrome FC175A00)
	{
		return CommonChromeV2.GetPageTitle(FC175A00);
	}

	public static string smethod_2(Chrome chrome_0)
	{
		return chrome_0.method_14("var x='';document.querySelectorAll('.overflowText').length>0&&(x=document.querySelector('.overflowText').innerText), x+''; return x;").ToString();
	}

	public static int smethod_3(Chrome chrome_0)
	{
		try
		{
			if (chrome_0 == null)
			{
				return -1;
			}
			int tickCount = Environment.TickCount;
			int num = 30;
			do
			{
				if (!chrome_0.CD930D04())
				{
					string text = chrome_0.GetURL();
					if (!text.StartsWith(chrome_0.method_25("https://m.facebook.com/home.php", text)) && !(text == chrome_0.method_25("https://m.facebook.com", text)) && !text.StartsWith("https://www.facebook.com"))
					{
						if (!chrome_0.method_18("#feed_jewel a"))
						{
							chrome_0.method_12("https://m.facebook.com/home.php");
						}
						if (chrome_0.D7A424AE("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]"))
						{
							chrome_0.E11EB838("#nux-nav-button,[href^=\"/a/nux/wizard/nav.php\"]");
							if (chrome_0.D7A424AE("#qf_skip_dialog_skip_link", 5.0))
							{
								chrome_0.E11EB838("#qf_skip_dialog_skip_link");
							}
						}
						chrome_0.F8091028(1.0);
						continue;
					}
					return 1;
				}
				return -2;
			}
			while (Environment.TickCount - tickCount < num * 1000);
		}
		catch
		{
		}
		return 0;
	}

	public static int A7AED931(Chrome chrome_0)
	{
		try
		{
			if (chrome_0 != null)
			{
				if (chrome_0.CD930D04())
				{
					return -2;
				}
				chrome_0.method_12("https://m.facebook.com/watch/?ref=bookmarks");
				chrome_0.method_69();
			}
		}
		catch
		{
		}
		return 0;
	}

	public static int smethod_4(Chrome chrome_0)
	{
		chrome_0.method_12("https://m.facebook.com/messages/?folder=unread&ref=bookmarks");
		return 1;
	}

	public static int smethod_5(Chrome chrome_0)
	{
		try
		{
			if (chrome_0 != null)
			{
				chrome_0.method_12("https://m.facebook.com/browse/birthdays/");
				chrome_0.method_45(2, 5);
				return 1;
			}
		}
		catch
		{
		}
		return 0;
	}

	public static string C01C5FA0(Chrome AD8FFFBC, string string_0, string string_1 = "https://www.facebook.com")
	{
		try
		{
			AD8FFFBC.method_12(string_1);
			AD8FFFBC.method_39(string_0);
			AD8FFFBC.method_13();
			return AD8FFFBC.FE31BD92().ToString() ?? "";
		}
		catch
		{
		}
		return "0";
	}

	public static string smethod_6(Chrome chrome_0, string string_0)
	{
		string result = "";
		try
		{
			if (string.IsNullOrEmpty(string_0)) return "";
			string json = new RequestXNet("", "", chrome_0?.A3A32284 ?? "", chrome_0?.Int32_1 ?? 0).E58EB99F("https://graph.facebook.com/me?fields=id,birthday,name&access_token=" + string_0);
			if (!string.IsNullOrEmpty(json))
			{
				JObject jObject = JObject.Parse(json);
				return (jObject["id"]?.ToString() ?? "") + "|" + (jObject["birthday"]?.ToString() ?? "") + "|" + (jObject["name"]?.ToString() ?? "");
			}
		}
		catch
		{
		}
		return result;
	}

	public static List<string> smethod_7(Chrome chrome_0)
	{
		return CommonChromeV2.GetMessengerThreadList(chrome_0);
	}

	public static List<string> smethod_8(Chrome chrome_0, int B7B1AEA6)
	{
		return CommonChromeV2.GetRecentCommentActivity(chrome_0, B7B1AEA6);
	}

	public static List<string> A0229E93(Chrome chrome_0, string string_0, string string_1, string string_2, int B7BAB2B9 = 20)
	{
		List<string> list = new List<string>();
		try
		{
			if (string.IsNullOrEmpty(string_2)) return list;
			string url = "https://graph.facebook.com/" + string_0 + "/photos?fields=images&limit=" + B7BAB2B9 + "&access_token=" + string_2;
			string text = new RequestXNet("", "", chrome_0?.A3A32284 ?? "", chrome_0?.Int32_1 ?? 0).E58EB99F(url);
			if (!string.IsNullOrEmpty(text) && text.Contains("images"))
			{
				JObject jObject = JObject.Parse(text);
				if (jObject["data"] != null)
				{
					for (int i = 0; i < jObject["data"].Count(); i++)
					{
						var images = jObject["data"]![i]!["images"]?.ToList();
						if (images != null && images.Count > 0)
						{
							int num = images.Count - 1;
							list.Add(string_0 + "*" + string_1 + "*" + images[num]!["source"]?.ToString() + "|" + images[num]!["width"]?.ToString() + "|" + images[num]!["height"]);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	public static List<string> BE13500C(Chrome chrome_0)
	{
		return CommonChromeV2.GetSuggestedPages(chrome_0);
	}

	public static List<string> F8053122(Chrome chrome_0, bool FB9C1537 = false)
	{
		return CommonChromeV2.GetFriendsList(chrome_0, FB9C1537);
	}

	public static string BD343C20(Chrome chrome_0)
	{
		return "";
	}
}
