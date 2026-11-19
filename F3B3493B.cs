using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

public class F3B3493B
{
	internal string string_0;

	internal string D49A2C87 = Assembly.GetExecutingAssembly().GetName().Name;

	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	private static extern long WritePrivateProfileString(string AA8EC502, string AA13F8A8, string string_1, string string_2);

	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string string_1, string string_2, string string_3, StringBuilder stringBuilder_0, int int_0, string string_4);

	[DllImport("KERNEL32.DLL", CharSet = CharSet.Unicode)]
	private static extern uint GetPrivateProfileStringW(string string_1, string string_2, string string_3, byte[] EA0E6B26, uint uint_0, string CB88CF91);

	public F3B3493B(string string_1 = null)
	{
		string_0 = new FileInfo(string_1 ?? (D49A2C87 + ".ini")).FullName.ToString();
	}

	public string method_0(string string_1, string string_2 = null)
	{
		byte[] array = new byte[1024];
		uint privateProfileStringW = GetPrivateProfileStringW(string_2 ?? D49A2C87, string_1, "", array, (uint)array.Length, string_0);
		return Encoding.Unicode.GetString(array, 0, (int)(privateProfileStringW * 2));
	}

	public string F98AC9A1(string string_1, string string_2 = null)
	{
		StringBuilder stringBuilder = new StringBuilder(255);
		GetPrivateProfileString(string_2 ?? D49A2C87, string_1, "", stringBuilder, 255, string_0);
		return stringBuilder.ToString();
	}

	public void method_1(string B6895781, string string_1, string string_2 = null)
	{
		WritePrivateProfileString(string_2 ?? D49A2C87, B6895781, string_1, string_0);
	}

	public void DEB29A8D(string string_1, string string_2 = null)
	{
		method_1(string_1, null, string_2 ?? D49A2C87);
	}

	public void method_2(string string_1 = null)
	{
		method_1(null, null, string_1 ?? D49A2C87);
	}

	public bool method_3(string B6ACD1B8, string A924AF33 = null)
	{
		return F98AC9A1(B6ACD1B8, A924AF33).Length > 0;
	}
}
