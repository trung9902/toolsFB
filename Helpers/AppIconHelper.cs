using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

public static class AppIconHelper
{
    private static readonly Dictionary<string, Bitmap> _iconCache = new Dictionary<string, Bitmap>(StringComparer.OrdinalIgnoreCase);
    private static readonly object _lock = new object();

    public static Bitmap GetIcon(string iconName, int width = 16, int height = 16)
    {
        string key = $"{iconName}_{width}_{height}";
        lock (_lock)
        {
            if (_iconCache.TryGetValue(key, out var cached) && cached != null)
            {
                return cached;
            }

            string[] searchPaths = new string[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons_app", iconName),
                Path.Combine(Application.StartupPath, "icons_app", iconName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", iconName),
                Path.Combine(Application.StartupPath, "icons", iconName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", iconName),
                Path.Combine(Application.StartupPath, "images", iconName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "icons_app", iconName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "icons", iconName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "images", iconName),
                @"D:\LushCareGlobal\icons_app\" + iconName,
                @"D:\LushCareGlobal\icons\" + iconName,
                @"D:\LushCareGlobal\images\" + iconName,
                @"D:\MaxCare_v25.05.08\icons_app\" + iconName,
                @"E:\LushCare_Global\icons_app\" + iconName,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Hermes\composer-images\" + iconName)
            };

            string foundPath = null;
            foreach (var path in searchPaths)
            {
                if (File.Exists(path))
                {
                    foundPath = path;
                    break;
                }
            }

            if (foundPath != null)
            {
                try
                {
                    using (var src = new Bitmap(foundPath))
                    {
                        var dest = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                        using (var g = Graphics.FromImage(dest))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.DrawImage(src, 0, 0, width, height);
                        }
                        _iconCache[key] = dest;
                        return dest;
                    }
                }
                catch { }
            }

            return null;
        }
    }

    public static void SetIcon(Form form, string iconName = "app_logo.png")
    {
        if (form == null) return;
        try
        {
            Bitmap bmp = GetIcon(iconName, 32, 32) ?? GetIcon("logo.ico", 32, 32) ?? GetIcon("logo.png", 32, 32);
            if (bmp != null)
            {
                IntPtr hIcon = bmp.GetHicon();
                form.Icon = Icon.FromHandle(hIcon);
            }
        }
        catch { }
    }
}
