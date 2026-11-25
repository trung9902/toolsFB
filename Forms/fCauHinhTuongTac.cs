using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fCauHinhTuongTac : Form
{
	internal IContainer icontainer_0 = null;

	internal BunifuCards bunifuCards1;

	internal Panel A83E1691;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button AB016E2C;

	internal Button CE93A1A5;

	internal Button btnAdd;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal CheckBox ckbCreateProfile;

	internal CheckBox ckbGetCookie;

	internal CheckBox B2986829;

	internal CheckBox A5B3DAA7;

	internal Panel panel1;

	internal CheckBox ckbLogOut;

	internal Label label3;

	internal Label label2;

	internal CheckBox ckbAllowFollow;

	internal CheckBox ckbCheckLiveUid;

	internal CheckBox ckbDontSaveBrowser;

	internal CheckBox ckbXoaCache;

	internal Panel ADA7CA14;

	internal CheckBox ckbEmail;

	internal CheckBox ckbFollow;

	internal CheckBox FF275AAF;

	internal CheckBox ckbFriend;

	internal CheckBox ckbNgayTao;

	internal CheckBox ckbBirthday;

	internal CheckBox ckbGender;

	internal CheckBox ckbName;

	internal CheckBox ckbPhone;

	internal ComboBox CBBB6E04;

	internal ComboBox cbbTypeLogin;

	internal ComboBox cbbFacebookWeb;

	internal CheckBox ckbAvatar;

	internal CheckBox ckbRandomThuTuTaiKhoan;

	internal CheckBox ckbLocation;

	internal CheckBox E91308A9;

	internal CheckBox A1858F13;

	internal CheckBox ckbDating;

	internal CheckBox ckbHometown;

	internal CheckBox ckbDisableChatSettings;

	internal CheckBox ckbFbBlock;

	internal GroupBox F9B713B0;

	internal GroupBox groupBox6;

	internal GroupBox B80E0C11;

	internal Button button2;

	internal Button button1;

	internal CheckBox ckbCapNhatThongTinTruocKhiTuongTac;

	internal GroupBox C3233E90;

	internal Panel plChonKichBan;

	internal Label EBB25FAB;

	internal ComboBox cbbKichBan;

	internal Button btnQuanLyKichBan;

	internal CheckBox ckbChayKichBanDaGan;

	internal Button btnDown;

	internal Button btnUp;

	internal Panel plGioiHanThoiGianChayKichBan;

	internal Label C7A0FABD;

	internal NumericUpDown nudThoiGianChayKichBanTo;

	internal NumericUpDown C71A900B;

	internal Panel plRepeatAll;

	internal Label label6;

	internal Label label4;

	internal NumericUpDown nudDelayTurnFrom;

	internal Label C303D92C;

	internal NumericUpDown D996DE84;

	internal Label label11;

	internal NumericUpDown BFBADA88;

	internal Label C68A59B4;

	internal Panel plGioiHanThoiGianChayTaiKhoan;

	internal Label label13;

	internal NumericUpDown B52AAC1A;

	internal NumericUpDown A52E7A3F;

	internal CheckBox ckbGioiHanThoiGianChayKichBan;

	internal CheckBox ckbRepeatAll;

	internal CheckBox ckbGioiHanThoiGianChayTaiKhoan;

	internal CheckBox ckbPublicPost;

	internal CheckBox D483029F;

	internal CheckBox D3AD12B0;

	internal CheckBox BB3F5B11;

	internal ComboBox B71EAD91;

	internal CheckBox ckbDoiNgonNgu;

	internal CheckBox C10D3B3A;

	internal CheckBox ckbPagePro5;

	internal CheckBox ckbWallPosts;

	internal CheckBox E3041E25;

	public fCauHinhTuongTac()
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		D483029F.Visible = Base.bool_0;
	}

	private void E29B42B4(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			ckbChayKichBanDaGan.Visible = true;
		}
		else
		{
			Close();
		}
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("configInteractGeneral").method_4("typeLogin", cbbTypeLogin.SelectedIndex);
		C5034B95.smethod_0("configInteractGeneral").method_4("typeBrowserLogin", cbbFacebookWeb.SelectedIndex);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCreateProfile", ckbCreateProfile.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCheckPasswordCorrect", C10D3B3A.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbGetToken", A5B3DAA7.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("typeToken", CBBB6E04.SelectedValue);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbGetCookie", ckbGetCookie.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCapNhatThongTin", B2986829.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCapNhatThongTinTruocKhiTuongTac", ckbCapNhatThongTinTruocKhiTuongTac.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbName", ckbName.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbGender", ckbGender.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbBirthday", ckbBirthday.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbNgayTao", ckbNgayTao.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbEmail", ckbEmail.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbFriend", ckbFriend.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbGroup", FF275AAF.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbPagePro5", ckbPagePro5.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbFollow", ckbFollow.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbPhone", ckbPhone.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbAvatar", ckbAvatar.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbDating", ckbDating.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbAds", A1858F13.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbBM", E91308A9.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbLocation", ckbLocation.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbHometown", ckbHometown.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbFbBlock", ckbFbBlock.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCheckLiveUid", ckbCheckLiveUid.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbDontSaveBrowser", ckbDontSaveBrowser.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbRepeatAll", ckbRepeatAll.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudDelayTurnFrom", nudDelayTurnFrom.Value);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudDelayTurnTo", D996DE84.Value);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudSoLuotChay", BFBADA88.Value);
		C5034B95.smethod_0("configInteractGeneral").method_4("RepeatAllVIP", "false");
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbLogOut", ckbLogOut.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbAllowFollow", ckbAllowFollow.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbWallPosts", ckbWallPosts.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbPublicPost", ckbPublicPost.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCheckCreateProfile", BB3F5B11.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbPrivateInfo", D3AD12B0.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbRandomThuTuTaiKhoan", ckbRandomThuTuTaiKhoan.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbDoiNgonNgu", ckbDoiNgonNgu.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("cbbLanguage", B71EAD91.Text);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbCheckMetaVerified", E3041E25.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbChayKichBanDaGan", ckbChayKichBanDaGan.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("cbbKichBan", cbbKichBan.SelectedValue);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbXoaCache", ckbXoaCache.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbXoaProfile", D483029F.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbGioiHanThoiGianChayTaiKhoan", ckbGioiHanThoiGianChayTaiKhoan.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudThoiGianChayTaiKhoanFrom", A52E7A3F.Value);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudThoiGianChayTaiKhoanTo", B52AAC1A.Value);
		C5034B95.smethod_0("configInteractGeneral").method_4("ckbGioiHanThoiGianChayKichBan", ckbGioiHanThoiGianChayKichBan.Checked);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudThoiGianChayKichBanFrom", C71A900B.Value);
		C5034B95.smethod_0("configInteractGeneral").method_4("nudThoiGianChayKichBanTo", nudThoiGianChayKichBanTo.Value);
		C5034B95.smethod_1("configInteractGeneral");
		if (MsBoxHelper.D41C45AC("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?") == DialogResult.Yes)
		{
			Close();
		}
	}

	private void CE93A1A5_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnQuanLyKichBan_Click(object sender, EventArgs e)
	{
		string b0BFABAD = "";
		try
		{
			if (cbbKichBan.Items.Count > 0)
			{
				b0BFABAD = cbbKichBan.SelectedValue.ToString();
			}
		}
		catch
		{
		}
		Commom.smethod_35(new fDanhSachKichBan_Old(b0BFABAD));
		E7131639();
	}

	private void BD2EF293(object sender, EventArgs e)
	{
	}

	private void F09B31B5(object sender, EventArgs e)
	{
	}

	private void method_0()
	{
		BD2EF293(null, null);
		F09B31B5(null, null);
		ckbRepeatAll_CheckedChanged(null, null);
		FD2F161D(null, null);
		FF1F9690(null, null);
		ckbGioiHanThoiGianChayKichBan_CheckedChanged(null, null);
		A5B3DAA7_CheckedChanged(null, null);
		D216BF21(null, null);
		FBABDFB0(null, null);
		E928923A(null, null);
	}

	private void fCauHinhTuongTac_Load(object sender, EventArgs e)
	{
		E7131639();
		method_1();
		method_0();
	}

	private void method_1()
	{
		CAA943BA();
		try
		{
			cbbTypeLogin.SelectedIndex = C5034B95.smethod_0("configInteractGeneral").method_2("typeLogin");
			cbbFacebookWeb.SelectedIndex = C5034B95.smethod_0("configInteractGeneral").method_2("typeBrowserLogin");
			ckbCreateProfile.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCreateProfile");
			C10D3B3A.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckPasswordCorrect");
			A5B3DAA7.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetToken");
			try
			{
				CBBB6E04.SelectedValue = C5034B95.smethod_0("configInteractGeneral").BDB80B23("typeToken");
			}
			catch (Exception)
			{
				CBBB6E04.SelectedIndex = 0;
			}
			ckbGetCookie.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGetCookie");
			B2986829.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCapNhatThongTin");
			ckbCapNhatThongTinTruocKhiTuongTac.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCapNhatThongTinTruocKhiTuongTac");
			ckbName.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbName");
			ckbGender.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGender");
			ckbBirthday.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbBirthday");
			ckbNgayTao.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbNgayTao");
			ckbEmail.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbEmail");
			ckbFriend.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbFriend");
			FF275AAF.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGroup");
			ckbPagePro5.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbPagePro5");
			ckbFollow.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbFollow");
			ckbPhone.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbPhone");
			ckbAvatar.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbAvatar");
			ckbDating.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbDating");
			A1858F13.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbAds");
			E91308A9.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbBM");
			ckbLocation.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbLocation");
			ckbHometown.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbHometown");
			ckbFbBlock.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbFbBlock");
			ckbCheckLiveUid.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckLiveUid");
			ckbDontSaveBrowser.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbDontSaveBrowser");
			ckbRepeatAll.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbRepeatAll");
			nudDelayTurnFrom.Value = C5034B95.smethod_0("configInteractGeneral").method_2("nudDelayTurnFrom");
			D996DE84.Value = C5034B95.smethod_0("configInteractGeneral").method_2("nudDelayTurnTo");
			int num = C5034B95.smethod_0("configInteractGeneral").method_2("nudSoLuotChay", 2);
			BFBADA88.Value = ((num >= 2) ? num : 2);
			ckbLogOut.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbLogOut");
			ckbAllowFollow.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbAllowFollow");
			ckbWallPosts.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbWallPosts");
			ckbPublicPost.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbPublicPost");
			BB3F5B11.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckCreateProfile");
			D3AD12B0.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbPrivateInfo");
			ckbRandomThuTuTaiKhoan.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbRandomThuTuTaiKhoan");
			ckbDoiNgonNgu.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbDoiNgonNgu");
			B71EAD91.Text = C5034B95.smethod_0("configInteractGeneral").BDB80B23("cbbLanguage", "vi_VN");
			E3041E25.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbCheckMetaVerified");
			ckbChayKichBanDaGan.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbChayKichBanDaGan");
			cbbKichBan.SelectedValue = C5034B95.smethod_0("configInteractGeneral").BDB80B23("cbbKichBan");
			ckbXoaCache.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbXoaCache");
			D483029F.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbXoaProfile");
			ckbGioiHanThoiGianChayTaiKhoan.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGioiHanThoiGianChayTaiKhoan");
			A52E7A3F.Value = C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayTaiKhoanFrom", 1);
			B52AAC1A.Value = C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayTaiKhoanTo", 1);
			ckbGioiHanThoiGianChayKichBan.Checked = C5034B95.smethod_0("configInteractGeneral").method_3("ckbGioiHanThoiGianChayKichBan");
			C71A900B.Value = C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayKichBanFrom", 1);
			nudThoiGianChayKichBanTo.Value = C5034B95.smethod_0("configInteractGeneral").method_2("nudThoiGianChayKichBanTo", 1);
		}
		catch
		{
		}
	}

	private void CAA943BA()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "EAAG");
		dictionary.Add("2", "EAABs");
		dictionary.Add("3", "EAAAAU");
		dictionary.Add("4", "EAAAAY");
		Commom.smethod_24(CBBB6E04, dictionary);
	}

	private void E7131639()
	{
		int num = -1;
		if (cbbKichBan.SelectedIndex != -1)
		{
			num = cbbKichBan.SelectedIndex;
		}
		DataTable dataSource = Class154.smethod_2();
		cbbKichBan.DataSource = dataSource;
		cbbKichBan.ValueMember = "Id_KichBan";
		cbbKichBan.DisplayMember = "Ten";
		if (num != -1 && num != 0 && cbbKichBan.Items.Count >= num + 1)
		{
			cbbKichBan.SelectedIndex = num;
		}
		else if (cbbKichBan.Items.Count > 0)
		{
			cbbKichBan.SelectedIndex = 0;
		}
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void FD2F161D(object sender, EventArgs e)
	{
		ADA7CA14.Enabled = B2986829.Checked;
		ckbCapNhatThongTinTruocKhiTuongTac.Enabled = B2986829.Checked;
		if (!B2986829.Checked)
		{
			ckbCapNhatThongTinTruocKhiTuongTac.Checked = false;
		}
	}

	private void A5B3DAA7_Click(object sender, EventArgs e)
	{
	}

	private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
	{
		plRepeatAll.Enabled = ckbRepeatAll.Checked;
	}

	private void E28AE398(object sender, EventArgs e)
	{
	}

	private void FF1F9690(object sender, EventArgs e)
	{
		plGioiHanThoiGianChayTaiKhoan.Enabled = ckbGioiHanThoiGianChayTaiKhoan.Checked;
	}

	private void ckbGioiHanThoiGianChayKichBan_CheckedChanged(object sender, EventArgs e)
	{
		plGioiHanThoiGianChayKichBan.Enabled = ckbGioiHanThoiGianChayKichBan.Checked;
	}

	private void A5B3DAA7_CheckedChanged(object sender, EventArgs e)
	{
		CBBB6E04.Enabled = A5B3DAA7.Checked;
	}

	private void FF275AAF_Click(object sender, EventArgs e)
	{
	}

	private void AA2F3D28(object sender, EventArgs e)
	{
		base.Height = 478;
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		base.Height = 385;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		F9B713B0.Height = 105;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		F9B713B0.Height = 51;
	}

	private void B2986829_Click(object sender, EventArgs e)
	{
		if ((e as MouseEventArgs).Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
		{
			ckbCapNhatThongTinTruocKhiTuongTac.Visible = true;
		}
	}

	private void D216BF21(object sender, EventArgs e)
	{
		plChonKichBan.Enabled = !ckbChayKichBanDaGan.Checked;
	}

	private void FBABDFB0(object sender, EventArgs e)
	{
		D483029F.Enabled = ckbCreateProfile.Checked;
		ckbXoaCache.Enabled = ckbCreateProfile.Checked;
		if (!ckbCreateProfile.Checked)
		{
			D483029F.Checked = false;
			ckbXoaCache.Checked = false;
		}
	}

	private void E928923A(object sender, EventArgs e)
	{
		B71EAD91.Enabled = ckbDoiNgonNgu.Checked;
	}

	private void C90F0BAD(object sender, EventArgs e)
	{
		if (ckbWallPosts.Checked)
		{
			Commom.smethod_35(new fCauHinhWallPost(C5034B95.smethod_0("configInteractGeneral")));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCauHinhTuongTac));
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		A83E1691 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		AB016E2C = new System.Windows.Forms.Button();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		CE93A1A5 = new System.Windows.Forms.Button();
		btnAdd = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		ckbCreateProfile = new System.Windows.Forms.CheckBox();
		ckbGetCookie = new System.Windows.Forms.CheckBox();
		ckbAllowFollow = new System.Windows.Forms.CheckBox();
		ckbLogOut = new System.Windows.Forms.CheckBox();
		B2986829 = new System.Windows.Forms.CheckBox();
		A5B3DAA7 = new System.Windows.Forms.CheckBox();
		panel1 = new System.Windows.Forms.Panel();
		groupBox6 = new System.Windows.Forms.GroupBox();
		B71EAD91 = new System.Windows.Forms.ComboBox();
		CBBB6E04 = new System.Windows.Forms.ComboBox();
		ckbWallPosts = new System.Windows.Forms.CheckBox();
		ckbDoiNgonNgu = new System.Windows.Forms.CheckBox();
		C10D3B3A = new System.Windows.Forms.CheckBox();
		BB3F5B11 = new System.Windows.Forms.CheckBox();
		ckbCapNhatThongTinTruocKhiTuongTac = new System.Windows.Forms.CheckBox();
		E3041E25 = new System.Windows.Forms.CheckBox();
		ADA7CA14 = new System.Windows.Forms.Panel();
		ckbHometown = new System.Windows.Forms.CheckBox();
		ckbLocation = new System.Windows.Forms.CheckBox();
		ckbNgayTao = new System.Windows.Forms.CheckBox();
		ckbPagePro5 = new System.Windows.Forms.CheckBox();
		ckbEmail = new System.Windows.Forms.CheckBox();
		E91308A9 = new System.Windows.Forms.CheckBox();
		ckbFbBlock = new System.Windows.Forms.CheckBox();
		A1858F13 = new System.Windows.Forms.CheckBox();
		ckbDating = new System.Windows.Forms.CheckBox();
		ckbAvatar = new System.Windows.Forms.CheckBox();
		ckbPhone = new System.Windows.Forms.CheckBox();
		ckbFollow = new System.Windows.Forms.CheckBox();
		FF275AAF = new System.Windows.Forms.CheckBox();
		ckbFriend = new System.Windows.Forms.CheckBox();
		ckbBirthday = new System.Windows.Forms.CheckBox();
		ckbGender = new System.Windows.Forms.CheckBox();
		ckbName = new System.Windows.Forms.CheckBox();
		B80E0C11 = new System.Windows.Forms.GroupBox();
		D483029F = new System.Windows.Forms.CheckBox();
		ckbRandomThuTuTaiKhoan = new System.Windows.Forms.CheckBox();
		ckbCheckLiveUid = new System.Windows.Forms.CheckBox();
		ckbXoaCache = new System.Windows.Forms.CheckBox();
		ckbPublicPost = new System.Windows.Forms.CheckBox();
		F9B713B0 = new System.Windows.Forms.GroupBox();
		button2 = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		cbbFacebookWeb = new System.Windows.Forms.ComboBox();
		cbbTypeLogin = new System.Windows.Forms.ComboBox();
		ckbDontSaveBrowser = new System.Windows.Forms.CheckBox();
		D3AD12B0 = new System.Windows.Forms.CheckBox();
		ckbDisableChatSettings = new System.Windows.Forms.CheckBox();
		C3233E90 = new System.Windows.Forms.GroupBox();
		plChonKichBan = new System.Windows.Forms.Panel();
		EBB25FAB = new System.Windows.Forms.Label();
		cbbKichBan = new System.Windows.Forms.ComboBox();
		btnQuanLyKichBan = new System.Windows.Forms.Button();
		ckbChayKichBanDaGan = new System.Windows.Forms.CheckBox();
		btnDown = new System.Windows.Forms.Button();
		btnUp = new System.Windows.Forms.Button();
		plGioiHanThoiGianChayKichBan = new System.Windows.Forms.Panel();
		C7A0FABD = new System.Windows.Forms.Label();
		nudThoiGianChayKichBanTo = new System.Windows.Forms.NumericUpDown();
		C71A900B = new System.Windows.Forms.NumericUpDown();
		plRepeatAll = new System.Windows.Forms.Panel();
		label6 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		nudDelayTurnFrom = new System.Windows.Forms.NumericUpDown();
		C303D92C = new System.Windows.Forms.Label();
		D996DE84 = new System.Windows.Forms.NumericUpDown();
		label11 = new System.Windows.Forms.Label();
		BFBADA88 = new System.Windows.Forms.NumericUpDown();
		C68A59B4 = new System.Windows.Forms.Label();
		plGioiHanThoiGianChayTaiKhoan = new System.Windows.Forms.Panel();
		label13 = new System.Windows.Forms.Label();
		B52AAC1A = new System.Windows.Forms.NumericUpDown();
		A52E7A3F = new System.Windows.Forms.NumericUpDown();
		ckbGioiHanThoiGianChayKichBan = new System.Windows.Forms.CheckBox();
		ckbRepeatAll = new System.Windows.Forms.CheckBox();
		ckbGioiHanThoiGianChayTaiKhoan = new System.Windows.Forms.CheckBox();
		bunifuCards1.SuspendLayout();
		A83E1691.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		groupBox6.SuspendLayout();
		ADA7CA14.SuspendLayout();
		B80E0C11.SuspendLayout();
		F9B713B0.SuspendLayout();
		C3233E90.SuspendLayout();
		plChonKichBan.SuspendLayout();
		plGioiHanThoiGianChayKichBan.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianChayKichBanTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)C71A900B).BeginInit();
		plRepeatAll.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)D996DE84).BeginInit();
		((System.ComponentModel.ISupportInitialize)BFBADA88).BeginInit();
		plGioiHanThoiGianChayTaiKhoan.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)B52AAC1A).BeginInit();
		((System.ComponentModel.ISupportInitialize)A52E7A3F).BeginInit();
		SuspendLayout();
		bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		bunifuCards1.BackColor = System.Drawing.Color.White;
		bunifuCards1.BorderRadius = 0;
		bunifuCards1.BottomSahddow = true;
		bunifuCards1.color = System.Drawing.Color.FromArgb(24, 119, 242);
		bunifuCards1.Controls.Add(A83E1691);
		bunifuCards1.LeftSahddow = false;
		bunifuCards1.Location = new System.Drawing.Point(2, 1);
		bunifuCards1.Name = "bunifuCards1";
		bunifuCards1.RightSahddow = true;
		bunifuCards1.ShadowDepth = 20;
		bunifuCards1.Size = new System.Drawing.Size(820, 38);
		bunifuCards1.TabIndex = 0;
		A83E1691.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A83E1691.BackColor = System.Drawing.Color.White;
		A83E1691.Controls.Add(pictureBox1);
		A83E1691.Controls.Add(AB016E2C);
		A83E1691.Controls.Add(bunifuCustomLabel1);
		A83E1691.Location = new System.Drawing.Point(0, 5);
		A83E1691.Name = "pnlHeader";
		A83E1691.Size = new System.Drawing.Size(820, 32);
		A83E1691.TabIndex = 9;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 78;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		AB016E2C.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		AB016E2C.Cursor = System.Windows.Forms.Cursors.Hand;
		AB016E2C.FlatAppearance.BorderSize = 0;
		AB016E2C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AB016E2C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		AB016E2C.ForeColor = System.Drawing.Color.White;
		AB016E2C.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
		AB016E2C.Location = new System.Drawing.Point(786, -2);
		AB016E2C.Name = "btnMinimize";
		AB016E2C.Size = new System.Drawing.Size(32, 32);
		AB016E2C.TabIndex = 9;
		AB016E2C.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		AB016E2C.UseVisualStyleBackColor = true;
		AB016E2C.Click += new System.EventHandler(E29B42B4);
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(820, 32);
		bunifuCustomLabel1.TabIndex = 1;
		bunifuCustomLabel1.Text = "Cấu hình Tương tác";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		CE93A1A5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		CE93A1A5.BackColor = System.Drawing.Color.Maroon;
		CE93A1A5.Cursor = System.Windows.Forms.Cursors.Hand;
		CE93A1A5.FlatAppearance.BorderSize = 0;
		CE93A1A5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CE93A1A5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CE93A1A5.ForeColor = System.Drawing.Color.White;
		CE93A1A5.Location = new System.Drawing.Point(415, 343);
		CE93A1A5.Name = "btnCancel";
		CE93A1A5.Size = new System.Drawing.Size(92, 29);
		CE93A1A5.TabIndex = 4;
		CE93A1A5.Text = "Đóng";
		CE93A1A5.UseVisualStyleBackColor = false;
		CE93A1A5.Click += new System.EventHandler(CE93A1A5_Click);
		btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnAdd.ForeColor = System.Drawing.Color.White;
		btnAdd.Location = new System.Drawing.Point(317, 343);
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(92, 29);
		btnAdd.TabIndex = 3;
		btnAdd.Text = "Lưu";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += new System.EventHandler(btnAdd_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(10, 54);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(102, 16);
		label3.TabIndex = 3;
		label3.Text = "Web đăng nhâ\u0323p:";
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(9, 24);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(100, 16);
		label2.TabIndex = 3;
		label2.Text = "Kiểu đăng nhâ\u0323p:";
		ckbCreateProfile.AutoSize = true;
		ckbCreateProfile.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCreateProfile.Location = new System.Drawing.Point(13, 22);
		ckbCreateProfile.Name = "ckbCreateProfile";
		ckbCreateProfile.Size = new System.Drawing.Size(161, 20);
		ckbCreateProfile.TabIndex = 2;
		ckbCreateProfile.Text = "Sử dụng profile chrome";
		ckbCreateProfile.UseVisualStyleBackColor = true;
		ckbCreateProfile.CheckedChanged += new System.EventHandler(FBABDFB0);
		ckbGetCookie.AutoSize = true;
		ckbGetCookie.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGetCookie.Location = new System.Drawing.Point(21, 22);
		ckbGetCookie.Name = "ckbGetCookie";
		ckbGetCookie.Size = new System.Drawing.Size(134, 20);
		ckbGetCookie.TabIndex = 2;
		ckbGetCookie.Text = "Tự động lấy cookie";
		ckbGetCookie.UseVisualStyleBackColor = true;
		ckbAllowFollow.AutoSize = true;
		ckbAllowFollow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAllowFollow.Location = new System.Drawing.Point(21, 183);
		ckbAllowFollow.Name = "ckbAllowFollow";
		ckbAllowFollow.Size = new System.Drawing.Size(187, 20);
		ckbAllowFollow.TabIndex = 2;
		ckbAllowFollow.Text = "Cho phe\u0301p ngươ\u0300i kha\u0301c Follow";
		ckbAllowFollow.UseVisualStyleBackColor = true;
		ckbLogOut.AutoSize = true;
		ckbLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLogOut.Location = new System.Drawing.Point(21, 261);
		ckbLogOut.Name = "ckbLogOut";
		ckbLogOut.Size = new System.Drawing.Size(140, 20);
		ckbLogOut.TabIndex = 2;
		ckbLogOut.Text = "Đăng xuất tài khoản";
		ckbLogOut.UseVisualStyleBackColor = true;
		B2986829.AutoSize = true;
		B2986829.Cursor = System.Windows.Forms.Cursors.Hand;
		B2986829.Location = new System.Drawing.Point(21, 48);
		B2986829.Name = "ckbCapNhatThongTin";
		B2986829.Size = new System.Drawing.Size(181, 20);
		B2986829.TabIndex = 2;
		B2986829.Text = "Tự động cập nhật thông tin";
		B2986829.UseVisualStyleBackColor = true;
		B2986829.CheckedChanged += new System.EventHandler(FD2F161D);
		B2986829.Click += new System.EventHandler(B2986829_Click);
		A5B3DAA7.AutoSize = true;
		A5B3DAA7.Cursor = System.Windows.Forms.Cursors.Hand;
		A5B3DAA7.Location = new System.Drawing.Point(166, 22);
		A5B3DAA7.Name = "ckbGetToken";
		A5B3DAA7.Size = new System.Drawing.Size(129, 20);
		A5B3DAA7.TabIndex = 2;
		A5B3DAA7.Text = "Tự động lấy token";
		A5B3DAA7.UseVisualStyleBackColor = true;
		A5B3DAA7.CheckedChanged += new System.EventHandler(A5B3DAA7_CheckedChanged);
		A5B3DAA7.Click += new System.EventHandler(A5B3DAA7_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(groupBox6);
		panel1.Controls.Add(B80E0C11);
		panel1.Controls.Add(ckbPublicPost);
		panel1.Controls.Add(F9B713B0);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(D3AD12B0);
		panel1.Controls.Add(ckbDisableChatSettings);
		panel1.Controls.Add(CE93A1A5);
		panel1.Controls.Add(C3233E90);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(822, 385);
		panel1.TabIndex = 8;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		groupBox6.Controls.Add(B71EAD91);
		groupBox6.Controls.Add(CBBB6E04);
		groupBox6.Controls.Add(ckbWallPosts);
		groupBox6.Controls.Add(ckbAllowFollow);
		groupBox6.Controls.Add(ckbDoiNgonNgu);
		groupBox6.Controls.Add(C10D3B3A);
		groupBox6.Controls.Add(BB3F5B11);
		groupBox6.Controls.Add(ckbCapNhatThongTinTruocKhiTuongTac);
		groupBox6.Controls.Add(E3041E25);
		groupBox6.Controls.Add(ckbLogOut);
		groupBox6.Controls.Add(B2986829);
		groupBox6.Controls.Add(ADA7CA14);
		groupBox6.Controls.Add(ckbGetCookie);
		groupBox6.Controls.Add(A5B3DAA7);
		groupBox6.Location = new System.Drawing.Point(414, 44);
		groupBox6.Name = "groupBox6";
		groupBox6.Size = new System.Drawing.Size(394, 287);
		groupBox6.TabIndex = 13;
		groupBox6.TabStop = false;
		groupBox6.Text = "Sau khi tương tác";
		B71EAD91.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
		B71EAD91.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
		B71EAD91.Cursor = System.Windows.Forms.Cursors.Hand;
		B71EAD91.DropDownWidth = 200;
		B71EAD91.FormattingEnabled = true;
		B71EAD91.Items.AddRange(new object[112]
		{
			"vi_VN|Tiếng Việt", "en_US|Tiếng Anh (Mỹ)", "af_ZA|Tiếng Afrikaans", "am_ET|Tiếng Amhara", "ar_AR|Tiếng Ả Rập", "as_IN|Tiếng Assam", "az_AZ|Tiếng Azerbaijan", "be_BY|Tiếng Belarus", "bg_BG|Tiếng Bungari", "bn_IN|Tiếng Bengali",
			"br_FR|Tiếng Breton", "bs_BA|Tiếng Bosnia", "ca_ES|Tiếng Ca-ta-lăng", "cb_IQ|Tiếng Kurd Sorani", "co_FR|Tiếng Corse", "cs_CZ|Tiếng Séc", "cx_PH|Tiếng Cebuano", "cy_GB|Tiếng Wales", "da_DK|Tiếng Đan Mạch", "de_DE|Tiếng Đức",
			"el_GR|Tiếng Hy Lạp", "en_GB|Tiếng Anh (Anh)", "eo_EO|Tiếng Esperanto", "es_ES|Tiếng Tây Ban Nha (Tây Ban Nha)", "es_LA|Tiếng Tây Ban Nha", "et_EE|Tiếng Estonia", "eu_ES|Tiếng Basque", "fa_IR|Tiếng Ba Tư", "ff_NG|Tiếng Fula", "fi_FI|Tiếng Phần Lan",
			"fo_FO|Tiếng Faroe", "fr_CA|Tiếng Pháp (Canada)", "fr_FR|Tiếng Pháp (Pháp)", "fy_NL|Tiếng Frisia", "ga_IE|Tiếng Ai-len", "gl_ES|Tiếng Galic", "gn_PY|Tiếng Guarani", "gu_IN|Tiếng Gujarati", "ha_NG|Tiếng Hausa", "he_IL|Tiếng Do Thái",
			"hi_IN|Tiếng Hin-di (Ấn Độ)", "hr_HR|Tiếng Croatia", "ht_HT|Tiếng Haitian Creole", "hu_HU|Tiếng Hungary", "hy_AM|Tiếng Armenia", "id_ID|Tiếng Indo", "ik_US|Tiếng Inupiaq", "is_IS|Tiếng Iceland", "it_IT|Tiếng Ý", "iu_CA|Tiếng Inuktitut",
			"ja_JP|Tiếng Nhật", "ja_KS|Tiếng Nhật (Kansai)", "jv_ID|Tiếng Java", "ka_GE|Tiếng Georgia", "kk_KZ|Tiếng Kazakh", "km_KH|Tiếng Khơ-me", "kn_IN|Tiếng Kannada", "ko_KR|Tiếng Hàn", "ku_TR|Tiếng Kurdish (Kurmanji)", "ky_KG|Tiếng Kyrgyz",
			"lo_LA|Tiếng Lào", "lt_LT|Tiếng Lithuania", "lv_LV|Tiếng Latvia", "mg_MG|Tiếng Malagasy", "mk_MK|Tiếng Macedoni", "ml_IN|Tiếng Malayalam", "mn_MN|Tiếng Mông Cổ", "mr_IN|Tiếng Marathi", "ms_MY|Tiếng Mã Lai", "mt_MT|Tiếng Malta",
			"my_MM|Tiếng Miến Điện", "nb_NO|Tiếng Na Uy (bokmal)", "ne_NP|Tiếng Nepan", "nl_BE|Tiếng Hà Lan-Bỉ", "nl_NL|Tiếng Hà Lan", "nn_NO|Tiếng Na-uy (nynorsk)", "or_IN|Tiếng Oriya", "pa_IN|Tiếng Punjabi", "pl_PL|Tiếng Ba Lan", "ps_AF|Tiếng Pashto",
			"pt_BR|Tiếng Bồ Đào Nha (Brazil)", "pt_PT|Tiếng Bồ Đào Nha (Bồ Đào Nha)", "ro_RO|Tiếng Rumani", "ru_RU|Tiếng Nga", "rw_RW|Tiếng Kinyarwanda", "sc_IT|Tiếng Sardinia", "si_LK|Tiếng Sinhala", "sk_SK|Tiếng Slovakia", "sl_SI|Tiếng Sloven", "sn_ZW|Tiếng Shona",
			"so_SO|Tiếng Somali", "sq_AL|Tiếng Albani", "sr_RS|Tiếng Serbia", "sv_SE|Tiếng Thụy Điển", "sw_KE|Tiếng Swahili", "sy_SY|Tiếng Syria", "sz_PL|Tiếng Silesia", "ta_IN|Tiếng Tamil", "te_IN|Tiếng Telugu", "tg_TJ|Tiếng Tajik",
			"th_TH|Tiếng Thái", "tl_PH|Tiếng Philippines", "tr_TR|Tiếng Thổ Nhĩ Kỳ", "tt_RU|Tiê\u0301ng Tatar", "tz_MA|Tiếng Tamazight", "uk_UA|Tiếng U-krai-na", "ur_PK|Tiếng Urdu", "uz_UZ|Tiếng Uzbek", "zh_CN|Tiếng Trung giản thể (Trung Quốc)", "zh_HK|Tiếng Trung phồn thể (Hồng Kông)",
			"zh_TW|Tiếng Trung phồn thể (Đài Loan)", "zz_TR|Tiếng Zaza"
		});
		B71EAD91.Location = new System.Drawing.Point(146, 233);
		B71EAD91.Name = "cbbLanguage";
		B71EAD91.Size = new System.Drawing.Size(49, 24);
		B71EAD91.TabIndex = 155;
		CBBB6E04.Cursor = System.Windows.Forms.Cursors.Hand;
		CBBB6E04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		CBBB6E04.DropDownWidth = 120;
		CBBB6E04.FormattingEnabled = true;
		CBBB6E04.Location = new System.Drawing.Point(291, 20);
		CBBB6E04.Name = "cbbGetToken";
		CBBB6E04.Size = new System.Drawing.Size(96, 24);
		CBBB6E04.TabIndex = 10;
		ckbWallPosts.AutoSize = true;
		ckbWallPosts.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWallPosts.Location = new System.Drawing.Point(21, 209);
		ckbWallPosts.Name = "ckbWallPosts";
		ckbWallPosts.Size = new System.Drawing.Size(179, 20);
		ckbWallPosts.TabIndex = 0;
		ckbWallPosts.Text = "Đếm số bài viết trên tường";
		ckbWallPosts.UseVisualStyleBackColor = true;
		ckbWallPosts.Click += new System.EventHandler(C90F0BAD);
		ckbDoiNgonNgu.AutoSize = true;
		ckbDoiNgonNgu.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDoiNgonNgu.Location = new System.Drawing.Point(21, 235);
		ckbDoiNgonNgu.Name = "ckbDoiNgonNgu";
		ckbDoiNgonNgu.Size = new System.Drawing.Size(103, 20);
		ckbDoiNgonNgu.TabIndex = 2;
		ckbDoiNgonNgu.Text = "Đô\u0309i ngôn ngư\u0303";
		ckbDoiNgonNgu.UseVisualStyleBackColor = true;
		ckbDoiNgonNgu.CheckedChanged += new System.EventHandler(E928923A);
		C10D3B3A.AutoSize = true;
		C10D3B3A.Cursor = System.Windows.Forms.Cursors.Hand;
		C10D3B3A.Location = new System.Drawing.Point(238, 209);
		C10D3B3A.Name = "ckbCheckPasswordCorrect";
		C10D3B3A.Size = new System.Drawing.Size(119, 20);
		C10D3B3A.TabIndex = 2;
		C10D3B3A.Text = "Check password";
		C10D3B3A.UseVisualStyleBackColor = true;
		BB3F5B11.AutoSize = true;
		BB3F5B11.Cursor = System.Windows.Forms.Cursors.Hand;
		BB3F5B11.Location = new System.Drawing.Point(238, 183);
		BB3F5B11.Name = "ckbCheckCreateProfile";
		BB3F5B11.Size = new System.Drawing.Size(140, 20);
		BB3F5B11.TabIndex = 2;
		BB3F5B11.Text = "Check create profile";
		BB3F5B11.UseVisualStyleBackColor = true;
		ckbCapNhatThongTinTruocKhiTuongTac.AutoSize = true;
		ckbCapNhatThongTinTruocKhiTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCapNhatThongTinTruocKhiTuongTac.Location = new System.Drawing.Point(255, 48);
		ckbCapNhatThongTinTruocKhiTuongTac.Name = "ckbCapNhatThongTinTruocKhiTuongTac";
		ckbCapNhatThongTinTruocKhiTuongTac.Size = new System.Drawing.Size(138, 20);
		ckbCapNhatThongTinTruocKhiTuongTac.TabIndex = 2;
		ckbCapNhatThongTinTruocKhiTuongTac.Text = "Trươ\u0301c khi tương ta\u0301c";
		ckbCapNhatThongTinTruocKhiTuongTac.UseVisualStyleBackColor = true;
		ckbCapNhatThongTinTruocKhiTuongTac.Visible = false;
		ckbCapNhatThongTinTruocKhiTuongTac.CheckedChanged += new System.EventHandler(FD2F161D);
		E3041E25.AutoSize = true;
		E3041E25.Cursor = System.Windows.Forms.Cursors.Hand;
		E3041E25.Location = new System.Drawing.Point(238, 235);
		E3041E25.Name = "ckbCheckMetaVerified";
		E3041E25.Size = new System.Drawing.Size(140, 20);
		E3041E25.TabIndex = 2;
		E3041E25.Text = "Check Meta Verified";
		E3041E25.UseVisualStyleBackColor = true;
		ADA7CA14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		ADA7CA14.Controls.Add(ckbHometown);
		ADA7CA14.Controls.Add(ckbLocation);
		ADA7CA14.Controls.Add(ckbNgayTao);
		ADA7CA14.Controls.Add(ckbPagePro5);
		ADA7CA14.Controls.Add(ckbEmail);
		ADA7CA14.Controls.Add(E91308A9);
		ADA7CA14.Controls.Add(ckbFbBlock);
		ADA7CA14.Controls.Add(A1858F13);
		ADA7CA14.Controls.Add(ckbDating);
		ADA7CA14.Controls.Add(ckbAvatar);
		ADA7CA14.Controls.Add(ckbPhone);
		ADA7CA14.Controls.Add(ckbFollow);
		ADA7CA14.Controls.Add(FF275AAF);
		ADA7CA14.Controls.Add(ckbFriend);
		ADA7CA14.Controls.Add(ckbBirthday);
		ADA7CA14.Controls.Add(ckbGender);
		ADA7CA14.Controls.Add(ckbName);
		ADA7CA14.Location = new System.Drawing.Point(21, 70);
		ADA7CA14.Name = "plCapNhatThongTin";
		ADA7CA14.Size = new System.Drawing.Size(366, 107);
		ADA7CA14.TabIndex = 14;
		ckbHometown.AutoSize = true;
		ckbHometown.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHometown.Location = new System.Drawing.Point(95, 82);
		ckbHometown.Name = "ckbHometown";
		ckbHometown.Size = new System.Drawing.Size(163, 20);
		ckbHometown.TabIndex = 0;
		ckbHometown.Text = "Hometown, Current City";
		ckbHometown.UseVisualStyleBackColor = true;
		ckbLocation.AutoSize = true;
		ckbLocation.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLocation.Location = new System.Drawing.Point(4, 82);
		ckbLocation.Name = "ckbLocation";
		ckbLocation.Size = new System.Drawing.Size(73, 20);
		ckbLocation.TabIndex = 0;
		ckbLocation.Text = "Location";
		ckbLocation.UseVisualStyleBackColor = true;
		ckbNgayTao.AutoSize = true;
		ckbNgayTao.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbNgayTao.Location = new System.Drawing.Point(282, 4);
		ckbNgayTao.Name = "ckbNgayTao";
		ckbNgayTao.Size = new System.Drawing.Size(76, 20);
		ckbNgayTao.TabIndex = 0;
		ckbNgayTao.Text = "Ngày tạo";
		ckbNgayTao.UseVisualStyleBackColor = true;
		ckbPagePro5.AutoSize = true;
		ckbPagePro5.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPagePro5.Location = new System.Drawing.Point(4, 56);
		ckbPagePro5.Name = "ckbPagePro5";
		ckbPagePro5.Size = new System.Drawing.Size(54, 20);
		ckbPagePro5.TabIndex = 1;
		ckbPagePro5.Text = "Page";
		ckbPagePro5.UseVisualStyleBackColor = true;
		ckbEmail.AutoSize = true;
		ckbEmail.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbEmail.Location = new System.Drawing.Point(216, 4);
		ckbEmail.Name = "ckbEmail";
		ckbEmail.Size = new System.Drawing.Size(57, 20);
		ckbEmail.TabIndex = 1;
		ckbEmail.Text = "Email";
		ckbEmail.UseVisualStyleBackColor = true;
		E91308A9.AutoSize = true;
		E91308A9.Cursor = System.Windows.Forms.Cursors.Hand;
		E91308A9.Location = new System.Drawing.Point(67, 56);
		E91308A9.Name = "ckbBM";
		E91308A9.Size = new System.Drawing.Size(43, 20);
		E91308A9.TabIndex = 0;
		E91308A9.Text = "BM";
		E91308A9.UseVisualStyleBackColor = true;
		ckbFbBlock.AutoSize = true;
		ckbFbBlock.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFbBlock.Location = new System.Drawing.Point(282, 82);
		ckbFbBlock.Name = "ckbFbBlock";
		ckbFbBlock.Size = new System.Drawing.Size(73, 20);
		ckbFbBlock.TabIndex = 0;
		ckbFbBlock.Text = "Fb Block";
		ckbFbBlock.UseVisualStyleBackColor = true;
		A1858F13.AutoSize = true;
		A1858F13.Cursor = System.Windows.Forms.Cursors.Hand;
		A1858F13.Location = new System.Drawing.Point(216, 56);
		A1858F13.Name = "ckbAds";
		A1858F13.Size = new System.Drawing.Size(47, 20);
		A1858F13.TabIndex = 0;
		A1858F13.Text = "Ads";
		A1858F13.UseVisualStyleBackColor = true;
		ckbDating.AutoSize = true;
		ckbDating.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDating.Location = new System.Drawing.Point(140, 56);
		ckbDating.Name = "ckbDating";
		ckbDating.Size = new System.Drawing.Size(62, 20);
		ckbDating.TabIndex = 0;
		ckbDating.Text = "Dating";
		ckbDating.UseVisualStyleBackColor = true;
		ckbAvatar.AutoSize = true;
		ckbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAvatar.Location = new System.Drawing.Point(282, 30);
		ckbAvatar.Name = "ckbAvatar";
		ckbAvatar.Size = new System.Drawing.Size(63, 20);
		ckbAvatar.TabIndex = 0;
		ckbAvatar.Text = "Avatar";
		ckbAvatar.UseVisualStyleBackColor = true;
		ckbPhone.AutoSize = true;
		ckbPhone.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPhone.Location = new System.Drawing.Point(216, 30);
		ckbPhone.Name = "ckbPhone";
		ckbPhone.Size = new System.Drawing.Size(61, 20);
		ckbPhone.TabIndex = 0;
		ckbPhone.Text = "Phone";
		ckbPhone.UseVisualStyleBackColor = true;
		ckbFollow.AutoSize = true;
		ckbFollow.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFollow.Location = new System.Drawing.Point(140, 30);
		ckbFollow.Name = "ckbFollow";
		ckbFollow.Size = new System.Drawing.Size(63, 20);
		ckbFollow.TabIndex = 0;
		ckbFollow.Text = "Follow";
		ckbFollow.UseVisualStyleBackColor = true;
		FF275AAF.AutoSize = true;
		FF275AAF.Cursor = System.Windows.Forms.Cursors.Hand;
		FF275AAF.Location = new System.Drawing.Point(67, 30);
		FF275AAF.Name = "ckbGroup";
		FF275AAF.Size = new System.Drawing.Size(60, 20);
		FF275AAF.TabIndex = 0;
		FF275AAF.Text = "Group";
		FF275AAF.UseVisualStyleBackColor = true;
		FF275AAF.Click += new System.EventHandler(FF275AAF_Click);
		ckbFriend.AutoSize = true;
		ckbFriend.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbFriend.Location = new System.Drawing.Point(4, 30);
		ckbFriend.Name = "ckbFriend";
		ckbFriend.Size = new System.Drawing.Size(62, 20);
		ckbFriend.TabIndex = 0;
		ckbFriend.Text = "Friend";
		ckbFriend.UseVisualStyleBackColor = true;
		ckbBirthday.AutoSize = true;
		ckbBirthday.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBirthday.Location = new System.Drawing.Point(140, 4);
		ckbBirthday.Name = "ckbBirthday";
		ckbBirthday.Size = new System.Drawing.Size(72, 20);
		ckbBirthday.TabIndex = 0;
		ckbBirthday.Text = "Birthday";
		ckbBirthday.UseVisualStyleBackColor = true;
		ckbGender.AutoSize = true;
		ckbGender.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGender.Location = new System.Drawing.Point(67, 4);
		ckbGender.Name = "ckbGender";
		ckbGender.Size = new System.Drawing.Size(72, 20);
		ckbGender.TabIndex = 0;
		ckbGender.Text = "Giới tính";
		ckbGender.UseVisualStyleBackColor = true;
		ckbName.AutoSize = true;
		ckbName.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbName.Location = new System.Drawing.Point(4, 4);
		ckbName.Name = "ckbName";
		ckbName.Size = new System.Drawing.Size(59, 20);
		ckbName.TabIndex = 0;
		ckbName.Text = "Name";
		ckbName.UseVisualStyleBackColor = true;
		B80E0C11.Controls.Add(D483029F);
		B80E0C11.Controls.Add(ckbRandomThuTuTaiKhoan);
		B80E0C11.Controls.Add(ckbCreateProfile);
		B80E0C11.Controls.Add(ckbCheckLiveUid);
		B80E0C11.Controls.Add(ckbXoaCache);
		B80E0C11.Location = new System.Drawing.Point(11, 44);
		B80E0C11.Name = "groupBox5";
		B80E0C11.Size = new System.Drawing.Size(397, 72);
		B80E0C11.TabIndex = 13;
		B80E0C11.TabStop = false;
		B80E0C11.Text = "Trước khi chạy";
		D483029F.AutoSize = true;
		D483029F.Cursor = System.Windows.Forms.Cursors.Hand;
		D483029F.Location = new System.Drawing.Point(224, 22);
		D483029F.Name = "ckbXoaProfile";
		D483029F.Size = new System.Drawing.Size(135, 20);
		D483029F.TabIndex = 16;
		D483029F.Text = "Xoá profile chrome";
		D483029F.UseVisualStyleBackColor = true;
		ckbRandomThuTuTaiKhoan.AutoSize = true;
		ckbRandomThuTuTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbRandomThuTuTaiKhoan.Location = new System.Drawing.Point(224, 46);
		ckbRandomThuTuTaiKhoan.Name = "ckbRandomThuTuTaiKhoan";
		ckbRandomThuTuTaiKhoan.Size = new System.Drawing.Size(170, 20);
		ckbRandomThuTuTaiKhoan.TabIndex = 15;
		ckbRandomThuTuTaiKhoan.Text = "Xáo trộn thứ tự tài khoản";
		ckbRandomThuTuTaiKhoan.UseVisualStyleBackColor = true;
		ckbCheckLiveUid.AutoSize = true;
		ckbCheckLiveUid.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCheckLiveUid.Location = new System.Drawing.Point(13, 46);
		ckbCheckLiveUid.Name = "ckbCheckLiveUid";
		ckbCheckLiveUid.Size = new System.Drawing.Size(135, 20);
		ckbCheckLiveUid.TabIndex = 2;
		ckbCheckLiveUid.Text = "Check wall account";
		ckbCheckLiveUid.UseVisualStyleBackColor = true;
		ckbXoaCache.AutoSize = true;
		ckbXoaCache.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbXoaCache.Location = new System.Drawing.Point(224, 22);
		ckbXoaCache.Name = "ckbXoaCache";
		ckbXoaCache.Size = new System.Drawing.Size(132, 20);
		ckbXoaCache.TabIndex = 9;
		ckbXoaCache.Text = "Xoá cache chrome";
		ckbXoaCache.UseVisualStyleBackColor = true;
		ckbPublicPost.AutoSize = true;
		ckbPublicPost.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbPublicPost.Location = new System.Drawing.Point(531, 541);
		ckbPublicPost.Name = "ckbPublicPost";
		ckbPublicPost.Size = new System.Drawing.Size(247, 20);
		ckbPublicPost.TabIndex = 0;
		ckbPublicPost.Text = "Đặt chế độ công khai khi đăng bài (ẩn)";
		ckbPublicPost.UseVisualStyleBackColor = true;
		F9B713B0.Controls.Add(button2);
		F9B713B0.Controls.Add(label2);
		F9B713B0.Controls.Add(button1);
		F9B713B0.Controls.Add(cbbFacebookWeb);
		F9B713B0.Controls.Add(label3);
		F9B713B0.Controls.Add(cbbTypeLogin);
		F9B713B0.Controls.Add(ckbDontSaveBrowser);
		F9B713B0.Location = new System.Drawing.Point(11, 122);
		F9B713B0.Name = "grLogin";
		F9B713B0.Size = new System.Drawing.Size(397, 51);
		F9B713B0.TabIndex = 12;
		F9B713B0.TabStop = false;
		F9B713B0.Text = "Đăng nhập";
		button2.BackColor = System.Drawing.Color.White;
		button2.BackgroundImage = (System.Drawing.Image)resources.GetObject("button2.BackgroundImage");
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Location = new System.Drawing.Point(341, 8);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(25, 25);
		button2.TabIndex = 160;
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		button1.BackColor = System.Drawing.Color.White;
		button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Location = new System.Drawing.Point(372, 8);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(25, 25);
		button1.TabIndex = 161;
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		cbbFacebookWeb.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbFacebookWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbFacebookWeb.DropDownWidth = 120;
		cbbFacebookWeb.FormattingEnabled = true;
		cbbFacebookWeb.Items.AddRange(new object[4] { "m.fb", "www", "mbasic", "www->m.fb" });
		cbbFacebookWeb.Location = new System.Drawing.Point(118, 51);
		cbbFacebookWeb.Name = "cbbFacebookWeb";
		cbbFacebookWeb.Size = new System.Drawing.Size(181, 24);
		cbbFacebookWeb.TabIndex = 10;
		cbbTypeLogin.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTypeLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTypeLogin.DropDownWidth = 120;
		cbbTypeLogin.FormattingEnabled = true;
		cbbTypeLogin.Items.AddRange(new object[4] { "Uid|Pass", "Email|Pass", "Cookie", "Cookie>Pass" });
		cbbTypeLogin.Location = new System.Drawing.Point(118, 21);
		cbbTypeLogin.Name = "cbbTypeLogin";
		cbbTypeLogin.Size = new System.Drawing.Size(181, 24);
		cbbTypeLogin.TabIndex = 10;
		ckbDontSaveBrowser.AutoSize = true;
		ckbDontSaveBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDontSaveBrowser.Location = new System.Drawing.Point(12, 81);
		ckbDontSaveBrowser.Name = "ckbDontSaveBrowser";
		ckbDontSaveBrowser.Size = new System.Drawing.Size(244, 20);
		ckbDontSaveBrowser.TabIndex = 2;
		ckbDontSaveBrowser.Text = "Không lưu trình duyệt khi facebook hỏi";
		ckbDontSaveBrowser.UseVisualStyleBackColor = true;
		D3AD12B0.AutoSize = true;
		D3AD12B0.Cursor = System.Windows.Forms.Cursors.Hand;
		D3AD12B0.Location = new System.Drawing.Point(671, 518);
		D3AD12B0.Name = "ckbPrivateInfo";
		D3AD12B0.Size = new System.Drawing.Size(149, 20);
		D3AD12B0.TabIndex = 2;
		D3AD12B0.Text = "Â\u0309n thông tin nick (ẩn)";
		D3AD12B0.UseVisualStyleBackColor = true;
		ckbDisableChatSettings.AutoSize = true;
		ckbDisableChatSettings.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDisableChatSettings.Location = new System.Drawing.Point(531, 518);
		ckbDisableChatSettings.Name = "ckbDisableChatSettings";
		ckbDisableChatSettings.Size = new System.Drawing.Size(140, 20);
		ckbDisableChatSettings.TabIndex = 2;
		ckbDisableChatSettings.Text = "Tắt Popup chat (ẩn)";
		ckbDisableChatSettings.UseVisualStyleBackColor = true;
		C3233E90.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		C3233E90.Controls.Add(plChonKichBan);
		C3233E90.Controls.Add(ckbChayKichBanDaGan);
		C3233E90.Controls.Add(btnDown);
		C3233E90.Controls.Add(btnUp);
		C3233E90.Controls.Add(plGioiHanThoiGianChayKichBan);
		C3233E90.Controls.Add(plRepeatAll);
		C3233E90.Controls.Add(plGioiHanThoiGianChayTaiKhoan);
		C3233E90.Controls.Add(ckbGioiHanThoiGianChayKichBan);
		C3233E90.Controls.Add(ckbRepeatAll);
		C3233E90.Controls.Add(ckbGioiHanThoiGianChayTaiKhoan);
		C3233E90.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C3233E90.Location = new System.Drawing.Point(11, 179);
		C3233E90.Name = "groupBox2";
		C3233E90.Size = new System.Drawing.Size(397, 152);
		C3233E90.TabIndex = 7;
		C3233E90.TabStop = false;
		C3233E90.Text = "Tương tác";
		plChonKichBan.Controls.Add(EBB25FAB);
		plChonKichBan.Controls.Add(cbbKichBan);
		plChonKichBan.Controls.Add(btnQuanLyKichBan);
		plChonKichBan.Location = new System.Drawing.Point(7, 41);
		plChonKichBan.Name = "plChonKichBan";
		plChonKichBan.Size = new System.Drawing.Size(387, 26);
		plChonKichBan.TabIndex = 14;
		EBB25FAB.AutoSize = true;
		EBB25FAB.Location = new System.Drawing.Point(3, 4);
		EBB25FAB.Name = "label1";
		EBB25FAB.Size = new System.Drawing.Size(92, 16);
		EBB25FAB.TabIndex = 0;
		EBB25FAB.Text = "Chọn kịch bản:";
		cbbKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbKichBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbKichBan.DropDownWidth = 300;
		cbbKichBan.FormattingEnabled = true;
		cbbKichBan.Location = new System.Drawing.Point(111, 1);
		cbbKichBan.Name = "cbbKichBan";
		cbbKichBan.Size = new System.Drawing.Size(181, 24);
		cbbKichBan.TabIndex = 1;
		btnQuanLyKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
		btnQuanLyKichBan.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnQuanLyKichBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnQuanLyKichBan.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnQuanLyKichBan.Location = new System.Drawing.Point(298, 1);
		btnQuanLyKichBan.Name = "btnQuanLyKichBan";
		btnQuanLyKichBan.Size = new System.Drawing.Size(86, 24);
		btnQuanLyKichBan.TabIndex = 1;
		btnQuanLyKichBan.Text = "Quản lý";
		btnQuanLyKichBan.Click += new System.EventHandler(btnQuanLyKichBan_Click);
		ckbChayKichBanDaGan.AutoSize = true;
		ckbChayKichBanDaGan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbChayKichBanDaGan.Location = new System.Drawing.Point(12, 17);
		ckbChayKichBanDaGan.Name = "ckbChayKichBanDaGan";
		ckbChayKichBanDaGan.Size = new System.Drawing.Size(234, 20);
		ckbChayKichBanDaGan.TabIndex = 162;
		ckbChayKichBanDaGan.Text = "Chạy kịch bản đã gán từng tài khoản";
		ckbChayKichBanDaGan.UseVisualStyleBackColor = true;
		ckbChayKichBanDaGan.Visible = false;
		ckbChayKichBanDaGan.CheckedChanged += new System.EventHandler(D216BF21);
		btnDown.BackColor = System.Drawing.Color.White;
		btnDown.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnDown.BackgroundImage");
		btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnDown.Location = new System.Drawing.Point(341, 8);
		btnDown.Name = "btnDown";
		btnDown.Size = new System.Drawing.Size(25, 25);
		btnDown.TabIndex = 160;
		btnDown.UseVisualStyleBackColor = false;
		btnDown.Click += new System.EventHandler(AA2F3D28);
		btnUp.BackColor = System.Drawing.Color.White;
		btnUp.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnUp.BackgroundImage");
		btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
		btnUp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnUp.Location = new System.Drawing.Point(372, 8);
		btnUp.Name = "btnUp";
		btnUp.Size = new System.Drawing.Size(25, 25);
		btnUp.TabIndex = 161;
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += new System.EventHandler(btnUp_Click);
		plGioiHanThoiGianChayKichBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plGioiHanThoiGianChayKichBan.Controls.Add(C7A0FABD);
		plGioiHanThoiGianChayKichBan.Controls.Add(nudThoiGianChayKichBanTo);
		plGioiHanThoiGianChayKichBan.Controls.Add(C71A900B);
		plGioiHanThoiGianChayKichBan.Location = new System.Drawing.Point(269, 118);
		plGioiHanThoiGianChayKichBan.Name = "plGioiHanThoiGianChayKichBan";
		plGioiHanThoiGianChayKichBan.Size = new System.Drawing.Size(121, 27);
		plGioiHanThoiGianChayKichBan.TabIndex = 17;
		C7A0FABD.AutoSize = true;
		C7A0FABD.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C7A0FABD.Location = new System.Drawing.Point(50, 4);
		C7A0FABD.Name = "label7";
		C7A0FABD.Size = new System.Drawing.Size(18, 16);
		C7A0FABD.TabIndex = 4;
		C7A0FABD.Text = ">";
		nudThoiGianChayKichBanTo.Location = new System.Drawing.Point(69, 1);
		nudThoiGianChayKichBanTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		nudThoiGianChayKichBanTo.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		nudThoiGianChayKichBanTo.Name = "nudThoiGianChayKichBanTo";
		nudThoiGianChayKichBanTo.Size = new System.Drawing.Size(48, 23);
		nudThoiGianChayKichBanTo.TabIndex = 3;
		nudThoiGianChayKichBanTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		C71A900B.Location = new System.Drawing.Point(1, 1);
		C71A900B.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		C71A900B.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		C71A900B.Name = "nudThoiGianChayKichBanFrom";
		C71A900B.Size = new System.Drawing.Size(48, 23);
		C71A900B.TabIndex = 3;
		C71A900B.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		plRepeatAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plRepeatAll.Controls.Add(label6);
		plRepeatAll.Controls.Add(label4);
		plRepeatAll.Controls.Add(nudDelayTurnFrom);
		plRepeatAll.Controls.Add(C303D92C);
		plRepeatAll.Controls.Add(D996DE84);
		plRepeatAll.Controls.Add(label11);
		plRepeatAll.Controls.Add(BFBADA88);
		plRepeatAll.Controls.Add(C68A59B4);
		plRepeatAll.Location = new System.Drawing.Point(32, 173);
		plRepeatAll.Name = "plRepeatAll";
		plRepeatAll.Size = new System.Drawing.Size(358, 64);
		plRepeatAll.TabIndex = 13;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(3, 8);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(83, 16);
		label6.TabIndex = 5;
		label6.Text = "Sô\u0301 lươ\u0323t cha\u0323y:";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(3, 36);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(144, 16);
		label4.TabIndex = 6;
		label4.Text = "Chờ cha\u0323y lươ\u0323t tiê\u0301p theo:";
		nudDelayTurnFrom.Location = new System.Drawing.Point(154, 34);
		nudDelayTurnFrom.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		nudDelayTurnFrom.Name = "nudDelayTurnFrom";
		nudDelayTurnFrom.Size = new System.Drawing.Size(65, 23);
		nudDelayTurnFrom.TabIndex = 9;
		C303D92C.Location = new System.Drawing.Point(222, 9);
		C303D92C.Name = "label5";
		C303D92C.Size = new System.Drawing.Size(30, 16);
		C303D92C.TabIndex = 10;
		C303D92C.Text = "lươ\u0323t";
		C303D92C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		C303D92C.Click += new System.EventHandler(E28AE398);
		D996DE84.Location = new System.Drawing.Point(244, 34);
		D996DE84.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		D996DE84.Name = "nudDelayTurnTo";
		D996DE84.Size = new System.Drawing.Size(65, 23);
		D996DE84.TabIndex = 8;
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(310, 37);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(32, 16);
		label11.TabIndex = 11;
		label11.Text = "phút";
		BFBADA88.Location = new System.Drawing.Point(154, 6);
		BFBADA88.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		BFBADA88.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		BFBADA88.Name = "nudSoLuotChay";
		BFBADA88.Size = new System.Drawing.Size(65, 23);
		BFBADA88.TabIndex = 7;
		BFBADA88.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		C68A59B4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		C68A59B4.Location = new System.Drawing.Point(219, 37);
		C68A59B4.Name = "label10";
		C68A59B4.Size = new System.Drawing.Size(24, 16);
		C68A59B4.TabIndex = 12;
		C68A59B4.Text = ">";
		C68A59B4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		plGioiHanThoiGianChayTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plGioiHanThoiGianChayTaiKhoan.Controls.Add(label13);
		plGioiHanThoiGianChayTaiKhoan.Controls.Add(B52AAC1A);
		plGioiHanThoiGianChayTaiKhoan.Controls.Add(A52E7A3F);
		plGioiHanThoiGianChayTaiKhoan.Location = new System.Drawing.Point(269, 82);
		plGioiHanThoiGianChayTaiKhoan.Name = "plGioiHanThoiGianChayTaiKhoan";
		plGioiHanThoiGianChayTaiKhoan.Size = new System.Drawing.Size(121, 27);
		plGioiHanThoiGianChayTaiKhoan.TabIndex = 18;
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(50, 4);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(18, 16);
		label13.TabIndex = 4;
		label13.Text = ">";
		B52AAC1A.Location = new System.Drawing.Point(69, 1);
		B52AAC1A.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		B52AAC1A.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		B52AAC1A.Name = "nudThoiGianChayTaiKhoanTo";
		B52AAC1A.Size = new System.Drawing.Size(48, 23);
		B52AAC1A.TabIndex = 3;
		B52AAC1A.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		A52E7A3F.Location = new System.Drawing.Point(1, 1);
		A52E7A3F.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
		A52E7A3F.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		A52E7A3F.Name = "nudThoiGianChayTaiKhoanFrom";
		A52E7A3F.Size = new System.Drawing.Size(48, 23);
		A52E7A3F.TabIndex = 3;
		A52E7A3F.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		ckbGioiHanThoiGianChayKichBan.AutoSize = true;
		ckbGioiHanThoiGianChayKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGioiHanThoiGianChayKichBan.Location = new System.Drawing.Point(12, 122);
		ckbGioiHanThoiGianChayKichBan.Name = "ckbGioiHanThoiGianChayKichBan";
		ckbGioiHanThoiGianChayKichBan.Size = new System.Drawing.Size(246, 20);
		ckbGioiHanThoiGianChayKichBan.TabIndex = 15;
		ckbGioiHanThoiGianChayKichBan.Text = "Giới hạn thời gian chạy/kịch bản (phút)";
		ckbGioiHanThoiGianChayKichBan.UseVisualStyleBackColor = true;
		ckbGioiHanThoiGianChayKichBan.CheckedChanged += new System.EventHandler(ckbGioiHanThoiGianChayKichBan_CheckedChanged);
		ckbRepeatAll.AutoSize = true;
		ckbRepeatAll.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbRepeatAll.Location = new System.Drawing.Point(12, 151);
		ckbRepeatAll.Name = "ckbRepeatAll";
		ckbRepeatAll.Size = new System.Drawing.Size(344, 20);
		ckbRepeatAll.TabIndex = 2;
		ckbRepeatAll.Text = "Chạy tương tác lại toàn bộ tài khoản sau khi hoàn thành";
		ckbRepeatAll.UseVisualStyleBackColor = true;
		ckbRepeatAll.CheckedChanged += new System.EventHandler(ckbRepeatAll_CheckedChanged);
		ckbGioiHanThoiGianChayTaiKhoan.AutoSize = true;
		ckbGioiHanThoiGianChayTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGioiHanThoiGianChayTaiKhoan.Location = new System.Drawing.Point(12, 85);
		ckbGioiHanThoiGianChayTaiKhoan.Name = "ckbGioiHanThoiGianChayTaiKhoan";
		ckbGioiHanThoiGianChayTaiKhoan.Size = new System.Drawing.Size(249, 20);
		ckbGioiHanThoiGianChayTaiKhoan.TabIndex = 16;
		ckbGioiHanThoiGianChayTaiKhoan.Text = "Giới hạn thời gian chạy/tài khoản (giây)";
		ckbGioiHanThoiGianChayTaiKhoan.UseVisualStyleBackColor = true;
		ckbGioiHanThoiGianChayTaiKhoan.CheckedChanged += new System.EventHandler(FF1F9690);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(822, 385);
		base.Controls.Add(bunifuCards1);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fCauHinhTuongTac";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fAddFile";
		base.Load += new System.EventHandler(fCauHinhTuongTac_Load);
		bunifuCards1.ResumeLayout(false);
		A83E1691.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		groupBox6.ResumeLayout(false);
		groupBox6.PerformLayout();
		ADA7CA14.ResumeLayout(false);
		ADA7CA14.PerformLayout();
		B80E0C11.ResumeLayout(false);
		B80E0C11.PerformLayout();
		F9B713B0.ResumeLayout(false);
		F9B713B0.PerformLayout();
		C3233E90.ResumeLayout(false);
		C3233E90.PerformLayout();
		plChonKichBan.ResumeLayout(false);
		plChonKichBan.PerformLayout();
		plGioiHanThoiGianChayKichBan.ResumeLayout(false);
		plGioiHanThoiGianChayKichBan.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudThoiGianChayKichBanTo).EndInit();
		((System.ComponentModel.ISupportInitialize)C71A900B).EndInit();
		plRepeatAll.ResumeLayout(false);
		plRepeatAll.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)D996DE84).EndInit();
		((System.ComponentModel.ISupportInitialize)BFBADA88).EndInit();
		plGioiHanThoiGianChayTaiKhoan.ResumeLayout(false);
		plGioiHanThoiGianChayTaiKhoan.PerformLayout();
		((System.ComponentModel.ISupportInitialize)B52AAC1A).EndInit();
		((System.ComponentModel.ISupportInitialize)A52E7A3F).EndInit();
		ResumeLayout(false);
	}
}
