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

public class fHDCapNhatThongTin : Form
{
	[Serializable]
	[CompilerGenerated]
	private sealed class AF96C287
	{
		internal static readonly AF96C287 _003C_003E9 = new AF96C287();

		internal static Func<string, string> _003C_003E9__27_0;

		internal static Func<string, string> _003C_003E9__27_1;

		internal string method_0(string string_0)
		{
			return string_0.Split('|')[0];
		}

		internal string CEB2E8B6(string B717E6BF)
		{
			return B717E6BF.Split('|')[0];
		}
	}

	internal GClass4 B79E0D83;

	internal string string_0;

	internal string string_1;

	internal string F21AEE3B;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal static bool DF09D9B0;

	internal string string_2 = "";

	internal int int_0 = 0;

	internal List<string> B8211F33 = new List<string>();

	internal List<string> E23DBA94 = new List<string>();

	internal List<string> CAA0181B = new List<string>();

	internal List<string> list_0 = new List<string>();

	internal List<string> list_1 = new List<string>();

	internal List<string> E31ABA86 = new List<string>();

	internal List<string> list_2 = new List<string>();

	internal List<string> list_3 = new List<string>();

	internal List<string> list_4 = new List<string>();

	internal List<string> E810EC18 = new List<string>
	{
		"1|Single", "2|In a relationship", "5|Engaged", "4|Married", "10|In a civil union", "11|In a domestic partnership", "3|In an open relationship", "6|It's complicated", "8|Separated", "9|Divorced",
		"7|Widowed"
	};

	internal List<string> list_5 = new List<string> { "1|Female", "2|Male" };

	internal IContainer icontainer_0 = null;

	internal BunifuDragControl bunifuDragControl_0;

	internal BunifuDragControl bunifuDragControl_1;

	internal Panel pnlTopAccent;

	internal Button btnMinimize;

	internal Panel EE160C25;

	internal TextBox A01B05AC;

	internal Label B527E3BD;

	internal Button FC3DE60E;

	internal Button AF82F5BC;

	internal BunifuCards bunifuCards1;

	internal Panel pnlHeader;

	internal Button BF8A47BE;

	internal PictureBox A10932AC;

	internal BunifuCustomLabel bunifuCustomLabel1;

	internal Button F1399A8E;

	internal CheckBox ckbRelationship;

	internal CheckBox BB0FDB14;

	internal CheckBox ckbCollege;

	internal CheckBox ckbHighSchool;

	internal CheckBox ckbWork;

	internal Button btnNhapCurrentCity;

	internal Button EEBF7886;

	internal Button btnNhapWork;

	internal CheckBox B72166A4;

	internal ComboBox cbbRelationship;

	internal CheckBox ckbHometown;

	internal Button D82E6235;

	internal ComboBox cbbGender;

	internal CheckBox ckbGender;

	internal CheckBox ckbBirthday;

	internal Button btnYear;

	internal Button btnMonth;

	internal Button btnDay;

	internal CheckBox ckbNickname;

	internal Button btnNickname;

	internal Panel E2392D0E;

	internal ComboBox cbbIfHaveWork;

	internal Label label3;

	internal Label ED3CF78C;

	internal Panel plCollege;

	internal ComboBox EFA1299C;

	internal Label D80D2EAF;

	internal Label label7;

	internal Panel plHighSchool;

	internal ComboBox cbbIfHaveHighSchool;

	internal Label ED3DE6A4;

	internal Label D3A6ABAA;

	internal Button D598A93C;

	public static bool Boolean_0
	{
		[CompilerGenerated]
		get
		{
			return DF09D9B0;
		}
		[CompilerGenerated]
		set
		{
			DF09D9B0 = value;
		}
	}

