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

public class fHDKetBanThanhVienNhom : Form
{
	internal GClass4 gclass4_0;

	internal string BF0B4D87;

	internal string string_0;

	internal string E2AE2ABB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool CEB3C6B1;

	internal IContainer BB8C150F = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl A1377399;

	internal Panel panel1;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox txtTenHanhDong;

	internal Label E69A02B6;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards BB8E752A;

	internal Panel B4B8D02B;

	internal Button button1;

	internal PictureBox D135EF2B;

	internal BunifuCustomLabel C3077520;

	internal Label lblStatus;

	internal NumericUpDown F9119D3F;

	internal NumericUpDown nudDelayFrom;

	internal RichTextBox A593D49B;

	internal Label label7;

	internal Label label3;

	internal ComboBox cbbFacebookWeb;

	internal Label BEB3E020;

	internal CheckBox C60CBE13;

	internal Label A4951087;

	internal Label label9;

	public static bool A613A61D
	{
		[CompilerGenerated]
		get
		{
			return CEB3C6B1;
		}
		[CompilerGenerated]
		set
		{
			CEB3C6B1 = value;
		}
	}

	public fHDKetBanThanhVienNhom(string string_1, string string_2 = "")
	{
		InitializeComponent();
		A613A61D = false;
		BF0B4D87 = string_1;
		E2AE2ABB = string_2;
		string aA239C = Language.GetValue(C3077520.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_3 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			string_3 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_3, F79F9AB5: true);
		Language.CD21F0A9(this);
		FriendAutomationHelper.SetupModernFormUI(this);
	}

