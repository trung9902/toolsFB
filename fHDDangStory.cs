using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDangStory : Form
{
	internal GClass4 F33F4E89;

	internal string string_0;

	internal string string_1;

	internal string FA23D501;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer D0389189 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl B40485BD;

	internal Panel A003291A;

	internal TextBox txtTenHanhDong;

	internal Label B3906096;

	internal Button C90CEB1F;

	internal Button F6335BAD;

	internal BunifuCards A830A7B9;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox F184853F;

	internal BunifuCustomLabel A81C8E39;

	internal TextBox txtPathAnh;

	internal Label label3;

	internal Panel pnlTopAccent;

	public static bool FFA26A02
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

	public fHDDangStory(string string_2, string string_3 = "")
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
		FFA26A02 = false;
		string_0 = string_2;
		FA23D501 = string_3;
		string aA239C = Language.GetValue(A81C8E39.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
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
			F6335BAD.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		F33F4E89 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void BA834A30(object sender, EventArgs e)
	{
		try
		{
			txtPathAnh.Text = F33F4E89.BDB80B23("txtPathAnh");
			Commom.AttachFolderPicker(txtPathAnh);
		}
		catch (Exception)
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F6335BAD_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("txtPathAnh", txtPathAnh.Text.Trim());
		string e013A = gClass.ED11179C();
		if (FA23D501 == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					FFA26A02 = true;
					Close();
				}
				else
				{
					MsBoxHelper.Show(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}
		else if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
		{
			if (Class154.smethod_13(FA23D501, text, e013A))
			{
				FFA26A02 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void C90CEB1F_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void A003291A_Paint(object sender, PaintEventArgs e)
	{
		if (A003291A.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, A003291A.ClientSize.Width - num, A003291A.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && D0389189 != null)
		{
			D0389189.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		D0389189 = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDangStory));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(D0389189);
		A81C8E39 = new Bunifu.Framework.UI.BunifuCustomLabel();
		B40485BD = new Bunifu.Framework.UI.BunifuDragControl(D0389189);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		F184853F = new System.Windows.Forms.PictureBox();
		A003291A = new System.Windows.Forms.Panel();
		txtPathAnh = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		F6335BAD = new System.Windows.Forms.Button();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		B3906096 = new System.Windows.Forms.Label();
		C90CEB1F = new System.Windows.Forms.Button();
		A830A7B9 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F184853F).BeginInit();
		A003291A.SuspendLayout();
		A830A7B9.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = A81C8E39;
		bunifuDragControl_0.Vertical = true;
		A81C8E39.BackColor = System.Drawing.Color.Transparent;
		A81C8E39.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A81C8E39.Dock = System.Windows.Forms.DockStyle.Fill;
		A81C8E39.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A81C8E39.ForeColor = System.Drawing.Color.Black;
		A81C8E39.Location = new System.Drawing.Point(0, 0);
		A81C8E39.Name = "bunifuCustomLabel1";
		A81C8E39.Size = new System.Drawing.Size(374, 31);
		A81C8E39.TabIndex = 12;
		A81C8E39.Text = "Cấu hình Đăng story";
		A81C8E39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		B40485BD.Fixed = true;
		B40485BD.Horizontal = true;
		B40485BD.TargetControl = pnlHeader;
		B40485BD.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(F184853F);
		pnlHeader.Controls.Add(A81C8E39);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(374, 31);
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
		button1.Location = new System.Drawing.Point(343, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 0;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		F184853F.Cursor = System.Windows.Forms.Cursors.Default;
		F184853F.Image = Class155.DD225F0D;
		F184853F.Location = new System.Drawing.Point(3, 2);
		F184853F.Name = "pictureBox1";
		F184853F.Size = new System.Drawing.Size(34, 27);
		F184853F.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		F184853F.TabIndex = 76;
		F184853F.TabStop = false;
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		A003291A.BackColor = System.Drawing.Color.White;
		A003291A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A003291A.Controls.Add(pnlTopAccent);
		A003291A.BringToFront();
		A003291A.Controls.Add(txtPathAnh);
		A003291A.Controls.Add(label3);
		A003291A.Controls.Add(F6335BAD);
		A003291A.Controls.Add(txtTenHanhDong);
		A003291A.Controls.Add(B3906096);
		A003291A.Controls.Add(C90CEB1F);
		A003291A.Controls.Add(A830A7B9);
		A003291A.Cursor = System.Windows.Forms.Cursors.Arrow;
		A003291A.Dock = System.Windows.Forms.DockStyle.Fill;
		A003291A.Location = new System.Drawing.Point(0, 0);
		A003291A.Name = "panel1";
		A003291A.Size = new System.Drawing.Size(377, 161);
		A003291A.TabIndex = 0;
		A003291A.Paint += new System.Windows.Forms.PaintEventHandler(A003291A_Paint);
		txtPathAnh.Location = new System.Drawing.Point(132, 78);
		txtPathAnh.Name = "txtPathAnh";
		txtPathAnh.Size = new System.Drawing.Size(205, 23);
		txtPathAnh.TabIndex = 1;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(30, 81);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(73, 16);
		label3.TabIndex = 0;
		label3.Text = "Folder ảnh:";
		F6335BAD.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F6335BAD.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		F6335BAD.Cursor = System.Windows.Forms.Cursors.Hand;
		F6335BAD.FlatAppearance.BorderSize = 0;
		F6335BAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F6335BAD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F6335BAD.ForeColor = System.Drawing.Color.White;
		F6335BAD.Location = new System.Drawing.Point(92, 118);
		F6335BAD.Name = "btnAdd";
		F6335BAD.Size = new System.Drawing.Size(92, 29);
		F6335BAD.TabIndex = 3;
		F6335BAD.Text = "Thêm";
		F6335BAD.UseVisualStyleBackColor = false;
		F6335BAD.Click += new System.EventHandler(F6335BAD_Click);
		txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(205, 23);
		txtTenHanhDong.TabIndex = 0;
		B3906096.AutoSize = true;
		B3906096.Location = new System.Drawing.Point(30, 52);
		B3906096.Name = "label1";
		B3906096.Size = new System.Drawing.Size(98, 16);
		B3906096.TabIndex = 31;
		B3906096.Text = "Tên ha\u0300nh đô\u0323ng:";
		C90CEB1F.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C90CEB1F.BackColor = System.Drawing.Color.Maroon;
		C90CEB1F.Cursor = System.Windows.Forms.Cursors.Hand;
		C90CEB1F.FlatAppearance.BorderSize = 0;
		C90CEB1F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C90CEB1F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C90CEB1F.ForeColor = System.Drawing.Color.White;
		C90CEB1F.Location = new System.Drawing.Point(191, 118);
		C90CEB1F.Name = "btnCancel";
		C90CEB1F.Size = new System.Drawing.Size(92, 29);
		C90CEB1F.TabIndex = 4;
		C90CEB1F.Text = "Đóng";
		C90CEB1F.UseVisualStyleBackColor = false;
		C90CEB1F.Click += new System.EventHandler(C90CEB1F_Click);
		A830A7B9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A830A7B9.BackColor = System.Drawing.Color.White;
		A830A7B9.BorderRadius = 0;
		A830A7B9.BottomSahddow = true;
		A830A7B9.color = System.Drawing.Color.DarkViolet;
		A830A7B9.Controls.Add(pnlHeader);
		A830A7B9.LeftSahddow = false;
		A830A7B9.Location = new System.Drawing.Point(1, 0);
		A830A7B9.Name = "bunifuCards1";
		A830A7B9.RightSahddow = true;
		A830A7B9.ShadowDepth = 20;
		A830A7B9.Size = new System.Drawing.Size(374, 37);
		A830A7B9.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(377, 161);
		base.Controls.Add(A003291A);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDangStory";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(BA834A30);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)F184853F).EndInit();
		A003291A.ResumeLayout(false);
		A003291A.PerformLayout();
		A830A7B9.ResumeLayout(false);
		ResumeLayout(false);
	}
}
