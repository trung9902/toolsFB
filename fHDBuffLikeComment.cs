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

public class fHDBuffLikeComment : Form
{
	internal GClass4 gclass4_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static bool bool_0;

	internal List<CheckBox> list_0;

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl A9AED713;

	internal Panel panel1;

	internal NumericUpDown nudDelayTo;

	internal NumericUpDown nudDelayFrom;

	internal TextBox txtTenHanhDong;

	internal Label label7;

	internal Label label5;

	internal Label D42558A3;

	internal Button B504C090;

	internal Button A1351F91;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button F5BC9C86;

	internal PictureBox pictureBox1;

	internal BunifuCustomLabel CFA7D9B7;

	internal CheckBox ckbShareWall;

	internal Label label2;

	internal NumericUpDown F6292C04;

	internal NumericUpDown nudTimeFrom;

	internal Label A21CC930;

	internal Label label3;

	internal Panel CEA70537;

	internal RichTextBox AE05AF3F;

	internal Label lblComment;

	internal Panel plAnh;

	internal TextBox txtAnh;

	internal RichTextBox txtIdPost;

	internal CheckBox ckbSendAnh;

	internal CheckBox DE29351B;

	internal Label label12;

	internal Label label49;

	internal NumericUpDown nudSoLuongUidFrom;

	internal NumericUpDown ED0E7190;

	internal Label label66;

	internal RadioButton rbCommentNgauNhien;

	internal RadioButton rbCommentTheoThuTu;

	internal Label CE934127;

	internal Button A99FC29A;

	internal Button CE96E13B;

	internal Panel panel3;

	internal CheckBox EC8CEAB0;

	internal Panel plTag;

	internal NumericUpDown nudSoLuongTagTo;

	internal Label label16;

	internal NumericUpDown C4B7AE2F;

	internal Label label14;

	internal CheckBox ckbTag;

	internal CheckBox A606D2B4;

	internal ComboBox cbbTuyChonNoiDung;

	internal Button F98C7DB6;

	internal Label E1373124;

	internal CheckBox ckbTuDongXoa;

	internal Panel panel2;

	internal Panel BD2EF88B;

	internal CheckBox ckbAngry;

	internal CheckBox ckbSad;

	internal CheckBox D61D0ABD;

	internal CheckBox B336C0B0;

	internal CheckBox ckbCare;

	internal CheckBox ckbLove;

	internal CheckBox ckbLike;

	internal Panel C62E47A0;

	internal RadioButton radioButton3;

	internal RadioButton DFB45D36;

	internal Label label26;

	internal CheckBox C4B808B6;

	internal Panel plContentShare;

	internal ComboBox cbbTuyChonNoiDungShare;

	internal Button button2;

	internal Label label15;

	internal CheckBox F285EEB9;

	internal Panel E7B4F219;

	internal RadioButton radioButton1;

	internal RadioButton A0ADDAA2;

	internal Label A336808B;

	internal RichTextBox txtContentShare;

	internal Label lblContentShare;

	internal CheckBox C3A154AE;

	internal Panel BD12A818;

	internal ComboBox E58E2D9F;

	internal Button button3;

	internal Label DABE5B33;

	internal RichTextBox txtCommentEdit;

	internal Label E090F495;

	internal Label label6;

	internal Label DC835B80;

	internal NumericUpDown nudDelayEditFrom;

	internal NumericUpDown nudDelayEditTo;

	internal CheckBox ckbEditComment;

	internal CheckBox ckbUuTienMbasic;

	internal Panel BBB062AB;

	internal Panel panel5;

	internal RadioButton F5128598;

	internal RadioButton AB26F3BE;

	internal Label ADA1A48C;

	internal RichTextBox txtContentShareMess;

	internal Label lblContentShareMess;

	internal CheckBox ckbShareMess;

	internal Label label22;

	internal Label FCA215A9;

	internal Label label20;

	internal NumericUpDown nudDelayMessFrom;

	internal NumericUpDown A112F898;

	internal Label label21;

	internal NumericUpDown nudSoLuongMessTo;

	internal NumericUpDown nudSoLuongMessFrom;

	internal ComboBox cbbTuyChonNoiDungShareMess;

	internal Button button4;

	internal Label label23;

	internal CheckBox ckbAutoDeleteContentShareMess;

	internal Panel plDeleteComment;

	internal Label A78232B3;

	internal Label label27;

	internal NumericUpDown nudDelayDeleteFrom;

	internal NumericUpDown nudDelayDeleteTo;

	internal CheckBox ckbDeleteComment;

	internal CheckBox ckbTaoNoiDungAI;

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

	public fHDBuffLikeComment(string string_3, string C89E4F12 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = string_3;
		string_2 = C89E4F12;
		string aA239C = Language.GetValue(CFA7D9B7.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (C89E4F12 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			txtTenHanhDong.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(C89E4F12);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			A1351F91.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			txtTenHanhDong.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		gclass4_0 = new GClass4(text2, F79F9AB5: true);
		Language.CD21F0A9(this);
		list_0 = new List<CheckBox> { ckbLike, ckbLove, ckbCare, B336C0B0, D61D0ABD, ckbSad, ckbAngry };
	}

	private void fHDBuffLikeComment_Load(object sender, EventArgs e)
	{
		method_0();
		C51AC625();
		method_1();
		CB1519B4();
		try
		{
			nudSoLuongUidFrom.Value = gclass4_0.method_2("nudSoLuongUidFrom", 1);
			ED0E7190.Value = gclass4_0.method_2("nudSoLuongUidTo", 1);
			nudDelayFrom.Value = gclass4_0.method_2("nudDelayFrom", 3);
			nudDelayTo.Value = gclass4_0.method_2("nudDelayTo", 5);
			txtIdPost.Text = gclass4_0.BDB80B23("txtIdPost");
			ckbTuDongXoa.Checked = gclass4_0.method_3("ckbTuDongXoa");
			ckbUuTienMbasic.Checked = gclass4_0.method_3("ckbUuTienMbasic");
			nudTimeFrom.Value = gclass4_0.method_2("nudTimeFrom", 3);
			F6292C04.Value = gclass4_0.method_2("nudTimeTo", 5);
			C4B808B6.Checked = gclass4_0.method_3("ckbInteract");
			string text = gclass4_0.BDB80B23("typeReaction", "Like");
			if (Commom.smethod_45(text.Replace("|", "")))
			{
				List<string> list = new List<string> { "Like", "Love", "Care", "Haha", "Wow", "Sad", "Angry" };
				for (int i = 0; i < list.Count; i++)
				{
					text = text.Replace(i.ToString(), list[i]);
				}
			}
			List<string> list2 = text.Split('|').ToList();
			for (int j = 0; j < list2.Count; j++)
			{
				foreach (CheckBox item in list_0)
				{
					if (item.Name.Substring(3) == list2[j])
					{
						item.Checked = true;
					}
				}
			}
			DE29351B.Checked = gclass4_0.method_3("ckbComment");
			ckbTaoNoiDungAI.Checked = gclass4_0.method_3("ckbTaoNoiDungAI");
			AE05AF3F.Text = gclass4_0.BDB80B23("txtComment");
			cbbTuyChonNoiDung.SelectedIndex = gclass4_0.method_2("typeNganCach");
			EC8CEAB0.Checked = gclass4_0.method_3("ckbAutoDeleteComment");
			C3A154AE.Checked = gclass4_0.method_3("ckbRunAPI");
			ckbTag.Checked = gclass4_0.method_3("ckbTag");
			C4B7AE2F.Value = gclass4_0.method_2("nudSoLuongTagFrom", 3);
			nudSoLuongTagTo.Value = gclass4_0.method_2("nudSoLuongTagTo", 5);
			A606D2B4.Checked = gclass4_0.method_3("ckbChiTagTenViet");
			ckbSendAnh.Checked = gclass4_0.method_3("ckbSendAnh");
			txtAnh.Text = gclass4_0.BDB80B23("txtAnh");
			Commom.AttachFolderPicker(txtAnh);
			if (gclass4_0.method_2("typeComment") == 1)
			{
				rbCommentNgauNhien.Checked = true;
			}
			else
			{
				rbCommentTheoThuTu.Checked = true;
			}
			ckbShareWall.Checked = gclass4_0.method_3("ckbShareWall");
			txtContentShare.Text = gclass4_0.BDB80B23("txtContentShare");
			cbbTuyChonNoiDungShare.SelectedIndex = gclass4_0.method_2("cbbTuyChonNoiDungShare");
			F285EEB9.Checked = gclass4_0.method_3("ckbAutoDeleteContentShare");
			ckbShareMess.Checked = gclass4_0.method_3("ckbShareMess");
			nudSoLuongMessFrom.Value = gclass4_0.method_2("nudSoLuongMessFrom", 1);
			nudSoLuongMessTo.Value = gclass4_0.method_2("nudSoLuongMessTo", 1);
			nudDelayMessFrom.Value = gclass4_0.method_2("nudDelayMessFrom", 3);
			A112F898.Value = gclass4_0.method_2("nudDelayMessTo", 5);
			txtContentShareMess.Text = gclass4_0.BDB80B23("txtContentShareMess");
			cbbTuyChonNoiDungShareMess.SelectedIndex = gclass4_0.method_2("cbbTuyChonNoiDungShareMess");
			ckbAutoDeleteContentShareMess.Checked = gclass4_0.method_3("ckbAutoDeleteContentShareMess");
			ckbDeleteComment.Checked = gclass4_0.method_3("ckbDeleteComment");
			nudDelayDeleteFrom.Value = gclass4_0.method_2("nudDelayDeleteFrom", 1);
			nudDelayDeleteTo.Value = gclass4_0.method_2("nudDelayDeleteTo", 1);
			ckbEditComment.Checked = gclass4_0.method_3("ckbEditComment");
			nudDelayEditFrom.Value = gclass4_0.method_2("nudDelayEditFrom", 1);
			nudDelayEditTo.Value = gclass4_0.method_2("nudDelayEditTo", 1);
			txtCommentEdit.Text = gclass4_0.BDB80B23("txtCommentEdit");
			E58E2D9F.SelectedIndex = gclass4_0.method_2("cbbTuyChonNoiDungEdit");
		}
		catch
		{
		}
		B836CE05();
	}

	private void method_0()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDung, list);
	}

