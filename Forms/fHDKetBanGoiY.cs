using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDKetBanGoiY : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string E4851F05;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool F5A14F9D;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel E4A1483A;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox txtTenHanhDong;

	internal Label label3;

	internal Label DA9F6210;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards DEB87FA9;

	internal Panel pnlHeader;

	internal Button CCAF8D8F;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label F5AC2823;

	internal NumericUpDown nudTimesWarning;

	internal Label label9;

	internal Label DCAE8E96;

	internal CheckBox DD12C7B7;

	internal CheckBox ckbChiKetBanTenCoDau;

	internal Label BA107317;

	internal Label label4;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return F5A14F9D;
		}
		[CompilerGenerated]
		set
		{
			F5A14F9D = value;
		}
	}

	public fHDKetBanGoiY(string string_2, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_2;
		E4851F05 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
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
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void fHDKetBanGoiY_Load(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom");
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo");
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom");
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo");
			ckbChiKetBanTenCoDau.Checked = gclass4_0.method_3("ckbChiKetBanTenCoDau");
			DD12C7B7.Checked = gclass4_0.method_3("ckbOnlyAddFriendWithMutualFriends");
			nudTimesWarning.Value = gclass4_0.method_2("nudTimesWarning", 5);
		}
		catch
		{
		}
	}

	private void CCAF8D8F_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbChiKetBanTenCoDau", ckbChiKetBanTenCoDau.Checked);
		gClass.method_4("ckbOnlyAddFriendWithMutualFriends", DD12C7B7.Checked);
		gClass.method_4("nudTimesWarning", nudTimesWarning.Value);
		string e013A = gClass.ED11179C();
		if (E4851F05 == "")
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
			if (Class154.smethod_13(E4851F05, text, e013A))
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

	private void F7AF2B89(object sender, EventArgs e)
	{
		Close();
	}

	private void E4A1483A_Paint(object sender, PaintEventArgs e)
	{
		if (E4A1483A.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, E4A1483A.ClientSize.Width - num, E4A1483A.ClientSize.Height - num));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKetBanGoiY));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		CCAF8D8F = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		E4A1483A = new System.Windows.Forms.Panel();
		nudTimesWarning = new System.Windows.Forms.NumericUpDown();
		label9 = new System.Windows.Forms.Label();
		DCAE8E96 = new System.Windows.Forms.Label();
		DD12C7B7 = new System.Windows.Forms.CheckBox();
		ckbChiKetBanTenCoDau = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		F5AC2823 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		DA9F6210 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		DEB87FA9 = new Bunifu.Framework.UI.BunifuCards();
		BA107317 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		E4A1483A.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudTimesWarning).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		DEB87FA9.SuspendLayout();
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
		bunifuCustomLabel1.Text = "Cấu hình Kết bạn gợi ý";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(CCAF8D8F);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		CCAF8D8F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		CCAF8D8F.Cursor = System.Windows.Forms.Cursors.Hand;
		CCAF8D8F.FlatAppearance.BorderSize = 0;
		CCAF8D8F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CCAF8D8F.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		CCAF8D8F.ForeColor = System.Drawing.Color.White;
		CCAF8D8F.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		CCAF8D8F.Location = new System.Drawing.Point(328, 1);
		CCAF8D8F.Name = "button1";
		CCAF8D8F.Size = new System.Drawing.Size(30, 30);
		CCAF8D8F.TabIndex = 77;
		CCAF8D8F.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		CCAF8D8F.UseVisualStyleBackColor = true;
		CCAF8D8F.Click += new System.EventHandler(CCAF8D8F_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		E4A1483A.BackColor = System.Drawing.Color.White;
		E4A1483A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E4A1483A.Controls.Add(BA107317);
		E4A1483A.Controls.Add(label4);
		E4A1483A.Controls.Add(nudTimesWarning);
		E4A1483A.Controls.Add(label9);
		E4A1483A.Controls.Add(DCAE8E96);
		E4A1483A.Controls.Add(DD12C7B7);
		E4A1483A.Controls.Add(ckbChiKetBanTenCoDau);
		E4A1483A.Controls.Add(nudDelayTo);
		E4A1483A.Controls.Add(nudDelayFrom);
		E4A1483A.Controls.Add(F5AC2823);
		E4A1483A.Controls.Add(nudSoLuongTo);
		E4A1483A.Controls.Add(nudSoLuongFrom);
		E4A1483A.Controls.Add(txtTenHanhDong);
		E4A1483A.Controls.Add(label3);
		E4A1483A.Controls.Add(DA9F6210);
		E4A1483A.Controls.Add(btnCancel);
		E4A1483A.Controls.Add(btnAdd);
		E4A1483A.Controls.Add(DEB87FA9);
		E4A1483A.Cursor = System.Windows.Forms.Cursors.Arrow;
		E4A1483A.Dock = System.Windows.Forms.DockStyle.Fill;
		E4A1483A.Location = new System.Drawing.Point(0, 0);
		E4A1483A.Name = "panel1";
		E4A1483A.Size = new System.Drawing.Size(362, 264);
		E4A1483A.TabIndex = 0;
		E4A1483A.Paint += new System.Windows.Forms.PaintEventHandler(E4A1483A_Paint);
		nudTimesWarning.Location = new System.Drawing.Point(253, 183);
		nudTimesWarning.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimesWarning.Name = "nudTimesWarning";
		nudTimesWarning.Size = new System.Drawing.Size(43, 23);
		nudTimesWarning.TabIndex = 55;
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(299, 185);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(24, 16);
		label9.TabIndex = 57;
		label9.Text = "lần";
		DCAE8E96.AutoSize = true;
		DCAE8E96.Location = new System.Drawing.Point(27, 185);
		DCAE8E96.Name = "label8";
		DCAE8E96.Size = new System.Drawing.Size(225, 16);
		DCAE8E96.TabIndex = 56;
		DCAE8E96.Text = "Dừng khi gặp cảnh báo của Facebook:";
		DD12C7B7.AutoSize = true;
		DD12C7B7.Cursor = System.Windows.Forms.Cursors.Hand;
		DD12C7B7.Location = new System.Drawing.Point(30, 160);
		DD12C7B7.Name = "ckbOnlyAddFriendWithMutualFriends";
		DD12C7B7.Size = new System.Drawing.Size(226, 20);
		DD12C7B7.TabIndex = 54;
		DD12C7B7.Text = "Chỉ kết bạn với người có bạn chung";
		DD12C7B7.UseVisualStyleBackColor = true;
		ckbChiKetBanTenCoDau.AutoSize = true;
		ckbChiKetBanTenCoDau.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbChiKetBanTenCoDau.Location = new System.Drawing.Point(30, 136);
		ckbChiKetBanTenCoDau.Name = "ckbChiKetBanTenCoDau";
		ckbChiKetBanTenCoDau.Size = new System.Drawing.Size(211, 20);
		ckbChiKetBanTenCoDau.TabIndex = 53;
		ckbChiKetBanTenCoDau.Text = "Chỉ kết bạn với người có tên Việt";
		ckbChiKetBanTenCoDau.UseVisualStyleBackColor = true;
		nudDelayTo.Location = new System.Drawing.Point(229, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		F5AC2823.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F5AC2823.Location = new System.Drawing.Point(194, 109);
		F5AC2823.Name = "label7";
		F5AC2823.Size = new System.Drawing.Size(29, 16);
		F5AC2823.TabIndex = 46;
		F5AC2823.Text = ">";
		F5AC2823.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongTo.Location = new System.Drawing.Point(229, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		nudSoLuongFrom.Location = new System.Drawing.Point(132, 78);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 1;
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
		txtTenHanhDong.TabIndex = 0;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DA9F6210.AutoSize = true;
		DA9F6210.Location = new System.Drawing.Point(27, 52);
		DA9F6210.Name = "label1";
		DA9F6210.Size = new System.Drawing.Size(98, 16);
		DA9F6210.TabIndex = 31;
		DA9F6210.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(187, 220);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F7AF2B89);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(80, 220);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		DEB87FA9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DEB87FA9.BackColor = System.Drawing.Color.White;
		DEB87FA9.BorderRadius = 0;
		DEB87FA9.BottomSahddow = true;
		DEB87FA9.color = System.Drawing.Color.DarkViolet;
		DEB87FA9.Controls.Add(pnlHeader);
		DEB87FA9.LeftSahddow = false;
		DEB87FA9.Location = new System.Drawing.Point(1, 0);
		DEB87FA9.Name = "bunifuCards1";
		DEB87FA9.RightSahddow = true;
		DEB87FA9.ShadowDepth = 20;
		DEB87FA9.Size = new System.Drawing.Size(359, 37);
		DEB87FA9.TabIndex = 28;
		BA107317.AutoSize = true;
		BA107317.Location = new System.Drawing.Point(27, 109);
		BA107317.Name = "label2";
		BA107317.Size = new System.Drawing.Size(87, 16);
		BA107317.TabIndex = 58;
		BA107317.Text = "Gia\u0303n ca\u0301ch (s):";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(27, 80);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(63, 16);
		label4.TabIndex = 59;
		label4.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 264);
		base.Controls.Add(E4A1483A);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKetBanGoiY";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDKetBanGoiY_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		E4A1483A.ResumeLayout(false);
		E4A1483A.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudTimesWarning).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		DEB87FA9.ResumeLayout(false);
		ResumeLayout(false);
	}
}
