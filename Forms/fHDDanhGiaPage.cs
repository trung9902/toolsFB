using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDanhGiaPage : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl A8956594;

	internal Panel panel1;

	internal TextBox txtTenHanhDong;

	internal Label BE9DAE97;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel E818842A;

	internal Label lblComment;

	internal RichTextBox txtComment;

	internal Button btnMinimize;

	internal Label lblUid;

	internal TextBox A12DE523;

	internal CheckBox ckbTuDongXoaNoiDung;

	internal ComboBox DEA09035;

	internal Button F003B933;

	internal Label label8;

	internal CheckBox AD8F5DB9;

	internal Panel plNoiDung;

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

	public fHDDanhGiaPage(string A0A72D92, string F4B545BA = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = A0A72D92;
		string_2 = F4B545BA;
		string text = base.Name.Substring(1);
		string aA239C = "Đánh giá Page";
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (F4B545BA == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			text2 = dataTable.Rows[0]["CauHinh"].ToString();
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(F4B545BA);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = "Câ\u0323p nhâ\u0323t";
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
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

	private void fHDDanhGiaPage_Load(object sender, EventArgs e)
	{
		method_0();
		try
		{
			A12DE523.Text = gclass4_0.BDB80B23("txtUid");
			AD8F5DB9.Checked = gclass4_0.method_3("ckbTaoNoiDungAI");
			txtComment.Text = gclass4_0.BDB80B23("txtComment");
			DEA09035.SelectedIndex = gclass4_0.method_2("typeNganCach");
			ckbTuDongXoaNoiDung.Checked = gclass4_0.method_3("ckbTuDongXoaNoiDung");
		}
		catch
		{
		}
		B48FDEA8();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(DEA09035, list_);
	}

	private void CA242AB7(object sender, EventArgs e)
	{
		Close();
	}

	private void F98126B5(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		gclass4_0.method_4("txtUid", A12DE523.Text.Trim());
		gclass4_0.method_4("ckbTaoNoiDungAI", AD8F5DB9.Checked);
		gclass4_0.method_4("txtComment", txtComment.Text.Trim());
		gclass4_0.method_4("typeNganCach", DEA09035.SelectedIndex);
		gclass4_0.method_4("ckbTuDongXoaNoiDung", ckbTuDongXoaNoiDung.Checked);
		string e013A = gclass4_0.ED11179C();
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

	private void C82C0016(object sender, EventArgs e)
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

	private void txtComment_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, lblComment, DEA09035.SelectedIndex);
	}

	private void B48FDEA8()
	{
		E51B2633(null, null);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void F003B933_Click(object sender, EventArgs e)
	{
		if (DEA09035.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtComment.Focus();
	}

	private void DEA09035_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, lblComment, DEA09035.SelectedIndex);
	}

	private void CE96BF1D(object sender, EventArgs e)
	{
		if (AD8F5DB9.Checked)
		{
			Commom.smethod_35(new fChonPrompt(gclass4_0));
		}
	}

	private void E51B2633(object sender, EventArgs e)
	{
		plNoiDung.Enabled = !AD8F5DB9.Checked;
	}

	protected override void Dispose(bool AEB58CB9)
	{
		if (AEB58CB9 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(AEB58CB9);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		E818842A = new Bunifu.Framework.UI.BunifuCustomLabel();
		A8956594 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		DEA09035 = new System.Windows.Forms.ComboBox();
		F003B933 = new System.Windows.Forms.Button();
		label8 = new System.Windows.Forms.Label();
		ckbTuDongXoaNoiDung = new System.Windows.Forms.CheckBox();
		txtComment = new System.Windows.Forms.RichTextBox();
		A12DE523 = new System.Windows.Forms.TextBox();
		lblComment = new System.Windows.Forms.Label();
		lblUid = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		BE9DAE97 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		AD8F5DB9 = new System.Windows.Forms.CheckBox();
		plNoiDung = new System.Windows.Forms.Panel();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		bunifuCards1.SuspendLayout();
		plNoiDung.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = E818842A;
		bunifuDragControl_0.Vertical = true;
		E818842A.BackColor = System.Drawing.Color.Transparent;
		E818842A.Cursor = System.Windows.Forms.Cursors.SizeAll;
		E818842A.Dock = System.Windows.Forms.DockStyle.Fill;
		E818842A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		E818842A.ForeColor = System.Drawing.Color.Black;
		E818842A.Location = new System.Drawing.Point(0, 0);
		E818842A.Name = "bunifuCustomLabel1";
		E818842A.Size = new System.Drawing.Size(343, 31);
		E818842A.TabIndex = 12;
		E818842A.Text = "Cấu hình Đánh giá Page";
		E818842A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A8956594.Fixed = true;
		A8956594.Horizontal = true;
		A8956594.TargetControl = pnlHeader;
		A8956594.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(E818842A);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(343, 31);
		pnlHeader.TabIndex = 9;
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnMinimize.ForeColor = System.Drawing.Color.White;
		btnMinimize.Image = Class155.Bitmap_15;
		btnMinimize.Location = new System.Drawing.Point(310, 0);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(32, 32);
		btnMinimize.TabIndex = 78;
		btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += new System.EventHandler(CA242AB7);
		System.Drawing.Image iconClose_fHDDa = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDDa != null) btnMinimize.Image = iconClose_fHDDa;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDDa = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDDa != null) pictureBox1.Image = iconApp_fHDDa;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(plNoiDung);
		panel1.Controls.Add(AD8F5DB9);
		panel1.Controls.Add(A12DE523);
		panel1.Controls.Add(lblComment);
		panel1.Controls.Add(lblUid);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(BE9DAE97);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(bunifuCards1);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(346, 364);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		DEA09035.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DEA09035.Cursor = System.Windows.Forms.Cursors.Hand;
		DEA09035.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		DEA09035.FormattingEnabled = true;
		DEA09035.Location = new System.Drawing.Point(64, 122);
		DEA09035.Name = "cbbTuyChonNoiDung";
		DEA09035.Size = new System.Drawing.Size(187, 24);
		DEA09035.TabIndex = 198;
		DEA09035.SelectedIndexChanged += new System.EventHandler(DEA09035_SelectedIndexChanged);
		F003B933.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		F003B933.Cursor = System.Windows.Forms.Cursors.Hand;
		F003B933.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F003B933.Location = new System.Drawing.Point(257, 121);
		F003B933.Name = "btnHuongDanNhapNoiDung";
		F003B933.Size = new System.Drawing.Size(26, 26);
		F003B933.TabIndex = 197;
		F003B933.Text = "?";
		F003B933.UseVisualStyleBackColor = true;
		F003B933.Click += new System.EventHandler(F003B933_Click);
		label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(-2, 125);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(64, 16);
		label8.TabIndex = 196;
		label8.Text = "Tùy chọn:";
		ckbTuDongXoaNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		ckbTuDongXoaNoiDung.AutoSize = true;
		ckbTuDongXoaNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongXoaNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbTuDongXoaNoiDung.Location = new System.Drawing.Point(2, 150);
		ckbTuDongXoaNoiDung.Name = "ckbTuDongXoaNoiDung";
		ckbTuDongXoaNoiDung.Size = new System.Drawing.Size(219, 20);
		ckbTuDongXoaNoiDung.TabIndex = 130;
		ckbTuDongXoaNoiDung.Text = "Tư\u0323 đô\u0323ng xo\u0301a nô\u0323i dung đa\u0303 sư\u0309 du\u0323ng";
		ckbTuDongXoaNoiDung.UseVisualStyleBackColor = true;
		txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtComment.Location = new System.Drawing.Point(2, 2);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(281, 114);
		txtComment.TabIndex = 106;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
		A12DE523.Location = new System.Drawing.Point(134, 78);
		A12DE523.Name = "txtUid";
		A12DE523.Size = new System.Drawing.Size(180, 23);
		A12DE523.TabIndex = 129;
		lblComment.AutoSize = true;
		lblComment.Location = new System.Drawing.Point(23, 111);
		lblComment.Name = "lblComment";
		lblComment.Size = new System.Drawing.Size(136, 16);
		lblComment.TabIndex = 0;
		lblComment.Text = "Nội dung đánh giá (0):";
		lblUid.AutoSize = true;
		lblUid.Location = new System.Drawing.Point(23, 81);
		lblUid.Name = "lblUid";
		lblUid.Size = new System.Drawing.Size(55, 16);
		lblUid.TabIndex = 126;
		lblUid.Text = "Id Page:";
		txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(180, 23);
		txtTenHanhDong.TabIndex = 0;
		BE9DAE97.AutoSize = true;
		BE9DAE97.Location = new System.Drawing.Point(23, 52);
		BE9DAE97.Name = "label1";
		BE9DAE97.Size = new System.Drawing.Size(98, 16);
		BE9DAE97.TabIndex = 31;
		BE9DAE97.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(177, 322);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 12;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(C82C0016);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(79, 322);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 11;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(F98126B5);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(pnlHeader);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(343, 37);
		bunifuCards1.TabIndex = 28;
		AD8F5DB9.AutoSize = true;
		AD8F5DB9.Cursor = System.Windows.Forms.Cursors.Hand;
		AD8F5DB9.Location = new System.Drawing.Point(171, 110);
		AD8F5DB9.Name = "ckbTaoNoiDungAI";
		AD8F5DB9.Size = new System.Drawing.Size(149, 20);
		AD8F5DB9.TabIndex = 199;
		AD8F5DB9.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		AD8F5DB9.UseVisualStyleBackColor = true;
		AD8F5DB9.CheckedChanged += new System.EventHandler(E51B2633);
		AD8F5DB9.Click += new System.EventHandler(CE96BF1D);
		plNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plNoiDung.Controls.Add(txtComment);
		plNoiDung.Controls.Add(ckbTuDongXoaNoiDung);
		plNoiDung.Controls.Add(DEA09035);
		plNoiDung.Controls.Add(label8);
		plNoiDung.Controls.Add(F003B933);
		plNoiDung.Location = new System.Drawing.Point(26, 130);
		plNoiDung.Name = "plNoiDung";
		plNoiDung.Size = new System.Drawing.Size(288, 175);
		plNoiDung.TabIndex = 200;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(346, 364);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDanhGiaPage";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDDanhGiaPage_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		plNoiDung.ResumeLayout(false);
		plNoiDung.PerformLayout();
		ResumeLayout(false);
	}
}
