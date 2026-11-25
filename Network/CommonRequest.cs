using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

internal class CommonRequest
{
	[CompilerGenerated]
	private sealed class Class18
	{
		internal string string_0;

		internal bool D7B28120(string A285511D)
		{
			return A285511D.Contains(string_0);
		}
	}

	internal static object B606C39F = new object();

	public static string FastCheckAccountStatus(string uid, string cookie, string proxy = "", int proxyType = 0)
	{
		return FbProfileChecker.FastCheckAccountStatus(uid, cookie, proxy, proxyType);
	}

	public static string smethod_0(string string_0, string string_1, string string_2, int E6B71982)
	{
		string result = "0|0";
		try
		{
			(string status, string info) tuple = smethod_11(string_0, "", 0);
			_ = tuple.status;
			string item = tuple.info;
			if (item == "Live")
			{
				result = "1|1";
			}
		}
		catch
		{
		}
		return result;
	}

	public static List<string> smethod_1(string AA9F46BB, string string_0, string string_1, string DE95CA28, int C73F831B)
	{
		List<string> list = new List<string>();
		try
		{
			string value = Regex.Match(AA9F46BB, "c_user=(\\d+)").Groups[1].Value;
			RequestXNet requestXNet = new RequestXNet(AA9F46BB, string_1, DE95CA28, C73F831B);
			requestXNet.F089DBB3.AddHeader("Authorization", "OAuth " + string_0);
			string json = requestXNet.E58EB99F("https://graph.facebook.com/?ids=" + value + "&fields=friends{id,name}");
			JObject jObject = JObject.Parse(json);
			JToken jToken = jObject[value]!["friends"];
			if (jToken["data"].Count() > 0)
			{
				for (int i = 0; i < jToken["data"].Count(); i++)
				{
					string item = jToken["data"]![i]!["id"]!.ToString();
					list.Add(item);
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public static List<string> smethod_2(string string_0, string C192F824, string string_1, string string_2, string string_3, int C73E73A8, int DBA4CB04 = 20, bool bool_0 = false)
	{
		List<string> list = new List<string>();
		try
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			string[] array = string_0.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				dictionary.Add(array[i], new List<string>());
			}
			try
			{
				RequestXNet requestXNet = new RequestXNet(C192F824, string_2, string_3, C73E73A8);
				requestXNet.F089DBB3.AddHeader("Authorization", "OAuth " + string_1);
				string string_4 = "https://graph.facebook.com/?ids=" + string_0 + "&pretty=0&fields=id,name,photos.limit(" + DBA4CB04 + "){images}";
				string text = requestXNet.E58EB99F(string_4);
				JObject jObject = JObject.Parse(text);
				if (jObject != null && text.Contains("images"))
				{
					string[] array2 = string_0.Split(',');
					foreach (string text2 in array2)
					{
						string text3 = jObject[text2]!["name"]!.ToString();
						try
						{
							foreach (JToken item in (IEnumerable<JToken>)(jObject[text2]!["photos"]!["data"]!))
							{
								try
								{
									int num = item["images"].ToList().Count - 1;
									dictionary[text2].Add(text2 + "*" + text3 + "*" + item["images"]![num]!["source"]?.ToString() + "|" + item["images"]![num]!["width"]?.ToString() + "|" + item["images"]![num]!["height"]);
								}
								catch
								{
								}
							}
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
			if (bool_0)
			{
				try
				{
					RequestXNet requestXNet2 = new RequestXNet(C192F824, string_2, string_3, C73E73A8);
					requestXNet2.F089DBB3.AddHeader("Authorization", "OAuth " + string_1);
					string string_5 = "https://graph.facebook.com/?ids=" + string_0 + "&pretty=0&fields=name,albums.limit(3){photos.limit(10){width,height,images}}";
					string text4 = requestXNet2.E58EB99F(string_5);
					JObject jObject2 = JObject.Parse(text4);
					if (jObject2 != null && text4.Contains("images"))
					{
						string[] array3 = string_0.Split(',');
						foreach (string text5 in array3)
						{
							string text6 = jObject2[text5]!["name"]!.ToString();
							foreach (JToken item2 in (IEnumerable<JToken>)(jObject2[text5]!["albums"]!["data"]!))
							{
								try
								{
									foreach (JToken item3 in (IEnumerable<JToken>)(item2["photos"]!["data"]!))
									{
										try
										{
											int num2 = item3["images"].ToList().Count - 1;
											if (dictionary[text5].Count < DBA4CB04)
											{
												dictionary[text5].Add(text5 + "*" + text6 + "*" + item3["images"]![num2]!["source"]?.ToString() + "|" + item3["images"]![num2]!["width"]?.ToString() + "|" + item3["images"]![num2]!["height"]);
												continue;
											}
										}
										catch (Exception)
										{
											continue;
										}
										goto IL_04bd;
									}
								}
								catch (Exception)
								{
								}
							}
							IL_04bd:;
						}
					}
				}
				catch
				{
				}
			}
			foreach (KeyValuePair<string, List<string>> item4 in dictionary)
			{
				if (item4.Value.Count > 0)
				{
					list.AddRange(item4.Value);
					list.Add("");
				}
			}
		}
		catch
		{
		}
		return list;
	}

	public static Bitmap smethod_3(string C515228C, bool bool_0 = false)
	{
		try
		{
			RequestXNet requestXNet = new RequestXNet();
			string string_ = "https://graph.facebook.com/" + C515228C + "/picture?height=500&access_token=6628568379%7Cc1e620fa708a1d5696fb991c1bde5662";
			byte[] array = requestXNet.method_0(string_);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array, 0, Convert.ToInt32(array.Length));
			Bitmap bitmap = new Bitmap(memoryStream, useIcm: false);
			if (bool_0)
			{
				string text = Commom.smethod_95() + "\\avatar";
				Commom.CreateFolder(text);
				bitmap.Save(text + "\\" + C515228C + ".png");
			}
			return bitmap;
		}
		catch
		{
		}
		return null;
	}

	public static string smethod_4(string EB344321, string DA8FB78E, string E491519D = "", int int_0 = 0)
	{
		try
		{
			string string_ = "https://graph.facebook.com/" + EB344321 + "/picture?width=9999&access_token=6628568379|c1e620fa708a1d5696fb991c1bde5662&redirect=false";
			RequestXNet requestXNet = new RequestXNet("", "", E491519D, int_0);
			string text = requestXNet.E58EB99F(string_);
			text = text.Trim('"');
			return smethod_5(text, DA8FB78E, EB344321);
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "Error DownLoadImageByUid");
		}
		return "";
	}

	public static string E00AE505(string string_0)
	{
		string result = "";
		try
		{
			using WebClient webClient = new WebClient();
			byte[] inArray = webClient.DownloadData(string_0);
			result = Convert.ToBase64String(inArray);
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static string smethod_5(string string_0, string string_1 = "", string string_2 = "")
	{
		string_1 = ((string_1 == "") ? (Commom.smethod_95() + "\\photos") : string_1.Trim('\\')) + "\\";
		string text = "";
		for (int i = 0; i < 2; i++)
		{
			try
			{
				using WebClient webClient = new WebClient();
				byte[] buffer = webClient.DownloadData(string_0);
				using MemoryStream stream = new MemoryStream(buffer);
				using Image image = Image.FromStream(stream);
				text = string_1 + ((string_2 == "") ? Guid.NewGuid().ToString() : string_2);
				try
				{
					image.Save(text + ".png", ImageFormat.Png);
					text += ".png";
				}
				catch
				{
					image.Save(text + ".jpg", ImageFormat.Jpeg);
					text += ".jpg";
				}
			}
			catch (Exception)
			{
			}
			if (text != "")
			{
				break;
			}
			string input = new RequestXNet().E58EB99F(string_0);
			string_0 = Regex.Match(input, "src=\"(.*?)\"").Groups[1].Value;
			if (string_0 == "")
			{
				break;
			}
		}
		return text;
	}

	public static string BC9215A7(string string_0, string D6A4629A = "")
	{
		try
		{
			string text = Commom.smethod_85("CheckWall('" + string_0 + "','')");
			if (text != "1")
			{
				text = Commom.smethod_85("CheckWall('" + string_0 + "','" + D6A4629A + "')");
			}
			if (string.IsNullOrEmpty(text))
			{
				return "1|";
			}
			return text + "|";
		}
		catch
		{
			return "1|";
		}
	}

	public static string smethod_6(string string_0, string string_1 = "", int E3839A91 = 0)
	{
		return "";
	}

	public static string D6A50126(string string_0, string EC08958D = "", int int_0 = 0)
	{
		return "";
	}

	public static string E083FD83(string FE2ED128, string string_0 = "", int int_0 = 0)
	{
		return "1|||||";
	}

	public static bool B4B29420(string E6A0553B, string string_0, string string_1, string string_2, int DFA94502 = 0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		try
		{
			var valResult = SmartTokenHub.ValidateToken(string_0, string_2, DFA94502);
			return valResult.IsLive;
		}
		catch
		{
			return true;
		}
	}

	public static string smethod_7(string string_0, string string_1, string string_2, int BB9E978B = 0)
	{
		string text = "";
		try
		{
			text = SmartTokenHub.GetTokenEAAB(string_0, string_2, BB9E978B);
		}
		catch { }
		if (string.IsNullOrEmpty(text))
		{
			try
			{
				RequestXNet requestXNet = new RequestXNet(string_0, "", string_2, BB9E978B);
				requestXNet.F089DBB3.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
				requestXNet.F089DBB3.AddHeader("accept-language", "en-US,en;q=0.9");
				string desktopUa = ModernUserAgentHub.GetRandomDesktopChrome();
				Dictionary<string, string> hints = ModernUserAgentHub.GetClientHintsHeaders(desktopUa);
				requestXNet.F089DBB3.AddHeader("sec-ch-ua", hints["sec-ch-ua"]);
				requestXNet.F089DBB3.AddHeader("sec-ch-ua-mobile", hints["sec-ch-ua-mobile"]);
				requestXNet.F089DBB3.AddHeader("sec-ch-ua-platform", hints["sec-ch-ua-platform"]);
				requestXNet.F089DBB3.AddHeader("sec-fetch-dest", "document");
				requestXNet.F089DBB3.AddHeader("sec-fetch-mode", "navigate");
				requestXNet.F089DBB3.AddHeader("sec-fetch-site", "none");
				requestXNet.F089DBB3.AddHeader("sec-fetch-user", "?1");
				requestXNet.F089DBB3.AddHeader("upgrade-insecure-requests", "1");
				requestXNet.F089DBB3.AddHeader("user-agent", desktopUa);
				string input = requestXNet.E58EB99F("https://www.facebook.com/adsmanager/manage/campaigns?act=");
				text = Regex.Match(input, "EAAB(.*?)\"").Value.Replace("\"", "").Replace("\\", "");
			}
			catch
			{
				if (!smethod_0(string_0, string_1, string_2, BB9E978B).StartsWith("1|"))
				{
					return "-1";
				}
			}
		}
		if (text == "" && !smethod_0(string_0, string_1, string_2, BB9E978B).StartsWith("1|"))
		{
			return "-1";
		}
		return text;
	}

	public static string BB254EB6(string string_0)
	{
		string result = "";
		int num = 0;
		uint num2 = AFAE75A0.smethod_0(string_0);
		if (num2 <= 1315429348)
		{
			if (num2 <= 822911587)
			{
				if (num2 != 334175660)
				{
					if (num2 != 401286136)
					{
						if (num2 == 822911587 && string_0 == "4")
						{
							goto IL_01c8;
						}
					}
					else if (string_0 == "14")
					{
						result = ((num != 0) ? "Device" : "Thiết bị");
						goto IL_02c6;
					}
				}
				else if (string_0 == "18")
				{
					result = ((num != 0) ? "comment" : "Bình luận");
					goto IL_02c6;
				}
				goto IL_02a5;
			}
			if (num2 <= 923577301)
			{
				if (num2 != 906799682)
				{
					if (num2 != 923577301 || !(string_0 == "2"))
					{
						goto IL_02a5;
					}
					result = ((num != 0) ? "Birthday" : "Ngày sinh");
				}
				else
				{
					if (!(string_0 == "3"))
					{
						goto IL_02a5;
					}
					result = ((num != 0) ? "Image" : "Ảnh");
				}
			}
			else if (num2 != 1153637868)
			{
				if (num2 != 1315429348 || !(string_0 == "id_upload"))
				{
					goto IL_02a5;
				}
				result = "Up a\u0309nh";
			}
			else
			{
				if (!(string_0 == "72h"))
				{
					goto IL_02a5;
				}
				result = ((num != 0) ? "72 hours" : "72h");
			}
		}
		else
		{
			if (num2 <= 2347784130u)
			{
				if (num2 != 1718322808)
				{
					if (num2 != 2331006511u)
					{
						if (num2 == 2347784130u && string_0 == "34")
						{
							goto IL_01c8;
						}
					}
					else if (string_0 == "37")
					{
						result = "Otp mail";
						goto IL_02c6;
					}
				}
				else if (string_0 == "2fa")
				{
					result = "Co\u0301 2fa";
					goto IL_02c6;
				}
				goto IL_02a5;
			}
			if (num2 <= 2364561749u)
			{
				if (num2 != 2347931225u)
				{
					if (num2 != 2364561749u || !(string_0 == "35"))
					{
						goto IL_02a5;
					}
					result = "Login google";
				}
				else
				{
					if (!(string_0 == "26"))
					{
						goto IL_02a5;
					}
					result = ((num != 0) ? "Friend" : "Nhơ\u0300 bạn bè");
				}
			}
			else if (num2 != 2381486463u)
			{
				if (num2 != 2517938561u || !(string_0 == "vhh"))
				{
					goto IL_02a5;
				}
				result = ((num != 0) ? "disable" : "Vô hiệu hóa");
			}
			else
			{
				if (!(string_0 == "20"))
				{
					goto IL_02a5;
				}
				result = ((num != 0) ? "Message" : "Tin nhắn");
			}
		}
		goto IL_02c6;
		IL_01c8:
		result = "Otp phone";
		goto IL_02c6;
		IL_02a5:
		File.AppendAllText("data\\dangcp.txt", string_0);
		goto IL_02c6;
		IL_02c6:
		return result;
	}

	public static string smethod_8(string string_0, string string_1, string B9A1F791, string string_2, int B4911386)
	{
		string text = "";
		try
		{
			string d = "email=" + WebUtility.UrlEncode(string_0) + "&pass=" + WebUtility.UrlEncode(string_1);
			RequestXNet requestXNet = new RequestXNet("", B9A1F791, string_2, B4911386);
			string text2 = requestXNet.method_1("https://mbasic.facebook.com/login/device-based/regular/login/?refsrc=https%3A%2F%2Fmbasic.facebook.com%2F&lwv=100&refid=8", d).ToString();
			if (text2.Contains("id=\"checkpointSubmitButton\""))
			{
				if (text2.Contains("id=\"approvals_code\""))
				{
					text = "5|";
				}
				else
				{
					text = "2|";
					requestXNet = new RequestXNet("", B9A1F791, string_2, B4911386);
					requestXNet.E58EB99F("https://www.facebook.com").ToString();
					text2 = requestXNet.method_1("https://www.facebook.com/login/device-based/regular/login/?login_attempt=1&lwv=100", d).ToString();
					string value = Regex.Match(text2, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
					string value2 = Regex.Match(text2, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
					string value3 = Regex.Match(text2, "name=\"nh\" value=\"(.*?)\"").Groups[1].Value;
					string value4 = Regex.Match(text2, "\"__spin_r\":(.*?),").Groups[1].Value;
					string value5 = Regex.Match(text2, "\"__spin_t\":(.*?),").Groups[1].Value;
					string d2 = "jazoest=" + value2 + "&fb_dtsg=" + value + "&nh=" + value3 + "&submit[Continue]=Ti%E1%BA%BFp%20t%E1%BB%A5c&__user=0&__a=1&__dyn=7xe6Fo4OQ1PyUhxOnFwn84a2i5U4e1Fx-ewSwMxW0DUeUhw5cx60Vo1upE4W0OE2WxO0SobEa87i0n2US1vw4Ugao881FU3rw&__csr=&__req=5&__beoa=0&__pc=PHASED%3ADEFAULT&dpr=1&__rev=" + value4 + "&__s=op5tkm%3A2d4a9m%3A37z92b&__hsi=6789153697588537525-0&__spin_r=" + value4 + "&__spin_b=trunk&__spin_t=" + value5;
					text2 = requestXNet.method_1("https://www.facebook.com/checkpoint/async?next=https%3A%2F%2Fwww.facebook.com%2F", d2);
					text2 = requestXNet.E58EB99F("https://www.facebook.com/checkpoint/?next");
					MatchCollection matchCollection = Regex.Matches(text2, "verification_method\" value=\"(.*?)\"");
					if (matchCollection.Count > 0)
					{
						for (int i = 0; i < matchCollection.Count; i++)
						{
							text = text + BB254EB6(matchCollection[i].Groups[1].Value) + "-";
						}
						text = text.TrimEnd('-');
					}
					else if (text2.Contains("/checkpoint/dyi/?referrer=disabled_checkpoint"))
					{
						text += BB254EB6("vhh");
					}
					else if (text2.Contains("captcha-recaptcha"))
					{
						text += BB254EB6("72h");
					}
					else if (text2.Contains("name=\"submit[Log Out]\"") || text2.Contains("name=\"submit[__placeholder__]\""))
					{
						text += "không thê\u0309 xmdt";
					}
					else if (text2.Contains("name=\"submit[Continue]\""))
					{
						text += "Thiê\u0301t bi\u0323";
					}
				}
			}
			else if (text2.Contains("login_error"))
			{
				text = ((!text2.Contains("m_login_email")) ? "0|" : "3|");
			}
			else if (text2.Contains("action_set_contact_point"))
			{
				text = "2|" + BB254EB6("34");
			}
			else
			{
				string text3 = requestXNet.method_4();
				text = ((!smethod_0(text3, B9A1F791, string_2, B4911386).StartsWith("1|")) ? "2|" : (text + "1|" + text3));
			}
		}
		catch
		{
			text = "0|";
		}
		return text;
	}

	public static string smethod_9(string string_0, string AB3E89BB, string string_1, string string_2, string string_3, int int_0)
	{
		string text = "";
		bool flag = false;
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		string text7 = "";
		string text8 = "";
		try
		{
			RequestXNet requestXNet = new RequestXNet(string_0, string_2, string_3, int_0);
			if (string_1 == "")
			{
				string_1 = "me";
			}
			string json = requestXNet.E58EB99F("https://graph.facebook.com/" + string_1 + "?fields=name,email,gender,birthday,friends.limit(0)&access_token=" + AB3E89BB);
			JObject jObject = JObject.Parse(json);
			flag = true;
			text2 = jObject["name"]!.ToString();
			try
			{
				text3 = jObject["gender"]!.ToString();
			}
			catch
			{
			}
			try
			{
				text4 = jObject["birthday"]!.ToString();
			}
			catch
			{
			}
			try
			{
				text6 = jObject["email"]!.ToString();
			}
			catch
			{
			}
			try
			{
				text7 = jObject["friends"]!["summary"]!["total_count"]!.ToString();
			}
			catch
			{
			}
		}
		catch
		{
			if (!B4B29420(string_0, AB3E89BB, "", ""))
			{
				return "-1";
			}
		}
		return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}";
	}

	private static void smethod_10(string AB0D6328)
	{
		List<string> list = new List<string>();
		foreach (JToken item in (IEnumerable<JToken>)(JObject.Parse(AB0D6328)["friends"]!["data"]!))
		{
			list.Add(item["id"]!.ToString());
		}
		list = list.Distinct().ToList();
	}

	public static string B20D9E0B(string string_0, string F2A72F87, string string_1, int int_0)
	{
		string text = "";
		bool flag = false;
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		string text7 = "";
		string text8 = "";
		string text9 = "";
		string text10 = "";
		try
		{
			string value = Regex.Match(string_0, "c_user=(\\d+)").Groups[1].Value;
			RequestXNet requestXNet = new RequestXNet(string_0, F2A72F87, string_1, int_0);
			string string_2 = "https://business.facebook.com/business_locations/";
			string input = requestXNet.E58EB99F(string_2);
			string value2 = Regex.Match(input, "dtsg\":{\"token\":\"(.*?)\"").Groups[1].Value;
			text9 = Regex.Match(input, "EAAA(.*?)\"").Value.TrimEnd('"', '\\');
			text2 = JObject.Parse("{" + Regex.Match(input, "\"NAME\":\"(.*?)\"").Value + "}")["NAME"]!.ToString();
			text2 = WebUtility.HtmlDecode(text2);
			string text11 = Commom.smethod_50("LS0tLS0tV2ViS2l0Rm9ybUJvdW5kYXJ5MnlnMEV6RHBTWk9DWGdCUgpDb250ZW50LURpc3Bvc2l0aW9uOiBmb3JtLWRhdGE7IG5hbWU9ImZiX2R0c2ciCgp7e2ZiX2R0c2d9fQotLS0tLS1XZWJLaXRGb3JtQm91bmRhcnkyeWcwRXpEcFNaT0NYZ0JSCkNvbnRlbnQtRGlzcG9zaXRpb246IGZvcm0tZGF0YTsgbmFtZT0icSIKCm5vZGUoe3t1aWR9fSl7ZnJpZW5kc3tjb3VudH0sc3Vic2NyaWJlcnN7Y291bnR9LGdyb3VwcyxjcmVhdGVkX3RpbWV9Ci0tLS0tLVdlYktpdEZvcm1Cb3VuZGFyeTJ5ZzBFekRwU1pPQ1hnQlItLQ==");
			text11 = text11.Replace("{{fb_dtsg}}", value2);
			text11 = text11.Replace("{{uid}}", value);
			input = requestXNet.method_1("https://www.facebook.com/api/graphql/", text11, "multipart/form-data; boundary=----WebKitFormBoundary2yg0EzDpSZOCXgBR");
			JObject jObject = JObject.Parse(input);
			text7 = jObject[value]!["friends"]!["count"]!.ToString();
			text8 = jObject[value]!["groups"]!["count"]!.ToString();
			text10 = jObject[value]!["created_time"]!.ToString();
			if (text7 == "")
			{
				text7 = "0";
			}
			if (text8 == "")
			{
				text8 = "0";
			}
		}
		catch
		{
			if (!smethod_0(string_0, F2A72F87, string_1, int_0).Contains("1|"))
			{
				return "-1";
			}
		}
		return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}|{text9}|{text10}";
	}

	public static string AEB03A15(string A20EC819, string D190AE99)
	{
		string text = "";
		bool flag = false;
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		string text7 = "";
		string text8 = "";
		string text9 = "";
		string text10 = "";
		try
		{
			string text11 = "c_user=" + Regex.Match(D190AE99 + ";", "c_user=(\\d+)").Groups[1].Value + "; xs=xs=" + Regex.Match(D190AE99 + ";", "xs=(.*?);").Groups[1].Value + ";";
			string modernUa = ModernUserAgentHub.GetRandomDesktopChrome();
			RequestXNet requestXNet = new RequestXNet(text11 + " useragent=" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(modernUa)), modernUa);
			string string_ = "https://www.facebook.com/api/graphql";
			string d = "q=user(" + A20EC819 + ")%7Bfriends%7Bcount%7D%2Cgroups%7Bcount%7D%2Cid%2Cname%2Cgender%2Cbirthday%2Cemail_addresses%2Cusername%7D";
			string json = requestXNet.method_1(string_, d);
			JObject jObject = JObject.Parse(json);
			text7 = jObject[A20EC819]!["friends"]!["count"]!.ToString();
			text8 = jObject[A20EC819]!["groups"]!["count"]!.ToString();
			text2 = jObject[A20EC819]!["name"]!.ToString();
			text4 = ((jObject[A20EC819]!["birthday"] != null) ? jObject[A20EC819]!["birthday"]!.ToString() : "");
			text3 = jObject[A20EC819]!["gender"]!.ToString().ToLower();
			if (text7 == "")
			{
				text7 = "0";
			}
			if (text8 == "")
			{
				text8 = "0";
			}
			flag = true;
		}
		catch
		{
			if (!smethod_0(D190AE99, "", "", 0).StartsWith("1|"))
			{
				return "-1";
			}
			flag = false;
		}
		return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}|{text9}|{text10}";
	}

	internal static (string status, string info) smethod_11(string string_0, string string_1, int C8BFB995)
	{
		string item = "";
		string item2 = "";
		try
		{
			RequestXNet requestXNet = new RequestXNet(string_0, ModernUserAgentHub.GetRandomDesktopChrome(), string_1, C8BFB995);
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				if (Base.smethod_5())
				{
					break;
				}
				try
				{
					text = requestXNet.E58EB99F("https://www.facebook.com/");
				}
				catch (Exception)
				{
				}
				if (text != "")
				{
					break;
				}
			}
			if (text == "")
			{
				item = "Không check được";
			}
			else
			{
				string text2 = requestXNet.method_5();
				if (text2.Contains("601051028565049"))
				{
					text2 = Regex.Match(text2, "https://(.*?)facebook.com").Value + "/checkpoint/601051028565049/submit/";
					string value = Regex.Match(text, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
					string value2 = Regex.Match(text, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
					text = requestXNet.method_1(text2, "jazoest=" + value2 + "&fb_dtsg=" + value);
					text2 = requestXNet.method_5();
				}
				if (text2.Contains("checkpoint/disabled"))
				{
					item = "Vô hiệu hóa";
					item2 = "Checkpoint: vhh";
				}
				else if (text2.Contains("828281030927956"))
				{
					string text3 = "956";
					item = "Checkpoint: " + text3;
					item2 = "Checkpoint: " + text3;
				}
				else
				{
					if (text2.Contains("1501092823525282"))
					{
						string text4 = Commom.F839D53E(text, new List<string>
						{
							"name=\"action_proceed\"", "id=\"captcha\"", "name=\"code\"", "name=\"contact_point\"", "id=\"mobile_image_data\"", "name=\"contact_point_index\"", "id=\"m_login_email\"", "name=\"action_set_contact_point\"", "/help/contact/571927962827151", "qV0ToI14MZv.png",
							"tGIsE6jdnU6.png", "bfCKqoUg0E4.png", "CdZCxLZ7L5L.png"
						});
						string text5 = text4;
						string text6 = text5;
						uint num = AFAE75A0.smethod_0(text6);
						if (num <= 1962905460)
						{
							switch (num)
							{
							case 896415299u:
								if (text6 == "id=\"captcha\"")
								{
									item = "Captcha-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
								}
								break;
							case 467237996u:
								if (text6 == "name=\"contact_point\"")
								{
									item = ((!text.Contains("email") || text.Contains("name=\"country_code\"")) ? ("Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) : ("Email-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
								}
								break;
							case 238436553u:
								if (text6 == "name=\"contact_point_index\"")
								{
									item = ((!text.Contains("name=\"action_use_different_phone\"")) ? ("Phone Old-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) : ("Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
								}
								break;
							case 1962905460u:
								if (text6 == "name=\"action_set_contact_point\"")
								{
								}
								break;
							case 1370698424u:
								if (text6 == "name=\"action_proceed\"")
								{
								}
								break;
							case 1064600637u:
								if (text6 == "/help/contact/571927962827151")
								{
									item = "Spam-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
								}
								break;
							}
						}
						else if (num <= 2576475206u)
						{
							if (num != 2263203229u)
							{
								if (num != 2439781595u)
								{
									if (num == 2576475206u && text6 == "CdZCxLZ7L5L.png")
									{
										goto IL_04d9;
									}
								}
								else if (text6 == "tGIsE6jdnU6.png")
								{
									goto IL_04d9;
								}
							}
							else if (text6 == "bfCKqoUg0E4.png")
							{
								goto IL_04d9;
							}
						}
						else if (num != 3244666871u)
						{
							switch (num)
							{
							case 3830140182u:
								if (text6 == "name=\"code\"")
								{
									item = "Phone-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
								}
								break;
							case 3647932414u:
								if (text6 == "id=\"mobile_image_data\"")
								{
									item = "Image-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
								}
								break;
							}
						}
						else if (text6 == "qV0ToI14MZv.png")
						{
							goto IL_04d9;
						}
						goto IL_04fc;
					}
					if (text.Contains("facebook.com/login.php") || text.Contains("id=\"login_form\"") || text.Contains("name=\"login\"") || text.Contains("/login/device-based/validate-pin/"))
					{
						item = "No login";
					}
					else if (!text2.Contains("facebook.com/gettingstarted") && (!text.Contains("href=\"/menu/bookmarks/") || !text.Contains("id=\"mbasic_logout_button\"")) && (!text.Contains("id=\"MComposer\"") || !text.Contains("id=\"MBackNavBar\"")) && !text.Contains("\"is_checkpointed\":false"))
					{
						item = ((text.Contains("confirmation") && !text.Contains("preconfirmation")) ? "Novery Live" : ((!text.Contains("/help/117450615006715") && !text.Contains("eid=147943945047188")) ? "Dạng Checkpoint khác" : "Checkpoint: login"));
					}
					else
					{
						item2 = "Live";
						item = "Tài khoản live";
					}
				}
			}
			goto end_IL_000c;
			IL_04d9:
			item = "Đợi xét duyệt (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")";
			goto IL_04fc;
			IL_04fc:
			item2 = "Checkpoint: 282";
			end_IL_000c:;
		}
		catch (Exception)
		{
			item = "Không check được";
		}
		return (item, item2);
	}

	public static void smethod_12(int int_0, string string_0, int int_1 = -1)
	{
		fMain.fMain_0.method_130(int_0, string_0, int_1);
	}

	public static (string status, string info, string newPass) smethod_13(int int_0, string string_0, RequestXNet requestXNet_0, string A088E59D, string C90C3FB4, string string_1, string string_2, string string_3, string string_4)
	{
		string item = "";
		string item2 = "";
		string text = "";
		bool flag = false;
		try
		{
			int num = 0;
			int num2 = 3;
			string text2 = "";
			int num3 = 3;
			string text3 = "";
			string text4 = "";
			text3 = requestXNet_0.E58EB99F("https://www.facebook.com/checkpoint/828281030927956/?next=https%3A%2F%2Fwww.facebook.com%2F");
			string text5 = Commom.F914B80B(text3, "\"LSD\",\\[\\],{\"token\":\"(.*?)\"");
			string text6 = Commom.F914B80B(text3, "\"DTSGInitialData\",\\[\\],{\"token\":\"(.*?)\"");
			if (text6 == "")
			{
				item = "Unlock 956 Fail (Please try again 1)";
			}
			else
			{
				A088E59D = Commom.F914B80B(requestXNet_0.method_4(), "c_user=(\\d+)");
				string text7 = "av=" + A088E59D + "&__user=" + A088E59D + "&__a=1&__req=7&__hs=20015.HYP%3Acomet_pkg.2.1..2.1&dpr=3&__ccg=EXCELLENT&__rev=1017496172&__s=pljtfv%3Aznp1jt%3Apkw3sx&__hsi=7427386731673553225&__dyn=7xeXxa1mxu1syaxG4Vp41twWwIxu13w8CewSwAyUco2qwJyE2OwpUe8hwaG0Z82_CwjE1xoswMwto2awgo9oO0n24oaEd82lwv89k2C1Fwc60D8vwRwlE-U2exi4UaEW0Loco4i5o2eUlwhE2Lx-0luVEbUGdG1Jw9h08O321Lwqo5B0bK1Iwqo2swEwkFU-4EdrwsUbUaU3yw&__csr=hJEJaIggyTtZ5RZlhdL8J9bviP5h6nkNpkhp2tltppFl-AaBykJprVbCghKjAgS8KcppWyECqq5pqDKQWVomwVxG3K4E5S0LUdpodEaHwpo5u0h-0A9U-09swqo4-m0PE1do0Rh1q3F0UUhw9m0d6w14K0tu03bC06q-00hl208Nw0Nzw4ZwwwjU0Ci1exe5WoK06So0De0709orx2ECp2otCga805vSew38o08NGa3e2Je9m&__comet_req=15&fb_dtsg=" + text6 + "&jazoest=25772&lsd=" + text5 + "&__spin_r=1017496172&__spin_b=trunk&__spin_t=1729323233&fb_api_caller_class=RelayModern&";
				string text8 = "";
				while (true)
				{
					IL_00d5:
					string text9 = "useEpsilonNavigateMutation";
					string text10 = "STEPPER_CONFIRMATION";
					string text11 = "";
					string text12 = "";
					string text13 = "";
					JObject jObject = null;
					text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22step%22%3A%22" + text10 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=9385152714844566";
					text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
					{
						"x-fb-friendly-name: " + text9,
						"x-fb-lsd: " + text5
					});
					if (!text3.Contains("errorSummary"))
					{
						List<string> list = new List<string>();
						int tickCount = Environment.TickCount;
						while (!Base.smethod_5())
						{
							try
							{
								jObject = JObject.Parse(text3);
							}
							catch (Exception)
							{
							}
							string text14 = Commom.F839D53E(text3, new List<string>
							{
								"EpsilonIntroScreen", "EpsilonStepperScreen", "EpsilonAntiScriptingCaptcha", "EpsilonChallengeChooser", "EpsilonMessageCodeCaptcha", "IXTAuthenticityWizardContactPointSelectionScreenViewModel", "EpsilonEnterMessageCodeCaptcha", "IXTAuthenticityWizardContactPointConfirmationScreenViewModel", "IXTCustomRedirectScreenViewModel", "EpsilonProfilesReview",
								"EpsilonContactPointReview", "EpsilonChangePasswordScreen", "EpsilonLoginDetailsConfirmationScreen", "EpsilonOutroScreen"
							});
							list.Add(text14);
							string text15 = text14;
							string text16 = text15;
							uint num4 = AFAE75A0.smethod_0(text16);
							if (num4 <= 1660330020)
							{
								if (num4 <= 1086481527)
								{
									if (num4 != 55629439)
									{
										if (num4 != 531998945)
										{
											if (num4 == 1086481527 && text16 == "EpsilonChallengeChooser")
											{
												smethod_12(int_0, string_0 + "Choose challenge...");
												List<string> list2 = new List<string>();
												JArray jArray = null;
												jArray = ((!text3.Contains("verify_anti_scripting_captcha_code")) ? (jObject["data"]!["epsilon_navigate"]!["epsilon_checkpoint"]!["screen"]!["available_challenges"] as JArray) : (jObject["data"]!["verify_anti_scripting_captcha_code"]!["epsilon_checkpoint"]!["screen"]!["available_challenges"] as JArray));
												foreach (JToken item3 in jArray)
												{
													list2.Add(item3["type"]!.ToString().ToLower());
												}
												if (list2.Count != 0)
												{
													if (list2.Contains("email_captcha") && C90C3FB4 != "")
													{
														text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
														text10 = "EMAIL_CAPTCHA";
														text9 = "useEpsilonNavigateMutation";
														text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22step%22%3A%22" + text10 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=9385152714844566";
														text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
														{
															"x-fb-friendly-name: " + text9,
															"x-fb-lsd: " + text5
														});
														goto IL_14d4;
													}
													string text17 = "";
													if (list2.Contains("email_captcha"))
													{
														text17 += "-Otp mail";
													}
													if (list2.Contains("text_message_captcha"))
													{
														text17 += "-Phone";
													}
													if (list2.Contains("credit_card_captcha"))
													{
														text17 += "-Card";
													}
													if (list2.Contains("birthday_captcha"))
													{
														text17 += "-Birthday";
													}
													if (list2.Contains("id_captcha"))
													{
														text17 += "-Xmdt";
													}
													if (text17 != "")
													{
														text17 = text17.Substring(1);
														item2 = (item = "Checkpoint: 956 (" + text17 + ")");
													}
													else
													{
														item2 = (item = "Checkpoint: 956 (" + string.Join(",", list2) + ")");
													}
													break;
												}
												item2 = (item = "Checkpoint: 956-Tìm hiểu thêm");
												break;
											}
										}
										else if (text16 == "EpsilonEnterMessageCodeCaptcha")
										{
											goto IL_11be;
										}
									}
									else if (text16 == "IXTCustomRedirectScreenViewModel")
									{
										text11 = jObject["data"]!["ixt_screen_next"]!["view_model"]!["updated_token"]!.ToString();
										text9 = "useEpsilonXFACAuthenticityNavigationMutation";
										text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22is_karma_limit_reached%22%3Afalse%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=8403843123055846";
										text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text9,
											"x-fb-lsd: " + text5
										});
										goto IL_14d4;
									}
									goto IL_110f;
								}
								if (num4 <= 1566447917)
								{
									if (num4 != 1525447425)
									{
										if (num4 != 1566447917 || !(text16 == "EpsilonIntroScreen"))
										{
											goto IL_110f;
										}
										smethod_12(int_0, string_0 + "Get start...");
										text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
										if (text10 != "STEPPER_CONFIRMATION")
										{
											item = ((num <= 0) ? "Unlock 956 Fail (Intro)" : "Unlock 956 Fail (Verify Otp fail)");
											break;
										}
										text9 = "useEpsilonNavigateMutation";
										text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22step%22%3A%22" + text10 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=9385152714844566";
										text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text9,
											"x-fb-lsd: " + text5
										});
									}
									else
									{
										if (!(text16 == "EpsilonLoginDetailsConfirmationScreen"))
										{
											goto IL_110f;
										}
										smethod_12(int_0, string_0 + "Click done...");
										text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
										text9 = "useEpsilonNavigateMutation";
										text10 = "OUTRO";
										text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22step%22%3A%22" + text10 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=9385152714844566";
										text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text9,
											"x-fb-lsd: " + text5
										});
									}
								}
								else if (num4 != 1651936736)
								{
									if (num4 != 1660330020 || !(text16 == "EpsilonAntiScriptingCaptcha"))
									{
										goto IL_110f;
									}
									smethod_12(int_0, string_0 + "Bypass captcha...");
									num3--;
									if (num3 <= 0)
									{
										item = "Unlock 956 Fail (Bypass captcha fail)";
										break;
									}
									string text18 = jObject["data"]!["epsilon_navigate"]!["epsilon_checkpoint"]!["screen"]!["captcha_data"]!["captcha_uri"]!.ToString();
									text18 = text18.Replace("&amp;", "&");
									int int_ = C5034B95.smethod_0("configCheckpoint").method_2("typeCaptcha");
									string text19 = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_" + int_);
									if (text19 == "" && !DB81C53D.smethod_2(C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4")))
									{
										item = "Unlock 956 Fail (Captcha)";
										break;
									}
									string text20 = Commom.A794F28D(requestXNet_0.method_4(), text18);
									if (text20 == "")
									{
										goto IL_00d5;
									}
									string text21 = GClass2.smethod_1(int_, text19, text20);
									if (text21 == "")
									{
										goto IL_00d5;
									}
									string text22 = jObject["data"]!["epsilon_navigate"]!["epsilon_checkpoint"]!["screen"]!["captcha_data"]!["captcha_persisted_data"]!.ToString();
									text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
									text9 = "useVerifyAntiScriptingCaptchaCodeMutation";
									text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22captcha_persisted_data%22%3A%22" + text22 + "%22%2C%22code%22%3A%22" + text21 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=8931784676832161";
									text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text9,
										"x-fb-lsd: " + text5
									});
									if (text3.Contains("\"errors\""))
									{
										goto IL_00d5;
									}
								}
								else
								{
									if (!(text16 == "IXTAuthenticityWizardContactPointSelectionScreenViewModel"))
									{
										goto IL_110f;
									}
									text13 = jObject["data"]!["ixt_xfac_universal_trigger"]!["screen"]!["view_model"]!["serialized_state"]!.ToString();
									text9 = "CometFacebookWithLoggedOutIXTNextMutation";
									text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22authenticity_wizard_contact_point_selection%22%3A%7B%22contact_point%22%3A%22" + text12 + "%22%2C%22contact_point_type%22%3A%22EMAIL%22%2C%22serialized_state%22%3A%22" + text13 + "%22%7D%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22client_mutation_id%22%3A%221%22%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=8760610473984639";
									text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text9,
										"x-fb-lsd: " + text5
									});
								}
							}
							else if (num4 <= 2180722076u)
							{
								if (num4 == 1692771796)
								{
									if (!(text16 == "EpsilonOutroScreen"))
									{
										goto IL_110f;
									}
									flag = true;
									break;
								}
								if (num4 != 1796792119)
								{
									if (num4 != 2180722076u || !(text16 == "EpsilonChangePasswordScreen"))
									{
										goto IL_110f;
									}
									smethod_12(int_0, string_0 + "Change pass...");
									text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
									text = Commom.smethod_77();
									text8 = text7 + "variables={\"input\":{\"client_mutation_id\":\"8\",\"actor_id\":\"" + A088E59D + "\",\"new_password\":\"" + text + "\",\"token\":{\"sensitive_string_value\":\"" + text11 + "\"}},\"scale\":1}&doc_id=5527135747335631";
									text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text9,
										"x-fb-lsd: " + text5
									});
								}
								else
								{
									if (!(text16 == "EpsilonProfilesReview"))
									{
										goto IL_110f;
									}
									smethod_12(int_0, string_0 + "Review profile...");
									text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
									text10 = "CONTACT_POINT_REVIEW";
									text9 = "useEpsilonNavigateMutation";
									text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22step%22%3A%22" + text10 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=8466618156761750";
									text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text9,
										"x-fb-lsd: " + text5
									});
								}
							}
							else
							{
								if (num4 > 3198980747u)
								{
									if (num4 != 3318294281u)
									{
										if (num4 == 3760394666u && text16 == "EpsilonStepperScreen")
										{
											smethod_12(int_0, string_0 + "Click next...");
											text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
											text10 = Commom.F914B80B(text3, "\"next_screen\":\"(.*?)\"");
											text9 = "useEpsilonNavigateMutation";
											text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%221%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22step%22%3A%22" + text10 + "%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=";
											text8 = ((!(text10 == "PROFILE_REVIEW")) ? (text8 + "9385152714844566") : (text8 + "8466618156761750"));
											text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text9,
												"x-fb-lsd: " + text5
											});
											goto IL_14d4;
										}
									}
									else if (text16 == "IXTAuthenticityWizardContactPointConfirmationScreenViewModel")
									{
										goto IL_11be;
									}
									goto IL_110f;
								}
								if (num4 != 3141059881u)
								{
									if (num4 != 3198980747u || !(text16 == "EpsilonContactPointReview"))
									{
										goto IL_110f;
									}
									smethod_12(int_0, string_0 + "Review contact...");
									string text23 = "";
									string text24 = "";
									if (C5034B95.smethod_0("configCheckpoint").method_3("ckbDeleteContact"))
									{
										foreach (JToken item4 in (IEnumerable<JToken>)(jObject["data"]!["epsilon_navigate"]!["epsilon_checkpoint"]!["screen"]!["contact_points"]!))
										{
											if (item4["label"]!.ToString() != C90C3FB4.ToLower())
											{
												text23 += string.Format("\"{0}\",", item4["label"]);
												text24 += string.Format("\"{0}\",", item4["id"]);
											}
										}
										if (text23 != "")
										{
											text23 = text23.TrimEnd(',');
										}
										if (text24 != "")
										{
											text24 = text24.TrimEnd(',');
										}
									}
									text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
									text9 = "useRemoveContactPointsMutation";
									text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%223%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22cps_to_remove%22%3A%5B" + text23 + "%5D%2C%22ids_to_remove%22%3A%5B" + text24 + "%5D%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=8880988131920703";
									text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text9,
										"x-fb-lsd: " + text5
									});
								}
								else
								{
									if (!(text16 == "EpsilonMessageCodeCaptcha"))
									{
										goto IL_110f;
									}
									smethod_12(int_0, string_0 + "Select email...");
									List<string> list3 = new List<string>();
									foreach (JToken item5 in (IEnumerable<JToken>)(jObject["data"]!["epsilon_navigate"]!["epsilon_checkpoint"]!["screen"]!["eligible_contact_points"]!))
									{
										if (item5["medium"]!.ToString().ToLower() == "email")
										{
											list3.Add(item5["contact_point"]!.ToString().ToLower());
										}
									}
									string string_5 = C90C3FB4.Substring(C90C3FB4.IndexOf('@') - 1, 3);
									text12 = list3.Where((string A285511D) => A285511D.Contains(string_5)).FirstOrDefault();
									if (text12 == null)
									{
										item = "Unlock 956 Fail (" + Language.GetValue("Fb bắt xác minh email không có trên tool") + ")";
										break;
									}
									text2 = FB93BDA4.GetOtpFromMail(1, C90C3FB4, string_1, string_2, string_3, 0, A088E59D, "");
									if (text2 == "fail")
									{
										item = "Unlock 956 Fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
										break;
									}
									text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
									text9 = "CometIXTFacebookXfacUniversalTriggerRootQuery";
									text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_token%22%3A%22" + text11 + "%22%2C%22trigger_event_type%22%3A%22XFAC_UNIVERSAL_ENTRY%22%2C%22xfac_appeal_type%22%3A%22CHECKPOINT_EPSILON%22%2C%22xfac_config%22%3A%22XFAC_EPSILON_EMAIL_OTP%22%2C%22nt_context%22%3Anull%2C%22trigger_session_id%22%3A%226b1db461-5391-4c8a-a0b8-63d303e4ef95%22%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=7916320065138329";
									text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
									{
										"x-fb-friendly-name: " + text9,
										"x-fb-lsd: " + text5
									});
									if (text3.Contains("\"errors\""))
									{
										text9 = "useSendCaptchaCodeMutation";
										text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22contact_point%22%3A%22" + text12 + "%22%2C%22index%22%3A0%2C%22medium%22%3A%22EMAIL%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=8453582888028888";
										text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text9,
											"x-fb-lsd: " + text5
										});
									}
								}
							}
							goto IL_14d4;
							IL_14d4:
							if (Environment.TickCount - tickCount < 600000)
							{
								Commom.smethod_52(1.0);
								continue;
							}
							item = "Unlock 956 Fail (Timeout)";
							break;
							IL_110f:
							if (!text3.Contains("571927962827151"))
							{
								if (!text3.Contains("1501092823525282"))
								{
									if (!text3.Contains("m_login_email"))
									{
										if (text3.Contains("601051028565049"))
										{
											smethod_12(int_0, string_0 + "Click dismiss...");
											text9 = "FBScrapingWarningMutation";
											text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%7D&server_timestamps=true&doc_id=6339492849481770";
											text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text9,
												"x-fb-lsd: " + text5
											});
											goto IL_14d4;
										}
										text3 = requestXNet_0.E58EB99F("https://www.facebook.com/");
										text4 = requestXNet_0.method_5();
										if (text4.Contains("1501092823525282"))
										{
											item2 = (item = "Checkpoint: 282");
										}
										else if (text4.Contains("facebook.com/gettingstarted") || (text3.Contains("href=\"/menu/bookmarks/") && text3.Contains("id=\"mbasic_logout_button\"")) || (text3.Contains("id=\"MComposer\"") && text3.Contains("id=\"MBackNavBar\"")) || text3.Contains("\"is_checkpointed\":false"))
										{
											flag = true;
										}
										else
										{
											item = "Unlock 956 Fail (Please try again 3)";
										}
										break;
									}
									item = "Unlock 956 Fail (1)";
									break;
								}
								item2 = (item = "Checkpoint: 282");
								break;
							}
							item = "Unlock 956 Fail (Spam)";
							break;
							IL_11be:
							num++;
							if (num < num2)
							{
								smethod_12(int_0, string_0 + "Get otp...");
								string text25 = FB93BDA4.GetOtpFromMail(1, C90C3FB4, string_1, string_2, string_3, 60, A088E59D, text2);
								if (!(text25 == "fail"))
								{
									if (text25 == "")
									{
										text9 = "useSendCaptchaCodeMutation";
										text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22contact_point%22%3A%22" + text12 + "%22%2C%22index%22%3A0%2C%22medium%22%3A%22EMAIL%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=8453582888028888";
										text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
										{
											"x-fb-friendly-name: " + text9,
											"x-fb-lsd: " + text5
										});
									}
									else
									{
										text2 = text25;
										smethod_12(int_0, string_0 + "Submit otp...");
										if (text14 == "EpsilonEnterMessageCodeCaptcha")
										{
											text11 = Commom.F914B80B(text3, "\"token\":\"(.*?)\"");
											text9 = "useVerifyCaptchaCodeMutation";
											text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%225%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22code%22%3A%22" + text25 + "%22%2C%22medium%22%3A%22EMAIL%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=7309059885884471";
											text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text9,
												"x-fb-lsd: " + text5
											});
											if (text3.Contains("\"errors\""))
											{
												text9 = "useSendCaptchaCodeMutation";
												text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22contact_point%22%3A%22" + text12 + "%22%2C%22index%22%3A0%2C%22medium%22%3A%22EMAIL%22%2C%22token%22%3A%7B%22sensitive_string_value%22%3A%22" + text11 + "%22%7D%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=8453582888028888";
												text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
												{
													"x-fb-friendly-name: " + text9,
													"x-fb-lsd: " + text5
												});
											}
										}
										else
										{
											text13 = jObject["data"]!["ixt_screen_next"]!["view_model"]!["serialized_state"]!.ToString();
											text9 = "CometFacebookWithLoggedOutIXTNextMutation";
											text8 = text7 + "fb_api_req_friendly_name=" + text9 + "&variables=%7B%22input%22%3A%7B%22authenticity_wizard_contact_point_confirmation%22%3A%7B%22confirmation_code%22%3A%22" + text25 + "%22%2C%22serialized_state%22%3A%22" + text13 + "%22%7D%2C%22actor_id%22%3A%22" + A088E59D + "%22%2C%22client_mutation_id%22%3A%222%22%7D%2C%22scale%22%3A3%7D&server_timestamps=true&doc_id=8760610473984639";
											text3 = requestXNet_0.E2028331("https://www.facebook.com/api/graphql/", text8, "application/x-www-form-urlencoded", new string[2]
											{
												"x-fb-friendly-name: " + text9,
												"x-fb-lsd: " + text5
											});
										}
									}
									goto IL_14d4;
								}
								item = "Unlock 956 Fail (" + Language.GetValue("Không thể kết nối mail!") + ")";
								break;
							}
							item = "Unlock 956 Fail (Không lấy được otp)";
							break;
						}
					}
					else
					{
						item = "Unlock 956 Fail (Please try again 2)";
					}
					break;
				}
			}
		}
		catch (Exception ex2)
		{
			smethod_14(ex2.ToString(), A088E59D);
			item = "Unlock 956 Fail (Please try again)";
		}
		if (flag)
		{
			item2 = "Live";
			item = "Unlock checkpoint success";
		}
		return (item, item2, text);
	}

	public static void smethod_14(string string_0, string ABBA5512)
	{
		string path = "log\\unlock956.txt";
		lock (B606C39F)
		{
			try
			{
				File.AppendAllText(path, "------------------ " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n");
				if (ABBA5512 != "")
				{
					File.AppendAllText(path, "Uid: " + ABBA5512 + "\r\n");
				}
				File.AppendAllText(path, string_0 + "\r\n");
			}
			catch (Exception)
			{
			}
		}
	}

	public static GClass4 C180C594(string string_0, string string_1, string CD84C588, string string_2, string string_3, int int_0)
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("success", false);
		gClass.method_4("error", "");
		RequestXNet requestXNet = new RequestXNet("", "", string_3, int_0);
		string text = "";
		requestXNet.E58EB99F("https://www.facebook.com/");
		text = requestXNet.E58EB99F("https://www.facebook.com/login/?next=https%3A%2F%2Fwww.facebook.com%2F");
		string value = Regex.Match(text, "\"LSD\",\\[\\],{\"token\":\"(.*?)\"}").Groups[1].Value;
		string d = "jazoest=2111&lsd=" + value + "&email=" + string_0 + "&login_source=comet_headerless_login&next=&encpass=%23PWD_BROWSER%3A0%3A" + Convert.ToInt32(Commom.smethod_15(DateTime.Now)) + "%3A" + string_1;
		requestXNet.F089DBB3.AddHeader("x-fb-lsd", value);
		text = requestXNet.method_1("https://www.facebook.com/login/?privacy_mutation_token=", d);
		int num = 3;
		int num2 = 3;
		bool flag = false;
		for (int i = 0; i < 20; i++)
		{
			string value2 = Regex.Match(text, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
			string value3 = Regex.Match(text, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
			string value4 = Regex.Match(text, "name=\"nh\" value=\"(.*?)\"").Groups[1].Value;
			if (text.Contains("approvals_code"))
			{
				num2--;
				if (num2 < 0)
				{
					gClass.method_4("error", "Sai 2fa");
					break;
				}
				string text2 = Commom.smethod_62(CD84C588);
				d = "jazoest=" + value3 + "&fb_dtsg=" + value2 + "&nh=" + value4 + "&no_fido=true&approvals_code=" + text2 + "&submit%5BContinue%5D=Continue";
			}
			else if (text.Contains("save_device"))
			{
				d = "jazoest=" + value3 + "&fb_dtsg=" + value2 + "&nh=" + value4 + "&name_action_selected=save_device&submit%5BContinue%5D=Continue";
			}
			else if (text.Contains("submit[Continue]"))
			{
				d = "jazoest=" + value3 + "&fb_dtsg=" + value2 + "&nh=" + value4 + "&submit%5BContinue%5D=Continue";
			}
			else if (text.Contains("submit[This was me]"))
			{
				d = "jazoest=" + value3 + "&fb_dtsg=" + value2 + "&nh=" + value4 + "&submit%5BThis+wasn%27t+me%5D=This+wasn%27t+me";
			}
			else if (text.Contains("password_new"))
			{
				gClass.method_4("newPass", string_2);
				d = "jazoest=" + value3 + "&fb_dtsg=" + value2 + "&nh=" + value4 + "&password_new=" + string_2 + "&password_confirm=" + string_2 + "&submit%5BChange+Password%5D=Change+Password";
			}
			else
			{
				if (text.Contains("/login/identify/"))
				{
					gClass.method_4("error", "Sai user");
					break;
				}
				if (text.Contains("not_me_link") || text.Contains("/recover/initiate/"))
				{
					gClass.method_4("error", "Sai pass");
					break;
				}
				Match match = Regex.Match(text, "CurrentUserInitialData\",\\[\\],{\"ACCOUNT_ID\":\"(\\d+)\",\"USER_ID\":\"(\\d+)\",\"NAME\":\"(.*?)\"");
				if (match.Success && match.Groups[1].Value == match.Groups[2].Value && match.Groups[3].Value != "")
				{
					gClass.method_4("success", true);
					break;
				}
				num--;
				if (num < 0)
				{
					if (!flag)
					{
						flag = true;
						requestXNet = new RequestXNet();
						text = requestXNet.E58EB99F("https://www.facebook.com/");
						string value5 = Regex.Match(text, "privacy_mutation_token=(.*?)\"").Groups[1].Value;
						if (value5 != "")
						{
							requestXNet = new RequestXNet(requestXNet.method_4(), "", string_3, int_0);
							value = Regex.Match(text, "\"LSD\",\\[\\],{\"token\":\"(.*?)\"}").Groups[1].Value;
							d = "jazoest=2111&lsd=" + value + "&email=" + string_0 + "&login_source=comet_headerless_login&next=&encpass=%23PWD_BROWSER%3A0%3A" + Convert.ToInt32(Commom.smethod_15(DateTime.Now)) + "%3A" + string_1;
							requestXNet.F089DBB3.AddHeader("x-fb-lsd", value);
							text = requestXNet.method_1("https://www.facebook.com/login/?privacy_mutation_token=" + value5, d);
							continue;
						}
					}
					gClass.method_4("error", "try_again");
					break;
				}
			}
			text = requestXNet.method_1("https://www.facebook.com/checkpoint/?next", d);
		}
		if (gClass.method_3("success") && gClass.BDB80B23("newPass") == "")
		{
			gClass.method_4("success", false);
			gClass.method_4("error", "Không co\u0301 tu\u0300y cho\u0323n đô\u0309i pass");
		}
		return gClass;
	}

	internal static string smethod_15(string string_0, string DC0F2083, string E32BF4A6, int int_0, string string_1)
	{
		string result = "";
		try
		{
			string json = Commom.smethod_85($"GetPageProfile2('{string_0}','{DC0F2083}','{E32BF4A6}',{int_0}, '{string_1}')");
			JArray jArray = JArray.Parse(json);
			result = jArray[0]["uid"]!.ToString() + "|" + jArray[0]["token"]!.ToString();
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static int smethod_16(string string_0)
	{
		int result = 0;
		if (string_0.StartsWith("https://www.facebook") || string_0.StartsWith("https://facebook") || string_0.StartsWith("https://web.facebook"))
		{
			result = 1;
		}
		else if (string_0.StartsWith("https://m.facebook") || string_0.StartsWith("https://mobile.facebook"))
		{
			result = 2;
		}
		else if (string_0.StartsWith("https://mbasic.facebook") || string_0.StartsWith("https://d.facebook"))
		{
			result = 3;
		}
		return result;
	}

	internal static string smethod_17(string D91E0703, string string_0, int A2323C2F)
	{
		try
		{
			string text = "https://www.facebook.com";
			RequestXNet requestXNet = new RequestXNet("", ModernUserAgentHub.GetRandomDesktopChrome(), string_0, A2323C2F);
			string input = requestXNet.E58EB99F(text + "/login/identify/?ctx=recover&from_login_screen=0");
			string value = Regex.Match(input, "name=\"lsd\" value=\"(.*?)\"").Groups[1].Value;
			if (value == "")
			{
				text = "https://web.facebook.com";
				input = requestXNet.E58EB99F(text + "/login/identify/?ctx=recover&from_login_screen=0");
				value = Regex.Match(input, "name=\"lsd\" value=\"(.*?)\"").Groups[1].Value;
			}
			if (value == "")
			{
				return Language.GetValue("Gư\u0309i yêu câ\u0300u thâ\u0301t ba\u0323i!");
			}
			string string_ = text + "/ajax/login/help/identify.php?ctx=recover";
			string d = "jazoest=2111&lsd=" + value + "&email=" + D91E0703 + "&did_submit=1&__user=0&__a=1&__dyn=&__csr=&__req=8&__hs=&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=0&__spin_r=&__spin_b=trunk&__spin_t=";
			requestXNet.F089DBB3.AddHeader("x-fb-lsd", value);
			input = requestXNet.method_1(string_, d);
			if (input.Contains("571927962827151"))
			{
				return Language.GetValue("Chặn tính năng!");
			}
			string value2 = Regex.Match(input, "ldata=(.*?)\"").Groups[1].Value;
			if (value2 == "")
			{
				try
				{
					input = JObject.Parse(input.Replace("for (;;);", ""))["domops"]![0]![3]!["__html"]!.ToString();
					string value3 = Regex.Match(input, "fwb fcb\\\">(.*?)<").Groups[1].Value;
					if (value3 != "")
					{
						return value3;
					}
				}
				catch (Exception)
				{
				}
				return Language.GetValue("Gư\u0309i yêu câ\u0300u thâ\u0301t ba\u0323i!");
			}
			input = requestXNet.E58EB99F(text + "/recover/initiate/?ldata=" + value2);
			input = requestXNet.E58EB99F(text + "/login/web/?email=" + Commom.smethod_54(D91E0703) + "&is_from_lara=1");
			value = Regex.Match(input, "name=\"lsd\" value=\"(.*?)\"").Groups[1].Value;
			if (value == "")
			{
				return Language.GetValue("Gư\u0309i yêu câ\u0300u thâ\u0301t ba\u0323i!");
			}
			requestXNet.F089DBB3.AddHeader("x-fb-lsd", value);
			input = requestXNet.method_1(text + "/ajax/recover/initiate/?lara=0", "jazoest=2111&lsd=" + value + "&openid_provider_id=&openid_provider_name=&recover_method=send_email&reset_action=1&__user=0&__a=1&__dyn=&__csr=&__req=8&__hs=&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=0&__spin_r=&__spin_b=trunk&__spin_t=");
			string_ = Regex.Match(input, "redirectPageTo\",\\[\\],\\[\"(.*?)\"").Groups[1].Value;
			if (string_ == "")
			{
				try
				{
					string text2 = JObject.Parse(input.Replace("for (;;);", ""))["errorSummary"]!.ToString();
					if (text2 != "")
					{
						return text2;
					}
				}
				catch (Exception)
				{
				}
				return Language.GetValue("Gư\u0309i yêu câ\u0300u thâ\u0301t ba\u0323i!");
			}
			string_ = JObject.Parse("{\"data\":\"" + string_ + "\"}")["data"]!.ToString();
			input = requestXNet.E58EB99F(string_);
			if (input.Contains(Commom.smethod_54(D91E0703)))
			{
				return "true";
			}
		}
		catch (Exception)
		{
		}
		return Language.GetValue("Lô\u0303i gửi yêu cầu!");
	}
}
