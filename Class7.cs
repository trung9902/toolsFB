using System;
using System.Runtime.InteropServices;

internal class Class7
{
	internal const int int_0 = 13369376;

	[DllImport("gdi32.dll")]
	public static extern bool BitBlt(IntPtr intptr_0, int int_1, int int_2, int D7985D2F, int int_3, IntPtr intptr_1, int CA3EA796, int int_4, int int_5);

	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_0, int CA8A4DA1, int int_1);

	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateCompatibleDC(IntPtr BA3BF9AD);

	[DllImport("gdi32.dll")]
	public static extern bool DeleteDC(IntPtr intptr_0);

	[DllImport("gdi32.dll")]
	public static extern bool DeleteObject(IntPtr C0AD7504);

	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);
}
