using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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

	public static fViewChrome fViewChrome_0;

	private fMain F5140524 = null;

	private IContainer AD3B460C = null;

	public FlowLayoutPanel panelListDevice;

	// Modern Zoom Bar Controls
	private Panel pnlZoomBar;
	private Label lblTitle;
	private Label lblDeviceCount;
	private Label lblZoomValue;
	private Button btnZoomOut;
	private Button btnZoomIn;
	private TrackBar trackBarZoom;
	private Button btnScale50;
	private Button btnScale75;
	private Button btnScale100;
	private Button btnAutoFit;

	private float _currentZoomScale = 1.0f;

	public bool IsPhoneView => C5034B95.smethod_0("configGeneral").method_3("ckbAddAndroidPhoneView");

	public fViewChrome()
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		fViewChrome_0 = this;
		SetupCleanLightAndZoomToolbar();
		Language.CD21F0A9(this);
	}

	public fViewChrome(fMain fMain_0)
	{
		InitializeComponent();
		base.Icon = Class155.D596C6A5;
		fViewChrome_0 = this;
		F5140524 = fMain_0;
		SetupCleanLightAndZoomToolbar();
		Language.CD21F0A9(this);
	}

	/// <summary>
	/// Thiết lập nền màu trắng sạch sẽ chuẩn Clean Light và thanh công cụ phóng to / thu nhỏ.
	/// </summary>
	private void SetupCleanLightAndZoomToolbar()
	{
		// 1. Nền màu trắng tinh tế (Clean Slate 50)
		Color bgLight = Color.FromArgb(248, 250, 252);
		BackColor = bgLight;
		panelListDevice.BackColor = bgLight;

		Text = IsPhoneView ? "Android Phone View (0)" : "Form View Chrome (0)";

		// 2. Tạo Toolbar phóng to / thu nhỏ ở mép trên
		CreateZoomToolbar();

		// 3. Bắt sự kiện Ctrl + Lăn chuột để phóng to / thu nhỏ như trình duyệt Web
		panelListDevice.MouseWheel += OnDeviceListMouseWheel;
		this.MouseWheel += OnDeviceListMouseWheel;
	}

	private void CreateZoomToolbar()
	{
		if (pnlZoomBar != null) return;

		pnlZoomBar = new Panel();
		pnlZoomBar.Dock = DockStyle.Top;
		pnlZoomBar.Height = 44;
		pnlZoomBar.BackColor = Color.White;
		pnlZoomBar.Padding = new Padding(12, 5, 12, 5);
		pnlZoomBar.Paint += (s, e) =>
		{
			// Bottom border line 1px #E2E8F0
			using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1f))
			{
				e.Graphics.DrawLine(p, 0, pnlZoomBar.Height - 1, pnlZoomBar.Width, pnlZoomBar.Height - 1);
			}
		};

		// Tiêu đề & Icon
		lblTitle = new Label();
		lblTitle.Text = IsPhoneView ? "📱 Android Phone View" : "💻 Form View Chrome";
		lblTitle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
		lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
		lblTitle.AutoSize = true;
		lblTitle.Location = new Point(12, 12);
		pnlZoomBar.Controls.Add(lblTitle);

		// Badge số lượng thiết bị
		lblDeviceCount = new Label();
		lblDeviceCount.Text = "0 Máy";
		lblDeviceCount.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		lblDeviceCount.ForeColor = Color.FromArgb(37, 99, 235);
		lblDeviceCount.BackColor = Color.FromArgb(239, 246, 255);
		lblDeviceCount.AutoSize = false;
		lblDeviceCount.Size = new Size(65, 24);
		lblDeviceCount.TextAlign = ContentAlignment.MiddleCenter;
		lblDeviceCount.Location = new Point(lblTitle.Right + 12, 10);
		lblDeviceCount.Paint += (s, e) =>
		{
			using (Pen p = new Pen(Color.FromArgb(191, 219, 254), 1f))
			{
				e.Graphics.DrawRectangle(p, 0, 0, lblDeviceCount.Width - 1, lblDeviceCount.Height - 1);
			}
		};
		pnlZoomBar.Controls.Add(lblDeviceCount);

		// Preset Buttons (Canh phải)
		FlowLayoutPanel flowRight = new FlowLayoutPanel();
		flowRight.Dock = DockStyle.Right;
		flowRight.AutoSize = true;
		flowRight.FlowDirection = FlowDirection.LeftToRight;
		flowRight.WrapContents = false;
		flowRight.BackColor = Color.Transparent;
		flowRight.Padding = new Padding(0, 4, 0, 0);

		// Nút Auto-Fit (Tự động dàn vừa màn hình cho 30-50 nick)
		btnAutoFit = CreateToolbarButton("🗖 Tự căn chỉnh", 110, Color.FromArgb(239, 246, 255), Color.FromArgb(37, 99, 235));
		btnAutoFit.Click += (s, e) => AutoFitDevicesToScreen();
		flowRight.Controls.Add(btnAutoFit);

		// Nút 50% (Phù hợp 30 - 50 nick)
		btnScale50 = CreateToolbarButton("50% (30-50 nick)", 115, Color.FromArgb(241, 245, 249), Color.FromArgb(51, 65, 85));
		btnScale50.Click += (s, e) => SetZoom(0.50f);
		flowRight.Controls.Add(btnScale50);

		// Nút 75% (Phù hợp 10 - 20 nick)
		btnScale75 = CreateToolbarButton("75%", 55, Color.FromArgb(241, 245, 249), Color.FromArgb(51, 65, 85));
		btnScale75.Click += (s, e) => SetZoom(0.75f);
		flowRight.Controls.Add(btnScale75);

		// Nút 100% (Chuẩn)
		btnScale100 = CreateToolbarButton("100%", 55, Color.FromArgb(241, 245, 249), Color.FromArgb(51, 65, 85));
		btnScale100.Click += (s, e) => SetZoom(1.00f);
		flowRight.Controls.Add(btnScale100);

		// Cụm nút [-] [100%] [+]
		btnZoomOut = CreateToolbarButton("−", 32, Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
		btnZoomOut.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
		btnZoomOut.Click += (s, e) => SetZoom(_currentZoomScale - 0.05f);
		flowRight.Controls.Add(btnZoomOut);

		lblZoomValue = new Label();
		lblZoomValue.Text = "100%";
		lblZoomValue.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		lblZoomValue.ForeColor = Color.FromArgb(30, 41, 59);
		lblZoomValue.AutoSize = false;
		lblZoomValue.Size = new Size(50, 28);
		lblZoomValue.TextAlign = ContentAlignment.MiddleCenter;
		lblZoomValue.Cursor = Cursors.Hand;
		lblZoomValue.Click += (s, e) => SetZoom(1.0f); // Click để reset 100%
		flowRight.Controls.Add(lblZoomValue);

		btnZoomIn = CreateToolbarButton("+", 32, Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
		btnZoomIn.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
		btnZoomIn.Click += (s, e) => SetZoom(_currentZoomScale + 0.05f);
		flowRight.Controls.Add(btnZoomIn);

		// TrackBar Zoom (Ẩn ngầm hoặc chỉnh mượt)
		trackBarZoom = new TrackBar();
		trackBarZoom.Minimum = 35;
		trackBarZoom.Maximum = 150;
		trackBarZoom.Value = 100;
		trackBarZoom.TickStyle = TickStyle.None;
		trackBarZoom.Size = new Size(90, 28);
		trackBarZoom.ValueChanged += (s, e) =>
		{
			float newScale = trackBarZoom.Value / 100.0f;
			if (Math.Abs(newScale - _currentZoomScale) >= 0.02f)
			{
				SetZoom(newScale, updateTrackbar: false);
			}
		};
		flowRight.Controls.Add(trackBarZoom);

		pnlZoomBar.Controls.Add(flowRight);
		Controls.Add(pnlZoomBar);

		// Đảm bảo panelListDevice nằm dưới toolbar
		panelListDevice.BringToFront();
	}

	private Button CreateToolbarButton(string text, int width, Color bg, Color fg)
	{
		Button b = new Button();
		b.Text = text;
		b.Size = new Size(width, 28);
		b.FlatStyle = FlatStyle.Flat;
		b.FlatAppearance.BorderSize = 1;
		b.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
		b.BackColor = bg;
		b.ForeColor = fg;
		b.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
		b.Cursor = Cursors.Hand;
		b.Margin = new Padding(3, 0, 3, 0);
		return b;
	}

	/// <summary>
	/// Bắt sự kiện phím Ctrl + Lăn chuột để Zoom In / Zoom Out tức thì (như trình duyệt web).
	/// </summary>
	private void OnDeviceListMouseWheel(object sender, MouseEventArgs e)
	{
		if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
		{
			if (e.Delta > 0)
			{
				SetZoom(_currentZoomScale + 0.05f);
			}
			else if (e.Delta < 0)
			{
				SetZoom(_currentZoomScale - 0.05f);
			}
			// Ngăn chặn cuộn trang khi đang zoom
			if (e is HandledMouseEventArgs hme)
			{
				hme.Handled = true;
			}
		}
	}

	/// <summary>
	/// Thiết lập tỉ lệ thu phóng (Scale) cho toàn bộ màn hình giả lập và cửa sổ Chrome bên trong.
	/// </summary>
	public void SetZoom(float scale, bool updateTrackbar = true)
	{
		_currentZoomScale = Math.Max(0.35f, Math.Min(1.60f, scale));

		if (lblZoomValue != null)
		{
			lblZoomValue.Text = (int)(_currentZoomScale * 100) + "%";
		}
		if (updateTrackbar && trackBarZoom != null)
		{
			int tbVal = (int)(_currentZoomScale * 100);
			trackBarZoom.Value = Math.Max(trackBarZoom.Minimum, Math.Min(trackBarZoom.Maximum, tbVal));
		}

		panelListDevice.SuspendLayout();
		try
		{
			foreach (Control c in panelListDevice.Controls)
			{
				if (c is PhoneDeviceFrame phone)
				{
					phone.ApplyScale(_currentZoomScale);
				}
				else if (c is Panel p && p.Tag is int)
				{
					ApplyScaleToStandardPanel(p, _currentZoomScale);
				}
			}
		}
		finally
		{
			panelListDevice.ResumeLayout(true);
		}
	}

	private void ApplyScaleToStandardPanel(Panel p, float scale)
	{
		try
		{
			int baseW = 360;
			int baseH = 480;
			if (p.Tag is int[] dims && dims.Length >= 2)
			{
				baseW = dims[0];
				baseH = dims[1];
			}
			else
			{
				// Lưu kích thước gốc vào Tag nếu chưa có
				p.Tag = new int[] { p.Width, p.Height };
				baseW = p.Width;
				baseH = p.Height;
			}

			int newW = (int)(baseW * scale);
			int newH = (int)(baseH * scale);
			p.Size = new Size(newW, newH);

			// Scale chrome inside
			Control screenPanel = p.Controls.Count > 0 ? p.Controls[0] : p;
			if (screenPanel.Tag is IntPtr hChrome && hChrome != IntPtr.Zero)
			{
				User32Helper.MoveWindow(hChrome, -10, -30, newW, newH, true);
			}
		}
		catch { }
	}

	/// <summary>
	/// Tự động tính toán Scale tối ưu để tất cả các thiết bị (ví dụ 30-50 nick) dàn đều
	/// vừa khít màn hình hiện tại mà không bị cuộn trang.
	/// </summary>
	public void AutoFitDevicesToScreen()
	{
		int count = panelListDevice.Controls.Count;
		if (count <= 0) return;

		int availW = panelListDevice.ClientSize.Width - 30;
		int availH = panelListDevice.ClientSize.Height - 30;
		if (availW <= 100 || availH <= 100) return;

		// Chuẩn kích thước phone gốc
		int baseItemW = 373 + 16;
		int baseItemH = 481 + 72;

		float bestScale = 0.40f;

		// Thử các số lượng cột từ 1 đến count
		for (int cols = 1; cols <= count; cols++)
		{
			int rows = (int)Math.Ceiling((double)count / cols);

			int margin = 12;
			float scaleW = (float)(availW - (cols * margin)) / (cols * baseItemW);
			float scaleH = (float)(availH - (rows * margin)) / (rows * baseItemH);

			float possibleScale = Math.Min(scaleW, scaleH);
			if (possibleScale > bestScale)
			{
				bestScale = possibleScale;
			}
		}

		// Giới hạn scale trong khoảng hợp lý
		bestScale = Math.Max(0.35f, Math.Min(1.20f, bestScale));
		SetZoom(bestScale);
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
					phone.BaseOffsetX = int_3;
					phone.BaseOffsetY = AD020A96;
					phone.SetChromeHandle(intptr_0);
					User32Helper.SetParent(intptr_0, phone.ScreenPanel.Handle);

					// Áp dụng scale hiện tại lên cửa sổ Chrome
					int scaledW = (int)(phone.BaseScreenWidth * phone.CurrentScale);
					int scaledH = (int)(phone.BaseScreenHeight * phone.CurrentScale);
					int offX = (int)(phone.BaseOffsetX * phone.CurrentScale);
					int offY = (int)(phone.BaseOffsetY * phone.CurrentScale);
					User32Helper.MoveWindow(intptr_0, offX, offY, scaledW, scaledH, bool_0: true);
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
			PhoneDeviceFrame phoneFrame = new PhoneDeviceFrame(int_0, int_1, int_2, _currentZoomScale);
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
			FB156783.Size = new Size((int)(int_1 * _currentZoomScale), (int)(int_2 * _currentZoomScale));
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

			// Cập nhật số lượng trên Toolbar
			if (lblDeviceCount != null)
			{
				lblDeviceCount.Text = D8A2529C + " Máy";
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
		panelListDevice.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
		panelListDevice.Dock = System.Windows.Forms.DockStyle.Fill;
		panelListDevice.Location = new System.Drawing.Point(0, 44);
		panelListDevice.Name = "panelListDevice";
		panelListDevice.Padding = new System.Windows.Forms.Padding(12);
		panelListDevice.Size = new System.Drawing.Size(933, 510);
		panelListDevice.TabIndex = 1;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(933, 554);
		base.Controls.Add(panelListDevice);
		Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fViewChrome";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Android Phone View (0)";
		ResumeLayout(false);
	}
}

/// <summary>
/// Khung điện thoại Android giả lập siêu thực tế (Phone Chassis)
/// Hỗ trợ Zoom Scale động từ 35% đến 150%, hiển thị siêu sắc nét trên nền trắng.
/// </summary>
public class PhoneDeviceFrame : Panel
{
	private int _deviceId;
	private IntPtr _chromeHandle = IntPtr.Zero;
	private string _timeStr = DateTime.Now.ToString("HH:mm");
	private System.Windows.Forms.Timer _timer;
	private int _hoveredNavButton = 0; // 0 = none, 1 = back, 2 = home, 3 = recents, 4 = island

	public int BaseScreenWidth { get; private set; }
	public int BaseScreenHeight { get; private set; }
	public int BaseOffsetX { get; set; } = -10;
	public int BaseOffsetY { get; set; } = -30;
	public float CurrentScale { get; private set; } = 1.0f;
	public IntPtr ChromeHandle => _chromeHandle;

	public Panel ScreenPanel { get; private set; }

	public PhoneDeviceFrame(int deviceId, int screenWidth, int screenHeight, float initialScale = 1.0f)
	{
		_deviceId = deviceId;
		Name = "dv" + deviceId;
		Tag = deviceId;

		BaseScreenWidth = screenWidth;
		BaseScreenHeight = screenHeight;

		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
		DoubleBuffered = true;

		ScreenPanel = new Panel();
		ScreenPanel.Name = "screen_" + deviceId;
		ScreenPanel.Tag = deviceId;
		ScreenPanel.BackColor = Color.Black;
		ScreenPanel.BorderStyle = BorderStyle.None;
		Controls.Add(ScreenPanel);

		// Áp dụng scale ban đầu
		ApplyScale(initialScale);

		_timer = new System.Windows.Forms.Timer();
		_timer.Interval = 30000;
		_timer.Tick += (s, e) =>
		{
			_timeStr = DateTime.Now.ToString("HH:mm");
			Invalidate(new Rectangle(0, 0, Width, Math.Max(20, (int)(36 * CurrentScale))));
		};
		_timer.Start();
	}

	/// <summary>
	/// Áp dụng tỉ lệ phóng to / thu nhỏ linh hoạt cho khung điện thoại và màn hình Chrome.
	/// </summary>
	public void ApplyScale(float scale)
	{
		CurrentScale = scale;

		int scaledScreenWidth = Math.Max(120, (int)(BaseScreenWidth * scale));
		int scaledScreenHeight = Math.Max(160, (int)(BaseScreenHeight * scale));

		int topBarH = Math.Max(20, (int)(36 * scale));
		int bottomBarH = Math.Max(20, (int)(36 * scale));
		int sideBorder = Math.Max(4, (int)(8 * scale));

		int outerWidth = scaledScreenWidth + sideBorder * 2;
		int outerHeight = scaledScreenHeight + topBarH + bottomBarH;

		Size = new Size(outerWidth, outerHeight);
		BackColor = Color.FromArgb(20, 22, 28);
		Margin = new Padding(Math.Max(4, (int)(10 * scale)));
		Padding = new Padding(0);

		ScreenPanel.Location = new Point(sideBorder, topBarH);
		ScreenPanel.Size = new Size(scaledScreenWidth, scaledScreenHeight);

		if (_chromeHandle != IntPtr.Zero)
		{
			int offX = (int)(BaseOffsetX * scale);
			int offY = (int)(BaseOffsetY * scale);
			User32Helper.MoveWindow(_chromeHandle, offX, offY, scaledScreenWidth, scaledScreenHeight, true);
		}

		UpdateRegion();
		Invalidate();
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
				int radius = Math.Max(8, (int)(20 * CurrentScale));
				using (GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, Width, Height), radius))
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

		int bottomBarH = Height - ScreenPanel.Bottom;

		// Bottom navigation bar buttons
		if (e.Y >= ScreenPanel.Bottom)
		{
			int distFromCenter = e.X - cx;
			if (distFromCenter >= -75 * CurrentScale && distFromCenter <= -25 * CurrentScale) newHover = 1; // Back
			else if (Math.Abs(distFromCenter) <= 20 * CurrentScale) newHover = 2; // Home
			else if (distFromCenter >= 25 * CurrentScale && distFromCenter <= 75 * CurrentScale) newHover = 3; // Recents
		}
		// Top Dynamic Island
		else if (e.Y <= ScreenPanel.Top && Math.Abs(e.X - cx) <= 55 * CurrentScale)
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
		g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

		int w = Width;
		int h = Height;
		int cx = w / 2;
		float sc = CurrentScale;

		int radius = Math.Max(8, (int)(20 * sc));

		// 1. Khung máy Titanium / Obsidian bo góc
		using (GraphicsPath outerPath = GetRoundedPath(new Rectangle(0, 0, w - 1, h - 1), radius))
		{
			using (SolidBrush bodyBrush = new SolidBrush(Color.FromArgb(20, 22, 28)))
			{
				g.FillPath(bodyBrush, outerPath);
			}
			// Viền kim loại Titanium sắc sảo
			using (Pen rimPen = new Pen(Color.FromArgb(75, 82, 98), Math.Max(1.2f, 1.75f * sc)))
			{
				g.DrawPath(rimPen, outerPath);
			}
			// Viền bezel trong
			int innerR = Math.Max(6, radius - 2);
			using (GraphicsPath innerPath = GetRoundedPath(new Rectangle(2, 2, w - 5, h - 5), innerR))
			using (Pen innerPen = new Pen(Color.FromArgb(38, 42, 52), 1f))
			{
				g.DrawPath(innerPen, innerPath);
			}
		}

		// 2. Nút bấm vật lý cạnh bên (Nút âm lượng + Nút nguồn)
		if (sc >= 0.55f)
		{
			using (SolidBrush btnBrush = new SolidBrush(Color.FromArgb(90, 98, 115)))
			{
				g.FillRectangle(btnBrush, 0, (int)(70 * sc), 2, (int)(24 * sc));
				g.FillRectangle(btnBrush, 0, (int)(102 * sc), 2, (int)(24 * sc));
				g.FillRectangle(btnBrush, w - 2, (int)(85 * sc), 2, (int)(32 * sc));
			}

			// Loa thoại đỉnh máy
			using (SolidBrush spkBrush = new SolidBrush(Color.FromArgb(45, 48, 58)))
			{
				int spkW = (int)(40 * sc);
				g.FillRectangle(spkBrush, cx - spkW / 2, Math.Max(3, (int)(5 * sc)), spkW, 3);
			}
		}

		// 3. Dynamic Island / Punch Hole Pill (Giữa đỉnh máy)
		int islandW = Math.Min(110, Math.Max((int)(60 * sc), (int)(w / 3.2f)));
		int islandH = Math.Max(12, (int)(18 * sc));
		int islandY = Math.Max(4, (int)(9 * sc));
		Rectangle islandRect = new Rectangle(cx - islandW / 2, islandY, islandW, islandH);
		using (GraphicsPath islandPath = GetRoundedPath(islandRect, islandH / 2))
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

		// Camera nốt ruồi trong đảo
		int camSize = Math.Max(6, (int)(9 * sc));
		int camX = islandRect.Left + Math.Max(4, (int)(6 * sc));
		int camY = islandY + (islandH - camSize) / 2;
		using (SolidBrush camBrush = new SolidBrush(Color.FromArgb(16, 20, 28)))
		using (Pen camRing = new Pen(Color.FromArgb(40, 45, 58), 1f))
		{
			g.FillEllipse(camBrush, camX, camY, camSize, camSize);
			g.DrawEllipse(camRing, camX, camY, camSize, camSize);
		}

		// Nhãn số thiết bị (DEV #1, DEV #2...)
		float islandFontSize = Math.Max(5.5f, 7.5f * sc);
		using (Font islandFont = new Font("Segoe UI", islandFontSize, FontStyle.Bold))
		using (SolidBrush islandTextBrush = new SolidBrush(Color.FromArgb(215, 225, 240)))
		{
			string devText = (sc < 0.6f) ? $"#{_deviceId + 1}" : $"DEV #{_deviceId + 1}";
			g.DrawString(devText, islandFont, islandTextBrush, camX + camSize + 3, islandY + (islandH - (int)(islandFontSize * 1.5f)) / 2);
		}

		// 4. Thanh trạng thái đỉnh máy - Trái (Đồng hồ)
		if (sc >= 0.5f)
		{
			float timeFontSize = Math.Max(6.5f, 8f * sc);
			using (Font timeFont = new Font("Segoe UI", timeFontSize, FontStyle.Bold))
			using (SolidBrush timeBrush = new SolidBrush(Color.FromArgb(230, 235, 245)))
			{
				g.DrawString(_timeStr, timeFont, timeBrush, Math.Max(6, (int)(10 * sc)), islandY);
			}

			// Thanh trạng thái đỉnh máy - Phải (Pin & 5G)
			int rightX = w - Math.Max(8, (int)(12 * sc));
			int battW = Math.Max(12, (int)(16 * sc));
			int battH = Math.Max(7, (int)(9 * sc));
			int battX = rightX - battW;
			int battY = islandY + (islandH - battH) / 2;

			using (Pen battPen = new Pen(Color.FromArgb(180, 188, 200), 1f))
			{
				g.DrawRectangle(battPen, battX, battY, battW, battH);
			}
			using (SolidBrush chargeBrush = new SolidBrush(Color.FromArgb(46, 204, 113)))
			{
				g.FillRectangle(chargeBrush, battX + 2, battY + 2, battW - 4, battH - 3);
			}

			if (sc >= 0.7f)
			{
				using (Font netFont = new Font("Segoe UI", Math.Max(5.5f, 6.5f * sc), FontStyle.Bold))
				using (SolidBrush netBrush = new SolidBrush(Color.FromArgb(170, 180, 195)))
				{
					g.DrawString("5G", netFont, netBrush, battX - (int)(18 * sc), battY - 1);
				}
			}
		}

		// 5. Viền ngăn cách màn hình
		using (Pen scrBorder = new Pen(Color.FromArgb(35, 38, 48), 1f))
		{
			g.DrawRectangle(scrBorder, ScreenPanel.Left - 1, ScreenPanel.Top - 1, ScreenPanel.Width + 1, ScreenPanel.Height + 1);
		}

		// 6. Thanh điều hướng cảm ứng đáy máy (Vector Keys: ‹  ○  □)
		int bottomBarH = h - ScreenPanel.Bottom;
		int navY = ScreenPanel.Bottom + (bottomBarH / 2);
		float navSpacing = Math.Max(25, 48 * sc);

		// Nút Back ‹
		Color backColor = (_hoveredNavButton == 1) ? Color.White : Color.FromArgb(160, 168, 182);
		using (Pen navPen = new Pen(backColor, Math.Max(1.5f, 2f * sc)))
		{
			navPen.StartCap = LineCap.Round;
			navPen.EndCap = LineCap.Round;
			int bx = cx - (int)navSpacing;
			int bs = (int)(6 * sc);
			Point[] backPts = new Point[] {
				new Point(bx + bs / 2, navY - bs),
				new Point(bx - bs / 2, navY),
				new Point(bx + bs / 2, navY + bs)
			};
			g.DrawLines(navPen, backPts);
		}

		// Nút Home ○
		Color homeColor = (_hoveredNavButton == 2) ? Color.White : Color.FromArgb(160, 168, 182);
		using (Pen homePen = new Pen(homeColor, Math.Max(1.5f, 2f * sc)))
		{
			int hs = Math.Max(8, (int)(11 * sc));
			g.DrawEllipse(homePen, cx - hs / 2, navY - hs / 2, hs, hs);
		}

		// Nút Recents □
		Color recColor = (_hoveredNavButton == 3) ? Color.White : Color.FromArgb(160, 168, 182);
		using (Pen recPen = new Pen(recColor, Math.Max(1.5f, 2f * sc)))
		{
			int rs = Math.Max(7, (int)(10 * sc));
			g.DrawRectangle(recPen, cx + (int)navSpacing - rs / 2, navY - rs / 2, rs, rs);
		}
	}
}
