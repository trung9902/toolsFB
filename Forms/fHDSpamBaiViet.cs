using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDSpamBaiViet : Form
{
	internal GClass4 gclass4_0;

	internal string F2334130;

	internal string string_0;

	internal string string_1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool D69ADC8A;

	internal List<CheckBox> list_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl AFA6E4A0;

	internal Panel A08AFD03;

	internal NumericUpDown E5174B16;

	internal NumericUpDown B92E4433;

	internal NumericUpDown nudDelayFrom;

	internal NumericUpDown nudSoLuongBaiVietFrom;

	internal TextBox BC9F362C;

	internal Label C91A3304;

	internal Label label3;

	internal Label CDA35C1D;

	internal Label label1;

	internal Button C53C113E;

	internal Panel pnlTopAccent;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button D5B291A3;

	internal PictureBox E39FB6B8;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Panel C2B7F600;

	internal Label lblComment;

	internal CheckBox ADB0AA3A;

	internal CheckBox C5325A9B;

	internal CheckBox ckbShareWall;

	internal Label label49;

	internal NumericUpDown nudSoLuongUidFrom;

	internal Label label19;

	internal NumericUpDown nudSoLuongUidTo;

	internal Label AFA74E1B;

	internal RichTextBox E00EBA9D;

	internal Panel plAnh;

	internal CheckBox ckbSendAnh;

	internal RichTextBox txtComment;

	internal CheckBox DCBA7C9B;

	internal TextBox txtAnh;

	internal Label label12;

	internal CheckBox ckbAutoDeleteComment;

	internal Button C5999D29;

	internal Button A7803B15;

	internal Panel panel2;

	internal NumericUpDown nudBoQuaTo;

	internal NumericUpDown B3128014;

	internal Label label8;

	internal Label label11;

	internal CheckBox ckbBoQua;

	internal CheckBox ckbTuDongThamGiaNhom;

	internal CheckBox A404060A;

	internal Panel plInteract;

	internal CheckBox ckbGian;

	internal CheckBox ckbBuon;

	internal CheckBox ckbWow;

	internal CheckBox B822D80F;

	internal CheckBox C90C59AE;

	internal CheckBox ckbTym;

	internal CheckBox A09549A3;

	internal Panel BA31DD31;

	internal RadioButton C38F62A7;

	internal RadioButton radioButton4;

	internal Label label26;

	internal Label F121F392;

	internal Label lblUid;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button btnHuongDanNhapNoiDung;

	internal Label label2;

	internal ComboBox cbbLoaiDoiTuong;

	internal CheckBox ED11F30D;

	internal Panel plEditComment;

	internal ComboBox cbbTuyChonNoiDungEdit;

	internal Button AB149E21;

	internal Label DC0D823F;

	internal RichTextBox txtCommentEdit;

	internal Label lblCommentEdit;

	internal Label BD9E1733;

	internal Label label13;

	internal NumericUpDown E53AA4B4;

	internal NumericUpDown F4974C9D;

	internal CheckBox ckbEditComment;

	internal CheckBox BAA5540E;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return D69ADC8A;
		}
		[CompilerGenerated]
		set
		{
			D69ADC8A = value;
		}
	}

	public fHDSpamBaiViet(string A2B96E8C, string string_2 = "")
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
		F2334130 = A2B96E8C;
		string_1 = string_2;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_2 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_0 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			BC9F362C.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_2);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			BC9F362C.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		list_0 = new List<CheckBox> { A09549A3, ckbTym, C90C59AE, B822D80F, ckbWow, ckbBuon, ckbGian };
	}

	private void fHDSpamBaiViet_Load(object sender, EventArgs e)
	{
		method_0();
		method_1();
		try
		{
			nudSoLuongUidFrom.Value = gclass4_0.method_2("nudSoLuongUidFrom", 1);
			nudSoLuongUidTo.Value = gclass4_0.method_2("nudSoLuongUidTo", 1);
			nudSoLuongBaiVietFrom.Value = gclass4_0.method_2("nudSoLuongBaiVietFrom", 1);
			B92E4433.Value = gclass4_0.method_2("nudSoLuongBaiVietTo", 1);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			E5174B16.Value = gclass4_0.method_2("nudDelayTo", 5);
			cbbLoaiDoiTuong.SelectedIndex = gclass4_0.method_2("typeID", 1);
			E00EBA9D.Text = gclass4_0.BDB80B23("txtUid");
			C5325A9B.Checked = gclass4_0.method_3("ckbInteract");
			string text = gclass4_0.BDB80B23("typeReaction", "0");
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Checked = text.Split('|').Contains(i.ToString());
			}
			ckbShareWall.Checked = gclass4_0.method_3("ckbShareWall");
			ED11F30D.Checked = gclass4_0.method_3("ckbRunAPI");
			ADB0AA3A.Checked = gclass4_0.method_3("ckbComment");
			txtComment.Text = gclass4_0.BDB80B23("txtComment");
			ckbAutoDeleteComment.Checked = gclass4_0.method_3("ckbAutoDeleteComment");
			ckbSendAnh.Checked = gclass4_0.method_3("ckbSendAnh");
			txtAnh.Text = gclass4_0.BDB80B23("txtAnh");
			Commom.AttachFolderPicker(txtAnh);
			DCBA7C9B.Checked = gclass4_0.method_3("ckbTuDongXoaUid");
			A404060A.Checked = gclass4_0.method_3("ckbKhongCommentTrungBaiCu");
			ckbBoQua.Checked = gclass4_0.method_3("ckbBoQua");
			B3128014.Value = gclass4_0.method_2("nudBoQuaFrom", 1);
			nudBoQuaTo.Value = gclass4_0.method_2("nudBoQuaTo", 1);
			ckbTuDongThamGiaNhom.Checked = gclass4_0.method_3("ckbTuDongThamGiaNhom");
			cbbTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("typeNganCach");
			ckbEditComment.Checked = gclass4_0.method_3("ckbEditComment");
			E53AA4B4.Value = gclass4_0.method_2("nudDelayEditFrom", 1);
			F4974C9D.Value = gclass4_0.method_2("nudDelayEditTo", 1);
			txtCommentEdit.Text = gclass4_0.BDB80B23("txtCommentEdit");
			cbbTuyChonNoiDungEdit.SelectedIndex = gclass4_0.method_2("cbbTuyChonNoiDungEdit");
			BAA5540E.Checked = gclass4_0.method_3("ckbUuTienMbasic");
		}
		catch
		{
		}
		A41F36BA();
	}

	private void method_0()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list);
	}

	private void method_1()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDungEdit, list);
	}

	private void D5B291A3_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C19870B4(object sender, EventArgs e)
	{
		string text = BC9F362C.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
		gClass.method_4("nudSoLuongUidTo", nudSoLuongUidTo.Value);
		gClass.method_4("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
		gClass.method_4("nudSoLuongBaiVietTo", B92E4433.Value);
		gClass.method_4("nudDelayFrom", nudDelayFrom.Value);
		gClass.method_4("nudDelayTo", E5174B16.Value);
		gClass.method_4("typeListUid", 0);
		gClass.method_4("typeID", cbbLoaiDoiTuong.SelectedIndex);
		gClass.method_4("txtUid", E00EBA9D.Text.Trim());
		gClass.method_4("ckbInteract", C5325A9B.Checked);
		string text2 = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text2 = text2 + i + "|";
			}
		}
		gClass.method_4("typeReaction", text2.TrimEnd('|'));
		gClass.method_4("ckbShareWall", ckbShareWall.Checked);
		gClass.method_4("ckbRunAPI", ED11F30D.Checked);
		gClass.method_4("ckbComment", ADB0AA3A.Checked);
		gClass.method_4("txtComment", txtComment.Text.Trim());
		gClass.method_4("ckbAutoDeleteComment", ckbAutoDeleteComment.Checked);
		gClass.method_4("ckbSendAnh", ckbSendAnh.Checked);
		gClass.method_4("txtAnh", txtAnh.Text.Trim());
		gClass.method_4("ckbTuDongXoaUid", DCBA7C9B.Checked);
		gClass.method_4("ckbKhongCommentTrungBaiCu", A404060A.Checked);
		gClass.method_4("ckbBoQua", ckbBoQua.Checked);
		gClass.method_4("nudBoQuaFrom", B3128014.Value);
		gClass.method_4("nudBoQuaTo", nudBoQuaTo.Value);
		gClass.method_4("ckbTuDongThamGiaNhom", ckbTuDongThamGiaNhom.Checked);
		gClass.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		gClass.method_4("ckbEditComment", ckbEditComment.Checked);
		gClass.method_4("nudDelayEditFrom", E53AA4B4.Value);
		gClass.method_4("nudDelayEditTo", F4974C9D.Value);
		gClass.method_4("txtCommentEdit", txtCommentEdit.Text.Trim());
		gClass.method_4("cbbTuyChonNoiDungEdit", cbbTuyChonNoiDungEdit.SelectedIndex);
		gClass.method_4("ckbUuTienMbasic", BAA5540E.Checked);
		string e013A = gClass.ED11179C();
		if (string_1 == "")
		{
			if (MsBoxHelper.D41C45AC("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?") == DialogResult.Yes)
			{
				if (Class154.smethod_11(F2334130, text, string_0, e013A))
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

	private void EE1E383E(object sender, EventArgs e)
	{
		Close();
	}

	private void EC9C789F(object sender, PaintEventArgs e)
	{
		if (A08AFD03.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, A08AFD03.ClientSize.Width - num, A08AFD03.ClientSize.Height - num));
		}
	}

	private void txtComment_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, lblComment, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void A41F36BA()
	{
		BF9A388F(null, null);
		ADB0AA3A_CheckedChanged(null, null);
		ckbBoQua_CheckedChanged(null, null);
		BE2B8807(null, null);
		ckbEditComment_CheckedChanged(null, null);
	}

	private void ADB0AA3A_CheckedChanged(object sender, EventArgs e)
	{
		C2B7F600.Enabled = ADB0AA3A.Checked;
	}

	private void E00EBA9D_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(E00EBA9D, lblUid);
	}

	private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbSendAnh.Checked;
	}

	private void C5999D29_Click(object sender, EventArgs e)
	{
		C2B7F600.Height = 436;
		base.Height = 657;
	}

	private void A7803B15_Click(object sender, EventArgs e)
	{
		C2B7F600.Height = 189;
		base.Height = 491;
	}

	private void ckbBoQua_CheckedChanged(object sender, EventArgs e)
	{
		panel2.Enabled = ckbBoQua.Checked;
	}

	private void BF9A388F(object sender, EventArgs e)
	{
		plInteract.Enabled = C5325A9B.Checked;
	}

	private void cbbTuyChonNoiDung_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtComment, lblComment, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void E198E204(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtComment.Focus();
	}

	private void BE2B8807(object sender, EventArgs e)
	{
		C5325A9B.Enabled = !ED11F30D.Checked;
		ckbSendAnh.Enabled = !ED11F30D.Checked;
		if (ED11F30D.Checked)
		{
			C5325A9B.Checked = false;
			ckbSendAnh.Checked = false;
		}
	}

	private void A3325A05(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDungEdit.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtCommentEdit.Focus();
	}

	private void txtCommentEdit_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtCommentEdit, lblCommentEdit, cbbTuyChonNoiDungEdit.SelectedIndex);
	}

	private void FC8EBAA4(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtCommentEdit, lblCommentEdit, cbbTuyChonNoiDungEdit.SelectedIndex);
	}

	private void ckbEditComment_CheckedChanged(object sender, EventArgs e)
	{
		plEditComment.Enabled = ckbEditComment.Checked;
	}

	protected override void Dispose(bool F9339E8E)
	{
		if (F9339E8E && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(F9339E8E);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDSpamBaiViet));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		AFA6E4A0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		D5B291A3 = new System.Windows.Forms.Button();
		E39FB6B8 = new System.Windows.Forms.PictureBox();
		A08AFD03 = new System.Windows.Forms.Panel();
		C2B7F600 = new System.Windows.Forms.Panel();
		plEditComment = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDungEdit = new System.Windows.Forms.ComboBox();
		AB149E21 = new System.Windows.Forms.Button();
		DC0D823F = new System.Windows.Forms.Label();
		txtCommentEdit = new System.Windows.Forms.RichTextBox();
		lblCommentEdit = new System.Windows.Forms.Label();
		BD9E1733 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		E53AA4B4 = new System.Windows.Forms.NumericUpDown();
		F4974C9D = new System.Windows.Forms.NumericUpDown();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		btnHuongDanNhapNoiDung = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		C5999D29 = new System.Windows.Forms.Button();
		A7803B15 = new System.Windows.Forms.Button();
		txtComment = new System.Windows.Forms.RichTextBox();
		lblComment = new System.Windows.Forms.Label();
		ckbEditComment = new System.Windows.Forms.CheckBox();
		ckbAutoDeleteComment = new System.Windows.Forms.CheckBox();
		BAA5540E = new System.Windows.Forms.CheckBox();
		ED11F30D = new System.Windows.Forms.CheckBox();
		cbbLoaiDoiTuong = new System.Windows.Forms.ComboBox();
		F121F392 = new System.Windows.Forms.Label();
		lblUid = new System.Windows.Forms.Label();
		plInteract = new System.Windows.Forms.Panel();
		ckbGian = new System.Windows.Forms.CheckBox();
		ckbBuon = new System.Windows.Forms.CheckBox();
		ckbWow = new System.Windows.Forms.CheckBox();
		B822D80F = new System.Windows.Forms.CheckBox();
		C90C59AE = new System.Windows.Forms.CheckBox();
		ckbTym = new System.Windows.Forms.CheckBox();
		A09549A3 = new System.Windows.Forms.CheckBox();
		BA31DD31 = new System.Windows.Forms.Panel();
		C38F62A7 = new System.Windows.Forms.RadioButton();
		radioButton4 = new System.Windows.Forms.RadioButton();
		label26 = new System.Windows.Forms.Label();
		ckbTuDongThamGiaNhom = new System.Windows.Forms.CheckBox();
		panel2 = new System.Windows.Forms.Panel();
		nudBoQuaTo = new System.Windows.Forms.NumericUpDown();
		B3128014 = new System.Windows.Forms.NumericUpDown();
		label8 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		ckbBoQua = new System.Windows.Forms.CheckBox();
		plAnh = new System.Windows.Forms.Panel();
		txtAnh = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		ckbSendAnh = new System.Windows.Forms.CheckBox();
		E00EBA9D = new System.Windows.Forms.RichTextBox();
		label49 = new System.Windows.Forms.Label();
		nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
		label19 = new System.Windows.Forms.Label();
		nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
		AFA74E1B = new System.Windows.Forms.Label();
		ADB0AA3A = new System.Windows.Forms.CheckBox();
		A404060A = new System.Windows.Forms.CheckBox();
		DCBA7C9B = new System.Windows.Forms.CheckBox();
		ckbShareWall = new System.Windows.Forms.CheckBox();
		C5325A9B = new System.Windows.Forms.CheckBox();
		E5174B16 = new System.Windows.Forms.NumericUpDown();
		B92E4433 = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
		BC9F362C = new System.Windows.Forms.TextBox();
		C91A3304 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		CDA35C1D = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		C53C113E = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E39FB6B8).BeginInit();
		A08AFD03.SuspendLayout();
		C2B7F600.SuspendLayout();
		plEditComment.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E53AA4B4).BeginInit();
		((System.ComponentModel.ISupportInitialize)F4974C9D).BeginInit();
		plInteract.SuspendLayout();
		BA31DD31.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudBoQuaTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)B3128014).BeginInit();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)E5174B16).BeginInit();
		((System.ComponentModel.ISupportInitialize)B92E4433).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).BeginInit();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(663, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Spam bài viết";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AFA6E4A0.Fixed = true;
		AFA6E4A0.Horizontal = true;
		AFA6E4A0.TargetControl = pnlHeader;
		AFA6E4A0.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(D5B291A3);
		pnlHeader.Controls.Add(E39FB6B8);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(663, 31);
		pnlHeader.TabIndex = 9;
		D5B291A3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D5B291A3.Cursor = System.Windows.Forms.Cursors.Hand;
		D5B291A3.FlatAppearance.BorderSize = 0;
		D5B291A3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D5B291A3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		D5B291A3.ForeColor = System.Drawing.Color.White;
		D5B291A3.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		D5B291A3.Location = new System.Drawing.Point(632, 1);
		D5B291A3.Name = "button1";
		D5B291A3.Size = new System.Drawing.Size(30, 30);
		D5B291A3.TabIndex = 77;
		D5B291A3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		D5B291A3.UseVisualStyleBackColor = true;
		D5B291A3.Click += new System.EventHandler(D5B291A3_Click);
		E39FB6B8.Cursor = System.Windows.Forms.Cursors.Default;
		E39FB6B8.Image = Class155.DD225F0D;
		E39FB6B8.Location = new System.Drawing.Point(3, 2);
		E39FB6B8.Name = "pictureBox1";
		E39FB6B8.Size = new System.Drawing.Size(34, 27);
		E39FB6B8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E39FB6B8.TabIndex = 76;
		E39FB6B8.TabStop = false;
		A08AFD03.BackColor = System.Drawing.Color.White;
		A08AFD03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A08AFD03.Controls.Add(C2B7F600);
		A08AFD03.Controls.Add(BAA5540E);
		A08AFD03.Controls.Add(ED11F30D);
		A08AFD03.Controls.Add(cbbLoaiDoiTuong);
		A08AFD03.Controls.Add(F121F392);
		A08AFD03.Controls.Add(lblUid);
		A08AFD03.Controls.Add(plInteract);
		A08AFD03.Controls.Add(ckbTuDongThamGiaNhom);
		A08AFD03.Controls.Add(panel2);
		A08AFD03.Controls.Add(ckbBoQua);
		A08AFD03.Controls.Add(plAnh);
		A08AFD03.Controls.Add(ckbSendAnh);
		A08AFD03.Controls.Add(E00EBA9D);
		A08AFD03.Controls.Add(label49);
		A08AFD03.Controls.Add(nudSoLuongUidFrom);
		A08AFD03.Controls.Add(label19);
		A08AFD03.Controls.Add(nudSoLuongUidTo);
		A08AFD03.Controls.Add(AFA74E1B);
		A08AFD03.Controls.Add(ADB0AA3A);
		A08AFD03.Controls.Add(A404060A);
		A08AFD03.Controls.Add(DCBA7C9B);
		A08AFD03.Controls.Add(ckbShareWall);
		A08AFD03.Controls.Add(C5325A9B);
		A08AFD03.Controls.Add(E5174B16);
		A08AFD03.Controls.Add(B92E4433);
		A08AFD03.Controls.Add(nudDelayFrom);
		A08AFD03.Controls.Add(nudSoLuongBaiVietFrom);
		A08AFD03.Controls.Add(BC9F362C);
		A08AFD03.Controls.Add(C91A3304);
		A08AFD03.Controls.Add(label3);
		A08AFD03.Controls.Add(CDA35C1D);
		A08AFD03.Controls.Add(label1);
		A08AFD03.Controls.Add(C53C113E);
		A08AFD03.Controls.Add(btnAdd);
		A08AFD03.Controls.Add(bunifuCards1);
		A08AFD03.Cursor = System.Windows.Forms.Cursors.Arrow;
		A08AFD03.Dock = System.Windows.Forms.DockStyle.Fill;
		A08AFD03.Location = new System.Drawing.Point(0, 0);
		A08AFD03.Name = "panel1";
		A08AFD03.Size = new System.Drawing.Size(666, 518);
		A08AFD03.TabIndex = 0;
		A08AFD03.Paint += new System.Windows.Forms.PaintEventHandler(EC9C789F);
		C2B7F600.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		C2B7F600.Controls.Add(plEditComment);
		C2B7F600.Controls.Add(cbbTuyChonNoiDung);
		C2B7F600.Controls.Add(btnHuongDanNhapNoiDung);
		C2B7F600.Controls.Add(label2);
		C2B7F600.Controls.Add(C5999D29);
		C2B7F600.Controls.Add(A7803B15);
		C2B7F600.Controls.Add(txtComment);
		C2B7F600.Controls.Add(lblComment);
		C2B7F600.Controls.Add(ckbEditComment);
		C2B7F600.Controls.Add(ckbAutoDeleteComment);
		C2B7F600.Location = new System.Drawing.Point(320, 163);
		C2B7F600.Name = "plComment";
		C2B7F600.Size = new System.Drawing.Size(313, 216);
		C2B7F600.TabIndex = 10;
		plEditComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plEditComment.Controls.Add(cbbTuyChonNoiDungEdit);
		plEditComment.Controls.Add(AB149E21);
		plEditComment.Controls.Add(DC0D823F);
		plEditComment.Controls.Add(txtCommentEdit);
		plEditComment.Controls.Add(lblCommentEdit);
		plEditComment.Controls.Add(BD9E1733);
		plEditComment.Controls.Add(label13);
		plEditComment.Controls.Add(E53AA4B4);
		plEditComment.Controls.Add(F4974C9D);
		plEditComment.Location = new System.Drawing.Point(7, 254);
		plEditComment.Name = "plEditComment";
		plEditComment.Size = new System.Drawing.Size(298, 218);
		plEditComment.TabIndex = 196;
		cbbTuyChonNoiDungEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDungEdit.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDungEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDungEdit.FormattingEnabled = true;
		cbbTuyChonNoiDungEdit.Location = new System.Drawing.Point(69, 186);
		cbbTuyChonNoiDungEdit.Name = "cbbTuyChonNoiDungEdit";
		cbbTuyChonNoiDungEdit.Size = new System.Drawing.Size(189, 24);
		cbbTuyChonNoiDungEdit.TabIndex = 195;
		cbbTuyChonNoiDungEdit.SelectedIndexChanged += new System.EventHandler(FC8EBAA4);
		AB149E21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		AB149E21.Cursor = System.Windows.Forms.Cursors.Hand;
		AB149E21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AB149E21.Location = new System.Drawing.Point(264, 185);
		AB149E21.Name = "button2";
		AB149E21.Size = new System.Drawing.Size(26, 26);
		AB149E21.TabIndex = 194;
		AB149E21.Text = "?";
		AB149E21.UseVisualStyleBackColor = true;
		AB149E21.Click += new System.EventHandler(A3325A05);
		DC0D823F.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		DC0D823F.AutoSize = true;
		DC0D823F.Location = new System.Drawing.Point(3, 189);
		DC0D823F.Name = "label4";
		DC0D823F.Size = new System.Drawing.Size(64, 16);
		DC0D823F.TabIndex = 193;
		DC0D823F.Text = "Tùy chọn:";
		txtCommentEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtCommentEdit.Location = new System.Drawing.Point(7, 53);
		txtCommentEdit.Name = "txtCommentEdit";
		txtCommentEdit.Size = new System.Drawing.Size(283, 128);
		txtCommentEdit.TabIndex = 1;
		txtCommentEdit.Text = "";
		txtCommentEdit.WordWrap = false;
		txtCommentEdit.TextChanged += new System.EventHandler(txtCommentEdit_TextChanged);
		lblCommentEdit.AutoSize = true;
		lblCommentEdit.Location = new System.Drawing.Point(4, 32);
		lblCommentEdit.Name = "lblCommentEdit";
		lblCommentEdit.Size = new System.Drawing.Size(139, 16);
		lblCommentEdit.TabIndex = 0;
		lblCommentEdit.Text = "Nội dung bình luận (0):";
		BD9E1733.AutoSize = true;
		BD9E1733.Location = new System.Drawing.Point(4, 6);
		BD9E1733.Name = "label9";
		BD9E1733.Size = new System.Drawing.Size(92, 16);
		BD9E1733.TabIndex = 34;
		BD9E1733.Text = "Delay time (s):";
		label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(170, 6);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(29, 16);
		label13.TabIndex = 38;
		label13.Text = ">";
		label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E53AA4B4.Location = new System.Drawing.Point(102, 4);
		E53AA4B4.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		E53AA4B4.Name = "nudDelayEditFrom";
		E53AA4B4.Size = new System.Drawing.Size(56, 23);
		E53AA4B4.TabIndex = 5;
		F4974C9D.Location = new System.Drawing.Point(209, 4);
		F4974C9D.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		F4974C9D.Name = "nudDelayEditTo";
		F4974C9D.Size = new System.Drawing.Size(56, 23);
		F4974C9D.TabIndex = 6;
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(69, 158);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(204, 24);
		cbbTuyChonNoiDung.TabIndex = 195;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDung_SelectedIndexChanged);
		btnHuongDanNhapNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnHuongDanNhapNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnHuongDanNhapNoiDung.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnHuongDanNhapNoiDung.Location = new System.Drawing.Point(279, 157);
		btnHuongDanNhapNoiDung.Name = "btnHuongDanNhapNoiDung";
		btnHuongDanNhapNoiDung.Size = new System.Drawing.Size(26, 26);
		btnHuongDanNhapNoiDung.TabIndex = 194;
		btnHuongDanNhapNoiDung.Text = "?";
		btnHuongDanNhapNoiDung.UseVisualStyleBackColor = true;
		btnHuongDanNhapNoiDung.Click += new System.EventHandler(E198E204);
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(3, 161);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(64, 16);
		label2.TabIndex = 193;
		label2.Text = "Tùy chọn:";
		C5999D29.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		C5999D29.BackgroundImage = Class155.Bitmap_94;
		C5999D29.Cursor = System.Windows.Forms.Cursors.Hand;
		C5999D29.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		C5999D29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C5999D29.Location = new System.Drawing.Point(256, -1);
		C5999D29.Name = "btnDown";
		C5999D29.Size = new System.Drawing.Size(25, 25);
		C5999D29.TabIndex = 191;
		C5999D29.Visible = false;
		C5999D29.Click += new System.EventHandler(C5999D29_Click);
		A7803B15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A7803B15.BackgroundImage = Class155.B116C210;
		A7803B15.Cursor = System.Windows.Forms.Cursors.Hand;
		A7803B15.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		A7803B15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A7803B15.Location = new System.Drawing.Point(287, -1);
		A7803B15.Name = "btnUp";
		A7803B15.Size = new System.Drawing.Size(25, 25);
		A7803B15.TabIndex = 192;
		A7803B15.Visible = false;
		A7803B15.Click += new System.EventHandler(A7803B15_Click);
		txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtComment.Location = new System.Drawing.Point(7, 25);
		txtComment.Name = "txtComment";
		txtComment.Size = new System.Drawing.Size(298, 128);
		txtComment.TabIndex = 1;
		txtComment.Text = "";
		txtComment.WordWrap = false;
		txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
		lblComment.AutoSize = true;
		lblComment.Location = new System.Drawing.Point(3, 5);
		lblComment.Name = "lblComment";
		lblComment.Size = new System.Drawing.Size(139, 16);
		lblComment.TabIndex = 0;
		lblComment.Text = "Nội dung bình luận (0):";
		ckbEditComment.AutoSize = true;
		ckbEditComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbEditComment.Location = new System.Drawing.Point(7, 232);
		ckbEditComment.Name = "ckbEditComment";
		ckbEditComment.Size = new System.Drawing.Size(159, 20);
		ckbEditComment.TabIndex = 8;
		ckbEditComment.Text = "Sửa nội dung comment";
		ckbEditComment.UseVisualStyleBackColor = true;
		ckbEditComment.CheckedChanged += new System.EventHandler(ckbEditComment_CheckedChanged);
		ckbAutoDeleteComment.AutoSize = true;
		ckbAutoDeleteComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoDeleteComment.Location = new System.Drawing.Point(7, 188);
		ckbAutoDeleteComment.Name = "ckbAutoDeleteComment";
		ckbAutoDeleteComment.Size = new System.Drawing.Size(169, 20);
		ckbAutoDeleteComment.TabIndex = 8;
		ckbAutoDeleteComment.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		ckbAutoDeleteComment.UseVisualStyleBackColor = true;
		BAA5540E.AutoSize = true;
		BAA5540E.Cursor = System.Windows.Forms.Cursors.Hand;
		BAA5540E.Location = new System.Drawing.Point(320, 445);
		BAA5540E.Name = "ckbUuTienMbasic";
		BAA5540E.Size = new System.Drawing.Size(173, 20);
		BAA5540E.TabIndex = 197;
		BAA5540E.Text = "Ưu tiên chạy bằng mbasic";
		BAA5540E.UseVisualStyleBackColor = true;
		ED11F30D.AutoSize = true;
		ED11F30D.Cursor = System.Windows.Forms.Cursors.Hand;
		ED11F30D.Location = new System.Drawing.Point(448, 141);
		ED11F30D.Name = "ckbRunAPI";
		ED11F30D.Size = new System.Drawing.Size(99, 20);
		ED11F30D.TabIndex = 196;
		ED11F30D.Text = "Run API (ẩn)";
		ED11F30D.UseVisualStyleBackColor = true;
		ED11F30D.CheckedChanged += new System.EventHandler(BE2B8807);
		cbbLoaiDoiTuong.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbLoaiDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbLoaiDoiTuong.FormattingEnabled = true;
		cbbLoaiDoiTuong.Items.AddRange(new object[3] { "Profile", "Group", "Page" });
		cbbLoaiDoiTuong.Location = new System.Drawing.Point(135, 166);
		cbbLoaiDoiTuong.Name = "cbbLoaiDoiTuong";
		cbbLoaiDoiTuong.Size = new System.Drawing.Size(153, 24);
		cbbLoaiDoiTuong.TabIndex = 195;
		F121F392.AutoSize = true;
		F121F392.Location = new System.Drawing.Point(27, 169);
		F121F392.Name = "label10";
		F121F392.Size = new System.Drawing.Size(93, 16);
		F121F392.TabIndex = 186;
		F121F392.Text = "Loại đối tượng:";
		lblUid.AutoSize = true;
		lblUid.Location = new System.Drawing.Point(27, 193);
		lblUid.Name = "lblUid";
		lblUid.Size = new System.Drawing.Size(140, 16);
		lblUid.TabIndex = 182;
		lblUid.Text = "Nhập danh sách ID (0):";
		plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plInteract.Controls.Add(ckbGian);
		plInteract.Controls.Add(ckbBuon);
		plInteract.Controls.Add(ckbWow);
		plInteract.Controls.Add(B822D80F);
		plInteract.Controls.Add(C90C59AE);
		plInteract.Controls.Add(ckbTym);
		plInteract.Controls.Add(A09549A3);
		plInteract.Controls.Add(BA31DD31);
		plInteract.Controls.Add(label26);
		plInteract.Location = new System.Drawing.Point(320, 102);
		plInteract.Name = "plInteract";
		plInteract.Size = new System.Drawing.Size(312, 33);
		plInteract.TabIndex = 181;
		ckbGian.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGian.Image = Class155.Bitmap_11;
		ckbGian.Location = new System.Drawing.Point(266, 1);
		ckbGian.Name = "ckbGian";
		ckbGian.Size = new System.Drawing.Size(40, 30);
		ckbGian.TabIndex = 179;
		ckbGian.UseVisualStyleBackColor = true;
		ckbBuon.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBuon.Image = Class155.E1938320;
		ckbBuon.Location = new System.Drawing.Point(222, 1);
		ckbBuon.Name = "ckbBuon";
		ckbBuon.Size = new System.Drawing.Size(40, 30);
		ckbBuon.TabIndex = 178;
		ckbBuon.UseVisualStyleBackColor = true;
		ckbWow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWow.Image = Class155.Bitmap_181;
		ckbWow.Location = new System.Drawing.Point(178, 1);
		ckbWow.Name = "ckbWow";
		ckbWow.Size = new System.Drawing.Size(40, 30);
		ckbWow.TabIndex = 177;
		ckbWow.UseVisualStyleBackColor = true;
		B822D80F.Cursor = System.Windows.Forms.Cursors.Hand;
		B822D80F.Image = Class155.E982D419;
		B822D80F.Location = new System.Drawing.Point(134, 1);
		B822D80F.Name = "ckbHaha";
		B822D80F.Size = new System.Drawing.Size(40, 30);
		B822D80F.TabIndex = 176;
		B822D80F.UseVisualStyleBackColor = true;
		C90C59AE.Cursor = System.Windows.Forms.Cursors.Hand;
		C90C59AE.Image = Class155.Bitmap_20;
		C90C59AE.Location = new System.Drawing.Point(90, 1);
		C90C59AE.Name = "ckbThuong";
		C90C59AE.Size = new System.Drawing.Size(40, 30);
		C90C59AE.TabIndex = 175;
		C90C59AE.UseVisualStyleBackColor = true;
		ckbTym.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTym.Image = Class155.AB95A212;
		ckbTym.Location = new System.Drawing.Point(46, 1);
		ckbTym.Name = "ckbTym";
		ckbTym.Size = new System.Drawing.Size(40, 30);
		ckbTym.TabIndex = 174;
		ckbTym.UseVisualStyleBackColor = true;
		A09549A3.Checked = true;
		A09549A3.CheckState = System.Windows.Forms.CheckState.Checked;
		A09549A3.Cursor = System.Windows.Forms.Cursors.Hand;
		A09549A3.Image = Class155.Bitmap_166;
		A09549A3.Location = new System.Drawing.Point(2, 1);
		A09549A3.Name = "ckbLike";
		A09549A3.Size = new System.Drawing.Size(40, 30);
		A09549A3.TabIndex = 173;
		A09549A3.UseVisualStyleBackColor = true;
		BA31DD31.Controls.Add(C38F62A7);
		BA31DD31.Controls.Add(radioButton4);
		BA31DD31.Location = new System.Drawing.Point(67, 300);
		BA31DD31.Name = "panel7";
		BA31DD31.Size = new System.Drawing.Size(200, 43);
		BA31DD31.TabIndex = 43;
		C38F62A7.AutoSize = true;
		C38F62A7.Checked = true;
		C38F62A7.Cursor = System.Windows.Forms.Cursors.Hand;
		C38F62A7.Location = new System.Drawing.Point(3, 2);
		C38F62A7.Name = "radioButton3";
		C38F62A7.Size = new System.Drawing.Size(201, 20);
		C38F62A7.TabIndex = 3;
		C38F62A7.TabStop = true;
		C38F62A7.Text = "Comment theo thứ tự nội dung";
		C38F62A7.UseVisualStyleBackColor = true;
		radioButton4.AutoSize = true;
		radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton4.Location = new System.Drawing.Point(3, 23);
		radioButton4.Name = "radioButton4";
		radioButton4.Size = new System.Drawing.Size(200, 20);
		radioButton4.TabIndex = 3;
		radioButton4.Text = "Comment ngẫu nhiên nội dung";
		radioButton4.UseVisualStyleBackColor = true;
		label26.AutoSize = true;
		label26.Location = new System.Drawing.Point(4, 302);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(64, 16);
		label26.TabIndex = 2;
		label26.Text = "Tùy chọn:";
		ckbTuDongThamGiaNhom.AutoSize = true;
		ckbTuDongThamGiaNhom.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongThamGiaNhom.Location = new System.Drawing.Point(320, 445);
		ckbTuDongThamGiaNhom.Name = "ckbTuDongThamGiaNhom";
		ckbTuDongThamGiaNhom.Size = new System.Drawing.Size(286, 20);
		ckbTuDongThamGiaNhom.TabIndex = 167;
		ckbTuDongThamGiaNhom.Text = "Tự động tham gia nhóm (Nếu chưa tham gia)";
		ckbTuDongThamGiaNhom.UseVisualStyleBackColor = true;
		ckbTuDongThamGiaNhom.Visible = false;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(nudBoQuaTo);
		panel2.Controls.Add(B3128014);
		panel2.Controls.Add(label8);
		panel2.Controls.Add(label11);
		panel2.Location = new System.Drawing.Point(97, 410);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(191, 29);
		panel2.TabIndex = 166;
		nudBoQuaTo.Location = new System.Drawing.Point(72, 2);
		nudBoQuaTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudBoQuaTo.Name = "nudBoQuaTo";
		nudBoQuaTo.Size = new System.Drawing.Size(35, 23);
		nudBoQuaTo.TabIndex = 40;
		B3128014.Location = new System.Drawing.Point(2, 2);
		B3128014.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		B3128014.Name = "nudBoQuaFrom";
		B3128014.Size = new System.Drawing.Size(35, 23);
		B3128014.TabIndex = 39;
		label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(39, 4);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(29, 16);
		label8.TabIndex = 42;
		label8.Text = ">";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(113, 4);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(73, 16);
		label11.TabIndex = 41;
		label11.Text = "bài viết đầu";
		ckbBoQua.AutoSize = true;
		ckbBoQua.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBoQua.Location = new System.Drawing.Point(31, 414);
		ckbBoQua.Name = "ckbBoQua";
		ckbBoQua.Size = new System.Drawing.Size(70, 20);
		ckbBoQua.TabIndex = 164;
		ckbBoQua.Text = "Bỏ qua:";
		ckbBoQua.UseVisualStyleBackColor = true;
		ckbBoQua.CheckedChanged += new System.EventHandler(ckbBoQua_CheckedChanged);
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(txtAnh);
		plAnh.Controls.Add(label12);
		plAnh.Enabled = false;
		plAnh.Location = new System.Drawing.Point(320, 408);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(313, 31);
		plAnh.TabIndex = 162;
		txtAnh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtAnh.Location = new System.Drawing.Point(90, 3);
		txtAnh.Name = "txtAnh";
		txtAnh.Size = new System.Drawing.Size(218, 23);
		txtAnh.TabIndex = 159;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(3, 6);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(73, 16);
		label12.TabIndex = 158;
		label12.Text = "Folder ảnh:";
		ckbSendAnh.AutoSize = true;
		ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSendAnh.Location = new System.Drawing.Point(320, 385);
		ckbSendAnh.Name = "ckbSendAnh";
		ckbSendAnh.Size = new System.Drawing.Size(103, 20);
		ckbSendAnh.TabIndex = 161;
		ckbSendAnh.Text = "Bình luận ảnh";
		ckbSendAnh.UseVisualStyleBackColor = true;
		ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
		E00EBA9D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E00EBA9D.Location = new System.Drawing.Point(31, 212);
		E00EBA9D.Name = "txtUid";
		E00EBA9D.Size = new System.Drawing.Size(257, 167);
		E00EBA9D.TabIndex = 117;
		E00EBA9D.Text = "";
		E00EBA9D.WordWrap = false;
		E00EBA9D.TextChanged += new System.EventHandler(E00EBA9D_TextChanged);
		label49.AutoSize = true;
		label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label49.Location = new System.Drawing.Point(27, 81);
		label49.Name = "label49";
		label49.Size = new System.Drawing.Size(79, 16);
		label49.TabIndex = 92;
		label49.Text = "Sô\u0301 lươ\u0323ng ID:";
		nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidFrom.Location = new System.Drawing.Point(135, 79);
		nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
		nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidFrom.TabIndex = 1;
		nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label19.Location = new System.Drawing.Point(27, 110);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(89, 16);
		label19.TabIndex = 101;
		label19.Text = "Sô\u0301 ba\u0300i viết/ID:";
		nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidTo.Location = new System.Drawing.Point(232, 79);
		nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidTo.Name = "nudSoLuongUidTo";
		nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidTo.TabIndex = 2;
		nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		AFA74E1B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AFA74E1B.Location = new System.Drawing.Point(197, 81);
		AFA74E1B.Name = "label66";
		AFA74E1B.Size = new System.Drawing.Size(29, 16);
		AFA74E1B.TabIndex = 105;
		AFA74E1B.Text = ">";
		AFA74E1B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ADB0AA3A.AutoSize = true;
		ADB0AA3A.Cursor = System.Windows.Forms.Cursors.Hand;
		ADB0AA3A.Location = new System.Drawing.Point(320, 141);
		ADB0AA3A.Name = "ckbComment";
		ADB0AA3A.Size = new System.Drawing.Size(127, 20);
		ADB0AA3A.TabIndex = 9;
		ADB0AA3A.Text = "Bi\u0300nh luâ\u0323n văn bản";
		ADB0AA3A.UseVisualStyleBackColor = true;
		ADB0AA3A.CheckedChanged += new System.EventHandler(ADB0AA3A_CheckedChanged);
		A404060A.AutoSize = true;
		A404060A.Cursor = System.Windows.Forms.Cursors.Hand;
		A404060A.Location = new System.Drawing.Point(31, 445);
		A404060A.Name = "ckbKhongCommentTrungBaiCu";
		A404060A.Size = new System.Drawing.Size(190, 20);
		A404060A.TabIndex = 8;
		A404060A.Text = "Không comment trùng bài cũ";
		A404060A.UseVisualStyleBackColor = true;
		DCBA7C9B.AutoSize = true;
		DCBA7C9B.Cursor = System.Windows.Forms.Cursors.Hand;
		DCBA7C9B.Location = new System.Drawing.Point(31, 386);
		DCBA7C9B.Name = "ckbTuDongXoaUid";
		DCBA7C9B.Size = new System.Drawing.Size(190, 20);
		DCBA7C9B.TabIndex = 8;
		DCBA7C9B.Text = "Tự động xóa ID đã tương tác";
		DCBA7C9B.UseVisualStyleBackColor = true;
		ckbShareWall.AutoSize = true;
		ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShareWall.Location = new System.Drawing.Point(553, 141);
		ckbShareWall.Name = "ckbShareWall";
		ckbShareWall.Size = new System.Drawing.Size(87, 20);
		ckbShareWall.TabIndex = 8;
		ckbShareWall.Text = "Share wall";
		ckbShareWall.UseVisualStyleBackColor = true;
		C5325A9B.AutoSize = true;
		C5325A9B.Cursor = System.Windows.Forms.Cursors.Hand;
		C5325A9B.Location = new System.Drawing.Point(321, 80);
		C5325A9B.Name = "ckbInteract";
		C5325A9B.Size = new System.Drawing.Size(99, 20);
		C5325A9B.TabIndex = 7;
		C5325A9B.Text = "Thả cảm xúc";
		C5325A9B.UseVisualStyleBackColor = true;
		C5325A9B.CheckedChanged += new System.EventHandler(BF9A388F);
		E5174B16.Location = new System.Drawing.Point(232, 137);
		E5174B16.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		E5174B16.Name = "nudDelayTo";
		E5174B16.Size = new System.Drawing.Size(56, 23);
		E5174B16.TabIndex = 6;
		B92E4433.Location = new System.Drawing.Point(232, 108);
		B92E4433.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		B92E4433.Name = "nudSoLuongBaiVietTo";
		B92E4433.Size = new System.Drawing.Size(56, 23);
		B92E4433.TabIndex = 4;
		nudDelayFrom.Location = new System.Drawing.Point(135, 137);
		nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 5;
		nudSoLuongBaiVietFrom.Location = new System.Drawing.Point(135, 108);
		nudSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongBaiVietFrom.Name = "nudSoLuongBaiVietFrom";
		nudSoLuongBaiVietFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongBaiVietFrom.TabIndex = 3;
		BC9F362C.Location = new System.Drawing.Point(135, 50);
		BC9F362C.Name = "txtTenHanhDong";
		BC9F362C.Size = new System.Drawing.Size(153, 23);
		BC9F362C.TabIndex = 0;
		C91A3304.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C91A3304.Location = new System.Drawing.Point(197, 139);
		C91A3304.Name = "label7";
		C91A3304.Size = new System.Drawing.Size(29, 16);
		C91A3304.TabIndex = 38;
		C91A3304.Text = ">";
		C91A3304.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(197, 110);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(29, 16);
		label3.TabIndex = 37;
		label3.Text = ">";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CDA35C1D.AutoSize = true;
		CDA35C1D.Location = new System.Drawing.Point(27, 139);
		CDA35C1D.Name = "label5";
		CDA35C1D.Size = new System.Drawing.Size(87, 16);
		CDA35C1D.TabIndex = 34;
		CDA35C1D.Text = "Gia\u0303n ca\u0301ch (s):";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(27, 53);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(98, 16);
		label1.TabIndex = 31;
		label1.Text = "Tên ha\u0300nh đô\u0323ng:";
		C53C113E.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C53C113E.BackColor = System.Drawing.Color.Maroon;
		C53C113E.Cursor = System.Windows.Forms.Cursors.Hand;
		C53C113E.FlatAppearance.BorderSize = 0;
		C53C113E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C53C113E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C53C113E.ForeColor = System.Drawing.Color.White;
		C53C113E.Location = new System.Drawing.Point(310, 476);
		C53C113E.Name = "btnCancel";
		C53C113E.Size = new System.Drawing.Size(92, 29);
		C53C113E.TabIndex = 12;
		C53C113E.Text = "Đóng";
		C53C113E.UseVisualStyleBackColor = false;
		C53C113E.Click += new System.EventHandler(EE1E383E);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(203, 476);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 11;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(C19870B4);
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
		bunifuCards1.Size = new System.Drawing.Size(663, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(666, 518);
		base.Controls.Add(A08AFD03);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDSpamBaiViet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDSpamBaiViet_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)E39FB6B8).EndInit();
		A08AFD03.ResumeLayout(false);
		A08AFD03.PerformLayout();
		C2B7F600.ResumeLayout(false);
		C2B7F600.PerformLayout();
		plEditComment.ResumeLayout(false);
		plEditComment.PerformLayout();
		((System.ComponentModel.ISupportInitialize)E53AA4B4).EndInit();
		((System.ComponentModel.ISupportInitialize)F4974C9D).EndInit();
		plInteract.ResumeLayout(false);
		plInteract.PerformLayout();
		BA31DD31.ResumeLayout(false);
		BA31DD31.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudBoQuaTo).EndInit();
		((System.ComponentModel.ISupportInitialize)B3128014).EndInit();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
		((System.ComponentModel.ISupportInitialize)E5174B16).EndInit();
		((System.ComponentModel.ISupportInitialize)B92E4433).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
