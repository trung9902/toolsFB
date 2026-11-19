using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

public class GClass4
{
	internal string string_0;

	internal JObject jobject_0;

	public GClass4(string string_1, bool F79F9AB5 = false)
	{
		try
		{
			if (F79F9AB5)
			{
				if (string_1.Trim() == "")
				{
					string_1 = "{}";
				}
				jobject_0 = JObject.Parse(string_1);
				return;
			}
			string_0 = "settings\\" + string_1 + ".json";
			if (!File.Exists(string_0))
			{
				using (File.AppendText(string_0))
				{
				}
			}
			jobject_0 = JObject.Parse(File.ReadAllText(string_0));
		}
		catch
		{
			jobject_0 = new JObject();
		}
	}

	public GClass4()
	{
		jobject_0 = new JObject();
	}

	public string BDB80B23(string C19D25AB, string E7BC1925 = "")
	{
		string result = E7BC1925;
		try
		{
			result = ((jobject_0[C19D25AB] == null) ? E7BC1925 : jobject_0[C19D25AB]!.ToString());
		}
		catch
		{
		}
		return result;
	}

	public bool method_0(string string_1)
	{
		return jobject_0.ContainsKey(string_1);
	}

	public List<string> method_1(string string_1, int F4076A09 = 0)
	{
		List<string> list = new List<string>();
		try
		{
			list = ((F4076A09 != 0) ? BDB80B23(string_1).Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : BDB80B23(string_1).Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList());
			list = Commom.smethod_36(list);
		}
		catch
		{
		}
		return list;
	}

	public int method_2(string string_1, int E0B32829 = 0)
	{
		int result = E0B32829;
		try
		{
			result = ((jobject_0[string_1] == null) ? E0B32829 : Convert.ToInt32(jobject_0[string_1]!.ToString()));
		}
		catch
		{
		}
		return result;
	}

	public bool method_3(string string_1, bool C9B3010F = false)
	{
		bool result = C9B3010F;
		try
		{
			result = ((jobject_0[string_1] == null) ? C9B3010F : Convert.ToBoolean(jobject_0[string_1]!.ToString()));
			return result;
		}
		catch
		{
			return result;
		}
	}

	public void method_4(string string_1, object object_0)
	{
		try
		{
			if (object_0.GetType() == typeof(bool))
			{
				jobject_0[string_1] = (JToken)object_0.ToString().ToLower();
			}
			else
			{
				jobject_0[string_1] = (JToken)object_0.ToString();
			}
		}
		catch
		{
		}
	}

	public void FD3CCF90(string B60D428D, List<string> list_0)
	{
		try
		{
			if (list_0.Any((string FE0FDEB2) => FE0FDEB2.Contains("\n")))
			{
				jobject_0[B60D428D] = (JToken)string.Join("\n|\n", list_0).ToString();
			}
			else
			{
				jobject_0[B60D428D] = (JToken)string.Join("\n", list_0).ToString();
			}
		}
		catch
		{
		}
	}

	public void method_5(string string_1)
	{
		try
		{
			jobject_0.Remove(string_1);
		}
		catch
		{
		}
	}

	public void AEBFED04(string string_1 = "")
	{
		for (int i = 0; i < 5; i++)
		{
			try
			{
				if (string_1 == "")
				{
					string_1 = string_0;
				}
				File.WriteAllText(string_1, jobject_0.ToString());
				return;
			}
			catch
			{
			}
			Commom.smethod_52(1.0);
		}
	}

	public string ED11179C()
	{
		string result = "";
		try
		{
			result = jobject_0.ToString().Replace("\r\n", "");
		}
		catch (Exception)
		{
		}
		return result;
	}
}
