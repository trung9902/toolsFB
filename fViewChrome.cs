using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

public class fViewChrome : Form
{
	[CompilerGenerated]
	private sealed class Class82
	{
		internal IntPtr intptr_0;

		internal fViewChrome fViewChrome_0;

		internal int AA1CC799;

		internal int DF8B2590;

		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal void method_0()
		{
			User32Helper.SetParent(intptr_0, (from Control control_0 in fViewChrome_0.panelListDevice.Controls
				where control_0.Tag.Equals(AA1CC799)
				select control_0).FirstOrDefault().Handle);
			User32Helper.MoveWindow(intptr_0, DF8B2590, int_0, int_1, int_2, bool_0: true);
		}

		internal bool method_1(Control control_0)
		{
			return control_0.Tag.Equals(AA1CC799);
		}
	}

	[CompilerGenerated]
	private sealed class DD024185
	{
		internal fViewChrome FB864CB9;

		internal Control F402A093;

		internal void method_0()
		{
			FB864CB9.panelListDevice.Controls.Remove(F402A093);
		}
	}

	[CompilerGenerated]
	private sealed class Class83
	{
		internal fViewChrome fViewChrome_0;

		internal Panel FB156783;

		internal void CC868C2F()
		{
			fViewChrome_0.panelListDevice.Controls.Add(FB156783);
		}
	}

	[CompilerGenerated]
	private sealed class B52E7B8E
	{
		internal fViewChrome AB3C2028;

		internal int D8A2529C;

		internal void E8AC8B26()
		{
			AB3C2028.Text = AB3C2028.Text.Replace(Regex.Match(AB3C2028.Text, "\\((.*?)\\)").Value, "(" + D8A2529C + ")");
		}
	}

	internal fMain F5140524 = null;

	internal static fViewChrome fViewChrome_0;

	internal IContainer AD3B460C = null;

	internal FlowLayoutPanel panelListDevice;

	public bool IsPhoneView => C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView");

	public fViewChrome()
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		fViewChrome_0 = this;
		if (IsPhoneView)
		{
			Text = "Android Phone View (0)";
			BackColor = Color.FromArgb(14, 16, 20);
			panelListDevice.BackColor = Color.FromArgb(14, 16, 20);
		}
		Language.CD21F0A9(this);
	}

	public fViewChrome(fMain fMain_0)
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		fViewChrome_0 = this;
		F5140524 = fMain_0;
		if (IsPhoneView)
		{
			Text = "Android Phone View (0)";
			BackColor = Color.FromArgb(14, 16, 20);
			panelListDevice.BackColor = Color.FromArgb(14, 16, 20);
		}
		Language.CD21F0A9(this);
	}

	public void method_0(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3 = -10, int AD020A96 = -30)
	{
		Invoke((MethodInvoker)delegate
		{
			Control parentPanel = (from Control control_0 in panelListDevice.Controls
				where control_0.Tag != null && control_0.Tag.Equals(int_0)
				select control_0).FirstOrDefault();
			if (parentPanel != null)
			{
				if (parentPanel is PhoneDeviceFrame phone)
				{
					phone.SetChromeHandle(intptr_0);
					User32Helper.SetParent(intptr_0, phone.ScreenPanel.Handle);
					User32Helper.MoveWindow(intptr_0, int_3, AD020A96, int_1, int_2, bool_0: true);
				}
				else
				{
					Control screenPanel = parentPanel.Controls["screen_" + int_0] ?? parentPanel;
					screenPanel.Tag = intptr_0;
					User32Helper.SetParent(intptr_0, screenPanel.Handle);
					User32Helper.MoveWindow(intptr_0, int_3, AD020A96, int_1, int_2, bool_0: true);
				}
			}
		});
		method_4();
	}

	public void method_1(int int_0)
	{
		Control F402A93 = panelListDevice.Controls["dv" + int_0];
		if (F402A93 != null)
		{
			panelListDevice.Invoke((MethodInvoker)delegate
			{
				try
				{
					panelListDevice.Controls.Remove(F402A93);
					F402A93.Dispose();
				}
				catch {}
			});
			method_4();
		}
	}

	public void method_2(int int_0, int int_1, int int_2)
	{
		if (IsPhoneView)
		{
			PhoneDeviceFrame phoneFrame = new PhoneDeviceFrame(int_0, int_1, int_2);
			Invoke((MethodInvoker)delegate
			{
				panelListDevice.Controls.Add(phoneFrame);
			});
		}
		else
		{
			Panel FB156783 = new Panel();
			FB156783.Name = "dv" + int_0;
			FB156783.Tag = int_0;
			FB156783.Size = new Size(int_1, int_2);
			FB156783.BackColor = Color.White;
			FB156783.BorderStyle = BorderStyle.FixedSingle;
			Invoke((MethodInvoker)delegate
			{
				panelListDevice.Controls.Add(FB156783);
			});
		}
		for (int i = 0; i < 10; i++)
		{
			if (panelListDevice.Controls["dv" + int_0] != null)
			{
				break;
			}
			Thread.Sleep(1000);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		method_1(Convert.ToInt32((sender as PictureBox).Name.Replace("pic", "")));
	}

	public void method_4()
	{
		int D8A2529C = panelListDevice.Controls.Count;
		Invoke((MethodInvoker)delegate
		{
			string prefix = IsPhoneView ? "Android Phone View" : "Form View Chrome";
			if (Text.Contains("("))
			{
				Text = Regex.Replace(Text, @"\((.*?)\)", "(" + D8A2529C + ")");
				if (IsPhoneView && !Text.StartsWith("Android Phone View"))
				{
					Text = "Android Phone View (" + D8A2529C + ")";
				}
			}
			else
			{
				Text = prefix + " (" + D8A2529C + ")";
			}
		});
		if (F5140524 != null)
		{
			F5140524.method_145(D8A2529C);
		}
	}

	protected override void Dispose(bool D111BF05)
	{
		if (D111BF05 && AD3B460C != null)
		{
			AD3B460C.Dispose();
		}
		base.Dispose(D111BF05);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fViewChrome));
		panelListDevice = new System.Windows.Forms.FlowLayoutPanel();
		SuspendLayout();
		panelListDevice.AutoScroll = true;
		panelListDevice.BackColor = System.Drawing.Color.White;
		panelListDevice.Dock = System.Windows.Forms.DockStyle.Fill;
		panelListDevice.Location = new System.Drawing.Point(0, 0);
		panelListDevice.Name = "panelListDevice";
		panelListDevice.Padding = new System.Windows.Forms.Padding(10);
		panelListDevice.Size = new System.Drawing.Size(933, 554);
		panelListDevice.TabIndex = 1;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(933, 554);
		base.Controls.Add(panelListDevice);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fViewChrome";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Form View Chrome (0)";
		ResumeLayout(false);
	}
}

