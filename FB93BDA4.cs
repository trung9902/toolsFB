using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

internal class FB93BDA4
{
	internal static string smethod_0(int BE00B6AD, string string_0, string CB073202, string BD85BFB1 = "", int D5ACE784 = 60)
	{
		RequestXNet requestXNet = new RequestXNet();
		string_0 = string_0.Substring(0, string_0.LastIndexOf("=") + 1) + CB073202;
		int tickCount = Environment.TickCount;
		do
		{
			string text = requestXNet.E58EB99F(string_0);
			try
			{
				text = "{\"data\":" + text + "}";
				JObject jObject = JObject.Parse(text);
				int num = jObject["data"].Count() - 1;
				while (num >= 0)
				{
					jObject["data"]![num]!["created_at"]!.ToString();
					string string_ = jObject["data"]![num]!["body"]!.ToString();
					string text2 = smethod_1(string_, BE00B6AD, BD85BFB1);
					if (!(text2 != ""))
					{
						num--;
						continue;
					}
					return text2;
				}
			}
			catch
			{
			}
			Commom.smethod_52(3.0);
		}
		while (Environment.TickCount - tickCount < D5ACE784 * 1000);
		return "";
	}

	public static string smethod_1(string string_0, int int_0, string A5013D0E)
	{
		return "";
	}

	public static bool CheckDonglaomail(string string_0)
	{
		return false;
	}

	public static string smethod_4(int int_0, string BAA28712, string BD88D585, int C5B75237 = 60, string A9AC8D2A = "", string string_0 = "")
	{
		return "";
	}

	public static bool CheckUnlimitMail(string string_0)
	{
		return false;
	}

	public static string C689F112(int int_0, string AD15C933, string CD2AC4B2, int E013FEA0 = 60, string string_0 = "", string EF2C7383 = "")
	{
		return "";
	}

	public static string EF2C4EBE(string string_0, string string_1)
	{
		return "";
	}

    public static bool CheckHotmail9(string mail)
    {
        return MaxCareLibPro.Hotmail9.CheckHotmail9(mail);
    }

    public static string CreateMailtm(string string_0, string string_1)
    {
        return "";
    }

	public static string smethod_10(int int_0, string string_0, int D005623E, string string_1, string C5809F33)
	{
		return "";
	}

	public static string A18013B7(string string_0)
	{
		string text = Commom.EB835717((from C09D4AB4 in SetupFolder.smethod_4()
			orderby Guid.NewGuid()
			select C09D4AB4).First() + (from string_0q in SetupFolder.smethod_5()
			orderby Guid.NewGuid()
			select string_0q).First()).Replace(" ", "").ToLower() + Commom.B820DC86(6, "0");
		return text + "@" + string_0;
	}

	public static string GetOtpFromMail(int type, string mail, string passmail, string refresh_token, string cookieMail, int timeOut, string uid, string oldOtp)
	{
		string text = "";
        if (MaxCareLibPro.Common.Check1secMail(mail))
        {
            text = MaxCareLibPro.Common.GetOtp1secMail(type, mail, uid);
        }
        else if (CheckDonglaomail(mail))
        {
            text = smethod_4(type, mail, passmail, timeOut, uid, oldOtp);
        }
        else if (CheckUnlimitMail(mail))
        {
            text = C689F112(type, mail, passmail, timeOut, uid, oldOtp);
        }
        else if (MaxCareLibPro.Hotmail9.CheckHotmail9(mail))
        {
            text = MaxCareLibPro.Hotmail9.GetOtpMailhotmail9(type, mail, passmail, uid);
        }
        else if (Commom.F839D53E(mail, C5034B95.smethod_0("configGeneral").method_1("txtGeneratorDomain")) != "")
        {
            text = smethod_10(type, mail, timeOut, uid, oldOtp);
        }
        else
        {
            if (passmail == "" && refresh_token == "")
            {
                return "empty_pass_email";
            }
            if (refresh_token != "")
            {
                text = D831098B.D8869319(type, mail, refresh_token, timeOut, uid, oldOtp);
                if (text == "" || text == "fail")
                {
                    text = MaxCareLibPro.Common.getOtpHotmail(type, mail, refresh_token, uid);
                }
            }
            if (text == "" || text == "fail")
            {
                text = D831098B.FD246327(type, mail, passmail, cookieMail, timeOut, uid, oldOtp);
                if (text == "fail" && refresh_token != "")
                {
                    text = "";
                }
            }
        }
        if (text == "")
		{
			text = oldOtp;
		}
		return text;
	}
}
