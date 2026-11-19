using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDUnlockProfile : Form
{
	internal GClass4 D436FDBD = null;

	internal string C622B328;

	internal string D7B5F217;

	internal string A03F2386;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer F01F20A9 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal TextBox DC32503E;

	internal Label C8816936;

	internal Button A59ECF30;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel CF0937BE;

	internal Button A3A4A610;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel A99FBD84;

	internal ComboBox FD024187;

	internal Label label2;

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

	public fHDUnlockProfile(string E8AB251D, string string_0 = "")
	{
		InitializeComponent();
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		Boolean_0 = false;
		C622B328 = E8AB251D;
		A03F2386 = string_0;
		string aA239C = Language.GetValue(A99FBD84.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string string_ = base.Name.Substring(1);
		Class154.FA0E41AD(string_, aA239C);
		string string_2 = "";
		if (string_0 == "")
		{
			DataTable dataTable = Class154.BD904B3B(string_);
			D7B5F217 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			DC32503E.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_0);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			DC32503E.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		D436FDBD = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDUnlockProfile_Load(object sender, EventArgs e)
	{
		List<string> list_ = new List<string> { "Unlock profile", "Lock profile" };
		Commom.smethod_23(FD024187, list_);
		FD024187.SelectedIndex = D436FDBD.method_2("cbbTuyChon");
	}

	private void A3A4A610_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void A6807837(object sender, EventArgs e)
	{
		string text = DC32503E.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		D436FDBD.method_4("cbbTuyChon", FD024187.SelectedIndex);
		string text2 = D436FDBD.ED11179C();
		if (A03F2386 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(C622B328, text, D7B5F217, text2))
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
			if (Class154.smethod_13(A03F2386, text, text2))
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

	private void A59ECF30_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool D98E5C38)
	{
		if (D98E5C38 && F01F20A9 != null)
		{
			F01F20A9.Dispose();
		}
		base.Dispose(D98E5C38);
	}

	private void InitializeComponent()
	{
		F01F20A9 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDUnlockProfile));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(F01F20A9);
		A99FBD84 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(F01F20A9);
		CF0937BE = new System.Windows.Forms.Panel();
		A3A4A610 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		DC32503E = new System.Windows.Forms.TextBox();
		C8816936 = new System.Windows.Forms.Label();
		A59ECF30 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		FD024187 = new System.Windows.Forms.ComboBox();
		label2 = new System.Windows.Forms.Label();
		CF0937BE.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = A99FBD84;
		bunifuDragControl_0.Vertical = true;
		A99FBD84.BackColor = System.Drawing.Color.Transparent;
		A99FBD84.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A99FBD84.Dock = System.Windows.Forms.DockStyle.Fill;
		A99FBD84.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A99FBD84.ForeColor = System.Drawing.Color.Black;
		A99FBD84.Location = new System.Drawing.Point(0, 0);
		A99FBD84.Name = "bunifuCustomLabel1";
		A99FBD84.Size = new System.Drawing.Size(359, 31);
		A99FBD84.TabIndex = 12;
		A99FBD84.Text = "Cấu hình Unlock profile";
		A99FBD84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = CF0937BE;
		bunifuDragControl_1.Vertical = true;
		CF0937BE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CF0937BE.BackColor = System.Drawing.Color.White;
		CF0937BE.Controls.Add(A3A4A610);
		CF0937BE.Controls.Add(pictureBox1);
		CF0937BE.Controls.Add(A99FBD84);
		CF0937BE.Cursor = System.Windows.Forms.Cursors.SizeAll;
		CF0937BE.Location = new System.Drawing.Point(0, 3);
		CF0937BE.Name = "pnlHeader";
		CF0937BE.Size = new System.Drawing.Size(359, 31);
		CF0937BE.TabIndex = 9;
		A3A4A610.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A3A4A610.Cursor = System.Windows.Forms.Cursors.Hand;
		A3A4A610.FlatAppearance.BorderSize = 0;
		A3A4A610.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A3A4A610.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		A3A4A610.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(CF0937BE.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		CF0937BE.Controls.Add(btnMinimize);
		CF0937BE.Resize += (s, e) =>
		{
			if (A3A4A610 != null) A3A4A610.Location = new System.Drawing.Point(CF0937BE.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(CF0937BE.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		A3A4A610.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		A3A4A610.Text = iconClose == null ? "✕" : "";
		A3A4A610.Location = new System.Drawing.Point(328, 1);
		A3A4A610.Name = "button1";
		A3A4A610.Size = new System.Drawing.Size(30, 30);
		A3A4A610.TabIndex = 77;
		A3A4A610.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		A3A4A610.UseVisualStyleBackColor = true;
		A3A4A610.Click += new System.EventHandler(A3A4A610_Click);
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
		panel1.Controls.Add(FD024187);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(DC32503E);
		panel1.Controls.Add(C8816936);
		panel1.Controls.Add(A59ECF30);
		panel1.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 160);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		DC32503E.Location = new System.Drawing.Point(132, 49);
		DC32503E.Name = "txtTenHanhDong";
		DC32503E.Size = new System.Drawing.Size(194, 23);
		DC32503E.TabIndex = 0;
		C8816936.AutoSize = true;
		C8816936.Location = new System.Drawing.Point(27, 52);
		C8816936.Name = "label1";
		C8816936.Size = new System.Drawing.Size(98, 16);
		C8816936.TabIndex = 31;
		C8816936.Text = "Tên ha\u0300nh đô\u0323ng:";
		A59ECF30.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A59ECF30.BackColor = System.Drawing.Color.Maroon;
		A59ECF30.Cursor = System.Windows.Forms.Cursors.Hand;
		A59ECF30.FlatAppearance.BorderSize = 0;
		A59ECF30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A59ECF30.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A59ECF30.ForeColor = System.Drawing.Color.White;
		A59ECF30.Location = new System.Drawing.Point(189, 116);
		A59ECF30.Name = "btnCancel";
		A59ECF30.Size = new System.Drawing.Size(92, 29);
		A59ECF30.TabIndex = 10;
		A59ECF30.Text = "Đóng";
		A59ECF30.UseVisualStyleBackColor = false;
		A59ECF30.Click += new System.EventHandler(A59ECF30_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 116);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(A6807837);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(CF0937BE);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(359, 37);
		bunifuCards1.TabIndex = 28;
		FD024187.Cursor = System.Windows.Forms.Cursors.Hand;
		FD024187.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		FD024187.FormattingEnabled = true;
		FD024187.Location = new System.Drawing.Point(132, 78);
		FD024187.Name = "cbbTuyChon";
		FD024187.Size = new System.Drawing.Size(194, 24);
		FD024187.TabIndex = 35;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 81);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(64, 16);
		label2.TabIndex = 34;
		label2.Text = "Tùy chọn:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 160);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDUnlockProfile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDUnlockProfile_Load);
		CF0937BE.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
