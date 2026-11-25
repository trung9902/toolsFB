using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDXoaBaiTuong : Form
{
	internal GClass4 gclass4_0 = null;

	internal Panel pnlTopAccent;

	internal string string_0;

	internal string EFA39481;

	internal string F516CF30;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel panel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal TextBox txtTenHanhDong;

	internal Label F102D727;

	internal Label label1;

	internal Button btnCancel;

	internal Button FC0985B9;

	internal BunifuCards bunifuCards1;

	internal Panel B935B988;

	internal Button E50F7611;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown CFBF549E;

	internal NumericUpDown AC84BE1A;

	internal Label label8;

	internal CheckBox ckbOnlyDeleteTagPost;

	internal Label label2;

	internal Label BF9D302C;

	public static bool Boolean_0
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

	public fHDXoaBaiTuong(string string_1, string BBA9A481 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_1;
		F516CF30 = BBA9A481;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_2 = "";
		if (BBA9A481 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			EFA39481 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(BBA9A481);
			string_2 = dataTable2.Rows[0]["CauHinh"].ToString();
			FC0985B9.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
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

	private void A03E6E9A(object sender, EventArgs e)
	{
		try
		{
			AC84BE1A.Value = gclass4_0.method_2("nudSoLuongBaiFrom", 3);
			CFBF549E.Value = gclass4_0.method_2("nudSoLuongBaiTo", 3);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			ckbOnlyDeleteTagPost.Checked = gclass4_0.method_3("ckbOnlyDeleteTagPost");
		}
		catch
		{
		}
	}

	private void E50F7611_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AABACC3F(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongBaiFrom", AC84BE1A.Value);
		gClass.method_4("nudSoLuongBaiTo", CFBF549E.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("ckbOnlyDeleteTagPost", ckbOnlyDeleteTagPost.Checked);
		string text2 = gClass.ED11179C();
		if (F516CF30 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, EFA39481, text2))
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
			if (Class154.smethod_13(F516CF30, text, text2))
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

	private void F73D691F(object sender, EventArgs e)
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

	protected override void Dispose(bool C0981102)
	{
		if (C0981102 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(C0981102);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		B935B988 = new System.Windows.Forms.Panel();
		E50F7611 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		ckbOnlyDeleteTagPost = new System.Windows.Forms.CheckBox();
		CFBF549E = new System.Windows.Forms.NumericUpDown();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		AC84BE1A = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label8 = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		F102D727 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		FC0985B9 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		label2 = new System.Windows.Forms.Label();
		BF9D302C = new System.Windows.Forms.Label();
		B935B988.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CFBF549E).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)AC84BE1A).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
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
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(315, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Xóa bài viết trên tươ\u0300ng";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = B935B988;
		bunifuDragControl_1.Vertical = true;
		B935B988.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B935B988.BackColor = System.Drawing.Color.White;
		B935B988.Controls.Add(E50F7611);
		B935B988.Controls.Add(pictureBox1);
		B935B988.Controls.Add(bunifuCustomLabel1);
		B935B988.Cursor = System.Windows.Forms.Cursors.SizeAll;
		B935B988.Location = new System.Drawing.Point(0, 3);
		B935B988.Name = "pnlHeader";
		B935B988.Size = new System.Drawing.Size(315, 31);
		B935B988.TabIndex = 9;
		E50F7611.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		E50F7611.Cursor = System.Windows.Forms.Cursors.Hand;
		E50F7611.FlatAppearance.BorderSize = 0;
		E50F7611.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		E50F7611.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E50F7611.ForeColor = System.Drawing.Color.White;
		E50F7611.Image = Class155.Bitmap_15;
		E50F7611.Location = new System.Drawing.Point(284, 1);
		E50F7611.Name = "button1";
		E50F7611.Size = new System.Drawing.Size(30, 30);
		E50F7611.TabIndex = 77;
		E50F7611.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		E50F7611.UseVisualStyleBackColor = true;
		E50F7611.Click += new System.EventHandler(E50F7611_Click);
		System.Drawing.Image iconClose_fHDXo = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDXo != null) E50F7611.Image = iconClose_fHDXo;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDXo = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDXo != null) pictureBox1.Image = iconApp_fHDXo;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(BF9D302C);
		panel1.Controls.Add(ckbOnlyDeleteTagPost);
		panel1.Controls.Add(CFBF549E);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(AC84BE1A);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(label8);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(F102D727);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(FC0985B9);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(318, 204);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		ckbOnlyDeleteTagPost.AutoSize = true;
		ckbOnlyDeleteTagPost.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbOnlyDeleteTagPost.Location = new System.Drawing.Point(132, 135);
		ckbOnlyDeleteTagPost.Name = "ckbOnlyDeleteTagPost";
		ckbOnlyDeleteTagPost.Size = new System.Drawing.Size(160, 20);
		ckbOnlyDeleteTagPost.TabIndex = 39;
		ckbOnlyDeleteTagPost.Text = "Chỉ xóa bài viết gắn thẻ";
		ckbOnlyDeleteTagPost.UseVisualStyleBackColor = true;
		CFBF549E.Location = new System.Drawing.Point(229, 78);
		CFBF549E.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		CFBF549E.Name = "nudSoLuongBaiTo";
		CFBF549E.Size = new System.Drawing.Size(56, 23);
		CFBF549E.TabIndex = 4;
		nudDelayTo.Location = new System.Drawing.Point(229, 107);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		AC84BE1A.Location = new System.Drawing.Point(132, 78);
		AC84BE1A.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AC84BE1A.Name = "nudSoLuongBaiFrom";
		AC84BE1A.Size = new System.Drawing.Size(56, 23);
		AC84BE1A.TabIndex = 3;
		nudDelayFrom.Location = new System.Drawing.Point(132, 107);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(194, 80);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(29, 16);
		label8.TabIndex = 38;
		label8.Text = ">";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		F102D727.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F102D727.Location = new System.Drawing.Point(194, 109);
		F102D727.Name = "label7";
		F102D727.Size = new System.Drawing.Size(29, 16);
		F102D727.TabIndex = 38;
		F102D727.Text = ">";
		F102D727.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		btnCancel.Location = new System.Drawing.Point(167, 165);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F73D691F);
		FC0985B9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		FC0985B9.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		FC0985B9.Cursor = System.Windows.Forms.Cursors.Hand;
		FC0985B9.FlatAppearance.BorderSize = 0;
		FC0985B9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		FC0985B9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FC0985B9.ForeColor = System.Drawing.Color.White;
		FC0985B9.Location = new System.Drawing.Point(60, 165);
		FC0985B9.Name = "btnAdd";
		FC0985B9.Size = new System.Drawing.Size(92, 29);
		FC0985B9.TabIndex = 9;
		FC0985B9.Text = "Thêm";
		FC0985B9.UseVisualStyleBackColor = false;
		FC0985B9.Click += new System.EventHandler(AABACC3F);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(B935B988);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(315, 37);
		bunifuCards1.TabIndex = 28;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(27, 109);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(87, 16);
		label2.TabIndex = 40;
		label2.Text = "Gia\u0303n ca\u0301ch (s):";
		BF9D302C.AutoSize = true;
		BF9D302C.Location = new System.Drawing.Point(27, 80);
		BF9D302C.Name = "label9";
		BF9D302C.Size = new System.Drawing.Size(63, 16);
		BF9D302C.TabIndex = 41;
		BF9D302C.Text = "Sô\u0301 lươ\u0323ng:";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(318, 204);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDXoaBaiTuong";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(A03E6E9A);
		B935B988.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)CFBF549E).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)AC84BE1A).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
