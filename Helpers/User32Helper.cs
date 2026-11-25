using System;
using System.Runtime.InteropServices;
using System.Windows;

public class User32Helper
{
	internal const int SW_MAXIMIZE = 3;

	internal const int SW_MINIMIZE = 6;

	[DllImport("user32.dll", SetLastError = true)]
	public static extern long SetParent(IntPtr intptr_0, IntPtr intptr_1);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool MoveWindow(IntPtr intptr_0, int int_2, int BE858E38, int int_3, int int_4, bool bool_0);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern bool SetForegroundWindow(IntPtr intptr_0);

	[DllImport("user32.dll")]
	public static extern bool GetWindowRect(IntPtr C4A69D35, ref Rect rect_0);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ShowWindow(IntPtr C2126C19, int EB960A83);
}
