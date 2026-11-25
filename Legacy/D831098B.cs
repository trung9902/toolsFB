using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;

public class D831098B
{
	public static bool FFA1D7B5(string ED0C1C85, string FE85769A, string string_0)
	{
		if (string_0 != "")
		{
			string text = MaxCareLibPro.Common.getAccessTokenHotmail(string_0, "", 0);
			if (text != "")
			{
				try
				{
					using ImapClient imapClient = new ImapClient();
					imapClient.Connect("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
					imapClient.Authenticate(new SaslMechanismOAuth2(ED0C1C85, text));
					imapClient.Inbox.Open(FolderAccess.ReadWrite);
					_ = imapClient.Inbox.Count;
					imapClient.Disconnect(quit: true);
					return true;
				}
				catch (Exception)
				{
				}
			}
		}
		try
		{
			using ImapClient imapClient = new ImapClient();
			imapClient.Connect("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
			imapClient.Authenticate(ED0C1C85, FE85769A);
			imapClient.Disconnect(quit: true);
			return true;
		}
		catch { return false; }
	}

	public static string FD246327(int int_0, string string_0, string string_1, string string_2, int E729BF0D, string string_3, string BC8DC738)
	{
		string text = "";
		try
		{
			if (int_0 == 5)
			{
				int_0 = 4;
			}
			int tickCount = Environment.TickCount;
			do
			{
				text = B2BF5517(int_0, string_0, string_1, string_3, BC8DC738);
				if (!text.Contains("error"))
				{
					if (!(text != ""))
					{
						Commom.smethod_52(1.0);
						continue;
					}
					break;
				}
				text = "fail";
				break;
			}
			while (Environment.TickCount - tickCount < E729BF0D * 1000);
		}
		catch
		{
		}
		if (text == "fail")
		{
			for (int i = 0; i < 2; i++)
			{
				if (string_2 == "")
				{
					string_2 = smethod_0(string_0, string_1);
					if (string_2 == "")
					{
						break;
					}
					i++;
				}
				text = GetOtpHotmailByCookie(int_0, string_0, string_2, E729BF0D, string_3, BC8DC738);
				if (text != "fail")
				{
					break;
				}
				string_2 = "";
			}
		}
		return text;
	}

    public static string GetOtpHotmailByCookie(int type, string string_0, string cookie, int timeOut = 60, string uidFb = "", string string_2 = "")
    {
        return MaxCareLibPro.Common.GetOtpHotmailByCookie(type, cookie, uidFb, "", 0);
    }

    public static string smethod_0(string string_0, string string_1, string string_2 = "", int int_0 = 0)
	{
		string text = "";
		int num = 3;
		do
		{
			num--;
			if (num >= 0)
			{
				RequestXNet requestXNet = new RequestXNet("", ModernUserAgentHub.GetRandomDesktopChrome(), string_2, int_0);
				try
				{
					string input = requestXNet.E58EB99F("https://outlook.live.com/owa/?nlp=1");
					string value = Regex.Match(input, "name=\"PPFT\" id=\"i0327\" value=\"(.*?)\"").Groups[1].Value;
					string value2 = Regex.Match(input, "urlPostMsa:'(.*?)'").Groups[1].Value;
					string string_3 = value2;
					List<KeyValuePair<string, string>> list_ = new List<KeyValuePair<string, string>>
					{
						new KeyValuePair<string, string>("ps", "2"),
						new KeyValuePair<string, string>("psRNGCDefaultType", ""),
						new KeyValuePair<string, string>("psRNGCEntropy", ""),
						new KeyValuePair<string, string>("psRNGCSLK", ""),
						new KeyValuePair<string, string>("canary", ""),
						new KeyValuePair<string, string>("ctx", ""),
						new KeyValuePair<string, string>("hpgrequestid", ""),
						new KeyValuePair<string, string>("PPFT", value),
						new KeyValuePair<string, string>("PPSX", "Passp"),
						new KeyValuePair<string, string>("NewUser", "1"),
						new KeyValuePair<string, string>("FoundMSAs", ""),
						new KeyValuePair<string, string>("fspost", "0"),
						new KeyValuePair<string, string>("i21", "0"),
						new KeyValuePair<string, string>("CookieDisclosure", "0"),
						new KeyValuePair<string, string>("IsFidoSupported", "1"),
						new KeyValuePair<string, string>("isSignupPost", "0"),
						new KeyValuePair<string, string>("isRecoveryAttemptPost", "0"),
						new KeyValuePair<string, string>("i13", "0"),
						new KeyValuePair<string, string>("login", string_0),
						new KeyValuePair<string, string>("loginfmt", string_0),
						new KeyValuePair<string, string>("type", "11"),
						new KeyValuePair<string, string>("LoginOptions", "3"),
						new KeyValuePair<string, string>("lrt", ""),
						new KeyValuePair<string, string>("lrtPartition", ""),
						new KeyValuePair<string, string>("hisRegion", ""),
						new KeyValuePair<string, string>("hisScaleUnit", ""),
						new KeyValuePair<string, string>("passwd", string_1)
					};
					string d = smethod_1(list_);
					input = requestXNet.method_1(string_3, d);
					value = Regex.Match(input, "sFT:'(.*?)'").Groups[1].Value;
					string value3 = Regex.Match(input, "urlPost:'(.*?route.*?)'").Groups[1].Value;
					value2 = value3;
					string string_4 = value2;
					List<KeyValuePair<string, string>> list_2 = new List<KeyValuePair<string, string>>
					{
						new KeyValuePair<string, string>("LoginOptions", "1"),
						new KeyValuePair<string, string>("type", "28"),
						new KeyValuePair<string, string>("ctx", ""),
						new KeyValuePair<string, string>("hpgrequestid", ""),
						new KeyValuePair<string, string>("PPFT", value),
						new KeyValuePair<string, string>("canary", "")
					};
					string d2 = smethod_1(list_2);
					input = requestXNet.method_1(string_4, d2);
					text = requestXNet.method_4();
					string value4 = Regex.Match(text, "MSPCID=(.*?);").Groups[1].Value;
					string value5 = Regex.Match(input, "id=\"NAP\" value=\"(.*?)\"").Groups[1].Value;
					string value6 = Regex.Match(input, "id=\"ANON\" value=\"(.*?)\"").Groups[1].Value;
					string value7 = Regex.Match(input, "id=\"ANONExp\" value=\"(.*?)\"").Groups[1].Value;
					string value8 = Regex.Match(input, "id=\"t\" value=\"(.*?)\"").Groups[1].Value;
					string value9 = Regex.Match(input, "id=\"NAPExp\" value=\"(.*?)\"").Groups[1].Value;
					string value10 = Regex.Match(input, "action=\"(.*?)\"").Groups[1].Value;
					string string_5 = value10;
					List<KeyValuePair<string, string>> list_3 = new List<KeyValuePair<string, string>>
					{
						new KeyValuePair<string, string>("NAPExp", value9),
						new KeyValuePair<string, string>("wbids", "0"),
						new KeyValuePair<string, string>("pprid", value4),
						new KeyValuePair<string, string>("wbid", "MSFT"),
						new KeyValuePair<string, string>("NAP", value5),
						new KeyValuePair<string, string>("ANON", value6),
						new KeyValuePair<string, string>("ANONExp", value7),
						new KeyValuePair<string, string>("t", value8)
					};
					string d3 = smethod_1(list_3);
					input = requestXNet.method_1(string_5, d3);
				}
				catch (Exception)
				{
					return "";
				}
				text = requestXNet.method_4();
				continue;
			}
			return "";
		}
		while (!text.Contains("X-OWA-CANARY"));
		return text;
	}

	public static string smethod_1(List<KeyValuePair<string, string>> list_0)
	{
		return string.Join("&", list_0.Select((KeyValuePair<string, string> keyValuePair_0) => WebUtility.UrlEncode(keyValuePair_0.Key) + "=" + WebUtility.UrlEncode(keyValuePair_0.Value)));
	}

	public static string smethod_2(string string_0, string string_1 = "", int int_0 = 0)
	{
		try
		{
			RequestXNet requestXNet = new RequestXNet(string_0, ModernUserAgentHub.GetRandomDesktopChrome(), string_1, int_0);
			try
			{
				string text = "9e5f94bc-e8a4-4e73-b8be-63364c29d753";
				string text2 = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=" + text + "&response_type=code&redirect_uri=https%3A%2F%2Flocalhost%2F&response_mode=query&scope=offline_access https://outlook.office.com/IMAP.AccessAsUser.All https://outlook.office.com/POP.AccessAsUser.All https://outlook.office.com/EWS.AccessAsUser.All https://outlook.office.com/SMTP.Send&state=PvCYEqIiGX";
				string text3 = requestXNet.E58EB99F(text2);
				if (!text3.Contains("urlGitHubFed"))
				{
					text3 = requestXNet.E58EB99F(text2 + "&sso_reload=true");
				}
				text2 = Regex.Unescape(Regex.Match(text3, "\"urlGitHubFed\":\"(.*?)\"").Groups[1].Value).Replace("&jshs=0&idp_hint=github.com", "&jshs=-1&jsh=&jshp=");
				if (text2 == "")
				{
					return "";
				}
				string text4 = "";
				string text5 = "";
				List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
				try
				{
					text3 = requestXNet.E58EB99F(text2);
					if (text3.Contains("form name=\"fmHF\""))
					{
						text2 = Regex.Match(text3, "action=\"(.*?)\"").Groups[1].Value;
						list = new List<KeyValuePair<string, string>>
						{
							new KeyValuePair<string, string>("rd", Regex.Match(text3, "name=\"rd\" id=\"rd\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("avp", Regex.Match(text3, "name=\"avp\" id=\"avp\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("pprid", Regex.Match(text3, "name=\"pprid\" id=\"pprid\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("ipt", Regex.Match(text3, "name=\"ipt\" id=\"ipt\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("uaid", Regex.Match(text3, "name=\"uaid\" id=\"uaid\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("client_id", Regex.Match(text3, "name=\"client_id\" id=\"client_id\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("scope", Regex.Match(text3, "name=\"scope\" id=\"scope\" value=\"(.*?)\"").Groups[1].Value)
						};
						text5 = smethod_1(list);
						text3 = requestXNet.method_1(text2, text5);
						list = new List<KeyValuePair<string, string>>
						{
							new KeyValuePair<string, string>("canary", Regex.Match(text3, "name=\"canary\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("client_id", Regex.Match(text3, "name=\"client_id\" value=\"(.*?)\"").Groups[1].Value),
							new KeyValuePair<string, string>("scope", Regex.Match(text3, "name=\"scope\" value=\"(.*?)\"").Groups[1].Value.Replace("&#32;", " ")),
							new KeyValuePair<string, string>("cscope", ""),
							new KeyValuePair<string, string>("ucaction", "Yes")
						};
						text5 = smethod_1(list);
						text3 = requestXNet.method_1(text2, text5);
					}
					if (requestXNet.method_5().Contains("localhost/?code="))
					{
						text4 = Commom.F914B80B(requestXNet.method_5(), "code=(.*?)&");
					}
					if (text4 == "")
					{
						text3 = requestXNet.E58EB99F(requestXNet.method_5());
					}
				}
				catch (Exception)
				{
					if (requestXNet.method_5().Contains("localhost/?code="))
					{
						text4 = Commom.F914B80B(requestXNet.method_5(), "code=(.*?)&");
					}
				}
				if (text4 == "")
				{
					return "";
				}
				text2 = "https://login.microsoftonline.com/common/oauth2/v2.0/token";
				list = new List<KeyValuePair<string, string>>
				{
					new KeyValuePair<string, string>("client_id", text),
					new KeyValuePair<string, string>("code", text4),
					new KeyValuePair<string, string>("redirect_uri", "https://localhost/"),
					new KeyValuePair<string, string>("grant_type", "authorization_code")
				};
				text5 = smethod_1(list);
				text3 = requestXNet.method_1(text2, text5);
				string value = Regex.Match(text3, "\"refresh_token\":\"(.*?)\"").Groups[1].Value;
				return value + "|" + text;
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
		return "";
	}

	public static string D8869319(int int_0, string string_0, string D2814318, int int_1 = 60, string F0B83C8F = "", string A012C12D = "")
	{
		string text = MaxCareLibPro.Common.getAccessTokenHotmail(D2814318, "", 0);
		if (text == "")
		{
			return "";
		}
		string text2 = "";
		try
		{
			using ImapClient imapClient = new ImapClient();
			imapClient.Connect("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
			imapClient.Authenticate(new SaslMechanismOAuth2(string_0, text));
			int tickCount = Environment.TickCount;
			while (true)
			{
				if (!Base.smethod_5())
				{
					imapClient.Inbox.Open(FolderAccess.ReadWrite);
					int count = imapClient.Inbox.Count;
					IList<IMessageSummary> list = imapClient.Inbox.Fetch(0, count - 1, MessageSummaryItems.Envelope | MessageSummaryItems.Flags);
					for (int num = list.Count - 1; num >= 0; num--)
					{
						IMessageSummary messageSummary = list[num];
						if (messageSummary.Flags.HasValue && messageSummary.Flags.Value.HasFlag(MessageFlags.Seen))
						{
							break;
						}
						imapClient.Inbox.AddFlags(messageSummary.Index, MessageFlags.Seen, silent: true);
						DateTime localDateTime = messageSummary.Envelope.Date.Value.LocalDateTime;
						int days = DateTime.Now.Subtract(localDateTime).Days;
						if (days > 1)
						{
							break;
						}
						string text3 = messageSummary.Envelope.From.ToString();
						List<string> list2 = new List<string> { "security@facebookmail.com", "security@account.meta.com" };
						switch (int_0)
						{
						case 7:
							list2 = new List<string> { "noreply@account.tiktok.com" };
							break;
						case 8:
							list2 = new List<string> { "account-security-noreply@accountprotection.microsoft.com" };
							break;
						case 9:
							list2 = new List<string> { "noreply@telegram.org" };
							break;
						case 10:
							list2 = new List<string> { "noreply@walletbot.net" };
							break;
						}
						bool flag = false;
						foreach (string item in list2)
						{
							if (text3.Contains(item))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						MimeMessage message = imapClient.Inbox.GetMessage(messageSummary.Index);
						string string_ = message.HtmlBody ?? message.TextBody ?? "";
						text2 = FB93BDA4.smethod_1(string_, int_0, F0B83C8F);
						if (text2 == "")
						{
							continue;
						}
						if (!(text2 != A012C12D))
						{
							text2 = "";
							continue;
						}
						goto end_IL_0032;
					}
					if (Environment.TickCount - tickCount <= int_1 * 1000)
					{
						Commom.smethod_52(3.0);
						continue;
					}
				}
				imapClient.Disconnect(quit: true);
				break;
			}
			end_IL_0032:;
		}
		catch (Exception)
		{
			if (text2 == "")
			{
				text2 = "fail";
			}
		}
		return text2;
	}

	public static string B2BF5517(int BEB01F14, string string_0, string F8250B9B, string string_1, string string_2)
	{
		return "";
	}
}
