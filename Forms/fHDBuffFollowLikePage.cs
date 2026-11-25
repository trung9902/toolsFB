using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBuffFollowLikePage : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 gclass4_0;

	internal string F590F31C;

	internal string BC94A7A1;

	internal string F4A7F68E;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer E93D122F = null;

	internal BunifuDragControl AA8A1D99;

	internal BunifuDragControl BB8D7B33;

	internal Panel E9209CAC;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown E78A479B;

	internal TextBox C03CD408;

	internal Label E128A22E;

	internal Label label5;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards FE928E97;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox A7A5EEB6;

	internal BunifuCustomLabel AE3E1180;

	internal Label label2;

	internal RichTextBox txtUid;

	public static bool B9925900
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

	public fHDBuffFollowLikePage(string CC985D05, string string_0 = "")
	{
		InitializeComponent();
		B9925900 = false;
		F590F31C = CC985D05;
		F4A7F68E = string_0;
		string aA239C = Language.GetValue(AE3E1180.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string string_ = base.Name.Substring(1);
		Class154.FA0E41AD(string_, aA239C);
		string string_2 = "";
		if (string_0 == "")
		{
			DataTable dataTable = Class154.BD904B3B(string_);
			BC94A7A1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			C03CD408.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_0);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			C03CD408.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_2, F79F9AB5: true);
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

	private void fHDBuffFollowLikePage_Load(object sender, EventArgs e)
	{
		try
		{
			E78A479B.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			txtUid.Text = gclass4_0.BDB80B23("txtUid");
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
		string text = C03CD408.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudDelayFrom", E78A479B.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("txtUid", txtUid.Text.Trim());
		string text2 = gClass.ED11179C();
		if (F4A7F68E == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(F590F31C, text, BC94A7A1, text2))
				{
					B9925900 = true;
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
			if (Class154.smethod_13(F4A7F68E, text, text2))
			{
				B9925900 = true;
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

	private void E4AB9B10(object sender, PaintEventArgs e)
	{
		if (E9209CAC.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, E9209CAC.ClientSize.Width - num, E9209CAC.ClientSize.Height - num));
		}
	}

	private void CC2DC435(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtUid, label2);
	}

	protected override void Dispose(bool DB87E40C)
	{
		if (DB87E40C && E93D122F != null)
		{
			E93D122F.Dispose();
		}
		base.Dispose(DB87E40C);
	}

	private void InitializeComponent()
	{
		E93D122F = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBuffFollowLikePage));
		AA8A1D99 = new Bunifu.Framework.UI.BunifuDragControl(E93D122F);
		AE3E1180 = new Bunifu.Framework.UI.BunifuCustomLabel();
		BB8D7B33 = new Bunifu.Framework.UI.BunifuDragControl(E93D122F);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		A7A5EEB6 = new System.Windows.Forms.PictureBox();
		E9209CAC = new System.Windows.Forms.Panel();
		txtUid = new System.Windows.Forms.RichTextBox();
		label2 = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		E78A479B = new System.Windows.Forms.NumericUpDown();
		C03CD408 = new System.Windows.Forms.TextBox();
		E128A22E = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		FE928E97 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)A7A5EEB6).BeginInit();
		E9209CAC.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)E78A479B).BeginInit();
		FE928E97.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		AA8A1D99.Fixed = true;
		AA8A1D99.Horizontal = true;
		AA8A1D99.TargetControl = AE3E1180;
		AA8A1D99.Vertical = true;
		AE3E1180.BackColor = System.Drawing.Color.Transparent;
		AE3E1180.Cursor = System.Windows.Forms.Cursors.SizeAll;
		AE3E1180.Dock = System.Windows.Forms.DockStyle.Fill;
		AE3E1180.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AE3E1180.ForeColor = System.Drawing.Color.Black;
		AE3E1180.Location = new System.Drawing.Point(0, 0);
		AE3E1180.Name = "bunifuCustomLabel1";
		AE3E1180.Size = new System.Drawing.Size(315, 31);
		AE3E1180.TabIndex = 12;
		AE3E1180.Text = "Cấu hình Like page";
		AE3E1180.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BB8D7B33.Fixed = true;
		BB8D7B33.Horizontal = true;
		BB8D7B33.TargetControl = pnlHeader;
		BB8D7B33.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(A7A5EEB6);
		pnlHeader.Controls.Add(AE3E1180);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(315, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(284, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		System.Drawing.Image iconClose_fHDBu = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDBu != null) button1.Image = iconClose_fHDBu;
		A7A5EEB6.Cursor = System.Windows.Forms.Cursors.Default;
		A7A5EEB6.Image = Class155.DD225F0D;
		A7A5EEB6.Location = new System.Drawing.Point(3, 2);
		A7A5EEB6.Name = "pictureBox1";
		A7A5EEB6.Size = new System.Drawing.Size(34, 27);
		A7A5EEB6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		A7A5EEB6.TabIndex = 76;
		A7A5EEB6.TabStop = false;
		System.Drawing.Image iconApp_fHDBu = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDBu != null) A7A5EEB6.Image = iconApp_fHDBu;
		E9209CAC.BackColor = System.Drawing.Color.White;
		E9209CAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E9209CAC.Controls.Add(pnlTopAccent);
		E9209CAC.Controls.Add(txtUid);
		E9209CAC.Controls.Add(label2);
		E9209CAC.Controls.Add(nudDelayTo);
		E9209CAC.Controls.Add(E78A479B);
		E9209CAC.Controls.Add(C03CD408);
		E9209CAC.Controls.Add(E128A22E);
		E9209CAC.Controls.Add(label5);
		E9209CAC.Controls.Add(label1);
		E9209CAC.Controls.Add(btnCancel);
		E9209CAC.Controls.Add(btnAdd);
		E9209CAC.Controls.Add(FE928E97);
		E9209CAC.Cursor = System.Windows.Forms.Cursors.Arrow;
		E9209CAC.Dock = System.Windows.Forms.DockStyle.Fill;
		E9209CAC.Location = new System.Drawing.Point(0, 0);
		E9209CAC.Name = "panel1";
		E9209CAC.Size = new System.Drawing.Size(318, 327);
		E9209CAC.TabIndex = 0;
		E9209CAC.Paint += new System.Windows.Forms.PaintEventHandler(E4AB9B10);
		txtUid.Location = new System.Drawing.Point(31, 124);
		txtUid.Name = "txtUid";
		txtUid.Size = new System.Drawing.Size(253, 146);
		txtUid.TabIndex = 50;
		txtUid.Text = "";
		txtUid.TextChanged += new System.EventHandler(CC2DC435);
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 104);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(140, 16);
		label2.TabIndex = 40;
		label2.Text = "Nhập danh sách ID (0):";
		nudDelayTo.Location = new System.Drawing.Point(228, 78);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		E78A479B.Location = new System.Drawing.Point(131, 78);
		E78A479B.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E78A479B.Name = "nudDelayFrom";
		E78A479B.Size = new System.Drawing.Size(56, 23);
		E78A479B.TabIndex = 3;
		C03CD408.Location = new System.Drawing.Point(131, 49);
		C03CD408.Name = "txtTenHanhDong";
		C03CD408.Size = new System.Drawing.Size(153, 23);
		C03CD408.TabIndex = 0;
		E128A22E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E128A22E.Location = new System.Drawing.Point(193, 80);
		E128A22E.Name = "label7";
		E128A22E.Size = new System.Drawing.Size(29, 16);
		E128A22E.TabIndex = 38;
		E128A22E.Text = ">";
		E128A22E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 80);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 34;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
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
		btnCancel.Location = new System.Drawing.Point(167, 285);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
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
		btnAdd.Location = new System.Drawing.Point(60, 285);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		FE928E97.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		FE928E97.BackColor = System.Drawing.Color.White;
		FE928E97.BorderRadius = 0;
		FE928E97.BottomSahddow = true;
		FE928E97.color = System.Drawing.Color.FromArgb(37, 99, 235);
		FE928E97.Controls.Add(pnlHeader);
		FE928E97.LeftSahddow = false;
		FE928E97.Location = new System.Drawing.Point(1, 0);
		FE928E97.Name = "bunifuCards1";
		FE928E97.RightSahddow = true;
		FE928E97.ShadowDepth = 20;
		FE928E97.Size = new System.Drawing.Size(315, 37);
		FE928E97.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(318, 327);
		base.Controls.Add(E9209CAC);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBuffFollowLikePage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBuffFollowLikePage_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)A7A5EEB6).EndInit();
		E9209CAC.ResumeLayout(false);
		E9209CAC.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)E78A479B).EndInit();
		FE928E97.ResumeLayout(false);
		ResumeLayout(false);
	}
}
