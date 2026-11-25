using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDSharePage : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string A2B73EA5;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool CDAD6086;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel A7BE1105;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox B00D29BC;

	internal Label label3;

	internal Label label4;

	internal Label label1;

	internal Button C6AA632D;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel EDB687A6;

	internal NumericUpDown E8A66F3D;

	internal NumericUpDown ED3D3836;

	internal Label F7285D87;

	internal Label label6;

	internal TextBox BA85DC11;

	internal Label D083B794;

	internal CheckBox ckbLeavePage;

	internal Label label2;

	internal Label label9;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return CDAD6086;
		}
		[CompilerGenerated]
		set
		{
			CDAD6086 = value;
		}
	}

	public fHDSharePage(string string_2, string string_3 = "")
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
		Boolean_0 = false;
		string_0 = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(EDB687A6.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			A2B73EA5 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			B00D29BC.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			B00D29BC.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDSharePage_Load(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 1);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 1);
			ED3D3836.Value = gclass4_0.method_2("nudDelayFrom", 3);
			E8A66F3D.Value = gclass4_0.method_2("nudDelayTo", 5);
			BA85DC11.Text = gclass4_0.BDB80B23("txtToCookie");
			ckbLeavePage.Checked = gclass4_0.method_3("ckbLeavePage");
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C18A1AB8(object sender, EventArgs e)
	{
		string text = B00D29BC.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		gClass.method_4("nudDelayFrom", ED3D3836.Value);
		gClass.method_4("nudDelayTo", E8A66F3D.Value);
		gClass.method_4("txtToCookie", BA85DC11.Text);
		gClass.method_4("ckbLeavePage", ckbLeavePage.Checked);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, A2B73EA5, e013A))
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

	private void C6AA632D_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void A7BE1105_Paint(object sender, PaintEventArgs e)
	{
		if (A7BE1105.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, A7BE1105.ClientSize.Width - num, A7BE1105.ClientSize.Height - num));
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
		pnlTopAccent = new System.Windows.Forms.Panel();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDSharePage));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		EDB687A6 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		A7BE1105 = new System.Windows.Forms.Panel();
		ckbLeavePage = new System.Windows.Forms.CheckBox();
		E8A66F3D = new System.Windows.Forms.NumericUpDown();
		ED3D3836 = new System.Windows.Forms.NumericUpDown();
		F7285D87 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		BA85DC11 = new System.Windows.Forms.TextBox();
		B00D29BC = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		D083B794 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		C6AA632D = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		A7BE1105.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E8A66F3D).BeginInit();
		((System.ComponentModel.ISupportInitialize)ED3D3836).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = EDB687A6;
		bunifuDragControl_0.Vertical = true;
		EDB687A6.BackColor = System.Drawing.Color.Transparent;
		EDB687A6.Cursor = System.Windows.Forms.Cursors.SizeAll;
		EDB687A6.Dock = System.Windows.Forms.DockStyle.Fill;
		EDB687A6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EDB687A6.ForeColor = System.Drawing.Color.Black;
		EDB687A6.Location = new System.Drawing.Point(0, 0);
		EDB687A6.Name = "bunifuCustomLabel1";
		EDB687A6.Size = new System.Drawing.Size(352, 31);
		EDB687A6.TabIndex = 12;
		EDB687A6.Text = "Cấu hình Share page";
		EDB687A6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(EDB687A6);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(352, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(321, 1);
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
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		A7BE1105.BackColor = System.Drawing.Color.White;
		A7BE1105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A7BE1105.Controls.Add(pnlTopAccent);
		A7BE1105.BringToFront();
		A7BE1105.Controls.Add(label2);
		A7BE1105.Controls.Add(label9);
		A7BE1105.Controls.Add(ckbLeavePage);
		A7BE1105.Controls.Add(E8A66F3D);
		A7BE1105.Controls.Add(ED3D3836);
		A7BE1105.Controls.Add(F7285D87);
		A7BE1105.Controls.Add(label6);
		A7BE1105.Controls.Add(nudSoLuongTo);
		A7BE1105.Controls.Add(nudSoLuongFrom);
		A7BE1105.Controls.Add(BA85DC11);
		A7BE1105.Controls.Add(B00D29BC);
		A7BE1105.Controls.Add(label3);
		A7BE1105.Controls.Add(label4);
		A7BE1105.Controls.Add(D083B794);
		A7BE1105.Controls.Add(label1);
		A7BE1105.Controls.Add(C6AA632D);
		A7BE1105.Controls.Add(btnAdd);
		A7BE1105.Controls.Add(bunifuCards1);
		A7BE1105.Cursor = System.Windows.Forms.Cursors.Arrow;
		A7BE1105.Dock = System.Windows.Forms.DockStyle.Fill;
		A7BE1105.Location = new System.Drawing.Point(0, 0);
		A7BE1105.Name = "panel1";
		A7BE1105.Size = new System.Drawing.Size(355, 240);
		A7BE1105.TabIndex = 0;
		A7BE1105.Paint += new System.Windows.Forms.PaintEventHandler(A7BE1105_Paint);
		ckbLeavePage.AutoSize = true;
		ckbLeavePage.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLeavePage.Location = new System.Drawing.Point(30, 164);
		ckbLeavePage.Name = "ckbLeavePage";
		ckbLeavePage.Size = new System.Drawing.Size(223, 20);
		ckbLeavePage.TabIndex = 47;
		ckbLeavePage.Text = "Rời page sau khi share thành công";
		ckbLeavePage.UseVisualStyleBackColor = true;
		E8A66F3D.Location = new System.Drawing.Point(229, 107);
		E8A66F3D.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E8A66F3D.Name = "nudDelayTo";
		E8A66F3D.Size = new System.Drawing.Size(56, 23);
		E8A66F3D.TabIndex = 4;
		ED3D3836.Location = new System.Drawing.Point(132, 107);
		ED3D3836.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		ED3D3836.Name = "nudDelayFrom";
		ED3D3836.Size = new System.Drawing.Size(56, 23);
		ED3D3836.TabIndex = 3;
		F7285D87.AutoSize = true;
		F7285D87.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F7285D87.Location = new System.Drawing.Point(199, 109);
		F7285D87.Name = "label7";
		F7285D87.Size = new System.Drawing.Size(18, 16);
		F7285D87.TabIndex = 46;
		F7285D87.Text = ">";
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(290, 109);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(13, 16);
		label6.TabIndex = 45;
		label6.Text = "s";
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
		BA85DC11.Location = new System.Drawing.Point(132, 135);
		BA85DC11.Name = "txtToCookie";
		BA85DC11.Size = new System.Drawing.Size(194, 23);
		BA85DC11.TabIndex = 0;
		B00D29BC.Location = new System.Drawing.Point(132, 49);
		B00D29BC.Name = "txtTenHanhDong";
		B00D29BC.Size = new System.Drawing.Size(194, 23);
		B00D29BC.TabIndex = 0;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(199, 80);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(18, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(290, 80);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(35, 16);
		label4.TabIndex = 35;
		label4.Text = "page";
		D083B794.AutoSize = true;
		D083B794.Location = new System.Drawing.Point(27, 137);
		D083B794.Name = "label10";
		D083B794.Size = new System.Drawing.Size(82, 16);
		D083B794.TabIndex = 31;
		D083B794.Text = "Cookie nhận:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		C6AA632D.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C6AA632D.BackColor = System.Drawing.Color.Maroon;
		C6AA632D.Cursor = System.Windows.Forms.Cursors.Hand;
		C6AA632D.FlatAppearance.BorderSize = 0;
		C6AA632D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C6AA632D.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C6AA632D.ForeColor = System.Drawing.Color.White;
		C6AA632D.Location = new System.Drawing.Point(184, 196);
		C6AA632D.Name = "btnCancel";
		C6AA632D.Size = new System.Drawing.Size(92, 29);
		C6AA632D.TabIndex = 7;
		C6AA632D.Text = "Đóng";
		C6AA632D.UseVisualStyleBackColor = false;
		C6AA632D.Click += new System.EventHandler(C6AA632D_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(77, 196);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 6;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(C18A1AB8);
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
		bunifuCards1.Size = new System.Drawing.Size(352, 37);
		bunifuCards1.TabIndex = 28;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 48;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(27, 80);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(63, 16);
		label9.TabIndex = 49;
		label9.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(355, 240);
		base.Controls.Add(A7BE1105);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDSharePage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDSharePage_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		A7BE1105.ResumeLayout(false);
		A7BE1105.PerformLayout();
		((System.ComponentModel.ISupportInitialize)E8A66F3D).EndInit();
		((System.ComponentModel.ISupportInitialize)ED3D3836).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
