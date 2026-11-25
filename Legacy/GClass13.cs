using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public static class GClass13
{
	[Serializable]
	[CompilerGenerated]
	private sealed class A9375CA5
	{
		internal static readonly A9375CA5 _003C_003E9 = new A9375CA5();

		internal static Func<string, Guid> _003C_003E9__10_0;

		internal Guid C9BD1319(string F3A11420)
		{
			return Guid.NewGuid();
		}
	}

	public static bool smethod_0(List<string> list_0, List<string> F1225E24)
	{
		List<string> source = list_0.Except(F1225E24).ToList();
		List<string> source2 = F1225E24.Except(list_0).ToList();
		return !source.Any() && !source2.Any();
	}

	public static List<string> smethod_1(List<string> BA051EBF)
	{
		string text = "";
		int num = BA051EBF.Count;
		int num2 = 0;
		while (num != 0)
		{
			num2 = Base.rd.Next(0, BA051EBF.Count);
			num--;
			text = BA051EBF[num];
			BA051EBF[num] = BA051EBF[num2];
			BA051EBF[num2] = text;
		}
		return BA051EBF;
	}

	public static List<string> C53EB88B(List<string> B4A5F49A)
	{
		List<string> list = new List<string>();
		try
		{
			for (int i = 0; i < B4A5F49A.Count; i++)
			{
				list.Add(B4A5F49A[i]);
			}
		}
		catch
		{
		}
		return list;
	}

	public static List<List<string>> smethod_2(List<string> FB295EAC, int F7104E04)
	{
		List<List<string>> list = new List<List<string>>();
		try
		{
			int num = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)FB295EAC.Count * 1.0 / (double)F7104E04)));
			for (int i = 0; i < num; i++)
			{
				list.Add(FB295EAC.GetRange(F7104E04 * i, (F7104E04 * i + F7104E04 <= FB295EAC.Count) ? F7104E04 : (FB295EAC.Count % F7104E04)));
			}
		}
		catch
		{
		}
		return list;
	}

	public static string smethod_3(List<string> A7AFCE86, string A28673BA = "\r\n")
	{
		return string.Join(A28673BA, A7AFCE86);
	}

	public static string smethod_4(List<string> list_0)
	{
		string result = "";
		if (list_0.Count > 0)
		{
			result = list_0.Last();
			list_0.RemoveAt(list_0.Count - 1);
		}
		return result;
	}

	public static List<string> smethod_5(List<string> FE35261D, List<string> B73E4C3D)
	{
		foreach (string item in B73E4C3D)
		{
			FE35261D.Remove(item);
		}
		return FE35261D;
	}

	public static int smethod_6(int int_0)
	{
		return D51B46A3(0, int_0 - 1);
	}

	public static int D51B46A3(int int_0, int int_1)
	{
		return Base.rd.Next(int_0, int_1 + 1);
	}

	public static int smethod_7(this List<string> EB9F5588)
	{
		return smethod_6(EB9F5588.Count);
	}

	public static string smethod_8(this List<string> C8199D0D)
	{
		if (C8199D0D.Count == 0)
		{
			return null;
		}
		return C8199D0D.OrderBy((string F3A11420) => Guid.NewGuid()).First();
	}
}
