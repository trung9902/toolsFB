using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

public class ucContact : UserControl
{
	private IContainer components = null;

	private PictureBox picBanner;
	private Label lblSubTitle;

	private Panel pnlCard;
	private Label lblWebTitle;
	private LinkLabel llWebsite;
	private Label lblHotlineTitle;
	private Label lblHotline;
	private Label lblHotlineCopy;
	private Label lblDevTitle;
	private Label lblDev;
	private Label lblLicTitle;
	private Label lblLic;

	private Panel pnlButtons;
	private Button btnOpenWeb;
	private Button btnZalo;

	private Panel pnlWarning;
	private Label lblWarnTitle;
	private Label lblWarnBody;

	public ucContact()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
	}

	private static Image GetBannerImage()
	{
		try
		{
			string[] searchPaths = new string[]
			{
				Path.Combine(Application.StartupPath, "image_baner", "lush_baner.png"),
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image_baner", "lush_baner.png")
			};
			foreach (string text in searchPaths)
			{
				if (File.Exists(text))
				{
					byte[] bytes = File.ReadAllBytes(text);
					using (MemoryStream ms = new MemoryStream(bytes))
					{
						return new Bitmap(ms);
					}
				}
			}
		}
		catch { }
		return Class155.DD225F0D;
	}

	private void btnOpenWeb_Click(object sender, EventArgs e)
	{
		try
		{
			Commom.CE2E5B3B("https://lushmkt.com");
		}
		catch { }
	}

	private void btnZalo_Click(object sender, EventArgs e)
	{
		try
		{
			Commom.CE2E5B3B("https://zalo.me/0359261551");
		}
		catch { }
	}

	private void llWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Commom.CE2E5B3B("https://lushmkt.com");
		}
		catch { }
	}

	private void lblHotline_Click(object sender, EventArgs e)
	{
		CopyHotline();
	}

	private void lblHotlineCopy_Click(object sender, EventArgs e)
	{
		CopyHotline();
	}

	private void CopyHotline()
	{
		try
		{
			Clipboard.SetText("0359.261.551");
			MessageBox.Show("Đã sao chép Hotline: 0359.261.551 vào bộ nhớ tạm!", "LunisSoftware Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch { }
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.picBanner = new PictureBox();
		this.lblSubTitle = new Label();

		this.pnlCard = new Panel();
		this.lblWebTitle = new Label();
		this.llWebsite = new LinkLabel();
		this.lblHotlineTitle = new Label();
		this.lblHotline = new Label();
		this.lblHotlineCopy = new Label();
		this.lblDevTitle = new Label();
		this.lblDev = new Label();
		this.lblLicTitle = new Label();
		this.lblLic = new Label();

		this.pnlButtons = new Panel();
		this.btnOpenWeb = new Button();
		this.btnZalo = new Button();

		this.pnlWarning = new Panel();
		this.lblWarnTitle = new Label();
		this.lblWarnBody = new Label();

		((ISupportInitialize)(this.picBanner)).BeginInit();
		this.pnlCard.SuspendLayout();
		this.pnlButtons.SuspendLayout();
		this.pnlWarning.SuspendLayout();
		this.SuspendLayout();

		// 
		// picBanner (Top Center Banner)
		// 
		this.picBanner.BackColor = Color.Transparent;
		this.picBanner.Cursor = Cursors.Hand;
		this.picBanner.Image = GetBannerImage();
		this.picBanner.Location = new Point(122, 12);
		this.picBanner.Name = "picBanner";
		this.picBanner.Size = new Size(470, 118);
		this.picBanner.SizeMode = PictureBoxSizeMode.Zoom;
		this.picBanner.TabIndex = 0;
		this.picBanner.TabStop = false;
		this.picBanner.Click += new EventHandler(this.btnOpenWeb_Click);

		// 
		// lblSubTitle
		// 
		this.lblSubTitle.Font = new Font("Segoe UI", 9.25f, FontStyle.Italic, GraphicsUnit.Point, 0);
		this.lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
		this.lblSubTitle.Location = new Point(10, 134);
		this.lblSubTitle.Name = "lblSubTitle";
		this.lblSubTitle.Size = new Size(694, 20);
		this.lblSubTitle.TabIndex = 1;
		this.lblSubTitle.Text = "Hệ thống giải pháp phần mềm tự động hóa Marketing & Chăm sóc tài khoản chuyên nghiệp";
		this.lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;

		// 
		// pnlCard (Main Information Card with crisp two-column grid)
		// 
		this.pnlCard.BackColor = Color.FromArgb(248, 250, 252);
		this.pnlCard.BorderStyle = BorderStyle.FixedSingle;
		this.pnlCard.Controls.Add(this.lblWebTitle);
		this.pnlCard.Controls.Add(this.llWebsite);
		this.pnlCard.Controls.Add(this.lblHotlineTitle);
		this.pnlCard.Controls.Add(this.lblHotline);
		this.pnlCard.Controls.Add(this.lblHotlineCopy);
		this.pnlCard.Controls.Add(this.lblDevTitle);
		this.pnlCard.Controls.Add(this.lblDev);
		this.pnlCard.Controls.Add(this.lblLicTitle);
		this.pnlCard.Controls.Add(this.lblLic);
		this.pnlCard.Location = new Point(57, 162);
		this.pnlCard.Name = "pnlCard";
		this.pnlCard.Size = new Size(600, 142);
		this.pnlCard.TabIndex = 2;

		// Row 1: Website
		this.lblWebTitle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblWebTitle.ForeColor = Color.FromArgb(51, 65, 85);
		this.lblWebTitle.Location = new Point(24, 12);
		this.lblWebTitle.Name = "lblWebTitle";
		this.lblWebTitle.Size = new Size(160, 22);
		this.lblWebTitle.TabIndex = 0;
		this.lblWebTitle.Text = "Website chính thức:";

		this.llWebsite.AutoSize = true;
		this.llWebsite.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.llWebsite.LinkBehavior = LinkBehavior.HoverUnderline;
		this.llWebsite.LinkColor = Color.FromArgb(2, 132, 199);
		this.llWebsite.Location = new Point(190, 11);
		this.llWebsite.Name = "llWebsite";
		this.llWebsite.Size = new Size(149, 19);
		this.llWebsite.TabIndex = 1;
		this.llWebsite.Text = "https://lushmkt.com";
		this.llWebsite.LinkClicked += new LinkLabelLinkClickedEventHandler(this.llWebsite_LinkClicked);

		// Row 2: Hotline
		this.lblHotlineTitle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblHotlineTitle.ForeColor = Color.FromArgb(51, 65, 85);
		this.lblHotlineTitle.Location = new Point(24, 43);
		this.lblHotlineTitle.Name = "lblHotlineTitle";
		this.lblHotlineTitle.Size = new Size(160, 22);
		this.lblHotlineTitle.TabIndex = 2;
		this.lblHotlineTitle.Text = "Hotline / Zalo hỗ trợ:";

		this.lblHotline.AutoSize = true;
		this.lblHotline.Cursor = Cursors.Hand;
		this.lblHotline.Font = new Font("Segoe UI", 11.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblHotline.ForeColor = Color.FromArgb(220, 38, 38);
		this.lblHotline.Location = new Point(190, 41);
		this.lblHotline.Name = "lblHotline";
		this.lblHotline.Size = new Size(106, 21);
		this.lblHotline.TabIndex = 3;
		this.lblHotline.Text = "0359.261.551";
		this.lblHotline.Click += new EventHandler(this.lblHotline_Click);

		this.lblHotlineCopy.AutoSize = true;
		this.lblHotlineCopy.Cursor = Cursors.Hand;
		this.lblHotlineCopy.Font = new Font("Segoe UI", 8.5f, FontStyle.Underline, GraphicsUnit.Point, 0);
		this.lblHotlineCopy.ForeColor = Color.FromArgb(14, 165, 233);
		this.lblHotlineCopy.Location = new Point(306, 46);
		this.lblHotlineCopy.Name = "lblHotlineCopy";
		this.lblHotlineCopy.Size = new Size(188, 15);
		this.lblHotlineCopy.TabIndex = 4;
		this.lblHotlineCopy.Text = "[Hỗ trợ 24/7 - Click để sao chép]";
		this.lblHotlineCopy.Click += new EventHandler(this.lblHotlineCopy_Click);

		// Row 3: Dev
		this.lblDevTitle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblDevTitle.ForeColor = Color.FromArgb(51, 65, 85);
		this.lblDevTitle.Location = new Point(24, 75);
		this.lblDevTitle.Name = "lblDevTitle";
		this.lblDevTitle.Size = new Size(160, 22);
		this.lblDevTitle.TabIndex = 5;
		this.lblDevTitle.Text = "Đơn vị phát triển:";

		this.lblDev.AutoSize = true;
		this.lblDev.Font = new Font("Segoe UI", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblDev.ForeColor = Color.FromArgb(15, 118, 110);
		this.lblDev.Location = new Point(190, 75);
		this.lblDev.Name = "lblDev";
		this.lblDev.Size = new Size(167, 19);
		this.lblDev.TabIndex = 6;
		this.lblDev.Text = "LunisSoftware Việt Nam";

		// Row 4: License
		this.lblLicTitle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblLicTitle.ForeColor = Color.FromArgb(51, 65, 85);
		this.lblLicTitle.Location = new Point(24, 107);
		this.lblLicTitle.Name = "lblLicTitle";
		this.lblLicTitle.Size = new Size(160, 22);
		this.lblLicTitle.TabIndex = 7;
		this.lblLicTitle.Text = "Bản quyền phần mềm:";

		this.lblLic.AutoSize = true;
		this.lblLic.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.lblLic.ForeColor = Color.FromArgb(22, 163, 74);
		this.lblLic.Location = new Point(190, 108);
		this.lblLic.Name = "lblLic";
		this.lblLic.Size = new Size(392, 15);
		this.lblLic.TabIndex = 8;
		this.lblLic.Text = "LushCare Pro v26.01 - AI & Multi-Threading Edition (Bản quyền chính thức)";

		// 
		// pnlButtons (Quick Action Buttons)
		// 
		this.pnlButtons.Controls.Add(this.btnOpenWeb);
		this.pnlButtons.Controls.Add(this.btnZalo);
		this.pnlButtons.Location = new Point(57, 314);
		this.pnlButtons.Name = "pnlButtons";
		this.pnlButtons.Size = new Size(600, 38);
		this.pnlButtons.TabIndex = 3;

		// btnOpenWeb
		this.btnOpenWeb.BackColor = Color.FromArgb(14, 165, 233);
		this.btnOpenWeb.Cursor = Cursors.Hand;
		this.btnOpenWeb.FlatAppearance.BorderSize = 0;
		this.btnOpenWeb.FlatStyle = FlatStyle.Flat;
		this.btnOpenWeb.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.btnOpenWeb.ForeColor = Color.White;
		this.btnOpenWeb.Location = new Point(0, 1);
		this.btnOpenWeb.Name = "btnOpenWeb";
		this.btnOpenWeb.Size = new Size(292, 36);
		this.btnOpenWeb.TabIndex = 0;
		this.btnOpenWeb.Text = "Truy cập Website: lushmkt.com";
		this.btnOpenWeb.UseVisualStyleBackColor = false;
		this.btnOpenWeb.Click += new EventHandler(this.btnOpenWeb_Click);
		this.btnOpenWeb.MouseEnter += (s, e) => this.btnOpenWeb.BackColor = Color.FromArgb(2, 132, 199);
		this.btnOpenWeb.MouseLeave += (s, e) => this.btnOpenWeb.BackColor = Color.FromArgb(14, 165, 233);

		// btnZalo
		this.btnZalo.BackColor = Color.FromArgb(16, 185, 129);
		this.btnZalo.Cursor = Cursors.Hand;
		this.btnZalo.FlatAppearance.BorderSize = 0;
		this.btnZalo.FlatStyle = FlatStyle.Flat;
		this.btnZalo.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.btnZalo.ForeColor = Color.White;
		this.btnZalo.Location = new Point(308, 1);
		this.btnZalo.Name = "btnZalo";
		this.btnZalo.Size = new Size(292, 36);
		this.btnZalo.TabIndex = 1;
		this.btnZalo.Text = "Liên hệ Zalo CSKH: 0359.261.551";
		this.btnZalo.UseVisualStyleBackColor = false;
		this.btnZalo.Click += new EventHandler(this.btnZalo_Click);
		this.btnZalo.MouseEnter += (s, e) => this.btnZalo.BackColor = Color.FromArgb(5, 150, 105);
		this.btnZalo.MouseLeave += (s, e) => this.btnZalo.BackColor = Color.FromArgb(16, 185, 129);

		// 
		// pnlWarning (Legal Disclaimer Alert)
		// 
		this.pnlWarning.BackColor = Color.FromArgb(254, 252, 232);
		this.pnlWarning.BorderStyle = BorderStyle.FixedSingle;
		this.pnlWarning.Controls.Add(this.lblWarnTitle);
		this.pnlWarning.Controls.Add(this.lblWarnBody);
		this.pnlWarning.Location = new Point(57, 362);
		this.pnlWarning.Name = "pnlWarning";
		this.pnlWarning.Size = new Size(600, 84);
		this.pnlWarning.TabIndex = 4;

		this.lblWarnTitle.Font = new Font("Segoe UI", 8.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblWarnTitle.ForeColor = Color.FromArgb(133, 77, 14);
		this.lblWarnTitle.Location = new Point(14, 8);
		this.lblWarnTitle.Name = "lblWarnTitle";
		this.lblWarnTitle.Size = new Size(572, 18);
		this.lblWarnTitle.TabIndex = 0;
		this.lblWarnTitle.Text = "[!]  CHÚ Ý & KHUYẾN CÁO SỬ DỤNG PHẦN MỀM:";

		this.lblWarnBody.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.lblWarnBody.ForeColor = Color.FromArgb(161, 98, 7);
		this.lblWarnBody.Location = new Point(14, 28);
		this.lblWarnBody.Name = "lblWarnBody";
		this.lblWarnBody.Size = new Size(572, 48);
		this.lblWarnBody.TabIndex = 1;
		this.lblWarnBody.Text = "Nghiêm cấm mọi hành vi sử dụng phần mềm vào các mục đích xấu, chống phá hoặc vi phạm quy định pháp luật. LunisSoftware Việt Nam hoàn toàn không chịu trách nhiệm đối với bất kỳ hành vi sử dụng sai lệch hoặc vi phạm pháp luật hiện hành của người dùng.";

		// 
		// ucContact
		// 
		this.AutoScaleMode = AutoScaleMode.None;
		this.BackColor = Color.White;
		this.Controls.Add(this.picBanner);
		this.Controls.Add(this.lblSubTitle);
		this.Controls.Add(this.pnlCard);
		this.Controls.Add(this.pnlButtons);
		this.Controls.Add(this.pnlWarning);
		this.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.Margin = new Padding(4);
		this.Name = "ucContact";
		this.Size = new Size(714, 465);
		((ISupportInitialize)(this.picBanner)).EndInit();
		this.pnlCard.ResumeLayout(false);
		this.pnlCard.PerformLayout();
		this.pnlButtons.ResumeLayout(false);
		this.pnlWarning.ResumeLayout(false);
		this.ResumeLayout(false);
	}
}
