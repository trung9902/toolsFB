using System.Collections.Generic;
using System.IO;
using System.Linq;

public class C5034B95
{
	internal static Dictionary<string, GClass4> E79C98BF = new Dictionary<string, GClass4>();

	public static GClass4 smethod_0(string string_0, bool bool_0 = false)
	{
		if (bool_0)
		{
			BA970699(string_0);
		}
		else
		{
			lock (E79C98BF)
			{
				if (!E79C98BF.ContainsKey(string_0))
				{
					E79C98BF.Add(string_0, new GClass4(string_0));
				}
			}
		}
		return E79C98BF[string_0];
	}

	private static void BA970699(string string_0)
	{
		if (E79C98BF.ContainsKey(string_0))
		{
			E79C98BF[string_0] = new GClass4(string_0);
		}
		else
		{
			E79C98BF.Add(string_0, new GClass4(string_0));
		}
	}

	public static void smethod_1(string string_0)
	{
		if (E79C98BF.ContainsKey(string_0))
		{
			E79C98BF[string_0].AEBFED04();
		}
		BA970699(string_0);
	}

	public static string smethod_2()
	{
		string text = smethod_0("configGeneral").BDB80B23("txbPathProfile").Trim();
		if (text == "" || !Directory.Exists(text)) text = "profiles";
		if (!Path.IsPathRooted(text)) text = Path.Combine(Commom.smethod_95(), text);
		try
		{
			if (!Directory.Exists(text)) Directory.CreateDirectory(text);
		}
		catch { }
		return Path.GetFullPath(text);
	}

	public static string smethod_3()
	{
		return Commom.smethod_95() + "\\backup";
	}

	public static bool smethod_4()
	{
		return smethod_0("configGeneral").method_3("ckbMysqlServer") && smethod_0("configGeneral").BDB80B23("txtMysqlServer") != "";
	}
}
