using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

/// <summary>
/// Bộ sinh mã xác thực 2 lớp (TOTP / 2FA) 100% Offline theo chuẩn RFC 6238 & RFC 4226.
/// Xử lý chuẩn hóa Secret Key, Base32 decoding, hỗ trợ URL otpauth:// và loại bỏ hoàn toàn phụ thuộc mạng bên ngoài.
/// </summary>
public static class LocalTotpEngine
{
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Sinh mã TOTP chuẩn theo RFC 6238 từ Secret Key.
    /// Trả về chuỗi rỗng an toàn nếu key không hợp lệ, không bao giờ ném Exception ra ngoài.
    /// </summary>
    /// <param name="secret">Secret Key Base32 (chuẩn, không chuẩn, hoặc URL otpauth://).</param>
    /// <param name="digits">Số chữ số của mã OTP (mặc định: 6).</param>
    /// <param name="periodSeconds">Chu kỳ hiệu lực tính bằng giây (mặc định: 30s).</param>
    /// <param name="utcNow">Thời điểm UTC tính mã (mặc định: DateTime.UtcNow).</param>
    /// <returns>Chuỗi mã OTP gồm N chữ số hoặc chuỗi rỗng nếu lỗi.</returns>
    public static string GenerateTotp(string secret, int digits = 6, int periodSeconds = 30, DateTime? utcNow = null)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(secret))
                return string.Empty;

            string normalized = NormalizeSecret(secret);
            if (string.IsNullOrEmpty(normalized))
                return string.Empty;

            byte[] key = Base32Decode(normalized);
            if (key == null || key.Length == 0)
                return string.Empty;

            if (digits <= 0 || digits > 9)
                digits = 6;
            if (periodSeconds <= 0)
                periodSeconds = 30;

            DateTime time = utcNow.HasValue ? utcNow.Value.ToUniversalTime() : DateTime.UtcNow;
            long unixSeconds = (long)(time - UnixEpoch).TotalSeconds;
            long timeStep = unixSeconds / periodSeconds;

            byte[] counter = BitConverter.GetBytes(timeStep);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(counter);
            }

            using (var hmac = new HMACSHA1(key))
            {
                byte[] hash = hmac.ComputeHash(counter);
                int offset = hash[hash.Length - 1] & 0x0F;
                int binaryCode = ((hash[offset] & 0x7F) << 24)
                               | ((hash[offset + 1] & 0xFF) << 16)
                               | ((hash[offset + 2] & 0xFF) << 8)
                               | (hash[offset + 3] & 0xFF);

                int modulo = (int)Math.Pow(10, digits);
                int otp = binaryCode % modulo;
                return otp.ToString(new string('0', digits));
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Sinh mã chuẩn theo UtcNow với cơ chế tự động bóc tách key linh hoạt nếu chuỗi đầu vào chứa tạp âm.
    /// </summary>
    /// <param name="secret">Secret Key Base32 hoặc chuỗi chứa secret.</param>
    /// <param name="driftWindows">Số bước trôi thời gian cho phép (dự phòng tương thích).</param>
    /// <returns>Mã OTP chuẩn theo UtcNow hoặc chuỗi rỗng.</returns>
    public static string GenerateWithDriftTolerance(string secret, int driftWindows = 1)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(secret))
                return string.Empty;

            // 1. Thử sinh mã trực tiếp
            string code = GenerateTotp(secret, 6, 30, DateTime.UtcNow);
            if (!string.IsNullOrEmpty(code))
                return code;

            // 2. Thử bóc tách chuỗi con Base32 hợp lệ (từ 16 ký tự trở lên)
            var match = Regex.Match(secret, @"[A-Za-z2-7]{16,}");
            if (match.Success)
            {
                code = GenerateTotp(match.Value, 6, 30, DateTime.UtcNow);
                if (!string.IsNullOrEmpty(code))
                    return code;
            }

            // 3. Thử lọc bỏ toàn bộ ký tự không thuộc bảng mã Base32
            string filtered = Regex.Replace(secret, @"[^A-Za-z2-7]", string.Empty);
            if (filtered.Length >= 16)
            {
                code = GenerateTotp(filtered, 6, 30, DateTime.UtcNow);
                if (!string.IsNullOrEmpty(code))
                    return code;
            }
        }
        catch
        {
        }
        return string.Empty;
    }

    /// <summary>
    /// Trả về số giây còn lại của chu kỳ hiện tại (mặc định chu kỳ 30s).
    /// </summary>
    /// <param name="periodSeconds">Chu kỳ hiệu lực (mặc định: 30s).</param>
    /// <returns>Số giây còn lại trong khoảng [1, periodSeconds].</returns>
    public static int GetSecondsRemaining(int periodSeconds = 30)
    {
        try
        {
            if (periodSeconds <= 0)
                periodSeconds = 30;

            long epoch = (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
            if (epoch < 0)
                epoch = 0;

            int elapsed = (int)(epoch % periodSeconds);
            int remaining = periodSeconds - elapsed;
            return (remaining <= 0) ? periodSeconds : remaining;
        }
        catch
        {
            return 30;
        }
    }

    /// <summary>
    /// Xác thực mã OTP người dùng nhập vào so với Secret Key, hỗ trợ dung sai lệch thời gian (Drift).
    /// </summary>
    /// <param name="secret">Secret Key Base32.</param>
    /// <param name="inputCode">Mã OTP cần kiểm tra.</param>
    /// <param name="driftWindows">Số chu kỳ trước và sau chấp nhận dung sai (mặc định: 1 chu kỳ +-30s).</param>
    /// <returns>True nếu mã khớp, ngược lại False.</returns>
    public static bool ValidateTotp(string secret, string inputCode, int driftWindows = 1)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(inputCode))
                return false;

            string cleanCode = inputCode.Trim();
            if (cleanCode.Length < 6)
                return false;

            DateTime now = DateTime.UtcNow;
            int window = Math.Max(0, driftWindows);

            for (int i = -window; i <= window; i++)
            {
                DateTime checkTime = now.AddSeconds(i * 30);
                string expectedCode = GenerateTotp(secret, cleanCode.Length, 30, checkTime);
                if (!string.IsNullOrEmpty(expectedCode) && string.Equals(expectedCode, cleanCode, StringComparison.Ordinal))
                {
                    return true;
                }
            }
        }
        catch
        {
        }
        return false;
    }

    /// <summary>
    /// Tự động chuẩn hóa Secret Key:
    /// - Hỗ trợ bóc tách Secret Key tự động từ URL otpauth://totp/... hoặc otpauth://hotp/...
    /// - Chấp nhận định dạng Base32 chuẩn và không chuẩn (bỏ khoảng trắng, dấu gạch nối '-', chữ hoa/thường).
    /// - Tự động bù đắp dấu '=' (padding Base32 mod 8) nếu chuỗi thiếu padding.
    /// - Trả về chuỗi rỗng an toàn nếu key không hợp lệ.
    /// </summary>
    /// <param name="secret">Chuỗi bí mật thô.</param>
    /// <returns>Chuỗi Base32 chuẩn hóa có padding mod 8 hoặc rỗng nếu không hợp lệ.</returns>
    public static string NormalizeSecret(string secret)
    {
        if (string.IsNullOrWhiteSpace(secret))
            return string.Empty;

        string cleaned = secret.Trim();

        // 1. Tự động bóc tách từ URL otpauth://
        if (cleaned.StartsWith("otpauth://", StringComparison.OrdinalIgnoreCase) || cleaned.IndexOf("secret=", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            var match = Regex.Match(cleaned, @"(?:[?&]|&amp;|^)secret=([^&#\s]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                cleaned = Uri.UnescapeDataString(match.Groups[1].Value);
            }
            else if (cleaned.StartsWith("otpauth://", StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }
        }

        // 2. Loại bỏ khoảng trắng, tab, newline và dấu gạch nối '-'
        cleaned = Regex.Replace(cleaned, @"[\s\-]+", string.Empty).ToUpperInvariant();

        // 3. Tách padding '=' hiện có để kiểm tra tính hợp lệ của Base32 alphabet
        string unpadded = cleaned.TrimEnd('=');
        if (unpadded.Length == 0)
            return string.Empty;

        // 4. Kiểm tra ký tự thuộc bảng Base32 (RFC 4648: A-Z, 2-7)
        for (int i = 0; i < unpadded.Length; i++)
        {
            char c = unpadded[i];
            if (!((c >= 'A' && c <= 'Z') || (c >= '2' && c <= '7')))
            {
                return string.Empty;
            }
        }

        // 5. Tự động bù đắp dấu '=' (padding Base32 mod 8) nếu thiếu padding
        int remainder = unpadded.Length % 8;
        if (remainder != 0)
        {
            return unpadded.PadRight(unpadded.Length + (8 - remainder), '=');
        }

        return unpadded;
    }

    /// <summary>
    /// Giải mã chuỗi Base32 thành mảng byte an toàn và tốc độ cao.
    /// </summary>
    /// <param name="input">Chuỗi Base32 (có hoặc không có padding '=').</param>
    /// <returns>Mảng byte giải mã hoặc mảng rỗng nếu lỗi.</returns>
    public static byte[] Base32Decode(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return new byte[0];

        try
        {
            string sanitized = input.Trim().TrimEnd('=').ToUpperInvariant();
            if (sanitized.Length == 0)
                return new byte[0];

            List<byte> bytes = new List<byte>((sanitized.Length * 5) / 8);
            int buffer = 0;
            int bitsLeft = 0;

            for (int i = 0; i < sanitized.Length; i++)
            {
                char c = sanitized[i];
                int val;
                if (c >= 'A' && c <= 'Z')
                {
                    val = c - 'A';
                }
                else if (c >= '2' && c <= '7')
                {
                    val = c - '2' + 26;
                }
                else
                {
                    return new byte[0];
                }

                buffer = (buffer << 5) | val;
                bitsLeft += 5;

                if (bitsLeft >= 8)
                {
                    bytes.Add((byte)((buffer >> (bitsLeft - 8)) & 0xFF));
                    bitsLeft -= 8;
                }
            }

            return bytes.ToArray();
        }
        catch
        {
            return new byte[0];
        }
    }
}
