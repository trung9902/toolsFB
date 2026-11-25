using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDangXuatThietBiCu : Form
{
	internal GClass4 gclass4_0 = null;

	internal string string_0;

	internal string F798370E;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool D71BDA06;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel C33FAB04;

	internal TextBox D18C4D0C;

	internal Label label1;

	internal Button btnCancel;

	internal Button B0801497;

	internal BunifuCards D7114815;

	internal Panel pnlHeader;

	internal Button AD18588D;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel D119BA1F;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return D71BDA06;
		}
		[CompilerGenerated]
		set
		{
			D71BDA06 = value;
		}
	}

	public fHDDangXuatThietBiCu(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(D119BA1F.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			F798370E = dataTable.Rows[0]["Id_TuongTac"].ToString();
			D18C4D0C.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			B0801497.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			D18C4D0C.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
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

	private void B39DF133(object sender, EventArgs e)
	{
	}

	private void AD18588D_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B0801497_Click(object sender, EventArgs e)
	{
		string text = D18C4D0C.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		string e013A = gclass4_0.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, F798370E, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?") == DialogResult.Yes)
		{
			if (Class154.smethod_13(string_1, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C33FAB04_Paint(object sender, PaintEventArgs e)
	{
		if (C33FAB04.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, C33FAB04.ClientSize.Width - num, C33FAB04.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDangXuatThietBiCu));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		D119BA1F = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		AD18588D = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		C33FAB04 = new System.Windows.Forms.Panel();
		D18C4D0C = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		B0801497 = new System.Windows.Forms.Button();
		D7114815 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		C33FAB04.SuspendLayout();
		D7114815.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = D119BA1F;
		bunifuDragControl_0.Vertical = true;
		D119BA1F.BackColor = System.Drawing.Color.Transparent;
		D119BA1F.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D119BA1F.Dock = System.Windows.Forms.DockStyle.Fill;
		D119BA1F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D119BA1F.ForeColor = System.Drawing.Color.Black;
		D119BA1F.Location = new System.Drawing.Point(0, 0);
		D119BA1F.Name = "bunifuCustomLabel1";
		D119BA1F.Size = new System.Drawing.Size(359, 31);
		D119BA1F.TabIndex = 12;
		D119BA1F.Text = "Cấu hình Đăng xuất thiết bị cũ";
		D119BA1F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		pnlHeader.Controls.Add(AD18588D);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(D119BA1F);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (AD18588D != null) AD18588D.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};

		// Minimize Button
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };

		AD18588D.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		AD18588D.Cursor = System.Windows.Forms.Cursors.Hand;
		AD18588D.FlatAppearance.BorderSize = 0;
		AD18588D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AD18588D.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AD18588D.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		AD18588D.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		AD18588D.Text = iconClose == null ? "✕" : "";
		AD18588D.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		AD18588D.Name = "button1";
		AD18588D.Size = new System.Drawing.Size(30, 30);
		AD18588D.TabIndex = 77;
		AD18588D.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		AD18588D.UseVisualStyleBackColor = true;
		AD18588D.Click += new System.EventHandler(AD18588D_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		C33FAB04.BackColor = System.Drawing.Color.White;
		C33FAB04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C33FAB04.Controls.Add(D18C4D0C);
		C33FAB04.Controls.Add(label1);
		C33FAB04.Controls.Add(btnCancel);
		C33FAB04.Controls.Add(B0801497);
		C33FAB04.Controls.Add(D7114815);
		C33FAB04.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		C33FAB04.Cursor = System.Windows.Forms.Cursors.Arrow;
		C33FAB04.Dock = System.Windows.Forms.DockStyle.Fill;
		C33FAB04.Location = new System.Drawing.Point(0, 0);
		C33FAB04.Name = "panel1";
		C33FAB04.Size = new System.Drawing.Size(362, 132);
		C33FAB04.TabIndex = 0;
		C33FAB04.Paint += new System.Windows.Forms.PaintEventHandler(C33FAB04_Paint);
		D18C4D0C.Location = new System.Drawing.Point(132, 49);
		D18C4D0C.Name = "txtTenHanhDong";
		D18C4D0C.Size = new System.Drawing.Size(194, 23);
		D18C4D0C.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(189, 88);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		B0801497.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B0801497.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		B0801497.Cursor = System.Windows.Forms.Cursors.Hand;
		B0801497.FlatAppearance.BorderSize = 0;
		B0801497.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B0801497.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B0801497.ForeColor = System.Drawing.Color.White;
		B0801497.Location = new System.Drawing.Point(82, 88);
		B0801497.Name = "btnAdd";
		B0801497.Size = new System.Drawing.Size(92, 29);
		B0801497.TabIndex = 9;
		B0801497.Text = "Thêm";
		B0801497.UseVisualStyleBackColor = false;
		B0801497.Click += new System.EventHandler(B0801497_Click);
		D7114815.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D7114815.BackColor = System.Drawing.Color.White;
		D7114815.BorderRadius = 0;
		D7114815.BottomSahddow = true;
		D7114815.color = System.Drawing.Color.DarkViolet;
		D7114815.Controls.Add(pnlHeader);
		D7114815.LeftSahddow = false;
		D7114815.Location = new System.Drawing.Point(1, 0);
		D7114815.Name = "bunifuCards1";
		D7114815.RightSahddow = true;
		D7114815.ShadowDepth = 20;
		D7114815.Size = new System.Drawing.Size(359, 37);
		D7114815.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 132);
		base.Controls.Add(C33FAB04);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDangXuatThietBiCu";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(B39DF133);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		C33FAB04.ResumeLayout(false);
		C33FAB04.PerformLayout();
		D7114815.ResumeLayout(false);
		ResumeLayout(false);
	}
}
