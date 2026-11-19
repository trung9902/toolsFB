using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

internal class Class59
{
	internal string A092B4BE;

	internal string C1B1B61F;

	internal string C61C311D;

	internal string CAB497BC;

	internal RequestXNet requestXNet_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	public string A99A612B()
	{
		return string_2;
	}

	public static bool ED081E86()
	{
		return C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin") || C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin");
	}

	public static string A29EB388()
	{
		if (C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin"))
		{
			return C5034B95.smethod_0("configGeneral").BDB80B23("txtGpmApiUrl").TrimEnd('/') + "/api/v3/";
		}
		if (C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin"))
		{
			return C5034B95.smethod_0("configGeneral").BDB80B23("txtGemApiUrl").TrimEnd('/') + "/api/";
		}
		return "";
	}

	public static List<string> smethod_0()
	{
		List<string> list = new List<string>();
		try
		{
			string json = new RequestXNet().E58EB99F(A29EB388() + "profiles?per_page=100000");
			foreach (JToken item in (IEnumerable<JToken>)(JObject.Parse(json)["data"]!))
			{
				list.Add(item["name"]!.ToString());
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public static Dictionary<string, string> smethod_1()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		try
		{
			C5034B95.smethod_0("configGeneral").BDB80B23("txtGpmApiUrl").TrimEnd('/');
			string json = new RequestXNet().E58EB99F(A29EB388() + "profiles?per_page=100000");
			foreach (JToken item in (IEnumerable<JToken>)(JObject.Parse(json)["data"]!))
			{
				dictionary.Add(item["name"]!.ToString(), item["id"]!.ToString());
			}
		}
		catch (Exception)
		{
		}
		return dictionary;
	}

	public static Dictionary<string, string> smethod_2()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		try
		{
			string json = new RequestXNet().E58EB99F(A29EB388() + "profiles?per_page=100000");
			string text = "";
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin"))
			{
				text = smethod_5() + "\\";
			}
			foreach (JToken item in (IEnumerable<JToken>)(JObject.Parse(json)["data"]!))
			{
				dictionary.Add(item["name"]!.ToString(), text + item["profile_path"]!.ToString());
			}
		}
		catch (Exception)
		{
		}
		return dictionary;
	}

	public static bool smethod_3(string FD214927)
	{
		smethod_4(FD214927);
		try
		{
			string json = new RequestXNet().E58EB99F(A29EB388() + "profiles/delete/" + FD214927 + "?mode=2");
			return Convert.ToBoolean(JObject.Parse(json)["success"]);
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static bool smethod_4(string string_3)
	{
		try
		{
			string json = new RequestXNet().E58EB99F(A29EB388() + "profiles/close/" + string_3);
			return Convert.ToBoolean(JObject.Parse(json)["success"]);
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static string smethod_5()
	{
		try
		{
			string result = "";
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin"))
			{
				string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\GPMLogin\\setting.dat");
				result = JObject.Parse(json)["ProfileSavePath"]!.ToString();
			}
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin"))
			{
				result = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.gemlogin\\profile\\profiles";
			}
			return result;
		}
		catch (Exception)
		{
		}
		return "";
	}

	public Class59(string string_3)
	{
		requestXNet_0 = new RequestXNet();
		C1B1B61F = string_3;
		CAB497BC = C5034B95.smethod_0("configGeneral").BDB80B23("cbbBrowserVersion", "121.0.6167.140");
		A092B4BE = A29EB388();
		C61C311D = "";
		EA086D28();
	}

	private void EA086D28()
	{
		try
		{
			string json = requestXNet_0.E58EB99F(A092B4BE + "profiles?per_page=100000&search=" + C1B1B61F.Trim('+'));
			foreach (JToken item in (IEnumerable<JToken>)(JObject.Parse(json)["data"]!))
			{
				if (item["name"]!.ToString() == C1B1B61F)
				{
					C61C311D = item["id"]!.ToString();
					break;
				}
			}
			if (string.IsNullOrEmpty(C61C311D))
			{
				method_0();
			}
		}
		catch (Exception)
		{
			string_2 = "Check profile fail";
		}
	}

	private void method_0()
	{
		string text = A092B4BE + "profiles/create";
		try
		{
			string text2 = "";
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin"))
			{
				text2 = "{\r\n    \"profile_name\" : \"{profileName}\",\r\n    \"group_name\": \"All\",\r\n    \"browser_core\": \"chromium\",\r\n    \"browser_name\": \"Chrome\",\r\n    \"browser_version\": \"{browser_version}\",\r\n    \"is_random_browser_version\": false,\r\n    \"raw_proxy\" : \"\",\r\n    \"startup_urls\": \"\",\r\n    \"is_masked_font\": true,\r\n    \"is_noise_canvas\": true,\r\n    \"is_noise_webgl\": true,\r\n    \"is_noise_client_rect\": true,\r\n    \"is_noise_audio_context\": true,\r\n    \"is_random_screen\": true,\r\n    \"is_masked_webgl_data\": true,\r\n    \"is_masked_media_device\": true,\r\n    \"is_random_os\": true,\r\n    \"os\": \"Windows 11\",\r\n    \"webrtc_mode\": 1,\r\n    \"user_agent\": \"\"\r\n}";
			}
			if (C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin"))
			{
				text2 = "{\r\n    \"profile_name\": \"{profileName}\",\r\n    \"group_name\": \"All\",\r\n    \"raw_proxy\": \"\",\r\n    \"startup_urls\": \"\",\r\n    \"is_masked_font\": true,\r\n    \"is_noise_canvas\": true,\r\n    \"is_noise_webgl\": true,\r\n    \"is_noise_client_rect\": true,\r\n    \"is_noise_audio_context\": true,\r\n    \"is_random_screen\": true,\r\n    \"is_masked_webgl_data\": true,\r\n    \"is_masked_media_device\": true,\r\n    \"is_random_os\": true,\r\n    \"os\": {\r\n        \"type\": \"Windows\",\r\n        \"version\": \"Windows 10\"\r\n    },\r\n    \"webrtc_mode\": 1,\r\n    \"user_agent\": \"\"\r\n}";
			}
			text2 = text2.Replace("{profileName}", C1B1B61F);
			text2 = text2.Replace("{browser_version}", CAB497BC);
			string json = requestXNet_0.method_1(text, text2, "application/json");
			C61C311D = JObject.Parse(json)["data"]!["id"]!.ToString();
		}
		catch (Exception)
		{
			string_2 = "Create profile fail";
		}
	}

	public void method_1(string DF1FAAAF, string A1BA3883)
	{
		string text = A092B4BE + "profiles/update/" + C61C311D;
		string text2 = "";
		if (C5034B95.smethod_0("configGeneral").method_3("ckbGpmLogin"))
		{
			text2 = "{\"raw_proxy\" : \"{proxy}\", \"user_agent\": \"{useragent}\", \"browser_version\":\"{browser_version}\", \"webrtc_mode\":2}";
		}
		if (C5034B95.smethod_0("configGeneral").method_3("ckbGemLogin"))
		{
			text2 = "{\"raw_proxy\": \"http://{proxy}\",\r\n  \"user_agent\": \"{useragent}\", \"web_rtc\":\"noise\"}";
		}
		text2 = text2.Replace("{proxy}", DF1FAAAF);
		text2 = text2.Replace("{useragent}", A1BA3883);
		text2 = text2.Replace("{browser_version}", C5034B95.smethod_0("configGeneral").BDB80B23("cbbBrowserVersion", "127.0.6533.73"));
		try
		{
			requestXNet_0.method_1(text, text2, "application/json");
		}
		catch (Exception)
		{
			string_2 = "Update profile fail";
		}
	}

	public void method_2(string string_3 = "")
	{
		method_3();
		string text = A092B4BE + "profiles/start/" + C61C311D;
		if (string_3 != "")
		{
			text = text + "?addination_args=" + string_3;
		}
		try
		{
			string json = requestXNet_0.E58EB99F(text);
			string_1 = JObject.Parse(json)["data"]!["driver_path"]!.ToString();
			string_0 = JObject.Parse(json)["data"]!["remote_debugging_address"]!.ToString();
		}
		catch (Exception)
		{
			string_2 = "Open profile fail";
		}
	}

	public void method_3()
	{
		smethod_4(C61C311D);
	}
}
