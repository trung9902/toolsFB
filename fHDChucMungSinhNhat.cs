using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDChucMungSinhNhat : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool FC8E5D31;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl D4A2E32A;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards C9309097;

	internal Panel pnlHeader;

	internal Button D500930B;

	internal PictureBox EB1E7891;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown BBA9CB82;

	internal NumericUpDown BAA6042A;

	internal NumericUpDown A2066235;

	internal NumericUpDown nudSoLuongFrom;

	internal Label label7;

	internal Label label3;

	internal Label D58D2B04;

	internal Label label2;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return FC8E5D31;
		}
		[CompilerGenerated]
		set
		{
			FC8E5D31 = value;
		}
	}

	public fHDChucMungSinhNhat(string string_3, string string_4 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_3;
		string_2 = string_4;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_4 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_4);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void fHDChucMungSinhNhat_Load(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 2);
			BAA6042A.Value = gclass4_0.method_2("nudSoLuongTo", 2);
			A2066235.Value = gclass4_0.method_2("nudDelayFrom", 3);
			BBA9CB82.Value = gclass4_0.method_2("nudDelayTo", 5);
		}
		catch
		{
		}
	}

	private void D500930B_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void D31F4E80(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", BAA6042A.Value);
		gClass.method_4("nudDelayFrom", A2066235.Value);
		gClass.method_4("nudDelayTo", BBA9CB82.Value);
		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
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
			if (Class154.smethod_13(string_2, text, e013A))
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

	protected override void Dispose(bool B81D3B1E)
	{
		if (B81D3B1E && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(B81D3B1E);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDChucMungSinhNhat));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		D4A2E32A = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		D500930B = new System.Windows.Forms.Button();
		EB1E7891 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		C9309097 = new Bunifu.Framework.UI.BunifuCards();
		BBA9CB82 = new System.Windows.Forms.NumericUpDown();
		BAA6042A = new System.Windows.Forms.NumericUpDown();
		A2066235 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		D58D2B04 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)EB1E7891).BeginInit();
		panel1.SuspendLayout();
		C9309097.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)BBA9CB82).BeginInit();
		((System.ComponentModel.ISupportInitialize)BAA6042A).BeginInit();
		((System.ComponentModel.ISupportInitialize)A2066235).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
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
		bunifuCustomLabel1.Text = "Cấu hình Chúc mừng sinh nhật";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D4A2E32A.Fixed = true;
		D4A2E32A.Horizontal = true;
		D4A2E32A.TargetControl = pnlHeader;
		D4A2E32A.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(D500930B);
		pnlHeader.Controls.Add(EB1E7891);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		D500930B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D500930B.Cursor = System.Windows.Forms.Cursors.Hand;
		D500930B.FlatAppearance.BorderSize = 0;
		D500930B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D500930B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D500930B.ForeColor = System.Drawing.Color.White;
		D500930B.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		D500930B.Location = new System.Drawing.Point(328, 1);
		D500930B.Name = "button1";
		D500930B.Size = new System.Drawing.Size(30, 30);
		D500930B.TabIndex = 77;
		D500930B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D500930B.UseVisualStyleBackColor = true;
		D500930B.Click += new System.EventHandler(D500930B_Click);
		EB1E7891.Cursor = System.Windows.Forms.Cursors.Default;
		EB1E7891.Image = Class155.DD225F0D;
		EB1E7891.Location = new System.Drawing.Point(3, 2);
		EB1E7891.Name = "pictureBox1";
		EB1E7891.Size = new System.Drawing.Size(34, 27);
		EB1E7891.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		EB1E7891.TabIndex = 76;
		EB1E7891.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(BBA9CB82);
		panel1.Controls.Add(BAA6042A);
		panel1.Controls.Add(A2066235);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(D58D2B04);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(C9309097);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(362, 192);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
		txtTenHanhDong.TabIndex = 0;
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
		btnCancel.Location = new System.Drawing.Point(185, 147);
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
		btnAdd.Location = new System.Drawing.Point(78, 147);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(D31F4E80);
		C9309097.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C9309097.BackColor = System.Drawing.Color.White;
		C9309097.BorderRadius = 0;
		C9309097.BottomSahddow = true;
		C9309097.color = System.Drawing.Color.DarkViolet;
		C9309097.Controls.Add(pnlHeader);
		C9309097.LeftSahddow = false;
		C9309097.Location = new System.Drawing.Point(1, 0);
		C9309097.Name = "bunifuCards1";
		C9309097.RightSahddow = true;
		C9309097.ShadowDepth = 20;
		C9309097.Size = new System.Drawing.Size(359, 37);
		C9309097.TabIndex = 28;
		BBA9CB82.Location = new System.Drawing.Point(229, 107);
		BBA9CB82.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		BBA9CB82.Name = "nudDelayTo";
		BBA9CB82.Size = new System.Drawing.Size(56, 23);
		BBA9CB82.TabIndex = 42;
		BAA6042A.Location = new System.Drawing.Point(229, 78);
		BAA6042A.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		BAA6042A.Name = "nudSoLuongTo";
		BAA6042A.Size = new System.Drawing.Size(56, 23);
		BAA6042A.TabIndex = 40;
		A2066235.Location = new System.Drawing.Point(132, 107);
		A2066235.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		A2066235.Name = "nudDelayFrom";
		A2066235.Size = new System.Drawing.Size(56, 23);
		A2066235.TabIndex = 41;
		nudSoLuongFrom.Location = new System.Drawing.Point(132, 78);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 39;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(194, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 45;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		D58D2B04.AutoSize = true;
		D58D2B04.Location = new System.Drawing.Point(27, 109);
		D58D2B04.Name = "label5";
		D58D2B04.Size = new System.Drawing.Size(87, 16);
		D58D2B04.TabIndex = 44;
		D58D2B04.Text = "Gia\u0303n ca\u0301ch (s):";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 80);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(88, 16);
		label2.TabIndex = 43;
		label2.Text = "Sô\u0301 lươ\u0323ng ba\u0323n:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 192);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDChucMungSinhNhat";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDChucMungSinhNhat_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)EB1E7891).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		C9309097.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)BBA9CB82).EndInit();
		((System.ComponentModel.ISupportInitialize)BAA6042A).EndInit();
		((System.ComponentModel.ISupportInitialize)A2066235).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		ResumeLayout(false);
	}
}
