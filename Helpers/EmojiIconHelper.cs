using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

public static class EmojiIconHelper
{
	public class EmojiItem
	{
		public string Code { get; set; }
		public string Char { get; set; }
		public string Tooltip { get; set; }
	}

	public static readonly EmojiItem[] Items = new EmojiItem[]
	{
		new EmojiItem { Code = "1f6a8", Char = "🚨", Tooltip = "Cảnh báo (🚨)" },
		new EmojiItem { Code = "274c",  Char = "❌", Tooltip = "Dấu chéo đỏ (❌)" },
		new EmojiItem { Code = "2705",  Char = "✅", Tooltip = "Tích xanh (✅)" },
		new EmojiItem { Code = "1f449", Char = "👉", Tooltip = "Chỉ tay phải (👉)" },
		new EmojiItem { Code = "1f525", Char = "🔥", Tooltip = "Hot / Lửa (🔥)" },
		new EmojiItem { Code = "1f4de", Char = "📞", Tooltip = "Điện thoại / Hotline (📞)" },
		new EmojiItem { Code = "1f310", Char = "🌐", Tooltip = "Website / Toàn cầu (🌐)" },
		new EmojiItem { Code = "1f4cd", Char = "📍", Tooltip = "Địa chỉ / Ghim tròn (📍)" },
		new EmojiItem { Code = "1f4a1", Char = "💡", Tooltip = "Ý tưởng / Bóng đèn (💡)" },
		new EmojiItem { Code = "1f3af", Char = "🎯", Tooltip = "Mục tiêu (🎯)" },
		new EmojiItem { Code = "1f4a5", Char = "💥", Tooltip = "Bùng nổ / Giảm giá (💥)" },
		new EmojiItem { Code = "1f381", Char = "🎁", Tooltip = "Quà tặng (🎁)" },
		new EmojiItem { Code = "1f4b0", Char = "💰", Tooltip = "Tiền / Doanh thu (💰)" },
		new EmojiItem { Code = "1f680", Char = "🚀", Tooltip = "Tên lửa / Tăng tốc (🚀)" },
		new EmojiItem { Code = "1f4bc", Char = "💼", Tooltip = "Doanh nghiệp / Công việc (💼)" },
		new EmojiItem { Code = "1f4e9", Char = "📩", Tooltip = "Tin nhắn / Email (📩)" },
		new EmojiItem { Code = "1f4cc", Char = "📌", Tooltip = "Ghim chú ý (📌)" },
		new EmojiItem { Code = "1f389", Char = "🎉", Tooltip = "Ưu đãi / Chúc mừng (🎉)" },
		new EmojiItem { Code = "2b50",  Char = "⭐", Tooltip = "Ngôi sao (⭐)" },
		new EmojiItem { Code = "26a0",  Char = "⚠️", Tooltip = "Lưu ý (⚠️)" },
		new EmojiItem { Code = "2764",  Char = "❤️", Tooltip = "Trái tim (❤️)" },
		new EmojiItem { Code = "1f44d", Char = "👍", Tooltip = "Thích / Tốt (👍)" }
	};

	private static readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
	private static readonly object _lock = new object();

	public static Image GetEmojiImage(string code, int targetSize = 22)
	{
		string key = code + "_" + targetSize;
		lock (_lock)
		{
			if (_imageCache.ContainsKey(key))
				return _imageCache[key];

			string[] possiblePaths = new string[]
			{
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "emoji", code + ".png"),
				Path.Combine(Application.StartupPath, "images", "emoji", code + ".png"),
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "images", "emoji", code + ".png"),
				Path.Combine("images", "emoji", code + ".png")
			};

			foreach (string path in possiblePaths)
			{
				if (File.Exists(path))
				{
					try
					{
						using (Image orig = Image.FromFile(path))
						{
							Bitmap res = new Bitmap(targetSize, targetSize);
							using (Graphics g = Graphics.FromImage(res))
							{
								g.InterpolationMode = InterpolationMode.HighQualityBicubic;
								g.SmoothingMode = SmoothingMode.HighQuality;
								g.PixelOffsetMode = PixelOffsetMode.HighQuality;
								g.Clear(Color.Transparent);
								g.DrawImage(orig, 0, 0, targetSize, targetSize);
							}
							_imageCache[key] = res;
							return res;
						}
					}
					catch { }
				}
			}
		}
		return null;
	}

	public static void PopulateEmojiToolbar(FlowLayoutPanel panel, Action<string> onInsert, ToolTip toolTip, int btnSize = 32, int iconSize = 22)
	{
		panel.SuspendLayout();
		panel.Controls.Clear();
		foreach (var item in Items)
		{
			Button btn = new Button
			{
				Size = new Size(btnSize, btnSize),
				Margin = new Padding(2),
				FlatStyle = FlatStyle.Flat,
				Cursor = Cursors.Hand,
				BackColor = Color.White
			};
			btn.FlatAppearance.BorderColor = Color.FromArgb(220, 225, 230);
			btn.FlatAppearance.BorderSize = 1;
			btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 245, 255);
			btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(215, 230, 255);

			Image img = GetEmojiImage(item.Code, iconSize);
			if (img != null)
			{
				btn.Image = img;
				btn.ImageAlign = ContentAlignment.MiddleCenter;
			}
			else
			{
				btn.Text = item.Char;
				btn.Font = new Font("Segoe UI Emoji", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
			}

			if (toolTip != null)
			{
				toolTip.SetToolTip(btn, item.Tooltip + " - Bấm để chèn");
			}

			string ch = item.Char;
			btn.Click += (s, e) => onInsert(ch + " ");
			panel.Controls.Add(btn);
		}
		panel.ResumeLayout();
	}
}
