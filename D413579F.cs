using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class D413579F
{
	internal string E623A307 = "";

	internal string A799E5B2 = "";

	internal string B8BAD80E = "";

	internal List<ObcProxy> F382379C;

	public D413579F(string string_0)
	{
		B8BAD80E = string_0;
		F382379C = new List<ObcProxy>();
	}

	public string FFBBF316()
	{
		return B8BAD80E;
	}

	public void method_0(ObcProxy E9142027)
	{
		E623A307 = E9142027.method_7();
		A799E5B2 = E9142027.method_8();
		F382379C.Add(E9142027);
	}

	public List<ObcProxy> A32E0104()
	{
		return F382379C;
	}

	public List<ObcProxy> B7AAE719()
	{
		List<ObcProxy> list = new List<ObcProxy>();
		for (int i = 0; i < F382379C.Count; i++)
		{
			ObcProxy obcProxy = F382379C[i];
			if (obcProxy.bool_0 && obcProxy.C701F934 < obcProxy.E90A3910)
			{
				list.Add(obcProxy);
			}
		}
		return list;
	}

	public bool method_1()
	{
		bool result = false;
		try
		{
			_ = Environment.TickCount;
			string string_ = E623A307.TrimEnd('/') + "/reset?proxy=" + A799E5B2 + "&type=deep";
			RequestXNet requestXNet = new RequestXNet();
			string json = requestXNet.E58EB99F(string_);
			JObject jObject = JObject.Parse(json);
			if (jObject.ContainsKey("msg") && (JObject.Parse(json)["msg"]!.ToString() == "command_sent" || JObject.Parse(json)["msg"]!.ToString() == "OK" || JObject.Parse(json)["msg"]!.ToString().ToLower() == "ok"))
			{
				result = true;
			}
			else if (jObject.ContainsKey("error_code") && JObject.Parse(json)["error_code"]!.ToString().ToLower() == "0")
			{
				result = true;
			}
		}
		catch
		{
		}
		foreach (ObcProxy item in F382379C)
		{
			item.C701F934 = 0;
		}
		return result;
	}

	public bool method_2()
	{
		int num = 0;
		while (true)
		{
			if (num < F382379C.Count)
			{
				ObcProxy obcProxy = F382379C[num];
				if (obcProxy.bool_0 && (obcProxy.C701F934 != obcProxy.E90A3910 || obcProxy.int_0 != 0))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static Dictionary<string, List<string>> smethod_0(string C2097F08)
	{
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		try
		{
			C2097F08 = C2097F08.TrimEnd('/') + "/api/v1/dongles/all";
			string text = new RequestXNet().E58EB99F(C2097F08);
			text = "{data:" + text + "}";
			JObject jObject = JObject.Parse(text);
			foreach (JToken item2 in (IEnumerable<JToken>)(jObject["data"]!))
			{
				string key = item2["rootId"]!.ToString();
				string item = item2["httpPortV6"]!.ToString();
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<string>());
				}
				dictionary[key].Add(item);
			}
		}
		catch (Exception)
		{
		}
		return dictionary;
	}

	public static D413579F smethod_1(List<D413579F> E80E6004, string string_0)
	{
		D413579F result = null;
		for (int i = 0; i < E80E6004.Count; i++)
		{
			if (E80E6004[i].FFBBF316() == string_0)
			{
				result = E80E6004[i];
				break;
			}
		}
		return result;
	}
}
