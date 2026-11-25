using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDXoaSdt : Form
{
	internal GClass4 F598EA03 = null;

	internal string B1A8A6B9;

	internal string F6976E80;

	internal string A03C1803;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool EC81FAA8;

	internal IContainer E68B8B84 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel panel1;

	internal TextBox D70FE5A9;

	internal Label B005D7A7;

	internal Button BBA6930A;

	internal Button btnAdd;

	internal BunifuCards DF2455B6;

	internal Panel E713F7A0;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal ComboBox EA354D1F;

	internal Label label10;

	public static bool AB196321
	{
		[CompilerGenerated]
		get
		{
			return EC81FAA8;
		}
		[CompilerGenerated]
		set
		{
			EC81FAA8 = value;
		}
	}

	public fHDXoaSdt(string string_0, string string_1 = "")
	{
		InitializeComponent();
		AB196321 = false;
		B1A8A6B9 = string_0;
		A03C1803 = string_1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string string_2 = base.Name.Substring(1);
		Class154.FA0E41AD(string_2, aA239C);
		string string_3 = "";
		if (string_1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(string_2);
			F6976E80 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			D70FE5A9.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_1);
			string_3 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			D70FE5A9.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		F598EA03 = new GClass4(string_3, F79F9AB5: true);
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

	private void fHDXoaSdt_Load(object sender, EventArgs e)
	{
		try
		{
			method_0();
			EA354D1F.SelectedValue = F598EA03.BDB80B23("cbbFacebookWeb", "3");
		}
		catch (Exception)
		{
		}
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("3", "Sử dụng Accounts Center");
		dictionary.Add("1", "Sử dụng m.fb");
		dictionary.Add("4", "Sử dụng mbasic");
		dictionary.Add("0", "Sử dụng www");
		dictionary.Add("2", "Sử dụng tut không pass");
		Commom.smethod_24(EA354D1F, dictionary);
	}

	private void A028A409(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = D70FE5A9.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		F598EA03.method_4("cbbFacebookWeb", EA354D1F.SelectedValue);
		string text2 = F598EA03.ED11179C();
		if (A03C1803 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(B1A8A6B9, text, F6976E80, text2))
				{
					AB196321 = true;
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
			if (Class154.smethod_13(A03C1803, text, text2))
			{
				AB196321 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void C1309598(object sender, EventArgs e)
	{
		Close();
	}

	private void C00AEB14(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && E68B8B84 != null)
		{
			E68B8B84.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		E68B8B84 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDXoaSdt));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(E68B8B84);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(E68B8B84);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		E713F7A0 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		EA354D1F = new System.Windows.Forms.ComboBox();
		label10 = new System.Windows.Forms.Label();
		D70FE5A9 = new System.Windows.Forms.TextBox();
		B005D7A7 = new System.Windows.Forms.Label();
		BBA6930A = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		DF2455B6 = new Bunifu.Framework.UI.BunifuCards();
		E713F7A0.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		DF2455B6.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Xóa Sđt";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = E713F7A0;
		bunifuDragControl_1.Vertical = true;
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		E713F7A0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E713F7A0.BackColor = System.Drawing.Color.White;
		E713F7A0.Controls.Add(btnMinimize);
		E713F7A0.Controls.Add(button1);
		E713F7A0.Controls.Add(pictureBox1);
		E713F7A0.Controls.Add(bunifuCustomLabel1);
		E713F7A0.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E713F7A0.Location = new System.Drawing.Point(0, 3);
		E713F7A0.Name = "pnlHeader";
		E713F7A0.Size = new System.Drawing.Size(359, 31);
		E713F7A0.TabIndex = 9;
		E713F7A0.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(E713F7A0.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(E713F7A0.Width - 68, 1);
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
		btnMinimize.Location = new System.Drawing.Point(E713F7A0.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };

		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(E713F7A0.Width - 34, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(A028A409);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(EA354D1F);
		panel1.Controls.Add(label10);
		panel1.Controls.Add(D70FE5A9);
		panel1.Controls.Add(B005D7A7);
		panel1.Controls.Add(BBA6930A);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(DF2455B6);
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 165);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(C00AEB14);
		EA354D1F.Cursor = System.Windows.Forms.Cursors.Hand;
		EA354D1F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		EA354D1F.DropDownWidth = 200;
		EA354D1F.FormattingEnabled = true;
		EA354D1F.Location = new System.Drawing.Point(132, 78);
		EA354D1F.Name = "cbbFacebookWeb";
		EA354D1F.Size = new System.Drawing.Size(194, 24);
		EA354D1F.TabIndex = 193;
		label10.AutoSize = true;
		label10.Location = new System.Drawing.Point(27, 81);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(64, 16);
		label10.TabIndex = 192;
		label10.Text = "Tùy chọn:";
		D70FE5A9.Location = new System.Drawing.Point(132, 49);
		D70FE5A9.Name = "txtTenHanhDong";
		D70FE5A9.Size = new System.Drawing.Size(194, 23);
		D70FE5A9.TabIndex = 0;
		B005D7A7.AutoSize = true;
		B005D7A7.Location = new System.Drawing.Point(27, 52);
		B005D7A7.Name = "label1";
		B005D7A7.Size = new System.Drawing.Size(98, 16);
		B005D7A7.TabIndex = 31;
		B005D7A7.Text = "Tên ha\u0300nh đô\u0323ng:";
		BBA6930A.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BBA6930A.BackColor = System.Drawing.Color.Maroon;
		BBA6930A.Cursor = System.Windows.Forms.Cursors.Hand;
		BBA6930A.FlatAppearance.BorderSize = 0;
		BBA6930A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BBA6930A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BBA6930A.ForeColor = System.Drawing.Color.White;
		BBA6930A.Location = new System.Drawing.Point(189, 121);
		BBA6930A.Name = "btnCancel";
		BBA6930A.Size = new System.Drawing.Size(92, 29);
		BBA6930A.TabIndex = 10;
		BBA6930A.Text = "Đóng";
		BBA6930A.UseVisualStyleBackColor = false;
		BBA6930A.Click += new System.EventHandler(C1309598);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 121);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		DF2455B6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DF2455B6.BackColor = System.Drawing.Color.White;
		DF2455B6.BorderRadius = 0;
		DF2455B6.BottomSahddow = true;
		DF2455B6.color = System.Drawing.Color.DarkViolet;
		DF2455B6.Controls.Add(E713F7A0);
		DF2455B6.LeftSahddow = false;
		DF2455B6.Location = new System.Drawing.Point(1, 0);
		DF2455B6.Name = "bunifuCards1";
		DF2455B6.RightSahddow = true;
		DF2455B6.ShadowDepth = 20;
		DF2455B6.Size = new System.Drawing.Size(359, 37);
		DF2455B6.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 165);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDXoaSdt";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDXoaSdt_Load);
		E713F7A0.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		DF2455B6.ResumeLayout(false);
		ResumeLayout(false);
	}
}
