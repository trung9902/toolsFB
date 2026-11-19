using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDKetBanTheoTuKhoa : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string C919CD15;

	internal string D625B91A;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool B99AECB1;

	internal IContainer B4A81AB4 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl BD308DA3;

	internal Panel A0084B84;

	internal NumericUpDown E10499AC;

	internal NumericUpDown D2062803;

	internal TextBox txtTenHanhDong;

	internal Label label3;

	internal Label label1;

	internal Button btnCancel;

	internal Button BD88AA12;

	internal BunifuCards bunifuCards1;

	internal Panel F728520D;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label lblTuKhoa;

	internal NumericUpDown C4810708;

	internal NumericUpDown nudDelayFrom;

	internal Label D1BC22AC;

	internal RichTextBox txtTuKhoa;

	internal Label label2;

	internal Label D4210439;

	public static bool C2204980
	{
		[CompilerGenerated]
		get
		{
			return B99AECB1;
		}
		[CompilerGenerated]
		set
		{
			B99AECB1 = value;
		}
	}

	public fHDKetBanTheoTuKhoa(string string_1, string string_2 = "")
	{
		InitializeComponent();
		C2204980 = false;
		string_0 = string_1;
		D625B91A = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_3 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			C919CD15 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			string_3 = dataTable2.Rows[0]["CauHinh"].ToString();
			BD88AA12.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_3, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void fHDKetBanTheoTuKhoa_Load(object sender, EventArgs e)
	{
		try
		{
			D2062803.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			E10499AC.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			C4810708.Value = gclass4_0.method_2("nudDelayTo", 5);
			txtTuKhoa.Text = gclass4_0.BDB80B23("txtTuKhoa");
		}
		catch
		{
		}
	}

	private void A03C2414(object sender, EventArgs e)
	{
		Close();
	}

	private void BD88AA12_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		List<string> list_ = txtTuKhoa.Lines.ToList();
		list_ = Commom.smethod_36(list_);
		if (list_.Count == 0)
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p từ khóa!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", D2062803.Value);
		gClass.method_4("nudSoLuongTo", E10499AC.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", C4810708.Value);
		gClass.method_4("txtTuKhoa", txtTuKhoa.Text.Trim());
		string text2 = gClass.ED11179C();
		if (D625B91A == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, C919CD15, text2))
				{
					C2204980 = true;
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
			if (Class154.smethod_13(D625B91A, text, text2))
			{
				C2204980 = true;
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

	private void A0084B84_Paint(object sender, PaintEventArgs e)
	{
		if (A0084B84.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, A0084B84.ClientSize.Width - num, A0084B84.ClientSize.Height - num));
		}
	}

	private void B8B021A4(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtTuKhoa, lblTuKhoa);
	}

	protected override void Dispose(bool F42B3023)
	{
		if (F42B3023 && B4A81AB4 != null)
		{
			B4A81AB4.Dispose();
		}
		base.Dispose(F42B3023);
	}

	private void InitializeComponent()
	{
		B4A81AB4 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKetBanTheoTuKhoa));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(B4A81AB4);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		BD308DA3 = new Bunifu.Framework.UI.BunifuDragControl(B4A81AB4);
		F728520D = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		A0084B84 = new System.Windows.Forms.Panel();
		txtTuKhoa = new System.Windows.Forms.RichTextBox();
		C4810708 = new System.Windows.Forms.NumericUpDown();
		lblTuKhoa = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		D1BC22AC = new System.Windows.Forms.Label();
		E10499AC = new System.Windows.Forms.NumericUpDown();
		D2062803 = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		BD88AA12 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		D4210439 = new System.Windows.Forms.Label();
		F728520D.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		A0084B84.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)C4810708).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)E10499AC).BeginInit();
		((System.ComponentModel.ISupportInitialize)D2062803).BeginInit();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(320, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Kết bạn theo từ khóa";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BD308DA3.Fixed = true;
		BD308DA3.Horizontal = true;
		BD308DA3.TargetControl = F728520D;
		BD308DA3.Vertical = true;
		F728520D.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		F728520D.BackColor = System.Drawing.Color.White;
		F728520D.Controls.Add(button1);
		F728520D.Controls.Add(pictureBox1);
		F728520D.Controls.Add(bunifuCustomLabel1);
		F728520D.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F728520D.Location = new System.Drawing.Point(0, 3);
		F728520D.Name = "pnlHeader";
		F728520D.Size = new System.Drawing.Size(320, 31);
		F728520D.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(289, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(A03C2414);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		A0084B84.BackColor = System.Drawing.Color.White;
		A0084B84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A0084B84.Controls.Add(label2);
		A0084B84.Controls.Add(D4210439);
		A0084B84.Controls.Add(txtTuKhoa);
		A0084B84.Controls.Add(C4810708);
		A0084B84.Controls.Add(lblTuKhoa);
		A0084B84.Controls.Add(nudDelayFrom);
		A0084B84.Controls.Add(D1BC22AC);
		A0084B84.Controls.Add(E10499AC);
		A0084B84.Controls.Add(D2062803);
		A0084B84.Controls.Add(txtTenHanhDong);
		A0084B84.Controls.Add(label3);
		A0084B84.Controls.Add(label1);
		A0084B84.Controls.Add(btnCancel);
		A0084B84.Controls.Add(BD88AA12);
		A0084B84.Controls.Add(bunifuCards1);
		A0084B84.Cursor = System.Windows.Forms.Cursors.Arrow;
		A0084B84.Dock = System.Windows.Forms.DockStyle.Fill;
		A0084B84.Location = new System.Drawing.Point(0, 0);
		A0084B84.Name = "panel1";
		A0084B84.Size = new System.Drawing.Size(323, 361);
		A0084B84.TabIndex = 0;
		A0084B84.Paint += new System.Windows.Forms.PaintEventHandler(A0084B84_Paint);
		txtTuKhoa.Location = new System.Drawing.Point(31, 154);
		txtTuKhoa.Name = "txtTuKhoa";
		txtTuKhoa.Size = new System.Drawing.Size(254, 151);
		txtTuKhoa.TabIndex = 47;
		txtTuKhoa.Text = "";
		txtTuKhoa.WordWrap = false;
		txtTuKhoa.TextChanged += new System.EventHandler(B8B021A4);
		C4810708.Location = new System.Drawing.Point(229, 107);
		C4810708.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C4810708.Name = "nudDelayTo";
		C4810708.Size = new System.Drawing.Size(56, 23);
		C4810708.TabIndex = 4;
		lblTuKhoa.AutoSize = true;
		lblTuKhoa.Location = new System.Drawing.Point(27, 134);
		lblTuKhoa.Name = "lblTuKhoa";
		lblTuKhoa.Size = new System.Drawing.Size(139, 16);
		lblTuKhoa.TabIndex = 0;
		lblTuKhoa.Text = "Danh sa\u0301ch từ khóa (0):";
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		D1BC22AC.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D1BC22AC.Location = new System.Drawing.Point(194, 109);
		D1BC22AC.Name = "label7";
		D1BC22AC.Size = new System.Drawing.Size(29, 16);
		D1BC22AC.TabIndex = 46;
		D1BC22AC.Text = ">";
		D1BC22AC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E10499AC.Location = new System.Drawing.Point(229, 78);
		E10499AC.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E10499AC.Name = "nudSoLuongTo";
		E10499AC.Size = new System.Drawing.Size(56, 23);
		E10499AC.TabIndex = 2;
		D2062803.Location = new System.Drawing.Point(132, 78);
		D2062803.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		D2062803.Name = "nudSoLuongFrom";
		D2062803.Size = new System.Drawing.Size(56, 23);
		D2062803.TabIndex = 1;
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		btnCancel.Location = new System.Drawing.Point(167, 319);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		BD88AA12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		BD88AA12.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		BD88AA12.Cursor = System.Windows.Forms.Cursors.Hand;
		BD88AA12.FlatAppearance.BorderSize = 0;
		BD88AA12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BD88AA12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BD88AA12.ForeColor = System.Drawing.Color.White;
		BD88AA12.Location = new System.Drawing.Point(60, 319);
		BD88AA12.Name = "btnAdd";
		BD88AA12.Size = new System.Drawing.Size(92, 29);
		BD88AA12.TabIndex = 6;
		BD88AA12.Text = "Thêm";
		BD88AA12.UseVisualStyleBackColor = false;
		BD88AA12.Click += new System.EventHandler(BD88AA12_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(F728520D);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(320, 37);
		bunifuCards1.TabIndex = 28;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 48;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		D4210439.AutoSize = true;
		D4210439.Location = new System.Drawing.Point(27, 80);
		D4210439.Name = "label9";
		D4210439.Size = new System.Drawing.Size(63, 16);
		D4210439.TabIndex = 49;
		D4210439.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(323, 361);
		base.Controls.Add(A0084B84);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKetBanTheoTuKhoa";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDKetBanTheoTuKhoa_Load);
		F728520D.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		A0084B84.ResumeLayout(false);
		A0084B84.PerformLayout();
		((System.ComponentModel.ISupportInitialize)C4810708).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)E10499AC).EndInit();
		((System.ComponentModel.ISupportInitialize)D2062803).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