	private void C51AC625()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(E58E2D9F, list);
	}

	private void method_1()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDungShare, list);
	}

	private void CB1519B4()
	{
		List<string> list = new List<string> { "Nội dung chỉ có 1 dòng", "Nội dung có nhiều dòng" };
		Commom.smethod_23(cbbTuyChonNoiDungShareMess, list);
	}

	private void A2210C3E(object sender, EventArgs e)
	{
		Close();
	}

	private void A1351F91_Click(object sender, EventArgs e)
	{
		string text = txtTenHanhDong.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
			return;
		}
		gclass4_0.method_4("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
		gclass4_0.method_4("nudSoLuongUidTo", ED0E7190.Value);
		gclass4_0.method_4("nudDelayFrom", nudDelayFrom.Value);
		gclass4_0.method_4("nudDelayTo", nudDelayTo.Value);
		gclass4_0.method_4("txtIdPost", txtIdPost.Text.Trim());
		gclass4_0.method_4("ckbTuDongXoa", ckbTuDongXoa.Checked);
		gclass4_0.method_4("ckbUuTienMbasic", ckbUuTienMbasic.Checked);
		gclass4_0.method_4("nudTimeFrom", nudTimeFrom.Value);
		gclass4_0.method_4("nudTimeTo", F6292C04.Value);
		gclass4_0.method_4("ckbInteract", C4B808B6.Checked);
		string text2 = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].Checked)
			{
				text2 = text2 + list_0[i].Name.Substring(3) + "|";
			}
		}
		gclass4_0.method_4("typeReaction", text2.TrimEnd('|'));
		gclass4_0.method_4("ckbComment", DE29351B.Checked);
		gclass4_0.method_4("ckbTaoNoiDungAI", ckbTaoNoiDungAI.Checked);
		gclass4_0.method_4("txtComment", AE05AF3F.Text.Trim());
		gclass4_0.method_4("typeNganCach", cbbTuyChonNoiDung.SelectedIndex);
		gclass4_0.method_4("ckbAutoDeleteComment", EC8CEAB0.Checked);
		gclass4_0.method_4("ckbRunAPI", C3A154AE.Checked);
		gclass4_0.method_4("ckbTag", ckbTag.Checked);
		gclass4_0.method_4("nudSoLuongTagFrom", C4B7AE2F.Value);
		gclass4_0.method_4("nudSoLuongTagTo", nudSoLuongTagTo.Value);
		gclass4_0.method_4("ckbChiTagTenViet", A606D2B4.Checked);
		gclass4_0.method_4("ckbSendAnh", ckbSendAnh.Checked);
		gclass4_0.method_4("txtAnh", txtAnh.Text.Trim());
		int num = 0;
		if (rbCommentNgauNhien.Checked)
		{
			num = 1;
		}
		gclass4_0.method_4("typeComment", num);
		gclass4_0.method_4("ckbShareWall", ckbShareWall.Checked);
		gclass4_0.method_4("txtContentShare", txtContentShare.Text.Trim());
		gclass4_0.method_4("cbbTuyChonNoiDungShare", cbbTuyChonNoiDungShare.SelectedIndex);
		gclass4_0.method_4("ckbAutoDeleteContentShare", F285EEB9.Checked);
		gclass4_0.method_4("ckbShareMess", ckbShareMess.Checked);
		gclass4_0.method_4("nudSoLuongMessFrom", nudSoLuongMessFrom.Value);
		gclass4_0.method_4("nudSoLuongMessTo", nudSoLuongMessTo.Value);
		gclass4_0.method_4("nudDelayMessFrom", nudDelayMessFrom.Value);
		gclass4_0.method_4("nudDelayMessTo", A112F898.Value);
		gclass4_0.method_4("txtContentShareMess", txtContentShareMess.Text.Trim());
		gclass4_0.method_4("cbbTuyChonNoiDungShareMess", cbbTuyChonNoiDungShareMess.SelectedIndex);
		gclass4_0.method_4("ckbAutoDeleteContentShareMess", ckbAutoDeleteContentShareMess.Checked);
		gclass4_0.method_4("ckbDeleteComment", ckbDeleteComment.Checked);
		gclass4_0.method_4("nudDelayDeleteFrom", nudDelayDeleteFrom.Value);
		gclass4_0.method_4("nudDelayDeleteTo", nudDelayDeleteTo.Value);
		gclass4_0.method_4("ckbEditComment", ckbEditComment.Checked);
		gclass4_0.method_4("nudDelayEditFrom", nudDelayEditFrom.Value);
		gclass4_0.method_4("nudDelayEditTo", nudDelayEditTo.Value);
		gclass4_0.method_4("txtCommentEdit", txtCommentEdit.Text.Trim());
		gclass4_0.method_4("cbbTuyChonNoiDungEdit", E58E2D9F.SelectedIndex);
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

	private void D5BF1C91(object sender, EventArgs e)
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

	private void AE05AF3F_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(AE05AF3F, lblComment, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void B836CE05()
	{
		C4B808B6_CheckedChanged(null, null);
		DE29351B_CheckedChanged(null, null);
		ckbTaoNoiDungAI_CheckedChanged(null, null);
		A530658B(null, null);
		AE05AF3F_TextChanged(null, null);
		A882C3A9(null, null);
		F80B739A(null, null);
		FFA34D2A(null, null);
		E5BFBD93(null, null);
		ckbDeleteComment_CheckedChanged(null, null);
	}

	private void C4B808B6_CheckedChanged(object sender, EventArgs e)
	{
		BD2EF88B.Enabled = C4B808B6.Checked;
	}

	private void DE29351B_CheckedChanged(object sender, EventArgs e)
	{
		CEA70537.Enabled = DE29351B.Checked && !ckbTaoNoiDungAI.Checked;
		ckbTaoNoiDungAI.Enabled = DE29351B.Checked;
	}

	private void A98F36A1(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtIdPost, label2);
	}

	private void D8A4A281(object sender, EventArgs e)
	{
		plAnh.Enabled = ckbSendAnh.Checked;
	}

	private void panel1_Click(object sender, EventArgs e)
	{
	}

	private void AD88FB86(object sender, EventArgs e)
	{
	}

	private void label12_Click(object sender, EventArgs e)
	{
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void A336808B_Click(object sender, EventArgs e)
	{
	}

	private void A0ADDAA2_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void CE96E13B_Click(object sender, EventArgs e)
	{
		CEA70537.Height = 276;
	}

	private void A99FC29A_Click(object sender, EventArgs e)
	{
		CEA70537.Height = 358;
		ckbEditComment.Visible = false;
		BD12A818.Visible = false;
	}

	private void A530658B(object sender, EventArgs e)
	{
		plTag.Enabled = ckbTag.Checked;
	}

	private void B424B493(object sender, EventArgs e)
	{
		Commom.A9BCAF05(AE05AF3F, lblComment, cbbTuyChonNoiDung.SelectedIndex);
	}

	private void AE0861B4(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDung.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		AE05AF3F.Focus();
	}

	private void A882C3A9(object sender, EventArgs e)
	{
		ckbSendAnh.Enabled = !C3A154AE.Checked;
		ckbTag.Enabled = !C3A154AE.Checked;
		if (C3A154AE.Checked)
		{
			ckbSendAnh.Checked = false;
			ckbTag.Checked = false;
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDungShare.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtContentShare.Focus();
	}

	private void C3BC5A2D(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContentShare, lblContentShare, cbbTuyChonNoiDungShare.SelectedIndex);
	}

	private void F80B739A(object sender, EventArgs e)
	{
		plContentShare.Enabled = ckbShareWall.Checked;
	}

	private void cbbTuyChonNoiDungShare_SelectedIndexChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContentShare, lblContentShare, cbbTuyChonNoiDungShare.SelectedIndex);
	}

	private void FFA34D2A(object sender, EventArgs e)
	{
		BD12A818.Enabled = ckbEditComment.Checked;
	}

	private void txtCommentEdit_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtCommentEdit, E090F495, E58E2D9F.SelectedIndex);
	}

	private void F69F6D26(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtCommentEdit, E090F495, E58E2D9F.SelectedIndex);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (E58E2D9F.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtCommentEdit.Focus();
	}

	private void E5BFBD93(object sender, EventArgs e)
	{
		BBB062AB.Enabled = ckbShareMess.Checked;
	}

	private void txtContentShareMess_TextChanged(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContentShareMess, lblContentShareMess, cbbTuyChonNoiDungShareMess.SelectedIndex);
	}

	private void button4_Click(object sender, EventArgs e)
	{
		if (cbbTuyChonNoiDungShareMess.SelectedIndex == 0)
		{
			MsBoxHelper.Show("Vui lòng nhập mỗi dòng là 1 nội dung!");
		}
		else
		{
			Commom.smethod_35(new fHelpNhapComment());
		}
		txtContentShareMess.Focus();
	}

	private void ABBBEC31(object sender, EventArgs e)
	{
		Commom.A9BCAF05(txtContentShareMess, lblContentShareMess, cbbTuyChonNoiDungShareMess.SelectedIndex);
	}

	private void ckbDeleteComment_CheckedChanged(object sender, EventArgs e)
	{
		plDeleteComment.Enabled = ckbDeleteComment.Checked;
	}

	private void CEA70537_Paint(object sender, PaintEventArgs e)
	{
	}

	private void ckbTaoNoiDungAI_CheckedChanged(object sender, EventArgs e)
	{
		CEA70537.Enabled = DE29351B.Checked && !ckbTaoNoiDungAI.Checked;
	}

	private void CD21320D(object sender, EventArgs e)
	{
		if (ckbTaoNoiDungAI.Checked)
		{
			Commom.smethod_35(new fChonPrompt(gclass4_0));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDBuffLikeComment));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		CFA7D9B7 = new Bunifu.Framework.UI.BunifuCustomLabel();
		A9AED713 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlHeader = new System.Windows.Forms.Panel();
		F5BC9C86 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		ckbTaoNoiDungAI = new System.Windows.Forms.CheckBox();
		BD2EF88B = new System.Windows.Forms.Panel();
		ckbAngry = new System.Windows.Forms.CheckBox();
		ckbSad = new System.Windows.Forms.CheckBox();
		D61D0ABD = new System.Windows.Forms.CheckBox();
		B336C0B0 = new System.Windows.Forms.CheckBox();
		ckbCare = new System.Windows.Forms.CheckBox();
		ckbLove = new System.Windows.Forms.CheckBox();
		ckbLike = new System.Windows.Forms.CheckBox();
		C62E47A0 = new System.Windows.Forms.Panel();
		radioButton3 = new System.Windows.Forms.RadioButton();
		DFB45D36 = new System.Windows.Forms.RadioButton();
		label26 = new System.Windows.Forms.Label();
		CEA70537 = new System.Windows.Forms.Panel();
		BD12A818 = new System.Windows.Forms.Panel();
		E58E2D9F = new System.Windows.Forms.ComboBox();
		button3 = new System.Windows.Forms.Button();
		DABE5B33 = new System.Windows.Forms.Label();
		txtCommentEdit = new System.Windows.Forms.RichTextBox();
		E090F495 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		DC835B80 = new System.Windows.Forms.Label();
		nudDelayEditFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayEditTo = new System.Windows.Forms.NumericUpDown();
		ckbEditComment = new System.Windows.Forms.CheckBox();
		cbbTuyChonNoiDung = new System.Windows.Forms.ComboBox();
		F98C7DB6 = new System.Windows.Forms.Button();
		plTag = new System.Windows.Forms.Panel();
		A606D2B4 = new System.Windows.Forms.CheckBox();
		nudSoLuongTagTo = new System.Windows.Forms.NumericUpDown();
		label16 = new System.Windows.Forms.Label();
		C4B7AE2F = new System.Windows.Forms.NumericUpDown();
		label14 = new System.Windows.Forms.Label();
		E1373124 = new System.Windows.Forms.Label();
		ckbTag = new System.Windows.Forms.CheckBox();
		EC8CEAB0 = new System.Windows.Forms.CheckBox();
		A99FC29A = new System.Windows.Forms.Button();
		CE96E13B = new System.Windows.Forms.Button();
		AE05AF3F = new System.Windows.Forms.RichTextBox();
		lblComment = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		rbCommentTheoThuTu = new System.Windows.Forms.RadioButton();
		rbCommentNgauNhien = new System.Windows.Forms.RadioButton();
		CE934127 = new System.Windows.Forms.Label();
		plDeleteComment = new System.Windows.Forms.Panel();
		A78232B3 = new System.Windows.Forms.Label();
		label27 = new System.Windows.Forms.Label();
		nudDelayDeleteFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayDeleteTo = new System.Windows.Forms.NumericUpDown();
		ckbDeleteComment = new System.Windows.Forms.CheckBox();
		C4B808B6 = new System.Windows.Forms.CheckBox();
		C3A154AE = new System.Windows.Forms.CheckBox();
		ckbSendAnh = new System.Windows.Forms.CheckBox();
		panel2 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		txtIdPost = new System.Windows.Forms.RichTextBox();
		ckbTuDongXoa = new System.Windows.Forms.CheckBox();
		plAnh = new System.Windows.Forms.Panel();
		txtAnh = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		label49 = new System.Windows.Forms.Label();
		nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
		ED0E7190 = new System.Windows.Forms.NumericUpDown();
		label66 = new System.Windows.Forms.Label();
		DE29351B = new System.Windows.Forms.CheckBox();
		F6292C04 = new System.Windows.Forms.NumericUpDown();
		nudDelayTo = new System.Windows.Forms.NumericUpDown();
		nudTimeFrom = new System.Windows.Forms.NumericUpDown();
		nudDelayFrom = new System.Windows.Forms.NumericUpDown();
		txtTenHanhDong = new System.Windows.Forms.TextBox();
		A21CC930 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		D42558A3 = new System.Windows.Forms.Label();
		B504C090 = new System.Windows.Forms.Button();
		A1351F91 = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		ckbUuTienMbasic = new System.Windows.Forms.CheckBox();
		plContentShare = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDungShare = new System.Windows.Forms.ComboBox();
		button2 = new System.Windows.Forms.Button();
		label15 = new System.Windows.Forms.Label();
		F285EEB9 = new System.Windows.Forms.CheckBox();
		E7B4F219 = new System.Windows.Forms.Panel();
		radioButton1 = new System.Windows.Forms.RadioButton();
		A0ADDAA2 = new System.Windows.Forms.RadioButton();
		A336808B = new System.Windows.Forms.Label();
		txtContentShare = new System.Windows.Forms.RichTextBox();
		lblContentShare = new System.Windows.Forms.Label();
		BBB062AB = new System.Windows.Forms.Panel();
		cbbTuyChonNoiDungShareMess = new System.Windows.Forms.ComboBox();
		button4 = new System.Windows.Forms.Button();
		label23 = new System.Windows.Forms.Label();
		ckbAutoDeleteContentShareMess = new System.Windows.Forms.CheckBox();
		panel5 = new System.Windows.Forms.Panel();
		F5128598 = new System.Windows.Forms.RadioButton();
		AB26F3BE = new System.Windows.Forms.RadioButton();
		ADA1A48C = new System.Windows.Forms.Label();
		txtContentShareMess = new System.Windows.Forms.RichTextBox();
		lblContentShareMess = new System.Windows.Forms.Label();
		label22 = new System.Windows.Forms.Label();
		FCA215A9 = new System.Windows.Forms.Label();
		nudSoLuongMessFrom = new System.Windows.Forms.NumericUpDown();
		nudSoLuongMessTo = new System.Windows.Forms.NumericUpDown();
		label20 = new System.Windows.Forms.Label();
		label21 = new System.Windows.Forms.Label();
		A112F898 = new System.Windows.Forms.NumericUpDown();
		nudDelayMessFrom = new System.Windows.Forms.NumericUpDown();
		ckbShareWall = new System.Windows.Forms.CheckBox();
		ckbShareMess = new System.Windows.Forms.CheckBox();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel1.SuspendLayout();
		BD2EF88B.SuspendLayout();
		C62E47A0.SuspendLayout();
		CEA70537.SuspendLayout();
		BD12A818.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayEditFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayEditTo).BeginInit();
		plTag.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTagTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)C4B7AE2F).BeginInit();
		panel3.SuspendLayout();
		plDeleteComment.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayDeleteFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayDeleteTo).BeginInit();
		panel2.SuspendLayout();
		plAnh.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)ED0E7190).BeginInit();
		((System.ComponentModel.ISupportInitialize)F6292C04).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
		bunifuCards1.SuspendLayout();
		plContentShare.SuspendLayout();
		E7B4F219.SuspendLayout();
		BBB062AB.SuspendLayout();
		panel5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongMessFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongMessTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)A112F898).BeginInit();
		((System.ComponentModel.ISupportInitialize)nudDelayMessFrom).BeginInit();
		SuspendLayout();
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = CFA7D9B7;
		bunifuDragControl_0.Vertical = true;
		CFA7D9B7.BackColor = System.Drawing.Color.Transparent;
		CFA7D9B7.Cursor = System.Windows.Forms.Cursors.SizeAll;
		CFA7D9B7.Dock = System.Windows.Forms.DockStyle.Fill;
		CFA7D9B7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		CFA7D9B7.ForeColor = System.Drawing.Color.Black;
		CFA7D9B7.Location = new System.Drawing.Point(0, 0);
		CFA7D9B7.Name = "bunifuCustomLabel1";
		CFA7D9B7.Size = new System.Drawing.Size(1000, 31);
		CFA7D9B7.TabIndex = 12;
		CFA7D9B7.Text = "Cấu hình Tương ta\u0301c ba\u0300i viê\u0301t chi\u0309 đi\u0323nh";
		CFA7D9B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A9AED713.Fixed = true;
		A9AED713.Horizontal = true;
		A9AED713.TargetControl = pnlHeader;
		A9AED713.Vertical = true;
		pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		pnlHeader.BackColor = System.Drawing.Color.White;
		pnlHeader.Controls.Add(F5BC9C86);
		pnlHeader.Controls.Add(pictureBox1);
		pnlHeader.Controls.Add(CFA7D9B7);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(1000, 31);
		pnlHeader.TabIndex = 9;
		F5BC9C86.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F5BC9C86.Cursor = System.Windows.Forms.Cursors.Hand;
		F5BC9C86.FlatAppearance.BorderSize = 0;
		F5BC9C86.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		F5BC9C86.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		F5BC9C86.ForeColor = System.Drawing.Color.White;
		F5BC9C86.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		F5BC9C86.Location = new System.Drawing.Point(969, 1);
		F5BC9C86.Name = "button1";
		F5BC9C86.Size = new System.Drawing.Size(30, 30);
		F5BC9C86.TabIndex = 77;
		F5BC9C86.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		F5BC9C86.UseVisualStyleBackColor = true;
		F5BC9C86.Click += new System.EventHandler(A2210C3E);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(3, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 76;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(AD88FB86);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(ckbTaoNoiDungAI);
		panel1.Controls.Add(BD2EF88B);
		panel1.Controls.Add(CEA70537);
		panel1.Controls.Add(C4B808B6);
		panel1.Controls.Add(C3A154AE);
		panel1.Controls.Add(ckbSendAnh);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(plAnh);
		panel1.Controls.Add(label49);
		panel1.Controls.Add(nudSoLuongUidFrom);
		panel1.Controls.Add(ED0E7190);
		panel1.Controls.Add(label66);
		panel1.Controls.Add(DE29351B);
		panel1.Controls.Add(F6292C04);
		panel1.Controls.Add(nudDelayTo);
		panel1.Controls.Add(nudTimeFrom);
		panel1.Controls.Add(nudDelayFrom);
		panel1.Controls.Add(txtTenHanhDong);
		panel1.Controls.Add(A21CC930);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(D42558A3);
		panel1.Controls.Add(B504C090);
		panel1.Controls.Add(A1351F91);
		panel1.Controls.Add(bunifuCards1);
		panel1.Controls.Add(ckbUuTienMbasic);
		panel1.Controls.Add(plContentShare);
		panel1.Controls.Add(BBB062AB);
		panel1.Controls.Add(ckbShareWall);
		panel1.Controls.Add(ckbShareMess);
		panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
		panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1003, 490);
		panel1.TabIndex = 0;
		panel1.Click += new System.EventHandler(panel1_Click);
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		ckbTaoNoiDungAI.AutoSize = true;
		ckbTaoNoiDungAI.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTaoNoiDungAI.Location = new System.Drawing.Point(823, 77);
		ckbTaoNoiDungAI.Name = "ckbTaoNoiDungAI";
		ckbTaoNoiDungAI.Size = new System.Drawing.Size(149, 20);
		ckbTaoNoiDungAI.TabIndex = 187;
		ckbTaoNoiDungAI.Text = "Ta\u0323o nô\u0323i dung bă\u0300ng AI";
		ckbTaoNoiDungAI.UseVisualStyleBackColor = true;
		ckbTaoNoiDungAI.CheckedChanged += new System.EventHandler(ckbTaoNoiDungAI_CheckedChanged);
		ckbTaoNoiDungAI.Click += new System.EventHandler(CD21320D);
		BD2EF88B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		BD2EF88B.Controls.Add(ckbAngry);
		BD2EF88B.Controls.Add(ckbSad);
		BD2EF88B.Controls.Add(D61D0ABD);
		BD2EF88B.Controls.Add(B336C0B0);
		BD2EF88B.Controls.Add(ckbCare);
		BD2EF88B.Controls.Add(ckbLove);
		BD2EF88B.Controls.Add(ckbLike);
		BD2EF88B.Controls.Add(C62E47A0);
		BD2EF88B.Controls.Add(label26);
		BD2EF88B.Location = new System.Drawing.Point(317, 99);
		BD2EF88B.Name = "plInteract";
		BD2EF88B.Size = new System.Drawing.Size(312, 33);
		BD2EF88B.TabIndex = 182;
		ckbAngry.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAngry.Image = Class155.Bitmap_11;
		ckbAngry.Location = new System.Drawing.Point(266, 1);
		ckbAngry.Name = "ckbAngry";
		ckbAngry.Size = new System.Drawing.Size(40, 30);
		ckbAngry.TabIndex = 179;
		ckbAngry.Tag = "Angry";
		ckbAngry.UseVisualStyleBackColor = true;
		ckbSad.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSad.Image = Class155.E1938320;
		ckbSad.Location = new System.Drawing.Point(222, 1);
		ckbSad.Name = "ckbSad";
		ckbSad.Size = new System.Drawing.Size(40, 30);
		ckbSad.TabIndex = 178;
		ckbSad.Tag = "Sad";
		ckbSad.UseVisualStyleBackColor = true;
		D61D0ABD.Cursor = System.Windows.Forms.Cursors.Hand;
		D61D0ABD.Image = Class155.Bitmap_181;
		D61D0ABD.Location = new System.Drawing.Point(178, 1);
		D61D0ABD.Name = "ckbWow";
		D61D0ABD.Size = new System.Drawing.Size(40, 30);
		D61D0ABD.TabIndex = 177;
		D61D0ABD.Tag = "Wow";
		D61D0ABD.UseVisualStyleBackColor = true;
		B336C0B0.Cursor = System.Windows.Forms.Cursors.Hand;
		B336C0B0.Image = Class155.E982D419;
		B336C0B0.Location = new System.Drawing.Point(134, 1);
		B336C0B0.Name = "ckbHaha";
		B336C0B0.Size = new System.Drawing.Size(40, 30);
		B336C0B0.TabIndex = 176;
		B336C0B0.Tag = "Haha";
		B336C0B0.UseVisualStyleBackColor = true;
		ckbCare.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCare.Image = Class155.Bitmap_20;
		ckbCare.Location = new System.Drawing.Point(90, 1);
		ckbCare.Name = "ckbCare";
		ckbCare.Size = new System.Drawing.Size(40, 30);
		ckbCare.TabIndex = 175;
		ckbCare.Tag = "Care";
		ckbCare.UseVisualStyleBackColor = true;
		ckbLove.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLove.Image = Class155.AB95A212;
		ckbLove.Location = new System.Drawing.Point(46, 1);
		ckbLove.Name = "ckbLove";
		ckbLove.Size = new System.Drawing.Size(40, 30);
		ckbLove.TabIndex = 174;
		ckbLove.Tag = "Love";
		ckbLove.UseVisualStyleBackColor = true;
		ckbLike.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbLike.Image = Class155.Bitmap_166;
		ckbLike.Location = new System.Drawing.Point(2, 1);
		ckbLike.Name = "ckbLike";
		ckbLike.Size = new System.Drawing.Size(40, 30);
		ckbLike.TabIndex = 173;
		ckbLike.Tag = "Like";
		ckbLike.UseVisualStyleBackColor = true;
		C62E47A0.Controls.Add(radioButton3);
		C62E47A0.Controls.Add(DFB45D36);
		C62E47A0.Location = new System.Drawing.Point(67, 300);
		C62E47A0.Name = "panel7";
		C62E47A0.Size = new System.Drawing.Size(200, 43);
		C62E47A0.TabIndex = 43;
		radioButton3.AutoSize = true;
		radioButton3.Checked = true;
		radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton3.Location = new System.Drawing.Point(3, 2);
		radioButton3.Name = "radioButton3";
		radioButton3.Size = new System.Drawing.Size(201, 20);
		radioButton3.TabIndex = 3;
		radioButton3.TabStop = true;
		radioButton3.Text = "Comment theo thứ tự nội dung";
		radioButton3.UseVisualStyleBackColor = true;
		DFB45D36.AutoSize = true;
		DFB45D36.Cursor = System.Windows.Forms.Cursors.Hand;
		DFB45D36.Location = new System.Drawing.Point(3, 23);
		DFB45D36.Name = "radioButton4";
		DFB45D36.Size = new System.Drawing.Size(200, 20);
		DFB45D36.TabIndex = 3;
		DFB45D36.Text = "Comment ngẫu nhiên nội dung";
		DFB45D36.UseVisualStyleBackColor = true;
		label26.AutoSize = true;
		label26.Location = new System.Drawing.Point(4, 302);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(64, 16);
		label26.TabIndex = 2;
		label26.Text = "Tùy chọn:";
		CEA70537.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		CEA70537.Controls.Add(BD12A818);
		CEA70537.Controls.Add(ckbEditComment);
		CEA70537.Controls.Add(cbbTuyChonNoiDung);
		CEA70537.Controls.Add(F98C7DB6);
		CEA70537.Controls.Add(plTag);
		CEA70537.Controls.Add(E1373124);
		CEA70537.Controls.Add(ckbTag);
		CEA70537.Controls.Add(EC8CEAB0);
		CEA70537.Controls.Add(A99FC29A);
		CEA70537.Controls.Add(CE96E13B);
		CEA70537.Controls.Add(AE05AF3F);
		CEA70537.Controls.Add(lblComment);
		CEA70537.Controls.Add(panel3);
		CEA70537.Controls.Add(CE934127);
		CEA70537.Controls.Add(plDeleteComment);
		CEA70537.Controls.Add(ckbDeleteComment);
		CEA70537.Location = new System.Drawing.Point(661, 99);
		CEA70537.Name = "plCommentText";
		CEA70537.Size = new System.Drawing.Size(311, 276);
		CEA70537.TabIndex = 164;
		CEA70537.Paint += new System.Windows.Forms.PaintEventHandler(CEA70537_Paint);
		BD12A818.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		BD12A818.Controls.Add(E58E2D9F);
		BD12A818.Controls.Add(button3);
		BD12A818.Controls.Add(DABE5B33);
		BD12A818.Controls.Add(txtCommentEdit);
		BD12A818.Controls.Add(E090F495);
		BD12A818.Controls.Add(label6);
		BD12A818.Controls.Add(DC835B80);
		BD12A818.Controls.Add(nudDelayEditFrom);
		BD12A818.Controls.Add(nudDelayEditTo);
		BD12A818.Location = new System.Drawing.Point(6, 298);
		BD12A818.Name = "plEditComment";
		BD12A818.Size = new System.Drawing.Size(298, 218);
		BD12A818.TabIndex = 198;
		E58E2D9F.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		E58E2D9F.Cursor = System.Windows.Forms.Cursors.Hand;
		E58E2D9F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		E58E2D9F.FormattingEnabled = true;
		E58E2D9F.Location = new System.Drawing.Point(69, 186);
		E58E2D9F.Name = "cbbTuyChonNoiDungEdit";
		E58E2D9F.Size = new System.Drawing.Size(189, 24);
		E58E2D9F.TabIndex = 195;
		E58E2D9F.SelectedIndexChanged += new System.EventHandler(F69F6D26);
		button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button3.Location = new System.Drawing.Point(264, 185);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(26, 26);
		button3.TabIndex = 194;
		button3.Text = "?";
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(button3_Click);
		DABE5B33.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		DABE5B33.AutoSize = true;
		DABE5B33.Location = new System.Drawing.Point(3, 189);
		DABE5B33.Name = "label4";
		DABE5B33.Size = new System.Drawing.Size(64, 16);
		DABE5B33.TabIndex = 193;
		DABE5B33.Text = "Tùy chọn:";
		txtCommentEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtCommentEdit.Location = new System.Drawing.Point(7, 53);
		txtCommentEdit.Name = "txtCommentEdit";
		txtCommentEdit.Size = new System.Drawing.Size(283, 128);
		txtCommentEdit.TabIndex = 1;
		txtCommentEdit.Text = "";
		txtCommentEdit.WordWrap = false;
		txtCommentEdit.TextChanged += new System.EventHandler(txtCommentEdit_TextChanged);
		E090F495.AutoSize = true;
		E090F495.Location = new System.Drawing.Point(4, 32);
		E090F495.Name = "lblCommentEdit";
		E090F495.Size = new System.Drawing.Size(139, 16);
		E090F495.TabIndex = 0;
		E090F495.Text = "Nội dung bình luận (0):";
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(4, 6);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(92, 16);
		label6.TabIndex = 34;
		label6.Text = "Delay time (s):";
		DC835B80.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		DC835B80.Location = new System.Drawing.Point(170, 6);
		DC835B80.Name = "label10";
		DC835B80.Size = new System.Drawing.Size(29, 16);
		DC835B80.TabIndex = 38;
		DC835B80.Text = ">";
		DC835B80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudDelayEditFrom.Location = new System.Drawing.Point(102, 4);
		nudDelayEditFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayEditFrom.Name = "nudDelayEditFrom";
		nudDelayEditFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayEditFrom.TabIndex = 5;
		nudDelayEditTo.Location = new System.Drawing.Point(209, 4);
		nudDelayEditTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayEditTo.Name = "nudDelayEditTo";
		nudDelayEditTo.Size = new System.Drawing.Size(56, 23);
		nudDelayEditTo.TabIndex = 6;
		ckbEditComment.AutoSize = true;
		ckbEditComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbEditComment.Location = new System.Drawing.Point(6, 276);
		ckbEditComment.Name = "ckbEditComment";
		ckbEditComment.Size = new System.Drawing.Size(159, 20);
		ckbEditComment.TabIndex = 197;
		ckbEditComment.Text = "Sửa nội dung comment";
		ckbEditComment.UseVisualStyleBackColor = true;
		ckbEditComment.CheckedChanged += new System.EventHandler(FFA34D2A);
		cbbTuyChonNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDung.FormattingEnabled = true;
		cbbTuyChonNoiDung.Location = new System.Drawing.Point(69, 223);
		cbbTuyChonNoiDung.Name = "cbbTuyChonNoiDung";
		cbbTuyChonNoiDung.Size = new System.Drawing.Size(202, 24);
		cbbTuyChonNoiDung.TabIndex = 180;
		cbbTuyChonNoiDung.SelectedIndexChanged += new System.EventHandler(B424B493);
		F98C7DB6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		F98C7DB6.Cursor = System.Windows.Forms.Cursors.Hand;
		F98C7DB6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F98C7DB6.Location = new System.Drawing.Point(277, 222);
		F98C7DB6.Name = "btnHuongDanNhapNoiDung";
		F98C7DB6.Size = new System.Drawing.Size(26, 26);
		F98C7DB6.TabIndex = 179;
		F98C7DB6.Text = "?";
		F98C7DB6.UseVisualStyleBackColor = true;
		F98C7DB6.Click += new System.EventHandler(AE0861B4);
		plTag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		plTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plTag.Controls.Add(A606D2B4);
		plTag.Controls.Add(nudSoLuongTagTo);
		plTag.Controls.Add(label16);
		plTag.Controls.Add(C4B7AE2F);
		plTag.Controls.Add(label14);
		plTag.Location = new System.Drawing.Point(25, 298);
		plTag.Name = "plTag";
		plTag.Size = new System.Drawing.Size(275, 54);
		plTag.TabIndex = 167;
		A606D2B4.AutoSize = true;
		A606D2B4.Cursor = System.Windows.Forms.Cursors.Hand;
		A606D2B4.Location = new System.Drawing.Point(6, 31);
		A606D2B4.Name = "ckbChiTagTenViet";
		A606D2B4.Size = new System.Drawing.Size(112, 20);
		A606D2B4.TabIndex = 168;
		A606D2B4.Text = "Chỉ tag tên việt";
		A606D2B4.UseVisualStyleBackColor = true;
		nudSoLuongTagTo.Location = new System.Drawing.Point(156, 4);
		nudSoLuongTagTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudSoLuongTagTo.Name = "nudSoLuongTagTo";
		nudSoLuongTagTo.Size = new System.Drawing.Size(51, 23);
		nudSoLuongTagTo.TabIndex = 174;
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(3, 6);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(63, 16);
		label16.TabIndex = 175;
		label16.Text = "Số lượng:";
		C4B7AE2F.Location = new System.Drawing.Point(70, 4);
		C4B7AE2F.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		C4B7AE2F.Name = "nudSoLuongTagFrom";
		C4B7AE2F.Size = new System.Drawing.Size(51, 23);
		C4B7AE2F.TabIndex = 173;
		label14.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label14.Location = new System.Drawing.Point(125, 6);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(29, 16);
		label14.TabIndex = 177;
		label14.Text = ">";
		label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		E1373124.AutoSize = true;
		E1373124.Location = new System.Drawing.Point(3, 226);
		E1373124.Name = "label8";
		E1373124.Size = new System.Drawing.Size(64, 16);
		E1373124.TabIndex = 178;
		E1373124.Text = "Tùy chọn:";
		ckbTag.AutoSize = true;
		ckbTag.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTag.Location = new System.Drawing.Point(6, 276);
		ckbTag.Name = "ckbTag";
		ckbTag.Size = new System.Drawing.Size(91, 20);
		ckbTag.TabIndex = 166;
		ckbTag.Text = "Tag bạn bè";
		ckbTag.UseVisualStyleBackColor = true;
		ckbTag.CheckedChanged += new System.EventHandler(A530658B);
		EC8CEAB0.AutoSize = true;
		EC8CEAB0.Cursor = System.Windows.Forms.Cursors.Hand;
		EC8CEAB0.Location = new System.Drawing.Point(6, 250);
		EC8CEAB0.Name = "ckbAutoDeleteComment";
		EC8CEAB0.Size = new System.Drawing.Size(169, 20);
		EC8CEAB0.TabIndex = 176;
		EC8CEAB0.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		EC8CEAB0.UseVisualStyleBackColor = true;
		A99FC29A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		A99FC29A.BackgroundImage = Class155.Bitmap_94;
		A99FC29A.Cursor = System.Windows.Forms.Cursors.Hand;
		A99FC29A.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		A99FC29A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A99FC29A.Location = new System.Drawing.Point(254, -1);
		A99FC29A.Name = "btnDown";
		A99FC29A.Size = new System.Drawing.Size(25, 25);
		A99FC29A.TabIndex = 40;
		A99FC29A.Click += new System.EventHandler(A99FC29A_Click);
		CE96E13B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		CE96E13B.BackgroundImage = Class155.B116C210;
		CE96E13B.Cursor = System.Windows.Forms.Cursors.Hand;
		CE96E13B.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		CE96E13B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		CE96E13B.Location = new System.Drawing.Point(285, -1);
		CE96E13B.Name = "btnUp";
		CE96E13B.Size = new System.Drawing.Size(25, 25);
		CE96E13B.TabIndex = 41;
		CE96E13B.Click += new System.EventHandler(CE96E13B_Click);
		AE05AF3F.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		AE05AF3F.Location = new System.Drawing.Point(6, 25);
		AE05AF3F.Name = "txtComment";
		AE05AF3F.Size = new System.Drawing.Size(297, 191);
		AE05AF3F.TabIndex = 1;
		AE05AF3F.Text = "";
		AE05AF3F.WordWrap = false;
		AE05AF3F.TextChanged += new System.EventHandler(AE05AF3F_TextChanged);
		lblComment.AutoSize = true;
		lblComment.Location = new System.Drawing.Point(2, 5);
		lblComment.Name = "lblComment";
		lblComment.Size = new System.Drawing.Size(139, 16);
		lblComment.TabIndex = 0;
		lblComment.Text = "Nội dung bình luận (0):";
		panel3.Controls.Add(rbCommentTheoThuTu);
		panel3.Controls.Add(rbCommentNgauNhien);
		panel3.Location = new System.Drawing.Point(75, 108);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(200, 43);
		panel3.TabIndex = 43;
		rbCommentTheoThuTu.AutoSize = true;
		rbCommentTheoThuTu.Checked = true;
		rbCommentTheoThuTu.Cursor = System.Windows.Forms.Cursors.Hand;
		rbCommentTheoThuTu.Location = new System.Drawing.Point(3, 2);
		rbCommentTheoThuTu.Name = "rbCommentTheoThuTu";
		rbCommentTheoThuTu.Size = new System.Drawing.Size(201, 20);
		rbCommentTheoThuTu.TabIndex = 3;
		rbCommentTheoThuTu.TabStop = true;
		rbCommentTheoThuTu.Text = "Comment theo thứ tự nội dung";
		rbCommentTheoThuTu.UseVisualStyleBackColor = true;
		rbCommentTheoThuTu.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
		rbCommentNgauNhien.AutoSize = true;
		rbCommentNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
		rbCommentNgauNhien.Location = new System.Drawing.Point(3, 23);
		rbCommentNgauNhien.Name = "rbCommentNgauNhien";
		rbCommentNgauNhien.Size = new System.Drawing.Size(200, 20);
		rbCommentNgauNhien.TabIndex = 3;
		rbCommentNgauNhien.Text = "Comment ngẫu nhiên nội dung";
		rbCommentNgauNhien.UseVisualStyleBackColor = true;
		rbCommentNgauNhien.CheckedChanged += new System.EventHandler(A0ADDAA2_CheckedChanged);
		CE934127.AutoSize = true;
		CE934127.Location = new System.Drawing.Point(12, 110);
		CE934127.Name = "label13";
		CE934127.Size = new System.Drawing.Size(64, 16);
		CE934127.TabIndex = 2;
		CE934127.Text = "Tùy chọn:";
		CE934127.Click += new System.EventHandler(A336808B_Click);
		plDeleteComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plDeleteComment.Controls.Add(A78232B3);
		plDeleteComment.Controls.Add(label27);
		plDeleteComment.Controls.Add(nudDelayDeleteFrom);
		plDeleteComment.Controls.Add(nudDelayDeleteTo);
		plDeleteComment.Location = new System.Drawing.Point(10, 49);
		plDeleteComment.Name = "plDeleteComment";
		plDeleteComment.Size = new System.Drawing.Size(287, 32);
		plDeleteComment.TabIndex = 200;
		A78232B3.AutoSize = true;
		A78232B3.Location = new System.Drawing.Point(4, 6);
		A78232B3.Name = "label25";
		A78232B3.Size = new System.Drawing.Size(92, 16);
		A78232B3.TabIndex = 34;
		A78232B3.Text = "Delay time (s):";
		label27.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label27.Location = new System.Drawing.Point(170, 6);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(29, 16);
		label27.TabIndex = 38;
		label27.Text = ">";
		label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		nudDelayDeleteFrom.Location = new System.Drawing.Point(102, 4);
		nudDelayDeleteFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayDeleteFrom.Name = "nudDelayDeleteFrom";
		nudDelayDeleteFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayDeleteFrom.TabIndex = 5;
		nudDelayDeleteTo.Location = new System.Drawing.Point(209, 4);
		nudDelayDeleteTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudDelayDeleteTo.Name = "nudDelayDeleteTo";
		nudDelayDeleteTo.Size = new System.Drawing.Size(56, 23);
		nudDelayDeleteTo.TabIndex = 6;
		ckbDeleteComment.AutoSize = true;
		ckbDeleteComment.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbDeleteComment.Location = new System.Drawing.Point(10, 27);
		ckbDeleteComment.Name = "ckbDeleteComment";
		ckbDeleteComment.Size = new System.Drawing.Size(105, 20);
		ckbDeleteComment.TabIndex = 199;
		ckbDeleteComment.Text = "Xo\u0301a comment";
		ckbDeleteComment.UseVisualStyleBackColor = true;
		ckbDeleteComment.CheckedChanged += new System.EventHandler(ckbDeleteComment_CheckedChanged);
		C4B808B6.AutoSize = true;
		C4B808B6.Cursor = System.Windows.Forms.Cursors.Hand;
		C4B808B6.Location = new System.Drawing.Point(317, 77);
		C4B808B6.Name = "ckbInteract";
		C4B808B6.Size = new System.Drawing.Size(99, 20);
		C4B808B6.TabIndex = 181;
		C4B808B6.Text = "Thả cảm xúc";
		C4B808B6.UseVisualStyleBackColor = true;
		C4B808B6.CheckedChanged += new System.EventHandler(C4B808B6_CheckedChanged);
		C3A154AE.AutoSize = true;
		C3A154AE.Cursor = System.Windows.Forms.Cursors.Hand;
		C3A154AE.Location = new System.Drawing.Point(565, 136);
		C3A154AE.Name = "ckbRunAPI";
		C3A154AE.Size = new System.Drawing.Size(99, 20);
		C3A154AE.TabIndex = 176;
		C3A154AE.Text = "Run API (ẩn)";
		C3A154AE.UseVisualStyleBackColor = true;
		C3A154AE.CheckedChanged += new System.EventHandler(A882C3A9);
		ckbSendAnh.AutoSize = true;
		ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbSendAnh.Location = new System.Drawing.Point(661, 381);
		ckbSendAnh.Name = "ckbSendAnh";
		ckbSendAnh.Size = new System.Drawing.Size(103, 20);
		ckbSendAnh.TabIndex = 165;
		ckbSendAnh.Text = "Bi\u0300nh luâ\u0323n a\u0309nh";
		ckbSendAnh.UseVisualStyleBackColor = true;
		ckbSendAnh.CheckedChanged += new System.EventHandler(D8A4A281);
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txtIdPost);
		panel2.Controls.Add(ckbTuDongXoa);
		panel2.Location = new System.Drawing.Point(30, 135);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(252, 299);
		panel2.TabIndex = 181;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(3, 4);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(176, 16);
		label2.TabIndex = 40;
		label2.Text = "Nhâ\u0323p Id hoă\u0323c link ba\u0300i viê\u0301t (0):";
		txtIdPost.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIdPost.Location = new System.Drawing.Point(6, 24);
		txtIdPost.Name = "txtIdPost";
		txtIdPost.Size = new System.Drawing.Size(238, 246);
		txtIdPost.TabIndex = 1;
		txtIdPost.Text = "";
		txtIdPost.WordWrap = false;
		txtIdPost.TextChanged += new System.EventHandler(A98F36A1);
		ckbTuDongXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		ckbTuDongXoa.AutoSize = true;
		ckbTuDongXoa.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbTuDongXoa.Location = new System.Drawing.Point(6, 273);
		ckbTuDongXoa.Name = "ckbTuDongXoa";
		ckbTuDongXoa.Size = new System.Drawing.Size(192, 20);
		ckbTuDongXoa.TabIndex = 176;
		ckbTuDongXoa.Text = "Xóa link ba\u0300i viê\u0301t đã tương tác";
		ckbTuDongXoa.UseVisualStyleBackColor = true;
		plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plAnh.Controls.Add(txtAnh);
		plAnh.Controls.Add(label12);
		plAnh.Enabled = false;
		plAnh.Location = new System.Drawing.Point(661, 403);
		plAnh.Name = "plAnh";
		plAnh.Size = new System.Drawing.Size(311, 31);
		plAnh.TabIndex = 166;
		txtAnh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtAnh.Location = new System.Drawing.Point(86, 3);
		txtAnh.Name = "txtAnh";
		txtAnh.Size = new System.Drawing.Size(220, 23);
		txtAnh.TabIndex = 155;
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(3, 6);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(73, 16);
		label12.TabIndex = 39;
		label12.Text = "Folder ảnh:";
		label12.Click += new System.EventHandler(label12_Click);
		label49.AutoSize = true;
		label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label49.Location = new System.Drawing.Point(27, 79);
		label49.Name = "label49";
		label49.Size = new System.Drawing.Size(84, 16);
		label49.TabIndex = 169;
		label49.Text = "Sô\u0301 lươ\u0323ng ba\u0300i:";
		nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongUidFrom.Location = new System.Drawing.Point(129, 77);
		nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
		nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongUidFrom.TabIndex = 167;
		nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		ED0E7190.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		ED0E7190.Location = new System.Drawing.Point(226, 77);
		ED0E7190.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		ED0E7190.Name = "nudSoLuongUidTo";
		ED0E7190.Size = new System.Drawing.Size(56, 23);
		ED0E7190.TabIndex = 168;
		ED0E7190.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label66.Location = new System.Drawing.Point(191, 79);
		label66.Name = "label66";
		label66.Size = new System.Drawing.Size(29, 16);
		label66.TabIndex = 171;
		label66.Text = ">";
		label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DE29351B.AutoSize = true;
		DE29351B.Cursor = System.Windows.Forms.Cursors.Hand;
		DE29351B.Location = new System.Drawing.Point(661, 77);
		DE29351B.Name = "ckbComment";
		DE29351B.Size = new System.Drawing.Size(127, 20);
		DE29351B.TabIndex = 163;
		DE29351B.Text = "Bi\u0300nh luâ\u0323n văn bản";
		DE29351B.UseVisualStyleBackColor = true;
		DE29351B.CheckedChanged += new System.EventHandler(DE29351B_CheckedChanged);
		F6292C04.Location = new System.Drawing.Point(498, 50);
		F6292C04.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		F6292C04.Name = "nudTimeTo";
		F6292C04.Size = new System.Drawing.Size(51, 23);
		F6292C04.TabIndex = 4;
		nudDelayTo.Location = new System.Drawing.Point(226, 106);
		nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayTo.Name = "nudDelayTo";
		nudDelayTo.Size = new System.Drawing.Size(56, 23);
		nudDelayTo.TabIndex = 4;
		nudTimeFrom.Location = new System.Drawing.Point(420, 50);
		nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudTimeFrom.Name = "nudTimeFrom";
		nudTimeFrom.Size = new System.Drawing.Size(51, 23);
		nudTimeFrom.TabIndex = 3;
		nudDelayFrom.Location = new System.Drawing.Point(129, 106);
		nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayFrom.Name = "nudDelayFrom";
		nudDelayFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayFrom.TabIndex = 3;
		txtTenHanhDong.Location = new System.Drawing.Point(129, 49);
		txtTenHanhDong.Name = "txtTenHanhDong";
		txtTenHanhDong.Size = new System.Drawing.Size(153, 23);
		txtTenHanhDong.TabIndex = 0;
		A21CC930.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A21CC930.Location = new System.Drawing.Point(471, 52);
		A21CC930.Name = "label9";
		A21CC930.Size = new System.Drawing.Size(29, 16);
		A21CC930.TabIndex = 38;
		A21CC930.Text = ">";
		A21CC930.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(191, 108);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(29, 16);
		label7.TabIndex = 38;
		label7.Text = ">";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(314, 52);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(103, 16);
		label3.TabIndex = 34;
		label3.Text = "Xem bài viết (s):";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(27, 108);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(87, 16);
		label5.TabIndex = 34;
		label5.Text = "Gia\u0303n ca\u0301ch (s):";
		D42558A3.AutoSize = true;
		D42558A3.Location = new System.Drawing.Point(27, 52);
		D42558A3.Name = "label1";
		D42558A3.Size = new System.Drawing.Size(98, 16);
		D42558A3.TabIndex = 31;
		D42558A3.Text = "Tên ha\u0300nh đô\u0323ng:";
		B504C090.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		B504C090.BackColor = System.Drawing.Color.Maroon;
		B504C090.Cursor = System.Windows.Forms.Cursors.Hand;
		B504C090.FlatAppearance.BorderSize = 0;
		B504C090.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		B504C090.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		B504C090.ForeColor = System.Drawing.Color.White;
		B504C090.Location = new System.Drawing.Point(508, 448);
		B504C090.Name = "btnCancel";
		B504C090.Size = new System.Drawing.Size(92, 29);
		B504C090.TabIndex = 10;
		B504C090.Text = "Đóng";
		B504C090.UseVisualStyleBackColor = false;
		B504C090.Click += new System.EventHandler(D5BF1C91);
		A1351F91.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		A1351F91.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		A1351F91.Cursor = System.Windows.Forms.Cursors.Hand;
		A1351F91.FlatAppearance.BorderSize = 0;
		A1351F91.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		A1351F91.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A1351F91.ForeColor = System.Drawing.Color.White;
		A1351F91.Location = new System.Drawing.Point(401, 448);
		A1351F91.Name = "btnAdd";
		A1351F91.Size = new System.Drawing.Size(92, 29);
		A1351F91.TabIndex = 9;
		A1351F91.Text = "Thêm";
		A1351F91.UseVisualStyleBackColor = false;
		A1351F91.Click += new System.EventHandler(A1351F91_Click);
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
		bunifuCards1.Size = new System.Drawing.Size(1000, 37);
		bunifuCards1.TabIndex = 28;
		ckbUuTienMbasic.AutoSize = true;
		ckbUuTienMbasic.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbUuTienMbasic.Location = new System.Drawing.Point(30, 414);
		ckbUuTienMbasic.Name = "ckbUuTienMbasic";
		ckbUuTienMbasic.Size = new System.Drawing.Size(173, 20);
		ckbUuTienMbasic.TabIndex = 176;
		ckbUuTienMbasic.Text = "Ưu tiên chạy bằng mbasic";
		ckbUuTienMbasic.UseVisualStyleBackColor = true;
		plContentShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plContentShare.Controls.Add(cbbTuyChonNoiDungShare);
		plContentShare.Controls.Add(button2);
		plContentShare.Controls.Add(label15);
		plContentShare.Controls.Add(F285EEB9);
		plContentShare.Controls.Add(E7B4F219);
		plContentShare.Controls.Add(A336808B);
		plContentShare.Controls.Add(txtContentShare);
		plContentShare.Controls.Add(lblContentShare);
		plContentShare.Location = new System.Drawing.Point(317, 159);
		plContentShare.Name = "plContentShare";
		plContentShare.Size = new System.Drawing.Size(312, 275);
		plContentShare.TabIndex = 164;
		cbbTuyChonNoiDungShare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDungShare.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDungShare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDungShare.FormattingEnabled = true;
		cbbTuyChonNoiDungShare.Location = new System.Drawing.Point(69, 225);
		cbbTuyChonNoiDungShare.Name = "cbbTuyChonNoiDungShare";
		cbbTuyChonNoiDungShare.Size = new System.Drawing.Size(203, 24);
		cbbTuyChonNoiDungShare.TabIndex = 180;
		cbbTuyChonNoiDungShare.SelectedIndexChanged += new System.EventHandler(cbbTuyChonNoiDungShare_SelectedIndexChanged);
		button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button2.Location = new System.Drawing.Point(278, 224);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(26, 26);
		button2.TabIndex = 179;
		button2.Text = "?";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(3, 228);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(64, 16);
		label15.TabIndex = 178;
		label15.Text = "Tùy chọn:";
		F285EEB9.AutoSize = true;
		F285EEB9.Cursor = System.Windows.Forms.Cursors.Hand;
		F285EEB9.Location = new System.Drawing.Point(6, 252);
		F285EEB9.Name = "ckbAutoDeleteContentShare";
		F285EEB9.Size = new System.Drawing.Size(169, 20);
		F285EEB9.TabIndex = 176;
		F285EEB9.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		F285EEB9.UseVisualStyleBackColor = true;
		E7B4F219.Controls.Add(radioButton1);
		E7B4F219.Controls.Add(A0ADDAA2);
		E7B4F219.Location = new System.Drawing.Point(67, 383);
		E7B4F219.Name = "panel6";
		E7B4F219.Size = new System.Drawing.Size(200, 43);
		E7B4F219.TabIndex = 43;
		radioButton1.AutoSize = true;
		radioButton1.Checked = true;
		radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		radioButton1.Location = new System.Drawing.Point(3, 2);
		radioButton1.Name = "radioButton1";
		radioButton1.Size = new System.Drawing.Size(201, 20);
		radioButton1.TabIndex = 3;
		radioButton1.TabStop = true;
		radioButton1.Text = "Comment theo thứ tự nội dung";
		radioButton1.UseVisualStyleBackColor = true;
		radioButton1.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
		A0ADDAA2.AutoSize = true;
		A0ADDAA2.Cursor = System.Windows.Forms.Cursors.Hand;
		A0ADDAA2.Location = new System.Drawing.Point(3, 23);
		A0ADDAA2.Name = "radioButton2";
		A0ADDAA2.Size = new System.Drawing.Size(200, 20);
		A0ADDAA2.TabIndex = 3;
		A0ADDAA2.Text = "Comment ngẫu nhiên nội dung";
		A0ADDAA2.UseVisualStyleBackColor = true;
		A0ADDAA2.CheckedChanged += new System.EventHandler(A0ADDAA2_CheckedChanged);
		A336808B.AutoSize = true;
		A336808B.Location = new System.Drawing.Point(4, 385);
		A336808B.Name = "label17";
		A336808B.Size = new System.Drawing.Size(64, 16);
		A336808B.TabIndex = 2;
		A336808B.Text = "Tùy chọn:";
		A336808B.Click += new System.EventHandler(A336808B_Click);
		txtContentShare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtContentShare.Location = new System.Drawing.Point(6, 25);
		txtContentShare.Name = "txtContentShare";
		txtContentShare.Size = new System.Drawing.Size(298, 194);
		txtContentShare.TabIndex = 1;
		txtContentShare.Text = "";
		txtContentShare.WordWrap = false;
		txtContentShare.TextChanged += new System.EventHandler(C3BC5A2D);
		lblContentShare.AutoSize = true;
		lblContentShare.Location = new System.Drawing.Point(2, 5);
		lblContentShare.Name = "lblContentShare";
		lblContentShare.Size = new System.Drawing.Size(119, 16);
		lblContentShare.TabIndex = 0;
		lblContentShare.Text = "Nội dung share (0):";
		BBB062AB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		BBB062AB.Controls.Add(cbbTuyChonNoiDungShareMess);
		BBB062AB.Controls.Add(button4);
		BBB062AB.Controls.Add(label23);
		BBB062AB.Controls.Add(ckbAutoDeleteContentShareMess);
		BBB062AB.Controls.Add(panel5);
		BBB062AB.Controls.Add(ADA1A48C);
		BBB062AB.Controls.Add(txtContentShareMess);
		BBB062AB.Controls.Add(lblContentShareMess);
		BBB062AB.Controls.Add(label22);
		BBB062AB.Controls.Add(FCA215A9);
		BBB062AB.Controls.Add(nudSoLuongMessFrom);
		BBB062AB.Controls.Add(nudSoLuongMessTo);
		BBB062AB.Controls.Add(label20);
		BBB062AB.Controls.Add(label21);
		BBB062AB.Controls.Add(A112F898);
		BBB062AB.Controls.Add(nudDelayMessFrom);
		BBB062AB.Location = new System.Drawing.Point(317, 159);
		BBB062AB.Name = "plShareMess";
		BBB062AB.Size = new System.Drawing.Size(312, 275);
		BBB062AB.TabIndex = 182;
		cbbTuyChonNoiDungShareMess.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		cbbTuyChonNoiDungShareMess.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbTuyChonNoiDungShareMess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbTuyChonNoiDungShareMess.FormattingEnabled = true;
		cbbTuyChonNoiDungShareMess.Location = new System.Drawing.Point(72, 221);
		cbbTuyChonNoiDungShareMess.Name = "cbbTuyChonNoiDungShareMess";
		cbbTuyChonNoiDungShareMess.Size = new System.Drawing.Size(202, 24);
		cbbTuyChonNoiDungShareMess.TabIndex = 184;
		cbbTuyChonNoiDungShareMess.SelectedIndexChanged += new System.EventHandler(ABBBEC31);
		button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button4.Location = new System.Drawing.Point(280, 220);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(26, 26);
		button4.TabIndex = 183;
		button4.Text = "?";
		button4.UseVisualStyleBackColor = true;
		button4.Click += new System.EventHandler(button4_Click);
		label23.AutoSize = true;
		label23.Location = new System.Drawing.Point(6, 224);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(64, 16);
		label23.TabIndex = 182;
		label23.Text = "Tùy chọn:";
		ckbAutoDeleteContentShareMess.AutoSize = true;
		ckbAutoDeleteContentShareMess.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbAutoDeleteContentShareMess.Location = new System.Drawing.Point(9, 249);
		ckbAutoDeleteContentShareMess.Name = "ckbAutoDeleteContentShareMess";
		ckbAutoDeleteContentShareMess.Size = new System.Drawing.Size(169, 20);
		ckbAutoDeleteContentShareMess.TabIndex = 181;
		ckbAutoDeleteContentShareMess.Text = "Xóa nội dung đã sư\u0309 du\u0323ng";
		ckbAutoDeleteContentShareMess.UseVisualStyleBackColor = true;
		panel5.Controls.Add(F5128598);
		panel5.Controls.Add(AB26F3BE);
		panel5.Location = new System.Drawing.Point(67, 383);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(200, 43);
		panel5.TabIndex = 43;
		F5128598.AutoSize = true;
		F5128598.Checked = true;
		F5128598.Cursor = System.Windows.Forms.Cursors.Hand;
		F5128598.Location = new System.Drawing.Point(3, 2);
		F5128598.Name = "radioButton5";
		F5128598.Size = new System.Drawing.Size(201, 20);
		F5128598.TabIndex = 3;
		F5128598.TabStop = true;
		F5128598.Text = "Comment theo thứ tự nội dung";
		F5128598.UseVisualStyleBackColor = true;
		AB26F3BE.AutoSize = true;
		AB26F3BE.Cursor = System.Windows.Forms.Cursors.Hand;
		AB26F3BE.Location = new System.Drawing.Point(3, 23);
		AB26F3BE.Name = "radioButton6";
		AB26F3BE.Size = new System.Drawing.Size(200, 20);
		AB26F3BE.TabIndex = 3;
		AB26F3BE.Text = "Comment ngẫu nhiên nội dung";
		AB26F3BE.UseVisualStyleBackColor = true;
		ADA1A48C.AutoSize = true;
		ADA1A48C.Location = new System.Drawing.Point(4, 385);
		ADA1A48C.Name = "label18";
		ADA1A48C.Size = new System.Drawing.Size(64, 16);
		ADA1A48C.TabIndex = 2;
		ADA1A48C.Text = "Tùy chọn:";
		txtContentShareMess.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtContentShareMess.Location = new System.Drawing.Point(8, 82);
		txtContentShareMess.Name = "txtContentShareMess";
		txtContentShareMess.Size = new System.Drawing.Size(298, 134);
		txtContentShareMess.TabIndex = 1;
		txtContentShareMess.Text = "";
		txtContentShareMess.WordWrap = false;
		txtContentShareMess.TextChanged += new System.EventHandler(txtContentShareMess_TextChanged);
		lblContentShareMess.AutoSize = true;
		lblContentShareMess.Location = new System.Drawing.Point(6, 62);
		lblContentShareMess.Name = "lblContentShareMess";
		lblContentShareMess.Size = new System.Drawing.Size(119, 16);
		lblContentShareMess.TabIndex = 0;
		lblContentShareMess.Text = "Nội dung share (0):";
		label22.AutoSize = true;
		label22.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		label22.Location = new System.Drawing.Point(6, 7);
		label22.Name = "label22";
		label22.Size = new System.Drawing.Size(63, 16);
		label22.TabIndex = 169;
		label22.Text = "Sô\u0301 lươ\u0323ng:";
		FCA215A9.AutoSize = true;
		FCA215A9.Location = new System.Drawing.Point(6, 36);
		FCA215A9.Name = "label11";
		FCA215A9.Size = new System.Drawing.Size(87, 16);
		FCA215A9.TabIndex = 34;
		FCA215A9.Text = "Gia\u0303n ca\u0301ch (s):";
		nudSoLuongMessFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongMessFrom.Location = new System.Drawing.Point(108, 5);
		nudSoLuongMessFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongMessFrom.Name = "nudSoLuongMessFrom";
		nudSoLuongMessFrom.Size = new System.Drawing.Size(56, 23);
		nudSoLuongMessFrom.TabIndex = 167;
		nudSoLuongMessFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
		nudSoLuongMessTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
		nudSoLuongMessTo.Location = new System.Drawing.Point(205, 5);
		nudSoLuongMessTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nudSoLuongMessTo.Name = "nudSoLuongMessTo";
		nudSoLuongMessTo.Size = new System.Drawing.Size(56, 23);
		nudSoLuongMessTo.TabIndex = 168;
		nudSoLuongMessTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		label20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(170, 36);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(29, 16);
		label20.TabIndex = 38;
		label20.Text = ">";
		label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
		label21.Location = new System.Drawing.Point(170, 7);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(29, 16);
		label21.TabIndex = 171;
		label21.Text = ">";
		label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		A112F898.Location = new System.Drawing.Point(205, 34);
		A112F898.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		A112F898.Name = "nudDelayMessTo";
		A112F898.Size = new System.Drawing.Size(56, 23);
		A112F898.TabIndex = 4;
		nudDelayMessFrom.Location = new System.Drawing.Point(108, 34);
		nudDelayMessFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		nudDelayMessFrom.Name = "nudDelayMessFrom";
		nudDelayMessFrom.Size = new System.Drawing.Size(56, 23);
		nudDelayMessFrom.TabIndex = 3;
		ckbShareWall.AutoSize = true;
		ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShareWall.Location = new System.Drawing.Point(317, 137);
		ckbShareWall.Name = "ckbShareWall";
		ckbShareWall.Size = new System.Drawing.Size(87, 20);
		ckbShareWall.TabIndex = 6;
		ckbShareWall.Text = "Share wall";
		ckbShareWall.UseVisualStyleBackColor = true;
		ckbShareWall.CheckedChanged += new System.EventHandler(F80B739A);
		ckbShareMess.AutoSize = true;
		ckbShareMess.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbShareMess.Location = new System.Drawing.Point(317, 137);
		ckbShareMess.Name = "ckbShareMess";
		ckbShareMess.Size = new System.Drawing.Size(94, 20);
		ckbShareMess.TabIndex = 181;
		ckbShareMess.Text = "Share mess";
		ckbShareMess.UseVisualStyleBackColor = true;
		ckbShareMess.CheckedChanged += new System.EventHandler(E5BFBD93);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1003, 490);
		base.Controls.Add(panel1);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDBuffLikeComment";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(fHDBuffLikeComment_Load);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		BD2EF88B.ResumeLayout(false);
		BD2EF88B.PerformLayout();
		C62E47A0.ResumeLayout(false);
		C62E47A0.PerformLayout();
		CEA70537.ResumeLayout(false);
		CEA70537.PerformLayout();
		BD12A818.ResumeLayout(false);
		BD12A818.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayEditFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayEditTo).EndInit();
		plTag.ResumeLayout(false);
		plTag.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongTagTo).EndInit();
		((System.ComponentModel.ISupportInitialize)C4B7AE2F).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		plDeleteComment.ResumeLayout(false);
		plDeleteComment.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudDelayDeleteFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayDeleteTo).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		plAnh.ResumeLayout(false);
		plAnh.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)ED0E7190).EndInit();
		((System.ComponentModel.ISupportInitialize)F6292C04).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
		((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
		bunifuCards1.ResumeLayout(false);
		plContentShare.ResumeLayout(false);
		plContentShare.PerformLayout();
		E7B4F219.ResumeLayout(false);
		E7B4F219.PerformLayout();
		BBB062AB.ResumeLayout(false);
		BBB062AB.PerformLayout();
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nudSoLuongMessFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)nudSoLuongMessTo).EndInit();
		((System.ComponentModel.ISupportInitialize)A112F898).EndInit();
		((System.ComponentModel.ISupportInitialize)nudDelayMessFrom).EndInit();
		ResumeLayout(false);
	}
}
