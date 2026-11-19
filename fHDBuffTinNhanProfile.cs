using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDBuffTinNhanProfile : Form
{
	internal GClass4 D493212A;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool bool_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl AA34BF16;

	internal BunifuDragControl CA29410B;

	internal Panel C3AB4015;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label EB24AE05;

	internal Label EA88022C;

	internal Button btnCancel;

	internal Button F63A4085;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel plComment;

	internal Label lblNoiDung;

	internal CheckBox ckbNhanTinVanBan;

	internal Label B93F2315;

	internal NumericUpDown nudSoLuongUidFrom;

	internal NumericUpDown nudSoLuongUidTo;

	internal Label DA263506;

	internal RichTextBox txtUid;

	internal Panel plAnh;

	internal CheckBox ckbSendAnh;

	internal CheckBox ckbTuDongXoaUid;

	internal Label DD847891;

	internal Label EF0D761E;

	internal NumericUpDown F0AEF39D;

	internal NumericUpDown BC8ED191;

	internal Label C73B0B30;

	internal Panel plTuongTacTruocKhiNhanTin;

	internal CheckBox E0A0AD8A;

	internal Label label10;

	internal TextBox C1139C0F;

	internal RichTextBox DB2E6416;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button FB90470A;

	internal ComboBox C1BEED9C;

	internal Label E584C19C;

	internal Panel plUid;

	internal Label DA3EEA37;

	internal ComboBox cbbTuongTac;

	internal LinkLabel B13FD187;

	internal CheckBox AF9630A0;

	internal CheckBox C20632B1;

	internal Panel CD398206;

	internal TabControl EF05C436;

	internal TabPage tabCommentText;

	internal TabPage CE082C98;

	internal Button btnPrompt;

	internal ComboBox F339933B;

	internal Label EE95588D;

	internal CheckBox checkBox1;

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

	public fHDBuffTinNhanProfile(string string_3, string C494E81C = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_3;
		string_2 = C494E81C;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (C494E81C == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(C494E81C);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			F63A4085.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		D493212A = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
	}

	private void fHDBuffTinNhanProfile_Load(object sender, EventArgs e)
	{
		method_0();
		method_1();
		method_2();
		method_4();
		try
		{
			nudSoLuongUidFrom.Value = D493212A.method_2("nudSoLuongUidFrom", 1);
			nudSoLuongUidTo.Value = D493212A.method_2("nudSoLuongUidTo", 1);
			F0AEF39D.Value = D493212A.method_2("nudSoLuongAnhFrom", 1);
			BC8ED191.Value = D493212A.method_2("nudSoLuongAnhTo", 1);
			nudDelayFrom.Value = D493212A.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = D493212A.method_2("nudDelayTo", 5);
			txtUid.Text = D493212A.BDB80B23("txtUid");
			ckbNhanTinVanBan.Checked = D493212A.method_3("ckbNhanTinVanBan");
			DB2E6416.Text = D493212A.BDB80B23("txtNoiDung");
			AF9630A0.Checked = D493212A.method_3("ckbAutoDeleteComment");
			C20632B1.Checked = D493212A.method_3("ckbTaoNoiDungAI");
			try
			{
				F339933B.SelectedValue = D493212A.BDB80B23("cbbPrompt");
			}
			catch (Exception)
			{
			}
			ckbSendAnh.Checked = D493212A.method_3("ckbSendAnh");
			C1139C0F.Text = D493212A.BDB80B23("txtAnh");
			Commom.AttachFolderPicker(C1139C0F);
			E0A0AD8A.Checked = D493212A.method_3("ckbTuongTacKhiNhanTin");
			cbbTuongTac.SelectedIndex = D493212A.method_2("typeTuongTacKhiNhanTin");
			ckbTuDongXoaUid.Checked = D493212A.method_3("ckbTuDongXoaUid");
			cbbTuyChonNoiDung.SelectedIndex = D493212A.method_2("typeNganCach");
			C1BEED9C.SelectedValue = D493212A.BDB80B23("typeDoiTuong", "0");
		}
		catch
		{
		}
		method_3();
	}

	private void method_0()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "UID chỉ định");
		dictionary.Add("1", "Ngẫu nhiên danh sách bạn");
		dictionary.Add("5", "Ngẫu nhiên trong hộp thư");
		dictionary.Add("4", "Tin nhắn Chờ");
		dictionary.Add("3", "Tin nhắn Spam");
		Commom.smethod_24(C1BEED9C, dictionary);
	}

	private void method_1()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list_);
	}

	private void method_2()
	{
		List<string> list_ = new List<string> { "Tương ta\u0301c trươ\u0301c khi nhă\u0301n tin", "Tương ta\u0301c sau khi nhă\u0301n tin" };
		Commom.smethod_23(cbbTuongTac, list_);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void F63A4085_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		D493212A.method_4("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
		D493212A.method_4("nudSoLuongUidTo", nudSoLuongUidTo.Value);
		D493212A.method_4("nudSoLuongAnhFrom", F0AEF39D.Value);
		D493212A.method_4("nudSoLuongAnhTo", BC8ED191.Value);
		D493212A.method_4("nudDelayFrom", nudDelayFrom.Value);
		D493212A.method_4("nudDelayTo", nudDelayTo.Value);
		D493212A.method_4("txtUid", txtUid.Text.Trim());
		D493212A.method_4("ckbNhanTinVanBan", ckbNhanTinVanBan.Checked);
		D493212A.method_4("txtNoiDung", DB2E6416.Text.Trim());
		D493212A.method_4("ckbAutoDeleteComment", AF9630A0.Checked);
		D493212A.method_4("ckbTaoNoiDungAI", C20632B1.Checked);
		D493212A.method_4("cbbPrompt", F339933B.SelectedValue ?? "");
		D493212A.method_4("ckbSendAnh", ckbSendAnh.Checked);
		D493212A.method_4("txtAnh", C1139C0F.Text.Trim());
		D493212A.method_4("ckbTuDongXoaUid", ckbTuDongXoaUid.Checked);
		D493212A.method_4("ckbTuongTacKhiNhanTin", E0A0AD8A.Checked);
		D493212A.method_4("typeTuongTacKhiNhanTin", cbbTuongTac.SelectedIndex);
		D493212A.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		D493212A.method_4("typeDoiTuong", C1BEED9C.SelectedValue);
		string e013A = D493212A.ED11179C();
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

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C3AB4015_Paint(object sender, PaintEventArgs e)
	{
		if (C3AB4015.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, C3AB4015.ClientSize.Width - num, C3AB4015.ClientSize.Height - num));
		}
	}

	private void method_3()
	{
		A3310688(null, null);
		B7A949AA(null, null);
		E0A0AD8A_CheckedChanged(null, null);
		A182E431(null, null);
		F425249B(null, null);
	}

	private void A3310688(object sender, EventArgs e)
	{
	}

	private void B7A949AA(object sender, EventArgs e)
	{
		plComment.Enabled = ckbNhanTinVanBan.Checked;
	}

	private void txtUid_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtUid, DA3EEA37);
	}

	private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbSendAnh.Checked;
	}

	private void ED3D6D19(object sender, EventArgs e)
	{
	}

	private void E0A0AD8A_CheckedChanged(object sender, EventArgs e)
	{
		plTuongTacTruocKhiNhanTin.Enabled = E0A0AD8A.Checked;
	}

	private void FB90470A_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		DB2E6416.Focus();
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(DB2E6416, lblNoiDung, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void DB2E6416_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(DB2E6416, lblNoiDung, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void A182E431(object sender, EventArgs e)
	{
		plUid.Enabled = C1BEED9C.SelectedValue.ToString() == "0";
		if (new List<string> { "0", "1", "2" }.Contains(C1BEED9C.SelectedValue.ToString()))
		{
			E0A0AD8A.Enabled = true;
			return;
		}
		E0A0AD8A.Enabled = false;
		E0A0AD8A.Checked = false;
	}

	private void B13FD187_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fTuongTacProfile(D493212A));
	}

	private void D709AD17(object sender, EventArgs e)
	{
	}

	private void F425249B(object sender, EventArgs e)
	{
		EF05C436.SelectedTab = (C20632B1.Checked ? CE082C98 : tabCommentText);
	}

	private void DA291523(object sender, EventArgs e)
	{
		int selectedIndex = F339933B.SelectedIndex;
		Commom.smethod_35(new fCauHinhAI(F339933B.SelectedValue?.ToString()));
		method_4();
		if (selectedIndex != -1 && selectedIndex < F339933B.Items.Count)
		{
			F339933B.SelectedIndex = selectedIndex;
		}
	}

	private void method_4()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		List<GClass10> list = GClass9.EC28DF14();
		foreach (GClass10 item in list)
		{
			dictionary.Add(item.String_0.ToString(), item.String_1.ToString());
		}
		Commom.smethod_24(F339933B, dictionary);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBuffTinNhanProfile));
		AA34BF16 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		CA29410B = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		C3AB4015 = new System.Windows.Forms.Panel();
		plUid = new System.Windows.Forms.Panel();
		DA3EEA37 = new System.Windows.Forms.Label();
		txtUid = new System.Windows.Forms.RichTextBox();
		ckbTuDongXoaUid = new System.Windows.Forms.CheckBox();
		C1BEED9C = new System.Windows.Forms.ComboBox();
		E584C19C = new System.Windows.Forms.Label();
		plTuongTacTruocKhiNhanTin = new System.Windows.Forms.Panel();
		B13FD187 = new System.Windows.Forms.LinkLabel();
		cbbTuongTac = new System.Windows.Forms.ComboBox();
		plComment = new System.Windows.Forms.Panel();
		CD398206 = new System.Windows.Forms.Panel();
		EF05C436 = new System.Windows.Forms.TabControl();
		tabCommentText = new System.Windows.Forms.TabPage();
		DB2E6416 = new System.Windows.Forms.RichTextBox();
		AF9630A0 = new System.Windows.Forms.CheckBox();
		C73B0B30 = new System.Windows.Forms.Label();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		FB90470A = new System.Windows.Forms.Button();
		CE082C98 = new System.Windows.Forms.TabPage();
		btnPrompt = new System.Windows.Forms.Button();
		F339933B = new System.Windows.Forms.ComboBox();
		EE95588D = new System.Windows.Forms.Label();
		checkBox1 = new System.Windows.Forms.CheckBox();
		C20632B1 = new System.Windows.Forms.CheckBox();
		lblNoiDung = new System.Windows.Forms.Label();
		plAnh = new System.Windows.Forms.Panel();
		EF0D761E = new System.Windows.Forms.Label();
		F0AEF39D = new System.Windows.Forms.NumericUpDown();
		BC8ED191 = new System.Windows.Forms.NumericUpDown();
		label10 = new System.Windows.Forms.Label();
		C1139C0F = new System.Windows.Forms.TextBox();
		DD847891 = new System.Windows.Forms.Label();
		ckbSendAnh = new System.Windows.Forms.CheckBox();
		B93F2315 = new System.Windows.Forms.Label();
		nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
		DA263506 = new System.Windows.Forms.Label();
		E0A0AD8A = new System.Windows.Forms.CheckBox();
		ckbNhanTinVanBan = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		EB24AE05 = new System.Windows.Forms.Label();
		EA88022C = new System.Windows.Forms.Label();
		btnCancel = new System.Windows.Forms.Button();
		F63A4085 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		C3AB4015.SuspendLayout();
		plUid.SuspendLayout();
		plTuongTacTruocKhiNhanTin.SuspendLayout();
		plComment.SuspendLayout();
		CD398206.SuspendLayout();
		EF05C436.SuspendLayout();
		tabCommentText.SuspendLayout();
		CE082C98.SuspendLayout();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)F0AEF39D).BeginInit();
		((System.ComponentModel.ISupportInitialize)BC8ED191).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		AA34BF16.Fixed = true;
		AA34BF16.Horizontal = true;
		AA34BF16.TargetControl = bunifuCustomLabel1;
		AA34BF16.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(696, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Nhắn tin";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CA29410B.Fixed = true;
		CA29410B.Horizontal = true;
		CA29410B.TargetControl = pnlHeader;
		CA29410B.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(696, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(665, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 77;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(ED3D6D19);
		C3AB4015.BackColor = System.Drawing.Color.White;
		C3AB4015.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C3AB4015.Controls.Add(plUid);
		C3AB4015.Controls.Add(C1BEED9C);
		C3AB4015.Controls.Add(E584C19C);
		C3AB4015.Controls.Add(plTuongTacTruocKhiNhanTin);
		C3AB4015.Controls.Add(plComment);
		C3AB4015.Controls.Add(plAnh);
		C3AB4015.Controls.Add(ckbSendAnh);
		C3AB4015.Controls.Add(B93F2315);
		C3AB4015.Controls.Add(nudSoLuongUidFrom);
		C3AB4015.Controls.Add(nudSoLuongUidTo);
		C3AB4015.Controls.Add(DA263506);
		C3AB4015.Controls.Add(E0A0AD8A);
		C3AB4015.Controls.Add(ckbNhanTinVanBan);
		C3AB4015.Controls.Add(nudDelayTo);
		C3AB4015.Controls.Add(nudDelayFrom);
		C3AB4015.Controls.Add(txtTenHanhDong);
		C3AB4015.Controls.Add(label7);
		C3AB4015.Controls.Add(EB24AE05);
		C3AB4015.Controls.Add(EA88022C);
		C3AB4015.Controls.Add(btnCancel);
		C3AB4015.Controls.Add(F63A4085);
		C3AB4015.Controls.Add(bunifuCards1);
		C3AB4015.Cursor = System.Windows.Forms.Cursors.Arrow;
		C3AB4015.Dock = System.Windows.Forms.DockStyle.Fill;
		C3AB4015.Location = new System.Drawing.Point(0, 0);
		C3AB4015.Name = "panel1";
		C3AB4015.Size = new System.Drawing.Size(699, 495);
		C3AB4015.TabIndex = 0;
		C3AB4015.Paint += new System.Windows.Forms.PaintEventHandler(C3AB4015_Paint);
		plUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plUid.Controls.Add(DA3EEA37);
		plUid.Controls.Add(txtUid);
		plUid.Controls.Add(ckbTuDongXoaUid);
		plUid.Location = new System.Drawing.Point(30, 167);
		plUid.Name = "plUid";
		plUid.Size = new System.Drawing.Size(265, 209);
		plUid.TabIndex = 194;
		DA3EEA37.AutoSize = true;
		DA3EEA37.Location = new System.Drawing.Point(0, 3);
		DA3EEA37.Name = "lblUid";
		DA3EEA37.Size = new System.Drawing.Size(114, 16);
		DA3EEA37.TabIndex = 0;
		DA3EEA37.Text = "Danh sách Uid (0):";
		txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtUid.Location = new System.Drawing.Point(3, 22);
		txtUid.Name = "txtUid";
		txtUid.Size = new System.Drawing.Size(257, 160);
		txtUid.TabIndex = 117;
		txtUid.Text = "";
		txtUid.WordWrap = false;
		txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
		ckbTuDongXoaUid.AutoSize = true;
		ckbTuDongXoaUid.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongXoaUid.Location = new System.Drawing.Point(3, 184);
		ckbTuDongXoaUid.Name = "ckbTuDongXoaUid";
		ckbTuDongXoaUid.Size = new System.Drawing.Size(188, 20);
		ckbTuDongXoaUid.TabIndex = 8;
		ckbTuDongXoaUid.Text = "Tự động xóa Uid đã nhắn tin";
		ckbTuDongXoaUid.UseVisualStyleBackColor = true;
		C1BEED9C.Cursor = System.Windows.Forms.Cursors.Hand;
		C1BEED9C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		C1BEED9C.DropDownWidth = 200;
		C1BEED9C.FormattingEnabled = true;
		C1BEED9C.Location = new System.Drawing.Point(131, 137);
		C1BEED9C.Name = "cbbDoiTuongNhanTin";
		C1BEED9C.Size = new System.Drawing.Size(164, 24);
		C1BEED9C.TabIndex = 193;
		C1BEED9C.SelectedIndexChanged += new System.EventHandler(A182E431);
		E584C19C.AutoSize = true;
		E584C19C.Location = new System.Drawing.Point(27, 140);
		E584C19C.Name = "label2";
		E584C19C.Size = new System.Drawing.Size(64, 16);
		E584C19C.TabIndex = 192;
		E584C19C.Text = "Tùy chọn:";
		plTuongTacTruocKhiNhanTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuongTacTruocKhiNhanTin.Controls.Add(B13FD187);
		plTuongTacTruocKhiNhanTin.Controls.Add(cbbTuongTac);
		plTuongTacTruocKhiNhanTin.Enabled = false;
		plTuongTacTruocKhiNhanTin.Location = new System.Drawing.Point(30, 403);
		plTuongTacTruocKhiNhanTin.Name = "plTuongTacTruocKhiNhanTin";
		plTuongTacTruocKhiNhanTin.Size = new System.Drawing.Size(265, 32);
		plTuongTacTruocKhiNhanTin.TabIndex = 163;
		B13FD187.AutoSize = true;
		B13FD187.Cursor = System.Windows.Forms.Cursors.Hand;
		B13FD187.Location = new System.Drawing.Point(212, 6);
		B13FD187.Name = "lblTuongTacNhom";
		B13FD187.Size = new System.Drawing.Size(47, 16);
		B13FD187.TabIndex = 184;
		B13FD187.TabStop = true;
		B13FD187.Text = "Cài đặt";
		B13FD187.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(B13FD187_LinkClicked);
		cbbTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuongTac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuongTac.FormattingEnabled = true;
		cbbTuongTac.Location = new System.Drawing.Point(3, 3);
		cbbTuongTac.Name = "cbbTuongTac";
		cbbTuongTac.Size = new System.Drawing.Size(203, 24);
		cbbTuongTac.TabIndex = 107;
		cbbTuongTac.SelectedIndexChanged += new System.EventHandler(D709AD17);
		plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plComment.Controls.Add(CD398206);
		plComment.Controls.Add(C20632B1);
		plComment.Controls.Add(lblNoiDung);
		plComment.Location = new System.Drawing.Point(328, 73);
		plComment.Name = "plComment";
		plComment.Size = new System.Drawing.Size(335, 277);
		plComment.TabIndex = 10;
		CD398206.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		CD398206.Controls.Add(EF05C436);
		CD398206.Controls.Add(checkBox1);
		CD398206.Location = new System.Drawing.Point(-1, 26);
		CD398206.Name = "panel2";
		CD398206.Size = new System.Drawing.Size(335, 288);
		CD398206.TabIndex = 195;
		EF05C436.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		EF05C436.Controls.Add(tabCommentText);
		EF05C436.Controls.Add(CE082C98);
		EF05C436.Location = new System.Drawing.Point(-7, -6);
		EF05C436.Name = "tabControl1";
		EF05C436.SelectedIndex = 0;
		EF05C436.Size = new System.Drawing.Size(341, 285);
		EF05C436.TabIndex = 198;
		tabCommentText.Controls.Add(DB2E6416);
		tabCommentText.Controls.Add(AF9630A0);
		tabCommentText.Controls.Add(C73B0B30);
		tabCommentText.Controls.Add(cbbTuyChonNoiDung);
		tabCommentText.Controls.Add(FB90470A);
		tabCommentText.Location = new System.Drawing.Point(4, 4);
		tabCommentText.Name = "tabCommentText";
		tabCommentText.Padding = new System.Windows.Forms.Padding(3);
		tabCommentText.Size = new System.Drawing.Size(333, 256);
		tabCommentText.TabIndex = 0;
		tabCommentText.Text = "Comment text";
		tabCommentText.UseVisualStyleBackColor = true;
		DB2E6416.Location = new System.Drawing.Point(6, 5);
		DB2E6416.Name = "txtNoiDung";
		DB2E6416.Size = new System.Drawing.Size(324, 190);
		DB2E6416.TabIndex = 165;
		DB2E6416.Text = "";
		DB2E6416.WordWrap = false;
		DB2E6416.TextChanged += new System.EventHandler(DB2E6416_TextChanged);
		AF9630A0.AutoSize = true;
		AF9630A0.Cursor = System.Windows.Forms.Cursors.Hand;
		AF9630A0.Location = new System.Drawing.Point(7, 227);
		AF9630A0.Name = "ckbAutoDeleteComment";
		AF9630A0.Size = new System.Drawing.Size(169, 20);
		AF9630A0.TabIndex = 198;
		AF9630A0.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		AF9630A0.UseVisualStyleBackColor = true;
		C73B0B30.AutoSize = true;
		C73B0B30.Location = new System.Drawing.Point(3, 203);
		C73B0B30.Name = "label11";
		C73B0B30.Size = new System.Drawing.Size(64, 16);
		C73B0B30.TabIndex = 8;
		C73B0B30.Text = "Tùy chọn:";
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(69, 200);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(174, 24);
		cbbTuyChonNoiDung.TabIndex = 197;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		FB90470A.Cursor = System.Windows.Forms.Cursors.Hand;
		FB90470A.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FB90470A.Location = new System.Drawing.Point(249, 199);
		FB90470A.Name = "btnHuongDanNhapNoiDung";
		FB90470A.Size = new System.Drawing.Size(26, 26);
		FB90470A.TabIndex = 196;
		FB90470A.Text = "?";
		FB90470A.UseVisualStyleBackColor = true;
		FB90470A.Click += new System.EventHandler(FB90470A_Click);
		CE082C98.Controls.Add(btnPrompt);
		CE082C98.Controls.Add(F339933B);
		CE082C98.Controls.Add(EE95588D);
		CE082C98.Location = new System.Drawing.Point(4, 4);
		CE082C98.Name = "tabCommentAI";
		CE082C98.Padding = new System.Windows.Forms.Padding(3);
		CE082C98.Size = new System.Drawing.Size(333, 259);
		CE082C98.TabIndex = 1;
		CE082C98.Text = "Comment AI";
		CE082C98.UseVisualStyleBackColor = true;
		btnPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
		btnPrompt.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnPrompt.Location = new System.Drawing.Point(297, 4);
		btnPrompt.Name = "btnPrompt";
		btnPrompt.Size = new System.Drawing.Size(33, 27);
		btnPrompt.TabIndex = 34;
		btnPrompt.Text = "...";
		btnPrompt.UseVisualStyleBackColor = true;
		btnPrompt.Click += new System.EventHandler(DA291523);
		F339933B.Cursor = System.Windows.Forms.Cursors.Hand;
		F339933B.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		F339933B.DropDownWidth = 120;
		F339933B.FormattingEnabled = true;
		F339933B.Location = new System.Drawing.Point(97, 6);
		F339933B.Name = "cbbPrompt";
		F339933B.Size = new System.Drawing.Size(194, 24);
		F339933B.TabIndex = 33;
		EE95588D.AutoSize = true;
		EE95588D.Location = new System.Drawing.Point(6, 9);
		EE95588D.Name = "label6";
		EE95588D.Size = new System.Drawing.Size(86, 16);
		EE95588D.TabIndex = 32;
		EE95588D.Text = "Cho\u0323n Prompt:";
		checkBox1.AutoSize = true;
		checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		checkBox1.Location = new System.Drawing.Point(7, 209);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(169, 20);
		checkBox1.TabIndex = 8;
		checkBox1.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		checkBox1.UseVisualStyleBackColor = true;
		C20632B1.AutoSize = true;
		C20632B1.Cursor = System.Windows.Forms.Cursors.Hand;
		C20632B1.Location = new System.Drawing.Point(183, 4);
		C20632B1.Name = "ckbTaoNoiDungAI";
		C20632B1.Size = new System.Drawing.Size(149, 20);
		C20632B1.TabIndex = 199;
		C20632B1.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		C20632B1.UseVisualStyleBackColor = true;
		C20632B1.CheckedChanged += new System.EventHandler(F425249B);
		lblNoiDung.AutoSize = true;
		lblNoiDung.Location = new System.Drawing.Point(2, 5);
		lblNoiDung.Name = "lblNoiDung";
		lblNoiDung.Size = new System.Drawing.Size(133, 16);
		lblNoiDung.TabIndex = 0;
		lblNoiDung.Text = "Nội dung tin nhắn (0):";
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(EF0D761E);
		plAnh.Controls.Add(F0AEF39D);
		plAnh.Controls.Add(BC8ED191);
		plAnh.Controls.Add(label10);
		plAnh.Controls.Add(C1139C0F);
		plAnh.Controls.Add(DD847891);
		plAnh.Enabled = false;
		plAnh.Location = new System.Drawing.Point(328, 375);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(335, 61);
		plAnh.TabIndex = 162;
		EF0D761E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		EF0D761E.Location = new System.Drawing.Point(152, 34);
		EF0D761E.Name = "label9";
		EF0D761E.Size = new System.Drawing.Size(29, 16);
		EF0D761E.TabIndex = 38;
		EF0D761E.Text = ">";
		EF0D761E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		F0AEF39D.Location = new System.Drawing.Point(106, 32);
		F0AEF39D.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		F0AEF39D.Name = "nudSoLuongAnhFrom";
		F0AEF39D.Size = new System.Drawing.Size(43, 23);
		F0AEF39D.TabIndex = 5;
		BC8ED191.Location = new System.Drawing.Point(183, 32);
		BC8ED191.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		BC8ED191.Name = "nudSoLuongAnhTo";
		BC8ED191.Size = new System.Drawing.Size(43, 23);
		BC8ED191.TabIndex = 6;
		label10.AutoSize = true;
		label10.Location = new System.Drawing.Point(3, 7);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(73, 16);
		label10.TabIndex = 159;
		label10.Text = "Folder ảnh:";
		C1139C0F.Location = new System.Drawing.Point(106, 4);
		C1139C0F.Name = "txtAnh";
		C1139C0F.Size = new System.Drawing.Size(224, 23);
		C1139C0F.TabIndex = 158;
		DD847891.AutoSize = true;
		DD847891.Location = new System.Drawing.Point(3, 34);
		DD847891.Name = "label3";
		DD847891.Size = new System.Drawing.Size(103, 16);
		DD847891.TabIndex = 34;
		DD847891.Text = "Số ảnh/tin nhắn:";
		ckbSendAnh.AutoSize = true;
		ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSendAnh.Location = new System.Drawing.Point(328, 353);
		ckbSendAnh.Name = "ckbSendAnh";
		ckbSendAnh.Size = new System.Drawing.Size(70, 20);
		ckbSendAnh.TabIndex = 161;
		ckbSendAnh.Text = "Gửi ảnh";
		ckbSendAnh.UseVisualStyleBackColor = true;
		ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
		B93F2315.AutoSize = true;
		B93F2315.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		B93F2315.Location = new System.Drawing.Point(27, 81);
		B93F2315.Name = "label49";
		B93F2315.Size = new System.Drawing.Size(85, 16);
		B93F2315.TabIndex = 92;
		B93F2315.Text = "Sô\u0301 lươ\u0323ng Uid:";
		nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidFrom.Location = new System.Drawing.Point(131, 79);
		nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
		nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidFrom.TabIndex = 1;
		nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidTo.Location = new System.Drawing.Point(239, 79);
		nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidTo.Name = "nudSoLuongUidTo";
		nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidTo.TabIndex = 2;
		nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		DA263506.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		DA263506.Location = new System.Drawing.Point(199, 81);
		DA263506.Name = "label66";
		DA263506.Size = new System.Drawing.Size(29, 16);
		DA263506.TabIndex = 105;
		DA263506.Text = ">";
		DA263506.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E0A0AD8A.AutoSize = true;
		E0A0AD8A.Cursor = System.Windows.Forms.Cursors.Hand;
		E0A0AD8A.Location = new System.Drawing.Point(30, 380);
		E0A0AD8A.Name = "ckbTuongTacKhiNhanTin";
		E0A0AD8A.Size = new System.Drawing.Size(154, 20);
		E0A0AD8A.TabIndex = 9;
		E0A0AD8A.Text = "Tương tác khi nhắn tin";
		E0A0AD8A.UseVisualStyleBackColor = true;
		E0A0AD8A.CheckedChanged += new System.EventHandler(E0A0AD8A_CheckedChanged);
		ckbNhanTinVanBan.AutoSize = true;
		ckbNhanTinVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbNhanTinVanBan.Location = new System.Drawing.Point(328, 51);
		ckbNhanTinVanBan.Name = "ckbNhanTinVanBan";
		ckbNhanTinVanBan.Size = new System.Drawing.Size(122, 20);
		ckbNhanTinVanBan.TabIndex = 9;
		ckbNhanTinVanBan.Text = "Nhắn tin văn bản";
		ckbNhanTinVanBan.UseVisualStyleBackColor = true;
		ckbNhanTinVanBan.CheckedChanged += new System.EventHandler(B7A949AA);
		nudDelayTo.Location = new System.Drawing.Point(239, 108);
		nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 6;
		nudDelayFrom.Location = new System.Drawing.Point(131, 108);
		nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 5;
		txtTenHanhDong.Location = new System.Drawing.Point(131, 50);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(164, 23);
		txtTenHanhDong.TabIndex = 0;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(199, 110);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		EB24AE05.AutoSize = true;
		EB24AE05.Location = new System.Drawing.Point(27, 110);
		EB24AE05.Name = "label5";
		EB24AE05.Size = new System.Drawing.Size(87, 16);
		EB24AE05.TabIndex = 34;
		EB24AE05.Text = "Gia\u0303n ca\u0301ch (s):";
		EA88022C.AutoSize = true;
		EA88022C.Location = new System.Drawing.Point(27, 53);
		EA88022C.Name = "label1";
		EA88022C.Size = new System.Drawing.Size(98, 16);
		EA88022C.TabIndex = 31;
		EA88022C.Text = "Tên ha\u0300nh đô\u0323ng:";
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(319, 453);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 12;
		btnCancel.Text = "Đóng";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(btnCancel_Click);
		F63A4085.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F63A4085.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		F63A4085.Cursor = System.Windows.Forms.Cursors.Hand;
		F63A4085.FlatAppearance.BorderSize = 0;
		F63A4085.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F63A4085.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F63A4085.ForeColor = System.Drawing.Color.White;
		F63A4085.Location = new System.Drawing.Point(212, 453);
		F63A4085.Name = "btnAdd";
		F63A4085.Size = new System.Drawing.Size(92, 29);
		F63A4085.TabIndex = 11;
		F63A4085.Text = "Thêm";
		F63A4085.UseVisualStyleBackColor = false;
		F63A4085.Click += new System.EventHandler(F63A4085_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(696, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(699, 495);
		base.Controls.Add(C3AB4015);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBuffTinNhanProfile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBuffTinNhanProfile_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		C3AB4015.ResumeLayout(false);
		C3AB4015.PerformLayout();
		plUid.ResumeLayout(false);
		plUid.PerformLayout();
		plTuongTacTruocKhiNhanTin.ResumeLayout(false);
		plTuongTacTruocKhiNhanTin.PerformLayout();
		plComment.ResumeLayout(false);
		plComment.PerformLayout();
		CD398206.ResumeLayout(false);
		CD398206.PerformLayout();
		EF05C436.ResumeLayout(false);
		tabCommentText.ResumeLayout(false);
		tabCommentText.PerformLayout();
		CE082C98.ResumeLayout(false);
		CE082C98.PerformLayout();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)F0AEF39D).EndInit();
		((System.ComponentModel.ISupportInitialize)BC8ED191).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
