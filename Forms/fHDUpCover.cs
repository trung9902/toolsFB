using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDUpCover : Form
{
	internal GClass4 gclass4_0 = null;

	internal string string_0;

	internal string B8A61125;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool EA148485;

	internal IContainer B80B4F03 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label5;

	internal Label label1;

	internal Button btnCancel;

	internal Button BA931F04;

	internal BunifuCards FE88CD9F;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal TextBox txtPathFolder;

	internal Button btnChonFolder;

	internal Label lblFolderInfo;

	internal CheckBox ckbXoaAnhDaDung;

	internal CheckBox ckbSkipIfHave;

	internal CheckBox ckbKhongDangFeed;

	internal CheckBox ckbBoQuaCanChinh;

	internal CheckBox ckbUuTienMbasic;

	internal Label lblDelay;

	internal NumericUpDown nudDelayFrom;

	internal Label lblDelayTo;

	internal NumericUpDown nudDelayTo;

	internal Label lblDelayUnit;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return EA148485;
		}
		[CompilerGenerated]
		set
		{
			EA148485 = value;
		}
	}

	public fHDUpCover(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			B8A61125 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			BA931F04.Text = Language.GetValue("Cập nhật");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to safely dismiss dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void fHDUpCover_Load(object sender, EventArgs e)
	{
		try
		{
			txtPathFolder.Text = gclass4_0.BDB80B23("txtPathFolder");
			ckbXoaAnhDaDung.Checked = gclass4_0.method_3("ckbXoaAnhDaDung");
			ckbSkipIfHave.Checked = gclass4_0.method_3("ckbSkipIfHave");
			ckbKhongDangFeed.Checked = gclass4_0.method_3("ckbKhongDangFeed", true);
			ckbBoQuaCanChinh.Checked = gclass4_0.method_3("ckbBoQuaCanChinh", true);
			ckbUuTienMbasic.Checked = gclass4_0.method_3("ckbUuTienMbasic");

			nudDelayFrom.Value = Math.Max(1, gclass4_0.method_2("nudDelayFrom", 3));
			nudDelayTo.Value = Math.Max((int)nudDelayFrom.Value, gclass4_0.method_2("nudDelayTo", 5));

			UpdateFolderMediaInfo();
		}
		catch
		{
		}
	}

	private void UpdateFolderMediaInfo()
	{
		try
		{
			string path = txtPathFolder.Text.Trim().Trim('"', '\'');
			if (string.IsNullOrEmpty(path))
			{
				lblFolderInfo.Text = "(Chưa chọn đường dẫn ảnh)";
				lblFolderInfo.ForeColor = Color.FromArgb(100, 116, 139);
				return;
			}
			if (File.Exists(path))
			{
				string ext = Path.GetExtension(path).ToLower();
				var validExts = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".bmp" };
				if (validExts.Contains(ext))
				{
					lblFolderInfo.Text = "✓ Đã chọn 1 file ảnh hợp lệ";
					lblFolderInfo.ForeColor = Color.FromArgb(37, 99, 235);
				}
				else
				{
					lblFolderInfo.Text = "✕ Tệp không đúng định dạng ảnh";
					lblFolderInfo.ForeColor = Color.FromArgb(220, 38, 38);
				}
			}
			else if (Directory.Exists(path))
			{
				var imgs = Commom.smethod_76(path);
				if (imgs != null && imgs.Count > 0)
				{
					lblFolderInfo.Text = $"✓ Tìm thấy {imgs.Count} ảnh bìa hợp lệ";
					lblFolderInfo.ForeColor = Color.FromArgb(16, 149, 102);
				}
				else
				{
					lblFolderInfo.Text = "✕ Thư mục không có file ảnh nào";
					lblFolderInfo.ForeColor = Color.FromArgb(220, 38, 38);
				}
			}
			else
			{
				lblFolderInfo.Text = "✕ Đường dẫn không tồn tại";
				lblFolderInfo.ForeColor = Color.FromArgb(220, 38, 38);
			}
		}
		catch
		{
			lblFolderInfo.Text = "";
		}
	}

	private void btnChonFolder_Click(object sender, EventArgs e)
	{
		try
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem mnuFolder = new ToolStripMenuItem("Chọn thư mục ảnh (Random)");
			ToolStripMenuItem mnuFile = new ToolStripMenuItem("Chọn 1 tệp ảnh chỉ định");

			mnuFolder.Click += (s, ev) =>
			{
				using (FolderBrowserDialog fbd = new FolderBrowserDialog())
				{
					fbd.Description = "Chọn thư mục chứa ảnh bìa";
					if (Directory.Exists(txtPathFolder.Text.Trim()))
					{
						fbd.SelectedPath = txtPathFolder.Text.Trim();
					}
					if (fbd.ShowDialog() == DialogResult.OK)
					{
						txtPathFolder.Text = fbd.SelectedPath;
						UpdateFolderMediaInfo();
					}
				}
			};

			mnuFile.Click += (s, ev) =>
			{
				using (OpenFileDialog ofd = new OpenFileDialog())
				{
					ofd.Title = "Chọn file ảnh bìa";
					ofd.Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.webp;*.bmp)|*.jpg;*.jpeg;*.png;*.webp;*.bmp|Tất cả tệp (*.*)|*.*";
					if (ofd.ShowDialog() == DialogResult.OK)
					{
						txtPathFolder.Text = ofd.FileName;
						UpdateFolderMediaInfo();
					}
				}
			};

			menu.Items.Add(mnuFolder);
			menu.Items.Add(mnuFile);
			menu.Show(btnChonFolder, new Point(0, btnChonFolder.Height));
		}
		catch
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					txtPathFolder.Text = fbd.SelectedPath;
					UpdateFolderMediaInfo();
				}
			}
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BA931F04_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lòng nhập tên hành động!", 3);
			return;
		}
		string folder = txtPathFolder.Text.Trim().Trim('"', '\'');
		bool isFile = File.Exists(folder);
		if (!isFile && !Commom.ValidateMediaFolder(folder, out int count, out string msg))
		{
			MsBoxHelper.Show(Language.GetValue(msg), 3);
			txtPathFolder.Focus();
			return;
		}
		if (isFile)
		{
			string ext = Path.GetExtension(folder).ToLower();
			var validExts = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".bmp" };
			if (!validExts.Contains(ext))
			{
				MsBoxHelper.Show("Tệp đã chọn không đúng định dạng ảnh (.jpg, .jpeg, .png, .webp, .bmp)!", 3);
				txtPathFolder.Focus();
				return;
			}
		}

		GClass4 gClass = new GClass4();
		gClass.method_4("txtPathFolder", txtPathFolder.Text.Trim());
		gClass.method_4("ckbXoaAnhDaDung", ckbXoaAnhDaDung.Checked);
		gClass.method_4("ckbSkipIfHave", ckbSkipIfHave.Checked);
		gClass.method_4("ckbKhongDangFeed", ckbKhongDangFeed.Checked);
		gClass.method_4("ckbBoQuaCanChinh", ckbBoQuaCanChinh.Checked);
		gClass.method_4("ckbUuTienMbasic", ckbUuTienMbasic.Checked);
		gClass.method_4("nudDelayFrom", (int)nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", (int)nudDelayTo.Value);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Bạn có muốn thêm hành động mới?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, B8A61125, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thất bại, vui lòng thử lại sau!", 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Bạn có muốn cập nhật hành động?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(string_1, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Cập nhật thất bại, vui lòng thử lại sau!", 2);
			}
		}
	}

	private void BD828C30(object sender, EventArgs e)
	{
		Close();
	}

	private void FC16B6BD(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1.5f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool BD1E3E84)
	{
		if (BD1E3E84 && B80B4F03 != null)
		{
			B80B4F03.Dispose();
		}
		base.Dispose(BD1E3E84);
	}

	private void InitializeComponent()
	{
		B80B4F03 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDUpCover));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(B80B4F03);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(B80B4F03);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		ckbSkipIfHave = new System.Windows.Forms.CheckBox();
		ckbXoaAnhDaDung = new System.Windows.Forms.CheckBox();
		ckbKhongDangFeed = new System.Windows.Forms.CheckBox();
		ckbBoQuaCanChinh = new System.Windows.Forms.CheckBox();
		ckbUuTienMbasic = new System.Windows.Forms.CheckBox();
		txtPathFolder = new System.Windows.Forms.TextBox();
		btnChonFolder = new System.Windows.Forms.Button();
		lblFolderInfo = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		lblDelay = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		lblDelayTo = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		lblDelayUnit = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		BA931F04 = new System.Windows.Forms.Button();
		FE88CD9F = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		FE88CD9F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		SuspendLayout();

		// Drag Controls
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;

		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(378, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Đổi Ảnh bìa";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;

		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(378, 31);
		pnlHeader.TabIndex = 9;

		// Minimize Button
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(314, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };

		// Close Button
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(346, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);

		// App Icon
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(5, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(30, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;

		// Main Panel
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(lblDelayUnit);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(lblDelayTo);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(lblDelay);
		panel1.Controls.Add(lblFolderInfo);
		panel1.Controls.Add(btnChonFolder);
		panel1.Controls.Add(ckbBoQuaCanChinh);
		panel1.Controls.Add(ckbKhongDangFeed);
		panel1.Controls.Add(ckbUuTienMbasic);
		panel1.Controls.Add(ckbSkipIfHave);
		panel1.Controls.Add(ckbXoaAnhDaDung);
		panel1.Controls.Add(txtPathFolder);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(BA931F04);
		panel1.Controls.Add(FE88CD9F);
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(380, 335);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(FC16B6BD);

		// Label Tên hành động
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(22, 51);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên hành động:";

		txtTenHanhDong.Location = new System.Drawing.Point(135, 48);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(220, 23);
		txtTenHanhDong.TabIndex = 0;

		// Label Thư mục ảnh
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(22, 80);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(95, 16);
		label5.TabIndex = 34;
		label5.Text = "Ảnh / Thư mục:";

		txtPathFolder.Location = new System.Drawing.Point(135, 77);
		txtPathFolder.Name = "txtPathFolder";
		txtPathFolder.Size = new System.Drawing.Size(155, 23);
		txtPathFolder.TabIndex = 1;
		txtPathFolder.TextChanged += (s, e) => { UpdateFolderMediaInfo(); };

		// Nút Chọn Folder/File
		btnChonFolder.Cursor = System.Windows.Forms.Cursors.Hand;
		btnChonFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnChonFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
		btnChonFolder.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
		btnChonFolder.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnChonFolder.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
		btnChonFolder.Location = new System.Drawing.Point(294, 76);
		btnChonFolder.Name = "btnChonFolder";
		btnChonFolder.Size = new System.Drawing.Size(61, 25);
		btnChonFolder.TabIndex = 2;
		btnChonFolder.Text = "Chọn";
		btnChonFolder.UseVisualStyleBackColor = true;
		btnChonFolder.Click += new System.EventHandler(btnChonFolder_Click);

		// Label Info ảnh tìm thấy
		lblFolderInfo.AutoSize = true;
		lblFolderInfo.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		lblFolderInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
		lblFolderInfo.Location = new System.Drawing.Point(135, 103);
		lblFolderInfo.Name = "lblFolderInfo";
		lblFolderInfo.Size = new System.Drawing.Size(150, 13);
		lblFolderInfo.TabIndex = 35;
		lblFolderInfo.Text = "(Chưa chọn đường dẫn ảnh)";

		// Checkboxes
		ckbXoaAnhDaDung.AutoSize = true;
		ckbXoaAnhDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaAnhDaDung.Location = new System.Drawing.Point(135, 124);
		ckbXoaAnhDaDung.Name = "ckbXoaAnhDaDung";
		ckbXoaAnhDaDung.Size = new System.Drawing.Size(173, 20);
		ckbXoaAnhDaDung.TabIndex = 3;
		ckbXoaAnhDaDung.Text = "Tự động xóa ảnh đã dùng";
		ckbXoaAnhDaDung.UseVisualStyleBackColor = true;

		ckbSkipIfHave.AutoSize = true;
		ckbSkipIfHave.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSkipIfHave.Location = new System.Drawing.Point(135, 146);
		ckbSkipIfHave.Name = "ckbSkipIfHave";
		ckbSkipIfHave.Size = new System.Drawing.Size(171, 20);
		ckbSkipIfHave.TabIndex = 4;
		ckbSkipIfHave.Text = "Bỏ qua nếu đã có ảnh bìa";
		ckbSkipIfHave.UseVisualStyleBackColor = true;

		ckbKhongDangFeed.AutoSize = true;
		ckbKhongDangFeed.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbKhongDangFeed.Checked = true;
		ckbKhongDangFeed.Location = new System.Drawing.Point(135, 168);
		ckbKhongDangFeed.Name = "ckbKhongDangFeed";
		ckbKhongDangFeed.Size = new System.Drawing.Size(217, 20);
		ckbKhongDangFeed.TabIndex = 5;
		ckbKhongDangFeed.Text = "Không chia sẻ lên Bảng tin (Feed)";
		ckbKhongDangFeed.UseVisualStyleBackColor = true;

		ckbBoQuaCanChinh.AutoSize = true;
		ckbBoQuaCanChinh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBoQuaCanChinh.Checked = true;
		ckbBoQuaCanChinh.Location = new System.Drawing.Point(135, 190);
		ckbBoQuaCanChinh.Name = "ckbBoQuaCanChinh";
		ckbBoQuaCanChinh.Size = new System.Drawing.Size(225, 20);
		ckbBoQuaCanChinh.TabIndex = 6;
		ckbBoQuaCanChinh.Text = "Bỏ qua căn chỉnh (Lưu thay đổi ngay)";
		ckbBoQuaCanChinh.UseVisualStyleBackColor = true;

		ckbUuTienMbasic.AutoSize = true;
		ckbUuTienMbasic.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUuTienMbasic.Location = new System.Drawing.Point(135, 212);
		ckbUuTienMbasic.Name = "ckbUuTienMbasic";
		ckbUuTienMbasic.Size = new System.Drawing.Size(195, 20);
		ckbUuTienMbasic.TabIndex = 7;
		ckbUuTienMbasic.Text = "Ưu tiên chạy bằng mbasic / mobile";
		ckbUuTienMbasic.UseVisualStyleBackColor = true;

		// Delay Controls
		lblDelay.AutoSize = true;
		lblDelay.Location = new System.Drawing.Point(22, 240);
		lblDelay.Name = "lblDelay";
		lblDelay.Size = new System.Drawing.Size(109, 16);
		lblDelay.TabIndex = 40;
		lblDelay.Text = "Chờ sau khi up:";

		nudDelayFrom.Location = new System.Drawing.Point(135, 237);
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(48, 23);
		nudDelayFrom.TabIndex = 8;
		nudDelayFrom.Value = new decimal(new int[] { 3, 0, 0, 0 });
		nudDelayFrom.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		nudDelayFrom.Maximum = new decimal(new int[] { 999, 0, 0, 0 });

		lblDelayTo.AutoSize = true;
		lblDelayTo.Location = new System.Drawing.Point(188, 240);
		lblDelayTo.Name = "lblDelayTo";
		lblDelayTo.Size = new System.Drawing.Size(28, 16);
		lblDelayTo.TabIndex = 42;
		lblDelayTo.Text = "đến";

		nudDelayTo.Location = new System.Drawing.Point(220, 237);
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(48, 23);
		nudDelayTo.TabIndex = 9;
		nudDelayTo.Value = new decimal(new int[] { 5, 0, 0, 0 });
		nudDelayTo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		nudDelayTo.Maximum = new decimal(new int[] { 999, 0, 0, 0 });

		lblDelayUnit.AutoSize = true;
		lblDelayUnit.Location = new System.Drawing.Point(273, 240);
		lblDelayUnit.Name = "lblDelayUnit";
		lblDelayUnit.Size = new System.Drawing.Size(30, 16);
		lblDelayUnit.TabIndex = 44;
		lblDelayUnit.Text = "giây";

		// Buttons
		BA931F04.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BA931F04.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		BA931F04.Cursor = System.Windows.Forms.Cursors.Hand;
		BA931F04.FlatAppearance.BorderSize = 0;
		BA931F04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BA931F04.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BA931F04.ForeColor = System.Drawing.Color.White;
		BA931F04.Location = new System.Drawing.Point(92, 285);
		BA931F04.Name = "btnAdd";
		BA931F04.Size = new System.Drawing.Size(92, 32);
		BA931F04.TabIndex = 10;
		BA931F04.Text = "Thêm";
		BA931F04.UseVisualStyleBackColor = false;
		BA931F04.Click += new System.EventHandler(BA931F04_Click);

		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(198, 285);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 32);
		btnCancel.TabIndex = 11;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(BD828C30);

		FE88CD9F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FE88CD9F.BackColor = System.Drawing.Color.White;
		FE88CD9F.BorderRadius = 0;
		FE88CD9F.BottomSahddow = true;
		FE88CD9F.color = System.Drawing.Color.FromArgb(37, 99, 235);
		FE88CD9F.Controls.Add(pnlHeader);
		FE88CD9F.LeftSahddow = false;
		FE88CD9F.Location = new System.Drawing.Point(1, 0);
		FE88CD9F.Name = "bunifuCards1";
		FE88CD9F.RightSahddow = true;
		FE88CD9F.ShadowDepth = 20;
		FE88CD9F.Size = new System.Drawing.Size(378, 37);
		FE88CD9F.TabIndex = 28;

		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(380, 335);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDUpCover";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDUpCover_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		FE88CD9F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		ResumeLayout(false);
	}
}
