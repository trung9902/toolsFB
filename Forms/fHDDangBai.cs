using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fHDDangBai : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool F19BFDB2;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel F0943083;

	internal TextBox EB1EDC91;

	internal Label CC864295;

	internal Button C4023429;

	internal Button btnAdd;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button button1;

	internal PictureBox EA2147A1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal Label label20;

	internal Label label15;

	internal Panel D3247C16;

	internal Label DB14C636;

	internal NumericUpDown nudSoLuongAnhTo;

	internal Label label2;

	internal NumericUpDown nudSoLuongAnhFrom;

	internal Label label10;

	internal TextBox txtPathAnh;

	internal CheckBox A90CC304;

	internal CheckBox ckbUseBackground;

	internal CheckBox ckbAnh;

	internal CheckBox D91633AC;

	internal CheckBox A098CC81;

	internal GroupBox grTuyChon;

	internal Panel plDangBaiLenPage;

	internal Label E4803489;

	internal NumericUpDown C69CBF1F;

	internal Label label23;

	internal NumericUpDown D105C48A;

	internal Panel plDangBaiLenNhom;

	internal CheckBox A137D9AD;

	internal CheckBox ckbUuTienNhomNhieuThanhVien;

	internal LinkLabel BF2567A4;

	internal CheckBox ckbOnlyDangNhomKhongKiemDuyet;

	internal Panel A7A9B280;

	internal Panel plTuNhap;

	internal RichTextBox C3AEDB1B;

	internal CheckBox F4999C2D;

	internal RadioButton rbTuNhap;

	internal RadioButton rbRandom;

	internal Label label12;

	internal NumericUpDown nudCountGroupTo;

	internal CheckBox ckbTuongTac;

	internal NumericUpDown nudCountGroupFrom;

	internal Label label24;

	internal Label label26;

	internal CheckBox DF303181;

	internal CheckBox ckbDangBaiLenNhom;

	internal CheckBox ckbDangBaiLenTuong;

	internal Panel EE365911;

	internal ComboBox EB96C086;

	internal Button C30A7833;

	internal RichTextBox DEABC818;

	internal Label D01FA418;

	internal Label lblNoiDung;

	internal Panel plDangBaiLenTuong;

	internal Label label4;

	internal NumericUpDown nudCountWallTo;

	internal Label BC0F0CA7;

	internal NumericUpDown nudCountWallFrom;

	internal GroupBox groupBox1;

	internal CheckBox ckbCopyPost;

	internal Panel F9AACA95;

	internal Label lblIdPost;

	internal RichTextBox txtIdPost;

	internal CheckBox ckbThemVaoCuoiNoiDung;

	internal LinkLabel linkLabel2;

	internal RichTextBox EF209413;

	internal Label label6;

	internal CheckBox ckbXoaIdPostDaDung;

	internal CheckBox ckbXoaNoiDung;

	internal CheckBox CF8C19A4;

	internal Panel plNotUseAvatar;

	internal CheckBox ckbXoaHashtag;

	internal LinkLabel BA11D702;

	internal CheckBox BD8D590F;

	internal CheckBox ckbTaoNoiDungAI;

	internal Panel E217C703;

	internal TabControl tabControl1;

	internal TabPage tabCommentText;

	internal TabPage tabCommentAI;

	internal Button btnPrompt;

	internal ComboBox cbbPrompt;

	internal Label label7;

	internal CheckBox ckbAutoDeleteComment;

	internal Button btnDown;

	internal CheckBox ckbTaoNoiDungCopyAI;

	internal Button button2;

	internal Button btnQuanLyNoiDung;

	internal Button btnSoanThaoTo;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return F19BFDB2;
		}
		[CompilerGenerated]
		set
		{
			F19BFDB2 = value;
		}
	}

	public fHDDangBai(string string_3, string string_4 = "")
	{
		InitializeComponent();
		AppIconHelper.SetIcon(this);
		this.KeyPreview = true;
		this.KeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		};
		pnlHeader.Resize += (s, e) =>
		{
			if (button1 != null)
			{
				button1.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
			}
			if (btnMinimize != null)
			{
				btnMinimize.Location = new System.Drawing.Point(pnlHeader.Width - 68, 1);
			}
		};
		Boolean_0 = false;
		string_0 = string_3;
		string_2 = string_4;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_4 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			EB1EDC91.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_4);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			EB1EDC91.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		BD8D590F.Visible = Base.DB801CBD || Base.CF2C3E9B;
		BA11D702.Visible = Base.DB801CBD || Base.CF2C3E9B;
	}

	private void fHDDangBai_Load(object sender, EventArgs e)
	{
		Commom.AttachFolderPicker(txtPathAnh);
		method_0();
		method_1();
		try
		{
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			D91633AC.Checked = gclass4_0.method_3("ckbVanBan");
			DEABC818.Text = gclass4_0.BDB80B23("txtNoiDung");
			EB96C086.SelectedIndex = gclass4_0.method_2("typeNganCach");
			ckbUseBackground.Checked = gclass4_0.method_3("ckbUseBackground");
			ckbXoaNoiDung.Checked = gclass4_0.method_3("ckbXoaNoiDung");
			ckbAutoDeleteComment.Checked = gclass4_0.method_3("ckbAutoDeleteComment");
			ckbTaoNoiDungAI.Checked = gclass4_0.method_3("ckbTaoNoiDungAI");
			try
			{
				cbbPrompt.SelectedValue = gclass4_0.BDB80B23("cbbPrompt");
			}
			catch (Exception)
			{
			}
			ckbAnh.Checked = gclass4_0.method_3("ckbAnh");
			nudSoLuongAnhFrom.Value = gclass4_0.method_2("nudSoLuongAnhFrom", 1);
			nudSoLuongAnhTo.Value = gclass4_0.method_2("nudSoLuongAnhTo", 1);
			A90CC304.Checked = gclass4_0.method_3("ckbUseAvatar");
			txtPathAnh.Text = gclass4_0.BDB80B23("txtPathAnh");
			CF8C19A4.Checked = gclass4_0.method_3("ckbXoaAnh");
			ckbDangBaiLenTuong.Checked = gclass4_0.method_3("ckbDangBaiLenTuong");
			nudCountWallFrom.Value = gclass4_0.method_2("nudCountWallFrom", 1);
			nudCountWallTo.Value = gclass4_0.method_2("nudCountWallTo", 1);
			ckbDangBaiLenNhom.Checked = gclass4_0.method_3("ckbDangBaiLenNhom");
			nudCountGroupFrom.Value = gclass4_0.method_2("nudCountGroupFrom", 1);
			nudCountGroupTo.Value = gclass4_0.method_2("nudCountGroupTo", 1);
			if (gclass4_0.method_2("typePost") == 0)
			{
				rbRandom.Checked = true;
			}
			else
			{
				rbTuNhap.Checked = true;
			}
			C3AEDB1B.Text = gclass4_0.BDB80B23("lstNhomTuNhap");
			F4999C2D.Checked = gclass4_0.method_3("ckbChiDangNhomDaThamGia");
			A098CC81.Checked = gclass4_0.method_3("ckbXoaNhomDaDang");
			ckbOnlyDangNhomKhongKiemDuyet.Checked = gclass4_0.method_3("ckbOnlyDangNhomKhongKiemDuyet");
			ckbUuTienNhomNhieuThanhVien.Checked = gclass4_0.method_3("ckbUuTienNhomNhieuThanhVien");
			A137D9AD.Checked = gclass4_0.method_3("ckbKhongDangTrung");
			ckbTuongTac.Checked = gclass4_0.method_3("ckbTuongTac");
			BD8D590F.Checked = gclass4_0.method_3("ckbTuongTacBaiVietDaDang");
			DF303181.Checked = gclass4_0.method_3("ckbDangBaiLenPage");
			D105C48A.Value = gclass4_0.method_2("nudCountPageFrom", 1);
			C69CBF1F.Value = gclass4_0.method_2("nudCountPageTo", 1);
			ckbCopyPost.Checked = gclass4_0.method_3("ckbCopyPost");
			txtIdPost.Text = gclass4_0.BDB80B23("txtIdPost");
			ckbXoaIdPostDaDung.Checked = gclass4_0.method_3("ckbXoaIdPostDaDung");
			ckbXoaHashtag.Checked = gclass4_0.method_3("ckbXoaHashtag");
			ckbTaoNoiDungCopyAI.Checked = gclass4_0.method_3("ckbTaoNoiDungCopyAI");
			ckbThemVaoCuoiNoiDung.Checked = gclass4_0.method_3("ckbThemVaoCuoiNoiDung");
			EF209413.Text = gclass4_0.BDB80B23("txtNoiDungThemVaoCuoi");
		}
		catch (Exception)
		{
		}
		method_2();
	}

	private void method_0()
	{
		List<string> list_ = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(EB96C086, list_);
	}

	private void method_1()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		List<GClass10> list = GClass9.EC28DF14();
		foreach (GClass10 item in list)
		{
			dictionary.Add(item.String_0.ToString(), item.String_1.ToString());
		}
		Commom.smethod_24(cbbPrompt, dictionary);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		string text = EB1EDC91.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		if (ckbAnh.Checked && !A90CC304.Checked)
		{
			string textPathAnh = txtPathAnh.Text.Trim();
			if (string.IsNullOrWhiteSpace(textPathAnh) || !Directory.Exists(textPathAnh))
			{
				MsBoxHelper.Show("Thư mục ảnh không tồn tại! Vui lòng chọn lại.", 3);
				txtPathAnh.Focus();
				return;
			}
			if (!Commom.ValidateMediaFolder(textPathAnh, out int mediaCount, out string _) || mediaCount == 0)
			{
				MsBoxHelper.Show("Thư mục đã chọn không có file ảnh/video nào! Vui lòng kiểm tra lại.", 3);
				txtPathAnh.Focus();
				return;
			}
		}
		gclass4_0.method_4("nudDelayFrom", nudDelayFrom.Value);
		gclass4_0.method_4("nudDelayTo", nudDelayTo.Value);
		gclass4_0.method_4("ckbVanBan", D91633AC.Checked);
		gclass4_0.method_4("txtNoiDung", DEABC818.Text.Trim());
		gclass4_0.method_4("typeNganCach", EB96C086.SelectedIndex);
		gclass4_0.method_4("ckbXoaNoiDung", ckbXoaNoiDung.Checked);
		gclass4_0.method_4("ckbAutoDeleteComment", ckbAutoDeleteComment.Checked);
		gclass4_0.method_4("ckbTaoNoiDungAI", ckbTaoNoiDungAI.Checked);
		gclass4_0.method_4("cbbPrompt", cbbPrompt.SelectedValue ?? "");
		gclass4_0.method_4("ckbUseBackground", ckbUseBackground.Checked);
		gclass4_0.method_4("ckbAnh", ckbAnh.Checked);
		gclass4_0.method_4("nudSoLuongAnhFrom", nudSoLuongAnhFrom.Value);
		gclass4_0.method_4("nudSoLuongAnhTo", nudSoLuongAnhTo.Value);
		gclass4_0.method_4("ckbUseAvatar", A90CC304.Checked);
		gclass4_0.method_4("txtPathAnh", txtPathAnh.Text.Trim());
		gclass4_0.method_4("ckbXoaAnh", CF8C19A4.Checked);
		gclass4_0.method_4("ckbDangBaiLenTuong", ckbDangBaiLenTuong.Checked);
		gclass4_0.method_4("nudCountWallFrom", nudCountWallFrom.Value);
		gclass4_0.method_4("nudCountWallTo", nudCountWallTo.Value);
		gclass4_0.method_4("ckbDangBaiLenNhom", ckbDangBaiLenNhom.Checked);
		gclass4_0.method_4("nudCountGroupFrom", nudCountGroupFrom.Value);
		gclass4_0.method_4("nudCountGroupTo", nudCountGroupTo.Value);
		int num = 0;
		if (rbTuNhap.Checked)
		{
			num = 1;
		}
		gclass4_0.method_4("typePost", num);
		gclass4_0.method_4("lstNhomTuNhap", C3AEDB1B.Text);
		gclass4_0.method_4("ckbChiDangNhomDaThamGia", F4999C2D.Checked);
		gclass4_0.method_4("ckbXoaNhomDaDang", A098CC81.Checked);
		gclass4_0.method_4("ckbOnlyDangNhomKhongKiemDuyet", ckbOnlyDangNhomKhongKiemDuyet.Checked);
		gclass4_0.method_4("ckbUuTienNhomNhieuThanhVien", ckbUuTienNhomNhieuThanhVien.Checked);
		gclass4_0.method_4("ckbKhongDangTrung", A137D9AD.Checked);
		gclass4_0.method_4("ckbTuongTac", ckbTuongTac.Checked);
		gclass4_0.method_4("ckbTuongTacBaiVietDaDang", BD8D590F.Checked);
		gclass4_0.method_4("ckbDangBaiLenPage", DF303181.Checked);
		gclass4_0.method_4("nudCountPageFrom", D105C48A.Value);
		gclass4_0.method_4("nudCountPageTo", C69CBF1F.Value);
		gclass4_0.method_4("ckbCopyPost", ckbCopyPost.Checked);
		gclass4_0.method_4("txtIdPost", txtIdPost.Text.Trim());
		gclass4_0.method_4("ckbXoaIdPostDaDung", ckbXoaIdPostDaDung.Checked);
		gclass4_0.method_4("ckbXoaHashtag", ckbXoaHashtag.Checked);
		gclass4_0.method_4("ckbTaoNoiDungCopyAI", ckbTaoNoiDungCopyAI.Checked);
		gclass4_0.method_4("ckbThemVaoCuoiNoiDung", ckbThemVaoCuoiNoiDung.Checked);
		gclass4_0.method_4("txtNoiDungThemVaoCuoi", EF209413.Text.Trim());
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

	private void A9A77939(object sender, EventArgs e)
	{
		Close();
	}

	private void BEBAF9A1(object sender, PaintEventArgs e)
	{
		if (F0943083.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.FromArgb(37, 99, 235), 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, F0943083.ClientSize.Width - num, F0943083.ClientSize.Height - num));
		}
	}

	private void method_2()
	{
		DB0CEABF(null, null);
		DF303181_CheckedChanged(null, null);
		D91633AC_CheckedChanged(null, null);
		F6B91017(null, null);
		A90CC304_CheckedChanged(null, null);
		rbTuNhap_CheckedChanged(null, null);
		CEA28104(null, null);
		EEB17327(null, null);
		ckbDangBaiLenTuong_CheckedChanged(null, null);
		A1204625(null, null);
		D5313798(null, null);
	}

	private void D91633AC_CheckedChanged(object sender, EventArgs e)
	{
		EE365911.Enabled = D91633AC.Checked;
		F227153C(null, null);
	}

	private void F6B91017(object sender, EventArgs e)
	{
		D3247C16.Enabled = ckbAnh.Checked;
		if (ckbAnh.Checked)
		{
			ckbUseBackground.Checked = false;
		}
	}

	private void DEABC818_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(DEABC818, lblNoiDung, EB96C086.SelectedIndex);
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fHuongDanRandom());
	}

	private void C30A7833_Click(object sender, EventArgs e)
	{
		if (EB96C086.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		DEABC818.Focus();
	}

	private void EB96C086_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(DEABC818, lblNoiDung, EB96C086.SelectedIndex);
	}

	private void btnQuanLyNoiDung_Click(object sender, EventArgs e)
	{
		fQuanLyNoiDung f = new fQuanLyNoiDung();
		if (f.ShowDialog() == DialogResult.OK)
		{
			if (!string.IsNullOrEmpty(f.ResultContent))
			{
				DEABC818.Text = f.ResultContent;
				if (f.ResultIsMultiPost)
				{
					EB96C086.SelectedIndex = 1;
				}
				Commom.A9BCAF05(DEABC818, lblNoiDung, EB96C086.SelectedIndex);
			}
		}
	}

	private void btnSoanThaoTo_Click(object sender, EventArgs e)
	{
		fSoanThaoNoiDung f = new fSoanThaoNoiDung(DEABC818.Text, EB96C086.SelectedIndex);
		if (f.ShowDialog() == DialogResult.OK)
		{
			DEABC818.Text = f.Content;
			if (f.IsMultiPost)
			{
				EB96C086.SelectedIndex = 1;
			}
			Commom.A9BCAF05(DEABC818, lblNoiDung, EB96C086.SelectedIndex);
		}
	}

	private void DB0CEABF(object sender, EventArgs e)
	{
		plDangBaiLenNhom.Enabled = ckbDangBaiLenNhom.Checked;
	}

	private void rbTuNhap_CheckedChanged(object sender, EventArgs e)
	{
		plTuNhap.Enabled = rbTuNhap.Checked;
	}

	private void CEA49C8C(object sender, EventArgs e)
	{
		Commom.FE214EB5(sender as RichTextBox, rbTuNhap);
	}

	private void B803CB1A(object sender, EventArgs e)
	{
	}

	private void CEA28104(object sender, EventArgs e)
	{
		BF2567A4.Enabled = ckbTuongTac.Checked;
	}

	private void B932E583(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fTuongTacProfile(gclass4_0, "Cấu hình Tương tác Nhóm trước khi đăng"));
	}

	private void DF303181_CheckedChanged(object sender, EventArgs e)
	{
		plDangBaiLenPage.Enabled = DF303181.Checked;
	}

	private void A90CC304_CheckedChanged(object sender, EventArgs e)
	{
		plNotUseAvatar.Enabled = !A90CC304.Checked;
	}

	private void F227153C(object sender, EventArgs e)
	{
		if (D91633AC.Checked && ckbUseBackground.Checked)
		{
			ckbAnh.Checked = false;
		}
	}

	private void ckbDangBaiLenTuong_CheckedChanged(object sender, EventArgs e)
	{
		plDangBaiLenTuong.Enabled = ckbDangBaiLenTuong.Checked;
	}

	private void txtIdPost_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdPost, lblIdPost);
	}

	private void A1204625(object sender, EventArgs e)
	{
		F9AACA95.Enabled = ckbCopyPost.Checked;
		if (ckbCopyPost.Checked)
		{
			D91633AC.Checked = false;
			ckbAnh.Checked = false;
		}
		D91633AC.Enabled = !ckbCopyPost.Checked;
		ckbAnh.Enabled = !ckbCopyPost.Checked;
	}

	private void D5313798(object sender, EventArgs e)
	{
		EF209413.Enabled = ckbThemVaoCuoiNoiDung.Checked;
	}

	private void D3247C16_Paint(object sender, PaintEventArgs e)
	{
	}

	private void BA11D702_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Commom.smethod_35(new fTuongTacBaiViet(gclass4_0));
	}

	private void EEB17327(object sender, EventArgs e)
	{
		BA11D702.Enabled = BD8D590F.Checked;
	}

	private void btnPrompt_Click(object sender, EventArgs e)
	{
		int selectedIndex = cbbPrompt.SelectedIndex;
		Commom.smethod_35(new fCauHinhAI(cbbPrompt.SelectedValue?.ToString()));
		method_1();
		if (selectedIndex != -1 && selectedIndex < cbbPrompt.Items.Count)
		{
			cbbPrompt.SelectedIndex = selectedIndex;
		}
	}

	private void FB2A0421(object sender, EventArgs e)
	{
		tabControl1.SelectedTab = (ckbTaoNoiDungAI.Checked ? tabCommentAI : tabCommentText);
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		grTuyChon.Height = 477;
		btnDown.Visible = false;
	}

	private void E3A7C61E(object sender, EventArgs e)
	{
		if (ckbTaoNoiDungCopyAI.Checked)
		{
			Commom.smethod_35(new fChonPrompt(gclass4_0, "cbbPromptCopy"));
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		string text = Commom.smethod_96(txtPathAnh.Text.Trim());
		if (!string.IsNullOrEmpty(text))
		{
			txtPathAnh.Text = text;
			Commom.ShowFolderMediaTooltip(txtPathAnh, text);
		}
	}

	protected override void Dispose(bool AE841EA1)
	{
		if (AE841EA1 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(AE841EA1);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDDangBai));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		EA2147A1 = new System.Windows.Forms.PictureBox();
		F0943083 = new System.Windows.Forms.Panel();
		groupBox1 = new System.Windows.Forms.GroupBox();
		ckbCopyPost = new System.Windows.Forms.CheckBox();
		D91633AC = new System.Windows.Forms.CheckBox();
		F9AACA95 = new System.Windows.Forms.Panel();
		ckbXoaHashtag = new System.Windows.Forms.CheckBox();
		ckbXoaIdPostDaDung = new System.Windows.Forms.CheckBox();
		ckbTaoNoiDungCopyAI = new System.Windows.Forms.CheckBox();
		ckbThemVaoCuoiNoiDung = new System.Windows.Forms.CheckBox();
		lblIdPost = new System.Windows.Forms.Label();
		linkLabel2 = new System.Windows.Forms.LinkLabel();
		EF209413 = new System.Windows.Forms.RichTextBox();
		txtIdPost = new System.Windows.Forms.RichTextBox();
		label6 = new System.Windows.Forms.Label();
		EE365911 = new System.Windows.Forms.Panel();
		ckbUseBackground = new System.Windows.Forms.CheckBox();
		E217C703 = new System.Windows.Forms.Panel();
		tabControl1 = new System.Windows.Forms.TabControl();
		tabCommentText = new System.Windows.Forms.TabPage();
		DEABC818 = new System.Windows.Forms.RichTextBox();
		ckbXoaNoiDung = new System.Windows.Forms.CheckBox();
		D01FA418 = new System.Windows.Forms.Label();
		EB96C086 = new System.Windows.Forms.ComboBox();
		C30A7833 = new System.Windows.Forms.Button();
		btnQuanLyNoiDung = new System.Windows.Forms.Button();
		btnSoanThaoTo = new System.Windows.Forms.Button();
		tabCommentAI = new System.Windows.Forms.TabPage();
		btnPrompt = new System.Windows.Forms.Button();
		cbbPrompt = new System.Windows.Forms.ComboBox();
		label7 = new System.Windows.Forms.Label();
		ckbAutoDeleteComment = new System.Windows.Forms.CheckBox();
		ckbTaoNoiDungAI = new System.Windows.Forms.CheckBox();
		lblNoiDung = new System.Windows.Forms.Label();
		ckbAnh = new System.Windows.Forms.CheckBox();
		D3247C16 = new System.Windows.Forms.Panel();
		plNotUseAvatar = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		txtPathAnh = new System.Windows.Forms.TextBox();
		DB14C636 = new System.Windows.Forms.Label();
		nudSoLuongAnhFrom = new System.Windows.Forms.NumericUpDown();
		CF8C19A4 = new System.Windows.Forms.CheckBox();
		label10 = new System.Windows.Forms.Label();
		nudSoLuongAnhTo = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		A90CC304 = new System.Windows.Forms.CheckBox();
		grTuyChon = new System.Windows.Forms.GroupBox();
		plDangBaiLenTuong = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		nudCountWallTo = new System.Windows.Forms.NumericUpDown();
		BC0F0CA7 = new System.Windows.Forms.Label();
		nudCountWallFrom = new System.Windows.Forms.NumericUpDown();
		plDangBaiLenPage = new System.Windows.Forms.Panel();
		E4803489 = new System.Windows.Forms.Label();
		C69CBF1F = new System.Windows.Forms.NumericUpDown();
		label23 = new System.Windows.Forms.Label();
		D105C48A = new System.Windows.Forms.NumericUpDown();
		plDangBaiLenNhom = new System.Windows.Forms.Panel();
		btnDown = new System.Windows.Forms.Button();
		A137D9AD = new System.Windows.Forms.CheckBox();
		ckbUuTienNhomNhieuThanhVien = new System.Windows.Forms.CheckBox();
		BF2567A4 = new System.Windows.Forms.LinkLabel();
		ckbOnlyDangNhomKhongKiemDuyet = new System.Windows.Forms.CheckBox();
		A7A9B280 = new System.Windows.Forms.Panel();
		plTuNhap = new System.Windows.Forms.Panel();
		C3AEDB1B = new System.Windows.Forms.RichTextBox();
		F4999C2D = new System.Windows.Forms.CheckBox();
		A098CC81 = new System.Windows.Forms.CheckBox();
		rbTuNhap = new System.Windows.Forms.RadioButton();
		rbRandom = new System.Windows.Forms.RadioButton();
		label12 = new System.Windows.Forms.Label();
		nudCountGroupTo = new System.Windows.Forms.NumericUpDown();
		ckbTuongTac = new System.Windows.Forms.CheckBox();
		nudCountGroupFrom = new System.Windows.Forms.NumericUpDown();
		label24 = new System.Windows.Forms.Label();
		label26 = new System.Windows.Forms.Label();
		BA11D702 = new System.Windows.Forms.LinkLabel();
		DF303181 = new System.Windows.Forms.CheckBox();
		ckbDangBaiLenNhom = new System.Windows.Forms.CheckBox();
		ckbDangBaiLenTuong = new System.Windows.Forms.CheckBox();
		BD8D590F = new System.Windows.Forms.CheckBox();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		label20 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		btnAdd = new System.Windows.Forms.Button();
		EB1EDC91 = new System.Windows.Forms.TextBox();
		CC864295 = new System.Windows.Forms.Label();
		C4023429 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)EA2147A1).BeginInit();
		F0943083.SuspendLayout();
		groupBox1.SuspendLayout();
		F9AACA95.SuspendLayout();
		EE365911.SuspendLayout();
		E217C703.SuspendLayout();
		tabControl1.SuspendLayout();
		tabCommentText.SuspendLayout();
		tabCommentAI.SuspendLayout();
		D3247C16.SuspendLayout();
		plNotUseAvatar.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).BeginInit();
		grTuyChon.SuspendLayout();
		plDangBaiLenTuong.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountWallTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountWallFrom).BeginInit();
		plDangBaiLenPage.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)C69CBF1F).BeginInit();
		((System.ComponentModel.ISupportInitialize)D105C48A).BeginInit();
		plDangBaiLenNhom.SuspendLayout();
		A7A9B280.SuspendLayout();
		plTuNhap.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountGroupTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(978, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Đăng bài";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(btnMinimize);
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(EA2147A1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(978, 31);
		pnlHeader.TabIndex = 9;
		// Minimize Button
		System.Drawing.Image iconMin = AppIconHelper.GetIcon("min_window.png", 24, 24);
		btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMinimize.FlatAppearance.BorderSize = 0;
		btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnMinimize.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		btnMinimize.Image = iconMin;
		btnMinimize.Text = iconMin == null ? "—" : "";
		btnMinimize.Location = new System.Drawing.Point(913, 1);
		btnMinimize.Name = "btnMinimize";
		btnMinimize.Size = new System.Drawing.Size(30, 30);
		btnMinimize.TabIndex = 78;
		btnMinimize.UseVisualStyleBackColor = true;
		btnMinimize.Click += (s, e) => { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; };
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		button1.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		button1.Text = iconClose == null ? "✕" : "";
		button1.Location = new System.Drawing.Point(947, 1);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(30, 30);
		button1.TabIndex = 0;
		button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		EA2147A1.Cursor = System.Windows.Forms.Cursors.Default;
		EA2147A1.Image = Class155.DD225F0D;
		EA2147A1.Location = new System.Drawing.Point(3, 2);
		EA2147A1.Name = "pictureBox1";
		EA2147A1.Size = new System.Drawing.Size(34, 27);
		EA2147A1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		EA2147A1.TabIndex = 76;
		EA2147A1.TabStop = false;
		pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
		pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
		pnlTopAccent.Height = 4;
		pnlTopAccent.Name = "pnlTopAccent";
		pnlTopAccent.TabIndex = 99;
		F0943083.BackColor = System.Drawing.Color.White;
		F0943083.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F0943083.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		F0943083.Controls.Add(groupBox1);
		F0943083.Controls.Add(grTuyChon);
		F0943083.Controls.Add(nudDelayTo);
		F0943083.Controls.Add(nudDelayFrom);
		F0943083.Controls.Add(label20);
		F0943083.Controls.Add(label15);
		F0943083.Controls.Add(btnAdd);
		F0943083.Controls.Add(EB1EDC91);
		F0943083.Controls.Add(CC864295);
		F0943083.Controls.Add(C4023429);
		F0943083.Controls.Add(bunifuCards1);
		F0943083.Cursor = System.Windows.Forms.Cursors.Arrow;
		F0943083.Dock = System.Windows.Forms.DockStyle.Fill;
		F0943083.Location = new System.Drawing.Point(0, 0);
		F0943083.Name = "panel1";
		F0943083.Size = new System.Drawing.Size(981, 643);
		F0943083.TabIndex = 0;
		F0943083.Paint += new System.Windows.Forms.PaintEventHandler(BEBAF9A1);
		groupBox1.Controls.Add(ckbCopyPost);
		groupBox1.Controls.Add(D91633AC);
		groupBox1.Controls.Add(F9AACA95);
		groupBox1.Controls.Add(EE365911);
		groupBox1.Controls.Add(ckbAnh);
		groupBox1.Controls.Add(D3247C16);
		groupBox1.Location = new System.Drawing.Point(30, 107);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(600, 477);
		groupBox1.TabIndex = 72;
		groupBox1.TabStop = false;
		groupBox1.Text = "Nội dung";
		ckbCopyPost.AutoSize = true;
		ckbCopyPost.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCopyPost.Location = new System.Drawing.Point(356, 22);
		ckbCopyPost.Name = "ckbCopyPost";
		ckbCopyPost.Size = new System.Drawing.Size(124, 20);
		ckbCopyPost.TabIndex = 66;
		ckbCopyPost.Text = "Sao chép bài viết";
		ckbCopyPost.UseVisualStyleBackColor = true;
		ckbCopyPost.CheckedChanged += new System.EventHandler(A1204625);
		D91633AC.AutoSize = true;
		D91633AC.Cursor = System.Windows.Forms.Cursors.Hand;
		D91633AC.Location = new System.Drawing.Point(9, 22);
		D91633AC.Name = "ckbVanBan";
		D91633AC.Size = new System.Drawing.Size(76, 20);
		D91633AC.TabIndex = 66;
		D91633AC.Text = "Nội dung";
		D91633AC.UseVisualStyleBackColor = true;
		D91633AC.CheckedChanged += new System.EventHandler(D91633AC_CheckedChanged);
		F9AACA95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		F9AACA95.Controls.Add(ckbXoaHashtag);
		F9AACA95.Controls.Add(ckbXoaIdPostDaDung);
		F9AACA95.Controls.Add(ckbTaoNoiDungCopyAI);
		F9AACA95.Controls.Add(ckbThemVaoCuoiNoiDung);
		F9AACA95.Controls.Add(lblIdPost);
		F9AACA95.Controls.Add(linkLabel2);
		F9AACA95.Controls.Add(EF209413);
		F9AACA95.Controls.Add(txtIdPost);
		F9AACA95.Controls.Add(label6);
		F9AACA95.Location = new System.Drawing.Point(356, 45);
		F9AACA95.Name = "plCopyPost";
		F9AACA95.Size = new System.Drawing.Size(236, 426);
		F9AACA95.TabIndex = 71;
		ckbXoaHashtag.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		ckbXoaHashtag.AutoSize = true;
		ckbXoaHashtag.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaHashtag.Location = new System.Drawing.Point(6, 249);
		ckbXoaHashtag.Name = "ckbXoaHashtag";
		ckbXoaHashtag.Size = new System.Drawing.Size(201, 20);
		ckbXoaHashtag.TabIndex = 66;
		ckbXoaHashtag.Text = "Xo\u0301a hashtag co\u0301 trong nô\u0323i dung";
		ckbXoaHashtag.UseVisualStyleBackColor = true;
		ckbXoaHashtag.CheckedChanged += new System.EventHandler(D5313798);
		ckbXoaIdPostDaDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		ckbXoaIdPostDaDung.AutoSize = true;
		ckbXoaIdPostDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaIdPostDaDung.Location = new System.Drawing.Point(6, 225);
		ckbXoaIdPostDaDung.Name = "ckbXoaIdPostDaDung";
		ckbXoaIdPostDaDung.Size = new System.Drawing.Size(158, 20);
		ckbXoaIdPostDaDung.TabIndex = 66;
		ckbXoaIdPostDaDung.Text = "Xóa Id bài viết đã dùng";
		ckbXoaIdPostDaDung.UseVisualStyleBackColor = true;
		ckbXoaIdPostDaDung.CheckedChanged += new System.EventHandler(D5313798);
		ckbTaoNoiDungCopyAI.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		ckbTaoNoiDungCopyAI.AutoSize = true;
		ckbTaoNoiDungCopyAI.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTaoNoiDungCopyAI.Location = new System.Drawing.Point(6, 273);
		ckbTaoNoiDungCopyAI.Name = "ckbTaoNoiDungCopyAI";
		ckbTaoNoiDungCopyAI.Size = new System.Drawing.Size(176, 20);
		ckbTaoNoiDungCopyAI.TabIndex = 186;
		ckbTaoNoiDungCopyAI.Text = "Thay đô\u0309i nô\u0323i dung bă\u0300ng AI";
		ckbTaoNoiDungCopyAI.UseVisualStyleBackColor = true;
		ckbTaoNoiDungCopyAI.Click += new System.EventHandler(E3A7C61E);
		ckbThemVaoCuoiNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		ckbThemVaoCuoiNoiDung.AutoSize = true;
		ckbThemVaoCuoiNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbThemVaoCuoiNoiDung.Location = new System.Drawing.Point(6, 297);
		ckbThemVaoCuoiNoiDung.Name = "ckbThemVaoCuoiNoiDung";
		ckbThemVaoCuoiNoiDung.Size = new System.Drawing.Size(163, 20);
		ckbThemVaoCuoiNoiDung.TabIndex = 66;
		ckbThemVaoCuoiNoiDung.Text = "Thêm vào cuối nội dung";
		ckbThemVaoCuoiNoiDung.UseVisualStyleBackColor = true;
		ckbThemVaoCuoiNoiDung.CheckedChanged += new System.EventHandler(D5313798);
		lblIdPost.AutoSize = true;
		lblIdPost.Location = new System.Drawing.Point(1, 4);
		lblIdPost.Name = "lblIdPost";
		lblIdPost.Size = new System.Drawing.Size(176, 16);
		lblIdPost.TabIndex = 179;
		lblIdPost.Text = "Nhâ\u0323p Id hoă\u0323c link ba\u0300i viê\u0301t (0):";
		linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		linkLabel2.AutoSize = true;
		linkLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
		linkLabel2.Location = new System.Drawing.Point(150, 405);
		linkLabel2.Name = "linkLabel2";
		linkLabel2.Size = new System.Drawing.Size(81, 16);
		linkLabel2.TabIndex = 183;
		linkLabel2.TabStop = true;
		linkLabel2.Text = "Random icon";
		linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
		EF209413.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EF209413.Location = new System.Drawing.Point(6, 318);
		EF209413.Name = "txtNoiDungThemVaoCuoi";
		EF209413.Size = new System.Drawing.Size(224, 85);
		EF209413.TabIndex = 180;
		EF209413.Text = "";
		EF209413.WordWrap = false;
		EF209413.TextChanged += new System.EventHandler(txtIdPost_TextChanged);
		txtIdPost.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIdPost.Location = new System.Drawing.Point(5, 24);
		txtIdPost.Name = "txtIdPost";
		txtIdPost.Size = new System.Drawing.Size(224, 196);
		txtIdPost.TabIndex = 180;
		txtIdPost.Text = "";
		txtIdPost.WordWrap = false;
		txtIdPost.TextChanged += new System.EventHandler(txtIdPost_TextChanged);
		label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(3, 405);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(143, 16);
		label6.TabIndex = 178;
		label6.Text = "(Spin nội dung {a|b|c})";
		EE365911.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		EE365911.Controls.Add(ckbUseBackground);
		EE365911.Controls.Add(E217C703);
		EE365911.Controls.Add(ckbTaoNoiDungAI);
		EE365911.Controls.Add(lblNoiDung);
		EE365911.Location = new System.Drawing.Point(26, 45);
		EE365911.Name = "plVanBan";
		EE365911.Size = new System.Drawing.Size(307, 287);
		EE365911.TabIndex = 71;
		ckbUseBackground.AutoSize = true;
		ckbUseBackground.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUseBackground.Location = new System.Drawing.Point(5, 262);
		ckbUseBackground.Name = "ckbUseBackground";
		ckbUseBackground.Size = new System.Drawing.Size(144, 20);
		ckbUseBackground.TabIndex = 64;
		ckbUseBackground.Text = "Sử dụng Background";
		ckbUseBackground.UseVisualStyleBackColor = true;
		ckbUseBackground.CheckedChanged += new System.EventHandler(F227153C);
		E217C703.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E217C703.Controls.Add(tabControl1);
		E217C703.Controls.Add(ckbAutoDeleteComment);
		E217C703.Location = new System.Drawing.Point(-1, 24);
		E217C703.Name = "plComment";
		E217C703.Size = new System.Drawing.Size(307, 288);
		E217C703.TabIndex = 186;
		tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		tabControl1.Controls.Add(tabCommentText);
		tabControl1.Controls.Add(tabCommentAI);
		tabControl1.Location = new System.Drawing.Point(-7, -6);
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.Size = new System.Drawing.Size(320, 293);
		tabControl1.TabIndex = 198;
		tabCommentText.Controls.Add(DEABC818);
		tabCommentText.Controls.Add(ckbXoaNoiDung);
		tabCommentText.Controls.Add(D01FA418);
		tabCommentText.Controls.Add(EB96C086);
		tabCommentText.Controls.Add(C30A7833);
		tabCommentText.Controls.Add(btnQuanLyNoiDung);
		tabCommentText.Controls.Add(btnSoanThaoTo);
		tabCommentText.Location = new System.Drawing.Point(4, 4);
		tabCommentText.Name = "tabCommentText";
		tabCommentText.Padding = new System.Windows.Forms.Padding(3);
		tabCommentText.Size = new System.Drawing.Size(312, 264);
		tabCommentText.TabIndex = 0;
		tabCommentText.Text = "Comment text";
		tabCommentText.UseVisualStyleBackColor = true;
		DEABC818.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DEABC818.Location = new System.Drawing.Point(8, 1);
		DEABC818.Name = "txtNoiDung";
		DEABC818.Size = new System.Drawing.Size(295, 152);
		DEABC818.TabIndex = 180;
		DEABC818.Text = "";
		DEABC818.WordWrap = true;
		DEABC818.TextChanged += new System.EventHandler(DEABC818_TextChanged);
		DEABC818.DoubleClick += new System.EventHandler(btnSoanThaoTo_Click);
		ckbXoaNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbXoaNoiDung.AutoSize = true;
		ckbXoaNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaNoiDung.Location = new System.Drawing.Point(8, 188);
		ckbXoaNoiDung.Name = "ckbXoaNoiDung";
		ckbXoaNoiDung.Size = new System.Drawing.Size(169, 20);
		ckbXoaNoiDung.TabIndex = 185;
		ckbXoaNoiDung.Text = "Xóa nội dung đã sử dụng";
		ckbXoaNoiDung.UseVisualStyleBackColor = true;
		D01FA418.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		D01FA418.AutoSize = true;
		D01FA418.Location = new System.Drawing.Point(5, 163);
		D01FA418.Name = "label9";
		D01FA418.Size = new System.Drawing.Size(64, 16);
		D01FA418.TabIndex = 181;
		D01FA418.Text = "Tùy chọn:";
		EB96C086.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		EB96C086.Cursor = System.Windows.Forms.Cursors.Hand;
		EB96C086.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		EB96C086.FormattingEnabled = true;
		EB96C086.Location = new System.Drawing.Point(82, 160);
		EB96C086.Name = "cbbTuyChonNoiDung";
		EB96C086.Size = new System.Drawing.Size(190, 24);
		EB96C086.TabIndex = 184;
		EB96C086.SelectedIndexChanged += new System.EventHandler(EB96C086_SelectedIndexChanged);
		C30A7833.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		C30A7833.Cursor = System.Windows.Forms.Cursors.Hand;
		C30A7833.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C30A7833.Location = new System.Drawing.Point(276, 159);
		C30A7833.Name = "btnHuongDanNhapNoiDung";
		C30A7833.Size = new System.Drawing.Size(26, 26);
		C30A7833.TabIndex = 182;
		C30A7833.Text = "?";
		C30A7833.UseVisualStyleBackColor = true;
		C30A7833.Click += new System.EventHandler(C30A7833_Click);
		btnQuanLyNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnQuanLyNoiDung.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnQuanLyNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		btnQuanLyNoiDung.FlatAppearance.BorderSize = 0;
		btnQuanLyNoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnQuanLyNoiDung.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnQuanLyNoiDung.ForeColor = System.Drawing.Color.White;
		btnQuanLyNoiDung.Location = new System.Drawing.Point(8, 214);
		btnQuanLyNoiDung.Name = "btnQuanLyNoiDung";
		btnQuanLyNoiDung.Size = new System.Drawing.Size(142, 30);
		btnQuanLyNoiDung.TabIndex = 186;
		btnQuanLyNoiDung.Text = "Mẫu nội dung";
		btnQuanLyNoiDung.UseVisualStyleBackColor = false;
		btnQuanLyNoiDung.Click += new System.EventHandler(btnQuanLyNoiDung_Click);
		btnSoanThaoTo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnSoanThaoTo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		btnSoanThaoTo.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSoanThaoTo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnSoanThaoTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSoanThaoTo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSoanThaoTo.ForeColor = System.Drawing.Color.Black;
		btnSoanThaoTo.Location = new System.Drawing.Point(155, 214);
		btnSoanThaoTo.Name = "btnSoanThaoTo";
		btnSoanThaoTo.Size = new System.Drawing.Size(147, 30);
		btnSoanThaoTo.TabIndex = 187;
		btnSoanThaoTo.Text = "Mở rộng";
		btnSoanThaoTo.UseVisualStyleBackColor = false;
		btnSoanThaoTo.Click += new System.EventHandler(btnSoanThaoTo_Click);
		tabCommentAI.Controls.Add(btnPrompt);
		tabCommentAI.Controls.Add(cbbPrompt);
		tabCommentAI.Controls.Add(label7);
		tabCommentAI.Location = new System.Drawing.Point(4, 4);
		tabCommentAI.Name = "tabCommentAI";
		tabCommentAI.Padding = new System.Windows.Forms.Padding(3);
		tabCommentAI.Size = new System.Drawing.Size(312, 267);
		tabCommentAI.TabIndex = 1;
		tabCommentAI.Text = "Comment AI";
		tabCommentAI.UseVisualStyleBackColor = true;
		btnPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
		btnPrompt.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnPrompt.Location = new System.Drawing.Point(270, 5);
		btnPrompt.Name = "btnPrompt";
		btnPrompt.Size = new System.Drawing.Size(33, 27);
		btnPrompt.TabIndex = 34;
		btnPrompt.Text = "...";
		btnPrompt.UseVisualStyleBackColor = true;
		btnPrompt.Click += new System.EventHandler(btnPrompt_Click);
		cbbPrompt.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbPrompt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbPrompt.DropDownWidth = 120;
		cbbPrompt.FormattingEnabled = true;
		cbbPrompt.Location = new System.Drawing.Point(97, 6);
		cbbPrompt.Name = "cbbPrompt";
		cbbPrompt.Size = new System.Drawing.Size(167, 24);
		cbbPrompt.TabIndex = 33;
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(6, 9);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(86, 16);
		label7.TabIndex = 32;
		label7.Text = "Cho\u0323n Prompt:";
		ckbAutoDeleteComment.AutoSize = true;
		ckbAutoDeleteComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoDeleteComment.Location = new System.Drawing.Point(7, 209);
		ckbAutoDeleteComment.Name = "ckbAutoDeleteComment";
		ckbAutoDeleteComment.Size = new System.Drawing.Size(169, 20);
		ckbAutoDeleteComment.TabIndex = 8;
		ckbAutoDeleteComment.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		ckbAutoDeleteComment.UseVisualStyleBackColor = true;
		ckbTaoNoiDungAI.AutoSize = true;
		ckbTaoNoiDungAI.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTaoNoiDungAI.Location = new System.Drawing.Point(148, 3);
		ckbTaoNoiDungAI.Name = "ckbTaoNoiDungAI";
		ckbTaoNoiDungAI.Size = new System.Drawing.Size(149, 20);
		ckbTaoNoiDungAI.TabIndex = 186;
		ckbTaoNoiDungAI.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		ckbTaoNoiDungAI.UseVisualStyleBackColor = true;
		ckbTaoNoiDungAI.CheckedChanged += new System.EventHandler(FB2A0421);
		lblNoiDung.AutoSize = true;
		lblNoiDung.Location = new System.Drawing.Point(3, 4);
		lblNoiDung.Name = "lblNoiDung";
		lblNoiDung.Size = new System.Drawing.Size(136, 16);
		lblNoiDung.TabIndex = 179;
		lblNoiDung.Text = "Nội dung đăng bài (0):";
		ckbAnh.AutoSize = true;
		ckbAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAnh.Location = new System.Drawing.Point(9, 338);
		ckbAnh.Name = "ckbAnh";
		ckbAnh.Size = new System.Drawing.Size(48, 20);
		ckbAnh.TabIndex = 65;
		ckbAnh.Text = "Ảnh / Video";
		ckbAnh.UseVisualStyleBackColor = true;
		ckbAnh.CheckedChanged += new System.EventHandler(F6B91017);
		D3247C16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		D3247C16.Controls.Add(plNotUseAvatar);
		D3247C16.Controls.Add(A90CC304);
		D3247C16.Location = new System.Drawing.Point(26, 360);
		D3247C16.Name = "plAnh";
		D3247C16.Size = new System.Drawing.Size(307, 111);
		D3247C16.TabIndex = 69;
		D3247C16.Paint += new System.Windows.Forms.PaintEventHandler(D3247C16_Paint);
		plNotUseAvatar.Controls.Add(button2);
		plNotUseAvatar.Controls.Add(txtPathAnh);
		plNotUseAvatar.Controls.Add(DB14C636);
		plNotUseAvatar.Controls.Add(nudSoLuongAnhFrom);
		plNotUseAvatar.Controls.Add(CF8C19A4);
		plNotUseAvatar.Controls.Add(label10);
		plNotUseAvatar.Controls.Add(nudSoLuongAnhTo);
		plNotUseAvatar.Controls.Add(label2);
		plNotUseAvatar.Location = new System.Drawing.Point(-1, -1);
		plNotUseAvatar.Name = "plNotUseAvatar";
		plNotUseAvatar.Size = new System.Drawing.Size(307, 111);
		plNotUseAvatar.TabIndex = 34;
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.BackgroundImage = null;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Location = new System.Drawing.Point(242, 4);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(60, 25);
		button2.TabIndex = 194;
		button2.Text = "Chọn";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		txtPathAnh.Location = new System.Drawing.Point(115, 5);
		txtPathAnh.Name = "txtPathAnh";
		txtPathAnh.Size = new System.Drawing.Size(122, 23);
		txtPathAnh.TabIndex = 1;
		txtPathAnh.DoubleClick += new System.EventHandler(button2_Click);
		DB14C636.AutoSize = true;
		DB14C636.Location = new System.Drawing.Point(4, 8);
		DB14C636.Name = "label3";
		DB14C636.Size = new System.Drawing.Size(107, 16);
		DB14C636.TabIndex = 0;
		DB14C636.Text = "Folder ảnh/video:";
		nudSoLuongAnhFrom.Location = new System.Drawing.Point(92, 33);
		nudSoLuongAnhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongAnhFrom.Name = "nudSoLuongAnhFrom";
		nudSoLuongAnhFrom.Size = new System.Drawing.Size(42, 23);
		nudSoLuongAnhFrom.TabIndex = 3;
		CF8C19A4.AutoSize = true;
		CF8C19A4.Cursor = System.Windows.Forms.Cursors.Hand;
		CF8C19A4.Location = new System.Drawing.Point(7, 60);
		CF8C19A4.Name = "ckbXoaAnh";
		CF8C19A4.Size = new System.Drawing.Size(141, 20);
		CF8C19A4.TabIndex = 33;
		CF8C19A4.Text = "Xóa ảnh đã sử dụng";
		CF8C19A4.UseVisualStyleBackColor = true;
		CF8C19A4.CheckedChanged += new System.EventHandler(A90CC304_CheckedChanged);
		label10.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(136, 35);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(16, 16);
		label10.TabIndex = 0;
		label10.Text = "-";
		label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudSoLuongAnhTo.Location = new System.Drawing.Point(155, 33);
		nudSoLuongAnhTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongAnhTo.Name = "nudSoLuongAnhTo";
		nudSoLuongAnhTo.Size = new System.Drawing.Size(42, 23);
		nudSoLuongAnhTo.TabIndex = 3;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(4, 35);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 16);
		label2.TabIndex = 0;
		label2.Text = "Số media/bài:";
		A90CC304.AutoSize = true;
		A90CC304.Cursor = System.Windows.Forms.Cursors.Hand;
		A90CC304.Location = new System.Drawing.Point(6, 82);
		A90CC304.Name = "ckbUseAvatar";
		A90CC304.Size = new System.Drawing.Size(196, 20);
		A90CC304.TabIndex = 33;
		A90CC304.Text = "Sử dụng avatar làm ảnh đăng";
		A90CC304.UseVisualStyleBackColor = true;
		A90CC304.CheckedChanged += new System.EventHandler(A90CC304_CheckedChanged);
		grTuyChon.Controls.Add(plDangBaiLenTuong);
		grTuyChon.Controls.Add(plDangBaiLenPage);
		grTuyChon.Controls.Add(plDangBaiLenNhom);
		grTuyChon.Controls.Add(BA11D702);
		grTuyChon.Controls.Add(DF303181);
		grTuyChon.Controls.Add(ckbDangBaiLenNhom);
		grTuyChon.Controls.Add(ckbDangBaiLenTuong);
		grTuyChon.Controls.Add(BD8D590F);
		grTuyChon.Location = new System.Drawing.Point(636, 107);
		grTuyChon.Name = "grTuyChon";
		grTuyChon.Size = new System.Drawing.Size(310, 376);
		grTuyChon.TabIndex = 70;
		grTuyChon.TabStop = false;
		grTuyChon.Text = "Tùy chọn";
		plDangBaiLenTuong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		plDangBaiLenTuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDangBaiLenTuong.Controls.Add(label4);
		plDangBaiLenTuong.Controls.Add(nudCountWallTo);
		plDangBaiLenTuong.Controls.Add(BC0F0CA7);
		plDangBaiLenTuong.Controls.Add(nudCountWallFrom);
		plDangBaiLenTuong.Location = new System.Drawing.Point(29, 44);
		plDangBaiLenTuong.Name = "plDangBaiLenTuong";
		plDangBaiLenTuong.Size = new System.Drawing.Size(270, 31);
		plDangBaiLenTuong.TabIndex = 1;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(3, 5);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(84, 16);
		label4.TabIndex = 49;
		label4.Text = "Số lượng bài:";
		nudCountWallTo.Location = new System.Drawing.Point(187, 3);
		nudCountWallTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountWallTo.Name = "nudCountWallTo";
		nudCountWallTo.Size = new System.Drawing.Size(56, 23);
		nudCountWallTo.TabIndex = 48;
		BC0F0CA7.AutoSize = true;
		BC0F0CA7.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		BC0F0CA7.Location = new System.Drawing.Point(166, 5);
		BC0F0CA7.Name = "label5";
		BC0F0CA7.Size = new System.Drawing.Size(18, 16);
		BC0F0CA7.TabIndex = 51;
		BC0F0CA7.Text = ">";
		nudCountWallFrom.Location = new System.Drawing.Point(108, 3);
		nudCountWallFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountWallFrom.Name = "nudCountWallFrom";
		nudCountWallFrom.Size = new System.Drawing.Size(56, 23);
		nudCountWallFrom.TabIndex = 47;
		plDangBaiLenPage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		plDangBaiLenPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDangBaiLenPage.Controls.Add(E4803489);
		plDangBaiLenPage.Controls.Add(C69CBF1F);
		plDangBaiLenPage.Controls.Add(label23);
		plDangBaiLenPage.Controls.Add(D105C48A);
		plDangBaiLenPage.Location = new System.Drawing.Point(29, 562);
		plDangBaiLenPage.Name = "plDangBaiLenPage";
		plDangBaiLenPage.Size = new System.Drawing.Size(270, 27);
		plDangBaiLenPage.TabIndex = 1;
		E4803489.AutoSize = true;
		E4803489.Location = new System.Drawing.Point(3, 3);
		E4803489.Name = "label21";
		E4803489.Size = new System.Drawing.Size(95, 16);
		E4803489.TabIndex = 49;
		E4803489.Text = "Số lượng page:";
		C69CBF1F.Location = new System.Drawing.Point(187, 1);
		C69CBF1F.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C69CBF1F.Name = "nudCountPageTo";
		C69CBF1F.Size = new System.Drawing.Size(56, 23);
		C69CBF1F.TabIndex = 48;
		label23.AutoSize = true;
		label23.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label23.Location = new System.Drawing.Point(166, 3);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(18, 16);
		label23.TabIndex = 51;
		label23.Text = ">";
		D105C48A.Location = new System.Drawing.Point(108, 1);
		D105C48A.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		D105C48A.Name = "nudCountPageFrom";
		D105C48A.Size = new System.Drawing.Size(56, 23);
		D105C48A.TabIndex = 47;
		plDangBaiLenNhom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		plDangBaiLenNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDangBaiLenNhom.Controls.Add(btnDown);
		plDangBaiLenNhom.Controls.Add(A137D9AD);
		plDangBaiLenNhom.Controls.Add(ckbUuTienNhomNhieuThanhVien);
		plDangBaiLenNhom.Controls.Add(BF2567A4);
		plDangBaiLenNhom.Controls.Add(ckbOnlyDangNhomKhongKiemDuyet);
		plDangBaiLenNhom.Controls.Add(A7A9B280);
		plDangBaiLenNhom.Controls.Add(label12);
		plDangBaiLenNhom.Controls.Add(nudCountGroupTo);
		plDangBaiLenNhom.Controls.Add(ckbTuongTac);
		plDangBaiLenNhom.Controls.Add(nudCountGroupFrom);
		plDangBaiLenNhom.Controls.Add(label24);
		plDangBaiLenNhom.Controls.Add(label26);
		plDangBaiLenNhom.Location = new System.Drawing.Point(29, 103);
		plDangBaiLenNhom.Name = "plDangBaiLenNhom";
		plDangBaiLenNhom.Size = new System.Drawing.Size(270, 240);
		plDangBaiLenNhom.TabIndex = 1;
		btnDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnDown.BackgroundImage = Class155.Bitmap_94;
		btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnDown.Location = new System.Drawing.Point(244, -1);
		btnDown.Name = "btnDown";
		btnDown.Size = new System.Drawing.Size(25, 25);
		btnDown.TabIndex = 193;
		btnDown.Click += new System.EventHandler(btnDown_Click);
		A137D9AD.AutoSize = true;
		A137D9AD.Cursor = System.Windows.Forms.Cursors.Hand;
		A137D9AD.Location = new System.Drawing.Point(6, 290);
		A137D9AD.Name = "ckbKhongDangTrung";
		A137D9AD.Size = new System.Drawing.Size(163, 20);
		A137D9AD.TabIndex = 2;
		A137D9AD.Text = "Không đăng trùng nhóm";
		A137D9AD.UseVisualStyleBackColor = true;
		ckbUuTienNhomNhieuThanhVien.AutoSize = true;
		ckbUuTienNhomNhieuThanhVien.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUuTienNhomNhieuThanhVien.Location = new System.Drawing.Point(6, 264);
		ckbUuTienNhomNhieuThanhVien.Name = "ckbUuTienNhomNhieuThanhVien";
		ckbUuTienNhomNhieuThanhVien.Size = new System.Drawing.Size(250, 20);
		ckbUuTienNhomNhieuThanhVien.TabIndex = 1;
		ckbUuTienNhomNhieuThanhVien.Text = "Ưu tiên đăng nhóm có nhiều thành viên";
		ckbUuTienNhomNhieuThanhVien.UseVisualStyleBackColor = true;
		BF2567A4.AutoSize = true;
		BF2567A4.Cursor = System.Windows.Forms.Cursors.Hand;
		BF2567A4.Location = new System.Drawing.Point(209, 317);
		BF2567A4.Name = "lblTuongTacNhom";
		BF2567A4.Size = new System.Drawing.Size(47, 16);
		BF2567A4.TabIndex = 183;
		BF2567A4.TabStop = true;
		BF2567A4.Text = "Cài đặt";
		BF2567A4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(B932E583);
		ckbOnlyDangNhomKhongKiemDuyet.AutoSize = true;
		ckbOnlyDangNhomKhongKiemDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbOnlyDangNhomKhongKiemDuyet.Location = new System.Drawing.Point(6, 238);
		ckbOnlyDangNhomKhongKiemDuyet.Name = "ckbOnlyDangNhomKhongKiemDuyet";
		ckbOnlyDangNhomKhongKiemDuyet.Size = new System.Drawing.Size(216, 20);
		ckbOnlyDangNhomKhongKiemDuyet.TabIndex = 0;
		ckbOnlyDangNhomKhongKiemDuyet.Text = "Chỉ đăng nhóm không kiểm duyệt";
		ckbOnlyDangNhomKhongKiemDuyet.UseVisualStyleBackColor = true;
		A7A9B280.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A7A9B280.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		A7A9B280.Controls.Add(plTuNhap);
		A7A9B280.Controls.Add(rbTuNhap);
		A7A9B280.Controls.Add(rbRandom);
		A7A9B280.Location = new System.Drawing.Point(6, 51);
		A7A9B280.Name = "panel3";
		A7A9B280.Size = new System.Drawing.Size(257, 183);
		A7A9B280.TabIndex = 67;
		plTuNhap.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		plTuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTuNhap.Controls.Add(C3AEDB1B);
		plTuNhap.Controls.Add(F4999C2D);
		plTuNhap.Controls.Add(A098CC81);
		plTuNhap.Location = new System.Drawing.Point(22, 49);
		plTuNhap.Name = "plTuNhap";
		plTuNhap.Size = new System.Drawing.Size(230, 128);
		plTuNhap.TabIndex = 193;
		C3AEDB1B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C3AEDB1B.Location = new System.Drawing.Point(3, 3);
		C3AEDB1B.Name = "txtNhomTuNhap";
		C3AEDB1B.Size = new System.Drawing.Size(222, 76);
		C3AEDB1B.TabIndex = 34;
		C3AEDB1B.Text = "";
		C3AEDB1B.WordWrap = false;
		C3AEDB1B.TextChanged += new System.EventHandler(CEA49C8C);
		F4999C2D.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		F4999C2D.AutoSize = true;
		F4999C2D.Cursor = System.Windows.Forms.Cursors.Hand;
		F4999C2D.Location = new System.Drawing.Point(3, 104);
		F4999C2D.Name = "ckbChiDangNhomDaThamGia";
		F4999C2D.Size = new System.Drawing.Size(184, 20);
		F4999C2D.TabIndex = 33;
		F4999C2D.Text = "Chỉ đăng nhóm đã tham gia";
		F4999C2D.UseVisualStyleBackColor = true;
		F4999C2D.CheckedChanged += new System.EventHandler(B803CB1A);
		A098CC81.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		A098CC81.AutoSize = true;
		A098CC81.Cursor = System.Windows.Forms.Cursors.Hand;
		A098CC81.Location = new System.Drawing.Point(3, 82);
		A098CC81.Name = "ckbXoaNhomDaDang";
		A098CC81.Size = new System.Drawing.Size(134, 20);
		A098CC81.TabIndex = 33;
		A098CC81.Text = "Xóa nhóm đã đăng";
		A098CC81.UseVisualStyleBackColor = true;
		rbTuNhap.AutoSize = true;
		rbTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
		rbTuNhap.Location = new System.Drawing.Point(3, 27);
		rbTuNhap.Name = "rbTuNhap";
		rbTuNhap.Size = new System.Drawing.Size(197, 20);
		rbTuNhap.TabIndex = 1;
		rbTuNhap.Text = "Nhóm do người dùng nhập (0)";
		rbTuNhap.UseVisualStyleBackColor = true;
		rbTuNhap.CheckedChanged += new System.EventHandler(rbTuNhap_CheckedChanged);
		rbRandom.AutoSize = true;
		rbRandom.Checked = true;
		rbRandom.Cursor = System.Windows.Forms.Cursors.Hand;
		rbRandom.Location = new System.Drawing.Point(3, 3);
		rbRandom.Name = "rbRandom";
		rbRandom.Size = new System.Drawing.Size(197, 20);
		rbRandom.TabIndex = 0;
		rbRandom.TabStop = true;
		rbRandom.Text = "Ngẫu nhiên nhóm đã tham gia";
		rbRandom.UseVisualStyleBackColor = true;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(3, 31);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(100, 16);
		label12.TabIndex = 66;
		label12.Text = "Tùy chọn nhóm:";
		nudCountGroupTo.Location = new System.Drawing.Point(187, 4);
		nudCountGroupTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountGroupTo.Name = "nudCountGroupTo";
		nudCountGroupTo.Size = new System.Drawing.Size(56, 23);
		nudCountGroupTo.TabIndex = 53;
		ckbTuongTac.AutoSize = true;
		ckbTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuongTac.Location = new System.Drawing.Point(6, 316);
		ckbTuongTac.Name = "ckbTuongTac";
		ckbTuongTac.Size = new System.Drawing.Size(206, 20);
		ckbTuongTac.TabIndex = 57;
		ckbTuongTac.Text = "Tương tác nhóm trước khi đăng";
		ckbTuongTac.UseVisualStyleBackColor = true;
		ckbTuongTac.CheckedChanged += new System.EventHandler(CEA28104);
		nudCountGroupFrom.Location = new System.Drawing.Point(108, 4);
		nudCountGroupFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudCountGroupFrom.Name = "nudCountGroupFrom";
		nudCountGroupFrom.Size = new System.Drawing.Size(56, 23);
		nudCountGroupFrom.TabIndex = 52;
		label24.AutoSize = true;
		label24.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
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
		BA11D702.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		BA11D702.AutoSize = true;
		BA11D702.Cursor = System.Windows.Forms.Cursors.Hand;
		BA11D702.Location = new System.Drawing.Point(200, 351);
		BA11D702.Name = "lblTuongTacBaiViet";
		BA11D702.Size = new System.Drawing.Size(47, 16);
		BA11D702.TabIndex = 183;
		BA11D702.TabStop = true;
		BA11D702.Text = "Cài đặt";
		BA11D702.Visible = false;
		BA11D702.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(BA11D702_LinkClicked);
		DF303181.AutoSize = true;
		DF303181.Cursor = System.Windows.Forms.Cursors.Hand;
		DF303181.Location = new System.Drawing.Point(9, 540);
		DF303181.Name = "ckbDangBaiLenPage";
		DF303181.Size = new System.Drawing.Size(130, 20);
		DF303181.TabIndex = 0;
		DF303181.Text = "Đăng bài lên page";
		DF303181.UseVisualStyleBackColor = true;
		DF303181.CheckedChanged += new System.EventHandler(DF303181_CheckedChanged);
		ckbDangBaiLenNhom.AutoSize = true;
		ckbDangBaiLenNhom.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDangBaiLenNhom.Location = new System.Drawing.Point(9, 81);
		ckbDangBaiLenNhom.Name = "ckbDangBaiLenNhom";
		ckbDangBaiLenNhom.Size = new System.Drawing.Size(134, 20);
		ckbDangBaiLenNhom.TabIndex = 0;
		ckbDangBaiLenNhom.Text = "Đăng bài lên nhóm";
		ckbDangBaiLenNhom.UseVisualStyleBackColor = true;
		ckbDangBaiLenNhom.CheckedChanged += new System.EventHandler(DB0CEABF);
		ckbDangBaiLenTuong.AutoSize = true;
		ckbDangBaiLenTuong.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDangBaiLenTuong.Location = new System.Drawing.Point(9, 22);
		ckbDangBaiLenTuong.Name = "ckbDangBaiLenTuong";
		ckbDangBaiLenTuong.Size = new System.Drawing.Size(135, 20);
		ckbDangBaiLenTuong.TabIndex = 0;
		ckbDangBaiLenTuong.Text = "Đăng bài lên tường";
		ckbDangBaiLenTuong.UseVisualStyleBackColor = true;
		ckbDangBaiLenTuong.CheckedChanged += new System.EventHandler(ckbDangBaiLenTuong_CheckedChanged);
		BD8D590F.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		BD8D590F.AutoSize = true;
		BD8D590F.Cursor = System.Windows.Forms.Cursors.Hand;
		BD8D590F.Location = new System.Drawing.Point(9, 350);
		BD8D590F.Name = "ckbTuongTacBaiVietDaDang";
		BD8D590F.Size = new System.Drawing.Size(179, 20);
		BD8D590F.TabIndex = 57;
		BD8D590F.Text = "Tương tác ba\u0300i viê\u0301t đa\u0303 đăng";
		BD8D590F.UseVisualStyleBackColor = true;
		BD8D590F.Visible = false;
		BD8D590F.CheckedChanged += new System.EventHandler(EEB17327);
		nudDelayTo.Location = new System.Drawing.Point(228, 78);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 58;
		nudDelayFrom.Location = new System.Drawing.Point(131, 78);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 57;
		label20.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(193, 80);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(29, 16);
		label20.TabIndex = 61;
		label20.Text = ">";
		label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(27, 80);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(87, 16);
		label15.TabIndex = 59;
		label15.Text = "Gia\u0303n ca\u0301ch (s):";
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(395, 600);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Thêm";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		EB1EDC91.Location = new System.Drawing.Point(131, 49);
		EB1EDC91.Name = "txtTenHanhDong";
		EB1EDC91.Size = new System.Drawing.Size(153, 23);
		EB1EDC91.TabIndex = 0;
		CC864295.AutoSize = true;
		CC864295.Location = new System.Drawing.Point(27, 52);
		CC864295.Name = "label1";
		CC864295.Size = new System.Drawing.Size(98, 16);
		CC864295.TabIndex = 31;
		CC864295.Text = "Tên ha\u0300nh đô\u0323ng:";
		C4023429.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		C4023429.BackColor = System.Drawing.Color.Maroon;
		C4023429.Cursor = System.Windows.Forms.Cursors.Hand;
		C4023429.FlatAppearance.BorderSize = 0;
		C4023429.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		C4023429.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C4023429.ForeColor = System.Drawing.Color.White;
		C4023429.Location = new System.Drawing.Point(494, 600);
		C4023429.Name = "btnCancel";
		C4023429.Size = new System.Drawing.Size(92, 29);
		C4023429.TabIndex = 4;
		C4023429.Text = "Đóng";
		C4023429.UseVisualStyleBackColor = false;
		C4023429.Click += new System.EventHandler(A9A77939);
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
		bunifuCards1.Size = new System.Drawing.Size(978, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(981, 643);
		base.Controls.Add(F0943083);
		Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDDangBai";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDDangBai_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)EA2147A1).EndInit();
		F0943083.ResumeLayout(false);
		F0943083.PerformLayout();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		F9AACA95.ResumeLayout(false);
		F9AACA95.PerformLayout();
		EE365911.ResumeLayout(false);
		EE365911.PerformLayout();
		E217C703.ResumeLayout(false);
		E217C703.PerformLayout();
		tabControl1.ResumeLayout(false);
		tabCommentText.ResumeLayout(false);
		tabCommentText.PerformLayout();
		tabCommentAI.ResumeLayout(false);
		tabCommentAI.PerformLayout();
		D3247C16.ResumeLayout(false);
		D3247C16.PerformLayout();
		plNotUseAvatar.ResumeLayout(false);
		plNotUseAvatar.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).EndInit();
		grTuyChon.ResumeLayout(false);
		grTuyChon.PerformLayout();
		plDangBaiLenTuong.ResumeLayout(false);
		plDangBaiLenTuong.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountWallTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountWallFrom).EndInit();
		plDangBaiLenPage.ResumeLayout(false);
		plDangBaiLenPage.PerformLayout();
		((System.ComponentModel.ISupportInitialize)C69CBF1F).EndInit();
		((System.ComponentModel.ISupportInitialize)D105C48A).EndInit();
		plDangBaiLenNhom.ResumeLayout(false);
		plDangBaiLenNhom.PerformLayout();
		A7A9B280.ResumeLayout(false);
		A7A9B280.PerformLayout();
		plTuNhap.ResumeLayout(false);
		plTuNhap.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountGroupTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