	public fHDCapNhatThongTin(string A7B9AF04, string string_3 = "")
	{
		InitializeComponent();
		Boolean_0 = false;
		string_0 = A7B9AF04;
		F21AEE3B = string_3;
		string aA239C = Language.GetValue(bunifuCustomLabel1.Text).Replace("Cấu hình ", "").Replace("Configure ", "");
		string text = base.Name.Substring(1);
		Class154.FA0E41AD(text, aA239C);
		string text2 = "";
		if (string_3 == "")
		{
			DataTable dataTable = Class154.BD904B3B(text);
			string_1 = dataTable.Rows[0]["Id_TuongTac"].ToString();
			A01B05AC.Text = Language.GetValue(dataTable.Rows[0]["MoTa"].ToString());
		}
		else
		{
			DataTable dataTable2 = Class154.E6AD9687(string_3);
			text2 = dataTable2.Rows[0]["CauHinh"].ToString();
			AF82F5BC.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
			A01B05AC.Text = dataTable2.Rows[0]["TenHanhDong"].ToString();
		}
		B79E0D83 = new GClass4(text2, F79F9AB5: true);
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

	private void E7897698(object sender, EventArgs e)
	{
		A0124B33();
		method_1();
		method_0(cbbIfHaveWork);
		method_0(cbbIfHaveHighSchool);
		method_0(EFA1299C);
		try
		{
			B72166A4.Checked = B79E0D83.method_3("ckbBio");
			ckbWork.Checked = B79E0D83.method_3("ckbWork");
			cbbIfHaveWork.SelectedIndex = B79E0D83.method_2("cbbIfHaveWork");
			ckbHighSchool.Checked = B79E0D83.method_3("ckbHighSchool");
			cbbIfHaveHighSchool.SelectedIndex = B79E0D83.method_2("cbbIfHaveHighSchool");
			ckbCollege.Checked = B79E0D83.method_3("ckbCollege");
			EFA1299C.SelectedIndex = B79E0D83.method_2("cbbIfHaveCollege");
			BB0FDB14.Checked = B79E0D83.method_3("ckbCurrentCity");
			ckbHometown.Checked = B79E0D83.method_3("ckbHometown");
			ckbRelationship.Checked = B79E0D83.method_3("ckbRelationship");
			ckbGender.Checked = B79E0D83.method_3("ckbGender");
			ckbBirthday.Checked = B79E0D83.method_3("ckbBirthday");
			ckbNickname.Checked = B79E0D83.method_3("ckbNickname");
			string_2 = B79E0D83.BDB80B23("txtBio");
			int_0 = B79E0D83.method_2("typeSplitBio");
			B8211F33 = B79E0D83.method_1("lstWork");
			E23DBA94 = B79E0D83.method_1("lstHighSchool");
			CAA0181B = B79E0D83.method_1("lstCollege");
			list_0 = B79E0D83.method_1("lstCurrentCity");
			list_1 = B79E0D83.method_1("lstHometown");
			cbbRelationship.SelectedValue = ((B79E0D83.BDB80B23("cbbRelationship", "-1").Split('|').Length == 1) ? B79E0D83.BDB80B23("cbbRelationship", "-1") : "-1");
			cbbGender.SelectedValue = ((B79E0D83.BDB80B23("cbbGender", "-1").Split('|').Length == 1) ? B79E0D83.BDB80B23("cbbGender", "-1") : "-1");
			E31ABA86 = B79E0D83.method_1("lstDay");
			list_2 = B79E0D83.method_1("lstMonth");
			list_3 = B79E0D83.method_1("lstYear");
			list_4 = B79E0D83.method_1("lstNickname");
			B72166A4_CheckedChanged(null, null);
			ckbWork_CheckedChanged(null, null);
			ckbHighSchool_CheckedChanged(null, null);
			F180AC03(null, null);
			E58C2E88(null, null);
			ckbHometown_CheckedChanged(null, null);
			E10FAEAC(null, null);
			D28FE523(null, null);
			ckbBirthday_CheckedChanged(null, null);
			ckbNickname_CheckedChanged(null, null);
			Commom.E998C514(btnNhapCurrentCity, list_0.Count);
			Commom.E998C514(D82E6235, list_1.Count);
			Commom.E998C514(EEBF7886, CAA0181B.Count);
			Commom.E998C514(D598A93C, E23DBA94.Count);
			Commom.E998C514(btnNhapWork, B8211F33.Count);
			Commom.E998C514(F1399A8E, string_2.Split(new string[1] { (int_0 == 0) ? "\n" : "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).Length);
			Commom.E998C514(btnNickname, list_4.Count);
		}
		catch
		{
		}
	}

	private void method_0(ComboBox EB28A10B)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "Tiê\u0301p tu\u0323c thêm thông tin");
		dictionary.Add("1", "Không thêm thông tin nư\u0303a");
		dictionary.Add("2", "Xo\u0301a thông tin cu\u0303");
		Commom.smethod_24(EB28A10B, dictionary);
	}

	private void method_1()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < list_5.Count; i++)
		{
			dictionary.Add(list_5[i].Split('|')[0], list_5[i].Split('|')[1]);
		}
		dictionary.Add("-1", "Random");
		cbbGender.DataSource = new BindingSource(dictionary, null);
		cbbGender.DisplayMember = "Value";
		cbbGender.ValueMember = "Key";
	}

