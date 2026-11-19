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

public class fHDThamGiaNhomTuKhoa : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl BC83F4B2;

	internal Panel pnlTopAccent;

	internal Panel C720BD87;

	internal NumericUpDown FC3F3DB3;

	internal NumericUpDown A201D5BB;

	internal TextBox E30D69BE;

	internal Label label3;

	internal Label label4;

	internal Label label1;

	internal Button AF98F523;

	internal Button E8328C06;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button D783C535;

	internal Button btnMinimize;

	internal PictureBox CABA8A90;

	internal BunifuCustomLabel BE21B811;

	internal Label lblTuKhoa;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label7;

	internal Label label6;

	internal RichTextBox txtTuKhoa;

	internal ToolTip toolTip_0;

	internal Panel FE2DC62D;

	internal CheckBox ckbTuDongTraLoiCauHoi;

	internal Label lblCauTraLoi;

	internal RichTextBox txtCauTraLoi;

	internal Panel E4235A96;

	internal RichTextBox C120DEA6;

	internal Label lblGroupId;

	internal CheckBox F793392F;

	internal Label label2;

	internal Label AEA12D02;

	internal CheckBox ckbGoChuTimKiem;

	internal CheckBox ckbSkipJoined;

	internal CheckBox ckbDongYQuyTac;

	public static bool C387DA8F
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

	public fHDThamGiaNhomTuKhoa(string string_3, string B03FA29A = "")
	{
		InitializeComponent();
		C387DA8F = false;
		string_0 = string_3;
		string_2 = B03FA29A;
		string aA239C = Language.GetValue(BE21B811.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (B03FA29A == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			E30D69BE.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(B03FA29A);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			E8328C06.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			E30D69BE.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		base.Width = (Base.DB801CBD ? 677 : 355);

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

	private void F7BCA53D(object sender, EventArgs e)
	{
		try
		{
			A201D5BB.Value = gclass4_0.method_2("nudSoLuongFrom", 3);
			FC3F3DB3.Value = gclass4_0.method_2("nudSoLuongTo", 3);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			txtTuKhoa.Text = gclass4_0.BDB80B23("txtTuKhoa");
			ckbTuDongTraLoiCauHoi.Checked = gclass4_0.method_3("ckbTuDongTraLoiCauHoi");
			txtCauTraLoi.Text = gclass4_0.BDB80B23("txtCauTraLoi");
			F793392F.Checked = gclass4_0.method_3("ckbGroupId");
			C120DEA6.Text = gclass4_0.BDB80B23("txtGroupId");

			ckbGoChuTimKiem.Checked = gclass4_0.method_3("ckbGoChuTimKiem", true);
			ckbDongYQuyTac.Checked = gclass4_0.method_3("ckbDongYQuyTac", true);
			ckbSkipJoined.Checked = gclass4_0.method_3("ckbSkipJoined", true);
		}
		catch
		{
		}
		method_0();
	}

	private void method_0()
	{
		F4A77AA4(null, null);
		A3BD0FAF(null, null);
		Commom.A9BCAF05(txtTuKhoa, lblTuKhoa);
		Commom.A9BCAF05(txtCauTraLoi, lblCauTraLoi);
		Commom.A9BCAF05(C120DEA6, lblGroupId);
	}

	private void AD0194AC(object sender, EventArgs e)
	{
		Close();
	}

	private void E8328C06_Click(object sender, EventArgs e)
	{
		string text = E30D69BE.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		List<string> list_ = txtTuKhoa.Lines.ToList();
		list_ = Commom.smethod_36(list_);
		if (list_.Count == 0)
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách từ khóa!", 3);
			return;
		}
		if (ckbTuDongTraLoiCauHoi.Checked)
		{
			list_ = txtCauTraLoi.Lines.ToList();
			list_ = Commom.smethod_36(list_);
			if (list_.Count == 0)
			{
				MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p danh sách câu trả lời!", 3);
				return;
			}
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", A201D5BB.Value);
		gClass.method_4("nudSoLuongTo", FC3F3DB3.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("txtTuKhoa", txtTuKhoa.Text.Trim());
		gClass.method_4("ckbTuDongTraLoiCauHoi", ckbTuDongTraLoiCauHoi.Checked);
		gClass.method_4("txtCauTraLoi", txtCauTraLoi.Text.Trim());
		gClass.method_4("ckbGroupId", F793392F.Checked);
		gClass.method_4("txtGroupId", C120DEA6.Text.Trim());
		gClass.method_4("ckbGoChuTimKiem", ckbGoChuTimKiem.Checked);
		gClass.method_4("ckbDongYQuyTac", ckbDongYQuyTac.Checked);
		gClass.method_4("ckbSkipJoined", ckbSkipJoined.Checked);

		string e013A = gClass.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					C387DA8F = true;
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
				C387DA8F = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void EE14893C(object sender, EventArgs e)
	{
		Close();
	}

	private void E214BF20(object sender, PaintEventArgs e)
	{
		if (C720BD87.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, C720BD87.ClientSize.Width - num, C720BD87.ClientSize.Height - num));
		}
	}

	private void BA0DF00D(object sender, EventArgs e)
	{
		Commom.A9BCAF05(sender as RichTextBox, lblTuKhoa);
	}

	private void F4A77AA4(object sender, EventArgs e)
	{
		FE2DC62D.Enabled = ckbTuDongTraLoiCauHoi.Checked;
	}

	private void txtCauTraLoi_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(sender as RichTextBox, lblCauTraLoi);
	}

	private void C120DEA6_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(sender as RichTextBox, lblGroupId);
	}

	private void A3BD0FAF(object sender, EventArgs e)
	{
		E4235A96.Enabled = F793392F.Checked;
	}

	protected override void Dispose(bool F9180004)
	{
		if (F9180004 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(F9180004);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDThamGiaNhomTuKhoa));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		BE21B811 = new Bunifu.Framework.UI.BunifuCustomLabel();
		BC83F4B2 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlTopAccent = new System.Windows.Forms.Panel();
		pnlHeader = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		D783C535 = new System.Windows.Forms.Button();
		CABA8A90 = new System.Windows.Forms.PictureBox();
		C720BD87 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		AEA12D02 = new System.Windows.Forms.Label();
		E4235A96 = new System.Windows.Forms.Panel();
		C120DEA6 = new System.Windows.Forms.RichTextBox();
		lblGroupId = new System.Windows.Forms.Label();
		FE2DC62D = new System.Windows.Forms.Panel();
		txtCauTraLoi = new System.Windows.Forms.RichTextBox();
		lblCauTraLoi = new System.Windows.Forms.Label();
		F793392F = new System.Windows.Forms.CheckBox();
		ckbDongYQuyTac = new System.Windows.Forms.CheckBox();
		ckbTuDongTraLoiCauHoi = new System.Windows.Forms.CheckBox();
		ckbSkipJoined = new System.Windows.Forms.CheckBox();
		ckbGoChuTimKiem = new System.Windows.Forms.CheckBox();
		txtTuKhoa = new System.Windows.Forms.RichTextBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		lblTuKhoa = new System.Windows.Forms.Label();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label7 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		FC3F3DB3 = new System.Windows.Forms.NumericUpDown();
		A201D5BB = new System.Windows.Forms.NumericUpDown();
		E30D69BE = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		AF98F523 = new System.Windows.Forms.Button();
		E8328C06 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		toolTip_0 = new System.Windows.Forms.ToolTip(icontainer_0);
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CABA8A90).BeginInit();
		C720BD87.SuspendLayout();
		E4235A96.SuspendLayout();
		FE2DC62D.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)FC3F3DB3).BeginInit();
		((System.ComponentModel.ISupportInitialize)A201D5BB).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();

		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = BE21B811;
		bunifuDragControl_0.Vertical = true;

		BE21B811.BackColor = System.Drawing.Color.Transparent;
		BE21B811.Cursor = System.Windows.Forms.Cursors.SizeAll;
		BE21B811.Dock = System.Windows.Forms.DockStyle.Fill;
		BE21B811.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BE21B811.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
		BE21B811.Location = new System.Drawing.Point(0, 0);
		BE21B811.Name = "bunifuCustomLabel1";
		BE21B811.Size = new System.Drawing.Size(352, 32);
		BE21B811.TabIndex = 12;
		BE21B811.Text = "Cấu hình Tham gia nhóm theo từ khóa";
		BE21B811.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		BC83F4B2.Fixed = true;
		BC83F4B2.Horizontal = true;
		BC83F4B2.TargetControl = pnlHeader;
		BC83F4B2.Vertical = true;

		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(D783C535);
		pnlHeader.Controls.Add(CABA8A90);
		pnlHeader.Controls.Add(BE21B811);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 0);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(352, 32);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (D783C535 != null) D783C535.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
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
		btnMinimize.Location = new System.Drawing.Point(284, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };

		// Close Button
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		D783C535.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D783C535.Cursor = System.Windows.Forms.Cursors.Hand;
		D783C535.FlatAppearance.BorderSize = 0;
		D783C535.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D783C535.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		D783C535.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		D783C535.Text = iconClose == null ? "✕" : "";
		D783C535.Location = new System.Drawing.Point(318, 1);
		D783C535.Name = "button1";
		D783C535.Size = new System.Drawing.Size(30, 30);
		D783C535.TabIndex = 77;
		D783C535.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D783C535.UseVisualStyleBackColor = true;
		D783C535.Click += new System.EventHandler(AD0194AC);

		// Header Group Icon
		System.Drawing.Image groupIcon = AppIconHelper.GetIcon("group.png", 22, 22);
		CABA8A90.Cursor = System.Windows.Forms.Cursors.Default;
		CABA8A90.Image = groupIcon ?? Class155.DD225F0D;
		CABA8A90.Location = new System.Drawing.Point(6, 4);
		CABA8A90.Name = "pictureBox1";
		CABA8A90.Size = new System.Drawing.Size(24, 24);
		CABA8A90.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		CABA8A90.TabIndex = 76;
		CABA8A90.TabStop = false;

		// Main Panel Container
		C720BD87.BackColor = System.Drawing.Color.White;
		C720BD87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C720BD87.Controls.Add(pnlTopAccent);
		C720BD87.Controls.Add(bunifuCards1);
		C720BD87.Controls.Add(label2);
		C720BD87.Controls.Add(AEA12D02);
		C720BD87.Controls.Add(E4235A96);
		C720BD87.Controls.Add(FE2DC62D);
		C720BD87.Controls.Add(F793392F);
		C720BD87.Controls.Add(ckbDongYQuyTac);
		C720BD87.Controls.Add(ckbTuDongTraLoiCauHoi);
		C720BD87.Controls.Add(ckbSkipJoined);
		C720BD87.Controls.Add(ckbGoChuTimKiem);
		C720BD87.Controls.Add(txtTuKhoa);
		C720BD87.Controls.Add(nudDelayTo);
		C720BD87.Controls.Add(lblTuKhoa);
		C720BD87.Controls.Add(nudDelayFrom);
		C720BD87.Controls.Add(label7);
		C720BD87.Controls.Add(label6);
		C720BD87.Controls.Add(FC3F3DB3);
		C720BD87.Controls.Add(A201D5BB);
		C720BD87.Controls.Add(E30D69BE);
		C720BD87.Controls.Add(label3);
		C720BD87.Controls.Add(label4);
		C720BD87.Controls.Add(label1);
		C720BD87.Controls.Add(AF98F523);
		C720BD87.Controls.Add(E8328C06);
		C720BD87.Cursor = System.Windows.Forms.Cursors.Arrow;
		C720BD87.Dock = System.Windows.Forms.DockStyle.Fill;
		C720BD87.Location = new System.Drawing.Point(0, 0);
		C720BD87.Name = "panel1";
		C720BD87.Size = new System.Drawing.Size(355, 530);
		C720BD87.TabIndex = 0;
		C720BD87.Paint += new System.Windows.Forms.PaintEventHandler(E214BF20);

		// Top Card Bar
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = false;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 4);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = false;
		bunifuCards1.ShadowDepth = 0;
		bunifuCards1.Size = new System.Drawing.Size(352, 34);
		bunifuCards1.TabIndex = 28;

		// Row 1: Tên hành động
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 48);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";

		E30D69BE.Location = new System.Drawing.Point(132, 45);
		E30D69BE.Name = "txtTenHanhDong";
		E30D69BE.Size = new System.Drawing.Size(194, 23);
		E30D69BE.TabIndex = 0;

		// Row 2: Số lượng
		AEA12D02.AutoSize = true;
		AEA12D02.Location = new System.Drawing.Point(27, 76);
		AEA12D02.Name = "label9";
		AEA12D02.Size = new System.Drawing.Size(63, 16);
		AEA12D02.TabIndex = 118;
		AEA12D02.Text = "Sô\u0301 lươ\u0323ng:";

		A201D5BB.Location = new System.Drawing.Point(132, 74);
		A201D5BB.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		A201D5BB.Name = "nudSoLuongFrom";
		A201D5BB.Size = new System.Drawing.Size(56, 23);
		A201D5BB.TabIndex = 1;

		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 76);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		FC3F3DB3.Location = new System.Drawing.Point(229, 74);
		FC3F3DB3.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FC3F3DB3.Name = "nudSoLuongTo";
		FC3F3DB3.Size = new System.Drawing.Size(56, 23);
		FC3F3DB3.TabIndex = 2;

		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(287, 76);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(39, 16);
		label4.TabIndex = 35;
		label4.Text = "nhóm";

		// Row 3: Giãn cách
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 104);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 117;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";

		nudDelayFrom.Location = new System.Drawing.Point(132, 102);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;

		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(194, 104);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 46;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		nudDelayTo.Location = new System.Drawing.Point(229, 102);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;

		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(287, 104);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(30, 16);
		label6.TabIndex = 45;
		label6.Text = "giây";

		// Row 4 & 5: Checkboxes Tùy chọn xịn (Human Typing & Bỏ qua nhóm đã vào)
		ckbGoChuTimKiem.AutoSize = true;
		ckbGoChuTimKiem.Checked = true;
		ckbGoChuTimKiem.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbGoChuTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGoChuTimKiem.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbGoChuTimKiem.Location = new System.Drawing.Point(27, 131);
		ckbGoChuTimKiem.Name = "ckbGoChuTimKiem";
		ckbGoChuTimKiem.Size = new System.Drawing.Size(286, 20);
		ckbGoChuTimKiem.TabIndex = 119;
		ckbGoChuTimKiem.Text = "Gõ chữ tìm kiếm như người thật (Human typing)";
		ckbGoChuTimKiem.UseVisualStyleBackColor = true;

		ckbSkipJoined.AutoSize = true;
		ckbSkipJoined.Checked = true;
		ckbSkipJoined.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbSkipJoined.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSkipJoined.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbSkipJoined.Location = new System.Drawing.Point(27, 154);
		ckbSkipJoined.Name = "ckbSkipJoined";
		ckbSkipJoined.Size = new System.Drawing.Size(271, 20);
		ckbSkipJoined.TabIndex = 120;
		ckbSkipJoined.Text = "Bỏ qua nhóm đã tham gia hoặc chờ duyệt";
		ckbSkipJoined.UseVisualStyleBackColor = true;

		// Row 6: Danh sách từ khóa
		lblTuKhoa.AutoSize = true;
		lblTuKhoa.Location = new System.Drawing.Point(27, 178);
		lblTuKhoa.Name = "lblTuKhoa";
		lblTuKhoa.Size = new System.Drawing.Size(139, 16);
		lblTuKhoa.TabIndex = 0;
		lblTuKhoa.Text = "Danh sa\u0301ch từ khóa (0):";

		txtTuKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtTuKhoa.Location = new System.Drawing.Point(30, 198);
		txtTuKhoa.Name = "txtTuKhoa";
		txtTuKhoa.Size = new System.Drawing.Size(295, 100);
		txtTuKhoa.TabIndex = 114;
		txtTuKhoa.Text = "";
		txtTuKhoa.WordWrap = false;
		txtTuKhoa.TextChanged += new System.EventHandler(BA0DF00D);

		// Row 7 & 8: Checkbox Đồng ý quy tắc & Tự động trả lời câu hỏi
		ckbDongYQuyTac.AutoSize = true;
		ckbDongYQuyTac.Checked = true;
		ckbDongYQuyTac.CheckState = System.Windows.Forms.CheckState.Checked;
		ckbDongYQuyTac.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDongYQuyTac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbDongYQuyTac.Location = new System.Drawing.Point(27, 303);
		ckbDongYQuyTac.Name = "ckbDongYQuyTac";
		ckbDongYQuyTac.Size = new System.Drawing.Size(253, 20);
		ckbDongYQuyTac.TabIndex = 121;
		ckbDongYQuyTac.Text = "Tự động đồng ý quy tắc nhóm (Rules)";
		ckbDongYQuyTac.UseVisualStyleBackColor = true;

		ckbTuDongTraLoiCauHoi.AutoSize = true;
		ckbTuDongTraLoiCauHoi.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongTraLoiCauHoi.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbTuDongTraLoiCauHoi.Location = new System.Drawing.Point(27, 325);
		ckbTuDongTraLoiCauHoi.Name = "ckbTuDongTraLoiCauHoi";
		ckbTuDongTraLoiCauHoi.Size = new System.Drawing.Size(156, 20);
		ckbTuDongTraLoiCauHoi.TabIndex = 115;
		ckbTuDongTraLoiCauHoi.Text = "Tự động trả lời câu hỏi";
		ckbTuDongTraLoiCauHoi.UseVisualStyleBackColor = true;
		ckbTuDongTraLoiCauHoi.CheckedChanged += new System.EventHandler(F4A77AA4);

		// Panel Câu trả lời
		FE2DC62D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		FE2DC62D.Controls.Add(txtCauTraLoi);
		FE2DC62D.Controls.Add(lblCauTraLoi);
		FE2DC62D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		FE2DC62D.Location = new System.Drawing.Point(30, 348);
		FE2DC62D.Name = "plTuongTac";
		FE2DC62D.Size = new System.Drawing.Size(295, 125);
		FE2DC62D.TabIndex = 116;

		lblCauTraLoi.AutoSize = true;
		lblCauTraLoi.Location = new System.Drawing.Point(3, 4);
		lblCauTraLoi.Name = "lblCauTraLoi";
		lblCauTraLoi.Size = new System.Drawing.Size(153, 16);
		lblCauTraLoi.TabIndex = 0;
		lblCauTraLoi.Text = "Danh sách câu trả lời (0):";

		txtCauTraLoi.Location = new System.Drawing.Point(6, 23);
		txtCauTraLoi.Name = "txtCauTraLoi";
		txtCauTraLoi.Size = new System.Drawing.Size(281, 95);
		txtCauTraLoi.TabIndex = 117;
		txtCauTraLoi.Text = "";
		txtCauTraLoi.WordWrap = false;
		txtCauTraLoi.TextChanged += new System.EventHandler(txtCauTraLoi_TextChanged);

		// Optional Right Panel (Base.DB801CBD)
		F793392F.AutoSize = true;
		F793392F.Cursor = System.Windows.Forms.Cursors.Hand;
		F793392F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		F793392F.Location = new System.Drawing.Point(365, 138);
		F793392F.Name = "ckbGroupId";
		F793392F.Size = new System.Drawing.Size(260, 20);
		F793392F.TabIndex = 115;
		F793392F.Text = "Chỉ tham gia nhóm thuộc danh sách sau:";
		F793392F.UseVisualStyleBackColor = true;
		F793392F.CheckedChanged += new System.EventHandler(A3BD0FAF);

		E4235A96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E4235A96.Controls.Add(C120DEA6);
		E4235A96.Controls.Add(lblGroupId);
		E4235A96.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		E4235A96.Location = new System.Drawing.Point(365, 160);
		E4235A96.Name = "plGroupId";
		E4235A96.Size = new System.Drawing.Size(278, 313);
		E4235A96.TabIndex = 116;

		lblGroupId.AutoSize = true;
		lblGroupId.Location = new System.Drawing.Point(3, 4);
		lblGroupId.Name = "lblGroupId";
		lblGroupId.Size = new System.Drawing.Size(143, 16);
		lblGroupId.TabIndex = 0;
		lblGroupId.Text = "Danh sách Id nhóm (0):";

		C120DEA6.Location = new System.Drawing.Point(6, 23);
		C120DEA6.Name = "txtGroupId";
		C120DEA6.Size = new System.Drawing.Size(266, 283);
		C120DEA6.TabIndex = 117;
		C120DEA6.Text = "";
		C120DEA6.WordWrap = false;
		C120DEA6.TextChanged += new System.EventHandler(C120DEA6_TextChanged);

		// Action Buttons (Thêm / Cập nhật & Đóng)
		E8328C06.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		E8328C06.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		E8328C06.Cursor = System.Windows.Forms.Cursors.Hand;
		E8328C06.FlatAppearance.BorderSize = 0;
		E8328C06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E8328C06.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E8328C06.ForeColor = System.Drawing.Color.White;
		E8328C06.Location = new System.Drawing.Point(75, 484);
		E8328C06.Name = "btnAdd";
		E8328C06.Size = new System.Drawing.Size(95, 32);
		E8328C06.TabIndex = 6;
		E8328C06.Text = "Thêm";
		E8328C06.UseVisualStyleBackColor = false;
		E8328C06.Click += new System.EventHandler(E8328C06_Click);

		AF98F523.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		AF98F523.BackColor = System.Drawing.Color.Maroon;
		AF98F523.Cursor = System.Windows.Forms.Cursors.Hand;
		AF98F523.FlatAppearance.BorderSize = 0;
		AF98F523.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AF98F523.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AF98F523.ForeColor = System.Drawing.Color.White;
		AF98F523.Location = new System.Drawing.Point(185, 484);
		AF98F523.Name = "btnCancel";
		AF98F523.Size = new System.Drawing.Size(95, 32);
		AF98F523.TabIndex = 7;
		AF98F523.Text = "Đóng";
		AF98F523.UseVisualStyleBackColor = false;
		AF98F523.Click += new System.EventHandler(EE14893C);

		// ToolTip
		toolTip_0.AutomaticDelay = 0;
		toolTip_0.AutoPopDelay = 0;
		toolTip_0.InitialDelay = 0;
		toolTip_0.ReshowDelay = 0;
		toolTip_0.ShowAlways = true;

		// Form Root Properties
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(355, 530);
		base.Controls.Add(C720BD87);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDThamGiaNhomTuKhoa";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(F7BCA53D);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)CABA8A90).EndInit();
		C720BD87.ResumeLayout(false);
		C720BD87.PerformLayout();
		E4235A96.ResumeLayout(false);
		E4235A96.PerformLayout();
		FE2DC62D.ResumeLayout(false);
		FE2DC62D.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)FC3F3DB3).EndInit();
		((System.ComponentModel.ISupportInitialize)A201D5BB).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
