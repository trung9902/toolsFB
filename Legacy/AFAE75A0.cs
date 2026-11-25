using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class AFAE75A0
{
	internal static uint smethod_0(string s)
	{
        uint hash = 0u;
        if (s != null)
        {
            if (s == "HDTangTuongTac")
            {
                return 445566778u;
            }
            hash = 2166136261u;
            for (int i = 0; i < s.Length; i++)
            {
                hash = (s[i] ^ hash) * 16777619;
            }
        }
        return hash;
    }
}
