using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDOnOff2FA : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string A72A892E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer F12C2B1B = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button D384771E;

	internal Button BB05100C;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox B324839B;

	internal BunifuCustomLabel E200F2A4;

	internal RadioButton EC01C225;

	internal RadioButton FE2A8804;

	internal Panel plBat2FA;

	internal RadioButton rbXoa2FACu;

	internal RadioButton DCAA1523;

	internal RadioButton rbKhongBat2FA;

	internal Label label2;

	internal ComboBox A1825C1C;

	internal Label E13F0FB6;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public fHDOnOff2FA(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		A72A892E = string_3;
		string aA239C = Language.GetValue(E200F2A4.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			BB05100C.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
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

	private void fHDOnOff2FA_Load(object sender, EventArgs e)
	{
		try
		{
			List<string> list_ = new List<string> { "Bật", "Tắt" };
			Commom.smethod_23(A1825C1C, list_);
			A1825C1C.SelectedIndex = gclass4_0.method_2("cbbTuyChon");
			if (gclass4_0.method_2("typeOnOff2FA") == 0)
			{
				FE2A8804.Checked = true;
			}
			else
			{
				EC01C225.Checked = true;
			}
			if (gclass4_0.method_2("neuDaCo2FA") == 0)
			{
				rbKhongBat2FA.Checked = true;
			}
			else if (gclass4_0.method_2("neuDaCo2FA") == 1)
			{
				DCAA1523.Checked = true;
			}
			else
			{
				rbXoa2FACu.Checked = true;
			}
			method_0(null, null);
			EC2FA93E(null, null);
		}
		catch
		{
		}
	}

	private void EAB38AB3(object sender, EventArgs e)
	{
		Close();
	}

	private void BB05100C_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("cbbTuyChon", A1825C1C.SelectedIndex);
		if (FE2A8804.Checked)
		{
			gClass.method_4("typeOnOff2FA", 0);
		}
		else
		{
			gClass.method_4("typeOnOff2FA", 1);
		}
		if (rbKhongBat2FA.Checked)
		{
			gClass.method_4("neuDaCo2FA", 0);
		}
		else if (DCAA1523.Checked)
		{
			gClass.method_4("neuDaCo2FA", 1);
		}
		else
		{
			gClass.method_4("neuDaCo2FA", 2);
		}
		string e013A = gClass.ED11179C();
		if (A72A892E == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					Boolean_0 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
		{
			if (Class154.smethod_13(A72A892E, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void C91EA48C(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void EC2FA93E(object sender, EventArgs e)
	{
		plBat2FA.Enabled = EC01C225.Checked;
	}

	private void B324839B_Click(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && F12C2B1B != null)
		{
			F12C2B1B.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		F12C2B1B = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDOnOff2FA));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F12C2B1B);
		E200F2A4 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(F12C2B1B);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		B324839B = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		A1825C1C = new System.Windows.Forms.ComboBox();
		E13F0FB6 = new System.Windows.Forms.Label();
		plBat2FA = new System.Windows.Forms.Panel();
		rbXoa2FACu = new System.Windows.Forms.RadioButton();
		DCAA1523 = new System.Windows.Forms.RadioButton();
		rbKhongBat2FA = new System.Windows.Forms.RadioButton();
		label2 = new System.Windows.Forms.Label();
		EC01C225 = new System.Windows.Forms.RadioButton();
		FE2A8804 = new System.Windows.Forms.RadioButton();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		D384771E = new System.Windows.Forms.Button();
		BB05100C = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B324839B).BeginInit();
		panel1.SuspendLayout();
		plBat2FA.SuspendLayout();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = E200F2A4;
		bunifuDragControl_0.Vertical = true;
		E200F2A4.BackColor = System.Drawing.Color.Transparent;
		E200F2A4.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E200F2A4.Dock = System.Windows.Forms.DockStyle.Fill;
		E200F2A4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E200F2A4.ForeColor = System.Drawing.Color.Black;
		E200F2A4.Location = new System.Drawing.Point(0, 0);
		E200F2A4.Name = "bunifuCustomLabel1";
		E200F2A4.Size = new System.Drawing.Size(358, 31);
		E200F2A4.TabIndex = 12;
		E200F2A4.Text = "Cấu hình Bật - Tắt 2FA";
		E200F2A4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		pnlHeader.Controls.Add(B324839B);
		pnlHeader.Controls.Add(E200F2A4);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(358, 31);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
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

		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(EAB38AB3);
		B324839B.Cursor = System.Windows.Forms.Cursors.Default;
		B324839B.Image = Class155.DD225F0D;
		B324839B.Location = new System.Drawing.Point(3, 2);
		B324839B.Name = "pictureBox1";
		B324839B.Size = new System.Drawing.Size(34, 27);
		B324839B.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		B324839B.TabIndex = 76;
		B324839B.TabStop = false;
		B324839B.Click += new System.EventHandler(B324839B_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(A1825C1C);
		panel1.Controls.Add(E13F0FB6);
		panel1.Controls.Add(plBat2FA);
		panel1.Controls.Add(EC01C225);
		panel1.Controls.Add(FE2A8804);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(D384771E);
		panel1.Controls.Add(BB05100C);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(361, 167);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		A1825C1C.Cursor = System.Windows.Forms.Cursors.Hand;
		A1825C1C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A1825C1C.FormattingEnabled = true;
		A1825C1C.Location = new System.Drawing.Point(131, 78);
		A1825C1C.Name = "cbbTuyChon";
		A1825C1C.Size = new System.Drawing.Size(194, 24);
		A1825C1C.TabIndex = 50;
		E13F0FB6.AutoSize = true;
		E13F0FB6.Location = new System.Drawing.Point(26, 81);
		E13F0FB6.Name = "label3";
		E13F0FB6.Size = new System.Drawing.Size(64, 16);
		E13F0FB6.TabIndex = 49;
		E13F0FB6.Text = "Tùy chọn:";
		plBat2FA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plBat2FA.Controls.Add(rbXoa2FACu);
		plBat2FA.Controls.Add(DCAA1523);
		plBat2FA.Controls.Add(rbKhongBat2FA);
		plBat2FA.Controls.Add(label2);
		plBat2FA.Location = new System.Drawing.Point(131, 297);
		plBat2FA.Name = "plBat2FA";
		plBat2FA.Size = new System.Drawing.Size(204, 97);
		plBat2FA.TabIndex = 48;
		rbXoa2FACu.AutoSize = true;
		rbXoa2FACu.Cursor = System.Windows.Forms.Cursors.Hand;
		rbXoa2FACu.Location = new System.Drawing.Point(6, 72);
		rbXoa2FACu.Name = "rbXoa2FACu";
		rbXoa2FACu.Size = new System.Drawing.Size(193, 20);
		rbXoa2FACu.TabIndex = 34;
		rbXoa2FACu.TabStop = true;
		rbXoa2FACu.Text = "Xóa 2FA cũ rồi thêm 2FA mới";
		rbXoa2FACu.UseVisualStyleBackColor = true;
		DCAA1523.AutoSize = true;
		DCAA1523.Cursor = System.Windows.Forms.Cursors.Hand;
		DCAA1523.Location = new System.Drawing.Point(6, 47);
		DCAA1523.Name = "rbGiu2FACu";
		DCAA1523.Size = new System.Drawing.Size(188, 20);
		DCAA1523.TabIndex = 33;
		DCAA1523.TabStop = true;
		DCAA1523.Text = "Giữ 2FA cũ và thêm 2FA mới";
		DCAA1523.UseVisualStyleBackColor = true;
		rbKhongBat2FA.AutoSize = true;
		rbKhongBat2FA.Cursor = System.Windows.Forms.Cursors.Hand;
		rbKhongBat2FA.Location = new System.Drawing.Point(6, 22);
		rbKhongBat2FA.Name = "rbKhongBat2FA";
		rbKhongBat2FA.Size = new System.Drawing.Size(134, 20);
		rbKhongBat2FA.TabIndex = 32;
		rbKhongBat2FA.TabStop = true;
		rbKhongBat2FA.Text = "Không bật 2FA nữa";
		rbKhongBat2FA.UseVisualStyleBackColor = true;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(3, 2);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(169, 16);
		label2.TabIndex = 31;
		label2.Text = "Nếu tài khoản đã có 2FA thì:";
		EC01C225.AutoSize = true;
		EC01C225.Cursor = System.Windows.Forms.Cursors.Hand;
		EC01C225.Location = new System.Drawing.Point(30, 297);
		EC01C225.Name = "rbBat2FA";
		EC01C225.Size = new System.Drawing.Size(69, 20);
		EC01C225.TabIndex = 47;
		EC01C225.Text = "Bật 2FA";
		EC01C225.UseVisualStyleBackColor = true;
		EC01C225.CheckedChanged += new System.EventHandler(EC2FA93E);
		FE2A8804.AutoSize = true;
		FE2A8804.Checked = true;
		FE2A8804.Cursor = System.Windows.Forms.Cursors.Hand;
		FE2A8804.Location = new System.Drawing.Point(29, 273);
		FE2A8804.Name = "rbTat2FA";
		FE2A8804.Size = new System.Drawing.Size(70, 20);
		FE2A8804.TabIndex = 47;
		FE2A8804.TabStop = true;
		FE2A8804.Text = "Tắt 2FA";
		FE2A8804.UseVisualStyleBackColor = true;
		txtTenHanhDong.Location = new System.Drawing.Point(131, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
		txtTenHanhDong.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(26, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		D384771E.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D384771E.BackColor = System.Drawing.Color.Maroon;
		D384771E.Cursor = System.Windows.Forms.Cursors.Hand;
		D384771E.FlatAppearance.BorderSize = 0;
		D384771E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D384771E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D384771E.ForeColor = System.Drawing.Color.White;
		D384771E.Location = new System.Drawing.Point(187, 122);
		D384771E.Name = "btnCancel";
		D384771E.Size = new System.Drawing.Size(92, 29);
		D384771E.TabIndex = 7;
		D384771E.Text = "Đóng";
		D384771E.UseVisualStyleBackColor = false;
		D384771E.Click += new System.EventHandler(C91EA48C);
		BB05100C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BB05100C.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		BB05100C.Cursor = System.Windows.Forms.Cursors.Hand;
		BB05100C.FlatAppearance.BorderSize = 0;
		BB05100C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BB05100C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BB05100C.ForeColor = System.Drawing.Color.White;
		BB05100C.Location = new System.Drawing.Point(80, 122);
		BB05100C.Name = "btnAdd";
		BB05100C.Size = new System.Drawing.Size(92, 29);
		BB05100C.TabIndex = 6;
		BB05100C.Text = "Thêm";
		BB05100C.UseVisualStyleBackColor = false;
		BB05100C.Click += new System.EventHandler(BB05100C_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(358, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(361, 167);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDOnOff2FA";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDOnOff2FA_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)B324839B).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plBat2FA.ResumeLayout(false);
		plBat2FA.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
