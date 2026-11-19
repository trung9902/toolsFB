using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

internal class Class87
{
	internal static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	internal static bool bool_0 = false;

	public static string smethod_0(string string_0)
	{
		if (!bool_0)
		{
			return "";
		}
		string result = "";
		if (dictionary_0.ContainsKey(string_0))
		{
			result = dictionary_0[string_0];
		}
		return result;
	}

	public static void smethod_1(string string_0, string string_1)
	{
		if (bool_0)
		{
			if (dictionary_0.ContainsKey(string_0))
			{
				dictionary_0[string_0] = string_1;
			}
			else
			{
				dictionary_0.Add(string_0, string_1);
			}
		}
	}

	public static void smethod_2()
	{
		if (!bool_0)
		{
			return;
		}
		DataTable source = CommonSQL.B3B3608F();
		try
		{
			dictionary_0 = source.AsEnumerable().ToDictionary((DataRow dataRow_0) => dataRow_0[0].ToString(), (DataRow dataRow_0) => dataRow_0[1].ToString());
		}
		catch
		{
			dictionary_0 = (from dataRow_0 in source.AsEnumerable()
				group dataRow_0 by dataRow_0[0].ToString()).ToDictionary((IGrouping<string, DataRow> igrouping_0) => igrouping_0.Key, (IGrouping<string, DataRow> B53FFF8E) => B53FFF8E.First()[1].ToString());
		}
	}

	public static void smethod_3()
	{
		if (bool_0)
		{
			List<string> a4143DAB = dictionary_0.Where(delegate(KeyValuePair<string, string> keyValuePair_0)
			{
				KeyValuePair<string, string> keyValuePair2 = keyValuePair_0;
				return keyValuePair2.Value.Trim() != "";
			}).Select(delegate(KeyValuePair<string, string> keyValuePair_0)
			{
				KeyValuePair<string, string> keyValuePair = keyValuePair_0;
				string key = keyValuePair.Key;
				keyValuePair = keyValuePair_0;
				return key + "|" + keyValuePair.Value;
			}).ToList();
			CommonSQL.smethod_5("status", a4143DAB);
		}
	}
}
