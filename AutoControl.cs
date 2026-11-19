using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public class AutoControl
{
	public delegate bool GDelegate0(IntPtr intptr_0, IntPtr A8022130);

	private delegate bool Delegate0(IntPtr intptr_0, IntPtr intptr_1);

	[Flags]
	public enum GEnum2 : uint
	{
		E18C9828 = 0x2u,
		flag_1 = 0x4u,
		flag_2 = 0x20u,
		BF99FDAE = 0x40u,
		A2A12D1C = 0x1u,
		C7237FAE = 0x8000u,
		B4AA8F06 = 0x8u,
		flag_7 = 0x10u,
		EE99D702 = 0x800u,
		flag_9 = 0x80u,
		flag_10 = 0x100u,
		flag_11 = 0x1u,
		flag_12 = 0x2u
	}

	private struct D797AB36
	{
		internal int int_0;

		internal int D589C13B;

		internal int BA97BA86;

		internal int int_1;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class E61E6399
	{
		internal static readonly E61E6399 _003C_003E9 = new E61E6399();

		internal static Func<Process, bool> _003C_003E9__25_0;

		internal static Func<Process, bool> _003C_003E9__26_0;

		internal static Delegate0 _003C_003E9__30_0;

		internal bool method_0(Process process_0)
		{
			return process_0.MainWindowHandle != IntPtr.Zero;
		}

		internal bool method_1(Process AC8A70B1)
		{
			return AC8A70B1.MainWindowHandle != IntPtr.Zero;
		}

		internal bool method_2(IntPtr intptr_0, IntPtr EEB47E91)
		{
			GCHandle gCHandle = GCHandle.FromIntPtr(EEB47E91);
			if (gCHandle.Target == null)
			{
				return false;
			}
			List<IntPtr> list = gCHandle.Target as List<IntPtr>;
			list.Add(intptr_0);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class Class5
	{
		internal string F313F63C;

		internal string A33E1ABB;

		internal bool FAA850A5(IntPtr intptr_0)
		{
			string text = D6821A9A(intptr_0);
			string text2 = smethod_27(intptr_0);
			return text == F313F63C || text2 == A33E1ABB;
		}
	}

	[CompilerGenerated]
	private sealed class Class6
	{
		internal string string_0;

		internal string string_1;

		internal bool FC8ACD0F(IntPtr C4939A07)
		{
			string text = D6821A9A(C4939A07);
			string text2 = smethod_27(C4939A07);
			return text == string_0 || text2 == string_1;
		}
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr FindWindow(string string_0, string string_1);

	[DllImport("User32.dll")]
	public static extern bool EnumChildWindows(IntPtr intptr_0, GDelegate0 gdelegate0_0, IntPtr intptr_1);

	[DllImport("User32.dll")]
	public static extern int GetWindowText(IntPtr intptr_0, StringBuilder stringBuilder_0, int F120FE2E);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr DCAF9118, StringBuilder stringBuilder_0, int int_0);

	[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
	private static extern IntPtr FindWindow_1(IntPtr F10E2994, string DA97472D);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, IntPtr FD842432);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_1(IntPtr intptr_0, int int_0, int int_1, IntPtr intptr_1);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_2(IntPtr intptr_0, int C727479B, IntPtr BB92A8B8, IntPtr intptr_1);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_3(IntPtr intptr_0, int int_0, IntPtr intptr_1, string string_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessage")]
	public static extern int SendMessage_4(IntPtr D23879A0, int int_0, int B48CE088, string C82F8480);

	[DllImport("user32.dll")]
	private static extern IntPtr GetDlgItem(IntPtr intptr_0, int int_0);

	[DllImport("user32.dll")]
	private static extern bool SetDlgItemTextA(IntPtr intptr_0, int B8130899, string string_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern IntPtr FindWindowEx(IntPtr AE0E080B, IntPtr AE877B39, string string_0, string C5B71A1A);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool PostMessage(IntPtr D21C0B3A, int int_0, IntPtr intptr_0, IntPtr intptr_1);

	[DllImport("user32.dll", EntryPoint = "PostMessage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool PostMessage_1(IntPtr intptr_0, int int_0, IntPtr DF98570A, string E08847B1);

	[DllImport("user32.dll")]
	private static extern bool SetForegroundWindow(IntPtr F40D1B1A);

	[DllImport("user32", EntryPoint = "EnumChildWindows")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumChildWindows_1(IntPtr BB9EF0B0, Delegate0 delegate0_0, IntPtr intptr_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	public static extern void mouse_event(uint uint_0, int int_0, int int_1, int int_2, UIntPtr EC802A17);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool MoveWindow(IntPtr intptr_0, int int_0, int E30A0E09, int int_1, int int_2, bool E6B6F134);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern uint SendInput(uint uint_0, GStruct1[] gstruct1_0, int C42B6626);

	public static IntPtr smethod_0(string E03EA694, string A6250896 = null)
	{
		IntPtr intPtr = FindWindow(E03EA694, A6250896);
		SetForegroundWindow(intPtr);
		return intPtr;
	}

	public static IntPtr smethod_1(IntPtr E8ABC29D)
	{
		SetForegroundWindow(E8ABC29D);
		return E8ABC29D;
	}

	public static bool smethod_2(IntPtr intptr_0)
	{
		return IsWindowVisible(intptr_0);
	}

	public static IntPtr D58E88A2(string DB995EA4, string BC36EC34)
	{
		return FindWindow(DB995EA4, BC36EC34);
	}

	[DllImport("User32.dll")]
	public static extern bool ShowWindow(IntPtr F08A8039, int E49E60A9);

	public static List<IntPtr> smethod_3(string A78994BD, string string_0, int A3BAD2B1 = 1)
	{
		Process[] processes = Process.GetProcesses();
		List<IntPtr> list = new List<IntPtr>();
		int num = 0;
		foreach (Process item in processes.Where((Process process_0) => process_0.MainWindowHandle != IntPtr.Zero))
		{
			IntPtr mainWindowHandle = item.MainWindowHandle;
			string text = D6821A9A(mainWindowHandle);
			string text2 = smethod_27(mainWindowHandle);
			if (text == A78994BD || text2 == string_0)
			{
				list.Add(mainWindowHandle);
				if (num >= A3BAD2B1)
				{
					break;
				}
				num++;
			}
		}
		return list;
	}

	public static IntPtr F69495B3(string ED9B880A, string A50D3D2D)
	{
		Process[] processes = Process.GetProcesses();
		IntPtr result = IntPtr.Zero;
		foreach (Process item in processes.Where((Process AC8A70B1) => AC8A70B1.MainWindowHandle != IntPtr.Zero))
		{
			IntPtr mainWindowHandle = item.MainWindowHandle;
			string text = D6821A9A(mainWindowHandle);
			string text2 = smethod_27(mainWindowHandle);
			Console.WriteLine("className2: " + text);
			Console.WriteLine("text: " + text2);
			Console.WriteLine("=========================");
			if (text == ED9B880A || text2 == A50D3D2D)
			{
				result = mainWindowHandle;
				break;
			}
		}
		return result;
	}

	public static IntPtr A5256A3B(IntPtr intptr_0, string A31C4402, string string_0)
	{
		return FindWindowEx(intptr_0, IntPtr.Zero, string_0, A31C4402);
	}

	private static IntPtr FC8D2E3F(IntPtr intptr_0, int int_0)
	{
		if (int_0 == 0)
		{
			return intptr_0;
		}
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		do
		{
			intPtr = FindWindowEx(intptr_0, intPtr, "Button", null);
			if (intPtr != IntPtr.Zero)
			{
				num++;
			}
		}
		while (num < int_0 && intPtr != IntPtr.Zero);
		return intPtr;
	}

	public static IntPtr smethod_4(IntPtr intptr_0, int int_0)
	{
		return GetDlgItem(intptr_0, int_0);
	}

	public static List<IntPtr> C616E4BF(IntPtr intptr_0)
	{
		List<IntPtr> list = new List<IntPtr>();
		GCHandle value = GCHandle.Alloc(list);
		IntPtr intptr_ = GCHandle.ToIntPtr(value);
		try
		{
			Delegate0 delegate0_ = delegate(IntPtr intptr_0, IntPtr EEB47E91)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(EEB47E91);
				if (gCHandle.Target == null)
				{
					return false;
				}
				List<IntPtr> list2 = gCHandle.Target as List<IntPtr>;
				list2.Add(intptr_0);
				return true;
			};
			EnumChildWindows_1(intptr_0, delegate0_, intptr_);
		}
		finally
		{
			value.Free();
		}
		return list;
	}

	[DllImport("user32.dll")]
	public static extern bool ShowWindowAsync(HandleRef A8267407, int int_0);

	public static IntPtr smethod_5(List<IntPtr> F33AA383, string string_0, string string_1)
	{
		return F33AA383.Find(delegate(IntPtr intptr_0)
		{
			string text = D6821A9A(intptr_0);
			string text2 = smethod_27(intptr_0);
			return text == string_0 || text2 == string_1;
		});
	}

	public static List<IntPtr> smethod_6(List<IntPtr> EDB9FE87, string string_0, string string_1)
	{
		new List<IntPtr>();
		IEnumerable<IntPtr> source = EDB9FE87.Where(delegate(IntPtr C4939A07)
		{
			string text = D6821A9A(C4939A07);
			string text2 = smethod_27(C4939A07);
			return text == string_0 || text2 == string_1;
		});
		return source.ToList();
	}

	public static IntPtr EE38740A(IntPtr D13ADB29, string string_0, string string_1)
	{
		return smethod_5(C616E4BF(D13ADB29), string_0, string_1);
	}

	public static List<IntPtr> smethod_7(IntPtr intptr_0, string CA379A0F, string string_0)
	{
		return smethod_6(C616E4BF(intptr_0), CA379A0F, string_0);
	}

	public static bool smethod_8(IntPtr D935A28B, IntPtr AD064512)
	{
		string text = smethod_27(D935A28B);
		string text2 = D6821A9A(D935A28B);
		if (text == "&Options >>" && text2.StartsWith("ToolbarWindow32"))
		{
			SendMessage_2(D935A28B, 0, IntPtr.Zero, IntPtr.Zero);
			return false;
		}
		return true;
	}

	public static void F314308D(IntPtr intptr_0, int EAA37BB4)
	{
		IntPtr dlgItem = GetDlgItem(intptr_0, EAA37BB4);
		int int_ = 0 | (EAA37BB4 & 0xFFFF);
		SendMessage_1(intptr_0, 273, int_, dlgItem);
	}

	public static void smethod_9(IntPtr intptr_0)
	{
		SendMessage_2(intptr_0, 513, IntPtr.Zero, IntPtr.Zero);
		SendMessage_2(intptr_0, 514, IntPtr.Zero, IntPtr.Zero);
	}

	public static void smethod_10(IntPtr intptr_0, int int_0, int int_1, GEnum1 F224E6B6 = GEnum1.const_0, int int_2 = 1)
	{
		int int_3 = 0;
		int int_4 = 0;
		if (F224E6B6 == GEnum1.const_0)
		{
			int_3 = 513;
			int_4 = 514;
		}
		if (F224E6B6 == GEnum1.A73C0D22)
		{
			int_3 = 516;
			int_4 = 517;
		}
		IntPtr intptr_ = smethod_29(int_0, int_1);
		if (F224E6B6 == GEnum1.const_0 || F224E6B6 == GEnum1.A73C0D22)
		{
			for (int i = 0; i < int_2; i++)
			{
				PostMessage(intptr_0, 6, new IntPtr(1), intptr_);
				PostMessage(intptr_0, int_3, new IntPtr(1), intptr_);
				PostMessage(intptr_0, int_4, new IntPtr(0), intptr_);
			}
			return;
		}
		if (F224E6B6 == GEnum1.const_2)
		{
			int_3 = 515;
			int_4 = 514;
		}
		if (F224E6B6 == GEnum1.const_3)
		{
			int_3 = 518;
			int_4 = 517;
		}
		PostMessage(intptr_0, int_3, new IntPtr(1), intptr_);
		PostMessage(intptr_0, int_4, new IntPtr(0), intptr_);
	}

	public static void smethod_11(IntPtr intptr_0, int B29F6E39, int int_0, int B284F597, int int_1, int CF103EAD = 10, int CD38372D = 10, double A3345919 = 0.05)
	{
		int int_2 = 513;
		int int_3 = 514;
		IntPtr intptr_ = smethod_29(B29F6E39, int_0);
		IntPtr intptr_2 = smethod_29(B284F597, int_1);
		if (B284F597 < B29F6E39)
		{
			CF103EAD *= -1;
		}
		if (int_1 < int_0)
		{
			CD38372D *= -1;
		}
		PostMessage(intptr_0, 6, new IntPtr(1), intptr_);
		PostMessage(intptr_0, int_2, new IntPtr(1), intptr_);
		bool flag = false;
		bool flag2 = false;
		while (true)
		{
			PostMessage(intptr_0, 512, new IntPtr(1), smethod_29(B29F6E39, int_0));
			if (CF103EAD <= 0)
			{
				if (B29F6E39 > B284F597)
				{
					B29F6E39 += CF103EAD;
				}
				else
				{
					flag = true;
				}
			}
			else if (B29F6E39 < B284F597)
			{
				B29F6E39 += CF103EAD;
			}
			else
			{
				flag = true;
			}
			if (CD38372D > 0)
			{
				if (int_0 < int_1)
				{
					int_0 += CD38372D;
				}
				else
				{
					flag2 = true;
				}
			}
			else if (int_0 > int_1)
			{
				int_0 += CD38372D;
			}
			else
			{
				flag2 = true;
			}
			if (flag && flag2)
			{
				break;
			}
			Thread.Sleep(TimeSpan.FromSeconds(A3345919));
		}
		PostMessage(intptr_0, int_3, new IntPtr(0), intptr_2);
	}

	public static void smethod_12(IntPtr intptr_0, int int_0, int C99BE190, GEnum1 genum1_0 = GEnum1.const_0, int int_1 = 1)
	{
		int int_2 = 0;
		if (genum1_0 == GEnum1.const_0)
		{
			int_2 = 513;
		}
		if (genum1_0 == GEnum1.A73C0D22)
		{
			int_2 = 516;
		}
		IntPtr intptr_ = smethod_29(int_0, C99BE190);
		for (int i = 0; i < int_1; i++)
		{
			PostMessage(intptr_0, 6, new IntPtr(1), intptr_);
			PostMessage(intptr_0, int_2, new IntPtr(1), intptr_);
		}
	}

	public static void smethod_13(IntPtr intptr_0, int int_0, int B7841927, GEnum1 CF2CB401 = GEnum1.const_0, int A21B8593 = 1)
	{
		int c727479B = 0;
		if (CF2CB401 == GEnum1.const_0)
		{
			c727479B = 514;
		}
		if (CF2CB401 == GEnum1.A73C0D22)
		{
			c727479B = 517;
		}
		IntPtr intptr_ = smethod_29(int_0, B7841927);
		for (int i = 0; i < A21B8593; i++)
		{
			PostMessage(intptr_0, 6, new IntPtr(1), intptr_);
			SendMessage_2(intptr_0, c727479B, new IntPtr(0), intptr_);
		}
	}

	public static void smethod_14(IntPtr intptr_0, string string_0)
	{
		SendMessage_4(intptr_0, 12, 0, string_0);
	}

	public static void smethod_15(IntPtr intptr_0, GEnum0 E8395596)
	{
		PostMessage(intptr_0, 6, new IntPtr(1), new IntPtr(0));
		PostMessage(intptr_0, 256, new IntPtr((int)E8395596), new IntPtr(1));
		PostMessage(intptr_0, 257, new IntPtr((int)E8395596), new IntPtr(0));
	}

	public static void smethod_16(IntPtr intptr_0, string E682DE23, float C1AB3017 = 0.1f)
	{
		string text = E682DE23.ToLower();
		foreach (char c in text)
		{
			GEnum0 e = GEnum0.EA32FD2D;
			char c2 = c;
			switch (c2)
			{
			default:
				switch (c2)
				{
				case 'a':
					e = GEnum0.B8298122;
					break;
				case 'b':
					e = GEnum0.const_42;
					break;
				case 'c':
					e = GEnum0.const_62;
					break;
				case 'd':
					e = GEnum0.const_44;
					break;
				case 'e':
					e = GEnum0.const_45;
					break;
				case 'f':
					e = GEnum0.const_46;
					break;
				case 'g':
					e = GEnum0.DE21D8AF;
					break;
				case 'h':
					e = GEnum0.const_48;
					break;
				case 'i':
					e = GEnum0.const_49;
					break;
				case 'j':
					e = GEnum0.const_50;
					break;
				case 'k':
					e = GEnum0.E426DA22;
					break;
				case 'l':
					e = GEnum0.const_52;
					break;
				case 'm':
					e = GEnum0.const_53;
					break;
				case 'n':
					e = GEnum0.const_54;
					break;
				case 'o':
					e = GEnum0.const_55;
					break;
				case 'p':
					e = GEnum0.AA934136;
					break;
				case 'q':
					e = GEnum0.const_57;
					break;
				case 'r':
					e = GEnum0.const_58;
					break;
				case 's':
					e = GEnum0.const_59;
					break;
				case 't':
					e = GEnum0.B585991E;
					break;
				case 'u':
					e = GEnum0.D63073AA;
					break;
				case 'v':
					e = GEnum0.const_62;
					break;
				case 'w':
					e = GEnum0.const_63;
					break;
				case 'x':
					e = GEnum0.C7B81738;
					break;
				case 'y':
					e = GEnum0.const_65;
					break;
				case 'z':
					e = GEnum0.const_66;
					break;
				}
				break;
			case '0':
				e = GEnum0.EA32FD2D;
				break;
			case '1':
				e = GEnum0.const_32;
				break;
			case '2':
				e = GEnum0.const_33;
				break;
			case '3':
				e = GEnum0.C207B929;
				break;
			case '4':
				e = GEnum0.const_35;
				break;
			case '5':
				e = GEnum0.const_36;
				break;
			case '6':
				e = GEnum0.const_37;
				break;
			case '7':
				e = GEnum0.const_38;
				break;
			case '8':
				e = GEnum0.const_39;
				break;
			case '9':
				e = GEnum0.const_40;
				break;
			}
			smethod_15(intptr_0, e);
			Thread.Sleep(TimeSpan.FromSeconds(C1AB3017));
		}
	}

	public static void E40F5692(IntPtr D6A5FC0D, GEnum0 genum0_0)
	{
		PostMessage(D6A5FC0D, 6, new IntPtr(1), new IntPtr(0));
		PostMessage(D6A5FC0D, 257, new IntPtr((int)genum0_0), new IntPtr(0));
	}

	public static void smethod_17(IntPtr FB263119, GEnum0 genum0_0)
	{
		PostMessage(FB263119, 6, new IntPtr(1), new IntPtr(0));
		PostMessage(FB263119, 258, new IntPtr((int)genum0_0), new IntPtr(0));
	}

	public static void C7975838(IntPtr FC37082B, int int_0)
	{
		PostMessage(FC37082B, 6, new IntPtr(1), new IntPtr(0));
		PostMessage(FC37082B, 258, new IntPtr(int_0), new IntPtr(0));
	}

	public static void smethod_18(IntPtr DE21179E, GEnum0 genum0_0)
	{
		PostMessage(DE21179E, 6, new IntPtr(1), new IntPtr(0));
		PostMessage(DE21179E, 256, new IntPtr((int)genum0_0), new IntPtr(0));
	}

	public static void smethod_19(IntPtr intptr_0, string string_0, float E230E1AA = 0.1f)
	{
		string text = string_0.ToLower();
		foreach (char int_ in text)
		{
			C7975838(intptr_0, int_);
		}
	}

	public static void smethod_20(F293EC8D f293EC8D_0)
	{
		AFB504A7(f293EC8D_0);
	}

	public static void EF18AC1F(F293EC8D[] f293EC8D_0)
	{
		foreach (F293EC8D f293EC8D_ in f293EC8D_0)
		{
			smethod_21(f293EC8D_);
		}
		foreach (F293EC8D f293EC8D_2 in f293EC8D_0)
		{
			smethod_22(f293EC8D_2);
		}
	}

	public static void E9276F97(string B79D5398)
	{
		Clipboard.SetText(B79D5398);
		EF18AC1F(new F293EC8D[2]
		{
			F293EC8D.FEBA6F10,
			F293EC8D.const_94
		});
	}

	public static void AFB504A7(F293EC8D f293EC8D_0)
	{
		GStruct1 gStruct = default(GStruct1);
		gStruct.uint_0 = 1u;
		GStruct1 gStruct2 = gStruct;
		ref GStruct2 f7982E = ref gStruct2.F7982E22;
		GStruct5 a9A10EA = new GStruct5
		{
			ushort_0 = (ushort)f293EC8D_0,
			ushort_1 = 0,
			uint_0 = 0u,
			uint_1 = 0u,
			EEB6F49F = IntPtr.Zero
		};
		f7982E.A9A10EA9 = a9A10EA;
		gStruct = default(GStruct1);
		gStruct.uint_0 = 1u;
		GStruct1 gStruct3 = gStruct;
		ref GStruct2 f7982E2 = ref gStruct3.F7982E22;
		a9A10EA = new GStruct5
		{
			ushort_0 = (ushort)f293EC8D_0,
			ushort_1 = 0,
			uint_0 = 2u,
			uint_1 = 0u,
			EEB6F49F = IntPtr.Zero
		};
		f7982E2.A9A10EA9 = a9A10EA;
		GStruct1[] gstruct1_ = new GStruct1[2] { gStruct2, gStruct3 };
		if (SendInput(2u, gstruct1_, Marshal.SizeOf(typeof(GStruct1))) == 0)
		{
			throw new Exception();
		}
	}

	public static void D890EC13(string string_0, double C905B790 = 0.5)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '0':
				AFB504A7(F293EC8D.E3020616);
				break;
			case '1':
				AFB504A7(F293EC8D.const_64);
				break;
			case '2':
				AFB504A7(F293EC8D.A78A2E82);
				break;
			case '3':
				AFB504A7(F293EC8D.const_66);
				break;
			case '4':
				AFB504A7(F293EC8D.const_67);
				break;
			case '5':
				AFB504A7(F293EC8D.A70FF235);
				break;
			case '6':
				AFB504A7(F293EC8D.const_69);
				break;
			case '7':
				AFB504A7(F293EC8D.const_70);
				break;
			case '8':
				AFB504A7(F293EC8D.F109F93C);
				break;
			case '9':
				AFB504A7(F293EC8D.const_72);
				break;
			}
			Thread.Sleep(TimeSpan.FromSeconds(C905B790));
		}
	}

	public static void smethod_21(F293EC8D f293EC8D_0)
	{
		GStruct1 gStruct = default(GStruct1);
		gStruct.uint_0 = 1u;
		GStruct1 gStruct2 = gStruct;
		gStruct2.F7982E22.A9A10EA9 = default(GStruct5);
		gStruct2.F7982E22.A9A10EA9.ushort_0 = (ushort)f293EC8D_0;
		gStruct2.F7982E22.A9A10EA9.ushort_1 = 0;
		gStruct2.F7982E22.A9A10EA9.uint_0 = 0u;
		gStruct2.F7982E22.A9A10EA9.uint_1 = 0u;
		gStruct2.F7982E22.A9A10EA9.EEB6F49F = IntPtr.Zero;
		GStruct1[] gstruct1_ = new GStruct1[1] { gStruct2 };
		if (SendInput(1u, gstruct1_, Marshal.SizeOf(typeof(GStruct1))) == 0)
		{
			throw new Exception();
		}
	}

	public static void smethod_22(F293EC8D f293EC8D_0)
	{
		GStruct1 gStruct = default(GStruct1);
		gStruct.uint_0 = 1u;
		GStruct1 gStruct2 = gStruct;
		gStruct2.F7982E22.A9A10EA9 = default(GStruct5);
		gStruct2.F7982E22.A9A10EA9.ushort_0 = (ushort)f293EC8D_0;
		gStruct2.F7982E22.A9A10EA9.ushort_1 = 0;
		gStruct2.F7982E22.A9A10EA9.uint_0 = 2u;
		gStruct2.F7982E22.A9A10EA9.uint_1 = 0u;
		gStruct2.F7982E22.A9A10EA9.EEB6F49F = IntPtr.Zero;
		GStruct1[] gstruct1_ = new GStruct1[1] { gStruct2 };
		if (SendInput(1u, gstruct1_, Marshal.SizeOf(typeof(GStruct1))) == 0)
		{
			throw new Exception();
		}
	}

	public static void smethod_23(int int_0, int int_1, GEnum1 E72F6038 = GEnum1.const_0)
	{
		Cursor.Position = new Point(int_0, int_1);
		smethod_26(E72F6038);
	}

	public static void smethod_24(Point point_0, int EE9EAC9F, bool bool_0 = false)
	{
		Cursor.Position = point_0;
		mouse_event(2u, 0, 0, 0, UIntPtr.Zero);
		for (int i = 0; i < EE9EAC9F; i++)
		{
			if (!bool_0)
			{
				mouse_event(1u, 1, 0, 0, UIntPtr.Zero);
			}
			else
			{
				mouse_event(1u, -1, 0, 0, UIntPtr.Zero);
			}
		}
		mouse_event(32772u, 0, 0, 0, UIntPtr.Zero);
	}

	public static void smethod_25(Point E9928A21, int int_0, bool B28E07B1 = false)
	{
		Cursor.Position = E9928A21;
		mouse_event(2u, 0, 0, 0, UIntPtr.Zero);
		for (int i = 0; i < int_0; i++)
		{
			if (!B28E07B1)
			{
				mouse_event(1u, 0, 1, 0, UIntPtr.Zero);
			}
			else
			{
				mouse_event(1u, 0, -1, 0, UIntPtr.Zero);
			}
		}
		mouse_event(32772u, 0, 0, 0, UIntPtr.Zero);
	}

	public static void EC184AB3(Point point_0, int int_0, bool bool_0 = false)
	{
		Cursor.Position = point_0;
		mouse_event(2048u, 0, 0, int_0, UIntPtr.Zero);
	}

	public static void C691BC89(Point point_0, GEnum1 genum1_0 = GEnum1.const_0)
	{
		Cursor.Position = point_0;
		smethod_26(genum1_0);
	}

	public static void smethod_26(GEnum1 genum1_0 = GEnum1.const_0)
	{
		switch (genum1_0)
		{
		case GEnum1.const_0:
			mouse_event(32774u, 0, 0, 0, UIntPtr.Zero);
			break;
		case GEnum1.A73C0D22:
			mouse_event(32792u, 0, 0, 0, UIntPtr.Zero);
			break;
		case GEnum1.const_2:
			mouse_event(32774u, 0, 0, 0, UIntPtr.Zero);
			mouse_event(32774u, 0, 0, 0, UIntPtr.Zero);
			break;
		case GEnum1.const_3:
			mouse_event(32792u, 0, 0, 0, UIntPtr.Zero);
			mouse_event(32792u, 0, 0, 0, UIntPtr.Zero);
			break;
		}
	}

	public static string smethod_27(IntPtr intptr_0)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		GetWindowText(intptr_0, stringBuilder, 256);
		return stringBuilder.ToString().Trim();
	}

	public static string D6821A9A(IntPtr F338F018)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		GetClassName(F338F018, stringBuilder, 256);
		return stringBuilder.ToString().Trim();
	}

	public static IntPtr smethod_28(int int_0, int int_1)
	{
		return (IntPtr)((int_1 << 16) | (int_0 & 0xFFFF));
	}

	public static IntPtr smethod_29(int int_0, int int_1)
	{
		return (IntPtr)((int_1 << 16) | int_0);
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool PrintWindow(IntPtr intptr_0, IntPtr FDAEC601, uint uint_0);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool GetWindowRect(IntPtr intptr_0, out D797AB36 d797AB36_0);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool IsWindowVisible(IntPtr intptr_0);

	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern bool BitBlt(IntPtr intptr_0, int int_0, int AC037A8F, int int_1, int int_2, IntPtr intptr_1, int int_3, int int_4, CopyPixelOperation copyPixelOperation_0);

	[DllImport("user32.dll")]
	private static extern IntPtr GetDC(IntPtr CF09E498);

	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateCompatibleDC(IntPtr D10ED384);

	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateCompatibleBitmap(IntPtr ACB9AE99, int B014A72E, int B60C242B);

	[DllImport("gdi32.dll")]
	private static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

	[DllImport("gdi32.dll")]
	private static extern bool DeleteObject(IntPtr intptr_0);

	[DllImport("gdi32.dll")]
	private static extern bool DeleteDC(IntPtr EC3D123B);

	[DllImport("user32.dll")]
	private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

	public static Bitmap B3A8D988(IntPtr intptr_0)
	{
		GetWindowRect(intptr_0, out var d797AB36_);
		int num = d797AB36_.BA97BA86 - d797AB36_.int_0;
		int num2 = d797AB36_.int_1 - d797AB36_.D589C13B;
		Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			IntPtr hdc = graphics.GetHdc();
			IntPtr dC = GetDC(intptr_0);
			BitBlt(hdc, 0, 0, num, num2, dC, 0, 0, (CopyPixelOperation)1087111200);
			graphics.ReleaseHdc(hdc);
			ReleaseDC(intptr_0, dC);
		}
		return bitmap;
	}
}
