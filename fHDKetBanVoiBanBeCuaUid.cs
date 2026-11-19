using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDKetBanVoiBanBeCuaUid : Form
{
	internal GClass4 gclass4_0;

	internal string F8BFE7AC;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool C2BFE891;

	internal IContainer C22D25BF = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl DBA63A39;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown C70A559E;

	internal TextBox BE379AA8;

	internal Label label3;

	internal Label label1;

	internal Button A10DCA1B;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel A4A31E0F;

	internal Label DA95F992;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal RichTextBox C52ED803;

	internal CheckBox EBB8BE1D;

	internal Label A924118A;

	internal Label FD3D7F9B;

	internal Panel plTuyChon;

	internal ComboBox EB34DE87;

	internal Label label4;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return C2BFE891;
		}
		[CompilerGenerated]
		set
		{
			C2BFE891 = value;
		}
	}

	public fHDKetBanVoiBanBeCuaUid(string string_2, string FB9D2B83 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		F8BFE7AC = string_2;
		string_1 = FB9D2B83;
		string aA239C = Language.GetValue(A4A31E0F.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (FB9D2B83 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			BE379AA8.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(FB9D2B83);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			BE379AA8.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void E70C200E()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Ngẫu nhiên ba\u0323n be\u0300");
		dictionary.Add("1", "User chi\u0309 đi\u0323nh");
		Commom.smethod_24(EB34DE87, dictionary);
	}

	private void BB0FDB0A(object sender, EventArgs e)
	{
		E70C200E();
		try
		{
			C70A559E.Value = gclass4_0.method_2("nudSoLuongFrom", 3);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 5);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			EB34DE87.SelectedValue = gclass4_0.BDB80B23("cbbTuyChon", "0");
			C52ED803.Text = gclass4_0.BDB80B23("txtUid");
			EBB8BE1D.Checked = gclass4_0.method_3("ckbTuDongXoaUid");
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = BE379AA8.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", C70A559E.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("cbbTuyChon", EB34DE87.SelectedValue);
		gClass.method_4("txtUid", C52ED803.Text.Trim());
		gClass.method_4("ckbTuDongXoaUid", EBB8BE1D.Checked);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(F8BFE7AC, text, string_0, e013A))
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

	private void A10DCA1B_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void EF2D2238(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	private void C52ED803_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(C52ED803, DA95F992);
	}

	private void E88CE594(object sender, EventArgs e)
	{
		plTuyChon.Enabled = EB34DE87.SelectedValue.ToString() == "1";
	}

	protected override void Dispose(bool BBA252BF)
	{
		if (BBA252BF && C22D25BF != null)
		{
			C22D25BF.Dispose();
		}
		base.Dispose(BBA252BF);
	}

	private void InitializeComponent()
	{
		C22D25BF = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKetBanVoiBanBeCuaUid));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(C22D25BF);
		A4A31E0F = new Bunifu.Framework.UI.BunifuCustomLabel();
		DBA63A39 = new Bunifu.Framework.UI.BunifuDragControl(C22D25BF);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		plTuyChon = new System.Windows.Forms.Panel();
		DA95F992 = new System.Windows.Forms.Label();
		C52ED803 = new System.Windows.Forms.RichTextBox();
		EBB8BE1D = new System.Windows.Forms.CheckBox();
		EB34DE87 = new System.Windows.Forms.ComboBox();
		label4 = new System.Windows.Forms.Label();
		A924118A = new System.Windows.Forms.Label();
		FD3D7F9B = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		C70A559E = new System.Windows.Forms.NumericUpDown();
		BE379AA8 = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		A10DCA1B = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		plTuyChon.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)C70A559E).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = A4A31E0F;
		bunifuDragControl_0.Vertical = true;
		A4A31E0F.BackColor = System.Drawing.Color.Transparent;
		A4A31E0F.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A4A31E0F.Dock = System.Windows.Forms.DockStyle.Fill;
		A4A31E0F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A4A31E0F.ForeColor = System.Drawing.Color.Black;
		A4A31E0F.Location = new System.Drawing.Point(0, 0);
		A4A31E0F.Name = "bunifuCustomLabel1";
		A4A31E0F.Size = new System.Drawing.Size(380, 31);
		A4A31E0F.TabIndex = 12;
		A4A31E0F.Text = "Cấu hình Kết bạn với bạn bè của Uid";
		A4A31E0F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DBA63A39.Fixed = true;
		DBA63A39.Horizontal = true;
		DBA63A39.TargetControl = pnlHeader;
		DBA63A39.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(A4A31E0F);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(380, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(349, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
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
		panel1.Controls.Add(plTuyChon);
		panel1.Controls.Add(EB34DE87);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(A924118A);
		panel1.Controls.Add(FD3D7F9B);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(C70A559E);
		panel1.Controls.Add(BE379AA8);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(A10DCA1B);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(383, 419);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(EF2D2238);
		plTuyChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuyChon.Controls.Add(DA95F992);
		plTuyChon.Controls.Add(C52ED803);
		plTuyChon.Controls.Add(EBB8BE1D);
		plTuyChon.Location = new System.Drawing.Point(31, 166);
		plTuyChon.Name = "plTuyChon";
		plTuyChon.Size = new System.Drawing.Size(318, 190);
		plTuyChon.TabIndex = 197;
		DA95F992.AutoSize = true;
		DA95F992.Location = new System.Drawing.Point(0, 4);
		DA95F992.Name = "lblUid";
		DA95F992.Size = new System.Drawing.Size(114, 16);
		DA95F992.TabIndex = 0;
		DA95F992.Text = "Danh sa\u0301ch Uid (0):";
		C52ED803.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C52ED803.Location = new System.Drawing.Point(4, 24);
		C52ED803.Name = "txtUid";
		C52ED803.Size = new System.Drawing.Size(308, 136);
		C52ED803.TabIndex = 114;
		C52ED803.Text = "";
		C52ED803.WordWrap = false;
		C52ED803.TextChanged += new System.EventHandler(C52ED803_TextChanged);
		EBB8BE1D.AutoSize = true;
		EBB8BE1D.Cursor = System.Windows.Forms.Cursors.Hand;
		EBB8BE1D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		EBB8BE1D.Location = new System.Drawing.Point(3, 164);
		EBB8BE1D.Name = "ckbTuDongXoaUid";
		EBB8BE1D.Size = new System.Drawing.Size(170, 20);
		EBB8BE1D.TabIndex = 115;
		EBB8BE1D.Text = "Tư\u0323 đô\u0323ng xo\u0301a Uid đa\u0303 dùng";
		EBB8BE1D.UseVisualStyleBackColor = true;
		EB34DE87.Cursor = System.Windows.Forms.Cursors.Hand;
		EB34DE87.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		EB34DE87.DropDownWidth = 200;
		EB34DE87.FormattingEnabled = true;
		EB34DE87.Location = new System.Drawing.Point(155, 136);
		EB34DE87.Name = "cbbTuyChon";
		EB34DE87.Size = new System.Drawing.Size(194, 24);
		EB34DE87.TabIndex = 196;
		EB34DE87.SelectedIndexChanged += new System.EventHandler(E88CE594);
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(28, 139);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(122, 16);
		label4.TabIndex = 195;
		label4.Text = "Tu\u0300y cho\u0323n đô\u0301i tươ\u0323ng:";
		A924118A.AutoSize = true;
		A924118A.Location = new System.Drawing.Point(28, 107);
		A924118A.Name = "label2";
		A924118A.Size = new System.Drawing.Size(87, 16);
		A924118A.TabIndex = 116;
		A924118A.Text = "Gia\u0303n ca\u0301ch (s):";
		FD3D7F9B.AutoSize = true;
		FD3D7F9B.Location = new System.Drawing.Point(28, 80);
		FD3D7F9B.Name = "label9";
		FD3D7F9B.Size = new System.Drawing.Size(63, 16);
		FD3D7F9B.TabIndex = 117;
		FD3D7F9B.Text = "Sô\u0301 lươ\u0323ng:";
		nudDelayTo.Location = new System.Drawing.Point(252, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(155, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(222, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(18, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		nudSoLuongTo.Location = new System.Drawing.Point(252, 78);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		C70A559E.Location = new System.Drawing.Point(155, 78);
		C70A559E.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C70A559E.Name = "nudSoLuongFrom";
		C70A559E.Size = new System.Drawing.Size(56, 23);
		C70A559E.TabIndex = 1;
		BE379AA8.Location = new System.Drawing.Point(155, 49);
		BE379AA8.Name = "txtTenHanhDong";
		BE379AA8.Size = new System.Drawing.Size(194, 23);
		BE379AA8.TabIndex = 0;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(222, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(18, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(28, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		A10DCA1B.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A10DCA1B.BackColor = System.Drawing.Color.Maroon;
		A10DCA1B.Cursor = System.Windows.Forms.Cursors.Hand;
		A10DCA1B.FlatAppearance.BorderSize = 0;
		A10DCA1B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A10DCA1B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A10DCA1B.ForeColor = System.Drawing.Color.White;
		A10DCA1B.Location = new System.Drawing.Point(200, 373);
		A10DCA1B.Name = "btnCancel";
		A10DCA1B.Size = new System.Drawing.Size(92, 29);
		A10DCA1B.TabIndex = 7;
		A10DCA1B.Text = "Đóng";
		A10DCA1B.UseVisualStyleBackColor = false;
		A10DCA1B.Click += new System.EventHandler(A10DCA1B_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(93, 373);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(380, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(383, 419);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKetBanVoiBanBeCuaUid";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(BB0FDB0A);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plTuyChon.ResumeLayout(false);
		plTuyChon.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)C70A559E).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
