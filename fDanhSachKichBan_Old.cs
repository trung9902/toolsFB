using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fDanhSachKichBan_Old : Form
{
	internal string string_0 = "";

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal GroupBox EA1B7F1F;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button button1;

	internal GroupBox CDAB3C35;

	internal DataGridView CBB92634;

	internal DataGridView dtgvHanhDong;

	internal ContextMenuStrip contextMenuStrip1;

	internal ToolStripMenuItem B711ED09;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem C2A119A9;

	internal ToolStripMenuItem F530009D;

	internal ContextMenuStrip contextMenuStrip1_1;

	internal ToolStripMenuItem toolStripMenuItem1;

	internal ToolStripMenuItem toolStripMenuItem3;

	internal ToolStripMenuItem toolStripMenuItem4;

	internal ToolStripMenuItem F8B44FAC;

	internal DataGridViewTextBoxColumn AA0D3639;

	internal DataGridViewTextBoxColumn cId_HanhDong;

	internal DataGridViewTextBoxColumn D8AC35A2;

	internal DataGridViewTextBoxColumn E3074F9A;

	internal Panel panel1;

	internal DataGridViewTextBoxColumn cStt;

	internal DataGridViewTextBoxColumn AF308E3C;

	internal DataGridViewTextBoxColumn F99B69B6;

	internal SplitContainer D619C29A;

	internal GroupBox groupBox3;

	internal Label label1;

	internal Panel CA232EBF;

	internal NumericUpDown nudCountActionTo;

	internal NumericUpDown C93377A8;

	internal Label label2;

	internal Button A52398A4;

	internal Button button7;

	internal Button button6;

	internal Button DB20DEB3;

	internal Button DC904CB0;

	internal Button D92B388E;

	internal Button button9;

	internal Button button10;

	internal Button button12;

	internal Button button13;

	internal Button button14;

	internal ComboBox A795C38E;

	internal Label label3;

	internal CheckBox ckbRandomAction;

	internal Button D8A3638B;

	internal Button B0351F99;

	public fDanhSachKichBan_Old(string B0BFABAD)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		Language.smethod_0(contextMenuStrip1);
		Language.smethod_0(contextMenuStrip1_1);
		string_0 = B0BFABAD;
	}

	private void AA3FEF8C(object sender, EventArgs e)
	{
		D106073E();
		method_5(string_0);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private void DE0C143D(object sender, EventArgs e)
	{
		method_6();
	}

	private void toolStripMenuItem4_Click(object sender, EventArgs e)
	{
		method_4();
	}

	public void method_0(ref DataGridView dataGridView_0, int D8373EBC, int int_0)
	{
		string text = "";
		for (int i = 1; i < dataGridView_0.Columns.Count; i++)
		{
			text = EAB09F19.EC12300A(dataGridView_0, D8373EBC, i);
			EAB09F19.smethod_2(dataGridView_0, D8373EBC, i, EAB09F19.EC12300A(dataGridView_0, int_0, i));
			EAB09F19.smethod_2(dataGridView_0, int_0, i, text);
		}
	}

	private void E33FD98B(object sender, EventArgs e)
	{
		int index = dtgvHanhDong.SelectedRows[0].Index;
		if (index == 0)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(dtgvHanhDong, index - 1, "cId_HanhDong");
		string text2 = EAB09F19.E2A1ED2F(dtgvHanhDong, index, "cId_HanhDong");
		if (text + text2 != "")
		{
			if (Class154.smethod_14(text, text2))
			{
				method_0(ref dtgvHanhDong, index, index - 1);
				dtgvHanhDong.Rows[index - 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		int index = dtgvHanhDong.SelectedRows[0].Index;
		if (index == dtgvHanhDong.RowCount - 1)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(dtgvHanhDong, index + 1, "cId_HanhDong");
		string text2 = EAB09F19.E2A1ED2F(dtgvHanhDong, index, "cId_HanhDong");
		if (text + text2 != "")
		{
			if (Class154.smethod_14(text, text2))
			{
				method_0(ref dtgvHanhDong, index, index + 1);
				dtgvHanhDong.Rows[index + 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void B711ED09_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void BEA1D884(object sender, EventArgs e)
	{
		E03B2492();
	}

	private void F530009D_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void FCB9CFB0(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex > -1)
		{
			method_3();
		}
	}

	private void D6B06BBB(object sender, EventArgs e)
	{
		FE954D38();
	}

	private void F8B44FAC_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void dtgvHanhDong_KeyDown(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
		case Keys.Delete:
			method_4();
			break;
		case Keys.Insert:
		case Keys.F1:
			E03B2492();
			break;
		case Keys.F2:
			FE954D38();
			break;
		case Keys.F5:
			method_3();
			break;
		case Keys.D:
			if (e.Modifiers == Keys.Control)
			{
				method_2();
			}
			break;
		}
	}

	private void method_2()
	{
		try
		{
			if (dtgvHanhDong.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm hành động trước!", 3);
				return;
			}
			DataGridViewRow dataGridViewRow = dtgvHanhDong.SelectedRows[0];
			string text = dataGridViewRow.Cells["cId_HanhDong"].Value.ToString();
			string text2 = dataGridViewRow.Cells["cTenHanhDong"].Value.ToString();
			string f831373E = text2 + " - Copy";
			int num = 2;
			while (Class154.D31F2EA6(f831373E))
			{
				f831373E = text2 + $" - Copy ({num++})";
			}
			if (Class154.smethod_12(text, f831373E))
			{
				DataTable dataTable = Class154.smethod_10();
				dtgvHanhDong.Rows.Add(dtgvHanhDong.RowCount + 1, dataTable.Rows[0]["Id_HanhDong"], dataTable.Rows[0]["TenHanhDong"], dataTable.Rows[0]["MoTa"]);
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
		catch
		{
		}
	}

	private void method_3()
	{
		try
		{
			dtgvHanhDong.Rows.Clear();
			if (CBB92634.RowCount != 0)
			{
				DataGridViewRow dataGridViewRow = CBB92634.SelectedRows[0];
				string c585AA = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
				DataTable dataTable = Class154.smethod_9(c585AA);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dtgvHanhDong.Rows.Add(dtgvHanhDong.RowCount + 1, dataTable.Rows[i]["Id_HanhDong"], dataTable.Rows[i]["TenHanhDong"], dataTable.Rows[i]["MoTa"]);
				}
				string string_ = Class154.smethod_3(c585AA);
				GClass4 gClass = new GClass4(string_, F79F9AB5: true);
				A795C38E.SelectedIndex = gClass.method_2("cbbCountAction");
				C93377A8.Value = gClass.method_2("nudCountActionFrom", 1);
				nudCountActionTo.Value = gClass.method_2("nudCountActionTo", 1);
				ckbRandomAction.Checked = gClass.method_3("ckbRandomAction");
				A00E86BF(null, null);
			}
		}
		catch
		{
		}
	}

	private void method_4()
	{
		try
		{
			if (dtgvHanhDong.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm hành động trước!", 3);
			}
			else
			{
				if (MsBoxHelper.D41C45AC("Bạn có chắc muốn xóa hoạt động này?") != DialogResult.Yes)
				{
					return;
				}
				DataGridViewRow dataGridViewRow = dtgvHanhDong.SelectedRows[0];
				if (Class154.smethod_15(dataGridViewRow.Cells["cId_HanhDong"].Value.ToString()))
				{
					int index = dataGridViewRow.Index;
					for (int i = index; i < dtgvHanhDong.Rows.Count - 1; i++)
					{
						method_0(ref dtgvHanhDong, i, i + 1);
					}
					dtgvHanhDong.Rows.RemoveAt(dtgvHanhDong.Rows.Count - 1);
				}
				else
				{
					MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
				return;
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void E03B2492()
	{
		try
		{
			if (CBB92634.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm kịch bản trước!", 3);
				return;
			}
			DataGridViewRow dataGridViewRow = CBB92634.SelectedRows[0];
			string text = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
			int count = Class154.smethod_9(text).Rows.Count;
			Commom.smethod_35(new fThemHanhDong(text));
			DataTable dataTable = Class154.smethod_9(text);
			int count2 = dataTable.Rows.Count;
			if (count2 > count)
			{
				dtgvHanhDong.Rows.Add(dtgvHanhDong.RowCount + 1, dataTable.Rows[count2 - 1]["Id_HanhDong"], dataTable.Rows[count2 - 1]["TenHanhDong"], dataTable.Rows[count2 - 1]["MoTa"]);
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void FE954D38()
	{
		try
		{
			if (dtgvHanhDong.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm hành động trước!", 3);
				return;
			}
			DataGridViewRow dataGridViewRow = dtgvHanhDong.SelectedRows[0];
			string text = dataGridViewRow.Cells["cId_HanhDong"].Value.ToString();
			DataTable dataTable = Class154.E6AD9687(text);
			Form form = null;
			string text2 = dataTable.Rows[0]["TenTuongTac"].ToString();
			string text3 = text2;
			string text4 = text3;
			if (text4 == "HDDangBaiV2")
			{
				form = new fHDDangBaiV2("", text);
			}
			switch (AFAE75A0.smethod_0(text4))
			{
			case 152310871u:
				if (text4 == "HDUpCover")
				{
					form = new fHDUpCover("", text);
				}
				break;
			case 80860474u:
				if (text4 == "HDUnlockProfile")
				{
					form = new fHDUnlockProfile("", text);
				}
				break;
			case 170588456u:
				if (text4 == "HDShareBai")
				{
					form = new fHDShareBai("", text);
				}
				break;
			case 167896116u:
				if (text4 == "HDTuongTacBaiVietTuKhoa")
				{
					form = new fHDTuongTacBaiVietTuKhoa("", text);
				}
				break;
			case 311671696u:
				if (text4 == "HDKetBanGoiY")
				{
					form = new fHDKetBanGoiY("", text);
				}
				break;
			case 271171672u:
				if (text4 == "HDTruyCapWebsite")
				{
					form = new fHDTruyCapWebsite("", text);
				}
				break;
			case 516966741u:
				if (text4 == "HDDangReel")
				{
					form = new fHDDangReel("", text);
				}
				break;
			case 327820411u:
				if (text4 == "HDBuffTinNhanProfile")
				{
					form = new fHDBuffTinNhanProfile("", text);
				}
				break;
			case 570065009u:
				if (text4 == "HDTuongTacReelNgauNhien")
				{
					form = new fHDTuongTacReelNgauNhien("", text);
				}
				break;
			case 532292684u:
				if (text4 == "HDBuffLikeComment")
				{
					form = new fHDBuffLikeComment("", text);
				}
				break;
			case 614517095u:
				if (text4 == "HDReport")
				{
					form = new fHDReport("", text);
				}
				break;
			case 582938346u:
				if (text4 == "HDXemStory")
				{
					form = new fHDXemStory("", text);
				}
				break;
			case 852508141u:
				if (text4 == "HDKetBanTepUid")
				{
					form = new fHDKetBanTepUid("", text);
				}
				break;
			case 786238800u:
				if (text4 == "HDXemWatch")
				{
					form = new fHDXemWatch("", text);
				}
				break;
			case 1340375996u:
				if (text4 == "HDBatCheDoChuyenNghiep")
				{
					form = new fHDBatCheDoChuyenNghiep("", text);
				}
				break;
			case 935513960u:
				if (text4 == "HDMoiLikePage")
				{
					form = new fHDMoiLikePage("", text);
				}
				break;
			case 894688135u:
				if (text4 == "HDTuongTacReelChiDinh")
				{
					form = new fHDTuongTacReelChiDinh("", text);
				}
				break;
			case 1470935067u:
				if (text4 == "HDDangStatus")
				{
					form = new fHDDangStatus("", text);
				}
				break;
			case 1467610808u:
				if (text4 == "HDLinkToInstagram")
				{
					form = new fHDLinkToInstagram("", text);
				}
				break;
			case 1653385921u:
				if (text4 == "HDNghiGiaiLao")
				{
					form = new fHDNghiGiaiLao("", text);
				}
				break;
			case 1591506910u:
				if (text4 == "HDTuongTacNhomv2")
				{
					form = new fHDTuongTacNhomv2("", text);
				}
				break;
			case 1697418988u:
				if (text4 == "HDTimKiemGoogle")
				{
					form = new fHDTimKiemGoogle("", text);
				}
				break;
			case 1672329986u:
				if (text4 == "HDBaiVietNewsfeed2")
				{
					form = new fHDBaiVietNewsfeed2("", text);
				}
				break;
			case 1884305945u:
				if (text4 == "HDDocThongBao")
				{
					form = new fHDDocThongBao("", text);
				}
				break;
			case 1823818229u:
				if (text4 == "HDUpAvatar")
				{
					form = new fHDUpAvatar("", text);
				}
				break;
			case 1723758688u:
				if (text4 == "HDXoaBaiTuong")
				{
					form = new fHDXoaBaiTuong("", text);
				}
				break;
			case 1952866892u:
				if (text4 == "HDKetBanTheoTuKhoa")
				{
					form = new fHDKetBanTheoTuKhoa("", text);
				}
				break;
			case 1906272025u:
				if (text4 == "HDKetBanVoiBanBeCuaUid")
				{
					form = new fHDKetBanVoiBanBeCuaUid("", text);
				}
				break;
			case 2004466602u:
				if (text4 == "HDDoiTen")
				{
					form = new fHDDoiTen("", text);
				}
				break;
			case 1984335833u:
				if (text4 == "HDBaiVietBanBe")
				{
					form = new fHDBaiVietBanBe("", text);
				}
				break;
			case 2065195933u:
				if (text4 == "HDBuffFollowLikePage")
				{
					form = new fHDBuffFollowLikePage("", text);
				}
				break;
			case 2030328732u:
				if (text4 == "HDOnOff2FA")
				{
					form = new fHDOnOff2FA("", text);
				}
				break;
			case 2117563667u:
				if (text4 == "HDKhangSpam")
				{
					form = new fHDKhangSpam("", text);
				}
				break;
			case 2081285240u:
				if (text4 == "HDChocBanBe")
				{
					form = new fHDChocBanBe("", text);
				}
				break;
			case 2079252553u:
				if (text4 == "HDPhanHoiBinhLuan")
				{
					form = new fHDPhanHoiBinhLuan("", text);
				}
				break;
			case 2277183375u:
				if (text4 == "HDRoiNhom")
				{
					form = new fHDRoiNhom("", text);
				}
				break;
			case 2230339588u:
				if (text4 == "HDBuffFollowCaNhan")
				{
					form = new fHDBuffFollowCaNhan("", text);
				}
				break;
			case 2421286761u:
				if (text4 == "HDBaiVietNhom")
				{
					form = new fHDBaiVietNhom("", text);
				}
				break;
			case 2416405417u:
				if (text4 == "HDHuyLikePage")
				{
					form = new fHDHuyLikePage("", text);
				}
				break;
			case 2540878680u:
				if (text4 == "HDThamGiaNhomTuKhoa")
				{
					form = new fHDThamGiaNhomTuKhoa("", text);
				}
				break;
			case 2653710823u:
				if (text4 == "HDSharePage")
				{
					form = new fHDSharePage("", text);
				}
				break;
			case 2553440797u:
				if (text4 == "HDCapNhatThongTin")
				{
					form = new fHDCapNhatThongTin("", text);
				}
				break;
			case 2703861858u:
				if (text4 == "HDChucMungSinhNhat")
				{
					form = new fHDChucMungSinhNhat("", text);
				}
				break;
			case 2680847194u:
				if (text4 == "HDScriptGemLogin")
				{
					form = new fHDScriptGemLogin("", text);
				}
				break;
			case 2837141903u:
				if (text4 == "HDBaiVietFanpage")
				{
					form = new fHDBaiVietFanpage("", text);
				}
				break;
			case 2821037716u:
				if (text4 == "HDHuyKetBan")
				{
					form = new fHDHuyKetBan("", text);
				}
				break;
			case 2922412940u:
				if (text4 == "HDTaoPage")
				{
					form = new fHDTaoPage("", text);
				}
				break;
			case 2837258301u:
				if (text4 == "HDKichHoatPageVhh")
				{
					form = new fHDKichHoatPageVhh("", text);
				}
				break;
			case 3099572506u:
				if (text4 == "HDDangXuatThietBiCu")
				{
					form = new fHDDangXuatThietBiCu("", text);
				}
				break;
			case 2944435598u:
				if (text4 == "HDThamGiaNhomUid")
				{
					form = new fHDThamGiaNhomUid("", text);
				}
				break;
			case 2924758840u:
				if (text4 == "HDMoiBanBeVaoNhom")
				{
					form = new fHDMoiBanBeVaoNhom("", text);
				}
				break;
			case 3375859832u:
				if (text4 == "HDDanhGiaPage")
				{
					form = new fHDDanhGiaPage("", text);
				}
				break;
			case 3255732838u:
				if (text4 == "HDDoiMatKhau")
				{
					form = new fHDDoiMatKhau("", text);
				}
				break;
			case 3609367991u:
				if (text4 == "HDAddMail")
				{
					form = new fHDAddMail("", text);
				}
				break;
			case 3427768725u:
				if (text4 == "HDBaiVietTrenTuong")
				{
					form = new fHDBaiVietTrenTuong("", text);
				}
				break;
			case 3671364376u:
				if (text4 == "HDThamGiaNhomGoiY")
				{
					form = new fHDThamGiaNhomGoiY("", text);
				}
				break;
			case 3656368709u:
				if (text4 == "HDUptopBaiViet")
				{
					form = new fHDUptopBaiViet("", text);
				}
				break;
			case 3742679556u:
				if (text4 == "HDBaiVietNewsfeed")
				{
					form = new fHDBaiVietNewsfeed("", text);
				}
				break;
			case 3732058847u:
				if (text4 == "HDDangStatusV2")
				{
					form = new fHDDangStatusV2("", text);
				}
				break;
			case 3677432718u:
				if (text4 == "HDDangStory")
				{
					form = new fHDDangStory("", text);
				}
				break;
			case 3877387086u:
				if (text4 == "HDTuongTacLivestream")
				{
					form = new fHDTuongTacLivestream("", text);
				}
				break;
			case 3850864715u:
				if (text4 == "HDDangBai")
				{
					form = new fHDDangBai("", text);
				}
				break;
			case 4062736188u:
				if (text4 == "HDXoaSdt")
				{
					form = new fHDXoaSdt("", text);
				}
				break;
			case 3917587807u:
				if (text4 == "HDHuyLoiMoiKetBan")
				{
					form = new fHDHuyLoiMoiKetBan("", text);
				}
				break;
			case 4167715081u:
				if (text4 == "HDHuyLienKetInstagram")
				{
					form = new fHDHuyLienKetInstagram("", text);
				}
				break;
			case 4095834327u:
				if (text4 == "HDXacNhanKetBan")
				{
					form = new fHDXacNhanKetBan("", text);
				}
				break;
			case 4226158249u:
				if (text4 == "HDKetBanThanhVienNhom")
				{
					form = new fHDKetBanThanhVienNhom("", text);
				}
				break;
			case 4198930712u:
				if (text4 == "HDXoaThietBiTinCay")
				{
					form = new fHDXoaThietBiTinCay("", text);
				}
				break;
			case 4189681400u:
				if (text4 == "HDSpamBaiViet")
				{
					form = new fHDSpamBaiViet("", text);
				}
				break;
			}
			if (form != null)
			{
				Commom.smethod_35(form);
			}
			dataTable = Class154.E6AD9687(text);
			EAB09F19.smethod_3(dtgvHanhDong, dataGridViewRow.Index, "cTenHanhDong", dataTable.Rows[0]["TenHanhDong"].ToString());
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void EC957A2F(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
		case Keys.Delete:
			method_6();
			break;
		case Keys.Insert:
		case Keys.F1:
			method_8();
			break;
		case Keys.F2:
			method_7();
			break;
		case Keys.F5:
			method_5();
			break;
		case Keys.D:
			if (e.Modifiers == Keys.Control)
			{
				method_9();
			}
			break;
		}
	}

	private void method_5(string string_1 = "")
	{
		try
		{
			CBB92634.Rows.Clear();
			DataTable dataTable = Class154.smethod_2();
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = dataTable.Rows[i];
					CBB92634.Rows.Add(i + 1, dataRow["Id_KichBan"], dataRow["TenKichBan"]);
				}
			}
			if (string_1 != "")
			{
				for (int j = 0; j < CBB92634.RowCount; j++)
				{
					if (EAB09F19.E2A1ED2F(CBB92634, j, "cId_KichBan") == string_1)
					{
						CBB92634.Rows[j].Selected = true;
						break;
					}
				}
			}
			method_3();
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
		}
	}

	private void method_6()
	{
		try
		{
			if (CBB92634.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm kịch bản trước!", 3);
			}
			else
			{
				if (MsBoxHelper.D41C45AC("Bạn có chắc muốn xóa kịch bản này?") != DialogResult.Yes)
				{
					return;
				}
				DataGridViewRow dataGridViewRow = CBB92634.SelectedRows[0];
				if (Class154.smethod_7(dataGridViewRow.Cells["cId_KichBan"].Value.ToString()))
				{
					int index = dataGridViewRow.Index;
					for (int i = index; i < CBB92634.Rows.Count - 1; i++)
					{
						method_0(ref CBB92634, i, i + 1);
					}
					CBB92634.Rows.RemoveAt(CBB92634.Rows.Count - 1);
					method_3();
				}
				else
				{
					MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
				}
				return;
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void method_7()
	{
		try
		{
			if (CBB92634.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm kịch bản trước!", 3);
				return;
			}
			DataGridViewRow dataGridViewRow = CBB92634.SelectedRows[0];
			string text = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
			Commom.smethod_35(new fThemKichBan(1, text));
			string object_ = Class154.smethod_1(text).Rows[0]["TenKichBan"].ToString();
			EAB09F19.smethod_3(CBB92634, dataGridViewRow.Index, "cTenKichBan", object_);
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void method_8()
	{
		try
		{
			string text = "";
			try
			{
				text = Class154.BA00569F().Rows[0]["Id_KichBan"].ToString();
			}
			catch
			{
			}
			Commom.smethod_35(new fThemKichBan(0));
			DataTable dataTable = Class154.BA00569F();
			string text2 = "";
			try
			{
				text2 = dataTable.Rows[0]["Id_KichBan"].ToString();
			}
			catch
			{
			}
			if (text != text2)
			{
				CBB92634.Rows.Add(CBB92634.RowCount + 1, dataTable.Rows[0]["Id_KichBan"], dataTable.Rows[0]["TenKichBan"]);
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_);
			MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
		}
	}

	private void method_9()
	{
		try
		{
			if (CBB92634.RowCount == 0)
			{
				MsBoxHelper.Show("Vui lòng thêm kịch bản trước!", 3);
				return;
			}
			DataGridViewRow dataGridViewRow = CBB92634.SelectedRows[0];
			string text = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
			string text2 = dataGridViewRow.Cells["cTenKichBan"].Value.ToString();
			string text3 = text2 + " - Copy";
			int num = 2;
			while (Class154.smethod_4(text3))
			{
				text3 = text2 + $" - Copy ({num++})";
			}
			if (Class154.smethod_8(text, text3))
			{
				DataTable dataTable = Class154.BA00569F();
				CBB92634.Rows.Add(CBB92634.RowCount + 1, dataTable.Rows[0]["Id_KichBan"], dataTable.Rows[0]["TenKichBan"]);
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
		catch
		{
		}
	}

	private void CBB92634_KeyUp(object sender, KeyEventArgs e)
	{
		Keys keyCode = e.KeyCode;
		Keys keys = keyCode;
		if (keys == Keys.Up || keys == Keys.Down)
		{
			method_3();
		}
	}

	private void fDanhSachKichBan_Old_Paint(object sender, PaintEventArgs e)
	{
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

	private void D60BEE35(object sender, EventArgs e)
	{
		method_8();
	}

	private void DC904CB0_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private void DB20DEB3_Click(object sender, EventArgs e)
	{
		method_6();
	}

	private void button6_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void button14_Click(object sender, EventArgs e)
	{
		E03B2492();
	}

	private void ED078289(object sender, EventArgs e)
	{
		FE954D38();
	}

	private void button12_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void F8B45F8F(object sender, EventArgs e)
	{
		method_2();
	}

	private void F787C437(object sender, EventArgs e)
	{
		int index = dtgvHanhDong.SelectedRows[0].Index;
		if (index == 0)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(dtgvHanhDong, index - 1, "cId_HanhDong");
		string text2 = EAB09F19.E2A1ED2F(dtgvHanhDong, index, "cId_HanhDong");
		if (text + text2 != "")
		{
			if (Class154.smethod_14(text, text2))
			{
				method_0(ref dtgvHanhDong, index, index - 1);
				dtgvHanhDong.Rows[index - 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void button9_Click(object sender, EventArgs e)
	{
		int index = dtgvHanhDong.SelectedRows[0].Index;
		if (index == dtgvHanhDong.RowCount - 1)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(dtgvHanhDong, index + 1, "cId_HanhDong");
		string text2 = EAB09F19.E2A1ED2F(dtgvHanhDong, index, "cId_HanhDong");
		if (text + text2 != "")
		{
			if (Class154.smethod_14(text, text2))
			{
				method_0(ref dtgvHanhDong, index, index + 1);
				dtgvHanhDong.Rows[index + 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		int index = CBB92634.SelectedRows[0].Index;
		if (index == 0)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(CBB92634, index - 1, "cId_KichBan");
		string text2 = EAB09F19.E2A1ED2F(CBB92634, index, "cId_KichBan");
		if (text + text2 != "")
		{
			if (Class154.D028FD87(text, text2))
			{
				Commom.smethod_75(ref CBB92634, index, index - 1);
				CBB92634.Rows[index - 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void A52398A4_Click(object sender, EventArgs e)
	{
		int index = CBB92634.SelectedRows[0].Index;
		if (index == CBB92634.RowCount - 1)
		{
			return;
		}
		string text = EAB09F19.E2A1ED2F(CBB92634, index + 1, "cId_KichBan");
		string text2 = EAB09F19.E2A1ED2F(CBB92634, index, "cId_KichBan");
		if (text + text2 != "")
		{
			if (Class154.D028FD87(text, text2))
			{
				Commom.smethod_75(ref CBB92634, index, index + 1);
				CBB92634.Rows[index + 1].Selected = true;
			}
			else
			{
				MsBoxHelper.Show("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
			}
		}
	}

	private void A00E86BF(object sender, EventArgs e)
	{
		CA232EBF.Visible = A795C38E.SelectedValue.ToString() == "1";
	}

	private void D106073E()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Tâ\u0301t ca\u0309");
		dictionary.Add("1", "Tu\u0300y chi\u0309nh");
		Commom.smethod_24(A795C38E, dictionary);
	}

	private void AC053181(object sender, EventArgs e)
	{
		try
		{
			GClass4 gClass = new GClass4();
			gClass.method_4("cbbCountAction", A795C38E.SelectedIndex);
			gClass.method_4("nudCountActionFrom", C93377A8.Value);
			gClass.method_4("nudCountActionTo", nudCountActionTo.Value);
			gClass.method_4("ckbRandomAction", ckbRandomAction.Checked);
			DataGridViewRow dataGridViewRow = CBB92634.SelectedRows[0];
			string f19FEA2A = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
			Class154.D912C107(f19FEA2A, gClass.ED11179C());
			MsBoxHelper.Show("Lưu thành công!");
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show("Lỗi Lưu cấu hình kịch bản!\r\n" + ex.ToString(), 2);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDanhSachKichBan_Old));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		EA1B7F1F = new System.Windows.Forms.GroupBox();
		A52398A4 = new System.Windows.Forms.Button();
		button7 = new System.Windows.Forms.Button();
		button6 = new System.Windows.Forms.Button();
		DB20DEB3 = new System.Windows.Forms.Button();
		DC904CB0 = new System.Windows.Forms.Button();
		D92B388E = new System.Windows.Forms.Button();
		CBB92634 = new System.Windows.Forms.DataGridView();
		cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
		AF308E3C = new System.Windows.Forms.DataGridViewTextBoxColumn();
		F99B69B6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		B711ED09 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		C2A119A9 = new System.Windows.Forms.ToolStripMenuItem();
		F530009D = new System.Windows.Forms.ToolStripMenuItem();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		CDAB3C35 = new System.Windows.Forms.GroupBox();
		button9 = new System.Windows.Forms.Button();
		button10 = new System.Windows.Forms.Button();
		B0351F99 = new System.Windows.Forms.Button();
		button12 = new System.Windows.Forms.Button();
		button13 = new System.Windows.Forms.Button();
		button14 = new System.Windows.Forms.Button();
		groupBox3 = new System.Windows.Forms.GroupBox();
		ckbRandomAction = new System.Windows.Forms.CheckBox();
		A795C38E = new System.Windows.Forms.ComboBox();
		label1 = new System.Windows.Forms.Label();
		CA232EBF = new System.Windows.Forms.Panel();
		nudCountActionTo = new System.Windows.Forms.NumericUpDown();
		C93377A8 = new System.Windows.Forms.NumericUpDown();
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		D8A3638B = new System.Windows.Forms.Button();
		dtgvHanhDong = new System.Windows.Forms.DataGridView();
		AA0D3639 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		cId_HanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
		D8AC35A2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		E3074F9A = new System.Windows.Forms.DataGridViewTextBoxColumn();
		contextMenuStrip1_1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
		toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		F8B44FAC = new System.Windows.Forms.ToolStripMenuItem();
		panel1 = new System.Windows.Forms.Panel();
		D619C29A = new System.Windows.Forms.SplitContainer();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		EA1B7F1F.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)CBB92634).BeginInit();
		contextMenuStrip1.SuspendLayout();
		bunifuCards1.SuspendLayout();
		CDAB3C35.SuspendLayout();
		groupBox3.SuspendLayout();
		CA232EBF.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudCountActionTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)C93377A8).BeginInit();
		((System.ComponentModel.ISupportInitialize)dtgvHanhDong).BeginInit();
		contextMenuStrip1_1.SuspendLayout();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)D619C29A).BeginInit();
		D619C29A.Panel1.SuspendLayout();
		D619C29A.Panel2.SuspendLayout();
		D619C29A.SuspendLayout();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = bunifuCustomLabel1;
		bunifuDragControl_0.Vertical = true;
		bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
		bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
		bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
		bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
		bunifuCustomLabel1.Name = "bunifuCustomLabel1";
		bunifuCustomLabel1.Size = new System.Drawing.Size(951, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Qua\u0309n ly\u0301 ki\u0323ch ba\u0309n";
		bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		bunifuDragControl_1.Fixed = true;
		bunifuDragControl_1.Horizontal = true;
		bunifuDragControl_1.TargetControl = pnlHeader;
		bunifuDragControl_1.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(button1);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(986, 31);
		pnlHeader.TabIndex = 9;
		button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(957, 2);
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
		EA1B7F1F.BackColor = System.Drawing.Color.White;
		EA1B7F1F.Controls.Add(A52398A4);
		EA1B7F1F.Controls.Add(button7);
		EA1B7F1F.Controls.Add(button6);
		EA1B7F1F.Controls.Add(DB20DEB3);
		EA1B7F1F.Controls.Add(DC904CB0);
		EA1B7F1F.Controls.Add(D92B388E);
		EA1B7F1F.Controls.Add(CBB92634);
		EA1B7F1F.Dock = System.Windows.Forms.DockStyle.Fill;
		EA1B7F1F.Location = new System.Drawing.Point(0, 0);
		EA1B7F1F.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		EA1B7F1F.Name = "groupBox1";
		EA1B7F1F.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		EA1B7F1F.Size = new System.Drawing.Size(330, 517);
		EA1B7F1F.TabIndex = 1;
		EA1B7F1F.TabStop = false;
		EA1B7F1F.Text = "Danh sách kịch bản";
		A52398A4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A52398A4.Cursor = System.Windows.Forms.Cursors.Hand;
		A52398A4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		A52398A4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A52398A4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A52398A4.Image = Class155.B4286B82;
		A52398A4.Location = new System.Drawing.Point(297, 15);
		A52398A4.Name = "button8";
		A52398A4.Padding = new System.Windows.Forms.Padding(3);
		A52398A4.Size = new System.Drawing.Size(27, 27);
		A52398A4.TabIndex = 77;
		A52398A4.Click += new System.EventHandler(A52398A4_Click);
		button7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button7.Cursor = System.Windows.Forms.Cursors.Hand;
		button7.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button7.Image = Class155.Bitmap_153;
		button7.Location = new System.Drawing.Point(265, 15);
		button7.Name = "button7";
		button7.Padding = new System.Windows.Forms.Padding(3);
		button7.Size = new System.Drawing.Size(27, 27);
		button7.TabIndex = 77;
		button7.Click += new System.EventHandler(button7_Click);
		button6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button6.Cursor = System.Windows.Forms.Cursors.Hand;
		button6.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button6.Image = Class155.Bitmap_78;
		button6.Location = new System.Drawing.Point(232, 15);
		button6.Name = "button6";
		button6.Padding = new System.Windows.Forms.Padding(3);
		button6.Size = new System.Drawing.Size(27, 27);
		button6.TabIndex = 77;
		button6.Click += new System.EventHandler(button6_Click);
		DB20DEB3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		DB20DEB3.Cursor = System.Windows.Forms.Cursors.Hand;
		DB20DEB3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		DB20DEB3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DB20DEB3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DB20DEB3.Image = Class155.Bitmap_86;
		DB20DEB3.Location = new System.Drawing.Point(199, 15);
		DB20DEB3.Name = "button5";
		DB20DEB3.Padding = new System.Windows.Forms.Padding(3);
		DB20DEB3.Size = new System.Drawing.Size(27, 27);
		DB20DEB3.TabIndex = 77;
		DB20DEB3.Click += new System.EventHandler(DB20DEB3_Click);
		DC904CB0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		DC904CB0.Cursor = System.Windows.Forms.Cursors.Hand;
		DC904CB0.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		DC904CB0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		DC904CB0.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DC904CB0.Image = Class155.Bitmap_91;
		DC904CB0.Location = new System.Drawing.Point(166, 15);
		DC904CB0.Name = "button4";
		DC904CB0.Padding = new System.Windows.Forms.Padding(3);
		DC904CB0.Size = new System.Drawing.Size(27, 27);
		DC904CB0.TabIndex = 77;
		DC904CB0.Click += new System.EventHandler(DC904CB0_Click);
		D92B388E.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D92B388E.Cursor = System.Windows.Forms.Cursors.Hand;
		D92B388E.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		D92B388E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D92B388E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D92B388E.Image = Class155.E6109034;
		D92B388E.Location = new System.Drawing.Point(133, 15);
		D92B388E.Name = "btnQuanLyKichBan";
		D92B388E.Padding = new System.Windows.Forms.Padding(3);
		D92B388E.Size = new System.Drawing.Size(27, 27);
		D92B388E.TabIndex = 77;
		D92B388E.Click += new System.EventHandler(D60BEE35);
		CBB92634.AllowUserToAddRows = false;
		CBB92634.AllowUserToDeleteRows = false;
		CBB92634.AllowUserToResizeRows = false;
		CBB92634.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		CBB92634.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		CBB92634.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		CBB92634.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		CBB92634.Columns.AddRange(cStt, AF308E3C, F99B69B6);
		CBB92634.ContextMenuStrip = contextMenuStrip1;
		CBB92634.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		CBB92634.Location = new System.Drawing.Point(6, 48);
		CBB92634.MultiSelect = false;
		CBB92634.Name = "dtgvKichBan";
		CBB92634.RowHeadersVisible = false;
		CBB92634.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		CBB92634.Size = new System.Drawing.Size(318, 462);
		CBB92634.TabIndex = 76;
		CBB92634.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(FCB9CFB0);
		CBB92634.KeyDown += new System.Windows.Forms.KeyEventHandler(EC957A2F);
		CBB92634.KeyUp += new System.Windows.Forms.KeyEventHandler(CBB92634_KeyUp);
		cStt.HeaderText = "STT";
		cStt.Name = "cStt";
		cStt.Width = 35;
		AF308E3C.HeaderText = "Column1";
		AF308E3C.Name = "cId_KichBan";
		AF308E3C.Visible = false;
		F99B69B6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		F99B69B6.HeaderText = "Tên kịch bản";
		F99B69B6.Name = "cTenKichBan";
		F99B69B6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { B711ED09, toolStripMenuItem_0, C2A119A9, F530009D });
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(162, 92);
		B711ED09.Image = Class155.E6109034;
		B711ED09.Name = "thêmMớiToolStripMenuItem";
		B711ED09.Size = new System.Drawing.Size(161, 22);
		B711ED09.Text = "Thêm ki\u0323ch ba\u0309n";
		B711ED09.Click += new System.EventHandler(B711ED09_Click);
		toolStripMenuItem_0.Image = Class155.Bitmap_91;
		toolStripMenuItem_0.Name = "sửaToolStripMenuItem";
		toolStripMenuItem_0.Size = new System.Drawing.Size(161, 22);
		toolStripMenuItem_0.Text = "Sửa tên ki\u0323ch ba\u0309n";
		toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
		C2A119A9.Image = Class155.Bitmap_86;
		C2A119A9.Name = "xóaToolStripMenuItem";
		C2A119A9.Size = new System.Drawing.Size(161, 22);
		C2A119A9.Text = "Xóa ki\u0323ch ba\u0309n";
		C2A119A9.Click += new System.EventHandler(DE0C143D);
		F530009D.Image = Class155.Bitmap_78;
		F530009D.Name = "nhânBảnToolStripMenuItem";
		F530009D.Size = new System.Drawing.Size(161, 22);
		F530009D.Text = "Nhân bản";
		F530009D.Click += new System.EventHandler(F530009D_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(989, 37);
		bunifuCards1.TabIndex = 12;
		CDAB3C35.BackColor = System.Drawing.Color.White;
		CDAB3C35.Controls.Add(button9);
		CDAB3C35.Controls.Add(button10);
		CDAB3C35.Controls.Add(B0351F99);
		CDAB3C35.Controls.Add(button12);
		CDAB3C35.Controls.Add(button13);
		CDAB3C35.Controls.Add(button14);
		CDAB3C35.Controls.Add(groupBox3);
		CDAB3C35.Controls.Add(dtgvHanhDong);
		CDAB3C35.Dock = System.Windows.Forms.DockStyle.Fill;
		CDAB3C35.Location = new System.Drawing.Point(0, 0);
		CDAB3C35.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		CDAB3C35.Name = "groupBox2";
		CDAB3C35.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		CDAB3C35.Size = new System.Drawing.Size(639, 517);
		CDAB3C35.TabIndex = 1;
		CDAB3C35.TabStop = false;
		CDAB3C35.Text = "Danh sách hành động";
		button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button9.Cursor = System.Windows.Forms.Cursors.Hand;
		button9.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button9.Image = Class155.Bitmap_88;
		button9.Location = new System.Drawing.Point(606, 15);
		button9.Name = "button9";
		button9.Padding = new System.Windows.Forms.Padding(3);
		button9.Size = new System.Drawing.Size(27, 27);
		button9.TabIndex = 84;
		button9.Click += new System.EventHandler(button9_Click);
		button10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button10.Cursor = System.Windows.Forms.Cursors.Hand;
		button10.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button10.Image = Class155.Bitmap_154;
		button10.Location = new System.Drawing.Point(574, 15);
		button10.Name = "button10";
		button10.Padding = new System.Windows.Forms.Padding(3);
		button10.Size = new System.Drawing.Size(27, 27);
		button10.TabIndex = 85;
		button10.Click += new System.EventHandler(F787C437);
		B0351F99.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		B0351F99.Cursor = System.Windows.Forms.Cursors.Hand;
		B0351F99.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		B0351F99.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B0351F99.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B0351F99.Image = Class155.AE116F9B;
		B0351F99.Location = new System.Drawing.Point(541, 15);
		B0351F99.Name = "button11";
		B0351F99.Padding = new System.Windows.Forms.Padding(3);
		B0351F99.Size = new System.Drawing.Size(27, 27);
		B0351F99.TabIndex = 86;
		B0351F99.Click += new System.EventHandler(F8B45F8F);
		button12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button12.Cursor = System.Windows.Forms.Cursors.Hand;
		button12.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button12.Image = Class155.Bitmap_85;
		button12.Location = new System.Drawing.Point(508, 15);
		button12.Name = "button12";
		button12.Padding = new System.Windows.Forms.Padding(3);
		button12.Size = new System.Drawing.Size(27, 27);
		button12.TabIndex = 87;
		button12.Click += new System.EventHandler(button12_Click);
		button13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button13.Cursor = System.Windows.Forms.Cursors.Hand;
		button13.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button13.Image = Class155.Bitmap_90;
		button13.Location = new System.Drawing.Point(475, 15);
		button13.Name = "button13";
		button13.Padding = new System.Windows.Forms.Padding(3);
		button13.Size = new System.Drawing.Size(27, 27);
		button13.TabIndex = 88;
		button13.Click += new System.EventHandler(ED078289);
		button14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button14.Cursor = System.Windows.Forms.Cursors.Hand;
		button14.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button14.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button14.Image = Class155.BF19D114;
		button14.Location = new System.Drawing.Point(442, 15);
		button14.Name = "button14";
		button14.Padding = new System.Windows.Forms.Padding(3);
		button14.Size = new System.Drawing.Size(27, 27);
		button14.TabIndex = 89;
		button14.Click += new System.EventHandler(button14_Click);
		groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		groupBox3.Controls.Add(ckbRandomAction);
		groupBox3.Controls.Add(A795C38E);
		groupBox3.Controls.Add(label1);
		groupBox3.Controls.Add(CA232EBF);
		groupBox3.Controls.Add(D8A3638B);
		groupBox3.Location = new System.Drawing.Point(6, 432);
		groupBox3.Name = "groupBox3";
		groupBox3.Size = new System.Drawing.Size(627, 78);
		groupBox3.TabIndex = 83;
		groupBox3.TabStop = false;
		groupBox3.Text = "Cấu hình kịch bản";
		ckbRandomAction.AutoSize = true;
		ckbRandomAction.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbRandomAction.Location = new System.Drawing.Point(9, 51);
		ckbRandomAction.Name = "ckbRandomAction";
		ckbRandomAction.Size = new System.Drawing.Size(178, 20);
		ckbRandomAction.TabIndex = 83;
		ckbRandomAction.Text = "Xáo trộn thứ tự hành động";
		ckbRandomAction.UseVisualStyleBackColor = true;
		A795C38E.Cursor = System.Windows.Forms.Cursors.Hand;
		A795C38E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		A795C38E.FormattingEnabled = true;
		A795C38E.Location = new System.Drawing.Point(133, 20);
		A795C38E.Name = "cbbCountAction";
		A795C38E.Size = new System.Drawing.Size(172, 24);
		A795C38E.TabIndex = 82;
		A795C38E.SelectedIndexChanged += new System.EventHandler(A00E86BF);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(6, 23);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(121, 16);
		label1.TabIndex = 79;
		label1.Text = "Sô\u0301 ha\u0300nh đô\u0323ng cha\u0323y:";
		CA232EBF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		CA232EBF.Controls.Add(nudCountActionTo);
		CA232EBF.Controls.Add(C93377A8);
		CA232EBF.Controls.Add(label3);
		CA232EBF.Controls.Add(label2);
		CA232EBF.Location = new System.Drawing.Point(311, 17);
		CA232EBF.Name = "plCountAction";
		CA232EBF.Size = new System.Drawing.Size(188, 31);
		CA232EBF.TabIndex = 81;
		nudCountActionTo.Location = new System.Drawing.Point(71, 3);
		nudCountActionTo.Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		nudCountActionTo.Name = "nudCountActionTo";
		nudCountActionTo.Size = new System.Drawing.Size(43, 23);
		nudCountActionTo.TabIndex = 0;
		C93377A8.Location = new System.Drawing.Point(2, 3);
		C93377A8.Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		C93377A8.Name = "nudCountActionFrom";
		C93377A8.Size = new System.Drawing.Size(43, 23);
		C93377A8.TabIndex = 0;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(117, 6);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(67, 16);
		label3.TabIndex = 79;
		label3.Text = "hành động";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(49, 5);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(18, 16);
		label2.TabIndex = 79;
		label2.Text = ">";
		D8A3638B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		D8A3638B.Cursor = System.Windows.Forms.Cursors.Hand;
		D8A3638B.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		D8A3638B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		D8A3638B.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		D8A3638B.Location = new System.Drawing.Point(523, 17);
		D8A3638B.Name = "btnSave";
		D8A3638B.Padding = new System.Windows.Forms.Padding(3);
		D8A3638B.Size = new System.Drawing.Size(98, 54);
		D8A3638B.TabIndex = 77;
		D8A3638B.Text = "Lưu";
		D8A3638B.Click += new System.EventHandler(AC053181);
		dtgvHanhDong.AllowUserToAddRows = false;
		dtgvHanhDong.AllowUserToDeleteRows = false;
		dtgvHanhDong.AllowUserToResizeRows = false;
		dtgvHanhDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		dtgvHanhDong.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		dtgvHanhDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dtgvHanhDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dtgvHanhDong.Columns.AddRange(AA0D3639, cId_HanhDong, D8AC35A2, E3074F9A);
		dtgvHanhDong.ContextMenuStrip = contextMenuStrip1_1;
		dtgvHanhDong.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		dtgvHanhDong.Location = new System.Drawing.Point(6, 48);
		dtgvHanhDong.MultiSelect = false;
		dtgvHanhDong.Name = "dtgvHanhDong";
		dtgvHanhDong.RowHeadersVisible = false;
		dtgvHanhDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		dtgvHanhDong.Size = new System.Drawing.Size(627, 378);
		dtgvHanhDong.TabIndex = 77;
		dtgvHanhDong.KeyDown += new System.Windows.Forms.KeyEventHandler(dtgvHanhDong_KeyDown);
		AA0D3639.HeaderText = "STT";
		AA0D3639.Name = "dataGridViewTextBoxColumn1";
		AA0D3639.Width = 35;
		cId_HanhDong.HeaderText = "Column1";
		cId_HanhDong.Name = "cId_HanhDong";
		cId_HanhDong.Visible = false;
		D8AC35A2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		D8AC35A2.HeaderText = "Tên hành động";
		D8AC35A2.Name = "cTenHanhDong";
		D8AC35A2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		E3074F9A.HeaderText = "Loại tương tác";
		E3074F9A.Name = "cTheLoai";
		E3074F9A.Width = 175;
		contextMenuStrip1_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem1, toolStripMenuItem3, toolStripMenuItem4, F8B44FAC });
		contextMenuStrip1_1.Name = "contextMenuStrip1";
		contextMenuStrip1_1.Size = new System.Drawing.Size(166, 92);
		toolStripMenuItem1.Image = Class155.BF19D114;
		toolStripMenuItem1.Name = "toolStripMenuItem1";
		toolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
		toolStripMenuItem1.Text = "Thêm ha\u0300nh đô\u0323ng";
		toolStripMenuItem1.Click += new System.EventHandler(BEA1D884);
		toolStripMenuItem3.Image = Class155.Bitmap_90;
		toolStripMenuItem3.Name = "toolStripMenuItem3";
		toolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
		toolStripMenuItem3.Text = "Sửa ha\u0300nh đô\u0323ng";
		toolStripMenuItem3.Click += new System.EventHandler(D6B06BBB);
		toolStripMenuItem4.Image = Class155.Bitmap_85;
		toolStripMenuItem4.Name = "toolStripMenuItem4";
		toolStripMenuItem4.Size = new System.Drawing.Size(165, 22);
		toolStripMenuItem4.Text = "Xóa ha\u0300nh đô\u0323ng";
		toolStripMenuItem4.Click += new System.EventHandler(toolStripMenuItem4_Click);
		F8B44FAC.Image = Class155.AE116F9B;
		F8B44FAC.Name = "toolStripMenuItem2";
		F8B44FAC.Size = new System.Drawing.Size(165, 22);
		F8B44FAC.Text = "Nhân bản";
		F8B44FAC.Click += new System.EventHandler(F8B44FAC_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(D619C29A);
		panel1.Controls.Add(bunifuCards1);
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(992, 565);
		panel1.TabIndex = 13;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		D619C29A.Location = new System.Drawing.Point(4, 40);
		D619C29A.Name = "splitContainer1";
		D619C29A.Panel1.Controls.Add(EA1B7F1F);
		D619C29A.Panel2.Controls.Add(CDAB3C35);
		D619C29A.Size = new System.Drawing.Size(984, 517);
		D619C29A.SplitterDistance = 330;
		D619C29A.SplitterWidth = 15;
		D619C29A.TabIndex = 13;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(992, 565);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fDanhSachKichBan_Old";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(AA3FEF8C);
		base.Paint += new System.Windows.Forms.PaintEventHandler(fDanhSachKichBan_Old_Paint);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		EA1B7F1F.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)CBB92634).EndInit();
		contextMenuStrip1.ResumeLayout(false);
		bunifuCards1.ResumeLayout(false);
		CDAB3C35.ResumeLayout(false);
		groupBox3.ResumeLayout(false);
		groupBox3.PerformLayout();
		CA232EBF.ResumeLayout(false);
		CA232EBF.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudCountActionTo).EndInit();
		((System.ComponentModel.ISupportInitialize)C93377A8).EndInit();
		((System.ComponentModel.ISupportInitialize)dtgvHanhDong).EndInit();
		contextMenuStrip1_1.ResumeLayout(false);
		panel1.ResumeLayout(false);
		D619C29A.Panel1.ResumeLayout(false);
		D619C29A.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)D619C29A).EndInit();
		D619C29A.ResumeLayout(false);
		ResumeLayout(false);
	}
}
