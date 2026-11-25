using System;
using System.IO;
using System.Text.RegularExpressions;

internal static class ProfileSession
{
    public static bool Enabled => C5034B95.smethod_0("configGeneral").method_3("preserveFacebookSessions", true);

    public static string ResolvePath(string root, string uid, string accountId)
    {
        root = Path.GetFullPath(root);
        string fallback = SafeComponent(accountId) ? Path.Combine(root, "account_" + accountId) : null;
        // A profile created before the UID is known must keep its original location.
        if (fallback != null && Directory.Exists(fallback)) return fallback;
        if (SafeComponent(uid) && (Regex.IsMatch(uid, @"\A[0-9]+\z") || Directory.Exists(Path.Combine(root, uid))))
            return Path.Combine(root, uid);
        if (fallback != null) return fallback;
        throw new InvalidOperationException("Tài khoản cần UID hoặc mã dữ liệu hợp lệ để lưu profile riêng.");
    }

    private static bool SafeComponent(string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value.Length <= 120
            && Regex.IsMatch(value, @"\A[a-zA-Z0-9_@-][a-zA-Z0-9_@.\-]*\z")
            && !value.EndsWith(".")
            && !Regex.IsMatch(value, @"\A(CON|PRN|AUX|NUL|COM[0-9]|LPT[0-9])(\.|$)", RegexOptions.IgnoreCase);
    }
}