	private void B71DAE00(object sender, EventArgs e)
	{
		BEBD6A15();
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 3);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			F9119D3F.Value = gclass4_0.method_2("nudDelayTo", 5);
			C60CBE13.Checked = gclass4_0.method_3("ckbChiKetBanTenCoDau");
			A593D49B.Text = gclass4_0.BDB80B23("txtUid");
			cbbFacebookWeb.SelectedValue = gclass4_0.BDB80B23("cbbFacebookWeb", "2");
		}
		catch
		{
		}
	}

	private void BEBD6A15()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("2", "https://m.facebook.com/");
		dictionary.Add("1", "https://www.facebook.com/");
		Commom.smethod_24(cbbFacebookWeb, dictionary);
	}

	private void button1_Click(object sender, EventArgs e)
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
		List<string> list_ = A593D49B.Lines.ToList();
		list_ = Commom.smethod_36(list_);
		if (list_.Count == 0)
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách uid nhóm!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", F9119D3F.Value);
		gClass.method_4("ckbChiKetBanTenCoDau", C60CBE13.Checked);
		gClass.method_4("txtUid", A593D49B.Text.Trim());
		gClass.method_4("cbbFacebookWeb", cbbFacebookWeb.SelectedValue);
		string text2 = gClass.ED11179C();
		if (E2AE2ABB == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(BF0B4D87, text, string_0, text2))
				{
					A613A61D = true;
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
			if (Class154.smethod_13(E2AE2ABB, text, text2))
			{
				A613A61D = true;
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

	private void C124EF9B(object sender, EventArgs e)
	{
		Commom.A9BCAF05(A593D49B, lblStatus);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && BB8C150F != null)
		{
			BB8C150F.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		BB8C150F = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKetBanThanhVienNhom));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(BB8C150F);
		C3077520 = new Bunifu.Framework.UI.BunifuCustomLabel();
		A1377399 = new Bunifu.Framework.UI.BunifuDragControl(BB8C150F);
		B4B8D02B = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		D135EF2B = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		A4951087 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		C60CBE13 = new System.Windows.Forms.CheckBox();
		cbbFacebookWeb = new System.Windows.Forms.ComboBox();
		BEB3E020 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		A593D49B = new System.Windows.Forms.RichTextBox();
		F9119D3F = new System.Windows.Forms.NumericUpDown();
		lblStatus = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		E69A02B6 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		BB8E752A = new Bunifu.Framework.UI.BunifuCards();
		B4B8D02B.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D135EF2B).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F9119D3F).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		BB8E752A.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = C3077520;
		bunifuDragControl_0.Vertical = true;
		C3077520.BackColor = System.Drawing.Color.Transparent;
		C3077520.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C3077520.Dock = System.Windows.Forms.DockStyle.Fill;
		C3077520.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C3077520.ForeColor = System.Drawing.Color.Black;
		C3077520.Location = new System.Drawing.Point(0, 0);
		C3077520.Name = "bunifuCustomLabel1";
		C3077520.Size = new System.Drawing.Size(353, 31);
		C3077520.TabIndex = 12;
		C3077520.Text = "Cấu hình Kết bạn thành viên nhóm";
		C3077520.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A1377399.Fixed = true;
		A1377399.Horizontal = true;
		A1377399.TargetControl = B4B8D02B;
		A1377399.Vertical = true;
		B4B8D02B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B4B8D02B.BackColor = System.Drawing.Color.White;
		B4B8D02B.Controls.Add(button1);
		B4B8D02B.Controls.Add(D135EF2B);
		B4B8D02B.Controls.Add(C3077520);
		B4B8D02B.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B4B8D02B.Location = new System.Drawing.Point(0, 3);
		B4B8D02B.Name = "pnlHeader";
		B4B8D02B.Size = new System.Drawing.Size(353, 31);
		B4B8D02B.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(322, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		D135EF2B.Cursor = System.Windows.Forms.Cursors.Default;
		D135EF2B.Image = Class155.DD225F0D;
		D135EF2B.Location = new System.Drawing.Point(3, 2);
		D135EF2B.Name = "pictureBox1";
		D135EF2B.Size = new System.Drawing.Size(34, 27);
		D135EF2B.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		D135EF2B.TabIndex = 76;
		D135EF2B.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(A4951087);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(C60CBE13);
		panel1.Controls.Add(cbbFacebookWeb);
		panel1.Controls.Add(BEB3E020);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(A593D49B);
		panel1.Controls.Add(F9119D3F);
		panel1.Controls.Add(lblStatus);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(E69A02B6);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(BB8E752A);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(356, 369);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		A4951087.AutoSize = true;
		A4951087.Location = new System.Drawing.Point(27, 109);
		A4951087.Name = "label2";
		A4951087.Size = new System.Drawing.Size(87, 16);
		A4951087.TabIndex = 122;
		A4951087.Text = "Gia\u0303n ca\u0301ch (s):";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 123;
		label9.Text = "Sô\u0301 lươ\u0323ng:";
		C60CBE13.AutoSize = true;
		C60CBE13.Cursor = System.Windows.Forms.Cursors.Hand;
		C60CBE13.Location = new System.Drawing.Point(31, 297);
		C60CBE13.Name = "ckbChiKetBanTenCoDau";
		C60CBE13.Size = new System.Drawing.Size(211, 20);
		C60CBE13.TabIndex = 121;
		C60CBE13.Text = "Chỉ kết bạn với người có tên Việt";
		C60CBE13.UseVisualStyleBackColor = true;
		cbbFacebookWeb.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbFacebookWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbFacebookWeb.DropDownWidth = 120;
		cbbFacebookWeb.FormattingEnabled = true;
		cbbFacebookWeb.Location = new System.Drawing.Point(132, 416);
		cbbFacebookWeb.Name = "cbbFacebookWeb";
		cbbFacebookWeb.Size = new System.Drawing.Size(194, 24);
		cbbFacebookWeb.TabIndex = 120;
		BEB3E020.AutoSize = true;
		BEB3E020.Location = new System.Drawing.Point(27, 419);
		BEB3E020.Name = "label4";
		BEB3E020.Size = new System.Drawing.Size(96, 16);
		BEB3E020.TabIndex = 119;
		BEB3E020.Text = "Facebook Web:";
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(194, 109);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 117;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 116;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A593D49B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A593D49B.Location = new System.Drawing.Point(31, 156);
		A593D49B.Name = "txtUid";
		A593D49B.Size = new System.Drawing.Size(295, 136);
		A593D49B.TabIndex = 114;
		A593D49B.Text = "";
		A593D49B.WordWrap = false;
		A593D49B.TextChanged += new System.EventHandler(C124EF9B);
		F9119D3F.Location = new System.Drawing.Point(229, 107);
		F9119D3F.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		F9119D3F.Name = "nudDelayTo";
		F9119D3F.Size = new System.Drawing.Size(56, 23);
		F9119D3F.TabIndex = 4;
		lblStatus.AutoSize = true;
		lblStatus.Location = new System.Drawing.Point(27, 137);
		lblStatus.Name = "lblStatus";
		lblStatus.Size = new System.Drawing.Size(143, 16);
		lblStatus.TabIndex = 0;
		lblStatus.Text = "Danh sa\u0301ch Id nhóm (0):";
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
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
		E69A02B6.AutoSize = true;
		E69A02B6.Location = new System.Drawing.Point(27, 52);
		E69A02B6.Name = "label1";
		E69A02B6.Size = new System.Drawing.Size(98, 16);
		E69A02B6.TabIndex = 31;
		E69A02B6.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(190, 327);
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
		btnAdd.Location = new System.Drawing.Point(83, 327);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		BB8E752A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		BB8E752A.BackColor = System.Drawing.Color.White;
		BB8E752A.BorderRadius = 0;
		BB8E752A.BottomSahddow = true;
		BB8E752A.color = System.Drawing.Color.DarkViolet;
		BB8E752A.Controls.Add(B4B8D02B);
		BB8E752A.LeftSahddow = false;
		BB8E752A.Location = new System.Drawing.Point(1, 0);
		BB8E752A.Name = "bunifuCards1";
		BB8E752A.RightSahddow = true;
		BB8E752A.ShadowDepth = 20;
		BB8E752A.Size = new System.Drawing.Size(353, 37);
		BB8E752A.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(356, 369);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKetBanThanhVienNhom";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(B71DAE00);
		B4B8D02B.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D135EF2B).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)F9119D3F).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		BB8E752A.ResumeLayout(false);
		ResumeLayout(false);
	}
}
