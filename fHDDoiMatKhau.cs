using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDoiMatKhau : Form
{
	internal GClass4 gclass4_0;

	internal string B21F7533;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel EA04B80E;

	internal TextBox FFA990AA;

	internal Label A21B4292;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards F4BDD6B2;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox AA8BD21C;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label AB032D8C;

	internal TextBox txtNewPass;

	internal Button button2;

	internal ComboBox cbbTypeDoiMatKhau;

	internal Label label3;

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

	public fHDDoiMatKhau(string DEA472A3, string string_2 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		B21F7533 = DEA472A3;
		string_1 = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			FFA990AA.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			FFA990AA.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
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

	private void F8BE5B81(object sender, EventArgs e)
	{
		DC0C9BB8();
		try
		{
			cbbTypeDoiMatKhau.SelectedValue = gclass4_0.BDB80B23("cbbTypeDoiMatKhau", "2");
			txtNewPass.Text = gclass4_0.BDB80B23("txtNewPass");
		}
		catch
		{
		}
	}

	private void DC0C9BB8()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("2", "Sư\u0309 du\u0323ng Account Center");
		dictionary.Add("1", "Sử dụng link hacked");
		dictionary.Add("3", "Tut không câ\u0300n xa\u0301c minh otp");
		Commom.smethod_24(cbbTypeDoiMatKhau, dictionary);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = FFA990AA.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("txtNewPass", txtNewPass.Text.Trim());
		gClass.method_4("cbbTypeDoiMatKhau", cbbTypeDoiMatKhau.SelectedValue);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(B21F7533, text, string_0, e013A))
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

	private void E98CB007(object sender, PaintEventArgs e)
	{
		if (EA04B80E.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, EA04B80E.ClientSize.Width - num, EA04B80E.ClientSize.Height - num));
		}
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		string object_ = "Có thể sử dụng ký tự * để random 1 ký tự ngẫu nhiên!\r\nVí dụ: MIN****** => MINdfghta";
		MsBoxHelper.Show(object_);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDoiMatKhau));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		AA8BD21C = new System.Windows.Forms.PictureBox();
		EA04B80E = new System.Windows.Forms.Panel();
		cbbTypeDoiMatKhau = new System.Windows.Forms.ComboBox();
		button2 = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		AB032D8C = new System.Windows.Forms.Label();
		txtNewPass = new System.Windows.Forms.TextBox();
		FFA990AA = new System.Windows.Forms.TextBox();
		A21B4292 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		F4BDD6B2 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)AA8BD21C).BeginInit();
		EA04B80E.SuspendLayout();
		F4BDD6B2.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(345, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Đổi mật khẩu";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(AA8BD21C);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(345, 31);
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

		// Close Button
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		AA8BD21C.Cursor = System.Windows.Forms.Cursors.Default;
		AA8BD21C.Image = Class155.DD225F0D;
		AA8BD21C.Location = new System.Drawing.Point(3, 2);
		AA8BD21C.Name = "pictureBox1";
		AA8BD21C.Size = new System.Drawing.Size(34, 27);
		AA8BD21C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		AA8BD21C.TabIndex = 76;
		AA8BD21C.TabStop = false;
		EA04B80E.BackColor = System.Drawing.Color.White;
		EA04B80E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		EA04B80E.Controls.Add(cbbTypeDoiMatKhau);
		EA04B80E.Controls.Add(button2);
		EA04B80E.Controls.Add(label3);
		EA04B80E.Controls.Add(AB032D8C);
		EA04B80E.Controls.Add(txtNewPass);
		EA04B80E.Controls.Add(FFA990AA);
		EA04B80E.Controls.Add(A21B4292);
		EA04B80E.Controls.Add(btnCancel);
		EA04B80E.Controls.Add(btnAdd);
		EA04B80E.Controls.Add(F4BDD6B2);
		EA04B80E.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		EA04B80E.Cursor = System.Windows.Forms.Cursors.Arrow;
		EA04B80E.Dock = System.Windows.Forms.DockStyle.Fill;
		EA04B80E.Location = new System.Drawing.Point(0, 0);
		EA04B80E.Name = "panel1";
		EA04B80E.Size = new System.Drawing.Size(348, 191);
		EA04B80E.TabIndex = 0;
		EA04B80E.Paint += new System.Windows.Forms.PaintEventHandler(E98CB007);
		cbbTypeDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeDoiMatKhau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeDoiMatKhau.FormattingEnabled = true;
		cbbTypeDoiMatKhau.Location = new System.Drawing.Point(125, 78);
		cbbTypeDoiMatKhau.Name = "cbbTypeDoiMatKhau";
		cbbTypeDoiMatKhau.Size = new System.Drawing.Size(194, 24);
		cbbTypeDoiMatKhau.TabIndex = 153;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button2.Location = new System.Drawing.Point(295, 107);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(24, 24);
		button2.TabIndex = 152;
		button2.Text = "?";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(20, 81);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(64, 16);
		label3.TabIndex = 31;
		label3.Text = "Tùy chọn:";
		AB032D8C.AutoSize = true;
		AB032D8C.Location = new System.Drawing.Point(20, 111);
		AB032D8C.Name = "label2";
		AB032D8C.Size = new System.Drawing.Size(89, 16);
		AB032D8C.TabIndex = 31;
		AB032D8C.Text = "Mật khẩu mới:";
		txtNewPass.Location = new System.Drawing.Point(125, 108);
		txtNewPass.Name = "txtNewPass";
		txtNewPass.Size = new System.Drawing.Size(167, 23);
		txtNewPass.TabIndex = 0;
		FFA990AA.Location = new System.Drawing.Point(125, 49);
		FFA990AA.Name = "txtTenHanhDong";
		FFA990AA.Size = new System.Drawing.Size(194, 23);
		FFA990AA.TabIndex = 0;
		A21B4292.AutoSize = true;
		A21B4292.Location = new System.Drawing.Point(20, 52);
		A21B4292.Name = "label1";
		A21B4292.Size = new System.Drawing.Size(98, 16);
		A21B4292.TabIndex = 31;
		A21B4292.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(184, 148);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(77, 148);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		F4BDD6B2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F4BDD6B2.BackColor = System.Drawing.Color.White;
		F4BDD6B2.BorderRadius = 0;
		F4BDD6B2.BottomSahddow = true;
		F4BDD6B2.color = System.Drawing.Color.DarkViolet;
		F4BDD6B2.Controls.Add(pnlHeader);
		F4BDD6B2.LeftSahddow = false;
		F4BDD6B2.Location = new System.Drawing.Point(1, 0);
		F4BDD6B2.Name = "bunifuCards1";
		F4BDD6B2.RightSahddow = true;
		F4BDD6B2.ShadowDepth = 20;
		F4BDD6B2.Size = new System.Drawing.Size(345, 37);
		F4BDD6B2.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(348, 191);
		base.Controls.Add(EA04B80E);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDoiMatKhau";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(F8BE5B81);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)AA8BD21C).EndInit();
		EA04B80E.ResumeLayout(false);
		EA04B80E.PerformLayout();
		F4BDD6B2.ResumeLayout(false);
		ResumeLayout(false);
	}
}
