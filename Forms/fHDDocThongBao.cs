using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDocThongBao : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string BE01B93B;

	internal string string_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool C8B1E295;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl A9007119;

	internal BunifuDragControl E409D699;

	internal Panel panel1;

	internal RadioButton C5AD4A92;

	internal RadioButton rbLanLuot;

	internal NumericUpDown FC17D997;

	internal NumericUpDown nudSoLuongTo;

	internal NumericUpDown C58BC72E;

	internal NumericUpDown nudSoLuongFrom;

	internal TextBox D32D05B9;

	internal Label DC07F092;

	internal Label label3;

	internal Label label5;

	internal Label A590B117;

	internal Label FC9C3A33;

	internal Label label1;

	internal Button B8979087;

	internal Button btnAdd;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal BunifuCards B6B02991;

	internal Panel pnlHeader;

	internal Button B7BA87BF;

	internal PictureBox F709F334;

	internal BunifuCustomLabel bunifuCustomLabel1;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return C8B1E295;
		}
		[CompilerGenerated]
		set
		{
			C8B1E295 = value;
		}
	}

	public fHDDocThongBao(string string_2, string string_3 = "")
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
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			BE01B93B = dataTable.Rows[0]["Id_TuongTac"].ToString();
			D32D05B9.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			D32D05B9.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDDocThongBao_Load(object sender, EventArgs e)
	{
		try
		{
			nudSoLuongFrom.Value = gclass4_0.method_2("nudSoLuongFrom", 2);
			nudSoLuongTo.Value = gclass4_0.method_2("nudSoLuongTo", 2);
			if (gclass4_0.method_2("typeDocThongBao") == 0)
			{
				rbLanLuot.Checked = true;
			}
			else
			{
				C5AD4A92.Checked = true;
			}
			C58BC72E.Value = gclass4_0.method_2("nudDelayFrom", 3);
			FC17D997.Value = gclass4_0.method_2("nudDelayTo", 5);
		}
		catch
		{
		}
	}

	private void AD043419(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = D32D05B9.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongFrom", nudSoLuongFrom.Value);
		gClass.method_4("nudSoLuongTo", nudSoLuongTo.Value);
		int num = 0;
		if (C5AD4A92.Checked)
		{
			num = 1;
		}
		gClass.method_4("typeDocThongBao", num);
		gClass.method_4("nudDelayFrom", C58BC72E.Value);
		gClass.method_4("nudDelayTo", FC17D997.Value);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, BE01B93B, e013A))
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

	private void CF9B4C22(object sender, EventArgs e)
	{
		Close();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
		if (panel1.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
		}
	}

	protected override void Dispose(bool B780F629)
	{
		if (B780F629 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(B780F629);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDocThongBao));
		A9007119 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		E409D699 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		B7BA87BF = new System.Windows.Forms.Button();
		F709F334 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		C5AD4A92 = new System.Windows.Forms.RadioButton();
		rbLanLuot = new System.Windows.Forms.RadioButton();
		FC17D997 = new System.Windows.Forms.NumericUpDown();
		nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
		C58BC72E = new System.Windows.Forms.NumericUpDown();
		nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
		D32D05B9 = new System.Windows.Forms.TextBox();
		DC07F092 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		A590B117 = new System.Windows.Forms.Label();
		FC9C3A33 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		B8979087 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		B6B02991 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F709F334).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)FC17D997).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)C58BC72E).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
		B6B02991.SuspendLayout();
		SuspendLayout();
		A9007119.Fixed = true;
		A9007119.Horizontal = true;
		A9007119.TargetControl = bunifuCustomLabel1;
		A9007119.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(316, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Đọc thông báo";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E409D699.Fixed = true;
		E409D699.Horizontal = true;
		E409D699.TargetControl = pnlHeader;
		E409D699.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(B7BA87BF);
		pnlHeader.Controls.Add(F709F334);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(316, 31);
		pnlHeader.TabIndex = 9;
		B7BA87BF.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		B7BA87BF.Cursor = System.Windows.Forms.Cursors.Hand;
		B7BA87BF.FlatAppearance.BorderSize = 0;
		B7BA87BF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B7BA87BF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B7BA87BF.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Resize += (s, e) =>
		{
			if (B7BA87BF != null) B7BA87BF.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			if (btnMinimize != null) btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		};
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		B7BA87BF.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		B7BA87BF.Text = iconClose == null ? "✕" : "";
		B7BA87BF.Location = new System.Drawing.Point(285, 1);
		B7BA87BF.Name = "button1";
		B7BA87BF.Size = new System.Drawing.Size(30, 30);
		B7BA87BF.TabIndex = 77;
		B7BA87BF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		B7BA87BF.UseVisualStyleBackColor = true;
		B7BA87BF.Click += new System.EventHandler(AD043419);
		F709F334.Cursor = System.Windows.Forms.Cursors.Default;
		F709F334.Image = Class155.DD225F0D;
		F709F334.Location = new System.Drawing.Point(3, 2);
		F709F334.Name = "pictureBox1";
		F709F334.Size = new System.Drawing.Size(34, 27);
		F709F334.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		F709F334.TabIndex = 76;
		F709F334.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(C5AD4A92);
		panel1.Controls.Add(rbLanLuot);
		panel1.Controls.Add(FC17D997);
		panel1.Controls.Add(nudSoLuongTo);
		panel1.Controls.Add(C58BC72E);
		panel1.Controls.Add(nudSoLuongFrom);
		panel1.Controls.Add(D32D05B9);
		panel1.Controls.Add(DC07F092);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(A590B117);
		panel1.Controls.Add(FC9C3A33);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(B8979087);
		panel1.Controls.Add(btnAdd);
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		panel1.Controls.Add(pnlTopAccent);
		panel1.Controls.Add(B6B02991);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(319, 189);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		C5AD4A92.AutoSize = true;
		C5AD4A92.Cursor = System.Windows.Forms.Cursors.Hand;
		C5AD4A92.Location = new System.Drawing.Point(216, 228);
		C5AD4A92.Name = "rbNgauNhien";
		C5AD4A92.Size = new System.Drawing.Size(89, 20);
		C5AD4A92.TabIndex = 4;
		C5AD4A92.TabStop = true;
		C5AD4A92.Text = "Ngâ\u0303u nhiên";
		C5AD4A92.UseVisualStyleBackColor = true;
		rbLanLuot.AutoSize = true;
		rbLanLuot.Cursor = System.Windows.Forms.Cursors.Hand;
		rbLanLuot.Location = new System.Drawing.Point(122, 228);
		rbLanLuot.Name = "rbLanLuot";
		rbLanLuot.Size = new System.Drawing.Size(71, 20);
		rbLanLuot.TabIndex = 3;
		rbLanLuot.TabStop = true;
		rbLanLuot.Text = "Lâ\u0300n lươ\u0323t";
		rbLanLuot.UseVisualStyleBackColor = true;
		FC17D997.Location = new System.Drawing.Point(228, 108);
		FC17D997.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		FC17D997.Name = "nudDelayTo";
		FC17D997.Size = new System.Drawing.Size(56, 23);
		FC17D997.TabIndex = 6;
		nudSoLuongTo.Location = new System.Drawing.Point(228, 79);
		nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTo.Name = "nudSoLuongTo";
		nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongTo.TabIndex = 2;
		C58BC72E.Location = new System.Drawing.Point(134, 108);
		C58BC72E.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C58BC72E.Name = "nudDelayFrom";
		C58BC72E.Size = new System.Drawing.Size(56, 23);
		C58BC72E.TabIndex = 5;
		nudSoLuongFrom.Location = new System.Drawing.Point(134, 79);
		nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongFrom.Name = "nudSoLuongFrom";
		nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongFrom.TabIndex = 1;
		D32D05B9.Location = new System.Drawing.Point(134, 50);
		D32D05B9.Name = "txtTenHanhDong";
		D32D05B9.Size = new System.Drawing.Size(150, 23);
		D32D05B9.TabIndex = 0;
		DC07F092.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DC07F092.Location = new System.Drawing.Point(194, 110);
		DC07F092.Name = "label7";
		DC07F092.Size = new System.Drawing.Size(29, 16);
		DC07F092.TabIndex = 38;
		DC07F092.Text = ">";
		DC07F092.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(194, 81);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(29, 110);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 34;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		A590B117.AutoSize = true;
		A590B117.Location = new System.Drawing.Point(17, 230);
		A590B117.Name = "label8";
		A590B117.Size = new System.Drawing.Size(92, 16);
		A590B117.TabIndex = 33;
		A590B117.Text = "Tu\u0300y cho\u0323n xem:";
		FC9C3A33.AutoSize = true;
		FC9C3A33.Location = new System.Drawing.Point(29, 81);
		FC9C3A33.Name = "label2";
		FC9C3A33.Size = new System.Drawing.Size(63, 16);
		FC9C3A33.TabIndex = 32;
		FC9C3A33.Text = "Sô\u0301 lươ\u0323ng:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(29, 53);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		B8979087.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B8979087.BackColor = System.Drawing.Color.Maroon;
		B8979087.Cursor = System.Windows.Forms.Cursors.Hand;
		B8979087.FlatAppearance.BorderSize = 0;
		B8979087.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B8979087.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B8979087.ForeColor = System.Drawing.Color.White;
		B8979087.Location = new System.Drawing.Point(168, 145);
		B8979087.Name = "btnCancel";
		B8979087.Size = new System.Drawing.Size(92, 29);
		B8979087.TabIndex = 8;
		B8979087.Text = "Đóng";
		B8979087.UseVisualStyleBackColor = false;
		B8979087.Click += new System.EventHandler(CF9B4C22);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(64, 145);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 7;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		B6B02991.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B6B02991.BackColor = System.Drawing.Color.White;
		B6B02991.BorderRadius = 0;
		B6B02991.BottomSahddow = true;
		B6B02991.color = System.Drawing.Color.FromArgb(37, 99, 235);
		B6B02991.Controls.Add(pnlHeader);
		B6B02991.LeftSahddow = false;
		B6B02991.Location = new System.Drawing.Point(1, 0);
		B6B02991.Name = "bunifuCards1";
		B6B02991.RightSahddow = true;
		B6B02991.ShadowDepth = 20;
		B6B02991.Size = new System.Drawing.Size(316, 37);
		B6B02991.TabIndex = 9;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(319, 189);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDocThongBao";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDDocThongBao_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)F709F334).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)FC17D997).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
		((System.ComponentModel.ISupportInitialize)C58BC72E).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
		B6B02991.ResumeLayout(false);
		ResumeLayout(false);
	}
}
