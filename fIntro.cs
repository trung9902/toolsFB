using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public class fIntro : Form
{
	[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	[DllImport("user32.dll")]
	private static extern bool ReleaseCapture();

	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	private System.Windows.Forms.Timer animTimer;
	private float displayProgress = 0f;
	private float targetProgress = 10f;
	private string currentStatus = "Đang khởi động LushCare Core...";
	private Image logoImage = null;
	private bool isTaskFinished = false;
	private bool isFadeOut = false;
	private string licenseResult = "";
	private Exception initException = null;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams cp = base.CreateParams;
			cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
			return cp;
		}
	}

	public fIntro()
	{
		base.SuspendLayout();
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(580, 350);
		base.FormBorderStyle = FormBorderStyle.None;
		base.StartPosition = FormStartPosition.CenterScreen;
		base.ShowInTaskbar = false;
		base.Opacity = 0.0;
		this.BackColor = Color.White;
		this.DoubleBuffered = true;
		base.Icon = Class155.D596C6A5;
		this.Text = "LushCare Pro";

		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

		try
		{
			string iconPath = Path.Combine(Commom.smethod_95(), "icons", "128x128.png");
			if (File.Exists(iconPath))
			{
				logoImage = Image.FromFile(iconPath);
			}
			else if (Class155.D596C6A5 != null)
			{
				logoImage = Class155.D596C6A5.ToBitmap();
			}
		}
		catch { }

		animTimer = new System.Windows.Forms.Timer();
		animTimer.Interval = 16; // ~60fps
		animTimer.Tick += AnimTimer_Tick;

		this.MouseDown += FIntro_MouseDown;
		base.Load += FIntro_Load;
		base.ResumeLayout(false);
	}

	private void FIntro_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0xA1, 0x2, 0);
		}
	}

	private void ApplyRoundedCorners()
	{
		try
		{
			IntPtr hRgn = CreateRoundRectRgn(0, 0, Width + 1, Height + 1, 20, 20);
			base.Region = Region.FromHrgn(hRgn);
		}
		catch { }
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		ApplyRoundedCorners();
	}

	private void FIntro_Load(object sender, EventArgs e)
	{
		ApplyRoundedCorners();
		animTimer.Start();

		// Start background initialization thread
		Thread initThread = new Thread(RunBackgroundInitialization)
		{
			IsBackground = true
		};
		initThread.Start();
	}

	private void RunBackgroundInitialization()
	{
		try
		{
			File.AppendAllText("startup_log.txt", "fIntro: Starting LushCare background init...\r\n");

			// Stage 1: Core setup
			Thread.Sleep(150);
			targetProgress = 25f;
			currentStatus = "Khởi tạo môi trường & kết nối dữ liệu...";

			// Stage 2: License verification
			Thread.Sleep(200);
			targetProgress = 45f;
			currentStatus = "Kiểm tra bản quyền hệ thống...";
			licenseResult = Commom.checkLicense2("", "");
			File.AppendAllText("startup_log.txt", "fIntro: License result = " + licenseResult + "\r\n");

			// Stage 3: ChromeDriver sync
			Thread.Sleep(200);
			targetProgress = 75f;
			currentStatus = "Đồng bộ trình điều khiển ChromeDriver...";
			try
			{
				ChromeDriverUpdater.EnsureMatchingChromeDriver(Commom.smethod_95());
			}
			catch (Exception exSync)
			{
				File.AppendAllText("startup_log.txt", "fIntro: Driver sync note: " + exSync.Message + "\r\n");
			}

			// Stage 4: Ready
			Thread.Sleep(200);
			targetProgress = 92f;
			currentStatus = "Nạp cấu hình & tài nguyên giao diện...";

			Thread.Sleep(250);
			targetProgress = 100f;
			currentStatus = "Sẵn sàng khởi chạy!";
			Thread.Sleep(200);

			isTaskFinished = true;
		}
		catch (Exception ex)
		{
			File.AppendAllText("startup_log.txt", "fIntro Background Exception: " + ex.ToString() + "\r\n");
			initException = ex;
			isTaskFinished = true;
		}
	}

	private void AnimTimer_Tick(object sender, EventArgs e)
	{
		// Fade In
		if (!isFadeOut)
		{
			if (base.Opacity < 1.0)
			{
				base.Opacity = Math.Min(1.0, base.Opacity + 0.05);
			}
		}

		// Smooth Progress interpolation (Lerp)
		if (displayProgress < targetProgress)
		{
			float diff = targetProgress - displayProgress;
			displayProgress += Math.Max(0.5f, diff * 0.12f);
			if (displayProgress > targetProgress)
			{
				displayProgress = targetProgress;
			}
		}

		// Check if initialization finished and reached 100%
		if (isTaskFinished && displayProgress >= 99.5f)
		{
			displayProgress = 100f;
			isFadeOut = true;
		}

		// Fade Out when done
		if (isFadeOut)
		{
			base.Opacity -= 0.08;
			if (base.Opacity <= 0.02)
			{
				animTimer.Stop();
				this.Hide();
				LaunchApplication();
				return;
			}
		}

		this.Invalidate();
	}

	private void LaunchApplication()
	{
		try
		{
			if (initException != null)
			{
				MsBoxHelper.Show("Có lỗi xảy ra trong quá trình khởi động: " + initException.Message, 2);
			}

			if (licenseResult.StartsWith("0|"))
			{
				File.AppendAllText("startup_log.txt", "fIntro: Opening fActive dialog...\r\n");
				new fActive(licenseResult.Substring(2)).ShowDialog();
				return;
			}

			string activeKey = licenseResult.Length > 2 ? licenseResult.Substring(2) : "";
			try
			{
				File.AppendAllText("startup_log.txt", "fIntro: Launching fMain(" + activeKey + ")...\r\n");
				new fMain(activeKey).ShowDialog();
				File.AppendAllText("startup_log.txt", "fIntro: fMain closed.\r\n");
			}
			catch (Exception ex)
			{
				File.AppendAllText("startup_log.txt", "fIntro fMain Exception: " + ex.ToString() + "\r\n");
				MsBoxHelper.Show(ex.ToString(), 2);
				new fActive("").ShowDialog();
			}

			try
			{
				File.AppendAllText("startup_log.txt", "fIntro: Exiting process.\r\n");
				Environment.Exit(0);
			}
			catch
			{
				Application.Exit();
			}
		}
		catch (Exception exOuter)
		{
			File.AppendAllText("startup_log.txt", "fIntro Launch Outer Exception: " + exOuter.ToString() + "\r\n");
			Commom.smethod_57(null, exOuter, "Run Program");
			Close();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics g = e.Graphics;
		g.SmoothingMode = SmoothingMode.AntiAlias;
		g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		g.InterpolationMode = InterpolationMode.HighQualityBicubic;

		int w = this.Width;
		int h = this.Height;

		// 1. Background gradient (Clean White to Soft Slate)
		using (LinearGradientBrush bgBrush = new LinearGradientBrush(new Rectangle(0, 0, w, h), Color.FromArgb(255, 255, 255), Color.FromArgb(248, 250, 252), LinearGradientMode.Vertical))
		{
			g.FillRectangle(bgBrush, 0, 0, w, h);
		}

		// 2. Ambient top glow effect (Soft Blue)
		using (LinearGradientBrush glowBrush = new LinearGradientBrush(new Rectangle(0, 0, w, 140), Color.FromArgb(25, 59, 130, 246), Color.FromArgb(0, 59, 130, 246), LinearGradientMode.Vertical))
		{
			g.FillRectangle(glowBrush, 0, 0, w, 140);
		}

		// 3. Subtle Card Border
		using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
		{
			using (GraphicsPath bPath = GetRoundedRectanglePath(new Rectangle(0, 0, w - 1, h - 1), 20))
			{
				g.DrawPath(borderPen, bPath);
			}
		}

		// 4. Logo / Icon
		int iconSize = 64;
		int iconX = (w - iconSize) / 2;
		int iconY = 32;

		// Ambient halo ring behind icon
		using (SolidBrush haloBrush = new SolidBrush(Color.FromArgb(15, 59, 130, 246)))
		{
			g.FillEllipse(haloBrush, iconX - 10, iconY - 10, iconSize + 20, iconSize + 20);
		}
		using (Pen haloPen = new Pen(Color.FromArgb(40, 59, 130, 246), 1.5f))
		{
			g.DrawEllipse(haloPen, iconX - 10, iconY - 10, iconSize + 20, iconSize + 20);
		}

		if (logoImage != null)
		{
			g.DrawImage(logoImage, iconX, iconY, iconSize, iconSize);
		}

		// 5. Title: LUSHCARE PRO
		using (Font titleFont = new Font("Segoe UI", 20f, FontStyle.Bold))
		{
			string title = "LUSHCARE PRO";
			SizeF titleSize = g.MeasureString(title, titleFont);
			float titleX = (w - titleSize.Width) / 2f;
			using (SolidBrush titleBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
			{
				g.DrawString(title, titleFont, titleBrush, titleX, 114);
			}
		}

		// 6. Subtitle
		using (Font subFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
		{
			string subtitle = "Facebook Multi-Account Automation Platform";
			SizeF subSize = g.MeasureString(subtitle, subFont);
			float subX = (w - subSize.Width) / 2f;
			using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
			{
				g.DrawString(subtitle, subFont, subBrush, subX, 154);
			}
		}

		// 7. Version Pill Badge
		string badgeText = "v26.01 • ULTIMATE";
		using (Font badgeFont = new Font("Segoe UI", 8.25f, FontStyle.Bold))
		{
			SizeF badgeSize = g.MeasureString(badgeText, badgeFont);
			int badgeW = (int)badgeSize.Width + 20;
			int badgeH = (int)badgeSize.Height + 7;
			int badgeX = (w - badgeW) / 2;
			int badgeY = 184;

			using (GraphicsPath badgePath = GetRoundedRectanglePath(new Rectangle(badgeX, badgeY, badgeW, badgeH), badgeH / 2))
			{
				using (SolidBrush badgeBg = new SolidBrush(Color.FromArgb(241, 245, 249)))
				{
					g.FillPath(badgeBg, badgePath);
				}
				using (Pen badgePen = new Pen(Color.FromArgb(59, 130, 246), 1f))
				{
					g.DrawPath(badgePen, badgePath);
				}
			}
			using (SolidBrush badgeFg = new SolidBrush(Color.FromArgb(59, 130, 246)))
			{
				g.DrawString(badgeText, badgeFont, badgeFg, badgeX + 10, badgeY + 3.5f);
			}
		}

		// 8. Progress Bar Section
		int barX = 46;
		int barW = w - barX * 2;
		int barY = 254;
		int barH = 8;

		// Status text & Percentage
		using (Font statusFont = new Font("Segoe UI", 9.25f, FontStyle.Regular))
		using (Font pctFont = new Font("Segoe UI", 9.25f, FontStyle.Bold))
		{
			using (SolidBrush statusBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
			{
				g.DrawString(currentStatus, statusFont, statusBrush, barX, barY - 24);
			}

			string pctStr = ((int)displayProgress).ToString() + "%";
			SizeF pctSize = g.MeasureString(pctStr, pctFont);
			using (SolidBrush pctBrush = new SolidBrush(Color.FromArgb(59, 130, 246)))
			{
				g.DrawString(pctStr, pctFont, pctBrush, barX + barW - pctSize.Width, barY - 24);
			}
		}

		// Track (background capsule)
		using (GraphicsPath trackPath = GetRoundedRectanglePath(new Rectangle(barX, barY, barW, barH), barH / 2))
		{
			using (SolidBrush trackBrush = new SolidBrush(Color.FromArgb(226, 232, 240)))
			{
				g.FillPath(trackBrush, trackPath);
			}
			using (Pen trackPen = new Pen(Color.FromArgb(203, 213, 225), 1f))
			{
				g.DrawPath(trackPen, trackPath);
			}
		}

		// Progress Fill (Blue to Indigo gradient)
		int fillW = (int)(barW * (displayProgress / 100f));
		if (fillW > 7)
		{
			using (GraphicsPath fillPath = GetRoundedRectanglePath(new Rectangle(barX, barY, fillW, barH), barH / 2))
			{
				using (LinearGradientBrush fillBrush = new LinearGradientBrush(new Rectangle(barX, barY, fillW, barH), Color.FromArgb(59, 130, 246), Color.FromArgb(99, 102, 241), LinearGradientMode.Horizontal))
				{
					g.FillPath(fillBrush, fillPath);
				}
			}
		}

		// 9. Footer
		using (Font footFont = new Font("Segoe UI", 8.25f, FontStyle.Regular))
		{
			using (SolidBrush footBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
			{
				g.DrawString("LushCare Automation Engine • High-Performance", footFont, footBrush, barX, h - 32);
				string copy = "© 2026 LushCare Inc.";
				SizeF copySize = g.MeasureString(copy, footFont);
				g.DrawString(copy, footFont, footBrush, barX + barW - copySize.Width, h - 32);
			}
		}
	}

	private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
	{
		GraphicsPath path = new GraphicsPath();
		int diameter = radius * 2;
		if (diameter > rect.Height) diameter = rect.Height;
		if (diameter > rect.Width) diameter = rect.Width;
		Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

		// Top-left
		path.AddArc(arcRect, 180, 90);

		// Top-right
		arcRect.X = rect.Right - diameter;
		path.AddArc(arcRect, 270, 90);

		// Bottom-right
		arcRect.Y = rect.Bottom - diameter;
		path.AddArc(arcRect, 0, 90);

		// Bottom-left
		arcRect.X = rect.Left;
		path.AddArc(arcRect, 90, 90);

		path.CloseFigure();
		return path;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (animTimer != null)
			{
				animTimer.Dispose();
			}
			if (logoImage != null)
			{
				logoImage.Dispose();
			}
		}
		base.Dispose(disposing);
	}
}