public class PhoneDeviceFrame : Panel
{
	private int _deviceId;
	private IntPtr _chromeHandle = IntPtr.Zero;
	private string _timeStr = DateTime.Now.ToString("HH:mm");
	private System.Windows.Forms.Timer _timer;
	private int _hoveredNavButton = 0; // 0 = none, 1 = back, 2 = home, 3 = recents, 4 = island

	public Panel ScreenPanel { get; private set; }

	public PhoneDeviceFrame(int deviceId, int screenWidth, int screenHeight)
	{
		_deviceId = deviceId;
		Name = "dv" + deviceId;
		Tag = deviceId;

		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
		DoubleBuffered = true;

		int outerWidth = screenWidth + 16;
		int outerHeight = screenHeight + 72; // 36 top + 36 bottom

		Size = new Size(outerWidth, outerHeight);
		BackColor = Color.FromArgb(20, 22, 28);
		Margin = new Padding(12, 10, 12, 10);
		Padding = new Padding(0);

		ScreenPanel = new Panel();
		ScreenPanel.Name = "screen_" + deviceId;
		ScreenPanel.Tag = deviceId;
		ScreenPanel.Location = new Point(8, 36);
		ScreenPanel.Size = new Size(screenWidth, screenHeight);
		ScreenPanel.BackColor = Color.Black;
		ScreenPanel.BorderStyle = BorderStyle.None;
		Controls.Add(ScreenPanel);

		_timer = new System.Windows.Forms.Timer();
		_timer.Interval = 30000;
		_timer.Tick += (s, e) =>
		{
			_timeStr = DateTime.Now.ToString("HH:mm");
			Invalidate(new Rectangle(0, 0, Width, 36));
		};
		_timer.Start();

		UpdateRegion();
	}

	public void SetChromeHandle(IntPtr handle)
	{
		_chromeHandle = handle;
		ScreenPanel.Tag = handle;
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		UpdateRegion();
	}

