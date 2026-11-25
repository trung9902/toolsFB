using System;

public static class B7059719
{
	public static bool smethod_0(string string_0)
	{
		try
		{
			Convert.ToInt32(string_0);
			return true;
		}
		catch
		{
		}
		return false;
	}

	public static string smethod_1(this string string_0, int int_0 = 0, char char_0 = '*')
	{
		try
		{
			string text = "";
			for (int i = 0; i < string_0.Length; i++)
			{
				if (string_0[i] != char_0)
				{
					text += string_0[i];
					continue;
				}
				switch (int_0)
				{
				case 0:
					text += Commom.B820DC86(1, "0");
					break;
				case 1:
					text += Commom.B820DC86(1, "a");
					break;
				case 2:
					text += Commom.B820DC86(1, "a_0");
					break;
				}
			}
			return text;
		}
		catch
		{
		}
		return "";
	}
}
