using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDShareBai : Form
{
	internal GClass4 A708AA04;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool D23676A9;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl E58F8590;

	internal Panel C9200327;

	internal TextBox txtTenHanhDong;

	internal Label E4B24119;

	internal Button btnCancel;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button D20F72A8;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown AA1F9008;

	internal Panel pnlTopAccent;

	internal Label label20;

	internal Label label15;

	internal Panel plDangBaiLenNhom;

	internal NumericUpDown nudCountGroupTo;

	internal NumericUpDown AD3A5298;

	internal Label label24;

	internal Label label26;

	internal CheckBox D09B491D;

	internal CheckBox ckbShareBaiLenTuong;

	internal CheckBox CCBA6BAF;

	internal CheckBox ckbTuongTacNhom;

	internal CheckBox B98EDB3F;

	internal CheckBox AD16899E;

	internal Panel panel3;

	internal RadioButton rbTuNhap;

	internal RadioButton B1176638;

	internal Label E30C1813;

	internal Panel E31EFA3C;

	internal RichTextBox txtNhomTuNhap;

	internal CheckBox ckbChiShareNhomDaThamGia;

	internal LinkLabel lblTuongTacNhom;

	internal GroupBox E6A9E631;

	internal Panel plDangBaiLenPage;

	internal Label label21;

	internal NumericUpDown nudCountPageTo;

	internal Label D617622F;

	internal NumericUpDown nudCountPageFrom;

	internal CheckBox AE831EB7;

	internal Button CF816932;

	internal GroupBox groupBox1;

	internal CheckBox FE264C10;

	internal Panel EB1B6027;

	internal CheckBox BF3DF22C;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button btnHuongDanNhapNoiDung;

	internal RichTextBox txtNoiDung;

	internal Label F00F1307;

	internal Label EEA71AA5;

	internal Label lblLinkChiaSe;

	internal CheckBox B905163A;

	internal CheckBox ckbVanBan;

	internal RichTextBox txtLinkChiaSe;

	internal LinkLabel AC022DAE;

	internal Label label3;

	internal ComboBox A2964395;

	public static bool AF14648D
	{
		[CompilerGenerated]
		get
		{
			return D23676A9;
		}
		[CompilerGenerated]
		set
		{
			D23676A9 = value;
		}
	}

	public fHDShareBai(string E4B372A3, string string_3 = "")
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
		AF14648D = false;
		string_0 = E4B372A3;
		string_2 = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
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
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		A708AA04 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void DAA26993(object sender, EventArgs e)
	{
		method_0();
		D21CFFBF();
		try
		{
			AA1F9008.Value = A708AA04.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = A708AA04.method_2("nudDelayTo", 5);
			txtLinkChiaSe.Text = A708AA04.BDB80B23("txtLinkChiaSe");
			A2964395.SelectedIndex = A708AA04.method_2("cbbKieuShare");
			ckbVanBan.Checked = A708AA04.method_3("ckbVanBan");
			FE264C10.Checked = A708AA04.method_3("ckbTaoNoiDungAI");
			txtNoiDung.Text = A708AA04.BDB80B23("txtNoiDung");
			cbbTuyChonNoiDung.SelectedIndex = A708AA04.method_2("typeNganCach");
			BF3DF22C.Checked = A708AA04.method_3("ckbTuDongXoaNoiDung");
			B905163A.Checked = A708AA04.method_3("ckbTuongTacBaiViet");
			ckbShareBaiLenTuong.Checked = A708AA04.method_3("ckbShareBaiLenTuong");
			D09B491D.Checked = A708AA04.method_3("ckbShareBaiLenNhom");
			AD3A5298.Value = A708AA04.method_2("nudCountGroupFrom", 1);
			nudCountGroupTo.Value = A708AA04.method_2("nudCountGroupTo", 1);
			if (A708AA04.method_2("typeShare") == 0)
			{
				B1176638.Checked = true;
			}
			else
			{
				rbTuNhap.Checked = true;
			}
			txtNhomTuNhap.Text = A708AA04.BDB80B23("lstNhomTuNhap");
			ckbChiShareNhomDaThamGia.Checked = A708AA04.method_3("ckbChiShareNhomDaThamGia");
			CCBA6BAF.Checked = A708AA04.method_3("ckbOnlyShareNhomKhongKiemDuyet");
			AD16899E.Checked = A708AA04.method_3("ckbUuTienNhomNhieuThanhVien");
			B98EDB3F.Checked = A708AA04.method_3("ckbKhongShareTrung");
			ckbTuongTacNhom.Checked = A708AA04.method_3("ckbTuongTacNhom");
			AE831EB7.Checked = A708AA04.method_3("ckbShareBaiLenPage");
			nudCountPageFrom.Value = A708AA04.method_2("nudCountPageFrom", 1);
			nudCountPageTo.Value = A708AA04.method_2("nudCountPageTo", 1);
		}
		catch (Exception)
		{
		}
		E7042D28();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "(www) Đăng link", "(m.fb) Đăng link", "(m.fb) Mở Link > click Chia sẻ" };
		Commom.smethod_23(A2964395, list_);
	}

	private void D21CFFBF()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list_);
	}

	private void C0AD798F(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		A708AA04.method_4("nudDelayFrom", AA1F9008.Value);
		A708AA04.method_4("nudDelayTo", nudDelayTo.Value);
		A708AA04.method_4("txtLinkChiaSe", txtLinkChiaSe.Text.Trim());
		A708AA04.method_4("cbbKieuShare", A2964395.SelectedIndex);
		A708AA04.method_4("ckbVanBan", ckbVanBan.Checked);
		A708AA04.method_4("ckbTaoNoiDungAI", FE264C10.Checked);
		A708AA04.method_4("txtNoiDung", txtNoiDung.Text.Trim());
		A708AA04.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		A708AA04.method_4("ckbTuDongXoaNoiDung", BF3DF22C.Checked);
		A708AA04.method_4("ckbTuongTacBaiViet", B905163A.Checked);
		A708AA04.method_4("ckbShareBaiLenTuong", ckbShareBaiLenTuong.Checked);
		A708AA04.method_4("ckbShareBaiLenNhom", D09B491D.Checked);
		A708AA04.method_4("nudCountGroupFrom", AD3A5298.Value);
		A708AA04.method_4("nudCountGroupTo", nudCountGroupTo.Value);
		int num = 0;
		if (rbTuNhap.Checked)
		{
			num = 1;
		}
		A708AA04.method_4("typeShare", num);
		A708AA04.method_4("lstNhomTuNhap", txtNhomTuNhap.Text);
		A708AA04.method_4("ckbChiShareNhomDaThamGia", ckbChiShareNhomDaThamGia.Checked);
		A708AA04.method_4("ckbOnlyShareNhomKhongKiemDuyet", CCBA6BAF.Checked);
		A708AA04.method_4("ckbUuTienNhomNhieuThanhVien", AD16899E.Checked);
		A708AA04.method_4("ckbKhongShareTrung", B98EDB3F.Checked);
		A708AA04.method_4("ckbTuongTacNhom", ckbTuongTacNhom.Checked);
		A708AA04.method_4("ckbShareBaiLenPage", AE831EB7.Checked);
		A708AA04.method_4("nudCountPageFrom", nudCountPageFrom.Value);
		A708AA04.method_4("nudCountPageTo", nudCountPageTo.Value);
		string e013A = A708AA04.ED11179C();
		if (string_2 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					AF14648D = true;
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
				AF14648D = true;
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

	private void C9200327_Paint(object sender, PaintEventArgs e)
	{
		if (C9200327.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, C9200327.ClientSize.Width - num, C9200327.ClientSize.Height - num));
		}
	}

	private void E7042D28()
	{
		AFB2EA2B(null, null);
		CAA73E97(null, null);
		F717739E(null, null);
		FE264C10_CheckedChanged(null, null);
		B83DF11F(null, null);
		B905163A_CheckedChanged(null, null);
		rbTuNhap_CheckedChanged(null, null);
	}

	private void F717739E(object sender, EventArgs e)
	{
		FE264C10.Enabled = ckbVanBan.Checked;
		EB1B6027.Enabled = ckbVanBan.Checked && !FE264C10.Checked;
	}

	private void AFB2EA2B(object sender, EventArgs e)
	{
		plDangBaiLenNhom.Enabled = D09B491D.Checked;
	}

	private void CAA73E97(object sender, EventArgs e)
	{
		plDangBaiLenPage.Enabled = AE831EB7.Checked;
	}

	private void B83DF11F(object sender, EventArgs e)
	{
		lblTuongTacNhom.Enabled = ckbTuongTacNhom.Checked;
	}

	private void rbTuNhap_CheckedChanged(object sender, EventArgs e)
	{
		E31EFA3C.Enabled = rbTuNhap.Checked;
		if (rbTuNhap.Checked)
		{
			if (!ckbChiShareNhomDaThamGia.Checked)
			{
				CCBA6BAF.Checked = false;
				CCBA6BAF.Enabled = false;
				AD16899E.Checked = false;
				AD16899E.Enabled = false;
			}
		}
		else
		{
			CCBA6BAF.Enabled = true;
			AD16899E.Enabled = true;
		}
	}

	private void CD2380BB(object sender, EventArgs e)
	{
		Commom.FE214EB5(sender as RichTextBox, rbTuNhap);
	}

	private void ckbChiShareNhomDaThamGia_CheckedChanged(object sender, EventArgs e)
	{
		if (!ckbChiShareNhomDaThamGia.Checked)
		{
			CCBA6BAF.Checked = false;
			CCBA6BAF.Enabled = false;
			AD16899E.Checked = false;
			AD16899E.Enabled = false;
		}
		else
		{
			CCBA6BAF.Enabled = true;
			AD16899E.Enabled = true;
		}
	}

	private void txtLinkChiaSe_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtLinkChiaSe, lblLinkChiaSe);
	}

	private void C58B250C(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtNoiDung, EEA71AA5, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void btnHuongDanNhapNoiDung_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtNoiDung.Focus();
	}

	private void method_1(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void B905163A_CheckedChanged(object sender, EventArgs e)
	{
		AC022DAE.Enabled = B905163A.Checked;
	}

	private void AC022DAE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fTuongTacBaiViet(A708AA04));
	}

	private void lblTuongTacNhom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fTuongTacProfile(A708AA04, "Cấu hình Tương tác Nhóm trước khi chia sẻ"));
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtNoiDung, EEA71AA5, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void BF1EE910(object sender, EventArgs e)
	{
	}

	private void FE264C10_CheckedChanged(object sender, EventArgs e)
	{
		EB1B6027.Enabled = ckbVanBan.Checked && !FE264C10.Checked;
	}

	private void CF816932_Click(object sender, EventArgs e)
	{
		E6A9E631.Height = 410;
		CF816932.Visible = false;
	}

	private void FE264C10_Click(object sender, EventArgs e)
	{
		if (FE264C10.Checked)
		{
			Commom.smethod_35(new fChonPrompt(A708AA04));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDShareBai));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		E58F8590 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		D20F72A8 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		C9200327 = new System.Windows.Forms.Panel();
		groupBox1 = new System.Windows.Forms.GroupBox();
		FE264C10 = new System.Windows.Forms.CheckBox();
		EB1B6027 = new System.Windows.Forms.Panel();
		BF3DF22C = new System.Windows.Forms.CheckBox();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		txtNoiDung = new System.Windows.Forms.RichTextBox();
		F00F1307 = new System.Windows.Forms.Label();
		EEA71AA5 = new System.Windows.Forms.Label();
		lblLinkChiaSe = new System.Windows.Forms.Label();
		B905163A = new System.Windows.Forms.CheckBox();
		ckbVanBan = new System.Windows.Forms.CheckBox();
		txtLinkChiaSe = new System.Windows.Forms.RichTextBox();
		AC022DAE = new System.Windows.Forms.LinkLabel();
		label3 = new System.Windows.Forms.Label();
		A2964395 = new System.Windows.Forms.ComboBox();
		E6A9E631 = new System.Windows.Forms.GroupBox();
		plDangBaiLenPage = new System.Windows.Forms.Panel();
		label21 = new System.Windows.Forms.Label();
		nudCountPageTo = new System.Windows.Forms.NumericUpDown();
		D617622F = new System.Windows.Forms.Label();
		nudCountPageFrom = new System.Windows.Forms.NumericUpDown();
		plDangBaiLenNhom = new System.Windows.Forms.Panel();
		CF816932 = new System.Windows.Forms.Button();
		B98EDB3F = new System.Windows.Forms.CheckBox();
		AD16899E = new System.Windows.Forms.CheckBox();
		lblTuongTacNhom = new System.Windows.Forms.LinkLabel();
		CCBA6BAF = new System.Windows.Forms.CheckBox();
		panel3 = new System.Windows.Forms.Panel();
		E31EFA3C = new System.Windows.Forms.Panel();
		txtNhomTuNhap = new System.Windows.Forms.RichTextBox();
		ckbChiShareNhomDaThamGia = new System.Windows.Forms.CheckBox();
		rbTuNhap = new System.Windows.Forms.RadioButton();
		B1176638 = new System.Windows.Forms.RadioButton();
		E30C1813 = new System.Windows.Forms.Label();
		nudCountGroupTo = new System.Windows.Forms.NumericUpDown();
		ckbTuongTacNhom = new System.Windows.Forms.CheckBox();
		AD3A5298 = new System.Windows.Forms.NumericUpDown();
		label24 = new System.Windows.Forms.Label();
		label26 = new System.Windows.Forms.Label();
		AE831EB7 = new System.Windows.Forms.CheckBox();
		D09B491D = new System.Windows.Forms.CheckBox();
		ckbShareBaiLenTuong = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		AA1F9008 = new System.Windows.Forms.NumericUpDown();
		label20 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		btnAdd = new System.Windows.Forms.Button();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		E4B24119 = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		C9200327.SuspendLayout();
		groupBox1.SuspendLayout();
		EB1B6027.SuspendLayout();
		E6A9E631.SuspendLayout();
		plDangBaiLenPage.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountPageTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountPageFrom).BeginInit();
		plDangBaiLenNhom.SuspendLayout();
		panel3.SuspendLayout();
		E31EFA3C.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountGroupTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)AD3A5298).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)AA1F9008).BeginInit();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(738, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Share bài";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E58F8590.Fixed = true;
		E58F8590.Horizontal = true;
		E58F8590.TargetControl = pnlHeader;
		E58F8590.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(D20F72A8);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(738, 31);
		pnlHeader.TabIndex = 9;
		D20F72A8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D20F72A8.Cursor = System.Windows.Forms.Cursors.Hand;
		D20F72A8.FlatAppearance.BorderSize = 0;
		D20F72A8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D20F72A8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D20F72A8.ForeColor = System.Drawing.Color.White;
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		D20F72A8.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		D20F72A8.Text = iconClose == null ? "✕" : "";
		D20F72A8.Location = new System.Drawing.Point(707, 1);
		D20F72A8.Name = "button1";
		D20F72A8.Size = new System.Drawing.Size(30, 30);
		D20F72A8.TabIndex = 0;
		D20F72A8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D20F72A8.UseVisualStyleBackColor = true;
		D20F72A8.Click += new System.EventHandler(C0AD798F);
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
		C9200327.BackColor = System.Drawing.Color.White;
		C9200327.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C9200327.Controls.Add(pnlTopAccent);
		C9200327.BringToFront();
		C9200327.Controls.Add(groupBox1);
		C9200327.Controls.Add(E6A9E631);
		C9200327.Controls.Add(nudDelayTo);
		C9200327.Controls.Add(AA1F9008);
		C9200327.Controls.Add(label20);
		C9200327.Controls.Add(label15);
		C9200327.Controls.Add(btnAdd);
		C9200327.Controls.Add(txtTenHanhDong);
		C9200327.Controls.Add(E4B24119);
		C9200327.Controls.Add(btnCancel);
		C9200327.Controls.Add(bunifuCards1);
		C9200327.Cursor = System.Windows.Forms.Cursors.Arrow;
		C9200327.Dock = System.Windows.Forms.DockStyle.Fill;
		C9200327.Location = new System.Drawing.Point(0, 0);
		C9200327.Name = "panel1";
		C9200327.Size = new System.Drawing.Size(741, 565);
		C9200327.TabIndex = 0;
		C9200327.Paint += new System.Windows.Forms.PaintEventHandler(C9200327_Paint);
		groupBox1.Controls.Add(FE264C10);
		groupBox1.Controls.Add(EB1B6027);
		groupBox1.Controls.Add(lblLinkChiaSe);
		groupBox1.Controls.Add(B905163A);
		groupBox1.Controls.Add(ckbVanBan);
		groupBox1.Controls.Add(txtLinkChiaSe);
		groupBox1.Controls.Add(AC022DAE);
		groupBox1.Controls.Add(label3);
		groupBox1.Controls.Add(A2964395);
		groupBox1.Location = new System.Drawing.Point(33, 105);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(354, 410);
		groupBox1.TabIndex = 184;
		groupBox1.TabStop = false;
		groupBox1.Text = "Nội dung";
		FE264C10.AutoSize = true;
		FE264C10.Cursor = System.Windows.Forms.Cursors.Hand;
		FE264C10.Location = new System.Drawing.Point(196, 151);
		FE264C10.Name = "ckbTaoNoiDungAI";
		FE264C10.Size = new System.Drawing.Size(149, 20);
		FE264C10.TabIndex = 187;
		FE264C10.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		FE264C10.UseVisualStyleBackColor = true;
		FE264C10.CheckedChanged += new System.EventHandler(FE264C10_CheckedChanged);
		FE264C10.Click += new System.EventHandler(FE264C10_Click);
		EB1B6027.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		EB1B6027.Controls.Add(BF3DF22C);
		EB1B6027.Controls.Add(cbbTuyChonNoiDung);
		EB1B6027.Controls.Add(btnHuongDanNhapNoiDung);
		EB1B6027.Controls.Add(txtNoiDung);
		EB1B6027.Controls.Add(F00F1307);
		EB1B6027.Controls.Add(EEA71AA5);
		EB1B6027.Location = new System.Drawing.Point(14, 173);
		EB1B6027.Name = "plVanBan";
		EB1B6027.Size = new System.Drawing.Size(331, 231);
		EB1B6027.TabIndex = 33;
		BF3DF22C.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		BF3DF22C.AutoSize = true;
		BF3DF22C.Cursor = System.Windows.Forms.Cursors.Hand;
		BF3DF22C.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		BF3DF22C.Location = new System.Drawing.Point(7, 207);
		BF3DF22C.Name = "ckbTuDongXoaNoiDung";
		BF3DF22C.Size = new System.Drawing.Size(169, 20);
		BF3DF22C.TabIndex = 197;
		BF3DF22C.Text = "Xóa nội dung đã sử dụng";
		BF3DF22C.UseVisualStyleBackColor = true;
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(100, 179);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(190, 24);
		cbbTuyChonNoiDung.TabIndex = 184;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		btnHuongDanNhapNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(296, 178);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 182;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(btnHuongDanNhapNoiDung_Click);
		txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtNoiDung.Location = new System.Drawing.Point(7, 24);
		txtNoiDung.Name = "txtNoiDung";
		txtNoiDung.Size = new System.Drawing.Size(316, 149);
		txtNoiDung.TabIndex = 180;
		txtNoiDung.Text = "";
		txtNoiDung.WordWrap = false;
		txtNoiDung.TextChanged += new System.EventHandler(C58B250C);
		F00F1307.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F00F1307.AutoSize = true;
		F00F1307.Location = new System.Drawing.Point(4, 182);
		F00F1307.Name = "label8";
		F00F1307.Size = new System.Drawing.Size(64, 16);
		F00F1307.TabIndex = 181;
		F00F1307.Text = "Tùy chọn:";
		EEA71AA5.AutoSize = true;
		EEA71AA5.Location = new System.Drawing.Point(3, 4);
		EEA71AA5.Name = "lblNoiDung";
		EEA71AA5.Size = new System.Drawing.Size(83, 16);
		EEA71AA5.TabIndex = 179;
		EEA71AA5.Text = "Nội dung (0):";
		lblLinkChiaSe.AutoSize = true;
		lblLinkChiaSe.Location = new System.Drawing.Point(11, 21);
		lblLinkChiaSe.Name = "lblLinkChiaSe";
		lblLinkChiaSe.Size = new System.Drawing.Size(136, 16);
		lblLinkChiaSe.TabIndex = 64;
		lblLinkChiaSe.Text = "Link bài cần share (0):";
		B905163A.AutoSize = true;
		B905163A.Cursor = System.Windows.Forms.Cursors.Hand;
		B905163A.Location = new System.Drawing.Point(34, 384);
		B905163A.Name = "ckbTuongTacBaiViet";
		B905163A.Size = new System.Drawing.Size(219, 20);
		B905163A.TabIndex = 107;
		B905163A.Text = "Tương ta\u0301c bài viết trươ\u0301c khi share";
		B905163A.UseVisualStyleBackColor = true;
		B905163A.CheckedChanged += new System.EventHandler(B905163A_CheckedChanged);
		ckbVanBan.AutoSize = true;
		ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbVanBan.Location = new System.Drawing.Point(14, 151);
		ckbVanBan.Name = "ckbVanBan";
		ckbVanBan.Size = new System.Drawing.Size(76, 20);
		ckbVanBan.TabIndex = 32;
		ckbVanBan.Text = "Nội dung";
		ckbVanBan.UseVisualStyleBackColor = true;
		ckbVanBan.CheckedChanged += new System.EventHandler(F717739E);
		txtLinkChiaSe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtLinkChiaSe.Location = new System.Drawing.Point(14, 39);
		txtLinkChiaSe.Name = "txtLinkChiaSe";
		txtLinkChiaSe.Size = new System.Drawing.Size(331, 108);
		txtLinkChiaSe.TabIndex = 34;
		txtLinkChiaSe.Text = "";
		txtLinkChiaSe.WordWrap = false;
		txtLinkChiaSe.TextChanged += new System.EventHandler(txtLinkChiaSe_TextChanged);
		AC022DAE.AutoSize = true;
		AC022DAE.Cursor = System.Windows.Forms.Cursors.Hand;
		AC022DAE.Location = new System.Drawing.Point(249, 385);
		AC022DAE.Name = "lblCaiDatTuongTacBaiViet";
		AC022DAE.Size = new System.Drawing.Size(47, 16);
		AC022DAE.TabIndex = 183;
		AC022DAE.TabStop = true;
		AC022DAE.Text = "Cài đặt";
		AC022DAE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(AC022DAE_LinkClicked);
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(11, 126);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(72, 16);
		label3.TabIndex = 66;
		label3.Text = "Kiểu share:";
		A2964395.Cursor = System.Windows.Forms.Cursors.Hand;
		A2964395.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A2964395.FormattingEnabled = true;
		A2964395.Location = new System.Drawing.Point(89, 123);
		A2964395.Name = "cbbKieuShare";
		A2964395.Size = new System.Drawing.Size(256, 24);
		A2964395.TabIndex = 106;
		A2964395.SelectedIndexChanged += new System.EventHandler(BF1EE910);
		E6A9E631.Controls.Add(plDangBaiLenPage);
		E6A9E631.Controls.Add(plDangBaiLenNhom);
		E6A9E631.Controls.Add(AE831EB7);
		E6A9E631.Controls.Add(D09B491D);
		E6A9E631.Controls.Add(ckbShareBaiLenTuong);
		E6A9E631.Location = new System.Drawing.Point(393, 105);
		E6A9E631.Name = "grTuyChon";
		E6A9E631.Size = new System.Drawing.Size(311, 306);
		E6A9E631.TabIndex = 62;
		E6A9E631.TabStop = false;
		E6A9E631.Text = "Tùy chọn";
		plDangBaiLenPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDangBaiLenPage.Controls.Add(label21);
		plDangBaiLenPage.Controls.Add(nudCountPageTo);
		plDangBaiLenPage.Controls.Add(D617622F);
		plDangBaiLenPage.Controls.Add(nudCountPageFrom);
		plDangBaiLenPage.Location = new System.Drawing.Point(33, 447);
		plDangBaiLenPage.Name = "plDangBaiLenPage";
		plDangBaiLenPage.Size = new System.Drawing.Size(270, 27);
		plDangBaiLenPage.TabIndex = 1;
		label21.AutoSize = true;
		label21.Location = new System.Drawing.Point(3, 3);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(95, 16);
		label21.TabIndex = 49;
		label21.Text = "Số lượng page:";
		nudCountPageTo.Location = new System.Drawing.Point(187, 1);
		nudCountPageTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountPageTo.Name = "nudCountPageTo";
		nudCountPageTo.Size = new System.Drawing.Size(56, 23);
		nudCountPageTo.TabIndex = 48;
		D617622F.AutoSize = true;
		D617622F.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D617622F.Location = new System.Drawing.Point(166, 3);
		D617622F.Name = "label23";
		D617622F.Size = new System.Drawing.Size(18, 16);
		D617622F.TabIndex = 51;
		D617622F.Text = ">";
		nudCountPageFrom.Location = new System.Drawing.Point(108, 1);
		nudCountPageFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountPageFrom.Name = "nudCountPageFrom";
		nudCountPageFrom.Size = new System.Drawing.Size(56, 23);
		nudCountPageFrom.TabIndex = 47;
		plDangBaiLenNhom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		plDangBaiLenNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDangBaiLenNhom.Controls.Add(CF816932);
		plDangBaiLenNhom.Controls.Add(B98EDB3F);
		plDangBaiLenNhom.Controls.Add(AD16899E);
		plDangBaiLenNhom.Controls.Add(lblTuongTacNhom);
		plDangBaiLenNhom.Controls.Add(CCBA6BAF);
		plDangBaiLenNhom.Controls.Add(panel3);
		plDangBaiLenNhom.Controls.Add(E30C1813);
		plDangBaiLenNhom.Controls.Add(nudCountGroupTo);
		plDangBaiLenNhom.Controls.Add(ckbTuongTacNhom);
		plDangBaiLenNhom.Controls.Add(AD3A5298);
		plDangBaiLenNhom.Controls.Add(label24);
		plDangBaiLenNhom.Controls.Add(label26);
		plDangBaiLenNhom.Location = new System.Drawing.Point(33, 70);
		plDangBaiLenNhom.Name = "plDangBaiLenNhom";
		plDangBaiLenNhom.Size = new System.Drawing.Size(270, 230);
		plDangBaiLenNhom.TabIndex = 1;
		CF816932.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		CF816932.BackgroundImage = Class155.Bitmap_94;
		CF816932.Cursor = System.Windows.Forms.Cursors.Hand;
		CF816932.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		CF816932.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CF816932.Location = new System.Drawing.Point(244, -1);
		CF816932.Name = "btnDown";
		CF816932.Size = new System.Drawing.Size(25, 25);
		CF816932.TabIndex = 192;
		CF816932.Click += new System.EventHandler(CF816932_Click);
		B98EDB3F.AutoSize = true;
		B98EDB3F.Cursor = System.Windows.Forms.Cursors.Hand;
		B98EDB3F.Location = new System.Drawing.Point(6, 281);
		B98EDB3F.Name = "ckbKhongShareTrung";
		B98EDB3F.Size = new System.Drawing.Size(167, 20);
		B98EDB3F.TabIndex = 2;
		B98EDB3F.Text = "Không share trùng nhóm";
		B98EDB3F.UseVisualStyleBackColor = true;
		AD16899E.AutoSize = true;
		AD16899E.Cursor = System.Windows.Forms.Cursors.Hand;
		AD16899E.Location = new System.Drawing.Point(6, 255);
		AD16899E.Name = "ckbUuTienNhomNhieuThanhVien";
		AD16899E.Size = new System.Drawing.Size(254, 20);
		AD16899E.TabIndex = 1;
		AD16899E.Text = "Ưu tiên share nhóm có nhiều thành viên";
		AD16899E.UseVisualStyleBackColor = true;
		lblTuongTacNhom.AutoSize = true;
		lblTuongTacNhom.Cursor = System.Windows.Forms.Cursors.Hand;
		lblTuongTacNhom.Location = new System.Drawing.Point(213, 308);
		lblTuongTacNhom.Name = "lblTuongTacNhom";
		lblTuongTacNhom.Size = new System.Drawing.Size(47, 16);
		lblTuongTacNhom.TabIndex = 183;
		lblTuongTacNhom.TabStop = true;
		lblTuongTacNhom.Text = "Cài đặt";
		lblTuongTacNhom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lblTuongTacNhom_LinkClicked);
		CCBA6BAF.AutoSize = true;
		CCBA6BAF.Cursor = System.Windows.Forms.Cursors.Hand;
		CCBA6BAF.Location = new System.Drawing.Point(6, 229);
		CCBA6BAF.Name = "ckbOnlyShareNhomKhongKiemDuyet";
		CCBA6BAF.Size = new System.Drawing.Size(220, 20);
		CCBA6BAF.TabIndex = 0;
		CCBA6BAF.Text = "Chỉ share nhóm không kiểm duyệt";
		CCBA6BAF.UseVisualStyleBackColor = true;
		panel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(E31EFA3C);
		panel3.Controls.Add(rbTuNhap);
		panel3.Controls.Add(B1176638);
		panel3.Location = new System.Drawing.Point(6, 52);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(257, 171);
		panel3.TabIndex = 67;
		E31EFA3C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E31EFA3C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E31EFA3C.Controls.Add(txtNhomTuNhap);
		E31EFA3C.Controls.Add(ckbChiShareNhomDaThamGia);
		E31EFA3C.Location = new System.Drawing.Point(22, 49);
		E31EFA3C.Name = "plTuNhap";
		E31EFA3C.Size = new System.Drawing.Size(230, 117);
		E31EFA3C.TabIndex = 193;
		txtNhomTuNhap.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtNhomTuNhap.Location = new System.Drawing.Point(3, 3);
		txtNhomTuNhap.Name = "txtNhomTuNhap";
		txtNhomTuNhap.Size = new System.Drawing.Size(222, 88);
		txtNhomTuNhap.TabIndex = 34;
		txtNhomTuNhap.Text = "";
		txtNhomTuNhap.WordWrap = false;
		txtNhomTuNhap.TextChanged += new System.EventHandler(CD2380BB);
		ckbChiShareNhomDaThamGia.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		ckbChiShareNhomDaThamGia.AutoSize = true;
		ckbChiShareNhomDaThamGia.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbChiShareNhomDaThamGia.Location = new System.Drawing.Point(3, 92);
		ckbChiShareNhomDaThamGia.Name = "ckbChiShareNhomDaThamGia";
		ckbChiShareNhomDaThamGia.Size = new System.Drawing.Size(190, 20);
		ckbChiShareNhomDaThamGia.TabIndex = 33;
		ckbChiShareNhomDaThamGia.Text = "Chỉ Share nhóm đã tham gia";
		ckbChiShareNhomDaThamGia.UseVisualStyleBackColor = true;
		ckbChiShareNhomDaThamGia.CheckedChanged += new System.EventHandler(ckbChiShareNhomDaThamGia_CheckedChanged);
		rbTuNhap.AutoSize = true;
		rbTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
		rbTuNhap.Location = new System.Drawing.Point(3, 27);
		rbTuNhap.Name = "rbTuNhap";
		rbTuNhap.Size = new System.Drawing.Size(197, 20);
		rbTuNhap.TabIndex = 1;
		rbTuNhap.Text = "Nhóm do người dùng nhập (0)";
		rbTuNhap.UseVisualStyleBackColor = true;
		rbTuNhap.CheckedChanged += new System.EventHandler(rbTuNhap_CheckedChanged);
		B1176638.AutoSize = true;
		B1176638.Checked = true;
		B1176638.Cursor = System.Windows.Forms.Cursors.Hand;
		B1176638.Location = new System.Drawing.Point(3, 3);
		B1176638.Name = "rbRandom";
		B1176638.Size = new System.Drawing.Size(197, 20);
		B1176638.TabIndex = 0;
		B1176638.TabStop = true;
		B1176638.Text = "Ngẫu nhiên nhóm đã tham gia";
		B1176638.UseVisualStyleBackColor = true;
		E30C1813.AutoSize = true;
		E30C1813.Location = new System.Drawing.Point(3, 31);
		E30C1813.Name = "label11";
		E30C1813.Size = new System.Drawing.Size(100, 16);
		E30C1813.TabIndex = 66;
		E30C1813.Text = "Tùy chọn nhóm:";
		nudCountGroupTo.Location = new System.Drawing.Point(187, 4);
		nudCountGroupTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountGroupTo.Name = "nudCountGroupTo";
		nudCountGroupTo.Size = new System.Drawing.Size(56, 23);
		nudCountGroupTo.TabIndex = 53;
		ckbTuongTacNhom.AutoSize = true;
		ckbTuongTacNhom.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuongTacNhom.Location = new System.Drawing.Point(6, 307);
		ckbTuongTacNhom.Name = "ckbTuongTacNhom";
		ckbTuongTacNhom.Size = new System.Drawing.Size(210, 20);
		ckbTuongTacNhom.TabIndex = 57;
		ckbTuongTacNhom.Text = "Tương tác nhóm trước khi share";
		ckbTuongTacNhom.UseVisualStyleBackColor = true;
		ckbTuongTacNhom.CheckedChanged += new System.EventHandler(B83DF11F);
		AD3A5298.Location = new System.Drawing.Point(108, 4);
		AD3A5298.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AD3A5298.Name = "nudCountGroupFrom";
		AD3A5298.Size = new System.Drawing.Size(56, 23);
		AD3A5298.TabIndex = 52;
		label24.AutoSize = true;
		label24.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label24.Location = new System.Drawing.Point(166, 6);
		label24.Name = "label24";
		label24.Size = new System.Drawing.Size(18, 16);
		label24.TabIndex = 56;
		label24.Text = ">";
		label26.AutoSize = true;
		label26.Location = new System.Drawing.Point(3, 6);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(99, 16);
		label26.TabIndex = 54;
		label26.Text = "Số lượng nhóm:";
		AE831EB7.AutoSize = true;
		AE831EB7.Cursor = System.Windows.Forms.Cursors.Hand;
		AE831EB7.Location = new System.Drawing.Point(10, 425);
		AE831EB7.Name = "ckbShareBaiLenPage";
		AE831EB7.Size = new System.Drawing.Size(134, 20);
		AE831EB7.TabIndex = 0;
		AE831EB7.Text = "Share bài lên page";
		AE831EB7.UseVisualStyleBackColor = true;
		AE831EB7.CheckedChanged += new System.EventHandler(CAA73E97);
		D09B491D.AutoSize = true;
		D09B491D.Cursor = System.Windows.Forms.Cursors.Hand;
		D09B491D.Location = new System.Drawing.Point(10, 46);
		D09B491D.Name = "ckbShareBaiLenNhom";
		D09B491D.Size = new System.Drawing.Size(138, 20);
		D09B491D.TabIndex = 0;
		D09B491D.Text = "Share bài lên nhóm";
		D09B491D.UseVisualStyleBackColor = true;
		D09B491D.CheckedChanged += new System.EventHandler(AFB2EA2B);
		ckbShareBaiLenTuong.AutoSize = true;
		ckbShareBaiLenTuong.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShareBaiLenTuong.Location = new System.Drawing.Point(10, 20);
		ckbShareBaiLenTuong.Name = "ckbShareBaiLenTuong";
		ckbShareBaiLenTuong.Size = new System.Drawing.Size(139, 20);
		ckbShareBaiLenTuong.TabIndex = 0;
		ckbShareBaiLenTuong.Text = "Share bài lên tường";
		ckbShareBaiLenTuong.UseVisualStyleBackColor = true;
		nudDelayTo.Location = new System.Drawing.Point(220, 76);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 58;
		AA1F9008.Location = new System.Drawing.Point(134, 76);
		AA1F9008.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		AA1F9008.Name = "nudDelayFrom";
		AA1F9008.Size = new System.Drawing.Size(56, 23);
		AA1F9008.TabIndex = 57;
		label20.AutoSize = true;
		label20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(196, 78);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(18, 16);
		label20.TabIndex = 61;
		label20.Text = ">";
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(30, 78);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(87, 16);
		label15.TabIndex = 59;
		label15.Text = "Gia\u0303n ca\u0301ch (s):";
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(295, 523);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		txtTenHanhDong.Location = new System.Drawing.Point(134, 47);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(142, 23);
		txtTenHanhDong.TabIndex = 0;
		E4B24119.AutoSize = true;
		E4B24119.Location = new System.Drawing.Point(30, 50);
		E4B24119.Name = "label1";
		E4B24119.Size = new System.Drawing.Size(98, 16);
		E4B24119.TabIndex = 31;
		E4B24119.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(393, 523);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(738, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(741, 565);
		base.Controls.Add(C9200327);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDShareBai";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(DAA26993);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		C9200327.ResumeLayout(false);
		C9200327.PerformLayout();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		EB1B6027.ResumeLayout(false);
		EB1B6027.PerformLayout();
		E6A9E631.ResumeLayout(false);
		E6A9E631.PerformLayout();
		plDangBaiLenPage.ResumeLayout(false);
		plDangBaiLenPage.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountPageTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountPageFrom).EndInit();
		plDangBaiLenNhom.ResumeLayout(false);
		plDangBaiLenNhom.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		E31EFA3C.ResumeLayout(false);
		E31EFA3C.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountGroupTo).EndInit();
		((System.ComponentModel.ISupportInitialize)AD3A5298).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)AA1F9008).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
