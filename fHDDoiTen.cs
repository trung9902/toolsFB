using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDoiTen : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string F987E52D;

	internal string E3A96B0F;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool F10C8C36;

	internal List<string> list_0 = new List<string>();

	internal List<string> list_1 = new List<string>();

	internal List<string> list_2 = new List<string>();

	internal List<string> list_3 = new List<string>();

	internal IContainer B7BE2AAC = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel panel1;

	internal TextBox FAB6E3B0;

	internal Label label1;

	internal Button B0B72DB0;

	internal Button D91AA78E;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button FC9B80B9;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel plTenTuDat1;

	internal Button button8;

	internal Button DC36E614;

	internal Button button6;

	internal RadioButton rdTenTuDat;

	internal RadioButton BA39BA2D;

	internal Panel B48C401B;

	internal RadioButton rdTenRandomNgoai;

	internal RadioButton C4897A86;

	internal Panel plTenTuDat;

	internal RadioButton rdTenTuDat2;

	internal RadioButton BC19D824;

	internal Panel F5238199;

	internal Button button2;

	internal CheckBox ckbTuDongXoaNoiDung;

	public static bool C23285A3
	{
		[CompilerGenerated]
		get
		{
			return F10C8C36;
		}
		[CompilerGenerated]
		set
		{
			F10C8C36 = value;
		}
	}

	public fHDDoiTen(string CE8BCD12, string C99D3831 = "")
	{
		InitializeComponent();
		C23285A3 = false;
		string_0 = CE8BCD12;
		E3A96B0F = C99D3831;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string string_ = "";
		if (C99D3831 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			F987E52D = dataTable.Rows[0]["Id_TuongTac"].ToString();
			FAB6E3B0.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(C99D3831);
			string_ = dataTable2.Rows[0]["CauHinh"].ToString();
			D91AA78E.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			FAB6E3B0.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(string_, F79F9AB5: true);
		Language.CD21F0A9(this);

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

	private void EE20A63E(object sender, EventArgs e)
	{
		try
		{
			if (gclass4_0.method_2("typeDatTen") == 0)
			{
				BA39BA2D.Checked = true;
			}
			else
			{
				rdTenTuDat.Checked = true;
			}
			if (gclass4_0.method_2("typeTenRandom") == 0)
			{
				C4897A86.Checked = true;
			}
			else
			{
				rdTenRandomNgoai.Checked = true;
			}
			if (gclass4_0.method_2("typeTenTuDat") == 0)
			{
				BC19D824.Checked = true;
			}
			else
			{
				rdTenTuDat2.Checked = true;
			}
			list_0 = gclass4_0.method_1("lstHo");
			list_1 = gclass4_0.method_1("lstTenDem");
			list_2 = gclass4_0.method_1("lstTen");
			list_3 = gclass4_0.method_1("lstHoTen");
			ckbTuDongXoaNoiDung.Checked = gclass4_0.method_3("ckbTuDongXoaNoiDung");
			BA39BA2D_CheckedChanged(null, null);
			C19C16BF(null, null);
			B621529C(null, null);
			rdTenTuDat2_CheckedChanged(null, null);
		}
		catch
		{
		}
	}

	private void A12EA7BA(object sender, EventArgs e)
	{
		Close();
	}

	private void EBB4BC3D(object sender, EventArgs e)
	{
		string text = FAB6E3B0.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		int num = 0;
		if (rdTenTuDat.Checked)
		{
			num = 1;
		}
		gClass.method_4("typeDatTen", num);
		int num2 = 0;
		if (rdTenRandomNgoai.Checked)
		{
			num2 = 1;
		}
		gClass.method_4("typeTenRandom", num2);
		int num3 = 0;
		if (rdTenTuDat2.Checked)
		{
			num3 = 1;
		}
		gClass.method_4("typeTenTuDat", num3);
		gClass.FD3CCF90("lstHo", list_0);
		gClass.FD3CCF90("lstTenDem", list_1);
		gClass.FD3CCF90("lstTen", list_2);
		gClass.FD3CCF90("lstHoTen", list_3);
		gClass.method_4("ckbTuDongXoaNoiDung", ckbTuDongXoaNoiDung.Checked);
		string text2 = gClass.ED11179C();
		if (E3A96B0F == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, F987E52D, text2))
				{
					C23285A3 = true;
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
			if (Class154.smethod_13(E3A96B0F, text, text2))
			{
				C23285A3 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void DCA711BB(object sender, EventArgs e)
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

	private void C19C16BF(object sender, EventArgs e)
	{
		plTenTuDat.Enabled = rdTenTuDat.Checked;
	}

	private void BA39BA2D_CheckedChanged(object sender, EventArgs e)
	{
		B48C401B.Enabled = BA39BA2D.Checked;
	}

	private void button6_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_0, "Nhâ\u0323p danh sa\u0301ch Họ", "Danh sa\u0301ch Họ", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_0 = fNhapDuLieu4.list_0;
	}

	private void DC36E614_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_1, "Nhâ\u0323p danh sa\u0301ch Tên đệm", "Danh sa\u0301ch Tên đệm", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_1 = fNhapDuLieu4.list_0;
	}

	private void button8_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_2, "Nhâ\u0323p danh sa\u0301ch Tên", "Danh sa\u0301ch Tên", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_2 = fNhapDuLieu4.list_0;
	}

	private void B621529C(object sender, EventArgs e)
	{
		plTenTuDat1.Enabled = BC19D824.Checked;
	}

	private void rdTenTuDat2_CheckedChanged(object sender, EventArgs e)
	{
		F5238199.Enabled = rdTenTuDat2.Checked;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_3, "Nhập danh sách họ tên", "Danh sách họ tên", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_3 = fNhapDuLieu4.list_0;
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && B7BE2AAC != null)
		{
			B7BE2AAC.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		B7BE2AAC = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDoiTen));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(B7BE2AAC);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(B7BE2AAC);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		FC9B80B9 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		rdTenTuDat = new System.Windows.Forms.RadioButton();
		BA39BA2D = new System.Windows.Forms.RadioButton();
		plTenTuDat = new System.Windows.Forms.Panel();
		F5238199 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		plTenTuDat1 = new System.Windows.Forms.Panel();
		button8 = new System.Windows.Forms.Button();
		DC36E614 = new System.Windows.Forms.Button();
		button6 = new System.Windows.Forms.Button();
		rdTenTuDat2 = new System.Windows.Forms.RadioButton();
		BC19D824 = new System.Windows.Forms.RadioButton();
		B48C401B = new System.Windows.Forms.Panel();
		rdTenRandomNgoai = new System.Windows.Forms.RadioButton();
		C4897A86 = new System.Windows.Forms.RadioButton();
		FAB6E3B0 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		B0B72DB0 = new System.Windows.Forms.Button();
		D91AA78E = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		ckbTuDongXoaNoiDung = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		plTenTuDat.SuspendLayout();
		F5238199.SuspendLayout();
		plTenTuDat1.SuspendLayout();
		B48C401B.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(341, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Đổi tên";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		// Top Accent Strip (#2563EB - LushCare Royal Blue)
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(FC9B80B9);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(341, 31);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (FC9B80B9 != null) FC9B80B9.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
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
		btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };

		FC9B80B9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		FC9B80B9.Cursor = System.Windows.Forms.Cursors.Hand;
		FC9B80B9.FlatAppearance.BorderSize = 0;
		FC9B80B9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		FC9B80B9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		FC9B80B9.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		FC9B80B9.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		FC9B80B9.Text = iconClose == null ? "✕" : "";
		FC9B80B9.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		FC9B80B9.Name = "button1";
		FC9B80B9.Size = new System.Drawing.Size(30, 30);
		FC9B80B9.TabIndex = 77;
		FC9B80B9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		FC9B80B9.UseVisualStyleBackColor = true;
		FC9B80B9.Click += new System.EventHandler(A12EA7BA);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(rdTenTuDat);
		panel1.Controls.Add(BA39BA2D);
		panel1.Controls.Add(plTenTuDat);
		panel1.Controls.Add(B48C401B);
		panel1.Controls.Add(FAB6E3B0);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(B0B72DB0);
		panel1.Controls.Add(D91AA78E);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(344, 317);
		panel1.TabIndex = 0;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		rdTenTuDat.AutoSize = true;
		rdTenTuDat.Checked = true;
		rdTenTuDat.Cursor = System.Windows.Forms.Cursors.Hand;
		rdTenTuDat.Location = new System.Drawing.Point(29, 131);
		rdTenTuDat.Name = "rdTenTuDat";
		rdTenTuDat.Size = new System.Drawing.Size(155, 20);
		rdTenTuDat.TabIndex = 138;
		rdTenTuDat.TabStop = true;
		rdTenTuDat.Text = "Tên do người dùng đặt";
		rdTenTuDat.UseVisualStyleBackColor = true;
		rdTenTuDat.CheckedChanged += new System.EventHandler(C19C16BF);
		BA39BA2D.AutoSize = true;
		BA39BA2D.Cursor = System.Windows.Forms.Cursors.Hand;
		BA39BA2D.Location = new System.Drawing.Point(29, 78);
		BA39BA2D.Name = "rdTenRandom";
		BA39BA2D.Size = new System.Drawing.Size(114, 20);
		BA39BA2D.TabIndex = 137;
		BA39BA2D.Text = "Tên ngẫu nhiên";
		BA39BA2D.UseVisualStyleBackColor = true;
		BA39BA2D.CheckedChanged += new System.EventHandler(BA39BA2D_CheckedChanged);
		plTenTuDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTenTuDat.Controls.Add(F5238199);
		plTenTuDat.Controls.Add(plTenTuDat1);
		plTenTuDat.Controls.Add(rdTenTuDat2);
		plTenTuDat.Controls.Add(BC19D824);
		plTenTuDat.Location = new System.Drawing.Point(44, 153);
		plTenTuDat.Name = "plTenTuDat";
		plTenTuDat.Size = new System.Drawing.Size(266, 101);
		plTenTuDat.TabIndex = 139;
		F5238199.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F5238199.Controls.Add(ckbTuDongXoaNoiDung);
		F5238199.Controls.Add(button2);
		F5238199.Location = new System.Drawing.Point(21, 38);
		F5238199.Name = "plTenTuDat2";
		F5238199.Size = new System.Drawing.Size(240, 56);
		F5238199.TabIndex = 136;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Location = new System.Drawing.Point(0, 0);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(238, 27);
		button2.TabIndex = 124;
		button2.Text = "Nhập danh sách họ tên";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		plTenTuDat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTenTuDat1.Controls.Add(button8);
		plTenTuDat1.Controls.Add(DC36E614);
		plTenTuDat1.Controls.Add(button6);
		plTenTuDat1.Location = new System.Drawing.Point(21, 3);
		plTenTuDat1.Name = "plTenTuDat1";
		plTenTuDat1.Size = new System.Drawing.Size(240, 29);
		plTenTuDat1.TabIndex = 136;
		button8.Cursor = System.Windows.Forms.Cursors.Hand;
		button8.Location = new System.Drawing.Point(171, 0);
		button8.Name = "button8";
		button8.Size = new System.Drawing.Size(67, 27);
		button8.TabIndex = 124;
		button8.Text = "Nhập tên";
		button8.UseVisualStyleBackColor = true;
		button8.Click += new System.EventHandler(button8_Click);
		DC36E614.Cursor = System.Windows.Forms.Cursors.Hand;
		DC36E614.Location = new System.Drawing.Point(69, 0);
		DC36E614.Name = "button7";
		DC36E614.Size = new System.Drawing.Size(96, 27);
		DC36E614.TabIndex = 124;
		DC36E614.Text = "Nhập tên đệm";
		DC36E614.UseVisualStyleBackColor = true;
		DC36E614.Click += new System.EventHandler(DC36E614_Click);
		button6.Cursor = System.Windows.Forms.Cursors.Hand;
		button6.Location = new System.Drawing.Point(0, 0);
		button6.Name = "button6";
		button6.Size = new System.Drawing.Size(63, 27);
		button6.TabIndex = 124;
		button6.Text = "Nhập họ";
		button6.UseVisualStyleBackColor = true;
		button6.Click += new System.EventHandler(button6_Click);
		rdTenTuDat2.AutoSize = true;
		rdTenTuDat2.Cursor = System.Windows.Forms.Cursors.Hand;
		rdTenTuDat2.Location = new System.Drawing.Point(3, 46);
		rdTenTuDat2.Name = "rdTenTuDat2";
		rdTenTuDat2.Size = new System.Drawing.Size(14, 13);
		rdTenTuDat2.TabIndex = 134;
		rdTenTuDat2.UseVisualStyleBackColor = true;
		rdTenTuDat2.CheckedChanged += new System.EventHandler(rdTenTuDat2_CheckedChanged);
		BC19D824.AutoSize = true;
		BC19D824.Checked = true;
		BC19D824.Cursor = System.Windows.Forms.Cursors.Hand;
		BC19D824.Location = new System.Drawing.Point(3, 11);
		BC19D824.Name = "rdTenTuDat1";
		BC19D824.Size = new System.Drawing.Size(14, 13);
		BC19D824.TabIndex = 134;
		BC19D824.TabStop = true;
		BC19D824.UseVisualStyleBackColor = true;
		BC19D824.CheckedChanged += new System.EventHandler(B621529C);
		B48C401B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		B48C401B.Controls.Add(rdTenRandomNgoai);
		B48C401B.Controls.Add(C4897A86);
		B48C401B.Location = new System.Drawing.Point(44, 100);
		B48C401B.Name = "plTenNgauNhien";
		B48C401B.Size = new System.Drawing.Size(266, 25);
		B48C401B.TabIndex = 139;
		rdTenRandomNgoai.AutoSize = true;
		rdTenRandomNgoai.Cursor = System.Windows.Forms.Cursors.Hand;
		rdTenRandomNgoai.Location = new System.Drawing.Point(80, 1);
		rdTenRandomNgoai.Name = "rdTenRandomNgoai";
		rdTenRandomNgoai.Size = new System.Drawing.Size(82, 20);
		rdTenRandomNgoai.TabIndex = 134;
		rdTenRandomNgoai.Text = "Tên ngoại";
		rdTenRandomNgoai.UseVisualStyleBackColor = true;
		C4897A86.AutoSize = true;
		C4897A86.Checked = true;
		C4897A86.Cursor = System.Windows.Forms.Cursors.Hand;
		C4897A86.Location = new System.Drawing.Point(2, 1);
		C4897A86.Name = "rdTenRandomViet";
		C4897A86.Size = new System.Drawing.Size(71, 20);
		C4897A86.TabIndex = 134;
		C4897A86.TabStop = true;
		C4897A86.Text = "Tên việt";
		C4897A86.UseVisualStyleBackColor = true;
		FAB6E3B0.Location = new System.Drawing.Point(125, 49);
		FAB6E3B0.Name = "txtTenHanhDong";
		FAB6E3B0.Size = new System.Drawing.Size(185, 23);
		FAB6E3B0.TabIndex = 0;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(26, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		B0B72DB0.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B0B72DB0.BackColor = System.Drawing.Color.Maroon;
		B0B72DB0.Cursor = System.Windows.Forms.Cursors.Hand;
		B0B72DB0.FlatAppearance.BorderSize = 0;
		B0B72DB0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B0B72DB0.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B0B72DB0.ForeColor = System.Drawing.Color.White;
		B0B72DB0.Location = new System.Drawing.Point(179, 272);
		B0B72DB0.Name = "btnCancel";
		B0B72DB0.Size = new System.Drawing.Size(92, 29);
		B0B72DB0.TabIndex = 7;
		B0B72DB0.Text = "Đóng";
		B0B72DB0.UseVisualStyleBackColor = false;
		B0B72DB0.Click += new System.EventHandler(DCA711BB);
		D91AA78E.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D91AA78E.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		D91AA78E.Cursor = System.Windows.Forms.Cursors.Hand;
		D91AA78E.FlatAppearance.BorderSize = 0;
		D91AA78E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D91AA78E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D91AA78E.ForeColor = System.Drawing.Color.White;
		D91AA78E.Location = new System.Drawing.Point(72, 272);
		D91AA78E.Name = "btnAdd";
		D91AA78E.Size = new System.Drawing.Size(92, 29);
		D91AA78E.TabIndex = 6;
		D91AA78E.Text = "Thêm";
		D91AA78E.UseVisualStyleBackColor = false;
		D91AA78E.Click += new System.EventHandler(EBB4BC3D);
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
		bunifuCards1.Size = new System.Drawing.Size(341, 37);
		bunifuCards1.TabIndex = 28;
		ckbTuDongXoaNoiDung.AutoSize = true;
		ckbTuDongXoaNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongXoaNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ckbTuDongXoaNoiDung.Location = new System.Drawing.Point(2, 30);
		ckbTuDongXoaNoiDung.Name = "ckbTuDongXoaNoiDung";
		ckbTuDongXoaNoiDung.Size = new System.Drawing.Size(138, 20);
		ckbTuDongXoaNoiDung.TabIndex = 133;
		ckbTuDongXoaNoiDung.Text = "Xo\u0301a tên đa\u0303 sư\u0309 du\u0323ng";
		ckbTuDongXoaNoiDung.UseVisualStyleBackColor = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(344, 317);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDoiTen";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(EE20A63E);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		plTenTuDat.ResumeLayout(false);
		plTenTuDat.PerformLayout();
		F5238199.ResumeLayout(false);
		F5238199.PerformLayout();
		plTenTuDat1.ResumeLayout(false);
		B48C401B.ResumeLayout(false);
		B48C401B.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
