using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDKhangSpam : Form
{
	internal GClass4 F718EAB7 = null;

	internal string B630D933;

	internal string D033CE05;

	internal string string_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl F530EAB8;

	internal Panel B99D1902;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown FBB4E21B;

	internal TextBox BDA9AC34;

	internal Label label7;

	internal Label F70C6096;

	internal Label label5;

	internal Label label1;

	internal Button E99C851C;

	internal Button E60BBABA;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox F7A16680;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal Label label2;

	internal Label BB36E4A3;

	internal Label label4;

	public static bool B7376F13
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

	public fHDKhangSpam(string C2A9A291, string string_1 = "")
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
		B7376F13 = false;
		B630D933 = C2A9A291;
		string_0 = string_1;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (string_1 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			D033CE05 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			BDA9AC34.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_1);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			E60BBABA.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			BDA9AC34.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		F718EAB7 = new GClass4(string_2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDKhangSpam_Load(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = F718EAB7.method_2("nudSoLuongFrom", 3);
			nudSoLuongTo.Value = F718EAB7.method_2("nudSoLuongTo", 3);
			FBB4E21B.Value = F718EAB7.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = F718EAB7.method_2("nudDelayTo", 5);
		}
		catch
		{
		}
	}

	private void B29402A0(object sender, EventArgs e)
	{
		Close();
	}

	private void E60BBABA_Click(object sender, EventArgs e)
	{
		string text = BDA9AC34.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", FBB4E21B.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		string text2 = gClass.ED11179C();
		if (string_0 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(B630D933, text, D033CE05, text2))
				{
					B7376F13 = true;
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
				B7376F13 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void E99C851C_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B99D1902_Paint(object sender, PaintEventArgs e)
	{
		if (B99D1902.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, B99D1902.ClientSize.Width - num, B99D1902.ClientSize.Height - num));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKhangSpam));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		F530EAB8 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		F7A16680 = new System.Windows.Forms.PictureBox();
		B99D1902 = new System.Windows.Forms.Panel();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		BB36E4A3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		FBB4E21B = new System.Windows.Forms.NumericUpDown();
		BDA9AC34 = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		F70C6096 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		E99C851C = new System.Windows.Forms.Button();
		E60BBABA = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F7A16680).BeginInit();
		B99D1902.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)FBB4E21B).BeginInit();
		bunifuCards1.SuspendLayout();
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
		bunifuCustomLabel1.Text = "Cấu hình Kháng spam";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F530EAB8.Fixed = true;
		F530EAB8.Horizontal = true;
		F530EAB8.TargetControl = pnlHeader;
		F530EAB8.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(F7A16680);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
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
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null) button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(328, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(B29402A0);
		F7A16680.Cursor = System.Windows.Forms.Cursors.Default;
		F7A16680.Image = Class155.DD225F0D;
		F7A16680.Location = new System.Drawing.Point(3, 2);
		F7A16680.Name = "pictureBox1";
		F7A16680.Size = new System.Drawing.Size(34, 27);
		F7A16680.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		F7A16680.TabIndex = 76;
		F7A16680.TabStop = false;
		B99D1902.BackColor = System.Drawing.Color.White;
		B99D1902.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B99D1902.Controls.Add(nudSoLuongTo);
		B99D1902.Controls.Add(nudSoLuongFrom);
		B99D1902.Controls.Add(label2);
		B99D1902.Controls.Add(BB36E4A3);
		B99D1902.Controls.Add(label4);
		B99D1902.Controls.Add(nudDelayTo);
		B99D1902.Controls.Add(FBB4E21B);
		B99D1902.Controls.Add(BDA9AC34);
		B99D1902.Controls.Add(label7);
		B99D1902.Controls.Add(F70C6096);
		B99D1902.Controls.Add(label5);
		B99D1902.Controls.Add(label1);
		B99D1902.Controls.Add(E99C851C);
		B99D1902.Controls.Add(E60BBABA);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		B99D1902.Controls.Add(pnlTopAccent);
		B99D1902.Controls.Add(bunifuCards1);
		B99D1902.Cursor = System.Windows.Forms.Cursors.Arrow;
		B99D1902.Dock = System.Windows.Forms.DockStyle.Fill;
		B99D1902.Location = new System.Drawing.Point(0, 0);
		B99D1902.Name = "panel1";
		B99D1902.Size = new System.Drawing.Size(362, 158);
		B99D1902.TabIndex = 0;
		B99D1902.Paint += new System.Windows.Forms.PaintEventHandler(B99D1902_Paint);
		nudSoLuongTo.Location = new System.Drawing.Point(229, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 40;
		nudSoLuongFrom.Location = new System.Drawing.Point(132, 78);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 39;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(194, 80);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(29, 16);
		label2.TabIndex = 43;
		label2.Text = ">";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BB36E4A3.AutoSize = true;
		BB36E4A3.Location = new System.Drawing.Point(287, 214);
		BB36E4A3.Name = "label3";
		BB36E4A3.Size = new System.Drawing.Size(0, 16);
		BB36E4A3.TabIndex = 42;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 80);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(63, 16);
		label4.TabIndex = 41;
		label4.Text = "Số lượng:";
		nudDelayTo.Location = new System.Drawing.Point(229, 242);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		FBB4E21B.Location = new System.Drawing.Point(132, 242);
		FBB4E21B.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FBB4E21B.Name = "nudDelayFrom";
		FBB4E21B.Size = new System.Drawing.Size(56, 23);
		FBB4E21B.TabIndex = 3;
		BDA9AC34.Location = new System.Drawing.Point(132, 49);
		BDA9AC34.Name = "txtTenHanhDong";
		BDA9AC34.Size = new System.Drawing.Size(194, 23);
		BDA9AC34.TabIndex = 0;
		label7.Location = new System.Drawing.Point(194, 244);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = "đê\u0301n";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F70C6096.AutoSize = true;
		F70C6096.Location = new System.Drawing.Point(287, 244);
		F70C6096.Name = "label6";
		F70C6096.Size = new System.Drawing.Size(30, 16);
		F70C6096.TabIndex = 36;
		F70C6096.Text = "giây";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 244);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(89, 16);
		label5.TabIndex = 34;
		label5.Text = "Thơ\u0300i gian chơ\u0300:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		E99C851C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E99C851C.BackColor = System.Drawing.Color.Maroon;
		E99C851C.Cursor = System.Windows.Forms.Cursors.Hand;
		E99C851C.FlatAppearance.BorderSize = 0;
		E99C851C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E99C851C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E99C851C.ForeColor = System.Drawing.Color.White;
		E99C851C.Location = new System.Drawing.Point(190, 116);
		E99C851C.Name = "btnCancel";
		E99C851C.Size = new System.Drawing.Size(92, 29);
		E99C851C.TabIndex = 10;
		E99C851C.Text = "Đóng";
		E99C851C.UseVisualStyleBackColor = false;
		E99C851C.Click += new System.EventHandler(E99C851C_Click);
		E60BBABA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E60BBABA.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		E60BBABA.Cursor = System.Windows.Forms.Cursors.Hand;
		E60BBABA.FlatAppearance.BorderSize = 0;
		E60BBABA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E60BBABA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E60BBABA.ForeColor = System.Drawing.Color.White;
		E60BBABA.Location = new System.Drawing.Point(83, 116);
		E60BBABA.Name = "btnAdd";
		E60BBABA.Size = new System.Drawing.Size(92, 29);
		E60BBABA.TabIndex = 9;
		E60BBABA.Text = "Thêm";
		E60BBABA.UseVisualStyleBackColor = false;
		E60BBABA.Click += new System.EventHandler(E60BBABA_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(359, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 158);
		base.Controls.Add(B99D1902);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKhangSpam";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDKhangSpam_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)F7A16680).EndInit();
		B99D1902.ResumeLayout(false);
		B99D1902.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)FBB4E21B).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
