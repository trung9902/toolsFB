using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBuffFollowCaNhan : Form
{
	internal Panel pnlTopAccent;

	internal GClass4 F203E29A;

	internal string B1810129;

	internal string string_0;

	internal string DD9C4A34;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool F215C79F;

	internal IContainer C7143392 = null;

	internal BunifuDragControl A42A3C1A;

	internal BunifuDragControl bunifuDragControl_0;

	internal Panel F19345AE;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown E9014C9F;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label label5;

	internal Label label1;

	internal Button btnCancel;

	internal Button B684C998;

	internal BunifuCards bunifuCards1;

	internal Panel D484E206;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Label lblUid;

	internal RichTextBox txtUid;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return F215C79F;
		}
		[CompilerGenerated]
		set
		{
			F215C79F = value;
		}
	}

	public fHDBuffFollowCaNhan(string string_1, string string_2 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		B1810129 = string_1;
		DD9C4A34 = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
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
			B684C998.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		F203E29A = new GClass4(string_3, F79F9AB5: true);
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

	private void B707238C(object sender, EventArgs e)
	{
		try
		{
			E9014C9F.Value = F203E29A.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = F203E29A.method_2("nudDelayTo", 5);
			txtUid.Text = F203E29A.BDB80B23("txtUid");
		}
		catch
		{
		}
	}

	private void A49F9CBE(object sender, EventArgs e)
	{
		Close();
	}

	private void E7329A3A(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudDelayFrom", E9014C9F.Value);
		gClass.method_4("nudDelayTo", nudDelayTo.Value);
		gClass.method_4("txtUid", txtUid.Text.Trim());
		string text2 = gClass.ED11179C();
		if (DD9C4A34 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(B1810129, text, string_0, text2))
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
			if (Class154.smethod_13(DD9C4A34, text, text2))
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

	private void A78F6E9B(object sender, EventArgs e)
	{
		Close();
	}

	private void F19345AE_Paint(object sender, PaintEventArgs e)
	{
		if (F19345AE.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, F19345AE.ClientSize.Width - num, F19345AE.ClientSize.Height - num));
		}
	}

	private void ADB2A9BA(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtUid, lblUid);
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && C7143392 != null)
		{
			C7143392.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		C7143392 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBuffFollowCaNhan));
		A42A3C1A = new Bunifu.Framework.UI.BunifuDragControl(C7143392);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(C7143392);
		D484E206 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		F19345AE = new System.Windows.Forms.Panel();
		txtUid = new System.Windows.Forms.RichTextBox();
		lblUid = new System.Windows.Forms.Label();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		E9014C9F = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		B684C998 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		D484E206.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		F19345AE.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)E9014C9F).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;

		A42A3C1A.Fixed = true;
		A42A3C1A.Horizontal = true;
		A42A3C1A.TargetControl = bunifuCustomLabel1;
		A42A3C1A.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(318, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Follow";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = D484E206;
		bunifuDragControl_0.Vertical = true;
		D484E206.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		D484E206.BackColor = System.Drawing.Color.White;
		D484E206.Controls.Add(button1);
		D484E206.Controls.Add(pictureBox1);
		D484E206.Controls.Add(bunifuCustomLabel1);
		D484E206.Cursor = System.Windows.Forms.Cursors.SizeAll;
		D484E206.Location = new System.Drawing.Point(0, 3);
		D484E206.Name = "pnlHeader";
		D484E206.Size = new System.Drawing.Size(318, 31);
		D484E206.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(287, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(A49F9CBE);
		System.Drawing.Image iconClose_fHDBu = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDBu != null) button1.Image = iconClose_fHDBu;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDBu = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDBu != null) pictureBox1.Image = iconApp_fHDBu;
		F19345AE.BackColor = System.Drawing.Color.White;
		F19345AE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F19345AE.Controls.Add(pnlTopAccent);
		F19345AE.Controls.Add(txtUid);
		F19345AE.Controls.Add(lblUid);
		F19345AE.Controls.Add(nudDelayTo);
		F19345AE.Controls.Add(E9014C9F);
		F19345AE.Controls.Add(txtTenHanhDong);
		F19345AE.Controls.Add(label7);
		F19345AE.Controls.Add(label5);
		F19345AE.Controls.Add(label1);
		F19345AE.Controls.Add(btnCancel);
		F19345AE.Controls.Add(B684C998);
		F19345AE.Controls.Add(bunifuCards1);
		F19345AE.Cursor = System.Windows.Forms.Cursors.Arrow;
		F19345AE.Dock = System.Windows.Forms.DockStyle.Fill;
		F19345AE.Location = new System.Drawing.Point(0, 0);
		F19345AE.Name = "panel1";
		F19345AE.Size = new System.Drawing.Size(321, 342);
		F19345AE.TabIndex = 0;
		F19345AE.Paint += new System.Windows.Forms.PaintEventHandler(F19345AE_Paint);
		txtUid.Location = new System.Drawing.Point(30, 125);
		txtUid.Name = "txtUid";
		txtUid.Size = new System.Drawing.Size(257, 159);
		txtUid.TabIndex = 41;
		txtUid.Text = "";
		txtUid.WordWrap = false;
		txtUid.TextChanged += new System.EventHandler(ADB2A9BA);
		lblUid.AutoSize = true;
		lblUid.Location = new System.Drawing.Point(27, 105);
		lblUid.Name = "lblUid";
		lblUid.Size = new System.Drawing.Size(140, 16);
		lblUid.TabIndex = 40;
		lblUid.Text = "Nhập danh sách ID (0):";
		nudDelayTo.Location = new System.Drawing.Point(231, 78);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		E9014C9F.Location = new System.Drawing.Point(134, 78);
		E9014C9F.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		E9014C9F.Name = "nudDelayFrom";
		E9014C9F.Size = new System.Drawing.Size(56, 23);
		E9014C9F.TabIndex = 3;
		txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(196, 80);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		btnCancel.Location = new System.Drawing.Point(167, 298);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 10;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(A78F6E9B);
		B684C998.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B684C998.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		B684C998.Cursor = System.Windows.Forms.Cursors.Hand;
		B684C998.FlatAppearance.BorderSize = 0;
		B684C998.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B684C998.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B684C998.ForeColor = System.Drawing.Color.White;
		B684C998.Location = new System.Drawing.Point(60, 298);
		B684C998.Name = "btnAdd";
		B684C998.Size = new System.Drawing.Size(92, 29);
		B684C998.TabIndex = 9;
		B684C998.Text = "Thêm";
		B684C998.UseVisualStyleBackColor = false;
		B684C998.Click += new System.EventHandler(E7329A3A);
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(37, 99, 235);
		bunifuCards1.Controls.Add(D484E206);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(1, 0);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(318, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(321, 342);
		base.Controls.Add(F19345AE);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBuffFollowCaNhan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(B707238C);
		D484E206.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		F19345AE.ResumeLayout(false);
		F19345AE.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)E9014C9F).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
