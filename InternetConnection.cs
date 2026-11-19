using System.Runtime.InteropServices;

internal class InternetConnection
{
	[DllImport("wininet.dll")]
	private static extern bool InternetGetConnectedState(out int F835F288, int int_0);

	public static bool smethod_0()
	{
		int F835F;
		return InternetGetConnectedState(out F835F, 0);
	}
}