	private void A0124B33()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < E810EC18.Count; i++)
		{
			dictionary.Add(E810EC18[i].Split('|')[0], E810EC18[i].Split('|')[1]);
		}
		dictionary.Add("-1", "Random");
		cbbRelationship.DataSource = new BindingSource(dictionary, null);
		cbbRelationship.DisplayMember = "Value";
		cbbRelationship.ValueMember = "Key";
	}

	private void BF8A47BE_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void C1B55E91(object sender, EventArgs e)
	{
		string text = A01B05AC.Text.Trim();
		if (text == "")
		{
			MsBoxHelper.Show(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
			return;
		}
		GClass4 gClass = new GClass4();
		gClass.method_4("ckbBio", B72166A4.Checked);
		gClass.method_4("ckbWork", ckbWork.Checked);
		gClass.method_4("cbbIfHaveWork", cbbIfHaveWork.SelectedIndex);
		gClass.method_4("ckbHighSchool", ckbHighSchool.Checked);
		gClass.method_4("cbbIfHaveHighSchool", cbbIfHaveHighSchool.SelectedIndex);
		gClass.method_4("ckbCollege", ckbCollege.Checked);
		gClass.method_4("cbbIfHaveCollege", EFA1299C.SelectedIndex);
		gClass.method_4("ckbCurrentCity", BB0FDB14.Checked);
		gClass.method_4("ckbHometown", ckbHometown.Checked);
		gClass.method_4("ckbRelationship", ckbRelationship.Checked);
		gClass.method_4("ckbGender", ckbGender.Checked);
		gClass.method_4("ckbBirthday", ckbBirthday.Checked);
		gClass.method_4("ckbNickname", ckbNickname.Checked);
		gClass.method_4("txtBio", string_2);
		gClass.method_4("typeSplitBio", int_0);
		gClass.FD3CCF90("lstWork", B8211F33);
		gClass.FD3CCF90("lstHighSchool", E23DBA94);
		gClass.FD3CCF90("lstCollege", CAA0181B);
		gClass.FD3CCF90("lstCurrentCity", list_0);
		gClass.FD3CCF90("lstHometown", list_1);
		string text2 = cbbRelationship.SelectedValue.ToString();
		text2 = ((text2 == "-1") ? string.Join("|", E810EC18.Select((string string_0) => string_0.Split('|')[0])) : text2);
		gClass.method_4("cbbRelationship", text2);
		string text3 = cbbGender.SelectedValue.ToString();
		text3 = ((text3 == "-1") ? string.Join("|", list_5.Select((string B717E6BF) => B717E6BF.Split('|')[0])) : text3);
		gClass.method_4("cbbGender", text3);
		gClass.FD3CCF90("lstDay", E31ABA86);
		gClass.FD3CCF90("lstMonth", list_2);
		gClass.FD3CCF90("lstYear", list_3);
		gClass.FD3CCF90("lstNickname", list_4);
		string e013A = gClass.ED11179C();
		if (F21AEE3B == "")
		{
			if (MsBoxHelper.D41C45AC(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
			{
				if (Class154.smethod_11(string_0, text, string_1, e013A))
				{
					Boolean_0 = true;
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
			if (Class154.smethod_13(F21AEE3B, text, e013A))
			{
				Boolean_0 = true;
				Close();
			}
			else
			{
				MsBoxHelper.Show(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}
	}

	private void ED12A58A(object sender, EventArgs e)
	{
		Close();
	}

	private void EE160C25_Paint(object sender, PaintEventArgs e)
	{
		if (EE160C25.BorderStyle == BorderStyle.FixedSingle)
		{
			int num = 1;
			int num2 = 0;
			using Pen pen = new Pen(Color.DarkViolet, 1f);
			e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, EE160C25.ClientSize.Width - num, EE160C25.ClientSize.Height - num));
		}
	}

	private void B72166A4_CheckedChanged(object sender, EventArgs e)
	{
		F1399A8E.Enabled = B72166A4.Checked;
	}

	private void ckbWork_CheckedChanged(object sender, EventArgs e)
	{
		E2392D0E.Enabled = ckbWork.Checked;
	}

	private void ckbHighSchool_CheckedChanged(object sender, EventArgs e)
	{
		plHighSchool.Enabled = ckbHighSchool.Checked;
	}

	private void F180AC03(object sender, EventArgs e)
	{
		plCollege.Enabled = ckbCollege.Checked;
	}

	private void E58C2E88(object sender, EventArgs e)
	{
		btnNhapCurrentCity.Enabled = BB0FDB14.Checked;
	}

	private void E10FAEAC(object sender, EventArgs e)
	{
		cbbRelationship.Enabled = ckbRelationship.Checked;
	}

	private void F1399A8E_Click(object sender, EventArgs e)
	{
		fNhapDuLieu3 fNhapDuLieu4 = new fNhapDuLieu3(string_2, int_0, Language.GetValue("Nhâ\u0323p danh sa\u0301ch Bio"), Language.GetValue("Danh sa\u0301ch Bio"));
		Commom.smethod_35(fNhapDuLieu4);
		string_2 = fNhapDuLieu4.C90D3E02;
		int_0 = fNhapDuLieu4.A732C0B9;
		Commom.E998C514(F1399A8E, string_2.Split(new string[1] { (int_0 == 0) ? "\n" : "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).Length);
	}

	private void btnNhapWork_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(B8211F33, "Nhâ\u0323p danh sa\u0301ch Work", "Danh sa\u0301ch Work", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		B8211F33 = fNhapDuLieu4.list_0;
		Commom.E998C514(btnNhapWork, B8211F33.Count);
	}

	private void D598A93C_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(E23DBA94, "Nhâ\u0323p danh sa\u0301ch High School", "Danh sa\u0301ch High School", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		E23DBA94 = fNhapDuLieu4.list_0;
		Commom.E998C514(D598A93C, E23DBA94.Count);
	}

	private void EEBF7886_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(CAA0181B, "Nhâ\u0323p danh sa\u0301ch College", "Danh sa\u0301ch College", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		CAA0181B = fNhapDuLieu4.list_0;
		Commom.E998C514(EEBF7886, CAA0181B.Count);
	}

	private void CD305BB1(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_0, "Nhâ\u0323p danh sa\u0301ch Current City", "Danh sa\u0301ch Current City", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_0 = fNhapDuLieu4.list_0;
		Commom.E998C514(btnNhapCurrentCity, list_0.Count);
	}

	private void ckbHometown_CheckedChanged(object sender, EventArgs e)
	{
		D82E6235.Enabled = ckbHometown.Checked;
	}

	private void DE295DB9(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_1, "Nhâ\u0323p danh sa\u0301ch Hometown", "Danh sa\u0301ch Hometown", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_1 = fNhapDuLieu4.list_0;
		Commom.E998C514(D82E6235, list_1.Count);
	}

	private void btnDay_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(E31ABA86, "Nhâ\u0323p danh sa\u0301ch ngày", "Danh sa\u0301ch ngày", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		E31ABA86 = fNhapDuLieu4.list_0;
	}

	private void btnMonth_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_2, "Nhâ\u0323p danh sa\u0301ch tháng", "Danh sa\u0301ch tháng", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_2 = fNhapDuLieu4.list_0;
	}

	private void btnYear_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_3, "Nhâ\u0323p danh sa\u0301ch năm", "Danh sa\u0301ch năm", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_3 = fNhapDuLieu4.list_0;
	}

	private void D28FE523(object sender, EventArgs e)
	{
		cbbGender.Enabled = ckbGender.Checked;
	}

	private void ckbBirthday_CheckedChanged(object sender, EventArgs e)
	{
		btnDay.Enabled = ckbBirthday.Checked;
		btnMonth.Enabled = ckbBirthday.Checked;
		btnYear.Enabled = ckbBirthday.Checked;
	}

	private void btnNickname_Click(object sender, EventArgs e)
	{
		fNhapDuLieu1 fNhapDuLieu4 = new fNhapDuLieu1(list_4, "Nhâ\u0323p danh sa\u0301ch Nickname", "Danh sa\u0301ch Nickname", "(Mô\u0303i nội dung 1 do\u0300ng)");
		Commom.smethod_35(fNhapDuLieu4);
		list_4 = fNhapDuLieu4.list_0;
		Commom.E998C514(btnNickname, list_4.Count);
	}

	private void ckbNickname_CheckedChanged(object sender, EventArgs e)
	{
		btnNickname.Enabled = ckbNickname.Checked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHDCapNhatThongTin));
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
		bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		pnlTopAccent = new System.Windows.Forms.Panel();
		btnMinimize = new System.Windows.Forms.Button();
		pnlHeader = new System.Windows.Forms.Panel();
		BF8A47BE = new System.Windows.Forms.Button();
		A10932AC = new System.Windows.Forms.PictureBox();
		EE160C25 = new System.Windows.Forms.Panel();
		plCollege = new System.Windows.Forms.Panel();
		EFA1299C = new System.Windows.Forms.ComboBox();
		D80D2EAF = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		EEBF7886 = new System.Windows.Forms.Button();
		plHighSchool = new System.Windows.Forms.Panel();
		cbbIfHaveHighSchool = new System.Windows.Forms.ComboBox();
		ED3DE6A4 = new System.Windows.Forms.Label();
		D3A6ABAA = new System.Windows.Forms.Label();
		D598A93C = new System.Windows.Forms.Button();
		E2392D0E = new System.Windows.Forms.Panel();
		cbbIfHaveWork = new System.Windows.Forms.ComboBox();
		btnNhapWork = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		ED3CF78C = new System.Windows.Forms.Label();
		btnYear = new System.Windows.Forms.Button();
		btnMonth = new System.Windows.Forms.Button();
		btnDay = new System.Windows.Forms.Button();
		cbbGender = new System.Windows.Forms.ComboBox();
		ckbNickname = new System.Windows.Forms.CheckBox();
		ckbBirthday = new System.Windows.Forms.CheckBox();
		cbbRelationship = new System.Windows.Forms.ComboBox();
		ckbGender = new System.Windows.Forms.CheckBox();
		ckbRelationship = new System.Windows.Forms.CheckBox();
		ckbHometown = new System.Windows.Forms.CheckBox();
		BB0FDB14 = new System.Windows.Forms.CheckBox();
		ckbCollege = new System.Windows.Forms.CheckBox();
		ckbHighSchool = new System.Windows.Forms.CheckBox();
		ckbWork = new System.Windows.Forms.CheckBox();
		D82E6235 = new System.Windows.Forms.Button();
		btnNhapCurrentCity = new System.Windows.Forms.Button();
		B72166A4 = new System.Windows.Forms.CheckBox();
		btnNickname = new System.Windows.Forms.Button();
		F1399A8E = new System.Windows.Forms.Button();
		A01B05AC = new System.Windows.Forms.TextBox();
		B527E3BD = new System.Windows.Forms.Label();
		FC3DE60E = new System.Windows.Forms.Button();
		AF82F5BC = new System.Windows.Forms.Button();
		bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
		pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)A10932AC).BeginInit();
		EE160C25.SuspendLayout();
		plCollege.SuspendLayout();
		plHighSchool.SuspendLayout();
		E2392D0E.SuspendLayout();
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
		bunifuCustomLabel1.Size = new System.Drawing.Size(837, 31);
		bunifuCustomLabel1.TabIndex = 12;
		bunifuCustomLabel1.Text = "Cấu hình Cập nhật thông tin";
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
		pnlHeader.Controls.Add(BF8A47BE);
		pnlHeader.Controls.Add(A10932AC);
		pnlHeader.Controls.Add(bunifuCustomLabel1);
		pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
		pnlHeader.Location = new System.Drawing.Point(0, 3);
		pnlHeader.Name = "pnlHeader";
		pnlHeader.Size = new System.Drawing.Size(837, 31);
		pnlHeader.TabIndex = 9;
		pnlHeader.Resize += (s, e) =>
		{
			if (BF8A47BE != null) BF8A47BE.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
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

		BF8A47BE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		BF8A47BE.Cursor = System.Windows.Forms.Cursors.Hand;
		BF8A47BE.FlatAppearance.BorderSize = 0;
		BF8A47BE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		BF8A47BE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		BF8A47BE.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
		System.Drawing.Image iconClose = AppIconHelper.GetIcon("close_window.png", 24, 24);
		BF8A47BE.Image = iconClose ?? ((System.Drawing.Image)resources.GetObject("button1.Image"));
		BF8A47BE.Text = iconClose == null ? "✕" : "";
		BF8A47BE.Location = new System.Drawing.Point(pnlHeader.Width - 34, 1);
		BF8A47BE.Name = "button1";
		BF8A47BE.Size = new System.Drawing.Size(30, 30);
		BF8A47BE.TabIndex = 77;
		BF8A47BE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		BF8A47BE.UseVisualStyleBackColor = true;
		BF8A47BE.Click += new System.EventHandler(BF8A47BE_Click);
		A10932AC.Cursor = System.Windows.Forms.Cursors.Default;
		A10932AC.Image = Class155.DD225F0D;
		A10932AC.Location = new System.Drawing.Point(3, 2);
		A10932AC.Name = "pictureBox1";
		A10932AC.Size = new System.Drawing.Size(34, 27);
		A10932AC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		A10932AC.TabIndex = 76;
		A10932AC.TabStop = false;
		EE160C25.BackColor = System.Drawing.Color.White;
		EE160C25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		EE160C25.Controls.Add(plCollege);
		EE160C25.Controls.Add(plHighSchool);
		EE160C25.Controls.Add(E2392D0E);
		EE160C25.Controls.Add(btnYear);
		EE160C25.Controls.Add(btnMonth);
		EE160C25.Controls.Add(btnDay);
		EE160C25.Controls.Add(cbbGender);
		EE160C25.Controls.Add(ckbNickname);
		EE160C25.Controls.Add(ckbBirthday);
		EE160C25.Controls.Add(cbbRelationship);
		EE160C25.Controls.Add(ckbGender);
		EE160C25.Controls.Add(ckbRelationship);
		EE160C25.Controls.Add(ckbHometown);
		EE160C25.Controls.Add(BB0FDB14);
		EE160C25.Controls.Add(ckbCollege);
		EE160C25.Controls.Add(ckbHighSchool);
		EE160C25.Controls.Add(ckbWork);
		EE160C25.Controls.Add(D82E6235);
		EE160C25.Controls.Add(btnNhapCurrentCity);
		EE160C25.Controls.Add(B72166A4);
		EE160C25.Controls.Add(btnNickname);
		EE160C25.Controls.Add(F1399A8E);
		EE160C25.Controls.Add(A01B05AC);
		EE160C25.Controls.Add(B527E3BD);
		EE160C25.Controls.Add(FC3DE60E);
		EE160C25.Controls.Add(AF82F5BC);
		EE160C25.Controls.Add(bunifuCards1);
		EE160C25.Controls.Add(pnlTopAccent);
		pnlTopAccent.BringToFront();
		EE160C25.Cursor = System.Windows.Forms.Cursors.Arrow;
		EE160C25.Dock = System.Windows.Forms.DockStyle.Fill;
		EE160C25.Location = new System.Drawing.Point(0, 0);
		EE160C25.Name = "panel1";
		EE160C25.Size = new System.Drawing.Size(840, 425);
		EE160C25.TabIndex = 0;
		EE160C25.Paint += new System.Windows.Forms.PaintEventHandler(EE160C25_Paint);
		plCollege.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plCollege.Controls.Add(EFA1299C);
		plCollege.Controls.Add(D80D2EAF);
		plCollege.Controls.Add(label7);
		plCollege.Controls.Add(EEBF7886);
		plCollege.Location = new System.Drawing.Point(29, 299);
		plCollege.Name = "plCollege";
		plCollege.Size = new System.Drawing.Size(322, 66);
		plCollege.TabIndex = 129;
		EFA1299C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		EFA1299C.FormattingEnabled = true;
		EFA1299C.Location = new System.Drawing.Point(130, 36);
		EFA1299C.Name = "cbbIfHaveCollege";
		EFA1299C.Size = new System.Drawing.Size(185, 24);
		EFA1299C.TabIndex = 125;
		D80D2EAF.AutoSize = true;
		D80D2EAF.Location = new System.Drawing.Point(3, 39);
		D80D2EAF.Name = "label6";
		D80D2EAF.Size = new System.Drawing.Size(123, 16);
		D80D2EAF.TabIndex = 31;
		D80D2EAF.Text = "Nê\u0301u đa\u0303 co\u0301 thông tin:";
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(3, 9);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(84, 16);
		label7.TabIndex = 31;
		label7.Text = "Nhâ\u0323p dư\u0303 liê\u0323u:";
		EEBF7886.Cursor = System.Windows.Forms.Cursors.Hand;
		EEBF7886.Location = new System.Drawing.Point(129, 4);
		EEBF7886.Name = "btnNhapCollege";
		EEBF7886.Size = new System.Drawing.Size(187, 27);
		EEBF7886.TabIndex = 124;
		EEBF7886.Text = "Nhập (0)";
		EEBF7886.UseVisualStyleBackColor = true;
		EEBF7886.Click += new System.EventHandler(EEBF7886_Click);
		plHighSchool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		plHighSchool.Controls.Add(cbbIfHaveHighSchool);
		plHighSchool.Controls.Add(ED3DE6A4);
		plHighSchool.Controls.Add(D3A6ABAA);
		plHighSchool.Controls.Add(D598A93C);
		plHighSchool.Location = new System.Drawing.Point(29, 205);
		plHighSchool.Name = "plHighSchool";
		plHighSchool.Size = new System.Drawing.Size(322, 66);
		plHighSchool.TabIndex = 129;
		cbbIfHaveHighSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbIfHaveHighSchool.FormattingEnabled = true;
		cbbIfHaveHighSchool.Location = new System.Drawing.Point(130, 36);
		cbbIfHaveHighSchool.Name = "cbbIfHaveHighSchool";
		cbbIfHaveHighSchool.Size = new System.Drawing.Size(185, 24);
		cbbIfHaveHighSchool.TabIndex = 125;
		ED3DE6A4.AutoSize = true;
		ED3DE6A4.Location = new System.Drawing.Point(3, 39);
		ED3DE6A4.Name = "label4";
		ED3DE6A4.Size = new System.Drawing.Size(123, 16);
		ED3DE6A4.TabIndex = 31;
		ED3DE6A4.Text = "Nê\u0301u đa\u0303 co\u0301 thông tin:";
		D3A6ABAA.AutoSize = true;
		D3A6ABAA.Location = new System.Drawing.Point(3, 9);
		D3A6ABAA.Name = "label5";
		D3A6ABAA.Size = new System.Drawing.Size(84, 16);
		D3A6ABAA.TabIndex = 31;
		D3A6ABAA.Text = "Nhâ\u0323p dư\u0303 liê\u0323u:";
		D598A93C.Cursor = System.Windows.Forms.Cursors.Hand;
		D598A93C.Location = new System.Drawing.Point(129, 4);
		D598A93C.Name = "btnNhapHighSchool";
		D598A93C.Size = new System.Drawing.Size(187, 27);
		D598A93C.TabIndex = 124;
		D598A93C.Text = "Nhập (0)";
		D598A93C.UseVisualStyleBackColor = true;
		D598A93C.Click += new System.EventHandler(D598A93C_Click);
		E2392D0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		E2392D0E.Controls.Add(cbbIfHaveWork);
		E2392D0E.Controls.Add(btnNhapWork);
		E2392D0E.Controls.Add(label3);
		E2392D0E.Controls.Add(ED3CF78C);
		E2392D0E.Location = new System.Drawing.Point(29, 110);
		E2392D0E.Name = "plWork";
		E2392D0E.Size = new System.Drawing.Size(322, 67);
		E2392D0E.TabIndex = 129;
		cbbIfHaveWork.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbIfHaveWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbIfHaveWork.FormattingEnabled = true;
		cbbIfHaveWork.Location = new System.Drawing.Point(130, 36);
		cbbIfHaveWork.Name = "cbbIfHaveWork";
		cbbIfHaveWork.Size = new System.Drawing.Size(185, 24);
		cbbIfHaveWork.TabIndex = 125;
		btnNhapWork.Cursor = System.Windows.Forms.Cursors.Hand;
		btnNhapWork.Location = new System.Drawing.Point(129, 4);
		btnNhapWork.Name = "btnNhapWork";
		btnNhapWork.Size = new System.Drawing.Size(187, 27);
		btnNhapWork.TabIndex = 124;
		btnNhapWork.Text = "Nhập (0)";
		btnNhapWork.UseVisualStyleBackColor = true;
		btnNhapWork.Click += new System.EventHandler(btnNhapWork_Click);
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(3, 39);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(123, 16);
		label3.TabIndex = 31;
		label3.Text = "Nê\u0301u đa\u0303 co\u0301 thông tin:";
		ED3CF78C.AutoSize = true;
		ED3CF78C.Location = new System.Drawing.Point(3, 9);
		ED3CF78C.Name = "label2";
		ED3CF78C.Size = new System.Drawing.Size(84, 16);
		ED3CF78C.TabIndex = 31;
		ED3CF78C.Text = "Nhâ\u0323p dư\u0303 liê\u0323u:";
		btnYear.Cursor = System.Windows.Forms.Cursors.Hand;
		btnYear.Location = new System.Drawing.Point(744, 244);
		btnYear.Name = "btnYear";
		btnYear.Size = new System.Drawing.Size(61, 25);
		btnYear.TabIndex = 128;
		btnYear.Text = "Năm";
		btnYear.UseVisualStyleBackColor = true;
		btnYear.Click += new System.EventHandler(btnYear_Click);
		btnMonth.Cursor = System.Windows.Forms.Cursors.Hand;
		btnMonth.Location = new System.Drawing.Point(676, 244);
		btnMonth.Name = "btnMonth";
		btnMonth.Size = new System.Drawing.Size(61, 25);
		btnMonth.TabIndex = 128;
		btnMonth.Text = "Tháng";
		btnMonth.UseVisualStyleBackColor = true;
		btnMonth.Click += new System.EventHandler(btnMonth_Click);
		btnDay.Cursor = System.Windows.Forms.Cursors.Hand;
		btnDay.Location = new System.Drawing.Point(609, 244);
		btnDay.Name = "btnDay";
		btnDay.Size = new System.Drawing.Size(61, 25);
		btnDay.TabIndex = 128;
		btnDay.Text = "Ngày";
		btnDay.UseVisualStyleBackColor = true;
		btnDay.Click += new System.EventHandler(btnDay_Click);
		cbbGender.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbGender.FormattingEnabled = true;
		cbbGender.Location = new System.Drawing.Point(609, 215);
		cbbGender.Name = "cbbGender";
		cbbGender.Size = new System.Drawing.Size(195, 24);
		cbbGender.TabIndex = 126;
		ckbNickname.AutoSize = true;
		ckbNickname.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbNickname.Location = new System.Drawing.Point(388, 279);
		ckbNickname.Name = "ckbNickname";
		ckbNickname.Size = new System.Drawing.Size(81, 20);
		ckbNickname.TabIndex = 125;
		ckbNickname.Text = "Nickname";
		ckbNickname.UseVisualStyleBackColor = true;
		ckbNickname.CheckedChanged += new System.EventHandler(ckbNickname_CheckedChanged);
		ckbBirthday.AutoSize = true;
		ckbBirthday.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbBirthday.Location = new System.Drawing.Point(388, 247);
		ckbBirthday.Name = "ckbBirthday";
		ckbBirthday.Size = new System.Drawing.Size(141, 20);
		ckbBirthday.TabIndex = 125;
		ckbBirthday.Text = "Ngày sinh (Birthday)";
		ckbBirthday.UseVisualStyleBackColor = true;
		ckbBirthday.CheckedChanged += new System.EventHandler(ckbBirthday_CheckedChanged);
		cbbRelationship.Cursor = System.Windows.Forms.Cursors.Hand;
		cbbRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbRelationship.FormattingEnabled = true;
		cbbRelationship.Location = new System.Drawing.Point(609, 185);
		cbbRelationship.Name = "cbbRelationship";
		cbbRelationship.Size = new System.Drawing.Size(195, 24);
		cbbRelationship.TabIndex = 126;
		ckbGender.AutoSize = true;
		ckbGender.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbGender.Location = new System.Drawing.Point(388, 217);
		ckbGender.Name = "ckbGender";
		ckbGender.Size = new System.Drawing.Size(127, 20);
		ckbGender.TabIndex = 125;
		ckbGender.Text = "Giới tính (Gender)";
		ckbGender.UseVisualStyleBackColor = true;
		ckbGender.CheckedChanged += new System.EventHandler(D28FE523);
		ckbRelationship.AutoSize = true;
		ckbRelationship.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbRelationship.Location = new System.Drawing.Point(388, 187);
		ckbRelationship.Name = "ckbRelationship";
		ckbRelationship.Size = new System.Drawing.Size(218, 20);
		ckbRelationship.TabIndex = 125;
		ckbRelationship.Text = "Tình trạng quan hệ (Relationship)";
		ckbRelationship.UseVisualStyleBackColor = true;
		ckbRelationship.CheckedChanged += new System.EventHandler(E10FAEAC);
		ckbHometown.AutoSize = true;
		ckbHometown.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHometown.Location = new System.Drawing.Point(388, 154);
		ckbHometown.Name = "ckbHometown";
		ckbHometown.Size = new System.Drawing.Size(156, 20);
		ckbHometown.TabIndex = 125;
		ckbHometown.Text = "Quê quán (Hometown)";
		ckbHometown.UseVisualStyleBackColor = true;
		ckbHometown.CheckedChanged += new System.EventHandler(ckbHometown_CheckedChanged);
		BB0FDB14.AutoSize = true;
		BB0FDB14.Cursor = System.Windows.Forms.Cursors.Hand;
		BB0FDB14.Location = new System.Drawing.Point(388, 121);
		BB0FDB14.Name = "ckbCurrentCity";
		BB0FDB14.Size = new System.Drawing.Size(215, 20);
		BB0FDB14.TabIndex = 125;
		BB0FDB14.Text = "Thành phố hiện tại (Current City)";
		BB0FDB14.UseVisualStyleBackColor = true;
		BB0FDB14.CheckedChanged += new System.EventHandler(E58C2E88);
		ckbCollege.AutoSize = true;
		ckbCollege.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbCollege.Location = new System.Drawing.Point(29, 277);
		ckbCollege.Name = "ckbCollege";
		ckbCollege.Size = new System.Drawing.Size(169, 20);
		ckbCollege.TabIndex = 125;
		ckbCollege.Text = "Trường đại học (College)";
		ckbCollege.UseVisualStyleBackColor = true;
		ckbCollege.CheckedChanged += new System.EventHandler(F180AC03);
		ckbHighSchool.AutoSize = true;
		ckbHighSchool.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbHighSchool.Location = new System.Drawing.Point(29, 183);
		ckbHighSchool.Name = "ckbHighSchool";
		ckbHighSchool.Size = new System.Drawing.Size(207, 20);
		ckbHighSchool.TabIndex = 125;
		ckbHighSchool.Text = "Trường trung học (High School)";
		ckbHighSchool.UseVisualStyleBackColor = true;
		ckbHighSchool.CheckedChanged += new System.EventHandler(ckbHighSchool_CheckedChanged);
		ckbWork.AutoSize = true;
		ckbWork.Cursor = System.Windows.Forms.Cursors.Hand;
		ckbWork.Location = new System.Drawing.Point(29, 88);
		ckbWork.Name = "ckbWork";
		ckbWork.Size = new System.Drawing.Size(125, 20);
		ckbWork.TabIndex = 125;
		ckbWork.Text = "Công việc (Work)";
		ckbWork.UseVisualStyleBackColor = true;
		ckbWork.CheckedChanged += new System.EventHandler(ckbWork_CheckedChanged);
		D82E6235.Cursor = System.Windows.Forms.Cursors.Hand;
		D82E6235.Location = new System.Drawing.Point(609, 150);
		D82E6235.Name = "btnNhapHometown";
		D82E6235.Size = new System.Drawing.Size(195, 27);
		D82E6235.TabIndex = 124;
		D82E6235.Text = "Nhập (0)";
		D82E6235.UseVisualStyleBackColor = true;
		D82E6235.Click += new System.EventHandler(DE295DB9);
		btnNhapCurrentCity.Cursor = System.Windows.Forms.Cursors.Hand;
		btnNhapCurrentCity.Location = new System.Drawing.Point(609, 117);
		btnNhapCurrentCity.Name = "btnNhapCurrentCity";
		btnNhapCurrentCity.Size = new System.Drawing.Size(195, 27);
		btnNhapCurrentCity.TabIndex = 124;
		btnNhapCurrentCity.Text = "Nhập (0)";
		btnNhapCurrentCity.UseVisualStyleBackColor = true;
		btnNhapCurrentCity.Click += new System.EventHandler(CD305BB1);
		B72166A4.AutoSize = true;
		B72166A4.Cursor = System.Windows.Forms.Cursors.Hand;
		B72166A4.Location = new System.Drawing.Point(388, 88);
		B72166A4.Name = "ckbBio";
		B72166A4.Size = new System.Drawing.Size(191, 20);
		B72166A4.TabIndex = 125;
		B72166A4.Text = "Tiểu sử mô tả bản thân (Bio)";
		B72166A4.UseVisualStyleBackColor = true;
		B72166A4.CheckedChanged += new System.EventHandler(B72166A4_CheckedChanged);
		btnNickname.Cursor = System.Windows.Forms.Cursors.Hand;
		btnNickname.Location = new System.Drawing.Point(609, 275);
		btnNickname.Name = "btnNickname";
		btnNickname.Size = new System.Drawing.Size(195, 27);
		btnNickname.TabIndex = 124;
		btnNickname.Text = "Nhập (0)";
		btnNickname.UseVisualStyleBackColor = true;
		btnNickname.Click += new System.EventHandler(btnNickname_Click);
		F1399A8E.Cursor = System.Windows.Forms.Cursors.Hand;
		F1399A8E.Location = new System.Drawing.Point(609, 84);
		F1399A8E.Name = "btnNhapBio";
		F1399A8E.Size = new System.Drawing.Size(101, 27);
		F1399A8E.TabIndex = 124;
		F1399A8E.Text = "Nhập (0)";
		F1399A8E.UseVisualStyleBackColor = true;
		F1399A8E.Click += new System.EventHandler(F1399A8E_Click);
		A01B05AC.Location = new System.Drawing.Point(125, 49);
		A01B05AC.Name = "txtTenHanhDong";
		A01B05AC.Size = new System.Drawing.Size(226, 23);
		A01B05AC.TabIndex = 0;
		B527E3BD.AutoSize = true;
		B527E3BD.Location = new System.Drawing.Point(26, 52);
		B527E3BD.Name = "label1";
		B527E3BD.Size = new System.Drawing.Size(98, 16);
		B527E3BD.TabIndex = 31;
		B527E3BD.Text = "Tên ha\u0300nh đô\u0323ng:";
		FC3DE60E.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		FC3DE60E.BackColor = System.Drawing.Color.Maroon;
		FC3DE60E.Cursor = System.Windows.Forms.Cursors.Hand;
		FC3DE60E.FlatAppearance.BorderSize = 0;
		FC3DE60E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		FC3DE60E.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		FC3DE60E.ForeColor = System.Drawing.Color.White;
		FC3DE60E.Location = new System.Drawing.Point(427, 380);
		FC3DE60E.Name = "btnCancel";
		FC3DE60E.Size = new System.Drawing.Size(92, 29);
		FC3DE60E.TabIndex = 7;
		FC3DE60E.Text = "Đóng";
		FC3DE60E.UseVisualStyleBackColor = false;
		FC3DE60E.Click += new System.EventHandler(ED12A58A);
		AF82F5BC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		AF82F5BC.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		AF82F5BC.Cursor = System.Windows.Forms.Cursors.Hand;
		AF82F5BC.FlatAppearance.BorderSize = 0;
		AF82F5BC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		AF82F5BC.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		AF82F5BC.ForeColor = System.Drawing.Color.White;
		AF82F5BC.Location = new System.Drawing.Point(320, 380);
		AF82F5BC.Name = "btnAdd";
		AF82F5BC.Size = new System.Drawing.Size(92, 29);
		AF82F5BC.TabIndex = 6;
		AF82F5BC.Text = "Thêm";
		AF82F5BC.UseVisualStyleBackColor = false;
		AF82F5BC.Click += new System.EventHandler(C1B55E91);
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
		bunifuCards1.Size = new System.Drawing.Size(837, 37);
		bunifuCards1.TabIndex = 28;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(840, 425);
		base.Controls.Add(EE160C25);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fHDCapNhatThongTin";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Cấu hình tương tác";
		base.Load += new System.EventHandler(E7897698);
		pnlHeader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)A10932AC).EndInit();
		EE160C25.ResumeLayout(false);
		EE160C25.PerformLayout();
		plCollege.ResumeLayout(false);
		plCollege.PerformLayout();
		plHighSchool.ResumeLayout(false);
		plHighSchool.PerformLayout();
		E2392D0E.ResumeLayout(false);
		E2392D0E.PerformLayout();
		bunifuCards1.ResumeLayout(false);
		ResumeLayout(false);
	}
}
