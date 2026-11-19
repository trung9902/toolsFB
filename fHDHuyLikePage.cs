using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDHuyLikePage : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 FA9198BF;

	internal string A3393A15;

	internal string AC87E89A;

	internal string string_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer C8A999A4 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown C2365615;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox C389A6B5;

	internal Label label3;

	internal Label label4;

	internal Label B4361E8F;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards FA3EF727;

	internal Panel BCAF38AE;

	internal Button CEBC2A2C;

	internal PictureBox BE39949A;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown FD0F8DA6;

	internal Label label7;

	internal Label D1AC4582;

	internal Label label2;

	internal Label E7BAB60A;

	public static bool D93E362A
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

	public fHDHuyLikePage(string A7BA032D, string string_1 = "")
	{
		InitializeComponent();
		D93E362A = false;
		A3393A15 = A7BA032D;
		string_0 = string_1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (string_1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			AC87E89A = dataTable.Rows[0]["Id_TuongTac"].ToString();
			C389A6B5.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_1);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			C389A6B5.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		FA9198BF = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);

		// Keyboard shortcut ESC to close dialog
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
	}

	private void DA05A8A1(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = FA9198BF.method_2("nudSoLuongFrom", 1);
			C2365615.Value = FA9198BF.method_2("nudSoLuongTo", 3);
			FD0F8DA6.Value = FA9198BF.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = FA9198BF.method_2("nudDelayTo", 5);
		}
		catch
		{
		}
	}

	private void CEBC2A2C_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = C389A6B5.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", C2365615.Value);
		gClass.method_4("nudDelayFrom", FD0F8DA6.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		string text2 = gClass.ED11179C();
		if (string_0 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(A3393A15, text, AC87E89A, text2))
				{
					D93E362A = true;
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
			if (Class154.smethod_13(string_0, text, text2))
			{
				D93E362A = true;
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

	protected override void Dispose(bool EF893E3F)
	{
		if (EF893E3F && C8A999A4 != null)
		{
			C8A999A4.Dispose();
		}
		base.Dispose(EF893E3F);
	}

	private void InitializeComponent()
	{
		C8A999A4 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDHuyLikePage));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(C8A999A4);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(C8A999A4);
		BCAF38AE = new System.Windows.Forms.Panel();
		CEBC2A2C = new System.Windows.Forms.Button();
		BE39949A = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		FD0F8DA6 = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		D1AC4582 = new System.Windows.Forms.Label();
		C2365615 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		C389A6B5 = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		B4361E8F = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		FA3EF727 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		E7BAB60A = new System.Windows.Forms.Label();
		BCAF38AE.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)BE39949A).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)FD0F8DA6).BeginInit();
		((System.ComponentModel.ISupportInitialize)C2365615).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		FA3EF727.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

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
		bunifuCustomLabel1.Text = "Cấu hình Hủy like page";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = BCAF38AE;
		bunifuDragControl_1.Vertical = true;
		BCAF38AE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		BCAF38AE.BackColor = System.Drawing.Color.White;
		BCAF38AE.Controls.Add(CEBC2A2C);
		BCAF38AE.Controls.Add(BE39949A);
		BCAF38AE.Controls.Add(bunifuCustomLabel1);
		BCAF38AE.Cursor = System.Windows.Forms.Cursors.SizeAll;
		BCAF38AE.Location = new System.Drawing.Point(0, 3);
		BCAF38AE.Name = "pnlHeader";
		BCAF38AE.Size = new System.Drawing.Size(359, 31);
		BCAF38AE.TabIndex = 9;
		CEBC2A2C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		CEBC2A2C.Cursor = System.Windows.Forms.Cursors.Hand;
		CEBC2A2C.FlatAppearance.BorderSize = 0;
		CEBC2A2C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CEBC2A2C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CEBC2A2C.ForeColor = System.Drawing.Color.White;
		CEBC2A2C.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		CEBC2A2C.Location = new System.Drawing.Point(328, 1);
		CEBC2A2C.Name = "button1";
		CEBC2A2C.Size = new System.Drawing.Size(30, 30);
		CEBC2A2C.TabIndex = 77;
		CEBC2A2C.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		CEBC2A2C.UseVisualStyleBackColor = true;
		CEBC2A2C.Click += new System.EventHandler(CEBC2A2C_Click);
		System.Drawing.Image iconClose_fHDHu = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDHu != null) CEBC2A2C.Image = iconClose_fHDHu;
		BE39949A.Cursor = System.Windows.Forms.Cursors.Default;
		BE39949A.Image = Class155.DD225F0D;
		BE39949A.Location = new System.Drawing.Point(3, 2);
		BE39949A.Name = "pictureBox1";
		BE39949A.Size = new System.Drawing.Size(34, 27);
		BE39949A.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		BE39949A.TabIndex = 76;
		BE39949A.TabStop = false;
		System.Drawing.Image iconApp_fHDHu = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDHu != null) BE39949A.Image = iconApp_fHDHu;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(E7BAB60A);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(FD0F8DA6);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(D1AC4582);
		panel1.Controls.Add(C2365615);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(C389A6B5);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(B4361E8F);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(FA3EF727);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 206);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		nudDelayTo.Location = new System.Drawing.Point(223, 112);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		FD0F8DA6.Location = new System.Drawing.Point(132, 112);
		FD0F8DA6.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FD0F8DA6.Name = "nudDelayFrom";
		FD0F8DA6.Size = new System.Drawing.Size(56, 23);
		FD0F8DA6.TabIndex = 3;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(191, 114);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D1AC4582.AutoSize = true;
		D1AC4582.Location = new System.Drawing.Point(280, 114);
		D1AC4582.Name = "label6";
		D1AC4582.Size = new System.Drawing.Size(30, 16);
		D1AC4582.TabIndex = 45;
		D1AC4582.Text = "giây";
		C2365615.Location = new System.Drawing.Point(223, 81);
		C2365615.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C2365615.Name = "nudSoLuongTo";
		C2365615.Size = new System.Drawing.Size(56, 23);
		C2365615.TabIndex = 2;
		nudSoLuongFrom.Location = new System.Drawing.Point(132, 81);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 1;
		C389A6B5.Location = new System.Drawing.Point(132, 49);
		C389A6B5.Name = "txtTenHanhDong";
		C389A6B5.Size = new System.Drawing.Size(194, 23);
		C389A6B5.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(191, 83);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(280, 83);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(35, 16);
		label4.TabIndex = 35;
		label4.Text = "page";
		B4361E8F.AutoSize = true;
		B4361E8F.Location = new System.Drawing.Point(27, 52);
		B4361E8F.Name = "label1";
		B4361E8F.Size = new System.Drawing.Size(98, 16);
		B4361E8F.TabIndex = 31;
		B4361E8F.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(191, 158);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(84, 158);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		FA3EF727.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FA3EF727.BackColor = System.Drawing.Color.White;
		FA3EF727.BorderRadius = 0;
		FA3EF727.BottomSahddow = true;
		FA3EF727.color = System.Drawing.Color.FromArgb(37, 99, 235);
		FA3EF727.Controls.Add(BCAF38AE);
		FA3EF727.LeftSahddow = false;
		FA3EF727.Location = new System.Drawing.Point(1, 0);
		FA3EF727.Name = "bunifuCards1";
		FA3EF727.RightSahddow = true;
		FA3EF727.ShadowDepth = 20;
		FA3EF727.Size = new System.Drawing.Size(359, 37);
		FA3EF727.TabIndex = 28;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 112);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 47;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		E7BAB60A.AutoSize = true;
		E7BAB60A.Location = new System.Drawing.Point(27, 83);
		E7BAB60A.Name = "label9";
		E7BAB60A.Size = new System.Drawing.Size(63, 16);
		E7BAB60A.TabIndex = 48;
		E7BAB60A.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 206);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDHuyLikePage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(DA05A8A1);
		BCAF38AE.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)BE39949A).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)FD0F8DA6).EndInit();
		((System.ComponentModel.ISupportInitialize)C2365615).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		FA3EF727.ResumeLayout(false);
		ResumeLayout(false);
	}
}
