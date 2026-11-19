using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fThemHanhDong : Form
{
	[Serializable]
	[CompilerGenerated]
	private sealed class BD31A9A1
	{
		internal static readonly BD31A9A1 _003C_003E9 = new BD31A9A1();

		internal static Func<PropertyInfo, bool> _003C_003E9__2_0;

		internal bool B394D89F(PropertyInfo propertyInfo_0)
		{
			return propertyInfo_0.PropertyType == typeof(bool);
		}
	}

	internal string string_0;

	internal IContainer F48C36B9 = null;

	internal GroupBox groupBox5;

	internal PictureBox pictureBox5;

	internal Panel E12FE49D;

	internal Button metroButton2;

	internal Button C2B98F1B;

	internal Button metroButton11;

	internal Button D536689C;

	internal Button CE968AA0;

	internal Button metroButton73;

	internal Button metroButton4;

	internal Button metroButton3;

	internal Button btnAddMail;

	internal Button D6B0C9B0;

	internal Button metroButton46;

	internal GroupBox groupBox6;

	internal PictureBox DE13053A;

	internal Panel panel8;

	internal Button metroButton75;

	internal Button CEA4C9BF;

	internal Button CDB00AA6;

	internal Button button3;

	internal Button button6;

	internal Button button9;

	internal Button metroButton63;

	internal Button metroButton30;

	internal Button B2813923;

	internal Button button1;

	internal Button metroButton32;

	internal Button metroButton33;

	internal Button metroButton28;

	internal GroupBox groupBox4;

	internal Panel panel5;

	internal Button D3B3159C;

	internal Button metroButton23;

	internal Button metroButton14;

	internal Button CD3D6A30;

	internal Button BA3EBC9E;

	internal Button D13B1803;

	internal Button CB37A41B;

	internal Button metroButton17;

	internal Button metroButton16;

	internal Button metroButton9;

	internal Button metroButton41;

	internal PictureBox pictureBox4;

	internal GroupBox AB2E8DB5;

	internal PictureBox D4BB9908;

	internal Panel C4918A9D;

	internal Button D13F38BC;

	internal Button F4212333;

	internal Button C996E22B;

	internal Button E1247622;

	internal Button metroButton31;

	internal Button metroButton70;

	internal Button CC9FD539;

	internal Button btnDangBaiV2;

	internal Button metroButton20;

	internal Button metroButton37;

	internal Button metroButton24;

	internal Button C401E4B0;

	internal Button metroButton56;

	internal GroupBox C498CAB3;

	internal Panel B4140AAB;

	internal Button metroButton59;

	internal Button E1860802;

	internal Button metroButton7;

	internal Button BF9C2CA7;

	internal Button metroButton35;

	internal Button metroButton6;

	internal Button metroButton66;

	internal PictureBox pictureBox3;

	internal GroupBox groupBox2;

	internal Panel EA3EA72F;

	internal Button metroButton78;

	internal Button A3B87B1B;

	internal Button metroButton62;

	internal Button BA1E9FA9;

	internal Button metroButton65;

	internal Button metroButton69;

	internal Button metroButton77;

	internal Button button4;

	internal Button button2;

	internal Button btnDangReel;

	internal PictureBox pictureBox2;

	internal Button btnKichHoatPageVhh;

	internal Button DA05193F;

	internal Button button10;

	internal Button C2084506;

	internal Button button7;

	internal Button C026BA07;

	internal Button FC927B25;

	internal Button C1B9173C;

	internal Panel panel1;

	internal BunifuCards E6B11382;

	internal Panel A730AF01;

	internal Button button31;

	internal PictureBox E83F5DA0;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal BunifuDragControl A6B0C53E;

	internal BunifuDragControl CE9D002D;

	internal Button B40C4C20;

	internal Button button12;

	internal Button btnReport;

	internal Button btnTangTuongTac;

	internal Button A38FFFB1;

	public fThemHanhDong(string string_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		string_0 = string_1;
		DA05193F.Visible = Base.bool_0;
		button6.Visible = !Base.bool_0;
		btnReport.Visible = Base.bool_8;
		base.Icon = Class155.D596C6A5;
		E83F5DA0.Image = Class155.DD225F0D;
	}

	private bool method_0(Form form_0)
	{
		try
		{
			Commom.smethod_35(form_0);
			Type type = form_0.GetType();
			PropertyInfo property = type.GetProperty("isSave", BindingFlags.Static | BindingFlags.Public);
			if (property != null && property.PropertyType == typeof(bool) && (bool)property.GetValue(null))
			{
				Close();
				return true;
			}
			List<PropertyInfo> list = (from propertyInfo_0 in type.GetProperties(BindingFlags.Static | BindingFlags.Public)
				where propertyInfo_0.PropertyType == typeof(bool)
				select propertyInfo_0).ToList();
			if (list.Count == 0)
			{
				return false;
			}
			foreach (PropertyInfo item in list)
			{
				if ((bool)item.GetValue(null))
				{
					Close();
					return true;
				}
			}
			return false;
		}
		catch (Exception exception_)
		{
			Commom.smethod_58(exception_, "ShowActionForm(" + form_0.GetType().Name + ")");
			MsBoxHelper.Show("Đã có lỗi xảy ra, vui lòng liên hệ Admin!", 2);
			return false;
		}
	}

	private void A3B87B1B_Click(object sender, EventArgs e)
	{
		method_0(new fHDDocThongBao(string_0));
	}

	private void DEA05E23(object sender, EventArgs e)
	{
		method_0(new fHDXemStory(string_0));
	}

	private void metroButton65_Click(object sender, EventArgs e)
	{
		method_0(new fHDXemWatch(string_0));
	}

	private void metroButton69_Click(object sender, EventArgs e)
	{
		method_0(new fHDChocBanBe(string_0));
	}

	private void metroButton78_Click(object sender, EventArgs e)
	{
		method_0(new fHDChucMungSinhNhat(string_0));
	}

	private void F11FB9A8(object sender, EventArgs e)
	{
		method_0(new fHDDangStatus(string_0));
	}

	private void metroButton77_Click(object sender, EventArgs e)
	{
		method_0(new fHDDangStory(string_0));
	}

	private void E1860802_Click(object sender, EventArgs e)
	{
		if (Base.DB801CBD)
		{
			method_0(new fHDBaiVietNewsfeed2(string_0));
		}
		else
		{
			method_0(new fHDBaiVietNewsfeed(string_0));
		}
	}

	private void metroButton7_Click(object sender, EventArgs e)
	{
		method_0(new fHDBaiVietBanBe(string_0));
	}

	private void FD80E001(object sender, EventArgs e)
	{
		method_0(new fHDBaiVietNhom(string_0));
	}

	private void BF9C2CA7_Click(object sender, EventArgs e)
	{
		method_0(new fHDBaiVietFanpage(string_0));
	}

	private void metroButton59_Click(object sender, EventArgs e)
	{
		method_0(new fHDBaiVietTrenTuong(string_0));
	}

	private void metroButton35_Click(object sender, EventArgs e)
	{
		method_0(new fHDNghiGiaiLao(string_0));
	}

	private void C026BA07_Click(object sender, EventArgs e)
	{
	}

	private void DCA3AF11(object sender, EventArgs e)
	{
		method_0(new fHDKetBanTheoTuKhoa(string_0));
	}

	private void D13B1803_Click(object sender, EventArgs e)
	{
		method_0(new fHDKetBanGoiY(string_0));
	}

	private void CB37A41B_Click(object sender, EventArgs e)
	{
		method_0(new fHDXacNhanKetBan(string_0));
	}

	private void metroButton9_Click(object sender, EventArgs e)
	{
		method_0(new fHDKetBanTepUid(string_0));
	}

	private void BA3EBC9E_Click(object sender, EventArgs e)
	{
		method_0(new fHDHuyLoiMoiKetBan(string_0));
	}

	private void metroButton17_Click(object sender, EventArgs e)
	{
		method_0(new fHDHuyKetBan(string_0));
	}

	private void D29D688F(object sender, EventArgs e)
	{
		method_0(new fHDKetBanThanhVienNhom(string_0));
	}

	private void metroButton41_Click(object sender, EventArgs e)
	{
		method_0(new fHDKetBanVoiBanBeCuaUid(string_0));
	}

	private void CE316539(object sender, EventArgs e)
	{
		method_0(new fHDThamGiaNhomGoiY(string_0));
	}

	private void BEABE599(object sender, EventArgs e)
	{
		method_0(new fHDThamGiaNhomTuKhoa(string_0));
	}

	private void F4B18B9C(object sender, EventArgs e)
	{
		method_0(new fHDThamGiaNhomUid(string_0));
	}

	private void DF1DC11F(object sender, EventArgs e)
	{
		method_0(new fHDBuffLikeComment(string_0));
	}

	private void E1247622_Click(object sender, EventArgs e)
	{
		method_0(new fHDBuffFollowCaNhan(string_0));
	}

	private void metroButton31_Click(object sender, EventArgs e)
	{
		method_0(new fHDBuffFollowLikePage(string_0));
	}

	private void C401E4B0_Click(object sender, EventArgs e)
	{
		method_0(new fHDBuffTinNhanProfile(string_0));
	}

	private void metroButton24_Click(object sender, EventArgs e)
	{
		method_0(new fHDSpamBaiViet(string_0));
	}

	private void E214F21C(object sender, EventArgs e)
	{
		method_0(new fHDDangBai(string_0));
	}

	private void btnDangBaiV2_Click(object sender, EventArgs e)
	{
		method_0(new fHDDangBaiV2(string_0));
	}

	private void metroButton37_Click(object sender, EventArgs e)
	{
		method_0(new fHDShareBai(string_0));
	}

	private void metroButton70_Click(object sender, EventArgs e)
	{
		method_0(new fHDPhanHoiBinhLuan(string_0));
	}

	private void F4212333_Click(object sender, EventArgs e)
	{
		method_0(new fHDDangStatusV2(string_0));
	}

	private void C996E22B_Click(object sender, EventArgs e)
	{
		method_0(new fHDTuongTacLivestream(string_0));
	}

	private void metroButton56_Click(object sender, EventArgs e)
	{
		method_0(new fHDMoiLikePage(string_0));
	}

	private void F19DAC2B(object sender, EventArgs e)
	{
		method_0(new fHDMoiBanBeVaoNhom(string_0));
	}

	private void B0AD6C96(object sender, EventArgs e)
	{
		method_0(new fHDDoiMatKhau(string_0));
	}

	private void D6B0C9B0_Click(object sender, EventArgs e)
	{
		method_0(new fHDXoaSdt(string_0));
	}

	private void C0059501(object sender, EventArgs e)
	{
		method_0(new fHDAddMail(string_0));
	}

	private void metroButton3_Click(object sender, EventArgs e)
	{
		method_0(new fHDDoiTen(string_0));
	}

	private void F7317002(object sender, EventArgs e)
	{
		method_0(new fHDUpAvatar(string_0));
	}

	private void FB207A87(object sender, EventArgs e)
	{
		method_0(new fHDUpCover(string_0));
	}

	private void BtnTangTuongTac_Click(object sender, EventArgs e)
	{
		method_0(new fHDTangTuongTac(string_0));
	}

	private void DE8E522D(object sender, EventArgs e)
	{
		method_0(new fHDOnOff2FA(string_0));
	}

	private void F31C3C1B(object sender, EventArgs e)
	{
		method_0(new fHDCapNhatThongTin(string_0));
	}

	private void AF86D588(object sender, EventArgs e)
	{
		method_0(new fHDXoaThietBiTinCay(string_0));
	}

	private void AD19D327(object sender, EventArgs e)
	{
		method_0(new fHDDangXuatThietBiCu(string_0));
	}

	private void CE968AA0_Click(object sender, EventArgs e)
	{
		method_0(new fHDRoiNhom(string_0));
	}

	private void metroButton32_Click(object sender, EventArgs e)
	{
		method_0(new fHDTimKiemGoogle(string_0));
	}

	private void metroButton33_Click(object sender, EventArgs e)
	{
		method_0(new fHDTruyCapWebsite(string_0));
	}

	private void B2813923_Click(object sender, EventArgs e)
	{
		method_0(new fHDHuyLikePage(string_0));
	}

	private void metroButton63_Click(object sender, EventArgs e)
	{
		method_0(new fHDLinkToInstagram(string_0));
	}

	private void DE018BAD(object sender, EventArgs e)
	{
		method_0(new fHDHuyLienKetInstagram(string_0));
	}

	private void B698099A(object sender, EventArgs e)
	{
		method_0(new fHDXoaBaiTuong(string_0));
	}

	private void D103583A(object sender, EventArgs e)
	{
		method_0(new fHDKhangSpam(string_0));
	}

	private void CEA4C9BF_Click(object sender, EventArgs e)
	{
		method_0(new fHDBatCheDoChuyenNghiep(string_0));
	}

	private void button3_Click(object sender, EventArgs e)
	{
		method_0(new fHDTaoPage(string_0));
	}

	private void D9B5108F(object sender, EventArgs e)
	{
		method_0(new fHDUnlockProfile(string_0));
	}

	private void BC93873E(object sender, EventArgs e)
	{
		method_0(new fHDTuongTacNhomv2(string_0));
	}

	private void DC235B07(object sender, EventArgs e)
	{
		method_0(new fHDKichHoatPageVhh(string_0));
	}

	private void btnDangReel_Click(object sender, EventArgs e)
	{
		method_0(new fHDDangReel(string_0));
	}

	private void DA05193F_Click(object sender, EventArgs e)
	{
		method_0(new fHDSharePage(string_0));
	}

	private void F223162F(object sender, EventArgs e)
	{
		method_0(new fHDTuongTacBaiVietTuKhoa(string_0));
	}

	private void C2084506_Click(object sender, EventArgs e)
	{
		method_0(new fHDDanhGiaPage(string_0));
	}

	private void CA0E2295(object sender, EventArgs e)
	{
	}

	private void B0B5F283(object sender, EventArgs e)
	{
		method_0(new fHDUptopBaiViet(string_0));
	}

	private void AC350701(object sender, EventArgs e)
	{
		method_0(new fHDScriptGemLogin(string_0));
	}

	private void button31_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button12_Click(object sender, EventArgs e)
	{
		method_0(new fHDTuongTacReelNgauNhien(string_0));
	}

	private void B40C4C20_Click(object sender, EventArgs e)
	{
		method_0(new fHDTuongTacReelChiDinh(string_0));
	}

	private void btnReport_Click(object sender, EventArgs e)
	{
		method_0(new fHDReport(string_0));
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && F48C36B9 != null)
		{
			F48C36B9.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		F48C36B9 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemHanhDong));
		groupBox5 = new System.Windows.Forms.GroupBox();
		pictureBox5 = new System.Windows.Forms.PictureBox();
		E12FE49D = new System.Windows.Forms.Panel();
		metroButton2 = new System.Windows.Forms.Button();
		C2B98F1B = new System.Windows.Forms.Button();
		metroButton11 = new System.Windows.Forms.Button();
		D536689C = new System.Windows.Forms.Button();
		metroButton73 = new System.Windows.Forms.Button();
		metroButton4 = new System.Windows.Forms.Button();
		metroButton3 = new System.Windows.Forms.Button();
		btnAddMail = new System.Windows.Forms.Button();
		D6B0C9B0 = new System.Windows.Forms.Button();
		CE968AA0 = new System.Windows.Forms.Button();
		metroButton46 = new System.Windows.Forms.Button();
		groupBox6 = new System.Windows.Forms.GroupBox();
		DE13053A = new System.Windows.Forms.PictureBox();
		panel8 = new System.Windows.Forms.Panel();
		btnReport = new System.Windows.Forms.Button();
		btnTangTuongTac = new System.Windows.Forms.Button();
		metroButton75 = new System.Windows.Forms.Button();
		CEA4C9BF = new System.Windows.Forms.Button();
		CDB00AA6 = new System.Windows.Forms.Button();
		button9 = new System.Windows.Forms.Button();
		metroButton63 = new System.Windows.Forms.Button();
		metroButton30 = new System.Windows.Forms.Button();
		B2813923 = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		metroButton32 = new System.Windows.Forms.Button();
		metroButton33 = new System.Windows.Forms.Button();
		metroButton28 = new System.Windows.Forms.Button();
		button3 = new System.Windows.Forms.Button();
		button6 = new System.Windows.Forms.Button();
		btnKichHoatPageVhh = new System.Windows.Forms.Button();
		DA05193F = new System.Windows.Forms.Button();
		button7 = new System.Windows.Forms.Button();
		groupBox4 = new System.Windows.Forms.GroupBox();
		panel5 = new System.Windows.Forms.Panel();
		D3B3159C = new System.Windows.Forms.Button();
		metroButton23 = new System.Windows.Forms.Button();
		metroButton14 = new System.Windows.Forms.Button();
		CD3D6A30 = new System.Windows.Forms.Button();
		BA3EBC9E = new System.Windows.Forms.Button();
		D13B1803 = new System.Windows.Forms.Button();
		CB37A41B = new System.Windows.Forms.Button();
		metroButton17 = new System.Windows.Forms.Button();
		metroButton16 = new System.Windows.Forms.Button();
		metroButton9 = new System.Windows.Forms.Button();
		metroButton41 = new System.Windows.Forms.Button();
		pictureBox4 = new System.Windows.Forms.PictureBox();
		AB2E8DB5 = new System.Windows.Forms.GroupBox();
		D4BB9908 = new System.Windows.Forms.PictureBox();
		C4918A9D = new System.Windows.Forms.Panel();
		button10 = new System.Windows.Forms.Button();
		C996E22B = new System.Windows.Forms.Button();
		E1247622 = new System.Windows.Forms.Button();
		D13F38BC = new System.Windows.Forms.Button();
		C2084506 = new System.Windows.Forms.Button();
		metroButton31 = new System.Windows.Forms.Button();
		metroButton70 = new System.Windows.Forms.Button();
		CC9FD539 = new System.Windows.Forms.Button();
		btnDangBaiV2 = new System.Windows.Forms.Button();
		metroButton20 = new System.Windows.Forms.Button();
		metroButton37 = new System.Windows.Forms.Button();
		metroButton24 = new System.Windows.Forms.Button();
		C401E4B0 = new System.Windows.Forms.Button();
		metroButton56 = new System.Windows.Forms.Button();
		F4212333 = new System.Windows.Forms.Button();
		C498CAB3 = new System.Windows.Forms.GroupBox();
		B4140AAB = new System.Windows.Forms.Panel();
		C1B9173C = new System.Windows.Forms.Button();
		metroButton59 = new System.Windows.Forms.Button();
		E1860802 = new System.Windows.Forms.Button();
		metroButton7 = new System.Windows.Forms.Button();
		BF9C2CA7 = new System.Windows.Forms.Button();
		metroButton6 = new System.Windows.Forms.Button();
		B40C4C20 = new System.Windows.Forms.Button();
		metroButton35 = new System.Windows.Forms.Button();
		button12 = new System.Windows.Forms.Button();
		metroButton66 = new System.Windows.Forms.Button();
		C026BA07 = new System.Windows.Forms.Button();
		FC927B25 = new System.Windows.Forms.Button();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		groupBox2 = new System.Windows.Forms.GroupBox();
		EA3EA72F = new System.Windows.Forms.Panel();
		metroButton78 = new System.Windows.Forms.Button();
		A3B87B1B = new System.Windows.Forms.Button();
		metroButton62 = new System.Windows.Forms.Button();
		metroButton65 = new System.Windows.Forms.Button();
		metroButton69 = new System.Windows.Forms.Button();
		metroButton77 = new System.Windows.Forms.Button();
		btnDangReel = new System.Windows.Forms.Button();
		BA1E9FA9 = new System.Windows.Forms.Button();
		button4 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		E6B11382 = new Bunifu.Framework.UI.BunifuCards();
		A730AF01 = new System.Windows.Forms.Panel();
		button31 = new System.Windows.Forms.Button();
		E83F5DA0 = new System.Windows.Forms.PictureBox();
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		A6B0C53E = new Bunifu.Framework.UI.BunifuDragControl(F48C36B9);
		CE9D002D = new Bunifu.Framework.UI.BunifuDragControl(F48C36B9);
		A38FFFB1 = new System.Windows.Forms.Button();
		groupBox5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		E12FE49D.SuspendLayout();
		groupBox6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DE13053A).BeginInit();
		panel8.SuspendLayout();
		groupBox4.SuspendLayout();
		panel5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
		AB2E8DB5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D4BB9908).BeginInit();
		C4918A9D.SuspendLayout();
		C498CAB3.SuspendLayout();
		B4140AAB.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		groupBox2.SuspendLayout();
		EA3EA72F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		panel1.SuspendLayout();
		E6B11382.SuspendLayout();
		A730AF01.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)E83F5DA0).BeginInit();
		SuspendLayout();
		groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		groupBox5.Controls.Add(pictureBox5);
		groupBox5.Controls.Add(E12FE49D);
		groupBox5.Location = new System.Drawing.Point(785, 42);
		groupBox5.Name = "groupBox5";
		groupBox5.Size = new System.Drawing.Size(189, 476);
		groupBox5.TabIndex = 8;
		groupBox5.TabStop = false;
		groupBox5.Text = "Chức năng Đổi thông tin";
		pictureBox5.Image = Class155.Bitmap_17;
		pictureBox5.Location = new System.Drawing.Point(18, 22);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(151, 83);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 1;
		pictureBox5.TabStop = false;
		E12FE49D.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E12FE49D.AutoScroll = true;
		E12FE49D.Controls.Add(metroButton2);
		E12FE49D.Controls.Add(C2B98F1B);
		E12FE49D.Controls.Add(metroButton11);
		E12FE49D.Controls.Add(D536689C);
		E12FE49D.Controls.Add(metroButton73);
		E12FE49D.Controls.Add(A38FFFB1);
		E12FE49D.Controls.Add(metroButton4);
		E12FE49D.Controls.Add(metroButton3);
		E12FE49D.Controls.Add(btnAddMail);
		E12FE49D.Controls.Add(D6B0C9B0);
		E12FE49D.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		E12FE49D.Location = new System.Drawing.Point(1, 120);
		E12FE49D.Name = "panel6";
		E12FE49D.Size = new System.Drawing.Size(187, 351);
		E12FE49D.TabIndex = 14;
		metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton2.Location = new System.Drawing.Point(12, 0);
		metroButton2.Name = "metroButton2";
		metroButton2.Size = new System.Drawing.Size(162, 26);
		metroButton2.TabIndex = 8;
		metroButton2.Text = "Đổi mật khẩu";
		metroButton2.Click += new System.EventHandler(B0AD6C96);
		C2B98F1B.Cursor = System.Windows.Forms.Cursors.Hand;
		C2B98F1B.Location = new System.Drawing.Point(12, 174);
		C2B98F1B.Name = "metroButton12";
		C2B98F1B.Size = new System.Drawing.Size(162, 26);
		C2B98F1B.TabIndex = 8;
		C2B98F1B.Text = "Bật - Tắt 2FA";
		C2B98F1B.Click += new System.EventHandler(DE8E522D);
		metroButton11.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton11.Location = new System.Drawing.Point(12, 145);
		metroButton11.Name = "metroButton11";
		metroButton11.Size = new System.Drawing.Size(162, 26);
		metroButton11.TabIndex = 8;
		this.metroButton11.Text = "Upload ảnh bìa";
		metroButton11.Click += new System.EventHandler(FB207A87);
		D536689C.Cursor = System.Windows.Forms.Cursors.Hand;
		D536689C.Location = new System.Drawing.Point(12, 116);
		D536689C.Name = "metroButton10";
		D536689C.Size = new System.Drawing.Size(162, 26);
		D536689C.TabIndex = 8;
		D536689C.Text = "Up Avatar";
		D536689C.Click += new System.EventHandler(F7317002);
		metroButton73.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton73.Location = new System.Drawing.Point(12, 261);
		metroButton73.Name = "metroButton73";
		metroButton73.Size = new System.Drawing.Size(162, 26);
		metroButton73.TabIndex = 8;
		metroButton73.Text = "Đăng xuất thiết bị cũ";
		metroButton73.Click += new System.EventHandler(AD19D327);
		metroButton4.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton4.Location = new System.Drawing.Point(12, 203);
		metroButton4.Name = "metroButton4";
		metroButton4.Size = new System.Drawing.Size(162, 26);
		metroButton4.TabIndex = 8;
		metroButton4.Text = "Cập nhật thông tin";
		metroButton4.Click += new System.EventHandler(F31C3C1B);
		metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton3.Location = new System.Drawing.Point(12, 87);
		metroButton3.Name = "metroButton3";
		metroButton3.Size = new System.Drawing.Size(162, 26);
		metroButton3.TabIndex = 8;
		metroButton3.Text = "Đổi tên";
		metroButton3.Click += new System.EventHandler(metroButton3_Click);
		btnAddMail.Cursor = System.Windows.Forms.Cursors.Hand;
		btnAddMail.Location = new System.Drawing.Point(12, 58);
		btnAddMail.Name = "btnAddMail";
		btnAddMail.Size = new System.Drawing.Size(162, 26);
		btnAddMail.TabIndex = 8;
		btnAddMail.Text = "Add Mail";
		btnAddMail.Click += new System.EventHandler(C0059501);
		D6B0C9B0.Cursor = System.Windows.Forms.Cursors.Hand;
		D6B0C9B0.Location = new System.Drawing.Point(12, 29);
		D6B0C9B0.Name = "metroButton49";
		D6B0C9B0.Size = new System.Drawing.Size(162, 26);
		D6B0C9B0.TabIndex = 8;
		D6B0C9B0.Text = "Xóa Sđt";
		D6B0C9B0.Click += new System.EventHandler(D6B0C9B0_Click);
		CE968AA0.Cursor = System.Windows.Forms.Cursors.Hand;
		CE968AA0.Location = new System.Drawing.Point(12, 319);
		CE968AA0.Name = "metroButton22";
		CE968AA0.Size = new System.Drawing.Size(162, 26);
		CE968AA0.TabIndex = 2;
		CE968AA0.Text = "Rời nhóm";
		CE968AA0.Click += new System.EventHandler(CE968AA0_Click);
		metroButton46.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton46.Location = new System.Drawing.Point(12, 87);
		metroButton46.Name = "metroButton46";
		metroButton46.Size = new System.Drawing.Size(165, 26);
		metroButton46.TabIndex = 9;
		metroButton46.Text = "Bài viết Nhóm (www)";
		metroButton46.Click += new System.EventHandler(BC93873E);
		groupBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		groupBox6.Controls.Add(DE13053A);
		groupBox6.Controls.Add(panel8);
		groupBox6.Location = new System.Drawing.Point(980, 42);
		groupBox6.Name = "groupBox6";
		groupBox6.Size = new System.Drawing.Size(189, 476);
		groupBox6.TabIndex = 10;
		groupBox6.TabStop = false;
		groupBox6.Text = "Chư\u0301c năng kha\u0301c";
		DE13053A.Image = Class155.Bitmap_5;
		DE13053A.Location = new System.Drawing.Point(18, 22);
		DE13053A.Name = "pictureBox7";
		DE13053A.Size = new System.Drawing.Size(151, 83);
		DE13053A.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		DE13053A.TabIndex = 1;
		DE13053A.TabStop = false;
		panel8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		panel8.AutoScroll = true;
		panel8.Controls.Add(btnReport);
		panel8.Controls.Add(btnTangTuongTac);
		panel8.Controls.Add(metroButton75);
		panel8.Controls.Add(CEA4C9BF);
		panel8.Controls.Add(CDB00AA6);
		panel8.Controls.Add(button9);
		panel8.Controls.Add(metroButton63);
		panel8.Controls.Add(metroButton30);
		panel8.Controls.Add(B2813923);
		panel8.Controls.Add(button1);
		panel8.Controls.Add(metroButton32);
		panel8.Controls.Add(metroButton33);
		panel8.Controls.Add(metroButton28);
		panel8.Controls.Add(button3);
		panel8.Controls.Add(button6);
		panel8.Controls.Add(btnKichHoatPageVhh);
		panel8.Controls.Add(DA05193F);
		panel8.Controls.Add(button7);
		panel8.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		panel8.Location = new System.Drawing.Point(1, 120);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(187, 351);
		panel8.TabIndex = 14;
		btnTangTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
		btnTangTuongTac.Location = new System.Drawing.Point(12, 290);
		btnTangTuongTac.Name = "btnTangTuongTac";
		btnTangTuongTac.Size = new System.Drawing.Size(162, 26);
		btnTangTuongTac.TabIndex = 20;
		btnTangTuongTac.Text = "Tăng tương tác";
		btnTangTuongTac.Click += new System.EventHandler(BtnTangTuongTac_Click);
		btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
		btnReport.Location = new System.Drawing.Point(12, 319);
		btnReport.Name = "btnReport";
		btnReport.Size = new System.Drawing.Size(162, 26);
		btnReport.TabIndex = 14;
		btnReport.Text = "Report";
		btnReport.Click += new System.EventHandler(btnReport_Click);
		metroButton75.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton75.Location = new System.Drawing.Point(12, 174);
		metroButton75.Name = "metroButton75";
		metroButton75.Size = new System.Drawing.Size(162, 26);
		metroButton75.TabIndex = 13;
		metroButton75.Text = "Kháng spam";
		metroButton75.Click += new System.EventHandler(D103583A);
		CEA4C9BF.Cursor = System.Windows.Forms.Cursors.Hand;
		CEA4C9BF.Location = new System.Drawing.Point(12, 203);
		CEA4C9BF.Name = "metroButton60";
		CEA4C9BF.Size = new System.Drawing.Size(162, 26);
		CEA4C9BF.TabIndex = 7;
		CEA4C9BF.Text = "Chế độ chuyên nghiệp";
		CEA4C9BF.Click += new System.EventHandler(CEA4C9BF_Click);
		CDB00AA6.Cursor = System.Windows.Forms.Cursors.Hand;
		CDB00AA6.Location = new System.Drawing.Point(12, 174);
		CDB00AA6.Name = "metroButton71";
		CDB00AA6.Size = new System.Drawing.Size(162, 26);
		CDB00AA6.TabIndex = 7;
		CDB00AA6.Text = "Report";
		CDB00AA6.Visible = false;
		button9.Cursor = System.Windows.Forms.Cursors.Hand;
		button9.Location = new System.Drawing.Point(12, 116);
		button9.Name = "button9";
		button9.Size = new System.Drawing.Size(162, 26);
		button9.TabIndex = 10;
		button9.Text = "Hủy liên kết Instagram";
		button9.Click += new System.EventHandler(DE018BAD);
		metroButton63.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton63.Location = new System.Drawing.Point(12, 87);
		metroButton63.Name = "metroButton63";
		metroButton63.Size = new System.Drawing.Size(162, 26);
		metroButton63.TabIndex = 10;
		metroButton63.Text = "Liên kết Instagram";
		metroButton63.Click += new System.EventHandler(metroButton63_Click);
		metroButton30.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton30.Location = new System.Drawing.Point(12, 145);
		metroButton30.Name = "metroButton30";
		metroButton30.Size = new System.Drawing.Size(162, 26);
		metroButton30.TabIndex = 3;
		metroButton30.Text = "Xóa bài trên tường";
		metroButton30.Click += new System.EventHandler(B698099A);
		B2813923.Cursor = System.Windows.Forms.Cursors.Hand;
		B2813923.Location = new System.Drawing.Point(12, 58);
		B2813923.Name = "metroButton57";
		B2813923.Size = new System.Drawing.Size(162, 26);
		B2813923.TabIndex = 6;
		B2813923.Text = "Hủy like page";
		B2813923.Click += new System.EventHandler(B2813923_Click);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.Location = new System.Drawing.Point(12, 174);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 26);
		button1.TabIndex = 8;
		button1.Text = "Kết bạn vip";
		metroButton32.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton32.Location = new System.Drawing.Point(12, 0);
		metroButton32.Name = "metroButton32";
		metroButton32.Size = new System.Drawing.Size(162, 26);
		metroButton32.TabIndex = 0;
		metroButton32.Text = "Ti\u0300m kiê\u0301m Google";
		metroButton32.Click += new System.EventHandler(metroButton32_Click);
		metroButton33.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton33.Location = new System.Drawing.Point(12, 29);
		metroButton33.Name = "metroButton33";
		metroButton33.Size = new System.Drawing.Size(162, 26);
		metroButton33.TabIndex = 0;
		metroButton33.Text = "Truy cập Website";
		metroButton33.Click += new System.EventHandler(metroButton33_Click);
		metroButton28.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton28.Location = new System.Drawing.Point(12, 0);
		metroButton28.Name = "metroButton28";
		metroButton28.Size = new System.Drawing.Size(162, 26);
		metroButton28.TabIndex = 2;
		metroButton28.Text = "Backup dư\u0303 liê\u0323u";
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.Location = new System.Drawing.Point(12, 232);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(162, 26);
		button3.TabIndex = 7;
		button3.Text = "Tạo page";
		button3.Click += new System.EventHandler(button3_Click);
		button6.Cursor = System.Windows.Forms.Cursors.Hand;
		button6.Location = new System.Drawing.Point(12, 261);
		button6.Name = "button6";
		button6.Size = new System.Drawing.Size(162, 26);
		button6.TabIndex = 10;
		button6.Text = "Unlock profile";
		button6.Click += new System.EventHandler(D9B5108F);
		btnKichHoatPageVhh.Cursor = System.Windows.Forms.Cursors.Hand;
		btnKichHoatPageVhh.Location = new System.Drawing.Point(12, 261);
		btnKichHoatPageVhh.Name = "btnKichHoatPageVhh";
		btnKichHoatPageVhh.Size = new System.Drawing.Size(162, 26);
		btnKichHoatPageVhh.TabIndex = 7;
		btnKichHoatPageVhh.Text = "Ki\u0301ch hoa\u0323t page vhh";
		btnKichHoatPageVhh.Click += new System.EventHandler(DC235B07);
		DA05193F.Cursor = System.Windows.Forms.Cursors.Hand;
		DA05193F.Location = new System.Drawing.Point(12, 261);
		DA05193F.Name = "btnShareAdminPage";
		DA05193F.Size = new System.Drawing.Size(162, 26);
		DA05193F.TabIndex = 10;
		DA05193F.Text = "Share Admin Page";
		DA05193F.Visible = false;
		DA05193F.Click += new System.EventHandler(DA05193F_Click);
		button7.Cursor = System.Windows.Forms.Cursors.Hand;
		button7.Location = new System.Drawing.Point(12, 261);
		button7.Name = "button7";
		button7.Size = new System.Drawing.Size(162, 26);
		button7.TabIndex = 2;
		button7.Text = "Report page";
		button7.Visible = false;
		button7.Click += new System.EventHandler(CA0E2295);
		groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		groupBox4.Controls.Add(panel5);
		groupBox4.Controls.Add(pictureBox4);
		groupBox4.Location = new System.Drawing.Point(396, 42);
		groupBox4.Name = "groupBox4";
		groupBox4.Size = new System.Drawing.Size(189, 476);
		groupBox4.TabIndex = 7;
		groupBox4.TabStop = false;
		groupBox4.Text = "Chức năng Bạn bè - Nhóm";
		panel5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		panel5.AutoScroll = true;
		panel5.Controls.Add(D3B3159C);
		panel5.Controls.Add(metroButton23);
		panel5.Controls.Add(metroButton14);
		panel5.Controls.Add(CD3D6A30);
		panel5.Controls.Add(CE968AA0);
		panel5.Controls.Add(BA3EBC9E);
		panel5.Controls.Add(D13B1803);
		panel5.Controls.Add(CB37A41B);
		panel5.Controls.Add(metroButton17);
		panel5.Controls.Add(metroButton16);
		panel5.Controls.Add(metroButton9);
		panel5.Controls.Add(metroButton41);
		panel5.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		panel5.Location = new System.Drawing.Point(1, 120);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(187, 351);
		panel5.TabIndex = 14;
		D3B3159C.Cursor = System.Windows.Forms.Cursors.Hand;
		D3B3159C.Location = new System.Drawing.Point(12, 232);
		D3B3159C.Name = "metroButton38";
		D3B3159C.Size = new System.Drawing.Size(162, 26);
		D3B3159C.TabIndex = 3;
		D3B3159C.Text = "Tham gia nhóm theo gợi ý";
		D3B3159C.Click += new System.EventHandler(CE316539);
		metroButton23.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton23.Location = new System.Drawing.Point(12, 261);
		metroButton23.Name = "metroButton23";
		metroButton23.Size = new System.Drawing.Size(162, 26);
		metroButton23.TabIndex = 0;
		metroButton23.Text = "Tham gia nhóm từ khóa";
		metroButton23.Click += new System.EventHandler(BEABE599);
		metroButton14.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton14.Location = new System.Drawing.Point(12, 0);
		metroButton14.Name = "metroButton14";
		metroButton14.Size = new System.Drawing.Size(162, 26);
		metroButton14.TabIndex = 0;
		metroButton14.Text = "Kết bạn theo từ khóa";
		metroButton14.Click += new System.EventHandler(DCA3AF11);
		CD3D6A30.Cursor = System.Windows.Forms.Cursors.Hand;
		CD3D6A30.Location = new System.Drawing.Point(12, 290);
		CD3D6A30.Name = "metroButton21";
		CD3D6A30.Size = new System.Drawing.Size(162, 26);
		CD3D6A30.TabIndex = 1;
		CD3D6A30.Text = "Tham gia nhóm chi\u0309 đi\u0323nh";
		CD3D6A30.Click += new System.EventHandler(F4B18B9C);
		BA3EBC9E.Cursor = System.Windows.Forms.Cursors.Hand;
		BA3EBC9E.Location = new System.Drawing.Point(12, 116);
		BA3EBC9E.Name = "metroButton15";
		BA3EBC9E.Size = new System.Drawing.Size(162, 26);
		BA3EBC9E.TabIndex = 5;
		BA3EBC9E.Text = "Hủy lời mời đã gửi";
		BA3EBC9E.Click += new System.EventHandler(BA3EBC9E_Click);
		D13B1803.Cursor = System.Windows.Forms.Cursors.Hand;
		D13B1803.Location = new System.Drawing.Point(12, 29);
		D13B1803.Name = "metroButton13";
		D13B1803.Size = new System.Drawing.Size(162, 26);
		D13B1803.TabIndex = 1;
		D13B1803.Text = "Kết bạn theo gợi ý";
		D13B1803.Click += new System.EventHandler(D13B1803_Click);
		CB37A41B.Cursor = System.Windows.Forms.Cursors.Hand;
		CB37A41B.Location = new System.Drawing.Point(12, 58);
		CB37A41B.Name = "metroButton18";
		CB37A41B.Size = new System.Drawing.Size(162, 26);
		CB37A41B.TabIndex = 2;
		CB37A41B.Text = "Xác nhận kết bạn";
		CB37A41B.Click += new System.EventHandler(CB37A41B_Click);
		metroButton17.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton17.Location = new System.Drawing.Point(12, 145);
		metroButton17.Name = "metroButton17";
		metroButton17.Size = new System.Drawing.Size(162, 26);
		metroButton17.TabIndex = 6;
		metroButton17.Text = "Hủy kết bạn";
		metroButton17.Click += new System.EventHandler(metroButton17_Click);
		metroButton16.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton16.Location = new System.Drawing.Point(12, 174);
		metroButton16.Name = "metroButton16";
		metroButton16.Size = new System.Drawing.Size(162, 26);
		metroButton16.TabIndex = 3;
		metroButton16.Text = "Kết bạn thành viên nhóm";
		metroButton16.Click += new System.EventHandler(D29D688F);
		metroButton9.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton9.Location = new System.Drawing.Point(12, 87);
		metroButton9.Name = "metroButton9";
		metroButton9.Size = new System.Drawing.Size(162, 26);
		metroButton9.TabIndex = 4;
		metroButton9.Text = "Kết bạn theo tệp UID";
		metroButton9.Click += new System.EventHandler(metroButton9_Click);
		metroButton41.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton41.Location = new System.Drawing.Point(12, 203);
		metroButton41.Name = "metroButton41";
		metroButton41.Size = new System.Drawing.Size(162, 26);
		metroButton41.TabIndex = 6;
		metroButton41.Text = "Kết bạn với bạn của bạn bè";
		metroButton41.Click += new System.EventHandler(metroButton41_Click);
		pictureBox4.Image = Class155.BF00A615;
		pictureBox4.Location = new System.Drawing.Point(18, 22);
		pictureBox4.Name = "pictureBox4";
		pictureBox4.Size = new System.Drawing.Size(151, 83);
		pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox4.TabIndex = 1;
		pictureBox4.TabStop = false;
		AB2E8DB5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		AB2E8DB5.Controls.Add(D4BB9908);
		AB2E8DB5.Controls.Add(C4918A9D);
		AB2E8DB5.Location = new System.Drawing.Point(591, 42);
		AB2E8DB5.Name = "groupBox3";
		AB2E8DB5.Size = new System.Drawing.Size(189, 476);
		AB2E8DB5.TabIndex = 11;
		AB2E8DB5.TabStop = false;
		AB2E8DB5.Text = "Chư\u0301c năng Seeding";
		D4BB9908.Image = Class155.Bitmap_174;
		D4BB9908.Location = new System.Drawing.Point(18, 22);
		D4BB9908.Name = "pictureBox6";
		D4BB9908.Size = new System.Drawing.Size(151, 83);
		D4BB9908.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		D4BB9908.TabIndex = 1;
		D4BB9908.TabStop = false;
		C4918A9D.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		C4918A9D.AutoScroll = true;
		C4918A9D.Controls.Add(button10);
		C4918A9D.Controls.Add(C996E22B);
		C4918A9D.Controls.Add(E1247622);
		C4918A9D.Controls.Add(D13F38BC);
		C4918A9D.Controls.Add(C2084506);
		C4918A9D.Controls.Add(metroButton31);
		C4918A9D.Controls.Add(metroButton70);
		C4918A9D.Controls.Add(CC9FD539);
		C4918A9D.Controls.Add(btnDangBaiV2);
		C4918A9D.Controls.Add(metroButton20);
		C4918A9D.Controls.Add(metroButton37);
		C4918A9D.Controls.Add(metroButton24);
		C4918A9D.Controls.Add(C401E4B0);
		C4918A9D.Controls.Add(metroButton56);
		C4918A9D.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		C4918A9D.Location = new System.Drawing.Point(1, 120);
		C4918A9D.Name = "panel7";
		C4918A9D.Size = new System.Drawing.Size(187, 351);
		C4918A9D.TabIndex = 14;
		button10.Cursor = System.Windows.Forms.Cursors.Hand;
		button10.Location = new System.Drawing.Point(11, 232);
		button10.Name = "button10";
		button10.Size = new System.Drawing.Size(165, 26);
		button10.TabIndex = 0;
		button10.Text = "Tương tác bài viết từ khóa";
		button10.Click += new System.EventHandler(F223162F);
		C996E22B.Cursor = System.Windows.Forms.Cursors.Hand;
		C996E22B.Location = new System.Drawing.Point(11, 261);
		C996E22B.Name = "metroButton48";
		C996E22B.Size = new System.Drawing.Size(165, 26);
		C996E22B.TabIndex = 8;
		C996E22B.Text = "Tương tác Livestream";
		C996E22B.Click += new System.EventHandler(C996E22B_Click);
		E1247622.Cursor = System.Windows.Forms.Cursors.Hand;
		E1247622.Location = new System.Drawing.Point(11, 116);
		E1247622.Name = "metroButton25";
		E1247622.Size = new System.Drawing.Size(78, 26);
		E1247622.TabIndex = 1;
		E1247622.Text = "Follow";
		E1247622.Click += new System.EventHandler(E1247622_Click);
		D13F38BC.Cursor = System.Windows.Forms.Cursors.Hand;
		D13F38BC.Location = new System.Drawing.Point(11, 203);
		D13F38BC.Name = "metroButton26";
		D13F38BC.Size = new System.Drawing.Size(165, 26);
		D13F38BC.TabIndex = 0;
		D13F38BC.Text = "Tương ta\u0301c ba\u0300i viê\u0301t chi\u0309 đi\u0323nh";
		D13F38BC.Click += new System.EventHandler(DF1DC11F);
		C2084506.Cursor = System.Windows.Forms.Cursors.Hand;
		C2084506.Location = new System.Drawing.Point(11, 145);
		C2084506.Name = "button11";
		C2084506.Size = new System.Drawing.Size(165, 26);
		C2084506.TabIndex = 1;
		C2084506.Text = "Đánh giá Page";
		C2084506.Click += new System.EventHandler(C2084506_Click);
		metroButton31.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton31.Location = new System.Drawing.Point(93, 116);
		metroButton31.Name = "metroButton31";
		metroButton31.Size = new System.Drawing.Size(83, 26);
		metroButton31.TabIndex = 1;
		metroButton31.Text = "Like page";
		metroButton31.Click += new System.EventHandler(metroButton31_Click);
		metroButton70.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton70.Location = new System.Drawing.Point(11, 174);
		metroButton70.Name = "metroButton70";
		metroButton70.Size = new System.Drawing.Size(165, 26);
		metroButton70.TabIndex = 6;
		metroButton70.Text = "Phản hồi bình luận";
		metroButton70.Click += new System.EventHandler(metroButton70_Click);
		CC9FD539.Cursor = System.Windows.Forms.Cursors.Hand;
		CC9FD539.Location = new System.Drawing.Point(11, 0);
		CC9FD539.Name = "metroButton36";
		CC9FD539.Size = new System.Drawing.Size(78, 26);
		CC9FD539.TabIndex = 2;
		CC9FD539.Text = "Đăng bài";
		CC9FD539.Click += new System.EventHandler(E214F21C);
		btnDangBaiV2.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDangBaiV2.Location = new System.Drawing.Point(93, 0);
		btnDangBaiV2.Name = "btnDangBaiV2";
		btnDangBaiV2.Size = new System.Drawing.Size(83, 26);
		btnDangBaiV2.TabIndex = 15;
		btnDangBaiV2.Text = "Đăng bài V2";
		btnDangBaiV2.Click += new System.EventHandler(btnDangBaiV2_Click);
		metroButton20.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton20.Location = new System.Drawing.Point(11, 319);
		metroButton20.Name = "metroButton20";
		metroButton20.Size = new System.Drawing.Size(165, 26);
		metroButton20.TabIndex = 3;
		metroButton20.Text = "Mời bạn bè vào nhóm";
		metroButton20.Click += new System.EventHandler(F19DAC2B);
		metroButton37.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton37.Location = new System.Drawing.Point(11, 29);
		metroButton37.Name = "metroButton37";
		metroButton37.Size = new System.Drawing.Size(165, 26);
		metroButton37.TabIndex = 2;
		metroButton37.Text = "Share bài";
		metroButton37.Click += new System.EventHandler(metroButton37_Click);
		metroButton24.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton24.Location = new System.Drawing.Point(11, 87);
		metroButton24.Name = "metroButton24";
		metroButton24.Size = new System.Drawing.Size(165, 26);
		metroButton24.TabIndex = 3;
		metroButton24.Text = "Spam bài viết";
		metroButton24.Click += new System.EventHandler(metroButton24_Click);
		C401E4B0.Cursor = System.Windows.Forms.Cursors.Hand;
		C401E4B0.Location = new System.Drawing.Point(11, 58);
		C401E4B0.Name = "metroButton27";
		C401E4B0.Size = new System.Drawing.Size(165, 26);
		C401E4B0.TabIndex = 3;
		C401E4B0.Text = "Nhắn tin";
		C401E4B0.Click += new System.EventHandler(C401E4B0_Click);
		metroButton56.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton56.Location = new System.Drawing.Point(11, 290);
		metroButton56.Name = "metroButton56";
		metroButton56.Size = new System.Drawing.Size(165, 26);
		metroButton56.TabIndex = 3;
		metroButton56.Text = "Mời bạn bè like page";
		metroButton56.Click += new System.EventHandler(metroButton56_Click);
		F4212333.Cursor = System.Windows.Forms.Cursors.Hand;
		F4212333.Location = new System.Drawing.Point(12, 174);
		F4212333.Name = "metroButton45";
		F4212333.Size = new System.Drawing.Size(162, 26);
		F4212333.TabIndex = 8;
		F4212333.Text = "Đăng status";
		F4212333.Click += new System.EventHandler(F4212333_Click);
		C498CAB3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		C498CAB3.Controls.Add(B4140AAB);
		C498CAB3.Controls.Add(pictureBox3);
		C498CAB3.Location = new System.Drawing.Point(198, 42);
		C498CAB3.Name = "groupBox1";
		C498CAB3.Size = new System.Drawing.Size(192, 476);
		C498CAB3.TabIndex = 6;
		C498CAB3.TabStop = false;
		C498CAB3.Text = "Tương tác bài viết";
		B4140AAB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		B4140AAB.AutoScroll = true;
		B4140AAB.Controls.Add(C1B9173C);
		B4140AAB.Controls.Add(metroButton59);
		B4140AAB.Controls.Add(metroButton46);
		B4140AAB.Controls.Add(E1860802);
		B4140AAB.Controls.Add(metroButton7);
		B4140AAB.Controls.Add(BF9C2CA7);
		B4140AAB.Controls.Add(metroButton6);
		B4140AAB.Controls.Add(B40C4C20);
		B4140AAB.Controls.Add(metroButton35);
		B4140AAB.Controls.Add(button12);
		B4140AAB.Controls.Add(metroButton66);
		B4140AAB.Controls.Add(C026BA07);
		B4140AAB.Controls.Add(FC927B25);
		B4140AAB.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		B4140AAB.Location = new System.Drawing.Point(1, 120);
		B4140AAB.Name = "panel4";
		B4140AAB.Size = new System.Drawing.Size(190, 351);
		B4140AAB.TabIndex = 14;
		C1B9173C.BackColor = System.Drawing.Color.DeepSkyBlue;
		C1B9173C.Cursor = System.Windows.Forms.Cursors.Hand;
		C1B9173C.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		C1B9173C.ForeColor = System.Drawing.Color.Black;
		C1B9173C.Location = new System.Drawing.Point(12, 203);
		C1B9173C.Name = "btnChayJobKiemTien";
		C1B9173C.Size = new System.Drawing.Size(165, 26);
		C1B9173C.TabIndex = 14;
		C1B9173C.Text = "Script GemLogin";
		C1B9173C.UseVisualStyleBackColor = false;
		C1B9173C.Click += new System.EventHandler(AC350701);
		metroButton59.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton59.Location = new System.Drawing.Point(12, 145);
		metroButton59.Name = "metroButton59";
		metroButton59.Size = new System.Drawing.Size(165, 26);
		metroButton59.TabIndex = 4;
		metroButton59.Text = "Bài viết trên tường";
		metroButton59.Click += new System.EventHandler(metroButton59_Click);
		E1860802.Cursor = System.Windows.Forms.Cursors.Hand;
		E1860802.Location = new System.Drawing.Point(12, 0);
		E1860802.Name = "metroButton8";
		E1860802.Size = new System.Drawing.Size(165, 26);
		E1860802.TabIndex = 0;
		E1860802.Text = "Bài viết Newsfeed";
		E1860802.Click += new System.EventHandler(E1860802_Click);
		metroButton7.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton7.Location = new System.Drawing.Point(12, 29);
		metroButton7.Name = "metroButton7";
		metroButton7.Size = new System.Drawing.Size(165, 26);
		metroButton7.TabIndex = 1;
		metroButton7.Text = "Bài viết Bạn bè";
		metroButton7.Click += new System.EventHandler(metroButton7_Click);
		BF9C2CA7.Cursor = System.Windows.Forms.Cursors.Hand;
		BF9C2CA7.Location = new System.Drawing.Point(12, 116);
		BF9C2CA7.Name = "metroButton5";
		BF9C2CA7.Size = new System.Drawing.Size(165, 26);
		BF9C2CA7.TabIndex = 3;
		BF9C2CA7.Text = "Bài viết Fanpage";
		BF9C2CA7.Click += new System.EventHandler(BF9C2CA7_Click);
		metroButton6.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton6.Location = new System.Drawing.Point(12, 58);
		metroButton6.Name = "metroButton6";
		metroButton6.Size = new System.Drawing.Size(165, 26);
		metroButton6.TabIndex = 2;
		metroButton6.Text = "Bài viết Nhóm";
		metroButton6.Click += new System.EventHandler(FD80E001);
		B40C4C20.Cursor = System.Windows.Forms.Cursors.Hand;
		B40C4C20.Location = new System.Drawing.Point(12, 232);
		B40C4C20.Name = "button13";
		B40C4C20.Size = new System.Drawing.Size(165, 26);
		B40C4C20.TabIndex = 2;
		B40C4C20.Text = "Tương ta\u0301c reel chi\u0309 đi\u0323nh";
		B40C4C20.Click += new System.EventHandler(B40C4C20_Click);
		metroButton35.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton35.Location = new System.Drawing.Point(12, 174);
		metroButton35.Name = "metroButton35";
		metroButton35.Size = new System.Drawing.Size(165, 26);
		metroButton35.TabIndex = 0;
		metroButton35.Text = "Nghỉ giải lao";
		metroButton35.Click += new System.EventHandler(metroButton35_Click);
		button12.Cursor = System.Windows.Forms.Cursors.Hand;
		button12.Location = new System.Drawing.Point(12, 261);
		button12.Name = "button12";
		button12.Size = new System.Drawing.Size(165, 26);
		button12.TabIndex = 2;
		button12.Text = "Tương ta\u0301c reel ngâ\u0303u nhiên";
		button12.Visible = false;
		button12.Click += new System.EventHandler(button12_Click);
		metroButton66.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton66.Location = new System.Drawing.Point(12, 175);
		metroButton66.Name = "metroButton66";
		metroButton66.Size = new System.Drawing.Size(165, 26);
		metroButton66.TabIndex = 13;
		metroButton66.Text = "Công khai bài gắn thẻ (ẩn)";
		metroButton66.Visible = false;
		C026BA07.Cursor = System.Windows.Forms.Cursors.Hand;
		C026BA07.Location = new System.Drawing.Point(12, 174);
		C026BA07.Name = "button8";
		C026BA07.Size = new System.Drawing.Size(165, 26);
		C026BA07.TabIndex = 13;
		C026BA07.Text = "Kiếm tiền Golike";
		C026BA07.Click += new System.EventHandler(C026BA07_Click);
		FC927B25.Cursor = System.Windows.Forms.Cursors.Hand;
		FC927B25.Location = new System.Drawing.Point(12, 145);
		FC927B25.Name = "button5";
		FC927B25.Size = new System.Drawing.Size(165, 26);
		FC927B25.TabIndex = 4;
		FC927B25.Text = "Uptop ba\u0300i viê\u0301t";
		FC927B25.Click += new System.EventHandler(B0B5F283);
		pictureBox3.Image = Class155.Bitmap_2;
		pictureBox3.Location = new System.Drawing.Point(18, 22);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(151, 83);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 1;
		pictureBox3.TabStop = false;
		groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		groupBox2.Controls.Add(EA3EA72F);
		groupBox2.Controls.Add(pictureBox2);
		groupBox2.Location = new System.Drawing.Point(4, 43);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(189, 476);
		groupBox2.TabIndex = 5;
		groupBox2.TabStop = false;
		groupBox2.Text = "Tương tác cá nhân";
		EA3EA72F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EA3EA72F.AutoScroll = true;
		EA3EA72F.Controls.Add(metroButton78);
		EA3EA72F.Controls.Add(F4212333);
		EA3EA72F.Controls.Add(A3B87B1B);
		EA3EA72F.Controls.Add(metroButton62);
		EA3EA72F.Controls.Add(metroButton65);
		EA3EA72F.Controls.Add(metroButton69);
		EA3EA72F.Controls.Add(metroButton77);
		EA3EA72F.Controls.Add(btnDangReel);
		EA3EA72F.Controls.Add(BA1E9FA9);
		EA3EA72F.Controls.Add(button4);
		EA3EA72F.Controls.Add(button2);
		EA3EA72F.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		EA3EA72F.Location = new System.Drawing.Point(1, 120);
		EA3EA72F.Name = "panel3";
		EA3EA72F.Size = new System.Drawing.Size(187, 351);
		EA3EA72F.TabIndex = 14;
		metroButton78.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton78.Location = new System.Drawing.Point(12, 115);
		metroButton78.Name = "metroButton78";
		metroButton78.Size = new System.Drawing.Size(162, 26);
		metroButton78.TabIndex = 5;
		metroButton78.Text = "Chúc mừng sinh nhật";
		metroButton78.Click += new System.EventHandler(metroButton78_Click);
		A3B87B1B.Cursor = System.Windows.Forms.Cursors.Hand;
		A3B87B1B.Location = new System.Drawing.Point(12, 0);
		A3B87B1B.Name = "metroButton61";
		A3B87B1B.Size = new System.Drawing.Size(162, 26);
		A3B87B1B.TabIndex = 0;
		A3B87B1B.Text = "Đọc thông báo";
		A3B87B1B.Click += new System.EventHandler(A3B87B1B_Click);
		metroButton62.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton62.Location = new System.Drawing.Point(12, 29);
		metroButton62.Name = "metroButton62";
		metroButton62.Size = new System.Drawing.Size(162, 26);
		metroButton62.TabIndex = 1;
		metroButton62.Text = "Xem Story";
		metroButton62.Click += new System.EventHandler(DEA05E23);
		metroButton65.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton65.Location = new System.Drawing.Point(12, 58);
		metroButton65.Name = "metroButton65";
		metroButton65.Size = new System.Drawing.Size(162, 26);
		metroButton65.TabIndex = 2;
		metroButton65.Text = "Xem Watch";
		metroButton65.Click += new System.EventHandler(metroButton65_Click);
		metroButton69.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton69.Location = new System.Drawing.Point(12, 86);
		metroButton69.Name = "metroButton69";
		metroButton69.Size = new System.Drawing.Size(162, 26);
		metroButton69.TabIndex = 4;
		metroButton69.Text = "Chọc bạn bè";
		metroButton69.Click += new System.EventHandler(metroButton69_Click);
		metroButton77.Cursor = System.Windows.Forms.Cursors.Hand;
		metroButton77.Location = new System.Drawing.Point(12, 144);
		metroButton77.Name = "metroButton77";
		metroButton77.Size = new System.Drawing.Size(162, 26);
		metroButton77.TabIndex = 2;
		metroButton77.Text = "Đăng story";
		metroButton77.Click += new System.EventHandler(metroButton77_Click);
		btnDangReel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDangReel.Location = new System.Drawing.Point(12, 232);
		btnDangReel.Name = "btnDangReel";
		btnDangReel.Size = new System.Drawing.Size(162, 26);
		btnDangReel.TabIndex = 2;
		btnDangReel.Text = "Đăng reel";
		btnDangReel.Click += new System.EventHandler(btnDangReel_Click);
		BA1E9FA9.Cursor = System.Windows.Forms.Cursors.Hand;
		BA1E9FA9.Location = new System.Drawing.Point(12, 203);
		BA1E9FA9.Name = "metroButton76";
		BA1E9FA9.Size = new System.Drawing.Size(162, 26);
		BA1E9FA9.TabIndex = 2;
		BA1E9FA9.Text = "Đăng status mfb";
		BA1E9FA9.Click += new System.EventHandler(F11FB9A8);
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.Location = new System.Drawing.Point(12, 173);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(162, 26);
		button4.TabIndex = 7;
		button4.Text = "Share page (ẩn)";
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Location = new System.Drawing.Point(12, 173);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(162, 26);
		button2.TabIndex = 7;
		button2.Text = "Uptop Post (ẩn)";
		pictureBox2.Image = Class155.Bitmap_6;
		pictureBox2.Location = new System.Drawing.Point(18, 22);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(151, 83);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 1;
		pictureBox2.TabStop = false;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(E6B11382);
		panel1.Controls.Add(groupBox5);
		panel1.Controls.Add(groupBox2);
		panel1.Controls.Add(groupBox6);
		panel1.Controls.Add(C498CAB3);
		panel1.Controls.Add(groupBox4);
		panel1.Controls.Add(AB2E8DB5);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1176, 523);
		panel1.TabIndex = 12;
		E6B11382.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E6B11382.BackColor = System.Drawing.Color.White;
		E6B11382.BorderRadius = 0;
		E6B11382.BottomSahddow = true;
		E6B11382.color = System.Drawing.Color.DarkViolet;
		E6B11382.Controls.Add(A730AF01);
		E6B11382.LeftSahddow = false;
		E6B11382.Location = new System.Drawing.Point(1, 0);
		E6B11382.Name = "bunifuCards1";
		E6B11382.RightSahddow = true;
		E6B11382.ShadowDepth = 20;
		E6B11382.Size = new System.Drawing.Size(1173, 37);
		E6B11382.TabIndex = 1;
		A730AF01.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A730AF01.BackColor = System.Drawing.Color.White;
		A730AF01.Controls.Add(button31);
		A730AF01.Controls.Add(E83F5DA0);
		A730AF01.Controls.Add(bunifuCustomLabel1);
		A730AF01.Cursor = System.Windows.Forms.Cursors.SizeAll;
		A730AF01.Location = new System.Drawing.Point(0, 3);
		A730AF01.Name = "pnlHeader";
		A730AF01.Size = new System.Drawing.Size(1173, 31);
		A730AF01.TabIndex = 9;
		button31.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button31.Cursor = System.Windows.Forms.Cursors.Hand;
		button31.FlatAppearance.BorderSize = 0;
		button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button31.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button31.ForeColor = System.Drawing.Color.White;
		button31.Image = (System.Drawing.Image)resources.GetObject("button31.Image");
		button31.Location = new System.Drawing.Point(1141, 1);
		button31.Name = "button31";
		button31.Size = new System.Drawing.Size(30, 30);
		button31.TabIndex = 77;
		button31.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		button31.UseVisualStyleBackColor = true;
		button31.Click += new System.EventHandler(button31_Click);
		E83F5DA0.Cursor = System.Windows.Forms.Cursors.Default;
		E83F5DA0.Image = Class155.DD225F0D;
		E83F5DA0.Location = new System.Drawing.Point(3, 2);
		E83F5DA0.Name = "pictureBox9";
		E83F5DA0.Size = new System.Drawing.Size(34, 27);
		E83F5DA0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		E83F5DA0.TabIndex = 76;
		E83F5DA0.TabStop = false;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(1173, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Danh sách hành động";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A6B0C53E.Fixed = true;
		A6B0C53E.Horizontal = true;
		A6B0C53E.TargetControl = bunifuCustomLabel1;
		A6B0C53E.Vertical = true;
		CE9D002D.Fixed = true;
		CE9D002D.Horizontal = true;
		CE9D002D.TargetControl = A730AF01;
		CE9D002D.Vertical = true;
		A38FFFB1.Cursor = System.Windows.Forms.Cursors.Hand;
		A38FFFB1.Location = new System.Drawing.Point(12, 232);
		A38FFFB1.Name = "button14";
		A38FFFB1.Size = new System.Drawing.Size(162, 26);
		A38FFFB1.TabIndex = 8;
		A38FFFB1.Text = "Xóa thiết bị tin cậy";
		A38FFFB1.Click += new System.EventHandler(AF86D588);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1176, 523);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "fThemHanhDong";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		groupBox5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		E12FE49D.ResumeLayout(false);
		groupBox6.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)DE13053A).EndInit();
		panel8.ResumeLayout(false);
		groupBox4.ResumeLayout(false);
		panel5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
		AB2E8DB5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D4BB9908).EndInit();
		C4918A9D.ResumeLayout(false);
		C498CAB3.ResumeLayout(false);
		B4140AAB.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		groupBox2.ResumeLayout(false);
		EA3EA72F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		panel1.ResumeLayout(false);
		E6B11382.ResumeLayout(false);
		A730AF01.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)E83F5DA0).EndInit();
		ResumeLayout(false);
	}
}
