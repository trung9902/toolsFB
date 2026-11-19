using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBatCheDoChuyenNghiep : Form
{
	internal GClass4 gclass4_0 = null;

	internal string D8B4952E;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer A3A34C95 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel B33E0817;

	internal TextBox txtTenHanhDong;

	internal Label label1;

	internal Button btnCancel;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards bunifuCards1;

	internal Panel C3118410;

	internal Button DBAC6B05;

	internal PictureBox D8AA8A26;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal ComboBox cbbTuyChon;

	internal Label FD12BC0C;

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

	public fHDBatCheDoChuyenNghiep(string string_2, string string_3 = "")
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
		D8B4952E = string_2;
		string_1 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
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
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDBatCheDoChuyenNghiep_Load(object sender, EventArgs e)
	{
		List<string> list_ = new List<string> { "Bật", "Tắt" };
		Commom.smethod_23(cbbTuyChon, list_);
		cbbTuyChon.SelectedIndex = gclass4_0.method_2("cbbTuyChon");
	}

	private void DBAC6B05_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void B82368A0(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		gclass4_0.method_4("cbbTuyChon", cbbTuyChon.SelectedIndex);
		string e013A = gclass4_0.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(D8B4952E, text, string_0, e013A))
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

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C931291F(object sender, PaintEventArgs e)
	{
		if (B33E0817.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, B33E0817.ClientSize.Width - num, B33E0817.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && A3A34C95 != null)
		{
			A3A34C95.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		A3A34C95 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBatCheDoChuyenNghiep));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(A3A34C95);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(A3A34C95);
		C3118410 = new System.Windows.Forms.Panel();
		DBAC6B05 = new System.Windows.Forms.Button();
		D8AA8A26 = new System.Windows.Forms.PictureBox();
		B33E0817 = new System.Windows.Forms.Panel();
		cbbTuyChon = new System.Windows.Forms.ComboBox();
		FD12BC0C = new System.Windows.Forms.Label();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		C3118410.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D8AA8A26).BeginInit();
		B33E0817.SuspendLayout();
		bunifuCards1.SuspendLayout();
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
		bunifuCustomLabel1.Text = "Cấu hình Bật chế độ chuyên nghiệp";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = C3118410;
		bunifuDragControl_1.Vertical = true;
		C3118410.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C3118410.BackColor = System.Drawing.Color.White;
		C3118410.Controls.Add(DBAC6B05);
		C3118410.Controls.Add(D8AA8A26);
		C3118410.Controls.Add(bunifuCustomLabel1);
		C3118410.Cursor = System.Windows.Forms.Cursors.SizeAll;
		C3118410.Location = new System.Drawing.Point(0, 3);
		C3118410.Name = "pnlHeader";
		C3118410.Size = new System.Drawing.Size(359, 31);
		C3118410.TabIndex = 9;
		DBAC6B05.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		DBAC6B05.Cursor = System.Windows.Forms.Cursors.Hand;
		DBAC6B05.FlatAppearance.BorderSize = 0;
		DBAC6B05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DBAC6B05.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		DBAC6B05.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(C3118410.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		C3118410.Controls.Add(btnMinimize);
		C3118410.Resize += (s, e) =>
		{
			if (DBAC6B05 != null) DBAC6B05.Location = new System.Drawing.Point(C3118410.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(C3118410.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		DBAC6B05.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		DBAC6B05.Text = iconClose == null ? "✕" : "";
		DBAC6B05.Location = new System.Drawing.Point(328, 1);
		DBAC6B05.Name = "button1";
		DBAC6B05.Size = new System.Drawing.Size(30, 30);
		DBAC6B05.TabIndex = 77;
		DBAC6B05.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		DBAC6B05.UseVisualStyleBackColor = true;
		DBAC6B05.Click += new System.EventHandler(DBAC6B05_Click);
		D8AA8A26.Cursor = System.Windows.Forms.Cursors.Default;
		D8AA8A26.Image = Class155.DD225F0D;
		D8AA8A26.Location = new System.Drawing.Point(3, 2);
		D8AA8A26.Name = "pictureBox1";
		D8AA8A26.Size = new System.Drawing.Size(34, 27);
		D8AA8A26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		D8AA8A26.TabIndex = 76;
		D8AA8A26.TabStop = false;
		B33E0817.BackColor = System.Drawing.Color.White;
		B33E0817.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B33E0817.Controls.Add(cbbTuyChon);
		B33E0817.Controls.Add(FD12BC0C);
		B33E0817.Controls.Add(txtTenHanhDong);
		B33E0817.Controls.Add(label1);
		B33E0817.Controls.Add(btnCancel);
		B33E0817.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		B33E0817.Controls.Add(pnlTopAccent);
		B33E0817.Controls.Add(bunifuCards1);
		B33E0817.Cursor = System.Windows.Forms.Cursors.Arrow;
		B33E0817.Dock = System.Windows.Forms.DockStyle.Fill;
		B33E0817.Location = new System.Drawing.Point(0, 0);
		B33E0817.Name = "panel1";
		B33E0817.Size = new System.Drawing.Size(362, 164);
		B33E0817.TabIndex = 0;
		B33E0817.Paint += new System.Windows.Forms.PaintEventHandler(C931291F);
		cbbTuyChon.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChon.FormattingEnabled = true;
		cbbTuyChon.Location = new System.Drawing.Point(132, 78);
		cbbTuyChon.Name = "cbbTuyChon";
		cbbTuyChon.Size = new System.Drawing.Size(194, 24);
		cbbTuyChon.TabIndex = 33;
		FD12BC0C.AutoSize = true;
		FD12BC0C.Location = new System.Drawing.Point(30, 81);
		FD12BC0C.Name = "label2";
		FD12BC0C.Size = new System.Drawing.Size(64, 16);
		FD12BC0C.TabIndex = 32;
		FD12BC0C.Text = "Tùy chọn:";
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
		btnCancel.Location = new System.Drawing.Point(189, 120);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 120);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(B82368A0);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(C3118410);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(359, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 164);
		base.Controls.Add(B33E0817);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBatCheDoChuyenNghiep";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBatCheDoChuyenNghiep_Load);
		C3118410.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D8AA8A26).EndInit();
		B33E0817.ResumeLayout(false);
		B33E0817.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
