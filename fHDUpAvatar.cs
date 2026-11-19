using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDUpAvatar : Form
{
	internal GClass4 gclass4_0 = null;

	internal string EB11EC96;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool FDAF3EB8;

	internal IContainer D92EFF0D = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel panel1;

	internal TextBox D910D48F;

	internal Label label5;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards F08AD02A;

	internal Panel pnlHeader;

	internal Button AA02F2BB;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal TextBox F3826B23;

	internal CheckBox EA895D92;

	internal CheckBox ckbSkipIfHave;

	internal CheckBox ckbThemKhungAvatar;

	internal CheckBox ckbBoQuaCatAnh;

	internal CheckBox ckbUuTienMbasic;

	public static bool C91040A6
	{
		[CompilerGenerated]
		get
		{
			return FDAF3EB8;
		}
		[CompilerGenerated]
		set
		{
			FDAF3EB8 = value;
		}
	}

	public fHDUpAvatar(string E1AF3099, string E6B0270C = "")
	{
		InitializeComponent();
		C91040A6 = false;
		EB11EC96 = E1AF3099;
		string_1 = E6B0270C;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (E6B0270C == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			D910D48F.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(E6B0270C);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			D910D48F.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
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

	private void fHDUpAvatar_Load(object sender, EventArgs e)
	{
		try
		{
			F3826B23.Text = gclass4_0.BDB80B23("txtPathFolder");
			Commom.AttachFolderPicker(F3826B23);
			EA895D92.Checked = gclass4_0.method_3("ckbXoaAnhDaDung");
			ckbThemKhungAvatar.Checked = gclass4_0.method_3("ckbThemKhungAvatar");
			ckbSkipIfHave.Checked = gclass4_0.method_3("ckbSkipIfHave");
			ckbBoQuaCatAnh.Checked = gclass4_0.method_3("ckbBoQuaCatAnh", true);
			ckbUuTienMbasic.Checked = gclass4_0.method_3("ckbUuTienMbasic");
			ckbUuTienMbasic_CheckedChanged(null, null);
		}
		catch
		{
		}
	}

	private void AA02F2BB_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = D910D48F.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		_ = F3826B23.Text;
		GClass4 gClass = new GClass4();
		gClass.method_4("txtPathFolder", F3826B23.Text);
		gClass.method_4("ckbXoaAnhDaDung", EA895D92.Checked);
		gClass.method_4("ckbThemKhungAvatar", ckbThemKhungAvatar.Checked);
		gClass.method_4("ckbSkipIfHave", ckbSkipIfHave.Checked);
		gClass.method_4("ckbBoQuaCatAnh", ckbBoQuaCatAnh.Checked);
		gClass.method_4("ckbUuTienMbasic", ckbUuTienMbasic.Checked);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(EB11EC96, text, string_0, e013A))
				{
					C91040A6 = true;
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
				C91040A6 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void F508502B(object sender, EventArgs e)
	{
		Close();
	}

	private void BDB802B7(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void AA125C84(object sender, EventArgs e)
	{
	}

	private void ckbUuTienMbasic_CheckedChanged(object sender, EventArgs e)
	{
		if (ckbUuTienMbasic.Checked)
		{
			ckbThemKhungAvatar.Checked = false;
			ckbThemKhungAvatar.Enabled = false;
		}
		else
		{
			ckbThemKhungAvatar.Enabled = true;
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D92EFF0D != null)
		{
			D92EFF0D.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		D92EFF0D = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDUpAvatar));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(D92EFF0D);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(D92EFF0D);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		AA02F2BB = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		ckbSkipIfHave = new System.Windows.Forms.CheckBox();
		F3826B23 = new System.Windows.Forms.TextBox();
		D910D48F = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		F08AD02A = new Bunifu.Framework.UI.BunifuCards();
		ckbThemKhungAvatar = new System.Windows.Forms.CheckBox();
		ckbBoQuaCatAnh = new System.Windows.Forms.CheckBox();
		EA895D92 = new System.Windows.Forms.CheckBox();
		ckbUuTienMbasic = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		F08AD02A.SuspendLayout();
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
		bunifuCustomLabel1.Text = "Cấu hình Up Avatar";
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
		pnlHeader.Controls.Add(AA02F2BB);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (AA02F2BB != null) AA02F2BB.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
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

		AA02F2BB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		AA02F2BB.Cursor = System.Windows.Forms.Cursors.Hand;
		AA02F2BB.FlatAppearance.BorderSize = 0;
		AA02F2BB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AA02F2BB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AA02F2BB.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		AA02F2BB.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		AA02F2BB.Text = iconClose == null ? "✕" : "";
		AA02F2BB.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		AA02F2BB.Name = "button1";
		AA02F2BB.Size = new System.Drawing.Size(30, 30);
		AA02F2BB.TabIndex = 77;
		AA02F2BB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		AA02F2BB.UseVisualStyleBackColor = true;
		AA02F2BB.Click += new System.EventHandler(AA02F2BB_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(AA125C84);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(ckbUuTienMbasic);
		panel1.Controls.Add(ckbSkipIfHave);
		panel1.Controls.Add(F3826B23);
		panel1.Controls.Add(D910D48F);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(F08AD02A);
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Controls.Add(ckbThemKhungAvatar);
		panel1.Controls.Add(ckbBoQuaCatAnh);
		panel1.Controls.Add(EA895D92);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 271);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(BDB802B7);
		ckbSkipIfHave.AutoSize = true;
		ckbSkipIfHave.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSkipIfHave.Location = new System.Drawing.Point(132, 159);
		ckbSkipIfHave.Name = "ckbSkipIfHave";
		ckbSkipIfHave.Size = new System.Drawing.Size(165, 20);
		ckbSkipIfHave.TabIndex = 35;
		ckbSkipIfHave.Text = "Bỏ qua nếu đã có avatar";
		ckbSkipIfHave.UseVisualStyleBackColor = true;
		F3826B23.Location = new System.Drawing.Point(132, 79);
		F3826B23.Name = "txtPathFolder";
		F3826B23.Size = new System.Drawing.Size(194, 23);
		F3826B23.TabIndex = 0;
		D910D48F.Location = new System.Drawing.Point(132, 49);
		D910D48F.Name = "txtTenHanhDong";
		D910D48F.Size = new System.Drawing.Size(194, 23);
		D910D48F.TabIndex = 0;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 82);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(73, 16);
		label5.TabIndex = 34;
		label5.Text = "Folder ảnh:";
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
		btnCancel.Location = new System.Drawing.Point(189, 242);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F508502B);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 242);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		F08AD02A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F08AD02A.BackColor = System.Drawing.Color.White;
		F08AD02A.BorderRadius = 0;
		F08AD02A.BottomSahddow = true;
		F08AD02A.color = System.Drawing.Color.DarkViolet;
		F08AD02A.Controls.Add(pnlHeader);
		F08AD02A.LeftSahddow = false;
		F08AD02A.Location = new System.Drawing.Point(1, 0);
		F08AD02A.Name = "bunifuCards1";
		F08AD02A.RightSahddow = true;
		F08AD02A.ShadowDepth = 20;
		F08AD02A.Size = new System.Drawing.Size(359, 37);
		F08AD02A.TabIndex = 28;
		ckbThemKhungAvatar.AutoSize = true;
		ckbThemKhungAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThemKhungAvatar.Location = new System.Drawing.Point(132, 133);
		ckbThemKhungAvatar.Name = "ckbThemKhungAvatar";
		ckbThemKhungAvatar.Size = new System.Drawing.Size(137, 20);
		ckbThemKhungAvatar.TabIndex = 35;
		ckbThemKhungAvatar.Text = "Thêm khung avatar";
		ckbThemKhungAvatar.UseVisualStyleBackColor = true;
		EA895D92.AutoSize = true;
		EA895D92.Cursor = System.Windows.Forms.Cursors.Hand;
		EA895D92.Location = new System.Drawing.Point(132, 108);
		EA895D92.Name = "ckbXoaAnhDaDung";
		EA895D92.Size = new System.Drawing.Size(173, 20);
		EA895D92.TabIndex = 35;
		EA895D92.Text = "Tự động xóa ảnh đã dùng";
		EA895D92.UseVisualStyleBackColor = true;
		ckbUuTienMbasic.AutoSize = true;
		ckbUuTienMbasic.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUuTienMbasic.Location = new System.Drawing.Point(132, 185);
		ckbUuTienMbasic.Name = "ckbUuTienMbasic";
		ckbUuTienMbasic.Size = new System.Drawing.Size(173, 20);
		ckbUuTienMbasic.TabIndex = 198;
		ckbUuTienMbasic.Text = "Ưu tiên chạy bằng mbasic";
		ckbUuTienMbasic.UseVisualStyleBackColor = true;
		ckbUuTienMbasic.CheckedChanged += new System.EventHandler(ckbUuTienMbasic_CheckedChanged);
		ckbBoQuaCatAnh.AutoSize = true;
		ckbBoQuaCatAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBoQuaCatAnh.Location = new System.Drawing.Point(132, 210);
		ckbBoQuaCatAnh.Name = "ckbBoQuaCatAnh";
		ckbBoQuaCatAnh.Size = new System.Drawing.Size(220, 20);
		ckbBoQuaCatAnh.TabIndex = 199;
		ckbBoQuaCatAnh.Text = "Bỏ qua cắt ảnh (giữ nguyên khung)";
		ckbBoQuaCatAnh.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 285);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDUpAvatar";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDUpAvatar_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		F08AD02A.ResumeLayout(false);
		ResumeLayout(false);
	}
}
