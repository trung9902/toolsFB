using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;

public class GClass2
{
	public static string smethod_0(int int_0, string F523B7AA)
	{
		string result = "";
		if (int_0 == 0 || int_0 == 1)
		{
			result = GClass14.smethod_2(int_0, F523B7AA, "6LeyIlkaAAAAAE-EjcALU28lwxWPusUvGL3e0avS", "https://fbsbx.com/captcha/recaptcha/iframe/");
		}
		else
		{
			switch (int_0)
			{
			case 4:
				result = DB81C53D.smethod_1(F523B7AA, "6LeyIlkaAAAAAE-EjcALU28lwxWPusUvGL3e0avS", "https://fbsbx.com/captcha/recaptcha/iframe/");
				break;
			case 7:
				result = Class21.smethod_1(F523B7AA, "6LeyIlkaAAAAAE-EjcALU28lwxWPusUvGL3e0avS", "https://fbsbx.com/captcha/recaptcha/iframe/");
				break;
			case 8:
				result = GClass5.smethod_0(F523B7AA, "6LeyIlkaAAAAAE-EjcALU28lwxWPusUvGL3e0avS", "https://fbsbx.com/captcha/recaptcha/iframe/");
				break;
			}
		}
		return result;
	}

	public static string smethod_1(int int_0, string A52D8580, string string_0)
	{
		string result = "";
		// Ưu tiên Gemini Vision AI nếu người dùng cấu hình chọn loại 9 hoặc nếu API key là Gemini (AIza...)
		if (int_0 == 9 || (!string.IsNullOrEmpty(A52D8580) && A52D8580.StartsWith("AIza", StringComparison.OrdinalIgnoreCase)))
		{
			string geminiKey = (!string.IsNullOrEmpty(A52D8580) && !A52D8580.StartsWith("http")) ? A52D8580 : GeminiVisionCaptchaHelper.GetGeminiApiKey();
			result = GeminiVisionCaptchaHelper.SolveImageCaptcha(string_0, geminiKey);
			if (!string.IsNullOrEmpty(result))
			{
				return result;
			}
		}

		if (DB81C53D.smethod_2(C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4")))
		{
			return DB81C53D.smethod_0(C5034B95.smethod_0("configCheckpoint").BDB80B23("txtCaptcha_4"), string_0);
		}
		if (int_0 == 0)
		{
			result = GClass14.smethod_0(int_0, A52D8580, string_0);
		}

		// Fallback sang Gemini Vision AI nếu các bên khác không giải được hoặc chưa cấu hình nhưng có sẵn Gemini API key
		if (string.IsNullOrEmpty(result))
		{
			string fallbackGeminiKey = GeminiVisionCaptchaHelper.GetGeminiApiKey();
			if (!string.IsNullOrEmpty(fallbackGeminiKey))
			{
				result = GeminiVisionCaptchaHelper.SolveImageCaptcha(string_0, fallbackGeminiKey);
			}
		}

		return result;
	}

	public static string D90B63A4(int int_0, string DE8C6293, int A2198426, string string_0 = "", string AC10258A = "")
	{
		string result = "";
		switch (int_0)
		{
		case 1:
			result = FD999E33(DE8C6293, A2198426);
			break;
		case 2:
			result = D22BA2B3(DE8C6293, A2198426);
			break;
		case 3:
			result = smethod_50(DE8C6293, A2198426);
			break;
		case 4:
			result = C61AC63E(DE8C6293, A2198426);
			break;
		case 5:
			result = smethod_52(DE8C6293, A2198426);
			break;
		case 6:
			result = smethod_54(DE8C6293, A2198426);
			break;
		case 8:
			result = smethod_5(DE8C6293, A2198426);
			break;
		case 9:
			result = smethod_12(DE8C6293, A2198426);
			break;
		case 10:
			result = smethod_42(DE8C6293, A2198426, string_0);
			break;
		case 12:
			result = smethod_37(DE8C6293, A2198426);
			break;
		case 13:
			result = smethod_32(DE8C6293, A2198426);
			break;
		case 14:
			result = A124AF8F(DE8C6293, A2198426);
			break;
		case 15:
			result = smethod_36(DE8C6293, A2198426);
			break;
		case 16:
			result = smethod_2(DE8C6293, A2198426);
			break;
		case 17:
			result = E10FFC0C(DE8C6293, A2198426);
			break;
		case 18:
			result = CE9A5081(DE8C6293, A2198426);
			break;
		case 19:
			result = smethod_4(DE8C6293, A2198426);
			break;
		case 21:
			result = smethod_35(DE8C6293, A2198426);
			break;
		case 23:
			result = smethod_3(DE8C6293, A2198426);
			break;
		case 25:
			result = smethod_34(DE8C6293, A2198426);
			break;
		case 26:
			result = E43CE7A7(DE8C6293, A2198426);
			break;
		case 27:
			result = F222A71B(DE8C6293, A2198426);
			break;
		case 28:
			result = smethod_31(DE8C6293, A2198426);
			break;
		case 29:
			result = smethod_6(DE8C6293, A2198426);
			break;
		case 30:
			result = smethod_44(DE8C6293, A2198426);
			break;
		case 31:
			result = AD33C12A(DE8C6293, A2198426);
			break;
		case 32:
			result = smethod_33(DE8C6293, A2198426);
			break;
		case 33:
			result = smethod_38(DE8C6293, A2198426);
			break;
		case 34:
			result = smethod_7(DE8C6293, A2198426);
			break;
		case 35:
			result = smethod_8(DE8C6293, A2198426);
			break;
		case 36:
			result = B69BB5A8(DE8C6293, A2198426);
			break;
		case 38:
			result = smethod_11(DE8C6293, A2198426, 1);
			break;
		case 39:
			result = smethod_9(DE8C6293, A2198426);
			break;
		case 40:
			result = smethod_10(DE8C6293, A2198426);
			break;
		case 41:
			result = smethod_44(DE8C6293, A2198426, 428);
			break;
		case 42:
			result = D6B79322(DE8C6293, A2198426);
			break;
		case 43:
			result = smethod_11(DE8C6293, A2198426, 6);
			break;
		case 45:
			result = smethod_37(DE8C6293, A2198426, "facebook_ru");
			break;
		case 46:
			result = E019472E(DE8C6293, A2198426);
			break;
		case 47:
			result = E5858A09(DE8C6293, A2198426);
			break;
		case 48:
			result = smethod_12(DE8C6293, A2198426, 133);
			break;
		case 49:
			result = smethod_13(DE8C6293, A2198426);
			break;
		case 52:
			result = smethod_32(DE8C6293, A2198426, "facebook_us");
			break;
		case 53:
			result = DB8AA3AA(DE8C6293, A2198426);
			break;
		case 54:
			result = smethod_44(DE8C6293, A2198426, 440);
			break;
		case 56:
			result = smethod_45(DE8C6293, A2198426);
			break;
		case 59:
			result = smethod_46(DE8C6293, A2198426);
			break;
		case 61:
			result = DC88CD9F(DE8C6293, A2198426);
			break;
		case 62:
			result = smethod_47(DE8C6293, A2198426);
			break;
		}
		return result;
	}

	private static string E10FFC0C(string string_0, int F582DE2F)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		List<string> list = new List<string>();
		do
		{
			for (int num = 4; num > 0; num--)
			{
				try
				{
					string string_ = $"https://2ndline.pro/apiv1/order?apikey={string_0}&serviceId=275&networkId={num}&allowVoiceSms=false";
					text = requestHttp.method_0(string_);
					JObject jObject = JObject.Parse(text);
					text3 = jObject["id"]!.ToString();
					text2 = jObject["phone"]!.ToString();
					if (text3 != "" && text2 != "")
					{
						return text3 + "|" + text2;
					}
					if (text3 != "")
					{
						list.Add(text3);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		while (list.Count <= 0);
		do
		{
			for (int i = 0; i < list.Count; i++)
			{
				text3 = list[i];
				try
				{
					text = requestHttp.method_0("https://2ndline.pro/apiv1/ordercheck?apikey=" + string_0 + "&id=" + text3);
					JObject jObject2 = JObject.Parse(text);
					text2 = jObject2["data"]!["phone"]!.ToString();
					if (text3 != "" && text2 != "")
					{
						return text3 + "|" + text2;
					}
				}
				catch (Exception)
				{
				}
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < F582DE2F * 1000);
		return text3 + "|" + text2;
	}

	private static string smethod_2(string string_0, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("https://otp282.com/api/createRequestOTP/" + string_0 + "/service_id/1");
				JObject jObject = JObject.Parse(text);
				text3 = jObject["data"]![0]!["request_id"]!.ToString();
				text2 = jObject["data"]![0]!["phone"]!.ToString();
				if (text3 != "" && text2 != "")
				{
					break;
				}
			}
			catch (Exception)
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text2;
	}

	private static string smethod_3(string AFACF20B, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.EF076293("https://codeotp.site/api/getphone", "token=" + AFACF20B + "&appid=9");
				JObject jObject = JObject.Parse(text);
				text3 = jObject["msg"]!["id"]!.ToString();
				text2 = jObject["msg"]!["number"]!.ToString();
				if (text3 != "" && text2 != "")
				{
					break;
				}
			}
			catch (Exception)
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text2;
	}

	private static string smethod_4(string string_0, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("http://hcotp.com/api/v2/createrequest?token=" + string_0 + "&serviceId=1&carrier=all");
				JObject jObject = JObject.Parse(text);
				text3 = jObject["id"]!.ToString();
				text2 = jObject["phoneNum"]!.ToString();
				if (text3 != "" && text2 != "")
				{
					break;
				}
			}
			catch (Exception)
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text2;
	}

	public static string smethod_5(string string_0, int F98E8882, int E0B99E93 = 7)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://api.viotp.com/request/getv2?token=" + string_0 + "&serviceId=" + E0B99E93);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["request_id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["phone_number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < F98E8882 * 1000);
		return text3 + "|" + text;
	}

	public static string F222A71B(string string_0, int C2B2E307)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("http://otptele.com/json/request/getv2.php?token=" + string_0 + "&serviceId=63c1131b0e33b");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["request_id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["phone_number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < C2B2E307 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_6(string B3A8AA95, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://otpngon.com/public/api/getNumber?api_key=" + B3A8AA95 + "&service_id=1");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["Data"]![0]!["Request_ID"]!.ToString();
				if (text3 != "")
				{
					text = jObject["Data"]![0]!["Phone"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_7(string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://atmteamfb.com/public/api/getNumber?api_key=" + string_0 + "&service_id=1");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["Data"]![0]!["Request_ID"]!.ToString();
				if (text3 != "")
				{
					text = jObject["Data"]![0]!["Phone"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_8(string string_0, int B53203A3)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://tskvb.com/pick_isdn?service=Facebook&apikey=" + string_0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["isdn"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < B53203A3 * 1000);
		return text3 + "|" + text;
	}

	public static string B69BB5A8(string CE9A35BC, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://api.usotp.xyz/create-request?apikey=" + CE9A35BC + "&service=facebook&softid=tungmin");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["phone"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string E5858A09(string E6AED996, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("http://otp.vocfor.site/pick_isdn?Brand=facebook&Token=" + E6AED996);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["isdn"]!.ToString();
				if (text3 != "")
				{
					text = jObject["isdn"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string E019472E(string string_0, int E3AC5692)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("http://live24h.shop/api/w1/BuyService?api_token=" + string_0 + "&service_id=6");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["phone"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < E3AC5692 * 1000);
		return text3 + "|" + text;
	}

	public static string D6B79322(string D5AD942D, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://api.thuesim.cloud/utils/request-number-for-tool?clientId=" + D5AD942D + "&appCode=Facebook");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["requestId"]!.ToString();
				if (text3 != "")
				{
					text = jObject["number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_9(string F0959917, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("http://api.smartotp.net:3001/api/facebook/" + F0959917);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["phoneNumber"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_10(string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://access.thuesimgiare.com/api/sim-request?token=" + string_0 + "&service=19");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["phone"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_11(string FC80E725, int C89B9820, int int_0)
	{
		string text = "";
		RequestXNet requestXNet = new RequestXNet();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				requestXNet.F089DBB3.AddHeader("code", "maxcarecutevippro");
				text2 = requestXNet.E58EB99F($"https://fullcode.me/api/public/user/sim/buy/v2?appId={int_0}&apiKey={FC80E725}");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["resultObj"]!["value"]!["id"]!.ToString();
				text = jObject["resultObj"]!["value"]!["number"]!.ToString();
				if (text3 != "" && text != "")
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < C89B9820 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_12(string string_0, int E0A81B2E, int int_0 = 1)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("http://otptextnow.com/api/?key=" + string_0 + "&action=get_number&id=" + int_0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["request_id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < E0A81B2E * 1000);
		return text3 + "|" + text;
	}

	public static string DB8AA3AA(string string_0, int int_0, int F6AC2C1F = 1)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://fastsim.online/api/sim/buy?key=" + string_0 + "&app=1");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_13(string string_0, int ED1C6B9B)
	{
		string text = "";
		RequestXNet requestXNet = new RequestXNet();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string d = "{ \"api_key\":\"" + string_0 + "\", \"appId\":9}";
				text2 = requestXNet.method_1("https://api.233io9.info/api/dangkysim", d, "application/json");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["Result"]!["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["Result"]!["number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < ED1C6B9B * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_14(string string_0, string AC130B9F, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://api.viotp.com/session/getv2?requestId=" + AC130B9F + "&token=" + string_0);
				JObject jObject = JObject.Parse(json);
				if (jObject["status_code"]!.ToString() == "200")
				{
					try
					{
						text = Regex.Match(jObject["data"]!["Code"]!.ToString(), "\\d+").Value;
						if (text != "")
						{
							return text;
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string D5919C3F(string string_0, string string_1, int BF8DE43A = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= BF8DE43A * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://mthgroup.vn:8066/api2/?key=" + string_0 + "&phone=" + string_1 + "&excludeLayout&brand=Facebook");
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["content"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_15(string BA23210D, string B3B0ED13, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://fastsim.online/api/sim/check?key=" + BA23210D + "&id=" + B3B0ED13);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["data"]!["code"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_16(string string_0, string string_1, int D0A4652D = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= D0A4652D * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://api.random-otp.io.vn:8450/sms/getStatusCode?apiKey=" + string_0 + "&idPhoneNumber=" + string_1);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["otp"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_17(string string_0, string string_1, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://muasms.com/api/order.php?token=" + string_0 + "&trans_id=" + string_1);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["data"]!["otp"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_18(string F406D399, string string_0, int B10D9A84 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= B10D9A84 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://apisim.codesim.net/otp/get_otp_by_phone_api_key?otp_id=" + string_0 + "&api_key=" + F406D399);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["data"]!["code"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(5000);
		}
		return text;
	}

	public static string smethod_19(string ECB8CE85, string D32166A8, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://otptele.com/json/session/getv2.php?requestId=" + D32166A8 + "&token=" + ECB8CE85);
				JObject jObject = JObject.Parse(json);
				text = jObject["data"]!["Code"]!.ToString();
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_20(string D93F4F3A, string FA9EC53B, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://otpngon.com/public/api/getOTP?api_key=" + D93F4F3A + "&request_id=" + FA9EC53B);
				JObject jObject = JObject.Parse(json);
				text = jObject["Data"]![0]!["OTP"]!.ToString();
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_21(string A81C680E, string A78DFA2A, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://atmteamfb.com/public/api/getOTP?api_key=" + A81C680E + "&request_id=" + A78DFA2A);
				JObject jObject = JObject.Parse(json);
				text = jObject["Data"]![0]!["OTP"]!.ToString();
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_22(string string_0, string string_1, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://tskvb.com/get_otp?id_order=" + string_1 + "&apikey=" + string_0);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["data"]![0]!["content"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_23(string string_0, string string_1, int B103842B = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= B103842B * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://api.usotp.xyz/get-request?apikey=" + string_0 + "&id=" + string_1);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["code"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_24(string F4184A9D, string string_0, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://live24h.shop/api/w1/SessionData?api_token=" + F4184A9D + "&id=" + string_0);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["data"]!["code"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_25(string string_0, string BE2EABA9, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://otp.vocfor.site/get_otp?Brand=facebook&Token=" + string_0 + "&Isdn=" + BE2EABA9);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["otp"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_26(string string_0, string string_1, int int_0 = 120)
	{
		string text = "";
		RequestXNet requestXNet = new RequestXNet();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string d = "{ \"api_key\":\"" + string_0 + "\", \"id\":" + string_1 + "}";
				string json = requestXNet.method_1("https://api.233io9.info/api/layotpByID", d, "application/json");
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["Result"]![0]!["otp"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string CBB95A0F(string string_0, string D539BD1F, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://api.thuesim.cloud/utils/get-code-for-tool?clientId=" + string_0 + "&requestId=" + D539BD1F);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["content"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_27(string string_0, string string_1, int A0BF6332 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= A0BF6332 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://api.smartotp.net:3001/api/order/" + string_1 + "/" + string_0);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["content"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_28(string A4910293, string string_0, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://access.thuesimgiare.com/api/get-message?token=" + A4910293 + "&phone=" + string_0);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["message"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_29(string DF184698, string ED81CF33, int E22F7D9C)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= E22F7D9C * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://fullcode.me/api/public/user/sim/v2?orderId=" + ED81CF33 + "&apiKey=" + DF184698);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["resultObj"]!["code"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string smethod_30(string B992EDBA, string C737BF8C, int A40D5F00 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= A40D5F00 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://otptextnow.com/api/?key=" + B992EDBA + "&action=get_code&id=" + C737BF8C);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["otp_code"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
				Thread.Sleep(3000);
			}
			catch
			{
			}
		}
		return text;
	}

	public static string A124AF8F(string string_0, int int_0)
	{
		RequestXNet requestXNet = new RequestXNet();
		string text = "";
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestXNet.E58EB99F("https://administrator.codetext247.com/api/sim-request?token=" + string_0 + "&service=19");
				JObject jObject = JObject.Parse(text);
				text2 = jObject["phone"]!.ToString();
				if (text2 != "")
				{
					return text2;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text2;
	}

	public static string CE9A5081(string C30BBF80, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("https://sosotps.com/get_sdt.php?apikey=" + C30BBF80 + "&dichvu=10");
				if (text.Split('|')[0] == "OK")
				{
					text2 = text.Split('|')[1];
				}
				if (text2 != "")
				{
					return text2;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text2;
	}

	public static string smethod_31(string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("http://171.244.56.172:9152/pick_isdn?service=Facebook&apikey=" + string_0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["isdn"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_32(string AEA713A0, int int_0, string string_0 = "facebook")
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://funotp.com/api?action=number&service=" + string_0 + "&apikey=" + AEA713A0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["Result"]!["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["Result"]!["number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string AD33C12A(string F71B4F04, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				if (text3 == "")
				{
					text2 = requestHttp.method_0("https://sell282.xyz/api/sim/buy?api_key=" + F71B4F04 + "&service=9");
					JObject jObject = JObject.Parse(text2);
					text3 = jObject["data"]!["code_order"]!.ToString();
					text = jObject["data"]!["phone"]!.ToString();
				}
				if (text3 != "" && text != "")
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_33(string DC075203, int B90F49BB)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				if (text3 == "")
				{
					text2 = requestHttp.method_0("https://api.thuesim.app/api/facebook/" + DC075203);
					JObject jObject = JObject.Parse(text2);
					text3 = jObject["id"]!.ToString();
					text = jObject["phoneNumber"]!.ToString();
				}
				if (text3 != "" && text != "")
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < B90F49BB * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_34(string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				if (text3 == "")
				{
					text2 = requestHttp.method_0("https://numberotp.co/public/api/gsm/order/facebook/" + string_0);
					JObject jObject = JObject.Parse(text2);
					text3 = jObject["id"]!.ToString();
					text = jObject["phoneNumber"]!.ToString();
				}
				if (text3 != "" && text != "")
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_35(string D337EF92, int B930369E)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				if (text3 == "")
				{
					requestHttp.requestHTTP_0.SetDefaultHeaders(new string[1] { "Authorization: Basic " + D337EF92 });
					text2 = requestHttp.method_0("https://zimablue.click/zimablue/getmsisdn/Facebook");
					JObject jObject = JObject.Parse(text2);
					text3 = jObject["request_id"]!.ToString();
					text = jObject["msisdn"]!.ToString();
				}
				if (text3 != "")
				{
					if (text != "")
					{
						break;
					}
					requestHttp.requestHTTP_0.SetDefaultHeaders(new string[1] { "Authorization: Basic " + D337EF92 });
					text2 = requestHttp.method_0("https://zimablue.click/zimablue/getcontent/" + text3);
					JObject jObject2 = JObject.Parse(text2);
					text = jObject2["msisdn"]!.ToString();
					if (text != "")
					{
						break;
					}
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < B930369E * 1000);
		return text3 + "|" + text;
	}

	public static string E43CE7A7(string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				requestHttp.requestHTTP_0.SetDefaultHeaders(new string[1] { "Authorization: OTP " + string_0 });
				text2 = requestHttp.EF076293("https://trumotpvn.com/api/v1/order", "service=9");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["id"]!.ToString();
				text = jObject["data"]!["phoneNumber"]!.ToString();
				if (text3 != "" && text != "")
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_36(string E60E8193, int int_0)
	{
		string text = "";
		RequestXNet requestXNet = new RequestXNet();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		string text4 = Commom.smethod_50("ewkKCSJhcGlfa2V5Ijoie2FwaV9rZXl9IiwKCSJhcHBJZCI6InthcHBJZH0iCn0=");
		text4 = text4.Replace("{api_key}", E60E8193);
		text4 = text4.Replace("{appId}", "9");
		do
		{
			try
			{
				text2 = requestXNet.method_1("https://api.goodotp.xyz/api/dangkysim", text4, "application/json");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["Result"]!["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["Result"]!["number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_37(string string_0, int int_0, string D783DC82 = "facebook")
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				if (text2 == "")
				{
					text = requestHttp.method_0("https://api.winmail.shop/phone/rent?clientId=" + string_0 + "&serviceId=" + D783DC82);
					JObject jObject = JObject.Parse(text);
					text3 = jObject["email"]!["phone"]!.ToString();
					text2 = jObject["email"]!["phoneId"]!.ToString();
				}
				if (text2 != "")
				{
					if (text3 != "")
					{
						break;
					}
					text = requestHttp.method_0("https://api.winmail.shop/phone/code?clientId=" + string_0 + "&phoneId=" + text2);
					JObject jObject2 = JObject.Parse(text);
					text3 = jObject2["result"]!["phone"]!.ToString();
					if (text3 != "")
					{
						break;
					}
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text2 + "|" + text3;
	}

	public static string smethod_38(string BA3D4596, int DF8398B6)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				if (text2 == "")
				{
					text = requestHttp.method_0("https://api.tempsms.co/create?api_key=" + BA3D4596 + "&service_id=13");
					JObject jObject = JObject.Parse(text);
					text2 = jObject["request_id"]!.ToString();
				}
				if (text2 != "")
				{
					if (text3 != "")
					{
						break;
					}
					text = requestHttp.method_0("https://api.tempsms.co/detail?api_key=" + BA3D4596 + "&request_id=" + text2);
					JObject jObject2 = JObject.Parse(text);
					text3 = jObject2["phone"]!.ToString();
					if (text3 != "")
					{
						break;
					}
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < DF8398B6 * 1000);
		return text2 + "|" + text3;
	}

	public static string E7AFAD94(string string_0, string AB31C020, int B695933F = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("https://api.winmail.shop/phone/code?clientId=" + string_0 + "&phoneId=" + AB31C020);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["result"]!["code"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(5000);
		}
		while (Environment.TickCount - tickCount <= B695933F * 1000);
		return text;
	}

	public static string smethod_39(string A61D31AD, string string_0, int E7BF13AE = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("https://api.tempsms.co/detail?api_key=" + A61D31AD + "&request_id=" + string_0);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["otp"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(5000);
		}
		while (Environment.TickCount - tickCount <= E7BF13AE * 1000);
		return text;
	}

	public static string BD124B0F(string string_0, string FDA2E328, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			string text2 = "";
			try
			{
				text2 = requestHttp.method_0("https://funotp.com/api?action=code&id=" + FDA2E328 + "&apikey=" + string_0);
				JObject jObject = JObject.Parse(text2);
				if (!(jObject["ResponseCode"]!.ToString() == "2"))
				{
					text = Regex.Match(jObject["Result"]!["otp"]!.ToString(), "\\d+").Value;
					if (!(text != ""))
					{
						goto IL_00a6;
					}
				}
			}
			catch
			{
				goto IL_00a6;
			}
			break;
			IL_00a6:
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	public static string A30C132F(string D5342A32, string string_0, int C733CC9D = 120)
	{
		string text = "";
		new RequestXNet();
		int tickCount = Environment.TickCount;
		string text2 = Commom.smethod_50("ewkKCSJhcGlfa2V5Ijoie2FwaV9rZXl9IiwKCSJpZCI6IntpZH0iCn0=");
		text2 = text2.Replace("{api_key}", D5342A32);
		text2 = text2.Replace("{id}", string_0);
		do
		{
			try
			{
				string json = new RequestXNet().method_1("https://api.goodotp.xyz/api/layotpByID", text2, "application/json");
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["Result"]![0]!["message"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= C733CC9D * 1000);
		return text;
	}

	public static string CBB77633(string BCB01827, string BEB70000, int int_0 = 120)
	{
		string text = "";
		RequestXNet requestXNet = new RequestXNet();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestXNet.E58EB99F("https://administrator.codetext247.com/api/get-message?token=" + BCB01827 + "&phone=" + BEB70000);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["message"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	public static string smethod_40(string string_0, string F2A57BB1, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.EF076293("https://codeotp.site/api/getotp", "token=" + string_0 + "&id=" + F2A57BB1);
				JObject jObject = JObject.Parse(json);
				text = jObject["msg"]!["otp"]!.ToString();
				if (text == "")
				{
					text = Regex.Match(jObject["msg"]!["msg"]!.ToString(), "\\d+").Value;
				}
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	public static string smethod_41(string string_0, string string_1, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string text2 = requestHttp.method_0("https://sosotps.com/get_code.php?apikey=" + string_0 + "&dichvu=10&sdt=" + string_1);
				text2 = text2.Replace("NO|||", "");
				if (text2.Split('|')[0] == "OK")
				{
					text = text2.Split('|')[2];
				}
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	public static string F7A88429(string string_0, string string_1, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("http://171.244.56.172:9152/get_otp?id_order=" + string_1 + "&apikey=" + string_0);
				text = Regex.Match(JObject.Parse(json)["data"]![0]!["content"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	public static string smethod_42(string ABAC531B, int A31C129E, string D69E59B0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.EF076293("https://tempcode.co/api/orders.php", "api_key=" + ABAC531B + "&act=buy_number&service_id=" + D69E59B0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["order_id"]!.ToString();
				if (text3 != "")
				{
					text = (jObject["data"]!["phonenumber"]!.ToString().Contains("+") ? jObject["data"]!["phonenumber"]!.ToString().Remove(0, 2) : jObject["data"]!["phonenumber"]!.ToString().Remove(0, 1));
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < A31C129E * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_43(string string_0, string string_1, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.EF076293("https://tempcode.co/api/orders.php", "api_key=" + string_0 + "&act=read_message&order_id=" + string_1);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = Regex.Match(jObject["data"]!["otp"]!.ToString(), "\\d+").Value;
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
				Thread.Sleep(3000);
			}
			catch
			{
			}
		}
		return text;
	}

	public static string smethod_44(string string_0, int int_0, int FCAE850E = 7)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://ironsim.com/api/phone/new-session?token=" + string_0 + "&service=" + FCAE850E);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["session"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["phone_number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(1000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_45(string string_0, int F795AEB6)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://api.random-otp.io.vn:8450/sms/getNumber?apiKey=" + string_0 + "&country=6&service=fb");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["phoneNumber"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(1000);
		}
		while (Environment.TickCount - tickCount < F795AEB6 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_46(string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://muasms.com/api/create-request.php?token=" + string_0 + "&id=3");
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["trans_id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["sdt"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(1000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string DC88CD9F(string string_0, int BE8D5723)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://apisim.codesim.net/sim/get_sim?service_id=1&api_key=" + string_0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["otpId"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["phone"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(1000);
		}
		while (Environment.TickCount - tickCount < BE8D5723 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_47(string string_0, int int_0)
	{
		string text = "";
		GClass0 gClass = new GClass0();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = gClass.B2157B0A("https://globalotp.org/api.php?action=createNew&country=39&service=fb&apikey=" + string_0);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["data"]!["id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["data"]!["phone_number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(1000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_48(string string_0, string string_1, int int_0 = 90)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("https://ironsim.com/api/session/" + string_1 + "/get-otp?token=" + string_0);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = jObject["data"]!["messages"]![0]!["otp"]!.ToString();
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
				Thread.Sleep(3000);
			}
			catch
			{
			}
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	public static string smethod_49(string string_0, string CB8E2620, int FE1FF61F = 90)
	{
		string text = "";
		GClass0 gClass = new GClass0();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = gClass.B2157B0A("https://globalotp.org/api.php?action=getSMS&apikey=" + string_0 + "&id=" + CB8E2620);
				JObject jObject = JObject.Parse(json);
				try
				{
					text = jObject["data"]!["otp"]!.ToString();
					if (text != "")
					{
						return text;
					}
				}
				catch
				{
				}
				Thread.Sleep(3000);
			}
			catch
			{
			}
		}
		while (Environment.TickCount - tickCount <= FE1FF61F * 1000);
		return text;
	}

	public static string smethod_50(string string_0, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("https://otpmmo.xyz/textnow/api.php?apikey=" + string_0 + "&type=getphone&qty=1");
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return "";
	}

	public static string ECA4341B(string A5B06F3E, string string_0, int FB390192 = 60)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		for (int i = 0; i < FB390192; i++)
		{
			try
			{
				text = requestHttp.method_0("https://otpmmo.xyz/textnow/api.php?apikey=" + A5B06F3E + "&type=getotp&sdt=" + string_0);
				if (text != "")
				{
					text = text.Remove(0, 1);
					text = text.Remove(text.Length - 1, 1);
					JObject jObject = JObject.Parse(text);
					text2 = jObject["otp"]!.ToString();
					if (text2 != "")
					{
						return Regex.Match(text2, "\\d+").Value;
					}
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return "";
	}

	public static string C61AC63E(string E1148436, int D03ADBAD)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("http://primeotp.me/api.php?apikey=" + E1148436 + "&action=create-request&serviceId=1&count=1");
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					return jObject["results"]!["data"]![0]!["requestId"]!.ToString() + "|" + jObject["results"]!["data"]![0]!["sdt"]!.ToString();
				}
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}
		while (Environment.TickCount - tickCount < D03ADBAD * 1000);
		return "";
	}

	public static string smethod_51(string string_0, string string_1, int BE8DD118 = 60)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		for (int i = 0; i < BE8DD118; i++)
		{
			try
			{
				text = requestHttp.method_0("http://primeotp.me/api.php?apikey=" + string_0 + "&action=data-request&requestId=" + string_1);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					text2 = jObject["data"]![0]!["otp"]!.ToString();
					if (text2 != "")
					{
						return Regex.Match(text2, "\\d+").Value;
					}
				}
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}
		return "";
	}

	public static string smethod_52(string string_0, int int_0, string DDA88196 = "servertextnow.xyz")
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("http://" + DDA88196 + "/api/get-phone/?access_token=" + string_0);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					return jObject["phone"]!.ToString();
				}
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return "";
	}

	public static string smethod_53(string string_0, string string_1, string A3B7FA91 = "servertextnow.xyz", int B6B5C10B = 60)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("http://" + A3B7FA91 + "/api/get-otp/?access_token=" + string_0 + "&phone=" + string_1);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					text2 = jObject["otp"]!.ToString();
					if (text2 != "")
					{
						return Regex.Match(text2, "\\d+").Value;
					}
				}
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}
		while (Environment.TickCount - tickCount < B6B5C10B * 1000);
		return "";
	}

	public static string smethod_54(string string_0, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text = requestHttp.method_0("http://otpfb.com/api.php?apikey=" + string_0 + "&action=create-request&serviceId=1&count=1");
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					return jObject["results"]!["data"]![0]!["requestId"]!.ToString() + "|" + jObject["results"]!["data"]![0]!["sdt"]!.ToString();
				}
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return "";
	}

	public static string C7015C87(string string_0, string string_1, int DFAC5EA8 = 60)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		string text2 = "";
		for (int i = 0; i < DFAC5EA8; i++)
		{
			try
			{
				text = requestHttp.method_0("http://otpfb.com/api.php?apikey=" + string_0 + "&action=data-request&requestId=" + string_1);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					text2 = jObject["data"]![0]!["otp"]!.ToString();
					if (text2 != "")
					{
						return Regex.Match(text2, "\\d+").Value;
					}
				}
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}
		return "";
	}

	public static string smethod_55(string C401352A, string C622209C, int EB3419BB = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= EB3419BB * 1000)
		{
			try
			{
				string json = requestHttp.method_0("http://otpsim.com/api/sessions/" + C622209C + "?token=" + C401352A);
				JObject jObject = JObject.Parse(json);
				if (Convert.ToBoolean(jObject["success"]!.ToString()))
				{
					try
					{
						text = JObject.Parse(json)["data"]!["messages"]![0]!["otp"]!.ToString();
						if (text != "")
						{
							return text;
						}
					}
					catch
					{
					}
				}
				Thread.Sleep(3000);
			}
			catch
			{
			}
		}
		return text;
	}

	public static string D22BA2B3(string string_0, int int_0, int int_1 = 1001)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://chaycodeso3.com/api?act=number&apik=" + string_0 + "&appId=" + int_1);
				JObject jObject = JObject.Parse(text2);
				text3 = jObject["Result"]!["Id"]!.ToString();
				if (text3 != "")
				{
					text = jObject["Result"]!["Number"]!.ToString();
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(1000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string CA350304(string E782279C, string string_0, int int_0 = 120)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		while (Environment.TickCount - tickCount <= int_0 * 1000)
		{
			try
			{
				string json = requestHttp.method_0("https://chaycodeso3.com/api?act=code&apik=" + E782279C + "&id=" + string_0);
				JObject jObject = JObject.Parse(json);
				if (jObject["ResponseCode"]!.ToString() == "0")
				{
					try
					{
						text = jObject["Result"]!["Code"]!.ToString();
						if (text != "")
						{
							return text;
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		return text;
	}

	public static string FD999E33(string string_0, int int_0, int FE9B4038 = 7)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		string text3 = "";
		int tickCount = Environment.TickCount;
		do
		{
			text2 = requestHttp.method_0("http://otpsim.com/api/phones/request?token=" + string_0 + "&service=" + FE9B4038);
			try
			{
				JObject jObject = JObject.Parse(text2);
				if (!Convert.ToBoolean(jObject["success"]!.ToString()))
				{
					goto IL_00cc;
				}
				text = JObject.Parse(text2)["data"]!["phone_number"]!.ToString();
				text3 = JObject.Parse(text2)["data"]!["session"]!.ToString();
				if (!(text != "") || !(text3 != ""))
				{
					goto IL_00cc;
				}
				goto end_IL_004d;
				IL_00cc:
				Thread.Sleep(5000);
				continue;
				end_IL_004d:;
			}
			catch
			{
				continue;
			}
			break;
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text3 + "|" + text;
	}

	public static string smethod_56(int DF054C20, string D1996B07, string string_0, string string_1, int int_0)
	{
		string result = "";
		switch (DF054C20)
		{
		case 1:
			result = smethod_55(D1996B07, string_0, int_0);
			break;
		case 2:
			result = CA350304(D1996B07, string_0, int_0);
			break;
		case 3:
			result = ECA4341B(D1996B07, string_1, int_0);
			break;
		case 4:
			result = smethod_51(D1996B07, string_0, int_0);
			break;
		case 5:
			result = smethod_53(D1996B07, string_1, "servertextnow.xyz", int_0);
			break;
		case 6:
			result = C7015C87(D1996B07, string_0, int_0);
			break;
		case 8:
			result = smethod_14(D1996B07, string_0, int_0);
			break;
		case 10:
			result = smethod_43(D1996B07, string_0, int_0);
			break;
		case 14:
			result = CBB77633(D1996B07, string_1, int_0);
			break;
		case 15:
			result = A30C132F(D1996B07, string_0, int_0);
			break;
		case 16:
			result = smethod_57(D1996B07, string_0, int_0);
			break;
		case 17:
			result = AC201C16(D1996B07, string_0, int_0);
			break;
		case 18:
			result = smethod_41(D1996B07, string_1, int_0);
			break;
		case 19:
			result = smethod_58(D1996B07, string_0, int_0);
			break;
		case 21:
			result = F0B736B1(D1996B07, string_0, int_0);
			break;
		case 23:
			result = smethod_40(D1996B07, string_0, int_0);
			break;
		case 25:
			result = smethod_64(D1996B07, string_0, int_0);
			break;
		case 26:
			result = smethod_65(D1996B07, string_0, int_0);
			break;
		case 27:
			result = smethod_19(D1996B07, string_0, int_0);
			break;
		case 28:
			result = F7A88429(D1996B07, string_0, int_0);
			break;
		case 29:
			result = smethod_20(D1996B07, string_0, int_0);
			break;
		case 31:
			result = smethod_62(D1996B07, string_0, int_0);
			break;
		case 32:
			result = smethod_63(D1996B07, string_0, int_0);
			break;
		case 33:
			result = smethod_39(D1996B07, string_0, int_0);
			break;
		case 34:
			result = smethod_21(D1996B07, string_0, int_0);
			break;
		case 35:
			result = smethod_22(D1996B07, string_0, int_0);
			break;
		case 36:
			result = smethod_23(D1996B07, string_0, int_0);
			break;
		case 39:
			result = smethod_27(D1996B07, string_0, int_0);
			break;
		case 40:
			result = smethod_28(D1996B07, string_1, int_0);
			break;
		case 42:
			result = CBB95A0F(D1996B07, string_0, int_0);
			break;
		case 38:
		case 43:
			result = smethod_29(D1996B07, string_0, int_0);
			break;
		case 12:
		case 45:
			result = E7AFAD94(D1996B07, string_0, int_0);
			break;
		case 46:
			result = smethod_24(D1996B07, string_0, int_0);
			break;
		case 47:
			result = smethod_25(D1996B07, string_0, int_0);
			break;
		case 9:
		case 48:
			result = smethod_30(D1996B07, string_0, int_0);
			break;
		case 49:
			result = smethod_26(D1996B07, string_0, int_0);
			break;
		case 50:
			result = D5919C3F(D1996B07, string_1, int_0);
			break;
		case 13:
		case 52:
			result = BD124B0F(D1996B07, string_0, int_0);
			break;
		case 53:
			result = smethod_15(D1996B07, string_0, int_0);
			break;
		case 30:
		case 41:
		case 54:
			result = smethod_48(D1996B07, string_0, int_0);
			break;
		case 56:
			result = smethod_16(D1996B07, string_0, int_0);
			break;
		case 59:
			result = smethod_17(D1996B07, string_0, int_0);
			break;
		case 61:
			result = smethod_18(D1996B07, string_0, int_0);
			break;
		case 62:
			result = smethod_49(D1996B07, string_0, int_0);
			break;
		}
		return result;
	}

	private static string AC201C16(string string_0, string string_1, int int_0)
	{
		RequestHttp requestHttp = new RequestHttp();
		string text = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("https://2ndline.pro/apiv1/ordercheck?apikey=" + string_0 + "&id=" + string_1);
				JObject jObject = JObject.Parse(json);
				text = Regex.Match(jObject["data"]!["message"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch (Exception)
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text;
	}

	private static string smethod_57(string string_0, string string_1, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("https://otp282.com/api/getOTPCode/" + string_0 + "/request_id/" + string_1);
				JObject jObject = JObject.Parse(json);
				text = jObject["otpcode"]!.ToString();
				if (text == "")
				{
					text = Regex.Match(jObject["message"]!.ToString(), "\\d+").Value;
				}
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	private static string smethod_58(string string_0, string string_1, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				string json = requestHttp.method_0("http://hcotp.com/api/v2/getcode?token=" + string_0 + "&requestId=" + string_1);
				JObject jObject = JObject.Parse(json);
				text = jObject["code"]!.ToString();
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount <= int_0 * 1000);
		return text;
	}

	internal static void smethod_59(int int_0, string A3339622, string string_0, string string_1)
	{
		switch (int_0)
		{
		case 15:
			FAA9FD18(A3339622, string_0);
			break;
		case 12:
			FE3F5221(A3339622, string_1);
			break;
		case 36:
			smethod_60(A3339622, string_1);
			break;
		case 33:
			B7BE1C00(A3339622, string_1);
			break;
		case 30:
			smethod_61(A3339622, string_1);
			break;
		}
	}

	public static bool smethod_60(string B993E385, string A9351A21, int int_0 = 120)
	{
		RequestHttp requestHttp = new RequestHttp();
		try
		{
			string text = requestHttp.method_0("https://api.usotp.xyz/cancel-request?apikey=" + B993E385 + "&id=" + A9351A21);
			return text.Trim() == "{}";
		}
		catch
		{
		}
		return false;
	}

	public static bool FE3F5221(string string_0, string A39E340A, int int_0 = 120)
	{
		RequestHttp requestHttp = new RequestHttp();
		try
		{
			string json = requestHttp.method_0("https://api.winmail.shop/phone/cancel?clientId=" + string_0 + "&phoneId=" + A39E340A);
			JObject jObject = JObject.Parse(json);
			return jObject["status"]!.ToString() == "canceled";
		}
		catch
		{
		}
		return false;
	}

	public static bool B7BE1C00(string B2B81092, string string_0, int F7926A82 = 120)
	{
		RequestHttp requestHttp = new RequestHttp();
		try
		{
			string json = requestHttp.method_0("https://api.tempsms.co/cancel?api_key=" + B2B81092 + "&request_id=" + string_0);
			JObject jObject = JObject.Parse(json);
			return jObject["status_code"]!.ToString() == "0";
		}
		catch
		{
		}
		return false;
	}

	public static string FAA9FD18(string string_0, string string_1)
	{
		string result = "";
		new RequestXNet();
		string text = Commom.smethod_50("ewkKCSJhcGlfa2V5Ijoie2FwaV9rZXl9IiwKCSJhcHBfaWQiOiJ7YXBwX2lkfSIsCiAgICAgICAgIm51bWJlciI6IntudW1iZXJ9Igp9");
		text = text.Replace("{api_key}", string_0);
		text = text.Replace("{app_id}", "9");
		text = text.Replace("{number}", string_1);
		try
		{
			string json = new RequestXNet().method_1("https://api.goodotp.xyz/api/huydangky", text, "application/json");
			JObject.Parse(json);
		}
		catch
		{
		}
		return result;
	}

	public static string smethod_61(string string_0, string string_1)
	{
		string result = "";
		RequestHttp requestHttp = new RequestHttp();
		try
		{
			string json = requestHttp.method_0("https://ironsim.com/api/session/cancel?token=" + string_0 + "&session=" + string_1);
			JObject jObject = JObject.Parse(json);
			result = jObject["success"]!.ToString();
		}
		catch
		{
		}
		return result;
	}

	public static string smethod_62(string string_0, string string_1, int FD02A389)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://sell282.xyz/api/sim/code?api_key=" + string_0 + "&code_order=" + string_1);
				JObject jObject = JObject.Parse(text2);
				text = Regex.Match(jObject["data"]!["code"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < FD02A389 * 1000);
		return text;
	}

	public static string smethod_63(string string_0, string DCB9830D, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://api.thuesim.app/api/order/" + DCB9830D + "/" + string_0);
				JObject jObject = JObject.Parse(text2);
				text = Regex.Match(jObject["content"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text;
	}

	public static string smethod_64(string E83FAD0D, string string_0, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				text2 = requestHttp.method_0("https://numberotp.co/public/api/gsm/get-order/" + string_0 + "/" + E83FAD0D);
				JObject jObject = JObject.Parse(text2);
				text = Regex.Match(jObject["content"]!.ToString(), "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text;
	}

	public static string F0B736B1(string string_0, string DC29F725, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				requestHttp.requestHTTP_0.SetDefaultHeaders(new string[1] { "Authorization: Basic " + string_0 });
				text2 = requestHttp.method_0("https://zimablue.click/zimablue/getcontent/" + DC29F725);
				JObject jObject = JObject.Parse(text2);
				text = jObject["otp"]!.ToString();
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text;
	}

	public static string smethod_65(string string_0, string string_1, int int_0)
	{
		string text = "";
		RequestHttp requestHttp = new RequestHttp();
		string text2 = "";
		int tickCount = Environment.TickCount;
		do
		{
			try
			{
				requestHttp.requestHTTP_0.SetDefaultHeaders(new string[1] { "Authorization: OTP " + string_0 });
				text2 = requestHttp.method_0("https://trumotpvn.com/api/v1/order/" + string_1);
				JObject jObject = JObject.Parse(text2);
				text = jObject["data"]!["content"]!.ToString();
				text = Regex.Match(text, "\\d+").Value;
				if (text != "")
				{
					return text;
				}
			}
			catch
			{
			}
			Thread.Sleep(3000);
		}
		while (Environment.TickCount - tickCount < int_0 * 1000);
		return text;
	}
}
