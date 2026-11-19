using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class GClass9
{
	[CompilerGenerated]
	private sealed class Class62
	{
		internal string C79CB593;

		internal bool C3825F15(GClass10 DF9A7E13)
		{
			return DF9A7E13.String_0 == C79CB593;
		}
	}

	[CompilerGenerated]
	private sealed class D1AA6319
	{
		internal string A022B41D;

		internal bool method_0(GClass10 EBA29917)
		{
			return EBA29917.String_0 == A022B41D;
		}
	}

	[CompilerGenerated]
	private sealed class Class63
	{
		internal GClass10 D0897F14;

		internal bool CFB793A2(GClass10 gclass10_0)
		{
			return gclass10_0.String_0 == D0897F14.String_0;
		}
	}

	[CompilerGenerated]
	private sealed class Class64
	{
		internal string EDB7890C;

		internal bool method_0(GClass10 gclass10_0)
		{
			return gclass10_0.String_0 == EDB7890C;
		}
	}

	internal static string string_0 = Commom.smethod_95() + "\\prompt.json";

	public static List<GClass10> EC28DF14()
	{
		if (!File.Exists(string_0))
		{
			return new List<GClass10>();
		}
		string value = File.ReadAllText(string_0);
		return JsonConvert.DeserializeObject<List<GClass10>>(value) ?? new List<GClass10>();
	}

	public static GClass10 F404A484(string string_1)
	{
		List<GClass10> list = EC28DF14();
		int num = list.FindIndex((GClass10 DF9A7E13) => DF9A7E13.String_0 == string_1);
		if (num == -1)
		{
			return null;
		}
		return list[num];
	}

	public static string smethod_0(string string_1)
	{
		List<GClass10> list = EC28DF14();
		int num = list.FindIndex((GClass10 EBA29917) => EBA29917.String_0 == string_1);
		if (num == -1)
		{
			return "";
		}
		return list[num].String_3;
	}

	public static void DF26772D(List<GClass10> C83F2190)
	{
		string contents = JsonConvert.SerializeObject(C83F2190, Formatting.Indented);
		File.WriteAllText(string_0, contents);
	}

	public static bool smethod_1(GClass10 FA01D734)
	{
		try
		{
			List<GClass10> list = EC28DF14();
			int num = list.FindIndex((GClass10 gclass10_0) => gclass10_0.String_0 == FA01D734.String_0);
			if (num == -1)
			{
				list.Add(FA01D734);
			}
			else
			{
				list[num] = FA01D734;
			}
			DF26772D(list);
			return true;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static bool E6115228(string D0BF952E)
	{
		try
		{
			List<GClass10> list = EC28DF14();
			list.RemoveAll((GClass10 gclass10_0) => gclass10_0.String_0 == D0BF952E);
			DF26772D(list);
			return true;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static void smethod_2(List<GClass10> list_0)
	{
		foreach (GClass10 item in list_0)
		{
			Console.WriteLine("ID: " + item.String_0 + ", Name: " + item.String_1 + ", Type: " + item.E2AD160C + ", Prompt: " + item.String_3);
		}
	}
}
