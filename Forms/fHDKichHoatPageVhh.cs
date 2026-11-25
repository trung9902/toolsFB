using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDKichHoatPageVhh : Form
{
	internal GClass4 EA2B9C36 = null;

	internal Panel pnlTopAccent;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal IContainer EC8A033C = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl E2BF2195;

	internal Panel DA88A72D;

	internal TextBox DABDF585;

	internal Label A23F8210;

	internal Button F9ACB5AC;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button AA952F1A;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	public static bool E280410B
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

	public fHDKichHoatPageVhh(string string_3, string CAA63492 = "")
	{
		InitializeComponent();
		E280410B = false;
		string_0 = string_3;
		string_2 = CAA63492;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (CAA63492 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			DABDF585.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(CAA63492);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			DABDF585.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		EA2B9C36 = new GClass4(text2, F79F9AB5: true);
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

	private void fHDKichHoatPageVhh_Load(object sender, EventArgs e)
	{
	}

	private void AA952F1A_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AD977018(object sender, EventArgs e)
	{
		string text = DABDF585.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		string e013A = EA2B9C36.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					E280410B = true;
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
				E280410B = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void D317228F(object sender, EventArgs e)
	{
		Close();
	}

	private void DA88A72D_Paint(object sender, PaintEventArgs e)
	{
		if (DA88A72D.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, DA88A72D.ClientSize.Width - num, DA88A72D.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool CEAF4D1A)
	{
		if (CEAF4D1A && EC8A033C != null)
		{
			EC8A033C.Dispose();
		}
		base.Dispose(CEAF4D1A);
	}

	private void InitializeComponent()
	{
		EC8A033C = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDKichHoatPageVhh));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(EC8A033C);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		E2BF2195 = new Bunifu.Framework.UI.BunifuDragControl(EC8A033C);
		pnlHeader = new System.Windows.Forms.Panel();
		AA952F1A = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		DA88A72D = new System.Windows.Forms.Panel();
		DABDF585 = new System.Windows.Forms.TextBox();
		A23F8210 = new System.Windows.Forms.Label();
		F9ACB5AC = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		DA88A72D.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Ki\u0301ch hoa\u0323t page vhh";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E2BF2195.Fixed = true;
		E2BF2195.Horizontal = true;
		E2BF2195.TargetControl = pnlHeader;
		E2BF2195.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(AA952F1A);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(359, 31);
		pnlHeader.TabIndex = 9;
		AA952F1A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		AA952F1A.Cursor = System.Windows.Forms.Cursors.Hand;
		AA952F1A.FlatAppearance.BorderSize = 0;
		AA952F1A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AA952F1A.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AA952F1A.ForeColor = System.Drawing.Color.White;
		AA952F1A.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		AA952F1A.Location = new System.Drawing.Point(328, 1);
		AA952F1A.Name = "button1";
		AA952F1A.Size = new System.Drawing.Size(30, 30);
		AA952F1A.TabIndex = 77;
		AA952F1A.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		AA952F1A.UseVisualStyleBackColor = true;
		AA952F1A.Click += new System.EventHandler(AA952F1A_Click);
		System.Drawing.Image iconClose_fHDKi = AppIconHelper.GetIcon("close_window.png", 24, 24);
		if (iconClose_fHDKi != null) AA952F1A.Image = iconClose_fHDKi;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		System.Drawing.Image iconApp_fHDKi = AppIconHelper.GetIcon("facebook.png", 22, 22) ?? AppIconHelper.GetIcon("settings.png", 22, 22);
		if (iconApp_fHDKi != null) pictureBox1.Image = iconApp_fHDKi;
		DA88A72D.BackColor = System.Drawing.Color.White;
		DA88A72D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		DA88A72D.Controls.Add(pnlTopAccent);
		DA88A72D.Controls.Add(DABDF585);
		DA88A72D.Controls.Add(A23F8210);
		DA88A72D.Controls.Add(F9ACB5AC);
		DA88A72D.Controls.Add(btnAdd);
		DA88A72D.Controls.Add(bunifuCards1);
		DA88A72D.Cursor = System.Windows.Forms.Cursors.Arrow;
		DA88A72D.Dock = System.Windows.Forms.DockStyle.Fill;
		DA88A72D.Location = new System.Drawing.Point(0, 0);
		DA88A72D.Name = "panel1";
		DA88A72D.Size = new System.Drawing.Size(362, 132);
		DA88A72D.TabIndex = 0;
		DA88A72D.Paint += new System.Windows.Forms.PaintEventHandler(DA88A72D_Paint);
		DABDF585.Location = new System.Drawing.Point(132, 49);
		DABDF585.Name = "txtTenHanhDong";
		DABDF585.Size = new System.Drawing.Size(194, 23);
		DABDF585.TabIndex = 0;
		A23F8210.AutoSize = true;
		A23F8210.Location = new System.Drawing.Point(27, 52);
		A23F8210.Name = "label1";
		A23F8210.Size = new System.Drawing.Size(98, 16);
		A23F8210.TabIndex = 31;
		A23F8210.Text = "Tên ha\u0300nh đô\u0323ng:";
		F9ACB5AC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		F9ACB5AC.BackColor = System.Drawing.Color.Maroon;
		F9ACB5AC.Cursor = System.Windows.Forms.Cursors.Hand;
		F9ACB5AC.FlatAppearance.BorderSize = 0;
		F9ACB5AC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F9ACB5AC.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F9ACB5AC.ForeColor = System.Drawing.Color.White;
		F9ACB5AC.Location = new System.Drawing.Point(189, 88);
		F9ACB5AC.Name = "btnCancel";
		F9ACB5AC.Size = new System.Drawing.Size(92, 29);
		F9ACB5AC.TabIndex = 10;
		F9ACB5AC.Text = "Đóng";
		F9ACB5AC.UseVisualStyleBackColor = false;
		F9ACB5AC.Click += new System.EventHandler(D317228F);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(82, 88);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 9;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(AD977018);
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
		bunifuCards1.Size = new System.Drawing.Size(359, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(362, 132);
		base.Controls.Add(DA88A72D);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDKichHoatPageVhh";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDKichHoatPageVhh_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		DA88A72D.ResumeLayout(false);
		DA88A72D.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
