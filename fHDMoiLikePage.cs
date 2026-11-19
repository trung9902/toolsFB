using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDMoiLikePage : Form
{
	internal GClass4 gclass4_0 = null;

	internal string F6060E30;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool B682729E;

	internal IContainer FD931907 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button DD2DA422;

	internal Button DCBBA21C;

	internal BunifuCards bunifuCards1;

	internal Panel A18D0D9E;

	internal PictureBox E488C208;

	internal BunifuCustomLabel B59BA79D;

	internal Label lblStatus;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal Label label13;

	internal Label E4982D9D;

	internal NumericUpDown FEBA4132;

	internal Label label2;

	internal Label F30FA3B4;

	internal NumericUpDown nudDelayFrom;

	internal Button button1;

	internal TextBox A4AA01B3;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return B682729E;
		}
		[CompilerGenerated]
		set
		{
			B682729E = value;
		}
	}

	public fHDMoiLikePage(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		F6060E30 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(B59BA79D.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			DCBBA21C.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDMoiLikePage_Load(object sender, EventArgs e)
	{
		try
		{
			A4AA01B3.Text = gclass4_0.BDB80B23("txtIdPage");
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 10);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 10);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			FEBA4132.Value = gclass4_0.method_2("nudDelayTo", 5);
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void DCBBA21C_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("txtIdPage", A4AA01B3.Text.Trim());
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", FEBA4132.Value);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(F6060E30, text, string_0, e013A))
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

	private void D6AE7525(object sender, EventArgs e)
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

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && FD931907 != null)
		{
			FD931907.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		FD931907 = new System.ComponentModel.Container();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(FD931907);
		B59BA79D = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(FD931907);
		A18D0D9E = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		E488C208 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		A4AA01B3 = new System.Windows.Forms.TextBox();
		FEBA4132 = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		F30FA3B4 = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		lblStatus = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label13 = new System.Windows.Forms.Label();
		E4982D9D = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		DD2DA422 = new System.Windows.Forms.Button();
		DCBBA21C = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A18D0D9E.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E488C208).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FEBA4132).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = B59BA79D;
		bunifuDragControl_0.Vertical = true;
		B59BA79D.BackColor = System.Drawing.Color.Transparent;
		B59BA79D.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B59BA79D.Dock = System.Windows.Forms.DockStyle.Fill;
		B59BA79D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B59BA79D.ForeColor = System.Drawing.Color.Black;
		B59BA79D.Location = new System.Drawing.Point(0, 0);
		B59BA79D.Name = "bunifuCustomLabel1";
		B59BA79D.Size = new System.Drawing.Size(326, 31);
		B59BA79D.TabIndex = 12;
		B59BA79D.Text = "Cấu hình Mời like Page";
		B59BA79D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = A18D0D9E;
		bunifuDragControl_1.Vertical = true;
		A18D0D9E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A18D0D9E.BackColor = System.Drawing.Color.White;
		A18D0D9E.Controls.Add(button1);
		A18D0D9E.Controls.Add(E488C208);
		A18D0D9E.Controls.Add(B59BA79D);
		A18D0D9E.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A18D0D9E.Location = new System.Drawing.Point(0, 3);
		A18D0D9E.Name = "pnlHeader";
		A18D0D9E.Size = new System.Drawing.Size(326, 31);
		A18D0D9E.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = Class155.Bitmap_15;
		button1.Location = new System.Drawing.Point(295, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		E488C208.Cursor = System.Windows.Forms.Cursors.Default;
		E488C208.Image = Class155.DD225F0D;
		E488C208.Location = new System.Drawing.Point(3, 2);
		E488C208.Name = "pictureBox1";
		E488C208.Size = new System.Drawing.Size(34, 27);
		E488C208.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E488C208.TabIndex = 76;
		E488C208.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(A4AA01B3);
		panel1.Controls.Add(FEBA4132);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(F30FA3B4);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(label13);
		panel1.Controls.Add(E4982D9D);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(DD2DA422);
		panel1.Controls.Add(DCBBA21C);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(329, 222);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		A4AA01B3.Location = new System.Drawing.Point(134, 78);
		A4AA01B3.Name = "txtIdPage";
		A4AA01B3.Size = new System.Drawing.Size(158, 23);
		A4AA01B3.TabIndex = 38;
		FEBA4132.Location = new System.Drawing.Point(232, 136);
		FEBA4132.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FEBA4132.Name = "nudDelayTo";
		FEBA4132.Size = new System.Drawing.Size(60, 23);
		FEBA4132.TabIndex = 2;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 138);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 32;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		F30FA3B4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F30FA3B4.Location = new System.Drawing.Point(200, 138);
		F30FA3B4.Name = "label4";
		F30FA3B4.Size = new System.Drawing.Size(29, 16);
		F30FA3B4.TabIndex = 37;
		F30FA3B4.Text = ">";
		F30FA3B4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudDelayFrom.Location = new System.Drawing.Point(134, 136);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(60, 23);
		nudDelayFrom.TabIndex = 1;
		lblStatus.AutoSize = true;
		lblStatus.Location = new System.Drawing.Point(27, 78);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(89, 16);
		lblStatus.TabIndex = 0;
		lblStatus.Text = "Nhập ID Page:";
		nudSoLuongTo.Location = new System.Drawing.Point(232, 107);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(60, 23);
		nudSoLuongTo.TabIndex = 2;
		nudSoLuongFrom.Location = new System.Drawing.Point(134, 107);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(60, 23);
		nudSoLuongFrom.TabIndex = 1;
		txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(158, 23);
		txtTenHanhDong.TabIndex = 0;
		label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(200, 109);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(29, 16);
		label13.TabIndex = 37;
		label13.Text = ">";
		label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E4982D9D.AutoSize = true;
		E4982D9D.Location = new System.Drawing.Point(27, 109);
		E4982D9D.Name = "label9";
		E4982D9D.Size = new System.Drawing.Size(63, 16);
		E4982D9D.TabIndex = 32;
		E4982D9D.Text = "Sô\u0301 lươ\u0323ng:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		DD2DA422.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		DD2DA422.BackColor = System.Drawing.Color.Maroon;
		DD2DA422.Cursor = System.Windows.Forms.Cursors.Hand;
		DD2DA422.FlatAppearance.BorderSize = 0;
		DD2DA422.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DD2DA422.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DD2DA422.ForeColor = System.Drawing.Color.White;
		DD2DA422.Location = new System.Drawing.Point(176, 181);
		DD2DA422.Name = "btnCancel";
		DD2DA422.Size = new System.Drawing.Size(92, 29);
		DD2DA422.TabIndex = 10;
		DD2DA422.Text = "Đóng";
		DD2DA422.UseVisualStyleBackColor = false;
		DD2DA422.Click += new System.EventHandler(D6AE7525);
		DCBBA21C.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		DCBBA21C.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		DCBBA21C.Cursor = System.Windows.Forms.Cursors.Hand;
		DCBBA21C.FlatAppearance.BorderSize = 0;
		DCBBA21C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DCBBA21C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DCBBA21C.ForeColor = System.Drawing.Color.White;
		DCBBA21C.Location = new System.Drawing.Point(69, 181);
		DCBBA21C.Name = "btnAdd";
		DCBBA21C.Size = new System.Drawing.Size(92, 29);
		DCBBA21C.TabIndex = 9;
		DCBBA21C.Text = "Thêm";
		DCBBA21C.UseVisualStyleBackColor = false;
		DCBBA21C.Click += new System.EventHandler(DCBBA21C_Click);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.DarkViolet;
		bunifuCards1.Controls.Add(A18D0D9E);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(326, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(329, 222);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDMoiLikePage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDMoiLikePage_Load);
		A18D0D9E.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)E488C208).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)FEBA4132).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