	private void UpdateRegion()
	{
		try
		{
			if (Width > 30 && Height > 30)
			{
				using (GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, Width, Height), 20))
				{
					Region = new Region(path);
				}
			}
		}
		catch {}
	}

	public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
	{
		GraphicsPath path = new GraphicsPath();
		int d = radius * 2;
		if (d > rect.Width) d = rect.Width;
		if (d > rect.Height) d = rect.Height;

		path.AddArc(rect.X, rect.Y, d, d, 180, 90);
		path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
		path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
		path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
		path.CloseFigure();
		return path;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		int cx = Width / 2;
		int newHover = 0;

		// Bottom navigation bar buttons
		if (e.Y >= Height - 36)
		{
			if (e.X >= cx - 75 && e.X <= cx - 35) newHover = 1; // Back
			else if (e.X >= cx - 20 && e.X <= cx + 20) newHover = 2; // Home
			else if (e.X >= cx + 35 && e.X <= cx + 75) newHover = 3; // Recents
		}
		// Top Dynamic Island
		else if (e.Y <= 30 && Math.Abs(e.X - cx) <= 55)
		{
			newHover = 4;
		}

		if (newHover != _hoveredNavButton)
		{
			_hoveredNavButton = newHover;
			Cursor = (newHover > 0) ? Cursors.Hand : Cursors.Default;
			Invalidate();
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		if (_hoveredNavButton != 0)
		{
			_hoveredNavButton = 0;
			Cursor = Cursors.Default;
			Invalidate();
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left)
		{
			if (_hoveredNavButton == 1) // Back
			{
				if (_chromeHandle != IntPtr.Zero)
				{
					try
					{
						User32Helper.SetForegroundWindow(_chromeHandle);
						SendKeys.SendWait("%{LEFT}");
					}
					catch {}
				}
			}
			else if (_hoveredNavButton == 2 || _hoveredNavButton == 3 || _hoveredNavButton == 4) // Home, Recents, Island
			{
				if (_chromeHandle != IntPtr.Zero)
				{
					try
					{
						User32Helper.SetForegroundWindow(_chromeHandle);
					}
					catch {}
				}
			}
		}
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		base.OnPaint(pe);
		Graphics g = pe.Graphics;
		g.SmoothingMode = SmoothingMode.AntiAlias;
		g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

		int w = Width;
		int h = Height;
		int cx = w / 2;

		// 1. Phone Body Chassis & Metallic Edge Rim
		using (GraphicsPath outerPath = GetRoundedPath(new Rectangle(0, 0, w - 1, h - 1), 20))
		{
			using (SolidBrush bodyBrush = new SolidBrush(Color.FromArgb(20, 22, 28)))
			{
				g.FillPath(bodyBrush, outerPath);
			}
			// Outer chamfer metallic rim (Titanium Slate)
			using (Pen rimPen = new Pen(Color.FromArgb(75, 82, 98), 1.75f))
			{
				g.DrawPath(rimPen, outerPath);
			}
			// Inner bezel accent
			using (GraphicsPath innerPath = GetRoundedPath(new Rectangle(2, 2, w - 5, h - 5), 18))
			using (Pen innerPen = new Pen(Color.FromArgb(38, 42, 52), 1f))
			{
				g.DrawPath(innerPen, innerPath);
			}
		}

		// 2. Physical Side Button Notches
		using (SolidBrush btnBrush = new SolidBrush(Color.FromArgb(90, 98, 115)))
		{
			// Left Volume Buttons
			g.FillRectangle(btnBrush, 0, 70, 2, 24);
			g.FillRectangle(btnBrush, 0, 102, 2, 24);
			// Right Power Button
			g.FillRectangle(btnBrush, w - 2, 85, 2, 32);
		}

		// 3. Top Ear Speaker Slit
		using (SolidBrush spkBrush = new SolidBrush(Color.FromArgb(45, 48, 58)))
		{
			g.FillRectangle(spkBrush, cx - 20, 5, 40, 3);
		}

		// 4. Dynamic Island / Punch Hole Pill (Center)
		int islandW = Math.Min(110, Math.Max(76, w / 3));
		Rectangle islandRect = new Rectangle(cx - islandW / 2, 10, islandW, 18);
		using (GraphicsPath islandPath = GetRoundedPath(islandRect, 9))
		{
			using (SolidBrush islandBrush = new SolidBrush(Color.FromArgb(8, 10, 14)))
			{
				g.FillPath(islandBrush, islandPath);
			}
			if (_hoveredNavButton == 4)
			{
				using (Pen glowPen = new Pen(Color.FromArgb(80, 120, 200), 1f))
				{
					g.DrawPath(glowPen, islandPath);
				}
			}
		}
		// Camera lens inside island
		using (SolidBrush camBrush = new SolidBrush(Color.FromArgb(16, 20, 28)))
		using (Pen camRing = new Pen(Color.FromArgb(40, 45, 58), 1f))
		{
			g.FillEllipse(camBrush, islandRect.Left + 7, 14, 10, 10);
			g.DrawEllipse(camRing, islandRect.Left + 7, 14, 10, 10);
		}
		using (SolidBrush reflexBrush = new SolidBrush(Color.FromArgb(55, 95, 175)))
		{
			g.FillEllipse(reflexBrush, islandRect.Left + 10, 17, 3, 3);
		}
		// Device badge text inside island
		using (Font islandFont = new Font("Segoe UI", 7.5f, FontStyle.Bold))
		using (SolidBrush islandTextBrush = new SolidBrush(Color.FromArgb(215, 225, 240)))
		{
			g.DrawString("DEV #" + (_deviceId + 1), islandFont, islandTextBrush, islandRect.Left + 22, 12);
		}

		// 5. Status Bar - Left (Time)
		using (Font timeFont = new Font("Segoe UI", 8.25f, FontStyle.Bold))
		using (SolidBrush timeBrush = new SolidBrush(Color.FromArgb(230, 235, 245)))
		{
			g.DrawString(_timeStr, timeFont, timeBrush, 12, 11);
		}

		// 6. Status Bar - Right (5G & Battery)
		int rightX = w - 14;
		// Battery
		int battW = 18;
		int battH = 9;
		int battX = rightX - battW;
		int battY = 14;
		using (Pen battPen = new Pen(Color.FromArgb(180, 188, 200), 1f))
		{
			g.DrawRectangle(battPen, battX, battY, battW, battH);
		}
		using (SolidBrush tipBrush = new SolidBrush(Color.FromArgb(180, 188, 200)))
		{
			g.FillRectangle(tipBrush, battX + battW, battY + 2, 2, 5);
		}
		using (SolidBrush chargeBrush = new SolidBrush(Color.FromArgb(46, 204, 113)))
		{
			g.FillRectangle(chargeBrush, battX + 2, battY + 2, 13, 6);
		}
		// 5G text
		using (Font netFont = new Font("Segoe UI", 7f, FontStyle.Bold))
		using (SolidBrush netBrush = new SolidBrush(Color.FromArgb(170, 180, 195)))
		{
			g.DrawString("5G", netFont, netBrush, battX - 22, 13);
		}

		// 7. Screen Frame Border
		using (Pen scrBorder = new Pen(Color.FromArgb(35, 38, 48), 1f))
		{
			g.DrawRectangle(scrBorder, ScreenPanel.Left - 1, ScreenPanel.Top - 1, ScreenPanel.Width + 1, ScreenPanel.Height + 1);
		}

		// 8. Bottom Navigation Bar (Vector Keys)
		int navY = h - 23;
		// Back button: clean vector chevron ‹
		Color backColor = (_hoveredNavButton == 1) ? Color.White : Color.FromArgb(160, 168, 182);
		if (_hoveredNavButton == 1)
		{
			using (SolidBrush glow = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
			{
				g.FillEllipse(glow, cx - 67, navY - 7, 24, 24);
			}
		}
		using (Pen navPen = new Pen(backColor, 2f))
		{
			navPen.StartCap = LineCap.Round;
			navPen.EndCap = LineCap.Round;
			Point[] backPts = new Point[] {
				new Point(cx - 52, navY - 5),
				new Point(cx - 57, navY + 4),
				new Point(cx - 52, navY + 13)
			};
			g.DrawLines(navPen, backPts);
		}

		// Home button: clean vector circle ○
		Color homeColor = (_hoveredNavButton == 2) ? Color.White : Color.FromArgb(160, 168, 182);
		if (_hoveredNavButton == 2)
		{
			using (SolidBrush glow = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
			{
				g.FillEllipse(glow, cx - 12, navY - 7, 24, 24);
			}
		}
		using (Pen homePen = new Pen(homeColor, 2f))
		{
			g.DrawEllipse(homePen, cx - 6, navY - 1, 12, 12);
		}

		// Recents button: clean vector rounded square ▢
		Color recColor = (_hoveredNavButton == 3) ? Color.White : Color.FromArgb(160, 168, 182);
		if (_hoveredNavButton == 3)
		{
			using (SolidBrush glow = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
			{
				g.FillEllipse(glow, cx + 43, navY - 7, 24, 24);
			}
		}
		using (GraphicsPath sqPath = GetRoundedPath(new Rectangle(cx + 49, navY, 11, 11), 3))
		using (Pen sqPen = new Pen(recColor, 2f))
		{
			g.DrawPath(sqPen, sqPath);
		}

		// Gesture indicator pill bar
		using (SolidBrush gestBrush = new SolidBrush(Color.FromArgb(85, 92, 105)))
		using (GraphicsPath gestPath = GetRoundedPath(new Rectangle(cx - 32, h - 7, 64, 3), 1))
		{
			g.FillPath(gestBrush, gestPath);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			try
			{
				_timer?.Stop();
				_timer?.Dispose();
			}
			catch {}
		}
		base.Dispose(disposing);
	}
}
